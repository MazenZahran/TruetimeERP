Public Class SecuritySettings
    Private Sub SecuritySettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _EndDate As DateTime
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Select SetCode from [dbo].[SettValues] where SetName='Set1'")
        _EndDate = CDate((DecodingData(sql.SQLDS.Tables(0).Rows(0).Item("SetCode"))))
        Me.EndDate.DateTime = CDate(_EndDate)
    End Sub
    Private Sub UpdateEndDate()
        Dim PassText As String = EncodingData(EndDate.Text)
        Dim SqlString As String = " Update  [dbo].[SettValues] Set SetCode= '" & PassText & "' where  SetName = 'Set1' "
        Dim sql As New SQLControl
        If sql.SqlTrueTimeRunQuery(SqlString) = True Then
            GlobalVariables._EndDate = Me.EndDate.DateTime
            MsgBox("تم حفظ الاعدادات ")
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateEndDate()
    End Sub

    'eDg-ewq-bfd
End Class