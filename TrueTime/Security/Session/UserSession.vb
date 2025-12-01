' =========================
' Session Manager
' =========================
Imports TrueTime.Security.Models
Imports TrueTime.Security.Business

Namespace Security.Session
    Public Class UserSession
        Private Shared _current As UserSession

        Public Shared Property Current As UserSession
            Get
                If _current Is Nothing Then
                    _current = New UserSession()
                End If
                Return _current
            End Get
            Set(value As UserSession)
                _current = value
            End Set
        End Property

        Public Property User As User
        Public Property PermissionManager As PermissionManager

        Public Function HasPermission(moduleName As String, permissionCode As String) As Boolean
            If User Is Nothing OrElse PermissionManager Is Nothing Then
                Return False
            End If
            Return PermissionManager.HasPermission(User.UserID, moduleName, permissionCode)
        End Function

        Public Sub LogAction(action As String, moduleName As String, Optional entityID As String = Nothing)
            If User IsNot Nothing AndAlso PermissionManager IsNot Nothing Then
                'PermissionManager._repository.LogAudit(New AuditLog With {
                '    .UserID = User.UserID,
                '    .Action = action,
                '    .ModuleName = moduleName,
                '    .EntityID = entityID
                '})
            End If
        End Sub
    End Class
End Namespace