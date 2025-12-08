Public Class ShortcutInfo
    Public Property FormID As Integer
    Public Property FormName As String
    Public Property ShortcutKey As String
    Public Property OpenAsNew As Boolean
    Public Property NameAr As String
    Public Property CategoryAr As String

    Public Sub New()
    End Sub

    Public Sub New(formID As Integer, formName As String, shortcutKey As String, Optional openAsNew As Boolean = False)
        Me.FormID = formID
        Me.FormName = formName
        Me.ShortcutKey = shortcutKey
        Me.OpenAsNew = openAsNew
    End Sub
End Class