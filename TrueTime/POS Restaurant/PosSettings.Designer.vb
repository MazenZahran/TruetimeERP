<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosSettings))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.ComboItemsViewTemplates = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CheckShowTaqseet = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckSendReceiptByWhatApp = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckPrintReceipt = New DevExpress.XtraEditors.CheckEdit()
        Me.txtPaperSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextPosName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextPosNo = New DevExpress.XtraEditors.TextEdit()
        Me.TextWahreHouse = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.WarehousesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colWarehouseID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colWarehouseNameAR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.WarehousesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.WarehousesTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.ComboItemsViewTemplates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckShowTaqseet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckSendReceiptByWhatApp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaperSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPosName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPosNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextWahreHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WarehousesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ComboItemsViewTemplates)
        Me.LayoutControl1.Controls.Add(Me.CheckShowTaqseet)
        Me.LayoutControl1.Controls.Add(Me.CheckSendReceiptByWhatApp)
        Me.LayoutControl1.Controls.Add(Me.CheckPrintReceipt)
        Me.LayoutControl1.Controls.Add(Me.txtPaperSize)
        Me.LayoutControl1.Controls.Add(Me.TextPosName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextPosNo)
        Me.LayoutControl1.Controls.Add(Me.TextWahreHouse)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(424, 377)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'ComboItemsViewTemplates
        '
        Me.ComboItemsViewTemplates.Location = New System.Drawing.Point(12, 116)
        Me.ComboItemsViewTemplates.Name = "ComboItemsViewTemplates"
        Me.ComboItemsViewTemplates.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboItemsViewTemplates.Properties.Items.AddRange(New Object() {"TileViewWithImages", "TileViewWithoutImages", "WinExplorerItems"})
        Me.ComboItemsViewTemplates.Size = New System.Drawing.Size(288, 22)
        Me.ComboItemsViewTemplates.StyleController = Me.LayoutControl1
        Me.ComboItemsViewTemplates.TabIndex = 12
        '
        'CheckShowTaqseet
        '
        Me.CheckShowTaqseet.Location = New System.Drawing.Point(12, 190)
        Me.CheckShowTaqseet.Name = "CheckShowTaqseet"
        Me.CheckShowTaqseet.Properties.Caption = "عرض عمود التقسيط في قائمة فواتير المبيعات"
        Me.CheckShowTaqseet.Size = New System.Drawing.Size(400, 20)
        Me.CheckShowTaqseet.StyleController = Me.LayoutControl1
        Me.CheckShowTaqseet.TabIndex = 11
        '
        'CheckSendReceiptByWhatApp
        '
        Me.CheckSendReceiptByWhatApp.Location = New System.Drawing.Point(12, 166)
        Me.CheckSendReceiptByWhatApp.Name = "CheckSendReceiptByWhatApp"
        Me.CheckSendReceiptByWhatApp.Properties.Caption = "ارسال سند القبض واتس اب"
        Me.CheckSendReceiptByWhatApp.Size = New System.Drawing.Size(400, 20)
        Me.CheckSendReceiptByWhatApp.StyleController = Me.LayoutControl1
        Me.CheckSendReceiptByWhatApp.TabIndex = 10
        '
        'CheckPrintReceipt
        '
        Me.CheckPrintReceipt.Location = New System.Drawing.Point(12, 142)
        Me.CheckPrintReceipt.Name = "CheckPrintReceipt"
        Me.CheckPrintReceipt.Properties.Caption = "طباعة سند القبض "
        Me.CheckPrintReceipt.Size = New System.Drawing.Size(400, 20)
        Me.CheckPrintReceipt.StyleController = Me.LayoutControl1
        Me.CheckPrintReceipt.TabIndex = 9
        '
        'txtPaperSize
        '
        Me.txtPaperSize.Location = New System.Drawing.Point(12, 90)
        Me.txtPaperSize.Name = "txtPaperSize"
        Me.txtPaperSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPaperSize.Properties.Items.AddRange(New Object() {"A4", "A5", "80*80"})
        Me.txtPaperSize.Size = New System.Drawing.Size(288, 22)
        Me.txtPaperSize.StyleController = Me.LayoutControl1
        Me.txtPaperSize.TabIndex = 8
        '
        'TextPosName
        '
        Me.TextPosName.Location = New System.Drawing.Point(12, 38)
        Me.TextPosName.Name = "TextPosName"
        Me.TextPosName.Properties.ReadOnly = True
        Me.TextPosName.Size = New System.Drawing.Size(288, 22)
        Me.TextPosName.StyleController = Me.LayoutControl1
        Me.TextPosName.TabIndex = 7
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 343)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(400, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "حفظ"
        '
        'TextPosNo
        '
        Me.TextPosNo.Location = New System.Drawing.Point(12, 12)
        Me.TextPosNo.Name = "TextPosNo"
        Me.TextPosNo.Size = New System.Drawing.Size(288, 22)
        Me.TextPosNo.StyleController = Me.LayoutControl1
        Me.TextPosNo.TabIndex = 4
        '
        'TextWahreHouse
        '
        Me.TextWahreHouse.Location = New System.Drawing.Point(12, 64)
        Me.TextWahreHouse.Name = "TextWahreHouse"
        Me.TextWahreHouse.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextWahreHouse.Properties.DataSource = Me.WarehousesBindingSource
        Me.TextWahreHouse.Properties.DisplayMember = "WarehouseNameAR"
        Me.TextWahreHouse.Properties.NullText = ""
        Me.TextWahreHouse.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.TextWahreHouse.Properties.ReadOnly = True
        Me.TextWahreHouse.Properties.ValueMember = "WarehouseID"
        Me.TextWahreHouse.Size = New System.Drawing.Size(288, 22)
        Me.TextWahreHouse.StyleController = Me.LayoutControl1
        Me.TextWahreHouse.TabIndex = 5
        '
        'WarehousesBindingSource
        '
        Me.WarehousesBindingSource.DataMember = "Warehouses"
        Me.WarehousesBindingSource.DataSource = Me.AccountingDataSet
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colWarehouseID, Me.colWarehouseNameAR})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colWarehouseID
        '
        Me.colWarehouseID.FieldName = "WarehouseID"
        Me.colWarehouseID.Name = "colWarehouseID"
        Me.colWarehouseID.Visible = True
        Me.colWarehouseID.VisibleIndex = 0
        '
        'colWarehouseNameAR
        '
        Me.colWarehouseNameAR.FieldName = "WarehouseNameAR"
        Me.colWarehouseNameAR.Name = "colWarehouseNameAR"
        Me.colWarehouseNameAR.Visible = True
        Me.colWarehouseNameAR.VisibleIndex = 1
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(424, 377)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextPosNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem1.Text = "رقم نقطة البيع:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(100, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 202)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(404, 129)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextWahreHouse
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem2.Text = "المستودع الافتراضي:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(100, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 331)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TextPosName
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem4.Text = "اسم نقطة البيع:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(100, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtPaperSize
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem5.Text = "حجم الورق:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(100, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.CheckPrintReceipt
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(404, 24)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.CheckSendReceiptByWhatApp
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 154)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(404, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CheckShowTaqseet
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 178)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(404, 24)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ComboItemsViewTemplates
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(404, 26)
        Me.LayoutControlItem9.Text = "طريقة عرض الأصناف:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(100, 13)
        '
        'WarehousesTableAdapter
        '
        Me.WarehousesTableAdapter.ClearBeforeFill = True
        '
        'PosSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 377)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("PosSettings.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "PosSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اعدادات نقاط البيع"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.ComboItemsViewTemplates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckShowTaqseet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckSendReceiptByWhatApp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckPrintReceipt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaperSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPosName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPosNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextWahreHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WarehousesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextPosNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextPosName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextWahreHouse As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents WarehousesBindingSource As BindingSource
    Friend WithEvents WarehousesTableAdapter As AccountingDataSetTableAdapters.WarehousesTableAdapter
    Friend WithEvents colWarehouseID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colWarehouseNameAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPaperSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckSendReceiptByWhatApp As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckPrintReceipt As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckShowTaqseet As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ComboItemsViewTemplates As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
