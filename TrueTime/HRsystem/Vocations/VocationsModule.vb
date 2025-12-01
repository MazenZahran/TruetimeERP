Module VocationsModule
    'Public Function GetVocationsBalanceByEmployee(EmpID As String)
    '    Dim _GetVocationsBalanceByEmployee As Decimal
    '    Dim _AllAddningBalances As Decimal = 0
    '    Dim _AllVocations As Decimal = 0

    '    Try
    '        Dim SqlString As String
    '        Dim Sql As New SQLControl
    '        SqlString = " Select ISNULL(SUM(BalanceDays),0) AS AllAddningBalances 
    '                      From [VacationsBalancesAdding] where Employee='" & EmpID & "'"
    '        Sql.SqlTrueTimeRunQuery(SqlString)
    '        _AllAddningBalances = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("AllAddningBalances").ToString)
    '    Catch ex As Exception
    '        _AllAddningBalances = 0
    '        MsgBox(ex.ToString)
    '    End Try

    '    Try
    '        Dim SqlString As String
    '        Dim Sql As New SQLControl
    '        SqlString = " Select ISNULL(SUM(NoDays),0) AS AllVocations 
    '                      From [Vocations] where EmployeeID='" & EmpID & "'"
    '        Sql.SqlTrueTimeRunQuery(SqlString)
    '        _AllVocations = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("AllVocations").ToString)
    '    Catch ex As Exception
    '        _AllVocations = 0
    '        MsgBox(ex.ToString)
    '    End Try

    '    _GetVocationsBalanceByEmployee = _AllAddningBalances - _AllVocations
    '    Return _GetVocationsBalanceByEmployee

    'End Function
    Public Function GetSumAddingThisYear(EmpID) As String

        Dim _GetSumAddingThisYear As Decimal

        Try
            Dim sql As New SQLControl
            If EmpID IsNot Nothing And EmpID <> String.Empty And Not IsDBNull(EmpID) Then
                Dim SqlString As String = "Select SUM(BalanceDays) as SumDays from VacationsBalancesAdding where Employee =  " & EmpID &
                    "  and year(BalanceDate) = '" & Today.Year.ToString & "'"
                sql.SqlTrueTimeRunQuery(SqlString)

                If Sql.SQLDS.Tables(0).Rows(0).Item("SumDays") Is DBNull.Value Then
                    _GetSumAddingThisYear = 0
                Else
                    _GetSumAddingThisYear = Sql.SQLDS.Tables(0).Rows(0).Item("SumDays").ToString
                End If
            End If

        Catch ex As Exception
            _GetSumAddingThisYear = 0
        End Try
        Return _GetSumAddingThisYear
    End Function



End Module
