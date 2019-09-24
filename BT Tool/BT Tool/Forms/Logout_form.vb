Public Class Logout_form
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Main_form.Enabled = True
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Main_form.Close()
        Login_form.Show()
        Me.Close()
    End Sub
End Class