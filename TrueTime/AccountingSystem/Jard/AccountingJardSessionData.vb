Public Class AccountingJardSessionData
    Private Doc_ID As Integer
    Public Sub New(_DocID As Integer)
        InitializeComponent()
        Doc_ID = _DocID
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        If String.IsNullOrWhiteSpace(Me.txtSessionDetails.Text) Then
            MsgBoxShowError(" يجب تعبئة بيانات الجلسة")
            Exit Sub
        End If
        If String.IsNullOrWhiteSpace(Me.WhereHouse.Text) Then
            MsgBoxShowError(" يجب تعبئة المستودع")
            Exit Sub
        End If
        If Doc_ID = -1 Then
            sqlstring = " Insert Into JardSessions 
                                 (SessionDetails,SessionDate,SessionWareHouse) 
                                 Values 
                                 (N'" & txtSessionDetails.Text & "','" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "'," & WhereHouse.EditValue & " ) "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                Me.Close()
            End If
        Else
            sqlstring = " Update JardSessions Set SessionDetails=N'" & Me.txtSessionDetails.Text & "', 
                                              SessionDate='" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', 
                                              SessionWareHouse=" & Me.WhereHouse.EditValue & " Where ID=" & Doc_ID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.Close()
        End If
    End Sub

    Private Sub AccountingJardSessionDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Doc_ID = -1 Then
            DateEdit1.DateTime = Today
        Else
            GetSessionData()
        End If
        WhereHouse.Properties.DataSource = GetWharehouses(False)
    End Sub
    Private Sub GetSessionData()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Select * From JardSessions Where ID=" & Doc_ID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Me.txtSessionDetails.Text = sql.SQLDS.Tables(0).Rows(0).Item("SessionDetails")
            Me.DateEdit1.DateTime = sql.SQLDS.Tables(0).Rows(0).Item("SessionDate")
            Me.WhereHouse.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SessionWareHouse")
        End If
    End Sub
End Class