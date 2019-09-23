<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
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
    Friend WithEvents Label4 As Label
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Copyright As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BunifuProgressBar1 As Bunifu.Framework.UI.BunifuProgressBar

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BunifuProgressBar1 = New Bunifu.Framework.UI.BunifuProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Old English Text MT", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 77)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Accolade"
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.Controls.Add(Me.Label7)
        Me.BunifuGradientPanel1.Controls.Add(Me.BunifuProgressBar1)
        Me.BunifuGradientPanel1.Controls.Add(Me.Label6)
        Me.BunifuGradientPanel1.Controls.Add(Me.Copyright)
        Me.BunifuGradientPanel1.Controls.Add(Me.Label2)
        Me.BunifuGradientPanel1.Controls.Add(Me.Label5)
        Me.BunifuGradientPanel1.Controls.Add(Me.Label3)
        Me.BunifuGradientPanel1.Controls.Add(Me.Label1)
        Me.BunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(356, 297)
        Me.BunifuGradientPanel1.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(151, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Loading ..."
        '
        'BunifuProgressBar1
        '
        Me.BunifuProgressBar1.BackColor = System.Drawing.Color.Silver
        Me.BunifuProgressBar1.BorderRadius = 5
        Me.BunifuProgressBar1.Location = New System.Drawing.Point(25, 216)
        Me.BunifuProgressBar1.MaximumValue = 100
        Me.BunifuProgressBar1.Name = "BunifuProgressBar1"
        Me.BunifuProgressBar1.ProgressColor = System.Drawing.Color.Gray
        Me.BunifuProgressBar1.Size = New System.Drawing.Size(308, 13)
        Me.BunifuProgressBar1.TabIndex = 29
        Me.BunifuProgressBar1.Value = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Old English Text MT", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(31, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(251, 77)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Accolade"
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.BackColor = System.Drawing.Color.Transparent
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.Color.DarkGray
        Me.Copyright.Location = New System.Drawing.Point(3, 275)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Padding = New System.Windows.Forms.Padding(2)
        Me.Copyright.Size = New System.Drawing.Size(217, 17)
        Me.Copyright.TabIndex = 27
        Me.Copyright.Text = "Copyright © Accolade Resources Inc. 2018"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGray
        Me.Label2.Location = New System.Drawing.Point(3, 259)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Version 1.0.0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Old English Text MT", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(180, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 28)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Resources Inc."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(198, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 55)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "TOOL"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(121, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 55)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "BT"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(356, 297)
        Me.Controls.Add(Me.BunifuGradientPanel1)
        Me.Controls.Add(Me.Label4)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.BunifuGradientPanel1.ResumeLayout(False)
        Me.BunifuGradientPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BunifuProgressBar1.Value = 50

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click
        Login_form.Show()
        Me.Close()
    End Sub
End Class
