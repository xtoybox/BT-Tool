<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_report_log
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tab_main = New System.Windows.Forms.TabControl()
        Me.tab_break = New System.Windows.Forms.TabPage()
        Me.dgv_break = New System.Windows.Forms.DataGridView()
        Me.tab_notif = New System.Windows.Forms.TabPage()
        Me.dgv_notif = New System.Windows.Forms.DataGridView()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menuStrip1.SuspendLayout()
        Me.tab_main.SuspendLayout()
        Me.tab_break.SuspendLayout()
        CType(Me.dgv_break, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_notif.SuspendLayout()
        CType(Me.dgv_notif, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.refreshToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.menuStrip1.TabIndex = 3
        Me.menuStrip1.Text = "menuStrip1"
        '
        'refreshToolStripMenuItem
        '
        Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
        Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.refreshToolStripMenuItem.Text = "Refresh"
        '
        'tab_main
        '
        Me.tab_main.Controls.Add(Me.tab_break)
        Me.tab_main.Controls.Add(Me.tab_notif)
        Me.tab_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tab_main.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tab_main.Location = New System.Drawing.Point(0, 24)
        Me.tab_main.Name = "tab_main"
        Me.tab_main.SelectedIndex = 0
        Me.tab_main.Size = New System.Drawing.Size(800, 404)
        Me.tab_main.TabIndex = 4
        '
        'tab_break
        '
        Me.tab_break.Controls.Add(Me.dgv_break)
        Me.tab_break.Location = New System.Drawing.Point(4, 22)
        Me.tab_break.Name = "tab_break"
        Me.tab_break.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_break.Size = New System.Drawing.Size(792, 378)
        Me.tab_break.TabIndex = 0
        Me.tab_break.Text = "Break Log"
        Me.tab_break.UseVisualStyleBackColor = True
        '
        'dgv_break
        '
        Me.dgv_break.AllowUserToAddRows = False
        Me.dgv_break.AllowUserToDeleteRows = False
        Me.dgv_break.AllowUserToResizeRows = False
        Me.dgv_break.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_break.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_break.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_break.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_break.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_break.Location = New System.Drawing.Point(3, 3)
        Me.dgv_break.Name = "dgv_break"
        Me.dgv_break.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_break.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_break.RowHeadersVisible = False
        Me.dgv_break.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv_break.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_break.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_break.Size = New System.Drawing.Size(786, 372)
        Me.dgv_break.TabIndex = 0
        '
        'tab_notif
        '
        Me.tab_notif.Controls.Add(Me.dgv_notif)
        Me.tab_notif.Location = New System.Drawing.Point(4, 22)
        Me.tab_notif.Name = "tab_notif"
        Me.tab_notif.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_notif.Size = New System.Drawing.Size(430, 288)
        Me.tab_notif.TabIndex = 1
        Me.tab_notif.Text = "Idle Notification Log"
        Me.tab_notif.UseVisualStyleBackColor = True
        '
        'dgv_notif
        '
        Me.dgv_notif.AllowUserToAddRows = False
        Me.dgv_notif.AllowUserToDeleteRows = False
        Me.dgv_notif.AllowUserToResizeRows = False
        Me.dgv_notif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_notif.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv_notif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_notif.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgv_notif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_notif.Location = New System.Drawing.Point(3, 3)
        Me.dgv_notif.Name = "dgv_notif"
        Me.dgv_notif.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_notif.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgv_notif.RowHeadersVisible = False
        Me.dgv_notif.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_notif.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_notif.Size = New System.Drawing.Size(424, 282)
        Me.dgv_notif.TabIndex = 1
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_status})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.statusStrip1.TabIndex = 5
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tss_status
        '
        Me.tss_status.Name = "tss_status"
        Me.tss_status.Size = New System.Drawing.Size(109, 17)
        Me.tss_status.Text = "toolStripStatusLabel1"
        '
        'frm_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tab_main)
        Me.Controls.Add(Me.menuStrip1)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "frm_report"
        Me.Text = "frm_report"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.tab_main.ResumeLayout(False)
        Me.tab_break.ResumeLayout(False)
        CType(Me.dgv_break, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_notif.ResumeLayout(False)
        CType(Me.dgv_notif, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents refreshToolStripMenuItem As ToolStripMenuItem
    Private WithEvents tab_main As TabControl
    Private WithEvents tab_break As TabPage
    Private WithEvents dgv_break As DataGridView
    Private WithEvents tab_notif As TabPage
    Private WithEvents dgv_notif As DataGridView
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_status As ToolStripStatusLabel
End Class
