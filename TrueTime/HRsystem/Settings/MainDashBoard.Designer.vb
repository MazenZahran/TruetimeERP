<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainDashBoard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainDashBoard))
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemFrame1 As DevExpress.XtraEditors.TileItemFrame = New DevExpress.XtraEditors.TileItemFrame()
        Dim TileItemElement5 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemFrame2 As DevExpress.XtraEditors.TileItemFrame = New DevExpress.XtraEditors.TileItemFrame()
        Dim TileItemElement6 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem1 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem2 = New DevExpress.XtraEditors.TileItem()
        Me.TileItem3 = New DevExpress.XtraEditors.TileItem()
        Me.TileGroup3 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItem4 = New DevExpress.XtraEditors.TileItem()
        Me.SuspendLayout()
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionName = "TrueTime.My.MySettings.TrueTimeConnectionString"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        ColumnExpression1.ColumnName = "EmployeeID"
        Table1.MetaSerializable = "<Meta X=""30"" Y=""30"" Width=""125"" Height=""875"" />"
        Table1.Name = "EmployeesData"
        ColumnExpression1.Table = Table1
        Column1.Expression = ColumnExpression1
        ColumnExpression2.ColumnName = "EmployeeName"
        ColumnExpression2.Table = Table1
        Column2.Expression = ColumnExpression2
        ColumnExpression3.ColumnName = "Address"
        ColumnExpression3.Table = Table1
        Column3.Expression = ColumnExpression3
        ColumnExpression4.ColumnName = "City"
        ColumnExpression4.Table = Table1
        Column4.Expression = ColumnExpression4
        ColumnExpression5.ColumnName = "DriverLicence"
        ColumnExpression5.Table = Table1
        Column5.Expression = ColumnExpression5
        ColumnExpression6.ColumnName = "Mobile1"
        ColumnExpression6.Table = Table1
        Column6.Expression = ColumnExpression6
        ColumnExpression7.ColumnName = "Department"
        ColumnExpression7.Table = Table1
        Column7.Expression = ColumnExpression7
        ColumnExpression8.ColumnName = "JobName"
        ColumnExpression8.Table = Table1
        Column8.Expression = ColumnExpression8
        ColumnExpression9.ColumnName = "Branch"
        ColumnExpression9.Table = Table1
        Column9.Expression = ColumnExpression9
        ColumnExpression10.ColumnName = "DateOfStart"
        ColumnExpression10.Table = Table1
        Column10.Expression = ColumnExpression10
        ColumnExpression11.ColumnName = "Active"
        ColumnExpression11.Table = Table1
        Column11.Expression = ColumnExpression11
        ColumnExpression12.ColumnName = "PictureEmp"
        ColumnExpression12.Table = Table1
        Column12.Expression = ColumnExpression12
        ColumnExpression13.ColumnName = "Gender"
        ColumnExpression13.Table = Table1
        Column13.Expression = ColumnExpression13
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
        SelectQuery1.Name = "EmployeesData"
        SelectQuery1.Tables.Add(Table1)
        Me.SqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {SelectQuery1})
        Me.SqlDataSource1.ResultSchemaSerializable = resources.GetString("SqlDataSource1.ResultSchemaSerializable")
        '
        'TileControl1
        '
        resources.ApplyResources(Me.TileControl1, "TileControl1")
        Me.TileControl1.AppearanceItem.Hovered.Font = CType(resources.GetObject("TileControl1.AppearanceItem.Hovered.Font"), System.Drawing.Font)
        Me.TileControl1.AppearanceItem.Hovered.Options.UseFont = True
        Me.TileControl1.AppearanceItem.Normal.Font = CType(resources.GetObject("TileControl1.AppearanceItem.Normal.Font"), System.Drawing.Font)
        Me.TileControl1.AppearanceItem.Normal.Options.UseFont = True
        Me.TileControl1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TileControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TileControl1.Groups.Add(Me.TileGroup2)
        Me.TileControl1.Groups.Add(Me.TileGroup3)
        Me.TileControl1.ItemSize = 150
        Me.TileControl1.MaxId = 12
        Me.TileControl1.Name = "TileControl1"
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileItem1)
        Me.TileGroup2.Items.Add(Me.TileItem2)
        Me.TileGroup2.Items.Add(Me.TileItem3)
        Me.TileGroup2.Name = "TileGroup2"
        resources.ApplyResources(Me.TileGroup2, "TileGroup2")
        '
        'TileItem1
        '
        resources.ApplyResources(Me.TileItem1, "TileItem1")
        Me.TileItem1.AppearanceItem.Hovered.Font = CType(resources.GetObject("TileItem1.AppearanceItem.Hovered.Font"), System.Drawing.Font)
        Me.TileItem1.AppearanceItem.Hovered.Options.UseFont = True
        Me.TileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.RoyalBlue
        Me.TileItem1.AppearanceItem.Normal.Font = CType(resources.GetObject("TileItem1.AppearanceItem.Normal.Font"), System.Drawing.Font)
        Me.TileItem1.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileItem1.AppearanceItem.Normal.Options.UseFont = True
        Me.TileItem1.BackgroundImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch
        TileItemElement1.ImageOptions.Image = CType(resources.GetObject("resource.Image"), System.Drawing.Image)
        TileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top
        resources.ApplyResources(TileItemElement1, "TileItemElement1")
        Me.TileItem1.Elements.Add(TileItemElement1)
        Me.TileItem1.Id = 0
        Me.TileItem1.Name = "TileItem1"
        '
        'TileItem2
        '
        resources.ApplyResources(Me.TileItem2, "TileItem2")
        Me.TileItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.Salmon
        Me.TileItem2.AppearanceItem.Normal.Options.UseBackColor = True
        TileItemElement2.ImageOptions.Image = CType(resources.GetObject("resource.Image1"), System.Drawing.Image)
        TileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        resources.ApplyResources(TileItemElement2, "TileItemElement2")
        Me.TileItem2.Elements.Add(TileItemElement2)
        Me.TileItem2.Id = 1
        Me.TileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
        Me.TileItem2.Name = "TileItem2"
        '
        'TileItem3
        '
        resources.ApplyResources(Me.TileItem3, "TileItem3")
        TileItemElement3.ImageOptions.Image = CType(resources.GetObject("resource.Image2"), System.Drawing.Image)
        TileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter
        resources.ApplyResources(TileItemElement3, "TileItemElement3")
        Me.TileItem3.Elements.Add(TileItemElement3)
        Me.TileItem3.Id = 5
        Me.TileItem3.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItem3.Name = "TileItem3"
        '
        'TileGroup3
        '
        Me.TileGroup3.Items.Add(Me.TileItem4)
        Me.TileGroup3.Name = "TileGroup3"
        resources.ApplyResources(Me.TileGroup3, "TileGroup3")
        '
        'TileItem4
        '
        resources.ApplyResources(Me.TileItem4, "TileItem4")
        Me.TileItem4.BackgroundImage = CType(resources.GetObject("TileItem4.BackgroundImage"), System.Drawing.Image)
        TileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        resources.ApplyResources(TileItemElement4, "TileItemElement4")
        Me.TileItem4.Elements.Add(TileItemElement4)
        TileItemFrame1.Animation = DevExpress.XtraEditors.TileItemContentAnimationType.ScrollDown
        TileItemFrame1.Appearance.BackColor = System.Drawing.Color.LightSeaGreen
        TileItemFrame1.Appearance.Options.UseBackColor = True
        TileItemFrame1.BackgroundImage = CType(resources.GetObject("TileItemFrame1.BackgroundImage"), System.Drawing.Image)
        TileItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        resources.ApplyResources(TileItemElement5, "TileItemElement5")
        TileItemFrame1.Elements.Add(TileItemElement5)
        TileItemFrame2.Appearance.BackColor = System.Drawing.Color.Blue
        TileItemFrame2.Appearance.Options.UseBackColor = True
        TileItemFrame2.BackgroundImage = CType(resources.GetObject("TileItemFrame2.BackgroundImage"), System.Drawing.Image)
        TileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        resources.ApplyResources(TileItemElement6, "TileItemElement6")
        TileItemFrame2.Elements.Add(TileItemElement6)
        Me.TileItem4.Frames.Add(TileItemFrame1)
        Me.TileItem4.Frames.Add(TileItemFrame2)
        Me.TileItem4.Id = 11
        Me.TileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Large
        Me.TileItem4.Name = "TileItem4"
        '
        'MainDashBoard
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TileControl1)
        Me.Name = "MainDashBoard"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem1 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem2 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItem3 As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileGroup3 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItem4 As DevExpress.XtraEditors.TileItem
End Class
