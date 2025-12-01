Imports System.Data.SqlClient
Imports System.Net
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTreeList.Data
Imports Microsoft.Graph
Imports Newtonsoft.Json.Linq

Public Class JiraTest
    Private sqlstring As String
    Private sql As New SQLControl
    Private Sub GetLogEntries()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")

            ' Dim server As String = "pcnc.atlassian.net"
            Dim fromDate As String = Format(DateFromDate.DateTime, "dd/MM/yyyy")
            Dim Date_fromdate As String = Format(DateFromDate.DateTime, "yyyy-MM-dd")
            Dim toDate As String = Format(DateFromDate.DateTime, "dd/MM/yyyy")
            ' Dim Date_toDate As String = Format(CDate(fromDate), "yyyy-MM-dd")
            ' Dim project As String = "CAP"

            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Email' ")
            Dim username As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_Token' ")
            Dim password As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName = 'Jira_URL' ")
            Dim server As String = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")


            Dim logEntries As New DataTable()
            logEntries.Columns.Add("WorklogID", GetType(Integer))
            logEntries.Columns.Add("Started", GetType(String))
            logEntries.Columns.Add("TimeSpent", GetType(String))
            logEntries.Columns.Add("Author", GetType(String))
            logEntries.Columns.Add("timeSpentSeconds", GetType(Integer))
            logEntries.Columns.Add("Created", GetType(String))
            logEntries.Columns.Add("IssueId", GetType(Integer))
            logEntries.Columns.Add("Key", GetType(String))
            logEntries.Columns.Add("Houres", GetType(Decimal))

            Dim curl As WebRequest = WebRequest.Create($"{server}/rest/api/2/search?startIndex=0&jql=timespent >0 and updated  >= {Date_fromdate}  ORDER BY created &fields=key&maxResults=1000")
            Dim credentials As String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{username}:{password}"))
            curl.Headers(HttpRequestHeader.Authorization) = $"Basic {credentials}"

            Dim response As WebResponse = curl.GetResponse()
            Dim dataStream As System.IO.Stream = response.GetResponseStream()
            Dim reader As New System.IO.StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()

            Dim issues As JObject = JObject.Parse(responseFromServer)
            Dim _CurrentEmployeeHandle As Integer = 0
            For Each issue As JObject In issues("issues")

                'SplashScreenManager.CloseForm(False)
                'Exit Sub

                Dim key As String = issue("key").ToString()

                curl = WebRequest.Create($"{server}/rest/api/2/issue/{key}/worklog")
                curl.Headers(HttpRequestHeader.Authorization) = $"Basic {credentials}"
                response = curl.GetResponse()
                dataStream = response.GetResponseStream()
                reader = New System.IO.StreamReader(dataStream)
                responseFromServer = reader.ReadToEnd()

                Dim worklog As JObject = JObject.Parse(responseFromServer)
                Dim worklogs As JArray = worklog("worklogs")

                For Each entry As JObject In worklogs
                    Dim worklogDate As String = entry("started").ToString().Substring(0, 10)
                    ' If shortDate >= fromDate AndAlso shortDate <= toDate Then
                    If worklogDate >= fromDate Then
                        Dim log As New LogEntry()
                        log.Key = key
                        log.Started = entry("started").ToString()
                        log.Created = entry("created").ToString()
                        log.TimeSpentSeconds = Convert.ToInt32(entry("timeSpentSeconds"))
                        log.TimeSpent = entry("timeSpent").ToString()
                        log.Id = Convert.ToInt32(entry("id"))
                        log.IssueId = Convert.ToInt32(entry("issueId"))
                        Dim updateAuthorData As JObject = DirectCast(entry("updateAuthor"), JObject)
                        log.DisplayName = updateAuthorData("displayName").ToString()
                        log.Houres = Convert.ToDecimal(entry("timeSpentSeconds")) / 60 / 60
                        logEntries.Rows.Add(log.Id, log.Started, log.TimeSpent, log.DisplayName, log.TimeSpentSeconds, log.Created, log.IssueId, key, log.Houres)
                    End If
                Next
                _CurrentEmployeeHandle += 1
                SplashScreenManager.Default.SetWaitFormDescription(((_CurrentEmployeeHandle / issues("issues").Count) * 100).ToString("n0") & "%" & vbCrLf & _CurrentEmployeeHandle & " From " & issues("issues").Count)
            Next

            sqlstring = "truncate TABLE  [dbo].[JIRA_worklogsTemp] "
            sql.SqlTrueAccountingRunQuery(sqlstring)

            Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
                For Each col As DataColumn In logEntries.Columns
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
                Next
                bulkCopy.BulkCopyTimeout = 600
                bulkCopy.DestinationTableName = "JIRA_worklogsTemp"
                bulkCopy.WriteToServer(logEntries)
            End Using

            sqlstring = " select W.id,W.WorklogID,W.[Started],W.TimeSpent,W.Author,IsNull(E.EmployeeName,'') as EmployeeName,
                                 IsNull(E.EmployeeID,0) as EmployeeID,W.timeSpentSeconds,
                                 W.Created,W.IssueId,W.Houres,W.[Key],IsNull(R.id,0) as ExistID,
                                 case when R.id is null then 'New' else 'Exist' end as Exist, 
                                 case when E.EmployeeID is null then 'New' else 'Exist' end as EmployeesStatus
                         from [dbo].[JIRA_worklogsTemp] W
                         LEFT JOIN [JIRA_worklogs] R ON R.WorklogID = W.WorklogID
                         Left Join [dbo].[EmployeesData] E on W.Author=E.FaceBook 
                         Order By W.WorklogID"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Me.GridControl1.DataSource = sql.SQLDS.Tables(0)
            Me.GridView1.BestFitColumns()
            SplashScreenManager.CloseForm(False)

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function GetWorkLogsStatus() As DataTable
        '  Dim _table As New DataTable
        Dim Table1 As New DataTable()
        Table1.Columns.Add("name", GetType(System.String))
        Table1.Rows.Add("New")
        Table1.Rows.Add("Exist")
        Return Table1
    End Function
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "Exist" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Exist"))
            If category = "New" Then
                e.DisplayText = String.Format(_New)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "Exist" Then
                e.DisplayText = String.Format(_Exist)
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub

    Private _New As String = "<backcolor=@Critical><b><color=255, 255, 255>  New  </b>"
    Private _Exist As String = "<backcolor=@Success><b><color=255, 255, 255>  Inserted   </b>"
    Private Class LogEntry
        Public Property Key As String
        Public Property Started As String
        Public Property Created As String
        Public Property TimeSpentSeconds As Integer
        Public Property TimeSpent As String
        Public Property Id As Integer
        Public Property IssueId As Integer
        Public Property DisplayName As String
        Public Property Houres As Decimal
        Public Property UpdateAuthor As Updateauthor
    End Class
    Private Class Updateauthor
        Public Property Self As String
        Public Property AccountId As String
        Public Property DisplayName As String
        Public Property Active As Boolean
        Public Property TimeZone As String
        Public Property AccountType As String
    End Class

    Private Sub BtnGetTrans_Click(sender As Object, e As EventArgs) Handles BtnGetTrans.Click
        GetLogEntries()
    End Sub

    Private Sub JiraTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateFromDate.DateTime = Now.Date.AddDays(-1)
        Me.RepositoryExistStatus.DataSource = GetWorkLogsStatus()
        GetLastDate()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
            Dim sql As New SQLControl
            Dim _ID, _ID2, _J As Integer
            _J = 0
            For i As Integer = 0 To GridView1.RowCount - 1
                Dim WorklogID As String = GridView1.GetRowCellValue(i, "WorklogID")
                Dim ExistID As Integer = GridView1.GetRowCellValue(i, "ExistID")
                Dim Started As DateTime = CDate(GridView1.GetRowCellValue(i, "Started"))
                Dim TimeSpent As String = GridView1.GetRowCellValue(i, "TimeSpent")
                Dim Author As String = GridView1.GetRowCellValue(i, "Author")
                Dim EmployeeName As String = GridView1.GetRowCellValue(i, "EmployeeName")
                Dim EmployeeID As String = GridView1.GetRowCellValue(i, "EmployeeID")
                Dim timeSpentSeconds As Decimal = GridView1.GetRowCellValue(i, "timeSpentSeconds")
                Dim timeSpentHoures As Decimal = CDec(GridView1.GetRowCellValue(i, "Houres"))
                Dim Created As DateTime = CDate(GridView1.GetRowCellValue(i, "Created"))
                Dim IssueId As Integer = GridView1.GetRowCellValue(i, "IssueId")
                Dim _Key As String = GridView1.GetRowCellValue(i, "Key")
                Dim sqlstring As String
                If EmployeeID <> "0" And ExistID = 0 Then
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
                                   ('" & Format(Started, "yyyy-MM-dd") & "'
                                   ,'" & EmployeeID & "'
                                   ,'" & Format(Started, "yyyy-MM-dd HH:mm") & "'
                                   ,'" & Format(Created, "yyyy-MM-dd HH:mm") & "'
                                   ,'" & timeSpentHoures & "'
                                   ,'" & "JIRA" & "'
                                   ,N'" & _Key & " : " & TimeSpent & "'
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
                                       ,[IssueId]
                                       ,[Key]
                                       ,[SalaryByProductionID])
                                 VALUES
                                       ('" & WorklogID & "'
                                       ,'" & Format(Started, "yyyy-MM-dd HH:mm") & "'
                                       ,'" & TimeSpent & "'
                                       ,'" & Author & "'
                                       ,N'" & EmployeeName & "'
                                       ,'" & EmployeeID & "'
                                       ,'" & timeSpentSeconds & "'
                                       ,'" & timeSpentHoures & "'
                                       ,'" & Format(Created, "yyyy-MM-dd HH:mm") & "'
                                       ,'" & IssueId & "'
                                       ,'" & _Key & "'
                                       ," & _ID & " ) ; SELECT SCOPE_IDENTITY() as ID"
                        sql.SqlTrueAccountingRunQuery(sqlstring)
                        _ID2 = sql.SQLDS.Tables(0).Rows(0).Item("ID")
                    End If
                End If
                If _ID > 0 And _ID2 > 0 Then
                    GridView1.SetRowCellValue(i, "ExistID", _ID2)
                    GridView1.SetRowCellValue(i, "Exist", "Exist")
                    _J += 1
                End If
                _ID = 0 : _ID2 = 0
            Next
            If _J = 0 Then
                MsgBoxShowError(" لم يتم حفظ اي حركة جديدة ")
            Else
                MsgBoxShowSuccess("تم الحفظ بنجاح " & _J & " حركة ")
            End If
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            MsgBox("Error in Save Data" & vbCrLf & ex.Message, "Error")
            SplashScreenManager.CloseForm(False)
        End Try
        GetLastDate()
    End Sub

    Private Sub RepositoryLinkEmployee_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryLinkEmployee.ButtonClick
        Dim F As New JiraLinkEmployee(GridView1.GetFocusedRowCellValue("Author"))
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetLogEntries()
            End If
        End With
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New JiraSettings
        With F
            .ShowDialog()
        End With
    End Sub
    Private Sub GetLastDate()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select top(1) [Started],InputDateTime from [dbo].JIRA_worklogs order by [Started] desc ")
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            LabelControl1.Text = "The Last Imported Data From Jira was for date " & Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("Started")), "yyyy-MM-dd") & " @ " & sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime") & " "
        End If
    End Sub
End Class









