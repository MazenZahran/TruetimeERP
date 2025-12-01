<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosDirectReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosDirectReceipt))
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckSendSMS = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckPrint = New DevExpress.XtraEditors.CheckEdit()
        Me.RadioAmountType = New DevExpress.XtraEditors.RadioGroup()
        Me.SearchCashAccount = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.TextRefBalance = New DevExpress.XtraEditors.TextEdit()
        Me.TextAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckSendSMS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckPrint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioAmountType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MemoEdit1
        '
        Me.MemoEdit1.Location = New System.Drawing.Point(21, 364)
        Me.MemoEdit1.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemoEdit1.Properties.Appearance.Options.UseFont = True
        Me.MemoEdit1.Size = New System.Drawing.Size(585, 105)
        Me.MemoEdit1.StyleController = Me.LayoutControl1
        Me.MemoEdit1.TabIndex = 2
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckSendSMS)
        Me.LayoutControl1.Controls.Add(Me.CheckPrint)
        Me.LayoutControl1.Controls.Add(Me.RadioAmountType)
        Me.LayoutControl1.Controls.Add(Me.SearchCashAccount)
        Me.LayoutControl1.Controls.Add(Me.BtnSave)
        Me.LayoutControl1.Controls.Add(Me.BtnCancel)
        Me.LayoutControl1.Controls.Add(Me.TextRefBalance)
        Me.LayoutControl1.Controls.Add(Me.MemoEdit1)
        Me.LayoutControl1.Controls.Add(Me.TextAmount)
        Me.LayoutControl1.Controls.Add(Me.Referance)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(627, 566)
        Me.LayoutControl1.TabIndex = 12
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CheckSendSMS
        '
        Me.CheckSendSMS.Location = New System.Drawing.Point(21, 477)
        Me.CheckSendSMS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckSendSMS.Name = "CheckSendSMS"
        Me.CheckSendSMS.Properties.Caption = "ارسال رسالة للزبون"
        Me.CheckSendSMS.Size = New System.Drawing.Size(288, 26)
        Me.CheckSendSMS.StyleController = Me.LayoutControl1
        Me.CheckSendSMS.TabIndex = 15
        '
        'CheckPrint
        '
        Me.CheckPrint.Location = New System.Drawing.Point(317, 477)
        Me.CheckPrint.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckPrint.Name = "CheckPrint"
        Me.CheckPrint.Properties.Caption = "طباعة"
        Me.CheckPrint.Size = New System.Drawing.Size(289, 26)
        Me.CheckPrint.StyleController = Me.LayoutControl1
        Me.CheckPrint.TabIndex = 13
        '
        'RadioAmountType
        '
        Me.RadioAmountType.Location = New System.Drawing.Point(21, 230)
        Me.RadioAmountType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioAmountType.Name = "RadioAmountType"
        Me.RadioAmountType.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("Cash", "نقدا"), New DevExpress.XtraEditors.Controls.RadioGroupItem("Card", "فيزا")})
        Me.RadioAmountType.Size = New System.Drawing.Size(494, 84)
        Me.RadioAmountType.StyleController = Me.LayoutControl1
        Me.RadioAmountType.TabIndex = 12
        '
        'SearchCashAccount
        '
        Me.SearchCashAccount.Location = New System.Drawing.Point(21, 322)
        Me.SearchCashAccount.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SearchCashAccount.Name = "SearchCashAccount"
        Me.SearchCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchCashAccount.Properties.DisplayMember = "PaidMethodName"
        Me.SearchCashAccount.Properties.NullText = ""
        Me.SearchCashAccount.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchCashAccount.Properties.ValueMember = "AccountNO"
        Me.SearchCashAccount.Size = New System.Drawing.Size(494, 34)
        Me.SearchCashAccount.StyleController = Me.LayoutControl1
        Me.SearchCashAccount.TabIndex = 11
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.DetailHeight = 431
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 1067
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "الحساب"
        Me.GridColumn1.FieldName = "PaidMethodName"
        Me.GridColumn1.MinWidth = 27
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "رقم الحساب"
        Me.GridColumn2.FieldName = "AccountNO"
        Me.GridColumn2.MinWidth = 27
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 100
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Location = New System.Drawing.Point(317, 511)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(289, 35)
        Me.BtnSave.StyleController = Me.LayoutControl1
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "حفظ"
        '
        'BtnCancel
        '
        Me.BtnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Appearance.Options.UseBackColor = True
        Me.BtnCancel.Appearance.Options.UseFont = True
        Me.BtnCancel.Location = New System.Drawing.Point(21, 511)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(288, 35)
        Me.BtnCancel.StyleController = Me.LayoutControl1
        Me.BtnCancel.TabIndex = 9
        Me.BtnCancel.Text = "الغاء"
        '
        'TextRefBalance
        '
        Me.TextRefBalance.Location = New System.Drawing.Point(21, 104)
        Me.TextRefBalance.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TextRefBalance.Name = "TextRefBalance"
        Me.TextRefBalance.Properties.ReadOnly = True
        Me.TextRefBalance.Size = New System.Drawing.Size(494, 34)
        Me.TextRefBalance.StyleController = Me.LayoutControl1
        Me.TextRefBalance.TabIndex = 10
        '
        'TextAmount
        '
        Me.TextAmount.EditValue = "0"
        Me.TextAmount.Location = New System.Drawing.Point(21, 146)
        Me.TextAmount.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.TextAmount.Name = "TextAmount"
        Me.TextAmount.Properties.AdvancedModeOptions.Label = "المبلغ:"
        Me.TextAmount.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAmount.Properties.Appearance.Options.UseFont = True
        Me.TextAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TextAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextAmount.Properties.MaskSettings.Set("mask", "c")
        Me.TextAmount.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextAmount.Properties.UseMaskAsDisplayFormat = True
        Me.TextAmount.Size = New System.Drawing.Size(585, 76)
        Me.TextAmount.StyleController = Me.LayoutControl1
        Me.TextAmount.TabIndex = 8
        '
        'Referance
        '
        Me.Referance.Location = New System.Drawing.Point(21, 20)
        Me.Referance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.Referance.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.Referance.Properties.AdvancedModeOptions.Label = "الزبون:"
        Me.Referance.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Referance.Properties.Appearance.Options.UseFont = True
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Referance.Properties.DisplayMember = "RefName"
        Me.Referance.Properties.NullText = ""
        Me.Referance.Properties.PopupView = Me.GridView1
        Me.Referance.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.UseEditorWidth
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.Size = New System.Drawing.Size(585, 76)
        Me.Referance.StyleController = Me.LayoutControl1
        Me.Referance.TabIndex = 7
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn3})
        Me.GridView1.DetailHeight = 431
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 711
        Me.GridView1.OptionsFind.SearchInPreview = True
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.PreviewFieldName = "ReMemo"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "ID"
        Me.GridColumn18.FieldName = "RefID"
        Me.GridColumn18.MinWidth = 27
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 100
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "رقم المرجع"
        Me.GridColumn19.FieldName = "RefNo"
        Me.GridColumn19.MaxWidth = 107
        Me.GridColumn19.MinWidth = 27
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 100
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "المرجع"
        Me.GridColumn20.FieldName = "RefName"
        Me.GridColumn20.MinWidth = 267
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 267
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "نوع المرجع"
        Me.GridColumn21.FieldName = "RefTypeName"
        Me.GridColumn21.MaxWidth = 107
        Me.GridColumn21.MinWidth = 27
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 2
        Me.GridColumn21.Width = 100
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "رقم الحساب"
        Me.GridColumn22.FieldName = "RefAccID"
        Me.GridColumn22.MinWidth = 27
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Width = 100
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "نوع المرجع"
        Me.GridColumn23.FieldName = "TypeID"
        Me.GridColumn23.MinWidth = 27
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Width = 100
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "العملة"
        Me.GridColumn24.FieldName = "Currency"
        Me.GridColumn24.MinWidth = 27
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Width = 100
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "رقم الموبايل"
        Me.GridColumn3.FieldName = "RefMobile"
        Me.GridColumn3.MinWidth = 27
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 100
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem11, Me.LayoutControlItem9})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(627, 566)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Referance
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(593, 84)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextRefBalance
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(593, 42)
        Me.LayoutControlItem2.Text = "المبلغ المطلوب:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextAmount
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 126)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(593, 84)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.MemoEdit1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 344)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(593, 113)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BtnCancel
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 491)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(296, 43)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.BtnSave
        Me.LayoutControlItem6.Location = New System.Drawing.Point(296, 491)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(297, 43)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.SearchCashAccount
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 302)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(593, 42)
        Me.LayoutControlItem7.Text = "الحساب:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(70, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.RadioAmountType
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 210)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(593, 92)
        Me.LayoutControlItem8.Text = "طريقة القبض"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(70, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.CheckSendSMS
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 457)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(296, 34)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.CheckPrint
        Me.LayoutControlItem9.Location = New System.Drawing.Point(296, 457)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(297, 34)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'PosDirectReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 566)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("PosDirectReceipt.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.Name = "PosDirectReceipt"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سند قبض"
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckSendSMS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckPrint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioAmountType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextRefBalance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SearchCashAccount As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadioAmountType As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckPrint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckSendSMS As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
End Class
