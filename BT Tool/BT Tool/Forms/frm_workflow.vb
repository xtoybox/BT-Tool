Public Class frm_workflow

#Region "Class"
    Private cf As New markform.CustomClass
    Private db As New markform.SQLClass
    Private WFID As Int16
    Private LastFlow As String = ""
    Private CustomFn As New CustomFunctions()
#End Region

#Region "Sub"

    ''' <summary>
    ''' Populate data to combobox
    ''' </summary>
    ''' <param name="cbo"></param>
    Private Sub PopulateCBO(cbo As ComboBox)
        Dim dt As New DataTable()
        dt.Columns.Add("txt", GetType(String))
        dt.Columns.Add("val", GetType(String))

        dt.Rows.Add("", "")
        dt.Rows.Add("BT", "bt")
        dt.Rows.Add("PR", "pr")
        dt.Rows.Add("CC", "cc")
        dt.Rows.Add("S&T", "st")
        dt.Rows.Add("TS", "ts")

        cbo.DataSource = dt
        cbo.DisplayMember = "txt" : cbo.ValueMember = "val"
    End Sub
    ''' <summary>
    ''' Reset the selected item to default
    ''' </summary>
    Private Sub ResetToDefault()
        cbo_step1.SelectedIndex = 0
        cbo_step2.SelectedIndex = 0
        cbo_step3.SelectedIndex = 0
        cbo_step4.SelectedIndex = 0
        cbo_step5.SelectedIndex = 0
        WFID = 0 : LastFlow = ""
    End Sub
    ''' <summary>
    ''' Load Data to datagridview
    ''' </summary>
    Private Sub LoadWorkFlow()
        Try
            Dim headers As New List(Of GridHeaders)()
            headers.Add(New GridHeaders() With {.index = 0, .text = "ID", .type = GetType(Integer), .visible = False})
            headers.Add(New GridHeaders() With {.index = 1, .text = "Work Flow", .type = GetType(String), .width = 200})
            Dim newdt As New DataTable()
            For Each itm As GridHeaders In headers
                newdt.Columns.Add(itm.text, itm.type)
            Next
            Dim dt As DataTable = db.query("SELECT Id, flow FROM dbo.Workflow")
            For Each rows As DataRow In dt.Rows
                Dim row() As Object = rows.ItemArray
                newdt.Rows.Add(row(0), row(1))
            Next
            dgv_wf.DataSource = newdt
            For Each itm As GridHeaders In headers
                dgv_wf.Columns(itm.index).Width = itm.width
                dgv_wf.Columns(itm.index).Visible = itm.visible
            Next

        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frm_workflow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCBO(cbo_step1) : PopulateCBO(cbo_step2)
        PopulateCBO(cbo_step3) : PopulateCBO(cbo_step4)
        PopulateCBO(cbo_step5)
        LoadWorkFlow()
        CustomFn.FormDrag(Me, Panel1)
    End Sub

    Private Sub btn_reset_Click(sender As Object, e As EventArgs) Handles btn_reset.Click
        ResetToDefault()
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim CbosVal As List(Of String) = New List(Of String)()
            For Each cbo As ComboBox In pnl_wf.Controls.OfType(Of ComboBox).Reverse
                Dim val As String = cbo.SelectedValue.ToString()
                If Not cf.IsStringEmpty(val) Then CbosVal.Add(val.ToUpper())
            Next
            If CbosVal.Count > 0 Then
                'check if workflow already exist
                Dim wf As String = String.Join("-", CbosVal.ToArray())
                Dim chk As Integer = Integer.Parse(db.single("SELECT COUNT(Id) FROM dbo.Workflow WHERE flow LIKE '" & wf & "'"))
                If chk > 0 And LastFlow <> wf Then
                    MessageBox.Show(Me, "Work Flow already exist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Dim qrystr As String = ""
                    If WFID = 0 Then
                        qrystr = "INSERT INTO dbo.Workflow (flow) VALUES('" & wf & "')"
                    Else
                        qrystr = "UPDATE dbo.Workflow SET flow = '" & wf & "' WHERE Id = " & WFID
                    End If
                    Dim qry As Integer = db.nQuery(qrystr)
                    If qry > 0 Then
                        LoadWorkFlow()
                        ResetToDefault()
                        MessageBox.Show(Me, "Work flow successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(Me, "Work flow failed to save.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show(Me, "No work flow to add", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgv_wf_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_wf.CellDoubleClick
        Try
            ResetToDefault()
            Dim row As DataGridViewRow = dgv_wf.Rows(e.RowIndex)
            Dim Cbos As List(Of ComboBox) = New List(Of ComboBox)(pnl_wf.Controls.OfType(Of ComboBox).Reverse) 'New ComboBox() {cbo_step1, cbo_step2, cbo_step3, cbo_step4, cbo_step5} 'pnl_wf.Controls.OfType(Of ComboBox).Reverse.ToArray()
            WFID = Convert.ToInt16(row.Cells(0).Value)
            LastFlow = row.Cells(1).Value
            Dim wfSplit() As String = row.Cells(1).Value.ToString().Split("-")
            Dim x As Integer = 0
            For Each wf As String In wfSplit
                Cbos.Item(x).SelectedValue = wf
                x = x + 1
            Next
        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Try
            Dim WFIDS As List(Of Integer) = New List(Of Integer)()
            For Each row As DataGridViewRow In dgv_wf.SelectedRows
                WFIDS.Add(row.Cells(0).Value)
            Next
            If WFIDS.Count = 0 Then
                MessageBox.Show(Me, "No item selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim ws As String = "" : If WFIDS.Count > 1 Then ws = "s"
                Dim dr As DialogResult = MessageBox.Show(Me, "Delete " & WFIDS.Count & " selected item" & ws, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If dr = DialogResult.OK Then
                    Dim qry As Integer = db.nQuery("DELETE FROM dbo.Workflow WHERE Id IN(" & String.Join(",", WFIDS.ToArray()) & ")")
                    If qry > 0 Then
                        LoadWorkFlow()
                        ResetToDefault()
                        MessageBox.Show(Me, "Delete Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(Me, "Delete failed.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End If
        Catch ex As Exception
            cf.WriteToFile("{0}==>" & ex.ToString(), DebugFilePath)
            MessageBox.Show(Me, "Something went wrong.", "Error Encountered!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Dispose()
    End Sub

#End Region

End Class