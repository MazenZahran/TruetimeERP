<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VocationBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VocationBalances))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.ColDateOfStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.VocationsTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LookUpEditDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesDepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookUpEditBranch = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesBranchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LookUpEditPosition = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesPositionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColEmpID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAddingDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNoVocationDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVocationType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.Colbalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTHISYEARVOCATIONS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColThisYearSetBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColBeginingBalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EmployeesPositionsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter()
        Me.EmployeesDepartmentsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter()
        Me.EmployeesBranchesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter()
        Me.VocationsTypesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColDateOfStart
        '
        resources.ApplyResources(Me.ColDateOfStart, "ColDateOfStart")
        Me.ColDateOfStart.FieldName = "DateOfStart"
        Me.ColDateOfStart.Name = "ColDateOfStart"
        Me.ColDateOfStart.OptionsColumn.AllowEdit = False
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("71c9c0d2-9a51-46a1-b3d9-1da054fce2fa")
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(264, 200)
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SearchLookUpEdit1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.DateEditTo)
        Me.LayoutControl1.Controls.Add(Me.DateEditFrom)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditDepartment)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditBranch)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditPosition)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'SearchLookUpEdit1
        '
        resources.ApplyResources(Me.SearchLookUpEdit1, "SearchLookUpEdit1")
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchLookUpEdit1.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchLookUpEdit1.Properties.DataSource = Me.VocationsTypesBindingSource
        Me.SearchLookUpEdit1.Properties.DisplayMember = "Vocation"
        Me.SearchLookUpEdit1.Properties.NullText = resources.GetString("SearchLookUpEdit1.Properties.NullText")
        Me.SearchLookUpEdit1.Properties.NullValuePrompt = resources.GetString("SearchLookUpEdit1.Properties.NullValuePrompt")
        Me.SearchLookUpEdit1.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookUpEdit1.Properties.ValueMember = "VocID"
        Me.SearchLookUpEdit1.StyleController = Me.LayoutControl1
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
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVocation})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colVocation
        '
        resources.ApplyResources(Me.colVocation, "colVocation")
        Me.colVocation.FieldName = "Vocation"
        Me.colVocation.Name = "colVocation"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        '
        'DateEditTo
        '
        resources.ApplyResources(Me.DateEditTo, "DateEditTo")
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditTo.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditTo.StyleController = Me.LayoutControl1
        '
        'DateEditFrom
        '
        resources.ApplyResources(Me.DateEditFrom, "DateEditFrom")
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditFrom.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditFrom.StyleController = Me.LayoutControl1
        '
        'LookUpEditDepartment
        '
        resources.ApplyResources(Me.LookUpEditDepartment, "LookUpEditDepartment")
        Me.LookUpEditDepartment.Name = "LookUpEditDepartment"
        Me.LookUpEditDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditDepartment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditDepartment.Properties.DataSource = Me.EmployeesDepartmentsBindingSource
        Me.LookUpEditDepartment.Properties.DisplayMember = "Department"
        Me.LookUpEditDepartment.Properties.NullText = resources.GetString("LookUpEditDepartment.Properties.NullText")
        Me.LookUpEditDepartment.Properties.NullValuePrompt = resources.GetString("LookUpEditDepartment.Properties.NullValuePrompt")
        Me.LookUpEditDepartment.Properties.ShowHeader = False
        Me.LookUpEditDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditDepartment.Properties.ValueMember = "Department"
        Me.LookUpEditDepartment.StyleController = Me.LayoutControl1
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
        Me.LookUpEditBranch.Properties.DataSource = Me.EmployeesBranchesBindingSource
        Me.LookUpEditBranch.Properties.DisplayMember = "Branch"
        Me.LookUpEditBranch.Properties.NullText = resources.GetString("LookUpEditBranch.Properties.NullText")
        Me.LookUpEditBranch.Properties.NullValuePrompt = resources.GetString("LookUpEditBranch.Properties.NullValuePrompt")
        Me.LookUpEditBranch.Properties.ShowHeader = False
        Me.LookUpEditBranch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditBranch.Properties.ValueMember = "Branch"
        Me.LookUpEditBranch.StyleController = Me.LayoutControl1
        '
        'EmployeesBranchesBindingSource
        '
        Me.EmployeesBranchesBindingSource.DataMember = "EmployeesBranches"
        Me.EmployeesBranchesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'LookUpEditPosition
        '
        resources.ApplyResources(Me.LookUpEditPosition, "LookUpEditPosition")
        Me.LookUpEditPosition.Name = "LookUpEditPosition"
        Me.LookUpEditPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditPosition.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditPosition.Properties.DataSource = Me.EmployeesPositionsBindingSource
        Me.LookUpEditPosition.Properties.DisplayMember = "Positions"
        Me.LookUpEditPosition.Properties.NullText = resources.GetString("LookUpEditPosition.Properties.NullText")
        Me.LookUpEditPosition.Properties.NullValuePrompt = resources.GetString("LookUpEditPosition.Properties.NullValuePrompt")
        Me.LookUpEditPosition.Properties.ShowHeader = False
        Me.LookUpEditPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditPosition.Properties.ValueMember = "Positions"
        Me.LookUpEditPosition.StyleController = Me.LayoutControl1
        '
        'EmployeesPositionsBindingSource
        '
        Me.EmployeesPositionsBindingSource.DataMember = "EmployeesPositions"
        Me.EmployeesPositionsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(257, 522)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 156)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(237, 294)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.LookUpEditPosition
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.LookUpEditDepartment
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LookUpEditBranch
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 450)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DateEditFrom
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(41, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.DateEditTo
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(237, 26)
        resources.ApplyResources(Me.LayoutControlItem6, "LayoutControlItem6")
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(41, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SimpleButton2
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 476)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.SearchLookUpEdit1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(237, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColEmpID, Me.ColEmployeeName, Me.ColAddingDays, Me.ColNoVocationDays, Me.ColVocationType, Me.ColDateOfStart, Me.Colbalance, Me.ColTHISYEARVOCATIONS, Me.ColThisYearSetBalance, Me.ColBeginingBalance, Me.GridColumn1})
        GridFormatRule1.Column = Me.ColDateOfStart
        GridFormatRule1.ColumnApplyTo = Me.ColDateOfStart
        GridFormatRule1.Description = Nothing
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.PredefinedName = "Red Fill"
        FormatConditionRuleValue1.Value1 = "1900-01-01"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColEmpID
        '
        resources.ApplyResources(Me.ColEmpID, "ColEmpID")
        Me.ColEmpID.FieldName = "EmpID"
        Me.ColEmpID.Name = "ColEmpID"
        Me.ColEmpID.OptionsColumn.AllowEdit = False
        '
        'ColEmployeeName
        '
        resources.ApplyResources(Me.ColEmployeeName, "ColEmployeeName")
        Me.ColEmployeeName.FieldName = "EmployeeName"
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.OptionsColumn.AllowEdit = False
        Me.ColEmployeeName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColEmployeeName.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColEmployeeName.Summary1"), resources.GetString("ColEmployeeName.Summary2"))})
        '
        'ColAddingDays
        '
        resources.ApplyResources(Me.ColAddingDays, "ColAddingDays")
        Me.ColAddingDays.FieldName = "AddingDays"
        Me.ColAddingDays.Name = "ColAddingDays"
        Me.ColAddingDays.OptionsColumn.AllowEdit = False
        '
        'ColNoVocationDays
        '
        resources.ApplyResources(Me.ColNoVocationDays, "ColNoVocationDays")
        Me.ColNoVocationDays.FieldName = "NoVocationDays"
        Me.ColNoVocationDays.Name = "ColNoVocationDays"
        Me.ColNoVocationDays.OptionsColumn.AllowEdit = False
        '
        'ColVocationType
        '
        resources.ApplyResources(Me.ColVocationType, "ColVocationType")
        Me.ColVocationType.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.ColVocationType.FieldName = "VocationType"
        Me.ColVocationType.Name = "ColVocationType"
        Me.ColVocationType.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemLookUpEdit1.Columns"), resources.GetString("RepositoryItemLookUpEdit1.Columns1"), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns2"), Integer), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemLookUpEdit1.Columns4"), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns5"), Boolean), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemLookUpEdit1.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryItemLookUpEdit1.DataSource = Me.VocationsTypesBindingSource
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Vocation"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ValueMember = "VocID"
        '
        'Colbalance
        '
        resources.ApplyResources(Me.Colbalance, "Colbalance")
        Me.Colbalance.DisplayFormat.FormatString = "N1"
        Me.Colbalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Colbalance.FieldName = "balance"
        Me.Colbalance.Name = "Colbalance"
        Me.Colbalance.OptionsColumn.AllowEdit = False
        '
        'ColTHISYEARVOCATIONS
        '
        resources.ApplyResources(Me.ColTHISYEARVOCATIONS, "ColTHISYEARVOCATIONS")
        Me.ColTHISYEARVOCATIONS.DisplayFormat.FormatString = "N1"
        Me.ColTHISYEARVOCATIONS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTHISYEARVOCATIONS.FieldName = "THISYEARVOCATIONS"
        Me.ColTHISYEARVOCATIONS.Name = "ColTHISYEARVOCATIONS"
        Me.ColTHISYEARVOCATIONS.OptionsColumn.AllowEdit = False
        '
        'ColThisYearSetBalance
        '
        resources.ApplyResources(Me.ColThisYearSetBalance, "ColThisYearSetBalance")
        Me.ColThisYearSetBalance.DisplayFormat.FormatString = "N1"
        Me.ColThisYearSetBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColThisYearSetBalance.FieldName = "ThisYearSetBalance"
        Me.ColThisYearSetBalance.Name = "ColThisYearSetBalance"
        Me.ColThisYearSetBalance.OptionsColumn.AllowEdit = False
        '
        'ColBeginingBalance
        '
        resources.ApplyResources(Me.ColBeginingBalance, "ColBeginingBalance")
        Me.ColBeginingBalance.DisplayFormat.FormatString = "N1"
        Me.ColBeginingBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColBeginingBalance.FieldName = "BeginingBalance"
        Me.ColBeginingBalance.Name = "ColBeginingBalance"
        Me.ColBeginingBalance.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.DisplayFormat.FormatString = "N1"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "AccruedVocation"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'EmployeesPositionsTableAdapter
        '
        Me.EmployeesPositionsTableAdapter.ClearBeforeFill = True
        '
        'EmployeesDepartmentsTableAdapter
        '
        Me.EmployeesDepartmentsTableAdapter.ClearBeforeFill = True
        '
        'EmployeesBranchesTableAdapter
        '
        Me.EmployeesBranchesTableAdapter.ClearBeforeFill = True
        '
        'VocationsTypesTableAdapter
        '
        Me.VocationsTypesTableAdapter.ClearBeforeFill = True
        '
        'VocationBalances
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "VocationBalances"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ColEmpID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAddingDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNoVocationDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Colbalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LookUpEditDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditBranch As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditPosition As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColDateOfStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTHISYEARVOCATIONS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColThisYearSetBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColBeginingBalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesPositionsBindingSource As BindingSource
    Friend WithEvents EmployeesPositionsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter
    Friend WithEvents EmployeesDepartmentsBindingSource As BindingSource
    Friend WithEvents EmployeesDepartmentsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter
    Friend WithEvents EmployeesBranchesBindingSource As BindingSource
    Friend WithEvents EmployeesBranchesTableAdapter As TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VocationsTypesBindingSource As BindingSource
    Friend WithEvents VocationsTypesTableAdapter As TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter
    Friend WithEvents ColVocationType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colVocation As DevExpress.XtraGrid.Columns.GridColumn
End Class
