<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_upload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_upload))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_upload = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtp_due = New System.Windows.Forms.DateTimePicker()
        Me.cbo_workflow = New System.Windows.Forms.ComboBox()
        Me.dtp_time = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_client = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_filename = New System.Windows.Forms.TextBox()
        Me.grid_upload = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_upload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btn_exit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 38)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Upload"
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.DarkRed
        Me.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_exit.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.ForeColor = System.Drawing.Color.Transparent
        Me.btn_exit.Image = Global.BT_Tool.My.Resources.Resources.close1
        Me.btn_exit.Location = New System.Drawing.Point(813, 0)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(39, 38)
        Me.btn_exit.TabIndex = 1
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 62)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(852, 68)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btn_upload)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtp_due)
        Me.GroupBox2.Controls.Add(Me.cbo_workflow)
        Me.GroupBox2.Controls.Add(Me.dtp_time)
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(294, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 61)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Work Flow:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(264, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Due Time:"
        '
        'btn_upload
        '
        Me.btn_upload.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_upload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_upload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_upload.FlatAppearance.BorderSize = 0
        Me.btn_upload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_upload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_upload.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_upload.ForeColor = System.Drawing.Color.White
        Me.btn_upload.Location = New System.Drawing.Point(458, 20)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(77, 28)
        Me.btn_upload.TabIndex = 0
        Me.btn_upload.Text = "Upload"
        Me.btn_upload.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(142, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Due Date:"
        '
        'dtp_due
        '
        Me.dtp_due.CustomFormat = "M/d/yyyy h:mm:ss tt"
        Me.dtp_due.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_due.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_due.Location = New System.Drawing.Point(145, 29)
        Me.dtp_due.Name = "dtp_due"
        Me.dtp_due.Size = New System.Drawing.Size(109, 23)
        Me.dtp_due.TabIndex = 3
        '
        'cbo_workflow
        '
        Me.cbo_workflow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_workflow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_workflow.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_workflow.FormatString = "mm/dd/yyyy"
        Me.cbo_workflow.FormattingEnabled = True
        Me.cbo_workflow.Location = New System.Drawing.Point(9, 29)
        Me.cbo_workflow.Name = "cbo_workflow"
        Me.cbo_workflow.Size = New System.Drawing.Size(121, 25)
        Me.cbo_workflow.TabIndex = 2
        '
        'dtp_time
        '
        Me.dtp_time.CustomFormat = "M/d/yyyy h:mm:ss tt"
        Me.dtp_time.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtp_time.Location = New System.Drawing.Point(267, 29)
        Me.dtp_time.Name = "dtp_time"
        Me.dtp_time.ShowUpDown = True
        Me.dtp_time.Size = New System.Drawing.Size(104, 23)
        Me.dtp_time.TabIndex = 4
        Me.dtp_time.Value = New Date(2019, 2, 23, 20, 0, 0, 0)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbo_client)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txt_filename)
        Me.GroupBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(287, 63)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(147, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Filename:"
        '
        'cbo_client
        '
        Me.cbo_client.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_client.FormattingEnabled = True
        Me.cbo_client.Location = New System.Drawing.Point(9, 31)
        Me.cbo_client.Name = "cbo_client"
        Me.cbo_client.Size = New System.Drawing.Size(121, 24)
        Me.cbo_client.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Client:"
        '
        'txt_filename
        '
        Me.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_filename.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_filename.Location = New System.Drawing.Point(147, 33)
        Me.txt_filename.Name = "txt_filename"
        Me.txt_filename.Size = New System.Drawing.Size(129, 23)
        Me.txt_filename.TabIndex = 6
        '
        'grid_upload
        '
        Me.grid_upload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid_upload.BackgroundColor = System.Drawing.Color.White
        Me.grid_upload.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_upload.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.grid_upload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_upload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_upload.Location = New System.Drawing.Point(0, 130)
        Me.grid_upload.Name = "grid_upload"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_upload.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grid_upload.RowHeadersVisible = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.grid_upload.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grid_upload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_upload.Size = New System.Drawing.Size(852, 399)
        Me.grid_upload.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lbl_status)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 508)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(852, 21)
        Me.Panel3.TabIndex = 3
        '
        'lbl_status
        '
        Me.lbl_status.AutoSize = True
        Me.lbl_status.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.ForeColor = System.Drawing.Color.White
        Me.lbl_status.Location = New System.Drawing.Point(3, 2)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(20, 17)
        Me.lbl_status.TabIndex = 10
        Me.lbl_status.Text = "---"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReloadToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 38)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(852, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.BackColor = System.Drawing.Color.Gray
        Me.ReloadToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReloadToolStripMenuItem.Text = "Reload"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.BackColor = System.Drawing.Color.Gray
        Me.SettingsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        Me.SettingsToolStripMenuItem.Visible = False
        '
        'frm_upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 529)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grid_upload)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_upload"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT-Tool Upload"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grid_upload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btn_exit As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btn_upload As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents dtp_due As DateTimePicker
    Friend WithEvents cbo_workflow As ComboBox
    Friend WithEvents dtp_time As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbo_client As ComboBox
    Friend WithEvents txt_filename As TextBox
    Friend WithEvents grid_upload As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbl_status As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
