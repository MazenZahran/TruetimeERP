Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Tile

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PosPaymentOptions
    Inherits XtraForm

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosPaymentOptions))
        Me.VirtualServerModeSource1 = New DevExpress.Data.VirtualServerModeSource(Me.components)
        Me.ColPaymentOption = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPaymentTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDelete = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LayoutControl7 = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnZero = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnAddCashCustomer = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGoBack = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAddNewCashCSTMR = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAddCreditCustomer = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCredit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCard = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCash = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TestLayout = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.TabbedControlGroup2 = New DevExpress.XtraLayout.TabbedControlGroup()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup8 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPoint = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnThree = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnFour = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnTwo = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtRest = New DevExpress.XtraEditors.TextEdit()
        Me.BtnNine = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOne = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnFive = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSix = New DevExpress.XtraEditors.SimpleButton()
        Me.TextTotal = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPaid = New DevExpress.XtraEditors.TextEdit()
        Me.BtnSeven = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEight = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator1 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.SimpleSeparator2 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator5 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator6 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator7 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator8 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator9 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator10 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator11 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator12 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator14 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator15 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator16 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator17 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator18 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.SimpleSeparator19 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleSeparator13 = New DevExpress.XtraLayout.SimpleSeparator()
        Me.TxtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.VirtualServerModeSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl7.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestLayout, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtRest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPaid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleSeparator13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColPaymentOption
        '
        Me.ColPaymentOption.Caption = "طريقة الدفع"
        Me.ColPaymentOption.FieldName = "ColPaymentOption"
        Me.ColPaymentOption.MinWidth = 25
        Me.ColPaymentOption.Name = "ColPaymentOption"
        Me.ColPaymentOption.Visible = True
        Me.ColPaymentOption.VisibleIndex = 0
        Me.ColPaymentOption.Width = 94
        '
        'ColPaymentTotal
        '
        Me.ColPaymentTotal.Caption = "المبلغ"
        Me.ColPaymentTotal.FieldName = "ColPaymentTotal"
        Me.ColPaymentTotal.MinWidth = 25
        Me.ColPaymentTotal.Name = "ColPaymentTotal"
        Me.ColPaymentTotal.Visible = True
        Me.ColPaymentTotal.VisibleIndex = 1
        Me.ColPaymentTotal.Width = 94
        '
        'ColDelete
        '
        Me.ColDelete.AppearanceCell.Options.UseTextOptions = True
        Me.ColDelete.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColDelete.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColDelete.Caption = "حذف"
        Me.ColDelete.FieldName = "ColDelete"
        Me.ColDelete.MinWidth = 25
        Me.ColDelete.Name = "ColDelete"
        Me.ColDelete.Visible = True
        Me.ColDelete.VisibleIndex = 2
        Me.ColDelete.Width = 94
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.AutoSize = True
        Me.PanelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelControl1.Controls.Add(Me.LayoutControl7)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1270, 818)
        Me.PanelControl1.TabIndex = 16
        '
        'LayoutControl7
        '
        Me.LayoutControl7.Controls.Add(Me.BtnZero)
        Me.LayoutControl7.Controls.Add(Me.LayoutControl1)
        Me.LayoutControl7.Controls.Add(Me.BtnDelete)
        Me.LayoutControl7.Controls.Add(Me.BtnPoint)
        Me.LayoutControl7.Controls.Add(Me.BtnThree)
        Me.LayoutControl7.Controls.Add(Me.BtnConfirm)
        Me.LayoutControl7.Controls.Add(Me.BtnFour)
        Me.LayoutControl7.Controls.Add(Me.BtnTwo)
        Me.LayoutControl7.Controls.Add(Me.TxtRest)
        Me.LayoutControl7.Controls.Add(Me.BtnNine)
        Me.LayoutControl7.Controls.Add(Me.BtnOne)
        Me.LayoutControl7.Controls.Add(Me.BtnFive)
        Me.LayoutControl7.Controls.Add(Me.BtnSix)
        Me.LayoutControl7.Controls.Add(Me.TextTotal)
        Me.LayoutControl7.Controls.Add(Me.TxtPaid)
        Me.LayoutControl7.Controls.Add(Me.BtnSeven)
        Me.LayoutControl7.Controls.Add(Me.BtnEight)
        Me.LayoutControl7.Controls.Add(Me.GridControl1)
        Me.LayoutControl7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl7.Location = New System.Drawing.Point(2, 2)
        Me.LayoutControl7.Name = "LayoutControl7"
        Me.LayoutControl7.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1270, 632, 650, 400)
        Me.LayoutControl7.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl7.Root = Me.LayoutControlGroup7
        Me.LayoutControl7.Size = New System.Drawing.Size(1266, 814)
        Me.LayoutControl7.TabIndex = 2
        Me.LayoutControl7.Text = "LayoutControl7"
        '
        'BtnZero
        '
        Me.BtnZero.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnZero.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnZero.Appearance.Options.UseBackColor = True
        Me.BtnZero.Appearance.Options.UseFont = True
        Me.BtnZero.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnZero.AppearancePressed.Options.UseForeColor = True
        Me.BtnZero.Location = New System.Drawing.Point(306, 742)
        Me.BtnZero.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnZero.Name = "BtnZero"
        Me.BtnZero.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnZero.Size = New System.Drawing.Size(229, 68)
        Me.BtnZero.StyleController = Me.LayoutControl7
        Me.BtnZero.TabIndex = 41
        Me.BtnZero.Text = "0"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnAddCashCustomer)
        Me.LayoutControl1.Controls.Add(Me.BtnGoBack)
        Me.LayoutControl1.Controls.Add(Me.btnAddCreditCustomer)
        Me.LayoutControl1.Controls.Add(Me.GridControl2)
        Me.LayoutControl1.Controls.Add(Me.GridControl3)
        Me.LayoutControl1.Controls.Add(Me.btnAddNewCashCSTMR)
        Me.LayoutControl1.Controls.Add(Me.BtnCredit)
        Me.LayoutControl1.Controls.Add(Me.BtnCard)
        Me.LayoutControl1.Controls.Add(Me.BtnCash)
        Me.LayoutControl1.Location = New System.Drawing.Point(981, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1270, 329, 650, 400)
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.TestLayout
        Me.LayoutControl1.Size = New System.Drawing.Size(282, 810)
        Me.LayoutControl1.TabIndex = 40
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnAddCashCustomer
        '
        Me.btnAddCashCustomer.Appearance.BackColor = System.Drawing.Color.Silver
        Me.btnAddCashCustomer.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCashCustomer.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnAddCashCustomer.Appearance.Options.UseBackColor = True
        Me.btnAddCashCustomer.Appearance.Options.UseFont = True
        Me.btnAddCashCustomer.Appearance.Options.UseForeColor = True
        Me.btnAddCashCustomer.Appearance.Options.UseTextOptions = True
        Me.btnAddCashCustomer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddCashCustomer.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddCashCustomer.AppearanceDisabled.Options.UseTextOptions = True
        Me.btnAddCashCustomer.AppearanceHovered.Options.UseTextOptions = True
        Me.btnAddCashCustomer.AppearancePressed.Options.UseTextOptions = True
        Me.btnAddCashCustomer.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddCashCustomer.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddCashCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom
        Me.btnAddCashCustomer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnAddCashCustomer.ImageOptions.SvgImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddCashCustomer.Location = New System.Drawing.Point(16, 474)
        Me.btnAddCashCustomer.Name = "btnAddCashCustomer"
        Me.btnAddCashCustomer.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.btnAddCashCustomer.Size = New System.Drawing.Size(250, 38)
        Me.btnAddCashCustomer.StyleController = Me.LayoutControl1
        Me.btnAddCashCustomer.TabIndex = 30
        Me.btnAddCashCustomer.Text = "زبون نقدي"
        '
        'BtnGoBack
        '
        Me.BtnGoBack.Appearance.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnGoBack.Appearance.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGoBack.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnGoBack.Appearance.Options.UseBackColor = True
        Me.BtnGoBack.Appearance.Options.UseFont = True
        Me.BtnGoBack.Appearance.Options.UseForeColor = True
        Me.BtnGoBack.Appearance.Options.UseTextOptions = True
        Me.BtnGoBack.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BtnGoBack.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BtnGoBack.AppearanceDisabled.Options.UseTextOptions = True
        Me.BtnGoBack.AppearanceHovered.Options.UseTextOptions = True
        Me.BtnGoBack.AppearancePressed.Options.UseTextOptions = True
        Me.BtnGoBack.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BtnGoBack.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BtnGoBack.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom
        Me.BtnGoBack.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.BtnGoBack.ImageOptions.SvgImageSize = New System.Drawing.Size(32, 32)
        Me.BtnGoBack.Location = New System.Drawing.Point(16, 740)
        Me.BtnGoBack.Name = "BtnGoBack"
        Me.BtnGoBack.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.BtnGoBack.Size = New System.Drawing.Size(250, 54)
        Me.BtnGoBack.StyleController = Me.LayoutControl1
        Me.BtnGoBack.TabIndex = 28
        Me.BtnGoBack.Text = "عودة"
        '
        'GridControl3
        '
        Me.GridControl3.Location = New System.Drawing.Point(32, 76)
        Me.GridControl3.MainView = Me.GridView3
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(218, 376)
        Me.GridControl3.TabIndex = 7
        Me.GridControl3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GridView3.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView3.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView3.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.GridView3.Appearance.Row.Options.UseFont = True
        Me.GridView3.Appearance.Row.Options.UseTextOptions = True
        Me.GridView3.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView3.GridControl = Me.GridControl3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.RowAutoHeight = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.OptionsView.ShowIndicator = False
        Me.GridView3.RowHeight = 36
        '
        'btnAddNewCashCSTMR
        '
        Me.btnAddNewCashCSTMR.Appearance.BackColor = System.Drawing.Color.Chocolate
        Me.btnAddNewCashCSTMR.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNewCashCSTMR.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnAddNewCashCSTMR.Appearance.Options.UseBackColor = True
        Me.btnAddNewCashCSTMR.Appearance.Options.UseFont = True
        Me.btnAddNewCashCSTMR.Appearance.Options.UseForeColor = True
        Me.btnAddNewCashCSTMR.Appearance.Options.UseTextOptions = True
        Me.btnAddNewCashCSTMR.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddNewCashCSTMR.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddNewCashCSTMR.AppearanceDisabled.Options.UseTextOptions = True
        Me.btnAddNewCashCSTMR.AppearanceHovered.Options.UseTextOptions = True
        Me.btnAddNewCashCSTMR.AppearancePressed.Options.UseTextOptions = True
        Me.btnAddNewCashCSTMR.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddNewCashCSTMR.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddNewCashCSTMR.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom
        Me.btnAddNewCashCSTMR.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnAddNewCashCSTMR.ImageOptions.SvgImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddNewCashCSTMR.Location = New System.Drawing.Point(32, 32)
        Me.btnAddNewCashCSTMR.Name = "btnAddNewCashCSTMR"
        Me.btnAddNewCashCSTMR.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.btnAddNewCashCSTMR.Size = New System.Drawing.Size(106, 38)
        Me.btnAddNewCashCSTMR.StyleController = Me.LayoutControl1
        Me.btnAddNewCashCSTMR.TabIndex = 32
        Me.btnAddNewCashCSTMR.Text = "زبون نقدي"
        '
        'btnAddCreditCustomer
        '
        Me.btnAddCreditCustomer.Appearance.BackColor = System.Drawing.Color.Chocolate
        Me.btnAddCreditCustomer.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCreditCustomer.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnAddCreditCustomer.Appearance.Options.UseBackColor = True
        Me.btnAddCreditCustomer.Appearance.Options.UseFont = True
        Me.btnAddCreditCustomer.Appearance.Options.UseForeColor = True
        Me.btnAddCreditCustomer.Appearance.Options.UseTextOptions = True
        Me.btnAddCreditCustomer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddCreditCustomer.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddCreditCustomer.AppearanceDisabled.Options.UseTextOptions = True
        Me.btnAddCreditCustomer.AppearanceHovered.Options.UseTextOptions = True
        Me.btnAddCreditCustomer.AppearancePressed.Options.UseTextOptions = True
        Me.btnAddCreditCustomer.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.btnAddCreditCustomer.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.btnAddCreditCustomer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom
        Me.btnAddCreditCustomer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.btnAddCreditCustomer.ImageOptions.SvgImageSize = New System.Drawing.Size(32, 32)
        Me.btnAddCreditCustomer.Location = New System.Drawing.Point(32, 32)
        Me.btnAddCreditCustomer.Name = "btnAddCreditCustomer"
        Me.btnAddCreditCustomer.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.btnAddCreditCustomer.Size = New System.Drawing.Size(106, 38)
        Me.btnAddCreditCustomer.StyleController = Me.LayoutControl1
        Me.btnAddCreditCustomer.TabIndex = 31
        Me.btnAddCreditCustomer.Text = "ذمة جديدة"
        '
        'BtnCredit
        '
        Me.BtnCredit.Appearance.BackColor = System.Drawing.Color.SandyBrown
        Me.BtnCredit.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCredit.Appearance.Options.UseBackColor = True
        Me.BtnCredit.Appearance.Options.UseFont = True
        Me.BtnCredit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnCredit.ImageOptions.SvgImage = CType(resources.GetObject("BtnCredit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnCredit.Location = New System.Drawing.Point(32, 290)
        Me.BtnCredit.Name = "BtnCredit"
        Me.BtnCredit.Size = New System.Drawing.Size(218, 116)
        Me.BtnCredit.StyleController = Me.LayoutControl1
        Me.BtnCredit.TabIndex = 5
        Me.BtnCredit.Text = "ذمم"
        '
        'BtnCard
        '
        Me.BtnCard.Appearance.BackColor = System.Drawing.Color.PaleTurquoise
        Me.BtnCard.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCard.Appearance.Options.UseBackColor = True
        Me.BtnCard.Appearance.Options.UseFont = True
        Me.BtnCard.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnCard.ImageOptions.SvgImage = CType(resources.GetObject("BtnCard.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnCard.Location = New System.Drawing.Point(32, 161)
        Me.BtnCard.Name = "BtnCard"
        Me.BtnCard.Size = New System.Drawing.Size(218, 116)
        Me.BtnCard.StyleController = Me.LayoutControl1
        Me.BtnCard.TabIndex = 5
        Me.BtnCard.Text = " بطاقة ائتمان"
        '
        'BtnCash
        '
        Me.BtnCash.Appearance.BackColor = System.Drawing.Color.LightGreen
        Me.BtnCash.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCash.Appearance.Options.UseBackColor = True
        Me.BtnCash.Appearance.Options.UseFont = True
        Me.BtnCash.ImageOptions.Image = CType(resources.GetObject("BtnCash.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnCash.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.BtnCash.Location = New System.Drawing.Point(32, 32)
        Me.BtnCash.Name = "BtnCash"
        Me.BtnCash.Padding = New System.Windows.Forms.Padding(5)
        Me.BtnCash.Size = New System.Drawing.Size(218, 116)
        Me.BtnCash.StyleController = Me.LayoutControl1
        Me.BtnCash.TabIndex = 4
        Me.BtnCash.Text = "دفع نقدي"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(32, 76)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(218, 376)
        Me.GridControl2.TabIndex = 29
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GridView2.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView2.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GridView2.Appearance.Row.Options.UseFont = True
        Me.GridView2.Appearance.Row.Options.UseTextOptions = True
        Me.GridView2.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.RowAutoHeight = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OptionsView.ShowIndicator = False
        Me.GridView2.RowHeight = 36
        '
        'TestLayout
        '
        Me.TestLayout.AppearanceGroup.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TestLayout.AppearanceGroup.Options.UseBackColor = True
        Me.TestLayout.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.TestLayout.GroupBordersVisible = False
        Me.TestLayout.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.TabbedControlGroup2, Me.LayoutControlItem25, Me.EmptySpaceItem11, Me.LayoutControlItem26})
        Me.TestLayout.Name = "Root"
        Me.TestLayout.Size = New System.Drawing.Size(282, 810)
        Me.TestLayout.TextVisible = False
        '
        'TabbedControlGroup2
        '
        Me.TabbedControlGroup2.AppearanceGroup.BackColor = System.Drawing.Color.Gray
        Me.TabbedControlGroup2.AppearanceGroup.Options.UseBackColor = True
        Me.TabbedControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.TabbedControlGroup2.Name = "TabbedControlGroup2"
        Me.TabbedControlGroup2.SelectedTabPage = Me.LayoutControlGroup1
        Me.TabbedControlGroup2.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.TabbedControlGroup2.Size = New System.Drawing.Size(256, 458)
        Me.TabbedControlGroup2.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.LayoutControlGroup2, Me.LayoutControlGroup6, Me.LayoutControlGroup8, Me.LayoutControlGroup3})
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "6"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11, Me.EmptySpaceItem9, Me.LayoutControlItem8})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(224, 426)
        Me.LayoutControlGroup3.Text = "4"
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.GridControl2
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(224, 382)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(112, 0)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(112, 44)
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnAddCreditCustomer
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(112, 44)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem6, Me.EmptySpaceItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(224, 426)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BtnCash
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 10)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BtnCard
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 129)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 10)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.BtnCredit
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 258)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 10)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(224, 129)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 387)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(224, 39)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(224, 426)
        Me.LayoutControlGroup2.Text = "1"
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.AppearanceGroup.Options.UseBackColor = True
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup6.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(224, 426)
        Me.LayoutControlGroup6.Text = "2"
        '
        'LayoutControlGroup8
        '
        Me.LayoutControlGroup8.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem24, Me.EmptySpaceItem8, Me.LayoutControlItem27})
        Me.LayoutControlGroup8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup8.Name = "LayoutControlGroup8"
        Me.LayoutControlGroup8.Size = New System.Drawing.Size(224, 426)
        Me.LayoutControlGroup8.Text = "3"
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.GridControl3
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(224, 382)
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem24.TextVisible = False
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(112, 0)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(112, 44)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.btnAddNewCashCSTMR
        Me.LayoutControlItem27.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(112, 44)
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem27.TextVisible = False
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.BtnGoBack
        Me.LayoutControlItem25.Location = New System.Drawing.Point(0, 724)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(256, 60)
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem25.TextVisible = False
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(0, 502)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(256, 222)
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.btnAddCashCustomer
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 458)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(256, 44)
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem26.TextVisible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnDelete.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Appearance.Options.UseBackColor = True
        Me.BtnDelete.Appearance.Options.UseFont = True
        Me.BtnDelete.Appearance.Options.UseTextOptions = True
        Me.BtnDelete.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.AppearancePressed.Options.UseForeColor = True
        Me.BtnDelete.ImageOptions.Image = CType(resources.GetObject("BtnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.BtnDelete.Location = New System.Drawing.Point(758, 742)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnDelete.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnDelete.ShowToolTips = False
        Me.BtnDelete.Size = New System.Drawing.Size(216, 68)
        Me.BtnDelete.StyleController = Me.LayoutControl7
        Me.BtnDelete.TabIndex = 33
        Me.BtnDelete.Text = " "
        '
        'BtnPoint
        '
        Me.BtnPoint.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnPoint.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPoint.Appearance.Options.UseBackColor = True
        Me.BtnPoint.Appearance.Options.UseFont = True
        Me.BtnPoint.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnPoint.AppearancePressed.Options.UseForeColor = True
        Me.BtnPoint.Location = New System.Drawing.Point(542, 742)
        Me.BtnPoint.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnPoint.Name = "BtnPoint"
        Me.BtnPoint.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnPoint.Size = New System.Drawing.Size(209, 68)
        Me.BtnPoint.StyleController = Me.LayoutControl7
        Me.BtnPoint.TabIndex = 32
        Me.BtnPoint.Text = "."
        '
        'BtnThree
        '
        Me.BtnThree.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnThree.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnThree.Appearance.Options.UseBackColor = True
        Me.BtnThree.Appearance.Options.UseFont = True
        Me.BtnThree.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnThree.AppearancePressed.Options.UseForeColor = True
        Me.BtnThree.Location = New System.Drawing.Point(758, 667)
        Me.BtnThree.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnThree.Name = "BtnThree"
        Me.BtnThree.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnThree.Size = New System.Drawing.Size(216, 68)
        Me.BtnThree.StyleController = Me.LayoutControl7
        Me.BtnThree.TabIndex = 33
        Me.BtnThree.Text = "3"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Appearance.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.BtnConfirm.Appearance.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfirm.Appearance.ForeColor = System.Drawing.Color.White
        Me.BtnConfirm.Appearance.Options.UseBackColor = True
        Me.BtnConfirm.Appearance.Options.UseFont = True
        Me.BtnConfirm.Appearance.Options.UseForeColor = True
        Me.BtnConfirm.Appearance.Options.UseTextOptions = True
        Me.BtnConfirm.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BtnConfirm.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BtnConfirm.AppearanceDisabled.Options.UseTextOptions = True
        Me.BtnConfirm.AppearanceHovered.Options.UseTextOptions = True
        Me.BtnConfirm.AppearancePressed.Options.UseTextOptions = True
        Me.BtnConfirm.AppearancePressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BtnConfirm.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BtnConfirm.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftBottom
        Me.BtnConfirm.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.BtnConfirm.ImageOptions.SvgImageSize = New System.Drawing.Size(32, 32)
        Me.BtnConfirm.Location = New System.Drawing.Point(3, 756)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.BtnConfirm.Size = New System.Drawing.Size(296, 54)
        Me.BtnConfirm.StyleController = Me.LayoutControl7
        Me.BtnConfirm.TabIndex = 28
        Me.BtnConfirm.Text = "تأكيد"
        '
        'BtnFour
        '
        Me.BtnFour.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnFour.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFour.Appearance.Options.UseBackColor = True
        Me.BtnFour.Appearance.Options.UseFont = True
        Me.BtnFour.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnFour.AppearancePressed.Options.UseForeColor = True
        Me.BtnFour.Location = New System.Drawing.Point(306, 592)
        Me.BtnFour.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnFour.Name = "BtnFour"
        Me.BtnFour.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnFour.Size = New System.Drawing.Size(229, 68)
        Me.BtnFour.StyleController = Me.LayoutControl7
        Me.BtnFour.TabIndex = 34
        Me.BtnFour.Text = "4"
        '
        'BtnTwo
        '
        Me.BtnTwo.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnTwo.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTwo.Appearance.Options.UseBackColor = True
        Me.BtnTwo.Appearance.Options.UseFont = True
        Me.BtnTwo.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnTwo.AppearancePressed.Options.UseForeColor = True
        Me.BtnTwo.Location = New System.Drawing.Point(542, 667)
        Me.BtnTwo.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnTwo.Name = "BtnTwo"
        Me.BtnTwo.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnTwo.Size = New System.Drawing.Size(209, 68)
        Me.BtnTwo.StyleController = Me.LayoutControl7
        Me.BtnTwo.TabIndex = 32
        Me.BtnTwo.Text = "2"
        '
        'TxtRest
        '
        Me.TxtRest.EditValue = ""
        Me.TxtRest.Enabled = False
        Me.TxtRest.Location = New System.Drawing.Point(306, 120)
        Me.TxtRest.Name = "TxtRest"
        Me.TxtRest.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TxtRest.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRest.Properties.Appearance.Options.UseBackColor = True
        Me.TxtRest.Properties.Appearance.Options.UseFont = True
        Me.TxtRest.Properties.AutoHeight = False
        Me.TxtRest.Properties.ReadOnly = True
        Me.TxtRest.Size = New System.Drawing.Size(488, 77)
        Me.TxtRest.StyleController = Me.LayoutControl7
        Me.TxtRest.TabIndex = 10
        '
        'BtnNine
        '
        Me.BtnNine.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnNine.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNine.Appearance.Options.UseBackColor = True
        Me.BtnNine.Appearance.Options.UseFont = True
        Me.BtnNine.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnNine.AppearancePressed.Options.UseForeColor = True
        Me.BtnNine.Location = New System.Drawing.Point(758, 517)
        Me.BtnNine.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnNine.Name = "BtnNine"
        Me.BtnNine.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnNine.Size = New System.Drawing.Size(216, 68)
        Me.BtnNine.StyleController = Me.LayoutControl7
        Me.BtnNine.TabIndex = 37
        Me.BtnNine.Text = "9"
        '
        'BtnOne
        '
        Me.BtnOne.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnOne.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOne.Appearance.Options.UseBackColor = True
        Me.BtnOne.Appearance.Options.UseFont = True
        Me.BtnOne.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnOne.AppearancePressed.Options.UseForeColor = True
        Me.BtnOne.Location = New System.Drawing.Point(306, 667)
        Me.BtnOne.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnOne.Name = "BtnOne"
        Me.BtnOne.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnOne.Size = New System.Drawing.Size(229, 68)
        Me.BtnOne.StyleController = Me.LayoutControl7
        Me.BtnOne.TabIndex = 31
        Me.BtnOne.Text = "1"
        '
        'BtnFive
        '
        Me.BtnFive.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnFive.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFive.Appearance.Options.UseBackColor = True
        Me.BtnFive.Appearance.Options.UseFont = True
        Me.BtnFive.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnFive.AppearancePressed.Options.UseForeColor = True
        Me.BtnFive.Location = New System.Drawing.Point(542, 592)
        Me.BtnFive.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnFive.Name = "BtnFive"
        Me.BtnFive.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnFive.Size = New System.Drawing.Size(209, 68)
        Me.BtnFive.StyleController = Me.LayoutControl7
        Me.BtnFive.TabIndex = 35
        Me.BtnFive.Text = "5"
        '
        'BtnSix
        '
        Me.BtnSix.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnSix.Appearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnSix.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSix.Appearance.Options.UseBackColor = True
        Me.BtnSix.Appearance.Options.UseBorderColor = True
        Me.BtnSix.Appearance.Options.UseFont = True
        Me.BtnSix.AppearanceDisabled.Options.UseBorderColor = True
        Me.BtnSix.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnSix.AppearancePressed.Options.UseForeColor = True
        Me.BtnSix.Location = New System.Drawing.Point(758, 592)
        Me.BtnSix.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnSix.Name = "BtnSix"
        Me.BtnSix.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnSix.Size = New System.Drawing.Size(216, 68)
        Me.BtnSix.StyleController = Me.LayoutControl7
        Me.BtnSix.TabIndex = 36
        Me.BtnSix.Text = "6"
        '
        'TextTotal
        '
        Me.TextTotal.EditValue = ""
        Me.TextTotal.Enabled = False
        Me.TextTotal.Location = New System.Drawing.Point(306, 20)
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TextTotal.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotal.Properties.Appearance.Options.UseBackColor = True
        Me.TextTotal.Properties.Appearance.Options.UseFont = True
        Me.TextTotal.Properties.AutoHeight = False
        Me.TextTotal.Properties.ReadOnly = True
        Me.TextTotal.Size = New System.Drawing.Size(488, 77)
        Me.TextTotal.StyleController = Me.LayoutControl7
        Me.TextTotal.TabIndex = 11
        '
        'TxtPaid
        '
        Me.TxtPaid.EditValue = ""
        Me.TxtPaid.Location = New System.Drawing.Point(306, 360)
        Me.TxtPaid.Name = "TxtPaid"
        Me.TxtPaid.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtPaid.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaid.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.TxtPaid.Properties.Appearance.Options.UseBackColor = True
        Me.TxtPaid.Properties.Appearance.Options.UseFont = True
        Me.TxtPaid.Properties.Appearance.Options.UseForeColor = True
        Me.TxtPaid.Properties.Appearance.Options.UseTextOptions = True
        Me.TxtPaid.Properties.AppearanceDisabled.Options.UseTextOptions = True
        Me.TxtPaid.Properties.AutoHeight = False
        Me.TxtPaid.Size = New System.Drawing.Size(488, 71)
        Me.TxtPaid.StyleController = Me.LayoutControl7
        Me.TxtPaid.TabIndex = 9
        '
        'BtnSeven
        '
        Me.BtnSeven.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnSeven.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSeven.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSeven.Appearance.Options.UseBackColor = True
        Me.BtnSeven.Appearance.Options.UseBorderColor = True
        Me.BtnSeven.Appearance.Options.UseFont = True
        Me.BtnSeven.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnSeven.AppearancePressed.Options.UseForeColor = True
        Me.BtnSeven.Location = New System.Drawing.Point(306, 517)
        Me.BtnSeven.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnSeven.Name = "BtnSeven"
        Me.BtnSeven.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnSeven.Size = New System.Drawing.Size(229, 68)
        Me.BtnSeven.StyleController = Me.LayoutControl7
        Me.BtnSeven.TabIndex = 39
        Me.BtnSeven.Text = "7"
        '
        'BtnEight
        '
        Me.BtnEight.Appearance.BackColor = System.Drawing.Color.Black
        Me.BtnEight.Appearance.BorderColor = System.Drawing.Color.Silver
        Me.BtnEight.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEight.Appearance.Options.UseBackColor = True
        Me.BtnEight.Appearance.Options.UseBorderColor = True
        Me.BtnEight.Appearance.Options.UseFont = True
        Me.BtnEight.AppearancePressed.ForeColor = System.Drawing.Color.White
        Me.BtnEight.AppearancePressed.Options.UseForeColor = True
        Me.BtnEight.Location = New System.Drawing.Point(542, 517)
        Me.BtnEight.MinimumSize = New System.Drawing.Size(100, 33)
        Me.BtnEight.Name = "BtnEight"
        Me.BtnEight.Padding = New System.Windows.Forms.Padding(15)
        Me.BtnEight.Size = New System.Drawing.Size(209, 68)
        Me.BtnEight.StyleController = Me.LayoutControl7
        Me.BtnEight.TabIndex = 38
        Me.BtnEight.Text = "8"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(3, 20)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(296, 730)
        Me.GridControl1.TabIndex = 15
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Appearance.Row.Options.UseTextOptions = True
        Me.GridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.RowHeight = 36
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup7.GroupBordersVisible = False
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem7, Me.LayoutControlItem23, Me.SimpleSeparator1, Me.LayoutControlItem1, Me.LayoutControlItem5, Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem19, Me.LayoutControlItem16, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem20, Me.EmptySpaceItem4, Me.SimpleSeparator2, Me.SimpleSeparator5, Me.SimpleSeparator6, Me.LayoutControlItem18, Me.LayoutControlItem17, Me.SimpleSeparator7, Me.SimpleSeparator8, Me.SimpleSeparator9, Me.SimpleSeparator10, Me.SimpleSeparator11, Me.SimpleSeparator12, Me.SimpleSeparator14, Me.SimpleSeparator15, Me.SimpleSeparator16, Me.SimpleSeparator17, Me.SimpleSeparator18, Me.SimpleSeparator19, Me.LayoutControlItem10, Me.LayoutControlItem9, Me.EmptySpaceItem3, Me.EmptySpaceItem5, Me.LayoutControlItem13, Me.EmptySpaceItem7, Me.EmptySpaceItem10, Me.LayoutControlItem12, Me.SimpleSeparator13})
        Me.LayoutControlGroup7.Name = "Root"
        Me.LayoutControlGroup7.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(1266, 814)
        Me.LayoutControlGroup7.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GridControl1
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 17)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(302, 736)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.BtnConfirm
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 753)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(302, 60)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.BtnPoint
        Me.LayoutControlItem23.Location = New System.Drawing.Point(539, 739)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(215, 74)
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem23.TextVisible = False
        '
        'SimpleSeparator1
        '
        Me.SimpleSeparator1.AllowHotTrack = False
        Me.SimpleSeparator1.Location = New System.Drawing.Point(302, 0)
        Me.SimpleSeparator1.Name = "SimpleSeparator1"
        Me.SimpleSeparator1.Size = New System.Drawing.Size(1, 813)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.LayoutControl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(978, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(3, 3, 0, 3)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(288, 813)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BtnDelete
        Me.LayoutControlItem5.Location = New System.Drawing.Point(755, 739)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(222, 74)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.BtnTwo
        Me.LayoutControlItem21.Location = New System.Drawing.Point(539, 664)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(215, 74)
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.BtnThree
        Me.LayoutControlItem22.Location = New System.Drawing.Point(755, 664)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(222, 74)
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem22.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.BtnFive
        Me.LayoutControlItem19.Location = New System.Drawing.Point(539, 589)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(215, 74)
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.BtnSix
        Me.LayoutControlItem16.Location = New System.Drawing.Point(755, 589)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(222, 74)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.BtnSeven
        Me.LayoutControlItem14.Location = New System.Drawing.Point(303, 514)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(235, 74)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.BtnEight
        Me.LayoutControlItem15.Location = New System.Drawing.Point(539, 514)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(215, 74)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.BtnNine
        Me.LayoutControlItem20.Location = New System.Drawing.Point(755, 514)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(222, 74)
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextVisible = False
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(303, 434)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(674, 79)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'SimpleSeparator2
        '
        Me.SimpleSeparator2.AllowHotTrack = False
        Me.SimpleSeparator2.Location = New System.Drawing.Point(303, 513)
        Me.SimpleSeparator2.Name = "SimpleSeparator2"
        Me.SimpleSeparator2.Size = New System.Drawing.Size(674, 1)
        '
        'SimpleSeparator5
        '
        Me.SimpleSeparator5.AllowHotTrack = False
        Me.SimpleSeparator5.Location = New System.Drawing.Point(538, 514)
        Me.SimpleSeparator5.Name = "SimpleSeparator5"
        Me.SimpleSeparator5.Size = New System.Drawing.Size(1, 299)
        '
        'SimpleSeparator6
        '
        Me.SimpleSeparator6.AllowHotTrack = False
        Me.SimpleSeparator6.Location = New System.Drawing.Point(754, 514)
        Me.SimpleSeparator6.Name = "SimpleSeparator6"
        Me.SimpleSeparator6.Size = New System.Drawing.Size(1, 299)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.BtnFour
        Me.LayoutControlItem18.Location = New System.Drawing.Point(303, 589)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(235, 74)
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.BtnOne
        Me.LayoutControlItem17.Location = New System.Drawing.Point(303, 664)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(235, 74)
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextVisible = False
        '
        'SimpleSeparator7
        '
        Me.SimpleSeparator7.AllowHotTrack = False
        Me.SimpleSeparator7.Location = New System.Drawing.Point(303, 588)
        Me.SimpleSeparator7.Name = "SimpleSeparator7"
        Me.SimpleSeparator7.Size = New System.Drawing.Size(235, 1)
        '
        'SimpleSeparator8
        '
        Me.SimpleSeparator8.AllowHotTrack = False
        Me.SimpleSeparator8.Location = New System.Drawing.Point(539, 588)
        Me.SimpleSeparator8.Name = "SimpleSeparator8"
        Me.SimpleSeparator8.Size = New System.Drawing.Size(215, 1)
        '
        'SimpleSeparator9
        '
        Me.SimpleSeparator9.AllowHotTrack = False
        Me.SimpleSeparator9.Location = New System.Drawing.Point(755, 588)
        Me.SimpleSeparator9.Name = "SimpleSeparator9"
        Me.SimpleSeparator9.Size = New System.Drawing.Size(222, 1)
        '
        'SimpleSeparator10
        '
        Me.SimpleSeparator10.AllowHotTrack = False
        Me.SimpleSeparator10.Location = New System.Drawing.Point(755, 663)
        Me.SimpleSeparator10.Name = "SimpleSeparator10"
        Me.SimpleSeparator10.Size = New System.Drawing.Size(222, 1)
        '
        'SimpleSeparator11
        '
        Me.SimpleSeparator11.AllowHotTrack = False
        Me.SimpleSeparator11.Location = New System.Drawing.Point(303, 663)
        Me.SimpleSeparator11.Name = "SimpleSeparator11"
        Me.SimpleSeparator11.Size = New System.Drawing.Size(235, 1)
        '
        'SimpleSeparator12
        '
        Me.SimpleSeparator12.AllowHotTrack = False
        Me.SimpleSeparator12.Location = New System.Drawing.Point(539, 663)
        Me.SimpleSeparator12.Name = "SimpleSeparator12"
        Me.SimpleSeparator12.Size = New System.Drawing.Size(215, 1)
        '
        'SimpleSeparator14
        '
        Me.SimpleSeparator14.AllowHotTrack = False
        Me.SimpleSeparator14.Location = New System.Drawing.Point(539, 738)
        Me.SimpleSeparator14.Name = "SimpleSeparator14"
        Me.SimpleSeparator14.Size = New System.Drawing.Size(215, 1)
        '
        'SimpleSeparator15
        '
        Me.SimpleSeparator15.AllowHotTrack = False
        Me.SimpleSeparator15.Location = New System.Drawing.Point(755, 738)
        Me.SimpleSeparator15.Name = "SimpleSeparator15"
        Me.SimpleSeparator15.Size = New System.Drawing.Size(222, 1)
        '
        'SimpleSeparator16
        '
        Me.SimpleSeparator16.AllowHotTrack = False
        Me.SimpleSeparator16.Location = New System.Drawing.Point(844, 813)
        Me.SimpleSeparator16.Name = "SimpleSeparator16"
        Me.SimpleSeparator16.Size = New System.Drawing.Size(422, 1)
        '
        'SimpleSeparator17
        '
        Me.SimpleSeparator17.AllowHotTrack = False
        Me.SimpleSeparator17.Location = New System.Drawing.Point(0, 813)
        Me.SimpleSeparator17.Name = "SimpleSeparator17"
        Me.SimpleSeparator17.Size = New System.Drawing.Size(422, 1)
        '
        'SimpleSeparator18
        '
        Me.SimpleSeparator18.AllowHotTrack = False
        Me.SimpleSeparator18.Location = New System.Drawing.Point(422, 813)
        Me.SimpleSeparator18.Name = "SimpleSeparator18"
        Me.SimpleSeparator18.Size = New System.Drawing.Size(422, 1)
        '
        'SimpleSeparator19
        '
        Me.SimpleSeparator19.AllowHotTrack = False
        Me.SimpleSeparator19.Location = New System.Drawing.Point(977, 0)
        Me.SimpleSeparator19.Name = "SimpleSeparator19"
        Me.SimpleSeparator19.Size = New System.Drawing.Size(1, 813)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlItem10.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem10.AppearanceItemCaption.Options.UseForeColor = True
        Me.LayoutControlItem10.Control = Me.TextTotal
        Me.LayoutControlItem10.Location = New System.Drawing.Point(303, 17)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(674, 83)
        Me.LayoutControlItem10.Text = " المبلغ الإجمالي "
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(164, 32)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem9.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem9.AppearanceItemCaption.Options.UseForeColor = True
        Me.LayoutControlItem9.AppearanceItemCaptionDisabled.ForeColor = System.Drawing.Color.Transparent
        Me.LayoutControlItem9.AppearanceItemCaptionDisabled.Options.UseForeColor = True
        Me.LayoutControlItem9.Control = Me.TxtRest
        Me.LayoutControlItem9.Location = New System.Drawing.Point(303, 117)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(674, 83)
        Me.LayoutControlItem9.Text = "الباقي"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(164, 32)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(303, 200)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(674, 157)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(303, 100)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(674, 17)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LayoutControlItem13.AppearanceItemCaption.ForeColor = System.Drawing.Color.ForestGreen
        Me.LayoutControlItem13.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlItem13.AppearanceItemCaption.Options.UseForeColor = True
        Me.LayoutControlItem13.Control = Me.TxtPaid
        Me.LayoutControlItem13.Location = New System.Drawing.Point(303, 357)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(674, 77)
        Me.LayoutControlItem13.Text = " المبلغ المقبوض"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(164, 32)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(303, 0)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(674, 17)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(302, 17)
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.BtnZero
        Me.LayoutControlItem12.Location = New System.Drawing.Point(303, 739)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(235, 74)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'SimpleSeparator13
        '
        Me.SimpleSeparator13.AllowHotTrack = False
        Me.SimpleSeparator13.Location = New System.Drawing.Point(303, 738)
        Me.SimpleSeparator13.Name = "SimpleSeparator13"
        Me.SimpleSeparator13.Size = New System.Drawing.Size(235, 1)
        '
        'TxtTotal
        '
        Me.TxtTotal.EditValue = ""
        Me.TxtTotal.Location = New System.Drawing.Point(234, 35)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TxtTotal.Properties.Appearance.Options.UseBackColor = True
        Me.TxtTotal.Properties.AutoHeight = False
        Me.TxtTotal.Properties.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(100, 499)
        Me.TxtTotal.TabIndex = 2
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(810, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(10, 693)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(427, 0)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(133, 660)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'PosPaymentOptions
        '
        Me.Appearance.ForeColor = System.Drawing.Color.Green
        Me.Appearance.Options.UseForeColor = True
        Me.ClientSize = New System.Drawing.Size(1270, 818)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "PosPaymentOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "خيارات الدفع"
        CType(Me.VirtualServerModeSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl7.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestLayout, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtRest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPaid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleSeparator13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VirtualServerModeSource1 As DevExpress.Data.VirtualServerModeSource
    Friend WithEvents ColPaymentOption As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPaymentTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As PanelControl
    Friend WithEvents TxtTotal As TextEdit
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl7 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents BtnThree As SimpleButton
    Friend WithEvents BtnConfirm As SimpleButton
    Friend WithEvents BtnFour As SimpleButton
    Friend WithEvents BtnPoint As SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemButtonEdit1 As Repository.RepositoryItemButtonEdit
    Friend WithEvents BtnSix As SimpleButton
    Friend WithEvents BtnTwo As SimpleButton
    Friend WithEvents BtnFive As SimpleButton
    Friend WithEvents BtnNine As SimpleButton
    Friend WithEvents TxtPaid As TextEdit
    Friend WithEvents BtnSeven As SimpleButton
    Friend WithEvents BtnOne As SimpleButton
    Friend WithEvents TextTotal As TextEdit
    Friend WithEvents BtnEight As SimpleButton
    Friend WithEvents TxtRest As TextEdit
    Friend WithEvents TabbedControlGroup2 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup8 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnDelete As SimpleButton

    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleSeparator1 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TestLayout As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnCredit As SimpleButton
    Friend WithEvents BtnCard As SimpleButton
    Friend WithEvents BtnCash As SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents SimpleSeparator2 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator5 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator6 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator7 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator8 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator9 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator10 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator11 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator12 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator13 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator14 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator15 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator16 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator17 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator18 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents SimpleSeparator19 As DevExpress.XtraLayout.SimpleSeparator
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents BtnGoBack As SimpleButton
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnZero As SimpleButton
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddCashCustomer As SimpleButton
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnAddNewCashCSTMR As SimpleButton
    Friend WithEvents btnAddCreditCustomer As SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
End Class
