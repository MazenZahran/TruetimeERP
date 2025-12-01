Public Class AccountingJardDocumentsList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New AccountingJardDocument(True, SrchSession.EditValue, CreateRandomCode(), -1)
        F.ShowDialog()
    End Sub

    Private Sub AccountingJardDocumentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SrchSession.Properties.DataSource = AccountingFunctions.GetSessonsTable(False)
    End Sub
End Class