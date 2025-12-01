Imports DevExpress.XtraEditors

Public Class ItemsWithNoTransWithInPeriod
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub BtnRefreshData_Click(sender As Object, e As EventArgs) Handles BtnRefreshData.Click
        GetData()
    End Sub
    Private Sub GetData()
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _dateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim _warehouseID As Integer = LookUpWhereHouse.EditValue
        Dim _StockDebitWhereHouse As Integer
        Dim _StockCreditWhereHouse As Integer
        If _warehouseID = -1 Then
            _StockDebitWhereHouse = 1
            _StockCreditWhereHouse = 9999999
        Else
            _StockDebitWhereHouse = _warehouseID
            _StockCreditWhereHouse = _warehouseID
        End If

        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   Declare @StockDebitWhereHouse int ; Declare @StockCreditWhereHouse int ; 
                        Set @StockDebitWhereHouse=" & _StockDebitWhereHouse & "; Set @StockCreditWhereHouse=" & _StockCreditWhereHouse & " 
                        select isnull(sum(case when    [StockDebitWhereHouse] Between @StockDebitWhereHouse And @StockDebitWhereHouse then JJ.[StockQuantityByMainUnit] end),0)  - isnull(sum(case when    StockCreditWhereHouse  Between @StockCreditWhereHouse And @StockCreditWhereHouse then [StockQuantityByMainUnit] end) ,0) as Balance,
                            II.ItemNo, II.ItemName, II.ItemNo2, MAx(JJ.DocDate) as DocDate, II.LastPurchasePrice
                        from Items II left join Journal JJ on II.ItemNo=JJ.StockID left join Items_units IU on II.ItemNo=IU.item_id
                            where II.type=0 and NOT EXISTS
                        (
                        SELECT ItemNo, I.ItemName
                            FROM Items I
                                left join Journal J on J.StockID=I.ItemNo
                            WHERE I.Type=0  and J.DocDate between '" & _dateFrom & "' and '" & _dateTo & "' and II.ItemNo=J.StockID "
        If SearchDocName.EditValue <> -1 Then
            sqlstring += " And J.DocName=" & SearchDocName.EditValue
        End If
        sqlstring += "      group by  ItemNo,I.ItemName)
                        Group by II.ItemNo,II.ItemName,II.ItemNo2,II.LastPurchasePrice "
        If chkOnlyItemsHasBalances.EditValue = True Then sqlstring += " having isnull(sum(case when    [StockDebitWhereHouse] Between @StockDebitWhereHouse And @StockDebitWhereHouse then JJ.[StockQuantityByMainUnit] end),0)  - isnull(sum(case when    StockCreditWhereHouse  Between @StockCreditWhereHouse And @StockCreditWhereHouse then [StockQuantityByMainUnit] end) ,0) >0 "

        sqlstring += " Order by DocDate desc "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub ItemsWithNoTransWithInPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColItemNo2.Visible = _ShowItemNo2
        LookUpWhereHouse.Properties.DataSource = GetWharehouses(True)
        DateEditFrom.DateTime = Today.AddMonths(-1)
        DateEditTo.DateTime = Today

        Me.DateEditTo.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt

        LookUpWhereHouse.EditValue = 1
        SearchDocName.Properties.DataSource = GetDocNames()
        SearchDocName.EditValue = -1
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub
End Class