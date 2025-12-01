Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DynamicallyConnectionString
    Public Class AppSetting
        Private config As Configuration

        Public Sub New()
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        End Sub

        Public Function GetConnectionString(ByVal key As String) As String
            Return config.ConnectionStrings.ConnectionStrings(key).ConnectionString
        End Function

        Public Sub SaveConnectionString(ByVal key As String, ByVal value As String)
            config.ConnectionStrings.ConnectionStrings(key).ConnectionString = value
            config.ConnectionStrings.ConnectionStrings(key).ProviderName = "System.Data.SqlClient"
            config.Save(ConfigurationSaveMode.Modified)
        End Sub
    End Class
End Namespace
