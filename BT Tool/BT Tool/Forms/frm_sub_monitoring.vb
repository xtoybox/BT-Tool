Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Windows.Forms

Public Class frm_sub_monitoring

#Region "Class"

    Private cf As New markform.CustomClass
    Private db As New markform.SQLClass

    Public Class DGVData
        Public Property dgv As DataGridView
        Public Property dataTable As DataTable
    End Class
#End Region

#Region "Variables"
    Private dgvArr As DataGridView()
    Private statArr As String()
    Private clientName As String = ""
    Private CurDt As String = ""
#End Region

#Region "Sub"


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Tag = "Monitoring Log"
        dgvArr = New DataGridView() {dgv_btsched, dgv_prsched, dgv_ccsched, dgv_stsched, dgv_forbt, dgv_forpr, dgv_forcc, dgv_forst, dgv_foraudit, dgv_ready, dgv_done}
        statArr = New String() {"bt sched", "pr sched", "cc shed", "st sched", "for bt", "for pr", "for cc", "for st", "for ts", "for audit", "ready", "done"}
    End Sub

    Public Sub SetSelectedTab(ByVal clientname As String, ByVal TabIndex As Integer, ByVal dt As String)
        Me.tabctrl.SelectedIndex = TabIndex
        Me.CurDt = dt
        clientname = clientname
        Me.Text = "Monitoring - " & clientname
        LoadData()
        Notif()
    End Sub

    Public Sub LoadData()

        Me.Cursor = Cursors.AppStarting
        db.SQLDependency(False)
        tss_status.Text = "Fetching Data..."
        Dim crdt As String = CurDt, tssStr As String = ""
        Dim dt As New DataTable()
        Dim qry As String = "SELECT branch,sFile,duration,status FROM dbo.Main WHERE client LIKE '" & clientName + "' AND LOWER([status]) NOT LIKE 'archive'"

        Dim btscheddt As New DataTable(), prscheddt As New DataTable(), ccscheddt As New DataTable(), stscheddt As New DataTable(), forbtdt As New DataTable(),
        forprdt As New DataTable(), forccdt As New DataTable(), forstdt As New DataTable(), fortsdt As New DataTable(), forauditdt As New DataTable(),
        readydt As New DataTable(), donedt As New DataTable()

        Dim dgvdata As New List(Of frm_file_eval.DGVData)()
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_btsched, .dataTable = btscheddt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_btsched, .dataTable = prscheddt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_ccsched, .dataTable = ccscheddt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_stsched, .dataTable = stscheddt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_forbt, .dataTable = forbtdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_forpr, .dataTable = forprdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_forcc, .dataTable = forccdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_forst, .dataTable = forstdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_forts, .dataTable = fortsdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_foraudit, .dataTable = forauditdt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_ready, .dataTable = readydt})
        dgvdata.Add(New frm_file_eval.DGVData() With {.dgv = dgv_done, .dataTable = donedt})

        For Each dgvd In dgvdata
            dgvd.dataTable.Columns.Add("Branch", GetType(String))
            dgvd.dataTable.Columns.Add("Filename", GetType(String))
            dgvd.dataTable.Columns.Add("Duration", GetType(String))
        Next

        Try
            dt = db.query(qry)
            For Each row As DataRow In dt.Rows
                Dim obj As Object() = row.ItemArray
                Dim stat As String = obj(3).ToString.ToLower
                dgvdata(Array.IndexOf(statArr, stat)).dataTable.Rows.Add(obj(0), obj(1), obj(2))
            Next

            For Each dgvd In dgvdata
                dgvd.dgv.DataSource = dgvd.dataTable
                dgvd.dgv.ClearSelection()
                cf.RowsNumber(dgvd.dgv)
            Next
            tssStr = "Ready!"

        Catch ex As Exception
            tssStr = "Error Encountered!"
            cf.WriteToFile("{0}==>" & ex.ToString() & "\n\n" & qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\\err.txt")
            MessageBox.Show(Me, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub OnNewMessage()
        Dim i As ISynchronizeInvoke = CType(Me, ISynchronizeInvoke)

        If i.InvokeRequired Then
            Dim tempDelegate As markform.SQLClass.NewMessage = New markform.SQLClass.NewMessage(AddressOf OnNewMessage)
            i.BeginInvoke(tempDelegate, Nothing)
            Return
        End If

        AddHandler db.OnNewMessage, AddressOf OnNewMessage
        LoadData()
        Notif()
    End Sub

    Private Sub Notif()
        Dim curdate As String = CurDt
        db.SQLDependency(True)
        AddHandler db.OnNewMessage, AddressOf OnNewMessage
        db.query("SELECT Id,status,dateServ FROM dbo.Main")
    End Sub

#End Region

#Region "Events"



#End Region

#Region "Functions"

#End Region


End Class