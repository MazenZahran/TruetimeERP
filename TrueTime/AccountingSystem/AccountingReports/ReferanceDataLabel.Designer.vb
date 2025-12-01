<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReferanceDataLabel
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
        Me.XrLabelMobile = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelName = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 254.0!
        Me.TopMargin.HeightF = 74.08334!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 254.0!
        Me.BottomMargin.HeightF = 26.93456!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelMobile, Me.XrLabelAddress, Me.XrLabelName})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 290.5654!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.Name = "Detail"
        '
        'XrLabelMobile
        '
        Me.XrLabelMobile.CanGrow = False
        Me.XrLabelMobile.Dpi = 254.0!
        Me.XrLabelMobile.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelMobile.LocationFloat = New DevExpress.Utils.PointFloat(30.33349!, 106.045!)
        Me.XrLabelMobile.Multiline = True
        Me.XrLabelMobile.Name = "XrLabelMobile"
        Me.XrLabelMobile.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelMobile.SizeF = New System.Drawing.SizeF(694.6665!, 58.42002!)
        Me.XrLabelMobile.StylePriority.UseFont = False
        Me.XrLabelMobile.StylePriority.UseTextAlignment = False
        Me.XrLabelMobile.Text = "Mobile"
        Me.XrLabelMobile.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelAddress
        '
        Me.XrLabelAddress.CanGrow = False
        Me.XrLabelAddress.Dpi = 254.0!
        Me.XrLabelAddress.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelAddress.LocationFloat = New DevExpress.Utils.PointFloat(30.33355!, 164.465!)
        Me.XrLabelAddress.Multiline = True
        Me.XrLabelAddress.Name = "XrLabelAddress"
        Me.XrLabelAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelAddress.SizeF = New System.Drawing.SizeF(694.6664!, 126.1004!)
        Me.XrLabelAddress.StylePriority.UseFont = False
        Me.XrLabelAddress.StylePriority.UseTextAlignment = False
        Me.XrLabelAddress.Text = "Adress:"
        Me.XrLabelAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelName
        '
        Me.XrLabelName.BackColor = System.Drawing.Color.Black
        Me.XrLabelName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLabelName.CanGrow = False
        Me.XrLabelName.Dpi = 254.0!
        Me.XrLabelName.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelName.ForeColor = System.Drawing.Color.White
        Me.XrLabelName.LocationFloat = New DevExpress.Utils.PointFloat(30.33351!, 0!)
        Me.XrLabelName.Multiline = True
        Me.XrLabelName.Name = "XrLabelName"
        Me.XrLabelName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelName.SizeF = New System.Drawing.SizeF(694.6666!, 106.045!)
        Me.XrLabelName.StylePriority.UseBackColor = False
        Me.XrLabelName.StylePriority.UseBorders = False
        Me.XrLabelName.StylePriority.UseFont = False
        Me.XrLabelName.StylePriority.UseForeColor = False
        Me.XrLabelName.StylePriority.UseTextAlignment = False
        Me.XrLabelName.Text = "Name"
        Me.XrLabelName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReferanceDataLabel
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.DesignerOptions.ShowExportWarnings = False
        Me.DesignerOptions.ShowPrintingWarnings = False
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 0!, 74.08334!, 26.93456!)
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
    Friend WithEvents XrLabelName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelMobile As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAddress As DevExpress.XtraReports.UI.XRLabel
End Class
