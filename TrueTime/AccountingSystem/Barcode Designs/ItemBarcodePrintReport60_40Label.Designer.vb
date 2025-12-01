<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ItemBarcodePrintReport60_40Label
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
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.lblItemName = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblPrice = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.BottomMargin.HeightF = 12.42495!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'lblItemName
        '
        Me.lblItemName.Dpi = 254.0!
        Me.lblItemName.Font = New DevExpress.Drawing.DXFont("Arial", 24.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName.LocationFloat = New DevExpress.Utils.PointFloat(11.7709!, 35.74261!)
        Me.lblItemName.Multiline = True
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName.SizeF = New System.Drawing.SizeF(678.1873!, 197.0907!)
        Me.lblItemName.StylePriority.UseFont = False
        Me.lblItemName.StylePriority.UseTextAlignment = False
        Me.lblItemName.Text = "الصنف"
        Me.lblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblPrice, Me.lblItemName})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 344.17!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.KeepTogether = True
        Me.Detail.MultiColumn.ColumnCount = 2
        Me.Detail.MultiColumn.ColumnWidth = 5.0!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.Name = "Detail"
        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
        '
        'lblPrice
        '
        Me.lblPrice.CanShrink = True
        Me.lblPrice.Dpi = 254.0!
        Me.lblPrice.Font = New DevExpress.Drawing.DXFont("Arial", 28.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblPrice.LocationFloat = New DevExpress.Utils.PointFloat(11.77072!, 232.8333!)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice.SizeF = New System.Drawing.SizeF(678.1875!, 111.3367!)
        Me.lblPrice.StylePriority.UseFont = False
        Me.lblPrice.StylePriority.UseTextAlignment = False
        Me.lblPrice.Text = "السعر"
        Me.lblPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblPrice.TextFormatString = "{0:N2}"
        Me.lblPrice.WordWrap = False
        '
        'ItemBarcodePrintReport60_40Label
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 13.22917!, 12.42495!)
        Me.PageHeight = 400
        Me.PageWidth = 700
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.ReportPrintOptions.DetailCountAtDesignTime = 2
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ShowPrintMarginsWarning = False
        Me.SnapGridSize = 25.0!
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblItemName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents lblPrice As DevExpress.XtraReports.UI.XRLabel
End Class
