Imports PresentationControls
Imports System.ComponentModel
Imports System.Threading
Imports Newtonsoft.Json

Public Class frm_userlist

#Region "Initialize Classes"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
#End Region

#Region "Setting Variables"
    Private EditUID As Integer = 0
    Private LastUname As String = ""
    Public UserRestrictions As String = ""

    Private _cancel As CancellationTokenSource
#End Region


#Region "Events"

    Private CustomFn As New CustomFunctions()
    Dim showpass As Image = My.Resources.show_pass_241
    Dim hidepass As Image = My.Resources.hide_pass_241

    Private Sub frm_userlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CustomFn.FormDrag(Me, Panel1)

        SetRestrictions()
        LoadUserList()
        LoadComboBox()

        ' Fixing btn_showhide_pass 10142019
        ImageList1.Images.Add(showpass)
        ImageList1.Images.Add(hidepass)

        btn_showhide_pass.PerformClick()
        ' ---

    End Sub
    Private Sub btn_showhide_pass_Click(sender As Object, e As EventArgs) Handles btn_showhide_pass.Click
        Dim btn As Button = sender
        ' Fixing btn_showhide_pass 10142019
        btn.ImageList = ImageList1
        ' ---
        Dim imgIndex As Integer = btn.ImageIndex : Dim HidePass As Boolean = True
        If imgIndex = 0 Then
            imgIndex = 1 : HidePass = False
        Else
            imgIndex = 0 : HidePass = True
        End If
        btn_showhide_pass.ImageIndex = imgIndex : txt_pass.UseSystemPasswordChar = HidePass
    End Sub

    Private Sub CboFilter_CheckBoxCheckedChanged(sender As Object, e As EventArgs) Handles cbo_f_dep.CheckBoxCheckedChanged, cbo_f_pos.CheckBoxCheckedChanged
        Filter()
    End Sub

    Private Sub TxtFilter_TextChanged(sender As Object, e As EventArgs) Handles txt_f_name.TextChanged, txt_f_uname.TextChanged
        Filter()
    End Sub
    Private Sub ChkFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chk_f_forbt.CheckedChanged, chk_f_locked.CheckedChanged, chk_f_online.CheckedChanged, chk_f_deactivate.CheckedChanged
        Filter()
    End Sub
    Private Sub cbo_dep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dep.SelectedIndexChanged
        Dim cdep As ComboBox = cbo_dep
        Dim cpos As ComboBox = cbo_pos

        If cdep.SelectedIndex <> -1 Then
            FilterCbo(cdep.SelectedValue, cpos.SelectedValue)
        End If
    End Sub
    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        ResetUserForm()
    End Sub
    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            'Set variables
            Dim ErrTxt As List(Of TextBox) = New List(Of TextBox)()
            Dim ErrMsg As List(Of String) = New List(Of String)()
            Dim fname As String = txt_name.Text : Dim uname As String = txt_uname.Text : Dim pass As String = txt_pass.Text
            Dim dep As String = cbo_dep.SelectedValue : Dim pos As String = cbo_pos.SelectedValue
            Dim udep As String = dep : Dim locktime As Integer = cbo_locktime.SelectedItem
            Dim online As Boolean = chk_online.Checked : Dim locked As Boolean = chk_locked.Checked
            Dim forbt As Boolean = chk_forbt.Checked : Dim deactivate As Boolean = chk_deactivate.Checked
            'Validate varaibles
            If udep = "st" Or udep = "cc" Then dep = "bet"

            If cf.IsStringEmpty(fname) Then
                ErrTxt.Add(txt_name) : ErrMsg.Add("-Name field is empty.")
            End If
            If cf.IsStringEmpty(uname) Then
                ErrTxt.Add(txt_uname) : ErrMsg.Add("-Username field is empty.")
            End If
            If cf.IsStringEmpty(pass) Then
                ErrTxt.Add(txt_pass) : ErrMsg.Add("-Password field is empty.")
            End If
            'Show error message if validation failed
            If ErrMsg.Count > 0 Then
                MessageBox.Show(Me, String.Join(vbNewLine, ErrMsg.ToArray()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ErrTxt(0).Select() 'focus the first textbox that has an error
            Else
                'Check username availability
                Dim ChkUname As String = db.single("SELECT COUNT (username) FROM dbo.UserData WHERE username LIKE @uname", New String() {"uname", uname})
                If Convert.ToInt16(ChkUname) > 0 And LastUname.ToLower() <> uname.ToLower() Then
                    MessageBox.Show(Me, "-Username already exist.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txt_uname.Select()
                Else
                    'prepare query string and parameter
                    Dim qryStr As String = "" : Dim qryParam() As String = New String() {}
                    If EditUID = 0 Then 'Insert
                        qryStr = "INSERT INTO dbo.UserData (fullname,username,password,uDept,position,department,locktime,restrictions) VALUES (@fullname,@username,@password,@uDept,@position,@department,@locktime,'" & UserRestrictions & "')"
                        qryParam = New String() {"fullname", fname, "username", uname, "password", pass, "uDept", udep, "position", pos, "department", dep, "locktime", locktime}
                    Else 'Update
                        qryStr = "UPDATE dbo.UserData SET fullname=@fullname,username=@username,password=@password,uDept=@uDept,position=@position,department=@department,lockTime=@lockTime,status=@status,locked=@locked,btwork=@btwork,deactivated=@deactivate,restrictions='" & UserRestrictions & "' WHERE Id=" & EditUID
                        qryParam = New String() {"fullname", fname, "username", uname, "password", pass, "uDept", udep,
                            "position", pos, "department", dep, "lockTime", locktime, "status", online, "locked", locked,
                            "btwork", forbt, "deactivate", deactivate}
                    End If

                    '****Query****
                    Dim qryResult As Integer = 0
                    If Not cf.IsStringEmpty(qryStr) Then qryResult = db.nQuery(qryStr, qryParam)
                    If qryResult > 0 Then
                        MessageBox.Show(Me, "User successfully saved.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadUserList()
                        ResetUserForm()
                        txt_name.Select()
                    End If
                End If
            End If
        Catch ex As Exception
            cf.Debug(ex)
        End Try

    End Sub
    Private Sub dgv_userlist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_userlist.CellDoubleClick
        Try
            Dim SelRow As DataGridViewRow = dgv_userlist.Rows(e.RowIndex)
            txt_name.Text = SelRow.Cells(1).Value : txt_uname.Text = SelRow.Cells(2).Value
            txt_pass.Text = SelRow.Cells(3).Value

            cbo_dep.SelectedValue = SelRow.Cells(4).Value
            cbo_pos.SelectedValue = SelRow.Cells(5).Value
            cbo_locktime.SelectedItem = SelRow.Cells(6).Value

            chk_online.Checked = SelRow.Cells(7).Value
            chk_locked.Checked = SelRow.Cells(8).Value
            chk_forbt.Checked = SelRow.Cells(9).Value
            chk_deactivate.Checked = SelRow.Cells(10).Value

            UserRestrictions = SelRow.Cells(11).Value
            EditUID = Convert.ToInt16(SelRow.Cells(0).Value)
            LastUname = SelRow.Cells(2).Value
            btn_edit_restrict.Enabled = (Not EditUID = CustomVariables.CurrentUserID)

        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
    Private Sub UserSave_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_name.KeyDown, txt_uname.KeyDown, txt_pass.KeyDown, chk_online.KeyDown, chk_locked.KeyDown, chk_forbt.KeyDown, chk_deactivate.KeyDown, cbo_pos.KeyDown, cbo_locktime.KeyDown, cbo_dep.KeyDown
        If e.KeyValue = 13 Then
            btn_save.PerformClick()
        End If
    End Sub
    Private Sub MultiEdit_Click(sender As Object, e As EventArgs) Handles btn_unlock.Click, btn_offline.Click, btn_lock.Click, btn_deactivate.Click, btn_bt_on.Click, btn_bt_off.Click, btn_activate.Click, b.Click
        Try
            Dim btn As Button = sender
            Dim tag As String = btn.Tag.ToString()
            Dim msg As String = "" : Dim ws As String = ""
            Dim uids As List(Of Integer) = New List(Of Integer)()
            For Each row As DataGridViewRow In dgv_userlist.SelectedRows
                uids.Add(row.Cells(0).Value)
            Next
            If uids.Count = 0 Then
                MessageBox.Show(Me, "No item selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                If uids.Count > 1 Then ws = "s"
                If New String() {"Activate", "Deactivate", "Lock", "Unlock"}.Contains(btn.Text) Then
                    msg = btn.Text
                ElseIf btn.Text = "Online" Or btn.Text = "Offline" Then
                    msg = "Change the user status to " & btn.Text.ToLower() & " of the"
                ElseIf btn.Text = "BT On" Or btn.Text = "BT Off" Then
                    Dim txt As String = ""
                    If btn.Text = "BT On" Then txt = "on" Else txt = "off"
                    msg = "Turn " & txt & " BT work of the "
                End If
                Dim dr As DialogResult = MessageBox.Show(Me, msg & " selected user" & ws, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If dr = DialogResult.OK Then
                    db.nQuery("UPDATE dbo.UserData SET " & tag & " WHERE Id IN(" & String.Join(",", uids.ToArray()) & ")")
                    LoadUserList()
                End If
            End If
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
    ''' <summary>
    ''' Cancel asynchronous action before closing the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frm_userlist_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _cancel IsNot Nothing Then
            _cancel.Cancel()
        End If
        Me.Dispose()
    End Sub
    Private Sub btn_edit_restrict_Click(sender As Object, e As EventArgs) Handles btn_edit_restrict.Click
        Dim frmrestriction As markform.frm_restriction
        If Not cf.IsFormOpen("frm_restriction") Then
            frmrestriction = New markform.frm_restriction(New Object() {EditUID, txt_uname.Text, UserRestrictions, False, CustomVariables.CurrentUserID})
            If frmrestriction.ShowDialog(Me) = DialogResult.OK Then
                UserRestrictions = frmrestriction.UserRestriction
            End If
        Else
            cf.GetForm.Activate()
        End If
    End Sub
    Private Sub btn_open_restrict_editor_Click(sender As Object, e As EventArgs) Handles btn_open_restrict_editor.Click
        Dim frmrestriction As markform.frm_restriction
        If Not cf.IsFormOpen("frm_restriction") Then
            frmrestriction = New markform.frm_restriction(New Object() {0, "", "", True, CustomVariables.CurrentUserID})
            If frmrestriction.ShowDialog(Me) = DialogResult.OK Then
                UserRestrictions = frmrestriction.UserRestriction
            End If
        Else
            cf.GetForm.Activate()
        End If
    End Sub
#End Region

#Region "Sub Routines"
    ''' <summary>
    ''' load user list from the database
    ''' </summary>
    Private Async Sub LoadUserList()
        Dim ErrMsg As String = "Something went wrong." 'The default Error Message if an error occured.
        Dim whereClause As String = "" 'variable for custom where clause of the queryV
        'Setting the whereClause value base on a certain condition.
        If New String() {"sup", "tl"}.Contains(CustomVariables.CurrentUserPosition) Then
            whereClause = "department LIKE '" & CustomVariables.CurrentUserDepartment & "'"
        End If
        'Preparing the whereClause if not empty.
        If whereClause IsNot "" Then
            whereClause = "WHERE " & whereClause
        End If
        'Preparing the query string. This will also be used as a reference if an error occured during the execution of the query.
        Dim qry As String = "SELECT Id,fullname,username,password,uDept,position,locktime,status,locked,btwork,deactivated,restrictions FROM dbo.UserData " & whereClause
        'Setting the column headers properties.
        Dim headers As New List(Of GridHeaders)() : Dim newDt As New DataTable() '(newDT) = Variable for storing the new datatable that will be used as the datasource of the datagridview
        headers.Add(New GridHeaders() With {.index = 0, .text = "id", .type = GetType(Integer), .visible = False, .width = 0})
        headers.Add(New GridHeaders() With {.index = 1, .text = "Name", .type = GetType(String), .width = 75})
        headers.Add(New GridHeaders() With {.index = 2, .text = "Username", .type = GetType(String), .width = 60})
        headers.Add(New GridHeaders() With {.index = 3, .text = "Password", .type = GetType(String), .visible = False, .width = 0})
        headers.Add(New GridHeaders() With {.index = 4, .text = "Department", .type = GetType(String), .width = 65})
        headers.Add(New GridHeaders() With {.index = 5, .text = "Position", .type = GetType(String), .width = 55})
        headers.Add(New GridHeaders() With {.index = 6, .text = "Lock Time", .type = GetType(Integer), .width = 55})
        headers.Add(New GridHeaders() With {.index = 7, .text = "Status", .type = GetType(Boolean), .width = 45})
        headers.Add(New GridHeaders() With {.index = 8, .text = "Locked", .type = GetType(Boolean), .width = 45})
        headers.Add(New GridHeaders() With {.index = 9, .text = "For BT", .type = GetType(Boolean), .width = 45})
        headers.Add(New GridHeaders() With {.index = 10, .text = "Deactivated", .type = GetType(Boolean), .visible = False, .width = 0})
        headers.Add(New GridHeaders() With {.index = 11, .text = "Restrictions", .type = GetType(String), .visible = False, .width = 0})
        'Adding the columns to newDT
        For Each itm As GridHeaders In headers
            newDt.Columns.Add(itm.text, itm.type)
        Next
        'Preparing a cancel token just in case the form is being closed to stop this thread from executing and prevent error.
        _cancel = New CancellationTokenSource() 'Instantiating a new cancel token source
        Dim token As CancellationToken = _cancel.Token 'Variable for the cancel token

        Try
            'Variable for storing the result of the task.run
            Dim dt As DataTable = Await Task.Run(
                Function()
                    Dim qryR As New DataTable() 'variable for storing the query result
                    Try
                        qryR = db.query(qry) 'executing the query
                    Catch ex As Exception
                        ErrMsg = "Something went wrong while trying to execute Query: " & vbNewLine & qry
                        Throw ex 'throwing the exception for this error to the main try catch exception.
                    End Try
                    For Each rows As DataRow In qryR.Rows
                        token.ThrowIfCancellationRequested() 'Stoping this process if cancellation request is present.
                        Dim row As Object() = rows.ItemArray
                        newDt.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11))
                    Next
                    Return newDt
                End Function)
            'set datagridview datasource
            dgv_userlist.DataSource = dt
            'set datagridview column properties
            For Each itm As GridHeaders In headers
                dgv_userlist.Columns(itm.index).Width = itm.width
                dgv_userlist.Columns(itm.index).Visible = itm.visible
            Next
            Filter()
        Catch ex As Exception
            cf.Debug(ex, True, ErrMsg)
        End Try
    End Sub
    ''' <summary>
    ''' This will populate the comboboxes
    ''' </summary>
    Private Sub LoadComboBox()
        '*************************************
        'For ComboBox Position
        '*************************************
        'initialize datatable
        Dim dtcommon As New DataTable()
        'add datacolumn to datatable
        dtcommon.Columns.Add("Text", GetType(String))
        dtcommon.Columns.Add("Value", GetType(String))
        'add datarow to datatable
        dtcommon.Rows.Add("Admin", "admin")
        dtcommon.Rows.Add("Auditor", "auditor")
        dtcommon.Rows.Add("Production", "prod")
        dtcommon.Rows.Add("Scheduler", "sched")
        dtcommon.Rows.Add("Supervisor", "sup")
        dtcommon.Rows.Add("Team Leader", "tl")
        dtcommon.Rows.Add("Trainer", "trainer")
        dtcommon.Rows.Add("Trainee", "trainee")
        dtcommon.Rows.Add("HR", "hr")
        dtcommon.Rows.Add("IT", "it")
        dtcommon.Rows.Add("TS", "ts")
        dtcommon.Rows.Add("OpSup", "opsup")
        'for the combobox with checkbox
        cbo_f_pos.DataSource = New ListSelectionWrapper(Of DataRow)(dtcommon.Rows, "Text")
        cbo_f_pos.DisplayMemberSingleItem = "Name" ' "Name" is constant
        cbo_f_pos.DisplayMember = "NameConcatenated" ' "NameConcatenated" is constant
        cbo_f_pos.ValueMember = "Selected" ' "Selected" is constant
        'for the normal combox
        cbo_pos.DisplayMember = "Text" : cbo_pos.ValueMember = "Value" : cbo_pos.DataSource = dtcommon
        '*************************************
        'For ComboBox Department
        '*************************************
        'initialize datatable
        dtcommon = New DataTable
        'add datacolumn to the datatable
        dtcommon.Columns.Add("Text", GetType(String))
        dtcommon.Columns.Add("Value", GetType(String))
        'add datarow to the datatable
        dtcommon.Rows.Add("Admin", "admin")
        dtcommon.Rows.Add("BT", "bt")
        dtcommon.Rows.Add("PR", "pr")
        dtcommon.Rows.Add("TS", "ts")
        dtcommon.Rows.Add("CC", "cc")
        dtcommon.Rows.Add("S&T", "st")
        dtcommon.Rows.Add("HR", "hr")
        'for the combobox with checkbox
        cbo_f_dep.DataSource = New ListSelectionWrapper(Of DataRow)(dtcommon.Rows, "Text")
        cbo_f_dep.DisplayMemberSingleItem = "Name"
        cbo_f_dep.DisplayMember = "NameConcatenated"
        cbo_f_dep.ValueMember = "Selected"
        'for the normal combox
        cbo_dep.DisplayMember = "Text" : cbo_dep.ValueMember = "Value" : cbo_dep.DataSource = dtcommon
        '*************************************
        'For ComboBox Lock Time
        '*************************************
        cbo_locktime.Items.Clear()
        For i = 0 To 15
            cbo_locktime.Items.Add(i)
        Next
        cbo_locktime.SelectedIndex = 0
    End Sub
    ''' <summary>
    ''' Contains the procedure for filtering the data from the user list datagridview datasource.
    ''' </summary>
    Private Sub Filter()
        Dim FilterList As List(Of String) = New List(Of String)()
        Dim PosList As List(Of String) = New List(Of String)()
        Dim DepList As List(Of String) = New List(Of String)()
        Dim Namae As String = txt_f_name.Text
        Dim UNamae As String = txt_f_uname.Text

        'get the selected position
        For Each itm In cbo_f_dep.CheckBoxItems
            If itm.Checked Then
                Dim txt As String = itm.Text.ToLower()
                If txt = "s&t" Then txt = "st"
                DepList.Add("'" & txt & "'")
            End If
        Next
        'get the selected department
        For Each itm In cbo_f_pos.CheckBoxItems
            If itm.Checked Then
                Dim txt As String = itm.Text.ToLower()
                Select Case txt
                    Case "production"
                        txt = "prod"
                    Case "scheduler"
                        txt = "sched"
                    Case "supervisor"
                        txt = "sup"
                    Case "team leader"
                        txt = "tl"
                End Select
                PosList.Add("'" & txt & "'")
            End If
        Next

        If Not cf.IsStringEmpty(Namae) Then FilterList.Add("Name LIKE '%" & Namae & "%'")
        If Not cf.IsStringEmpty(UNamae) Then FilterList.Add("Username LIKE '%" & UNamae & "%'")
        If chk_f_forbt.Checked Then FilterList.Add("[For BT] = 1")
        If chk_f_online.Checked Then FilterList.Add("Status = 1")
        If chk_f_locked.Checked Then FilterList.Add("Locked = 1")
        If chk_f_deactivate.Checked Then FilterList.Add("Deactivated = 1")
        If PosList.Count > 0 Then FilterList.Add("Position IN(" & String.Join(",", PosList.ToArray()) & ")")
        If DepList.Count > 0 Then FilterList.Add("Department IN(" & String.Join(",", DepList.ToArray()) & ")")

        If Not IsNothing(dgv_userlist.DataSource) Then
            Dim ds As New DataTable
            ds = dgv_userlist.DataSource

            ds.DefaultView.RowFilter = String.Join(" AND ", FilterList.ToArray())
        End If
    End Sub
    ''' <summary>
    ''' Reset the Add/Edit Fields to its default value.
    ''' </summary>
    Private Sub ResetUserForm()
        txt_name.ResetText()
        txt_uname.ResetText()
        txt_pass.ResetText()

        chk_online.Checked = False
        chk_locked.Checked = False
        chk_forbt.Checked = False
        chk_deactivate.Checked = False

        cbo_dep.SelectedIndex = 0
        cbo_locktime.SelectedIndex = 0
        EditUID = 0 : UserRestrictions = "" : LastUname = ""
    End Sub
    ''' <summary>
    ''' Filter cbo_position base on department
    ''' </summary>
    ''' <param name="dep">cbo_dep value</param>
    ''' <param name="pos">cbo_pos value</param>
    Private Sub FilterCbo(dep As String, pos As String)

        Dim fpos As String

        If dep = "admin" Then
            fpos = "value like 'admin'"
        ElseIf dep = "all" Then
            fpos = "value like 'opsup'"
        ElseIf dep = "hr" Then
            fpos = "value like 'hr'"
        ElseIf dep = "ts" Then
            fpos = "value like 'ts'"
        Else
            fpos = "value IN('auditor','prod','sup','tl','trainer','trainee','sched')"
        End If

        Dim dspos As New DataTable
        dspos = cbo_pos.DataSource
        dspos.DefaultView.RowFilter = fpos

    End Sub
    ''' <summary>
    ''' Setting the restriction for user list form.
    ''' </summary>
    Private Sub SetRestrictions()
        Try
            Dim JSONString As String = CustomVariables.CurrentUserRestriction
            If Not cf.IsStringEmpty(JSONString) Then
                Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(JSONString)
                Dim ua As markform.UserList = urc.UserList
                With ua
                    txt_name.Enabled = .AllowSave
                    txt_uname.Enabled = .AllowSave
                    txt_pass.Enabled = .AllowSave
                    cbo_dep.Enabled = .AllowSave
                    cbo_locktime.Enabled = .AllowSave
                    cbo_pos.Enabled = .AllowSave
                    chk_deactivate.Enabled = .AllowSave
                    chk_forbt.Enabled = .AllowSave
                    chk_locked.Enabled = .AllowSave
                    chk_online.Enabled = .AllowSave
                    btn_edit_restrict.Enabled = .AllowSave
                    btn_save.Enabled = .AllowSave
                    btn_clear.Enabled = .AllowSave
                    tlp_contain_multi.Enabled = .AllowSave
                    btn_open_restrict_editor.Enabled = .AllowSave
                End With
            End If
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub
#End Region


    Private Sub PopupComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_userlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_userlist.CellContentClick

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class