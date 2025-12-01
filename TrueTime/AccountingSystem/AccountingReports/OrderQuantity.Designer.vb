<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderQuantity
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderQuantity))
        Me.TextEditOrderQuantity = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControlItem = New DevExpress.XtraEditors.LabelControl()
        Me.TextEditItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TextEditOrderQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextEditOrderQuantity
        '
        Me.TextEditOrderQuantity.Location = New System.Drawing.Point(16, 136)
        Me.TextEditOrderQuantity.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextEditOrderQuantity.Name = "TextEditOrderQuantity"
        Me.TextEditOrderQuantity.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEditOrderQuantity.Properties.Appearance.Options.UseFont = True
        Me.TextEditOrderQuantity.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEditOrderQuantity.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextEditOrderQuantity.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextEditOrderQuantity.Size = New System.Drawing.Size(239, 48)
        Me.TextEditOrderQuantity.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 112)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 16)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "كمية الطلب :"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.motorcycle_delivery_single_box_32
        Me.SimpleButton1.Location = New System.Drawing.Point(215, 216)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(101, 28)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "موافق"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(414, 216)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(101, 28)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "الغاء"
        '
        'LabelControlItem
        '
        Me.LabelControlItem.Location = New System.Drawing.Point(16, 15)
        Me.LabelControlItem.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.LabelControlItem.Name = "LabelControlItem"
        Me.LabelControlItem.Size = New System.Drawing.Size(33, 16)
        Me.LabelControlItem.TabIndex = 1
        Me.LabelControlItem.Text = "الصنف:"
        '
        'TextEditItemNo
        '
        Me.TextEditItemNo.Location = New System.Drawing.Point(16, 47)
        Me.TextEditItemNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TextEditItemNo.Name = "TextEditItemNo"
        Me.TextEditItemNo.Size = New System.Drawing.Size(499, 34)
        Me.TextEditItemNo.TabIndex = 4
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton4.Appearance.Options.UseBackColor = True
        Me.SimpleButton4.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.delivery_32
        Me.SimpleButton4.Location = New System.Drawing.Point(16, 216)
        Me.SimpleButton4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(101, 28)
        Me.SimpleButton4.TabIndex = 2
        Me.SimpleButton4.Text = "موافق"
        '
        'OrderQuantity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 296)
        Me.Controls.Add(Me.TextEditItemNo)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControlItem)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TextEditOrderQuantity)
        Me.IconOptions.Image = CType(resources.GetObject("OrderQuantity.IconOptions.Image"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OrderQuantity"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "كمية الطلب"
        CType(Me.TextEditOrderQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextEditOrderQuantity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControlItem As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
End Class
