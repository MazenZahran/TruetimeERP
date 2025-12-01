Public Class ReferancesMessageWrite
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If String.IsNullOrWhiteSpace(Me.MemoEdit1.Text) Then
            MsgBoxShowError(" لا يوجد نص لارساله ")
            Exit Sub
        End If
        GlobalVariables._ReferancesMessage = Me.MemoEdit1.Text
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GlobalVariables._ReferancesMessage = "-1"
        Me.Close()
    End Sub
End Class