<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PosHoldVouchers
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PosHoldVouchers))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim TableColumnDefinition1 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TableColumnDefinition2 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New DevExpress.XtraEditors.TableLayout.TableColumnDefinition()
        Dim TableRowDefinition1 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition2 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition3 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition4 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition5 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableRowDefinition6 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New DevExpress.XtraEditors.TableLayout.TableRowDefinition()
        Dim TableSpan1 As DevExpress.XtraEditors.TableLayout.TableSpan = New DevExpress.XtraEditors.TableLayout.TableSpan()
        Dim TableSpan2 As DevExpress.XtraEditors.TableLayout.TableSpan = New DevExpress.XtraEditors.TableLayout.TableSpan()
        Dim TableSpan3 As DevExpress.XtraEditors.TableLayout.TableSpan = New DevExpress.XtraEditors.TableLayout.TableSpan()
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement5 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement7 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement8 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement9 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Me.TileDocID = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileInputDateTime = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileAmount = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileQuantity = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileViewDocNote = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileViewReferanceName = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileViewColumn2 = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.RepositoryPrint = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.TileView1 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.TileDocCode = New DevExpress.XtraGrid.Columns.TileViewColumn()
        Me.TileViewColumn1 = New DevExpress.XtraGrid.Columns.TileViewColumn()
        CType(Me.RepositoryPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TileDocID
        '
        Me.TileDocID.Caption = "رقم"
        Me.TileDocID.FieldName = "DocID"
        Me.TileDocID.Name = "TileDocID"
        Me.TileDocID.Visible = True
        Me.TileDocID.VisibleIndex = 2
        '
        'TileInputDateTime
        '
        Me.TileInputDateTime.Caption = "الوقت"
        Me.TileInputDateTime.DisplayFormat.FormatString = "yyyy-MM-dd (HH:mm:ss)"
        Me.TileInputDateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TileInputDateTime.FieldName = "InputDateTime"
        Me.TileInputDateTime.Name = "TileInputDateTime"
        Me.TileInputDateTime.Visible = True
        Me.TileInputDateTime.VisibleIndex = 0
        '
        'TileAmount
        '
        Me.TileAmount.Caption = "المبلغ"
        Me.TileAmount.DisplayFormat.FormatString = "{0:0.00 شيكل }"
        Me.TileAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TileAmount.FieldName = "Amount"
        Me.TileAmount.Name = "TileAmount"
        Me.TileAmount.Visible = True
        Me.TileAmount.VisibleIndex = 3
        '
        'TileQuantity
        '
        Me.TileQuantity.Caption = "الكمية"
        Me.TileQuantity.FieldName = "Quantity"
        Me.TileQuantity.Name = "TileQuantity"
        Me.TileQuantity.Visible = True
        Me.TileQuantity.VisibleIndex = 4
        '
        'TileViewDocNote
        '
        Me.TileViewDocNote.Caption = "ملاحظات"
        Me.TileViewDocNote.FieldName = "DocNotes"
        Me.TileViewDocNote.Name = "TileViewDocNote"
        Me.TileViewDocNote.Visible = True
        Me.TileViewDocNote.VisibleIndex = 5
        '
        'TileViewReferanceName
        '
        Me.TileViewReferanceName.Caption = "اسم الذمة"
        Me.TileViewReferanceName.FieldName = "ReferanceName"
        Me.TileViewReferanceName.Name = "TileViewReferanceName"
        Me.TileViewReferanceName.Visible = True
        Me.TileViewReferanceName.VisibleIndex = 7
        '
        'TileViewColumn2
        '
        Me.TileViewColumn2.Caption = "طباعة"
        Me.TileViewColumn2.ColumnEdit = Me.RepositoryPrint
        Me.TileViewColumn2.Name = "TileViewColumn2"
        Me.TileViewColumn2.Visible = True
        Me.TileViewColumn2.VisibleIndex = 6
        Me.TileViewColumn2.Width = 64
        '
        'RepositoryPrint
        '
        Me.RepositoryPrint.AutoHeight = False
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.RepositoryPrint.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.RepositoryPrint.Name = "RepositoryPrint"
        Me.RepositoryPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.TileView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryPrint})
        Me.GridControl1.Size = New System.Drawing.Size(470, 607)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileView1})
        '
        'TileView1
        '
        Me.TileView1.Appearance.ItemHovered.BackColor = System.Drawing.Color.Gold
        Me.TileView1.Appearance.ItemHovered.Options.UseBackColor = True
        Me.TileView1.Appearance.ItemNormal.BackColor = System.Drawing.SystemColors.Info
        Me.TileView1.Appearance.ItemNormal.Options.UseBackColor = True
        Me.TileView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TileInputDateTime, Me.TileDocCode, Me.TileDocID, Me.TileAmount, Me.TileQuantity, Me.TileViewDocNote, Me.TileViewColumn1, Me.TileViewReferanceName, Me.TileViewColumn2})
        Me.TileView1.GridControl = Me.GridControl1
        Me.TileView1.Name = "TileView1"
        Me.TileView1.OptionsTiles.AllowItemHover = True
        Me.TileView1.OptionsTiles.GroupTextPadding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.TileView1.OptionsTiles.IndentBetweenGroups = 29
        Me.TileView1.OptionsTiles.IndentBetweenItems = 0
        Me.TileView1.OptionsTiles.ItemPadding = New System.Windows.Forms.Padding(10)
        Me.TileView1.OptionsTiles.ItemSize = New System.Drawing.Size(460, 132)
        Me.TileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List
        Me.TileView1.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileView1.OptionsTiles.RowCount = 0
        TableColumnDefinition1.Length.Value = 127.0R
        TableColumnDefinition2.Length.Value = 81.0R
        Me.TileView1.TileColumns.Add(TableColumnDefinition1)
        Me.TileView1.TileColumns.Add(TableColumnDefinition2)
        TableRowDefinition1.Length.Value = 15.0R
        TableRowDefinition2.Length.Value = 18.0R
        TableRowDefinition3.Length.Value = 14.0R
        TableRowDefinition4.Length.Value = 19.0R
        TableRowDefinition5.Length.Value = 22.0R
        TableRowDefinition6.Length.Value = 24.0R
        Me.TileView1.TileRows.Add(TableRowDefinition1)
        Me.TileView1.TileRows.Add(TableRowDefinition2)
        Me.TileView1.TileRows.Add(TableRowDefinition3)
        Me.TileView1.TileRows.Add(TableRowDefinition4)
        Me.TileView1.TileRows.Add(TableRowDefinition5)
        Me.TileView1.TileRows.Add(TableRowDefinition6)
        TableSpan1.ColumnSpan = 2
        TableSpan1.RowIndex = 3
        TableSpan2.ColumnSpan = 2
        TableSpan2.RowIndex = 4
        TableSpan3.ColumnSpan = 2
        TableSpan3.RowIndex = 5
        Me.TileView1.TileSpans.Add(TableSpan1)
        Me.TileView1.TileSpans.Add(TableSpan2)
        Me.TileView1.TileSpans.Add(TableSpan3)
        TileViewItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement1.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement1.Column = Me.TileDocID
        TileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement1.Text = "TileDocID"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement2.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement2.ColumnIndex = 1
        TileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement2.Text = "رقم الفاتورة:"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement3.Appearance.Normal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement3.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Hyperlink
        TileViewItemElement3.Appearance.Normal.Options.UseFont = True
        TileViewItemElement3.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement3.Column = Me.TileInputDateTime
        TileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement3.RowIndex = 3
        TileViewItemElement3.StretchHorizontal = True
        TileViewItemElement3.Text = "TileInputDateTime"
        TileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement4.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement4.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement4.ColumnIndex = 1
        TileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement4.RowIndex = 1
        TileViewItemElement4.Text = "المبلغ:"
        TileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement5.Appearance.Normal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement5.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText
        TileViewItemElement5.Appearance.Normal.Options.UseFont = True
        TileViewItemElement5.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement5.Column = Me.TileAmount
        TileViewItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement5.RowIndex = 1
        TileViewItemElement5.Text = "TileAmount"
        TileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement6.Appearance.Normal.ForeColor = System.Drawing.Color.Gray
        TileViewItemElement6.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement6.ColumnIndex = 1
        TileViewItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement6.RowIndex = 2
        TileViewItemElement6.Text = "عدد الأصناف:"
        TileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement7.Appearance.Normal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement7.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.DisabledText
        TileViewItemElement7.Appearance.Normal.Options.UseFont = True
        TileViewItemElement7.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement7.Column = Me.TileQuantity
        TileViewItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement7.RowIndex = 2
        TileViewItemElement7.Text = "TileQuantity"
        TileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement8.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Warning
        TileViewItemElement8.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement8.Column = Me.TileViewDocNote
        TileViewItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement8.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement8.RowIndex = 5
        TileViewItemElement8.Text = "TileViewDocNote"
        TileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement9.Appearance.Normal.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.WindowText
        TileViewItemElement9.Appearance.Normal.Options.UseForeColor = True
        TileViewItemElement9.Column = Me.TileViewReferanceName
        TileViewItemElement9.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        TileViewItemElement9.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze
        TileViewItemElement9.RowIndex = 4
        TileViewItemElement9.Text = "TileViewReferanceName"
        TileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
        Me.TileView1.TileTemplate.Add(TileViewItemElement1)
        Me.TileView1.TileTemplate.Add(TileViewItemElement2)
        Me.TileView1.TileTemplate.Add(TileViewItemElement3)
        Me.TileView1.TileTemplate.Add(TileViewItemElement4)
        Me.TileView1.TileTemplate.Add(TileViewItemElement5)
        Me.TileView1.TileTemplate.Add(TileViewItemElement6)
        Me.TileView1.TileTemplate.Add(TileViewItemElement7)
        Me.TileView1.TileTemplate.Add(TileViewItemElement8)
        Me.TileView1.TileTemplate.Add(TileViewItemElement9)
        '
        'TileDocCode
        '
        Me.TileDocCode.Caption = "DocCode"
        Me.TileDocCode.FieldName = "DocCode"
        Me.TileDocCode.Name = "TileDocCode"
        Me.TileDocCode.Visible = True
        Me.TileDocCode.VisibleIndex = 1
        '
        'TileViewColumn1
        '
        Me.TileViewColumn1.Caption = "الذمة"
        Me.TileViewColumn1.FieldName = "Referance"
        Me.TileViewColumn1.Name = "TileViewColumn1"
        '
        'PosHoldVouchers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 607)
        Me.Controls.Add(Me.GridControl1)
        Me.IconOptions.Image = CType(resources.GetObject("PosHoldVouchers.IconOptions.Image"), System.Drawing.Image)
        Me.LookAndFeel.SkinName = "Office 2019 White"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "PosHoldVouchers"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الفواتير المعلقة"
        CType(Me.RepositoryPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents TileView1 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents TileInputDateTime As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileDocCode As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileDocID As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileAmount As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileQuantity As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileViewDocNote As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileViewColumn1 As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileViewReferanceName As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents TileViewColumn2 As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents RepositoryPrint As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
