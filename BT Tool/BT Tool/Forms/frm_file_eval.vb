Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.IO
Imports Newtonsoft.Json

Public Class frm_file_eval

#Region "Classes"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
    Private ur As New markform.UserRestrictionsClass
#End Region

#Region "Variables"
    Private btid As Integer, fid As Integer, uid As Integer, evaluwee_uid As Integer, evalid As Integer, evaluator_uid As Integer
    Private uname As String, upos As String, udep As String, evaluwee_name As String, evaluwee_pos As String, evaluwee_dep As String,
        filename As String, ComparesStoragePath As String = "\\Pdx-fs\mediafiles\Jeff\06 IT PEOPLE\MARK\bt_compares\",
        ComparesFileName As String = "", ErrorQry As String = "",
        ComparesPath As String = "", CurUserRestriction As String = ""
    Public Event yeet As EventHandler
    Private _cnl As CancellationTokenSource
    Dim ViewDep = New String() {}
    Private IsAllowViewEval As Boolean = False
#End Region


#Region "Sub"

    Public Sub New(ByVal args As Object(), ByVal viewtype As String, ByVal restriction As String)

        ' This call is required by the designer.
        InitializeComponent()

        If args IsNot Nothing Then

            uid = Integer.Parse(args(0).ToString)
            uname = args(1).ToString
            upos = args(2).ToString
            udep = args(3).ToString
            CurUserRestriction = restriction
            btid = 0
            Me.fid = 0
            Tag = viewtype
            sb_info.Items.Add("User ID: " & Me.uid)
            sb_info.Items.Add("User Name: " & Me.uname.ToUpper)
            sb_info.Items.Add("User Position: " & cf.GetPositionFull(Me.upos).ToUpper)
            sb_info.Items.Add("User Department: " & Me.udep.ToUpper)

            For Each itm As ToolStripStatusLabel In sb_info.Items
                itm.BorderSides = ToolStripStatusLabelBorderSides.All
                itm.BorderStyle = Border3DStyle.Sunken
            Next

            Me.SetCboDataSource()

            If viewtype Is "save" Then
                Me.btid = Integer.Parse(args(4).ToString)
                Me.fid = Integer.Parse(args(5).ToString)
                Me.ComparesPath = args(7).ToString
                evaluator_uid = Me.uid
                txt_filename.Text = args(6).ToString
                txt_compares.Text = Me.ComparesPath
                filename = args(6).ToString
                cbo_accounts.SelectedValue = Me.GetClientID(args(8).ToString)
                cbo_accounts.Visible = False
                lbl_accounts_cbo.Visible = True
                lbl_accounts_cbo.Text = cbo_accounts.Text
                btn_save.Visible = True
                Set_EvaluweeInfo()
                ScoreCalculator()
                tlp_evaluator_evaluwee_container.Visible = False
                txt_words.Text = args(9).ToString
                txt_mistakes.Text = args(10).ToString
            ElseIf viewtype Is "view" Then
                Me.Text = Me.Text & "[View Only]"
                tlp_1.Visible = True
                tlp_2.Visible = True

                If IsAllowViewEval AndAlso ViewDep.Length > 0 Then
                    DisplayUserList
                End If
            Else
                Me.Text = "My Evaluation"
                tlp_2.Visible = True
                pnl_mycontrol_container.Visible = True
                Me.EnabledControls(False)
                Me.DisplayEvals
                lbl_name_label.Visible = False
                lbl_evaluwee.Visible = False
            End If

            SetRestrictions


        End If

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SetCboDataSource()
        Dim dt As DataTable = New DataTable
        cbo_accounts.DisplayMember = "client"
        cbo_accounts.ValueMember = "cl_id"
        cbo_accounts.DataSource = db.query("SELECT cl_id, client FROM dbo.tbl_client ORDER BY client")
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Integer))
        dt.Rows.Add("Bad", 1)
        dt.Rows.Add("Fair", 2)
        dt.Rows.Add("Good", 3)
        dt.Rows.Add("Very Good", 4)
        dt.Rows.Add("Excellent", 5)
        cbo_aq.DisplayMember = "text"
        cbo_aq.ValueMember = "value"
        cbo_aq.DataSource = dt
        cbo_aq.SelectedValue = 3
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Met all requirements", 1.11)
        dt.Rows.Add("Did not meet 1 requirement", 0.833333333)
        dt.Rows.Add("Did not meet 2 requirements", 0.556666667)
        dt.Rows.Add("Did not meet 3 requirements", 0.28)
        dt.Rows.Add("Failed to meet all requirements", 0)
        cbo_q1_1.DisplayMember = "text"
        cbo_q1_1.ValueMember = "value"
        cbo_q1_1.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Yes", 0.553333333)
        dt.Rows.Add("No", 0)
        cbo_q1_2.DisplayMember = "text"
        cbo_q1_2.ValueMember = "value"
        cbo_q1_2.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Yes", 0.666666667)
        dt.Rows.Add("No", 0)
        cbo_q2_1.DisplayMember = "text"
        cbo_q2_1.ValueMember = "value"
        cbo_q2_1.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Excellent", 2)
        dt.Rows.Add("Very Good", 1.75)
        dt.Rows.Add("Good", 1.5)
        dt.Rows.Add("Okay", 1.25)
        dt.Rows.Add("Fair", 1)
        dt.Rows.Add("Weak to Fair", 0.75)
        dt.Rows.Add("Weak", 0.5)
        dt.Rows.Add("Poor", 0.25)
        dt.Rows.Add("Fail", 0)
        cbo_q2_2.DisplayMember = "text"
        cbo_q2_2.ValueMember = "value"
        cbo_q2_2.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Excellent", 4.666666667)
        dt.Rows.Add("Very Good", 4)
        dt.Rows.Add("Good", 3.333333333)
        dt.Rows.Add("Okay", 2.666666667)
        dt.Rows.Add("Fair", 2)
        dt.Rows.Add("Weak to Fair", 1.333333333)
        dt.Rows.Add("Weak", 0.666666667)
        dt.Rows.Add("Poor", 0.333333333)
        dt.Rows.Add("Fail", 0)
        cbo_q3_1.DisplayMember = "text"
        cbo_q3_1.ValueMember = "value"
        cbo_q3_1.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("Yes", 1)
        dt.Rows.Add("No", 0)
        cbo_q3_2.DisplayMember = "text"
        cbo_q3_2.ValueMember = "value"
        cbo_q3_2.DataSource = dt
        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(Double))
        dt.Rows.Add("No", 30.004)
        dt.Rows.Add("Yes", 0.00)
        cbo_q4.DisplayMember = "text"
        cbo_q4.ValueMember = "value"
        cbo_q4.DataSource = dt
    End Sub

    Private Sub Set_EvaluweeInfo()
        Try
            Dim qry As String() = db.row("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,department,position FROM dbo.UserData WHERE Id = " & btid)
            evaluwee_uid = Integer.Parse(qry(0))
            evaluwee_name = qry(1)
            evaluwee_dep = qry(2)
            evaluwee_pos = qry(3)
        Catch ex As Exception
            cf.Debug(ex, True, "Failed to get the evaluwee info.")
        End Try
    End Sub

    'Private Sub SetEventHandler()
    '    cbo_q1_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q1_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q2_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q2_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q3_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q3_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    '    Me.cbo_q4.SelectedIndexChanged += cbo_q_SelectedIndexChanged()
    'End Sub

    Private Sub cbo_q_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.ScoreCalculator()
    End Sub

    Private Sub ScoreCalculator()

        Dim q1_1 = Double.Parse(cbo_q1_1.SelectedValue.ToString)
        Dim q1_2 = Double.Parse(cbo_q1_2.SelectedValue.ToString)
        Dim q2_1 = Double.Parse(cbo_q2_1.SelectedValue.ToString)
        Dim q2_2 = Double.Parse(cbo_q2_2.SelectedValue.ToString)
        Dim q3_1 = Double.Parse(cbo_q3_1.SelectedValue.ToString)
        Dim q3_2 = Double.Parse(cbo_q3_2.SelectedValue.ToString)
        Dim q4 = Double.Parse(cbo_q4.SelectedValue.ToString)

        Dim Q1Score = 0.00, Q2Score = 0.00, Q3Score = 0.00, TotalScore = 0.00

        If q4 = 0 Then
            TotalScore = q4
        Else
            Q1Score = (q1_1 + q1_2) * 3
            Q2Score = (q2_1 + q2_2) * 3
            Q3Score = (q3_1 + q3_2) * 3 + 0.01
            TotalScore = Q1Score + Q2Score + Q3Score
        End If

        lbl_q1_score.Text = Q1Score.ToString("0.00")
        lbl_q2_score.Text = Q2Score.ToString("0.00")
        lbl_q3_score.Text = Q3Score.ToString("0.00")
        lbl_score.Text = TotalScore.ToString("0.00")
        Dim scoretxt = ""
        Dim scoretxtcolor As Color = Color.FromArgb(0, 138, 0)
        Dim score As Double = Math.Floor(TotalScore)

        Select Case True
            Case score = 30 Or score > 29
                scoretxt = "Excellent" : scoretxtcolor = Color.FromArgb(0, 138, 0)
            Case score <= 29 Or score > 27
                scoretxt = "Very Good" : scoretxtcolor = Color.FromArgb(96, 169, 23)
            Case score <= 27 Or score > 25
                scoretxt = "Good" : scoretxtcolor = Color.FromArgb(164, 196, 0)
            Case score <= 25 Or score > 23
                scoretxt = "Okay" : scoretxtcolor = Color.FromArgb(51, 51, 51)
            Case score <= 23 Or score > 22
                scoretxt = "Fair" : scoretxtcolor = Color.FromArgb(85, 85, 85)
            Case score <= 22 Or score > 21
                scoretxt = "Weak to Fair" : scoretxtcolor = Color.FromArgb(153, 153, 153)
            Case score <= 21 Or score > 20
                scoretxt = "Weak" : scoretxtcolor = Color.FromArgb(227, 200, 0)
            Case score <= 20 Or score > 19
                scoretxt = "Poor" : scoretxtcolor = Color.FromArgb(240, 163, 10)
            Case score <= 19
                scoretxt = "Fail" : scoretxtcolor = Color.FromArgb(162, 0, 37)
        End Select
        lbl_score_txt.Text = scoretxt
        lbl_score_txt.ForeColor = scoretxtcolor

    End Sub

    Private Sub DisplayUserList()

        Dim evalcnt As String, pos As String
        Dim userid As Integer

        Me.Cursor = Cursors.AppStarting
        tssl_status.Visible = True
        tssl_status.Text = "Fetching user data..."
        Dim SelDT As String = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = ""
        Dim btdt As DataTable = New DataTable, prdt As DataTable = New DataTable, betdt As DataTable = New DataTable
        Dim headers As New List(Of GridHeaders)()
        headers.Add(New GridHeaders() With {.index = 0, .text = "Name", .width = 100, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 1, .text = "Evals", .width = 100, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 2, .text = "Dep", .width = 0, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 3, .text = "Pos", .width = 0, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 4, .text = "UserID", .width = 0, .type = GetType(Integer)})

        Dim dgvdata = New List(Of DGVData)

        If ViewDep.Contains("bt") Then
            dgvdata.Add(New DGVData With {
                .dgv = dgv_bt,
                .dataTable = btdt
            })
        ElseIf ViewDep.Contains("pr") Then
            dgvdata.Add(New DGVData With {
                .dgv = dgv_bt,
                .dataTable = prdt
            })
        ElseIf ViewDep.Contains("bet") Then
            dgvdata.Add(New DGVData With {
                .dgv = dgv_bt,
                .dataTable = betdt
            })
        End If

        For Each dgvd In dgvdata
            For Each hdata In headers
                dgvd.dataTable.Columns.Add(hdata.text, hdata.type)
            Next
        Next

        Try
            Dim qry As String = "SELECT Id, UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname, " +
                "position, department, status,(SELECT COUNT(eid) FROM dbo.tbl_btpr_eval WHERE user_id = Id AND " +
                "CONVERT(date, dt_created) LIKE CONVERT(date, '" + SelDT + "')) AS cnt FROM dbo.UserData WHERE " +
                "department IN('" + String.Join("','", ViewDep) + "') AND deactivated = 0 ORDER " +
                "BY CASE department WHEN 'bt' THEN 1 WHEN 'pr' THEN 2 WHEN 'bet' THEN 3 ELSE 4 END, username"
            Dim dt As DataTable
            dt = db.query(qry)
            Dim depArr As String() = ViewDep

            For Each rows As DataRow In dt.Rows
                Dim obj As Object() = rows.ItemArray
                Dim dep As String = obj(3).ToString
                uname = obj(1).ToString
                pos = obj(2).ToString
                evalcnt = If(CInt(obj(5)) <> 0, obj(5).ToString, "")
                userid = CInt(obj(1))
                dgvdata(Array.IndexOf(depArr, dep)).dataTable.Rows.Add(uname, evalcnt, dep, pos, userid)
            Next

            For Each dgvd In dgvdata
                dgvd.dgv.DataSource = dgvd.dataTable
                dgvd.dgv.ClearSelection()
                For Each hdata In headers
                    dgvd.dgv.Columns(hdata.index).Visible = hdata.visible
                    dgvd.dgv.Columns(hdata.index).Width = hdata.width
                Next
            Next
            tssStr = "Ready!"

        Catch ex As Exception
            tssStr = "Error Occured!"
            cf.Debug(ex, True, "", ErrorQry)
        End Try

        tssl_status.Text = tssStr
        Me.Cursor = Cursors.Default
    End Sub


    Private Async Sub DisplayEvals()

        Dim _cnl As New CancellationTokenSource
        Dim token As CancellationToken = _cnl.Token
        Dim qry As String : Dim userID As Integer = 0
        tssl_status.Visible = True : tssl_status.Text = "Fetching eval data..."
        Me.Cursor = Cursors.AppStarting

        'Dim dtpcker As DateTimePicker = 
        Dim dtpcker As DateTimePicker = If(Me.Tag.ToString Is "view", Me.dtpicker, Me.dt_mypicker)
        Dim SelDT As String = dtpcker.Value.Date.ToString("MM/dd/yyyy"), tssStr = ""
        Dim usrID As Integer = If(Me.Tag.ToString Is "view", userID, Me.uid)
        Dim newdt As New DataTable
        Dim headers As New List(Of GridHeaders)()

        headers.Add(New GridHeaders() With {.index = 0, .text = "Eval", .width = 100, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 1, .text = "Score", .width = 100, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 2, .text = "evaluatorID", .width = 0, .type = GetType(Integer), .visible = False})
        headers.Add(New GridHeaders() With {.index = 3, .text = "eid", .width = 0, .type = GetType(Integer), .visible = False})
        headers.Add(New GridHeaders() With {.index = 4, .text = "accounts", .width = 0, .type = GetType(Integer), .visible = False})
        headers.Add(New GridHeaders() With {.index = 5, .text = "filename", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 6, .text = "aq", .width = 0, .type = GetType(Integer), .visible = False})
        headers.Add(New GridHeaders() With {.index = 7, .text = "filepath", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 8, .text = "other", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 9, .text = "q1", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 10, .text = "q2", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 11, .text = "q3", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 12, .text = "q4", .width = 0, .type = GetType(String), .visible = False})
        headers.Add(New GridHeaders() With {.index = 13, .text = "dt", .width = 0, .type = GetType(String), .visible = False})

        For Each h In headers
            newdt.Columns.Add(h.text, h.type)
        Next h


        Dim progressHandler = New Progress(Of String)(Function(val)
                                                          tssl_status.Text = val
                                                      End Function)
        Dim progress As IProgress(Of String) = progressHandler

        Try
            Await Task.Run(
                Sub()
                    qry = "SELECT eid,user_id,eval_user_id," +
                        "(SELECT UPPER(LEFT(username, 1)) + LOWER(SUBSTRING(username, 2, LEN(username))) FROM dbo.UserData WHERE Id = eval_user_id) AS uname," +
                        "dep, filename, filepath, cl_id, autofail, q1, q2, q3, audio_quality, total_score, other, dt_created FROM dbo.tbl_btpr_eval WHERE user_id = " + userID + " AND CONVERT(date, dt_created) LIKE CONVERT(date, '" + SelDT + "')"

                    Dim dt As DataTable = New DataTable
                    Try
                        dt = db.query(qry)
                        token.ThrowIfCancellationRequested()
                    Catch ex As Exception
                        ErrorQry = qry
                        Throw
                    End Try
                    Dim x As Int16 = 0, cnt = dt.Rows.Count
                    For Each row As DataRow In dt.Rows
                        token.ThrowIfCancellationRequested()
                        progress.Report("Evals: " + x + " of " + cnt)
                        Dim obj As Object() = row.ItemArray
                        newdt.Rows.Add(obj(3), obj(13), obj(2), obj(0), obj(7), obj(5), obj(12), obj(6), obj(14), obj(9), obj(10), obj(11), obj(8), obj(15))
                    Next
                End Sub)
            dgv_eval_list.DataSource = newdt
            For Each h In headers
                dgv_eval_list.Columns(h.index).Visible = h.visible
                dgv_eval_list.Columns(h.index).Width = h.width
            Next h
            dgv_eval_list.ClearSelection()
            tssStr = "Ready!"
        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.Debug(ex, True, "", ErrorQry)
        End Try
        ErrorQry = ""
        tssl_status.Text = tssStr
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SetRestrictions()
        Dim fe As markform.FileEval = New markform.FileEval

        If Not cf.IsStringEmpty(CurUserRestriction) Then

            Try
                Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(CurUserRestriction)
                fe = urc.FileEval
            Catch ex As Exception
                cf.Debug(ex, True, "Something is wrong with the current restrictions." & vbLf & "Restrictions will revert to default.")
            End Try
        End If

        EnabledControls(fe.AllowCreateEval)
        btn_export.Enabled = fe.AllowExport
        tc_dep.Enabled = fe.AllowViewEval
        IsAllowViewEval = fe.AllowViewEval
    End Sub

    Private Sub EnabledControls(ByVal Optional b As Boolean = True)
        Dim rdonly As Boolean = Not b
        Dim lblarr = New Label() {lbl_accounts_cbo, lbl_aq_cbo, lbl_q1_1_cbo, lbl_q1_2_cbo, lbl_q2_1_cbo, lbl_q2_2_cbo, lbl_q3_1_cbo, lbl_q3_2_cbo, lbl_q4_cbo}
        Dim cboarr = New ComboBox() {cbo_accounts, cbo_aq, cbo_q1_1, cbo_q1_2, cbo_q2_1, cbo_q2_2, cbo_q3_1, cbo_q3_2, cbo_q4}
        Dim index = 0

        For Each cbo As ComboBox In cboarr
            cbo.Visible = b

            If rdonly Then
                lblarr(index).Visible = True
                lblarr(index).Text = cbo.Text
            End If

            index += 1
        Next

        txt_filename.ReadOnly = rdonly
        txt_compares.ReadOnly = rdonly
        txt_mistakes.ReadOnly = rdonly
        txt_words.ReadOnly = rdonly
        rtxt_q1_1.ReadOnly = rdonly
        rtxt_q1_2.ReadOnly = rdonly
        rtxt_q2_1.ReadOnly = rdonly
        rtxt_q2_2.ReadOnly = rdonly
        rtxt_q3_1.ReadOnly = rdonly
        rtxt_q3_2.ReadOnly = rdonly
        rtxt_q4.ReadOnly = rdonly
    End Sub

    Private Sub CboReadOnlyAlt()
        Dim lblarr = New Label() {lbl_accounts_cbo, lbl_aq_cbo, lbl_q1_1_cbo, lbl_q1_2_cbo, lbl_q2_1_cbo, lbl_q2_2_cbo, lbl_q3_1_cbo, lbl_q3_2_cbo, lbl_q4_cbo}
        Dim cboarr = New ComboBox() {cbo_accounts, cbo_aq, cbo_q1_1, cbo_q1_2, cbo_q2_1, cbo_q2_2, cbo_q3_1, cbo_q3_2, cbo_q4}
        Dim index = 0

        For Each cbo As ComboBox In cboarr
            lblarr(index).Text = cbo.Text
            index += 1
        Next
    End Sub

#End Region

#Region "Events"
    Private Sub cbo_q1_1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_q1_1.SelectedIndexChanged, cbo_q1_2.SelectedIndexChanged, cbo_q2_1.SelectedIndexChanged,
                                                                                    cbo_q2_2.SelectedIndexChanged, cbo_q3_1.SelectedIndexChanged, cbo_q3_2.SelectedIndexChanged,
                                                                                    cbo_q4.SelectedIndexChanged

        Me.ScoreCalculator()

    End Sub
#End Region

#Region "Functions"
    Private Function GetClientID(ByVal cl As String) As Integer
        Dim id = 0
        Dim qryr As String, qry = "SELECT cl_id FROM dbo.tbl_client WHERE client LIKE '" & cl & "'"

        Try
            qryr = db.single(qry)
            id = Integer.Parse(qryr)
        Catch ex As Exception
            cf.Debug(ex, True, "", qry)
        End Try

        Return id
    End Function
#End Region

    Public Class DGVData
        Public Property dgv As DataGridView
        Public Property dataTable As DataTable
    End Class

End Class