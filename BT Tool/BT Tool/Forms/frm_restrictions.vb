Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class frm_restrictions

#Region "Class"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
    Private urc As New markform.UserRestrictionsClass
#End Region

#Region "Variables"
    Private DefaultRestriction As String = ""
    Private TempRestriction As String = ""
    Private UserID As Integer = 0
    Private UserName As String = ""
    Public UserRestriction As String = ""
    Private CurrentSelectedRow As Integer = -1
    Private CurrentUID As Integer = 0
    Private IsAll As Boolean = False
#End Region

#Region "Initialization"

    Public Sub New(ByVal args As Object())

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            If Not IsNothing(args) Then

                UserID = Integer.Parse(args(0))
                UserName = If(IsNothing(args(1)), "", args(1).ToString)
                UserRestriction = args(2).ToString
                IsAll = Boolean.Parse(args(3))
                CurrentUID = Integer.Parse(args(4))
                pnl_contains_userlist.Visible = IsAll

                If IsAll Then LoadUserList()

                Me.Text = If(IsAll, "BT TOOL - User Restriction Editor", "BT TOOL - User Restriction Editor (" & If(UserID = 0, "New User", UserName.ToUpper()) & ")")
                DefaultRestriction = urc.DefaultRestriction

                PopulatePresets()
                AddHandler cbo_preset_dep.SelectedIndexChanged, AddressOf cbodep_indexchange
                AddHandler cbo_preset_pos.SelectedIndexChanged, AddressOf cbopos_indexchanged
                FilterCBO("all", "all")
                SetRestriction(If(Not cf.IsStringEmpty(UserRestriction), UserRestriction, DefaultRestriction))

            End If
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

#End Region

#Region "Sub"

    Private Sub LoadUserList()

        Try
            Dim ndt As New DataTable
            ndt.Columns.Add("uid", GetType(Integer)) : ndt.Columns.Add("Username", GetType(String))
            ndt.Columns.Add("Restrictions", GetType(String)) : ndt.Columns.Add("Department", GetType(String))
            Dim dt As DataTable = db.query("SELECT Id, UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,restrictions,department FROM dbo.UserData WHERE deactivated = 0 AND Id != " & CurrentUID & " ORDER BY department,position,username")

            For Each row As DataRow In dt.Rows
                Dim obj As Object() = row.ItemArray
                ndt.Rows.Add(Integer.Parse(obj(0)), obj(1), obj(2), obj(3).ToString.ToUpper)
            Next

            dgv_userlist.DataSource = ndt
            dgv_userlist.Columns(0).Visible = False
            dgv_userlist.Columns(2).Visible = False
            dgv_userlist.Columns(1).Width = 82
            dgv_userlist.Columns(3).Width = 50
            dgv_userlist.ClearSelection()

        Catch ex As Exception
            cf.Debug(ex)
        End Try

    End Sub

    Private Sub FilterDGV()
        Try
            Dim dep As New List(Of String)
            For Each chk As CheckBox In pnl_filterdgv_container.Controls.OfType(Of CheckBox).Reverse
                If chk.Checked Then dep.Add("'" & chk.Text.ToLower & "'")
            Next


            Dim flter As New List(Of String)
            Dim txt As String = txt_f_username.Text
            If Not cf.IsStringEmpty(txt) Then flter.Add("Username LIKE '%" & txt & "%'")
            If dep.Count > 0 Then flter.Add("Department IN(" & String.Join(",", dep) & ")")
            TryCast(dgv_userlist.DataSource, DataTable).DefaultView.RowFilter = String.Join(" AND ", flter)

        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

    Private Sub PopulatePresets()
        Try
            Dim depdt As New DataTable
            depdt.Columns.Add("text", GetType(String))
            depdt.Columns.Add("value", GetType(String))
            depdt.Rows.Add("All", "all")
            depdt.Rows.Add("BT", "bt") : depdt.Rows.Add("PR", "pr") : depdt.Rows.Add("BET", "bet") : depdt.Rows.Add("TS", "ts")

            Dim posdt As New DataTable
            posdt.Columns.Add("text", GetType(String))
            posdt.Columns.Add("value", GetType(String))
            posdt.Rows.Add("All", "all") : posdt.Rows.Add("Supervisor", "sup") : posdt.Rows.Add("Team Leader", "tl") : posdt.Rows.Add("Scheduler", "sched")
            posdt.Rows.Add("Production", "prod") : posdt.Rows.Add("Technical Support", "ts")
            cbo_preset_pos.DisplayMember = "text" : cbo_preset_pos.ValueMember = "value"
            cbo_preset_pos.DataSource = posdt : cbo_preset_pos.SelectedIndex = 0

        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

    Private Sub SetRestriction(ByVal JSONString As String)
        Try
            JSONString = If(Not cf.IsStringEmpty(JSONString), JSONString, DefaultRestriction)

            Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(JSONString)
            Dim fi As markform.FileInformation = urc.FileInformation
            Dim wf As markform.WorkFile = urc.WorkFile
            Dim au As markform.AssignUser = urc.AssignUser

            Dim fe As markform.FileEval = urc.FileEval : Dim fr As markform.FileReturn = urc.FileReturn
            Dim flag As markform.Flagging = urc.Flagging : Dim mo As markform.Monitoring = urc.Monitoring
            Dim rt As markform.RatioTracker = urc.RatioTracker : Dim it As markform.IdleTracker = urc.IdleTracker
            Dim wt As markform.WaitTracker = urc.WaitTracker : Dim fd As markform.FilesDue = urc.FilesDue
            Dim ua As markform.UserList = urc.UserList : Dim wfw As markform.WorkFlow = urc.WorkFlow
            Dim uf As markform.UploadFunction = urc.UploadFunction : Dim ef As markform.ExportFunction = urc.ExportFunction
            Dim af As markform.ArchiveFunction = urc.ArchiveFunction : Dim rl As markform.ReportLog = urc.ReportLog
            Dim rf As markform.ReferenceFunction = urc.ReferenceFunction : Dim btf As markform.BTFileFunction = urc.BTFileFunction

            chk_file_prio.Checked = urc.FilePriority
            chk_return_file.Checked = urc.ReturnFileBtn

#Region "Menu Restriction"
            chk_file_eval.Checked = fe.Enabled
            chk_monitoring.Checked = mo.Enabled
            chk_view_return.Checked = fr.Enabled
            chk_flagging.Checked = flag.Enabled
            chk_ratio_track.Checked = rt.Enabled
            chk_idle_track.Checked = it.Enabled
            chk_wait_tracker.Checked = wt.Enabled
            chk_files_due.Checked = fd.Enabled
            chk_userlist.Checked = ua.Enabled
            chk_workflow.Checked = wfw.Enabled
            chk_upload.Checked = uf.Enabled
            chk_export.Checked = ef.Enabled
            chk_archive.Checked = af.Enabled
            chk_report_logs.Checked = rl.Enabled
            chk_ref.Checked = rf.Enabled
            chk_btfile.Checked = btf.Enabled
#End Region

#Region "File Eval Restriction"
            chk_fe_allow_create_eval.Checked = fe.AllowCreateEval
            chk_fe_allow_export_eval.Checked = fe.AllowExport
            chk_fe_allow_view_eval.Checked = fe.AllowViewEval
            Dim feindex As Integer = 0 : Dim fe_dep As String() = fe.RestrictedDepartment
            For Each chk As CheckBox In pnl_evaldep.Controls.OfType(Of CheckBox).Reverse
                If Not chk.Name = "chk_fe_allow_view_eval" Then chk.Checked = fe_dep.Contains(chk.Text.ToLower)
                feindex += 1
            Next
#End Region

#Region "Return File Restrictions"
            chk_ret_allow_save.Checked = fr.AllowSave
            chk_flag_allow_delete.Checked = fr.AllowDelete
            chk_ret_allo_export.Checked = fr.AllowExport
            chk_ret_allow_seen.Checked = fr.AllowChangeSeen
            chk_ret_allow_view.Checked = fr.AllowViewReturn
            feindex = 0 : fe_dep = fr.RestrictedDepartment
            For Each chk As CheckBox In pnl_ret_allow_dep.Controls.OfType(Of CheckBox).Reverse
                If Not chk.Name = "chk_ret_allow_view" Then chk.Checked = fe_dep.Contains(chk.Text.ToLower()) : feindex += 1
            Next
#End Region

#Region "Set Flagging Restrictions"
            chk_flag_allow_create.Checked = flag.AllowSave
            chk_flag_allow_delete.Checked = flag.AllowDelete
            chk_flag_allo_export.Checked = flag.AllowExport
            chk_flag_view_all.Checked = flag.AllowViewFlag
            chk_flag_allow_seen.Checked = flag.AllowChangeSeen
            feindex = 0 : fe_dep = flag.RestrictedDepartment
            For Each chk As CheckBox In pnl_flag_allow_dep.Controls.OfType(Of CheckBox).Reverse
                If Not chk.Name = "chk_flag_view_all" Then chk.Checked = fe_dep.Contains(chk.Text.ToLower()) : feindex += 1
            Next
#End Region

#Region "Report Log Restrictions"
            chk_rl_allow_bl.Checked = rl.AllowViewBreakLog
            chk_rl_allow_il.Checked = rl.AllowViewIdleLog
            feindex = 0 : fe_dep = rl.BreakLogRestrictedDepartment
            For Each chk As CheckBox In pnl_rl_allow_bl.Controls.OfType(Of CheckBox).Reverse
                If Not chk.Name = "chk_rl_allow_bl" Then chk.Checked = fe_dep.Contains(chk.Text.ToLower()) : feindex += 1
            Next

            For Each chk As CheckBox In pnl_rl_allow_il.Controls.OfType(Of CheckBox).Reverse
                If Not chk.Name = "chk_rl_allow_il" Then chk.Checked = fe_dep.Contains(chk.Text.ToLower()) : feindex += 1
            Next
#End Region

#Region "File Information Restrictions"
            chk_file_info.Checked = fi.Enabled
            chk_due_date.Checked = fi.DueDate
            chk_serv_date.Checked = fi.ServiceDate
            chk_client.Checked = fi.Client
            chk_branch.Checked = fi.Branch
            chk_receive.Checked = fi.Receive
            chk_dur.Checked = fi.DurationInfo
            chk_page.Checked = fi.PageInfo
            chk_accuracy.Checked = fi.Accuracy
#End Region

#Region "Work File Restrictions"
            chk_work_file.Checked = wf.Enabled
            chk_audio.Checked = wf.AudioFile
            chk_doc.Checked = wf.DocumentInfo
#End Region

#Region "Asign User"
            chk_assign_user.Checked = au.Enabled
            chk_bt.Checked = au.BT
            chk_pr.Checked = au.PR
            chk_st.Checked = au.ST
            chk_cc.Checked = au.CC
            chk_btqa.Checked = au.BTQA
            chk_prqa.Checked = au.PRQA
            chk_stqa.Checked = au.STQA
            chk_ccqa.Checked = au.CCQA
#End Region

        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

    Private Sub FilterCBO(ByVal cbodep As String, ByVal cbopos As String)
        Try
            Dim fpos As String = ""
            If cbodep = "ts" Then
                fpos = "value LIKE 'ts'"
            ElseIf cbodep = "all" Then
                fpos = "value LIKE 'all'"
            Else
                fpos = "value NOT IN('ts','all')"
            End If

            TryCast(cbo_preset_pos.DataSource, DataTable).DefaultView.RowFilter = fpos
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

    Private Sub GetPreset()
        Try
            Dim cbodep As String = cbo_preset_dep.SelectedValue.ToString,
            cbopos As String = cbo_preset_pos.SelectedValue.ToString
            Dim preset As String = urc.GetPresetRestriction(cbodep, cbopos)
            SetRestriction(preset)
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
#End Region

#Region "Events"

    Private Sub txt_f_username_TextChanged(sender As Object, e As EventArgs)
        FilterDGV()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs)

        'Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(JSONString)

        Try
            Dim fi As markform.FileInformation = New markform.FileInformation With {
                .Enabled = chk_file_info.Checked,
                .DueDate = chk_due_date.Checked,
                .ServiceDate = chk_serv_date.Checked,
                .Client = chk_client.Checked,
                .Branch = chk_branch.Checked,
                .Receive = chk_receive.Checked,
                .DurationInfo = chk_dur.Checked,
                .PageInfo = chk_page.Checked,
                .Accuracy = chk_accuracy.Checked
            }
            Dim wf As markform.WorkFile = New markform.WorkFile With {
                .Enabled = chk_work_file.Checked,
                .AudioFile = chk_audio.Checked,
                .DocumentInfo = chk_doc.Checked
            }
            Dim au As markform.AssignUser = New markform.AssignUser With {
                .Enabled = chk_assign_user.Checked,
                .BT = chk_bt.Checked,
                .PR = chk_pr.Checked,
                .ST = chk_st.Checked,
                .CC = chk_cc.Checked,
                .BTQA = chk_btqa.Checked,
                .PRQA = chk_prqa.Checked,
                .STQA = chk_stqa.Checked,
                .CCQA = chk_ccqa.Checked
            }

#Region "Get file eval restrictions"
            Dim fileEval As markform.FileEval = New markform.FileEval With {
                .Enabled = chk_file_eval.Checked,
                .AllowCreateEval = chk_fe_allow_create_eval.Checked,
                .AllowExport = chk_fe_allow_export_eval.Checked,
                .AllowViewEval = chk_fe_allow_view_eval.Checked
            }
            Dim fe_dept = New List(Of String)

            For Each chk As CheckBox In pnl_evaldep.Controls.OfType(Of CheckBox).Reverse

                If chk.Name IsNot "chk_fe_allow_view_eval" AndAlso chk.Checked Then
                    fe_dept.Add(chk.Text.ToLower)
                End If
            Next

            fileEval.RestrictedDepartment = fe_dept.ToArray
#End Region

#Region "Get file return restrictions"
            Dim fileReturn As markform.FileReturn = New markform.FileReturn With {
                .Enabled = chk_view_return.Checked,
                .AllowSave = chk_ret_allow_save.Checked,
                .AllowDelete = chk_ret_allo_delete.Checked,
                .AllowExport = chk_ret_allo_export.Checked,
                .AllowChangeSeen = chk_ret_allow_seen.Checked,
                .AllowViewReturn = chk_ret_allow_view.Checked
            }
            Dim fr_dep = New List(Of String)

            For Each chk As CheckBox In pnl_ret_allow_dep.Controls.OfType(Of CheckBox).Reverse

                If chk.Name IsNot "chk_ret_allow_view" AndAlso chk.Checked Then
                    fr_dep.Add(chk.Text.ToLower)
                End If
            Next

            fileReturn.RestrictedDepartment = fr_dep.ToArray
#End Region

#Region "Get flagging restrictions"
            Dim flagging As markform.Flagging = New markform.Flagging With {
                .Enabled = chk_flagging.Checked,
                .AllowDelete = chk_flag_allow_delete.Checked,
                .AllowExport = chk_flag_allo_export.Checked,
                .AllowSave = chk_flag_allow_create.Checked,
                .AllowViewFlag = chk_flag_view_all.Checked,
                .AllowChangeSeen = chk_flag_allow_seen.Checked
            }
            Dim flag_dept = New List(Of String)

            For Each chk As CheckBox In pnl_flag_allow_dep.Controls.OfType(Of CheckBox).Reverse

                If chk.Name IsNot "chk_flag_view_all" AndAlso chk.Checked Then
                    flag_dept.Add(chk.Text.ToLower)
                End If
            Next

            flagging.RestrictedDepartment = flag_dept.ToArray
#End Region

#Region "Get report log restrictions"

            Dim reportLog As markform.ReportLog = New markform.ReportLog With {
                .Enabled = chk_report_logs.Checked,
                .AllowViewBreakLog = chk_rl_allow_bl.Checked,
                .AllowViewIdleLog = chk_rl_allow_il.Checked
            }
            Dim rlbl_dep = New List(Of String), rlil_dep = New List(Of String)

            For Each chk As CheckBox In pnl_rl_allow_bl.Controls.OfType(Of CheckBox).Reverse

                If chk.Name IsNot "chk_rl_allow_bl" AndAlso chk.Checked Then
                    rlbl_dep.Add(chk.Text.ToLower)
                End If
            Next

            For Each chk As CheckBox In pnl_rl_allow_il.Controls.OfType(Of CheckBox).Reverse

                If chk.Name IsNot "chk_rl_allow_il" AndAlso chk.Checked Then
                    rlil_dep.Add(chk.Text.ToLower)
                End If
            Next

            reportLog.BreakLogRestrictedDepartment = rlbl_dep.ToArray
            reportLog.IdleLogRestrictedDepartment = rlil_dep.ToArray
#End Region


            Dim monitoring As markform.Monitoring = New markform.Monitoring With {
                 .Enabled = chk_monitoring.Checked
            }
            Dim ratioTracker As markform.RatioTracker = New markform.RatioTracker With {
                .Enabled = chk_ratio_track.Checked
            }
            Dim idleTracker As markform.IdleTracker = New markform.IdleTracker With {
                .Enabled = chk_idle_track.Checked
            }
            Dim waitTracker As markform.WaitTracker = New markform.WaitTracker With {
                .Enabled = chk_wait_tracker.Checked
            }
            Dim filesDue As markform.FilesDue = New markform.FilesDue With {
                .Enabled = chk_files_due.Checked
            }
            Dim userList As markform.UserList = New markform.UserList With {
                .Enabled = chk_userlist.Checked,
                .AllowSave = chk_ua_allow_save.Checked
            }
            Dim workFlow As markform.WorkFlow = New markform.WorkFlow With {
                .Enabled = chk_workflow.Checked
            }
            Dim uploadFunction As markform.UploadFunction = New markform.UploadFunction With {
                .Enabled = chk_upload.Checked
            }
            Dim exportFunction As markform.ExportFunction = New markform.ExportFunction With {
                .Enabled = chk_export.Checked
            }
            Dim archiveFunction As markform.ArchiveFunction = New markform.ArchiveFunction With {
                .Enabled = chk_archive.Checked
            }
            Dim referenceFunction As markform.ReferenceFunction = New markform.ReferenceFunction With {
                .Enabled = chk_ref.Checked
            }
            Dim bTFileFunction As markform.BTFileFunction = New markform.BTFileFunction With {
                .Enabled = chk_btfile.Checked
            }

            Dim urc As markform.UserRestrictionsClass = New markform.UserRestrictionsClass With {
                .FilePriority = chk_file_prio.Checked, .FileInformation = fi, .WorkFile = wf, .AssignUser = au, .FileEval = fileEval, .FileReturn = fileReturn, .Flagging = flagging, .Monitoring = monitoring,
                .RatioTracker = ratioTracker, .IdleTracker = idleTracker, .WaitTracker = waitTracker, .FilesDue = filesDue, .UserList = userList, .WorkFlow = workFlow, .UploadFunction = uploadFunction,
                .ExportFunction = exportFunction, .ArchiveFunction = archiveFunction, .ReportLog = reportLog, .ReferenceFunction = referenceFunction, .BTFileFunction = bTFileFunction, .ReturnFileBtn = chk_return_file.Checked
            }

            Dim restrictions As String = JsonConvert.SerializeObject(urc)
            Console.WriteLine(restrictions)

            If Not IsAll Then
                UserRestriction = restrictions
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Dim qry As Integer = db.nQuery("UPDATE dbo.UserData SET restrictions = '" & restrictions & "' WHERE Id = " & UserID)

                If qry <> 0 Then
                    MessageBox.Show(Me, "Success!", UserName & "'s restrictions successfully saved.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgv_userlist(2, CurrentSelectedRow).Value = restrictions
                Else
                    MessageBox.Show(Me, "Failed!", UserName & "'s restrictions failed to save.", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End If
            End If

        Catch ex As Exception
            cf.Debug(ex)
        End Try

    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs)
        SetRestriction(DefaultRestriction)
    End Sub

    Private Sub cbodep_indexchange(sender As Object, e As EventArgs)

        Dim dep As String = cbo_preset_dep.SelectedValue.ToString, pos As String = cbo_preset_pos.SelectedValue.ToString
        FilterCBO(dep, pos)
        GetPreset()
    End Sub

    Private Sub cbopos_indexchanged(sender As Object, e As EventArgs)
        GetPreset()
    End Sub

    Private Sub chk_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try
            Select Case DirectCast(sender, Button).Name
                Case "chk_file_info"
                    gbox_fileinfo.Enabled = chk_file_info.Checked
                Case "chk_work_file"
                    gbox_workfile.Enabled = chk_work_file.Checked
                Case "chk_assign_user"
                    gbox_assign_user.Enabled = chk_assign_user.Checked
                Case "chk_fe_allow_view_eval"
                    pnl_evaldep.Enabled = chk_fe_allow_view_eval.Checked
                Case "chk_file_eval"
                    DirectCast(tab_file_eval, Control).Enabled = chk_file_eval.Checked
                Case "chk_view_return"
                    DirectCast(tab_view_return, Control).Enabled = chk_view_return.Checked
                Case "chk_userlist"
                    DirectCast(tab_userlist, Control).Enabled = chk_userlist.Checked
                Case "chk_report_logs"
                    DirectCast(tab_report_logs, Control).Enabled = chk_report_logs.Checked
                Case "chk_flag_view_all"
                    pnl_flag_allow_dep.Enabled = chk_flag_view_all.Checked
                Case "chk_ret_allow_view"
                    pnl_ret_allow_dep.Enabled = chk_ret_allow_view.Checked
                Case "chk_rl_allow_bl"
                    pnl_rl_allow_bl.Enabled = chk_rl_allow_bl.Enabled
                Case "chk_rl_allow_il"
                    pnl_rl_allow_bl.Enabled = chk_rl_allow_il.Checked
            End Select

        Catch ex As Exception
            cf.Debug(ex)
        End Try

    End Sub

    Private Sub dgv_userlist_CellClick(sender As Object, e As DataGridViewCellEventArgs)

        Try
            If e.RowIndex <> -1 Then
                CurrentSelectedRow = e.RowIndex
                Dim SelRow As DataGridViewRow = dgv_userlist.Rows(e.RowIndex)
                UserID = Integer.Parse(SelRow.Cells(0).Value)
                UserName = SelRow.Cells(1).Value.ToString.ToUpper
                UserRestriction = SelRow.Cells(2).Value.ToString
                SetRestriction(UserRestriction)
            End If
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub

    Public Sub Filter_CheckChange(ByVal sender As String, ByVal e As EventArgs)
        FilterDGV()
    End Sub

#End Region



End Class