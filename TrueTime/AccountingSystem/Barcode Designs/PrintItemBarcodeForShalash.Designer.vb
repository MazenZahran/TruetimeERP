<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintItemBarcodeForShalash
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
        Me.TxtBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.TxtItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.DateEditLastPurchaseDate = New DevExpress.XtraEditors.DateEdit()
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.txtQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.DocumentViewer1 = New DevExpress.XtraPrinting.Preview.DocumentViewer()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditLastPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditLastPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtBarcode)
        Me.LayoutControl1.Controls.Add(Me.TxtItemNo)
        Me.LayoutControl1.Controls.Add(Me.DateEditLastPurchaseDate)
        Me.LayoutControl1.Controls.Add(Me.BtnPrint)
        Me.LayoutControl1.Controls.Add(Me.txtQuantity)
        Me.LayoutControl1.Controls.Add(Me.DocumentViewer1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(432, 423)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtBarcode
        '
        Me.TxtBarcode.Location = New System.Drawing.Point(16, 50)
        Me.TxtBarcode.Name = "TxtBarcode"
        Me.TxtBarcode.Properties.ReadOnly = True
        Me.TxtBarcode.Size = New System.Drawing.Size(337, 28)
        Me.TxtBarcode.StyleController = Me.LayoutControl1
        Me.TxtBarcode.TabIndex = 9
        '
        'TxtItemNo
        '
        Me.TxtItemNo.Location = New System.Drawing.Point(16, 16)
        Me.TxtItemNo.Name = "TxtItemNo"
        Me.TxtItemNo.Properties.ReadOnly = True
        Me.TxtItemNo.Size = New System.Drawing.Size(337, 28)
        Me.TxtItemNo.StyleController = Me.LayoutControl1
        Me.TxtItemNo.TabIndex = 8
        '
        'DateEditLastPurchaseDate
        '
        Me.DateEditLastPurchaseDate.EditValue = Nothing
        Me.DateEditLastPurchaseDate.Location = New System.Drawing.Point(16, 342)
        Me.DateEditLastPurchaseDate.Name = "DateEditLastPurchaseDate"
        Me.DateEditLastPurchaseDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditLastPurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditLastPurchaseDate.Properties.ReadOnly = True
        Me.DateEditLastPurchaseDate.Size = New System.Drawing.Size(400, 28)
        Me.DateEditLastPurchaseDate.StyleController = Me.LayoutControl1
        Me.DateEditLastPurchaseDate.TabIndex = 7
        '
        'BtnPrint
        '
        Me.BtnPrint.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnPrint.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Appearance.Options.UseBackColor = True
        Me.BtnPrint.Appearance.Options.UseFont = True
        Me.BtnPrint.Location = New System.Drawing.Point(16, 376)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(400, 31)
        Me.BtnPrint.StyleController = Me.LayoutControl1
        Me.BtnPrint.TabIndex = 6
        Me.BtnPrint.Text = "طباعة"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(16, 103)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Properties.Appearance.Options.UseFont = True
        Me.txtQuantity.Properties.Appearance.Options.UseTextOptions = True
        Me.txtQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtQuantity.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.txtQuantity.Size = New System.Drawing.Size(400, 40)
        Me.txtQuantity.StyleController = Me.LayoutControl1
        Me.txtQuantity.TabIndex = 5
        '
        'DocumentViewer1
        '
        Me.DocumentViewer1.IsMetric = False
        Me.DocumentViewer1.Location = New System.Drawing.Point(16, 149)
        Me.DocumentViewer1.Name = "DocumentViewer1"
        Me.DocumentViewer1.Size = New System.Drawing.Size(400, 187)
        Me.DocumentViewer1.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(432, 423)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DocumentViewer1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 133)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(406, 193)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtQuantity
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(406, 65)
        Me.LayoutControlItem2.Text = "الكمية"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(47, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BtnPrint
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 360)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(406, 37)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DateEditLastPurchaseDate
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 326)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(406, 34)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtItemNo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(406, 34)
        Me.LayoutControlItem5.Text = "رقم الصنف"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(47, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtBarcode
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(406, 34)
        Me.LayoutControlItem6.Text = "الباركود"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(47, 13)
        Me.LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'PrintItemBarcodeForShalash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 423)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "PrintItemBarcodeForShalash"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "PrintItemBarcodeForShalash"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditLastPurchaseDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditLastPurchaseDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocumentViewer1 As DevExpress.XtraPrinting.Preview.DocumentViewer
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateEditLastPurchaseDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
End Class
