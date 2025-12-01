Public Class PivotTableCostCenters
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetData()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select J.[DocID], [DocDate], D.Name as DocName, DocName as DocNameValue, [DocStatus], c.CostName, [DebitAcc],
    [CredAcc], [AccountCurr], [DocAmount], [ExchangePrice], [BaseCurrAmount],
    U.Code as DocCurrency, J.DocCode,
    Case when CredAcc ='0'  then [BaseCurrAmount] else 0 end as CredAmount ,
    Case when DebitAcc ='0' then [BaseCurrAmount] else 0 end as DebitAmount  ,
    Case when DebitAcc ='0' then [BaseCurrAmount] else -[BaseCurrAmount] end as ToBaseAmount ,
    Case when CredAcc ='0' then AA.[AccName] else A.[AccName] end as Account  ,
    Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes
from Journal J
    left join FinancialAccounts A on A.AccNo = J.CredAcc
    left join FinancialAccounts AA on AA.AccNo = J.DebitAcc
    left join DocNames D on D.id = J.DocName
    left join DocSorts S on S.SortID = J.DocSort
    left join CostCenter C on C.CostID = J.DocCostCenter
    left join Currency U on U.CurrID=J.DocCurrency
where (A.FinancialStatment=2 or AA.FinancialStatment=2) and DocStatus > 0 and DocCostCenter <> 0
    and (DocDate between '2000-02-01' 
                            and '2100-02-14')
order by DocDate,DocID  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.PivotGridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub PivotTableCostCenters_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class