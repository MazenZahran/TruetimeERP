<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosNames
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosNames))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.AccountingPOSNamesGridControl = New DevExpress.XtraGrid.GridControl()
        Me.AccountingPOSNamesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOSCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOSName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCostCenter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrefixCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBranchID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWarehouse = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOnlineOnly = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNote1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNote2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaperSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOpenCashDrawerOnSave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPOSQr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colServerAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDefaultPrinter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTickets = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUseDirectProduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSamabaPos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTempAccounting = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryTempAccounting = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemsGroups = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPosType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositortPosTypes = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.AccountingPosTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountingDataSet1 = New TrueTime.AccountingDataSet()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.AccountingPOSNamesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.AccountingPOSNamesTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.AccountingPOSNamesGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingPOSNamesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryTempAccounting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositortPosTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingPosTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.AccountingPOSNamesGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(736, 550)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton3.Appearance.Options.UseBackColor = True
        Me.SimpleButton3.Location = New System.Drawing.Point(11, 10)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(153, 22)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 7
        Me.SimpleButton3.Text = "حذف"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(415, 10)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(153, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "جديد"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(572, 10)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(153, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "حفظ"
        '
        'AccountingPOSNamesGridControl
        '
        Me.AccountingPOSNamesGridControl.DataSource = Me.AccountingPOSNamesBindingSource
        Me.AccountingPOSNamesGridControl.Location = New System.Drawing.Point(11, 36)
        Me.AccountingPOSNamesGridControl.MainView = Me.GridView1
        Me.AccountingPOSNamesGridControl.Name = "AccountingPOSNamesGridControl"
        Me.AccountingPOSNamesGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryTempAccounting, Me.RepositortPosTypes})
        Me.AccountingPOSNamesGridControl.Size = New System.Drawing.Size(714, 504)
        Me.AccountingPOSNamesGridControl.TabIndex = 4
        Me.AccountingPOSNamesGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'AccountingPOSNamesBindingSource
        '
        Me.AccountingPOSNamesBindingSource.DataMember = "AccountingPOSNames"
        Me.AccountingPOSNamesBindingSource.DataSource = Me.AccountingDataSet
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colPOSCode, Me.colPOSName, Me.colCostCenter, Me.colPrefixCode, Me.colBranchID, Me.colWarehouse, Me.colOnlineOnly, Me.colNote1, Me.colNote2, Me.colPaperSize, Me.colOpenCashDrawerOnSave, Me.colPOSQr, Me.colServerAddress, Me.colDefaultPrinter, Me.colTickets, Me.colUseDirectProduction, Me.colSamabaPos, Me.colTempAccounting, Me.colItemsGroups, Me.colPosType})
        Me.GridView1.GridControl = Me.AccountingPOSNamesGridControl
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm
        Me.GridView1.OptionsEditForm.EditFormColumnCount = 2
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsPrint.ExpandAllDetails = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colBranchID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colID
        '
        Me.colID.Caption = "رقم"
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'colPOSCode
        '
        Me.colPOSCode.Caption = "كود النقطة"
        Me.colPOSCode.FieldName = "POSCode"
        Me.colPOSCode.Name = "colPOSCode"
        Me.colPOSCode.Visible = True
        Me.colPOSCode.VisibleIndex = 1
        '
        'colPOSName
        '
        Me.colPOSName.Caption = "اسم النقطة"
        Me.colPOSName.FieldName = "POSName"
        Me.colPOSName.Name = "colPOSName"
        Me.colPOSName.Visible = True
        Me.colPOSName.VisibleIndex = 2
        '
        'colCostCenter
        '
        Me.colCostCenter.Caption = "مركز التكلفة"
        Me.colCostCenter.FieldName = "CostCenter"
        Me.colCostCenter.Name = "colCostCenter"
        Me.colCostCenter.Visible = True
        Me.colCostCenter.VisibleIndex = 3
        '
        'colPrefixCode
        '
        Me.colPrefixCode.Caption = "بادئة السندات"
        Me.colPrefixCode.FieldName = "PrefixCode"
        Me.colPrefixCode.Name = "colPrefixCode"
        Me.colPrefixCode.Visible = True
        Me.colPrefixCode.VisibleIndex = 4
        '
        'colBranchID
        '
        Me.colBranchID.Caption = "الفرع"
        Me.colBranchID.FieldName = "BranchID"
        Me.colBranchID.Name = "colBranchID"
        Me.colBranchID.Visible = True
        Me.colBranchID.VisibleIndex = 5
        '
        'colWarehouse
        '
        Me.colWarehouse.Caption = "المستودع:"
        Me.colWarehouse.FieldName = "Warehouse"
        Me.colWarehouse.Name = "colWarehouse"
        Me.colWarehouse.Visible = True
        Me.colWarehouse.VisibleIndex = 5
        '
        'colOnlineOnly
        '
        Me.colOnlineOnly.Caption = "اون لاين:"
        Me.colOnlineOnly.FieldName = "OnlineOnly"
        Me.colOnlineOnly.Name = "colOnlineOnly"
        Me.colOnlineOnly.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colNote1
        '
        Me.colNote1.Caption = "ملاحظات 1:"
        Me.colNote1.FieldName = "Note1"
        Me.colNote1.Name = "colNote1"
        Me.colNote1.OptionsEditForm.StartNewRow = True
        Me.colNote1.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colNote2
        '
        Me.colNote2.Caption = "ملاحظات 2:"
        Me.colNote2.FieldName = "Note2"
        Me.colNote2.Name = "colNote2"
        Me.colNote2.OptionsEditForm.StartNewRow = True
        Me.colNote2.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colPaperSize
        '
        Me.colPaperSize.Caption = "حجم الورق:"
        Me.colPaperSize.FieldName = "PaperSize"
        Me.colPaperSize.Name = "colPaperSize"
        Me.colPaperSize.OptionsEditForm.StartNewRow = True
        Me.colPaperSize.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colOpenCashDrawerOnSave
        '
        Me.colOpenCashDrawerOnSave.Caption = "فتح الكاشير عند الحفظ"
        Me.colOpenCashDrawerOnSave.FieldName = "OpenCashDrawerOnSave"
        Me.colOpenCashDrawerOnSave.Name = "colOpenCashDrawerOnSave"
        Me.colOpenCashDrawerOnSave.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colPOSQr
        '
        Me.colPOSQr.Caption = "QR"
        Me.colPOSQr.FieldName = "POSQr"
        Me.colPOSQr.Name = "colPOSQr"
        Me.colPOSQr.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colServerAddress
        '
        Me.colServerAddress.Caption = "عنوان السيرفر"
        Me.colServerAddress.FieldName = "ServerAddress"
        Me.colServerAddress.Name = "colServerAddress"
        Me.colServerAddress.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colDefaultPrinter
        '
        Me.colDefaultPrinter.Caption = "الطابعة الافتراضية"
        Me.colDefaultPrinter.FieldName = "DefaultPrinter"
        Me.colDefaultPrinter.Name = "colDefaultPrinter"
        Me.colDefaultPrinter.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colTickets
        '
        Me.colTickets.Caption = "تذاكر:"
        Me.colTickets.FieldName = "Tickets"
        Me.colTickets.Name = "colTickets"
        Me.colTickets.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[True]
        '
        'colUseDirectProduction
        '
        Me.colUseDirectProduction.FieldName = "UseDirectProduction"
        Me.colUseDirectProduction.Name = "colUseDirectProduction"
        Me.colUseDirectProduction.Visible = True
        Me.colUseDirectProduction.VisibleIndex = 6
        '
        'colSamabaPos
        '
        Me.colSamabaPos.FieldName = "SamabaPos"
        Me.colSamabaPos.Name = "colSamabaPos"
        Me.colSamabaPos.Visible = True
        Me.colSamabaPos.VisibleIndex = 7
        '
        'colTempAccounting
        '
        Me.colTempAccounting.ColumnEdit = Me.RepositoryTempAccounting
        Me.colTempAccounting.FieldName = "TempAccounting"
        Me.colTempAccounting.Name = "colTempAccounting"
        Me.colTempAccounting.Visible = True
        Me.colTempAccounting.VisibleIndex = 8
        '
        'RepositoryTempAccounting
        '
        Me.RepositoryTempAccounting.AutoHeight = False
        Me.RepositoryTempAccounting.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryTempAccounting.DisplayMember = "AccName"
        Me.RepositoryTempAccounting.Name = "RepositoryTempAccounting"
        Me.RepositoryTempAccounting.NullText = ""
        Me.RepositoryTempAccounting.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.RepositoryTempAccounting.ValueMember = "AccNo"
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "الحساب"
        Me.GridColumn1.FieldName = "AccName"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 300
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "رقم الحساب"
        Me.GridColumn2.FieldName = "AccNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 85
        '
        'colItemsGroups
        '
        Me.colItemsGroups.FieldName = "ItemsGroups"
        Me.colItemsGroups.Name = "colItemsGroups"
        Me.colItemsGroups.Visible = True
        Me.colItemsGroups.VisibleIndex = 9
        '
        'colPosType
        '
        Me.colPosType.ColumnEdit = Me.RepositortPosTypes
        Me.colPosType.FieldName = "PosType"
        Me.colPosType.Name = "colPosType"
        Me.colPosType.Visible = True
        Me.colPosType.VisibleIndex = 10
        '
        'RepositortPosTypes
        '
        Me.RepositortPosTypes.AutoHeight = False
        Me.RepositortPosTypes.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositortPosTypes.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 24, DevExpress.Utils.FormatType.Numeric, "", False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("PosType", "نوع النقطة", 57, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositortPosTypes.DataSource = Me.AccountingPosTypesBindingSource
        Me.RepositortPosTypes.DisplayMember = "PosType"
        Me.RepositortPosTypes.Name = "RepositortPosTypes"
        Me.RepositortPosTypes.NullText = ""
        Me.RepositortPosTypes.ValueMember = "ID"
        '
        'AccountingPosTypesBindingSource
        '
        Me.AccountingPosTypesBindingSource.DataMember = "AccountingPosTypes"
        Me.AccountingPosTypesBindingSource.DataSource = Me.AccountingDataSet1
        '
        'AccountingDataSet1
        '
        Me.AccountingDataSet1.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(736, 550)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.AccountingPOSNamesGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(718, 508)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(561, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(404, 0)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(157, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(247, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SimpleButton3
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(157, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'AccountingPOSNamesTableAdapter
        '
        Me.AccountingPOSNamesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountingBranchesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPOSNamesTableAdapter = Me.AccountingPOSNamesTableAdapter
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
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Nothing
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
        'PosNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 550)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("PosNames.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "PosNames"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "نقاط البيع"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.AccountingPOSNamesGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingPOSNamesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryTempAccounting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositortPosTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingPosTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents AccountingPOSNamesBindingSource As BindingSource
    Friend WithEvents AccountingPOSNamesTableAdapter As AccountingDataSetTableAdapters.AccountingPOSNamesTableAdapter
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents AccountingPOSNamesGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOSCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOSName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCostCenter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrefixCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBranchID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWarehouse As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOnlineOnly As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNote1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNote2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaperSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOpenCashDrawerOnSave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPOSQr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colServerAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDefaultPrinter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTickets As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colUseDirectProduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSamabaPos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTempAccounting As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryTempAccounting As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemsGroups As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPosType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositortPosTypes As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents AccountingPosTypesBindingSource As BindingSource
    Friend WithEvents AccountingDataSet1 As AccountingDataSet
End Class
