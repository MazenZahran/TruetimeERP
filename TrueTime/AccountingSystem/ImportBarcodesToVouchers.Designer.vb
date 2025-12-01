<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImportBarcodesToVouchers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportBarcodesToVouchers))
        Dim GridFormatRule1 As DevExpress.XtraGrid.GridFormatRule = New DevExpress.XtraGrid.GridFormatRule()
        Dim FormatConditionRuleValue1 As DevExpress.XtraEditors.FormatConditionRuleValue = New DevExpress.XtraEditors.FormatConditionRuleValue()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.DocName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryUnit = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColStockQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDebitAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCredAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockQuantityByMainUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockQuantityPerMainUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.DocName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "اسم الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.AllowEdit = False
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 2
        '
        'ColStockBarcode
        '
        Me.ColStockBarcode.Caption = "باركود الصنف"
        Me.ColStockBarcode.FieldName = "StockBarcode"
        Me.ColStockBarcode.Name = "ColStockBarcode"
        Me.ColStockBarcode.OptionsColumn.AllowEdit = False
        Me.ColStockBarcode.Visible = True
        Me.ColStockBarcode.VisibleIndex = 1
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.DocName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(890, 576)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'DocName
        '
        Me.DocName.Location = New System.Drawing.Point(12, 12)
        Me.DocName.Name = "DocName"
        Me.DocName.Size = New System.Drawing.Size(822, 28)
        Me.DocName.StyleController = Me.LayoutControl1
        Me.DocName.TabIndex = 8
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton3.Location = New System.Drawing.Point(644, 526)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(116, 34)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 7
        Me.SimpleButton3.Text = "جهاز باركود"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton2.Location = New System.Drawing.Point(766, 526)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(108, 34)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 6
        Me.SimpleButton2.Text = "ملف اكسل"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 526)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(135, 34)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "اعتماد"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(16, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryUnit})
        Me.GridControl1.Size = New System.Drawing.Size(858, 504)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColStockBarcode, Me.ColStockID, Me.ColItemName, Me.ColStockUnit, Me.ColStockQuantity, Me.ColStockPrice, Me.ColDebitAcc, Me.ColCredAcc, Me.ColDocAmount, Me.ColStockQuantityByMainUnit, Me.ColStockQuantityPerMainUnit})
        GridFormatRule1.ApplyToRow = True
        GridFormatRule1.Column = Me.ColItemName
        GridFormatRule1.ColumnApplyTo = Me.ColStockBarcode
        GridFormatRule1.Name = "Format0"
        FormatConditionRuleValue1.AllowAnimation = DevExpress.Utils.DefaultBoolean.[True]
        FormatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal
        FormatConditionRuleValue1.PredefinedName = "Red Fill"
        FormatConditionRuleValue1.Value1 = "0"
        GridFormatRule1.Rule = FormatConditionRuleValue1
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColStockID
        '
        Me.ColStockID.Caption = "رقم الصنف"
        Me.ColStockID.FieldName = "StockID"
        Me.ColStockID.Name = "ColStockID"
        Me.ColStockID.OptionsColumn.AllowEdit = False
        Me.ColStockID.Visible = True
        Me.ColStockID.VisibleIndex = 3
        '
        'ColStockUnit
        '
        Me.ColStockUnit.Caption = "الوحدة"
        Me.ColStockUnit.ColumnEdit = Me.RepositoryUnit
        Me.ColStockUnit.FieldName = "StockUnit"
        Me.ColStockUnit.Name = "ColStockUnit"
        Me.ColStockUnit.OptionsColumn.AllowEdit = False
        Me.ColStockUnit.Visible = True
        Me.ColStockUnit.VisibleIndex = 4
        '
        'RepositoryUnit
        '
        Me.RepositoryUnit.AutoHeight = False
        Me.RepositoryUnit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryUnit.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "Name1"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Name2")})
        Me.RepositoryUnit.DisplayMember = "name"
        Me.RepositoryUnit.Name = "RepositoryUnit"
        Me.RepositoryUnit.NullText = ""
        Me.RepositoryUnit.ValueMember = "id"
        '
        'ColStockQuantity
        '
        Me.ColStockQuantity.Caption = "الكمية"
        Me.ColStockQuantity.FieldName = "StockQuantity"
        Me.ColStockQuantity.Name = "ColStockQuantity"
        Me.ColStockQuantity.Visible = True
        Me.ColStockQuantity.VisibleIndex = 5
        '
        'ColStockPrice
        '
        Me.ColStockPrice.Caption = "السعر"
        Me.ColStockPrice.FieldName = "StockPrice"
        Me.ColStockPrice.Name = "ColStockPrice"
        Me.ColStockPrice.OptionsColumn.AllowEdit = False
        Me.ColStockPrice.Visible = True
        Me.ColStockPrice.VisibleIndex = 6
        '
        'ColDebitAcc
        '
        Me.ColDebitAcc.Caption = "الحساب المدين"
        Me.ColDebitAcc.FieldName = "DebitAcc"
        Me.ColDebitAcc.Name = "ColDebitAcc"
        Me.ColDebitAcc.OptionsColumn.AllowEdit = False
        '
        'ColCredAcc
        '
        Me.ColCredAcc.Caption = "الحساب الدائن"
        Me.ColCredAcc.FieldName = "CredAcc"
        Me.ColCredAcc.Name = "ColCredAcc"
        Me.ColCredAcc.OptionsColumn.AllowEdit = False
        '
        'ColDocAmount
        '
        Me.ColDocAmount.Caption = "المبلغ"
        Me.ColDocAmount.FieldName = "DocAmount"
        Me.ColDocAmount.Name = "ColDocAmount"
        Me.ColDocAmount.OptionsColumn.AllowEdit = False
        Me.ColDocAmount.Visible = True
        Me.ColDocAmount.VisibleIndex = 7
        '
        'ColStockQuantityByMainUnit
        '
        Me.ColStockQuantityByMainUnit.Caption = "الكمية يالوحدة الرئيسية"
        Me.ColStockQuantityByMainUnit.FieldName = "StockQuantityByMainUnit"
        Me.ColStockQuantityByMainUnit.Name = "ColStockQuantityByMainUnit"
        Me.ColStockQuantityByMainUnit.OptionsColumn.AllowEdit = False
        '
        'ColStockQuantityPerMainUnit
        '
        Me.ColStockQuantityPerMainUnit.Caption = "الكمية لكل وحدة"
        Me.ColStockQuantityPerMainUnit.FieldName = "StockQuantityPerMainUnit"
        Me.ColStockQuantityPerMainUnit.Name = "ColStockQuantityPerMainUnit"
        Me.ColStockQuantityPerMainUnit.OptionsColumn.AllowEdit = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.DocName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(870, 24)
        Me.LayoutControlItem5.Text = "السند:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(32, 13)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(890, 576)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(864, 510)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 510)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(40, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(141, 40)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(141, 510)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(487, 40)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton2
        Me.LayoutControlItem3.Location = New System.Drawing.Point(750, 510)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(114, 40)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(114, 40)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(114, 40)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SimpleButton3
        Me.LayoutControlItem4.Location = New System.Drawing.Point(628, 510)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(122, 40)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(122, 40)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(122, 40)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'ImportBarcodesToVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 576)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "ImportBarcodesToVouchers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "استيراد جدول الأصناف"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.DocName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColStockBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryUnit As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColStockPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DocName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColDebitAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCredAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantityByMainUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantityPerMainUnit As DevExpress.XtraGrid.Columns.GridColumn
End Class
