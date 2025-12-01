Imports System.Data.SqlClient

Public Class FinancialItems
    Public Property ItemNo As Integer
    Public Property ItemName As String
    Public Property ItemBarcode As String
    Public Property ItemPrice As Decimal
    Public Property ItemUnit As Integer
    Public Property ItemGroup As Integer

    Public Function InsertItemFromPos() As Integer
        Dim _result As Boolean
        Dim _ItemNo As Integer
        Dim _Item_Unit_ID As Integer
        Dim query As String = String.Empty
        Dim _ItemInsertResult As Boolean
        Dim _UnitInsertResult As Boolean
        _result = False
        query &= "INSERT INTO [Items] ("
        query &= "            [ItemNo],[ItemName],[Type],[HasExpireDate],ReOrderQuantity,notes, "
        query &= "            [AccSales],AccPurches,AccRetSales,AccRetPurches,     "
        query &= "            [CategoryID],TradeMarkID,GroupID,SaleOnScale,VisibleInAPP,ItemStatus,HasSerial,[classification])
                              OUTPUT Inserted.ItemNo "
        query &= "VALUES ( (select IsNull(max(ItemNo),0)+1 from Items), @ItemName, @Type,@HasExpireDate,@ReOrderQuantity,@notes, "
        query &= "         @AccSales,@AccPurches,@AccRetSales,@AccRetPurches,@CategoryID,@TradeMarkID,@GroupID,@SaleOnScale,"
        query &= "         @VisibleInAPP,@ItemStatus,@HasSerial,1)"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ItemName", ItemName)
                    .Parameters.AddWithValue("@Type", 0)
                    .Parameters.AddWithValue("@HasExpireDate", 0)
                    .Parameters.AddWithValue("@ReOrderQuantity", 0)
                    .Parameters.AddWithValue("@notes", "")
                    .Parameters.AddWithValue("@AccSales", "3000000000")
                    .Parameters.AddWithValue("@AccPurches", "4020000000")
                    .Parameters.AddWithValue("@AccRetSales", "3010000000")
                    .Parameters.AddWithValue("@AccRetPurches", "4030000000")
                    .Parameters.AddWithValue("@CategoryID", "0")
                    .Parameters.AddWithValue("@TradeMarkID", "0")
                    .Parameters.AddWithValue("@GroupID", ItemGroup)
                    .Parameters.AddWithValue("@SaleOnScale", "0")
                    .Parameters.AddWithValue("@VisibleInAPP", "1")
                    .Parameters.AddWithValue("@ItemStatus", "1")
                    .Parameters.AddWithValue("@HasSerial", "0")
                End With
                Try
                    conn.Open()
                    _ItemNo = comm.ExecuteScalar()
                    If _ItemNo > 0 Then
                        _ItemInsertResult = True
                    Else
                        _ItemInsertResult = False
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    _ItemInsertResult = False
                End Try


            End Using
        End Using

        query = ""
        If ItemBarcode = "0" Then
            ItemBarcode = _ItemNo & "000" & "1"
        End If
        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                If _ItemInsertResult = True Then
                    query = " Insert Into Items_units (item_id,unit_id,main_unit,EquivalentToMain,
                                                       item_unit_bar_code,Price1,Price2,Price3,IsUnit) 
                                                       OUTPUT Inserted.id  
                                                      VALUES 
                                                       (@item_id,@unit_id,@main_unit,@EquivalentToMain,
                                                        @item_unit_bar_code,@Price1,@Price2,@Price3,@IsUnit) "
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@item_id", _ItemNo)
                        .Parameters.AddWithValue("@unit_id", 1)
                        .Parameters.AddWithValue("@main_unit", 1)
                        .Parameters.AddWithValue("@EquivalentToMain", 1)
                        .Parameters.AddWithValue("@item_unit_bar_code", ItemBarcode)
                        .Parameters.AddWithValue("@Price1", ItemPrice)
                        .Parameters.AddWithValue("@Price2", ItemPrice)
                        .Parameters.AddWithValue("@Price3", ItemPrice)
                        .Parameters.AddWithValue("@IsUnit", 1)
                    End With
                    Try
                        conn.Open()
                        _Item_Unit_ID = comm.ExecuteScalar()
                        If _Item_Unit_ID > 0 Then
                            _UnitInsertResult = True
                        Else
                            _UnitInsertResult = False
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString(), "Error Message")
                        _UnitInsertResult = False
                    End Try
                End If
            End Using
        End Using

        If _UnitInsertResult = False Then
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" delete from Items where ItemNo=" & _ItemNo)
        End If

        If _ItemInsertResult = True And _UnitInsertResult = True Then
            Return _ItemNo
        Else
            Return 0
        End If
    End Function

    Private Sub DeleteItemOnError(_ItemNo As Integer)
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" delete from Items where ItemNo=" & _ItemNo)
    End Sub

End Class
