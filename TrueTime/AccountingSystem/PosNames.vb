Public Class PosNames
    Private Sub AccountingPOSNamesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AccountingPOSNamesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub PosNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.AccountingPOSNames' table. You can move, or remove it, as needed.
        Me.AccountingPOSNamesTableAdapter.Fill(Me.AccountingDataSet.AccountingPOSNames)
        Me.RepositoryTempAccounting.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        Me.RepositortPosTypes.DataSource = AccountingFunctions.GetPosTypes()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Validate()
        Me.AccountingPOSNamesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Not Me.Validate() Then Exit Sub
        Me.AccountingPOSNamesBindingSource.CancelEdit()
        Me.AccountingPOSNamesBindingSource.AddNew()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Not Me.Validate() Then Exit Sub
        Me.AccountingPOSNamesBindingSource.CancelEdit()
        Me.AccountingPOSNamesBindingSource.RemoveCurrent()
    End Sub

    Private Sub RepositoryTempAccounting_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryTempAccounting.BeforePopup
        Me.RepositoryTempAccounting.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
    End Sub
End Class