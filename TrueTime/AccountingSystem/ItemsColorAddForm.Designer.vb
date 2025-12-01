<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsColorAddForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsColorAddForm))
        Me.ColorPickEdit1 = New DevExpress.XtraEditors.ColorPickEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextColorName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextColorHEX = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TextID = New DevExpress.XtraEditors.TextEdit()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        CType(Me.ColorPickEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextColorName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextColorHEX.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColorPickEdit1
        '
        Me.ColorPickEdit1.EditValue = System.Drawing.Color.Empty
        Me.ColorPickEdit1.Location = New System.Drawing.Point(107, 108)
        Me.ColorPickEdit1.Name = "ColorPickEdit1"
        Me.ColorPickEdit1.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.ColorPickEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorPickEdit1.Properties.ColorText = DevExpress.XtraEditors.Controls.ColorText.[Integer]
        Me.ColorPickEdit1.Properties.ShowSystemColors = False
        Me.ColorPickEdit1.Properties.ShowWebColors = False
        Me.ColorPickEdit1.Size = New System.Drawing.Size(272, 24)
        Me.ColorPickEdit1.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 111)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(30, 17)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "اللون:"
        '
        'TextColorName
        '
        Me.TextColorName.Location = New System.Drawing.Point(107, 73)
        Me.TextColorName.Name = "TextColorName"
        Me.TextColorName.Size = New System.Drawing.Size(272, 24)
        Me.TextColorName.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 76)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 17)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "اسم اللون:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(107, 205)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(132, 23)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "موافق"
        '
        'TextColorHEX
        '
        Me.TextColorHEX.Location = New System.Drawing.Point(107, 138)
        Me.TextColorHEX.Name = "TextColorHEX"
        Me.TextColorHEX.Size = New System.Drawing.Size(272, 24)
        Me.TextColorHEX.TabIndex = 4
        Me.TextColorHEX.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 141)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(27, 17)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "HEX:"
        Me.LabelControl3.Visible = False
        '
        'TextID
        '
        Me.TextID.Location = New System.Drawing.Point(328, 12)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(77, 24)
        Me.TextID.TabIndex = 5
        Me.TextID.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnDelete.Appearance.Options.UseBackColor = True
        Me.BtnDelete.Location = New System.Drawing.Point(245, 205)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(134, 23)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "حذف"
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(108, 169)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(271, 24)
        Me.TextEdit1.TabIndex = 6
        Me.TextEdit1.Visible = False
        '
        'ItemsColorAddForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 246)
        Me.Controls.Add(Me.TextEdit1)
        Me.Controls.Add(Me.TextID)
        Me.Controls.Add(Me.TextColorHEX)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.TextColorName)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ColorPickEdit1)
        Me.IconOptions.Image = CType(resources.GetObject("ItemsColorAddForm.IconOptions.Image"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ItemsColorAddForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ColorPickEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextColorName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextColorHEX.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColorPickEdit1 As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextColorName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextColorHEX As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
End Class
