Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DynamicallyConnectionString
    Public Class SqlHelper
        Private cn As SqlConnection

        Public Sub New(ByVal connectionString As String)
            cn = New SqlConnection(connectionString)
        End Sub

        Public ReadOnly Property IsConnection As Boolean
            Get
                If cn.State = System.Data.ConnectionState.Closed Then cn.Open()
                Return True
            End Get
        End Property
    End Class
End Namespace
