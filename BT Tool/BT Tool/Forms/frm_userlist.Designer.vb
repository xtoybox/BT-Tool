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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btn_clear = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_showhide_pass = New System.Windows.Forms.Button()
        Me.txt_pass = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chk_f_deactivate = New System.Windows.Forms.CheckBox()
        Me.chk_f_online = New System.Windows.Forms.CheckBox()
        Me.txt_f_name = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chk_f_forbt = New System.Windows.Forms.CheckBox()
        Me.txt_f_uname = New System.Windows.Forms.TextBox()
        Me.chk_f_locked = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.tlp_contain_multi.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(739, 32)
        Me.Panel1.TabIndex = 0
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.DarkRed
        Me.btn_exit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.ForeColor = System.Drawing.Color.Transparent
        Me.btn_exit.Image = Global.BT_Tool.My.Resources.Resources.close1
        Me.btn_exit.Location = New System.Drawing.Point(708, 0)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(31, 32)
        Me.btn_exit.TabIndex = 2
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.tlp_contain_multi)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.ForeColor = System.Drawing.Color.White
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(196, 566)
        Me.Panel2.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btn_open_restrict_editor)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 538)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.Panel7.Size = New System.Drawing.Size(196, 27)
        Me.Panel7.TabIndex = 23
        '
        'btn_open_restrict_editor
        '
        Me.btn_open_restrict_editor.BackColor = System.Drawing.Color.Gray
        Me.btn_open_restrict_editor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_open_restrict_editor.Dock = System.Windows.Forms.DockStyle.Top
        Me.btn_open_restrict_editor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_open_restrict_editor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_open_restrict_editor.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_open_restrict_editor.Location = New System.Drawing.Point(3, 0)
        Me.btn_open_restrict_editor.Name = "btn_open_restrict_editor"
        Me.btn_open_restrict_editor.Size = New System.Drawing.Size(190, 23)
        Me.btn_open_restrict_editor.TabIndex = 12
        Me.btn_open_restrict_editor.Text = "Open User Restriction Editor"
        Me.btn_open_restrict_editor.UseVisualStyleBackColor = False
        '
        'tlp_contain_multi
        '
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
        Me.tlp_contain_multi.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlp_contain_multi.Location = New System.Drawing.Point(0, 428)
        Me.tlp_contain_multi.Name = "tlp_contain_multi"
        Me.tlp_contain_multi.RowCount = 4
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlp_contain_multi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlp_contain_multi.Size = New System.Drawing.Size(196, 110)
        Me.tlp_contain_multi.TabIndex = 22
        '
        'btn_activate
        '
        Me.btn_activate.BackColor = System.Drawing.Color.Gray
        Me.btn_activate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_activate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_activate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_activate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_activate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_activate.Location = New System.Drawing.Point(3, 3)
        Me.btn_activate.Name = "btn_activate"
        Me.btn_activate.Size = New System.Drawing.Size(92, 23)
        Me.btn_activate.TabIndex = 13
        Me.btn_activate.Tag = "deactivated=0"
        Me.btn_activate.Text = "Activate"
        Me.btn_activate.UseVisualStyleBackColor = False
        '
        'btn_deactivate
        '
        Me.btn_deactivate.BackColor = System.Drawing.Color.Gray
        Me.btn_deactivate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_deactivate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_deactivate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_deactivate.Location = New System.Drawing.Point(101, 3)
        Me.btn_deactivate.Name = "btn_deactivate"
        Me.btn_deactivate.Size = New System.Drawing.Size(92, 23)
        Me.btn_deactivate.TabIndex = 14
        Me.btn_deactivate.Tag = "deactivated=1"
        Me.btn_deactivate.Text = "Deactivate"
        Me.btn_deactivate.UseVisualStyleBackColor = False
        '
        'btn_bt_off
        '
        Me.btn_bt_off.BackColor = System.Drawing.Color.Gray
        Me.btn_bt_off.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_bt_off.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_bt_off.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_bt_off.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bt_off.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bt_off.Location = New System.Drawing.Point(101, 84)
        Me.btn_bt_off.Name = "btn_bt_off"
        Me.btn_bt_off.Size = New System.Drawing.Size(92, 23)
        Me.btn_bt_off.TabIndex = 20
        Me.btn_bt_off.Tag = "btwork=0"
        Me.btn_bt_off.Text = "BT Off"
        Me.btn_bt_off.UseVisualStyleBackColor = False
        '
        'b
        '
        Me.b.BackColor = System.Drawing.Color.Gray
        Me.b.Cursor = System.Windows.Forms.Cursors.Hand
        Me.b.Dock = System.Windows.Forms.DockStyle.Fill
        Me.b.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.b.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.b.Location = New System.Drawing.Point(3, 30)
        Me.b.Name = "b"
        Me.b.Size = New System.Drawing.Size(92, 23)
        Me.b.TabIndex = 15
        Me.b.Tag = "status=1"
        Me.b.Text = "Online"
        Me.b.UseVisualStyleBackColor = False
        '
        'btn_offline
        '
        Me.btn_offline.BackColor = System.Drawing.Color.Gray
        Me.btn_offline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_offline.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_offline.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_offline.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_offline.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_offline.Location = New System.Drawing.Point(101, 30)
        Me.btn_offline.Name = "btn_offline"
        Me.btn_offline.Size = New System.Drawing.Size(92, 23)
        Me.btn_offline.TabIndex = 16
        Me.btn_offline.Tag = "status=0"
        Me.btn_offline.Text = "Offline"
        Me.btn_offline.UseVisualStyleBackColor = False
        '
        'btn_bt_on
        '
        Me.btn_bt_on.BackColor = System.Drawing.Color.Gray
        Me.btn_bt_on.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_bt_on.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_bt_on.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_bt_on.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bt_on.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_bt_on.Location = New System.Drawing.Point(3, 84)
        Me.btn_bt_on.Name = "btn_bt_on"
        Me.btn_bt_on.Size = New System.Drawing.Size(92, 23)
        Me.btn_bt_on.TabIndex = 19
        Me.btn_bt_on.Tag = "btwork=1"
        Me.btn_bt_on.Text = "BT On"
        Me.btn_bt_on.UseVisualStyleBackColor = False
        '
        'btn_lock
        '
        Me.btn_lock.BackColor = System.Drawing.Color.Gray
        Me.btn_lock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_lock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_lock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_lock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_lock.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_lock.Location = New System.Drawing.Point(3, 57)
        Me.btn_lock.Name = "btn_lock"
        Me.btn_lock.Size = New System.Drawing.Size(92, 23)
        Me.btn_lock.TabIndex = 17
        Me.btn_lock.Tag = "locked=1"
        Me.btn_lock.Text = "Lock"
        Me.btn_lock.UseVisualStyleBackColor = False
        '
        'btn_unlock
        '
        Me.btn_unlock.BackColor = System.Drawing.Color.Gray
        Me.btn_unlock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_unlock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn_unlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_unlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_unlock.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_unlock.Location = New System.Drawing.Point(101, 57)
        Me.btn_unlock.Name = "btn_unlock"
        Me.btn_unlock.Size = New System.Drawing.Size(92, 23)
        Me.btn_unlock.TabIndex = 18
        Me.btn_unlock.Tag = "locked=0"
        Me.btn_unlock.Text = "Unlock"
        Me.btn_unlock.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Black
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 397)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(196, 31)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Selected Item Action"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.cbo_locktime)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.cbo_pos)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.cbo_dep)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txt_uname)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txt_name)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel3.Size = New System.Drawing.Size(196, 366)
        Me.Panel3.TabIndex = 20
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btn_clear)
        Me.Panel6.Controls.Add(Me.btn_save)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(5, 337)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(186, 22)
        Me.Panel6.TabIndex = 23
        '
        'btn_clear
        '
        Me.btn_clear.BackColor = System.Drawing.Color.Gray
        Me.btn_clear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_clear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clear.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_clear.ForeColor = System.Drawing.Color.White
        Me.btn_clear.Location = New System.Drawing.Point(96, 0)
        Me.btn_clear.Name = "btn_clear"
        Me.btn_clear.Size = New System.Drawing.Size(90, 22)
        Me.btn_clear.TabIndex = 12
        Me.btn_clear.Text = "Clear"
        Me.btn_clear.UseVisualStyleBackColor = False
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.Gray
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.Location = New System.Drawing.Point(0, 0)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(90, 22)
        Me.btn_save.TabIndex = 11
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btn_edit_restrict)
        Me.Panel5.Controls.Add(Me.chk_forbt)
        Me.Panel5.Controls.Add(Me.chk_online)
        Me.Panel5.Controls.Add(Me.chk_locked)
        Me.Panel5.Controls.Add(Me.chk_deactivate)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(5, 257)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(186, 80)
        Me.Panel5.TabIndex = 22
        '
        'btn_edit_restrict
        '
        Me.btn_edit_restrict.BackColor = System.Drawing.Color.Gray
        Me.btn_edit_restrict.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_edit_restrict.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_edit_restrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_edit_restrict.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_edit_restrict.Location = New System.Drawing.Point(3, 47)
        Me.btn_edit_restrict.Name = "btn_edit_restrict"
        Me.btn_edit_restrict.Size = New System.Drawing.Size(180, 23)
        Me.btn_edit_restrict.TabIndex = 11
        Me.btn_edit_restrict.Text = "Edit Restrictions"
        Me.btn_edit_restrict.UseVisualStyleBackColor = False
        '
        'chk_forbt
        '
        Me.chk_forbt.AutoSize = True
        Me.chk_forbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_forbt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_forbt.Location = New System.Drawing.Point(96, 7)
        Me.chk_forbt.Name = "chk_forbt"
        Me.chk_forbt.Size = New System.Drawing.Size(53, 20)
        Me.chk_forbt.TabIndex = 9
        Me.chk_forbt.Text = "For BT"
        Me.chk_forbt.UseVisualStyleBackColor = True
        '
        'chk_online
        '
        Me.chk_online.AutoSize = True
        Me.chk_online.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_online.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_online.Location = New System.Drawing.Point(3, 7)
        Me.chk_online.Name = "chk_online"
        Me.chk_online.Size = New System.Drawing.Size(59, 20)
        Me.chk_online.TabIndex = 7
        Me.chk_online.Text = "Online"
        Me.chk_online.UseVisualStyleBackColor = True
        '
        'chk_locked
        '
        Me.chk_locked.AutoSize = True
        Me.chk_locked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_locked.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_locked.Location = New System.Drawing.Point(3, 24)
        Me.chk_locked.Name = "chk_locked"
        Me.chk_locked.Size = New System.Drawing.Size(63, 20)
        Me.chk_locked.TabIndex = 8
        Me.chk_locked.Text = "Locked"
        Me.chk_locked.UseVisualStyleBackColor = True
        '
        'chk_deactivate
        '
        Me.chk_deactivate.AutoSize = True
        Me.chk_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_deactivate.Location = New System.Drawing.Point(96, 24)
        Me.chk_deactivate.Name = "chk_deactivate"
        Me.chk_deactivate.Size = New System.Drawing.Size(87, 20)
        Me.chk_deactivate.TabIndex = 10
        Me.chk_deactivate.Text = "Deactivate"
        Me.chk_deactivate.UseVisualStyleBackColor = True
        '
        'cbo_locktime
        '
        Me.cbo_locktime.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_locktime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_locktime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_locktime.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_locktime.FormattingEnabled = True
        Me.cbo_locktime.Location = New System.Drawing.Point(5, 236)
        Me.cbo_locktime.Name = "cbo_locktime"
        Me.cbo_locktime.Size = New System.Drawing.Size(186, 21)
        Me.cbo_locktime.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(5, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(186, 22)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Lock Time:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbo_pos
        '
        Me.cbo_pos.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_pos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_pos.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_pos.FormattingEnabled = True
        Me.cbo_pos.Location = New System.Drawing.Point(5, 193)
        Me.cbo_pos.Name = "cbo_pos"
        Me.cbo_pos.Size = New System.Drawing.Size(186, 21)
        Me.cbo_pos.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(186, 22)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Position:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cbo_dep
        '
        Me.cbo_dep.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_dep.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_dep.FormattingEnabled = True
        Me.cbo_dep.Location = New System.Drawing.Point(5, 150)
        Me.cbo_dep.Name = "cbo_dep"
        Me.cbo_dep.Size = New System.Drawing.Size(186, 21)
        Me.cbo_dep.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(186, 22)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Department:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_showhide_pass)
        Me.Panel4.Controls.Add(Me.txt_pass)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(5, 106)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(186, 22)
        Me.Panel4.TabIndex = 21
        '
        'btn_showhide_pass
        '
        Me.btn_showhide_pass.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.btn_showhide_pass.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_showhide_pass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btn_showhide_pass.FlatAppearance.BorderSize = 0
        Me.btn_showhide_pass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_showhide_pass.ForeColor = System.Drawing.Color.Black
        Me.btn_showhide_pass.ImageIndex = 0
        Me.btn_showhide_pass.Location = New System.Drawing.Point(156, 1)
        Me.btn_showhide_pass.Name = "btn_showhide_pass"
        Me.btn_showhide_pass.Size = New System.Drawing.Size(30, 19)
        Me.btn_showhide_pass.TabIndex = 6
        Me.btn_showhide_pass.UseVisualStyleBackColor = False
        '
        'txt_pass
        '
        Me.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pass.Dock = System.Windows.Forms.DockStyle.Left
        Me.txt_pass.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pass.Location = New System.Drawing.Point(0, 0)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.Size = New System.Drawing.Size(157, 19)
        Me.txt_pass.TabIndex = 3
        Me.txt_pass.UseSystemPasswordChar = True
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(186, 22)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Password:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_uname
        '
        Me.txt_uname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_uname.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_uname.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_uname.Location = New System.Drawing.Point(5, 65)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.Size = New System.Drawing.Size(186, 19)
        Me.txt_uname.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(186, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Username:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txt_name
        '
        Me.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_name.Dock = System.Windows.Forms.DockStyle.Top
        Me.txt_name.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_name.Location = New System.Drawing.Point(5, 24)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(186, 19)
        Me.txt_name.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(186, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Black
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(196, 31)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Add/ Edit User"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gray
        Me.Panel8.Controls.Add(Me.GroupBox1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(196, 32)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel8.Size = New System.Drawing.Size(543, 101)
        Me.Panel8.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.chk_f_deactivate)
        Me.GroupBox1.Controls.Add(Me.chk_f_online)
        Me.GroupBox1.Controls.Add(Me.txt_f_name)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chk_f_forbt)
        Me.GroupBox1.Controls.Add(Me.txt_f_uname)
        Me.GroupBox1.Controls.Add(Me.chk_f_locked)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(533, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter:"
        '
        'chk_f_deactivate
        '
        Me.chk_f_deactivate.AutoSize = True
        Me.chk_f_deactivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_f_deactivate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_deactivate.ForeColor = System.Drawing.Color.White
        Me.chk_f_deactivate.Location = New System.Drawing.Point(205, 67)
        Me.chk_f_deactivate.Name = "chk_f_deactivate"
        Me.chk_f_deactivate.Size = New System.Drawing.Size(95, 20)
        Me.chk_f_deactivate.TabIndex = 28
        Me.chk_f_deactivate.Text = "Deactivated"
        Me.chk_f_deactivate.UseVisualStyleBackColor = True
        '
        'chk_f_online
        '
        Me.chk_f_online.AutoSize = True
        Me.chk_f_online.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_f_online.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_online.ForeColor = System.Drawing.Color.White
        Me.chk_f_online.Location = New System.Drawing.Point(71, 67)
        Me.chk_f_online.Name = "chk_f_online"
        Me.chk_f_online.Size = New System.Drawing.Size(59, 20)
        Me.chk_f_online.TabIndex = 26
        Me.chk_f_online.Text = "Online"
        Me.chk_f_online.UseVisualStyleBackColor = True
        '
        'txt_f_name
        '
        Me.txt_f_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_f_name.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_f_name.Location = New System.Drawing.Point(9, 35)
        Me.txt_f_name.Name = "txt_f_name"
        Me.txt_f_name.Size = New System.Drawing.Size(101, 21)
        Me.txt_f_name.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(345, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Position:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(233, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Department:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(121, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Username:"
        '
        'chk_f_forbt
        '
        Me.chk_f_forbt.AutoSize = True
        Me.chk_f_forbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_f_forbt.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_forbt.ForeColor = System.Drawing.Color.White
        Me.chk_f_forbt.Location = New System.Drawing.Point(12, 67)
        Me.chk_f_forbt.Name = "chk_f_forbt"
        Me.chk_f_forbt.Size = New System.Drawing.Size(53, 20)
        Me.chk_f_forbt.TabIndex = 25
        Me.chk_f_forbt.Text = "For BT"
        Me.chk_f_forbt.UseVisualStyleBackColor = True
        '
        'txt_f_uname
        '
        Me.txt_f_uname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_f_uname.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_f_uname.Location = New System.Drawing.Point(121, 35)
        Me.txt_f_uname.Name = "txt_f_uname"
        Me.txt_f_uname.Size = New System.Drawing.Size(101, 21)
        Me.txt_f_uname.TabIndex = 22
        '
        'chk_f_locked
        '
        Me.chk_f_locked.AutoSize = True
        Me.chk_f_locked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chk_f_locked.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_f_locked.ForeColor = System.Drawing.Color.White
        Me.chk_f_locked.Location = New System.Drawing.Point(136, 67)
        Me.chk_f_locked.Name = "chk_f_locked"
        Me.chk_f_locked.Size = New System.Drawing.Size(63, 20)
        Me.chk_f_locked.TabIndex = 27
        Me.chk_f_locked.Text = "Locked"
        Me.chk_f_locked.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(236, 35)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(90, 24)
        Me.ComboBox1.TabIndex = 29
        '
        'ComboBox2
        '
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(348, 35)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(90, 24)
        Me.ComboBox2.TabIndex = 29
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'frm_userlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(739, 598)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_userlist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_userlist"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.tlp_contain_multi.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_exit As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents btn_open_restrict_editor As Button
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
    Friend WithEvents Panel3 As Panel
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
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_showhide_pass As Button
    Friend WithEvents txt_pass As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_uname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_name As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents chk_f_deactivate As CheckBox
    Friend WithEvents chk_f_online As CheckBox
    Friend WithEvents txt_f_name As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chk_f_forbt As CheckBox
    Friend WithEvents txt_f_uname As TextBox
    Friend WithEvents chk_f_locked As CheckBox
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
End Class
