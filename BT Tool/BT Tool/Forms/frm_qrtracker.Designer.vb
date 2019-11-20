<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_qrtracker
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
        Me.dgv_tracker = New System.Windows.Forms.DataGridView()
        Me.gb_filter_export_container = New System.Windows.Forms.GroupBox()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.dtpicker = New System.Windows.Forms.DateTimePicker()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgv_tracker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_filter_export_container.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_tracker
        '
        Me.dgv_tracker.AllowUserToAddRows = False
        Me.dgv_tracker.AllowUserToDeleteRows = False
        Me.dgv_tracker.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_tracker.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_tracker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_tracker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_tracker.Location = New System.Drawing.Point(0, 51)
        Me.dgv_tracker.Name = "dgv_tracker"
        Me.dgv_tracker.ReadOnly = True
        Me.dgv_tracker.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_tracker.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_tracker.Size = New System.Drawing.Size(800, 377)
        Me.dgv_tracker.TabIndex = 4
        '
        'gb_filter_export_container
        '
        Me.gb_filter_export_container.Controls.Add(Me.btn_export)
        Me.gb_filter_export_container.Controls.Add(Me.dtpicker)
        Me.gb_filter_export_container.Dock = System.Windows.Forms.DockStyle.Top
        Me.gb_filter_export_container.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_filter_export_container.Location = New System.Drawing.Point(0, 0)
        Me.gb_filter_export_container.Name = "gb_filter_export_container"
        Me.gb_filter_export_container.Size = New System.Drawing.Size(800, 51)
        Me.gb_filter_export_container.TabIndex = 3
        Me.gb_filter_export_container.TabStop = False
        Me.gb_filter_export_container.Text = "Filter and Export"
        '
        'btn_export
        '
        Me.btn_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_export.Location = New System.Drawing.Point(111, 19)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(61, 20)
        Me.btn_export.TabIndex = 1
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = True
        Me.btn_export.Visible = False
        '
        'dtpicker
        '
        Me.dtpicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker.Location = New System.Drawing.Point(12, 19)
        Me.dtpicker.Name = "dtpicker"
        Me.dtpicker.Size = New System.Drawing.Size(93, 20)
        Me.dtpicker.TabIndex = 0
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
        'frm_qrtracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dgv_tracker)
        Me.Controls.Add(Me.gb_filter_export_container)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "frm_qrtracker"
        Me.Text = "Form1"
        CType(Me.dgv_tracker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_filter_export_container.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents dgv_tracker As DataGridView
    Private WithEvents gb_filter_export_container As GroupBox
    Private WithEvents btn_export As Button
    Private WithEvents dtpicker As DateTimePicker
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_status As ToolStripStatusLabel
End Class
