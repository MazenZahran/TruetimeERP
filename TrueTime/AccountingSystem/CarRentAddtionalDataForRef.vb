Public Class CarRentAddtionalDataForRef
    Private Sub ReferencessBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ReferencessBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub CarRentAddtionalDataForRef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Referencess' table. You can move, or remove it, as needed.
        Me.ReferencessTableAdapter.Fill(Me.AccountingDataSet.Referencess)

    End Sub
End Class