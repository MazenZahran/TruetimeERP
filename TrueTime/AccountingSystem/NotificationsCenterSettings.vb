Public Class NotificationsCenter


    Private Sub VouchersSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormsNames()
        GetNotificationsForms()
    End Sub

    Private Sub GetFormsNames()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "SELECT * FROM SystemForms"
        sql.SqlTrueTimeRunQuery(sqlString)
        RepositoryFormName.DataSource = sql.SQLDS.Tables(0)

    End Sub

    Private Sub GetNotificationsForms()
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "SELECT * FROM NotificationsForms"
        sql.SqlTrueTimeRunQuery(sqlString)
        TblNotificationsForms.DataSource = sql.SQLDS.Tables(0)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            For i = 0 To GridView1.RowCount - 1
                Dim idObj As Object = GridView1.GetRowCellValue(i, "id")
                Dim formIDObj As Object = GridView1.GetRowCellValue(i, "FormID")

                If IsNothing(formIDObj) OrElse IsDBNull(formIDObj) OrElse String.IsNullOrWhiteSpace(formIDObj.ToString()) Then
                    Continue For
                End If

                Dim phonesObj As Object = GridView1.GetRowCellValue(i, "Phones")
                Dim whenEditObj As Object = GridView1.GetRowCellValue(i, "WhenEdit")
                Dim whenDeleteObj As Object = GridView1.GetRowCellValue(i, "WhenDelete")
                Dim whenAddObj As Object = GridView1.GetRowCellValue(i, "WhenAdd")

                Dim sql As New SQLControl
                Dim sqlString As String = String.Empty

                Dim formID As Integer = 0
                Integer.TryParse(formIDObj.ToString(), formID)

                Dim phones As String = ""
                If Not IsNothing(phonesObj) AndAlso Not IsDBNull(phonesObj) Then
                    phones = phonesObj.ToString().Replace("'", "''")
                End If

                Dim whenEdit As Integer = 0
                If Not IsNothing(whenEditObj) AndAlso Not IsDBNull(whenEditObj) Then
                    If Boolean.TryParse(whenEditObj.ToString(), Nothing) Then
                        whenEdit = If(CBool(whenEditObj), 1, 0)
                    End If
                End If

                Dim whenDelete As Integer = 0
                If Not IsNothing(whenDeleteObj) AndAlso Not IsDBNull(whenDeleteObj) Then
                    If Boolean.TryParse(whenDeleteObj.ToString(), Nothing) Then
                        whenDelete = If(CBool(whenDeleteObj), 1, 0)
                    End If
                End If

                Dim whenAdd As Integer = 0
                If Not IsNothing(whenAddObj) AndAlso Not IsDBNull(whenAddObj) Then
                    If Boolean.TryParse(whenAddObj.ToString(), Nothing) Then
                        whenAdd = If(CBool(whenAddObj), 1, 0)
                    End If
                End If

                If idObj Is Nothing OrElse IsDBNull(idObj) OrElse String.IsNullOrWhiteSpace(idObj.ToString()) Then
                    sqlString = "INSERT INTO NotificationsForms (FormID, Phones, WhenEdit, WhenDelete, WhenAdd) VALUES (" &
                                     formID & ", N'" & phones & "', " & whenEdit & ", " & whenDelete & ", " & whenAdd & ")"
                Else
                    Dim idVal As Integer = 0
                    Integer.TryParse(idObj.ToString(), idVal)
                    sqlString = "UPDATE NotificationsForms SET " &
                                 "FormID = " & formID & ", " &
                                 "Phones = N'" & phones.Replace("'", "''") & "', " &
                                 "WhenEdit = " & whenEdit & ", " &
                                 "WhenDelete = " & whenDelete & ", " &
                                 "WhenAdd = " & whenAdd & " " &
                                 "WHERE id = " & idVal

                End If

                sql.SqlTrueTimeRunQuery(sqlString)
            Next

            MsgBox("تم الحفظ بنجاح")
            GetNotificationsForms()

        Catch ex As Exception
            MsgBox("حدث خطأ أثناء الحفظ: " & ex.Message, MsgBoxStyle.Critical, "خطأ")
        End Try

    End Sub
End Class