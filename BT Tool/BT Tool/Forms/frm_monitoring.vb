Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports markform

Public Class frm_monitoring

    Public cf = New CustomClass()
    Public db = New SQLClass()
    Public frm = New frm_sub_monitoring()

    Private Sub dgv_monitoring_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_monitoring.CellContentClick

    End Sub

    Private Sub dgv_monitoring_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_monitoring.CellContentDoubleClick
        If e.RowIndex = -1 And e.ColumnIndex = -1 Then
            Dim curdate As String = dtpicker.Value.Date.ToString("MM/dd/yyyy")
            Dim clname As String = dgv_monitoring(0, e.RowIndex).Value.ToString
            frm.SetSelectedTab(clname, e.ColumnIndex - 1, curdate)

            If Not cf.IsFormOpen("frm_sub_monitoring", True, "monitoringlog") Then

                Try
                    frm.Show(Me)
                Catch __unusedException1__ As Exception
                    frm = New frm_sub_monitoring
                    frm.SetSelectedTab(clname, e.ColumnIndex - 1, curdate)
                    frm.Show(Me)
                End Try
            Else
                cf.GetForm.Activate
            End If
        End If
    End Sub

    Private Sub dtpicker_ValueChanged(sender As Object, e As EventArgs) Handles dtpicker.ValueChanged
        Me.LoadData()
    End Sub

    Private Sub LoadData()
        db.SQLDependency(False)
        Me.Cursor = Cursors.AppStarting
        Dim curdate As String = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = ""
        tss_status.Text = "Fetching data..."
        Dim headers = New List(Of CustomClass.GridHeaders) From {
            New CustomClass.GridHeaders With {
                .index = 0,
                .text = "Client",
                .type = GetType(String),
                .width = 100
            },
            New CustomClass.GridHeaders With {
                .index = 1,
                .text = "BT Sched",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 2,
                .text = "PR Sched",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 3,
                .text = "CC Sched",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 4,
                .text = "S&T Sched",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 5,
                .text = "For BT",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 6,
                .text = "For PR",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 7,
                .text = "For CC",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 8,
                .text = "For S&T",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 9,
                .text = "For TS",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 10,
                .text = "For Audit",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 11,
                .text = "Ready",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            },
            New CustomClass.GridHeaders With {
                .index = 12,
                .text = "Done",
                .type = GetType(String),
                .width = 60,
                .align = DataGridViewContentAlignment.MiddleCenter
            }
        }
        Dim newdt As DataTable = New DataTable

        For Each itm In headers
            newdt.Columns.Add(itm.text, itm.type)
        Next

        Dim dt As DataTable = New DataTable
        Dim qry = "SELECT client AS Client," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'bt sched' AND client = a.client) AS [BT Sched]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'pr sched' AND client = a.client) AS [PR Sched]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'cc sched' AND client = a.client) AS [CC Sched]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'st sched' AND client = a.client) AS [S & T Sched]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for bt' AND client = a.client) AS [For BT]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for pr' AND client = a.client) AS [For PR]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for cc' AND client = a.client) AS [For CC]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for st' AND client = a.client) AS [For S & T]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for ts' AND client = a.client) AS [For TS]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for audit' AND client = a.client) AS [For Audit]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'ready' AND client = a.client) AS [Ready]," & "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'done' AND client = a.client) AS [Done] " & "FROM dbo.Main AS a WHERE LOWER([status]) NOT LIKE 'archive' GROUP BY client"

        Try
            dt = db.query(qry)

            For Each row As DataRow In dt.Rows
                Dim obj As Object() = row.ItemArray
                newdt.Rows.Add(obj(0), obj(1), obj(2), obj(3), obj(4), obj(5), obj(6), obj(7), obj(8), obj(9), obj(10), obj(11), obj(12))
            Next

            dgv_monitoring.DataSource = newdt

            For Each itm In headers
                dgv_monitoring.Columns(itm.index).Width = itm.width
                dgv_monitoring.Columns(itm.index).DefaultCellStyle.Alignment = itm.align
            Next

            cf.RowsNumber(dgv_monitoring)
        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.WriteToFile("{0}==>" & ex.ToString & vbLf & vbLf & qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\err.txt")
            MessageBox.Show(Me, "Exception:" & vbLf & ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

        tss_status.Text = tssStr
        Me.Cursor = Cursors.[Default]
    End Sub

    'Public Sub OnNewMessage()
    '    Dim i As ISynchronizeInvoke = CType(Me, ISynchronizeInvoke)

    '    If i.InvokeRequired Then
    '        Dim tempDelegate As SQLClass.NewMessage = New SQLClass.NewMessage(AddressOf OnNewMessage)
    '        i.BeginInvoke(tempDelegate, Nothing)
    '        Return
    '    End If

    '    RemoveHandler db.OnNewMessage, AddressOf OnNewMessage

    '    LoadData()
    '    Notif()
    'End Sub

    'Private Sub Notif()
    '    Dim curdate As String = dtpicker.Value.Date.ToString("MM/dd/yyyy")
    '    db.SQLDependency(True)
    '    db.OnNewMessage += New SQLClass.NewMessage(OnNewMessage)
    '    db.query("SELECT Id,status,dateServ FROM dbo.Main ")
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frm_monitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomFn.FormDrag(Me, Panel2)
        InitializeComponent()
        Me.Tag = "monitor"
        LoadData()
        'Notif()
    End Sub

End Class