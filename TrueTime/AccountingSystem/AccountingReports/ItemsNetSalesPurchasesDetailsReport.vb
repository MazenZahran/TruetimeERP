Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid

Public Class ItemsNetSalesPurchasesDetailsReport
    Private Sub SalesManReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ItemsGroups' table. You can move, or remove it, as needed.
        Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
        'TODO: This line of code loads data into the 'AccountingDataSet.ItemsCategories' table. You can move, or remove it, as needed.
        Me.ItemsCategoriesTableAdapter.Fill(Me.AccountingDataSet.ItemsCategories)
        'TODO: This line of code loads data into the 'AccountingDataSet.ItemsTradeMark' table. You can move, or remove it, as needed.
        Me.ItemsTradeMarkTableAdapter.Fill(Me.AccountingDataSet.ItemsTradeMark)

        Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
        Me.RepositoryClassification.DataSource = GetItemsClassification()
        Me.KeyPreview = True
        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today
        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        ColGroupName.VisibleIndex = -1
        ColCategoryName.VisibleIndex = -1
        ColTradeMarkName.VisibleIndex = -1



        Dim fieldMenuItemName As New PivotGridField() With {
            .Area = PivotArea.RowArea,
            .AreaIndex = 0,
            .Caption = "الصنف",
            .FieldName = "ItemName",
            .Width = 300
        }
        Dim fieldQuantity As New PivotGridField() With {
                .Area = PivotArea.DataArea,
                .AreaIndex = 0,
                .Caption = "الكمية",
                .FieldName = "TotalEquivalentToMain",
                .Width = 150
            }
        fieldQuantity.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        fieldQuantity.CellFormat.FormatString = "n0"

        Dim fieldAmount As New PivotGridField() With {
                .Area = PivotArea.DataArea,
                .AreaIndex = 0,
                .Caption = "المبلغ",
                .FieldName = "BaseAmount",
                .Width = 150
            }
        fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        fieldAmount.CellFormat.FormatString = "n1"

        Dim fieldCreatedDateTime As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 0,
                .Caption = "التاريخ",
                .FieldName = "DocDate"
            }
        Dim fieldTradeMarkName As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 1,
                .Caption = "العلامة التجارية",
                .FieldName = "TradeMarkName"
            }
        Dim fieldCategoryName As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 2,
                .Caption = "التصنيف",
                .FieldName = "CategoryName"
            }
        Dim fieldGroupName As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 3,
                .Caption = "المجموعة",
                .FieldName = "GroupName"
            }
        Dim fieldRefName As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 4,
                .Caption = "الذمة",
                .FieldName = "RefName"
            }
        Dim fieldTransType As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 5,
                .Caption = "الحركة",
                .FieldName = "TransType"
            }
        Dim fieldCostCenter As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 6,
                .Caption = "مركز التكلفة",
                .FieldName = "CostName"
            }
        Dim fieldSalesMan As New PivotGridField() With {
                .Area = PivotArea.FilterArea,
                .AreaIndex = 6,
                .Caption = "المندوب",
                .FieldName = "SalesPersonName"
            }



        PivotGridControl1.Fields.AddRange(New PivotGridField() {fieldMenuItemName, fieldAmount, fieldQuantity, fieldCreatedDateTime, fieldTradeMarkName, fieldCategoryName, fieldGroupName, fieldRefName, fieldTransType, fieldCostCenter, fieldSalesMan})
        '  PivotGridControl1.Fields()
        '  PivotGridControl1.BestFit()

        PivotGridControl1.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        ' ReShowCustomizationForm()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub
    Private Sub RefreshData()
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroupPivotTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
            Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
            ColBaseAmount.Caption = " <size=-3> " & GetCurrencyCode(GetDefaultCurrency()) & " </size> المبلغ "
            Dim _TradeMark, _ItemGroups, _ItemsCategories As String
            If Not String.IsNullOrEmpty(Me.SearchItemsTradeMark.Text) Then
                _TradeMark = Me.SearchItemsTradeMark.EditValue
            Else
                _TradeMark = "-1"
            End If
            If Not String.IsNullOrEmpty(Me.SearchItemsGroups.Text) Then
                _ItemGroups = Me.SearchItemsGroups.EditValue
            Else
                _ItemGroups = "-1"
            End If
            If Not String.IsNullOrEmpty(Me.SearchItemsCategories.Text) Then
                _ItemsCategories = Me.SearchItemsCategories.EditValue
            Else
                _ItemsCategories = "-1"
            End If

            sqlstring = "  Select   Case When N.id In (1,13) then 'Purchase' When N.id In (2,12) then 'Sales' End As [TransType] ,
                                    Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] End As [BaseAmount]  ,
                                    Case When N.id In (2,1) then [DocAmount] When N.id In (12,13) then -1*[DocAmount] End As [DocAmount]  ,
	                                Case When N.id In (2,1) then J.StockQuantity When N.id In (12,13) then -1*StockQuantity end as StockQuantity ,
	                                [SalesPerson],E.EmployeeName As SalesPersonName ,[StockID],J.ItemName As ItemNameInJournal,I.ItemName,DocNoteByAccount,
	                                [Referance],R.RefName,J.DocDate,N.Name As DocName,U.name as UnitName,J.DocCode,J.DocID,J.DocManualNo,
	                                Case When N.id In (2,1) then StockQuantity*IU.EquivalentToMain When N.id In (12,13) then  -1*StockQuantity*IU.EquivalentToMain End  As TotalEquivalentToMain,
	                                IU.EquivalentToMain,TradeMarkName,CategoryName,GroupName,DocID2,PosNo,DocNotes,Cu.Code as DocCurrency,
                                    Cs.CostName as CostName, CAST(J.BaseCurrAmount / NULLIF(ABS(J.StockQuantity), 0) AS DECIMAL(10,2)) AS PricePerUnitAferDiscount,
                                    StockPrice,IsNull(I.classification,1) as classification,ISNULL(BonusQuantity,0) As BonusQuantity,ISNULL(BonusQuantityByMainUnit,0) AS BonusQuantityByMainUnit
                                From [dbo].[Journal] J
                                left join Items I on I.ItemNo=J.StockID 
                                left Join EmployeesData E on E.EmployeeID=J.SalesPerson
                                left Join Referencess R on R.RefNo=J.Referance 
                                left Join DocNames N on N.id=J.DocName 
                                left join Units U on U.id=J.StockUnit 
                                left Join Items_units IU on IU.item_id=J.StockID and J.StockUnit=IU.unit_id  and Iu.IsUnit=1
                                left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                                left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                                left join ItemsGroups G on G.GroupID=I.GroupID 
                                left Join Currency Cu on Cu.CurrID=J.DocCurrency
                                left join CostCenter Cs on J.DocCostCenter=Cs.CostID 
                            Where I.Type<>3 And J.StockID is not null And J.StockID <> 0   And DocStatus <> 0 And 
                                  J.DocDate between '" & _DateFrom & "' and '" & _DateTo & "' "
            Select Case RadioGroupReportName.EditValue
                Case "Sales"
                    sqlstring += " And DocName In (2,12) "
                Case "Purchases"
                    sqlstring += " And DocName In (1,13)"
                Case "SalesAndPuchases"
                    sqlstring = "  Select   Case When N.id In (1,13) then 'Purchase' When N.id In (2,12) then 'Sales' End As [TransType] ,
                                    Case When N.id In (1,12) then [BaseAmount] When N.id In (2,13) then -1*[BaseAmount] End As [BaseAmount]  ,
	                                Case When N.id In (1,12) then J.StockQuantity When N.id In (2,13) then -1*StockQuantity end as StockQuantity ,
	                                [SalesPerson],E.EmployeeName As SalesPersonName ,[StockID],J.ItemName,
	                                [Referance],R.RefName,J.DocDate,N.Name As DocName,U.name as UnitName,J.DocCode,J.DocID,J.DocManualNo,
	                                Case When N.id In (1,12) then StockQuantity*IU.EquivalentToMain When N.id In (2,13) then  -1*StockQuantity*IU.EquivalentToMain End  As TotalEquivalentToMain,
	                                IU.EquivalentToMain,TradeMarkName,CategoryName,GroupName,DocID2,PosNo,DocNotes
                            From [dbo].[Journal] J
                                left join Items I on I.ItemNo=J.StockID 
                                left Join EmployeesData E on E.EmployeeID=J.SalesPerson
                                left Join Referencess R on R.RefNo=J.Referance 
                                left Join DocNames N on N.id=J.DocName 
                                left join Units U on U.id=J.StockUnit 
                                left Join Items_units IU on IU.item_id=J.StockID and J.StockUnit=IU.unit_id  and Iu.IsUnit=1
                                left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                                left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                                left join ItemsGroups G on G.GroupID=I.GroupID 
                            Where I.Type<>3 And J.StockID is not null And J.StockID <> 0   And DocStatus <> 0 And 
                                  J.DocDate between '" & _DateFrom & "' and '" & _DateTo & "' "
                    sqlstring += " And DocName In (2,12,1,13)"
            End Select
            '  If CheckNetSales.Checked = True Then sqlstring += " And DocName In (2,12,1,13) "
            '  If CheckNetPurchase.Checked = True Then sqlstring += " And DocName In (1,13)"
            If _TradeMark <> "-1" Then sqlstring += " And T.TradeMarkID=" & _TradeMark
            If _ItemGroups <> "-1" Then sqlstring += " And G.GroupID= " & _ItemGroups
            If _ItemsCategories <> "-1" Then sqlstring += " And C.CategoryID=" & _ItemsCategories
            If _ItemsCategories <> "-1" Then sqlstring += " And C.CategoryID=" & _ItemsCategories
            If Me.LookCostCenter.Text <> "" Then
                sqlstring += " And J.DocCostCenter=" & LookCostCenter.EditValue
            End If
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
            PivotGridControl1.DataSource = sql.SQLDS.Tables(0)
            TabbedControlGroup1.SelectedTabPage = LayoutControlTrans
            BandedGridView1.BestFitColumns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub RepositoryItemNo_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemNo.OpenLink
        My.Forms.Items.ItemNo.EditValue = CStr(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub RepositoryRefNo_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryRefNo.OpenLink
        ReferancessAddNew.TextRefNo.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "Referance")
        ReferancessAddNew.ShowDialog()
    End Sub

    Private Sub RepositoryDocID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryDocID.OpenLink
        Dim _DocCode As String
        _DocCode = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocCode")
        OpenDocumentsByDocCode(_DocCode, "Journal", Me.Name)
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs)
        If e.Column.FieldName = "BaseAmount" Or e.Column.FieldName = "TotalEquivalentToMain" Or e.Column.FieldName = "ItemName" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub SearchItemsTradeMark_EditValueChanged(sender As Object, e As EventArgs) Handles SearchItemsTradeMark.EditValueChanged
        If Me.IsHandleCreated Then
            RefreshData()
        End If
    End Sub

    Private Sub SearchItemsCategories_EditValueChanged(sender As Object, e As EventArgs) Handles SearchItemsCategories.EditValueChanged
        If Me.IsHandleCreated Then
            RefreshData()
        End If
    End Sub

    Private Sub SearchItemsGroups_EditValueChanged(sender As Object, e As EventArgs) Handles SearchItemsGroups.EditValueChanged
        If Me.IsHandleCreated Then
            RefreshData()
        End If
    End Sub

    Private Sub CheckShowItemsDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowItemsDetails.CheckedChanged
        If CheckShowItemsDetails.Checked = True Then
            ColGroupName.VisibleIndex = 3
            ColCategoryName.VisibleIndex = 4
            ColTradeMarkName.VisibleIndex = 5
            '   BandedGridView1.OptionsView.ShowGroupPanel = True
        Else
            ColGroupName.VisibleIndex = -1
            ColCategoryName.VisibleIndex = -1
            ColTradeMarkName.VisibleIndex = -1
            '  BandedGridView1.OptionsView.ShowGroupPanel = False
        End If
    End Sub

    Private Sub RadioGroupReportName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroupReportName.SelectedIndexChanged
        If Me.IsHandleCreated Then
            RefreshData()
        End If
    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        PivotGridControl1.OptionsView.ShowRowTotals = False
    End Sub
    Protected Sub TabbedGroup_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                           ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlTrans" Then
            GridControl1.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupPivotTable" Then
            PivotGridControl1.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabChart" Then
            ChartControl1.ShowPrintPreview()
        End If
        If e.Button.Tag = "Copy" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlTrans" Then
            BandedGridView1.OptionsSelection.MultiSelect = True
            BandedGridView1.SelectAll()
            BandedGridView1.CopyToClipboard()
            BandedGridView1.OptionsSelection.MultiSelect = False
        End If

    End Sub

    Private Sub CheckShowTotals_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowTotals.CheckedChanged
        PivotGridControl1.OptionsView.ShowRowTotals = CheckShowTotals.Checked
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabbedControlGroup1_Click(sender As Object, e As EventArgs) Handles TabbedControlGroup1.Click

    End Sub


    Dim _ShowChartControls As Boolean = False
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If _ShowChartControls = True Then
            _ShowChartControls = False
        Else
            _ShowChartControls = True
        End If
        If _ShowChartControls = True Then
            ChartTypeBar1.Visible = True
            ChartAppearanceBar1.Visible = True
            ChartFinancialSeriesBar1.Visible = True
            ChartDesignerBar1.Visible = True
            ChartTemplatesBar1.Visible = True
            ChartPrintExportBar1.Visible = True
            ChartFinancialIndicatorsBar1.Visible = True
            ChartAnnotationsBar1.Visible = True
            ChartFinancialAxisBar1.Visible = True
            ChartAnnotationsBar2.Visible = True
        Else
            ChartTypeBar1.Visible = False
            ChartAppearanceBar1.Visible = False
            ChartFinancialSeriesBar1.Visible = False
            ChartDesignerBar1.Visible = False
            ChartTemplatesBar1.Visible = False
            ChartPrintExportBar1.Visible = False
            ChartFinancialIndicatorsBar1.Visible = False
            ChartAnnotationsBar1.Visible = False
            ChartFinancialAxisBar1.Visible = False
            ChartAnnotationsBar2.Visible = False
        End If
    End Sub
    'Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridView1.PopupMenuShowing
    '    If e.Menu IsNot Nothing AndAlso e.HitInfo.InRow Then
    '        BandedGridView1.FocusedRowHandle = e.HitInfo.RowHandle
    '        PopupMenu1.ShowPopup(GridControl1.PointToScreen(e.Point))
    '        e.Menu = Nothing
    '    End If
    'End Sub

    Private Sub رصيدالصنفحسبالمستودعToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles رصيدالصنفحسبالمستودعToolStripMenuItem.Click
        Dim F3 As New StockBalanceBywarehouse
        With F3
            .CheckSearchByItemNo.Checked = True
            .TextStockID.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            .Text = "رصيد صنف حسب المستودع ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID") & " )"
            .GetBalanceByWareHouse()
            .Show()
            '.RefreshData()
        End With
    End Sub
    Private Sub RepositoryBalance_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryBalance.ButtonClick
        Dim F3 As New StockBalanceBywarehouse
        With F3
            .CheckSearchByItemNo.Checked = True
            .TextStockID.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            .Text = "رصيد صنف حسب المستودع ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID") & " )"
            .GetBalanceByWareHouse()
            .Show()
            '.RefreshData()
        End With
    End Sub
End Class