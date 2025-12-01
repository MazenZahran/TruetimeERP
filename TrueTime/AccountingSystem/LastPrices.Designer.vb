<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LastPrices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LastPrices))
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.StockID = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextItemName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextPurchaseOrSale = New System.Windows.Forms.TextBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemHyperLinkEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColDocDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColReferanceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockUnit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColInputUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColInputDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStockBarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.StockID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.StockID)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.TextItemName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextPurchaseOrSale)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1079, 140, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1339, 545)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'StockID
        '
        Me.StockID.Location = New System.Drawing.Point(1083, 20)
        Me.StockID.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.StockID.Name = "StockID"
        Me.StockID.Properties.ReadOnly = True
        Me.StockID.Size = New System.Drawing.Size(181, 34)
        Me.StockID.StyleController = Me.LayoutControl1
        Me.StockID.TabIndex = 11
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton3.Location = New System.Drawing.Point(21, 484)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(48, 41)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 10
        '
        'TextItemName
        '
        Me.TextItemName.Location = New System.Drawing.Point(660, 20)
        Me.TextItemName.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TextItemName.Name = "TextItemName"
        Me.TextItemName.Properties.ReadOnly = True
        Me.TextItemName.Size = New System.Drawing.Size(415, 34)
        Me.TextItemName.StyleController = Me.LayoutControl1
        Me.TextItemName.TabIndex = 9
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(13, 363)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(1151, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl1
        Me.SimpleButton2.TabIndex = 8
        Me.SimpleButton2.Text = "خروج"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(13, 12)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(567, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 7
        Me.SimpleButton1.Text = "SimpleButton1"
        '
        'TextPurchaseOrSale
        '
        Me.TextPurchaseOrSale.Location = New System.Drawing.Point(325, 12)
        Me.TextPurchaseOrSale.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TextPurchaseOrSale.Name = "TextPurchaseOrSale"
        Me.TextPurchaseOrSale.Size = New System.Drawing.Size(120, 20)
        Me.TextPurchaseOrSale.TabIndex = 5
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.GridControl1.Location = New System.Drawing.Point(21, 62)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemHyperLinkEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1297, 414)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColDocID, Me.ColDocDate, Me.ColName, Me.ColReferanceName, Me.ColStockPrice, Me.ColDocCode, Me.ColStockUnit, Me.ColUnitPrice, Me.ColStockQuantity, Me.ColInputUser, Me.ColInputDateTime, Me.ColDocAmount, Me.ColStockBarcode, Me.ColItemName, Me.ColDocCurrency})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 1067
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColDocID
        '
        Me.ColDocID.Caption = "رقم السند"
        Me.ColDocID.ColumnEdit = Me.RepositoryItemHyperLinkEdit1
        Me.ColDocID.FieldName = "DocID"
        Me.ColDocID.MaxWidth = 93
        Me.ColDocID.MinWidth = 93
        Me.ColDocID.Name = "ColDocID"
        Me.ColDocID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DocID", "{0}")})
        Me.ColDocID.Visible = True
        Me.ColDocID.VisibleIndex = 0
        Me.ColDocID.Width = 93
        '
        'RepositoryItemHyperLinkEdit1
        '
        Me.RepositoryItemHyperLinkEdit1.AutoHeight = False
        Me.RepositoryItemHyperLinkEdit1.Name = "RepositoryItemHyperLinkEdit1"
        Me.RepositoryItemHyperLinkEdit1.ReadOnly = True
        Me.RepositoryItemHyperLinkEdit1.SingleClick = True
        '
        'ColDocDate
        '
        Me.ColDocDate.Caption = "التاريخ"
        Me.ColDocDate.FieldName = "DocDate"
        Me.ColDocDate.MaxWidth = 107
        Me.ColDocDate.MinWidth = 107
        Me.ColDocDate.Name = "ColDocDate"
        Me.ColDocDate.OptionsColumn.ReadOnly = True
        Me.ColDocDate.Visible = True
        Me.ColDocDate.VisibleIndex = 1
        Me.ColDocDate.Width = 107
        '
        'ColName
        '
        Me.ColName.Caption = "السند"
        Me.ColName.FieldName = "Name"
        Me.ColName.MinWidth = 23
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.ReadOnly = True
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 105
        '
        'ColReferanceName
        '
        Me.ColReferanceName.Caption = "الذمة"
        Me.ColReferanceName.FieldName = "ReferanceName"
        Me.ColReferanceName.MinWidth = 23
        Me.ColReferanceName.Name = "ColReferanceName"
        Me.ColReferanceName.OptionsColumn.ReadOnly = True
        Me.ColReferanceName.Visible = True
        Me.ColReferanceName.VisibleIndex = 3
        Me.ColReferanceName.Width = 305
        '
        'ColStockPrice
        '
        Me.ColStockPrice.Caption = "السعر"
        Me.ColStockPrice.DisplayFormat.FormatString = "n2"
        Me.ColStockPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColStockPrice.FieldName = "StockPrice"
        Me.ColStockPrice.MinWidth = 23
        Me.ColStockPrice.Name = "ColStockPrice"
        Me.ColStockPrice.OptionsColumn.AllowSize = False
        Me.ColStockPrice.OptionsColumn.ReadOnly = True
        Me.ColStockPrice.Visible = True
        Me.ColStockPrice.VisibleIndex = 8
        Me.ColStockPrice.Width = 69
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "كود السند"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MinWidth = 23
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.OptionsColumn.ReadOnly = True
        Me.ColDocCode.Width = 85
        '
        'ColStockUnit
        '
        Me.ColStockUnit.Caption = "الوحدة"
        Me.ColStockUnit.FieldName = "StockUnit"
        Me.ColStockUnit.MinWidth = 23
        Me.ColStockUnit.Name = "ColStockUnit"
        Me.ColStockUnit.OptionsColumn.AllowSize = False
        Me.ColStockUnit.OptionsColumn.ReadOnly = True
        Me.ColStockUnit.Visible = True
        Me.ColStockUnit.VisibleIndex = 5
        Me.ColStockUnit.Width = 69
        '
        'ColUnitPrice
        '
        Me.ColUnitPrice.Caption = "سعر الوحدة"
        Me.ColUnitPrice.FieldName = "UnitPrice"
        Me.ColUnitPrice.MinWidth = 27
        Me.ColUnitPrice.Name = "ColUnitPrice"
        Me.ColUnitPrice.Visible = True
        Me.ColUnitPrice.VisibleIndex = 9
        Me.ColUnitPrice.Width = 100
        '
        'ColStockQuantity
        '
        Me.ColStockQuantity.Caption = "الكمية"
        Me.ColStockQuantity.DisplayFormat.FormatString = "n2"
        Me.ColStockQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColStockQuantity.FieldName = "StockQuantity"
        Me.ColStockQuantity.MinWidth = 23
        Me.ColStockQuantity.Name = "ColStockQuantity"
        Me.ColStockQuantity.OptionsColumn.AllowSize = False
        Me.ColStockQuantity.OptionsColumn.ReadOnly = True
        Me.ColStockQuantity.Visible = True
        Me.ColStockQuantity.VisibleIndex = 6
        Me.ColStockQuantity.Width = 65
        '
        'ColInputUser
        '
        Me.ColInputUser.Caption = "المستخدم"
        Me.ColInputUser.FieldName = "InputUser"
        Me.ColInputUser.MinWidth = 23
        Me.ColInputUser.Name = "ColInputUser"
        Me.ColInputUser.OptionsColumn.ReadOnly = True
        Me.ColInputUser.Width = 85
        '
        'ColInputDateTime
        '
        Me.ColInputDateTime.Caption = "وقت الادخال"
        Me.ColInputDateTime.FieldName = "InputDateTime"
        Me.ColInputDateTime.MinWidth = 23
        Me.ColInputDateTime.Name = "ColInputDateTime"
        Me.ColInputDateTime.OptionsColumn.ReadOnly = True
        Me.ColInputDateTime.Width = 85
        '
        'ColDocAmount
        '
        Me.ColDocAmount.Caption = "المبلغ"
        Me.ColDocAmount.DisplayFormat.FormatString = "n2"
        Me.ColDocAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColDocAmount.FieldName = "DocAmount"
        Me.ColDocAmount.MinWidth = 23
        Me.ColDocAmount.Name = "ColDocAmount"
        Me.ColDocAmount.OptionsColumn.AllowSize = False
        Me.ColDocAmount.OptionsColumn.ReadOnly = True
        Me.ColDocAmount.Visible = True
        Me.ColDocAmount.VisibleIndex = 10
        Me.ColDocAmount.Width = 108
        '
        'ColStockBarcode
        '
        Me.ColStockBarcode.Caption = "باركود"
        Me.ColStockBarcode.FieldName = "StockBarcode"
        Me.ColStockBarcode.MinWidth = 23
        Me.ColStockBarcode.Name = "ColStockBarcode"
        Me.ColStockBarcode.OptionsColumn.AllowSize = False
        Me.ColStockBarcode.OptionsColumn.ReadOnly = True
        Me.ColStockBarcode.Visible = True
        Me.ColStockBarcode.VisibleIndex = 4
        Me.ColStockBarcode.Width = 135
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.MinWidth = 23
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.[True]
        Me.ColItemName.OptionsColumn.ReadOnly = True
        Me.ColItemName.Width = 85
        '
        'ColDocCurrency
        '
        Me.ColDocCurrency.Caption = "العملة"
        Me.ColDocCurrency.FieldName = "CurrencyCode"
        Me.ColDocCurrency.MinWidth = 27
        Me.ColDocCurrency.Name = "ColDocCurrency"
        Me.ColDocCurrency.OptionsColumn.AllowSize = False
        Me.ColDocCurrency.OptionsColumn.ReadOnly = True
        Me.ColDocCurrency.Visible = True
        Me.ColDocCurrency.VisibleIndex = 7
        Me.ColDocCurrency.Width = 73
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        EditorButtonImageOptions2.Image = CType(resources.GetObject("EditorButtonImageOptions2.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.SimpleButton1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(500, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButton2
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 351)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1011, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextPurchaseOrSale
        Me.LayoutControlItem2.Location = New System.Drawing.Point(273, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(232, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(127, 16)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem7})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1339, 545)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 42)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1305, 422)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(56, 464)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1249, 49)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TextItemName
        Me.LayoutControlItem6.Location = New System.Drawing.Point(639, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(423, 42)
        Me.LayoutControlItem6.Text = "الصنف"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(639, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.StockID
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1062, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(243, 42)
        Me.LayoutControlItem3.Text = "الصنف:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(33, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SimpleButton3
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 464)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(56, 49)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(56, 49)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(56, 49)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LastPrices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButton2
        Me.ClientSize = New System.Drawing.Size(1339, 545)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("LastPrices.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Name = "LastPrices"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LastPrices"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.StockID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemHyperLinkEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextPurchaseOrSale As TextBox
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ColDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColReferanceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColStockUnit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColInputUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColInputDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStockBarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StockID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColDocCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents RepositoryItemHyperLinkEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
    Friend WithEvents ColUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
