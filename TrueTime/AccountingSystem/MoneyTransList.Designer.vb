<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MoneyTransList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoneyTransList))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.ColOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryOrdersStatus = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocStatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEditDocStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDocID = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColDocNameText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCredAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDebitAcc = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColReferance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryReferance = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColDocCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColBaseCurrAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryMemoNote = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ColDocSort = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDebitAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryOpenDoc = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColReferanceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryMemoReferanceName = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.ColDocManualNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReferanceCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReferanceNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryRefNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColSalesMan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocID2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColExchangePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaidStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemPaidStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColPaidAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRemainAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocTags = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTags = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColCostName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColVoucherDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHypertextLabel1 = New DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonSendAccrualVoucherSMS = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemReceiveMoney = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem6 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarPaidVoucher = New DevExpress.XtraBars.BarButtonItem()
        Me.BarUnPaidVoucher = New DevExpress.XtraBars.BarButtonItem()
        Me.BarInstallmentVoucher = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonRecCalculate = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarPrintClaims = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem9 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem10 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem5 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarShowTasdeedColumns = New DevExpress.XtraBars.BarButtonItem()
        Me.BarShare = New DevExpress.XtraBars.BarSubItem()
        Me.BarSendDocumentsByWhatsApp = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonSendToShalash = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem8 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSubItem5 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem7 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarEditItem1 = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItem2 = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.chkShowDletedDocuments = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckShowCurrencyDetails = New DevExpress.XtraEditors.CheckEdit()
        Me.MultiCurrencyCheck = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEditDocName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButtonAddNewDoc = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.HtmlTemplateCollection1 = New DevExpress.Utils.Html.HtmlTemplateCollection()
        Me.HtmlTemplate1 = New DevExpress.Utils.Html.HtmlTemplate()
        CType(Me.RepositoryOrdersStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEditDocStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDebitAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryReferance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryMemoNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryOpenDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryMemoReferanceName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryRefNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemPaidStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowDletedDocuments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowCurrencyDetails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MultiCurrencyCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditDocName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColOrderStatus
        '
        Me.ColOrderStatus.AppearanceCell.Options.UseTextOptions = True
        Me.ColOrderStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColOrderStatus, "ColOrderStatus")
        Me.ColOrderStatus.ColumnEdit = Me.RepositoryOrdersStatus
        Me.ColOrderStatus.FieldName = "OrderStatus"
        Me.ColOrderStatus.MaxWidth = 80
        Me.ColOrderStatus.MinWidth = 80
        Me.ColOrderStatus.Name = "ColOrderStatus"
        Me.ColOrderStatus.OptionsColumn.AllowEdit = False
        Me.ColOrderStatus.OptionsColumn.ReadOnly = True
        '
        'RepositoryOrdersStatus
        '
        Me.RepositoryOrdersStatus.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryOrdersStatus, "RepositoryOrdersStatus")
        Me.RepositoryOrdersStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryOrdersStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryOrdersStatus.DisplayMember = "OrderStatus"
        Me.RepositoryOrdersStatus.Name = "RepositoryOrdersStatus"
        Me.RepositoryOrdersStatus.PopupView = Me.RepositoryItemSearchLookUpEdit1View
        Me.RepositoryOrdersStatus.ValueMember = "ID"
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnOrderStatus})
        Me.RepositoryItemSearchLookUpEdit1View.DetailHeight = 284
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        resources.ApplyResources(Me.GridColumnID, "GridColumnID")
        Me.GridColumnID.FieldName = "ID"
        Me.GridColumnID.MinWidth = 17
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnOrderStatus
        '
        resources.ApplyResources(Me.GridColumnOrderStatus, "GridColumnOrderStatus")
        Me.GridColumnOrderStatus.FieldName = "OrderStatus"
        Me.GridColumnOrderStatus.MinWidth = 17
        Me.GridColumnOrderStatus.Name = "GridColumnOrderStatus"
        '
        'ColDocStatusID
        '
        resources.ApplyResources(Me.ColDocStatusID, "ColDocStatusID")
        Me.ColDocStatusID.ColumnEdit = Me.RepositoryItemLookUpEditDocStatus
        Me.ColDocStatusID.FieldName = "DocStatus"
        Me.ColDocStatusID.MaxWidth = 69
        Me.ColDocStatusID.MinWidth = 69
        Me.ColDocStatusID.Name = "ColDocStatusID"
        Me.ColDocStatusID.OptionsColumn.AllowEdit = False
        '
        'RepositoryItemLookUpEditDocStatus
        '
        Me.RepositoryItemLookUpEditDocStatus.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryItemLookUpEditDocStatus, "RepositoryItemLookUpEditDocStatus")
        Me.RepositoryItemLookUpEditDocStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEditDocStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemLookUpEditDocStatus.Columns"), resources.GetString("RepositoryItemLookUpEditDocStatus.Columns1"), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns2"), Integer), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemLookUpEditDocStatus.Columns4"), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns5"), Boolean), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemLookUpEditDocStatus.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemLookUpEditDocStatus.Columns9"), resources.GetString("RepositoryItemLookUpEditDocStatus.Columns10"))})
        Me.RepositoryItemLookUpEditDocStatus.DisplayMember = "DocStatus"
        Me.RepositoryItemLookUpEditDocStatus.Name = "RepositoryItemLookUpEditDocStatus"
        Me.RepositoryItemLookUpEditDocStatus.ValueMember = "ID"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryDebitAcc, Me.RepositoryReferance, Me.RepositoryOpenDoc, Me.RepositoryMemoNote, Me.RepositoryMemoReferanceName, Me.RepositoryOrdersStatus, Me.RepositoryDocID, Me.RepositoryItemLookUpEditDocStatus, Me.RepositoryRefNo, Me.RepositoryItemPaidStatus, Me.RepositoryItemHypertextLabel1, Me.RepositoryItemTags})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColDocID, Me.ColDocNameText, Me.ColDocDate, Me.ColCredAcc, Me.ColReferance, Me.ColDocCurrency, Me.ColDocAmount, Me.ColBaseCurrAmount, Me.ColDocNotes, Me.ColDocSort, Me.ColDebitAcc, Me.ColDocName, Me.GridColumn1, Me.ColReferanceName, Me.ColDocManualNo, Me.ColOrderStatus, Me.ColDocCode, Me.ColReferanceCode, Me.ColReferanceNo, Me.ColSalesMan, Me.ColDocStatusID, Me.ColStockID, Me.ColItemName, Me.ColStockPrice, Me.ColDocID2, Me.ColExchangePrice, Me.ColPaidStatus, Me.ColPaidAmount, Me.ColRemainAmount, Me.GridColumn2, Me.GridColumn3, Me.ColDocTags, Me.ColCostName, Me.ColStockDiscount, Me.ColVoucherDiscount})
        GridFormatRule1.Column = Me.ColOrderStatus
        GridFormatRule1.ColumnApplyTo = Me.ColOrderStatus
        GridFormatRule1.Description = Nothing
        GridFormatRule1.Name = "Format1"
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.PredefinedName = "Red Text"
        FormatConditionRuleValue1.Value1 = "مفوترة"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.ApplyToRow = True
        GridFormatRule2.Column = Me.ColDocStatusID
        GridFormatRule2.Description = Nothing
        GridFormatRule2.Name = "Format0"
        FormatConditionRuleValue2.Appearance.Font = CType(resources.GetObject("resource.Font"), System.Drawing.Font)
        FormatConditionRuleValue2.Appearance.Options.UseFont = True
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue2.Value1 = "0"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.FormatRules.Add(GridFormatRule2)
        Me.GridView1.GridControl = Me.GridControl1
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(CType(resources.GetObject("GridView1.GroupSummary"), DevExpress.Data.SummaryItemType), resources.GetString("GridView1.GroupSummary1"), Me.ColBaseCurrAmount, resources.GetString("GridView1.GroupSummary2")), New DevExpress.XtraGrid.GridGroupSummaryItem(CType(resources.GetObject("GridView1.GroupSummary3"), DevExpress.Data.SummaryItemType), resources.GetString("GridView1.GroupSummary4"), Me.ColDocID, resources.GetString("GridView1.GroupSummary5"))})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        Me.GridView1.OptionsView.ShowViewCaption = True
        '
        'ColDocID
        '
        Me.ColDocID.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocID, "ColDocID")
        Me.ColDocID.ColumnEdit = Me.RepositoryDocID
        Me.ColDocID.DisplayFormat.FormatString = "00000000"
        Me.ColDocID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDocID.FieldName = "DocID"
        Me.ColDocID.ImageOptions.Alignment = CType(resources.GetObject("ColDocID.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.ColDocID.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full
        Me.ColDocID.MaxWidth = 80
        Me.ColDocID.MinWidth = 80
        Me.ColDocID.Name = "ColDocID"
        Me.ColDocID.OptionsColumn.ReadOnly = True
        Me.ColDocID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColDocID.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColDocID.Summary1"), resources.GetString("ColDocID.Summary2"))})
        '
        'RepositoryDocID
        '
        resources.ApplyResources(Me.RepositoryDocID, "RepositoryDocID")
        Me.RepositoryDocID.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryDocID.MaskSettings.Set("mask", "00000000")
        Me.RepositoryDocID.Name = "RepositoryDocID"
        Me.RepositoryDocID.SingleClick = True
        '
        'ColDocNameText
        '
        Me.ColDocNameText.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocNameText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocNameText, "ColDocNameText")
        Me.ColDocNameText.FieldName = "DocNameText"
        Me.ColDocNameText.MaxWidth = 100
        Me.ColDocNameText.MinWidth = 100
        Me.ColDocNameText.Name = "ColDocNameText"
        Me.ColDocNameText.OptionsColumn.AllowEdit = False
        Me.ColDocNameText.OptionsColumn.ReadOnly = True
        '
        'ColDocDate
        '
        Me.ColDocDate.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocDate, "ColDocDate")
        Me.ColDocDate.FieldName = "DocDate"
        Me.ColDocDate.ImageOptions.Alignment = CType(resources.GetObject("ColDocDate.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.ColDocDate.MaxWidth = 80
        Me.ColDocDate.MinWidth = 80
        Me.ColDocDate.Name = "ColDocDate"
        Me.ColDocDate.OptionsColumn.AllowEdit = False
        Me.ColDocDate.OptionsColumn.ReadOnly = True
        '
        'ColCredAcc
        '
        Me.ColCredAcc.AppearanceCell.Options.UseTextOptions = True
        Me.ColCredAcc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColCredAcc, "ColCredAcc")
        Me.ColCredAcc.ColumnEdit = Me.RepositoryDebitAcc
        Me.ColCredAcc.FieldName = "Account"
        Me.ColCredAcc.Name = "ColCredAcc"
        Me.ColCredAcc.OptionsColumn.AllowEdit = False
        Me.ColCredAcc.OptionsColumn.FixedWidth = True
        Me.ColCredAcc.OptionsColumn.ReadOnly = True
        '
        'RepositoryDebitAcc
        '
        Me.RepositoryDebitAcc.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryDebitAcc, "RepositoryDebitAcc")
        Me.RepositoryDebitAcc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryDebitAcc.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryDebitAcc.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryDebitAcc.Columns"), resources.GetString("RepositoryDebitAcc.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryDebitAcc.Columns2"), resources.GetString("RepositoryDebitAcc.Columns3"))})
        Me.RepositoryDebitAcc.DisplayMember = "AccName"
        Me.RepositoryDebitAcc.Name = "RepositoryDebitAcc"
        Me.RepositoryDebitAcc.ValueMember = "AccNo"
        '
        'ColReferance
        '
        Me.ColReferance.AppearanceCell.Options.UseTextOptions = True
        Me.ColReferance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColReferance, "ColReferance")
        Me.ColReferance.ColumnEdit = Me.RepositoryReferance
        Me.ColReferance.FieldName = "Referance"
        Me.ColReferance.Name = "ColReferance"
        Me.ColReferance.OptionsColumn.AllowEdit = False
        Me.ColReferance.OptionsColumn.ReadOnly = True
        '
        'RepositoryReferance
        '
        Me.RepositoryReferance.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryReferance, "RepositoryReferance")
        Me.RepositoryReferance.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryReferance.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryReferance.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryReferance.Columns"), resources.GetString("RepositoryReferance.Columns1")), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryReferance.Columns2"), resources.GetString("RepositoryReferance.Columns3"))})
        Me.RepositoryReferance.DisplayMember = "RefName"
        Me.RepositoryReferance.Name = "RepositoryReferance"
        Me.RepositoryReferance.ValueMember = "RefNo"
        '
        'ColDocCurrency
        '
        Me.ColDocCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocCurrency, "ColDocCurrency")
        Me.ColDocCurrency.FieldName = "DocCurrency"
        Me.ColDocCurrency.ImageOptions.Alignment = CType(resources.GetObject("ColDocCurrency.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.ColDocCurrency.MaxWidth = 80
        Me.ColDocCurrency.Name = "ColDocCurrency"
        Me.ColDocCurrency.OptionsColumn.AllowEdit = False
        Me.ColDocCurrency.OptionsColumn.ReadOnly = True
        '
        'ColDocAmount
        '
        Me.ColDocAmount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocAmount, "ColDocAmount")
        Me.ColDocAmount.DisplayFormat.FormatString = "n2"
        Me.ColDocAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDocAmount.FieldName = "DocAmount"
        Me.ColDocAmount.MaxWidth = 120
        Me.ColDocAmount.Name = "ColDocAmount"
        Me.ColDocAmount.OptionsColumn.AllowEdit = False
        Me.ColDocAmount.OptionsColumn.ReadOnly = True
        Me.ColDocAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColDocAmount.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColDocAmount.Summary1"), resources.GetString("ColDocAmount.Summary2"))})
        '
        'ColBaseCurrAmount
        '
        Me.ColBaseCurrAmount.AppearanceCell.Options.UseTextOptions = True
        Me.ColBaseCurrAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColBaseCurrAmount, "ColBaseCurrAmount")
        Me.ColBaseCurrAmount.DisplayFormat.FormatString = "n2"
        Me.ColBaseCurrAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColBaseCurrAmount.FieldName = "BaseCurrAmount"
        Me.ColBaseCurrAmount.MaxWidth = 90
        Me.ColBaseCurrAmount.MinWidth = 90
        Me.ColBaseCurrAmount.Name = "ColBaseCurrAmount"
        Me.ColBaseCurrAmount.OptionsColumn.AllowEdit = False
        Me.ColBaseCurrAmount.OptionsColumn.ReadOnly = True
        Me.ColBaseCurrAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColBaseCurrAmount.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColBaseCurrAmount.Summary1"), resources.GetString("ColBaseCurrAmount.Summary2"))})
        '
        'ColDocNotes
        '
        Me.ColDocNotes.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocNotes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColDocNotes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColDocNotes.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.ColDocNotes, "ColDocNotes")
        Me.ColDocNotes.ColumnEdit = Me.RepositoryMemoNote
        Me.ColDocNotes.FieldName = "DocNotes"
        Me.ColDocNotes.Name = "ColDocNotes"
        Me.ColDocNotes.OptionsColumn.AllowEdit = False
        Me.ColDocNotes.OptionsColumn.ReadOnly = True
        '
        'RepositoryMemoNote
        '
        Me.RepositoryMemoNote.Appearance.Options.UseTextOptions = True
        Me.RepositoryMemoNote.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryMemoNote.Name = "RepositoryMemoNote"
        '
        'ColDocSort
        '
        Me.ColDocSort.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocSort.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocSort, "ColDocSort")
        Me.ColDocSort.FieldName = "DocSort"
        Me.ColDocSort.Name = "ColDocSort"
        Me.ColDocSort.OptionsColumn.AllowEdit = False
        Me.ColDocSort.OptionsColumn.ReadOnly = True
        '
        'ColDebitAcc
        '
        Me.ColDebitAcc.AppearanceCell.Options.UseTextOptions = True
        Me.ColDebitAcc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDebitAcc, "ColDebitAcc")
        Me.ColDebitAcc.ColumnEdit = Me.RepositoryDebitAcc
        Me.ColDebitAcc.FieldName = "DebitAcc"
        Me.ColDebitAcc.Name = "ColDebitAcc"
        Me.ColDebitAcc.OptionsColumn.AllowEdit = False
        Me.ColDebitAcc.OptionsColumn.ReadOnly = True
        '
        'ColDocName
        '
        Me.ColDocName.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocName, "ColDocName")
        Me.ColDocName.FieldName = "DocName"
        Me.ColDocName.Name = "ColDocName"
        Me.ColDocName.OptionsColumn.AllowEdit = False
        Me.ColDocName.OptionsColumn.ReadOnly = True
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn1.ColumnEdit = Me.RepositoryOpenDoc
        Me.GridColumn1.MaxWidth = 64
        Me.GridColumn1.MinWidth = 50
        Me.GridColumn1.Name = "GridColumn1"
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        '
        'RepositoryOpenDoc
        '
        resources.ApplyResources(Me.RepositoryOpenDoc, "RepositoryOpenDoc")
        Me.RepositoryOpenDoc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryOpenDoc.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryOpenDoc.Name = "RepositoryOpenDoc"
        Me.RepositoryOpenDoc.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'ColReferanceName
        '
        Me.ColReferanceName.AppearanceCell.Options.UseTextOptions = True
        Me.ColReferanceName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColReferanceName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        resources.ApplyResources(Me.ColReferanceName, "ColReferanceName")
        Me.ColReferanceName.ColumnEdit = Me.RepositoryMemoReferanceName
        Me.ColReferanceName.FieldName = "ReferanceName"
        Me.ColReferanceName.MinWidth = 120
        Me.ColReferanceName.Name = "ColReferanceName"
        Me.ColReferanceName.OptionsColumn.AllowEdit = False
        Me.ColReferanceName.OptionsColumn.ReadOnly = True
        '
        'RepositoryMemoReferanceName
        '
        Me.RepositoryMemoReferanceName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryMemoReferanceName.Appearance.Options.UseTextOptions = True
        Me.RepositoryMemoReferanceName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryMemoReferanceName.Name = "RepositoryMemoReferanceName"
        '
        'ColDocManualNo
        '
        Me.ColDocManualNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocManualNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocManualNo, "ColDocManualNo")
        Me.ColDocManualNo.FieldName = "DocManualNo"
        Me.ColDocManualNo.ImageOptions.Alignment = CType(resources.GetObject("ColDocManualNo.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.ColDocManualNo.MaxWidth = 100
        Me.ColDocManualNo.MinWidth = 60
        Me.ColDocManualNo.Name = "ColDocManualNo"
        Me.ColDocManualNo.OptionsColumn.AllowEdit = False
        Me.ColDocManualNo.OptionsColumn.ReadOnly = True
        '
        'ColDocCode
        '
        Me.ColDocCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColDocCode, "ColDocCode")
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MaxWidth = 100
        Me.ColDocCode.MinWidth = 100
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.OptionsColumn.AllowEdit = False
        Me.ColDocCode.OptionsColumn.ReadOnly = True
        '
        'ColReferanceCode
        '
        Me.ColReferanceCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColReferanceCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColReferanceCode, "ColReferanceCode")
        Me.ColReferanceCode.FieldName = "ReferanceCode"
        Me.ColReferanceCode.Name = "ColReferanceCode"
        Me.ColReferanceCode.OptionsColumn.AllowEdit = False
        '
        'ColReferanceNo
        '
        resources.ApplyResources(Me.ColReferanceNo, "ColReferanceNo")
        Me.ColReferanceNo.ColumnEdit = Me.RepositoryRefNo
        Me.ColReferanceNo.FieldName = "Referance"
        Me.ColReferanceNo.Name = "ColReferanceNo"
        '
        'RepositoryRefNo
        '
        resources.ApplyResources(Me.RepositoryRefNo, "RepositoryRefNo")
        Me.RepositoryRefNo.Name = "RepositoryRefNo"
        Me.RepositoryRefNo.SingleClick = True
        '
        'ColSalesMan
        '
        resources.ApplyResources(Me.ColSalesMan, "ColSalesMan")
        Me.ColSalesMan.FieldName = "SalesPerson"
        Me.ColSalesMan.Name = "ColSalesMan"
        Me.ColSalesMan.OptionsColumn.AllowEdit = False
        Me.ColSalesMan.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ColStockID
        '
        Me.ColStockID.AppearanceCell.Options.UseTextOptions = True
        Me.ColStockID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColStockID, "ColStockID")
        Me.ColStockID.FieldName = "ItemNo"
        Me.ColStockID.Name = "ColStockID"
        Me.ColStockID.OptionsColumn.AllowEdit = False
        Me.ColStockID.OptionsColumn.FixedWidth = True
        '
        'ColItemName
        '
        resources.ApplyResources(Me.ColItemName, "ColItemName")
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.AllowEdit = False
        '
        'ColStockPrice
        '
        Me.ColStockPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColStockPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        resources.ApplyResources(Me.ColStockPrice, "ColStockPrice")
        Me.ColStockPrice.DisplayFormat.FormatString = "n4"
        Me.ColStockPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColStockPrice.FieldName = "UnitPrice"
        Me.ColStockPrice.Name = "ColStockPrice"
        Me.ColStockPrice.OptionsColumn.AllowEdit = False
        Me.ColStockPrice.OptionsColumn.FixedWidth = True
        '
        'ColDocID2
        '
        resources.ApplyResources(Me.ColDocID2, "ColDocID2")
        Me.ColDocID2.FieldName = "DocID2"
        Me.ColDocID2.Name = "ColDocID2"
        Me.ColDocID2.OptionsColumn.AllowEdit = False
        Me.ColDocID2.OptionsColumn.FixedWidth = True
        Me.ColDocID2.OptionsColumn.ReadOnly = True
        '
        'ColExchangePrice
        '
        resources.ApplyResources(Me.ColExchangePrice, "ColExchangePrice")
        Me.ColExchangePrice.DisplayFormat.FormatString = "n4"
        Me.ColExchangePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColExchangePrice.FieldName = "ExchangePrice"
        Me.ColExchangePrice.Name = "ColExchangePrice"
        Me.ColExchangePrice.OptionsColumn.AllowEdit = False
        Me.ColExchangePrice.OptionsColumn.FixedWidth = True
        '
        'ColPaidStatus
        '
        resources.ApplyResources(Me.ColPaidStatus, "ColPaidStatus")
        Me.ColPaidStatus.ColumnEdit = Me.RepositoryItemPaidStatus
        Me.ColPaidStatus.FieldName = "PaidStatus"
        Me.ColPaidStatus.Name = "ColPaidStatus"
        Me.ColPaidStatus.OptionsColumn.AllowEdit = False
        Me.ColPaidStatus.OptionsColumn.FixedWidth = True
        Me.ColPaidStatus.OptionsColumn.ReadOnly = True
        '
        'RepositoryItemPaidStatus
        '
        Me.RepositoryItemPaidStatus.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.RepositoryItemPaidStatus, "RepositoryItemPaidStatus")
        Me.RepositoryItemPaidStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemPaidStatus.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemPaidStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemPaidStatus.Columns"), resources.GetString("RepositoryItemPaidStatus.Columns1"), CType(resources.GetObject("RepositoryItemPaidStatus.Columns2"), Integer), CType(resources.GetObject("RepositoryItemPaidStatus.Columns3"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemPaidStatus.Columns4"), CType(resources.GetObject("RepositoryItemPaidStatus.Columns5"), Boolean), CType(resources.GetObject("RepositoryItemPaidStatus.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemPaidStatus.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemPaidStatus.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("RepositoryItemPaidStatus.Columns9"), resources.GetString("RepositoryItemPaidStatus.Columns10"), CType(resources.GetObject("RepositoryItemPaidStatus.Columns11"), Integer), CType(resources.GetObject("RepositoryItemPaidStatus.Columns12"), DevExpress.Utils.FormatType), resources.GetString("RepositoryItemPaidStatus.Columns13"), CType(resources.GetObject("RepositoryItemPaidStatus.Columns14"), Boolean), CType(resources.GetObject("RepositoryItemPaidStatus.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("RepositoryItemPaidStatus.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("RepositoryItemPaidStatus.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.RepositoryItemPaidStatus.DisplayMember = "name"
        Me.RepositoryItemPaidStatus.Name = "RepositoryItemPaidStatus"
        Me.RepositoryItemPaidStatus.ValueMember = "id"
        '
        'ColPaidAmount
        '
        resources.ApplyResources(Me.ColPaidAmount, "ColPaidAmount")
        Me.ColPaidAmount.FieldName = "PaidAmount"
        Me.ColPaidAmount.Name = "ColPaidAmount"
        Me.ColPaidAmount.OptionsColumn.AllowEdit = False
        Me.ColPaidAmount.OptionsColumn.ReadOnly = True
        '
        'ColRemainAmount
        '
        resources.ApplyResources(Me.ColRemainAmount, "ColRemainAmount")
        Me.ColRemainAmount.FieldName = "ColRemainAmount"
        Me.ColRemainAmount.FieldNameSortGroup = "RemainAmount"
        Me.ColRemainAmount.MinWidth = 17
        Me.ColRemainAmount.Name = "ColRemainAmount"
        Me.ColRemainAmount.OptionsColumn.AllowEdit = False
        Me.ColRemainAmount.OptionsColumn.ReadOnly = True
        Me.ColRemainAmount.UnboundDataType = GetType(Decimal)
        Me.ColRemainAmount.UnboundExpression = "[DocAmount] - [PaidAmount]"
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "RefSort"
        Me.GridColumn2.MinWidth = 17
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        '
        'GridColumn3
        '
        resources.ApplyResources(Me.GridColumn3, "GridColumn3")
        Me.GridColumn3.FieldName = "DeviceName"
        Me.GridColumn3.MinWidth = 21
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        '
        'ColDocTags
        '
        resources.ApplyResources(Me.ColDocTags, "ColDocTags")
        Me.ColDocTags.ColumnEdit = Me.RepositoryItemTags
        Me.ColDocTags.FieldName = "DocTags"
        Me.ColDocTags.Name = "ColDocTags"
        Me.ColDocTags.OptionsColumn.AllowEdit = False
        Me.ColDocTags.OptionsColumn.FixedWidth = True
        '
        'RepositoryItemTags
        '
        Me.RepositoryItemTags.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemTags.Name = "RepositoryItemTags"
        '
        'ColCostName
        '
        resources.ApplyResources(Me.ColCostName, "ColCostName")
        Me.ColCostName.FieldName = "CostCenterName"
        Me.ColCostName.Name = "ColCostName"
        Me.ColCostName.OptionsColumn.AllowEdit = False
        '
        'ColStockDiscount
        '
        resources.ApplyResources(Me.ColStockDiscount, "ColStockDiscount")
        Me.ColStockDiscount.FieldName = "StockDiscount"
        Me.ColStockDiscount.Name = "ColStockDiscount"
        Me.ColStockDiscount.OptionsColumn.ReadOnly = True
        '
        'ColVoucherDiscount
        '
        resources.ApplyResources(Me.ColVoucherDiscount, "ColVoucherDiscount")
        Me.ColVoucherDiscount.FieldName = "VoucherDiscount"
        Me.ColVoucherDiscount.Name = "ColVoucherDiscount"
        '
        'RepositoryItemHypertextLabel1
        '
        Me.RepositoryItemHypertextLabel1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemHypertextLabel1.Name = "RepositoryItemHypertextLabel1"
        '
        'RepositoryItemCheckEdit2
        '
        resources.ApplyResources(Me.RepositoryItemCheckEdit2, "RepositoryItemCheckEdit2")
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.MenuManager = Me.BarManager1
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.DockManager = Me.DockManager1
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.BarSubItem2, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4, Me.BarSubItem3, Me.BarButtonSendAccrualVoucherSMS, Me.BarButtonItemReceiveMoney, Me.BarSubItem4, Me.BarButtonItem5, Me.BarSubItem5, Me.BarButtonItem7, Me.BarEditItem1, Me.BarEditItem2, Me.BarButtonItem6, Me.BarButtonItem8, Me.BarPrintClaims, Me.BarButtonItem9, Me.BarButtonItem10, Me.BarPaidVoucher, Me.BarUnPaidVoucher, Me.BarShowTasdeedColumns, Me.BarShare, Me.BarSendDocumentsByWhatsApp, Me.BarButtonSendToShalash, Me.BarInstallmentVoucher, Me.BarButtonRecCalculate})
        Me.BarManager1.MaxItemId = 35
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.RepositoryItemLookUpEdit2})
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.BarShare), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem8)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        resources.ApplyResources(Me.BarSubItem1, "BarSubItem1")
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.ImageOptions.Image = CType(resources.GetObject("BarSubItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem1.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem6), New DevExpress.XtraBars.LinkPersistInfo(Me.BarPaidVoucher), New DevExpress.XtraBars.LinkPersistInfo(Me.BarUnPaidVoucher), New DevExpress.XtraBars.LinkPersistInfo(Me.BarInstallmentVoucher), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonRecCalculate)})
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarSubItem3
        '
        resources.ApplyResources(Me.BarSubItem3, "BarSubItem3")
        Me.BarSubItem3.Id = 7
        Me.BarSubItem3.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonSendAccrualVoucherSMS), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemReceiveMoney)})
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'BarButtonSendAccrualVoucherSMS
        '
        resources.ApplyResources(Me.BarButtonSendAccrualVoucherSMS, "BarButtonSendAccrualVoucherSMS")
        Me.BarButtonSendAccrualVoucherSMS.Id = 8
        Me.BarButtonSendAccrualVoucherSMS.Name = "BarButtonSendAccrualVoucherSMS"
        '
        'BarButtonItemReceiveMoney
        '
        resources.ApplyResources(Me.BarButtonItemReceiveMoney, "BarButtonItemReceiveMoney")
        Me.BarButtonItemReceiveMoney.Id = 9
        Me.BarButtonItemReceiveMoney.Name = "BarButtonItemReceiveMoney"
        '
        'BarButtonItem6
        '
        resources.ApplyResources(Me.BarButtonItem6, "BarButtonItem6")
        Me.BarButtonItem6.Id = 17
        Me.BarButtonItem6.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem6.Name = "BarButtonItem6"
        '
        'BarPaidVoucher
        '
        resources.ApplyResources(Me.BarPaidVoucher, "BarPaidVoucher")
        Me.BarPaidVoucher.Id = 23
        Me.BarPaidVoucher.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarPaidVoucher.Name = "BarPaidVoucher"
        '
        'BarUnPaidVoucher
        '
        resources.ApplyResources(Me.BarUnPaidVoucher, "BarUnPaidVoucher")
        Me.BarUnPaidVoucher.Id = 24
        Me.BarUnPaidVoucher.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarUnPaidVoucher.Name = "BarUnPaidVoucher"
        '
        'BarInstallmentVoucher
        '
        resources.ApplyResources(Me.BarInstallmentVoucher, "BarInstallmentVoucher")
        Me.BarInstallmentVoucher.Id = 33
        Me.BarInstallmentVoucher.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarInstallmentVoucher.Name = "BarInstallmentVoucher"
        '
        'BarButtonRecCalculate
        '
        resources.ApplyResources(Me.BarButtonRecCalculate, "BarButtonRecCalculate")
        Me.BarButtonRecCalculate.Id = 34
        Me.BarButtonRecCalculate.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonRecCalculate.Name = "BarButtonRecCalculate"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        resources.ApplyResources(Me.BarSubItem2, "BarSubItem2")
        Me.BarSubItem2.Id = 1
        Me.BarSubItem2.ImageOptions.Image = CType(resources.GetObject("BarSubItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem2.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.BarPrintClaims)})
        Me.BarSubItem2.Name = "BarSubItem2"
        Me.BarSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonItem1
        '
        resources.ApplyResources(Me.BarButtonItem1, "BarButtonItem1")
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        resources.ApplyResources(Me.BarButtonItem2, "BarButtonItem2")
        Me.BarButtonItem2.Id = 3
        Me.BarButtonItem2.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        resources.ApplyResources(Me.BarButtonItem3, "BarButtonItem3")
        Me.BarButtonItem3.Id = 4
        Me.BarButtonItem3.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem4
        '
        resources.ApplyResources(Me.BarButtonItem4, "BarButtonItem4")
        Me.BarButtonItem4.Id = 5
        Me.BarButtonItem4.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'BarPrintClaims
        '
        resources.ApplyResources(Me.BarPrintClaims, "BarPrintClaims")
        Me.BarPrintClaims.Id = 20
        Me.BarPrintClaims.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarPrintClaims.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem9), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem10)})
        Me.BarPrintClaims.Name = "BarPrintClaims"
        '
        'BarButtonItem9
        '
        resources.ApplyResources(Me.BarButtonItem9, "BarButtonItem9")
        Me.BarButtonItem9.Id = 21
        Me.BarButtonItem9.Name = "BarButtonItem9"
        '
        'BarButtonItem10
        '
        resources.ApplyResources(Me.BarButtonItem10, "BarButtonItem10")
        Me.BarButtonItem10.Id = 22
        Me.BarButtonItem10.Name = "BarButtonItem10"
        '
        'BarSubItem4
        '
        Me.BarSubItem4.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        resources.ApplyResources(Me.BarSubItem4, "BarSubItem4")
        Me.BarSubItem4.Id = 11
        Me.BarSubItem4.ImageOptions.Image = CType(resources.GetObject("BarSubItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem4.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem5), New DevExpress.XtraBars.LinkPersistInfo(Me.BarShowTasdeedColumns)})
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'BarButtonItem5
        '
        resources.ApplyResources(Me.BarButtonItem5, "BarButtonItem5")
        Me.BarButtonItem5.Id = 12
        Me.BarButtonItem5.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarButtonItem5.Name = "BarButtonItem5"
        '
        'BarShowTasdeedColumns
        '
        resources.ApplyResources(Me.BarShowTasdeedColumns, "BarShowTasdeedColumns")
        Me.BarShowTasdeedColumns.Id = 25
        Me.BarShowTasdeedColumns.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.check_16
        Me.BarShowTasdeedColumns.Name = "BarShowTasdeedColumns"
        '
        'BarShare
        '
        Me.BarShare.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        resources.ApplyResources(Me.BarShare, "BarShare")
        Me.BarShare.Id = 26
        Me.BarShare.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.whatsapp_16
        Me.BarShare.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSendDocumentsByWhatsApp), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonSendToShalash)})
        Me.BarShare.Name = "BarShare"
        Me.BarShare.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        '
        'BarSendDocumentsByWhatsApp
        '
        resources.ApplyResources(Me.BarSendDocumentsByWhatsApp, "BarSendDocumentsByWhatsApp")
        Me.BarSendDocumentsByWhatsApp.Id = 27
        Me.BarSendDocumentsByWhatsApp.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.whatsapp_16
        Me.BarSendDocumentsByWhatsApp.Name = "BarSendDocumentsByWhatsApp"
        '
        'BarButtonSendToShalash
        '
        resources.ApplyResources(Me.BarButtonSendToShalash, "BarButtonSendToShalash")
        Me.BarButtonSendToShalash.Id = 32
        Me.BarButtonSendToShalash.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.share_16
        Me.BarButtonSendToShalash.Name = "BarButtonSendToShalash"
        Me.BarButtonSendToShalash.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        '
        'BarButtonItem8
        '
        Me.BarButtonItem8.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        resources.ApplyResources(Me.BarButtonItem8, "BarButtonItem8")
        Me.BarButtonItem8.Id = 18
        Me.BarButtonItem8.ImageOptions.Image = CType(resources.GetObject("BarButtonItem8.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem8.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem8.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem8.Name = "BarButtonItem8"
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
        'BarSubItem5
        '
        resources.ApplyResources(Me.BarSubItem5, "BarSubItem5")
        Me.BarSubItem5.Id = 13
        Me.BarSubItem5.ImageOptions.Image = CType(resources.GetObject("BarSubItem5.ImageOptions.Image"), System.Drawing.Image)
        Me.BarSubItem5.ImageOptions.LargeImage = CType(resources.GetObject("BarSubItem5.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarSubItem5.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem7)})
        Me.BarSubItem5.Name = "BarSubItem5"
        Me.BarSubItem5.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonItem7
        '
        resources.ApplyResources(Me.BarButtonItem7, "BarButtonItem7")
        Me.BarButtonItem7.Id = 14
        Me.BarButtonItem7.Name = "BarButtonItem7"
        '
        'BarEditItem1
        '
        resources.ApplyResources(Me.BarEditItem1, "BarEditItem1")
        Me.BarEditItem1.Edit = Me.RepositoryItemCheckEdit2
        Me.BarEditItem1.Id = 15
        Me.BarEditItem1.Name = "BarEditItem1"
        '
        'BarEditItem2
        '
        resources.ApplyResources(Me.BarEditItem2, "BarEditItem2")
        Me.BarEditItem2.Edit = Me.RepositoryItemLookUpEdit2
        Me.BarEditItem2.Id = 16
        Me.BarEditItem2.Name = "BarEditItem2"
        '
        'RepositoryItemLookUpEdit2
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit2, "RepositoryItemLookUpEdit2")
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit2.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("18fcf09a-ec05-488e-b2f5-3c5c433f5b25")
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(228, 200)
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl2.Controls.Add(Me.DateEditTo)
        Me.LayoutControl2.Controls.Add(Me.DateEditFrom)
        Me.LayoutControl2.Controls.Add(Me.chkShowDletedDocuments)
        Me.LayoutControl2.Controls.Add(Me.CheckShowCurrencyDetails)
        Me.LayoutControl2.Controls.Add(Me.MultiCurrencyCheck)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl2.Controls.Add(Me.TextEditDocName)
        Me.LayoutControl2.Controls.Add(Me.SimpleButtonAddNewDoc)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        resources.ApplyResources(Me.LayoutControl2, "LayoutControl2")
        Me.LayoutControl2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem10, Me.LayoutControlItem11})
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1189, 338, 650, 400)
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        '
        'RadioGroup1
        '
        resources.ApplyResources(Me.RadioGroup1, "RadioGroup1")
        Me.RadioGroup1.MenuManager = Me.BarManager1
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Columns = 1
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items"), resources.GetString("RadioGroup1.Properties.Items1")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items2"), resources.GetString("RadioGroup1.Properties.Items3")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items4"), resources.GetString("RadioGroup1.Properties.Items5"))})
        Me.RadioGroup1.StyleController = Me.LayoutControl2
        '
        'DateEditTo
        '
        resources.ApplyResources(Me.DateEditTo, "DateEditTo")
        Me.DateEditTo.MenuManager = Me.BarManager1
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditTo.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditTo.StyleController = Me.LayoutControl2
        '
        'DateEditFrom
        '
        resources.ApplyResources(Me.DateEditFrom, "DateEditFrom")
        Me.DateEditFrom.MenuManager = Me.BarManager1
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("DateEditFrom.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.DateEditFrom.StyleController = Me.LayoutControl2
        '
        'chkShowDletedDocuments
        '
        resources.ApplyResources(Me.chkShowDletedDocuments, "chkShowDletedDocuments")
        Me.chkShowDletedDocuments.MenuManager = Me.BarManager1
        Me.chkShowDletedDocuments.Name = "chkShowDletedDocuments"
        Me.chkShowDletedDocuments.Properties.Caption = resources.GetString("chkShowDletedDocuments.Properties.Caption")
        Me.chkShowDletedDocuments.StyleController = Me.LayoutControl2
        '
        'CheckShowCurrencyDetails
        '
        resources.ApplyResources(Me.CheckShowCurrencyDetails, "CheckShowCurrencyDetails")
        Me.CheckShowCurrencyDetails.Name = "CheckShowCurrencyDetails"
        Me.CheckShowCurrencyDetails.Properties.Caption = resources.GetString("CheckShowCurrencyDetails.Properties.Caption")
        Me.CheckShowCurrencyDetails.StyleController = Me.LayoutControl2
        '
        'MultiCurrencyCheck
        '
        resources.ApplyResources(Me.MultiCurrencyCheck, "MultiCurrencyCheck")
        Me.MultiCurrencyCheck.Name = "MultiCurrencyCheck"
        Me.MultiCurrencyCheck.StyleController = Me.LayoutControl2
        '
        'SimpleButton3
        '
        resources.ApplyResources(Me.SimpleButton3, "SimpleButton3")
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.StyleController = Me.LayoutControl2
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me.SimpleButton2, "SimpleButton2")
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.StyleController = Me.LayoutControl2
        '
        'TextEditDocName
        '
        resources.ApplyResources(Me.TextEditDocName, "TextEditDocName")
        Me.TextEditDocName.Name = "TextEditDocName"
        Me.TextEditDocName.Properties.ReadOnly = True
        Me.TextEditDocName.StyleController = Me.LayoutControl2
        '
        'SimpleButtonAddNewDoc
        '
        Me.SimpleButtonAddNewDoc.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButtonAddNewDoc.Appearance.Options.UseBackColor = True
        Me.SimpleButtonAddNewDoc.ImageOptions.Image = CType(resources.GetObject("SimpleButtonAddNewDoc.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButtonAddNewDoc, "SimpleButtonAddNewDoc")
        Me.SimpleButtonAddNewDoc.Name = "SimpleButtonAddNewDoc"
        Me.SimpleButtonAddNewDoc.StyleController = Me.LayoutControl2
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.MultiCurrencyCheck
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 511)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TextEditDocName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 535)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(173, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton3
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(202, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.DateEditFrom
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 57)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(229, 36)
        resources.ApplyResources(Me.LayoutControlItem10, "LayoutControlItem10")
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(20, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.DateEditTo
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 57)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(229, 36)
        resources.ApplyResources(Me.LayoutControlItem11, "LayoutControlItem11")
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(20, 13)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem4, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem13})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(221, 492)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 167)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(195, 197)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SimpleButton2
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 432)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(195, 34)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 398)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(195, 34)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButtonAddNewDoc
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 364)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(195, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CheckShowCurrencyDetails
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 111)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(195, 28)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.chkShowDletedDocuments
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 139)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(195, 28)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.RadioGroup1
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(0, 111)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(54, 111)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(195, 111)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        resources.ApplyResources(Me.LayoutControlItem13, "LayoutControlItem13")
        Me.LayoutControlItem13.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(60, 13)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1185, 533)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1159, 507)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'HtmlTemplateCollection1
        '
        Me.HtmlTemplateCollection1.AddRange(New DevExpress.Utils.Html.HtmlTemplate() {Me.HtmlTemplate1})
        '
        'HtmlTemplate1
        '
        Me.HtmlTemplate1.Name = "HtmlTemplate1"
        resources.ApplyResources(Me.HtmlTemplate1, "HtmlTemplate1")
        '
        'MoneyTransList
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "MoneyTransList"
        CType(Me.RepositoryOrdersStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEditDocStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDebitAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryReferance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryMemoNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryOpenDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryMemoReferanceName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryRefNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemPaidStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowDletedDocuments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowCurrencyDetails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MultiCurrencyCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditDocName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButtonAddNewDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocNameText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocSort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDebitAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCredAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReferance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDebitAcc As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryReferance As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColDocName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextEditDocName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColBaseCurrAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents MultiCurrencyCheck As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryOpenDoc As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryMemoNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColReferanceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryMemoReferanceName As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColDocManualNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryOrdersStatus As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReferanceCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDocID As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents ColReferanceNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSalesMan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocStatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEditDocStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColStockID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocID2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckShowCurrencyDetails As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColExchangePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonSendAccrualVoucherSMS As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemReceiveMoney As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem5 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem5 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem7 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryRefNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents BarEditItem2 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarEditItem1 As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BarButtonItem6 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ColPaidAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaidStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItem8 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarPrintClaims As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem9 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem10 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents chkShowDletedDocuments As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemPaidStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BarPaidVoucher As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarUnPaidVoucher As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColRemainAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarShowTasdeedColumns As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarShare As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSendDocumentsByWhatsApp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocTags As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHypertextLabel1 As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel
    Friend WithEvents HtmlTemplateCollection1 As DevExpress.Utils.Html.HtmlTemplateCollection
    Friend WithEvents HtmlTemplate1 As DevExpress.Utils.Html.HtmlTemplate
    Friend WithEvents RepositoryItemTags As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BarButtonSendToShalash As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ColCostName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarInstallmentVoucher As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ColStockDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColVoucherDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonRecCalculate As DevExpress.XtraBars.BarButtonItem
End Class
