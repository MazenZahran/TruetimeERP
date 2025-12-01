<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemDefineBatch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemDefineBatch))
        Me.TextItemName = New DevExpress.XtraEditors.TextEdit()
        Me.TextItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.TextBatchNo = New DevExpress.XtraEditors.TextEdit()
        Me.DateExpireDate = New DevExpress.XtraEditors.DateEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBatchNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateExpireDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateExpireDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextItemName
        '
        Me.TextItemName.Location = New System.Drawing.Point(188, 12)
        Me.TextItemName.Name = "TextItemName"
        Me.TextItemName.Properties.AdvancedModeOptions.Label = "الصنف"
        Me.TextItemName.Properties.ReadOnly = True
        Me.TextItemName.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextItemName.Size = New System.Drawing.Size(317, 42)
        Me.TextItemName.TabIndex = 3
        '
        'TextItemNo
        '
        Me.TextItemNo.Location = New System.Drawing.Point(22, 12)
        Me.TextItemNo.Name = "TextItemNo"
        Me.TextItemNo.Properties.AdvancedModeOptions.Label = "رقم الصنف"
        Me.TextItemNo.Properties.ReadOnly = True
        Me.TextItemNo.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextItemNo.Size = New System.Drawing.Size(156, 42)
        Me.TextItemNo.TabIndex = 2
        '
        'TextBatchNo
        '
        Me.TextBatchNo.Location = New System.Drawing.Point(22, 76)
        Me.TextBatchNo.Name = "TextBatchNo"
        Me.TextBatchNo.Properties.AdvancedModeOptions.Label = "رقم الباتش"
        Me.TextBatchNo.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextBatchNo.Size = New System.Drawing.Size(235, 42)
        Me.TextBatchNo.TabIndex = 4
        '
        'DateExpireDate
        '
        Me.DateExpireDate.EditValue = Nothing
        Me.DateExpireDate.Location = New System.Drawing.Point(263, 76)
        Me.DateExpireDate.Name = "DateExpireDate"
        Me.DateExpireDate.Properties.AdvancedModeOptions.Label = "تاريخ الانتهاء"
        Me.DateExpireDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateExpireDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateExpireDate.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateExpireDate.Size = New System.Drawing.Size(242, 42)
        Me.DateExpireDate.TabIndex = 5
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.ok_32px
        Me.SimpleButton1.Location = New System.Drawing.Point(367, 144)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(138, 43)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "حفظ"
        '
        'ItemDefineBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 199)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.DateExpireDate)
        Me.Controls.Add(Me.TextBatchNo)
        Me.Controls.Add(Me.TextItemName)
        Me.Controls.Add(Me.TextItemNo)
        Me.IconOptions.Image = CType(resources.GetObject("ItemDefineBatch.IconOptions.Image"), System.Drawing.Image)
        Me.MaximizeBox = False
        Me.Name = "ItemDefineBatch"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعريف باتش جديد"
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBatchNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateExpireDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateExpireDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextBatchNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateExpireDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
