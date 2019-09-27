Imports System.IO
Imports System.Globalization

Public Class mainClass

    Private db As New markDBOClass.SQLClass
    Dim baseLoc As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    Private CustomFn As New CustomFunctions()

    Public Function isStringEmpty(ByRef str) As Boolean
        Return String.IsNullOrEmpty(str) OrElse String.IsNullOrWhiteSpace(str)
        Return isStringEmpty
    End Function

    Public Function userLogin(val As Integer) As Boolean

        Dim r As Boolean
        r = True
        Try
            db.SQLDependency(False)
            Select Case val

                Case 1 'Login
                    Dim inputUsername As String = frm_login.txt_username.Text
                    Dim inputPassword As String = frm_login.txt_password.Text
                    Dim errorCnt As Integer = 0
                    Dim msg As List(Of String) = New List(Of String)
                    Dim ctrlTxt As List(Of Control) = New List(Of Control)
                    If String.IsNullOrEmpty(inputUsername) Then
                        errorCnt = errorCnt + 1
                        msg.Add("Username is Empty.")
                        ctrlTxt.Add(frm_login.txt_username)
                    End If
                    If String.IsNullOrEmpty(inputPassword) Then
                        errorCnt = errorCnt + 1
                        msg.Add("Password is Empty.")
                        ctrlTxt.Add(frm_login.txt_password)
                    End If
                    'Validations
                    If errorCnt > 0 Then
                        frm_login.err.Text = String.Join(vbNewLine, msg) : frm_login.err.ForeColor = Color.Red
                        ctrlTxt(0).Select()
                        r = False
                    Else
                        Dim usrData As String() = db.row("SELECT Id,username,uDept,lockTime,status,password,position,department,btwork,canReturn,
                                            canEval,canReport,canMonitor,canUser,canUpload,canWorkflow FROM dbo.UserData WHERE username LIKE @uname", New String() {"uname", inputUsername})
                        'check if user 
                        If String.IsNullOrEmpty(usrData(0)) Then
                            frm_login.err.Text = "Username does not exist." : frm_login.err.ForeColor = Color.Red
                            frm_login.txt_username.Select()
                            r = False
                        Else
                            'Check if password is correct
                            If usrData(5) <> inputPassword Then
                                frm_login.err.Text = "Incorrect Password." : frm_login.err.ForeColor = Color.Red
                                frm_login.txt_password.Select()
                                r = False
                            Else
                                'check online status
                                If usrData(4) = "True" Then
                                    frm_login.err.Text = "User already logged in." : frm_login.err.ForeColor = Color.Red
                                    frm_login.txt_password.Select()
                                    r = False
                                Else

                                    Dim userid As Integer = Integer.Parse(usrData(0))
                                    Dim ol As String

                                    If usrData(6) = "admin" Then
                                        ol = "False"
                                    Else
                                        ol = "True"
                                    End If
                                    'False to ol
                                    Dim otherChanges = db.nQuery("UPDATE dbo.userData SET status=@online WHERE Id = @uid;
                                                            INSERT INTO dbo.LogData (timeIn,uid) VALUES (@timeIn,@uid)", New String() {"online", "False", "uid", userid, "timeIn", Date.Now})
                                    If otherChanges = 0 Then
                                        MessageBox.Show(frm_login, "Something went wrong while trying to login.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Else
                                        varMod.uid = userid
                                        varMod.userName = usrData(1)
                                        varMod.uDept = usrData(2)
                                        varMod.lockTime = Integer.Parse(usrData(3))
                                        varMod.status = usrData(4)
                                        varMod.CurUserPos = usrData(6)
                                        varMod.CurUserDep = usrData(7)
                                        varMod.Btwork = usrData(8)
                                        varMod.locDir = Path.Combine(baseLoc, "BT Tool Documents", varMod.uDept)

                                        varMod.canReturn = usrData(9)
                                        varMod.canEval = usrData(10)
                                        varMod.canReport = usrData(11)
                                        varMod.canMonitor = usrData(12)
                                        varMod.canUser = usrData(13)
                                        varMod.canUpload = usrData(14)
                                        varMod.canWorkflow = usrData(15)

                                        'frm_main.lbl_username.Text = varMod.userName
                                        frm_main.fillCombo()
                                        frm_main.fillMain()
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case 2 'Logout1
                    Dim timeOut As Integer = db.nQuery("UPDATE dbo.LogData set timeOut=@date WHERE Id=" & varMod.uid, New String() {"date", Date.Now})
                    Dim logOut As Integer = db.nQuery("UPDATE dbo.userData SET status=@online WHERE Id =" & varMod.uid, New String() {"online", "False"})
                    frm_main.main_gridview.DataSource = vbNull
                    'frm_main.idle_timer.Stop()
            End Select
        Catch ex As Exception
            CustomFn.ErrorLog(ex)
        End Try

        Return r

    End Function


End Class
