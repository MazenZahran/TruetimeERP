Namespace Win_Dashboards
    Partial Public Class DashboardSalaries
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
            Dim Column8 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression8 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column9 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression9 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column10 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression10 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column11 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression11 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column12 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression12 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column13 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression13 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column14 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression14 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column15 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression15 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column16 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression16 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column17 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression17 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column18 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression18 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column19 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression19 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column20 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression20 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column21 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression21 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column22 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression22 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column23 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression23 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column24 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression24 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column25 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression25 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Column26 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression26 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DashboardSalaries))
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension3 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension4 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension5 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure2 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure3 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure4 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure5 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure6 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure7 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries2 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries3 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries4 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries5 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries6 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim SimpleSeries7 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim Dimension6 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure8 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure9 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure10 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure11 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure12 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure13 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure14 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Dimension7 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure15 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure16 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure17 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure18 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure19 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure20 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure21 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure22 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Measure23 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card1 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate1 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Measure24 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card2 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate2 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Measure25 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card3 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate3 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Measure26 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card4 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate4 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Measure27 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card5 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate5 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Measure28 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim Card6 As DevExpress.DashboardCommon.Card = New DevExpress.DashboardCommon.Card()
            Dim CardStretchedLayoutTemplate6 As DevExpress.DashboardCommon.CardStretchedLayoutTemplate = New DevExpress.DashboardCommon.CardStretchedLayoutTemplate()
            Dim Dimension8 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Dimension9 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem4 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup3 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup4 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem5 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem6 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutGroup5 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem7 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem8 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DateFilterDashboardItem1 = New DevExpress.DashboardCommon.DateFilterDashboardItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.ComboBoxDashboardItem2 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem1 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ComboBoxDashboardItem3 = New DevExpress.DashboardCommon.ComboBoxDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.PieDashboardItem1 = New DevExpress.DashboardCommon.PieDashboardItem()
            Me.TreemapDashboardItem1 = New DevExpress.DashboardCommon.TreemapDashboardItem()
            Me.CardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure10, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure11, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure12, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure13, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure14, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TreemapDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure15, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure16, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure17, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure18, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure19, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure20, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure21, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure22, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure23, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure24, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure25, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure26, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure27, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure28, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DateFilterDashboardItem1
            '
            Me.DateFilterDashboardItem1.ComponentName = "DateFilterDashboardItem1"
            Dimension1.DataMember = "DateTo"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.DateFilterDashboardItem1.DataItemRepository.Clear()
            Me.DateFilterDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.DateFilterDashboardItem1.DataMember = "AttRawatebArchive"
            Me.DateFilterDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            FlowDateTimePeriodLimit1.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod1.End = FlowDateTimePeriodLimit1
            DateTimePeriod1.Name = "Last Month"
            FlowDateTimePeriodLimit2.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit2.Offset = -1
            DateTimePeriod1.Start = FlowDateTimePeriodLimit2
            DateTimePeriod2.End = FlowDateTimePeriodLimit3
            DateTimePeriod2.Name = "Last Year"
            FlowDateTimePeriodLimit4.Offset = -1
            DateTimePeriod2.Start = FlowDateTimePeriodLimit4
            FlowDateTimePeriodLimit5.Offset = 1
            DateTimePeriod3.End = FlowDateTimePeriodLimit5
            DateTimePeriod3.Name = "This Year"
            DateTimePeriod3.Start = FlowDateTimePeriodLimit6
            FlowDateTimePeriodLimit7.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            FlowDateTimePeriodLimit7.Offset = 1
            DateTimePeriod4.End = FlowDateTimePeriodLimit7
            DateTimePeriod4.Name = "This Month"
            FlowDateTimePeriodLimit8.Interval = DevExpress.DashboardCommon.DateTimeInterval.Month
            DateTimePeriod4.Start = FlowDateTimePeriodLimit8
            Me.DateFilterDashboardItem1.DateTimePeriods.AddRange(New DevExpress.DashboardCommon.DateTimePeriod() {DateTimePeriod1, DateTimePeriod2, DateTimePeriod3, DateTimePeriod4})
            Me.DateFilterDashboardItem1.Dimension = Dimension1
            Me.DateFilterDashboardItem1.Name = "Date Filter 1"
            Me.DateFilterDashboardItem1.ShowCaption = True
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            ColumnExpression1.ColumnName = "ID"
            Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""220"" Height=""943"" />"
            Table1.Name = "AttRawatebArchive"
            ColumnExpression1.Table = Table1
            Column1.Expression = ColumnExpression1
            ColumnExpression2.ColumnName = "EmployeeID"
            ColumnExpression2.Table = Table1
            Column2.Expression = ColumnExpression2
            ColumnExpression3.ColumnName = "EmployeeNoAsAcc"
            ColumnExpression3.Table = Table1
            Column3.Expression = ColumnExpression3
            ColumnExpression4.ColumnName = "EmployeeName"
            ColumnExpression4.Table = Table1
            Column4.Expression = ColumnExpression4
            ColumnExpression5.ColumnName = "Branch"
            ColumnExpression5.Table = Table1
            Column5.Expression = ColumnExpression5
            ColumnExpression6.ColumnName = "JobName"
            ColumnExpression6.Table = Table1
            Column6.Expression = ColumnExpression6
            ColumnExpression7.ColumnName = "BeginDate"
            ColumnExpression7.Table = Table1
            Column7.Expression = ColumnExpression7
            ColumnExpression8.ColumnName = "SalaryMonth"
            ColumnExpression8.Table = Table1
            Column8.Expression = ColumnExpression8
            ColumnExpression9.ColumnName = "Department"
            ColumnExpression9.Table = Table1
            Column9.Expression = ColumnExpression9
            ColumnExpression10.ColumnName = "BonusAmount"
            ColumnExpression10.Table = Table1
            Column10.Expression = ColumnExpression10
            ColumnExpression11.ColumnName = "Transport"
            ColumnExpression11.Table = Table1
            Column11.Expression = ColumnExpression11
            ColumnExpression12.ColumnName = "Additions"
            ColumnExpression12.Table = Table1
            Column12.Expression = ColumnExpression12
            ColumnExpression13.ColumnName = "LeavesAmount"
            ColumnExpression13.Table = Table1
            Column13.Expression = ColumnExpression13
            ColumnExpression14.ColumnName = "Payment"
            ColumnExpression14.Table = Table1
            Column14.Expression = ColumnExpression14
            ColumnExpression15.ColumnName = "GrossSalary"
            ColumnExpression15.Table = Table1
            Column15.Expression = ColumnExpression15
            ColumnExpression16.ColumnName = "MonthDays"
            ColumnExpression16.Table = Table1
            Column16.Expression = ColumnExpression16
            ColumnExpression17.ColumnName = "ActualDays"
            ColumnExpression17.Table = Table1
            Column17.Expression = ColumnExpression17
            ColumnExpression18.ColumnName = "AbsenceDays"
            ColumnExpression18.Table = Table1
            Column18.Expression = ColumnExpression18
            ColumnExpression19.ColumnName = "HouresRequired"
            ColumnExpression19.Table = Table1
            Column19.Expression = ColumnExpression19
            ColumnExpression20.ColumnName = "ActualHoures"
            ColumnExpression20.Table = Table1
            Column20.Expression = ColumnExpression20
            ColumnExpression21.ColumnName = "NetSalary"
            ColumnExpression21.Table = Table1
            Column21.Expression = ColumnExpression21
            ColumnExpression22.ColumnName = "DateFrom"
            ColumnExpression22.Table = Table1
            Column22.Expression = ColumnExpression22
            ColumnExpression23.ColumnName = "DateTo"
            ColumnExpression23.Table = Table1
            Column23.Expression = ColumnExpression23
            ColumnExpression24.ColumnName = "HouresNetBonus"
            ColumnExpression24.Table = Table1
            Column24.Expression = ColumnExpression24
            ColumnExpression25.ColumnName = "HouresNetLeaves"
            ColumnExpression25.Table = Table1
            Column25.Expression = ColumnExpression25
            ColumnExpression26.ColumnName = "VocationDays"
            ColumnExpression26.Table = Table1
            Column26.Expression = ColumnExpression26
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
            SelectQuery1.Columns.Add(Column23)
            SelectQuery1.Columns.Add(Column24)
            SelectQuery1.Columns.Add(Column25)
            SelectQuery1.Columns.Add(Column26)
            SelectQuery1.Name = "AttRawatebArchive"
            SelectQuery1.Tables.Add(Table1)
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'ComboBoxDashboardItem2
            '
            Me.ComboBoxDashboardItem2.ComponentName = "ComboBoxDashboardItem2"
            Dimension2.DataMember = "Branch"
            Me.ComboBoxDashboardItem2.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem2.DataItemRepository.Add(Dimension2, "DataItem0")
            Me.ComboBoxDashboardItem2.DataMember = "AttRawatebArchive"
            Me.ComboBoxDashboardItem2.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem2.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.ComboBoxDashboardItem2.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem2.Name = "الفرع"
            Me.ComboBoxDashboardItem2.ShowCaption = True
            '
            'ComboBoxDashboardItem1
            '
            Me.ComboBoxDashboardItem1.ComponentName = "ComboBoxDashboardItem1"
            Dimension3.DataMember = "Department"
            Me.ComboBoxDashboardItem1.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem1.DataItemRepository.Add(Dimension3, "DataItem0")
            Me.ComboBoxDashboardItem1.DataMember = "AttRawatebArchive"
            Me.ComboBoxDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem1.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension3})
            Me.ComboBoxDashboardItem1.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem1.Name = "الدائرة"
            Me.ComboBoxDashboardItem1.ShowCaption = True
            '
            'ComboBoxDashboardItem3
            '
            Me.ComboBoxDashboardItem3.ComponentName = "ComboBoxDashboardItem3"
            Dimension4.DataMember = "JobName"
            Me.ComboBoxDashboardItem3.DataItemRepository.Clear()
            Me.ComboBoxDashboardItem3.DataItemRepository.Add(Dimension4, "DataItem0")
            Me.ComboBoxDashboardItem3.DataMember = "AttRawatebArchive"
            Me.ComboBoxDashboardItem3.DataSource = Me.DashboardSqlDataSource1
            Me.ComboBoxDashboardItem3.FilterDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension4})
            Me.ComboBoxDashboardItem3.InteractivityOptions.IgnoreMasterFilters = True
            Me.ComboBoxDashboardItem3.Name = "الوظيفة"
            Me.ComboBoxDashboardItem3.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Dimension5.DataMember = "Branch"
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension5})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure1.DataMember = "NetSalary"
            Measure2.DataMember = "LeavesAmount"
            Measure3.DataMember = "Additions"
            Measure4.DataMember = "BonusAmount"
            Measure5.DataMember = "Payment"
            Measure6.DataMember = "SalaryMonth"
            Measure7.DataMember = "Transport"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension5, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem1")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure2, "DataItem2")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure3, "DataItem3")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure4, "DataItem4")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure5, "DataItem5")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure6, "DataItem6")
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure7, "DataItem7")
            Me.ChartDashboardItem1.DataMember = "AttRawatebArchive"
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
            SimpleSeries1.AddDataItem("Value", Measure1)
            SimpleSeries2.AddDataItem("Value", Measure2)
            SimpleSeries3.AddDataItem("Value", Measure3)
            SimpleSeries4.AddDataItem("Value", Measure4)
            SimpleSeries5.AddDataItem("Value", Measure5)
            SimpleSeries6.AddDataItem("Value", Measure6)
            SimpleSeries7.AddDataItem("Value", Measure7)
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1, SimpleSeries2, SimpleSeries3, SimpleSeries4, SimpleSeries5, SimpleSeries6, SimpleSeries7})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'PieDashboardItem1
            '
            Dimension6.DataMember = "Branch"
            Me.PieDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension6})
            Me.PieDashboardItem1.ComponentName = "PieDashboardItem1"
            Measure8.DataMember = "SalaryMonth"
            Measure9.DataMember = "Transport"
            Measure10.DataMember = "Payment"
            Measure11.DataMember = "LeavesAmount"
            Measure12.DataMember = "Additions"
            Measure13.DataMember = "BonusAmount"
            Measure14.DataMember = "VocationDays"
            Me.PieDashboardItem1.DataItemRepository.Clear()
            Me.PieDashboardItem1.DataItemRepository.Add(Measure8, "DataItem2")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure9, "DataItem5")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure10, "DataItem4")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure11, "DataItem3")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure12, "DataItem1")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure13, "DataItem0")
            Me.PieDashboardItem1.DataItemRepository.Add(Measure14, "DataItem6")
            Me.PieDashboardItem1.DataItemRepository.Add(Dimension6, "DataItem7")
            Me.PieDashboardItem1.DataMember = "AttRawatebArchive"
            Me.PieDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.PieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.PieDashboardItem1.Name = "Pies 1"
            Me.PieDashboardItem1.ShowCaption = True
            Me.PieDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure12, Measure13, Measure8, Measure11, Measure10, Measure9, Measure14})
            '
            'TreemapDashboardItem1
            '
            Dimension7.DataMember = "Branch"
            Me.TreemapDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension7})
            Me.TreemapDashboardItem1.ComponentName = "TreemapDashboardItem1"
            Measure15.DataMember = "BonusAmount"
            Measure16.DataMember = "Additions"
            Measure17.DataMember = "LeavesAmount"
            Measure18.DataMember = "NetSalary"
            Measure19.DataMember = "Payment"
            Measure20.DataMember = "SalaryMonth"
            Measure21.DataMember = "Transport"
            Measure22.DataMember = "VocationDays"
            Me.TreemapDashboardItem1.DataItemRepository.Clear()
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure15, "DataItem0")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Dimension7, "DataItem1")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure16, "DataItem2")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure17, "DataItem3")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure18, "DataItem4")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure19, "DataItem5")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure20, "DataItem6")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure21, "DataItem7")
            Me.TreemapDashboardItem1.DataItemRepository.Add(Measure22, "DataItem8")
            Me.TreemapDashboardItem1.DataMember = "AttRawatebArchive"
            Me.TreemapDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.TreemapDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.TreemapDashboardItem1.Name = "Treemap 1"
            Me.TreemapDashboardItem1.ShowCaption = True
            Me.TreemapDashboardItem1.Values.AddRange(New DevExpress.DashboardCommon.Measure() {Measure15, Measure16, Measure17, Measure18, Measure19, Measure20, Measure21, Measure22})
            '
            'CardDashboardItem1
            '
            Measure23.DataMember = "Transport"
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
            Card1.AddDataItem("ActualValue", Measure23)
            Measure24.DataMember = "SalaryMonth"
            CardStretchedLayoutTemplate2.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate2.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate2.BottomValue1.Visible = True
            CardStretchedLayoutTemplate2.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate2.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate2.BottomValue2.Visible = True
            CardStretchedLayoutTemplate2.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate2.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate2.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate2.MainValue.Visible = True
            CardStretchedLayoutTemplate2.Sparkline.Visible = True
            CardStretchedLayoutTemplate2.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate2.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate2.SubValue.Visible = True
            CardStretchedLayoutTemplate2.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate2.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate2.TopValue.Visible = True
            Card2.LayoutTemplate = CardStretchedLayoutTemplate2
            Card2.AddDataItem("ActualValue", Measure24)
            Measure25.DataMember = "NetSalary"
            CardStretchedLayoutTemplate3.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate3.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate3.BottomValue1.Visible = True
            CardStretchedLayoutTemplate3.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate3.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate3.BottomValue2.Visible = True
            CardStretchedLayoutTemplate3.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate3.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate3.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate3.MainValue.Visible = True
            CardStretchedLayoutTemplate3.Sparkline.Visible = True
            CardStretchedLayoutTemplate3.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate3.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate3.SubValue.Visible = True
            CardStretchedLayoutTemplate3.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate3.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate3.TopValue.Visible = True
            Card3.LayoutTemplate = CardStretchedLayoutTemplate3
            Card3.AddDataItem("ActualValue", Measure25)
            Measure26.DataMember = "LeavesAmount"
            CardStretchedLayoutTemplate4.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate4.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate4.BottomValue1.Visible = True
            CardStretchedLayoutTemplate4.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate4.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate4.BottomValue2.Visible = True
            CardStretchedLayoutTemplate4.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate4.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate4.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate4.MainValue.Visible = True
            CardStretchedLayoutTemplate4.Sparkline.Visible = True
            CardStretchedLayoutTemplate4.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate4.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate4.SubValue.Visible = True
            CardStretchedLayoutTemplate4.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate4.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate4.TopValue.Visible = True
            Card4.LayoutTemplate = CardStretchedLayoutTemplate4
            Card4.AddDataItem("ActualValue", Measure26)
            Measure27.DataMember = "BonusAmount"
            CardStretchedLayoutTemplate5.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate5.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate5.BottomValue1.Visible = True
            CardStretchedLayoutTemplate5.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate5.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate5.BottomValue2.Visible = True
            CardStretchedLayoutTemplate5.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate5.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate5.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate5.MainValue.Visible = True
            CardStretchedLayoutTemplate5.Sparkline.Visible = True
            CardStretchedLayoutTemplate5.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate5.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate5.SubValue.Visible = True
            CardStretchedLayoutTemplate5.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate5.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate5.TopValue.Visible = True
            Card5.LayoutTemplate = CardStretchedLayoutTemplate5
            Card5.AddDataItem("ActualValue", Measure27)
            Measure28.DataMember = "Additions"
            CardStretchedLayoutTemplate6.BottomValue1.DimensionIndex = 0
            CardStretchedLayoutTemplate6.BottomValue1.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.PercentVariation
            CardStretchedLayoutTemplate6.BottomValue1.Visible = True
            CardStretchedLayoutTemplate6.BottomValue2.DimensionIndex = 0
            CardStretchedLayoutTemplate6.BottomValue2.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.AbsoluteVariation
            CardStretchedLayoutTemplate6.BottomValue2.Visible = True
            CardStretchedLayoutTemplate6.DeltaIndicator.Visible = True
            CardStretchedLayoutTemplate6.MainValue.DimensionIndex = 0
            CardStretchedLayoutTemplate6.MainValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Title
            CardStretchedLayoutTemplate6.MainValue.Visible = True
            CardStretchedLayoutTemplate6.Sparkline.Visible = True
            CardStretchedLayoutTemplate6.SubValue.DimensionIndex = 0
            CardStretchedLayoutTemplate6.SubValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.Subtitle
            CardStretchedLayoutTemplate6.SubValue.Visible = True
            CardStretchedLayoutTemplate6.TopValue.DimensionIndex = 0
            CardStretchedLayoutTemplate6.TopValue.ValueType = DevExpress.DashboardCommon.CardRowDataElementType.ActualValue
            CardStretchedLayoutTemplate6.TopValue.Visible = True
            Card6.LayoutTemplate = CardStretchedLayoutTemplate6
            Card6.AddDataItem("ActualValue", Measure28)
            Me.CardDashboardItem1.Cards.AddRange(New DevExpress.DashboardCommon.Card() {Card1, Card2, Card3, Card4, Card5, Card6})
            Me.CardDashboardItem1.ComponentName = "CardDashboardItem1"
            Dimension8.DataMember = "Branch"
            Dimension9.DataMember = "DateTo"
            Dimension9.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear
            Me.CardDashboardItem1.DataItemRepository.Clear()
            Me.CardDashboardItem1.DataItemRepository.Add(Measure23, "DataItem0")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure24, "DataItem1")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure25, "DataItem2")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure26, "DataItem3")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure27, "DataItem4")
            Me.CardDashboardItem1.DataItemRepository.Add(Measure28, "DataItem5")
            Me.CardDashboardItem1.DataItemRepository.Add(Dimension8, "DataItem6")
            Me.CardDashboardItem1.DataItemRepository.Add(Dimension9, "DataItem7")
            Me.CardDashboardItem1.DataMember = "AttRawatebArchive"
            Me.CardDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            Me.CardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.CardDashboardItem1.Name = "Cards 1"
            Me.CardDashboardItem1.SeriesDimensions.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension8})
            Me.CardDashboardItem1.ShowCaption = True
            Me.CardDashboardItem1.SparklineArgument = Dimension9
            '
            'DashboardSalaries
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.PieDashboardItem1, Me.ComboBoxDashboardItem1, Me.ComboBoxDashboardItem2, Me.ComboBoxDashboardItem3, Me.ChartDashboardItem1, Me.DateFilterDashboardItem1, Me.TreemapDashboardItem1, Me.CardDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.DateFilterDashboardItem1
            DashboardLayoutItem1.Weight = 41.337630942788074R
            DashboardLayoutItem2.DashboardItem = Me.ComboBoxDashboardItem2
            DashboardLayoutItem2.Weight = 19.903303787268332R
            DashboardLayoutItem3.DashboardItem = Me.ComboBoxDashboardItem1
            DashboardLayoutItem3.Weight = 18.372280419016921R
            DashboardLayoutItem4.DashboardItem = Me.ComboBoxDashboardItem3
            DashboardLayoutItem4.Weight = 20.386784850926674R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2, DashboardLayoutItem3, DashboardLayoutItem4})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 12.752721617418352R
            DashboardLayoutItem5.DashboardItem = Me.CardDashboardItem1
            DashboardLayoutItem5.Weight = 49.959709911361806R
            DashboardLayoutItem6.DashboardItem = Me.TreemapDashboardItem1
            DashboardLayoutItem6.Weight = 50.040290088638194R
            DashboardLayoutGroup4.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem5, DashboardLayoutItem6})
            DashboardLayoutGroup4.DashboardItem = Nothing
            DashboardLayoutGroup4.Weight = 38.146167557932266R
            DashboardLayoutItem7.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem7.Weight = 49.959709911361806R
            DashboardLayoutItem8.DashboardItem = Me.PieDashboardItem1
            DashboardLayoutItem8.Weight = 50.040290088638194R
            DashboardLayoutGroup5.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem7, DashboardLayoutItem8})
            DashboardLayoutGroup5.DashboardItem = Nothing
            DashboardLayoutGroup5.Weight = 61.853832442067734R
            DashboardLayoutGroup3.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup4, DashboardLayoutGroup5})
            DashboardLayoutGroup3.DashboardItem = Nothing
            DashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup3.Weight = 87.247278382581655R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutGroup3})
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
            CType(Me.ComboBoxDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboBoxDashboardItem3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure10, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure11, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure12, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure13, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure14, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PieDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure15, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure16, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure17, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure18, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure19, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure20, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure21, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure22, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TreemapDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure23, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure24, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure25, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure26, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure27, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure28, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents PieDashboardItem1 As DevExpress.DashboardCommon.PieDashboardItem
        Friend WithEvents ComboBoxDashboardItem1 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem2 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ComboBoxDashboardItem3 As DevExpress.DashboardCommon.ComboBoxDashboardItem
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents DateFilterDashboardItem1 As DevExpress.DashboardCommon.DateFilterDashboardItem
        Friend WithEvents TreemapDashboardItem1 As DevExpress.DashboardCommon.TreemapDashboardItem
        Friend WithEvents CardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem

#End Region
    End Class
End Namespace