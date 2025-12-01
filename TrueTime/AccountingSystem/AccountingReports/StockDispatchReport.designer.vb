<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class StockDispatchReport
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
        Me.components = New System.ComponentModel.Container()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column8 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression1 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Column9 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression2 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockDispatchReport))
        Dim Column10 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression8 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column11 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression9 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column12 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression10 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column13 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression11 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column14 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression12 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column15 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression13 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column16 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression14 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column17 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression15 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column18 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression16 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column19 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression17 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column20 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression18 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Column21 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression3 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Column22 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression19 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table3 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim QueryParameter1 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim QueryParameter2 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim QueryParameter3 As DevExpress.DataAccess.Sql.QueryParameter = New DevExpress.DataAccess.Sql.QueryParameter()
        Dim Join1 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo1 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Join2 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo2 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Sorting1 As DevExpress.DataAccess.Sql.Sorting = New DevExpress.DataAccess.Sql.Sorting()
        Dim ColumnExpression20 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellItemNo_ = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell33 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel36 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.DocOriginal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDocName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelVatNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.DocID = New DevExpress.XtraReports.Parameters.Parameter()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.ReportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel40 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCredit = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCreditName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDebitName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDebit = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel4 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLabelCurrency = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelSalesMan = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel38 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelCarNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabelDriver = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.AccountAddressLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.AccountMobileLabel = New DevExpress.XtraReports.UI.XRLabel()
        Me.AccountID = New DevExpress.XtraReports.Parameters.Parameter()
        Me.Account = New DevExpress.XtraReports.Parameters.Parameter()
        Me.CreditWhereHouse = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DebitWhereHouse = New DevExpress.XtraReports.Parameters.Parameter()
        Me.GroupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCellItemNo = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooterBand1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel29 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GroupCaption3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GroupData3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailCaption3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailData3_Odd = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DetailCaptionBackground3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.TotalCaption3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.TotalData3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.TotalBackground3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GrandTotalCaption3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GrandTotalData3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GrandTotalBackground3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DocType = New DevExpress.XtraReports.Parameters.Parameter()
        Me.Driver = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocSort = New DevExpress.XtraReports.Parameters.Parameter()
        Me.CarNo = New DevExpress.XtraReports.Parameters.Parameter()
        Me.SalesPerson = New DevExpress.XtraReports.Parameters.Parameter()
        Me.SalesPersonName = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocNotes = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DocName = New DevExpress.XtraReports.Parameters.Parameter()
        Me.BarcodePrint = New DevExpress.XtraReports.Parameters.Parameter()
        Me.CreditWhereHouseName = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DebitWahreHouseName = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable3
        '
        Me.XrTable3.BorderColor = System.Drawing.Color.Silver
        Me.XrTable3.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0.000002543129!, 0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.OddStyleName = "DetailData3_Odd"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(650.0001!, 25.0!)
        Me.XrTable3.StylePriority.UseBorderColor = False
        Me.XrTable3.StylePriority.UseBorders = False
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCellItemNo_, Me.XrTableCell38, Me.XrTableCell33, Me.XrTableCell29})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 11.5R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")})
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StyleName = "DetailData3"
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrTableCell4.Summary = XrSummary1
        Me.XrTableCell4.Text = "XrTableCell4"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell4.Weight = 0.017727025851214551R
        '
        'XrTableCellItemNo_
        '
        Me.XrTableCellItemNo_.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockID]")})
        Me.XrTableCellItemNo_.Name = "XrTableCellItemNo_"
        Me.XrTableCellItemNo_.StyleName = "DetailData3"
        Me.XrTableCellItemNo_.StylePriority.UseTextAlignment = False
        Me.XrTableCellItemNo_.Text = "XrTableCellItemNo_"
        Me.XrTableCellItemNo_.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCellItemNo_.Weight = 0.076200111138528356R
        Me.XrTableCellItemNo_.WordWrap = False
        '
        'XrTableCell38
        '
        Me.XrTableCell38.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ItemName]")})
        Me.XrTableCell38.Name = "XrTableCell38"
        Me.XrTableCell38.StyleName = "DetailData3"
        Me.XrTableCell38.StylePriority.UseTextAlignment = False
        Me.XrTableCell38.Text = "XrTableCell38"
        Me.XrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell38.Weight = 0.086462584221908667R
        '
        'XrTableCell33
        '
        Me.XrTableCell33.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[UnitName]")})
        Me.XrTableCell33.Name = "XrTableCell33"
        Me.XrTableCell33.StyleName = "DetailData3"
        Me.XrTableCell33.StylePriority.UseTextAlignment = False
        Me.XrTableCell33.Text = "XrTableCell33"
        Me.XrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell33.Weight = 0.03277508689546R
        '
        'XrTableCell29
        '
        Me.XrTableCell29.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[StockQuantity]")})
        Me.XrTableCell29.Name = "XrTableCell29"
        Me.XrTableCell29.StyleName = "DetailData3"
        Me.XrTableCell29.StylePriority.UseTextAlignment = False
        Me.XrTableCell29.Text = "XrTableCell29"
        Me.XrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell29.TextFormatString = "{0:n1}"
        Me.XrTableCell29.Weight = 0.036584916249873985R
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel36, Me.XrLabel23, Me.XrLabel22, Me.XrLabel7, Me.XrLabel6, Me.XrLabel15, Me.XrLabel12, Me.DocOriginal, Me.XrLabel1, Me.XrLabelDocName, Me.XrLabelVatNo, Me.XrPictureBox1})
        Me.TopMargin.HeightF = 264.7917!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel36
        '
        Me.XrLabel36.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DocSort")})
        Me.XrLabel36.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel36.LocationFloat = New DevExpress.Utils.PointFloat(12.64026!, 211.0832!)
        Me.XrLabel36.Multiline = True
        Me.XrLabel36.Name = "XrLabel36"
        Me.XrLabel36.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel36.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel36.StylePriority.UseFont = False
        Me.XrLabel36.Text = "XrLabel36"
        Me.XrLabel36.Visible = False
        '
        'XrLabel23
        '
        Me.XrLabel23.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(0!, 158.5001!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel22
        '
        Me.XrLabel22.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(0!, 135.5!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 112.5!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(315.979!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New DevExpress.Drawing.DXFont("Times New Roman", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 89.49999!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(383.8957!, 23.00001!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel15
        '
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(488.6081!, 240.75!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(39.58337!, 23.0!)
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.Text = "التاريخ: "
        '
        'XrLabel12
        '
        Me.XrLabel12.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DocDate]")})
        Me.XrLabel12.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(528.1915!, 240.75!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(110.282!, 23.0!)
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "XrLabel12"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel12.TextFormatString = "{0:dd/MM/yyyy}"
        '
        'DocOriginal
        '
        Me.DocOriginal.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.DocOriginal.LocationFloat = New DevExpress.Utils.PointFloat(484.608!, 211.0832!)
        Me.DocOriginal.Name = "DocOriginal"
        Me.DocOriginal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.DocOriginal.SizeF = New System.Drawing.SizeF(155.392!, 29.25002!)
        Me.DocOriginal.StylePriority.UseFont = False
        Me.DocOriginal.StylePriority.UseTextAlignment = False
        Me.DocOriginal.Text = "نسخة"
        Me.DocOriginal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel1
        '
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DocID")})
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 240.75!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(152.453!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrLabel1.TextFormatString = "{0:""سند رقم ""#000000}"
        '
        'XrLabelDocName
        '
        Me.XrLabelDocName.Font = New DevExpress.Drawing.DXFont("Times New Roman", 14.25!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDocName.LocationFloat = New DevExpress.Utils.PointFloat(187.5682!, 211.0832!)
        Me.XrLabelDocName.Name = "XrLabelDocName"
        Me.XrLabelDocName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDocName.SizeF = New System.Drawing.SizeF(297.0399!, 29.24998!)
        Me.XrLabelDocName.StylePriority.UseFont = False
        Me.XrLabelDocName.StylePriority.UseTextAlignment = False
        Me.XrLabelDocName.Text = "مبيعات"
        Me.XrLabelDocName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelVatNo
        '
        Me.XrLabelVatNo.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelVatNo.LocationFloat = New DevExpress.Utils.PointFloat(187.5682!, 240.3332!)
        Me.XrLabelVatNo.Name = "XrLabelVatNo"
        Me.XrLabelVatNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelVatNo.SizeF = New System.Drawing.SizeF(297.0399!, 23.0!)
        Me.XrLabelVatNo.StylePriority.UseFont = False
        Me.XrLabelVatNo.StylePriority.UseTextAlignment = False
        Me.XrLabelVatNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(397.7748!, 89.49999!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(231.2612!, 115.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'DocID
        '
        Me.DocID.Description = "DocID"
        Me.DocID.Name = "DocID"
        Me.DocID.Type = GetType(Integer)
        Me.DocID.ValueInfo = "0"
        Me.DocID.Visible = False
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel25, Me.XrLabel24, Me.XrPageInfo2})
        Me.BottomMargin.HeightF = 41.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel25
        '
        Me.XrLabel25.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InputUser]")})
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(196.1172!, 10.0!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(130.1345!, 23.0!)
        Me.XrLabel25.Text = "XrLabel25"
        Me.XrLabel25.TextFormatString = "المستخدم{0}"
        '
        'XrLabel24
        '
        Me.XrLabel24.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InputDateTime]")})
        Me.XrLabel24.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(7.846436!, 10.0!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(188.2707!, 23.0!)
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.Text = "XrLabel24"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(541.3298!, 10.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(100.5168!, 23.0!)
        Me.XrPageInfo2.StyleName = "PageInfo"
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrPageInfo2.TextFormatString = "Page {0} of {1}"
        '
        'XrLabel31
        '
        Me.XrLabel31.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrLabel31.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(15.0!, 140.0!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(214.0417!, 16.0!)
        Me.XrLabel31.StyleName = "TotalCaption3"
        Me.XrLabel31.StylePriority.UseBorderDashStyle = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.Text = "توقيع المستلم:"
        '
        'XrLabel30
        '
        Me.XrLabel30.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(424.4318!, 140.0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(214.0417!, 16.0!)
        Me.XrLabel30.StyleName = "TotalCaption3"
        Me.XrLabel30.StylePriority.UseBorderDashStyle = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.Text = "توقيع الادارة:"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        ColumnExpression1.ColumnName = "DocID"
        Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""1523"" />"
        Table1.Name = "Journal"
        ColumnExpression1.Table = Table1
        Column1.Expression = ColumnExpression1
        ColumnExpression2.ColumnName = "DocDate"
        ColumnExpression2.Table = Table1
        Column2.Expression = ColumnExpression2
        ColumnExpression3.ColumnName = "DocName"
        ColumnExpression3.Table = Table1
        Column3.Expression = ColumnExpression3
        ColumnExpression4.ColumnName = "DebitAcc"
        ColumnExpression4.Table = Table1
        Column4.Expression = ColumnExpression4
        ColumnExpression5.ColumnName = "CredAcc"
        ColumnExpression5.Table = Table1
        Column5.Expression = ColumnExpression5
        ColumnExpression6.ColumnName = "AccountCurr"
        ColumnExpression6.Table = Table1
        Column6.Expression = ColumnExpression6
        ColumnExpression7.ColumnName = "DocCurrency"
        ColumnExpression7.Table = Table1
        Column7.Expression = ColumnExpression7
        Column8.Alias = "DocAmount"
        CustomExpression1.Expression = "[Journal.DocAmount]+ISNULL([Journal.VoucherDiscount],0)"
        Column8.Expression = CustomExpression1
        Column9.Alias = "StockID"
        CustomExpression2.Expression = resources.GetString("CustomExpression2.Expression")
        Column9.Expression = CustomExpression2
        ColumnExpression8.ColumnName = "StockUnit"
        ColumnExpression8.Table = Table1
        Column10.Expression = ColumnExpression8
        ColumnExpression9.ColumnName = "StockQuantity"
        ColumnExpression9.Table = Table1
        Column11.Expression = ColumnExpression9
        ColumnExpression10.ColumnName = "StockQuantityByMainUnit"
        ColumnExpression10.Table = Table1
        Column12.Expression = ColumnExpression10
        ColumnExpression11.ColumnName = "StockPrice"
        ColumnExpression11.Table = Table1
        Column13.Expression = ColumnExpression11
        ColumnExpression12.ColumnName = "StockItemPrice"
        ColumnExpression12.Table = Table1
        Column14.Expression = ColumnExpression12
        ColumnExpression13.ColumnName = "StockDebitWhereHouse"
        ColumnExpression13.Table = Table1
        Column15.Expression = ColumnExpression13
        ColumnExpression14.ColumnName = "StockCreditWhereHouse"
        ColumnExpression14.Table = Table1
        Column16.Expression = ColumnExpression14
        ColumnExpression15.ColumnName = "ItemName"
        ColumnExpression15.Table = Table1
        Column17.Expression = ColumnExpression15
        ColumnExpression16.ColumnName = "DocNotes"
        ColumnExpression16.Table = Table1
        Column18.Expression = ColumnExpression16
        Column19.Alias = "UnitName"
        ColumnExpression17.ColumnName = "name"
        Table2.MetaSerializable = "<Meta X=""185"" Y=""30"" Width=""125"" Height=""123"" />"
        Table2.Name = "Units"
        ColumnExpression17.Table = Table2
        Column19.Expression = ColumnExpression17
        ColumnExpression18.ColumnName = "StockDiscount"
        ColumnExpression18.Table = Table1
        Column20.Expression = ColumnExpression18
        Column21.Alias = "VoucherDiscount"
        CustomExpression3.Expression = "ISNULL([Journal.VoucherDiscount],0)"
        Column21.Expression = CustomExpression3
        ColumnExpression19.ColumnName = "ItemNo2"
        Table3.MetaSerializable = "<Meta X=""340"" Y=""30"" Width=""125"" Height=""683"" />"
        Table3.Name = "Items"
        ColumnExpression19.Table = Table3
        Column22.Expression = ColumnExpression19
        SelectQuery1.Columns.Add(Column1)
        SelectQuery1.Columns.Add(Column2)
        SelectQuery1.Columns.Add(Column3)
        SelectQuery1.Columns.Add(Column4)
        SelectQuery1.Columns.Add(Column5)
        SelectQuery1.Columns.Add(Column6)
        SelectQuery1.Columns.Add(Column7)
        SelectQuery1.Columns.Add(Column8)
        SelectQuery1.Columns.Add(Column9)
        SelectQuery1.Columns.Add(Column10)
        SelectQuery1.Columns.Add(Column11)
        SelectQuery1.Columns.Add(Column12)
        SelectQuery1.Columns.Add(Column13)
        SelectQuery1.Columns.Add(Column14)
        SelectQuery1.Columns.Add(Column15)
        SelectQuery1.Columns.Add(Column16)
        SelectQuery1.Columns.Add(Column17)
        SelectQuery1.Columns.Add(Column18)
        SelectQuery1.Columns.Add(Column19)
        SelectQuery1.Columns.Add(Column20)
        SelectQuery1.Columns.Add(Column21)
        SelectQuery1.Columns.Add(Column22)
        SelectQuery1.FilterString = "[Journal.DocID] = ?DocID And [Journal.DocName] = ?DocName And [Journal.StockID] <" &
    "> '0'"
        SelectQuery1.GroupFilterString = ""
        SelectQuery1.Name = "StockMove"
        QueryParameter1.Name = "DocID"
        QueryParameter1.Type = GetType(DevExpress.DataAccess.Expression)
        QueryParameter1.Value = New DevExpress.DataAccess.Expression("?DocID", GetType(Integer))
        QueryParameter2.Name = "DocName"
        QueryParameter2.Type = GetType(DevExpress.DataAccess.Expression)
        QueryParameter2.Value = New DevExpress.DataAccess.Expression("?DocName", GetType(Integer))
        QueryParameter3.Name = "BarCodePrint"
        QueryParameter3.Type = GetType(DevExpress.DataAccess.Expression)
        QueryParameter3.Value = New DevExpress.DataAccess.Expression("?BarcodePrint", GetType(String))
        SelectQuery1.Parameters.AddRange(New DevExpress.DataAccess.Sql.QueryParameter() {QueryParameter1, QueryParameter2, QueryParameter3})
        RelationColumnInfo1.NestedKeyColumn = "id"
        RelationColumnInfo1.ParentKeyColumn = "StockUnit"
        Join1.KeyColumns.Add(RelationColumnInfo1)
        Join1.Nested = Table2
        Join1.Parent = Table1
        RelationColumnInfo2.NestedKeyColumn = "ItemNo"
        RelationColumnInfo2.ParentKeyColumn = "StockID"
        Join2.KeyColumns.Add(RelationColumnInfo2)
        Join2.Nested = Table3
        Join2.Parent = Table1
        Join2.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        SelectQuery1.Relations.Add(Join1)
        SelectQuery1.Relations.Add(Join2)
        ColumnExpression20.ColumnName = "OrderID"
        ColumnExpression20.Table = Table1
        Sorting1.Expression = ColumnExpression20
        SelectQuery1.Sorting.Add(Sorting1)
        SelectQuery1.Tables.Add(Table1)
        SelectQuery1.Tables.Add(Table2)
        SelectQuery1.Tables.Add(Table3)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'ReportHeaderBand1
        '
        Me.ReportHeaderBand1.BorderColor = System.Drawing.Color.Silver
        Me.ReportHeaderBand1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.ReportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel40, Me.XrLabelCredit, Me.XrLabelCreditName, Me.XrLabel11, Me.XrLabelDebitName, Me.XrLabelDebit, Me.XrLabel10, Me.XrPanel4})
        Me.ReportHeaderBand1.HeightF = 147.5833!
        Me.ReportHeaderBand1.Name = "ReportHeaderBand1"
        Me.ReportHeaderBand1.StylePriority.UseBorderColor = False
        Me.ReportHeaderBand1.StylePriority.UseBorders = False
        '
        'XrLabel40
        '
        Me.XrLabel40.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel40.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel40.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SalesPerson")})
        Me.XrLabel40.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel40.LocationFloat = New DevExpress.Utils.PointFloat(253.9735!, 124.5833!)
        Me.XrLabel40.Multiline = True
        Me.XrLabel40.Name = "XrLabel40"
        Me.XrLabel40.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel40.SizeF = New System.Drawing.SizeF(50.17397!, 23.00001!)
        Me.XrLabel40.StylePriority.UseBorderColor = False
        Me.XrLabel40.StylePriority.UseBorders = False
        Me.XrLabel40.StylePriority.UseFont = False
        Me.XrLabel40.Text = "XrLabel40"
        Me.XrLabel40.Visible = False
        '
        'XrLabelCredit
        '
        Me.XrLabelCredit.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelCredit.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelCredit.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DebitWhereHouse")})
        Me.XrLabelCredit.LocationFloat = New DevExpress.Utils.PointFloat(337.3494!, 124.5833!)
        Me.XrLabelCredit.Name = "XrLabelCredit"
        Me.XrLabelCredit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCredit.SizeF = New System.Drawing.SizeF(34.79716!, 23.00001!)
        Me.XrLabelCredit.StylePriority.UseBorderColor = False
        Me.XrLabelCredit.StylePriority.UseBorders = False
        Me.XrLabelCredit.Text = "XrLabelCredit"
        Me.XrLabelCredit.Visible = False
        '
        'XrLabelCreditName
        '
        Me.XrLabelCreditName.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelCreditName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelCreditName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?DebitWahreHouseName")})
        Me.XrLabelCreditName.LocationFloat = New DevExpress.Utils.PointFloat(509.7539!, 124.5833!)
        Me.XrLabelCreditName.Name = "XrLabelCreditName"
        Me.XrLabelCreditName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCreditName.SizeF = New System.Drawing.SizeF(128.7196!, 23.00001!)
        Me.XrLabelCreditName.StylePriority.UseBorderColor = False
        Me.XrLabelCreditName.StylePriority.UseBorders = False
        Me.XrLabelCreditName.StylePriority.UseTextAlignment = False
        Me.XrLabelCreditName.Text = "XrLabelCreditName"
        Me.XrLabelCreditName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(444.1288!, 124.5833!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = "الى مستودع:"
        '
        'XrLabelDebitName
        '
        Me.XrLabelDebitName.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelDebitName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelDebitName.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?CreditWhereHouseName")})
        Me.XrLabelDebitName.LocationFloat = New DevExpress.Utils.PointFloat(78.26526!, 124.5833!)
        Me.XrLabelDebitName.Name = "XrLabelDebitName"
        Me.XrLabelDebitName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDebitName.SizeF = New System.Drawing.SizeF(163.6304!, 23.00001!)
        Me.XrLabelDebitName.StylePriority.UseBorderColor = False
        Me.XrLabelDebitName.StylePriority.UseBorders = False
        Me.XrLabelDebitName.StylePriority.UseTextAlignment = False
        Me.XrLabelDebitName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabelDebit
        '
        Me.XrLabelDebit.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelDebit.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelDebit.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CreditWhereHouse]")})
        Me.XrLabelDebit.LocationFloat = New DevExpress.Utils.PointFloat(304.1468!, 124.5833!)
        Me.XrLabelDebit.Name = "XrLabelDebit"
        Me.XrLabelDebit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDebit.SizeF = New System.Drawing.SizeF(33.20258!, 23.00002!)
        Me.XrLabelDebit.StylePriority.UseBorderColor = False
        Me.XrLabelDebit.StylePriority.UseBorders = False
        Me.XrLabelDebit.Text = "XrLabelDebit"
        Me.XrLabelDebit.Visible = False
        '
        'XrLabel10
        '
        Me.XrLabel10.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(12.64026!, 124.5833!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "من مستودع:"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPanel4
        '
        Me.XrPanel4.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelCurrency, Me.XrLabelSalesMan, Me.XrLabel39, Me.XrLabel38, Me.XrLabelCarNo, Me.XrLabelDriver, Me.XrLabel32, Me.XrLabel27, Me.XrLabel26, Me.XrLabel13, Me.AccountAddressLabel, Me.XrLabel16, Me.XrLabel14, Me.AccountMobileLabel})
        Me.XrPanel4.LocationFloat = New DevExpress.Utils.PointFloat(11.52649!, 10.00001!)
        Me.XrPanel4.Name = "XrPanel4"
        Me.XrPanel4.SizeF = New System.Drawing.SizeF(628.4735!, 114.5833!)
        '
        'XrLabelCurrency
        '
        Me.XrLabelCurrency.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelCurrency.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelCurrency.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelCurrency.LocationFloat = New DevExpress.Utils.PointFloat(526.947!, 7.916637!)
        Me.XrLabelCurrency.Multiline = True
        Me.XrLabelCurrency.Name = "XrLabelCurrency"
        Me.XrLabelCurrency.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCurrency.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabelCurrency.StylePriority.UseBorderColor = False
        Me.XrLabelCurrency.StylePriority.UseBorders = False
        Me.XrLabelCurrency.StylePriority.UseFont = False
        Me.XrLabelCurrency.StylePriority.UseTextAlignment = False
        Me.XrLabelCurrency.Text = "XrLabelCurrency"
        Me.XrLabelCurrency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabelCurrency.Visible = False
        '
        'XrLabelSalesMan
        '
        Me.XrLabelSalesMan.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelSalesMan.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelSalesMan.CanShrink = True
        Me.XrLabelSalesMan.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SalesPersonName")})
        Me.XrLabelSalesMan.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelSalesMan.LocationFloat = New DevExpress.Utils.PointFloat(506.2482!, 76.91669!)
        Me.XrLabelSalesMan.Multiline = True
        Me.XrLabelSalesMan.Name = "XrLabelSalesMan"
        Me.XrLabelSalesMan.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelSalesMan.SizeF = New System.Drawing.SizeF(105.9697!, 23.0!)
        Me.XrLabelSalesMan.StylePriority.UseBorderColor = False
        Me.XrLabelSalesMan.StylePriority.UseBorders = False
        Me.XrLabelSalesMan.StylePriority.UseFont = False
        Me.XrLabelSalesMan.Text = "XrLabelSalesMan"
        '
        'XrLabel39
        '
        Me.XrLabel39.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(428.9094!, 76.91669!)
        Me.XrLabel39.Name = "XrLabel39"
        Me.XrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel39.SizeF = New System.Drawing.SizeF(77.33882!, 23.0!)
        Me.XrLabel39.StylePriority.UseBorderColor = False
        Me.XrLabel39.StylePriority.UseBorders = False
        Me.XrLabel39.Text = "مندوب المبيعات:"
        '
        'XrLabel38
        '
        Me.XrLabel38.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel38.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel38.LocationFloat = New DevExpress.Utils.PointFloat(428.9094!, 53.91674!)
        Me.XrLabel38.Name = "XrLabel38"
        Me.XrLabel38.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel38.SizeF = New System.Drawing.SizeF(77.33882!, 23.0!)
        Me.XrLabel38.StylePriority.UseBorderColor = False
        Me.XrLabel38.StylePriority.UseBorders = False
        Me.XrLabel38.Text = "المركبة:"
        '
        'XrLabelCarNo
        '
        Me.XrLabelCarNo.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelCarNo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelCarNo.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?CarNo")})
        Me.XrLabelCarNo.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabelCarNo.LocationFloat = New DevExpress.Utils.PointFloat(506.2483!, 53.91674!)
        Me.XrLabelCarNo.Multiline = True
        Me.XrLabelCarNo.Name = "XrLabelCarNo"
        Me.XrLabelCarNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelCarNo.SizeF = New System.Drawing.SizeF(105.9696!, 23.0!)
        Me.XrLabelCarNo.StylePriority.UseBorderColor = False
        Me.XrLabelCarNo.StylePriority.UseBorders = False
        Me.XrLabelCarNo.StylePriority.UseFont = False
        Me.XrLabelCarNo.Text = "XrLabelCarNo"
        '
        'XrLabelDriver
        '
        Me.XrLabelDriver.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabelDriver.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabelDriver.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Driver")})
        Me.XrLabelDriver.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabelDriver.LocationFloat = New DevExpress.Utils.PointFloat(506.2483!, 30.91672!)
        Me.XrLabelDriver.Name = "XrLabelDriver"
        Me.XrLabelDriver.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabelDriver.SizeF = New System.Drawing.SizeF(105.9696!, 23.0!)
        Me.XrLabelDriver.StylePriority.UseBorderColor = False
        Me.XrLabelDriver.StylePriority.UseBorders = False
        Me.XrLabelDriver.StylePriority.UseFont = False
        Me.XrLabelDriver.Text = "XrLabelDriver"
        '
        'XrLabel32
        '
        Me.XrLabel32.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(428.9094!, 30.91672!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(77.33882!, 23.0!)
        Me.XrLabel32.StylePriority.UseBorderColor = False
        Me.XrLabel32.StylePriority.UseBorders = False
        Me.XrLabel32.Text = "السائق:"
        '
        'XrLabel27
        '
        Me.XrLabel27.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(13.19159!, 76.91669!)
        Me.XrLabel27.Name = "XrLabel27"
        Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel27.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel27.StylePriority.UseBorderColor = False
        Me.XrLabel27.StylePriority.UseBorders = False
        Me.XrLabel27.Text = "رقم الموبايل:"
        '
        'XrLabel26
        '
        Me.XrLabel26.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel26.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(13.19159!, 53.91667!)
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel26.StylePriority.UseBorderColor = False
        Me.XrLabel26.StylePriority.UseBorders = False
        Me.XrLabel26.Text = "العنوان:"
        '
        'XrLabel13
        '
        Me.XrLabel13.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(13.19141!, 7.916641!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(65.62506!, 23.0!)
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = "الحساب:"
        '
        'AccountAddressLabel
        '
        Me.AccountAddressLabel.BorderColor = System.Drawing.Color.Transparent
        Me.AccountAddressLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.AccountAddressLabel.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.AccountAddressLabel.LocationFloat = New DevExpress.Utils.PointFloat(78.81667!, 53.91668!)
        Me.AccountAddressLabel.Name = "AccountAddressLabel"
        Me.AccountAddressLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.AccountAddressLabel.SizeF = New System.Drawing.SizeF(330.7703!, 23.0!)
        Me.AccountAddressLabel.StylePriority.UseBorderColor = False
        Me.AccountAddressLabel.StylePriority.UseBorders = False
        Me.AccountAddressLabel.StylePriority.UseFont = False
        '
        'XrLabel16
        '
        Me.XrLabel16.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?AccountID")})
        Me.XrLabel16.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(78.8165!, 7.916637!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(97.22525!, 23.0!)
        Me.XrLabel16.StylePriority.UseBorderColor = False
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.Text = "XrLabel16"
        '
        'XrLabel14
        '
        Me.XrLabel14.BorderColor = System.Drawing.Color.Transparent
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?Account")})
        Me.XrLabel14.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(78.81645!, 30.91662!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(330.7704!, 23.00001!)
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.Text = "XrLabel14"
        '
        'AccountMobileLabel
        '
        Me.AccountMobileLabel.BorderColor = System.Drawing.Color.Transparent
        Me.AccountMobileLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.AccountMobileLabel.Font = New DevExpress.Drawing.DXFont("Times New Roman", 12.0!, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, New DevExpress.Drawing.DXFontAdditionalProperty() {New DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", CType(0, Byte))})
        Me.AccountMobileLabel.LocationFloat = New DevExpress.Utils.PointFloat(78.81647!, 76.91669!)
        Me.AccountMobileLabel.Name = "AccountMobileLabel"
        Me.AccountMobileLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.AccountMobileLabel.SizeF = New System.Drawing.SizeF(330.7704!, 23.0!)
        Me.AccountMobileLabel.StylePriority.UseBorderColor = False
        Me.AccountMobileLabel.StylePriority.UseBorders = False
        Me.AccountMobileLabel.StylePriority.UseFont = False
        '
        'AccountID
        '
        Me.AccountID.Description = "AccountID"
        Me.AccountID.Name = "AccountID"
        Me.AccountID.Visible = False
        '
        'Account
        '
        Me.Account.Description = "Account"
        Me.Account.Name = "Account"
        Me.Account.Visible = False
        '
        'CreditWhereHouse
        '
        Me.CreditWhereHouse.Description = "CreditWhereHouse"
        Me.CreditWhereHouse.Name = "CreditWhereHouse"
        Me.CreditWhereHouse.Visible = False
        '
        'DebitWhereHouse
        '
        Me.DebitWhereHouse.Description = "DebitWhereHouse"
        Me.DebitWhereHouse.Name = "DebitWhereHouse"
        Me.DebitWhereHouse.Visible = False
        '
        'GroupHeaderBand2
        '
        Me.GroupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1})
        Me.GroupHeaderBand2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail
        Me.GroupHeaderBand2.HeightF = 37.99998!
        Me.GroupHeaderBand2.Level = 2
        Me.GroupHeaderBand2.Name = "GroupHeaderBand2"
        Me.GroupHeaderBand2.RepeatEveryPage = True
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(650.0!, 37.99998!)
        Me.XrPanel1.StyleName = "DetailCaptionBackground3"
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'XrTable2
        '
        Me.XrTable2.BackColor = System.Drawing.Color.Silver
        Me.XrTable2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 9.999974!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(649.9999!, 28.0!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseBorders = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.XrTableCellItemNo, Me.XrTableCell19, Me.XrTableCell14, Me.XrTableCell10})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StyleName = "DetailCaption3"
        Me.XrTableCell3.StylePriority.UseBackColor = False
        Me.XrTableCell3.StylePriority.UseBorders = False
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "#"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell3.Weight = 0.017727025851214551R
        '
        'XrTableCellItemNo
        '
        Me.XrTableCellItemNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCellItemNo.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCellItemNo.Name = "XrTableCellItemNo"
        Me.XrTableCellItemNo.StyleName = "DetailCaption3"
        Me.XrTableCellItemNo.StylePriority.UseBackColor = False
        Me.XrTableCellItemNo.StylePriority.UseBorders = False
        Me.XrTableCellItemNo.StylePriority.UseTextAlignment = False
        Me.XrTableCellItemNo.Text = "رقم الصنف"
        Me.XrTableCellItemNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCellItemNo.Weight = 0.076200111138528356R
        Me.XrTableCellItemNo.WordWrap = False
        '
        'XrTableCell19
        '
        Me.XrTableCell19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.StyleName = "DetailCaption3"
        Me.XrTableCell19.StylePriority.UseBackColor = False
        Me.XrTableCell19.StylePriority.UseBorders = False
        Me.XrTableCell19.Text = "الصنف"
        Me.XrTableCell19.Weight = 0.086462607589532239R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.StyleName = "DetailCaption3"
        Me.XrTableCell14.StylePriority.UseBackColor = False
        Me.XrTableCell14.StylePriority.UseBorders = False
        Me.XrTableCell14.Text = "الوحدة"
        Me.XrTableCell14.Weight = 0.032775086895459993R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.XrTableCell10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.StyleName = "DetailCaption3"
        Me.XrTableCell10.StylePriority.UseBackColor = False
        Me.XrTableCell10.StylePriority.UseBorders = False
        Me.XrTableCell10.StylePriority.UseTextAlignment = False
        Me.XrTableCell10.Text = "الكمية"
        Me.XrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell10.Weight = 0.036584924039081847R
        '
        'GroupFooterBand1
        '
        Me.GroupFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2})
        Me.GroupFooterBand1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail
        Me.GroupFooterBand1.HeightF = 6.0!
        Me.GroupFooterBand1.Name = "GroupFooterBand1"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(650.0!, 2.08!)
        Me.XrLabel2.StyleName = "GroupCaption3"
        Me.XrLabel2.StylePriority.UseBorders = False
        '
        'GroupFooterBand2
        '
        Me.GroupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel30, Me.XrLabel31, Me.XrLabel35, Me.XrLabel34, Me.XrLabel29, Me.XrLabel28, Me.XrLabel5, Me.XrLabel42})
        Me.GroupFooterBand2.HeightF = 167.3155!
        Me.GroupFooterBand2.Level = 1
        Me.GroupFooterBand2.Name = "GroupFooterBand2"
        '
        'XrLabel35
        '
        Me.XrLabel35.CanGrow = False
        Me.XrLabel35.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([StockQuantity])")})
        Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(187.5682!, 0!)
        Me.XrLabel35.Name = "XrLabel35"
        Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel35.SizeF = New System.Drawing.SizeF(84.47157!, 16.0!)
        Me.XrLabel35.StyleName = "TotalData3"
        Me.XrLabel35.StylePriority.UseTextAlignment = False
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.XrLabel35.Summary = XrSummary2
        Me.XrLabel35.Text = "XrLabel4"
        Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel35.TextFormatString = "{0:n}"
        Me.XrLabel35.WordWrap = False
        '
        'XrLabel34
        '
        Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(12.40143!, 0!)
        Me.XrLabel34.Name = "XrLabel34"
        Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel34.SizeF = New System.Drawing.SizeF(175.1668!, 16.0!)
        Me.XrLabel34.StyleName = "TotalCaption3"
        Me.XrLabel34.Text = "عدد الأصناف:"
        '
        'XrLabel29
        '
        Me.XrLabel29.LocationFloat = New DevExpress.Utils.PointFloat(12.40161!, 15.99998!)
        Me.XrLabel29.Name = "XrLabel29"
        Me.XrLabel29.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel29.SizeF = New System.Drawing.SizeF(175.1666!, 16.0!)
        Me.XrLabel29.StyleName = "TotalCaption3"
        Me.XrLabel29.Text = "مجموع الكميات:"
        '
        'XrLabel28
        '
        Me.XrLabel28.CanGrow = False
        Me.XrLabel28.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([StockQuantity])")})
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(187.5682!, 15.99998!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(84.47157!, 16.0!)
        Me.XrLabel28.StyleName = "TotalData3"
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.XrLabel28.Summary = XrSummary3
        Me.XrLabel28.Text = "XrLabel4"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel28.TextFormatString = "{0:n}"
        Me.XrLabel28.WordWrap = False
        '
        'XrLabel5
        '
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(7.846422!, 66.80756!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(622.947!, 41.96669!)
        '
        'XrLabel42
        '
        Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(8.960205!, 43.80754!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.Text = "ملاحظات:"
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New DevExpress.Drawing.DXFont("Tahoma", 14.0!)
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.Title.Name = "Title"
        '
        'GroupCaption3
        '
        Me.GroupCaption3.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.GroupCaption3.BorderColor = System.Drawing.Color.White
        Me.GroupCaption3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.GroupCaption3.BorderWidth = 2.0!
        Me.GroupCaption3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.GroupCaption3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.GroupCaption3.Name = "GroupCaption3"
        Me.GroupCaption3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
        Me.GroupCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupData3
        '
        Me.GroupData3.BackColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.GroupData3.BorderColor = System.Drawing.Color.White
        Me.GroupData3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.GroupData3.BorderWidth = 2.0!
        Me.GroupData3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.GroupData3.ForeColor = System.Drawing.Color.White
        Me.GroupData3.Name = "GroupData3"
        Me.GroupData3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
        Me.GroupData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailCaption3
        '
        Me.DetailCaption3.BackColor = System.Drawing.Color.Transparent
        Me.DetailCaption3.BorderColor = System.Drawing.Color.Transparent
        Me.DetailCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DetailCaption3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.DetailCaption3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.DetailCaption3.Name = "DetailCaption3"
        Me.DetailCaption3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailData3
        '
        Me.DetailData3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!)
        Me.DetailData3.ForeColor = System.Drawing.Color.Black
        Me.DetailData3.Name = "DetailData3"
        Me.DetailData3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailData3_Odd
        '
        Me.DetailData3_Odd.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.DetailData3_Odd.BorderColor = System.Drawing.Color.Transparent
        Me.DetailData3_Odd.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DetailData3_Odd.BorderWidth = 1.0!
        Me.DetailData3_Odd.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!)
        Me.DetailData3_Odd.ForeColor = System.Drawing.Color.Black
        Me.DetailData3_Odd.Name = "DetailData3_Odd"
        Me.DetailData3_Odd.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 6, 0, 0, 100.0!)
        Me.DetailData3_Odd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'DetailCaptionBackground3
        '
        Me.DetailCaptionBackground3.BackColor = System.Drawing.Color.Transparent
        Me.DetailCaptionBackground3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.DetailCaptionBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.DetailCaptionBackground3.BorderWidth = 2.0!
        Me.DetailCaptionBackground3.Name = "DetailCaptionBackground3"
        '
        'TotalCaption3
        '
        Me.TotalCaption3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.TotalCaption3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.TotalCaption3.Name = "TotalCaption3"
        Me.TotalCaption3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
        Me.TotalCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'TotalData3
        '
        Me.TotalData3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.TotalData3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TotalData3.Name = "TotalData3"
        Me.TotalData3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 6, 0, 0, 100.0!)
        Me.TotalData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'TotalBackground3
        '
        Me.TotalBackground3.Name = "TotalBackground3"
        '
        'GrandTotalCaption3
        '
        Me.GrandTotalCaption3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.GrandTotalCaption3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.GrandTotalCaption3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.GrandTotalCaption3.Name = "GrandTotalCaption3"
        Me.GrandTotalCaption3.Padding = New DevExpress.XtraPrinting.PaddingInfo(6, 2, 0, 0, 100.0!)
        Me.GrandTotalCaption3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GrandTotalData3
        '
        Me.GrandTotalData3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.GrandTotalData3.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.GrandTotalData3.ForeColor = System.Drawing.Color.White
        Me.GrandTotalData3.Name = "GrandTotalData3"
        Me.GrandTotalData3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 6, 0, 0, 100.0!)
        Me.GrandTotalData3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GrandTotalBackground3
        '
        Me.GrandTotalBackground3.BackColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.GrandTotalBackground3.BorderColor = System.Drawing.Color.White
        Me.GrandTotalBackground3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.GrandTotalBackground3.BorderWidth = 2.0!
        Me.GrandTotalBackground3.Name = "GrandTotalBackground3"
        '
        'PageInfo
        '
        Me.PageInfo.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.PageInfo.Name = "PageInfo"
        Me.PageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'DocType
        '
        Me.DocType.Description = "DocType"
        Me.DocType.Name = "DocType"
        Me.DocType.Visible = False
        '
        'Driver
        '
        Me.Driver.Description = "Driver"
        Me.Driver.Name = "Driver"
        Me.Driver.Visible = False
        '
        'DocSort
        '
        Me.DocSort.Description = "DocSort"
        Me.DocSort.Name = "DocSort"
        Me.DocSort.Visible = False
        '
        'CarNo
        '
        Me.CarNo.Description = "CarNo"
        Me.CarNo.Name = "CarNo"
        Me.CarNo.Visible = False
        '
        'SalesPerson
        '
        Me.SalesPerson.Description = "SalePerson"
        Me.SalesPerson.Name = "SalesPerson"
        Me.SalesPerson.Visible = False
        '
        'SalesPersonName
        '
        Me.SalesPersonName.Description = "SalesPersonName"
        Me.SalesPersonName.Name = "SalesPersonName"
        Me.SalesPersonName.Visible = False
        '
        'DocNotes
        '
        Me.DocNotes.AllowNull = True
        Me.DocNotes.Description = "DocNotes"
        Me.DocNotes.MultiValue = True
        Me.DocNotes.Name = "DocNotes"
        Me.DocNotes.Visible = False
        '
        'DocName
        '
        Me.DocName.Description = "DocName"
        Me.DocName.Name = "DocName"
        Me.DocName.Type = GetType(Integer)
        Me.DocName.ValueInfo = "0"
        Me.DocName.Visible = False
        '
        'BarcodePrint
        '
        Me.BarcodePrint.Description = "BarcodePrint"
        Me.BarcodePrint.Name = "BarcodePrint"
        Me.BarcodePrint.Type = GetType(Boolean)
        Me.BarcodePrint.ValueInfo = "False"
        Me.BarcodePrint.Visible = False
        '
        'CreditWhereHouseName
        '
        Me.CreditWhereHouseName.AllowNull = True
        Me.CreditWhereHouseName.Description = "CreditWhereHouseName"
        Me.CreditWhereHouseName.Name = "CreditWhereHouseName"
        Me.CreditWhereHouseName.Visible = False
        '
        'DebitWahreHouseName
        '
        Me.DebitWahreHouseName.AllowNull = True
        Me.DebitWahreHouseName.Description = "DebitWahreHouseName"
        Me.DebitWahreHouseName.Name = "DebitWahreHouseName"
        Me.DebitWahreHouseName.Visible = False
        '
        'StockDispatchReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeaderBand1, Me.GroupHeaderBand2, Me.GroupFooterBand1, Me.GroupFooterBand2})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.DataMember = "StockMove"
        Me.DataSource = Me.SqlDataSource1
        Me.Margins = New DevExpress.Drawing.DXMargins(100.0!, 100.0!, 264.7917!, 41.0!)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.DocID, Me.Account, Me.AccountID, Me.DebitWhereHouse, Me.CreditWhereHouse, Me.DocType, Me.Driver, Me.DocSort, Me.CarNo, Me.SalesPerson, Me.SalesPersonName, Me.DocNotes, Me.DocName, Me.BarcodePrint, Me.CreditWhereHouseName, Me.DebitWahreHouseName})
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.GroupCaption3, Me.GroupData3, Me.DetailCaption3, Me.DetailData3, Me.DetailData3_Odd, Me.DetailCaptionBackground3, Me.TotalCaption3, Me.TotalData3, Me.TotalBackground3, Me.GrandTotalCaption3, Me.GrandTotalData3, Me.GrandTotalBackground3, Me.PageInfo})
        Me.Version = "24.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellItemNo_ As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell33 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents ReportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents GroupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCellItemNo As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooterBand1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GroupCaption3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GroupData3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailCaption3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailData3_Odd As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DetailCaptionBackground3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents TotalCaption3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents TotalData3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents TotalBackground3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GrandTotalCaption3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GrandTotalData3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GrandTotalBackground3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrLabelDocName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DocID As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Account As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents AccountID As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocOriginal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelVatNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents AccountMobileLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel4 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents AccountAddressLabel As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DebitWhereHouse As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents CreditWhereHouse As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DocType As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel29 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDriver As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Driver As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DocSort As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel36 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel38 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCarNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents CarNo As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents SalesPerson As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel40 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelSalesMan As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents SalesPersonName As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocNotes As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DocName As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabelDebitName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCredit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelDebit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabelCreditName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BarcodePrint As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents CreditWhereHouseName As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DebitWahreHouseName As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabelCurrency As DevExpress.XtraReports.UI.XRLabel
End Class
