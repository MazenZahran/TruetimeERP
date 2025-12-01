<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemsAvailableBatches
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsAvailableBatches))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.TextItemNo = New DevExpress.XtraEditors.TextEdit()
        Me.TextItemName = New DevExpress.XtraEditors.TextEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColBatchNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColExpireDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Colbalance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryOK = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryOK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextItemNo
        '
        Me.TextItemNo.Location = New System.Drawing.Point(17, 9)
        Me.TextItemNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextItemNo.Name = "TextItemNo"
        Me.TextItemNo.Properties.ReadOnly = True
        Me.TextItemNo.Size = New System.Drawing.Size(190, 28)
        Me.TextItemNo.TabIndex = 0
        '
        'TextItemName
        '
        Me.TextItemName.Location = New System.Drawing.Point(17, 41)
        Me.TextItemName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextItemName.Name = "TextItemName"
        Me.TextItemName.Properties.ReadOnly = True
        Me.TextItemName.Size = New System.Drawing.Size(457, 28)
        Me.TextItemName.TabIndex = 1
        '
        'GridControl1
        '
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Location = New System.Drawing.Point(17, 73)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryOK})
        Me.GridControl1.Size = New System.Drawing.Size(457, 217)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColID, Me.ColBatchNo, Me.ColExpireDate, Me.Colbalance, Me.GridColumn1})
        Me.GridView1.DetailHeight = 268
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 686
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ColID
        '
        Me.ColID.Caption = "GridColumn1"
        Me.ColID.FieldName = "ID"
        Me.ColID.MinWidth = 17
        Me.ColID.Name = "ColID"
        Me.ColID.Width = 64
        '
        'ColBatchNo
        '
        Me.ColBatchNo.Caption = "BatchNo"
        Me.ColBatchNo.FieldName = "BatchNo"
        Me.ColBatchNo.MinWidth = 17
        Me.ColBatchNo.Name = "ColBatchNo"
        Me.ColBatchNo.OptionsColumn.AllowEdit = False
        Me.ColBatchNo.Visible = True
        Me.ColBatchNo.VisibleIndex = 0
        Me.ColBatchNo.Width = 69
        '
        'ColExpireDate
        '
        Me.ColExpireDate.Caption = "ExpireDate"
        Me.ColExpireDate.FieldName = "ExpireDate"
        Me.ColExpireDate.MinWidth = 17
        Me.ColExpireDate.Name = "ColExpireDate"
        Me.ColExpireDate.OptionsColumn.AllowEdit = False
        Me.ColExpireDate.Visible = True
        Me.ColExpireDate.VisibleIndex = 1
        Me.ColExpireDate.Width = 100
        '
        'Colbalance
        '
        Me.Colbalance.Caption = "الرصيد"
        Me.Colbalance.FieldName = "balance"
        Me.Colbalance.MinWidth = 17
        Me.Colbalance.Name = "Colbalance"
        Me.Colbalance.OptionsColumn.AllowEdit = False
        Me.Colbalance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "balance", "{0:0.##}")})
        Me.Colbalance.Visible = True
        Me.Colbalance.VisibleIndex = 2
        Me.Colbalance.Width = 69
        '
        'GridColumn1
        '
        Me.GridColumn1.ColumnEdit = Me.RepositoryOK
        Me.GridColumn1.MinWidth = 17
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 69
        '
        'RepositoryOK
        '
        Me.RepositoryOK.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.RepositoryOK.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryOK.Name = "RepositoryOK"
        Me.RepositoryOK.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(17, 308)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(135, 34)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "تعريف باتش جديد"
        '
        'ItemsAvailableBatches
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 358)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.TextItemName)
        Me.Controls.Add(Me.TextItemNo)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ItemsAvailableBatches"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الكميات المتوفرة للصنف حسب الباتش"
        CType(Me.TextItemNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryOK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextItemNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColBatchNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColExpireDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Colbalance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryOK As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
