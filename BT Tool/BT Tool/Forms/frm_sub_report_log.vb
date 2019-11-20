Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Newtonsoft.Json

Public Class frm_sub_report_log


#Region "Class"
    Private cf As New markform.CustomClass
#End Region

#Region "Variables"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Tag = "breaklog"
    End Sub
#End Region

#Region "sub"

    Public Sub SetLocation(ByVal mainfrmwidth As Integer)
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - (Me.Width + mainfrmwidth)), (Screen.PrimaryScreen.WorkingArea.Height - Me.Height))
    End Sub

    Private Sub dgv_breaklog_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_breaklog.SelectionChanged
        GetSelectedTotalDur()
    End Sub

    Public Sub DisplayData(ByVal breakdata As String, ByVal username As String)
        Me.Text = "Break Log - " & username.ToUpper
        ' Dim bdata As List(Of BreakLogData) = JsonConvert.DeserializeObject(Of BreakLogData)(breakdata)
        Dim bdata As List(Of BreakLogData) = JsonConvert.DeserializeObject(Of List(Of BreakLogData))(breakdata)
        Dim dt As New DataTable
        dt.Columns.Add("Filename", GetType(String))
        dt.Columns.Add("Break Start", GetType(String))
        dt.Columns.Add("Break End", GetType(String))
        dt.Columns.Add("Duration", GetType(String))
        Dim dur As Double = 0
        For Each bld As BreakLogData In bdata
            dt.Rows.Add(bld.filename, bld.bstart, bld.bend, bld.duration)
            dur = dur & TimeSpan.Parse(bld.duration).TotalSeconds
        Next
        dgv_breaklog.DataSource = dt
        tss_total_dur.Text = "Total Duration: " & cf.SecondsToTime24(dur)
        tss_total_dur.ForeColor = If(dur > 5400, Color.Red, Color.Black)
        cf.RowsNumber(dgv_breaklog)
    End Sub

    Public Sub GetSelectedTotalDur()
        Dim dur As Double = 0
        For Each row As DataGridViewRow In dgv_breaklog.SelectedRows
            dur = dur & TimeSpan.Parse(row.Cells(3).Value.ToString()).TotalSeconds
        Next
        tss_sel_dur.Text = "Selected Total Duration: " & cf.SecondsToTime24(dur)
    End Sub
#End Region
End Class