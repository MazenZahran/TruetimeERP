Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class CurrencyExchangePrices
    Dim _DefaultCurr As Integer = GetDefaultCurrency()

    Private Sub CurrencyExchangePrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateEdit1.DateTime = Today
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrEmpty(DateEdit1.EditValue) Then Exit Sub
        Dim _Date As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim SqlString As String
        For i = 0 To GridView1.RowCount - 1
            Dim _CurrencyId As Integer = 0
            Dim _ExchangePrice As Decimal = 0
            Dim _TransID As Integer
            _CurrencyId = Me.GridView1.GetRowCellValue(i, "CurrID")
            _ExchangePrice = Me.GridView1.GetRowCellValue(i, "PurchasePrice")

            If IsDBNull(Me.GridView1.GetRowCellValue(i, "TransID")) Then
                SqlString = " Insert into [dbo].[CurrencyExchangePrice] 
                              ([TheDate],[CurrencyID],[PurchasePrice],[SalesPrice]) 
                              Values
                              ('" & _Date & "','" & _CurrencyId & "'," & _ExchangePrice & "," & _ExchangePrice & " ) "
                sql.SqlTrueAccountingRunQuery(SqlString)
            Else
                _TransID = Me.GridView1.GetRowCellValue(i, "TransID")
                SqlString = " Update [dbo].[CurrencyExchangePrice] 
                              Set [PurchasePrice]=" & _ExchangePrice & ",
                              [SalesPrice]= " & _ExchangePrice & " where [ID]= " & _TransID & " and [CurrencyID]=" & _CurrencyId
                sql.SqlTrueAccountingRunQuery(SqlString)
            End If
        Next
        GetCurrencyPrices()
    End Sub
    Private Sub GetCurrencyPrices()
        If String.IsNullOrEmpty(DateEdit1.EditValue) Then Exit Sub
        Dim _Date As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " Select [CurrID],[Code],CurrencyName,[IsDefault],TransID,[TheDate],[PurchasePrice],[SalesPrice] from (
                      SELECT [CurrID]      ,[Code]      ,[name] as CurrencyName
                     ,[IsDefault]  FROM [dbo].[Currency] C ) A  left join 
                     ( SELECT  [ID] as TransID      ,[TheDate]      ,[CurrencyID]      ,[PurchasePrice]
                     ,[SalesPrice]  FROM [dbo].[CurrencyExchangePrice]   
                     Where    TheDate='" & _Date & "' ) B
                     On A.CurrID = B.CurrencyID  where IsDefault=0"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "PurchasePrice", GetExchengPrice(Me.GridView1.GetRowCellValue(i, "CurrID"), _Date).PurchasePrice)
        Next

    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        GetCurrencyPrices()
    End Sub




    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ExchangePriceReport.ShowDialog()
    End Sub
End Class