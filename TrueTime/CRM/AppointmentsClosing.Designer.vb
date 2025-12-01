<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AppointmentsClosing
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppointmentsClosing))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.tbDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.UniqueID = New DevExpress.XtraEditors.TextEdit()
        Me.Referance = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.ReferancesListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueAccountingDataSet = New TrueTime.AccountingDataSet()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColRefID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRefAccID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CreationDate = New DevExpress.XtraEditors.DateEdit()
        Me.lblPercentCompleteValue = New DevExpress.XtraEditors.LabelControl()
        Me.tbProgress = New DevExpress.XtraEditors.TrackBarControl()
        Me.lblPercentComplete = New DevExpress.XtraEditors.LabelControl()
        Me.SearchAssignedTo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.EmployeesData1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.tbSubject = New DevExpress.XtraEditors.TextEdit()
        Me.lblLocation = New DevExpress.XtraEditors.LabelControl()
        Me.edtEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.tbLocation = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.edtStartTime = New DevExpress.XtraEditors.TimeEdit()
        Me.edtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextTaskStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.CRMTaskStatusesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colStatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EmployeesData1TableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter()
        Me.ReferancesListTableAdapter = New TrueTime.AccountingDataSetTableAdapters.ReferancesListTableAdapter()
        Me.CRMTaskStatusesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter()
        Me.SearchCreationUser = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 628)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1015, 45)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(34, 30, 34, 30)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 377
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1015, 243)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "انجاز"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "حفظ المهمة"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem2.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "خيارات"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.EditValue = ""
        Me.tbDescription.Location = New System.Drawing.Point(17, 452)
        Me.tbDescription.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Properties.AccessibleName = "Message"
        Me.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        Me.tbDescription.Properties.UseReadOnlyAppearance = False
        Me.tbDescription.Size = New System.Drawing.Size(984, 101)
        Me.tbDescription.TabIndex = 47
        '
        'UniqueID
        '
        Me.UniqueID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UniqueID.Location = New System.Drawing.Point(691, 269)
        Me.UniqueID.MenuManager = Me.RibbonControl1
        Me.UniqueID.Name = "UniqueID"
        Me.UniqueID.Properties.ReadOnly = True
        Me.UniqueID.Properties.UseReadOnlyAppearance = False
        Me.UniqueID.Size = New System.Drawing.Size(93, 34)
        Me.UniqueID.TabIndex = 49
        '
        'Referance
        '
        Me.Referance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Referance.Location = New System.Drawing.Point(113, 360)
        Me.Referance.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Referance.Name = "Referance"
        Me.Referance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Referance.Properties.DataSource = Me.ReferancesListBindingSource
        Me.Referance.Properties.DisplayMember = "RefName"
        Me.Referance.Properties.NullText = ""
        Me.Referance.Properties.PopupView = Me.GridView3
        Me.Referance.Properties.ShowAddNewButton = True
        Me.Referance.Properties.UseReadOnlyAppearance = False
        Me.Referance.Properties.ValueMember = "RefNo"
        Me.Referance.Size = New System.Drawing.Size(506, 34)
        Me.Referance.TabIndex = 48
        '
        'ReferancesListBindingSource
        '
        Me.ReferancesListBindingSource.DataMember = "ReferancesList"
        Me.ReferancesListBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'TrueAccountingDataSet
        '
        Me.TrueAccountingDataSet.DataSetName = "TrueAccountingDataSet"
        Me.TrueAccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColRefID, Me.ColRefNo, Me.ColRefName, Me.ColRefTypeName, Me.ColRefAccID, Me.ColTypeID, Me.ColCurrency})
        Me.GridView3.DetailHeight = 431
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColRefID
        '
        Me.ColRefID.Caption = "ID"
        Me.ColRefID.FieldName = "RefID"
        Me.ColRefID.MinWidth = 26
        Me.ColRefID.Name = "ColRefID"
        Me.ColRefID.Width = 99
        '
        'ColRefNo
        '
        Me.ColRefNo.Caption = "رقم المرجع"
        Me.ColRefNo.FieldName = "RefNo"
        Me.ColRefNo.MinWidth = 26
        Me.ColRefNo.Name = "ColRefNo"
        Me.ColRefNo.Visible = True
        Me.ColRefNo.VisibleIndex = 0
        Me.ColRefNo.Width = 99
        '
        'ColRefName
        '
        Me.ColRefName.Caption = "المرجع"
        Me.ColRefName.FieldName = "RefName"
        Me.ColRefName.MinWidth = 26
        Me.ColRefName.Name = "ColRefName"
        Me.ColRefName.Visible = True
        Me.ColRefName.VisibleIndex = 1
        Me.ColRefName.Width = 99
        '
        'ColRefTypeName
        '
        Me.ColRefTypeName.Caption = "نوع المرجع"
        Me.ColRefTypeName.FieldName = "RefTypeName"
        Me.ColRefTypeName.MinWidth = 26
        Me.ColRefTypeName.Name = "ColRefTypeName"
        Me.ColRefTypeName.Visible = True
        Me.ColRefTypeName.VisibleIndex = 2
        Me.ColRefTypeName.Width = 99
        '
        'ColRefAccID
        '
        Me.ColRefAccID.Caption = "رقم الحساب"
        Me.ColRefAccID.FieldName = "RefAccID"
        Me.ColRefAccID.MinWidth = 26
        Me.ColRefAccID.Name = "ColRefAccID"
        Me.ColRefAccID.Width = 99
        '
        'ColTypeID
        '
        Me.ColTypeID.Caption = "نوع المرجع"
        Me.ColTypeID.FieldName = "TypeID"
        Me.ColTypeID.MinWidth = 26
        Me.ColTypeID.Name = "ColTypeID"
        Me.ColTypeID.Width = 99
        '
        'ColCurrency
        '
        Me.ColCurrency.Caption = "العملة"
        Me.ColCurrency.FieldName = "Currency"
        Me.ColCurrency.MinWidth = 26
        Me.ColCurrency.Name = "ColCurrency"
        Me.ColCurrency.Width = 99
        '
        'CreationDate
        '
        Me.CreationDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CreationDate.EditValue = Nothing
        Me.CreationDate.Location = New System.Drawing.Point(790, 269)
        Me.CreationDate.MenuManager = Me.RibbonControl1
        Me.CreationDate.Name = "CreationDate"
        Me.CreationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreationDate.Properties.ReadOnly = True
        Me.CreationDate.Properties.UseReadOnlyAppearance = False
        Me.CreationDate.Size = New System.Drawing.Size(141, 34)
        Me.CreationDate.TabIndex = 46
        '
        'lblPercentCompleteValue
        '
        Me.lblPercentCompleteValue.AccessibleName = "PercentCompleteValue"
        Me.lblPercentCompleteValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPercentCompleteValue.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentCompleteValue.Appearance.Options.UseBackColor = True
        Me.lblPercentCompleteValue.Location = New System.Drawing.Point(878, 410)
        Me.lblPercentCompleteValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblPercentCompleteValue.Name = "lblPercentCompleteValue"
        Me.lblPercentCompleteValue.Size = New System.Drawing.Size(21, 16)
        Me.lblPercentCompleteValue.TabIndex = 45
        Me.lblPercentCompleteValue.Text = "100"
        '
        'tbProgress
        '
        Me.tbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbProgress.EditValue = Nothing
        Me.tbProgress.Enabled = False
        Me.tbProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tbProgress.Location = New System.Drawing.Point(19, 410)
        Me.tbProgress.Margin = New System.Windows.Forms.Padding(0)
        Me.tbProgress.Name = "tbProgress"
        Me.tbProgress.Properties.AutoSize = False
        Me.tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.tbProgress.Properties.Maximum = 100
        Me.tbProgress.Properties.ShowValueToolTip = True
        Me.tbProgress.Properties.TickFrequency = 10
        Me.tbProgress.Size = New System.Drawing.Size(840, 23)
        Me.tbProgress.TabIndex = 44
        '
        'lblPercentComplete
        '
        Me.lblPercentComplete.AccessibleName = "PercentComplete"
        Me.lblPercentComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPercentComplete.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentComplete.Appearance.Options.UseBackColor = True
        Me.lblPercentComplete.Location = New System.Drawing.Point(909, 410)
        Me.lblPercentComplete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblPercentComplete.Name = "lblPercentComplete"
        Me.lblPercentComplete.Size = New System.Drawing.Size(76, 16)
        Me.lblPercentComplete.TabIndex = 43
        Me.lblPercentComplete.Text = "% &Complete:"
        '
        'SearchAssignedTo
        '
        Me.SearchAssignedTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchAssignedTo.Location = New System.Drawing.Point(113, 319)
        Me.SearchAssignedTo.Name = "SearchAssignedTo"
        Me.SearchAssignedTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchAssignedTo.Properties.DataSource = Me.EmployeesData1BindingSource
        Me.SearchAssignedTo.Properties.DisplayMember = "EmployeeName"
        Me.SearchAssignedTo.Properties.NullText = ""
        Me.SearchAssignedTo.Properties.PopupView = Me.GridView1
        Me.SearchAssignedTo.Properties.UseReadOnlyAppearance = False
        Me.SearchAssignedTo.Properties.ValueMember = "EmployeeID"
        Me.SearchAssignedTo.Size = New System.Drawing.Size(506, 34)
        Me.SearchAssignedTo.TabIndex = 40
        '
        'EmployeesData1BindingSource
        '
        Me.EmployeesData1BindingSource.DataMember = "EmployeesData1"
        Me.EmployeesData1BindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.Locale = New System.Globalization.CultureInfo("")
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "EmployeeID"
        Me.GridColumn1.MinWidth = 23
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 86
        '
        'GridColumn2
        '
        Me.GridColumn2.FieldName = "EmployeeName"
        Me.GridColumn2.MinWidth = 23
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 86
        '
        'LabelControl1
        '
        Me.LabelControl1.AccessibleName = "Subject"
        Me.LabelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Location = New System.Drawing.Point(17, 330)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(38, 16)
        Me.LabelControl1.TabIndex = 28
        Me.LabelControl1.Text = "الموظف:"
        '
        'LabelControl3
        '
        Me.LabelControl3.AccessibleName = "Subject"
        Me.LabelControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Location = New System.Drawing.Point(26, 587)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl3.TabIndex = 29
        Me.LabelControl3.Text = "تاريخ المتابعة:"
        '
        'lblSubject
        '
        Me.lblSubject.AccessibleName = "Subject"
        Me.lblSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubject.Location = New System.Drawing.Point(19, 287)
        Me.lblSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(45, 16)
        Me.lblSubject.TabIndex = 27
        Me.lblSubject.Text = "الموضوع:"
        '
        'tbSubject
        '
        Me.tbSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSubject.EditValue = ""
        Me.tbSubject.Location = New System.Drawing.Point(113, 278)
        Me.tbSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Properties.AccessibleName = "Subject"
        Me.tbSubject.Properties.ReadOnly = True
        Me.tbSubject.Properties.UseReadOnlyAppearance = False
        Me.tbSubject.Size = New System.Drawing.Size(506, 34)
        Me.tbSubject.TabIndex = 30
        '
        'lblLocation
        '
        Me.lblLocation.AccessibleName = "Location"
        Me.lblLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLocation.Location = New System.Drawing.Point(937, 237)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(54, 16)
        Me.lblLocation.TabIndex = 31
        Me.lblLocation.Text = "&Location:"
        Me.lblLocation.Visible = False
        '
        'edtEndDate
        '
        Me.edtEndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtEndDate.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtEndDate.Location = New System.Drawing.Point(937, 261)
        Me.edtEndDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.edtEndDate.Name = "edtEndDate"
        Me.edtEndDate.Properties.AccessibleName = "End date"
        Me.edtEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtEndDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtEndDate.Properties.UseReadOnlyAppearance = False
        Me.edtEndDate.Size = New System.Drawing.Size(57, 34)
        Me.edtEndDate.TabIndex = 37
        Me.edtEndDate.Visible = False
        '
        'tbLocation
        '
        Me.tbLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLocation.EditValue = ""
        Me.tbLocation.Location = New System.Drawing.Point(937, 291)
        Me.tbLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbLocation.Name = "tbLocation"
        Me.tbLocation.Properties.AccessibleName = "Location"
        Me.tbLocation.Properties.UseReadOnlyAppearance = False
        Me.tbLocation.Size = New System.Drawing.Size(59, 34)
        Me.tbLocation.TabIndex = 32
        Me.tbLocation.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.AccessibleName = "End time"
        Me.LabelControl5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl5.Location = New System.Drawing.Point(17, 369)
        Me.LabelControl5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(25, 16)
        Me.LabelControl5.TabIndex = 36
        Me.LabelControl5.Text = "الذمة:"
        '
        'edtStartTime
        '
        Me.edtStartTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtStartTime.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartTime.Location = New System.Drawing.Point(501, 578)
        Me.edtStartTime.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.edtStartTime.Name = "edtStartTime"
        Me.edtStartTime.Properties.AccessibleName = "Start time"
        Me.edtStartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartTime.Properties.MaskSettings.Set("mask", "t")
        Me.edtStartTime.Properties.UseReadOnlyAppearance = False
        Me.edtStartTime.Size = New System.Drawing.Size(118, 34)
        Me.edtStartTime.TabIndex = 34
        '
        'edtStartDate
        '
        Me.edtStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtStartDate.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartDate.Location = New System.Drawing.Point(113, 578)
        Me.edtStartDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.edtStartDate.Name = "edtStartDate"
        Me.edtStartDate.Properties.AccessibleName = "Start date"
        Me.edtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtStartDate.Properties.UseReadOnlyAppearance = False
        Me.edtStartDate.Size = New System.Drawing.Size(382, 34)
        Me.edtStartDate.TabIndex = 33
        '
        'TextTaskStatus
        '
        Me.TextTaskStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTaskStatus.Location = New System.Drawing.Point(837, 64)
        Me.TextTaskStatus.MenuManager = Me.RibbonControl1
        Me.TextTaskStatus.Name = "TextTaskStatus"
        Me.TextTaskStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TextTaskStatus.Properties.DataSource = Me.CRMTaskStatusesBindingSource
        Me.TextTaskStatus.Properties.DisplayMember = "StatusName"
        Me.TextTaskStatus.Properties.NullText = ""
        Me.TextTaskStatus.Properties.PopupView = Me.GridView2
        Me.TextTaskStatus.Properties.ReadOnly = True
        Me.TextTaskStatus.Properties.UseReadOnlyAppearance = False
        Me.TextTaskStatus.Properties.ValueMember = "StatusID"
        Me.TextTaskStatus.Size = New System.Drawing.Size(165, 34)
        Me.TextTaskStatus.TabIndex = 42
        '
        'CRMTaskStatusesBindingSource
        '
        Me.CRMTaskStatusesBindingSource.DataMember = "CRMTaskStatuses"
        Me.CRMTaskStatusesBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colStatusID, Me.colStatusName})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsEditForm.PopupEditFormWidth = 914
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colStatusID
        '
        Me.colStatusID.Caption = "ID"
        Me.colStatusID.FieldName = "StatusID"
        Me.colStatusID.MinWidth = 23
        Me.colStatusID.Name = "colStatusID"
        Me.colStatusID.Width = 86
        '
        'colStatusName
        '
        Me.colStatusName.Caption = "الحالة"
        Me.colStatusName.FieldName = "StatusName"
        Me.colStatusName.MinWidth = 23
        Me.colStatusName.Name = "colStatusName"
        Me.colStatusName.Visible = True
        Me.colStatusName.VisibleIndex = 0
        Me.colStatusName.Width = 86
        '
        'EmployeesData1TableAdapter
        '
        Me.EmployeesData1TableAdapter.ClearBeforeFill = True
        '
        'ReferancesListTableAdapter
        '
        Me.ReferancesListTableAdapter.ClearBeforeFill = True
        '
        'CRMTaskStatusesTableAdapter
        '
        Me.CRMTaskStatusesTableAdapter.ClearBeforeFill = True
        '
        'SearchCreationUser
        '
        Me.SearchCreationUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchCreationUser.Location = New System.Drawing.Point(691, 309)
        Me.SearchCreationUser.MenuManager = Me.RibbonControl1
        Me.SearchCreationUser.Name = "SearchCreationUser"
        Me.SearchCreationUser.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchCreationUser.Properties.DataSource = Me.EmployeesData1BindingSource
        Me.SearchCreationUser.Properties.DisplayMember = "EmployeeName"
        Me.SearchCreationUser.Properties.NullText = ""
        Me.SearchCreationUser.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchCreationUser.Properties.UseReadOnlyAppearance = False
        Me.SearchCreationUser.Properties.ValueMember = "EmployeeID"
        Me.SearchCreationUser.Size = New System.Drawing.Size(240, 34)
        Me.SearchCreationUser.TabIndex = 52
        Me.SearchCreationUser.Visible = False
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEmployeeID, Me.colEmployeeName})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsEditForm.PopupEditFormWidth = 914
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colEmployeeID
        '
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.MinWidth = 23
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.Visible = True
        Me.colEmployeeID.VisibleIndex = 0
        Me.colEmployeeID.Width = 86
        '
        'colEmployeeName
        '
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.MinWidth = 23
        Me.colEmployeeName.Name = "colEmployeeName"
        Me.colEmployeeName.Visible = True
        Me.colEmployeeName.VisibleIndex = 1
        Me.colEmployeeName.Width = 86
        '
        'AppointmentsClosing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 673)
        Me.Controls.Add(Me.SearchCreationUser)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.UniqueID)
        Me.Controls.Add(Me.Referance)
        Me.Controls.Add(Me.CreationDate)
        Me.Controls.Add(Me.lblPercentCompleteValue)
        Me.Controls.Add(Me.tbProgress)
        Me.Controls.Add(Me.lblPercentComplete)
        Me.Controls.Add(Me.SearchAssignedTo)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.edtEndDate)
        Me.Controls.Add(Me.tbLocation)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.edtStartTime)
        Me.Controls.Add(Me.edtStartDate)
        Me.Controls.Add(Me.TextTaskStatus)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "AppointmentsClosing"
        Me.Ribbon = Me.RibbonControl1
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "AppointmentsClosing"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Referance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReferancesListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbProgress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesData1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents UniqueID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Referance As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColRefID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRefAccID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CreationDate As DevExpress.XtraEditors.DateEdit
    Protected WithEvents lblPercentCompleteValue As DevExpress.XtraEditors.LabelControl
    Protected WithEvents tbProgress As DevExpress.XtraEditors.TrackBarControl
    Protected WithEvents lblPercentComplete As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SearchAssignedTo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Protected WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents lblSubject As DevExpress.XtraEditors.LabelControl
    Protected WithEvents lblLocation As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtEndDate As DevExpress.XtraEditors.DateEdit
    Protected WithEvents tbLocation As DevExpress.XtraEditors.TextEdit
    Protected WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtStartTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents TextTaskStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colStatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tbSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents edtStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents EmployeesData1BindingSource As BindingSource
    Friend WithEvents EmployeesData1TableAdapter As TrueTimeDataSetTableAdapters.EmployeesData1TableAdapter
    Friend WithEvents TrueAccountingDataSet As AccountingDataSet
    Friend WithEvents ReferancesListBindingSource As BindingSource
    Friend WithEvents ReferancesListTableAdapter As AccountingDataSetTableAdapters.ReferancesListTableAdapter
    Friend WithEvents CRMTaskStatusesBindingSource As BindingSource
    Friend WithEvents CRMTaskStatusesTableAdapter As AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter
    Friend WithEvents SearchCreationUser As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
End Class
