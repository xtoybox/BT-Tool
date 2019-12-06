Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading
Imports Microsoft.Office.Interop
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.NetworkInformation

Public Class frm_main
#Region "Initialize DLL"
    ''' <summary>
    ''' user32.dll function that captures user input
    ''' </summary>
    ''' <param name="plii"></param>
    ''' <returns></returns>
    <DllImport("user32.dll")> Shared Function GetLastInputInfo(ByRef plii As LASTINPUTINFO) As Boolean
    End Function
    <StructLayout(LayoutKind.Sequential)> Structure LASTINPUTINFO
        <MarshalAs(UnmanagedType.U4)> Public cbSize As Integer
        <MarshalAs(UnmanagedType.U4)> Public dwTime As Integer
    End Structure
#End Region

#Region "Initialize Classes"
    ''' <summary>
    ''' A class that contains custom functions.
    ''' </summary>
    Private cf As New markform.CustomClass
    ''' <summary>
    ''' A class for manipulating database (eg. INSERT,UPDATE,DELETE,SELECT)
    ''' </summary>
    Private db As New markform.SQLClass
    Private lastInputInf As New LASTINPUTINFO()
#End Region

#Region "Setting Variables"
    ''' <summary>
    ''' Timer variable for checking if the user is still waiting for a file or not.
    ''' </summary>
    Private isWait As Boolean = False
    ''' <summary>
    ''' The time at which the user wait for the file.
    ''' </summary>
    Private waitSTime As String = ""
    Private el_tick As Integer
    Private user_idle As Boolean = False
    Private IsWorkFileEnabled As Boolean = False
    Private last_tick As Integer = 0
    ''' <summary>
    ''' This variable is used to store the query string if an error occured when trying to execute the query.
    ''' </summary>
    Private ErrorQuery As String = ""
    ''' <summary>
    ''' <see langword="True"/> if there's a file currently selected else <see langword="False"/>
    ''' </summary>
    Private FileIsSelected As Boolean = False
    ''' <summary>
    ''' The workflow of the selected file.
    ''' </summary>
    Private WorkFlow As String
    ''' <summary>
    ''' The current workflow base on the index of the WorkFlow that is split into array
    ''' </summary>
    Private CurrentFlow As Integer
    ''' <summary>
    ''' The user id of the assigned qa on the selected file
    ''' </summary>
    Private QAUserID As Integer = 0
    ''' <summary>
    ''' The row index of the last selected row.
    ''' </summary>
    Private LastSelectedRowIndex As Integer = vbNull
    ''' <summary>
    ''' The directory of the file after the bet choose from open file dialog.
    ''' </summary>
    Private BETFileDirectory As String = ""
#End Region

#Region "Events"
    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Show()
        Console.WriteLine("File Exist 1: " & File.Exists("\\accomediasvr\MediaFiles-2\FROOT\TRANSCRIPT\CC\cc\DOWNLOAD-MCY-10042017\CA unit 0007 SYSMAN\test.txt"))
        Console.WriteLine("File Exist 2: " & File.Exists("\\172.16.3.54\MediaFiles-2\FROOT\TRANSCRIPT\CC\cc\DOWNLOAD-MCY-10042017\CA unit 0007 SYSMAN\test.txt"))
        Dim login As DialogResult = frm_login.ShowDialog(Me)
        LoginDefault(login)

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles IdleTimer.Tick, WaitTimer.Tick

        If Not BWTimer.IsBusy Then
            BWTimer.RunWorkerAsync(main_gridview)
        End If

    End Sub

    Private Sub btn_loginout_Click(sender As Object, e As EventArgs) Handles btn_loginout.Click
        Dim dr As DialogResult = MessageBox.Show("Are you sure you want to logout", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dr = DialogResult.Yes Then
            Try
                Dim qry As Integer = db.nQuery("UPDATE dbo.LogData set timeOut=@date WHERE Id=@id;
                    UPDATE dbo.userData SET status=@online WHERE Id =@id", New String() {"id", CustomVariables.CurrentUserID, "date", Date.Now, "online", "False"})
                If qry > 0 Then
                    If CustomVariables.FileID <> 0 Then
                        db.nQuery("UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & CustomVariables.FileID, New String() {"activeUser", 0, "active", "False"})
                        CustomVariables.FileID = 0
                    End If
                End If
                Me.Text = "BT TOOL"

                For Each frm As Form In My.Application.OpenForms
                    If Not New String() {Me.Name, frm_login.Name}.Contains(frm.Name) Then
                        frm.Close()
                    End If
                Next
                ClearForm()
                main_gridview.DataSource = vbNull
                IdleTimer.Stop()
                WaitTimer.Stop()
                ResetRestriction()
                'show login form
                Dim login As DialogResult = frm_login.ShowDialog(Me)
                LoginDefault(login)
            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            End Try
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        End
    End Sub

    Private Sub main_gridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles main_gridview.CellDoubleClick
        'prevent getting error when user double click on the column header
        If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Dim SelectedRow As DataGridViewRow = dgv.SelectedRows(0)
            'prevent user from selecting the file when the rowEnabled is not empty
            If Not cf.IsStringEmpty(SelectedRow.Cells(40).Value.ToString()) Then
                Dim msg As String = ""
                If SelectedRow.Cells(40).Value.ToString() = "NOT YET" Then
                    Dim topfile As String = dgv.Rows(0).Cells(8).Value.ToString()
                    msg = "You can't start on this file yet. " & vbNewLine & "Submit [" & topfile & "] first."
                Else
                    msg = "You can't start this file yet since the previous workflow is not done yet."
                End If
                MessageBox.Show(Me, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            'prevent user from selecting the file when the file is on hold
            If SelectedRow.Cells(41).Value Then
                Dim isPass As Boolean = True : Dim msg As String = ""
                For Each row As DataGridViewRow In dgv.Rows
                    If SelectedRow.Index <> row.Index And row.Cells(36).Value And Integer.Parse(row.Cells(39).Value.ToString()) = CustomVariables.CurrentUserID Then
                        Dim curfile As String = row.Cells(8).Value.ToString()
                        msg = "You can't start on this file yet. " & vbNewLine & "Submit [" & curfile & "] first."
                        isPass = False
                        Exit For
                    End If
                Next
                If Not isPass Then
                    MessageBox.Show(Me, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If
            'let the user select the file if the activeUser is equal to the current user or the activeUser is 0
            If SelectedRow.Cells(39).Value = CustomVariables.CurrentUserID Or SelectedRow.Cells(39).Value = 0 Then
                'prevent production users from selecting a file when there's still rush files left
                If CustomVariables.CurrentUserPosition.ToLower() = "prod" Then
                    Dim rushFile As List(Of String) = New List(Of String)
                    For Each row As DataGridViewRow In dgv.Rows
                        If CInt(row.Cells(2).Value) = True Then
                            rushFile.Add("- " & row.Cells(8).Value.ToString())
                        End If
                    Next
                    If SelectedRow.Cells(2).Value <> True And rushFile.Count <> 0 Then
                        If rushFile.Count <> 0 Then MessageBox.Show("You still have " & rushFile.Count & " rush file(s)." & vbNewLine & " Rush Files:" & vbNewLine & String.Join(vbNewLine, rushFile.ToArray()), "Rush found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                    End If
                End If

                Dim FileID As Integer = Integer.Parse(SelectedRow.Cells(0).Value)
                'set the activeUser and active status if current user is not a scheduler
                If Not CustomVariables.CurrentUserPosition Like "sched" Then
                    Dim qry As String = "UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & FileID.ToString()
                    Try
                        db.nQuery(qry, New String() {"activeUser", CustomVariables.CurrentUserID, "active", "True"})
                    Catch ex As Exception
                        cf.WriteToFile("{0}==>" & ex.ToString() & vbNewLine & qry, DebugFilePath)
                        MessageBox.Show(Me, "Something went wrong while trying to update active status of the file.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    dgv(36, e.RowIndex).Value = True
                End If
                FileIsSelected = True
                'update file information fields, priorities, work file and assign user if current selected file id is not equal to the last selected file id
                If CustomVariables.FileID <> FileID Then
                    'making sure that the main gridview is not empty
                    If dgv.Rows.Count > 0 Then

                        If SelectedRow.Cells(2).Value Then chk_rush.Checked = True
                        txt_receive.Text = SelectedRow.Cells(3).Value.ToString()
                        Try
                            cbo_service.Value = Date.Parse(SelectedRow.Cells(4).Value.ToString())
                        Catch

                        End Try

                        txt_due.Text = SelectedRow.Cells(5).Value.ToString()
                        txt_client.Text = SelectedRow.Cells(6).Value.ToString()
                        txt_branch.Text = SelectedRow.Cells(7).Value.ToString()
                        txt_audio.Text = SelectedRow.Cells(8).Value.ToString()
                        txt_duration.Text = SelectedRow.Cells(11).Value.ToString()
                        txt_document.Text = SelectedRow.Cells(12).Value.ToString()

                        Select Case CustomVariables.CurrentUserPosition
                            Case "admin", "ts", "auditor"
                                txt_page.Text = SelectedRow.Cells(15).Value.ToString()

                                cbo_bt.SelectedValue = SelectedRow.Cells(24).Value
                                cbo_qabt.SelectedValue = SelectedRow.Cells(25).Value
                                cbo_pr.SelectedValue = SelectedRow.Cells(26).Value
                                cbo_qapr.SelectedValue = SelectedRow.Cells(27).Value
                                cbo_st.SelectedValue = SelectedRow.Cells(28).Value
                                cbo_qast.SelectedValue = SelectedRow.Cells(29).Value
                                cbo_cc.SelectedValue = SelectedRow.Cells(30).Value
                                cbo_qacc.SelectedValue = SelectedRow.Cells(31).Value
                            Case "sched"
                                txt_page.Text = SelectedRow.Cells(15).Value.ToString()
                                Select Case CustomVariables.CurrentUserDepartment
                                    Case "bt"
                                        cbo_bt.SelectedValue = SelectedRow.Cells(24).Value
                                        cbo_qabt.SelectedValue = SelectedRow.Cells(25).Value
                                    Case "pr"
                                        cbo_pr.SelectedValue = SelectedRow.Cells(26).Value
                                        cbo_qapr.SelectedValue = SelectedRow.Cells(27).Value
                                    Case "bet"
                                        If CustomVariables.CurrentUDept = "st" Then
                                            cbo_st.SelectedValue = SelectedRow.Cells(28).Value
                                            cbo_qast.SelectedValue = SelectedRow.Cells(29).Value
                                        Else
                                            cbo_cc.SelectedValue = SelectedRow.Cells(30).Value
                                            cbo_qacc.SelectedValue = SelectedRow.Cells(31).Value
                                        End If
                                End Select
                            Case "prod"
                                If CustomVariables.CurrentUserDepartment = "bet" Then
                                    txt_page.Text = SelectedRow.Cells(15).Value.ToString()
                                End If
                        End Select

                        CustomVariables.RecDate = SelectedRow.Cells(3).Value.ToString()
                        CustomVariables.Client = SelectedRow.Cells(6).Value.ToString()
                        CustomVariables.Branch = SelectedRow.Cells(7).Value.ToString()
                        CustomVariables.SoundFile = SelectedRow.Cells(8).Value.ToString()
                        CustomVariables.ServSound = SelectedRow.Cells(9).Value.ToString()
                        CustomVariables.DocName = SelectedRow.Cells(12).Value.ToString()
                        CustomVariables.ServDoc = SelectedRow.Cells(13).Value.ToString()
                        CustomVariables.BTID = Integer.Parse(SelectedRow.Cells(24).Value)
                        CustomVariables.PRID = Integer.Parse(SelectedRow.Cells(26).Value)
                        CustomVariables.QAPRID = Integer.Parse(SelectedRow.Cells(27).Value)
                        CustomVariables.RetDirectory = SelectedRow.Cells(38).Value.ToString()

                        WorkFlow = SelectedRow.Cells(34).Value.ToString()
                        CurrentFlow = Integer.Parse(SelectedRow.Cells(35).Value)

                        'set qa user variable
                        If CustomVariables.CurrentUserPosition = "prod" Then
                            If CustomVariables.CurrentUDept = "bt" Then
                                If SelectedRow.Cells(25).Value <> 0 Then QAUserID = Integer.Parse(SelectedRow.Cells(25).Value)
                            ElseIf CustomVariables.CurrentUDept = "pr" Then
                                If SelectedRow.Cells(27).Value <> 0 Then QAUserID = Integer.Parse(SelectedRow.Cells(27).Value)
                            ElseIf CustomVariables.CurrentUDept = "st" Then
                                If SelectedRow.Cells(29).Value <> 0 Then QAUserID = Integer.Parse(SelectedRow.Cells(29).Value)
                            ElseIf CustomVariables.CurrentUDept = "cc" Then
                                If SelectedRow.Cells(31).Value <> 0 Then QAUserID = Integer.Parse(SelectedRow.Cells(31).Value)
                            End If
                        End If

                        Dim qry As String = "UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & CustomVariables.FileID
                        Try
                            db.nQuery(qry, New String() {"activeUser", 0, "active", "False"})

                            Dim SelectedRowIndex As Integer = e.RowIndex
                            If LastSelectedRowIndex <> vbNull Then SelectedRowIndex = LastSelectedRowIndex
                            dgv(36, SelectedRowIndex).Value = False
                            If LastSelectedRowIndex <> vbNull Then LastSelectedRowIndex = e.RowIndex
                        Catch ex As Exception
                            cf.WriteToFile("{0}==>" & ex.ToString() & vbNewLine & qry, DebugFilePath)
                            MessageBox.Show(Me, "Something went wrong while trying to update active status of the file.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                End If

                CustomVariables.FileID = Integer.Parse(SelectedRow.Cells(0).Value)
                If IsWorkFileEnabled Then gbox_work_file.Enabled = True 'GboxUList.Enabled = True
                LoadData()
            Else
                MessageBox.Show(Me, "The file is currently being opened by other user.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click

        If CustomVariables.FileID <> 0 Then
            Dim AddWhere As String = ""
            If CustomVariables.CurrentUserPosition.ToLower() <> "admin" Then
                AddWhere = " And activeUser = " & CustomVariables.CurrentUserID
            End If
            Dim qry As String = "UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & CustomVariables.FileID & " " & AddWhere
            Try
                db.nQuery(qry, New String() {"activeUser", 0, "active", "False"})
                FileIsSelected = False
                For Each row As DataGridViewRow In Me.main_gridview.Rows
                    If CInt(row.Cells(0).Value) = CustomVariables.FileID Then
                        row.Cells(35).Value = False
                        Exit For
                    End If
                Next
                ClearForm()
                CustomVariables.FileID = 0
                LoadData()
            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString() & vbNewLine & qry, DebugFilePath)
            End Try
        End If

    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        LoadData()
    End Sub

    Private Sub btn_file_Click(sender As Object, e As EventArgs) Handles btn_file.Click
        If Not cf.IsStringEmpty(txt_receive.Text) Then
            Try
                Dim CurDT As DateTime = DateTime.Parse(txt_receive.Text)
                Dim DownloadFolderName As String = "DOWNLOAD-" & Me.txt_client.Text & "-" & CurDT.ToString("MMddyyyy", CultureInfo.InvariantCulture)
                Dim DocumentDirectory As String = Path.Combine(CustomVariables.BaseServer, "FROOT\TRANSCRIPT", "BT", main_gridview.SelectedRows(0).Cells(16).Value, DownloadFolderName, txt_branch.Text, txt_document.Text)
                Dim DesktopDirectory As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, txt_document.Text)
                If File.Exists(DocumentDirectory) Then
                    File.Copy(DocumentDirectory, DesktopDirectory, True)
                    Process.Start(DesktopDirectory)
                Else
                    MessageBox.Show(Me, "File does not exist", "Missing BT File", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
                MessageBox.Show(Me, "Something went wrong while trying to copy the BT File from the server.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        Me.Cursor = Cursors.AppStarting
        lbl_gridview_status.Visible = True : lbl_gridview_status.Text = ""

        If CustomVariables.FileID = 0 Then
            MessageBox.Show(Me, "No file to submit.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'check if current user is pr and prID and QAUserID is equal to the current user ID
            If New Integer() {CustomVariables.PRID, QAUserID}.Contains(CustomVariables.CurrentUserID) And CustomVariables.CurrentUserDepartment = "pr" Then
                'if QAUserID is equal to current user ID them skip evaluation
                If CustomVariables.CurrentUserID = QAUserID Then
                    Submit(True)
                Else 'proceed to evaluation
                    'instantiate eval form class
                    Dim FileEvalForm As markform.frm_file_eval
                    'check if eval form is already open
                    If cf.IsFormOpen("frm_file_eval", True, "save") Then
                        'focus on the file eval form if it is already opened
                        cf.GetForm.Activate()
                    Else
                        lbl_gridview_status.Text = "Creating compares..."
                        Try
                            'instantiate microsoft word
                            Dim Wordapp As New Word.Application
                            'set variables
                            Dim servDir As String = Path.Combine(CustomVariables.BaseServer, main_gridview.SelectedRows(0).Cells(13).Value.ToString())
                            Dim OrigDoc As Word.Document = Wordapp.Documents.Open(Path.Combine(servDir, CustomVariables.DocName),, True)
                            Dim RevisedDoc As Word.Document = Wordapp.Documents.Open(Path.Combine(CustomVariables.FileLocalDirectory, CustomVariables.DocName),, True)
                            Dim CompareDoc As Word.Document = Wordapp.CompareDocuments(OrigDoc, RevisedDoc, Word.WdCompareDestination.wdCompareDestinationNew, Word.WdGranularity.wdGranularityWordLevel, True, True, True, True, True, True, True, True, True, True, "", False)
                            Dim savedir As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "compares_" & CustomVariables.DocName)
                            Dim wordCnt As Double = 0 : Dim mistakesCnt As Double = 0

                            Wordapp.ChangeFileOpenDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop)

                            wordCnt = WordCounter(OrigDoc.Range)
                            mistakesCnt = RevisionCounter(CompareDoc.Range)
                            'close the word document instances
                            OrigDoc.Close(False) : RevisedDoc.Close(False)

                            Wordapp.Options.SaveInterval() = 5 : CompareDoc.SaveAs(savedir) : Wordapp.Visible = True
                            'open file eval form
                            lbl_gridview_status.Text = "Opening file evaluation form..."
                            FileEvalForm = New markform.frm_file_eval(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment, main_gridview.SelectedRows(0).Cells(24).Value, CustomVariables.FileID, txt_document.Text, savedir, CustomVariables.Client, wordCnt, mistakesCnt}, "save", CustomVariables.CurrentUserRestriction)
                            lbl_gridview_status.Visible = True : lbl_gridview_status.Text = ""

                            Dim dr As DialogResult = FileEvalForm.ShowDialog(Me)
                            If dr = DialogResult.Yes Then
                                Submit(True)
                            End If
                        Catch ex As Exception
                            cf.Debug(ex)
                        End Try
                    End If
                End If
            Else
                Submit()
            End If
        End If
        Me.Cursor = Cursors.Default
        lbl_gridview_status.Visible = False : lbl_gridview_status.Text = ""

    End Sub

    Private Sub btn_Doc_Click(sender As Object, e As EventArgs) Handles btn_Doc.Click
        Dim CatchErrorMsg As String = "Something went wrong." 'Default error message

        Try
            'initialize microsoft word
            Dim oWord As Word.Application : Dim oDoc As Word.Document
            'set variables
            Dim servDoc As String = Path.Combine(CustomVariables.BaseServer, main_gridview.SelectedRows(0).Cells(13).Value.ToString, txt_document.Text)
            Dim locDoc As String = Path.Combine(CustomVariables.FileLocalDirectory, txt_document.Text)
            Dim fExt As String = Path.GetExtension(servDoc)
            Dim downDate As String = "UPLOAD-" & txt_client.Text & "-" & Convert.ToDateTime(txt_receive.Text).ToString("MMddyyyy", CultureInfo.InvariantCulture)
            Dim usrTime As String = CustomVariables.CurrentUDept & "Start='" & Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture) & "'"
            If CustomVariables.CurrentUDept = "cc" Then
                If txt_document.Text = "" Then
                    Using betFile As OpenFileDialog = New OpenFileDialog()
                        betFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                        betFile.Filter = "Word Document (*.doc)|*.doc|All files (*.*)|*.*"
                        betFile.FilterIndex = 1
                        betFile.RestoreDirectory = True
                        betFile.Multiselect = False
                        If betFile.ShowDialog() = DialogResult.OK Then
                            BETFileDirectory = betFile.FileName 'Path.GetDirectoryName(betFile.FileName)
                            txt_document.Text = betFile.SafeFileName
                        End If
                    End Using
                Else
                    Try
                        Dim newDir As String = Path.Combine(CustomVariables.BaseServer, CustomVariables.ServDoc) 'Directory from the server
                        Dim deskDir As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, CustomVariables.CurrentUserName, CustomVariables.Client, txt_document.Text) 'Directory from the Desktop directory
                        'Create a directory to the My Documents if not exist
                        If Not Directory.Exists(deskDir) Then Directory.CreateDirectory(deskDir)

                        Dim fdr As DialogResult = MessageBox.Show(Me, "Click [Yes] to replace the file." & vbNewLine & vbNewLine & "Click [No] to opne the file", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                        If fdr = DialogResult.Yes Then
                            Using betFile As OpenFileDialog = New OpenFileDialog()
                                betFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                                betFile.Filter = "Word Document (*.doc)|*.doc|All files (*.*)|*.*"
                                betFile.FilterIndex = 1
                                betFile.RestoreDirectory = True
                                betFile.Multiselect = False
                                If betFile.ShowDialog() = DialogResult.OK Then
                                    BETFileDirectory = betFile.FileName 'Path.GetDirectoryName(betFile.FileName)
                                    txt_document.Text = betFile.SafeFileName
                                End If
                            End Using
                        ElseIf fdr = DialogResult.No Then
                            Dim OpenDir As String = deskDir
                            If File.Exists(BETFileDirectory) Then
                                If File.Exists(newDir) Then
                                    fdr = MessageBox.Show(Me, "The file also exist from the server. Would you like to open the file from the server?" & vbNewLine & vbNewLine & "Click [Yes] to open the file from the server" & vbNewLine & vbNewLine & "Click [No] to open the file located at your computer.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    If fdr = DialogResult.Yes Then File.Copy(Path.Combine(newDir, txt_document.Text), Path.Combine(deskDir, txt_document.Text), True)
                                    OpenDir = deskDir
                                Else
                                    OpenDir = BETFileDirectory
                                End If
                            End If
                            If File.Exists(OpenDir) Then
                                Process.Start(OpenDir)
                            Else
                                MessageBox.Show(Me, "The file does not exist." & vbNewLine & vbNewLine & OpenDir, "File Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If

                        End If
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to copy the file."
                        Throw ex
                    End Try
                End If
            Else
                If CustomVariables.FileID <> 0 And Not CustomVariables.CurrentUserPosition Like "sched" Then

                    If cf.IsStringEmpty(txt_document.Text) Then txt_document.Text = Path.GetFileNameWithoutExtension(txt_audio.Text) & ".doc"
                    locDoc = Path.Combine(CustomVariables.FileLocalDirectory, txt_document.Text)
                    Dim CopyFromDir As String = "" : Dim CopyToDir As String = locDoc
                    'This is for the MCY use only
                    Dim CopyFromDir2 As String = "" : Dim CopyToDir2 As String = ""
                    'set variables for word application. This is to be used only if isWordStart is equal to true
                    Dim isWordStart As Boolean = False : Dim isDocAdd As Boolean = False : Dim TemplatePath As String = ""
                    'set variables for query
                    Dim Qry As String = "" : Dim QryParam() As String = New String() {}
                    'set variables for messagebox
                    Dim MsgTxt As String = "" : Dim MsgTitle As String = "" : Dim MsgButton As MessageBoxButtons = MessageBoxButtons.OK
                    Dim MsgIcon As MessageBoxIcon = MessageBoxIcon.Error

                    'check return stat (retFile)
                    If Not Convert.ToBoolean(main_gridview.SelectedRows(0).Cells(37).Value) Then
                        'check if document exist in the local directory
                        If Not File.Exists(locDoc) Then
                            'check if the document exist in the server directory
                            If Not File.Exists(servDoc) Then
                                Qry = "UPDATE dbo.Main SET wFile=@wFile," & usrTime & " WHERE Id=" & CustomVariables.FileID
                                QryParam = New String() {"wFile", txt_document.Text}
                                Select Case txt_client.Text.ToLower
                                    Case "mcy"
                                        CopyFromDir = Path.Combine(CustomVariables.BaseServer, "FROOT\TEMPLATE\MCY\MCY Template.doc")
                                        CopyToDir = Path.Combine(CustomVariables.MyDocumentsDirectory, "MCY Template.doc")
                                        CopyFromDir2 = Path.Combine(CustomVariables.BaseServer, "FROOT\TEMPLATE\MCY\MCY.dot")
                                        CopyToDir2 = Path.Combine(CustomVariables.MyDocumentsDirectory, "MCY.dot")
                                        isWordStart = True : TemplatePath = Path.Combine(CustomVariables.MyDocumentsDirectory, "MCY.dot")
                                    Case Else
                                        CopyFromDir = Path.Combine(CustomVariables.BaseServer, "FROOT\TEMPLATE\Straight\Straight.dot")
                                        CopyToDir = Path.Combine(CustomVariables.MyDocumentsDirectory, "Straight.dot")
                                        isWordStart = True : TemplatePath = Path.Combine(CustomVariables.MyDocumentsDirectory, "Straight.dot")
                                End Select
                            Else
                                'If New String() {".doc", ".docx"}.Contains(fExt) Then CopyFromDir = servDoc
                                CopyFromDir = servDoc
                            End If
                        Else
                            If Not New String() {".doc", ".docx"}.Contains(fExt) Then MsgTitle = "Cannot open file type."
                        End If
                    Else
                        fExt = Path.GetExtension(Path.Combine(CustomVariables.RetDirectory, txt_document.Text))
                        If New String() {".doc", ".docx"}.Contains(fExt) Then CopyFromDir = Path.Combine(CustomVariables.RetDirectory, txt_document.Text) Else MsgTxt = "Cannot open file type."
                    End If

                    '****Message Box****
                    If Not cf.IsStringEmpty(MsgTxt) Then
                        MessageBox.Show(Me, MsgTxt, MsgTitle, MsgButton, MsgIcon)
                        Exit Sub
                    End If
                    '****Copy****
                    Try
                        If Not cf.IsStringEmpty(CopyFromDir) Then File.Copy(CopyFromDir, CopyToDir, True)
                        If Not cf.IsStringEmpty(CopyFromDir2) Then File.Copy(CopyFromDir2, CopyToDir2, True)
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to copy the file."
                        Throw ex
                    End Try
                    '****Word Application****
                    If isWordStart Then
                        Try
                            oWord = CreateObject("Word.Application")
                            If isDocAdd Then oDoc = oWord.Documents.Add Else oDoc = oWord.Documents.Open(Path.Combine(CustomVariables.MyDocumentsDirectory, "MCY Template.doc"))
                            oWord.ChangeFileOpenDirectory(CustomVariables.FileLocalDirectory)
                            oDoc.SaveAs(locDoc) : oDoc.UpdateStylesOnOpen = False
                            oDoc.AttachedTemplate = TemplatePath
                            oDoc.XMLSchemaReferences.AutomaticValidation = False
                            oDoc.XMLSchemaReferences.AllowSaveAsXMLWithoutValidation = False
                            oWord.Visible = True : oWord.Activate() : oDoc.Activate()
                            oDoc = Nothing : oWord = Nothing
                        Catch ex As Exception
                            CatchErrorMsg = "Something went wrong while trying to create a new document."
                            Throw ex
                        End Try
                    End If
                    '****Query****
                    Try
                        db.nQuery(Qry, QryParam)
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to execute the query. " & vbNewLine & "Query: " & Qry
                        Throw ex
                    End Try
                    '****Start Process****
                    Try
                        If Not isWordStart Then Process.Start(locDoc)
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to open a document. " & vbNewLine & "Document: " & locDoc
                        Throw ex
                    End Try

                End If
            End If
        Catch ex As Exception
            cf.Debug(ex, True, CatchErrorMsg)
        End Try

    End Sub

    Private Sub btn_Audio_Click(sender As Object, e As EventArgs) Handles btn_Audio.Click

        Dim CatchErrorMsg As String = "Something went wrong."
        Try
            Dim SoundName As String = txt_audio.Text
            If Not cf.IsStringEmpty(SoundName) Then
                'set variables
                Dim servSound As String = Path.Combine(CustomVariables.BaseServer, CustomVariables.ServSound)
                Dim locSound As String = Path.Combine(CustomVariables.MyMusicDirectory, SoundName)
                Dim isCopy As Boolean = False
                'check If audio exist in the local directory
                If File.Exists(locSound) Then
                    Dim sInfo As New FileInfo(servSound)
                    Dim lInfo As New FileInfo(locSound)
                    'if server size <> user size then overwrite
                    If sInfo.Length <> lInfo.Length Then isCopy = True
                Else 'if not exist then copy the audio from the server
                    isCopy = True
                End If
                'execute copy function if isCopy = true
                If isCopy Then
                    Try
                        File.Copy(servSound, locSound, True)
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to copy from the server." & vbNewLine & ex.Message
                        Throw ex
                    End Try
                End If
                'get the name of the selected player
                Dim rButton As String = TableLayoutPanel6.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked).Text
                Dim progDir As String = "" : Dim ProcStartInfo As New ProcessStartInfo
                ProcStartInfo.Arguments = """" & locSound & """"

                Select Case rButton
                    Case "Express Scribe"
                        progDir = "NCH Swift Sound\Scribe\scribe.exe"
                    Case "People Support"
                        progDir = "PeopleSupport\TMS\RTMMPlayer.exe"
                    Case "Accolade QT"
                        progDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ftsu2.exe"
                End Select

                If rButton <> "Accolade QT" Then
                    Dim ProgFile32 As String = Path.Combine(Environment.GetEnvironmentVariable("ProgramFiles(x86)"), progDir)
                    Dim ProgFile64 As String = Path.Combine(Environment.GetEnvironmentVariable("ProgramW6432"), progDir)
                    If File.Exists(ProgFile32) Then ProcStartInfo.FileName = ProgFile32 Else ProcStartInfo.FileName = ProgFile64
                Else
                    ProcStartInfo.FileName = progDir
                End If
                Try
                    Process.Start(ProcStartInfo)
                Catch ex As Exception
                    CatchErrorMsg = "Unable to find " & rButton & ". Please open the file manually."
                    Process.Start(locSound)
                    Throw ex
                End Try

            End If
        Catch ex As Exception
            cf.Debug(ex, True, CatchErrorMsg)
        End Try
    End Sub

    Private Sub btn_return_Click(sender As Object, e As EventArgs) Handles btn_return.Click
        Dim CatchErrorMsg As String = "Something went wrong"
        If CustomVariables.FileID <> 0 Then
            Try
                'open return form only if the current user department is PR and BET 
                If New String() {"pr", "bet"}.Contains(CustomVariables.CurrentUserDepartment) Then
                    Dim returnFrm As markform.frm_return_file 'instantiate return form class
                    'check if return form is already opened. If already opened then set focus to the return form
                    If Not cf.IsFormOpen("frm_return_file", True, "Return") Then
                        returnFrm = New markform.frm_return_file(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment, CustomVariables.CurrentUserLevel, CustomVariables.DocName, CustomVariables.Client, CustomVariables.BTID})
                        Dim dr As DialogResult = returnFrm.ShowDialog(Me)
                        'if the return form is close using the close button(x) then exit sub
                        If dr = DialogResult.Cancel Then
                            Exit Sub
                        End If
                    Else
                        cf.GetForm.Activate()
                    End If
                End If

                Dim locDoc As String = Path.Combine(CustomVariables.FileLocalDirectory, txt_document.Text)
                Dim getReturn As String() = db.row("Select servDoc, flow, cFlow FROM dbo.Main WHERE Id=" & CustomVariables.FileID)
                Dim retServ As String = ""
                Dim curDep As String = ""
                Dim cFlow As Long = getReturn(2)
                Dim nFlow As Long

                If cFlow <> 0 Then
                    nFlow = cFlow - 1
                    Dim prevDep As String() = Split(getReturn(1), "-")
                    Dim forX As String = "For " & prevDep(nFlow)

                    Dim prevUser As String() = db.row("Select (Select username FROM dbo.UserData WHERE Id =" & prevDep(nFlow) & ") As username," & prevDep(nFlow) &
                                                                  " FROM dbo.Main WHERE Id=" & CustomVariables.FileID)
                    Select Case CustomVariables.CurrentUserDepartment
                        Case "admin"
                            db.nQuery("UPDATE dbo.Main SET status='" & forX & "',active=0,activeUser=0,cFlow=" & nFlow & " WHERE Id=" & CustomVariables.FileID)
                        Case "pr", "bet"
                            If File.Exists(locDoc) Then
                                retServ = Replace(getReturn(0), CustomVariables.CurrentUDept.ToUpper, prevDep(nFlow))
                                retServ = Replace(retServ, CustomVariables.CurrentUserName, prevUser(0))
                                retServ = Path.Combine(retServ, "return")
                                If Not Directory.Exists(retServ) Then Directory.CreateDirectory(retServ)
                                File.Copy(locDoc, Path.Combine(retServ, Me.txt_document.Text), True)
                                db.nQuery("UPDATE dbo.Main SET rush=1,status=CASE WHEN qa" & prevDep(nFlow) & " != 0 THEN 'For " & prevDep(nFlow) & " QA' ELSE '" & forX & "' END,active=0,activeUser=0,cFlow=" & nFlow & ",
                                    retFile=1,retDirectory='" & retServ & "' WHERE Id=" & CustomVariables.FileID)

                                ClearForm()
                                MessageBox.Show(Me, "File returned", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show(Me, "Document does not exist.", "Missing document", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                    End Select
                End If

            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
                MessageBox.Show(Me, CatchErrorMsg, "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            LoadData()
        End If
    End Sub

    Private Sub FormOpen_Click(sender As Object, e As EventArgs) Handles btn_break.Click, btn_break_log.Click,
        btn_file_eval.Click, btn_myeval.Click, btn_monitoring.Click, btn_flagging.Click, btn_ratio_tracker.Click,
        btn_idle_tracker.Click, btn_wait_tracker.Click, btn_files_due.Click, btn_report_log.Click, btn_userlist.Click,
        btn_workflow.Click, btn_upload.Click

        Dim btn As Button = sender : Me.Cursor = Cursors.AppStarting
        Try
            Select Case btn.Name
                Case "btn_break"
                    IdleTimer.Stop()
                    frm_break.ShowDialog()
                Case "btn_break_log"
                    Dim mybreakfrm As markform.frm_break_log
                    If Not cf.IsFormOpen("frm_break_log", True, "mybreaklog") Then
                        mybreakfrm = New markform.frm_break_log(New String() {CustomVariables.CurrentUserID})
                        mybreakfrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_file_eval", "btn_myeval"
                    Dim EvalFrm As markform.frm_file_eval
                    If btn.Name = "btn_file_eval" Then
                        If Not cf.IsFormOpen("frm_file_eval", True, "view") Then
                            EvalFrm = New markform.frm_file_eval(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment}, "view", CustomVariables.CurrentUserRestriction)
                            EvalFrm.Show(Me)
                        Else
                            cf.GetForm.Activate()
                        End If
                    Else
                        If Not cf.IsFormOpen("frm_file_eval", True, "own") Then
                            EvalFrm = New markform.frm_file_eval(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment}, "own", CustomVariables.CurrentUserRestriction)
                            EvalFrm.Show(Me)
                        Else
                            cf.GetForm.Activate()
                        End If
                    End If
                Case "btn_monitoring"
                    Dim montoringfrm As markform.frm_monitoring
                    If Not cf.IsFormOpen("frm_monitoring", True, "monitor") Then
                        montoringfrm = New markform.frm_monitoring()
                        montoringfrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_returnfile"
                    Dim returnFrm As markform.frm_return_file
                    If Not cf.IsFormOpen("frm_return_file", True, "return") Then
                        returnFrm = New markform.frm_return_file(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment, CustomVariables.CurrentUserLevel}, True, CustomVariables.CurrentUserRestriction)
                        returnFrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_flagging"
                    Dim flagFrm As markform.frm_flagging
                    If Not cf.IsFormOpen("frm_flagging", True, "flag") Then
                        flagFrm = New markform.frm_flagging(New String() {CustomVariables.CurrentUserID, CustomVariables.CurrentUserName, CustomVariables.CurrentUserPosition, CustomVariables.CurrentUserDepartment, CustomVariables.CurrentUserLevel, CustomVariables.CurrentUserRestriction})
                        flagFrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_qrtracker"
                    Dim qrtrackFrm As markform.frm_qrtracker
                    If Not cf.IsFormOpen("frm_qrtracker", True, "track") Then
                        qrtrackFrm = New markform.frm_qrtracker()
                        qrtrackFrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_idle"

                Case "btn_wait"

                Case "btn_files_due"
                    Dim duefilesFrm As markform.frm_duefile
                    If Not cf.IsFormOpen("frm_duefile", True, "duefiles") Then
                        duefilesFrm = New markform.frm_duefile()
                        duefilesFrm.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_report_log"
                    Dim reportlog As markform.frm_report_log
                    If Not cf.IsFormOpen("frm_report_log", True) Then
                        reportlog = New markform.frm_report_log(CustomVariables.CurrentUserRestriction)
                        reportlog.Show(Me)
                    Else
                        cf.GetForm.Activate()
                    End If
                Case "btn_userlist"
                    frm_userlist.ShowDialog(Me)
                    LoadComboBoxData() : LoadData()
                Case "btn_workflow"
                    frm_workflow.ShowDialog(Me)
                Case "btn_upload"
                    frm_upload.ShowDialog(Me)

            End Select

        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "Sub Routines"
    ''' <summary>
    ''' Setting restrictions for the current form
    ''' </summary>
    ''' <param name="JSONString"></param>
    Private Sub SetRestrictions(JSONString As String)
        Try
            'Dim urc2 As New markform.UserRestrictionsClass
            'JSONString = If(Not cf.IsStringEmpty(JSONString), JSONString, urc2.GetPresetRestriction(CustomVariables.CurrentUserDepartment, CustomVariables.CurrentUserPosition))

            Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(JSONString)
            Dim fi As markform.FileInformation = urc.FileInformation : Dim wf As markform.WorkFile = urc.WorkFile : Dim au As markform.AssignUser = urc.AssignUser
            Dim fe As markform.FileEval = urc.FileEval : Dim fr As markform.FileReturn = urc.FileReturn : Dim flag As markform.Flagging = urc.Flagging
            Dim mo As markform.Monitoring = urc.Monitoring : Dim rt As markform.RatioTracker = urc.RatioTracker : Dim it As markform.IdleTracker = urc.IdleTracker
            Dim wt As markform.WaitTracker = urc.WaitTracker : Dim fd As markform.FilesDue = urc.FilesDue : Dim ua As markform.UserList = urc.UserList
            Dim wfw As markform.WorkFlow = urc.WorkFlow : Dim uf As markform.UploadFunction = urc.UploadFunction : Dim ef As markform.ExportFunction = urc.ExportFunction
            Dim af As markform.ArchiveFunction = urc.ArchiveFunction : Dim rl As markform.ReportLog = urc.ReportLog : Dim rf As markform.ReferenceFunction = urc.ReferenceFunction
            Dim btf As markform.BTFileFunction = urc.BTFileFunction

            btn_return.Visible = urc.ReturnFileBtn : btn_file_eval.Visible = fe.Enabled : btn_monitoring.Visible = mo.Enabled : btn_return.Visible = fr.Enabled : btn_flagging.Visible = flag.Enabled
            btn_ratio_tracker.Visible = rt.Enabled : btn_idle_tracker.Visible = it.Enabled : btn_wait_tracker.Visible = wt.Enabled : btn_files_due.Visible = fd.Enabled
            btn_userlist.Visible = ua.Enabled : btn_workflow.Visible = wfw.Enabled : btn_upload.Visible = uf.Enabled : btn_export.Visible = ef.Enabled : btn_archive.Visible = af.Enabled
            btn_report_log.Visible = rl.Enabled : btn_reference.Visible = rf.Enabled : btn_file.Visible = btf.Enabled

            gbox_prio.Enabled = urc.FilePriority : gbox_file_info.Enabled = fi.Enabled

            GboxUList.Visible = au.Enabled
            If fi.Enabled Then
                txt_due.Enabled = fi.DueDate
                cbo_service.Enabled = fi.ServiceDate
                txt_client.Enabled = fi.Client
                txt_branch.Enabled = fi.Branch
                txt_receive.Enabled = fi.Receive
                txt_duration.Enabled = fi.DurationInfo
                txt_page.Enabled = fi.PageInfo
                txt_accuracy.Enabled = fi.Accuracy
            End If
            If au.Enabled Then
                cbo_bt.Visible = au.BT : cbo_qabt.Visible = au.BTQA
                cbo_pr.Visible = au.PR : cbo_qapr.Visible = au.PRQA
                cbo_st.Visible = au.ST : cbo_qast.Visible = au.STQA
                cbo_cc.Visible = au.CC : cbo_qacc.Visible = au.CCQA
            End If
            IsWorkFileEnabled = wf.Enabled
            gbox_work_file.Enabled = False

        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Reset the restriction to default
    ''' </summary>
    Private Sub ResetRestriction()
        btn_file_eval.Visible = True
        btn_monitoring.Visible = True
        btn_return.Visible = True
        btn_flagging.Visible = True
        btn_ratio_tracker.Visible = True
        btn_idle_tracker.Visible = True
        btn_wait_tracker.Visible = True
        btn_files_due.Visible = True
        btn_userlist.Visible = True
        btn_workflow.Visible = True
        btn_upload.Visible = True
        btn_export.Visible = True
        btn_archive.Visible = True
        btn_report_log.Visible = True
        btn_reference.Visible = True
        btn_file.Visible = True

        gbox_prio.Enabled = True
        gbox_file_info.Enabled = True
        gbox_work_file.Enabled = True
        GboxUList.Visible = True

        txt_due.Enabled = True
        cbo_service.Enabled = True
        txt_client.Enabled = True
        txt_branch.Enabled = True
        txt_receive.Enabled = True
        txt_duration.Enabled = True
        txt_page.Enabled = True
        txt_accuracy.Enabled = True

        cbo_bt.Enabled = True : cbo_qabt.Enabled = True
        cbo_pr.Enabled = True : cbo_qapr.Enabled = True
        cbo_st.Enabled = True : cbo_qast.Enabled = True
        cbo_cc.Enabled = True : cbo_qacc.Enabled = True
    End Sub
    ''' <summary>
    ''' The default variables and functions that to be set when the user is logged in.
    ''' </summary>
    ''' <param name="dr"></param>
    Private Sub LoginDefault(dr As DialogResult)
        If dr = DialogResult.OK Then
            Me.Text = "BT TOOL [" & CustomVariables.CurrentUserName.ToUpper() & "]"
            SetRestrictions(CustomVariables.CurrentUserRestriction)
            IdleTimer.Start()
            WaitTimer.Start()

            LoadComboBoxData()
            LoadData()
        Else
            Me.Dispose()
        End If
    End Sub
    ''' <summary>
    ''' Load data to main gridview.
    ''' </summary>
    Private Async Sub LoadData()
        'Displaying indications that the process of fetching and displaying the data is running
        Me.Cursor = Cursors.AppStarting
        lbl_gridview_status.BackColor = Color.FromArgb(0, 122, 204)
        lbl_gridview_status.Text = "Fetching data..."
        lbl_gridview_status.Visible = True
        'Setting variables
        Dim newDt As New DataTable
        Dim dt As New DataTable
        Dim selRow As Long = 0
        Dim whereClause As String = "status=@status"
        Dim bind() As String = New String() {}
        Dim dgvCurSelRowIndex As Integer = 0
        If Not IsNothing(main_gridview.CurrentRow) Then
            dgvCurSelRowIndex = main_gridview.CurrentRow.Index
            selRow = main_gridview.CurrentRow.Cells(0).Value
        End If
        'Preparing query filters
        Select Case CustomVariables.CurrentUserPosition
            Case "admin", "it", "opsup", "sup"
                whereClause = ""
            Case "ts"
                whereClause = "status NOT IN ('done','for audit','archive')"
            Case "sched"
                Select Case CustomVariables.CurrentUserDepartment
                    Case "bt"
                        whereClause = "status IN ('BT Sched','for bt', 'for bt qa')"
                    Case "pr"
                        whereClause = "status In ('PR Sched','for bt','for pr', 'for bt qa', 'for pr qa')"
                    Case "bet"
                        whereClause = "status IN ('" & CustomVariables.CurrentUDept & " Sched','for " & CustomVariables.CurrentUDept & "', 'for " & CustomVariables.CurrentUDept & " qa' )"
                End Select
            Case "prod"
                'whereClause = "(status=@status AND " & varMod.uDept & " = @uid) OR (qa" & varMod.uDept & " = CASE status WHEN 'for " & varMod.uDept & " qa' THEN @uid ELSE NULL END)"
                'bind = New String() {"status", "for " & varMod.uDept, "uid", varMod.uid}
                'db.bind("status", "for " & varMod.uDept)

                whereClause = "( " & CustomVariables.CurrentUDept & " = @uid OR qa" & CustomVariables.CurrentUDept & " = @uid)"
                bind = New String() {"uid", CustomVariables.CurrentUserID}'{varMod.uDept, "uid", varMod.uid}
            Case "auditor"
                bind = New String() {"status", "For ts"}
                'db.bind("status", "For ts")
            Case "tl"
                Select Case CustomVariables.CurrentUserDepartment
                    Case "bt"
                        whereClause = "status IN ('BT Sched','for bt')"
                    Case "pr"
                        whereClause = "status In ('PR Sched','for pr')"
                    Case "bet"
                        whereClause = "status IN ('" & CustomVariables.CurrentUDept & " Sched','for " & CustomVariables.CurrentUDept & "', 'for " & CustomVariables.CurrentUDept & " qa')"
                End Select
        End Select

        Dim additionalWhere As String = ""
        If CustomVariables.CurrentUserIsBTWork = True Then
            additionalWhere = " OR (bt = " & CustomVariables.CurrentUserID & " AND status LIKE 'For BT')"
        End If

        If whereClause IsNot "" Then
            whereClause = "WHERE " & whereClause & additionalWhere
        End If

#Region "Gridview column number reference"
        '0  = id           | 1  = Prio      | 2  = Rush      | 3  = Receive      | 4  = Service    | 5  = Due        | 6 = Client
        '7  = Branch       | 8  = Soundfile | 9  = servSound | 10 = locSound     | 11 = Duration   | 12 = wFile      | 13 = servDoc
        '14 = servLoc      | 15 = page      | 16 =  BT       | 17 = QA BT        | 18 = PR         | 19 = QA PR      | 20 = S&T
        '21 = QA S&T       | 22 = CC        | 23 = QA CC     | 24 = btid         | 25 = qabtid     | 26 = prid       | 27 = qaprid
        '28 = stid         | 29 = qastid    | 30 = ccid      | 31 = qaccid       | 32 = Accuracy   | 33 = Status     | 34 = Workflow
        '35 = Current Flow | 36 = Active    | 37 = retFile   | 38 = retDirectory | 39 = activeUser | 40 = rowEnabled | 41 = isHold
#End Region
        Dim ColField() As String = New String() {"id", "Prio", "Rush", "Receive", "Service", "Due", "Client", "Branch", "Soundfile", "servSound", "locSound",'10
            "Duration", "wFile", "servDoc", "servLoc", "Page",'15
            "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC",'23
            "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid",'31
            "Accuracy", "Status", "Workflow", "Current Flow", "Active", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"} '41

#Region "Gridview Column properties"
        Dim headers As New List(Of GridHeaders)() : Dim colIndex As Integer = 0
        For Each col As String In ColField
            Dim colType As Type = GetType(String) : Dim colVisible As Boolean = True
            'Set the column type of specific columns
            If New String() {"Prio", "Rush", "Active", "isHold"}.Contains(col) Then colType = GetType(Boolean)
            'Set the visibility of the specific columns , "rowEnabled"
            If New String() {"id", "Prio", "servSound", "locSound", "wFile", "servDoc", "servLoc", "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid", "Accuracy",
                "Workflow", "Current Flow", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"}.Contains(col) Then colVisible = False

            Dim colVFalse() As String = New String() {} : Dim colVTrue() As String = New String() {}
            Select Case CustomVariables.CurrentUserPosition
                Case "admin"
                    colVFalse = New String() {}
                    colVTrue = New String() {"Receive", "Page", "BT", "QA BT", "PR", "QA PR"}
                Case "prod"
                    colVFalse = New String() {"Receive", "servLoc", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "btid", "qabtid", "prid", "qaprid", "stid",
                        "qastid", "ccid", "qaccid", "Accuracy", "Active", "retFile"}
                    colVTrue = New String() {}
                Case "sched"
                    Select Case CustomVariables.CurrentUserDepartment
                        Case "bt"
                            colVFalse = New String() {"PR", "QA PR", "S&T", "QA ST", "CC", "QA CC"}
                            colVTrue = New String() {"Page", "BT", "QA BT"}
                        Case "pr"
                            colVFalse = New String() {"Page", "S&T", "QA ST", "CC", "QA CC"}
                            colVTrue = New String() {"BT", "QA BT", "PR", "QA PR"}
                        Case "bet"
                            colVFalse = New String() {"Page", "BT", "QA BT", "PR", "QA PR"}
                            If CustomVariables.CurrentUDept = "st" Then
                                colVTrue = New String() {"S&T", "QA ST"}
                            Else
                                colVTrue = New String() {"CC", "QA CC"}
                            End If
                    End Select
            End Select
            If colVFalse.Contains(col) Then colVisible = False
            If colVTrue.Contains(col) Then colVisible = True
            'Set column width
            Dim colW As Integer = 0
            If col = "Client" Then colW = 60
            If col = "Branch" Then colW = 85
            If col = "Soundfile" Then colW = 145
            If col = "Due" Then colW = 120
            If New String() {"Receive", "Service", "Duration"}.Contains(col) Then colW = 75
            If New String() {"Rush", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "Status", "Active"}.Contains(col) Then colW = 50

            headers.Add(New GridHeaders() With {.index = colIndex, .text = col, .type = colType, .visible = colVisible, .width = colW})

            colIndex = colIndex + 1
        Next

        For Each itm As GridHeaders In headers
            newDt.Columns.Add(itm.text, itm.type)
        Next
#End Region
        Try
            Dim ndt As DataTable = Await Task.Run(
                Function()
#Region "Table column number reference"
                    '0  = Id       | 1  = prio   | 2  = rush      | 3  = dateRec      | 4  = dateServ   | 5  = dateDue  | 6 = client
                    '7  = branch   | 8  = sFile  | 9  = servSound | 10 = locSound     | 11 = duration   | 12 = wFile    | 13 = servDoc
                    '14 = locDoc   | 15 = page   | 16 =  btname   | 17 = qabtname     | 18 = prname     | 19 = qaprname | 20 = stname
                    '21 = qastname | 22 = ccname | 23 = qaccname  | 24 = bt           | 25 = qabt       | 26 = pr       | 27 = qapr
                    '28 = st       | 29 = qast   | 30 = cc        | 31 = qacc         | 32 = accuracy   | 33 = status   | 34 = flow
                    '35 = cFlow    | 36 = active | 37 = retFile   | 38 = retDirectory | 39 = activeUser | 40 = timeDue  | 41 = onhold
#End Region
                    Dim qry As String = "SELECT Id,prio,rush,dateRec,dateServ,dateDue,client,branch,sFile,servSound,locSound," &
                    "duration,wFile,servDoc,locDoc,page,(SELECT username FROM dbo.UserData WHERE Id = bt) AS btname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = qabt) AS qabtname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = pr) AS prname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = qapr) AS qaprname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = st) AS stname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = qast) AS qastname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = cc) AS ccname," &
                    "(SELECT username FROM dbo.UserData WHERE Id = qacc) AS qaccname,bt,qabt,pr,qapr,st,qast,cc,qacc," &
                    "accuracy,status,flow,cFlow,active,retFile,retDirectory,activeUser,timeDue,onhold FROM dbo.Main " &
                    whereClause & " ORDER BY CASE rush WHEN 1 THEN 0 ELSE 1 END,CASE WHEN dateDue IS NULL THEN 1 ELSE 0 END, CAST(dateDue AS date),
                    CASE WHEN timeDue IS NULL THEN 1 ELSE 0 END,CAST(timeDue AS time)"
                    Try
                        dt = db.query(qry, bind)
                    Catch
                        ErrorQuery = qry
                        Throw
                    End Try
                    Dim rowIndex As Integer = 0 : Dim CurUid As Integer = CustomVariables.CurrentUserID
                    For Each rows As DataRow In dt.Rows
                        Dim row As Object() = rows.ItemArray
                        Dim dtTime As DateTime : Dim convertedTime As String
                        Try
                            dtTime = DateTime.Parse(row(40))
                            convertedTime = dtTime.ToString("h:mm tt")
                        Catch ex As Exception
                            convertedTime = ""
                        End Try
                        '*****************************
                        Dim rowInclude As Boolean = True
                        Dim rowEnabled As String = ""
                        Dim isHold As Boolean = Boolean.Parse(row(41))
                        If rowIndex > 0 And New String() {"prod"}.Contains(CustomVariables.CurrentUserPosition) And Not isHold Then rowEnabled = "NOT YET"
                        'check workflow and current flow
                        If New String() {"prod"}.Contains(CustomVariables.CurrentUserPosition) Then
                            Dim WorkFlowArray() As String = row(34).ToString().Split("-")
                            Dim CurUserFlowAssigned As Integer = 0
                            Select Case CurUid
                                Case Integer.Parse(row(24))
                                    CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "BT")
                                Case Integer.Parse(row(26))
                                    CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "PR")
                                Case Integer.Parse(row(28))
                                    CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "ST")
                                Case Integer.Parse(row(30))
                                    CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "CC")
                            End Select
                            If Integer.Parse(row(35)) > CurUserFlowAssigned Then
                                rowInclude = False
                            End If
                            If Integer.Parse(row(35)) < CurUserFlowAssigned Then
                                rowEnabled = "WORKFLOW"
                            End If

                        End If
                        '****************************
                        If rowInclude Then
                            newDt.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5) & " " & convertedTime, row(6), row(7), row(8), row(9), row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), row(18),
                            row(19), row(20), row(21), row(22), row(23), row(24), row(25), row(26), row(27), row(28), row(29), row(30), row(31), row(32), row(33), row(34), row(35), row(36), row(37), row(38), row(39), rowEnabled, isHold)

                            rowIndex = rowIndex + 1
                        End If
                    Next
                    Return newDt
                End Function)

            main_gridview.DataSource = ndt
            For Each itm As GridHeaders In headers
                main_gridview.Columns(itm.index).Width = itm.width
                main_gridview.Columns(itm.index).Visible = itm.visible
            Next

            cf.RowsNumber(main_gridview)
            For Each row As DataGridViewRow In Me.main_gridview.Rows
                If row.Cells(0).Value.ToString = selRow Then
                    Dim index As Integer = row.Index
                    row.Selected = True 'either this or the bottom line would work
                    Me.main_gridview.Rows(row.Index).Selected = True
                End If

                If row.Cells(41).Value Then 'check if on hold
                    row.DefaultCellStyle.BackColor = Color.DarkRed
                    row.DefaultCellStyle.ForeColor = Color.White
                End If
                If Not cf.IsStringEmpty(row.Cells(40).Value.ToString()) Then 'check if row is enabled
                    row.DefaultCellStyle.ForeColor = Color.Gray
                End If
            Next

        Catch ex As Exception
            lbl_gridview_status.Text = "Error encountered while trying to retrieve the data."
            lbl_gridview_status.BackColor = Color.DarkRed
            cf.WriteToFile("{0}==>" & ex.ToString() & vbNewLine & ErrorQuery, DebugFilePath)
        End Try
        main_gridview.ClearSelection()
        If main_gridview.Rows.Count > 0 Then main_gridview.Rows(dgvCurSelRowIndex).Selected = True
        lbl_gridview_status.Visible = False
        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' Load data to combobox
    ''' </summary>
    Private Sub LoadComboBoxData()
        GboxUList.Text = "Assign User: [Fetching data...]"
        GboxUList.ForeColor = Color.Black

        Dim dt As New DataTable
        Dim qry As String = "SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,uDept,department,btwork,position FROM dbo.UserData WHERE deactivated = 0 ORDER BY department,username"
        Try
            dt = db.query(qry)

            Dim dv As New DataView(dt)
            dt.Rows.Add(0, "", "", "bt", 0, "prod")
            dt.Rows.Add(0, "", "", "pr", 0, "prod")
            dt.Rows.Add(0, "", "st", "bet", 0, "prod")
            dt.Rows.Add(0, "", "cc", "bet", 0, "prod")
            dt.AcceptChanges()
            '**********bt************
            dv.RowFilter = "department LIKE 'bt' OR btwork = 1 AND position LIKE 'prod'"

            cbo_bt.DisplayMember = "uname"
            cbo_bt.ValueMember = "Id"
            cbo_bt.DataSource = dv
            cbo_bt.SelectedValue = 0


            dv = New DataView(dt)
            dv.RowFilter = "department LIKE 'bt' AND position LIKE 'prod'"

            cbo_qabt.DisplayMember = "uname"
            cbo_qabt.ValueMember = "Id"
            cbo_qabt.DataSource = dv
            cbo_qabt.SelectedValue = 0

            '**********pr************
            dv = New DataView(dt)
            dv.RowFilter = "department LIKE 'pr' AND position LIKE 'prod'"

            cbo_pr.DisplayMember = "uname"
            cbo_pr.ValueMember = "Id"
            cbo_pr.DataSource = dv
            cbo_pr.SelectedValue = 0

            dv = New DataView(dt)
            dv.RowFilter = "department LIKE 'pr' AND position LIKE 'prod'"

            cbo_qapr.DisplayMember = "uname"
            cbo_qapr.ValueMember = "Id"
            cbo_qapr.DataSource = dv
            cbo_qapr.SelectedValue = 0

            '*********s&t***********
            dv = New DataView(dt)
            dv.RowFilter = "uDept LIKE 'st' AND position LIKE 'prod'"

            cbo_st.DisplayMember = "uname"
            cbo_st.ValueMember = "Id"
            cbo_st.DataSource = dv
            cbo_st.SelectedValue = 0

            dv = New DataView(dt)
            dv.RowFilter = "uDept LIKE 'st' AND position LIKE 'prod'"

            cbo_qast.DisplayMember = "uname"
            cbo_qast.ValueMember = "Id"
            cbo_qast.DataSource = dv
            cbo_qast.SelectedValue = 0

            '*********cc***********
            dv = New DataView(dt)
            dv.RowFilter = "uDept LIKE 'cc' AND position LIKE 'prod'"

            cbo_cc.DisplayMember = "uname"
            cbo_cc.ValueMember = "Id"
            cbo_cc.DataSource = dv
            cbo_cc.SelectedValue = 0

            dv = New DataView(dt)
            dv.RowFilter = "uDept LIKE 'cc' AND position LIKE 'prod'"

            cbo_qacc.DisplayMember = "uname"
            cbo_qacc.ValueMember = "Id"
            cbo_qacc.DataSource = dv
            cbo_qacc.SelectedValue = 0

            GboxUList.Text = "Assign User:"
        Catch ex As Exception
            GboxUList.Text = "Assign User: [Error encountered]"
            GboxUList.ForeColor = Color.DarkRed
            cf.WriteToFile("{0}==>" & ex.ToString() & vbNewLine & qry, DebugFilePath)
        End Try
    End Sub
    ''' <summary>
    ''' This will clear textbox and combobox
    ''' </summary>
    Private Sub ClearForm()
        'checkboxes
        chk_blank.Checked = False : chk_rush.Checked = False
        'textbox
        txt_due.Text = "" : txt_client.Text = "" : txt_branch.Text = ""
        txt_receive.Text = "" : txt_duration.Text = "" : txt_page.Text = ""
        txt_accuracy.Text = "" : txt_audio.Text = "" : txt_document.Text = ""
        'comboboxes
        cbo_bt.SelectedValue = 0 : cbo_pr.SelectedValue = 0 : cbo_cc.SelectedValue = 0 : cbo_st.SelectedValue = 0
        cbo_qabt.SelectedValue = 0 : cbo_qapr.SelectedValue = 0 : cbo_qacc.SelectedValue = 0 : cbo_qast.SelectedValue = 0
        'datepicker
        cbo_service.Value = DateTime.Now.ToShortDateString()
    End Sub
    ''' <summary>
    ''' Submit the file
    ''' </summary>
    ''' <param name="IsPRSubmit">This will proceed to the update query and skip other process</param>
    Private Sub Submit(Optional IsPRSubmit As Boolean = False)
        Dim dr As DialogResult
        If IsPRSubmit Then dr = DialogResult.Yes Else dr = MessageBox.Show("Confirm submission?", "Submit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = DialogResult.Yes Then
            Dim CatchErrorMsg As String = "Something went wrong."
            Try
                Dim usrTime As String = CustomVariables.CurrentUDept & "End='" & Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture) & "'"
                'The name of the download folder
                Dim downDate As String = "DOWNLOAD-" & txt_client.Text & "-" & Convert.ToDateTime(txt_receive.Text).ToString("MMddyyyy", CultureInfo.InvariantCulture)
                Dim fName As String = Me.txt_document.Text 'filename
                Dim locDoc As String = Path.Combine(CustomVariables.FileLocalDirectory, txt_document.Text) 'local document path
                Dim servDate As String = "" 'service date

                Dim statVal As String = "" : Dim flowX As String() = WorkFlow.Split("-") : Dim leFlow As String = ""
                CurrentFlow = main_gridview.SelectedRows(0).Cells(35).Value 'The current workflow base on the value from the datagridview
                Dim flowDept As String = flowX(CurrentFlow) 'The base value of the department on which the current workflow is assigned
                'check if the current workflow is less than the max index of the workflow array
                If CurrentFlow < UBound(flowX) Then
                    leFlow = flowX(CurrentFlow) 'The current workflow as string
                    If CustomVariables.CurrentUserPosition <> "admin" Then 'check if the current user position is not admin
                        If QAUserID <> 0 AndAlso CustomVariables.CurrentUserID <> QAUserID Then 'check if the QA User ID is not equal to zero and also not equal to the current user ID
                            statVal = "For " & flowX(CurrentFlow) 'set the status value "For" plus the current workflow string which is also the name of the department
                        Else
                            CurrentFlow = CurrentFlow + 1 'incrementing the current workflow
                            leFlow = flowX(CurrentFlow) 'getting the current workflow string after it has been incremented
                            If flowX(CurrentFlow) <> "TS" Then statVal = leFlow & " Sched" Else statVal = "For TS" 'setting the status value base on the current workflow
                        End If
                    End If
                End If

                Dim servDoc As String = String.Empty : Dim servDir As String = String.Empty
                'check if the current user position is not a scheduler
                If Not CustomVariables.CurrentUserPosition = "sched" Then
                    If CustomVariables.CurrentUserDepartment = "bet" Then flowDept = CustomVariables.CurrentUDept
                    servDoc = Path.Combine("FROOT\TRANSCRIPT", flowDept.ToUpper, CustomVariables.CurrentUserName, downDate, txt_branch.Text)
                    servDir = Path.Combine(CustomVariables.BaseServer, "FROOT\TRANSCRIPT", flowDept.ToUpper, CustomVariables.CurrentUserName, downDate, txt_branch.Text)

                    If Not Directory.Exists(servDir) Then Directory.CreateDirectory(servDir)
                    File.SetAttributes(servDir, FileAttributes.Hidden) 'setting the file attribute to hidden
                    'change the local document path to the BET user defined path from file browser dialog
                    If CustomVariables.CurrentUDept = "cc" Then locDoc = BETFileDirectory
                End If

                Dim IsCopy As Boolean = False 'this is to determine if the file is to be copied
                'This variables is to supplement the parameters of the messagebox
                Dim MsgTxt As String = "" : Dim MsgTitle As String = "" : Dim MsgIcon As MessageBoxIcon = MessageBoxIcon.Error : Dim MsgButton As MessageBoxButtons = MessageBoxButtons.OK
                Dim Qry As String = "" 'The query string
                Dim QryParam() As String = New String() {"servDoc", servDoc, "wFile", fName} 'the parameter for the query
                If IsPRSubmit Then
                    Qry = "UPDATE dbo.Main SET status=CASE WHEN qapr != 0 AND qapr != " & CustomVariables.CurrentUserID & " THEN 'For PR QA' ELSE '" & statVal & "' END,servDoc=@servDoc,wFile=@wFile," & usrTime & ",cFlow=" & CurrentFlow & ",retFile=0,active=0,activeUser=0 WHERE Id=" & CustomVariables.FileID
                    IsCopy = True
                Else
                    Select Case CustomVariables.CurrentUserPosition
                        Case "admin"
                            Qry = "UPDATE dbo.Main SET rush='" & chk_rush.Checked & "',dateServ=CASE WHEN dateServ IS NULL THEN '' END,bt=" & cbo_bt.SelectedValue & ",
                          pr=" & cbo_pr.SelectedValue & ",st=" & cbo_st.SelectedValue & ",cc=" & cbo_cc.SelectedValue & ",qabt=" & cbo_qabt.SelectedValue & ",
                          qapr=" & cbo_qapr.SelectedValue & ",qast=" & cbo_qast.SelectedValue & ",qacc=" & cbo_qacc.SelectedValue & ",
                          status='For " & leFlow & "' WHERE Id = " & CustomVariables.FileID
                        Case "ts"

                            Dim fExt As String = Path.GetExtension(Me.txt_document.Text)
                            If New String() {".doc", ".docx"}.Contains(fExt) Then
                                If File.Exists(locDoc) Then
                                    Dim pCount As Long
                                    Try
                                        If New String() {".doc", ".docx"}.Contains(Path.GetExtension(locDoc)) Then
                                            Dim oWord As Word.Application = CreateObject("Word.Application")
                                            Dim oDoc As Word.Document = oWord.Documents.Open(locDoc)
                                            pCount = oDoc.ComputeStatistics(Word.WdStatistic.wdStatisticPages)
                                            oDoc.Close() : oWord.Quit() : oDoc = Nothing : oWord = Nothing
                                        End If
                                    Catch ex As Exception
                                        CatchErrorMsg = "Something went wrong while trying to get the page count."
                                        Throw ex
                                    End Try
                                    Qry = "UPDATE dbo.Main SET page=" & pCount & " ,status='Ready',servDoc=@servDoc,wFile=@wFile WHERE Id=" & CustomVariables.FileID
                                    IsCopy = True
                                Else
                                    MsgTxt = "Document does not exist." : MsgTitle = "Missing document"
                                End If
                            Else
                                Qry = "UPDATE dbo.Main SET status='Ready',servDoc=@servDoc,wFile=@wFile WHERE Id=" & CustomVariables.FileID
                                IsCopy = True
                            End If

                        Case "sched"
                            Dim DepArr() As String = New String() {"bt", "pr", "st", "qast", "cc", "qacc"}
                            Dim CboArr() As ComboBox = New ComboBox() {Me.cbo_bt, Me.cbo_pr, Me.cbo_st, Me.cbo_qast, Me.cbo_cc, Me.cbo_qacc}
                            Dim cbo As ComboBox

                            If CustomVariables.CurrentUserDepartment = "bet" Then cbo = CboArr(Array.IndexOf(DepArr, CustomVariables.CurrentUDept)) Else cbo = CboArr(Array.IndexOf(DepArr, CustomVariables.CurrentUserDepartment))

                            If cf.IsStringEmpty(cbo.Text) Then
                                Dim d As String = CustomVariables.CurrentUserDepartment
                                If d = "bet" Then d = CustomVariables.CurrentUDept
                                MsgTxt = "Please set " & d.ToUpper() & " Name." : MsgTitle = "Missing Entry" : MsgIcon = MessageBoxIcon.Exclamation
                            Else
                                Dim param As List(Of String) = New List(Of String)
                                Dim AddDateServ As String = ""
                                If flowX(0).ToLower = CustomVariables.CurrentUDept Then
                                    servDate = cbo_service.Value.ToShortDateString
                                    AddDateServ = ",dateServ='" & servDate & "'"
                                End If

                                Select Case CustomVariables.CurrentUserDepartment
                                    Case "bt"
                                        Qry = "UPDATE dbo.Main SET rush='" & chk_rush.Checked & "'" & AddDateServ & ",bt=" & cbo_bt.SelectedValue & ",
                                          qabt=" & cbo_qabt.SelectedValue & ",status='For BT' WHERE Id = " & CustomVariables.FileID
                                    Case "pr"
                                        If CustomVariables.BTID = cbo_pr.SelectedValue Then
                                            MsgTitle = "Cannot assign" : MsgTxt = "Cannot assign Transcript to PR."
                                        Else
                                            Qry = "UPDATE dbo.Main SET pr=" & cbo_pr.SelectedValue & ",qapr=" & cbo_qapr.SelectedValue & " " & AddDateServ & ",
                                              status=CASE WHEN status='pr sched' THEN 'For PR' ELSE status END WHERE Id=" & CustomVariables.FileID
                                        End If
                                    Case "bet"
                                        Dim qaid As String = CboArr(3).SelectedValue 'Default: S&T User ID
                                        If CustomVariables.CurrentUDept = "cc" Then qaid = CboArr(5).SelectedValue
                                        Qry = "UPDATE dbo.Main SET rush='" & chk_rush.Checked & "',servDoc=@servDoc " & AddDateServ & ",
                                          status='For " & CustomVariables.CurrentUDept & "'," & CustomVariables.CurrentUDept & "='" & cbo.SelectedValue & "',
                                          qa" & CustomVariables.CurrentUDept & "=" & qaid & " WHERE Id=" & CustomVariables.FileID
                                End Select
                            End If
                        Case "prod"

                            If Me.txt_document.Text = "" Then
                                MsgTxt = "No document found."
                            Else
                                Dim dep As String = CustomVariables.CurrentUserDepartment
                                If CustomVariables.CurrentUserDepartment = "bet" Then dep = CustomVariables.CurrentUDept
                                If dep = "bt" Or CustomVariables.CurrentUserIsBTWork Then
                                    Qry = "UPDATE dbo.Main SET servDoc=@servDoc,wFile=@wFile," & usrTime & ",cflow=" & CurrentFlow & ",retFile=0,
                                      status=CASE WHEN qabt != 0 AND qabt != " & CustomVariables.CurrentUserID & " THEN 'For BT QA' WHEN pr = 0 
                                      THEN '" & statVal & "' ELSE 'For " & leFlow & "' END,active=0,activeUser=0 WHERE Id=" & CustomVariables.FileID
                                Else
                                    Qry = "UPDATE dbo.Main SET status=CASE WHEN qa" & CustomVariables.CurrentUDept & " NOT 
                                      IN(0," & CustomVariables.CurrentUserID & ") THEN 'For " & CustomVariables.CurrentUDept & " QA' ELSE '" & statVal & "' 
                                      END,servDoc=@servDoc,wFile=@wFile," & usrTime & ",cFlow=" & CurrentFlow & ",retFile=0,active=0,activeUser=0
                                      WHERE Id=" & CustomVariables.FileID
                                End If
                                IsCopy = True
                            End If

                        Case "auditor"
                            Qry = "UPDATE dbo.Main SET servDoc=@servDoc WHERE Id=" & CustomVariables.FileID
                            IsCopy = True
                    End Select
                End If

                '***Show MessageBox***
                If Not cf.IsStringEmpty(MsgTxt) Then
                    MessageBox.Show(Me, MsgTxt, MsgTitle, MsgButton, MsgIcon)
                    Exit Sub
                End If
                '***Copy File***
                Try
                    If File.Exists(locDoc) Then
                        If IsCopy Then File.Copy(locDoc, Path.Combine(servDir, fName), True)
                    Else
                        If IsCopy Then File.Copy(Path.Combine(servDir, fName), Path.Combine(servDir, fName), True)
                    End If
                Catch ex As Exception
                    CatchErrorMsg = "Something went wrong while trying to copy the file."
                    Throw ex
                End Try
                '***Query***
                Dim QryR As Integer
                Try
                    If Not cf.IsStringEmpty(Qry) Then QryR = db.nQuery(Qry, QryParam)
                Catch ex As Exception
                    CatchErrorMsg = "Something went wrong while executing the query."
                    Throw ex
                End Try


                If File.Exists(Path.Combine(CustomVariables.MyMusicDirectory, Me.txt_audio.Text)) Then
                    Try
                        File.Delete(Path.Combine(CustomVariables.MyMusicDirectory, Me.txt_audio.Text))
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to delete the file"
                        Throw ex
                    End Try
                End If

                If FileIsSelected = True Then
                    Try
                        Dim nActive As Integer = db.nQuery("UPDATE dbo.Main SET active=0,activeUser=0")
                        FileIsSelected = False
                    Catch ex As Exception
                        CatchErrorMsg = "Something went wrong while trying to execute the query"
                        Throw ex
                    End Try
                End If

                CustomVariables.FileID = 0
                ClearForm()
                LoadData()
            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
                MessageBox.Show(Me, CatchErrorMsg, "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
#End Region

#Region "Background Worker"
    ''' <summary>
    ''' Background Worker for idle and wait timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BWTimer_DoWork(sender As Object, e As DoWorkEventArgs) Handles BWTimer.DoWork
        Dim dgv As DataGridView = CType(e.Argument, DataGridView)
        If dgv.Rows.Count = 0 Then
            e.Result = "wait"
            If Not isWait Then
                waitSTime = Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture)
                isWait = True
            End If
        Else
            If isWait Then
                db.nQuery("INSERT INTO dbo.tbl_wait (uid,stime,etime) VALUES (" & CustomVariables.CurrentUserID & ",'" & waitSTime & "','" & Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture) & "')")
                isWait = False
            End If
            e.Result = "idle"

            If CustomVariables.LockTime > 0 Then
                'lock user after five minutes
                lastInputInf.cbSize = Marshal.SizeOf(lastInputInf)
                lastInputInf.dwTime = 0
                GetLastInputInfo(lastInputInf)
                last_tick = el_tick
                el_tick = CInt((Environment.TickCount - lastInputInf.dwTime) / 1000)

                If user_idle Then
                    If CInt((Environment.TickCount - lastInputInf.dwTime) / 1000) = 0 Then
                        user_idle = False
                        Dim idle_exist As String() = db.row("SELECT id FROM dbo.tbl_idle WHERE uid=" & CustomVariables.CurrentUserID & "AND time=0")
                        If idle_exist(0) <> "" Then
                            db.nQuery("UPDATE dbo.tbl_idle SET time=@time WHERE id=" & idle_exist(0), New String() {"time", last_tick - (CustomVariables.LockTime * 60)})
                        End If
                    End If
                Else
                    If el_tick > (CustomVariables.LockTime * 60) Then
                        db.nQuery("INSERT INTO dbo.tbl_idle (time,date,uid,itime) VALUES (@time,@date,@uid,@itime)", New String() {"date", Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture), "time", 0, "itime", Now.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture), "uid", CustomVariables.CurrentUserID})
                        user_idle = True
                    End If
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Background Worker for idle and wait timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub BWTimer_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BWTimer.RunWorkerCompleted
        If e.Error Is Nothing Then
            If CStr(e.Result) = "wait" Then
                IdleTimer.Enabled = False
            Else
                IdleTimer.Enabled = True
            End If
        ElseIf e.Cancelled Then
            MessageBox.Show(Me, "The process has been cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            cf.WriteToFile("{0}==>" & e.Error.ToString(), DebugFilePath)
            MessageBox.Show(Me, e.Error.ToString, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

#Region "old form main"
    'Private cf As New CustomFunctions()
    'Private mC As New mainClass
    'Private db As New markform.SQLClass

    'Public locDir As String
    'Private Const QuotationMark As String = """"
    'Public baseLoc As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    'Public baseSound As String = My.Computer.FileSystem.SpecialDirectories.MyMusic
    'Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    'Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    'Dim defaultPlayer As Integer = 1
    'Public fSelect As Boolean
    'Private LastRowSelected As Integer = vbNull

    'Dim TaskBarRect As Rectangle = Rectangle.Intersect(Screen.PrimaryScreen.WorkingArea, Screen.PrimaryScreen.Bounds)

    'Private Sub Main_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    CheckDirectory()
    '    ' == For design ==

    '    'User_Pnl.Height = 0
    '    cf.FormDrag(Me, Me)
    '    'User_Pnl.Visible = False
    '    Me.Width = screenWidth
    '    Me.Height = screenHeight - 44

    '    Me.Location = New Point(0, 0)
    '    'User_Pnl.Left = screenWidth - 300
    '    'User_Pnl.Top = True
    '    Me.Show()
    '    frm_login.ShowDialog(Me)

    '    resize_components()

    '    ' if main panel clicked hide all dropdowns 

    'End Sub

    'Sub resize_components()

    '    main_gridview.Width = Me.Width - (174 + 81)
    '    main_gridview.Height = Me.Height - (181 + 25)

    'End Sub

    '''' <summary>
    '''' some pc's use are not able to connect on the default accomediasvr and vice versa.
    '''' </summary>
    'Sub CheckDirectory()

    '    'create folder in mydocuments 
    '    Dim btDir As String = Path.Combine(baseLoc, "BT Tool Documents")
    '    If Not Directory.Exists(btDir) Then Directory.CreateDirectory(btDir)
    '    Dim di As New DirectoryInfo(btDir)
    '    'If ((di.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden) Then File.SetAttributes(btDir, FileAttributes.Hidden)

    '    If Not Directory.Exists(Path.Combine(btDir, "BT")) Then Directory.CreateDirectory(Path.Combine(btDir, "BT"))
    '    If Not Directory.Exists(Path.Combine(btDir, "PR")) Then Directory.CreateDirectory(Path.Combine(btDir, "PR"))
    '    If Not Directory.Exists(Path.Combine(btDir, "TS")) Then Directory.CreateDirectory(Path.Combine(btDir, "TS"))
    '    If Not Directory.Exists(Path.Combine(btDir, "CC")) Then Directory.CreateDirectory(Path.Combine(btDir, "CC"))
    '    If Not Directory.Exists(Path.Combine(btDir, "ST")) Then Directory.CreateDirectory(Path.Combine(btDir, "ST"))
    '    If Not Directory.Exists(Path.Combine(btDir, "AUDITOR")) Then Directory.CreateDirectory(Path.Combine(btDir, "AUDITOR"))

    '    If Directory.Exists("\\ACC-TEST-SQL\Users") Then
    '        varMod.BaseServer = "\\ACC-TEST-SQL\Users\admin\Desktop"
    '    ElseIf Directory.Exists("\\172.16.3.65\Users") Then
    '        varMod.BaseServer = "\\172.16.3.65\Users\admin\Desktop"
    '    Else
    '        MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    End If

    '    'If rdMain.Checked Then
    '    '    If Directory.Exists("\\accomediasvr\MediaFiles-2") Then
    '    '        varMod.BaseServer = "\\accomediasvr\MediaFiles-2"
    '    '    ElseIf Directory.Exists("\\172.16.3.54\MediaFiles-2") Then
    '    '        varMod.BaseServer = "\\172.16.3.54\MediaFiles-2"
    '    '    Else
    '    '        MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    '    End If
    '    'ElseIf rdTest.Checked Then
    '    '    If Directory.Exists("\\ACC-TEST-SQL\Users\admin\Desktop") Then
    '    '        varMod.BaseServer = "\\ACC-TEST-SQL\Users\admin\Desktop"
    '    '    ElseIf Directory.Exists("\\172.16.3.65\Users\admin\Desktop") Then
    '    '        varMod.BaseServer = "\\172.16.3.65\Users\admin\Desktop"
    '    '    Else
    '    '        MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    '    End If
    '    'End If

    '    'If Directory.Exists("\\accomediasvr\MediaFiles-2\FROOT") Then
    '    '    varMod.BaseServer = "\\accomediasvr\MediaFiles-2\FROOT"
    '    'ElseIf Directory.Exists("\\172.16.3.54\MediaFiles-2\FROOT") Then
    '    '    varMod.BaseServer = "\\172.16.3.54\MediaFiles-2\FROOT"
    '    'Else
    '    '    MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    '    '    End
    '    'End If
    'End Sub

    '''' <summary>
    '''' populate the main gridview depending on the user logged in
    '''' </summary>
    'Public Sub fillMain()
    '    Dim i As Long
    '    Try
    '        Me.Cursor = Cursors.AppStarting
    '        'db.SQLDependency(False)
    '        'RemoveHandler db.OnNewMessage, AddressOf OnNewMessage
    '        'populate main window DGV depening on user deparment/position

    '        Dim newDt As New Data.DataTable
    '        Dim dt As New Data.DataTable
    '        Dim selRow As Long = 0
    '        Dim whereClause As String = "status=@status"
    '        Dim bind() As String = New String() {}

    '        If Not IsNothing(Me.main_gridview.CurrentRow) Then
    '            selRow = Me.main_gridview.SelectedRows(0).Cells(0).Value
    '        End If

    '        'Console.writeline("fillmain: " & varMod.CurUserDep)

    '        Select Case varMod.CurUserPos
    '            Case "admin", "it", "opsup"
    '                whereClause = ""
    '            Case "ts"
    '                whereClause = "status NOT IN ('done','for audit','archive')"
    '            Case "sched"
    '                Select Case varMod.CurUserDep
    '                    Case "bt"
    '                        whereClause = "status IN ('BT Sched','for bt', 'for bt qa')"
    '                    Case "pr"
    '                        whereClause = "status In ('PR Sched','for bt','for pr', 'for bt qa', 'for pr qa')"
    '                    Case "bet"
    '                        whereClause = "status IN ('" & varMod.uDept & " Sched','for " & varMod.uDept & "', 'for " & varMod.uDept & " qa' )"
    '                End Select
    '            Case "prod"
    '                'whereClause = "(status=@status AND " & varMod.uDept & " = @uid) OR (qa" & varMod.uDept & " = CASE status WHEN 'for " & varMod.uDept & " qa' THEN @uid ELSE NULL END)"
    '                'bind = New String() {"status", "for " & varMod.uDept, "uid", varMod.uid}
    '                'db.bind("status", "for " & varMod.uDept)

    '                whereClause = "( " & varMod.uDept & " = @uid OR qa" & varMod.uDept & " = @uid)"
    '                bind = New String() {"uid", varMod.uid}'{varMod.uDept, "uid", varMod.uid}

    '            Case "auditor"
    '                bind = New String() {"status", "For ts"}
    '        'db.bind("status", "For ts")
    '            Case "tl"
    '                Select Case varMod.CurUserDep
    '                    Case "bt"
    '                        whereClause = "status IN ('BT Sched','for bt')"
    '                    Case "pr"
    '                        whereClause = "status In ('PR Sched','for pr')"
    '                    Case "bet"
    '                        whereClause = "status IN ('" & varMod.uDept & " Sched','for " & varMod.uDept & "', 'for " & varMod.uDept & " qa')"
    '                End Select
    '        End Select

    '        Dim additionalWhere As String = ""
    '        If varMod.Btwork = True Then
    '            additionalWhere = " OR (bt = " & varMod.uid & " AND status LIKE 'For BT')"
    '        End If

    '        If whereClause IsNot "" Then
    '            whereClause = "WHERE " & whereClause & additionalWhere
    '        End If
    '        'Console.writeline(whereClause)

    '        '0-15
    '        '16-17
    '        '18-19
    '        '20-21
    '        '22-23
    '        '24-31
    '        '32-39
    '        dt = db.query("SELECT Id,prio,rush,dateRec,dateServ,dateDue,client,branch,sFile,servSound,locSound,duration,wFile,servDoc,locDoc,page, 
    '            (SELECT username FROM dbo.UserData WHERE Id = bt) AS btname,(SELECT username FROM dbo.UserData WHERE Id = qabt) AS qabtname,
    '            (SELECT username FROM dbo.UserData WHERE Id = pr) AS prname,(SELECT username FROM dbo.UserData WHERE Id = qapr) AS qaprname,
    '            (SELECT username FROM dbo.UserData WHERE Id = st) AS stname,(SELECT username FROM dbo.UserData WHERE Id = qast) AS qastname,
    '            (SELECT username FROM dbo.UserData WHERE Id = cc) AS ccname,(SELECT username FROM dbo.UserData WHERE Id = qacc) AS qaccname,
    '            bt,qabt,pr,qapr,st,qast,cc,qacc,
    '            accuracy,status,flow,cFlow,active,retFile,retDirectory,activeUser,timeDue,onhold,blank FROM dbo.Main " & whereClause & "
    '            ORDER BY CASE rush WHEN 1 THEN 0 ELSE 1 END,CASE WHEN dateDue IS NULL THEN 1 ELSE 0 END, CAST(dateDue AS date),
    '            CASE WHEN timeDue IS NULL THEN 1 ELSE 0 END,CAST(timeDue AS time)", bind)


    '        Dim ColField() As String = New String() {"id", "Prio", "Blank", "Rush", "Receive", "Service", "Due", "Client", "Branch", "Soundfile", "servSound", "locSound",'11
    '        "Duration", "wFile", "servDoc", "servLoc", "Page",'16
    '        "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC",'24
    '        "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid",'32
    '        "Accuracy", "Status", "Workflow", "Current Flow", "Active", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"} '42

    '        '***************************************************
    '        Dim headers As New List(Of GridHeaders)() : Dim colIndex As Integer = 0
    '        For Each col As String In ColField
    '            Dim colType As Type = GetType(String) : Dim colVisible As Boolean = True
    '            'Set the column type of specific columns
    '            If New String() {"Prio", "Rush", "Active", "isHold", "Blank"}.Contains(col) Then colType = GetType(Boolean)
    '            If New String() {"Current Flow"}.Contains(col) Then colType = GetType(Integer)
    '            'Set the visibility of the specific columns
    '            If New String() {"id", "Prio", "servSound", "locSound", "wFile", "servDoc", "servLoc", "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid", "Accuracy",
    '            "Workflow", "retFile", "retDirectory", "activeUser", "rowEnabled"}.Contains(col) Then colVisible = False

    '            Dim colVFalse() As String = New String() {} : Dim colVTrue() As String = New String() {}
    '            Select Case varMod.CurUserPos
    '                Case "admin"
    '                    colVFalse = New String() {}
    '                    colVTrue = New String() {"Receive", "Page", "BT", "QA BT", "PR", "QA PR"}
    '                Case "prod"
    '                    colVFalse = New String() {"Receive", "servLoc", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "btid", "qabtid", "prid", "qaprid", "stid",
    '                    "qastid", "ccid", "qaccid", "Accuracy", "Active", "retFile"}
    '                    colVTrue = New String() {}
    '                Case "sched"
    '                    Select Case varMod.CurUserDep
    '                        Case "bt"
    '                            colVFalse = New String() {"PR", "QA PR", "S&T", "QA ST", "CC", "QA CC"}
    '                            colVTrue = New String() {"Page", "BT", "QA BT"}
    '                        Case "pr"
    '                            colVFalse = New String() {"Page", "S&T", "QA ST", "CC", "QA CC"}
    '                            colVTrue = New String() {"BT", "QA BT", "PR", "QA PR"}
    '                        Case "bet"
    '                            colVFalse = New String() {"Page", "BT", "QA BT", "PR", "QA PR"}
    '                            If varMod.uDept = "st" Then
    '                                colVTrue = New String() {"S&T", "QA ST"}
    '                            Else
    '                                colVTrue = New String() {"CC", "QA CC"}
    '                            End If
    '                    End Select
    '            End Select
    '            If colVFalse.Contains(col) Then colVisible = False
    '            If colVTrue.Contains(col) Then colVisible = True
    '            'Set column width
    '            Dim colW As Integer = 0
    '            If col = "Client" Then colW = 60
    '            If col = "Branch" Then colW = 85
    '            If col = "Soundfile" Then colW = 145
    '            If col = "Due" Then colW = 120
    '            If New String() {"Receive", "Service", "Duration", "Current Flow"}.Contains(col) Then colW = 75
    '            If New String() {"Rush", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "Status", "Active", "Blank", "isHold"}.Contains(col) Then colW = 50

    '            headers.Add(New GridHeaders() With {.index = colIndex, .text = col, .type = colType, .visible = colVisible, .width = colW})

    '            colIndex = colIndex + 1
    '        Next

    '        For Each itm As GridHeaders In headers
    '            newDt.Columns.Add(itm.text, itm.type)
    '        Next
    '        '***************************************************
    '        Dim rowIndex As Integer = 0


    '        For Each rows As DataRow In dt.Rows
    '            Dim row As Object() = rows.ItemArray
    '            Dim dtTime As DateTime : Dim convertedTime As String
    '            Try
    '                dtTime = DateTime.Parse(row(40))
    '                convertedTime = dtTime.ToString("h:mm tt")
    '            Catch ex As Exception
    '                convertedTime = ""
    '            End Try
    '            '*****************************
    '            Dim rowEnabled As String = "" : Dim rowInclude As Boolean = True
    '            Dim isHold As Boolean = Boolean.Parse(row(41))
    '            'If rowIndex > 0 And New String() {"prod"}.Contains(varMod.CurUserPos) Then rowEnabled = "NOT YET"
    '            If varMod.CurUserPos = "prod" Then
    '                If rowIndex > 0 Then rowEnabled = "NOT YET"
    '                If isHold And rowIndex > 0 Then rowEnabled = "NOT YET"

    '                Dim WorkFlowArray() As String = row(34).ToString.Split("-")
    '                Dim CurUserFlowAssigned As Integer = 0

    '                Select Case varMod.uid
    '                    Case Integer.Parse(row(24))
    '                        CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "BT")
    '                    Case Integer.Parse(row(26))
    '                        CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "PR")
    '                    Case Integer.Parse(row(28))
    '                        CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "ST")
    '                    Case Integer.Parse(row(30))
    '                        CurUserFlowAssigned = Array.IndexOf(WorkFlowArray, "CC")
    '                End Select

    '                If Integer.Parse(row(35)) > CurUserFlowAssigned Then
    '                    rowInclude = False
    '                    'check file status
    '                    If row(33).ToString().ToLower() = "for " & varMod.uDept.ToLower() & " qa" Then
    '                        rowInclude = New Integer() {Integer.Parse(row(25)), Integer.Parse(row(27)), Integer.Parse(row(29)), Integer.Parse(row(31))}.Contains(varMod.uid)
    '                    End If

    '                End If
    '                If Integer.Parse(row(35)) < CurUserFlowAssigned Then
    '                    rowEnabled = "WORKFLOW"
    '                End If
    '                If Integer.Parse(row(35)) = CurUserFlowAssigned Then
    '                    'rowEnabled = "WORKFLOW"
    '                    'check file status
    '                    Select Case row(33).ToString().ToLower()
    '                        Case "for bt"
    '                            If Integer.Parse(row(24)) <> varMod.uid Then rowEnabled = "PROD"
    '                        Case "for pr"
    '                            If Integer.Parse(row(26)) <> varMod.uid Then rowEnabled = "PROD"
    '                        Case "for cc"
    '                            If Integer.Parse(row(30)) <> varMod.uid Then rowEnabled = "PROD"
    '                        Case "for st"
    '                            If Integer.Parse(row(28)) <> varMod.uid Then rowEnabled = "PROD"
    '                        Case "for bt qa"
    '                            If Integer.Parse(row(25)) <> varMod.uid Then rowInclude = False
    '                        Case "for pr qa"
    '                            If Integer.Parse(row(27)) <> varMod.uid Then rowInclude = False
    '                        Case "for st qa"
    '                            If Integer.Parse(row(29)) <> varMod.uid Then rowInclude = False
    '                        Case "for cc qa"
    '                            If Integer.Parse(row(31)) <> varMod.uid Then rowInclude = False
    '                    End Select
    '                End If
    '            End If
    '            '****************************

    '            '{"id", "Prio", "Blank", "Rush", "Receive", "Service", "Due", "Client", "Branch", "Soundfile", "servSound", "locSound",'11
    '            '"Duration", "wFile", "servDoc", "servLoc", "Page",'16
    '            '"BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC",'24
    '            '"btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid",'32
    '            '"Accuracy", "Status", "Workflow", "Current Flow", "Active", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"} '42

    '            'Console.WriteLine(row(0) & " | " & row(35))
    '            If rowInclude Then
    '                newDt.Rows.Add(row(0), row(1), row(42), row(2), row(3), row(4), row(5) & " " & convertedTime, row(6), row(7), row(8), row(9),
    '                        row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), row(18), row(19),
    '                        row(20), row(21), row(22), row(23), row(24), row(25), row(26), row(27), row(28), row(29),
    '                        row(30), row(31), row(32), row(33), row(34), Integer.Parse(row(35)), row(36), row(37), row(38), row(39),
    '                        rowEnabled, isHold)
    '                rowIndex = rowIndex + 1
    '            End If
    '            'Console.WriteLine(row(34))

    '        Next


    '        main_gridview.DataSource = newDt
    '        For Each itm As GridHeaders In headers
    '            main_gridview.Columns(itm.index).Width = itm.width
    '            main_gridview.Columns(itm.index).Visible = itm.visible
    '            main_gridview.Columns(itm.index).SortMode = DataGridViewColumnSortMode.NotSortable
    '        Next

    '        'Console.writeline("fillmain: " & Me.main_gridview.Rows.Count)
    '        cf.RowsNumber(main_gridview)
    '        'If Me.dgv1.Rows.Count <> 0 Then
    '        For Each row As DataGridViewRow In Me.main_gridview.Rows
    '            i = i + 1
    '            Debug.Print(row.Cells(0).Value.ToString)
    '            If row.Cells(0).Value.ToString = selRow Then
    '                Dim index As Integer = row.Index
    '                row.Selected = True 'either this or the bottom line would work
    '                Me.main_gridview.Rows(row.Index).Selected = True
    '            End If

    '            If row.Cells(42).Value Then 'check if on hold
    '                row.DefaultCellStyle.BackColor = Color.DarkRed
    '                row.DefaultCellStyle.ForeColor = Color.White
    '            End If

    '            If Not mC.isStringEmpty(row.Cells(41).Value.ToString()) Then 'check if row is enabled
    '                row.DefaultCellStyle.ForeColor = Color.Gray
    '            End If
    '        Next
    '    Catch ex As Exception
    '        cf.ErrorLog(ex)
    '        Console.WriteLine(i)
    '    End Try

    '    'main_gridview.Sort(main_gridview.Columns(5), System.ComponentModel.ListSortDirection.Ascending)

    '    Me.Cursor = Cursors.Default
    '    'End If
    'End Sub

    'Private Sub Burgermenu_btn_Click(sender As Object, e As EventArgs)

    '    If User_Pnl.Height = 200 Then

    '        BunifuTransition1.HideSync(User_Pnl)
    '        User_Pnl.Height = 0

    '    End If

    '    If Dashboard_pnl.Width = 190 Then

    '        BunifuTransition2.HideSync(Dashboard_pnl)

    '        btn_myeval.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_file_eval.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_monitoring.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_viewreturn.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_flagging.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_idle_tracker.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_wait_tracker.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_files_due.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_userlist.ImageAlign = ContentAlignment.MiddleCenter
    '        btn_workflow.ImageAlign = ContentAlignment.MiddleCenter

    '        btn_myeval.Text = ""
    '        btn_file_eval.Text = ""
    '        btn_monitoring.Text = ""
    '        btn_viewreturn.Text = ""
    '        btn_flagging.Text = ""
    '        btn_ratio_tracker.Text = ""
    '        btn_idle_tracker.Text = ""
    '        btn_wait_tracker.Text = ""
    '        btn_files_due.Text = ""
    '        btn_userlist.Text = ""
    '        btn_workflow.Text = ""


    '        Dashboard_pnl.Width = 50
    '        BunifuTransition3.ShowSync(Dashboard_pnl)

    '    ElseIf Dashboard_pnl.Width = 50 Then

    '        BunifuTransition3.HideSync(Dashboard_pnl)

    '        btn_myeval.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_file_eval.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_monitoring.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_viewreturn.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_flagging.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_idle_tracker.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_wait_tracker.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_files_due.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_userlist.ImageAlign = ContentAlignment.MiddleLeft
    '        btn_workflow.ImageAlign = ContentAlignment.MiddleLeft

    '        btn_myeval.Text = "My Evaluation"
    '        btn_file_eval.Text = "File Evaluation"
    '        btn_monitoring.Text = "Monitoring"
    '        btn_viewreturn.Text = "View Return"
    '        btn_flagging.Text = "Flagging"
    '        btn_ratio_tracker.Text = "Ratio Tracker"
    '        btn_idle_tracker.Text = "Idle Tracker"
    '        btn_wait_tracker.Text = "Wait Tracker"
    '        btn_files_due.Text = "Files Due"
    '        btn_userlist.Text = "User List"
    '        btn_workflow.Text = "Workflow"

    '        Dashboard_pnl.Width = 190
    '        BunifuTransition2.ShowSync(Dashboard_pnl)

    '    End If

    'End Sub

    'Private Sub Exit_btn_Click(sender As Object, e As EventArgs)
    '    End
    'End Sub

    '''' <summary>
    '''' populate combobox
    '''' </summary>
    'Sub fillCombo()
    '    Try
    '        db.SQLDependency(False)
    '        'fill combobox with usernames
    '        Dim dt As DataTable = db.query("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,uDept,department,btwork,position FROM dbo.UserData WHERE deactivated = 0 ORDER BY department,username")
    '        Dim dv As New DataView(dt)
    '        dt.Rows.Add(0, "", "", "bt", 0, "prod")
    '        dt.Rows.Add(0, "", "", "pr", 0, "prod")
    '        dt.Rows.Add(0, "", "st", "bet", 0, "prod")
    '        dt.Rows.Add(0, "", "cc", "bet", 0, "prod")
    '        dt.AcceptChanges()
    '        '**********bt************
    '        dv.RowFilter = "department LIKE 'bt' OR btwork = 1 AND position LIKE 'prod'"

    '        cbo_bt.DisplayMember = "uname"
    '        cbo_bt.ValueMember = "Id"
    '        cbo_bt.DataSource = dv
    '        cbo_bt.SelectedValue = 0


    '        dv = New DataView(dt)
    '        dv.RowFilter = "department LIKE 'bt' AND position LIKE 'prod'"

    '        cbo_qabt.DisplayMember = "uname"
    '        cbo_qabt.ValueMember = "Id"
    '        cbo_qabt.DataSource = dv
    '        cbo_qabt.SelectedValue = 0

    '        '**********pr************
    '        dv = New DataView(dt)
    '        dv.RowFilter = "department LIKE 'pr' AND position LIKE 'prod'"

    '        cbo_pr.DisplayMember = "uname"
    '        cbo_pr.ValueMember = "Id"
    '        cbo_pr.DataSource = dv
    '        cbo_pr.SelectedValue = 0

    '        dv = New DataView(dt)
    '        dv.RowFilter = "department LIKE 'pr' AND position LIKE 'prod'"

    '        cbo_qapr.DisplayMember = "uname"
    '        cbo_qapr.ValueMember = "Id"
    '        cbo_qapr.DataSource = dv
    '        cbo_qapr.SelectedValue = 0

    '        '*********s&t***********
    '        dv = New DataView(dt)
    '        dv.RowFilter = "uDept LIKE 'st' AND position LIKE 'prod'"

    '        cbo_st.DisplayMember = "uname"
    '        cbo_st.ValueMember = "Id"
    '        cbo_st.DataSource = dv
    '        cbo_st.SelectedValue = 0

    '        dv = New DataView(dt)
    '        dv.RowFilter = "uDept LIKE 'st' AND position LIKE 'prod'"

    '        cbo_qast.DisplayMember = "uname"
    '        cbo_qast.ValueMember = "Id"
    '        cbo_qast.DataSource = dv
    '        cbo_qast.SelectedValue = 0

    '        '*********cc***********
    '        dv = New DataView(dt)
    '        dv.RowFilter = "uDept LIKE 'cc' AND position LIKE 'prod'"

    '        cbo_cc.DisplayMember = "uname"
    '        cbo_cc.ValueMember = "Id"
    '        cbo_cc.DataSource = dv
    '        cbo_cc.SelectedValue = 0

    '        dv = New DataView(dt)
    '        dv.RowFilter = "uDept LIKE 'cc' AND position LIKE 'prod'"

    '        cbo_qacc.DisplayMember = "uname"
    '        cbo_qacc.ValueMember = "Id"
    '        cbo_qacc.DataSource = dv
    '        cbo_qacc.SelectedValue = 0
    '    Catch ex As Exception
    '        cf.ErrorLog(ex)
    '    End Try

    'End Sub

    '''' <summary>
    '''' opens audio file/audio directory(for cc)
    '''' </summary>
    ''''
    'Private Sub btn_Audio_Click_1(sender As Object, e As EventArgs) Handles btn_Audio.Click
    '    Try
    '        If Me.txt_audio.Text <> "" Then
    '            'markDBOClass.SQLClass.conStr = "this value"
    '            Dim soundName As String = Me.txt_audio.Text
    '            Dim servSound As String = Path.Combine(varMod.BaseServer, varMod.servSound)
    '            Dim deskDir As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, varMod.userName, varMod.client)
    '            'copy sound from server directory to local directory

    '            Dim locSound As String = Path.Combine(baseSound, soundName)

    '            If varMod.uDept = "cc" Then
    '                If Not Directory.Exists(deskDir) Then
    '                    Directory.CreateDirectory(deskDir)
    '                End If

    '                'Me.lbl_status.Text = "Copying File, please wait"
    '                File.Copy(servSound, Path.Combine(deskDir, varMod.sFile))
    '                Process.Start(deskDir)
    '                'Me.lbl_status.Text = "Done"
    '            Else
    '                If File.Exists(locSound) Then
    '                    'file exists
    '                    'if server size <> user size then overwrite
    '                    Dim sInfo As New FileInfo(servSound)
    '                    Dim lInfo As New FileInfo(locSound)

    '                    If sInfo.Length <> lInfo.Length Then
    '                        'Me.lbl_status.Text = "Copying File, please wait"
    '                        File.Copy(servSound, locSound, True)
    '                        'Me.lbl_status.Text = "Done"
    '                    End If
    '                Else
    '                    'file does not exist in local directory
    '                    Try
    '                        'Me.lbl_status.Text = "Copying File, please wait"
    '                        File.Copy(servSound, locSound, True)
    '                        'Me.lbl_status.Text = "Done"
    '                    Catch ex As Exception
    '                        Console.WriteLine(ex.Message)
    '                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        Exit Sub
    '                    End Try
    '                End If
    '                'frm_playerselect.locDir = locSound
    '                'frm_playerselect.Show()
    '                startPlayer()

    '            End If
    '        End If
    '    Catch ex As Exception
    '        cf.ErrorLog(ex)
    '    End Try
    'End Sub

    'Private Sub btn_Doc_Click_1(sender As Object, e As EventArgs) Handles btn_Doc.Click

    'End Sub

    'Private Sub rd_express_CheckedChanged(sender As Object, e As EventArgs)

    '    If rd_express.Checked Then
    '        defaultPlayer = 1
    '    ElseIf rd_pepsup.Checked Then
    '        defaultPlayer = 2
    '    ElseIf rd_acqt.Checked Then
    '        defaultPlayer = 3
    '    End If

    'End Sub

    'Sub startPlayer()

    '    Select Case defaultPlayer
    '        Case 1
    '            'use express scribe
    '            Dim P As New ProcessStartInfo
    '            P.FileName = "C:\Program Files (x86)\NCH Swift Sound\Scribe\scribe.exe"
    '            If IO.File.Exists(P.FileName) = False And InStr(P.FileName, "x86") = 0 Then
    '                P.FileName = "C:\Program Files\NCH Swift Sound\Scribe\scribe.exe"
    '            End If

    '            Try
    '                P.Arguments = QuotationMark & locDir & QuotationMark
    '                Process.Start(P)
    '                Me.Close()
    '            Catch
    '                MsgBox("Unable to find Express Scribe. Please open file manually.")
    '                Process.Start(locDir)
    '            End Try
    '        Case 2
    '            'use people support
    '            Dim P As New ProcessStartInfo
    '            P.FileName = "C:\Program Files (x86)\PeopleSupport\TMS\RTMMPlayer.exe"
    '            If IO.File.Exists(P.FileName) = False And InStr(P.FileName, "x86") = 0 Then
    '                P.FileName = "C:\Program Files\PeopleSupport\TMS\RTMMPlayer.exe"
    '            End If
    '            Try
    '                P.Arguments = QuotationMark & locDir & QuotationMark
    '                Process.Start(P)
    '                Me.Close()
    '            Catch
    '                MsgBox("Unable to find PeopleSupport Multimedia Player. Please open file manually.")
    '                Process.Start(locDir)
    '            End Try
    '        Case 3
    '            'Dim p As New ProcessStartInfo
    '            'p.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ftsu2.exe"
    '            'p.Arguments = QuotationMark & locDir & QuotationMark
    '            'If IO.File.Exists(p.FileName) = False Then
    '            '    MsgBox("ARI Player not found.", vbCritical, "ARI Media Player")
    '            '    Process.Start(locDir)
    '            '    Exit Sub
    '            'End If
    '            'Try
    '            '    Process.Start(p)
    '            '    Me.Close()
    '            'Catch
    '            '    MessageBox.Show(Err.Description, "ARI Media Player", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            '    Process.Start(locDir)
    '            'End Try
    '    End Select
    'End Sub

    'Private Sub main_gridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles main_gridview.CellDoubleClick
    '    Try
    '        If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
    '            '***********************************************************
    '            Dim dgv As DataGridView = CType(sender, DataGridView)
    '            Dim SelectedRow As DataGridViewRow = dgv.SelectedRows(0)
    '            If Not mC.isStringEmpty(SelectedRow.Cells(41).Value.ToString()) Then
    '                Dim m As String = ""
    '                If SelectedRow.Cells(41).Value.ToString() = "NOT YET" Then
    '                    Dim topfile As String = dgv.Rows(0).Cells(9).Value.ToString()
    '                    m = "You can't start on this file yet. " & vbNewLine & "Submit [" & topfile & "] first."
    '                ElseIf SelectedRow.Cells(41).Value.ToString() = "WORKFLOW" Then
    '                    m = "You can't start this file yet since the previous workflow is not done yet."
    '                ElseIf SelectedRow.Cells(41).Value.ToString = "PROD" Then
    '                    m = "You can't start on this file yet. It is currently being work by the production assigned on it."
    '                Else
    '                    m = "You can't start this file since it is already being passed to the QA."
    '                End If
    '                MessageBox.Show(Me, m, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Exit Sub
    '            End If

    '            Dim msg As String = ""

    '            If main_gridview.SelectedRows(0).Cells(42).Value Then
    '                Dim isPass As Boolean = True
    '                For Each row As DataGridViewRow In main_gridview.Rows
    '                    If main_gridview.SelectedRows(0).Index <> row.Index And row.Cells(37).Value And Integer.Parse(row.Cells(40).Value.ToString()) = varMod.uid Then
    '                        Dim curfile As String = row.Cells(9).Value.ToString()
    '                        msg = "You can't start on this file yet. " & vbNewLine & "Submit [" & curfile & "] first."
    '                        isPass = False
    '                        Exit For
    '                    End If
    '                Next
    '                If Not isPass Then
    '                    MessageBox.Show(Me, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Exit Sub
    '                End If
    '            End If
    '            '***********************************************************

    '            'If Me.main_gridview.SelectedRows(0).Cells(40).Value = varMod.uid Or Me.main_gridview.SelectedRows(0).Cells(40).Value = 0 Then

    '            If varMod.CurUserPos.ToLower = "prod" Then
    '                Dim rushCount As Integer = 0

    '                For Each row As DataGridViewRow In Me.main_gridview.Rows
    '                    If CInt(row.Cells(3).Value) = True Then
    '                        rushCount += 1
    '                    End If
    '                Next

    '                If Me.main_gridview.SelectedRows(0).Cells(3).Value <> True And rushCount <> 0 Then
    '                    If rushCount <> 0 Then MessageBox.Show("You still have " & rushCount & " rush file(s).", "Rush found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
    '                End If

    '            End If


    '            'file selection
    '            Dim maingrid As DataGridView = sender
    '            Dim gActive As Integer
    '            Dim selRow As Integer = Me.main_gridview.SelectedRows(0).Cells(0).Value

    '            If Not varMod.CurUserPos Like "sched" Then
    '                db.nQuery("UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & selRow, New String() {"activeUser", varMod.uid, "active", "True"})
    '                maingrid(37, e.RowIndex).Value = True
    '                'Me.main_gridview.SelectedRows(0).Cells(36).Value = True
    '            End If

    '            fSelect = True
    '            '35-'38
    '            If varMod.fId <> selRow Then

    '                '0"id", 1"Prio", 2"Blank", 3"Rush", 4"Receive", 5"Service", 6"Due", 7"Client", 8"Branch", 9"Soundfile", 10"servSound", 11"locSound",'
    '                '"12Duration", 13"wFile", 14"servDoc", 15"servLoc", 16Page",'
    '                '"17BT", 18"QA BT", 19"PR", 20"QA PR", 21"S&T", 22"QA ST", 23"CC", "QA CC",'24
    '                '"25btid", 26"qabtid", 27"prid", 28"qaprid", 29"stid", 30"qastid", 31"ccid", "qaccid",'32
    '                '"33Accuracy", 34"Status", 35"Workflow", 36"Current Flow", 37"Active", 38"ret   File", 39"retDirectory", 40"activeUser", 41"rowEnabled", "isHold"} '42

    '                If Me.main_gridview.Rows.Count <> 0 Then

    '                    Me.chk_blank.Checked = Me.main_gridview.SelectedRows(0).Cells(2).Value
    '                    Me.chk_rush.Checked = Me.main_gridview.SelectedRows(0).Cells(3).Value
    '                    Me.txt_receive.Text = Me.main_gridview.SelectedRows(0).Cells(4).Value.ToString
    '                    Me.cbo_service.Text = Me.main_gridview.SelectedRows(0).Cells(5).Value.ToString
    '                    Me.txt_due.Text = Me.main_gridview.SelectedRows(0).Cells(6).Value.ToString
    '                    Me.txt_client.Text = Me.main_gridview.SelectedRows(0).Cells(7).Value.ToString
    '                    Me.txt_branch.Text = Me.main_gridview.SelectedRows(0).Cells(8).Value.ToString
    '                    Me.txt_audio.Text = Me.main_gridview.SelectedRows(0).Cells(9).Value.ToString
    '                    Me.txt_duration.Text = Me.main_gridview.SelectedRows(0).Cells(12).Value.ToString
    '                    Me.txt_document.Text = Me.main_gridview.SelectedRows(0).Cells(13).Value.ToString

    '                    Select Case varMod.CurUserPos
    '                        Case "admin", "ts", "auditor"
    '                            Me.txt_page.Text = Me.main_gridview.SelectedRows(0).Cells(16).Value.ToString
    '                            Me.cbo_bt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(25).Value
    '                            Me.cbo_pr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(27).Value
    '                            Me.cbo_st.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(29).Value
    '                            Me.cbo_cc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(31).Value
    '                            Me.cbo_qabt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(26).Value
    '                            Me.cbo_qapr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(28).Value
    '                            Me.cbo_qast.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(30).Value
    '                            Me.cbo_qacc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(32).Value
    '                        Case "sched"
    '                            Me.txt_page.Text = Me.main_gridview.SelectedRows(0).Cells(16).Value.ToString

    '                            Select Case varMod.CurUserDep
    '                                Case "bt"
    '                                    Me.cbo_bt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(25).Value
    '                                    Me.cbo_qabt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(26).Value
    '                                Case "pr"
    '                                    Me.cbo_pr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(27).Value
    '                                    Me.cbo_qapr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(28).Value
    '                                Case "bet"
    '                                    If varMod.uDept = "st" Then
    '                                        Me.cbo_st.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(29).Value
    '                                        Me.cbo_qast.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(30).Value
    '                                    ElseIf varMod.uDept = "cc" Then
    '                                        Me.cbo_cc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(31).Value
    '                                        Me.cbo_qacc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(32).Value
    '                                    End If
    '                            End Select
    '                    End Select
    '                End If

    '                varMod.recDate = Me.main_gridview.SelectedRows(0).Cells(4).Value.ToString
    '                varMod.client = Me.main_gridview.SelectedRows(0).Cells(7).Value.ToString
    '                varMod.branch = Me.main_gridview.SelectedRows(0).Cells(8).Value.ToString
    '                varMod.sFile = Me.main_gridview.SelectedRows(0).Cells(9).Value.ToString
    '                varMod.servSound = Me.main_gridview.SelectedRows(0).Cells(10).Value.ToString
    '                varMod.docName = Me.main_gridview.SelectedRows(0).Cells(13).Value.ToString
    '                varMod.servDoc = Me.main_gridview.SelectedRows(0).Cells(14).Value.ToString
    '                varMod.btid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(25).Value)
    '                varMod.prid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(27).Value)
    '                varMod.qaprid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(28).Value)
    '                varMod.cFlow = Me.main_gridview.SelectedRows(0).Cells(36).Value
    '                varMod.returnStat = Me.main_gridview.SelectedRows(0).Cells(38).Value
    '                varMod.retDirectory = Me.main_gridview.SelectedRows(0).Cells(39).Value.ToString

    '                For i = 0 To Me.main_gridview.Columns.Count - 1
    '                    Console.WriteLine(i & " = " & Me.main_gridview.SelectedRows(0).Cells(i).Value & " | " & Me.main_gridview.Columns(i).Name & " | " & Me.main_gridview.SelectedRows(0).Cells(i).Value.GetType.ToString())
    '                Next
    '                Console.WriteLine(Me.main_gridview.SelectedRows(0).Cells(0).Value & " | " & Me.main_gridview.SelectedRows(0).Cells(36).Value & " | " & Me.main_gridview.Columns(36).Name)

    '                varMod.flow = Me.main_gridview.SelectedRows(0).Cells(35).Value.ToString
    '                'cFlow = Me.main_gridview.SelectedRows(0).Cells(36).Value

    '                'QA users
    '                If varMod.CurUserPos = "prod" Then
    '                    If varMod.uDept = "bt" Then
    '                        varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(26).Value
    '                    ElseIf varMod.uDept = "pr" Then
    '                        varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(28).Value
    '                    ElseIf varMod.uDept = "st" Then
    '                        varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(30).Value
    '                    ElseIf varMod.uDept = "cc" Then
    '                        varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(32).Value
    '                    End If
    '                End If


    '                db.nQuery("UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & varMod.fId, New String() {"activeUser", 0, "active", "False"})
    '                Dim rindex As Integer = e.RowIndex
    '                If LastRowSelected <> vbNull Then rindex = LastRowSelected
    '                maingrid(36, rindex).Value = False
    '                'maingrid(24, varMod.fId).Value = False
    '                If LastRowSelected <> vbNull Then LastRowSelected = e.RowIndex
    '            End If

    '            varMod.fId = Me.main_gridview.SelectedRows(0).Cells(0).Value

    '            LoadData()
    '            'End If
    '        End If
    '    Catch ex As Exception
    '        cf.ErrorLog(ex)
    '    End Try
    'End Sub

    'Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
    '    frm_upload.ShowDialog(Me)
    'End Sub

    '' Dropdown hide when other objects are clicked

    '' Dropdown hide when other objects are clicked - END

    'Private Sub btn_archive_Click(sender As Object, e As EventArgs) Handles btn_archive.Click

    'End Sub

    '''' <summary>
    '''' archiving files that have been exported
    '''' archived files are only viewable by the admin
    '''' </summary>
    'Sub archive_function()
    '    'Dim repwhat As String = "TRANSCRIPT(\\\w+)*\\DOWNLOAD"
    '    'Dim repwith As String = "TRANSCRIPT\archive\DOWNLOAD"
    '    'Dim repTest As String = System.Text.RegularExpressions.Regex.Replace(val1, repwhat, repwith, System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    '    ''Console.writeline(repTest)
    '    If New String() {"admin"}.Contains(varMod.CurUserPos) Then

    '        Dim dt As Data.DataTable = db.query("SELECT Id,servdoc,wFile FROM dbo.Main WHERE status='done'")
    '        Dim repwhat As String = "TRANSCRIPT.+DOWNLOAD"
    '        Dim repwith As String = "TRANSCRIPT\archive\DOWNLOAD"
    '        Dim idList As New List(Of Integer)()

    '        For Each rows As DataRow In dt.Rows
    '            Dim row As Object = rows.ItemArray
    '            Try
    '                Dim repDir As String = System.Text.RegularExpressions.Regex.Replace(row(1), repwhat, repwith)
    '                If Not Directory.Exists(Path.Combine(varMod.BaseServer, repDir)) Then Directory.CreateDirectory(Path.Combine(varMod.BaseServer, repDir))
    '                Console.WriteLine(Path.Combine(varMod.BaseServer, row(1), row(2)))
    '                Console.WriteLine(Path.Combine(varMod.BaseServer, repDir, row(2)))
    '                File.Copy(Path.Combine(varMod.BaseServer, row(1), row(2)), Path.Combine(varMod.BaseServer, repDir, row(2)))
    '                idList.Add(row(0))
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End Try
    '        Next

    '        If idList.Count <> 0 Then
    '            db.nQuery("UPDATE dbo.Main SET status='archive' WHERE Id IN (" & String.Join(",", idList) & ")")
    '            MessageBox.Show("Archvie complete." & vbCrLf& & "Archived " & idList.Count & " files.", "", MessageBoxButtons.OK, MessageBoxIcon.None)
    '        Else
    '            MessageBox.Show("No files available to archive", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If

    '    End If

    'End Sub

    'Private Sub btn_loginout_Click(sender As Object, e As EventArgs) Handles btn_loginout.Click

    '    Me.WindowState = FormWindowState.Maximized
    '    Me.Enabled = False
    '    Me.TopMost = True
    '    Me.Location = New Point(0, 0)

    '    frm_logout.Show()
    '    frm_logout.TopMost = True
    'End Sub
    ''commenthere
    'Private Sub btn_userlist_Click(sender As Object, e As EventArgs) Handles btn_userlist.Click
    '    frm_userlist.ShowDialog(Me)
    'End Sub

    'Private Sub btn_workflow_Click(sender As Object, e As EventArgs) Handles btn_workflow.Click
    '    frm_workflow.ShowDialog(Me)
    'End Sub

    ''Private Sub btn_file_eval_Click(sender As Object, e As EventArgs) Handles btn_file_eval.Click
    ''    frm_file_eval.ShowDialog(Me)
    ''End Sub

    'Private Sub btn_flagging_Click(sender As Object, e As EventArgs) Handles btn_flagging.Click
    '    Dim flagging = New frm_flagging

    '    flagging.ShowDialog(Me)
    'End Sub

    ''Private Sub btn_myeval_Click(sender As Object, e As EventArgs) Handles btn_myeval.Click
    ''    frm_file_eval.ShowDialog(Me)
    ''End Sub

    'Private Sub btn_break_Click(sender As Object, e As EventArgs) Handles btn_break.Click
    '    frm_break.ShowDialog(Me)
    'End Sub
    ''commenthere

    'Private Sub Panel1_DoubleClick(sender As Object, e As EventArgs)
    '    Me.Location = New Point(0, 0)
    'End Sub

    'Private Sub frm_main_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    '    resize_components()
    'End Sub

    'Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    '    Me.Hide()
    '    frm_minimized.Show()
    'End Sub

    'Private Sub btn_monitoring_Click(sender As Object, e As EventArgs) Handles btn_monitoring.Click
    '    frm_monitoring.Show()
    'End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Me.Close()
    'End Sub

    'Private Sub btn_files_due_Click(sender As Object, e As EventArgs) Handles btn_files_due.Click
    '    frm_duefile.Show()
    'End Sub
#End Region

End Class