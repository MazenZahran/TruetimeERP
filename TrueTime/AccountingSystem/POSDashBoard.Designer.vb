Namespace Win_Dashboards
    Partial Public Class POSDashBoard
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
            Dim SelectQuery2 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
            Dim Column3 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression3 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column4 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression4 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POSDashBoard))
            Dim Dimension1 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim DateTimePeriod1 As DevExpress.DashboardCommon.DateTimePeriod = New DevExpress.DashboardCommon.DateTimePeriod()
            Dim FlowDateTimePeriodLimit1 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim FlowDateTimePeriodLimit2 As DevExpress.DashboardCommon.FlowDateTimePeriodLimit = New DevExpress.DashboardCommon.FlowDateTimePeriodLimit()
            Dim Dimension2 As DevExpress.DashboardCommon.Dimension = New DevExpress.DashboardCommon.Dimension()
            Dim Measure1 As DevExpress.DashboardCommon.Measure = New DevExpress.DashboardCommon.Measure()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim SimpleSeries1 As DevExpress.DashboardCommon.SimpleSeries = New DevExpress.DashboardCommon.SimpleSeries()
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.DateFilterDashboardItem1 = New DevExpress.DashboardCommon.DateFilterDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            ColumnExpression3.ColumnName = "VoucherDateTime"
            Table2.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""403"" />"
            Table2.Name = "PosVouchers"
            ColumnExpression3.Table = Table2
            Column3.Expression = ColumnExpression3
            ColumnExpression4.ColumnName = "VoucherAmount"
            ColumnExpression4.Table = Table2
            Column4.Expression = ColumnExpression4
            SelectQuery2.Columns.Add(Column3)
            SelectQuery2.Columns.Add(Column4)
            SelectQuery2.Name = "PosVouchers"
            SelectQuery2.Tables.Add(Table2)
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery2})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'DateFilterDashboardItem1
            '
            Me.DateFilterDashboardItem1.ComponentName = "DateFilterDashboardItem1"
            Dimension1.DataMember = "VoucherDateTime"
            Dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHour
            Me.DateFilterDashboardItem1.DataItemRepository.Clear()
            Me.DateFilterDashboardItem1.DataItemRepository.Add(Dimension1, "DataItem0")
            Me.DateFilterDashboardItem1.DataMember = "PosVouchers"
            Me.DateFilterDashboardItem1.DataSource = Me.DashboardSqlDataSource1
            FlowDateTimePeriodLimit1.Interval = DevExpress.DashboardCommon.DateTimeInterval.Day
            FlowDateTimePeriodLimit1.Offset = 1
            DateTimePeriod1.End = FlowDateTimePeriodLimit1
            DateTimePeriod1.Name = "Today"
            FlowDateTimePeriodLimit2.Interval = DevExpress.DashboardCommon.DateTimeInterval.Day
            DateTimePeriod1.Start = FlowDateTimePeriodLimit2
            Me.DateFilterDashboardItem1.DateTimePeriods.AddRange(New DevExpress.DashboardCommon.DateTimePeriod() {DateTimePeriod1})
            Me.DateFilterDashboardItem1.Dimension = Dimension1
            Me.DateFilterDashboardItem1.Name = "Date Filter 1"
            Me.DateFilterDashboardItem1.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Dimension2.DataMember = "VoucherDateTime"
            Dimension2.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.DateHour
            Me.ChartDashboardItem1.Arguments.AddRange(New DevExpress.DashboardCommon.Dimension() {Dimension2})
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Measure1.DataMember = "VoucherAmount"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.DataItemRepository.Add(Measure1, "DataItem0")
            Me.ChartDashboardItem1.DataItemRepository.Add(Dimension2, "DataItem1")
            Me.ChartDashboardItem1.DataMember = "PosVouchers"
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
            ChartPane1.Series.AddRange(New DevExpress.DashboardCommon.ChartSeries() {SimpleSeries1})
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'POSDashBoard
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.DateFilterDashboardItem1, Me.ChartDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.DateFilterDashboardItem1
            DashboardLayoutItem1.Weight = 12.238805970149254R
            DashboardLayoutItem2.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem2.Weight = 87.761194029850742R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard"
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateFilterDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Dimension2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Measure1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents DateFilterDashboardItem1 As DevExpress.DashboardCommon.DateFilterDashboardItem
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem

#End Region
    End Class
End Namespace