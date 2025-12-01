<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PosItemDirectDefind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosItemDirectDefind))
        Me.TextItemName = New DevExpress.XtraEditors.TextEdit()
        Me.TextItemBarcode = New DevExpress.XtraEditors.TextEdit()
        Me.TextPrice = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.AccountingDataSet = New TrueTime.AccountingDataSet()
        Me.UnitsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UnitsTableAdapter = New TrueTime.AccountingDataSetTableAdapters.UnitsTableAdapter()
        Me.LookUpUnit = New DevExpress.XtraEditors.LookUpEdit()
        Me.SearchItemsGroups = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TextQuantity = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemBarcode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UnitsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchItemsGroups.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextItemName
        '
        Me.TextItemName.Location = New System.Drawing.Point(50, 17)
        Me.TextItemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextItemName.Name = "TextItemName"
        Me.TextItemName.Properties.AdvancedModeOptions.Label = "الصنف:"
        Me.TextItemName.Properties.MaxLength = 50
        Me.TextItemName.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextItemName.Size = New System.Drawing.Size(338, 36)
        Me.TextItemName.TabIndex = 0
        '
        'TextItemBarcode
        '
        Me.TextItemBarcode.Location = New System.Drawing.Point(51, 68)
        Me.TextItemBarcode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextItemBarcode.Name = "TextItemBarcode"
        Me.TextItemBarcode.Properties.AdvancedModeOptions.Label = "الباركود"
        Me.TextItemBarcode.Properties.MaxLength = 20
        Me.TextItemBarcode.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextItemBarcode.Size = New System.Drawing.Size(337, 36)
        Me.TextItemBarcode.TabIndex = 1
        '
        'TextPrice
        '
        Me.TextPrice.EditValue = CType(0, Short)
        Me.TextPrice.Location = New System.Drawing.Point(51, 121)
        Me.TextPrice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextPrice.Name = "TextPrice"
        Me.TextPrice.Properties.AdvancedModeOptions.Label = "سعر البيع:"
        Me.TextPrice.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextPrice.Size = New System.Drawing.Size(154, 36)
        Me.TextPrice.TabIndex = 2
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Location = New System.Drawing.Point(50, 300)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(154, 40)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "حفظ"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Location = New System.Drawing.Point(234, 300)
        Me.SimpleButton2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(154, 40)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "الغاء"
        '
        'AccountingDataSet
        '
        Me.AccountingDataSet.DataSetName = "AccountingDataSet"
        Me.AccountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UnitsBindingSource
        '
        Me.UnitsBindingSource.DataMember = "Units"
        Me.UnitsBindingSource.DataSource = Me.AccountingDataSet
        '
        'UnitsTableAdapter
        '
        Me.UnitsTableAdapter.ClearBeforeFill = True
        '
        'LookUpUnit
        '
        Me.LookUpUnit.EditValue = CType(1, Short)
        Me.LookUpUnit.Location = New System.Drawing.Point(225, 121)
        Me.LookUpUnit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LookUpUnit.Name = "LookUpUnit"
        Me.LookUpUnit.Properties.AdvancedModeOptions.Label = "الوحدة"
        Me.LookUpUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpUnit.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "Name1", 17, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "الوحدة", 17, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.LookUpUnit.Properties.DataSource = Me.UnitsBindingSource
        Me.LookUpUnit.Properties.DisplayMember = "name"
        Me.LookUpUnit.Properties.NullText = ""
        Me.LookUpUnit.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        Me.LookUpUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.LookUpUnit.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.LookUpUnit.Properties.ValueMember = "id"
        Me.LookUpUnit.Size = New System.Drawing.Size(161, 36)
        Me.LookUpUnit.TabIndex = 3
        '
        'SearchItemsGroups
        '
        Me.SearchItemsGroups.Location = New System.Drawing.Point(50, 235)
        Me.SearchItemsGroups.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SearchItemsGroups.Name = "SearchItemsGroups"
        Me.SearchItemsGroups.Properties.AdvancedModeOptions.Label = "مجموعة الصنف:"
        Me.SearchItemsGroups.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchItemsGroups.Properties.DisplayMember = "GroupName"
        Me.SearchItemsGroups.Properties.NullText = ""
        Me.SearchItemsGroups.Properties.PopupView = Me.GridView6
        Me.SearchItemsGroups.Properties.ShowAddNewButton = True
        Me.SearchItemsGroups.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.SearchItemsGroups.Properties.ValueMember = "GroupID"
        Me.SearchItemsGroups.Size = New System.Drawing.Size(338, 36)
        Me.SearchItemsGroups.TabIndex = 5
        '
        'GridView6
        '
        Me.GridView6.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17})
        Me.GridView6.DetailHeight = 284
        Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView6.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "رقم"
        Me.GridColumn16.FieldName = "GroupID"
        Me.GridColumn16.MinWidth = 17
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Width = 64
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "المجموعة"
        Me.GridColumn17.FieldName = "GroupName"
        Me.GridColumn17.MinWidth = 17
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        Me.GridColumn17.Width = 64
        '
        'TextQuantity
        '
        Me.TextQuantity.EditValue = CType(0, Short)
        Me.TextQuantity.Location = New System.Drawing.Point(50, 178)
        Me.TextQuantity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextQuantity.Name = "TextQuantity"
        Me.TextQuantity.Properties.AdvancedModeOptions.Label = "الكمية لأغراض الجرد:"
        Me.TextQuantity.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextQuantity.Size = New System.Drawing.Size(206, 36)
        Me.TextQuantity.TabIndex = 4
        '
        'PosItemDirectDefind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 351)
        Me.Controls.Add(Me.SearchItemsGroups)
        Me.Controls.Add(Me.LookUpUnit)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.TextQuantity)
        Me.Controls.Add(Me.TextPrice)
        Me.Controls.Add(Me.TextItemBarcode)
        Me.Controls.Add(Me.TextItemName)
        Me.IconOptions.SvgImage = CType(resources.GetObject("PosItemDirectDefind.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PosItemDirectDefind"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تعريف صنف جديد"
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemBarcode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccountingDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UnitsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchItemsGroups.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextItemBarcode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccountingDataSet As AccountingDataSet
    Friend WithEvents UnitsBindingSource As BindingSource
    Friend WithEvents UnitsTableAdapter As AccountingDataSetTableAdapters.UnitsTableAdapter
    Friend WithEvents LookUpUnit As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents SearchItemsGroups As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextQuantity As DevExpress.XtraEditors.TextEdit
End Class
