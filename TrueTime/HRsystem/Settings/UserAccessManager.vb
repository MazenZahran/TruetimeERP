Imports System.Data.SqlClient

Public Class UserAccessManager
    Private connectionString As String = My.Settings.TrueTimeConnectionString

    Public Class UserAccessName
        Public Property AccessNo As Integer
        Public Property AccessName As String
        Public Property AccessType As String
        Public Property Description As String
    End Class

    ' Class representing UsersAccess
    Public Class UserAccess
        Public Property ID As Integer
        Public Property AccessNo As Integer
        Public Property AccessValue As String
        Public Property AccessUser As String
    End Class
    Public Class UserAccessDetail
        Public Property AccessNo As Integer
        Public Property AccessName As String
        Public Property AccessType As String
        Public Property Description As String
        Public Property AccessValue As String
    End Class
    ' Get all access names
    Public Function GetAllAccessNames() As List(Of UserAccessName)
        Dim accessList As New List(Of UserAccessName)()
        Dim query As String = "SELECT AccessNo, AccessName, AccessType, Description FROM UsersAccessNames LEFT JOIN "

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        accessList.Add(New UserAccessName With {
                            .AccessNo = reader.GetInt32(0),
                            .AccessName = reader.GetString(1),
                            .AccessType = reader.GetString(2),
                            .Description = If(reader.IsDBNull(3), String.Empty, reader.GetString(3))
                        })
                    End While
                End Using
            End Using
        End Using

        Return accessList
    End Function

    Public Function GetUserAccess(accessUser As String) As List(Of UserAccessDetail)
        Dim userAccessList As New List(Of UserAccessDetail)()
        Dim query As String = "SELECT UAN.AccessNo, UAN.AccessName, UAN.AccessType, 
                                      UAN.Description, UA.AccessValue 
                               FROM UsersAccessNames UAN
                               LEFT JOIN UsersAccess UA ON UAN.AccessNo = UA.AccessNo 
                                    AND UA.AccessUser = @AccessUser"

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@AccessUser", accessUser)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        userAccessList.Add(New UserAccessDetail With {
                            .AccessNo = reader("AccessNo"),
                            .AccessName = reader("AccessName").ToString(),
                            .AccessType = reader("AccessType").ToString(),
                            .Description = If(reader.IsDBNull(reader.GetOrdinal("Description")), String.Empty, reader("Description").ToString()),
                            .AccessValue = If(reader.IsDBNull(reader.GetOrdinal("AccessValue")), "None", reader("AccessValue").ToString())
                        })
                    End While
                End Using
            End Using
        End Using

        Return userAccessList
    End Function
End Class
