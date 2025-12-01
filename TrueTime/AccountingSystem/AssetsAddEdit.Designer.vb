<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssetsAddEdit
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
        Me.DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        Me.TextNewOld = New DevExpress.XtraEditors.TextEdit()
        Me.ItemNoTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.AssetCodeTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.AssetNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.AssetLocationTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.CostTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.PurchaseDateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.DepreciationPercentageTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.NotesTextEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.AssetsMainAccount = New DevExpress.XtraEditors.LookUpEdit()
        Me.FinancialAccounts1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.AssetsDepAccount = New DevExpress.XtraEditors.LookUpEdit()
        Me.AssetsAccumulatedAccount = New DevExpress.XtraEditors.LookUpEdit()
        Me.AssetTypeLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.AssetsTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAssetType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.ItemForCost = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForPurchaseDate = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ItemForDepreciationPercentage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.ItemForAssetName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForAssetLocation = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForAssetCode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ItemForAssetType = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AssetsTypeTableAdapter = New TrueTime.AccountingDataSetTableAdapters.AssetsTypeTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.FinancialAccounts1TableAdapter = New TrueTime.AccountingDataSetTableAdapters.FinancialAccounts1TableAdapter()
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DataLayoutControl1.SuspendLayout()
        CType(Me.TextNewOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemNoTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetCodeTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetLocationTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CostTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PurchaseDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepreciationPercentageTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotesTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetsMainAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinancialAccounts1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetsDepAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetsAccumulatedAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetTypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetsTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForPurchaseDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForDepreciationPercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForAssetName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForAssetLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForAssetCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForAssetType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataLayoutControl1
        '
        Me.DataLayoutControl1.Controls.Add(Me.TextNewOld)
        Me.DataLayoutControl1.Controls.Add(Me.ItemNoTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.DataLayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.DataLayoutControl1.Controls.Add(Me.AssetCodeTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.AssetNameTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.AssetLocationTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.CostTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.PurchaseDateDateEdit)
        Me.DataLayoutControl1.Controls.Add(Me.DepreciationPercentageTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.NotesTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.AssetsMainAccount)
        Me.DataLayoutControl1.Controls.Add(Me.AssetsDepAccount)
        Me.DataLayoutControl1.Controls.Add(Me.AssetsAccumulatedAccount)
        Me.DataLayoutControl1.Controls.Add(Me.AssetTypeLookUpEdit)
        Me.DataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataLayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.DataLayoutControl1.Name = "DataLayoutControl1"
        Me.DataLayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.DataLayoutControl1.Root = Me.Root
        Me.DataLayoutControl1.Size = New System.Drawing.Size(882, 502)
        Me.DataLayoutControl1.TabIndex = 0
        Me.DataLayoutControl1.Text = "DataLayoutControl1"
        '
        'TextNewOld
        '
        Me.TextNewOld.Location = New System.Drawing.Point(443, 49)
        Me.TextNewOld.Name = "TextNewOld"
        Me.TextNewOld.Size = New System.Drawing.Size(298, 20)
        Me.TextNewOld.StyleController = Me.DataLayoutControl1
        Me.TextNewOld.TabIndex = 21
        '
        'ItemNoTextEdit
        '
        Me.ItemNoTextEdit.Location = New System.Drawing.Point(24, 49)
        Me.ItemNoTextEdit.Name = "ItemNoTextEdit"
        Me.ItemNoTextEdit.Size = New System.Drawing.Size(298, 20)
        Me.ItemNoTextEdit.StyleController = Me.DataLayoutControl1
        Me.ItemNoTextEdit.TabIndex = 20
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton3.Appearance.Options.UseBackColor = True
        Me.SimpleButton3.Location = New System.Drawing.Point(12, 468)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(172, 22)
        Me.SimpleButton3.StyleController = Me.DataLayoutControl1
        Me.SimpleButton3.TabIndex = 16
        Me.SimpleButton3.Text = "حذف"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(699, 468)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(171, 22)
        Me.SimpleButton1.StyleController = Me.DataLayoutControl1
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "حفظ"
        '
        'AssetCodeTextEdit
        '
        Me.AssetCodeTextEdit.Location = New System.Drawing.Point(24, 73)
        Me.AssetCodeTextEdit.Name = "AssetCodeTextEdit"
        Me.AssetCodeTextEdit.Size = New System.Drawing.Size(132, 20)
        Me.AssetCodeTextEdit.StyleController = Me.DataLayoutControl1
        Me.AssetCodeTextEdit.TabIndex = 5
        '
        'AssetNameTextEdit
        '
        Me.AssetNameTextEdit.Location = New System.Drawing.Point(277, 73)
        Me.AssetNameTextEdit.Name = "AssetNameTextEdit"
        Me.AssetNameTextEdit.Size = New System.Drawing.Size(464, 20)
        Me.AssetNameTextEdit.StyleController = Me.DataLayoutControl1
        Me.AssetNameTextEdit.TabIndex = 6
        '
        'AssetLocationTextEdit
        '
        Me.AssetLocationTextEdit.Location = New System.Drawing.Point(24, 193)
        Me.AssetLocationTextEdit.Name = "AssetLocationTextEdit"
        Me.AssetLocationTextEdit.Size = New System.Drawing.Size(717, 20)
        Me.AssetLocationTextEdit.StyleController = Me.DataLayoutControl1
        Me.AssetLocationTextEdit.TabIndex = 7
        '
        'CostTextEdit
        '
        Me.CostTextEdit.Location = New System.Drawing.Point(443, 266)
        Me.CostTextEdit.Name = "CostTextEdit"
        Me.CostTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.CostTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.CostTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.CostTextEdit.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.CostTextEdit.Properties.MaskSettings.Set("mask", "G")
        Me.CostTextEdit.Properties.ReadOnly = True
        Me.CostTextEdit.Size = New System.Drawing.Size(298, 20)
        Me.CostTextEdit.StyleController = Me.DataLayoutControl1
        Me.CostTextEdit.TabIndex = 8
        '
        'PurchaseDateDateEdit
        '
        Me.PurchaseDateDateEdit.EditValue = Nothing
        Me.PurchaseDateDateEdit.Location = New System.Drawing.Point(443, 290)
        Me.PurchaseDateDateEdit.Name = "PurchaseDateDateEdit"
        Me.PurchaseDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PurchaseDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.PurchaseDateDateEdit.Properties.MaskSettings.Set("mask", "HH:mm yyyy-MM-dd")
        Me.PurchaseDateDateEdit.Properties.ReadOnly = True
        Me.PurchaseDateDateEdit.Size = New System.Drawing.Size(298, 20)
        Me.PurchaseDateDateEdit.StyleController = Me.DataLayoutControl1
        Me.PurchaseDateDateEdit.TabIndex = 9
        '
        'DepreciationPercentageTextEdit
        '
        Me.DepreciationPercentageTextEdit.Location = New System.Drawing.Point(443, 314)
        Me.DepreciationPercentageTextEdit.Name = "DepreciationPercentageTextEdit"
        Me.DepreciationPercentageTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.DepreciationPercentageTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DepreciationPercentageTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DepreciationPercentageTextEdit.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.DepreciationPercentageTextEdit.Properties.MaskSettings.Set("mask", "G")
        Me.DepreciationPercentageTextEdit.Size = New System.Drawing.Size(298, 20)
        Me.DepreciationPercentageTextEdit.StyleController = Me.DataLayoutControl1
        Me.DepreciationPercentageTextEdit.TabIndex = 10
        '
        'NotesTextEdit
        '
        Me.NotesTextEdit.Location = New System.Drawing.Point(12, 350)
        Me.NotesTextEdit.Name = "NotesTextEdit"
        Me.NotesTextEdit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.NotesTextEdit.Properties.Appearance.Options.UseBackColor = True
        Me.NotesTextEdit.Size = New System.Drawing.Size(741, 114)
        Me.NotesTextEdit.StyleController = Me.DataLayoutControl1
        Me.NotesTextEdit.TabIndex = 15
        '
        'AssetsMainAccount
        '
        Me.AssetsMainAccount.Location = New System.Drawing.Point(443, 133)
        Me.AssetsMainAccount.Name = "AssetsMainAccount"
        Me.AssetsMainAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AssetsMainAccount.Properties.DataSource = Me.FinancialAccounts1BindingSource
        Me.AssetsMainAccount.Properties.DisplayMember = "AccName"
        Me.AssetsMainAccount.Properties.NullText = ""
        Me.AssetsMainAccount.Properties.ReadOnly = True
        Me.AssetsMainAccount.Properties.ValueMember = "AccNo"
        Me.AssetsMainAccount.Size = New System.Drawing.Size(286, 20)
        Me.AssetsMainAccount.StyleController = Me.DataLayoutControl1
        Me.AssetsMainAccount.TabIndex = 17
        '
        'FinancialAccounts1BindingSource
        '
        Me.FinancialAccounts1BindingSource.DataMember = "FinancialAccounts1"
        Me.FinancialAccounts1BindingSource.DataSource = Me.AccountingDataSet
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AssetsDepAccount
        '
        Me.AssetsDepAccount.Location = New System.Drawing.Point(36, 133)
        Me.AssetsDepAccount.Name = "AssetsDepAccount"
        Me.AssetsDepAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AssetsDepAccount.Properties.DataSource = Me.FinancialAccounts1BindingSource
        Me.AssetsDepAccount.Properties.DisplayMember = "AccName"
        Me.AssetsDepAccount.Properties.NullText = ""
        Me.AssetsDepAccount.Properties.ReadOnly = True
        Me.AssetsDepAccount.Properties.ValueMember = "AccNo"
        Me.AssetsDepAccount.Size = New System.Drawing.Size(286, 20)
        Me.AssetsDepAccount.StyleController = Me.DataLayoutControl1
        Me.AssetsDepAccount.TabIndex = 19
        '
        'AssetsAccumulatedAccount
        '
        Me.AssetsAccumulatedAccount.Location = New System.Drawing.Point(443, 157)
        Me.AssetsAccumulatedAccount.Name = "AssetsAccumulatedAccount"
        Me.AssetsAccumulatedAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AssetsAccumulatedAccount.Properties.DataSource = Me.FinancialAccounts1BindingSource
        Me.AssetsAccumulatedAccount.Properties.DisplayMember = "AccName"
        Me.AssetsAccumulatedAccount.Properties.NullText = ""
        Me.AssetsAccumulatedAccount.Properties.ReadOnly = True
        Me.AssetsAccumulatedAccount.Properties.ValueMember = "AccNo"
        Me.AssetsAccumulatedAccount.Size = New System.Drawing.Size(286, 20)
        Me.AssetsAccumulatedAccount.StyleController = Me.DataLayoutControl1
        Me.AssetsAccumulatedAccount.TabIndex = 18
        '
        'AssetTypeLookUpEdit
        '
        Me.AssetTypeLookUpEdit.Location = New System.Drawing.Point(443, 109)
        Me.AssetTypeLookUpEdit.Name = "AssetTypeLookUpEdit"
        Me.AssetTypeLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.AssetTypeLookUpEdit.Properties.DataSource = Me.AssetsTypeBindingSource
        Me.AssetTypeLookUpEdit.Properties.DisplayMember = "AssetType"
        Me.AssetTypeLookUpEdit.Properties.NullText = ""
        Me.AssetTypeLookUpEdit.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.AssetTypeLookUpEdit.Properties.ShowAddNewButton = True
        Me.AssetTypeLookUpEdit.Properties.ValueMember = "ID"
        Me.AssetTypeLookUpEdit.Size = New System.Drawing.Size(286, 20)
        Me.AssetTypeLookUpEdit.StyleController = Me.DataLayoutControl1
        Me.AssetTypeLookUpEdit.TabIndex = 11
        '
        'AssetsTypeBindingSource
        '
        Me.AssetsTypeBindingSource.DataMember = "AssetsType"
        Me.AssetsTypeBindingSource.DataSource = Me.AccountingDataSet
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAssetType})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsFind.ShowClearButton = False
        Me.SearchLookUpEdit1View.OptionsNavigation.AutoFocusNewRow = True
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colAssetType
        '
        Me.colAssetType.Caption = "نوع الأصل"
        Me.colAssetType.FieldName = "AssetType"
        Me.colAssetType.Name = "colAssetType"
        Me.colAssetType.Visible = True
        Me.colAssetType.VisibleIndex = 0
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(882, 502)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowDrawBackground = False
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.EmptySpaceItem2, Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "autoGeneratedGroup0"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(862, 482)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForCost, Me.ItemForPurchaseDate, Me.EmptySpaceItem3, Me.EmptySpaceItem5, Me.EmptySpaceItem4, Me.ItemForDepreciationPercentage})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 217)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(862, 121)
        Me.LayoutControlGroup2.Text = "البيانات المالية"
        '
        'ItemForCost
        '
        Me.ItemForCost.Control = Me.CostTextEdit
        Me.ItemForCost.Location = New System.Drawing.Point(419, 0)
        Me.ItemForCost.Name = "ItemForCost"
        Me.ItemForCost.Size = New System.Drawing.Size(419, 24)
        Me.ItemForCost.Text = "التكلفة بعملة الأساس:"
        Me.ItemForCost.TextSize = New System.Drawing.Size(105, 13)
        '
        'ItemForPurchaseDate
        '
        Me.ItemForPurchaseDate.Control = Me.PurchaseDateDateEdit
        Me.ItemForPurchaseDate.Location = New System.Drawing.Point(419, 24)
        Me.ItemForPurchaseDate.Name = "ItemForPurchaseDate"
        Me.ItemForPurchaseDate.Size = New System.Drawing.Size(419, 24)
        Me.ItemForPurchaseDate.Text = "تاريخ الشراء:"
        Me.ItemForPurchaseDate.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 48)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(419, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(419, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(419, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'ItemForDepreciationPercentage
        '
        Me.ItemForDepreciationPercentage.Control = Me.DepreciationPercentageTextEdit
        Me.ItemForDepreciationPercentage.Location = New System.Drawing.Point(419, 48)
        Me.ItemForDepreciationPercentage.Name = "ItemForDepreciationPercentage"
        Me.ItemForDepreciationPercentage.Size = New System.Drawing.Size(419, 24)
        Me.ItemForDepreciationPercentage.Text = "نسبة الاستهلاك (%) :"
        Me.ItemForDepreciationPercentage.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForAssetName, Me.ItemForAssetLocation, Me.LayoutControlItem9, Me.LayoutControlItem2, Me.ItemForAssetCode, Me.LayoutControlGroup4})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(862, 217)
        Me.LayoutControlGroup3.Text = "بيانات الأصل"
        '
        'ItemForAssetName
        '
        Me.ItemForAssetName.Control = Me.AssetNameTextEdit
        Me.ItemForAssetName.Location = New System.Drawing.Point(253, 24)
        Me.ItemForAssetName.Name = "ItemForAssetName"
        Me.ItemForAssetName.Size = New System.Drawing.Size(585, 24)
        Me.ItemForAssetName.Text = "اسم الأصل:"
        Me.ItemForAssetName.TextSize = New System.Drawing.Size(105, 13)
        '
        'ItemForAssetLocation
        '
        Me.ItemForAssetLocation.Control = Me.AssetLocationTextEdit
        Me.ItemForAssetLocation.Location = New System.Drawing.Point(0, 144)
        Me.ItemForAssetLocation.Name = "ItemForAssetLocation"
        Me.ItemForAssetLocation.Size = New System.Drawing.Size(838, 24)
        Me.ItemForAssetLocation.Text = "الموقع"
        Me.ItemForAssetLocation.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ItemNoTextEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(419, 24)
        Me.LayoutControlItem9.Text = "Item No:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(105, 13)
        Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextNewOld
        Me.LayoutControlItem2.Location = New System.Drawing.Point(419, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(419, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(105, 13)
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'ItemForAssetCode
        '
        Me.ItemForAssetCode.Control = Me.AssetCodeTextEdit
        Me.ItemForAssetCode.Location = New System.Drawing.Point(0, 24)
        Me.ItemForAssetCode.MaxSize = New System.Drawing.Size(253, 24)
        Me.ItemForAssetCode.MinSize = New System.Drawing.Size(253, 24)
        Me.ItemForAssetCode.Name = "ItemForAssetCode"
        Me.ItemForAssetCode.Size = New System.Drawing.Size(253, 24)
        Me.ItemForAssetCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.ItemForAssetCode.Text = "كود الأصل:"
        Me.ItemForAssetCode.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.ItemForAssetType, Me.EmptySpaceItem6})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(838, 96)
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.AssetsMainAccount
        Me.LayoutControlItem5.Location = New System.Drawing.Point(407, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(407, 24)
        Me.LayoutControlItem5.Text = "ح/ الأصول"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.AssetsDepAccount
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(407, 24)
        Me.LayoutControlItem7.Text = "ح/مصروف الاستهلاك:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.AssetsAccumulatedAccount
        Me.LayoutControlItem6.Location = New System.Drawing.Point(407, 48)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(407, 24)
        Me.LayoutControlItem6.Text = "ح/ اجمالي الاستهلاك"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 48)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(407, 24)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'ItemForAssetType
        '
        Me.ItemForAssetType.Control = Me.AssetTypeLookUpEdit
        Me.ItemForAssetType.Location = New System.Drawing.Point(407, 0)
        Me.ItemForAssetType.Name = "ItemForAssetType"
        Me.ItemForAssetType.Size = New System.Drawing.Size(407, 24)
        Me.ItemForAssetType.Text = "نوع الأصل"
        Me.ItemForAssetType.TextSize = New System.Drawing.Size(105, 13)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(407, 24)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(176, 456)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(511, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.NotesTextEdit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 338)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(862, 118)
        Me.LayoutControlItem4.Text = "ملاحظات:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(105, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(687, 456)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(175, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(175, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(175, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton3
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 456)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(176, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(176, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(176, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'AssetsTypeTableAdapter
        '
        Me.AssetsTypeTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountingBranchesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPOSNamesTableAdapter = Nothing
        Me.TableAdapterManager.AppointmentsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTypeTableAdapter = Me.AssetsTypeTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CRMTaskStatusesTableAdapter = Nothing
        Me.TableAdapterManager.DocNamesTableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccounts1TableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccountsTableAdapter = Nothing
        Me.TableAdapterManager.Items_unitsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsCategoriesTableAdapter = Nothing
        Me.TableAdapterManager.ItemsColorsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsMeasuresTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTradeMarkTableAdapter = Nothing
        Me.TableAdapterManager.PatientsVisitsTableAdapter = Nothing
        Me.TableAdapterManager.ProductionEquationTableAdapter = Nothing
        Me.TableAdapterManager.RefCitiesTableAdapter = Nothing
        Me.TableAdapterManager.ReferancesListTableAdapter = Nothing
        Me.TableAdapterManager.ReferencessTableAdapter = Nothing
        Me.TableAdapterManager.ReferencesTypesTableAdapter = Nothing
        Me.TableAdapterManager.RefSortsTableAdapter = Nothing
        Me.TableAdapterManager.ResourcesTableAdapter = Nothing
        Me.TableAdapterManager.UnitsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.Vehicle_MaintenanceTableAdapter = Nothing
        Me.TableAdapterManager.WarehousesTableAdapter = Nothing
        '
        'FinancialAccounts1TableAdapter
        '
        Me.FinancialAccounts1TableAdapter.ClearBeforeFill = True
        '
        'AssetsAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 502)
        Me.Controls.Add(Me.DataLayoutControl1)
        Me.Name = "AssetsAddEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة / تعديل أصل"
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DataLayoutControl1.ResumeLayout(False)
        CType(Me.TextNewOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemNoTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetCodeTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetLocationTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CostTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PurchaseDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepreciationPercentageTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotesTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetsMainAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinancialAccounts1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetsDepAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetsAccumulatedAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetTypeLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetsTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForPurchaseDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForDepreciationPercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForAssetName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForAssetLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForAssetCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForAssetType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents AssetCodeTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AssetNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents AssetLocationTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CostTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PurchaseDateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DepreciationPercentageTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ItemForAssetCode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForAssetName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForAssetLocation As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForCost As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForPurchaseDate As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForDepreciationPercentage As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForAssetType As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AssetsTypeBindingSource As BindingSource
    Friend WithEvents AssetsTypeTableAdapter As AccountingDataSetTableAdapters.AssetsTypeTableAdapter
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents NotesTextEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AssetsMainAccount As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents FinancialAccounts1BindingSource As BindingSource
    Friend WithEvents FinancialAccounts1TableAdapter As AccountingDataSetTableAdapters.FinancialAccounts1TableAdapter
    Friend WithEvents AssetsDepAccount As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents AssetsAccumulatedAccount As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ItemNoTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextNewOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AssetTypeLookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAssetType As DevExpress.XtraGrid.Columns.GridColumn
End Class
