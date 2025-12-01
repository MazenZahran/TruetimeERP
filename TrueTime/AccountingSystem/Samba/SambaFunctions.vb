Module SambaFunctions
    Public Function GetSambaBranches() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  ID, POSCode, POSName, CostCenter, BranchID, 
                                  Warehouse, ServerAddress, UseDirectProduction, SamabaPos
                                  FROM AccountingPOSNames 
                                  Where PosType=2"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
    End Function
    Public Function CheckSambaItemNameExists(_Name As String, _BranchID As Integer) As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " select COUNT(*) As count FROM [dbo].[MenuItems] WHERE [Name]=N'" & _Name & "'"
            If sql.SqlPosRunQuery(sqlstring, _BranchID) = True Then
                If sql.SQLDS.Tables(0).Rows(0).Item("count") > 0 Then
                    result = True
                Else
                    result = False
                End If
            End If
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function
End Module
