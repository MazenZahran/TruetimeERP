<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VocationsGroupList
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VocationsGroupList))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColBatchNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmpCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColFromDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColToDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNoteDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDisplayBatch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryButtonDisplay = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColDeleteBatch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDeleteBatch = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColVocationType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VocationsTypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TrueTimeDataSet = New TrueTime.TrueTimeDataSet()
        Me.VocationsTypesTableAdapter = New TrueTime.TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryButtonDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDeleteBatch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl"})
        '
        'DockPanel1
        '
        resources.ApplyResources(Me.DockPanel1, "DockPanel1")
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("2ee96e45-f8a6-494f-90b9-465e09b20aeb")
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
        '
        'DockPanel1_Container
        '
        resources.ApplyResources(Me.DockPanel1_Container, "DockPanel1_Container")
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        '
        'LayoutControl1
        '
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        '
        'SimpleButton1
        '
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(193, 575)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(173, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(173, 529)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.EmbeddedNavigator.AccessibleDescription = resources.GetString("GridControl1.EmbeddedNavigator.AccessibleDescription")
        Me.GridControl1.EmbeddedNavigator.AccessibleName = resources.GetString("GridControl1.EmbeddedNavigator.AccessibleName")
        Me.GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = CType(resources.GetObject("GridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip"), DevExpress.Utils.DefaultBoolean)
        Me.GridControl1.EmbeddedNavigator.Anchor = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Anchor"), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.BackgroundImage = CType(resources.GetObject("GridControl1.EmbeddedNavigator.BackgroundImage"), System.Drawing.Image)
        Me.GridControl1.EmbeddedNavigator.BackgroundImageLayout = CType(resources.GetObject("GridControl1.EmbeddedNavigator.BackgroundImageLayout"), System.Windows.Forms.ImageLayout)
        Me.GridControl1.EmbeddedNavigator.ImeMode = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ImeMode"), System.Windows.Forms.ImeMode)
        Me.GridControl1.EmbeddedNavigator.Margin = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        Me.GridControl1.EmbeddedNavigator.MaximumSize = CType(resources.GetObject("GridControl1.EmbeddedNavigator.MaximumSize"), System.Drawing.Size)
        Me.GridControl1.EmbeddedNavigator.TextLocation = CType(resources.GetObject("GridControl1.EmbeddedNavigator.TextLocation"), DevExpress.XtraEditors.NavigatorButtonsTextLocation)
        Me.GridControl1.EmbeddedNavigator.ToolTip = resources.GetString("GridControl1.EmbeddedNavigator.ToolTip")
        Me.GridControl1.EmbeddedNavigator.ToolTipIconType = CType(resources.GetObject("GridControl1.EmbeddedNavigator.ToolTipIconType"), DevExpress.Utils.ToolTipIconType)
        Me.GridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("GridControl1.EmbeddedNavigator.ToolTipTitle")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryButtonDisplay, Me.RepositoryDeleteBatch, Me.RepositoryItemLookUpEdit1})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColBatchNo, Me.ColEmpCount, Me.ColFromDate, Me.ColToDate, Me.ColNoteDetails, Me.ColDisplayBatch, Me.ColDeleteBatch, Me.ColVocationType})
        Me.GridView1.DetailHeight = 431
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColBatchNo
        '
        resources.ApplyResources(Me.ColBatchNo, "ColBatchNo")
        Me.ColBatchNo.FieldName = "BatchNo"
        Me.ColBatchNo.MinWidth = 23
        Me.ColBatchNo.Name = "ColBatchNo"
        Me.ColBatchNo.OptionsColumn.AllowEdit = False
        Me.ColBatchNo.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(CType(resources.GetObject("ColBatchNo.Summary"), DevExpress.Data.SummaryItemType), resources.GetString("ColBatchNo.Summary1"), resources.GetString("ColBatchNo.Summary2"))})
        '
        'ColEmpCount
        '
        resources.ApplyResources(Me.ColEmpCount, "ColEmpCount")
        Me.ColEmpCount.FieldName = "EmpCount"
        Me.ColEmpCount.MinWidth = 23
        Me.ColEmpCount.Name = "ColEmpCount"
        Me.ColEmpCount.OptionsColumn.AllowEdit = False
        Me.ColEmpCount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColFromDate
        '
        resources.ApplyResources(Me.ColFromDate, "ColFromDate")
        Me.ColFromDate.FieldName = "FromDate"
        Me.ColFromDate.MinWidth = 23
        Me.ColFromDate.Name = "ColFromDate"
        Me.ColFromDate.OptionsColumn.AllowEdit = False
        Me.ColFromDate.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColToDate
        '
        resources.ApplyResources(Me.ColToDate, "ColToDate")
        Me.ColToDate.FieldName = "ToDate"
        Me.ColToDate.MinWidth = 23
        Me.ColToDate.Name = "ColToDate"
        Me.ColToDate.OptionsColumn.AllowEdit = False
        Me.ColToDate.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColNoteDetails
        '
        resources.ApplyResources(Me.ColNoteDetails, "ColNoteDetails")
        Me.ColNoteDetails.FieldName = "NoteDetails"
        Me.ColNoteDetails.MinWidth = 23
        Me.ColNoteDetails.Name = "ColNoteDetails"
        Me.ColNoteDetails.OptionsColumn.AllowEdit = False
        Me.ColNoteDetails.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'ColDisplayBatch
        '
        resources.ApplyResources(Me.ColDisplayBatch, "ColDisplayBatch")
        Me.ColDisplayBatch.ColumnEdit = Me.RepositoryButtonDisplay
        Me.ColDisplayBatch.FieldName = "DisplayBatch"
        Me.ColDisplayBatch.MaxWidth = 82
        Me.ColDisplayBatch.MinWidth = 23
        Me.ColDisplayBatch.Name = "ColDisplayBatch"
        Me.ColDisplayBatch.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryButtonDisplay
        '
        resources.ApplyResources(Me.RepositoryButtonDisplay, "RepositoryButtonDisplay")
        resources.ApplyResources(EditorButtonImageOptions1, "EditorButtonImageOptions1")
        Me.RepositoryButtonDisplay.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryButtonDisplay.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepositoryButtonDisplay.Buttons1"), CType(resources.GetObject("RepositoryButtonDisplay.Buttons2"), Integer), CType(resources.GetObject("RepositoryButtonDisplay.Buttons3"), Boolean), CType(resources.GetObject("RepositoryButtonDisplay.Buttons4"), Boolean), CType(resources.GetObject("RepositoryButtonDisplay.Buttons5"), Boolean), EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, resources.GetString("RepositoryButtonDisplay.Buttons6"), CType(resources.GetObject("RepositoryButtonDisplay.Buttons7"), Object), CType(resources.GetObject("RepositoryButtonDisplay.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepositoryButtonDisplay.Buttons9"), DevExpress.Utils.ToolTipAnchor))})
        Me.RepositoryButtonDisplay.Name = "RepositoryButtonDisplay"
        Me.RepositoryButtonDisplay.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'ColDeleteBatch
        '
        resources.ApplyResources(Me.ColDeleteBatch, "ColDeleteBatch")
        Me.ColDeleteBatch.ColumnEdit = Me.RepositoryDeleteBatch
        Me.ColDeleteBatch.FieldName = "DeleteBatch"
        Me.ColDeleteBatch.MaxWidth = 82
        Me.ColDeleteBatch.MinWidth = 23
        Me.ColDeleteBatch.Name = "ColDeleteBatch"
        Me.ColDeleteBatch.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryDeleteBatch
        '
        resources.ApplyResources(Me.RepositoryDeleteBatch, "RepositoryDeleteBatch")
        resources.ApplyResources(EditorButtonImageOptions2, "EditorButtonImageOptions2")
        Me.RepositoryDeleteBatch.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryDeleteBatch.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines), resources.GetString("RepositoryDeleteBatch.Buttons1"), CType(resources.GetObject("RepositoryDeleteBatch.Buttons2"), Integer), CType(resources.GetObject("RepositoryDeleteBatch.Buttons3"), Boolean), CType(resources.GetObject("RepositoryDeleteBatch.Buttons4"), Boolean), CType(resources.GetObject("RepositoryDeleteBatch.Buttons5"), Boolean), EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, resources.GetString("RepositoryDeleteBatch.Buttons6"), CType(resources.GetObject("RepositoryDeleteBatch.Buttons7"), Object), CType(resources.GetObject("RepositoryDeleteBatch.Buttons8"), DevExpress.Utils.SuperToolTip), CType(resources.GetObject("RepositoryDeleteBatch.Buttons9"), DevExpress.Utils.ToolTipAnchor))})
        Me.RepositoryDeleteBatch.Name = "RepositoryDeleteBatch"
        Me.RepositoryDeleteBatch.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'ColVocationType
        '
        resources.ApplyResources(Me.ColVocationType, "ColVocationType")
        Me.ColVocationType.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.ColVocationType.FieldName = "VocationType"
        Me.ColVocationType.MinWidth = 23
        Me.ColVocationType.Name = "ColVocationType"
        Me.ColVocationType.OptionsColumn.AllowEdit = False
        Me.ColVocationType.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem()})
        '
        'RepositoryItemLookUpEdit1
        '
        resources.ApplyResources(Me.RepositoryItemLookUpEdit1, "RepositoryItemLookUpEdit1")
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("RepositoryItemLookUpEdit1.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.RepositoryItemLookUpEdit1.DataSource = Me.VocationsTypesBindingSource
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Vocation"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.ValueMember = "VocID"
        '
        'VocationsTypesBindingSource
        '
        Me.VocationsTypesBindingSource.DataMember = "VocationsTypes"
        Me.VocationsTypesBindingSource.DataSource = Me.TrueTimeDataSet
        '
        'TrueTimeDataSet
        '
        Me.TrueTimeDataSet.DataSetName = "TrueTimeDataSet"
        Me.TrueTimeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'VocationsTypesTableAdapter
        '
        Me.VocationsTypesTableAdapter.ClearBeforeFill = True
        '
        'VocationsGroupList
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "VocationsGroupList"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryButtonDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDeleteBatch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VocationsTypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueTimeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ColBatchNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEmpCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColFromDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColToDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNoteDetails As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDisplayBatch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryButtonDisplay As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColDeleteBatch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryDeleteBatch As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColVocationType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents TrueTimeDataSet As TrueTimeDataSet
    Friend WithEvents VocationsTypesBindingSource As BindingSource
    Friend WithEvents VocationsTypesTableAdapter As TrueTimeDataSetTableAdapters.VocationsTypesTableAdapter
End Class
