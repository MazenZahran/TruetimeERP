<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AttCustomizedReport1
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttCustomizedReport1))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim TableColumnDefinition1 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TableColumnDefinition2 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TableRowDefinition1 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition2 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition3 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableSpan1 As DevExpress.XtraEditors.TableLayout.TableSpan = New DevExpress.XtraEditors.TableLayout.TableSpan()
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Me.ColStartTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.ColVoc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colPictureEmp = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colBranch = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colDepartment = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColEmpID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColSalaryAccountNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.CollEmployeeName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColTransDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColTransDay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColEditedType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColAddAndEdit = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColEditedTypeOut = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColStartTimeReal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.ColEndTimeReal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.ColRequiredDailyHoures = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.ColRestDailyHoures = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RestTimeSpanEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.ColAttStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColBonusPerHour = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColPlaneID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColEndTime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.ColMissedDuration = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDuration11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.LeaveBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDuration2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.LeaveBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDuration3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.LeaveBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDuration4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.LeaveBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDuration5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.gridBand13 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColTotalDurations = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit12 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.ColBonusHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeSpanEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit()
        Me.ColLeavesHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.ColNetDurations = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveJobBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveJobBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveJobBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveJobBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.LeaveJobBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand16 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColDailyTransport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Colpayment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColBonusHoursNIS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColLeavesHoursNIS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColMonthlySalaryPerDay = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColSalaryPerHour = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColNetSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColTransInID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColTransOutID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.CheckEditCheckActive = New DevExpress.XtraEditors.CheckEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditRestTime = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioGroup2 = New DevExpress.XtraEditors.RadioGroup()
        Me.CheckCalcVocationsAtOffDay = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckElapseOnVocation = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButtonAddVocations = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonInsertAttTrans = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SpinEdit1 = New DevExpress.XtraEditors.SpinEdit()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.LookUpEditDepartment = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesDepartmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit()
        Me.LookUpEditPosition = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesPositionsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LookUpEditBranch = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesBranchesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.EmployeesDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.colID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colAttPlane = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colMobile1 = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colJobName = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmployeesDataTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesDataTableAdapter()
        Me.EmployeesBranchesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter()
        Me.EmployeesDepartmentsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter()
        Me.EmployeesPositionsTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.TrueTime.WaitForm1), True, True)
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.ColMonthlySalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        CType(Me.RepositoryItemTimeEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RestTimeSpanEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeSpanEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditRestTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckCalcVocationsAtOffDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckElapseOnVocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColStartTime
        '
        Me.ColStartTime.Caption = "بداية الوردية"
        Me.ColStartTime.ColumnEdit = Me.RepositoryItemTimeEdit2
        Me.ColStartTime.FieldName = "StartTime"
        Me.ColStartTime.Name = "ColStartTime"
        Me.ColStartTime.OptionsColumn.AllowEdit = False
        Me.ColStartTime.Visible = True
        '
        'RepositoryItemTimeEdit2
        '
        Me.RepositoryItemTimeEdit2.AutoHeight = False
        Me.RepositoryItemTimeEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit2.DisplayFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit2.EditFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit2.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit2.Name = "RepositoryItemTimeEdit2"
        '
        'ColVoc
        '
        Me.ColVoc.Caption = "اجازة"
        Me.ColVoc.FieldName = "Voc"
        Me.ColVoc.Name = "ColVoc"
        Me.ColVoc.OptionsColumn.AllowEdit = False
        '
        'colEmployeeName
        '
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.Name = "colEmployeeName"
        Me.colEmployeeName.Visible = True
        Me.colEmployeeName.VisibleIndex = 1
        '
        'colPictureEmp
        '
        Me.colPictureEmp.Caption = "صورة"
        Me.colPictureEmp.FieldName = "PictureEmp"
        Me.colPictureEmp.Name = "colPictureEmp"
        Me.colPictureEmp.Visible = True
        Me.colPictureEmp.VisibleIndex = 4
        '
        'colBranch
        '
        Me.colBranch.FieldName = "Branch"
        Me.colBranch.Name = "colBranch"
        Me.colBranch.Visible = True
        Me.colBranch.VisibleIndex = 6
        '
        'colDepartment
        '
        Me.colDepartment.FieldName = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.Visible = True
        Me.colDepartment.VisibleIndex = 7
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(299, 0)
        Me.GridControl1.MainView = Me.BandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTimeEdit1, Me.RepositoryItemTimeEdit2, Me.RepositoryItemTimeEdit3, Me.RepositoryItemTimeEdit6, Me.RepositoryItemTimeSpanEdit1, Me.RepositoryItemTimeSpanEdit2, Me.RepositoryItemButtonEdit1, Me.RepositoryItemTimeSpanEdit3, Me.RepositoryItemTimeSpanEdit4, Me.RepositoryItemTimeSpanEdit5, Me.RepositoryItemTimeSpanEdit6, Me.RepositoryItemTimeSpanEdit7, Me.RepositoryItemTimeSpanEdit12, Me.RepositoryItemTimeEdit4, Me.RepositoryItemSpinEdit1, Me.RepositoryItemTimeSpanEdit8, Me.RestTimeSpanEdit})
        Me.GridControl1.Size = New System.Drawing.Size(810, 628)
        Me.GridControl1.TabIndex = 8
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView1})
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BandedGridView1.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5, Me.GridBand6, Me.gridBand7, Me.gridBand13, Me.gridBand8, Me.gridBand16, Me.gridBand9})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.ColTransDate, Me.ColTransDay, Me.ColEditedTypeOut, Me.ColAddAndEdit, Me.ColPlaneID, Me.ColStartTimeReal, Me.ColEndTimeReal, Me.ColRequiredDailyHoures, Me.ColStartTime, Me.ColEndTime, Me.ColMissedDuration, Me.ColTransInID, Me.ColTransOutID, Me.ColEditedType, Me.ColEmpID, Me.CollEmployeeName, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.ColDuration11, Me.ColDuration2, Me.ColDuration3, Me.ColDuration4, Me.ColDuration5, Me.ColTotalDurations, Me.ColAttStatus, Me.ColVoc, Me.ColLeavesHours, Me.ColBonusHours, Me.ColNetDurations, Me.ColSalaryPerHour, Me.ColNetSalary, Me.ColRestDailyHoures, Me.ColBonusPerHour, Me.ColMonthlySalaryPerDay, Me.ColBonusHoursNIS, Me.ColLeavesHoursNIS, Me.ColDailyTransport, Me.Colpayment, Me.ColSalaryAccountNo, Me.ColMonthlySalary})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.ColStartTime
        GridFormatRule1.ColumnApplyTo = Me.ColStartTime
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Gray
        FormatConditionRuleValue1.Appearance.Options.UseBackColor = True
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.Expression = "[StartTime] Is Null"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.ColVoc
        GridFormatRule2.ColumnApplyTo = Me.ColVoc
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue2.PredefinedName = "Red Fill"
        FormatConditionRuleValue2.Value1 = "0"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.BandedGridView1.FormatRules.Add(GridFormatRule1)
        Me.BandedGridView1.FormatRules.Add(GridFormatRule2)
        Me.BandedGridView1.GridControl = Me.GridControl1
        Me.BandedGridView1.GroupCount = 1
        Me.BandedGridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "RequiredDailyHoures", Me.ColRequiredDailyHoures, "", "20"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MissedDuration", Me.ColMissedDuration, "", "21"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TotalDurations", Me.ColTotalDurations, "", "26"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "LeavesHours", Me.ColLeavesHours, "", "27"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BonusHours", Me.ColBonusHours, "", "28"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSalary", Me.ColNetSalary, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "SalaryPerHour", Me.ColSalaryPerHour, "{0:n1}")})
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.BandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.BandedGridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.BandedGridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BandedGridView1.OptionsView.ShowFooter = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        Me.BandedGridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.CollEmployeeName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.BackColor = System.Drawing.Color.Gray
        Me.GridBand1.AppearanceHeader.Options.UseBackColor = True
        Me.GridBand1.Caption = "التفاصيل"
        Me.GridBand1.Columns.Add(Me.ColEmpID)
        Me.GridBand1.Columns.Add(Me.ColSalaryAccountNo)
        Me.GridBand1.Columns.Add(Me.CollEmployeeName)
        Me.GridBand1.Columns.Add(Me.ColTransDate)
        Me.GridBand1.Columns.Add(Me.ColTransDay)
        Me.GridBand1.Columns.Add(Me.ColEditedType)
        Me.GridBand1.Columns.Add(Me.ColAddAndEdit)
        Me.GridBand1.Columns.Add(Me.ColEditedTypeOut)
        Me.GridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 450
        '
        'ColEmpID
        '
        Me.ColEmpID.Caption = "رقم الموظف"
        Me.ColEmpID.FieldName = "EmpID"
        Me.ColEmpID.Name = "ColEmpID"
        Me.ColEmpID.OptionsColumn.AllowEdit = False
        Me.ColEmpID.Visible = True
        '
        'ColSalaryAccountNo
        '
        Me.ColSalaryAccountNo.Caption = "الرقم الوظيفي"
        Me.ColSalaryAccountNo.FieldName = "SalaryAccountNo"
        Me.ColSalaryAccountNo.Name = "ColSalaryAccountNo"
        Me.ColSalaryAccountNo.Visible = True
        '
        'CollEmployeeName
        '
        Me.CollEmployeeName.Caption = "الموظف"
        Me.CollEmployeeName.FieldName = "EmployeeName"
        Me.CollEmployeeName.Name = "CollEmployeeName"
        Me.CollEmployeeName.OptionsColumn.AllowEdit = False
        Me.CollEmployeeName.Visible = True
        '
        'ColTransDate
        '
        Me.ColTransDate.Caption = "التاريخ"
        Me.ColTransDate.FieldName = "TransDate"
        Me.ColTransDate.Name = "ColTransDate"
        Me.ColTransDate.OptionsColumn.AllowEdit = False
        Me.ColTransDate.Visible = True
        '
        'ColTransDay
        '
        Me.ColTransDay.Caption = "اليوم"
        Me.ColTransDay.FieldName = "TransDay"
        Me.ColTransDay.Name = "ColTransDay"
        Me.ColTransDay.OptionsColumn.AllowEdit = False
        Me.ColTransDay.Visible = True
        '
        'ColEditedType
        '
        Me.ColEditedType.Caption = "حالة الحركة"
        Me.ColEditedType.FieldName = "EditedType"
        Me.ColEditedType.Name = "ColEditedType"
        Me.ColEditedType.OptionsColumn.AllowEdit = False
        '
        'ColAddAndEdit
        '
        Me.ColAddAndEdit.Caption = "تعديل"
        Me.ColAddAndEdit.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.ColAddAndEdit.FieldName = "AddAndEdit"
        Me.ColAddAndEdit.Name = "ColAddAndEdit"
        Me.ColAddAndEdit.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColAddAndEdit.Visible = True
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'ColEditedTypeOut
        '
        Me.ColEditedTypeOut.Caption = "تعديل (خروج)"
        Me.ColEditedTypeOut.FieldName = "EditedTypeOut"
        Me.ColEditedTypeOut.Name = "ColEditedTypeOut"
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "الدوام"
        Me.gridBand2.Columns.Add(Me.ColStartTimeReal)
        Me.gridBand2.Columns.Add(Me.ColEndTimeReal)
        Me.gridBand2.Columns.Add(Me.ColRequiredDailyHoures)
        Me.gridBand2.Columns.Add(Me.ColVoc)
        Me.gridBand2.Columns.Add(Me.ColRestDailyHoures)
        Me.gridBand2.Columns.Add(Me.ColAttStatus)
        Me.gridBand2.Columns.Add(Me.ColBonusPerHour)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 167
        '
        'ColStartTimeReal
        '
        Me.ColStartTimeReal.Caption = "من"
        Me.ColStartTimeReal.ColumnEdit = Me.RepositoryItemTimeEdit1
        Me.ColStartTimeReal.DisplayFormat.FormatString = "HH:mm"
        Me.ColStartTimeReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColStartTimeReal.FieldName = "StartTimeReal"
        Me.ColStartTimeReal.Name = "ColStartTimeReal"
        Me.ColStartTimeReal.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemTimeEdit1
        '
        Me.RepositoryItemTimeEdit1.AutoHeight = False
        Me.RepositoryItemTimeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemTimeEdit1.Mask.EditMask = ""
        Me.RepositoryItemTimeEdit1.Name = "RepositoryItemTimeEdit1"
        '
        'ColEndTimeReal
        '
        Me.ColEndTimeReal.Caption = "الى"
        Me.ColEndTimeReal.ColumnEdit = Me.RepositoryItemTimeEdit3
        Me.ColEndTimeReal.FieldName = "EndTimeReal"
        Me.ColEndTimeReal.Name = "ColEndTimeReal"
        Me.ColEndTimeReal.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemTimeEdit3
        '
        Me.RepositoryItemTimeEdit3.AutoHeight = False
        Me.RepositoryItemTimeEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit3.DisplayFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit3.EditFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit3.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit3.Name = "RepositoryItemTimeEdit3"
        '
        'ColRequiredDailyHoures
        '
        Me.ColRequiredDailyHoures.Caption = "ساعات مطلوبة"
        Me.ColRequiredDailyHoures.ColumnEdit = Me.RepositoryItemTimeSpanEdit1
        Me.ColRequiredDailyHoures.FieldName = "RequiredDailyHoures"
        Me.ColRequiredDailyHoures.Name = "ColRequiredDailyHoures"
        Me.ColRequiredDailyHoures.OptionsColumn.AllowEdit = False
        Me.ColRequiredDailyHoures.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "RequiredDailyHoures", "", "5")})
        Me.ColRequiredDailyHoures.Visible = True
        Me.ColRequiredDailyHoures.Width = 117
        '
        'RepositoryItemTimeSpanEdit1
        '
        Me.RepositoryItemTimeSpanEdit1.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit1.DisplayFormat.FormatString = "hh:mm"
        Me.RepositoryItemTimeSpanEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeSpanEdit1.EditFormat.FormatString = "hh:mm"
        Me.RepositoryItemTimeSpanEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeSpanEdit1.Mask.EditMask = "hh\:mm"
        Me.RepositoryItemTimeSpanEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit1.Name = "RepositoryItemTimeSpanEdit1"
        '
        'ColRestDailyHoures
        '
        Me.ColRestDailyHoures.Caption = "فترة الاستراحة"
        Me.ColRestDailyHoures.ColumnEdit = Me.RestTimeSpanEdit
        Me.ColRestDailyHoures.DisplayFormat.FormatString = "HH:mn"
        Me.ColRestDailyHoures.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRestDailyHoures.FieldName = "RestDailyHoures"
        Me.ColRestDailyHoures.Name = "ColRestDailyHoures"
        Me.ColRestDailyHoures.OptionsColumn.AllowEdit = False
        Me.ColRestDailyHoures.OptionsColumn.ReadOnly = True
        '
        'RestTimeSpanEdit
        '
        Me.RestTimeSpanEdit.AutoHeight = False
        Me.RestTimeSpanEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RestTimeSpanEdit.Mask.EditMask = "HH:mm"
        Me.RestTimeSpanEdit.Mask.UseMaskAsDisplayFormat = True
        Me.RestTimeSpanEdit.Name = "RestTimeSpanEdit"
        '
        'ColAttStatus
        '
        Me.ColAttStatus.Caption = "حالة الدوام"
        Me.ColAttStatus.FieldName = "AttStatus"
        Me.ColAttStatus.Name = "ColAttStatus"
        Me.ColAttStatus.OptionsColumn.AllowEdit = False
        Me.ColAttStatus.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AttStatus", "الدوام {0}", "102"), New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Voc", "اجازات {0}"), New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AttStatus", "العطل {0}", "100"), New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "AttStatus", "غياب {0}", "101")})
        Me.ColAttStatus.Visible = True
        Me.ColAttStatus.Width = 50
        '
        'ColBonusPerHour
        '
        Me.ColBonusPerHour.Caption = "معامل البونص/الساعة"
        Me.ColBonusPerHour.FieldName = "BonusPerHour"
        Me.ColBonusPerHour.Name = "ColBonusPerHour"
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "الوردية"
        Me.gridBand3.Columns.Add(Me.ColPlaneID)
        Me.gridBand3.Columns.Add(Me.ColStartTime)
        Me.gridBand3.Columns.Add(Me.ColEndTime)
        Me.gridBand3.Columns.Add(Me.ColMissedDuration)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.Visible = False
        Me.gridBand3.VisibleIndex = -1
        Me.gridBand3.Width = 174
        '
        'ColPlaneID
        '
        Me.ColPlaneID.Caption = "الوردية"
        Me.ColPlaneID.FieldName = "PlaneID"
        Me.ColPlaneID.Name = "ColPlaneID"
        Me.ColPlaneID.OptionsColumn.AllowEdit = False
        Me.ColPlaneID.Visible = True
        '
        'ColEndTime
        '
        Me.ColEndTime.Caption = "نهاية الوردية"
        Me.ColEndTime.ColumnEdit = Me.RepositoryItemTimeEdit6
        Me.ColEndTime.FieldName = "EndTime"
        Me.ColEndTime.Name = "ColEndTime"
        Me.ColEndTime.OptionsColumn.AllowEdit = False
        Me.ColEndTime.Visible = True
        '
        'RepositoryItemTimeEdit6
        '
        Me.RepositoryItemTimeEdit6.AutoHeight = False
        Me.RepositoryItemTimeEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit6.DisplayFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit6.EditFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit6.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit6.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit6.Name = "RepositoryItemTimeEdit6"
        '
        'ColMissedDuration
        '
        Me.ColMissedDuration.Caption = "مغادرات"
        Me.ColMissedDuration.ColumnEdit = Me.RepositoryItemTimeSpanEdit2
        Me.ColMissedDuration.DisplayFormat.FormatString = "dd:mm"
        Me.ColMissedDuration.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColMissedDuration.FieldName = "MissedDuration"
        Me.ColMissedDuration.Name = "ColMissedDuration"
        Me.ColMissedDuration.OptionsColumn.AllowEdit = False
        Me.ColMissedDuration.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MissedDuration", "", "6")})
        Me.ColMissedDuration.Visible = True
        '
        'RepositoryItemTimeSpanEdit2
        '
        Me.RepositoryItemTimeSpanEdit2.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit2.Mask.EditMask = "hh:mm"
        Me.RepositoryItemTimeSpanEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit2.Name = "RepositoryItemTimeSpanEdit2"
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "تاخير صباحي / مسائي"
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.Visible = False
        Me.gridBand4.VisibleIndex = -1
        Me.gridBand4.Width = 105
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "اضافي صباحي / مسائي"
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.Visible = False
        Me.gridBand5.VisibleIndex = -1
        Me.gridBand5.Width = 178
        '
        'GridBand6
        '
        Me.GridBand6.Caption = "فترة السماح"
        Me.GridBand6.Name = "GridBand6"
        Me.GridBand6.Visible = False
        Me.GridBand6.VisibleIndex = -1
        Me.GridBand6.Width = 150
        '
        'gridBand7
        '
        Me.gridBand7.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand7.Caption = "فترات الدوام"
        Me.gridBand7.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.LeaveBand1, Me.LeaveBand2, Me.LeaveBand3, Me.LeaveBand4, Me.LeaveBand5})
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 2
        Me.gridBand7.Width = 295
        '
        'LeaveBand1
        '
        Me.LeaveBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.LeaveBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LeaveBand1.Caption = "الفترة الاولى"
        Me.LeaveBand1.Columns.Add(Me.BandedGridColumn1)
        Me.LeaveBand1.Columns.Add(Me.BandedGridColumn6)
        Me.LeaveBand1.Columns.Add(Me.ColDuration11)
        Me.LeaveBand1.Name = "LeaveBand1"
        Me.LeaveBand1.VisibleIndex = 0
        Me.LeaveBand1.Width = 295
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "دخول 1  "
        Me.BandedGridColumn1.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn1.FieldName = "StartTimeReal1"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn1.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 100
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.Caption = "خروج 1"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn6.FieldName = "EndTimeReal1"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn6.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 78
        '
        'ColDuration11
        '
        Me.ColDuration11.Caption = "الفترة 1"
        Me.ColDuration11.ColumnEdit = Me.RepositoryItemTimeSpanEdit3
        Me.ColDuration11.FieldName = "Duration1"
        Me.ColDuration11.Name = "ColDuration11"
        Me.ColDuration11.OptionsColumn.AllowEdit = False
        Me.ColDuration11.OptionsColumn.ReadOnly = True
        Me.ColDuration11.Visible = True
        Me.ColDuration11.Width = 117
        '
        'RepositoryItemTimeSpanEdit3
        '
        Me.RepositoryItemTimeSpanEdit3.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit3.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit3.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit3.Name = "RepositoryItemTimeSpanEdit3"
        '
        'LeaveBand2
        '
        Me.LeaveBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.LeaveBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LeaveBand2.Caption = "الفترة الثانية"
        Me.LeaveBand2.Columns.Add(Me.BandedGridColumn2)
        Me.LeaveBand2.Columns.Add(Me.BandedGridColumn7)
        Me.LeaveBand2.Columns.Add(Me.ColDuration2)
        Me.LeaveBand2.Name = "LeaveBand2"
        Me.LeaveBand2.Visible = False
        Me.LeaveBand2.VisibleIndex = -1
        Me.LeaveBand2.Width = 261
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "دخول 2 "
        Me.BandedGridColumn2.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn2.FieldName = "StartTimeReal2"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn2.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 76
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.Caption = "خروج 2"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn7.FieldName = "EndTimeReal2"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 76
        '
        'ColDuration2
        '
        Me.ColDuration2.Caption = "الفترة 2 "
        Me.ColDuration2.ColumnEdit = Me.RepositoryItemTimeSpanEdit4
        Me.ColDuration2.FieldName = "Duration2"
        Me.ColDuration2.Name = "ColDuration2"
        Me.ColDuration2.OptionsColumn.AllowEdit = False
        Me.ColDuration2.OptionsColumn.ReadOnly = True
        Me.ColDuration2.Visible = True
        Me.ColDuration2.Width = 109
        '
        'RepositoryItemTimeSpanEdit4
        '
        Me.RepositoryItemTimeSpanEdit4.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit4.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit4.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit4.Name = "RepositoryItemTimeSpanEdit4"
        '
        'LeaveBand3
        '
        Me.LeaveBand3.Caption = "الفترة الثالثة"
        Me.LeaveBand3.Columns.Add(Me.BandedGridColumn3)
        Me.LeaveBand3.Columns.Add(Me.BandedGridColumn8)
        Me.LeaveBand3.Columns.Add(Me.ColDuration3)
        Me.LeaveBand3.Name = "LeaveBand3"
        Me.LeaveBand3.Visible = False
        Me.LeaveBand3.VisibleIndex = -1
        Me.LeaveBand3.Width = 119
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "دخول3"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn3.FieldName = "StartTimeReal3"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn3.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 43
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.Caption = "خروج3"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn8.FieldName = "EndTimeReal3"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn8.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 38
        '
        'ColDuration3
        '
        Me.ColDuration3.Caption = "الفترة3"
        Me.ColDuration3.ColumnEdit = Me.RepositoryItemTimeSpanEdit5
        Me.ColDuration3.FieldName = "Duration3"
        Me.ColDuration3.Name = "ColDuration3"
        Me.ColDuration3.OptionsColumn.AllowEdit = False
        Me.ColDuration3.OptionsColumn.ReadOnly = True
        Me.ColDuration3.Visible = True
        Me.ColDuration3.Width = 38
        '
        'RepositoryItemTimeSpanEdit5
        '
        Me.RepositoryItemTimeSpanEdit5.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit5.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit5.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit5.Name = "RepositoryItemTimeSpanEdit5"
        '
        'LeaveBand4
        '
        Me.LeaveBand4.Caption = "الفترة الرابعة"
        Me.LeaveBand4.Columns.Add(Me.BandedGridColumn4)
        Me.LeaveBand4.Columns.Add(Me.BandedGridColumn9)
        Me.LeaveBand4.Columns.Add(Me.ColDuration4)
        Me.LeaveBand4.Name = "LeaveBand4"
        Me.LeaveBand4.Visible = False
        Me.LeaveBand4.VisibleIndex = -1
        Me.LeaveBand4.Width = 124
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "دخول4"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn4.FieldName = "StartTimeReal4"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 48
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.Caption = "خروج4"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn9.FieldName = "EndTimeReal4"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn9.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 38
        '
        'ColDuration4
        '
        Me.ColDuration4.Caption = "الفترة4"
        Me.ColDuration4.ColumnEdit = Me.RepositoryItemTimeSpanEdit6
        Me.ColDuration4.FieldName = "Duration4"
        Me.ColDuration4.Name = "ColDuration4"
        Me.ColDuration4.OptionsColumn.AllowEdit = False
        Me.ColDuration4.OptionsColumn.ReadOnly = True
        Me.ColDuration4.Visible = True
        Me.ColDuration4.Width = 38
        '
        'RepositoryItemTimeSpanEdit6
        '
        Me.RepositoryItemTimeSpanEdit6.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit6.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit6.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit6.Name = "RepositoryItemTimeSpanEdit6"
        '
        'LeaveBand5
        '
        Me.LeaveBand5.Caption = "الفترة الخامسة"
        Me.LeaveBand5.Columns.Add(Me.BandedGridColumn5)
        Me.LeaveBand5.Columns.Add(Me.BandedGridColumn10)
        Me.LeaveBand5.Columns.Add(Me.ColDuration5)
        Me.LeaveBand5.Name = "LeaveBand5"
        Me.LeaveBand5.Visible = False
        Me.LeaveBand5.VisibleIndex = -1
        Me.LeaveBand5.Width = 126
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "دخول5"
        Me.BandedGridColumn5.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn5.FieldName = "StartTimeReal5"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 50
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "خروج5"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "HH:mm"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumn10.FieldName = "EndTimeReal5"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn10.OptionsColumn.ReadOnly = True
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 38
        '
        'ColDuration5
        '
        Me.ColDuration5.Caption = "الفترة5"
        Me.ColDuration5.ColumnEdit = Me.RepositoryItemTimeSpanEdit7
        Me.ColDuration5.FieldName = "Duration5"
        Me.ColDuration5.Name = "ColDuration5"
        Me.ColDuration5.OptionsColumn.AllowEdit = False
        Me.ColDuration5.OptionsColumn.ReadOnly = True
        Me.ColDuration5.Visible = True
        Me.ColDuration5.Width = 38
        '
        'RepositoryItemTimeSpanEdit7
        '
        Me.RepositoryItemTimeSpanEdit7.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit7.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit7.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit7.Name = "RepositoryItemTimeSpanEdit7"
        '
        'gridBand13
        '
        Me.gridBand13.Caption = "المجموع"
        Me.gridBand13.Columns.Add(Me.ColTotalDurations)
        Me.gridBand13.Columns.Add(Me.ColBonusHours)
        Me.gridBand13.Columns.Add(Me.ColLeavesHours)
        Me.gridBand13.Columns.Add(Me.ColNetDurations)
        Me.gridBand13.Name = "gridBand13"
        Me.gridBand13.VisibleIndex = 3
        Me.gridBand13.Width = 292
        '
        'ColTotalDurations
        '
        Me.ColTotalDurations.Caption = "اجمالي الدوام"
        Me.ColTotalDurations.ColumnEdit = Me.RepositoryItemTimeSpanEdit12
        Me.ColTotalDurations.FieldName = "TotalDurations"
        Me.ColTotalDurations.Name = "ColTotalDurations"
        Me.ColTotalDurations.OptionsColumn.AllowEdit = False
        Me.ColTotalDurations.OptionsColumn.ReadOnly = True
        Me.ColTotalDurations.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TotalDurations", "", "11")})
        Me.ColTotalDurations.Visible = True
        Me.ColTotalDurations.Width = 74
        '
        'RepositoryItemTimeSpanEdit12
        '
        Me.RepositoryItemTimeSpanEdit12.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit12.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit12.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit12.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit12.Name = "RepositoryItemTimeSpanEdit12"
        '
        'ColBonusHours
        '
        Me.ColBonusHours.Caption = "اضافي"
        Me.ColBonusHours.ColumnEdit = Me.RepositoryItemTimeSpanEdit8
        Me.ColBonusHours.FieldName = "BonusHours"
        Me.ColBonusHours.Name = "ColBonusHours"
        Me.ColBonusHours.OptionsColumn.AllowEdit = False
        Me.ColBonusHours.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "BonusHours", "", "16")})
        Me.ColBonusHours.Visible = True
        Me.ColBonusHours.Width = 107
        '
        'RepositoryItemTimeSpanEdit8
        '
        Me.RepositoryItemTimeSpanEdit8.AutoHeight = False
        Me.RepositoryItemTimeSpanEdit8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeSpanEdit8.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeSpanEdit8.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeSpanEdit8.Name = "RepositoryItemTimeSpanEdit8"
        '
        'ColLeavesHours
        '
        Me.ColLeavesHours.Caption = "مغادرات"
        Me.ColLeavesHours.ColumnEdit = Me.RepositoryItemTimeEdit4
        Me.ColLeavesHours.FieldName = "LeavesHours"
        Me.ColLeavesHours.Name = "ColLeavesHours"
        Me.ColLeavesHours.OptionsColumn.AllowEdit = False
        Me.ColLeavesHours.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "LeavesHours", "", "15")})
        Me.ColLeavesHours.Visible = True
        Me.ColLeavesHours.Width = 111
        '
        'RepositoryItemTimeEdit4
        '
        Me.RepositoryItemTimeEdit4.AutoHeight = False
        Me.RepositoryItemTimeEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit4.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit4.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTimeEdit4.Name = "RepositoryItemTimeEdit4"
        '
        'ColNetDurations
        '
        Me.ColNetDurations.Caption = "صافي الدوام"
        Me.ColNetDurations.FieldName = "NetDurations"
        Me.ColNetDurations.Name = "ColNetDurations"
        '
        'gridBand8
        '
        Me.gridBand8.Caption = "مغادرات العمل"
        Me.gridBand8.Children.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.LeaveJobBand1, Me.LeaveJobBand2, Me.LeaveJobBand3, Me.LeaveJobBand4, Me.LeaveJobBand5})
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.Visible = False
        Me.gridBand8.VisibleIndex = -1
        Me.gridBand8.Width = 146
        '
        'LeaveJobBand1
        '
        Me.LeaveJobBand1.Caption = "مغادرة عمل1"
        Me.LeaveJobBand1.Name = "LeaveJobBand1"
        Me.LeaveJobBand1.VisibleIndex = 0
        Me.LeaveJobBand1.Width = 73
        '
        'LeaveJobBand2
        '
        Me.LeaveJobBand2.Caption = "مغادرة عمل2"
        Me.LeaveJobBand2.Name = "LeaveJobBand2"
        Me.LeaveJobBand2.VisibleIndex = 1
        Me.LeaveJobBand2.Width = 73
        '
        'LeaveJobBand3
        '
        Me.LeaveJobBand3.Caption = "مغادرة عمل3"
        Me.LeaveJobBand3.Name = "LeaveJobBand3"
        Me.LeaveJobBand3.Visible = False
        Me.LeaveJobBand3.VisibleIndex = -1
        Me.LeaveJobBand3.Width = 225
        '
        'LeaveJobBand4
        '
        Me.LeaveJobBand4.Caption = "مغادرة عمل4"
        Me.LeaveJobBand4.Name = "LeaveJobBand4"
        Me.LeaveJobBand4.Visible = False
        Me.LeaveJobBand4.VisibleIndex = -1
        Me.LeaveJobBand4.Width = 225
        '
        'LeaveJobBand5
        '
        Me.LeaveJobBand5.Caption = "مغادرة عمل5"
        Me.LeaveJobBand5.Name = "LeaveJobBand5"
        Me.LeaveJobBand5.Visible = False
        Me.LeaveJobBand5.VisibleIndex = -1
        Me.LeaveJobBand5.Width = 225
        '
        'gridBand16
        '
        Me.gridBand16.Caption = "مجموع م العمل"
        Me.gridBand16.Name = "gridBand16"
        Me.gridBand16.Visible = False
        Me.gridBand16.VisibleIndex = -1
        Me.gridBand16.Width = 25
        '
        'gridBand9
        '
        Me.gridBand9.Caption = "الراتب"
        Me.gridBand9.Columns.Add(Me.ColDailyTransport)
        Me.gridBand9.Columns.Add(Me.Colpayment)
        Me.gridBand9.Columns.Add(Me.ColBonusHoursNIS)
        Me.gridBand9.Columns.Add(Me.ColLeavesHoursNIS)
        Me.gridBand9.Columns.Add(Me.ColMonthlySalaryPerDay)
        Me.gridBand9.Columns.Add(Me.ColSalaryPerHour)
        Me.gridBand9.Columns.Add(Me.ColNetSalary)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 4
        Me.gridBand9.Width = 525
        '
        'ColDailyTransport
        '
        Me.ColDailyTransport.Caption = "المواصلات"
        Me.ColDailyTransport.FieldName = "DailyTransport"
        Me.ColDailyTransport.Name = "ColDailyTransport"
        Me.ColDailyTransport.Visible = True
        '
        'Colpayment
        '
        Me.Colpayment.Caption = "السلف"
        Me.Colpayment.FieldName = "Payment"
        Me.Colpayment.Name = "Colpayment"
        Me.Colpayment.Visible = True
        '
        'ColBonusHoursNIS
        '
        Me.ColBonusHoursNIS.Caption = "مبلغ الاضافي"
        Me.ColBonusHoursNIS.FieldName = "BonusHoursNIS"
        Me.ColBonusHoursNIS.Name = "ColBonusHoursNIS"
        Me.ColBonusHoursNIS.Visible = True
        '
        'ColLeavesHoursNIS
        '
        Me.ColLeavesHoursNIS.Caption = "مبلغ المغادرات"
        Me.ColLeavesHoursNIS.FieldName = "LeavesHoursNIS"
        Me.ColLeavesHoursNIS.Name = "ColLeavesHoursNIS"
        Me.ColLeavesHoursNIS.Visible = True
        '
        'ColMonthlySalaryPerDay
        '
        Me.ColMonthlySalaryPerDay.Caption = "الراتب اليومي"
        Me.ColMonthlySalaryPerDay.FieldName = "MonthlySalaryPerDay"
        Me.ColMonthlySalaryPerDay.Name = "ColMonthlySalaryPerDay"
        Me.ColMonthlySalaryPerDay.Visible = True
        '
        'ColSalaryPerHour
        '
        Me.ColSalaryPerHour.Caption = "راتب الساعة"
        Me.ColSalaryPerHour.FieldName = "SalaryPerHour"
        Me.ColSalaryPerHour.Name = "ColSalaryPerHour"
        Me.ColSalaryPerHour.OptionsColumn.AllowEdit = False
        Me.ColSalaryPerHour.Visible = True
        '
        'ColNetSalary
        '
        Me.ColNetSalary.Caption = "صافي الراتب"
        Me.ColNetSalary.FieldName = "NetSalary"
        Me.ColNetSalary.Name = "ColNetSalary"
        Me.ColNetSalary.OptionsColumn.AllowEdit = False
        Me.ColNetSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NetSalary", "{0:n0}")})
        Me.ColNetSalary.Visible = True
        '
        'ColTransInID
        '
        Me.ColTransInID.Caption = "رقم حركة الدخول"
        Me.ColTransInID.FieldName = "TransInID"
        Me.ColTransInID.Name = "ColTransInID"
        Me.ColTransInID.OptionsColumn.AllowEdit = False
        Me.ColTransInID.Visible = True
        '
        'ColTransOutID
        '
        Me.ColTransOutID.Caption = "رقم حركة الخروج"
        Me.ColTransOutID.FieldName = "TransOutID"
        Me.ColTransOutID.Name = "ColTransOutID"
        Me.ColTransOutID.OptionsColumn.AllowEdit = False
        Me.ColTransOutID.Visible = True
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "HH:mm"
        Me.RepositoryItemSpinEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'CheckEditCheckActive
        '
        Me.CheckEditCheckActive.EditValue = True
        Me.CheckEditCheckActive.Location = New System.Drawing.Point(24, 336)
        Me.CheckEditCheckActive.Name = "CheckEditCheckActive"
        Me.CheckEditCheckActive.Properties.Caption = "الموظفين الفاعلين فقط"
        Me.CheckEditCheckActive.Size = New System.Drawing.Size(242, 19)
        Me.CheckEditCheckActive.StyleController = Me.LayoutControl1
        Me.CheckEditCheckActive.TabIndex = 31
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckEdit1)
        Me.LayoutControl1.Controls.Add(Me.CheckEditRestTime)
        Me.LayoutControl1.Controls.Add(Me.RadioGroup2)
        Me.LayoutControl1.Controls.Add(Me.CheckCalcVocationsAtOffDay)
        Me.LayoutControl1.Controls.Add(Me.CheckElapseOnVocation)
        Me.LayoutControl1.Controls.Add(Me.SimpleButtonAddVocations)
        Me.LayoutControl1.Controls.Add(Me.SimpleButtonInsertAttTrans)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.CheckEditCheckActive)
        Me.LayoutControl1.Controls.Add(Me.SpinEdit1)
        Me.LayoutControl1.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditDepartment)
        Me.LayoutControl1.Controls.Add(Me.DateEdit2)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditPosition)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditBranch)
        Me.LayoutControl1.Controls.Add(Me.SearchLookUpEdit1)
        Me.LayoutControl1.Controls.Add(Me.DateEdit1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(290, 599)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CheckEdit1
        '
        Me.CheckEdit1.EditValue = True
        Me.CheckEdit1.Location = New System.Drawing.Point(24, 428)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Caption = "ملائمة التقرير للشاشة"
        Me.CheckEdit1.Size = New System.Drawing.Size(242, 19)
        Me.CheckEdit1.StyleController = Me.LayoutControl1
        Me.CheckEdit1.TabIndex = 40
        '
        'CheckEditRestTime
        '
        Me.CheckEditRestTime.EditValue = True
        Me.CheckEditRestTime.Location = New System.Drawing.Point(24, 405)
        Me.CheckEditRestTime.Name = "CheckEditRestTime"
        Me.CheckEditRestTime.Properties.Caption = "خصم فترة الاستراحة"
        Me.CheckEditRestTime.Size = New System.Drawing.Size(242, 19)
        Me.CheckEditRestTime.StyleController = Me.LayoutControl1
        Me.CheckEditRestTime.TabIndex = 39
        '
        'RadioGroup2
        '
        Me.RadioGroup2.EditValue = "1"
        Me.RadioGroup2.Location = New System.Drawing.Point(24, 168)
        Me.RadioGroup2.Name = "RadioGroup2"
        Me.RadioGroup2.Properties.Columns = 2
        Me.RadioGroup2.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("1", "تفصيلي"), New DevExpress.XtraEditors.Controls.RadioGroupItem("2", "تجميعي")})
        Me.RadioGroup2.Size = New System.Drawing.Size(242, 25)
        Me.RadioGroup2.StyleController = Me.LayoutControl1
        Me.RadioGroup2.TabIndex = 38
        '
        'CheckCalcVocationsAtOffDay
        '
        Me.CheckCalcVocationsAtOffDay.Location = New System.Drawing.Point(24, 382)
        Me.CheckCalcVocationsAtOffDay.Name = "CheckCalcVocationsAtOffDay"
        Me.CheckCalcVocationsAtOffDay.Properties.Appearance.Options.UseTextOptions = True
        Me.CheckCalcVocationsAtOffDay.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.CheckCalcVocationsAtOffDay.Properties.Caption = " يوم العطلة اجازة اذا كانت ضمن فترة الاجازة"
        Me.CheckCalcVocationsAtOffDay.Size = New System.Drawing.Size(242, 19)
        Me.CheckCalcVocationsAtOffDay.StyleController = Me.LayoutControl1
        Me.CheckCalcVocationsAtOffDay.TabIndex = 37
        '
        'CheckElapseOnVocation
        '
        Me.CheckElapseOnVocation.Location = New System.Drawing.Point(24, 359)
        Me.CheckElapseOnVocation.Name = "CheckElapseOnVocation"
        Me.CheckElapseOnVocation.Properties.Caption = "فترة الدوام صفر يوم الاجازة"
        Me.CheckElapseOnVocation.Size = New System.Drawing.Size(242, 19)
        Me.CheckElapseOnVocation.StyleController = Me.LayoutControl1
        Me.CheckElapseOnVocation.TabIndex = 36
        '
        'SimpleButtonAddVocations
        '
        Me.SimpleButtonAddVocations.ImageOptions.Image = CType(resources.GetObject("SimpleButtonAddVocations.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButtonAddVocations.Location = New System.Drawing.Point(12, 485)
        Me.SimpleButtonAddVocations.Name = "SimpleButtonAddVocations"
        Me.SimpleButtonAddVocations.Size = New System.Drawing.Size(128, 22)
        Me.SimpleButtonAddVocations.StyleController = Me.LayoutControl1
        Me.SimpleButtonAddVocations.TabIndex = 35
        Me.SimpleButtonAddVocations.Text = "اضافة اجازة"
        '
        'SimpleButtonInsertAttTrans
        '
        Me.SimpleButtonInsertAttTrans.ImageOptions.Image = CType(resources.GetObject("SimpleButtonInsertAttTrans.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButtonInsertAttTrans.Location = New System.Drawing.Point(144, 485)
        Me.SimpleButtonInsertAttTrans.Name = "SimpleButtonInsertAttTrans"
        Me.SimpleButtonInsertAttTrans.Size = New System.Drawing.Size(134, 22)
        Me.SimpleButtonInsertAttTrans.StyleController = Me.LayoutControl1
        Me.SimpleButtonInsertAttTrans.TabIndex = 34
        Me.SimpleButtonInsertAttTrans.Text = "اضافة حركة Insert"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(12, 565)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(128, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 33
        Me.SimpleButton2.Text = "طباعة (F12)"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(144, 565)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(134, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 29
        Me.SimpleButton1.Text = "تحديث (F5)"
        '
        'SpinEdit1
        '
        Me.SpinEdit1.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SpinEdit1.Location = New System.Drawing.Point(24, 312)
        Me.SpinEdit1.Name = "SpinEdit1"
        Me.SpinEdit1.Properties.Appearance.Options.UseTextOptions = True
        Me.SpinEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SpinEdit1.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.SpinEdit1.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SpinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SpinEdit1.Properties.Mask.EditMask = "n0"
        Me.SpinEdit1.Properties.MaxValue = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SpinEdit1.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SpinEdit1.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        Me.SpinEdit1.Size = New System.Drawing.Size(155, 20)
        Me.SpinEdit1.StyleController = Me.LayoutControl1
        Me.SpinEdit1.TabIndex = 28
        '
        'RadioGroup1
        '
        Me.RadioGroup1.EditValue = "1"
        Me.RadioGroup1.Location = New System.Drawing.Point(24, 240)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Columns = 3
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("1", "الاسم"), New DevExpress.XtraEditors.Controls.RadioGroupItem("2", "التاريخ"), New DevExpress.XtraEditors.Controls.RadioGroupItem("3", "اليوم")})
        Me.RadioGroup1.Size = New System.Drawing.Size(242, 25)
        Me.RadioGroup1.StyleController = Me.LayoutControl1
        Me.RadioGroup1.TabIndex = 27
        '
        'LookUpEditDepartment
        '
        Me.LookUpEditDepartment.EditValue = ""
        Me.LookUpEditDepartment.Location = New System.Drawing.Point(24, 144)
        Me.LookUpEditDepartment.Name = "LookUpEditDepartment"
        Me.LookUpEditDepartment.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditDepartment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditDepartment.Properties.DataSource = Me.EmployeesDepartmentsBindingSource
        Me.LookUpEditDepartment.Properties.DisplayMember = "Department"
        Me.LookUpEditDepartment.Properties.NullText = "اختر القسم"
        Me.LookUpEditDepartment.Properties.NullValuePrompt = "اختر القسم"
        Me.LookUpEditDepartment.Properties.NullValuePromptShowForEmptyValue = True
        Me.LookUpEditDepartment.Properties.ShowHeader = False
        Me.LookUpEditDepartment.Properties.ShowNullValuePromptWhenFocused = True
        Me.LookUpEditDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditDepartment.Properties.ValueMember = "Department"
        Me.LookUpEditDepartment.Size = New System.Drawing.Size(242, 20)
        Me.LookUpEditDepartment.StyleController = Me.LayoutControl1
        Me.LookUpEditDepartment.TabIndex = 26
        '
        'EmployeesDepartmentsBindingSource
        '
        Me.EmployeesDepartmentsBindingSource.DataMember = "EmployeesDepartments"
        Me.EmployeesDepartmentsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = Nothing
        Me.DateEdit2.Location = New System.Drawing.Point(24, 48)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Size = New System.Drawing.Size(94, 20)
        Me.DateEdit2.StyleController = Me.LayoutControl1
        Me.DateEdit2.TabIndex = 24
        '
        'LookUpEditPosition
        '
        Me.LookUpEditPosition.EditValue = ""
        Me.LookUpEditPosition.Location = New System.Drawing.Point(24, 96)
        Me.LookUpEditPosition.Name = "LookUpEditPosition"
        Me.LookUpEditPosition.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpEditPosition.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditPosition.Properties.DataSource = Me.EmployeesPositionsBindingSource
        Me.LookUpEditPosition.Properties.DisplayMember = "Positions"
        Me.LookUpEditPosition.Properties.NullText = "اختر المسمى الوظيفي"
        Me.LookUpEditPosition.Properties.NullValuePrompt = "اختر المسمى الوظيفي"
        Me.LookUpEditPosition.Properties.NullValuePromptShowForEmptyValue = True
        Me.LookUpEditPosition.Properties.ShowHeader = False
        Me.LookUpEditPosition.Properties.ShowNullValuePromptWhenFocused = True
        Me.LookUpEditPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditPosition.Properties.ValueMember = "Positions"
        Me.LookUpEditPosition.Size = New System.Drawing.Size(242, 20)
        Me.LookUpEditPosition.StyleController = Me.LayoutControl1
        Me.LookUpEditPosition.TabIndex = 30
        '
        'EmployeesPositionsBindingSource
        '
        Me.EmployeesPositionsBindingSource.DataMember = "EmployeesPositions"
        Me.EmployeesPositionsBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'LookUpEditBranch
        '
        Me.LookUpEditBranch.EditValue = ""
        Me.LookUpEditBranch.Location = New System.Drawing.Point(24, 120)
        Me.LookUpEditBranch.Name = "LookUpEditBranch"
        Me.LookUpEditBranch.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditBranch.Properties.DataSource = Me.EmployeesBranchesBindingSource
        Me.LookUpEditBranch.Properties.DisplayMember = "Branch"
        Me.LookUpEditBranch.Properties.NullText = "اختر الفرع"
        Me.LookUpEditBranch.Properties.NullValuePrompt = "اختر الفرع"
        Me.LookUpEditBranch.Properties.NullValuePromptShowForEmptyValue = True
        Me.LookUpEditBranch.Properties.ShowHeader = False
        Me.LookUpEditBranch.Properties.ShowNullValuePromptWhenFocused = True
        Me.LookUpEditBranch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpEditBranch.Properties.ValueMember = "Branch"
        Me.LookUpEditBranch.Size = New System.Drawing.Size(242, 20)
        Me.LookUpEditBranch.StyleController = Me.LayoutControl1
        Me.LookUpEditBranch.TabIndex = 25
        '
        'EmployeesBranchesBindingSource
        '
        Me.EmployeesBranchesBindingSource.DataMember = "EmployeesBranches"
        Me.EmployeesBranchesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.EditValue = ""
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(24, 24)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.DataSource = Me.EmployeesDataBindingSource
        Me.SearchLookUpEdit1.Properties.DisplayMember = "EmployeeName"
        Me.SearchLookUpEdit1.Properties.NullText = " اختر الموظف"
        Me.SearchLookUpEdit1.Properties.NullValuePrompt = " اختر الموظف"
        Me.SearchLookUpEdit1.Properties.NullValuePromptShowForEmptyValue = True
        Me.SearchLookUpEdit1.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookUpEdit1.Properties.ShowNullValuePromptWhenFocused = True
        Me.SearchLookUpEdit1.Properties.ValueMember = "EmployeeID"
        Me.SearchLookUpEdit1.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.TileView
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(242, 20)
        Me.SearchLookUpEdit1.StyleController = Me.LayoutControl1
        Me.SearchLookUpEdit1.TabIndex = 22
        '
        'EmployeesDataBindingSource
        '
        Me.EmployeesDataBindingSource.DataMember = "EmployeesData"
        Me.EmployeesDataBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colEmployeeName, Me.colEmployeeID, Me.colAttPlane, Me.colPictureEmp, Me.colMobile1, Me.colBranch, Me.colDepartment, Me.colJobName})
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsBehavior.AllowMousePanning = False
        Me.SearchLookUpEdit1View.OptionsBehavior.AllowSmoothScrolling = True
        Me.SearchLookUpEdit1View.OptionsTiles.AllowPressAnimation = False
        Me.SearchLookUpEdit1View.OptionsTiles.ItemSize = New System.Drawing.Size(248, 100)
        Me.SearchLookUpEdit1View.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List
        Me.SearchLookUpEdit1View.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.SearchLookUpEdit1View.OptionsTiles.Padding = New System.Windows.Forms.Padding(0)
        Me.SearchLookUpEdit1View.TileColumns.Add(TableColumnDefinition1)
        Me.SearchLookUpEdit1View.TileColumns.Add(TableColumnDefinition2)
        Me.SearchLookUpEdit1View.TileRows.Add(TableRowDefinition1)
        Me.SearchLookUpEdit1View.TileRows.Add(TableRowDefinition2)
        Me.SearchLookUpEdit1View.TileRows.Add(TableRowDefinition3)
        TableSpan1.RowSpan = 3
        Me.SearchLookUpEdit1View.TileSpans.Add(TableSpan1)
        TileViewItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement1.Column = Me.colEmployeeName
        TileViewItemElement1.ColumnIndex = 1
        TileViewItemElement1.Text = "colEmployeeName"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        TileViewItemElement2.Column = Me.colPictureEmp
        TileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileViewItemElement2.RowIndex = 1
        TileViewItemElement2.Text = "colPictureEmp"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement3.Column = Me.colBranch
        TileViewItemElement3.ColumnIndex = 1
        TileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileViewItemElement3.RowIndex = 1
        TileViewItemElement3.Text = "colBranch"
        TileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement4.Column = Me.colDepartment
        TileViewItemElement4.ColumnIndex = 1
        TileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileViewItemElement4.RowIndex = 2
        TileViewItemElement4.Text = "colDepartment"
        TileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement1)
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement2)
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement3)
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement4)
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'colEmployeeID
        '
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.Visible = True
        Me.colEmployeeID.VisibleIndex = 2
        '
        'colAttPlane
        '
        Me.colAttPlane.FieldName = "AttPlane"
        Me.colAttPlane.Name = "colAttPlane"
        Me.colAttPlane.Visible = True
        Me.colAttPlane.VisibleIndex = 3
        '
        'colMobile1
        '
        Me.colMobile1.FieldName = "Mobile1"
        Me.colMobile1.Name = "colMobile1"
        Me.colMobile1.Visible = True
        Me.colMobile1.VisibleIndex = 5
        '
        'colJobName
        '
        Me.colJobName.FieldName = "JobName"
        Me.colJobName.Name = "colJobName"
        Me.colJobName.Visible = True
        Me.colJobName.VisibleIndex = 8
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(144, 48)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Size = New System.Drawing.Size(103, 20)
        Me.DateEdit1.StyleController = Me.LayoutControl1
        Me.DateEdit1.TabIndex = 23
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup4, Me.LayoutControlGroup5, Me.LayoutControlGroup3, Me.LayoutControlItem13, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem11, Me.LayoutControlItem12})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(290, 599)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem16})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(270, 125)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LookUpEditPosition
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.LookUpEditBranch
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LookUpEditDepartment
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.RadioGroup2
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(0, 29)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(54, 29)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(246, 29)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.Text = "طريقة العرض"
        Me.LayoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextToControlDistance = 0
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 197)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(270, 72)
        Me.LayoutControlGroup4.Text = "تجميع حسب"
        Me.LayoutControlGroup4.TextLocation = DevExpress.Utils.Locations.[Default]
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.RadioGroup1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 29)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(54, 29)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(246, 29)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem8, Me.LayoutControlItem17, Me.LayoutControlItem18})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 269)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(270, 182)
        Me.LayoutControlGroup5.Text = "خيارات التقرير"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.CheckEditCheckActive
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.CheckElapseOnVocation
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 47)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.CheckCalcVocationsAtOffDay
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 70)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.SpinEdit1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem8.Text = "عدد فترات الدوام :"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(84, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.CheckEditRestTime
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 93)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.CheckEdit1
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 116)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(270, 72)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateEdit1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(120, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(126, 24)
        Me.LayoutControlItem4.Text = "من"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(14, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SearchLookUpEdit1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DateEdit2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(120, 24)
        Me.LayoutControlItem2.Text = "الى"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(17, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.SimpleButtonInsertAttTrans
        Me.LayoutControlItem13.Location = New System.Drawing.Point(132, 473)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButton1
        Me.LayoutControlItem10.Location = New System.Drawing.Point(132, 553)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(138, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 499)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(270, 54)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 451)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 22)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 22)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(270, 22)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.SimpleButtonAddVocations
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 473)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(132, 26)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.SimpleButton2
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 553)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(132, 26)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmployeesDataTableAdapter
        '
        Me.EmployeesDataTableAdapter.ClearBeforeFill = True
        '
        'EmployeesBranchesTableAdapter
        '
        Me.EmployeesBranchesTableAdapter.ClearBeforeFill = True
        '
        'EmployeesDepartmentsTableAdapter
        '
        Me.EmployeesDepartmentsTableAdapter.ClearBeforeFill = True
        '
        'EmployeesPositionsTableAdapter
        '
        Me.EmployeesPositionsTableAdapter.ClearBeforeFill = True
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
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
        Me.DockPanel1.ID = New System.Guid("f1a25c6c-7c91-44e1-b75a-350d3acb681b")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.AllowDockAsTabbedDocument = False
        Me.DockPanel1.Options.AllowDockBottom = False
        Me.DockPanel1.Options.AllowDockFill = False
        Me.DockPanel1.Options.AllowDockTop = False
        Me.DockPanel1.Options.AllowFloating = False
        Me.DockPanel1.Options.FloatOnDblClick = False
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.Options.ShowMaximizeButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(299, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(299, 628)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(5, 25)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(290, 599)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'ColMonthlySalary
        '
        Me.ColMonthlySalary.Caption = "الراتب الشهري"
        Me.ColMonthlySalary.FieldName = "MonthlySalary"
        Me.ColMonthlySalary.Name = "ColMonthlySalary"
        Me.ColMonthlySalary.Visible = True
        '
        'AttCustomizedReport1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 628)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "AttCustomizedReport1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "تقرير الدوام حسب الساعات المطلوبة"
        CType(Me.RepositoryItemTimeEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RestTimeSpanEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeSpanEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditRestTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckCalcVocationsAtOffDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckElapseOnVocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SpinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditDepartment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDepartmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesPositionsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesBranchesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SpinEdit1 As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LookUpEditDepartment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEditBranch As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colAttPlane As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colPictureEmp As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colMobile1 As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colBranch As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colDepartment As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colJobName As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmployeesDepartmentsBindingSource As BindingSource
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesBranchesBindingSource As BindingSource
    Friend WithEvents EmployeesDataBindingSource As BindingSource
    Friend WithEvents EmployeesDataTableAdapter As TrueTimeDataSetTableAdapters.EmployeesDataTableAdapter
    Friend WithEvents EmployeesBranchesTableAdapter As TrueTimeDataSetTableAdapters.EmployeesBranchesTableAdapter
    Friend WithEvents EmployeesDepartmentsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesDepartmentsTableAdapter
    Friend WithEvents EmployeesPositionsBindingSource As BindingSource
    Friend WithEvents EmployeesPositionsTableAdapter As TrueTimeDataSetTableAdapters.EmployeesPositionsTableAdapter
    Friend WithEvents LookUpEditPosition As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents CheckEditCheckActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents ColEmpID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CollEmployeeName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColTransDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColTransDay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColAddAndEdit As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColStartTimeReal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents ColEndTimeReal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents ColRequiredDailyHoures As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents ColEditedType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColPlaneID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColStartTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents ColEndTime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents ColMissedDuration As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDuration11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDuration2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDuration3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDuration4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDuration5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents ColTotalDurations As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeSpanEdit12 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents ColTransInID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColTransOutID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColEditedTypeOut As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColAttStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SimpleButtonInsertAttTrans As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButtonAddVocations As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckElapseOnVocation As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColVoc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CheckCalcVocationsAtOffDay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents RadioGroup2 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ColLeavesHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColBonusHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColNetDurations As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColSalaryPerHour As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColNetSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemTimeSpanEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents ColRestDailyHoures As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RestTimeSpanEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeSpanEdit
    Friend WithEvents CheckEditRestTime As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColBonusPerHour As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColMonthlySalaryPerDay As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColBonusHoursNIS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColLeavesHoursNIS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDailyTransport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Colpayment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ColSalaryAccountNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand13 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveJobBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveJobBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveJobBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveJobBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LeaveJobBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand16 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ColMonthlySalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
