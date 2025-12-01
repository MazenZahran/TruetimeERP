Public Class CRMFollowingTask

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.tbDescription.Select()
        InsertToClosingTables(Me.UniqueID.EditValue, Me.tbDescription.Text, Format(Now, "yyyy-MM-dd HH:mm"), GlobalVariables.CurrUserForTasks, TextTaskStatus.EditValue, TextTaskStatus.EditValue)

        UpdateAppointment("Follow", Me.UniqueID.EditValue, tbDescription.Text, Me.SearchAssignedTo.EditValue, edtStartDate.EditValue, Me.SearchCreationUser.EditValue)
        Me.Dispose()
    End Sub

    Private Sub CRMFollowingTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.CRMTaskStatuses' table. You can move, or remove it, as needed.
        Me.CRMTaskStatusesTableAdapter.Fill(Me.TrueAccountingDataSet.CRMTaskStatuses)

    End Sub
End Class