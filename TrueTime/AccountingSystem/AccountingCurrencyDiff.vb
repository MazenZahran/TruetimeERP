Imports DevExpress.XtraEditors

Public Class AccountingCurrencyDiff
    Private DefaultCurrency As Integer = GetDefaultCurrency()
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetAccount()
    End Sub
    Private Sub GetAccount()
        If LookCurrency.Text = "" Then
            GridControl1.DataSource = Nothing
            MsgBoxShowError(" يجب اختيار عملة ")
            Exit Sub
        End If
        If Me.txtExchangeRate.Text = "" Then
            GridControl1.DataSource = Nothing
            Exit Sub
        End If
        If txtExchangeRate.Text = "0" Then
            GridControl1.DataSource = Nothing
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Declare @Rate float ; Declare @DocDate DateTime 
Set @Rate = " & Me.txtExchangeRate.EditValue & "
Set @DocDate = '" & Format(Me.DateDocDate.DateTime, "yyyy-MM-dd") & "' 
SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,
isnull(Debit,0) as Debit ,isnull(Credit,0) as Credit,
isnull(Debit,0)-isnull(Credit,0) as Balance,
IsNull(DebitBaseAmount,0) as DebitBaseAmount,
IsNull(CreditBaseAmount,0) as CreditBaseAmount,
Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0) as BalanceByAccCurr,
(Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0))*@Rate as NewBalance,
(Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0))*@Rate - (isnull(Debit,0)-isnull(Credit,0)) as diff
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts) t0
left join
(select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount from Journal where DocStatus <> 0 And DocDate <=@DocDate  group by DebitAcc) t1
	ON (t0.AccNo = t1.DebitAcc)
left JOIN
    (select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate <=@DocDate group by CredAcc) t2
ON (t0.AccNo = t2.CredAcc)
where  (Debit<>0 or Credit<>0) And t0.Currency=" & LookCurrency.EditValue & " And t0.Currency<>" & DefaultCurrency & " 
And  (Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0))*@Rate - (isnull(Debit,0)-isnull(Credit,0)) <>0 "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub AccountingCurrencyDiff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCurrencies()
        DateDocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
        LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
    End Sub
    Private Sub GetCurrencies()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select CurrID,Code from Currency where CurrID<>" & DefaultCurrency
        sql.SqlTrueTimeRunQuery(sqlstring)
        LookCurrency.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub AccountForRefranace_BeforePopup(sender As Object, e As EventArgs) Handles AccountForRefranace.BeforePopup
        AccountForRefranace.Properties.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SaveData()
    End Sub
    Private Sub SaveData()

        Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim JournalTable As New DataTable
        With JournalTable
            .Columns.Add("DocDate", GetType(DateTime))
            .Columns.Add("DocName", GetType(Integer))
            .Columns.Add("DocStatus", GetType(Integer))
            .Columns.Add("DocCostCenter", GetType(Integer))
            .Columns.Add("DebitAcc", GetType(String))
            .Columns.Add("CredAcc", GetType(String))
            .Columns.Add("AccountCurr", GetType(Integer))
            .Columns.Add("DocCurrency", GetType(Integer))
            .Columns.Add("DocAmount", GetType(Decimal))
            .Columns.Add("ExchangePrice", GetType(Decimal))
            .Columns.Add("BaseCurrAmount", GetType(Decimal))
            .Columns.Add("BaseAmount", GetType(Decimal))
            .Columns.Add("DocSort", GetType(Integer))
            .Columns.Add("Referance", GetType(String))
            .Columns.Add("DocManualNo", GetType(String))
            .Columns.Add("InputUser", GetType(Integer))
            .Columns.Add("InputDateTime", GetType(DateTime))
            .Columns.Add("DocNotes", GetType(String))
            .Columns.Add("ReferanceName", GetType(String))
            .Columns.Add("CurrentUserID", GetType(String))
            .Columns.Add("DocCode", GetType(String))
            .Columns.Add("DocNoteByAccount", GetType(String))
            .Columns.Add("OrderID", GetType(Integer))
        End With

        Dim _Referance As String = "0"

        Dim selectedRowHandles As Integer() = BandedGridView1.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError(" لم يتم اختيار حساب ")
            Exit Sub
        End If




        With BandedGridView1 ' 
            For i As Integer = 0 To selectedRowHandles.Length - 1
                If .GetRowCellValue(selectedRowHandles(i), "diff") < 0 Then
                    Dim R As DataRow = JournalTable.NewRow
                    R("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                    R("DocName") = 5
                    R("DebitAcc") = CStr(AccountForRefranace.EditValue)
                    R("CredAcc") = 0
                    Dim AccData = GetFinancialAccountsData(CStr(AccountForRefranace.EditValue))
                    R("AccountCurr") = AccData.Currency
                    R("DocCurrency") = DefaultCurrency
                    R("DocAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    R("DocCostCenter") = LookCostCenter.EditValue
                    R("ExchangePrice") = 1
                    R("BaseCurrAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    R("BaseAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    R("DocManualNo") = "0"
                    R("InputUser") = GlobalVariables.CurrUser
                    R("InputDateTime") = _Now
                    R("DocNotes") = DocNote.Text
                    R("Referance") = _Referance
                    R("ReferanceName") = ""
                    R("DocNoteByAccount") = ""
                    R("OrderID") = i
                    JournalTable.Rows.Add(R)

                    Dim RR As DataRow = JournalTable.NewRow
                    RR("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                    RR("DocName") = 5
                    RR("DebitAcc") = "0"
                    RR("CredAcc") = .GetRowCellValue(selectedRowHandles(i), "AccNo")
                    Dim AccData2 = GetFinancialAccountsData(RR("DebitAcc"))
                    RR("AccountCurr") = AccData2.Currency
                    RR("DocCurrency") = AccData2.Currency
                    RR("DocAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff")) / txtExchangeRate.EditValue
                    RR("DocCostCenter") = LookCostCenter.EditValue
                    RR("ExchangePrice") = 0
                    RR("BaseCurrAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    RR("BaseAmount") = 0
                    RR("DocManualNo") = "0"
                    RR("InputUser") = GlobalVariables.CurrUser
                    RR("InputDateTime") = _Now
                    RR("DocNotes") = DocNote.Text
                    RR("Referance") = _Referance
                    RR("ReferanceName") = ""
                    RR("DocNoteByAccount") = ""
                    RR("OrderID") = i
                    JournalTable.Rows.Add(RR)

                Else
                    Dim R As DataRow = JournalTable.NewRow
                    R("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                    R("DocName") = 5
                    R("DebitAcc") = .GetRowCellValue(selectedRowHandles(i), "AccNo")
                    R("CredAcc") = 0
                    Dim AccData = GetFinancialAccountsData(R("DebitAcc"))
                    R("AccountCurr") = AccData.Currency
                    R("DocCurrency") = AccData.Currency
                    R("DocAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff")) / txtExchangeRate.EditValue
                    R("DocCostCenter") = LookCostCenter.EditValue
                    R("ExchangePrice") = 0
                    R("BaseCurrAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    R("BaseAmount") = 0
                    R("DocManualNo") = "0"
                    R("InputUser") = GlobalVariables.CurrUser
                    R("InputDateTime") = _Now
                    R("DocNotes") = DocNote.Text
                    R("Referance") = _Referance
                    R("ReferanceName") = ""
                    R("DocNoteByAccount") = ""
                    R("OrderID") = i
                    JournalTable.Rows.Add(R)

                    Dim RR As DataRow = JournalTable.NewRow
                    RR("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                    RR("DocName") = 5
                    RR("DebitAcc") = "0"
                    RR("CredAcc") = CStr(AccountForRefranace.EditValue)
                    Dim AccData2 = GetFinancialAccountsData(CStr(AccountForRefranace.EditValue))
                    RR("AccountCurr") = AccData2.Currency
                    RR("DocCurrency") = DefaultCurrency
                    RR("DocAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    RR("DocCostCenter") = LookCostCenter.EditValue
                    RR("ExchangePrice") = 1
                    RR("BaseCurrAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    RR("BaseAmount") = Math.Abs(.GetRowCellValue(selectedRowHandles(i), "diff"))
                    RR("DocManualNo") = "0"
                    RR("InputUser") = GlobalVariables.CurrUser
                    RR("InputDateTime") = _Now
                    RR("DocNotes") = DocNote.Text
                    RR("Referance") = _Referance
                    RR("ReferanceName") = ""
                    RR("DocNoteByAccount") = ""
                    RR("OrderID") = i
                    JournalTable.Rows.Add(RR)

                End If




                If JournalTable.Rows.Count = 0 Then Exit Sub

                Dim _DocID As Integer = 0
                _DocID = GetDocNo(5, False)
                If _DocID = 0 Then
                    XtraMessageBox.Show("لا يمكن ترحيل السند: خطا برقم السند")
                    Exit Sub
                End If
                Dim _DocCode As String = CreateRandomCode()
                For Each row As DataRow In JournalTable.Rows
                    Dim Sql2 As New SQLControl
                    Dim SqlInsertDetials As String
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],DocCostCenter,[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(CDate(row("DocDate").ToString), "yyyy-MM-dd") & "', 
                                      '" & row("DocName").ToString & "', 
                                      '" & 4 & "',
                                      '" & row("DocCostCenter").ToString & "',
                                      '" & row("DebitAcc").ToString & "',
                                      '" & row("CredAcc").ToString & "',
                                      '" & row("AccountCurr").ToString & "',
                                      '" & row("DocCurrency").ToString & "',
                                      '" & row("DocAmount").ToString & "',
                                      '" & row("ExchangePrice").ToString & "',
                                      '" & row("BaseCurrAmount").ToString & "',
                                      '" & row("BaseAmount").ToString & "',
                                      '" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & row("InputUser").ToString & "',
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & _DocCode & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                        " & row("OrderID").ToString & "
                                            )"
                    If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        MsgBox("خطا بخظ السند")
                        DeleteFromJournalTemp(5, _DocCode)
                        Exit Sub
                    End If
                Next row


                If InsertFromTempToJournal(5, _DocID) = False Then
                    XtraMessageBox.Show("خطا بعملية الحفظ")
                    DeleteFromJournalTemp(5, _DocCode)
                    Exit Sub
                Else
                    DeleteFromJournalTemp(5, _DocCode)
                End If
                JournalTable.Clear()
                _DocCode = CreateRandomCode()
            Next
        End With

        GetAccount()

    End Sub

    Private Sub LookCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LookCurrency.EditValueChanged
        txtExchangeRate.EditValue = GetExchengPrice(LookCurrency.EditValue, Format(DateDocDate.DateTime, "yyyy-MM-dd")).SalesPrice
    End Sub

    Private Sub txtExchangeRate_EditValueChanged(sender As Object, e As EventArgs) Handles txtExchangeRate.EditValueChanged
        If Me.IsHandleCreated Then
            GetAccount()
        End If
    End Sub

    Private Sub txtExchangeRate_Leave(sender As Object, e As EventArgs) Handles txtExchangeRate.Leave

    End Sub
End Class