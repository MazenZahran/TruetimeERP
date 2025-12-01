Public Class AccTaxSummary
    Private Sub AccTaxSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextMonth.EditValue = DateTime.Now.Month
        Me.TextYear.EditValue = DateTime.Now.Year
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetData()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " SELECT
                      CAST(ISNULL(SUM(CASE WHEN DocName = 2  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalSales,
                      CAST(ISNULL(SUM(CASE WHEN DocName = 12  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalReturnSales,
                      CAST(ISNULL(SUM(CASE WHEN DocName = 1  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalPurchases, 
                      CAST(ISNULL(SUM(CASE WHEN DocName = 13  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalReturnPurchases,
                      CAST(ISNULL(SUM(CASE WHEN DocName = 6  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalDebitNotes,
                      CAST(ISNULL(SUM(CASE WHEN DocName = 7  THEN BaseCurrAmount END), 0) AS DECIMAL(19,2))  AS totalCreditNotes

                      FROM dbo.Journal
                      WHERE DocStatus > 0 And Month(TaxDate) = " & Me.TextMonth.EditValue & " 
                            And Year(TaxDate) = " & Me.TextYear.EditValue
        sql.SqlTrueAccountingRunQuery(sqlString)
        If sql.SQLDS.Tables.Count > 0 Then
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim totalSales As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalSales"))
                Dim totalReturnSales As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalReturnSales"))
                Dim totalPurchases As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalPurchases"))
                Dim totalReturnPurchases As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalReturnPurchases"))
                Dim totalDebitNotes As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalDebitNotes"))
                Dim totalCreditNotes As Decimal = Convert.ToDecimal(sql.SQLDS.Tables(0).Rows(0).Item("totalCreditNotes"))
                Me.TextTotalSales.EditValue = totalSales
                Me.TextTotalReturnSales.EditValue = totalReturnSales
                Me.TextTotalReturnPurchases.EditValue = totalReturnPurchases
            End If
        End If
    End Sub
End Class