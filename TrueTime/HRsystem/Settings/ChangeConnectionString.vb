Imports System.Configuration
Imports System.Data.SqlClient
Imports TrueTime.DynamicallyConnectionString

Public Class ChangeConnectionString
    Private Sub ChangeConnectionString_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboServer.Items.Add(".")
        cboServer.Items.Add("(local)")
        cboServer.Items.Add(".\SQLEXPRESS")
        cboServer.Items.Add(String.Format("{0}\SQLEXPRESS", Environment.MachineName))
        'cboServer.SelectedIndex = 3

        Try
            Dim MyDBConnection As String = ConfigurationManager.ConnectionStrings(Me.ConnectionName.Text).ConnectionString
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim connectionString As String = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text)

        Try
            Dim helper As SqlHelper = New SqlHelper(connectionString)
            If helper.IsConnection Then MessageBox.Show("Test connection succeeded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SaveChanges()
        ' Application.Exit()
    End Sub
    Private Sub SaveChanges()
        Dim connectionString As String = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text)

        Try
            Dim helper As SqlHelper = New SqlHelper(connectionString)

            If helper.IsConnection Then
                Dim setting As AppSetting = New AppSetting()
                setting.SaveConnectionString(ConnectionName.Text, connectionString)
                MessageBox.Show("Your connection string has been successfully saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class