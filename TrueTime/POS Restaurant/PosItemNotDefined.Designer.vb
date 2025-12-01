<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosItemNotDefined
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosItemNotDefined))
        Me.SimpleButtonClose = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDefineNewItem = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControlBarcode = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'SimpleButtonClose
        '
        Me.SimpleButtonClose.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButtonClose.Appearance.Options.UseBackColor = True
        Me.SimpleButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButtonClose.Location = New System.Drawing.Point(237, 341)
        Me.SimpleButtonClose.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButtonClose.Name = "SimpleButtonClose"
        Me.SimpleButtonClose.Size = New System.Drawing.Size(197, 58)
        Me.SimpleButtonClose.TabIndex = 0
        Me.SimpleButtonClose.Text = "موافق"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(77, 102)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(254, 39)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "الصنف غير معرف"
        '
        'BtnDefineNewItem
        '
        Me.BtnDefineNewItem.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnDefineNewItem.Appearance.Options.UseBackColor = True
        Me.BtnDefineNewItem.Location = New System.Drawing.Point(12, 341)
        Me.BtnDefineNewItem.Name = "BtnDefineNewItem"
        Me.BtnDefineNewItem.Size = New System.Drawing.Size(197, 58)
        Me.BtnDefineNewItem.TabIndex = 3
        Me.BtnDefineNewItem.Text = "تعريف الصنف"
        Me.BtnDefineNewItem.Visible = False
        '
        'LabelControlBarcode
        '
        Me.LabelControlBarcode.Location = New System.Drawing.Point(12, 12)
        Me.LabelControlBarcode.Name = "LabelControlBarcode"
        Me.LabelControlBarcode.Size = New System.Drawing.Size(124, 17)
        Me.LabelControlBarcode.TabIndex = 4
        Me.LabelControlBarcode.Text = "LabelControlBarCode"
        '
        'PosItemNotDefined
        '
        Me.Appearance.BackColor = System.Drawing.Color.OrangeRed
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.SimpleButtonClose
        Me.ClientSize = New System.Drawing.Size(448, 415)
        Me.Controls.Add(Me.LabelControlBarcode)
        Me.Controls.Add(Me.BtnDefineNewItem)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SimpleButtonClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.SvgImage = CType(resources.GetObject("PosItemNotDefined.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "PosItemNotDefined"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PosItemNotDefined"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SimpleButtonClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnDefineNewItem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControlBarcode As DevExpress.XtraEditors.LabelControl
End Class
