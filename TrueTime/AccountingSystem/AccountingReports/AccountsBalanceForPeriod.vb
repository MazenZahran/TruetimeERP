Imports DevExpress.XtraPrinting

Public Class AccountsBalanceForPeriod
	Public _RefOrAccount As String

	Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
		Select Case _RefOrAccount
			Case "Ref"
				GetBalancesForReferances()
			Case "Account"
				GetBalancesForAccounts()
		End Select
	End Sub
	Private Sub GetBalancesForAccounts()
		If Me.Currency.EditValue <> -1 Then
			gridBand2.Visible = False
			gridBand3.Visible = True
		Else
			gridBand2.Visible = True
			gridBand3.Visible = False
		End If
		Dim Sql As New SQLControl
		Dim sqlString As String
		sqlString = "  
Declare @DateFrom Date
Declare @DateTo Date
Set @DateFrom='" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "'
Set @DateTo='" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "'

Select BeginBalance.AccNo,BeginBalance.AccName,BeginBalance.BalanceAtBegining,BeginBalance.BalanceAtBeginingByAccCurr,Debit.DebitDuringPeriod,Debit.DebitDuringPeriodByAccCurr,Credit.CreditDuringPeriod,Credit.CreditDuringPeriodByAccCurr,EndBalance.EndBalance,EndBalance.EndBalanceByAccCurr From 
(
SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,isnull(Debit,0)-isnull(Credit,0) as BalanceAtBegining,Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0) as BalanceAtBeginingByAccCurr
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts f 		    "
		If Me.Currency.EditValue <> -1 Then sqlString += "  where f.Currency=" & Me.Currency.EditValue
		sqlString += " ) t0 
left join
(select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount from Journal where DocStatus <> 0 And DocDate <@DateFrom   group by DebitAcc) t1 ON (t0.AccNo = t1.DebitAcc)
left JOIN
(select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate <@DateFrom  group by CredAcc ) t2 ON (t0.AccNo = t2.CredAcc)
) BeginBalance

Left Join
(
SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,isnull(Debit,0) as DebitDuringPeriod,Isnull(DebitBaseAmount,0)  as DebitDuringPeriodByAccCurr
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts) t0
left join
(select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount from Journal where DocStatus <> 0 And DocDate between @DateFrom And  @DateTo    group by DebitAcc) t1 ON (t0.AccNo = t1.DebitAcc)
) Debit 
on BeginBalance.AccNo=Debit.AccNo

Left Join
(
SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,isnull(Credit,0) as CreditDuringPeriod, IsNull(CreditBaseAmount,0) as CreditDuringPeriodByAccCurr
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts) t0
left JOIN
(select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate between @DateFrom And  @DateTo   group by CredAcc ) t2 ON (t0.AccNo = t2.CredAcc)
) Credit 
on BeginBalance.AccNo=Credit.AccNo

left Join 
(
SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,isnull(Debit,0)-isnull(Credit,0) as EndBalance,Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0) as EndBalanceByAccCurr
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts) t0
left join
(select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount from Journal where DocStatus <> 0 And DocDate <= @DateTo   group by DebitAcc) t1 ON (t0.AccNo = t1.DebitAcc)
left JOIN
(select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate <= @DateTo  group by CredAcc ) t2 ON (t0.AccNo = t2.CredAcc) 
) EndBalance 
on BeginBalance.AccNo=EndBalance.AccNo
  "
		Sql.SqlTrueTimeRunQuery(sqlString)
		Me.GridControl1.DataSource = Sql.SQLDS.Tables(0)
		BandedGridView1.BestFitColumns()
	End Sub
	Private Sub GetBalancesForReferances()
		Dim Sql As New SQLControl
		Dim sqlString As String
		sqlString = "  Declare @DateFrom Date
Declare @DateTo Date
Set @DateFrom='" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "'
Set @DateTo='" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "'
Select  A.RefNo As AccNo,A.RefName As AccName,A.RefTypeName,
          RefAccID,A.RefType, A.RefMobile,A.RefPhone,A.RefEmail,A.CITY,IsNull(A.RefMemo,'') As RefMemo,Address,SortName,A.SalesMan,
		  IsNull(B.BalanceAtBegining,0) as BalanceAtBegining ,IsNull(C.DebitDuringPeriod,0) as DebitDuringPeriod ,IsNull(E.CreditDuringPeriod,0) as CreditDuringPeriod,IsNull(D.EndBalance,0) as EndBalance
		  
FROM
	(SELECT RefNo,
			RefName,
			RefType,RefAccID,
			T.RefTypeName,
			RefMobile,RefPhone,RefEmail,SearchCity,RefMemo,R.Address,C.CITY,S.[SortName] as SortName,IsNull(E.EmployeeName,'') as SalesMan
	FROM Referencess R 
	Left Join ReferencesTypes T on R.RefType=T.TypeID 
	Left Join RefSorts S on R.RefSort=S.ID
	left join RefCities C on R.SearchCity=C.ID
	left Join EmployeesData E on E.EmployeeID=R.SalesMan
) A
LEFT JOIN
	(SELECT J.Referance AS AccNo,
	R.RefName AS AccName,
	CONVERT(DECIMAL(16, 2), SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END)) -CONVERT(DECIMAL(16, 2), SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) AS BalanceAtBegining
	FROM journal J
	LEFT JOIN Referencess R ON R.RefNo=J.Referance
	WHERE J.DocDate < @DateFrom  AND j.DocStatus<>0
		  AND (j.DebitAcc= R.RefAccID
		  OR j.CredAcc= R.RefAccID) GROUP BY Referance,RefName
) B 
ON A.RefNo=B.AccNo 
LEFT JOIN
	(SELECT J.Referance AS AccNo,
	R.RefName AS AccName,
	CONVERT(DECIMAL(16, 2), SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) ) AS DebitDuringPeriod
	FROM journal J
	LEFT JOIN Referencess R ON R.RefNo=J.Referance
	WHERE J.DocDate between @DateFrom And  @DateTo  AND j.DocStatus<>0
		  AND (j.DebitAcc= R.RefAccID
		  OR j.CredAcc= R.RefAccID) GROUP BY Referance,RefName
) C
ON A.RefNo=C.AccNo 
LEFT JOIN
	(SELECT J.Referance AS AccNo,
	R.RefName AS AccName,
	CONVERT(DECIMAL(16, 2), SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) AS CreditDuringPeriod
	FROM journal J
	LEFT JOIN Referencess R ON R.RefNo=J.Referance
	WHERE J.DocDate between @DateFrom And  @DateTo  AND j.DocStatus<>0
		  AND (j.DebitAcc= R.RefAccID
		  OR j.CredAcc= R.RefAccID) GROUP BY Referance,RefName
) E
ON A.RefNo=E.AccNo 
LEFT JOIN
	(SELECT J.Referance AS AccNo,
	R.RefName AS AccName,
	CONVERT(DECIMAL(16, 2), SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END)) - CONVERT(DECIMAL(16, 2), SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) AS EndBalance
	FROM journal J
	LEFT JOIN Referencess R ON R.RefNo=J.Referance
	WHERE J.DocDate <= @DateTo  AND j.DocStatus<>0
		  AND (j.DebitAcc= R.RefAccID
		  OR j.CredAcc= R.RefAccID) GROUP BY Referance,RefName
) D
ON A.RefNo=D.AccNo  "
		Sql.SqlTrueTimeRunQuery(sqlString)
		Me.GridControl1.DataSource = Sql.SQLDS.Tables(0)
		BandedGridView1.BestFitColumns()
	End Sub
	Private Sub RadioGroup3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup3.SelectedIndexChanged
		Select Case RadioGroup3.EditValue
			Case "last"
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

				Me.DateEdit2.DateTime = _todate
				Me.DateEdit1.DateTime = _fromdate
				If GlobalVariables._EndDate < Today Then
					DateEdit2.Enabled = False
					DateEdit2.DateTime = GlobalVariables._EndDate
				End If
			Case "current"
				Me.DateEdit2.DateTime = Today
				Dim startDt As New Date(Today.Year, Today.Month, 1)
				Me.DateEdit1.DateTime = startDt
				If GlobalVariables._EndDate < Today Then
					DateEdit2.Enabled = False
					DateEdit2.DateTime = GlobalVariables._EndDate
				End If
		End Select
	End Sub

	Private Sub AccountsBalanceForPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Currency.Properties.DataSource = GetCurrencyTableWithAll(True)
		Currency.EditValue = -1
		Select Case _RefOrAccount
			Case "Ref"
				GridColRefTypeName.Visible = True
				ColRefMobile.Visible = True
				gridBand3.Visible = False
				GridColRefTypeName.Visible = True
				ColRefPhone.Visible = False
				ColRefEmail.Visible = False
				ColSearchCity.Visible = False
				ColAddress.Visible = False
				ColSortName.Visible = False
				ColRefAccID.Visible = False
				ColSalesMan.Visible = False
				LayoutControlItemCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
			Case "Account"
				GridColRefTypeName.Visible = False
				ColRefMobile.Visible = False
				gridBand3.Visible = False
				GridColRefTypeName.Visible = False
				ColRefPhone.Visible = False
				ColRefEmail.Visible = False
				ColAddress.Visible = False
				ColSortName.Visible = False
				ColRefAccID.Visible = False
				ColSalesMan.Visible = False
				LayoutControlItemCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
		End Select

		RadioGroup3.EditValue = "last"
	End Sub

	Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
		GridControl1.ShowPrintPreview()
	End Sub
	Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs)
		Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
		pb.PageSettings.Landscape = False
		pb.PageSettings.LeftMargin = 0
		pb.PageSettings.RightMargin = 0
		TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
		Dim sql As New SQLControl
		Dim SQLString As String = "Select *  from CompanyData"
		sql.SqlTrueTimeRunQuery(SQLString)
		If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
		Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
		TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
{"  ", Now(), "Pages: [Page # of Pages #]"})
		TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
(" " & "كشف ارصدة الذمم  ")
		TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
		Dim _FromToDate As String = " من تاريخ:   " & DateEdit1.EditValue & " الى تاريخ: " & " " & DateEdit2.EditValue
		TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
	End Sub
End Class