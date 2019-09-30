Public Class frm_upload
    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Me.Close()
    End Sub

    Private Sub btn_exit_MouseHover(sender As Object, e As EventArgs) Handles btn_exit.MouseHover
        btn_exit.BackColor = Color.Red
    End Sub

    Private Sub btn_exit_MouseLeave(sender As Object, e As EventArgs) Handles btn_exit.MouseLeave
        btn_exit.BackColor = Color.DarkRed
    End Sub
End Class