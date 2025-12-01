Public Class JournalForDocument
    Public _DocName As Integer
    Public _DocID As Integer
    Private Sub JournalForDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.ShowPrintPreview()
    End Sub
End Class