<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InsuranceDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InsuranceDoc))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.RelatedJournal = New DevExpress.XtraEditors.TextEdit()
        Me.VoucherNo = New DevExpress.XtraEditors.TextEdit()
        Me.TaskIDText = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.HyperlinkLabelJournalNo = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.HyperlinkLabelVoucherNo = New DevExpress.XtraEditors.HyperlinkLabelControl()
        Me.CheckAutoIssueDocument = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckCreateAppointment = New DevExpress.XtraEditors.CheckEdit()
        Me.ButtonIssueJournal = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonIssueVoucher = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAddAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelFormName = New DevExpress.XtraEditors.LabelControl()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LookDocStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.Amount = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TextInsuranceAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TextInsuranceFullAmount = New DevExpress.XtraEditors.TextEdit()
        Me.InsuranceService = New DevExpress.XtraEditors.TextEdit()
        Me.ManualDocNo2 = New DevExpress.XtraEditors.TextEdit()
        Me.TextInsuranceExpeneseAmount = New DevExpress.XtraEditors.TextEdit()
        Me.InsuranceExpenseMethod = New DevExpress.XtraEditors.RadioGroup()
        Me.TextInsuranceExpensePerc = New DevExpress.XtraEditors.TextEdit()
        Me.InsurancePlace = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextInsuranceExpense = New DevExpress.XtraEditors.TextEdit()
        Me.ManualDocNo1 = New DevExpress.XtraEditors.TextEdit()
        Me.TextDocNewOld = New DevExpress.XtraEditors.TextEdit()
        Me.DocNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.DocCode = New DevExpress.XtraEditors.TextEdit()
        Me.Currency = New DevExpress.XtraEditors.LookUpEdit()
        Me.ExchangeRate = New DevExpress.XtraEditors.TextEdit()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPageCars = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TextEngine = New DevExpress.XtraEditors.TextEdit()
        Me.TextYearCar = New DevExpress.XtraEditors.TextEdit()
        Me.TextCarModel = New DevExpress.XtraEditors.TextEdit()
        Me.TextCarType = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl26 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCarType = New DevExpress.XtraEditors.LabelControl()
        Me.CarCoverType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CarType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.CARNO = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TabNavigationPageAccident = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.TabNavigationPageFire = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.TabNavigationPageSocial = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.TabNavigationPageEngineering = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.ManualDocNo = New DevExpress.XtraEditors.TextEdit()
        Me.InsuranceDocType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocID = New DevExpress.XtraEditors.TextEdit()
        Me.InsuranceCompanyName = New DevExpress.XtraEditors.TextEdit()
        Me.InsuranceCompany = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DocDate = New DevExpress.XtraEditors.DateEdit()
        Me.ReferanceID = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BeneficiaryName = New DevExpress.XtraEditors.TextEdit()
        Me.DateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.ReferanceName = New DevExpress.XtraEditors.TextEdit()
        Me.DateTo = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutInsuranceExpAmount = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutInsurancePercentagePercentage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TaskID = New DevExpress.XtraEditors.TextEdit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.RelatedJournal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VoucherNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAutoIssueDocument.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckCreateAppointment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookDocStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextInsuranceAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInsuranceFullAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsuranceService.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManualDocNo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInsuranceExpeneseAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsuranceExpenseMethod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInsuranceExpensePerc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsurancePlace.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInsuranceExpense.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManualDocNo1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocNewOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangeRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPageCars.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.TextEngine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextYearCar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCarModel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCarType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CarCoverType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CarType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CARNO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ManualDocNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsuranceDocType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsuranceCompanyName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InsuranceCompany.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferanceID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeneficiaryName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferanceName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutInsuranceExpAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutInsurancePercentagePercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaskID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DockPanel1.ID = New System.Guid("d18dcc9b-feb0-489f-b070-efff0ec2ca0a")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowAutoHideButton = False
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(316, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(316, 707)
        Me.DockPanel1.Text = "DockPanel1"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.TaskID)
        Me.DockPanel1_Container.Controls.Add(Me.RelatedJournal)
        Me.DockPanel1_Container.Controls.Add(Me.VoucherNo)
        Me.DockPanel1_Container.Controls.Add(Me.TaskIDText)
        Me.DockPanel1_Container.Controls.Add(Me.HyperlinkLabelJournalNo)
        Me.DockPanel1_Container.Controls.Add(Me.HyperlinkLabelVoucherNo)
        Me.DockPanel1_Container.Controls.Add(Me.CheckAutoIssueDocument)
        Me.DockPanel1_Container.Controls.Add(Me.CheckCreateAppointment)
        Me.DockPanel1_Container.Controls.Add(Me.ButtonIssueJournal)
        Me.DockPanel1_Container.Controls.Add(Me.ButtonIssueVoucher)
        Me.DockPanel1_Container.Controls.Add(Me.LabelControl8)
        Me.DockPanel1_Container.Controls.Add(Me.SimpleButton5)
        Me.DockPanel1_Container.Controls.Add(Me.ButtonAddAttachment)
        Me.DockPanel1_Container.Controls.Add(Me.ButtonDelete)
        Me.DockPanel1_Container.Controls.Add(Me.ButtonSave)
        Me.DockPanel1_Container.Controls.Add(Me.LabelFormName)
        Me.DockPanel1_Container.Controls.Add(Me.PictureEdit1)
        Me.DockPanel1_Container.Controls.Add(Me.LookDocStatus)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 26)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(4)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(309, 678)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'RelatedJournal
        '
        Me.RelatedJournal.Location = New System.Drawing.Point(6, 353)
        Me.RelatedJournal.Margin = New System.Windows.Forms.Padding(4)
        Me.RelatedJournal.Name = "RelatedJournal"
        Me.RelatedJournal.Size = New System.Drawing.Size(27, 24)
        Me.RelatedJournal.TabIndex = 40
        Me.RelatedJournal.Visible = False
        '
        'VoucherNo
        '
        Me.VoucherNo.Location = New System.Drawing.Point(6, 307)
        Me.VoucherNo.Margin = New System.Windows.Forms.Padding(4)
        Me.VoucherNo.Name = "VoucherNo"
        Me.VoucherNo.Size = New System.Drawing.Size(27, 24)
        Me.VoucherNo.TabIndex = 39
        Me.VoucherNo.Visible = False
        '
        'TaskIDText
        '
        Me.TaskIDText.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TaskIDText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.TaskIDText.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.TaskIDText.ImageOptions.Image = CType(resources.GetObject("TaskID.ImageOptions.Image"), System.Drawing.Image)
        Me.TaskIDText.Location = New System.Drawing.Point(70, 356)
        Me.TaskIDText.Margin = New System.Windows.Forms.Padding(4)
        Me.TaskIDText.Name = "TaskIDText"
        Me.TaskIDText.Size = New System.Drawing.Size(236, 26)
        Me.TaskIDText.TabIndex = 38
        Me.TaskIDText.Text = "رقم التذكير رقم التذكير"
        '
        'HyperlinkLabelJournalNo
        '
        Me.HyperlinkLabelJournalNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HyperlinkLabelJournalNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.HyperlinkLabelJournalNo.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.HyperlinkLabelJournalNo.ImageOptions.Image = CType(resources.GetObject("HyperlinkLabelJournalNo.ImageOptions.Image"), System.Drawing.Image)
        Me.HyperlinkLabelJournalNo.Location = New System.Drawing.Point(59, 292)
        Me.HyperlinkLabelJournalNo.Margin = New System.Windows.Forms.Padding(4)
        Me.HyperlinkLabelJournalNo.Name = "HyperlinkLabelJournalNo"
        Me.HyperlinkLabelJournalNo.Size = New System.Drawing.Size(247, 26)
        Me.HyperlinkLabelJournalNo.TabIndex = 38
        Me.HyperlinkLabelJournalNo.Text = "صدرت صدرت قيد رقم : "
        '
        'HyperlinkLabelVoucherNo
        '
        Me.HyperlinkLabelVoucherNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HyperlinkLabelVoucherNo.Appearance.Options.UseTextOptions = True
        Me.HyperlinkLabelVoucherNo.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.HyperlinkLabelVoucherNo.AutoEllipsis = True
        Me.HyperlinkLabelVoucherNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.HyperlinkLabelVoucherNo.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        Me.HyperlinkLabelVoucherNo.ImageOptions.Image = CType(resources.GetObject("HyperlinkLabelVoucherNo.ImageOptions.Image"), System.Drawing.Image)
        Me.HyperlinkLabelVoucherNo.Location = New System.Drawing.Point(68, 324)
        Me.HyperlinkLabelVoucherNo.Margin = New System.Windows.Forms.Padding(4)
        Me.HyperlinkLabelVoucherNo.Name = "HyperlinkLabelVoucherNo"
        Me.HyperlinkLabelVoucherNo.Size = New System.Drawing.Size(238, 26)
        Me.HyperlinkLabelVoucherNo.TabIndex = 38
        Me.HyperlinkLabelVoucherNo.Text = "صدرت صدرت فاتورة رقم : "
        Me.HyperlinkLabelVoucherNo.UseMnemonic = False
        '
        'CheckAutoIssueDocument
        '
        Me.CheckAutoIssueDocument.EditValue = True
        Me.CheckAutoIssueDocument.Location = New System.Drawing.Point(124, 400)
        Me.CheckAutoIssueDocument.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckAutoIssueDocument.Name = "CheckAutoIssueDocument"
        Me.CheckAutoIssueDocument.Properties.Caption = "إصدار السندات المرفقة تلقائيا"
        Me.CheckAutoIssueDocument.Size = New System.Drawing.Size(182, 21)
        Me.CheckAutoIssueDocument.TabIndex = 34
        '
        'CheckCreateAppointment
        '
        Me.CheckCreateAppointment.EditValue = True
        Me.CheckCreateAppointment.Location = New System.Drawing.Point(124, 433)
        Me.CheckCreateAppointment.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckCreateAppointment.Name = "CheckCreateAppointment"
        Me.CheckCreateAppointment.Properties.Caption = "اضافة موعد على الأجندة"
        Me.CheckCreateAppointment.Size = New System.Drawing.Size(182, 21)
        Me.CheckCreateAppointment.TabIndex = 34
        '
        'ButtonIssueJournal
        '
        Me.ButtonIssueJournal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonIssueJournal.ImageOptions.Image = CType(resources.GetObject("ButtonIssueJournal.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonIssueJournal.Location = New System.Drawing.Point(24, 635)
        Me.ButtonIssueJournal.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonIssueJournal.Name = "ButtonIssueJournal"
        Me.ButtonIssueJournal.Size = New System.Drawing.Size(132, 30)
        Me.ButtonIssueJournal.TabIndex = 36
        Me.ButtonIssueJournal.Text = "اصدار العمولة"
        Me.ButtonIssueJournal.Visible = False
        '
        'ButtonIssueVoucher
        '
        Me.ButtonIssueVoucher.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonIssueVoucher.ImageOptions.Image = CType(resources.GetObject("ButtonIssueVoucher.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonIssueVoucher.Location = New System.Drawing.Point(163, 635)
        Me.ButtonIssueVoucher.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonIssueVoucher.Name = "ButtonIssueVoucher"
        Me.ButtonIssueVoucher.Size = New System.Drawing.Size(132, 30)
        Me.ButtonIssueVoucher.TabIndex = 36
        Me.ButtonIssueVoucher.Text = "اصدار فاتورة"
        Me.ButtonIssueVoucher.Visible = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl8.Location = New System.Drawing.Point(238, 251)
        Me.LabelControl8.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(58, 17)
        Me.LabelControl8.TabIndex = 30
        Me.LabelControl8.Text = "حالة السند:"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.Location = New System.Drawing.Point(24, 486)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(132, 30)
        Me.SimpleButton5.TabIndex = 36
        Me.SimpleButton5.Text = "عرض الوثائق"
        '
        'ButtonAddAttachment
        '
        Me.ButtonAddAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAddAttachment.ImageOptions.Image = CType(resources.GetObject("ButtonAddAttachment.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonAddAttachment.Location = New System.Drawing.Point(163, 486)
        Me.ButtonAddAttachment.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonAddAttachment.Name = "ButtonAddAttachment"
        Me.ButtonAddAttachment.Size = New System.Drawing.Size(132, 30)
        Me.ButtonAddAttachment.TabIndex = 36
        Me.ButtonAddAttachment.Text = "ارفاق وثيقة"
        '
        'ButtonDelete
        '
        Me.ButtonDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDelete.ImageOptions.Image = CType(resources.GetObject("ButtonDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonDelete.Location = New System.Drawing.Point(24, 590)
        Me.ButtonDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(132, 30)
        Me.ButtonDelete.TabIndex = 35
        Me.ButtonDelete.Text = "حذف السند"
        '
        'ButtonSave
        '
        Me.ButtonSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSave.ImageOptions.Image = CType(resources.GetObject("ButtonSave.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonSave.Location = New System.Drawing.Point(24, 542)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(271, 30)
        Me.ButtonSave.TabIndex = 35
        Me.ButtonSave.Text = "حفظ السند"
        '
        'LabelFormName
        '
        Me.LabelFormName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelFormName.Appearance.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LabelFormName.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelFormName.Appearance.Options.UseFont = True
        Me.LabelFormName.Appearance.Options.UseForeColor = True
        Me.LabelFormName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelFormName.Location = New System.Drawing.Point(85, 5)
        Me.LabelFormName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LabelFormName.Name = "LabelFormName"
        Me.LabelFormName.Size = New System.Drawing.Size(122, 41)
        Me.LabelFormName.TabIndex = 26
        Me.LabelFormName.Text = "وثيقة تأمين"
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = Global.TrueTime.My.Resources.Resources.Insurance
        Me.PictureEdit1.Location = New System.Drawing.Point(55, 53)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(196, 184)
        Me.PictureEdit1.TabIndex = 0
        '
        'LookDocStatus
        '
        Me.LookDocStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LookDocStatus.Location = New System.Drawing.Point(18, 250)
        Me.LookDocStatus.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LookDocStatus.Name = "LookDocStatus"
        Me.LookDocStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookDocStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DocStatus", "Name5", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DocName", "حالة السند")})
        Me.LookDocStatus.Properties.DisplayMember = "DocName"
        Me.LookDocStatus.Properties.NullText = ""
        Me.LookDocStatus.Properties.ReadOnly = True
        Me.LookDocStatus.Properties.ValueMember = "DocStatus"
        Me.LookDocStatus.Size = New System.Drawing.Size(210, 24)
        Me.LookDocStatus.TabIndex = 23
        '
        'Amount
        '
        Me.Amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Amount.Location = New System.Drawing.Point(611, 349)
        Me.Amount.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Amount.Name = "Amount"
        Me.Amount.Properties.ReadOnly = True
        Me.Amount.Size = New System.Drawing.Size(165, 24)
        Me.Amount.StyleController = Me.LayoutControl1
        Me.Amount.TabIndex = 11
        Me.Amount.Visible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextInsuranceAmount)
        Me.LayoutControl1.Controls.Add(Me.TextInsuranceFullAmount)
        Me.LayoutControl1.Controls.Add(Me.InsuranceService)
        Me.LayoutControl1.Controls.Add(Me.ManualDocNo2)
        Me.LayoutControl1.Controls.Add(Me.TextInsuranceExpeneseAmount)
        Me.LayoutControl1.Controls.Add(Me.InsuranceExpenseMethod)
        Me.LayoutControl1.Controls.Add(Me.TextInsuranceExpensePerc)
        Me.LayoutControl1.Controls.Add(Me.InsurancePlace)
        Me.LayoutControl1.Controls.Add(Me.TextInsuranceExpense)
        Me.LayoutControl1.Controls.Add(Me.ManualDocNo1)
        Me.LayoutControl1.Controls.Add(Me.TextDocNewOld)
        Me.LayoutControl1.Controls.Add(Me.DocNotes)
        Me.LayoutControl1.Controls.Add(Me.DocCode)
        Me.LayoutControl1.Controls.Add(Me.Currency)
        Me.LayoutControl1.Controls.Add(Me.ExchangeRate)
        Me.LayoutControl1.Controls.Add(Me.Amount)
        Me.LayoutControl1.Controls.Add(Me.TabPane1)
        Me.LayoutControl1.Controls.Add(Me.ManualDocNo)
        Me.LayoutControl1.Controls.Add(Me.InsuranceDocType)
        Me.LayoutControl1.Controls.Add(Me.DocID)
        Me.LayoutControl1.Controls.Add(Me.InsuranceCompanyName)
        Me.LayoutControl1.Controls.Add(Me.InsuranceCompany)
        Me.LayoutControl1.Controls.Add(Me.DocDate)
        Me.LayoutControl1.Controls.Add(Me.ReferanceID)
        Me.LayoutControl1.Controls.Add(Me.BeneficiaryName)
        Me.LayoutControl1.Controls.Add(Me.DateFrom)
        Me.LayoutControl1.Controls.Add(Me.ReferanceName)
        Me.LayoutControl1.Controls.Add(Me.DateTo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem16, Me.LayoutControlItem18, Me.LayoutControlItem1, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem20})
        Me.LayoutControl1.Location = New System.Drawing.Point(316, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(836, 707)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TextInsuranceAmount
        '
        Me.TextInsuranceAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextInsuranceAmount.Location = New System.Drawing.Point(24, 345)
        Me.TextInsuranceAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.TextInsuranceAmount.Name = "TextInsuranceAmount"
        Me.TextInsuranceAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextInsuranceAmount.Properties.MaskSettings.Set("mask", "n")
        Me.TextInsuranceAmount.Properties.UseMaskAsDisplayFormat = True
        Me.TextInsuranceAmount.Size = New System.Drawing.Size(284, 24)
        Me.TextInsuranceAmount.StyleController = Me.LayoutControl1
        Me.TextInsuranceAmount.TabIndex = 33
        '
        'TextInsuranceFullAmount
        '
        Me.TextInsuranceFullAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextInsuranceFullAmount.Location = New System.Drawing.Point(420, 345)
        Me.TextInsuranceFullAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.TextInsuranceFullAmount.Name = "TextInsuranceFullAmount"
        Me.TextInsuranceFullAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextInsuranceFullAmount.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.TextInsuranceFullAmount.Properties.MaskSettings.Set("mask", "n")
        Me.TextInsuranceFullAmount.Properties.UseMaskAsDisplayFormat = True
        Me.TextInsuranceFullAmount.Size = New System.Drawing.Size(284, 24)
        Me.TextInsuranceFullAmount.StyleController = Me.LayoutControl1
        Me.TextInsuranceFullAmount.TabIndex = 33
        '
        'InsuranceService
        '
        Me.InsuranceService.Location = New System.Drawing.Point(368, 317)
        Me.InsuranceService.Name = "InsuranceService"
        Me.InsuranceService.Size = New System.Drawing.Size(50, 24)
        Me.InsuranceService.StyleController = Me.LayoutControl1
        Me.InsuranceService.TabIndex = 46
        '
        'ManualDocNo2
        '
        Me.ManualDocNo2.Location = New System.Drawing.Point(455, 45)
        Me.ManualDocNo2.Name = "ManualDocNo2"
        Me.ManualDocNo2.Size = New System.Drawing.Size(68, 24)
        Me.ManualDocNo2.StyleController = Me.LayoutControl1
        Me.ManualDocNo2.TabIndex = 45
        '
        'TextInsuranceExpeneseAmount
        '
        Me.TextInsuranceExpeneseAmount.Location = New System.Drawing.Point(364, 251)
        Me.TextInsuranceExpeneseAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.TextInsuranceExpeneseAmount.Name = "TextInsuranceExpeneseAmount"
        Me.TextInsuranceExpeneseAmount.Size = New System.Drawing.Size(53, 24)
        Me.TextInsuranceExpeneseAmount.StyleController = Me.LayoutControl1
        Me.TextInsuranceExpeneseAmount.TabIndex = 44
        '
        'InsuranceExpenseMethod
        '
        Me.InsuranceExpenseMethod.EditValue = "1"
        Me.InsuranceExpenseMethod.Location = New System.Drawing.Point(529, 251)
        Me.InsuranceExpenseMethod.Margin = New System.Windows.Forms.Padding(4)
        Me.InsuranceExpenseMethod.Name = "InsuranceExpenseMethod"
        Me.InsuranceExpenseMethod.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("1", "مبلغ"), New DevExpress.XtraEditors.Controls.RadioGroupItem("2", "نسبة")})
        Me.InsuranceExpenseMethod.Size = New System.Drawing.Size(175, 34)
        Me.InsuranceExpenseMethod.StyleController = Me.LayoutControl1
        Me.InsuranceExpenseMethod.TabIndex = 43
        '
        'TextInsuranceExpensePerc
        '
        Me.TextInsuranceExpensePerc.Location = New System.Drawing.Point(199, 251)
        Me.TextInsuranceExpensePerc.Margin = New System.Windows.Forms.Padding(4)
        Me.TextInsuranceExpensePerc.Name = "TextInsuranceExpensePerc"
        Me.TextInsuranceExpensePerc.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextInsuranceExpensePerc.Properties.MaskSettings.Set("mask", "P")
        Me.TextInsuranceExpensePerc.Properties.UseMaskAsDisplayFormat = True
        Me.TextInsuranceExpensePerc.Size = New System.Drawing.Size(53, 24)
        Me.TextInsuranceExpensePerc.StyleController = Me.LayoutControl1
        Me.TextInsuranceExpensePerc.TabIndex = 42
        '
        'InsurancePlace
        '
        Me.InsurancePlace.Location = New System.Drawing.Point(24, 317)
        Me.InsurancePlace.Margin = New System.Windows.Forms.Padding(4)
        Me.InsurancePlace.Name = "InsurancePlace"
        Me.InsurancePlace.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsurancePlace.Properties.Items.AddRange(New Object() {"ضفة", "قدس", "مشترك"})
        Me.InsurancePlace.Size = New System.Drawing.Size(151, 24)
        Me.InsurancePlace.StyleController = Me.LayoutControl1
        Me.InsurancePlace.TabIndex = 41
        '
        'TextInsuranceExpense
        '
        Me.TextInsuranceExpense.Location = New System.Drawing.Point(24, 251)
        Me.TextInsuranceExpense.Margin = New System.Windows.Forms.Padding(4)
        Me.TextInsuranceExpense.Name = "TextInsuranceExpense"
        Me.TextInsuranceExpense.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextInsuranceExpense.Properties.MaskSettings.Set("mask", "n")
        Me.TextInsuranceExpense.Properties.ReadOnly = True
        Me.TextInsuranceExpense.Size = New System.Drawing.Size(83, 24)
        Me.TextInsuranceExpense.StyleController = Me.LayoutControl1
        Me.TextInsuranceExpense.TabIndex = 40
        '
        'ManualDocNo1
        '
        Me.ManualDocNo1.Location = New System.Drawing.Point(539, 45)
        Me.ManualDocNo1.Margin = New System.Windows.Forms.Padding(4)
        Me.ManualDocNo1.Name = "ManualDocNo1"
        Me.ManualDocNo1.Properties.NullText = "21-1-55-01"
        Me.ManualDocNo1.Size = New System.Drawing.Size(125, 24)
        Me.ManualDocNo1.StyleController = Me.LayoutControl1
        Me.ManualDocNo1.TabIndex = 39
        '
        'TextDocNewOld
        '
        Me.TextDocNewOld.Location = New System.Drawing.Point(14, 16)
        Me.TextDocNewOld.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDocNewOld.Name = "TextDocNewOld"
        Me.TextDocNewOld.Size = New System.Drawing.Size(332, 24)
        Me.TextDocNewOld.StyleController = Me.LayoutControl1
        Me.TextDocNewOld.TabIndex = 33
        Me.TextDocNewOld.Visible = False
        '
        'DocNotes
        '
        Me.DocNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DocNotes.Location = New System.Drawing.Point(24, 373)
        Me.DocNotes.Margin = New System.Windows.Forms.Padding(4)
        Me.DocNotes.Name = "DocNotes"
        Me.DocNotes.Size = New System.Drawing.Size(680, 36)
        Me.DocNotes.StyleController = Me.LayoutControl1
        Me.DocNotes.TabIndex = 34
        '
        'DocCode
        '
        Me.DocCode.Location = New System.Drawing.Point(475, 16)
        Me.DocCode.Margin = New System.Windows.Forms.Padding(4)
        Me.DocCode.Name = "DocCode"
        Me.DocCode.Size = New System.Drawing.Size(334, 24)
        Me.DocCode.StyleController = Me.LayoutControl1
        Me.DocCode.TabIndex = 37
        Me.DocCode.Visible = False
        '
        'Currency
        '
        Me.Currency.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Currency.Location = New System.Drawing.Point(12, 349)
        Me.Currency.Margin = New System.Windows.Forms.Padding(4)
        Me.Currency.Name = "Currency"
        Me.Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Currency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrID", "ID", 23, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "العملة", 23, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.Currency.Properties.DisplayMember = "Code"
        Me.Currency.Properties.NullText = ""
        Me.Currency.Properties.ReadOnly = True
        Me.Currency.Properties.ValueMember = "CurrID"
        Me.Currency.Size = New System.Drawing.Size(764, 24)
        Me.Currency.StyleController = Me.LayoutControl1
        Me.Currency.TabIndex = 21
        Me.Currency.Visible = False
        '
        'ExchangeRate
        '
        Me.ExchangeRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExchangeRate.Location = New System.Drawing.Point(312, 349)
        Me.ExchangeRate.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ExchangeRate.Name = "ExchangeRate"
        Me.ExchangeRate.Properties.ReadOnly = True
        Me.ExchangeRate.Size = New System.Drawing.Size(464, 24)
        Me.ExchangeRate.StyleController = Me.LayoutControl1
        Me.ExchangeRate.TabIndex = 24
        Me.ExchangeRate.Visible = False
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPageCars)
        Me.TabPane1.Controls.Add(Me.TabNavigationPageAccident)
        Me.TabPane1.Controls.Add(Me.TabNavigationPageFire)
        Me.TabPane1.Controls.Add(Me.TabNavigationPageSocial)
        Me.TabPane1.Controls.Add(Me.TabNavigationPageEngineering)
        Me.TabPane1.Location = New System.Drawing.Point(12, 425)
        Me.TabPane1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPageCars, Me.TabNavigationPageAccident, Me.TabNavigationPageFire, Me.TabNavigationPageSocial, Me.TabNavigationPageEngineering})
        Me.TabPane1.RegularSize = New System.Drawing.Size(812, 242)
        Me.TabPane1.SelectedPage = Me.TabNavigationPageCars
        Me.TabPane1.Size = New System.Drawing.Size(812, 242)
        Me.TabPane1.TabIndex = 31
        Me.TabPane1.Text = "TabPane1"
        '
        'TabNavigationPageCars
        '
        Me.TabNavigationPageCars.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabNavigationPageCars.Caption = "مركبات"
        Me.TabNavigationPageCars.Controls.Add(Me.GroupControl1)
        Me.TabNavigationPageCars.Controls.Add(Me.CarCoverType)
        Me.TabNavigationPageCars.Controls.Add(Me.CarType)
        Me.TabNavigationPageCars.Controls.Add(Me.LabelControl9)
        Me.TabNavigationPageCars.Controls.Add(Me.CARNO)
        Me.TabNavigationPageCars.Controls.Add(Me.LabelControl7)
        Me.TabNavigationPageCars.Controls.Add(Me.LabelControl1)
        Me.TabNavigationPageCars.ImageOptions.SvgImage = CType(resources.GetObject("TabNavigationPageCars.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.TabNavigationPageCars.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageCars.Margin = New System.Windows.Forms.Padding(4)
        Me.TabNavigationPageCars.Name = "TabNavigationPageCars"
        Me.TabNavigationPageCars.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageCars.Size = New System.Drawing.Size(812, 183)
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Controls.Add(Me.TextEngine)
        Me.GroupControl1.Controls.Add(Me.TextYearCar)
        Me.GroupControl1.Controls.Add(Me.TextCarModel)
        Me.GroupControl1.Controls.Add(Me.TextCarType)
        Me.GroupControl1.Controls.Add(Me.LabelControl27)
        Me.GroupControl1.Controls.Add(Me.LabelControl25)
        Me.GroupControl1.Controls.Add(Me.LabelControl26)
        Me.GroupControl1.Controls.Add(Me.LabelCarType)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.GroupControl1.Location = New System.Drawing.Point(24, 20)
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(345, 169)
        Me.GroupControl1.TabIndex = 35
        Me.GroupControl1.Text = "بيانات المركبة"
        '
        'TextEngine
        '
        Me.TextEngine.Location = New System.Drawing.Point(24, 122)
        Me.TextEngine.Margin = New System.Windows.Forms.Padding(4)
        Me.TextEngine.Name = "TextEngine"
        Me.TextEngine.Properties.ReadOnly = True
        Me.TextEngine.Size = New System.Drawing.Size(194, 24)
        Me.TextEngine.TabIndex = 31
        '
        'TextYearCar
        '
        Me.TextYearCar.Location = New System.Drawing.Point(24, 90)
        Me.TextYearCar.Margin = New System.Windows.Forms.Padding(4)
        Me.TextYearCar.Name = "TextYearCar"
        Me.TextYearCar.Properties.ReadOnly = True
        Me.TextYearCar.Size = New System.Drawing.Size(194, 24)
        Me.TextYearCar.TabIndex = 31
        '
        'TextCarModel
        '
        Me.TextCarModel.Location = New System.Drawing.Point(24, 58)
        Me.TextCarModel.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCarModel.Name = "TextCarModel"
        Me.TextCarModel.Properties.ReadOnly = True
        Me.TextCarModel.Size = New System.Drawing.Size(194, 24)
        Me.TextCarModel.TabIndex = 31
        '
        'TextCarType
        '
        Me.TextCarType.Location = New System.Drawing.Point(24, 26)
        Me.TextCarType.Margin = New System.Windows.Forms.Padding(4)
        Me.TextCarType.Name = "TextCarType"
        Me.TextCarType.Properties.ReadOnly = True
        Me.TextCarType.Size = New System.Drawing.Size(194, 24)
        Me.TextCarType.TabIndex = 31
        '
        'LabelControl27
        '
        Me.LabelControl27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl27.Location = New System.Drawing.Point(246, 125)
        Me.LabelControl27.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(71, 17)
        Me.LabelControl27.TabIndex = 30
        Me.LabelControl27.Text = "سعة المحرك:"
        '
        'LabelControl25
        '
        Me.LabelControl25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl25.Location = New System.Drawing.Point(285, 93)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(32, 17)
        Me.LabelControl25.TabIndex = 30
        Me.LabelControl25.Text = "السنة:"
        '
        'LabelControl26
        '
        Me.LabelControl26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl26.Location = New System.Drawing.Point(279, 61)
        Me.LabelControl26.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl26.Name = "LabelControl26"
        Me.LabelControl26.Size = New System.Drawing.Size(38, 17)
        Me.LabelControl26.TabIndex = 30
        Me.LabelControl26.Text = "موديل:"
        '
        'LabelCarType
        '
        Me.LabelCarType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelCarType.Location = New System.Drawing.Point(288, 33)
        Me.LabelCarType.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelCarType.Name = "LabelCarType"
        Me.LabelCarType.Size = New System.Drawing.Size(29, 17)
        Me.LabelCarType.TabIndex = 30
        Me.LabelCarType.Text = "النوع:"
        '
        'CarCoverType
        '
        Me.CarCoverType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CarCoverType.Location = New System.Drawing.Point(404, 97)
        Me.CarCoverType.Margin = New System.Windows.Forms.Padding(4)
        Me.CarCoverType.Name = "CarCoverType"
        Me.CarCoverType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CarCoverType.Properties.DisplayMember = "CoverType"
        Me.CarCoverType.Properties.NullText = ""
        Me.CarCoverType.Properties.PopupView = Me.GridView2
        Me.CarCoverType.Properties.ShowAddNewButton = True
        Me.CarCoverType.Properties.ValueMember = "ID"
        Me.CarCoverType.Size = New System.Drawing.Size(278, 24)
        Me.CarCoverType.TabIndex = 32
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn15})
        Me.GridView2.DetailHeight = 458
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "ID"
        Me.GridColumn14.FieldName = "ID"
        Me.GridColumn14.MinWidth = 23
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Width = 87
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "نوع التغطية"
        Me.GridColumn15.FieldName = "CoverType"
        Me.GridColumn15.MinWidth = 23
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 0
        Me.GridColumn15.Width = 87
        '
        'CarType
        '
        Me.CarType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CarType.Location = New System.Drawing.Point(404, 63)
        Me.CarType.Margin = New System.Windows.Forms.Padding(4)
        Me.CarType.Name = "CarType"
        Me.CarType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CarType.Properties.DisplayMember = "CarType"
        Me.CarType.Properties.NullText = ""
        Me.CarType.Properties.PopupView = Me.SearchLookUpEdit2View
        Me.CarType.Properties.ShowAddNewButton = True
        Me.CarType.Properties.ValueMember = "ID"
        Me.CarType.Size = New System.Drawing.Size(278, 24)
        Me.CarType.TabIndex = 32
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13})
        Me.SearchLookUpEdit2View.DetailHeight = 458
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID"
        Me.GridColumn12.FieldName = "ID"
        Me.GridColumn12.MinWidth = 23
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Width = 87
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "نوع المركبة"
        Me.GridColumn13.FieldName = "CarType"
        Me.GridColumn13.MinWidth = 23
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 87
        '
        'LabelControl9
        '
        Me.LabelControl9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl9.Location = New System.Drawing.Point(719, 100)
        Me.LabelControl9.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(67, 17)
        Me.LabelControl9.TabIndex = 30
        Me.LabelControl9.Text = "نوع التغطية:"
        '
        'CARNO
        '
        Me.CARNO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CARNO.Location = New System.Drawing.Point(404, 29)
        Me.CARNO.Margin = New System.Windows.Forms.Padding(4)
        Me.CARNO.Name = "CARNO"
        Me.CARNO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CARNO.Properties.DisplayMember = "CARNO"
        Me.CARNO.Properties.NullText = ""
        Me.CARNO.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.CARNO.Properties.ShowAddNewButton = True
        Me.CARNO.Properties.ValueMember = "CarID"
        Me.CARNO.Size = New System.Drawing.Size(278, 24)
        Me.CARNO.TabIndex = 31
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11})
        Me.SearchLookUpEdit1View.DetailHeight = 458
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID"
        Me.GridColumn10.FieldName = "CarID"
        Me.GridColumn10.MinWidth = 23
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Width = 87
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "رقم المركبة"
        Me.GridColumn11.FieldName = "CARNO"
        Me.GridColumn11.MinWidth = 23
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 87
        '
        'LabelControl7
        '
        Me.LabelControl7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl7.Location = New System.Drawing.Point(696, 66)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(90, 17)
        Me.LabelControl7.TabIndex = 30
        Me.LabelControl7.Text = "استعمال المركبة:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Location = New System.Drawing.Point(746, 32)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 17)
        Me.LabelControl1.TabIndex = 30
        Me.LabelControl1.Text = "المركبة:"
        '
        'TabNavigationPageAccident
        '
        Me.TabNavigationPageAccident.Caption = "اصابات عمل"
        Me.TabNavigationPageAccident.ImageOptions.Image = CType(resources.GetObject("TabNavigationPageAccident.ImageOptions.Image"), System.Drawing.Image)
        Me.TabNavigationPageAccident.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageAccident.Margin = New System.Windows.Forms.Padding(4)
        Me.TabNavigationPageAccident.Name = "TabNavigationPageAccident"
        Me.TabNavigationPageAccident.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageAccident.Size = New System.Drawing.Size(812, 183)
        '
        'TabNavigationPageFire
        '
        Me.TabNavigationPageFire.Caption = "الحريق والسرقة"
        Me.TabNavigationPageFire.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.fire_48px
        Me.TabNavigationPageFire.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageFire.Margin = New System.Windows.Forms.Padding(4)
        Me.TabNavigationPageFire.Name = "TabNavigationPageFire"
        Me.TabNavigationPageFire.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageFire.Size = New System.Drawing.Size(812, 183)
        '
        'TabNavigationPageSocial
        '
        Me.TabNavigationPageSocial.Caption = "المسؤولية المدنية"
        Me.TabNavigationPageSocial.ImageOptions.Image = CType(resources.GetObject("TabNavigationPageSocial.ImageOptions.Image"), System.Drawing.Image)
        Me.TabNavigationPageSocial.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageSocial.Margin = New System.Windows.Forms.Padding(4)
        Me.TabNavigationPageSocial.Name = "TabNavigationPageSocial"
        Me.TabNavigationPageSocial.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageSocial.Size = New System.Drawing.Size(812, 183)
        '
        'TabNavigationPageEngineering
        '
        Me.TabNavigationPageEngineering.Caption = "مشروع هندسي"
        Me.TabNavigationPageEngineering.ImageOptions.SvgImage = CType(resources.GetObject("TabNavigationPageEngineering.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.TabNavigationPageEngineering.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageEngineering.Name = "TabNavigationPageEngineering"
        Me.TabNavigationPageEngineering.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.TabNavigationPageEngineering.Size = New System.Drawing.Size(812, 183)
        '
        'ManualDocNo
        '
        Me.ManualDocNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ManualDocNo.Location = New System.Drawing.Point(259, 16)
        Me.ManualDocNo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ManualDocNo.Name = "ManualDocNo"
        Me.ManualDocNo.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.RegularMaskManager))
        Me.ManualDocNo.Properties.MaskSettings.Set("mask", "\d\d-\d-\d\d-\d\d-\d\d\d\d\d\d")
        Me.ManualDocNo.Properties.MaskSettings.Set("placeholder", Global.Microsoft.VisualBasic.ChrW(48))
        Me.ManualDocNo.Properties.MaxLength = 50
        Me.ManualDocNo.Size = New System.Drawing.Size(203, 24)
        Me.ManualDocNo.StyleController = Me.LayoutControl1
        Me.ManualDocNo.TabIndex = 28
        '
        'InsuranceDocType
        '
        Me.InsuranceDocType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsuranceDocType.Location = New System.Drawing.Point(530, 317)
        Me.InsuranceDocType.Margin = New System.Windows.Forms.Padding(4)
        Me.InsuranceDocType.Name = "InsuranceDocType"
        Me.InsuranceDocType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsuranceDocType.Properties.DisplayMember = "InsuranceTypeName"
        Me.InsuranceDocType.Properties.NullText = ""
        Me.InsuranceDocType.Properties.PopupView = Me.GridView4
        Me.InsuranceDocType.Properties.ValueMember = "TypeID"
        Me.InsuranceDocType.Size = New System.Drawing.Size(174, 24)
        Me.InsuranceDocType.StyleController = Me.LayoutControl1
        Me.InsuranceDocType.TabIndex = 32
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9})
        Me.GridView4.DetailHeight = 458
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID"
        Me.GridColumn8.FieldName = "TypeID"
        Me.GridColumn8.MinWidth = 23
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Width = 87
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "النوع"
        Me.GridColumn9.FieldName = "InsuranceTypeName"
        Me.GridColumn9.MinWidth = 23
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 87
        '
        'DocID
        '
        Me.DocID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DocID.Location = New System.Drawing.Point(635, 45)
        Me.DocID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DocID.Name = "DocID"
        Me.DocID.Properties.ReadOnly = True
        Me.DocID.Size = New System.Drawing.Size(69, 24)
        Me.DocID.StyleController = Me.LayoutControl1
        Me.DocID.TabIndex = 22
        '
        'InsuranceCompanyName
        '
        Me.InsuranceCompanyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsuranceCompanyName.Location = New System.Drawing.Point(24, 289)
        Me.InsuranceCompanyName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.InsuranceCompanyName.Name = "InsuranceCompanyName"
        Me.InsuranceCompanyName.Properties.MaxLength = 50
        Me.InsuranceCompanyName.Properties.ReadOnly = True
        Me.InsuranceCompanyName.Size = New System.Drawing.Size(502, 24)
        Me.InsuranceCompanyName.StyleController = Me.LayoutControl1
        Me.InsuranceCompanyName.TabIndex = 28
        '
        'InsuranceCompany
        '
        Me.InsuranceCompany.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsuranceCompany.Location = New System.Drawing.Point(530, 289)
        Me.InsuranceCompany.Margin = New System.Windows.Forms.Padding(4)
        Me.InsuranceCompany.Name = "InsuranceCompany"
        Me.InsuranceCompany.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.InsuranceCompany.Properties.DisplayMember = "RefNo"
        Me.InsuranceCompany.Properties.NullText = ""
        Me.InsuranceCompany.Properties.PopupView = Me.GridView3
        Me.InsuranceCompany.Properties.ShowAddNewButton = True
        Me.InsuranceCompany.Properties.ValueMember = "RefNo"
        Me.InsuranceCompany.Size = New System.Drawing.Size(174, 24)
        Me.InsuranceCompany.StyleController = Me.LayoutControl1
        Me.InsuranceCompany.TabIndex = 27
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView3.DetailHeight = 458
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "RefID"
        Me.GridColumn1.MinWidth = 23
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Width = 87
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "رقم المرجع"
        Me.GridColumn2.FieldName = "RefNo"
        Me.GridColumn2.MinWidth = 23
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 87
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "المرجع"
        Me.GridColumn3.FieldName = "RefName"
        Me.GridColumn3.MinWidth = 23
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 87
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "نوع المرجع"
        Me.GridColumn4.FieldName = "RefTypeName"
        Me.GridColumn4.MinWidth = 23
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 87
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "رقم الحساب"
        Me.GridColumn5.FieldName = "RefAccID"
        Me.GridColumn5.MinWidth = 23
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Width = 87
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "نوع المرجع"
        Me.GridColumn6.FieldName = "TypeID"
        Me.GridColumn6.MinWidth = 23
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Width = 87
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "العملة"
        Me.GridColumn7.FieldName = "Currency"
        Me.GridColumn7.MinWidth = 23
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Width = 87
        '
        'DocDate
        '
        Me.DocDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DocDate.EditValue = Nothing
        Me.DocDate.Location = New System.Drawing.Point(455, 73)
        Me.DocDate.Margin = New System.Windows.Forms.Padding(4)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DocDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Size = New System.Drawing.Size(249, 24)
        Me.DocDate.StyleController = Me.LayoutControl1
        Me.DocDate.TabIndex = 30
        '
        'ReferanceID
        '
        Me.ReferanceID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReferanceID.Location = New System.Drawing.Point(493, 147)
        Me.ReferanceID.Margin = New System.Windows.Forms.Padding(4)
        Me.ReferanceID.Name = "ReferanceID"
        Me.ReferanceID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReferanceID.Properties.DisplayMember = "RefNo"
        Me.ReferanceID.Properties.NullText = ""
        Me.ReferanceID.Properties.PopupView = Me.GridView1
        Me.ReferanceID.Properties.ShowAddNewButton = True
        Me.ReferanceID.Properties.ValueMember = "RefNo"
        Me.ReferanceID.Size = New System.Drawing.Size(211, 24)
        Me.ReferanceID.StyleController = Me.LayoutControl1
        Me.ReferanceID.TabIndex = 27
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID, Me.ColTypeID, Me.ColCurrency})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColRefID
        '
        Me.ColRefID.Caption = "ID"
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.MinWidth = 23
        Me.ColRefID.Name = "ColRefID"
        Me.ColRefID.Width = 87
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم المرجع"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.MinWidth = 23
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.Visible = True
        Me.ColRefNo.VisibleIndex = 0
        Me.ColRefNo.Width = 87
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "المرجع"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.MinWidth = 23
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 1
        Me.ColRefName.Width = 87
        '
        'ColRefTypeName
        '
        Me.ColRefTypeName.Caption = "نوع المرجع"
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.MinWidth = 23
        Me.ColRefTypeName.Name = "ColRefTypeName"
        Me.ColRefTypeName.Visible = True
        Me.ColRefTypeName.VisibleIndex = 2
        Me.ColRefTypeName.Width = 87
        '
        'ColRefAccID
        '
        Me.ColRefAccID.Caption = "رقم الحساب"
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.MinWidth = 23
        Me.ColRefAccID.Name = "ColRefAccID"
        Me.ColRefAccID.Width = 87
        '
        'ColTypeID
        '
        Me.ColTypeID.Caption = "نوع المرجع"
        Me.ColTypeID.FieldName = "TypeID"
        Me.ColTypeID.MinWidth = 23
        Me.ColTypeID.Name = "ColTypeID"
        Me.ColTypeID.Width = 87
        '
        'ColCurrency
        '
        Me.ColCurrency.Caption = "العملة"
        Me.ColCurrency.FieldName = "Currency"
        Me.ColCurrency.MinWidth = 23
        Me.ColCurrency.Name = "ColCurrency"
        Me.ColCurrency.Width = 87
        '
        'BeneficiaryName
        '
        Me.BeneficiaryName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BeneficiaryName.Location = New System.Drawing.Point(24, 178)
        Me.BeneficiaryName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BeneficiaryName.Name = "BeneficiaryName"
        Me.BeneficiaryName.Properties.MaxLength = 50
        Me.BeneficiaryName.Size = New System.Drawing.Size(680, 24)
        Me.BeneficiaryName.StyleController = Me.LayoutControl1
        Me.BeneficiaryName.TabIndex = 28
        '
        'DateFrom
        '
        Me.DateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateFrom.EditValue = Nothing
        Me.DateFrom.Location = New System.Drawing.Point(24, 45)
        Me.DateFrom.Margin = New System.Windows.Forms.Padding(4)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateFrom.Size = New System.Drawing.Size(184, 24)
        Me.DateFrom.StyleController = Me.LayoutControl1
        Me.DateFrom.TabIndex = 30
        '
        'ReferanceName
        '
        Me.ReferanceName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReferanceName.Location = New System.Drawing.Point(24, 147)
        Me.ReferanceName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ReferanceName.Name = "ReferanceName"
        Me.ReferanceName.Properties.MaxLength = 50
        Me.ReferanceName.Properties.ReadOnly = True
        Me.ReferanceName.Size = New System.Drawing.Size(465, 24)
        Me.ReferanceName.StyleController = Me.LayoutControl1
        Me.ReferanceName.TabIndex = 28
        '
        'DateTo
        '
        Me.DateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTo.EditValue = Nothing
        Me.DateTo.Location = New System.Drawing.Point(24, 73)
        Me.DateTo.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateTo.Size = New System.Drawing.Size(184, 24)
        Me.DateTo.StyleController = Me.LayoutControl1
        Me.DateTo.TabIndex = 30
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.DocCode
        Me.LayoutControlItem16.Location = New System.Drawing.Point(395, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(396, 24)
        Me.LayoutControlItem16.Text = "DocCode"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(119, 17)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.TextDocNewOld
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(395, 24)
        Me.LayoutControlItem18.Text = "DocNewOld"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(119, 17)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ManualDocNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(210, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(284, 24)
        Me.LayoutControlItem1.Text = "كود الوثيقة"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(119, 17)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.Amount
        Me.LayoutControlItem13.Location = New System.Drawing.Point(599, 337)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(301, 28)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(120, 17)
        Me.LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.ExchangeRate
        Me.LayoutControlItem14.Location = New System.Drawing.Point(300, 337)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(600, 28)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(120, 17)
        Me.LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.Currency
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 337)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(900, 28)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(120, 17)
        Me.LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.ManualDocNo1
        Me.LayoutControlItem20.Location = New System.Drawing.Point(515, 0)
        Me.LayoutControlItem20.MaxSize = New System.Drawing.Size(129, 31)
        Me.LayoutControlItem20.MinSize = New System.Drawing.Size(129, 31)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(129, 31)
        Me.LayoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.SimpleSeparator1, Me.EmptySpaceItem5, Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(836, 707)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TabPane1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 413)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(816, 246)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(0, 101)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(816, 1)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 659)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(816, 28)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem19, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(816, 101)
        Me.LayoutControlGroup1.Text = "بيانات السند"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DocDate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(431, 28)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(361, 28)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(361, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(361, 28)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "تاريخ الإصدار:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.ManualDocNo2
        Me.LayoutControlItem19.Location = New System.Drawing.Point(431, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(180, 28)
        Me.LayoutControlItem19.Text = "كود السند:"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateFrom
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(296, 28)
        Me.LayoutControlItem4.Text = "تاريخ بداية التأمين:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DateTo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(296, 28)
        Me.LayoutControlItem5.Text = "تاريخ نهاية التأمين:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DocID
        Me.LayoutControlItem2.Location = New System.Drawing.Point(611, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(181, 28)
        Me.LayoutControlItem2.Text = "رقم الوثيقة:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 17)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(296, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(135, 56)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem6, Me.LayoutControlItem9})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(816, 104)
        Me.LayoutControlGroup2.Text = "الزبون"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.ReferanceName
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(469, 31)
        Me.LayoutControlItem7.Text = "اسم الزبون"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.ReferanceID
        Me.LayoutControlItem6.Location = New System.Drawing.Point(469, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(323, 31)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(323, 31)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(323, 31)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "الزبون:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.BeneficiaryName
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(792, 28)
        Me.LayoutControlItem9.Text = "المستفيد:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem24, Me.LayoutInsuranceExpAmount, Me.LayoutInsurancePercentagePercentage, Me.LayoutControlItem21, Me.EmptySpaceItem8, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem10, Me.LayoutControlItem22, Me.LayoutControlItem17, Me.LayoutControlItem23, Me.LayoutControlItem25, Me.LayoutControlItem26})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 206)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(816, 207)
        Me.LayoutControlGroup3.Text = "بيانات التأمين"
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.InsuranceExpenseMethod
        Me.LayoutControlItem24.Location = New System.Drawing.Point(505, 0)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(287, 38)
        Me.LayoutControlItem24.Text = "العمولة:"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutInsuranceExpAmount
        '
        Me.LayoutInsuranceExpAmount.Control = Me.TextInsuranceExpeneseAmount
        Me.LayoutInsuranceExpAmount.Location = New System.Drawing.Point(340, 0)
        Me.LayoutInsuranceExpAmount.Name = "LayoutInsuranceExpAmount"
        Me.LayoutInsuranceExpAmount.Size = New System.Drawing.Size(165, 38)
        Me.LayoutInsuranceExpAmount.Text = "مبلغ العمولة:"
        Me.LayoutInsuranceExpAmount.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutInsurancePercentagePercentage
        '
        Me.LayoutInsurancePercentagePercentage.Control = Me.TextInsuranceExpensePerc
        Me.LayoutInsurancePercentagePercentage.Location = New System.Drawing.Point(175, 0)
        Me.LayoutInsurancePercentagePercentage.Name = "LayoutInsurancePercentagePercentage"
        Me.LayoutInsurancePercentagePercentage.Size = New System.Drawing.Size(165, 38)
        Me.LayoutInsurancePercentagePercentage.Text = "نسبة العمولة:"
        Me.LayoutInsurancePercentagePercentage.TextSize = New System.Drawing.Size(96, 17)
        Me.LayoutInsurancePercentagePercentage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.TextInsuranceExpense
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(165, 38)
        Me.LayoutControlItem21.Text = "عمولة الزبون:"
        Me.LayoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(73, 17)
        Me.LayoutControlItem21.TextToControlDistance = 5
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(165, 0)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(10, 38)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.InsuranceCompany
        Me.LayoutControlItem10.Location = New System.Drawing.Point(506, 38)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(286, 28)
        Me.LayoutControlItem10.Text = "شركة التأمين:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.InsuranceCompanyName
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(506, 28)
        Me.LayoutControlItem11.Text = "اسم شركة التأمين"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.InsuranceDocType
        Me.LayoutControlItem12.Location = New System.Drawing.Point(506, 66)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(286, 28)
        Me.LayoutControlItem12.Text = "نوع التأمين:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(96, 17)
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(263, 66)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(81, 28)
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.InsurancePlace
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 66)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(263, 28)
        Me.LayoutControlItem22.Text = "مكان التأمين:"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.DocNotes
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 122)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(0, 40)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(122, 40)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(792, 40)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "ملاحظات:"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.InsuranceService
        Me.LayoutControlItem23.Location = New System.Drawing.Point(344, 66)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(162, 28)
        Me.LayoutControlItem23.Text = "الخدمة"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(96, 17)
        Me.LayoutControlItem23.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.TextInsuranceFullAmount
        Me.LayoutControlItem25.Location = New System.Drawing.Point(396, 94)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(396, 28)
        Me.LayoutControlItem25.Text = "مبلغ التأمين"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(96, 17)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.TextInsuranceAmount
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 94)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(396, 28)
        Me.LayoutControlItem26.Text = "قسط التأمين:"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(96, 17)
        '
        'TaskID
        '
        Me.TaskID.Location = New System.Drawing.Point(6, 389)
        Me.TaskID.Name = "TaskID"
        Me.TaskID.Size = New System.Drawing.Size(27, 24)
        Me.TaskID.TabIndex = 41
        Me.TaskID.Visible = False
        '
        'InsuranceDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1152, 707)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "InsuranceDoc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سند تأمين"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.DockPanel1_Container.PerformLayout()
        CType(Me.RelatedJournal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VoucherNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAutoIssueDocument.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckCreateAppointment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookDocStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextInsuranceAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInsuranceFullAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsuranceService.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManualDocNo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInsuranceExpeneseAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsuranceExpenseMethod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInsuranceExpensePerc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsurancePlace.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInsuranceExpense.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManualDocNo1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocNewOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangeRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPageCars.ResumeLayout(False)
        Me.TabNavigationPageCars.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.TextEngine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextYearCar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCarModel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCarType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CarCoverType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CarType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CARNO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ManualDocNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsuranceDocType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsuranceCompanyName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InsuranceCompany.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferanceID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeneficiaryName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferanceName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutInsuranceExpAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutInsurancePercentagePercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaskID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LabelFormName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LookDocStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents DocID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ReferanceID As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReferanceName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPageCars As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPageAccident As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPageFire As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabNavigationPageSocial As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CARNO As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents DocDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents CarCoverType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CarType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents InsuranceCompany As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InsuranceCompanyName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextInsuranceAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ButtonIssueVoucher As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonAddAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextInsuranceFullAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents InsuranceDocType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextDocNewOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckCreateAppointment As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents DocNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelCarType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl26 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEngine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextYearCar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextCarModel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextCarType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BeneficiaryName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ManualDocNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents HyperlinkLabelVoucherNo As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents VoucherNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TaskIDText As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Currency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ExchangeRate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Amount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents ManualDocNo1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextInsuranceExpense As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ButtonIssueJournal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents HyperlinkLabelJournalNo As DevExpress.XtraEditors.HyperlinkLabelControl
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents InsurancePlace As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RelatedJournal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextInsuranceExpensePerc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutInsurancePercentagePercentage As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextInsuranceExpeneseAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents InsuranceExpenseMethod As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutInsuranceExpAmount As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckAutoIssueDocument As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TabNavigationPageEngineering As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ManualDocNo2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents InsuranceService As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TaskID As DevExpress.XtraEditors.TextEdit
End Class
