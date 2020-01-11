<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_break
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_break))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_stop = New System.Windows.Forms.Button()
        Me.lbl_time = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(957, 610)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn_stop
        '
        Me.btn_stop.BackColor = System.Drawing.Color.Transparent
        Me.btn_stop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_stop.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btn_stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black
        Me.btn_stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black
        Me.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_stop.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_stop.ForeColor = System.Drawing.Color.White
        Me.btn_stop.Location = New System.Drawing.Point(0, 572)
        Me.btn_stop.Name = "btn_stop"
        Me.btn_stop.Size = New System.Drawing.Size(957, 38)
        Me.btn_stop.TabIndex = 13
        Me.btn_stop.Text = "Resume"
        Me.btn_stop.UseVisualStyleBackColor = False
        '
        'lbl_time
        '
        Me.lbl_time.BackColor = System.Drawing.Color.Transparent
        Me.lbl_time.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_time.Font = New System.Drawing.Font("Century Gothic", 150.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_time.ForeColor = System.Drawing.Color.White
        Me.lbl_time.Location = New System.Drawing.Point(0, 0)
        Me.lbl_time.Name = "lbl_time"
        Me.lbl_time.Size = New System.Drawing.Size(957, 610)
        Me.lbl_time.TabIndex = 12
        Me.lbl_time.Text = "00:00:00"
        Me.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(957, 119)
        Me.Panel1.TabIndex = 14
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = Global.BT_Tool.My.Resources.Resources.accoalde_logo_small
        Me.PictureBox2.Location = New System.Drawing.Point(617, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(340, 119)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'frm_break
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(957, 610)
        Me.Controls.Add(Me.btn_stop)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lbl_time)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_break"
        Me.Text = "BT-Tool Break"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_stop As Button
    Friend WithEvents lbl_time As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
End Class
