' =========================
' Usage Example
' =========================
Imports TrueTime.Security.Models
Imports TrueTime.Security.Business
Imports TrueTime.Security.Data
Imports TrueTime.Security.Session
Imports TrueTime.Security.Attributes

Namespace Security.Examples
    Public Class ExampleUsage
        Public Shared Sub InitializeSystem()
            ' Initialize the system
            Dim connectionString = My.Settings.TrueTimeConnectionString
            Dim repository As New SqlPermissionRepository(connectionString)
            Dim permissionManager As New PermissionManager(repository)

            ' Login user
            Dim user = permissionManager.AuthenticateUser("john.doe", "password123")
            If user IsNot Nothing Then
                UserSession.Current.User = user
                UserSession.Current.PermissionManager = permissionManager

                ' Check permissions
                If UserSession.Current.HasPermission("HR", "READ") Then
                    Console.WriteLine("User can read HR data")
                End If

                If UserSession.Current.HasPermission("Salaries", "UPDATE") Then
                    Console.WriteLine("User can update salary data")
                End If

                ' Log an action
                UserSession.Current.LogAction("VIEW_EMPLOYEE", "HR", "EMP001")
            End If
        End Sub

        ' Example of method-level security
        <RequiresPermission("HR", "CREATE")>
        Public Sub CreateEmployee()
            ' Check permission before executing
            If Not UserSession.Current.HasPermission("HR", "CREATE") Then
                Throw New UnauthorizedAccessException("Insufficient permissions to create employee")
            End If

            ' Implementation here
            Console.WriteLine("Creating employee...")
            UserSession.Current.LogAction("CREATE_EMPLOYEE", "HR", "EMP002")
        End Sub
    End Class
End Namespace