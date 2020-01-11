Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class frm_file_return

#Region "Class"

    Private cf As New markform.CustomClass
    Private db As New markform.SQLClass
    Private nDataTable As New DataTable
    Private headers As New List(Of GridHeaders)()
#End Region

#Region "Variables"
    Private uid As Integer, ulvl As Integer, btid As Integer
    Private uName As String, uPos As String, uDep As String, UserRestriction As String = ""
    Private ErrorQuery As String = ""
    Private _cnl As CancellationTokenSource
    Private IsAllowSave As Boolean = False, IsAllowView As Boolean = False, IsViewOnly As Boolean = False
    Private AllowDep As String()
#End Region

#Region "Sub"

    Public Sub New(args As String(), Optional viewonly As Boolean = False, Optional CurrentUserRestriction As String = "")

        ' This call is required by the designer.
        InitializeComponent()
        Me.Tag = "Return"
        ' Add any initialization after the InitializeComponent() call.

        If args IsNot Nothing Then

            uid = Integer.Parse(args(0).ToString)
            uName = args(1).ToString
            uPos = args(2).ToString
            uDep = args(3).ToString
            ulvl = Integer.Parse(args(4).ToString)
            UserRestriction = CurrentUserRestriction
            IsViewOnly = viewonly

            sb_info.Items.Add("User ID: " & uid)
            sb_info.Items.Add("User Name: " & uName.ToUpper())
            sb_info.Items.Add("User Position: " & cf.GetPositionFull(uPos).ToUpper())
            sb_info.Items.Add("User Department: " & uDep.ToUpper())
            sb_info.Items.Add("User Level: " & ulvl)

            For Each itm As ToolStripStatusLabel In sb_info.Items
                itm.BorderSides = ToolStripStatusLabelBorderSides.All
                itm.BorderStyle = Border3DStyle.Sunken
            Next

            If Not viewonly Then
                txt_fn.Text = args(5).ToString()
                cbo_cl.SelectedValue = GetClientID(args(6).ToString())
                lbl_client.Text = cbo_cl.Text
                btid = Integer.Parse(args(7).ToString())
                cbo_name.SelectedValue = btid
            End If

            LoadReturn()
            Restrictions()
            'event for combo box index changed
        End If

    End Sub

    Private Async Sub LoadReturn()
        _cnl = New CancellationTokenSource
        Dim token As CancellationToken = _cnl.Token
        db.SQLDependency(False)
        Cursor = Cursors.AppStarting
        tss_status.Text = "Initializing..."
        Dim SelDT As String = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = ""
        Dim progressHandler = New Progress(Of String)(Function(val)
                                                          tss_status.Text = val
                                                      End Function)
        Dim progress As IProgress(Of String) = progressHandler

        Try
            Await Task.Run(Function()
                               Dim opsdep = If(uDep Is "pr", "BT", "PR")
                               Dim curdep As String = uDep

                               If IsAllowView Then
                                   opsdep = "BT/PR"
                                   curdep = "PR/BET"
                               End If

                               Dim PosArr = New String() {"sup", "tl", "auditor"}
                               Dim qrywhere = New List(Of String)
                               Dim q As String = If(uDep Is "bt", "btpr_id = " & uid, "(user_id = " & uid & " OR " & "btpr_id = " + uid & ")")

                               If AllowDep.Length > 0 AndAlso IsAllowView Then
                                   qrywhere.Add("dep IN ('" & String.Join("','", AllowDep) & "')")
                               End If

                               progress.Report("Fetching Data...")
                               Dim qryStr = "SELECT fid,user_id,user2_id,btpr_id,fixer_id,act_id,[filename],dep,seen," & "CONVERT(varchar(15),CAST(dt_created AS date),100)," & "cl_id,(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," & "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," & "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname, " & "(SELECT username FROM dbo.UserData WHERE Id = a.user2_id) AS uname2," & "(SELECT username FROM dbo.UserData WHERE Id = a.btpr_id) AS btprname," & "(SELECT username FROM dbo.UserData WHERE Id = a.fixer_id) AS fixername," & "(SELECT username FROM dbo.UserData WHERE Id = a.act_id) AS actname," & "others " & "FROM dbo.tbl_flag_return AS a WHERE CONVERT(date,dt_created) LIKE CONVERT(date,'" & SelDT & "') AND type LIKE 'return' " & " AND (" & q & " OR " & String.Join(" AND ", qrywhere.ToArray) & ")" & "ORDER BY Convert(varchar(30), dt_created, 101) DESC"
                               Dim dt As DataTable = New DataTable

                               Try
                                   dt = db.query(qryStr)
                                   token.ThrowIfCancellationRequested()
                               Catch __unusedException1__ As Exception
                                   ErrorQuery = qryStr
                                   Throw
                               End Try

                               Dim newdt As DataTable = New DataTable
                               Dim headers As New List(Of GridHeaders)()
                               headers.Add(New GridHeaders() With {.index = 0, .text = "Seen/Unseen", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 1, .text = "Date Submitted", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 2, .text = If(Not New String() {"pr", "bet"}.Contains(uDep), "BT", opsdep) & " Name", .visible = False, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 3, .text = If(Not New String() {"pr", "bet"}.Contains(uDep), "PR", curdep.ToUpper) & " Name", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 4, .text = "File Fixed By", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 5, .text = If(Not New String() {"pr", "bet"}.Contains(uDep), "PR", curdep.ToUpper) & " Name 2", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 6, .text = "Account", .width = 80, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 7, .text = "Filename", .width = 200, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 8, .text = "Accuracy", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 9, .text = "Specs", .width = 150, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 10, .text = If(Not New String() {"pr", "bet"}.Contains(uDep), "BT", opsdep) & " Comment", .width = 150, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 11, .text = "Action By " & If(Not New String() {"pr", "bet"}.Contains(uDep), "BT", opsdep) & " Sup", .width = 50, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 12, .text = "Side-by-side Feedback", .width = 150, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 13, .text = "Comment", .width = 150, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 14, .text = "fid", .visible = False, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 15, .text = "cltype", .visible = False, .type = GetType(String)})
                               headers.Add(New GridHeaders() With {.index = 16, .text = "dep", .visible = False, .type = GetType(String)})


                               For Each itm In headers
                                   newdt.Columns.Add(itm.text, itm.type)
                               Next

                               Dim x = 1, cnt As Integer = dt.Rows.Count

                               For Each row As DataRow In dt.Rows
                                   token.ThrowIfCancellationRequested()
                                   progress.Report(x & " of " & cnt)
                                   Dim obj As Object() = row.ItemArray
                                   Dim rfobj As returnfile = JsonConvert.DeserializeObject(Of returnfile)(obj(18).ToString)
                                   Dim ac As String = rfobj.accuracy, sp As String = rfobj.specs, com1 As String = rfobj.btpr_comment, com2 As String = rfobj.side_comment, com3 As String = rfobj.comment, seen = If(Integer.Parse(obj(8).ToString) = 0, "Unseen", "Seen")
                                   newdt.Rows.Add(seen, obj(9), obj(15), obj(13), obj(16), obj(14), obj(11), obj(6), ac, sp, com1, obj(17), com2, com3, obj(0), obj(12), obj(7))
                                   x += 1
                               Next

                               progress.Report("Finalizing...")
                               headers = headers
                               nDataTable = New DataTable
                               nDataTable = newdt
                           End Function)
            dgv_return.DataSource = nDataTable

            For Each itm In headers
                dgv_return.Columns(itm.index).Visible = itm.visible
                dgv_return.Columns(itm.index).Width = itm.width
            Next

            cf.RowsNumber(dgv_return)
            tssStr = "Ready!"
            FilterData()
        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.WriteToFile("{0}==>" & ex.ToString & vbLf & vbLf + ErrorQuery, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
            MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ErrorQuery = ""
        tss_status.Text = tssStr
        Cursor = Cursors.Default

    End Sub

    Public Sub FilterData()

        Dim type As String = cbo_type.SelectedValue.ToString
        Dim dep As String = cbo_dep.SelectedValue.ToString
        Dim filter As New List(Of String)
        If type IsNot "all" Then
            filter.Add("cltype LIKE '" & type & "'")
        End If
        If dep IsNot "all" Then
            filter.Add("dep LIKE '" & dep & "'")
        End If

    End Sub

    Public Sub Restrictions()

        Dim rf As New markform.FileReturn

        If Not cf.IsStringEmpty(UserRestriction) Then
            Try
                Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(UserRestriction)
                rf = urc.FileReturn
            Catch ex As Exception
                cf.Debug(ex, True, "Something is wrong with the current restrictions.\nRestrictions will revert to default.")
            End Try
        End If

        IsAllowSave = If(IsViewOnly, False, rf.AllowSave)
        gb_form_container.Visible = If(IsViewOnly, False, IsAllowSave)
        btn_export.Visible = If(IsViewOnly, False, rf.AllowExport)
        btn_seen.Visible = If(IsViewOnly, False, rf.AllowChangeSeen)
        btn_unseen.Visible = If(IsViewOnly, False, rf.AllowChangeSeen)
        btn_del.Visible = rf.AllowViewReturn
        AllowDep = rf.RestrictedDepartment

        If (Not IsViewOnly Or IsAllowSave) Then
            SetPRBETLabel()
        End If
        SetCboDataSource()

    End Sub

    Public Sub DisableForm(Optional b As Boolean = True)
        gb_filter_export_container.Enabled = b
        gb_form_container.Enabled = b
        dgv_return.Enabled = b
    End Sub

    Public Sub SetPRBETLabel()

        lbl_prbet_1.Text = "Second " + If(uDep = "pr", "PR", "BET") + " Assigned"
        lbl_prbet_2.Text = If(uDep = "pr", "BT", "PR") & " Name"
        lbl_prbet_3.Text = "Action By " + If(uDep = "pr", "BT", "PR") + " Supervisor"
        lbl_prbet_4.Text = If(uDep = "pr", "BT", "PR") & " Comment"

    End Sub

    Public Sub SetCboDataSource()

        Dim dt As New DataTable
        'Dim rdv As DataRowView
        Dim dv As New DataView

        If (Not IsViewOnly Or IsAllowSave) Then

            dt = db.query("SELECT cl_id,client FROM dbo.tbl_client ORDER BY client")
            cbo_cl.DisplayMember = "client"
            cbo_cl.ValueMember = "cl_id"
            cbo_cl.DataSource = dt

            Dim opsdep As String = If(uDep = "pr", "bt", "pr")
            dt = db.query("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,department,position FROM dbo.UserData WHERE deactivated = 0 ORDER BY department,username")
            dt.Rows.Add(0, "None", "bt", "prod")
            dt.Rows.Add(0, "None", "pr", "prod")
            dt.Rows.Add(0, "None", "st", "prod")
            dt.Rows.Add(0, "None", "cc", "prod")
            dt.Rows.Add(0, "None", "bt", "sup")
            dt.Rows.Add(0, "None", "pr", "sup")
            dt.Rows.Add(0, "None", "st", "sup")
            dt.Rows.Add(0, "None", "cc", "sup")

            'second PR/BT assigned
            dv = New DataView(dt)
            dv.RowFilter = "department LIKE '" & uDep & "'"
            cbo_second_assigned.DisplayMember = "uname"
            cbo_second_assigned.ValueMember = "Id"
            cbo_second_assigned.DataSource = dv
            cbo_second_assigned.SelectedValue = 0
            'name
            dv = New DataView(dt)
            dv.RowFilter = "department LIKE '" & opsdep & "'"
            cbo_second_assigned.DisplayMember = "uname"
            cbo_second_assigned.ValueMember = "Id"
            cbo_second_assigned.DataSource = dv
            'fixby
            dv = New DataView(dt)
            dv.RowFilter = "department LIKE '" & uDep & "'"
            cbo_second_assigned.DisplayMember = "uname"
            cbo_second_assigned.ValueMember = "Id"
            cbo_second_assigned.DataSource = dv
            'actions by sup
            dv = New DataView(dt)
            dv.RowFilter = "department LIKE '" & opsdep & "' AND position LIKE 'sup'"
            cbo_actby.DisplayMember = "uname"
            cbo_actby.ValueMember = "Id"
            cbo_actby.DataSource = dv
            cbo_actby.SelectedValue = 0

        End If

        'type
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))

        dt.Rows.Add("All", "all")
        dt.Rows.Add("Insurance", "ins")
        dt.Rows.Add("Non-Isurance", "non")

        cbo_type.DisplayMember = "text"
        cbo_type.ValueMember = "value"
        cbo_type.DataSource = dt

        'department
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))

        dt.Rows.Add("All", "all")
        dt.Rows.Add("Business Transcriber", "bt")
        dt.Rows.Add("Proofreader", "pr")
        dt.Rows.Add("BET", "bet")

        cbo_dep.DisplayMember = "text"
        cbo_dep.ValueMember = "value"
        cbo_dep.DataSource = dt

    End Sub

    Public Sub ResetForm()

        cbo_actby.SelectedValue = 0
        cbo_second_assigned.SelectedValue = 0
        cbo_cl.SelectedIndex = 1
        cbo_fxby.SelectedIndex = 1
        cbo_name.SelectedIndex = 1

        txt_ac.Text = ""
        txt_sp.Text = ""
        txt_fn.Text = ""

        rtxt_com1.Text = ""
        rtxt_com2.Text = ""
        rtxt_com3.Text = ""

    End Sub


    Sub exprt()

        Me.Cursor = Cursors.AppStarting

        Dim frmex As frm_export = New frm_export(New String() {uid.ToString, uName, uPos, uDep}, "return")
        frmex.ShowDialog(Me)

        Me.Cursor = Cursors.Default
    End Sub

    Sub save()
        Dim SecondAssigned As String = cbo_second_assigned.SelectedValue.ToString,
        name As String = cbo_name.SelectedValue.ToString,
        fixby As String = cbo_fxby.SelectedValue.ToString,
        actby As String = cbo_actby.SelectedValue.ToString,
        cl As String = cbo_cl.SelectedValue.ToString,
        ac As String = txt_ac.Text, sp As String = txt_sp.Text, fn As String = txt_fn.Text,
        com1 As String = rtxt_com1.Text, com2 As String = rtxt_com2.Text, com3 As String = rtxt_com3.Text

        Dim opsdep As String = If(uDep = "pr", "BT", "PR")

        Dim errmsg As New List(Of String)

        If (cf.IsStringEmpty(name)) Then
            errmsg.Add("-Please select " & opsdep & " Name.")
        End If
        If (cf.IsStringEmpty(fixby)) Then
            errmsg.Add("-Please select File Fixed By.")
        End If
        If (cf.IsStringEmpty(fn)) Then
            errmsg.Add("-Filename is empty.")
        End If

        If errmsg.Count > 0 Then
            MessageBox.Show(Me, String.Join("\n", errmsg.ToArray()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dr As DialogResult = MessageBox.Show(Me, "You are about to send a return file.", "Confirm Return File", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If dr = DialogResult.OK Then

                Me.Cursor = Cursors.AppStarting
                DisableForm(False)

                Dim rf As markform.ReturnFile = New markform.ReturnFile With {
                                                .accuracy = ac,
                                                .specs = sp,
                                                .btpr_comment = com1,
                                                .side_comment = com2,
                                                .comment = com3
                                            }

                tss_status.Text = "Saving..."
                Dim rfo As String = JsonConvert.SerializeObject(rf), tssStr As String = ""
                Dim qryStr As String = "INSERT INTO dbo.tbl_flag_return(user_id,user2_id,btpr_id,fixer_id,act_id,cl_id,filename,dep,type,others,dt_created) VALUES(@user_id,@user2_id,@btpr_id,@fixer_id,@act_id,@cl_id,@filename,@dep,@type,@others,@dt_created)"


                Try

                    Dim qryResult = db.nQuery(qryStr, New String() {"user_id", uid.ToString(), "user2_id", SecondAssigned, "btpr_id", name, "fixer_id", fixby, "act_id", actby, "cl_id", cl, "filename", fn, "dep", uDep, "type", "return", "others", rfo, "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")})

                    If qryResult = 0 Then
                        MessageBox.Show(Me, "Something went wrong while trying to save the return file to the database.", "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        tssStr = "Done!"
                        MessageBox.Show(Me, "Return file successfully send.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult = DialogResult.Yes
                        Dispose()
                    End If

                Catch ex As Exception
                    tssStr = "Error Encountered!"
                    cf.Debug(ex, True, "", "\n\n" + ErrorQuery)
                End Try
                tss_status.Text = tssStr
                DisableForm()
                Me.Cursor = Cursors.Default
                LoadReturn()
            End If
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub cbo_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_type.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub cbo_dep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dep.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub frm_return_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _cnl IsNot Nothing Then
            _cnl.Cancel()
        End If
    End Sub

    Private Sub dtpicker_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker.ValueChanged
        LoadReturn()
    End Sub

    Private Sub dgv_return_Sorted(sender As Object, e As EventArgs) Handles dgv_return.Sorted
        cf.RowsNumber(dgv_return)
    End Sub

    Private Sub frm_return_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = 13 And Not e.Shift Then
            btn_save.PerformClick()
        End If
    End Sub

    Private Sub btn_click(sender As Object, e As EventArgs) Handles btn_del.Click, btn_export.Click, btn_reload.Click, btn_save.Click,
            btn_seen.Click, btn_unseen.Click

        Dim btn As Button = sender : Me.Cursor = Cursors.AppStarting

        Try
            Select Case btn.Name

                Case "btn_del"

                Case "btn_export"
                    exprt()
                Case "btn_reload"
                    LoadReturn()
                Case "btn_save"
                    save()
                Case "btn_seen"

                Case "btn_unseen"

            End Select
        Catch ex As Exception

        End Try

    End Sub

    'add event for button clicks
    'add event for combobox index change

#End Region

#Region "Functions"

    Private Function GetClientID(ByVal cl As String)

        Dim id As Integer = 0
        Dim qry As String = "SELECT cl_id FROM dbo.tbl_client WHERE client LIKE '" + cl + "'", qryr

        Try
            qryr = db.single(qry)
            id = Integer.Parse(qryr)
        Catch ex As Exception
            cf.Debug(ex, True, "", "\n\n" + qry)
        End Try

        Return id
    End Function


#End Region


End Class