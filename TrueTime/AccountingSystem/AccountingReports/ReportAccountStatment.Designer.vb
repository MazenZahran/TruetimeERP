<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportAccountStatment
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
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.FooterPicture = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabelReportNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.PrintableComponentContainer1 = New DevExpress.XtraReports.UI.PrintableComponentContainer()
        Me.HeaderPicture = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabelCurrencyLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCurrency = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAccountName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAccountLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAccountStatment = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLabelReforAcc = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabelDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelUser = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 27.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.FooterPicture})
        Me.BottomMargin.HeightF = 54.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'FooterPicture
        '
        Me.FooterPicture.LocationFloat = New DevExpress.Utils.PointFloat(0.00009028117!, 0!)
        Me.FooterPicture.Name = "FooterPicture"
        Me.FooterPicture.SizeF = New System.Drawing.SizeF(779.9999!, 53.54169!)
        Me.FooterPicture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelReportNote, Me.PrintableComponentContainer1})
        Me.Detail.HeightF = 353.125!
        Me.Detail.Name = "Detail"
        '
        'XrLabelReportNote
        '
        Me.XrLabelReportNote.LocationFloat = New DevExpress.Utils.PointFloat(0.0005175273!, 330.125!)
        Me.XrLabelReportNote.Multiline = True
        Me.XrLabelReportNote.Name = "XrLabelReportNote"
        Me.XrLabelReportNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelReportNote.SizeF = New System.Drawing.SizeF(779.9995!, 23.0!)
        Me.XrLabelReportNote.StylePriority.UseTextAlignment = False
        Me.XrLabelReportNote.Text = "ملاحظة كشف الحساب"
        Me.XrLabelReportNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'PrintableComponentContainer1
        '
        Me.PrintableComponentContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0000559489!, 0!)
        Me.PrintableComponentContainer1.Name = "PrintableComponentContainer1"
        Me.PrintableComponentContainer1.SizeF = New System.Drawing.SizeF(779.9998!, 330.1249!)
        '
        'HeaderPicture
        '
        Me.HeaderPicture.LocationFloat = New DevExpress.Utils.PointFloat(0.00005679659!, 9.999996!)
        Me.HeaderPicture.Name = "HeaderPicture"
        Me.HeaderPicture.SizeF = New System.Drawing.SizeF(779.9993!, 119.3889!)
        Me.HeaderPicture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabelCurrencyLabel
        '
        Me.XrLabelCurrencyLabel.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelCurrencyLabel.LocationFloat = New DevExpress.Utils.PointFloat(670.8447!, 175.3889!)
        Me.XrLabelCurrencyLabel.Multiline = True
        Me.XrLabelCurrencyLabel.Name = "XrLabelCurrencyLabel"
        Me.XrLabelCurrencyLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCurrencyLabel.SizeF = New System.Drawing.SizeF(48.66117!, 23.0!)
        Me.XrLabelCurrencyLabel.StylePriority.UseFont = False
        Me.XrLabelCurrencyLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelCurrencyLabel.Text = "العملة:"
        Me.XrLabelCurrencyLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelPeriod
        '
        Me.XrLabelPeriod.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0.0001860725!, 152.3889!)
        Me.XrLabelPeriod.Multiline = True
        Me.XrLabelPeriod.Name = "XrLabelPeriod"
        Me.XrLabelPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelPeriod.SizeF = New System.Drawing.SizeF(779.9996!, 23.00002!)
        Me.XrLabelPeriod.StylePriority.UseFont = False
        Me.XrLabelPeriod.StylePriority.UseTextAlignment = False
        Me.XrLabelPeriod.Text = "من تاريخ: 30/05/2022 الى تاريخ 2022/05/01"
        Me.XrLabelPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelCurrency
        '
        Me.XrLabelCurrency.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelCurrency.LocationFloat = New DevExpress.Utils.PointFloat(720.2557!, 175.3889!)
        Me.XrLabelCurrency.Multiline = True
        Me.XrLabelCurrency.Name = "XrLabelCurrency"
        Me.XrLabelCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCurrency.SizeF = New System.Drawing.SizeF(59.74418!, 23.0!)
        Me.XrLabelCurrency.StylePriority.UseFont = False
        Me.XrLabelCurrency.StylePriority.UseTextAlignment = False
        Me.XrLabelCurrency.Text = "NIS"
        Me.XrLabelCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelAccountName
        '
        Me.XrLabelAccountName.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccountName.LocationFloat = New DevExpress.Utils.PointFloat(69.49469!, 175.389!)
        Me.XrLabelAccountName.Multiline = True
        Me.XrLabelAccountName.Name = "XrLabelAccountName"
        Me.XrLabelAccountName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccountName.SizeF = New System.Drawing.SizeF(310.1193!, 23.0!)
        Me.XrLabelAccountName.StylePriority.UseFont = False
        Me.XrLabelAccountName.StylePriority.UseTextAlignment = False
        Me.XrLabelAccountName.Text = "شركة الهدى للمحروقات"
        Me.XrLabelAccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelAccountLabel
        '
        Me.XrLabelAccountLabel.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003051758!, 175.389!)
        Me.XrLabelAccountLabel.Multiline = True
        Me.XrLabelAccountLabel.Name = "XrLabelAccountLabel"
        Me.XrLabelAccountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccountLabel.SizeF = New System.Drawing.SizeF(69.49432!, 23.0!)
        Me.XrLabelAccountLabel.StylePriority.UseFont = False
        Me.XrLabelAccountLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelAccountLabel.Text = "الحساب:"
        Me.XrLabelAccountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelAccountStatment
        '
        Me.XrLabelAccountStatment.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccountStatment.LocationFloat = New DevExpress.Utils.PointFloat(0.0003742642!, 129.3889!)
        Me.XrLabelAccountStatment.Multiline = True
        Me.XrLabelAccountStatment.Name = "XrLabelAccountStatment"
        Me.XrLabelAccountStatment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccountStatment.SizeF = New System.Drawing.SizeF(779.9995!, 23.0!)
        Me.XrLabelAccountStatment.StylePriority.UseFont = False
        Me.XrLabelAccountStatment.StylePriority.UseTextAlignment = False
        Me.XrLabelAccountStatment.Text = "كشف حساب"
        Me.XrLabelAccountStatment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelReforAcc, Me.XrPageInfo2, Me.XrLabelDateTime, Me.XrLabelUser})
        Me.PageFooter.HeightF = 39.7916!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabelReforAcc
        '
        Me.XrLabelReforAcc.LocationFloat = New DevExpress.Utils.PointFloat(542.3332!, 16.7916!)
        Me.XrLabelReforAcc.Multiline = True
        Me.XrLabelReforAcc.Name = "XrLabelReforAcc"
        Me.XrLabelReforAcc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelReforAcc.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabelReforAcc.Text = "ReforAcc"
        Me.XrLabelReforAcc.Visible = False
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.Font = New DevExpress.Drawing.DXFont("Arial", 6.75!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(658.7748!, 16.7916!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(98.51678!, 23.0!)
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrPageInfo2.TextFormatString = "Page {0} of {1}"
        '
        'XrLabelDateTime
        '
        Me.XrLabelDateTime.Font = New DevExpress.Drawing.DXFont("Arial", 6.75!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDateTime.LocationFloat = New DevExpress.Utils.PointFloat(140.1348!, 16.7916!)
        Me.XrLabelDateTime.Name = "XrLabelDateTime"
        Me.XrLabelDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDateTime.SizeF = New System.Drawing.SizeF(188.2707!, 23.0!)
        Me.XrLabelDateTime.StylePriority.UseFont = False
        Me.XrLabelDateTime.Text = "XrLabelDateTime"
        '
        'XrLabelUser
        '
        Me.XrLabelUser.Font = New DevExpress.Drawing.DXFont("Arial", 6.75!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelUser.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 16.7916!)
        Me.XrLabelUser.Name = "XrLabelUser"
        Me.XrLabelUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelUser.SizeF = New System.Drawing.SizeF(130.1345!, 23.0!)
        Me.XrLabelUser.StylePriority.UseFont = False
        Me.XrLabelUser.Text = "XrLabelUser"
        Me.XrLabelUser.TextFormatString = "المستخدم{0}"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.HeaderPicture, Me.XrLabelCurrency, Me.XrLabelCurrencyLabel, Me.XrLabelAccountName, Me.XrLabelAccountLabel, Me.XrLabelPeriod, Me.XrLabelAccountStatment})
        Me.PageHeader.HeightF = 198.389!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel3
        '
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(9.999939!, 10.00001!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(369.614!, 23.0!)
        Me.XrLabel3.Text = "شركة حسام ابو لحية واولاده للمقاولات"
        '
        'ReportAccountStatment
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageFooter, Me.PageHeader})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(29.0!, 41.0!, 27.0!, 54.0!)
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ShowPrintMarginsWarning = False
        Me.Version = "23.2"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.Add(XrWatermark1)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PrintableComponentContainer1 As DevExpress.XtraReports.UI.PrintableComponentContainer
    Friend WithEvents HeaderPicture As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabelPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCurrency As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccountName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccountLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccountStatment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents FooterPicture As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabelCurrencyLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabelDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelUser As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabelReportNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelReforAcc As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
End Class
