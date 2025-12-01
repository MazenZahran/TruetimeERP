Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class CostCenterClass
    ' Properties map to your table columns
    Public Property CostID As Integer
    Public Property CostName As String
    Public Property CostCenterTypeID As Integer?
    Public Property CostCenterImage As Byte()
    Public Property StartDate As Date?
    Public Property EndDate As Date?
    Public Property Notes As String
    Public Property CostCenterStatus As Boolean?
    Public Property CompletionRate As Integer?
    Public Property Supplier As Integer?

    Private Shared ReadOnly connectionString As String =
       My.Settings.TrueTimeConnectionString

    ' Create (INSERT) - returns the new CostID
    Public Function Create() As Integer
        Dim newId As Integer
        Dim sql As String = "
            INSERT INTO dbo.CostCenter
                (CostName, CostCenterTypeID, CostCenterImage, StartDate, EndDate, Notes, CostCenterStatus, CompletionRate, Supplier)
            VALUES
                (@CostName, @CostCenterTypeID, @CostCenterImage, @StartDate, @EndDate, @Notes, @CostCenterStatus, @CompletionRate, @Supplier);
            SELECT CAST(SCOPE_IDENTITY() AS INT);"

        Using conn As New SqlConnection(connectionString),
              cmd As New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@CostName", CostName)
            cmd.Parameters.AddWithValue("@CostCenterTypeID", If(CostCenterTypeID.HasValue, CType(CostCenterTypeID.Value, Object), DBNull.Value))

            ' Explicitly set binary type to avoid NVARCHAR inference for NULLs
            If CostCenterImage IsNot Nothing Then
                Dim imgParam As SqlParameter = cmd.Parameters.Add("@CostCenterImage", SqlDbType.VarBinary)
                imgParam.Value = CostCenterImage
            Else
                cmd.Parameters.Add("@CostCenterImage", SqlDbType.VarBinary).Value = DBNull.Value
            End If

            cmd.Parameters.AddWithValue("@StartDate", If(StartDate.HasValue, CType(StartDate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@EndDate", If(EndDate.HasValue, CType(EndDate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@Notes", If(Notes IsNot Nothing, Notes, DBNull.Value))
            cmd.Parameters.AddWithValue("@CostCenterStatus", If(CostCenterStatus.HasValue, CType(CostCenterStatus.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@CompletionRate", If(CompletionRate.HasValue, CType(CompletionRate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@Supplier", If(Supplier.HasValue, CType(Supplier.Value, Object), DBNull.Value))

            conn.Open()
            newId = Convert.ToInt32(cmd.ExecuteScalar())
        End Using

        Return newId
    End Function

    ' Read single (SELECT by PK)
    Public Shared Function [Get](ByVal id As Integer) As CostCenterClass
        Dim result As CostCenterClass = Nothing
        Dim sql As String = "
            SELECT CostID, CostName, CostCenterTypeID, CostCenterImage, StartDate, EndDate, Notes, CostCenterStatus, CompletionRate, Supplier
            FROM dbo.CostCenter
            WHERE CostID = @CostID;"

        Using conn As New SqlConnection(connectionString),
              cmd As New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@CostID", id)
            conn.Open()

            Using rdr As SqlDataReader = cmd.ExecuteReader()
                If rdr.Read() Then
                    result = New CostCenterClass() With {
                        .CostID = Convert.ToInt32(rdr("CostID")),
                        .CostName = rdr("CostName").ToString(),
                        .CostCenterTypeID = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterTypeID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CostCenterTypeID"))),
                        .CostCenterImage = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterImage")), Nothing, CType(rdr("CostCenterImage"), Byte())),
                        .StartDate = If(rdr.IsDBNull(rdr.GetOrdinal("StartDate")), CType(Nothing, Date?), Convert.ToDateTime(rdr("StartDate"))),
                        .EndDate = If(rdr.IsDBNull(rdr.GetOrdinal("EndDate")), CType(Nothing, Date?), Convert.ToDateTime(rdr("EndDate"))),
                        .Notes = If(rdr.IsDBNull(rdr.GetOrdinal("Notes")), Nothing, rdr("Notes").ToString()),
                        .CostCenterStatus = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterStatus")), CType(Nothing, Boolean?), Convert.ToBoolean(rdr("CostCenterStatus"))),
                        .CompletionRate = If(rdr.IsDBNull(rdr.GetOrdinal("CompletionRate")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CompletionRate"))),
                        .Supplier = If(rdr.IsDBNull(rdr.GetOrdinal("Supplier")), CType(Nothing, Integer?), Convert.ToInt32(rdr("Supplier")))
                    }
                End If
            End Using
        End Using

        Return result
    End Function

    ' Read all (SELECT *)
    Public Shared Function GetAll() As List(Of CostCenterClass)
        Dim list As New List(Of CostCenterClass)()
        Dim sql As String = "
            SELECT CostID, CostName, CostCenterTypeID, CostCenterImage, StartDate, EndDate, Notes, CostCenterStatus, CompletionRate, Supplier
            FROM dbo.CostCenter;"

        Using conn As New SqlConnection(connectionString),
              cmd As New SqlCommand(sql, conn)

            conn.Open()
            Using rdr As SqlDataReader = cmd.ExecuteReader()
                While rdr.Read()
                    list.Add(New CostCenterClass() With {
                        .CostID = Convert.ToInt32(rdr("CostID")),
                        .CostName = rdr("CostName").ToString(),
                        .CostCenterTypeID = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterTypeID")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CostCenterTypeID"))),
                        .CostCenterImage = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterImage")), Nothing, CType(rdr("CostCenterImage"), Byte())),
                        .StartDate = If(rdr.IsDBNull(rdr.GetOrdinal("StartDate")), CType(Nothing, Date?), Convert.ToDateTime(rdr("StartDate"))),
                        .EndDate = If(rdr.IsDBNull(rdr.GetOrdinal("EndDate")), CType(Nothing, Date?), Convert.ToDateTime(rdr("EndDate"))),
                        .Notes = If(rdr.IsDBNull(rdr.GetOrdinal("Notes")), Nothing, rdr("Notes").ToString()),
                        .CostCenterStatus = If(rdr.IsDBNull(rdr.GetOrdinal("CostCenterStatus")), CType(Nothing, Boolean?), Convert.ToBoolean(rdr("CostCenterStatus"))),
                        .CompletionRate = If(rdr.IsDBNull(rdr.GetOrdinal("CompletionRate")), CType(Nothing, Integer?), Convert.ToInt32(rdr("CompletionRate"))),
                        .Supplier = If(rdr.IsDBNull(rdr.GetOrdinal("Supplier")), CType(Nothing, Integer?), Convert.ToInt32(rdr("Supplier")))
                    })
                End While
            End Using
        End Using

        Return list
    End Function

    ' Update (UPDATE by PK) - returns True if rows affected > 0
    ' Update (UPDATE by PK) - returns True if rows affected > 0
    Public Function Update() As Boolean
        Dim rows As Integer
        Dim sql As String = "
        UPDATE dbo.CostCenter
        SET CostName            = @CostName,
            CostCenterTypeID    = @CostCenterTypeID,
            CostCenterImage     = @CostCenterImage,
            StartDate           = @StartDate,
            EndDate             = @EndDate,
            Notes               = @Notes,
            CostCenterStatus    = @CostCenterStatus,
            CompletionRate      = @CompletionRate,
            Supplier            = @Supplier
        WHERE CostID = @CostID;"

        Using conn As New SqlConnection(connectionString),
          cmd As New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@CostID", CostID)
            cmd.Parameters.AddWithValue("@CostName", CostName)
            cmd.Parameters.AddWithValue("@CostCenterTypeID", If(CostCenterTypeID.HasValue, CType(CostCenterTypeID.Value, Object), DBNull.Value))

            ' Fix for image data type
            If CostCenterImage IsNot Nothing Then
                Dim param As SqlParameter = cmd.Parameters.Add("@CostCenterImage", SqlDbType.VarBinary)
                param.Value = CostCenterImage
            Else
                cmd.Parameters.Add("@CostCenterImage", SqlDbType.VarBinary).Value = DBNull.Value
            End If

            cmd.Parameters.AddWithValue("@StartDate", If(StartDate.HasValue, CType(StartDate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@EndDate", If(EndDate.HasValue, CType(EndDate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@Notes", If(Notes IsNot Nothing, Notes, DBNull.Value))
            cmd.Parameters.AddWithValue("@CostCenterStatus", If(CostCenterStatus.HasValue, CType(CostCenterStatus.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@CompletionRate", If(CompletionRate.HasValue, CType(CompletionRate.Value, Object), DBNull.Value))
            cmd.Parameters.AddWithValue("@Supplier", If(Supplier.HasValue, CType(Supplier.Value, Object), DBNull.Value))

            conn.Open()
            rows = cmd.ExecuteNonQuery()
        End Using

        Return (rows > 0)
    End Function


    ' Delete (DELETE by PK) - returns True if rows affected > 0
    Public Shared Function Delete(ByVal id As Integer) As Boolean
        Dim rows As Integer
        Dim sql As String = "DELETE FROM dbo.CostCenter WHERE CostID = @CostID;"

        Using conn As New SqlConnection(connectionString),
              cmd As New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@CostID", id)
            conn.Open()
            rows = cmd.ExecuteNonQuery()
        End Using

        Return (rows > 0)
    End Function
End Class
