Public Class Branches
    Private Sub Branches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.AccountingBranches' table. You can move, or remove it, as needed.
        Me.AccountingBranchesTableAdapter.Fill(Me.AccountingDataSet.AccountingBranches)
        'TODO: This line of code loads data into the 'AccountingDataSet.AccountingBranches' table. You can move, or remove it, as needed.


    End Sub

    Private Sub AccountingBranchesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Validate()
        Me.AccountingBranchesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Not Me.Validate() Then Exit Sub
        Me.AccountingBranchesBindingSource.CancelEdit()
        Me.AccountingBranchesBindingSource.AddNew()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Not Me.Validate() Then Exit Sub
        Me.AccountingBranchesBindingSource.CancelEdit()
        Me.AccountingBranchesBindingSource.RemoveCurrent()
    End Sub

End Class