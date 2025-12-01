<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ItemBarcodePrintReport50_100
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
        Me.lblItemName = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabelProductCompany = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelOtherCodes = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelItemCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrBarCode1 = New DevExpress.XtraReports.UI.XRBarCode()
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
        Me.BottomMargin.HeightF = 21.16667!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'lblItemName
        '
        Me.lblItemName.Dpi = 254.0!
        Me.lblItemName.Font = New DevExpress.Drawing.DXFont("Arial", 16.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.lblItemName.LocationFloat = New DevExpress.Utils.PointFloat(24.99999!, 0!)
        Me.lblItemName.Multiline = True
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblItemName.SizeF = New System.Drawing.SizeF(938.0!, 139.0642!)
        Me.lblItemName.StylePriority.UseFont = False
        Me.lblItemName.StylePriority.UseTextAlignment = False
        Me.lblItemName.Text = "الصنف"
        Me.lblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelProductCompany, Me.XrLabelDate, Me.XrLabelCompanyName, Me.XrLabelOtherCodes, Me.XrLabelItemCode, Me.XrBarCode1, Me.lblItemName, Me.lblPrice})
        Me.Detail.Dpi = 254.0!
        Me.Detail.HeightF = 563.5626!
        Me.Detail.HierarchyPrintOptions.Indent = 50.8!
        Me.Detail.KeepTogether = True
        Me.Detail.MultiColumn.ColumnCount = 2
        Me.Detail.MultiColumn.ColumnWidth = 5.0!
        Me.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown
        Me.Detail.Name = "Detail"
        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBandExceptFirstEntry
        '
        'XrLabelProductCompany
        '
        Me.XrLabelProductCompany.CanShrink = True
        Me.XrLabelProductCompany.Dpi = 254.0!
        Me.XrLabelProductCompany.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelProductCompany.LocationFloat = New DevExpress.Utils.PointFloat(24.99999!, 314.9883!)
        Me.XrLabelProductCompany.Name = "XrLabelProductCompany"
        Me.XrLabelProductCompany.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelProductCompany.SizeF = New System.Drawing.SizeF(938.0!, 52.91666!)
        Me.XrLabelProductCompany.StylePriority.UseFont = False
        Me.XrLabelProductCompany.StylePriority.UseTextAlignment = False
        Me.XrLabelProductCompany.Text = "السعر"
        Me.XrLabelProductCompany.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelProductCompany.WordWrap = False
        '
        'XrLabelDate
        '
        Me.XrLabelDate.Dpi = 254.0!
        Me.XrLabelDate.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrLabelDate.LocationFloat = New DevExpress.Utils.PointFloat(24.99999!, 438.3824!)
        Me.XrLabelDate.Multiline = True
        Me.XrLabelDate.Name = "XrLabelDate"
        Me.XrLabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelDate.SizeF = New System.Drawing.SizeF(254.0!, 58.42!)
        Me.XrLabelDate.StylePriority.UseFont = False
        Me.XrLabelDate.StylePriority.UseTextAlignment = False
        Me.XrLabelDate.Text = "XrLabelDate"
        Me.XrLabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabelCompanyName
        '
        Me.XrLabelCompanyName.CanShrink = True
        Me.XrLabelCompanyName.Dpi = 254.0!
        Me.XrLabelCompanyName.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 434.4674!)
        Me.XrLabelCompanyName.Name = "XrLabelCompanyName"
        Me.XrLabelCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelCompanyName.SizeF = New System.Drawing.SizeF(938.0!, 62.33502!)
        Me.XrLabelCompanyName.StylePriority.UseFont = False
        Me.XrLabelCompanyName.StylePriority.UseTextAlignment = False
        Me.XrLabelCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelCompanyName.WordWrap = False
        '
        'XrLabelOtherCodes
        '
        Me.XrLabelOtherCodes.CanShrink = True
        Me.XrLabelOtherCodes.Dpi = 254.0!
        Me.XrLabelOtherCodes.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelOtherCodes.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 367.9049!)
        Me.XrLabelOtherCodes.Name = "XrLabelOtherCodes"
        Me.XrLabelOtherCodes.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelOtherCodes.SizeF = New System.Drawing.SizeF(938.0!, 62.33502!)
        Me.XrLabelOtherCodes.StylePriority.UseFont = False
        Me.XrLabelOtherCodes.StylePriority.UseTextAlignment = False
        Me.XrLabelOtherCodes.Text = "ارقام اخرى للصنف"
        Me.XrLabelOtherCodes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelOtherCodes.WordWrap = False
        '
        'XrLabelItemCode
        '
        Me.XrLabelItemCode.CanShrink = True
        Me.XrLabelItemCode.Dpi = 254.0!
        Me.XrLabelItemCode.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelItemCode.LocationFloat = New DevExpress.Utils.PointFloat(25.00001!, 139.0642!)
        Me.XrLabelItemCode.Name = "XrLabelItemCode"
        Me.XrLabelItemCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.XrLabelItemCode.SizeF = New System.Drawing.SizeF(938.0!, 62.33502!)
        Me.XrLabelItemCode.StylePriority.UseFont = False
        Me.XrLabelItemCode.StylePriority.UseTextAlignment = False
        Me.XrLabelItemCode.Text = "كود الصنف"
        Me.XrLabelItemCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelItemCode.WordWrap = False
        '
        'XrBarCode1
        '
        Me.XrBarCode1.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrBarCode1.AutoModule = True
        Me.XrBarCode1.Dpi = 254.0!
        Me.XrBarCode1.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.XrBarCode1.LocationFloat = New DevExpress.Utils.PointFloat(24.99999!, 201.3992!)
        Me.XrBarCode1.Module = 5.08!
        Me.XrBarCode1.Name = "XrBarCode1"
        Me.XrBarCode1.Padding = New DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254.0!)
        Me.XrBarCode1.SizeF = New System.Drawing.SizeF(938.0!, 113.589!)
        Me.XrBarCode1.StylePriority.UseFont = False
        Me.XrBarCode1.StylePriority.UseTextAlignment = False
        Me.XrBarCode1.Symbology = Code128Generator1
        Me.XrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPrice
        '
        Me.lblPrice.Dpi = 254.0!
        Me.lblPrice.Font = New DevExpress.Drawing.DXFont("Arial", 8.0!)
        Me.lblPrice.LocationFloat = New DevExpress.Utils.PointFloat(0!, 465.8008!)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
        Me.lblPrice.SizeF = New System.Drawing.SizeF(24.99999!, 43.06598!)
        Me.lblPrice.StylePriority.UseFont = False
        Me.lblPrice.StylePriority.UseTextAlignment = False
        Me.lblPrice.Text = "السعر"
        Me.lblPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        Me.lblPrice.TextFormatString = "NIS {0}"
        '
        'ItemBarcodePrintReport50_100
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail})
        Me.Dpi = 254.0!
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 12.0!, 13.22917!, 21.16667!)
        Me.PageHeight = 500
        Me.PageWidth = 1000
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
    Friend WithEvents XrBarCode1 As DevExpress.XtraReports.UI.XRBarCode
    Friend WithEvents XrLabelItemCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelOtherCodes As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelProductCompany As DevExpress.XtraReports.UI.XRLabel
End Class
