Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class BalanceSheet
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CreateTempTable()
    End Sub
    Private Sub CreateTempTable()


        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   IF OBJECT_ID('tempdb..#tmp_IncomeStatment') IS NOT NULL
 DROP TABLE #tmp_IncomeStatment


Declare @EndDate date
Set @EndDate ='" & Format(DateEnd.DateTime, "yyyy-MM-dd") & "'


 Select A.AccNo,AccName,Case When A.FinancialSector=1  then N'1 (أولا: الأصول المتداولة)' When A.FinancialSector=2 then N'2 (ثانيا: الأصول الثابته)' When A.FinancialSector=3 then N'3 (ثالثا: المطلوبات المتداولة)' When A.FinancialSector=4 then N'4 رابعا: مطلوبات طويلة الاجل' When A.FinancialSector=5 then N'5 خامسا: حقوق الملكية  '  End as  FinancialSector,isnull(B.DebitSum,0) As Debit,Isnull(C.CreditSum,0) As Credit,(isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) As Balance,A.SectorName
   INTO #tmp_IncomeStatment 
   from
  (Select AccNo ,AccName,FinancialSector,P.SectorName  from [dbo].FinancialAccounts F left join FinancialParts P on F.FinancialSector=P.SectorID 
where [FinancialStatment]=1   "
        If CheckInventory.Checked = True Then SqlString += " And (AccNo <>'4010000000' And AccNo<>'4050000000' And AccNo<>'1106000000' )   "
        SqlString += " ) A left Join ( Select Sum(BaseCurrAmount) as DebitSum ,DebitAcc  from Journal where DocStatus<>0  and (DocDate <= @EndDate)  group by  DebitAcc ) B
  on A.AccNo=B.DebitAcc
    left Join 
  ( Select Sum(BaseCurrAmount) as CreditSum ,CredAcc  from Journal where DocStatus<>0 and (DocDate <= @EndDate)  group by CredAcc  ) C
  on A.AccNo=C.CredAcc
  Where (isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) <> 0 "

        If CheckInventory.Checked = True Then
            SqlString += " Declare @WahreHouseFrom Int;Declare @WahreHouseTo Int;Set @WahreHouseFrom=1;Set @WahreHouseTo=99999999
 Insert Into #tmp_IncomeStatment
   Select '4050000000' as AccNo,N'بضاعة نهاية المدة' as AccName,N'1 (أولا: الأصول المتداولة)' As FinancialSector,IsNull(Sum(balance * LastPurchasePrice),0) As Debit,0 As Credit,1 * IsNull(Sum(balance * LastPurchasePrice),0) As Balance,N'اصول متداولة'  From
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
                    WHERE DocDate=(SELECT Top(1) MAX(DocDate) FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,16) and DocDate <=@EndDate and StockID = S.StockID   )
                    And S.ID=(SELECT Top(1) ID FROM Journal SS WHERE DocStatus <> 0 and DocName in (1,17,16) and DocDate <=@EndDate and StockID = S.StockID order by DocDate desc  )
                    and DocStatus <> 0 and DocName in (1,17,16) and  DocDate <= @EndDate    
     ) B
 on A.StockID=B.StockID  "
        End If


        SqlString += "
Declare @ProfitOrLoss dec
 Set @ProfitOrLoss= -1*(Select sum(Balance) from #tmp_IncomeStatment)
 Insert into #tmp_IncomeStatment select '9999999999',Case When @ProfitOrLoss < 0  then N'صافي الربح' Else N'صافي الخسارة' end as AccName , N'5 خامسا: حقوق الملكية  ',
Case When @ProfitOrLoss is null then 0 when @ProfitOrLoss < 0  then 0 Else Abs(@ProfitOrLoss) end  ,
 Case When @ProfitOrLoss is null then 0 when @ProfitOrLoss >= 0 then 0 Else Abs(@ProfitOrLoss) end ,   
Case when @ProfitOrLoss is null then 0 else  @ProfitOrLoss end As Balance,N'حقوق الملكية' 
Select * from #tmp_IncomeStatment order by FinancialSector,AccNo"
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
        '  DateStart.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEnd.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        '  SearchCostCenter.Properties.DataSource = GetCostCenter(False)
        ' gff
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridControl1.Print()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub Send()
        Me.GridView1.ExportToPdf("")
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim myControl As New SendToWhatsAppNo()
        myControl.textMobileNo.Select()
        If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
            Dim MobileNo As String = myControl.Mobile
            If String.IsNullOrEmpty(MobileNo) Then
                Exit Sub
            End If
            Me.GridView1.ExportToPdf("BalanceSheet.pdf")
            Dim _ReportTitle As String = " الميزانية العمومية  " & " في " & Format(Me.DateEnd.DateTime, "dd/MM/yyyy")
            SendFileToWhatsApp(MobileNo, "BalanceSheet.pdf", _ReportTitle, "", "")
        End If
    End Sub
End Class