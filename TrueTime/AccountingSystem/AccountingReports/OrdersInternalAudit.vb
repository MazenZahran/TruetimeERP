Public Class OrdersInternalAudit
    Private Sub OrdersInternalAudit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetOrdersForAudit()
        CreateOrdersTable()
        Me.GridControl1.DataSource = receivedItemsTable
    End Sub
    Private Sub GetOrdersForAudit()
        Dim sql As New SQLControl
        ' Dim sqlstring As String
        'sqlstring = "   "
        'sql.SqlTrueAccountingRunQuery(sqlstring)
        'GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryAudit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim F As New OrdersInternalAddAudit
        With F
            .ShowDialog()
        End With
    End Sub
    Private Function GetItemNo() As (ItemNo As Integer, ItemName As String, ItemNo2 As String)
        Dim _ItemNo As Integer
        Dim _ItemName As String = ""
        Dim _ItemNo2 As String = ""
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select top(1) item_id from [Items_units] where [item_unit_bar_code]=N'" & txtBarcode.Text & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _ItemNo = sql.SQLDS.Tables(0).Rows(0).Item("item_id")
            Else
                _ItemNo = 0
            End If

            If _ItemNo <> 0 Then
                sqlstring = " select top(1) ItemName,ItemNo2 from [Items] where [ItemNo]=" & _ItemNo & ""
                sql.SqlTrueAccountingRunQuery(sqlstring)
                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    _ItemName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("ItemName"))
                    _ItemNo2 = CStr(sql.SQLDS.Tables(0).Rows(0).Item("ItemNo2"))
                Else
                    _ItemName = ""
                    _ItemNo2 = ""
                End If
            End If


        Catch ex As Exception
            _ItemNo = 0
            _ItemName = ""
        End Try
        Return (_ItemNo, _ItemName, _ItemNo2)
    End Function
    Private Function GetOrderID(_ItemNo As Integer) As Integer
        Dim _ID As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select top(1) [ID] from [InternalOrders] where [ItemNo]=" & _ItemNo & " and Orderstatus=1 and ReceivedQuantity < Quantity order By ID desc "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Else
                _ID = 0
            End If
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function
    Private Sub ChangeQuantity(_ID As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update [InternalOrders] Set [ReceivedQuantity]=IsNull(ReceivedQuantity,0)+1 Where ID=" & _ID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        sqlstring = " INSERT INTO [dbo].[InternalOrdersReceiveLogs] (OrderID) Values (" & _ID & ") "
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub

    Private Sub txtBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyUp
        If e.KeyCode = Keys.Enter AndAlso txtBarcode.Text <> "" Then
            Dim _Item = GetItemNo()
            Dim _ItemNo As Integer = _Item.ItemNo
            Dim _ItemName As String = _Item.ItemName
            Dim _ItemNo2 As String = _Item.ItemNo2
            If _ItemNo = 0 Then
                MsgBoxShowError(" الصنف غير معرف ")
                Exit Sub
            End If

            Dim _ID As Integer = GetOrderID(_ItemNo)
            Dim sampleData As Object()
            If _ID = 0 Then
                Dim sql As New SQLControl
                Dim Sqlstring As String
                Sqlstring = " INSERT INTO [dbo].[InternalOrdersReceviedWihoutSendItems]
           ([ItemNo],[ItemName],[ItemNo2])
            VALUES
           (" & _ItemNo & ",N'" & _ItemName & "',N'" & _ItemNo2 & "')"
                sql.SqlTrueAccountingRunQuery(Sqlstring)
                sampleData = {Nothing, DateTime.Now, _ItemNo, _ItemName, _ID, -1, _ItemNo2}
            Else
                ChangeQuantity(_ID)
                sampleData = {Nothing, DateTime.Now, _ItemNo, _ItemName, _ID, GetUnReceivedQuantity(_ItemNo), _ItemNo2}
            End If





            receivedItemsTable.Rows.Add(sampleData)
            receivedItemsTable.DefaultView.Sort = "Id DESC"

            txtBarcode.Text = ""
            txtBarcode.Select()
        End If
    End Sub

    Private Sub txtBarcode_EditValueChanged(sender As Object, e As EventArgs) Handles txtBarcode.EditValueChanged

    End Sub
    Dim receivedItemsTable As New DataTable("ReceivedItems")
    Sub CreateOrdersTable()
        ' Create a new DataTable


        ' Define the columns
        Dim idColumn As New DataColumn("Id", GetType(Integer))
        Dim receiveDateColumn As New DataColumn("ReceiveDate", GetType(DateTime))
        Dim itemNoColumn As New DataColumn("ItemNo", GetType(String))
        Dim itemNameColumn As New DataColumn("ItemName", GetType(String))
        Dim OrderID As New DataColumn("OrderID", GetType(Integer))
        Dim UnReceivedQuantity As New DataColumn("UnReceivedQuantity", GetType(Integer))
        Dim ItemNo2 As New DataColumn("ItemNo2", GetType(String))

        ' Add the columns to the DataTable
        receivedItemsTable.Columns.Add(idColumn)
        receivedItemsTable.Columns.Add(receiveDateColumn)
        receivedItemsTable.Columns.Add(itemNoColumn)
        receivedItemsTable.Columns.Add(itemNameColumn)
        receivedItemsTable.Columns.Add(OrderID)
        receivedItemsTable.Columns.Add(UnReceivedQuantity)
        receivedItemsTable.Columns.Add(ItemNo2)

        ' Optional: Set the Id column as auto-increment
        idColumn.AutoIncrement = True
        idColumn.AutoIncrementSeed = 1
        idColumn.AutoIncrementStep = 1

    End Sub
    Private Function GetUnReceivedQuantity(_ItemNo As Integer)
        Dim _Count As Integer = 0
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " select IsNull(sum(Quantity),0)-IsNull(sum(ReceivedQuantity),0) as Count from [InternalOrders] where ItemNo=" & _ItemNo
            If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                _Count = CInt(sql.SQLDS.Tables(0).Rows(0).Item("Count"))
            End If
        Catch ex As Exception
            _Count = 0
        End Try
        Return _Count
    End Function
    Private Sub InsertIntoPendingTable()

    End Sub
End Class