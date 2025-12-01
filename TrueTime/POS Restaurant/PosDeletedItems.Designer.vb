<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosDeletedItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosDeletedItems))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeleteDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeleteUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShiftID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckAutoFit = New DevExpress.XtraEditors.CheckEdit()
        Me.SearchEmployees = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.CheckAutoFit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchEmployees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(275, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(673, 516)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(649, 492)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColStockID, Me.ColItemName, Me.ColStockBarcode, Me.ColDeleteDateTime, Me.ColDeleteUser, Me.ColEmployeeName, Me.ColStockQuantity, Me.ColDocAmount, Me.ColDocCode, Me.ColShiftID})
        Me.GridView1.DetailHeight = 284
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColStockID
        '
        Me.ColStockID.Caption = "رقم الصنف"
        Me.ColStockID.FieldName = "StockID"
        Me.ColStockID.MinWidth = 17
        Me.ColStockID.Name = "ColStockID"
        Me.ColStockID.OptionsColumn.AllowEdit = False
        Me.ColStockID.Visible = True
        Me.ColStockID.VisibleIndex = 1
        Me.ColStockID.Width = 64
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.MinWidth = 17
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.AllowEdit = False
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 2
        Me.ColItemName.Width = 64
        '
        'ColStockBarcode
        '
        Me.ColStockBarcode.Caption = "باركود"
        Me.ColStockBarcode.FieldName = "StockBarcode"
        Me.ColStockBarcode.MinWidth = 17
        Me.ColStockBarcode.Name = "ColStockBarcode"
        Me.ColStockBarcode.OptionsColumn.AllowEdit = False
        Me.ColStockBarcode.Visible = True
        Me.ColStockBarcode.VisibleIndex = 3
        Me.ColStockBarcode.Width = 64
        '
        'ColDeleteDateTime
        '
        Me.ColDeleteDateTime.Caption = "وقت الحذف"
        Me.ColDeleteDateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm"
        Me.ColDeleteDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDeleteDateTime.FieldName = "DeleteDateTime"
        Me.ColDeleteDateTime.MinWidth = 17
        Me.ColDeleteDateTime.Name = "ColDeleteDateTime"
        Me.ColDeleteDateTime.OptionsColumn.AllowEdit = False
        Me.ColDeleteDateTime.Visible = True
        Me.ColDeleteDateTime.VisibleIndex = 4
        Me.ColDeleteDateTime.Width = 64
        '
        'ColDeleteUser
        '
        Me.ColDeleteUser.Caption = "رقم الموظف"
        Me.ColDeleteUser.FieldName = "DeleteUser"
        Me.ColDeleteUser.MinWidth = 17
        Me.ColDeleteUser.Name = "ColDeleteUser"
        Me.ColDeleteUser.OptionsColumn.AllowEdit = False
        Me.ColDeleteUser.Visible = True
        Me.ColDeleteUser.VisibleIndex = 5
        Me.ColDeleteUser.Width = 64
        '
        'ColEmployeeName
        '
        Me.ColEmployeeName.Caption = "الموظف"
        Me.ColEmployeeName.FieldName = "EmployeeName"
        Me.ColEmployeeName.MinWidth = 17
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.OptionsColumn.AllowEdit = False
        Me.ColEmployeeName.Visible = True
        Me.ColEmployeeName.VisibleIndex = 6
        Me.ColEmployeeName.Width = 64
        '
        'ColStockQuantity
        '
        Me.ColStockQuantity.Caption = "الكمية"
        Me.ColStockQuantity.FieldName = "StockQuantity"
        Me.ColStockQuantity.MinWidth = 17
        Me.ColStockQuantity.Name = "ColStockQuantity"
        Me.ColStockQuantity.OptionsColumn.AllowEdit = False
        Me.ColStockQuantity.Visible = True
        Me.ColStockQuantity.VisibleIndex = 7
        Me.ColStockQuantity.Width = 64
        '
        'ColDocAmount
        '
        Me.ColDocAmount.Caption = "المبلغ"
        Me.ColDocAmount.FieldName = "DocAmount"
        Me.ColDocAmount.MinWidth = 17
        Me.ColDocAmount.Name = "ColDocAmount"
        Me.ColDocAmount.OptionsColumn.AllowEdit = False
        Me.ColDocAmount.Visible = True
        Me.ColDocAmount.VisibleIndex = 8
        Me.ColDocAmount.Width = 64
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "DocCode"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MinWidth = 17
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.OptionsColumn.AllowEdit = False
        Me.ColDocCode.Width = 64
        '
        'ColShiftID
        '
        Me.ColShiftID.Caption = "رقم الشفت"
        Me.ColShiftID.FieldName = "ShiftID"
        Me.ColShiftID.MinWidth = 17
        Me.ColShiftID.Name = "ColShiftID"
        Me.ColShiftID.OptionsColumn.AllowEdit = False
        Me.ColShiftID.Visible = True
        Me.ColShiftID.VisibleIndex = 0
        Me.ColShiftID.Width = 64
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(673, 516)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.GridControl1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(653, 496)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
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
        Me.DockPanel1.ID = New System.Guid("6d403f50-acb3-4da9-817f-338e7496456b")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(275, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(275, 516)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(5, 38)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(266, 474)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.CheckAutoFit)
        Me.LayoutControl2.Controls.Add(Me.SearchEmployees)
        Me.LayoutControl2.Controls.Add(Me.DateEditTo)
        Me.LayoutControl2.Controls.Add(Me.DateEditFrom)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(266, 474)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'CheckAutoFit
        '
        Me.CheckAutoFit.EditValue = True
        Me.CheckAutoFit.Location = New System.Drawing.Point(12, 84)
        Me.CheckAutoFit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CheckAutoFit.Name = "CheckAutoFit"
        Me.CheckAutoFit.Properties.Caption = "ملائمة التقرير للشاشة"
        Me.CheckAutoFit.Size = New System.Drawing.Size(242, 19)
        Me.CheckAutoFit.StyleController = Me.LayoutControl2
        Me.CheckAutoFit.TabIndex = 13
        '
        'SearchEmployees
        '
        Me.SearchEmployees.Location = New System.Drawing.Point(12, 60)
        Me.SearchEmployees.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SearchEmployees.Name = "SearchEmployees"
        Me.SearchEmployees.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchEmployees.Properties.DisplayMember = "EmployeeName"
        Me.SearchEmployees.Properties.NullText = "الكل"
        Me.SearchEmployees.Properties.NullValuePrompt = "اختر الموظف"
        Me.SearchEmployees.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchEmployees.Properties.ValueMember = "EmployeeID"
        Me.SearchEmployees.Size = New System.Drawing.Size(205, 20)
        Me.SearchEmployees.StyleController = Me.LayoutControl2
        Me.SearchEmployees.TabIndex = 12
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.DetailHeight = 284
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
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
        Me.GridColumn1.Width = 64
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "الموظف"
        Me.GridColumn2.FieldName = "EmployeeName"
        Me.GridColumn2.MinWidth = 17
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 64
        '
        'DateEditTo
        '
        Me.DateEditTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateEditTo.EditValue = Nothing
        Me.DateEditTo.Location = New System.Drawing.Point(12, 36)
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
        Me.DateEditTo.Size = New System.Drawing.Size(205, 20)
        Me.DateEditTo.StyleController = Me.LayoutControl2
        Me.DateEditTo.TabIndex = 11
        '
        'DateEditFrom
        '
        Me.DateEditFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateEditFrom.EditValue = Nothing
        Me.DateEditFrom.Location = New System.Drawing.Point(12, 12)
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
        Me.DateEditFrom.Size = New System.Drawing.Size(205, 20)
        Me.DateEditFrom.StyleController = Me.LayoutControl2
        Me.DateEditFrom.TabIndex = 10
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 440)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(242, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "تحديث F5 "
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(266, 474)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 95)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(246, 333)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 428)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(246, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SearchEmployees
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem2.Text = "الموظف"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(33, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateEditTo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem4.Text = "الى"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(33, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DateEditFrom
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(246, 24)
        Me.LayoutControlItem5.Text = "من"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(33, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CheckAutoFit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(246, 23)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'PosDeletedItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 516)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "PosDeletedItems"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "تقرير الحركات المحذوفة"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.CheckAutoFit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchEmployees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckAutoFit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SearchEmployees As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColStockID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeleteDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeleteUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColShiftID As DevExpress.XtraGrid.Columns.GridColumn
End Class
