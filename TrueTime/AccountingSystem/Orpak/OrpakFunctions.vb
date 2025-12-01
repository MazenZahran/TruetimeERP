Imports System.Data.SqlClient
Imports TrueTime.DynamicallyConnectionString
Module OrpakControl
    ' Public PosID As Integer = 1
    ' Public SqlOrpak As New SqlConnection With {.ConnectionString = GetOrpakConnectionString(PosID)._Cstring}
    'Public SqlCmd As SqlCommand
    'Public SQLDA As SqlDataAdapter
    'Public SQLDS As DataSet
    'Public Function SqlOrpak(PosID As Integer) As SqlConnection
    '    Dim SqlOrpak2 As New SqlConnection With {.ConnectionString = GetOrpakConnectionString(PosID)._Cstring}
    '    Return SqlOrpak2
    'End Function

    Public Function GetOrpakPos() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  ID, POSCode, POSName, CostCenter, BranchID, 
                                  Warehouse, ServerAddress, UseDirectProduction, SamabaPos
                                  FROM AccountingPOSNames 
                                  Where PosType=3"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
    End Function
    Public Function GetOrpakConnectionString(PosID As Integer) As (_Cstring As String, _IsConnection As Boolean)
        Dim _ConnectionString As String = ""
        Dim _IsCstring As Boolean = False
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  ServerAddress,TempAccounting,CostCenter
                                  FROM AccountingPOSNames 
                                  Where ID=" & PosID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _ConnectionString = sql.SQLDS.Tables(0).Rows(0).Item("ServerAddress")
            If Not String.IsNullOrEmpty(_ConnectionString) Then
                Try
                    Dim helper As SqlHelper = New SqlHelper(_ConnectionString)
                    If helper.IsConnection Then
                        _IsCstring = True
                    Else
                        _IsCstring = False
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    _IsCstring = False
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            _ConnectionString = ""
        End Try
        Return (_ConnectionString, _IsCstring)
    End Function
    Public Function ProductNameCase() As String
        Return "CASE WHEN product_name = '95' THEN N'بنزين95' 
                     WHEN product_name = '98' THEN N'بنزين98' 
                     WHEN product_name = 'Disel' THEN N'سولار' 
                     When product_name = 'Add Blue' then N'بلو' 
                     else product_name  END AS SotckName"
    End Function
    Public Function GetCardData(_CardID As Integer) As (_CardNo As String, _CardCode As String, _CardType As Integer, _CardID As Integer, _CardStatus As Integer,
                                                        _Plate As String, _LastUpdate As String, _IssueDate As String, _Rule As Integer, _RuleName As String,
                                                        _FleetName As String, _FleetType As Integer, _FleetStatus As Integer, _FleetBalance As Decimal,
                                                        _MonthNIS As Decimal, _MonthLit As Decimal, _FleetCode As String, _FleetID As Integer)

        Dim cardNo As String = "0", cardCode As String = "0",
            cardType As Integer = 0, cardID As Integer = 0,
            cardStatus As Integer = 0, plate As String = "0", lastUpdate As String = "1900-01-01",
            issueDate As String = "1900-01-01", rule As Integer = 0,
            ruleName As String = "0", fleetName As String = "0",
            fleetType As Integer = 0, fleetStatus As Integer = 0,
            fleetBalance As Decimal = 0, monthNIS As Decimal = 0,
            monthLit As Decimal = 0, fleetCode As String = "0", fleetID As Integer = 0


        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = "   select M.[name] as CardNo,[string] as CardCode,M.[type] as CardType,M.[id] As CardID,M.status as CardStatus,
	                                 M.hardware_type,M.plate ,M.update_timestamp,M.issued_date,M.[rule] ,G.[name] as RuleName,
		                             F.name as FleetName,F.acctyp as FleetType,F.status as FleetStatus,F.available_amount as FleetBalance,F.code as FleetCode,F.id as FleetID
                            from means M 
                            left join group_rules G on G.id=M.[rule]
                            left join Fleets F on M.fleet_id=F.id
                            where F.code<>'99999' and M.id=" & _CardID
        sql.SqlOrpakRunQuery(sqlstring, 1)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            With sql.SQLDS.Tables(0).Rows(0)
                cardNo = .Item("CardNo")
                cardCode = .Item("CardCode")
                cardType = .Item("CardType")
                cardID = .Item("CardID")
                cardStatus = .Item("CardStatus")
                plate = .Item("plate")
                lastUpdate = .Item("update_timestamp")
                issueDate = .Item("issued_date")
                rule = .Item("rule")
                ruleName = .Item("RuleName")
                fleetName = .Item("FleetName")
                fleetType = .Item("FleetType")
                fleetStatus = .Item("FleetStatus")
                fleetBalance = .Item("FleetBalance")
                fleetCode = .Item("FleetCode")
                fleetID = .Item("FleetID")
            End With
        End If


        sqlstring = " select IsNull(sum(sale),0) as MonthNIS,IsNull(sum(quantity),0) as MonthLit
                          from transactions 
                          where mean_name='" & _CardID & "' 
                          and DATEPART(YEAR,[date])=" & Format(Now, "yyyy") & " and DATEPART(Month,date)=" & Format(Now, "MM") & "  "
        sql.SqlOrpakRunQuery(sqlstring, 1)
        monthNIS = sql.SQLDS.Tables(0).Rows(0).Item("MonthNIS")
        monthLit = sql.SQLDS.Tables(0).Rows(0).Item("MonthLit")

        Return (cardNo, cardCode, cardType, cardID, cardStatus, plate, lastUpdate, issueDate, rule, ruleName, fleetName, fleetType, fleetStatus, fleetBalance, monthNIS, monthLit, fleetCode, fleetID)
    End Function
    Public Function GetOrpakGoupRules() As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   select id as RuleID ,name as RuleName,content_summary  from group_rules "
        sql.SqlOrpakRunQuery(sqlstring, 1)
        Return sql.SQLDS.Tables(0)
    End Function
    Public Function GetOrpakCardTransactions(_CardId As Integer) As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select [timestamp],pump,ppv,sale,quantity,tag,plate,product_name,fleet_code,fleet_name 
                      from transactions 
                      where mean_id=" & _CardId
        sql.SqlOrpakRunQuery(sqlstring, 1)
        Return sql.SQLDS.Tables(0)
    End Function
End Module
