<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosVoucherReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosVoucherReport))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchPOSNames = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckAutoFit = New DevExpress.XtraEditors.CheckEdit()
        Me.SearchEmployees = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColVoucherID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEditVoucherNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColVoucherCounter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherDiscount2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherPC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherAmountAfterDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherDebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherCredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherPayType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaidMethodName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherReferanceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherReferance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemDocName = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DocNamesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueAccountingDataSet = New TrueTime.AccountingDataSet()
        Me.ColPosNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShiftID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPOSName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocNamesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.DocNamesTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SearchPOSNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAutoFit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchEmployees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEditVoucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDocName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNamesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SearchPOSNames)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.CheckAutoFit)
        Me.LayoutControl1.Controls.Add(Me.SearchEmployees)
        Me.LayoutControl1.Controls.Add(Me.DateEditTo)
        Me.LayoutControl1.Controls.Add(Me.DateEditFrom)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(269, 458)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SearchPOSNames
        '
        Me.SearchPOSNames.Location = New System.Drawing.Point(16, 118)
        Me.SearchPOSNames.MenuManager = Me.BarManager1
        Me.SearchPOSNames.Name = "SearchPOSNames"
        Me.SearchPOSNames.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchPOSNames.Properties.DisplayMember = "POSName"
        Me.SearchPOSNames.Properties.NullText = ""
        Me.SearchPOSNames.Properties.PopupView = Me.GridView2
        Me.SearchPOSNames.Properties.ValueMember = "ID"
        Me.SearchPOSNames.Size = New System.Drawing.Size(175, 28)
        Me.SearchPOSNames.StyleController = Me.LayoutControl1
        Me.SearchPOSNames.TabIndex = 20
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockManager = Me.DockManager1
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 2
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Copy"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = CType(resources.GetObject("BarButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
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
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1044, 39)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 538)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1044, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 39)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 499)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1044, 39)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 499)
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.MenuManager = Me.BarManager1
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("58997753-a334-4506-a28f-8364e139de58")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 39)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(276, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(276, 499)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 38)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(269, 458)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "نقطة البيع"
        Me.GridColumn6.FieldName = "POSName"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "رقم"
        Me.GridColumn8.FieldName = "ID"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(16, 414)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(237, 28)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 19
        Me.SimpleButton2.Text = "طباعة"
        '
        'CheckAutoFit
        '
        Me.CheckAutoFit.EditValue = True
        Me.CheckAutoFit.Location = New System.Drawing.Point(16, 152)
        Me.CheckAutoFit.Name = "CheckAutoFit"
        Me.CheckAutoFit.Properties.Caption = "ملائمة التقرير للشاشة"
        Me.CheckAutoFit.Size = New System.Drawing.Size(237, 22)
        Me.CheckAutoFit.StyleController = Me.LayoutControl1
        Me.CheckAutoFit.TabIndex = 18
        '
        'SearchEmployees
        '
        Me.SearchEmployees.Location = New System.Drawing.Point(16, 84)
        Me.SearchEmployees.Name = "SearchEmployees"
        Me.SearchEmployees.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchEmployees.Properties.DisplayMember = "EmployeeName"
        Me.SearchEmployees.Properties.NullText = "الكل"
        Me.SearchEmployees.Properties.NullValuePrompt = "اختر الموظف"
        Me.SearchEmployees.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchEmployees.Properties.ValueMember = "EmployeeID"
        Me.SearchEmployees.Size = New System.Drawing.Size(175, 28)
        Me.SearchEmployees.StyleController = Me.LayoutControl1
        Me.SearchEmployees.TabIndex = 17
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3})
        Me.SearchLookUpEdit1View.DetailHeight = 283
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "رقم"
        Me.GridColumn1.FieldName = "EmployeeID"
        Me.GridColumn1.MinWidth = 17
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 63
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "الموظف"
        Me.GridColumn3.FieldName = "EmployeeName"
        Me.GridColumn3.MinWidth = 17
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 63
        '
        'DateEditTo
        '
        Me.DateEditTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateEditTo.EditValue = Nothing
        Me.DateEditTo.Location = New System.Drawing.Point(16, 50)
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.DateEditTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditTo.Properties.Mask.BeepOnError = True
        Me.DateEditTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditTo.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm")
        Me.DateEditTo.Properties.NullDate = ""
        Me.DateEditTo.Size = New System.Drawing.Size(175, 28)
        Me.DateEditTo.StyleController = Me.LayoutControl1
        Me.DateEditTo.TabIndex = 16
        '
        'DateEditFrom
        '
        Me.DateEditFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateEditFrom.EditValue = Nothing
        Me.DateEditFrom.Location = New System.Drawing.Point(16, 16)
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"
        Me.DateEditFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditFrom.Properties.Mask.BeepOnError = True
        Me.DateEditFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditFrom.Properties.MaskSettings.Set("mask", "yyyy-MM-dd HH:mm")
        Me.DateEditFrom.Properties.NullDate = ""
        Me.DateEditFrom.Size = New System.Drawing.Size(175, 28)
        Me.DateEditFrom.StyleController = Me.LayoutControl1
        Me.DateEditFrom.TabIndex = 15
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 380)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(237, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 14
        Me.SimpleButton1.Text = "تحديث F5 "
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(269, 458)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CheckAutoFit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(243, 28)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 164)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(243, 200)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 364)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DateEditFrom
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem5.Text = "من"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateEditTo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem4.Text = "الى"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SearchEmployees
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem3.Text = "الموظف"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SimpleButton2
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 398)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.SearchPOSNames
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(243, 34)
        Me.LayoutControlItem8.Text = "نقطة البيع"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(46, 13)
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GridControl1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(276, 39)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(768, 499)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Location = New System.Drawing.Point(16, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEditVoucherNo, Me.RepositoryItemDocName})
        Me.GridControl1.Size = New System.Drawing.Size(736, 467)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColVoucherID, Me.ColVoucherCounter, Me.GridColumn2, Me.ColVoucherAmount, Me.ColVoucherDiscount, Me.ColVoucherDiscount2, Me.ColVoucherPC, Me.ColVoucherAmountAfterDiscount, Me.GridColumn7, Me.ColVoucherCode, Me.ColVoucherDebit, Me.ColVoucherCredit, Me.ColVoucherPayType, Me.ColPaidMethodName, Me.ColVoucherReferanceName, Me.ColVoucherReferance, Me.ColEmployeeName, Me.ColVoucherNote, Me.ColDocName, Me.ColPosNo, Me.ColShiftID, Me.GridColumn4, Me.GridColumn5, Me.ColPOSName})
        Me.GridView1.DetailHeight = 283
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColVoucherID
        '
        Me.ColVoucherID.Caption = "رقم الفاتورة"
        Me.ColVoucherID.ColumnEdit = Me.RepositoryItemHyperLinkEditVoucherNo
        Me.ColVoucherID.FieldName = "VoucherID"
        Me.ColVoucherID.MinWidth = 17
        Me.ColVoucherID.Name = "ColVoucherID"
        Me.ColVoucherID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "VoucherID", "{0}")})
        Me.ColVoucherID.Visible = True
        Me.ColVoucherID.VisibleIndex = 0
        Me.ColVoucherID.Width = 63
        '
        'RepositoryItemHyperLinkEditVoucherNo
        '
        Me.RepositoryItemHyperLinkEditVoucherNo.AutoHeight = False
        Me.RepositoryItemHyperLinkEditVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemHyperLinkEditVoucherNo.Name = "RepositoryItemHyperLinkEditVoucherNo"
        Me.RepositoryItemHyperLinkEditVoucherNo.SingleClick = True
        '
        'ColVoucherCounter
        '
        Me.ColVoucherCounter.Caption = "العداد"
        Me.ColVoucherCounter.FieldName = "VoucherCounter"
        Me.ColVoucherCounter.Name = "ColVoucherCounter"
        Me.ColVoucherCounter.Visible = True
        Me.ColVoucherCounter.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "التاريخ/الوقت"
        Me.GridColumn2.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "VoucherDateTime"
        Me.GridColumn2.MinWidth = 17
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 4
        Me.GridColumn2.Width = 63
        '
        'ColVoucherAmount
        '
        Me.ColVoucherAmount.Caption = "مبلغ الفاتورة"
        Me.ColVoucherAmount.FieldName = "VoucherAmount"
        Me.ColVoucherAmount.MinWidth = 17
        Me.ColVoucherAmount.Name = "ColVoucherAmount"
        Me.ColVoucherAmount.OptionsColumn.ReadOnly = True
        Me.ColVoucherAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VoucherAmount", "{0:0.##}")})
        Me.ColVoucherAmount.Visible = True
        Me.ColVoucherAmount.VisibleIndex = 5
        Me.ColVoucherAmount.Width = 63
        '
        'ColVoucherDiscount
        '
        Me.ColVoucherDiscount.Caption = "خصم الأصناف"
        Me.ColVoucherDiscount.FieldName = "VoucherDiscount"
        Me.ColVoucherDiscount.MinWidth = 17
        Me.ColVoucherDiscount.Name = "ColVoucherDiscount"
        Me.ColVoucherDiscount.OptionsColumn.ReadOnly = True
        Me.ColVoucherDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VoucherDiscount", "{0:0.##}")})
        Me.ColVoucherDiscount.Visible = True
        Me.ColVoucherDiscount.VisibleIndex = 6
        Me.ColVoucherDiscount.Width = 63
        '
        'ColVoucherDiscount2
        '
        Me.ColVoucherDiscount2.Caption = "خصم الفاتورة"
        Me.ColVoucherDiscount2.FieldName = "VoucherDiscount2"
        Me.ColVoucherDiscount2.MinWidth = 21
        Me.ColVoucherDiscount2.Name = "ColVoucherDiscount2"
        Me.ColVoucherDiscount2.OptionsColumn.ReadOnly = True
        Me.ColVoucherDiscount2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VoucherDiscount2", "{0:0.##}")})
        Me.ColVoucherDiscount2.Visible = True
        Me.ColVoucherDiscount2.VisibleIndex = 7
        Me.ColVoucherDiscount2.Width = 63
        '
        'ColVoucherPC
        '
        Me.ColVoucherPC.Caption = "الجهاز"
        Me.ColVoucherPC.FieldName = "VoucherPC"
        Me.ColVoucherPC.MinWidth = 17
        Me.ColVoucherPC.Name = "ColVoucherPC"
        Me.ColVoucherPC.OptionsColumn.ReadOnly = True
        Me.ColVoucherPC.Width = 63
        '
        'ColVoucherAmountAfterDiscount
        '
        Me.ColVoucherAmountAfterDiscount.Caption = "المبلغ بعد الخصم"
        Me.ColVoucherAmountAfterDiscount.FieldName = "VoucherAmountAfterDiscount"
        Me.ColVoucherAmountAfterDiscount.MinWidth = 17
        Me.ColVoucherAmountAfterDiscount.Name = "ColVoucherAmountAfterDiscount"
        Me.ColVoucherAmountAfterDiscount.OptionsColumn.ReadOnly = True
        Me.ColVoucherAmountAfterDiscount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VoucherAmountAfterDiscount", "{0:0.##}")})
        Me.ColVoucherAmountAfterDiscount.Visible = True
        Me.ColVoucherAmountAfterDiscount.VisibleIndex = 8
        Me.ColVoucherAmountAfterDiscount.Width = 63
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "الموظف"
        Me.GridColumn7.FieldName = "UserNo"
        Me.GridColumn7.MinWidth = 17
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.Width = 63
        '
        'ColVoucherCode
        '
        Me.ColVoucherCode.Caption = "كود الفاتورة"
        Me.ColVoucherCode.FieldName = "VoucherCode"
        Me.ColVoucherCode.MinWidth = 17
        Me.ColVoucherCode.Name = "ColVoucherCode"
        Me.ColVoucherCode.OptionsColumn.ReadOnly = True
        Me.ColVoucherCode.Width = 63
        '
        'ColVoucherDebit
        '
        Me.ColVoucherDebit.Caption = "مدين"
        Me.ColVoucherDebit.FieldName = "VoucherDebit"
        Me.ColVoucherDebit.MinWidth = 17
        Me.ColVoucherDebit.Name = "ColVoucherDebit"
        Me.ColVoucherDebit.OptionsColumn.ReadOnly = True
        Me.ColVoucherDebit.Width = 63
        '
        'ColVoucherCredit
        '
        Me.ColVoucherCredit.Caption = "الدائن"
        Me.ColVoucherCredit.FieldName = "VoucherCredit"
        Me.ColVoucherCredit.MinWidth = 17
        Me.ColVoucherCredit.Name = "ColVoucherCredit"
        Me.ColVoucherCredit.OptionsColumn.ReadOnly = True
        Me.ColVoucherCredit.Width = 63
        '
        'ColVoucherPayType
        '
        Me.ColVoucherPayType.Caption = "طريقة الدفع"
        Me.ColVoucherPayType.FieldName = "VoucherPayType"
        Me.ColVoucherPayType.MinWidth = 17
        Me.ColVoucherPayType.Name = "ColVoucherPayType"
        Me.ColVoucherPayType.OptionsColumn.ReadOnly = True
        Me.ColVoucherPayType.Visible = True
        Me.ColVoucherPayType.VisibleIndex = 10
        Me.ColVoucherPayType.Width = 63
        '
        'ColPaidMethodName
        '
        Me.ColPaidMethodName.Caption = "اسم البطاقة"
        Me.ColPaidMethodName.FieldName = "PaidMethodName"
        Me.ColPaidMethodName.MinWidth = 17
        Me.ColPaidMethodName.Name = "ColPaidMethodName"
        Me.ColPaidMethodName.OptionsColumn.ReadOnly = True
        Me.ColPaidMethodName.Visible = True
        Me.ColPaidMethodName.VisibleIndex = 11
        Me.ColPaidMethodName.Width = 63
        '
        'ColVoucherReferanceName
        '
        Me.ColVoucherReferanceName.Caption = "الزبون"
        Me.ColVoucherReferanceName.FieldName = "VoucherReferanceName"
        Me.ColVoucherReferanceName.MinWidth = 17
        Me.ColVoucherReferanceName.Name = "ColVoucherReferanceName"
        Me.ColVoucherReferanceName.OptionsColumn.ReadOnly = True
        Me.ColVoucherReferanceName.Visible = True
        Me.ColVoucherReferanceName.VisibleIndex = 12
        Me.ColVoucherReferanceName.Width = 63
        '
        'ColVoucherReferance
        '
        Me.ColVoucherReferance.Caption = "رقم الزبون"
        Me.ColVoucherReferance.FieldName = "VoucherReferance"
        Me.ColVoucherReferance.MinWidth = 17
        Me.ColVoucherReferance.Name = "ColVoucherReferance"
        Me.ColVoucherReferance.OptionsColumn.ReadOnly = True
        Me.ColVoucherReferance.Visible = True
        Me.ColVoucherReferance.VisibleIndex = 13
        Me.ColVoucherReferance.Width = 63
        '
        'ColEmployeeName
        '
        Me.ColEmployeeName.Caption = "اسم الموظف"
        Me.ColEmployeeName.FieldName = "EmployeeName"
        Me.ColEmployeeName.MinWidth = 17
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.OptionsColumn.ReadOnly = True
        Me.ColEmployeeName.Visible = True
        Me.ColEmployeeName.VisibleIndex = 9
        Me.ColEmployeeName.Width = 63
        '
        'ColVoucherNote
        '
        Me.ColVoucherNote.Caption = "ملاحظة الفاتورة"
        Me.ColVoucherNote.FieldName = "VoucherNote"
        Me.ColVoucherNote.MinWidth = 17
        Me.ColVoucherNote.Name = "ColVoucherNote"
        Me.ColVoucherNote.OptionsColumn.ReadOnly = True
        Me.ColVoucherNote.Visible = True
        Me.ColVoucherNote.VisibleIndex = 14
        Me.ColVoucherNote.Width = 63
        '
        'ColDocName
        '
        Me.ColDocName.Caption = "السند"
        Me.ColDocName.ColumnEdit = Me.RepositoryItemDocName
        Me.ColDocName.FieldName = "DocName"
        Me.ColDocName.MinWidth = 21
        Me.ColDocName.Name = "ColDocName"
        Me.ColDocName.OptionsColumn.ReadOnly = True
        Me.ColDocName.Visible = True
        Me.ColDocName.VisibleIndex = 2
        '
        'RepositoryItemDocName
        '
        Me.RepositoryItemDocName.AutoHeight = False
        Me.RepositoryItemDocName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDocName.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 21, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 21, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.RepositoryItemDocName.DataSource = Me.DocNamesBindingSource
        Me.RepositoryItemDocName.DisplayMember = "Name"
        Me.RepositoryItemDocName.Name = "RepositoryItemDocName"
        Me.RepositoryItemDocName.NullText = ""
        Me.RepositoryItemDocName.ValueMember = "id"
        '
        'DocNamesBindingSource
        '
        Me.DocNamesBindingSource.DataMember = "DocNames"
        Me.DocNamesBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'TrueAccountingDataSet
        '
        Me.TrueAccountingDataSet.DataSetName = "TrueAccountingDataSet"
        Me.TrueAccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ColPosNo
        '
        Me.ColPosNo.Caption = "PosNo"
        Me.ColPosNo.FieldName = "PosNo"
        Me.ColPosNo.MinWidth = 21
        Me.ColPosNo.Name = "ColPosNo"
        '
        'ColShiftID
        '
        Me.ColShiftID.Caption = "رقم الشفت"
        Me.ColShiftID.FieldName = "ShiftID"
        Me.ColShiftID.MinWidth = 21
        Me.ColShiftID.Name = "ColShiftID"
        Me.ColShiftID.Visible = True
        Me.ColShiftID.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "الطاولة"
        Me.GridColumn4.FieldName = "TableName"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "الزبون النقدي"
        Me.GridColumn5.FieldName = "CashCustomerName"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        '
        'ColPOSName
        '
        Me.ColPOSName.Caption = "نقطة البيع"
        Me.ColPOSName.FieldName = "POSName"
        Me.ColPOSName.Name = "ColPOSName"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(768, 499)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(742, 473)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'DocNamesTableAdapter
        '
        Me.DocNamesTableAdapter.ClearBeforeFill = True
        '
        'PosVoucherReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 565)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "PosVoucherReport"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "تقرير فواتير نقطة البيع"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SearchPOSNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAutoFit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchEmployees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEditVoucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDocName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNamesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColVoucherID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherPC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherAmountAfterDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherDebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherCredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherPayType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherReferanceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherReferance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents CheckAutoFit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SearchEmployees As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaidMethodName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherDiscount2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEditVoucherNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents ColDocName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemDocName As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents TrueAccountingDataSet As AccountingDataSet
    Friend WithEvents DocNamesBindingSource As BindingSource
    Friend WithEvents DocNamesTableAdapter As AccountingDataSetTableAdapters.DocNamesTableAdapter
    Friend WithEvents ColPosNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShiftID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherCounter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchPOSNames As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPOSName As DevExpress.XtraGrid.Columns.GridColumn
End Class
