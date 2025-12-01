Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports DevExpress.XtraEditors

Public Class DefaultsAccounts
    Private Sub DefaultsAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchLookUsers.Properties.DataSource = GetUsers(True)
        RepositoryAccounts.DataSource = GetFinancialAccounts(1, -1, False, -1, -1)
        GetCurrenciesAccounts()
        GetChecksInBox()
        RepositoryCheksIn.DataSource = GetFinancialAccounts(2, -1, False, -1, -1)
        Me.KeyPreview = True
        DefaultWhereHouse.Properties.DataSource = GetWharehouses(False)
        Me.DefaultWhereHouse.EditValue = GetDefaltWahreHouse(SearchLookUsers.EditValue)
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
        Me.LookCostCenter.EditValue = GetDefaultCostCenter(SearchLookUsers.EditValue)
    End Sub
    Private Sub Me_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveDate()
        End If
    End Sub
    Private Sub SaveDate()
        If SaveFinancialAccountsDefaultTable() = True And SaveInCheksTable() = True And SaveDefualtWahreHouse() = True And SaveDefualtCostCenter() = True Then
            MsgBoxShowSuccess(" تم حفظ البيانات ")
            Me.Close()
        End If
    End Sub
    Private Sub SearchUsers_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUsers.EditValueChanged
        GetCurrenciesAccounts()
        GetChecksInBox()
        Me.DefaultWhereHouse.EditValue = GetDefaltWahreHouse(SearchLookUsers.EditValue)
    End Sub
    Private Sub GetChecksInBox()
        Try
            If Not IsNothing(SearchLookUsers.EditValue) Then
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select IsNull(BB.ID,0) as ID,CurrID,Code,AccNo from
                                (Select CurrID,code from Currency ) AA
                                left join 
                                ( select ID,AccNo,CurrencyID  from  [dbo].[FinancialAccountsDefault]  where AccTypeID=2 and UserID=" & SearchLookUsers.EditValue & ") BB
                                 on AA.CurrID=BB.CurrencyID "
                sql.SqlTrueAccountingRunQuery(SqlString)
                If sql.SQLDS.Tables(0).Rows(0).Item("ID") <> 0 Then
                    GridControlCheqs.DataSource = sql.SQLDS.Tables(0)
                Else
                    SqlString = " Select 0 as ID,CurrID,Code,AccNo from
                                (Select CurrID,code from Currency ) AA
                                left join 
                                ( select ID,AccNo,CurrencyID  from  [dbo].[FinancialAccountsDefault]  where AccTypeID=2 and UserID=" & 1 & ") BB
                                 on AA.CurrID=BB.CurrencyID "
                    sql.SqlTrueAccountingRunQuery(SqlString)
                    GridControlCheqs.DataSource = sql.SQLDS.Tables(0)
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetCurrenciesAccounts()
        Try
            If Not IsNothing(SearchLookUsers.EditValue) Then
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select IsNull(BB.ID,0) as ID,CurrID,Code,AccNo from
                                (Select CurrID,code from Currency ) AA
                                left join 
                                ( select ID,AccNo,CurrencyID  from  [dbo].[FinancialAccountsDefault]  where AccTypeID=1 and UserID=" & SearchLookUsers.EditValue & ") BB
                                 on AA.CurrID=BB.CurrencyID "
                sql.SqlTrueAccountingRunQuery(SqlString)
                GridControlCash.DataSource = sql.SQLDS.Tables(0)

                If sql.SQLDS.Tables(0).Rows(0).Item("ID") <> 0 Then
                    GridControlCash.DataSource = sql.SQLDS.Tables(0)
                Else
                    SqlString = " Select 0 as ID,CurrID,Code,AccNo from
                                (Select CurrID,code from Currency ) AA
                                left join 
                                ( select ID,AccNo,CurrencyID  from  [dbo].[FinancialAccountsDefault]  where AccTypeID=1 and UserID=" & 1 & ") BB
                                 on AA.CurrID=BB.CurrencyID "
                    sql.SqlTrueAccountingRunQuery(SqlString)
                    GridControlCash.DataSource = sql.SQLDS.Tables(0)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveDate()
    End Sub
    Private Function SaveFinancialAccountsDefaultTable() As Boolean
        Dim _result As Boolean = True
        Dim i As Integer
        For i = 0 To GridView2.RowCount - 1
            If IsDBNull(Me.GridView2.GetRowCellValue(i, "AccNo")) Then Return False
            Dim AccNo As String = CStr(Me.GridView2.GetRowCellValue(i, "AccNo"))
            Dim CurrID As String = CStr(Me.GridView2.GetRowCellValue(i, "CurrID"))
            Dim ID As Integer = CInt(Me.GridView2.GetRowCellValue(i, "ID"))
            Select Case ID
                Case 0
                    Try
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Insert Into  FinancialAccountsDefault (AccTypeID,AccNo,UserID,CurrencyID)
                                        Values
                                       (1,'" & AccNo & "','" & SearchLookUsers.EditValue & "','" & CurrID & "')"
                        sql.SqlTrueAccountingRunQuery(SqlString)
                    Catch ex As Exception
                        MsgBoxShowError(" خطأ في حفظ الحسابات الافتراضية ")
                        _result = False
                    End Try
                Case > 0
                    Try
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Update FinancialAccountsDefault Set AccNo= '" & AccNo & "' Where ID=" & ID
                        sql.SqlTrueAccountingRunQuery(SqlString)
                    Catch ex As Exception
                        MsgBoxShowError(" خطأ في حفظ الحسابات الافتراضية ")
                        _result = False
                    End Try
            End Select
        Next
        GetCurrenciesAccounts()
        Return _result
    End Function
    Private Function SaveInCheksTable() As Boolean
        Dim _result As Boolean = True
        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(Me.GridView1.GetRowCellValue(i, "AccNo")) Then Return False
            Dim AccNo As String = CStr(Me.GridView1.GetRowCellValue(i, "AccNo"))
            Dim CurrID As String = CStr(Me.GridView1.GetRowCellValue(i, "CurrID"))
            Dim ID As Integer = CInt(Me.GridView1.GetRowCellValue(i, "ID"))
            Select Case ID
                Case 0
                    Try
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Insert Into  FinancialAccountsDefault (AccTypeID,AccNo,UserID,CurrencyID)
                                        Values
                                       (2,'" & AccNo & "','" & SearchLookUsers.EditValue & "','" & CurrID & "')"
                        sql.SqlTrueAccountingRunQuery(SqlString)
                    Catch ex As Exception
                        MsgBoxShowError(" خطأ في حفظ حسابات الشيكات الافتراضية ")
                        _result = False
                    End Try
                Case > 0
                    Try
                        Dim sql As New SQLControl
                        Dim SqlString As String
                        SqlString = " Update FinancialAccountsDefault Set AccNo= '" & AccNo & "' Where ID=" & ID
                        sql.SqlTrueAccountingRunQuery(SqlString)
                    Catch ex As Exception
                        MsgBoxShowError(" خطأ في حفظ حسابات الشيكات الافتراضية ")
                        _result = False
                    End Try
            End Select
        Next
        GetChecksInBox()
        Return _result
    End Function

    Private Function GetDefaltWahreHouse(UserId As Integer) As Integer
        Dim _result As Integer
        Try
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select DefaultWareHouse from [dbo].[EmployeesData] where [EmployeeID]=" & SearchLookUsers.EditValue
            Sql.SqlTrueAccountingRunQuery(sqlstring)
            _result = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("DefaultWareHouse"))
        Catch ex As Exception
            _result = 1
        End Try
        Return _result
    End Function
    Private Function SaveDefualtWahreHouse() As Boolean
        Dim _result As Boolean = True
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            If Not IsNothing(SearchLookUsers.EditValue) Then
                sqlstring = " Update [dbo].[EmployeesData]
                          Set [DefaultWareHouse]=" & DefaultWhereHouse.EditValue & " 
                          Where [EmployeeID]= " & SearchLookUsers.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
            End If
        Catch ex As Exception
            MsgBoxShowError(" خطا عند تحديد المستودع الافتراضي ")
            _result = False
        End Try
        Return _result
    End Function
    Private Function SaveDefualtCostCenter() As Boolean
        Dim _result As Boolean = True
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            If Not IsNothing(SearchLookUsers.EditValue) Then
                sqlstring = " Update [dbo].[EmployeesData]
                          Set [DefaultCostCenter]=" & LookCostCenter.EditValue & " 
                          Where [EmployeeID]= " & SearchLookUsers.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
            End If
        Catch ex As Exception
            MsgBoxShowError(" خطا في عملية حفظ مركز التكلفة الافتراضي ")
            _result = False
        End Try
        Return _result
    End Function
End Class