Public Class JiraSettings
    Private Sub JiraSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Private Sub GetData()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Email' ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                txtEmail.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            End If
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Token' ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                txtToken.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            End If
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Url' ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                txtURL.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdateData()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" update Settings set SettingValue = '" & txtEmail.Text & "' where SettingName = 'Jira_Email' ")
            sql.SqlTrueAccountingRunQuery(" update Settings set SettingValue = '" & txtToken.Text & "' where SettingName = 'Jira_Token' ")
            sql.SqlTrueAccountingRunQuery(" update Settings set SettingValue = '" & txtURL.Text & "'   where SettingName = 'Jira_Url' ")
            MsgBoxShowSuccess("Update Successfull")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        UpdateData()
    End Sub
End Class