Public Class ReferancesListForUpdate
    Private Sub ReferancesListBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ReferancesListForUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ReferencesTypes' table. You can move, or remove it, as needed.
        Me.ReferencesTypesTableAdapter.Fill(Me.AccountingDataSet.ReferencesTypes)
        'TODO: This line of code loads data into the 'AccountingDataSet.RefCities' table. You can move, or remove it, as needed.
        Me.RefCitiesTableAdapter.Fill(Me.AccountingDataSet.RefCities)
        'TODO: This line of code loads data into the 'AccountingDataSet.RefSorts' table. You can move, or remove it, as needed.
        Me.RefSortsTableAdapter.Fill(Me.AccountingDataSet.RefSorts)
        'TODO: This line of code loads data into the 'AccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.
        Me.ReferancesListTableAdapter.Fill(Me.AccountingDataSet.ReferancesList)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Me.Validate()
            Me.ReferancesListBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
            Me.ReferancesListTableAdapter.Fill(Me.AccountingDataSet.ReferancesList)
        Catch ex As Exception
            MsgBox("لم يتم حفظ البيانات")
        End Try

    End Sub
End Class