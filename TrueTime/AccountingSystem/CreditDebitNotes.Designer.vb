<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreditDebitNotes
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ButtonImageOptions1 As DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions = New DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreditDebitNotes))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextDocStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextDocName = New DevExpress.XtraEditors.TextEdit()
        Me.TextDocCode = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextDocNotes = New DevExpress.XtraEditors.MemoEdit()
        Me.DocCurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.ExchangePrice = New DevExpress.XtraEditors.TextEdit()
        Me.TextDocManualNo = New DevExpress.XtraEditors.TextEdit()
        Me.DocDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextDocID = New DevExpress.XtraEditors.TextEdit()
        Me.TotalDocAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TextRefBalance = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextReferanceName = New DevExpress.XtraEditors.MemoEdit()
        Me.LookCostCenter = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Account = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColAccNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutReferance = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutCostCenter = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextDocStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExchangePrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocManualNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDocID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalDocAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextReferanceName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookCostCenter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Account.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutReferance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.TextDocStatus)
        Me.LayoutControl1.Controls.Add(Me.TextDocName)
        Me.LayoutControl1.Controls.Add(Me.TextDocCode)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton6)
        Me.LayoutControl1.Controls.Add(Me.TextDocNotes)
        Me.LayoutControl1.Controls.Add(Me.DocCurrency)
        Me.LayoutControl1.Controls.Add(Me.ExchangePrice)
        Me.LayoutControl1.Controls.Add(Me.TextDocManualNo)
        Me.LayoutControl1.Controls.Add(Me.DocDate)
        Me.LayoutControl1.Controls.Add(Me.TextDocID)
        Me.LayoutControl1.Controls.Add(Me.TotalDocAmount)
        Me.LayoutControl1.Controls.Add(Me.TextRefBalance)
        Me.LayoutControl1.Controls.Add(Me.Referance)
        Me.LayoutControl1.Controls.Add(Me.TextReferanceName)
        Me.LayoutControl1.Controls.Add(Me.LookCostCenter)
        Me.LayoutControl1.Controls.Add(Me.Account)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem13, Me.LayoutControlItem15})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 33)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(895, 322, 650, 400)
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(920, 505)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 465)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(105, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 21
        Me.SimpleButton1.Text = "حذف"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.SimpleButton3.Appearance.Options.UseBackColor = True
        Me.SimpleButton3.Location = New System.Drawing.Point(121, 465)
        Me.SimpleButton3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(118, 28)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 20
        Me.SimpleButton3.Text = "طباعة"
        '
        'TextDocStatus
        '
        Me.TextDocStatus.EnterMoveNextControl = True
        Me.TextDocStatus.Location = New System.Drawing.Point(24, 59)
        Me.TextDocStatus.Name = "TextDocStatus"
        Me.TextDocStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextDocStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 17, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("DocStatus", "الحالة", 17, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.TextDocStatus.Properties.DisplayMember = "DocStatus"
        Me.TextDocStatus.Properties.NullText = ""
        Me.TextDocStatus.Properties.ReadOnly = True
        Me.TextDocStatus.Properties.ValueMember = "ID"
        Me.TextDocStatus.Size = New System.Drawing.Size(230, 22)
        Me.TextDocStatus.StyleController = Me.LayoutControl1
        Me.TextDocStatus.TabIndex = 2
        '
        'TextDocName
        '
        Me.TextDocName.Location = New System.Drawing.Point(10, 447)
        Me.TextDocName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextDocName.Name = "TextDocName"
        Me.TextDocName.Size = New System.Drawing.Size(595, 22)
        Me.TextDocName.StyleController = Me.LayoutControl1
        Me.TextDocName.TabIndex = 63
        '
        'TextDocCode
        '
        Me.TextDocCode.Location = New System.Drawing.Point(300, 447)
        Me.TextDocCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextDocCode.Name = "TextDocCode"
        Me.TextDocCode.Size = New System.Drawing.Size(305, 22)
        Me.TextDocCode.StyleController = Me.LayoutControl1
        Me.TextDocCode.TabIndex = 61
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton6.Appearance.Options.UseBackColor = True
        Me.SimpleButton6.Location = New System.Drawing.Point(243, 465)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(130, 28)
        Me.SimpleButton6.StyleController = Me.LayoutControl1
        Me.SimpleButton6.TabIndex = 11
        Me.SimpleButton6.Text = "حفظ    F3"
        '
        'TextDocNotes
        '
        Me.TextDocNotes.Location = New System.Drawing.Point(12, 390)
        Me.TextDocNotes.Name = "TextDocNotes"
        Me.TextDocNotes.Properties.MaxLength = 100
        Me.TextDocNotes.Size = New System.Drawing.Size(851, 71)
        Me.TextDocNotes.StyleController = Me.LayoutControl1
        Me.TextDocNotes.TabIndex = 10
        '
        'DocCurrency
        '
        Me.DocCurrency.EnterMoveNextControl = True
        Me.DocCurrency.Location = New System.Drawing.Point(139, 85)
        Me.DocCurrency.Name = "DocCurrency"
        Me.DocCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocCurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CurrID", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "العملة")})
        Me.DocCurrency.Properties.DisplayMember = "Code"
        Me.DocCurrency.Properties.NullText = ""
        Me.DocCurrency.Properties.ValueMember = "CurrID"
        Me.DocCurrency.Size = New System.Drawing.Size(136, 22)
        Me.DocCurrency.StyleController = Me.LayoutControl1
        Me.DocCurrency.TabIndex = 4
        '
        'ExchangePrice
        '
        Me.ExchangePrice.EnterMoveNextControl = True
        Me.ExchangePrice.Location = New System.Drawing.Point(24, 85)
        Me.ExchangePrice.Name = "ExchangePrice"
        Me.ExchangePrice.Properties.BeepOnError = True
        Me.ExchangePrice.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.ExchangePrice.Properties.MaskSettings.Set("mask", "f")
        Me.ExchangePrice.Properties.UseMaskAsDisplayFormat = True
        Me.ExchangePrice.Size = New System.Drawing.Size(111, 22)
        Me.ExchangePrice.StyleController = Me.LayoutControl1
        Me.ExchangePrice.TabIndex = 5
        '
        'TextDocManualNo
        '
        Me.TextDocManualNo.EnterMoveNextControl = True
        Me.TextDocManualNo.Location = New System.Drawing.Point(332, 59)
        Me.TextDocManualNo.Name = "TextDocManualNo"
        Me.TextDocManualNo.Properties.MaxLength = 20
        Me.TextDocManualNo.Size = New System.Drawing.Size(190, 22)
        Me.TextDocManualNo.StyleController = Me.LayoutControl1
        Me.TextDocManualNo.TabIndex = 1
        '
        'DocDate
        '
        Me.DocDate.EditValue = Nothing
        Me.DocDate.EnterMoveNextControl = True
        Me.DocDate.Location = New System.Drawing.Point(629, 85)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocDate.Size = New System.Drawing.Size(199, 22)
        Me.DocDate.StyleController = Me.LayoutControl1
        Me.DocDate.TabIndex = 3
        '
        'TextDocID
        '
        Me.TextDocID.EnterMoveNextControl = True
        Me.TextDocID.Location = New System.Drawing.Point(629, 59)
        Me.TextDocID.Name = "TextDocID"
        Me.TextDocID.Size = New System.Drawing.Size(199, 22)
        Me.TextDocID.StyleController = Me.LayoutControl1
        Me.TextDocID.TabIndex = 0
        '
        'TotalDocAmount
        '
        Me.TotalDocAmount.EnterMoveNextControl = True
        Me.TotalDocAmount.Location = New System.Drawing.Point(521, 237)
        Me.TotalDocAmount.Name = "TotalDocAmount"
        Me.TotalDocAmount.Properties.BeepOnError = True
        Me.TotalDocAmount.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TotalDocAmount.Properties.MaskSettings.Set("mask", "f5")
        Me.TotalDocAmount.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.TotalDocAmount.Properties.UseMaskAsDisplayFormat = True
        Me.TotalDocAmount.Size = New System.Drawing.Size(307, 22)
        Me.TotalDocAmount.StyleController = Me.LayoutControl1
        Me.TotalDocAmount.TabIndex = 9
        '
        'TextRefBalance
        '
        Me.TextRefBalance.EnterMoveNextControl = True
        Me.TextRefBalance.Location = New System.Drawing.Point(323, 157)
        Me.TextRefBalance.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextRefBalance.Name = "TextRefBalance"
        Me.TextRefBalance.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextRefBalance.Properties.MaskSettings.Set("mask", "n")
        Me.TextRefBalance.Properties.ReadOnly = True
        Me.TextRefBalance.Properties.UseMaskAsDisplayFormat = True
        Me.TextRefBalance.Size = New System.Drawing.Size(159, 22)
        Me.TextRefBalance.StyleController = Me.LayoutControl1
        Me.TextRefBalance.TabIndex = 7
        '
        'Referance
        '
        Me.Referance.EnterMoveNextControl = True
        Me.Referance.Location = New System.Drawing.Point(521, 157)
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Referance.Properties.DisplayMember = "RefNo"
        Me.Referance.Properties.NullText = ""
        Me.Referance.Properties.PopupView = Me.GridView1
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.Size = New System.Drawing.Size(307, 22)
        Me.Referance.StyleController = Me.LayoutControl1
        Me.Referance.TabIndex = 6
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID, Me.ColTypeID, Me.ColCurrency})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColRefID
        '
        Me.ColRefID.Caption = "ID"
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.Name = "ColRefID"
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم المرجع"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.Visible = True
        Me.ColRefNo.VisibleIndex = 0
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "المرجع"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 1
        '
        'ColRefTypeName
        '
        Me.ColRefTypeName.Caption = "نوع المرجع"
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.Name = "ColRefTypeName"
        Me.ColRefTypeName.Visible = True
        Me.ColRefTypeName.VisibleIndex = 2
        '
        'ColRefAccID
        '
        Me.ColRefAccID.Caption = "رقم الحساب"
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.Name = "ColRefAccID"
        '
        'ColTypeID
        '
        Me.ColTypeID.Caption = "نوع المرجع"
        Me.ColTypeID.FieldName = "TypeID"
        Me.ColTypeID.Name = "ColTypeID"
        '
        'ColCurrency
        '
        Me.ColCurrency.Caption = "العملة"
        Me.ColCurrency.FieldName = "Currency"
        Me.ColCurrency.Name = "ColCurrency"
        '
        'TextReferanceName
        '
        Me.TextReferanceName.EnterMoveNextControl = True
        Me.TextReferanceName.Location = New System.Drawing.Point(323, 183)
        Me.TextReferanceName.Name = "TextReferanceName"
        Me.TextReferanceName.Properties.MaxLength = 50
        Me.TextReferanceName.Size = New System.Drawing.Size(505, 50)
        Me.TextReferanceName.StyleController = Me.LayoutControl1
        Me.TextReferanceName.TabIndex = 8
        '
        'LookCostCenter
        '
        Me.LookCostCenter.Location = New System.Drawing.Point(530, 183)
        Me.LookCostCenter.Name = "LookCostCenter"
        Me.LookCostCenter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookCostCenter.Properties.DisplayMember = "CostName"
        Me.LookCostCenter.Properties.NullText = ""
        Me.LookCostCenter.Properties.PopupView = Me.GridView8
        Me.LookCostCenter.Properties.ValueMember = "CostID"
        Me.LookCostCenter.Size = New System.Drawing.Size(298, 22)
        Me.LookCostCenter.StyleController = Me.LayoutControl1
        Me.LookCostCenter.TabIndex = 27
        '
        'GridView8
        '
        Me.GridView8.DetailHeight = 284
        Me.GridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView8.Name = "GridView8"
        Me.GridView8.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView8.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView8.OptionsView.ShowGroupPanel = False
        '
        'Account
        '
        Me.Account.Location = New System.Drawing.Point(530, 157)
        Me.Account.Name = "Account"
        Me.Account.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Account.Properties.DisplayMember = "AccName"
        Me.Account.Properties.NullText = ""
        Me.Account.Properties.PopupView = Me.GridView3
        Me.Account.Properties.ValueMember = "AccNo"
        Me.Account.Size = New System.Drawing.Size(298, 22)
        Me.Account.StyleController = Me.LayoutControl1
        Me.Account.TabIndex = 13
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColAccNo, Me.ColAccName, Me.GridColumnCurrency})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColAccNo
        '
        Me.ColAccNo.Caption = "رقم الحساب"
        Me.ColAccNo.FieldName = "AccNo"
        Me.ColAccNo.Name = "ColAccNo"
        Me.ColAccNo.Visible = True
        Me.ColAccNo.VisibleIndex = 0
        '
        'ColAccName
        '
        Me.ColAccName.Caption = "رقم الحساب"
        Me.ColAccName.FieldName = "AccName"
        Me.ColAccName.Name = "ColAccName"
        Me.ColAccName.Visible = True
        Me.ColAccName.VisibleIndex = 1
        '
        'GridColumnCurrency
        '
        Me.GridColumnCurrency.Caption = "العملة"
        Me.GridColumnCurrency.FieldName = "Currency"
        Me.GridColumnCurrency.MinWidth = 17
        Me.GridColumnCurrency.Name = "GridColumnCurrency"
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.TextDocCode
        Me.LayoutControlItem13.Location = New System.Drawing.Point(338, 538)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(490, 26)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(101, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.TextDocName
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 538)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(828, 26)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(101, 13)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.EmptySpaceItem10, Me.TabbedControlGroup1, Me.LayoutControlItem14, Me.LayoutControlItem16})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(920, 505)
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup1
        '
        ButtonImageOptions1.SvgImage = CType(resources.GetObject("ButtonImageOptions1.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LayoutControlGroup1.CustomHeaderButtons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Tags", True, ButtonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, True, Nothing, True, False, True, "Tags", -1)})
        Me.LayoutControlGroup1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem2, Me.LayoutControlItem12, Me.EmptySpaceItem6, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(900, 111)
        Me.LayoutControlGroup1.Text = "  "
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextDocID
        Me.LayoutControlItem1.Location = New System.Drawing.Point(605, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(271, 26)
        Me.LayoutControlItem1.Text = "رقم السند"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(56, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.DocDate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(605, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(271, 26)
        Me.LayoutControlItem3.Text = "تاريخ السند"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(56, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ExchangePrice
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(115, 21)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(115, 21)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(115, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "سعر الصرف"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextDocManualNo
        Me.LayoutControlItem2.Location = New System.Drawing.Point(308, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(261, 26)
        Me.LayoutControlItem2.Text = "السند اليدوي"
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(62, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.TextDocStatus
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(289, 26)
        Me.LayoutControlItem12.Text = "حالة السند"
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(50, 13)
        Me.LayoutControlItem12.TextToControlDistance = 5
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(308, 26)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(261, 26)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(569, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(36, 52)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(289, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(19, 52)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.DocCurrency
        Me.LayoutControlItem4.Location = New System.Drawing.Point(115, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(174, 26)
        Me.LayoutControlItem4.Text = "العملة"
        Me.LayoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(29, 13)
        Me.LayoutControlItem4.TextToControlDistance = 5
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.TextDocNotes
        Me.LayoutControlItem10.ImageOptions.SvgImage = CType(resources.GetObject("LayoutControlItem10.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 378)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(900, 75)
        Me.LayoutControlItem10.Text = " "
        Me.LayoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(40, 32)
        Me.LayoutControlItem10.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.SimpleButton6
        Me.LayoutControlItem11.Location = New System.Drawing.Point(231, 453)
        Me.LayoutControlItem11.MaxSize = New System.Drawing.Size(134, 32)
        Me.LayoutControlItem11.MinSize = New System.Drawing.Size(134, 32)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(134, 32)
        Me.LayoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(365, 453)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(535, 32)
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 111)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup4
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(900, 267)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup4})
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem8, Me.EmptySpaceItem4, Me.LayoutReferance, Me.EmptySpaceItem11, Me.LayoutControlItem9, Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(876, 221)
        Me.LayoutControlGroup2.Text = "التفاصيل"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TextRefBalance
        Me.LayoutControlItem6.Location = New System.Drawing.Point(299, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(198, 26)
        Me.LayoutControlItem6.Text = "الرصيد"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(30, 13)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TextReferanceName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(299, 26)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(0, 54)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(85, 54)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(577, 54)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = " "
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(56, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 106)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(876, 115)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutReferance
        '
        Me.LayoutReferance.Control = Me.Referance
        Me.LayoutReferance.Location = New System.Drawing.Point(497, 0)
        Me.LayoutReferance.Name = "LayoutReferance"
        Me.LayoutReferance.Size = New System.Drawing.Size(379, 26)
        Me.LayoutReferance.Text = "الذمة"
        Me.LayoutReferance.TextSize = New System.Drawing.Size(56, 13)
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(299, 80)
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TotalDocAmount
        Me.LayoutControlItem9.Location = New System.Drawing.Point(497, 80)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(379, 26)
        Me.LayoutControlItem9.Text = "المبلغ"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(56, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 80)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(497, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem5, Me.LayoutControlItem7, Me.LayoutCostCenter, Me.EmptySpaceItem8})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(876, 221)
        Me.LayoutControlGroup4.Text = "أخرى"
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 52)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(876, 169)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.Account
        Me.LayoutControlItem7.Location = New System.Drawing.Point(506, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(370, 26)
        Me.LayoutControlItem7.Text = "الحساب"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(56, 13)
        '
        'LayoutCostCenter
        '
        Me.LayoutCostCenter.Control = Me.LookCostCenter
        Me.LayoutCostCenter.Location = New System.Drawing.Point(506, 26)
        Me.LayoutCostCenter.Name = "LayoutCostCenter"
        Me.LayoutCostCenter.Size = New System.Drawing.Size(370, 26)
        Me.LayoutCostCenter.Text = "مركز التكلفة"
        Me.LayoutCostCenter.TextSize = New System.Drawing.Size(56, 13)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(506, 52)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.SimpleButton3
        Me.LayoutControlItem14.Location = New System.Drawing.Point(109, 453)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(122, 32)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(122, 32)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(122, 32)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.SimpleButton1
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 453)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(109, 32)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(109, 32)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(109, 32)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarSubItem1, Me.BarButtonItem1})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 2
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1)})
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "تقارير"
        Me.BarSubItem1.Id = 0
        Me.BarSubItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarSubItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1)})
        Me.BarSubItem1.Name = "BarSubItem1"
        Me.BarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Log"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(920, 33)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 538)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(920, 25)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 33)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 505)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(920, 33)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 505)
        '
        'CreditDebitNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 563)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "CreditDebitNotes"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اشعار دائن / مدين"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextDocStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExchangePrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocManualNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDocID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalDocAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRefBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextReferanceName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookCostCenter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Account.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutReferance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DocCurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents ExchangePrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextDocManualNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DocDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextDocID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextRefBalance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextReferanceName As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Account As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColAccNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TotalDocAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextDocNotes As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextDocCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LookCostCenter As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutCostCenter As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutReferance As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextDocName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumnCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextDocStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
