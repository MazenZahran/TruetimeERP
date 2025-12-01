' =========================
' Entity Models for Permission System
' =========================
Imports System.ComponentModel.DataAnnotations

Namespace Security.Models
    Public Class User
        Public Property UserID As Integer
        Public Property UserName As String
        Public Property PasswordHash As String
        Public Property Email As String
        Public Property IsActive As Boolean
        Public Property CreatedAt As DateTime
        Public Property CreatedBy As Integer?
        Public Property UpdatedAt As DateTime?
        Public Property UpdatedBy As Integer?
        Public Property Roles As List(Of Role) = New List(Of Role)
    End Class

    Public Class Role
        Public Property RoleID As Integer
        Public Property RoleName As String
        Public Property Description As String
        Public Property CreatedAt As DateTime
        Public Property CreatedBy As Integer?
        Public Property UpdatedAt As DateTime?
        Public Property UpdatedBy As Integer?
        Public Property Permissions As List(Of RolePermission) = New List(Of RolePermission)
    End Class

    Public Class UserRole
        Public Property UserRoleID As Integer
        Public Property UserID As Integer
        Public Property RoleID As Integer
        Public Property AssignedAt As DateTime
        Public Property AssignedBy As Integer?
    End Class

    Public Class [Module]
        Public Property ModuleID As Integer
        Public Property ModuleName As String
        Public Property Description As String
    End Class

    Public Class PermissionType
        Public Property PermissionTypeID As Integer
        Public Property PermissionCode As String
        Public Property Description As String
    End Class

    Public Class RolePermission
        Public Property RolePermissionID As Integer
        Public Property RoleID As Integer
        Public Property ModuleID As Integer
        Public Property PermissionTypeID As Integer
        Public Property ModuleName As String
        Public Property PermissionCode As String
    End Class

    Public Class AuditLog
        Public Property AuditLogID As Long
        Public Property UserID As Integer
        Public Property Action As String
        Public Property ModuleName As String
        Public Property EntityID As String
        Public Property ActionTime As DateTime
    End Class
End Namespace