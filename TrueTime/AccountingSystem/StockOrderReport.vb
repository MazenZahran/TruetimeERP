Imports System.ComponentModel

Public Class StockOrderReport
    Private Sub StockOrderReport_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        'Accounting_PrintOrderWithTaxIncluded
        If CheckIfTaxIncluded() Then
            XrLabelIncludedTax.Text = "شامل"
        Else
            XrLabelIncludedTax.Text = "غير شامل"
        End If
    End Sub
    Private Function CheckIfTaxIncluded() As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select SettingValue from Settings where SettingName='Accounting_PrintOrderWithTaxIncluded'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
End Class