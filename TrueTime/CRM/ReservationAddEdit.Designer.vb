<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservationAddEdit
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReservationAddEdit))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.ReferanceNoSearchLookUpEditView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TheServiceSearchLookUpEditView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colItemNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReferanceNoSearchLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.ReservationAmountTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ReservationDateDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.TheServiceSearchLookUpEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TextRemainAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.ReservationNoteTextEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.ReservationsPaymentGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colPaymentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymentAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colPaymentID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPaymentNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.ReservationStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.DocID = New DevExpress.XtraEditors.TextEdit()
        Me.DocIdquery = New DevExpress.XtraEditors.SpinEdit()
        Me.TextDocDate = New DevExpress.XtraEditors.TextEdit()
        Me.TextNewOld = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PaymentsSum = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ItemsTableAdapter()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferanceNoSearchLookUpEditView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TheServiceSearchLookUpEditView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferanceNoSearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationAmountTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TheServiceSearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRemainAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationNoteTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationsPaymentGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.ReservationStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocIdquery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentsSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountingBranchesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPOSNamesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPosTypesTableAdapter = Nothing
        Me.TableAdapterManager.AppointmentsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTypeTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BankBrancheTableAdapter = Nothing
        Me.TableAdapterManager.BankTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.CRMTaskStatusesTableAdapter = Nothing
        Me.TableAdapterManager.DocNamesTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesAccessTableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccounts1TableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccountsTableAdapter = Nothing
        Me.TableAdapterManager.Items_unitsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsCategoriesTableAdapter = Nothing
        Me.TableAdapterManager.ItemsColorsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsMeasuresTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTradeMarkTableAdapter = Nothing
        Me.TableAdapterManager.PatientsVisitsTableAdapter = Nothing
        Me.TableAdapterManager.PosPaidMethodsTableAdapter = Nothing
        Me.TableAdapterManager.ProductionEquationTableAdapter = Nothing
        Me.TableAdapterManager.RefCitiesTableAdapter = Nothing
        Me.TableAdapterManager.ReferancesListTableAdapter = Nothing
        Me.TableAdapterManager.ReferencessTableAdapter = Nothing
        Me.TableAdapterManager.ReferencesTypesTableAdapter = Nothing
        Me.TableAdapterManager.RefSortsTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsListTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsPaymentTableAdapter = Nothing
        Me.TableAdapterManager.ResourcesTableAdapter = Nothing
        Me.TableAdapterManager.UnitsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.Vehicle_MaintenanceTableAdapter = Nothing
        Me.TableAdapterManager.WarehousesTableAdapter = Nothing
        '
        'ReferanceNoSearchLookUpEditView
        '
        Me.ReferanceNoSearchLookUpEditView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRefNo, Me.colRefName})
        Me.ReferanceNoSearchLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.ReferanceNoSearchLookUpEditView.Name = "ReferanceNoSearchLookUpEditView"
        Me.ReferanceNoSearchLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.ReferanceNoSearchLookUpEditView.OptionsView.ShowGroupPanel = False
        '
        'colRefNo
        '
        Me.colRefNo.FieldName = "RefNo"
        Me.colRefNo.Name = "colRefNo"
        Me.colRefNo.Visible = True
        Me.colRefNo.VisibleIndex = 0
        '
        'colRefName
        '
        Me.colRefName.FieldName = "RefName"
        Me.colRefName.Name = "colRefName"
        Me.colRefName.Visible = True
        Me.colRefName.VisibleIndex = 1
        '
        'TheServiceSearchLookUpEditView
        '
        Me.TheServiceSearchLookUpEditView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colItemNo, Me.colItemName})
        Me.TheServiceSearchLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.TheServiceSearchLookUpEditView.Name = "TheServiceSearchLookUpEditView"
        Me.TheServiceSearchLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.TheServiceSearchLookUpEditView.OptionsView.ShowGroupPanel = False
        '
        'colItemNo
        '
        Me.colItemNo.FieldName = "ItemNo"
        Me.colItemNo.Name = "colItemNo"
        Me.colItemNo.Visible = True
        Me.colItemNo.VisibleIndex = 0
        '
        'colItemName
        '
        Me.colItemName.FieldName = "ItemName"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Visible = True
        Me.colItemName.VisibleIndex = 1
        '
        'ReferanceNoSearchLookUpEdit
        '
        Me.ReferanceNoSearchLookUpEdit.Location = New System.Drawing.Point(318, 64)
        Me.ReferanceNoSearchLookUpEdit.Name = "ReferanceNoSearchLookUpEdit"
        Me.ReferanceNoSearchLookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferanceNoSearchLookUpEdit.Properties.Appearance.Options.UseFont = True
        EditorButtonImageOptions1.SvgImage = CType(resources.GetObject("EditorButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.ReferanceNoSearchLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "اضافة جديد", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", "AddNew", Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.ReferanceNoSearchLookUpEdit.Properties.DisplayMember = "RefName"
        Me.ReferanceNoSearchLookUpEdit.Properties.NullText = ""
        Me.ReferanceNoSearchLookUpEdit.Properties.PopupView = Me.ReferanceNoSearchLookUpEditView
        Me.ReferanceNoSearchLookUpEdit.Properties.ValueMember = "RefNo"
        Me.ReferanceNoSearchLookUpEdit.Size = New System.Drawing.Size(351, 36)
        Me.ReferanceNoSearchLookUpEdit.TabIndex = 6
        '
        'ReservationAmountTextEdit
        '
        Me.ReservationAmountTextEdit.Location = New System.Drawing.Point(471, 147)
        Me.ReservationAmountTextEdit.Name = "ReservationAmountTextEdit"
        Me.ReservationAmountTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationAmountTextEdit.Properties.Appearance.Options.UseFont = True
        Me.ReservationAmountTextEdit.Size = New System.Drawing.Size(198, 36)
        Me.ReservationAmountTextEdit.TabIndex = 8
        '
        'ReservationDateDateEdit
        '
        Me.ReservationDateDateEdit.EditValue = Nothing
        Me.ReservationDateDateEdit.Location = New System.Drawing.Point(471, 26)
        Me.ReservationDateDateEdit.Name = "ReservationDateDateEdit"
        Me.ReservationDateDateEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationDateDateEdit.Properties.Appearance.Options.UseFont = True
        Me.ReservationDateDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReservationDateDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReservationDateDateEdit.Size = New System.Drawing.Size(198, 36)
        Me.ReservationDateDateEdit.TabIndex = 10
        '
        'TheServiceSearchLookUpEdit
        '
        Me.TheServiceSearchLookUpEdit.Location = New System.Drawing.Point(318, 104)
        Me.TheServiceSearchLookUpEdit.Name = "TheServiceSearchLookUpEdit"
        Me.TheServiceSearchLookUpEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TheServiceSearchLookUpEdit.Properties.Appearance.Options.UseFont = True
        Me.TheServiceSearchLookUpEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TheServiceSearchLookUpEdit.Properties.DisplayMember = "ItemName"
        Me.TheServiceSearchLookUpEdit.Properties.NullText = ""
        Me.TheServiceSearchLookUpEdit.Properties.PopupView = Me.TheServiceSearchLookUpEditView
        Me.TheServiceSearchLookUpEdit.Properties.ValueMember = "ItemNo"
        Me.TheServiceSearchLookUpEdit.Size = New System.Drawing.Size(351, 36)
        Me.TheServiceSearchLookUpEdit.TabIndex = 16
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(710, 70)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(44, 21)
        Me.LabelControl3.TabIndex = 17
        Me.LabelControl3.Text = "الزبون:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(683, 158)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(71, 21)
        Me.LabelControl4.TabIndex = 17
        Me.LabelControl4.Text = "مبلغ الحجز:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(675, 33)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(79, 21)
        Me.LabelControl5.TabIndex = 17
        Me.LabelControl5.Text = "تاريخ الحجز:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.Options.UseFont = True
        Me.LabelControl6.Location = New System.Drawing.Point(12, 437)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(61, 21)
        Me.LabelControl6.TabIndex = 17
        Me.LabelControl6.Text = "ملاحظات:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.Options.UseFont = True
        Me.LabelControl8.Location = New System.Drawing.Point(712, 111)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(42, 21)
        Me.LabelControl8.TabIndex = 17
        Me.LabelControl8.Text = "الخدمة:"
        '
        'TextRemainAmount
        '
        Me.TextRemainAmount.Location = New System.Drawing.Point(586, 390)
        Me.TextRemainAmount.Name = "TextRemainAmount"
        Me.TextRemainAmount.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRemainAmount.Properties.Appearance.Options.UseFont = True
        Me.TextRemainAmount.Properties.ReadOnly = True
        Me.TextRemainAmount.Size = New System.Drawing.Size(200, 36)
        Me.TextRemainAmount.TabIndex = 18
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.Options.UseFont = True
        Me.LabelControl9.Location = New System.Drawing.Point(497, 397)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(83, 21)
        Me.LabelControl9.TabIndex = 17
        Me.LabelControl9.Text = "المبلغ المتبقي:"
        '
        'ReservationNoteTextEdit
        '
        Me.ReservationNoteTextEdit.Location = New System.Drawing.Point(117, 430)
        Me.ReservationNoteTextEdit.Name = "ReservationNoteTextEdit"
        Me.ReservationNoteTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationNoteTextEdit.Properties.Appearance.Options.UseFont = True
        Me.ReservationNoteTextEdit.Size = New System.Drawing.Size(669, 55)
        Me.ReservationNoteTextEdit.TabIndex = 12
        '
        'ReservationsPaymentGridControl
        '
        Me.ReservationsPaymentGridControl.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationsPaymentGridControl.Location = New System.Drawing.Point(13, 218)
        Me.ReservationsPaymentGridControl.MainView = Me.GridView1
        Me.ReservationsPaymentGridControl.Name = "ReservationsPaymentGridControl"
        Me.ReservationsPaymentGridControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        Me.ReservationsPaymentGridControl.Size = New System.Drawing.Size(773, 164)
        Me.ReservationsPaymentGridControl.TabIndex = 18
        Me.ReservationsPaymentGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colPaymentDate, Me.colPaymentAmount, Me.colPaymentID, Me.colPaymentNotes, Me.GridColumn1})
        Me.GridView1.GridControl = Me.ReservationsPaymentGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.NewItemRowText = "اضغط هنا لاضافة دفعة جديدة"
        Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colPaymentDate
        '
        Me.colPaymentDate.Caption = "تاريخ الدفعة"
        Me.colPaymentDate.FieldName = "PaymentDate"
        Me.colPaymentDate.Name = "colPaymentDate"
        Me.colPaymentDate.Visible = True
        Me.colPaymentDate.VisibleIndex = 0
        Me.colPaymentDate.Width = 194
        '
        'colPaymentAmount
        '
        Me.colPaymentAmount.Caption = "المبلغ"
        Me.colPaymentAmount.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.colPaymentAmount.FieldName = "PaymentAmount"
        Me.colPaymentAmount.Name = "colPaymentAmount"
        Me.colPaymentAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaymentAmount", "{0:0.##}")})
        Me.colPaymentAmount.Visible = True
        Me.colPaymentAmount.VisibleIndex = 1
        Me.colPaymentAmount.Width = 202
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'colPaymentID
        '
        Me.colPaymentID.FieldName = "PaymentID"
        Me.colPaymentID.Name = "colPaymentID"
        '
        'colPaymentNotes
        '
        Me.colPaymentNotes.Caption = "ملاحظات الدفعة"
        Me.colPaymentNotes.FieldName = "PaymentNotes"
        Me.colPaymentNotes.Name = "colPaymentNotes"
        Me.colPaymentNotes.Visible = True
        Me.colPaymentNotes.VisibleIndex = 2
        Me.colPaymentNotes.Width = 350
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "رقم الحجز"
        Me.GridColumn1.FieldName = "ReservationID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Location = New System.Drawing.Point(32, 504)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(150, 34)
        Me.BtnSave.TabIndex = 19
        Me.BtnSave.Text = "حفظ"
        '
        'BtnDelete
        '
        Me.BtnDelete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnDelete.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Appearance.Options.UseBackColor = True
        Me.BtnDelete.Appearance.Options.UseFont = True
        Me.BtnDelete.Location = New System.Drawing.Point(636, 504)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(150, 34)
        Me.BtnDelete.TabIndex = 19
        Me.BtnDelete.Text = "حذف"
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.Controls.Add(Me.ReservationStatus)
        Me.GroupControl1.Controls.Add(Me.DocID)
        Me.GroupControl1.Controls.Add(Me.DocIdquery)
        Me.GroupControl1.Controls.Add(Me.TextDocDate)
        Me.GroupControl1.Controls.Add(Me.TextNewOld)
        Me.GroupControl1.Controls.Add(Me.ReservationDateDateEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.ReferanceNoSearchLookUpEdit)
        Me.GroupControl1.Controls.Add(Me.TheServiceSearchLookUpEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.ReservationAmountTextEdit)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light
        Me.GroupControl1.Location = New System.Drawing.Point(13, 20)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(773, 192)
        Me.GroupControl1.TabIndex = 20
        Me.GroupControl1.Text = "بيانات الحجز"
        '
        'ReservationStatus
        '
        Me.ReservationStatus.Location = New System.Drawing.Point(5, 147)
        Me.ReservationStatus.Name = "ReservationStatus"
        Me.ReservationStatus.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationStatus.Properties.Appearance.Options.UseFont = True
        Me.ReservationStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ReservationStatus.Properties.Items.AddRange(New Object() {"مفتوح", "مغلق"})
        Me.ReservationStatus.Size = New System.Drawing.Size(167, 36)
        Me.ReservationStatus.TabIndex = 22
        '
        'DocID
        '
        Me.DocID.Location = New System.Drawing.Point(5, 15)
        Me.DocID.Name = "DocID"
        Me.DocID.Properties.ReadOnly = True
        Me.DocID.Size = New System.Drawing.Size(100, 28)
        Me.DocID.TabIndex = 21
        '
        'DocIdquery
        '
        Me.DocIdquery.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.DocIdquery.Location = New System.Drawing.Point(5, 15)
        Me.DocIdquery.Name = "DocIdquery"
        Me.DocIdquery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocIdquery.Size = New System.Drawing.Size(100, 28)
        Me.DocIdquery.TabIndex = 20
        '
        'TextDocDate
        '
        Me.TextDocDate.Location = New System.Drawing.Point(5, 41)
        Me.TextDocDate.Name = "TextDocDate"
        Me.TextDocDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.TextDocDate.Properties.ReadOnly = True
        Me.TextDocDate.Size = New System.Drawing.Size(100, 28)
        Me.TextDocDate.TabIndex = 19
        '
        'TextNewOld
        '
        Me.TextNewOld.Location = New System.Drawing.Point(5, 63)
        Me.TextNewOld.Name = "TextNewOld"
        Me.TextNewOld.Size = New System.Drawing.Size(100, 28)
        Me.TextNewOld.TabIndex = 18
        Me.TextNewOld.Visible = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(178, 158)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 21)
        Me.LabelControl2.TabIndex = 17
        Me.LabelControl2.Text = "حالة الحجز:"
        '
        'PaymentsSum
        '
        Me.PaymentsSum.Location = New System.Drawing.Point(117, 390)
        Me.PaymentsSum.Name = "PaymentsSum"
        Me.PaymentsSum.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentsSum.Properties.Appearance.Options.UseFont = True
        Me.PaymentsSum.Properties.ReadOnly = True
        Me.PaymentsSum.Size = New System.Drawing.Size(198, 36)
        Me.PaymentsSum.TabIndex = 18
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(13, 397)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 21)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "مجموع الدفعات:"
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataMember = "Items"
        Me.ItemsBindingSource.DataSource = Me.AccountingDataSet
        '
        'ItemsTableAdapter
        '
        Me.ItemsTableAdapter.ClearBeforeFill = True
        '
        'ReservationAddEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 550)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.ReservationsPaymentGridControl)
        Me.Controls.Add(Me.PaymentsSum)
        Me.Controls.Add(Me.TextRemainAmount)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.ReservationNoteTextEdit)
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        Me.IconOptions.SvgImage = CType(resources.GetObject("ReservationAddEdit.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "ReservationAddEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "شاشة الحجز"
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferanceNoSearchLookUpEditView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TheServiceSearchLookUpEditView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferanceNoSearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationAmountTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDateDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDateDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TheServiceSearchLookUpEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRemainAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationNoteTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationsPaymentGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.ReservationStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocIdquery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentsSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ReferanceNoSearchLookUpEditView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TheServiceSearchLookUpEditView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ReferanceNoSearchLookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents ReservationAmountTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ReservationDateDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TheServiceSearchLookUpEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextRemainAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ReservationNoteTextEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents ReservationsPaymentGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPaymentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymentAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymentID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPaymentNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PaymentsSum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ItemsBindingSource As BindingSource
    Friend WithEvents ItemsTableAdapter As AccountingDataSetTableAdapters.ItemsTableAdapter
    Friend WithEvents colItemNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextNewOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextDocDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocIdquery As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents DocID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ReservationStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
