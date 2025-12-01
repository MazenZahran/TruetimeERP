Imports DevExpress.XtraEditors
Imports DocumentFormat.OpenXml.Office2010.Drawing

Public Class SalaryTaxDeductionForInsentives
    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextMonth2.EditValueChanged, TextMonth3.EditValueChanged

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetEmployeeData(TextYear.EditValue, TextMonth1.EditValue, TextMonth2.EditValue, TextMonth3.EditValue)
    End Sub
    Private Function GetTaxableIncome(employeeID As Integer, year As Integer, month As Integer, grossSalary As Decimal) As Decimal
        Dim sql As New SQLControl
        Dim sqlString As String
        'If TextEdit1.Text = "1" Then
        sqlString = " Declare @ExchangeRate decimal(18,3)
        Set @ExchangeRate= ( Select top(1) ExchangePrice From SalariesTaxExchangePrice where [Year]=" & year & " And [Month]=" & month & " )

        Select  EmployeeID,EmployeeName,
        case when (AnualGrossSalaryNIS-IndividualDiscount-AnualTransport-UniversityAmount) < 0 then 0 else (AnualGrossSalaryNIS-IndividualDiscount-AnualTransport-UniversityAmount) end  As TaxableIncome From 
        (
          select R.EmployeeID,E.EmployeeName," & grossSalary & " As AverageTaxableIncome,BonusAmount+Additions As Additions,AbsenceAmount,
          (SalaryMonth) As GrossSalary,(" & grossSalary & ")*12 * @ExchangeRate As AnualGrossSalaryNIS,(" & grossSalary & ") * @ExchangeRate As GrossSalaryNIS,36000.00  As IndividualDiscount,
              CASE 
                WHEN UniversitySonNo = 1 THEN 6000
                WHEN UniversitySonNo >= 2 THEN 12000
                ELSE 0 
            END AS UniversityAmount,
        	    CASE 
                WHEN (" & grossSalary & ")*12 * @ExchangeRate * 0.1 <= 14004 THEN (" & grossSalary & ")*12 * @ExchangeRate * 0.1
                WHEN (" & grossSalary & ")*12 * @ExchangeRate * 0.1 > 14004 THEN 14004
                ELSE 0 
            END AS AnualTransport
          from [AttRawatebArchive] R
          left Join EmployeesData E on e.EmployeeID=R.EmployeeID
          where R.EmployeeID=" & employeeID & " AND YEAR(DateFrom) = " & year & " AND MONTH(DateFrom) =" & month & "
          ) B   "

            'Else
            '    sqlString = "-- Inputs
            'DECLARE @EmployeeID    int            = " & employeeID & ";      -- target employee
            'DECLARE @GrossSalary   decimal(19,6)  = " & grossSalary & ";   -- NEW: monthly gross (in your source currency)
            'DECLARE @ExchangeRate  decimal(18,3);
            'DECLARE @PeriodStart   date           = DATEFROMPARTS(2025, 9, 1);
            'DECLARE @PeriodEnd     date           =DATEFROMPARTS(2025, 9, 30);  -- 2025-10-01

            '-- Exchange rate for the target month
            'SELECT TOP (1) @ExchangeRate = ExchangePrice
            'FROM dbo.SalariesTaxExchangePrice
            'WHERE [Year] = YEAR(@PeriodStart) AND [Month] = MONTH(@PeriodStart);

            'WITH Raw AS
            '(
            '    SELECT
            '        r.EmployeeID,
            '        e.EmployeeName,
            '        r.SalaryMonth,
            '        r.BonusAmount,
            '        r.Additions,
            '        r.AbsenceAmount,
            '        e.UniversitySonNo
            '    FROM dbo.AttRawatebArchive AS r
            '    LEFT JOIN dbo.EmployeesData AS e
            '        ON e.EmployeeID = r.EmployeeID
            '    WHERE r.EmployeeID = @EmployeeID
            '      AND r.DateFrom  >= @PeriodStart
            '      AND r.DateFrom  <=  @PeriodEnd
            '),
            'Pay AS
            '(
            '    SELECT
            '        p.EmployeeID,
            '        OtherTaxableDeductions =
            '            SUM(CASE WHEN t.Taxable = 1 THEN COALESCE(p.PaymentAmount, 0) ELSE 0 END)
            '    FROM dbo.AttEmployeePayments AS p
            '    LEFT JOIN dbo.AttPaymentsTypes AS t
            '        ON t.ID = p.PaymentType
            '    WHERE p.EmployeeID = @EmployeeID
            '      AND p.PaymentDate >= @PeriodStart
            '      AND p.PaymentDate <=  @PeriodEnd
            '    GROUP BY p.EmployeeID
            '),
            'Base AS
            '(
            '    SELECT
            '        r.EmployeeID,
            '        r.EmployeeName,

            '        -- Keep source fields (not used in calc here, but may be useful to display)
            '        Additions       = COALESCE(r.BonusAmount, 0) + COALESCE(r.Additions, 0),
            '        AbsenceAmount   = COALESCE(r.AbsenceAmount, 0),

            '        -- Payments (Taxable)
            '        OtherTaxableDeductions = COALESCE(p.OtherTaxableDeductions, 0),

            '        -- NEW: drive all calculations from the parameter @GrossSalary
            '        GrossSalary          = COALESCE(@GrossSalary, 0),                         -- monthly (source currency)
            '        GrossSalaryNIS       = COALESCE(@GrossSalary, 0) * @ExchangeRate,         -- monthly NIS
            '        AnualGrossSalaryNIS  = COALESCE(@GrossSalary, 0) * 12 * @ExchangeRate,    -- annual NIS

            '        -- Exemptions
            '        IndividualDiscount   = CAST(36000.00 AS decimal(18,2)),
            '        UniversityAmount     = CAST(
            '                                   CASE
            '                                       WHEN COALESCE(r.UniversitySonNo, 0) = 1 THEN  6000
            '                                       WHEN COALESCE(r.UniversitySonNo, 0) >= 2 THEN 12000
            '                                       ELSE 0
            '                                   END AS decimal(18,2)
            '                                 ),
            '        AnualTransport       = CAST(
            '                                   CASE
            '                                       WHEN (COALESCE(@GrossSalary,0) * 12 * @ExchangeRate * 0.10) <= 14004
            '                                            THEN (COALESCE(@GrossSalary,0) * 12 * @ExchangeRate * 0.10)
            '                                       ELSE 14004
            '                                   END
            '                                   AS decimal(18,2)
            '                                 )
            '    FROM Raw AS r
            '    LEFT JOIN Pay AS p
            '        ON p.EmployeeID = r.EmployeeID
            ')
            'SELECT
            '    b.EmployeeID,
            '    b.EmployeeName,

            '    -- Side-by-side as requested
            '    b.AbsenceAmount,
            '    b.OtherTaxableDeductions,

            '    -- (Optional) expose the parameter-driven gross to verify inputs
            '    b.GrossSalary,
            '    b.GrossSalaryNIS,
            '    b.AnualGrossSalaryNIS,

            '    -- Final taxable income (never negative)
            '    TaxableIncome =
            '        CASE
            '            WHEN (b.AnualGrossSalaryNIS - b.IndividualDiscount - b.AnualTransport - b.UniversityAmount - b.AbsenceAmount-b.OtherTaxableDeductions) < 0
            '                THEN CAST(0 AS decimal(18,2))
            '            ELSE CAST((b.AnualGrossSalaryNIS - b.IndividualDiscount - b.AnualTransport - b.UniversityAmount-b.AbsenceAmount-b.OtherTaxableDeductions) AS decimal(18,2))
            '        END
            'FROM Base AS b;
            ' "

            'End If







            sql.SqlTrueTimeRunQuery(sqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return CDec(sql.SQLDS.Tables(0).Rows(0).Item("TaxableIncome"))
        Else
            Return 0 ' Or handle the case appropriately
        End If
    End Function
    Private Sub GetEmployeeData(year As Integer, month1 As Integer, month2 As Integer, month3 As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " SELECT 
    EmployeeID,
    EmployeeName,
    ISNULL(MAX(CASE WHEN [Month] = " & month1 & " THEN [GrossSalary] END), 0) AS [First],
    ISNULL(MAX(CASE WHEN [Month] = " & month2 & " THEN [GrossSalary] END), 0) AS [Second],
    ISNULL(MAX(CASE WHEN [Month] = " & month3 & " THEN [GrossSalary] END), 0) AS [Third],
    (
        ISNULL(MAX(CASE WHEN [Month] = " & month1 & " THEN [GrossSalary] END), 0) +
        ISNULL(MAX(CASE WHEN [Month] = " & month2 & " THEN [GrossSalary] END), 0) +
        ISNULL(MAX(CASE WHEN [Month] = " & month3 & " THEN [GrossSalary] END), 0)
    ) / 3.0 AS AverageTaxableIncome,0.0 As IncomeTax
FROM 
    SalaryTaxDeduction
WHERE 
    [Month] IN (" & month1 & ", " & month2 & ", " & month3 & ")
GROUP BY 
    EmployeeID, EmployeeName
Order By EmployeeID"
        sql.SqlTrueTimeRunQuery(sqlString)
        'GridControl1.DataSource = sql.SQLDS.Tables(0)
        Dim dt As New DataTable
        dt.Columns.Add("EmployeeID", GetType(Integer))
        dt.Columns.Add("EmployeeName", GetType(String))
        dt.Columns.Add("First", GetType(Decimal))
        dt.Columns.Add("Second", GetType(Decimal))
        dt.Columns.Add("Third", GetType(Decimal))
        dt.Columns.Add("AverageTaxableIncome", GetType(Decimal))
        dt.Columns.Add("IncomeTax", GetType(Decimal))
        dt.Columns.Add("FirstMonthTaxUSD", GetType(Decimal))
        dt.Columns.Add("SecondMonthTaxUSD", GetType(Decimal))
        dt.Columns.Add("ThirdMonthTaxUSD", GetType(Decimal))
        dt.Columns.Add("AverageMonthTaxUSD", GetType(Decimal))
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In sql.SQLDS.Tables(0).Rows
                Dim employeeID As Integer = CInt(row("EmployeeID"))
                Dim employeeName As String = row("EmployeeName").ToString()
                Dim First As Decimal = row("First")
                Dim Second As Decimal = row("Second")
                Dim Third As Decimal = row("Third")
                Dim AverageGrossSalary As Decimal = CDec(row("AverageTaxableIncome"))
                Dim taxableIncome As Decimal = GetTaxableIncome(employeeID, year, month3, AverageGrossSalary)

                Dim YearTax As Decimal = CalculateTotalTax(taxableIncome)
                Dim MonthTaxNIS As Decimal = (CDec(YearTax) / 12)
                Dim ExchangeRate As Decimal = GetExchangePrice(year, month3)
                Dim MonthTaxUSD = MonthTaxNIS / ExchangeRate

                Dim FirstMonthTaxUSD As Decimal = GetTaxIncome(employeeID, year, month1)
                Dim SecondMonthTaxUSD As Decimal = GetTaxIncome(employeeID, year, month2)
                Dim ThirdMonthTaxUSD As Decimal = GetTaxIncome(employeeID, year, month3)
                Dim AverageMonthTaxUSD As Decimal = MonthTaxUSD * 3 - (FirstMonthTaxUSD + SecondMonthTaxUSD)
                'Dim incomeTax As Decimal = CalculateTotalTax(Decimal.Parse(taxableIncome))
                dt.Rows.Add(employeeID, employeeName, First, Second, Third, taxableIncome, MonthTaxUSD, FirstMonthTaxUSD, SecondMonthTaxUSD, ThirdMonthTaxUSD, AverageMonthTaxUSD)
            Next
        End If
        GridControl1.DataSource = dt
    End Sub
    Private Function GetTaxIncome(employeeID As Integer, year As Integer, month As Integer) As Decimal
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "SELECT [MonthTaxUSD] FROM SalaryTaxDeduction WHERE EmployeeID = " & employeeID & " AND [Year] = " & year & " AND [Month] = " & month
        sql.SqlTrueTimeRunQuery(sqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return CDec(sql.SQLDS.Tables(0).Rows(0)("MonthTaxUSD"))
        Else
            Return 0 ' Or handle the case appropriately
        End If
    End Function
    Private Function GetExchangePrice(Year As Integer, Month As Integer) As Decimal
        Dim sql As New SQLControl
        Dim sqlString As String = "Select TOP 1 ExchangePrice From SalariesTaxExchangePrice Where Month=" & Month & " And Year=" & Year
        sql.SqlTrueAccountingRunQuery(sqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")
        Else
            Return 1
        End If
    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        Dim _Count As Integer = selectedRowHandles.Length

        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError(" لم يتم اختيار الموظفين ")
            Exit Sub
        End If

        If XtraMessageBox.Show(" هل تريد احتساب الضريبة لموظفين عدد " & _Count, "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _EmplID As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeID")
            Dim _SalaryData = GetSalaryDocumentIDAndStatusIfExist(_EmplID, GetMonthStartEnd(TextMonth3.EditValue, TextYear.EditValue).Item1, GetMonthStartEnd(TextMonth3.Text, TextYear.EditValue).Item2)
            If _SalaryData.DocStatus = 1 Then
                Exit For
            End If
            Dim _TaxAmount As Decimal = GridView1.GetRowCellValue(selectedRowHandles(i), "AverageMonthTaxUSD")
            Dim _Year As Integer = TextYear.Text
            Dim _Month As Integer = TextMonth3.Text
            Dim _MonthPeriod As String = _Year & "-" & _Month & "-" & "01"
            Dim sql As New SQLControl
            Dim sqlString As String = " Update AttRawatebArchive Set IncomeTAX=" & _TaxAmount.ToString("n2") & " Where [EmployeeID]=" & _EmplID & " And [DateFrom]='" & _MonthPeriod & "'"
            sql.SqlTrueAccountingRunQuery(sqlString)
            ReCalcSalaryDocument(_SalaryData.DocID)
        Next i

        'SaveSalaryDataToDatabase()
        'SaveExchangePrice()
        MsgBoxShowSuccess(" تم احتساب الضريبة بنجاح ")


    End Sub
    Private Function GetMonthStartEnd(ByVal month As Integer, ByVal year As Integer) As (DateTime, DateTime)
        ' Get the first day of the month
        Dim firstDay As DateTime = New DateTime(year, month, 1)

        ' Get the last day of the month
        Dim lastDay As DateTime = firstDay.AddMonths(1).AddDays(-1)

        ' Return as a tuple (VB.NET 2017+)
        Return (firstDay, lastDay)
    End Function

    Private Sub SalaryTaxDeductionForInsentives_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextYear.Text = DateTime.Now.Year.ToString()
        TextMonth1.EditValue = DateTime.Now.AddMonths(-2).Month
        TextMonth2.EditValue = DateTime.Now.AddMonths(-1).Month
        TextMonth3.EditValue = DateTime.Now.Month
    End Sub
End Class