<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Accounts
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Accounts))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCurrency = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColFinancialStatment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryFinancialStatment = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColFinancialSector = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryFinancialSectors = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColEditAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryFinancialStatment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryFinancialSectors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("1aa3eb89-b544-4f64-9973-db47ef7ecc73")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
        '
        'DockPanel1_Container
        '
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'LayoutControl2
        '
        resources.ApplyResources(Me.LayoutControl2, "LayoutControl2")
        Me.LayoutControl2.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        '
        'SimpleButton2
        '
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl2
        '
        'SimpleButton1
        '
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(193, 682)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 52)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(173, 610)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        resources.ApplyResources(Me.LayoutControlItem3, "LayoutControlItem3")
        Me.LayoutControlItem3.Control = Me.SimpleButton2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("GridControl1.EmbeddedNavigator.AccessibleDescription")
        Me.GridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("GridControl1.EmbeddedNavigator.AccessibleName")
        Me.GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.GridControl1.EmbeddedNavigator.Anchor = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("GridControl1.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
        Me.GridControl1.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("GridControl1.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.GridControl1.EmbeddedNavigator.ImeMode = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GridControl1.EmbeddedNavigator.Margin = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        Me.GridControl1.EmbeddedNavigator.MaximumSize = CType(resources.GetObject("GridControl1.EmbeddedNavigator.MaximumSize"), System.Drawing.Size)
        Me.GridControl1.EmbeddedNavigator.TextLocation = CType(resources.GetObject("GridControl1.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.GridControl1.EmbeddedNavigator.ToolTip = resources.GetString("GridControl1.EmbeddedNavigator.ToolTip")
        Me.GridControl1.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.GridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("GridControl1.EmbeddedNavigator.ToolTipTitle")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryCurrency, Me.RepositoryFinancialStatment, Me.RepositoryFinancialSectors, Me.RepositoryEdit})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColAccID, Me.ColAccNo, Me.ColAccName, Me.ColCurrency, Me.ColFinancialStatment, Me.ColFinancialSector, Me.ColEditAccount})
        Me.GridView1.DetailHeight = 431
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColFinancialStatment, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColFinancialSector, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColAccID
        '
        resources.ApplyResources(Me.ColAccID, "ColAccID")
        Me.ColAccID.FieldName = "AccID"
        Me.ColAccID.MinWidth = 23
        Me.ColAccID.Name = "ColAccID"
        Me.ColAccID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColAccNo
        '
        resources.ApplyResources(Me.ColAccNo, "ColAccNo")
        Me.ColAccNo.FieldName = "AccNo"
        Me.ColAccNo.MinWidth = 23
        Me.ColAccNo.Name = "ColAccNo"
        Me.ColAccNo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColAccName
        '
        resources.ApplyResources(Me.ColAccName, "ColAccName")
        Me.ColAccName.FieldName = "AccName"
        Me.ColAccName.MinWidth = 23
        Me.ColAccName.Name = "ColAccName"
        Me.ColAccName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColCurrency
        '
        resources.ApplyResources(Me.ColCurrency, "ColCurrency")
        Me.ColCurrency.ColumnEdit = Me.RepositoryCurrency
        Me.ColCurrency.FieldName = "Currency"
        Me.ColCurrency.MinWidth = 23
        Me.ColCurrency.Name = "ColCurrency"
        Me.ColCurrency.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryCurrency
        '
        resources.ApplyResources(Me.RepositoryCurrency, "RepositoryCurrency")
        Me.RepositoryCurrency.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryCurrency.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryCurrency.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryCurrency.Columns"), resources.GetString("RepositoryCurrency.Columns1"), CType(resources.GetObject("RepositoryCurrency.Columns2"), Integer), CType(resources.GetObject("RepositoryCurrency.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryCurrency.Columns4"), CType(resources.GetObject("RepositoryCurrency.Columns5"), Boolean), CType(resources.GetObject("RepositoryCurrency.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryCurrency.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryCurrency.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryCurrency.Columns9"), resources.GetString("RepositoryCurrency.Columns10"), CType(resources.GetObject("RepositoryCurrency.Columns11"), Integer), CType(resources.GetObject("RepositoryCurrency.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryCurrency.Columns13"), CType(resources.GetObject("RepositoryCurrency.Columns14"), Boolean), CType(resources.GetObject("RepositoryCurrency.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryCurrency.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryCurrency.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryCurrency.DisplayMember = "Code"
        Me.RepositoryCurrency.Name = "RepositoryCurrency"
        Me.RepositoryCurrency.ValueMember = "CurrID"
        '
        'ColFinancialStatment
        '
        resources.ApplyResources(Me.ColFinancialStatment, "ColFinancialStatment")
        Me.ColFinancialStatment.ColumnEdit = Me.RepositoryFinancialStatment
        Me.ColFinancialStatment.FieldName = "FinancialStatment"
        Me.ColFinancialStatment.MinWidth = 23
        Me.ColFinancialStatment.Name = "ColFinancialStatment"
        Me.ColFinancialStatment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryFinancialStatment
        '
        resources.ApplyResources(Me.RepositoryFinancialStatment, "RepositoryFinancialStatment")
        Me.RepositoryFinancialStatment.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryFinancialStatment.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryFinancialStatment.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryFinancialStatment.Columns"), resources.GetString("RepositoryFinancialStatment.Columns1"), CType(resources.GetObject("RepositoryFinancialStatment.Columns2"), Integer), CType(resources.GetObject("RepositoryFinancialStatment.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryFinancialStatment.Columns4"), CType(resources.GetObject("RepositoryFinancialStatment.Columns5"), Boolean), CType(resources.GetObject("RepositoryFinancialStatment.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryFinancialStatment.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryFinancialStatment.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryFinancialStatment.Columns9"), resources.GetString("RepositoryFinancialStatment.Columns10"), CType(resources.GetObject("RepositoryFinancialStatment.Columns11"), Integer), CType(resources.GetObject("RepositoryFinancialStatment.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryFinancialStatment.Columns13"), CType(resources.GetObject("RepositoryFinancialStatment.Columns14"), Boolean), CType(resources.GetObject("RepositoryFinancialStatment.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryFinancialStatment.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryFinancialStatment.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryFinancialStatment.DisplayMember = "FinancialStatementName"
        Me.RepositoryFinancialStatment.Name = "RepositoryFinancialStatment"
        Me.RepositoryFinancialStatment.ValueMember = "ID"
        '
        'ColFinancialSector
        '
        resources.ApplyResources(Me.ColFinancialSector, "ColFinancialSector")
        Me.ColFinancialSector.ColumnEdit = Me.RepositoryFinancialSectors
        Me.ColFinancialSector.FieldName = "FinancialSector"
        Me.ColFinancialSector.MinWidth = 23
        Me.ColFinancialSector.Name = "ColFinancialSector"
        Me.ColFinancialSector.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryFinancialSectors
        '
        resources.ApplyResources(Me.RepositoryFinancialSectors, "RepositoryFinancialSectors")
        Me.RepositoryFinancialSectors.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryFinancialSectors.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryFinancialSectors.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryFinancialSectors.Columns"), resources.GetString("RepositoryFinancialSectors.Columns1"), CType(resources.GetObject("RepositoryFinancialSectors.Columns2"), Integer), CType(resources.GetObject("RepositoryFinancialSectors.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryFinancialSectors.Columns4"), CType(resources.GetObject("RepositoryFinancialSectors.Columns5"), Boolean), CType(resources.GetObject("RepositoryFinancialSectors.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryFinancialSectors.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryFinancialSectors.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryFinancialSectors.Columns9"), resources.GetString("RepositoryFinancialSectors.Columns10"), CType(resources.GetObject("RepositoryFinancialSectors.Columns11"), Integer), CType(resources.GetObject("RepositoryFinancialSectors.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryFinancialSectors.Columns13"), CType(resources.GetObject("RepositoryFinancialSectors.Columns14"), Boolean), CType(resources.GetObject("RepositoryFinancialSectors.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryFinancialSectors.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryFinancialSectors.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryFinancialSectors.DisplayMember = "SectorName"
        Me.RepositoryFinancialSectors.Name = "RepositoryFinancialSectors"
        Me.RepositoryFinancialSectors.ValueMember = "SectorID"
        '
        'ColEditAccount
        '
        resources.ApplyResources(Me.ColEditAccount, "ColEditAccount")
        Me.ColEditAccount.ColumnEdit = Me.RepositoryEdit
        Me.ColEditAccount.FieldName = "EditAccount"
        Me.ColEditAccount.MaxWidth = 175
        Me.ColEditAccount.MinWidth = 23
        Me.ColEditAccount.Name = "ColEditAccount"
        Me.ColEditAccount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryEdit
        '
        resources.ApplyResources(Me.RepositoryEdit, "RepositoryEdit")
        resources.ApplyResources(EditorButtonImageOptions1, "EditorButtonImageOptions1")
        Me.RepositoryEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryEdit.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepositoryEdit.Buttons1"), CType(resources.GetObject("RepositoryEdit.Buttons2"), Integer), CType(resources.GetObject("RepositoryEdit.Buttons3"), Boolean), CType(resources.GetObject("RepositoryEdit.Buttons4"), Boolean), CType(resources.GetObject("RepositoryEdit.Buttons5"), Boolean), EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, resources.GetString("RepositoryEdit.Buttons6"), CType(resources.GetObject("RepositoryEdit.Buttons7"), Object), CType(resources.GetObject("RepositoryEdit.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepositoryEdit.Buttons9"), DevExpress.Utils.ToolTipAnchor))})
        Me.RepositoryEdit.MaxLength = 100
        Me.RepositoryEdit.Name = "RepositoryEdit"
        Me.RepositoryEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'LayoutControl1
        '
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(497, 0, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(864, 715)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(844, 695)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'Accounts
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "Accounts"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryFinancialStatment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryFinancialSectors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCurrency As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColFinancialStatment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColFinancialSector As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryFinancialStatment As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryFinancialSectors As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColEditAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
