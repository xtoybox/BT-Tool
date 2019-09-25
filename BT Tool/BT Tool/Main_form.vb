Imports BunifuAnimatorNS.BunifuTransition

Public Class Main_form

    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub Main_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' == For design ==
        Settings_Pnl.Height = 0
        User_Pnl.Height = 0

        Settings_Pnl.Visible = False
        User_Pnl.Visible = False

        Me.Width = screenWidth
        Me.Height = screenHeight - 50

        Me.Location = New Point(0, 0)
        Settings_Pnl.Left = screenWidth - 245
        User_Pnl.Left = screenWidth - 307

        ' if main panel clicked hide all dropdowns 

    End Sub

    Sub hidedropdowns()

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            Myfileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Fileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Monitoring_btn.ImageAlign = ContentAlignment.MiddleCenter
            Viewreturn_btn.ImageAlign = ContentAlignment.MiddleCenter
            Flagging_btn.ImageAlign = ContentAlignment.MiddleCenter
            Ratiotracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Idletracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Waittracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Filesdue_btn.ImageAlign = ContentAlignment.MiddleCenter
            Userlist_btn.ImageAlign = ContentAlignment.MiddleCenter
            Workflow_btn.ImageAlign = ContentAlignment.MiddleCenter

            Myfileeval_btn.Text = ""
            Fileeval_btn.Text = ""
            Monitoring_btn.Text = ""
            Viewreturn_btn.Text = ""
            Flagging_btn.Text = ""
            Ratiotracker_btn.Text = ""
            Idletracker_btn.Text = ""
            Waittracker_btn.Text = ""
            Filesdue_btn.Text = ""
            Userlist_btn.Text = ""
            Workflow_btn.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If

    End Sub

    Private Sub Burgermenu_btn_Click(sender As Object, e As EventArgs) Handles Burgermenu_btn.Click

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            Myfileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Fileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Monitoring_btn.ImageAlign = ContentAlignment.MiddleCenter
            Viewreturn_btn.ImageAlign = ContentAlignment.MiddleCenter
            Flagging_btn.ImageAlign = ContentAlignment.MiddleCenter
            Ratiotracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Idletracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Waittracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Filesdue_btn.ImageAlign = ContentAlignment.MiddleCenter
            Userlist_btn.ImageAlign = ContentAlignment.MiddleCenter
            Workflow_btn.ImageAlign = ContentAlignment.MiddleCenter

            Myfileeval_btn.Text = ""
            Fileeval_btn.Text = ""
            Monitoring_btn.Text = ""
            Viewreturn_btn.Text = ""
            Flagging_btn.Text = ""
            Ratiotracker_btn.Text = ""
            Idletracker_btn.Text = ""
            Waittracker_btn.Text = ""
            Filesdue_btn.Text = ""
            Userlist_btn.Text = ""
            Workflow_btn.Text = ""


            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        ElseIf Dashboard_pnl.Width = 50 Then

            BunifuTransition3.HideSync(Dashboard_pnl)

            Myfileeval_btn.ImageAlign = ContentAlignment.MiddleLeft
            Fileeval_btn.ImageAlign = ContentAlignment.MiddleLeft
            Monitoring_btn.ImageAlign = ContentAlignment.MiddleLeft
            Viewreturn_btn.ImageAlign = ContentAlignment.MiddleLeft
            Flagging_btn.ImageAlign = ContentAlignment.MiddleLeft
            Ratiotracker_btn.ImageAlign = ContentAlignment.MiddleLeft
            Idletracker_btn.ImageAlign = ContentAlignment.MiddleLeft
            Waittracker_btn.ImageAlign = ContentAlignment.MiddleLeft
            Filesdue_btn.ImageAlign = ContentAlignment.MiddleLeft
            Userlist_btn.ImageAlign = ContentAlignment.MiddleLeft
            Workflow_btn.ImageAlign = ContentAlignment.MiddleLeft

            Myfileeval_btn.Text = "My Evaluation"
            Fileeval_btn.Text = "File Evaluation"
            Monitoring_btn.Text = "Monitoring"
            Viewreturn_btn.Text = "View Return"
            Flagging_btn.Text = "Flagging"
            Ratiotracker_btn.Text = "Ratio Tracker"
            Idletracker_btn.Text = "Idle Tracker"
            Waittracker_btn.Text = "Wait Tracker"
            Filesdue_btn.Text = "Files Due"
            Userlist_btn.Text = "User List"
            Workflow_btn.Text = "Workflow"

            Dashboard_pnl.Width = 213
            BunifuTransition2.ShowSync(Dashboard_pnl)

        End If

    End Sub
    Private Sub Main_form_Click(sender As Object, e As EventArgs) Handles Me.Click
        hidedropdowns()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        hidedropdowns()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        hidedropdowns()
    End Sub

    Private Sub Main_pnl_Click(sender As Object, e As EventArgs) Handles Main_pnl.Click
        hidedropdowns()
    End Sub

    Private Sub User_Btn_LostFocus(sender As Object, e As EventArgs)
        'hidedropdowns()
    End Sub

    Private Sub Settings_btn_LostFocus(sender As Object, e As EventArgs)
        'hidedropdowns()
    End Sub

    Private Sub Burgermenu_btn_LostFocus(sender As Object, e As EventArgs) Handles Burgermenu_btn.LostFocus
        'hidedropdowns()
    End Sub

    Private Sub User_Btn_Click(sender As Object, e As EventArgs) Handles User_Btn.Click
        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            Myfileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Fileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Monitoring_btn.ImageAlign = ContentAlignment.MiddleCenter
            Viewreturn_btn.ImageAlign = ContentAlignment.MiddleCenter
            Flagging_btn.ImageAlign = ContentAlignment.MiddleCenter
            Ratiotracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Idletracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Waittracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Filesdue_btn.ImageAlign = ContentAlignment.MiddleCenter
            Userlist_btn.ImageAlign = ContentAlignment.MiddleCenter
            Workflow_btn.ImageAlign = ContentAlignment.MiddleCenter

            Myfileeval_btn.Text = ""
            Fileeval_btn.Text = ""
            Monitoring_btn.Text = ""
            Viewreturn_btn.Text = ""
            Flagging_btn.Text = ""
            Ratiotracker_btn.Text = ""
            Idletracker_btn.Text = ""
            Waittracker_btn.Text = ""
            Filesdue_btn.Text = ""
            Userlist_btn.Text = ""
            Workflow_btn.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If

        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        Else

            User_Pnl.Height = 200
            BunifuTransition1.ShowSync(User_Pnl)

        End If
    End Sub

    Private Sub Settings_Btn_Click(sender As Object, e As EventArgs) Handles Settings_Btn.Click
        If User_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(User_Pnl)
            User_Pnl.Height = 0

        End If

        If Dashboard_pnl.Width = 213 Then

            BunifuTransition2.HideSync(Dashboard_pnl)

            Myfileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Fileeval_btn.ImageAlign = ContentAlignment.MiddleCenter
            Monitoring_btn.ImageAlign = ContentAlignment.MiddleCenter
            Viewreturn_btn.ImageAlign = ContentAlignment.MiddleCenter
            Flagging_btn.ImageAlign = ContentAlignment.MiddleCenter
            Ratiotracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Idletracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Waittracker_btn.ImageAlign = ContentAlignment.MiddleCenter
            Filesdue_btn.ImageAlign = ContentAlignment.MiddleCenter
            Userlist_btn.ImageAlign = ContentAlignment.MiddleCenter
            Workflow_btn.ImageAlign = ContentAlignment.MiddleCenter

            Myfileeval_btn.Text = ""
            Fileeval_btn.Text = ""
            Monitoring_btn.Text = ""
            Viewreturn_btn.Text = ""
            Flagging_btn.Text = ""
            Ratiotracker_btn.Text = ""
            Idletracker_btn.Text = ""
            Waittracker_btn.Text = ""
            Filesdue_btn.Text = ""
            Userlist_btn.Text = ""
            Workflow_btn.Text = ""

            Dashboard_pnl.Width = 50
            BunifuTransition3.ShowSync(Dashboard_pnl)

        End If

        If Settings_Pnl.Height = 200 Then

            BunifuTransition1.HideSync(Settings_Pnl)
            Settings_Pnl.Height = 0

        Else

            Settings_Pnl.Height = 200
            BunifuTransition1.ShowSync(Settings_Pnl)

        End If
    End Sub

    Private Sub Exit_btn_Click(sender As Object, e As EventArgs) Handles Exit_btn.Click
        End
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Enabled = False
        Me.TopMost = True
        Me.Location = New Point(0, 0)
        Logout_form.Show()
        Logout_form.TopMost = True

    End Sub

    Private Sub Exit_btn_MouseHover(sender As Object, e As EventArgs) Handles Exit_btn.MouseHover
        Exit_btn.BackColor = Color.Red
    End Sub

    Private Sub Exit_btn_MouseLeave(sender As Object, e As EventArgs) Handles Exit_btn.MouseLeave
        Exit_btn.BackColor = Color.Black
    End Sub
End Class