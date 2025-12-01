Public Class ExchangePriceReport
    Private Sub ExchangePriceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCurrencyExchangePrices()
    End Sub
    Private Sub LoadCurrencyExchangePrices()
        Try
            Dim SqlString As String = "Select [CurrID],[Code],CurrencyName,[IsDefault],TransID,[TheDate],[PurchasePrice],[SalesPrice] from (
                      SELECT [CurrID]      ,[Code]      ,[name] as CurrencyName
                     ,[IsDefault]  FROM [dbo].[Currency] C ) A  left join 
                     ( SELECT  [ID] as TransID      ,[TheDate]      ,[CurrencyID]      ,[PurchasePrice]
                     ,[SalesPrice]  FROM [dbo].[CurrencyExchangePrice]   
                     ) B
                     On A.CurrID = B.CurrencyID  where IsDefault=0"

            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridCurrencyExchangePrice.DataSource = Sql.SQLDS.Tables(0)

        Catch ex As Exception
            ' Handle any exceptions that might occur during data loading
            MessageBox.Show("Error loading currency exchange prices: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class