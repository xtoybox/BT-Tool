Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports markform
Imports Newtonsoft.Json

Public Class frm_flagging

    Private cf As CustomClass = New CustomClass()
    Private db As SQLClass = New SQLClass()
    Private uid, ulvl As Integer
    Private uname, udep, upos As String, ErrorQry As String = ""
    public _cnl As CancellationTokenSource
    Private CurrentRestriction As String = ""
    Private IsAllowFlagView As Boolean = False
    Private AlloDep As String() = New String() {}
    Private IsAllowDeleteOther As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frm_flagging_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New(ByVal Optional args As String() = Nothing)
        InitializeComponent()

        If args IsNot Nothing Then
            db.LogExceptions = True
            Me.Tag = "flag"
            uid = Integer.Parse(args(0).ToString())
            uname = args(1).ToString()
            upos = args(2).ToString()
            udep = args(3).ToString()
            ulvl = Integer.Parse(args(4).ToString())
            CurrentRestriction = args(5).ToString()
            strip_info.Items.Add("User ID: " & Me.uid)
            strip_info.Items.Add("User Name: " & Me.uname.ToUpper())
            strip_info.Items.Add("User Position: " & cf.GetPositionFull(Me.upos).ToUpper())
            strip_info.Items.Add("User Department: " & Me.udep.ToUpper())
            strip_info.Items.Add("User Level: " & Me.ulvl)

            For Each itm As ToolStripStatusLabel In strip_info.Items
                itm.BorderSides = ToolStripStatusLabelBorderSides.Right
                itm.BorderStyle = Border3DStyle.Flat
                itm.ForeColor = Color.White
            Next

            SetRestrictions()
            SetCboDataSource()
            LoadData()


            cbo_type.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged)
            cbo_dep.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged)
        End If
    End Sub

    Private Sub ActionBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim qryResult As Integer = 0
        Dim msgContent As String = "", msgTitle As String = ""
        Dim Ids As List(Of Integer) = New List(Of Integer)()

        For Each cell As DataGridViewCell In dgv_flag.SelectedCells

            If IsAllowDeleteOther Then
                Ids.Add(Integer.Parse(dgv_flag(7, cell.RowIndex).Value.ToString()))
            Else

                If CInt(dgv_flag(10, cell.RowIndex).Value) = uid Then
                    Ids.Add(Integer.Parse(dgv_flag(7, cell.RowIndex).Value.ToString()))
                End If
            End If
        Next

        Ids = Ids.Distinct().ToList()

        If Ids.Count = 0 Then
            MessageBox.Show(Me, "No item selected" & (If(IsAllowDeleteOther, "", vbLf & " You don't have permission to delete other flag." & vbLf & " Only your own flag is allowed to be deleted.")), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Else
            Dim ws As String = If((Ids.Count > 1), "s", "")
            msgContent = If((btn.Text.ToLower() = "delete"), "You are about to delete " & Ids.Count & " selected item" & ws & "." & (If(IsAllowDeleteOther, "", vbLf & " Only your own flag" & ws & " will be delete.")), "You are about to " & btn.Text.ToLower() & " " + Ids.Count & " selected item" & ws & ".")
            msgTitle = "Confirm " & (If(btn.Text.ToLower() = "delete", "Delete", "Update"))
            Dim dr As DialogResult = MessageBox.Show(Me, msgContent, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If dr = DialogResult.OK Then
                Me.Cursor = Cursors.AppStarting
                DisableForm(False)
                Dim idjoin As String = String.Join(",", Ids.ToArray())
                Dim qry As String = If((btn.Text.ToLower() = "delete"), "DELETE FROM dbo.tbl_flag_return WHERE fid IN (" & idjoin & ")", "UPDATE dbo.tbl_flag_return SET seen = " & (If(btn.Text.ToLower() = "seen", 1, 0)) & " WHERE fid IN (" & idjoin & ")")

                Try
                    qryResult = db.nQuery(qry)

                    If qryResult = 0 Then
                        MessageBox.Show(Me, "Query failed.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End If

                Catch ex As Exception
                    cf.Debug(ex, True, "Something went wrong while trying to execute the query." & vbLf & vbLf & "Query: " & qry)
                End Try

                DisableForm()
                Me.Cursor = Cursors.[Default]
                LoadData()
            End If
        End If
    End Sub


    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyValue = 13 AndAlso Not e.Shift Then
            btn_save.PerformClick()
        End If
    End Sub

    Private Sub frm_flagging_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        If _cnl IsNot Nothing Then
            _cnl.Cancel()
        End If
    End Sub


    Private Sub SetCboDataSource()
        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))
        dt.Rows.Add("All", "all")
        dt.Rows.Add("Insurance", "ins")
        dt.Rows.Add("Non-Insurance", "non")
        cbo_type.DisplayMember = "text"
        cbo_type.ValueMember = "value"
        cbo_type.DataSource = dt
        dt = New DataTable()
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))

        If AlloDep.Length > 1 OrElse AlloDep.Length = 0 Then
            dt.Rows.Add("All", "all")
        End If

        For Each dep As String In AlloDep
            Dim LongName As String = dep.ToUpper()

            Select Case dep
                Case "bt"
                    LongName = "Business Transcirber"
                Case "pr"
                    LongName = "Proofreader"
            End Select

            dt.Rows.Add(LongName, dep)
        Next

        cbo_dep.DisplayMember = "text"
        cbo_dep.ValueMember = "value"
        cbo_dep.DataSource = dt
        dt = New DataTable()
        dt = db.query("SELECT cl_id,client FROM dbo.tbl_client ORDER BY client")
        cbo_client.DisplayMember = "client"
        cbo_client.ValueMember = "cl_id"
        cbo_client.DataSource = dt
    End Sub

    Private Async Sub LoadData()
        _cnl = New CancellationTokenSource()
        Dim token As CancellationToken = _cnl.Token
        db.SQLDependency(False)
        Me.Cursor = Cursors.AppStarting
        Dim newdt As DataTable = New DataTable()
        Dim SelDT As String = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr As String = ""
        tss_status.Text = "Initializing..."
        Dim qryWhere As List(Of String) = New List(Of String)()

        If IsAllowFlagView Then
            qryWhere.Add((If(AlloDep.Length > 0, "dep IN ('" & String.Join("','", AlloDep) & "')", "user_id = " & uid)))
        Else
            qryWhere.Add("user_id = " & uid)
        End If

        qryWhere.Add("type LIKE 'flag' AND CONVERT(date,dt_created) LIKE CONVERT(date,'" & SelDT & "')")
        Dim header As List(Of CustomClass.GridHeaders) = New List(Of CustomClass.GridHeaders)() From {
            New CustomClass.GridHeaders With {
                .index = 0,
                .text = "Seen/Unseen",
                .type = GetType(String),
                .width = 50
            },
            New CustomClass.GridHeaders With {
                .index = 1,
                .text = "Date Submitted",
                .type = GetType(String),
                .width = 60
            },
            New CustomClass.GridHeaders With {
                .index = 2,
                .text = "Username",
                .type = GetType(String),
                .width = 50
            },
            New CustomClass.GridHeaders With {
                .index = 3,
                .text = "Client",
                .type = GetType(String),
                .width = 80
            },
            New CustomClass.GridHeaders With {
                .index = 4,
                .text = "Type",
                .type = GetType(String),
                .width = 80
            },
            New CustomClass.GridHeaders With {
                .index = 5,
                .text = "Filename",
                .type = GetType(String),
                .width = 300
            },
            New CustomClass.GridHeaders With {
                .index = 6,
                .text = "Problem",
                .type = GetType(String),
                .width = 200
            },
            New CustomClass.GridHeaders With {
                .index = 7,
                .text = "fid",
                .type = GetType(Integer),
                .visible = False
            },
            New CustomClass.GridHeaders With {
                .index = 8,
                .text = "dep",
                .type = GetType(String),
                .visible = False
            },
            New CustomClass.GridHeaders With {
                .index = 9,
                .text = "cltype",
                .type = GetType(String),
                .visible = False
            },
            New CustomClass.GridHeaders With {
                .index = 10,
                .text = "userid",
                .type = GetType(Integer),
                .visible = False
            }
        }

        For Each itm In header
            newdt.Columns.Add(itm.text, itm.type)
        Next

        Dim progressHandler As Progress(Of String) = New Progress(Of String)(Function(val)
                                                                                 tss_status.Text = val
                                                                             End Function)
        Dim progress As IProgress(Of String) = CType(progressHandler, IProgress(Of String))

        Try
            Await Task.Run(Function()
                               Dim qry As String = "SELECT fid,user_id,dep,filename,problem,seen," & "CONVERT(varchar(15),CAST(dt_created AS time),100)," & "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," & "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," & "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname FROM dbo.tbl_flag_return AS a " & "WHERE " & String.Join(" AND ", qryWhere.ToArray()) & " ORDER BY Convert(varchar(30), dt_created, 101) DESC"
                               Dim dataTable As DataTable = New DataTable()

                               Try
                                   dataTable = db.query(qry)
                                   token.ThrowIfCancellationRequested()
                               Catch __unusedException1__ As Exception
                                   ErrorQry = qry
                                   Throw
                               End Try

                               Dim x As Integer = 0, cnt As Integer = dataTable.Rows.Count

                               For Each row As DataRow In dataTable.Rows
                                   token.ThrowIfCancellationRequested()
                                   progress.Report("Fetching flags: " & x & " of " & cnt)
                                   Dim obj As Object() = row.ItemArray
                                   Dim seen As String = If((Integer.Parse(obj(5).ToString()) = 0), "Unseen", "Seen"), ins As String = If((obj(8).ToString() = "non"), "Non-Insurance", "Insurance")
                                   newdt.Rows.Add(seen, obj(6), obj(9), obj(7), ins, obj(3), obj(4), obj(0), obj(2), obj(8), Integer.Parse(obj(1).ToString()))
                                   x += 1
                               Next
                           End Function)
            dgv_flag.DataSource = newdt

            For Each itm In header
                dgv_flag.Columns(itm.index).Visible = itm.visible
                dgv_flag.Columns(itm.index).Width = itm.width
            Next

            cf.RowsNumber(dgv_flag)
            tssStr = "Ready!"
            Me.FilterData()
        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.WriteToFile("{0}==>" & ex.ToString() & vbLf & vbLf + ErrorQry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
            MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        tss_status.Text = tssStr
        Me.Cursor = Cursors.[Default]
    End Sub

    Private Sub FilterData()
        Dim type As String = cbo_type.SelectedValue.ToString(), dep As String = cbo_dep.SelectedValue.ToString()
        Dim filter As List(Of String) = New List(Of String)()

        If type <> "all" Then
            filter.Add("cltype LIKE '" & type & "'")
        End If

        If dep <> "all" Then
            filter.Add("dep LIKE '" & dep & "'")
        End If

        Try
        (TryCast(dgv_flag.DataSource, DataTable)).DefaultView.RowFilter = If((filter.Count = 0), "", String.Join(" AND ", filter.ToArray()))
        cf.RowsNumber(dgv_flag)
        Catch ex As Exception
            cf.Debug(ex)
        End Try
    End Sub


    Private Sub DisableForm(ByVal Optional b As Boolean = True)
        tlp_filter_export.Enabled = b
        tlp_flag_form_container.Enabled = b
        tlp_seen_unseen_container.Enabled = b
        dgv_flag.Enabled = b
    End Sub

    Private Sub ResetForm()
        cbo_client.SelectedIndex = 0
        cbo_client.[Select]()
        txt_filename.Text = ""
        rtxt_problem.Text = ""
    End Sub


    Private Sub SetRestrictions()
        Dim flag As Flagging = New Flagging()

        If Not cf.IsStringEmpty(CurrentRestriction) Then

            Try
                Dim urc As UserRestrictionsClass = JsonConvert.DeserializeObject(Of UserRestrictionsClass)(CurrentRestriction)
                flag = urc.Flagging
            Catch ex As Exception
                cf.Debug(ex, True, "Something is wrong with the current restrictions." & vbLf & "Restrictions will revert to default.")
            End Try
        End If

        IsAllowDeleteOther = flag.AllowDelete
        btn_export.Enabled = flag.AllowExport
        btn_save.Enabled = flag.AllowSave
        btn_seen.Enabled = flag.AllowChangeSeen
        btn_unseen.Enabled = flag.AllowChangeSeen
        IsAllowFlagView = flag.AllowViewFlag
        AlloDep = flag.RestrictedDepartment
        cbo_dep.Enabled = IsAllowFlagView
    End Sub

    Private Sub Cbo_SeletedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.FilterData()
    End Sub

    Private Sub btn_save_Click_1(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim clid As Integer = Integer.Parse(cbo_client.SelectedValue.ToString())
        Dim filename As String = txt_filename.Text, probs As String = rtxt_problem.Text, tssStr As String = ""
        tss_status.Text = "Preparing..."
        Dim msg As List(Of String) = New List(Of String)()

        If cf.IsStringEmpty(filename) Then
            msg.Add("-Filename field is empty.")
        End If

        If cf.IsStringEmpty(probs) Then
            msg.Add("Problem field is empty.")
        End If

        If msg.Count > 0 Then
            MessageBox.Show(Me, String.Join(vbLf, msg.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Else
            Dim dr As DialogResult = MessageBox.Show(Me, "You are about to send a flag.", "Confirm Flagging", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If dr = DialogResult.OK Then
                DisableForm(False)
                Cursor = Cursors.AppStarting
                Dim qry As String = "INSERT INTO dbo.tbl_flag_return(user_id,cl_id,filename,problem,dep,type,dt_created) VALUES(@user_id, @cl_id, @filename, @problem, @dep, @type, @dt_created)"
                Dim qryR As Integer = 0

                Try
                    qryR = db.nQuery(qry, New String() {"user_id", uid.ToString(), "cl_id", clid.ToString(), "filename", filename, "problem", probs, "dep", udep, "type", "flag", "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")})
                    tssStr = "Done!"
                    MessageBox.Show(Me, "Success", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ResetForm()
                    Me.LoadData()
                Catch ex As Exception
                    tssStr = "Error Encountered!"
                    cf.WriteToFile("{0}==>" & ex.ToString() & vbLf & vbLf & qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
                    MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try

                DisableForm()
                Cursor = Cursors.[Default]
            End If
        End If
    End Sub

    Private Sub dtpicker_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.LoadData()
    End Sub

    Private Sub dgv_flag_Sorted(ByVal sender As Object, ByVal e As EventArgs)
        cf.RowsNumber(dgv_flag)
    End Sub

    Private Sub btn_reload_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LoadData()
    End Sub

    Private Sub btn_export_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Cursor = Cursors.AppStarting
        Dim frmex As frm_export = New frm_export(New String() {Me.uid.ToString(), Me.uname, Me.upos, Me.udep}, "flag")
        frmex.ShowDialog(Me)
        Me.Cursor = Cursors.[Default]
    End Sub


End Class