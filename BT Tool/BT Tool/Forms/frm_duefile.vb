Public Class frm_duefile

    Private CustomFn As New CustomFunctions()

    Private Sub frm_duefile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CustomFn.FormDrag(Me, Panel1)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class