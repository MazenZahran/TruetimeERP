<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeesAccess
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.EmployeesAccessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeesAccessTableAdapter = New TrueTime.AccountingDataSetTableAdapters.EmployeesAccessTableAdapter()
        Me.TableAdapterManager = New TrueTime.AccountingDataSetTableAdapters.TableAdapterManager()
        Me.EmployeesAccessGridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccessName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAccessValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesAccessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeesAccessGridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextEdit1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton1)
        Me.LayoutControl1.Controls.Add(Me.EmployeesAccessGridControl)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(597, 464)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(597, 464)
        Me.Root.TextVisible = False
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EmployeesAccessBindingSource
        '
        Me.EmployeesAccessBindingSource.DataMember = "EmployeesAccess"
        Me.EmployeesAccessBindingSource.DataSource = Me.AccountingDataSet
        '
        'EmployeesAccessTableAdapter
        '
        Me.EmployeesAccessTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AccountingBranchesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPOSNamesTableAdapter = Nothing
        Me.TableAdapterManager.AccountingPosTypesTableAdapter = Nothing
        Me.TableAdapterManager.AppointmentsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTableAdapter = Nothing
        Me.TableAdapterManager.AssetsTypeTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BankBrancheTableAdapter = Nothing
        Me.TableAdapterManager.BankTableAdapter = Nothing
        Me.TableAdapterManager.CRMTaskStatusesTableAdapter = Nothing
        Me.TableAdapterManager.DocNamesTableAdapter = Nothing
        Me.TableAdapterManager.EmployeesAccessTableAdapter = Me.EmployeesAccessTableAdapter
        Me.TableAdapterManager.FinancialAccounts1TableAdapter = Nothing
        Me.TableAdapterManager.FinancialAccountsTableAdapter = Nothing
        Me.TableAdapterManager.Items_unitsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsCategoriesTableAdapter = Nothing
        Me.TableAdapterManager.ItemsColorsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsGroupsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsMeasuresTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTableAdapter = Nothing
        Me.TableAdapterManager.ItemsTradeMarkTableAdapter = Nothing
        Me.TableAdapterManager.PatientsVisitsTableAdapter = Nothing
        Me.TableAdapterManager.PosPaidMethodsTableAdapter = Nothing
        Me.TableAdapterManager.ProductionEquationTableAdapter = Nothing
        Me.TableAdapterManager.RefCitiesTableAdapter = Nothing
        Me.TableAdapterManager.ReferancesListTableAdapter = Nothing
        Me.TableAdapterManager.ReferencessTableAdapter = Nothing
        Me.TableAdapterManager.ReferencesTypesTableAdapter = Nothing
        Me.TableAdapterManager.RefSortsTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsListTableAdapter = Nothing
        Me.TableAdapterManager.ReservationsPaymentTableAdapter = Nothing
        Me.TableAdapterManager.ResourcesTableAdapter = Nothing
        Me.TableAdapterManager.UnitsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = TrueTime.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.Vehicle_MaintenanceTableAdapter = Nothing
        Me.TableAdapterManager.WarehousesTableAdapter = Nothing
        '
        'EmployeesAccessGridControl
        '
        Me.EmployeesAccessGridControl.DataSource = Me.EmployeesAccessBindingSource
        Me.EmployeesAccessGridControl.Location = New System.Drawing.Point(12, 40)
        Me.EmployeesAccessGridControl.MainView = Me.GridView1
        Me.EmployeesAccessGridControl.Name = "EmployeesAccessGridControl"
        Me.EmployeesAccessGridControl.Size = New System.Drawing.Size(573, 386)
        Me.EmployeesAccessGridControl.TabIndex = 4
        Me.EmployeesAccessGridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colEmployeeID, Me.colAccessName, Me.colAccessValue})
        Me.GridView1.GridControl = Me.EmployeesAccessGridControl
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.EmployeesAccessGridControl
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(577, 390)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        Me.colID.Visible = True
        Me.colID.VisibleIndex = 0
        '
        'colEmployeeID
        '
        Me.colEmployeeID.FieldName = "EmployeeID"
        Me.colEmployeeID.Name = "colEmployeeID"
        '
        'colAccessName
        '
        Me.colAccessName.FieldName = "AccessName"
        Me.colAccessName.Name = "colAccessName"
        Me.colAccessName.Visible = True
        Me.colAccessName.VisibleIndex = 2
        '
        'colAccessValue
        '
        Me.colAccessValue.FieldName = "AccessValue"
        Me.colAccessValue.Name = "colAccessValue"
        Me.colAccessValue.Visible = True
        Me.colAccessValue.VisibleIndex = 3
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 430)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(127, 22)
        Me.SimpleButton1.StyleController = Me.LayoutControl1
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "حفظ"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.SimpleButton1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 418)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(131, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(131, 418)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(446, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'TextEdit1
        '
        Me.TextEdit1.Location = New System.Drawing.Point(12, 12)
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Properties.ReadOnly = True
        Me.TextEdit1.Size = New System.Drawing.Size(508, 24)
        Me.TextEdit1.StyleController = Me.LayoutControl1
        Me.TextEdit1.TabIndex = 6
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TextEdit1
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(577, 28)
        Me.LayoutControlItem3.Text = "المستخدم"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(53, 17)
        '
        'EmployeesAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 464)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "EmployeesAccess"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Text = "EmployeesAccess"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesAccessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeesAccessGridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents EmployeesAccessBindingSource As BindingSource
    Friend WithEvents EmployeesAccessTableAdapter As AccountingDataSetTableAdapters.EmployeesAccessTableAdapter
    Friend WithEvents TableAdapterManager As AccountingDataSetTableAdapters.TableAdapterManager
    Friend WithEvents EmployeesAccessGridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccessName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAccessValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
