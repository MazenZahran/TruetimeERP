<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReadClock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadClock))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnRead = New DevExpress.XtraEditors.SimpleButton()
        Me.AttConnectionType = New DevExpress.XtraEditors.TextEdit()
        Me.TextTotalReads = New DevExpress.XtraEditors.TextEdit()
        Me.TextUnProcessedTrans = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TextNewEmployees = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.TrueTime.WaitForm11), True, True)
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarAttFilePath = New DevExpress.XtraBars.BarStaticItem()
        Me.BarAttAplicationPath = New DevExpress.XtraBars.BarStaticItem()
        Me.BarAttConnectionType = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.AttConnectionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalReads.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextUnProcessedTrans.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewEmployees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Controls.Add(Me.LayoutControl2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(619, 632, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'LayoutControl2
        '
        resources.ApplyResources(Me.LayoutControl2, "LayoutControl2")
        Me.LayoutControl2.Controls.Add(Me.BtnRead)
        Me.LayoutControl2.Controls.Add(Me.AttConnectionType)
        Me.LayoutControl2.Controls.Add(Me.TextTotalReads)
        Me.LayoutControl2.Controls.Add(Me.TextUnProcessedTrans)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl2.Controls.Add(Me.BtnSave)
        Me.LayoutControl2.Controls.Add(Me.TextNewEmployees)
        Me.LayoutControl2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem6})
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.Root
        '
        'BtnRead
        '
        resources.ApplyResources(Me.BtnRead, "BtnRead")
        Me.BtnRead.ImageOptions.SvgImage = CType(resources.GetObject("BtnRead.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnRead.Name = "BtnRead"
        Me.BtnRead.StyleController = Me.LayoutControl2
        '
        'AttConnectionType
        '
        resources.ApplyResources(Me.AttConnectionType, "AttConnectionType")
        Me.AttConnectionType.Name = "AttConnectionType"
        Me.AttConnectionType.Properties.ReadOnly = True
        Me.AttConnectionType.StyleController = Me.LayoutControl2
        '
        'TextTotalReads
        '
        resources.ApplyResources(Me.TextTotalReads, "TextTotalReads")
        Me.TextTotalReads.Name = "TextTotalReads"
        Me.TextTotalReads.Properties.AdvancedModeOptions.Label = resources.GetString("TextTotalReads.Properties.AdvancedModeOptions.Label")
        Me.TextTotalReads.Properties.ReadOnly = True
        Me.TextTotalReads.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextTotalReads.StyleController = Me.LayoutControl2
        '
        'TextUnProcessedTrans
        '
        resources.ApplyResources(Me.TextUnProcessedTrans, "TextUnProcessedTrans")
        Me.TextUnProcessedTrans.Name = "TextUnProcessedTrans"
        Me.TextUnProcessedTrans.Properties.ReadOnly = True
        Me.TextUnProcessedTrans.StyleController = Me.LayoutControl2
        '
        'SimpleButton2
        '
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl2
        '
        'BtnSave
        '
        resources.ApplyResources(Me.BtnSave, "BtnSave")
        Me.BtnSave.ImageOptions.SvgImage = CType(resources.GetObject("BtnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.StyleController = Me.LayoutControl2
        '
        'TextNewEmployees
        '
        resources.ApplyResources(Me.TextNewEmployees, "TextNewEmployees")
        Me.TextNewEmployees.Name = "TextNewEmployees"
        Me.TextNewEmployees.Properties.AdvancedModeOptions.Label = resources.GetString("TextNewEmployees.Properties.AdvancedModeOptions.Label")
        Me.TextNewEmployees.Properties.ReadOnly = True
        Me.TextNewEmployees.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextNewEmployees.StyleController = Me.LayoutControl2
        '
        'LayoutControlItem3
        '
        resources.ApplyResources(Me.LayoutControlItem3, "LayoutControlItem3")
        Me.LayoutControlItem3.Control = Me.TextUnProcessedTrans
        Me.LayoutControlItem3.Location = New System.Drawing.Point(400, 452)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(179, 28)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem6
        '
        resources.ApplyResources(Me.LayoutControlItem6, "LayoutControlItem6")
        Me.LayoutControlItem6.Control = Me.AttConnectionType
        Me.LayoutControlItem6.Location = New System.Drawing.Point(221, 452)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(179, 28)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'Root
        '
        resources.ApplyResources(Me.Root, "Root")
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem4, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.LayoutControlItem5, Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem5})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(703, 461)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem4
        '
        resources.ApplyResources(Me.EmptySpaceItem4, "EmptySpaceItem4")
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 243)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(677, 148)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.Control = Me.TextTotalReads
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 107)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(606, 46)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(606, 46)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(677, 46)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem7
        '
        resources.ApplyResources(Me.LayoutControlItem7, "LayoutControlItem7")
        Me.LayoutControlItem7.Control = Me.BtnSave
        Me.LayoutControlItem7.Location = New System.Drawing.Point(374, 153)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(303, 42)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(303, 42)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(303, 42)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem5
        '
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.Control = Me.SimpleButton2
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 391)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(190, 44)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem1
        '
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Control = Me.BtnRead
        Me.LayoutControlItem1.Location = New System.Drawing.Point(374, 63)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(303, 44)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        resources.ApplyResources(Me.EmptySpaceItem1, "EmptySpaceItem1")
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(677, 63)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        resources.ApplyResources(Me.LayoutControlItem4, "LayoutControlItem4")
        Me.LayoutControlItem4.Control = Me.TextNewEmployees
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 195)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(677, 48)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem2
        '
        resources.ApplyResources(Me.EmptySpaceItem2, "EmptySpaceItem2")
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 63)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(374, 44)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        resources.ApplyResources(Me.EmptySpaceItem3, "EmptySpaceItem3")
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 153)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(374, 42)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        resources.ApplyResources(Me.EmptySpaceItem5, "EmptySpaceItem5")
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(190, 391)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(487, 44)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup1
        '
        resources.ApplyResources(Me.LayoutControlGroup1, "LayoutControlGroup1")
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(735, 493)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem8
        '
        resources.ApplyResources(Me.LayoutControlItem8, "LayoutControlItem8")
        Me.LayoutControlItem8.Control = Me.LayoutControl2
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(709, 467)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarAttFilePath, Me.BarAttAplicationPath, Me.BarAttConnectionType})
        Me.BarManager1.MaxItemId = 3
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        resources.ApplyResources(Me.Bar3, "Bar3")
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarAttFilePath), New DevExpress.XtraBars.LinkPersistInfo(Me.BarAttAplicationPath), New DevExpress.XtraBars.LinkPersistInfo(Me.BarAttConnectionType)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        '
        'BarAttFilePath
        '
        resources.ApplyResources(Me.BarAttFilePath, "BarAttFilePath")
        Me.BarAttFilePath.Id = 0
        Me.BarAttFilePath.ImageOptions.Image = CType(resources.GetObject("BarAttFilePath.ImageOptions.Image"), System.Drawing.Image)
        Me.BarAttFilePath.ImageOptions.ImageIndex = CType(resources.GetObject("BarAttFilePath.ImageOptions.ImageIndex"), Integer)
        Me.BarAttFilePath.ImageOptions.LargeImage = CType(resources.GetObject("BarAttFilePath.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarAttFilePath.ImageOptions.LargeImageIndex = CType(resources.GetObject("BarAttFilePath.ImageOptions.LargeImageIndex"), Integer)
        Me.BarAttFilePath.ImageOptions.SvgImage = CType(resources.GetObject("BarAttFilePath.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarAttFilePath.Name = "BarAttFilePath"
        Me.BarAttFilePath.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarAttAplicationPath
        '
        resources.ApplyResources(Me.BarAttAplicationPath, "BarAttAplicationPath")
        Me.BarAttAplicationPath.Id = 1
        Me.BarAttAplicationPath.ImageOptions.Image = CType(resources.GetObject("BarAttAplicationPath.ImageOptions.Image"), System.Drawing.Image)
        Me.BarAttAplicationPath.ImageOptions.ImageIndex = CType(resources.GetObject("BarAttAplicationPath.ImageOptions.ImageIndex"), Integer)
        Me.BarAttAplicationPath.ImageOptions.LargeImage = CType(resources.GetObject("BarAttAplicationPath.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarAttAplicationPath.ImageOptions.LargeImageIndex = CType(resources.GetObject("BarAttAplicationPath.ImageOptions.LargeImageIndex"), Integer)
        Me.BarAttAplicationPath.ImageOptions.SvgImage = CType(resources.GetObject("BarAttAplicationPath.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarAttAplicationPath.Name = "BarAttAplicationPath"
        Me.BarAttAplicationPath.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarAttConnectionType
        '
        resources.ApplyResources(Me.BarAttConnectionType, "BarAttConnectionType")
        Me.BarAttConnectionType.Id = 2
        Me.BarAttConnectionType.ImageOptions.Image = CType(resources.GetObject("BarAttConnectionType.ImageOptions.Image"), System.Drawing.Image)
        Me.BarAttConnectionType.ImageOptions.ImageIndex = CType(resources.GetObject("BarAttConnectionType.ImageOptions.ImageIndex"), Integer)
        Me.BarAttConnectionType.ImageOptions.LargeImage = CType(resources.GetObject("BarAttConnectionType.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarAttConnectionType.ImageOptions.LargeImageIndex = CType(resources.GetObject("BarAttConnectionType.ImageOptions.LargeImageIndex"), Integer)
        Me.BarAttConnectionType.ImageOptions.SvgImage = CType(resources.GetObject("BarAttConnectionType.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarAttConnectionType.Name = "BarAttConnectionType"
        Me.BarAttConnectionType.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'barDockControlTop
        '
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Manager = Me.BarManager1
        '
        'barDockControlBottom
        '
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Manager = Me.BarManager1
        '
        'barDockControlLeft
        '
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Manager = Me.BarManager1
        '
        'barDockControlRight
        '
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Manager = Me.BarManager1
        '
        'ReadClock
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.LargeImage = CType(resources.GetObject("ReadClock.IconOptions.LargeImage"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReadClock"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.AttConnectionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalReads.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextUnProcessedTrans.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewEmployees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BtnRead As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextTotalReads As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextUnProcessedTrans As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents TextNewEmployees As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AttConnectionType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents BarAttFilePath As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarAttAplicationPath As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarAttConnectionType As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
End Class
