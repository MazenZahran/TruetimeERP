<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSSelectSerial
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.GridControlAllSerials = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColTransID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSerialNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSerialStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySerialStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ColPurchaseWarrantySrart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryPurchaseWarrantySrart = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColPurchaseWarrantyEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryPurchaseWarrantyEnd = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColSaleWarrantyStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySaleWarrantyStart = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColSaleWarrantyEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositorySaleWarrantyEnd = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ColItemNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSelectedSerial = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextItemNoInItemsSerialOut = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlAllSerials, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySerialStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantySrart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantyEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyStart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositorySaleWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemNoInItemsSerialOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextItemNoInItemsSerialOut)
        Me.LayoutControl1.Controls.Add(Me.GridControlAllSerials)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(422, 382)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(422, 382)
        Me.Root.TextVisible = False
        '
        'GridControlAllSerials
        '
        Me.GridControlAllSerials.Location = New System.Drawing.Point(12, 36)
        Me.GridControlAllSerials.MainView = Me.GridView1
        Me.GridControlAllSerials.Name = "GridControlAllSerials"
        Me.GridControlAllSerials.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositorySerialStatus, Me.RepositoryPurchaseWarrantySrart, Me.RepositoryPurchaseWarrantyEnd, Me.RepositorySaleWarrantyStart, Me.RepositorySaleWarrantyEnd})
        Me.GridControlAllSerials.Size = New System.Drawing.Size(398, 334)
        Me.GridControlAllSerials.TabIndex = 6
        Me.GridControlAllSerials.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColTransID, Me.ColSerialNumber, Me.ColSerialStatus, Me.ColPurchaseWarrantySrart, Me.ColPurchaseWarrantyEnd, Me.ColSaleWarrantyStart, Me.ColSaleWarrantyEnd, Me.ColItemNo, Me.ColDocCode, Me.GridColumn1, Me.GridColumn2, Me.ColSelectedSerial})
        Me.GridView1.GridControl = Me.GridControlAllSerials
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.FindNullPrompt = "ابحث من هنا ...."
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColTransID
        '
        Me.ColTransID.Caption = "TransID"
        Me.ColTransID.FieldName = "TransID"
        Me.ColTransID.Name = "ColTransID"
        '
        'ColSerialNumber
        '
        Me.ColSerialNumber.AppearanceHeader.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.ColSerialNumber.AppearanceHeader.Options.UseBackColor = True
        Me.ColSerialNumber.Caption = "SerialNumber"
        Me.ColSerialNumber.FieldName = "SerialNumber"
        Me.ColSerialNumber.Name = "ColSerialNumber"
        Me.ColSerialNumber.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SerialNumber", "{0}")})
        Me.ColSerialNumber.Visible = True
        Me.ColSerialNumber.VisibleIndex = 0
        Me.ColSerialNumber.Width = 130
        '
        'ColSerialStatus
        '
        Me.ColSerialStatus.Caption = "الحالة"
        Me.ColSerialStatus.ColumnEdit = Me.RepositorySerialStatus
        Me.ColSerialStatus.FieldName = "SerialStatus"
        Me.ColSerialStatus.Name = "ColSerialStatus"
        Me.ColSerialStatus.OptionsColumn.AllowEdit = False
        Me.ColSerialStatus.Visible = True
        Me.ColSerialStatus.VisibleIndex = 1
        Me.ColSerialStatus.Width = 86
        '
        'RepositorySerialStatus
        '
        Me.RepositorySerialStatus.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositorySerialStatus.AutoHeight = False
        Me.RepositorySerialStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySerialStatus.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SerialStatus", "حالة السيريال")})
        Me.RepositorySerialStatus.DisplayMember = "SerialStatus"
        Me.RepositorySerialStatus.Name = "RepositorySerialStatus"
        Me.RepositorySerialStatus.NullText = ""
        Me.RepositorySerialStatus.ValueMember = "ID"
        '
        'ColPurchaseWarrantySrart
        '
        Me.ColPurchaseWarrantySrart.Caption = "بداية كفالة الشراء"
        Me.ColPurchaseWarrantySrart.ColumnEdit = Me.RepositoryPurchaseWarrantySrart
        Me.ColPurchaseWarrantySrart.FieldName = "PurchaseWarrantyStart"
        Me.ColPurchaseWarrantySrart.Name = "ColPurchaseWarrantySrart"
        Me.ColPurchaseWarrantySrart.Width = 86
        '
        'RepositoryPurchaseWarrantySrart
        '
        Me.RepositoryPurchaseWarrantySrart.AutoHeight = False
        Me.RepositoryPurchaseWarrantySrart.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantySrart.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositoryPurchaseWarrantySrart.Name = "RepositoryPurchaseWarrantySrart"
        Me.RepositoryPurchaseWarrantySrart.UseMaskAsDisplayFormat = True
        '
        'ColPurchaseWarrantyEnd
        '
        Me.ColPurchaseWarrantyEnd.Caption = "نهاية كفالة الشراء"
        Me.ColPurchaseWarrantyEnd.ColumnEdit = Me.RepositoryPurchaseWarrantyEnd
        Me.ColPurchaseWarrantyEnd.FieldName = "PurchaseWarrantyEnd"
        Me.ColPurchaseWarrantyEnd.Name = "ColPurchaseWarrantyEnd"
        Me.ColPurchaseWarrantyEnd.Width = 86
        '
        'RepositoryPurchaseWarrantyEnd
        '
        Me.RepositoryPurchaseWarrantyEnd.AutoHeight = False
        Me.RepositoryPurchaseWarrantyEnd.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryPurchaseWarrantyEnd.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositoryPurchaseWarrantyEnd.Name = "RepositoryPurchaseWarrantyEnd"
        Me.RepositoryPurchaseWarrantyEnd.UseMaskAsDisplayFormat = True
        '
        'ColSaleWarrantyStart
        '
        Me.ColSaleWarrantyStart.Caption = "بداية كفالة البيع"
        Me.ColSaleWarrantyStart.ColumnEdit = Me.RepositorySaleWarrantyStart
        Me.ColSaleWarrantyStart.FieldName = "SaleWarrantyStart"
        Me.ColSaleWarrantyStart.Name = "ColSaleWarrantyStart"
        Me.ColSaleWarrantyStart.Width = 86
        '
        'RepositorySaleWarrantyStart
        '
        Me.RepositorySaleWarrantyStart.AutoHeight = False
        Me.RepositorySaleWarrantyStart.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyStart.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyStart.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositorySaleWarrantyStart.Name = "RepositorySaleWarrantyStart"
        Me.RepositorySaleWarrantyStart.UseMaskAsDisplayFormat = True
        '
        'ColSaleWarrantyEnd
        '
        Me.ColSaleWarrantyEnd.Caption = "نهاية كفالة البيع"
        Me.ColSaleWarrantyEnd.ColumnEdit = Me.RepositorySaleWarrantyEnd
        Me.ColSaleWarrantyEnd.FieldName = "SaleWarrantyEnd"
        Me.ColSaleWarrantyEnd.Name = "ColSaleWarrantyEnd"
        Me.ColSaleWarrantyEnd.Width = 86
        '
        'RepositorySaleWarrantyEnd
        '
        Me.RepositorySaleWarrantyEnd.AutoHeight = False
        Me.RepositorySaleWarrantyEnd.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyEnd.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositorySaleWarrantyEnd.MaskSettings.Set("mask", "dd-MM-yyyy")
        Me.RepositorySaleWarrantyEnd.Name = "RepositorySaleWarrantyEnd"
        Me.RepositorySaleWarrantyEnd.UseMaskAsDisplayFormat = True
        '
        'ColItemNo
        '
        Me.ColItemNo.Caption = "ItemNo"
        Me.ColItemNo.FieldName = "ItemNo"
        Me.ColItemNo.Name = "ColItemNo"
        Me.ColItemNo.Width = 86
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "DocCode"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.Width = 86
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "TransType"
        Me.GridColumn1.FieldName = "TransType"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Width = 86
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "SerialID"
        Me.GridColumn2.FieldName = "SerialID"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Width = 96
        '
        'ColSelectedSerial
        '
        Me.ColSelectedSerial.Caption = "SelectedSerial"
        Me.ColSelectedSerial.FieldName = "SelectedSerial"
        Me.ColSelectedSerial.Name = "ColSelectedSerial"
        Me.ColSelectedSerial.OptionsColumn.AllowEdit = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControlAllSerials
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(402, 338)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'TextItemNoInItemsSerialOut
        '
        Me.TextItemNoInItemsSerialOut.Location = New System.Drawing.Point(12, 12)
        Me.TextItemNoInItemsSerialOut.Name = "TextItemNoInItemsSerialOut"
        Me.TextItemNoInItemsSerialOut.Size = New System.Drawing.Size(290, 20)
        Me.TextItemNoInItemsSerialOut.StyleController = Me.LayoutControl1
        Me.TextItemNoInItemsSerialOut.TabIndex = 7
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextItemNoInItemsSerialOut
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(402, 24)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 13)
        '
        'POSSelectSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(422, 382)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "POSSelectSerial"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "اختيار سيريال للصنف"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlAllSerials, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySerialStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantySrart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantySrart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryPurchaseWarrantyEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyStart.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyEnd.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositorySaleWarrantyEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemNoInItemsSerialOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControlAllSerials As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColTransID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSerialNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSerialStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySerialStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents ColPurchaseWarrantySrart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryPurchaseWarrantySrart As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColPurchaseWarrantyEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryPurchaseWarrantyEnd As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColSaleWarrantyStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySaleWarrantyStart As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColSaleWarrantyEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositorySaleWarrantyEnd As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents ColItemNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSelectedSerial As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextItemNoInItemsSerialOut As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
