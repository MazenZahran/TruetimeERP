<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderItemShalash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderItemShalash))
        Me.TextQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.ItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.ItemName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.ItemBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.ItemNo2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TextLastOrderd = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TextLastDateOrderd = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextWareHouse = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextEditLastQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TextQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemNo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLastOrderd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLastDateOrderd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextWareHouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TextEditLastQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextQuantity
        '
        Me.TextQuantity.Location = New System.Drawing.Point(191, 305)
        Me.TextQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.TextQuantity.Name = "TextQuantity"
        Me.TextQuantity.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextQuantity.Properties.Appearance.Options.UseFont = True
        Me.TextQuantity.Properties.Appearance.Options.UseTextOptions = True
        Me.TextQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextQuantity.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextQuantity.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.TextQuantity.Properties.MaskSettings.Set("mask", "N0")
        Me.TextQuantity.Properties.UseMaskAsDisplayFormat = True
        Me.TextQuantity.Size = New System.Drawing.Size(148, 46)
        Me.TextQuantity.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.delivery_32
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(347, 381)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(104, 53)
        Me.SimpleButton1.TabIndex = 1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.motorcycle_delivery_single_box_32
        Me.SimpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(208, 381)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(104, 53)
        Me.SimpleButton2.TabIndex = 2
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(122, 310)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(64, 50)
        Me.SimpleButton3.TabIndex = 3
        Me.SimpleButton3.Text = "+"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(345, 310)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(64, 50)
        Me.SimpleButton4.TabIndex = 3
        Me.SimpleButton4.Text = "-"
        '
        'ItemNo
        '
        Me.ItemNo.Location = New System.Drawing.Point(227, 48)
        Me.ItemNo.Margin = New System.Windows.Forms.Padding(2)
        Me.ItemNo.Name = "ItemNo"
        Me.ItemNo.Properties.ReadOnly = True
        Me.ItemNo.Size = New System.Drawing.Size(94, 22)
        Me.ItemNo.TabIndex = 6
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(343, 52)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "رقم الصنف:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(361, 110)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "الصنف:"
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(13, 103)
        Me.ItemName.Margin = New System.Windows.Forms.Padding(2)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Properties.ReadOnly = True
        Me.ItemName.Size = New System.Drawing.Size(308, 22)
        Me.ItemName.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(360, 78)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "الباركود:"
        '
        'ItemBarcode
        '
        Me.ItemBarcode.Location = New System.Drawing.Point(12, 74)
        Me.ItemBarcode.Margin = New System.Windows.Forms.Padding(2)
        Me.ItemBarcode.Name = "ItemBarcode"
        Me.ItemBarcode.Properties.ReadOnly = True
        Me.ItemBarcode.Size = New System.Drawing.Size(308, 22)
        Me.ItemBarcode.TabIndex = 6
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(169, 52)
        Me.LabelControl4.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "رقم 2:"
        '
        'ItemNo2
        '
        Me.ItemNo2.Location = New System.Drawing.Point(12, 48)
        Me.ItemNo2.Margin = New System.Windows.Forms.Padding(2)
        Me.ItemNo2.Name = "ItemNo2"
        Me.ItemNo2.Properties.ReadOnly = True
        Me.ItemNo2.Size = New System.Drawing.Size(144, 22)
        Me.ItemNo2.TabIndex = 6
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(289, 36)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "كمية بانتظار الموافقة:"
        '
        'TextLastOrderd
        '
        Me.TextLastOrderd.EditValue = CType(0, Short)
        Me.TextLastOrderd.Location = New System.Drawing.Point(67, 28)
        Me.TextLastOrderd.Margin = New System.Windows.Forms.Padding(2)
        Me.TextLastOrderd.Name = "TextLastOrderd"
        Me.TextLastOrderd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextLastOrderd.Properties.NullText = "0"
        Me.TextLastOrderd.Properties.ReadOnly = True
        Me.TextLastOrderd.Size = New System.Drawing.Size(189, 22)
        Me.TextLastOrderd.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(332, 68)
        Me.LabelControl6.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "اخر طلبية:"
        '
        'TextLastDateOrderd
        '
        Me.TextLastDateOrderd.Location = New System.Drawing.Point(67, 61)
        Me.TextLastDateOrderd.Margin = New System.Windows.Forms.Padding(2)
        Me.TextLastDateOrderd.Name = "TextLastDateOrderd"
        Me.TextLastDateOrderd.Properties.ReadOnly = True
        Me.TextLastDateOrderd.Size = New System.Drawing.Size(250, 22)
        Me.TextLastDateOrderd.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextWareHouse)
        Me.GroupBox1.Controls.Add(Me.ItemNo)
        Me.GroupBox1.Controls.Add(Me.ItemName)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.ItemBarcode)
        Me.GroupBox1.Controls.Add(Me.LabelControl4)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.ItemNo2)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Location = New System.Drawing.Point(64, 20)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(400, 139)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "تفاصيل الصنف"
        '
        'TextWareHouse
        '
        Me.TextWareHouse.Location = New System.Drawing.Point(13, 20)
        Me.TextWareHouse.Name = "TextWareHouse"
        Me.TextWareHouse.Size = New System.Drawing.Size(100, 22)
        Me.TextWareHouse.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextEditLastQuantity)
        Me.GroupBox2.Controls.Add(Me.LabelControl5)
        Me.GroupBox2.Controls.Add(Me.TextLastOrderd)
        Me.GroupBox2.Controls.Add(Me.LabelControl7)
        Me.GroupBox2.Controls.Add(Me.LabelControl6)
        Me.GroupBox2.Controls.Add(Me.TextLastDateOrderd)
        Me.GroupBox2.Location = New System.Drawing.Point(64, 163)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(400, 139)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "تفاصيل الطلبيات السابقة"
        '
        'TextEditLastQuantity
        '
        Me.TextEditLastQuantity.Location = New System.Drawing.Point(67, 93)
        Me.TextEditLastQuantity.Margin = New System.Windows.Forms.Padding(2)
        Me.TextEditLastQuantity.Name = "TextEditLastQuantity"
        Me.TextEditLastQuantity.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextEditLastQuantity.Properties.MaskSettings.Set("mask", "N0")
        Me.TextEditLastQuantity.Properties.ReadOnly = True
        Me.TextEditLastQuantity.Properties.UseMaskAsDisplayFormat = True
        Me.TextEditLastQuantity.Size = New System.Drawing.Size(189, 22)
        Me.TextEditLastQuantity.TabIndex = 10
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(296, 101)
        Me.LabelControl7.Margin = New System.Windows.Forms.Padding(2)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(95, 13)
        Me.LabelControl7.TabIndex = 4
        Me.LabelControl7.Text = "الكمية المسموح بها:"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton5.Appearance.Options.UseBackColor = True
        Me.SimpleButton5.ImageOptions.Image = CType(resources.GetObject("SimpleButton5.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton5.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton5.Location = New System.Drawing.Point(79, 381)
        Me.SimpleButton5.Margin = New System.Windows.Forms.Padding(2)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(104, 53)
        Me.SimpleButton5.TabIndex = 2
        '
        'OrderItemShalash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 457)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.TextQuantity)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OrderItemShalash"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "طلب"
        CType(Me.TextQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemNo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLastOrderd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLastDateOrderd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextWareHouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TextEditLastQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ItemBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ItemNo2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextLastOrderd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextLastDateOrderd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEditLastQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextWareHouse As DevExpress.XtraEditors.TextEdit
End Class
