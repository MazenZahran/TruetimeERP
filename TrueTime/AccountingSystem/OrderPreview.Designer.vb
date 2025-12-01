<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrderPreview
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderPreview))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.WhereHouse = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.DocNote = New DevExpress.XtraEditors.MemoEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColItemNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDelete = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocNoteByAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.WhereHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.WhereHouse)
        Me.LayoutControl1.Controls.Add(Me.Referance)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.DocNote)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(805, 386)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'WhereHouse
        '
        Me.WhereHouse.EnterMoveNextControl = True
        Me.WhereHouse.Location = New System.Drawing.Point(12, 13)
        Me.WhereHouse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WhereHouse.Name = "WhereHouse"
        Me.WhereHouse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.WhereHouse.Properties.DisplayMember = "WarehouseNameAR"
        Me.WhereHouse.Properties.NullText = ""
        Me.WhereHouse.Properties.PopupView = Me.GridView4
        Me.WhereHouse.Properties.ValueMember = "WarehouseID"
        Me.WhereHouse.Size = New System.Drawing.Size(187, 28)
        Me.WhereHouse.StyleController = Me.LayoutControl1
        Me.WhereHouse.TabIndex = 14
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn6})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsEditForm.PopupEditFormWidth = 685
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "رقم"
        Me.GridColumn5.FieldName = "WarehouseID"
        Me.GridColumn5.MinWidth = 19
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        Me.GridColumn5.Width = 74
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "المستودع"
        Me.GridColumn6.FieldName = "WarehouseNameAR"
        Me.GridColumn6.MinWidth = 19
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 74
        '
        'Referance
        '
        Me.Referance.EditValue = CType(-1, Short)
        Me.Referance.EnterMoveNextControl = True
        Me.Referance.Location = New System.Drawing.Point(265, 13)
        Me.Referance.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Referance.Properties.DisplayMember = "RefName"
        Me.Referance.Properties.NullText = ""
        Me.Referance.Properties.NullValuePrompt = "اختر الذمة"
        Me.Referance.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.Size = New System.Drawing.Size(466, 28)
        Me.Referance.StyleController = Me.LayoutControl1
        Me.Referance.TabIndex = 9
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 685
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'ColRefID
        '
        Me.ColRefID.Caption = "ID"
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.MinWidth = 19
        Me.ColRefID.Name = "ColRefID"
        Me.ColRefID.Width = 74
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم المرجع"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.MaxWidth = 79
        Me.ColRefNo.MinWidth = 19
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.Visible = True
        Me.ColRefNo.VisibleIndex = 0
        Me.ColRefNo.Width = 74
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "المرجع"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.MinWidth = 199
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 1
        Me.ColRefName.Width = 199
        '
        'ColRefTypeName
        '
        Me.ColRefTypeName.Caption = "نوع المرجع"
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.MaxWidth = 79
        Me.ColRefTypeName.MinWidth = 19
        Me.ColRefTypeName.Name = "ColRefTypeName"
        Me.ColRefTypeName.Visible = True
        Me.ColRefTypeName.VisibleIndex = 2
        Me.ColRefTypeName.Width = 74
        '
        'ColRefAccID
        '
        Me.ColRefAccID.Caption = "رقم الحساب"
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.MinWidth = 19
        Me.ColRefAccID.Name = "ColRefAccID"
        Me.ColRefAccID.Width = 74
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 346)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(160, 27)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "اعتماد الطلبية"
        '
        'DocNote
        '
        Me.DocNote.Location = New System.Drawing.Point(12, 271)
        Me.DocNote.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DocNote.Name = "DocNote"
        Me.DocNote.Size = New System.Drawing.Size(719, 71)
        Me.DocNote.StyleController = Me.LayoutControl1
        Me.DocNote.TabIndex = 5
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(12, 45)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryDelete})
        Me.GridControl1.Size = New System.Drawing.Size(781, 222)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColItemNo, Me.ColItemName, Me.ColQuantity, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.ColAmount, Me.ColDocNoteByAccount})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 685
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColItemNo
        '
        Me.ColItemNo.Caption = "رقم الصنف"
        Me.ColItemNo.FieldName = "ItemNo"
        Me.ColItemNo.MinWidth = 19
        Me.ColItemNo.Name = "ColItemNo"
        Me.ColItemNo.Visible = True
        Me.ColItemNo.VisibleIndex = 2
        Me.ColItemNo.Width = 76
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.MinWidth = 19
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 3
        Me.ColItemName.Width = 187
        '
        'ColQuantity
        '
        Me.ColQuantity.Caption = "الكمية"
        Me.ColQuantity.FieldName = "Quantity"
        Me.ColQuantity.MinWidth = 19
        Me.ColQuantity.Name = "ColQuantity"
        Me.ColQuantity.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n2}")})
        Me.ColQuantity.Visible = True
        Me.ColQuantity.VisibleIndex = 4
        Me.ColQuantity.Width = 67
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "المورد"
        Me.GridColumn1.FieldName = "RefName"
        Me.GridColumn1.MinWidth = 17
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 114
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "التكلفة"
        Me.GridColumn2.FieldName = "Cost"
        Me.GridColumn2.MinWidth = 17
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        Me.GridColumn2.Width = 58
        '
        'GridColumn3
        '
        Me.GridColumn3.ColumnEdit = Me.RepositoryDelete
        Me.GridColumn3.MinWidth = 17
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 7
        Me.GridColumn3.Width = 52
        '
        'RepositoryDelete
        '
        Me.RepositoryDelete.AutoHeight = False
        EditorButtonImageOptions1.Image = Global.TrueTime.My.Resources.Resources.remove_24
        Me.RepositoryDelete.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryDelete.Name = "RepositoryDelete"
        Me.RepositoryDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ID"
        Me.GridColumn4.FieldName = "ID"
        Me.GridColumn4.MinWidth = 17
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Width = 64
        '
        'ColAmount
        '
        Me.ColAmount.Caption = "المبلغ"
        Me.ColAmount.FieldName = "Amount"
        Me.ColAmount.MinWidth = 17
        Me.ColAmount.Name = "ColAmount"
        Me.ColAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")})
        Me.ColAmount.Visible = True
        Me.ColAmount.VisibleIndex = 6
        Me.ColAmount.Width = 64
        '
        'ColDocNoteByAccount
        '
        Me.ColDocNoteByAccount.Caption = "ملاحظة"
        Me.ColDocNoteByAccount.FieldName = "DocNoteByAccount"
        Me.ColDocNoteByAccount.MinWidth = 17
        Me.ColDocNoteByAccount.Name = "ColDocNoteByAccount"
        Me.ColDocNoteByAccount.Width = 64
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.EmptySpaceItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(805, 386)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(785, 226)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DocNote
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 258)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(785, 75)
        Me.LayoutControlItem2.Text = "ملاحظات"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 333)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(164, 31)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(164, 31)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(164, 31)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.Referance
        Me.LayoutControlItem5.Location = New System.Drawing.Point(253, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(532, 32)
        Me.LayoutControlItem5.Text = "الذمة:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(164, 333)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(621, 31)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.WhereHouse
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(253, 21)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(253, 21)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(253, 32)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "المستودع:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(50, 13)
        '
        'OrderPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 386)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("OrderPreview.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "OrderPreview"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "معاينة الطلبية"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.WhereHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DocNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColItemNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDelete As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WhereHouse As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColDocNoteByAccount As DevExpress.XtraGrid.Columns.GridColumn
End Class
