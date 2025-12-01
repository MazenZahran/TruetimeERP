<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttLeavesProccessDaily
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttLeavesProccessDaily))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.VocationsTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutFromVocations = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.VocationsTypesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter()
        Me.TextLeavesPeriod = New DevExpress.XtraEditors.TimeSpanEdit()
        Me.RequiredDailyHoures = New DevExpress.XtraEditors.TimeSpanEdit()
        Me.TextEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.MemoDetails = New DevExpress.XtraEditors.TextEdit()
        Me.LookUpEditVocations = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colVocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextDayNo = New DevExpress.XtraEditors.TextEdit()
        Me.VocationDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextEmployeeID = New DevExpress.XtraEditors.TextEdit()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutFromVocations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLeavesPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RequiredDailyHoures.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoDetails.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEditVocations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDayNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEmployeeID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextLeavesPeriod)
        Me.LayoutControl1.Controls.Add(Me.RequiredDailyHoures)
        Me.LayoutControl1.Controls.Add(Me.TextEmployeeName)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.MemoDetails)
        Me.LayoutControl1.Controls.Add(Me.LookUpEditVocations)
        Me.LayoutControl1.Controls.Add(Me.TextDayNo)
        Me.LayoutControl1.Controls.Add(Me.VocationDate)
        Me.LayoutControl1.Controls.Add(Me.TextEmployeeID)
        Me.LayoutControl1.Controls.Add(Me.DateEdit1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(623, 432)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(16, 388)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(141, 28)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 37
        Me.SimpleButton1.Text = "موافق"
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
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutFromVocations, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem2, Me.LayoutControlItem12, Me.LayoutControlItem11, Me.EmptySpaceItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(623, 432)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 297)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(597, 75)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutFromVocations
        '
        Me.LayoutFromVocations.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem5, Me.LayoutControlItem8})
        Me.LayoutFromVocations.Location = New System.Drawing.Point(0, 102)
        Me.LayoutFromVocations.Name = "LayoutFromVocations"
        Me.LayoutFromVocations.Size = New System.Drawing.Size(597, 195)
        Me.LayoutFromVocations.Text = "بيانات الخصم من الاجازات"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.SimpleButton1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 372)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(147, 34)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(147, 34)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(147, 34)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(147, 372)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(450, 34)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'VocationsTypesTableAdapter
        '
        Me.VocationsTypesTableAdapter.ClearBeforeFill = True
        '
        'TextLeavesPeriod
        '
        Me.TextLeavesPeriod.EditValue = System.TimeSpan.Parse("00:00:00")
        Me.TextLeavesPeriod.Location = New System.Drawing.Point(314, 84)
        Me.TextLeavesPeriod.Name = "TextLeavesPeriod"
        Me.TextLeavesPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextLeavesPeriod.Properties.MaskSettings.Set("mask", "[d.]hh:mm")
        Me.TextLeavesPeriod.Properties.ReadOnly = True
        Me.TextLeavesPeriod.Properties.UseMaskAsDisplayFormat = True
        Me.TextLeavesPeriod.Size = New System.Drawing.Size(164, 28)
        Me.TextLeavesPeriod.StyleController = Me.LayoutControl1
        Me.TextLeavesPeriod.TabIndex = 42
        '
        'RequiredDailyHoures
        '
        Me.RequiredDailyHoures.EditValue = System.TimeSpan.Parse("00:00:00")
        Me.RequiredDailyHoures.Location = New System.Drawing.Point(16, 84)
        Me.RequiredDailyHoures.Name = "RequiredDailyHoures"
        Me.RequiredDailyHoures.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RequiredDailyHoures.Properties.MaskSettings.Set("mask", "[d.]hh:mm")
        Me.RequiredDailyHoures.Properties.ReadOnly = True
        Me.RequiredDailyHoures.Properties.UseMaskAsDisplayFormat = True
        Me.RequiredDailyHoures.Size = New System.Drawing.Size(163, 28)
        Me.RequiredDailyHoures.StyleController = Me.LayoutControl1
        Me.RequiredDailyHoures.TabIndex = 41
        '
        'TextEmployeeName
        '
        Me.TextEmployeeName.Location = New System.Drawing.Point(16, 50)
        Me.TextEmployeeName.Name = "TextEmployeeName"
        Me.TextEmployeeName.Properties.ReadOnly = True
        Me.TextEmployeeName.Size = New System.Drawing.Size(376, 28)
        Me.TextEmployeeName.StyleController = Me.LayoutControl1
        Me.TextEmployeeName.TabIndex = 39
        '
        'MemoDetails
        '
        Me.MemoDetails.Location = New System.Drawing.Point(32, 263)
        Me.MemoDetails.Name = "MemoDetails"
        Me.MemoDetails.Size = New System.Drawing.Size(430, 28)
        Me.MemoDetails.StyleController = Me.LayoutControl1
        Me.MemoDetails.TabIndex = 36
        '
        'LookUpEditVocations
        '
        Me.LookUpEditVocations.Location = New System.Drawing.Point(32, 195)
        Me.LookUpEditVocations.Name = "LookUpEditVocations"
        Me.LookUpEditVocations.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEditVocations.Properties.DataSource = Me.VocationsTypesBindingSource
        Me.LookUpEditVocations.Properties.DisplayMember = "Vocation"
        Me.LookUpEditVocations.Properties.NullText = ""
        Me.LookUpEditVocations.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.LookUpEditVocations.Properties.ShowClearButton = False
        Me.LookUpEditVocations.Properties.ValueMember = "VocID"
        Me.LookUpEditVocations.Size = New System.Drawing.Size(430, 28)
        Me.LookUpEditVocations.StyleController = Me.LayoutControl1
        Me.LookUpEditVocations.TabIndex = 35
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colVocation, Me.colVocID})
        Me.SearchLookUpEdit1View.DetailHeight = 284
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colVocation
        '
        Me.colVocation.Caption = "نوع الاجازة"
        Me.colVocation.FieldName = "Vocation"
        Me.colVocation.MinWidth = 17
        Me.colVocation.Name = "colVocation"
        Me.colVocation.Visible = True
        Me.colVocation.VisibleIndex = 0
        '
        'colVocID
        '
        Me.colVocID.FieldName = "VocID"
        Me.colVocID.Name = "colVocID"
        '
        'TextDayNo
        '
        Me.TextDayNo.Location = New System.Drawing.Point(32, 229)
        Me.TextDayNo.Name = "TextDayNo"
        Me.TextDayNo.Size = New System.Drawing.Size(430, 28)
        Me.TextDayNo.StyleController = Me.LayoutControl1
        Me.TextDayNo.TabIndex = 34
        '
        'VocationDate
        '
        Me.VocationDate.EditValue = Nothing
        Me.VocationDate.Location = New System.Drawing.Point(32, 161)
        Me.VocationDate.Name = "VocationDate"
        Me.VocationDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.VocationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VocationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.VocationDate.Size = New System.Drawing.Size(430, 28)
        Me.VocationDate.StyleController = Me.LayoutControl1
        Me.VocationDate.TabIndex = 33
        '
        'TextEmployeeID
        '
        Me.TextEmployeeID.Location = New System.Drawing.Point(398, 50)
        Me.TextEmployeeID.Name = "TextEmployeeID"
        Me.TextEmployeeID.Properties.ReadOnly = True
        Me.TextEmployeeID.Size = New System.Drawing.Size(80, 28)
        Me.TextEmployeeID.StyleController = Me.LayoutControl1
        Me.TextEmployeeID.TabIndex = 25
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(16, 16)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.ReadOnly = True
        Me.DateEdit1.Size = New System.Drawing.Size(462, 28)
        Me.DateEdit1.StyleController = Me.LayoutControl1
        Me.DateEdit1.TabIndex = 24
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DateEdit1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(597, 34)
        Me.LayoutControlItem1.Text = "التاريخ:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.LookUpEditVocations
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(565, 34)
        Me.LayoutControlItem6.Text = "نوع الاجازة:"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TextDayNo
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(565, 34)
        Me.LayoutControlItem7.Text = "عدد الأيام:"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.MemoDetails
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(565, 34)
        Me.LayoutControlItem5.Text = "ملاحظات الاجازة:"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.VocationDate
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(565, 34)
        Me.LayoutControlItem8.Text = "تاريخ الاجازة:"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TextEmployeeName
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(382, 34)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextEmployeeID
        Me.LayoutControlItem2.Location = New System.Drawing.Point(382, 34)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(215, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(215, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(215, 34)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "الموظف:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.RequiredDailyHoures
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(298, 34)
        Me.LayoutControlItem12.Text = "الساعات اليومية المطلوبة:"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(113, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TextLeavesPeriod
        Me.LayoutControlItem11.Location = New System.Drawing.Point(298, 68)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(299, 34)
        Me.LayoutControlItem11.Text = "فترة التجاوز للمغادرات:"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(113, 13)
        '
        'AttLeavesProccessDaily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 432)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("AttLeavesProccessDaily.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "AttLeavesProccessDaily"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "معالجة المغادرات اليومية"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutFromVocations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLeavesPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RequiredDailyHoures.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoDetails.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEditVocations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDayNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEmployeeID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TextEmployeeID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents MemoDetails As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LookUpEditVocations As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colVocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextDayNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents VocationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutFromVocations As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents VocationsTypesBindingSource As BindingSource
    Friend WithEvents VocationsTypesTableAdapter As TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter
    Friend WithEvents colVocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RequiredDailyHoures As DevExpress.XtraEditors.TimeSpanEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextLeavesPeriod As DevExpress.XtraEditors.TimeSpanEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
