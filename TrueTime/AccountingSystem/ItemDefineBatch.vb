Public Class ItemDefineBatch
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Savedata()
    End Sub
    Private Sub Savedata()
        If String.IsNullOrEmpty(TextBatchNo.Text) Then Exit Sub
        If String.IsNullOrEmpty(TextItemNo.Text) Then Exit Sub
        If DateExpireDate.Text = "" Then
            MsgBoxShowError(" يجب ادخال تاريخ الصلاحية ")
            Exit Sub
        End If
        If TextBatchNo.Text = "" Then
            MsgBoxShowError(" يجب ادخال رقم الباتش ")
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " INSERT INTO [dbo].[ItemBatchNo]
           ([BatchNo]
           ,[ExpireDate]
           ,[ItemNo])
     VALUES
           (N'" & TextBatchNo.Text & "'
           , '" & Format(DateExpireDate.DateTime, "yyyy-MM-dd") & "'
           ," & TextItemNo.Text & " )"
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            'MsgBoxShowSuccess(" تم تعريف الباتش  ")
            Me.Close()
        End If
    End Sub

    Private Sub ItemDefineBatch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBatchNo.Select()
        Me.KeyPreview = True
    End Sub

    Private Sub ItemDefineBatch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Savedata()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TextBatchNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBatchNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DateExpireDate.Select()
        End If
    End Sub

    Private Sub DateExpireDate_KeyDown(sender As Object, e As KeyEventArgs) Handles DateExpireDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            Savedata()
        End If
    End Sub
End Class