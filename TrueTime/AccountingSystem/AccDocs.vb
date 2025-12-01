Public Class AccDocs
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is AccDocs Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New AccDocs()
        '    child.MdiParent = Main
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
        AccStockMove.DocStatus.EditValue = 1
        AccStockMove.DocName.EditValue = 1
        AccStockMove.ShowDialog()
    End Sub
End Class