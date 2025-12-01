Namespace Win_Dashboards
    Partial Public Class Dashboard3
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
            Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
            Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table3 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table4 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column8 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression8 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table5 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column9 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression9 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table6 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column10 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression10 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table7 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column11 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression11 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table8 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Join1 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo1 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join2 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo2 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join3 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo3 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join4 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo4 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join5 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo5 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join6 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo6 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Join7 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo7 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard3))
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
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
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn1 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn1 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridSparklineColumn1 As DevExpress.DashboardCommon.GridSparklineColumn = New DevExpress.DashboardCommon.GridSparklineColumn()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridItemFormatRule1 As DevExpress.DashboardCommon.GridItemFormatRule = New DevExpress.DashboardCommon.GridItemFormatRule()
            Dim FormatConditionColorRangeBar1 As DevExpress.DashboardCommon.FormatConditionColorRangeBar = New DevExpress.DashboardCommon.FormatConditionColorRangeBar()
            Dim RangeInfo1 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings1 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim RangeInfo2 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings2 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension8 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension9 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension10 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension11 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn2 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn2 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim GridItemFormatRule2 As DevExpress.DashboardCommon.GridItemFormatRule = New DevExpress.DashboardCommon.GridItemFormatRule()
            Dim FormatConditionGradientRangeBar1 As DevExpress.DashboardCommon.FormatConditionGradientRangeBar = New DevExpress.DashboardCommon.FormatConditionGradientRangeBar()
            Dim RangeInfo3 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings3 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim RangeInfo4 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim RangeInfo5 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim RangeInfo6 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim RangeInfo7 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings4 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension12 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension13 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension14 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension15 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim GridDimensionColumn3 As DevExpress.DashboardCommon.GridDimensionColumn = New DevExpress.DashboardCommon.GridDimensionColumn()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim GridMeasureColumn3 As DevExpress.DashboardCommon.GridMeasureColumn = New DevExpress.DashboardCommon.GridMeasureColumn()
            Dim GridItemFormatRule3 As DevExpress.DashboardCommon.GridItemFormatRule = New DevExpress.DashboardCommon.GridItemFormatRule()
            Dim FormatConditionColorRangeBar2 As DevExpress.DashboardCommon.FormatConditionColorRangeBar = New DevExpress.DashboardCommon.FormatConditionColorRangeBar()
            Dim RangeInfo8 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings5 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim RangeInfo9 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings6 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim RangeInfo10 As DevExpress.DashboardCommon.RangeInfo = New DevExpress.DashboardCommon.RangeInfo()
            Dim BarStyleSettings7 As DevExpress.DashboardCommon.BarStyleSettings = New DevExpress.DashboardCommon.BarStyleSettings()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup4 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem6 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem7 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem8 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup5 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup6 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem9 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem10 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup7 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem11 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem12 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem13 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem14 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.ComboBoxDashboardItem4 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.DashboardSqlDataSource2 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.DateFilterDashboardItem1 = New DevExpress.DashboardCommon.DateFilterDashboardItem()
            Me.ComboBoxDashboardItem3 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.GridDashboardItem1 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.ComboBoxDashboardItem2 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.PieDashboardItem1 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.ComboBoxDashboardItem5 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.PieDashboardItem3 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.GridDashboardItem3 = New DevExpress.DashboardCommon.GridDashboardItem()
            Me.ComboBoxDashboardItem6 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem7 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem1 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.GridDashboardItem2 = New DevExpress.DashboardCommon.GridDashboardItem()
            CType(Me.ComboBoxDashboardItem4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardSqlDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension12, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension13, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension14, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension15, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'ComboBoxDashboardItem4
            '
            Me.ComboBoxDashboardItem4.ComponentName = "ComboBoxDashboardItem4"
            Dimension1.DataMember = "Name"
            Me.ComboBoxDashboardItem4.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem4.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.ComboBoxDashboardItem4.DataMember = "Items"
            Me.ComboBoxDashboardItem4.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem4.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension1})
            Me.ComboBoxDashboardItem4.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem4.Name = "السند"
            Me.ComboBoxDashboardItem4.ShowCaption = True
            '
            'DashboardSqlDataSource2
            '
            Me.DashboardSqlDataSource2.ComponentName = "DashboardSqlDataSource2"
            Me.DashboardSqlDataSource2.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
            Me.DashboardSqlDataSource2.Name = "SQL Data Source 1"
            ColumnExpression1.ColumnName = "ItemNo"
            Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""703"" />"
            Table1.Name = "Items"
            ColumnExpression1.Table = Table1
            Column1.Expression = ColumnExpression1
            ColumnExpression2.ColumnName = "ItemName"
            ColumnExpression2.Table = Table1
            Column2.Expression = ColumnExpression2
            ColumnExpression3.ColumnName = "GroupName"
            Table2.MetaSerializable = "<Meta X=""185"" Y=""30"" Width=""125"" Height=""163"" />"
            Table2.Name = "ItemsGroups"
            ColumnExpression3.Table = Table2
            Column3.Expression = ColumnExpression3
            ColumnExpression4.ColumnName = "DocDate"
            Table3.MetaSerializable = "<Meta X=""340"" Y=""30"" Width=""125"" Height=""1543"" />"
            Table3.Name = "Journal"
            ColumnExpression4.Table = Table3
            Column4.Expression = ColumnExpression4
            ColumnExpression5.ColumnName = "RefName"
            Table4.MetaSerializable = "<Meta X=""495"" Y=""30"" Width=""125"" Height=""503"" />"
            Table4.Name = "Referencess"
            ColumnExpression5.Table = Table4
            Column5.Expression = ColumnExpression5
            Column6.Alias = "BaseAmount"
            ColumnExpression6.ColumnName = "BaseCurrAmount"
            ColumnExpression6.Table = Table3
            Column6.Expression = ColumnExpression6
            ColumnExpression7.ColumnName = "DocName"
            ColumnExpression7.Table = Table3
            Column7.Expression = ColumnExpression7
            ColumnExpression8.ColumnName = "Name"
            Table5.MetaSerializable = "<Meta X=""650"" Y=""30"" Width=""125"" Height=""103"" />"
            Table5.Name = "DocNames"
            ColumnExpression8.Table = Table5
            Column8.Expression = ColumnExpression8
            ColumnExpression9.ColumnName = "CategoryName"
            Table6.MetaSerializable = "<Meta X=""805"" Y=""30"" Width=""125"" Height=""103"" />"
            Table6.Name = "ItemsCategories"
            ColumnExpression9.Table = Table6
            Column9.Expression = ColumnExpression9
            ColumnExpression10.ColumnName = "RefTypeName"
            Table7.MetaSerializable = "<Meta X=""960"" Y=""30"" Width=""125"" Height=""123"" />"
            Table7.Name = "ReferencesTypes"
            ColumnExpression10.Table = Table7
            Column10.Expression = ColumnExpression10
            ColumnExpression11.ColumnName = "SortName"
            Table8.MetaSerializable = "<Meta X=""1115"" Y=""30"" Width=""125"" Height=""103"" />"
            Table8.Name = "RefSorts"
            ColumnExpression11.Table = Table8
            Column11.Expression = ColumnExpression11
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
            SelectQuery1.FilterString = "[Journal.DocStatus] <> 0 And [Journal.DocName] In (1, 2, 12, 13)"
            SelectQuery1.GroupFilterString = ""
            SelectQuery1.Name = "Items"
            RelationColumnInfo1.NestedKeyColumn = "StockID"
            RelationColumnInfo1.ParentKeyColumn = "ItemNo"
            Join1.KeyColumns.Add(RelationColumnInfo1)
            Join1.Nested = Table3
            Join1.Parent = Table1
            RelationColumnInfo2.NestedKeyColumn = "RefNo"
            RelationColumnInfo2.ParentKeyColumn = "Referance"
            Join2.KeyColumns.Add(RelationColumnInfo2)
            Join2.Nested = Table4
            Join2.Parent = Table3
            RelationColumnInfo3.NestedKeyColumn = "id"
            RelationColumnInfo3.ParentKeyColumn = "DocName"
            Join3.KeyColumns.Add(RelationColumnInfo3)
            Join3.Nested = Table5
            Join3.Parent = Table3
            RelationColumnInfo4.NestedKeyColumn = "CategoryID"
            RelationColumnInfo4.ParentKeyColumn = "CategoryID"
            Join4.KeyColumns.Add(RelationColumnInfo4)
            Join4.Nested = Table6
            Join4.Parent = Table1
            Join4.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
            RelationColumnInfo5.NestedKeyColumn = "GroupID"
            RelationColumnInfo5.ParentKeyColumn = "GroupID"
            Join5.KeyColumns.Add(RelationColumnInfo5)
            Join5.Nested = Table2
            Join5.Parent = Table1
            Join5.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
            RelationColumnInfo6.NestedKeyColumn = "TypeID"
            RelationColumnInfo6.ParentKeyColumn = "RefType"
            Join6.KeyColumns.Add(RelationColumnInfo6)
            Join6.Nested = Table7
            Join6.Parent = Table4
            Join6.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
            RelationColumnInfo7.NestedKeyColumn = "ID"
            RelationColumnInfo7.ParentKeyColumn = "RefSort"
            Join7.KeyColumns.Add(RelationColumnInfo7)
            Join7.Nested = Table8
            Join7.Parent = Table4
            Join7.SqlJoinType = CType(DevExpress.DataAccess.Sql.SqlJoinType.LeftOuter, DevExpress.DataAccess.Sql.SqlJoinType)
            SelectQuery1.Relations.Add(Join1)
            SelectQuery1.Relations.Add(Join2)
            SelectQuery1.Relations.Add(Join3)
            SelectQuery1.Relations.Add(Join4)
            SelectQuery1.Relations.Add(Join5)
            SelectQuery1.Relations.Add(Join6)
            SelectQuery1.Relations.Add(Join7)
            SelectQuery1.Tables.Add(Table1)
            SelectQuery1.Tables.Add(Table2)
            SelectQuery1.Tables.Add(Table3)
            SelectQuery1.Tables.Add(Table4)
            SelectQuery1.Tables.Add(Table5)
            SelectQuery1.Tables.Add(Table6)
            SelectQuery1.Tables.Add(Table7)
            SelectQuery1.Tables.Add(Table8)
            Me.DashboardSqlDataSource2.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
            Me.DashboardSqlDataSource2.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource2.ResultSchemaSerializable")
            '
            'DateFilterDashboardItem1
            '
            Me.DateFilterDashboardItem1.ComponentName = "DateFilterDashboardItem1"
            Dimension2.DataMember = "DocDate"
            Dimension2.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.DateFilterDashboardItem1.DataItemRepository.Clear()
            Me.DateFilterDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.DateFilterDashboardItem1.DataMember = "Items"
            Me.DateFilterDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            FlowDateTimePeriodLimit1.Offset = 1
            DateTimePeriod1.End = FlowDateTimePeriodLimit1
            DateTimePeriod1.Name = "This Year"
            DateTimePeriod1.Start = FlowDateTimePeriodLimit2
            FlowDateTimePeriodLimit3.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit3.Offset = 1
            DateTimePeriod2.End = FlowDateTimePeriodLimit3
            DateTimePeriod2.Name = "This Month"
            FlowDateTimePeriodLimit4.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod2.Start = FlowDateTimePeriodLimit4
            DateTimePeriod3.End = FlowDateTimePeriodLimit5
            DateTimePeriod3.Name = "Last Year"
            FlowDateTimePeriodLimit6.Offset = -1
            DateTimePeriod3.Start = FlowDateTimePeriodLimit6
            FlowDateTimePeriodLimit7.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod4.End = FlowDateTimePeriodLimit7
            DateTimePeriod4.Name = "Last Month"
            FlowDateTimePeriodLimit8.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit8.Offset = -1
            DateTimePeriod4.Start = FlowDateTimePeriodLimit8
            Me.DateFilterDashboardItem1.DateTimePeriods.AddRange(New DevExpress.DashboardCommon.DateTimePeriod() {DateTimePeriod1, DateTimePeriod2, DateTimePeriod3, DateTimePeriod4})
            Me.DateFilterDashboardItem1.DefaultDateTimePeriodName = "This Year"
            Me.DateFilterDashboardItem1.Dimension = Dimension2
            Me.DateFilterDashboardItem1.Name = "الفترة"
            Me.DateFilterDashboardItem1.ShowCaption = True
            '
            'ComboBoxDashboardItem3
            '
            Me.ComboBoxDashboardItem3.ComponentName = "ComboBoxDashboardItem3"
            Dimension3.DataMember = "ItemName"
            Me.ComboBoxDashboardItem3.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem3.DataItemRepository.Add(Dimension3, "DataItem0")
            Me.ComboBoxDashboardItem3.DataMember = "Items"
            Me.ComboBoxDashboardItem3.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem3.EnableSearch = True
            Me.ComboBoxDashboardItem3.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension3})
            Me.ComboBoxDashboardItem3.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem3.Name = "الاصناف"
            Me.ComboBoxDashboardItem3.ShowCaption = True
            '
            'GridDashboardItem1
            '
            Dimension4.DataMember = "ItemName"
            GridDimensionColumn1.Name = "الصنف"
            GridDimensionColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn1.AddDataItem("Dimension", Dimension4)
            Measure1.DataMember = "BaseAmount"
            Measure1.NumericFormat.CustomFormatString = ""
            Measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure1.NumericFormat.IncludeGroupSeparator = True
            Measure1.NumericFormat.Precision = 0
            Measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridMeasureColumn1.Name = "المبلغ"
            GridMeasureColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn1.AddDataItem("Measure", Measure1)
            Measure2.DataMember = "BaseAmount"
            Measure2.NumericFormat.CustomFormatString = ""
            Measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure2.NumericFormat.IncludeGroupSeparator = True
            Measure2.NumericFormat.Precision = 0
            Measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridSparklineColumn1.Name = "المبلغ"
            GridSparklineColumn1.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridSparklineColumn1.AddDataItem("SparklineValue", Measure2)
            Me.GridDashboardItem1.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn1, GridMeasureColumn1, GridSparklineColumn1})
            Me.GridDashboardItem1.ComponentName = "GridDashboardItem1"
            Dimension5.DataMember = "DocDate"
            Dimension5.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month
            Me.GridDashboardItem1.DataItemRepository.Clear()
            Me.GridDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.GridDashboardItem1.DataItemRepository.Add(Measure1, "DataItem1")
            Me.GridDashboardItem1.DataItemRepository.Add(Measure2, "DataItem2")
            Me.GridDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem3")
            Me.GridDashboardItem1.DataMember = "Items"
            Me.GridDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            BarStyleSettings1.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Red
            RangeInfo1.StyleSettings = BarStyleSettings1
            RangeInfo1.Value = 0R
            BarStyleSettings2.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Green
            RangeInfo2.StyleSettings = BarStyleSettings2
            RangeInfo2.Value = 50.0R
            FormatConditionColorRangeBar1.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo1, RangeInfo2})
            FormatConditionColorRangeBar1.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            GridItemFormatRule1.Condition = FormatConditionColorRangeBar1
            GridItemFormatRule1.Enabled = False
            GridItemFormatRule1.Name = "FormatRule 1"
            Me.GridDashboardItem1.FormatRules.AddRange(New DevExpress.DashboardCommon.GridItemFormatRule() {GridItemFormatRule1})
            Me.GridDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.GridDashboardItem1.Name = "مبيعات الاصناف"
            Me.GridDashboardItem1.ShowCaption = True
            Me.GridDashboardItem1.SparklineArgument = Dimension5
            '
            'ComboBoxDashboardItem2
            '
            Me.ComboBoxDashboardItem2.ComponentName = "ComboBoxDashboardItem2"
            Dimension6.DataMember = "GroupName"
            Me.ComboBoxDashboardItem2.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem2.DataItemRepository.Add(Dimension6, "DataItem0")
            Me.ComboBoxDashboardItem2.DataMember = "Items"
            Me.ComboBoxDashboardItem2.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem2.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension6})
            Me.ComboBoxDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem2.Name = "مجموعات الاصناف"
            Me.ComboBoxDashboardItem2.ShowCaption = True
            '
            'PieDashboardItem1
            '
            Dimension7.DataMember = "GroupName"
            Me.PieDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension7})
            Me.PieDashboardItem1.ComponentName = "PieDashboardItem1"
            Measure3.DataMember = "BaseAmount"
            Measure3.Name = "المبلغ"
            Me.PieDashboardItem1.DataItemRepository.Clear()
            Me.PieDashboardItem1.DataItemRepository.Add(Measure3, "DataItem0")
            Me.PieDashboardItem1.DataItemRepository.Add(Dimension7, "DataItem1")
            Me.PieDashboardItem1.DataMember = "Items"
            Me.PieDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            Me.PieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem1.Name = "المبيعات حسب المجموعة"
            Me.PieDashboardItem1.ShowCaption = True
            Me.PieDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure3})
            '
            'ComboBoxDashboardItem5
            '
            Me.ComboBoxDashboardItem5.ComponentName = "ComboBoxDashboardItem5"
            Dimension8.DataMember = "CategoryName"
            Me.ComboBoxDashboardItem5.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem5.DataItemRepository.Add(Dimension8, "DataItem0")
            Me.ComboBoxDashboardItem5.DataMember = "Items"
            Me.ComboBoxDashboardItem5.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem5.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension8})
            Me.ComboBoxDashboardItem5.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem5.Name = "التصنيف"
            Me.ComboBoxDashboardItem5.ShowCaption = True
            '
            'PieDashboardItem3
            '
            Dimension9.DataMember = "CategoryName"
            Me.PieDashboardItem3.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension9})
            Me.PieDashboardItem3.ComponentName = "PieDashboardItem3"
            Measure4.DataMember = "BaseAmount"
            Measure4.Name = "المبلغ"
            Measure4.NumericFormat.CustomFormatString = ""
            Measure4.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure4.NumericFormat.IncludeGroupSeparator = True
            Measure4.NumericFormat.Precision = 0
            Measure4.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            Me.PieDashboardItem3.DataItemRepository.Clear()
            Me.PieDashboardItem3.DataItemRepository.Add(Dimension9, "DataItem0")
            Me.PieDashboardItem3.DataItemRepository.Add(Measure4, "DataItem1")
            Me.PieDashboardItem3.DataMember = "Items"
            Me.PieDashboardItem3.DataSource = Me.DashboardSqlDataSource2
            Me.PieDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem3.Name = "المبيعات حسب التصنيف"
            Me.PieDashboardItem3.ShowCaption = True
            Me.PieDashboardItem3.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure4})
            '
            'ChartDashboardItem1
            '
            Dimension10.DataMember = "DocDate"
            Dimension10.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension10})
            Me.ChartDashboardItem1.AxisX.Title = "الشهر"
            Me.ChartDashboardItem1.AxisX.TitleVisible = True
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure5.DataMember = "BaseAmount"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure5, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension10, "DataItem1")
            Me.ChartDashboardItem1.DataMember = "Items"
            Me.ChartDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "المبيعات الشهرية"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.Name = "المبلغ"
            SimpleSeries1.AddDataItem("Value", Measure5)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'GridDashboardItem3
            '
            Dimension11.DataMember = "DocDate"
            Dimension11.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            GridDimensionColumn2.Name = "الفترة"
            GridDimensionColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn2.AddDataItem("Dimension", Dimension11)
            Measure6.DataMember = "BaseAmount"
            Measure6.NumericFormat.CustomFormatString = ""
            Measure6.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure6.NumericFormat.IncludeGroupSeparator = True
            Measure6.NumericFormat.Precision = 0
            Measure6.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridMeasureColumn2.Name = "المبلغ"
            GridMeasureColumn2.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn2.AddDataItem("Measure", Measure6)
            Me.GridDashboardItem3.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn2, GridMeasureColumn2})
            Me.GridDashboardItem3.ComponentName = "GridDashboardItem3"
            Me.GridDashboardItem3.DataItemRepository.Clear()
            Me.GridDashboardItem3.DataItemRepository.Add(Measure6, "DataItem1")
            Me.GridDashboardItem3.DataItemRepository.Add(Dimension11, "DataItem0")
            Me.GridDashboardItem3.DataMember = "Items"
            Me.GridDashboardItem3.DataSource = Me.DashboardSqlDataSource2
            BarStyleSettings3.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.GradientGreen
            RangeInfo3.StyleSettings = BarStyleSettings3
            RangeInfo3.Value = 0R
            RangeInfo4.Value = 20.0R
            RangeInfo5.Value = 40.0R
            RangeInfo6.Value = 60.0R
            BarStyleSettings4.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.GradientTransparent
            RangeInfo7.StyleSettings = BarStyleSettings4
            RangeInfo7.Value = 80.0R
            FormatConditionGradientRangeBar1.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo3, RangeInfo4, RangeInfo5, RangeInfo6, RangeInfo7})
            FormatConditionGradientRangeBar1.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            GridItemFormatRule2.Condition = FormatConditionGradientRangeBar1
            Measure7.DataMember = "BaseAmount"
            GridItemFormatRule2.DataItem = Measure7
            GridItemFormatRule2.DataItemApplyTo = Measure7
            GridItemFormatRule2.Name = "FormatRule 1"
            Me.GridDashboardItem3.FormatRules.AddRange(New DevExpress.DashboardCommon.GridItemFormatRule() {GridItemFormatRule2})
            Me.GridDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.GridDashboardItem3.Name = "مبلغ المبيعات الشهرية"
            Me.GridDashboardItem3.ShowCaption = True
            '
            'ComboBoxDashboardItem6
            '
            Me.ComboBoxDashboardItem6.ComponentName = "ComboBoxDashboardItem6"
            Dimension12.DataMember = "RefTypeName"
            Me.ComboBoxDashboardItem6.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem6.DataItemRepository.Add(Dimension12, "DataItem0")
            Me.ComboBoxDashboardItem6.DataMember = "Items"
            Me.ComboBoxDashboardItem6.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem6.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension12})
            Me.ComboBoxDashboardItem6.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem6.Name = "نوع الذمة"
            Me.ComboBoxDashboardItem6.ShowCaption = True
            '
            'ComboBoxDashboardItem7
            '
            Me.ComboBoxDashboardItem7.ComponentName = "ComboBoxDashboardItem7"
            Dimension13.DataMember = "SortName"
            Me.ComboBoxDashboardItem7.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem7.DataItemRepository.Add(Dimension13, "DataItem0")
            Me.ComboBoxDashboardItem7.DataMember = "Items"
            Me.ComboBoxDashboardItem7.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem7.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension13})
            Me.ComboBoxDashboardItem7.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem7.Name = "تصنيف الذمة"
            Me.ComboBoxDashboardItem7.ShowCaption = True
            '
            'ComboBoxDashboardItem1
            '
            Me.ComboBoxDashboardItem1.ComponentName = "ComboBoxDashboardItem1"
            Dimension14.DataMember = "RefName"
            Me.ComboBoxDashboardItem1.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem1.DataItemRepository.Add(Dimension14, "DataItem0")
            Me.ComboBoxDashboardItem1.DataMember = "Items"
            Me.ComboBoxDashboardItem1.DataSource = Me.DashboardSqlDataSource2
            Me.ComboBoxDashboardItem1.EnableSearch = True
            Me.ComboBoxDashboardItem1.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension14})
            Me.ComboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem1.Name = "الذمم"
            Me.ComboBoxDashboardItem1.ShowCaption = True
            '
            'GridDashboardItem2
            '
            Dimension15.DataMember = "RefName"
            GridDimensionColumn3.Name = "الذمة"
            GridDimensionColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridDimensionColumn3.AddDataItem("Dimension", Dimension15)
            Measure8.DataMember = "BaseAmount"
            Measure8.NumericFormat.CustomFormatString = ""
            Measure8.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number
            Measure8.NumericFormat.IncludeGroupSeparator = True
            Measure8.NumericFormat.Precision = 0
            Measure8.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones
            GridMeasureColumn3.Name = "المبلغ"
            GridMeasureColumn3.WidthType = DevExpress.DashboardCommon.GridColumnFixedWidthType.Weight
            GridMeasureColumn3.AddDataItem("Measure", Measure8)
            Me.GridDashboardItem2.Columns.AddRange(New DevExpress.DashboardCommon.GridColumnBase() {GridDimensionColumn3, GridMeasureColumn3})
            Me.GridDashboardItem2.ComponentName = "GridDashboardItem2"
            Me.GridDashboardItem2.DataItemRepository.Clear()
            Me.GridDashboardItem2.DataItemRepository.Add(Dimension15, "DataItem0")
            Me.GridDashboardItem2.DataItemRepository.Add(Measure8, "DataItem1")
            Me.GridDashboardItem2.DataMember = "Items"
            Me.GridDashboardItem2.DataSource = Me.DashboardSqlDataSource2
            BarStyleSettings5.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Red
            RangeInfo8.StyleSettings = BarStyleSettings5
            RangeInfo8.Value = 0R
            BarStyleSettings6.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Green
            RangeInfo9.StyleSettings = BarStyleSettings6
            RangeInfo9.Value = 33.0R
            BarStyleSettings7.PredefinedColor = DevExpress.DashboardCommon.FormatConditionAppearanceType.Blue
            RangeInfo10.StyleSettings = BarStyleSettings7
            RangeInfo10.Value = 67.0R
            FormatConditionColorRangeBar2.RangeSet.AddRange(New DevExpress.DashboardCommon.RangeInfo() {RangeInfo8, RangeInfo9, RangeInfo10})
            FormatConditionColorRangeBar2.ValueType = DevExpress.DashboardCommon.DashboardFormatConditionValueType.Percent
            GridItemFormatRule3.Condition = FormatConditionColorRangeBar2
            GridItemFormatRule3.Enabled = False
            GridItemFormatRule3.Name = "FormatRule 1"
            Me.GridDashboardItem2.FormatRules.AddRange(New DevExpress.DashboardCommon.GridItemFormatRule() {GridItemFormatRule3})
            Me.GridDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.GridDashboardItem2.Name = "مبيعات حسب الزبون"
            Me.GridDashboardItem2.ShowCaption = True
            '
            'Dashboard3
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource2})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.ChartDashboardItem1, Me.PieDashboardItem1, Me.GridDashboardItem1, Me.GridDashboardItem2, Me.ComboBoxDashboardItem1, Me.ComboBoxDashboardItem2, Me.ComboBoxDashboardItem3, Me.ComboBoxDashboardItem4, Me.DateFilterDashboardItem1, Me.ComboBoxDashboardItem5, Me.PieDashboardItem3, Me.ComboBoxDashboardItem6, Me.ComboBoxDashboardItem7, Me.GridDashboardItem3})
            DashboardLayoutItem1.DashboardItem = Me.ComboBoxDashboardItem4
            DashboardLayoutItem1.Weight = 24.943481537302187R
            DashboardLayoutItem2.DashboardItem = Me.DateFilterDashboardItem1
            DashboardLayoutItem2.Weight = 50.263752825923135R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 12.238805970149254R
            DashboardLayoutItem3.DashboardItem = Me.ComboBoxDashboardItem3
            DashboardLayoutItem3.Weight = 9.183673469387756R
            DashboardLayoutItem4.DashboardItem = Me.GridDashboardItem1
            DashboardLayoutItem4.Weight = 27.040816326530614R
            DashboardLayoutItem5.DashboardItem = Me.ComboBoxDashboardItem2
            DashboardLayoutItem5.Weight = 9.183673469387756R
            DashboardLayoutItem6.DashboardItem = Me.PieDashboardItem1
            DashboardLayoutItem6.Weight = 29.591836734693878R
            DashboardLayoutItem7.DashboardItem = Me.ComboBoxDashboardItem5
            DashboardLayoutItem7.Weight = 9.183673469387756R
            DashboardLayoutItem8.DashboardItem = Me.PieDashboardItem3
            DashboardLayoutItem8.Weight = 15.816326530612244R
            DashboardLayoutGroup4.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem3, DashboardLayoutItem4, DashboardLayoutItem5, DashboardLayoutItem6, DashboardLayoutItem7, DashboardLayoutItem8})
            DashboardLayoutGroup4.DashboardItem = Nothing
            DashboardLayoutGroup4.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup4.Weight = 36.473247927656367R
            DashboardLayoutItem9.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem9.Weight = 50.0R
            DashboardLayoutItem10.DashboardItem = Me.GridDashboardItem3
            DashboardLayoutItem10.Weight = 50.0R
            DashboardLayoutGroup6.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem9, DashboardLayoutItem10})
            DashboardLayoutGroup6.DashboardItem = Nothing
            DashboardLayoutGroup6.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup6.Weight = 48.16132858837485R
            DashboardLayoutItem11.DashboardItem = Me.ComboBoxDashboardItem6
            DashboardLayoutItem11.Weight = 9.183673469387756R
            DashboardLayoutItem12.DashboardItem = Me.ComboBoxDashboardItem7
            DashboardLayoutItem12.Weight = 9.183673469387756R
            DashboardLayoutItem13.DashboardItem = Me.ComboBoxDashboardItem1
            DashboardLayoutItem13.Weight = 9.183673469387756R
            DashboardLayoutItem14.DashboardItem = Me.GridDashboardItem2
            DashboardLayoutItem14.Weight = 72.448979591836732R
            DashboardLayoutGroup7.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem11, DashboardLayoutItem12, DashboardLayoutItem13, DashboardLayoutItem14})
            DashboardLayoutGroup7.DashboardItem = Nothing
            DashboardLayoutGroup7.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup7.Weight = 51.83867141162515R
            DashboardLayoutGroup5.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup6, DashboardLayoutGroup7})
            DashboardLayoutGroup5.DashboardItem = Nothing
            DashboardLayoutGroup5.Weight = 63.526752072343633R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup4, DashboardLayoutGroup5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Weight = 87.761194029850742R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup3})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "مبيعات الاصناف"
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardSqlDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension12, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension13, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension14, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension15, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource2 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents PieDashboardItem1 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents GridDashboardItem1 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents GridDashboardItem2 As DevExpress.DashboardCommon.GridDashboardItem
        Friend WithEvents ComboBoxDashboardItem1 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem2 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem3 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem4 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents DateFilterDashboardItem1 As DevExpress.DashboardCommon.DateFilterDashboardItem
        Friend WithEvents ComboBoxDashboardItem5 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents PieDashboardItem3 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents ComboBoxDashboardItem6 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem7 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents GridDashboardItem3 As DevExpress.DashboardCommon.GridDashboardItem

#End Region
    End Class
End Namespace