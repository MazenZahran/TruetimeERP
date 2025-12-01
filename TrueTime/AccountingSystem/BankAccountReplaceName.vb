Public Class BankAccountReplaceName
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.ComboBoxEdit1.Text <> "" And Me.TextEdit1.Text <> "" Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            Dim _OldAccountName As String = ComboBoxEdit1.Text
            Dim _NewAccountName As String = TextEdit1.Text
            sqlstring = " Update [dbo].[FinancialAccounts] 
                            Set [AccName] = ( SELECT REPLACE([AccName], N'" & _OldAccountName & "', N'" & _NewAccountName & "')  ) ; 
                          Update  [dbo].[BanksAccounts] 
                            Set [BankName] = ( SELECT REPLACE([BankName], N'" & _OldAccountName & "', N'" & _NewAccountName & "') ) "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                MsgBoxShowSuccess(" تم تغيير الاسم بنجاح ")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BankAccountReplaceName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ComboBoxEdit1.Text = ""
        Me.TextEdit1.Text = ""
    End Sub
End Class