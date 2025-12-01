Imports DevExpress.XtraScheduler.UI
Partial Class OutlookAppointmentForm

#Region "Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OutlookAppointmentForm))
        Dim TrackBarLabel6 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel7 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel8 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel9 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Dim TrackBarLabel10 As DevExpress.XtraEditors.Repository.TrackBarLabel = New DevExpress.XtraEditors.Repository.TrackBarLabel()
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.backstageViewControl1 = New DevExpress.XtraBars.Ribbon.BackstageViewControl()
        Me.bvPrint = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.appointmentBackstageControl = New DevExpress.XtraScheduler.Design.AppointmentBackstageControl()
        Me.bvtPrint = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.bvbSave = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.bvbSaveAs = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.bvbClose = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.btnSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.barLabel = New DevExpress.XtraBars.BarEditItem()
        Me.riAppointmentLabel = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentLabel()
        Me.barStatus = New DevExpress.XtraBars.BarEditItem()
        Me.riAppointmentStatus = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentStatus()
        Me.barReminder = New DevExpress.XtraBars.BarEditItem()
        Me.riDuration = New DevExpress.XtraScheduler.UI.RepositoryItemDuration()
        Me.btnRecurrence = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSave = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNext = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrevious = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTimeZones = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonDone = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonFollowing = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonClose = New DevExpress.XtraBars.BarButtonItem()
        Me.ButtonApplyLable = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonTaskTrans = New DevExpress.XtraBars.BarButtonItem()
        Me.BarTaskStatus = New DevExpress.XtraBars.BarStaticItem()
        Me.BarButtonDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.rpAppointment = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgActions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.rpgOptions = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.riAppointmentResource = New DevExpress.XtraScheduler.UI.RepositoryItemAppointmentResource()
        Me.edtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.tbLocation = New DevExpress.XtraEditors.TextEdit()
        Me.edtStartTime = New DevExpress.XtraEditors.TimeEdit()
        Me.edtEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.edtEndTime = New DevExpress.XtraEditors.TimeEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        Me.panel1 = New DevExpress.XtraEditors.PanelControl()
        Me.edtTimeZone = New DevExpress.XtraScheduler.UI.TimeZoneEdit()
        Me.lblResource = New DevExpress.XtraEditors.LabelControl()
        Me.edtResource = New DevExpress.XtraScheduler.UI.AppointmentResourceEdit()
        Me.edtResources = New DevExpress.XtraScheduler.UI.AppointmentResourcesEdit()
        Me.chkAllDay = New DevExpress.XtraEditors.CheckEdit()
        Me.tbSubject = New DevExpress.XtraEditors.TextEdit()
        Me.tbProgress = New DevExpress.XtraEditors.TrackBarControl()
        Me.lblPercentComplete = New DevExpress.XtraEditors.LabelControl()
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.panelMain = New System.Windows.Forms.Panel()
        Me.tbDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.panelDescription = New System.Windows.Forms.Panel()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.UniqueID = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.ReferancesListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueAccountingDataSet = New TrueTime.AccountingDataSet()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CreationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblPercentCompleteValue = New DevExpress.XtraEditors.LabelControl()
        Me.SearchAssignedTo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.EmployeesData1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchCreationUser = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TextTaskStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.CRMTaskStatusesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colStatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchServiceNo = New DevExpress.XtraEditors.LookUpEdit()
        Me.EmployeesDataBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesData1TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter()
        Me.CRMTaskStatusesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter()
        Me.ReferancesListTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ReferancesListTableAdapter()
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backstageViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.backstageViewControl1.SuspendLayout()
        Me.bvPrint.SuspendLayout()
        CType(Me.riAppointmentLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riAppointmentStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riAppointmentResource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchServiceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesDataBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.ApplicationButtonDropDownControl = Me.backstageViewControl1
        Me.ribbonControl1.AutoSizeItems = True
        Me.ribbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue
        Me.ribbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(40, 37, 40, 37)
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.btnSaveAndClose, Me.btnDelete, Me.barLabel, Me.barStatus, Me.barReminder, Me.btnRecurrence, Me.btnSave, Me.btnNext, Me.btnPrevious, Me.btnTimeZones, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonDone, Me.BarButtonItem5, Me.BarButtonItem6, Me.BarButtonFollowing, Me.BarButtonClose, Me.ButtonApplyLable, Me.BarButtonTaskTrans, Me.BarTaskStatus, Me.BarButtonDelete, Me.BarButtonItem4})
        resources.ApplyResources(Me.ribbonControl1, "ribbonControl1")
        Me.ribbonControl1.MaxItemId = 15
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.OptionsMenuMinWidth = 440
        Me.ribbonControl1.PageHeaderItemLinks.Add(Me.BarTaskStatus)
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpAppointment})
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnSave)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnPrevious)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnNext)
        Me.ribbonControl1.QuickToolbarItemLinks.Add(Me.btnDelete)
        Me.ribbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.riAppointmentLabel, Me.riAppointmentResource, Me.riAppointmentStatus, Me.riDuration})
        Me.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice
        '
        'backstageViewControl1
        '
        resources.ApplyResources(Me.backstageViewControl1, "backstageViewControl1")
        Me.backstageViewControl1.Controls.Add(Me.bvPrint)
        Me.backstageViewControl1.Items.Add(Me.bvtPrint)
        Me.backstageViewControl1.Items.Add(Me.bvbSave)
        Me.backstageViewControl1.Items.Add(Me.bvbSaveAs)
        Me.backstageViewControl1.Items.Add(Me.bvbClose)
        Me.backstageViewControl1.Name = "backstageViewControl1"
        Me.backstageViewControl1.Office2013StyleOptions.HeaderBackColor = System.Drawing.SystemColors.Control
        Me.backstageViewControl1.OwnerControl = Me.ribbonControl1
        Me.backstageViewControl1.SelectedTab = Me.bvtPrint
        Me.backstageViewControl1.SelectedTabIndex = 0
        Me.backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013
        Me.backstageViewControl1.VisibleInDesignTime = True
        '
        'bvPrint
        '
        resources.ApplyResources(Me.bvPrint, "bvPrint")
        Me.bvPrint.Controls.Add(Me.appointmentBackstageControl)
        Me.bvPrint.Name = "bvPrint"
        '
        'appointmentBackstageControl
        '
        resources.ApplyResources(Me.appointmentBackstageControl, "appointmentBackstageControl")
        Me.appointmentBackstageControl.Name = "appointmentBackstageControl"
        '
        'bvtPrint
        '
        resources.ApplyResources(Me.bvtPrint, "bvtPrint")
        Me.bvtPrint.ContentControl = Me.bvPrint
        Me.bvtPrint.Name = "bvtPrint"
        Me.bvtPrint.Selected = True
        '
        'bvbSave
        '
        resources.ApplyResources(Me.bvbSave, "bvbSave")
        Me.bvbSave.Name = "bvbSave"
        '
        'bvbSaveAs
        '
        resources.ApplyResources(Me.bvbSaveAs, "bvbSaveAs")
        Me.bvbSaveAs.Name = "bvbSaveAs"
        '
        'bvbClose
        '
        resources.ApplyResources(Me.bvbClose, "bvbClose")
        Me.bvbClose.Name = "bvbClose"
        '
        'btnSaveAndClose
        '
        resources.ApplyResources(Me.btnSaveAndClose, "btnSaveAndClose")
        Me.btnSaveAndClose.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSaveAndClose.Id = 3
        Me.btnSaveAndClose.ImageOptions.Image = CType(resources.GetObject("btnSaveAndClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.LargeImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSaveAndClose.ImageOptions.SvgImage = CType(resources.GetObject("btnSaveAndClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSaveAndClose.Name = "btnSaveAndClose"
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnDelete.Id = 4
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.LargeImage = CType(resources.GetObject("btnDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.SvgImage = CType(resources.GetObject("btnDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'barLabel
        '
        resources.ApplyResources(Me.barLabel, "barLabel")
        Me.barLabel.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barLabel.Edit = Me.riAppointmentLabel
        Me.barLabel.Id = 8
        Me.barLabel.Name = "barLabel"
        '
        'riAppointmentLabel
        '
        resources.ApplyResources(Me.riAppointmentLabel, "riAppointmentLabel")
        Me.riAppointmentLabel.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentLabel.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentLabel.Name = "riAppointmentLabel"
        '
        'barStatus
        '
        resources.ApplyResources(Me.barStatus, "barStatus")
        Me.barStatus.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barStatus.Edit = Me.riAppointmentStatus
        Me.barStatus.Id = 11
        Me.barStatus.Name = "barStatus"
        '
        'riAppointmentStatus
        '
        resources.ApplyResources(Me.riAppointmentStatus, "riAppointmentStatus")
        Me.riAppointmentStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentStatus.Name = "riAppointmentStatus"
        '
        'barReminder
        '
        resources.ApplyResources(Me.barReminder, "barReminder")
        Me.barReminder.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.barReminder.Edit = Me.riDuration
        Me.barReminder.Id = 12
        Me.barReminder.Name = "barReminder"
        '
        'riDuration
        '
        resources.ApplyResources(Me.riDuration, "riDuration")
        Me.riDuration.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riDuration.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riDuration.DisabledStateText = Nothing
        Me.riDuration.Name = "riDuration"
        Me.riDuration.ShowEmptyItem = True
        '
        'btnRecurrence
        '
        Me.btnRecurrence.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        resources.ApplyResources(Me.btnRecurrence, "btnRecurrence")
        Me.btnRecurrence.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnRecurrence.Id = 17
        Me.btnRecurrence.ImageOptions.Image = CType(resources.GetObject("btnRecurrence.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.LargeImage = CType(resources.GetObject("btnRecurrence.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnRecurrence.ImageOptions.SvgImage = CType(resources.GetObject("btnRecurrence.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnRecurrence.Name = "btnRecurrence"
        Me.btnRecurrence.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnSave
        '
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnSave.Id = 1
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("btnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.SvgImage = CType(resources.GetObject("btnSave.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnSave.Name = "btnSave"
        '
        'btnNext
        '
        resources.ApplyResources(Me.btnNext, "btnNext")
        Me.btnNext.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnNext.Id = 3
        Me.btnNext.ImageOptions.Image = CType(resources.GetObject("btnNext.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNext.ImageOptions.LargeImage = CType(resources.GetObject("btnNext.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnNext.ImageOptions.SvgImage = CType(resources.GetObject("btnNext.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnNext.Name = "btnNext"
        '
        'btnPrevious
        '
        resources.ApplyResources(Me.btnPrevious, "btnPrevious")
        Me.btnPrevious.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnPrevious.Id = 4
        Me.btnPrevious.ImageOptions.Image = CType(resources.GetObject("btnPrevious.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.LargeImage = CType(resources.GetObject("btnPrevious.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPrevious.ImageOptions.SvgImage = CType(resources.GetObject("btnPrevious.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnPrevious.Name = "btnPrevious"
        '
        'btnTimeZones
        '
        Me.btnTimeZones.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check
        resources.ApplyResources(Me.btnTimeZones, "btnTimeZones")
        Me.btnTimeZones.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnTimeZones.Id = 1
        Me.btnTimeZones.ImageOptions.Image = CType(resources.GetObject("btnTimeZones.ImageOptions.Image"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.LargeImage = CType(resources.GetObject("btnTimeZones.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnTimeZones.ImageOptions.SvgImage = CType(resources.GetObject("btnTimeZones.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnTimeZones.Name = "btnTimeZones"
        Me.btnTimeZones.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        resources.ApplyResources(Me.BarButtonItem2, "BarButtonItem2")
        Me.BarButtonItem2.Id = 3
        Me.BarButtonItem2.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        resources.ApplyResources(Me.BarButtonItem3, "BarButtonItem3")
        Me.BarButtonItem3.Id = 4
        Me.BarButtonItem3.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonDone
        '
        resources.ApplyResources(Me.BarButtonDone, "BarButtonDone")
        Me.BarButtonDone.Id = 5
        Me.BarButtonDone.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonDone.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonDone.Name = "BarButtonDone"
        Me.BarButtonDone.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonItem5
        '
        resources.ApplyResources(Me.BarButtonItem5, "BarButtonItem5")
        Me.BarButtonItem5.Id = 6
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'BarButtonItem6
        '
        resources.ApplyResources(Me.BarButtonItem6, "BarButtonItem6")
        Me.BarButtonItem6.Id = 7
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'BarButtonFollowing
        '
        resources.ApplyResources(Me.BarButtonFollowing, "BarButtonFollowing")
        Me.BarButtonFollowing.Id = 8
        Me.BarButtonFollowing.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonFollowing.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonFollowing.Name = "BarButtonFollowing"
        Me.BarButtonFollowing.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonClose
        '
        resources.ApplyResources(Me.BarButtonClose, "BarButtonClose")
        Me.BarButtonClose.Id = 9
        Me.BarButtonClose.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonClose.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonClose.Name = "BarButtonClose"
        Me.BarButtonClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ButtonApplyLable
        '
        resources.ApplyResources(Me.ButtonApplyLable, "ButtonApplyLable")
        Me.ButtonApplyLable.Id = 10
        Me.ButtonApplyLable.ImageOptions.Image = CType(resources.GetObject("ButtonApplyLable.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonApplyLable.ImageOptions.LargeImage = CType(resources.GetObject("ButtonApplyLable.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.ButtonApplyLable.Name = "ButtonApplyLable"
        '
        'BarButtonTaskTrans
        '
        resources.ApplyResources(Me.BarButtonTaskTrans, "BarButtonTaskTrans")
        Me.BarButtonTaskTrans.Id = 11
        Me.BarButtonTaskTrans.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonTaskTrans.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonTaskTrans.Name = "BarButtonTaskTrans"
        '
        'BarTaskStatus
        '
        resources.ApplyResources(Me.BarTaskStatus, "BarTaskStatus")
        Me.BarTaskStatus.Id = 12
        Me.BarTaskStatus.ImageOptions.SvgImage = CType(resources.GetObject("BarTaskStatus.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarTaskStatus.ItemAppearance.Normal.Font = CType(resources.GetObject("BarTaskStatus.ItemAppearance.Normal.Font"), System.Drawing.Font)
        Me.BarTaskStatus.ItemAppearance.Normal.Options.UseFont = True
        Me.BarTaskStatus.Name = "BarTaskStatus"
        Me.BarTaskStatus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.BarTaskStatus.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarButtonDelete
        '
        resources.ApplyResources(Me.BarButtonDelete, "BarButtonDelete")
        Me.BarButtonDelete.Id = 13
        Me.BarButtonDelete.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonDelete.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonDelete.Name = "BarButtonDelete"
        '
        'BarButtonItem4
        '
        resources.ApplyResources(Me.BarButtonItem4, "BarButtonItem4")
        Me.BarButtonItem4.Id = 14
        Me.BarButtonItem4.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem4.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'rpAppointment
        '
        Me.rpAppointment.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgActions, Me.rpgOptions, Me.RibbonPageGroup2, Me.RibbonPageGroup1})
        Me.rpAppointment.Name = "rpAppointment"
        resources.ApplyResources(Me.rpAppointment, "rpAppointment")
        '
        'rpgActions
        '
        Me.rpgActions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgActions.ItemLinks.Add(Me.btnSaveAndClose)
        Me.rpgActions.ItemLinks.Add(Me.BarButtonFollowing)
        Me.rpgActions.ItemLinks.Add(Me.BarButtonDone)
        Me.rpgActions.ItemLinks.Add(Me.BarButtonClose)
        Me.rpgActions.ItemLinks.Add(Me.btnDelete, True)
        Me.rpgActions.ItemLinks.Add(Me.BarButtonDelete)
        Me.rpgActions.Name = "rpgActions"
        resources.ApplyResources(Me.rpgActions, "rpgActions")
        '
        'rpgOptions
        '
        Me.rpgOptions.AllowTextClipping = False
        Me.rpgOptions.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.[False]
        Me.rpgOptions.ItemLinks.Add(Me.barLabel)
        Me.rpgOptions.ItemLinks.Add(Me.barReminder)
        Me.rpgOptions.Name = "rpgOptions"
        resources.ApplyResources(Me.rpgOptions, "rpgOptions")
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonTaskTrans)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        resources.ApplyResources(Me.RibbonPageGroup2, "RibbonPageGroup2")
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem4)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        resources.ApplyResources(Me.RibbonPageGroup1, "RibbonPageGroup1")
        '
        'riAppointmentResource
        '
        resources.ApplyResources(Me.riAppointmentResource, "riAppointmentResource")
        Me.riAppointmentResource.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("riAppointmentResource.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.riAppointmentResource.Name = "riAppointmentResource"
        '
        'edtStartDate
        '
        resources.ApplyResources(Me.edtStartDate, "edtStartDate")
        Me.edtStartDate.Name = "edtStartDate"
        Me.edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName")
        Me.edtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtStartDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtStartDate.Properties.UseReadOnlyAppearance = False
        '
        'tbLocation
        '
        resources.ApplyResources(Me.tbLocation, "tbLocation")
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName")
        Me.tbLocation.Properties.ReadOnly = True
        '
        'edtStartTime
        '
        resources.ApplyResources(Me.edtStartTime, "edtStartTime")
        Me.edtStartTime.Name = "edtStartTime"
        Me.edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName")
        Me.edtStartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartTime.Properties.MaskSettings.Set("mask", "t")
        Me.edtStartTime.Properties.UseReadOnlyAppearance = False
        '
        'edtEndDate
        '
        resources.ApplyResources(Me.edtEndDate, "edtEndDate")
        Me.edtEndDate.Name = "edtEndDate"
        Me.edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName")
        Me.edtEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtEndDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtEndDate.Properties.UseReadOnlyAppearance = False
        '
        'edtEndTime
        '
        resources.ApplyResources(Me.edtEndTime, "edtEndTime")
        Me.edtEndTime.Name = "edtEndTime"
        Me.edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName")
        Me.edtEndTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndTime.Properties.MaskSettings.Set("mask", "t")
        Me.edtEndTime.Properties.UseReadOnlyAppearance = False
        '
        'lblLocation
        '
        resources.ApplyResources(Me.lblLocation, "lblLocation")
        Me.lblLocation.Name = "lblLocation"
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.panel1.Controls.Add(Me.edtTimeZone)
        Me.panel1.Controls.Add(Me.lblResource)
        Me.panel1.Controls.Add(Me.edtResource)
        Me.panel1.Controls.Add(Me.edtResources)
        Me.panel1.Controls.Add(Me.chkAllDay)
        Me.panel1.Name = "panel1"
        '
        'edtTimeZone
        '
        resources.ApplyResources(Me.edtTimeZone, "edtTimeZone")
        Me.edtTimeZone.MenuManager = Me.ribbonControl1
        Me.edtTimeZone.Name = "edtTimeZone"
        Me.edtTimeZone.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtTimeZone.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'lblResource
        '
        resources.ApplyResources(Me.lblResource, "lblResource")
        Me.lblResource.Name = "lblResource"
        '
        'edtResource
        '
        resources.ApplyResources(Me.edtResource, "edtResource")
        Me.edtResource.Name = "edtResource"
        Me.edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox
        Me.edtResource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtResource.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        'edtResources
        '
        resources.ApplyResources(Me.edtResources, "edtResources")
        Me.edtResources.Name = "edtResources"
        Me.edtResources.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("edtResources.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        '
        '
        '
        Me.edtResources.ResourcesCheckedListBoxControl.CheckOnClick = True
        Me.edtResources.ResourcesCheckedListBoxControl.Dock = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Dock"), System.Windows.Forms.DockStyle)
        Me.edtResources.ResourcesCheckedListBoxControl.Location = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location"), System.Drawing.Point)
        Me.edtResources.ResourcesCheckedListBoxControl.Name = ""
        Me.edtResources.ResourcesCheckedListBoxControl.Size = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Size"), System.Drawing.Size)
        Me.edtResources.ResourcesCheckedListBoxControl.TabIndex = CType(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex"), Integer)
        '
        'chkAllDay
        '
        resources.ApplyResources(Me.chkAllDay, "chkAllDay")
        Me.chkAllDay.Name = "chkAllDay"
        Me.chkAllDay.Properties.AccessibleName = resources.GetString("chkAllDay.Properties.AccessibleName")
        Me.chkAllDay.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton
        Me.chkAllDay.Properties.AutoWidth = True
        Me.chkAllDay.Properties.Caption = resources.GetString("chkAllDay.Properties.Caption")
        '
        'tbSubject
        '
        resources.ApplyResources(Me.tbSubject, "tbSubject")
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName")
        Me.tbSubject.Properties.UseReadOnlyAppearance = False
        '
        'tbProgress
        '
        resources.ApplyResources(Me.tbProgress, "tbProgress")
        Me.tbProgress.Name = "tbProgress"
        Me.tbProgress.Properties.AutoSize = False
        Me.tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tbProgress.Properties.LabelAppearance.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.tbProgress.Properties.LabelAppearance.Options.UseBackColor = True
        resources.ApplyResources(TrackBarLabel6, "TrackBarLabel6")
        resources.ApplyResources(TrackBarLabel7, "TrackBarLabel7")
        TrackBarLabel7.Value = 33
        resources.ApplyResources(TrackBarLabel8, "TrackBarLabel8")
        TrackBarLabel8.Value = 66
        resources.ApplyResources(TrackBarLabel9, "TrackBarLabel9")
        TrackBarLabel9.Value = 90
        resources.ApplyResources(TrackBarLabel10, "TrackBarLabel10")
        TrackBarLabel10.Value = 100
        Me.tbProgress.Properties.Labels.AddRange(New DevExpress.XtraEditors.Repository.TrackBarLabel() {TrackBarLabel6, TrackBarLabel7, TrackBarLabel8, TrackBarLabel9, TrackBarLabel10})
        Me.tbProgress.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.tbProgress.Properties.Maximum = 100
        Me.tbProgress.Properties.ReadOnly = True
        Me.tbProgress.Properties.ShowLabels = True
        Me.tbProgress.Properties.ShowValueToolTip = True
        '
        'lblPercentComplete
        '
        resources.ApplyResources(Me.lblPercentComplete, "lblPercentComplete")
        Me.lblPercentComplete.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentComplete.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblPercentComplete.Appearance.Options.UseBackColor = True
        Me.lblPercentComplete.Appearance.Options.UseForeColor = True
        Me.lblPercentComplete.Name = "lblPercentComplete"
        '
        'lblSubject
        '
        resources.ApplyResources(Me.lblSubject, "lblSubject")
        Me.lblSubject.Name = "lblSubject"
        '
        'panelMain
        '
        resources.ApplyResources(Me.panelMain, "panelMain")
        Me.panelMain.Name = "panelMain"
        '
        'tbDescription
        '
        resources.ApplyResources(Me.tbDescription, "tbDescription")
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName")
        Me.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        Me.tbDescription.Properties.UseReadOnlyAppearance = False
        '
        'panelDescription
        '
        resources.ApplyResources(Me.panelDescription, "panelDescription")
        Me.panelDescription.Name = "panelDescription"
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.tbDescription)
        Me.panel2.Controls.Add(Me.UniqueID)
        Me.panel2.Controls.Add(Me.Referance)
        Me.panel2.Controls.Add(Me.CreationDate)
        Me.panel2.Controls.Add(Me.lblPercentCompleteValue)
        Me.panel2.Controls.Add(Me.tbProgress)
        Me.panel2.Controls.Add(Me.lblPercentComplete)
        Me.panel2.Controls.Add(Me.SearchAssignedTo)
        Me.panel2.Controls.Add(Me.SearchCreationUser)
        Me.panel2.Controls.Add(Me.LabelControl1)
        Me.panel2.Controls.Add(Me.LabelControl3)
        Me.panel2.Controls.Add(Me.lblSubject)
        Me.panel2.Controls.Add(Me.panel1)
        Me.panel2.Controls.Add(Me.tbSubject)
        Me.panel2.Controls.Add(Me.edtEndTime)
        Me.panel2.Controls.Add(Me.lblLocation)
        Me.panel2.Controls.Add(Me.edtEndDate)
        Me.panel2.Controls.Add(Me.LabelControl4)
        Me.panel2.Controls.Add(Me.LabelControl5)
        Me.panel2.Controls.Add(Me.LabelControl2)
        Me.panel2.Controls.Add(Me.edtStartTime)
        Me.panel2.Controls.Add(Me.edtStartDate)
        Me.panel2.Controls.Add(Me.TextTaskStatus)
        Me.panel2.Controls.Add(Me.SearchServiceNo)
        resources.ApplyResources(Me.panel2, "panel2")
        Me.panel2.Name = "panel2"
        '
        'UniqueID
        '
        resources.ApplyResources(Me.UniqueID, "UniqueID")
        Me.UniqueID.MenuManager = Me.ribbonControl1
        Me.UniqueID.Name = "UniqueID"
        Me.UniqueID.Properties.ReadOnly = True
        Me.UniqueID.Properties.UseReadOnlyAppearance = False
        '
        'Referance
        '
        resources.ApplyResources(Me.Referance, "Referance")
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("Referance.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.Referance.Properties.DataSource = Me.ReferancesListBindingSource
        Me.Referance.Properties.DisplayMember = "RefName"
        Me.Referance.Properties.NullText = resources.GetString("Referance.Properties.NullText")
        Me.Referance.Properties.PopupView = Me.GridView3
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.UseReadOnlyAppearance = False
        Me.Referance.Properties.ValueMember = "RefNo"
        '
        'ReferancesListBindingSource
        '
        Me.ReferancesListBindingSource.DataMember = "ReferancesList"
        Me.ReferancesListBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'TrueAccountingDataSet
        '
        Me.TrueAccountingDataSet.DataSetName = "TrueAccountingDataSet"
        Me.TrueAccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID, Me.ColTypeID, Me.ColCurrency})
        Me.GridView3.DetailHeight = 431
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColRefID
        '
        resources.ApplyResources(Me.ColRefID, "ColRefID")
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.MinWidth = 26
        Me.ColRefID.Name = "ColRefID"
        '
        'ColRefNo
        '
        resources.ApplyResources(Me.ColRefNo, "ColRefNo")
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.MinWidth = 26
        Me.ColRefNo.Name = "ColRefNo"
        '
        'ColRefName
        '
        resources.ApplyResources(Me.ColRefName, "ColRefName")
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.MinWidth = 26
        Me.ColRefName.Name = "ColRefName"
        '
        'ColRefTypeName
        '
        resources.ApplyResources(Me.ColRefTypeName, "ColRefTypeName")
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.MinWidth = 26
        Me.ColRefTypeName.Name = "ColRefTypeName"
        '
        'ColRefAccID
        '
        resources.ApplyResources(Me.ColRefAccID, "ColRefAccID")
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.MinWidth = 26
        Me.ColRefAccID.Name = "ColRefAccID"
        '
        'ColTypeID
        '
        resources.ApplyResources(Me.ColTypeID, "ColTypeID")
        Me.ColTypeID.FieldName = "TypeID"
        Me.ColTypeID.MinWidth = 26
        Me.ColTypeID.Name = "ColTypeID"
        '
        'ColCurrency
        '
        resources.ApplyResources(Me.ColCurrency, "ColCurrency")
        Me.ColCurrency.FieldName = "Currency"
        Me.ColCurrency.MinWidth = 26
        Me.ColCurrency.Name = "ColCurrency"
        '
        'CreationDate
        '
        resources.ApplyResources(Me.CreationDate, "CreationDate")
        Me.CreationDate.MenuManager = Me.ribbonControl1
        Me.CreationDate.Name = "CreationDate"
        Me.CreationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("CreationDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.CreationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("CreationDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.CreationDate.Properties.ReadOnly = True
        Me.CreationDate.Properties.UseReadOnlyAppearance = False
        '
        'lblPercentCompleteValue
        '
        resources.ApplyResources(Me.lblPercentCompleteValue, "lblPercentCompleteValue")
        Me.lblPercentCompleteValue.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentCompleteValue.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.lblPercentCompleteValue.Appearance.Options.UseBackColor = True
        Me.lblPercentCompleteValue.Appearance.Options.UseForeColor = True
        Me.lblPercentCompleteValue.Name = "lblPercentCompleteValue"
        '
        'SearchAssignedTo
        '
        resources.ApplyResources(Me.SearchAssignedTo, "SearchAssignedTo")
        Me.SearchAssignedTo.Name = "SearchAssignedTo"
        Me.SearchAssignedTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchAssignedTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchAssignedTo.Properties.DataSource = Me.EmployeesData1BindingSource
        Me.SearchAssignedTo.Properties.DisplayMember = "EmployeeName"
        Me.SearchAssignedTo.Properties.NullText = resources.GetString("SearchAssignedTo.Properties.NullText")
        Me.SearchAssignedTo.Properties.PopupView = Me.GridView1
        Me.SearchAssignedTo.Properties.UseReadOnlyAppearance = False
        Me.SearchAssignedTo.Properties.ValueMember = "EmployeeID"
        '
        'EmployeesData1BindingSource
        '
        Me.EmployeesData1BindingSource.DataMember = "EmployeesData1"
        Me.EmployeesData1BindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.Locale = New System.Globalization.CultureInfo("")
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.DetailHeight = 349
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "EmployeeID"
        Me.GridColumn1.MinWidth = 23
        Me.GridColumn1.Name = "GridColumn1"
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "EmployeeName"
        Me.GridColumn2.MinWidth = 23
        Me.GridColumn2.Name = "GridColumn2"
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        '
        'SearchCreationUser
        '
        resources.ApplyResources(Me.SearchCreationUser, "SearchCreationUser")
        Me.SearchCreationUser.MenuManager = Me.ribbonControl1
        Me.SearchCreationUser.Name = "SearchCreationUser"
        Me.SearchCreationUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchCreationUser.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchCreationUser.Properties.DataSource = Me.EmployeesData1BindingSource
        Me.SearchCreationUser.Properties.DisplayMember = "EmployeeName"
        Me.SearchCreationUser.Properties.NullText = resources.GetString("SearchCreationUser.Properties.NullText")
        Me.SearchCreationUser.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchCreationUser.Properties.ValueMember = "EmployeeID"
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEmployeeID, Me.colEmployeeName})
        Me.SearchLookUpEdit1View.DetailHeight = 349
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 914
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colEmployeeID
        '
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.MinWidth = 23
        Me.colEmployeeID.Name = "colEmployeeID"
        resources.ApplyResources(Me.colEmployeeID, "colEmployeeID")
        '
        'colEmployeeName
        '
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.MinWidth = 23
        Me.colEmployeeName.Name = "colEmployeeName"
        resources.ApplyResources(Me.colEmployeeName, "colEmployeeName")
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'LabelControl4
        '
        resources.ApplyResources(Me.LabelControl4, "LabelControl4")
        Me.LabelControl4.Name = "LabelControl4"
        '
        'LabelControl5
        '
        resources.ApplyResources(Me.LabelControl5, "LabelControl5")
        Me.LabelControl5.Name = "LabelControl5"
        '
        'LabelControl2
        '
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'TextTaskStatus
        '
        resources.ApplyResources(Me.TextTaskStatus, "TextTaskStatus")
        Me.TextTaskStatus.MenuManager = Me.ribbonControl1
        Me.TextTaskStatus.Name = "TextTaskStatus"
        Me.TextTaskStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("TextTaskStatus.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.TextTaskStatus.Properties.DataSource = Me.CRMTaskStatusesBindingSource
        Me.TextTaskStatus.Properties.DisplayMember = "StatusName"
        Me.TextTaskStatus.Properties.NullText = resources.GetString("TextTaskStatus.Properties.NullText")
        Me.TextTaskStatus.Properties.PopupView = Me.GridView2
        Me.TextTaskStatus.Properties.ReadOnly = True
        Me.TextTaskStatus.Properties.UseReadOnlyAppearance = False
        Me.TextTaskStatus.Properties.ValueMember = "StatusID"
        '
        'CRMTaskStatusesBindingSource
        '
        Me.CRMTaskStatusesBindingSource.DataMember = "CRMTaskStatuses"
        Me.CRMTaskStatusesBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colStatusID, Me.colStatusName})
        Me.GridView2.DetailHeight = 349
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colStatusID
        '
        resources.ApplyResources(Me.colStatusID, "colStatusID")
        Me.colStatusID.FieldName = "StatusID"
        Me.colStatusID.MinWidth = 23
        Me.colStatusID.Name = "colStatusID"
        '
        'colStatusName
        '
        resources.ApplyResources(Me.colStatusName, "colStatusName")
        Me.colStatusName.FieldName = "StatusName"
        Me.colStatusName.MinWidth = 23
        Me.colStatusName.Name = "colStatusName"
        '
        'SearchServiceNo
        '
        resources.ApplyResources(Me.SearchServiceNo, "SearchServiceNo")
        Me.SearchServiceNo.MenuManager = Me.ribbonControl1
        Me.SearchServiceNo.Name = "SearchServiceNo"
        Me.SearchServiceNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchServiceNo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchServiceNo.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("SearchServiceNo.Properties.Columns"), resources.GetString("SearchServiceNo.Properties.Columns1"), CType(resources.GetObject("SearchServiceNo.Properties.Columns2"), Integer), CType(resources.GetObject("SearchServiceNo.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("SearchServiceNo.Properties.Columns4"), CType(resources.GetObject("SearchServiceNo.Properties.Columns5"), Boolean), CType(resources.GetObject("SearchServiceNo.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("SearchServiceNo.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("SearchServiceNo.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("SearchServiceNo.Properties.Columns9"), resources.GetString("SearchServiceNo.Properties.Columns10"), CType(resources.GetObject("SearchServiceNo.Properties.Columns11"), Integer), CType(resources.GetObject("SearchServiceNo.Properties.Columns12"), DevExpress.Utils.FormatType), resources.GetString("SearchServiceNo.Properties.Columns13"), CType(resources.GetObject("SearchServiceNo.Properties.Columns14"), Boolean), CType(resources.GetObject("SearchServiceNo.Properties.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("SearchServiceNo.Properties.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("SearchServiceNo.Properties.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.SearchServiceNo.Properties.DisplayMember = "ItemName"
        Me.SearchServiceNo.Properties.NullText = resources.GetString("SearchServiceNo.Properties.NullText")
        Me.SearchServiceNo.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.SearchServiceNo.Properties.ShowFooter = False
        Me.SearchServiceNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.SearchServiceNo.Properties.ValueMember = "ItemNo"
        '
        'EmployeesDataBindingSource
        '
        Me.EmployeesDataBindingSource.DataMember = "EmployeesData"
        Me.EmployeesDataBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'EmployeesData1TableAdapter
        '
        Me.EmployeesData1TableAdapter.ClearBeforeFill = True
        '
        'CRMTaskStatusesTableAdapter
        '
        Me.CRMTaskStatusesTableAdapter.ClearBeforeFill = True
        '
        'ReferancesListTableAdapter
        '
        Me.ReferancesListTableAdapter.ClearBeforeFill = True
        '
        'OutlookAppointmentForm
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.backstageViewControl1)
        Me.Controls.Add(Me.tbLocation)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Name = "OutlookAppointmentForm"
        Me.Ribbon = Me.ribbonControl1
        Me.ShowInTaskbar = False
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backstageViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.backstageViewControl1.ResumeLayout(False)
        Me.bvPrint.ResumeLayout(False)
        CType(Me.riAppointmentLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riAppointmentStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riAppointmentResource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.edtTimeZone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtResources.ResourcesCheckedListBoxControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAllDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchServiceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesDataBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private components As System.ComponentModel.IContainer = Nothing
    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private rpAppointment As DevExpress.XtraBars.Ribbon.RibbonPage
    Private rpgActions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private rpgOptions As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Private WithEvents btnSaveAndClose As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnDelete As DevExpress.XtraBars.BarButtonItem
    Private barLabel As DevExpress.XtraBars.BarEditItem
    Private riAppointmentLabel As RepositoryItemAppointmentLabel
    Private riAppointmentResource As RepositoryItemAppointmentResource
    Private barStatus As DevExpress.XtraBars.BarEditItem
    Private riAppointmentStatus As RepositoryItemAppointmentStatus
    Private barReminder As DevExpress.XtraBars.BarEditItem
    Private riDuration As RepositoryItemDuration
    Private WithEvents btnRecurrence As DevExpress.XtraBars.BarButtonItem
    Protected tbLocation As DevExpress.XtraEditors.TextEdit
    Protected lblLocation As DevExpress.XtraEditors.LabelControl
    Protected panel1 As DevExpress.XtraEditors.PanelControl
    Protected lblResource As DevExpress.XtraEditors.LabelControl
    Protected edtResource As AppointmentResourceEdit
    Protected edtResources As AppointmentResourcesEdit
    Protected chkAllDay As DevExpress.XtraEditors.CheckEdit
    Protected tbProgress As DevExpress.XtraEditors.TrackBarControl
    Protected lblPercentComplete As DevExpress.XtraEditors.LabelControl
    Protected lblSubject As DevExpress.XtraEditors.LabelControl
    Private panelMain As System.Windows.Forms.Panel
    Private panelDescription As System.Windows.Forms.Panel
    Private panel2 As System.Windows.Forms.Panel
    Private backstageViewControl1 As DevExpress.XtraBars.Ribbon.BackstageViewControl
    Private WithEvents bvbSave As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents bvbSaveAs As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents bvbClose As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Private WithEvents btnSave As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnNext As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnPrevious As DevExpress.XtraBars.BarButtonItem
    Private WithEvents btnTimeZones As DevExpress.XtraBars.BarButtonItem
    Private edtTimeZone As TimeZoneEdit
    Private bvPrint As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Private bvtPrint As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Private WithEvents appointmentBackstageControl As DevExpress.XtraScheduler.Design.AppointmentBackstageControl
    Friend WithEvents SearchCreationUser As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesDataBindingSource As BindingSource
    Friend WithEvents EmployeesData1BindingSource As BindingSource
    Friend WithEvents EmployeesData1TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter
    Protected WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents lblPercentCompleteValue As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SearchAssignedTo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextTaskStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TrueAccountingDataSet As AccountingDataSet
    Friend WithEvents CRMTaskStatusesBindingSource As BindingSource
    Friend WithEvents CRMTaskStatusesTableAdapter As AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter
    Friend WithEvents colStatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CreationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ReferancesListBindingSource As BindingSource
    Friend WithEvents ReferancesListTableAdapter As AccountingDataSetTableAdapters.ReferancesListTableAdapter
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents UniqueID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents edtStartDate As DevExpress.XtraEditors.DateEdit
    Private WithEvents edtStartTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents edtEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents edtEndTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonDone As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonFollowing As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tbSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ButtonApplyLable As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonTaskTrans As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarTaskStatus As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarButtonDelete As DevExpress.XtraBars.BarButtonItem
    Protected WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SearchServiceNo As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class