<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ItemBarcodePrintReport50_25
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
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblPrice = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblItemName = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrBarCode1 = New DevExpress.XtraReports.UI.XRBarCode()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.HeightF = 13.22917!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.HeightF = 33.06589!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'lblPrice
        '
        Me.lblPrice.Dpi = 254.0!
        Me.lblPrice.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblPrice.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 166.8217!)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice.SizeF = New System.Drawing.SizeF(426.0001!, 43.06592!)
        Me.lblPrice.StylePriority.UseFont = False
        Me.lblPrice.StylePriority.UseTextAlignment = False
        Me.lblPrice.Text = "السعر"
        Me.lblPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        Me.lblPrice.TextFormatString = "NIS {0}"
        '
        'lblItemName
        '
        Me.lblItemName.CanShrink = True
        Me.lblItemName.Dpi = 254.0!
        Me.lblItemName.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 0!)
        Me.lblItemName.Multiline = True
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName.SizeF = New System.Drawing.SizeF(426.0!, 92.49752!)
        Me.lblItemName.StylePriority.UseFont = False
        Me.lblItemName.StylePriority.UseTextAlignment = False
        Me.lblItemName.Text = "الصنف"
        Me.lblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrBarCode1, Me.lblItemName, Me.lblPrice})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 209.8876!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.KeepTogether = True
        Me.Detail.MultiColumn.ColumnCount = 2
        Me.Detail.MultiColumn.ColumnWidth = 5.0!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.Name = "Detail"
        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
        '
        'XrBarCode1
        '
        Me.XrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode1.AutoModule = True
        Me.XrBarCode1.Dpi = 254.0!
        Me.XrBarCode1.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode1.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 92.49752!)
        Me.XrBarCode1.Module = 5.08!
        Me.XrBarCode1.Name = "XrBarCode1"
        Me.XrBarCode1.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode1.SizeF = New System.Drawing.SizeF(426.0!, 74.32421!)
        Me.XrBarCode1.StylePriority.UseFont = False
        Me.XrBarCode1.StylePriority.UseTextAlignment = False
        Me.XrBarCode1.Symbology = Code128Generator1
        Me.XrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ItemBarcodePrintReport50_25
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(12.0!, 12.0!, 13.22917!, 33.06589!)
        Me.PageHeight = 250
        Me.PageWidth = 500
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
End Class
