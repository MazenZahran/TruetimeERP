Public Class CRMCloseTask
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        InsertToClosingTables(Me.UniqueID.EditValue, My.Forms.CRMCloseTask.MemoCloseNote.Text,
                              Format(Now, "yyyy-MM-dd HH:mm"), GlobalVariables.CurrUserForTasks,
                              LastTaskStatus.EditValue, CurrentTaskStatus.EditValue)
        UpdateAppointment("Done", UniqueID.EditValue, My.Forms.CRMCloseTask.MemoCloseNote.Text,
                          Me.SearchCreationUser.EditValue, Now, Me.SearchCreationUser.EditValue)
        MsgBox("تم انجاز المهمة")
        Me.Dispose()
        '
    End Sub

    Private Sub CRMCloseTask_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateOfDone.DateTime = Now
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Dispose()
    End Sub
End Class