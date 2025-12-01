<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DebitCreditNotesReport
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabelnputDateTime = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelInputUser = New DevExpress.XtraReports.UI.XRLabel()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAccountNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAccountName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRefNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelRefName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelNotes = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDocName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DocOriginal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabeldate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DocID = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocSort = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocName = New DevExpress.XtraReports.Parameters.Parameter()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 68.75!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrLabelnputDateTime, Me.XrLabelInputUser})
        Me.BottomMargin.HeightF = 90.625!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(541.3298!, 56.00001!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(100.5168!, 23.0!)
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrPageInfo2.TextFormatString = "Page {0} of {1}"
        '
        'XrLabelnputDateTime
        '
        Me.XrLabelnputDateTime.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelnputDateTime.LocationFloat = New DevExpress.Utils.PointFloat(7.846436!, 10.0!)
        Me.XrLabelnputDateTime.Name = "XrLabelnputDateTime"
        Me.XrLabelnputDateTime.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelnputDateTime.SizeF = New System.Drawing.SizeF(188.2707!, 23.0!)
        Me.XrLabelnputDateTime.StylePriority.UseFont = False
        '
        'XrLabelInputUser
        '
        Me.XrLabelInputUser.LocationFloat = New DevExpress.Utils.PointFloat(196.1172!, 10.0!)
        Me.XrLabelInputUser.Name = "XrLabelInputUser"
        Me.XrLabelInputUser.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelInputUser.SizeF = New System.Drawing.SizeF(130.1345!, 23.0!)
        Me.XrLabelInputUser.TextFormatString = "المستخدم{0}"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine4, Me.XrLabelAmount, Me.XrLabel3, Me.XrLine3, Me.XrLine1, Me.XrLabel2, Me.XrLabelAccountNo, Me.XrLabelAccountName, Me.XrLabel13, Me.XrLabelRefNo, Me.XrLabelRefName, Me.XrLabel42, Me.XrLabelNotes})
        Me.Detail.HeightF = 571.875!
        Me.Detail.Name = "Detail"
        '
        'XrLine3
        '
        Me.XrLine3.LineStyle = DevExpress.Drawing.DXDashStyle.Dot
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(15.5265!, 299.9167!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(624.4733!, 11.45834!)
        '
        'XrLine1
        '
        Me.XrLine1.LineStyle = DevExpress.Drawing.DXDashStyle.Dot
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(11.52651!, 81.00001!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(628.4734!, 11.45833!)
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(13.19128!, 129.9583!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "الحساب:"
        '
        'XrLabelAccountNo
        '
        Me.XrLabelAccountNo.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccountNo.LocationFloat = New DevExpress.Utils.PointFloat(78.81635!, 129.9583!)
        Me.XrLabelAccountNo.Name = "XrLabelAccountNo"
        Me.XrLabelAccountNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccountNo.SizeF = New System.Drawing.SizeF(120.8333!, 23.0!)
        Me.XrLabelAccountNo.StylePriority.UseFont = False
        Me.XrLabelAccountNo.Text = "XrLabel16"
        '
        'XrLabelAccountName
        '
        Me.XrLabelAccountName.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAccountName.LocationFloat = New DevExpress.Utils.PointFloat(78.81648!, 152.9584!)
        Me.XrLabelAccountName.Name = "XrLabelAccountName"
        Me.XrLabelAccountName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAccountName.SizeF = New System.Drawing.SizeF(330.7704!, 23.00001!)
        Me.XrLabelAccountName.StylePriority.UseFont = False
        Me.XrLabelAccountName.Text = "XrLabel14"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(13.19141!, 10.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = "الذمة"
        '
        'XrLabelRefNo
        '
        Me.XrLabelRefNo.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelRefNo.LocationFloat = New DevExpress.Utils.PointFloat(78.81647!, 10.0!)
        Me.XrLabelRefNo.Name = "XrLabelRefNo"
        Me.XrLabelRefNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRefNo.SizeF = New System.Drawing.SizeF(120.8333!, 23.0!)
        Me.XrLabelRefNo.StylePriority.UseFont = False
        Me.XrLabelRefNo.Text = "رقم الذمة"
        '
        'XrLabelRefName
        '
        Me.XrLabelRefName.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelRefName.LocationFloat = New DevExpress.Utils.PointFloat(78.81647!, 33.00002!)
        Me.XrLabelRefName.Name = "XrLabelRefName"
        Me.XrLabelRefName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelRefName.SizeF = New System.Drawing.SizeF(330.7704!, 23.00001!)
        Me.XrLabelRefName.StylePriority.UseFont = False
        Me.XrLabelRefName.Text = "XrLabelRefName"
        '
        'XrLabel42
        '
        Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(17.05286!, 367.8083!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.Text = "ملاحظات:"
        '
        'XrLabelNotes
        '
        Me.XrLabelNotes.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabelNotes.LocationFloat = New DevExpress.Utils.PointFloat(17.05301!, 390.8083!)
        Me.XrLabelNotes.Name = "XrLabelNotes"
        Me.XrLabelNotes.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelNotes.SizeF = New System.Drawing.SizeF(622.947!, 156.55!)
        Me.XrLabelNotes.StylePriority.UseBorders = False
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel17, Me.XrLabelDocName, Me.XrLine2, Me.XrLabel1, Me.DocOriginal, Me.XrLabeldate, Me.XrLabel15, Me.XrLabel6, Me.XrLabel7, Me.XrLabel22, Me.XrLabel23, Me.XrLabel36})
        Me.ReportHeader.HeightF = 246.875!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(488.6081!, 30.83334!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(140.4279!, 115.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel17
        '
        Me.XrLabel17.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(15.52649!, 122.8334!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelDocName
        '
        Me.XrLabelDocName.Font = New DevExpress.Drawing.DXFont("Times New Roman", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDocName.LocationFloat = New DevExpress.Utils.PointFloat(187.5682!, 163.875!)
        Me.XrLabelDocName.Name = "XrLabelDocName"
        Me.XrLabelDocName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDocName.SizeF = New System.Drawing.SizeF(297.0399!, 29.24998!)
        Me.XrLabelDocName.StylePriority.UseFont = False
        Me.XrLabelDocName.StylePriority.UseTextAlignment = False
        Me.XrLabelDocName.Text = "اشعار"
        Me.XrLabelDocName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(11.52649!, 193.125!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(628.4735!, 11.45833!)
        '
        'XrLabel1
        '
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DocID")})
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(11.52649!, 204.5833!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(215.1555!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel1.TextFormatString = "{0:""سند رقم ""#000000}"
        '
        'DocOriginal
        '
        Me.DocOriginal.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DocOriginal.LocationFloat = New DevExpress.Utils.PointFloat(484.608!, 163.875!)
        Me.DocOriginal.Name = "DocOriginal"
        Me.DocOriginal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DocOriginal.SizeF = New System.Drawing.SizeF(155.392!, 29.25002!)
        Me.DocOriginal.StylePriority.UseFont = False
        Me.DocOriginal.StylePriority.UseTextAlignment = False
        Me.DocOriginal.Text = "نسخة"
        Me.DocOriginal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabeldate
        '
        Me.XrLabeldate.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabeldate.LocationFloat = New DevExpress.Utils.PointFloat(529.718!, 205.0!)
        Me.XrLabeldate.Name = "XrLabeldate"
        Me.XrLabeldate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabeldate.SizeF = New System.Drawing.SizeF(110.282!, 23.0!)
        Me.XrLabeldate.StylePriority.UseFont = False
        Me.XrLabeldate.TextFormatString = "{0:dd/MM/yyyy}"
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(488.6081!, 205.0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(39.58337!, 23.0!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.Text = "التاريخ: "
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New DevExpress.Drawing.DXFont("Times New Roman", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(15.52641!, 30.83334!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(469.0817!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(15.52649!, 53.83334!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel22
        '
        Me.XrLabel22.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(15.52649!, 76.83334!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel23
        '
        Me.XrLabel23.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(15.52649!, 99.83336!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel36
        '
        Me.XrLabel36.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DocSort")})
        Me.XrLabel36.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(226.682!, 205.0!)
        Me.XrLabel36.Multiline = True
        Me.XrLabel36.Name = "XrLabel36"
        Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel36.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel36.StylePriority.UseFont = False
        Me.XrLabel36.Text = "XrLabel36"
        '
        'DocID
        '
        Me.DocID.Description = "DocID"
        Me.DocID.Name = "DocID"
        Me.DocID.Type = GetType(Integer)
        Me.DocID.ValueInfo = "0"
        Me.DocID.Visible = False
        '
        'DocSort
        '
        Me.DocSort.Description = "DocSort"
        Me.DocSort.Name = "DocSort"
        Me.DocSort.Visible = False
        '
        'DocDate
        '
        Me.DocDate.Description = "DocDate"
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Visible = False
        '
        'DocName
        '
        Me.DocName.Description = "DocName"
        Me.DocName.Name = "DocName"
        Me.DocName.Visible = False
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(13.19128!, 232.0416!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "المبلغ:"
        '
        'XrLabelAmount
        '
        Me.XrLabelAmount.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelAmount.LocationFloat = New DevExpress.Utils.PointFloat(78.81633!, 232.0416!)
        Me.XrLabelAmount.Name = "XrLabelAmount"
        Me.XrLabelAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelAmount.SizeF = New System.Drawing.SizeF(330.7704!, 23.00001!)
        Me.XrLabelAmount.StylePriority.UseFont = False
        Me.XrLabelAmount.Text = "0"
        '
        'XrLine4
        '
        Me.XrLine4.LineStyle = DevExpress.Drawing.DXDashStyle.Dot
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(13.19149!, 202.0!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(626.8083!, 11.45833!)
        '
        'DebitCreditNotesReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(100, 100, 69, 91)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.DocID, Me.DocSort, Me.DocDate, Me.DocName})
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "21.2"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDocName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DocOriginal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabeldate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelNotes As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccountNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelAccountName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRefNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelRefName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelnputDateTime As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelInputUser As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents DocID As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocSort As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocDate As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocName As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabelAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
End Class
