Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class frm_qrtracker

#Region "Class"
    Private cf As New markform.CustomClass
    Private db As New markform.SQLClass
#End Region

#Region "Variables"
    Private ErrorQry As String = ""
    Private _cnl As CancellationTokenSource
#End Region

#Region "Sub"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Tag = "track"
        DisplayData()
    End Sub

    Private Async Sub DisplayData()
        _cnl = New CancellationTokenSource
        Dim token As CancellationToken = _cnl.Token
        db.SQLDependency(False)
        Me.Cursor = Cursors.AppStarting
        Dim SelDT As String = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = ""
        Dim newdt As DataTable = New DataTable
        Dim headers As New List(Of GridHeaders)()
        headers.Add(New GridHeaders() With {.index = 0, .text = "Name", .width = 70, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 1, .text = "Filename", .width = 300, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 2, .text = "Client", .width = 80, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 3, .text = "Duration", .width = 60, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 4, .text = "Start", .width = 70, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 5, .text = "End", .width = 60, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 6, .text = "Total Working Hours", .width = 50, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 7, .text = "Ratio", .width = 50, .type = GetType(String)})
        headers.Add(New GridHeaders() With {.index = 8, .text = "mid", .visible = False, .type = GetType(String)})


        For Each itm In headers
            newdt.Columns.Add(itm.text, itm.type)
        Next

        Dim progressHandler = New Progress(Of String)(Function(val)
                                                          tss_status.Text = val
                                                      End Function)
        Dim progress As IProgress(Of String) = progressHandler

        Try
            Await Task.Run(Function()
                               Dim qry = "SELECT Id, sFile, duration, client, accuracy, status, ISNULL(btStart, '') AS tstart," & "ISNULL(btEnd, '') AS tend,(SELECT username FROM dbo.UserData WHERE Id = bt)," & "DATEDIFF(second, 0, cast(duration as datetime)) AS dursec," & "DATEDIFF(ss, CONVERT(datetime, btStart), CONVERT(datetime, btEnd)) AS twhsec " & "FROM dbo.Main WHERE CONVERT(date, dateServ) LIKE CONVERT(date,'" & SelDT & "') ORDER BY CONVERT(date, dateServ)"
                               Dim dt As DataTable = New DataTable

                               Try
                                   dt = db.query(qry)
                                   token.ThrowIfCancellationRequested()
                               Catch __unusedException1__ As Exception
                                   ErrorQry = qry
                                   Throw
                               End Try

                               Dim x = 0, cnt As Integer = dt.Rows.Count

                               For Each row As DataRow In dt.Rows
                                   token.ThrowIfCancellationRequested()
                                   progress.Report("Fetching data: " & x & " of " & cnt)
                                   Dim obj As Object() = row.ItemArray
                                   Console.Write("test: " & obj(10).ToString)
                                   Dim dursec, twhsec As Double
                                   Double.TryParse(obj(9).ToString, dursec)
                                   Double.TryParse(obj(10).ToString, twhsec)
                                   Dim r = twhsec / dursec
                                   Dim twh As String = cf.SecondsToTime24(twhsec), bstart = If(cf.IsStringEmpty(obj(6).ToString), "", Date.Parse(obj(6).ToString).ToString("h:mm:ss tt")), bend = If(cf.IsStringEmpty(obj(7).ToString), "", Date.Parse(obj(7).ToString).ToString("h:mm:ss tt"))
                                   newdt.Rows.Add(obj(8), obj(1), obj(3), obj(2), bstart, bend, twh, r.ToString("0.00"), obj(0))
                                   x += 1
                               Next
                           End Function)
            dgv_tracker.DataSource = newdt

            For Each itm In headers
                dgv_tracker.Columns(itm.index).Visible = itm.visible
                dgv_tracker.Columns(itm.index).Width = itm.width
            Next

            cf.RowsNumber(dgv_tracker)
            tssStr = "Ready!"
        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.WriteToFile("{0}==>" & ex.ToString & vbLf & vbLf + ErrorQry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
            MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        tss_status.Text = tssStr
        Me.Cursor = Cursors.[Default]
    End Sub

    Private Sub frm_qrtracker_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        cf.RowsNumber(dgv_tracker)
    End Sub

    Private Sub dtpicker_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker.ValueChanged
        DisplayData()
    End Sub

#End Region

#Region "Events"

#End Region

#Region "Functions"

#End Region
End Class