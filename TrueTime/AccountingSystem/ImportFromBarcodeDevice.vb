Imports System.ComponentModel

Public Class ImportFromBarcodeDevice
    Private Sub ImportFromBarcodeDevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTempTable()
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
            ' .Columns.Add("StockItemPrice", GetType(Decimal))
            .Columns.Add("StockPrice", GetType(Decimal))
            .Columns.Add("StockBarcode", GetType(String))
            .Columns.Add("StockQuantityPerMainUnit", GetType(Decimal))
            .Columns.Add("DebitAcc", GetType(String))
            .Columns.Add("CredAcc", GetType(String))
            .Columns.Add("DocAmount", GetType(Decimal))
            '  .Columns.Add("StockBarcode", GetType(String))

        End With

        GridControl1.DataSource = JournalTable

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        GlobalVariables._ItemsTable = dt
        Me.Dispose()
    End Sub

    Private Sub ImportFromBarcodeDevice_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub
End Class