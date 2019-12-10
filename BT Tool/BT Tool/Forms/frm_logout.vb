Public Class frm_logout
    Private Sub btn_yes_Click_1(sender As Object, e As EventArgs) Handles btn_yes.Click

        frm_login.Show()
        frm_main.Close()
        Me.Close()

    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Me.Close()
        frm_main.Enabled = True
        frm_main.TopMost = False
    End Sub
End Class