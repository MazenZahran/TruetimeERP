Module JardGlobalVariables
    Public _OpenJardFormAgain As Boolean

    Public Function GetJardDocumentData(DocID As Integer) As (EmployeeName As String, Warehouse As String)
        Dim _usrName As String = ""
        Dim _houseName As String = ""
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT J.ID,E.EmployeeName,DocDate,DocStatus,DocNote,DeviceName,S.ID as SessionID ,IsNull(W.WarehouseNameAR,'') As WarehouseNameAR ,S.SessionDetails
                        FROM [dbo].[JardJournalList] J
                        left join EmployeesData E on E.EmployeeID=J.UserID
                        left join JardSessions S on J.SessionID=S.ID
                        left join Warehouses W on W.WarehouseID=S.SessionWareHouse  "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            With sql.SQLDS.Tables(0).Rows(0)
                _usrName = .Item("EmployeeName")
                _houseName = .Item("WarehouseNameAR")
            End With
        End If
        Return (_usrName, _houseName)
    End Function
    Public Function GetSesssionData(_ID As Integer) As (Details As String, DocDate As String, WarehouseID As Integer, SessionStatus As Boolean, WarehouseIDName As String)
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select ID,SessionDetails,SessionStatus,SessionDate,SessionWareHouse,W.WarehouseNameAR as WarehouseName
                          from [JardSessions] S
                          left join Warehouses W on S.SessionWareHouse=W.WarehouseID 
                          where [ID]=" & _ID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                Return (.Item("SessionDetails"), Format(CDate(.Item("SessionDate")), "yyyy-MM-dd"), .Item("SessionWareHouse"), .Item("SessionStatus"), .Item("WarehouseName"))
            End With
        Catch ex As Exception
            Return ("0", "1900-01-01", 0, 0, 0)
        End Try
    End Function
End Module
