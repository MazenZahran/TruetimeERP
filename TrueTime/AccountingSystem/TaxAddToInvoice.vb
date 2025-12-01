Public Class TaxAddToInvoice
    Private Sub DocAmountBeforeTax_EditValueChanged(sender As Object, e As EventArgs) Handles DocAmountBeforeTax.EditValueChanged
        Calc()
    End Sub
    Private Sub Calc()
        Try
            TaxAmount.EditValue = DocAmountBeforeTax.EditValue * VATPercentage.EditValue / 100
            DocAmountAfterTax.EditValue = DocAmountBeforeTax.EditValue + TaxAmount.EditValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub VATPercentage_EditValueChanged(sender As Object, e As EventArgs) Handles VATPercentage.EditValueChanged
        Calc()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        AccStockMove._TempPercentage = (VATPercentage.EditValue / 100)
        'AccStockMove.TaxPercentage = 1
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'AccStockMove.TaxPercentage = 0
        Me.Close()
    End Sub
End Class