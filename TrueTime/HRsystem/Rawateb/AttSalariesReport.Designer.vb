<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class AttSalariesReport
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.PrintableComponentContainer1 = New DevExpress.XtraReports.UI.PrintableComponentContainer()
        Me.XrLabelCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabelPeriodName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLabelSignature4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelSignature3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelSignature2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelSignature1 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 27.08333!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 10.41654!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.PrintableComponentContainer1})
        Me.Detail.HeightF = 288.5417!
        Me.Detail.Name = "Detail"
        '
        'PrintableComponentContainer1
        '
        Me.PrintableComponentContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001618067!, 0!)
        Me.PrintableComponentContainer1.Name = "PrintableComponentContainer1"
        Me.PrintableComponentContainer1.SizeF = New System.Drawing.SizeF(769.9999!, 288.5417!)
        '
        'XrLabelCompanyName
        '
        Me.XrLabelCompanyName.Font = New DevExpress.Drawing.DXFont("Arial", 16.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 10.00001!)
        Me.XrLabelCompanyName.Multiline = True
        Me.XrLabelCompanyName.Name = "XrLabelCompanyName"
        Me.XrLabelCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCompanyName.SizeF = New System.Drawing.SizeF(499.9999!, 23.0!)
        Me.XrLabelCompanyName.StylePriority.UseFont = False
        Me.XrLabelCompanyName.StylePriority.UseTextAlignment = False
        Me.XrLabelCompanyName.Text = "شركة تروتايم سوليوشنز"
        Me.XrLabelCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelPeriodName, Me.XrLabel2, Me.XrPictureBox1, Me.XrLabelCompanyName})
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabelPeriodName
        '
        Me.XrLabelPeriodName.LocationFloat = New DevExpress.Utils.PointFloat(0.0002441406!, 71.16667!)
        Me.XrLabelPeriodName.Multiline = True
        Me.XrLabelPeriodName.Name = "XrLabelPeriodName"
        Me.XrLabelPeriodName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelPeriodName.SizeF = New System.Drawing.SizeF(315.6249!, 23.0!)
        Me.XrLabelPeriodName.StylePriority.UseTextAlignment = False
        Me.XrLabelPeriodName.Text = "للفترة بين"
        Me.XrLabelPeriodName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0002441406!, 48.16669!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(315.6249!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "كشف الرواتب"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(536.667!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(233.3331!, 100.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox1.StylePriority.UseBackColor = False
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelSignature4, Me.XrLabelSignature3, Me.XrLabelSignature2, Me.XrLabelSignature1})
        Me.PageFooter.HeightF = 141.6667!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabelSignature4
        '
        Me.XrLabelSignature4.LocationFloat = New DevExpress.Utils.PointFloat(536.6668!, 66.25004!)
        Me.XrLabelSignature4.Multiline = True
        Me.XrLabelSignature4.Name = "XrLabelSignature4"
        Me.XrLabelSignature4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelSignature4.SizeF = New System.Drawing.SizeF(233.3332!, 23.00001!)
        Me.XrLabelSignature4.StylePriority.UseTextAlignment = False
        Me.XrLabelSignature4.Text = "توقيع 4"
        Me.XrLabelSignature4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabelSignature3
        '
        Me.XrLabelSignature3.LocationFloat = New DevExpress.Utils.PointFloat(0.0001831055!, 66.25004!)
        Me.XrLabelSignature3.Multiline = True
        Me.XrLabelSignature3.Name = "XrLabelSignature3"
        Me.XrLabelSignature3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelSignature3.SizeF = New System.Drawing.SizeF(277.0833!, 23.0!)
        Me.XrLabelSignature3.StylePriority.UseTextAlignment = False
        Me.XrLabelSignature3.Text = "توقيع 3"
        Me.XrLabelSignature3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelSignature2
        '
        Me.XrLabelSignature2.LocationFloat = New DevExpress.Utils.PointFloat(536.6668!, 9.999911!)
        Me.XrLabelSignature2.Multiline = True
        Me.XrLabelSignature2.Name = "XrLabelSignature2"
        Me.XrLabelSignature2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelSignature2.SizeF = New System.Drawing.SizeF(233.3332!, 23.0!)
        Me.XrLabelSignature2.StylePriority.UseTextAlignment = False
        Me.XrLabelSignature2.Text = "توقيع 2"
        Me.XrLabelSignature2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabelSignature1
        '
        Me.XrLabelSignature1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001831055!, 9.999911!)
        Me.XrLabelSignature1.Multiline = True
        Me.XrLabelSignature1.Name = "XrLabelSignature1"
        Me.XrLabelSignature1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelSignature1.SizeF = New System.Drawing.SizeF(277.0834!, 23.0!)
        Me.XrLabelSignature1.StylePriority.UseTextAlignment = False
        Me.XrLabelSignature1.Text = "توقيع 1"
        Me.XrLabelSignature1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'AttSalariesReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.PageHeader, Me.PageFooter})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(40.0!, 40.0!, 27.08333!, 10.41654!)
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
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
    Friend WithEvents XrLabelCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabelPeriodName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabelSignature4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelSignature3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelSignature2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelSignature1 As DevExpress.XtraReports.UI.XRLabel
End Class
