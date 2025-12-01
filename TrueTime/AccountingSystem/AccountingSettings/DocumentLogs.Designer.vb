<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DocumentLogs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentLogs))
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDocID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryDocNo = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        Me.ColLogName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUserID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUserName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLogDateTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeviceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLogDetails = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLogType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryDocNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("a5c8d92e-f822-49b2-a677-92a8a24e353e")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(247, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(247, 641)
        Me.DockPanel1.Text = "خيارات التقرير"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.LayoutControl2)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 26)
        Me.DockPanel1_Container.Margin = New System.Windows.Forms.Padding(4)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(240, 612)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.SimpleButton2)
        Me.LayoutControl2.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(240, 612)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(12, 578)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(216, 22)
        Me.SimpleButton2.StyleController = Me.LayoutControl2
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "طباعة"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 552)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(216, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl2
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "تحديث"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(240, 612)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(220, 540)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton2
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 566)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(220, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.SimpleButton1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 540)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(220, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(247, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1043, 641)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryDocNo})
        Me.GridControl1.Size = New System.Drawing.Size(1019, 617)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColDocCode, Me.ColDocName, Me.ColDocID, Me.ColLogName, Me.ColUserID, Me.ColUserName, Me.ColLogDateTime, Me.ColDeviceName, Me.ColLogDetails, Me.ColLogType})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColID
        '
        Me.ColID.Caption = "ID"
        Me.ColID.FieldName = "LogID"
        Me.ColID.MinWidth = 23
        Me.ColID.Name = "ColID"
        Me.ColID.OptionsColumn.AllowEdit = False
        Me.ColID.OptionsColumn.FixedWidth = True
        Me.ColID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LogID", "{0}")})
        Me.ColID.Width = 87
        '
        'ColDocCode
        '
        Me.ColDocCode.Caption = "كود السند"
        Me.ColDocCode.FieldName = "DocCode"
        Me.ColDocCode.MinWidth = 23
        Me.ColDocCode.Name = "ColDocCode"
        Me.ColDocCode.OptionsColumn.AllowEdit = False
        Me.ColDocCode.OptionsColumn.FixedWidth = True
        Me.ColDocCode.Width = 87
        '
        'ColDocName
        '
        Me.ColDocName.Caption = "السند"
        Me.ColDocName.FieldName = "DocName"
        Me.ColDocName.MinWidth = 23
        Me.ColDocName.Name = "ColDocName"
        Me.ColDocName.OptionsColumn.AllowEdit = False
        Me.ColDocName.OptionsColumn.FixedWidth = True
        Me.ColDocName.Visible = True
        Me.ColDocName.VisibleIndex = 0
        Me.ColDocName.Width = 128
        '
        'ColDocID
        '
        Me.ColDocID.Caption = "رقم السند"
        Me.ColDocID.ColumnEdit = Me.RepositoryDocNo
        Me.ColDocID.FieldName = "DocID"
        Me.ColDocID.MinWidth = 23
        Me.ColDocID.Name = "ColDocID"
        Me.ColDocID.OptionsColumn.FixedWidth = True
        Me.ColDocID.Visible = True
        Me.ColDocID.VisibleIndex = 1
        Me.ColDocID.Width = 87
        '
        'RepositoryDocNo
        '
        Me.RepositoryDocNo.AutoHeight = False
        Me.RepositoryDocNo.Name = "RepositoryDocNo"
        Me.RepositoryDocNo.SingleClick = True
        '
        'ColLogName
        '
        Me.ColLogName.Caption = "نوع الحركة"
        Me.ColLogName.FieldName = "LogName"
        Me.ColLogName.MinWidth = 23
        Me.ColLogName.Name = "ColLogName"
        Me.ColLogName.OptionsColumn.AllowEdit = False
        Me.ColLogName.OptionsColumn.FixedWidth = True
        Me.ColLogName.Visible = True
        Me.ColLogName.VisibleIndex = 2
        Me.ColLogName.Width = 87
        '
        'ColUserID
        '
        Me.ColUserID.Caption = "المستخدم"
        Me.ColUserID.FieldName = "UserID"
        Me.ColUserID.MinWidth = 23
        Me.ColUserID.Name = "ColUserID"
        Me.ColUserID.OptionsColumn.AllowEdit = False
        Me.ColUserID.OptionsColumn.FixedWidth = True
        Me.ColUserID.Visible = True
        Me.ColUserID.VisibleIndex = 3
        Me.ColUserID.Width = 90
        '
        'ColUserName
        '
        Me.ColUserName.Caption = "اسم المستخدم"
        Me.ColUserName.FieldName = "UserName"
        Me.ColUserName.MinWidth = 23
        Me.ColUserName.Name = "ColUserName"
        Me.ColUserName.OptionsColumn.AllowEdit = False
        Me.ColUserName.OptionsColumn.FixedWidth = True
        Me.ColUserName.Visible = True
        Me.ColUserName.VisibleIndex = 4
        Me.ColUserName.Width = 160
        '
        'ColLogDateTime
        '
        Me.ColLogDateTime.Caption = "تاريخ الحركة"
        Me.ColLogDateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss"
        Me.ColLogDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColLogDateTime.FieldName = "LogDateTime"
        Me.ColLogDateTime.MinWidth = 23
        Me.ColLogDateTime.Name = "ColLogDateTime"
        Me.ColLogDateTime.OptionsColumn.AllowEdit = False
        Me.ColLogDateTime.OptionsColumn.FixedWidth = True
        Me.ColLogDateTime.Visible = True
        Me.ColLogDateTime.VisibleIndex = 5
        Me.ColLogDateTime.Width = 150
        '
        'ColDeviceName
        '
        Me.ColDeviceName.Caption = "الجهاز"
        Me.ColDeviceName.FieldName = "DeviceName"
        Me.ColDeviceName.MinWidth = 23
        Me.ColDeviceName.Name = "ColDeviceName"
        Me.ColDeviceName.OptionsColumn.AllowEdit = False
        Me.ColDeviceName.OptionsColumn.FixedWidth = True
        Me.ColDeviceName.Visible = True
        Me.ColDeviceName.VisibleIndex = 6
        Me.ColDeviceName.Width = 140
        '
        'ColLogDetails
        '
        Me.ColLogDetails.Caption = "التفاصيل"
        Me.ColLogDetails.FieldName = "LogDetails"
        Me.ColLogDetails.MinWidth = 23
        Me.ColLogDetails.Name = "ColLogDetails"
        Me.ColLogDetails.OptionsColumn.AllowEdit = False
        Me.ColLogDetails.Visible = True
        Me.ColLogDetails.VisibleIndex = 7
        Me.ColLogDetails.Width = 107
        '
        'ColLogType
        '
        Me.ColLogType.Caption = "العملية"
        Me.ColLogType.FieldName = "LogType"
        Me.ColLogType.MinWidth = 23
        Me.ColLogType.Name = "ColLogType"
        Me.ColLogType.OptionsColumn.AllowEdit = False
        Me.ColLogType.OptionsColumn.FixedWidth = True
        Me.ColLogType.Width = 87
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1043, 641)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.GridControl1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1023, 621)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'DocumentLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 641)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.DockPanel1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("DocumentLogs.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DocumentLogs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بيانات الاستخدام"
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryDocNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDocID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLogName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUserID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUserName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLogDateTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeviceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLogDetails As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLogType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryDocNo As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
