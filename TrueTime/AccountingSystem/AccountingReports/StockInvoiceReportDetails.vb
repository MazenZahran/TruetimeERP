Public Class StockInvoiceReportDetails
    Private Sub DocOriginal_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub StockInvoiceReportDetails_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.BeforePrint
        Dim _ShowDocNoInSalesDetailsReport As Boolean = True
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("select SettingValue from [dbo].[Settings] where SettingName='ShowDocNoInSalesDetailsReport'")
            _ShowDocNoInSalesDetailsReport = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ShowDocNoInSalesDetailsReport = True
        End Try
        If _ShowDocNoInSalesDetailsReport = False Then XrLabel1.Visible = False
    End Sub
End Class