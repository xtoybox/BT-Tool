<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main_form
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
        Dim Animation6 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation5 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim Animation4 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_form))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.User_Btn = New System.Windows.Forms.Button()
        Me.Settings_btn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dashboard_pnl = New System.Windows.Forms.Panel()
        Me.Workflow_btn = New System.Windows.Forms.Button()
        Me.Userlist_btn = New System.Windows.Forms.Button()
        Me.Filesdue_btn = New System.Windows.Forms.Button()
        Me.Waittracker_btn = New System.Windows.Forms.Button()
        Me.Idletracker_btn = New System.Windows.Forms.Button()
        Me.Ratiotracker_btn = New System.Windows.Forms.Button()
        Me.Flagging_btn = New System.Windows.Forms.Button()
        Me.Viewreturn_btn = New System.Windows.Forms.Button()
        Me.Monitoring_btn = New System.Windows.Forms.Button()
        Me.Fileeval_btn = New System.Windows.Forms.Button()
        Me.Myfileeval_btn = New System.Windows.Forms.Button()
        Me.Burgermenu_btn = New System.Windows.Forms.Button()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.User_Pnl = New System.Windows.Forms.Panel()
        Me.Logout_btn = New System.Windows.Forms.Button()
        Me.Settings_Pnl = New System.Windows.Forms.Panel()
        Me.BunifuTransition1 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Submit_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Hold_btn = New System.Windows.Forms.Button()
        Me.Return_btn = New System.Windows.Forms.Button()
        Me.Break_btn = New System.Windows.Forms.Button()
        Me.Status_Pnl = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BunifuTransition2 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.BunifuTransition3 = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Dashboard_pnl.SuspendLayout()
        Me.User_Pnl.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Status_Pnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.User_Btn)
        Me.Panel1.Controls.Add(Me.Settings_btn)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.BunifuTransition1.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel1, BunifuAnimatorNS.DecorationType.None)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 52)
        Me.Panel1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label4, BunifuAnimatorNS.DecorationType.None)
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(125, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 21)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "BT TOOL"
        '
        'User_Btn
        '
        Me.User_Btn.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.User_Btn, BunifuAnimatorNS.DecorationType.None)
        Me.User_Btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.User_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.User_Btn.Image = CType(resources.GetObject("User_Btn.Image"), System.Drawing.Image)
        Me.User_Btn.Location = New System.Drawing.Point(1023, 0)
        Me.User_Btn.Name = "User_Btn"
        Me.User_Btn.Size = New System.Drawing.Size(55, 52)
        Me.User_Btn.TabIndex = 10
        Me.User_Btn.UseVisualStyleBackColor = False
        '
        'Settings_btn
        '
        Me.Settings_btn.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Settings_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Settings_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Settings_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Settings_btn.Dock = System.Windows.Forms.DockStyle.Right
        Me.Settings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Settings_btn.Image = CType(resources.GetObject("Settings_btn.Image"), System.Drawing.Image)
        Me.Settings_btn.Location = New System.Drawing.Point(1078, 0)
        Me.Settings_btn.Name = "Settings_btn"
        Me.Settings_btn.Size = New System.Drawing.Size(55, 52)
        Me.Settings_btn.TabIndex = 9
        Me.Settings_btn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuTransition3.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button1, BunifuAnimatorNS.DecorationType.None)
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1133, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 52)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label2, BunifuAnimatorNS.DecorationType.None)
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(949, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 33)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label1, BunifuAnimatorNS.DecorationType.None)
        Me.Label1.Font = New System.Drawing.Font("Old English Text MT", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 38)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Accolade"
        '
        'Dashboard_pnl
        '
        Me.Dashboard_pnl.BackColor = System.Drawing.Color.Black
        Me.Dashboard_pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dashboard_pnl.Controls.Add(Me.Button2)
        Me.Dashboard_pnl.Controls.Add(Me.Workflow_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Userlist_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Filesdue_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Waittracker_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Idletracker_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Ratiotracker_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Flagging_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Viewreturn_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Monitoring_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Fileeval_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Myfileeval_btn)
        Me.Dashboard_pnl.Controls.Add(Me.Burgermenu_btn)
        Me.BunifuTransition1.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Dashboard_pnl, BunifuAnimatorNS.DecorationType.None)
        Me.Dashboard_pnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.Dashboard_pnl.Location = New System.Drawing.Point(0, 52)
        Me.Dashboard_pnl.Name = "Dashboard_pnl"
        Me.Dashboard_pnl.Size = New System.Drawing.Size(50, 664)
        Me.Dashboard_pnl.TabIndex = 1
        '
        'Workflow_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Workflow_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Workflow_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Workflow_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Workflow_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Workflow_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Workflow_btn.ForeColor = System.Drawing.Color.White
        Me.Workflow_btn.Image = CType(resources.GetObject("Workflow_btn.Image"), System.Drawing.Image)
        Me.Workflow_btn.Location = New System.Drawing.Point(0, 517)
        Me.Workflow_btn.Name = "Workflow_btn"
        Me.Workflow_btn.Size = New System.Drawing.Size(48, 47)
        Me.Workflow_btn.TabIndex = 11
        Me.Workflow_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Workflow_btn.UseVisualStyleBackColor = True
        '
        'Userlist_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Userlist_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Userlist_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Userlist_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Userlist_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Userlist_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Userlist_btn.ForeColor = System.Drawing.Color.White
        Me.Userlist_btn.Image = CType(resources.GetObject("Userlist_btn.Image"), System.Drawing.Image)
        Me.Userlist_btn.Location = New System.Drawing.Point(0, 470)
        Me.Userlist_btn.Name = "Userlist_btn"
        Me.Userlist_btn.Size = New System.Drawing.Size(48, 47)
        Me.Userlist_btn.TabIndex = 10
        Me.Userlist_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Userlist_btn.UseVisualStyleBackColor = True
        '
        'Filesdue_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Filesdue_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Filesdue_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Filesdue_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Filesdue_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Filesdue_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Filesdue_btn.ForeColor = System.Drawing.Color.White
        Me.Filesdue_btn.Image = CType(resources.GetObject("Filesdue_btn.Image"), System.Drawing.Image)
        Me.Filesdue_btn.Location = New System.Drawing.Point(0, 423)
        Me.Filesdue_btn.Name = "Filesdue_btn"
        Me.Filesdue_btn.Size = New System.Drawing.Size(48, 47)
        Me.Filesdue_btn.TabIndex = 9
        Me.Filesdue_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Filesdue_btn.UseVisualStyleBackColor = True
        '
        'Waittracker_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Waittracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Waittracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Waittracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Waittracker_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Waittracker_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Waittracker_btn.ForeColor = System.Drawing.Color.White
        Me.Waittracker_btn.Image = CType(resources.GetObject("Waittracker_btn.Image"), System.Drawing.Image)
        Me.Waittracker_btn.Location = New System.Drawing.Point(0, 376)
        Me.Waittracker_btn.Name = "Waittracker_btn"
        Me.Waittracker_btn.Size = New System.Drawing.Size(48, 47)
        Me.Waittracker_btn.TabIndex = 8
        Me.Waittracker_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Waittracker_btn.UseVisualStyleBackColor = True
        '
        'Idletracker_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Idletracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Idletracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Idletracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Idletracker_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Idletracker_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Idletracker_btn.ForeColor = System.Drawing.Color.White
        Me.Idletracker_btn.Image = CType(resources.GetObject("Idletracker_btn.Image"), System.Drawing.Image)
        Me.Idletracker_btn.Location = New System.Drawing.Point(0, 329)
        Me.Idletracker_btn.Name = "Idletracker_btn"
        Me.Idletracker_btn.Size = New System.Drawing.Size(48, 47)
        Me.Idletracker_btn.TabIndex = 7
        Me.Idletracker_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Idletracker_btn.UseVisualStyleBackColor = True
        '
        'Ratiotracker_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Ratiotracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Ratiotracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Ratiotracker_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Ratiotracker_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ratiotracker_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ratiotracker_btn.ForeColor = System.Drawing.Color.White
        Me.Ratiotracker_btn.Image = CType(resources.GetObject("Ratiotracker_btn.Image"), System.Drawing.Image)
        Me.Ratiotracker_btn.Location = New System.Drawing.Point(0, 282)
        Me.Ratiotracker_btn.Name = "Ratiotracker_btn"
        Me.Ratiotracker_btn.Size = New System.Drawing.Size(48, 47)
        Me.Ratiotracker_btn.TabIndex = 6
        Me.Ratiotracker_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Ratiotracker_btn.UseVisualStyleBackColor = True
        '
        'Flagging_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Flagging_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Flagging_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Flagging_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Flagging_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Flagging_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Flagging_btn.ForeColor = System.Drawing.Color.White
        Me.Flagging_btn.Image = CType(resources.GetObject("Flagging_btn.Image"), System.Drawing.Image)
        Me.Flagging_btn.Location = New System.Drawing.Point(0, 235)
        Me.Flagging_btn.Name = "Flagging_btn"
        Me.Flagging_btn.Size = New System.Drawing.Size(48, 47)
        Me.Flagging_btn.TabIndex = 5
        Me.Flagging_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Flagging_btn.UseVisualStyleBackColor = True
        '
        'Viewreturn_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Viewreturn_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Viewreturn_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Viewreturn_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Viewreturn_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Viewreturn_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Viewreturn_btn.ForeColor = System.Drawing.Color.White
        Me.Viewreturn_btn.Image = CType(resources.GetObject("Viewreturn_btn.Image"), System.Drawing.Image)
        Me.Viewreturn_btn.Location = New System.Drawing.Point(0, 188)
        Me.Viewreturn_btn.Name = "Viewreturn_btn"
        Me.Viewreturn_btn.Size = New System.Drawing.Size(48, 47)
        Me.Viewreturn_btn.TabIndex = 4
        Me.Viewreturn_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Viewreturn_btn.UseVisualStyleBackColor = True
        '
        'Monitoring_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Monitoring_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Monitoring_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Monitoring_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Monitoring_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Monitoring_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Monitoring_btn.ForeColor = System.Drawing.Color.White
        Me.Monitoring_btn.Image = CType(resources.GetObject("Monitoring_btn.Image"), System.Drawing.Image)
        Me.Monitoring_btn.Location = New System.Drawing.Point(0, 141)
        Me.Monitoring_btn.Name = "Monitoring_btn"
        Me.Monitoring_btn.Size = New System.Drawing.Size(48, 47)
        Me.Monitoring_btn.TabIndex = 3
        Me.Monitoring_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Monitoring_btn.UseVisualStyleBackColor = True
        '
        'Fileeval_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Fileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Fileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Fileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Fileeval_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Fileeval_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fileeval_btn.ForeColor = System.Drawing.Color.White
        Me.Fileeval_btn.Image = CType(resources.GetObject("Fileeval_btn.Image"), System.Drawing.Image)
        Me.Fileeval_btn.Location = New System.Drawing.Point(0, 94)
        Me.Fileeval_btn.Name = "Fileeval_btn"
        Me.Fileeval_btn.Size = New System.Drawing.Size(48, 47)
        Me.Fileeval_btn.TabIndex = 2
        Me.Fileeval_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Fileeval_btn.UseVisualStyleBackColor = True
        '
        'Myfileeval_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Myfileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Myfileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Myfileeval_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Myfileeval_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Myfileeval_btn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Myfileeval_btn.ForeColor = System.Drawing.Color.White
        Me.Myfileeval_btn.Image = CType(resources.GetObject("Myfileeval_btn.Image"), System.Drawing.Image)
        Me.Myfileeval_btn.Location = New System.Drawing.Point(0, 47)
        Me.Myfileeval_btn.Name = "Myfileeval_btn"
        Me.Myfileeval_btn.Size = New System.Drawing.Size(48, 47)
        Me.Myfileeval_btn.TabIndex = 1
        Me.Myfileeval_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Myfileeval_btn.UseVisualStyleBackColor = True
        '
        'Burgermenu_btn
        '
        Me.Burgermenu_btn.BackgroundImage = CType(resources.GetObject("Burgermenu_btn.BackgroundImage"), System.Drawing.Image)
        Me.Burgermenu_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuTransition3.SetDecoration(Me.Burgermenu_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Burgermenu_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Burgermenu_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Burgermenu_btn.Dock = System.Windows.Forms.DockStyle.Top
        Me.Burgermenu_btn.Location = New System.Drawing.Point(0, 0)
        Me.Burgermenu_btn.Name = "Burgermenu_btn"
        Me.Burgermenu_btn.Size = New System.Drawing.Size(48, 47)
        Me.Burgermenu_btn.TabIndex = 0
        Me.Burgermenu_btn.Text = "  "
        Me.Burgermenu_btn.UseVisualStyleBackColor = True
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Me.Panel1
        Me.BunifuDragControl1.Vertical = True
        '
        'User_Pnl
        '
        Me.User_Pnl.BackColor = System.Drawing.Color.Black
        Me.User_Pnl.Controls.Add(Me.Logout_btn)
        Me.BunifuTransition1.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.User_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.User_Pnl.Location = New System.Drawing.Point(915, 52)
        Me.User_Pnl.Name = "User_Pnl"
        Me.User_Pnl.Size = New System.Drawing.Size(160, 239)
        Me.User_Pnl.TabIndex = 2
        '
        'Logout_btn
        '
        Me.BunifuTransition3.SetDecoration(Me.Logout_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Logout_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Logout_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Logout_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Logout_btn.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Logout_btn.ForeColor = System.Drawing.Color.Red
        Me.Logout_btn.Image = CType(resources.GetObject("Logout_btn.Image"), System.Drawing.Image)
        Me.Logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Logout_btn.Location = New System.Drawing.Point(0, 191)
        Me.Logout_btn.Name = "Logout_btn"
        Me.Logout_btn.Size = New System.Drawing.Size(160, 48)
        Me.Logout_btn.TabIndex = 20
        Me.Logout_btn.Text = "Log-out"
        Me.Logout_btn.UseVisualStyleBackColor = True
        '
        'Settings_Pnl
        '
        Me.Settings_Pnl.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition1.SetDecoration(Me.Settings_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Settings_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Settings_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.Settings_Pnl.Location = New System.Drawing.Point(957, 52)
        Me.Settings_Pnl.Name = "Settings_Pnl"
        Me.Settings_Pnl.Size = New System.Drawing.Size(169, 239)
        Me.Settings_Pnl.TabIndex = 2
        '
        'BunifuTransition1
        '
        Me.BunifuTransition1.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide
        Me.BunifuTransition1.Cursor = Nothing
        Animation6.AnimateOnlyDifferences = True
        Animation6.BlindCoeff = CType(resources.GetObject("Animation6.BlindCoeff"), System.Drawing.PointF)
        Animation6.LeafCoeff = 0!
        Animation6.MaxTime = 1.0!
        Animation6.MinTime = 0!
        Animation6.MosaicCoeff = CType(resources.GetObject("Animation6.MosaicCoeff"), System.Drawing.PointF)
        Animation6.MosaicShift = CType(resources.GetObject("Animation6.MosaicShift"), System.Drawing.PointF)
        Animation6.MosaicSize = 0
        Animation6.Padding = New System.Windows.Forms.Padding(0)
        Animation6.RotateCoeff = 0!
        Animation6.RotateLimit = 0!
        Animation6.ScaleCoeff = CType(resources.GetObject("Animation6.ScaleCoeff"), System.Drawing.PointF)
        Animation6.SlideCoeff = CType(resources.GetObject("Animation6.SlideCoeff"), System.Drawing.PointF)
        Animation6.TimeCoeff = 0!
        Animation6.TransparencyCoeff = 0!
        Me.BunifuTransition1.DefaultAnimation = Animation6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.Submit_btn)
        Me.Panel2.Controls.Add(Me.Cancel_btn)
        Me.Panel2.Controls.Add(Me.Hold_btn)
        Me.Panel2.Controls.Add(Me.Return_btn)
        Me.Panel2.Controls.Add(Me.Break_btn)
        Me.BunifuTransition1.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Panel2, BunifuAnimatorNS.DecorationType.None)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1125, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(60, 664)
        Me.Panel2.TabIndex = 3
        '
        'Submit_btn
        '
        Me.Submit_btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Submit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Submit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Submit_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Submit_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Submit_btn.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Submit_btn.ForeColor = System.Drawing.Color.White
        Me.Submit_btn.Image = Global.BT_Tool.My.Resources.Resources.submit_321
        Me.Submit_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Submit_btn.Location = New System.Drawing.Point(0, 349)
        Me.Submit_btn.Name = "Submit_btn"
        Me.Submit_btn.Size = New System.Drawing.Size(60, 63)
        Me.Submit_btn.TabIndex = 17
        Me.Submit_btn.Text = "SUBMIT"
        Me.Submit_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Submit_btn.UseVisualStyleBackColor = False
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Cancel_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Cancel_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Cancel_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Cancel_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Cancel_btn.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.ForeColor = System.Drawing.Color.White
        Me.Cancel_btn.Image = Global.BT_Tool.My.Resources.Resources.cancel_32
        Me.Cancel_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cancel_btn.Location = New System.Drawing.Point(0, 412)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(60, 63)
        Me.Cancel_btn.TabIndex = 16
        Me.Cancel_btn.Text = "CANCEL"
        Me.Cancel_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'Hold_btn
        '
        Me.Hold_btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Hold_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Hold_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Hold_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Hold_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Hold_btn.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hold_btn.ForeColor = System.Drawing.Color.White
        Me.Hold_btn.Image = Global.BT_Tool.My.Resources.Resources.hold_32
        Me.Hold_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Hold_btn.Location = New System.Drawing.Point(0, 475)
        Me.Hold_btn.Name = "Hold_btn"
        Me.Hold_btn.Size = New System.Drawing.Size(60, 63)
        Me.Hold_btn.TabIndex = 15
        Me.Hold_btn.Text = "HOLD"
        Me.Hold_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Hold_btn.UseVisualStyleBackColor = False
        '
        'Return_btn
        '
        Me.Return_btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Return_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Return_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Return_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Return_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Return_btn.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Return_btn.ForeColor = System.Drawing.Color.White
        Me.Return_btn.Image = Global.BT_Tool.My.Resources.Resources.return_32
        Me.Return_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Return_btn.Location = New System.Drawing.Point(0, 538)
        Me.Return_btn.Name = "Return_btn"
        Me.Return_btn.Size = New System.Drawing.Size(60, 63)
        Me.Return_btn.TabIndex = 14
        Me.Return_btn.Text = "RETURN"
        Me.Return_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Return_btn.UseVisualStyleBackColor = False
        '
        'Break_btn
        '
        Me.Break_btn.BackColor = System.Drawing.Color.Black
        Me.BunifuTransition3.SetDecoration(Me.Break_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Break_btn, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Break_btn, BunifuAnimatorNS.DecorationType.None)
        Me.Break_btn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Break_btn.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Break_btn.ForeColor = System.Drawing.Color.White
        Me.Break_btn.Image = Global.BT_Tool.My.Resources.Resources.break_321
        Me.Break_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Break_btn.Location = New System.Drawing.Point(0, 601)
        Me.Break_btn.Name = "Break_btn"
        Me.Break_btn.Size = New System.Drawing.Size(60, 63)
        Me.Break_btn.TabIndex = 13
        Me.Break_btn.Text = "BREAK"
        Me.Break_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Break_btn.UseVisualStyleBackColor = False
        '
        'Status_Pnl
        '
        Me.Status_Pnl.BackColor = System.Drawing.Color.DimGray
        Me.Status_Pnl.Controls.Add(Me.Label3)
        Me.BunifuTransition1.SetDecoration(Me.Status_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Status_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me.Status_Pnl, BunifuAnimatorNS.DecorationType.None)
        Me.Status_Pnl.Location = New System.Drawing.Point(1011, 693)
        Me.Status_Pnl.Name = "Status_Pnl"
        Me.Status_Pnl.Size = New System.Drawing.Size(115, 23)
        Me.Status_Pnl.TabIndex = 4
        Me.Status_Pnl.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.BunifuTransition3.SetDecoration(Me.Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Label3, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Label3, BunifuAnimatorNS.DecorationType.None)
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fetching Data ..."
        '
        'BunifuTransition2
        '
        Me.BunifuTransition2.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide
        Me.BunifuTransition2.Cursor = Nothing
        Animation5.AnimateOnlyDifferences = True
        Animation5.BlindCoeff = CType(resources.GetObject("Animation5.BlindCoeff"), System.Drawing.PointF)
        Animation5.LeafCoeff = 0!
        Animation5.MaxTime = 1.0!
        Animation5.MinTime = 0!
        Animation5.MosaicCoeff = CType(resources.GetObject("Animation5.MosaicCoeff"), System.Drawing.PointF)
        Animation5.MosaicShift = CType(resources.GetObject("Animation5.MosaicShift"), System.Drawing.PointF)
        Animation5.MosaicSize = 0
        Animation5.Padding = New System.Windows.Forms.Padding(0)
        Animation5.RotateCoeff = 0!
        Animation5.RotateLimit = 0!
        Animation5.ScaleCoeff = CType(resources.GetObject("Animation5.ScaleCoeff"), System.Drawing.PointF)
        Animation5.SlideCoeff = CType(resources.GetObject("Animation5.SlideCoeff"), System.Drawing.PointF)
        Animation5.TimeCoeff = 0!
        Animation5.TransparencyCoeff = 0!
        Me.BunifuTransition2.DefaultAnimation = Animation5
        '
        'BunifuTransition3
        '
        Me.BunifuTransition3.AnimationType = BunifuAnimatorNS.AnimationType.Transparent
        Me.BunifuTransition3.Cursor = Nothing
        Animation4.AnimateOnlyDifferences = True
        Animation4.BlindCoeff = CType(resources.GetObject("Animation4.BlindCoeff"), System.Drawing.PointF)
        Animation4.LeafCoeff = 0!
        Animation4.MaxTime = 1.0!
        Animation4.MinTime = 0!
        Animation4.MosaicCoeff = CType(resources.GetObject("Animation4.MosaicCoeff"), System.Drawing.PointF)
        Animation4.MosaicShift = CType(resources.GetObject("Animation4.MosaicShift"), System.Drawing.PointF)
        Animation4.MosaicSize = 0
        Animation4.Padding = New System.Windows.Forms.Padding(0)
        Animation4.RotateCoeff = 0!
        Animation4.RotateLimit = 0!
        Animation4.ScaleCoeff = CType(resources.GetObject("Animation4.ScaleCoeff"), System.Drawing.PointF)
        Animation4.SlideCoeff = CType(resources.GetObject("Animation4.SlideCoeff"), System.Drawing.PointF)
        Animation4.TimeCoeff = 0!
        Animation4.TransparencyCoeff = 1.0!
        Me.BunifuTransition3.DefaultAnimation = Animation4
        '
        'Button2
        '
        Me.BunifuTransition3.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition2.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me.Button2, BunifuAnimatorNS.DecorationType.None)
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(0, 564)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 47)
        Me.Button2.TabIndex = 12
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Main_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1185, 716)
        Me.Controls.Add(Me.Status_Pnl)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Settings_Pnl)
        Me.Controls.Add(Me.User_Pnl)
        Me.Controls.Add(Me.Dashboard_pnl)
        Me.Controls.Add(Me.Panel1)
        Me.BunifuTransition2.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition1.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuTransition3.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Main_form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Dashboard_pnl.ResumeLayout(False)
        Me.User_Pnl.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Status_Pnl.ResumeLayout(False)
        Me.Status_Pnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents User_Btn As Button
    Friend WithEvents Settings_btn As Button
    Friend WithEvents Dashboard_pnl As Panel
    Friend WithEvents Viewreturn_btn As Button
    Friend WithEvents Monitoring_btn As Button
    Friend WithEvents Fileeval_btn As Button
    Friend WithEvents Myfileeval_btn As Button
    Friend WithEvents Burgermenu_btn As Button
    Friend WithEvents Workflow_btn As Button
    Friend WithEvents Userlist_btn As Button
    Friend WithEvents Filesdue_btn As Button
    Friend WithEvents Waittracker_btn As Button
    Friend WithEvents Idletracker_btn As Button
    Friend WithEvents Ratiotracker_btn As Button
    Friend WithEvents Flagging_btn As Button
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents User_Pnl As Panel
    Friend WithEvents Settings_Pnl As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cancel_btn As Button
    Friend WithEvents Hold_btn As Button
    Friend WithEvents Return_btn As Button
    Friend WithEvents Break_btn As Button
    Friend WithEvents Submit_btn As Button
    Friend WithEvents Status_Pnl As Panel
    Friend WithEvents Label3 As Label
    Public WithEvents BunifuTransition1 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition2 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents BunifuTransition3 As BunifuAnimatorNS.BunifuTransition
    Friend WithEvents Label4 As Label
    Friend WithEvents Logout_btn As Button
    Friend WithEvents Button2 As Button
End Class
