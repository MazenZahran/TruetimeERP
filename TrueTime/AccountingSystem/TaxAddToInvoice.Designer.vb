<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaxAddToInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaxAddToInvoice))
        Me.DocAmountBeforeTax = New DevExpress.XtraEditors.TextEdit()
        Me.VATPercentage = New DevExpress.XtraEditors.TextEdit()
        Me.DocAmountAfterTax = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TaxAmount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.DocAmountBeforeTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VATPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocAmountAfterTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaxAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DocAmountBeforeTax
        '
        Me.DocAmountBeforeTax.Location = New System.Drawing.Point(132, 30)
        Me.DocAmountBeforeTax.Name = "DocAmountBeforeTax"
        Me.DocAmountBeforeTax.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DocAmountBeforeTax.Properties.Appearance.Options.UseForeColor = True
        Me.DocAmountBeforeTax.Properties.ReadOnly = True
        Me.DocAmountBeforeTax.Size = New System.Drawing.Size(151, 20)
        Me.DocAmountBeforeTax.TabIndex = 0
        '
        'VATPercentage
        '
        Me.VATPercentage.Location = New System.Drawing.Point(132, 70)
        Me.VATPercentage.Name = "VATPercentage"
        Me.VATPercentage.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.VATPercentage.Properties.Appearance.Options.UseForeColor = True
        Me.VATPercentage.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.VATPercentage.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.VATPercentage.Properties.MaskSettings.Set("mask", "f")
        Me.VATPercentage.Properties.UseMaskAsDisplayFormat = True
        Me.VATPercentage.Size = New System.Drawing.Size(67, 20)
        Me.VATPercentage.TabIndex = 1
        '
        'DocAmountAfterTax
        '
        Me.DocAmountAfterTax.Location = New System.Drawing.Point(132, 145)
        Me.DocAmountAfterTax.Name = "DocAmountAfterTax"
        Me.DocAmountAfterTax.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DocAmountAfterTax.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DocAmountAfterTax.Properties.Appearance.Options.UseBackColor = True
        Me.DocAmountAfterTax.Properties.Appearance.Options.UseForeColor = True
        Me.DocAmountAfterTax.Properties.ReadOnly = True
        Me.DocAmountAfterTax.Size = New System.Drawing.Size(151, 20)
        Me.DocAmountAfterTax.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(12, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(117, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "مبلغ الفاتورة قبل الضريبة:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(68, 73)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "نسبة الضريبة:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(68, 109)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "مبلغ الضريبة:"
        '
        'TaxAmount
        '
        Me.TaxAmount.Location = New System.Drawing.Point(132, 106)
        Me.TaxAmount.Name = "TaxAmount"
        Me.TaxAmount.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TaxAmount.Properties.Appearance.Options.UseForeColor = True
        Me.TaxAmount.Properties.ReadOnly = True
        Me.TaxAmount.Size = New System.Drawing.Size(151, 20)
        Me.TaxAmount.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(12, 148)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(115, 13)
        Me.LabelControl4.TabIndex = 3
        Me.LabelControl4.Text = "مبلغ الفاتورة بعد الضريبة:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 203)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(96, 23)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "اعتماد"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(297, 3)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(56, 23)
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "الغاء"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(205, 73)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(8, 13)
        Me.LabelControl5.TabIndex = 5
        Me.LabelControl5.Text = "%"
        '
        'TaxAddToInvoice
        '
        Me.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButton2
        Me.ClientSize = New System.Drawing.Size(356, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DocAmountAfterTax)
        Me.Controls.Add(Me.TaxAmount)
        Me.Controls.Add(Me.VATPercentage)
        Me.Controls.Add(Me.DocAmountBeforeTax)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.Image = CType(resources.GetObject("TaxAddToInvoice.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "TaxAddToInvoice"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "اضافة ضريبة على الفاتورة"
        CType(Me.DocAmountBeforeTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VATPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocAmountAfterTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaxAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DocAmountBeforeTax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents VATPercentage As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocAmountAfterTax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TaxAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
End Class
