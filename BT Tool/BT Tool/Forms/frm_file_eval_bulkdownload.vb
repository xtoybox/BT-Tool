Public Class frm_file_eval_bulkdownload
    Private CustomFn As New CustomFunctions()
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frm_file_eval_bulkdownload_Load(sender As Object, e As EventArgs) Handles Me.Load
        CustomFn.FormDrag(Me, Panel1)
    End Sub
End Class