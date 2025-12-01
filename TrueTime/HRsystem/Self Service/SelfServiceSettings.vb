Imports DevExpress.PivotGrid.QueryMode

Public Class SelfServiceSettings
    Private sql As New SQLControl
    Private sqlString As String
    Private Sub SelfServiceSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSettings()
    End Sub
    Private Sub GetSettings()
        Try
            Dim _SettingsTable As New DataTable
            Dim _SettingName, _SettingValue As String
            sqlString = " Select * from [dbo].[Settings] where SettingName IN ('SelfService_NumbersToJustViewNotifications','SelfService_SickVacationRequireAttch') "
            sql.SqlTrueTimeRunQuery(sqlString)
            _SettingsTable = sql.SQLDS.Tables(0)
            For i = 0 To _SettingsTable.Rows.Count - 1
                _SettingName = _SettingsTable.Rows(i).Item("SettingName")
                _SettingValue = _SettingsTable.Rows(i).Item("SettingValue")
                Select Case _SettingName
                    Case "SelfService_NumbersToJustViewNotifications"
                        NumbersToJustViewNotifications.Text = _SettingValue
                    Case "SelfService_SickVacationRequireAttch"
                        SelfService_SickVacationRequireAttch.EditValue = CBool(_SettingValue)
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub NumbersToJustViewNotifications_EditValueChanged(sender As Object, e As EventArgs) Handles NumbersToJustViewNotifications.EditValueChanged
        sql.SqlTrueTimeRunQuery(" Update [dbo].[Settings] Set SettingValue='" & NumbersToJustViewNotifications.Text & "' Where SettingName='SelfService_NumbersToJustViewNotifications'")
    End Sub

    Private Sub SelfService_SickVacationRequireAttch_CheckedChanged(sender As Object, e As EventArgs) Handles SelfService_SickVacationRequireAttch.CheckedChanged
        Dim sqlString As String
        Dim _Value As Boolean = CBool(SelfService_SickVacationRequireAttch.EditValue)
        sqlString = "  Update [dbo].[Settings] Set SettingValue='" & _Value & "' Where SettingName='SelfService_SickVacationRequireAttch'"
        sql.SqlTrueTimeRunQuery(sqlString)
    End Sub
End Class