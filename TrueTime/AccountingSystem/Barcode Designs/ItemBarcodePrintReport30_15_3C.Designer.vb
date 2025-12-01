<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ItemBarcodePrintReport30_15_3C
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Code128Generator1 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Dim Code128Generator2 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Dim Code128Generator3 As DevExpress.XtraPrinting.BarCode.Code128Generator = New DevExpress.XtraPrinting.BarCode.Code128Generator()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblPrice = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblItemName = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrBarCode3 = New DevExpress.XtraReports.UI.XRBarCode()
        Me.lblItemName3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrice3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrice2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblItemName2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrBarCode2 = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrBarCode1 = New DevExpress.XtraReports.UI.XRBarCode()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.HeightF = 5.291667!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.HeightF = 7.982717!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'lblPrice
        '
        Me.lblPrice.Dpi = 254.0!
        Me.lblPrice.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.lblPrice.LocationFloat = New DevExpress.Utils.PointFloat(33.99997!, 69.38103!)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice.SizeF = New System.Drawing.SizeF(274.9999!, 34.67343!)
        Me.lblPrice.StylePriority.UseFont = False
        Me.lblPrice.StylePriority.UseTextAlignment = False
        Me.lblPrice.Text = "السعر"
        Me.lblPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblItemName
        '
        Me.lblItemName.CanShrink = True
        Me.lblItemName.Dpi = 254.0!
        Me.lblItemName.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName.LocationFloat = New DevExpress.Utils.PointFloat(34.0!, 0!)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName.SizeF = New System.Drawing.SizeF(275.0!, 33.2308!)
        Me.lblItemName.StylePriority.UseFont = False
        Me.lblItemName.StylePriority.UseTextAlignment = False
        Me.lblItemName.Text = "الصنف"
        Me.lblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.lblItemName.WordWrap = False
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrBarCode3, Me.lblItemName3, Me.lblPrice3, Me.lblPrice2, Me.lblItemName2, Me.XrBarCode2, Me.XrBarCode1, Me.lblItemName, Me.lblPrice})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 122.5752!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.KeepTogether = True
        Me.Detail.MultiColumn.ColumnCount = 2
        Me.Detail.MultiColumn.ColumnWidth = 5.0!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.Name = "Detail"
        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
        '
        'XrBarCode3
        '
        Me.XrBarCode3.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode3.AutoModule = True
        Me.XrBarCode3.Dpi = 254.0!
        Me.XrBarCode3.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode3.LocationFloat = New DevExpress.Utils.PointFloat(689.5833!, 33.23077!)
        Me.XrBarCode3.Module = 5.08!
        Me.XrBarCode3.Name = "XrBarCode3"
        Me.XrBarCode3.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode3.ShowText = False
        Me.XrBarCode3.SizeF = New System.Drawing.SizeF(270.0!, 36.15015!)
        Me.XrBarCode3.StylePriority.UseFont = False
        Me.XrBarCode3.StylePriority.UseTextAlignment = False
        Me.XrBarCode3.Symbology = Code128Generator1
        Me.XrBarCode3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblItemName3
        '
        Me.lblItemName3.CanShrink = True
        Me.lblItemName3.Dpi = 254.0!
        Me.lblItemName3.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName3.LocationFloat = New DevExpress.Utils.PointFloat(689.5833!, 0!)
        Me.lblItemName3.Name = "lblItemName3"
        Me.lblItemName3.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName3.SizeF = New System.Drawing.SizeF(270.0!, 33.2308!)
        Me.lblItemName3.StylePriority.UseFont = False
        Me.lblItemName3.StylePriority.UseTextAlignment = False
        Me.lblItemName3.Text = "الصنف"
        Me.lblItemName3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.lblItemName3.WordWrap = False
        '
        'lblPrice3
        '
        Me.lblPrice3.Dpi = 254.0!
        Me.lblPrice3.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.lblPrice3.LocationFloat = New DevExpress.Utils.PointFloat(689.5833!, 69.38094!)
        Me.lblPrice3.Name = "lblPrice3"
        Me.lblPrice3.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice3.SizeF = New System.Drawing.SizeF(270.0!, 34.67348!)
        Me.lblPrice3.StylePriority.UseFont = False
        Me.lblPrice3.StylePriority.UseTextAlignment = False
        Me.lblPrice3.Text = "السعر"
        Me.lblPrice3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblPrice2
        '
        Me.lblPrice2.Dpi = 254.0!
        Me.lblPrice2.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.lblPrice2.LocationFloat = New DevExpress.Utils.PointFloat(364.1457!, 69.38094!)
        Me.lblPrice2.Name = "lblPrice2"
        Me.lblPrice2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice2.SizeF = New System.Drawing.SizeF(270.0!, 34.67352!)
        Me.lblPrice2.StylePriority.UseFont = False
        Me.lblPrice2.StylePriority.UseTextAlignment = False
        Me.lblPrice2.Text = "السعر"
        Me.lblPrice2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblItemName2
        '
        Me.lblItemName2.CanShrink = True
        Me.lblItemName2.Dpi = 254.0!
        Me.lblItemName2.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName2.LocationFloat = New DevExpress.Utils.PointFloat(364.1457!, 0!)
        Me.lblItemName2.Name = "lblItemName2"
        Me.lblItemName2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName2.SizeF = New System.Drawing.SizeF(270.0001!, 33.2308!)
        Me.lblItemName2.StylePriority.UseFont = False
        Me.lblItemName2.StylePriority.UseTextAlignment = False
        Me.lblItemName2.Text = "الصنف"
        Me.lblItemName2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.lblItemName2.WordWrap = False
        '
        'XrBarCode2
        '
        Me.XrBarCode2.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode2.AutoModule = True
        Me.XrBarCode2.Dpi = 254.0!
        Me.XrBarCode2.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode2.LocationFloat = New DevExpress.Utils.PointFloat(364.1457!, 33.23077!)
        Me.XrBarCode2.Module = 5.08!
        Me.XrBarCode2.Name = "XrBarCode2"
        Me.XrBarCode2.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode2.ShowText = False
        Me.XrBarCode2.SizeF = New System.Drawing.SizeF(270.0001!, 36.15016!)
        Me.XrBarCode2.StylePriority.UseFont = False
        Me.XrBarCode2.StylePriority.UseTextAlignment = False
        Me.XrBarCode2.Symbology = Code128Generator2
        Me.XrBarCode2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrBarCode1
        '
        Me.XrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode1.AutoModule = True
        Me.XrBarCode1.Dpi = 254.0!
        Me.XrBarCode1.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode1.LocationFloat = New DevExpress.Utils.PointFloat(33.99997!, 33.23077!)
        Me.XrBarCode1.Module = 5.08!
        Me.XrBarCode1.Name = "XrBarCode1"
        Me.XrBarCode1.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode1.ShowText = False
        Me.XrBarCode1.SizeF = New System.Drawing.SizeF(275.0!, 36.15016!)
        Me.XrBarCode1.StylePriority.UseFont = False
        Me.XrBarCode1.StylePriority.UseTextAlignment = False
        Me.XrBarCode1.Symbology = Code128Generator3
        Me.XrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ItemBarcodePrintReport30_15_3C
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 13.0!, 5.291667!, 7.982717!)
        Me.PageHeight = 250
        Me.PageWidth = 1000
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.ReportPrintOptions.DetailCountAtDesignTime = 2
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.ShowPrintMarginsWarning = False
        Me.SnapGridSize = 25.0!
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblPrice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblItemName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrBarCode1 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents lblPrice2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblItemName2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrBarCode2 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrBarCode3 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents lblItemName3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrice3 As DevExpress.XtraReports.UI.XRLabel
End Class
