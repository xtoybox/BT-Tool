Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Newtonsoft.Json
Imports closedxml.excel


Public Class frm_export

#Region "Class"
    Private db As New markform.SQLClass
    Private cf As New markform.CustomClass
#End Region

#Region "Variables"
    Private _cnl As CancellationTokenSource
    Private FieldArr As String()
    Private TableArr As String()
    Private uid As Integer
    Private uName As String, uPos As String, uDep As String

    'Contianer of the datatable that will be set from the DoWork
    Private nDataTable As New DataTable
    Private nDataSet As New DataSet
    'Data range
    Private DateSelectionRange As SelectionRange
    'eval, break, flag, or return
    Private dType As String = ""
    Private client = "all", dep As String = "all"
    Private totalData = 0
    Private OldDateSelectionRange As SelectionRange

    Private ErroQuerry As String = ""

#End Region

#Region "Sub"
    Public Sub New(ByVal args As Object(), ByVal type As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If args IsNot Nothing Then

            uid = Integer.Parse(args(0).ToString)
            uName = args(1).ToString
            uPos = args(2).ToString
            uDep = args(3).ToString
            setcbodatasource
            formtitle(type)
            dType = type
            OldDateSelectionRange = dtpicker.SelectionRange
            tss_status.Text = "Ready"
            fetchdata

        End If
    End Sub
#End Region

#Region "Events"

    Private Sub dtpicker_DateSelected(sender As Object, e As DateRangeEventArgs) Handles dtpicker.DateSelected
        fetchdata
    End Sub

    Private Sub cbo_client_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_client.SelectedIndexChanged
        fetchdata
    End Sub

    Private Sub cbo_dep_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_dep.SelectedIndexChanged
        fetchdata
    End Sub

    Private Async Sub btn_export_Click(ByVal sender As Object, ByVal e As EventArgs)

        If totalData > 0 Then
            Me.Cursor = Cursors.AppStarting
            Dim path = ""

            Using fbd As FolderBrowserDialog = New FolderBrowserDialog
                fbd.Description = "Select export location"

                If fbd.ShowDialog = DialogResult.OK Then
                    path = fbd.SelectedPath
                End If
            End Using

            If path IsNot "" Then
                dtpicker.Enabled = False
                btn_close.Enabled = False

                If New String() {"flag", "return"}.Contains(Me.Tag.ToString) Then
                    cbo_client.Enabled = False
                    cbo_dep.Enabled = False
                End If

                tss_status.Text = "Initializing..."
                lbl_status.Text = "Preparing..."
                Dim tssStr = "", lblStr = ""
                Dim progressHandler = New Progress(Of String)(Function(val)
                                                                  tss_status.Text = val
                                                              End Function)
                Dim progress As IProgress(Of String) = progressHandler

                Try
                    Await Task.Run(Function()
                                       progress.Report("Preparing sheet name...")
                                       Thread.Sleep(500)
                                       Dim sheetname As String = If(DateSelectionRange.Start <> DateSelectionRange.[End], DateSelectionRange.Start.ToString("MMM.d.yyyy") & "_" + DateSelectionRange.[End].ToString("MMM.d.yyyy"), DateSelectionRange.Start.ToString("MMM d, yyyy"))
                                       progress.Report("Preparing excel name...")
                                       Thread.Sleep(500)
                                       Dim withCLandDep = If(dType Is "eval" OrElse dType Is "break", "", client & "_" + dep & "_")
                                       Dim excelName As String = dType.ToUpper & "_" & sheetname & "_" & withCLandDep + Date.Now.ToString("yyyy.MM.dd.HHmmss") & ".xlsx"
                                       progress.Report("Preparing to export...")
                                       Thread.Sleep(500)

                                       Using wb As XLWorkbook = New XLWorkbook
                                           progress.Report("Adding data to excel worksheet...")
                                           Thread.Sleep(500)
                                           wb.Worksheets.Add(nDataSet)

                                           For Each ws As IXLWorksheet In wb.Worksheets
                                               Dim str = If(dType Is "break", ws.Worksheet.Name & " - ", "")
                                               Dim dtformat = If(dType Is "eval", "m/d/yyyy", "m/d/yyyy h:mm:ss AM/PM;@")
                                               progress.Report(str & "Removing default filter...")
                                               Thread.Sleep(500)
                                               ws.Tables.FirstOrDefault.ShowAutoFilter = False
                                               progress.Report(str & "Setting data type...")
                                               Thread.Sleep(500)
                                               ws.Range("A2", "A" & ws.RowsUsed.Count.ToString).DataType = XLDataType.DateTime
                                               progress.Report(str & "Formatting cells...")
                                               Thread.Sleep(500)
                                               ws.Range("A2", "A" & ws.RowsUsed.Count.ToString).Style.DateFormat.Format = dtformat
                                               progress.Report(str & "Setting cell alignment...")
                                               Thread.Sleep(500)
                                               ws.Range("A2", "A" & ws.RowsUsed.Count.ToString).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left)
                                               progress.Report(str & "Freezing first row...")
                                               Thread.Sleep(500)
                                               ws.SheetView.FreezeRows(1)
                                           Next

                                           progress.Report("Saving excel...")
                                           Thread.Sleep(500)
                                           wb.SaveAs(path & "\" & excelName)
                                       End Using
                                   End Function)
                    btn_export.Enabled = totalData > 0
                    tssStr = "Done."
                    lblStr = If(totalData = 0, "No Data to Export", "Total data: " & totalData)
                    MessageBox.Show(Me, "Export complete.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    tssStr = "Error Encountered!"
                    lblStr = "Failed"
                    Dim innerException = If(ex.InnerException.Message IsNot Nothing, vbLf & ex.InnerException.Message, "")
                    MessageBox.Show(Me, "Exception:" & vbLf & ex.Message & innerException, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                End Try

                dtpicker.Enabled = True
                btn_close.Enabled = True

                If New String() {"flag", "return"}.Contains(dType.ToString) Then
                    cbo_client.Enabled = True
                    cbo_dep.Enabled = True
                End If

                tss_status.Text = tssStr
                lbl_status.Text = lblStr
                Me.Cursor = Cursors.[Default]
            End If
        Else
            MessageBox.Show(Me, "No data to export.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Dispose()
    End Sub

    Private Sub frm_export_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _cnl IsNot Nothing Then
            _cnl.Cancel()
        End If
    End Sub



#End Region

#Region "Sub"
    Sub formTitle(ByVal type As String)

        Dim title As String = "Export to Excel"
        Dim fields As String() = {}
        Dim opsDep As String
        Select Case type
            Case "eval"
                title = title & " - Evaluation"
                fields = New String() {"Date", "BT", "PR", "Account", "Filename", "Score"}
            Case "break"
                title = title + " - Break"
                If (New String() {"sup", "tl"}).Contains(uPos) Then
                    fields = New String() {"Date", "Username", "Filename", "Break Start", "Break End", "Duration"}
                Else
                    fields = New String() {"Date", "Department", "Username", "Filename", "Break Start", "Break End", "Duration"}
                    TableArr = New String() {"BT", "PR", "BET"}
                End If
            Case "return"
                title = title + " - Return"
                opsDep = If(uDep = "pr", "bt", "pr")
                fields = New String() {"Date and Time", opsDep.ToUpper() + " Name", uDep.ToUpper() + " Name", "File Fixed By", uDep.ToUpper() + " Name 2", "Client", "Filename", "Accuracy", "Specs", opsDep.ToUpper() + " Comment", "Action By " + opsDep.ToUpper() + " Sup", "Side-by-side Feedback", "Comment"}
            Case "flag"
                title = title + " - Flagging"
                fields = New String() {"Date and Time", "Username", "Client", "Client Type", "Filename", "Problem"}
        End Select

        Me.FieldArr = fields
        Me.Text = title
        Me.Tag = type
        Me.Height = 320

        If (New String() {"flag", "return"}).Contains(type) Then
            pnl_cl_dep_container.Visible = True
            setcbodatasource()
            Me.Height = 390
            FetchData()
        End If

    End Sub

    Private Async Sub FetchData()
        _cnl = New CancellationTokenSource
        Dim token As CancellationToken = _cnl.Token
        db.SQLDependency(False)
        Dim dtsr As SelectionRange = dtpicker.SelectionRange
        Dim stime As String = dtsr.Start.ToString("MM/dd/yyyy"), etime As String = dtsr.[End].ToString("MM/dd/yyyy"), tssStr = "", lblStr = ""
        Me.Cursor = Cursors.AppStarting
        dtpicker.Enabled = False
        btn_close.Enabled = False
        btn_export.Enabled = False
        tss_status.Text = "Initializing..."
        lbl_status.Text = "Preparing..."

        If New String() {"flag", "return"}.Contains(Me.Tag.ToString) Then
            cbo_client.Enabled = False
            cbo_dep.Enabled = False
            Me.client = cbo_client.SelectedValue.ToString
            Me.dep = cbo_dep.SelectedValue.ToString
        End If

        Dim progressHandler = New Progress(Of String)(Function(val)
                                                          tss_status.Text = val
                                                      End Function)
        Dim progress As IProgress(Of String) = progressHandler

        Try
            Await Task.Run(Function()
                               Dim sheetname As String = If(dtsr.Start = dtsr.[End], dtsr.Start.ToString("MMM.d.yyyy") & "_" + dtsr.[End].ToString("MMM.d.yyyy"), dtsr.Start.ToString("MMM d, yyyy"))
                               Dim qry = ""
                               Dim qrywhere = New List(Of String)

                               Select Case dType
                                   Case "eval"
                                       qry = "SELECT (SELECT username FROM dbo.UserData WHERE Id = user_id)," & "(SELECT username FROM dbo.UserData WHERE Id = eval_user_id)," & "(SELECT cl_id FROM dbo.tbl_client WHERE cl_id = a.cl_id),filename,CONVERT(date, dt_created)," & "total_score FROM dbo.tbl_btpr_eval AS a WHERE " & "CONVERT(date, dt_created) BETWEEN CONVERT(date,'" & stime & "') AND CONVERT(date,'" & etime & "') " & "ORDER BY CAST(dt_created AS datetime)"
                                   Case "break"

                                       If New String() {"sup", "tl"}.Contains(uPos) Then
                                           qrywhere.Add("department LIKE '" & uDep & "'")
                                       End If

                                       Dim w = If(qrywhere.Count > 0, " AND " & String.Join(" AND ", qrywhere.ToArray), "")
                                       qry = "SELECT a.Id,username,department,position,ISNULL(bstart,''),ISNULL(bend,'')," & "ISNULL(bstart, ''),ISNULL(DATEDIFF(ss, CONVERT(datetime, bstart)," & "CONVERT(datetime, bend)), 0) FROM dbo.UserData AS a " & "LEFT OUTER JOIN dbo.tbl_break AS b ON a.Id = b.uid AND " & "CONVERT(date, bstart) BETWEEN CONVERT(date,'" & stime & "') AND CONVERT(date,'" & etime & "') " & "WHERE deactivated = 0 AND position NOT IN('it','sup','opsup') " & w & " " & "ORDER BY department,CONVERT(date, bstart),username,CAST(bstart AS datetime)"
                                   Case Else
                                       Dim qrysel = If(dType Is "return", "others", "problem,(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype")
                                       Dim PosArrFull = New String() {"sup", "opsup", "it", "hr", "tl", "ts", "auditor"}

                                       If Not PosArrFull.Contains(uPos) Then
                                           qrywhere.Add("user_id = " & uid)

                                           If dType Is "return" Then
                                               qrywhere.Add("dep LIKE '" & uDep & "'")
                                           End If
                                       Else

                                           If dType Is "return" Then
                                               qrywhere.Add("dep IN " & If(uDep Is "pr", "('pr','bet')", If(uDep Is "bt", "pr", "bet")))
                                           End If
                                       End If

                                       If client IsNot "all" Then
                                           qrywhere.Add("cl_id IN ((SELECT cl_id FROM dbo.tbl_client WHERE ctype LIKE '" & client & "'))")
                                       End If

                                       If dep IsNot "all" Then
                                           qrywhere.Add("dep LIKE '" & dep & "'")
                                       End If

                                       Dim addWhereJoin = If(qrywhere.Count > 0, String.Join(" AND ", qrywhere.ToArray) & " AND ", "")
                                       qry = "SELECT filename,CAST(dt_created AS datetime)," & "(SELECT username FROM dbo.UserData WHERE Id = a.user_id) AS uname," & "(SELECT username FROM dbo.UserData WHERE Id = a.user2_id) AS uname2," & "(SELECT username FROM dbo.UserData WHERE Id = a.btpr_id) AS btprname," & "(SELECT username FROM dbo.UserData WHERE Id = a.fixer_id) AS fixername," & "(SELECT username FROM dbo.UserData WHERE Id = a.act_id) AS actname," & "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," & qrysel & " FROM dbo.tbl_flag_return AS a WHERE " & addWhereJoin & "" & "type LIKE '" & dType & "' AND CONVERT(date, dt_created) BETWEEN CONVERT(date,'" & stime & "') AND CONVERT(date,'" & etime & "') " & "ORDER BY CAST(dt_created AS datetime)"
                               End Select

                               progress.Report("Fetching data...")
                               Dim dt As DataTable = New DataTable

                               Try
                                   dt = db.query(qry)
                                   token.ThrowIfCancellationRequested()
                               Catch __unusedException1__ As Exception
                                   Throw
                               End Try

                               totalData = dt.Rows.Count
                               Dim newdt As DataTable = New DataTable
                               Dim bt As DataTable = New DataTable("BT"), pr As DataTable = New DataTable("PR"), bet As DataTable = New DataTable("BET")
                               Dim dataTables = New DataTable() {bt, pr, bet}
                               sheetname = If(dType Is "break", "Others", sheetname)
                               newdt = New DataTable(sheetname)

                               For Each field As String In FieldArr
                                   newdt.Columns.Add(field, GetType(String))
                               Next

                               If TableArr IsNot Nothing Then

                                   For Each dataTable As DataTable In dataTables

                                       For Each field As String In FieldArr
                                           dataTable.Columns.Add(field, GetType(String))
                                       Next
                                   Next
                               End If

                               Dim i = 1, cnt As Integer = dt.Rows.Count
                               Dim DepIndexArr = New String() {"bt", "pr", "bet"}

                               For Each row As DataRow In dt.Rows
                                   token.ThrowIfCancellationRequested()
                                   progress.Report(i & " of " & cnt)
                                   Dim obj As Object() = row.ItemArray

                                   Select Case dType
                                       Case "eval"
                                           newdt.Rows.Add(obj(4), obj(0), obj(1), obj(2), obj(3), obj(5))
                                       Case "break"
                                           Dim DurSec = Double.Parse(obj(7).ToString)
                                           Dim dur As String = cf.SecondsToTime24(DurSec)

                                           If New String() {"sup", "tl"}.Contains(uPos) Then
                                               newdt.Rows.Add(obj(6), obj(1), obj(4), obj(5), dur)
                                           Else
                                               Dim depIndex = Array.IndexOf(DepIndexArr, obj(2).ToString.ToLower)

                                               If depIndex = -1 Then
                                                   newdt.Rows.Add(obj(6), obj(2).ToString.ToUpper, obj(1), obj(4), obj(5), dur)
                                               Else
                                                   dataTables(depIndex).Rows.Add(obj(6), obj(1), obj(4), obj(5), dur)
                                               End If
                                           End If

                                       Case "flag"
                                           Dim clt = If(obj(9).ToString Is "non", "Non-Insurance", "Insurance")
                                           newdt.Rows.Add(obj(1), obj(2), obj(7), clt, obj(0), obj(8))
                                       Case "return"
                                           Dim rfObj As returnfile = JsonConvert.DeserializeObject(Of returnfile)(obj(8).ToString)
                                           Dim ac As String = rfObj.accuracy, sp As String = rfObj.specs, com1 As String = rfObj.btpr_comment, com2 As String = rfObj.side_comment, com3 As String = rfObj.comment
                                           newdt.Rows.Add(obj(1), obj(4), obj(2), obj(5), obj(3), obj(7), obj(0), ac, sp, com1, obj(6), com2, com3)
                                   End Select

                                   i += 1
                               Next

                               nDataTable = New DataTable
                               nDataTable = newdt
                               Dim dset As DataSet = New DataSet(dType)
                               Dim lstdt = New List(Of DataTable)

                               If TableArr IsNot Nothing Then

                                   For Each dataTable As DataTable In dataTables
                                       dset.Tables.Add(dataTable)
                                   Next
                               End If

                               dset.Tables.Add(newdt)
                               nDataSet = New DataSet
                               nDataSet = dset
                           End Function)
            btn_export.Enabled = totalData > 0
            tssStr = "Done."
            lblStr = If(totalData = 0, "No Data to Export", "Total data: " & totalData)
            Me.OldDateSelectionRange = dtsr
        Catch ex As Exception
            tssStr = "Error Encountered!"
            lblStr = "Failed"
            cf.WriteToFile("{0}==>" & ex.ToString & vbLf & vbLf + ErroQuerry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
            MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        ErroQuerry = ""
        dtpicker.Enabled = True
        btn_close.Enabled = True

        If New String() {"flag", "return"}.Contains(dType.ToString) Then
            cbo_client.Enabled = True
            cbo_dep.Enabled = True
        End If

        tss_status.Text = tssStr
        lbl_status.Text = lblStr
        Me.Cursor = Cursors.[Default]

    End Sub

    Public Sub SetCboDataSource()

        Dim dt As New DataTable
        Me.cbo_client.DisplayMember = "text"
        Me.cbo_client.ValueMember = "value"
        Me.cbo_dep.DisplayMember = "text"
        Me.cbo_dep.ValueMember = "value"

        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))
        dt.Rows.Add("All", "all")
        dt.Rows.Add("Insurance", "ins")
        dt.Rows.Add("Non-insurance", "non")
        cbo_client.DataSource = dt

        dt = New DataTable
        dt.Columns.Add("text", GetType(String))
        dt.Columns.Add("value", GetType(String))
        dt.Rows.Add("All", "all")
        dt.Rows.Add("Business Transcriber", "bt")
        dt.Rows.Add("Proofreader", "pr")
        dt.Rows.Add("BET", "bet")
        cbo_client.DataSource = dt

    End Sub

#End Region


#Region "Functions"



#End Region
End Class