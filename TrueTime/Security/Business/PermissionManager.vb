' =========================
' Business Logic Layer
' =========================
Imports TrueTime.Security.Models
Imports TrueTime.Security.Interfaces

Namespace Security.Business
    Public Class PermissionManager
        Private ReadOnly _repository As IPermissionRepository
        Private ReadOnly _userPermissionsCache As New Dictionary(Of Integer, List(Of String))

        Public Sub New(repository As IPermissionRepository)
            _repository = repository
        End Sub

        Public Function AuthenticateUser(username As String, password As String) As User
            Dim user = _repository.GetUserByUsername(username)
            If user IsNot Nothing AndAlso user.IsActive AndAlso VerifyPassword(password, user.PasswordHash) Then
                ' Load user roles
                user.Roles = _repository.GetUserRoles(user.UserID)
                Return user
            End If
            Return Nothing
        End Function

        Public Function HasPermission(userID As Integer, moduleName As String, permissionCode As String) As Boolean
            Dim userPermissions = GetUserPermissions(userID)
            Dim permissionKey = $"{moduleName}:{permissionCode}"
            Return userPermissions.Contains(permissionKey)
        End Function

        Public Function GetUserPermissions(userID As Integer) As List(Of String)
            If _userPermissionsCache.ContainsKey(userID) Then
                Return _userPermissionsCache(userID)
            End If

            Dim permissions As New List(Of String)
            Dim userRoles = _repository.GetUserRoles(userID)

            For Each role In userRoles
                Dim rolePermissions = _repository.GetRolePermissions(role.RoleID)
                For Each permission In rolePermissions
                    Dim permissionKey = $"{permission.ModuleName}:{permission.PermissionCode}"
                    If Not permissions.Contains(permissionKey) Then
                        permissions.Add(permissionKey)
                    End If
                Next
            Next

            _userPermissionsCache(userID) = permissions
            Return permissions
        End Function

        Public Sub ClearUserCache(userID As Integer)
            If _userPermissionsCache.ContainsKey(userID) Then
                _userPermissionsCache.Remove(userID)
            End If
        End Sub

        Public Function AssignRoleToUser(userID As Integer, roleID As Integer, assignedBy As Integer) As Boolean
            Dim result = _repository.AssignRoleToUser(userID, roleID, assignedBy)
            If result Then
                ClearUserCache(userID)
                _repository.LogAudit(New AuditLog With {
                    .UserID = assignedBy,
                    .Action = "ASSIGN_ROLE",
                    .ModuleName = "UserManagement",
                    .EntityID = $"UserID:{userID},RoleID:{roleID}"
                })
            End If
            Return result
        End Function

        Public Function RemoveRoleFromUser(userID As Integer, roleID As Integer, removedBy As Integer) As Boolean
            Dim result = _repository.RemoveRoleFromUser(userID, roleID)
            If result Then
                ClearUserCache(userID)
                _repository.LogAudit(New AuditLog With {
                    .UserID = removedBy,
                    .Action = "REMOVE_ROLE",
                    .ModuleName = "UserManagement",
                    .EntityID = $"UserID:{userID},RoleID:{roleID}"
                })
            End If
            Return result
        End Function

        Public Function CreateRole(roleName As String, description As String, createdBy As Integer) As Integer
            Dim role As New Role With {
                .RoleName = roleName,
                .Description = description,
                .CreatedBy = createdBy
            }

            Dim roleID = _repository.CreateRole(role)
            If roleID > 0 Then
                _repository.LogAudit(New AuditLog With {
                    .UserID = createdBy,
                    .Action = "CREATE_ROLE",
                    .ModuleName = "RoleManagement",
                    .EntityID = $"RoleID:{roleID}"
                })
            End If
            Return roleID
        End Function

        Public Function AssignPermissionToRole(roleID As Integer, moduleID As Integer, permissionTypeID As Integer, assignedBy As Integer) As Boolean
            Dim result = _repository.AssignPermissionToRole(roleID, moduleID, permissionTypeID)
            If result Then
                ' Clear cache for all users with this role
                ClearCacheForRole(roleID)
                _repository.LogAudit(New AuditLog With {
                    .UserID = assignedBy,
                    .Action = "ASSIGN_PERMISSION",
                    .ModuleName = "RoleManagement",
                    .EntityID = $"RoleID:{roleID},ModuleID:{moduleID},PermissionTypeID:{permissionTypeID}"
                })
            End If
            Return result
        End Function

        Private Sub ClearCacheForRole(roleID As Integer)
            ' This is a simplified approach - in a real application, you might want to
            ' track which users have which roles to avoid clearing all cache
            _userPermissionsCache.Clear()
        End Sub

        Private Function VerifyPassword(password As String, hash As String) As Boolean
            ' Implement your password verification logic here
            ' This is a placeholder - use proper password hashing like BCrypt
            Return hash = HashPassword(password)
        End Function

        Private Function HashPassword(password As String) As String
            ' Implement your password hashing logic here
            ' This is a placeholder - use proper password hashing like BCrypt
            Using sha256 As System.Security.Cryptography.SHA256 = System.Security.Cryptography.SHA256.Create()
                Dim hashedBytes As Byte() = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                Return Convert.ToBase64String(hashedBytes)
            End Using
        End Function

        ' Utility methods
        Public Function GetAllRoles() As List(Of Role)
            Return _repository.GetAllRoles()
        End Function

        Public Function GetAllModules() As List(Of [Module])
            Return _repository.GetAllModules()
        End Function

        Public Function GetAllPermissionTypes() As List(Of PermissionType)
            Return _repository.GetAllPermissionTypes()
        End Function

        Public Function GetRolePermissions(roleID As Integer) As List(Of RolePermission)
            Return _repository.GetRolePermissions(roleID)
        End Function
    End Class
End Namespace