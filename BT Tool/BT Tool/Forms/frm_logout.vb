Public Class frm_logout
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        frm_main.Enabled = True
        frm_main.TopMost = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_login.Show()
        frm_main.Close()
        Me.Close()
    End Sub
End Class