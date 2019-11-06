<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_export))
        Me.cbo_client = New System.Windows.Forms.ComboBox()
        Me.pnl_cl_dep_container = New System.Windows.Forms.Panel()
        Me.cbo_dep = New System.Windows.Forms.ComboBox()
        Me.lbl_dep = New System.Windows.Forms.Label()
        Me.lbl_cltype = New System.Windows.Forms.Label()
        Me.dtpicker = New System.Windows.Forms.MonthCalendar()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_progressbar = New System.Windows.Forms.ToolStripProgressBar()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnl_action_btn_container = New System.Windows.Forms.Panel()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.lbl_status = New System.Windows.Forms.Label()
        Me.pnl_cl_dep_container.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.pnl_action_btn_container.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbo_client
        '
        Me.cbo_client.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_client.FormattingEnabled = True
        Me.cbo_client.Location = New System.Drawing.Point(0, 23)
        Me.cbo_client.Name = "cbo_client"
        Me.cbo_client.Size = New System.Drawing.Size(202, 21)
        Me.cbo_client.TabIndex = 1
        '
        'pnl_cl_dep_container
        '
        Me.pnl_cl_dep_container.Controls.Add(Me.cbo_dep)
        Me.pnl_cl_dep_container.Controls.Add(Me.lbl_dep)
        Me.pnl_cl_dep_container.Controls.Add(Me.cbo_client)
        Me.pnl_cl_dep_container.Controls.Add(Me.lbl_cltype)
        Me.pnl_cl_dep_container.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_cl_dep_container.Location = New System.Drawing.Point(0, 163)
        Me.pnl_cl_dep_container.Name = "pnl_cl_dep_container"
        Me.pnl_cl_dep_container.Size = New System.Drawing.Size(202, 91)
        Me.pnl_cl_dep_container.TabIndex = 6
        Me.pnl_cl_dep_container.Visible = False
        '
        'cbo_dep
        '
        Me.cbo_dep.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_dep.FormattingEnabled = True
        Me.cbo_dep.Location = New System.Drawing.Point(0, 65)
        Me.cbo_dep.Name = "cbo_dep"
        Me.cbo_dep.Size = New System.Drawing.Size(202, 21)
        Me.cbo_dep.TabIndex = 2
        '
        'lbl_dep
        '
        Me.lbl_dep.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_dep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_dep.Location = New System.Drawing.Point(0, 44)
        Me.lbl_dep.Name = "lbl_dep"
        Me.lbl_dep.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lbl_dep.Size = New System.Drawing.Size(202, 21)
        Me.lbl_dep.TabIndex = 1
        Me.lbl_dep.Text = "Department:"
        Me.lbl_dep.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbl_cltype
        '
        Me.lbl_cltype.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_cltype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cltype.Location = New System.Drawing.Point(0, 0)
        Me.lbl_cltype.Name = "lbl_cltype"
        Me.lbl_cltype.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lbl_cltype.Size = New System.Drawing.Size(202, 23)
        Me.lbl_cltype.TabIndex = 0
        Me.lbl_cltype.Text = "Client Type:"
        Me.lbl_cltype.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'dtpicker
        '
        Me.dtpicker.Dock = System.Windows.Forms.DockStyle.Top
        Me.dtpicker.Location = New System.Drawing.Point(0, 0)
        Me.dtpicker.MaxSelectionCount = 500
        Me.dtpicker.Name = "dtpicker"
        Me.dtpicker.TabIndex = 5
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_progressbar, Me.tss_status})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 316)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(202, 22)
        Me.statusStrip1.TabIndex = 7
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tss_progressbar
        '
        Me.tss_progressbar.Name = "tss_progressbar"
        Me.tss_progressbar.Size = New System.Drawing.Size(100, 16)
        Me.tss_progressbar.Visible = False
        '
        'tss_status
        '
        Me.tss_status.Name = "tss_status"
        Me.tss_status.Size = New System.Drawing.Size(26, 17)
        Me.tss_status.Text = "stat"
        '
        'pnl_action_btn_container
        '
        Me.pnl_action_btn_container.Controls.Add(Me.btn_export)
        Me.pnl_action_btn_container.Controls.Add(Me.panel2)
        Me.pnl_action_btn_container.Controls.Add(Me.btn_close)
        Me.pnl_action_btn_container.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl_action_btn_container.Location = New System.Drawing.Point(0, 338)
        Me.pnl_action_btn_container.Name = "pnl_action_btn_container"
        Me.pnl_action_btn_container.Size = New System.Drawing.Size(202, 25)
        Me.pnl_action_btn_container.TabIndex = 8
        '
        'btn_export
        '
        Me.btn_export.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_export.Enabled = False
        Me.btn_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.Location = New System.Drawing.Point(82, 0)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(55, 25)
        Me.btn_export.TabIndex = 0
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'panel2
        '
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel2.Location = New System.Drawing.Point(137, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(10, 25)
        Me.panel2.TabIndex = 2
        '
        'btn_close
        '
        Me.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_close.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Location = New System.Drawing.Point(147, 0)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(55, 25)
        Me.btn_close.TabIndex = 1
        Me.btn_close.Text = "Close"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'lbl_status
        '
        Me.lbl_status.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_status.Location = New System.Drawing.Point(0, 0)
        Me.lbl_status.Name = "lbl_status"
        Me.lbl_status.Size = New System.Drawing.Size(202, 363)
        Me.lbl_status.TabIndex = 9
        Me.lbl_status.Text = "No Data to Export"
        Me.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frm_export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(202, 363)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnl_cl_dep_container)
        Me.Controls.Add(Me.dtpicker)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.pnl_action_btn_container)
        Me.Controls.Add(Me.lbl_status)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_export"
        Me.Text = "Export to Excel"
        Me.pnl_cl_dep_container.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.pnl_action_btn_container.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents cbo_client As ComboBox
    Private WithEvents pnl_cl_dep_container As Panel
    Private WithEvents cbo_dep As ComboBox
    Private WithEvents lbl_dep As Label
    Private WithEvents lbl_cltype As Label
    Private WithEvents dtpicker As MonthCalendar
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_progressbar As ToolStripProgressBar
    Private WithEvents tss_status As ToolStripStatusLabel
    Private WithEvents pnl_action_btn_container As Panel
    Private WithEvents btn_export As Button
    Private WithEvents panel2 As Panel
    Private WithEvents btn_close As Button
    Private WithEvents lbl_status As Label
End Class
