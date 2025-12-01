Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class FinancialAccount
    Public Property AccountNo As String
    Public Property AccountName As String
    Public Property Currency As Integer
    Public Property FatherAccount As String
    Public Property FinancialStatment As Integer
    Public Property FinancialSector As Integer
    Public Property AccType As Integer
    Public Property IsMain As Boolean
    Public Property IsActive As Boolean
    Public Property HasTrans As Boolean
    Public Property FatherAccountName As String
    Public Property CurrencyCode As String
    Public Property NeedCostCenter As Boolean



    Public Function GetAccountData(AccountNo As String) As Boolean
        Dim query As String = String.Empty
        Dim sql As New SQLControl
        query &= " Select F.[AccNo] As AccNo ,F.[AccName] As AccName,F.[Currency] As Currency,F.[FinancialStatment] As FinancialStatment ,
                   F.[FinancialSector] As FinancialSector ,F.[AccType] As AccType ,F.[FatherAccount] As FatherAccount,F.[IsActive] As IsActive,
		           FF.AccName As FatherName,C.Code As CurrencyCode,
                   Case when F.NeedCostCenter =1 then 'True' else 'False' end as NeedCostCenter
                   FROM [dbo].[FinancialAccounts] F
		           left Join [dbo].[FinancialAccounts]  FF on F.FatherAccount=FF.AccNo
                   left join [dbo].[Currency] C on C.CurrID=F.Currency
                   Where F.[AccNo]  ='" & AccountNo & "'"
        Try
            sql.SqlTrueAccountingRunQuery(query)
            With sql.SQLDS.Tables(0).Rows(0)
                Me.AccountNo = .Item("AccNo")
                Me.AccountName = .Item("AccName")
                Me.Currency = .Item("Currency")
                Me.FinancialStatment = .Item("FinancialStatment")
                Me.FinancialSector = .Item("FinancialSector")
                Me.AccType = .Item("AccType")
                If Not IsDBNull(.Item("FatherAccount")) Then Me.FatherAccount = .Item("FatherAccount")
                Me.IsActive = .Item("IsActive")
                If Not IsDBNull(.Item("FatherName")) Then Me.FatherAccountName = .Item("FatherName")
                Me.CurrencyCode = .Item("CurrencyCode")
                Me.HasTrans = CheckHasTrans(.Item("AccNo"))
                Me.NeedCostCenter = .Item("NeedCostCenter")
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function InsertAccount()
        Dim query As String = String.Empty
        query &= "INSERT INTO [FinancialAccounts] ("
        query &= "            [AccNo],[AccName],[Currency],[FinancialStatment], "
        query &= "            [FinancialSector],[AccType],[FatherAccount],[IsActive],NeedCostCenter )  "
        query &= "VALUES ( @AccNo, @AccName, @Currency,@FinancialStatment, "
        query &= "         @FinancialSector,@AccType,@FatherAccount,@IsActive,@NeedCostCenter)"
        If IsNothing(Me.FatherAccount) Then
            Me.FatherAccount = ""
        End If
        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@AccNo", Me.AccountNo)
                    .Parameters.AddWithValue("@AccName", Me.AccountName)
                    .Parameters.AddWithValue("@Currency", Me.Currency)
                    .Parameters.AddWithValue("@FinancialStatment", Me.FinancialStatment)
                    .Parameters.AddWithValue("@FinancialSector", Me.FinancialSector)
                    .Parameters.AddWithValue("@AccType", Me.AccType)
                    .Parameters.AddWithValue("@FatherAccount", Me.FatherAccount)
                    .Parameters.AddWithValue("@IsActive", Me.IsActive)
                    .Parameters.AddWithValue("@NeedCostCenter", Me.NeedCostCenter)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    Return False
                End Try
            End Using
        End Using
    End Function
    Public Function UpdateAccount(AccountNo As String) As Boolean
        Dim query As String = String.Empty
        query &= "Update [FinancialAccounts] Set "
        query &= "                           AccName=@AccName, "
        query &= "                           Currency=@Currency,FinancialStatment=@FinancialStatment, "
        query &= "                           FinancialSector=@FinancialSector  ,AccType=@AccType, "
        query &= "                           FatherAccount=@FatherAccount,     IsActive=@IsActive, NeedCostCenter=@NeedCostCenter where AccNo='" & AccountNo & "'"
        If IsNothing(Me.FatherAccount) Then
            Me.FatherAccount = ""
        End If
        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@AccName", Me.AccountName)
                    .Parameters.AddWithValue("@Currency", Me.Currency)
                    .Parameters.AddWithValue("@FinancialStatment", Me.FinancialStatment)
                    .Parameters.AddWithValue("@FinancialSector", Me.FinancialSector)
                    .Parameters.AddWithValue("@AccType", Me.AccType)
                    .Parameters.AddWithValue("@FatherAccount", Me.FatherAccount)
                    .Parameters.AddWithValue("@IsActive", Me.IsActive)
                    .Parameters.AddWithValue("@NeedCostCenter", Me.NeedCostCenter)
                End With
                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function CheckHasTrans(AccountNo As String) As Boolean
        Dim _HasTrans As Boolean = False
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select top(1) ID from [dbo].[Journal] where [DebitAcc]= '" & AccountNo & "' or [CredAcc]='" & AccountNo & "' And DocStatus<>0"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ID")) Then
                _HasTrans = False
            Else
                _HasTrans = True
            End If
        Catch ex As Exception
            _HasTrans = False
        End Try
        Return _HasTrans
    End Function
    Public Function DeleteAccount(AccountNo As String) As Boolean
        Try
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Delete FROM [dbo].[FinancialAccounts] 
                          Where AccNo ='" & AccountNo & "'"
            If Sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function IsFatherAccount(AccountNo) As Boolean
        Dim _Count As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select IsNull(Count(FatherAccount),0) As Counts 
                          from [dbo].[FinancialAccounts] 
                          where FatherAccount='" & AccountNo & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Count = sql.SQLDS.Tables(0).Rows(0).Item("Counts")
        Catch ex As Exception
            _Count = 0
        End Try
        If _Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
Public Module FinanicialAccountsVariable
    Public IsInserted As Boolean
    Public IsDeleted As Boolean
    Public IsUpdated As Boolean
    Public AccountNo As String
End Module


