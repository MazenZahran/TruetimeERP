Public Class PosDeletedItems
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub

    Private Sub PosDeletedItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt
        Me.KeyPreview = True
        GetUsers()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub

    Private Sub RefreshData()

        Dim FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm")
        Dim ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm")

        GridControl1.DataSource = Nothing
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select DocAmount,[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
                                 [StockPrice],[StockDiscount],[DeleteUser],[DeleteDateTime],[DocCode],[ItemName],[StockBarcode],E.EmployeeName,ShiftID
                          FROM [dbo].[POSDeletedJournal] P
                               Left join  [dbo].[EmployeesData] E on P.[DeleteUser] = E.EmployeeID 
                          Where  [DeleteDateTime]  between '" & FromDate & "' and '" & ToDate & "'"

            If SearchEmployees.EditValue IsNot Nothing Then
                SqlString += " And DeleteUser ='" & SearchEmployees.EditValue & "'"
            End If

            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        GridView1.BestFitColumns()
    End Sub
    Private Sub GetUsers()
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " Select distinct [DeleteUser] as EmployeeID, [EmployeeName] 
                                    from [dbo].[POSDeletedJournal] P 
                                    left join  [dbo].[EmployeesData] E on P.[DeleteUser] = E.EmployeeID "
            sql.SqlTrueAccountingRunQuery(SqlString)
            SearchEmployees.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        SearchLookUpEdit1View.BestFitColumns()
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoFit.CheckedChanged
        If CheckAutoFit.Checked = True Then
            GridView1.OptionsView.ColumnAutoWidth = True
        Else
            GridView1.OptionsView.ColumnAutoWidth = False
        End If
        GridView1.BestFitColumns()
    End Sub
End Class