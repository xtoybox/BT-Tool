<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_userlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_userlist))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim CheckBoxProperties1 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties2 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_userlist = New System.Windows.Forms.DataGridView()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbo_f_dep = New PresentationControls.CheckBoxComboBox()
        Me.cbo_f_pos = New PresentationControls.CheckBoxComboBox()
        Me.chk_f_deactivate = New System.Windows.Forms.CheckBox()
        Me.chk_f_online = New System.Windows.Forms.CheckBox()
        Me.txt_f_name = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chk_f_forbt = New System.Windows.Forms.CheckBox()
        Me.txt_f_uname = New System.Windows.Forms.TextBox()
        Me.chk_f_locked = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_open_restrict_editor = New System.Windows.Forms.Button()
        Me.tlp_contain_multi = New System.Windows.Forms.TableLayoutPanel()
        Me.btn_activate = New System.Windows.Forms.Button()
        Me.btn_deactivate = New System.Windows.Forms.Button()
        Me.btn_bt_off = New System.Windows.Forms.Button()
        Me.b = New System.Windows.Forms.Button()
        Me.btn_offline = New System.Windows.Forms.Button()
        Me.btn_bt_on = New System.Windows.Forms.Button()
        Me.btn_lock = New System.Windows.Forms.Button()
        Me.btn_unlock = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btn_edit_restrict = New System.Windows.Forms.Button()
        Me.chk_forbt = New System.Windows.Forms.CheckBox()
        Me.chk_online = New System.Windows.Forms.CheckBox()
        Me.chk_locked = New System.Windows.Forms.CheckBox()
        Me.chk_deactivate = New System.Windows.Forms.CheckBox()
        Me.cbo_locktime = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbo_pos = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_dep = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btn_showhide_pass = New System.Windows.Forms.Button()
        Me.txt_pass = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_userlist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.tlp_contain_multi.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(761, 30)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User List"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgv_userlist)
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(761, 604)
        Me.Panel2.TabIndex = 1
        '
        'dgv_userlist
        '
        Me.dgv_userlist.AllowUserToAddRows = False
        Me.dgv_userlist.AllowUserToDeleteRows = False
        Me.dgv_userlist.AllowUserToResizeRows = False
        Me.dgv_userlist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_userlist.BackgroundColor = System.Drawing.Color.White
        Me.dgv_userlist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_userlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_userlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_userlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_userlist.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_userlist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_userlist.Location = New System.Drawing.Point(218, 104)
        Me.dgv_userlist.Name = "dgv_userlist"
        Me.dgv_userlist.ReadOnly = True
        Me.dgv_userlist.RowHeadersVisible = False
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.dgv_userlist.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_userlist.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv_userlist.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.dgv_userlist.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.dgv_userlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_userlist.Size = New System.Drawing.Size(541, 498)
        Me.dgv_userlist.TabIndex = 4
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.Controls.Add(Me.GroupBox1)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(218, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel9.Size = New System.Drawing.Size(541, 104)
        Me.Panel9.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.cbo_f_dep)
        Me.GroupBox1.Controls.Add(Me.cbo_f_pos)
        Me.GroupBox1.Controls.Add(Me.chk_f_deactivate)
        Me.GroupBox1.Controls.Add(Me.chk_f_online)
        Me.GroupBox1.Controls.Add(Me.txt_f_name)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.chk_f_forbt)
        Me.GroupBox1.Controls.Add(Me.txt_f_uname)
        Me.GroupBox1.Controls.Add(Me.chk_f_locked)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(531, 94)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter:"
        '
        'cbo_f_dep
        '
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_f_dep.CheckBoxProperties = CheckBoxProperties1
        Me.cbo_f_dep.DisplayMemberSingleItem = ""
        Me.cbo_f_dep.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_f_dep.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_f_dep.FormattingEnabled = True
        Me.cbo_f_dep.Location = New System.Drawing.Point(233, 35)
        Me.cbo_f_dep.Name = "cbo_f_dep"
        Me.cbo_f_dep.Size = New System.Drawing.Size(107, 25)
        Me.cbo_f_dep.TabIndex = 30
        '
        'cbo_f_pos
        '
        CheckBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbo_f_pos.CheckBoxProperties = CheckBoxProperties2
        Me.cbo_f_pos.DisplayMemberSingleItem = ""
        Me.cbo_f_pos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_f_pos.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_f_pos.FormattingEnabled = True
        Me.cbo_f_pos.Location = New System.Drawing.Point(354, 35)
        Me.cbo_f_pos.Name = "cbo_f_pos"
        Me.cbo_f_pos.Size = New System.Drawing.Size(107, 25)
        Me.cbo_f_pos.TabIndex = 7
        '
        'chk_f_deactivate
        '
        Me.chk_f_deactivate.AutoSize = True
        Me.chk_f_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_f_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_deactivate.ForeColor = System.Drawing.Color.Black
        Me.chk_f_deactivate.Location = New System.Drawing.Point(210, 67)
        Me.chk_f_deactivate.Name = "chk_f_deactivate"
        Me.chk_f_deactivate.Size = New System.Drawing.Size(104, 21)
        Me.chk_f_deactivate.TabIndex = 28
        Me.chk_f_deactivate.Text = "Deactivated"
        Me.chk_f_deactivate.UseVisualStyleBackColor = True
        '
        'chk_f_online
        '
        Me.chk_f_online.AutoSize = True
        Me.chk_f_online.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_f_online.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_online.ForeColor = System.Drawing.Color.Black
        Me.chk_f_online.Location = New System.Drawing.Point(77, 67)
        Me.chk_f_online.Name = "chk_f_online"
        Me.chk_f_online.Size = New System.Drawing.Size(68, 21)
        Me.chk_f_online.TabIndex = 26
        Me.chk_f_online.Text = "Online"
        Me.chk_f_online.UseVisualStyleBackColor = True
        '
        'txt_f_name
        '
        Me.txt_f_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_f_name.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_f_name.Location = New System.Drawing.Point(9, 35)
        Me.txt_f_name.Name = "txt_f_name"
        Me.txt_f_name.Size = New System.Drawing.Size(101, 23)
        Me.txt_f_name.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(351, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Position:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(230, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Department:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(118, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Username:"
        '
        'chk_f_forbt
        '
        Me.chk_f_forbt.AutoSize = True
        Me.chk_f_forbt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_f_forbt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_forbt.ForeColor = System.Drawing.Color.Black
        Me.chk_f_forbt.Location = New System.Drawing.Point(12, 67)
        Me.chk_f_forbt.Name = "chk_f_forbt"
        Me.chk_f_forbt.Size = New System.Drawing.Size(62, 21)
        Me.chk_f_forbt.TabIndex = 25
        Me.chk_f_forbt.Text = "For BT"
        Me.chk_f_forbt.UseVisualStyleBackColor = True
        '
        'txt_f_uname
        '
        Me.txt_f_uname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_f_uname.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_f_uname.Location = New System.Drawing.Point(121, 35)
        Me.txt_f_uname.Name = "txt_f_uname"
        Me.txt_f_uname.Size = New System.Drawing.Size(101, 23)
        Me.txt_f_uname.TabIndex = 22
        '
        'chk_f_locked
        '
        Me.chk_f_locked.AutoSize = True
        Me.chk_f_locked.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_f_locked.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_locked.ForeColor = System.Drawing.Color.Black
        Me.chk_f_locked.Location = New System.Drawing.Point(145, 67)
        Me.chk_f_locked.Name = "chk_f_locked"
        Me.chk_f_locked.Size = New System.Drawing.Size(72, 21)
        Me.chk_f_locked.TabIndex = 27
        Me.chk_f_locked.Text = "Locked"
        Me.chk_f_locked.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.btn_open_restrict_editor)
        Me.Panel3.Controls.Add(Me.tlp_contain_multi)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.ForeColor = System.Drawing.Color.White
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(218, 602)
        Me.Panel3.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btn_save)
        Me.Panel6.Controls.Add(Me.btn_clear)
        Me.Panel6.Location = New System.Drawing.Point(5, 376)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(203, 33)
        Me.Panel6.TabIndex = 23
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.Black
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ForeColor = System.Drawing.Color.White
        Me.btn_save.Location = New System.Drawing.Point(0, 3)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(98, 24)
        Me.btn_save.TabIndex = 11
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.Black
        Me.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clear.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.Color.White
        Me.btn_clear.Location = New System.Drawing.Point(102, 3)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(101, 24)
        Me.btn_clear.TabIndex = 12
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_open_restrict_editor
        '
        Me.btn_open_restrict_editor.BackColor = System.Drawing.Color.Black
        Me.btn_open_restrict_editor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_open_restrict_editor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_open_restrict_editor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_open_restrict_editor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_open_restrict_editor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_open_restrict_editor.ForeColor = System.Drawing.Color.White
        Me.btn_open_restrict_editor.Location = New System.Drawing.Point(0, 566)
        Me.btn_open_restrict_editor.Name = "btn_open_restrict_editor"
        Me.btn_open_restrict_editor.Size = New System.Drawing.Size(216, 34)
        Me.btn_open_restrict_editor.TabIndex = 12
        Me.btn_open_restrict_editor.Text = "Open User Restriction Editor"
        Me.btn_open_restrict_editor.UseVisualStyleBackColor = False
        '
        'tlp_contain_multi
        '
        Me.tlp_contain_multi.BackColor = System.Drawing.SystemColors.Control
        Me.tlp_contain_multi.ColumnCount = 2
        Me.tlp_contain_multi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_contain_multi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlp_contain_multi.Controls.Add(Me.btn_activate, 0, 0)
        Me.tlp_contain_multi.Controls.Add(Me.btn_deactivate, 1, 0)
        Me.tlp_contain_multi.Controls.Add(Me.btn_bt_off, 1, 3)
        Me.tlp_contain_multi.Controls.Add(Me.b, 0, 1)
        Me.tlp_contain_multi.Controls.Add(Me.btn_offline, 1, 1)
        Me.tlp_contain_multi.Controls.Add(Me.btn_bt_on, 0, 3)
        Me.tlp_contain_multi.Controls.Add(Me.btn_lock, 0, 2)
        Me.tlp_contain_multi.Controls.Add(Me.btn_unlock, 1, 2)
        Me.tlp_contain_multi.Location = New System.Drawing.Point(0, 445)
        Me.tlp_contain_multi.Name = "tlp_contain_multi"
        Me.tlp_contain_multi.RowCount = 4
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlp_contain_multi.Size = New System.Drawing.Size(213, 121)
        Me.tlp_contain_multi.TabIndex = 22
        '
        'btn_activate
        '
        Me.btn_activate.BackColor = System.Drawing.Color.Black
        Me.btn_activate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_activate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_activate.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_activate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_activate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_activate.ForeColor = System.Drawing.Color.White
        Me.btn_activate.Location = New System.Drawing.Point(3, 3)
        Me.btn_activate.Name = "btn_activate"
        Me.btn_activate.Size = New System.Drawing.Size(100, 24)
        Me.btn_activate.TabIndex = 13
        Me.btn_activate.Tag = "deactivated=0"
        Me.btn_activate.Text = "Activate"
        Me.btn_activate.UseVisualStyleBackColor = False
        '
        'btn_deactivate
        '
        Me.btn_deactivate.BackColor = System.Drawing.Color.Black
        Me.btn_deactivate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_deactivate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_deactivate.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deactivate.ForeColor = System.Drawing.Color.White
        Me.btn_deactivate.Location = New System.Drawing.Point(109, 3)
        Me.btn_deactivate.Name = "btn_deactivate"
        Me.btn_deactivate.Size = New System.Drawing.Size(101, 24)
        Me.btn_deactivate.TabIndex = 14
        Me.btn_deactivate.Tag = "deactivated=1"
        Me.btn_deactivate.Text = "Deactivate"
        Me.btn_deactivate.UseVisualStyleBackColor = False
        '
        'btn_bt_off
        '
        Me.btn_bt_off.BackColor = System.Drawing.Color.Black
        Me.btn_bt_off.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_bt_off.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_bt_off.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_bt_off.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bt_off.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bt_off.ForeColor = System.Drawing.Color.White
        Me.btn_bt_off.Location = New System.Drawing.Point(109, 93)
        Me.btn_bt_off.Name = "btn_bt_off"
        Me.btn_bt_off.Size = New System.Drawing.Size(101, 25)
        Me.btn_bt_off.TabIndex = 20
        Me.btn_bt_off.Tag = "btwork=0"
        Me.btn_bt_off.Text = "BT Off"
        Me.btn_bt_off.UseVisualStyleBackColor = False
        '
        'b
        '
        Me.b.BackColor = System.Drawing.Color.Black
        Me.b.Cursor = System.Windows.Forms.Cursors.Hand
        Me.b.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b.ForeColor = System.Drawing.Color.White
        Me.b.Location = New System.Drawing.Point(3, 33)
        Me.b.Name = "b"
        Me.b.Size = New System.Drawing.Size(100, 24)
        Me.b.TabIndex = 15
        Me.b.Tag = "status=1"
        Me.b.Text = "Online"
        Me.b.UseVisualStyleBackColor = False
        '
        'btn_offline
        '
        Me.btn_offline.BackColor = System.Drawing.Color.Black
        Me.btn_offline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_offline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_offline.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_offline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_offline.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_offline.ForeColor = System.Drawing.Color.White
        Me.btn_offline.Location = New System.Drawing.Point(109, 33)
        Me.btn_offline.Name = "btn_offline"
        Me.btn_offline.Size = New System.Drawing.Size(101, 24)
        Me.btn_offline.TabIndex = 16
        Me.btn_offline.Tag = "status=0"
        Me.btn_offline.Text = "Offline"
        Me.btn_offline.UseVisualStyleBackColor = False
        '
        'btn_bt_on
        '
        Me.btn_bt_on.BackColor = System.Drawing.Color.Black
        Me.btn_bt_on.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_bt_on.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_bt_on.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_bt_on.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bt_on.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bt_on.ForeColor = System.Drawing.Color.White
        Me.btn_bt_on.Location = New System.Drawing.Point(3, 93)
        Me.btn_bt_on.Name = "btn_bt_on"
        Me.btn_bt_on.Size = New System.Drawing.Size(100, 25)
        Me.btn_bt_on.TabIndex = 19
        Me.btn_bt_on.Tag = "btwork=1"
        Me.btn_bt_on.Text = "BT On"
        Me.btn_bt_on.UseVisualStyleBackColor = False
        '
        'btn_lock
        '
        Me.btn_lock.BackColor = System.Drawing.Color.Black
        Me.btn_lock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_lock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_lock.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_lock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lock.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lock.ForeColor = System.Drawing.Color.White
        Me.btn_lock.Location = New System.Drawing.Point(3, 63)
        Me.btn_lock.Name = "btn_lock"
        Me.btn_lock.Size = New System.Drawing.Size(100, 24)
        Me.btn_lock.TabIndex = 17
        Me.btn_lock.Tag = "locked=1"
        Me.btn_lock.Text = "Lock"
        Me.btn_lock.UseVisualStyleBackColor = False
        '
        'btn_unlock
        '
        Me.btn_unlock.BackColor = System.Drawing.Color.Black
        Me.btn_unlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_unlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_unlock.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_unlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_unlock.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_unlock.ForeColor = System.Drawing.Color.White
        Me.btn_unlock.Location = New System.Drawing.Point(109, 63)
        Me.btn_unlock.Name = "btn_unlock"
        Me.btn_unlock.Size = New System.Drawing.Size(101, 24)
        Me.btn_unlock.TabIndex = 18
        Me.btn_unlock.Tag = "locked=0"
        Me.btn_unlock.Text = "Unlock"
        Me.btn_unlock.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 411)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(213, 31)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Selected Item Action"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Control
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.cbo_locktime)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.cbo_pos)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.cbo_dep)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txt_uname)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.txt_name)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 31)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(216, 348)
        Me.Panel4.TabIndex = 20
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btn_edit_restrict)
        Me.Panel5.Controls.Add(Me.chk_forbt)
        Me.Panel5.Controls.Add(Me.chk_online)
        Me.Panel5.Controls.Add(Me.chk_locked)
        Me.Panel5.Controls.Add(Me.chk_deactivate)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(5, 270)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(206, 74)
        Me.Panel5.TabIndex = 22
        '
        'btn_edit_restrict
        '
        Me.btn_edit_restrict.BackColor = System.Drawing.Color.Black
        Me.btn_edit_restrict.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_edit_restrict.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btn_edit_restrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_edit_restrict.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit_restrict.ForeColor = System.Drawing.Color.White
        Me.btn_edit_restrict.Location = New System.Drawing.Point(0, 47)
        Me.btn_edit_restrict.Name = "btn_edit_restrict"
        Me.btn_edit_restrict.Size = New System.Drawing.Size(203, 25)
        Me.btn_edit_restrict.TabIndex = 11
        Me.btn_edit_restrict.Text = "Edit Restrictions"
        Me.btn_edit_restrict.UseVisualStyleBackColor = False
        '
        'chk_forbt
        '
        Me.chk_forbt.AutoSize = True
        Me.chk_forbt.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_forbt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_forbt.ForeColor = System.Drawing.Color.Black
        Me.chk_forbt.Location = New System.Drawing.Point(113, 7)
        Me.chk_forbt.Name = "chk_forbt"
        Me.chk_forbt.Size = New System.Drawing.Size(62, 21)
        Me.chk_forbt.TabIndex = 9
        Me.chk_forbt.Text = "For BT"
        Me.chk_forbt.UseVisualStyleBackColor = True
        '
        'chk_online
        '
        Me.chk_online.AutoSize = True
        Me.chk_online.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_online.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_online.ForeColor = System.Drawing.Color.Black
        Me.chk_online.Location = New System.Drawing.Point(3, 7)
        Me.chk_online.Name = "chk_online"
        Me.chk_online.Size = New System.Drawing.Size(68, 21)
        Me.chk_online.TabIndex = 7
        Me.chk_online.Text = "Online"
        Me.chk_online.UseVisualStyleBackColor = True
        '
        'chk_locked
        '
        Me.chk_locked.AutoSize = True
        Me.chk_locked.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_locked.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_locked.ForeColor = System.Drawing.Color.Black
        Me.chk_locked.Location = New System.Drawing.Point(3, 24)
        Me.chk_locked.Name = "chk_locked"
        Me.chk_locked.Size = New System.Drawing.Size(72, 21)
        Me.chk_locked.TabIndex = 8
        Me.chk_locked.Text = "Locked"
        Me.chk_locked.UseVisualStyleBackColor = True
        '
        'chk_deactivate
        '
        Me.chk_deactivate.AutoSize = True
        Me.chk_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chk_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_deactivate.ForeColor = System.Drawing.Color.Black
        Me.chk_deactivate.Location = New System.Drawing.Point(113, 24)
        Me.chk_deactivate.Name = "chk_deactivate"
        Me.chk_deactivate.Size = New System.Drawing.Size(96, 21)
        Me.chk_deactivate.TabIndex = 10
        Me.chk_deactivate.Text = "Deactivate"
        Me.chk_deactivate.UseVisualStyleBackColor = True
        '
        'cbo_locktime
        '
        Me.cbo_locktime.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_locktime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_locktime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_locktime.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_locktime.FormattingEnabled = True
        Me.cbo_locktime.Location = New System.Drawing.Point(5, 246)
        Me.cbo_locktime.Name = "cbo_locktime"
        Me.cbo_locktime.Size = New System.Drawing.Size(206, 24)
        Me.cbo_locktime.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(5, 224)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(206, 22)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Lock Time:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbo_pos
        '
        Me.cbo_pos.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_pos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_pos.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_pos.FormattingEnabled = True
        Me.cbo_pos.Location = New System.Drawing.Point(5, 200)
        Me.cbo_pos.Name = "cbo_pos"
        Me.cbo_pos.Size = New System.Drawing.Size(206, 24)
        Me.cbo_pos.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(5, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(206, 22)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Position:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbo_dep
        '
        Me.cbo_dep.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dep.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbo_dep.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dep.FormattingEnabled = True
        Me.cbo_dep.Location = New System.Drawing.Point(5, 154)
        Me.cbo_dep.Name = "cbo_dep"
        Me.cbo_dep.Size = New System.Drawing.Size(206, 24)
        Me.cbo_dep.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(5, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(206, 22)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Department:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btn_showhide_pass)
        Me.Panel8.Controls.Add(Me.txt_pass)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(5, 110)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(206, 22)
        Me.Panel8.TabIndex = 21
        '
        'btn_showhide_pass
        '
        Me.btn_showhide_pass.BackColor = System.Drawing.Color.White
        Me.btn_showhide_pass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_showhide_pass.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_showhide_pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_showhide_pass.ForeColor = System.Drawing.Color.Black
        Me.btn_showhide_pass.Location = New System.Drawing.Point(173, 0)
        Me.btn_showhide_pass.Name = "btn_showhide_pass"
        Me.btn_showhide_pass.Size = New System.Drawing.Size(33, 21)
        Me.btn_showhide_pass.TabIndex = 6
        Me.btn_showhide_pass.UseVisualStyleBackColor = False
        '
        'txt_pass
        '
        Me.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pass.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_pass.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pass.Location = New System.Drawing.Point(0, 0)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.Size = New System.Drawing.Size(174, 21)
        Me.txt_pass.TabIndex = 3
        Me.txt_pass.UseSystemPasswordChar = True
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(206, 22)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Password:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_uname
        '
        Me.txt_uname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_uname.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_uname.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_uname.Location = New System.Drawing.Point(5, 67)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.Size = New System.Drawing.Size(206, 21)
        Me.txt_uname.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(206, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Username:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_name
        '
        Me.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_name.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_name.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_name.Location = New System.Drawing.Point(5, 24)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(206, 21)
        Me.txt_name.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(5, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(206, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(216, 31)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Add/ Edit User"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(730, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frm_userlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(761, 634)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_userlist"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT-Tool Userlist"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv_userlist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.tlp_contain_multi.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_open_restrict_editor As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btn_clear As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btn_edit_restrict As Button
    Friend WithEvents chk_forbt As CheckBox
    Friend WithEvents chk_online As CheckBox
    Friend WithEvents chk_locked As CheckBox
    Friend WithEvents chk_deactivate As CheckBox
    Friend WithEvents cbo_locktime As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cbo_pos As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbo_dep As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents btn_showhide_pass As Button
    Friend WithEvents txt_pass As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_uname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_name As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents tlp_contain_multi As TableLayoutPanel
    Friend WithEvents btn_activate As Button
    Friend WithEvents btn_deactivate As Button
    Friend WithEvents btn_bt_off As Button
    Friend WithEvents b As Button
    Friend WithEvents btn_offline As Button
    Friend WithEvents btn_bt_on As Button
    Friend WithEvents btn_lock As Button
    Friend WithEvents btn_unlock As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chk_f_deactivate As CheckBox
    Friend WithEvents chk_f_online As CheckBox
    Friend WithEvents txt_f_name As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents chk_f_forbt As CheckBox
    Friend WithEvents txt_f_uname As TextBox
    Friend WithEvents chk_f_locked As CheckBox
    Friend WithEvents dgv_userlist As DataGridView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cbo_f_dep As PresentationControls.CheckBoxComboBox
    Friend WithEvents cbo_f_pos As PresentationControls.CheckBoxComboBox
    Friend WithEvents Button1 As Button
End Class
