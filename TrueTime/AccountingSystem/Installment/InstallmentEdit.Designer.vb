<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstallmentEdit
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
        Me.BtnUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtDueDate = New DevExpress.XtraEditors.DateEdit()
        Me.TxtNote = New DevExpress.XtraEditors.MemoEdit()
        Me.TxtAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtDueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnUpdate.Appearance.Options.UseBackColor = True
        Me.BtnUpdate.Location = New System.Drawing.Point(16, 385)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(642, 28)
        Me.BtnUpdate.StyleController = Me.LayoutControl1
        Me.BtnUpdate.TabIndex = 14
        Me.BtnUpdate.Text = "حفظ"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtDueDate)
        Me.LayoutControl1.Controls.Add(Me.BtnUpdate)
        Me.LayoutControl1.Controls.Add(Me.TxtNote)
        Me.LayoutControl1.Controls.Add(Me.TxtAmount)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(674, 429)
        Me.LayoutControl1.TabIndex = 15
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtDueDate
        '
        Me.TxtDueDate.EditValue = Nothing
        Me.TxtDueDate.Location = New System.Drawing.Point(16, 16)
        Me.TxtDueDate.Name = "TxtDueDate"
        Me.TxtDueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDueDate.Properties.ReadOnly = True
        Me.TxtDueDate.Size = New System.Drawing.Size(547, 28)
        Me.TxtDueDate.StyleController = Me.LayoutControl1
        Me.TxtDueDate.TabIndex = 16
        '
        'TxtNote
        '
        Me.TxtNote.Location = New System.Drawing.Point(16, 84)
        Me.TxtNote.Name = "TxtNote"
        Me.TxtNote.Size = New System.Drawing.Size(547, 295)
        Me.TxtNote.StyleController = Me.LayoutControl1
        Me.TxtNote.TabIndex = 12
        '
        'TxtAmount
        '
        Me.TxtAmount.Location = New System.Drawing.Point(16, 50)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Properties.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(547, 28)
        Me.TxtAmount.StyleController = Me.LayoutControl1
        Me.TxtAmount.TabIndex = 10
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(674, 429)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtNote
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(648, 301)
        Me.LayoutControlItem1.Text = "ملاحظات:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BtnUpdate
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 369)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(648, 34)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtAmount
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(648, 34)
        Me.LayoutControlItem2.Text = "المبلغ:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(79, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtDueDate
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(648, 34)
        Me.LayoutControlItem6.Text = "تاريخ الاستحقاق:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(79, 13)
        '
        'InstallmentEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 429)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "InstallmentEdit"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "شاشة قسط"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtDueDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtNote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents TxtAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtDueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
End Class
