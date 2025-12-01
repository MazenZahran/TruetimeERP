Imports DevExpress.Utils
Imports DevExpress.Xpf.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class StockBalancesReport

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub RefreshData()
        Dim Sql As New SQLControl
        Dim SqlString As String = "-1"
        Dim _DocDate As String = Format(DateDocDate.EditValue, "yyyy-MM-dd")
        If String.IsNullOrEmpty(_DocDate) Then
            XtraMessageBox.Show("يرجى تحديد التاريخ")
            Exit Sub
        End If

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        My.Forms.Main.ItemElapseTime.Caption = (0)
        start_time = Now
        Dim focusedRow As Integer = BandedGridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Dim _WithAmount As Boolean
        _WithAmount = False
        SqlString = "     Declare @WahreHouseFrom Int;  Declare @WahreHouseTo Int; "
        If Me.Warehouses.EditValue <> -1 Then
            SqlString += "   Set @WahreHouseFrom=" & Me.Warehouses.EditValue
            SqlString += "   Set @WahreHouseTo=" & Me.Warehouses.EditValue
        Else
            SqlString += "   Set @WahreHouseFrom=1 "
            SqlString += "   Set @WahreHouseTo=9999999 "
        End If

        If CheckShowAllItems.Checked = True Then
            SqlString += "     Select AA.Barcode, AA.ItemNo As StockID ,AA.ItemName,AA.ItemNo2,AA.ItemNo3,AA.ItemNo4,AA.GroupName,AA.TradeMarkName,AA.CategoryName,IsNull(BB.QuantityIn,0) as QuantityIn ,IsNull(BB.QuantityOut,0) as QuantityOut ,IsNull(BB.[balance],0) as balance,IsNull(BB.LastPurchasePrice,0) as LastPurchasePrice ,BB.LastPurchaseDate as LastPurchaseDate ,IsNull(BB.ReOrderQuantityPercentage,0) as ReOrderQuantityPercentage,IsNull(BB.ItemCostAmount,0) as ItemCostAmount,AA.Price1,IsNull(BB.ItemPriceAmount,0) as ItemPriceAmount ,IsNull(BB.OrderQuantity,0) as OrderQuantity,IsNull(MaxQuantity,0) as MaxQuantity , Deficiency ,IsNull(BB.OrderedQuantity,0) as OrderedQuantity,ItemPriceInDocCurrency,ItemLastPurchaseCurrency, IsNull(ItemPriceInDocCurrency,0) * IsNull(BB.[balance],0) as  ItemAmountInDocCurrency,InternalOrderd,case when (IsNull(BB.QuantityIn,0) = 0 And IsNull(BB.QuantityOut,0) = 0)  then 'NoTrans' else 'YesTrans' end as HasTrans  from 
                               ( SELECT IU.item_unit_bar_code as Barcode,ItemNo,ItemName As ItemName ,ItemNo2,ItemNo3,ItemNo4,GroupName,TradeMarkName,CategoryName,IsNull(I.ReOrderQuantity,0) as ReOrderQuantity,IU.Price1 from items I
                                                                          left join Items_units IU on IU.item_id=I.ItemNo 
                                                                          left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                                                                          left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                                                                          left join ItemsGroups G on G.GroupID=I.GroupID 
										                                  where IU.main_unit=1
                                ) AA
                                left Join 
                                ( "
        End If

        Try
            SqlString += "        Select A.Barcode,A.StockID,ItemName,A.ItemNo2,A.ItemNo3,A.ItemNo4,GroupName,TradeMarkName,CategoryName,QuantityIn,QuantityOut,[balance],IsNull(LastPurchasePrice,0) As LastPurchasePrice,LastPurchaseDate,
                                         ReOrderQuantity,MaxQuantity,case when balance > 0 then 100*(balance-ReOrderQuantity)/balance end as ReOrderQuantityPercentage,
                                         IsNull(balance * LastPurchasePrice,0) As ItemCostAmount,Price1,Price1*balance as ItemPriceAmount,
                                         Case When IsNull(MaxQuantity,0) > 0 Then IsNull(MaxQuantity,0) - IsNull(balance,0) Else IsNull(balance,0)  End As OrderQuantity,ItemPriceInDocCurrency,ItemLastPurchaseCurrency, 
                                         IsNull(ItemPriceInDocCurrency,0) * IsNull([balance],0) as  ItemAmountInDocCurrency, Case when IsNull(ReOrderQuantity,0) > IsNull(balance,0) then  IsNull(ReOrderQuantity,0)-IsNull(balance,0) else 0 end As Deficiency,
                                         IsNull(OrderedQuantity,0) as OrderedQuantity,IsNull(OrderID,0) as OrderID,0 as InternalOrderd  From
                                      (
                                          SELECT StockID,I.ItemName As ItemName ,I.ItemNo2,I.ItemNo3,I.ItemNo4,GroupName,TradeMarkName,CategoryName,IsNull(I.ReOrderQuantity,0) as ReOrderQuantity,
                                          isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0)  as QuantityIn,
                                          isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as QuantityOut,
                                          isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as balance,
                                          IsNull(IU.Price1,0) as  Price1,IsNull(IU.item_unit_bar_code,0) as  Barcode,
                                          IsNull(MaxQuantity,0) As MaxQuantity,O.Quantity as OrderedQuantity,O.ID as OrderID
                                          FROM [Journal] J
                                          left join Items I on I.ItemNo=J.StockID 
                                          left join Items_units IU on IU.item_id=I.ItemNo 
                                          left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                                          left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                                          left join ItemsGroups G on G.GroupID=I.GroupID 
                                          left join OrderProcessing O on O.ItemNo=J.StockID and O.Orderstatus=0 and [OrderByUser]=" & GlobalVariables.CurrUser & "
                                          where  DocDate <= '" & _DocDate & "' And IU.main_unit=1 and DocStatus<>0 and StockID > '0' 
                                                And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )"
            If Not String.IsNullOrEmpty(SearchItemsGroups.Text) Then SqlString += " And I.GroupID='" & SearchItemsGroups.EditValue & "'"
            If Not String.IsNullOrEmpty(SearchItemsCategories.Text) Then SqlString += " And I.CategoryID='" & SearchItemsCategories.EditValue & "'"
            If Not String.IsNullOrEmpty(SearchItemsTradeMark.Text) Then SqlString += " And I.TradeMarkID='" & SearchItemsTradeMark.EditValue & "'"
            SqlString += " group by item_unit_bar_code,StockID,I.ItemName,I.ItemNo2,I.ItemNo3,I.ItemNo4,Price1,G.GroupName,T.TradeMarkName,C.CategoryName,I.ReOrderQuantity,I.MaxQuantity,O.Quantity,O.ID
                                       ) A "
            If CheckValuation.Checked = True Then
                SqlString += " left join
                                        (
                                         	SELECT StockID,
                                            Case when [StockQuantityByMainUnit] <> 0 then [BaseCurrAmount]/ABS([StockQuantityByMainUnit]) else 0 end as LastPurchasePrice,
                                            DocDate as LastPurchaseDate,
                                            Case when StockQuantityByMainUnit > 0 then  DocAmount/StockQuantityByMainUnit else 0 end as ItemPriceInDocCurrency ,
                                            DocCurrency as ItemLastPurchaseCurrency
                                            FROM Journal S 
                                            WHERE DocDate=(SELECT Top(1) MAX(DocDate) FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <='" & _DocDate & "' and StockID = S.StockID   ) "
                ' SqlString += " and S.ID=(SELECT Max(ID) FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <='" & _DocDate & "' and StockID = S.StockID  ) "
                SqlString += " and S.ID=(SELECT Top(1) ID FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <='" & _DocDate & "' and StockID = S.StockID order by DocDate desc  ) "
                SqlString += "         and DocStatus <> 0 and DocName in (1,17,16,19) and DocDate <='" & _DocDate & "'  
                                         ) B
                                        on A.StockID=B.StockID "
                gridBandValuation.Visible = True
            Else
                SqlString += " left join
                                        (
                                         	SELECT 0 as StockID,  0 as LastPurchasePrice,'1900-01-01' as LastPurchaseDate ,0 as ItemPriceInDocCurrency , 0 as ItemLastPurchaseCurrency, 0 as ItemAmountInDocCurrency
                                         ) B
                                        on A.StockID=B.StockID "
                gridBandValuation.Visible = False
            End If

            If CheckShowZeroBalance.Checked = False Then
                SqlString += " where Balance<>0"
            End If

            If CheckShowAllItems.Checked = True Then
                SqlString += " ) BB on AA.ItemNo=BB.StockID "
            End If

            If SqlString <> "-1" Then Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            BandedGridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            CloseProgressPanel(handle)
        End Try

        gridBandBalances.Width = 720
        Colbalance.Width = 100
        ColOrderQuantity.Width = 100
        ColOrderedQuantity.Width = 100
        ColMaxQuantity.Width = 100
        ColDeficiency.Width = 100
        ColOrder.Width = 60
        ColInternalOrder.Width = 200

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))


    End Sub

    Private Sub StockBalancesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSettings()
        Warehouses.Properties.DataSource = GetWharehouses(True)
        Warehouses.EditValue = GetDefaultWharehouse()
        Me.SearchItemsCategories.Properties.DataSource = GetItemsCategories()
        Me.SearchItemsTradeMark.Properties.DataSource = GetItemsTradeMark()
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
        DateDocDate.DateTime = Now
        'ColGroupName.Visible = False
        'ColCategoryName.Visible = False
        'ColTradeMarkName.Visible = False
        'ColOrderQuantity.Visible = False
        'ColReOrderQuantity.Visible = False
        'ColOrder.Visible = False
        'ColLastPurchaseDate.Visible = False
        'ColItemNo4.Visible = False
        'ColItemNo3.Visible = False
        'ColItemAmountInDocCurrency.Visible = False
        'ColItemPriceInDocCurrency.Visible = False
        'ColItemLastPurchaseCurrency.Visible = False
        gridBandOrders.Visible = False
        gridBandSales.Visible = False
        gridBandCurrency.Visible = False
        gridBandValuation.Visible = False
        gridBandItemsDetails.Visible = False
        gridInternalOrder.Visible = False
        Colin.Visible = False
        Colout.Visible = False
        Me.KeyPreview = True
        Me.RepositoryItemCurrency.DataSource = GetCurrency()
        'DocCode.Text = CreateRandomCode()
        CeateOrderTable()
        If GlobalVariables._WareHouseUseShelf = False Then
            toolStripMenuItemBalanceOnShelv.Visible = False
            LayoutControlInternalShelfOrders.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub
    Private Sub GetSettings()
        Dim _ShowItemNo2 As Boolean = False
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2'")
            _ShowItemNo2 = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If _ShowItemNo2 = True Then
                ColItemName2.Visible = True
                ColItemNo4.Visible = True
                ColItemNo3.Visible = True
            Else
                ColItemName2.Visible = False
                ColItemNo4.Visible = False
                ColItemNo3.Visible = False
            End If


            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Shalash'")
            GlobalVariables._Shalash = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))

            If GlobalVariables._UserAccessType = 94 Then
                ' مستخدم أمين مستودع
                LayoutControlItemShowCurrencyDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItemEvaluation.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub CheckShowItemsDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowItemsDetails.CheckedChanged
        If CheckShowItemsDetails.Checked = True Then
            gridBandItemsDetails.Visible = True
            BandedGridColumn2.Visible = True
            ' ColCategoryName.Visible = True
            ' ColTradeMarkName.Visible = True
            '   BandedBandedGridView1.OptionsView.ShowGroupPanel = True
        Else
            gridBandItemsDetails.Visible = False
            BandedGridColumn2.Visible = False
            'ColGroupName.Visible = False
            'ColCategoryName.Visible = False
            'ColTradeMarkName.Visible = False
            '  BandedBandedGridView1.OptionsView.ShowGroupPanel = False
        End If
    End Sub

    Private Sub حركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            '.GridColumn4.Visible = False
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            '.TextPurchaseOrSale.Text = 1
            '.TextItemName.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName")
            .Text = "حركة صنف ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .RefreshData()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub رصيدالصنفحسبالرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolStripMenuItemBalanceOnShelv.Click
        Dim F3 As New PosSelectShelf
        With F3
            .TextItemBarcode.Text = ""
            .TextItemNo.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            .Text = "رصيد صنف حسب الرف ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .GetDataForPosSelectShelf()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
            '.RefreshData()
        End With
    End Sub

    Private Sub رصيدالصنفحسبالمستودعToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles رصيدالصنفحسبالمستودعToolStripMenuItem.Click
        Dim F3 As New StockBalanceBywarehouse
        With F3
            .CheckSearchByItemNo.Checked = True
            .TextStockID.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID")
            .Text = "رصيد صنف حسب المستودع ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName") & " )"
            .GetBalanceByWareHouse()
            .Show()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
            '.RefreshData()
        End With
    End Sub

    Private Sub RepositoryItemHyperLinkEditItemNo_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEditItemNo.OpenLink
        My.Forms.Items.ItemNo.EditValue = CStr(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub
    Private Sub BandedGridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs)
        If e.Column.FieldName = "ItemName" Or e.Column.FieldName = "balance" Or
            e.Column.FieldName = "ItemCostAmount" Or e.Column.FieldName = "ItemPriceAmount" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
            'e.Appearance.BackColor = Color.FromArgb(1, 55, 99)
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditReOrder.CheckedChanged
        If Me.CheckEditReOrder.Checked = True Then
            LayoutControlOrderPreview.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            gridBandOrders.Visible = True
            GetItemsCountInOrdersTable()
        Else
            LayoutControlOrderPreview.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            gridBandOrders.Visible = False
        End If
    End Sub

    Public Sub GetItemsCountInOrdersTable()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(ID) as count from OrderProcessing where Orderstatus=0 "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Dim _htmltext As String = "<color=255, 0, 0>" & sql.SQLDS.Tables(0).Rows(0).Item("count") & "</color>"
            'BtnPrepareOrder.Text = " معاينة الطلبية " & " " & sql.SQLDS.Tables(0).Rows(0).Item("count")
            BtnPrepareOrder.Text = " صنف " & _htmltext & " تجهيز الطلبية "
        End If

    End Sub


    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles BtnPrepareOrder.Click
        'If GlobalVariables._OrderTable.Rows.Count = 0 Then
        '    MsgBox("خطأ: لم يتم طلب أصناف")
        '    Exit Sub
        'End If
        'Dim ctr As Integer = 0
        'Dim child As Form = Nothing
        'Dim f As AccStockMove = New AccStockMove()
        'f.DocName.EditValue = 1
        'ctr = ctr + 1
        'f.MdiParent = My.Forms.Main
        'With f
        '    .Show()
        '    .DocName.EditValue = 10
        '    .DocName.Text = 10
        '    .DocStatus.Text = -1
        '    .Text = "طلبية مشتريات"
        '    '.LayoutControlItem26.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        '    .SearchOrderStatus.EditValue = 0
        '    .SearchOrderStatus.ReadOnly = True
        '    .LoadDefault()
        '    .DocID.EditValue = GetDocNo(10)
        '    .JournalGridControl.DataSource = GlobalVariables._OrderTable

        'End With
        Dim f As New OrderPreview
        With f
            .WhereHouse.EditValue = Me.Warehouses.EditValue
            If .ShowDialog <> DialogResult.OK Then

            End If
        End With
        'Warehouses
        'My.Forms.OrderPreview.ShowDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SetItemsBalancesToZero()
    End Sub
    Private Sub SetItemsBalancesToZero()

        If XtraMessageBox.Show("سيتم عمل سندات ادخال واخراج لتسوية المخزون ، هل تريد الاستمرار؟", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If
        Dim _DocNote As String = " "

        'RefreshData()
        Dim _Date As String = Format(Me.DateDocDate.DateTime, "yyyy-MM-dd")
        _DocNote = " Stock Adjustment (" & _Date & ")"
        Dim sql As New SQLControl
        Dim sqlstringIn, sqlstringOut As String
        sqlstringIn = " --17 سند ادخال بضاعة
                        Declare @WahreHouse Int;Set @WahreHouse=1;
                        Declare @DocDate date ; Set @DocDate='" & _Date & "'
                        Declare @InputDateTime datetime; Set @InputDateTime = GETDATE()
                        Declare @DocCode varchar(50) ; Set @DocCode=(select Right(NEWID(),15) )
                        Declare @DocID int; Set @DocID=" & GetDocNo(17, False) & "

                     Insert Into Journal 
                         (
                         DocID,DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,
			             DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,
					     InputUser,DeviceName,InputDateTime,DocNotes,
					     StockID,StockUnit,StockQuantity,StockQuantityByMainUnit,StockPrice,StockDiscount,
					     StockDebitWhereHouse,Referance,ReferanceName,ItemName,DocCode,StockBarcode,LastDocCode,
					     LastDataName,VoucherDiscount,ItemVAT,StockDebitShelve,StockCreditShelve,DocNoteByAccount,
					     Color,Measure,SalesPerson,ItemNo2,OrderID
                         ) 
			         Select  @DocID,@DocDate,17,1,1,'4020000000','0',1,
				             1,0,1,0,0,'',
			                 1,'Device' As 'Device',@InputDateTime,'" & _DocNote & "',
			                 A.StockID,UnitID,-1 * [balance],-1 * [balance],0,0, 
					         @WahreHouse,'','',ItemName,@DocCode,'','',
					         '',0,0,0,0,'',
					         0,0,'','',0
				   	From
                         (
                        SELECT StockID,I.ItemName As ItemName , Iu.unit_id as UnitID,
                               isnull(sum(case when [StockDebitWhereHouse] Between @WahreHouse And @WahreHouse then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouse And @WahreHouse then [StockQuantityByMainUnit] end) ,0) as balance
                        FROM [Journal] J
                        left join Items I on I.ItemNo=J.StockID 
                        left join Items_units IU on IU.item_id=I.ItemNo 
			            left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                        left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                        left join ItemsGroups G on G.GroupID=I.GroupID 
                     Where DocDate <= @DocDate And IU.main_unit=1 and DocStatus<>0 and StockID > '0' and IU.main_unit=1
                           And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouse And @WahreHouse or StockCreditWhereHouse Between @WahreHouse And @WahreHouse 
                         ) "
        If Not String.IsNullOrEmpty(SearchItemsGroups.Text) Then sqlstringIn += " And I.GroupID='" & SearchItemsGroups.EditValue & "'"
        If Not String.IsNullOrEmpty(SearchItemsCategories.Text) Then sqlstringIn += " And I.CategoryID='" & SearchItemsCategories.EditValue & "'"
        If Not String.IsNullOrEmpty(SearchItemsTradeMark.Text) Then sqlstringIn += " And I.TradeMarkID='" & SearchItemsTradeMark.EditValue & "'"
        sqlstringIn += " Group by StockID,I.ItemName,Iu.unit_id
                       ) A
                       where Balance < 0

                      Insert into Journal (DocID, DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,
				            DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,
					        InputUser,DeviceName,InputDateTime,DocNotes,StockID,Referance,ReferanceName,
					        DocCode,SalesPerson,OrderID)
                            Values (@DocID, @DocDate,17,1,1,'0','4020000000',1,1,0,1,0,0,'',1, 'Device',@InputDateTime,'" & _DocNote & "',0,'','',@DocCode,'',0) "
        sql.SqlTrueAccountingRunQuery(sqlstringIn)


        sqlstringOut = " --18 سند اخراج بضاعة
                        Declare @WahreHouse Int;Set @WahreHouse=1;
                        Declare @DocDate date ; Set @DocDate='" & _Date & "'
                        Declare @InputDateTime datetime; Set @InputDateTime = GETDATE()
                        Declare @DocCode varchar(50) ; Set @DocCode=(select Right(NEWID(),15) )
                        Declare @DocID int; Set @DocID=" & GetDocNo(18, False) & "
                        Insert Into Journal (DocID,DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,
			                     DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,
					             InputUser,DeviceName,InputDateTime,DocNotes,
					             StockID,StockUnit,StockQuantity,StockQuantityByMainUnit,StockPrice,StockDiscount,
					             StockcreditWhereHouse,Referance,ReferanceName,ItemName,DocCode,StockBarcode,LastDocCode,
					             LastDataName,VoucherDiscount,ItemVAT,StockDebitShelve,StockCreditShelve,DocNoteByAccount,
					             Color,Measure,SalesPerson,ItemNo2,OrderID) 
			            Select  @DocID,@DocDate,18,1,1,'0','4020000000',1,
				                1,0,1,0,0,'',
			                    1,'Device' As 'Device',@InputDateTime,'" & _DocNote & "',
			                    A.StockID,UnitID, [balance], [balance],0,0, 
					            @WahreHouse,'','',ItemName,@DocCode,'','',
					            '',0,0,0,0,'',
					            0,0,'','',0
				    	From
                         (
                         SELECT StockID,I.ItemName As ItemName , Iu.unit_id as UnitID,
                                isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouse And @WahreHouse then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouse And @WahreHouse then [StockQuantityByMainUnit] end) ,0) as balance
                         FROM [Journal] J
                                left join Items I on I.ItemNo=J.StockID 
                                left join Items_units IU on IU.item_id=I.ItemNo 
			                    left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                                left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                                left join ItemsGroups G on G.GroupID=I.GroupID 
                         where DocDate <= @DocDate And IU.main_unit=1 and DocStatus<>0 and StockID > '0' and IU.main_unit=1
                                And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouse And @WahreHouse or StockCreditWhereHouse Between @WahreHouse And @WahreHouse ) "
        If Not String.IsNullOrEmpty(SearchItemsGroups.Text) Then sqlstringOut += " And I.GroupID='" & SearchItemsGroups.EditValue & "'"
        If Not String.IsNullOrEmpty(SearchItemsCategories.Text) Then sqlstringOut += " And I.CategoryID='" & SearchItemsCategories.EditValue & "'"
        If Not String.IsNullOrEmpty(SearchItemsTradeMark.Text) Then sqlstringOut += " And I.TradeMarkID='" & SearchItemsTradeMark.EditValue & "'"
        sqlstringOut += "	group by StockID,I.ItemName,Iu.unit_id
        ) A
        where Balance > 0

Insert into Journal (DocID, DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,
				     DocCurrency,DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,
					 InputUser,DeviceName,InputDateTime,DocNotes,StockID,Referance,ReferanceName,
					 DocCode,SalesPerson,OrderID)
Values (@DocID, @DocDate,18,1,1,'4020000000','0',1,1,0,1,0,0,'',1, 'Device',@InputDateTime,'" & _DocNote & "',0,'','',@DocCode,'',0) "
        sql.SqlTrueAccountingRunQuery(sqlstringOut)
    End Sub

    Private Sub CheckShowCurrencyDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowCurrencyDetails.CheckedChanged
        gridBandCurrency.Visible = CheckShowCurrencyDetails.CheckState
    End Sub

    Private Sub CheckAutoFit_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoFit.CheckedChanged
        If CheckAutoFit.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
            ColItemAmountInDocCurrency.Width = 75
            ColItemPriceInDocCurrency.Visible = 75
            ColItemLastPurchaseCurrency.Visible = 75
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
            ColItemAmountInDocCurrency.Width = 150
            ColItemPriceInDocCurrency.Visible = 150
            ColItemLastPurchaseCurrency.Visible = 75
        End If
        BandedGridView1.BestFitColumns()
    End Sub

    Private Sub CheckValuation_CheckedChanged(sender As Object, e As EventArgs) Handles CheckValuation.CheckedChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub RepositoryItemOrder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemOrder.ButtonClick


    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawFooterCell
        If e.Column.FieldName = "ItemName" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
            'e.Appearance.BackColor = Color.FromArgb(1, 55, 99)
        End If
        If e.Column.FieldName = "balance" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
            'e.Appearance.BackColor = Color.FromArgb(1, 55, 99)
        End If
        If e.Column.FieldName = "ItemCostAmount" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub RepositoryOrderedQuantity_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOrderedQuantity.ButtonClick
        Dim ItemNo As Integer
        Dim ItemName As String
        Dim Quantity As Decimal
        GlobalVariables._OrderedQuantity = 0
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("StockID")) Then Exit Sub
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemName")) Then Exit Sub
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("balance")) Then Exit Sub
        ItemNo = BandedGridView1.GetFocusedRowCellValue("StockID")
        ItemName = BandedGridView1.GetFocusedRowCellValue("ItemName")
        Quantity = BandedGridView1.GetFocusedRowCellValue("balance")
        'If Quantity <= 0 Then
        '    Quantity = 1
        'End If

        If GlobalVariables._Shalash = False Then
            Dim F As New InternalOrderItemQuantityFromItemBalance
            With F
                .TextCurrentBalance.EditValue = Quantity
                .TextItemName.Text = ItemName
                .TextItemNo.Text = ItemNo
                '.ComboBoxEditType.EditValue = "0"
                If .ShowDialog() <> DialogResult.OK Then
                    If GlobalVariables._OrderedQuantity > 0 Then BandedGridView1.SetFocusedRowCellValue("OrderedQuantity", GlobalVariables._OrderedQuantity)
                    GlobalVariables._OrderedQuantity = 0
                    GetItemsCountInOrdersTable()
                End If
            End With
        Else
            Dim F As New OrderQuantity
            With F
                .LabelControlItem.Text = ItemName
                .TextEditItemNo.Text = ItemNo
                .TextEditOrderQuantity.Text = Quantity
                '_OrderTable.Rows.Add(ItemNo, ItemName, Quantity)
                If .ShowDialog() <> DialogResult.OK Then
                    If GlobalVariables._OrderedQuantity > 0 Then BandedGridView1.SetFocusedRowCellValue("OrderedQuantity", GlobalVariables._OrderedQuantity)
                End If
            End With
        End If
    End Sub

    Private Sub CheckInternalOrder_CheckedChanged(sender As Object, e As EventArgs) Handles CheckInternalOrder.CheckedChanged
        If Me.CheckInternalOrder.Checked = True Then
            ' LayoutControlOrderPreview.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            gridInternalOrder.Visible = True
            GetItemsCountInOrdersTable()
        Else
            ' LayoutControlOrderPreview.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            gridInternalOrder.Visible = False
        End If
    End Sub

    Private Sub RepositoryInternalOrder_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryInternalOrder.ButtonClick

        Dim ItemNo As Integer
        Dim ItemName As String
        Dim OrderedQuantity As Decimal
        Dim _ItemNo2 As String = ""
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("StockID")) Then Exit Sub
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemName")) Then Exit Sub
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("InternalOrderd")) Then Exit Sub
        If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemNo2")) Then
            _ItemNo2 = ""
        Else
            _ItemNo2 = BandedGridView1.GetFocusedRowCellValue("ItemNo2")
        End If
        ItemNo = BandedGridView1.GetFocusedRowCellValue("StockID")
        ItemName = BandedGridView1.GetFocusedRowCellValue("ItemName")
        OrderedQuantity = BandedGridView1.GetFocusedRowCellValue("InternalOrderd")
        If OrderedQuantity = 0 Then
            MsgBoxShowError(" الكمية صفر ")
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " INSERT INTO [dbo].[InternalOrders]
              ([ItemNo]
              ,[ItemName]
              ,[Quantity]
              ,[OrderDate]
              ,[OrderByUser]
              ,[Orderstatus],[OrderType],[ItemNo2])
        VALUES
              (" & ItemNo & "
              ,N'" & ItemName & "'
              ," & OrderedQuantity & "
              ,'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'
              ," & GlobalVariables.CurrUser & "
              ,0," & e.Button.Tag & ",' " & _ItemNo2 & "') "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            XtraMessageBox.Show("تمت عملية الطلب بنجاح")
            BandedGridView1.SetFocusedRowCellValue("InternalOrderd", OrderedQuantity)
        End If
    End Sub
    Private Sub RepositoryInternalOrder_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryInternalOrder.EditValueChanged
        If BandedGridView1.PostEditor() Then
            BandedGridView1.UpdateCurrentRow()
        End If
    End Sub

    Private Sub RepositoryOrder2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOrder2.ButtonClick
        Dim F As New OrderItemShalash
        With F
            Dim _Balance1, _Balance2 As Decimal
            _Balance1 = CDec(Me.BandedGridView1.GetFocusedRowCellValue("balance"))
            _Balance2 = GetItemBalance(Me.BandedGridView1.GetFocusedRowCellValue("StockID"), Warehouses.EditValue)
            If _Balance1 <> _Balance2 Then
                MsgBoxShowError(" الكمية المتاحة للصنف تم تعديلها، يرجى تحديث البيانات")
            End If

            If _Balance2 = 0 Then
                MsgBoxShowError(" لا يمكن طلب الصنف، الكمية صفر بالمستودع ")
                Exit Sub
            End If
            'MsgBox(Me.TileView1.GetFocusedRowCellValue("ItemNo"))
            .TextWareHouse.Text = Me.Warehouses.EditValue
            .ItemNo.EditValue = Me.BandedGridView1.GetFocusedRowCellValue("StockID")
            .TextEditLastQuantity.EditValue = _Balance2
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Me.BandedGridView1.OptionsSelection.MultiSelect = True
        BandedGridView1.SelectAll()
        BandedGridView1.CopyToClipboard()
    End Sub

    Private Sub BandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView1.DoubleClick
        With BandedGridView1
            Dim Currentbalance As Decimal, CurrentDate As Date, ItemNo As Integer, Barcode As String, LastPurchasePrice As Decimal, ItemName As String
            Select Case .FocusedColumn.FieldName
                Case "balance"
                    'If Me.CheckValuation.Checked = False Then
                    '    MsgBoxShowError(" يجب تقييم المخزون ")
                    '    Exit Sub
                    'End If
                    Currentbalance = .GetFocusedRowCellValue("balance")
                    ItemNo = .GetFocusedRowCellValue("StockID")
                    CurrentDate = DateDocDate.DateTime
                    Barcode = .GetFocusedRowCellValue("Barcode")
                    'LastPurchasePrice = .GetFocusedRowCellValue("LastPurchasePrice")
                    ItemName = .GetFocusedRowCellValue("ItemName")
                    Dim f As New ChangeItemBalanceInStockBalance
                    With f
                        .TextSystemQuantity.EditValue = Currentbalance
                        .TextItemNo.Text = ItemNo
                        .DocDate.DateTime = CurrentDate
                        .TextBarcode.Text = Barcode
                        '.TextItemCost.EditValue = LastPurchasePrice
                        .TextWarehouseID.EditValue = Me.Warehouses.EditValue
                        .TexItemName.Text = ItemName
                        .ShowDialog()
                    End With
                Case Else
                    Exit Sub
            End Select
        End With
    End Sub
    '    Private Sub GridView1_ShowingEditor(ByVal sender As Object,
    'ByVal e As System.ComponentModel.CancelEventArgs) _
    'Handles BandedGridView1.ShowingEditor
    '        ' Dim View As BandedGridView = sender
    '        '  Dim CellValue As String = View.GetRowCellValue(View.FocusedRowHandle, ColOrderedQuantity).ToString()
    '        'If CInt(CellValue) > 0 Then e.Cancel = True

    '        'Dim view As BandedGridView = TryCast(sender, GridView)
    '        'If view.FocusedColumn.FieldName = "Order" Then
    '        '    If (Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "OrderedQuantity")) > 0 Then
    '        '        ' If DocName.EditValue <> 11 Then
    '        '        e.Cancel = True
    '        '        ' End If
    '        '    End If
    '        'End If

    '    End Sub
End Class