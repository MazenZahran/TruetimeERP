Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class IncomeStatment
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CreateTempTable()
    End Sub
    Private Sub CreateTempTable()
        Dim _CostCenter1, _CostCenter2 As String
        Dim _CostCenterType1, _CostCenterType2 As String
        If SearchCostCenter.Text = "" Then SearchCostCenter.EditValue = -1
        If SrchCostCenterType.Text = "" Then SrchCostCenterType.EditValue = -1

        If SearchCostCenter.EditValue <> -1 Then
            _CostCenter1 = SearchCostCenter.EditValue
            _CostCenter2 = SearchCostCenter.EditValue
        Else
            _CostCenter1 = "0"
            _CostCenter2 = "9999999"
        End If


        If SrchCostCenterType.EditValue <> -1 Then
            _CostCenterType1 = SrchCostCenterType.EditValue
            _CostCenterType2 = SrchCostCenterType.EditValue
        Else
            _CostCenterType1 = "0"
            _CostCenterType2 = "9999999"
        End If

        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "  IF OBJECT_ID('tempdb..#tmp_IncomeStatment') IS NOT NULL
                        DROP TABLE #tmp_IncomeStatment

  Declare @StartDate date
  Declare @EndDate date
  Declare @CostCenter1 int
  Declare @CostCenter2 int
  Declare @CostCenterType1 int
  Declare @CostCenterType2 int
  Set @StartDate ='" & Format(DateStart.DateTime, "yyyy-MM-dd") & "'
  Set @EndDate ='" & Format(DateEnd.DateTime, "yyyy-MM-dd") & "'
  Set @CostCenter1 = " & _CostCenter1 & " ; Set @CostCenter2= " & _CostCenter2

        SqlString += "Set @CostCenterType1 = " & _CostCenterType1 & " ; Set @CostCenterType2= " & _CostCenterType2

        SqlString += " Select A.AccNo,AccName,Case When A.FinancialSector=6  then N'1 (أولا: المبيعات)' When A.FinancialSector=7 then N'2 (ثانيا: تطرح تكلفة البصاعة المباعة)' When A.FinancialSector=8 then N'3 (ثالثا: تطرح المصاريف)' When A.FinancialSector=9 then N'4 رابعا: صافي الربح' End as  FinancialSector,isnull(B.DebitSum,0) As Debit,Isnull(C.CreditSum,0) As Credit,(isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) As Balance,A.SectorName
  INTO #tmp_IncomeStatment 
  From

        (Select AccNo ,AccName,FinancialSector,P.SectorName  from [dbo].FinancialAccounts F left join FinancialParts P on F.FinancialSector=P.SectorID 
         Where [FinancialStatment]=2 "
        If CheckInventory.Checked = True Then SqlString += " And (AccNo <>'4010000000' And AccNo<>'4050000000') "
        SqlString += " ) A 
left Join "
        If GlobalVariables._ShowCostCenter = True And (SrchCostCenterType.EditValue <> -1 Or SearchCostCenter.EditValue <> -1) Then
            SqlString += "  ( Select Sum(BaseCurrAmount) as DebitSum ,DebitAcc  from Journal J left join CostCenter C on C.CostID = J.DocCostCenter left join CostCenterTypes T on T.ID=C.CostCenterTypeID where DocStatus<>0  and (DocDate between @StartDate and @EndDate) and ( DocCostCenter between @CostCenter1 and @CostCenter2 ) and ( T.ID between @CostCenterType1 and @CostCenterType2 )  group by DebitAcc ) B "
        Else
            SqlString += "  ( Select Sum(BaseCurrAmount) As DebitSum ,DebitAcc  from Journal J  where DocStatus<>0  And (DocDate between @StartDate And @EndDate)  group by DebitAcc ) B "
        End If
        SqlString += " on A.AccNo=B.DebitAcc
    left Join "
        If GlobalVariables._ShowCostCenter = True And (SrchCostCenterType.EditValue <> -1 Or SearchCostCenter.EditValue <> -1) Then
            SqlString += "  ( Select Sum(BaseCurrAmount) as CreditSum ,CredAcc  from Journal J left join CostCenter C on C.CostID = J.DocCostCenter left join CostCenterTypes T on T.ID=C.CostCenterTypeID where DocStatus<>0  and (DocDate between @StartDate and @EndDate) and ( DocCostCenter between @CostCenter1 and @CostCenter2 ) and ( T.ID between @CostCenterType1 and @CostCenterType2 )  group by CredAcc  ) C"
        Else
            SqlString += "  ( Select Sum(BaseCurrAmount) as CreditSum ,CredAcc  from Journal J  where DocStatus<>0  and (DocDate between @StartDate and @EndDate)  group by CredAcc  ) C"
        End If
        SqlString += " on A.AccNo=C.CredAcc
  Where (isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) <> 0 
Declare @WahreHouseFrom Int;Declare @WahreHouseTo Int;Set @WahreHouseFrom=1;Set @WahreHouseTo=99999999"

        If CheckInventory.Checked = True Then
            SqlString += "Insert Into #tmp_IncomeStatment
   Select '4010000000' as AccNo,N'بضاعة أول المدة' as AccName,N'2 (ثانيا: تطرح تكلفة البصاعة المباعة)' As FinancialSector,IsNull(Sum(balance * LastPurchasePrice),0) As Debit,0 As Credit,IsNull(Sum(balance * LastPurchasePrice),0) As Balance ,N'تكلفة البضاعة المباعة' From
  (
   SELECT StockID,I.ItemName As ItemName ,
    isnull(sum(case when    [StockDebitWhereHouse] between  @WahreHouseFrom and @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  between  @WahreHouseFrom and @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as balance
    FROM [Journal] J
    left join Items I on I.ItemNo=J.StockID 
    where DocDate < @StartDate   and DocStatus<>0 and StockID > '0' 
    And I.[Type]=0 and (StockDebitWhereHouse between  @WahreHouseFrom and @WahreHouseTo or StockCreditWhereHouse between  @WahreHouseFrom and @WahreHouseTo) group by StockID,I.ItemName
     ) A
left join
(
       -- select  [ItemNo] as StockID,IsNull([LastPurchasePrice],0) as LastPurchasePrice from [dbo].[Items] 
        SELECT StockID,Case when [StockQuantityByMainUnit] <> 0 then [BaseCurrAmount]/ABS([StockQuantityByMainUnit]) else 0 end as LastPurchasePrice
                    FROM Journal S 
                    WHERE DocDate=(SELECT Top(1) MAX(DocDate) FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate < @StartDate and StockID = S.StockID   )
                    And S.ID=(SELECT Top(1) ID FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <@StartDate and StockID = S.StockID order by DocDate desc  )
                    and DocStatus <> 0 and DocName in (1,17,19) and  DocDate < @StartDate  
                                        
     ) B
 on A.StockID=B.StockID "
        End If

        If CheckInventory.Checked = True Then
            SqlString += "Insert Into #tmp_IncomeStatment
   Select '4050000000' as AccNo,N'بضاعة نهاية المدة' as AccName,N'2 (ثانيا: تطرح تكلفة البصاعة المباعة)' As FinancialSector,0 As Debit,IsNull(Sum(balance * LastPurchasePrice),0) As Credit,-1 * IsNull(Sum(balance * LastPurchasePrice),0) As Balance,N'تكلفة البضاعة المباعة'  From
  (
   SELECT StockID,I.ItemName As ItemName ,
    isnull(sum(case when    [StockDebitWhereHouse] between  @WahreHouseFrom and @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  between  @WahreHouseFrom and @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as balance
    FROM [Journal] J
    left join Items I on I.ItemNo=J.StockID 
    where DocDate <= @EndDate   and DocStatus<>0 and StockID > '0' 
    And I.[Type]=0 and (StockDebitWhereHouse between  @WahreHouseFrom and @WahreHouseTo or StockCreditWhereHouse between  @WahreHouseFrom and @WahreHouseTo) group by StockID,I.ItemName
     ) A
left join
(
          SELECT StockID,Case when [StockQuantityByMainUnit] <> 0 then [BaseCurrAmount]/ABS([StockQuantityByMainUnit]) else 0 end as LastPurchasePrice
                    FROM Journal S 
                    WHERE DocDate=(SELECT Top(1) MAX(DocDate) FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <=@EndDate and StockID = S.StockID   )
                    And S.ID=(SELECT Top(1) ID FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,19) and DocDate <=@EndDate and StockID = S.StockID order by DocDate desc  )
                    and DocStatus <> 0 and DocName in (1,17,19) and  DocDate <= @EndDate    
     ) B
 on A.StockID=B.StockID "
        End If

        SqlString += " Declare @ProfitOrLoss dec
 Set @ProfitOrLoss= -1*(Select sum(Balance) from #tmp_IncomeStatment)
 Insert into #tmp_IncomeStatment select '9999999999',Case When @ProfitOrLoss < 0  then N'اجمالي الخسارة' Else N'اجمالي الربح' end as AccName , N'4 رابعا: صافي الربح',
Case When @ProfitOrLoss is null then 0 when @ProfitOrLoss < 0  then 0 Else @ProfitOrLoss end  ,
 Case When @ProfitOrLoss is null then 0 when @ProfitOrLoss >= 0 then 0 Else @ProfitOrLoss end ,   
Case when @ProfitOrLoss is null then 0 else  @ProfitOrLoss end As Balance,N'صافي الربح' 
"

        SqlString += "Select * from #tmp_IncomeStatment order by FinancialSector,AccNo"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()


    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell


        '        Const LargeHTMLPattern As String = "
        '<size=+10>Invoice: <href={0}>R{0}</href> <image={1}></size>
        '<size=+5><i><color=@DisabledText>{3}</color></i></size>

        '<size=+6>{5} - {2}</size>
        '<size=+4><href={4}>{4}</href></size>
        '<size=+3><i><color=@DisabledText>{6}
        '{7}</color></i></size>
        ' "
        '        Const _HtmlAvailable As String = "<backcolor=@Success><b><color=255, 255, 255>  متوفر  </b>"
        '        Const _HtmlSold As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  مباع  </b>"

        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "FinancialSector" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("FinancialSector"))
            If category = "6" Then
                'e.DrawHtmlText(e.DisplayText)
                'e.Graphics.DrawImage(AddImage, e.Bounds.Location)
                'e.DisplayText = String.Empty
                e.DisplayText = "المبيعات"
                e.Appearance.Options.CancelUpdate()
                'e.Appearance.HAlignment = DevExpress.Utils.HorzAlignment.Near
            ElseIf category = "7" Then
                e.DisplayText = "تكلفة البضاعة المباعة"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "8" Then
                e.DisplayText = "المصاريف"
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "9" Then
                e.DisplayText = "الربح"
                e.Appearance.Options.CancelUpdate()
            End If
            'If category <> "" Then
            '    'e.Graphics.DrawImage(ApplyImage, e.Bounds.Location)
            '    e.DisplayText = String.Format(_HtmlPattern)
            'End If
        End If
    End Sub

    Private Sub IncomeStatment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today
        DateStart.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEnd.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        SearchCostCenter.Properties.DataSource = GetCostCenter(True)
        SearchCostCenter.EditValue = -1
        SrchCostCenterType.Properties.DataSource = GetCostCentersType(True)
        SrchCostCenterType.EditValue = -1
        If GlobalVariables._ShowCostCenter = False Then
            LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim F3 As New AccountStatmentForRef
        With F3
            .CheckReportForRef.Text = "False"
            .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccName") & " )"
            .TheAccount.EditValue = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo")
            .Show()
            .DateEditFrom.DateTime = Me.DateStart.DateTime
            .DateEditTo.DateTime = Me.DateEnd.DateTime
            .LookCostCenter.EditValue = SearchCostCenter.EditValue

            .RefreshDataInAccountStatmentForRef()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide

        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")

        Dim reportName As String = "قائمة الدخل"
        If SearchCostCenter.Text <> "" And SearchCostCenter.EditValue <> -1 Then
            reportName = reportName & " لمركز التكلفة " & SearchCostCenter.Text
        End If
        If SrchCostCenterType.Text <> "" And SrchCostCenterType.EditValue <> -1 Then
            reportName = reportName & " / " & SrchCostCenterType.Text
        End If
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(reportName)


        'TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {"قائمة الدخل", "من تاريخ ", "الى تاريخ"})




        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ  " & DateStart.EditValue & "  الى تاريخ  " & DateEnd.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
                                                                           {"  ", Now(), "Pages: [Page # of Pages #]"})
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _journal As New DataTable
        With _journal
            .Columns.Add("AccountNew", GetType(System.String))
            .Columns.Add("Account", GetType(System.String))
            .Columns.Add("AccountCurr", GetType(System.Int16))
            .Columns.Add("DocCostCenter", GetType(System.Int32))
            .Columns.Add("DocCurrency", GetType(System.Int32))
            .Columns.Add("DebitAmount", GetType(System.Decimal))
            .Columns.Add("CreditAmount", GetType(System.Decimal))
            .Columns.Add("ExchangePrice", GetType(System.Decimal))
            .Columns.Add("BaseCurrAmount", GetType(System.Decimal))


            Dim _amount As Decimal
            Dim _AccNo As String

            Dim i As Integer
            For i = 0 To GridView1.RowCount - 1
                _amount = GridView1.GetRowCellValue(i, "Balance")
                _AccNo = GridView1.GetRowCellValue(i, "AccNo")
                If _amount > 0 Then
                    .Rows.Add(_AccNo, _AccNo, 1, 1, 1, 0, _amount, 1, -1 * _amount)
                Else
                    .Rows.Add(_AccNo, _AccNo, 1, 1, 1, Math.Abs(_amount), 0, 1, Math.Abs(_amount))
                End If
            Next

        End With
        GlobalVariables._ItemsTable = _journal

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim myControl As New SendToWhatsAppNo()
        myControl.textMobileNo.Select()
        If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Dim MobileNo As String = myControl.Mobile
            If String.IsNullOrEmpty(MobileNo) Then
                Exit Sub
            End If
            Me.GridView1.ExportToPdf("IncomeStatment.pdf")
            Dim _ReportTitle As String = " قائمة الدخل  " & " الفترة من " & Format(Me.DateStart.DateTime, "dd/MM/yyyy") & " الى " & Format(Me.DateEnd.DateTime, "dd/MM/yyyy")
            SendFileToWhatsApp(MobileNo, "IncomeStatment.pdf", _ReportTitle, "", "")
        End If
    End Sub
End Class