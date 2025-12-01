Public Class VoucherProfit
    Public _VoucherID As Integer
    Private Sub VoucherProfit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioGroup1.EditValue = "PurchasePriceOnVoucherDate"
        GetVoucherDetails()
    End Sub
    Private Sub GetVoucherDetails()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = ""
        Select Case RadioGroup1.EditValue
            Case "PurchasePriceOnVoucherDate"
                sqlstring = " SELECT StockID,StockBarcode,ItemName,BaseCurrAmount/StockQuantityByMainUnit as MainUnitPrice,
                                U.name as StockUnit,LastPurchasePrice as UnitCost,(BaseCurrAmount-LastPurchasePrice*StockQuantityByMainUnit) as Profit,StockQuantityByMainUnit,
                                case when LastPurchasePrice > 0 then ((BaseCurrAmount-LastPurchasePrice*StockQuantityByMainUnit)/(LastPurchasePrice*StockQuantityByMainUnit)) else 1 end as MarginProfit
                                FROM [dbo].[Journal] J
                                Left join Units U on J.StockUnit=U.id 
                                where   StockID<>0 and StockID is not null and DocName=2 and DocID=" & _VoucherID & "
                                order by TarteebID "
            Case "LastPurchasedPrice"
                sqlstring = " SELECT StockID,StockBarcode,J.ItemName,BaseCurrAmount/StockQuantityByMainUnit as MainUnitPrice,
                                U.name as StockUnit,IsNull(I.LastPurchasePrice,0) as UnitCost,(BaseCurrAmount-IsNull(I.LastPurchasePrice,0)*StockQuantityByMainUnit) as Profit,StockQuantityByMainUnit,
                               case when I.LastPurchasePrice > 0 then ((BaseCurrAmount-I.LastPurchasePrice*StockQuantityByMainUnit)/(I.LastPurchasePrice*StockQuantityByMainUnit)) else 1 end as MarginProfit
                                FROM [dbo].[Journal] J
                                Left join Units U on J.StockUnit=U.id 
                                left join Items I on J.StockID=I.ItemNo 
                                where DocStatus<>0 and  StockID<>0 and StockID is not null and DocName=2 and DocID=" & _VoucherID & " 
                                order by TarteebID  "
            Case "AveragePurchasePrice"
                sqlstring = " select A.StockID,A.StockBarcode,A.ItemName,A.MainUnitPrice,A.StockUnit,
                                     IsNull(B.AvergaeCost,0) as UnitCost ,(A.BaseCurrAmount-IsNull(B.AvergaeCost,0)*StockQuantityByMainUnit) as Profit,
                                     StockQuantityByMainUnit ,
                                    case when B.AvergaeCost > 0 then  ((A.BaseCurrAmount-B.AvergaeCost*StockQuantityByMainUnit)/(B.AvergaeCost*StockQuantityByMainUnit)) else 1 end as MarginProfit
                              from 
                              (SELECT StockID,StockBarcode,J.ItemName,BaseCurrAmount/StockQuantityByMainUnit as MainUnitPrice,BaseCurrAmount,
                                      U.name as StockUnit,StockQuantityByMainUnit
                                      FROM [dbo].[Journal] J
                                      Left join Units U on J.StockUnit=U.id 
                                      left join Items I on J.StockID=I.ItemNo 
                                      where DocStatus<>0 and  StockID<>0 and StockID is not null and DocName=2 and DocID=" & _VoucherID & " ) A
                               left join 
                                      (select StockID,
                                      IsNull(sum(BaseAmount)/sum(StockQuantityByMainUnit),0) as AvergaeCost from Journal 
                                      where  DocStatus<>0 and ( DocName=1 ) and StockID<>'0' and  StockID is not null 
                                      group by StockID having sum(StockQuantityByMainUnit)>0 ) B
	                            on A.StockID=B.StockID  "
        End Select

        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try


    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        GetVoucherDetails()
    End Sub

    Private Sub تفاصيلالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تفاصيلالصنفToolStripMenuItem.Click
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub حركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .Warehouses.Text = 1
            .Text = " حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class