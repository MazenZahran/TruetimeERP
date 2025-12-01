<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeesEditList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeesEditList))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.TableAdapterManager = New TrueTime.TrueTimeDataSetTableAdapters.TableAdapterManager()
        Me.EmployeesData2TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData2TableAdapter()
        Me.EmployeesDataGridControl = New DevExpress.XtraGrid.GridControl()
        Me.EmployeesData2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBirthday = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIndenty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSocialState = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSonNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDriverLicence = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMobile1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMobile2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPhoneNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFaceBook = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDepartment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EmployeesDepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colJobName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EmployeesPositionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSalaryCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryCurrency = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colDateOfStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDateOfEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colActive = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBankBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPictureEmp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSalaryAccountNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLicenseDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUserIDInAttFile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colGender = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.colDefinedONAtt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVocationsLimit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EmployeesBranchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colOffDay1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOffDay2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRequiredDailyHoures = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSalaryPerHour = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVocationBeginingBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRestDailyHoures = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBonusPerHour = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDailyTransport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFactorLate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBonusPerHourAferPeriod1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCalcBonusAfterMinitues = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colProcessType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryProcessType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.colMonthlyHouresRequired = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colManagerID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySearchManager = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.EmployeesData1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAddBonusToSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIBAN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EmployeesDepartmentsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter()
        Me.EmployeesBranchesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter()
        Me.EmployeesPositionsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckEditFitColumns = New DevExpress.XtraEditors.CheckEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.CheckEditActive = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager2 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmployeesData1TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter()
        Me.RepositoryRefNo = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDataGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryProcessType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySearchManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.CheckEditFitColumns.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.CheckEditActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.Locale = New System.Globalization.CultureInfo("")
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccessFormsTableAdapter = Nothing
        Me.TableAdapterManager.AccessUsersTableAdapter = Nothing
        Me.TableAdapterManager.ArchiveDocsSorts1TableAdapter = Nothing
        Me.TableAdapterManager.AttAdditionsTypesTableAdapter = Nothing
        Me.TableAdapterManager.AttByQuantityTableAdapter = Nothing
        Me.TableAdapterManager.AttCHECKINOUTTableAdapter = Nothing
        Me.TableAdapterManager.AttPaymentsTypesTableAdapter = Nothing
        Me.TableAdapterManager.AttPlaneForPeriodTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CheckInOutTableAdapter = Nothing
        Me.TableAdapterManager.CheckTypesTableAdapter = Nothing
        Me.TableAdapterManager.CitysTableAdapter = Nothing
        Me.TableAdapterManager.CompanyDataTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesBranchesTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesData1TableAdapter = Nothing
        Me.TableAdapterManager.EmployeesData2TableAdapter = Me.EmployeesData2TableAdapter
        Me.TableAdapterManager.EmployeesDataTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesDepartmentsTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesItemsTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesOhdahTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesPositionsTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesTypesTableAdapter = Nothing
        Me.TableAdapterManager.LocationsTableAdapter = Nothing
        Me.TableAdapterManager.SettingsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.TrueTimeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VacationsBalancesAddingTableAdapter = Nothing
        Me.TableAdapterManager.VocationsTypesTableAdapter = Nothing
        '
        'EmployeesData2TableAdapter
        '
        Me.EmployeesData2TableAdapter.ClearBeforeFill = True
        '
        'EmployeesDataGridControl
        '
        Me.EmployeesDataGridControl.DataSource = Me.EmployeesData2BindingSource
        Me.EmployeesDataGridControl.EmbeddedNavigator.Margin = CType(resources.GetObject("EmployeesDataGridControl.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        GridLevelNode1.RelationName = "Level1"
        Me.EmployeesDataGridControl.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        resources.ApplyResources(Me.EmployeesDataGridControl, "EmployeesDataGridControl")
        Me.EmployeesDataGridControl.MainView = Me.GridView1
        Me.EmployeesDataGridControl.Name = "EmployeesDataGridControl"
        Me.EmployeesDataGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.RepositoryItemLookUpEdit2, Me.RepositoryItemComboBox1, Me.RepositoryItemLookUpEdit3, Me.RepositoryProcessType, Me.RepositorySearchManager, Me.RepositoryCurrency, Me.RepositoryRefNo})
        Me.EmployeesDataGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'EmployeesData2BindingSource
        '
        Me.EmployeesData2BindingSource.DataMember = "EmployeesData2"
        Me.EmployeesData2BindingSource.DataSource = Me.TrueTimeDataSet
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colEmployeeID, Me.colEmployeeName, Me.colAddress, Me.colCity, Me.colBirthday, Me.colIndenty, Me.colSocialState, Me.colSonNO, Me.colDriverLicence, Me.colMobile1, Me.colMobile2, Me.colPhoneNo, Me.colEmail, Me.colFaceBook, Me.colDepartment, Me.colJobName, Me.colSalary, Me.colSalaryCurrency, Me.colDateOfStart, Me.colDateOfEnd, Me.colActive, Me.colBankName, Me.colBankNo, Me.colBankBranch, Me.colPictureEmp, Me.colSalaryAccountNo, Me.colLicenseDate, Me.colUserIDInAttFile, Me.colGender, Me.colDefinedONAtt, Me.colVocationsLimit, Me.colBranch, Me.colOffDay1, Me.colOffDay2, Me.colRequiredDailyHoures, Me.colSalaryPerHour, Me.colVocationBeginingBalance, Me.colRestDailyHoures, Me.colBonusPerHour, Me.colDailyTransport, Me.colFactorLate, Me.colBonusPerHourAferPeriod1, Me.colCalcBonusAfterMinitues, Me.colProcessType, Me.colMonthlyHouresRequired, Me.colManagerID, Me.colNotes, Me.colAddBonusToSalary, Me.colEmployeeType, Me.colIBAN})
        Me.GridView1.GridControl = Me.EmployeesDataGridControl
        Me.GridView1.IndicatorWidth = 30
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        Me.GridView1.OptionsFilter.UseNewCustomFilterDialog = True
        Me.GridView1.OptionsPrint.AutoWidth = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.MinWidth = 21
        Me.colID.Name = "colID"
        '
        'colEmployeeID
        '
        resources.ApplyResources(Me.colEmployeeID, "colEmployeeID")
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.MinWidth = 21
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.OptionsColumn.AllowEdit = False
        Me.colEmployeeID.OptionsColumn.ReadOnly = True
        '
        'colEmployeeName
        '
        resources.ApplyResources(Me.colEmployeeName, "colEmployeeName")
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.MinWidth = 21
        Me.colEmployeeName.Name = "colEmployeeName"
        Me.colEmployeeName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("colEmployeeName.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("colEmployeeName.Summary1"), resources.GetString("colEmployeeName.Summary2"))})
        '
        'colAddress
        '
        resources.ApplyResources(Me.colAddress, "colAddress")
        Me.colAddress.FieldName = "Address"
        Me.colAddress.MinWidth = 21
        Me.colAddress.Name = "colAddress"
        '
        'colCity
        '
        resources.ApplyResources(Me.colCity, "colCity")
        Me.colCity.FieldName = "City"
        Me.colCity.MinWidth = 21
        Me.colCity.Name = "colCity"
        '
        'colBirthday
        '
        resources.ApplyResources(Me.colBirthday, "colBirthday")
        Me.colBirthday.FieldName = "Birthday"
        Me.colBirthday.MinWidth = 21
        Me.colBirthday.Name = "colBirthday"
        '
        'colIndenty
        '
        resources.ApplyResources(Me.colIndenty, "colIndenty")
        Me.colIndenty.FieldName = "Indenty"
        Me.colIndenty.MinWidth = 21
        Me.colIndenty.Name = "colIndenty"
        '
        'colSocialState
        '
        resources.ApplyResources(Me.colSocialState, "colSocialState")
        Me.colSocialState.FieldName = "SocialState"
        Me.colSocialState.MinWidth = 21
        Me.colSocialState.Name = "colSocialState"
        '
        'colSonNO
        '
        resources.ApplyResources(Me.colSonNO, "colSonNO")
        Me.colSonNO.FieldName = "SonNO"
        Me.colSonNO.MinWidth = 21
        Me.colSonNO.Name = "colSonNO"
        '
        'colDriverLicence
        '
        resources.ApplyResources(Me.colDriverLicence, "colDriverLicence")
        Me.colDriverLicence.FieldName = "DriverLicence"
        Me.colDriverLicence.MinWidth = 21
        Me.colDriverLicence.Name = "colDriverLicence"
        '
        'colMobile1
        '
        resources.ApplyResources(Me.colMobile1, "colMobile1")
        Me.colMobile1.FieldName = "Mobile1"
        Me.colMobile1.MinWidth = 21
        Me.colMobile1.Name = "colMobile1"
        '
        'colMobile2
        '
        resources.ApplyResources(Me.colMobile2, "colMobile2")
        Me.colMobile2.FieldName = "Mobile2"
        Me.colMobile2.MinWidth = 21
        Me.colMobile2.Name = "colMobile2"
        '
        'colPhoneNo
        '
        resources.ApplyResources(Me.colPhoneNo, "colPhoneNo")
        Me.colPhoneNo.FieldName = "PhoneNo"
        Me.colPhoneNo.MinWidth = 21
        Me.colPhoneNo.Name = "colPhoneNo"
        '
        'colEmail
        '
        resources.ApplyResources(Me.colEmail, "colEmail")
        Me.colEmail.FieldName = "Email"
        Me.colEmail.MinWidth = 21
        Me.colEmail.Name = "colEmail"
        '
        'colFaceBook
        '
        resources.ApplyResources(Me.colFaceBook, "colFaceBook")
        Me.colFaceBook.FieldName = "FaceBook"
        Me.colFaceBook.MinWidth = 21
        Me.colFaceBook.Name = "colFaceBook"
        '
        'colDepartment
        '
        resources.ApplyResources(Me.colDepartment, "colDepartment")
        Me.colDepartment.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.colDepartment.FieldName = "Department"
        Me.colDepartment.MinWidth = 21
        Me.colDepartment.Name = "colDepartment"
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.DataSource = Me.EmployeesDepartmentsBindingSource
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Department"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ValueMember = "Department"
        '
        'EmployeesDepartmentsBindingSource
        '
        Me.EmployeesDepartmentsBindingSource.DataMember = "EmployeesDepartments"
        Me.EmployeesDepartmentsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'colJobName
        '
        resources.ApplyResources(Me.colJobName, "colJobName")
        Me.colJobName.ColumnEdit = Me.RepositoryItemLookUpEdit3
        Me.colJobName.FieldName = "JobName"
        Me.colJobName.MinWidth = 21
        Me.colJobName.Name = "colJobName"
        '
        'RepositoryItemLookUpEdit3
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit3, "RepositoryItemLookUpEdit3")
        Me.RepositoryItemLookUpEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit3.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit3.DataSource = Me.EmployeesPositionsBindingSource
        Me.RepositoryItemLookUpEdit3.DisplayMember = "Positions"
        Me.RepositoryItemLookUpEdit3.Name = "RepositoryItemLookUpEdit3"
        Me.RepositoryItemLookUpEdit3.ValueMember = "Positions"
        '
        'EmployeesPositionsBindingSource
        '
        Me.EmployeesPositionsBindingSource.DataMember = "EmployeesPositions"
        Me.EmployeesPositionsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'colSalary
        '
        resources.ApplyResources(Me.colSalary, "colSalary")
        Me.colSalary.FieldName = "Salary"
        Me.colSalary.MinWidth = 21
        Me.colSalary.Name = "colSalary"
        '
        'colSalaryCurrency
        '
        resources.ApplyResources(Me.colSalaryCurrency, "colSalaryCurrency")
        Me.colSalaryCurrency.ColumnEdit = Me.RepositoryCurrency
        Me.colSalaryCurrency.FieldName = "SalaryCurrency"
        Me.colSalaryCurrency.MinWidth = 21
        Me.colSalaryCurrency.Name = "colSalaryCurrency"
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
        'colDateOfStart
        '
        resources.ApplyResources(Me.colDateOfStart, "colDateOfStart")
        Me.colDateOfStart.FieldName = "DateOfStart"
        Me.colDateOfStart.MinWidth = 21
        Me.colDateOfStart.Name = "colDateOfStart"
        '
        'colDateOfEnd
        '
        resources.ApplyResources(Me.colDateOfEnd, "colDateOfEnd")
        Me.colDateOfEnd.FieldName = "DateOfEnd"
        Me.colDateOfEnd.MinWidth = 21
        Me.colDateOfEnd.Name = "colDateOfEnd"
        '
        'colActive
        '
        resources.ApplyResources(Me.colActive, "colActive")
        Me.colActive.FieldName = "Active"
        Me.colActive.MinWidth = 21
        Me.colActive.Name = "colActive"
        '
        'colBankName
        '
        resources.ApplyResources(Me.colBankName, "colBankName")
        Me.colBankName.FieldName = "BankName"
        Me.colBankName.MinWidth = 21
        Me.colBankName.Name = "colBankName"
        '
        'colBankNo
        '
        resources.ApplyResources(Me.colBankNo, "colBankNo")
        Me.colBankNo.FieldName = "BankNo"
        Me.colBankNo.MinWidth = 21
        Me.colBankNo.Name = "colBankNo"
        '
        'colBankBranch
        '
        resources.ApplyResources(Me.colBankBranch, "colBankBranch")
        Me.colBankBranch.FieldName = "BankBranch"
        Me.colBankBranch.MinWidth = 21
        Me.colBankBranch.Name = "colBankBranch"
        '
        'colPictureEmp
        '
        resources.ApplyResources(Me.colPictureEmp, "colPictureEmp")
        Me.colPictureEmp.FieldName = "PictureEmp"
        Me.colPictureEmp.MinWidth = 21
        Me.colPictureEmp.Name = "colPictureEmp"
        '
        'colSalaryAccountNo
        '
        resources.ApplyResources(Me.colSalaryAccountNo, "colSalaryAccountNo")
        Me.colSalaryAccountNo.ColumnEdit = Me.RepositoryRefNo
        Me.colSalaryAccountNo.FieldName = "SalaryAccountNo"
        Me.colSalaryAccountNo.MinWidth = 21
        Me.colSalaryAccountNo.Name = "colSalaryAccountNo"
        '
        'colLicenseDate
        '
        resources.ApplyResources(Me.colLicenseDate, "colLicenseDate")
        Me.colLicenseDate.FieldName = "LicenseDate"
        Me.colLicenseDate.MinWidth = 21
        Me.colLicenseDate.Name = "colLicenseDate"
        '
        'colUserIDInAttFile
        '
        resources.ApplyResources(Me.colUserIDInAttFile, "colUserIDInAttFile")
        Me.colUserIDInAttFile.FieldName = "UserIDInAttFile"
        Me.colUserIDInAttFile.MinWidth = 21
        Me.colUserIDInAttFile.Name = "colUserIDInAttFile"
        '
        'colGender
        '
        resources.ApplyResources(Me.colGender, "colGender")
        Me.colGender.ColumnEdit = Me.RepositoryItemComboBox1
        Me.colGender.FieldName = "Gender"
        Me.colGender.MinWidth = 21
        Me.colGender.Name = "colGender"
        '
        'RepositoryItemComboBox1
        '
        resources.ApplyResources(Me.RepositoryItemComboBox1, "RepositoryItemComboBox1")
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemComboBox1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemComboBox1.Items.AddRange(New Object() {resources.GetString("RepositoryItemComboBox1.Items"), resources.GetString("RepositoryItemComboBox1.Items1")})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'colDefinedONAtt
        '
        resources.ApplyResources(Me.colDefinedONAtt, "colDefinedONAtt")
        Me.colDefinedONAtt.FieldName = "DefinedONAtt"
        Me.colDefinedONAtt.MinWidth = 21
        Me.colDefinedONAtt.Name = "colDefinedONAtt"
        '
        'colVocationsLimit
        '
        resources.ApplyResources(Me.colVocationsLimit, "colVocationsLimit")
        Me.colVocationsLimit.FieldName = "VocationsLimit"
        Me.colVocationsLimit.MinWidth = 21
        Me.colVocationsLimit.Name = "colVocationsLimit"
        '
        'colBranch
        '
        resources.ApplyResources(Me.colBranch, "colBranch")
        Me.colBranch.ColumnEdit = Me.RepositoryItemLookUpEdit2
        Me.colBranch.FieldName = "Branch"
        Me.colBranch.MinWidth = 21
        Me.colBranch.Name = "colBranch"
        '
        'RepositoryItemLookUpEdit2
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit2, "RepositoryItemLookUpEdit2")
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit2.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit2.DataSource = Me.EmployeesBranchesBindingSource
        Me.RepositoryItemLookUpEdit2.DisplayMember = "Branch"
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.ValueMember = "Branch"
        '
        'EmployeesBranchesBindingSource
        '
        Me.EmployeesBranchesBindingSource.DataMember = "EmployeesBranches"
        Me.EmployeesBranchesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'colOffDay1
        '
        resources.ApplyResources(Me.colOffDay1, "colOffDay1")
        Me.colOffDay1.FieldName = "OffDay1"
        Me.colOffDay1.MinWidth = 21
        Me.colOffDay1.Name = "colOffDay1"
        '
        'colOffDay2
        '
        resources.ApplyResources(Me.colOffDay2, "colOffDay2")
        Me.colOffDay2.FieldName = "OffDay2"
        Me.colOffDay2.MinWidth = 21
        Me.colOffDay2.Name = "colOffDay2"
        '
        'colRequiredDailyHoures
        '
        resources.ApplyResources(Me.colRequiredDailyHoures, "colRequiredDailyHoures")
        Me.colRequiredDailyHoures.FieldName = "RequiredDailyHoures"
        Me.colRequiredDailyHoures.MinWidth = 21
        Me.colRequiredDailyHoures.Name = "colRequiredDailyHoures"
        '
        'colSalaryPerHour
        '
        resources.ApplyResources(Me.colSalaryPerHour, "colSalaryPerHour")
        Me.colSalaryPerHour.FieldName = "SalaryPerHour"
        Me.colSalaryPerHour.MinWidth = 21
        Me.colSalaryPerHour.Name = "colSalaryPerHour"
        '
        'colVocationBeginingBalance
        '
        resources.ApplyResources(Me.colVocationBeginingBalance, "colVocationBeginingBalance")
        Me.colVocationBeginingBalance.FieldName = "VocationBeginingBalance"
        Me.colVocationBeginingBalance.MinWidth = 21
        Me.colVocationBeginingBalance.Name = "colVocationBeginingBalance"
        '
        'colRestDailyHoures
        '
        resources.ApplyResources(Me.colRestDailyHoures, "colRestDailyHoures")
        Me.colRestDailyHoures.FieldName = "RestDailyHoures"
        Me.colRestDailyHoures.MinWidth = 21
        Me.colRestDailyHoures.Name = "colRestDailyHoures"
        '
        'colBonusPerHour
        '
        resources.ApplyResources(Me.colBonusPerHour, "colBonusPerHour")
        Me.colBonusPerHour.FieldName = "BonusPerHour"
        Me.colBonusPerHour.MinWidth = 21
        Me.colBonusPerHour.Name = "colBonusPerHour"
        '
        'colDailyTransport
        '
        resources.ApplyResources(Me.colDailyTransport, "colDailyTransport")
        Me.colDailyTransport.FieldName = "DailyTransport"
        Me.colDailyTransport.MinWidth = 21
        Me.colDailyTransport.Name = "colDailyTransport"
        '
        'colFactorLate
        '
        resources.ApplyResources(Me.colFactorLate, "colFactorLate")
        Me.colFactorLate.FieldName = "FactorLate"
        Me.colFactorLate.MinWidth = 21
        Me.colFactorLate.Name = "colFactorLate"
        '
        'colBonusPerHourAferPeriod1
        '
        resources.ApplyResources(Me.colBonusPerHourAferPeriod1, "colBonusPerHourAferPeriod1")
        Me.colBonusPerHourAferPeriod1.FieldName = "BonusPerHourAferPeriod1"
        Me.colBonusPerHourAferPeriod1.MinWidth = 21
        Me.colBonusPerHourAferPeriod1.Name = "colBonusPerHourAferPeriod1"
        '
        'colCalcBonusAfterMinitues
        '
        resources.ApplyResources(Me.colCalcBonusAfterMinitues, "colCalcBonusAfterMinitues")
        Me.colCalcBonusAfterMinitues.FieldName = "CalcBonusAfterMinitues"
        Me.colCalcBonusAfterMinitues.MinWidth = 21
        Me.colCalcBonusAfterMinitues.Name = "colCalcBonusAfterMinitues"
        '
        'colProcessType
        '
        resources.ApplyResources(Me.colProcessType, "colProcessType")
        Me.colProcessType.ColumnEdit = Me.RepositoryProcessType
        Me.colProcessType.FieldName = "ProcessType"
        Me.colProcessType.MinWidth = 21
        Me.colProcessType.Name = "colProcessType"
        '
        'RepositoryProcessType
        '
        resources.ApplyResources(Me.RepositoryProcessType, "RepositoryProcessType")
        Me.RepositoryProcessType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryProcessType.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryProcessType.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryProcessType.Columns"), resources.GetString("RepositoryProcessType.Columns1"), CType(resources.GetObject("RepositoryProcessType.Columns2"), Integer), CType(resources.GetObject("RepositoryProcessType.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryProcessType.Columns4"), CType(resources.GetObject("RepositoryProcessType.Columns5"), Boolean), CType(resources.GetObject("RepositoryProcessType.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryProcessType.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryProcessType.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryProcessType.Columns9"), resources.GetString("RepositoryProcessType.Columns10"), CType(resources.GetObject("RepositoryProcessType.Columns11"), Integer), CType(resources.GetObject("RepositoryProcessType.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryProcessType.Columns13"), CType(resources.GetObject("RepositoryProcessType.Columns14"), Boolean), CType(resources.GetObject("RepositoryProcessType.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryProcessType.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryProcessType.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryProcessType.DisplayMember = "ProccessType"
        Me.RepositoryProcessType.Name = "RepositoryProcessType"
        Me.RepositoryProcessType.ValueMember = "TypeID"
        '
        'colMonthlyHouresRequired
        '
        resources.ApplyResources(Me.colMonthlyHouresRequired, "colMonthlyHouresRequired")
        Me.colMonthlyHouresRequired.FieldName = "MonthlyHouresRequired"
        Me.colMonthlyHouresRequired.MinWidth = 17
        Me.colMonthlyHouresRequired.Name = "colMonthlyHouresRequired"
        '
        'colManagerID
        '
        resources.ApplyResources(Me.colManagerID, "colManagerID")
        Me.colManagerID.ColumnEdit = Me.RepositorySearchManager
        Me.colManagerID.FieldName = "ManagerID"
        Me.colManagerID.MinWidth = 17
        Me.colManagerID.Name = "colManagerID"
        '
        'RepositorySearchManager
        '
        resources.ApplyResources(Me.RepositorySearchManager, "RepositorySearchManager")
        Me.RepositorySearchManager.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositorySearchManager.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositorySearchManager.DataSource = Me.EmployeesData1BindingSource
        Me.RepositorySearchManager.DisplayMember = "EmployeeName"
        Me.RepositorySearchManager.Name = "RepositorySearchManager"
        Me.RepositorySearchManager.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.RepositorySearchManager.ValueMember = "EmployeeID"
        '
        'EmployeesData1BindingSource
        '
        Me.EmployeesData1BindingSource.DataMember = "EmployeesData1"
        Me.EmployeesData1BindingSource.DataSource = Me.TrueTimeDataSet
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.DetailHeight = 268
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colNotes
        '
        Me.colNotes.FieldName = "Notes"
        Me.colNotes.MinWidth = 17
        Me.colNotes.Name = "colNotes"
        resources.ApplyResources(Me.colNotes, "colNotes")
        '
        'colAddBonusToSalary
        '
        resources.ApplyResources(Me.colAddBonusToSalary, "colAddBonusToSalary")
        Me.colAddBonusToSalary.FieldName = "AddBonusToSalary"
        Me.colAddBonusToSalary.MinWidth = 17
        Me.colAddBonusToSalary.Name = "colAddBonusToSalary"
        '
        'colEmployeeType
        '
        Me.colEmployeeType.FieldName = "EmployeeType"
        Me.colEmployeeType.MinWidth = 17
        Me.colEmployeeType.Name = "colEmployeeType"
        resources.ApplyResources(Me.colEmployeeType, "colEmployeeType")
        '
        'colIBAN
        '
        Me.colIBAN.FieldName = "IBAN"
        Me.colIBAN.Name = "colIBAN"
        resources.ApplyResources(Me.colIBAN, "colIBAN")
        '
        'EmployeesDepartmentsTableAdapter
        '
        Me.EmployeesDepartmentsTableAdapter.ClearBeforeFill = True
        '
        'EmployeesBranchesTableAdapter
        '
        Me.EmployeesBranchesTableAdapter.ClearBeforeFill = True
        '
        'EmployeesPositionsTableAdapter
        '
        Me.EmployeesPositionsTableAdapter.ClearBeforeFill = True
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl2.Controls.Add(Me.CheckEditFitColumns)
        Me.LayoutControl2.Controls.Add(Me.CheckEditActive)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        resources.ApplyResources(Me.LayoutControl2, "LayoutControl2")
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton3.Appearance.Options.UseBackColor = True
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton3, "SimpleButton3")
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.StyleController = Me.LayoutControl2
        '
        'CheckEditFitColumns
        '
        resources.ApplyResources(Me.CheckEditFitColumns, "CheckEditFitColumns")
        Me.CheckEditFitColumns.MenuManager = Me.BarManager1
        Me.CheckEditFitColumns.Name = "CheckEditFitColumns"
        Me.CheckEditFitColumns.Properties.Caption = resources.GetString("CheckEditFitColumns.Properties.Caption")
        Me.CheckEditFitColumns.StyleController = Me.LayoutControl2
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockManager = Me.DockManager1
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager1
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager1
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager1
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager1
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.MenuManager = Me.BarManager2
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("e2425aa8-ee60-4987-be75-1c2bf43b8bc0")
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(311, 200)
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'CheckEditActive
        '
        resources.ApplyResources(Me.CheckEditActive, "CheckEditActive")
        Me.CheckEditActive.MenuManager = Me.BarManager1
        Me.CheckEditActive.Name = "CheckEditActive"
        Me.CheckEditActive.Properties.Caption = resources.GetString("CheckEditActive.Properties.Caption")
        Me.CheckEditActive.StyleController = Me.LayoutControl2
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl2
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(304, 385)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 124)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(278, 201)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.CheckEditActive
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(278, 28)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CheckEditFitColumns
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(278, 28)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(278, 34)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton3
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(278, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 325)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(278, 34)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'BarManager2
        '
        Me.BarManager2.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager2.DockControls.Add(Me.BarDockControl1)
        Me.BarManager2.DockControls.Add(Me.BarDockControl2)
        Me.BarManager2.DockControls.Add(Me.BarDockControl3)
        Me.BarManager2.DockControls.Add(Me.BarDockControl4)
        Me.BarManager2.DockManager = Me.DockManager1
        Me.BarManager2.Form = Me
        Me.BarManager2.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem2})
        Me.BarManager2.MainMenu = Me.Bar2
        Me.BarManager2.MaxItemId = 1
        Me.BarManager2.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar2, "Bar2")
        '
        'BarButtonItem2
        '
        resources.ApplyResources(Me.BarButtonItem2, "BarButtonItem2")
        Me.BarButtonItem2.Id = 0
        Me.BarButtonItem2.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar3, "Bar3")
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        resources.ApplyResources(Me.BarDockControl1, "BarDockControl1")
        Me.BarDockControl1.Manager = Me.BarManager2
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        resources.ApplyResources(Me.BarDockControl2, "BarDockControl2")
        Me.BarDockControl2.Manager = Me.BarManager2
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        resources.ApplyResources(Me.BarDockControl3, "BarDockControl3")
        Me.BarDockControl3.Manager = Me.BarManager2
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        resources.ApplyResources(Me.BarDockControl4, "BarDockControl4")
        Me.BarDockControl4.Manager = Me.BarManager2
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.Label1)
        Me.LayoutControl1.Controls.Add(Me.EmployeesDataGridControl)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(692, 426)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.EmployeesDataGridControl
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(666, 369)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.Label1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 369)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(666, 31)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmployeesData1TableAdapter
        '
        Me.EmployeesData1TableAdapter.ClearBeforeFill = True
        '
        'RepositoryRefNo
        '
        resources.ApplyResources(Me.RepositoryRefNo, "RepositoryRefNo")
        Me.RepositoryRefNo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryRefNo.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryRefNo.DisplayMember = "RefName"
        Me.RepositoryRefNo.Name = "RepositoryRefNo"
        Me.RepositoryRefNo.PopupView = Me.GridView2
        Me.RepositoryRefNo.ValueMember = "RefNo"
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "RefNo"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "RefName"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'EmployeesEditList
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Name = "EmployeesEditList"
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDataGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryProcessType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySearchManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.CheckEditFitColumns.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.CheckEditActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents TableAdapterManager As TrueTimeDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmployeesDataGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBirthday As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIndenty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSocialState As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSonNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDriverLicence As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMobile1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMobile2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPhoneNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFaceBook As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepartment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJobName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSalaryCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateOfStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDateOfEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colActive As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBankBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPictureEmp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSalaryAccountNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLicenseDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUserIDInAttFile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colGender As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDefinedONAtt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVocationsLimit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents EmployeesDepartmentsBindingSource As BindingSource
    Friend WithEvents EmployeesDepartmentsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents EmployeesBranchesBindingSource As BindingSource
    Friend WithEvents EmployeesBranchesTableAdapter As TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter
    Friend WithEvents RepositoryItemLookUpEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents EmployeesPositionsBindingSource As BindingSource
    Friend WithEvents EmployeesPositionsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter
    '   Friend WithEvents AttPlaneDurationBindingSource As BindingSource
    '  Friend WithEvents AttPlaneDurationTableAdapter As TrueTimeDataSetTableAdapters.AttPlaneDurationTableAdapter
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents colOffDay1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOffDay2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRequiredDailyHoures As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSalaryPerHour As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVocationBeginingBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colRestDailyHoures As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBonusPerHour As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEditActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEditFitColumns As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colDailyTransport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmployeesData2BindingSource As BindingSource
    Friend WithEvents EmployeesData2TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData2TableAdapter
    Friend WithEvents colFactorLate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBonusPerHourAferPeriod1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCalcBonusAfterMinitues As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colProcessType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryProcessType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colMonthlyHouresRequired As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colManagerID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySearchManager As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents EmployeesData1BindingSource As BindingSource
    Friend WithEvents EmployeesData1TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter
    Friend WithEvents colNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAddBonusToSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCurrency As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colIBAN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager2 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RepositoryRefNo As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
