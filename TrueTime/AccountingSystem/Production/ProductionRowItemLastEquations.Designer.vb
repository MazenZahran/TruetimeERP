<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionRowItemLastEquations
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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColEquationStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColEquationID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColDocNote = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColItemNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColItemUnit = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColItemQuantity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.ColRawItemNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColRawItemName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColRawItemUnit = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColRawItemPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.ColRawItemQuantity = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryEquationID = New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryEquationID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.BandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryEquationID})
        Me.GridControl1.Size = New System.Drawing.Size(1092, 463)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView1})
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.ColEquationID, Me.ColItemNo, Me.ColItemName, Me.ColItemUnit, Me.ColItemQuantity, Me.ColDocNote, Me.ColRawItemNo, Me.ColRawItemName, Me.ColRawItemQuantity, Me.ColRawItemUnit, Me.ColRawItemPrice, Me.ColEquationStatus})
        Me.BandedGridView1.GridControl = Me.GridControl1
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsView.RowAutoHeight = True
        Me.BandedGridView1.OptionsView.ShowFooter = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "معادلة الانتاج"
        Me.GridBand1.Columns.Add(Me.ColEquationStatus)
        Me.GridBand1.Columns.Add(Me.ColEquationID)
        Me.GridBand1.Columns.Add(Me.ColDocNote)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 230
        '
        'ColEquationStatus
        '
        Me.ColEquationStatus.Caption = "حالة المعادلة"
        Me.ColEquationStatus.FieldName = "EquationStatus"
        Me.ColEquationStatus.Name = "ColEquationStatus"
        Me.ColEquationStatus.Visible = True
        Me.ColEquationStatus.Width = 76
        '
        'ColEquationID
        '
        Me.ColEquationID.Caption = "رقم المعادلة"
        Me.ColEquationID.ColumnEdit = Me.RepositoryEquationID
        Me.ColEquationID.FieldName = "EquationID"
        Me.ColEquationID.Name = "ColEquationID"
        Me.ColEquationID.Visible = True
        Me.ColEquationID.Width = 76
        '
        'ColDocNote
        '
        Me.ColDocNote.Caption = "ملاحظات"
        Me.ColDocNote.FieldName = "DocNote"
        Me.ColDocNote.Name = "ColDocNote"
        Me.ColDocNote.Visible = True
        Me.ColDocNote.Width = 78
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "المواد المصنعة"
        Me.gridBand2.Columns.Add(Me.ColItemNo)
        Me.gridBand2.Columns.Add(Me.ColItemName)
        Me.gridBand2.Columns.Add(Me.ColItemUnit)
        Me.gridBand2.Columns.Add(Me.ColItemQuantity)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 369
        '
        'ColItemNo
        '
        Me.ColItemNo.Caption = "رقم الصنف"
        Me.ColItemNo.FieldName = "ItemNo"
        Me.ColItemNo.Name = "ColItemNo"
        Me.ColItemNo.Visible = True
        Me.ColItemNo.Width = 76
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "الصنف"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.Visible = True
        Me.ColItemName.Width = 138
        '
        'ColItemUnit
        '
        Me.ColItemUnit.Caption = "الوحدة"
        Me.ColItemUnit.FieldName = "ItemUnit"
        Me.ColItemUnit.Name = "ColItemUnit"
        Me.ColItemUnit.Visible = True
        Me.ColItemUnit.Width = 76
        '
        'ColItemQuantity
        '
        Me.ColItemQuantity.Caption = "الكمية"
        Me.ColItemQuantity.FieldName = "ItemQuantity"
        Me.ColItemQuantity.Name = "ColItemQuantity"
        Me.ColItemQuantity.Visible = True
        Me.ColItemQuantity.Width = 79
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "مواد الخام"
        Me.gridBand3.Columns.Add(Me.ColRawItemNo)
        Me.gridBand3.Columns.Add(Me.ColRawItemName)
        Me.gridBand3.Columns.Add(Me.ColRawItemUnit)
        Me.gridBand3.Columns.Add(Me.ColRawItemPrice)
        Me.gridBand3.Columns.Add(Me.ColRawItemQuantity)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 398
        '
        'ColRawItemNo
        '
        Me.ColRawItemNo.Caption = "رقم الصنف"
        Me.ColRawItemNo.FieldName = "RawItemNo"
        Me.ColRawItemNo.Name = "ColRawItemNo"
        Me.ColRawItemNo.Visible = True
        Me.ColRawItemNo.Width = 69
        '
        'ColRawItemName
        '
        Me.ColRawItemName.Caption = "الصنف"
        Me.ColRawItemName.FieldName = "RawItemName"
        Me.ColRawItemName.Name = "ColRawItemName"
        Me.ColRawItemName.Visible = True
        Me.ColRawItemName.Width = 150
        '
        'ColRawItemUnit
        '
        Me.ColRawItemUnit.Caption = "الوحدة"
        Me.ColRawItemUnit.FieldName = "RawItemUnit"
        Me.ColRawItemUnit.Name = "ColRawItemUnit"
        Me.ColRawItemUnit.Visible = True
        Me.ColRawItemUnit.Width = 58
        '
        'ColRawItemPrice
        '
        Me.ColRawItemPrice.Caption = "سعر التكلفة"
        Me.ColRawItemPrice.FieldName = "RawItemPrice"
        Me.ColRawItemPrice.Name = "ColRawItemPrice"
        Me.ColRawItemPrice.Visible = True
        Me.ColRawItemPrice.Width = 58
        '
        'ColRawItemQuantity
        '
        Me.ColRawItemQuantity.Caption = "الكمية"
        Me.ColRawItemQuantity.FieldName = "RawItemQuantity"
        Me.ColRawItemQuantity.Name = "ColRawItemQuantity"
        Me.ColRawItemQuantity.Visible = True
        Me.ColRawItemQuantity.Width = 63
        '
        'RepositoryEquationID
        '
        Me.RepositoryEquationID.AutoHeight = False
        Me.RepositoryEquationID.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.RepositoryEquationID.MaskSettings.Set("mask", "000000")
        Me.RepositoryEquationID.Name = "RepositoryEquationID"
        Me.RepositoryEquationID.SingleClick = True
        Me.RepositoryEquationID.UseMaskAsDisplayFormat = True
        '
        'ProductionRowItemLastEquations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 463)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "ProductionRowItemLastEquations"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "معادلات الانتاج لصنف"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryEquationID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ColEquationStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColEquationID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColDocNote As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ColItemNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColItemUnit As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColItemQuantity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents ColRawItemNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColRawItemName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColRawItemUnit As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColRawItemPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ColRawItemQuantity As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryEquationID As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
End Class
