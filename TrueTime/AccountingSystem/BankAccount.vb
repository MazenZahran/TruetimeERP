Public Class BankAccount
    Private Sub BankAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Currency.Properties.DataSource = GetCurrency()
        BankID.Properties.DataSource = GetBanksTable()
        BranchID.Properties.DataSource = GetBanksBranches()

        BankDepositAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)
        BankOutChequeAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)
        BankCheqsTahselAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrEmpty(BankName.EditValue) Or IsNothing(BankDepositAccount.EditValue) Or
            IsNothing(BankCheqsTahselAccount.EditValue) Or IsNothing(BankOutChequeAccount.EditValue) Or
            String.IsNullOrEmpty(BankID.Text) Or String.IsNullOrEmpty(BranchID.Text) Or
            String.IsNullOrEmpty(BankAccID.Text) Or IsNothing(Currency.EditValue) Then
            MsgBox("يجب تعبئة كل الخانات المطلوبة")
            Exit Sub
        End If
        If TextID.EditValue = -1 Then
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " insert into BanksAccounts (ID,BankName,BankDepositAccount,BankOutChequeAccount,
                                BankCheqsTahselAccount,BankID,BranchID,BankAccID,Currency) values (
                                 " & Val(GetMax()) + 1 & ",N'" & BankName.EditValue & "','" & BankDepositAccount.EditValue & "',
                                 '" & BankOutChequeAccount.EditValue & "',
                                 '" & BankCheqsTahselAccount.EditValue & "',
                                 N'" & BankID.EditValue & "',
                                 N'" & BranchID.EditValue & "',
                                 N'" & BankAccID.EditValue & "',
                                 " & Currency.EditValue & "
                                )"
            sql.SqlTrueAccountingRunQuery(SqlString)
            Me.Dispose()
        Else
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Update BanksAccounts Set BankName= N'" & BankName.Text & "' , BankDepositAccount='" & BankDepositAccount.EditValue & "', 
                                                   BankOutChequeAccount='" & BankOutChequeAccount.EditValue & "' , BankCheqsTahselAccount='" & BankCheqsTahselAccount.EditValue & "',
                                                   BankID='" & BankID.EditValue & "',BranchID='" & BranchID.EditValue & "' ,BankAccID='" & BankAccID.EditValue & "' ,
                                                   Currency=" & Currency.EditValue & " Where ID=" & TextID.EditValue
            sql.SqlTrueAccountingRunQuery(SqlString)
            Me.Dispose()
        End If

    End Sub
    Private Function GetMax() As Integer
        Dim max As Integer
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select max(ID) as MaxID from BanksAccounts"
            sql.SqlTrueAccountingRunQuery(SqlString)
            max = sql.SQLDS.Tables(0).Rows(0).Item("MaxID")
        Catch ex As Exception
            max = 0
        End Try
        Return max

    End Function

    Private Sub Currency_EditValueChanged(sender As Object, e As EventArgs) Handles Currency.EditValueChanged
        If Not IsNothing(Currency) Then
            BankDepositAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)
            BankOutChequeAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)
            BankCheqsTahselAccount.Properties.DataSource = GetFinancialAccounts(-1, Currency.EditValue, True, -1, -1)
        End If

    End Sub

    Private Sub TextID_EditValueChanged(sender As Object, e As EventArgs) Handles TextID.EditValueChanged

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select  [BankName],[BankDepositAccount],[BankOutChequeAccount],[BankCheqsTahselAccount],
                                                   [UserID],[BankID],[BranchID],[BankAccID],[Currency]
                                            FROM [BanksAccounts] where ID= " & TextID.EditValue)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                BankName.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankName")
                BankDepositAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankDepositAccount")
                BankOutChequeAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankOutChequeAccount")
                BankCheqsTahselAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankCheqsTahselAccount")
                BankID.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankID")
                BranchID.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BranchID")
                BankAccID.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("BankAccID")
                Currency.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Currency")
            Else
                BankName.EditValue = 0
                BankDepositAccount.EditValue = 0
                BankOutChequeAccount.EditValue = 0
                BankCheqsTahselAccount.EditValue = 0
                BankID.EditValue = 0
                BranchID.EditValue = 0
                BankAccID.EditValue = 0
                Currency.EditValue = 0
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class