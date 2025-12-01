Public Class TTSSettings
    Public Property SettingName As String
    Public Property SettingValue As String
    Public Property ID As Integer
    Public Property SettingDescription As String

    Public Function GetAccountData(AccountNo As String) As Boolean
        Dim query As String = String.Empty
        Dim sql As New SQLControl
        query = " SELECT  [SettingName]
                      ,[SettingValue]
                      ,[ID]
                      ,[SettingDescription]
                   FROM [Settings]"
        Try
            sql.SqlTrueAccountingRunQuery(query)
            With sql.SQLDS.Tables(0).Rows(0)
                Me.SettingName = .Item("SettingName")
                Me.SettingValue = .Item("SettingValue")
                Me.ID = .Item("ID")
                Me.SettingDescription = .Item("SettingDescription")
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
