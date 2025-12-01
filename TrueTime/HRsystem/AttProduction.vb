Public Class AttProduction
    Dim sql As New SQLControl
    Dim sqlstring As String
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetData()
        Try
            sqlstring = " SELECT S.[Id],[Date_],S.[EmployeeID],E.[EmployeeName] ,[From_],[To_],[Quantity],[Service_Name],[Note],[ManagerNote],[HrNotes],[status],[x],[y],[Entry_date],[Path]  
FROM [dbo].[SalaryByProduction] S
Left Join EmployeesData E on S.EmployeeID=E.EmployeeID  "
            sql.SqlTrueTimeRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        GridView1.BestFitColumns()
    End Sub

    Private Sub AttProduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub
End Class