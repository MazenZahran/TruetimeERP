<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VocationsQuery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VocationsQuery))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDocNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.colVocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVocationType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VocationsTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.colFromDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colToDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNoteDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDepartment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJobName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMonth = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVocationSourceAr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemVocationSource = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RadioGroup2 = New DevExpress.XtraEditors.RadioGroup()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchEmployee = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.EmployeesData1BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEmployeeID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeName1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchVocationType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CheckEditCheckActive = New DevExpress.XtraEditors.CheckEdit()
        Me.DateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.DateTo = New DevExpress.XtraEditors.DateEdit()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.LookUpEditPosition = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesPositionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookUpEditDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesDepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookUpEditBranch = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesBranchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmployeesData1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesData1TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter()
        Me.EmployeesDepartmentsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter()
        Me.EmployeesBranchesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter()
        Me.EmployeesPositionsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter()
        Me.VocationsTypesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDocNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemVocationSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.SearchEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchVocationType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.EmbeddedNavigator.Margin = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.RepositoryItemMemoEdit1, Me.RepositoryItemMemoEdit2, Me.RepositoryItemVocationSource, Me.RepositoryDocNo})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVocID, Me.colVocDate, Me.colEmployeeID, Me.colVocationType, Me.colFromDate, Me.colToDate, Me.colNoDays, Me.colNoteDetails, Me.colEmployeeName, Me.colBranch, Me.colDepartment, Me.colJobName, Me.ColMonth, Me.ColVocationSourceAr, Me.GridColumn1})
        Me.GridView1.DetailHeight = 284
        Me.GridView1.GridControl = Me.GridControl1
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(CType(resources.GetObject("GridView1.GroupSummary"), DevExpress.Data.SummaryItemType), resources.GetString("GridView1.GroupSummary1"), Me.colNoDays, resources.GetString("GridView1.GroupSummary2"))})
        Me.GridView1.IndicatorWidth = 34
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'colVocID
        '
        Me.colVocID.AppearanceCell.Font = CType(resources.GetObject("colVocID.AppearanceCell.Font"), System.Drawing.Font)
        Me.colVocID.AppearanceCell.Options.UseFont = True
        Me.colVocID.AppearanceCell.Options.UseTextOptions = True
        Me.colVocID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colVocID, "colVocID")
        Me.colVocID.ColumnEdit = Me.RepositoryDocNo
        Me.colVocID.FieldName = "VocID"
        Me.colVocID.MinWidth = 17
        Me.colVocID.Name = "colVocID"
        Me.colVocID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("colVocID.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("colVocID.Summary1"), resources.GetString("colVocID.Summary2"))})
        '
        'RepositoryDocNo
        '
        resources.ApplyResources(Me.RepositoryDocNo, "RepositoryDocNo")
        Me.RepositoryDocNo.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryDocNo.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.RepositoryDocNo.MaskSettings.Set("mask", "000000")
        Me.RepositoryDocNo.Name = "RepositoryDocNo"
        Me.RepositoryDocNo.SingleClick = True
        '
        'colVocDate
        '
        Me.colVocDate.AppearanceCell.Options.UseTextOptions = True
        Me.colVocDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colVocDate, "colVocDate")
        Me.colVocDate.FieldName = "VocDate"
        Me.colVocDate.MinWidth = 55
        Me.colVocDate.Name = "colVocDate"
        Me.colVocDate.OptionsColumn.AllowEdit = False
        '
        'colEmployeeID
        '
        Me.colEmployeeID.AppearanceCell.Options.UseTextOptions = True
        Me.colEmployeeID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colEmployeeID, "colEmployeeID")
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.MinWidth = 17
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.OptionsColumn.AllowEdit = False
        '
        'colVocationType
        '
        Me.colVocationType.AppearanceCell.Options.UseTextOptions = True
        Me.colVocationType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colVocationType, "colVocationType")
        Me.colVocationType.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.colVocationType.FieldName = "VocationType"
        Me.colVocationType.MinWidth = 17
        Me.colVocationType.Name = "colVocationType"
        Me.colVocationType.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.DataSource = Me.VocationsTypesBindingSource
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Vocation"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ValueMember = "VocID"
        '
        'VocationsTypesBindingSource
        '
        Me.VocationsTypesBindingSource.DataMember = "VocationsTypes"
        Me.VocationsTypesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.Locale = New System.Globalization.CultureInfo("")
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'colFromDate
        '
        Me.colFromDate.AppearanceCell.Options.UseTextOptions = True
        Me.colFromDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colFromDate, "colFromDate")
        Me.colFromDate.FieldName = "FromDate"
        Me.colFromDate.MinWidth = 55
        Me.colFromDate.Name = "colFromDate"
        Me.colFromDate.OptionsColumn.AllowEdit = False
        '
        'colToDate
        '
        Me.colToDate.AppearanceCell.Options.UseTextOptions = True
        Me.colToDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colToDate, "colToDate")
        Me.colToDate.FieldName = "ToDate"
        Me.colToDate.MinWidth = 55
        Me.colToDate.Name = "colToDate"
        Me.colToDate.OptionsColumn.AllowEdit = False
        '
        'colNoDays
        '
        Me.colNoDays.AppearanceCell.Options.UseTextOptions = True
        Me.colNoDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colNoDays, "colNoDays")
        Me.colNoDays.FieldName = "NoDays"
        Me.colNoDays.MinWidth = 17
        Me.colNoDays.Name = "colNoDays"
        Me.colNoDays.OptionsColumn.AllowEdit = False
        Me.colNoDays.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("colNoDays.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("colNoDays.Summary1"), resources.GetString("colNoDays.Summary2"))})
        '
        'colNoteDetails
        '
        Me.colNoteDetails.AppearanceCell.Options.UseTextOptions = True
        Me.colNoteDetails.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colNoteDetails, "colNoteDetails")
        Me.colNoteDetails.ColumnEdit = Me.RepositoryItemMemoEdit2
        Me.colNoteDetails.FieldName = "NoteDetails"
        Me.colNoteDetails.MinWidth = 17
        Me.colNoteDetails.Name = "colNoteDetails"
        Me.colNoteDetails.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemMemoEdit2
        '
        Me.RepositoryItemMemoEdit2.Name = "RepositoryItemMemoEdit2"
        '
        'colEmployeeName
        '
        Me.colEmployeeName.AppearanceCell.Options.UseTextOptions = True
        Me.colEmployeeName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colEmployeeName, "colEmployeeName")
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.MinWidth = 17
        Me.colEmployeeName.Name = "colEmployeeName"
        Me.colEmployeeName.OptionsColumn.AllowEdit = False
        '
        'colBranch
        '
        Me.colBranch.AppearanceCell.Options.UseTextOptions = True
        Me.colBranch.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colBranch, "colBranch")
        Me.colBranch.FieldName = "Branch"
        Me.colBranch.MinWidth = 17
        Me.colBranch.Name = "colBranch"
        Me.colBranch.OptionsColumn.AllowEdit = False
        '
        'colDepartment
        '
        Me.colDepartment.AppearanceCell.Options.UseTextOptions = True
        Me.colDepartment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colDepartment, "colDepartment")
        Me.colDepartment.FieldName = "Department"
        Me.colDepartment.MinWidth = 17
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.OptionsColumn.AllowEdit = False
        '
        'colJobName
        '
        Me.colJobName.AppearanceCell.Options.UseTextOptions = True
        Me.colJobName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.colJobName, "colJobName")
        Me.colJobName.FieldName = "JobName"
        Me.colJobName.MinWidth = 17
        Me.colJobName.Name = "colJobName"
        Me.colJobName.OptionsColumn.AllowEdit = False
        '
        'ColMonth
        '
        Me.ColMonth.AppearanceCell.Options.UseTextOptions = True
        Me.ColMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColMonth, "ColMonth")
        Me.ColMonth.FieldName = "VocMonth"
        Me.ColMonth.MinWidth = 17
        Me.ColMonth.Name = "ColMonth"
        Me.ColMonth.OptionsColumn.AllowEdit = False
        '
        'ColVocationSourceAr
        '
        resources.ApplyResources(Me.ColVocationSourceAr, "ColVocationSourceAr")
        Me.ColVocationSourceAr.ColumnEdit = Me.RepositoryItemVocationSource
        Me.ColVocationSourceAr.FieldName = "VocationSource"
        Me.ColVocationSourceAr.Name = "ColVocationSourceAr"
        Me.ColVocationSourceAr.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemVocationSource
        '
        resources.ApplyResources(Me.RepositoryItemVocationSource, "RepositoryItemVocationSource")
        Me.RepositoryItemVocationSource.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemVocationSource.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemVocationSource.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemVocationSource.Columns"), resources.GetString("RepositoryItemVocationSource.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemVocationSource.Columns2"), resources.GetString("RepositoryItemVocationSource.Columns3"))})
        Me.RepositoryItemVocationSource.DisplayMember = "sourcenameAr"
        Me.RepositoryItemVocationSource.Name = "RepositoryItemVocationSource"
        Me.RepositoryItemVocationSource.ValueMember = "sourcename"
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "SalaryDocumentID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(972, 437)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(946, 411)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'RadioGroup2
        '
        resources.ApplyResources(Me.RadioGroup2, "RadioGroup2")
        Me.RadioGroup2.Name = "RadioGroup2"
        Me.RadioGroup2.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup2.Properties.Items"), resources.GetString("RadioGroup2.Properties.Items1")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup2.Properties.Items2"), resources.GetString("RadioGroup2.Properties.Items3"))})
        Me.RadioGroup2.StyleController = Me.LayoutControl2
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton4)
        Me.LayoutControl2.Controls.Add(Me.RadioGroup2)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl2.Controls.Add(Me.SearchEmployee)
        Me.LayoutControl2.Controls.Add(Me.SearchVocationType)
        Me.LayoutControl2.Controls.Add(Me.CheckEditCheckActive)
        Me.LayoutControl2.Controls.Add(Me.DateFrom)
        Me.LayoutControl2.Controls.Add(Me.DateTo)
        Me.LayoutControl2.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl2.Controls.Add(Me.LookUpEditPosition)
        Me.LayoutControl2.Controls.Add(Me.LookUpEditDepartment)
        Me.LayoutControl2.Controls.Add(Me.LookUpEditBranch)
        resources.ApplyResources(Me.LayoutControl2, "LayoutControl2")
        Me.LayoutControl2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12, Me.LayoutControlItem2})
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1262, 423, 650, 400)
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.Root
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
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton4.Appearance.Options.UseBackColor = True
        Me.SimpleButton4.ImageOptions.Image = CType(resources.GetObject("SimpleButton4.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton4, "SimpleButton4")
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.StyleController = Me.LayoutControl2
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.SimpleButton3.Appearance.Options.UseBackColor = True
        Me.SimpleButton3.ImageOptions.Image = CType(resources.GetObject("SimpleButton3.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton3, "SimpleButton3")
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.StyleController = Me.LayoutControl2
        '
        'SearchEmployee
        '
        resources.ApplyResources(Me.SearchEmployee, "SearchEmployee")
        Me.SearchEmployee.Name = "SearchEmployee"
        Me.SearchEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchEmployee.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchEmployee.Properties.DataSource = Me.EmployeesData1BindingSource1
        Me.SearchEmployee.Properties.DisplayMember = "EmployeeName"
        Me.SearchEmployee.Properties.NullText = resources.GetString("SearchEmployee.Properties.NullText")
        Me.SearchEmployee.Properties.NullValuePrompt = resources.GetString("SearchEmployee.Properties.NullValuePrompt")
        Me.SearchEmployee.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchEmployee.Properties.ValueMember = "EmployeeID"
        Me.SearchEmployee.StyleController = Me.LayoutControl2
        '
        'EmployeesData1BindingSource1
        '
        Me.EmployeesData1BindingSource1.DataMember = "EmployeesData1"
        Me.EmployeesData1BindingSource1.DataSource = Me.TrueTimeDataSet
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEmployeeID1, Me.colEmployeeName1})
        Me.SearchLookUpEdit1View.DetailHeight = 284
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colEmployeeID1
        '
        resources.ApplyResources(Me.colEmployeeID1, "colEmployeeID1")
        Me.colEmployeeID1.FieldName = "EmployeeID"
        Me.colEmployeeID1.MinWidth = 17
        Me.colEmployeeID1.Name = "colEmployeeID1"
        '
        'colEmployeeName1
        '
        resources.ApplyResources(Me.colEmployeeName1, "colEmployeeName1")
        Me.colEmployeeName1.FieldName = "EmployeeName"
        Me.colEmployeeName1.MinWidth = 17
        Me.colEmployeeName1.Name = "colEmployeeName1"
        '
        'SearchVocationType
        '
        resources.ApplyResources(Me.SearchVocationType, "SearchVocationType")
        Me.SearchVocationType.Name = "SearchVocationType"
        Me.SearchVocationType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchVocationType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchVocationType.Properties.DataSource = Me.VocationsTypesBindingSource
        Me.SearchVocationType.Properties.DisplayMember = "Vocation"
        Me.SearchVocationType.Properties.NullText = resources.GetString("SearchVocationType.Properties.NullText")
        Me.SearchVocationType.Properties.NullValuePrompt = resources.GetString("SearchVocationType.Properties.NullValuePrompt")
        Me.SearchVocationType.Properties.PopupView = Me.SearchLookUpEdit2View
        Me.SearchVocationType.Properties.ValueMember = "VocID"
        Me.SearchVocationType.StyleController = Me.LayoutControl2
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVocation})
        Me.SearchLookUpEdit2View.DetailHeight = 284
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'colVocation
        '
        resources.ApplyResources(Me.colVocation, "colVocation")
        Me.colVocation.FieldName = "Vocation"
        Me.colVocation.MinWidth = 17
        Me.colVocation.Name = "colVocation"
        '
        'CheckEditCheckActive
        '
        resources.ApplyResources(Me.CheckEditCheckActive, "CheckEditCheckActive")
        Me.CheckEditCheckActive.Name = "CheckEditCheckActive"
        Me.CheckEditCheckActive.Properties.Caption = resources.GetString("CheckEditCheckActive.Properties.Caption")
        Me.CheckEditCheckActive.StyleController = Me.LayoutControl2
        '
        'DateFrom
        '
        resources.ApplyResources(Me.DateFrom, "DateFrom")
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateFrom.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateFrom.StyleController = Me.LayoutControl2
        '
        'DateTo
        '
        resources.ApplyResources(Me.DateTo, "DateTo")
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateTo.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateTo.StyleController = Me.LayoutControl2
        '
        'RadioGroup1
        '
        resources.ApplyResources(Me.RadioGroup1, "RadioGroup1")
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Columns = 3
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items"), resources.GetString("RadioGroup1.Properties.Items1")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items2"), resources.GetString("RadioGroup1.Properties.Items3")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items4"), resources.GetString("RadioGroup1.Properties.Items5")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items6"), resources.GetString("RadioGroup1.Properties.Items7")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items8"), resources.GetString("RadioGroup1.Properties.Items9")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items10"), resources.GetString("RadioGroup1.Properties.Items11"))})
        Me.RadioGroup1.StyleController = Me.LayoutControl2
        '
        'LookUpEditPosition
        '
        resources.ApplyResources(Me.LookUpEditPosition, "LookUpEditPosition")
        Me.LookUpEditPosition.Name = "LookUpEditPosition"
        Me.LookUpEditPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditPosition.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("LookUpEditPosition.Properties.Columns"), resources.GetString("LookUpEditPosition.Properties.Columns1"), CType(resources.GetObject("LookUpEditPosition.Properties.Columns2"), Integer), CType(resources.GetObject("LookUpEditPosition.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("LookUpEditPosition.Properties.Columns4"), CType(resources.GetObject("LookUpEditPosition.Properties.Columns5"), Boolean), CType(resources.GetObject("LookUpEditPosition.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("LookUpEditPosition.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("LookUpEditPosition.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.LookUpEditPosition.Properties.DataSource = Me.EmployeesPositionsBindingSource
        Me.LookUpEditPosition.Properties.DisplayMember = "Positions"
        Me.LookUpEditPosition.Properties.NullText = resources.GetString("LookUpEditPosition.Properties.NullText")
        Me.LookUpEditPosition.Properties.NullValuePrompt = resources.GetString("LookUpEditPosition.Properties.NullValuePrompt")
        Me.LookUpEditPosition.Properties.ShowHeader = False
        Me.LookUpEditPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditPosition.Properties.ValueMember = "Positions"
        Me.LookUpEditPosition.StyleController = Me.LayoutControl2
        '
        'EmployeesPositionsBindingSource
        '
        Me.EmployeesPositionsBindingSource.DataMember = "EmployeesPositions"
        Me.EmployeesPositionsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'LookUpEditDepartment
        '
        resources.ApplyResources(Me.LookUpEditDepartment, "LookUpEditDepartment")
        Me.LookUpEditDepartment.Name = "LookUpEditDepartment"
        Me.LookUpEditDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditDepartment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditDepartment.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("LookUpEditDepartment.Properties.Columns"), resources.GetString("LookUpEditDepartment.Properties.Columns1"), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns2"), Integer), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("LookUpEditDepartment.Properties.Columns4"), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns5"), Boolean), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("LookUpEditDepartment.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.LookUpEditDepartment.Properties.DataSource = Me.EmployeesDepartmentsBindingSource
        Me.LookUpEditDepartment.Properties.DisplayMember = "Department"
        Me.LookUpEditDepartment.Properties.NullText = resources.GetString("LookUpEditDepartment.Properties.NullText")
        Me.LookUpEditDepartment.Properties.NullValuePrompt = resources.GetString("LookUpEditDepartment.Properties.NullValuePrompt")
        Me.LookUpEditDepartment.Properties.ShowHeader = False
        Me.LookUpEditDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditDepartment.Properties.ValueMember = "Department"
        Me.LookUpEditDepartment.StyleController = Me.LayoutControl2
        '
        'EmployeesDepartmentsBindingSource
        '
        Me.EmployeesDepartmentsBindingSource.DataMember = "EmployeesDepartments"
        Me.EmployeesDepartmentsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'LookUpEditBranch
        '
        resources.ApplyResources(Me.LookUpEditBranch, "LookUpEditBranch")
        Me.LookUpEditBranch.Name = "LookUpEditBranch"
        Me.LookUpEditBranch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditBranch.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditBranch.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("LookUpEditBranch.Properties.Columns"), resources.GetString("LookUpEditBranch.Properties.Columns1"), CType(resources.GetObject("LookUpEditBranch.Properties.Columns2"), Integer), CType(resources.GetObject("LookUpEditBranch.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("LookUpEditBranch.Properties.Columns4"), CType(resources.GetObject("LookUpEditBranch.Properties.Columns5"), Boolean), CType(resources.GetObject("LookUpEditBranch.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("LookUpEditBranch.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("LookUpEditBranch.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.LookUpEditBranch.Properties.DataSource = Me.EmployeesBranchesBindingSource
        Me.LookUpEditBranch.Properties.DisplayMember = "Branch"
        Me.LookUpEditBranch.Properties.NullText = resources.GetString("LookUpEditBranch.Properties.NullText")
        Me.LookUpEditBranch.Properties.NullValuePrompt = resources.GetString("LookUpEditBranch.Properties.NullValuePrompt")
        Me.LookUpEditBranch.Properties.ShowHeader = False
        Me.LookUpEditBranch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditBranch.Properties.ValueMember = "Branch"
        Me.LookUpEditBranch.StyleController = Me.LayoutControl2
        '
        'EmployeesBranchesBindingSource
        '
        Me.EmployeesBranchesBindingSource.DataMember = "EmployeesBranches"
        Me.EmployeesBranchesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.RadioGroup1
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 182)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(239, 173)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.RadioGroup2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 182)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(39, 25)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(239, 38)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem13, Me.LayoutControlItem9, Me.LayoutControlItem14, Me.LayoutControlItem8})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(242, 404)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchEmployee
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 266)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(216, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SearchVocationType
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DateFrom
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.DateTo
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.LookUpEditDepartment
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.LookUpEditBranch
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 170)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.LookUpEditPosition
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 204)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.CheckEditCheckActive
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 238)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(216, 28)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.SimpleButton4
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 344)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.SimpleButton1
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 310)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.SimpleButton3
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 276)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(216, 34)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmployeesData1BindingSource
        '
        Me.EmployeesData1BindingSource.DataMember = "EmployeesData1"
        Me.EmployeesData1BindingSource.DataSource = Me.TrueTimeDataSet
        '
        'EmployeesData1TableAdapter
        '
        Me.EmployeesData1TableAdapter.ClearBeforeFill = True
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
        'VocationsTypesTableAdapter
        '
        Me.VocationsTypesTableAdapter.ClearBeforeFill = True
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
        Me.DockPanel1.ID = New System.Guid("463a56aa-3e76-4f3d-872c-286960f7af43")
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(266, 200)
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'VocationsQuery
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "VocationsQuery"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDocNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemVocationSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.SearchEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchVocationType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colVocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVocationType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFromDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colToDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNoteDetails As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDepartment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJobName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesData1BindingSource As BindingSource
    Friend WithEvents EmployeesData1TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter
    Friend WithEvents SearchVocationType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SearchEmployee As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LookUpEditPosition As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditBranch As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents CheckEditCheckActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents EmployeesDepartmentsBindingSource As BindingSource
    Friend WithEvents EmployeesDepartmentsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter
    Friend WithEvents EmployeesBranchesBindingSource As BindingSource
    Friend WithEvents EmployeesBranchesTableAdapter As TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter
    Friend WithEvents EmployeesPositionsBindingSource As BindingSource
    Friend WithEvents EmployeesPositionsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter
    Friend WithEvents VocationsTypesBindingSource As BindingSource
    Friend WithEvents VocationsTypesTableAdapter As TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter
    Friend WithEvents colVocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmployeesData1BindingSource1 As BindingSource
    Friend WithEvents colEmployeeID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeName1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMonth As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadioGroup2 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents RepositoryItemMemoEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColVocationSourceAr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemVocationSource As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryDocNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
