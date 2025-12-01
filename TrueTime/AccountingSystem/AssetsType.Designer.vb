<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AssetsType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssetsType))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.AssetsTypeGridControl = New DevExpress.XtraGrid.GridControl()
        Me.AssetsTypeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetsMainAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSearchLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.FinancialAccountsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colAccNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetsDepAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAssetsAccumulatedAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.AssetsTypeTableAdapter = New TrueTime.AccountingDataSetTableAdapters.AssetsTypeTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.FinancialAccountsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.FinancialAccountsTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.AssetsTypeGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AssetsTypeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinancialAccountsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.AssetsTypeGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(869, 484)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 450)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(170, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "حفظ"
        '
        'AssetsTypeGridControl
        '
        Me.AssetsTypeGridControl.DataSource = Me.AssetsTypeBindingSource
        Me.AssetsTypeGridControl.Location = New System.Drawing.Point(12, 12)
        Me.AssetsTypeGridControl.MainView = Me.GridView1
        Me.AssetsTypeGridControl.Name = "AssetsTypeGridControl"
        Me.AssetsTypeGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSearchLookUpEdit1})
        Me.AssetsTypeGridControl.Size = New System.Drawing.Size(845, 434)
        Me.AssetsTypeGridControl.TabIndex = 4
        Me.AssetsTypeGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'AssetsTypeBindingSource
        '
        Me.AssetsTypeBindingSource.DataMember = "AssetsType"
        Me.AssetsTypeBindingSource.DataSource = Me.AccountingDataSet
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colAssetType, Me.colAssetsMainAccount, Me.colAssetsDepAccount, Me.colAssetsAccumulatedAccount})
        Me.GridView1.GridControl = Me.AssetsTypeGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.NewItemRowText = "اضغط هنا لاضافة جديد"
        Me.GridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.GridView1.OptionsEditForm.EditFormColumnCount = 1
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsPrint.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.EnableAppearanceOddRow = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.OptionsColumn.FixedWidth = True
        Me.colID.OptionsColumn.ShowInExpressionEditor = False
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        Me.colID.Width = 48
        '
        'colAssetType
        '
        Me.colAssetType.Caption = "النوع"
        Me.colAssetType.FieldName = "AssetType"
        Me.colAssetType.Name = "colAssetType"
        Me.colAssetType.Visible = True
        Me.colAssetType.VisibleIndex = 1
        Me.colAssetType.Width = 210
        '
        'colAssetsMainAccount
        '
        Me.colAssetsMainAccount.Caption = "حساب الأصل"
        Me.colAssetsMainAccount.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.colAssetsMainAccount.FieldName = "AssetsMainAccount"
        Me.colAssetsMainAccount.Name = "colAssetsMainAccount"
        Me.colAssetsMainAccount.Visible = True
        Me.colAssetsMainAccount.VisibleIndex = 2
        Me.colAssetsMainAccount.Width = 210
        '
        'RepositoryItemSearchLookUpEdit1
        '
        Me.RepositoryItemSearchLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit1.DataSource = Me.FinancialAccountsBindingSource
        Me.RepositoryItemSearchLookUpEdit1.DisplayMember = "AccName"
        Me.RepositoryItemSearchLookUpEdit1.Name = "RepositoryItemSearchLookUpEdit1"
        Me.RepositoryItemSearchLookUpEdit1.NullText = ""
        Me.RepositoryItemSearchLookUpEdit1.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.RepositoryItemSearchLookUpEdit1.ValueMember = "AccNo"
        '
        'FinancialAccountsBindingSource
        '
        Me.FinancialAccountsBindingSource.DataMember = "FinancialAccounts"
        Me.FinancialAccountsBindingSource.DataSource = Me.AccountingDataSet
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colAccNo, Me.colAccName})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colAccNo
        '
        Me.colAccNo.FieldName = "AccNo"
        Me.colAccNo.MaxWidth = 120
        Me.colAccNo.Name = "colAccNo"
        Me.colAccNo.Visible = True
        Me.colAccNo.VisibleIndex = 0
        '
        'colAccName
        '
        Me.colAccName.FieldName = "AccName"
        Me.colAccName.Name = "colAccName"
        Me.colAccName.Visible = True
        Me.colAccName.VisibleIndex = 1
        '
        'colAssetsDepAccount
        '
        Me.colAssetsDepAccount.Caption = "حساب مصروف الاستهلاك"
        Me.colAssetsDepAccount.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.colAssetsDepAccount.FieldName = "AssetsDepAccount"
        Me.colAssetsDepAccount.Name = "colAssetsDepAccount"
        Me.colAssetsDepAccount.Visible = True
        Me.colAssetsDepAccount.VisibleIndex = 3
        Me.colAssetsDepAccount.Width = 212
        '
        'colAssetsAccumulatedAccount
        '
        Me.colAssetsAccumulatedAccount.Caption = "حساب اجمالي الاستهلاك"
        Me.colAssetsAccumulatedAccount.ColumnEdit = Me.RepositoryItemSearchLookUpEdit1
        Me.colAssetsAccumulatedAccount.FieldName = "AssetsAccumulatedAccount"
        Me.colAssetsAccumulatedAccount.Name = "colAssetsAccumulatedAccount"
        Me.colAssetsAccumulatedAccount.Visible = True
        Me.colAssetsAccumulatedAccount.VisibleIndex = 4
        Me.colAssetsAccumulatedAccount.Width = 138
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(869, 484)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.AssetsTypeGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(849, 438)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 438)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(174, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(174, 438)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(675, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'AssetsTypeTableAdapter
        '
        Me.AssetsTypeTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
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
        Me.TableAdapterManager.RefCitiesTableAdapter = Nothing
        Me.TableAdapterManager.ReferancesListTableAdapter = Nothing
        Me.TableAdapterManager.ReferencessTableAdapter = Nothing
        Me.TableAdapterManager.ReferencesTypesTableAdapter = Nothing
        Me.TableAdapterManager.RefSortsTableAdapter = Nothing
        Me.TableAdapterManager.ResourcesTableAdapter = Nothing
        Me.TableAdapterManager.UnitsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FinancialAccountsTableAdapter
        '
        Me.FinancialAccountsTableAdapter.ClearBeforeFill = True
        '
        'AssetsType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 484)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("AssetsType.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "AssetsType"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "أنواع الأصول"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.AssetsTypeGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AssetsTypeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinancialAccountsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents AssetsTypeBindingSource As BindingSource
    Friend WithEvents AssetsTypeTableAdapter As AccountingDataSetTableAdapters.AssetsTypeTableAdapter
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AssetsTypeGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetsMainAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAssetsDepAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents FinancialAccountsBindingSource As BindingSource
    Friend WithEvents FinancialAccountsTableAdapter As AccountingDataSetTableAdapters.FinancialAccountsTableAdapter
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents colAssetsAccumulatedAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSearchLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colAccNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccName As DevExpress.XtraGrid.Columns.GridColumn
End Class
