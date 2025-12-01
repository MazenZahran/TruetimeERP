<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosAddParcodeToItem
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
        Me.LookItem = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.LookItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LookItem
        '
        Me.LookItem.Location = New System.Drawing.Point(69, 24)
        Me.LookItem.Name = "LookItem"
        Me.LookItem.Properties.AdvancedModeOptions.Label = "الصنف:"
        Me.LookItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookItem.Properties.DisplayMember = "ItemName"
        Me.LookItem.Properties.NullText = ""
        Me.LookItem.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.LookItem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookItem.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookItem.Properties.ValueMember = "ItemNo"
        Me.LookItem.Size = New System.Drawing.Size(433, 42)
        Me.LookItem.TabIndex = 0
        '
        'PosAddParcodeToItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 455)
        Me.Controls.Add(Me.LookItem)
        Me.Name = "PosAddParcodeToItem"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "PosAddParcodeToItem"
        CType(Me.LookItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LookItem As DevExpress.XtraEditors.LookUpEdit
End Class
