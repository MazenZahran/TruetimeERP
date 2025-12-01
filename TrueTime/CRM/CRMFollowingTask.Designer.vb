<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMFollowingTask
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMFollowingTask))
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.lblSubject = New DevExpress.XtraEditors.LabelControl()
        Me.tbSubject = New DevExpress.XtraEditors.TextEdit()
        Me.tbDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.edtStartTime = New DevExpress.XtraEditors.TimeEdit()
        Me.edtStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.UniqueID = New DevExpress.XtraEditors.TextEdit()
        Me.CreationDate = New DevExpress.XtraEditors.DateEdit()
        Me.TextTaskStatus = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.CRMTaskStatusesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueAccountingDataSet = New TrueTime.AccountingDataSet()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colStatusID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchAssignedTo = New DevExpress.XtraEditors.TextEdit()
        Me.SearchCreationUser = New DevExpress.XtraEditors.TextEdit()
        Me.CRMTaskStatusesTableAdapter = New TrueTime.AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.DarkBlue
        Me.RibbonControl1.EmptyAreaImageOptions.ImagePadding = New System.Windows.Forms.Padding(34, 30, 34, 30)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarStaticItem1})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsMenuMinWidth = 377
        Me.RibbonControl1.PageHeaderItemLinks.Add(Me.BarStaticItem1)
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(1015, 242)
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
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "BarButtonItem3"
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarStaticItem1
        '
        Me.BarStaticItem1.Caption = "حالة المهمة"
        Me.BarStaticItem1.Id = 4
        Me.BarStaticItem1.ImageOptions.SvgImage = CType(resources.GetObject("BarStaticItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BarStaticItem1.Name = "BarStaticItem1"
        Me.BarStaticItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
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
        'lblSubject
        '
        Me.lblSubject.AccessibleName = "Subject"
        Me.lblSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSubject.Location = New System.Drawing.Point(69, 278)
        Me.lblSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(45, 16)
        Me.lblSubject.TabIndex = 31
        Me.lblSubject.Text = "الموضوع:"
        '
        'tbSubject
        '
        Me.tbSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSubject.EditValue = ""
        Me.tbSubject.Location = New System.Drawing.Point(200, 272)
        Me.tbSubject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbSubject.Name = "tbSubject"
        Me.tbSubject.Properties.AccessibleName = "Subject"
        Me.tbSubject.Properties.ReadOnly = True
        Me.tbSubject.Properties.UseReadOnlyAppearance = False
        Me.tbSubject.Size = New System.Drawing.Size(633, 34)
        Me.tbSubject.TabIndex = 32
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.EditValue = ""
        Me.tbDescription.Location = New System.Drawing.Point(200, 314)
        Me.tbDescription.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Properties.AccessibleName = "Message"
        Me.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        Me.tbDescription.Properties.UseReadOnlyAppearance = False
        Me.tbDescription.Size = New System.Drawing.Size(633, 133)
        Me.tbDescription.TabIndex = 51
        '
        'LabelControl3
        '
        Me.LabelControl3.AccessibleName = "Subject"
        Me.LabelControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl3.Location = New System.Drawing.Point(-149, 366)
        Me.LabelControl3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl3.TabIndex = 48
        Me.LabelControl3.Text = "تاريخ المتابعة:"
        '
        'edtStartTime
        '
        Me.edtStartTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtStartTime.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartTime.Location = New System.Drawing.Point(413, 425)
        Me.edtStartTime.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.edtStartTime.Name = "edtStartTime"
        Me.edtStartTime.Properties.AccessibleName = "Start time"
        Me.edtStartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartTime.Properties.MaskSettings.Set("mask", "t")
        Me.edtStartTime.Properties.UseReadOnlyAppearance = False
        Me.edtStartTime.Size = New System.Drawing.Size(0, 34)
        Me.edtStartTime.TabIndex = 50
        '
        'edtStartDate
        '
        Me.edtStartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.edtStartDate.EditValue = New Date(2005, 3, 31, 0, 0, 0, 0)
        Me.edtStartDate.Location = New System.Drawing.Point(200, 467)
        Me.edtStartDate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.edtStartDate.Name = "edtStartDate"
        Me.edtStartDate.Properties.AccessibleName = "Start date"
        Me.edtStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.edtStartDate.Properties.MaxValue = New Date(4000, 1, 1, 0, 0, 0, 0)
        Me.edtStartDate.Properties.UseReadOnlyAppearance = False
        Me.edtStartDate.Size = New System.Drawing.Size(379, 34)
        Me.edtStartDate.TabIndex = 49
        '
        'LabelControl1
        '
        Me.LabelControl1.AccessibleName = "Subject"
        Me.LabelControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Location = New System.Drawing.Point(69, 323)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 16)
        Me.LabelControl1.TabIndex = 31
        Me.LabelControl1.Text = "ملاحظات:"
        '
        'LabelControl2
        '
        Me.LabelControl2.AccessibleName = "Subject"
        Me.LabelControl2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl2.Location = New System.Drawing.Point(54, 476)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(83, 16)
        Me.LabelControl2.TabIndex = 31
        Me.LabelControl2.Text = "تاريخ الاستحقاق:"
        '
        'UniqueID
        '
        Me.UniqueID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UniqueID.Location = New System.Drawing.Point(715, 176)
        Me.UniqueID.MenuManager = Me.RibbonControl1
        Me.UniqueID.Name = "UniqueID"
        Me.UniqueID.Properties.ReadOnly = True
        Me.UniqueID.Properties.UseReadOnlyAppearance = False
        Me.UniqueID.Size = New System.Drawing.Size(104, 34)
        Me.UniqueID.TabIndex = 53
        '
        'CreationDate
        '
        Me.CreationDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CreationDate.EditValue = Nothing
        Me.CreationDate.Location = New System.Drawing.Point(826, 176)
        Me.CreationDate.MenuManager = Me.RibbonControl1
        Me.CreationDate.Name = "CreationDate"
        Me.CreationDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreationDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreationDate.Properties.ReadOnly = True
        Me.CreationDate.Properties.UseReadOnlyAppearance = False
        Me.CreationDate.Size = New System.Drawing.Size(175, 34)
        Me.CreationDate.TabIndex = 52
        '
        'TextTaskStatus
        '
        Me.TextTaskStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTaskStatus.Location = New System.Drawing.Point(887, 260)
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
        Me.TextTaskStatus.Size = New System.Drawing.Size(114, 34)
        Me.TextTaskStatus.TabIndex = 54
        Me.TextTaskStatus.Visible = False
        '
        'CRMTaskStatusesBindingSource
        '
        Me.CRMTaskStatusesBindingSource.DataMember = "CRMTaskStatuses"
        Me.CRMTaskStatusesBindingSource.DataSource = Me.TrueAccountingDataSet
        '
        'TrueAccountingDataSet
        '
        Me.TrueAccountingDataSet.DataSetName = "TrueAccountingDataSet"
        Me.TrueAccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'SearchAssignedTo
        '
        Me.SearchAssignedTo.Location = New System.Drawing.Point(887, 204)
        Me.SearchAssignedTo.MenuManager = Me.RibbonControl1
        Me.SearchAssignedTo.Name = "SearchAssignedTo"
        Me.SearchAssignedTo.Size = New System.Drawing.Size(114, 34)
        Me.SearchAssignedTo.TabIndex = 55
        Me.SearchAssignedTo.Visible = False
        '
        'SearchCreationUser
        '
        Me.SearchCreationUser.Location = New System.Drawing.Point(887, 232)
        Me.SearchCreationUser.Name = "SearchCreationUser"
        Me.SearchCreationUser.Size = New System.Drawing.Size(114, 34)
        Me.SearchCreationUser.TabIndex = 55
        Me.SearchCreationUser.Visible = False
        '
        'CRMTaskStatusesTableAdapter
        '
        Me.CRMTaskStatusesTableAdapter.ClearBeforeFill = True
        '
        'CRMFollowingTask
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 552)
        Me.Controls.Add(Me.SearchCreationUser)
        Me.Controls.Add(Me.SearchAssignedTo)
        Me.Controls.Add(Me.TextTaskStatus)
        Me.Controls.Add(Me.UniqueID)
        Me.Controls.Add(Me.CreationDate)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.edtStartTime)
        Me.Controls.Add(Me.edtStartDate)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.tbSubject)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "CRMFollowingTask"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CRMFollowingTask"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbSubject.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.edtStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UniqueID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreationDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTaskStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CRMTaskStatusesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueAccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchAssignedTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchCreationUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Protected WithEvents lblSubject As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tbSubject As DevExpress.XtraEditors.TextEdit
    Friend WithEvents tbDescription As DevExpress.XtraEditors.MemoEdit
    Protected WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents edtStartTime As DevExpress.XtraEditors.TimeEdit
    Friend WithEvents edtStartDate As DevExpress.XtraEditors.DateEdit
    Protected WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Protected WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarStaticItem1 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents UniqueID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CreationDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TextTaskStatus As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colStatusID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchAssignedTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SearchCreationUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TrueAccountingDataSet As AccountingDataSet
    Friend WithEvents CRMTaskStatusesBindingSource As BindingSource
    Friend WithEvents CRMTaskStatusesTableAdapter As AccountingDataSetTableAdapters.CRMTaskStatusesTableAdapter
End Class
