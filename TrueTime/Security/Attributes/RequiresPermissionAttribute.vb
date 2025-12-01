' =========================
' Authorization Attribute (for method-level security)
' =========================
Namespace Security.Attributes
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Class)>
    Public Class RequiresPermissionAttribute
        Inherits Attribute

        Public ReadOnly Property ModuleName As String
        Public ReadOnly Property PermissionCode As String

        Public Sub New(moduleName As String, permissionCode As String)
            Me.ModuleName = moduleName
            Me.PermissionCode = permissionCode
        End Sub
    End Class
End Namespace