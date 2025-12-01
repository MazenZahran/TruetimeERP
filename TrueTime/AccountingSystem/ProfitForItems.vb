Public Class ProfitForItems
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub

    Private Sub ProfitForItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today
        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        gridBandAverage.Visible = False
        Me.SearchReferance.Properties.DataSource = GetReferences(-1, -1, -1)

        If GlobalVariables._UseSalesMan = False Then
            LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            SearchSalesPerson.Properties.DataSource = GetEmployeesTable(-1, -1)
        End If
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub
    Private Sub RefreshData()
        If RadioGroup1.EditValue = "last" Then UpdateItemsNetLastPurchasePrice(DateEditTo.DateTime)

        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = "
                        Declare @FromDate datetime
                        Declare @To__Date datetime
                        set @FromDate='" & Format(DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                        set @To__Date='" & Format(DateEditTo.DateTime, "yyyy-MM-dd") & "'
                        Select  A.StockID,B.MainUnitName,QuantitySold,QuantityReturn,QuantitySold-QuantityReturn As Quantity,sales,A.ItemName,A.GroupName,A.TradeMarkName,A.CategoryName,
                                LastPurchasePrice,
                                (QuantitySold-QuantityReturn)*LastPurchasePrice as CostFromLastCost,sales - ((QuantitySold-QuantityReturn)*LastPurchasePrice) as ProfitFromLastCost,
                               Case When Sales > 0 Then (sales - ((QuantitySold-QuantityReturn)*LastPurchasePrice))/sales Else 0 End as MarginFromLastPrice,
                                IsNull(AvergaeCost,0) As AvergaeCost ,(QuantitySold-QuantityReturn)*IsNull(AvergaeCost,0) as CostFromAverage,
                                sales - ((QuantitySold-QuantityReturn)*IsNull(AvergaeCost,0)) as ProfitFromAvergaeCost,
                               Case When sales > 0 Then  (sales - ((QuantitySold-QuantityReturn)*IsNull(AvergaeCost,0)))/sales Else 0 End as MarginAvergaeCost
                        From 
                            (select  StockID,
                            IsNull(Sum( case when DocName=2 then BaseCurrAmount when DocName=12 then -BaseCurrAmount End),0) as sales,
                            IsNull(Sum( case when DocName=2 then StockQuantityByMainUnit end ),0) as QuantitySold,
                            IsNull(Sum( case when DocName=12 then StockQuantityByMainUnit end ),0) as QuantityReturn,
                            I.ItemName,G.GroupName,T.TradeMarkName,C.CategoryName
                            from Journal J
                            left join Items I on I.ItemNo=J.StockID 
                            left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                            left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                            left join ItemsGroups G on G.GroupID=I.GroupID "
            SqlString += "  where   DocStatus<>0 and  (DocName=2 or DocName=12) and StockID<>'0' and 
                            StockID is not null and DocDate between @FromDate and @To__Date And I.Type<>3 "
            If Not String.IsNullOrEmpty(Me.SearchReferance.Text) Then
                SqlString += " and J.Referance=" & Me.SearchReferance.EditValue
            End If
            If GlobalVariables._UseSalesMan = True Then
                If Not String.IsNullOrEmpty(Me.SearchSalesPerson.Text) Then
                    SqlString += " and J.SalesPerson=" & Me.SearchSalesPerson.EditValue
                End If
            End If
            SqlString += "  Group by StockID,I.ItemName,G.GroupName,T.TradeMarkName,C.CategoryName having sum(BaseCurrAmount)>0 ) A
                            left join
                                ( select  ItemNo,U.name as MainUnitName, isnull(LastNetPurchasePrice,0) as LastPurchasePrice from Items I left join Items_units IU on I.ItemNo=IU.item_id left join Units U on U.id=IU.unit_id where IU.main_unit=1 ) B 
                            on A.StockID=B.ItemNo
                            left join
                                ( select StockID,
                                IsNull(sum(BaseCurrAmount)/sum(StockQuantityByMainUnit),0) as AvergaeCost from Journal 
                                where  DocStatus<>0 and ( DocName=1 or DocName=17 or DocName=19 ) and StockID<>'0' and  StockID is not null
                                group by StockID having sum(StockQuantityByMainUnit)>0 ) C
                            on A.StockID=C.StockID "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If RadioGroup1.EditValue = "last" Then UpdateItemsNetLastPurchasePrice(Today())
    End Sub

    Private Sub CheckShowItemsDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowItemsDetails.CheckedChanged
        If CheckShowItemsDetails.Checked = True Then
            ColGroupName.Visible = True
            ColCategoryName.Visible = True
            ColTradeMarkName.Visible = True
            '   BandedGridView1.OptionsView.ShowGroupPanel = True
        Else
            ColGroupName.Visible = False
            ColCategoryName.Visible = False
            ColTradeMarkName.Visible = False
            '  BandedGridView1.OptionsView.ShowGroupPanel = False
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "last"
                gridBandAverage.Visible = False
                gridBandLast.Visible = True
            Case "average"
                gridBandAverage.Visible = True
                gridBandLast.Visible = False
        End Select
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        My.Forms.Items.ItemNo.EditValue = CStr(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            .Warehouses.Text = 1
            .Text = " حركة صنف ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName") & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridView1.PopupMenuShowing
        If e.Menu IsNot Nothing AndAlso e.HitInfo.InRow Then
            BandedGridView1.FocusedRowHandle = e.HitInfo.RowHandle
            PopupMenu1.ShowPopup(GridControl1.PointToScreen(e.Point))
            e.Menu = Nothing
        End If
    End Sub
End Class