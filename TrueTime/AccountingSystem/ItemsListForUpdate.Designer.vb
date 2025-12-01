<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsListForUpdate
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
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.ItemsCategoriesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsCategoriesTableAdapter()
        Me.ItemsGroupsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsGroupsTableAdapter()
        Me.ItemsTradeMarkTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsTradeMarkTableAdapter()
        Me.ItemsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colItemNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryGroups = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ItemsGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colCategoryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCategory = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ItemsCategoriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colTradeMarkID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryTradeMark = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ItemsTradeMarkBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colItemStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckItemStatus = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colHasProductionEquation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVisibleInAPP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMaxQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReOrderQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLastPurchasePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWithAdditions = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUseBatchNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSaleOnScale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSaleOnSamba = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccSales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccPurches = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.RepositoryItemMemoExEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.RefreshBut = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.colLastPurchasePrice1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsCategoriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryTradeMark, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsTradeMarkBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckItemStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.AccountingDataSet
        '
        'ItemsTableAdapter
        '
        Me.ItemsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountingBranchesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPOSNamesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPosTypesTableAdapter = Nothing
        Me.TableAdapterManager.AppointmentsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTypeTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BankBrancheTableAdapter = Nothing
        Me.TableAdapterManager.BankTableAdapter = Nothing
        Me.TableAdapterManager.CRMTaskStatusesTableAdapter = Nothing
        Me.TableAdapterManager.DocNamesTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesAccessTableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccounts1TableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccountsTableAdapter = Nothing
        Me.TableAdapterManager.Items_unitsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsCategoriesTableAdapter = Me.ItemsCategoriesTableAdapter
        Me.TableAdapterManager.ItemsColorsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Me.ItemsGroupsTableAdapter
        Me.TableAdapterManager.ItemsMeasuresTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTableAdapter = Me.ItemsTableAdapter
        Me.TableAdapterManager.ItemsTradeMarkTableAdapter = Me.ItemsTradeMarkTableAdapter
        Me.TableAdapterManager.PatientsVisitsTableAdapter = Nothing
        Me.TableAdapterManager.PosPaidMethodsTableAdapter = Nothing
        Me.TableAdapterManager.ProductionEquationTableAdapter = Nothing
        Me.TableAdapterManager.RefCitiesTableAdapter = Nothing
        Me.TableAdapterManager.ReferancesListTableAdapter = Nothing
        Me.TableAdapterManager.ReferencessTableAdapter = Nothing
        Me.TableAdapterManager.ReferencesTypesTableAdapter = Nothing
        Me.TableAdapterManager.RefSortsTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsListTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsPaymentTableAdapter = Nothing
        Me.TableAdapterManager.ResourcesTableAdapter = Nothing
        Me.TableAdapterManager.UnitsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.Vehicle_MaintenanceTableAdapter = Nothing
        Me.TableAdapterManager.WarehousesTableAdapter = Nothing
        '
        'ItemsCategoriesTableAdapter
        '
        Me.ItemsCategoriesTableAdapter.ClearBeforeFill = True
        '
        'ItemsGroupsTableAdapter
        '
        Me.ItemsGroupsTableAdapter.ClearBeforeFill = True
        '
        'ItemsTradeMarkTableAdapter
        '
        Me.ItemsTradeMarkTableAdapter.ClearBeforeFill = True
        '
        'ItemsGridControl
        '
        Me.ItemsGridControl.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ItemsGridControl.DataSource = Me.ItemsBindingSource
        Me.ItemsGridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemsGridControl.Location = New System.Drawing.Point(200, 0)
        Me.ItemsGridControl.MainView = Me.GridView1
        Me.ItemsGridControl.Name = "ItemsGridControl"
        Me.ItemsGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryGroups, Me.RepositoryCategory, Me.RepositoryTradeMark, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoExEdit1, Me.RepositoryItemCheckItemStatus})
        Me.ItemsGridControl.Size = New System.Drawing.Size(656, 550)
        Me.ItemsGridControl.TabIndex = 1
        Me.ItemsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "نسخ إلى الأسفل"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colItemNo, Me.colItemName, Me.colGroupID, Me.colCategoryID, Me.colTradeMarkID, Me.colItemStatus, Me.colHasProductionEquation, Me.colVisibleInAPP, Me.colMaxQuantity, Me.colReOrderQuantity, Me.colLastPurchasePrice, Me.colWithAdditions, Me.colUseBatchNo, Me.colSaleOnScale, Me.colSaleOnSamba, Me.colAccSales, Me.colAccPurches, Me.colLastPurchasePrice1})
        Me.GridView1.GridControl = Me.ItemsGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colItemNo
        '
        Me.colItemNo.AppearanceCell.Options.UseTextOptions = True
        Me.colItemNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colItemNo.AppearanceHeader.Options.UseTextOptions = True
        Me.colItemNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.colItemNo.Caption = "رقم الصنف"
        Me.colItemNo.FieldName = "ItemNo"
        Me.colItemNo.MaxWidth = 80
        Me.colItemNo.Name = "colItemNo"
        Me.colItemNo.OptionsColumn.AllowEdit = False
        Me.colItemNo.OptionsColumn.ReadOnly = True
        Me.colItemNo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ItemNo", "{0}")})
        Me.colItemNo.Visible = True
        Me.colItemNo.VisibleIndex = 0
        '
        'colItemName
        '
        Me.colItemName.Caption = "الصنف"
        Me.colItemName.FieldName = "ItemName"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Visible = True
        Me.colItemName.VisibleIndex = 1
        '
        'colGroupID
        '
        Me.colGroupID.Caption = "مجموعة الصنف"
        Me.colGroupID.ColumnEdit = Me.RepositoryGroups
        Me.colGroupID.FieldName = "GroupID"
        Me.colGroupID.Name = "colGroupID"
        Me.colGroupID.Visible = True
        Me.colGroupID.VisibleIndex = 2
        Me.colGroupID.Width = 113
        '
        'RepositoryGroups
        '
        Me.RepositoryGroups.AutoHeight = False
        Me.RepositoryGroups.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryGroups.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupID", "ID", 52, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("GroupName", "المجموعة", 69, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryGroups.DataSource = Me.ItemsGroupsBindingSource
        Me.RepositoryGroups.DisplayMember = "GroupName"
        Me.RepositoryGroups.Name = "RepositoryGroups"
        Me.RepositoryGroups.NullText = ""
        Me.RepositoryGroups.ValueMember = "GroupID"
        '
        'ItemsGroupsBindingSource
        '
        Me.ItemsGroupsBindingSource.DataMember = "ItemsGroups"
        Me.ItemsGroupsBindingSource.DataSource = Me.AccountingDataSet
        '
        'colCategoryID
        '
        Me.colCategoryID.Caption = "التصنيف"
        Me.colCategoryID.ColumnEdit = Me.RepositoryCategory
        Me.colCategoryID.FieldName = "CategoryID"
        Me.colCategoryID.Name = "colCategoryID"
        Me.colCategoryID.Visible = True
        Me.colCategoryID.VisibleIndex = 3
        Me.colCategoryID.Width = 113
        '
        'RepositoryCategory
        '
        Me.RepositoryCategory.AutoHeight = False
        Me.RepositoryCategory.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryCategory.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryID", "ID", 65, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryName", "التصنيف", 81, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryCategory.DataSource = Me.ItemsCategoriesBindingSource
        Me.RepositoryCategory.DisplayMember = "CategoryName"
        Me.RepositoryCategory.Name = "RepositoryCategory"
        Me.RepositoryCategory.NullText = ""
        Me.RepositoryCategory.ValueMember = "CategoryID"
        '
        'ItemsCategoriesBindingSource
        '
        Me.ItemsCategoriesBindingSource.DataMember = "ItemsCategories"
        Me.ItemsCategoriesBindingSource.DataSource = Me.AccountingDataSet
        '
        'colTradeMarkID
        '
        Me.colTradeMarkID.Caption = "العلامة التجارية"
        Me.colTradeMarkID.ColumnEdit = Me.RepositoryTradeMark
        Me.colTradeMarkID.FieldName = "TradeMarkID"
        Me.colTradeMarkID.Name = "colTradeMarkID"
        Me.colTradeMarkID.Visible = True
        Me.colTradeMarkID.VisibleIndex = 4
        Me.colTradeMarkID.Width = 152
        '
        'RepositoryTradeMark
        '
        Me.RepositoryTradeMark.AutoHeight = False
        Me.RepositoryTradeMark.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryTradeMark.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TradeMarkID", "ID", 78, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TradeMarkName", "العلامة التجارية", 94, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryTradeMark.DataSource = Me.ItemsTradeMarkBindingSource
        Me.RepositoryTradeMark.DisplayMember = "TradeMarkName"
        Me.RepositoryTradeMark.Name = "RepositoryTradeMark"
        Me.RepositoryTradeMark.NullText = ""
        Me.RepositoryTradeMark.ValueMember = "TradeMarkID"
        '
        'ItemsTradeMarkBindingSource
        '
        Me.ItemsTradeMarkBindingSource.DataMember = "ItemsTradeMark"
        Me.ItemsTradeMarkBindingSource.DataSource = Me.AccountingDataSet
        '
        'colItemStatus
        '
        Me.colItemStatus.Caption = "حالة الصنف"
        Me.colItemStatus.ColumnEdit = Me.RepositoryItemCheckItemStatus
        Me.colItemStatus.FieldName = "ItemStatus"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.OptionsColumn.FixedWidth = True
        Me.colItemStatus.Visible = True
        Me.colItemStatus.VisibleIndex = 5
        Me.colItemStatus.Width = 69
        '
        'RepositoryItemCheckItemStatus
        '
        Me.RepositoryItemCheckItemStatus.AutoHeight = False
        Me.RepositoryItemCheckItemStatus.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1
        Me.RepositoryItemCheckItemStatus.Name = "RepositoryItemCheckItemStatus"
        '
        'colHasProductionEquation
        '
        Me.colHasProductionEquation.Caption = "له معادلة انتاج"
        Me.colHasProductionEquation.FieldName = "HasProductionEquation"
        Me.colHasProductionEquation.Name = "colHasProductionEquation"
        Me.colHasProductionEquation.OptionsColumn.ReadOnly = True
        '
        'colVisibleInAPP
        '
        Me.colVisibleInAPP.Caption = "يظهر في نظام الطلبيات موبايل"
        Me.colVisibleInAPP.FieldName = "VisibleInAPP"
        Me.colVisibleInAPP.Name = "colVisibleInAPP"
        '
        'colMaxQuantity
        '
        Me.colMaxQuantity.Caption = "اعلى كمية "
        Me.colMaxQuantity.FieldName = "MaxQuantity"
        Me.colMaxQuantity.Name = "colMaxQuantity"
        '
        'colReOrderQuantity
        '
        Me.colReOrderQuantity.Caption = "ادنى كمية"
        Me.colReOrderQuantity.FieldName = "ReOrderQuantity"
        Me.colReOrderQuantity.Name = "colReOrderQuantity"
        '
        'colLastPurchasePrice
        '
        Me.colLastPurchasePrice.Caption = "تاريخ اخر سعر شراء"
        Me.colLastPurchasePrice.FieldName = "LastPurchaseDate"
        Me.colLastPurchasePrice.Name = "colLastPurchasePrice"
        '
        'colWithAdditions
        '
        Me.colWithAdditions.FieldName = "WithAdditions"
        Me.colWithAdditions.MinWidth = 17
        Me.colWithAdditions.Name = "colWithAdditions"
        '
        'colUseBatchNo
        '
        Me.colUseBatchNo.FieldName = "UseBatchNo"
        Me.colUseBatchNo.MinWidth = 17
        Me.colUseBatchNo.Name = "colUseBatchNo"
        '
        'colSaleOnScale
        '
        Me.colSaleOnScale.FieldName = "SaleOnScale"
        Me.colSaleOnScale.MinWidth = 17
        Me.colSaleOnScale.Name = "colSaleOnScale"
        '
        'colSaleOnSamba
        '
        Me.colSaleOnSamba.FieldName = "SaleOnSamba"
        Me.colSaleOnSamba.MinWidth = 17
        Me.colSaleOnSamba.Name = "colSaleOnSamba"
        '
        'colAccSales
        '
        Me.colAccSales.Caption = "حساب المبيعات"
        Me.colAccSales.FieldName = "AccSales"
        Me.colAccSales.MinWidth = 17
        Me.colAccSales.Name = "colAccSales"
        Me.colAccSales.Width = 64
        '
        'colAccPurches
        '
        Me.colAccPurches.Caption = "حساب المشتريات"
        Me.colAccPurches.FieldName = "AccPurches"
        Me.colAccPurches.MinWidth = 17
        Me.colAccPurches.Name = "colAccPurches"
        Me.colAccPurches.Width = 64
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'RepositoryItemMemoExEdit1
        '
        Me.RepositoryItemMemoExEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemMemoExEdit1.Name = "RepositoryItemMemoExEdit1"
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
        Me.DockPanel1.ID = New System.Guid("3eedf862-3929-440b-82be-4a5e6d66ef37")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(200, 550)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 38)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(193, 509)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.RefreshBut)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(193, 509)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(16, 16)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(161, 28)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "الثوابت"
        '
        'RefreshBut
        '
        Me.RefreshBut.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.RefreshBut.Appearance.Options.UseBackColor = True
        Me.RefreshBut.Location = New System.Drawing.Point(16, 431)
        Me.RefreshBut.Name = "RefreshBut"
        Me.RefreshBut.Size = New System.Drawing.Size(161, 28)
        Me.RefreshBut.StyleController = Me.LayoutControl1
        Me.RefreshBut.TabIndex = 5
        Me.RefreshBut.Text = "تحديث القائمة"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 465)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(161, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "حفظ التعديلات"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(193, 509)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 449)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(167, 34)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 34)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(167, 381)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(167, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.RefreshBut
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 415)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(167, 34)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'PopupMenu1
        '
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'colLastPurchasePrice1
        '
        Me.colLastPurchasePrice1.Caption = "اخر سعر شراء"
        Me.colLastPurchasePrice1.FieldName = "LastPurchasePrice"
        Me.colLastPurchasePrice1.Name = "colLastPurchasePrice1"
        '
        'ItemsListForUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 550)
        Me.Controls.Add(Me.ItemsGridControl)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "ItemsListForUpdate"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "شاشة تعديل الأصناف"
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryGroups, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsCategoriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryTradeMark, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsTradeMarkBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckItemStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoExEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents ItemsBindingSource As BindingSource
    Friend WithEvents ItemsTableAdapter As AccountingDataSetTableAdapters.ItemsTableAdapter
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ItemsGroupsTableAdapter As AccountingDataSetTableAdapters.ItemsGroupsTableAdapter
    Friend WithEvents ItemsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colItemNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryGroups As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colCategoryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCategory As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colTradeMarkID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryTradeMark As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ItemsGroupsBindingSource As BindingSource
    Friend WithEvents ItemsCategoriesTableAdapter As AccountingDataSetTableAdapters.ItemsCategoriesTableAdapter
    Friend WithEvents ItemsCategoriesBindingSource As BindingSource
    Friend WithEvents ItemsTradeMarkTableAdapter As AccountingDataSetTableAdapters.ItemsTradeMarkTableAdapter
    Friend WithEvents ItemsTradeMarkBindingSource As BindingSource
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents RefreshBut As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RepositoryItemMemoExEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit
    Friend WithEvents colItemStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckItemStatus As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colHasProductionEquation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVisibleInAPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMaxQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReOrderQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastPurchasePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWithAdditions As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUseBatchNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSaleOnScale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSaleOnSamba As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccSales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccPurches As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLastPurchasePrice1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
