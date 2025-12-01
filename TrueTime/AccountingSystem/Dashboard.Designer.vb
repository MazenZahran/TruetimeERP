Namespace Win_Dashboards
    Partial Public Class Dashboard
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim DateTimePeriod1 As DevExpress.DashboardCommon.DateTimePeriod = New DevExpress.DashboardCommon.DateTimePeriod()
            Dim FlowDateTimePeriodLimit1 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim FlowDateTimePeriodLimit2 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim DateTimePeriod2 As DevExpress.DashboardCommon.DateTimePeriod = New DevExpress.DashboardCommon.DateTimePeriod()
            Dim FlowDateTimePeriodLimit3 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim FlowDateTimePeriodLimit4 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim DateTimePeriod3 As DevExpress.DashboardCommon.DateTimePeriod = New DevExpress.DashboardCommon.DateTimePeriod()
            Dim FlowDateTimePeriodLimit5 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim FlowDateTimePeriodLimit6 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim DateTimePeriod4 As DevExpress.DashboardCommon.DateTimePeriod = New DevExpress.DashboardCommon.DateTimePeriod()
            Dim FlowDateTimePeriodLimit7 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim FlowDateTimePeriodLimit8 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
            Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim CustomExpression1 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim CustomExpression2 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim CustomExpression3 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim CustomExpression4 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim CustomExpression5 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
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
            Dim Sorting1 As DevExpress.DataAccess.Sql.Sorting = New DevExpress.DataAccess.Sql.Sorting()
            Dim CustomExpression6 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim Sorting2 As DevExpress.DataAccess.Sql.Sorting = New DevExpress.DataAccess.Sql.Sorting()
            Dim CustomExpression7 As DevExpress.DataAccess.Sql.CustomExpression = New DevExpress.DataAccess.Sql.CustomExpression()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim CardWindowDefinition1 As DevExpress.DashboardCommon.CardWindowDefinition = New DevExpress.DashboardCommon.CardWindowDefinition()
            Dim Card1 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate1 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn1 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridWindowDefinition1 As DevExpress.DashboardCommon.GridWindowDefinition = New DevExpress.DashboardCommon.GridWindowDefinition()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartWindowDefinition1 As DevExpress.DashboardCommon.ChartWindowDefinition = New DevExpress.DashboardCommon.ChartWindowDefinition()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DateFilterDashboardItem1 = New DevExpress.DashboardCommon.DateFilterDashboardItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.CardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            Me.GridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DateFilterDashboardItem1
            '
            Me.DateFilterDashboardItem1.ComponentName = "DateFilterDashboardItem1"
            Dimension1.DataMember = "DocDate"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.DateFilterDashboardItem1.DataItemRepository.Clear()
            Me.DateFilterDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.DateFilterDashboardItem1.DataMember = "Journal"
            Me.DateFilterDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            FlowDateTimePeriodLimit1.Offset = 1
            DateTimePeriod1.End = FlowDateTimePeriodLimit1
            DateTimePeriod1.Name = "السنة الحالية"
            DateTimePeriod1.Start = FlowDateTimePeriodLimit2
            FlowDateTimePeriodLimit3.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit3.Offset = 1
            DateTimePeriod2.End = FlowDateTimePeriodLimit3
            DateTimePeriod2.Name = "الشهر الحالي"
            FlowDateTimePeriodLimit4.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod2.Start = FlowDateTimePeriodLimit4
            DateTimePeriod3.End = FlowDateTimePeriodLimit5
            DateTimePeriod3.Name = "السنة الماضية"
            FlowDateTimePeriodLimit6.Offset = -1
            DateTimePeriod3.Start = FlowDateTimePeriodLimit6
            FlowDateTimePeriodLimit7.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod4.End = FlowDateTimePeriodLimit7
            DateTimePeriod4.Name = "الشهر الماضي"
            FlowDateTimePeriodLimit8.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit8.Offset = -1
            DateTimePeriod4.Start = FlowDateTimePeriodLimit8
            Me.DateFilterDashboardItem1.DateTimePeriods.AddRange(New DevExpress.DashboardCommon.DateTimePeriod() {DateTimePeriod1, DateTimePeriod2, DateTimePeriod3, DateTimePeriod4})
            Me.DateFilterDashboardItem1.DefaultDateTimePeriodName = "السنة الحالية"
            Me.DateFilterDashboardItem1.Dimension = Dimension1
            Me.DateFilterDashboardItem1.Name = "خيارات الفترة"
            Me.DateFilterDashboardItem1.ShowCaption = True
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            ColumnExpression1.ColumnName = "DocDate"
            Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""1483"" />"
            Table1.Name = "Journal"
            ColumnExpression1.Table = Table1
            Column1.Expression = ColumnExpression1
            ColumnExpression2.ColumnName = "BaseCurrAmount"
            ColumnExpression2.Table = Table1
            Column2.Expression = ColumnExpression2
            Column3.Alias = "Account"
            CustomExpression1.Expression = "IIF([Journal.DebitAcc]='0', [Journal.CredAcc], [Journal.DebitAcc])"
            Column3.Expression = CustomExpression1
            Column4.Alias = "Amount"
            CustomExpression2.Expression = "IIF([Journal.DebitAcc]='0',[Journal.BaseCurrAmount] ,-1*[Journal.BaseCurrAmount] " &
    ")"
            Column4.Expression = CustomExpression2
            Column5.Alias = "AccountName"
            CustomExpression3.Expression = "IIF([Journal.DebitAcc]='0',[FinancialAccounts_1.AccName] , [FinancialAccounts.Acc" &
    "Name])"
            Column5.Expression = CustomExpression3
            Column6.Alias = "Sector"
            CustomExpression4.Expression = "IIF([Journal.DebitAcc]='0', [FinancialAccounts_1.FinancialSector],[FinancialAccou" &
    "nts.FinancialSector] )"
            Column6.Expression = CustomExpression4
            Column7.Alias = "SectorName"
            CustomExpression5.Expression = "IIF([Journal.DebitAcc]='0', [FinancialParts_1.SectorName], [FinancialParts.Sector" &
    "Name])"
            Column7.Expression = CustomExpression5
            SelectQuery1.Columns.Add(Column1)
            SelectQuery1.Columns.Add(Column2)
            SelectQuery1.Columns.Add(Column3)
            SelectQuery1.Columns.Add(Column4)
            SelectQuery1.Columns.Add(Column5)
            SelectQuery1.Columns.Add(Column6)
            SelectQuery1.Columns.Add(Column7)
            SelectQuery1.FilterString = "[Journal.DocStatus] > 0 And ([FinancialAccounts.FinancialStatment] = 2 Or [Financ" &
    "ialAccounts_1.FinancialStatment] = 2)"
            SelectQuery1.GroupFilterString = ""
            SelectQuery1.Name = "Journal"
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
            SelectQuery1.Relations.Add(Join1)
            SelectQuery1.Relations.Add(Join2)
            SelectQuery1.Relations.Add(Join3)
            SelectQuery1.Relations.Add(Join4)
            CustomExpression6.Expression = "IIF([Journal.DebitAcc]='0', [FinancialAccounts_1.FinancialSector],[FinancialAccou" &
    "nts.FinancialSector] )"
            Sorting1.Expression = CustomExpression6
            CustomExpression7.Expression = "IIF([Journal.DebitAcc]='0', [Journal.CredAcc], [Journal.DebitAcc])"
            Sorting2.Expression = CustomExpression7
            SelectQuery1.Sorting.Add(Sorting1)
            SelectQuery1.Sorting.Add(Sorting2)
            SelectQuery1.Tables.Add(Table1)
            SelectQuery1.Tables.Add(Table2)
            SelectQuery1.Tables.Add(Table3)
            SelectQuery1.Tables.Add(Table4)
            SelectQuery1.Tables.Add(Table5)
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'CardDashboardItem1
            '
            Measure1.DataMember = "Amount"
            Measure1.Expression = "Abs(Sum([Amount]))"
            Measure1.NumericFormat.CustomFormatString = ""
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure1.WindowDefinition = CardWindowDefinition1
            CardStretchedLayoutTemplate1.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate1.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate1.BottomValue1.Visible = True
            CardStretchedLayoutTemplate1.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate1.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate1.BottomValue2.Visible = True
            CardStretchedLayoutTemplate1.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate1.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate1.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate1.MainValue.Visible = True
            CardStretchedLayoutTemplate1.Sparkline.Visible = True
            CardStretchedLayoutTemplate1.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate1.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate1.SubValue.Visible = True
            CardStretchedLayoutTemplate1.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate1.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate1.TopValue.Visible = True
            Card1.LayoutTemplate = CardStretchedLayoutTemplate1
            Card1.SparklineOptions.ViewType = DevExpress.DashboardCommon.SparklineViewType.Area
            Card1.AddDataItem("ActualValue", Measure1)
            Me.CardDashboardItem1.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card1})
            Me.CardDashboardItem1.ComponentName = "CardDashboardItem1"
            Dimension2.DataMember = "SectorName"
            Dimension3.DataMember = "DocDate"
            Dimension3.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Dimension3.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            Me.CardDashboardItem1.DataItemRepository.Clear()
            Me.CardDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure1, "DataItem1")
            Me.CardDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem2")
            Me.CardDashboardItem1.DataMember = "Journal"
            Me.CardDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.CardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.CardDashboardItem1.InteractivityOptions.MasterFilterMode = DevExpress.DashboardCommon.DashboardItemMasterFilterMode.Multiple
            Me.CardDashboardItem1.IsMasterFilterCrossDataSource = True
            Me.CardDashboardItem1.Name = " "
            Me.CardDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.CardDashboardItem1.ShowCaption = False
            Me.CardDashboardItem1.SparklineArgument = Dimension3
            '
            'GridDashboardItem1
            '
            Dimension4.DataMember = "AccountName"
            GridDimensionColumn1.Name = "الحساب"
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension4)
            Measure2.DataMember = "Amount"
            Measure2.Expression = "Abs(Sum([Amount]))"
            Measure2.NumericFormat.CustomFormatString = ""
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Measure2.WindowDefinition = GridWindowDefinition1
            GridMeasureColumn1.Name = "المبلغ"
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure2)
            Me.GridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridMeasureColumn1})
            Me.GridDashboardItem1.ComponentName = "GridDashboardItem1"
            Dimension5.DataMember = "DocDate"
            Dimension5.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.GridDashboardItem1.DataItemRepository.Clear()
            Me.GridDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.GridDashboardItem1.DataItemRepository.Add(Measure2, "DataItem1")
            Me.GridDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem2")
            Me.GridDashboardItem1.DataMember = "Journal"
            Me.GridDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.GridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.GridDashboardItem1.Name = "Grid 1"
            Me.GridDashboardItem1.ShowCaption = False
            Me.GridDashboardItem1.SparklineArgument = Dimension5
            '
            'ChartDashboardItem1
            '
            Dimension6.DataMember = "DocDate"
            Dimension6.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension6})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure3.DataMember = "Amount"
            Measure3.Expression = "Abs(Sum([Amount]))"
            Measure3.WindowDefinition = ChartWindowDefinition1
            Dimension7.DataMember = "SectorName"
            Dimension7.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure3, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension6, "DataItem1")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension7, "DataItem3")
            Me.ChartDashboardItem1.DataMember = "Journal"
            Me.ChartDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "Chart 1"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.SeriesType = DevExpress.DashboardCommon.SimpleSeriesType.StackedBar
            SimpleSeries1.AddDataItem("Value", Measure3)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension7})
            Me.ChartDashboardItem1.ShowCaption = False
            '
            'Dashboard
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.CardDashboardItem1, Me.ChartDashboardItem1, Me.DateFilterDashboardItem1, Me.GridDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.DateFilterDashboardItem1
            DashboardLayoutItem1.Weight = 12.112259970457902R
            DashboardLayoutItem2.DashboardItem = Me.CardDashboardItem1
            DashboardLayoutItem2.Weight = 15.657311669128507R
            DashboardLayoutItem3.DashboardItem = Me.GridDashboardItem1
            DashboardLayoutItem3.Weight = 34.490566037735846R
            DashboardLayoutItem4.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem4.Weight = 65.509433962264154R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem3, DashboardLayoutItem4})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 72.230428360413583R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2, DashboardLayoutGroup2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard"
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents CardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents DateFilterDashboardItem1 As DevExpress.DashboardCommon.DateFilterDashboardItem
        Friend WithEvents GridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem

#End Region
    End Class
End Namespace