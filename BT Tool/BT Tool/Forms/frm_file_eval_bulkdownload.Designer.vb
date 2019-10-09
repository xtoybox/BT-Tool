<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_file_eval_bulkdownload
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_file_eval_bulkdownload))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gb_listview_container = New System.Windows.Forms.GroupBox()
        Me.listview = New System.Windows.Forms.ListView()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.cbo_viewtype = New System.Windows.Forms.ComboBox()
        Me.pnl_action_btn_container = New System.Windows.Forms.Panel()
        Me.btn_download = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gb_directory_container = New System.Windows.Forms.GroupBox()
        Me.txt_directory = New System.Windows.Forms.TextBox()
        Me.btn_browse_folder = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.gb_listview_container.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.pnl_action_btn_container.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.gb_directory_container.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 26)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Download Compares"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Maroon
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.BT_Tool.My.Resources.Resources.close1
        Me.Button1.Location = New System.Drawing.Point(445, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 26)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = False
        '
        'gb_listview_container
        '
        Me.gb_listview_container.Controls.Add(Me.listview)
        Me.gb_listview_container.Controls.Add(Me.panel2)
        Me.gb_listview_container.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_listview_container.ForeColor = System.Drawing.Color.White
        Me.gb_listview_container.Location = New System.Drawing.Point(12, 87)
        Me.gb_listview_container.Name = "gb_listview_container"
        Me.gb_listview_container.Padding = New System.Windows.Forms.Padding(10)
        Me.gb_listview_container.Size = New System.Drawing.Size(450, 318)
        Me.gb_listview_container.TabIndex = 5
        Me.gb_listview_container.TabStop = False
        Me.gb_listview_container.Text = "Select the file/s you want to download"
        '
        'listview
        '
        Me.listview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listview.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listview.HideSelection = False
        Me.listview.Location = New System.Drawing.Point(10, 46)
        Me.listview.Name = "listview"
        Me.listview.Size = New System.Drawing.Size(430, 262)
        Me.listview.TabIndex = 0
        Me.listview.UseCompatibleStateImageBehavior = False
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.cbo_viewtype)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(10, 24)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(430, 22)
        Me.panel2.TabIndex = 2
        '
        'cbo_viewtype
        '
        Me.cbo_viewtype.Dock = System.Windows.Forms.DockStyle.Right
        Me.cbo_viewtype.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_viewtype.FormattingEnabled = True
        Me.cbo_viewtype.Location = New System.Drawing.Point(309, 0)
        Me.cbo_viewtype.Name = "cbo_viewtype"
        Me.cbo_viewtype.Size = New System.Drawing.Size(121, 24)
        Me.cbo_viewtype.TabIndex = 1
        '
        'pnl_action_btn_container
        '
        Me.pnl_action_btn_container.Controls.Add(Me.btn_download)
        Me.pnl_action_btn_container.Controls.Add(Me.Panel3)
        Me.pnl_action_btn_container.Controls.Add(Me.btn_close)
        Me.pnl_action_btn_container.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_action_btn_container.Location = New System.Drawing.Point(0, 407)
        Me.pnl_action_btn_container.Name = "pnl_action_btn_container"
        Me.pnl_action_btn_container.Size = New System.Drawing.Size(472, 36)
        Me.pnl_action_btn_container.TabIndex = 7
        '
        'btn_download
        '
        Me.btn_download.BackColor = System.Drawing.Color.DimGray
        Me.btn_download.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_download.Enabled = False
        Me.btn_download.FlatAppearance.BorderSize = 0
        Me.btn_download.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_download.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_download.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_download.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_download.ForeColor = System.Drawing.Color.White
        Me.btn_download.Location = New System.Drawing.Point(307, 3)
        Me.btn_download.Name = "btn_download"
        Me.btn_download.Size = New System.Drawing.Size(73, 26)
        Me.btn_download.TabIndex = 1
        Me.btn_download.Text = "Download"
        Me.btn_download.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(462, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 36)
        Me.Panel3.TabIndex = 2
        '
        'btn_close
        '
        Me.btn_close.BackColor = System.Drawing.Color.DimGray
        Me.btn_close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_close.FlatAppearance.BorderSize = 0
        Me.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.ForeColor = System.Drawing.Color.White
        Me.btn_close.Location = New System.Drawing.Point(390, 3)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(62, 26)
        Me.btn_close.TabIndex = 0
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = False
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.Gray
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_status})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 443)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(472, 22)
        Me.statusStrip1.TabIndex = 6
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tss_status
        '
        Me.tss_status.BackColor = System.Drawing.Color.DimGray
        Me.tss_status.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.tss_status.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tss_status.ForeColor = System.Drawing.Color.White
        Me.tss_status.Name = "tss_status"
        Me.tss_status.Size = New System.Drawing.Size(120, 17)
        Me.tss_status.Text = "toolStripStatusLabel1"
        '
        'gb_directory_container
        '
        Me.gb_directory_container.Controls.Add(Me.txt_directory)
        Me.gb_directory_container.Controls.Add(Me.btn_browse_folder)
        Me.gb_directory_container.Font = New System.Drawing.Font("Century Gothic", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_directory_container.ForeColor = System.Drawing.Color.White
        Me.gb_directory_container.Location = New System.Drawing.Point(12, 34)
        Me.gb_directory_container.Name = "gb_directory_container"
        Me.gb_directory_container.Padding = New System.Windows.Forms.Padding(10)
        Me.gb_directory_container.Size = New System.Drawing.Size(450, 53)
        Me.gb_directory_container.TabIndex = 4
        Me.gb_directory_container.TabStop = False
        Me.gb_directory_container.Text = "Download Directory:"
        '
        'txt_directory
        '
        Me.txt_directory.BackColor = System.Drawing.Color.White
        Me.txt_directory.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_directory.Location = New System.Drawing.Point(10, 24)
        Me.txt_directory.Name = "txt_directory"
        Me.txt_directory.ReadOnly = True
        Me.txt_directory.Size = New System.Drawing.Size(392, 21)
        Me.txt_directory.TabIndex = 0
        '
        'btn_browse_folder
        '
        Me.btn_browse_folder.BackColor = System.Drawing.Color.DimGray
        Me.btn_browse_folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_browse_folder.FlatAppearance.BorderSize = 0
        Me.btn_browse_folder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_browse_folder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_browse_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_browse_folder.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_browse_folder.Location = New System.Drawing.Point(402, 24)
        Me.btn_browse_folder.Name = "btn_browse_folder"
        Me.btn_browse_folder.Size = New System.Drawing.Size(38, 21)
        Me.btn_browse_folder.TabIndex = 1
        Me.btn_browse_folder.Text = "..."
        Me.btn_browse_folder.UseVisualStyleBackColor = False
        '
        'frm_file_eval_bulkdownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(472, 465)
        Me.Controls.Add(Me.gb_listview_container)
        Me.Controls.Add(Me.pnl_action_btn_container)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.gb_directory_container)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_file_eval_bulkdownload"
        Me.Text = "BT-Tool Bulk Download"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gb_listview_container.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.pnl_action_btn_container.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.gb_directory_container.ResumeLayout(False)
        Me.gb_directory_container.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents gb_listview_container As GroupBox
    Private WithEvents listview As ListView
    Private WithEvents panel2 As Panel
    Private WithEvents cbo_viewtype As ComboBox
    Private WithEvents pnl_action_btn_container As Panel
    Private WithEvents btn_download As Button
    Private WithEvents Panel3 As Panel
    Private WithEvents btn_close As Button
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_status As ToolStripStatusLabel
    Private WithEvents gb_directory_container As GroupBox
    Private WithEvents txt_directory As TextBox
    Private WithEvents btn_browse_folder As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
