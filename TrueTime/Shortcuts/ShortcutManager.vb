Imports System.Data

Public Class ShortcutManager
    Private Shared _instance As ShortcutManager
    Private _shortcutsCache As Dictionary(Of String, ShortcutInfo)

    Private Sub New()
        _shortcutsCache = New Dictionary(Of String, ShortcutInfo)(StringComparer.OrdinalIgnoreCase)
    End Sub

    Public Shared ReadOnly Property Instance As ShortcutManager
        Get
            If _instance Is Nothing Then
                _instance = New ShortcutManager()
            End If
            Return _instance
        End Get
    End Property

    Public Sub LoadShortcuts()
        Try
            _shortcutsCache.Clear()

            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT FormID, FormName, ShortCut, ISNULL(OpenAsNew, 0) AS OpenAsNew, NameAr, CategoryAr FROM SystemForms WHERE ShortCut IS NOT NULL AND ShortCut <> ''"
            sql.SqlTrueTimeRunQuery(sqlString)

            For Each row As DataRow In sql.SQLDS.Tables(0).Rows
                Dim info As New ShortcutInfo With {
                    .FormID = If(IsDBNull(row("FormID")), 0, CInt(row("FormID"))),
                    .FormName = If(IsDBNull(row("FormName")), "", row("FormName").ToString()),
                    .ShortcutKey = If(IsDBNull(row("ShortCut")), "", row("ShortCut").ToString().Trim()),
                    .OpenAsNew = If(IsDBNull(row("OpenAsNew")), False, CBool(row("OpenAsNew"))),
                    .NameAr = If(IsDBNull(row("NameAr")), "", row("NameAr").ToString()),
                    .CategoryAr = If(IsDBNull(row("CategoryAr")), "", row("CategoryAr").ToString())
                }

                If Not String.IsNullOrWhiteSpace(info.ShortcutKey) Then
                    _shortcutsCache(info.ShortcutKey) = info
                End If
            Next
        Catch ex As Exception
            ' Log error
        End Try
    End Sub

    Public Function FindShortcut(shortcutKey As String) As ShortcutInfo
        If _shortcutsCache.ContainsKey(shortcutKey) Then
            Return _shortcutsCache(shortcutKey)
        End If
        Return Nothing
    End Function

    Public Function IsShortcutExists(shortcutKey As String) As Boolean
        Return _shortcutsCache.ContainsKey(shortcutKey)
    End Function

    Public Function GetAllShortcuts() As List(Of ShortcutInfo)
        Return _shortcutsCache.Values.ToList()
    End Function

    Public Sub Refresh()
        LoadShortcuts()
    End Sub

    Public Shared Function BuildShortcutText(e As KeyEventArgs) As String
        If e.KeyCode = Keys.ControlKey OrElse e.KeyCode = Keys.ShiftKey OrElse
           e.KeyCode = Keys.Menu OrElse e.KeyCode = Keys.Alt OrElse
           e.KeyCode = Keys.LWin OrElse e.KeyCode = Keys.RWin Then
            Return String.Empty
        End If

        Dim parts As New List(Of String)

        If e.Control Then parts.Add("Ctrl")
        If e.Alt Then parts.Add("Alt")
        If e.Shift Then parts.Add("Shift")

        If e.KeyCode <> Keys.None Then
            parts.Add(e.KeyCode.ToString())
        End If

        Return If(parts.Count > 0, String.Join("+", parts), String.Empty)
    End Function
End Class