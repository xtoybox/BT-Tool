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
    Public _cnl As CancellationTokenSource
    Private CurrentRestriction As String = ""
    Private IsAllowFlagView As Boolean = False
    Private AlloDep As String() = New String() {}
    Private IsAllowDeleteOther As Boolean = False
    Private CustomFn As New CustomFunctions()

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frm_flagging_Load(sender As Object, e As EventArgs, ByVal Optional args As String() = Nothing) Handles MyBase.Load

        CustomFn.FormDrag(Me, Panel2)

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

            'Experimental Conversion 1 ----------------
            'cbo_type.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged);
            'cbo_dep.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged);

        End If

        'InitializeComponent()

        'If args IsNot Nothing Then
        '    db.LogExceptions = True
        '    Me.Tag = "flag"
        '    uid = Integer.Parse(args(0).ToString())
        '    uname = args(1).ToString()
        '    upos = args(2).ToString()
        '    udep = args(3).ToString()
        '    ulvl = Integer.Parse(args(4).ToString())
        '    CurrentRestriction = args(5).ToString()
        '    strip_info.Items.Add("User ID: " & Me.uid)
        '    strip_info.Items.Add("User Name: " & Me.uname.ToUpper())
        '    strip_info.Items.Add("User Position: " & cf.GetPositionFull(Me.upos).ToUpper())
        '    strip_info.Items.Add("User Department: " & Me.udep.ToUpper())
        '    strip_info.Items.Add("User Level: " & Me.ulvl)

        '    For Each itm As ToolStripStatusLabel In strip_info.Items
        '        itm.BorderSides = ToolStripStatusLabelBorderSides.Right
        '        itm.BorderStyle = Border3DStyle.Flat
        '        itm.ForeColor = Color.White
        '    Next

        '    SetRestrictions()
        '    SetCboDataSource()
        '    LoadData()
        'End If
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
                    LongName = "Business Transcriber"
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
            Dim sampleconvertion As IConvertible = (TryCast(dgv_flag.DataSource, DataTable)).DefaultView.RowFilter = If((filter.Count = 0), "", String.Join(" AND ", filter.ToArray()))
            If sampleconvertion Is Nothing Then

            Else
                cf.RowsNumber(dgv_flag)
            End If

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

    Public Sub Cbo_SeletedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
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

    Private Sub dgv_flag_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_flag.CellContentClick

    End Sub

    Private Sub dgv_flag_Sorted(ByVal sender As Object, ByVal e As EventArgs)
        cf.RowsNumber(dgv_flag)
    End Sub

    Private Sub btn_reload_Click_1(sender As Object, e As EventArgs) Handles btn_reload.Click
        Me.LoadData()
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click

    End Sub

    Private Sub btn_seen_Click(sender As Object, e As EventArgs) Handles btn_seen.Click

    End Sub

    Private Sub btn_unseen_Click(sender As Object, e As EventArgs) Handles btn_unseen.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btn_export_Click_1(sender As Object, e As EventArgs) Handles btn_export.Click
        Me.Cursor = Cursors.AppStarting
        Dim frmex As frm_export = New frm_export(New String() {Me.uid.ToString(), Me.uname, Me.upos, Me.udep}, "flag")
        frmex.ShowDialog(Me)
        Me.Cursor = Cursors.[Default]
    End Sub

    ' Experemental conversion 1 =========================

    Private Sub cbo_dep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dep.SelectedIndexChanged
        Me.FilterData()
    End Sub

    Private Sub cbo_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_type.SelectedIndexChanged
        Me.FilterData()
    End Sub

    Private Sub frm_flagging_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd

        If Me.Height <= 561 Then

            Me.Height = 561

        End If

    End Sub
End Class

'Using System;
'Using System.Collections.Generic;
'Using System.ComponentModel;
'Using System.Data;
'Using System.Drawing;
'Using System.Linq;
'Using System.Text;
'Using System.Threading;
'Using System.Threading.Tasks;
'Using System.Windows.Forms;

'Using Newtonsoft.Json;

'Namespace markform
'{
'    Partial Public Class frm_flagging :    Form
'    {
'        #Region Initialize Classes
'        CustomClass cf = New CustomClass();
'        SQLClass db = New SQLClass();
'        #endregion

'        #Region Setting Variables
'        Private int uid, ulvl;
'        Private String uname, udep, upos, ErrorQry = "";
'        Private CancellationTokenSource _cnl;
'        Private String CurrentRestriction = "";
'        /// <summary>
'        /// Allowing user to view other flags aside from the current user's flag.
'        /// If allow then it will base on <seealso cref="AlloDep"/>.
'        /// </summary>
'        Private bool IsAllowFlagView = False;
'        Private String[] AlloDep = New String[] { };
'        /// <summary>
'        /// Allowing user to delete oher flags beside current user flag.
'        /// </summary>
'        Private bool IsAllowDeleteOther = False;
'        #endregion

'        #region Form Class Initialization
'        /// <summary>
'        /// <paramref name="args"/> should contain an array of Array(user id, username, user position, user department, user level,restriction)
'        /// </summary>
'        /// <param name="args"></param>
'        Public frm_flagging(String[] args = null)
'        {
'            InitializeComponent();
'            If (args! = null)
'            {
'                db.LogExceptions = true;//allow to write a log if an SQL error occured.
'                this.Tag = "flag";

'                uid = int.Parse(args[0].ToString());
'                uname = args[1].ToString();
'                upos = args[2].ToString();
'                udep = args[3].ToString();
'                ulvl = int.Parse(args[4].ToString());
'                CurrentRestriction = args[5].ToString();

'                strip_info.Items.Add("User ID: " + this.uid);
'                strip_info.Items.Add("User Name: " + this.uname.ToUpper());
'                strip_info.Items.Add("User Position: " + cf.GetPositionFull(this.upos).ToUpper());
'                strip_info.Items.Add("User Department: " + this.udep.ToUpper());
'                strip_info.Items.Add("User Level: " + this.ulvl);

'                foreach (ToolStripStatusLabel itm in strip_info.Items)
'                {
'                    itm.BorderSides = ToolStripStatusLabelBorderSides.Right;
'                    itm.BorderStyle = Border3DStyle.Flat;
'                    itm.ForeColor = Color.White;
'                }
'                SetRestrictions();
'                SetCboDataSource();
'                LoadData();
'                cbo_type.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged);
'                cbo_dep.SelectedIndexChanged += New EventHandler(Cbo_SeletedItemChanged);
'            }
'        }
'        #endregion

'        #region Events
'        /// <summary>
'        /// Call FilterData() when type Or dep combobox selection Is changed
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void Cbo_SeletedItemChanged(Object sender, EventArgs e)
'        {
'            this.FilterData();
'        }
'        /// <summary>
'        /// Call LoadData() when date Is changed
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void dtpicker_ValueChanged(Object sender, EventArgs e)
'        {
'            this.LoadData();
'        }
'        /// <summary>
'        /// Reinitialize row number when sorting to be always from 1 to n
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void dgv_flag_Sorted(Object sender, EventArgs e)
'        {
'            cf.RowsNumber(dgv_flag);
'        }
'        /// <summary>
'        /// This will call the LoadData();
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void btn_reload_Click(Object sender, EventArgs e)
'        {
'            this.LoadData();
'        }
'        /// <summary>
'        /// Opens the export form
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void btn_export_Click(Object sender, EventArgs e)
'        {
'            this.Cursor = Cursors.AppStarting;

'            frm_export frmex = New frm_export(New String[] { this.uid.ToString(), this.uname, this.upos, this.udep }, "flag");
'            frmex.ShowDialog(this);

'            this.Cursor = Cursors.Default;
'        }
'        /// <summary>
'        /// Saving flag
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void btn_save_Click(Object sender, EventArgs e)
'        {
'            int clid = int.Parse(cbo_client.SelectedValue.ToString());
'            String filename = txt_filename.Text, probs = rtxt_problem.Text, tssStr = "";
'            tss_status.Text = "Preparing...";
'            List<string> msg = New List<string>();
'            If (cf.IsStringEmpty(filename))
'            {
'                msg.Add("-Filename field is empty.");
'            }
'            If (cf.IsStringEmpty(probs))
'            {
'                msg.Add("Problem field is empty.");
'            }

'            If (msg.Count > 0)
'            {
'                MessageBox.Show(this, String.Join("\n", msg.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
'            }
'            Else
'            {
'                DialogResult dr = MessageBox.Show(this, "You are about to send a flag.", "Confirm Flagging", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
'                If (dr == DialogResult.OK)
'                {
'                    DisableForm(false);Cursor = Cursors.AppStarting;
'                    String qry = "INSERT INTO dbo.tbl_flag_return(user_id,cl_id,filename,problem,dep,type,dt_created) VALUES(@user_id, @cl_id, @filename, @problem, @dep, @type, @dt_created)";
'                    int qryR = 0;
'                    Try
'                    {
'                        qryR = db.nQuery(qry,
'                            New string[] { "user_id", uid.ToString(), "cl_id", clid.ToString(), "filename", filename, "problem", probs, "dep", udep, "type", "flag", "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") });
'                        tssStr = "Done!";
'                        MessageBox.Show(this, "Success", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
'                        ResetForm();
'                        this.LoadData();
'                    }
'                    Catch (Exception ex)
'                    {
'                        tssStr = "Error Encountered!";
'                        cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
'                        MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
'                    }
'                    DisableForm(); Cursor = Cursors.Default;
'                }

'            }
'        }
'        /// <summary>
'        /// Event for seen/unseen And delete
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void ActionBtn_Click(Object sender, EventArgs e)
'        {
'            Button btn = (Button)sender;//getting the button that Is being click from the buttons that Is currently bound by this Function

'            int qryResult = 0;
'            String msgContent = "", msgTitle = "";
'            List<int> Ids = New List<int>();
'            //getting the flag ID from the selected items
'            foreach (DataGridViewCell cell in dgv_flag.SelectedCells)
'            {
'                If (IsAllowDeleteOther)
'                {
'                    Ids.Add(int.Parse(dgv_flag[7, cell.RowIndex].Value.ToString()));
'                }
'                Else
'                {
'                    //check if the flag userid [10] Is the same as the current user ID
'                    If ((int)dgv_flag[10,cell.RowIndex].Value == uid) { Ids.Add(int.Parse(dgv_flag[7, cell.RowIndex].Value.ToString())); }
'                }
'            }
'            Ids = Ids.Distinct().ToList();//remove duplicate
'            If (Ids.Count == 0)
'            {
'                MessageBox.Show(this, "No item selected"+(IsAllowDeleteOther?"": "\n You don't have permission to delete other flag.\n Only your own flag is allowed to be deleted."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
'            }
'            Else
'            {
'                String ws = (Ids.Count > 1) ? "s" : "";//adding 's' if the Flag ID is more than 1
'                msgContent = (btn.Text.ToLower() == "delete") ?
'                    "You are about to delete " + Ids.Count + " selected item" + ws + "."+
'                    (IsAllowDeleteOther?"": "\n Only your own flag" + ws + " will be delete.") :
'                    "You are about to " + btn.Text.ToLower() + " " + Ids.Count + " selected item" + ws + ".";
'                msgTitle = "Confirm " + (btn.Text.ToLower() == "delete" ? "Delete" : "Update");

'                DialogResult dr = MessageBox.Show(this, msgContent, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
'                If (dr == DialogResult.OK)
'                {
'                    this.Cursor = Cursors.AppStarting;//change cursor to AppStarting to let the user know that the process running.
'                    DisableForm(false);//disable some form controls while processing the action to prevent the user from making another action just in case the current process takes time to finish

'                    String idjoin = String.Join(",", Ids.ToArray());
'                    String qry = (btn.Text.ToLower() == "delete") ?
'                        "DELETE FROM dbo.tbl_flag_return WHERE fid IN (" + idjoin + ")" :
'                        "UPDATE dbo.tbl_flag_return SET seen = " + (btn.Text.ToLower() == "seen" ? 1  0) + " WHERE fid IN (" + idjoin + ")";
'                    Try
'                    {
'                        qryResult = db.nQuery(qry);
'                        If (qryResult == 0)
'                        {
'                            MessageBox.Show(this, "Query failed.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
'                        }
'                    }
'                    Catch (Exception ex)
'                    {
'                        cf.Debug(ex, true, "Something went wrong while trying to execute the query.\n\nQuery: "+qry);
'                    }

'                    DisableForm();//enable form controls
'                    this.Cursor = Cursors.Default;//change the cursor to default
'                    LoadData();//refresh the datagridview list
'                }
'            }

'        }
'        /// <summary>
'        /// When the control inside the return form Is focus And enter key Is pressed then perform click event on save button.
'        /// </summary>
'        /// <param name="sender"></param>
'        /// <param name="e"></param>
'        Private void Form_KeyDown(Object sender, KeyEventArgs e)
'        {
'            If (e.KeyValue == 13 && !e.Shift)
'            {
'                btn_save.PerformClick();
'            }
'        }
'        Private void frm_flagging_FormClosing(Object sender, FormClosingEventArgs e)
'        {
'            If (_cnl! = null) { _cnl.Cancel(); }
'        }
'        #endregion

'        #region Void Methods
'        /// <summary>
'        /// Populating data to the comboboxes
'        /// </summary>
'        Private void SetCboDataSource()
'        {
'            DataTable dt = New DataTable();
'            //---type---
'            dt.Columns.Add("text", TypeOf(string));
'            dt.Columns.Add("value", TypeOf(string));

'            dt.Rows.Add("All", "all");
'            dt.Rows.Add("Insurance", "ins");
'            dt.Rows.Add("Non-Insurance", "non");

'            cbo_type.DisplayMember = "text";
'            cbo_type.ValueMember = "value";
'            cbo_type.DataSource = dt;

'            //---dep---
'            dt = New DataTable();
'            dt.Columns.Add("text", TypeOf(string));
'            dt.Columns.Add("value", TypeOf(string));

'            If (AlloDep.Length > 1 || AlloDep.Length == 0){dt.Rows.Add("All", "all");}
'            foreach(string dep in AlloDep)
'            {
'                String LongName = dep.ToUpper();
'                switch (dep)
'                {
'                    Case "bt" :   
'                        LongName = "Business Transcirber";
'                        break;
'                    Case "pr" :   
'                        LongName = "Proofreader";
'                        break;
'                }
'                dt.Rows.Add(LongName, dep);
'            }
'            //dt.Rows.Add("Business Transcirber", "bt");
'            //dt.Rows.Add("Proofreader", "pr");
'            //dt.Rows.Add("BET", "bet");

'            cbo_dep.DisplayMember = "text";
'            cbo_dep.ValueMember = "value";
'            cbo_dep.DataSource = dt;

'            //---client---
'            dt = New DataTable();
'            dt = db.query("SELECT cl_id,client FROM dbo.tbl_client ORDER BY client");
'            cbo_client.DisplayMember = "client";
'            cbo_client.ValueMember = "cl_id";
'            cbo_client.DataSource = dt;
'        }
'        /// <summary>
'        /// Population the datagridview
'        /// </summary>
'        Private Async void LoadData()
'        {
'            _cnl = New CancellationTokenSource();
'            CancellationToken token = _cnl.Token;

'            db.SQLDependency(false);

'            this.Cursor = Cursors.AppStarting;
'            DataTable newdt = New DataTable();
'            String SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
'            tss_status.Text = "Initializing...";
'            List<string> qryWhere = New List<string>();

'            If (IsAllowFlagView)
'            {
'                qryWhere.Add((AlloDep.Length > 0? "dep IN ('" + string.Join("','", AlloDep) + "')": "user_id = " + uid));
'            }
'            Else
'            {
'                qryWhere.Add("user_id = " + uid);
'            }


'            qryWhere.Add("type LIKE 'flag' AND CONVERT(date,dt_created) LIKE CONVERT(date,'" + SelDT + "')");
'            List<CustomClass.GridHeaders> header = New List<CustomClass.GridHeaders>()
'            {
'                New CustomClass.GridHeaders{index = 0, text = "Seen/Unseen", type = TypeOf(string), width = 50},
'                New CustomClass.GridHeaders{index = 1, text = "Date Submitted", type = TypeOf(string), width = 60},
'                New CustomClass.GridHeaders{index = 2, text = "Username", type = TypeOf(string), width = 50},
'                New CustomClass.GridHeaders{index = 3, text = "Client", type = TypeOf(string), width = 80},
'                New CustomClass.GridHeaders{index = 4, text = "Type", type = TypeOf(string), width = 80},
'                New CustomClass.GridHeaders{index = 5, text = "Filename", type = TypeOf(string), width = 300},
'                New CustomClass.GridHeaders{index = 6, text = "Problem", type = TypeOf(string), width = 200},
'                New CustomClass.GridHeaders{index = 7, text = "fid", type = TypeOf(int), visible = false},
'                New CustomClass.GridHeaders{index = 8, text = "dep", type = TypeOf(string), visible = false},
'                New CustomClass.GridHeaders{index = 9, text = "cltype", type = TypeOf(string), visible = false},
'                New CustomClass.GridHeaders{index = 10, text = "userid", type = TypeOf(int), visible = false}
'            };
'            foreach (var itm in header)
'            {
'                newdt.Columns.Add(itm.text, itm.type);
'            }
'            Progress<string> progressHandler = New Progress<string>(val => { tss_status.Text = val; });
'            IProgress<string> progress = (IProgress<string>)progressHandler;

'            Try
'            {
'                await Task.Run(() => {
'                    String qry = "SELECT fid,user_id,dep,filename,problem,seen," +
'                    "CONVERT(varchar(15),CAST(dt_created AS time),100)," +
'                    "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," +
'                    "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," +
'                    "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname FROM dbo.tbl_flag_return AS a " +
'                    "WHERE " + String.Join(" AND ", qryWhere.ToArray()) + " ORDER BY Convert(varchar(30), dt_created, 101) DESC";
'                    DataTable dataTable = New DataTable();
'                    Try
'                    {
'                        dataTable = db.query(qry);
'                        token.ThrowIfCancellationRequested();
'                    }
'                    Catch (Exception)
'                    {
'                        ErrorQry = qry;
'                        Throw;
'                    }

'                    int x = 0, cnt = dataTable.Rows.Count;
'                    foreach (DataRow row in dataTable.Rows)
'                    {
'                        token.ThrowIfCancellationRequested();
'                        progress.Report("Fetching flags: " + x + " of " + cnt);
'                        Object[] obj = row.ItemArray;
'                        String seen = (int.Parse(obj[5].ToString()) == 0) ? "Unseen" : "Seen",
'                        ins = (obj[8].ToString() == "non") ? "Non-Insurance" : "Insurance";
'                        newdt.Rows.Add(seen, obj[6], obj[9], obj[7], ins, obj[3], obj[4], obj[0], obj[2], obj[8],int.Parse(obj[1].ToString()));
'                        x++;
'                    }
'                });
'                dgv_flag.DataSource = newdt;
'                foreach (var itm in header)
'                {
'                    dgv_flag.Columns[itm.index].Visible = itm.visible;
'                    dgv_flag.Columns[itm.index].Width = itm.width;
'                }
'                cf.RowsNumber(dgv_flag);
'                tssStr = "Ready!";
'                this.FilterData();
'            }
'            Catch (Exception ex)
'            {
'                tssStr = "Error Encountered!";
'                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + ErrorQry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
'                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
'            }
'            tss_status.Text = tssStr;
'            this.Cursor = Cursors.Default;
'        }

'        Private void frm_flagging_Load(Object sender, EventArgs e)
'        {

'        }

'        Private void dgv_flag_CellContentClick(Object sender, DataGridViewCellEventArgs e)
'        {

'        }

'        /// <summary>
'        /// Filter data
'        /// </summary>
'        Private void FilterData()
'        {
'            String type = cbo_type.SelectedValue.ToString(),
'                dep = cbo_dep.SelectedValue.ToString();

'            List<string> filter = New List<string>();
'            If (type! = "all")
'            {
'                filter.Add("cltype LIKE '" + type + "'");
'            }
'            If (dep! = "all")
'            {
'                filter.Add("dep LIKE '" + dep + "'");
'            }
'            //Console.Write(string.Join(" AND ", filter.ToArray()));
'            Try
'            {
'                (dgv_flag.DataSource as DataTable).DefaultView.RowFilter = (filter.Count == 0) ? "" : String.Join(" AND ", filter.ToArray());
'                cf.RowsNumber(dgv_flag);
'            }
'            Catch (Exception ex)
'            {
'                cf.Debug(ex);
'            }

'        }
'        /// <summary>
'        /// Enable/Disable form after a certain action
'        /// </summary>
'        /// <param name="b"></param>
'        Private void DisableForm(bool b = True)
'        {
'            tlp_filter_export.Enabled = b;
'            tlp_flag_form_container.Enabled = b;
'            tlp_seen_unseen_container.Enabled = b;
'            dgv_flag.Enabled = b;
'        }
'        /// <summary>
'        /// Reset form to default after saving
'        /// </summary>
'        Private void ResetForm()
'        {
'            cbo_client.SelectedIndex = 0;
'            cbo_client.Select();
'            txt_filename.Text = "";
'            rtxt_problem.Text = "";
'        }
'        /// <summary>
'        /// Setting the restriction for the current user
'        /// </summary>
'        Private void SetRestrictions()
'        {
'            Flagging flag = New Flagging();
'            If (!cf.IsStringEmpty(CurrentRestriction))
'            {
'                Try
'                {
'                    UserRestrictionsClass urc = JsonConvert.DeserializeObject < UserRestrictionsClass > (CurrentRestriction);
'                    flag = urc.Flagging;
'                }
'                Catch (Exception ex)
'                {
'                    cf.Debug(ex,true,"Something is wrong with the current restrictions.\nRestrictions will revert to default.");
'                }

'            }
'            IsAllowDeleteOther = flag.AllowDelete;
'            btn_export.Enabled = flag.AllowExport;
'            btn_save.Enabled = flag.AllowSave;
'            btn_seen.Enabled = flag.AllowChangeSeen;
'            btn_unseen.Enabled = flag.AllowChangeSeen;
'            IsAllowFlagView = flag.AllowViewFlag;
'            AlloDep = flag.RestrictedDepartment;
'            cbo_dep.Enabled = IsAllowFlagView;
'        }
'        #endregion

'        #region Functions

'        #endregion
'    }
'}
