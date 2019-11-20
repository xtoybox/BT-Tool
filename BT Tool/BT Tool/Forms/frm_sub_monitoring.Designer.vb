<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_sub_monitoring
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
        Me.dgv_done = New System.Windows.Forms.DataGridView()
        Me.dgv_ready = New System.Windows.Forms.DataGridView()
        Me.dgv_foraudit = New System.Windows.Forms.DataGridView()
        Me.dgv_forts = New System.Windows.Forms.DataGridView()
        Me.tab_btshced = New System.Windows.Forms.TabPage()
        Me.dgv_btsched = New System.Windows.Forms.DataGridView()
        Me.tab_prsched = New System.Windows.Forms.TabPage()
        Me.dgv_prsched = New System.Windows.Forms.DataGridView()
        Me.dgv_forst = New System.Windows.Forms.DataGridView()
        Me.tab_ccsched = New System.Windows.Forms.TabPage()
        Me.dgv_ccsched = New System.Windows.Forms.DataGridView()
        Me.dgv_forcc = New System.Windows.Forms.DataGridView()
        Me.tab_stsched = New System.Windows.Forms.TabPage()
        Me.dgv_stsched = New System.Windows.Forms.DataGridView()
        Me.dgv_forpr = New System.Windows.Forms.DataGridView()
        Me.tab_forbt = New System.Windows.Forms.TabPage()
        Me.dgv_forbt = New System.Windows.Forms.DataGridView()
        Me.tab_forpr = New System.Windows.Forms.TabPage()
        Me.tab_done = New System.Windows.Forms.TabPage()
        Me.tab_forcc = New System.Windows.Forms.TabPage()
        Me.tab_forst = New System.Windows.Forms.TabPage()
        Me.tab_forts = New System.Windows.Forms.TabPage()
        Me.tabctrl = New System.Windows.Forms.TabControl()
        Me.tab_audits = New System.Windows.Forms.TabPage()
        Me.tab_ready = New System.Windows.Forms.TabPage()
        Me.tss_status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        CType(Me.dgv_done, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_ready, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_foraudit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_forts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_btshced.SuspendLayout()
        CType(Me.dgv_btsched, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_prsched.SuspendLayout()
        CType(Me.dgv_prsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_forst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_ccsched.SuspendLayout()
        CType(Me.dgv_ccsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_forcc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_stsched.SuspendLayout()
        CType(Me.dgv_stsched, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_forpr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_forbt.SuspendLayout()
        CType(Me.dgv_forbt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_forpr.SuspendLayout()
        Me.tab_done.SuspendLayout()
        Me.tab_forcc.SuspendLayout()
        Me.tab_forst.SuspendLayout()
        Me.tab_forts.SuspendLayout()
        Me.tabctrl.SuspendLayout()
        Me.tab_audits.SuspendLayout()
        Me.tab_ready.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv_done
        '
        Me.dgv_done.AllowUserToAddRows = False
        Me.dgv_done.AllowUserToDeleteRows = False
        Me.dgv_done.AllowUserToResizeRows = False
        Me.dgv_done.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_done.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_done.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_done.Location = New System.Drawing.Point(0, 0)
        Me.dgv_done.Name = "dgv_done"
        Me.dgv_done.ReadOnly = True
        Me.dgv_done.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_done.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_done.Size = New System.Drawing.Size(670, 298)
        Me.dgv_done.TabIndex = 1
        '
        'dgv_ready
        '
        Me.dgv_ready.AllowUserToAddRows = False
        Me.dgv_ready.AllowUserToDeleteRows = False
        Me.dgv_ready.AllowUserToResizeRows = False
        Me.dgv_ready.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_ready.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ready.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ready.Location = New System.Drawing.Point(0, 0)
        Me.dgv_ready.Name = "dgv_ready"
        Me.dgv_ready.ReadOnly = True
        Me.dgv_ready.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_ready.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ready.Size = New System.Drawing.Size(670, 298)
        Me.dgv_ready.TabIndex = 1
        '
        'dgv_foraudit
        '
        Me.dgv_foraudit.AllowUserToAddRows = False
        Me.dgv_foraudit.AllowUserToDeleteRows = False
        Me.dgv_foraudit.AllowUserToResizeRows = False
        Me.dgv_foraudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_foraudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_foraudit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_foraudit.Location = New System.Drawing.Point(0, 0)
        Me.dgv_foraudit.Name = "dgv_foraudit"
        Me.dgv_foraudit.ReadOnly = True
        Me.dgv_foraudit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_foraudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_foraudit.Size = New System.Drawing.Size(670, 298)
        Me.dgv_foraudit.TabIndex = 1
        '
        'dgv_forts
        '
        Me.dgv_forts.AllowUserToAddRows = False
        Me.dgv_forts.AllowUserToDeleteRows = False
        Me.dgv_forts.AllowUserToResizeRows = False
        Me.dgv_forts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_forts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_forts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_forts.Location = New System.Drawing.Point(0, 0)
        Me.dgv_forts.Name = "dgv_forts"
        Me.dgv_forts.ReadOnly = True
        Me.dgv_forts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_forts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_forts.Size = New System.Drawing.Size(670, 298)
        Me.dgv_forts.TabIndex = 1
        '
        'tab_btshced
        '
        Me.tab_btshced.Controls.Add(Me.dgv_btsched)
        Me.tab_btshced.Location = New System.Drawing.Point(4, 22)
        Me.tab_btshced.Name = "tab_btshced"
        Me.tab_btshced.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_btshced.Size = New System.Drawing.Size(792, 402)
        Me.tab_btshced.TabIndex = 0
        Me.tab_btshced.Text = "BT Sched"
        Me.tab_btshced.UseVisualStyleBackColor = True
        '
        'dgv_btsched
        '
        Me.dgv_btsched.AllowUserToAddRows = False
        Me.dgv_btsched.AllowUserToDeleteRows = False
        Me.dgv_btsched.AllowUserToResizeRows = False
        Me.dgv_btsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_btsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_btsched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_btsched.Location = New System.Drawing.Point(3, 3)
        Me.dgv_btsched.Name = "dgv_btsched"
        Me.dgv_btsched.ReadOnly = True
        Me.dgv_btsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_btsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_btsched.Size = New System.Drawing.Size(786, 396)
        Me.dgv_btsched.TabIndex = 0
        '
        'tab_prsched
        '
        Me.tab_prsched.Controls.Add(Me.dgv_prsched)
        Me.tab_prsched.Location = New System.Drawing.Point(4, 22)
        Me.tab_prsched.Name = "tab_prsched"
        Me.tab_prsched.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_prsched.Size = New System.Drawing.Size(670, 298)
        Me.tab_prsched.TabIndex = 1
        Me.tab_prsched.Text = "PR Sched"
        Me.tab_prsched.UseVisualStyleBackColor = True
        '
        'dgv_prsched
        '
        Me.dgv_prsched.AllowUserToAddRows = False
        Me.dgv_prsched.AllowUserToDeleteRows = False
        Me.dgv_prsched.AllowUserToResizeRows = False
        Me.dgv_prsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_prsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_prsched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_prsched.Location = New System.Drawing.Point(3, 3)
        Me.dgv_prsched.Name = "dgv_prsched"
        Me.dgv_prsched.ReadOnly = True
        Me.dgv_prsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_prsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_prsched.Size = New System.Drawing.Size(664, 292)
        Me.dgv_prsched.TabIndex = 1
        '
        'dgv_forst
        '
        Me.dgv_forst.AllowUserToAddRows = False
        Me.dgv_forst.AllowUserToDeleteRows = False
        Me.dgv_forst.AllowUserToResizeRows = False
        Me.dgv_forst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_forst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_forst.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_forst.Location = New System.Drawing.Point(0, 0)
        Me.dgv_forst.Name = "dgv_forst"
        Me.dgv_forst.ReadOnly = True
        Me.dgv_forst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_forst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_forst.Size = New System.Drawing.Size(670, 298)
        Me.dgv_forst.TabIndex = 1
        '
        'tab_ccsched
        '
        Me.tab_ccsched.Controls.Add(Me.dgv_ccsched)
        Me.tab_ccsched.Location = New System.Drawing.Point(4, 22)
        Me.tab_ccsched.Name = "tab_ccsched"
        Me.tab_ccsched.Size = New System.Drawing.Size(670, 298)
        Me.tab_ccsched.TabIndex = 2
        Me.tab_ccsched.Text = "CC Sched"
        Me.tab_ccsched.UseVisualStyleBackColor = True
        '
        'dgv_ccsched
        '
        Me.dgv_ccsched.AllowUserToAddRows = False
        Me.dgv_ccsched.AllowUserToDeleteRows = False
        Me.dgv_ccsched.AllowUserToResizeRows = False
        Me.dgv_ccsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_ccsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_ccsched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_ccsched.Location = New System.Drawing.Point(0, 0)
        Me.dgv_ccsched.Name = "dgv_ccsched"
        Me.dgv_ccsched.ReadOnly = True
        Me.dgv_ccsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_ccsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ccsched.Size = New System.Drawing.Size(670, 298)
        Me.dgv_ccsched.TabIndex = 1
        '
        'dgv_forcc
        '
        Me.dgv_forcc.AllowUserToAddRows = False
        Me.dgv_forcc.AllowUserToDeleteRows = False
        Me.dgv_forcc.AllowUserToResizeRows = False
        Me.dgv_forcc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_forcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_forcc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_forcc.Location = New System.Drawing.Point(0, 0)
        Me.dgv_forcc.Name = "dgv_forcc"
        Me.dgv_forcc.ReadOnly = True
        Me.dgv_forcc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_forcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_forcc.Size = New System.Drawing.Size(670, 298)
        Me.dgv_forcc.TabIndex = 1
        '
        'tab_stsched
        '
        Me.tab_stsched.Controls.Add(Me.dgv_stsched)
        Me.tab_stsched.Location = New System.Drawing.Point(4, 22)
        Me.tab_stsched.Name = "tab_stsched"
        Me.tab_stsched.Size = New System.Drawing.Size(670, 298)
        Me.tab_stsched.TabIndex = 3
        Me.tab_stsched.Text = "S&T Sched"
        Me.tab_stsched.UseVisualStyleBackColor = True
        '
        'dgv_stsched
        '
        Me.dgv_stsched.AllowUserToAddRows = False
        Me.dgv_stsched.AllowUserToDeleteRows = False
        Me.dgv_stsched.AllowUserToResizeRows = False
        Me.dgv_stsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_stsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_stsched.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_stsched.Location = New System.Drawing.Point(0, 0)
        Me.dgv_stsched.Name = "dgv_stsched"
        Me.dgv_stsched.ReadOnly = True
        Me.dgv_stsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_stsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_stsched.Size = New System.Drawing.Size(670, 298)
        Me.dgv_stsched.TabIndex = 1
        '
        'dgv_forpr
        '
        Me.dgv_forpr.AllowUserToAddRows = False
        Me.dgv_forpr.AllowUserToDeleteRows = False
        Me.dgv_forpr.AllowUserToResizeRows = False
        Me.dgv_forpr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_forpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_forpr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_forpr.Location = New System.Drawing.Point(0, 0)
        Me.dgv_forpr.Name = "dgv_forpr"
        Me.dgv_forpr.ReadOnly = True
        Me.dgv_forpr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_forpr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_forpr.Size = New System.Drawing.Size(670, 298)
        Me.dgv_forpr.TabIndex = 1
        '
        'tab_forbt
        '
        Me.tab_forbt.Controls.Add(Me.dgv_forbt)
        Me.tab_forbt.Location = New System.Drawing.Point(4, 22)
        Me.tab_forbt.Name = "tab_forbt"
        Me.tab_forbt.Size = New System.Drawing.Size(670, 298)
        Me.tab_forbt.TabIndex = 4
        Me.tab_forbt.Text = "For BT"
        Me.tab_forbt.UseVisualStyleBackColor = True
        '
        'dgv_forbt
        '
        Me.dgv_forbt.AllowUserToAddRows = False
        Me.dgv_forbt.AllowUserToDeleteRows = False
        Me.dgv_forbt.AllowUserToResizeRows = False
        Me.dgv_forbt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_forbt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_forbt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_forbt.Location = New System.Drawing.Point(0, 0)
        Me.dgv_forbt.Name = "dgv_forbt"
        Me.dgv_forbt.ReadOnly = True
        Me.dgv_forbt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgv_forbt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_forbt.Size = New System.Drawing.Size(670, 298)
        Me.dgv_forbt.TabIndex = 1
        '
        'tab_forpr
        '
        Me.tab_forpr.Controls.Add(Me.dgv_forpr)
        Me.tab_forpr.Location = New System.Drawing.Point(4, 22)
        Me.tab_forpr.Name = "tab_forpr"
        Me.tab_forpr.Size = New System.Drawing.Size(670, 298)
        Me.tab_forpr.TabIndex = 5
        Me.tab_forpr.Text = "For PR"
        Me.tab_forpr.UseVisualStyleBackColor = True
        '
        'tab_done
        '
        Me.tab_done.Controls.Add(Me.dgv_done)
        Me.tab_done.Location = New System.Drawing.Point(4, 22)
        Me.tab_done.Name = "tab_done"
        Me.tab_done.Size = New System.Drawing.Size(670, 298)
        Me.tab_done.TabIndex = 11
        Me.tab_done.Text = "Done"
        Me.tab_done.UseVisualStyleBackColor = True
        '
        'tab_forcc
        '
        Me.tab_forcc.Controls.Add(Me.dgv_forcc)
        Me.tab_forcc.Location = New System.Drawing.Point(4, 22)
        Me.tab_forcc.Name = "tab_forcc"
        Me.tab_forcc.Size = New System.Drawing.Size(670, 298)
        Me.tab_forcc.TabIndex = 6
        Me.tab_forcc.Text = "For CC"
        Me.tab_forcc.UseVisualStyleBackColor = True
        '
        'tab_forst
        '
        Me.tab_forst.Controls.Add(Me.dgv_forst)
        Me.tab_forst.Location = New System.Drawing.Point(4, 22)
        Me.tab_forst.Name = "tab_forst"
        Me.tab_forst.Size = New System.Drawing.Size(670, 298)
        Me.tab_forst.TabIndex = 7
        Me.tab_forst.Text = "For S&T"
        Me.tab_forst.UseVisualStyleBackColor = True
        '
        'tab_forts
        '
        Me.tab_forts.Controls.Add(Me.dgv_forts)
        Me.tab_forts.Location = New System.Drawing.Point(4, 22)
        Me.tab_forts.Name = "tab_forts"
        Me.tab_forts.Size = New System.Drawing.Size(670, 298)
        Me.tab_forts.TabIndex = 8
        Me.tab_forts.Text = "For TS"
        Me.tab_forts.UseVisualStyleBackColor = True
        '
        'tabctrl
        '
        Me.tabctrl.Controls.Add(Me.tab_btshced)
        Me.tabctrl.Controls.Add(Me.tab_prsched)
        Me.tabctrl.Controls.Add(Me.tab_ccsched)
        Me.tabctrl.Controls.Add(Me.tab_stsched)
        Me.tabctrl.Controls.Add(Me.tab_forbt)
        Me.tabctrl.Controls.Add(Me.tab_forpr)
        Me.tabctrl.Controls.Add(Me.tab_forcc)
        Me.tabctrl.Controls.Add(Me.tab_forst)
        Me.tabctrl.Controls.Add(Me.tab_forts)
        Me.tabctrl.Controls.Add(Me.tab_audits)
        Me.tabctrl.Controls.Add(Me.tab_ready)
        Me.tabctrl.Controls.Add(Me.tab_done)
        Me.tabctrl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabctrl.Location = New System.Drawing.Point(0, 0)
        Me.tabctrl.Name = "tabctrl"
        Me.tabctrl.SelectedIndex = 0
        Me.tabctrl.Size = New System.Drawing.Size(800, 428)
        Me.tabctrl.TabIndex = 3
        '
        'tab_audits
        '
        Me.tab_audits.Controls.Add(Me.dgv_foraudit)
        Me.tab_audits.Location = New System.Drawing.Point(4, 22)
        Me.tab_audits.Name = "tab_audits"
        Me.tab_audits.Size = New System.Drawing.Size(670, 298)
        Me.tab_audits.TabIndex = 9
        Me.tab_audits.Text = "For Audit"
        Me.tab_audits.UseVisualStyleBackColor = True
        '
        'tab_ready
        '
        Me.tab_ready.Controls.Add(Me.dgv_ready)
        Me.tab_ready.Location = New System.Drawing.Point(4, 22)
        Me.tab_ready.Name = "tab_ready"
        Me.tab_ready.Size = New System.Drawing.Size(670, 298)
        Me.tab_ready.TabIndex = 10
        Me.tab_ready.Text = "Ready"
        Me.tab_ready.UseVisualStyleBackColor = True
        '
        'tss_status
        '
        Me.tss_status.Name = "tss_status"
        Me.tss_status.Size = New System.Drawing.Size(109, 17)
        Me.tss_status.Text = "toolStripStatusLabel1"
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tss_status})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.statusStrip1.TabIndex = 2
        Me.statusStrip1.Text = "statusStrip1"
        '
        'frm_sub_monitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tabctrl)
        Me.Controls.Add(Me.statusStrip1)
        Me.Name = "frm_sub_monitoring"
        Me.Text = "frm_sub_monitoring"
        CType(Me.dgv_done, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_ready, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_foraudit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_forts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_btshced.ResumeLayout(False)
        CType(Me.dgv_btsched, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_prsched.ResumeLayout(False)
        CType(Me.dgv_prsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_forst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_ccsched.ResumeLayout(False)
        CType(Me.dgv_ccsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_forcc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_stsched.ResumeLayout(False)
        CType(Me.dgv_stsched, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_forpr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_forbt.ResumeLayout(False)
        CType(Me.dgv_forbt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_forpr.ResumeLayout(False)
        Me.tab_done.ResumeLayout(False)
        Me.tab_forcc.ResumeLayout(False)
        Me.tab_forst.ResumeLayout(False)
        Me.tab_forts.ResumeLayout(False)
        Me.tabctrl.ResumeLayout(False)
        Me.tab_audits.ResumeLayout(False)
        Me.tab_ready.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents dgv_done As DataGridView
    Private WithEvents dgv_ready As DataGridView
    Private WithEvents dgv_foraudit As DataGridView
    Private WithEvents dgv_forts As DataGridView
    Private WithEvents tab_btshced As TabPage
    Private WithEvents dgv_btsched As DataGridView
    Private WithEvents tab_prsched As TabPage
    Private WithEvents dgv_prsched As DataGridView
    Private WithEvents dgv_forst As DataGridView
    Private WithEvents tab_ccsched As TabPage
    Private WithEvents dgv_ccsched As DataGridView
    Private WithEvents dgv_forcc As DataGridView
    Private WithEvents tab_stsched As TabPage
    Private WithEvents dgv_stsched As DataGridView
    Private WithEvents dgv_forpr As DataGridView
    Private WithEvents tab_forbt As TabPage
    Private WithEvents dgv_forbt As DataGridView
    Private WithEvents tab_forpr As TabPage
    Private WithEvents tab_done As TabPage
    Private WithEvents tab_forcc As TabPage
    Private WithEvents tab_forst As TabPage
    Private WithEvents tab_forts As TabPage
    Private WithEvents tabctrl As TabControl
    Private WithEvents tab_audits As TabPage
    Private WithEvents tab_ready As TabPage
    Private WithEvents tss_status As ToolStripStatusLabel
    Private WithEvents statusStrip1 As StatusStrip
End Class
