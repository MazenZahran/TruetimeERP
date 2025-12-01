Imports DevExpress.XtraReports.UI
Imports System.ComponentModel
Imports System.Drawing

Partial Public Class AccountStatementReport80mm

    Private components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub InitializeComponent()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocNotes = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabelPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReportTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPhone = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelReferancesName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.lblCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailReportDetail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblStockQuantity = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblItemName = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabelDateTimePrinted = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelEndingBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.XrLabel1, Me.lblDocName, Me.lblBalance})
        Me.Detail.HeightF = 20.00008!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100.0!)
        Me.Detail.StylePriority.UseBorders = False
        '
        'XrLabel2
        '
        Me.XrLabel2.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel2.BorderWidth = 2.0!
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.Amount]")})
        Me.XrLabel2.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(153.9582!, 2.000046!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(63.04178!, 16.0!)
        Me.XrLabel2.StylePriority.UseBorderDashStyle = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseBorderWidth = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.TextFormatString = "{0:N1}₪"
        Me.XrLabel2.WordWrap = False
        '
        'XrLabel1
        '
        Me.XrLabel1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel1.BorderWidth = 2.0!
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.DocDate]")})
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(89.29152!, 2.000046!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(64.66669!, 18.0!)
        Me.XrLabel1.StylePriority.UseBorderDashStyle = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseBorderWidth = False
        Me.XrLabel1.TextFormatString = "{0:dd/MM/yyyy}"
        '
        'lblDocName
        '
        Me.lblDocName.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.lblDocName.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.lblDocName.BorderWidth = 2.0!
        Me.lblDocName.CanGrow = False
        Me.lblDocName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.DocName]")})
        Me.lblDocName.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblDocName.LocationFloat = New DevExpress.Utils.PointFloat(28.74994!, 2.000046!)
        Me.lblDocName.Name = "lblDocName"
        Me.lblDocName.SizeF = New System.Drawing.SizeF(60.54158!, 18.0!)
        Me.lblDocName.StylePriority.UseBorderDashStyle = False
        Me.lblDocName.StylePriority.UseBorders = False
        Me.lblDocName.StylePriority.UseBorderWidth = False
        Me.lblDocName.WordWrap = False
        '
        'lblBalance
        '
        Me.lblBalance.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.lblBalance.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.lblBalance.BorderWidth = 2.0!
        Me.lblBalance.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.Balance]")})
        Me.lblBalance.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblBalance.LocationFloat = New DevExpress.Utils.PointFloat(217.0!, 2.000046!)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.SizeF = New System.Drawing.SizeF(85.0!, 16.0!)
        Me.lblBalance.StylePriority.UseBorderDashStyle = False
        Me.lblBalance.StylePriority.UseBorders = False
        Me.lblBalance.StylePriority.UseBorderWidth = False
        Me.lblBalance.StylePriority.UseFont = False
        Me.lblBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalance.TextFormatString = "رصيد:{0:N1}"
        '
        'lblDocNotes
        '
        Me.lblDocNotes.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDocNotes.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.DocNotes]")})
        Me.lblDocNotes.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.lblDocNotes.LocationFloat = New DevExpress.Utils.PointFloat(39.16662!, 0!)
        Me.lblDocNotes.Name = "lblDocNotes"
        Me.lblDocNotes.SizeF = New System.Drawing.SizeF(262.8334!, 17.29166!)
        Me.lblDocNotes.StylePriority.UseBorders = False
        Me.lblDocNotes.StylePriority.UseTextAlignment = False
        Me.lblDocNotes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 10.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 10.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'ReportHeader
        '
        Me.ReportHeader.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.ReportHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabelPeriod, Me.lblReportTitle, Me.lblPhone, Me.lblAddress, Me.XrLabelReferancesName, Me.XrLine2, Me.lblCompanyName})
        Me.ReportHeader.HeightF = 196.875!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseBorderDashStyle = False
        Me.ReportHeader.StylePriority.UseBorders = False
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(41.16655!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(261.8335!, 70.62505!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabelPeriod
        '
        Me.XrLabelPeriod.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrLabelPeriod.LocationFloat = New DevExpress.Utils.PointFloat(39.1666!, 181.625!)
        Me.XrLabelPeriod.Name = "XrLabelPeriod"
        Me.XrLabelPeriod.SizeF = New System.Drawing.SizeF(265.8333!, 15.24995!)
        Me.XrLabelPeriod.StylePriority.UseTextAlignment = False
        Me.XrLabelPeriod.Text = "الفترة"
        Me.XrLabelPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblReportTitle
        '
        Me.lblReportTitle.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.lblReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(39.16666!, 143.6251!)
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.SizeF = New System.Drawing.SizeF(265.8333!, 18.0!)
        Me.lblReportTitle.Text = "كشف حساب"
        Me.lblReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPhone
        '
        Me.lblPhone.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblPhone.LocationFloat = New DevExpress.Utils.PointFloat(39.16672!, 110.625!)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPhone.SizeF = New System.Drawing.SizeF(265.8333!, 20.0!)
        Me.lblPhone.Text = "موبايل"
        Me.lblPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAddress
        '
        Me.lblAddress.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblAddress.LocationFloat = New DevExpress.Utils.PointFloat(39.16669!, 90.62505!)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAddress.SizeF = New System.Drawing.SizeF(265.8333!, 20.0!)
        Me.lblAddress.Text = "العنوان"
        Me.lblAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelReferancesName
        '
        Me.XrLabelReferancesName.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle))
        Me.XrLabelReferancesName.LocationFloat = New DevExpress.Utils.PointFloat(39.16669!, 161.6251!)
        Me.XrLabelReferancesName.Name = "XrLabelReferancesName"
        Me.XrLabelReferancesName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelReferancesName.SizeF = New System.Drawing.SizeF(265.8333!, 20.0!)
        Me.XrLabelReferancesName.StylePriority.UseFont = False
        Me.XrLabelReferancesName.StylePriority.UseTextAlignment = False
        Me.XrLabelReferancesName.Text = "شركة تروتايم سوليوشنز"
        Me.XrLabelReferancesName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLine2
        '
        Me.XrLine2.LineWidth = 3.0!
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(39.16665!, 130.625!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(262.8333!, 13.00003!)
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(39.16666!, 70.62505!)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompanyName.SizeF = New System.Drawing.SizeF(265.8333!, 20.0!)
        Me.lblCompanyName.Text = "شركة تروتايم سوليوشنز"
        Me.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.PageFooter.HeightF = 23.0!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.StylePriority.UseBorders = False
        '
        'DetailReport
        '
        Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailReportDetail, Me.GroupFooter1})
        Me.DetailReport.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.DetailReport.Level = 0
        Me.DetailReport.Name = "DetailReport"
        '
        'DetailReportDetail
        '
        Me.DetailReportDetail.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DetailReportDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblStockQuantity, Me.XrLabel5, Me.lblItemName, Me.lblDocAmount})
        Me.DetailReportDetail.HeightF = 24.0!
        Me.DetailReportDetail.KeepTogether = True
        Me.DetailReportDetail.KeepTogetherWithDetailReports = True
        Me.DetailReportDetail.Name = "DetailReportDetail"
        Me.DetailReportDetail.StylePriority.UseBorders = False
        '
        'lblStockQuantity
        '
        Me.lblStockQuantity.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.CategoriesProducts.StockQuantity]")})
        Me.lblStockQuantity.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.lblStockQuantity.LocationFloat = New DevExpress.Utils.PointFloat(210.6249!, 0!)
        Me.lblStockQuantity.Name = "lblStockQuantity"
        Me.lblStockQuantity.SizeF = New System.Drawing.SizeF(41.45836!, 20.0!)
        Me.lblStockQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblStockQuantity.TextFormatString = "{0:N2}"
        '
        'XrLabel5
        '
        Me.XrLabel5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.CategoriesProducts.StockPrice]")})
        Me.XrLabel5.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(165.4165!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(45.20837!, 20.0!)
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel5.TextFormatString = "{0:N1}₪"
        '
        'lblItemName
        '
        Me.lblItemName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.CategoriesProducts.ItemName]")})
        Me.lblItemName.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.lblItemName.LocationFloat = New DevExpress.Utils.PointFloat(39.16666!, 0!)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.SizeF = New System.Drawing.SizeF(126.2499!, 20.0!)
        Me.lblItemName.StylePriority.UseTextAlignment = False
        Me.lblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDocAmount
        '
        Me.lblDocAmount.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Journal.CategoriesProducts.DocAmount]")})
        Me.lblDocAmount.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.lblDocAmount.LocationFloat = New DevExpress.Utils.PointFloat(252.0833!, 0!)
        Me.lblDocAmount.Name = "lblDocAmount"
        Me.lblDocAmount.SizeF = New System.Drawing.SizeF(49.91672!, 20.0!)
        Me.lblDocAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDocAmount.TextFormatString = "{0:N1}₪"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDocNotes})
        Me.GroupFooter1.HeightF = 17.29167!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelDateTimePrinted, Me.XrLabelEndingBalance, Me.XrLabel4})
        Me.ReportFooter.HeightF = 75.37447!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabelDateTimePrinted
        '
        Me.XrLabelDateTimePrinted.Font = New DevExpress.Drawing.DXFont("Arial", 7.0!)
        Me.XrLabelDateTimePrinted.LocationFloat = New DevExpress.Utils.PointFloat(39.1666!, 34.37444!)
        Me.XrLabelDateTimePrinted.Name = "XrLabelDateTimePrinted"
        Me.XrLabelDateTimePrinted.SizeF = New System.Drawing.SizeF(265.8333!, 18.0!)
        Me.XrLabelDateTimePrinted.StylePriority.UseFont = False
        Me.XrLabelDateTimePrinted.StylePriority.UseTextAlignment = False
        Me.XrLabelDateTimePrinted.Text = "Print @2025-04-01 14:12"
        Me.XrLabelDateTimePrinted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelEndingBalance
        '
        Me.XrLabelEndingBalance.Font = New DevExpress.Drawing.DXFont("Times New Roman", 14.0!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle))
        Me.XrLabelEndingBalance.LocationFloat = New DevExpress.Utils.PointFloat(41.16656!, 10.00001!)
        Me.XrLabelEndingBalance.Multiline = True
        Me.XrLabelEndingBalance.Name = "XrLabelEndingBalance"
        Me.XrLabelEndingBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelEndingBalance.SizeF = New System.Drawing.SizeF(263.8334!, 23.00003!)
        Me.XrLabelEndingBalance.StylePriority.UseFont = False
        Me.XrLabelEndingBalance.StylePriority.UseTextAlignment = False
        Me.XrLabelEndingBalance.Text = "الرصيد"
        Me.XrLabelEndingBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(39.16665!, 52.37444!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(263.8334!, 23.00003!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "-------------------انتهى -------------------"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'AccountStatementReport80mm
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageFooter, Me.DetailReport, Me.ReportFooter})
        Me.Margins = New DevExpress.Drawing.DXMargins(5.0!, 5.0!, 10.0!, 10.0!)
        Me.PageHeight = 1169
        Me.PageWidth = 315
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ShowPrintMarginsWarning = False
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    ' Control declarations
    Private Detail As DevExpress.XtraReports.UI.DetailBand
    Private TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Private BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Private ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Private PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Private DetailReport As DevExpress.XtraReports.UI.DetailReportBand
    Private DetailReportDetail As DevExpress.XtraReports.UI.DetailBand

    Private lblCompanyName As DevExpress.XtraReports.UI.XRLabel
    Private lblDocName As DevExpress.XtraReports.UI.XRLabel
    Private lblBalance As DevExpress.XtraReports.UI.XRLabel
    Private lblDocNotes As DevExpress.XtraReports.UI.XRLabel
    Private lblItemName As DevExpress.XtraReports.UI.XRLabel
    Private lblDocAmount As DevExpress.XtraReports.UI.XRLabel
    Private lblStockQuantity As DevExpress.XtraReports.UI.XRLabel
    Private WithEvents XrLabel1 As XRLabel
    Friend WithEvents XrLine2 As XRLine
    Private WithEvents XrLabel2 As XRLabel
    Friend WithEvents ReportFooter As ReportFooterBand
    Friend WithEvents XrLabel4 As XRLabel
    Private WithEvents XrLabel5 As XRLabel
    Friend WithEvents GroupFooter1 As GroupFooterBand
    Friend WithEvents XrLabelEndingBalance As XRLabel
    Private WithEvents lblAddress As XRLabel
    Private WithEvents XrLabelReferancesName As XRLabel
    Private WithEvents lblPhone As XRLabel
    Private WithEvents lblReportTitle As XRLabel
    Private WithEvents XrLabelPeriod As XRLabel
    Private WithEvents XrLabelDateTimePrinted As XRLabel
    Friend WithEvents XrPictureBox1 As XRPictureBox
End Class