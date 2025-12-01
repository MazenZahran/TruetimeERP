<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountAddNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountAddNew))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TextFatherAccName = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchAccType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColAccTypeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccTypeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.FinancialSector = New DevExpress.XtraEditors.LookUpEdit()
        Me.FinancialStatment = New DevExpress.XtraEditors.LookUpEdit()
        Me.Currency = New DevExpress.XtraEditors.LookUpEdit()
        Me.TextAccName = New DevExpress.XtraEditors.TextEdit()
        Me.TextAccNo = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextFatherAccName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchAccType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinancialSector.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FinancialStatment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAccName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAccNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        resources.ApplyResources(Me.LayoutControl1, "LayoutControl1")
        Me.LayoutControl1.Controls.Add(Me.TextFatherAccName)
        Me.LayoutControl1.Controls.Add(Me.SearchAccType)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.FinancialSector)
        Me.LayoutControl1.Controls.Add(Me.FinancialStatment)
        Me.LayoutControl1.Controls.Add(Me.Currency)
        Me.LayoutControl1.Controls.Add(Me.TextAccName)
        Me.LayoutControl1.Controls.Add(Me.TextAccNo)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        '
        'TextFatherAccName
        '
        resources.ApplyResources(Me.TextFatherAccName, "TextFatherAccName")
        Me.TextFatherAccName.Name = "TextFatherAccName"
        Me.TextFatherAccName.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("TextFatherAccName.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.TextFatherAccName.Properties.DisplayMember = "AccName"
        Me.TextFatherAccName.Properties.NullText = resources.GetString("TextFatherAccName.Properties.NullText")
        Me.TextFatherAccName.Properties.PopupView = Me.GridView1
        Me.TextFatherAccName.Properties.ValueMember = "AccNo"
        Me.TextFatherAccName.StyleController = Me.LayoutControl1
        '
        'GridView1
        '
        resources.ApplyResources(Me.GridView1, "GridView1")
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.DetailHeight = 431
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        resources.ApplyResources(Me.GridColumn1, "GridColumn1")
        Me.GridColumn1.FieldName = "AccNo"
        Me.GridColumn1.MinWidth = 23
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        resources.ApplyResources(Me.GridColumn2, "GridColumn2")
        Me.GridColumn2.FieldName = "AccName"
        Me.GridColumn2.MinWidth = 23
        Me.GridColumn2.Name = "GridColumn2"
        '
        'SearchAccType
        '
        resources.ApplyResources(Me.SearchAccType, "SearchAccType")
        Me.SearchAccType.Name = "SearchAccType"
        Me.SearchAccType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("SearchAccType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.SearchAccType.Properties.DisplayMember = "AccTypeName"
        Me.SearchAccType.Properties.NullText = resources.GetString("SearchAccType.Properties.NullText")
        Me.SearchAccType.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchAccType.Properties.ValueMember = "AccTypeID"
        Me.SearchAccType.StyleController = Me.LayoutControl1
        '
        'SearchLookUpEdit1View
        '
        resources.ApplyResources(Me.SearchLookUpEdit1View, "SearchLookUpEdit1View")
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColAccTypeID, Me.ColAccTypeName})
        Me.SearchLookUpEdit1View.DetailHeight = 431
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'ColAccTypeID
        '
        resources.ApplyResources(Me.ColAccTypeID, "ColAccTypeID")
        Me.ColAccTypeID.FieldName = "AccTypeID"
        Me.ColAccTypeID.MinWidth = 23
        Me.ColAccTypeID.Name = "ColAccTypeID"
        '
        'ColAccTypeName
        '
        resources.ApplyResources(Me.ColAccTypeName, "ColAccTypeName")
        Me.ColAccTypeName.FieldName = "AccTypeName"
        Me.ColAccTypeName.MinWidth = 23
        Me.ColAccTypeName.Name = "ColAccTypeName"
        '
        'SimpleButton1
        '
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        '
        'FinancialSector
        '
        resources.ApplyResources(Me.FinancialSector, "FinancialSector")
        Me.FinancialSector.Name = "FinancialSector"
        Me.FinancialSector.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("FinancialSector.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.FinancialSector.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("FinancialSector.Properties.Columns"), resources.GetString("FinancialSector.Properties.Columns1"), CType(resources.GetObject("FinancialSector.Properties.Columns2"), Integer), CType(resources.GetObject("FinancialSector.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("FinancialSector.Properties.Columns4"), CType(resources.GetObject("FinancialSector.Properties.Columns5"), Boolean), CType(resources.GetObject("FinancialSector.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("FinancialSector.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("FinancialSector.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("FinancialSector.Properties.Columns9"), resources.GetString("FinancialSector.Properties.Columns10"), CType(resources.GetObject("FinancialSector.Properties.Columns11"), Integer), CType(resources.GetObject("FinancialSector.Properties.Columns12"), DevExpress.Utils.FormatType), resources.GetString("FinancialSector.Properties.Columns13"), CType(resources.GetObject("FinancialSector.Properties.Columns14"), Boolean), CType(resources.GetObject("FinancialSector.Properties.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("FinancialSector.Properties.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("FinancialSector.Properties.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.FinancialSector.Properties.DisplayMember = "SectorName"
        Me.FinancialSector.Properties.NullText = resources.GetString("FinancialSector.Properties.NullText")
        Me.FinancialSector.Properties.ValueMember = "SectorID"
        Me.FinancialSector.StyleController = Me.LayoutControl1
        '
        'FinancialStatment
        '
        resources.ApplyResources(Me.FinancialStatment, "FinancialStatment")
        Me.FinancialStatment.Name = "FinancialStatment"
        Me.FinancialStatment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("FinancialStatment.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.FinancialStatment.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("FinancialStatment.Properties.Columns"), resources.GetString("FinancialStatment.Properties.Columns1"), CType(resources.GetObject("FinancialStatment.Properties.Columns2"), Integer), CType(resources.GetObject("FinancialStatment.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("FinancialStatment.Properties.Columns4"), CType(resources.GetObject("FinancialStatment.Properties.Columns5"), Boolean), CType(resources.GetObject("FinancialStatment.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("FinancialStatment.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("FinancialStatment.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("FinancialStatment.Properties.Columns9"), resources.GetString("FinancialStatment.Properties.Columns10"), CType(resources.GetObject("FinancialStatment.Properties.Columns11"), Integer), CType(resources.GetObject("FinancialStatment.Properties.Columns12"), DevExpress.Utils.FormatType), resources.GetString("FinancialStatment.Properties.Columns13"), CType(resources.GetObject("FinancialStatment.Properties.Columns14"), Boolean), CType(resources.GetObject("FinancialStatment.Properties.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("FinancialStatment.Properties.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("FinancialStatment.Properties.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.FinancialStatment.Properties.DisplayMember = "FinancialStatementName"
        Me.FinancialStatment.Properties.NullText = resources.GetString("FinancialStatment.Properties.NullText")
        Me.FinancialStatment.Properties.ValueMember = "ID"
        Me.FinancialStatment.StyleController = Me.LayoutControl1
        '
        'Currency
        '
        resources.ApplyResources(Me.Currency, "Currency")
        Me.Currency.Name = "Currency"
        Me.Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("Currency.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.Currency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("Currency.Properties.Columns"), resources.GetString("Currency.Properties.Columns1"), CType(resources.GetObject("Currency.Properties.Columns2"), Integer), CType(resources.GetObject("Currency.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("Currency.Properties.Columns4"), CType(resources.GetObject("Currency.Properties.Columns5"), Boolean), CType(resources.GetObject("Currency.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("Currency.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("Currency.Properties.Columns8"), DevExpress.Utils.DefaultBoolean)), New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("Currency.Properties.Columns9"), resources.GetString("Currency.Properties.Columns10"), CType(resources.GetObject("Currency.Properties.Columns11"), Integer), CType(resources.GetObject("Currency.Properties.Columns12"), DevExpress.Utils.FormatType), resources.GetString("Currency.Properties.Columns13"), CType(resources.GetObject("Currency.Properties.Columns14"), Boolean), CType(resources.GetObject("Currency.Properties.Columns15"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("Currency.Properties.Columns16"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("Currency.Properties.Columns17"), DevExpress.Utils.DefaultBoolean))})
        Me.Currency.Properties.DisplayMember = "Code"
        Me.Currency.Properties.NullText = resources.GetString("Currency.Properties.NullText")
        Me.Currency.Properties.ValueMember = "CurrID"
        Me.Currency.StyleController = Me.LayoutControl1
        '
        'TextAccName
        '
        resources.ApplyResources(Me.TextAccName, "TextAccName")
        Me.TextAccName.Name = "TextAccName"
        Me.TextAccName.Properties.MaxLength = 50
        Me.TextAccName.StyleController = Me.LayoutControl1
        '
        'TextAccNo
        '
        resources.ApplyResources(Me.TextAccNo, "TextAccNo")
        Me.TextAccNo.Name = "TextAccNo"
        Me.TextAccNo.Properties.MaxLength = 10
        Me.TextAccNo.StyleController = Me.LayoutControl1
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem2, Me.LayoutControlItem7, Me.LayoutControlItem8})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(416, 316)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        resources.ApplyResources(Me.LayoutControlItem1, "LayoutControlItem1")
        Me.LayoutControlItem1.Control = Me.TextAccNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(106, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 182)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(396, 74)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        resources.ApplyResources(Me.LayoutControlItem2, "LayoutControlItem2")
        Me.LayoutControlItem2.Control = Me.TextAccName
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem3
        '
        resources.ApplyResources(Me.LayoutControlItem3, "LayoutControlItem3")
        Me.LayoutControlItem3.Control = Me.Currency
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem4
        '
        resources.ApplyResources(Me.LayoutControlItem4, "LayoutControlItem4")
        Me.LayoutControlItem4.Control = Me.FinancialStatment
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem5
        '
        resources.ApplyResources(Me.LayoutControlItem5, "LayoutControlItem5")
        Me.LayoutControlItem5.Control = Me.FinancialSector
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 130)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem6
        '
        resources.ApplyResources(Me.LayoutControlItem6, "LayoutControlItem6")
        Me.LayoutControlItem6.Control = Me.SimpleButton1
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 256)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(174, 40)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(174, 256)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(222, 40)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        resources.ApplyResources(Me.LayoutControlItem7, "LayoutControlItem7")
        Me.LayoutControlItem7.Control = Me.SearchAccType
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 156)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(106, 16)
        '
        'LayoutControlItem8
        '
        resources.ApplyResources(Me.LayoutControlItem8, "LayoutControlItem8")
        Me.LayoutControlItem8.Control = Me.TextFatherAccName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(396, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(106, 16)
        '
        'AccountAddNew
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "AccountAddNew"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextFatherAccName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchAccType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinancialSector.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FinancialStatment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAccName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAccNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FinancialSector As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents FinancialStatment As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Currency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TextAccName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextAccNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SearchAccType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColAccTypeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccTypeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextFatherAccName As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
