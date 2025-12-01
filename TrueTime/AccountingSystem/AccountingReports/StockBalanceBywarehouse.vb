Public Class StockBalanceBywarehouse
    Private Sub StockBalanceBywarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Warehouses.Properties.DataSource = GetWharehouses(True)
        DateDocDate.DateTime = Today
        Me.KeyPreview = True
        'If GlobalVariables._Shalash = True Then
        '    LayoutOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        'End If
    End Sub

    Private Sub LookUpEdit1_EditValueChanged(sender As Object, e As EventArgs)
        'GetBalance()
    End Sub
    Private Function GetBalance(_Warehouses As Integer, ItemBarcodeOrNumber As String)
        Dim _Balance As Decimal
        If String.IsNullOrEmpty(ItemBarcodeOrNumber) Then _Balance = 0
        Dim _DateDocDate As String
        _DateDocDate = Format(DateDocDate.DateTime, "yyyy-MM-dd")
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = "  Declare @WahreHouse Int 
                           Declare @ItemBarCode varchar(50);
                           Declare @ItemNo varchar(10);
                           Set @WahreHouse=" & _Warehouses
            If CheckSearchByItemNo.Checked = True Then
                SqlString += " Set @ItemNo ='" & ItemBarcodeOrNumber & "'"
            Else
                SqlString += " Set @ItemNo= (Select item_id  from Items_units where item_unit_bar_code='" & ItemBarcodeOrNumber & "')"
            End If
            SqlString += "  Select  [balance]
                           From (
                           Select Isnull(sum(case when    [StockDebitWhereHouse] = @WahreHouse then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  = @WahreHouse then [StockQuantityByMainUnit] end) ,0) as balance
                           FROM [Journal] J
                           where DocDate <= '" & _DateDocDate & "' and DocStatus<>0"
            SqlString += " And StockID =@ItemNo"
            SqlString += " And (StockDebitWhereHouse= @WahreHouse or StockCreditWhereHouse =@WahreHouse)  ) A"

            sql.SqlTrueAccountingRunQuery(SqlString)
            _Balance = sql.SQLDS.Tables(0).Rows(0).Item("balance")
        Catch ex As Exception
            _Balance = 0
        End Try
        Return _Balance
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        'GetBalance()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub TextStockID_EditValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Dim F3 As New ItemsSearchMenue
        With F3
            .TextFromForm.Text = Me.Name
            .ColOpen.Visible = False
            If .ShowDialog() <> DialogResult.OK Then
                TextStockID.Text = GlobalVariables._TempItemNo
            End If
        End With
    End Sub

    Private Sub TextStockID_EditValueChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckSearchByItemNo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSearchByItemNo.CheckedChanged
        Select Case CheckSearchByItemNo.Checked
            Case True
                LayoutControlItem4.Text = "رقم الصنف"
            Case False
                LayoutControlItem4.Text = "رقم الباركود"
        End Select
    End Sub

    Private Sub LayoutControlItem5_Click(sender As Object, e As EventArgs)
        Dim F3 As New ItemsSearchMenue
        With F3
            .TextFromForm.Text = Me.Name
            .ColOpen.Visible = False
            If .ShowDialog() <> DialogResult.OK Then
                TextStockID.Text = GlobalVariables._TempItemNo
            End If
        End With
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextStockID_EditValueChanged_2(sender As Object, e As EventArgs) Handles TextStockID.EditValueChanged

    End Sub
    Private Sub TextItemBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles TextStockID.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetBalanceByWareHouse()
        End If
    End Sub
    Public Sub GetBalanceByWareHouse()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _itemno2 As String = ""
        Dim _ItemNo As String = ""
        Select Case CheckSearchByItemNo.Checked
            Case True
                Try
                    SqlString = " Select [ItemName],ItemNo2,ItemNo from [dbo].[Items] where [ItemNo]= '" & TextStockID.Text & "'"
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")) Then
                        TextItemName.Text = Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
                        _itemno2 = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo2")
                        _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
                    End If
                Catch ex As Exception
                    TextItemName.Text = ""
                End Try
            Case False
                Try
                    SqlString = " Select [ItemName],ItemNo2,ItemNo
                                  from [dbo].[Items] I
                                  Left Join [Items_units] IU on I.[ItemNo]=IU.[item_id]
                                  where IU.[item_unit_bar_code]= '" & TextStockID.Text & "'"
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")) Then
                        TextItemName.Text = Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
                        _itemno2 = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo2")
                        _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
                    End If
                Catch ex As Exception
                    TextItemName.Text = ""
                    _itemno2 = ""
                End Try
        End Select


        Try
            GridControl1.DataSource = ""
            SqlString = " SELECT  [WarehouseID],[WarehouseNameAR],[IsDefault],0 as Balance,'' as ItemName,'' as ItemNo2,'' as ItemNo
                      FROM [dbo].[Warehouses]"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        For i = 0 To TileView1.RowCount - 1
            Dim _WareHouse As Integer
            _WareHouse = TileView1.GetRowCellValue(i, "WarehouseID")
            TileView1.SetRowCellValue(i, "Balance", GetBalance(_WareHouse, TextStockID.Text))
            TileView1.SetRowCellValue(i, "ItemName", TextItemName.Text)
            TileView1.SetRowCellValue(i, "ItemNo2", _itemno2)
            TileView1.SetRowCellValue(i, "ItemNo", _ItemNo)
        Next
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F3 As New ItemsSearchMenue
        With F3
            .TextFromForm.Text = Me.Name
            .ColOpen.Visible = False
            If .ShowDialog() <> DialogResult.OK Then
                TextStockID.Text = GlobalVariables._TempItemNo
                GetBalanceByWareHouse()
                TextStockID.Select()
            End If
        End With
    End Sub

    Private Sub DateDocDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateDocDate.EditValueChanged
        GetBalanceByWareHouse()
    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetBalanceByWareHouse()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.TileView1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        Dim F As New OrderItemShalash
        With F
            Dim _Balance As Decimal
            _Balance = CDec(Me.TileView1.GetFocusedRowCellValue("Balance"))
            If _Balance = 0 Then
                MsgBoxShowError(" لا يمكن طلب الصنف، الكمية صفر بالمستودع ")
                Exit Sub
            End If
            .ItemNo.EditValue = Me.TileView1.GetFocusedRowCellValue("ItemNo")
            .TextEditLastQuantity.EditValue = _Balance
            .ShowDialog()

        End With
    End Sub

    Private Sub TileView1_ItemDoubleClick(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs) Handles TileView1.ItemDoubleClick
        If GlobalVariables._WareHouseUseShelf = True Then
            Dim F As New OrderItemShalash
            With F
                Dim _Balance As Decimal
                _Balance = CDec(Me.TileView1.GetFocusedRowCellValue("Balance"))
                If _Balance = 0 Then
                    MsgBoxShowError(" لا يمكن طلب الصنف، الكمية صفر بالمستودع ")
                    Exit Sub
                End If
                .TextWareHouse.EditValue = Me.TileView1.GetFocusedRowCellValue("WarehouseID")
                .ItemNo.EditValue = Me.TileView1.GetFocusedRowCellValue("ItemNo")
                .TextEditLastQuantity.EditValue = _Balance
                Me.Close()
                .ShowDialog()

            End With
        End If
    End Sub
End Class