
Public Class frm_break

#Region "Initialize Classes"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
#End Region

#Region "Setting Variables"
    Private CurUserID As Integer
    Private CurFileID As Integer
    Private stopwatch As New Stopwatch
#End Region

#Region "Events"
    Private Sub frm_break_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        Me.Width = screenWidth
        Me.Height = screenHeight
        Me.Location = New Point(0, 0)

        Me.lbl_time.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.lbl_time.Location))
        Me.lbl_time.Parent = Me.PictureBox1
        Me.Panel1.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.Panel1.Location))
        Me.Panel1.Parent = Me.PictureBox1
        Me.btn_stop.Location = Me.PictureBox1.PointToClient(Me.PointToScreen(Me.btn_stop.Location))
        Me.btn_stop.Parent = Me.PictureBox1

        CurUserID = CustomVariables.CurrentUserID
        CurFileID = CustomVariables.FileID

        Timer1.Interval = 1000
        Timer1.Start()
        Me.stopwatch.Start()

        SaveTime("START")
    End Sub

    Private Sub frm_break_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        lbl_time.Font = New Font("Century Gothic", Me.ClientSize.Height / 4)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TickTime
    End Sub

    Private Sub btn_stop_Click(sender As Object, e As EventArgs) Handles btn_stop.Click
        SaveTime("END")

        Timer1.Stop()
        Me.stopwatch.Stop()
        Me.stopwatch.Reset()
        lbl_time.Text = "00:00:00"
        Me.Dispose()
    End Sub
#End Region

#Region "Sub Routines"
    Private Async Sub TickTime()
        Try
            Dim elapsed As TimeSpan = Await Task.Run(
                Function()
                    Return stopwatch.Elapsed
                End Function)
            lbl_time.Text = String.Format("{0:00}:{1:00}:{2:00}", Math.Floor(elapsed.TotalHours), elapsed.Minutes, elapsed.Seconds)
        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ''' <summary>
    ''' This will save the start/end time to the database
    ''' </summary>
    ''' <param name="savetype">SAVE or END</param>
    Private Sub SaveTime(savetype As String)
        Dim CurDt As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Try
            Dim qry As String = "INSERT INTO dbo.tbl_break(uid,fid,bstart,bend) VALUES(" & CurUserID & "," & CurFileID & ",'" & CurDt & "','pending')"
            If savetype = "END" Then qry = "UPDATE dbo.tbl_Break SET bend = '" & CurDt & "' WHERE uid = " & CurUserID & " AND bend LIKE 'pending'"
            db.nQuery(qry)
        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Dispose()
        End Try
    End Sub
#End Region
End Class
