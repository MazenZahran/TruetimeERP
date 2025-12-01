<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ShishaDefineNewExpenseWithPercentage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShishaDefineNewExpenseWithPercentage))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.CheckPercantageFromSales = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPercantage = New DevExpress.XtraEditors.TextEdit()
        Me.txtCategoryID = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtAccountNo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColAccNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckPercantageFromSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPercantage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoryID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.CheckPercantageFromSales)
        Me.LayoutControl1.Controls.Add(Me.BtnSave)
        Me.LayoutControl1.Controls.Add(Me.txtPercantage)
        Me.LayoutControl1.Controls.Add(Me.txtCategoryID)
        Me.LayoutControl1.Controls.Add(Me.txtAccountNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(527, 191)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'CheckPercantageFromSales
        '
        Me.CheckPercantageFromSales.Location = New System.Drawing.Point(16, 84)
        Me.CheckPercantageFromSales.Name = "CheckPercantageFromSales"
        Me.CheckPercantageFromSales.Properties.Caption = "يعتمد على المبيعات"
        Me.CheckPercantageFromSales.Size = New System.Drawing.Size(150, 22)
        Me.CheckPercantageFromSales.StyleController = Me.LayoutControl1
        Me.CheckPercantageFromSales.TabIndex = 57
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Location = New System.Drawing.Point(16, 147)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(150, 28)
        Me.BtnSave.StyleController = Me.LayoutControl1
        Me.BtnSave.TabIndex = 56
        Me.BtnSave.Text = "موافق"
        '
        'txtPercantage
        '
        Me.txtPercantage.Location = New System.Drawing.Point(328, 84)
        Me.txtPercantage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPercantage.Name = "txtPercantage"
        Me.txtPercantage.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.txtPercantage.Properties.MaskSettings.Set("MaskManagerSignature", "allowNull=False")
        Me.txtPercantage.Properties.MaskSettings.Set("mask", "000%%")
        Me.txtPercantage.Properties.UseMaskAsDisplayFormat = True
        Me.txtPercantage.Size = New System.Drawing.Size(124, 28)
        Me.txtPercantage.StyleController = Me.LayoutControl1
        Me.txtPercantage.TabIndex = 55
        '
        'txtCategoryID
        '
        Me.txtCategoryID.Location = New System.Drawing.Point(16, 50)
        Me.txtCategoryID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCategoryID.Name = "txtCategoryID"
        Me.txtCategoryID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtCategoryID.Properties.DisplayMember = "CategoryName"
        Me.txtCategoryID.Properties.NullText = ""
        Me.txtCategoryID.Properties.PopupView = Me.GridView1
        Me.txtCategoryID.Properties.ShowAddNewButton = True
        Me.txtCategoryID.Properties.ValueMember = "CategoryID"
        Me.txtCategoryID.Size = New System.Drawing.Size(436, 28)
        Me.txtCategoryID.StyleController = Me.LayoutControl1
        Me.txtCategoryID.TabIndex = 54
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn12, Me.GridColumn13})
        Me.GridView1.DetailHeight = 284
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID"
        Me.GridColumn12.FieldName = "CategoryID"
        Me.GridColumn12.MinWidth = 17
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Width = 64
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "التصنيف"
        Me.GridColumn13.FieldName = "CategoryName"
        Me.GridColumn13.MinWidth = 17
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 64
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Location = New System.Drawing.Point(16, 16)
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtAccountNo.Properties.DisplayMember = "AccName"
        Me.txtAccountNo.Properties.NullText = ""
        Me.txtAccountNo.Properties.NullValuePrompt = "الحساب"
        Me.txtAccountNo.Properties.PopupView = Me.GridView3
        Me.txtAccountNo.Properties.ValueMember = "AccNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(436, 28)
        Me.txtAccountNo.StyleController = Me.LayoutControl1
        Me.txtAccountNo.TabIndex = 9
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColAccNo, Me.ColAccName})
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
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.EmptySpaceItem2, Me.LayoutControlItem4, Me.EmptySpaceItem3, Me.LayoutControlItem3, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(527, 191)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtAccountNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(501, 34)
        Me.LayoutControlItem1.Text = "المصروف:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(43, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 102)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(501, 29)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtCategoryID
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(501, 34)
        Me.LayoutControlItem2.Text = "التصنيف:"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(43, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(156, 68)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(156, 34)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.BtnSave
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 131)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(156, 34)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(156, 131)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(345, 34)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtPercantage
        Me.LayoutControlItem3.Location = New System.Drawing.Point(312, 68)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(189, 34)
        Me.LayoutControlItem3.Text = "النسبة:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(43, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.CheckPercantageFromSales
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(156, 34)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'ShishaDefineNewExpenseWithPercentage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 191)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("ShishaDefineNewExpenseWithPercentage.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ShishaDefineNewExpenseWithPercentage"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة / تعديل النسبة"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.CheckPercantageFromSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPercantage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoryID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtAccountNo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColAccNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPercantage As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCategoryID As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CheckPercantageFromSales As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
