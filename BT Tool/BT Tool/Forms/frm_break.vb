Public Class frm_break
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub frm_break_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Me.Width = screenWidth
        Me.Height = screenHeight
        Me.Location = New Point(0, 0)

        Me.lbl_time.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.lbl_time.Location))
        Me.lbl_time.Parent = Me.PictureBox1
        Me.Panel1.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.Panel1.Location))
        Me.Panel1.Parent = Me.PictureBox1
        Me.btn_stop.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.btn_stop.Location))
        Me.btn_stop.Parent = Me.PictureBox1

    End Sub

    Private Sub lbl_time_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btn_stop_Click_1(sender As Object, e As EventArgs) Handles btn_stop.Click
        Me.Close()
    End Sub

    Private Sub lbl_time_Click_1(sender As Object, e As EventArgs) Handles lbl_time.Click

    End Sub
End Class