Public Class PosSecondScreen
    Private Sub PosSecondScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridPosVoucher.MainView = TileView2

        Dim s As String = "{0} {1} {2}"
        Dim msg As String = String.Format(s, " الصافي للدفع: ", "#,##0.00", " شيكل ")
        TexVouchertAmountAfterDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        TexVouchertAmountAfterDiscount.Properties.Mask.EditMask = msg
        TexVouchertAmountAfterDiscount.Properties.Mask.UseMaskAsDisplayFormat = True




        TileViewQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        TileViewQuantity.DisplayFormat.FormatString = "الكمية: {0:n2}"
        TileViewPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        TileViewPrice.DisplayFormat.FormatString = "السعر: {0:n2}"
        TileViewDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        TileViewDiscount.DisplayFormat.FormatString = "خصم: {0:n2}"
        TileViewAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        TileViewAmount.DisplayFormat.FormatString = "المبلغ: {0:n2}"
    End Sub
End Class