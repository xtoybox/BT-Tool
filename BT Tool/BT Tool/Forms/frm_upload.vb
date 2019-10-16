Imports System.IO
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks

Public Class frm_upload

#Region "Constant Variables"
    Private Const OF_SHARE_DENY_WRITE As Integer = &H20S
#End Region
#Region "Structure"
    Private Structure AVIFileInfo
        Dim dwMaxBytesPerSec As Integer
        Dim dwFlags As Integer
        Dim dwCaps As Integer
        Dim dwStreams As Integer
        Dim dwSuggestedBufferSize As Integer
        Dim dwWidth As Integer
        Dim dwHeight As Integer
        Dim dwScale As Integer
        Dim dwRate As Integer
        Dim dwLength As Integer
        Dim dwEditCount As Integer
        <VBFixedString(64), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=64)> Public szFileType As String
    End Structure
#End Region
#Region "API Function Declarations"
    Private Declare Function AVIFileOpen Lib "avifil32" Alias "AVIFileOpenA" (ByRef ppfile As Integer, ByVal szFile As String, ByVal mode As Integer, ByVal pclsidHandler As IntPtr) As Integer
    Private Declare Function AVIFileRelease Lib "avifil32" (ByVal pfile As Integer) As Integer
    Private Declare Function AVIFileInfo_Renamed Lib "avifil32" Alias "AVIFileInfoA" (ByVal pfile As Integer, ByRef pfi As AVIFileInfo, ByVal lSize As Integer) As Integer
    Private Declare Sub AVIFileInit Lib "avifil32" ()
    Private Declare Sub AVIFileExit Lib "avifil32" ()
#End Region
#Region "Instantiate Class"
    Private cf As New CustomFunctions()
    Private mf As New markform.CustomClass()
    Private db As New markDBOClass.DboClass
#End Region
#Region "Declaring Variables"
    Public objShell = CreateObject("Shell.Application")
    Public flCount As Long = 0
    Private uploadDir As String = ""
    Private cList As List(Of String) = New List(Of String)
    Private sDir As String = Path.Combine(varMod.BaseServer, "FROOT\AUDIO\UPLOAD")

    Private _cancl As CancellationTokenSource
#End Region
#Region "Events"
    Private CustomFn As New CustomFunctions()

    Private Sub frm_upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CustomFn.FormDrag(Me, Panel1)

        Me.Label1.Text = "Loading files. Please wait."
        Me.Show()

        'Cursor = Cursors.WaitCursor
        'Application.DoEvents()

        'GetAllFolders(Path.Combine(varMod.BaseServer, "FROOT\AUDIO\UPLOAD")).0
        Me.Cursor = Cursors.AppStarting
        GetFiles(sDir)

        Me.Label1.Text = "Upload"
        Cursor = Cursors.Default

    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    'Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
    '    Try
    '        'get destination path from FolderBrowserDialog
    '        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
    '            Dim index As Integer = FolderBrowserDialog1.SelectedPath.LastIndexOf("\")
    '            uploadDir = FolderBrowserDialog1.SelectedPath.Substring(index + 1)
    '            GetAllFolders(FolderBrowserDialog1.SelectedPath)
    '        End If
    '    Catch ex As Exception
    '        cf.ErrorLog(ex)
    '    End Try
    'End Sub

    ''' <summary>
    ''' old upload function
    ''' </summary>
    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click

        Try
            upList.Clear()
            'prgBar.Value = 0
            Console.WriteLine(varMod.servSound)
            Dim dateDue As String = Format(Me.dtp_due.Value, "MM/dd/yyyy")
            Dim dTime As String = Me.dtp_time.Value.ToString("HH:mm")
            Dim ct As Integer = 0

            Dim increment As Integer = 0
            Me.lbl_status.Text = "Uploading"
            For a = 0 To Me.grid_upload.RowCount - 1
                If Me.grid_upload.Rows(a).Selected = True Then
                    ct += 1
                End If
            Next

            Dim div = 100 / ct

            Application.DoEvents()
            For Each selrow As DataGridViewRow In Me.grid_upload.SelectedRows

                Dim dateRec As String = selrow.Cells(0).Value
                Dim client As String = selrow.Cells(1).Value
                Dim branch As String = selrow.Cells(2).Value
                Dim fName As String = selrow.Cells(3).Value
                Dim duration As String = selrow.Cells(4).Value
                'source directory
                Dim sDir As String = selrow.Cells(5).Value
                Dim flow As String = Me.cbo_workflow.Text
                Dim ftype As String = selrow.Cells(6).Value
                Dim cFlow As Integer = 0

                varMod.servSound = Path.Combine("FROOT\AUDIO", uploadDir, branch)
                Dim gPath As String = Path.Combine(varMod.BaseServer, varMod.servSound)
                'If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)

                'If branch <> "" Then
                '    If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)
                'End If

                'get date?
                'Dim newDir As String = Regex.Replace(sDir, "[/\\][/\\]+[A-Za-z0-9._%+-]+[/\\]+[A-Za-z0-9._%+-]+[/\\]", "", RegexOptions.IgnoreCase)
                'Dim newDir As String = Regex.Replace(sDir, varMod.BaseServer, "", RegexOptions.IgnoreCase)
                Dim newDir As String = sDir.Replace(varMod.BaseServer & "\", "")
                Dim serverPath As String = Path.Combine(gPath, fName)

                'Try
                '    increment = increment + div
                '    If increment > prgBar.Maximum Then
                '        increment = prgBar.Maximum
                '    End If
                '    prgBar.Value = increment
                'Catch ex As Exception
                '    'File.Copy(sFile, serverPath, True)
                '    MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    GoTo onError
                'End Try

                upList.Add(dateRec & "|" & dateDue & "|" & dTime & "|" & client & "|" & branch & "|" & fName & "|" & duration & "|" & newDir & "|" & flow & "|" & cFlow & "|" & ftype)

                Me.grid_upload.Rows.Remove(selrow)
            Next

            For Each element As String In upList
                Console.WriteLine(element)
            Next

            uploadFiles()

            Me.grid_upload.Refresh()
            'prgBar.Value = prgBar.Maximum
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            MsgBox("Upload complete", vbOKOnly, "Upload complete")
            frm_main.fillMain()
            Me.lbl_status.Text = "Upload Complete"
        Catch ex As Exception
            cf.ErrorLog(ex)
        End Try

onError:
    End Sub

    'Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Me.cbo_client.Items.Clear()
    '    cList.Clear()
    '    Me.Cursor = Cursors.AppStarting
    '    GetFiles(sDir)
    'End Sub

    Private Sub cbo_client_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_client.SelectedIndexChanged
        filter()
    End Sub

    Private Sub txt_filename_TextChanged(sender As Object, e As EventArgs) Handles txt_filename.TextChanged
        filter()
    End Sub

    Private Sub frm_upload_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _cancl IsNot Nothing Then
            _cancl.Cancel()
        End If
    End Sub

#End Region

#Region "Sub Routine"

    Sub fill_combo()
        Try
            Dim sList As List(Of String) = cList.Distinct.ToList

            For Each element As String In sList
                Me.cbo_client.Items.Add(element)
            Next
            Dim dt As DataTable = db.query("SELECT Id,flow FROM dbo.Workflow")

            Me.cbo_workflow.DisplayMember = "flow"
            Me.cbo_workflow.ValueMember = "Id"
            Me.cbo_client.SelectedIndex = 0

            cbo_workflow.DataSource = dt
        Catch ex As Exception
            cf.ErrorLog(ex)
        End Try
    End Sub

    Sub folderLoop(ByRef directory As String)
        Try
            Dim ParentDir As String = directory
            Dim d As String
            For Each d In IO.Directory.GetDirectories(ParentDir)

                folderLoop(d) 'Add all the subFolder's subfolders
            Next
        Catch ex As Exception
            cf.ErrorLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' old functin for uploading file
    ''' </summary>
    Private Sub GetAllFolders(directory As String)

        Dim fi As New IO.DirectoryInfo(directory)
        Dim pt() As String = {}, nDate As String, nClient As String = "", nBranch As String = "", medDuration As String, ext As String, ftype As String = ""
        Dim itemArr As FileInfo() = fi.GetFiles()
        Dim item As FileInfo
        Dim leDate As Match
        Dim leClient As Match

        Dim wmp As WMPLib.WindowsMediaPlayer = New WMPLib.WindowsMediaPlayer

        Dim objFolder = objShell.Namespace((directory))
        Dim newdt As New DataTable
        newdt.Columns.Add("", GetType(String)) : newdt.Columns.Add("Date", GetType(String)) : newdt.Columns.Add("Client", GetType(String)) : newdt.Columns.Add("Branch", GetType(String))
        newdt.Columns.Add("Filename", GetType(String)) : newdt.Columns.Add("Duration", GetType(String)) : newdt.Columns.Add("Path", GetType(String)) : newdt.Columns.Add("", GetType(String))
        newdt.Columns.Add("Type", GetType(String))

        Try
            Me.Cursor = Cursors.AppStarting

            For Each item In itemArr
                'data extraction goes here
                If (Not objFolder Is Nothing) Then

                    Dim objFolderItem = objFolder.ParseName(item.Name)
                    Dim di As DirectoryInfo = item.Directory
                    leClient = Regex.Match(di.FullName, "UPLOAD.+(\d{2})(\d{2})(\d{4})", RegexOptions.IgnoreCase)
                    Dim splitClient As String() = leClient.ToString.Split("-")
                    nClient = splitClient(1)

                    If (Not objFolderItem Is Nothing) Then

                        ext = Path.GetExtension(item.Name)
                        Select Case ext.ToLower

                            Case ".wav", ".mpeg", ".mp3", ".mp4", ".m4a", ".avi", ".wmv", ".mov", ".mpg", ".wpl", ".wma", " "

                                Select Case ext.ToLower
                                    Case ".wav", ".mpeg", ".mp3", ".wma"
                                        ftype = "Audio"
                                    Case ".mp4", ".m4a", ".avi", ".wmv", ".mov", ".mpg"
                                        ftype = "Video"
                                End Select
                                'get date from directory
                                leDate = Regex.Match(directory, "(\d{2})(\d{2})(\d{4})?", RegexOptions.IgnoreCase)
                                Dim dt As DateTime = DateTime.ParseExact(leDate.ToString, "mmddyyyy", CultureInfo.InvariantCulture)
                                nDate = dt.ToString("mm/dd/yyyy", CultureInfo.InvariantCulture)

                                'get client and branch format
                                If nClient = "MCY" Then
                                    nBranch = objFolder.getdetailsof(objFolderItem, 176)
                                ElseIf InStr(1, directory, "amica") <> 0 Then
                                    nClient = "Amica"
                                ElseIf InStr(1, directory, "K_DAL") <> 0 Then
                                    nClient = "Kemper"
                                ElseIf InStr(1, directory, "SPC") <> 0 Or InStr(1, directory, "UINS") <> 0 Then
                                    nClient = "UINS SPC"
                                End If

                                Dim media As WMPLib.IWMPMedia = wmp.newMedia(directory & "\" & item.Name)
                                medDuration = ShowAVIInfo(directory & "\" & item.Name).ToString

                                Select Case medDuration

                                    Case "00:00:00", ""
                                        Dim iSecond As Double = media.duration 'Total number of seconds
                                        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(iSecond)

                                        Dim hrs As String = iSpan.Hours.ToString.PadLeft(2, "0"c)
                                        Dim min As String = iSpan.Minutes.ToString.PadLeft(2, "0"c)
                                        Dim sec As String = iSpan.Seconds.ToString.PadLeft(2, "0"c)

                                        medDuration = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                                                    iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                                                        iSpan.Seconds.ToString.PadLeft(2, "0"c)

                                End Select
                                cList.Add(nClient)
                                newdt.Rows.Add(Nothing, nDate, nClient, nBranch, item.Name, medDuration, directory & "\" & item.Name, "", ftype)

                        End Select
here:
                    End If

                    objFolderItem = Nothing

                End If
            Next

            For Each subfolder As IO.DirectoryInfo In fi.GetDirectories()
                'loop to next folder
                GetAllFolders(subfolder.FullName)
            Next

            Me.grid_upload.DataSource = newdt

            objFolder = Nothing
        Catch ex As Exception
            MessageBox.Show(Me, ex.ToString(), "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' extract file details from predefined directory for uploading
    ''' </summary>
    Private Async Sub GetFiles(dir As String)
        'Dim dir As String = "\\accomediasvr\MediaFiles-2\FROOT\AUDIO\UPLOAD"
        _cancl = New CancellationTokenSource()
        Dim token As CancellationToken = _cancl.Token

        Dim catchErrorMsg As String = Nothing

        Try

            'Me.lbl_status.Text = 0 : Me.lbl_status.Text = ""
            ' lbl_total_files.Text = 0 : lbl_file_prog.Text = ""  prgBar.Maximum = 0 : prgBar.Value = 0
            Dim ExtArray() As String = New String() {".wav", ".mpeg", ".mp3", ".mp4", ".m4a", ".avi", ".wmv", ".mov", ".mpg", ".wpl", ".wma"}
            Dim wmp As WMPLib.WindowsMediaPlayer = New WMPLib.WindowsMediaPlayer
            Dim TopLevelFolder As New DirectoryInfo(dir) : Dim ProgSet As Boolean = False

            Dim progressHandler As Progress(Of String) = New Progress(Of String)(
                Sub(val)
                    If ProgSet Then
                        flCount = Integer.Parse(flCount) + 1
                        Me.lbl_status.Text = flCount & " " & val
                        'lbl_total_files.Text = Integer.Parse(lbl_total_files.Text) + 1
                        'lbl_file_prog.Text = val
                        'If prgBar.Value < prgBar.Maximum Then
                        '    prgBar.Value = Integer.Parse(lbl_total_files.Text) + 1
                        'End If
                    Else
                        'prgBar.Maximum = Integer.Parse(val)
                        ProgSet = True
                    End If
                End Sub)

            Dim progress As IProgress(Of String) = CType(progressHandler, IProgress(Of String))
            Dim dt As New DataTable() : Dim str As String = "" : Dim clst As New List(Of String) : clst.Add("All")
            Dim headers As New List(Of GridHeaders)()

            headers.Add(New GridHeaders() With {.index = 0, .text = "Receive", .type = GetType(String), .width = 70})
            headers.Add(New GridHeaders() With {.index = 1, .text = "Client", .type = GetType(String), .width = 60})
            headers.Add(New GridHeaders() With {.index = 2, .text = "Branch", .type = GetType(String), .width = 130})
            headers.Add(New GridHeaders() With {.index = 3, .text = "Filename", .type = GetType(String), .width = 370})
            headers.Add(New GridHeaders() With {.index = 4, .text = "Duration", .type = GetType(String), .width = 55})
            headers.Add(New GridHeaders() With {.index = 5, .text = "Directory", .type = GetType(String), .width = 100})
            headers.Add(New GridHeaders() With {.index = 6, .text = "Type", .type = GetType(String), .width = 40})

            'add new column to datagridview
            For Each itm As GridHeaders In headers
                dt.Columns.Add(itm.text, itm.type)
            Next

            Await Task.Run(
                Sub()
                    token.ThrowIfCancellationRequested()
                    Dim x As Integer = 0
                    For Each CurrentFile As FileInfo In TopLevelFolder.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(
                    Function(files As FileInfo)
                        Return ExtArray.Any(Function(ext As String)
                                                Return files.Extension.ToLowerInvariant = ext
                                            End Function)
                    End Function)
                        token.ThrowIfCancellationRequested()
                        x = x + 1
                    Next

                    progress.Report(x)

                    For Each CurrentFile As FileInfo In TopLevelFolder.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(
                    Function(files As FileInfo)
                        Return ExtArray.Any(Function(ext As String)
                                                Return files.Extension.ToLowerInvariant = ext
                                            End Function)
                    End Function)

                        token.ThrowIfCancellationRequested()

                        Dim FileType As String = "Video"
                        If New String() {".wav", ".mpeg", ".mp3", ".wma"}.Contains(CurrentFile.Extension.ToLowerInvariant) Then
                            FileType = "Audio"
                        End If
                        'get date from directory
                        Dim GetDate As String = DateTime.ParseExact(Regex.Match(CurrentFile.DirectoryName, "(\d{2})(\d{2})(\d{4})?", RegexOptions.IgnoreCase).ToString(), "mmddyyyy", CultureInfo.InvariantCulture).ToString("mm/dd/yyyy", CultureInfo.InvariantCulture)
                        'get client name
                        Dim GetClient As String = Regex.Match(CurrentFile.DirectoryName, "UPLOAD.+(\d{2})(\d{2})(\d{4})", RegexOptions.IgnoreCase).ToString().Split("-")(1)
                        Dim GetBranch As String = ""

                        If GetClient = "MCY" Then
                            Dim DirSplit() As String = CurrentFile.DirectoryName.Split("\"c)
                            GetBranch = DirSplit(DirSplit.Length - 1)
                        ElseIf GetClient.Contains("amica") Then
                            GetClient = "Amica"
                        ElseIf GetClient.Contains("K_DAL") Then
                            GetClient = "Kemper"
                        ElseIf GetClient.Contains("SPC") Or GetClient.Contains("UINS") Then
                            GetClient = "UINS SPC"
                        End If

                        Dim media As WMPLib.IWMPMedia = wmp.newMedia(CurrentFile.FullName)
                        clst.Add(GetClient)
                        dt.Rows.Add(GetDate, GetClient, GetBranch, CurrentFile.Name, cf.SecondsToTime24(media.duration), CurrentFile.FullName, FileType)
                        progress.Report(CurrentFile.Name)

                    Next
                End Sub)

            grid_upload.DataSource = dt

            'set datagridview column properties
            For Each itm As GridHeaders In headers
                Try
                    grid_upload.Columns(itm.index).Width = itm.width
                Catch ex As Exception
                    catchErrorMsg = "Current Index: " & itm.index
                    Throw ex
                End Try
            Next

            Me.lbl_status.Text = "Done"
            cList = clst
            fill_combo()
        Catch exc As OperationCanceledException
            Console.WriteLine("Cancelled")
        Catch ex As Exception
            cf.ErrorLog(ex, catchErrorMsg)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' uploading process based on selected files on upload form
    ''' </summary>
    Public Sub uploadFiles()
        'upload file details to database

        Dim i As Long = 0
        Dim sUp() As String
        Dim upCount As Long = upList.Count - 1
        Dim arr As String() = upList.ToArray
        Dim dept As String = ""

        For i = 0 To upCount

            sUp = Split(upList(i).ToString, "|")

            Dim dFlow As String() = Split(sUp(8), "-")

            Select Case dFlow(0)
                Case "BT"
                    dept = "BT Sched"
                Case "PR"
                    dept = "PR Sched"
                Case "S&T"
                    dept = "ST Sched"
                Case "CC"
                    dept = "CC Sched"
            End Select

            Dim stringVal As String() = sUp(8).Split("-")
            Dim forX As String = stringVal(sUp(9))

            Dim nQuer As Integer = db.nQuery("INSERT INTO dbo.Main (dateRec,dateDue,timeDue,client,branch,sFile,duration,servSound,status,active,flow,cFlow,ftype) 
                VALUES (@dateRec,@dateDue,@timeDue,@client,@branch,@sFile,@duration,@servSound,@status,@active,@flow,@cFlow,@ftype)",
                    New String() {"dateRec", sUp(0), "dateDue", sUp(1), "timeDue", sUp(2), "client", sUp(3), "branch", sUp(4), "sFile", sUp(5), "duration",
                        sUp(6), "servSound", sUp(7), "flow", sUp(8), "cFlow", sUp(9), "ftype", sUp(10), "status", forX & " Sched", "active", "0"})

            If nQuer <> 0 Then
                Debug.WriteLine("Record Added")
            Else
                MessageBox.Show("Failed to add record(s) on filename " & sUp(5) & ".")
            End If

        Next i
here:
    End Sub

    ''' <summary>
    ''' new upload function, not being used
    ''' </summary>
    Sub newUpload()
        Try
            upList.Clear()
            'prgBar.Value = 0
            Console.WriteLine(varMod.servSound)
            Dim dateDue As String = Format(Me.dtp_due.Value, "MM/dd/yyyy")
            Dim dTime As String = Me.dtp_time.Value.ToString("HH:mm")
            Dim ct As Integer = 0

            Dim increment As Integer = 0
            Me.lbl_status.Text = "Uploading"
            For a = 0 To Me.grid_upload.RowCount - 1
                If Me.grid_upload.Rows(a).Selected = True Then
                    ct += 1
                End If
            Next

            Dim div = 100 / ct

            Application.DoEvents()
            For Each selrow As DataGridViewRow In Me.grid_upload.SelectedRows
                'Application.DoEvents()

                Dim dateRec As String = selrow.Cells(1).Value
                Dim client As String = selrow.Cells(2).Value
                Dim branch As String = selrow.Cells(3).Value
                Dim fName As String = selrow.Cells(4).Value
                Dim duration As String = selrow.Cells(5).Value
                'source directory
                Dim sDir As String = selrow.Cells(6).Value
                Dim flow As String = Me.cbo_workflow.Text
                Dim ftype As String = selrow.Cells(8).Value
                Dim cFlow As Integer = 0

                Console.WriteLine(sDir)

                Dim servSound As String = Path.Combine("FROOT\AUDIO", uploadDir, branch)
                Dim gPath As String = Path.Combine(varMod.BaseServer, servSound)
                If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)

                If branch <> "" Then
                    If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)
                End If
                Console.WriteLine(gPath)
                'check branch folder exist
                '\\accomediasvr\MediaFiles-2
                'Dim varmod.servsound As String = Path.Combine("\\accomediasvr\MediaFiles-2\FROOT\AUDIO", selrow.Cells(3).Value, fName)
                Dim serverPath As String = Path.Combine(gPath, fName)
                Console.WriteLine(serverPath)

                Try
                    increment = increment + div
                    'If increment > prgBar.Maximum Then
                    '    increment = prgBar.Maximum
                    'End If
                    'prgBar.Value = increment

                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo onError
                End Try

                upList.Add(dateRec & "|" & dateDue & "|" & dTime & "|" & client & "|" & branch & "|" & fName & "|" & duration & "|" & sDir & "|" & flow & "|" & cFlow & "|" & ftype)
                Me.grid_upload.Rows.Remove(selrow)
            Next

            For x As Integer = Me.grid_upload.Rows.Count - 1 To 0 Step -1
                If Me.grid_upload.Rows(x).Cells(1).Value Then 'Column1.Name
                    Me.grid_upload.Rows.Remove(Me.grid_upload.Rows(x))
                End If
            Next

            uploadFiles()

            Me.grid_upload.Refresh()
            'prgBar.Value = prgBar.Maximum
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            MsgBox("Upload complete", vbOKOnly, "Upload complete")
            frm_main.fillMain()
            Me.lbl_status.Text = "Upload Complete"

        Catch ex As Exception
            cf.ErrorLog(ex)
        End Try

onError:
    End Sub

    'Sub upload_function()

    '    If New String() {"admin", "ts"}.Contains(varMod.CurUserDep) Or varMod.canUpload = True Then
    '        frm_upload.ShowDialog()
    '        frm_upload.Dispose()
    '    Else
    '        MessageBox.Show("You do not have enough privileges to access this function.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    ''' <summary>
    ''' get sound file details for duration
    ''' </summary>
    Private Function ShowAVIInfo(ByVal dir As String) As TimeSpan
        Try

            Dim hFile As Integer
            Dim AviInfo As AVIFileInfo
            Dim rTime As Double
            'initialize the AVIFile library
            AVIFileInit()
            'create a handle to the AVI file
            If AVIFileOpen(hFile, dir, OF_SHARE_DENY_WRITE, Nothing) = 0 Then
                'retrieve the AVI information
                If AVIFileInfo_Renamed(hFile, AviInfo, Len(AviInfo)) = 0 Then

                    rTime = (AviInfo.dwLength / (AviInfo.dwRate / AviInfo.dwScale))

                    Dim wow As Long = Math.Floor(rTime)
                    Dim tp As TimeSpan = New TimeSpan(0, 0, wow)

                    ShowAVIInfo = tp

                End If
                'release the file handle
                AVIFileRelease(hFile)
            End If
            'exit the AVIFile library and decrement the reference count for the library
            AVIFileExit()
        Catch ex As Exception
            cf.ErrorLog(ex)
        End Try

    End Function

    Sub filter()

        Dim txt As String = ""
        Dim filter As List(Of String) = New List(Of String)

        If Me.txt_filename.Text <> "" Then
            filter.Add("Filename LIKE '%" & Me.txt_filename.Text & "%'")
        End If

        If Me.cbo_client.SelectedItem <> "All" Then
            filter.Add("Client LIKE '" & Me.cbo_client.SelectedItem & "'")
        End If

        If filter.Count <> 0 Then
            txt = String.Join(" AND ", filter.ToArray)
        End If

        Dim ds As DataTable = grid_upload.DataSource
        ds.DefaultView.RowFilter = txt

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Btn_reload_Click(sender As Object, e As EventArgs) Handles Btn_reload.Click
        Me.cbo_client.Items.Clear()
        cList.Clear()
        Me.Cursor = Cursors.AppStarting
        GetFiles(sDir)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


#End Region
End Class
