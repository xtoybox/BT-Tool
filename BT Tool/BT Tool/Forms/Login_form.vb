Imports System.Data.SqlClient

Public Class Login_form

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
            Password_txtbox.PasswordChar = ""

        ElseIf Button2.Image Is hidepass Then

            Button2.Image = showpass
            Password_txtbox.PasswordChar = "*"

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
        Error3_lbl.Visible = False

        If Username_txtbox.Text.Length <= 0 Then
            Error1_lbl.Visible = True
        ElseIf Password_txtbox.Text.Length <= 0 Then
            Error2_lbl.Visible = True
        Else

            Dim sql As String = "SELECT COUNT(*) FROM Login WHERE Username=@Username AND Password=@Password"
            Using Conn As New SqlConnection(connection.Testdbcon)
                Using cmd As New SqlCommand(sql, Conn)
                    Conn.Open()
                    cmd.Parameters.AddWithValue("@Username", Username_txtbox.Text)
                    cmd.Parameters.AddWithValue("@Password", Password_txtbox.Text)
                    Dim value = cmd.ExecuteScalar()
                    If value > 0 Then
                        Main_form.Show()
                        Main_form.Enabled = True
                        Me.Close()
                    Else
                        Error3_lbl.Visible = True
                    End If
                End Using

            End Using

        End If

        ' ---              ---

    End Sub

End Class