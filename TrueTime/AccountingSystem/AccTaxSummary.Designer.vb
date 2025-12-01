<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccTaxSummary
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckEditCheckActive = New DevExpress.XtraEditors.CheckEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextMonth = New DevExpress.XtraEditors.SpinEdit()
        Me.TextYear = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextTotalSales = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TextTotalPurchases = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextTotalReturnSales = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextTotalReturnPurchases = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalPurchases.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalReturnSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalReturnPurchases.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextTotalReturnPurchases)
        Me.LayoutControl1.Controls.Add(Me.TextTotalReturnSales)
        Me.LayoutControl1.Controls.Add(Me.TextTotalPurchases)
        Me.LayoutControl1.Controls.Add(Me.TextTotalSales)
        Me.LayoutControl1.Controls.Add(Me.CheckEditCheckActive)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextMonth)
        Me.LayoutControl1.Controls.Add(Me.TextYear)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(576, 401)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CheckEditCheckActive
        '
        Me.CheckEditCheckActive.Location = New System.Drawing.Point(16, 60)
        Me.CheckEditCheckActive.Name = "CheckEditCheckActive"
        Me.CheckEditCheckActive.Properties.Caption = "حسب تاريخ الفاتورة"
        Me.CheckEditCheckActive.Size = New System.Drawing.Size(544, 22)
        Me.CheckEditCheckActive.StyleController = Me.LayoutControl1
        Me.CheckEditCheckActive.TabIndex = 32
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 16)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(131, 38)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 9
        Me.SimpleButton1.Text = "تحديث"
        '
        'TextMonth
        '
        Me.TextMonth.EditValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextMonth.Location = New System.Drawing.Point(174, 16)
        Me.TextMonth.Name = "TextMonth"
        Me.TextMonth.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMonth.Properties.Appearance.Options.UseFont = True
        Me.TextMonth.Properties.Appearance.Options.UseTextOptions = True
        Me.TextMonth.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextMonth.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextMonth.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TextMonth.Properties.MaskSettings.Set("mask", "00")
        Me.TextMonth.Properties.MaxValue = New Decimal(New Integer() {12, 0, 0, 0})
        Me.TextMonth.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextMonth.Properties.UseMaskAsDisplayFormat = True
        Me.TextMonth.Size = New System.Drawing.Size(92, 38)
        Me.TextMonth.StyleController = Me.LayoutControl1
        Me.TextMonth.TabIndex = 8
        '
        'TextYear
        '
        Me.TextYear.EditValue = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.TextYear.Location = New System.Drawing.Point(370, 16)
        Me.TextYear.Name = "TextYear"
        Me.TextYear.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextYear.Properties.Appearance.Options.UseFont = True
        Me.TextYear.Properties.Appearance.Options.UseTextOptions = True
        Me.TextYear.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextYear.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.TextYear.Properties.BeepOnError = True
        Me.TextYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextYear.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TextYear.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextYear.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.TextYear.Properties.MaskSettings.Set("mask", "0000")
        Me.TextYear.Properties.MaxValue = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.TextYear.Properties.MinValue = New Decimal(New Integer() {2000, 0, 0, 0})
        Me.TextYear.Properties.UseMaskAsDisplayFormat = True
        Me.TextYear.Size = New System.Drawing.Size(92, 38)
        Me.TextYear.StyleController = Me.LayoutControl1
        Me.TextYear.TabIndex = 7
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem6, Me.EmptySpaceItem2, Me.LayoutControlItem1, Me.LayoutControlItem8, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(576, 401)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextYear
        Me.LayoutControlItem3.Location = New System.Drawing.Point(354, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(196, 44)
        Me.LayoutControlItem3.Text = "السنة:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TextMonth
        Me.LayoutControlItem4.Location = New System.Drawing.Point(158, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(196, 44)
        Me.LayoutControlItem4.Text = "الشهر:"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(82, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(137, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(21, 44)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.SimpleButton1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(137, 0)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(137, 34)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(137, 44)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CheckEditCheckActive
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(550, 28)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'TextTotalSales
        '
        Me.TextTotalSales.Location = New System.Drawing.Point(16, 88)
        Me.TextTotalSales.Name = "TextTotalSales"
        Me.TextTotalSales.Properties.DisplayFormat.FormatString = "D2"
        Me.TextTotalSales.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextTotalSales.Size = New System.Drawing.Size(446, 28)
        Me.TextTotalSales.StyleController = Me.LayoutControl1
        Me.TextTotalSales.TabIndex = 33
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TextTotalSales
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(550, 34)
        Me.LayoutControlItem6.Text = "المبيعات:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(82, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 208)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(550, 167)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'TextTotalPurchases
        '
        Me.TextTotalPurchases.Location = New System.Drawing.Point(16, 156)
        Me.TextTotalPurchases.Name = "TextTotalPurchases"
        Me.TextTotalPurchases.Properties.DisplayFormat.FormatString = "D2"
        Me.TextTotalPurchases.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextTotalPurchases.Size = New System.Drawing.Size(446, 28)
        Me.TextTotalPurchases.StyleController = Me.LayoutControl1
        Me.TextTotalPurchases.TabIndex = 34
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextTotalPurchases
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 140)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(550, 34)
        Me.LayoutControlItem1.Text = "المشتريات:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(82, 13)
        '
        'TextTotalReturnSales
        '
        Me.TextTotalReturnSales.Location = New System.Drawing.Point(16, 122)
        Me.TextTotalReturnSales.Name = "TextTotalReturnSales"
        Me.TextTotalReturnSales.Properties.DisplayFormat.FormatString = "D2"
        Me.TextTotalReturnSales.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextTotalReturnSales.Size = New System.Drawing.Size(446, 28)
        Me.TextTotalReturnSales.StyleController = Me.LayoutControl1
        Me.TextTotalReturnSales.TabIndex = 35
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextTotalReturnSales
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 106)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(550, 34)
        Me.LayoutControlItem7.Text = "مردودات مبيعات:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(82, 13)
        '
        'TextTotalReturnPurchases
        '
        Me.TextTotalReturnPurchases.Location = New System.Drawing.Point(16, 190)
        Me.TextTotalReturnPurchases.Name = "TextTotalReturnPurchases"
        Me.TextTotalReturnPurchases.Properties.DisplayFormat.FormatString = "D2"
        Me.TextTotalReturnPurchases.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextTotalReturnPurchases.Size = New System.Drawing.Size(446, 28)
        Me.TextTotalReturnPurchases.StyleController = Me.LayoutControl1
        Me.TextTotalReturnPurchases.TabIndex = 36
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TextTotalReturnPurchases
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 174)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(550, 34)
        Me.LayoutControlItem8.Text = "مردودات مشتريات:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(82, 13)
        '
        'AccTaxSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 401)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "AccTaxSummary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "AccTaxSummary"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckEditCheckActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalPurchases.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalReturnSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalReturnPurchases.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TextYear As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextMonth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckEditCheckActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextTotalSales As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextTotalReturnSales As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextTotalPurchases As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextTotalReturnPurchases As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
