Imports System.IO
Imports System.Globalization
Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Thread
Imports System.Threading.Tasks

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

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
    Private cf As New markform.CustomClass
    Private db As New markform.SQLClass
#End Region
#Region "Declaring Variables"
    Public objShell = CreateObject("Shell.Application")

    Private CurrentFilesSourceDir As String = ""
    Private ClientList As List(Of String) = New List(Of String)
    Private LastScanData As String = ""
    Private UseLastScan As Boolean = False

    Private _cancl As CancellationTokenSource
#End Region
#Region "Events"
    ''' <summary>
    ''' Executing event on form load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frm_upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentFilesSourceDir = cf.ReadAppSetting("FileSourceDir") 'Assigning value from the application settings
        'checking if there is a last upload data
        Dim lud As String = cf.ReadAppSetting("LastScanData") 'Assigning value from the application settings
        'if lud is not "NOT FOUND" then give option to the user to use the load 
        If lud <> "NOT FOUND" Then
            LastScanData = lud
            Dim dr As DialogResult = MessageBox.Show(Me, "Would you like to load the data from last scan?", "Confirm Load Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            UseLastScan = (dr = DialogResult.Yes)
        End If
        dgv_upload.DataSource = vbNull
        LoadFiles()
        LoadWorkFlowDataSource()
    End Sub
    ''' <summary>
    ''' Execute event when upload button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        Dim cntTotal = 0 : Dim cntExist = 0 : Dim adMsg = ""
        For Each SelRow As DataGridViewRow In dgv_upload.SelectedRows
            Dim IsExist As Boolean = SelRow.Cells(7).Value
            If IsExist Then cntExist = cntExist + 1
            cntTotal = cntTotal + 1
        Next
        If cntExist > 0 Then
            adMsg = "Total Selected File" & If(cntExist > 1, "s", "") & " that already exist in the database: " & cntExist & vbNewLine & vbNewLine &
                "Warning! Selected files that already exist in the database will overwrite the data from the database."

        End If
        Dim dr As DialogResult = MessageBox.Show(Me, "Are you sure you want to upload selected file" & If(cntTotal > 1, "s", "") & "?" & vbNewLine & vbNewLine & "Total Selected file" & If(cntTotal > 1, "s", "") & ": " & cntTotal & vbNewLine & adMsg, "Confirm File Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = DialogResult.Yes Then UploadData()
    End Sub
    ''' <summary>
    ''' Execute event when reload button from the menu strip control is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        UseLastScan = False
        LoadFiles()
    End Sub
    ''' <summary>
    ''' Execute event when datagridview header is clicked. This will fixed the format of the datagridview rows
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgv_upload_Sorted(sender As Object, e As EventArgs) Handles dgv_upload.Sorted
        FormatDGV()
    End Sub
    ''' <summary>
    ''' Execute the filter function if cbo_client selected item is changed or txt_filename text is changed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Filter_Event(sender As Object, e As EventArgs) Handles cbo_client.SelectedIndexChanged, txt_filename.TextChanged
        Filter()
    End Sub
#End Region
#Region "Sub Routine"
    ''' <summary>
    ''' Loading data from the server and populate data to the datagridview
    ''' </summary>
    Private Async Sub LoadFiles()
        _cancl = New CancellationTokenSource() 'instantiate new cancellation token.
        Dim token As CancellationToken = _cancl.Token 'Used for cancelling the execution when cancel token is presented.
        Dim AddMsg As String = "" 'Additional message for when an exception occured.
        Dim ClItm As List(Of String) = New List(Of String) : ClItm.Add("ALL") 'declaring an list for the client and adding the first value of the list.
        Cursor = Cursors.AppStarting 'change the cursor of the current form to AppStarting
        EnableControls(False) 'Disabling the controls to prevent user from interacting the controls.
        lbl_status.Text = If(UseLastScan, "Loading files from the last scan...", "Loading files form the server...") 'changing the text of the lbl_status base on either UseLastUpload is true or false
        Sleep(1000) 'Delay the continuation of the execution for 1 seconds to let the user see the lbl_status message.
        'encapsulate the process in Try Catch to capture any exception and prevent the application from crashing due to the exception.
        Try
            Dim ExtArray() As String = New String() {".wav", ".mpeg", ".mp3", ".mp4", ".m4a", ".avi", ".wmv", ".mov", ".mpg", ".wpl", ".wma"} 'The allowed extention to be loaded
            Dim ProgSet As Boolean = False 'Used for preparing the lbl_status for the progress changed
            Dim TotalFiles As Integer = 0 : Dim CurrentCountFiles As Integer = 0 'Declaring the variable for the total number of files and the current files loaded.
            Dim progressHandler As Progress(Of String) = New Progress(Of String)('declaring the progress event handler variable.
                Sub(val) 'the process to be executed everytime the progress is changed. This will allow the user to see the current progress of the process being executed.
                    If ProgSet Then
                        If val = "COMPARE_DB" Then
                            lbl_status.Text = "Checking the database for existing data..."
                        Else
                            CurrentCountFiles = CurrentCountFiles + 1
                            lbl_status.Text = CurrentCountFiles & " of " & TotalFiles & " - " & val
                        End If

                    Else
                        TotalFiles = Integer.Parse(val)
                        ProgSet = True
                    End If
                End Sub)
            Dim progress As IProgress(Of String) = CType(progressHandler, IProgress(Of String)) 'declaring the progress variable to be used inside the asychronous function.
            Dim dt As New DataTable() : Dim clst As New List(Of String) : clst.Add("All")
            'preparing the datatable and datagridview header and column properties.
            Dim headers As New List(Of GridHeaders)()
            headers.Add(New GridHeaders() With {.index = 0, .text = "Receive", .type = GetType(String), .width = 70})
            headers.Add(New GridHeaders() With {.index = 1, .text = "Client", .type = GetType(String), .width = 60})
            headers.Add(New GridHeaders() With {.index = 2, .text = "Branch", .type = GetType(String), .width = 130})
            headers.Add(New GridHeaders() With {.index = 3, .text = "Filename", .type = GetType(String), .width = 370})
            headers.Add(New GridHeaders() With {.index = 4, .text = "Duration", .type = GetType(String), .width = 55})
            headers.Add(New GridHeaders() With {.index = 5, .text = "Directory", .type = GetType(String), .width = 100})
            headers.Add(New GridHeaders() With {.index = 6, .text = "Type", .type = GetType(String), .width = 40})
            headers.Add(New GridHeaders() With {.index = 7, .text = "IsAlreadyExist", .type = GetType(Boolean), .visible = False})
            headers.Add(New GridHeaders() With {.index = 8, .text = "Status", .type = GetType(String), .width = 60})
            headers.Add(New GridHeaders() With {.index = 9, .text = "fid", .type = GetType(Integer), .visible = False})

            'add new column to datagridview
            For Each itm As GridHeaders In headers
                dt.Columns.Add(itm.text, itm.type)
            Next

            'running the asychronous function.
            Await Task.Run(
                Sub()
                    token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                    Dim drow As DataRow
                    Dim CBFilnames As List(Of String) = New List(Of String) 'contains the combination of client, branch and filename. This will be used to filter database
                    If UseLastScan Then 'use last scan data to populate the datagridview.
                        Dim ludjson As LUData = JsonConvert.DeserializeObject(Of LUData)(LastScanData) 'deserialize the json string
                        progress.Report(ludjson.LastScanData.Count()) 'report progress and changing the value of TotalFiles.
                        For Each row As JArray In ludjson.LastScanData
                            Dim cl As String = row(1) : Dim br As String = row(2) : Dim fn As String = row(3)
                            CBFilnames.Add("'" & cl & br & fn & "'") 'this will be used for checking if data is already exist in the database.
                            progress.Report(fn) 'report progress. Showing the user the filename of the current data that is being added to the datatable and adding incrementing the CurrentCountFiles
                            dt.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)) 'adding the data to the datatable
                            ClItm.Add(row(1)) 'adding an item to the client list.
                            Sleep(100)
                        Next
                    Else 'use server data to populate the datagridview

                        Dim TopLevelFolder As New DirectoryInfo(CurrentFilesSourceDir)
                        Dim wmp As WMPLib.WindowsMediaPlayer = New WMPLib.WindowsMediaPlayer
                        Dim x As Integer = 0
                        'This for each loop will only search for the files where extension is included in ExtArray
                        For Each CurrentFile As FileInfo In TopLevelFolder.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(
                        Function(files As FileInfo)
                            Return ExtArray.Any(Function(ext As String)
                                                    Return files.Extension.ToLowerInvariant = ext
                                                End Function)
                        End Function)
                            token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                            x = x + 1
                        Next
                        progress.Report(x) 'report progress and changing the value of TotalFiles.
                        'This for each loop will only search for the files where extension is included in ExtArray
                        For Each CurrentFile As FileInfo In TopLevelFolder.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(
                        Function(files As FileInfo)
                            Return ExtArray.Any(Function(ext As String)
                                                    Return files.Extension.ToLowerInvariant = ext
                                                End Function)
                        End Function)
                            token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
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
                            dt.Rows.Add(GetDate, GetClient, GetBranch, CurrentFile.Name, cf.SecondsToTime24(media.duration), CurrentFile.FullName, FileType, False, "") 'adding data to the datatable
                            CBFilnames.Add("'" & GetClient & GetBranch & CurrentFile.Name & "'") 'this will be used for checking if data is already exist in the database.
                            ClItm.Add(GetClient) 'adding an item to the client list.
                            progress.Report(CurrentFile.Name) 'report progress. Showing the user the filename of the current data that is being added to the datatable and adding incrementing the CurrentCountFiles
                        Next
                    End If
                    Sleep(500)
                    token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                    progress.Report("COMPARE_DB") 'report progress and change lbl_status.Text.
                    'checking existing data from the database.
                    Dim chkdt As DataTable = db.query("SELECT client+branch+sFile, [status],Id FROM dbo.Main WHERE client+branch+sFile IN(" & String.Join(",", CBFilnames) & ")")
                    For Each rows As DataRow In chkdt.Rows
                        token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                        Dim row As Object() = rows.ItemArray
                        Dim IndexOfFile As Integer = CBFilnames.IndexOf("'" & row(0).ToString() & "'") 'getting the row index.
                        'changing the cell value
                        dt.Rows(IndexOfFile)(7) = True : dt.Rows(IndexOfFile)(8) = row(1).ToString() : dt.Rows(IndexOfFile)(9) = Integer.Parse(row(2).ToString())
                    Next
                End Sub)
            lbl_status.Text = "Finalizing data..."

            dgv_upload.DataSource = dt 'changing the DataSource of the datagridview.
            cbo_client.Items.AddRange(ClItm.Distinct().ToArray()) 'Removing the duplicate values of the client list and adding the values to cbo_client
            cbo_client.SelectedIndex = 0 'selecting the first value of the combobox.
            'Setting the datagridview column properties
            For Each itm As GridHeaders In headers
                dgv_upload.Columns(itm.index).Visible = itm.visible
                dgv_upload.Columns(itm.index).Width = itm.width
            Next
            'If UseLastScan is true then save last scan data to application settings.
            If Not UseLastScan Then
                Dim lud As List(Of Object()) = New List(Of Object())
                For Each row As DataGridViewRow In dgv_upload.Rows
                    Dim ludsub As List(Of Object) = New List(Of Object)
                    For Each cell As DataGridViewCell In row.Cells
                        ludsub.Add(cell.Value)
                    Next
                    lud.Add(ludsub.ToArray())
                Next
                Dim ludjson2 As LUData = New LUData
                ludjson2.LastScanData = lud.ToArray()
                Dim ludStr As String = JsonConvert.SerializeObject(ludjson2) 'convert list to Json String
                cf.AddUpdateAppSettings("LastScanData", ludStr)
            End If
            Sleep(500) 'delaying the process for 0.5 seconds to let the user see the lbl_status message.
            Filter()
            FormatDGV()

        Catch ex As Exception
            cf.Debug(ex, True, "", vbNewLine & vbNewLine & AddMsg)
        End Try
        Sleep(1000)
        dgv_upload.ClearSelection()
        lbl_status.Text = "Done!"
        EnableControls() 'Enable the controls.
        Cursor = Cursors.Default 'change the cursor of the current form to default
    End Sub
    ''' <summary>
    ''' Enable or disable controls
    ''' </summary>
    ''' <param name="b"></param>
    Private Sub EnableControls(Optional ByVal b As Boolean = True)
        dgv_upload.Enabled = b

        cbo_client.Enabled = b
        cbo_workflow.Enabled = b

        txt_filename.Enabled = b

        dtpicker_date.Enabled = b
        dtpicker_time.Enabled = b

        MenuStrip1.Enabled = b

        btn_upload.Enabled = b
    End Sub
    ''' <summary>
    ''' Asychronous function for uploading data to the database
    ''' </summary>
    Private Async Sub UploadData()
        _cancl = New CancellationTokenSource() 'instantiate new cancellation token.
        Dim token As CancellationToken = _cancl.Token 'Used for cancelling the execution when cancel token is presented.
        Cursor = Cursors.AppStarting 'change the cursor of the current form to AppStarting
        EnableControls(False) 'Disabling the controls to prevent user from interacting the controls.
        lbl_status.Text = "Preparing to upload file..."
        Sleep(1000)
        Dim DueDate As String = Format(dtpicker_date.Value, "MM/dd/yyyy")
        Dim DueTime As String = dtpicker_time.Value.ToString("HH:mm")
        Dim wflowID As Integer = Integer.Parse(cbo_workflow.SelectedValue)
        Dim wflow As String = cbo_workflow.Text
        Dim status As String = wflow.Split("-")(0)
        Dim RowIndexes As List(Of Integer) = New List(Of Integer)
        Dim CBChkList As List(Of String) = New List(Of String)

        Dim progressHandler As Progress(Of String) = New Progress(Of String)(
                Sub(val)
                    lbl_status.Text = val
                End Sub)
        Dim progress As IProgress(Of String) = CType(progressHandler, IProgress(Of String))
        Try
            Await Task.Run(
                Sub()
                    token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                    Dim QueryValues As List(Of String) = New List(Of String)
                    Dim QueryParam As List(Of String) = New List(Of String)
                    Dim FidList As List(Of Integer) = New List(Of Integer)


                    progress.Report("Preparing.")
                    Sleep(200)
                    Dim CurProgress = "Preparing." : Dim x As Integer = 1
                    'Preparing update string
                    Dim UpDateRec As String = " dateRec = Case " : Dim UpdateDue As String = " dateDue = Case "
                    Dim UptimeDue As String = " timeDue = Case " : Dim Upclient As String = " client = Case "
                    Dim Upbranch As String = " branch = Case " : Dim UpsFile As String = " sFile = Case "
                    Dim Upduration As String = " duration = Case " : Dim UpservSound As String = " servSound = Case "
                    Dim Upstat As String = " status = Case " : Dim Upactive As String = " active = Case "
                    Dim Upflow As String = " flow = Case " : Dim UpcFlow As String = " cFlow = Case "
                    Dim Upftype As String = " ftype = Case " : Dim Upwfid As String = " wfid = Case "

                    Dim CntUpdate As Integer = 0
                    For Each SelRow As DataGridViewRow In dgv_upload.SelectedRows
                        token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                        Select Case CurProgress.Length
                            Case 10
                                progress.Report("Preparing..")
                            Case 11
                                progress.Report("Preparing...")
                            Case 12
                                progress.Report("Preparing....")
                            Case 13
                                progress.Report("Preparing.....")
                            Case Else
                                progress.Report("Preparing.")
                        End Select

                        Dim DateRec As String = SelRow.Cells(0).Value
                        Dim Client As String = SelRow.Cells(1).Value
                        Dim Branch As String = SelRow.Cells(2).Value
                        Dim Filename As String = SelRow.Cells(3).Value
                        Dim Dur As String = SelRow.Cells(4).Value
                        Dim SourceDir As String = SelRow.Cells(5).Value
                        Dim FileType As String = SelRow.Cells(6).Value
                        Dim IsExist As Boolean = SelRow.Cells(7).Value

                        Dim ServSound As String = Path.Combine("FROOT\AUDIO", Branch)
                        Dim gPath As String = Path.Combine(CustomVariables.BaseServer, ServSound)
                        If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)
                        If Branch <> "" Then
                            If Not Directory.Exists(gPath) Then Directory.CreateDirectory(gPath)
                        End If

                        Dim newDir As String = Regex.Replace(SourceDir, "[/\\][/\\]+[A-Za-z0-9._%+-]+[/\\]+[A-Za-z0-9._%+-]+[/\\]", "", RegexOptions.IgnoreCase)
                        Dim serverPath As String = Path.Combine(gPath, Filename)
                        '(dateRec,dateDue,timeDue,client,branch,sFile,duration,servSound,status,active,flow,cFlow,ftype,wfid)
                        If IsExist Then
                            Dim fid As Integer = SelRow.Cells(9).Value
                            FidList.Add(fid)
                            CntUpdate = CntUpdate + 1
                            UpDateRec = UpDateRec & " WHEN Id = " & fid & " THEN @dr" & x & " "
                            UpdateDue = UpdateDue & " WHEN Id = " & fid & " THEN '" & DueDate & "' "
                            UptimeDue = UptimeDue & " WHEN Id = " & fid & " THEN '" & DueTime & "' "
                            Upclient = Upclient & " WHEN Id = " & fid & " THEN @cl" & x & " "
                            Upbranch = Upbranch & " WHEN Id = " & fid & " THEN @br" & x & " "
                            UpsFile = UpsFile & " WHEN Id = " & fid & " THEN @sf" & x & " "
                            Upduration = Upduration & " WHEN Id = " & fid & " THEN @du" & x & " "
                            UpservSound = UpservSound & " WHEN Id = " & fid & " THEN @ss" & x & " "
                            Upstat = Upstat & " WHEN Id = " & fid & " THEN '" & status & " Sched' "
                            Upactive = Upactive & " WHEN Id = " & fid & " THEN 0 "
                            Upflow = Upflow & " WHEN Id = " & fid & " THEN '" & wflow & "' "
                            UpcFlow = UpcFlow & " WHEN Id = " & fid & " THEN 0 "
                            Upftype = Upftype & " WHEN Id = " & fid & " THEN '" & FileType & "' "
                            Upwfid = Upwfid & " WHEN Id = " & fid & " THEN " & wflowID & " "
                        Else
                            QueryValues.Add("(@dr" & x & ",'" & DueDate & "','" & DueTime & "',@cl" & x & ",@br" & x & ",@sf" & x & ",@du" & x & ",@ss" & x & ",'" & status & " Sched',0,'" & wflow & "',0,'" & FileType & "'," & wflowID & ")")

                        End If
                        QueryParam.Add("dr" & x) : QueryParam.Add(DateRec)
                        QueryParam.Add("cl" & x) : QueryParam.Add(Client)
                        QueryParam.Add("br" & x) : QueryParam.Add(Branch)
                        QueryParam.Add("sf" & x) : QueryParam.Add(Filename)
                        QueryParam.Add("du" & x) : QueryParam.Add(Dur)
                        QueryParam.Add("ss" & x) : QueryParam.Add(newDir)

                        x = x + 1
                        RowIndexes.Add(SelRow.Index)
                        CBChkList.Add("'" & Client & Branch & Filename & "'")

                    Next
                    Sleep(200)
                    progress.Report("Executing the query...")
                    If CntUpdate > 0 Then
                        UpDateRec = UpDateRec & " ELSE dateRec END "
                        UpdateDue = UpdateDue & " ELSE dateDue END "
                        UptimeDue = UptimeDue & " ELSE timeDue END "
                        Upclient = Upclient & " ELSE client END "
                        Upbranch = Upbranch & " ELSE branch END "
                        UpsFile = UpsFile & " ELSE sFile END "
                        Upduration = Upduration & " ELSE duration END "
                        UpservSound = UpservSound & " ELSE servSound END "
                        Upstat = Upstat & " ELSE status END "
                        Upactive = Upactive & " ELSE active END "
                        Upflow = Upflow & " ELSE flow END "
                        UpcFlow = UpcFlow & " ELSE cFlow END "
                        Upftype = Upftype & " ELSE ftype END "
                        Upwfid = Upwfid & " ELSE wfid END "
                        Dim uqrystr As String() = New String() {UpDateRec, UpdateDue, UptimeDue, Upclient, Upbranch, UpsFile, Upduration,
                        UpservSound, Upstat, Upactive, Upflow, UpcFlow, Upftype, Upwfid}
                        db.nQuery("UPDATE dbo.Main SET " & String.Join(",", uqrystr) & " WHERE Id IN(" & String.Join(",", FidList) & ") ", QueryParam.ToArray())
                    End If
                    If QueryValues.Count > 0 Then
                        db.nQuery("INSERT INTO dbo.Main (dateRec,dateDue,timeDue,client,branch,sFile,duration,servSound,status,active,flow,cFlow,ftype,wfid)
                                VALUES " & String.Join(",", QueryValues), QueryParam.ToArray())
                    End If

                    Dim chkdt As DataTable = db.query("SELECT client+branch+sFile,[status], Id FROM dbo.Main WHERE client+branch+sFile IN(" & String.Join(",", CBChkList) & ")")
                    For Each rows As DataRow In chkdt.Rows
                        token.ThrowIfCancellationRequested() 'terminate the process if cancellation is requested
                        Dim row As Object() = rows.ItemArray
                        Dim IndexOfFile As Integer = CBChkList.IndexOf("'" & row(0).ToString() & "'")
                        Dim rowindex As Integer = RowIndexes(IndexOfFile)
                        dgv_upload.Rows(rowindex).Cells(9).Value = Integer.Parse(row(2).ToString())
                        dgv_upload.Rows(rowindex).Cells(7).Value = True
                        dgv_upload.Rows(rowindex).Cells(8).Value = status & " Sched"
                    Next
                End Sub)
            Sleep(200)
            lbl_status.Text = "Finalizing..."
            FormatDGV()
        Catch ex As Exception
            cf.Debug(ex)
        End Try

        Sleep(1000)
        lbl_status.Text = "Done!"
        EnableControls()
        Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Populate workflow combobox
    ''' </summary>
    Private Sub LoadWorkFlowDataSource()
        Try
            Dim dt As DataTable = db.query("SELECT Id,flow FROM dbo.WorkFlow")
            With cbo_workflow
                .DisplayMember = "flow" : .ValueMember = "Id" : .DataSource = dt
            End With
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Format datagridview row
    ''' </summary>
    Private Sub FormatDGV()
        For Each row As DataGridViewRow In dgv_upload.Rows
            If row.Cells(7).Value Then
                row.DefaultCellStyle.BackColor = Color.Yellow
                'row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
    End Sub
    ''' <summary>
    ''' Filter datagridview
    ''' </summary>
    Private Sub Filter()
        Dim cl As String = cbo_client.Text : Dim fn As String = txt_filename.Text
        Dim flst As List(Of String) = New List(Of String)

        If Not cf.IsStringEmpty(cl) And cl <> "ALL" Then flst.Add("Client LIKE '" & cl & "'")
        If Not cf.IsStringEmpty(fn) Then flst.Add("Filename LIKE '%" & fn & "%'")

        If Not IsNothing(dgv_upload.DataSource) Then
            Dim ds As New DataTable
            ds = dgv_upload.DataSource
            ds.DefaultView.RowFilter = String.Join(" AND ", flst.ToArray())
        End If
    End Sub

#End Region
End Class
''' <summary>
''' A class to store last 
''' </summary>
Public Class LUData
    Public Property LastScanData As Object() = New Object() {}
End Class