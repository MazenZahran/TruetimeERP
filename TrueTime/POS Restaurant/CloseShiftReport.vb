Imports System.Drawing.Printing

Public Class CloseShiftReport
    Private Sub CloseShiftReport_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        Me.RequiredBalance.Text = CDec(Me.BegBalance.Text) + CDec(CashAmount.Text) + CDec(XrReceiptsCash.Text) - CDec(XrPaymentsCash.Text) - CDec(DiscountAmountForCash.Text)
    End Sub
End Class