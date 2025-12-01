Imports DevExpress.XtraEditors

Public Class InternalOrderItemQuantityFromItemBalance
    Public _OrderID As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _vendor As Integer
        If Me.Referance.Text <> "" Then
            _vendor = Referance.EditValue
        Else
            _vendor = 0
        End If
        If _vendor = 0 Then
            MsgBoxShowError(" يجب اختيار المورد ")
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        If GetOrderdQuantity(TextItemNo.EditValue) = 0 Then
            sqlstring = " INSERT INTO [dbo].[OrderProcessing]
           ([ItemNo]
           ,[ItemName]
           ,[Quantity]
           ,[OrderDate]
           ,[OrderByUser]
           ,[Orderstatus],[Vendor],OrderType)
     VALUES
           (" & TextItemNo.Text & "
           ,N'" & TextItemName.Text & "'
           ," & Me.TextOrderQuantity.EditValue & "
           ,'" & Format(Now, "yyyy-MM-dd HH:mm") & "'
           ," & GlobalVariables.CurrUser & "
           ,0," & _vendor & ",1 ) "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                sql.SqlTrueAccountingRunQuery(" Update Items Set Vendor=" & _vendor & " where  ItemNo=" & TextItemNo.Text)
                Me.Close()
            End If
        Else
            sqlstring = " Update OrderProcessing
                          Set Quantity=" & Me.TextOrderQuantity.EditValue & " ,
                          Vendor=" & _vendor & "  
                          Where ItemNo=" & Me.TextItemNo.EditValue
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                sql.SqlTrueAccountingRunQuery(" Update Items Set Vendor=" & _vendor & " where  ItemNo=" & TextItemNo.Text)
                Me.Close()
            End If
        End If
        GlobalVariables._OrderedQuantity = Me.TextOrderQuantity.EditValue

    End Sub

    Private Sub InternalOrderItemQuantityFromItemBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
        Me.TextOrderQuantity.Select()
    End Sub

    Private Sub TextItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemNo.EditValueChanged
        If TextItemNo.Text <> "" Then
            Dim _orderdetails = GetOrderDetails(TextItemNo.Text)
            Me.TextQinimumQuantity.EditValue = _orderdetails._Minimun
            Me.TextMaximumQuantity.EditValue = _orderdetails._Maximum
            If _OrderID = 0 Then
                Me.Referance.EditValue = _orderdetails._Vendor
            Else
                Dim sql As New SQLControl
                sql.SqlTrueAccountingRunQuery(" select Vendor from OrderProcessing where ID=" & _OrderID)
                Me.Referance.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("Vendor")
            End If
            If _orderdetails._Maximum > TextCurrentBalance.EditValue Then Me.TextOrderQuantity.EditValue = _orderdetails._Maximum - TextCurrentBalance.EditValue
            Me.TextOrderQuantity.EditValue = GetOrderdQuantity(TextItemNo.EditValue)
        End If
    End Sub


    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup

    End Sub
    Private Function GetOrderdQuantity(_ItemNo As Integer) As Decimal
        Dim _quantity As Decimal = 0
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select IsNull(sum(Quantity),0) as Quantity from OrderProcessing where Orderstatus=0  And ItemNo=" & _ItemNo
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _quantity = sql.SQLDS.Tables(0).Rows(0).Item("Quantity")
        End If
        Return _quantity
    End Function

End Class