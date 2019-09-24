Public Class Logout_form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Main_form.Enabled = True
        Main_form.TopMost = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login_form.Show()
        Main_form.Close()
        Me.Close()
    End Sub
End Class