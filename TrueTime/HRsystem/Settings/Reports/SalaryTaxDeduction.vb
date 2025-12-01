Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports TrueTime.My

Public Class SalaryTaxDeduction
    Private Sub SalaryTaxDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtExchangePrice.EditValue = TxtExchangePrice.EditValue + 1
        Me.TextMonth.EditValue = DateTime.Now.Month
        Me.TextYear.EditValue = DateTime.Now.Year
        TextEdit1.Text = 2
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlString As String

        ' Build @PeriodStart and @PeriodEnd from TextYear.Text and TextMonth.Text
        Dim period = GetMonthStartEnd(CInt(TextMonth.Text), CInt(TextYear.Text))
        Dim periodStartStr As String = period.Item1.ToString("yyyy-MM-dd")
        Dim periodEndStr As String = period.Item2.ToString("yyyy-MM-dd")

        If TextEdit1.Text = "2" Then
            sqlString = " DECLARE @ExchangeRate   decimal(18,4) = " & Me.TxtExchangePrice.EditValue & ";
            DECLARE @PeriodStart    date          = '" & periodStartStr & "';
            DECLARE @PeriodEnd      date          = '" & periodEndStr & "'


            ;WITH Raw AS
            (
                SELECT
                    r.EmployeeID,
                    r.EmployeeName,
                    SalaryMonth   = COALESCE(r.SalaryMonth,   0),
                    BonusAmount   = COALESCE(r.BonusAmount,   0),
                    Additions     = COALESCE(r.Additions,     0),
                    AbsenceAmount = COALESCE(r.AbsenceAmount, 0),
                    e.UniversitySonNo
                FROM [AttRawatebArchive] AS r
                LEFT JOIN dbo.EmployeesData AS e
                    ON e.EmployeeID = r.EmployeeID
                WHERE r.DateFrom >= @PeriodStart
                  AND r.DateFrom <=  @PeriodEnd
            ),
            Pay AS
            (
                SELECT
                    p.EmployeeID,
                    OtherTaxableDeductions = SUM(CASE WHEN t.Taxable = 1
                                                      THEN COALESCE(p.PaymentAmount, 0)
                                                      ELSE 0 END)
                FROM dbo.AttEmployeePayments AS p
                LEFT JOIN dbo.AttPaymentsTypes AS t
                    ON p.PaymentType = t.ID
                WHERE p.PaymentDate >= @PeriodStart
                  AND p.PaymentDate <=  @PeriodEnd
                GROUP BY p.EmployeeID
            ),
            Base AS
            (
                SELECT
                    r.EmployeeID,
                    r.EmployeeName,
                    -- Keep original inputs visible
                    r.SalaryMonth,
                    -- Your original intention: expose additions as Bonus + Additions
                    Additions = r.BonusAmount + r.Additions,
                    r.AbsenceAmount,

                    -- Payments
                    OtherTaxableDeductions = COALESCE(pay.OtherTaxableDeductions, 0),

                    -- Core salary base
                    GrossSalaryBase = (r.SalaryMonth + r.BonusAmount + r.Additions
                                       - r.AbsenceAmount - COALESCE(pay.OtherTaxableDeductions, 0)),

                    -- For later use
                    r.UniversitySonNo
                FROM Raw AS r
                LEFT JOIN Pay AS pay
                    ON pay.EmployeeID = r.EmployeeID
            )
            SELECT
                b.EmployeeID,
                b.EmployeeName,
                -- echo of original field names
                b.SalaryMonth,
                b.Additions,
                b.AbsenceAmount,

                b.OtherTaxableDeductions,

                -- Gross salary (monthly, USD per your original naming)
                GrossSalary    = b.GrossSalaryBase,
                GrossSalaryNIS = b.GrossSalaryBase * @ExchangeRate,

                -- Annualized in NIS
                AnualGrossSalaryNIS = b.GrossSalaryBase * 12 * @ExchangeRate,

                -- Exemptions
                IndividualDiscount  = CAST(36000.00 AS decimal(18,2)),
                UniversityAmount    = CAST(CASE
                                             WHEN b.UniversitySonNo = 1 THEN  6000
                                             WHEN b.UniversitySonNo >= 2 THEN 12000
                                             ELSE 0
                                           END AS decimal(18,2)),
                AnualTransport      = CAST(
                                           CASE
                                               WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                                    THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                               ELSE 14004
                                           END
                                           AS decimal(18,2)
                                         ),
                -- Total exemptions & taxable income
                TotalExemptions = CAST(36000.00 AS decimal(18,2))
                                  + CAST(CASE
                                           WHEN b.UniversitySonNo = 1 THEN  6000
                                           WHEN b.UniversitySonNo >= 2 THEN 12000
                                           ELSE 0
                                         END AS decimal(18,2))
                                  + CAST(
                                         CASE
                                             WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                                  THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                             ELSE 14004
                                         END
                                         AS decimal(18,2)
                                       ),

                TaxableIncome = CAST(
                                  CASE
                                      WHEN (b.GrossSalaryBase * 12 * @ExchangeRate)
                                           - ( 36000.00
                                             + CASE
                                                   WHEN b.UniversitySonNo = 1 THEN  6000
                                                   WHEN b.UniversitySonNo >= 2 THEN 12000
                                                   ELSE 0
                                               END
                                             + CASE
                                                   WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                                        THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                                   ELSE 14004
                                               END
                                             ) < 0
                                      THEN 0
                                      ELSE (b.GrossSalaryBase * 12 * @ExchangeRate)
                                           - ( 36000.00
                                             + CASE
                                                   WHEN b.UniversitySonNo = 1 THEN  6000
                                                   WHEN b.UniversitySonNo >= 2 THEN 12000
                                                   ELSE 0
                                               END
                                             + CASE
                                                   WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                                        THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                                   ELSE 14004
                                               END
                                             )
                                  END
                                  AS decimal(18,2)
                               ),

                -- Placeholders (you can replace with real brackets later)
                YearTax     = CAST(0.00 AS decimal(18,2)),
                MonthTaxNIS = CAST(0.00 AS decimal(18,2)),
                MonthTaxUSD = CAST(0.00 AS decimal(18,2))
            FROM Base AS b
            ORDER BY b.EmployeeID;
              "


        ElseIf TextEdit1.Text = "3" Then
            sqlString = "DECLARE @ExchangeRate   decimal(18,3) = 3.35;
DECLARE @PeriodStart    date          = '" & periodStartStr & "';
DECLARE @PeriodEnd      date          = '" & periodEndStr & "';  -- inclusive

;WITH Raw AS
(
    SELECT
        r.EmployeeID,
        r.EmployeeName,
        SalaryMonth   = COALESCE(r.SalaryMonth,   0),
        BonusAmount   = COALESCE(r.BonusAmount,   0),
        Additions     = COALESCE(r.Additions,     0),
        AbsenceAmount = COALESCE(r.AbsenceAmount, 0),
        e.UniversitySonNo
    FROM dbo.AttRawatebArchive AS r
    LEFT JOIN dbo.EmployeesData AS e
        ON e.EmployeeID = r.EmployeeID
    WHERE r.DateFrom >= @PeriodStart
      AND r.DateFrom <= @PeriodEnd
),
Pay AS
(
    SELECT
        p.EmployeeID,
        OtherTaxableDeductions =
            SUM(CASE WHEN t.Taxable = 1 THEN COALESCE(p.PaymentAmount, 0) ELSE 0 END)
    FROM dbo.AttEmployeePayments AS p
    LEFT JOIN dbo.AttPaymentsTypes AS t
        ON p.PaymentType = t.ID
    WHERE p.PaymentDate >= @PeriodStart
      AND p.PaymentDate <= @PeriodEnd
    GROUP BY p.EmployeeID
),
Adds AS
(
    -- Taxable additions/deductions from AttEmployeeAdditions ⟂ AttAdditionsTypes
    SELECT
        a.EmployeeID,
        OtherAdditionsDeductions =
            SUM(CASE WHEN at.Taxable = 1 THEN COALESCE(a.AdditionAmount, 0) ELSE 0 END)
    FROM dbo.AttEmployeeAdditions AS a
    LEFT JOIN dbo.AttAdditionsTypes AS at
        ON at.ID = a.AdditionType
    WHERE a.AdditionDate >= @PeriodStart
      AND a.AdditionDate <= @PeriodEnd
    GROUP BY a.EmployeeID
),
Base AS
(
    SELECT
        r.EmployeeID,
        r.EmployeeName,
        r.SalaryMonth,
        r.BonusAmount,
        r.Additions,
        r.AbsenceAmount,

        OtherTaxableDeductions   = COALESCE(pay.OtherTaxableDeductions, 0),
        OtherAdditionsDeductions = COALESCE(adds.OtherAdditionsDeductions, 0),

        -- Core salary base (unchanged)
        GrossSalaryBase = (r.SalaryMonth + r.BonusAmount + r.Additions
                           - r.AbsenceAmount - COALESCE(pay.OtherTaxableDeductions, 0)),

        r.UniversitySonNo
    FROM Raw  AS r
    LEFT JOIN Pay  AS pay  ON pay.EmployeeID  = r.EmployeeID
    LEFT JOIN Adds AS adds ON adds.EmployeeID = r.EmployeeID
)
SELECT
    b.EmployeeID,
    b.EmployeeName,
    b.SalaryMonth,
    b.AbsenceAmount,
    b.OtherTaxableDeductions,
    b.OtherAdditionsDeductions,

    -- Monthly gross & annual (NIS)
    GrossSalary          = b.GrossSalaryBase,
    GrossSalaryNIS       = b.GrossSalaryBase * @ExchangeRate,
    AnualGrossSalaryNIS  = b.GrossSalaryBase * 12 * @ExchangeRate,

    -- Exemptions
    IndividualDiscount  = CAST(36000.00 AS decimal(18,2)),
    UniversityAmount    = CAST(CASE
                                 WHEN b.UniversitySonNo = 1 THEN  6000
                                 WHEN b.UniversitySonNo >= 2 THEN 12000
                                 ELSE 0
                               END AS decimal(18,2)),
    AnualTransport      = CAST(
                               CASE
                                   WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                        THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                   ELSE 14004
                               END
                               AS decimal(18,2)
                             ),

    -- Deduct annualized NIS value of OtherAdditionsDeductions
    TaxableIncome = CAST(
                      CASE
                        WHEN (b.GrossSalaryBase * 12 * @ExchangeRate)
                             - ( 36000.00
                               + CASE WHEN b.UniversitySonNo = 1 THEN  6000
                                      WHEN b.UniversitySonNo >= 2 THEN 12000
                                      ELSE 0 END
                               + CASE
                                   WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                        THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                   ELSE 14004
                                 END
                               )
                             - (b.OtherAdditionsDeductions * 12 * @ExchangeRate) < 0
                        THEN 0
                        ELSE (b.GrossSalaryBase * 12 * @ExchangeRate)
                             - ( 36000.00
                               + CASE WHEN b.UniversitySonNo = 1 THEN  6000
                                      WHEN b.UniversitySonNo >= 2 THEN 12000
                                      ELSE 0 END
                               + CASE
                                   WHEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10 <= 14004
                                        THEN (b.GrossSalaryBase * 12 * @ExchangeRate) * 0.10
                                   ELSE 14004
                                 END
                               )
                             - (b.OtherAdditionsDeductions * 12 * @ExchangeRate)
                      END
                      AS decimal(18,2)
                   ),

    YearTax     = CAST(0.00 AS decimal(18,2)),
    MonthTaxNIS = CAST(0.00 AS decimal(18,2)),
    MonthTaxUSD = CAST(0.00 AS decimal(18,2))
FROM Base AS b
ORDER BY b.EmployeeID;

"

        End If

        sql.SqlTrueTimeRunQuery(sqlString)
        Dim dataTable As New DataTable
        dataTable = sql.SQLDS.Tables(0)
        For i = 0 To dataTable.Rows.Count - 1
            dataTable.Rows(i).Item("YearTax") = CalculateTotalTax(dataTable.Rows(i).Item("TaxableIncome"))
            dataTable.Rows(i).Item("MonthTaxNIS") = (CDec(dataTable.Rows(i).Item("YearTax")) / 12)
            dataTable.Rows(i).Item("MonthTaxUSD") = (dataTable.Rows(i).Item("MonthTaxNIS") / TxtExchangePrice.EditValue)
        Next
        Me.GridControl1.DataSource = dataTable
    End Sub


    Private Sub SimplePost_Click(sender As Object, e As EventArgs) Handles SimplePost.Click



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
            Dim _SalaryData = GetSalaryDocumentIDAndStatusIfExist(_EmplID, GetMonthStartEnd(TextMonth.Text, TextYear.EditValue).Item1, GetMonthStartEnd(TextMonth.Text, TextYear.EditValue).Item2)
            If _SalaryData.DocStatus = 1 Then
                Exit For
            End If
            Dim _TaxAmount As Decimal = GridView1.GetRowCellValue(selectedRowHandles(i), "MonthTaxUSD")
            Dim _Year As Integer = TextYear.Text
            Dim _Month As Integer = TextMonth.Text
            Dim _MonthPeriod As String = _Year & "-" & _Month & "-" & "01"
            Dim sql As New SQLControl
            Dim sqlString As String = " Update AttRawatebArchive Set IncomeTAX=" & _TaxAmount & " Where [EmployeeID]=" & _EmplID & " And [DateFrom]='" & _MonthPeriod & "'"
            sql.SqlTrueAccountingRunQuery(sqlString)
            ReCalcSalaryDocument(_SalaryData.DocID)
        Next i

        SaveSalaryDataToDatabase()
        SaveExchangePrice()
        MsgBoxShowSuccess(" تم احتساب الضريبة بنجاح ")
        'For i = 0 To GridView1.RowCount - 1
        '    Dim _TaxAmount As Decimal = GridView1.GetRowCellValue(i, "MonthTaxUSD")
        '    Dim _EmplID As Integer = GridView1.GetRowCellValue(i, "EmployeeID")
        '    Dim _Year As Integer = TextYear.Text
        '    Dim _Month As Integer = TextMonth.Text
        '    Dim _MonthPeriod As String = _Year & "-" & _Month & "-" & "01"
        '    Dim sql As New SQLControl
        '    Dim sqlString As String = " Update AttRawatebArchive Set IncomeTAX=" & _TaxAmount.ToString("n2") & " Where [EmployeeID]=" & _EmplID & " And [DateFrom]='" & _MonthPeriod & "'"
        '    sql.SqlTrueAccountingRunQuery(sqlString)
        'Next
    End Sub
    Private Function GetMonthStartEnd(ByVal month As Integer, ByVal year As Integer) As (DateTime, DateTime)
        ' Get the first day of the month
        Dim firstDay As DateTime = New DateTime(year, month, 1)

        ' Get the last day of the month
        Dim lastDay As DateTime = firstDay.AddMonths(1).AddDays(-1)

        ' Return as a tuple (VB.NET 2017+)
        Return (firstDay, lastDay)
    End Function

    Private Sub SimplePrint_Click(sender As Object, e As EventArgs) Handles SimplePrint.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GetExchangePrice()
        If TextMonth.EditValue Is Nothing Or TextYear.EditValue Is Nothing Then
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextMonth.EditValue) OrElse String.IsNullOrEmpty(TextYear.EditValue) Then
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlString As String = "Select TOP 1 ExchangePrice From SalariesTaxExchangePrice Where Month=" & TextMonth.EditValue & " And Year=" & TextYear.EditValue
        sql.SqlTrueAccountingRunQuery(sqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            TxtExchangePrice.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ExchangePrice")
        Else
            TxtExchangePrice.EditValue = 1
        End If
    End Sub
    Private Sub SaveExchangePrice()
        If TextMonth.EditValue Is Nothing Or TextYear.EditValue Is Nothing Then
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlString As String = "IF EXISTS (SELECT * FROM SalariesTaxExchangePrice WHERE Month = " & TextMonth.EditValue & " AND Year = " & TextYear.EditValue & ")
            UPDATE SalariesTaxExchangePrice SET ExchangePrice = " & TxtExchangePrice.EditValue & " WHERE Month = " & TextMonth.EditValue & " AND Year = " & TextYear.EditValue & "
        ELSE
            INSERT INTO SalariesTaxExchangePrice (Month, Year, ExchangePrice) VALUES (" & TextMonth.EditValue & ", " & TextYear.EditValue & ", " & TxtExchangePrice.EditValue & ")"
        sql.SqlTrueAccountingRunQuery(sqlString)
    End Sub

    Private Sub TextYear_EditValueChanged(sender As Object, e As EventArgs) Handles TextYear.EditValueChanged
        GetExchangePrice()
    End Sub

    Private Sub TextMonth_EditValueChanged(sender As Object, e As EventArgs) Handles TextMonth.EditValueChanged
        GetExchangePrice()
    End Sub
    Private Sub SaveSalaryDataToDatabase()
        Dim connStr As String = MySettings.Default.TrueTimeConnectionString
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError("لم يتم اختيار أي موظف لحفظ البيانات.")
            Return
        End If
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim view As GridView = GridView1
            For i As Integer = 0 To selectedRowHandles.Length - 1

                ' Skip empty or new rows
                If view.IsDataRow(i) Then
                    Dim yearValue As Integer = TextYear.EditValue
                    Dim monthValue As Integer = TextMonth.EditValue
                    Dim employeeID As Integer = view.GetRowCellValue(selectedRowHandles(i), "EmployeeID")
                    ' Step 1: Delete existing records for the same Year and Month
                    Dim deleteCmd As New SqlCommand("DELETE FROM SalaryTaxDeduction WHERE [Year] = @Year AND [Month] = @Month And EmployeeID=@EmployeeID", conn)
                    deleteCmd.Parameters.AddWithValue("@Year", yearValue)
                    deleteCmd.Parameters.AddWithValue("@Month", monthValue)
                    deleteCmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    deleteCmd.ExecuteNonQuery()

                    Dim cmd As New SqlCommand("
                        INSERT INTO SalaryTaxDeduction (
                            EmployeeID, EmployeeName, SalaryMonth, Additions, GrossSalary, AnualGrossSalaryNIS, 
                            IndividualDiscount, AnualTransport, UniversityAmount, TotalExemptions, TaxableIncome, 
                            YearTax, MonthTaxNIS, MonthTaxUSD, AbsenceAmount,Month,Year
                        )
                        VALUES (
                            @EmployeeID, @EmployeeName, @SalaryMonth, @Additions, @GrossSalary, @AnualGrossSalaryNIS,
                            @IndividualDiscount, @AnualTransport, @UniversityAmount, @TotalExemptions, @TaxableIncome,
                            @YearTax, @MonthTaxNIS, @MonthTaxUSD, @AbsenceAmount, @Month, @Year
                        )", conn)

                    cmd.Parameters.AddWithValue("@EmployeeID", view.GetRowCellValue(selectedRowHandles(i), "EmployeeID"))
                    cmd.Parameters.AddWithValue("@EmployeeName", view.GetRowCellValue(selectedRowHandles(i), "EmployeeName"))
                    cmd.Parameters.AddWithValue("@SalaryMonth", view.GetRowCellValue(selectedRowHandles(i), "SalaryMonth"))
                    cmd.Parameters.AddWithValue("@Additions", view.GetRowCellValue(selectedRowHandles(i), "Additions"))
                    cmd.Parameters.AddWithValue("@GrossSalary", view.GetRowCellValue(selectedRowHandles(i), "GrossSalary"))
                    cmd.Parameters.AddWithValue("@AnualGrossSalaryNIS", view.GetRowCellValue(selectedRowHandles(i), "AnualGrossSalaryNIS"))
                    cmd.Parameters.AddWithValue("@IndividualDiscount", view.GetRowCellValue(selectedRowHandles(i), "IndividualDiscount"))
                    cmd.Parameters.AddWithValue("@AnualTransport", view.GetRowCellValue(selectedRowHandles(i), "AnualTransport"))
                    cmd.Parameters.AddWithValue("@UniversityAmount", view.GetRowCellValue(selectedRowHandles(i), "UniversityAmount"))
                    cmd.Parameters.AddWithValue("@TotalExemptions", view.GetRowCellValue(selectedRowHandles(i), "TotalExemptions"))
                    cmd.Parameters.AddWithValue("@TaxableIncome", view.GetRowCellValue(selectedRowHandles(i), "TaxableIncome"))
                    cmd.Parameters.AddWithValue("@YearTax", view.GetRowCellValue(selectedRowHandles(i), "YearTax"))
                    cmd.Parameters.AddWithValue("@MonthTaxNIS", view.GetRowCellValue(selectedRowHandles(i), "MonthTaxNIS"))
                    cmd.Parameters.AddWithValue("@MonthTaxUSD", view.GetRowCellValue(selectedRowHandles(i), "MonthTaxUSD"))
                    cmd.Parameters.AddWithValue("@AbsenceAmount", view.GetRowCellValue(selectedRowHandles(i), "AbsenceAmount"))
                    cmd.Parameters.AddWithValue("@Month", TextMonth.EditValue)
                    cmd.Parameters.AddWithValue("@Year", TextYear.EditValue)

                    cmd.ExecuteNonQuery()
                End If
            Next

            'MessageBox.Show("Data saved successfully to SalaryTaxDeduction table.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using

    End Sub

    Private Sub TxtExchangePrice_EditValueChanged(sender As Object, e As EventArgs) Handles TxtExchangePrice.EditValueChanged

    End Sub
End Class