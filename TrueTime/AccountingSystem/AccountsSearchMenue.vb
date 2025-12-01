Public Class AccountsSearchMenue
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim ItemsTable As New DataTable
        Dim ItemsTable2 As New DataTable
        ItemsTable.Columns.Add("RefNo", GetType(String))
        ItemsTable.Columns.Add("DebitAmount", GetType(Decimal))
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim R As DataRow = ItemsTable.NewRow
            R("RefNo") = GridView1.GetRowCellValue(selectedRowHandles(i), "RefNo")
            R("DebitAmount") = 1
            ItemsTable.Rows.Add(R)
        Next
        Dim _View As New DataView(ItemsTable) With {
            .Sort = "RefNo"
        }
        Dim newTable As DataTable = _View.ToTable("RefNo")
        GlobalVariables._ItemsTable = newTable
        Me.Close()
    End Sub

    Private Sub AccountsSearchMenue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetAccounts()
    End Sub
    Private Sub GetAccounts()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select RefNo,AccNo,AccName,AccType,Currency,Code As CurrCode From (
Select CONVERT(NVARCHAR(20), RefNo) as RefNo ,RefAccID  as [AccNo],RefName as [AccName], 'Ref' As AccType,F.Currency as  Currency
from Referencess R Left Join FinancialAccounts F on F.AccNo=R.RefAccID
Union
SELECT CONVERT(NVARCHAR(20), [AccNo]) as RefNo, [AccNo] ,[AccName], 'Acc' As AccType,Currency
FROM [dbo].[FinancialAccounts] Where IsMain =0 
) A
Left Join 
(Select CurrID,Code from Currency ) B
on A.Currency=B.CurrID
order by RefNo"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
    End Sub
End Class