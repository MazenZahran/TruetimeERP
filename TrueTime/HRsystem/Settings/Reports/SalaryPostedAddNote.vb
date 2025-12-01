Public Class SalaryPostedAddNote
    Public _DocID As Integer
    Public _Note As String
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update AttRawatebArchive Set SalaryNote=N'" & Me.MemoEdit1.Text & "' where [ID]=" & _DocID
        If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
            _Note = Me.MemoEdit1.Text
            Me.Close()
        Else
            MsgBoxShowError(" خطأ في حفظ البيانات ")
        End If
    End Sub
    Private Sub GetLastNote()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select IsNull(SalaryNote,'') as SalaryNote from AttRawatebArchive where ID=" & _DocID
            sql.SqlTrueTimeRunQuery(sqlstring)
            Me.MemoEdit1.Text = sql.SQLDS.Tables(0).Rows(0).Item("SalaryNote")
            _Note = sql.SQLDS.Tables(0).Rows(0).Item("SalaryNote")
        Catch ex As Exception
            Me.MemoEdit1.Text = ""
        End Try

    End Sub

    Private Sub SalaryPostedAddNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GetLastNote()
    End Sub
End Class