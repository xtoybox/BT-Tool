<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_workflow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_workflow))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgv_wf = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.pnl_wf = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btn_reset = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.cbo_step5 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbo_step4 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbo_step3 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbo_step2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbo_step1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgv_wf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnl_wf.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(354, 27)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.BT_Tool.My.Resources.Resources.close1
        Me.Button1.Location = New System.Drawing.Point(325, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Workflow"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgv_wf)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(354, 342)
        Me.Panel2.TabIndex = 1
        '
        'dgv_wf
        '
        Me.dgv_wf.AllowUserToAddRows = False
        Me.dgv_wf.AllowUserToDeleteRows = False
        Me.dgv_wf.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgv_wf.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_wf.BackgroundColor = System.Drawing.Color.White
        Me.dgv_wf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv_wf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_wf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv_wf.Location = New System.Drawing.Point(154, 0)
        Me.dgv_wf.Name = "dgv_wf"
        Me.dgv_wf.ReadOnly = True
        Me.dgv_wf.RowHeadersVisible = False
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.dgv_wf.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_wf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_wf.Size = New System.Drawing.Size(198, 340)
        Me.dgv_wf.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btn_delete)
        Me.Panel3.Controls.Add(Me.pnl_wf)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(154, 340)
        Me.Panel3.TabIndex = 4
        '
        'btn_delete
        '
        Me.btn_delete.BackColor = System.Drawing.Color.DimGray
        Me.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_delete.FlatAppearance.BorderSize = 0
        Me.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_delete.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_delete.ForeColor = System.Drawing.Color.White
        Me.btn_delete.Location = New System.Drawing.Point(5, 304)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(144, 31)
        Me.btn_delete.TabIndex = 8
        Me.btn_delete.Text = "Delete Selected"
        Me.btn_delete.UseVisualStyleBackColor = False
        '
        'pnl_wf
        '
        Me.pnl_wf.Controls.Add(Me.Panel4)
        Me.pnl_wf.Controls.Add(Me.cbo_step5)
        Me.pnl_wf.Controls.Add(Me.Label6)
        Me.pnl_wf.Controls.Add(Me.cbo_step4)
        Me.pnl_wf.Controls.Add(Me.Label5)
        Me.pnl_wf.Controls.Add(Me.cbo_step3)
        Me.pnl_wf.Controls.Add(Me.Label4)
        Me.pnl_wf.Controls.Add(Me.cbo_step2)
        Me.pnl_wf.Controls.Add(Me.Label3)
        Me.pnl_wf.Controls.Add(Me.cbo_step1)
        Me.pnl_wf.Controls.Add(Me.Label2)
        Me.pnl_wf.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_wf.Location = New System.Drawing.Point(0, 31)
        Me.pnl_wf.Name = "pnl_wf"
        Me.pnl_wf.Padding = New System.Windows.Forms.Padding(5)
        Me.pnl_wf.Size = New System.Drawing.Size(154, 267)
        Me.pnl_wf.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btn_reset)
        Me.Panel4.Controls.Add(Me.btn_save)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(5, 232)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.Panel4.Size = New System.Drawing.Size(144, 41)
        Me.Panel4.TabIndex = 9
        '
        'btn_reset
        '
        Me.btn_reset.BackColor = System.Drawing.Color.DimGray
        Me.btn_reset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_reset.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_reset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_reset.FlatAppearance.BorderSize = 0
        Me.btn_reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_reset.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_reset.ForeColor = System.Drawing.Color.White
        Me.btn_reset.Location = New System.Drawing.Point(74, 10)
        Me.btn_reset.Name = "btn_reset"
        Me.btn_reset.Size = New System.Drawing.Size(70, 31)
        Me.btn_reset.TabIndex = 7
        Me.btn_reset.Text = "Reset"
        Me.btn_reset.UseVisualStyleBackColor = False
        '
        'btn_save
        '
        Me.btn_save.BackColor = System.Drawing.Color.DimGray
        Me.btn_save.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_save.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.btn_save.FlatAppearance.BorderSize = 0
        Me.btn_save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.btn_save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray
        Me.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_save.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_save.ForeColor = System.Drawing.Color.White
        Me.btn_save.Location = New System.Drawing.Point(0, 10)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(70, 31)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = False
        '
        'cbo_step5
        '
        Me.cbo_step5.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_step5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_step5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_step5.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_step5.FormattingEnabled = True
        Me.cbo_step5.Location = New System.Drawing.Point(5, 208)
        Me.cbo_step5.Name = "cbo_step5"
        Me.cbo_step5.Size = New System.Drawing.Size(144, 24)
        Me.cbo_step5.TabIndex = 5
        Me.cbo_step5.Tag = "4"
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 22)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "STEP 5"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbo_step4
        '
        Me.cbo_step4.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_step4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_step4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_step4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_step4.FormattingEnabled = True
        Me.cbo_step4.Location = New System.Drawing.Point(5, 162)
        Me.cbo_step4.Name = "cbo_step4"
        Me.cbo_step4.Size = New System.Drawing.Size(144, 24)
        Me.cbo_step4.TabIndex = 4
        Me.cbo_step4.Tag = "3"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 22)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "STEP 4"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbo_step3
        '
        Me.cbo_step3.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_step3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_step3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_step3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_step3.FormattingEnabled = True
        Me.cbo_step3.Location = New System.Drawing.Point(5, 116)
        Me.cbo_step3.Name = "cbo_step3"
        Me.cbo_step3.Size = New System.Drawing.Size(144, 24)
        Me.cbo_step3.TabIndex = 3
        Me.cbo_step3.Tag = "2"
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(5, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 22)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "STEP 3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbo_step2
        '
        Me.cbo_step2.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_step2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_step2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_step2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_step2.FormattingEnabled = True
        Me.cbo_step2.Location = New System.Drawing.Point(5, 70)
        Me.cbo_step2.Name = "cbo_step2"
        Me.cbo_step2.Size = New System.Drawing.Size(144, 24)
        Me.cbo_step2.TabIndex = 2
        Me.cbo_step2.Tag = "1"
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "STEP 2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cbo_step1
        '
        Me.cbo_step1.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbo_step1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_step1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbo_step1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_step1.FormattingEnabled = True
        Me.cbo_step1.Location = New System.Drawing.Point(5, 24)
        Me.cbo_step1.Name = "cbo_step1"
        Me.cbo_step1.Size = New System.Drawing.Size(144, 24)
        Me.cbo_step1.TabIndex = 1
        Me.cbo_step1.Tag = "0"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "STEP 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Add/ Edit Work Flow"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_workflow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 369)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_workflow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BT-Tool Workflow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgv_wf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.pnl_wf.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgv_wf As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn_delete As Button
    Friend WithEvents pnl_wf As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btn_reset As Button
    Friend WithEvents btn_save As Button
    Friend WithEvents cbo_step5 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbo_step4 As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbo_step3 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbo_step2 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbo_step1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
