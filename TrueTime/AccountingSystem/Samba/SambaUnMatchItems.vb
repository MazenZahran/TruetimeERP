Public Class SambaUnMatchItems
    Private Sub SambaUnMatchItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RepositoryTTSItems.DataSource = GetItemsFromBarcodesTable(-1)
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _ItemBarcodeOnAccounting As String = GridView1.GetFocusedRowCellValue("financialBarcode")
        Dim _MenuItemId As String = GridView1.GetFocusedRowCellValue("MenuItemId")
        sqlstring = "     update SambaOrdersTemp set Barcode='" & _ItemBarcodeOnAccounting & "' where MenuItemId=" & _MenuItemId & ""
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            MsgBoxShowSuccess("تم")
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
        End If
    End Sub
End Class