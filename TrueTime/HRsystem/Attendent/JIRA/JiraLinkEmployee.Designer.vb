<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JiraLinkEmployee
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
        Dim TableColumnDefinition1 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TableRowDefinition1 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition2 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JiraLinkEmployee))
        Me.colEmployeeName = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SearchLookUpEdit1 = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.colID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colAttPlane = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colPictureEmp = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colMobile1 = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colBranch = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colDepartment = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.colJobName = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.txtJiraName = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJiraName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colEmployeeName
        '
        Me.colEmployeeName.FieldName = "EmployeeName"
        Me.colEmployeeName.Name = "colEmployeeName"
        Me.colEmployeeName.Visible = True
        Me.colEmployeeName.VisibleIndex = 1
        Me.colEmployeeName.Width = 50
        '
        'colEmployeeID
        '
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.Name = "colEmployeeID"
        Me.colEmployeeID.Visible = True
        Me.colEmployeeID.VisibleIndex = 2
        Me.colEmployeeID.Width = 50
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnSave)
        Me.LayoutControl1.Controls.Add(Me.SearchLookUpEdit1)
        Me.LayoutControl1.Controls.Add(Me.txtJiraName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(353, 249)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Location = New System.Drawing.Point(16, 205)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(321, 28)
        Me.BtnSave.StyleController = Me.LayoutControl1
        Me.BtnSave.TabIndex = 24
        Me.BtnSave.Text = "Save"
        '
        'SearchLookUpEdit1
        '
        Me.SearchLookUpEdit1.EditValue = ""
        Me.SearchLookUpEdit1.Location = New System.Drawing.Point(16, 88)
        Me.SearchLookUpEdit1.Name = "SearchLookUpEdit1"
        Me.SearchLookUpEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.SearchLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookUpEdit1.Properties.DisplayMember = "EmployeeName"
        Me.SearchLookUpEdit1.Properties.NullText = ""
        Me.SearchLookUpEdit1.Properties.NullValuePrompt = " اختر الموظف"
        Me.SearchLookUpEdit1.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookUpEdit1.Properties.ValueMember = "EmployeeID"
        Me.SearchLookUpEdit1.Properties.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.TileView
        Me.SearchLookUpEdit1.Size = New System.Drawing.Size(321, 28)
        Me.SearchLookUpEdit1.StyleController = Me.LayoutControl1
        Me.SearchLookUpEdit1.TabIndex = 23
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colEmployeeName, Me.colEmployeeID, Me.colAttPlane, Me.colPictureEmp, Me.colMobile1, Me.colBranch, Me.colDepartment, Me.colJobName})
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsBehavior.AllowMousePanning = False
        Me.SearchLookUpEdit1View.OptionsBehavior.AllowSmoothScrolling = True
        Me.SearchLookUpEdit1View.OptionsTiles.AllowPressAnimation = False
        Me.SearchLookUpEdit1View.OptionsTiles.ItemSize = New System.Drawing.Size(248, 70)
        Me.SearchLookUpEdit1View.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List
        Me.SearchLookUpEdit1View.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.SearchLookUpEdit1View.OptionsTiles.Padding = New System.Windows.Forms.Padding(0)
        Me.SearchLookUpEdit1View.TileColumns.Add(TableColumnDefinition1)
        TableRowDefinition1.Length.Value = 24.0R
        TableRowDefinition2.Length.Value = 30.0R
        Me.SearchLookUpEdit1View.TileRows.Add(TableRowDefinition1)
        Me.SearchLookUpEdit1View.TileRows.Add(TableRowDefinition2)
        TileViewItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        TileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement1.Column = Me.colEmployeeName
        TileViewItemElement1.RowIndex = 1
        TileViewItemElement1.Text = "colEmployeeName"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        TileViewItemElement2.Appearance.Normal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        TileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement2.Appearance.Normal.Options.UseFont = True
        TileViewItemElement2.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement2.Column = Me.colEmployeeID
        TileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileViewItemElement2.Text = "colEmployeeID"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement1)
        Me.SearchLookUpEdit1View.TileTemplate.Add(TileViewItemElement2)
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        Me.colID.Width = 50
        '
        'colAttPlane
        '
        Me.colAttPlane.FieldName = "AttPlane"
        Me.colAttPlane.Name = "colAttPlane"
        Me.colAttPlane.Visible = True
        Me.colAttPlane.VisibleIndex = 3
        Me.colAttPlane.Width = 50
        '
        'colPictureEmp
        '
        Me.colPictureEmp.Caption = "صورة"
        Me.colPictureEmp.FieldName = "PictureEmp"
        Me.colPictureEmp.Name = "colPictureEmp"
        Me.colPictureEmp.Visible = True
        Me.colPictureEmp.VisibleIndex = 4
        Me.colPictureEmp.Width = 50
        '
        'colMobile1
        '
        Me.colMobile1.FieldName = "Mobile1"
        Me.colMobile1.Name = "colMobile1"
        Me.colMobile1.Visible = True
        Me.colMobile1.VisibleIndex = 5
        Me.colMobile1.Width = 50
        '
        'colBranch
        '
        Me.colBranch.FieldName = "Branch"
        Me.colBranch.Name = "colBranch"
        Me.colBranch.Visible = True
        Me.colBranch.VisibleIndex = 6
        Me.colBranch.Width = 50
        '
        'colDepartment
        '
        Me.colDepartment.FieldName = "Department"
        Me.colDepartment.Name = "colDepartment"
        Me.colDepartment.Visible = True
        Me.colDepartment.VisibleIndex = 7
        Me.colDepartment.Width = 50
        '
        'colJobName
        '
        Me.colJobName.FieldName = "JobName"
        Me.colJobName.Name = "colJobName"
        Me.colJobName.Visible = True
        Me.colJobName.VisibleIndex = 8
        Me.colJobName.Width = 50
        '
        'txtJiraName
        '
        Me.txtJiraName.Location = New System.Drawing.Point(16, 35)
        Me.txtJiraName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtJiraName.Name = "txtJiraName"
        Me.txtJiraName.Properties.ReadOnly = True
        Me.txtJiraName.Size = New System.Drawing.Size(321, 28)
        Me.txtJiraName.StyleController = Me.LayoutControl1
        Me.txtJiraName.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(353, 249)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtJiraName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(327, 53)
        Me.LayoutControlItem1.Text = "Jira Name:"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(50, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 106)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(327, 83)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SearchLookUpEdit1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 53)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(327, 53)
        Me.LayoutControlItem2.Text = "Employee:"
        Me.LayoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BtnSave
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 189)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(327, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'JiraLinkEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 249)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = CType(resources.GetObject("JiraLinkEmployee.IconOptions.Image"), System.Drawing.Image)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "JiraLinkEmployee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JiraLinkEmployee"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SearchLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJiraName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtJiraName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colEmployeeName As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colAttPlane As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colPictureEmp As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colMobile1 As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colBranch As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colDepartment As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents colJobName As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
