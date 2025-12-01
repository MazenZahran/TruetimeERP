Namespace Win_Dashboards
    Partial Public Class Dashboard6
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
            Dim SelectQuery1 As DevExpress.DataAccess.Sql.SelectQuery = New DevExpress.DataAccess.Sql.SelectQuery()
            Dim Column1 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression1 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table1 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Column2 As DevExpress.DataAccess.Sql.Column = New DevExpress.DataAccess.Sql.Column()
            Dim ColumnExpression2 As DevExpress.DataAccess.Sql.ColumnExpression = New DevExpress.DataAccess.Sql.ColumnExpression()
            Dim Table2 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Join1 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo1 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim Table3 As DevExpress.DataAccess.Sql.Table = New DevExpress.DataAccess.Sql.Table()
            Dim Join2 As DevExpress.DataAccess.Sql.Join = New DevExpress.DataAccess.Sql.Join()
            Dim RelationColumnInfo2 As DevExpress.DataAccess.Sql.RelationColumnInfo = New DevExpress.DataAccess.Sql.RelationColumnInfo()
            Dim CustomShapefileData1 As DevExpress.DashboardCommon.CustomShapefileData = New DevExpress.DashboardCommon.CustomShapefileData()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard6))
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.GeoPointMapDashboardItem1 = New DevExpress.DashboardCommon.GeoPointMapDashboardItem()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GeoPointMapDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueAccountingConnectionString"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            ColumnExpression1.ColumnName = "CITY"
            Table1.MetaSerializable = "<Meta X=""340"" Y=""30"" Width=""125"" Height=""104"" />"
            Table1.Name = "RefCities"
            ColumnExpression1.Table = Table1
            Column1.Expression = ColumnExpression1
            ColumnExpression2.ColumnName = "DocAmount"
            Table2.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""1364"" />"
            Table2.Name = "Journal"
            ColumnExpression2.Table = Table2
            Column2.Expression = ColumnExpression2
            SelectQuery1.Columns.Add(Column1)
            SelectQuery1.Columns.Add(Column2)
            SelectQuery1.Name = "Journal"
            RelationColumnInfo1.NestedKeyColumn = "RefNo"
            RelationColumnInfo1.ParentKeyColumn = "Referance"
            Join1.KeyColumns.Add(RelationColumnInfo1)
            Table3.MetaSerializable = "<Meta X=""185"" Y=""30"" Width=""125"" Height=""404"" />"
            Table3.Name = "Referencess"
            Join1.Nested = Table3
            Join1.Parent = Table2
            RelationColumnInfo2.NestedKeyColumn = "ID"
            RelationColumnInfo2.ParentKeyColumn = "SearchCity"
            Join2.KeyColumns.Add(RelationColumnInfo2)
            Join2.Nested = Table1
            Join2.Parent = Table3
            SelectQuery1.Relations.Add(Join1)
            SelectQuery1.Relations.Add(Join2)
            SelectQuery1.Tables.Add(Table2)
            SelectQuery1.Tables.Add(Table3)
            SelectQuery1.Tables.Add(Table1)
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0iU1FMIERhdGEgU291cmNlIDEiPjxWaWV3IE5hbWU9IkpvdXJuYWwiPjxGaWVsZ" &
    "CBOYW1lPSJDSVRZIiBUeXBlPSJTdHJpbmciIC8+PEZpZWxkIE5hbWU9IkRvY0Ftb3VudCIgVHlwZT0iR" &
    "G91YmxlIiAvPjwvVmlldz48L0RhdGFTZXQ+"
            '
            'GeoPointMapDashboardItem1
            '
            Me.GeoPointMapDashboardItem1.Area = DevExpress.DashboardCommon.ShapefileArea.Custom
            Me.GeoPointMapDashboardItem1.ComponentName = "GeoPointMapDashboardItem1"
            CustomShapefileData1.AttributeDataSerializable = resources.GetString("CustomShapefileData1.AttributeDataSerializable")
            CustomShapefileData1.ShapeDataSerializable = resources.GetString("CustomShapefileData1.ShapeDataSerializable")
            Me.GeoPointMapDashboardItem1.CustomShapefile.Data = CustomShapefileData1
            Me.GeoPointMapDashboardItem1.DataItemRepository.Clear()
            Me.GeoPointMapDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.GeoPointMapDashboardItem1.Name = "Map 1"
            Me.GeoPointMapDashboardItem1.ShowCaption = True
            Me.GeoPointMapDashboardItem1.Viewport.BottomLatitude = 30.219007880216996R
            Me.GeoPointMapDashboardItem1.Viewport.CenterPointLatitude = 31.254460530262811R
            Me.GeoPointMapDashboardItem1.Viewport.CenterPointLongitude = 35.2495236858388R
            Me.GeoPointMapDashboardItem1.Viewport.CreateViewerPaddings = False
            Me.GeoPointMapDashboardItem1.Viewport.LeftLongitude = 33.255400129302608R
            Me.GeoPointMapDashboardItem1.Viewport.RightLongitude = 37.24364724237504R
            Me.GeoPointMapDashboardItem1.Viewport.TopLatitude = 32.278679522030373R
            '
            'Dashboard6
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.GeoPointMapDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.GeoPointMapDashboardItem1
            DashboardLayoutItem1.Weight = 100.0R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard"
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GeoPointMapDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents GeoPointMapDashboardItem1 As DevExpress.DashboardCommon.GeoPointMapDashboardItem

#End Region
    End Class
End Namespace