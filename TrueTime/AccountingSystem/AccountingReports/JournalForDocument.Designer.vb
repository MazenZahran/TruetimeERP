<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JournalForDocument
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JournalForDocument))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDebitAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCredAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDebitDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColExchangePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColBaseCurrAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReferance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocNotes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCostCenter = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(849, 406)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 372)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(123, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "طباعة"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(825, 356)
        Me.GridControl1.TabIndex = 5
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.ActiveFilterEnabled = False
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColDocID, Me.ColDocDate, Me.ColDocName, Me.ColDebitAcc, Me.ColCredAcc, Me.ColDocCurrency, Me.ColDebitDocAmount, Me.ColExchangePrice, Me.ColBaseCurrAmount, Me.ColReferance, Me.ColDocNotes, Me.ColDocCostCenter, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.GridView1.DetailHeight = 284
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 2
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsCustomization.AllowFilter = False
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsView.AllowCellMerge = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowGroupPanelColumnsAsSingleRow = True
        Me.GridView1.PreviewFieldName = "DocNotes"
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDocName, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDocID, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColID
        '
        Me.ColID.Caption = "ID"
        Me.ColID.FieldName = "ID"
        Me.ColID.MinWidth = 17
        Me.ColID.Name = "ColID"
        '
        'ColDocID
        '
        Me.ColDocID.Caption = "رقم السند"
        Me.ColDocID.FieldName = "DocID"
        Me.ColDocID.MinWidth = 17
        Me.ColDocID.Name = "ColDocID"
        Me.ColDocID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColDocID.Visible = True
        Me.ColDocID.VisibleIndex = 0
        '
        'ColDocDate
        '
        Me.ColDocDate.Caption = "تاريخ السند"
        Me.ColDocDate.FieldName = "DocDate"
        Me.ColDocDate.MinWidth = 17
        Me.ColDocDate.Name = "ColDocDate"
        Me.ColDocDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColDocDate.Visible = True
        Me.ColDocDate.VisibleIndex = 0
        '
        'ColDocName
        '
        Me.ColDocName.Caption = "السند"
        Me.ColDocName.FieldName = "DocName"
        Me.ColDocName.MinWidth = 17
        Me.ColDocName.Name = "ColDocName"
        Me.ColDocName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColDocName.Visible = True
        Me.ColDocName.VisibleIndex = 2
        '
        'ColDebitAcc
        '
        Me.ColDebitAcc.Caption = "الحساب المدين"
        Me.ColDebitAcc.FieldName = "DebitAcc"
        Me.ColDebitAcc.MinWidth = 17
        Me.ColDebitAcc.Name = "ColDebitAcc"
        '
        'ColCredAcc
        '
        Me.ColCredAcc.Caption = "الحساب الدائن"
        Me.ColCredAcc.FieldName = "CredAcc"
        Me.ColCredAcc.MinWidth = 17
        Me.ColCredAcc.Name = "ColCredAcc"
        '
        'ColDocCurrency
        '
        Me.ColDocCurrency.Caption = "العملة"
        Me.ColDocCurrency.FieldName = "DocCurrency"
        Me.ColDocCurrency.MinWidth = 17
        Me.ColDocCurrency.Name = "ColDocCurrency"
        Me.ColDocCurrency.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColDocCurrency.Visible = True
        Me.ColDocCurrency.VisibleIndex = 1
        '
        'ColDebitDocAmount
        '
        Me.ColDebitDocAmount.Caption = "المبلغ"
        Me.ColDebitDocAmount.DisplayFormat.FormatString = "N"
        Me.ColDebitDocAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDebitDocAmount.FieldName = "DocAmount"
        Me.ColDebitDocAmount.MinWidth = 17
        Me.ColDebitDocAmount.Name = "ColDebitDocAmount"
        Me.ColDebitDocAmount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'ColExchangePrice
        '
        Me.ColExchangePrice.Caption = "سعر الصرف"
        Me.ColExchangePrice.FieldName = "ExchangePrice"
        Me.ColExchangePrice.MinWidth = 17
        Me.ColExchangePrice.Name = "ColExchangePrice"
        Me.ColExchangePrice.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColExchangePrice.Visible = True
        Me.ColExchangePrice.VisibleIndex = 5
        '
        'ColBaseCurrAmount
        '
        Me.ColBaseCurrAmount.Caption = "المبلغ بالعملة الرئيسية"
        Me.ColBaseCurrAmount.DisplayFormat.FormatString = "N"
        Me.ColBaseCurrAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColBaseCurrAmount.FieldName = "BaseCurrAmount"
        Me.ColBaseCurrAmount.MinWidth = 17
        Me.ColBaseCurrAmount.Name = "ColBaseCurrAmount"
        Me.ColBaseCurrAmount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.ColBaseCurrAmount.Visible = True
        Me.ColBaseCurrAmount.VisibleIndex = 6
        '
        'ColReferance
        '
        Me.ColReferance.Caption = "المرجع"
        Me.ColReferance.FieldName = "ReferanceName"
        Me.ColReferance.MinWidth = 17
        Me.ColReferance.Name = "ColReferance"
        Me.ColReferance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColReferance.Visible = True
        Me.ColReferance.VisibleIndex = 7
        '
        'ColDocNotes
        '
        Me.ColDocNotes.Caption = "ملاحظات"
        Me.ColDocNotes.FieldName = "DocNotes"
        Me.ColDocNotes.MinWidth = 17
        Me.ColDocNotes.Name = "ColDocNotes"
        Me.ColDocNotes.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColDocNotes.Visible = True
        Me.ColDocNotes.VisibleIndex = 8
        '
        'ColDocCostCenter
        '
        Me.ColDocCostCenter.Caption = "مركز التكلفة"
        Me.ColDocCostCenter.FieldName = "DocCostCenter"
        Me.ColDocCostCenter.MinWidth = 15
        Me.ColDocCostCenter.Name = "ColDocCostCenter"
        Me.ColDocCostCenter.Width = 64
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "الحساب"
        Me.GridColumn1.FieldName = "Account"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "مدين"
        Me.GridColumn2.FieldName = "DebitAmount"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebitAmount", "{0:0.##}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "دائن"
        Me.GridColumn3.FieldName = "CreditAmount"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CreditAmount", "{0:0.##}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(849, 406)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(829, 360)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 360)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(127, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(127, 360)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(702, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'JournalForDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 406)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "JournalForDocument"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "JournalForDocument"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDebitAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCredAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDebitDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColExchangePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColBaseCurrAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReferance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocNotes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCostCenter As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
