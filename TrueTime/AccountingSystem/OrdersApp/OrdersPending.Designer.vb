<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrdersPending
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
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrdersPending))
        Dim EditorButtonImageOptions3 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.ColOrderStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocNameText = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeliverDate = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.ColDeviceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnInputDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColInputUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryInputUser = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.EmployeesData1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SearchLookDocStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextSeconds = New DevExpress.XtraEditors.TextEdit()
        Me.CheckAutoCheck = New DevExpress.XtraEditors.CheckEdit()
        Me.SearchDocNames = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Colid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutStatus = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.EmployeesData1TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDebitAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryReferance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryMemoNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryOpenDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryMemoReferanceName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryInputUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.SearchLookDocStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSeconds.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckAutoCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchDocNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColOrderStatus
        '
        Me.ColOrderStatus.AppearanceCell.Options.UseTextOptions = True
        Me.ColOrderStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColOrderStatus.Caption = "حالة السند"
        Me.ColOrderStatus.FieldName = "OrderStatus"
        Me.ColOrderStatus.MinWidth = 17
        Me.ColOrderStatus.Name = "ColOrderStatus"
        Me.ColOrderStatus.OptionsColumn.AllowEdit = False
        Me.ColOrderStatus.OptionsColumn.ReadOnly = True
        Me.ColOrderStatus.Visible = True
        Me.ColOrderStatus.VisibleIndex = 7
        Me.ColOrderStatus.Width = 51
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(246, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(931, 514)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(2)
        Me.GridControl1.Location = New System.Drawing.Point(16, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryDebitAcc, Me.RepositoryReferance, Me.RepositoryOpenDoc, Me.RepositoryMemoNote, Me.RepositoryMemoReferanceName, Me.RepositoryInputUser})
        Me.GridControl1.Size = New System.Drawing.Size(899, 482)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColDocID, Me.ColDocNameText, Me.ColDocDate, Me.ColDeliverDate, Me.ColCredAcc, Me.ColReferance, Me.ColDocCurrency, Me.ColDocAmount, Me.ColBaseCurrAmount, Me.ColDocNotes, Me.ColDocSort, Me.ColDebitAcc, Me.ColDocName, Me.GridColumn1, Me.ColReferanceName, Me.ColDeviceName, Me.ColDocCode, Me.ColOrderStatus, Me.GridColumnInputDateTime, Me.ColInputUser})
        GridFormatRule1.Column = Me.ColOrderStatus
        GridFormatRule1.ColumnApplyTo = Me.ColOrderStatus
        GridFormatRule1.Description = Nothing
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.PredefinedName = "Red Text"
        FormatConditionRuleValue1.Value1 = "مفوترة"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColDocID
        '
        Me.ColDocID.Caption = "رقم"
        Me.ColDocID.FieldName = "DocID"
        Me.ColDocID.MinWidth = 17
        Me.ColDocID.Name = "ColDocID"
        Me.ColDocID.OptionsColumn.AllowEdit = False
        Me.ColDocID.OptionsColumn.ReadOnly = True
        Me.ColDocID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocID", "{0}")})
        Me.ColDocID.Visible = True
        Me.ColDocID.VisibleIndex = 0
        Me.ColDocID.Width = 60
        '
        'ColDocNameText
        '
        Me.ColDocNameText.Caption = "السند"
        Me.ColDocNameText.FieldName = "DocNameText"
        Me.ColDocNameText.MinWidth = 86
        Me.ColDocNameText.Name = "ColDocNameText"
        Me.ColDocNameText.OptionsColumn.AllowEdit = False
        Me.ColDocNameText.OptionsColumn.ReadOnly = True
        Me.ColDocNameText.Visible = True
        Me.ColDocNameText.VisibleIndex = 1
        Me.ColDocNameText.Width = 86
        '
        'ColDocDate
        '
        Me.ColDocDate.Caption = "التاريخ"
        Me.ColDocDate.FieldName = "DocDate"
        Me.ColDocDate.MinWidth = 64
        Me.ColDocDate.Name = "ColDocDate"
        Me.ColDocDate.OptionsColumn.AllowEdit = False
        Me.ColDocDate.OptionsColumn.FixedWidth = True
        Me.ColDocDate.OptionsColumn.ReadOnly = True
        Me.ColDocDate.Visible = True
        Me.ColDocDate.VisibleIndex = 2
        Me.ColDocDate.Width = 90
        '
        'ColDeliverDate
        '
        Me.ColDeliverDate.Caption = "تاريخ التسليم"
        Me.ColDeliverDate.FieldName = "DeliverDate"
        Me.ColDeliverDate.Name = "ColDeliverDate"
        Me.ColDeliverDate.OptionsColumn.AllowEdit = False
        Me.ColDeliverDate.OptionsColumn.FixedWidth = True
        Me.ColDeliverDate.OptionsColumn.ReadOnly = True
        Me.ColDeliverDate.Visible = True
        Me.ColDeliverDate.VisibleIndex = 3
        Me.ColDeliverDate.Width = 90
        '
        'ColCredAcc
        '
        Me.ColCredAcc.Caption = "الحساب"
        Me.ColCredAcc.ColumnEdit = Me.RepositoryDebitAcc
        Me.ColCredAcc.FieldName = "Account"
        Me.ColCredAcc.Name = "ColCredAcc"
        Me.ColCredAcc.OptionsColumn.AllowEdit = False
        Me.ColCredAcc.OptionsColumn.ReadOnly = True
        Me.ColCredAcc.Width = 130
        '
        'RepositoryDebitAcc
        '
        Me.RepositoryDebitAcc.AutoHeight = False
        Me.RepositoryDebitAcc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryDebitAcc.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccNo", "رقم"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccName", "الحساب")})
        Me.RepositoryDebitAcc.DisplayMember = "AccName"
        Me.RepositoryDebitAcc.Name = "RepositoryDebitAcc"
        Me.RepositoryDebitAcc.NullText = ""
        Me.RepositoryDebitAcc.ValueMember = "AccNo"
        '
        'ColReferance
        '
        Me.ColReferance.Caption = "المرجع"
        Me.ColReferance.ColumnEdit = Me.RepositoryReferance
        Me.ColReferance.FieldName = "Referance"
        Me.ColReferance.Name = "ColReferance"
        Me.ColReferance.OptionsColumn.AllowEdit = False
        Me.ColReferance.OptionsColumn.ReadOnly = True
        Me.ColReferance.Visible = True
        Me.ColReferance.VisibleIndex = 5
        Me.ColReferance.Width = 105
        '
        'RepositoryReferance
        '
        Me.RepositoryReferance.AutoHeight = False
        Me.RepositoryReferance.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryReferance.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RefNo", "رقم"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("RefName", "الاسم")})
        Me.RepositoryReferance.DisplayMember = "RefName"
        Me.RepositoryReferance.Name = "RepositoryReferance"
        Me.RepositoryReferance.NullText = ""
        Me.RepositoryReferance.ValueMember = "RefNo"
        '
        'ColDocCurrency
        '
        Me.ColDocCurrency.Caption = "العملة"
        Me.ColDocCurrency.FieldName = "DocCurrency"
        Me.ColDocCurrency.ImageOptions.Alignment = System.Drawing.StringAlignment.Center
        Me.ColDocCurrency.ImageOptions.Image = CType(resources.GetObject("ColDocCurrency.ImageOptions.Image"), System.Drawing.Image)
        Me.ColDocCurrency.MaxWidth = 80
        Me.ColDocCurrency.Name = "ColDocCurrency"
        Me.ColDocCurrency.OptionsColumn.AllowEdit = False
        Me.ColDocCurrency.OptionsColumn.ReadOnly = True
        Me.ColDocCurrency.Width = 56
        '
        'ColDocAmount
        '
        Me.ColDocAmount.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColDocAmount.AppearanceHeader.Options.UseImage = True
        Me.ColDocAmount.Caption = "المبلغ"
        Me.ColDocAmount.DisplayFormat.FormatString = "n2"
        Me.ColDocAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDocAmount.FieldName = "DocAmount"
        Me.ColDocAmount.MaxWidth = 120
        Me.ColDocAmount.Name = "ColDocAmount"
        Me.ColDocAmount.OptionsColumn.AllowEdit = False
        Me.ColDocAmount.OptionsColumn.ReadOnly = True
        Me.ColDocAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DocAmount", "{0:0.##}")})
        Me.ColDocAmount.Visible = True
        Me.ColDocAmount.VisibleIndex = 6
        Me.ColDocAmount.Width = 77
        '
        'ColBaseCurrAmount
        '
        Me.ColBaseCurrAmount.Caption = "بالعملة الرئيسية"
        Me.ColBaseCurrAmount.DisplayFormat.FormatString = "n2"
        Me.ColBaseCurrAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColBaseCurrAmount.FieldName = "BaseCurrAmount"
        Me.ColBaseCurrAmount.MinWidth = 17
        Me.ColBaseCurrAmount.Name = "ColBaseCurrAmount"
        Me.ColBaseCurrAmount.OptionsColumn.AllowEdit = False
        Me.ColBaseCurrAmount.OptionsColumn.ReadOnly = True
        Me.ColBaseCurrAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BaseAmount", "{0:0.##}")})
        Me.ColBaseCurrAmount.Width = 69
        '
        'ColDocNotes
        '
        Me.ColDocNotes.AppearanceCell.Options.UseTextOptions = True
        Me.ColDocNotes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColDocNotes.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.ColDocNotes.Caption = "ملاحظات"
        Me.ColDocNotes.ColumnEdit = Me.RepositoryMemoNote
        Me.ColDocNotes.FieldName = "DocNotes"
        Me.ColDocNotes.MinWidth = 17
        Me.ColDocNotes.Name = "ColDocNotes"
        Me.ColDocNotes.OptionsColumn.AllowEdit = False
        Me.ColDocNotes.OptionsColumn.ReadOnly = True
        Me.ColDocNotes.Visible = True
        Me.ColDocNotes.VisibleIndex = 8
        Me.ColDocNotes.Width = 78
        '
        'RepositoryMemoNote
        '
        Me.RepositoryMemoNote.Appearance.Options.UseTextOptions = True
        Me.RepositoryMemoNote.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryMemoNote.Name = "RepositoryMemoNote"
        '
        'ColDocSort
        '
        Me.ColDocSort.Caption = "التصنيف"
        Me.ColDocSort.FieldName = "DocSort"
        Me.ColDocSort.Name = "ColDocSort"
        Me.ColDocSort.OptionsColumn.AllowEdit = False
        Me.ColDocSort.OptionsColumn.ReadOnly = True
        '
        'ColDebitAcc
        '
        Me.ColDebitAcc.Caption = "الحساب المدين"
        Me.ColDebitAcc.ColumnEdit = Me.RepositoryDebitAcc
        Me.ColDebitAcc.FieldName = "DebitAcc"
        Me.ColDebitAcc.Name = "ColDebitAcc"
        Me.ColDebitAcc.OptionsColumn.AllowEdit = False
        Me.ColDebitAcc.OptionsColumn.ReadOnly = True
        '
        'ColDocName
        '
        Me.ColDocName.Caption = "السند"
        Me.ColDocName.FieldName = "DocName"
        Me.ColDocName.Name = "ColDocName"
        Me.ColDocName.OptionsColumn.AllowEdit = False
        Me.ColDocName.OptionsColumn.ReadOnly = True
        '
        'GridColumn1
        '
        Me.GridColumn1.ColumnEdit = Me.RepositoryOpenDoc
        Me.GridColumn1.MaxWidth = 64
        Me.GridColumn1.MinWidth = 17
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 9
        Me.GridColumn1.Width = 64
        '
        'RepositoryOpenDoc
        '
        Me.RepositoryOpenDoc.AutoHeight = False
        EditorButtonImageOptions3.SvgImage = CType(resources.GetObject("EditorButtonImageOptions3.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.RepositoryOpenDoc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions3, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryOpenDoc.Name = "RepositoryOpenDoc"
        Me.RepositoryOpenDoc.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'ColReferanceName
        '
        Me.ColReferanceName.AppearanceCell.Options.UseTextOptions = True
        Me.ColReferanceName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColReferanceName.Caption = "الدمة"
        Me.ColReferanceName.ColumnEdit = Me.RepositoryMemoReferanceName
        Me.ColReferanceName.FieldName = "ReferanceName"
        Me.ColReferanceName.MinWidth = 17
        Me.ColReferanceName.Name = "ColReferanceName"
        Me.ColReferanceName.OptionsColumn.ReadOnly = True
        Me.ColReferanceName.Width = 68
        '
        'RepositoryMemoReferanceName
        '
        Me.RepositoryMemoReferanceName.Appearance.Options.UseTextOptions = True
        Me.RepositoryMemoReferanceName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.RepositoryMemoReferanceName.Name = "RepositoryMemoReferanceName"
        '
        'ColDeviceName
        '
        Me.ColDeviceName.Caption = "الجهاز"
        Me.ColDeviceName.FieldName = "DeviceName"
        Me.ColDeviceName.MinWidth = 17
        Me.ColDeviceName.Name = "ColDeviceName"
        Me.ColDeviceName.OptionsColumn.AllowEdit = False
        Me.ColDeviceName.OptionsColumn.ReadOnly = True
        Me.ColDeviceName.Width = 51
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "كود الطلبية"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MinWidth = 17
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.OptionsColumn.AllowEdit = False
        Me.ColDocCode.OptionsColumn.ReadOnly = True
        Me.ColDocCode.Width = 51
        '
        'GridColumnInputDateTime
        '
        Me.GridColumnInputDateTime.Caption = "الوقت"
        Me.GridColumnInputDateTime.DisplayFormat.FormatString = "HH:mm"
        Me.GridColumnInputDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnInputDateTime.FieldName = "InputDateTime"
        Me.GridColumnInputDateTime.MinWidth = 17
        Me.GridColumnInputDateTime.Name = "GridColumnInputDateTime"
        Me.GridColumnInputDateTime.OptionsColumn.AllowEdit = False
        Me.GridColumnInputDateTime.OptionsColumn.ReadOnly = True
        Me.GridColumnInputDateTime.Width = 64
        '
        'ColInputUser
        '
        Me.ColInputUser.Caption = "المندوب"
        Me.ColInputUser.ColumnEdit = Me.RepositoryInputUser
        Me.ColInputUser.FieldName = "InputUser"
        Me.ColInputUser.Name = "ColInputUser"
        Me.ColInputUser.OptionsColumn.AllowEdit = False
        Me.ColInputUser.OptionsColumn.ReadOnly = True
        Me.ColInputUser.Visible = True
        Me.ColInputUser.VisibleIndex = 4
        Me.ColInputUser.Width = 64
        '
        'RepositoryInputUser
        '
        Me.RepositoryInputUser.AutoHeight = False
        Me.RepositoryInputUser.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryInputUser.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeID", "EmployeeID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeName", "EmployeeName")})
        Me.RepositoryInputUser.DataSource = Me.EmployeesData1BindingSource
        Me.RepositoryInputUser.DisplayMember = "EmployeeName"
        Me.RepositoryInputUser.Name = "RepositoryInputUser"
        Me.RepositoryInputUser.NullText = ""
        Me.RepositoryInputUser.ValueMember = "EmployeeID"
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
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(931, 514)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(905, 488)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
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
        Me.DockPanel1.ID = New System.Guid("2a954660-f33c-4b00-9353-742a9d24106d")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Options.ShowCloseButton = False
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(246, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(246, 514)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 38)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(239, 473)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.SearchLookDocStatus)
        Me.LayoutControl2.Controls.Add(Me.TextSeconds)
        Me.LayoutControl2.Controls.Add(Me.CheckAutoCheck)
        Me.LayoutControl2.Controls.Add(Me.SearchDocNames)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem2})
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(526, 281, 650, 400)
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(239, 473)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'SearchLookDocStatus
        '
        Me.SearchLookDocStatus.Location = New System.Drawing.Point(16, 50)
        Me.SearchLookDocStatus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SearchLookDocStatus.Name = "SearchLookDocStatus"
        Me.SearchLookDocStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookDocStatus.Properties.DisplayMember = "StatusName"
        Me.SearchLookDocStatus.Properties.NullText = ""
        Me.SearchLookDocStatus.Properties.PopupView = Me.GridView2
        Me.SearchLookDocStatus.Properties.ValueMember = "ID"
        Me.SearchLookDocStatus.Size = New System.Drawing.Size(141, 28)
        Me.SearchLookDocStatus.StyleController = Me.LayoutControl2
        Me.SearchLookDocStatus.TabIndex = 9
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnStatusName})
        Me.GridView2.DetailHeight = 284
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "ID"
        Me.GridColumnID.MinWidth = 17
        Me.GridColumnID.Name = "GridColumnID"
        Me.GridColumnID.Width = 64
        '
        'GridColumnStatusName
        '
        Me.GridColumnStatusName.Caption = "حالة السند"
        Me.GridColumnStatusName.FieldName = "StatusName"
        Me.GridColumnStatusName.MinWidth = 17
        Me.GridColumnStatusName.Name = "GridColumnStatusName"
        Me.GridColumnStatusName.Visible = True
        Me.GridColumnStatusName.VisibleIndex = 0
        Me.GridColumnStatusName.Width = 64
        '
        'TextSeconds
        '
        Me.TextSeconds.Location = New System.Drawing.Point(10, 50)
        Me.TextSeconds.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextSeconds.Name = "TextSeconds"
        Me.TextSeconds.Size = New System.Drawing.Size(184, 28)
        Me.TextSeconds.StyleController = Me.LayoutControl2
        Me.TextSeconds.TabIndex = 8
        '
        'CheckAutoCheck
        '
        Me.CheckAutoCheck.Location = New System.Drawing.Point(10, 52)
        Me.CheckAutoCheck.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CheckAutoCheck.Name = "CheckAutoCheck"
        Me.CheckAutoCheck.Properties.Caption = "تحديث تلقائي"
        Me.CheckAutoCheck.Size = New System.Drawing.Size(184, 22)
        Me.CheckAutoCheck.StyleController = Me.LayoutControl2
        Me.CheckAutoCheck.TabIndex = 7
        '
        'SearchDocNames
        '
        Me.SearchDocNames.EditValue = ""
        Me.SearchDocNames.Location = New System.Drawing.Point(16, 16)
        Me.SearchDocNames.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SearchDocNames.Name = "SearchDocNames"
        Me.SearchDocNames.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchDocNames.Properties.DisplayMember = "Name"
        Me.SearchDocNames.Properties.NullText = ""
        Me.SearchDocNames.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchDocNames.Properties.ValueMember = "id"
        Me.SearchDocNames.Size = New System.Drawing.Size(141, 28)
        Me.SearchDocNames.StyleController = Me.LayoutControl2
        Me.SearchDocNames.TabIndex = 6
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Colid, Me.ColName})
        Me.SearchLookUpEdit1View.DetailHeight = 284
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        Me.SearchLookUpEdit1View.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Colid, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'Colid
        '
        Me.Colid.Caption = "id"
        Me.Colid.FieldName = "id"
        Me.Colid.MinWidth = 17
        Me.Colid.Name = "Colid"
        Me.Colid.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value
        Me.Colid.Width = 64
        '
        'ColName
        '
        Me.ColName.Caption = "السند"
        Me.ColName.FieldName = "Name"
        Me.ColName.MinWidth = 17
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 0
        Me.ColName.Width = 64
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 429)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(207, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "تحديث    F5"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TextSeconds
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(219, 26)
        Me.LayoutControlItem5.Text = "عدد الثواني "
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CheckAutoCheck
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(219, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutStatus})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(239, 473)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 68)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(213, 345)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 413)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(213, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SearchDocNames
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(213, 34)
        Me.LayoutControlItem4.Text = "السند"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutStatus
        '
        Me.LayoutStatus.Control = Me.SearchLookDocStatus
        Me.LayoutStatus.Location = New System.Drawing.Point(0, 34)
        Me.LayoutStatus.Name = "LayoutStatus"
        Me.LayoutStatus.Size = New System.Drawing.Size(213, 34)
        Me.LayoutStatus.Text = "حالة السند"
        Me.LayoutStatus.TextSize = New System.Drawing.Size(50, 13)
        '
        'Timer1
        '
        '
        'EmployeesData1TableAdapter
        '
        Me.EmployeesData1TableAdapter.ClearBeforeFill = True
        '
        'OrdersPending
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 514)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "OrdersPending"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "قائمة السندات من نظام الطلبيات"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDebitAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryReferance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryMemoNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryOpenDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryMemoReferanceName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryInputUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.SearchLookDocStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSeconds.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckAutoCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchDocNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocNameText As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCredAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDebitAcc As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColReferance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryReferance As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColBaseCurrAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryMemoNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColDocSort As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDebitAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryOpenDoc As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColReferanceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryMemoReferanceName As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchDocNames As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Colid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeviceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOrderStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnInputDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckAutoCheck As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextSeconds As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchLookDocStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutStatus As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColInputUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryInputUser As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesData1BindingSource As BindingSource
    Friend WithEvents EmployeesData1TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter
    Friend WithEvents ColDeliverDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
