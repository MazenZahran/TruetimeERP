Imports DevExpress.XtraEditors

Public Class AccountAddNew
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [AccNo] from [dbo].[FinancialAccounts] where AccNo='" & TextAccNo.EditValue & "'")
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("AccNo")) Then
                MsgBox("الحساب موجود لا يمكن الحفظ")
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            Dim _AccName As String
            Dim _FinancialStatment, _AccNo As String
            Dim _FinancialSector, _Currency, _AccType As Integer
            Dim _FatherAccount As String
            _AccNo = TextAccNo.EditValue
            _AccName = TextAccName.Text
            _FinancialStatment = CInt(FinancialStatment.EditValue)
            _FinancialSector = CInt(FinancialSector.EditValue)
            _Currency = CInt(Currency.EditValue)
            _AccType = SearchAccType.EditValue
            _FatherAccount = TextFatherAccName.EditValue

            SqlString = " Insert Into FinancialAccounts (AccNo, AccName, Currency, FinancialStatment, FinancialSector, AccType, FatherAccount)
            Values ('" & _AccNo & "',N'" & _AccName & "'," & _Currency & "," & _FinancialStatment & "," & _FinancialSector & "," & _AccType & ",'" & _FatherAccount & "' )  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            XtraMessageBox.Show("تم تعريف الحساب بنجاح")
            Me.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AccountAddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Currency.Properties.DataSource = GetCurrency()
        GetFinancialSectors()
        GetFinancialStatementNames()
        SearchAccType.Properties.DataSource = GetAccTypes(-1)
        TextFatherAccName.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
    End Sub
    Private Sub GetFinancialSectors()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [SectorID],[SectorName]
  FROM [FinancialParts] S
  left join [FinancialStatementNames] N on S.[FinancialStatmentID]=N.ID"

        sql.SqlTrueAccountingRunQuery(SqlString)
        FinancialSector.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub GetFinancialStatementNames()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select [ID],[FinancialStatementName] From [FinancialStatementNames]  "
        sql.SqlTrueAccountingRunQuery(SqlString)
        FinancialStatment.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class