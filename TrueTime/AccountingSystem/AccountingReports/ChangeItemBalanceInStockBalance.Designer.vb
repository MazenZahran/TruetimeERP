<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeItemBalanceInStockBalance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeItemBalanceInStockBalance))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TextItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TextSystemQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextJardQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextDifference = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DocDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextDifferenceAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextItemCost = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextWarehouseID = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TexItemName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSystemQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextJardQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDifference.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDifferenceAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextWarehouseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TexItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextBarcode)
        Me.LayoutControl1.Controls.Add(Me.TexItemName)
        Me.LayoutControl1.Controls.Add(Me.TextWarehouseID)
        Me.LayoutControl1.Controls.Add(Me.TextItemCost)
        Me.LayoutControl1.Controls.Add(Me.TextDifferenceAmount)
        Me.LayoutControl1.Controls.Add(Me.DocDate)
        Me.LayoutControl1.Controls.Add(Me.BtnSave)
        Me.LayoutControl1.Controls.Add(Me.TextDifference)
        Me.LayoutControl1.Controls.Add(Me.TextJardQuantity)
        Me.LayoutControl1.Controls.Add(Me.TextSystemQuantity)
        Me.LayoutControl1.Controls.Add(Me.TextItemNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(435, 399)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(435, 399)
        Me.Root.TextVisible = False
        '
        'TextItemNo
        '
        Me.TextItemNo.Location = New System.Drawing.Point(220, 118)
        Me.TextItemNo.Name = "TextItemNo"
        Me.TextItemNo.Properties.ReadOnly = True
        Me.TextItemNo.Size = New System.Drawing.Size(116, 28)
        Me.TextItemNo.StyleController = Me.LayoutControl1
        Me.TextItemNo.TabIndex = 4
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextItemNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(204, 102)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(205, 34)
        Me.LayoutControlItem1.Text = "الصنف:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(67, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 306)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(409, 33)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'TextSystemQuantity
        '
        Me.TextSystemQuantity.Location = New System.Drawing.Point(16, 152)
        Me.TextSystemQuantity.Name = "TextSystemQuantity"
        Me.TextSystemQuantity.Properties.ReadOnly = True
        Me.TextSystemQuantity.Size = New System.Drawing.Size(320, 28)
        Me.TextSystemQuantity.StyleController = Me.LayoutControl1
        Me.TextSystemQuantity.TabIndex = 5
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextSystemQuantity
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 136)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem2.Text = "الرصيد الحالي:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(67, 13)
        '
        'TextJardQuantity
        '
        Me.TextJardQuantity.Location = New System.Drawing.Point(16, 186)
        Me.TextJardQuantity.Name = "TextJardQuantity"
        Me.TextJardQuantity.Size = New System.Drawing.Size(320, 28)
        Me.TextJardQuantity.StyleController = Me.LayoutControl1
        Me.TextJardQuantity.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextJardQuantity
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 170)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem3.Text = "كمية الجرد:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(67, 13)
        '
        'TextDifference
        '
        Me.TextDifference.Location = New System.Drawing.Point(16, 220)
        Me.TextDifference.Name = "TextDifference"
        Me.TextDifference.Properties.ReadOnly = True
        Me.TextDifference.Size = New System.Drawing.Size(320, 28)
        Me.TextDifference.StyleController = Me.LayoutControl1
        Me.TextDifference.TabIndex = 7
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TextDifference
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 204)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem4.Text = "الفرق:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(67, 13)
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Location = New System.Drawing.Point(16, 355)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(403, 28)
        Me.BtnSave.StyleController = Me.LayoutControl1
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "حفظ"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BtnSave
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 339)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'DocDate
        '
        Me.DocDate.EditValue = Nothing
        Me.DocDate.Location = New System.Drawing.Point(16, 50)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Properties.ReadOnly = True
        Me.DocDate.Size = New System.Drawing.Size(320, 28)
        Me.DocDate.StyleController = Me.LayoutControl1
        Me.DocDate.TabIndex = 9
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.DocDate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem6.Text = "التاريخ:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(67, 13)
        '
        'TextDifferenceAmount
        '
        Me.TextDifferenceAmount.Location = New System.Drawing.Point(16, 288)
        Me.TextDifferenceAmount.Name = "TextDifferenceAmount"
        Me.TextDifferenceAmount.Properties.ReadOnly = True
        Me.TextDifferenceAmount.Size = New System.Drawing.Size(320, 28)
        Me.TextDifferenceAmount.StyleController = Me.LayoutControl1
        Me.TextDifferenceAmount.TabIndex = 10
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextDifferenceAmount
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 272)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem7.Text = "مبلغ الفرق:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(67, 13)
        '
        'TextItemCost
        '
        Me.TextItemCost.Location = New System.Drawing.Point(16, 254)
        Me.TextItemCost.Name = "TextItemCost"
        Me.TextItemCost.Properties.ReadOnly = True
        Me.TextItemCost.Size = New System.Drawing.Size(320, 28)
        Me.TextItemCost.StyleController = Me.LayoutControl1
        Me.TextItemCost.TabIndex = 11
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TextItemCost
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 238)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem8.Text = "سعر التكلفة:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(67, 13)
        '
        'TextWarehouseID
        '
        Me.TextWarehouseID.Location = New System.Drawing.Point(16, 16)
        Me.TextWarehouseID.Name = "TextWarehouseID"
        Me.TextWarehouseID.Properties.ReadOnly = True
        Me.TextWarehouseID.Size = New System.Drawing.Size(320, 28)
        Me.TextWarehouseID.StyleController = Me.LayoutControl1
        Me.TextWarehouseID.TabIndex = 12
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TextWarehouseID
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem9.Text = "المستودع:"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(67, 13)
        '
        'TexItemName
        '
        Me.TexItemName.Location = New System.Drawing.Point(16, 118)
        Me.TexItemName.Name = "TexItemName"
        Me.TexItemName.Properties.ReadOnly = True
        Me.TexItemName.Size = New System.Drawing.Size(198, 28)
        Me.TexItemName.StyleController = Me.LayoutControl1
        Me.TexItemName.TabIndex = 13
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.TexItemName
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(204, 34)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'TextBarcode
        '
        Me.TextBarcode.Location = New System.Drawing.Point(16, 84)
        Me.TextBarcode.Name = "TextBarcode"
        Me.TextBarcode.Properties.ReadOnly = True
        Me.TextBarcode.Size = New System.Drawing.Size(320, 28)
        Me.TextBarcode.StyleController = Me.LayoutControl1
        Me.TextBarcode.TabIndex = 14
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TextBarcode
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(409, 34)
        Me.LayoutControlItem11.Text = "الباركود:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(67, 13)
        '
        'ChangeItemBalanceInStockBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 399)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("ChangeItemBalanceInStockBalance.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "ChangeItemBalanceInStockBalance"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "جرد محزون لصنف واحد"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSystemQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextJardQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDifference.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDifferenceAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextWarehouseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TexItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextDifference As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextJardQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextSystemQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DocDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextDifferenceAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextItemCost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextWarehouseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TexItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
End Class
