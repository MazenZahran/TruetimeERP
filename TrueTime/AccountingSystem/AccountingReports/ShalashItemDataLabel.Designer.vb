<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ShalashItemDataLabel
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrBarCode = New DevExpress.XtraReports.UI.XRBarCode()
        Me.XrLabelItemNo2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDetails = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelItemName = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.HeightF = 0.1322997!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.HeightF = 6.111868!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrBarCode, Me.XrLabelItemNo2, Me.XrLabelDetails, Me.XrLabelDateTime, Me.XrLabelItemName})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 290.5654!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.Name = "Detail"
        '
        'XrBarCode
        '
        Me.XrBarCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode.AutoModule = True
        Me.XrBarCode.Dpi = 254.0!
        Me.XrBarCode.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode.LocationFloat = New DevExpress.Utils.PointFloat(30.33365!, 116.6812!)
        Me.XrBarCode.Module = 5.08!
        Me.XrBarCode.Name = "XrBarCode"
        Me.XrBarCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode.SizeF = New System.Drawing.SizeF(694.6663!, 83.15857!)
        Me.XrBarCode.StylePriority.UseFont = False
        Me.XrBarCode.StylePriority.UseTextAlignment = False
        Me.XrBarCode.Symbology = Code128Generator1
        Me.XrBarCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelItemNo2
        '
        Me.XrLabelItemNo2.CanGrow = False
        Me.XrLabelItemNo2.Dpi = 254.0!
        Me.XrLabelItemNo2.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelItemNo2.LocationFloat = New DevExpress.Utils.PointFloat(30.33362!, 72.54867!)
        Me.XrLabelItemNo2.Multiline = True
        Me.XrLabelItemNo2.Name = "XrLabelItemNo2"
        Me.XrLabelItemNo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelItemNo2.SizeF = New System.Drawing.SizeF(694.6665!, 44.13253!)
        Me.XrLabelItemNo2.StylePriority.UseFont = False
        Me.XrLabelItemNo2.StylePriority.UseTextAlignment = False
        Me.XrLabelItemNo2.Text = "ItemNo2"
        Me.XrLabelItemNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelDetails
        '
        Me.XrLabelDetails.CanGrow = False
        Me.XrLabelDetails.Dpi = 254.0!
        Me.XrLabelDetails.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelDetails.LocationFloat = New DevExpress.Utils.PointFloat(30.33365!, 199.8398!)
        Me.XrLabelDetails.Name = "XrLabelDetails"
        Me.XrLabelDetails.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelDetails.SizeF = New System.Drawing.SizeF(694.6665!, 45.4554!)
        Me.XrLabelDetails.StylePriority.UseFont = False
        Me.XrLabelDetails.StylePriority.UseTextAlignment = False
        Me.XrLabelDetails.Text = "Details"
        Me.XrLabelDetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelDateTime
        '
        Me.XrLabelDateTime.CanGrow = False
        Me.XrLabelDateTime.CanShrink = True
        Me.XrLabelDateTime.Dpi = 254.0!
        Me.XrLabelDateTime.Font = New DevExpress.Drawing.DXFont("Arial", 9.0!)
        Me.XrLabelDateTime.LocationFloat = New DevExpress.Utils.PointFloat(30.33353!, 245.2952!)
        Me.XrLabelDateTime.Name = "XrLabelDateTime"
        Me.XrLabelDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelDateTime.SizeF = New System.Drawing.SizeF(694.6664!, 45.27028!)
        Me.XrLabelDateTime.StylePriority.UseFont = False
        Me.XrLabelDateTime.StylePriority.UseTextAlignment = False
        Me.XrLabelDateTime.Text = "DateTime"
        Me.XrLabelDateTime.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabelItemName
        '
        Me.XrLabelItemName.BackColor = System.Drawing.Color.Transparent
        Me.XrLabelItemName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLabelItemName.Dpi = 254.0!
        Me.XrLabelItemName.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelItemName.ForeColor = System.Drawing.Color.Black
        Me.XrLabelItemName.LocationFloat = New DevExpress.Utils.PointFloat(30.3335!, 0!)
        Me.XrLabelItemName.Multiline = True
        Me.XrLabelItemName.Name = "XrLabelItemName"
        Me.XrLabelItemName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelItemName.SizeF = New System.Drawing.SizeF(694.6666!, 72.54868!)
        Me.XrLabelItemName.StylePriority.UseBackColor = False
        Me.XrLabelItemName.StylePriority.UseBorders = False
        Me.XrLabelItemName.StylePriority.UseFont = False
        Me.XrLabelItemName.StylePriority.UseForeColor = False
        Me.XrLabelItemName.StylePriority.UseTextAlignment = False
        Me.XrLabelItemName.Text = "Name"
        Me.XrLabelItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ShalashItemDataLabel
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.DesignerOptions.ShowExportWarnings = False
        Me.DesignerOptions.ShowPrintingWarnings = False
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 0.1322997!, 6.111868!)
        Me.PageHeight = 500
        Me.PageWidth = 750
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ShowPreviewMarginLines = False
        Me.ShowPrintMarginsWarning = False
        Me.SnapGridSize = 33.07292!
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabelItemName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDetails As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelItemNo2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrBarCode As DevExpress.XtraReports.UI.XRBarCode
End Class
