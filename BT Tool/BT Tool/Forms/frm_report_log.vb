Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class frm_report_log

#Region "Class"
    Private cf As New markform.CustomClass
    Private frm As New frm_sub_report_log
    Private db_break As New markform.SQLClass
    Private db_notif As New markform.SQLClass
#End Region

#Region "Variables"
    Private CurSelUser As String = "", CurrentRestriction As String = ""
    Private IsAllowViewBL As Boolean = True, IsAllowViewIL As Boolean = True
    Private AllowDepBL As String(), AllowDepIL As String()
#End Region

#Region "Sub"

    Public Sub New(ByVal currestriction As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CurrentRestriction = currestriction
        Me.Tag = "report"
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Width), (Screen.PrimaryScreen.WorkingArea.Height - Height))
        SetRestrictions()
    End Sub


    Private Sub OnNewMessage_break()
        Dim i As ISynchronizeInvoke = CType(Me, ISynchronizeInvoke)

        If i.InvokeRequired Then
            Dim tempDelegate As markform.SQLClass.NewMessage = New markform.SQLClass.NewMessage(AddressOf OnNewMessage_break)
            i.BeginInvoke(tempDelegate, Nothing)
            Return
        End If
        AddHandler db_break.OnNewMessage, AddressOf OnNewMessage_break
        DisplayData("break")
        Notif("break")
    End Sub

    Private Sub OnNewMessage_idle()
        Dim i As ISynchronizeInvoke = CType(Me, ISynchronizeInvoke)

        If i.InvokeRequired Then
            Dim tempDelegate As markform.SQLClass.NewMessage = New markform.SQLClass.NewMessage(AddressOf OnNewMessage_idle)
            i.BeginInvoke(tempDelegate, Nothing)
            Return
        End If

        AddHandler db_notif.OnNewMessage, AddressOf OnNewMessage_idle
        DisplayData("idle")
        Notif("idle")
    End Sub

    Private Sub Notif(ByVal type As String)
        db_break.SQLDependency(True)
        Dim qry As String = If(type = "break", "SELECT bid,uid,bstart,bend FROM dbo.tbl_break", "SELECT Id,uid,time,date FROM dbo.tbl_idle")
        Dim db As markform.SQLClass = If(type = "break", db_break, db_notif)

        If type = "break" Then
            'db.OnNewMessage, New SQLClass.NewMessage(OnNewMessage_break)
            'AddHandler db_break.OnNewMessage, AddressOf markform.SQLClass.NewMessage(AddressOf OnNewMessage_break)
            AddHandler db.OnNewMessage, AddressOf OnNewMessage_break
        Else
            AddHandler db.OnNewMessage, AddressOf OnNewMessage_idle
        End If
        db.query(qry)
    End Sub

    Private Sub DisplayData(ByVal type As String)

        Me.Cursor = Cursors.AppStarting

        tss_status.Text = "Fetching Data..."
        Dim db As markform.SQLClass = If(type = "break", db_break, db_notif)
        db.SQLDependency(False)
        Dim headers As New List(Of GridHeaders)()

        If type = "idle" Then
            headers.Add(New GridHeaders() With {.index = 0, .text = "Username", .type = GetType(String)})
            headers.Add(New GridHeaders() With {.index = 1, .text = "Idle Time", .type = GetType(String)})
        Else
            headers.Add(New GridHeaders() With {.index = 0, .text = "Username", .type = GetType(String)})
            headers.Add(New GridHeaders() With {.index = 1, .text = "Duration", .type = GetType(String)})
            headers.Add(New GridHeaders() With {.index = 2, .text = "Logdata", .visible = False, .type = GetType(String)})
            headers.Add(New GridHeaders() With {.index = 3, .text = "Status", .type = GetType(String)})
        End If

        Dim curdt As String = DateTime.Now.ToString("MM/dd/yyyy"), tssStr As String = ""
        Dim dgv As DataGridView = If(type = "break", dgv_break, dgv_notif)
        Dim AllowDep As String() = If(type = "break", AllowDepBL, AllowDepIL)

        Dim AddQueryFilter As String = If(AllowDep.Length > 0, " AND dep IN('" & String.Join("','", AllowDep) & "')", "")
        Dim qry As String = If(type = "break",
                "SELECT bid,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username)))," +
                "ISNULL((SELECT sFile FROM dbo.Main WHERE Id = fid),'None')," +
                "DATEDIFF(ss, CONVERT(datetime, bstart), CONVERT(datetime, CASE bend WHEN 'pending' THEN GETDATE() ELSE bend END)) AS tbhsec," +
                "bstart, bend, uid FROM dbo.tbl_break AS a LEFT JOIN dbo.UserData AS b ON a.uid = b.Id " +
                "WHERE CONVERT(date, [bstart]) LIKE CONVERT(date,'" + curdt + "') " + AddQueryFilter +
                "ORDER BY username,Convert(varchar(30), bstart, 101) DESC",
                "SELECT a.Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))),time,[date],uid " +
                "FROM dbo.tbl_idle AS a LEFT JOIN dbo.UserData AS b ON a.uid = b.Id " +
                "WHERE CONVERT(date, [itime]) LIKE CONVERT(date,'" + curdt + "') " + AddQueryFilter +
                "ORDER BY username,Convert(varchar(30), itime, 101) DESC")

        Dim newdt As New DataTable
        For Each itm In headers
            newdt.Columns.Add(itm.text, itm.type)
        Next

        Dim dt As New DataTable
        Try
            dt = db.query(qry)
            Dim tempBreakLst As New List(Of BreakLogData)
            Dim tempUid As Integer = 0, CurRow As Integer = 0
            Dim tempDur As Double = 0
            Dim breakOngoing As String = ""

            For Each row As DataRow In dt.Rows
                Dim obj As Object = row.ItemArray

                If type = "idle" Then
                    newdt.Rows.Add(obj(1), obj(2))
                Else
                    Dim uid As Integer = Integer.Parse(obj(6).ToString()), nxtUid As Integer = 0

                    Dim nxtObj As Object()

                    Try
                        nxtObj = dt.Rows(CurRow + 1).ItemArray
                        nxtUid = Integer.Parse(nxtObj(6).ToString)
                    Catch ex As Exception
                        nxtUid = 0
                    End Try

                    Dim tbhsec As Double = Double.Parse(obj(3).ToString)
                    Dim tbh As String = cf.SecondsToTime24(tbhsec)
                    Dim bld As New BreakLogData()
                    bld.filename = obj(2).ToString
                    bld.bstart = obj(4).ToString
                    bld.bend = obj(5).ToString
                    bld.duration = tbh

                    tempBreakLst.Add(bld)
                    tempDur = tempDur + tbhsec
                    If obj(5).ToString = "pending" Then breakOngoing = "On Break"
                    If Not uid = nxtUid Then
                        Dim bld_output As String = JsonConvert.SerializeObject(tempBreakLst)
                        newdt.Rows.Add(obj(1), cf.SecondsToTime24(tempDur), bld_output, breakOngoing)
                        If CurSelUser.ToLower = obj(1).ToString.ToLower Then
                            frm.DisplayData(bld_output, CurSelUser)
                            frm.SetLocation(Width)
                        End If
                        tempUid = uid
                        tempDur = 0
                        tempBreakLst = New List(Of BreakLogData)
                        breakOngoing = ""
                    End If
                End If
                CurRow += 1
            Next
        Catch ex As Exception
            tssStr = "Error Encoutnered!"
            cf.Debug(ex, True, "", "\n\n" + qry)
        End Try
        tssStr = "Done!"
        dgv.DataSource = newdt
        For Each itm In headers
            dgv.Columns(itm.index).Visible = itm.visible
        Next
        tss_status.Text = tssStr
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub SetRestrictions()
        Dim rl As New markform.ReportLog
        Try
            Dim urc As markform.UserRestrictionsClass = JsonConvert.DeserializeObject(Of markform.UserRestrictionsClass)(CurrentRestriction)
            rl = urc.ReportLog
        Catch ex As Exception
            cf.Debug(ex, True, "Something is wrong with the current restrictions.\nRestrictions will revert to default.")
        End Try
        IsAllowViewBL = rl.AllowViewBreakLog
        IsAllowViewIL = rl.AllowViewIdleLog
        AllowDepBL = rl.BreakLogRestrictedDepartment
        AllowDepIL = rl.IdleLogRestrictedDepartment

        If Not rl.AllowViewBreakLog Then
            tab_main.TabPages.Remove(tab_break)
        Else
            DisplayData("break")
            Notif("break")
        End If

        If Not rl.AllowViewIdleLog Then
            tab_main.TabPages.Remove(tab_notif)
        Else
            DisplayData("idle")
            Notif("idle")
        End If
    End Sub
#End Region

#Region "Events"

#End Region

#Region "Functions"

#End Region
End Class