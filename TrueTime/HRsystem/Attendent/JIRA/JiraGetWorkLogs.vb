Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Imports Newtonsoft.Json

Public Class JiraGetWorkLogs
    Private JsonString As String
    Dim _WorkLogTable As DataTable
    Private Sub BtnGetTrans_Click(sender As Object, e As EventArgs) Handles BtnGetTrans.Click
        GetNewData(False)
        Me.GridControl1.DataSource = _WorkLogTable
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub GetNewData(_all As Boolean)


        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        If GetJsonData() = False Then
            CloseProgressPanel(handle)
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "truncate TABLE  [dbo].[JIRA_ContentTemp];truncate TABLE  [dbo].[JIRA_worklogsTemp];truncate TABLE  [dbo].[JIRA_IssuesTemp] "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Dim rootObject As RootObject = JsonConvert.DeserializeObject(Of RootObject)(JsonString)
        Dim worklogsDataTable As New DataTable()
        ' Define columns in the DataTable
        worklogsDataTable.Columns.Add("WorklogID", GetType(String))
        worklogsDataTable.Columns.Add("Started", GetType(DateTime))
        worklogsDataTable.Columns.Add("TimeSpent", GetType(String))
        worklogsDataTable.Columns.Add("Author", GetType(String))
        worklogsDataTable.Columns.Add("UpdateAuthor", GetType(String))
        worklogsDataTable.Columns.Add("timeSpentSeconds", GetType(Decimal))
        worklogsDataTable.Columns.Add("Created", GetType(DateTime))
        worklogsDataTable.Columns.Add("Updated", GetType(DateTime))
        worklogsDataTable.Columns.Add("IssueId", GetType(Integer))
        worklogsDataTable.Columns.Add("emailAddress", GetType(String))

        ' Accessing Worklogs and populating the DataTable
        For Each issue As Issue In rootObject.issues
            For Each worklog As Worklogs In issue.fields.worklog.worklogs
                ' Adding rows to the DataTable with worklog details
                worklogsDataTable.Rows.Add(
            worklog.id,
            worklog.started,
            worklog.timeSpent,
            worklog.author.displayName,
            worklog.updateAuthor.displayName,
            worklog.timeSpentSeconds,
            worklog.created,
            worklog.updated,
            worklog.issueId,
            worklog.author.emailAddress
        )
            Next
        Next
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In worklogsDataTable.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "JIRA_worklogsTemp"
            bulkCopy.WriteToServer(worklogsDataTable)
        End Using




        Dim contentDataTable As New DataTable()
        contentDataTable.Columns.Add("WorklogID", GetType(String))
        contentDataTable.Columns.Add("IssueId", GetType(Integer))
        contentDataTable.Columns.Add("Type", GetType(String))
        contentDataTable.Columns.Add("Text", GetType(String))
        ' Iterate through the issues and worklogs to extract content
        For Each issue As Issue In rootObject.issues
            For Each worklog As Worklogs In issue.fields.worklog.worklogs
                If worklog.comment IsNot Nothing AndAlso worklog.comment.content IsNot Nothing Then
                    For Each commentContent As Content In worklog.comment.content
                        For Each subContent As SubContent In commentContent.content
                            Dim newRow As DataRow = contentDataTable.NewRow()
                            newRow("WorklogID") = worklog.id ' Add Worklog ID field
                            newRow("IssueId") = worklog.issueId ' Add Worklog ID field
                            newRow("Type") = subContent.type
                            newRow("Text") = subContent.text
                            contentDataTable.Rows.Add(newRow)
                        Next
                    Next
                End If
            Next
        Next
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In contentDataTable.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "JIRA_ContentTemp"
            bulkCopy.WriteToServer(contentDataTable)
        End Using


        Dim issueTable As New DataTable
        issueTable.Columns.Add("id", GetType(Integer))
        issueTable.Columns.Add("Key", GetType(String))
        For Each issue As Issue In rootObject.issues
            Dim newRow As DataRow = issueTable.NewRow()
            newRow("id") = issue.id ' Add Worklog ID field
            newRow("Key") = issue.key ' Add Worklog ID field
            issueTable.Rows.Add(newRow)
        Next
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In issueTable.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "JIRA_IssuesTemp"
            bulkCopy.WriteToServer(issueTable)
        End Using


        sqlstring = " 
                    select W.id,W.WorklogID,W.[Started],W.TimeSpent,W.Author,IsNull(E.EmployeeName,'') as EmployeeName,IsNull(E.EmployeeID,0) as EmployeeID,W.timeSpentSeconds,ROUND(W.timeSpentSeconds/60/60,2) as timeSpentHoures,
                           W.Created,W.Updated,W.IssueId,I.[Key],IsNull(C.Text,'') as NoteContent 
                    from [dbo].[JIRA_worklogsTemp] W
                    left join [dbo].[JIRA_IssuesTemp] I on W.IssueId =I.id 
                    left join [dbo].[JIRA_ContentTemp] C on W.WorklogID=C.WorklogID 
                    LEFT JOIN [JIRA_worklogs] R ON R.WorklogID = W.WorklogID
                    Left Join [dbo].[EmployeesData] E on W.Author=E.FaceBook  "
        If _all = False Then
            sqlstring += " WHERE R.WorklogID IS NULL Order By W.WorklogID "
        Else
            sqlstring += " Order By W.WorklogID "
        End If
        sql.SqlTrueAccountingRunQuery(sqlstring)
        'GridControl1.DataSource = sql.SQLDS.Tables(0)
        _WorkLogTable = sql.SQLDS.Tables(0)
        CloseProgressPanel(handle)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Dim sql As New SQLControl
        For i As Integer = 0 To GridView1.RowCount - 1
            Dim WorklogID As String = GridView1.GetRowCellValue(i, "WorklogID")
            Dim Started As DateTime = GridView1.GetRowCellValue(i, "Started")
            Dim TimeSpent As String = GridView1.GetRowCellValue(i, "TimeSpent")
            Dim Author As String = GridView1.GetRowCellValue(i, "Author")
            Dim EmployeeName As String = GridView1.GetRowCellValue(i, "EmployeeName")
            Dim EmployeeID As String = GridView1.GetRowCellValue(i, "EmployeeID")
            Dim timeSpentSeconds As Decimal = GridView1.GetRowCellValue(i, "timeSpentSeconds")
            Dim timeSpentHoures As Decimal = GridView1.GetRowCellValue(i, "timeSpentHoures")
            Dim Created As DateTime = GridView1.GetRowCellValue(i, "Created")
            Dim Updated As DateTime = GridView1.GetRowCellValue(i, "Updated")
            Dim IssueId As Integer = GridView1.GetRowCellValue(i, "IssueId")
            Dim Key As String = GridView1.GetRowCellValue(i, "Key")
            Dim NoteContent As String = GridView1.GetRowCellValue(i, "NoteContent")
            Dim sqlstring As String
            Dim _ID As Integer
            If EmployeeID <> "0" Then
                sqlstring = " INSERT INTO [dbo].[SalaryByProduction]
                                   ([Date_]
                                   ,[EmployeeID]
                                   ,[From_]
                                   ,[To_]
                                   ,[Quantity]
                                   ,[Service_Name]
                                   ,[Note]
                                   ,[ManagerNote]
                                   ,[HrNotes]
                                   ,[status]
                                   ,[x]
                                   ,[y]
                                   ,[Entry_date])
                             VALUES
                                   ('" & Started & "'
                                   ,'" & EmployeeID & "'
                                   ,'" & Format(Started, "yyyy-MM-dd HH:mm") & "'
                                   ,'" & Format(Created, "yyyy-MM-dd HH:mm") & "'
                                   ,'" & timeSpentHoures & "'
                                   ,'" & "JIRA" & "'
                                   ,N'" & NoteContent & " : " & TimeSpent & "'
                                   ,'" & "" & "'
                                   ,'" & "" & "'
                                   ,'" & 1 & "'
                                   ,'" & 0 & "'
                                   ,'" & 0 & "'
                                   ,'" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "') ; SELECT SCOPE_IDENTITY() as ID "
                If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                    _ID = sql.SQLDS.Tables(0).Rows(0).Item("ID")
                    sqlstring = " INSERT INTO [dbo].[JIRA_worklogs]
                                       ([WorklogID]
                                       ,[Started]
                                       ,[TimeSpent]
                                       ,[Author]
                                       ,[EmployeeName]
                                       ,[EmployeeID]
                                       ,[timeSpentSeconds]
                                       ,[timeSpentHoures]
                                       ,[Created]
                                       ,[Updated]
                                       ,[IssueId]
                                       ,[Key]
                                       ,[NoteContent],[SalaryByProductionID])
                                 VALUES
                                       ('" & WorklogID & "'
                                       ,'" & Started & "'
                                       ,'" & TimeSpent & "'
                                       ,'" & Author & "'
                                       ,'" & EmployeeName & "'
                                       ,'" & EmployeeID & "'
                                       ,'" & timeSpentSeconds & "'
                                       ,'" & timeSpentHoures & "'
                                       ,'" & Created & "'
                                       ,'" & Updated & "'
                                       ,'" & IssueId & "'
                                       ,'" & Key & "'
                                       ,'" & NoteContent & "'," & _ID & " ) "
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                End If


            End If

        Next

        'Dim filteredRows() As DataRow = _WorkLogTable.Select("NOT (EmployeeName IS NULL)")
        'Dim filteredTable As DataTable = _WorkLogTable.Clone() ' Cloning the structure of table1
        'For Each row As DataRow In filteredRows
        '    filteredTable.ImportRow(row)
        'Next

        'Try
        '    Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
        '        For Each col As DataColumn In filteredTable.Columns
        '            bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
        '        Next
        '        bulkCopy.BulkCopyTimeout = 600
        '        bulkCopy.DestinationTableName = "JIRA_worklogs"
        '        bulkCopy.WriteToServer(filteredTable)
        '    End Using
        '    MsgBoxShowSuccess(" تم حفظ الحركات بنجاح  ")
        'Catch ex As Exception
        '    MsgBoxShowError(" يوجد خطا في حفظ الحركات ")
        'End Try

        GetNewData(False)
    End Sub
    Private Function GetJsonData() As Boolean

        'Dim apiUrl As String = "https://pcnc.atlassian.net/rest/api/3/search?jql=updated>2014-01-20&fields=worklog,summery"

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Email' ")
        Dim username As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Token' ")
        Dim password As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_URL' ")
        Dim apiUrl As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") & "/rest/api/3/search?jql=ORDER BY created DESC&startAt=0&maxResults=1000&fields=worklog,summery"

        If username = "" Or password = "" Or apiUrl = "" Then
            MsgBoxShowError(" يجب ادخال بيانات الاتصال بالجيرا ")
            Return False
        Else
            Using httpClient As New HttpClient()
                Dim authInfo As String = Convert.ToBase64String(Encoding.[Default].GetBytes($"{username}:{password}"))
                httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authInfo)
                Dim responseTask As Task(Of HttpResponseMessage) = httpClient.GetAsync(apiUrl)
                Dim response As HttpResponseMessage = responseTask.Result
                If response.IsSuccessStatusCode Then
                    Dim responseContentTask As Task(Of String) = response.Content.ReadAsStringAsync()
                    Dim responseContent As String = responseContentTask.Result
                    JsonString = responseContent
                Else
                    Console.WriteLine("Request failed with status code: " & response.StatusCode)
                End If
            End Using
            Return True
        End If
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New JiraSettings
        With F
            .ShowDialog()
        End With
    End Sub

    Private Class RootObject
        Public Property expand As String
        Public Property startAt As Integer
        Public Property maxResults As Integer
        Public Property total As Integer
        Public Property issues As List(Of Issue)
    End Class

    Private Class Issue
        Public Property expand As String
        Public Property id As String
        Public Property [self] As String
        Public Property key As String
        Public Property fields As Fields
    End Class

    Private Class Fields
        Public Property worklog As Worklog
    End Class

    Private Class Worklog
        Public Property startAt As Integer
        Public Property maxResults As Integer
        Public Property total As Integer
        Public Property worklogs As List(Of Worklogs)

    End Class

    Private Class Worklogs
        Public Property self As String
        Public Property author As User
        Public Property updateAuthor As User
        Public Property created As DateTime
        Public Property updated As DateTime
        Public Property started As DateTime
        Public Property timeSpent As String
        Public Property timeSpentSeconds As Decimal
        Public Property id As String
        Public Property issueId As String
        Public Property comment As Comment
        Public Property emailAddress As String
    End Class

    Private Class User
        Public Property [self] As String
        Public Property accountId As String
        Public Property emailAddress As String
        Public Property avatarUrls As AvatarUrls
        Public Property displayName As String
        Public Property active As Boolean
        Public Property timeZone As String
        Public Property accountType As String
    End Class

    Private Class AvatarUrls
        Public Property x48 As String
        Public Property x24 As String
        Public Property x16 As String
        Public Property x32 As String
    End Class

    Private Class Comment
        Public Property version As Integer
        Public Property type As String
        Public Property content As List(Of Content)
    End Class

    Private Class Content
        Public Property type As String
        Public Property content As List(Of SubContent)
    End Class

    Private Class SubContent
        Public Property type As String
        Public Property text As String
    End Class

    Private Sub Jira_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroup2
    End Sub

    Private Sub RepositoryLinkEmployee_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryLinkEmployee.ButtonClick
        Dim F As New JiraLinkEmployee(GridView1.GetFocusedRowCellValue("Author"))
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetNewData(False)
            End If
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetNewData(True)
        Me.GridControl2.DataSource = _WorkLogTable
    End Sub
End Class