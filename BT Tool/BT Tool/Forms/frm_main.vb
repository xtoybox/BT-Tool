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

    Private CustomFn As New CustomFunctions()
    Private cf As New mainClass
    Private db As New markform.SQLClass
    Public locDir As String
    Private Const QuotationMark As String = """"
    Public baseLoc As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Public baseSound As String = My.Computer.FileSystem.SpecialDirectories.MyMusic
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim defaultPlayer As Integer = 1
    Public fSelect As Boolean
    Private LastRowSelected As Integer = vbNull

    Private Sub Main_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckDirectory()
        ' == For design ==

        Dashboard_pnl.Width = 213

        Settings_Pnl.Height = 0
        User_Pnl.Height = 0

        Settings_Pnl.Visible = False
        User_Pnl.Visible = False

        Me.Width = screenWidth
        Me.Height = screenHeight - 50

        Me.Location = New Point(0, 0)
        Settings_Pnl.Left = screenWidth - 245
        User_Pnl.Left = screenWidth - 307
        Me.Show()
        frm_login.ShowDialog(Me)
        ' if main panel clicked hide all dropdowns 

    End Sub

    ''' <summary>
    ''' some pc's use are not able to connect on the default accomediasvr and vice versa.
    ''' </summary>
    Sub CheckDirectory()

        'create folder in mydocuments 
        Dim btDir As String = Path.Combine(baseLoc, "BT Tool Documents")
        If Not Directory.Exists(btDir) Then Directory.CreateDirectory(btDir)
        Dim di As New DirectoryInfo(btDir)
        'If ((di.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden) Then File.SetAttributes(btDir, FileAttributes.Hidden)

        If Not Directory.Exists(Path.Combine(btDir, "BT")) Then Directory.CreateDirectory(Path.Combine(btDir, "BT"))
        If Not Directory.Exists(Path.Combine(btDir, "PR")) Then Directory.CreateDirectory(Path.Combine(btDir, "PR"))
        If Not Directory.Exists(Path.Combine(btDir, "TS")) Then Directory.CreateDirectory(Path.Combine(btDir, "TS"))
        If Not Directory.Exists(Path.Combine(btDir, "CC")) Then Directory.CreateDirectory(Path.Combine(btDir, "CC"))
        If Not Directory.Exists(Path.Combine(btDir, "ST")) Then Directory.CreateDirectory(Path.Combine(btDir, "ST"))
        If Not Directory.Exists(Path.Combine(btDir, "AUDITOR")) Then Directory.CreateDirectory(Path.Combine(btDir, "AUDITOR"))

        If Directory.Exists("\\ACC-TEST-SQL\Users") Then
            varMod.BaseServer = "\\ACC-TEST-SQL\Users\admin\Desktop"
        ElseIf Directory.Exists("\\172.16.3.65\Users") Then
            varMod.BaseServer = "\\172.16.3.65\Users\admin\Desktop"
        Else
            MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

        'If rdMain.Checked Then
        '    If Directory.Exists("\\accomediasvr\MediaFiles-2") Then
        '        varMod.BaseServer = "\\accomediasvr\MediaFiles-2"
        '    ElseIf Directory.Exists("\\172.16.3.54\MediaFiles-2") Then
        '        varMod.BaseServer = "\\172.16.3.54\MediaFiles-2"
        '    Else
        '        MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    End If
        'ElseIf rdTest.Checked Then
        '    If Directory.Exists("\\ACC-TEST-SQL\Users\admin\Desktop") Then
        '        varMod.BaseServer = "\\ACC-TEST-SQL\Users\admin\Desktop"
        '    ElseIf Directory.Exists("\\172.16.3.65\Users\admin\Desktop") Then
        '        varMod.BaseServer = "\\172.16.3.65\Users\admin\Desktop"
        '    Else
        '        MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    End If
        'End If


        'If Directory.Exists("\\accomediasvr\MediaFiles-2\FROOT") Then
        '    varMod.BaseServer = "\\accomediasvr\MediaFiles-2\FROOT"
        'ElseIf Directory.Exists("\\172.16.3.54\MediaFiles-2\FROOT") Then
        '    varMod.BaseServer = "\\172.16.3.54\MediaFiles-2\FROOT"
        'Else
        '    MessageBox.Show("System cannot connect to server." & vbCrLf & "Contact your System Administrator.", "Connection issue to server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        '    End
        'End If
    End Sub

    ''' <summary>
    ''' populate the main gridview depending on the user logged in
    ''' </summary>
    Public Sub fillMain()
        Dim i As Long
        Try
            Me.Cursor = Cursors.AppStarting
            'db.SQLDependency(False)
            'RemoveHandler db.OnNewMessage, AddressOf OnNewMessage
            'populate main window DGV depening on user deparment/position

            Dim newDt As New Data.DataTable
            Dim dt As New Data.DataTable
            Dim selRow As Long = 0
            Dim whereClause As String = "status=@status"
            Dim bind() As String = New String() {}

            If Not IsNothing(Me.main_gridview.CurrentRow) Then
                selRow = Me.main_gridview.SelectedRows(0).Cells(0).Value
            End If

            'Console.writeline("fillmain: " & varMod.CurUserDep)

            Select Case varMod.CurUserPos
                Case "admin", "it", "opsup"
                    whereClause = ""
                Case "ts"
                    whereClause = "status NOT IN ('done','for audit','archive')"
                Case "sched"
                    Select Case varMod.CurUserDep
                        Case "bt"
                            whereClause = "status IN ('BT Sched','for bt', 'for bt qa')"
                        Case "pr"
                            whereClause = "status In ('PR Sched','for bt','for pr', 'for bt qa', 'for pr qa')"
                        Case "bet"
                            whereClause = "status IN ('" & varMod.uDept & " Sched','for " & varMod.uDept & "', 'for " & varMod.uDept & " qa' )"
                    End Select
                Case "prod"
                    'whereClause = "(status=@status AND " & varMod.uDept & " = @uid) OR (qa" & varMod.uDept & " = CASE status WHEN 'for " & varMod.uDept & " qa' THEN @uid ELSE NULL END)"
                    'bind = New String() {"status", "for " & varMod.uDept, "uid", varMod.uid}
                    'db.bind("status", "for " & varMod.uDept)

                    whereClause = "( " & varMod.uDept & " = @uid OR qa" & varMod.uDept & " = @uid)"
                    bind = New String() {"uid", varMod.uid}'{varMod.uDept, "uid", varMod.uid}

                Case "auditor"
                    bind = New String() {"status", "For ts"}
            'db.bind("status", "For ts")
                Case "tl"
                    Select Case varMod.CurUserDep
                        Case "bt"
                            whereClause = "status IN ('BT Sched','for bt')"
                        Case "pr"
                            whereClause = "status In ('PR Sched','for pr')"
                        Case "bet"
                            whereClause = "status IN ('" & varMod.uDept & " Sched','for " & varMod.uDept & "', 'for " & varMod.uDept & " qa')"
                    End Select
            End Select

            Dim additionalWhere As String = ""
            If varMod.Btwork = True Then
                additionalWhere = " OR (bt = " & varMod.uid & " AND status LIKE 'For BT')"
            End If

            If whereClause IsNot "" Then
                whereClause = "WHERE " & whereClause & additionalWhere
            End If
            'Console.writeline(whereClause)

            '0-15
            '16-17
            '18-19
            '20-21
            '22-23
            '24-31
            '32-39
            dt = db.query("SELECT Id,prio,rush,dateRec,dateServ,dateDue,client,branch,sFile,servSound,locSound,duration,wFile,servDoc,locDoc,page, 
                (SELECT username FROM dbo.UserData WHERE Id = bt) AS btname,(SELECT username FROM dbo.UserData WHERE Id = qabt) AS qabtname,
                (SELECT username FROM dbo.UserData WHERE Id = pr) AS prname,(SELECT username FROM dbo.UserData WHERE Id = qapr) AS qaprname,
                (SELECT username FROM dbo.UserData WHERE Id = st) AS stname,(SELECT username FROM dbo.UserData WHERE Id = qast) AS qastname,
                (SELECT username FROM dbo.UserData WHERE Id = cc) AS ccname,(SELECT username FROM dbo.UserData WHERE Id = qacc) AS qaccname,
                bt,qabt,pr,qapr,st,qast,cc,qacc,
                accuracy,status,flow,cFlow,active,retFile,retDirectory,activeUser,timeDue,onhold,blank FROM dbo.Main " & whereClause & "
                ORDER BY CASE rush WHEN 1 THEN 0 ELSE 1 END,CASE WHEN dateDue IS NULL THEN 1 ELSE 0 END, CAST(dateDue AS date),
                CASE WHEN timeDue IS NULL THEN 1 ELSE 0 END,CAST(timeDue AS time)", bind)


            Dim ColField() As String = New String() {"id", "Prio", "Blank", "Rush", "Receive", "Service", "Due", "Client", "Branch", "Soundfile", "servSound", "locSound",'11
            "Duration", "wFile", "servDoc", "servLoc", "Page",'16
            "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC",'24
            "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid",'32
            "Accuracy", "Status", "Workflow", "Current Flow", "Active", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"} '42

            '***************************************************
            Dim headers As New List(Of GridHeaders)() : Dim colIndex As Integer = 0
            For Each col As String In ColField
                Dim colType As Type = GetType(String) : Dim colVisible As Boolean = True
                'Set the column type of specific columns
                If New String() {"Prio", "Rush", "Active", "isHold", "Blank"}.Contains(col) Then colType = GetType(Boolean)
                If New String() {"Current Flow"}.Contains(col) Then colType = GetType(Integer)
                'Set the visibility of the specific columns
                If New String() {"id", "Prio", "servSound", "locSound", "wFile", "servDoc", "servLoc", "btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid", "Accuracy",
                "Workflow", "retFile", "retDirectory", "activeUser", "rowEnabled"}.Contains(col) Then colVisible = False

                Dim colVFalse() As String = New String() {} : Dim colVTrue() As String = New String() {}
                Select Case varMod.CurUserPos
                    Case "admin"
                        colVFalse = New String() {}
                        colVTrue = New String() {"Receive", "Page", "BT", "QA BT", "PR", "QA PR"}
                    Case "prod"
                        colVFalse = New String() {"Receive", "servLoc", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "btid", "qabtid", "prid", "qaprid", "stid",
                        "qastid", "ccid", "qaccid", "Accuracy", "Active", "retFile"}
                        colVTrue = New String() {}
                    Case "sched"
                        Select Case varMod.CurUserDep
                            Case "bt"
                                colVFalse = New String() {"PR", "QA PR", "S&T", "QA ST", "CC", "QA CC"}
                                colVTrue = New String() {"Page", "BT", "QA BT"}
                            Case "pr"
                                colVFalse = New String() {"Page", "S&T", "QA ST", "CC", "QA CC"}
                                colVTrue = New String() {"BT", "QA BT", "PR", "QA PR"}
                            Case "bet"
                                colVFalse = New String() {"Page", "BT", "QA BT", "PR", "QA PR"}
                                If varMod.uDept = "st" Then
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
                If New String() {"Receive", "Service", "Duration", "Current Flow"}.Contains(col) Then colW = 75
                If New String() {"Rush", "Page", "BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC", "Status", "Active", "Blank", "isHold"}.Contains(col) Then colW = 50

                headers.Add(New GridHeaders() With {.index = colIndex, .text = col, .type = colType, .visible = colVisible, .width = colW})

                colIndex = colIndex + 1
            Next

            For Each itm As GridHeaders In headers
                newDt.Columns.Add(itm.text, itm.type)
            Next
            '***************************************************
            Dim rowIndex As Integer = 0


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
                Dim rowEnabled As String = "" : Dim rowInclude As Boolean = True
                Dim isHold As Boolean = Boolean.Parse(row(41))
                'If rowIndex > 0 And New String() {"prod"}.Contains(varMod.CurUserPos) Then rowEnabled = "NOT YET"
                If varMod.CurUserPos = "prod" Then
                    If rowIndex > 0 Then rowEnabled = "NOT YET"
                    If isHold And rowIndex > 0 Then rowEnabled = "NOT YET"

                    Dim WorkFlowArray() As String = row(34).ToString.Split("-")
                    Dim CurUserFlowAssigned As Integer = 0

                    Select Case varMod.uid
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
                        'check file status
                        If row(33).ToString().ToLower() = "for " & varMod.uDept.ToLower() & " qa" Then
                            rowInclude = New Integer() {Integer.Parse(row(25)), Integer.Parse(row(27)), Integer.Parse(row(29)), Integer.Parse(row(31))}.Contains(varMod.uid)
                        End If

                    End If
                    If Integer.Parse(row(35)) < CurUserFlowAssigned Then
                        rowEnabled = "WORKFLOW"
                    End If
                    If Integer.Parse(row(35)) = CurUserFlowAssigned Then
                        'rowEnabled = "WORKFLOW"
                        'check file status
                        Select Case row(33).ToString().ToLower()
                            Case "for bt"
                                If Integer.Parse(row(24)) <> varMod.uid Then rowEnabled = "PROD"
                            Case "for pr"
                                If Integer.Parse(row(26)) <> varMod.uid Then rowEnabled = "PROD"
                            Case "for cc"
                                If Integer.Parse(row(30)) <> varMod.uid Then rowEnabled = "PROD"
                            Case "for st"
                                If Integer.Parse(row(28)) <> varMod.uid Then rowEnabled = "PROD"
                            Case "for bt qa"
                                If Integer.Parse(row(25)) <> varMod.uid Then rowInclude = False
                            Case "for pr qa"
                                If Integer.Parse(row(27)) <> varMod.uid Then rowInclude = False
                            Case "for st qa"
                                If Integer.Parse(row(29)) <> varMod.uid Then rowInclude = False
                            Case "for cc qa"
                                If Integer.Parse(row(31)) <> varMod.uid Then rowInclude = False
                        End Select
                    End If
                End If
                '****************************

                '{"id", "Prio", "Blank", "Rush", "Receive", "Service", "Due", "Client", "Branch", "Soundfile", "servSound", "locSound",'11
                '"Duration", "wFile", "servDoc", "servLoc", "Page",'16
                '"BT", "QA BT", "PR", "QA PR", "S&T", "QA ST", "CC", "QA CC",'24
                '"btid", "qabtid", "prid", "qaprid", "stid", "qastid", "ccid", "qaccid",'32
                '"Accuracy", "Status", "Workflow", "Current Flow", "Active", "retFile", "retDirectory", "activeUser", "rowEnabled", "isHold"} '42

                'Console.WriteLine(row(0) & " | " & row(35))
                If rowInclude Then
                    newDt.Rows.Add(row(0), row(1), row(42), row(2), row(3), row(4), row(5) & " " & convertedTime, row(6), row(7), row(8), row(9),
                            row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), row(18), row(19),
                            row(20), row(21), row(22), row(23), row(24), row(25), row(26), row(27), row(28), row(29),
                            row(30), row(31), row(32), row(33), row(34), Integer.Parse(row(35)), row(36), row(37), row(38), row(39),
                            rowEnabled, isHold)
                    rowIndex = rowIndex + 1
                End If
                'Console.WriteLine(row(34))

            Next


            main_gridview.DataSource = newDt
            For Each itm As GridHeaders In headers
                main_gridview.Columns(itm.index).Width = itm.width
                main_gridview.Columns(itm.index).Visible = itm.visible
                main_gridview.Columns(itm.index).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            'Console.writeline("fillmain: " & Me.main_gridview.Rows.Count)
            CustomFn.RowsNumber(main_gridview)
            'If Me.dgv1.Rows.Count <> 0 Then
            For Each row As DataGridViewRow In Me.main_gridview.Rows
                i = i + 1
                Debug.Print(row.Cells(0).Value.ToString)
                If row.Cells(0).Value.ToString = selRow Then
                    Dim index As Integer = row.Index
                    row.Selected = True 'either this or the bottom line would work
                    Me.main_gridview.Rows(row.Index).Selected = True
                End If

                If row.Cells(42).Value Then 'check if on hold
                    row.DefaultCellStyle.BackColor = Color.DarkRed
                    row.DefaultCellStyle.ForeColor = Color.White
                End If

                If Not cf.isStringEmpty(row.Cells(41).Value.ToString()) Then 'check if row is enabled
                    row.DefaultCellStyle.ForeColor = Color.Gray
                End If
            Next
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
            Console.WriteLine(i)
        End Try

        'main_gridview.Sort(main_gridview.Columns(5), System.ComponentModel.ListSortDirection.Ascending)

        Me.Cursor = Cursors.Default
        'End If
    End Sub

    Sub hidedropdowns()

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            btn_myeval.ImageAlign = ContentAlignment.MiddleCenter
            btn_file_eval.ImageAlign = ContentAlignment.MiddleCenter
            btn_monitoring.ImageAlign = ContentAlignment.MiddleCenter
            btn_viewreturn.ImageAlign = ContentAlignment.MiddleCenter
            btn_flagging.ImageAlign = ContentAlignment.MiddleCenter
            btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_idle_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_wait_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_files_due.ImageAlign = ContentAlignment.MiddleCenter
            btn_userlist.ImageAlign = ContentAlignment.MiddleCenter
            btn_workflow.ImageAlign = ContentAlignment.MiddleCenter

            btn_myeval.Text = ""
            btn_file_eval.Text = ""
            btn_monitoring.Text = ""
            btn_viewreturn.Text = ""
            btn_flagging.Text = ""
            btn_ratio_tracker.Text = ""
            btn_idle_tracker.Text = ""
            btn_wait_tracker.Text = ""
            btn_files_due.Text = ""
            btn_userlist.Text = ""
            btn_workflow.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If
        Exit Sub
    End Sub

    Private Sub Burgermenu_btn_Click(sender As Object, e As EventArgs) Handles Burgermenu_btn.Click

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            btn_myeval.ImageAlign = ContentAlignment.MiddleCenter
            btn_file_eval.ImageAlign = ContentAlignment.MiddleCenter
            btn_monitoring.ImageAlign = ContentAlignment.MiddleCenter
            btn_viewreturn.ImageAlign = ContentAlignment.MiddleCenter
            btn_flagging.ImageAlign = ContentAlignment.MiddleCenter
            btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_idle_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_wait_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_files_due.ImageAlign = ContentAlignment.MiddleCenter
            btn_userlist.ImageAlign = ContentAlignment.MiddleCenter
            btn_workflow.ImageAlign = ContentAlignment.MiddleCenter

            btn_myeval.Text = ""
            btn_file_eval.Text = ""
            btn_monitoring.Text = ""
            btn_viewreturn.Text = ""
            btn_flagging.Text = ""
            btn_ratio_tracker.Text = ""
            btn_idle_tracker.Text = ""
            btn_wait_tracker.Text = ""
            btn_files_due.Text = ""
            btn_userlist.Text = ""
            btn_workflow.Text = ""


            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        ElseIf Dashboard_pnl.Width = 50 Then

            BunifuTransition3.HideSync(Dashboard_pnl)

            btn_myeval.ImageAlign = ContentAlignment.MiddleLeft
            btn_file_eval.ImageAlign = ContentAlignment.MiddleLeft
            btn_monitoring.ImageAlign = ContentAlignment.MiddleLeft
            btn_viewreturn.ImageAlign = ContentAlignment.MiddleLeft
            btn_flagging.ImageAlign = ContentAlignment.MiddleLeft
            btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleLeft
            btn_idle_tracker.ImageAlign = ContentAlignment.MiddleLeft
            btn_wait_tracker.ImageAlign = ContentAlignment.MiddleLeft
            btn_files_due.ImageAlign = ContentAlignment.MiddleLeft
            btn_userlist.ImageAlign = ContentAlignment.MiddleLeft
            btn_workflow.ImageAlign = ContentAlignment.MiddleLeft

            btn_myeval.Text = "My Evaluation"
            btn_file_eval.Text = "File Evaluation"
            btn_monitoring.Text = "Monitoring"
            btn_viewreturn.Text = "View Return"
            btn_flagging.Text = "Flagging"
            btn_ratio_tracker.Text = "Ratio Tracker"
            btn_idle_tracker.Text = "Idle Tracker"
            btn_wait_tracker.Text = "Wait Tracker"
            btn_files_due.Text = "Files Due"
            btn_userlist.Text = "User List"
            btn_workflow.Text = "Workflow"

            Dashboard_pnl.Width = 213
            BunifuTransition2.ShowSync(Dashboard_pnl)

        End If

    End Sub
    Private Sub Main_form_Click(sender As Object, e As EventArgs) Handles Me.Click
        hidedropdowns()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles main_gridview.CellContentClick
        hidedropdowns()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles main_gridview.CellClick
        hidedropdowns()
    End Sub

    Private Sub Main_pnl_Click(sender As Object, e As EventArgs) Handles Main_pnl.Click
        hidedropdowns()
    End Sub

    Private Sub Settings_btn_LostFocus(sender As Object, e As EventArgs)

        'hidedropdowns()
    End Sub

    Private Sub Burgermenu_btn_LostFocus(sender As Object, e As EventArgs) Handles Burgermenu_btn.LostFocus
        'hidedropdowns()
    End Sub

    Private Sub User_Btn_Click(sender As Object, e As EventArgs) Handles User_Btn.Click
        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            btn_myeval.ImageAlign = ContentAlignment.MiddleCenter
            btn_file_eval.ImageAlign = ContentAlignment.MiddleCenter
            btn_monitoring.ImageAlign = ContentAlignment.MiddleCenter
            btn_viewreturn.ImageAlign = ContentAlignment.MiddleCenter
            btn_flagging.ImageAlign = ContentAlignment.MiddleCenter
            btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_idle_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_wait_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_files_due.ImageAlign = ContentAlignment.MiddleCenter
            btn_userlist.ImageAlign = ContentAlignment.MiddleCenter
            btn_workflow.ImageAlign = ContentAlignment.MiddleCenter

            btn_myeval.Text = ""
            btn_file_eval.Text = ""
            btn_monitoring.Text = ""
            btn_viewreturn.Text = ""
            btn_flagging.Text = ""
            btn_ratio_tracker.Text = ""
            btn_idle_tracker.Text = ""
            btn_wait_tracker.Text = ""
            btn_files_due.Text = ""
            btn_userlist.Text = ""
            btn_workflow.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        Else

            User_Pnl.Height = 200
            BunifuTransition1.ShowSync(User_Pnl)

        End If
    End Sub

    Private Sub Settings_Btn_Click(sender As Object, e As EventArgs) Handles Settings_Btn.Click
        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            btn_myeval.ImageAlign = ContentAlignment.MiddleCenter
            btn_file_eval.ImageAlign = ContentAlignment.MiddleCenter
            btn_monitoring.ImageAlign = ContentAlignment.MiddleCenter
            btn_viewreturn.ImageAlign = ContentAlignment.MiddleCenter
            btn_flagging.ImageAlign = ContentAlignment.MiddleCenter
            btn_ratio_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_idle_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_wait_tracker.ImageAlign = ContentAlignment.MiddleCenter
            btn_files_due.ImageAlign = ContentAlignment.MiddleCenter
            btn_userlist.ImageAlign = ContentAlignment.MiddleCenter
            btn_workflow.ImageAlign = ContentAlignment.MiddleCenter

            btn_myeval.Text = ""
            btn_file_eval.Text = ""
            btn_monitoring.Text = ""
            btn_viewreturn.Text = ""
            btn_flagging.Text = ""
            btn_ratio_tracker.Text = ""
            btn_idle_tracker.Text = ""
            btn_wait_tracker.Text = ""
            btn_files_due.Text = ""
            btn_userlist.Text = ""
            btn_workflow.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        Else

            Settings_Pnl.Height = 200
            BunifuTransition1.ShowSync(Settings_Pnl)

        End If
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        End
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btn_loginout.Click

        Me.Enabled = False
        Me.TopMost = True
        Me.Location = New Point(0, 0)
        frm_logout.Show()
        frm_logout.TopMost = True

    End Sub

    Private Sub Exit_btn_MouseHover(sender As Object, e As EventArgs) Handles Exit_btn.MouseHover
        Exit_btn.BackColor = Color.Red
    End Sub

    Private Sub Exit_btn_MouseLeave(sender As Object, e As EventArgs) Handles Exit_btn.MouseLeave
        Exit_btn.BackColor = Color.Black
    End Sub

    ''' <summary>
    ''' populate combobox
    ''' </summary>
    Sub fillCombo()
        Try
            db.SQLDependency(False)
            'fill combobox with usernames
            Dim dt As DataTable = db.query("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,uDept,department,btwork,position FROM dbo.UserData WHERE deactivated = 0 ORDER BY department,username")
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
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
        End Try

    End Sub


    ''' <summary>
    ''' opens audio file/audio directory(for cc)
    ''' </summary>
    Private Sub btn_Audio_Click(sender As Object, e As EventArgs) Handles btn_Audio.Click

        Try
            If Me.txt_audio.Text <> "" Then
                'markDBOClass.SQLClass.conStr = "this value"
                Dim soundName As String = Me.txt_audio.Text
                Dim servSound As String = Path.Combine(varMod.BaseServer, varMod.servSound)
                Dim deskDir As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, varMod.userName, varMod.client)
                'copy sound from server directory to local directory

                Dim locSound As String = Path.Combine(baseSound, soundName)

                If varMod.uDept = "cc" Then
                    If Not Directory.Exists(deskDir) Then
                        Directory.CreateDirectory(deskDir)
                    End If

                    'Me.lbl_status.Text = "Copying File, please wait"
                    File.Copy(servSound, Path.Combine(deskDir, varMod.sFile))
                    Process.Start(deskDir)
                    'Me.lbl_status.Text = "Done"
                Else
                    If File.Exists(locSound) Then
                        'file exists
                        'if server size <> user size then overwrite
                        Dim sInfo As New FileInfo(servSound)
                        Dim lInfo As New FileInfo(locSound)

                        If sInfo.Length <> lInfo.Length Then
                            'Me.lbl_status.Text = "Copying File, please wait"
                            File.Copy(servSound, locSound, True)
                            'Me.lbl_status.Text = "Done"
                        End If
                    Else
                        'file does not exist in local directory
                        Try
                            'Me.lbl_status.Text = "Copying File, please wait"
                            File.Copy(servSound, locSound, True)
                            'Me.lbl_status.Text = "Done"
                        Catch ex As Exception
                            Console.WriteLine(ex.Message)
                            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    End If
                    'frm_playerselect.locDir = locSound
                    'frm_playerselect.Show()
                    startPlayer()

                End If
            End If
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
        End Try
    End Sub

    Private Sub btn_Doc_Click(sender As Object, e As EventArgs) Handles btn_Doc.Click

    End Sub

    Private Sub rd_express_CheckedChanged(sender As Object, e As EventArgs) Handles rd_express.CheckedChanged, rd_acqt.CheckedChanged, rd_pepsup.CheckedChanged

        If rd_express.Checked Then
            defaultPlayer = 1
        ElseIf rd_pepsup.Checked Then
            defaultPlayer = 2
        ElseIf rd_acqt.Checked Then
            defaultPlayer = 3
        End If

    End Sub

    Sub startPlayer()

        Select Case defaultPlayer
            Case 1
                'use express scribe
                Dim P As New ProcessStartInfo
                P.FileName = "C:\Program Files (x86)\NCH Swift Sound\Scribe\scribe.exe"
                If IO.File.Exists(P.FileName) = False And InStr(P.FileName, "x86") = 0 Then
                    P.FileName = "C:\Program Files\NCH Swift Sound\Scribe\scribe.exe"
                End If

                Try
                    P.Arguments = QuotationMark & locDir & QuotationMark
                    Process.Start(P)
                    Me.Close()
                Catch
                    MsgBox("Unable to find Express Scribe. Please open file manually.")
                    Process.Start(locDir)
                End Try
            Case 2
                'use people support
                Dim P As New ProcessStartInfo
                P.FileName = "C:\Program Files (x86)\PeopleSupport\TMS\RTMMPlayer.exe"
                If IO.File.Exists(P.FileName) = False And InStr(P.FileName, "x86") = 0 Then
                    P.FileName = "C:\Program Files\PeopleSupport\TMS\RTMMPlayer.exe"
                End If
                Try
                    P.Arguments = QuotationMark & locDir & QuotationMark
                    Process.Start(P)
                    Me.Close()
                Catch
                    MsgBox("Unable to find PeopleSupport Multimedia Player. Please open file manually.")
                    Process.Start(locDir)
                End Try
            Case 3
                'Dim p As New ProcessStartInfo
                'p.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\ftsu2.exe"
                'p.Arguments = QuotationMark & locDir & QuotationMark
                'If IO.File.Exists(p.FileName) = False Then
                '    MsgBox("ARI Player not found.", vbCritical, "ARI Media Player")
                '    Process.Start(locDir)
                '    Exit Sub
                'End If
                'Try
                '    Process.Start(p)
                '    Me.Close()
                'Catch
                '    MessageBox.Show(Err.Description, "ARI Media Player", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Process.Start(locDir)
                'End Try
        End Select
    End Sub

    Private Sub main_gridview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles main_gridview.CellDoubleClick
        Try
            If e.RowIndex <> -1 And e.ColumnIndex <> -1 Then
                '***********************************************************
                Dim dgv As DataGridView = CType(sender, DataGridView)
                Dim SelectedRow As DataGridViewRow = dgv.SelectedRows(0)
                If Not cf.isStringEmpty(SelectedRow.Cells(41).Value.ToString()) Then
                    Dim m As String = ""
                    If SelectedRow.Cells(41).Value.ToString() = "NOT YET" Then
                        Dim topfile As String = dgv.Rows(0).Cells(9).Value.ToString()
                        m = "You can't start on this file yet. " & vbNewLine & "Submit [" & topfile & "] first."
                    ElseIf SelectedRow.Cells(41).Value.ToString() = "WORKFLOW" Then
                        m = "You can't start this file yet since the previous workflow is not done yet."
                    ElseIf SelectedRow.Cells(41).Value.ToString = "PROD" Then
                        m = "You can't start on this file yet. It is currently being work by the production assigned on it."
                    Else
                        m = "You can't start this file since it is already being passed to the QA."
                    End If
                    MessageBox.Show(Me, m, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim msg As String = ""

                If main_gridview.SelectedRows(0).Cells(42).Value Then
                    Dim isPass As Boolean = True
                    For Each row As DataGridViewRow In main_gridview.Rows
                        If main_gridview.SelectedRows(0).Index <> row.Index And row.Cells(37).Value And Integer.Parse(row.Cells(40).Value.ToString()) = varMod.uid Then
                            Dim curfile As String = row.Cells(9).Value.ToString()
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
                '***********************************************************

                'If Me.main_gridview.SelectedRows(0).Cells(40).Value = varMod.uid Or Me.main_gridview.SelectedRows(0).Cells(40).Value = 0 Then

                If varMod.CurUserPos.ToLower = "prod" Then
                    Dim rushCount As Integer = 0

                    For Each row As DataGridViewRow In Me.main_gridview.Rows
                        If CInt(row.Cells(3).Value) = True Then
                            rushCount += 1
                        End If
                    Next

                    If Me.main_gridview.SelectedRows(0).Cells(3).Value <> True And rushCount <> 0 Then
                        If rushCount <> 0 Then MessageBox.Show("You still have " & rushCount & " rush file(s).", "Rush found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                    End If

                End If


                'file selection
                Dim maingrid As DataGridView = sender
                Dim gActive As Integer
                Dim selRow As Integer = Me.main_gridview.SelectedRows(0).Cells(0).Value

                If Not varMod.CurUserPos Like "sched" Then
                    db.nQuery("UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & selRow, New String() {"activeUser", varMod.uid, "active", "True"})
                    maingrid(37, e.RowIndex).Value = True
                    'Me.main_gridview.SelectedRows(0).Cells(36).Value = True
                End If

                fSelect = True
                '35-'38
                If varMod.fId <> selRow Then

                    '0"id", 1"Prio", 2"Blank", 3"Rush", 4"Receive", 5"Service", 6"Due", 7"Client", 8"Branch", 9"Soundfile", 10"servSound", 11"locSound",'
                    '"12Duration", 13"wFile", 14"servDoc", 15"servLoc", 16Page",'
                    '"17BT", 18"QA BT", 19"PR", 20"QA PR", 21"S&T", 22"QA ST", 23"CC", "QA CC",'24
                    '"25btid", 26"qabtid", 27"prid", 28"qaprid", 29"stid", 30"qastid", 31"ccid", "qaccid",'32
                    '"33Accuracy", 34"Status", 35"Workflow", 36"Current Flow", 37"Active", 38"ret   File", 39"retDirectory", 40"activeUser", 41"rowEnabled", "isHold"} '42

                    If Me.main_gridview.Rows.Count <> 0 Then

                        Me.chk_blank.Checked = Me.main_gridview.SelectedRows(0).Cells(2).Value
                        Me.chk_rush.Checked = Me.main_gridview.SelectedRows(0).Cells(3).Value
                        Me.txt_receive.Text = Me.main_gridview.SelectedRows(0).Cells(4).Value.ToString
                        Me.cbo_service.Text = Me.main_gridview.SelectedRows(0).Cells(5).Value.ToString
                        Me.txt_due.Text = Me.main_gridview.SelectedRows(0).Cells(6).Value.ToString
                        Me.txt_client.Text = Me.main_gridview.SelectedRows(0).Cells(7).Value.ToString
                        Me.txt_branch.Text = Me.main_gridview.SelectedRows(0).Cells(8).Value.ToString
                        Me.txt_audio.Text = Me.main_gridview.SelectedRows(0).Cells(9).Value.ToString
                        Me.txt_duration.Text = Me.main_gridview.SelectedRows(0).Cells(12).Value.ToString
                        Me.txt_document.Text = Me.main_gridview.SelectedRows(0).Cells(13).Value.ToString

                        Select Case varMod.CurUserPos
                            Case "admin", "ts", "auditor"
                                Me.txt_page.Text = Me.main_gridview.SelectedRows(0).Cells(16).Value.ToString
                                Me.cbo_bt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(25).Value
                                Me.cbo_pr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(27).Value
                                Me.cbo_st.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(29).Value
                                Me.cbo_cc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(31).Value
                                Me.cbo_qabt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(26).Value
                                Me.cbo_qapr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(28).Value
                                Me.cbo_qast.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(30).Value
                                Me.cbo_qacc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(32).Value
                            Case "sched"
                                Me.txt_page.Text = Me.main_gridview.SelectedRows(0).Cells(16).Value.ToString

                                Select Case varMod.CurUserDep
                                    Case "bt"
                                        Me.cbo_bt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(25).Value
                                        Me.cbo_qabt.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(26).Value
                                    Case "pr"
                                        Me.cbo_pr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(27).Value
                                        Me.cbo_qapr.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(28).Value
                                    Case "bet"
                                        If varMod.uDept = "st" Then
                                            Me.cbo_st.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(29).Value
                                            Me.cbo_qast.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(30).Value
                                        ElseIf varMod.uDept = "cc" Then
                                            Me.cbo_cc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(31).Value
                                            Me.cbo_qacc.SelectedValue = Me.main_gridview.SelectedRows(0).Cells(32).Value
                                        End If
                                End Select
                        End Select
                    End If

                    varMod.recDate = Me.main_gridview.SelectedRows(0).Cells(4).Value.ToString
                    varMod.client = Me.main_gridview.SelectedRows(0).Cells(7).Value.ToString
                    varMod.branch = Me.main_gridview.SelectedRows(0).Cells(8).Value.ToString
                    varMod.sFile = Me.main_gridview.SelectedRows(0).Cells(9).Value.ToString
                    varMod.servSound = Me.main_gridview.SelectedRows(0).Cells(10).Value.ToString
                    varMod.docName = Me.main_gridview.SelectedRows(0).Cells(13).Value.ToString
                    varMod.servDoc = Me.main_gridview.SelectedRows(0).Cells(14).Value.ToString
                    varMod.btid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(25).Value)
                    varMod.prid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(27).Value)
                    varMod.qaprid = Integer.Parse(Me.main_gridview.SelectedRows(0).Cells(28).Value)
                    varMod.cFlow = Me.main_gridview.SelectedRows(0).Cells(36).Value
                    varMod.returnStat = Me.main_gridview.SelectedRows(0).Cells(38).Value
                    varMod.retDirectory = Me.main_gridview.SelectedRows(0).Cells(39).Value.ToString

                    For i = 0 To Me.main_gridview.Columns.Count - 1
                        Console.WriteLine(i & " = " & Me.main_gridview.SelectedRows(0).Cells(i).Value & " | " & Me.main_gridview.Columns(i).Name & " | " & Me.main_gridview.SelectedRows(0).Cells(i).Value.GetType.ToString())
                    Next
                    Console.WriteLine(Me.main_gridview.SelectedRows(0).Cells(0).Value & " | " & Me.main_gridview.SelectedRows(0).Cells(36).Value & " | " & Me.main_gridview.Columns(36).Name)

                    varMod.flow = Me.main_gridview.SelectedRows(0).Cells(35).Value.ToString
                    'cFlow = Me.main_gridview.SelectedRows(0).Cells(36).Value

                    'QA users
                    If varMod.CurUserPos = "prod" Then
                        If varMod.uDept = "bt" Then
                            varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(26).Value
                        ElseIf varMod.uDept = "pr" Then
                            varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(28).Value
                        ElseIf varMod.uDept = "st" Then
                            varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(30).Value
                        ElseIf varMod.uDept = "cc" Then
                            varMod.qauserid = Me.main_gridview.SelectedRows(0).Cells(32).Value
                        End If
                    End If


                    db.nQuery("UPDATE dbo.Main SET activeUser=@activeUser,active=@active WHERE Id=" & varMod.fId, New String() {"activeUser", 0, "active", "False"})
                    Dim rindex As Integer = e.RowIndex
                    If LastRowSelected <> vbNull Then rindex = LastRowSelected
                    maingrid(36, rindex).Value = False
                    'maingrid(24, varMod.fId).Value = False
                    If LastRowSelected <> vbNull Then LastRowSelected = e.RowIndex
                End If

                varMod.fId = Me.main_gridview.SelectedRows(0).Cells(0).Value

                fillMain()
                'End If
            End If
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
        End Try
    End Sub

    Private Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        frm_upload.Show()
    End Sub

    Private Sub User_Btn_LostFocus(sender As Object, e As EventArgs) Handles User_Btn.LostFocus

        If btn_loginout.Focused Then

        Else

            hidedropdowns()

        End If

    End Sub
End Class