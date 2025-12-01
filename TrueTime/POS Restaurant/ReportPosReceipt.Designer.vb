<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportPosReceipt
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
    'Do  not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabelAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCompanyName = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabelDocDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelVoucherName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCustomer = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelVoucherNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabelAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabelUserName = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabelNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelBalance = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.BorderWidth = 0!
        Me.TopMargin.HeightF = 2.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.StylePriority.UseBorderWidth = False
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 14.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.BorderWidth = 0.2!
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelAmount})
        Me.Detail.HeightF = 22.74882!
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.StylePriority.UseBorderWidth = False
        '
        'XrLabelAmount
        '
        Me.XrLabelAmount.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabelAmount.BorderWidth = 0.2!
        Me.XrLabelAmount.Font = New DevExpress.Drawing.DXFont("Arial", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelAmount.LocationFloat = New DevExpress.Utils.PointFloat(9.542053!, 0!)
        Me.XrLabelAmount.Multiline = True
        Me.XrLabelAmount.Name = "XrLabelAmount"
        Me.XrLabelAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 0, 2, 0, 100.0!)
        Me.XrLabelAmount.SizeF = New System.Drawing.SizeF(282.4149!, 22.0!)
        Me.XrLabelAmount.StylePriority.UseBorders = False
        Me.XrLabelAmount.StylePriority.UseBorderWidth = False
        Me.XrLabelAmount.StylePriority.UseFont = False
        Me.XrLabelAmount.StylePriority.UsePadding = False
        Me.XrLabelAmount.StylePriority.UseTextAlignment = False
        Me.XrLabelAmount.Text = "0"
        Me.XrLabelAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelAmount.TextFormatString = "{0:#.00}"
        '
        'XrLabelCompanyName
        '
        Me.XrLabelCompanyName.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelCompanyName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelCompanyName.CanGrow = False
        Me.XrLabelCompanyName.Font = New DevExpress.Drawing.DXFont("Arial Narrow", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelCompanyName.LocationFloat = New DevExpress.Utils.PointFloat(35.41669!, 82.2083!)
        Me.XrLabelCompanyName.Name = "XrLabelCompanyName"
        Me.XrLabelCompanyName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCompanyName.SizeF = New System.Drawing.SizeF(233.4006!, 21.54183!)
        Me.XrLabelCompanyName.StylePriority.UseFont = False
        Me.XrLabelCompanyName.StylePriority.UseTextAlignment = False
        Me.XrLabelCompanyName.Text = "TTS Resturant"
        Me.XrLabelCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelCompanyName.WordWrap = False
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelBalance, Me.XrLabelDocDate, Me.XrLabelVoucherName, Me.XrLabelCustomer, Me.XrLabelVoucherNo, Me.XrPictureBox1, Me.XrLabelAddress, Me.XrLabelCompanyName})
        Me.ReportHeader.HeightF = 207.8755!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseTextAlignment = False
        Me.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabelDocDate
        '
        Me.XrLabelDocDate.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelDocDate.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelDocDate.AutoWidth = True
        Me.XrLabelDocDate.CanGrow = False
        Me.XrLabelDocDate.Font = New DevExpress.Drawing.DXFont("Arial", 8.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDocDate.LocationFloat = New DevExpress.Utils.PointFloat(35.41678!, 144.3331!)
        Me.XrLabelDocDate.Name = "XrLabelDocDate"
        Me.XrLabelDocDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDocDate.SizeF = New System.Drawing.SizeF(125.2073!, 23.20836!)
        Me.XrLabelDocDate.StylePriority.UseFont = False
        Me.XrLabelDocDate.StylePriority.UseTextAlignment = False
        Me.XrLabelDocDate.Text = "XrLabelDocDate"
        Me.XrLabelDocDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.XrLabelDocDate.TextFormatString = "{0:dd/MM/yyyy HH:mm:ss}"
        '
        'XrLabelVoucherName
        '
        Me.XrLabelVoucherName.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelVoucherName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelVoucherName.CanGrow = False
        Me.XrLabelVoucherName.Font = New DevExpress.Drawing.DXFont("Arial", 11.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelVoucherName.LocationFloat = New DevExpress.Utils.PointFloat(35.41676!, 123.5421!)
        Me.XrLabelVoucherName.Name = "XrLabelVoucherName"
        Me.XrLabelVoucherName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelVoucherName.SizeF = New System.Drawing.SizeF(233.4006!, 20.791!)
        Me.XrLabelVoucherName.StylePriority.UseFont = False
        Me.XrLabelVoucherName.StylePriority.UseTextAlignment = False
        Me.XrLabelVoucherName.Text = "سند قبض"
        Me.XrLabelVoucherName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabelCustomer
        '
        Me.XrLabelCustomer.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelCustomer.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelCustomer.CanGrow = False
        Me.XrLabelCustomer.Font = New DevExpress.Drawing.DXFont("Arial Narrow", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelCustomer.LocationFloat = New DevExpress.Utils.PointFloat(35.41672!, 167.5414!)
        Me.XrLabelCustomer.Multiline = True
        Me.XrLabelCustomer.Name = "XrLabelCustomer"
        Me.XrLabelCustomer.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCustomer.SizeF = New System.Drawing.SizeF(261.2917!, 26.08298!)
        Me.XrLabelCustomer.StylePriority.UseFont = False
        Me.XrLabelCustomer.StylePriority.UseTextAlignment = False
        Me.XrLabelCustomer.Text = "الزبون:"
        Me.XrLabelCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelVoucherNo
        '
        Me.XrLabelVoucherNo.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelVoucherNo.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelVoucherNo.CanGrow = False
        Me.XrLabelVoucherNo.Font = New DevExpress.Drawing.DXFont("Arial", 11.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelVoucherNo.LocationFloat = New DevExpress.Utils.PointFloat(188.5149!, 144.3331!)
        Me.XrLabelVoucherNo.Name = "XrLabelVoucherNo"
        Me.XrLabelVoucherNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelVoucherNo.SizeF = New System.Drawing.SizeF(108.1934!, 23.20837!)
        Me.XrLabelVoucherNo.StylePriority.UseFont = False
        Me.XrLabelVoucherNo.StylePriority.UseTextAlignment = False
        Me.XrLabelVoucherNo.Text = "Voucher No:"
        Me.XrLabelVoucherNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(35.41672!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(233.4006!, 82.20827!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabelAddress
        '
        Me.XrLabelAddress.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelAddress.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelAddress.CanGrow = False
        Me.XrLabelAddress.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAddress.LocationFloat = New DevExpress.Utils.PointFloat(0!, 103.7501!)
        Me.XrLabelAddress.Multiline = True
        Me.XrLabelAddress.Name = "XrLabelAddress"
        Me.XrLabelAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAddress.SizeF = New System.Drawing.SizeF(305.0!, 19.79203!)
        Me.XrLabelAddress.StylePriority.UseFont = False
        Me.XrLabelAddress.StylePriority.UseTextAlignment = False
        Me.XrLabelAddress.Text = "Address"
        Me.XrLabelAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelUserName})
        Me.ReportFooter.HeightF = 38.91633!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabelUserName
        '
        Me.XrLabelUserName.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelUserName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelUserName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelUserName.CanGrow = False
        Me.XrLabelUserName.Font = New DevExpress.Drawing.DXFont("Arial", 8.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelUserName.LocationFloat = New DevExpress.Utils.PointFloat(0.00006230672!, 4.457792!)
        Me.XrLabelUserName.Name = "XrLabelUserName"
        Me.XrLabelUserName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelUserName.SizeF = New System.Drawing.SizeF(305.0!, 24.45854!)
        Me.XrLabelUserName.StylePriority.UseBorders = False
        Me.XrLabelUserName.StylePriority.UseFont = False
        Me.XrLabelUserName.StylePriority.UseTextAlignment = False
        Me.XrLabelUserName.Text = "User:"
        Me.XrLabelUserName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1})
        Me.GroupHeader1.HeightF = 44.74996!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(11.7088!, 10.62501!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(280.2481!, 33.33344!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UsePadding = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "المبلغ"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelNote})
        Me.GroupFooter1.HeightF = 25.62574!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrLabelNote
        '
        Me.XrLabelNote.AutoWidth = True
        Me.XrLabelNote.LocationFloat = New DevExpress.Utils.PointFloat(0.0001869202!, 0!)
        Me.XrLabelNote.Multiline = True
        Me.XrLabelNote.Name = "XrLabelNote"
        Me.XrLabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelNote.SizeF = New System.Drawing.SizeF(304.9999!, 23.0!)
        Me.XrLabelNote.StylePriority.UseTextAlignment = False
        Me.XrLabelNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelBalance
        '
        Me.XrLabelBalance.AutoWidth = True
        Me.XrLabelBalance.LocationFloat = New DevExpress.Utils.PointFloat(35.41681!, 193.6244!)
        Me.XrLabelBalance.Multiline = True
        Me.XrLabelBalance.Name = "XrLabelBalance"
        Me.XrLabelBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelBalance.SizeF = New System.Drawing.SizeF(261.2915!, 14.25104!)
        Me.XrLabelBalance.StylePriority.UseTextAlignment = False
        Me.XrLabelBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportPosReceipt
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 6.0!, 2.0!, 14.0!)
        Me.PageWidth = 311
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.RollPaper = True
        Me.ShowPrintMarginsWarning = False
        Me.ShowPrintStatusDialog = False
        Me.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabelCompanyName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrLabelDocDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabelVoucherNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCustomer As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelVoucherName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelUserName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelBalance As DevExpress.XtraReports.UI.XRLabel
End Class
