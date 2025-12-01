Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports DevExpress.Data
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Native
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraVerticalGrid
Imports Microsoft.Office.Interop.Outlook
Imports Link = DevExpress.XtraPrinting.Link

Public Class ShishaMonthlyReport
    Private _SalesByCategory As DataTable
    Private _CostByCategory As DataTable
    Private _AllocateExpensesOnCategories As DataTable
    Private _ExpenseTable As DataTable
    Private _HeaderTables As DataTable
    Private _CostOfGoodSold As DataTable
    Sub ShishaMonthlyReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTasksTable()
        GetLastMonthdates()
        TabbedControlGroup1.SelectedTabPage = TabMain
        WhereHouse.Properties.DataSource = GetWharehouses(-1)
        WhereHouse.EditValue = 1

    End Sub
    Private Sub GetLastMonthdates()
        Dim _fromdate, _todate As DateTime
        Dim _lastmonth, _year As Integer
        If Today.Month = 1 Then
            _lastmonth = 12
            _year = Today.Year - 1
        Else
            _lastmonth = Today.Month - 1
            _year = Today.Year
        End If
        Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
        _fromdate = New Date(_year, _lastmonth, 1)
        _todate = New Date(_year, _lastmonth, _daysCount)
        Me.DateEditFrom.DateTime = _fromdate
        Me.DateEditTo.DateTime = _todate
    End Sub
    Private Sub CreateTasksTable()
        Dim dt As New DataTable()
        dt.Columns.Add("Task", GetType(String))
        dt.Columns.Add("ID", GetType(Integer))
        dt.Rows.Add("تحضير المبيعات", 1)
        dt.Rows.Add("تحضير تكلفة المبيعات", 2)
        dt.Rows.Add("جدول الرواتب", 3)
        dt.Rows.Add("جدول المصاريف", 4)
        dt.Rows.Add("التقرير الشهري", 5)
        GridControlPosNames.DataSource = dt
    End Sub

    Private Sub TileViewBranches_ItemClick(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs) Handles TileViewTasks.ItemClick
        Dim _TaskID As Integer
        _TaskID = TileViewTasks.GetFocusedRowCellValue("ID")
        Select Case _TaskID
            Case 1
                TabbedControlGroup1.SelectedTabPage = TabSales
                GridViewSalesByCategory.ViewCaption = "  تقرير المبيعات للفترة من " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
            Case 2
                TabbedControlGroup1.SelectedTabPage = TabCostOfSales
                GridViewCostOfGoodsSold.ViewCaption = "  تقرير تكلفة المبيعات للفترة من " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
            Case 3
                TabbedControlGroup1.SelectedTabPage = TabSalaryOnCategories
            Case 4
                TabbedControlGroup1.SelectedTabPage = TabAllocateExpensesOnCategories
            Case 5
                TabbedControlGroup1.SelectedTabPage = TabMonthReport
        End Select
        ' اختيار المهمة
    End Sub
    Private Sub DateEditFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditFrom.EditValueChanged, DateEditTo.EditValueChanged
        If Me.IsHandleCreated Then
            LabelMainIdea.Text = " التقرير الشهري للفترة من  " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
        End If
    End Sub
    Private Sub BtnRefreshSalesData_Click(sender As Object, e As EventArgs) Handles BtnRefreshSalesData.Click
        GetSalesReportByCategory()
    End Sub
    Private Sub GetSalesReportByCategory()
        Dim sql As New SQLControl
        Dim sqlStringSalesByCategory As String
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        sqlStringSalesByCategory = "    Declare @TotalSales Decimal(18,3)
                                     Set @TotalSales=(Select sum (  Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] end ) from Journal J left join DocNames N on N.id=J.DocName left join Items I on I.ItemNo=J.StockID Where I.Type<>3 And J.StockID is not null And J.StockID <> 0   And DocStatus <> 0 And J.DocDate between  '" & _dateFrom & "' and '" & _date__To & "'  And DocName In (2,12) )
                                     Select CONVERT (DECIMAL(16,2) , sum (  Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] end )) as SalesSUM  ,
                                            CONVERT( DECIMAL(16,2) ,(sum (  Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] end ) * 100.0 / @TotalSales)) AS PercentageOfTotal,
                                        IsNull(CategoryName,'0') as CategoryName ,Case When I.CategoryID='' then '0' Else IsNull(I.CategoryID,'0') end as CategoryID,'" & _dateFrom & "' as DateFrom,'" & _date__To & "' as DateTo
                                     From [dbo].[Journal] J
                                         left join Items I on I.ItemNo=J.StockID 
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
                                         J.DocDate between '" & _dateFrom & "' and '" & _date__To & "'  And DocName In (2,12) 
                                     Group by IsNull(CategoryName,'0')  ,I.CategoryID Order BY I.CategoryID"
        sql.SqlTrueAccountingRunQuery(sqlStringSalesByCategory)
        GridControlSales.DataSource = sql.SQLDS.Tables(0)
        ChartControlSales.DataSource = sql.SQLDS.Tables(0)
        ChartControlSales2.DataSource = sql.SQLDS.Tables(0)
        _SalesByCategory = sql.SQLDS.Tables(0)
        GridViewSalesByCategory.ViewCaption = "  تقرير المبيعات للفترة من " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnRefreshCostOfSalesData.Click
        GetCostOfGoodSold()
    End Sub
    Private Sub GetCostOfGoodSoldByCategory(_CategoryID As String)
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Declare @WahreHouseFrom Int;
                        Declare @WahreHouseTo Int;
                        Declare @DateFrom date;Declare @DateTo date;
                        Set @WahreHouseFrom=" & WhereHouse.EditValue & "
                        Set @WahreHouseTo=" & WhereHouse.EditValue & "
                        Set @DateFrom ='" & Format(DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                        Set @DateTo ='" & Format(DateEditTo.DateTime, "yyyy-MM-dd") & "'
                        Select A.ItemNo,A.ItemName,A.CategoryName,A.CategoryID,IsNull(B.BeginingBalance,0) as BeginingBalance,IsNull(C.EndingBalance,0) as EndingBalance,IsNull(Purchases,0) as Purchases,IsNull(ReturnPurchases,0) as ReturnPurchases,
                        IsNull(B.BeginingBalance,0)+IsNull(Purchases,0)-IsNull(ReturnPurchases,0)-IsNull(C.EndingBalance,0) as Consume,
						IsNull(A.LastPurchasePrice,0)*(IsNull(B.BeginingBalance,0)+IsNull(Purchases,0)-IsNull(ReturnPurchases,0)-IsNull(C.EndingBalance,0)) TotalCost
                        From 
                        (Select ItemNo,ItemName,LastPurchasePrice,C.CategoryName,I.CategoryID from Items I Left Join ItemsCategories C on I.CategoryID=C.CategoryID where I.[Type]=0 And I.CategoryID=" & _CategoryID & ") A

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as BeginingBalance
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where  DocDate < @DateFrom And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) B
                        On A.ItemNo=B.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as EndingBalance
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where  DocDate <= @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) C
                        On A.ItemNo=C.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as Purchases
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where DocName=1 And  DocDate between @DateFrom and @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) D
                        On A.ItemNo=D.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as ReturnPurchases
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where DocName=13 And  DocDate between @DateFrom and @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) E
                        On A.ItemNo=E.StockID "
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlCostOfGoodsSoldByCategory.DataSource = sql.SQLDS.Tables(0)
        _CostByCategory = sql.SQLDS.Tables(0)
    End Sub
    Private Sub GetCostOfGoodSold()

        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "   Declare @WahreHouseFrom Int;
                        Declare @WahreHouseTo Int;
                        Declare @DateFrom date;Declare @DateTo date;
                        Set @WahreHouseFrom=" & WhereHouse.EditValue & "
                        Set @WahreHouseTo=" & WhereHouse.EditValue & "
                        Set @DateFrom ='" & Format(DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                        Set @DateTo ='" & Format(DateEditTo.DateTime, "yyyy-MM-dd") & "'
                        Select CategoryName,CategoryID, CONVERT( DECIMAL(16,2) ,Sum(TotalCost)) as TotalCost,0.0 as PercentageOfTotal,'" & _dateFrom & "' as DateFrom,'" & _date__To & "' as DateTo From
                        (
                        Select A.ItemNo,A.ItemName,A.CategoryName,A.CategoryID,IsNull(B.BeginingBalance,0) as BeginingBalance,IsNull(C.EndingBalance,0) as EndingBalance,IsNull(Purchases,0) as Purchases,IsNull(ReturnPurchases,0) as ReturnPurchases,
                        IsNull(B.BeginingBalance,0)+IsNull(Purchases,0)-IsNull(ReturnPurchases,0)-IsNull(C.EndingBalance,0) as Consume,
						IsNull(A.LastPurchasePrice,0)*(IsNull(B.BeginingBalance,0)+IsNull(Purchases,0)-IsNull(ReturnPurchases,0)-IsNull(C.EndingBalance,0)) TotalCost
                        From 
                        (Select ItemNo,ItemName,LastPurchasePrice,C.CategoryName,I.CategoryID from Items I Left Join ItemsCategories C on I.CategoryID=C.CategoryID where I.[Type]=0 And  C.CategoryName Is Not NULL ) A

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as BeginingBalance
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where  DocDate < @DateFrom And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) B
                        On A.ItemNo=B.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as EndingBalance
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where  DocDate <= @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) C
                        On A.ItemNo=C.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as Purchases
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where DocName=1 And  DocDate between @DateFrom and @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) D
                        On A.ItemNo=D.StockID

                        Left Join 
                        (SELECT StockID, I.ItemName,
                            isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as ReturnPurchases
                        FROM [Journal] J
                            left join Items I on I.ItemNo=J.StockID
                            left join Items_units IU on IU.item_id=I.ItemNo
                        where DocName=13 And  DocDate between @DateFrom and @DateTo And IU.main_unit=1 and DocStatus<>0 and StockID > '0' And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
                        group by StockID,I.ItemName) E
                        On A.ItemNo=E.StockID
                         ) AA   
                         Group By CategoryName,CategoryID Order By CategoryID "

        sql.SqlTrueAccountingRunQuery(SqlString)
        _CostOfGoodSold = sql.SQLDS.Tables(0)
        Dim totalCosts As Decimal = 0
        For Each row As DataRow In _CostOfGoodSold.Rows
            totalCosts += Convert.ToDecimal(row("TotalCost"))
        Next
        If totalCosts <> 0 Then
            For Each row As DataRow In _CostOfGoodSold.Rows
                Dim totalCost As Decimal = Convert.ToDecimal(row("TotalCost"))
                Dim percentOfSales As Decimal = (totalCost / totalCosts) * 100
                row("PercentageOfTotal") = percentOfSales.ToString("0.00")
            Next
        End If
        GridControlCostOfGoodsSold.DataSource = _CostOfGoodSold
        Chart1ControlCostOfGoodsSold.DataSource = _CostOfGoodSold
        Chart2ControlCostOfGoodsSold.DataSource = _CostOfGoodSold
        GridViewCostOfGoodsSold.ViewCaption = "  تقرير تكلفة المبيعات للفترة من " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
    End Sub

    Private Sub BtnSaveSalesData_Click_1(sender As Object, e As EventArgs) Handles BtnSaveSalesData.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Delete from [Samba_ShishaReportSales] 
                                        where DateFrom='" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'")
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In _SalesByCategory.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "Samba_ShishaReportSales"
            bulkCopy.WriteToServer(_SalesByCategory)
            MsgBoxShowSuccess(" تم حفظ البيانات بنجاح")
            TabbedControlGroup1.SelectedTabPage = TabMain
        End Using
    End Sub

    Private Sub RepositoryBtnSalesDetails_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryBtnSalesDetails.ButtonClick
        Dim _CategoryID As Integer
        _CategoryID = GridViewSalesByCategory.GetFocusedRowCellValue("CategoryID")
        GetSalesDetailsByCategory(_CategoryID)
        TabbedControlGroup1.SelectedTabPage = TabSalesDetails
    End Sub
    Private Sub GetSalesDetailsByCategory(_CategoryID As Integer)
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        'SqlString = "   Select     Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] End As [BaseAmount]  ,
        '                        Case When N.id In (2,1) then J.StockQuantity When N.id In (12,13) then -1*StockQuantity end as StockQuantity ,
        '                        StockID,I.ItemName,
        '                        J.DocDate,N.Name As DocName,U.name as UnitName,J.DocID,
        '                        Case When N.id In (2,1) then StockQuantity*IU.EquivalentToMain When N.id In (12,13) then  -1*StockQuantity*IU.EquivalentToMain End  As TotalEquivalentToMain,
        '                        IU.EquivalentToMain,GroupName,I.CategoryID
        '                 From [dbo].[Journal] J
        '                                    left join Items I on I.ItemNo=J.StockID 
        '                                    left Join EmployeesData E on E.EmployeeID=J.SalesPerson
        '                                    left Join Referencess R on R.RefNo=J.Referance 
        '                                    left Join DocNames N on N.id=J.DocName 
        '                                    left join Units U on U.id=J.StockUnit 
        '                                    left Join Items_units IU on IU.item_id=J.StockID and J.StockUnit=IU.unit_id  and Iu.IsUnit=1
        '                                    left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
        '                                    left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
        '                                    left join ItemsGroups G on G.GroupID=I.GroupID 
        '                                    left Join Currency Cu on Cu.CurrID=J.DocCurrency
        '                                    left join CostCenter Cs on J.DocCostCenter=Cs.CostID 
        '                 Where I.Type<>3 And J.StockID is not null And J.StockID <> 0   And DocStatus <> 0 And 
        '                                    J.DocDate between '" & _dateFrom & "' and '" & _date__To & "'  And DocName In (2,12) And I.CategoryID=" & _CategoryID
        SqlString = " Declare @Total Decimal(18,2)
                      Declare @CategoryID int
                      Set @CategoryID=" & _CategoryID & "
                      Set @Total = (  select Sum([BaseAmount]) From [dbo].[Journal] J left join Items I on I.ItemNo=J.StockID Where I.Type<>3 And J.StockID is not null And J.StockID <> 0   And DocStatus <> 0 And 
				      J.DocDate between '" & _dateFrom & "' and '" & _date__To & "'  And DocName In (2,12) And I.CategoryID=@CategoryID    )
                      Select StockID,GroupName,Sum([BaseAmount]) As BaseAmount,Sum([StockQuantity]) as StockQuantity,ItemName,ROUND ( (Sum(BaseAmount)/@Total)*100 ,2) as PercentageOfsale from 
                       (
                        Select     Case When N.id In (2,1) then [BaseAmount] When N.id In (12,13) then -1*[BaseAmount] End As [BaseAmount]  ,
	                               Case When N.id In (2,1) then J.StockQuantity When N.id In (12,13) then -1*StockQuantity end as StockQuantity ,
	                               StockID,I.ItemName,
	                               J.DocDate,N.Name As DocName,U.name as UnitName,J.DocID,
	                               Case When N.id In (2,1) then StockQuantity*IU.EquivalentToMain When N.id In (12,13) then  -1*StockQuantity*IU.EquivalentToMain End  As TotalEquivalentToMain,
	                               IU.EquivalentToMain,GroupName,I.CategoryID
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
                                            J.DocDate between '" & _dateFrom & "' and '" & _date__To & "'  And DocName In (2,12) And I.CategoryID=@CategoryID ) A
											group by ItemName,GroupName,StockID Order By BaseAmount desc "
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControlSalesDetails.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryBtnDetails_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryBtnDetails.ButtonClick
        Dim _CategoryID As String
        _CategoryID = CStr(GridViewCostOfGoodsSold.GetFocusedRowCellValue("CategoryID"))
        GetCostOfGoodSoldByCategory(_CategoryID)
        TabbedControlGroup1.SelectedTabPage = TabTabCostOfSalesDetails
    End Sub
    Private Sub BtnSaveCostOfSales_Click(sender As Object, e As EventArgs) Handles BtnSaveCostOfSales.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Delete from [Samba_ShishaReportCostOfSales] 
                                        where DateFrom='" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'")
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In _CostOfGoodSold.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "Samba_ShishaReportCostOfSales"
            bulkCopy.WriteToServer(_CostOfGoodSold)
            MsgBoxShowSuccess(" تم حفظ البيانات بنجاح")
            TabbedControlGroup1.SelectedTabPage = TabMain
        End Using
    End Sub
    Protected Sub TabbedGroup_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                               ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabSales" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabSalesDetails" Then
            TabbedControlGroup1.SelectedTabPage = TabSales
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabCostOfSales" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabTabCostOfSalesDetails" Then
            TabbedControlGroup1.SelectedTabPage = TabCostOfSales
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabExpensesTable" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabAllocateExpensesOnCategories" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabMonthReport" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabSalaryOnCategories" Then
            TabbedControlGroup1.SelectedTabPage = TabMain
        ElseIf e.Button.Tag = "Back" AndAlso TabbedControlGroup1.SelectedTabPageName = "TabSalaryAllocateTable" Then
            TabbedControlGroup1.SelectedTabPage = TabSalaryOnCategories
        End If
    End Sub

    Private Sub GetAccountsPercentageTable()
        GridViewSalariesPercentage.PopulateColumns()
        Dim _HeaderTables As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        'المصاريف
        Dim _ExpenseTable As DataTable
        sqlstring = " SELECT  distinct([AccountNo]) as AccountNo   FROM [dbo].[Samba_ShishaExpensesAllocationDefine]  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _ExpenseTable = sql.SQLDS.Tables(0)

        'الاقسام
        sqlstring = " SELECT distinct(S.[CategoryID]),C.CategoryName FROM [dbo].[Samba_ShishaExpensesAllocationDefine] S left join ItemsCategories C on S.CategoryID=C.CategoryID"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _HeaderTables = sql.SQLDS.Tables(0)
        Dim CategoriesTable As New DataTable()
        CategoriesTable.Columns.Add("ExpensesName", GetType(String))
        CategoriesTable.Columns.Add("ExpensesNo", GetType(String))
        CategoriesTable.Columns.Add("Total", GetType(Decimal))
        For i = 0 To _HeaderTables.Rows.Count - 1
            CategoriesTable.Columns.Add(_HeaderTables.Rows(i).Item("CategoryName"), GetType(String))
        Next

        'add rows to CategoriesTable 
        For i = 0 To _ExpenseTable.Rows.Count - 1
            Dim _AccountNo As String = _ExpenseTable.Rows(i).Item("AccountNo")
            Dim _AccountName As String = GetFinancialAccountsData(_AccountNo).AccName
            Dim _Row As DataRow = CategoriesTable.NewRow()
            _Row("ExpensesName") = _AccountName
            _Row("ExpensesNo") = _AccountNo
            Dim _Total As Decimal = 0
            For j = 0 To _HeaderTables.Rows.Count - 1
                Dim _CategoryName As String = _HeaderTables.Rows(j).Item("CategoryName")
                Dim _CategoryAmount As Decimal = GetExpensePercentageByCategory(_AccountNo, _CategoryName).Percentage
                _Total += _CategoryAmount
                _Row(_CategoryName) = _CategoryAmount
                _Row("Total") = _Total
            Next
            CategoriesTable.Rows.Add(_Row)
        Next
        GridControlAccountsPercentage.DataSource = CategoriesTable
    End Sub

    Private Function GetExpensePercentageByCategory(_AccountNo As String, _CategoryName As String) As (Percentage As Decimal, ID As Integer)
        Dim _Percentage As Decimal
        Dim _PercantageFromSales As Boolean
        Dim _ID As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [Percantage],[ID],IsNull([PercantageFromSales],0) as PercantageFromSales
                      FROM [dbo].[Samba_ShishaExpensesAllocationDefine] S 
                      Left join  ItemsCategories C on S.CategoryID=C.CategoryID  
                      Where AccountNo=" & _AccountNo & " And C.CategoryName='" & _CategoryName & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _PercantageFromSales = CBool(sql.SQLDS.Tables(0).Rows(0).Item("PercantageFromSales"))
            If _PercantageFromSales = False Then
                _Percentage = sql.SQLDS.Tables(0).Rows(0).Item("Percantage")
                _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Else
                _Percentage = GetExpensePercentageByCategory2(_AccountNo, _CategoryName).Percentage
                _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
            End If


        Else
            _Percentage = 0
            _ID = 0
        End If
        Return (_Percentage, _ID)
    End Function

    Public Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim F As New ShishaDefineNewExpenseWithPercentage(-1)
        If F.ShowDialog() <> DialogResult.OK Then
            GetAccountsPercentageTable()
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GetAccountsPercentageTable()
    End Sub
    Private Sub تعديلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تعديلToolStripMenuItem.Click
        Dim _AccountNo As String = GridViewSalariesPercentage.GetFocusedRowCellValue("ExpensesNo")
        Dim _AccountName As String = GridViewSalariesPercentage.GetFocusedRowCellValue("ExpensesName")
        Dim _HeaderName As String = GridViewSalariesPercentage.FocusedColumn.FieldName
        If _HeaderName <> "" Then
            Dim _CategoryName As String = _HeaderName
            Dim _Percentage As Decimal = GetExpensePercentageByCategory(_AccountNo, _CategoryName).Percentage
            Dim _ID As Decimal = GetExpensePercentageByCategory(_AccountNo, _CategoryName).ID
            Dim F As New ShishaDefineNewExpenseWithPercentage(_ID)
            With F
                .txtAccountNo.EditValue = _AccountNo
                .txtCategoryID.EditValue = GetCategoryIDFromCategoryName(_CategoryName)
                .txtPercantage.EditValue = _Percentage
            End With
            If F.ShowDialog() <> DialogResult.OK Then
                GetAccountsPercentageTable()
            End If
        End If
    End Sub
    Private Function GetCategoryIDFromCategoryName(_CategoryName As String) As Integer
        Dim _CategoryID As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [CategoryID] 
                      FROM [dbo].[ItemsCategories] 
                      Where CategoryName='" & _CategoryName & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _CategoryID = sql.SQLDS.Tables(0).Rows(0).Item("CategoryID")
        Else
            _CategoryID = 0
        End If
        Return _CategoryID
    End Function

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        AllocateExpensesOnCategories()
    End Sub
    Private Sub AllocateExpensesOnCategories()
        GridViewAllocateSalariesOnCategories.PopulateColumns()

        Dim siTotal As New GridColumnSummaryItem()
        siTotal.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal.DisplayFormat = "{0:n2}"


        Dim siTotal0 As New GridColumnSummaryItem()
        siTotal0.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal0.DisplayFormat = "{0:n2}"

        Dim siCategoryName As New GridColumnSummaryItem()
        siCategoryName.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siCategoryName.DisplayFormat = "{0:n2}"

        Dim si1 As New GridColumnSummaryItem()
        si1.SummaryType = DevExpress.Data.SummaryItemType.Sum
        si1.DisplayFormat = "{0:n2}"

        Dim si2 As New GridColumnSummaryItem()
        si2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        si2.DisplayFormat = "{0:n2}"

        Dim si3 As New GridColumnSummaryItem()
        si3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        si3.DisplayFormat = "{0:n2}"

        Dim si4 As New GridColumnSummaryItem()
        si4.SummaryType = DevExpress.Data.SummaryItemType.Sum
        si4.DisplayFormat = "{0:n2}"

        Dim sql As New SQLControl
        Dim sqlstring As String
        'المصاريف

        sqlstring = " SELECT  distinct([AccountNo]) as AccountNo,F.AccName,'0' As AcountAmount FROM [dbo].[Samba_ShishaExpensesAllocationDefine] S Left Join FinancialAccounts F on F.AccNo=S.AccountNo  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _ExpenseTable = sql.SQLDS.Tables(0)
        For i = 0 To _ExpenseTable.Rows.Count - 1
            _ExpenseTable.Rows(i).Item("AcountAmount") = GetAccountBalanceWithPeriod(_ExpenseTable.Rows(i).Item("AccountNo"), Me.DateEditFrom.DateTime, Me.DateEditTo.DateTime)
        Next

        'الاقسام
        sqlstring = " SELECT distinct(S.[CategoryID]),C.CategoryName FROM [dbo].[Samba_ShishaExpensesAllocationDefine] S left join ItemsCategories C on S.CategoryID=C.CategoryID"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _HeaderTables = sql.SQLDS.Tables(0)
        Dim CategoriesTable As New DataTable()
        CategoriesTable.Columns.Add("ExpensesName", GetType(String))
        CategoriesTable.Columns.Add("ExpensesNo", GetType(String))
        CategoriesTable.Columns.Add("AccountBalance", GetType(Decimal))
        CategoriesTable.Columns.Add("TotalBalance", GetType(Decimal))
        For i = 0 To _HeaderTables.Rows.Count - 1
            CategoriesTable.Columns.Add(_HeaderTables.Rows(i).Item("CategoryName"), GetType(String))
            '  GridViewAllocateExpensesOnCategories.Columns(_HeaderTables.Rows(i).Item("CategoryName")).Summary.Add(siCategoryName)
        Next

        'add rows to CategoriesTable 
        For i = 0 To _ExpenseTable.Rows.Count - 1
            Dim _AccountNo As String = _ExpenseTable.Rows(i).Item("AccountNo")
            Dim _AccountName As String = GetFinancialAccountsData(_AccountNo).AccName
            Dim _AccountBalance As Decimal = GetAccountBalanceWithPeriod(_AccountNo, Me.DateEditFrom.DateTime, Me.DateEditTo.DateTime)
            Dim _Row As DataRow = CategoriesTable.NewRow()
            _Row("ExpensesName") = _AccountName
            _Row("ExpensesNo") = _AccountNo
            _Row("AccountBalance") = _AccountBalance
            For j = 0 To _HeaderTables.Rows.Count - 1
                Dim _CategoryName As String = _HeaderTables.Rows(j).Item("CategoryName")
                Dim _CategoryPercentage As Decimal = GetExpensePercentageByCategory(_AccountNo, _CategoryName).Percentage
                _Row(_CategoryName) = (_CategoryPercentage * _AccountBalance / 100).ToString("n2")
                _Row("TotalBalance") += _Row(_CategoryName)
            Next
            CategoriesTable.Rows.Add(_Row)
        Next
        GridControlAllocateExpensesOnCategories.DataSource = CategoriesTable
        GridViewAllocateSalariesOnCategories.Columns("ExpensesNo").OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False
        GridViewAllocateSalariesOnCategories.Columns("AccountBalance").OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False


        _AllocateExpensesOnCategories = CategoriesTable


        GridViewAllocateSalariesOnCategories.Columns("TotalBalance").Summary.Add(siTotal)
        GridViewAllocateSalariesOnCategories.Columns("AccountBalance").Summary.Add(siTotal0)

        GridViewAllocateSalariesOnCategories.Columns(4).Summary.Add(si1)
        GridViewAllocateSalariesOnCategories.Columns(5).Summary.Add(si2)
        GridViewAllocateSalariesOnCategories.Columns(6).Summary.Add(si3)
        'GridViewAllocateSalariesOnCategories.Columns(7).Summary.Add(si4)


        FillExpensesChart()
    End Sub
    Private Sub FillExpensesChart()
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [ID],S.[AccountNo],F.AccName,[CategoryID],[CategoryName],[TotalCost],[DateFrom],[DateTo]  
FROM [Samba_ShishaExpensesAllocationAmounts] S
Left Join FinancialAccounts F on S.[AccountNo]=F.AccNo Where [DateFrom]='" & _dateFrom & "' and [DateTo] ='" & _date__To & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        ChartControlExpenses.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub BtnSaveAllocationExpenses_Click(sender As Object, e As EventArgs) Handles BtnSaveAllocationExpenses.Click
        SaveExpensesAllocation()
    End Sub
    Private Sub SaveExpensesAllocation()
        Dim sql As New SQLControl
        Dim Sqlstring As String
        sql.SqlTrueAccountingRunQuery(" Delete from [Samba_ShishaExpensesAllocationAmounts] 
                                        where DateFrom='" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'")
        Dim _AcountNo As String
        Dim _AcountAmount As String
        For i = 0 To _ExpenseTable.Rows.Count - 1
            _AcountNo = _ExpenseTable.Rows(i).Item("AccountNo")
            _AcountAmount = _ExpenseTable.Rows(i).Item("AcountAmount")
            Dim _CategoryID As String
            Dim _CategoryName As String
            For j = 0 To _HeaderTables.Rows.Count - 1
                _CategoryID = _HeaderTables.Rows(j).Item("CategoryID")
                _CategoryName = _HeaderTables.Rows(j).Item("CategoryName")
                Dim _CategoryPercentage As Decimal = GetExpensePercentageByCategory(_AcountNo, _CategoryName).Percentage
                Dim _AccountAmount As Decimal = (_CategoryPercentage * _AcountAmount / 100).ToString("n2")
                Sqlstring = " INSERT INTO [dbo].[Samba_ShishaExpensesAllocationAmounts]
                                ([AccountNo],[CategoryID],[CategoryName],[TotalCost],[DateFrom],[DateTo])
                                VALUES
                               ('" & _AcountNo & "'
                               ," & _CategoryID & "
                               ,N'" & _CategoryName & "'
                               ," & _AccountAmount & "
                               ,'" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                               ,'" & Format(Me.DateEditTo.DateTime, "yyyy-MM-dd") & "')"
                sql.SqlTrueAccountingRunQuery(Sqlstring)

            Next
        Next
        MsgBoxShowSuccess(" تم حفظ البيانات بنجاح")
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetIncomeStatment()
        VGridControl1.Appearance.FocusedRow.Assign(VGridControl1.ViewInfo.PaintAppearance.RowHeaderPanel)
    End Sub
    Private Sub GetIncomeStatment()
        VGridControl1.OptionsView.ShowCaption = True
        VGridControl1.Caption = "تقرير الأرباح للأقسام "
        VGridControl1.CaptionHeight = 50


        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        sqlstring = "  
  Select Z.CategoryID,Z.CategoryName,Z.TotalSales,Z.TotalCost,(Z.TotalCost / Z.TotalSales)*100 as CostPercentage,(Z.TotalSales-Z.TotalCost) as ProfitMargine,
 Case when (Z.TotalSales-Z.TotalCost) >0 then (Z.TotalSales-Z.TotalCost)/ Z.TotalSales*100 else 0 end as MarginePercentage,IsNull(Z.TotalExpense,0) as TotalExpense ,Z.TotalExpense2,((IsNull(Z.TotalExpense,0)+Z.TotalExpense2)/Z.TotalSales)*100 as ExpensesPercentage,
Z.NetProfit , Case when Z.NetProfit >0 then (Z.NetProfit/Z.TotalSales)*100 else 0 end as ProfitPercentage 
From 
 (
Select A.CategoryID,A.CategoryName,B.TotalSales,IsNull(C.TotalCost,0) as TotalCost ,D.TotalExpense,E.TotalExpense2,(B.TotalSales-IsNull(C.TotalCost,0)-IsNull(D.TotalExpense,0)-IsNull(E.TotalExpense2,0)) as NetProfit,
case when (B.TotalSales-IsNull(C.TotalCost,0)-D.TotalExpense) > 0 then (B.TotalSales-IsNull(C.TotalCost,0)-D.TotalExpense)/ B.TotalSales*100 end As ProfitPercentage
From  
(
SELECT [CategoryID],CategoryName From  ItemsCategories 
) A
Left Join 
(
Select CategoryID,IsNull(Sum(SalesSUM),0) As TotalSales from Samba_ShishaReportSales where [DateFrom]='" & _dateFrom & "' and [DateTo]='" & _date__To & "' Group By CategoryID
) B
On A.CategoryID=b.CategoryID
Left Join 
(
Select CategoryID,IsNull(Sum(TotalCost),0) as TotalCost  From [Samba_ShishaReportCostOfSales] where [DateFrom]='" & _dateFrom & "' and [DateTo]='" & _date__To & "' Group By CategoryID
) C
On A.CategoryID=C.CategoryID
Left Join 
(
Select CategoryID,IsNull(Sum(TotalCost),0) as TotalExpense from [Samba_ShishaExpensesAllocationAmounts] where [DateFrom]='" & _dateFrom & "' and [DateTo]='" & _date__To & "' Group By CategoryID
) D
On A.CategoryID=D.CategoryID
left join
(
Select CategoryID,IsNull(Sum(TotalCost),0) as TotalExpense2 from [Samba_ShishaExpensesAllocationAmounts2] where [DateFrom]='" & _dateFrom & "' and [DateTo]='" & _date__To & "' Group By CategoryID
) E
On A.CategoryID=E.CategoryID
) Z"
        Dim _ChartTable As New DataTable
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _ChartTable = sql.SQLDS.Tables(0)
        ChartControl1.DataSource = _ChartTable
        Dim _Verticaltable As DataTable
        _Verticaltable = sql.SQLDS.Tables(0)
        Dim _AragelCost As Decimal

        For i = 0 To _Verticaltable.Rows.Count - 1
            If _Verticaltable.Rows(i).Item("CategoryName") = "اراجيل" Then
                'If IsDBNull(_Verticaltable.Rows(i).Item("TotalSales")) Then _Verticaltable.Rows(i).Item("TotalSales") = 0
                _AragelCost = (_Verticaltable.Rows(i).Item("TotalSales") - (_Verticaltable.Rows(i).Item("TotalSales") * 0.16)) * 0.5
                    _Verticaltable.Rows(i).Item("TotalCost") = _AragelCost
                    _Verticaltable.Rows(i).Item("CostPercentage") = (_AragelCost / _Verticaltable.Rows(i).Item("TotalSales")) * 100
                    _Verticaltable.Rows(i).Item("ProfitMargine") = _Verticaltable.Rows(i).Item("TotalSales") - _AragelCost
                    _Verticaltable.Rows(i).Item("MarginePercentage") = (_Verticaltable.Rows(i).Item("ProfitMargine") / _Verticaltable.Rows(i).Item("TotalSales")) * 100
                    _Verticaltable.Rows(i).Item("NetProfit") = _Verticaltable.Rows(i).Item("ProfitMargine") - _Verticaltable.Rows(i).Item("TotalExpense") - _Verticaltable.Rows(i).Item("TotalExpense2")
                    _Verticaltable.Rows(i).Item("ProfitPercentage") = ((_Verticaltable.Rows(i).Item("NetProfit") / _Verticaltable.Rows(i).Item("TotalSales")) * 100)
                End If
        Next


        Dim _Row As DataRow = _Verticaltable.NewRow()
        _Row("CategoryID") = -1
        _Row("CategoryName") = "المجموع"
        Dim _TotalSales As Decimal = 0
        Dim _TotalCost As Decimal = 0
        Dim _ProfitMargine As Decimal = 0
        Dim _MarginePercentage As Decimal = 0
        Dim _TotalExpense As Decimal = 0
        Dim _TotalExpense2 As Decimal = 0
        Dim _NetProfit As Decimal = 0
        Dim _ProfitPercentage As Decimal = 0
        For j = 0 To _Verticaltable.Rows.Count - 1
            _TotalSales += _Verticaltable.Rows(j).Item("TotalSales")
            _TotalCost += _Verticaltable.Rows(j).Item("TotalCost")
            _ProfitMargine += _Verticaltable.Rows(j).Item("ProfitMargine")
            _TotalExpense += _Verticaltable.Rows(j).Item("TotalExpense")
            _TotalExpense2 += _Verticaltable.Rows(j).Item("TotalExpense2")
            _NetProfit += _Verticaltable.Rows(j).Item("NetProfit")
        Next
        _Row("TotalSales") = _TotalSales
        _Row("TotalCost") = _TotalCost
        If _TotalSales > 0 Then _Row("CostPercentage") = (_TotalCost / _TotalSales) * 100
        _Row("ProfitMargine") = _ProfitMargine
        If _TotalSales > 0 Then _Row("MarginePercentage") = (_ProfitMargine / _TotalSales) * 100
        _Row("TotalExpense") = _TotalExpense
        _Row("TotalExpense2") = _TotalExpense2
        _Row("NetProfit") = _NetProfit
        _Row("ExpensesPercentage") = ((_TotalExpense + _TotalExpense2) / _TotalSales) * 100
        If _TotalSales > 0 Then _Row("ProfitPercentage") = ((_NetProfit / _TotalSales) * 100).ToString("n2")
        _Verticaltable.Rows.Add(_Row)
        VGridControl1.DataSource = _Verticaltable


        'ChartControl2.DataSource = sql.SQLDS.Tables(0)
    End Sub

    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
    '    VGridControl1.ShowPrintPreview()
    'End Sub




    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        GetExpenses()
    End Sub
    Private Sub GetExpenses()
        Dim siTotal As New GridColumnSummaryItem()
        siTotal.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal.DisplayFormat = "{0:n2}"

        Dim siTotal2 As New GridColumnSummaryItem()
        siTotal2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal2.DisplayFormat = "{0:n2}"

        Dim siTotal3 As New GridColumnSummaryItem()
        siTotal3.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal3.DisplayFormat = "{0:n2}"

        Dim siTotal4 As New GridColumnSummaryItem()
        siTotal4.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal4.DisplayFormat = "{0:n2}"

        Dim siTotal5 As New GridColumnSummaryItem()
        siTotal5.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal5.DisplayFormat = "{0:n2}"

        Dim siTotal6 As New GridColumnSummaryItem()
        siTotal6.SummaryType = DevExpress.Data.SummaryItemType.Sum
        siTotal6.DisplayFormat = "{0:n2}"

        GridViewExpensesPercentage.PopulateColumns()
        'Dim _HeaderTables As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        'المصاريف
        'Dim _ExpenseTable As DataTable
        Dim _dateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim _date__To As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        sqlstring = " SELECT AccNo as AccountNo, AccName as AccountName,isnull(Debit,0)-isnull(Credit,0) as Balance
                            FROM 
                            (Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts F where FinancialSector=8 and not EXISTS (select AccountNo from Samba_ShishaExpensesAllocationDefine S where S.AccountNo=F.AccNo )) t0
                            left join
                            (select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount     from Journal where DocStatus <> 0 And DocDate  between '" & _dateFrom & "' and '" & _date__To & "'  group by DebitAcc) t1
                            ON (t0.AccNo = t1.DebitAcc)
                            left JOIN
                            (select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate  between '" & _dateFrom & "' and '" & _date__To & "'  group by CredAcc) t2
                            ON (t0.AccNo = t2.CredAcc)
                            where  isnull(Debit,0)-isnull(Credit,0) <> 0   "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _ExpenseTable = sql.SQLDS.Tables(0)

        'الاقسام
        sqlstring = " SELECT CategoryID,CategoryName  FROM  ItemsCategories  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _HeaderTables = sql.SQLDS.Tables(0)
        Dim CategoriesTable As New DataTable()
        CategoriesTable.Columns.Add("ExpensesName", GetType(String))
        CategoriesTable.Columns.Add("ExpensesNo", GetType(String))
        CategoriesTable.Columns.Add("Balance", GetType(Decimal))
        CategoriesTable.Columns.Add("Total", GetType(Decimal))
        For i = 0 To _HeaderTables.Rows.Count - 1
            CategoriesTable.Columns.Add(_HeaderTables.Rows(i).Item("CategoryName"), GetType(String))
        Next

        'add rows to CategoriesTable 
        For i = 0 To _ExpenseTable.Rows.Count - 1
            Dim _AccountNo As String = _ExpenseTable.Rows(i).Item("AccountNo")
            Dim _AccountName As String = _ExpenseTable.Rows(i).Item("AccountName")
            Dim _Row As DataRow = CategoriesTable.NewRow()
            _Row("ExpensesName") = _AccountName
            _Row("ExpensesNo") = _AccountNo
            Dim _Total As Decimal = 0
            For j = 0 To _HeaderTables.Rows.Count - 1
                Dim _CategoryName As String = _HeaderTables.Rows(j).Item("CategoryName")
                Dim _CategoryAmount As Decimal = CDec(GetExpensePercentageByCategory2(_AccountNo, _CategoryName).Amount)
                _Total += _CategoryAmount
                _Row(_CategoryName) = _CategoryAmount.ToString("n2")
                _Row("Total") = _Total.ToString("n2")
                _Row("Balance") = GetAccountBalanceWithPeriod(_AccountNo, Me.DateEditFrom.DateTime, Me.DateEditTo.DateTime).ToString("n2")
            Next
            CategoriesTable.Rows.Add(_Row)
        Next

        GridViewExpensesPercentage.OptionsMenu.ShowFooterItem = True


        'Dim _CategoryName As String = _HeaderTables.Rows(j).Item("CategoryName")

        ' GridViewAllocateSalariesOnCategories.Columns(5).Summary.Add(siTotal)



        GridControlSalariesPercentage.DataSource = CategoriesTable
        GridViewExpensesPercentage.BestFitColumns()
        GridViewExpensesPercentage.Columns("ExpensesNo").OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False
        GridViewExpensesPercentage.Columns("Balance").OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False
        'MsgBox(_HeaderTables.Rows.Count)

        GridViewExpensesPercentage.Columns(2).Summary.Add(siTotal6)
        GridViewExpensesPercentage.Columns(3).Summary.Add(siTotal5)
        GridViewExpensesPercentage.Columns(4).Summary.Add(siTotal)
        GridViewExpensesPercentage.Columns(5).Summary.Add(siTotal2)
        GridViewExpensesPercentage.Columns(6).Summary.Add(siTotal3)
        GridViewExpensesPercentage.Columns(7).Summary.Add(siTotal4)

    End Sub
    Private Function GetExpensePercentageByCategory2(_AccountNo As String, _CategoryName As String) As (Percentage As Decimal, Amount As Decimal)
        Dim _Percentage As Decimal
        Dim _Balance As Decimal
        Dim _Amount As Decimal
        Dim _ID As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select ID,PercentageOfTotal as Percantage from Samba_ShishaReportSales   
                      Where  CategoryName=N'" & _CategoryName & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _Percentage = sql.SQLDS.Tables(0).Rows(0).Item("Percantage")
            _Balance = GetAccountBalanceWithPeriod(_AccountNo, Me.DateEditFrom.DateTime, Me.DateEditTo.DateTime)
            _Amount = _Percentage * _Balance / 100
            _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
        Else
            _Percentage = 0
            _ID = 0
        End If
        Return (_Percentage, _Amount)
    End Function
    Private Function GetExpensePercentageDependOnSalesByCategoryForRawateb(_AccountNo As String, _CategoryName As String) As (Percentage As Decimal, Amount As Decimal)
        Dim _Percentage As Decimal
        Dim _Balance As Decimal
        Dim _Amount As Decimal
        Dim _ID As Integer
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select ID,PercentageOfTotal as Percantage from Samba_ShishaReportSales   
                      Where  CategoryName=N'" & _CategoryName & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _Percentage = sql.SQLDS.Tables(0).Rows(0).Item("Percantage")
            _Balance = GetAccountBalanceWithPeriod(_AccountNo, Me.DateEditFrom.DateTime, Me.DateEditTo.DateTime)
            _Amount = _Percentage * _Balance / 100
            _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
        Else
            _Percentage = 0
            _ID = 0
        End If
        Return (_Percentage, _Amount)
    End Function

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SaveExpensesAllocation2()
    End Sub
    Private Sub SaveExpensesAllocation2()
        Dim sql As New SQLControl
        Dim Sqlstring As String
        sql.SqlTrueAccountingRunQuery(" Delete from [Samba_ShishaExpensesAllocationAmounts2] 
                                        where DateFrom='" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'")
        Dim _AcountNo As String
        Dim _AcountAmount As String
        For i = 0 To _ExpenseTable.Rows.Count - 1
            _AcountNo = _ExpenseTable.Rows(i).Item("AccountNo")
            _AcountAmount = _ExpenseTable.Rows(i).Item("Balance")
            Dim _CategoryID As String
            Dim _CategoryName As String
            For j = 0 To _HeaderTables.Rows.Count - 1
                _CategoryID = _HeaderTables.Rows(j).Item("CategoryID")
                _CategoryName = _HeaderTables.Rows(j).Item("CategoryName")
                Dim _CategoryPercentage As Decimal = GetExpensePercentageByCategory(_AcountNo, _CategoryName).Percentage
                Dim _AccountAmount As Decimal = CDec(GetExpensePercentageByCategory2(_AcountNo, _CategoryName).Amount)
                Sqlstring = " INSERT INTO [dbo].[Samba_ShishaExpensesAllocationAmounts2]
                                ([AccountNo],[CategoryID],[CategoryName],[TotalCost],[DateFrom],[DateTo])
                                VALUES
                               ('" & _AcountNo & "'
                               ," & _CategoryID & "
                               ,N'" & _CategoryName & "'
                               ," & _AccountAmount & "
                               ,'" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                               ,'" & Format(Me.DateEditTo.DateTime, "yyyy-MM-dd") & "')"
                sql.SqlTrueAccountingRunQuery(Sqlstring)

            Next
        Next
        MsgBoxShowSuccess(" تم حفظ البيانات بنجاح")
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        TabbedControlGroup1.SelectedTabPage = TabSalaryAllocateTable
    End Sub



    Private Sub PrintReport(_WhatsApp As Boolean)
        ' Create objects and define event handlers.
        Dim composLink As CompositeLink = New CompositeLink(New PrintingSystem())
        AddHandler composLink.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
        Dim pcLink1 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink2 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink3 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink4 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink5 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink6 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink7 As PrintableComponentLink = New PrintableComponentLink()
        Dim pcLink8 As PrintableComponentLink = New PrintableComponentLink()
        Dim linkMainReport As Link = New Link()
        AddHandler linkMainReport.CreateDetailArea, AddressOf linkMainReport_CreateDetailArea
        Dim linkGrid1Report As Link = New Link()
        AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
        Dim linkGrid2Report As Link = New Link()
        AddHandler linkGrid2Report.CreateDetailArea, AddressOf linkGrid2Report_CreateDetailArea
        Dim linkGrid3Report As Link = New Link()
        AddHandler linkGrid3Report.CreateDetailArea, AddressOf linkGrid3Report_CreateDetailArea
        Dim linkGrid4Report As Link = New Link()
        AddHandler linkGrid4Report.CreateDetailArea, AddressOf linkGrid4Report_CreateDetailArea
        Dim linkGrid5Report As Link = New Link()
        AddHandler linkGrid5Report.CreateDetailArea, AddressOf linkGrid5Report_CreateDetailArea
        ' Assign the controls to the printing links.
        pcLink1.Component = Me.GridControlSales
        pcLink2.Component = Me.ChartControlSales
        pcLink2.CustomPaperSize = New Size(100, 100)
        pcLink3.Component = Me.GridControlCostOfGoodsSold
        pcLink4.Component = Me.Chart1ControlCostOfGoodsSold
        pcLink4.CustomPaperSize = New Size(100, 100)
        pcLink5.Component = Me.GridControlAllocateExpensesOnCategories
        pcLink6.Component = Me.ChartControlExpenses
        pcLink6.CustomPaperSize = New Size(100, 100)
        pcLink7.Component = Me.GridControlSalariesPercentage
        pcLink8.Component = Me.VGridControl1

        ' Populate the collection of links in the composite link.
        ' The order of operations corresponds to the document structure.
        'composLink.BreakSpace = 100

        composLink.Links.Add(linkGrid1Report)
        composLink.Links.Add(pcLink1)
        composLink.BreakSpace = 100
        composLink.Links.Add(pcLink2)
        composLink.Links.Add(linkMainReport)

        composLink.Links.Add(linkGrid2Report)
        composLink.Links.Add(pcLink3)
        composLink.BreakSpace = 100
        composLink.Links.Add(pcLink4)
        composLink.Links.Add(linkMainReport)


        composLink.Links.Add(linkGrid3Report)
        composLink.Links.Add(pcLink5)
        composLink.BreakSpace = 100
        composLink.Links.Add(linkGrid4Report)
        composLink.Links.Add(pcLink7)
        composLink.BreakSpace = 100
        'composLink.Links.Add(pcLink6)
        composLink.Links.Add(linkMainReport)


        'composLink.Links.Add(linkGrid4Report)
        'composLink.Links.Add(pcLink7)
        'composLink.Links.Add(linkMainReport)


        composLink.Links.Add(linkGrid5Report)
        pcLink8.RightToLeftLayout = False
        composLink.Links.Add(pcLink8)


        'composLink.Links.Add(linkMainReport)
        'composLink.Links.Add(linkGrid2Report)

        ' Create the report and show the preview window.
        composLink.RightToLeftLayout = True

        If _WhatsApp = False Then
            composLink.ShowPreviewDialog()
        Else
            Dim myControl As New SendToWhatsAppNo()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                Dim _Title As String = "  التقرير الشهري للفترة من " & CStr(DateEditFrom.DateTime) & " إلى " & CStr(DateEditTo.DateTime)
                composLink.ExportToPdf("MonthlyReport.pdf")
                SendFileToWhatsApp(MobileNo, "MonthlyReport.pdf", _Title, "", "")
            End If
        End If

    End Sub

    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object,
    ByVal e As CreateAreaEventArgs)
        'e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}",
        '    Color.Black, New RectangleF(0, 0, 200, 50), DevExpress.XtraEditors.Controls.BorderSide.None)
    End Sub

    ' Creates a text header for the first grid.
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object,
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "أولا: المبيعات"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        e.Graph.DrawBrick(tb)
    End Sub

    ' Creates an interval between the grids and fills it with color.
    Private Sub linkMainReport_CreateDetailArea(ByVal sender As Object,
    ByVal e As CreateAreaEventArgs)
        'Dim tb As TextBrick = New TextBrick()
        'tb.Rect = New RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50)
        'tb.BackColor = Color.Gray
        'e.Graph.DrawBrick(tb)
        e.Graph.PrintingSystem.InsertPageBreak(0)
    End Sub


    ' Creates a text header for the second grid.
    Private Sub linkGrid2Report_CreateDetailArea(ByVal sender As Object,
    ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "ثانيا: تكلفة المبيعات"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        e.Graph.DrawBrick(tb)
    End Sub
    Private Sub linkGrid3Report_CreateDetailArea(ByVal sender As Object,
ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "ثالثا: الرواتب"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        e.Graph.DrawBrick(tb)
    End Sub
    Private Sub linkGrid4Report_CreateDetailArea(ByVal sender As Object,
ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "رابعا: المصاريف"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        e.Graph.DrawBrick(tb)
    End Sub
    Private Sub linkGrid5Report_CreateDetailArea(ByVal sender As Object,
ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "خامسا: الأرباح"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        e.Graph.DrawBrick(tb)
    End Sub
    Private Sub linkGrid6Report_CreateDetailArea(ByVal sender As Object,
ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        tb.Text = "خامسا: الأرباح"
        tb.Font = New Font("Arial", 15)
        tb.Rect = New RectangleF(0, 0, 300, 25)
        tb.BorderWidth = 1
        tb.BackColor = Color.Transparent
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Far
        tb.Sides = DevExpress.XtraPrinting.BorderSide.Bottom
        e.Graph.DrawBrick(tb)
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        GetSalesReportByCategory()
        GetCostOfGoodSold()
        AllocateExpensesOnCategories()
        GetExpenses()
        GetIncomeStatment()
        TabbedControlGroup1.SelectedTabPage = TabMonthReport
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PrintReport(False)
    End Sub

    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        PrintReport(True)
    End Sub
    Private Sub CreateChart()
        ' Create an empty chart.
        Dim pieChart As New ChartControl()

        pieChart.Titles.Add(New ChartTitle() With {.Text = "Land Area by Country"})

        ' Create a pie series.
        Dim series1 As New Series("Land Area by Country", ViewType.Pie)

        ' Bind the series to data.
        ' series1.DataSource = DataPoint.GetDataPoints()
        series1.ArgumentDataMember = "Argument"
        series1.ValueDataMembers.AddRange(New String() {"Value"})

        ' Add the series to the chart.
        pieChart.Series.Add(series1)

        ' Format the the series labels.
        series1.Label.TextPattern = "{VP:p0} ({V:.##}M km²)"

        ' Format the series legend items.
        series1.LegendTextPattern = "{A}"

        ' Adjust the position of series labels. 
        CType(series1.Label, PieSeriesLabel).Position = PieSeriesLabelPosition.TwoColumns

        ' Detect overlapping of series labels.
        CType(series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

        ' Access the view-type-specific options of the series.
        Dim myView As PieSeriesView = CType(series1.View, PieSeriesView)

        ' Specify a data filter to explode points.
        myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9))
        myView.ExplodedPointsFilters.Add(New SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"))
        myView.ExplodeMode = PieExplodeMode.UseFilters
        myView.ExplodedDistancePercentage = 30
        myView.RuntimeExploding = True

        ' Customize the legend.
        pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True

        ' Add the chart to the form.
        pieChart.Dock = DockStyle.Fill
        Me.Controls.Add(pieChart)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim F3 As New StockMoveReport
        With F3
            '.GridColumn4.Visible = False
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.GridViewCostOfGoodsSoldDetails.GetRowCellValue(GridViewCostOfGoodsSoldDetails.FocusedRowHandle, "ItemNo")
            '.TextPurchaseOrSale.Text = 1
            '.TextItemName.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName")
            .Text = "حركة صنف ( " & Me.GridViewCostOfGoodsSoldDetails.GetRowCellValue(GridViewCostOfGoodsSoldDetails.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .RefreshData()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub VGridControl1_RecordCellStyle(sender As Object, e As DevExpress.XtraVerticalGrid.Events.GetCustomRowCellStyleEventArgs) Handles VGridControl1.RecordCellStyle

    End Sub
End Class