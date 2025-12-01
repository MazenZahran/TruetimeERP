<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddFixedDiscountsAndBonuses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddFixedDiscountsAndBonuses))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TextFields = New DevExpress.XtraEditors.TextEdit()
        Me.TextPercentage = New DevExpress.XtraEditors.TextEdit()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.TXT_Amount = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.DateEditTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditFrom = New DevExpress.XtraEditors.DateEdit()
        Me.txtTermID = New DevExpress.XtraEditors.LookUpEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutAmount = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutPercntage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutFields = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextFields.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXT_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTermID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutPercntage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutFields, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextFields)
        Me.LayoutControl1.Controls.Add(Me.TextPercentage)
        Me.LayoutControl1.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl1.Controls.Add(Me.TXT_Amount)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.MemoEdit1)
        Me.LayoutControl1.Controls.Add(Me.DateEditTo)
        Me.LayoutControl1.Controls.Add(Me.DateEditFrom)
        Me.LayoutControl1.Controls.Add(Me.txtTermID)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(513, 404)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TextFields
        '
        Me.TextFields.Location = New System.Drawing.Point(16, 257)
        Me.TextFields.Name = "TextFields"
        Me.TextFields.Properties.AdvancedModeOptions.Label = "الحقول"
        Me.TextFields.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextFields.Size = New System.Drawing.Size(481, 42)
        Me.TextFields.StyleController = Me.LayoutControl1
        Me.TextFields.TabIndex = 12
        '
        'TextPercentage
        '
        Me.TextPercentage.Location = New System.Drawing.Point(16, 209)
        Me.TextPercentage.Name = "TextPercentage"
        Me.TextPercentage.Properties.AdvancedModeOptions.Label = "النسبة"
        Me.TextPercentage.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextPercentage.Size = New System.Drawing.Size(481, 42)
        Me.TextPercentage.StyleController = Me.LayoutControl1
        Me.TextPercentage.TabIndex = 11
        '
        'RadioGroup1
        '
        Me.RadioGroup1.Location = New System.Drawing.Point(16, 112)
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Columns = 2
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("FixedAmount", "مبلغ ثابت"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Percentage", "نسبة")})
        Me.RadioGroup1.Size = New System.Drawing.Size(481, 43)
        Me.RadioGroup1.StyleController = Me.LayoutControl1
        Me.RadioGroup1.TabIndex = 10
        '
        'TXT_Amount
        '
        Me.TXT_Amount.Location = New System.Drawing.Point(16, 161)
        Me.TXT_Amount.Name = "TXT_Amount"
        Me.TXT_Amount.Properties.AdvancedModeOptions.Label = "المبلغ"
        Me.TXT_Amount.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TXT_Amount.Size = New System.Drawing.Size(481, 42)
        Me.TXT_Amount.StyleController = Me.LayoutControl1
        Me.TXT_Amount.TabIndex = 9
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.ImageOptions.Image = Global.TrueTime.My.Resources.Resources.save_close_32px
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 350)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(481, 38)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 8
        Me.SimpleButton1.Text = "حفظ"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(16, 305)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Size = New System.Drawing.Size(481, 39)
        Me.MemoEdit1.StyleController = Me.LayoutControl1
        Me.MemoEdit1.TabIndex = 7
        '
        'DateEditTo
        '
        Me.DateEditTo.EditValue = Nothing
        Me.DateEditTo.Location = New System.Drawing.Point(16, 64)
        Me.DateEditTo.Name = "DateEditTo"
        Me.DateEditTo.Properties.AdvancedModeOptions.Label = "الى تاريخ:"
        Me.DateEditTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditTo.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateEditTo.Size = New System.Drawing.Size(237, 42)
        Me.DateEditTo.StyleController = Me.LayoutControl1
        Me.DateEditTo.TabIndex = 6
        '
        'DateEditFrom
        '
        Me.DateEditFrom.EditValue = Nothing
        Me.DateEditFrom.Location = New System.Drawing.Point(259, 64)
        Me.DateEditFrom.Name = "DateEditFrom"
        Me.DateEditFrom.Properties.AdvancedModeOptions.Label = "من تاريخ:"
        Me.DateEditFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditFrom.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.DateEditFrom.Size = New System.Drawing.Size(238, 42)
        Me.DateEditFrom.StyleController = Me.LayoutControl1
        Me.DateEditFrom.TabIndex = 5
        '
        'txtTermID
        '
        Me.txtTermID.Location = New System.Drawing.Point(16, 16)
        Me.txtTermID.Name = "txtTermID"
        Me.txtTermID.Properties.AdvancedModeOptions.Label = "النوع:"
        Me.txtTermID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTermID.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TermID", "ID"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TermType", "النوع")})
        Me.txtTermID.Properties.DisplayMember = "TermType"
        Me.txtTermID.Properties.NullText = ""
        Me.txtTermID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.txtTermID.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtTermID.Properties.ValueMember = "TermID"
        Me.txtTermID.Size = New System.Drawing.Size(481, 42)
        Me.txtTermID.StyleController = Me.LayoutControl1
        Me.txtTermID.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutAmount, Me.LayoutControlItem7, Me.LayoutPercntage, Me.LayoutFields})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(513, 404)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtTermID
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(487, 48)
        Me.LayoutControlItem1.Text = "النوع:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.DateEditFrom
        Me.LayoutControlItem2.Location = New System.Drawing.Point(243, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(244, 48)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DateEditTo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(243, 48)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.MemoEdit1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 289)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(487, 45)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButton1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 334)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(487, 44)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutAmount
        '
        Me.LayoutAmount.Control = Me.TXT_Amount
        Me.LayoutAmount.Location = New System.Drawing.Point(0, 145)
        Me.LayoutAmount.Name = "LayoutAmount"
        Me.LayoutAmount.Size = New System.Drawing.Size(487, 48)
        Me.LayoutAmount.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutAmount.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.RadioGroup1
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 49)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(54, 49)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(487, 49)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutPercntage
        '
        Me.LayoutPercntage.Control = Me.TextPercentage
        Me.LayoutPercntage.Location = New System.Drawing.Point(0, 193)
        Me.LayoutPercntage.Name = "LayoutPercntage"
        Me.LayoutPercntage.Size = New System.Drawing.Size(487, 48)
        Me.LayoutPercntage.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutPercntage.TextVisible = False
        '
        'LayoutFields
        '
        Me.LayoutFields.Control = Me.TextFields
        Me.LayoutFields.Location = New System.Drawing.Point(0, 241)
        Me.LayoutFields.Name = "LayoutFields"
        Me.LayoutFields.Size = New System.Drawing.Size(487, 48)
        Me.LayoutFields.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutFields.TextVisible = False
        '
        'AddFixedDiscountsAndBonuses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 404)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("AddFixedDiscountsAndBonuses.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddFixedDiscountsAndBonuses"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextFields.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXT_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTermID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutPercntage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutFields, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents DateEditTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEditFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtTermID As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TXT_Amount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutAmount As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextFields As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextPercentage As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutPercntage As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutFields As DevExpress.XtraLayout.LayoutControlItem
End Class
