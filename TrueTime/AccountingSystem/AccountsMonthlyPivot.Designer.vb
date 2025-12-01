<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AccountsMonthlyPivot
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataSourceColumnBinding1 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
        Dim DataSourceColumnBinding2 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
        Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
        Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
        Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression1 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression2 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression3 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
        Dim CustomExpression4 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
        Dim Join1 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo1 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Join2 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo2 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table3 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Join3 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo3 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table4 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Join4 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo4 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table5 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Join5 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo5 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table6 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim Join6 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
        Dim RelationColumnInfo6 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
        Dim Table7 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsMonthlyPivot))
        Dim DataSourceColumnBinding3 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
        Dim DataSourceColumnBinding4 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
        Dim DataSourceColumnBinding5 As DevExpress.XtraPivotGrid.DataSourceColumnBinding = New DevExpress.XtraPivotGrid.DataSourceColumnBinding()
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim ChartIntervalItem1 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Dim ChartIntervalItem2 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Dim ChartIntervalItem3 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Dim ChartIntervalItem4 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Dim ChartIntervalItem5 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Dim ChartIntervalItem6 As DevExpress.XtraCharts.ChartIntervalItem = New DevExpress.XtraCharts.ChartIntervalItem()
        Me.fieldStatmentName = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldSectorName = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.fieldTransDate = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldAmount = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldAccountName = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutChart = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.SelectSeriesRepositoryItemComboBox1 = New DevExpress.XtraCharts.UI.SelectSeriesRepositoryItemComboBox()
        Me.ChangeSeriesViewRepositoryItemComboBox1 = New DevExpress.XtraCharts.UI.ChangeSeriesViewRepositoryItemComboBox()
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1 = New DevExpress.XtraCharts.UI.SelectAxisMeasureUnitRepositoryItemComboBox()
        Me.SelectPeriodRepositoryItemComboBox1 = New DevExpress.XtraCharts.UI.SelectPeriodRepositoryItemComboBox()
        Me.CommandBarGalleryDropDown1 = New DevExpress.XtraBars.Commands.CommandBarGalleryDropDown(Me.components)
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectSeriesRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChangeSeriesViewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectAxisMeasureUnitRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectPeriodRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandBarGalleryDropDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fieldStatmentName
        '
        Me.fieldStatmentName.AreaIndex = 0
        Me.fieldStatmentName.Caption = "القائمة المالية"
        DataSourceColumnBinding1.ColumnName = "StatmentName"
        Me.fieldStatmentName.DataBinding = DataSourceColumnBinding1
        Me.fieldStatmentName.MinWidth = 23
        Me.fieldStatmentName.Name = "fieldStatmentName"
        Me.fieldStatmentName.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None
        Me.fieldStatmentName.Width = 117
        '
        'fieldSectorName
        '
        Me.fieldSectorName.AreaIndex = 1
        Me.fieldSectorName.Caption = "البند"
        DataSourceColumnBinding2.ColumnName = "SectorName"
        Me.fieldSectorName.DataBinding = DataSourceColumnBinding2
        Me.fieldSectorName.MinWidth = 23
        Me.fieldSectorName.Name = "fieldSectorName"
        Me.fieldSectorName.Width = 117
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Column1.Alias = "TransDate"
        ColumnExpression1.ColumnName = "DocDate"
        Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""1483"" />"
        Table1.Name = "Journal"
        ColumnExpression1.Table = Table1
        Column1.Expression = ColumnExpression1
        Column2.Alias = "Amount"
        CustomExpression1.Expression = "IIF([Journal.DebitAcc]='0', [Journal.BaseCurrAmount], [Journal.BaseCurrAmount])"
        Column2.Expression = CustomExpression1
        Column3.Alias = "AccountName"
        CustomExpression2.Expression = "IIF([Journal.DebitAcc]='0',[FinancialAccounts_1.AccName] , [FinancialAccounts.Acc" &
    "Name])"
        Column3.Expression = CustomExpression2
        Column4.Alias = "SectorName"
        CustomExpression3.Expression = "IIF([Journal.DebitAcc]='0',[FinancialParts_1.SectorName],[FinancialParts.SectorNa" &
    "me] )"
        Column4.Expression = CustomExpression3
        Column5.Alias = "StatmentName"
        CustomExpression4.Expression = "IIF([Journal.DebitAcc]='0', [FinancialStatementNames_1.FinancialStatementName],[F" &
    "inancialStatementNames.FinancialStatementName] )"
        Column5.Expression = CustomExpression4
        SelectQuery1.Columns.Add(Column1)
        SelectQuery1.Columns.Add(Column2)
        SelectQuery1.Columns.Add(Column3)
        SelectQuery1.Columns.Add(Column4)
        SelectQuery1.Columns.Add(Column5)
        SelectQuery1.FilterString = "[Journal.DocStatus] > 0"
        SelectQuery1.GroupFilterString = ""
        SelectQuery1.Name = "Query"
        RelationColumnInfo1.NestedKeyColumn = "AccNo"
        RelationColumnInfo1.ParentKeyColumn = "DebitAcc"
        Join1.KeyColumns.Add(RelationColumnInfo1)
        Table2.MetaSerializable = "<Meta X=""185"" Y=""30"" Width=""125"" Height=""263"" />"
        Table2.Name = "FinancialAccounts"
        Join1.Nested = Table2
        Join1.Parent = Table1
        Join1.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        RelationColumnInfo2.NestedKeyColumn = "AccNo"
        RelationColumnInfo2.ParentKeyColumn = "CredAcc"
        Join2.KeyColumns.Add(RelationColumnInfo2)
        Table3.Alias = "FinancialAccounts_1"
        Table3.MetaSerializable = "<Meta X=""340"" Y=""30"" Width=""125"" Height=""263"" />"
        Table3.Name = "FinancialAccounts"
        Join2.Nested = Table3
        Join2.Parent = Table1
        Join2.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        RelationColumnInfo3.NestedKeyColumn = "SectorID"
        RelationColumnInfo3.ParentKeyColumn = "FinancialSector"
        Join3.KeyColumns.Add(RelationColumnInfo3)
        Table4.MetaSerializable = "<Meta X=""495"" Y=""30"" Width=""125"" Height=""123"" />"
        Table4.Name = "FinancialParts"
        Join3.Nested = Table4
        Join3.Parent = Table2
        Join3.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        RelationColumnInfo4.NestedKeyColumn = "SectorID"
        RelationColumnInfo4.ParentKeyColumn = "FinancialSector"
        Join4.KeyColumns.Add(RelationColumnInfo4)
        Table5.Alias = "FinancialParts_1"
        Table5.MetaSerializable = "<Meta X=""650"" Y=""30"" Width=""125"" Height=""123"" />"
        Table5.Name = "FinancialParts"
        Join4.Nested = Table5
        Join4.Parent = Table3
        Join4.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        RelationColumnInfo5.NestedKeyColumn = "ID"
        RelationColumnInfo5.ParentKeyColumn = "FinancialStatmentID"
        Join5.KeyColumns.Add(RelationColumnInfo5)
        Table6.MetaSerializable = "<Meta X=""960"" Y=""150"" Width=""125"" Height=""103"" />"
        Table6.Name = "FinancialStatementNames"
        Join5.Nested = Table6
        Join5.Parent = Table4
        Join5.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        RelationColumnInfo6.NestedKeyColumn = "ID"
        RelationColumnInfo6.ParentKeyColumn = "FinancialStatmentID"
        Join6.KeyColumns.Add(RelationColumnInfo6)
        Table7.Alias = "FinancialStatementNames_1"
        Table7.MetaSerializable = "<Meta X=""960"" Y=""30"" Width=""125"" Height=""103"" />"
        Table7.Name = "FinancialStatementNames"
        Join6.Nested = Table7
        Join6.Parent = Table5
        Join6.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
        SelectQuery1.Relations.Add(Join1)
        SelectQuery1.Relations.Add(Join2)
        SelectQuery1.Relations.Add(Join3)
        SelectQuery1.Relations.Add(Join4)
        SelectQuery1.Relations.Add(Join5)
        SelectQuery1.Relations.Add(Join6)
        SelectQuery1.Tables.Add(Table1)
        SelectQuery1.Tables.Add(Table2)
        SelectQuery1.Tables.Add(Table3)
        SelectQuery1.Tables.Add(Table4)
        SelectQuery1.Tables.Add(Table5)
        SelectQuery1.Tables.Add(Table6)
        SelectQuery1.Tables.Add(Table7)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PivotGridControl1.Appearance.GrandTotalCell.Options.UseBackColor = True
        Me.PivotGridControl1.Appearance.TotalCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PivotGridControl1.Appearance.TotalCell.Options.UseBackColor = True
        Me.PivotGridControl1.DataMember = "Query"
        Me.PivotGridControl1.DataSource = Me.SqlDataSource1
        Me.PivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldTransDate, Me.fieldAmount, Me.fieldAccountName, Me.fieldSectorName, Me.fieldStatmentName})
        Me.PivotGridControl1.Location = New System.Drawing.Point(12, 12)
        Me.PivotGridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.OptionsBehavior.CopyToClipboardWithFieldValues = True
        Me.PivotGridControl1.OptionsChartDataSource.ProvideColumnTotals = True
        Me.PivotGridControl1.OptionsCustomization.CustomizationFormStyle = DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle.Excel2007
        Me.PivotGridControl1.OptionsData.AutoExpandGroups = DevExpress.Utils.DefaultBoolean.[True]
        Me.PivotGridControl1.OptionsData.DataProcessingEngine = DevExpress.XtraPivotGrid.PivotDataProcessingEngine.Optimized
        Me.PivotGridControl1.OptionsDataField.RowHeaderWidth = 117
        Me.PivotGridControl1.OptionsMenu.EnableFormatRulesMenu = True
        Me.PivotGridControl1.OptionsView.RowTreeOffset = 24
        Me.PivotGridControl1.OptionsView.RowTreeWidth = 117
        Me.PivotGridControl1.Size = New System.Drawing.Size(823, 667)
        Me.PivotGridControl1.TabIndex = 0
        '
        'fieldTransDate
        '
        Me.fieldTransDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldTransDate.AreaIndex = 0
        Me.fieldTransDate.Caption = "التاريخ"
        DataSourceColumnBinding3.ColumnName = "TransDate"
        DataSourceColumnBinding3.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonthYear
        Me.fieldTransDate.DataBinding = DataSourceColumnBinding3
        Me.fieldTransDate.MinWidth = 23
        Me.fieldTransDate.Name = "fieldTransDate"
        Me.fieldTransDate.Width = 117
        '
        'fieldAmount
        '
        Me.fieldAmount.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldAmount.AreaIndex = 0
        Me.fieldAmount.Caption = "المبلغ"
        Me.fieldAmount.CellFormat.FormatString = "n0"
        Me.fieldAmount.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        DataSourceColumnBinding4.ColumnName = "Amount"
        Me.fieldAmount.DataBinding = DataSourceColumnBinding4
        Me.fieldAmount.EmptyCellText = "0"
        Me.fieldAmount.EmptyValueText = "0"
        Me.fieldAmount.GrandTotalCellFormat.FormatString = "n0"
        Me.fieldAmount.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldAmount.MinWidth = 23
        Me.fieldAmount.Name = "fieldAmount"
        Me.fieldAmount.ToolTips.ValueFormat.FormatString = "n0"
        Me.fieldAmount.ToolTips.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldAmount.TotalCellFormat.FormatString = "n0"
        Me.fieldAmount.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldAmount.TotalValueFormat.FormatString = "n0"
        Me.fieldAmount.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldAmount.ValueFormat.FormatString = "n0"
        Me.fieldAmount.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.fieldAmount.Width = 175
        '
        'fieldAccountName
        '
        Me.fieldAccountName.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldAccountName.AreaIndex = 0
        Me.fieldAccountName.Caption = "الحساب"
        DataSourceColumnBinding5.ColumnName = "AccountName"
        Me.fieldAccountName.DataBinding = DataSourceColumnBinding5
        Me.fieldAccountName.MinWidth = 100
        Me.fieldAccountName.Name = "fieldAccountName"
        Me.fieldAccountName.Width = 233
        '
        'ChartControl1
        '
        Me.ChartControl1.CrosshairOptions.ShowArgumentLabels = True
        Me.ChartControl1.CrosshairOptions.ShowValueLabels = True
        Me.ChartControl1.DataSource = Me.PivotGridControl1
        XyDiagram1.AxisX.Title.Text = "الحساب"
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.Title.Text = "المبلغ"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Legend.MaxHorizontalPercentage = 30.0R
        Me.ChartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[True]
        Me.ChartControl1.Location = New System.Drawing.Point(14, 362)
        Me.ChartControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.SeriesDataMember = "Series"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.ChartControl1.SeriesTemplate.ArgumentDataMember = "Arguments"
        Me.ChartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Me.ChartControl1.SeriesTemplate.SeriesDataMember = "Series"
        Me.ChartControl1.SeriesTemplate.ValueDataMembersSerializable = "Values"
        Me.ChartControl1.Size = New System.Drawing.Size(819, 313)
        Me.ChartControl1.TabIndex = 1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ChartControl1)
        Me.LayoutControl1.Controls.Add(Me.PivotGridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutChart})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(847, 691)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutChart
        '
        Me.LayoutChart.Control = Me.ChartControl1
        Me.LayoutChart.Location = New System.Drawing.Point(0, 346)
        Me.LayoutChart.Name = "LayoutChart"
        Me.LayoutChart.Size = New System.Drawing.Size(823, 319)
        Me.LayoutChart.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutChart.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(847, 691)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PivotGridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(827, 671)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 25
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SelectSeriesRepositoryItemComboBox1, Me.ChangeSeriesViewRepositoryItemComboBox1, Me.SelectAxisMeasureUnitRepositoryItemComboBox1, Me.SelectPeriodRepositoryItemComboBox1})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarSubItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "خيارات التقرير"
        Me.BarSubItem1.Id = 5
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.BarButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "عرض رسم بياني"
        Me.BarButtonItem1.Id = 6
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "تصدير الى اكسل"
        Me.BarButtonItem2.Id = 23
        Me.BarButtonItem2.ImageOptions.Image = CType(resources.GetObject("BarButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlTop.Size = New System.Drawing.Size(847, 24)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 715)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(847, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 24)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 691)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(847, 24)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 691)
        '
        'SelectSeriesRepositoryItemComboBox1
        '
        Me.SelectSeriesRepositoryItemComboBox1.AutoHeight = False
        Me.SelectSeriesRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SelectSeriesRepositoryItemComboBox1.Items.AddRange(New Object() {"Error"})
        Me.SelectSeriesRepositoryItemComboBox1.Name = "SelectSeriesRepositoryItemComboBox1"
        Me.SelectSeriesRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'ChangeSeriesViewRepositoryItemComboBox1
        '
        Me.ChangeSeriesViewRepositoryItemComboBox1.AutoHeight = False
        Me.ChangeSeriesViewRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ChangeSeriesViewRepositoryItemComboBox1.Items.AddRange(New Object() {DevExpress.XtraCharts.ViewType.Stock, DevExpress.XtraCharts.ViewType.CandleStick, DevExpress.XtraCharts.ViewType.Area, DevExpress.XtraCharts.ViewType.Line, DevExpress.XtraCharts.ViewType.Bar})
        Me.ChangeSeriesViewRepositoryItemComboBox1.Name = "ChangeSeriesViewRepositoryItemComboBox1"
        Me.ChangeSeriesViewRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'SelectAxisMeasureUnitRepositoryItemComboBox1
        '
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1.AutoHeight = False
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        ChartIntervalItem1.Caption = "1 day"
        ChartIntervalItem1.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Day
        ChartIntervalItem2.Caption = "1 week"
        ChartIntervalItem2.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Week
        ChartIntervalItem3.Caption = "1 month"
        ChartIntervalItem3.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1.Items.AddRange(New Object() {ChartIntervalItem1, ChartIntervalItem2, ChartIntervalItem3})
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1.Name = "SelectAxisMeasureUnitRepositoryItemComboBox1"
        Me.SelectAxisMeasureUnitRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'SelectPeriodRepositoryItemComboBox1
        '
        Me.SelectPeriodRepositoryItemComboBox1.AutoHeight = False
        Me.SelectPeriodRepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        ChartIntervalItem4.Caption = "6 month"
        ChartIntervalItem4.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
        ChartIntervalItem4.MeasureUnitMultiplier = 6
        ChartIntervalItem5.Caption = "1 year"
        ChartIntervalItem5.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year
        ChartIntervalItem6.Caption = "2 years"
        ChartIntervalItem6.MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year
        ChartIntervalItem6.MeasureUnitMultiplier = 2
        Me.SelectPeriodRepositoryItemComboBox1.Items.AddRange(New Object() {ChartIntervalItem4, ChartIntervalItem5, ChartIntervalItem6})
        Me.SelectPeriodRepositoryItemComboBox1.Name = "SelectPeriodRepositoryItemComboBox1"
        Me.SelectPeriodRepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'CommandBarGalleryDropDown1
        '
        Me.CommandBarGalleryDropDown1.Manager = Me.BarManager1
        Me.CommandBarGalleryDropDown1.Name = "CommandBarGalleryDropDown1"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "طباعة"
        Me.BarButtonItem3.Id = 24
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        Me.BarButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'AccountsMonthlyPivot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 715)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "AccountsMonthlyPivot"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "الحركات الشهرية للحسابات"
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectSeriesRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChangeSeriesViewRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectAxisMeasureUnitRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectPeriodRepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandBarGalleryDropDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents fieldTransDate As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldAmount As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldAccountName As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldSectorName As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldStatmentName As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutChart As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SelectSeriesRepositoryItemComboBox1 As DevExpress.XtraCharts.UI.SelectSeriesRepositoryItemComboBox
    Friend WithEvents ChangeSeriesViewRepositoryItemComboBox1 As DevExpress.XtraCharts.UI.ChangeSeriesViewRepositoryItemComboBox
    Friend WithEvents SelectAxisMeasureUnitRepositoryItemComboBox1 As DevExpress.XtraCharts.UI.SelectAxisMeasureUnitRepositoryItemComboBox
    Friend WithEvents SelectPeriodRepositoryItemComboBox1 As DevExpress.XtraCharts.UI.SelectPeriodRepositoryItemComboBox
    Friend WithEvents CommandBarGalleryDropDown1 As DevExpress.XtraBars.Commands.CommandBarGalleryDropDown
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
End Class
