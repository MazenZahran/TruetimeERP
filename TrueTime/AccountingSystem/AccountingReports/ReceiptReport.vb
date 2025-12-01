Imports System.ComponentModel

Public Class ReceiptReport
    Private Sub ReceiptReport_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        If GlobalVariables._Shalash = True Then
            XrLabelRefBalance.Visible = True
        End If
        If GlobalVariables._UseSalesMan = True Then
            XrLabelSalesLabel.Visible = True
            XrLabelSalesManNo.Visible = True
            XrLabelSalesManName.Visible = True
        Else
            XrLabelSalesLabel.Visible = False
            XrLabelSalesManNo.Visible = False
            XrLabelSalesManName.Visible = False
        End If
    End Sub
End Class