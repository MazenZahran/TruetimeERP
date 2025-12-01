<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VoucherProfit
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
        Dim FormatConditionRuleIconSet1 As DevExpress.XtraEditors.FormatConditionRuleIconSet = New DevExpress.XtraEditors.FormatConditionRuleIconSet()
        Dim FormatConditionIconSet1 As DevExpress.XtraEditors.FormatConditionIconSet = New DevExpress.XtraEditors.FormatConditionIconSet()
        Dim FormatConditionIconSetIcon1 As DevExpress.XtraEditors.FormatConditionIconSetIcon = New DevExpress.XtraEditors.FormatConditionIconSetIcon()
        Dim FormatConditionIconSetIcon2 As DevExpress.XtraEditors.FormatConditionIconSetIcon = New DevExpress.XtraEditors.FormatConditionIconSetIcon()
        Dim FormatConditionIconSetIcon3 As DevExpress.XtraEditors.FormatConditionIconSetIcon = New DevExpress.XtraEditors.FormatConditionIconSetIcon()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VoucherProfit))
        Me.ColMarginProfit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.حركةالصنفToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.تفاصيلالصنفToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColStockBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMainUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColMarginProfit
        '
        Me.ColMarginProfit.Caption = "هامش الربح"
        Me.ColMarginProfit.DisplayFormat.FormatString = "P0"
        Me.ColMarginProfit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColMarginProfit.FieldName = "MarginProfit"
        Me.ColMarginProfit.Name = "ColMarginProfit"
        Me.ColMarginProfit.OptionsColumn.AllowEdit = False
        Me.ColMarginProfit.OptionsColumn.FixedWidth = True
        Me.ColMarginProfit.Visible = True
        Me.ColMarginProfit.VisibleIndex = 6
        Me.ColMarginProfit.Width = 80
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(946, 462)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GridControl1.Location = New System.Drawing.Point(12, 50)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHyperLinkEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(922, 400)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.حركةالصنفToolStripMenuItem, Me.تفاصيلالصنفToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 48)
        '
        'حركةالصنفToolStripMenuItem
        '
        Me.حركةالصنفToolStripMenuItem.Name = "حركةالصنفToolStripMenuItem"
        Me.حركةالصنفToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.حركةالصنفToolStripMenuItem.Text = "حركة الصنف"
        '
        'تفاصيلالصنفToolStripMenuItem
        '
        Me.تفاصيلالصنفToolStripMenuItem.Name = "تفاصيلالصنفToolStripMenuItem"
        Me.تفاصيلالصنفToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.تفاصيلالصنفToolStripMenuItem.Text = "تفاصيل الصنف"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColStockID, Me.ColStockBarcode, Me.ColItemName, Me.ColStockUnit, Me.GridColumn1, Me.ColMainUnitPrice, Me.ColStockQuantity, Me.GridColumn2, Me.ColMarginProfit})
        Me.GridView1.DetailHeight = 458
        GridFormatRule1.Column = Me.ColMarginProfit
        GridFormatRule1.ColumnApplyTo = Me.ColMarginProfit
        GridFormatRule1.Name = "Format0"
        FormatConditionIconSet1.CategoryName = "Symbols"
        FormatConditionIconSetIcon1.PredefinedName = "Flags3_1.png"
        FormatConditionIconSetIcon1.Value = New Decimal(New Integer() {67, 0, 0, 0})
        FormatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual
        FormatConditionIconSetIcon2.PredefinedName = "Flags3_2.png"
        FormatConditionIconSetIcon2.Value = New Decimal(New Integer() {33, 0, 0, 0})
        FormatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual
        FormatConditionIconSetIcon3.PredefinedName = "Flags3_3.png"
        FormatConditionIconSetIcon3.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual
        FormatConditionIconSet1.Icons.Add(FormatConditionIconSetIcon1)
        FormatConditionIconSet1.Icons.Add(FormatConditionIconSetIcon2)
        FormatConditionIconSet1.Icons.Add(FormatConditionIconSetIcon3)
        FormatConditionIconSet1.Name = "Flags3"
        FormatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Percent
        FormatConditionRuleIconSet1.IconSet = FormatConditionIconSet1
        GridFormatRule1.Rule = FormatConditionRuleIconSet1
        Me.GridView1.FormatRules.Add(GridFormatRule1)
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColStockID
        '
        Me.ColStockID.Caption = "رقم الصنف"
        Me.ColStockID.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.ColStockID.FieldName = "StockID"
        Me.ColStockID.MaxWidth = 82
        Me.ColStockID.MinWidth = 82
        Me.ColStockID.Name = "ColStockID"
        Me.ColStockID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocID", "{0}")})
        Me.ColStockID.Visible = True
        Me.ColStockID.VisibleIndex = 0
        Me.ColStockID.Width = 82
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        Me.RepositoryItemHyperLinkEdit1.ReadOnly = True
        Me.RepositoryItemHyperLinkEdit1.SingleClick = True
        '
        'ColStockBarcode
        '
        Me.ColStockBarcode.Caption = "باركود"
        Me.ColStockBarcode.FieldName = "StockBarcode"
        Me.ColStockBarcode.Name = "ColStockBarcode"
        Me.ColStockBarcode.OptionsColumn.AllowEdit = False
        Me.ColStockBarcode.OptionsColumn.AllowSize = False
        Me.ColStockBarcode.OptionsColumn.ReadOnly = True
        Me.ColStockBarcode.Width = 118
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.AllowEdit = False
        Me.ColItemName.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColItemName.OptionsColumn.ReadOnly = True
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 1
        Me.ColItemName.Width = 275
        '
        'ColStockUnit
        '
        Me.ColStockUnit.Caption = "الوحدة"
        Me.ColStockUnit.FieldName = "StockUnit"
        Me.ColStockUnit.Name = "ColStockUnit"
        Me.ColStockUnit.OptionsColumn.AllowEdit = False
        Me.ColStockUnit.OptionsColumn.AllowSize = False
        Me.ColStockUnit.OptionsColumn.ReadOnly = True
        Me.ColStockUnit.Width = 95
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "تكلفة الوحدة"
        Me.GridColumn1.FieldName = "UnitCost"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        Me.GridColumn1.Width = 120
        '
        'ColMainUnitPrice
        '
        Me.ColMainUnitPrice.Caption = "سعر البيع"
        Me.ColMainUnitPrice.DisplayFormat.FormatString = "n2"
        Me.ColMainUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColMainUnitPrice.FieldName = "MainUnitPrice"
        Me.ColMainUnitPrice.Name = "ColMainUnitPrice"
        Me.ColMainUnitPrice.OptionsColumn.AllowEdit = False
        Me.ColMainUnitPrice.OptionsColumn.AllowSize = False
        Me.ColMainUnitPrice.OptionsColumn.FixedWidth = True
        Me.ColMainUnitPrice.OptionsColumn.ReadOnly = True
        Me.ColMainUnitPrice.Visible = True
        Me.ColMainUnitPrice.VisibleIndex = 3
        Me.ColMainUnitPrice.Width = 120
        '
        'ColStockQuantity
        '
        Me.ColStockQuantity.Caption = "الكمية"
        Me.ColStockQuantity.DisplayFormat.FormatString = "n2"
        Me.ColStockQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColStockQuantity.FieldName = "StockQuantityByMainUnit"
        Me.ColStockQuantity.Name = "ColStockQuantity"
        Me.ColStockQuantity.OptionsColumn.AllowEdit = False
        Me.ColStockQuantity.OptionsColumn.AllowSize = False
        Me.ColStockQuantity.OptionsColumn.FixedWidth = True
        Me.ColStockQuantity.OptionsColumn.ReadOnly = True
        Me.ColStockQuantity.Visible = True
        Me.ColStockQuantity.VisibleIndex = 2
        Me.ColStockQuantity.Width = 120
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "اجمالي الربح"
        Me.GridColumn2.DisplayFormat.FormatString = "n2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "Profit"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Profit", "{0:n2}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        Me.GridColumn2.Width = 120
        '
        'RadioGroup1
        '
        Me.RadioGroup1.EditValue = "PurchasePriceOnVoucherDate"
        Me.RadioGroup1.Location = New System.Drawing.Point(12, 12)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("PurchasePriceOnVoucherDate", "سعر الشراء بتاريخ السند"), New DevExpress.XtraEditors.Controls.RadioGroupItem("LastPurchasedPrice", "اخر سعر شراء"), New DevExpress.XtraEditors.Controls.RadioGroupItem("AveragePurchasePrice", "معدل سعر الشراء")})
        Me.RadioGroup1.Size = New System.Drawing.Size(810, 34)
        Me.RadioGroup1.StyleController = Me.LayoutControl1
        Me.RadioGroup1.TabIndex = 5
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(946, 462)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 38)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(926, 404)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.RadioGroup1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(926, 38)
        Me.LayoutControlItem2.Text = "حساب تكلفة السند"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(100, 17)
        '
        'VoucherProfit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 462)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("VoucherProfit.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "VoucherProfit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ربح فاتورة مبيعات"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColStockID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents ColMainUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMarginProfit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents حركةالصنفToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents تفاصيلالصنفToolStripMenuItem As ToolStripMenuItem
End Class
