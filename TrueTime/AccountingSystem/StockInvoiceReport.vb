Imports System.ComponentModel
Imports System.Data.SqlTypes

Public Class StockInvoiceReport
    Private Sub StockInvoiceReport_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        'Dim Sql As New SQLControl
        'Dim sqlString As String
        'sqlString = "  Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowColumnBonusInVouchers' "
        'Sql.SqlTrueAccountingRunQuery(sqlString)
        'XrTableCellBonusLabel.Visible = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'XrTableCellBonus.Visible = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    End Sub
End Class