<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_flagging
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_flagging))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgv_flag = New System.Windows.Forms.DataGridView()
        Me.pnl_group_container = New System.Windows.Forms.Panel()
        Me.tlp_flag_form_container = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_client = New System.Windows.Forms.Label()
        Me.lbl_filename = New System.Windows.Forms.Label()
        Me.lbl_problem = New System.Windows.Forms.Label()
        Me.cbo_client = New System.Windows.Forms.ComboBox()
        Me.txt_filename = New System.Windows.Forms.TextBox()
        Me.rtxt_problem = New System.Windows.Forms.RichTextBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.tlp_seen_unseen_container = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_seen = New System.Windows.Forms.Button()
        Me.btn_unseen = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tlp_filter_export = New System.Windows.Forms.TableLayoutPanel()
        Me.label2 = New System.Windows.Forms.Label()
        Me.cbo_dep = New System.Windows.Forms.ComboBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.dtpicker = New System.Windows.Forms.DateTimePicker()
        Me.lbl_type = New System.Windows.Forms.Label()
        Me.cbo_type = New System.Windows.Forms.ComboBox()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.btn_reload = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.strip_info = New System.Windows.Forms.StatusStrip()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.dgv_flag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_group_container.SuspendLayout()
        Me.tlp_flag_form_container.SuspendLayout()
        Me.tlp_seen_unseen_container.SuspendLayout()
        Me.tlp_filter_export.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.strip_info.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgv_flag)
        Me.Panel1.Controls.Add(Me.pnl_group_container)
        Me.Panel1.Controls.Add(Me.strip_info)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(998, 627)
        Me.Panel1.TabIndex = 0
        '
        'dgv_flag
        '
        Me.dgv_flag.AllowUserToAddRows = False
        Me.dgv_flag.AllowUserToDeleteRows = False
        Me.dgv_flag.AllowUserToResizeRows = False
        Me.dgv_flag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_flag.BackgroundColor = System.Drawing.Color.White
        Me.dgv_flag.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_flag.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Roboto", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_flag.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_flag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_flag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_flag.Location = New System.Drawing.Point(200, 28)
        Me.dgv_flag.Name = "dgv_flag"
        Me.dgv_flag.ReadOnly = True
        Me.dgv_flag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.dgv_flag.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_flag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgv_flag.Size = New System.Drawing.Size(796, 575)
        Me.dgv_flag.TabIndex = 7
        '
        'pnl_group_container
        '
        Me.pnl_group_container.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnl_group_container.Controls.Add(Me.tlp_flag_form_container)
        Me.pnl_group_container.Controls.Add(Me.label1)
        Me.pnl_group_container.Controls.Add(Me.tlp_filter_export)
        Me.pnl_group_container.Controls.Add(Me.label4)
        Me.pnl_group_container.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnl_group_container.ForeColor = System.Drawing.Color.White
        Me.pnl_group_container.Location = New System.Drawing.Point(0, 28)
        Me.pnl_group_container.Name = "pnl_group_container"
        Me.pnl_group_container.Size = New System.Drawing.Size(200, 575)
        Me.pnl_group_container.TabIndex = 6
        '
        'tlp_flag_form_container
        '
        Me.tlp_flag_form_container.ColumnCount = 1
        Me.tlp_flag_form_container.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_flag_form_container.Controls.Add(Me.lbl_client, 0, 0)
        Me.tlp_flag_form_container.Controls.Add(Me.lbl_filename, 0, 2)
        Me.tlp_flag_form_container.Controls.Add(Me.lbl_problem, 0, 4)
        Me.tlp_flag_form_container.Controls.Add(Me.cbo_client, 0, 1)
        Me.tlp_flag_form_container.Controls.Add(Me.txt_filename, 0, 3)
        Me.tlp_flag_form_container.Controls.Add(Me.rtxt_problem, 0, 5)
        Me.tlp_flag_form_container.Controls.Add(Me.btn_save, 0, 6)
        Me.tlp_flag_form_container.Controls.Add(Me.btn_delete, 0, 7)
        Me.tlp_flag_form_container.Controls.Add(Me.tlp_seen_unseen_container, 0, 8)
        Me.tlp_flag_form_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_flag_form_container.ForeColor = System.Drawing.Color.White
        Me.tlp_flag_form_container.Location = New System.Drawing.Point(0, 240)
        Me.tlp_flag_form_container.Name = "tlp_flag_form_container"
        Me.tlp_flag_form_container.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.tlp_flag_form_container.RowCount = 9
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_flag_form_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.tlp_flag_form_container.Size = New System.Drawing.Size(200, 335)
        Me.tlp_flag_form_container.TabIndex = 0
        '
        'lbl_client
        '
        Me.lbl_client.AutoSize = True
        Me.lbl_client.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_client.Location = New System.Drawing.Point(8, 5)
        Me.lbl_client.Name = "lbl_client"
        Me.lbl_client.Size = New System.Drawing.Size(42, 15)
        Me.lbl_client.TabIndex = 0
        Me.lbl_client.Text = "Client:"
        '
        'lbl_filename
        '
        Me.lbl_filename.AutoSize = True
        Me.lbl_filename.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_filename.Location = New System.Drawing.Point(8, 50)
        Me.lbl_filename.Name = "lbl_filename"
        Me.lbl_filename.Size = New System.Drawing.Size(59, 15)
        Me.lbl_filename.TabIndex = 1
        Me.lbl_filename.Text = "Filename:"
        '
        'lbl_problem
        '
        Me.lbl_problem.AutoSize = True
        Me.lbl_problem.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_problem.Location = New System.Drawing.Point(8, 95)
        Me.lbl_problem.Name = "lbl_problem"
        Me.lbl_problem.Size = New System.Drawing.Size(55, 15)
        Me.lbl_problem.TabIndex = 2
        Me.lbl_problem.Text = "Problem:"
        '
        'cbo_client
        '
        Me.cbo_client.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_client.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_client.FormattingEnabled = True
        Me.cbo_client.Location = New System.Drawing.Point(8, 23)
        Me.cbo_client.Name = "cbo_client"
        Me.cbo_client.Size = New System.Drawing.Size(184, 24)
        Me.cbo_client.TabIndex = 3
        '
        'txt_filename
        '
        Me.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_filename.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txt_filename.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_filename.Location = New System.Drawing.Point(8, 68)
        Me.txt_filename.Name = "txt_filename"
        Me.txt_filename.Size = New System.Drawing.Size(184, 21)
        Me.txt_filename.TabIndex = 4
        '
        'rtxt_problem
        '
        Me.rtxt_problem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtxt_problem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxt_problem.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxt_problem.Location = New System.Drawing.Point(8, 113)
        Me.rtxt_problem.Name = "rtxt_problem"
        Me.rtxt_problem.Size = New System.Drawing.Size(184, 120)
        Me.rtxt_problem.TabIndex = 5
        Me.rtxt_problem.Text = ""
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.DimGray
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_save.FlatAppearance.BorderSize = 0
        Me.btn_save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ForeColor = System.Drawing.Color.White
        Me.btn_save.Location = New System.Drawing.Point(8, 239)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(184, 27)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.DimGray
        Me.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_delete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_delete.FlatAppearance.BorderSize = 0
        Me.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_delete.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.ForeColor = System.Drawing.Color.White
        Me.btn_delete.Location = New System.Drawing.Point(8, 272)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(184, 27)
        Me.btn_delete.TabIndex = 7
        Me.btn_delete.Text = "Delete"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'tlp_seen_unseen_container
        '
        Me.tlp_seen_unseen_container.ColumnCount = 2
        Me.tlp_seen_unseen_container.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_seen_unseen_container.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_seen_unseen_container.Controls.Add(Me.btn_seen, 0, 0)
        Me.tlp_seen_unseen_container.Controls.Add(Me.btn_unseen, 1, 0)
        Me.tlp_seen_unseen_container.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlp_seen_unseen_container.Location = New System.Drawing.Point(5, 302)
        Me.tlp_seen_unseen_container.Margin = New System.Windows.Forms.Padding(0)
        Me.tlp_seen_unseen_container.Name = "tlp_seen_unseen_container"
        Me.tlp_seen_unseen_container.RowCount = 1
        Me.tlp_seen_unseen_container.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_seen_unseen_container.Size = New System.Drawing.Size(190, 33)
        Me.tlp_seen_unseen_container.TabIndex = 8
        '
        'btn_seen
        '
        Me.btn_seen.BackColor = System.Drawing.Color.DimGray
        Me.btn_seen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_seen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_seen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_seen.FlatAppearance.BorderSize = 0
        Me.btn_seen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_seen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_seen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_seen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_seen.ForeColor = System.Drawing.Color.White
        Me.btn_seen.Location = New System.Drawing.Point(3, 3)
        Me.btn_seen.Name = "btn_seen"
        Me.btn_seen.Size = New System.Drawing.Size(89, 27)
        Me.btn_seen.TabIndex = 0
        Me.btn_seen.Text = "Seen"
        Me.btn_seen.UseVisualStyleBackColor = False
        '
        'btn_unseen
        '
        Me.btn_unseen.BackColor = System.Drawing.Color.DimGray
        Me.btn_unseen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_unseen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_unseen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_unseen.FlatAppearance.BorderSize = 0
        Me.btn_unseen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_unseen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_unseen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_unseen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_unseen.ForeColor = System.Drawing.Color.White
        Me.btn_unseen.Location = New System.Drawing.Point(98, 3)
        Me.btn_unseen.Name = "btn_unseen"
        Me.btn_unseen.Size = New System.Drawing.Size(89, 27)
        Me.btn_unseen.TabIndex = 1
        Me.btn_unseen.Text = "Unseen"
        Me.btn_unseen.UseVisualStyleBackColor = False
        '
        'label1
        '
        Me.label1.BackColor = System.Drawing.Color.Black
        Me.label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.White
        Me.label1.Location = New System.Drawing.Point(0, 210)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(200, 30)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Flagging Form"
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tlp_filter_export
        '
        Me.tlp_filter_export.ColumnCount = 1
        Me.tlp_filter_export.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_filter_export.Controls.Add(Me.label2, 0, 0)
        Me.tlp_filter_export.Controls.Add(Me.cbo_dep, 0, 5)
        Me.tlp_filter_export.Controls.Add(Me.label3, 0, 4)
        Me.tlp_filter_export.Controls.Add(Me.dtpicker, 0, 1)
        Me.tlp_filter_export.Controls.Add(Me.lbl_type, 0, 2)
        Me.tlp_filter_export.Controls.Add(Me.cbo_type, 0, 3)
        Me.tlp_filter_export.Controls.Add(Me.tableLayoutPanel2, 0, 6)
        Me.tlp_filter_export.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_filter_export.ForeColor = System.Drawing.Color.White
        Me.tlp_filter_export.Location = New System.Drawing.Point(0, 30)
        Me.tlp_filter_export.Name = "tlp_filter_export"
        Me.tlp_filter_export.Padding = New System.Windows.Forms.Padding(5, 5, 5, 0)
        Me.tlp_filter_export.RowCount = 7
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_filter_export.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlp_filter_export.Size = New System.Drawing.Size(200, 180)
        Me.tlp_filter_export.TabIndex = 6
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.ForeColor = System.Drawing.Color.White
        Me.label2.Location = New System.Drawing.Point(8, 5)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 15)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Date:"
        '
        'cbo_dep
        '
        Me.cbo_dep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_dep.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dep.FormattingEnabled = True
        Me.cbo_dep.Location = New System.Drawing.Point(8, 113)
        Me.cbo_dep.Name = "cbo_dep"
        Me.cbo_dep.Size = New System.Drawing.Size(184, 24)
        Me.cbo_dep.TabIndex = 2
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(8, 95)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(77, 15)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Department:"
        '
        'dtpicker
        '
        Me.dtpicker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpicker.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker.Location = New System.Drawing.Point(8, 23)
        Me.dtpicker.Name = "dtpicker"
        Me.dtpicker.Size = New System.Drawing.Size(184, 21)
        Me.dtpicker.TabIndex = 0
        '
        'lbl_type
        '
        Me.lbl_type.AutoSize = True
        Me.lbl_type.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_type.ForeColor = System.Drawing.Color.White
        Me.lbl_type.Location = New System.Drawing.Point(8, 50)
        Me.lbl_type.Name = "lbl_type"
        Me.lbl_type.Size = New System.Drawing.Size(37, 15)
        Me.lbl_type.TabIndex = 3
        Me.lbl_type.Text = "Type:"
        '
        'cbo_type
        '
        Me.cbo_type.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbo_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_type.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_type.FormattingEnabled = True
        Me.cbo_type.Location = New System.Drawing.Point(8, 68)
        Me.cbo_type.Name = "cbo_type"
        Me.cbo_type.Size = New System.Drawing.Size(184, 24)
        Me.cbo_type.TabIndex = 1
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 2
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.btn_export, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.btn_reload, 1, 0)
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(8, 143)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 1
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(184, 34)
        Me.tableLayoutPanel2.TabIndex = 6
        '
        'btn_export
        '
        Me.btn_export.BackColor = System.Drawing.Color.DimGray
        Me.btn_export.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_export.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_export.FlatAppearance.BorderSize = 0
        Me.btn_export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_export.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.ForeColor = System.Drawing.Color.White
        Me.btn_export.Location = New System.Drawing.Point(3, 3)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(86, 28)
        Me.btn_export.TabIndex = 0
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = False
        '
        'btn_reload
        '
        Me.btn_reload.BackColor = System.Drawing.Color.DimGray
        Me.btn_reload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_reload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_reload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_reload.FlatAppearance.BorderSize = 0
        Me.btn_reload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver
        Me.btn_reload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reload.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reload.ForeColor = System.Drawing.Color.White
        Me.btn_reload.Location = New System.Drawing.Point(95, 3)
        Me.btn_reload.Name = "btn_reload"
        Me.btn_reload.Size = New System.Drawing.Size(86, 28)
        Me.btn_reload.TabIndex = 1
        Me.btn_reload.Text = "Reload"
        Me.btn_reload.UseVisualStyleBackColor = False
        '
        'label4
        '
        Me.label4.BackColor = System.Drawing.Color.Black
        Me.label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.label4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(0, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(200, 30)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Filter / Export"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'strip_info
        '
        Me.strip_info.BackColor = System.Drawing.Color.DimGray
        Me.strip_info.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_status})
        Me.strip_info.Location = New System.Drawing.Point(0, 603)
        Me.strip_info.Name = "strip_info"
        Me.strip_info.Size = New System.Drawing.Size(996, 22)
        Me.strip_info.TabIndex = 5
        Me.strip_info.Text = "statusStrip1"
        '
        'tss_status
        '
        Me.tss_status.BackColor = System.Drawing.Color.DimGray
        Me.tss_status.ForeColor = System.Drawing.Color.White
        Me.tss_status.Name = "tss_status"
        Me.tss_status.Size = New System.Drawing.Size(109, 17)
        Me.tss_status.Text = "toolStripStatusLabel1"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(996, 28)
        Me.Panel2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Flagging"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.BT_Tool.My.Resources.Resources.close1
        Me.Button1.Location = New System.Drawing.Point(967, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel2
        Me.BunifuDragControl1.Vertical = True
        '
        'frm_flagging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 627)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_flagging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT-Tool Flagging"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv_flag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_group_container.ResumeLayout(False)
        Me.tlp_flag_form_container.ResumeLayout(False)
        Me.tlp_flag_form_container.PerformLayout()
        Me.tlp_seen_unseen_container.ResumeLayout(False)
        Me.tlp_filter_export.ResumeLayout(False)
        Me.tlp_filter_export.PerformLayout()
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.strip_info.ResumeLayout(False)
        Me.strip_info.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents pnl_group_container As Panel
    Private WithEvents tlp_flag_form_container As TableLayoutPanel
    Private WithEvents lbl_client As Label
    Private WithEvents lbl_filename As Label
    Private WithEvents lbl_problem As Label
    Private WithEvents cbo_client As ComboBox
    Private WithEvents txt_filename As TextBox
    Private WithEvents rtxt_problem As RichTextBox
    Private WithEvents btn_save As Button
    Private WithEvents btn_delete As Button
    Private WithEvents tlp_seen_unseen_container As TableLayoutPanel
    Private WithEvents btn_seen As Button
    Private WithEvents btn_unseen As Button
    Private WithEvents label1 As Label
    Private WithEvents tlp_filter_export As TableLayoutPanel
    Private WithEvents label2 As Label
    Private WithEvents cbo_dep As ComboBox
    Private WithEvents label3 As Label
    Private WithEvents dtpicker As DateTimePicker
    Private WithEvents lbl_type As Label
    Private WithEvents cbo_type As ComboBox
    Private WithEvents tableLayoutPanel2 As TableLayoutPanel
    Private WithEvents btn_export As Button
    Private WithEvents btn_reload As Button
    Private WithEvents label4 As Label
    Private WithEvents strip_info As StatusStrip
    Private WithEvents tss_status As ToolStripStatusLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Private WithEvents dgv_flag As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
End Class
