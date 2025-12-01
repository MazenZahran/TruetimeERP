' =========================
' Data Access Layer Implementation
' =========================
Imports System.Data.SqlClient
Imports TrueTime.Security.Models
Imports TrueTime.Security.Interfaces

Namespace Security.Data
    Public Class SqlPermissionRepository
        Implements IPermissionRepository

        Private ReadOnly _connectionString As String

        Public Sub New(connectionString As String)
            _connectionString = connectionString
        End Sub

        Public Function GetUserByUsername(username As String) As User Implements IPermissionRepository.GetUserByUsername
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT UserID, UserName, PasswordHash, Email, IsActive, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM Users WHERE UserName = @username", conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return New User With {
                                .UserID = reader.GetInt32("UserID"),
                                .UserName = reader.GetString("UserName"),
                                .PasswordHash = reader.GetString("PasswordHash"),
                                .Email = If(reader.IsDBNull("Email"), Nothing, reader.GetString("Email")),
                                .IsActive = reader.GetBoolean("IsActive"),
                                .CreatedAt = reader.GetDateTime("CreatedAt"),
                                .CreatedBy = If(reader.IsDBNull("CreatedBy"), Nothing, reader.GetInt32("CreatedBy")),
                                .UpdatedAt = If(reader.IsDBNull("UpdatedAt"), Nothing, reader.GetDateTime("UpdatedAt")),
                                .UpdatedBy = If(reader.IsDBNull("UpdatedBy"), Nothing, reader.GetInt32("UpdatedBy"))
                            }
                        End If
                    End Using
                End Using
            End Using
            Return Nothing
        End Function

        Public Function GetUserRoles(userID As Integer) As List(Of Role) Implements IPermissionRepository.GetUserRoles
            Dim roles As New List(Of Role)
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Dim sql = "SELECT r.RoleID, r.RoleName, r.Description, r.CreatedAt, r.CreatedBy, r.UpdatedAt, r.UpdatedBy " &
                         "FROM Roles r INNER JOIN UserRoles ur ON r.RoleID = ur.RoleID " &
                         "WHERE ur.UserID = @userID"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            roles.Add(New Role With {
                                .RoleID = reader.GetInt32("RoleID"),
                                .RoleName = reader.GetString("RoleName"),
                                .Description = If(reader.IsDBNull("Description"), Nothing, reader.GetString("Description")),
                                .CreatedAt = reader.GetDateTime("CreatedAt"),
                                .CreatedBy = If(reader.IsDBNull("CreatedBy"), Nothing, reader.GetInt32("CreatedBy")),
                                .UpdatedAt = If(reader.IsDBNull("UpdatedAt"), Nothing, reader.GetDateTime("UpdatedAt")),
                                .UpdatedBy = If(reader.IsDBNull("UpdatedBy"), Nothing, reader.GetInt32("UpdatedBy"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return roles
        End Function

        Public Function GetRolePermissions(roleID As Integer) As List(Of RolePermission) Implements IPermissionRepository.GetRolePermissions
            Dim permissions As New List(Of RolePermission)
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Dim sql = "SELECT rp.RolePermissionID, rp.RoleID, rp.ModuleID, rp.PermissionTypeID, " &
                         "m.ModuleName, pt.PermissionCode " &
                         "FROM RolePermissions rp " &
                         "INNER JOIN Modules m ON rp.ModuleID = m.ModuleID " &
                         "INNER JOIN PermissionTypes pt ON rp.PermissionTypeID = pt.PermissionTypeID " &
                         "WHERE rp.RoleID = @roleID"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@roleID", roleID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            permissions.Add(New RolePermission With {
                                .RolePermissionID = reader.GetInt32("RolePermissionID"),
                                .RoleID = reader.GetInt32("RoleID"),
                                .ModuleID = reader.GetInt32("ModuleID"),
                                .PermissionTypeID = reader.GetInt32("PermissionTypeID"),
                                .ModuleName = reader.GetString("ModuleName"),
                                .PermissionCode = reader.GetString("PermissionCode")
                            })
                        End While
                    End Using
                End Using
            End Using
            Return permissions
        End Function

        Public Function GetAllRoles() As List(Of Role) Implements IPermissionRepository.GetAllRoles
            Dim roles As New List(Of Role)
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT RoleID, RoleName, Description, CreatedAt, CreatedBy, UpdatedAt, UpdatedBy FROM Roles ORDER BY RoleName", conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            roles.Add(New Role With {
                                .RoleID = reader.GetInt32("RoleID"),
                                .RoleName = reader.GetString("RoleName"),
                                .Description = If(reader.IsDBNull("Description"), Nothing, reader.GetString("Description")),
                                .CreatedAt = reader.GetDateTime("CreatedAt"),
                                .CreatedBy = If(reader.IsDBNull("CreatedBy"), Nothing, reader.GetInt32("CreatedBy")),
                                .UpdatedAt = If(reader.IsDBNull("UpdatedAt"), Nothing, reader.GetDateTime("UpdatedAt")),
                                .UpdatedBy = If(reader.IsDBNull("UpdatedBy"), Nothing, reader.GetInt32("UpdatedBy"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return roles
        End Function

        Public Function GetAllModules() As List(Of [Module]) Implements IPermissionRepository.GetAllModules
            Dim modules As New List(Of [Module])
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT ModuleID, ModuleName, Description FROM Modules ORDER BY ModuleName", conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            modules.Add(New [Module] With {
                                .ModuleID = reader.GetInt32("ModuleID"),
                                .ModuleName = reader.GetString("ModuleName"),
                                .Description = If(reader.IsDBNull("Description"), Nothing, reader.GetString("Description"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return modules
        End Function

        Public Function GetAllPermissionTypes() As List(Of PermissionType) Implements IPermissionRepository.GetAllPermissionTypes
            Dim permissionTypes As New List(Of PermissionType)
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("SELECT PermissionTypeID, PermissionCode, Description FROM PermissionTypes ORDER BY PermissionCode", conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            permissionTypes.Add(New PermissionType With {
                                .PermissionTypeID = reader.GetInt32("PermissionTypeID"),
                                .PermissionCode = reader.GetString("PermissionCode"),
                                .Description = If(reader.IsDBNull("Description"), Nothing, reader.GetString("Description"))
                            })
                        End While
                    End Using
                End Using
            End Using
            Return permissionTypes
        End Function

        Public Function AssignRoleToUser(userID As Integer, roleID As Integer, assignedBy As Integer) As Boolean Implements IPermissionRepository.AssignRoleToUser
            Try
                Using conn As New SqlConnection(_connectionString)
                    conn.Open()
                    Using cmd As New SqlCommand("INSERT INTO UserRoles (UserID, RoleID, AssignedAt, AssignedBy) VALUES (@userID, @roleID, SYSDATETIME(), @assignedBy)", conn)
                        cmd.Parameters.AddWithValue("@userID", userID)
                        cmd.Parameters.AddWithValue("@roleID", roleID)
                        cmd.Parameters.AddWithValue("@assignedBy", assignedBy)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As SqlException
                ' Handle duplicate key constraint
                Return False
            End Try
        End Function

        Public Function RemoveRoleFromUser(userID As Integer, roleID As Integer) As Boolean Implements IPermissionRepository.RemoveRoleFromUser
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("DELETE FROM UserRoles WHERE UserID = @userID AND RoleID = @roleID", conn)
                    cmd.Parameters.AddWithValue("@userID", userID)
                    cmd.Parameters.AddWithValue("@roleID", roleID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function CreateRole(role As Role) As Integer Implements IPermissionRepository.CreateRole
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("INSERT INTO Roles (RoleName, Description, CreatedAt, CreatedBy) OUTPUT INSERTED.RoleID VALUES (@roleName, @description, SYSDATETIME(), @createdBy)", conn)
                    cmd.Parameters.AddWithValue("@roleName", role.RoleName)
                    cmd.Parameters.AddWithValue("@description", If(role.Description, DBNull.Value))
                    cmd.Parameters.AddWithValue("@createdBy", If(role.CreatedBy, DBNull.Value))
                    Return CInt(cmd.ExecuteScalar())
                End Using
            End Using
        End Function

        Public Function UpdateRole(role As Role) As Boolean Implements IPermissionRepository.UpdateRole
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("UPDATE Roles SET RoleName = @roleName, Description = @description, UpdatedAt = SYSDATETIME(), UpdatedBy = @updatedBy WHERE RoleID = @roleID", conn)
                    cmd.Parameters.AddWithValue("@roleID", role.RoleID)
                    cmd.Parameters.AddWithValue("@roleName", role.RoleName)
                    cmd.Parameters.AddWithValue("@description", If(role.Description, DBNull.Value))
                    cmd.Parameters.AddWithValue("@updatedBy", If(role.UpdatedBy, DBNull.Value))
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Function DeleteRole(roleID As Integer) As Boolean Implements IPermissionRepository.DeleteRole
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        ' Remove role permissions first
                        Using cmd As New SqlCommand("DELETE FROM RolePermissions WHERE RoleID = @roleID", conn, trans)
                            cmd.Parameters.AddWithValue("@roleID", roleID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Remove user role assignments
                        Using cmd As New SqlCommand("DELETE FROM UserRoles WHERE RoleID = @roleID", conn, trans)
                            cmd.Parameters.AddWithValue("@roleID", roleID)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' Delete the role
                        Using cmd As New SqlCommand("DELETE FROM Roles WHERE RoleID = @roleID", conn, trans)
                            cmd.Parameters.AddWithValue("@roleID", roleID)
                            Dim result = cmd.ExecuteNonQuery() > 0
                            trans.Commit()
                            Return result
                        End Using
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        Public Function AssignPermissionToRole(roleID As Integer, moduleID As Integer, permissionTypeID As Integer) As Boolean Implements IPermissionRepository.AssignPermissionToRole
            Try
                Using conn As New SqlConnection(_connectionString)
                    conn.Open()
                    Using cmd As New SqlCommand("INSERT INTO RolePermissions (RoleID, ModuleID, PermissionTypeID) VALUES (@roleID, @moduleID, @permissionTypeID)", conn)
                        cmd.Parameters.AddWithValue("@roleID", roleID)
                        cmd.Parameters.AddWithValue("@moduleID", moduleID)
                        cmd.Parameters.AddWithValue("@permissionTypeID", permissionTypeID)
                        Return cmd.ExecuteNonQuery() > 0
                    End Using
                End Using
            Catch ex As SqlException
                ' Handle duplicate key constraint
                Return False
            End Try
        End Function

        Public Function RemovePermissionFromRole(rolePermissionID As Integer) As Boolean Implements IPermissionRepository.RemovePermissionFromRole
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("DELETE FROM RolePermissions WHERE RolePermissionID = @rolePermissionID", conn)
                    cmd.Parameters.AddWithValue("@rolePermissionID", rolePermissionID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        End Function

        Public Sub LogAudit(auditLog As AuditLog) Implements IPermissionRepository.LogAudit
            Using conn As New SqlConnection(_connectionString)
                conn.Open()
                Using cmd As New SqlCommand("INSERT INTO AuditLogs (UserID, Action, ModuleName, EntityID, ActionTime) VALUES (@userID, @action, @moduleName, @entityID, SYSDATETIME())", conn)
                    cmd.Parameters.AddWithValue("@userID", auditLog.UserID)
                    cmd.Parameters.AddWithValue("@action", auditLog.Action)
                    cmd.Parameters.AddWithValue("@moduleName", If(auditLog.ModuleName, DBNull.Value))
                    cmd.Parameters.AddWithValue("@entityID", If(auditLog.EntityID, DBNull.Value))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub
    End Class
End Namespace