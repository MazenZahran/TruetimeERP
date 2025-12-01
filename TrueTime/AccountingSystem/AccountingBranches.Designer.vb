<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountingBranches
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountingBranches))
        Me.TextBranchName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TextBranchName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBranchName
        '
        Me.TextBranchName.Location = New System.Drawing.Point(53, 30)
        Me.TextBranchName.Name = "TextBranchName"
        Me.TextBranchName.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextBranchName.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextBranchName.Properties.AdvancedModeOptions.Label = "اسم الفرع"
        Me.TextBranchName.Properties.AdvancedModeOptions.LabelAppearance.Options.UseImage = True
        Me.TextBranchName.Properties.AdvancedModeOptions.ShiftedLabelAppearance.Options.UseImage = True
        Me.TextBranchName.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextBranchName.Size = New System.Drawing.Size(484, 42)
        Me.TextBranchName.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        Me.SimpleButton1.Location = New System.Drawing.Point(422, 92)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(143, 34)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "حفظ"
        '
        'AccountingBranches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 138)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.TextBranchName)
        Me.IconOptions.SvgImage = CType(resources.GetObject("AccountingBranches.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccountingBranches"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة / تعديل فرع"
        CType(Me.TextBranchName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextBranchName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
