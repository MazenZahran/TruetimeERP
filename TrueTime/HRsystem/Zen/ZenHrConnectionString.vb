Imports System.Configuration
Imports System.Data.SqlClient
Imports TrueTime.DynamicallyConnectionString
Public Class ZenHrConnectionString
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim connectionString As String = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text)
        Try
            Dim helper As SqlHelper = New SqlHelper(connectionString)
            If helper.IsConnection Then
                If UpdateConnectionString(connectionString) = True Then
                    MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Function UpdateConnectionString(_string) As Boolean
        Dim _result As Boolean = False
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update Settings Set SettingValue='" & _string & "' where SettingName='AlqudsCigConnection'"
        If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
            _result = True
        End If
        Return True
    End Function

    Private Sub ZenHrConnectionString_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim _ConnectionName As String
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select SettingValue from Settings where SettingName='AlqudsCigConnection'"
        sql.SqlTrueTimeRunQuery(sqlstring)
        _ConnectionName = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Try
            Dim MyDBConnection As String = _ConnectionName
            Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(MyDBConnection)
            Dim UserID As String = builder.UserID
            Dim Password As String = builder.Password
            Dim ServerName As String = builder.DataSource
            Dim DatabaseName As String = builder.InitialCatalog
            cboServer.Text = ServerName
            Me.txtDatabase.Text = DatabaseName
            Me.txtUsername.Text = UserID
            Me.txtPassword.Text = Password
        Catch ex As Exception

        End Try

    End Sub
    Private Sub SaveChanges()

    End Sub
End Class