<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttLeavesProccess
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttLeavesProccess))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.tempdaysLeaves = New DevExpress.XtraEditors.TextEdit()
        Me.MemoDetails = New DevExpress.XtraEditors.TextEdit()
        Me.LookUpEditVocations = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.VocationsTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextDayNo = New DevExpress.XtraEditors.TextEdit()
        Me.VocationDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextLeaveNIS_PerHour = New DevExpress.XtraEditors.TextEdit()
        Me.TextLeavesAmount = New DevExpress.XtraEditors.TextEdit()
        Me.RadioGroup1 = New DevExpress.XtraEditors.RadioGroup()
        Me.TextRemainingLeaves = New DevExpress.XtraEditors.TimeSpanEdit()
        Me.TextMaxLeavesHoures = New DevExpress.XtraEditors.TimeSpanEdit()
        Me.TextTotalNetLeaves = New DevExpress.XtraEditors.TimeSpanEdit()
        Me.TextEmployeeID = New DevExpress.XtraEditors.TextEdit()
        Me.TextEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.TextVocationsBalance = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutRemainingLeaves = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutFromSalary = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutFromVocations = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayouttempdaysLeaves = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.VocationsTypesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.tempdaysLeaves.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoDetails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditVocations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDayNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLeaveNIS_PerHour.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLeavesAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRemainingLeaves.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMaxLeavesHoures.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalNetLeaves.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEmployeeID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextVocationsBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutRemainingLeaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutFromSalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutFromVocations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayouttempdaysLeaves, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.tempdaysLeaves)
        Me.LayoutControl1.Controls.Add(Me.MemoDetails)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditVocations)
        Me.LayoutControl1.Controls.Add(Me.TextDayNo)
        Me.LayoutControl1.Controls.Add(Me.VocationDate)
        Me.LayoutControl1.Controls.Add(Me.TextLeaveNIS_PerHour)
        Me.LayoutControl1.Controls.Add(Me.TextLeavesAmount)
        Me.LayoutControl1.Controls.Add(Me.RadioGroup1)
        Me.LayoutControl1.Controls.Add(Me.TextRemainingLeaves)
        Me.LayoutControl1.Controls.Add(Me.TextMaxLeavesHoures)
        Me.LayoutControl1.Controls.Add(Me.TextTotalNetLeaves)
        Me.LayoutControl1.Controls.Add(Me.TextEmployeeID)
        Me.LayoutControl1.Controls.Add(Me.TextEmployeeName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.TextVocationsBalance)
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(919, 205, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'tempdaysLeaves
        '
        resources.ApplyResources(Me.tempdaysLeaves, "tempdaysLeaves")
        Me.tempdaysLeaves.Name = "tempdaysLeaves"
        Me.tempdaysLeaves.StyleController = Me.LayoutControl1
        '
        'MemoDetails
        '
        resources.ApplyResources(Me.MemoDetails, "MemoDetails")
        Me.MemoDetails.Name = "MemoDetails"
        Me.MemoDetails.StyleController = Me.LayoutControl1
        '
        'LookUpEditVocations
        '
        resources.ApplyResources(Me.LookUpEditVocations, "LookUpEditVocations")
        Me.LookUpEditVocations.Name = "LookUpEditVocations"
        Me.LookUpEditVocations.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("LookUpEditVocations.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.LookUpEditVocations.Properties.DataSource = Me.VocationsTypesBindingSource
        Me.LookUpEditVocations.Properties.DisplayMember = "Vocation"
        Me.LookUpEditVocations.Properties.NullText = resources.GetString("LookUpEditVocations.Properties.NullText")
        Me.LookUpEditVocations.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.LookUpEditVocations.Properties.ShowClearButton = False
        Me.LookUpEditVocations.Properties.ValueMember = "VocID"
        Me.LookUpEditVocations.StyleController = Me.LayoutControl1
        '
        'VocationsTypesBindingSource
        '
        Me.VocationsTypesBindingSource.DataMember = "VocationsTypes"
        Me.VocationsTypesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.Locale = New System.Globalization.CultureInfo("")
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVocation})
        Me.SearchLookUpEdit1View.DetailHeight = 284
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 686
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colVocation
        '
        Me.colVocation.FieldName = "Vocation"
        Me.colVocation.MinWidth = 17
        Me.colVocation.Name = "colVocation"
        resources.ApplyResources(Me.colVocation, "colVocation")
        '
        'TextDayNo
        '
        resources.ApplyResources(Me.TextDayNo, "TextDayNo")
        Me.TextDayNo.Name = "TextDayNo"
        Me.TextDayNo.Properties.ReadOnly = True
        Me.TextDayNo.StyleController = Me.LayoutControl1
        '
        'VocationDate
        '
        resources.ApplyResources(Me.VocationDate, "VocationDate")
        Me.VocationDate.Name = "VocationDate"
        Me.VocationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.VocationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("VocationDate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.VocationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("VocationDate.Properties.CalendarTimeProperties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.VocationDate.StyleController = Me.LayoutControl1
        '
        'TextLeaveNIS_PerHour
        '
        resources.ApplyResources(Me.TextLeaveNIS_PerHour, "TextLeaveNIS_PerHour")
        Me.TextLeaveNIS_PerHour.Name = "TextLeaveNIS_PerHour"
        Me.TextLeaveNIS_PerHour.StyleController = Me.LayoutControl1
        '
        'TextLeavesAmount
        '
        resources.ApplyResources(Me.TextLeavesAmount, "TextLeavesAmount")
        Me.TextLeavesAmount.Name = "TextLeavesAmount"
        Me.TextLeavesAmount.StyleController = Me.LayoutControl1
        '
        'RadioGroup1
        '
        resources.ApplyResources(Me.RadioGroup1, "RadioGroup1")
        Me.RadioGroup1.Name = "RadioGroup1"
        Me.RadioGroup1.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items"), resources.GetString("RadioGroup1.Properties.Items1")), New DevExpress.XtraEditors.Controls.RadioGroupItem(resources.GetString("RadioGroup1.Properties.Items2"), resources.GetString("RadioGroup1.Properties.Items3"))})
        Me.RadioGroup1.StyleController = Me.LayoutControl1
        '
        'TextRemainingLeaves
        '
        resources.ApplyResources(Me.TextRemainingLeaves, "TextRemainingLeaves")
        Me.TextRemainingLeaves.Name = "TextRemainingLeaves"
        Me.TextRemainingLeaves.Properties.AllowEditDays = False
        Me.TextRemainingLeaves.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("TextRemainingLeaves.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.TextRemainingLeaves.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("TextRemainingLeaves.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.TextRemainingLeaves.Properties.MaskSettings.Set("mask", "hh:mm")
        Me.TextRemainingLeaves.Properties.MaxDays = 10000
        Me.TextRemainingLeaves.Properties.MaxHours = 10000
        Me.TextRemainingLeaves.Properties.ReadOnly = True
        Me.TextRemainingLeaves.StyleController = Me.LayoutControl1
        '
        'TextMaxLeavesHoures
        '
        resources.ApplyResources(Me.TextMaxLeavesHoures, "TextMaxLeavesHoures")
        Me.TextMaxLeavesHoures.Name = "TextMaxLeavesHoures"
        Me.TextMaxLeavesHoures.Properties.AllowEditDays = False
        Me.TextMaxLeavesHoures.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("TextMaxLeavesHoures.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.TextMaxLeavesHoures.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("TextMaxLeavesHoures.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.TextMaxLeavesHoures.Properties.MaskSettings.Set("mask", "hh:mm")
        Me.TextMaxLeavesHoures.Properties.MaxDays = 10000
        Me.TextMaxLeavesHoures.Properties.MaxHours = 10000
        Me.TextMaxLeavesHoures.StyleController = Me.LayoutControl1
        '
        'TextTotalNetLeaves
        '
        resources.ApplyResources(Me.TextTotalNetLeaves, "TextTotalNetLeaves")
        Me.TextTotalNetLeaves.Name = "TextTotalNetLeaves"
        Me.TextTotalNetLeaves.Properties.AllowEditDays = False
        Me.TextTotalNetLeaves.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("TextTotalNetLeaves.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.TextTotalNetLeaves.Properties.Mask.UseMaskAsDisplayFormat = CType(resources.GetObject("TextTotalNetLeaves.Properties.Mask.UseMaskAsDisplayFormat"), Boolean)
        Me.TextTotalNetLeaves.Properties.MaskSettings.Set("mask", "hh:mm")
        Me.TextTotalNetLeaves.Properties.MaxDays = 10000
        Me.TextTotalNetLeaves.Properties.MaxHours = 10000
        Me.TextTotalNetLeaves.Properties.ReadOnly = True
        Me.TextTotalNetLeaves.StyleController = Me.LayoutControl1
        '
        'TextEmployeeID
        '
        resources.ApplyResources(Me.TextEmployeeID, "TextEmployeeID")
        Me.TextEmployeeID.Name = "TextEmployeeID"
        Me.TextEmployeeID.Properties.ReadOnly = True
        Me.TextEmployeeID.StyleController = Me.LayoutControl1
        '
        'TextEmployeeName
        '
        resources.ApplyResources(Me.TextEmployeeName, "TextEmployeeName")
        Me.TextEmployeeName.Name = "TextEmployeeName"
        Me.TextEmployeeName.Properties.ReadOnly = True
        Me.TextEmployeeName.StyleController = Me.LayoutControl1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'TextVocationsBalance
        '
        resources.ApplyResources(Me.TextVocationsBalance, "TextVocationsBalance")
        Me.TextVocationsBalance.Name = "TextVocationsBalance"
        Me.TextVocationsBalance.Properties.ReadOnly = True
        Me.TextVocationsBalance.StyleController = Me.LayoutControl1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem9, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutRemainingLeaves, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.LayoutControlItem6, Me.LayoutFromSalary, Me.LayoutFromVocations, Me.EmptySpaceItem1, Me.LayoutControlItem10, Me.EmptySpaceItem2})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(749, 532)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TextEmployeeName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(555, 32)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TextEmployeeID
        Me.LayoutControlItem9.Location = New System.Drawing.Point(555, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(172, 32)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextTotalNetLeaves
        Me.LayoutControlItem2.Location = New System.Drawing.Point(507, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(220, 32)
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(75, 13)
        Me.LayoutControlItem2.TextToControlDistance = 5
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextMaxLeavesHoures
        Me.LayoutControlItem3.Location = New System.Drawing.Point(242, 40)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(265, 32)
        resources.ApplyResources(Me.LayoutControlItem3, "LayoutControlItem3")
        Me.LayoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(68, 13)
        Me.LayoutControlItem3.TextToControlDistance = 5
        '
        'LayoutRemainingLeaves
        '
        Me.LayoutRemainingLeaves.Control = Me.TextRemainingLeaves
        Me.LayoutRemainingLeaves.Location = New System.Drawing.Point(0, 40)
        Me.LayoutRemainingLeaves.Name = "LayoutRemainingLeaves"
        Me.LayoutRemainingLeaves.Size = New System.Drawing.Size(242, 32)
        resources.ApplyResources(Me.LayoutRemainingLeaves, "LayoutRemainingLeaves")
        Me.LayoutRemainingLeaves.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutRemainingLeaves.TextSize = New System.Drawing.Size(34, 13)
        Me.LayoutRemainingLeaves.TextToControlDistance = 5
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 209)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 8)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(9, 8)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(727, 8)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 32)
        Me.EmptySpaceItem5.MaxSize = New System.Drawing.Size(0, 8)
        Me.EmptySpaceItem5.MinSize = New System.Drawing.Size(9, 8)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(727, 8)
        Me.EmptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 364)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(160, 32)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutFromSalary
        '
        Me.LayoutFromSalary.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8, Me.LayoutControlItem7, Me.EmptySpaceItem3})
        Me.LayoutFromSalary.Location = New System.Drawing.Point(0, 126)
        Me.LayoutFromSalary.Name = "LayoutFromSalary"
        Me.LayoutFromSalary.Size = New System.Drawing.Size(727, 83)
        resources.ApplyResources(Me.LayoutFromSalary, "LayoutFromSalary")
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.TextLeaveNIS_PerHour
        Me.LayoutControlItem8.Location = New System.Drawing.Point(482, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(217, 32)
        resources.ApplyResources(Me.LayoutControlItem8, "LayoutControlItem8")
        Me.LayoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(87, 13)
        Me.LayoutControlItem8.TextToControlDistance = 5
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextLeavesAmount
        Me.LayoutControlItem7.Location = New System.Drawing.Point(243, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(239, 32)
        resources.ApplyResources(Me.LayoutControlItem7, "LayoutControlItem7")
        Me.LayoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(64, 13)
        Me.LayoutControlItem7.TextToControlDistance = 5
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(243, 32)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutFromVocations
        '
        Me.LayoutFromVocations.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayouttempdaysLeaves, Me.LayoutControlItem14})
        Me.LayoutFromVocations.Location = New System.Drawing.Point(0, 217)
        Me.LayoutFromVocations.Name = "LayoutFromVocations"
        Me.LayoutFromVocations.Size = New System.Drawing.Size(727, 147)
        resources.ApplyResources(Me.LayoutFromVocations, "LayoutFromVocations")
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TextVocationsBalance
        Me.LayoutControlItem5.Location = New System.Drawing.Point(544, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(155, 32)
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(62, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.VocationDate
        Me.LayoutControlItem11.Location = New System.Drawing.Point(359, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(185, 32)
        resources.ApplyResources(Me.LayoutControlItem11, "LayoutControlItem11")
        Me.LayoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(80, 13)
        Me.LayoutControlItem11.TextToControlDistance = 5
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.TextDayNo
        Me.LayoutControlItem12.Location = New System.Drawing.Point(171, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(188, 32)
        resources.ApplyResources(Me.LayoutControlItem12, "LayoutControlItem12")
        Me.LayoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(79, 13)
        Me.LayoutControlItem12.TextToControlDistance = 5
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.LookUpEditVocations
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(171, 32)
        resources.ApplyResources(Me.LayoutControlItem13, "LayoutControlItem13")
        Me.LayoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(51, 13)
        Me.LayoutControlItem13.TextToControlDistance = 5
        '
        'LayouttempdaysLeaves
        '
        Me.LayouttempdaysLeaves.Control = Me.tempdaysLeaves
        Me.LayouttempdaysLeaves.Location = New System.Drawing.Point(0, 64)
        Me.LayouttempdaysLeaves.Name = "LayouttempdaysLeaves"
        Me.LayouttempdaysLeaves.Size = New System.Drawing.Size(699, 32)
        resources.ApplyResources(Me.LayouttempdaysLeaves, "LayouttempdaysLeaves")
        Me.LayouttempdaysLeaves.TextSize = New System.Drawing.Size(110, 13)
        Me.LayouttempdaysLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.MemoDetails
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(699, 32)
        resources.ApplyResources(Me.LayoutControlItem14, "LayoutControlItem14")
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(110, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(160, 364)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(567, 32)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.RadioGroup1
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem10.MaxSize = New System.Drawing.Size(0, 54)
        Me.LayoutControlItem10.MinSize = New System.Drawing.Size(46, 54)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(727, 54)
        Me.LayoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 396)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(727, 116)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'VocationsTypesTableAdapter
        '
        Me.VocationsTypesTableAdapter.ClearBeforeFill = True
        '
        'AttLeavesProccess
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "AttLeavesProccess"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.tempdaysLeaves.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoDetails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditVocations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDayNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLeaveNIS_PerHour.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLeavesAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRemainingLeaves.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMaxLeavesHoures.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalNetLeaves.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEmployeeID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextVocationsBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutRemainingLeaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutFromSalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutFromVocations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayouttempdaysLeaves, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextVocationsBalance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEmployeeID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextRemainingLeaves As DevExpress.XtraEditors.TimeSpanEdit
    Friend WithEvents TextMaxLeavesHoures As DevExpress.XtraEditors.TimeSpanEdit
    Friend WithEvents TextTotalNetLeaves As DevExpress.XtraEditors.TimeSpanEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutRemainingLeaves As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextLeavesAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextLeaveNIS_PerHour As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents VocationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextDayNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LookUpEditVocations As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents MemoDetails As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents VocationsTypesBindingSource As BindingSource
    Friend WithEvents VocationsTypesTableAdapter As TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter
    Friend WithEvents colVocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tempdaysLeaves As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayouttempdaysLeaves As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutFromSalary As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutFromVocations As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
End Class
