<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Animation3 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Animation2 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation1 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_main))
        Me.Dashboard_pnl = New System.Windows.Forms.Panel()
        Me.btn_loginout = New System.Windows.Forms.Button()
        Me.btn_workflow = New System.Windows.Forms.Button()
        Me.btn_userlist = New System.Windows.Forms.Button()
        Me.btn_files_due = New System.Windows.Forms.Button()
        Me.btn_wait_tracker = New System.Windows.Forms.Button()
        Me.btn_idle_tracker = New System.Windows.Forms.Button()
        Me.btn_ratio_tracker = New System.Windows.Forms.Button()
        Me.btn_flagging = New System.Windows.Forms.Button()
        Me.btn_viewreturn = New System.Windows.Forms.Button()
        Me.btn_monitoring = New System.Windows.Forms.Button()
        Me.btn_file_eval = New System.Windows.Forms.Button()
        Me.btn_myeval = New System.Windows.Forms.Button()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.User_Btn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Exit_btn = New System.Windows.Forms.Button()
        Me.BunifuTransition1 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_break = New System.Windows.Forms.Button()
        Me.btn_return = New System.Windows.Forms.Button()
        Me.btn_hold = New System.Windows.Forms.Button()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_submit = New System.Windows.Forms.Button()
        Me.Main_pnl = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.gbox_file_info = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.cbo_service = New System.Windows.Forms.DateTimePicker()
        Me.txt_accuracy = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_page = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_duration = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_receive = New System.Windows.Forms.TextBox()
        Me.txt_branch = New System.Windows.Forms.TextBox()
        Me.txt_client = New System.Windows.Forms.TextBox()
        Me.txt_due = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbox_work_file = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_Doc = New System.Windows.Forms.Button()
        Me.txt_document = New System.Windows.Forms.TextBox()
        Me.btn_Audio = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_audio = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gbox_players = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.rd_pepsup = New System.Windows.Forms.RadioButton()
        Me.rd_acqt = New System.Windows.Forms.RadioButton()
        Me.rd_express = New System.Windows.Forms.RadioButton()
        Me.gbox_prio = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.chk_blank = New System.Windows.Forms.CheckBox()
        Me.chk_rush = New System.Windows.Forms.CheckBox()
        Me.GboxUList = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbo_qapr = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbo_qabt = New System.Windows.Forms.ComboBox()
        Me.cbo_bt = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbo_pr = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbo_qacc = New System.Windows.Forms.ComboBox()
        Me.cbo_qast = New System.Windows.Forms.ComboBox()
        Me.cbo_cc = New System.Windows.Forms.ComboBox()
        Me.cbo_st = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnl_header = New System.Windows.Forms.Panel()
        Me.main_gridview = New System.Windows.Forms.DataGridView()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.User_Pnl = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_file = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_reference = New System.Windows.Forms.Button()
        Me.btn_break_log = New System.Windows.Forms.Button()
        Me.btn_report_log = New System.Windows.Forms.Button()
        Me.btn_archive = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.BunifuTransition2 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition3 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.IdleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.WaitTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BWTimer = New System.ComponentModel.BackgroundWorker()
        Me.Dashboard_pnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Main_pnl.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.gbox_file_info.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.gbox_work_file.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.gbox_players.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.gbox_prio.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GboxUList.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.pnl_header.SuspendLayout()
        CType(Me.main_gridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.User_Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dashboard_pnl
        '
        Me.Dashboard_pnl.BackColor = System.Drawing.Color.Black
        Me.Dashboard_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dashboard_pnl.Controls.Add(Me.btn_loginout)
        Me.Dashboard_pnl.Controls.Add(Me.btn_workflow)
        Me.Dashboard_pnl.Controls.Add(Me.btn_userlist)
        Me.Dashboard_pnl.Controls.Add(Me.btn_files_due)
        Me.Dashboard_pnl.Controls.Add(Me.btn_wait_tracker)
        Me.Dashboard_pnl.Controls.Add(Me.btn_idle_tracker)
        Me.Dashboard_pnl.Controls.Add(Me.btn_ratio_tracker)
        Me.Dashboard_pnl.Controls.Add(Me.btn_flagging)
        Me.Dashboard_pnl.Controls.Add(Me.btn_viewreturn)
        Me.Dashboard_pnl.Controls.Add(Me.btn_monitoring)
        Me.Dashboard_pnl.Controls.Add(Me.btn_file_eval)
        Me.Dashboard_pnl.Controls.Add(Me.btn_myeval)
        Me.BunifuTransition1.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.Dashboard_pnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.Dashboard_pnl.Location = New System.Drawing.Point(0, 43)
        Me.Dashboard_pnl.Name = "Dashboard_pnl"
        Me.Dashboard_pnl.Size = New System.Drawing.Size(174, 648)
        Me.Dashboard_pnl.TabIndex = 1
        '
        'btn_loginout
        '
        Me.btn_loginout.BackColor = System.Drawing.Color.Black
        Me.btn_loginout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_loginout, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_loginout, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_loginout, BunifuAnimatorNS.DecorationType.None)
        Me.btn_loginout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_loginout.FlatAppearance.BorderSize = 0
        Me.btn_loginout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_loginout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_loginout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_loginout.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_loginout.ForeColor = System.Drawing.Color.White
        Me.btn_loginout.Image = CType(resources.GetObject("btn_loginout.Image"), System.Drawing.Image)
        Me.btn_loginout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_loginout.Location = New System.Drawing.Point(0, 596)
        Me.btn_loginout.Name = "btn_loginout"
        Me.btn_loginout.Size = New System.Drawing.Size(172, 50)
        Me.btn_loginout.TabIndex = 19
        Me.btn_loginout.Text = "Logout"
        Me.btn_loginout.UseVisualStyleBackColor = False
        '
        'btn_workflow
        '
        Me.btn_workflow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_workflow, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_workflow, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_workflow, BunifuAnimatorNS.DecorationType.None)
        Me.btn_workflow.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_workflow.FlatAppearance.BorderSize = 0
        Me.btn_workflow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_workflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_workflow.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_workflow.ForeColor = System.Drawing.Color.White
        Me.btn_workflow.Image = CType(resources.GetObject("btn_workflow.Image"), System.Drawing.Image)
        Me.btn_workflow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_workflow.Location = New System.Drawing.Point(0, 470)
        Me.btn_workflow.Name = "btn_workflow"
        Me.btn_workflow.Size = New System.Drawing.Size(172, 47)
        Me.btn_workflow.TabIndex = 11
        Me.btn_workflow.Text = "   Work Flow"
        Me.btn_workflow.UseVisualStyleBackColor = True
        '
        'btn_userlist
        '
        Me.btn_userlist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_userlist, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_userlist, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_userlist, BunifuAnimatorNS.DecorationType.None)
        Me.btn_userlist.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_userlist.FlatAppearance.BorderSize = 0
        Me.btn_userlist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_userlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_userlist.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_userlist.ForeColor = System.Drawing.Color.White
        Me.btn_userlist.Image = CType(resources.GetObject("btn_userlist.Image"), System.Drawing.Image)
        Me.btn_userlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_userlist.Location = New System.Drawing.Point(0, 423)
        Me.btn_userlist.Name = "btn_userlist"
        Me.btn_userlist.Size = New System.Drawing.Size(172, 47)
        Me.btn_userlist.TabIndex = 10
        Me.btn_userlist.Text = "User List"
        Me.btn_userlist.UseVisualStyleBackColor = True
        '
        'btn_files_due
        '
        Me.btn_files_due.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_files_due, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_files_due, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_files_due, BunifuAnimatorNS.DecorationType.None)
        Me.btn_files_due.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_files_due.FlatAppearance.BorderSize = 0
        Me.btn_files_due.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_files_due.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_files_due.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_files_due.ForeColor = System.Drawing.Color.White
        Me.btn_files_due.Image = CType(resources.GetObject("btn_files_due.Image"), System.Drawing.Image)
        Me.btn_files_due.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_files_due.Location = New System.Drawing.Point(0, 376)
        Me.btn_files_due.Name = "btn_files_due"
        Me.btn_files_due.Size = New System.Drawing.Size(172, 47)
        Me.btn_files_due.TabIndex = 9
        Me.btn_files_due.Text = " Files Due"
        Me.btn_files_due.UseVisualStyleBackColor = True
        '
        'btn_wait_tracker
        '
        Me.btn_wait_tracker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_wait_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_wait_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_wait_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.btn_wait_tracker.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_wait_tracker.FlatAppearance.BorderSize = 0
        Me.btn_wait_tracker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_wait_tracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_wait_tracker.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_wait_tracker.ForeColor = System.Drawing.Color.White
        Me.btn_wait_tracker.Image = CType(resources.GetObject("btn_wait_tracker.Image"), System.Drawing.Image)
        Me.btn_wait_tracker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_wait_tracker.Location = New System.Drawing.Point(0, 329)
        Me.btn_wait_tracker.Name = "btn_wait_tracker"
        Me.btn_wait_tracker.Size = New System.Drawing.Size(172, 47)
        Me.btn_wait_tracker.TabIndex = 8
        Me.btn_wait_tracker.Text = "        Wait Tracker"
        Me.btn_wait_tracker.UseVisualStyleBackColor = True
        '
        'btn_idle_tracker
        '
        Me.btn_idle_tracker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_idle_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_idle_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_idle_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.btn_idle_tracker.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_idle_tracker.FlatAppearance.BorderSize = 0
        Me.btn_idle_tracker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_idle_tracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_idle_tracker.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_idle_tracker.ForeColor = System.Drawing.Color.White
        Me.btn_idle_tracker.Image = CType(resources.GetObject("btn_idle_tracker.Image"), System.Drawing.Image)
        Me.btn_idle_tracker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_idle_tracker.Location = New System.Drawing.Point(0, 282)
        Me.btn_idle_tracker.Name = "btn_idle_tracker"
        Me.btn_idle_tracker.Size = New System.Drawing.Size(172, 47)
        Me.btn_idle_tracker.TabIndex = 7
        Me.btn_idle_tracker.Text = "      Idle Tracker"
        Me.btn_idle_tracker.UseVisualStyleBackColor = True
        '
        'btn_ratio_tracker
        '
        Me.btn_ratio_tracker.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_ratio_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_ratio_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_ratio_tracker, BunifuAnimatorNS.DecorationType.None)
        Me.btn_ratio_tracker.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_ratio_tracker.FlatAppearance.BorderSize = 0
        Me.btn_ratio_tracker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_ratio_tracker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ratio_tracker.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ratio_tracker.ForeColor = System.Drawing.Color.White
        Me.btn_ratio_tracker.Image = CType(resources.GetObject("btn_ratio_tracker.Image"), System.Drawing.Image)
        Me.btn_ratio_tracker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_ratio_tracker.Location = New System.Drawing.Point(0, 235)
        Me.btn_ratio_tracker.Name = "btn_ratio_tracker"
        Me.btn_ratio_tracker.Size = New System.Drawing.Size(172, 47)
        Me.btn_ratio_tracker.TabIndex = 6
        Me.btn_ratio_tracker.Text = "        Ratio Tracker"
        Me.btn_ratio_tracker.UseVisualStyleBackColor = True
        '
        'btn_flagging
        '
        Me.btn_flagging.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_flagging, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_flagging, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_flagging, BunifuAnimatorNS.DecorationType.None)
        Me.btn_flagging.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_flagging.FlatAppearance.BorderSize = 0
        Me.btn_flagging.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_flagging.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_flagging.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_flagging.ForeColor = System.Drawing.Color.White
        Me.btn_flagging.Image = CType(resources.GetObject("btn_flagging.Image"), System.Drawing.Image)
        Me.btn_flagging.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_flagging.Location = New System.Drawing.Point(0, 188)
        Me.btn_flagging.Name = "btn_flagging"
        Me.btn_flagging.Size = New System.Drawing.Size(172, 47)
        Me.btn_flagging.TabIndex = 5
        Me.btn_flagging.Text = "Flagging"
        Me.btn_flagging.UseVisualStyleBackColor = True
        '
        'btn_viewreturn
        '
        Me.btn_viewreturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_viewreturn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_viewreturn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_viewreturn, BunifuAnimatorNS.DecorationType.None)
        Me.btn_viewreturn.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_viewreturn.FlatAppearance.BorderSize = 0
        Me.btn_viewreturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_viewreturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_viewreturn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_viewreturn.ForeColor = System.Drawing.Color.White
        Me.btn_viewreturn.Image = CType(resources.GetObject("btn_viewreturn.Image"), System.Drawing.Image)
        Me.btn_viewreturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_viewreturn.Location = New System.Drawing.Point(0, 141)
        Me.btn_viewreturn.Name = "btn_viewreturn"
        Me.btn_viewreturn.Size = New System.Drawing.Size(172, 47)
        Me.btn_viewreturn.TabIndex = 4
        Me.btn_viewreturn.Text = "      View Return"
        Me.btn_viewreturn.UseVisualStyleBackColor = True
        '
        'btn_monitoring
        '
        Me.btn_monitoring.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_monitoring, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_monitoring, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_monitoring, BunifuAnimatorNS.DecorationType.None)
        Me.btn_monitoring.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_monitoring.FlatAppearance.BorderSize = 0
        Me.btn_monitoring.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_monitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_monitoring.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_monitoring.ForeColor = System.Drawing.Color.White
        Me.btn_monitoring.Image = CType(resources.GetObject("btn_monitoring.Image"), System.Drawing.Image)
        Me.btn_monitoring.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_monitoring.Location = New System.Drawing.Point(0, 94)
        Me.btn_monitoring.Name = "btn_monitoring"
        Me.btn_monitoring.Size = New System.Drawing.Size(172, 47)
        Me.btn_monitoring.TabIndex = 3
        Me.btn_monitoring.Text = "   Monitoring"
        Me.btn_monitoring.UseVisualStyleBackColor = True
        '
        'btn_file_eval
        '
        Me.btn_file_eval.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_file_eval, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_file_eval, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_file_eval, BunifuAnimatorNS.DecorationType.None)
        Me.btn_file_eval.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_file_eval.FlatAppearance.BorderSize = 0
        Me.btn_file_eval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_file_eval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_file_eval.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_file_eval.ForeColor = System.Drawing.Color.White
        Me.btn_file_eval.Image = CType(resources.GetObject("btn_file_eval.Image"), System.Drawing.Image)
        Me.btn_file_eval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_file_eval.Location = New System.Drawing.Point(0, 47)
        Me.btn_file_eval.Name = "btn_file_eval"
        Me.btn_file_eval.Size = New System.Drawing.Size(172, 47)
        Me.btn_file_eval.TabIndex = 2
        Me.btn_file_eval.Text = "         File Evaluation"
        Me.btn_file_eval.UseVisualStyleBackColor = True
        '
        'btn_myeval
        '
        Me.btn_myeval.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_myeval, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_myeval, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_myeval, BunifuAnimatorNS.DecorationType.None)
        Me.btn_myeval.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_myeval.FlatAppearance.BorderSize = 0
        Me.btn_myeval.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_myeval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_myeval.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_myeval.ForeColor = System.Drawing.Color.White
        Me.btn_myeval.Image = CType(resources.GetObject("btn_myeval.Image"), System.Drawing.Image)
        Me.btn_myeval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_myeval.Location = New System.Drawing.Point(0, 0)
        Me.btn_myeval.Name = "btn_myeval"
        Me.btn_myeval.Size = New System.Drawing.Size(172, 47)
        Me.btn_myeval.TabIndex = 1
        Me.btn_myeval.Text = "         My Evaluation"
        Me.btn_myeval.UseVisualStyleBackColor = True
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.User_Btn)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Exit_btn)
        Me.BunifuTransition1.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1376, 25)
        Me.Panel1.TabIndex = 0
        '
        'User_Btn
        '
        Me.User_Btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.User_Btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.User_Btn.FlatAppearance.BorderSize = 0
        Me.User_Btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.User_Btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.User_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.User_Btn.Font = New System.Drawing.Font("MegaMan 2", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.User_Btn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.User_Btn.Image = Global.BT_Tool.My.Resources.Resources.person
        Me.User_Btn.Location = New System.Drawing.Point(1193, 0)
        Me.User_Btn.Name = "User_Btn"
        Me.User_Btn.Size = New System.Drawing.Size(61, 25)
        Me.User_Btn.TabIndex = 18
        Me.User_Btn.Text = "_"
        Me.User_Btn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("MegaMan 2", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(1254, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 25)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "_"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Exit_btn
        '
        Me.Exit_btn.BackColor = System.Drawing.Color.Black
        Me.Exit_btn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.Exit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Exit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Exit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Exit_btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.Exit_btn.FlatAppearance.BorderSize = 0
        Me.Exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red
        Me.Exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Exit_btn.Image = CType(resources.GetObject("Exit_btn.Image"), System.Drawing.Image)
        Me.Exit_btn.Location = New System.Drawing.Point(1315, 0)
        Me.Exit_btn.Name = "Exit_btn"
        Me.Exit_btn.Size = New System.Drawing.Size(61, 25)
        Me.Exit_btn.TabIndex = 14
        Me.Exit_btn.UseVisualStyleBackColor = False
        '
        'BunifuTransition1
        '
        Me.BunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.Transparent
        Me.BunifuTransition1.Cursor = Nothing
        Animation3.AnimateOnlyDifferences = True
        Animation3.BlindCoeff = CType(resources.GetObject("Animation3.BlindCoeff"), System.Drawing.PointF)
        Animation3.LeafCoeff = 0!
        Animation3.MaxTime = 1.0!
        Animation3.MinTime = 0!
        Animation3.MosaicCoeff = CType(resources.GetObject("Animation3.MosaicCoeff"), System.Drawing.PointF)
        Animation3.MosaicShift = CType(resources.GetObject("Animation3.MosaicShift"), System.Drawing.PointF)
        Animation3.MosaicSize = 0
        Animation3.Padding = New System.Windows.Forms.Padding(0)
        Animation3.RotateCoeff = 0!
        Animation3.RotateLimit = 0!
        Animation3.ScaleCoeff = CType(resources.GetObject("Animation3.ScaleCoeff"), System.Drawing.PointF)
        Animation3.SlideCoeff = CType(resources.GetObject("Animation3.SlideCoeff"), System.Drawing.PointF)
        Animation3.TimeCoeff = 0!
        Animation3.TransparencyCoeff = 1.0!
        Me.BunifuTransition1.DefaultAnimation = Animation3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.btn_break)
        Me.Panel2.Controls.Add(Me.btn_return)
        Me.Panel2.Controls.Add(Me.btn_hold)
        Me.Panel2.Controls.Add(Me.btn_cancel)
        Me.Panel2.Controls.Add(Me.btn_submit)
        Me.BunifuTransition1.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1313, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(63, 691)
        Me.Panel2.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = Global.BT_Tool.My.Resources.Resources.refresh_32
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(0, 630)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(63, 61)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "REFRESH"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btn_break
        '
        Me.btn_break.BackColor = System.Drawing.Color.Transparent
        Me.btn_break.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_break, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_break, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_break, BunifuAnimatorNS.DecorationType.None)
        Me.btn_break.FlatAppearance.BorderSize = 0
        Me.btn_break.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_break.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_break.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_break.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_break.ForeColor = System.Drawing.Color.White
        Me.btn_break.Image = CType(resources.GetObject("btn_break.Image"), System.Drawing.Image)
        Me.btn_break.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_break.Location = New System.Drawing.Point(0, 300)
        Me.btn_break.Name = "btn_break"
        Me.btn_break.Size = New System.Drawing.Size(63, 61)
        Me.btn_break.TabIndex = 17
        Me.btn_break.Text = "BREAK"
        Me.btn_break.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_break.UseVisualStyleBackColor = False
        '
        'btn_return
        '
        Me.btn_return.BackColor = System.Drawing.Color.Transparent
        Me.btn_return.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_return, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_return, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_return, BunifuAnimatorNS.DecorationType.None)
        Me.btn_return.FlatAppearance.BorderSize = 0
        Me.btn_return.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_return.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_return.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_return.ForeColor = System.Drawing.Color.White
        Me.btn_return.Image = CType(resources.GetObject("btn_return.Image"), System.Drawing.Image)
        Me.btn_return.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_return.Location = New System.Drawing.Point(0, 236)
        Me.btn_return.Name = "btn_return"
        Me.btn_return.Size = New System.Drawing.Size(63, 61)
        Me.btn_return.TabIndex = 16
        Me.btn_return.Text = "RETURN"
        Me.btn_return.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_return.UseVisualStyleBackColor = False
        '
        'btn_hold
        '
        Me.btn_hold.BackColor = System.Drawing.Color.Transparent
        Me.btn_hold.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_hold, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_hold, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_hold, BunifuAnimatorNS.DecorationType.None)
        Me.btn_hold.FlatAppearance.BorderSize = 0
        Me.btn_hold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_hold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_hold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_hold.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_hold.ForeColor = System.Drawing.Color.White
        Me.btn_hold.Image = CType(resources.GetObject("btn_hold.Image"), System.Drawing.Image)
        Me.btn_hold.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_hold.Location = New System.Drawing.Point(0, 172)
        Me.btn_hold.Name = "btn_hold"
        Me.btn_hold.Size = New System.Drawing.Size(63, 61)
        Me.btn_hold.TabIndex = 15
        Me.btn_hold.Text = "HOLD"
        Me.btn_hold.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_hold.UseVisualStyleBackColor = False
        '
        'btn_cancel
        '
        Me.btn_cancel.BackColor = System.Drawing.Color.Transparent
        Me.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_cancel, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_cancel, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_cancel, BunifuAnimatorNS.DecorationType.None)
        Me.btn_cancel.FlatAppearance.BorderSize = 0
        Me.btn_cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cancel.ForeColor = System.Drawing.Color.White
        Me.btn_cancel.Image = CType(resources.GetObject("btn_cancel.Image"), System.Drawing.Image)
        Me.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_cancel.Location = New System.Drawing.Point(0, 108)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(63, 61)
        Me.btn_cancel.TabIndex = 14
        Me.btn_cancel.Text = "CANCEL"
        Me.btn_cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_cancel.UseVisualStyleBackColor = False
        '
        'btn_submit
        '
        Me.btn_submit.BackColor = System.Drawing.Color.Transparent
        Me.btn_submit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_submit, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_submit, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_submit, BunifuAnimatorNS.DecorationType.None)
        Me.btn_submit.FlatAppearance.BorderSize = 0
        Me.btn_submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_submit.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_submit.ForeColor = System.Drawing.Color.White
        Me.btn_submit.Image = CType(resources.GetObject("btn_submit.Image"), System.Drawing.Image)
        Me.btn_submit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_submit.Location = New System.Drawing.Point(0, 44)
        Me.btn_submit.Name = "btn_submit"
        Me.btn_submit.Size = New System.Drawing.Size(63, 61)
        Me.btn_submit.TabIndex = 13
        Me.btn_submit.Text = "SUBMIT"
        Me.btn_submit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_submit.UseVisualStyleBackColor = False
        '
        'Main_pnl
        '
        Me.Main_pnl.BackColor = System.Drawing.Color.White
        Me.Main_pnl.Controls.Add(Me.Panel3)
        Me.Main_pnl.Controls.Add(Me.Dashboard_pnl)
        Me.Main_pnl.Controls.Add(Me.pnl_header)
        Me.Main_pnl.Controls.Add(Me.Panel4)
        Me.BunifuTransition1.SetDecoration(Me.Main_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Main_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Main_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.Main_pnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Main_pnl.Location = New System.Drawing.Point(0, 25)
        Me.Main_pnl.Name = "Main_pnl"
        Me.Main_pnl.Size = New System.Drawing.Size(1376, 691)
        Me.Main_pnl.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.BunifuTransition1.SetDecoration(Me.Panel3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel3, BunifuAnimatorNS.DecorationType.None)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(174, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1202, 163)
        Me.Panel3.TabIndex = 6
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.gbox_file_info, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gbox_work_file, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.gbox_prio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GboxUList, 3, 0)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel1, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1200, 161)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'gbox_file_info
        '
        Me.gbox_file_info.Controls.Add(Me.TableLayoutPanel2)
        Me.BunifuTransition1.SetDecoration(Me.gbox_file_info, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.gbox_file_info, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.gbox_file_info, BunifuAnimatorNS.DecorationType.None)
        Me.gbox_file_info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox_file_info.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_file_info.Location = New System.Drawing.Point(439, 3)
        Me.gbox_file_info.Name = "gbox_file_info"
        Me.gbox_file_info.Padding = New System.Windows.Forms.Padding(6, 3, 6, 6)
        Me.gbox_file_info.Size = New System.Drawing.Size(408, 155)
        Me.gbox_file_info.TabIndex = 64
        Me.gbox_file_info.TabStop = False
        Me.gbox_file_info.Text = "File Information:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.cbo_service, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_accuracy, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_page, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_duration, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_receive, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_branch, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_client, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txt_due, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 2, 0)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel2, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(396, 132)
        Me.TableLayoutPanel2.TabIndex = 46
        '
        'cbo_service
        '
        Me.cbo_service.CalendarTitleBackColor = System.Drawing.Color.Silver
        Me.cbo_service.CustomFormat = "MM/dd/yyyy"
        Me.BunifuTransition3.SetDecoration(Me.cbo_service, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_service, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_service, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_service.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_service.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.cbo_service.Location = New System.Drawing.Point(73, 31)
        Me.cbo_service.Name = "cbo_service"
        Me.cbo_service.Size = New System.Drawing.Size(122, 21)
        Me.cbo_service.TabIndex = 7
        '
        'txt_accuracy
        '
        Me.txt_accuracy.BackColor = System.Drawing.Color.White
        Me.txt_accuracy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_accuracy, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_accuracy, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_accuracy, BunifuAnimatorNS.DecorationType.None)
        Me.txt_accuracy.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_accuracy.Font = New System.Drawing.Font("Futura", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_accuracy.Location = New System.Drawing.Point(271, 88)
        Me.txt_accuracy.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_accuracy.Name = "txt_accuracy"
        Me.txt_accuracy.Size = New System.Drawing.Size(122, 21)
        Me.txt_accuracy.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label7, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label7, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label7, BunifuAnimatorNS.DecorationType.None)
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(201, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Duration: "
        '
        'txt_page
        '
        Me.txt_page.BackColor = System.Drawing.Color.White
        Me.txt_page.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_page, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_page, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_page, BunifuAnimatorNS.DecorationType.None)
        Me.txt_page.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_page.Font = New System.Drawing.Font("Futura", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_page.Location = New System.Drawing.Point(271, 60)
        Me.txt_page.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_page.Name = "txt_page"
        Me.txt_page.Size = New System.Drawing.Size(122, 21)
        Me.txt_page.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label6, BunifuAnimatorNS.DecorationType.None)
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(201, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Page:"
        '
        'txt_duration
        '
        Me.txt_duration.BackColor = System.Drawing.Color.White
        Me.txt_duration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_duration, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_duration, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_duration, BunifuAnimatorNS.DecorationType.None)
        Me.txt_duration.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_duration.Font = New System.Drawing.Font("Futura", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_duration.Location = New System.Drawing.Point(271, 32)
        Me.txt_duration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_duration.Name = "txt_duration"
        Me.txt_duration.Size = New System.Drawing.Size(122, 21)
        Me.txt_duration.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label5, BunifuAnimatorNS.DecorationType.None)
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(201, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Accuracy:"
        '
        'txt_receive
        '
        Me.txt_receive.BackColor = System.Drawing.Color.White
        Me.txt_receive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_receive, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_receive, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_receive, BunifuAnimatorNS.DecorationType.None)
        Me.txt_receive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_receive.Font = New System.Drawing.Font("Futura", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_receive.Location = New System.Drawing.Point(271, 4)
        Me.txt_receive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_receive.Name = "txt_receive"
        Me.txt_receive.Size = New System.Drawing.Size(122, 21)
        Me.txt_receive.TabIndex = 16
        '
        'txt_branch
        '
        Me.txt_branch.BackColor = System.Drawing.Color.White
        Me.txt_branch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_branch, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_branch, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_branch, BunifuAnimatorNS.DecorationType.None)
        Me.txt_branch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_branch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_branch.Location = New System.Drawing.Point(73, 88)
        Me.txt_branch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_branch.Name = "txt_branch"
        Me.txt_branch.Size = New System.Drawing.Size(122, 21)
        Me.txt_branch.TabIndex = 14
        '
        'txt_client
        '
        Me.txt_client.BackColor = System.Drawing.Color.White
        Me.txt_client.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_client, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_client, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_client, BunifuAnimatorNS.DecorationType.None)
        Me.txt_client.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_client.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_client.Location = New System.Drawing.Point(73, 60)
        Me.txt_client.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_client.Name = "txt_client"
        Me.txt_client.Size = New System.Drawing.Size(122, 21)
        Me.txt_client.TabIndex = 12
        '
        'txt_due
        '
        Me.txt_due.BackColor = System.Drawing.Color.White
        Me.txt_due.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_due, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_due, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_due, BunifuAnimatorNS.DecorationType.None)
        Me.txt_due.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_due.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_due.Location = New System.Drawing.Point(73, 4)
        Me.txt_due.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_due.Name = "txt_due"
        Me.txt_due.Size = New System.Drawing.Size(122, 21)
        Me.txt_due.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label11, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label11, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label11, BunifuAnimatorNS.DecorationType.None)
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Due Date:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label20, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label20, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label20, BunifuAnimatorNS.DecorationType.None)
        Me.Label20.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 28)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Service Date:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label21, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label21, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label21, BunifuAnimatorNS.DecorationType.None)
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 56)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(45, 16)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Client: "
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label22, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label22, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label22, BunifuAnimatorNS.DecorationType.None)
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 84)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 16)
        Me.Label22.TabIndex = 13
        Me.Label22.Text = "Branch:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label8, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label8, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label8, BunifuAnimatorNS.DecorationType.None)
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(201, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Receive:"
        '
        'gbox_work_file
        '
        Me.gbox_work_file.Controls.Add(Me.Panel6)
        Me.BunifuTransition1.SetDecoration(Me.gbox_work_file, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.gbox_work_file, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.gbox_work_file, BunifuAnimatorNS.DecorationType.None)
        Me.gbox_work_file.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox_work_file.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_work_file.Location = New System.Drawing.Point(99, 3)
        Me.gbox_work_file.Name = "gbox_work_file"
        Me.gbox_work_file.Padding = New System.Windows.Forms.Padding(6, 3, 6, 6)
        Me.gbox_work_file.Size = New System.Drawing.Size(334, 155)
        Me.gbox_work_file.TabIndex = 63
        Me.gbox_work_file.TabStop = False
        Me.gbox_work_file.Text = "Work File:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.TableLayoutPanel5)
        Me.Panel6.Controls.Add(Me.gbox_players)
        Me.BunifuTransition1.SetDecoration(Me.Panel6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel6, BunifuAnimatorNS.DecorationType.None)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(6, 17)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(322, 132)
        Me.Panel6.TabIndex = 49
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btn_Doc, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txt_document, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btn_Audio, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txt_audio, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label10, 0, 0)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel5, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel5, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 69)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(322, 63)
        Me.TableLayoutPanel5.TabIndex = 32
        '
        'btn_Doc
        '
        Me.btn_Doc.BackColor = System.Drawing.Color.Black
        Me.btn_Doc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition1.SetDecoration(Me.btn_Doc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_Doc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.btn_Doc, BunifuAnimatorNS.DecorationType.None)
        Me.btn_Doc.FlatAppearance.BorderSize = 0
        Me.btn_Doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Doc.Image = CType(resources.GetObject("btn_Doc.Image"), System.Drawing.Image)
        Me.btn_Doc.Location = New System.Drawing.Point(293, 35)
        Me.btn_Doc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Doc.Name = "btn_Doc"
        Me.btn_Doc.Size = New System.Drawing.Size(26, 21)
        Me.btn_Doc.TabIndex = 36
        Me.btn_Doc.UseVisualStyleBackColor = False
        '
        'txt_document
        '
        Me.txt_document.BackColor = System.Drawing.Color.White
        Me.txt_document.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_document, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_document, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_document, BunifuAnimatorNS.DecorationType.None)
        Me.txt_document.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_document.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_document.Location = New System.Drawing.Point(78, 35)
        Me.txt_document.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_document.Name = "txt_document"
        Me.txt_document.Size = New System.Drawing.Size(209, 21)
        Me.txt_document.TabIndex = 42
        '
        'btn_Audio
        '
        Me.btn_Audio.BackColor = System.Drawing.Color.Black
        Me.btn_Audio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition1.SetDecoration(Me.btn_Audio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_Audio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.btn_Audio, BunifuAnimatorNS.DecorationType.None)
        Me.btn_Audio.FlatAppearance.BorderSize = 0
        Me.btn_Audio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Audio.Image = CType(resources.GetObject("btn_Audio.Image"), System.Drawing.Image)
        Me.btn_Audio.Location = New System.Drawing.Point(293, 4)
        Me.btn_Audio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_Audio.Name = "btn_Audio"
        Me.btn_Audio.Size = New System.Drawing.Size(26, 21)
        Me.btn_Audio.TabIndex = 35
        Me.btn_Audio.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label9, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label9, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label9, BunifuAnimatorNS.DecorationType.None)
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 32)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Document:"
        '
        'txt_audio
        '
        Me.txt_audio.BackColor = System.Drawing.Color.White
        Me.txt_audio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BunifuTransition3.SetDecoration(Me.txt_audio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.txt_audio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.txt_audio, BunifuAnimatorNS.DecorationType.None)
        Me.txt_audio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_audio.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_audio.Location = New System.Drawing.Point(78, 4)
        Me.txt_audio.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txt_audio.Name = "txt_audio"
        Me.txt_audio.Size = New System.Drawing.Size(209, 21)
        Me.txt_audio.TabIndex = 41
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label10, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label10, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label10, BunifuAnimatorNS.DecorationType.None)
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 31)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Audio:"
        '
        'gbox_players
        '
        Me.gbox_players.Controls.Add(Me.TableLayoutPanel6)
        Me.BunifuTransition1.SetDecoration(Me.gbox_players, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.gbox_players, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.gbox_players, BunifuAnimatorNS.DecorationType.None)
        Me.gbox_players.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbox_players.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_players.Location = New System.Drawing.Point(0, 0)
        Me.gbox_players.Name = "gbox_players"
        Me.gbox_players.Size = New System.Drawing.Size(322, 69)
        Me.gbox_players.TabIndex = 31
        Me.gbox_players.TabStop = False
        Me.gbox_players.Text = "Select the player to be used"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.rd_pepsup, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.rd_acqt, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.rd_express, 0, 0)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel6, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel6, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(316, 49)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'rd_pepsup
        '
        Me.rd_pepsup.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.rd_pepsup, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.rd_pepsup, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.rd_pepsup, BunifuAnimatorNS.DecorationType.None)
        Me.rd_pepsup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rd_pepsup.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd_pepsup.Location = New System.Drawing.Point(161, 3)
        Me.rd_pepsup.Name = "rd_pepsup"
        Me.rd_pepsup.Size = New System.Drawing.Size(152, 18)
        Me.rd_pepsup.TabIndex = 9
        Me.rd_pepsup.Text = "People Support"
        Me.rd_pepsup.UseVisualStyleBackColor = True
        '
        'rd_acqt
        '
        Me.rd_acqt.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.rd_acqt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.rd_acqt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.rd_acqt, BunifuAnimatorNS.DecorationType.None)
        Me.rd_acqt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rd_acqt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd_acqt.Location = New System.Drawing.Point(3, 27)
        Me.rd_acqt.Name = "rd_acqt"
        Me.rd_acqt.Size = New System.Drawing.Size(152, 19)
        Me.rd_acqt.TabIndex = 10
        Me.rd_acqt.Text = "Accolade QT"
        Me.rd_acqt.UseVisualStyleBackColor = True
        '
        'rd_express
        '
        Me.rd_express.AutoSize = True
        Me.rd_express.Checked = True
        Me.BunifuTransition3.SetDecoration(Me.rd_express, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.rd_express, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.rd_express, BunifuAnimatorNS.DecorationType.None)
        Me.rd_express.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rd_express.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd_express.Location = New System.Drawing.Point(3, 3)
        Me.rd_express.Name = "rd_express"
        Me.rd_express.Size = New System.Drawing.Size(152, 18)
        Me.rd_express.TabIndex = 8
        Me.rd_express.TabStop = True
        Me.rd_express.Text = "Express Scribe"
        Me.rd_express.UseVisualStyleBackColor = True
        '
        'gbox_prio
        '
        Me.gbox_prio.Controls.Add(Me.TableLayoutPanel3)
        Me.BunifuTransition1.SetDecoration(Me.gbox_prio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.gbox_prio, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.gbox_prio, BunifuAnimatorNS.DecorationType.None)
        Me.gbox_prio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox_prio.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_prio.Location = New System.Drawing.Point(3, 3)
        Me.gbox_prio.Name = "gbox_prio"
        Me.gbox_prio.Padding = New System.Windows.Forms.Padding(6, 3, 6, 6)
        Me.gbox_prio.Size = New System.Drawing.Size(90, 155)
        Me.gbox_prio.TabIndex = 61
        Me.gbox_prio.TabStop = False
        Me.gbox_prio.Text = "File Priority:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.chk_blank, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.chk_rush, 0, 1)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel3, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(77, 135)
        Me.TableLayoutPanel3.TabIndex = 47
        '
        'chk_blank
        '
        Me.chk_blank.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.chk_blank, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.chk_blank, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.chk_blank, BunifuAnimatorNS.DecorationType.None)
        Me.chk_blank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_blank.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_blank.Location = New System.Drawing.Point(3, 4)
        Me.chk_blank.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chk_blank.Name = "chk_blank"
        Me.chk_blank.Size = New System.Drawing.Size(52, 20)
        Me.chk_blank.TabIndex = 4
        Me.chk_blank.Text = "Blank"
        Me.chk_blank.UseVisualStyleBackColor = True
        '
        'chk_rush
        '
        Me.chk_rush.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.chk_rush, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.chk_rush, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.chk_rush, BunifuAnimatorNS.DecorationType.None)
        Me.chk_rush.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_rush.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_rush.Location = New System.Drawing.Point(3, 32)
        Me.chk_rush.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chk_rush.Name = "chk_rush"
        Me.chk_rush.Size = New System.Drawing.Size(49, 20)
        Me.chk_rush.TabIndex = 6
        Me.chk_rush.Text = "Rush"
        Me.chk_rush.UseVisualStyleBackColor = True
        '
        'GboxUList
        '
        Me.GboxUList.Controls.Add(Me.TableLayoutPanel4)
        Me.BunifuTransition1.SetDecoration(Me.GboxUList, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.GboxUList, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.GboxUList, BunifuAnimatorNS.DecorationType.None)
        Me.GboxUList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GboxUList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GboxUList.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GboxUList.Location = New System.Drawing.Point(853, 3)
        Me.GboxUList.Name = "GboxUList"
        Me.GboxUList.Padding = New System.Windows.Forms.Padding(6, 3, 6, 6)
        Me.GboxUList.Size = New System.Drawing.Size(278, 155)
        Me.GboxUList.TabIndex = 59
        Me.GboxUList.TabStop = False
        Me.GboxUList.Text = "Assign User:"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_qapr, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_qabt, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_bt, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label18, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_pr, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label19, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_qacc, 3, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_qast, 3, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_cc, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.cbo_st, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label17, 2, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label16, 2, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label14, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label15, 0, 2)
        Me.BunifuTransition1.SetDecoration(Me.TableLayoutPanel4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.TableLayoutPanel4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.TableLayoutPanel4, BunifuAnimatorNS.DecorationType.None)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(6, 17)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 4
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(266, 132)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label12, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label12, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label12, BunifuAnimatorNS.DecorationType.None)
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(19, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "BT"
        '
        'cbo_qapr
        '
        Me.cbo_qapr.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_qapr, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_qapr, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_qapr, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_qapr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_qapr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_qapr.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_qapr.FormattingEnabled = True
        Me.cbo_qapr.Location = New System.Drawing.Point(184, 31)
        Me.cbo_qapr.Name = "cbo_qapr"
        Me.cbo_qapr.Size = New System.Drawing.Size(79, 24)
        Me.cbo_qapr.TabIndex = 41
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label13, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label13, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label13, BunifuAnimatorNS.DecorationType.None)
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "PR"
        '
        'cbo_qabt
        '
        Me.cbo_qabt.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_qabt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_qabt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_qabt, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_qabt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_qabt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_qabt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_qabt.FormattingEnabled = True
        Me.cbo_qabt.Location = New System.Drawing.Point(184, 3)
        Me.cbo_qabt.Name = "cbo_qabt"
        Me.cbo_qabt.Size = New System.Drawing.Size(79, 24)
        Me.cbo_qabt.TabIndex = 39
        '
        'cbo_bt
        '
        Me.cbo_bt.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_bt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_bt, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_bt, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_bt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_bt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_bt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_bt.FormattingEnabled = True
        Me.cbo_bt.Location = New System.Drawing.Point(47, 3)
        Me.cbo_bt.Name = "cbo_bt"
        Me.cbo_bt.Size = New System.Drawing.Size(79, 24)
        Me.cbo_bt.TabIndex = 31
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label18, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label18, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label18, BunifuAnimatorNS.DecorationType.None)
        Me.Label18.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(132, 28)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 16)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "PR QA"
        '
        'cbo_pr
        '
        Me.cbo_pr.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_pr, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_pr, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_pr, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_pr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_pr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pr.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_pr.FormattingEnabled = True
        Me.cbo_pr.Location = New System.Drawing.Point(47, 31)
        Me.cbo_pr.Name = "cbo_pr"
        Me.cbo_pr.Size = New System.Drawing.Size(79, 24)
        Me.cbo_pr.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label19, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label19, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label19, BunifuAnimatorNS.DecorationType.None)
        Me.Label19.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(132, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 16)
        Me.Label19.TabIndex = 38
        Me.Label19.Text = "BT QA"
        '
        'cbo_qacc
        '
        Me.cbo_qacc.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_qacc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_qacc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_qacc, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_qacc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_qacc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_qacc.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_qacc.FormattingEnabled = True
        Me.cbo_qacc.Location = New System.Drawing.Point(184, 87)
        Me.cbo_qacc.Name = "cbo_qacc"
        Me.cbo_qacc.Size = New System.Drawing.Size(79, 24)
        Me.cbo_qacc.TabIndex = 43
        '
        'cbo_qast
        '
        Me.cbo_qast.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_qast, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_qast, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_qast, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_qast.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_qast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_qast.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_qast.FormattingEnabled = True
        Me.cbo_qast.Location = New System.Drawing.Point(184, 59)
        Me.cbo_qast.Name = "cbo_qast"
        Me.cbo_qast.Size = New System.Drawing.Size(79, 24)
        Me.cbo_qast.TabIndex = 45
        '
        'cbo_cc
        '
        Me.cbo_cc.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_cc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_cc, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_cc, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_cc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_cc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_cc.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_cc.FormattingEnabled = True
        Me.cbo_cc.Location = New System.Drawing.Point(47, 87)
        Me.cbo_cc.Name = "cbo_cc"
        Me.cbo_cc.Size = New System.Drawing.Size(79, 24)
        Me.cbo_cc.TabIndex = 35
        '
        'cbo_st
        '
        Me.cbo_st.BackColor = System.Drawing.Color.White
        Me.BunifuTransition3.SetDecoration(Me.cbo_st, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.cbo_st, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.cbo_st, BunifuAnimatorNS.DecorationType.None)
        Me.cbo_st.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_st.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_st.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_st.FormattingEnabled = True
        Me.cbo_st.Location = New System.Drawing.Point(47, 59)
        Me.cbo_st.Name = "cbo_st"
        Me.cbo_st.Size = New System.Drawing.Size(79, 24)
        Me.cbo_st.TabIndex = 37
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label17, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label17, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label17, BunifuAnimatorNS.DecorationType.None)
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(132, 84)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 16)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "CC QA"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label16, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label16, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label16, BunifuAnimatorNS.DecorationType.None)
        Me.Label16.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(132, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 16)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "ST QA"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label14, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label14, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label14, BunifuAnimatorNS.DecorationType.None)
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(26, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "CC"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.BunifuTransition1.SetDecoration(Me.Label15, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label15, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Label15, BunifuAnimatorNS.DecorationType.None)
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 16)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "S&T"
        Me.Label15.UseMnemonic = False
        '
        'pnl_header
        '
        Me.pnl_header.Controls.Add(Me.main_gridview)
        Me.BunifuTransition1.SetDecoration(Me.pnl_header, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.pnl_header, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.pnl_header, BunifuAnimatorNS.DecorationType.None)
        Me.pnl_header.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnl_header.Location = New System.Drawing.Point(0, 43)
        Me.pnl_header.Name = "pnl_header"
        Me.pnl_header.Size = New System.Drawing.Size(1376, 648)
        Me.pnl_header.TabIndex = 60
        '
        'main_gridview
        '
        Me.main_gridview.AllowUserToAddRows = False
        Me.main_gridview.BackgroundColor = System.Drawing.Color.White
        Me.main_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.main_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BunifuTransition2.SetDecoration(Me.main_gridview, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.main_gridview, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.main_gridview, BunifuAnimatorNS.DecorationType.None)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.main_gridview.DefaultCellStyle = DataGridViewCellStyle1
        Me.main_gridview.GridColor = System.Drawing.Color.Black
        Me.main_gridview.Location = New System.Drawing.Point(174, 163)
        Me.main_gridview.Name = "main_gridview"
        Me.main_gridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.main_gridview.RowHeadersVisible = False
        Me.main_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.main_gridview.Size = New System.Drawing.Size(1136, 485)
        Me.main_gridview.TabIndex = 7
        Me.main_gridview.VirtualMode = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Black
        Me.Panel4.Controls.Add(Me.User_Pnl)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.btn_file)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.btn_reference)
        Me.Panel4.Controls.Add(Me.btn_break_log)
        Me.Panel4.Controls.Add(Me.btn_report_log)
        Me.Panel4.Controls.Add(Me.btn_archive)
        Me.Panel4.Controls.Add(Me.btn_export)
        Me.Panel4.Controls.Add(Me.btn_upload)
        Me.BunifuTransition1.SetDecoration(Me.Panel4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel4, BunifuAnimatorNS.DecorationType.None)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1376, 43)
        Me.Panel4.TabIndex = 61
        '
        'User_Pnl
        '
        Me.User_Pnl.BackColor = System.Drawing.Color.DimGray
        Me.User_Pnl.Controls.Add(Me.Label2)
        Me.User_Pnl.Controls.Add(Me.Button3)
        Me.BunifuTransition1.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.User_Pnl.Location = New System.Drawing.Point(1162, 5)
        Me.User_Pnl.Name = "User_Pnl"
        Me.User_Pnl.Size = New System.Drawing.Size(136, 40)
        Me.User_Pnl.TabIndex = 8
        Me.User_Pnl.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label2.Location = New System.Drawing.Point(3, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "User Settings"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Button3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button3, BunifuAnimatorNS.DecorationType.None)
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(107, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 25)
        Me.Button3.TabIndex = 15
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label4.Location = New System.Drawing.Point(108, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "BT TOOL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn_file
        '
        Me.btn_file.BackColor = System.Drawing.Color.Transparent
        Me.btn_file.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_file, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_file, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_file, BunifuAnimatorNS.DecorationType.None)
        Me.btn_file.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_file.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_file.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_file.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_file.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_file.ForeColor = System.Drawing.Color.White
        Me.btn_file.Image = CType(resources.GetObject("btn_file.Image"), System.Drawing.Image)
        Me.btn_file.Location = New System.Drawing.Point(1012, 0)
        Me.btn_file.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_file.Name = "btn_file"
        Me.btn_file.Size = New System.Drawing.Size(118, 43)
        Me.btn_file.TabIndex = 8
        Me.btn_file.Text = "BT FILE"
        Me.btn_file.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_file.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.Label1.Font = New System.Drawing.Font("Old English Text MT", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 34)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Accolade"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btn_reference
        '
        Me.btn_reference.BackColor = System.Drawing.Color.Transparent
        Me.btn_reference.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_reference, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_reference, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_reference, BunifuAnimatorNS.DecorationType.None)
        Me.btn_reference.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_reference.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_reference.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_reference.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reference.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reference.ForeColor = System.Drawing.Color.White
        Me.btn_reference.Image = CType(resources.GetObject("btn_reference.Image"), System.Drawing.Image)
        Me.btn_reference.Location = New System.Drawing.Point(868, 0)
        Me.btn_reference.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_reference.Name = "btn_reference"
        Me.btn_reference.Size = New System.Drawing.Size(138, 43)
        Me.btn_reference.TabIndex = 7
        Me.btn_reference.Text = "REFERENCE"
        Me.btn_reference.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_reference.UseVisualStyleBackColor = False
        '
        'btn_break_log
        '
        Me.btn_break_log.BackColor = System.Drawing.Color.Transparent
        Me.btn_break_log.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_break_log, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_break_log, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_break_log, BunifuAnimatorNS.DecorationType.None)
        Me.btn_break_log.FlatAppearance.BorderSize = 0
        Me.btn_break_log.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_break_log.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_break_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_break_log.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_break_log.ForeColor = System.Drawing.Color.White
        Me.btn_break_log.Image = CType(resources.GetObject("btn_break_log.Image"), System.Drawing.Image)
        Me.btn_break_log.Location = New System.Drawing.Point(726, 0)
        Me.btn_break_log.Name = "btn_break_log"
        Me.btn_break_log.Size = New System.Drawing.Size(136, 43)
        Me.btn_break_log.TabIndex = 6
        Me.btn_break_log.Text = "BREAK LOG"
        Me.btn_break_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_break_log.UseVisualStyleBackColor = False
        '
        'btn_report_log
        '
        Me.btn_report_log.BackColor = System.Drawing.Color.Transparent
        Me.btn_report_log.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_report_log, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_report_log, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_report_log, BunifuAnimatorNS.DecorationType.None)
        Me.btn_report_log.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_report_log.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_report_log.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_report_log.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_report_log.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_report_log.ForeColor = System.Drawing.Color.White
        Me.btn_report_log.Image = CType(resources.GetObject("btn_report_log.Image"), System.Drawing.Image)
        Me.btn_report_log.Location = New System.Drawing.Point(567, 0)
        Me.btn_report_log.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_report_log.Name = "btn_report_log"
        Me.btn_report_log.Size = New System.Drawing.Size(153, 43)
        Me.btn_report_log.TabIndex = 4
        Me.btn_report_log.Text = "REPORT LOGS"
        Me.btn_report_log.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_report_log.UseVisualStyleBackColor = False
        '
        'btn_archive
        '
        Me.btn_archive.BackColor = System.Drawing.Color.Transparent
        Me.btn_archive.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_archive, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_archive, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_archive, BunifuAnimatorNS.DecorationType.None)
        Me.btn_archive.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_archive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_archive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_archive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_archive.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_archive.ForeColor = System.Drawing.Color.White
        Me.btn_archive.Image = CType(resources.GetObject("btn_archive.Image"), System.Drawing.Image)
        Me.btn_archive.Location = New System.Drawing.Point(429, 0)
        Me.btn_archive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_archive.Name = "btn_archive"
        Me.btn_archive.Size = New System.Drawing.Size(132, 43)
        Me.btn_archive.TabIndex = 9
        Me.btn_archive.Text = "ARCHIVE"
        Me.btn_archive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_archive.UseVisualStyleBackColor = False
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.Transparent
        Me.btn_export.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_export, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_export, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_export, BunifuAnimatorNS.DecorationType.None)
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_export.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.Color.White
        Me.btn_export.Image = CType(resources.GetObject("btn_export.Image"), System.Drawing.Image)
        Me.btn_export.Location = New System.Drawing.Point(302, 0)
        Me.btn_export.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(121, 43)
        Me.btn_export.TabIndex = 10
        Me.btn_export.Text = "EXPORT"
        Me.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_upload
        '
        Me.btn_upload.BackColor = System.Drawing.Color.Transparent
        Me.btn_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuTransition3.SetDecoration(Me.btn_upload, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.btn_upload, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.btn_upload, BunifuAnimatorNS.DecorationType.None)
        Me.btn_upload.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_upload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_upload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_upload.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_upload.ForeColor = System.Drawing.Color.White
        Me.btn_upload.Image = CType(resources.GetObject("btn_upload.Image"), System.Drawing.Image)
        Me.btn_upload.Location = New System.Drawing.Point(175, 0)
        Me.btn_upload.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(121, 43)
        Me.btn_upload.TabIndex = 11
        Me.btn_upload.Text = "UPLOAD"
        Me.btn_upload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_upload.UseVisualStyleBackColor = False
        '
        'BunifuTransition2
        '
        Me.BunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide
        Me.BunifuTransition2.Cursor = Nothing
        Animation2.AnimateOnlyDifferences = True
        Animation2.BlindCoeff = CType(resources.GetObject("Animation2.BlindCoeff"), System.Drawing.PointF)
        Animation2.LeafCoeff = 0!
        Animation2.MaxTime = 1.0!
        Animation2.MinTime = 0!
        Animation2.MosaicCoeff = CType(resources.GetObject("Animation2.MosaicCoeff"), System.Drawing.PointF)
        Animation2.MosaicShift = CType(resources.GetObject("Animation2.MosaicShift"), System.Drawing.PointF)
        Animation2.MosaicSize = 0
        Animation2.Padding = New System.Windows.Forms.Padding(0)
        Animation2.RotateCoeff = 0!
        Animation2.RotateLimit = 0!
        Animation2.ScaleCoeff = CType(resources.GetObject("Animation2.ScaleCoeff"), System.Drawing.PointF)
        Animation2.SlideCoeff = CType(resources.GetObject("Animation2.SlideCoeff"), System.Drawing.PointF)
        Animation2.TimeCoeff = 0!
        Animation2.TransparencyCoeff = 0!
        Me.BunifuTransition2.DefaultAnimation = Animation2
        '
        'BunifuTransition3
        '
        Me.BunifuTransition3.AnimationType = BunifuAnimatorNS.AnimationType.Transparent
        Me.BunifuTransition3.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 0
        Animation1.Padding = New System.Windows.Forms.Padding(0)
        Animation1.RotateCoeff = 0!
        Animation1.RotateLimit = 0!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 0!
        Animation1.TransparencyCoeff = 1.0!
        Me.BunifuTransition3.DefaultAnimation = Animation1
        Me.BunifuTransition3.TimeStep = 0.03!
        '
        'frm_main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1376, 716)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Main_pnl)
        Me.Controls.Add(Me.Panel1)
        Me.BunifuTransition2.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT-Tool Dashboard"
        Me.Dashboard_pnl.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Main_pnl.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.gbox_file_info.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.gbox_work_file.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.gbox_players.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.gbox_prio.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GboxUList.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.pnl_header.ResumeLayout(False)
        CType(Me.main_gridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.User_Pnl.ResumeLayout(False)
        Me.User_Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Dashboard_pnl As Panel
    Friend WithEvents btn_viewreturn As Button
    Friend WithEvents btn_monitoring As Button
    Friend WithEvents btn_file_eval As Button
    Friend WithEvents btn_myeval As Button
    Friend WithEvents btn_workflow As Button
    Friend WithEvents btn_userlist As Button
    Friend WithEvents btn_files_due As Button
    Friend WithEvents btn_wait_tracker As Button
    Friend WithEvents btn_idle_tracker As Button
    Friend WithEvents btn_ratio_tracker As Button
    Friend WithEvents btn_flagging As Button
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btn_return As Button
    Friend WithEvents btn_hold As Button
    Friend WithEvents btn_cancel As Button
    Friend WithEvents btn_submit As Button
    Friend WithEvents btn_break As Button
    Public WithEvents BunifuTransition1 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition2 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition3 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents Main_pnl As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Exit_btn As Button
    Friend WithEvents pnl_header As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_file As Button
    Friend WithEvents btn_reference As Button
    Friend WithEvents btn_break_log As Button
    Friend WithEvents btn_report_log As Button
    Friend WithEvents btn_archive As Button
    Friend WithEvents btn_export As Button
    Friend WithEvents btn_upload As Button
    Friend WithEvents IdleTimer As Timer
    Friend WithEvents WaitTimer As Timer
    Friend WithEvents BWTimer As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_loginout As Button
    Friend WithEvents main_gridview As DataGridView
    Friend WithEvents User_Btn As Button
    Friend WithEvents User_Pnl As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents gbox_work_file As GroupBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents gbox_players As GroupBox
    Friend WithEvents GboxUList As GroupBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents cbo_qapr As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cbo_qabt As ComboBox
    Friend WithEvents cbo_bt As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cbo_pr As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cbo_qacc As ComboBox
    Friend WithEvents cbo_qast As ComboBox
    Friend WithEvents cbo_cc As ComboBox
    Friend WithEvents cbo_st As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents gbox_file_info As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cbo_service As DateTimePicker
    Friend WithEvents txt_accuracy As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_page As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_duration As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_receive As TextBox
    Friend WithEvents txt_branch As TextBox
    Friend WithEvents txt_client As TextBox
    Friend WithEvents txt_due As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents gbox_prio As GroupBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents chk_blank As CheckBox
    Friend WithEvents chk_rush As CheckBox
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents txt_document As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_audio As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents rd_pepsup As RadioButton
    Friend WithEvents rd_acqt As RadioButton
    Friend WithEvents rd_express As RadioButton
    Friend WithEvents btn_Doc As Button
    Friend WithEvents btn_Audio As Button
End Class
