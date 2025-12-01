Public Class Rofoof
    Private Sub Rofoof_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookUpEdit1.Properties.DataSource = GetWharehouses(False)
        LookUpEdit1.EditValue = 1
        GridControl1.DataSource = GetShelves(1)
    End Sub
End Class