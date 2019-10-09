Public Class frm_minimized
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_main.Show()
        frm_main.Location = New Point(0, 0)
        Me.Close()
    End Sub

    Private Sub frm_minimized_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class