Public Class InternalAuditLogs
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        getData()
    End Sub
    Private Sub getData()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   select L.ID,L.InputDateTime,L.OrderID,O.ItemNo,O.ItemNo2,O.ItemName,O.ReceivedQuantity
                        from [InternalOrdersReceiveLogs] L
                        left Join InternalOrders O on O.ID=L.OrderID  "
        sql.SqlTrueTimeRunQuery(sqlstring)
        GridControlRececiedLogs.DataSource = sql.SQLDS.Tables(0)

        sqlstring = " select * from  [InternalOrdersReceviedWihoutSendItems] "
        sql.SqlTrueTimeRunQuery(sqlstring)
        GridControlItemsWithoutOrder.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub InternalAuditLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class