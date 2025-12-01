Public Class DocumentLogs
    Public _DocCode As String
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrEmpty(_DocCode) Then
            GridControl1.DataSource = GetDocumentsLogs("--1", -1)
        Else
            GridControl1.DataSource = GetDocumentsLogs(_DocCode, -1)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub RepositoryDocNo_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryDocNo.OpenLink
        Dim _DocCode, _LogDateTime As String
        _DocCode = GridView1.GetFocusedRowCellValue("DocCode")
        _LogDateTime = GridView1.GetFocusedRowCellValue("LogDateTime")
        OpenDocumentsByDocCode(_DocCode, "JournalBeforeUpdate", "", _LogDateTime)
    End Sub

    Private Sub DocumentLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class