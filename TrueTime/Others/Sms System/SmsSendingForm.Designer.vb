<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmsSendingForm
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
        Dim GridFormatRule2 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue2 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SmsSendingForm))
        Me.ColSMSStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemMemoEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefMobile = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSMSDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccrualDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryActions = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDelete = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButtonSendSms = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.RadioGroupSendType = New DevExpress.XtraEditors.RadioGroup()
        Me.TextBalanceAfterSend = New DevExpress.XtraEditors.TextEdit()
        Me.TextBalanceBeforeSend = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.BarResponse = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryActions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.RadioGroupSendType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBalanceAfterSend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBalanceBeforeSend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColSMSStatus
        '
        Me.ColSMSStatus.Caption = "الحالة"
        Me.ColSMSStatus.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ColSMSStatus.FieldName = "SMSStatus"
        Me.ColSMSStatus.Name = "ColSMSStatus"
        Me.ColSMSStatus.OptionsColumn.AllowEdit = False
        Me.ColSMSStatus.Visible = True
        Me.ColSMSStatus.VisibleIndex = 5
        Me.ColSMSStatus.Width = 129
        '
        'RepositoryItemMemoEdit1
        '
        Me.RepositoryItemMemoEdit1.Name = "RepositoryItemMemoEdit1"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(16, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemMemoEdit1, Me.RepositoryActions, Me.RepositoryDelete})
        Me.GridControl1.Size = New System.Drawing.Size(1013, 318)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefNo, Me.ColRefName, Me.ColRefMobile, Me.ColSMSDetails, Me.ColSMSStatus, Me.ColAccrualDateTime, Me.ColAction, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        GridFormatRule1.Column = Me.ColSMSStatus
        GridFormatRule1.ColumnApplyTo = Me.ColSMSStatus
        GridFormatRule1.Description = Nothing
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.[True]
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.PredefinedName = "Green Fill"
        FormatConditionRuleValue1.Value1 = "Success"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        GridFormatRule2.Column = Me.ColSMSStatus
        GridFormatRule2.ColumnApplyTo = Me.ColSMSStatus
        GridFormatRule2.Description = Nothing
        GridFormatRule2.Name = "Format1"
        FormatConditionRuleValue2.AllowAnimation = DevExpress.Utils.DefaultBoolean.[True]
        FormatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual
        FormatConditionRuleValue2.PredefinedName = "Red Fill"
        FormatConditionRuleValue2.Value1 = "Success"
        GridFormatRule2.Rule = FormatConditionRuleValue2
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.FormatRules.Add(GridFormatRule2)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.IndicatorWidth = 50
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم الذمة"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.OptionsColumn.AllowEdit = False
        Me.ColRefNo.Width = 86
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "الاسم"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.OptionsColumn.AllowEdit = False
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 0
        Me.ColRefName.Width = 133
        '
        'ColRefMobile
        '
        Me.ColRefMobile.Caption = "رقم الموبايل"
        Me.ColRefMobile.FieldName = "RefMobile"
        Me.ColRefMobile.Name = "ColRefMobile"
        Me.ColRefMobile.Visible = True
        Me.ColRefMobile.VisibleIndex = 1
        Me.ColRefMobile.Width = 114
        '
        'ColSMSDetails
        '
        Me.ColSMSDetails.Caption = "الرسالة"
        Me.ColSMSDetails.ColumnEdit = Me.RepositoryItemMemoEdit1
        Me.ColSMSDetails.FieldName = "SMSDetails"
        Me.ColSMSDetails.Name = "ColSMSDetails"
        Me.ColSMSDetails.Visible = True
        Me.ColSMSDetails.VisibleIndex = 3
        Me.ColSMSDetails.Width = 118
        '
        'ColAccrualDateTime
        '
        Me.ColAccrualDateTime.Caption = "استحقاق المسج"
        Me.ColAccrualDateTime.FieldName = "AccrualDateTime"
        Me.ColAccrualDateTime.Name = "ColAccrualDateTime"
        Me.ColAccrualDateTime.OptionsColumn.AllowEdit = False
        Me.ColAccrualDateTime.Visible = True
        Me.ColAccrualDateTime.VisibleIndex = 2
        Me.ColAccrualDateTime.Width = 113
        '
        'ColAction
        '
        Me.ColAction.Caption = "الاجراء"
        Me.ColAction.ColumnEdit = Me.RepositoryActions
        Me.ColAction.FieldName = "Action"
        Me.ColAction.Name = "ColAction"
        Me.ColAction.Visible = True
        Me.ColAction.VisibleIndex = 4
        Me.ColAction.Width = 57
        '
        'RepositoryActions
        '
        Me.RepositoryActions.AutoHeight = False
        Me.RepositoryActions.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryActions.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Action", "الاجراء")})
        Me.RepositoryActions.DisplayMember = "Action"
        Me.RepositoryActions.Name = "RepositoryActions"
        Me.RepositoryActions.NullText = ""
        Me.RepositoryActions.ValueMember = "ID"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = " ازالة"
        Me.GridColumn1.ColumnEdit = Me.RepositoryDelete
        Me.GridColumn1.FieldName = "Delete"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 6
        '
        'RepositoryDelete
        '
        Me.RepositoryDelete.AutoHeight = False
        Me.RepositoryDelete.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.RepositoryDelete.Name = "RepositoryDelete"
        Me.RepositoryDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "اسم السند"
        Me.GridColumn2.FieldName = "DocName"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "رقم السند"
        Me.GridColumn3.FieldName = "DocID"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "كود السند"
        Me.GridColumn4.FieldName = "DocCode"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "البيانات"
        Me.GridColumn5.FieldName = "DocData"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "SMSType"
        Me.GridColumn6.FieldName = "SMSType"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "SmsID"
        Me.GridColumn7.FieldName = "SmsID"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'SimpleButtonSendSms
        '
        Me.SimpleButtonSendSms.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButtonSendSms.Appearance.Options.UseBackColor = True
        Me.SimpleButtonSendSms.Location = New System.Drawing.Point(905, 439)
        Me.SimpleButtonSendSms.Name = "SimpleButtonSendSms"
        Me.SimpleButtonSendSms.Size = New System.Drawing.Size(124, 20)
        Me.SimpleButtonSendSms.StyleController = Me.LayoutControl1
        Me.SimpleButtonSendSms.TabIndex = 2
        Me.SimpleButtonSendSms.Text = "موافق"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.RadioGroupSendType)
        Me.LayoutControl1.Controls.Add(Me.TextBalanceAfterSend)
        Me.LayoutControl1.Controls.Add(Me.TextBalanceBeforeSend)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButtonSendSms)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1045, 475)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'RadioGroupSendType
        '
        Me.RadioGroupSendType.EditValue = "SMS"
        Me.RadioGroupSendType.Location = New System.Drawing.Point(16, 340)
        Me.RadioGroupSendType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioGroupSendType.Name = "RadioGroupSendType"
        Me.RadioGroupSendType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("SMS", "SMS"), New DevExpress.XtraEditors.Controls.RadioGroupItem("WhatsApp", "WhatsApp")})
        Me.RadioGroupSendType.Size = New System.Drawing.Size(873, 49)
        Me.RadioGroupSendType.StyleController = Me.LayoutControl1
        Me.RadioGroupSendType.TabIndex = 14
        '
        'TextBalanceAfterSend
        '
        Me.TextBalanceAfterSend.Location = New System.Drawing.Point(16, 395)
        Me.TextBalanceAfterSend.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBalanceAfterSend.Name = "TextBalanceAfterSend"
        Me.TextBalanceAfterSend.Properties.ReadOnly = True
        Me.TextBalanceAfterSend.Size = New System.Drawing.Size(363, 28)
        Me.TextBalanceAfterSend.StyleController = Me.LayoutControl1
        Me.TextBalanceAfterSend.TabIndex = 6
        '
        'TextBalanceBeforeSend
        '
        Me.TextBalanceBeforeSend.Location = New System.Drawing.Point(525, 395)
        Me.TextBalanceBeforeSend.Name = "TextBalanceBeforeSend"
        Me.TextBalanceBeforeSend.Properties.ReadOnly = True
        Me.TextBalanceBeforeSend.Size = New System.Drawing.Size(364, 28)
        Me.TextBalanceBeforeSend.StyleController = Me.LayoutControl1
        Me.TextBalanceBeforeSend.TabIndex = 5
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 439)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(122, 20)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "خروج"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1045, 475)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1019, 324)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButtonSendSms
        Me.LayoutControlItem2.Location = New System.Drawing.Point(889, 423)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(130, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(130, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(130, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(128, 423)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(761, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 413)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1019, 10)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 423)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(128, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(128, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(128, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TextBalanceBeforeSend
        Me.LayoutControlItem4.CustomizationFormText = "رصيد الرسائل قبل عملية الارسال:"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(509, 379)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(510, 34)
        Me.LayoutControlItem4.Text = "رصيد الرسائل قبل الارسال:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(124, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TextBalanceAfterSend
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 379)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(509, 34)
        Me.LayoutControlItem5.Text = "رصيد الرسائل بعد الارسال:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(124, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.RadioGroupSendType
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 324)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(1019, 55)
        Me.LayoutControlItem6.Text = "طريقة الارسال"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(124, 13)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarResponse})
        Me.BarManager1.MaxItemId = 1
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarResponse)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'BarResponse
        '
        Me.BarResponse.Caption = "Response"
        Me.BarResponse.Id = 0
        Me.BarResponse.Name = "BarResponse"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1045, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 475)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1045, 35)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 475)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1045, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 475)
        '
        'SmsSendingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 510)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = CType(resources.GetObject("SmsSendingForm.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "SmsSendingForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مركز ارسال الرسائل"
        CType(Me.RepositoryItemMemoEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryActions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.RadioGroupSendType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBalanceAfterSend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBalanceBeforeSend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefMobile As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSMSDetails As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemMemoEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Friend WithEvents ColSMSStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButtonSendSms As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ColAccrualDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryActions As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDelete As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextBalanceBeforeSend As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextBalanceAfterSend As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RadioGroupSendType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarResponse As DevExpress.XtraBars.BarStaticItem
End Class
