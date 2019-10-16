<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_duefile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_duefile))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gb_filter_export_container = New System.Windows.Forms.GroupBox()
        Me.dtpicker = New System.Windows.Forms.DateTimePicker()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgv_duefile = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.gb_filter_export_container.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        CType(Me.dgv_duefile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Name = "Panel1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Red
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'gb_filter_export_container
        '
        Me.gb_filter_export_container.BackColor = System.Drawing.SystemColors.Control
        Me.gb_filter_export_container.Controls.Add(Me.dtpicker)
        resources.ApplyResources(Me.gb_filter_export_container, "gb_filter_export_container")
        Me.gb_filter_export_container.Name = "gb_filter_export_container"
        Me.gb_filter_export_container.TabStop = False
        '
        'dtpicker
        '
        resources.ApplyResources(Me.dtpicker, "dtpicker")
        Me.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpicker.Name = "dtpicker"
        '
        'statusStrip1
        '
        Me.statusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_status})
        resources.ApplyResources(Me.statusStrip1, "statusStrip1")
        Me.statusStrip1.Name = "statusStrip1"
        '
        'tss_status
        '
        resources.ApplyResources(Me.tss_status, "tss_status")
        Me.tss_status.ForeColor = System.Drawing.Color.White
        Me.tss_status.Name = "tss_status"
        '
        'dgv_duefile
        '
        Me.dgv_duefile.AllowUserToAddRows = False
        Me.dgv_duefile.AllowUserToDeleteRows = False
        Me.dgv_duefile.AllowUserToResizeRows = False
        Me.dgv_duefile.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_duefile.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_duefile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgv_duefile, "dgv_duefile")
        Me.dgv_duefile.Name = "dgv_duefile"
        Me.dgv_duefile.ReadOnly = True
        Me.dgv_duefile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_duefile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'frm_duefile
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.dgv_duefile)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.gb_filter_export_container)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_duefile"
        Me.ShowInTaskbar = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gb_filter_export_container.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        CType(Me.dgv_duefile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Private WithEvents gb_filter_export_container As GroupBox
    Private WithEvents dtpicker As DateTimePicker
    Private WithEvents statusStrip1 As StatusStrip
    Private WithEvents tss_status As ToolStripStatusLabel
    Private WithEvents dgv_duefile As DataGridView
End Class
