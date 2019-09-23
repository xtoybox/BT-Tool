Public Class Login_form

    Dim showpas As Image = BT_Tool.My.Resources.show_pass_24
    Dim hidepas As Image = BT_Tool.My.Resources.hide_pass_24

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Login_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Button2.Image Is showpas Then

            Button2.Image = hidepas
            Password_txtbox.PasswordChar = ""

        ElseIf Button2.Image Is hidepas Then

            Button2.Image = showpas
            Password_txtbox.PasswordChar = "*"

        End If

    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click
        Main_form.Show()
        Me.Close()
    End Sub

    Private Sub Login_btn_MouseEnter(sender As Object, e As EventArgs) Handles Login_btn.MouseEnter
        Login_btn.BackColor = Color.Black
    End Sub

    Private Sub Login_btn_MouseLeave(sender As Object, e As EventArgs) Handles Login_btn.MouseLeave
        Login_btn.BackColor = Color.Transparent

        Button2.Image = My.Resources.show_pass_24

    End Sub
End Class