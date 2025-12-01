Public Class AppointmentsClosing
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'InsertToClosingTables(1, "hg", Now, 1)
        'UpdateAppointment("Done", 1, "", 1, Now, 1)
        'MsgBox("تم انجاز المهمة")
        'Me.Dispose()
    End Sub
    'Private Sub InsertClosingAppointment()
    '    Dim _TaskID As Integer = 0
    '    Dim _Notes As String = ""
    '    Dim _ClosingDate As DateTime = Today
    '    Dim _AssignedTo As Integer = 0
    '    _TaskID = Me.UniqueID.EditValue
    '    _Notes = Me.tbDescription.Text
    '    _ClosingDate = edtStartDate.DateTime

    '    Dim Sql As New SQLControl
    '    Dim SqlString As String
    '    SqlString = " Insert Into [dbo].[AppointmentClosing] (TaskID,ClosingDate,[AssignedTo],Notes) 
    '                              Values (" & _TaskID & ",
    '                              '" & Format(_ClosingDate, "yyyy-MM-dd HH:mm") & "',
    '                              '" & _AssignedTo & "',
    '                              N'" & _Notes & "')  "
    '    Sql.SqlTrueAccountingRunQuery(SqlString)
    'End Sub
    'Private Sub UpdateAppointment(_Action)
    '    Dim _TaskID As Integer = 0
    '    Dim _Notes As String = ""
    '    Dim _ClosingDate As DateTime = Today
    '    Dim _AssignedTo As Integer
    '    _TaskID = Me.UniqueID.EditValue
    '    _Notes = Me.tbDescription.Text
    '    _ClosingDate = edtStartDate.DateTime
    '    _AssignedTo = Me.SearchAssignedTo.EditValue
    '    Dim Sql As New SQLControl
    '    Dim SqlString As String
    '    Select Case _Action
    '        Case "Done"
    '            SqlString = " Update [dbo].[Appointments] Set
    '                               TaskStatus=3, 
    '                                AssignedTo=" & SearchCreationUser.EditValue & " 
    '                                Where UniqueID=" & _TaskID
    '            Sql.SqlTrueAccountingRunQuery(SqlString)
    '        Case "Follow"
    '            SqlString = " Update [dbo].[Appointments] Set
    '                               TaskStatus=2 ,
    '                               StartDate='" & Format(_ClosingDate, "yyyy-MM-dd HH:mm") & "',
    '                               [EndDate]='" & Format(_ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
    '                                QueryStartDate= '" & Format(_ClosingDate, "yyyy-MM-dd HH:mm") & "',
    '                                QueryEndDate='" & Format(_ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
    '                                AssignedTo=" & _AssignedTo & ",
    '                                Description=N'" & Me.tbDescription.Text & "'
    '                                Where UniqueID=" & _TaskID
    '            Sql.SqlTrueAccountingRunQuery(SqlString)
    '    End Select


    '    Me.Dispose()


    'End Sub
    ' 
    Private Sub AppointmentsClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.CRMTaskStatuses' table. You can move, or remove it, as needed.
        Me.CRMTaskStatusesTableAdapter.Fill(Me.TrueAccountingDataSet.CRMTaskStatuses)
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.
        Me.ReferancesListTableAdapter.Fill(Me.TrueAccountingDataSet.ReferancesList)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        TextTaskStatus.EditValue = 2
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        InsertToClosingTables(Me.UniqueID.EditValue, Me.tbDescription.Text, Format(Now, "yyyy-MM-dd HH:mm"), GlobalVariables.CurrUserForTasks, TextTaskStatus.EditValue, 2)
        UpdateAppointment("Follow", Me.UniqueID.EditValue, tbDescription.Text, Me.SearchAssignedTo.EditValue, edtStartDate.EditValue, Me.SearchCreationUser.EditValue)
    End Sub

    Private Sub TextTaskStatus_EditValueChanged(sender As Object, e As EventArgs) Handles TextTaskStatus.EditValueChanged
        tbProgress.EditValue = GetStatusSteps(TextTaskStatus.EditValue)
        lblPercentCompleteValue.Text = tbProgress.EditValue
        'If Me.TextTaskStatus.EditValue = 3 Then Me
    End Sub
    Private Function GetStatusSteps(StatusID As Integer) As Integer
        Dim _Step As Integer = 0
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select Step from [dbo].[CRMTaskStatuses] where  StatusID=" & StatusID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Step = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("Step"))
        Catch ex As Exception
            _Step = 0
        End Try
        Return _Step
    End Function

    Private Sub RibbonControl1_Click(sender As Object, e As EventArgs) Handles RibbonControl1.Click

    End Sub

    Private Sub tbProgress_EditValueChanged(sender As Object, e As EventArgs) Handles tbProgress.EditValueChanged

    End Sub
End Class