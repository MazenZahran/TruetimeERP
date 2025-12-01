Public Class AttachmentDispaly
    Private Sub PdfFileOpenBarItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PdfFileOpenBarItem1.ItemClick

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        MsgBox("Email")
    End Sub

    Private Sub AttachmentDispaly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
End Class