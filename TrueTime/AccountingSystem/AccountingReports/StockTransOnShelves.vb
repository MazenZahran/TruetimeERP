Public Class StockTransOnShelves
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "SELECT [DocID],
                           [DocDate],
                           Format(J.[InputDateTime],'yyyy-MM-dd HH:mm') As InputDateTime,
                           D.Name AS DocName,
                           [StockQuantity],
                           w.WarehouseNameAR AS ToWarehouse,
                           ww.WarehouseNameAR AS FromWarehouse,
                           [ReferanceName],
                           I.[ItemName],
                           S.ShelfCode AS ToShelf ,
                           SS.ShelfCode AS FromShelf,
                           J.stockID,
                           I.ItemNo2,
                           J.DocCode,
                           J.DocName As DocNameValue,
                           J.StockBarcode,
                           j.StockDebitShelve,j.StockCreditShelve,'' as ToShelfBalance,'' as FromShelfBalance
                    FROM [dbo].[Journal] J
                    LEFT JOIN DocNames D ON J.DocName=D.id
                    LEFT JOIN Warehouses W ON w.WarehouseID=J.StockDebitWhereHouse
                    LEFT JOIN Warehouses WW ON ww.WarehouseID=J.StockCreditWhereHouse
                    LEFT JOIN FinancialShelves S ON S.ShelfID=J.StockDebitShelve
                    LEFT JOIN FinancialShelves SS ON SS.ShelfID=J.StockCreditShelve
                    Left Join Items I on I.ItemNo = J.StockID
                    WHERE (J.DocName=1
                           OR J.DocName=2
                           OR J.DocName=16
                           Or J.DocName=17
                           Or J.DocName=18 Or  J.DocName=12 Or  J.DocName=13)
                      AND J.StockQuantity IS NOT NULL
                      AND DocStatus > 0
                      AND J.InputDateTime BETWEEN '" & _DateFrom & " 00:00:00.000' AND '" & _DateTo & " 23:59:59.000' Order By DocDate"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub StockTransOnShelves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEditFrom.DateTime = Today.AddDays(-30)
        Me.DateEditTo.DateTime = Today
        If GlobalVariables._ShowItemNo2 = False Then ColItemNo2.Visible = False
    End Sub

    Private Sub RepositoryItemOpenDoc_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemOpenDoc.OpenLink
        OpenDoc()
    End Sub
    Private Sub OpenDoc()
        Try
            If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID")) Or
               IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")) Or
               GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID") Is Nothing Then
                Exit Sub
            End If
            Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
            Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocNameValue"))
            Dim DocCode As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
            Select Case DocName
                Case 1, 2, 3, 4, 5, 12, 13, 16, 17, 18
                    OpenDocumentsByDocCode(DocCode, "Journal", Me.Name)
            End Select
        Finally
            ' CloseProgressPanel(Handle)
        End Try
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim _StockDebitShelve As Integer = 0
        Dim _StockCreditShelve As Integer = 0
        Dim _stockID As Integer
        Dim i As Integer
        With GridView1
            For i = 0 To GridView1.RowCount - 1
                If Not IsDBNull(.GetRowCellValue(i, "StockDebitShelve")) Then _StockDebitShelve = .GetRowCellValue(i, "StockDebitShelve")
                If Not IsDBNull(.GetRowCellValue(i, "StockCreditShelve")) Then _StockCreditShelve = .GetRowCellValue(i, "StockCreditShelve")
                If Not IsDBNull(.GetRowCellValue(i, "stockID")) Then _stockID = .GetRowCellValue(i, "stockID")
                If _StockDebitShelve <> 0 Then .SetRowCellValue(i, "ToShelfBalance", GetQuantityByShelf(_stockID, _StockDebitShelve))
                If _StockCreditShelve <> 0 Then .SetRowCellValue(i, "FromShelfBalance", GetQuantityByShelf(_stockID, _StockCreditShelve))
            Next
        End With

    End Sub
    Private Function GetQuantityByShelf(_StockID As Integer, _ShelfID As Integer) As Decimal
        Dim _result As Decimal
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   Select Sum(Quantity) as Quantity from 
  (select sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & _StockID & " and StockDebitShelve=" & _ShelfID & " And DocStatus<>0
  Union All
  select -1 * sum(StockQuantityByMainUnit) as Quantity from Journal where StockID=" & _StockID & " and StockCreditShelve=" & _ShelfID & " And DocStatus<>0 ) A"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _result = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Quantity"))
        Catch ex As Exception
            _result = 0
        End Try
        Return _result

    End Function

    Private Sub رصيدالصنفحسبالرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles رصيدالصنفحسبالرفToolStripMenuItem.Click
        Dim F3 As New PosSelectShelf
        With F3
            .TextItemNo.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "stockID")
            .Text = "رصيد صنف حسب الرف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .GetDataForPosSelectShelf()
        End With
    End Sub

    Private Sub محتوياتالرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles محتوياتالرفToolStripMenuItem.Click
        If IsDBNull(GridView1.GetFocusedRowCellValue("FromShelf")) Then
            Exit Sub
        End If
        If GridView1.GetFocusedRowCellValue("FromShelf") <> "" Then
            Dim f As New StockBalanceByShelves
            With f
                .TextFromShelv.EditValue = GridView1.GetFocusedRowCellValue("FromShelf")
                .TextToShelf.EditValue = GridView1.GetFocusedRowCellValue("FromShelf")
                .Show()
                .GetShelvesContains()
            End With
        End If
    End Sub

    Private Sub محتوياتالىرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles محتوياتالىرفToolStripMenuItem.Click
        If IsDBNull(GridView1.GetFocusedRowCellValue("ToShelf")) Then
            Exit Sub
        End If
        If GridView1.GetFocusedRowCellValue("ToShelf") <> "" Then
            Dim f As New StockBalanceByShelves
            With f

                .TextFromShelv.EditValue = GridView1.GetFocusedRowCellValue("ToShelf")
                .TextToShelf.EditValue = GridView1.GetFocusedRowCellValue("ToShelf")
                .Show()
                .GetShelvesContains()
            End With
        End If
    End Sub
End Class