Namespace Win_Dashboards
    Partial Public Class OrpakSales
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
            Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column5 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression5 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column6 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression6 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column7 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression7 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrpakSales))
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane2 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane3 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension8 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane4 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries4 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension9 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane5 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries5 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension10 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane6 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries6 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card1 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate1 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Dimension11 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutTabContainer1 As DevExpress.DashboardCommon.DashboardLayoutTabContainer = New DevExpress.DashboardCommon.DashboardLayoutTabContainer()
            Dim DashboardLayoutTabPage1 As DevExpress.DashboardCommon.DashboardLayoutTabPage = New DevExpress.DashboardCommon.DashboardLayoutTabPage()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem6 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup4 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem7 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem8 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutTabPage2 As DevExpress.DashboardCommon.DashboardLayoutTabPage = New DevExpress.DashboardCommon.DashboardLayoutTabPage()
            Dim DashboardLayoutItem9 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutTabPage3 As DevExpress.DashboardCommon.DashboardLayoutTabPage = New DevExpress.DashboardCommon.DashboardLayoutTabPage()
            Dim DashboardLayoutItem10 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem11 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DateFilterDashboardItem1 = New DevExpress.DashboardCommon.DateFilterDashboardItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.ComboBoxDashboardItem2 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem3 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem1 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.ChartDashboardItem2 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.ChartDashboardItem3 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.ChartDashboardItem4 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.ChartDashboardItem5 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.TabContainerDashboardItem1 = New DevExpress.DashboardCommon.TabContainerDashboardItem()
            Me.dashboardTabPage1 = New DevExpress.DashboardCommon.DashboardTabPage()
            Me.DashboardTabPage2 = New DevExpress.DashboardCommon.DashboardTabPage()
            Me.DashboardTabPage3 = New DevExpress.DashboardCommon.DashboardTabPage()
            Me.ChartDashboardItem6 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.CardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabContainerDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dashboardTabPage1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardTabPage2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardTabPage3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DateFilterDashboardItem1
            '
            Me.DateFilterDashboardItem1.ComponentName = "DateFilterDashboardItem1"
            Dimension1.DataMember = "timestamp"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.DateFilterDashboardItem1.DataItemRepository.Clear()
            Me.DateFilterDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.DateFilterDashboardItem1.DataMember = "transactions"
            Me.DateFilterDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            FlowDateTimePeriodLimit1.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit1.Offset = 1
            DateTimePeriod1.End = FlowDateTimePeriodLimit1
            DateTimePeriod1.Name = "This Month"
            FlowDateTimePeriodLimit2.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod1.Start = FlowDateTimePeriodLimit2
            FlowDateTimePeriodLimit3.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod2.End = FlowDateTimePeriodLimit3
            DateTimePeriod2.Name = "Last Month"
            FlowDateTimePeriodLimit4.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit4.Offset = -1
            DateTimePeriod2.Start = FlowDateTimePeriodLimit4
            FlowDateTimePeriodLimit5.Offset = 1
            DateTimePeriod3.End = FlowDateTimePeriodLimit5
            DateTimePeriod3.Name = "This Year"
            DateTimePeriod3.Start = FlowDateTimePeriodLimit6
            DateTimePeriod4.End = FlowDateTimePeriodLimit7
            DateTimePeriod4.Name = "Last Year"
            FlowDateTimePeriodLimit8.Offset = -1
            DateTimePeriod4.Start = FlowDateTimePeriodLimit8
            Me.DateFilterDashboardItem1.DateTimePeriods.AddRange(New DevExpress.DashboardCommon.DateTimePeriod() {DateTimePeriod1, DateTimePeriod2, DateTimePeriod3, DateTimePeriod4})
            Me.DateFilterDashboardItem1.Dimension = Dimension1
            Me.DateFilterDashboardItem1.Name = "الفترة"
            Me.DateFilterDashboardItem1.ShowCaption = True
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "TrueTime.My.MySettings.Orpak"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            ColumnExpression1.ColumnName = "timestamp"
            Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""1805"" />"
            Table1.Name = "transactions"
            ColumnExpression1.Table = Table1
            Column1.Expression = ColumnExpression1
            ColumnExpression2.ColumnName = "quantity"
            ColumnExpression2.Table = Table1
            Column2.Expression = ColumnExpression2
            ColumnExpression3.ColumnName = "fleet_code"
            ColumnExpression3.Table = Table1
            Column3.Expression = ColumnExpression3
            ColumnExpression4.ColumnName = "fleet_name"
            ColumnExpression4.Table = Table1
            Column4.Expression = ColumnExpression4
            ColumnExpression5.ColumnName = "product_name"
            ColumnExpression5.Table = Table1
            Column5.Expression = ColumnExpression5
            ColumnExpression6.ColumnName = "type"
            ColumnExpression6.Table = Table1
            Column6.Expression = ColumnExpression6
            ColumnExpression7.ColumnName = "plate"
            ColumnExpression7.Table = Table1
            Column7.Expression = ColumnExpression7
            SelectQuery1.Columns.Add(Column1)
            SelectQuery1.Columns.Add(Column2)
            SelectQuery1.Columns.Add(Column3)
            SelectQuery1.Columns.Add(Column4)
            SelectQuery1.Columns.Add(Column5)
            SelectQuery1.Columns.Add(Column6)
            SelectQuery1.Columns.Add(Column7)
            SelectQuery1.Name = "transactions"
            SelectQuery1.Tables.Add(Table1)
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'ComboBoxDashboardItem2
            '
            Me.ComboBoxDashboardItem2.ComponentName = "ComboBoxDashboardItem2"
            Dimension2.DataMember = "fleet_name"
            Me.ComboBoxDashboardItem2.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem2.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.ComboBoxDashboardItem2.DataMember = "transactions"
            Me.ComboBoxDashboardItem2.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem2.EnableSearch = True
            Me.ComboBoxDashboardItem2.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.ComboBoxDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem2.Name = "الزبون"
            Me.ComboBoxDashboardItem2.ShowCaption = True
            '
            'ComboBoxDashboardItem3
            '
            Me.ComboBoxDashboardItem3.ComponentName = "ComboBoxDashboardItem3"
            Dimension3.DataMember = "type"
            Me.ComboBoxDashboardItem3.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem3.DataItemRepository.Add(Dimension3, "DataItem0")
            Me.ComboBoxDashboardItem3.DataMember = "transactions"
            Me.ComboBoxDashboardItem3.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem3.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension3})
            Me.ComboBoxDashboardItem3.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem3.Name = "نوع الحركة"
            Me.ComboBoxDashboardItem3.ShowCaption = True
            '
            'ComboBoxDashboardItem1
            '
            Me.ComboBoxDashboardItem1.ComponentName = "ComboBoxDashboardItem1"
            Dimension4.DataMember = "product_name"
            Me.ComboBoxDashboardItem1.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem1.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.ComboBoxDashboardItem1.DataMember = "transactions"
            Me.ComboBoxDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem1.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension4})
            Me.ComboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem1.Name = "الصنف"
            Me.ComboBoxDashboardItem1.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Dimension5.DataMember = "fleet_name"
            Dimension5.TopNOptions.Count = 10
            Dimension5.TopNOptions.Enabled = True
            Measure1.DataMember = "quantity"
            Dimension5.TopNOptions.Measure = Measure1
            Dimension5.TopNOptions.ShowOthers = True
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension5})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem1")
            Me.ChartDashboardItem1.DataMember = "transactions"
            Me.ChartDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem1.FilterString = "[DataItem1] <> 'default_fleet'"
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "مبيعات الزبائن"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            SimpleSeries1.AddDataItem("Value", Measure1)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ParentContainer = Me.DashboardTabPage2
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'ChartDashboardItem2
            '
            Dimension6.DataMember = "timestamp"
            Dimension6.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Hour
            Me.ChartDashboardItem2.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension6})
            Me.ChartDashboardItem2.AxisX.TitleVisible = False
            Me.ChartDashboardItem2.ComponentName = "ChartDashboardItem2"
            Measure2.DataMember = "quantity"
            Me.ChartDashboardItem2.DataItemRepository.Clear()
            Me.ChartDashboardItem2.DataItemRepository.Add(Dimension6, "DataItem0")
            Me.ChartDashboardItem2.DataItemRepository.Add(Measure2, "DataItem1")
            Me.ChartDashboardItem2.DataMember = "transactions"
            Me.ChartDashboardItem2.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem2.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem2.Name = "المبيعات حسب الوقت"
            ChartPane2.Name = "Pane 1"
            ChartPane2.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane2.PrimaryAxisY.ShowGridLines = True
            ChartPane2.PrimaryAxisY.TitleVisible = True
            ChartPane2.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane2.SecondaryAxisY.ShowGridLines = False
            ChartPane2.SecondaryAxisY.TitleVisible = True
            SimpleSeries2.AddDataItem("Value", Measure2)
            ChartPane2.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries2})
            Me.ChartDashboardItem2.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane2})
            Me.ChartDashboardItem2.ParentContainer = Me.dashboardTabPage1
            Me.ChartDashboardItem2.ShowCaption = True
            '
            'ChartDashboardItem3
            '
            Dimension7.DataMember = "timestamp"
            Dimension7.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DayOfWeek
            Me.ChartDashboardItem3.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension7})
            Me.ChartDashboardItem3.AxisX.TitleVisible = False
            Me.ChartDashboardItem3.ComponentName = "ChartDashboardItem3"
            Measure3.DataMember = "quantity"
            Me.ChartDashboardItem3.DataItemRepository.Clear()
            Me.ChartDashboardItem3.DataItemRepository.Add(Measure3, "DataItem0")
            Me.ChartDashboardItem3.DataItemRepository.Add(Dimension7, "DataItem1")
            Me.ChartDashboardItem3.DataMember = "transactions"
            Me.ChartDashboardItem3.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem3.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem3.Name = "المبيعات حسب اليوم"
            ChartPane3.Name = "Pane 1"
            ChartPane3.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane3.PrimaryAxisY.ShowGridLines = True
            ChartPane3.PrimaryAxisY.TitleVisible = True
            ChartPane3.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane3.SecondaryAxisY.ShowGridLines = False
            ChartPane3.SecondaryAxisY.TitleVisible = True
            SimpleSeries3.AddDataItem("Value", Measure3)
            ChartPane3.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries3})
            Me.ChartDashboardItem3.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane3})
            Me.ChartDashboardItem3.ParentContainer = Me.dashboardTabPage1
            Me.ChartDashboardItem3.ShowCaption = True
            '
            'ChartDashboardItem4
            '
            Dimension8.DataMember = "timestamp"
            Dimension8.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Day
            Me.ChartDashboardItem4.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension8})
            Me.ChartDashboardItem4.AxisX.TitleVisible = False
            Me.ChartDashboardItem4.ComponentName = "ChartDashboardItem4"
            Measure4.DataMember = "quantity"
            Me.ChartDashboardItem4.DataItemRepository.Clear()
            Me.ChartDashboardItem4.DataItemRepository.Add(Dimension8, "DataItem0")
            Me.ChartDashboardItem4.DataItemRepository.Add(Measure4, "DataItem1")
            Me.ChartDashboardItem4.DataMember = "transactions"
            Me.ChartDashboardItem4.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem4.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem4.Name = "المبيعات حسب التاريخ"
            ChartPane4.Name = "Pane 1"
            ChartPane4.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane4.PrimaryAxisY.ShowGridLines = True
            ChartPane4.PrimaryAxisY.TitleVisible = True
            ChartPane4.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane4.SecondaryAxisY.ShowGridLines = False
            ChartPane4.SecondaryAxisY.TitleVisible = True
            SimpleSeries4.AddDataItem("Value", Measure4)
            ChartPane4.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries4})
            Me.ChartDashboardItem4.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane4})
            Me.ChartDashboardItem4.ParentContainer = Me.dashboardTabPage1
            Me.ChartDashboardItem4.ShowCaption = True
            '
            'ChartDashboardItem5
            '
            Dimension9.DataMember = "timestamp"
            Dimension9.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.Month
            Me.ChartDashboardItem5.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension9})
            Me.ChartDashboardItem5.AxisX.TitleVisible = False
            Me.ChartDashboardItem5.ComponentName = "ChartDashboardItem5"
            Measure5.DataMember = "quantity"
            Me.ChartDashboardItem5.DataItemRepository.Clear()
            Me.ChartDashboardItem5.DataItemRepository.Add(Measure5, "DataItem0")
            Me.ChartDashboardItem5.DataItemRepository.Add(Dimension9, "DataItem1")
            Me.ChartDashboardItem5.DataMember = "transactions"
            Me.ChartDashboardItem5.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem5.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem5.Name = "المبيعات حسب الشهر"
            ChartPane5.Name = "Pane 1"
            ChartPane5.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane5.PrimaryAxisY.ShowGridLines = True
            ChartPane5.PrimaryAxisY.TitleVisible = True
            ChartPane5.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane5.SecondaryAxisY.ShowGridLines = False
            ChartPane5.SecondaryAxisY.TitleVisible = True
            SimpleSeries5.AddDataItem("Value", Measure5)
            ChartPane5.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries5})
            Me.ChartDashboardItem5.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane5})
            Me.ChartDashboardItem5.ParentContainer = Me.dashboardTabPage1
            Me.ChartDashboardItem5.ShowCaption = True
            '
            'TabContainerDashboardItem1
            '
            Me.TabContainerDashboardItem1.ComponentName = "TabContainerDashboardItem1"
            Me.TabContainerDashboardItem1.Name = "Tab Container 1"
            Me.TabContainerDashboardItem1.ShowCaption = True
            Me.TabContainerDashboardItem1.TabPages.AddRange(New DevExpress.DashboardCommon.DashboardTabPage() {Me.dashboardTabPage1, Me.DashboardTabPage2, Me.DashboardTabPage3})
            '
            'dashboardTabPage1
            '
            Me.dashboardTabPage1.ComponentName = "dashboardTabPage1"
            Me.dashboardTabPage1.InteractivityOptions.IgnoreMasterFilters = False
            Me.dashboardTabPage1.InteractivityOptions.IsMasterFilter = True
            Me.dashboardTabPage1.Name = "المبيعات حسب التاريخ"
            Me.dashboardTabPage1.ShowCaption = True
            '
            'DashboardTabPage2
            '
            Me.DashboardTabPage2.ComponentName = "DashboardTabPage2"
            Me.DashboardTabPage2.InteractivityOptions.IgnoreMasterFilters = False
            Me.DashboardTabPage2.InteractivityOptions.IsMasterFilter = True
            Me.DashboardTabPage2.Name = "Page 2"
            Me.DashboardTabPage2.ShowCaption = True
            '
            'DashboardTabPage3
            '
            Me.DashboardTabPage3.ComponentName = "DashboardTabPage3"
            Me.DashboardTabPage3.InteractivityOptions.IgnoreMasterFilters = False
            Me.DashboardTabPage3.InteractivityOptions.IsMasterFilter = True
            Me.DashboardTabPage3.Name = "المبيعات حسب المركبة"
            Me.DashboardTabPage3.ShowCaption = True
            '
            'ChartDashboardItem6
            '
            Dimension10.DataMember = "plate"
            Me.ChartDashboardItem6.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension10})
            Me.ChartDashboardItem6.AxisX.TitleVisible = False
            Me.ChartDashboardItem6.ComponentName = "ChartDashboardItem6"
            Measure6.DataMember = "quantity"
            Me.ChartDashboardItem6.DataItemRepository.Clear()
            Me.ChartDashboardItem6.DataItemRepository.Add(Dimension10, "DataItem0")
            Me.ChartDashboardItem6.DataItemRepository.Add(Measure6, "DataItem1")
            Me.ChartDashboardItem6.DataMember = "transactions"
            Me.ChartDashboardItem6.DataSource = Me.DashboardSqlDataSource1
            Me.ChartDashboardItem6.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem6.Name = "المبيعات حسب المركبة"
            ChartPane6.Name = "Pane 1"
            ChartPane6.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane6.PrimaryAxisY.ShowGridLines = True
            ChartPane6.PrimaryAxisY.TitleVisible = True
            ChartPane6.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane6.SecondaryAxisY.ShowGridLines = False
            ChartPane6.SecondaryAxisY.TitleVisible = True
            SimpleSeries6.AddDataItem("Value", Measure6)
            ChartPane6.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries6})
            Me.ChartDashboardItem6.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane6})
            Me.ChartDashboardItem6.ParentContainer = Me.DashboardTabPage3
            Me.ChartDashboardItem6.ShowCaption = True
            '
            'CardDashboardItem1
            '
            Measure7.DataMember = "quantity"
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
            Card1.AddDataItem("ActualValue", Measure7)
            Me.CardDashboardItem1.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card1})
            Me.CardDashboardItem1.ComponentName = "CardDashboardItem1"
            Dimension11.DataMember = "plate"
            Me.CardDashboardItem1.DataItemRepository.Clear()
            Me.CardDashboardItem1.DataItemRepository.Add(Dimension11, "DataItem0")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure7, "DataItem1")
            Me.CardDashboardItem1.DataMember = "transactions"
            Me.CardDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.CardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.CardDashboardItem1.Name = "Cards 1"
            Me.CardDashboardItem1.ParentContainer = Me.DashboardTabPage3
            Me.CardDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension11})
            Me.CardDashboardItem1.ShowCaption = True
            '
            'OrpakSales
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.ChartDashboardItem1, Me.DateFilterDashboardItem1, Me.ComboBoxDashboardItem1, Me.ComboBoxDashboardItem2, Me.ComboBoxDashboardItem3, Me.ChartDashboardItem2, Me.ChartDashboardItem3, Me.ChartDashboardItem4, Me.ChartDashboardItem5, Me.TabContainerDashboardItem1, Me.ChartDashboardItem6, Me.CardDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.DateFilterDashboardItem1
            DashboardLayoutItem1.Weight = 43.967611336032391R
            DashboardLayoutItem2.DashboardItem = Me.ComboBoxDashboardItem2
            DashboardLayoutItem2.Weight = 26.963562753036438R
            DashboardLayoutItem3.DashboardItem = Me.ComboBoxDashboardItem3
            DashboardLayoutItem3.Weight = 13.765182186234817R
            DashboardLayoutItem4.DashboardItem = Me.ComboBoxDashboardItem1
            DashboardLayoutItem4.Weight = 15.303643724696355R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2, DashboardLayoutItem3, DashboardLayoutItem4})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 14.916286149162861R
            DashboardLayoutItem5.DashboardItem = Me.ChartDashboardItem5
            DashboardLayoutItem5.Weight = 49.958847736625515R
            DashboardLayoutItem6.DashboardItem = Me.ChartDashboardItem3
            DashboardLayoutItem6.Weight = 50.041152263374485R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem5, DashboardLayoutItem6})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Weight = 55.18590998043053R
            DashboardLayoutItem7.DashboardItem = Me.ChartDashboardItem4
            DashboardLayoutItem7.Weight = 49.958847736625515R
            DashboardLayoutItem8.DashboardItem = Me.ChartDashboardItem2
            DashboardLayoutItem8.Weight = 50.041152263374485R
            DashboardLayoutGroup4.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem7, DashboardLayoutItem8})
            DashboardLayoutGroup4.DashboardItem = Nothing
            DashboardLayoutGroup4.Weight = 44.81409001956947R
            DashboardLayoutTabPage1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup3, DashboardLayoutGroup4})
            DashboardLayoutTabPage1.DashboardItem = Me.dashboardTabPage1
            DashboardLayoutTabPage1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutTabPage1.Weight = 100.0R
            DashboardLayoutItem9.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem9.Weight = 100.0R
            DashboardLayoutTabPage2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem9})
            DashboardLayoutTabPage2.DashboardItem = Me.DashboardTabPage2
            DashboardLayoutTabPage2.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutTabPage2.Weight = 100.0R
            DashboardLayoutItem10.DashboardItem = Me.CardDashboardItem1
            DashboardLayoutItem10.Weight = 49.902152641878672R
            DashboardLayoutItem11.DashboardItem = Me.ChartDashboardItem6
            DashboardLayoutItem11.Weight = 50.097847358121328R
            DashboardLayoutTabPage3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem10, DashboardLayoutItem11})
            DashboardLayoutTabPage3.DashboardItem = Me.DashboardTabPage3
            DashboardLayoutTabPage3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutTabPage3.Weight = 100.0R
            DashboardLayoutTabContainer1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutTabPage1, DashboardLayoutTabPage2, DashboardLayoutTabPage3})
            DashboardLayoutTabContainer1.DashboardItem = Me.TabContainerDashboardItem1
            DashboardLayoutTabContainer1.Weight = 85.083713850837142R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutTabContainer1})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard"
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabContainerDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dashboardTabPage1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardTabPage2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardTabPage3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents DateFilterDashboardItem1 As DevExpress.DashboardCommon.DateFilterDashboardItem
        Friend WithEvents ComboBoxDashboardItem1 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem2 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem3 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents DashboardTabPage2 As DevExpress.DashboardCommon.DashboardTabPage
        Friend WithEvents ChartDashboardItem2 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents dashboardTabPage1 As DevExpress.DashboardCommon.DashboardTabPage
        Friend WithEvents ChartDashboardItem3 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents ChartDashboardItem4 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents ChartDashboardItem5 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents TabContainerDashboardItem1 As DevExpress.DashboardCommon.TabContainerDashboardItem
        Friend WithEvents DashboardTabPage3 As DevExpress.DashboardCommon.DashboardTabPage
        Friend WithEvents ChartDashboardItem6 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents CardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem

#End Region
    End Class
End Namespace