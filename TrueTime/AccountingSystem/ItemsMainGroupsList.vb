Public Class ItemsMainGroupsList
    Private Sub ItemsGroupsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ItemsGroupsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)

    End Sub

    Private Sub ItemsMainGroupsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ItemsGroups' table. You can move, or remove it, as needed.

        Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
    End Sub

    Private Sub ItemsGroupsGridControl_Click(sender As Object, e As EventArgs) Handles ItemsGroupsGridControl.Click
        '900 شيكل

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim f As New ItemsMainGroupsAddEdit
        With f
            .TextID.Text = -1
            .Text = " اضافة مجموعة جديدة "
            .TextGroupName.Select()
            If .ShowDialog() <> DialogResult.OK Then
                Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
            End If
        End With
    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Dim _ID As Integer
        Try
            _ID = GridView1.GetFocusedRowCellValue("GroupID")
            Dim f As New ItemsMainGroupsAddEdit
            With f
                .TextID.Text = _ID
                .Text = " تعديل " & .TextGroupName.Text
                If .ShowDialog() <> DialogResult.OK Then
                    Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class