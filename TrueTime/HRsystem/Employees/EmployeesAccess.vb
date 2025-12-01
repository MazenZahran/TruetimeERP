Public Class EmployeesAccess


    Private Sub EmployeesAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.EmployeesAccess' table. You can move, or remove it, as needed.
        Me.EmployeesAccessTableAdapter.FillBy(Me.AccountingDataSet.EmployeesAccess, GlobalVariables.CurrUser)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Validate()
        Me.EmployeesAccessBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
    End Sub
End Class