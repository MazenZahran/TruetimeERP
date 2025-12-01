<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsSerialsReport
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsSerialsReport))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckShowDates = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.كشفحركةالسيريالToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColTransID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSerialNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSerialStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySerialStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColPurchaseWarrantyStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryPurchaseWarrantySrart = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColPurchaseWarrantyEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryPurchaseWarrantyEnd = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColSaleWarrantyStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySaleWarrantyStart = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColSaleWarrantyEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySaleWarrantyEnd = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColItemNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrentWahreHouse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCustomer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHypertextLabel1 = New DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckShowDates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySerialStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantySrart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantyEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyStart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("7831030b-2ee5-4fc8-8bec-d0af3255435e")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(203, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(237, 620)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 26)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(230, 591)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.CheckShowDates)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(230, 591)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(14, 553)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(202, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "طباعة"
        '
        'CheckShowDates
        '
        Me.CheckShowDates.EditValue = True
        Me.CheckShowDates.Location = New System.Drawing.Point(14, 16)
        Me.CheckShowDates.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckShowDates.Name = "CheckShowDates"
        Me.CheckShowDates.Properties.Caption = "اظهار تفاصيل التواريخ"
        Me.CheckShowDates.Size = New System.Drawing.Size(202, 21)
        Me.CheckShowDates.StyleController = Me.LayoutControl1
        Me.CheckShowDates.TabIndex = 5
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(14, 525)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(202, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "تحديث"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(230, 591)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 27)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(206, 482)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 509)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(206, 28)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CheckShowDates
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(206, 27)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 537)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(206, 28)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridControl1.Location = New System.Drawing.Point(237, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositorySerialStatus, Me.RepositoryPurchaseWarrantySrart, Me.RepositoryPurchaseWarrantyEnd, Me.RepositorySaleWarrantyStart, Me.RepositorySaleWarrantyEnd, Me.RepositoryItemHypertextLabel1})
        Me.GridControl1.Size = New System.Drawing.Size(953, 620)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.كشفحركةالسيريالToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 26)
        '
        'كشفحركةالسيريالToolStripMenuItem
        '
        Me.كشفحركةالسيريالToolStripMenuItem.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        Me.كشفحركةالسيريالToolStripMenuItem.Name = "كشفحركةالسيريالToolStripMenuItem"
        Me.كشفحركةالسيريالToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.كشفحركةالسيريالToolStripMenuItem.Text = "كشف حركة السيريال"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColTransID, Me.ColSerialNumber, Me.ColSerialStatus, Me.ColPurchaseWarrantyStart, Me.ColPurchaseWarrantyEnd, Me.ColSaleWarrantyStart, Me.ColSaleWarrantyEnd, Me.ColItemNo, Me.ColDocCode, Me.GridColumn1, Me.GridColumn2, Me.ColItemName, Me.ColCurrentWahreHouse, Me.ColVendor, Me.ColCustomer})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.ViewCaption = "test"
        '
        'ColTransID
        '
        Me.ColTransID.Caption = "TransID"
        Me.ColTransID.FieldName = "ID"
        Me.ColTransID.MinWidth = 23
        Me.ColTransID.Name = "ColTransID"
        Me.ColTransID.Width = 87
        '
        'ColSerialNumber
        '
        Me.ColSerialNumber.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.ColSerialNumber.AppearanceHeader.Options.UseBackColor = True
        Me.ColSerialNumber.Caption = "SerialNumber"
        Me.ColSerialNumber.FieldName = "SerialNumber"
        Me.ColSerialNumber.ImageOptions.Image = CType(resources.GetObject("ColSerialNumber.ImageOptions.Image"), System.Drawing.Image)
        Me.ColSerialNumber.MaxWidth = 292
        Me.ColSerialNumber.MinWidth = 23
        Me.ColSerialNumber.Name = "ColSerialNumber"
        Me.ColSerialNumber.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SerialNumber", "{0}")})
        Me.ColSerialNumber.Visible = True
        Me.ColSerialNumber.VisibleIndex = 2
        Me.ColSerialNumber.Width = 175
        '
        'ColSerialStatus
        '
        Me.ColSerialStatus.AppearanceCell.Options.UseTextOptions = True
        Me.ColSerialStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSerialStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSerialStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSerialStatus.Caption = "الحالة"
        Me.ColSerialStatus.ColumnEdit = Me.RepositorySerialStatus
        Me.ColSerialStatus.FieldName = "SerialStatus"
        Me.ColSerialStatus.ImageOptions.Image = CType(resources.GetObject("ColSerialStatus.ImageOptions.Image"), System.Drawing.Image)
        Me.ColSerialStatus.MaxWidth = 117
        Me.ColSerialStatus.MinWidth = 23
        Me.ColSerialStatus.Name = "ColSerialStatus"
        Me.ColSerialStatus.OptionsColumn.AllowEdit = False
        Me.ColSerialStatus.Visible = True
        Me.ColSerialStatus.VisibleIndex = 3
        Me.ColSerialStatus.Width = 105
        '
        'RepositorySerialStatus
        '
        Me.RepositorySerialStatus.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositorySerialStatus.AutoHeight = False
        Me.RepositorySerialStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySerialStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 23, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialStatus", "حالة السيريال", 23, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositorySerialStatus.DisplayMember = "SerialStatus"
        Me.RepositorySerialStatus.Name = "RepositorySerialStatus"
        Me.RepositorySerialStatus.NullText = ""
        Me.RepositorySerialStatus.ValueMember = "ID"
        '
        'ColPurchaseWarrantyStart
        '
        Me.ColPurchaseWarrantyStart.Caption = "بداية كفالة الشراء"
        Me.ColPurchaseWarrantyStart.ColumnEdit = Me.RepositoryPurchaseWarrantySrart
        Me.ColPurchaseWarrantyStart.FieldName = "PurchaseWarrantyStart"
        Me.ColPurchaseWarrantyStart.ImageOptions.Image = CType(resources.GetObject("ColPurchaseWarrantyStart.ImageOptions.Image"), System.Drawing.Image)
        Me.ColPurchaseWarrantyStart.MinWidth = 23
        Me.ColPurchaseWarrantyStart.Name = "ColPurchaseWarrantyStart"
        Me.ColPurchaseWarrantyStart.Visible = True
        Me.ColPurchaseWarrantyStart.VisibleIndex = 5
        Me.ColPurchaseWarrantyStart.Width = 105
        '
        'RepositoryPurchaseWarrantySrart
        '
        Me.RepositoryPurchaseWarrantySrart.AutoHeight = False
        Me.RepositoryPurchaseWarrantySrart.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantySrart.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositoryPurchaseWarrantySrart.Name = "RepositoryPurchaseWarrantySrart"
        Me.RepositoryPurchaseWarrantySrart.UseMaskAsDisplayFormat = True
        '
        'ColPurchaseWarrantyEnd
        '
        Me.ColPurchaseWarrantyEnd.Caption = "نهاية كفالة الشراء"
        Me.ColPurchaseWarrantyEnd.ColumnEdit = Me.RepositoryPurchaseWarrantyEnd
        Me.ColPurchaseWarrantyEnd.FieldName = "PurchaseWarrantyEnd"
        Me.ColPurchaseWarrantyEnd.ImageOptions.Image = CType(resources.GetObject("ColPurchaseWarrantyEnd.ImageOptions.Image"), System.Drawing.Image)
        Me.ColPurchaseWarrantyEnd.MinWidth = 23
        Me.ColPurchaseWarrantyEnd.Name = "ColPurchaseWarrantyEnd"
        Me.ColPurchaseWarrantyEnd.Visible = True
        Me.ColPurchaseWarrantyEnd.VisibleIndex = 6
        Me.ColPurchaseWarrantyEnd.Width = 105
        '
        'RepositoryPurchaseWarrantyEnd
        '
        Me.RepositoryPurchaseWarrantyEnd.AutoHeight = False
        Me.RepositoryPurchaseWarrantyEnd.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantyEnd.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositoryPurchaseWarrantyEnd.Name = "RepositoryPurchaseWarrantyEnd"
        Me.RepositoryPurchaseWarrantyEnd.UseMaskAsDisplayFormat = True
        '
        'ColSaleWarrantyStart
        '
        Me.ColSaleWarrantyStart.Caption = "تاريخ كفالة البيع"
        Me.ColSaleWarrantyStart.ColumnEdit = Me.RepositorySaleWarrantyStart
        Me.ColSaleWarrantyStart.FieldName = "SaleWarrantyStart"
        Me.ColSaleWarrantyStart.ImageOptions.Image = CType(resources.GetObject("ColSaleWarrantyStart.ImageOptions.Image"), System.Drawing.Image)
        Me.ColSaleWarrantyStart.MinWidth = 23
        Me.ColSaleWarrantyStart.Name = "ColSaleWarrantyStart"
        Me.ColSaleWarrantyStart.Visible = True
        Me.ColSaleWarrantyStart.VisibleIndex = 7
        Me.ColSaleWarrantyStart.Width = 105
        '
        'RepositorySaleWarrantyStart
        '
        Me.RepositorySaleWarrantyStart.AutoHeight = False
        Me.RepositorySaleWarrantyStart.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyStart.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyStart.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositorySaleWarrantyStart.Name = "RepositorySaleWarrantyStart"
        Me.RepositorySaleWarrantyStart.UseMaskAsDisplayFormat = True
        '
        'ColSaleWarrantyEnd
        '
        Me.ColSaleWarrantyEnd.Caption = "نهاية كفالة البيع"
        Me.ColSaleWarrantyEnd.ColumnEdit = Me.RepositorySaleWarrantyEnd
        Me.ColSaleWarrantyEnd.FieldName = "SaleWarrantyEnd"
        Me.ColSaleWarrantyEnd.ImageOptions.Image = CType(resources.GetObject("ColSaleWarrantyEnd.ImageOptions.Image"), System.Drawing.Image)
        Me.ColSaleWarrantyEnd.MinWidth = 23
        Me.ColSaleWarrantyEnd.Name = "ColSaleWarrantyEnd"
        Me.ColSaleWarrantyEnd.Visible = True
        Me.ColSaleWarrantyEnd.VisibleIndex = 8
        Me.ColSaleWarrantyEnd.Width = 110
        '
        'RepositorySaleWarrantyEnd
        '
        Me.RepositorySaleWarrantyEnd.AutoHeight = False
        Me.RepositorySaleWarrantyEnd.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyEnd.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyEnd.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositorySaleWarrantyEnd.Name = "RepositorySaleWarrantyEnd"
        Me.RepositorySaleWarrantyEnd.UseMaskAsDisplayFormat = True
        '
        'ColItemNo
        '
        Me.ColItemNo.Caption = "رقم الصنف"
        Me.ColItemNo.FieldName = "ItemNo"
        Me.ColItemNo.ImageOptions.Image = CType(resources.GetObject("ColItemNo.ImageOptions.Image"), System.Drawing.Image)
        Me.ColItemNo.MinWidth = 23
        Me.ColItemNo.Name = "ColItemNo"
        Me.ColItemNo.Visible = True
        Me.ColItemNo.VisibleIndex = 0
        Me.ColItemNo.Width = 105
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "DocCode"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MinWidth = 23
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.Width = 100
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "TransType"
        Me.GridColumn1.FieldName = "TransType"
        Me.GridColumn1.MinWidth = 23
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SerialID"
        Me.GridColumn2.FieldName = "SerialID"
        Me.GridColumn2.MinWidth = 23
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Width = 112
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.ImageOptions.Image = CType(resources.GetObject("ColItemName.ImageOptions.Image"), System.Drawing.Image)
        Me.ColItemName.MinWidth = 175
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 1
        Me.ColItemName.Width = 175
        '
        'ColCurrentWahreHouse
        '
        Me.ColCurrentWahreHouse.Caption = "المستودع"
        Me.ColCurrentWahreHouse.FieldName = "CurrentWahreHouse"
        Me.ColCurrentWahreHouse.MinWidth = 23
        Me.ColCurrentWahreHouse.Name = "ColCurrentWahreHouse"
        Me.ColCurrentWahreHouse.Visible = True
        Me.ColCurrentWahreHouse.VisibleIndex = 4
        Me.ColCurrentWahreHouse.Width = 87
        '
        'ColVendor
        '
        Me.ColVendor.Caption = "المورد"
        Me.ColVendor.FieldName = "vendor"
        Me.ColVendor.MinWidth = 23
        Me.ColVendor.Name = "ColVendor"
        Me.ColVendor.Visible = True
        Me.ColVendor.VisibleIndex = 9
        Me.ColVendor.Width = 87
        '
        'ColCustomer
        '
        Me.ColCustomer.Caption = "الزبون"
        Me.ColCustomer.FieldName = "customer"
        Me.ColCustomer.MinWidth = 23
        Me.ColCustomer.Name = "ColCustomer"
        Me.ColCustomer.Visible = True
        Me.ColCustomer.VisibleIndex = 10
        Me.ColCustomer.Width = 87
        '
        'RepositoryItemHypertextLabel1
        '
        Me.RepositoryItemHypertextLabel1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemHypertextLabel1.Name = "RepositoryItemHypertextLabel1"
        '
        'ItemsSerialsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1190, 620)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.IconOptions.Image = CType(resources.GetObject("ItemsSerialsReport.IconOptions.Image"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ItemsSerialsReport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "استعلام السيريال"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckShowDates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySerialStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantySrart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantyEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyStart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColTransID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSerialNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSerialStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySerialStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColPurchaseWarrantyStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryPurchaseWarrantySrart As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColPurchaseWarrantyEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryPurchaseWarrantyEnd As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColSaleWarrantyStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySaleWarrantyStart As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColSaleWarrantyEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySaleWarrantyEnd As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColItemNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckShowDates As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemHypertextLabel1 As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents كشفحركةالسيريالToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColCurrentWahreHouse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCustomer As DevExpress.XtraGrid.Columns.GridColumn
End Class
