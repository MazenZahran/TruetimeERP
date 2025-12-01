' =========================
' Data Access Layer Interface
' =========================
Imports TrueTime.Security.Models

Namespace Security.Interfaces
    Public Interface IPermissionRepository
        Function GetUserByUsername(username As String) As User
        Function GetUserRoles(userID As Integer) As List(Of Role)
        Function GetRolePermissions(roleID As Integer) As List(Of RolePermission)
        Function GetAllRoles() As List(Of Role)
        Function GetAllModules() As List(Of [Module])
        Function GetAllPermissionTypes() As List(Of PermissionType)
        Function AssignRoleToUser(userID As Integer, roleID As Integer, assignedBy As Integer) As Boolean
        Function RemoveRoleFromUser(userID As Integer, roleID As Integer) As Boolean
        Function CreateRole(role As Role) As Integer
        Function UpdateRole(role As Role) As Boolean
        Function DeleteRole(roleID As Integer) As Boolean
        Function AssignPermissionToRole(roleID As Integer, moduleID As Integer, permissionTypeID As Integer) As Boolean
        Function RemovePermissionFromRole(rolePermissionID As Integer) As Boolean
        Sub LogAudit(auditLog As AuditLog)
    End Interface
End Namespace