Imports MySqlConnector

Public Class CAPEConnect
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try

            Dim DeviceKey As String = GlobalVariables.LocalDeviceKey
            Dim CustData As New DataTable
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            MsgBox("success")
            MySqlConnection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class