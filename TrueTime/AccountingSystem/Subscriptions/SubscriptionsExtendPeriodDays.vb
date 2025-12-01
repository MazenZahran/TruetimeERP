Public Class SubscriptionsExtendPeriodDays
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _DayNo As Integer
        If TextEdit1.Text = "" Then
            MsgBoxShowError(" يجب تعبئة البيانات ")
        End If
        If TextEdit1.EditValue = 0 Then
            MsgBoxShowError(" يجب تعبئة البيانات ")
        End If
        _DayNo = CInt(TextEdit1.EditValue)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update [SubscriptionDoc] Set EndDate=DATEADD(d," & _DayNo & ",EndDate)   where SubStatus=1    "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            MsgBoxShowSuccess(" تم ")
            Me.Close()
        End If
    End Sub

    Private Sub SubscriptionsExtendPeriodDays_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class