<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sub_report_log
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
        Me.dgv_breaklog = New System.Windows.Forms.DataGridView()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_total_dur = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tss_sel_dur = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgv_breaklog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_breaklog
        '
        Me.dgv_breaklog.AllowUserToAddRows = False
        Me.dgv_breaklog.AllowUserToDeleteRows = False
        Me.dgv_breaklog.AllowUserToResizeRows = False
        Me.dgv_breaklog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_breaklog.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_breaklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_breaklog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_breaklog.Location = New System.Drawing.Point(0, 0)
        Me.dgv_breaklog.Name = "dgv_breaklog"
        Me.dgv_breaklog.ReadOnly = True
        Me.dgv_breaklog.RowHeadersVisible = False
        Me.dgv_breaklog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_breaklog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_breaklog.Size = New System.Drawing.Size(696, 280)
        Me.dgv_breaklog.TabIndex = 3
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_total_dur, Me.tss_sel_dur})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 280)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(696, 22)
        Me.statusStrip1.TabIndex = 2
        Me.statusStrip1.Text = "statusStrip1"
        '
        'tss_total_dur
        '
        Me.tss_total_dur.Name = "tss_total_dur"
        Me.tss_total_dur.Size = New System.Drawing.Size(79, 17)
        Me.tss_total_dur.Text = "Total Duration:"
        '
        'tss_sel_dur
        '
        Me.tss_sel_dur.Name = "tss_sel_dur"
        Me.tss_sel_dur.Size = New System.Drawing.Size(123, 17)
        Me.tss_sel_dur.Text = "Selected Total Duration:"
        '
        'frm_sub_report_log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 302)
        Me.Controls.Add(Me.dgv_breaklog)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "frm_sub_report_log"
        Me.Text = "frm_sub_report_log"
        CType(Me.dgv_breaklog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents dgv_breaklog As DataGridView
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_total_dur As ToolStripStatusLabel
    Private WithEvents tss_sel_dur As ToolStripStatusLabel
End Class
