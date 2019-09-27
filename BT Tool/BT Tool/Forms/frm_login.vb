Imports System.Data.SqlClient

Public Class frm_login

    Dim showpass As Image = My.Resources.show_pass_24
    Dim hidepass As Image = My.Resources.hide_pass_24

    Dim originalheight As Integer = 292
    Dim witherrorheight As Integer = 352
    Dim origbuttonlocation As Integer = 173
    Dim witherrorbuttonlocation As Integer = 230

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Login_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button2.Image = showpass

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Button2.Image Is showpass Then

            Button2.Image = hidepass
            txt_password.PasswordChar = ""

        ElseIf Button2.Image Is hidepass Then

            Button2.Image = showpass
            txt_password.PasswordChar = "*"

        End If

    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles Login_btn.Click

        trylogin()

    End Sub

    Private Sub Login_btn_MouseEnter(sender As Object, e As EventArgs) Handles Login_btn.MouseEnter
        Login_btn.BackColor = Color.Black
    End Sub

    Private Sub Login_btn_MouseLeave(sender As Object, e As EventArgs) Handles Login_btn.MouseLeave

        Login_btn.BackColor = Color.Transparent

        Button2.Image = My.Resources.show_pass_24

    End Sub

    Sub trylogin()

        ' -- Test Db Login --
        Error1_lbl.Visible = False
        Error2_lbl.Visible = False
        err.Visible = False

        If txt_username.Text.Length <= 0 Then
            Error1_lbl.Visible = True
        ElseIf txt_password.Text.Length <= 0 Then
            Error2_lbl.Visible = True
        Else

            Dim sql As String = "SELECT COUNT(*) FROM Login WHERE Username=@Username AND Password=@Password"
            Using Conn As New SqlConnection(connection.Testdbcon)
                Using cmd As New SqlCommand(sql, Conn)
                    Conn.Open()
                    cmd.Parameters.AddWithValue("@Username", txt_username.Text)
                    cmd.Parameters.AddWithValue("@Password", txt_password.Text)
                    Dim value = cmd.ExecuteScalar()
                    If value > 0 Then
                        frm_main.Show()
                        frm_main.Enabled = True
                        Me.Close()
                    Else
                        err.Visible = True
                    End If
                End Using

            End Using

        End If

        ' ---              ---

    End Sub

End Class