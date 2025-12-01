Public Class VocationsSetBeginingList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.VacationsBalancesAddingTableAdapter.Fill(Me.TrueTimeDataSet.VacationsBalancesAdding)
    End Sub


    Private Sub VacationsBalancesAddingBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.VacationsBalancesAddingTableAdapter.Fill(Me.TrueTimeDataSet.VacationsBalancesAdding)
    End Sub

    Private Sub VocationsSetBeginingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.Vocations' table. You can move, or remove it, as needed.
        '   Me.VocationsTableAdapter.Fill(Me.TrueTimeDataSet.Vocations)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VacationsBalancesAdding' table. You can move, or remove it, as needed.
        Me.VacationsBalancesAddingTableAdapter.Fill(Me.TrueTimeDataSet.VacationsBalancesAdding)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        VocationsSetBegining.ShowDialog()
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.Validate()
        Me.VacationsBalancesAddingBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
    End Sub

    Private Sub RepositoryDelete_Click(sender As Object, e As EventArgs) Handles RepositoryDelete.Click
        VacationsBalancesAddingBindingSource.RemoveCurrent()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
End Class