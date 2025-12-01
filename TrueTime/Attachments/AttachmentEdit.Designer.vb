<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttachmentEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttachmentEdit))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.DocIDEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocNameEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocSort1Edit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocAccountCodeEdit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocDetailsEdit = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocExpireDateEdit = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocNoEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocCodeEdit = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SearchLookReferance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.ReferancesListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReferancesListTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ReferancesListTableAdapter()
        Me.colRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocIDEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNameEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocSort1Edit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocAccountCodeEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDetailsEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocExpireDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocExpireDateEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocNoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCodeEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookReferance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SearchLookReferance)
        Me.LayoutControl1.Controls.Add(Me.DocCodeEdit)
        Me.LayoutControl1.Controls.Add(Me.DocNoEdit)
        Me.LayoutControl1.Controls.Add(Me.DocExpireDateEdit)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.DocDetailsEdit)
        Me.LayoutControl1.Controls.Add(Me.DocAccountCodeEdit)
        Me.LayoutControl1.Controls.Add(Me.DocSort1Edit)
        Me.LayoutControl1.Controls.Add(Me.DocNameEdit)
        Me.LayoutControl1.Controls.Add(Me.DocIDEdit)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(349, 327)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(349, 327)
        Me.Root.TextVisible = False
        '
        'DocIDEdit
        '
        Me.DocIDEdit.Location = New System.Drawing.Point(12, 12)
        Me.DocIDEdit.Name = "DocIDEdit"
        Me.DocIDEdit.Properties.ReadOnly = True
        Me.DocIDEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocIDEdit.StyleController = Me.LayoutControl1
        Me.DocIDEdit.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DocIDEdit
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem1.Text = "رقم الوثيقة:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(84, 13)
        '
        'DocNameEdit
        '
        Me.DocNameEdit.Location = New System.Drawing.Point(12, 36)
        Me.DocNameEdit.Name = "DocNameEdit"
        Me.DocNameEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocNameEdit.StyleController = Me.LayoutControl1
        Me.DocNameEdit.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DocNameEdit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem2.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem2.Text = "اسم الوثيقة:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(84, 13)
        '
        'DocSort1Edit
        '
        Me.DocSort1Edit.Location = New System.Drawing.Point(12, 60)
        Me.DocSort1Edit.Name = "DocSort1Edit"
        Me.DocSort1Edit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocSort1Edit.Properties.DisplayMember = "ArchiveDocsSorts1"
        Me.DocSort1Edit.Properties.NullText = ""
        Me.DocSort1Edit.Properties.PopupView = Me.GridView3
        Me.DocSort1Edit.Properties.ValueMember = "ID"
        Me.DocSort1Edit.Size = New System.Drawing.Size(229, 20)
        Me.DocSort1Edit.StyleController = Me.LayoutControl1
        Me.DocSort1Edit.TabIndex = 20
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView3.DetailHeight = 284
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DocSort1Edit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem4.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem4.Text = "تصنيف الوثيقة:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(84, 13)
        '
        'DocAccountCodeEdit
        '
        Me.DocAccountCodeEdit.EditValue = ""
        Me.DocAccountCodeEdit.Location = New System.Drawing.Point(12, 84)
        Me.DocAccountCodeEdit.Name = "DocAccountCodeEdit"
        Me.DocAccountCodeEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocAccountCodeEdit.Properties.DisplayMember = "AccName"
        Me.DocAccountCodeEdit.Properties.NullText = ""
        Me.DocAccountCodeEdit.Properties.PopupView = Me.GridView4
        Me.DocAccountCodeEdit.Properties.ValueMember = "AccNo"
        Me.DocAccountCodeEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocAccountCodeEdit.StyleController = Me.LayoutControl1
        Me.DocAccountCodeEdit.TabIndex = 22
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView4.DetailHeight = 284
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DocAccountCodeEdit
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem3.OptionsTableLayoutItem.RowIndex = 1
        Me.LayoutControlItem3.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem3.Text = "الحساب:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(84, 13)
        '
        'DocDetailsEdit
        '
        Me.DocDetailsEdit.Location = New System.Drawing.Point(12, 204)
        Me.DocDetailsEdit.Name = "DocDetailsEdit"
        Me.DocDetailsEdit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.DocDetailsEdit.Properties.Appearance.Options.UseBackColor = True
        Me.DocDetailsEdit.Size = New System.Drawing.Size(325, 85)
        Me.DocDetailsEdit.StyleController = Me.LayoutControl1
        Me.DocDetailsEdit.TabIndex = 23
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DocDetailsEdit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 192)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.OptionsTableLayoutItem.RowIndex = 2
        Me.LayoutControlItem5.Size = New System.Drawing.Size(329, 89)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 293)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(325, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 24
        Me.SimpleButton1.Text = "حفظ"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 281)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.OptionsTableLayoutItem.ColumnIndex = 1
        Me.LayoutControlItem6.OptionsTableLayoutItem.RowIndex = 2
        Me.LayoutControlItem6.Size = New System.Drawing.Size(329, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'DocExpireDateEdit
        '
        Me.DocExpireDateEdit.EditValue = Nothing
        Me.DocExpireDateEdit.Location = New System.Drawing.Point(12, 132)
        Me.DocExpireDateEdit.Name = "DocExpireDateEdit"
        Me.DocExpireDateEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocExpireDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocExpireDateEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocExpireDateEdit.StyleController = Me.LayoutControl1
        Me.DocExpireDateEdit.TabIndex = 25
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.DocExpireDateEdit
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem7.Text = "تاريخ انتهاء الوثيقة:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(84, 13)
        Me.LayoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'DocNoEdit
        '
        Me.DocNoEdit.Location = New System.Drawing.Point(12, 156)
        Me.DocNoEdit.Name = "DocNoEdit"
        Me.DocNoEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocNoEdit.StyleController = Me.LayoutControl1
        Me.DocNoEdit.TabIndex = 26
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.DocNoEdit
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem8.Text = "رقم السند:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(84, 13)
        Me.LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'DocCodeEdit
        '
        Me.DocCodeEdit.Location = New System.Drawing.Point(12, 180)
        Me.DocCodeEdit.Name = "DocCodeEdit"
        Me.DocCodeEdit.Size = New System.Drawing.Size(229, 20)
        Me.DocCodeEdit.StyleController = Me.LayoutControl1
        Me.DocCodeEdit.TabIndex = 27
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.DocCodeEdit
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem9.Text = "كود الوثيقة:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(84, 13)
        Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'SearchLookReferance
        '
        Me.SearchLookReferance.Location = New System.Drawing.Point(12, 108)
        Me.SearchLookReferance.Name = "SearchLookReferance"
        Me.SearchLookReferance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookReferance.Properties.DisplayMember = "RefName"
        Me.SearchLookReferance.Properties.NullText = ""
        Me.SearchLookReferance.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookReferance.Properties.ValueMember = "RefNo"
        Me.SearchLookReferance.Size = New System.Drawing.Size(229, 20)
        Me.SearchLookReferance.StyleController = Me.LayoutControl1
        Me.SearchLookReferance.TabIndex = 28
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SearchLookReferance
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(329, 24)
        Me.LayoutControlItem10.Text = "الذمة:"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(84, 13)
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colRefNo, Me.colRefName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReferancesListBindingSource
        '
        Me.ReferancesListBindingSource.DataMember = "ReferancesList"
        Me.ReferancesListBindingSource.DataSource = Me.AccountingDataSet
        '
        'ReferancesListTableAdapter
        '
        Me.ReferancesListTableAdapter.ClearBeforeFill = True
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
        'GridColumn1
        '
        Me.GridColumn1.Caption = "الحساب"
        Me.GridColumn1.FieldName = "AccName"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "رقم الحساب"
        Me.GridColumn2.FieldName = "AccNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "ID"
        Me.GridColumn3.FieldName = "ID"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "تصنيف الوثيقة"
        Me.GridColumn4.FieldName = "ArchiveDocsSorts1"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'AttachmentEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 327)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("AttachmentEdit.IconOptions.Image"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AttachmentEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعديل وثيقة"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocIDEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNameEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocSort1Edit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocAccountCodeEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDetailsEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocExpireDateEdit.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocExpireDateEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocNoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCodeEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookReferance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents DocNameEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocIDEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocSort1Edit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocAccountCodeEdit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DocDetailsEdit As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocExpireDateEdit As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocNoEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocCodeEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchLookReferance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents ReferancesListBindingSource As BindingSource
    Friend WithEvents ReferancesListTableAdapter As AccountingDataSetTableAdapters.ReferancesListTableAdapter
    Friend WithEvents colRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
End Class
