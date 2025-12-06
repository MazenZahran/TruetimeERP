Public Class ShortcutsForm

    Private Sub ShortcutsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSystemForms()
        AddHandler RepositoryShortCut.KeyDown, AddressOf RepositoryShortCut_KeyDown
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

            If GridView1.FocusedRowHandle >= 0 Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ShortCut", shortcutText)
            End If

            e.Handled = True
            e.SuppressKeyPress = True

        Catch ex As Exception
            MsgBox("حدث خطأ: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
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
