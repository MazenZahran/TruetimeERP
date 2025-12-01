<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AttGetMap
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttGetMap))
        Me.meResult = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.mapControl = New DevExpress.XtraMap.MapControl()
        Me.imageLayer = New DevExpress.XtraMap.ImageLayer()
        Me.imageProvider = New DevExpress.XtraMap.BingMapDataProvider()
        Me.informationLayer = New DevExpress.XtraMap.InformationLayer()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.teLongitude = New DevExpress.XtraEditors.TextEdit()
        Me.teLatitude = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.meResult.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.mapControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teLongitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teLatitude.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'meResult
        '
        Me.meResult.Location = New System.Drawing.Point(12, 531)
        Me.meResult.Name = "meResult"
        Me.meResult.Size = New System.Drawing.Size(686, 72)
        Me.meResult.StyleController = Me.LayoutControl1
        Me.meResult.TabIndex = 8
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.mapControl)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.teLongitude)
        Me.LayoutControl1.Controls.Add(Me.teLatitude)
        Me.LayoutControl1.Controls.Add(Me.meResult)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(710, 615)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'mapControl
        '
        Me.mapControl.Layers.Add(Me.imageLayer)
        Me.mapControl.Layers.Add(Me.informationLayer)
        Me.mapControl.Location = New System.Drawing.Point(12, 38)
        Me.mapControl.Name = "mapControl"
        Me.mapControl.Size = New System.Drawing.Size(686, 489)
        Me.mapControl.TabIndex = 10
        Me.mapControl.ZoomLevel = 17.0R
        Me.imageLayer.DataProvider = Me.imageProvider
        Me.imageProvider.Kind = DevExpress.XtraMap.BingMapKind.RoadGray
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(49, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 11
        Me.SimpleButton1.Text = "Go"
        '
        'teLongitude
        '
        Me.teLongitude.Location = New System.Drawing.Point(173, 12)
        Me.teLongitude.Name = "teLongitude"
        Me.teLongitude.Size = New System.Drawing.Size(261, 22)
        Me.teLongitude.StyleController = Me.LayoutControl1
        Me.teLongitude.TabIndex = 10
        '
        'teLatitude
        '
        Me.teLatitude.Location = New System.Drawing.Point(546, 12)
        Me.teLatitude.Name = "teLatitude"
        Me.teLatitude.Size = New System.Drawing.Size(152, 22)
        Me.teLatitude.StyleController = Me.LayoutControl1
        Me.teLatitude.TabIndex = 9
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(710, 615)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.meResult
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 519)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 76)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(14, 76)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(690, 76)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.teLatitude
        Me.LayoutControlItem3.Location = New System.Drawing.Point(426, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(264, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(96, 13)
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.teLongitude
        Me.LayoutControlItem4.Location = New System.Drawing.Point(53, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(373, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        Me.LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButton1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(53, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        Me.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.mapControl
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(690, 493)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'AttGetMap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(710, 615)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("AttGetMap.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "AttGetMap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.meResult.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.mapControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teLongitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teLatitude.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents meResult As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents teLongitude As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teLatitude As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Private WithEvents mapControl As DevExpress.XtraMap.MapControl
    Private WithEvents imageLayer As DevExpress.XtraMap.ImageLayer
    Private WithEvents imageProvider As DevExpress.XtraMap.BingMapDataProvider
    Private WithEvents informationLayer As DevExpress.XtraMap.InformationLayer
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
