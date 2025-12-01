
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports GridView = DevExpress.XtraGrid.Views.Grid.GridView

Public Class ImportBarcodesToVouchers
    Dim _StockBarCode As String = "0"
    Private Sub ImportBarcodesToVouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTempTable()
        RepositoryUnit.DataSource = GetOnlyUnitsTable()
    End Sub
    Private Sub CreateTempTable()
        Dim PlaneTable As New DataTable

        Dim JournalTable As New DataTable
        Dim DD As New DataColumn With {
            .AllowDBNull = False,
            .Unique = True
        }
        With JournalTable

            .Columns.Add("StockID", GetType(String))
            .Columns.Add("ItemName", GetType(String))
            .Columns.Add("StockUnit", GetType(Integer))
            .Columns.Add("StockQuantity", GetType(Decimal))
            .Columns.Add("StockQuantityByMainUnit", GetType(Decimal))
            '.Columns.Add("StockItemPrice", GetType(Decimal))
            .Columns.Add("StockPrice", GetType(Decimal))
            .Columns.Add("StockBarcode", GetType(String))
            .Columns.Add("StockQuantityPerMainUnit", GetType(Decimal))
            .Columns.Add("DebitAcc", GetType(String))
            .Columns.Add("CredAcc", GetType(String))
            .Columns.Add("DocAmount", GetType(Decimal))
            ' .Columns.Add("UnitID", GetType(Integer))
            '  .Columns.Add("StockBarcode", GetType(String))

        End With

        GridControl1.DataSource = JournalTable

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            If ImportFromBarcodeDevice.ShowDialog() <> DialogResult.OK Then
                If _ItemsTable.Rows.Count = 0 Then Exit Sub
                Dim i As Integer
                For i = 0 To _ItemsTable.Rows.Count - 1
                    _StockBarCode = _ItemsTable.Rows(i).Item("StockBarcode")
                    GridView1.AddNewRow()
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                Next
            End If
        Catch ex As Exception
            _ItemsTable = GridControl1.DataSource
        End Try

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار الأصناف من القائمة")
            Exit Sub
        End If

        GridView1.PostEditor()
        Dim i As Integer = 0
        While (i < GridView1.DataRowCount)
            Dim val As String = CStr(GridView1.GetRowCellValue(i, GridView1.Columns("ItemName")))
            If val = "0" Or Not GridView1.IsRowSelected(i) Then
                GridView1.DeleteRow(i)
            Else
                i = i + 1
            End If
        End While

        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        GlobalVariables._ItemsTable = dt
        _AcceptFromImportSreen = True
        Me.Dispose()
    End Sub

    Private Sub GridView1_InitNewRow2(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Dim ItemDataByBarcode = GetItemsData(_StockBarCode, True)
        Me.GridView1.SetRowCellValue(e.RowHandle, "StockBarcode", _StockBarCode)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemName", ItemDataByBarcode.ItemName)
        If ItemDataByBarcode.ItemName <> "0" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockID", ItemDataByBarcode.ItemNo)
            Me.GridView1.SetRowCellValue(e.RowHandle, "ItemName", ItemDataByBarcode.ItemName)
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantity", 1)
            '  Me.GridView1.SetRowCellValue(e.RowHandle, "StockItemPrice", ItemDataByBarcode._Price1)
            Me.GridView1.SetRowCellValue(e.RowHandle, "DocAmount", ItemDataByBarcode._Price1)
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantityByMainUnit", ItemDataByBarcode.EquivalentToMain)
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantityPerMainUnit", ItemDataByBarcode.EquivalentToMain)
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockPrice", ItemDataByBarcode._Price1)
            Me.GridView1.SetRowCellValue(e.RowHandle, "StockUnit", ItemDataByBarcode.DefaultUnit)
            Me.GridView1.SetRowCellValue(e.RowHandle, "DocAmount", ItemDataByBarcode._Price1)
            Select Case DocName.EditValue
                Case 1, 10
                    Me.GridView1.SetRowCellValue(e.RowHandle, "DebitAcc", ItemDataByBarcode.AccPurches)
                Case 2, 11
                    Me.GridView1.SetRowCellValue(e.RowHandle, "CredAcc", ItemDataByBarcode.AccSales)
                Case 12
                    Me.GridView1.SetRowCellValue(e.RowHandle, "DebitAcc", ItemDataByBarcode.AccRetSales)
                Case 13
                    Me.GridView1.SetRowCellValue(e.RowHandle, "CredAcc", ItemDataByBarcode.AccRetPurches)
            End Select
            Select Case GridView1.RowCount
                Case 10
                    Me.GridView1.IndicatorWidth = 30
                Case 99
                    Me.GridView1.IndicatorWidth = 50
            End Select
        End If

    End Sub
    Private Sub gridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedColumn.FieldName = "ExchangePrice" AndAlso
           String.IsNullOrEmpty(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")) Then
            e.Cancel = True
        End If
    End Sub


End Class