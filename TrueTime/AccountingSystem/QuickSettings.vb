Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class QuickSettings
    Dim Con As SqlConnection
    Dim SettingsAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingQuickSettingsTable()
        GetSettings()
    End Sub
    Private Sub GetSettings()
        Dim sqlstring As String = " SELECT  [ID],[SettingName],[SettingValue],[SettingDescription]                                
                                    FROM [dbo].[Settings]
                                    Where SettingValue='True' or SettingValue='False' "
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            SettingsAdapter = New SqlDataAdapter(sqlstring, Con)
            DS = New System.Data.DataSet()
            SettingsAdapter.Fill(DS, "Settings")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try

    End Sub

    Private Sub QuickSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSettings()
    End Sub
    Private Sub SavingQuickSettingsTable()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(SettingsAdapter)
            SettingsAdapter.Update(DS, "Settings")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        GetSettings()
    End Sub
End Class