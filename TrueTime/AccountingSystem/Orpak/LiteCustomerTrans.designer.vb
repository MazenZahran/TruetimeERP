<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class LiteCustomerTrans
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
        Me.HeaderPicture = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabelAccID = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelMonth = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabelUser = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PrintableComponentContainer2 = New DevExpress.XtraReports.UI.PrintableComponentContainer()
        Me.PrintableComponentContainer1 = New DevExpress.XtraReports.UI.PrintableComponentContainer()
        Me.XrLabelBegAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelBegAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRecieptAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRecieptAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDebitAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDebitAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRequirdAmountLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRequirdAmount = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.HeaderPicture, Me.XrLabelAccID, Me.XrLabelMonth, Me.XrLabel5, Me.XrLabel4, Me.XrLabel1})
        Me.TopMargin.HeightF = 203.125!
        Me.TopMargin.Name = "TopMargin"
        '
        'HeaderPicture
        '
        Me.HeaderPicture.LocationFloat = New DevExpress.Utils.PointFloat(0.00001335144!, 9.999959!)
        Me.HeaderPicture.Name = "HeaderPicture"
        Me.HeaderPicture.SizeF = New System.Drawing.SizeF(808.9999!, 90.87504!)
        Me.HeaderPicture.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabelAccID
        '
        Me.XrLabelAccID.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccID.LocationFloat = New DevExpress.Utils.PointFloat(70.83333!, 142.0!)
        Me.XrLabelAccID.Multiline = True
        Me.XrLabelAccID.Name = "XrLabelAccID"
        Me.XrLabelAccID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccID.SizeF = New System.Drawing.SizeF(429.1667!, 23.0!)
        Me.XrLabelAccID.StylePriority.UseFont = False
        '
        'XrLabelMonth
        '
        Me.XrLabelMonth.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelMonth.LocationFloat = New DevExpress.Utils.PointFloat(70.83345!, 170.125!)
        Me.XrLabelMonth.Multiline = True
        Me.XrLabelMonth.Name = "XrLabelMonth"
        Me.XrLabelMonth.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelMonth.SizeF = New System.Drawing.SizeF(429.1666!, 22.99999!)
        Me.XrLabelMonth.StylePriority.UseFont = False
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 170.125!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(70.83337!, 22.99999!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "الفترة:"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 142.0!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(70.83331!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "الحساب:"
        '
        'XrLabel1
        '
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 15.75!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle), DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00001335144!, 100.875!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(808.9999!, 29.25!)
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "تقرير تعبئة المحروقات"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelUser, Me.XrLabelDateTime, Me.XrPageInfo2})
        Me.BottomMargin.HeightF = 56.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'XrLabelUser
        '
        Me.XrLabelUser.Font = New DevExpress.Drawing.DXFont("Arial", 5.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelUser.LocationFloat = New DevExpress.Utils.PointFloat(133.3334!, 32.99999!)
        Me.XrLabelUser.Multiline = True
        Me.XrLabelUser.Name = "XrLabelUser"
        Me.XrLabelUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelUser.SizeF = New System.Drawing.SizeF(133.3333!, 23.0!)
        Me.XrLabelUser.StylePriority.UseFont = False
        Me.XrLabelUser.Text = "User:"
        '
        'XrLabelDateTime
        '
        Me.XrLabelDateTime.Font = New DevExpress.Drawing.DXFont("Arial", 5.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDateTime.LocationFloat = New DevExpress.Utils.PointFloat(0!, 33.0!)
        Me.XrLabelDateTime.Multiline = True
        Me.XrLabelDateTime.Name = "XrLabelDateTime"
        Me.XrLabelDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDateTime.SizeF = New System.Drawing.SizeF(133.3333!, 23.0!)
        Me.XrLabelDateTime.StylePriority.UseFont = False
        Me.XrLabelDateTime.Text = "DateTime"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(706.8165!, 9.999974!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(100.5168!, 23.0!)
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrPageInfo2.TextFormatString = "Page {0} of {1}"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel2, Me.PrintableComponentContainer2, Me.PrintableComponentContainer1, Me.XrLabelBegAmountLabel, Me.XrLabelBegAmount, Me.XrLabelRecieptAmountLabel, Me.XrLabelRecieptAmount, Me.XrLabelDebitAmountLabel, Me.XrLabelDebitAmount, Me.XrLabelRequirdAmountLabel, Me.XrLabelRequirdAmount})
        Me.Detail.HeightF = 277.1666!
        Me.Detail.Name = "Detail"
        Me.Detail.StylePriority.UseTextAlignment = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New DevExpress.Drawing.DXFont("Arial", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 125.125!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(198.9583!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "المجاميع"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New DevExpress.Drawing.DXFont("Arial", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 8.87502!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(198.9583!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "تفاصيل حركات التعبئة"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PrintableComponentContainer2
        '
        Me.PrintableComponentContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 148.125!)
        Me.PrintableComponentContainer2.Name = "PrintableComponentContainer2"
        Me.PrintableComponentContainer2.SizeF = New System.Drawing.SizeF(809.0!, 75.00003!)
        '
        'PrintableComponentContainer1
        '
        Me.PrintableComponentContainer1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.PrintableComponentContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 31.87501!)
        Me.PrintableComponentContainer1.Name = "PrintableComponentContainer1"
        Me.PrintableComponentContainer1.SizeF = New System.Drawing.SizeF(809.0!, 75.0!)
        '
        'XrLabelBegAmountLabel
        '
        Me.XrLabelBegAmountLabel.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabelBegAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 235.9166!)
        Me.XrLabelBegAmountLabel.Multiline = True
        Me.XrLabelBegAmountLabel.Name = "XrLabelBegAmountLabel"
        Me.XrLabelBegAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelBegAmountLabel.SizeF = New System.Drawing.SizeF(84.33344!, 25.00002!)
        Me.XrLabelBegAmountLabel.StylePriority.UseFont = False
        Me.XrLabelBegAmountLabel.StylePriority.UsePadding = False
        Me.XrLabelBegAmountLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelBegAmountLabel.Text = "رصيد بداية الفترة:"
        Me.XrLabelBegAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelBegAmount
        '
        Me.XrLabelBegAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelBegAmount.LocationFloat = New DevExpress.Utils.PointFloat(84.33344!, 235.9165!)
        Me.XrLabelBegAmount.Multiline = True
        Me.XrLabelBegAmount.Name = "XrLabelBegAmount"
        Me.XrLabelBegAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelBegAmount.SizeF = New System.Drawing.SizeF(81.29163!, 25.00002!)
        Me.XrLabelBegAmount.StylePriority.UseFont = False
        Me.XrLabelBegAmount.StylePriority.UsePadding = False
        Me.XrLabelBegAmount.StylePriority.UseTextAlignment = False
        Me.XrLabelBegAmount.Text = "0"
        Me.XrLabelBegAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabelBegAmount.TextFormatString = "{0:N1}"
        '
        'XrLabelRecieptAmountLabel
        '
        Me.XrLabelRecieptAmountLabel.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabelRecieptAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(176.0417!, 235.9166!)
        Me.XrLabelRecieptAmountLabel.Multiline = True
        Me.XrLabelRecieptAmountLabel.Name = "XrLabelRecieptAmountLabel"
        Me.XrLabelRecieptAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRecieptAmountLabel.SizeF = New System.Drawing.SizeF(92.66663!, 25.00002!)
        Me.XrLabelRecieptAmountLabel.StylePriority.UseFont = False
        Me.XrLabelRecieptAmountLabel.StylePriority.UsePadding = False
        Me.XrLabelRecieptAmountLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelRecieptAmountLabel.Text = "دفعات خلال الفترة:"
        Me.XrLabelRecieptAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelRecieptAmount
        '
        Me.XrLabelRecieptAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelRecieptAmount.LocationFloat = New DevExpress.Utils.PointFloat(268.7084!, 235.9167!)
        Me.XrLabelRecieptAmount.Multiline = True
        Me.XrLabelRecieptAmount.Name = "XrLabelRecieptAmount"
        Me.XrLabelRecieptAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRecieptAmount.SizeF = New System.Drawing.SizeF(81.29169!, 24.99997!)
        Me.XrLabelRecieptAmount.StylePriority.UseFont = False
        Me.XrLabelRecieptAmount.StylePriority.UsePadding = False
        Me.XrLabelRecieptAmount.StylePriority.UseTextAlignment = False
        Me.XrLabelRecieptAmount.Text = "0"
        Me.XrLabelRecieptAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabelRecieptAmount.TextFormatString = "{0:N1}"
        '
        'XrLabelDebitAmountLabel
        '
        Me.XrLabelDebitAmountLabel.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.XrLabelDebitAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(389.5834!, 235.9166!)
        Me.XrLabelDebitAmountLabel.Multiline = True
        Me.XrLabelDebitAmountLabel.Name = "XrLabelDebitAmountLabel"
        Me.XrLabelDebitAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDebitAmountLabel.SizeF = New System.Drawing.SizeF(78.08334!, 25.00002!)
        Me.XrLabelDebitAmountLabel.StylePriority.UseFont = False
        Me.XrLabelDebitAmountLabel.StylePriority.UsePadding = False
        Me.XrLabelDebitAmountLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelDebitAmountLabel.Text = "سحوبات الفترة:"
        Me.XrLabelDebitAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelDebitAmount
        '
        Me.XrLabelDebitAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDebitAmount.LocationFloat = New DevExpress.Utils.PointFloat(467.6669!, 235.9166!)
        Me.XrLabelDebitAmount.Multiline = True
        Me.XrLabelDebitAmount.Name = "XrLabelDebitAmount"
        Me.XrLabelDebitAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDebitAmount.SizeF = New System.Drawing.SizeF(81.29169!, 25.0!)
        Me.XrLabelDebitAmount.StylePriority.UseFont = False
        Me.XrLabelDebitAmount.StylePriority.UsePadding = False
        Me.XrLabelDebitAmount.StylePriority.UseTextAlignment = False
        Me.XrLabelDebitAmount.Text = "0"
        Me.XrLabelDebitAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabelDebitAmount.TextFormatString = "{0:N1}"
        '
        'XrLabelRequirdAmountLabel
        '
        Me.XrLabelRequirdAmountLabel.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle), DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelRequirdAmountLabel.LocationFloat = New DevExpress.Utils.PointFloat(575.0417!, 235.9167!)
        Me.XrLabelRequirdAmountLabel.Multiline = True
        Me.XrLabelRequirdAmountLabel.Name = "XrLabelRequirdAmountLabel"
        Me.XrLabelRequirdAmountLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRequirdAmountLabel.SizeF = New System.Drawing.SizeF(151.0001!, 25.0!)
        Me.XrLabelRequirdAmountLabel.StylePriority.UseFont = False
        Me.XrLabelRequirdAmountLabel.StylePriority.UsePadding = False
        Me.XrLabelRequirdAmountLabel.StylePriority.UseTextAlignment = False
        Me.XrLabelRequirdAmountLabel.Text = "الرصيد المطلوب بنهاية الفترة:"
        Me.XrLabelRequirdAmountLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelRequirdAmount
        '
        Me.XrLabelRequirdAmount.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle), DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelRequirdAmount.LocationFloat = New DevExpress.Utils.PointFloat(726.0417!, 235.9169!)
        Me.XrLabelRequirdAmount.Multiline = True
        Me.XrLabelRequirdAmount.Name = "XrLabelRequirdAmount"
        Me.XrLabelRequirdAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRequirdAmount.SizeF = New System.Drawing.SizeF(81.29156!, 25.0!)
        Me.XrLabelRequirdAmount.StylePriority.UseFont = False
        Me.XrLabelRequirdAmount.StylePriority.UsePadding = False
        Me.XrLabelRequirdAmount.StylePriority.UseTextAlignment = False
        Me.XrLabelRequirdAmount.Text = "0"
        Me.XrLabelRequirdAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabelRequirdAmount.TextFormatString = "{0:N1} NIS"
        '
        'LiteCustomerTrans
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(16.0!, 25.0!, 203.125!, 56.0!)
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.Version = "23.2"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.Add(XrWatermark1)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents PrintableComponentContainer2 As DevExpress.XtraReports.UI.PrintableComponentContainer
    Public WithEvents PrintableComponentContainer1 As DevExpress.XtraReports.UI.PrintableComponentContainer
    Friend WithEvents XrLabelMonth As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabelBegAmountLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelBegAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRecieptAmountLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRecieptAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDebitAmountLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDebitAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRequirdAmountLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRequirdAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents HeaderPicture As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabelDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelUser As DevExpress.XtraReports.UI.XRLabel
End Class
