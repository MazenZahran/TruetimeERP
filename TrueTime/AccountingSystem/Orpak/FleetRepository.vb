Imports System.Data.SqlClient
Imports Microsoft.Graph
Imports Microsoft.Office.Interop.Outlook

Public Class FleetRepository


    Public Sub AddFleet(ByVal fleet As Fleet)
        'TODO: Implement code to add customer to database'
    End Sub

    Public Sub UpdateFleet(ByVal fleet As Fleet)
        'TODO: Implement code to update customer in database'
    End Sub

    Public Sub DeleteFleet(ByVal fleetcode As Integer)
        'TODO: Implement code to delete customer from database'
    End Sub
    Public Function CheckIfFleetExist(fleetCode As Integer) As Boolean
        Dim _result As Boolean
        Dim sql As New SQLControl
        sql.SqlOrpakRunQuery(" select count(*) as count from fleets where code=" & fleetCode, 1)
        If sql.SQLDS.Tables(0).Rows(0).Item("count") = 0 Then
            _result = False
        Else
            _result = True
        End If
        Return _result
    End Function
    Public Function ChargeFleet(ByVal fleetID As Integer, PosNo As Integer, ByVal Amount As Decimal) As Boolean
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = "  BEGIN TRANSACTION
                                  SET DEADLOCK_PRIORITY HIGH
                                  Update fleets set available_amount='" & Amount & "',acctyp=1, update_timestamp=CURRENT_TIMESTAMP where id='" & fleetID & "';
                        COMMIT"
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetFleet(ByVal fleetID As Integer, ByVal PosNo As Integer) As Fleet
        Dim fleet As New Fleet()

        Using connection As New SqlConnection(GetOrpakConnectionString(PosNo)._Cstring)
            connection.Open()

            Dim query As String = "SELECT * FROM Fleets WHERE id = @ID And [status] in (1,2)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ID", fleetID)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.Read() Then
                fleet.ID = reader("id").ToString()
                fleet.fleetCode = Convert.ToInt32(reader("code"))
                fleet.FleetName = reader("name").ToString()
                fleet.Status = Convert.ToInt32(reader("status"))
                fleet.Mobile = reader("phone").ToString()
                fleet.Prepaid = reader("acctyp").ToString()
                fleet.Available_amount = Convert.ToInt32(reader("available_amount"))
                fleet.LastUpdate = Convert.ToString(reader("update_timestamp"))
                If reader("state") = "" Then
                    fleet.MonthlyVoucher = 0
                Else
                    fleet.MonthlyVoucher = Convert.ToInt32(reader("state"))
                End If
                If reader("zip") = "" Then
                    fleet.SendMessage = 0
                Else
                    fleet.SendMessage = Convert.ToInt32(reader("zip"))
                End If
                If reader("city") = "" Then
                    fleet.SmsWithBalance = 0
                Else
                    fleet.SmsWithBalance = Convert.ToInt32(reader("city"))
                End If
            End If

            reader.Close()
        End Using

        Return fleet
    End Function
    Public Function GetFleetByFleetCode(ByVal fleetCode As Integer, ByVal PosNo As Integer) As Fleet
        Dim fleet As New Fleet()

        Using connection As New SqlConnection(GetOrpakConnectionString(PosNo)._Cstring)
            connection.Open()

            Dim query As String = "SELECT * FROM Fleets WHERE code = @code and [status] in (1,2)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@code", fleetCode)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.Read() Then
                fleet.ID = reader("id").ToString()
                fleet.fleetCode = Convert.ToInt32(reader("code"))
                fleet.FleetName = reader("name").ToString()
                fleet.Status = Convert.ToInt32(reader("status"))
                fleet.Mobile = reader("phone").ToString()
                fleet.Prepaid = reader("acctyp").ToString()
                fleet.Available_amount = Convert.ToInt32(reader("available_amount"))
                fleet.LastUpdate = Convert.ToString(reader("update_timestamp"))
                If reader("state") = "" Then
                    fleet.MonthlyVoucher = 0
                Else
                    fleet.MonthlyVoucher = Convert.ToInt32(reader("state"))
                End If
                If reader("zip") = "" Then
                    fleet.SendMessage = 0
                Else
                    fleet.SendMessage = Convert.ToInt32(reader("zip"))
                End If
                If reader("city") = "" Then
                    fleet.SmsWithBalance = 0
                Else
                    fleet.SmsWithBalance = Convert.ToInt32(reader("city"))
                End If
            End If

            reader.Close()
        End Using

        Return fleet
    End Function
    Public Function GetFleetChargesLog(ByVal fleetID As Integer, ByVal PosNo As Integer) As DataTable
        Dim _table As New DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select * from [dbo].[OrpakFleetsChargeLog] where FleetID=" & fleetID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        _table = sql.SQLDS.Tables(0)
        Return _table
    End Function
    Public Function ActiveFleet(ByVal fleetID As Integer) As Boolean
        Dim _Result As Boolean
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " Update Fleets Set [status]=2 where [id]=" & fleetID
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            _Result = True
        Else
            _Result = False
        End If
        Return _Result
    End Function
    Public Function BlockFleet(ByVal fleetID As Integer) As Boolean
        Dim _Result As Boolean
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " Update Fleets Set [status]=1 where [id]=" & fleetID
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            _Result = True
        Else
            _Result = False
        End If
        Return _Result
    End Function
    Public Function GetMaxCode() As Integer
        Dim _MaxCode As Integer
        _MaxCode = 0
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " Select Max(code) as code from [dbo].[fleets] where code <> '99999' "
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            _MaxCode = sql.SQLDS.Tables(0).Rows(0).Item("code")
        Else
            _MaxCode = 0
        End If
        Return _MaxCode
    End Function
    Public Function DefaultDepForFleet(_fleetID As Integer) As Integer
        Dim _Dep As Integer = 0
        Dim sql As New SQLControl
        Dim sqlstring As String = " select top(1) id from depts where fleet_id=" & _fleetID
        If sql.SqlOrpakRunQuery(sqlstring, 1) = True Then
            _Dep = sql.SQLDS.Tables(0).Rows(0).Item("id")
        End If
        Return _Dep
    End Function
End Class
