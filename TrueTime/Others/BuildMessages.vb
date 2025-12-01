Public Class BuildMessages
    Private Sub BuildMessages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetMessagesNames()
    End Sub
    Private Sub GetMessagesNames()
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Select [ID],SMSName,[SMSMessage],[SMSFields] from Messages")
        SearchIMessagesTypes.Properties.DataSource = Sql.SQLDS.Tables(0)
    End Sub
    Private Sub SearchIMessagesTypes_EditValueChanged(sender As Object, e As EventArgs) Handles SearchIMessagesTypes.EditValueChanged
        'If Not String.IsNullOrEmpty(SearchIMessagesTypes.Text) Then
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Select IsNull([SMSFields],'') as SMSFields,IsNull(SMSMessage,'') as SMSMessage from Messages where ID=" & SearchIMessagesTypes.EditValue)
        '    GridFields.DataSource = Sql.SQLDS.Tables(0)
        TextEdit1.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage"))
            Dim s As String = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SMSFields"))
            Dim items As String() = s.Split(","c)
            GridFields.DataSource = items
        'End If
    End Sub

    Private Sub GridFields_Click(sender As Object, e As EventArgs) Handles GridFields.DoubleClick
        TextEdit1.Text += "#" & GridView1.GetFocusedRowCellValue("Column") & "#"
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery(" Update [dbo].[Messages]
                                        Set [SMSMessage] = N'" & TextEdit1.Text & "' Where ID=" & SearchIMessagesTypes.EditValue)
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim str = TextEdit1.Text
        str = str.Replace("#CarNo#", "6908097")
        str = str.Replace("#Referenace#", "mazen zahran")
        str = str.Replace("#Amount#", "500")
        FunSendSmS2("0597505029", str)
    End Sub
End Class