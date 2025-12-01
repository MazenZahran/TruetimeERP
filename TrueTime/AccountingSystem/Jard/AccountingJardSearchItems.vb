Public Class AccountingJardSearchItems
    Public Sub New(_OpenFrom As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub txtSearch_EditValueChanged(sender As Object, e As EventArgs) Handles txtSearch.EditValueChanged
        SearchItems()
    End Sub
    Private Sub SearchItems()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select ItemNo,ItemName,IU.item_unit_bar_code,IU.Price1,U.name as Unit,IU.unit_id  
                        from Items I left join Items_units IU on I.ItemNo=IU.item_id
                        left join Units U on U.id=IU.unit_id 
                        where I.[Type]=0 and ItemName like N'%" & txtSearch.Text & "%' 
                           Or IU.item_unit_bar_code like N'%" & txtSearch.Text & "%' or IU.item_id like N'%" & txtSearch.Text & "%'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            GridControl1.Focus()
        End If
    End Sub

    Private Sub AccountingJardSearchItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearch.Select()
        Me.KeyPreview = True
        ColItemNo2.Visible = GlobalVariables._ShowItemNo2
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetItemNoItemBarcode()
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        GetItemNoItemBarcode()
    End Sub
    Private Sub GetItemNoItemBarcode()
        Dim _ItemNo, _UnitID As Integer
        Dim _Barcode As String
        _ItemNo = GridView1.GetFocusedRowCellValue("ItemNo")
        _Barcode = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
        _UnitID = GridView1.GetFocusedRowCellValue("unit_id")
        GlobalVariables._ItemNoGlobal = _ItemNo
        GlobalVariables._ItemBarcodeGlobal = _Barcode
        GlobalVariables._ItemUnitIDGlobal = _UnitID
        Me.Close()
    End Sub

    Private Sub AccountingJardSearchItems_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class