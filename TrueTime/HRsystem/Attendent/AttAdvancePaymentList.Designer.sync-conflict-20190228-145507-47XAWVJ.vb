<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AttAdvancePaymentList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AttAdvancePaymentList))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.ColPaymentID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaymentDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaymentAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaymentType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaymentNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColOpen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonOpen = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonOpen, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("f2a71cfc-2316-45e1-a10a-a093c62fc869")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(200, 502)
        Me.DockPanel1.Text = "فلترة"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(5, 23)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(191, 475)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(200, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonOpen})
        Me.GridControl1.Size = New System.Drawing.Size(552, 502)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColPaymentID, Me.ColPaymentDate, Me.ColEmployeeID, Me.ColEmployeeName, Me.ColPaymentAmount, Me.ColPaymentType, Me.ColPaymentNote, Me.ColOpen})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(191, 475)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(191, 475)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(167, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "تحديث"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(171, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(171, 429)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'ColPaymentID
        '
        Me.ColPaymentID.Caption = "رقم السند"
        Me.ColPaymentID.FieldName = "PaymentID"
        Me.ColPaymentID.Name = "ColPaymentID"
        Me.ColPaymentID.Visible = True
        Me.ColPaymentID.VisibleIndex = 0
        '
        'ColPaymentDate
        '
        Me.ColPaymentDate.Caption = "التاريخ"
        Me.ColPaymentDate.FieldName = "PaymentDate"
        Me.ColPaymentDate.Name = "ColPaymentDate"
        Me.ColPaymentDate.Visible = True
        Me.ColPaymentDate.VisibleIndex = 1
        '
        'ColEmployeeID
        '
        Me.ColEmployeeID.Caption = "الموظف"
        Me.ColEmployeeID.FieldName = "EmployeeID"
        Me.ColEmployeeID.Name = "ColEmployeeID"
        Me.ColEmployeeID.Visible = True
        Me.ColEmployeeID.VisibleIndex = 2
        '
        'ColEmployeeName
        '
        Me.ColEmployeeName.Caption = "اسم الموظف"
        Me.ColEmployeeName.FieldName = "EmployeeName"
        Me.ColEmployeeName.Name = "ColEmployeeName"
        Me.ColEmployeeName.Visible = True
        Me.ColEmployeeName.VisibleIndex = 3
        '
        'ColPaymentAmount
        '
        Me.ColPaymentAmount.Caption = "المبلغ"
        Me.ColPaymentAmount.FieldName = "PaymentAmount"
        Me.ColPaymentAmount.Name = "ColPaymentAmount"
        Me.ColPaymentAmount.Visible = True
        Me.ColPaymentAmount.VisibleIndex = 4
        '
        'ColPaymentType
        '
        Me.ColPaymentType.Caption = "نوع السلفة"
        Me.ColPaymentType.FieldName = "PaymentType"
        Me.ColPaymentType.Name = "ColPaymentType"
        Me.ColPaymentType.Visible = True
        Me.ColPaymentType.VisibleIndex = 5
        '
        'ColPaymentNote
        '
        Me.ColPaymentNote.Caption = "ملاحظات"
        Me.ColPaymentNote.FieldName = "PaymentNote"
        Me.ColPaymentNote.Name = "ColPaymentNote"
        Me.ColPaymentNote.Visible = True
        Me.ColPaymentNote.VisibleIndex = 6
        '
        'ColOpen
        '
        Me.ColOpen.Caption = "فتح"
        Me.ColOpen.ColumnEdit = Me.RepositoryItemButtonOpen
        Me.ColOpen.FieldName = "Open"
        Me.ColOpen.MaxWidth = 50
        Me.ColOpen.Name = "ColOpen"
        Me.ColOpen.Visible = True
        Me.ColOpen.VisibleIndex = 7
        Me.ColOpen.Width = 50
        '
        'RepositoryItemButtonOpen
        '
        Me.RepositoryItemButtonOpen.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.RepositoryItemButtonOpen.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryItemButtonOpen.Name = "RepositoryItemButtonOpen"
        Me.RepositoryItemButtonOpen.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'AttAdvancePaymentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 502)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "AttAdvancePaymentList"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "السلف"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonOpen, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ColPaymentID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaymentDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaymentAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaymentType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaymentNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOpen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonOpen As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
