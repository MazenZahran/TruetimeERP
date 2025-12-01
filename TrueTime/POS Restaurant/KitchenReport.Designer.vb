<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class KitchenReport
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
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabelVoucherNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCustomer = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelVoucherName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelTableName = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabelUserName = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabelNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTableCellDocNoteByAccount = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BottomMargin.HeightF = 3.287156!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.Detail.BorderWidth = 0.2!
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XrTable1})
        Me.Detail.HeightF = 58.75069!
        Me.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount
        Me.Detail.Name = "Detail"
        Me.Detail.StylePriority.UseBorders = False
        Me.Detail.StylePriority.UseBorderWidth = False
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelVoucherNo, Me.XrLabelCustomer, Me.XrLabelVoucherName, Me.XrLabel5})
        Me.ReportHeader.HeightF = 82.70877!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseTextAlignment = False
        Me.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabelVoucherNo
        '
        Me.XrLabelVoucherNo.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelVoucherNo.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelVoucherNo.CanGrow = False
        Me.XrLabelVoucherNo.Font = New DevExpress.Drawing.DXFont("Arial", 11.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelVoucherNo.LocationFloat = New DevExpress.Utils.PointFloat(157.2073!, 33.8333!)
        Me.XrLabelVoucherNo.Name = "XrLabelVoucherNo"
        Me.XrLabelVoucherNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelVoucherNo.SizeF = New System.Drawing.SizeF(106.735!, 18.7926!)
        Me.XrLabelVoucherNo.StylePriority.UseFont = False
        Me.XrLabelVoucherNo.StylePriority.UseTextAlignment = False
        Me.XrLabelVoucherNo.Text = "Voucher No:"
        Me.XrLabelVoucherNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabelVoucherNo.TextFormatString = "No. {0}"
        '
        'XrLabelCustomer
        '
        Me.XrLabelCustomer.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelCustomer.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelCustomer.CanGrow = False
        Me.XrLabelCustomer.Font = New DevExpress.Drawing.DXFont("Arial Narrow", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelCustomer.LocationFloat = New DevExpress.Utils.PointFloat(8.292114!, 52.6259!)
        Me.XrLabelCustomer.Multiline = True
        Me.XrLabelCustomer.Name = "XrLabelCustomer"
        Me.XrLabelCustomer.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCustomer.SizeF = New System.Drawing.SizeF(255.6503!, 30.08287!)
        Me.XrLabelCustomer.StylePriority.UseFont = False
        Me.XrLabelCustomer.StylePriority.UseTextAlignment = False
        Me.XrLabelCustomer.Text = "الزبون:"
        Me.XrLabelCustomer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabelVoucherName
        '
        Me.XrLabelVoucherName.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabelVoucherName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelVoucherName.CanGrow = False
        Me.XrLabelVoucherName.Font = New DevExpress.Drawing.DXFont("Arial", 16.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelVoucherName.LocationFloat = New DevExpress.Utils.PointFloat(13.70883!, 10.00001!)
        Me.XrLabelVoucherName.Name = "XrLabelVoucherName"
        Me.XrLabelVoucherName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelVoucherName.SizeF = New System.Drawing.SizeF(250.2336!, 23.83329!)
        Me.XrLabelVoucherName.StylePriority.UseFont = False
        Me.XrLabelVoucherName.StylePriority.UseTextAlignment = False
        Me.XrLabelVoucherName.Text = "طلبية"
        Me.XrLabelVoucherName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabel5.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabel5.AutoWidth = True
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Now()")})
        Me.XrLabel5.Font = New DevExpress.Drawing.DXFont("Arial", 8.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(8.292114!, 33.8333!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(148.9152!, 18.79261!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "XrLabel5"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel5.TextFormatString = "{0:dd/MM/yyyy HH:mm:ss}"
        '
        'XrLabelTableName
        '
        Me.XrLabelTableName.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelTableName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelTableName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelTableName.CanGrow = False
        Me.XrLabelTableName.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelTableName.LocationFloat = New DevExpress.Utils.PointFloat(13.70883!, 0!)
        Me.XrLabelTableName.Name = "XrLabelTableName"
        Me.XrLabelTableName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelTableName.SizeF = New System.Drawing.SizeF(278.2481!, 27.4162!)
        Me.XrLabelTableName.StylePriority.UseBorders = False
        Me.XrLabelTableName.StylePriority.UseFont = False
        Me.XrLabelTableName.StylePriority.UseTextAlignment = False
        Me.XrLabelTableName.Text = "............"
        Me.XrLabelTableName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelUserName})
        Me.ReportFooter.HeightF = 18.75226!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabelUserName
        '
        Me.XrLabelUserName.AnchorHorizontal = CType((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left Or DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right), DevExpress.XtraReports.UI.HorizontalAnchorStyles)
        Me.XrLabelUserName.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.XrLabelUserName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelUserName.CanGrow = False
        Me.XrLabelUserName.Font = New DevExpress.Drawing.DXFont("Arial", 8.25!, DevExpress.Drawing.DXFontStyle.Regular, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelUserName.LocationFloat = New DevExpress.Utils.PointFloat(8.292116!, 0!)
        Me.XrLabelUserName.Name = "XrLabelUserName"
        Me.XrLabelUserName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelUserName.SizeF = New System.Drawing.SizeF(288.7079!, 18.75225!)
        Me.XrLabelUserName.StylePriority.UseBorders = False
        Me.XrLabelUserName.StylePriority.UseFont = False
        Me.XrLabelUserName.StylePriority.UseTextAlignment = False
        Me.XrLabelUserName.Text = "User:"
        Me.XrLabelUserName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelTableName, Me.XrTable2})
        Me.GroupHeader1.HeightF = 63.12386!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(13.70885!, 27.4162!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(278.2481!, 33.9584!)
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell6, Me.XrTableCell7})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 2.2257861834892054R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell6.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell6.CanGrow = False
        Me.XrTableCell6.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrTableCell6.Multiline = True
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell6.StylePriority.UseBackColor = False
        Me.XrTableCell6.StylePriority.UseBorders = False
        Me.XrTableCell6.StylePriority.UseFont = False
        Me.XrTableCell6.StylePriority.UsePadding = False
        Me.XrTableCell6.StylePriority.UseTextAlignment = False
        Me.XrTableCell6.Text = "الصنف"
        Me.XrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell6.Weight = 206.02629731477663R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell7.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTableCell7.CanGrow = False
        Me.XrTableCell7.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrTableCell7.Multiline = True
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrTableCell7.StylePriority.UseBackColor = False
        Me.XrTableCell7.StylePriority.UseBorders = False
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.StylePriority.UsePadding = False
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "الكمية"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell7.Weight = 72.221789518298365R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.GroupFooter1.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelNote})
        Me.GroupFooter1.HeightF = 23.16696!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.StylePriority.UseBorderDashStyle = False
        Me.GroupFooter1.StylePriority.UseBorders = False
        '
        'XrLabelNote
        '
        Me.XrLabelNote.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!)
        Me.XrLabelNote.LocationFloat = New DevExpress.Utils.PointFloat(13.70883!, 0!)
        Me.XrLabelNote.Multiline = True
        Me.XrLabelNote.Name = "XrLabelNote"
        Me.XrLabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelNote.SizeF = New System.Drawing.SizeF(278.2481!, 23.16686!)
        Me.XrLabelNote.StylePriority.UseFont = False
        Me.XrLabelNote.StylePriority.UseTextAlignment = False
        Me.XrLabelNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableCellDocNoteByAccount
        '
        Me.XrTableCellDocNoteByAccount.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.[Double]
        Me.XrTableCellDocNoteByAccount.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTableCellDocNoteByAccount.BorderWidth = 2.0!
        Me.XrTableCellDocNoteByAccount.CanShrink = True
        Me.XrTableCellDocNoteByAccount.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DocNoteByAccount]")})
        Me.XrTableCellDocNoteByAccount.Font = New DevExpress.Drawing.DXFont("Arial", 14.0!, DevExpress.Drawing.DXFontStyle.Underline)
        Me.XrTableCellDocNoteByAccount.Multiline = True
        Me.XrTableCellDocNoteByAccount.Name = "XrTableCellDocNoteByAccount"
        Me.XrTableCellDocNoteByAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100.0!)
        Me.XrTableCellDocNoteByAccount.StylePriority.UseBorderDashStyle = False
        Me.XrTableCellDocNoteByAccount.StylePriority.UseBorders = False
        Me.XrTableCellDocNoteByAccount.StylePriority.UseBorderWidth = False
        Me.XrTableCellDocNoteByAccount.StylePriority.UseFont = False
        Me.XrTableCellDocNoteByAccount.StylePriority.UsePadding = False
        Me.XrTableCellDocNoteByAccount.StylePriority.UseTextAlignment = False
        Me.XrTableCellDocNoteByAccount.Text = "..."
        Me.XrTableCellDocNoteByAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCellDocNoteByAccount.TextFormatString = "({0})"
        Me.XrTableCellDocNoteByAccount.Weight = 278.24807433186243R
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellDocNoteByAccount})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0454545454545454R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.BorderWidth = 0.2!
        Me.XrTableCell2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Quantity]")})
        Me.XrTableCell2.Font = New DevExpress.Drawing.DXFont("Arial", 16.0!)
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100.0!)
        Me.XrTableCell2.StylePriority.UseBorderWidth = False
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UsePadding = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "xrTableCell1"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell2.TextFormatString = "{0:n1}"
        Me.XrTableCell2.Weight = 72.221786760337636R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.BorderWidth = 0.2!
        Me.XrTableCell1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemName]")})
        Me.XrTableCell1.Font = New DevExpress.Drawing.DXFont("Arial", 16.0!)
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100.0!)
        Me.XrTableCell1.StylePriority.UseBorderWidth = False
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UsePadding = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "xrTableCell2"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrTableCell1.Weight = 206.02628757152476R
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0454545454545454R
        '
        'XrTable1
        '
        Me.XrTable1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(13.70883!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow3})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(278.2481!, 44.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrLine1
        '
        Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLine1.LineWidth = 2.0!
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(13.70883!, 43.99999!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(278.2481!, 12.99999!)
        Me.XrLine1.StylePriority.UseBorders = False
        '
        'KitchenReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.ReportFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.DesignerOptions.ShowExportWarnings = False
        Me.DesignerOptions.ShowPrintingWarnings = False
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(0!, 4.0!, 2.0!, 3.287156!)
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
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabelVoucherNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCustomer As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelVoucherName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelUserName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelTableName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCellDocNoteByAccount As DevExpress.XtraReports.UI.XRTableCell
End Class
