Public Class ShortcutsForm

    Private Sub ShortcutsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSystemForms()
        AddHandler RepositoryShortCut.KeyDown, AddressOf RepositoryShortCut_KeyDown
        AddHandler RepositoryShortCut.ButtonClick, AddressOf RepositoryShortCut_ButtonClick
    End Sub

    Private Sub LoadSystemForms()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT FormID, NameAr, CategoryAr, ShortCut FROM SystemForms ORDER BY CategoryAr, NameAr"
            sql.SqlTrueTimeRunQuery(sqlString)
            TblSystemForms.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox("حدث خطأ أثناء تحميل البيانات: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub RepositoryShortCut_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ControlKey Or
               e.KeyCode = Keys.Menu Or e.KeyCode = Keys.LWin Or e.KeyCode = Keys.RWin Then
                Return
            End If

            Dim shortcutText As String = ""

            If e.Control Then
                shortcutText = "Ctrl"
            End If

            If e.Alt Then
                If shortcutText <> "" Then shortcutText &= "+"
                shortcutText &= "Alt"
            End If

            If e.Shift Then
                If shortcutText <> "" Then shortcutText &= "+"
                shortcutText &= "Shift"
            End If

            If e.KeyCode <> Keys.None Then
                If shortcutText <> "" Then shortcutText &= "+"
                shortcutText &= e.KeyCode.ToString()
            End If

            If Not String.IsNullOrWhiteSpace(shortcutText) AndAlso IsShortcutDuplicate(shortcutText, GridView1.FocusedRowHandle) Then
                MsgBox("هذا الاختصار مستخدم بالفعل في سند آخر!" & vbCrLf & "الرجاء اختيار اختصار مختلف.", MsgBoxStyle.Exclamation, "تحذير")
                e.Handled = True
                e.SuppressKeyPress = True
                Return
            End If

            If GridView1.FocusedRowHandle >= 0 Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ShortCut", shortcutText)
            End If

            e.Handled = True
            e.SuppressKeyPress = True

        Catch ex As Exception
            MsgBox("حدث خطأ: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub RepositoryShortCut_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Try
            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Delete Then
                If GridView1.FocusedRowHandle >= 0 Then
                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ShortCut", "")
                End If
            End If
        Catch ex As Exception
            MsgBox("حدث خطأ: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Function IsShortcutDuplicate(shortcutText As String, currentRowHandle As Integer) As Boolean
        For i = 0 To GridView1.RowCount - 1
            If i = currentRowHandle Then Continue For

            Dim existingShortcut As Object = GridView1.GetRowCellValue(i, "ShortCut")
            If existingShortcut IsNot Nothing AndAlso Not IsDBNull(existingShortcut) Then
                If existingShortcut.ToString().Trim().Equals(shortcutText.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim duplicates As New List(Of String)
            For i = 0 To GridView1.RowCount - 1
                Dim shortCutObj As Object = GridView1.GetRowCellValue(i, "ShortCut")
                If shortCutObj IsNot Nothing AndAlso Not IsDBNull(shortCutObj) AndAlso Not String.IsNullOrWhiteSpace(shortCutObj.ToString()) Then
                    Dim shortcut As String = shortCutObj.ToString().Trim()
                    If IsShortcutDuplicate(shortcut, i) AndAlso Not duplicates.Contains(shortcut) Then
                        duplicates.Add(shortcut)
                    End If
                End If
            Next

            If duplicates.Count > 0 Then
                MsgBox("يوجد اختصارات مكررة:" & vbCrLf & String.Join(", ", duplicates) & vbCrLf & vbCrLf & "الرجاء تصحيح الاختصارات المكررة قبل الحفظ.", MsgBoxStyle.Exclamation, "تحذير")
                Return
            End If

            For i = 0 To GridView1.RowCount - 1
                Dim formIDObj As Object = GridView1.GetRowCellValue(i, "FormID")
                Dim shortCutObj As Object = GridView1.GetRowCellValue(i, "ShortCut")

                If IsNothing(formIDObj) OrElse IsDBNull(formIDObj) Then
                    Continue For
                End If

                Dim formID As Integer = 0
                Integer.TryParse(formIDObj.ToString(), formID)

                Dim shortCut As String = ""
                If Not IsNothing(shortCutObj) AndAlso Not IsDBNull(shortCutObj) Then
                    shortCut = shortCutObj.ToString().Replace("'", "''")
                End If

                Dim sql As New SQLControl
                Dim sqlString As String = "UPDATE SystemForms SET ShortCut = N'" & shortCut & "' WHERE FormID = " & formID
                sql.SqlTrueTimeRunQuery(sqlString)
            Next

            MsgBox("تم حفظ الاختصارات بنجاح", MsgBoxStyle.Information, "نجح")
            LoadSystemForms()

        Catch ex As Exception
            MsgBox("حدث خطأ أثناء الحفظ: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

End Class
