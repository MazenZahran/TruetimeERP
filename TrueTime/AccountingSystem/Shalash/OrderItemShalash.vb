Imports DevExpress.XtraEditors

Public Class OrderItemShalash


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        OrderItem(2)
    End Sub

    Private Sub OrderItemShalash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextQuantity.EditValue = 1
    End Sub
    Private Sub OrderItem(_type As Integer)
        If TextLastOrderd.EditValue > 0 Then
            MsgBoxShowError(" لا يمكن طلب الصنف يا " & GlobalVariables.EmployeeName & " " & " الصنف موجود في قائمة الطلبيات ")
            Exit Sub
        End If

        Dim ItemNo As Integer
        Dim ItemName As String
        Dim OrderedQuantity As Decimal
        Dim _ItemNo2 As String = ""
        'If IsDBNull(BandedGridView1.GetFocusedRowCellValue("StockID")) Then Exit Sub
        'If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemName")) Then Exit Sub
        'If IsDBNull(BandedGridView1.GetFocusedRowCellValue("InternalOrderd")) Then Exit Sub
        'If IsDBNull(BandedGridView1.GetFocusedRowCellValue("ItemNo2")) Then
        '    _ItemNo2 = ""
        'Else
        '    _ItemNo2 = BandedGridView1.GetFocusedRowCellValue("ItemNo2")
        'End If
        ItemNo = Me.ItemNo.Text
        _ItemNo2 = Me.ItemNo2.Text
        ItemName = Me.ItemName.Text
        OrderedQuantity = TextQuantity.EditValue

        If TextQuantity.EditValue > TextEditLastQuantity.EditValue Then
            If XtraMessageBox.Show(" لا يوجد كمية كافية للطلب  ", "تنبيه") Then
                Exit Sub
            End If
        End If

        If TextLastOrderd.EditValue > 0 Then
            If XtraMessageBox.Show(" يوجد كمية سابقة مطلوبة هل تريد الاستمرار ؟ ", "تنبيه", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If OrderedQuantity = 0 Then
            MsgBoxShowError(" الكمية صفر ")
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " INSERT INTO [dbo].[InternalOrders]
              ([ItemNo]
              ,[ItemName]
              ,[Quantity]
              ,[OrderDate]
              ,[OrderByUser]
              ,[Orderstatus],[OrderType],[ItemNo2],[WarehouseID])
        VALUES
              (" & ItemNo & "
              ,N'" & ItemName & "'
              ," & OrderedQuantity & "
              ,'" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "'
              ," & GlobalVariables.CurrUser & "
              ,0," & _type & ",' " & _ItemNo2 & "','" & TextWareHouse.EditValue & "') "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            '   XtraMessageBox.Show("تمت عملية الطلب بنجاح")
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        OrderItem(3)
    End Sub

    Private Sub ItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles ItemNo.EditValueChanged
        If ItemNo.Text = "" Then Exit Sub
        'Dim _itemdate = GetItemsData(ItemNo.EditValue, False)
        Dim repo As New ItemRepository()
        Dim item As ItemDetails = repo.GetItem(ItemNo.EditValue, "False")
        Me.ItemName.Text = item.ItemName
        Me.ItemBarcode.Text = item.UnitBarcode
        Me.ItemNo2.Text = item.ItemNo2
        GetLastOrderd()
    End Sub
    Private Sub GetLastOrderd()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "select IsNull(sum(Quantity),0) as Quantity  from [dbo].[InternalOrders] where [Orderstatus]=0 and ItemNo=" & ItemNo.EditValue & " And WarehouseID=" & TextWareHouse.EditValue & "; "
        sqlstring += "select top(1)  OrderDate from [dbo].[InternalOrders] where  ItemNo=" & ItemNo.EditValue & " AND  WarehouseID=" & TextWareHouse.EditValue & " order by id desc "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.TextLastOrderd.Text = sql.SQLDS.Tables(0).Rows(0).Item("Quantity")
        If sql.SQLDS.Tables(1).Rows.Count > 0 Then Me.TextLastDateOrderd.Text = sql.SQLDS.Tables(1).Rows(0).Item("OrderDate")
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        TextQuantity.EditValue = TextQuantity.EditValue + 1
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        TextQuantity.EditValue = TextQuantity.EditValue - 1
        If TextQuantity.EditValue <= 0 Then
            TextQuantity.EditValue = 1
            Exit Sub
        End If
    End Sub

    Private Sub TextLastOrderd_EditValueChanged(sender As Object, e As EventArgs) Handles TextLastOrderd.EditValueChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        OrderItem(4)
    End Sub
End Class