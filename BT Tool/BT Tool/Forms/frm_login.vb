Imports System.IO

Imports System.Data.SqlClient

Public Class frm_login


#Region "Initialize Classes"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
    Private CustomFn As New CustomFunctions()
#End Region

#Region "Events"
    Private Sub Txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_username.KeyDown, txt_password.KeyDown
        If e.KeyValue = 13 Then
            LoginValidation()
        End If
    End Sub
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        LoginValidation()
    End Sub
    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Activate()
        CustomFn.SetForm(Me)
        CustomFn.FormDrag(Me, Panel1)
        txt_username.Select()
    End Sub
    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        End
    End Sub
#End Region

#Region "Sub Routines"
    ''' <summary>
    ''' Validate login credentials and setting variables from the <seealso cref="CustomVariables"/>
    ''' that will be used throughout the application.
    ''' </summary>
    Private Async Sub LoginValidation()
        'set the default display of the login form
        lbl_err.Visible = False
        txt_username.BackColor = Color.White
        txt_password.BackColor = Color.White
        'pbox_loader.Visible = True
        'set variables
        Dim uname As String = txt_username.Text : Dim pass As String = txt_password.Text
        Dim errmsg As List(Of String) = New List(Of String)() 'store error messages here
        Dim txterr As List(Of TextBox) = New List(Of TextBox)() 'store txtbox that is empty here
        'check if username is empty
        If cf.IsStringEmpty(uname) Then
            errmsg.Add("-Username field is empty.")
            txterr.Add(txt_username)
        End If
        'check if password is empty
        If cf.IsStringEmpty(pass) Then
            errmsg.Add("-Password field is empty.")
            txterr.Add(txt_password)
        End If
        'check if there's an error and display the error
        If errmsg.Count > 0 Then
            DisplayError(errmsg, txterr)
        Else
            'set the error handler
            Dim Uid As String = "" : Dim UserName As String = "" : Dim UDept As String = ""
            Dim LockTime As String = "" : Dim Status As String = "" : Dim Password As String = ""
            Dim Position As String = "" : Dim Department As String = "" : Dim BTWork As String = ""
            Dim Restrictions As String = "" : Dim IsOK As Boolean = False
            Try
                Await Task.Run(
                    Sub()
                        'check if username exist and fetch the data
                        Dim UserData As String() = db.row("SELECT Id,username,uDept,lockTime,status,password,position,department,btwork,restrictions
                            FROM dbo.UserData WHERE username LIKE @uname", New String() {"uname", uname})
                        'set the variable with the data from UserData
                        Uid = UserData(0)
                        UserName = UserData(1)
                        UDept = UserData(2)
                        LockTime = UserData(3)
                        Status = UserData(4)
                        Password = UserData(5)
                        Position = UserData(6)
                        Department = UserData(7)
                        BTWork = UserData(8)
                        Restrictions = UserData(9)

                        'check if username exist
                        If cf.IsStringEmpty(Uid) Then
                            errmsg.Add("Username does not exist.")
                            txterr.Add(txt_username)
                        Else
                            'check if password match
                            If pass <> Password Then
                                errmsg.Add("Incorrect password.")
                                txterr.Add(txt_password)
                            Else
                                'check if online 
                                If Status = "True" Then
                                    errmsg.Add("User already logged in.")
                                    txterr.Add(txt_username)
                                End If
                            End If
                        End If
                        'check if there's an error from validating the above conditions and display error
                        If errmsg.Count > 0 Then
                            IsOK = False
                        Else
                            'update the user status and insert a time log
                            Dim OtherChanges = db.nQuery("UPDATE dbo.userData SET status=@online WHERE Id = @uid;
                                                 INSERT INTO dbo.LogData (timeIn,uid) VALUES (@timeIn,@uid)",
                                                         New String() {"online", "False", "uid", Integer.Parse(Uid), "timeIn", Date.Now})
                            IsOK = (OtherChanges <> 0)
                            If OtherChanges = 0 Then
                                IsOK = False
                            Else
                                IsOK = True
                            End If
                        End If
                    End Sub)

                If IsOK Then
                    'set global variables to used throughout the whole application
                    CustomVariables.CurrentUserID = Integer.Parse(Uid)
                    CustomVariables.CurrentUserName = UserName
                    CustomVariables.CurrentUDept = UDept
                    CustomVariables.CurrentUserDepartment = Department
                    CustomVariables.CurrentUserPosition = Position
                    CustomVariables.CurrentUserIsActive = Boolean.Parse(Status)
                    CustomVariables.CurrentUserIsBTWork = Boolean.Parse(BTWork)
                    CustomVariables.LockTime = Integer.Parse(LockTime)
                    CustomVariables.FileLocalDirectory = Path.Combine(CustomVariables.MyDocumentsDirectory, "BT Tool", UDept)
                    Dim urc As New markform.UserRestrictionsClass
                    CustomVariables.CurrentUserRestriction = If(cf.IsStringEmpty(Restrictions), urc.GetPresetRestriction(Department, Position), Restrictions)
                    txt_username.Text = "" : txt_password.Text = ""
                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                Else
                    If errmsg.Count > 0 Then DisplayError(errmsg, txterr)
                End If

            Catch ex As Exception
                cf.WriteToFile("{0}==>" & ex.ToString, CustomVariables.DebugDirectory & "\\" & DebugTextFile)
            End Try
        End If
        'pbox_loader.Visible = False
    End Sub
    ''' <summary>
    ''' Displaying error message to the label.
    ''' </summary>
    ''' <param name="errmsg">List of error message</param>
    ''' <param name="txterr">list of textbox that cause the error message</param>
    Private Sub DisplayError(errmsg As List(Of String), txterr As List(Of TextBox))
        lbl_err.Visible = True : lbl_err.Text = String.Join(vbNewLine, errmsg.ToArray())
        txterr(0).Select() 'set focus on the first txtbox that has an error
        For Each txt As TextBox In txterr
            txt.BackColor = Color.FromArgb(233, 170, 170) 'change the color of all the txtbox that has an error
        Next
    End Sub

#End Region



#Region "old login"
    'Private CustomFn As New CustomFunctions()
    'Private mainClass As New mainClass()
    'Dim showpass As Image = My.Resources.show_pass_24
    'Dim hidepass As Image = My.Resources.hide_pass_24
    'Dim originalheight As Integer = 292
    'Dim witherrorheight As Integer = 352
    'Dim origbuttonlocation As Integer = 173
    'Dim witherrorbuttonlocation As Integer = 230

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    End
    'End Sub

    'Private Sub Login_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '    CustomFn.SetForm(Me)
    '    CustomFn.FormDrag(Me, Panel1)
    '    Button2.Image = showpass

    'End Sub

    'Private Sub txtUser_KeyUp(sender As Object, e As KeyEventArgs)
    '    If Me.lbl_err.Text <> "" Then Me.lbl_err.Text = ""
    '    If e.KeyCode = Keys.Enter Then Me.btn_login_Click_1(sender, e)
    'End Sub

    'Private Sub txtPass_KeyUp(sender As Object, e As KeyEventArgs)
    '    If Me.lbl_err.Text <> "" Then Me.lbl_err.Text = ""
    '    If e.KeyCode = Keys.Enter Then Me.btn_login_Click_1(sender, e)
    'End Sub

    'Sub trylogin()

    '    ' -- Test Db Login --
    '    Error1_lbl.Visible = False
    '    Error2_lbl.Visible = False
    '    lbl_err.Visible = False

    '    If txt_username.Text.Length <= 0 Then
    '        Error1_lbl.Visible = True
    '        btn_login.Image = My.Resources.logout_32
    '    ElseIf txt_password.Text.Length <= 0 Then
    '        Error2_lbl.Visible = True
    '        btn_login.Image = My.Resources.logout_32
    '    Else

    '        Dim sql As String = "SELECT COUNT(*) FROM Login WHERE Username=@Username AND Password=@Password"
    '        Using Conn As New SqlConnection(connection.Testdbcon)
    '            Using cmd As New SqlCommand(sql, Conn)
    '                Conn.Open()
    '                cmd.Parameters.AddWithValue("@Username", txt_username.Text)
    '                cmd.Parameters.AddWithValue("@Password", txt_password.Text)
    '                Dim value = cmd.ExecuteScalar()
    '                If value > 0 Then
    '                    btn_login.Image = My.Resources.logout_32
    '                    frm_main.Show()
    '                    frm_main.Enabled = True
    '                    Me.Close()
    '                Else
    '                    lbl_err.Visible = True
    '                End If
    '            End Using
    '        End Using

    '    End If

    '    ' ---              ---

    'End Sub

    'Private Sub btn_login_Click_1(sender As Object, e As EventArgs) Handles btn_login.Click
    '    'trylogin()

    '    Dim login As Boolean = mainClass.userLogin(1)

    '    If login = True Then

    '        Me.lbl_err.Text = ""
    '        Me.txt_username.Text = ""
    '        Me.txt_password.Text = ""
    '        Me.Close()

    '    End If
    'End Sub

    'Private Sub Error1_lbl_Click(sender As Object, e As EventArgs) Handles Error1_lbl.Click

    'End Sub

    'Private Sub err_Click(sender As Object, e As EventArgs) Handles lbl_err.Click

    'End Sub

    'Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    '    If Button2.Image Is showpass Then

    '        Button2.Image = hidepass
    '        txt_password.PasswordChar = ""

    '    ElseIf Button2.Image Is hidepass Then

    '        Button2.Image = showpass
    '        txt_password.PasswordChar = "•"

    '    End If

    'End Sub
#End Region

End Class