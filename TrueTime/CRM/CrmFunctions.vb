Module CrmFunctions
    Public Sub InsertToCalender(_StartDate As DateTime, _EndDate As DateTime, _Subject As String,
                             _Location As String, _Description As String, _Label As String,
                             _CreationUser As Integer, _CreationDate As DateTime,
                             _AssignedTo As Integer, _Referance As Integer, _DocCode As String)
        Dim sql As New SQLControl
        Dim sqlString As String
        If Format(_StartDate, "HH:mm") <> "00:00" Then
            sqlString = "  Delete from [Appointments] where DocCode='" & _DocCode & "' ; 
                       Insert Into [Appointments] ([Type],[StartDate],[EndDate],[QueryStartDate],
                                   [QueryEndDate],[AllDay],[Subject],[Location],[Description],[Status],[Label],[ReminderInfo],[TimeZoneId],
                                   [CreationUser],[TaskStatus],[CreationDate],[AssignedTo],DocCode,[Referance]) 
                       Values
                                    (0,'" & Format(_StartDate, "yyyy-MM-dd HH:mm") & "',
                                    '" & Format(_EndDate, "yyyy-MM-dd HH:mm") & "',
                                    '" & Format(_StartDate, "yyyy-MM-dd HH:mm") & "',
                                    '" & Format(_EndDate, "yyyy-MM-dd HH:mm") & "',
                                    0,
                                    N'" & _Subject & "',
                                    N'" & _Location & "',
                                    N'" & _Description & "',
                                    2,
                                    " & _Label & ",
                                    '',
                                    'Israel Standard Time',
                                    " & _CreationUser & ",
                                    1,
                                    '" & Format(_CreationDate, "yyyy-MM-dd HH:mm") & "',
                                    " & _AssignedTo & ",
                                    '" & _DocCode & "',
                                    " & _Referance & ") "
            sql.SqlTrueAccountingRunQuery(sqlString)
        Else
            sqlString = "  Delete from [Appointments] where DocCode='" & _DocCode & "' ; 
                       Insert Into [Appointments] ([Type],[StartDate],[EndDate],[QueryStartDate],
                                   [QueryEndDate],[AllDay],[Subject],[Location],[Description],[Status],[Label],[ReminderInfo],[TimeZoneId],
                                   [CreationUser],[TaskStatus],[CreationDate],[AssignedTo],DocCode,[Referance]) 
                       Values
                                    (0,
                                    (select top(1) IsNull(DATEADD(MINUTE,0,max(EndDate)),'" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000')  from [dbo].[Appointments] where EndDate between '" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000' and '" & Format(_StartDate, "yyyy-MM-dd") & " 23:59:59.999'), 
                                    (select top(1) IsNull(DATEADD(MINUTE,30,max(EndDate)),'" & Format(_StartDate, "yyyy-MM-dd") & " 00:30:00.000')  from [dbo].[Appointments] where EndDate between '" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000' and '" & Format(_StartDate, "yyyy-MM-dd") & " 23:59:59.999'), 
                                    (select top(1) IsNull(DATEADD(MINUTE,0,max(EndDate)),'" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000')  from [dbo].[Appointments] where EndDate between '" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000' and '" & Format(_StartDate, "yyyy-MM-dd") & " 23:59:59.999'),
                                    (select top(1) IsNull(DATEADD(MINUTE,30,max(EndDate)),'" & Format(_StartDate, "yyyy-MM-dd") & " 00:30:00.000')  from [dbo].[Appointments] where EndDate between '" & Format(_StartDate, "yyyy-MM-dd") & " 00:00:00.000' and '" & Format(_StartDate, "yyyy-MM-dd") & " 23:59:59.999'), 
                                    0,
                                    N'" & _Subject & "',
                                    N'" & _Location & "',
                                    N'" & _Description & "',
                                    2,
                                    " & _Label & ",
                                    '',
                                    'West Bank Standard Time',
                                    " & _CreationUser & ",
                                    1,
                                    '" & Format(_CreationDate, "yyyy-MM-dd HH:mm") & "',
                                    " & _AssignedTo & ",
                                    '" & _DocCode & "',
                                    " & _Referance & ") "
            sql.SqlTrueAccountingRunQuery(sqlString)
        End If



    End Sub





    Public Sub InsertToClosingTables(_TaskID As Integer, _Notes As String, _ClosingDate As DateTime, UserID As Integer, LastStatus As Integer, CurrentStatus As Integer)
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " Insert into AppointmentClosing
                                                    (TaskID,Notes,ClosingDate,UserID,
                                                    LastTaskStatus,CurrentTaskStatus) Values 
                                      (
                                      " & _TaskID & ",
                                      N'" & _Notes & "',
                                      '" & Format(_ClosingDate, "yyyy-MM-dd HH:mm") & "',
                                      '" & UserID & "',
                                      " & LastStatus & ",
                                      " & CurrentStatus & "
                                      ) "
            Sql.SqlTrueAccountingRunQuery(SqlString)
        Catch ex As Exception

        End Try

    End Sub


    'Public Sub InsertClosingAppointment()
    '    'Dim _TaskID As Integer = 0
    '    'Dim _Notes As String = ""
    '    'Dim _ClosingDate As DateTime = Today
    '    'Dim _AssignedTo As Integer = 0
    '    '_TaskID = Me.UniqueID.EditValue
    '    '_Notes = Me.tbDescription.Text
    '    '_ClosingDate = edtStartDate.DateTime

    '    'Dim Sql As New SQLControl
    '    'Dim SqlString As String
    '    'SqlString = " Insert Into [dbo].[AppointmentClosing] (TaskID,ClosingDate,[AssignedTo],Notes) 
    '    '                          Values (" & _TaskID & ",
    '    '                          '" & Format(_ClosingDate, "yyyy-MM-dd HH:mm") & "',
    '    '                          '" & _AssignedTo & "',
    '    '                          N'" & _Notes & "')  "
    '    'Sql.SqlTrueAccountingRunQuery(SqlString)
    'End Sub


    Public Sub UpdateAppointment(Action As String, TaskID As Integer, Notes As String, AssignedTo As Integer, ClosingDate As DateTime, SearchCreationUser As Integer)

        Dim Sql As New SQLControl
        Dim SqlString As String
        Select Case Action
            Case "Done"
                SqlString = " Update [dbo].[Appointments] Set
                                   TaskStatus=3, 
                                   Label=3,
                                   AssignedTo=" & SearchCreationUser & " 
                                   Where UniqueID=" & TaskID
                Sql.SqlTrueAccountingRunQuery(SqlString)
            Case "Follow"
                SqlString = " Update [dbo].[Appointments] Set
                                   TaskStatus=2 ,
                                   StartDate='" & Format(ClosingDate, "yyyy-MM-dd HH:mm") & "',
                                   [EndDate]='" & Format(ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
                                   QueryStartDate= '" & Format(ClosingDate, "yyyy-MM-dd HH:mm") & "',
                                   QueryEndDate='" & Format(ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
                                   AssignedTo=" & AssignedTo & ",
                                   Description=N'" & Notes & "'
                                   Where UniqueID=" & TaskID
                Sql.SqlTrueAccountingRunQuery(SqlString)
            Case "Close"
                SqlString = " Update [dbo].[Appointments] Set
                                   TaskStatus=4, 
                                   Label=3
                                   Where UniqueID=" & TaskID
                Sql.SqlTrueAccountingRunQuery(SqlString)
        End Select


        ' Me.Dispose()


    End Sub

    Public Sub UpdateAppointmentByDocCode(Action As String, DocCode As String, Notes As String, ClosingDate As DateTime, Referance As String, Location As String)

        Dim Sql As New SQLControl
        Dim SqlString As String
        Select Case Action
            Case "Follow"
                SqlString = " Update [dbo].[Appointments] Set
                                   StartDate='" & Format(ClosingDate, "yyyy-MM-dd HH:mm") & "',
                                   [EndDate]='" & Format(ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
                                   QueryStartDate= '" & Format(ClosingDate, "yyyy-MM-dd HH:mm") & "',
                                   QueryEndDate='" & Format(ClosingDate.AddDays(1), "yyyy-MM-dd HH:mm") & "',
                                   Location=N'" & Location & "',[Referance]='" & Referance & "'
                                   Where DocCode='" & DocCode & "'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
        End Select


        ' Me.Dispose()


    End Sub
End Module
