<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CloseShiftReportThin
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ShiftID = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrReceiptsCash = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPaymentsCash = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TotalDiscount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.NetSales = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.DiscountAmountForCards = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.CardAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DiscountAmountForCash = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DeletedItemsCount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DiscountAmountForCSTMR = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.UserName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDiff = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TotalSales = New DevExpress.XtraReports.UI.XRLabel()
        Me.EndBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.DebitAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.CashAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.BegBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.UserID = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.EndDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.StartDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrReceiptsCard = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.BorderColor = System.Drawing.Color.DimGray
        Me.TopMargin.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel14, Me.XrLabelCompanyName, Me.XrPictureBox1})
        Me.TopMargin.HeightF = 215.3333!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.StylePriority.UseBorderColor = False
        Me.TopMargin.StylePriority.UseBorders = False
        '
        'XrLabel14
        '
        Me.XrLabel14.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabel14.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New DevExpress.Drawing.DXFont("Arial Narrow", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(13.75008!, 176.375!)
        Me.XrLabel14.Multiline = True
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(176.2499!, 28.95833!)
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "تقرير إغلاق وردية العمل"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelCompanyName
        '
        Me.XrLabelCompanyName.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelCompanyName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelCompanyName.CanGrow = False
        Me.XrLabelCompanyName.Font = New DevExpress.Drawing.DXFont("Arial Narrow", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(13.33339!, 143.9166!)
        Me.XrLabelCompanyName.Multiline = True
        Me.XrLabelCompanyName.Name = "XrLabelCompanyName"
        Me.XrLabelCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCompanyName.SizeF = New System.Drawing.SizeF(176.6665!, 32.45845!)
        Me.XrLabelCompanyName.StylePriority.UseFont = False
        Me.XrLabelCompanyName.StylePriority.UseTextAlignment = False
        Me.XrLabelCompanyName.Text = "Best Parts Company"
        Me.XrLabelCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(12.50004!, 12.5!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(177.4999!, 131.4166!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel1
        '
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(12.91672!, 15.37498!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(99.16663!, 23.0!)
        Me.XrLabel1.Text = "رقم الشفت:"
        '
        'ShiftID
        '
        Me.ShiftID.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.ShiftID.LocationFloat = New DevExpress.Utils.PointFloat(112.0833!, 15.37498!)
        Me.ShiftID.Multiline = True
        Me.ShiftID.Name = "ShiftID"
        Me.ShiftID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.ShiftID.SizeF = New System.Drawing.SizeF(76.66651!, 23.0!)
        Me.ShiftID.StylePriority.UseFont = False
        Me.ShiftID.Text = "0"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 13.0825!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrReceiptsCard, Me.XrLabel20, Me.XrLine4, Me.XrLabel18, Me.XrReceiptsCash, Me.XrLabel21, Me.XrPaymentsCash, Me.XrLabel17, Me.TotalDiscount, Me.XrLabel19, Me.NetSales, Me.XrLine3, Me.XrLine2, Me.DiscountAmountForCards, Me.XrLabel16, Me.CardAmount, Me.XrLabel7, Me.DiscountAmountForCash, Me.XrLabel15, Me.DeletedItemsCount, Me.XrLabel12, Me.DiscountAmountForCSTMR, Me.XrLabel11, Me.XrLine1, Me.ShiftID, Me.XrLabel1, Me.UserName, Me.XrLabelDiff, Me.XrLabel13, Me.XrLabel10, Me.TotalSales, Me.EndBalance, Me.DebitAmount, Me.CashAmount, Me.BegBalance, Me.XrLabel9, Me.XrLabel8, Me.XrLabel6, Me.XrLabel5, Me.UserID, Me.XrLabel4, Me.XrLabel2, Me.EndDateTime, Me.StartDateTime, Me.XrLabel3})
        Me.Detail.HeightF = 682.5004!
        Me.Detail.Name = "Detail"
        '
        'XrLine4
        '
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(11.99979!, 413.9169!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(176.6665!, 2.083344!)
        '
        'XrLabel18
        '
        Me.XrLabel18.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(11.9998!, 351.3335!)
        Me.XrLabel18.Multiline = True
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(88.12513!, 15.70831!)
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.Text = "قبوضات نقدية:"
        '
        'XrReceiptsCash
        '
        Me.XrReceiptsCash.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrReceiptsCash.LocationFloat = New DevExpress.Utils.PointFloat(113.4166!, 351.3335!)
        Me.XrReceiptsCash.Multiline = True
        Me.XrReceiptsCash.Name = "XrReceiptsCash"
        Me.XrReceiptsCash.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrReceiptsCash.SizeF = New System.Drawing.SizeF(75.74988!, 15.70831!)
        Me.XrReceiptsCash.StylePriority.UseFont = False
        Me.XrReceiptsCash.Text = "0"
        '
        'XrLabel21
        '
        Me.XrLabel21.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(12.91655!, 394.0419!)
        Me.XrLabel21.Multiline = True
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(87.70834!, 19.87497!)
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.Text = "مصاريف:"
        '
        'XrPaymentsCash
        '
        Me.XrPaymentsCash.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrPaymentsCash.LocationFloat = New DevExpress.Utils.PointFloat(113.4167!, 393.0834!)
        Me.XrPaymentsCash.Multiline = True
        Me.XrPaymentsCash.Name = "XrPaymentsCash"
        Me.XrPaymentsCash.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPaymentsCash.SizeF = New System.Drawing.SizeF(75.74982!, 19.87497!)
        Me.XrPaymentsCash.StylePriority.UseFont = False
        Me.XrPaymentsCash.Text = "0"
        '
        'XrLabel17
        '
        Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel17.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(13.75009!, 173.0!)
        Me.XrLabel17.Multiline = True
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(87.7084!, 22.99997!)
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.Text = "مجموع الخصم:"
        '
        'TotalDiscount
        '
        Me.TotalDiscount.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.TotalDiscount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.TotalDiscount.LocationFloat = New DevExpress.Utils.PointFloat(112.9167!, 173.0!)
        Me.TotalDiscount.Multiline = True
        Me.TotalDiscount.Name = "TotalDiscount"
        Me.TotalDiscount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.TotalDiscount.SizeF = New System.Drawing.SizeF(76.66652!, 22.99994!)
        Me.TotalDiscount.StylePriority.UseBorders = False
        Me.TotalDiscount.StylePriority.UseFont = False
        Me.TotalDiscount.Text = "0"
        '
        'XrLabel19
        '
        Me.XrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel19.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(13.75009!, 195.9999!)
        Me.XrLabel19.Multiline = True
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(87.7084!, 22.99997!)
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.Text = "صافي المبيعات:"
        '
        'NetSales
        '
        Me.NetSales.BackColor = System.Drawing.Color.Silver
        Me.NetSales.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.NetSales.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.NetSales.LocationFloat = New DevExpress.Utils.PointFloat(112.9167!, 195.9999!)
        Me.NetSales.Multiline = True
        Me.NetSales.Name = "NetSales"
        Me.NetSales.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.NetSales.SizeF = New System.Drawing.SizeF(75.41653!, 23.0!)
        Me.NetSales.StylePriority.UseBackColor = False
        Me.NetSales.StylePriority.UseBorders = False
        Me.NetSales.StylePriority.UseFont = False
        Me.NetSales.Text = "0"
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 224.2501!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(176.6665!, 2.083344!)
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 349.2501!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(176.6665!, 2.083344!)
        '
        'DiscountAmountForCards
        '
        Me.DiscountAmountForCards.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DiscountAmountForCards.LocationFloat = New DevExpress.Utils.PointFloat(113.0!, 322.1667!)
        Me.DiscountAmountForCards.Multiline = True
        Me.DiscountAmountForCards.Name = "DiscountAmountForCards"
        Me.DiscountAmountForCards.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DiscountAmountForCards.SizeF = New System.Drawing.SizeF(75.74982!, 22.99997!)
        Me.DiscountAmountForCards.StylePriority.UseFont = False
        Me.DiscountAmountForCards.Text = "0"
        '
        'XrLabel16
        '
        Me.XrLabel16.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(13.33334!, 323.1251!)
        Me.XrLabel16.Multiline = True
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(87.70834!, 22.99997!)
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.Text = "خصم بطاقات:"
        '
        'CardAmount
        '
        Me.CardAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.CardAmount.LocationFloat = New DevExpress.Utils.PointFloat(112.9999!, 299.1667!)
        Me.CardAmount.Multiline = True
        Me.CardAmount.Name = "CardAmount"
        Me.CardAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.CardAmount.SizeF = New System.Drawing.SizeF(75.74988!, 22.99997!)
        Me.CardAmount.StylePriority.UseFont = False
        Me.CardAmount.Text = "0"
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(13.33334!, 299.1667!)
        Me.XrLabel7.Multiline = True
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(88.12514!, 22.99997!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.Text = "مبيعات بطاقات:"
        '
        'DiscountAmountForCash
        '
        Me.DiscountAmountForCash.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DiscountAmountForCash.LocationFloat = New DevExpress.Utils.PointFloat(109.8749!, 480.3335!)
        Me.DiscountAmountForCash.Multiline = True
        Me.DiscountAmountForCash.Name = "DiscountAmountForCash"
        Me.DiscountAmountForCash.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DiscountAmountForCash.SizeF = New System.Drawing.SizeF(74.16644!, 23.00003!)
        Me.DiscountAmountForCash.StylePriority.UseFont = False
        Me.DiscountAmountForCash.Text = "0"
        '
        'XrLabel15
        '
        Me.XrLabel15.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(9.791382!, 480.3335!)
        Me.XrLabel15.Multiline = True
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(88.12513!, 23.0!)
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.Text = "خصم نقدي:"
        '
        'DeletedItemsCount
        '
        Me.DeletedItemsCount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DeletedItemsCount.LocationFloat = New DevExpress.Utils.PointFloat(109.0415!, 589.9584!)
        Me.DeletedItemsCount.Multiline = True
        Me.DeletedItemsCount.Name = "DeletedItemsCount"
        Me.DeletedItemsCount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DeletedItemsCount.SizeF = New System.Drawing.SizeF(77.41666!, 22.99994!)
        Me.DeletedItemsCount.StylePriority.UseFont = False
        Me.DeletedItemsCount.Text = "0"
        Me.DeletedItemsCount.TextFormatString = "حركة {0}"
        '
        'XrLabel12
        '
        Me.XrLabel12.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 589.9584!)
        Me.XrLabel12.Multiline = True
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(87.41676!, 22.99994!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.Text = "الحركات المحذوفة"
        '
        'DiscountAmountForCSTMR
        '
        Me.DiscountAmountForCSTMR.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DiscountAmountForCSTMR.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DiscountAmountForCSTMR.LocationFloat = New DevExpress.Utils.PointFloat(113.3334!, 258.2917!)
        Me.DiscountAmountForCSTMR.Multiline = True
        Me.DiscountAmountForCSTMR.Name = "DiscountAmountForCSTMR"
        Me.DiscountAmountForCSTMR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DiscountAmountForCSTMR.SizeF = New System.Drawing.SizeF(75.41642!, 22.99997!)
        Me.DiscountAmountForCSTMR.StylePriority.UseBorders = False
        Me.DiscountAmountForCSTMR.StylePriority.UseFont = False
        Me.DiscountAmountForCSTMR.Text = "0"
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(13.33339!, 258.2917!)
        Me.XrLabel11.Multiline = True
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(87.7084!, 23.0!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.Text = "خصميات ذمم:"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(9.041533!, 573.1666!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(176.6665!, 2.083344!)
        '
        'UserName
        '
        Me.UserName.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.UserName.LocationFloat = New DevExpress.Utils.PointFloat(12.91672!, 107.375!)
        Me.UserName.Multiline = True
        Me.UserName.Name = "UserName"
        Me.UserName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.UserName.SizeF = New System.Drawing.SizeF(177.0833!, 23.0!)
        Me.UserName.StylePriority.UseFont = False
        Me.UserName.StylePriority.UseTextAlignment = False
        Me.UserName.Text = "0"
        Me.UserName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelDiff
        '
        Me.XrLabelDiff.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDiff.LocationFloat = New DevExpress.Utils.PointFloat(108.6248!, 545.1669!)
        Me.XrLabelDiff.Multiline = True
        Me.XrLabelDiff.Name = "XrLabelDiff"
        Me.XrLabelDiff.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDiff.SizeF = New System.Drawing.SizeF(77.41666!, 22.99994!)
        Me.XrLabelDiff.StylePriority.UseFont = False
        Me.XrLabelDiff.Text = "0"
        '
        'XrLabel13
        '
        Me.XrLabel13.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(8.833191!, 545.1669!)
        Me.XrLabel13.Multiline = True
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(87.41676!, 22.99994!)
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.Text = "زيادة / عجز:"
        '
        'XrLabel10
        '
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 150.0!)
        Me.XrLabel10.Multiline = True
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(87.7084!, 22.99997!)
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.Text = "مجموع المبيعات:"
        '
        'TotalSales
        '
        Me.TotalSales.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.TotalSales.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.TotalSales.LocationFloat = New DevExpress.Utils.PointFloat(112.5!, 150.0!)
        Me.TotalSales.Multiline = True
        Me.TotalSales.Name = "TotalSales"
        Me.TotalSales.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.TotalSales.SizeF = New System.Drawing.SizeF(76.24982!, 22.99997!)
        Me.TotalSales.StylePriority.UseBorders = False
        Me.TotalSales.StylePriority.UseFont = False
        Me.TotalSales.Text = "0"
        '
        'EndBalance
        '
        Me.EndBalance.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.EndBalance.LocationFloat = New DevExpress.Utils.PointFloat(108.6248!, 511.8334!)
        Me.EndBalance.Multiline = True
        Me.EndBalance.Name = "EndBalance"
        Me.EndBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.EndBalance.SizeF = New System.Drawing.SizeF(76.66649!, 23.0!)
        Me.EndBalance.StylePriority.UseFont = False
        Me.EndBalance.Text = "0"
        '
        'DebitAmount
        '
        Me.DebitAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DebitAmount.LocationFloat = New DevExpress.Utils.PointFloat(113.3334!, 235.2917!)
        Me.DebitAmount.Multiline = True
        Me.DebitAmount.Name = "DebitAmount"
        Me.DebitAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DebitAmount.SizeF = New System.Drawing.SizeF(75.41642!, 23.0!)
        Me.DebitAmount.StylePriority.UseFont = False
        Me.DebitAmount.Text = "0"
        '
        'CashAmount
        '
        Me.CashAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.CashAmount.LocationFloat = New DevExpress.Utils.PointFloat(109.0415!, 457.3334!)
        Me.CashAmount.Multiline = True
        Me.CashAmount.Name = "CashAmount"
        Me.CashAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.CashAmount.SizeF = New System.Drawing.SizeF(74.99987!, 23.00003!)
        Me.CashAmount.StylePriority.UseFont = False
        Me.CashAmount.Text = "0"
        '
        'BegBalance
        '
        Me.BegBalance.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.BegBalance.LocationFloat = New DevExpress.Utils.PointFloat(109.8749!, 427.4587!)
        Me.BegBalance.Multiline = True
        Me.BegBalance.Name = "BegBalance"
        Me.BegBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.BegBalance.SizeF = New System.Drawing.SizeF(74.16643!, 23.0!)
        Me.BegBalance.StylePriority.UseFont = False
        Me.BegBalance.Text = "0"
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(8.624878!, 511.8334!)
        Me.XrLabel9.Multiline = True
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(87.7084!, 23.0!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = "مبلغ نهاية الشفت:"
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(12.91672!, 235.2917!)
        Me.XrLabel8.Multiline = True
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(88.54176!, 23.0!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.Text = "مبيعات ذمم:"
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(9.874847!, 457.3334!)
        Me.XrLabel6.Multiline = True
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(88.12513!, 23.00003!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = "مبيعات نقدية:"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(9.874847!, 427.4586!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(87.7084!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "رصيد افتتاحي:"
        '
        'UserID
        '
        Me.UserID.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.UserID.LocationFloat = New DevExpress.Utils.PointFloat(113.3334!, 84.375!)
        Me.UserID.Multiline = True
        Me.UserID.Name = "UserID"
        Me.UserID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.UserID.SizeF = New System.Drawing.SizeF(76.66659!, 23.0!)
        Me.UserID.StylePriority.UseFont = False
        Me.UserID.Text = "0"
        '
        'XrLabel4
        '
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(13.3334!, 84.375!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(99.99999!, 23.0!)
        Me.XrLabel4.Text = "المستخدم:"
        '
        'XrLabel2
        '
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(12.91672!, 61.375!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel2.Text = "وقت النهاية:"
        '
        'EndDateTime
        '
        Me.EndDateTime.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.EndDateTime.LocationFloat = New DevExpress.Utils.PointFloat(112.9167!, 61.375!)
        Me.EndDateTime.Multiline = True
        Me.EndDateTime.Name = "EndDateTime"
        Me.EndDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.EndDateTime.SizeF = New System.Drawing.SizeF(80.4166!, 23.0!)
        Me.EndDateTime.StylePriority.UseFont = False
        Me.EndDateTime.Text = "0"
        '
        'StartDateTime
        '
        Me.StartDateTime.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.StartDateTime.LocationFloat = New DevExpress.Utils.PointFloat(113.3334!, 38.37498!)
        Me.StartDateTime.Multiline = True
        Me.StartDateTime.Name = "StartDateTime"
        Me.StartDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.StartDateTime.SizeF = New System.Drawing.SizeF(79.99989!, 23.0!)
        Me.StartDateTime.StylePriority.UseFont = False
        Me.StartDateTime.Text = "0"
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(13.3334!, 38.375!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel3.Text = "وقت البداية:"
        '
        'XrLabel20
        '
        Me.XrLabel20.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(11.9998!, 367.0418!)
        Me.XrLabel20.Multiline = True
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(88.12513!, 15.70831!)
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.Text = "قبوضات نقدية:"
        '
        'XrReceiptsCard
        '
        Me.XrReceiptsCard.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrReceiptsCard.LocationFloat = New DevExpress.Utils.PointFloat(112.5!, 367.0418!)
        Me.XrReceiptsCard.Multiline = True
        Me.XrReceiptsCard.Name = "XrReceiptsCard"
        Me.XrReceiptsCard.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrReceiptsCard.SizeF = New System.Drawing.SizeF(76.66651!, 15.70831!)
        Me.XrReceiptsCard.StylePriority.UseFont = False
        Me.XrReceiptsCard.Text = "0"
        '
        'CloseShiftReportThin
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 215.3333!, 13.0825!)
        Me.PageWidth = 200
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.Version = "24.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ShiftID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents EndBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DebitAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CardAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CashAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BegBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents UserID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents EndDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents StartDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDiff As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TotalSales As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents UserName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents DiscountAmountForCSTMR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DeletedItemsCount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DiscountAmountForCash As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DiscountAmountForCards As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TotalDiscount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents NetSales As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrReceiptsCash As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPaymentsCash As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrReceiptsCard As DevExpress.XtraReports.UI.XRLabel
End Class
