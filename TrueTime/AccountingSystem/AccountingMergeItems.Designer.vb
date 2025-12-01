<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountingMergeItems
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
        Me.SearchLookOldItem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.SearchLookNewItem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TextOldItemName = New DevExpress.XtraEditors.TextEdit()
        Me.TextNewItemName = New DevExpress.XtraEditors.TextEdit()
        Me.TextOldItemUnitName = New DevExpress.XtraEditors.TextEdit()
        Me.TextOldItemTransCount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.OldItemProductEquationCount = New DevExpress.XtraEditors.TextEdit()
        Me.SeparatorControl2 = New DevExpress.XtraEditors.SeparatorControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TextNewItemUnitName = New DevExpress.XtraEditors.TextEdit()
        Me.TextNewItemTransCount = New DevExpress.XtraEditors.TextEdit()
        Me.NewItemProductEquationCount = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TextNewItemHasEquation = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.TextOldItemHasEquation = New DevExpress.XtraEditors.TextEdit()
        Me.CheckMergeBarcodes = New DevExpress.XtraEditors.CheckEdit()
        Me.CheckEditDelete = New DevExpress.XtraEditors.CheckEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SearchLookOldItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookNewItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOldItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOldItemUnitName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOldItemTransCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OldItemProductEquationCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewItemUnitName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewItemTransCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewItemProductEquationCount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNewItemHasEquation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOldItemHasEquation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckMergeBarcodes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckEditDelete.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SearchLookOldItem
        '
        Me.SearchLookOldItem.EditValue = ""
        Me.SearchLookOldItem.Location = New System.Drawing.Point(174, 107)
        Me.SearchLookOldItem.Name = "SearchLookOldItem"
        Me.SearchLookOldItem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SearchLookOldItem.Properties.Appearance.Options.UseBackColor = True
        Me.SearchLookOldItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookOldItem.Properties.DisplayMember = "ItemNo"
        Me.SearchLookOldItem.Properties.NullText = ""
        Me.SearchLookOldItem.Properties.PopupView = Me.SearchLookUpEdit1View
        Me.SearchLookOldItem.Properties.ValueMember = "ItemNo"
        Me.SearchLookOldItem.Size = New System.Drawing.Size(89, 22)
        Me.SearchLookOldItem.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 104)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "الصنف المراد الغائه:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 256)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(150, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "الصنف المراد تحميل الحركات عليه:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(34, 29)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(123, 22)
        Me.LabelControl3.TabIndex = 1
        Me.LabelControl3.Text = "شاشة دمج الأصناف"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(-1, 57)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(525, 23)
        Me.SeparatorControl1.TabIndex = 2
        '
        'SearchLookNewItem
        '
        Me.SearchLookNewItem.EditValue = ""
        Me.SearchLookNewItem.Location = New System.Drawing.Point(174, 253)
        Me.SearchLookNewItem.Name = "SearchLookNewItem"
        Me.SearchLookNewItem.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SearchLookNewItem.Properties.Appearance.Options.UseBackColor = True
        Me.SearchLookNewItem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SearchLookNewItem.Properties.DisplayMember = "ItemNo"
        Me.SearchLookNewItem.Properties.NullText = ""
        Me.SearchLookNewItem.Properties.PopupView = Me.GridView1
        Me.SearchLookNewItem.Properties.ValueMember = "ItemNo"
        Me.SearchLookNewItem.Size = New System.Drawing.Size(89, 22)
        Me.SearchLookNewItem.TabIndex = 0
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(12, 443)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(98, 23)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "دمج الحركات"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 136)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl4.TabIndex = 4
        Me.LabelControl4.Text = "الوحدة الرئيسية:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(309, 136)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "عدد الحركات:"
        '
        'TextOldItemName
        '
        Me.TextOldItemName.Location = New System.Drawing.Point(269, 107)
        Me.TextOldItemName.Name = "TextOldItemName"
        Me.TextOldItemName.Properties.ReadOnly = True
        Me.TextOldItemName.Size = New System.Drawing.Size(233, 22)
        Me.TextOldItemName.TabIndex = 5
        '
        'TextNewItemName
        '
        Me.TextNewItemName.Location = New System.Drawing.Point(269, 253)
        Me.TextNewItemName.Name = "TextNewItemName"
        Me.TextNewItemName.Properties.ReadOnly = True
        Me.TextNewItemName.Size = New System.Drawing.Size(233, 22)
        Me.TextNewItemName.TabIndex = 5
        '
        'TextOldItemUnitName
        '
        Me.TextOldItemUnitName.Location = New System.Drawing.Point(128, 133)
        Me.TextOldItemUnitName.Name = "TextOldItemUnitName"
        Me.TextOldItemUnitName.Properties.ReadOnly = True
        Me.TextOldItemUnitName.Size = New System.Drawing.Size(119, 22)
        Me.TextOldItemUnitName.TabIndex = 5
        '
        'TextOldItemTransCount
        '
        Me.TextOldItemTransCount.Location = New System.Drawing.Point(383, 133)
        Me.TextOldItemTransCount.Name = "TextOldItemTransCount"
        Me.TextOldItemTransCount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOldItemTransCount.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextOldItemTransCount.Properties.Appearance.Options.UseFont = True
        Me.TextOldItemTransCount.Properties.Appearance.Options.UseForeColor = True
        Me.TextOldItemTransCount.Properties.ReadOnly = True
        Me.TextOldItemTransCount.Size = New System.Drawing.Size(119, 22)
        Me.TextOldItemTransCount.TabIndex = 5
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(9, 162)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(114, 13)
        Me.LabelControl7.TabIndex = 4
        Me.LabelControl7.Text = "موجود في معادلات انتاج:"
        '
        'OldItemProductEquationCount
        '
        Me.OldItemProductEquationCount.Location = New System.Drawing.Point(128, 159)
        Me.OldItemProductEquationCount.Name = "OldItemProductEquationCount"
        Me.OldItemProductEquationCount.Properties.ReadOnly = True
        Me.OldItemProductEquationCount.Size = New System.Drawing.Size(119, 22)
        Me.OldItemProductEquationCount.TabIndex = 5
        '
        'SeparatorControl2
        '
        Me.SeparatorControl2.Location = New System.Drawing.Point(34, 209)
        Me.SeparatorControl2.Name = "SeparatorControl2"
        Me.SeparatorControl2.Size = New System.Drawing.Size(443, 23)
        Me.SeparatorControl2.TabIndex = 2
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 294)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "الوحدة الرئيسية:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(309, 294)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl8.TabIndex = 4
        Me.LabelControl8.Text = "عدد الحركات:"
        '
        'TextNewItemUnitName
        '
        Me.TextNewItemUnitName.Location = New System.Drawing.Point(128, 291)
        Me.TextNewItemUnitName.Name = "TextNewItemUnitName"
        Me.TextNewItemUnitName.Properties.ReadOnly = True
        Me.TextNewItemUnitName.Size = New System.Drawing.Size(119, 22)
        Me.TextNewItemUnitName.TabIndex = 5
        '
        'TextNewItemTransCount
        '
        Me.TextNewItemTransCount.Location = New System.Drawing.Point(383, 287)
        Me.TextNewItemTransCount.Name = "TextNewItemTransCount"
        Me.TextNewItemTransCount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNewItemTransCount.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNewItemTransCount.Properties.Appearance.Options.UseFont = True
        Me.TextNewItemTransCount.Properties.Appearance.Options.UseForeColor = True
        Me.TextNewItemTransCount.Properties.ReadOnly = True
        Me.TextNewItemTransCount.Size = New System.Drawing.Size(119, 22)
        Me.TextNewItemTransCount.TabIndex = 5
        '
        'NewItemProductEquationCount
        '
        Me.NewItemProductEquationCount.Location = New System.Drawing.Point(128, 317)
        Me.NewItemProductEquationCount.Name = "NewItemProductEquationCount"
        Me.NewItemProductEquationCount.Properties.ReadOnly = True
        Me.NewItemProductEquationCount.Size = New System.Drawing.Size(119, 22)
        Me.NewItemProductEquationCount.TabIndex = 5
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(309, 166)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl10.TabIndex = 4
        Me.LabelControl10.Text = "له معادلة انتاج:"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(9, 324)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(114, 13)
        Me.LabelControl11.TabIndex = 4
        Me.LabelControl11.Text = "موجود في معادلات انتاج:"
        '
        'TextNewItemHasEquation
        '
        Me.TextNewItemHasEquation.Location = New System.Drawing.Point(383, 317)
        Me.TextNewItemHasEquation.Name = "TextNewItemHasEquation"
        Me.TextNewItemHasEquation.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNewItemHasEquation.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNewItemHasEquation.Properties.Appearance.Options.UseFont = True
        Me.TextNewItemHasEquation.Properties.Appearance.Options.UseForeColor = True
        Me.TextNewItemHasEquation.Properties.ReadOnly = True
        Me.TextNewItemHasEquation.Size = New System.Drawing.Size(119, 22)
        Me.TextNewItemHasEquation.TabIndex = 5
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(301, 324)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl9.TabIndex = 4
        Me.LabelControl9.Text = "له معادلة انتاج:"
        '
        'TextOldItemHasEquation
        '
        Me.TextOldItemHasEquation.Location = New System.Drawing.Point(383, 163)
        Me.TextOldItemHasEquation.Name = "TextOldItemHasEquation"
        Me.TextOldItemHasEquation.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOldItemHasEquation.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextOldItemHasEquation.Properties.Appearance.Options.UseFont = True
        Me.TextOldItemHasEquation.Properties.Appearance.Options.UseForeColor = True
        Me.TextOldItemHasEquation.Properties.ReadOnly = True
        Me.TextOldItemHasEquation.Size = New System.Drawing.Size(119, 22)
        Me.TextOldItemHasEquation.TabIndex = 5
        '
        'CheckMergeBarcodes
        '
        Me.CheckMergeBarcodes.EditValue = True
        Me.CheckMergeBarcodes.Location = New System.Drawing.Point(12, 390)
        Me.CheckMergeBarcodes.Name = "CheckMergeBarcodes"
        Me.CheckMergeBarcodes.Properties.Caption = "دمج الباركودات"
        Me.CheckMergeBarcodes.Size = New System.Drawing.Size(121, 20)
        Me.CheckMergeBarcodes.TabIndex = 6
        '
        'CheckEditDelete
        '
        Me.CheckEditDelete.EditValue = True
        Me.CheckEditDelete.Location = New System.Drawing.Point(383, 390)
        Me.CheckEditDelete.Name = "CheckEditDelete"
        Me.CheckEditDelete.Properties.Caption = "حذف الصنف القديم"
        Me.CheckEditDelete.Size = New System.Drawing.Size(118, 20)
        Me.CheckEditDelete.TabIndex = 7
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "رقم الصنف"
        Me.GridColumn3.FieldName = "ItemNo"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "الصنف"
        Me.GridColumn4.FieldName = "ItemName"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "رقم الصنف"
        Me.GridColumn1.FieldName = "ItemNo"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "الصنف"
        Me.GridColumn2.FieldName = "ItemName"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'AccountingMergeItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 478)
        Me.Controls.Add(Me.CheckEditDelete)
        Me.Controls.Add(Me.CheckMergeBarcodes)
        Me.Controls.Add(Me.TextNewItemName)
        Me.Controls.Add(Me.NewItemProductEquationCount)
        Me.Controls.Add(Me.TextNewItemTransCount)
        Me.Controls.Add(Me.TextNewItemHasEquation)
        Me.Controls.Add(Me.TextOldItemHasEquation)
        Me.Controls.Add(Me.OldItemProductEquationCount)
        Me.Controls.Add(Me.TextNewItemUnitName)
        Me.Controls.Add(Me.TextOldItemTransCount)
        Me.Controls.Add(Me.TextOldItemUnitName)
        Me.Controls.Add(Me.TextOldItemName)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.SeparatorControl2)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SearchLookNewItem)
        Me.Controls.Add(Me.SearchLookOldItem)
        Me.Name = "AccountingMergeItems"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AccountingMergeItems"
        CType(Me.SearchLookOldItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookNewItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOldItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOldItemUnitName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOldItemTransCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OldItemProductEquationCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewItemUnitName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewItemTransCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewItemProductEquationCount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNewItemHasEquation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOldItemHasEquation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckMergeBarcodes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckEditDelete.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SearchLookOldItem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchLookNewItem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextOldItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextNewItemName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextOldItemUnitName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextOldItemTransCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents OldItemProductEquationCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SeparatorControl2 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextNewItemUnitName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextNewItemTransCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents NewItemProductEquationCount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextNewItemHasEquation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextOldItemHasEquation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CheckMergeBarcodes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CheckEditDelete As DevExpress.XtraEditors.CheckEdit
End Class
