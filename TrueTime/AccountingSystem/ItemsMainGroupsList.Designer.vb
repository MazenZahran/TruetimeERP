<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsMainGroupsList
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
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsMainGroupsList))
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.ItemsGroupsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsGroupsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsGroupsTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.ItemsGroupsGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colGroupID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGroupName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsGroupsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsGroupsGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemsGroupsBindingSource
        '
        Me.ItemsGroupsBindingSource.DataMember = "ItemsGroups"
        Me.ItemsGroupsBindingSource.DataSource = Me.AccountingDataSet
        '
        'ItemsGroupsTableAdapter
        '
        Me.ItemsGroupsTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.ItemsCategoriesTableAdapter = Nothing
        Me.TableAdapterManager.ItemsColorsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Me.ItemsGroupsTableAdapter
        Me.TableAdapterManager.ItemsMeasuresTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTradeMarkTableAdapter = Nothing
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
        'ItemsGroupsGridControl
        '
        Me.ItemsGroupsGridControl.DataSource = Me.ItemsGroupsBindingSource
        Me.ItemsGroupsGridControl.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ItemsGroupsGridControl.Location = New System.Drawing.Point(14, 42)
        Me.ItemsGroupsGridControl.MainView = Me.GridView1
        Me.ItemsGroupsGridControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ItemsGroupsGridControl.Name = "ItemsGroupsGridControl"
        Me.ItemsGroupsGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryEdit})
        Me.ItemsGroupsGridControl.Size = New System.Drawing.Size(553, 271)
        Me.ItemsGroupsGridControl.TabIndex = 1
        Me.ItemsGroupsGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colGroupID, Me.colGroupName, Me.GridColumn1})
        Me.GridView1.DetailHeight = 268
        Me.GridView1.GridControl = Me.ItemsGroupsGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colGroupID
        '
        Me.colGroupID.Caption = "رقم"
        Me.colGroupID.FieldName = "GroupID"
        Me.colGroupID.MinWidth = 17
        Me.colGroupID.Name = "colGroupID"
        Me.colGroupID.OptionsColumn.ReadOnly = True
        Me.colGroupID.Width = 117
        '
        'colGroupName
        '
        Me.colGroupName.Caption = "المجموعة"
        Me.colGroupName.FieldName = "GroupName"
        Me.colGroupName.MinWidth = 17
        Me.colGroupName.Name = "colGroupName"
        Me.colGroupName.OptionsColumn.ReadOnly = True
        Me.colGroupName.Visible = True
        Me.colGroupName.VisibleIndex = 0
        Me.colGroupName.Width = 374
        '
        'GridColumn1
        '
        Me.GridColumn1.ColumnEdit = Me.RepositoryEdit
        Me.GridColumn1.MinWidth = 17
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 51
        '
        'RepositoryEdit
        '
        Me.RepositoryEdit.AutoHeight = False
        EditorButtonImageOptions3.SvgImage = CType(resources.GetObject("EditorButtonImageOptions3.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.RepositoryEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryEdit.Name = "RepositoryEdit"
        Me.RepositoryEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.ItemsGroupsGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(581, 356)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton1.Location = New System.Drawing.Point(414, 317)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(153, 27)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "اضافة جديد"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.EmptySpaceItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(581, 356)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ItemsGroupsGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(559, 275)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(559, 30)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(400, 305)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(159, 31)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(159, 31)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(159, 31)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 305)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(400, 31)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'ItemsMainGroupsList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 356)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("ItemsMainGroupsList.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ItemsMainGroupsList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مجموعات الاصناف"
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsGroupsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsGroupsGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents ItemsGroupsBindingSource As BindingSource
    Friend WithEvents ItemsGroupsTableAdapter As AccountingDataSetTableAdapters.ItemsGroupsTableAdapter
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ItemsGroupsGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colGroupID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGroupName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
