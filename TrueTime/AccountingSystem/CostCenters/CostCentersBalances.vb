Public Class CostCentersBalances
    Private Sub CostCentersBalances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEditTo.DateTime = Today
        Me.DateEditFrom.DateTime = New Date(Today.Year, 1, 1)
        Me.KeyPreview = True
        Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
        ' Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup4
        SrchCostCenterType.Properties.DataSource = GetCostCentersType(True)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        '  Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
        Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup4
        GetData()
        GetPivotData()
        Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
        ' Me.TabbedControlGroup1.SelectedTabPage = LayoutControlGroup4
    End Sub
    Private Sub GetData()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   Declare @DateFrom date;Set @DateFrom='" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "'
                        Declare @DateTo date;set @DateTo ='" & Format(Me.DateEditTo.DateTime, "yyyy-MM-dd") & "'
                        select CostID, CostName, IsNull(expenses,0) as Expenses, IsNull(revenue,0) as Revenue, (IsNull(revenue,0) -IsNull(expenses,0)) As Balance
                        from
                            ( select CostID, CostName
                            from CostCenter  ) A
                            left join
                            (select DocCostCenter , IsNull(Sum([BaseCurrAmount]),0)  as expenses
                            from Journal J
                                left join FinancialAccounts A on A.AccNo = J.CredAcc
                                left join FinancialAccounts AA on AA.AccNo = J.DebitAcc
                            where (A.FinancialStatment=2 or AA.FinancialStatment=2) and DocStatus > 0
                                and (DocDate between @DateFrom 
                                                    and @DateTo) and DocCostCenter <>0 and CredAcc ='0'
                            group by DocCostCenter,J.CredAcc ) B
                            on A.CostID=B.DocCostCenter
                            left join
                            ( select DocCostCenter , IsNull(Sum([BaseCurrAmount]),0)  as revenue
                            from Journal J
                                left join FinancialAccounts A on A.AccNo = J.CredAcc
                                left join FinancialAccounts AA on AA.AccNo = J.DebitAcc
                            where (A.FinancialStatment=2 or AA.FinancialStatment=2) and DocStatus > 0
                                and (DocDate between @DateFrom 
                                                    and @DateTo) and DocCostCenter <>0 and DebitAcc ='0'
                            group by DocCostCenter,J.DebitAcc ) C
                            on A.CostID=C.DocCostCenter "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub GetPivotData()
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
    and (DocDate between '" & Format(Me.DateEditFrom.DateTime, "yyyy-MM-dd") & "' 
                            and '" & Format(Me.DateEditTo.DateTime, "yyyy-MM-dd") & "')
order by DocDate,DocID  "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.PivotGridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        GridControl1.ShowPrintPreview()
    End Sub
End Class