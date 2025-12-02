Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports Newtonsoft.Json
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports DevExpress.XtraBars

Module Functions
    Private Function CheckIFHasAccessOnWhatsApp() As Boolean
        Dim companyId As Integer = 1

        ' Build the API URL with the company ID
        Dim url As String = $"http://ordersapp.truetime.ps/api/GetCompanyServices/GetWhatsAppStatus?CompanyID={companyId}"

        ' Create a new HttpClient instance
        Dim client As HttpClient = New HttpClient()

        ' Send a GET request to the API
        Dim response As Task(Of HttpResponseMessage) = client.GetAsync(url)
        Dim httpResponse As HttpResponseMessage = response.Result ' Wait for the task to complete and get the result synchronously

        ' Check for successful response
        If httpResponse.IsSuccessStatusCode Then
            ' Read the response content as a string
            Dim responseContent As String = httpResponse.Content.ReadAsStringAsync().Result ' Wait for the task to complete and get the result synchronously

            ' Deserialize the JSON response into a list of objects
            Dim whatsAppStatuses As List(Of WhatsAppStatus) = JsonConvert.DeserializeObject(Of List(Of WhatsAppStatus))(responseContent)

            ' Process the data
            For Each status In whatsAppStatuses
                'Console.WriteLine($"WhatsApp Status: {status.WhatsAppStatus}")
                GlobalVariables._AllowUseWhatsApp = status.WhatsAppStatus
            Next

            Return True ' Return true if the operation was successful
        Else
            Console.WriteLine($"Error: {httpResponse.StatusCode}")
            Return True
        End If
    End Function

    Private Function GetWhatsAppURLString(_SendFile As Boolean) As String
        ' 🚩 Check if package is enabled
        If GetCRMServices Then
            If Not LogInMenue.HasWhatsAppPackage Then
                MsgBoxShowError("الخدمة غير مفعلة")
                Return "https://invalid.local/fakeWhatsAppApi"
            End If
        End If

        Dim _Url As String
        Dim _InstanceID As String
        Dim _Token As String
        Dim sql As New SQLControl
        Dim sqlstring As String

        If _SendFile = True Then
            Try
                sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenAPISendFile' "
                sql.SqlTrueAccountingRunQuery(sqlstring)
                _Url = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Catch ex As Exception
                _Url = "0"
            End Try
        Else
            Try
                sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenAPI' "
                sql.SqlTrueAccountingRunQuery(sqlstring)
                _Url = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Catch ex As Exception
                _Url = "0"
            End Try
        End If

        Try
            sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenInstanceID' "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _InstanceID = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _InstanceID = "0"
        End Try

        Try
            sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenToken' "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Token = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _Token = "0"
        End Try

        Return _Url.Replace("{{idInstance}}", _InstanceID).Replace("{{apiTokenInstance}}", _Token)
    End Function

    Private Function GetWhatsAppURLString2(_SendFile As Boolean) As String
        Return "https://api.green-api.com/waInstance7103903885/sendMessage/83ac2143e09b4d45831e7b7423ae5a2c4bed9c1bed394c2389"
    End Function

    Public Function _SmsActionsTable() As DataTable
        Dim _table As New DataTable

        With _table
            .Columns.Add("ID", GetType(Integer))
            .Columns.Add("Action", GetType(String))
            Dim dr As DataRow = .NewRow
            dr("ID") = 1
            dr("Action") = "ارسال"
            .Rows.Add(dr)
            Dim dr2 As DataRow = .NewRow
            dr2("ID") = 2
            dr2("Action") = "تأجيل"
            .Rows.Add(dr2)
        End With
        Return _table
    End Function

    Public Sub ArchiveTrans(TransID As Integer, TransDate As String, TransType As String, EditedType As String, EmployeeID As Integer)
        Dim sql As New SQLControl
        ' Dim sqlString As String = " Select top(1) Concat(CHECKTYPE,':',Format(CHECKTIME,'yyyy-MM-dd HH:mm')) as Lastdata From AttCHECKINOUT where ID=" & TransID
        Dim sqlString As String = " SELECT TOP(1) CHECKTYPE + ':' +CONVERT(VARCHAR(16), CHECKTIME, 120) AS Lastdata FROM AttCHECKINOUT where ID= " & TransID

        sql.SqlTrueTimeRunQuery(sqlString)
        Dim _LastData As String = sql.SQLDS.Tables(0).Rows(0).Item("Lastdata")
        Dim InsertAttString As String = "Insert Into DeletedEditedTrans 
                                                    (TransID,TransDate,TransType,EditedType,EditedDate,UserID,EmployeeID,LastData) 
                                                    Values
                                                    (" & TransID & " , '" & TransDate & "' , '" & TransType & "','" & EditedType & "',
                                                    GETDATE(),'" & GlobalVariables.CurrUser & "','" & EmployeeID & "',N'" & "LastData:" & _LastData & "')"
        sql.SqlTrueTimeRunQuery(InsertAttString)

        CreateDocLog("Att", "Att", "0", EmployeeID, EditedType, EditedType & " Att Trans." & "For AttID=" & TransID & " Last Data=" & _LastData, Format(Now(), "yyyy-MM-dd HH:mm:ss"))

    End Sub

    Public Function Att_Get_AdditionsTypes_Table() As DataTable
        Dim _table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select * from [AttAdditionsTypes]")
            _table = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function
    Public Function Att_Get_DefualtAdditionTypeID() As Integer
        Dim _ID As Integer = 0
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select IsNull(SettingValue,0) as SettingValue from Settings where SettingName='Att_DefualtAdditionTypeID'")
            _ID = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function
    Public Function Att_Get_DefualtDiscountTypeID() As Integer
        Dim _ID As Integer = 0
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select IsNull(SettingValue,0) as SettingValue from Settings where SettingName='Att_DefualtDiscountTypeID'")
            _ID = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function
    Public Function Att_Get_DiscountsTypes_Table() As DataTable
        Dim _table As New DataTable
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select * from [AttPaymentsTypes]")
            _table = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function
    Public Function Att_InsertNewAttEmployeeAddition(
    ByVal additionDate As Date,
    ByVal employeeID As Integer,
    ByVal additionAmount As Decimal,
    ByVal additionNote As String,
    ByVal additionType As Integer,
    ByVal salaryDocumentID As Integer
) As Integer

        Dim paymentID As Integer = 0
        Try
            Dim connectionString As String = My.Settings.Item("TrueTimeConnectionString")

            ' SQL query to insert data and return the PaymentID
            Dim sqlstring As String = "INSERT INTO AttEmployeeAdditions " &
                        "(AdditionDate, EmployeeID, AdditionAmount, AdditionNote, AdditionType,SalaryDocumentID) " &
                        "OUTPUT INSERTED.AdditionID " &
                        "VALUES (@AdditionDate, @EmployeeID, @AdditionAmount, @AdditionNote, @AdditionType,@SalaryDocumentID); "

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(sqlstring, conn)
                    ' Add parameters
                    cmd.Parameters.AddWithValue("@AdditionDate", Format(additionDate, "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.Parameters.AddWithValue("@AdditionAmount", additionAmount)
                    cmd.Parameters.AddWithValue("@AdditionNote", additionNote)
                    cmd.Parameters.AddWithValue("@AdditionType", additionType)
                    cmd.Parameters.AddWithValue("@SalaryDocumentID", salaryDocumentID)

                    ' Open connection
                    conn.Open()

                    ' Execute the command and get the inserted PaymentID
                    paymentID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        ' Connection string

        Return paymentID
    End Function
    Public Function Att_InsertNewAttEmployeePayment(
    ByVal paymentDate As Date,
    ByVal employeeID As Integer,
    ByVal paymentAmount As Decimal,
    ByVal paymentNote As String,
    ByVal paymentType As Integer,
    ByVal paymentBranch As String,
    ByVal status As String,
    ByVal inputDateTime As DateTime,
    ByVal managerNote As String,
    ByVal hrNote As String,
    ByVal entryDate As Date,
    ByVal salaryDocumentID As Integer
) As Integer

        Dim paymentID As Integer = 0
        Try
            Dim connectionString As String = My.Settings.Item("TrueTimeConnectionString")

            ' SQL query to insert data and return the PaymentID
            Dim sql As String = "INSERT INTO AttEmployeePayments " &
                        "(PaymentDate, EmployeeID, PaymentAmount, PaymentNote, PaymentType, PaymentBranch, Status, InputDateTime, ManagerNote, HrNote, Entry_date,SalaryDocumentID) " &
                        "OUTPUT INSERTED.PaymentID " &
                        "VALUES (@PaymentDate, @EmployeeID, @PaymentAmount, @PaymentNote, @PaymentType, @PaymentBranch, @Status, @InputDateTime, @ManagerNote, @HrNote, @Entry_date,@SalaryDocumentID);"

            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(sql, conn)
                    ' Add parameters
                    cmd.Parameters.AddWithValue("@PaymentDate", Format(paymentDate, "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                    cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount)
                    cmd.Parameters.AddWithValue("@PaymentNote", paymentNote)
                    cmd.Parameters.AddWithValue("@PaymentType", paymentType)
                    cmd.Parameters.AddWithValue("@PaymentBranch", paymentBranch)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@InputDateTime", Format(inputDateTime, "yyyy-MM-dd HH:mm:ss"))
                    cmd.Parameters.AddWithValue("@ManagerNote", managerNote)
                    cmd.Parameters.AddWithValue("@HrNote", hrNote)
                    cmd.Parameters.AddWithValue("@Entry_date", Format(inputDateTime, "yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@SalaryDocumentID", salaryDocumentID)

                    ' Open connection
                    conn.Open()

                    ' Execute the command and get the inserted PaymentID
                    paymentID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        ' Connection string

        Return paymentID
    End Function
    Public Function Att_InsertNewAttEmployeeSavingsFund(
    ByVal salaryDocumentID As Integer,
    ByVal employeeID As Integer,
    ByVal docDate As Date,
    ByVal notes As String
) As Integer
        Dim sql As New SQLControl
        Dim ID As Integer = 0
        Dim companyContribution As Decimal
        Dim personalContribution As Decimal
        Dim salaryMonth As Decimal
        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [dbo].[Settings] Where [SettingName]='HR_CompanyContributionPercentage' ")
            companyContribution = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            companyContribution = 0
        End Try
        Try
            sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [dbo].[Settings] Where [SettingName]='HR_PersonalContributionPercentage' ")
            personalContribution = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            personalContribution = 0
        End Try


        Try
            sql.SqlTrueAccountingRunQuery(" select [SalaryMonth] from [dbo].[AttRawatebArchive] where ID=" & salaryDocumentID)
            salaryMonth = sql.SQLDS.Tables(0).Rows(0).Item("SalaryMonth")
        Catch ex As Exception
            salaryMonth = 0
        End Try

        If My.Forms.Main.ItemDataBaseName.Caption = "RCCI" Then
            Dim _CostOfLiving As Decimal = 0
            _CostOfLiving = GetAdditionsByTypeID(3, employeeID, Format(docDate, "yyyy-MM-dd"), Format(docDate, "yyyy-MM-dd"))
            Dim _LeavesPayments As Decimal = 0
            _LeavesPayments = GetDiscountByPaymentTypeID(5, employeeID, Format(docDate, "yyyy-MM-dd"), Format(docDate, "yyyy-MM-dd"))
            salaryMonth = salaryMonth + _CostOfLiving - _LeavesPayments
        End If


        If personalContribution <> 0 And companyContribution <> 0 And salaryMonth <> 0 Then
            Try
                Dim connectionString As String = My.Settings.Item("TrueTimeConnectionString")

                ' SQL query to insert data and return the PaymentID
                Dim sqlstring As String = "INSERT INTO SavingsFund " &
                            "(SalaryDocumentID, EmployeeID, CompanyContribution, PersonalContribution, DocDate,Notes,InputUser) " &
                            "OUTPUT INSERTED.ID " &
                            "VALUES (@SalaryDocumentID, @EmployeeID, @CompanyContribution, @PersonalContribution, @DocDate,@Notes,@InputUser);"

                Using conn As New SqlConnection(connectionString)
                    Using cmd As New SqlCommand(sqlstring, conn)
                        ' Add parameters
                        cmd.Parameters.AddWithValue("@SalaryDocumentID", salaryDocumentID)
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
                        cmd.Parameters.AddWithValue("@CompanyContribution", salaryMonth * companyContribution / 100)
                        cmd.Parameters.AddWithValue("@PersonalContribution", salaryMonth * personalContribution / 100)
                        cmd.Parameters.AddWithValue("@DocDate", Format(docDate, "yyyy-MM-dd"))
                        cmd.Parameters.AddWithValue("@Notes", notes)
                        cmd.Parameters.AddWithValue("@InputUser", GlobalVariables.CurrUser)

                        ' Open connection
                        conn.Open()

                        ' Execute the command and get the inserted PaymentID
                        ID = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        Try
            If ID > 0 Then
                sql.SqlTrueAccountingRunQuery(" Update AttRawatebArchive Set SavingsFund=" & salaryMonth * personalContribution / 100 & " Where ID=" & salaryDocumentID)
            End If
        Catch ex As Exception

        End Try





        ' Connection string

        Return ID
    End Function
    Public Function GetDiscountByPaymentTypeID(type As Integer, emplID As Integer, fromDate As String, toDate As String) As Decimal
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = " Select IsNull(sum([PaymentAmount]),0) as _sum 
                                        from [AttEmployeePayments] 
                                        where [PaymentType]=" & type & " And EmployeeID=" & emplID & "  
                                              And PaymentDate between '" & Format(CDate(fromDate), "yyyy-MM-dd") & "' And '" & Format(CDate(toDate), "yyyy-MM-dd") & "'  and [Status]= 1"
            sql.SqlTrueTimeRunQuery(sqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("_sum")
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function GetAdditionsByTypeID(type As Integer, emplID As Integer, fromDate As String, toDate As String) As Decimal
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = " Select IsNull(sum([AdditionAmount]),0) as _sum 
                                        from [AttEmployeeAdditions] 
                                        where [AdditionType]=" & type & " And EmployeeID=" & emplID & "  
                                              And AdditionDate between '" & Format(CDate(fromDate), "yyyy-MM-dd") & "' And '" & Format(CDate(toDate), "yyyy-MM-dd") & "'"
            sql.SqlTrueTimeRunQuery(sqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("_sum")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    'Public Function Att_InsertNewDiscount(PaymentDate As String, EmployeeID As Integer, PaymentAmount As Decimal, PaymentNote As String, PaymentType As Integer, Branch As String) As Integer
    '    Try
    '        Dim sql As New SQLControl
    '        Dim InsertString As String = " INSERT INTO [AttEmployeePayments]
    '       ([PaymentDate]
    '       ,[EmployeeID]
    '       ,[PaymentAmount]
    '       ,[PaymentNote]
    '       ,[PaymentType],[PaymentBranch],[Status])
    ' VALUES
    '       ('" & PaymentDate & "'
    '       ,'" & EmployeeID & "'
    '       ," & PaymentAmount & "
    '       ,N'" & PaymentNote & "'
    '       ,N'" & PaymentType & "'
    '       ,N'" & Branch & "',1)"

    '        If sql.SqlTrueTimeRunQuery(InsertString) = True Then
    '            XtraMessageBox.Show(" تم حفظ البيانات بنجاح ")
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Function
    Public Sub Att_IssueDiscountAndAddsWhenPublishSalary(_EmployeeID As Integer, _Date As Date, _SalaryDocumentID As Integer)
        Dim _table As New DataTable
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = "   SELECT  [ID]
      ,[TermID]
      ,[TermType]
      ,[Amount]
      ,[FromDate]
      ,[ToDate]
      ,[Notes]
      ,[EmployeeID]
      ,[TermStatus]
      ,IsNull([Percentage],0) as Percentage
      ,[Fields]
      ,IsNull([FixOrPercentage],'Fixed') As FixOrPercentage
  FROM [dbo].[AttFixedDiscountsAndBonuses] Where EmployeeID=" & _EmployeeID & " And TermStatus=1 And '" & Format(_Date, "yyyy-MM-dd") & "' Between FromDate And ToDate  "
        sql.SqlTrueTimeRunQuery(sqlstring)
        _table = sql.SQLDS.Tables(0)
        If _table.Rows.Count > 0 Then
            For i = 0 To _table.Rows.Count - 1
                Dim _TermType As String = sql.SQLDS.Tables(0).Rows(i).Item("TermType")
                Dim _Amount As Decimal
                Dim _Notes As String = sql.SQLDS.Tables(0).Rows(i).Item("Notes")
                Dim _TermID As Integer = CInt(sql.SQLDS.Tables(0).Rows(i).Item("TermID"))
                Dim _ID As Integer = CInt(sql.SQLDS.Tables(0).Rows(i).Item("ID"))
                Dim _FixOrPercentage As String = CStr(sql.SQLDS.Tables(0).Rows(i).Item("FixOrPercentage"))
                Dim _Percentage As Decimal = CDec(sql.SQLDS.Tables(0).Rows(i).Item("Percentage"))
                If _FixOrPercentage = "Percentage" Then
                    Dim _GrossSalary As Decimal
                    _GrossSalary = GetAmountForIssueDiscountAndAddsForPercentage(_ID, _SalaryDocumentID)
                    _Amount = _GrossSalary * _Percentage / 100
                Else
                    _Amount = CDec(sql.SQLDS.Tables(0).Rows(i).Item("Amount"))
                End If
                Select Case _TermType
                    Case "Addition"
                        Att_InsertNewAttEmployeeAddition(_Date, _EmployeeID, _Amount, _Notes, _TermID, _SalaryDocumentID)
                    Case "Discount"
                        Att_InsertNewAttEmployeePayment(_Date, _EmployeeID, _Amount, _Notes, _TermID, String.Empty, 1, Now(), String.Empty, String.Empty, Today(), _SalaryDocumentID)
                End Select
            Next
        End If
    End Sub

    Private Function GetAmountForIssueDiscountAndAddsForPercentage(_ID As Integer, _SalaryDocumentID As Integer) As Decimal
        Try
            Dim sqlString As String = "  Select Fields from AttFixedDiscountsAndBonuses where  ID=" & _ID
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(sqlString)
            Dim _Fields As String = sql.SQLDS.Tables(0).Rows(0).Item("Fields")
            sqlString = " Select  " & _Fields & " As Amount from AttRawatebArchive where ID=" & _SalaryDocumentID
            sql.SqlTrueTimeRunQuery(sqlString)
            Dim _Amount As Decimal = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Amount"))
            Return _Amount
        Catch ex As Exception
            Return 0
        End Try
    End Function



    Public Function AttConectionString() As String
        AttConectionString = String.Empty

        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery("select SettingValue  from Settings where SettingName='AttFilePath'")
            Dim AttPath As String = String.Empty
            AttPath = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            AttConectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AttPath
            Return AttConectionString
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return AttConectionString

    End Function
    Function CalculateTotalDuration(dt As DataTable) As String
        Dim _timefunction As New TimeFunctions
        Dim totalDuration As TimeSpan = TimeSpan.Zero

        ' Iterate through each row in the DataTable
        For Each row As DataRow In dt.Rows
            ' Retrieve the TimeSpan value from the "Duration" column
            Dim duration As TimeSpan = DirectCast(row("TotalDurations"), TimeSpan)
            ' Add the duration to the total
            totalDuration = totalDuration.Add(duration)
        Next

        ' Return the total duration
        Return _timefunction.ConvertTimeSpan_hhmmm_ToString(totalDuration)
    End Function
    Public Function CAPEMySqlString() As String
        'Return "server=tts.com.ps;Port=3306; User ID=ttsttstt_mazen; password=mazen@2020; database=ttsttstt_resturant"
        ' Return "server=127.0.0.1;Port=3306; User ID=root; password=shadi1973amer2003tamer2004; database=safeway_cape"
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "select SettingValue  From Settings where SettingName='CAPEConnectionString'"
            sql.SqlTrueTimeRunQuery(SQLString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Sub CeateMessagesTempTable()
        Try
            _SMSMessagesTempTable.Columns.Add("SMSType", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("SMSDetails", GetType(String))
            _SMSMessagesTempTable.Columns.Add("RefNo", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("RefMobile", GetType(String))
            _SMSMessagesTempTable.Columns.Add("RefName", GetType(String))
            _SMSMessagesTempTable.Columns.Add("AccrualDateTime", GetType(DateTime))
            _SMSMessagesTempTable.Columns.Add("Sent", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("Action", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("SMSStatus", GetType(String))
            _SMSMessagesTempTable.Columns.Add("DocName", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("DocID", GetType(Integer))
            _SMSMessagesTempTable.Columns.Add("DocCode", GetType(String))
            _SMSMessagesTempTable.Columns.Add("DocData", GetType(String))
            _SMSMessagesTempTable.Columns.Add("SmsID", GetType(Integer))
        Catch ex As Exception

        End Try
    End Sub

    Public Function CheckIfAddition(EmployeeID As String, DateFrom As DateTime, DateTo As DateTime) As Boolean
        Dim _AdditionFound As Boolean
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = "  select ISNULL(SUM(AdditionAmount),0) as Addition FROM [AttEmployeeAdditions] 
                                            where [EmployeeID]='" & EmployeeID & "' and 
                                            [AdditionDate] between '" & Format(DateFrom, "yyyy-MM-dd") & "' 
                                            and '" & Format(DateTo, "yyyy-MM-dd") & "'"
            sql.SqlTrueTimeRunQuery(SelectString)
            If sql.SQLDS.Tables(0).Rows(0).Item("Addition") > 0 Then
                _AdditionFound = True
            Else
                _AdditionFound = False
            End If
        Catch ex As Exception
            _AdditionFound = False
        End Try
        Return _AdditionFound
    End Function

    Public Function CheckIfAdmin()

        Try
            Dim sql As New SQLControl
            Dim SqlString As String = "Select AccessType  from EmployeesData where EmployeeID= '" & GlobalVariables.CurrUser & "'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows(0).Item("AccessType") = "Admin" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function CheckIfEmployeeHasTrans(_EmpID As Integer, _DateFrom As Date, _DateTo As Date) As Boolean
        Dim sql As New SQLControl
        Dim sqlstring As String = " select count(*) from AttCHECKINOUT 
                                    where USERID=" & _EmpID & " 
                                          and CHECKTIME between '" & Format(_DateFrom, "yyyy-MM-dd 00:00:00") & "' and '" & Format(_DateTo, "yyyy-MM-dd 23:59:59") & "'"
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows(0).Item(0) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckIfFirstUsed() As Boolean
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery("Select SettingValue as FirstUsed  from Settings where SettingName = 'FirstUsed'")
            Dim FirstValue As String = sql.SQLDS.Tables(0).Rows(0).Item("FirstUsed")
            If FirstValue = "0" Then Return True
            If FirstValue = "1" Then Return False
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        Return CheckIfFirstUsed()
    End Function
    Public Function CheckIfFormExist(FormName As String) As Boolean
        Dim SqlString As String = "Select [ID] as Form from AccessForms where FormName= '" & FormName & "'"
        Try
            Dim _FormName As String
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SqlString)
            _FormName = sql.SQLDS.Tables(0).Rows(0).Item("Form")
            Return True
            '   InsertLogs(GlobalVariables.CurrUser, "فحص وجود الفورم", "CheckIfFormExist", Now, "True", "", "", SqlString)
        Catch ex As Exception
            '   InsertLogs(GlobalVariables.CurrUser, "فحص وجود الفورم", "CheckIfFormExist", Now, "False", "", ex.ToString, SqlString)
            '  Return False
            Return True
            '  MsgBox(ex.ToString)
        End Try



        Return True


    End Function
    Public Function CheckIfHasAccessToEditAttendanceTrans() As Boolean
        Dim _AttAllowAttUserToEditAttTrans As Boolean
        If GlobalVariables._UserAccessType = 2 Then
            Try
                Dim Sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " select SettingValue from Settings where SettingName='AttAllowAttUserToEditAttTrans'   "
                Sql.SqlTrueAccountingRunQuery(sqlstring)
                _AttAllowAttUserToEditAttTrans = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Catch ex As Exception
                _AttAllowAttUserToEditAttTrans = False
            End Try
        Else
            _AttAllowAttUserToEditAttTrans = True
        End If

        Return _AttAllowAttUserToEditAttTrans
    End Function

    Public Function CheckIfHasAccessToAddAttendanceTrans() As Boolean
        Dim _AttAllowAttUserToAddAttTrans As Boolean
        If GlobalVariables._UserAccessType = 2 Then
            Try
                Dim Sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " select SettingValue from Settings where SettingName='AttAllowAttUserToAddAttTrans'   "
                Sql.SqlTrueAccountingRunQuery(sqlstring)
                _AttAllowAttUserToAddAttTrans = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Catch ex As Exception
                _AttAllowAttUserToAddAttTrans = False
            End Try
        Else
            _AttAllowAttUserToAddAttTrans = True
        End If

        Return _AttAllowAttUserToAddAttTrans
    End Function

    Public Function CheckIfHasAccessToDeleteAttendanceTrans() As Boolean
        Dim _AttAllowAttUserToDeleteAttTrans As Boolean
        If GlobalVariables._UserAccessType = 2 Then
            Try
                Dim Sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " select SettingValue from Settings where SettingName='AttAllowAttUserToDeleteAttTrans'   "
                Sql.SqlTrueAccountingRunQuery(sqlstring)
                _AttAllowAttUserToDeleteAttTrans = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Catch ex As Exception
                _AttAllowAttUserToDeleteAttTrans = False
            End Try
        Else
            _AttAllowAttUserToDeleteAttTrans = True
        End If

        Return _AttAllowAttUserToDeleteAttTrans
    End Function

    Public Function CheckIfPayment(EmployeeID As String, DateFrom As DateTime, DateTo As DateTime) As Boolean
        Dim _PaymentFound As Boolean
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = "  select ISNULL(SUM(PaymentAmount),0) as payment FROM [AttEmployeePayments] 
                                            where [Status]=1 And [EmployeeID]='" & EmployeeID & "' and 
                                            [PaymentDate] between '" & Format(DateFrom, "yyyy-MM-dd") & "' 
                                            and '" & Format(DateTo, "yyyy-MM-dd") & "'"
            sql.SqlTrueTimeRunQuery(SelectString)
            If sql.SQLDS.Tables(0).Rows(0).Item("payment") > 0 Then
                _PaymentFound = True
            Else
                _PaymentFound = False
            End If
        Catch ex As Exception
            _PaymentFound = False
        End Try
        Return _PaymentFound
    End Function
    Public Function CheckIfVocations(EmployeeID As String, DateFrom As DateTime, DateTo As DateTime) As Boolean
        Dim _VocationsFound As Boolean
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = " SELECT count([VocID]) as VocationNo
                                           FROM    [dbo].[Vocations]    WHERE  
                                           EmployeeID='" & EmployeeID & "' and 
                                           ( (FromDate>='" & Format(DateFrom, "yyyy-MM-dd") & "' Or ToDate<='" & Format(DateTo, "yyyy-MM-dd") & "'))"
            sql.SqlTrueTimeRunQuery(SelectString)
            If sql.SQLDS.Tables(0).Rows(0).Item("VocationNo") > 0 Then
                _VocationsFound = True
            Else
                _VocationsFound = False
            End If
        Catch ex As Exception
            _VocationsFound = False
        End Try

        If _VocationsFound = False Then
            Try
                Dim sql As New SQLControl
                Dim SelectString As String = " SELECT count([VocID]) as VocationNo
                                               FROM    [dbo].[Vocations]    WHERE  
                                               EmployeeID='" & EmployeeID & "' 
                                               And ( '" & Format(DateFrom, "yyyy-MM-dd") & "' between FromDate and ToDate  )"
                sql.SqlTrueTimeRunQuery(SelectString)
                If sql.SQLDS.Tables(0).Rows(0).Item("VocationNo") > 0 Then
                    _VocationsFound = True
                Else
                    _VocationsFound = False
                End If
            Catch ex As Exception
                _VocationsFound = False
            End Try
        End If



        Return _VocationsFound
    End Function



    Public Function CheckInternetConnection() As Boolean
        Try
            If My.Computer.Network.Ping("www.google.com") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try


    End Function
    Public Function CheckNumberIsNullOrNothing(ByVal value As Object) As Integer
        If value Is DBNull.Value OrElse value Is Nothing OrElse IsDBNull(value) Then
            Return 0
        End If

        ' If the value is not DBNull or Nothing, return the actual value
        Return Convert.ToInt32(value)
    End Function



    Public Function CompareDataTables(ByVal first As DataTable, ByVal second As DataTable) As DataTable
        first.TableName = "FirstTable"
        second.TableName = "SecondTable"
        Dim table As DataTable = New DataTable("Difference")
        Try
            Using ds As DataSet = New DataSet()
                ds.Tables.AddRange(New DataTable() {first.Copy(), second.Copy()})
                Dim firstcolumns As DataColumn() = New DataColumn(ds.Tables(0).Columns.Count - 1) {}
                For i As Integer = 0 To firstcolumns.Length - 1
                    firstcolumns(i) = ds.Tables(0).Columns(i)
                Next

                Dim secondcolumns As DataColumn() = New DataColumn(ds.Tables(1).Columns.Count - 1) {}
                For i As Integer = 0 To secondcolumns.Length - 1
                    secondcolumns(i) = ds.Tables(1).Columns(i)
                Next

                Dim r As DataRelation = New DataRelation(String.Empty, firstcolumns, secondcolumns, False)
                ds.Relations.Add(r)
                For i As Integer = 0 To first.Columns.Count - 1
                    table.Columns.Add(first.Columns(i).ColumnName, first.Columns(i).DataType)
                Next

                table.BeginLoadData()
                For Each parentrow As DataRow In ds.Tables(0).Rows
                    Dim childrows As DataRow() = parentrow.GetChildRows(r)
                    If childrows Is Nothing OrElse childrows.Length = 0 Then table.LoadDataRow(parentrow.ItemArray, True)
                Next

                table.EndLoadData()
                CompareDataTables = table
                Return CompareDataTables
            End Using

        Finally

        End Try

    End Function
    Public Function CreatAttPreccessFromMobileTable() As DataTable
        Dim ProcessType As New DataTable
        ProcessType.Columns.Add("No", GetType(Integer))
        ProcessType.Columns.Add("ProcessType", GetType(String))
        ProcessType.Columns.Add("ProcessTypeE", GetType(String))

        ProcessType.Rows.Add(1, "السماح بعمل حركات دوام", "1")
        ProcessType.Rows.Add(2, "رفض حركات الدوام", "2")
        ProcessType.Rows.Add(3, "ارسال الحركات الى مركز الطلبات", "3")

        Return ProcessType
    End Function

    Public Sub CreateFirstUser()

        Try
            Dim SQLString As String = " Insert Into Users ( UserID,Password,UserType ) Values ('Admin','Admin','Admin')"
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SQLString)
            MsgBox("تم تعريف المستخدم الرئيسي")
        Catch ex As Exception
            Exit Sub
        End Try



    End Sub

    Public Sub CreateProcessCol()
        Dim sql As New SQLControl
        Dim ConnString As String = AttConectionString()
        Dim SqlString As String = "ALTER TABLE CHECKINOUT ADD COLUMN AttProcess Number"

        Try
            Using conn As New OleDbConnection(ConnString)
                Using cmd As New OleDbCommand(SqlString, conn)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("تم اضافة عمود process")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function CreateRentDocumentsStatusTable() As DataTable
        Dim table As New DataTable
        table.Columns.Add("DocStatus", GetType(Integer))
        table.Columns.Add("DocName", GetType(String))
        table.Rows.Add(-1, "الكل")
        table.Rows.Add(1, "مفتوح")
        table.Rows.Add(2, "مغلق")
        table.Rows.Add(3, "مفوتر")
        table.Rows.Add(0, "محذوف")
        Return table
    End Function
    Public Function CreateUserAccessTypeTable() As DataTable

        Dim ProcessType As New DataTable
        ProcessType.Columns.Add("TypeID", GetType(Integer))
        ProcessType.Columns.Add("UserType", GetType(String))
        ProcessType.Columns.Add("UserTypeE", GetType(String))

        ProcessType.Rows.Add(1, "مدير", "Manager")
        ProcessType.Rows.Add(2, "مراقب دوام", "Attendance")
        ProcessType.Rows.Add(3, "كاشير", "Cashier")
        'ProcessType.Rows.Add(4, "كاشير مطعم", "Restaurant")
        ProcessType.Rows.Add(5, "الاشتراكات", "Subscriptions")
        ProcessType.Rows.Add(99, "شاشة الأصناف", "ItemScreen")
        ProcessType.Rows.Add(98, "تقارير مالية", "FinancialReport")
        ProcessType.Rows.Add(97, "ادارة المواعيد", "Tasks")
        ProcessType.Rows.Add(96, "ادارة بيانات الموظفين", "Tasks")
        ProcessType.Rows.Add(95, "محاسب ادخال", "Accounting Entry Data")
        ProcessType.Rows.Add(94, "ادارة مستودع", "Warehouse Manager")
        ProcessType.Rows.Add(93, "شاشة الطلبيات الداخلية", "Internal Orders")
        ProcessType.Rows.Add(92, "ادارة الاقساط", "Installments")
        ProcessType.Rows.Add(91, "تدقيق الرواتب", "Salaries Audit")

        Return ProcessType

    End Function
    'Public Function GetEmpData(EmpID As String) As Tuple(Of String, String, String, String, String, String, String)
    '    Dim EmployeeName As String = "0"
    '    Dim JobName As String = "0"
    '    Dim Department As String = "0"
    '    Dim Branch As String = "0"
    '    Dim SalaryAccountNo As String = "0"
    '    Dim DateOfStart As String = "0"
    '    Dim SalaryCurrency As String = "0"

    '    Try
    '        Dim sql As New SQLControl
    '        Dim SqlSelect As String = " Select [EmployeeName],[JobName],[Department],[Branch],SalaryAccountNo,DateOfStart,SalaryCurrency
    '                                    FROM         [EmployeesData]
    '                                    WHERE     (EmployeeID  ='" & EmpID & "') "
    '        sql.SqlTrueTimeRunQuery(SqlSelect)
    '        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
    '            Return New Tuple(Of String, String, String, String, String, String, String)(EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency)
    '        Else
    '            EmployeeName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName").ToString)
    '            JobName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("JobName").ToString)
    '            Department = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Department").ToString)
    '            Branch = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Branch").ToString)
    '            SalaryAccountNo = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryAccountNo").ToString)
    '            DateOfStart = CStr(sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart").ToString)
    '            SalaryCurrency = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryCurrency").ToString)

    '        End If
    '    Catch ex As Exception
    '        EmployeeName = "0"
    '        JobName = "0"
    '        Department = "0"
    '        Branch = "0"
    '        SalaryAccountNo = "0"
    '        DateOfStart = "01-01-1900"
    '        SalaryCurrency = " "

    '    End Try

    '    Return New Tuple(Of String, String, String, String, String, String, String)(EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency)

    'End Function

    Public Function CreateVocationsSource() As DataTable
        Dim Sr As New DataTable
        Sr.Columns.Add("sourcename", GetType(String))
        Sr.Columns.Add("sourcenameAr", GetType(String))
        Sr.Rows.Add("vocation", "اجازة")
        'Sr.Rows.Add("leaves", "مغادرة")
        Sr.Rows.Add("adjust", "تسوية")
        Return Sr
    End Function

    Public Function CreatPreccessTypeTable() As DataTable
        Dim ProcessType As New DataTable
        ProcessType.Columns.Add("TypeID", GetType(Integer))
        ProcessType.Columns.Add("ProccessType", GetType(String))
        ProcessType.Columns.Add("ProccessTypeE", GetType(String))

        ProcessType.Rows.Add(1, "دوام ثابت وردية", "Shift")
        ProcessType.Rows.Add(2, "ساعات يومية مطلوبة", "Required Houres")
        ProcessType.Rows.Add(3, "راتب /الساعة", "Salary / Hour")
        ProcessType.Rows.Add(4, "راتب ثابت لا يتطلب دوام", "FixedSalary")
        ProcessType.Rows.Add(5, "دوام بوجود حركة", "Existence Approve")
        ProcessType.Rows.Add(6, "ساعات شهرية مطلوبة", "Monthly Required Houres")
        ProcessType.Rows.Add(7, "راتب يومي", "Daily Salary")
        'ProcessType.Rows.Add(7, "ساعات شهرية مطلوبة", "Monthly Required Houres")
        Return ProcessType
    End Function
    Public Function CreatSubscriptionTypesTable() As DataTable
        Dim ProcessType As New DataTable
        ProcessType.Columns.Add("id", GetType(Integer))
        ProcessType.Columns.Add("Name", GetType(String))

        ProcessType.Rows.Add(0, "مجمد")
        ProcessType.Rows.Add(1, "فعال")
        ProcessType.Rows.Add(2, "تم تجديده")
        ProcessType.Rows.Add(3, "غير فعال")

        Return ProcessType
    End Function
    Public Function DecodingData(_Text As String) As String
        Dim cipherText As String = _Text
        Dim password As String = "ourcompany"
        Dim wrapper As New Simple3Des(password)
        Dim plainText As String = String.Empty
        ' DecryptData throws if the wrong password is used.
        Try
            plainText = wrapper.DecryptData(cipherText)
        Catch ex As System.Security.Cryptography.CryptographicException
            '  MsgBox("The data could not be decrypted with the password.")
        End Try
        Return plainText
    End Function

    Public Sub DeleteLocalRegData()
        'Dim Sql As New SQLControl
        'Sql.SqlTrueTimeRunQuery(" Delete  From DevicesReg where
        'DeviceKey='" & GlobalVariables.LocalDeviceKey & "'")
        'MsgBox("تم حذف سجل التسجيل")
    End Sub

    Public Sub EditProcess()
        Dim SQLString As String = " Update CHECKINOUT set AttProcess = 1   "
        Try
            Select Case GlobalVariables._AttConnectionType
                Case "Access"
                    Dim con = New System.Data.OleDb.OleDbConnection With {.connectionString = AttConectionString()}
                    con.Open()
                    Dim cmd As OleDbCommand = New OleDbCommand(SQLString, con)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    con.Close()
                Case "Sql"
                    Dim Sql As New SQLControl
                    Sql.SqlTrueTimeRunQuery(SQLString)
            End Select
            InsertLogs(GlobalVariables.CurrUser, "EditProcess", "EditProcess", Now, String.Empty, "تم تعديل عمود Processed", String.Empty, SQLString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            InsertLogs(GlobalVariables.CurrUser, "EditProcess", "EditProcess", Now, String.Empty, "خطا في تعديل عمود Processed", ex.ToString, String.Empty)
        End Try
    End Sub ' تعديل عمودالقراءة من فراغ الى قيمة 1

    Public Function EncodingData(_Text As String) As String
        Dim plainText As String = _Text
        Dim password As String = "ourcompany"
        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)
        Return cipherText
    End Function

    Function FunSendSmS2(destination As String, sms As String) As String
        'If CInt(GetSMSBalance()) = 0 Then MsgBox("لا يوجد رصيد") : Return "لا يوجد رصيد" : Exit Function
        destination = CType(Val(destination), String)

        Select Case Len(destination)
            Case 9
                destination = "972" & destination
            Case 12
                destination = destination
            Case Else
                Return "False"
        End Select
        Dim strUrl As String = "http://int.mtcsms.com/sendsms.aspx?username=Meqdam&password=Truetime@20!8&from=TrueTime&to=" & destination & "&msg=" & sms & "&type=0"
        Dim request As WebRequest = HttpWebRequest.Create(strUrl)
        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
        Dim s As Stream = response.GetResponseStream()
        Dim readStream As New StreamReader(s)
        Dim dataString As String = readStream.ReadToEnd()
        Dim Result As String = dataString.ToString
        response.Close()
        s.Close()
        readStream.Close()
        Return Result
    End Function


    Public Function GetAttAdjustmentsForHoresRequired(_EmpNo As Integer, _Date As Date, _BonusOrLeave As Integer) As TimeSpan
        Dim Period As TimeSpan = TimeSpan.Zero
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   with cte
                            as
                            ( select case when left([PeriodFactor],1)='-' then -1 else 1 end as multiply,
                            right([PeriodFactor],8) as [PeriodFactor],
                            --get hours in seconds:
                            DATEPART(HOUR,right([PeriodFactor],8)) * 3600 AS h_in_s,
                            --get minutes in seconds:
                            DATEPART(MINUTE,right([PeriodFactor],8)) * 60 AS m_in_s,
                            --get seconds:
                            DATEPART(SECOND,right([PeriodFactor],8)) AS s
                            from AttAdjustmentTrans A left join AttAdjustmentTypes T on A.AdjustName=T.ID   where T.[type]=" & _BonusOrLeave & " And [EmpNo]=" & _EmpNo & "  And TransDate ='" & Format(_Date, "yyyy-MM-dd") & "'
                            )
                            select case when sum((c.h_in_s + c.m_in_s + c.s) * multiply) < 0
                            then '-' + CONVERT(varchar,DATEADD(s,ABS(sum((c.h_in_s + c.m_in_s + c.s) * multiply)),0),114)
                            else CONVERT(varchar,DATEADD(s,sum((c.h_in_s + c.m_in_s + c.s) * multiply),0),114)
                            end as TotalTime
                            from cte c "
            If sql.SqlTrueTimeRunQuery(sqlstring) Then
                Dim _string As String
                If Len(sql.SQLDS.Tables(0).Rows(0).Item("TotalTime")) = 12 Then
                    _string = Left(sql.SQLDS.Tables(0).Rows(0).Item("TotalTime"), 5)
                    Period = TimeSpan.Parse(Strings.Left(_string, 9))
                ElseIf Len(sql.SQLDS.Tables(0).Rows(0).Item("TotalTime")) = 13 Then
                    _string = Left(sql.SQLDS.Tables(0).Rows(0).Item("TotalTime"), 6)
                    Period = TimeSpan.Parse(Strings.Left(_string, 9))
                Else
                    _string = Left(sql.SQLDS.Tables(0).Rows(0).Item("TotalTime"), 5)
                    Period = TimeSpan.Parse(Strings.Left(_string, 9))
                End If

            End If
        Catch ex As Exception

        End Try
        Return Period
    End Function
    'Public Function GetAttAdjustmentsForMonthAdjustments(_EmpNo As Integer, _Month As Integer, _Year As Integer) As TimeSpan
    '    Dim Period As TimeSpan = TimeSpan.Zero
    '    Try
    '        Dim sql As New SQLControl
    '        Dim sqlstring As String
    '        sqlstring = "   with cte
    '                        as
    '                        ( select case when left([Priod],1)='-' then -1 else 1 end as multiply,
    '                        right([Priod],8) as [Priod],
    '                        --get hours in seconds:
    '                        DATEPART(HOUR,right([Priod],8)) * 3600 AS h_in_s,
    '                        --get minutes in seconds:
    '                        DATEPART(MINUTE,right([Priod],8)) * 60 AS m_in_s
    '                        from [AttMonthlyAdjustments] A   where   [EmpID]=" & _EmpNo & "  And [Month] =" & _Month & " and [Year]=" & _Year & "
    '                        )
    '                        select case when sum((c.h_in_s + c.m_in_s ) * multiply) < 0
    '                        then '-' + CONVERT(varchar,DATEADD(s,ABS(sum((c.h_in_s + c.m_in_s ) * multiply)),0),114)
    '                        else CONVERT(varchar,DATEADD(s,sum((c.h_in_s + c.m_in_s ) * multiply),0),114)
    '                        end as TotalTime
    '                        from cte c  "
    '        If sql.SqlTrueTimeRunQuery(sqlstring) Then
    '            Dim _string As String
    '            _string = sql.SQLDS.Tables(0).Rows(0).Item("TotalTime")
    '            Period = TimeSpan.Parse(Strings.Left(_string, 8))
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Return Period
    'End Function
    Public Function GetAttAdjustmentsForMonthAdjustments(_EmpNo As Integer, _Month As Integer, _Year As Integer) As TimeSpan
        Dim Period As TimeSpan = TimeSpan.Zero
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   select Sum(Hm) +Sum(M) as TotalMinutes From
                            (
                            Select Cast(left(Priod,2)*60 as Int) As Hm,Cast(right(Priod,2) as int) as M from [AttMonthlyAdjustments] where EmpID=" & _EmpNo & " And [Month] =" & _Month & " and [Year]=" & _Year & "
                            ) A  "
            If sql.SqlTrueTimeRunQuery(sqlstring) Then
                Dim _TotalMinutes As Decimal
                _TotalMinutes = CDec(sql.SQLDS.Tables(0).Rows(0).Item("TotalMinutes"))
                Period = TimeSpan.FromMinutes(_TotalMinutes)
            End If
        Catch ex As Exception

        End Try
        Return Period
    End Function

    Public Function GetAttendanceTrans(EmpID As String, _DateFrom As Date, _DateTo As Date) As DataTable
        Dim ListDays As New DataTable
        Dim PlaneTable As New DataTable
        Dim DD As New DataColumn With {
            .AllowDBNull = False,
            .Unique = True
        }
        DD = ListDays.Columns.Add("TransDate", GetType(DateTime))
        ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("PlaneID", GetType(Integer))
        ListDays.Columns.Add("EmpID", GetType(String))
        ListDays.Columns.Add("EmployeeName", GetType(String))
        ListDays.Columns.Add("RequiredDailyHoures", GetType(TimeSpan))
        ListDays.Columns.Add("RestDailyHoures", GetType(TimeSpan))
        ListDays.Columns.Add("StartTimeReal", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal", GetType(DateTime))
        ListDays.Columns.Add("ElapseTime", GetType(TimeSpan))
        ListDays.Columns.Add("ElapseTimePlane", GetType(TimeSpan))
        ListDays.Columns.Add("TransInID", GetType(Integer))
        ListDays.Columns.Add("TransOutID", GetType(Integer))
        ListDays.Columns.Add("EditedTypeIn", GetType(String))
        ListDays.Columns.Add("EditedTypeOut", GetType(String))
        ListDays.Columns.Add("StartTimeReal1", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal1", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal2", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal2", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal3", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal3", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal4", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal4", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal5", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal5", GetType(DateTime))
        ListDays.Columns.Add("Duration1", GetType(TimeSpan))
        ListDays.Columns.Add("Duration2", GetType(TimeSpan))
        ListDays.Columns.Add("Duration3", GetType(TimeSpan))
        ListDays.Columns.Add("Duration4", GetType(TimeSpan))
        ListDays.Columns.Add("Duration5", GetType(TimeSpan))
        ListDays.Columns.Add("TotalDurations", GetType(TimeSpan))
        ListDays.Columns.Add("AttStatus", GetType(String))
        ListDays.Columns.Add("NetDurations", GetType(TimeSpan))
        ListDays.Columns.Add("SalaryAccountNo", GetType(String))
        ListDays.Columns.Add("AttendentDays", GetType(Integer))
        ListDays.Columns.Add("Note1", GetType(String))

        Dim TempOutID As Integer = 0
        Dim PlaneID As Integer = 0
        Dim Sqlstring As String
        Dim sql As New SQLControl

        Dim CurrD As Date = Format(_DateFrom, "yyyy-MM-dd")
        Dim endP As Date = Format(_DateTo, "yyyy-MM-dd")
        If GlobalVariables._SystemLanguage = "Arabic" Then
            ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        Else
            ListDays.Rows.Add(CurrD, CurrD.ToString("dddd"), PlaneID, EmpID, EmployeeName)
        End If

        While (CurrD < endP)
            CurrD = CurrD.AddDays(1)
            If GlobalVariables._SystemLanguage = "Arabic" Then
                ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
            Else
                ListDays.Rows.Add(CurrD, CurrD.ToString("dddd"), PlaneID, EmpID, EmployeeName)
            End If
        End While

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand

        myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))

        Dim dr As SqlDataReader

        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1
            Dim FromDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            Dim ToDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero
            Dim TotalDurationsSpan As TimeSpan = TimeSpan.Zero
            Dim TotalDurationLeave As TimeSpan = TimeSpan.Zero


            ' Get INs Count
            Dim GetTransInCount As Integer = 0
            Try
                Sqlstring = "   Select count([ID]) as TransInCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & ToDate2 & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
                mycommand = New SqlCommand(Sqlstring, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    GetTransInCount = dr.Item("TransInCount")
                    dr.Close()
                Else
                    dr.Close()
                End If
            Catch ex As Exception
                GetTransInCount = "0"
            End Try

            ' Get OUTs Count
            Dim GetTransOutCount As Integer = 0
            Try
                Sqlstring = "   Select count([ID]) as TransOutCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & Format(CDate(ToDate2).AddHours(5), "yyyy-MM-dd HH:mm") & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS"
                mycommand = New SqlCommand(Sqlstring, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    GetTransOutCount = dr.Item("TransOutCount")
                    dr.Close()
                Else
                    dr.Close()
                End If
            Catch ex As Exception
                GetTransOutCount = "0"
            End Try


            If GetTransInCount > 0 Then
                If GetTransInCount > 5 Then GetTransInCount = 5
                For j = 1 To CInt(GetTransInCount)
                    Try
                        Dim SQLString2 As String
                        SQLString2 = "SELECT     Row, CHECKTIME AS CheckINTimes, USERID, CHECKTYPE, ID As CheckInID,EditedType,EditNote
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [AttCHECKINOUT] 
                                        where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
                        SQLString2 += "  and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
                                        where row =" & j

                        mycommand = New SqlCommand(SQLString2, myconnection)
                        dr = mycommand.ExecuteReader

                        Try
                            If dr.HasRows Then
                                dr.Read()
                                ListDays.Rows(i).Item("StartTimeReal" & j) = dr.Item("CheckINTimes")
                                ListDays.Rows(i).Item("TransInID") = dr.Item("CheckInID")
                                ListDays.Rows(i).Item("EditedTypeIn") = dr.Item("EditedType")
                                If j = 1 Then ListDays.Rows(i).Item("Note1") = dr.Item("EditNote")

                                dr.Close()
                            Else
                                dr.Close()
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            dr.Close()
                        End Try




                        If Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal" & j)) Then
                            Dim CheckIn, CheckOut As String

                            CheckIn = Format((ListDays.Rows(i).Item("StartTimeReal" & j)), "yyyy-MM-dd HH:mm")
                            CheckOut = Format(CDate(CheckIn).AddHours(23.9999), "yyyy-MM-dd HH:mm")

                            Dim SQLString3 As String
                            SQLString3 = " SELECT top 1 CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType,EditNote
                                                 FROM   [AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS "
                            SQLString3 += " and  [USERID] = " & EmpID & "
                                            and ( CHECKTIME between '" & CheckIn & "'  and '" & CheckOut & "') order by CHECKTIME asc "
                            mycommand = New SqlCommand(SQLString3, myconnection)
                            dr = mycommand.ExecuteReader
                            If dr.HasRows Then
                                dr.Read()
                                ListDays.Rows(i).Item("EndTimeReal" & j) = dr.Item("CheckOutTimes")
                                ListDays.Rows(i).Item("TransOutID") = dr.Item("CheckOutID")
                                ListDays.Rows(i).Item("EditedTypeOut") = dr.Item("EditedType")
                                TempOutID = dr.Item("CheckOutID")
                                dr.Close()
                            Else
                                dr.Close()
                            End If

                        End If


                        Try
                            Dim StartJ, EndJ As DateTime

                            StartJ = CDate(ListDays.Rows(i).Item("StartTimeReal" & j))
                            EndJ = CDate(ListDays.Rows(i).Item("EndTimeReal" & j))

                            ListDays.Rows(i).Item("Duration" & j) = EndJ.Subtract(StartJ)

                            Try
                                '  حذف حركة الخروج التي تتكرر مع حركات الدخول
                                Dim CheckOut_1, CheckOut_2 As String
                                Dim vv As TimeSpan
                                If j > 1 Then
                                    CheckOut_1 = Format((ListDays.Rows(i).Item("EndTimeReal" & j)), "yyyy-MM-dd HH:mm")
                                    CheckOut_2 = Format((ListDays.Rows(i).Item("EndTimeReal" & j - 1)), "yyyy-MM-dd HH:mm")
                                    vv = (CDate(CheckOut_1).Subtract(CDate(CheckOut_2)))
                                    If vv.TotalMinutes = 0 Or vv.TotalMinutes > 100000 Then
                                        ListDays.Rows(i).Item("EndTimeReal" & j) = New DateTime
                                        ListDays.Rows(i).Item("Duration" & j) = TimeSpan.Zero
                                    End If

                                End If
                            Catch ex As Exception
                                '   MsgBox(ex.ToString)
                            End Try

                            TotalDurationsSpan = TotalDurationsSpan + ListDays.Rows(i).Item("Duration" & j)
                            ListDays.Rows(i).Item("TotalDurations") = TotalDurationsSpan

                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Next j

            ElseIf CInt(GetTransInCount) = 0 And CInt(GetTransOutCount) > 0 Then
                For j = 1 To CInt(GetTransOutCount)

                    Try
                        Sqlstring = ";WITH BASE_DATA AS
                                                (
                                                    SELECT
                                                        TS.CHECKTIME AS CheckINTimes ,TS.CHECKTYPE,TS.USERID,EditedType,ID As CheckOutID,EditNote,ROW_NUMBER() OVER 
                                                            (
                                                                ORDER BY TS.CHECKTIME
                                                            ) AS TS_RID
                                                    FROM     [AttCHECKINOUT]    TS
                                                )
                                                Select  Row, CheckINTimes, USERID, CHECKTYPE, CheckOutID As CheckOutID,EditedType,EditNote From 
                                                (
                                                 SELECT ROW_NUMBER() OVER(ORDER BY BD.CheckINTimes ASC) AS Row,
                                                    BD.CheckINTimes,bd.USERID,BD.CHECKTYPE,BD.CheckOutID,BD.EditedType,BD.EditNote
                                                    ,CONVERT(TIME(0),DATEADD(MINUTE,DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes),CONVERT(DATETIME,0,0)),0) AS TimeDiff
                                                 FROM            BASE_DATA       BD
                                                 LEFT OUTER JOIN BASE_DATA       BD2
                                                 ON              BD.TS_RID   =   BD2.TS_RID + 1

                                                 where   BD.USERID =" & EmpID & " and BD.CheckINTimes between '" & Format(CDate(FromDate2).AddHours(5), "yyyy-MM-dd HH:mm") & "' and '" & Format(CDate(ToDate2).AddHours(6), "yyyy-MM-dd HH:mm") & "' and BD.CHECKTYPE='O' COLLATE Latin1_General_CS_AS "
                        If GetTransOutCount <> 1 Then Sqlstring += " And DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes) >= 2" ' عند وجود حركة خروج واحدة فقط خلال الفترة 
                        Sqlstring += "          )  
                                                 aa
                                                 where Row =" & j & " order by row desc "

                        sql.SqlTrueTimeRunQuery(Sqlstring)

                        If TempOutID <> sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID") Then
                            If j > 1 Then
                                If IsDBNull(ListDays.Rows(i).Item("EndTimeReal" & j - 1)) Then
                                    ListDays.Rows(i).Item("EndTimeReal" & j - 1) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                                End If
                            Else
                                ListDays.Rows(i).Item("EndTimeReal" & (j)) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                            End If
                            ListDays.Rows(i).Item("TransOutID") = sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID")
                            ListDays.Rows(i).Item("EditedTypeIn") = sql.SQLDS.Tables(0).Rows(0).Item("EditedType")
                            TempOutID = sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID")
                        Else
                            TempOutID = 0
                        End If

                    Catch ex As Exception
                        '   MsgBox(ex.ToString)
                    End Try
                Next j
            End If
        Next

        '   MsgBox(_timefunction.ConvertTimeSpan_hhmmm_ToString(CalculateTotalDuration(ListDays)))
        Return ListDays

    End Function

    Public Function GetCode(TextKey As String, Pass As String) As String
        Dim wrapper As New Simple3Des(TextKey)
        Dim cipherText As String = wrapper.EncryptData(Pass)
        Return Mid(cipherText, 1, 3) & "-" & Mid(cipherText, 4, 3) & "-" & Mid(cipherText, 7, 3)
    End Function

    Public Function GetCountUnProcessedTrans() As Integer
        Dim SQLString As String = " Select Count(ID) As CountTrans From [AttCHECKINOUT] where [Edited] is null"
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)
        Return (sql.SQLDS.Tables(0).Rows(0).Item("CountTrans"))
    End Function


    Public Sub GetDatesTable(UserID)
        Dim i As Integer
        Dim CheckInSQL As String = "SELECT  distinct  CHECKTIME FROM [AttCHECKINOUT]
                                    where Edited Is Null order by CHECKTIME "
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(CheckInSQL)
        Dim z As Integer = (sql.SQLDS.Tables(0).Rows.Count)

        For i = 0 To z - 1

            Dim DDDdate As String = Format(sql.SQLDS.Tables(0).Rows(i).Item("CHECKTIME"), "yyyy-MM-dd")

            ProcessTransWithUserAndDate(DDDdate, UserID)
        Next

    End Sub
    Public Function GetDocumentSignatures(_DocName As String) As (signature1 As String, signature2 As String, signature3 As String, signature4 As String)
        Dim _signature1 As String = " "
        Dim _signature2 As String = " "
        Dim _signature3 As String = " "
        Dim _signature4 As String = " "
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select * from [DocumentsSignatures] where [DocNameEN]=N'" & _DocName & "'"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _signature1 = sql.SQLDS.Tables(0).Rows(0).Item("Signature1")
            _signature2 = sql.SQLDS.Tables(0).Rows(0).Item("Signature2")
            _signature3 = sql.SQLDS.Tables(0).Rows(0).Item("Signature3")
            _signature4 = sql.SQLDS.Tables(0).Rows(0).Item("Signature4")
        End If

        'Dim _signature1 As String = " الموارد البشرية"
        'Dim _signature2 As String = " المدير المالي"
        'Dim _signature3 As String = " المحاسب"
        'Dim _signature4 As String = " المدير العام"
        Return (_signature1, _signature2, _signature3, _signature4)
    End Function


    Public Function GetEmpData(EmpID As String) As Tuple(Of String, String, String, String, String, String, String)
        Dim EmployeeName As String = "0"
        Dim JobName As String = "0"
        Dim Department As String = "0"
        Dim Branch As String = "0"
        Dim SalaryAccountNo As String = "0"
        Dim DateOfStart As String = "0"
        Dim SalaryCurrency As String = "0"



        Try
            Dim sql As New SQLControl
            Dim SqlSelect As String = " Select [EmployeeName],[JobName],[Department],[Branch],SalaryAccountNo,DateOfStart,SalaryCurrency,Indenty,[RequiredDailyHoures]
                                        FROM         [EmployeesData]
                                        WHERE     (EmployeeID  ='" & EmpID & "') "
            sql.SqlTrueTimeRunQuery(SqlSelect)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                Return New Tuple(Of String, String, String, String, String, String, String)(EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency)
            Else
                EmployeeName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName").ToString)
                JobName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("JobName").ToString)
                Department = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Department").ToString)
                Branch = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Branch").ToString)
                SalaryAccountNo = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryAccountNo").ToString)
                DateOfStart = CStr(sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart").ToString)
                SalaryCurrency = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryCurrency").ToString)


            End If
        Catch ex As Exception
            EmployeeName = "0"
            JobName = "0"
            Department = "0"
            Branch = "0"
            SalaryAccountNo = "0"
            DateOfStart = "01-01-1900"
            SalaryCurrency = " "

        End Try

        Return New Tuple(Of String, String, String, String, String, String, String)(EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency)

    End Function
    Public Function GetEmployeeData(EmpID As String) As (EmployeeName As String, JobName As String, Department As String,
        Branch As String, SalaryAccountNo As String, DateOfStart As String, SalaryCurrency As String,
        MonthlySalary As Decimal, RequiredDailyHoures As TimeSpan, BankName As String,
        BankBranch As String, BankAccountNo As String, Iban As String, Indenty As String,
        SalaryPerHour As Decimal, Mobile As String, MonthlyHouresRequired As TimeSpan,
        BonusFactor As Decimal, ProcessType As Integer, MonthlyMaxLeavesHoures As TimeSpan, SalaryPerDay As Decimal, ActiveSavingFund As Boolean)
        Dim EmployeeName As String = "0"
        Dim JobName As String = "0"
        Dim Department As String = "0"
        Dim Branch As String = "0"
        Dim SalaryAccountNo As String = "0"
        Dim DateOfStart As String = "1900-01-01"
        Dim SalaryCurrency As String = "0"
        Dim MonthlySalary As Decimal = 0.0
        Dim RequiredDailyHoures As TimeSpan = TimeSpan.Zero
        Dim _BankName As String = String.Empty
        Dim _BankBranch As String = String.Empty
        Dim _BankAccountNo As String = String.Empty
        Dim _Iban As String = String.Empty
        Dim _Indenty As String = String.Empty
        Dim _SalaryPerHour As Decimal = 0.0
        Dim _Mobile As String = String.Empty
        Dim _MonthlyHouresRequired As TimeSpan = TimeSpan.Zero
        Dim _BonusFactor As Decimal = 1
        Dim _ProcessType As Decimal
        Dim _MonthlyMaxLeavesHoures As TimeSpan = TimeSpan.Zero
        Dim _SalaryPerDay As Decimal = 0.0
        Dim _ActiveSavingFund As Boolean = False
        Try

            Dim sql As New SQLControl
            Dim SqlSelect As String = " Select [EmployeeName],[JobName],[Department],[Branch],SalaryAccountNo,
                                               [DateOfStart],SalaryCurrency,Indenty,IsNull(Salary,0) as Salary,
                                                RequiredDailyHoures,[BankName],[BankBranch],[BankNo],[IBAN],
                                                Indenty,SalaryPerHour,Mobile1,MonthlyHouresRequired,BonusPerHour,
                                                ProcessType,MaxLeavesHoures,SalaryPerDay,ActiveSavingFund
                                        FROM         [EmployeesData]
                                        WHERE     (EmployeeID  ='" & EmpID & "') "
            sql.SqlTrueTimeRunQuery(SqlSelect)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                Return (EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency, MonthlySalary, RequiredDailyHoures, _BankName, _BankBranch, _BankAccountNo, _Iban, _Indenty, _SalaryPerHour, _Mobile, _MonthlyHouresRequired, _BonusFactor, _ProcessType, _MonthlyMaxLeavesHoures, _SalaryPerDay, _ActiveSavingFund)
            Else
                EmployeeName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName").ToString)
                JobName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("JobName").ToString)
                Department = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Department").ToString)
                Branch = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Branch").ToString)
                SalaryAccountNo = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryAccountNo").ToString)
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart")) Then
                    DateOfStart = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart").ToString), "yyyy-MM-dd")
                End If
                SalaryCurrency = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SalaryCurrency").ToString)
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Salary").ToString) Then
                    MonthlySalary = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Salary").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RequiredDailyHoures")) Then
                    RequiredDailyHoures = TimeSpan.Parse(sql.SQLDS.Tables(0).Rows(0).Item("RequiredDailyHoures").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankName").ToString) Then
                    _BankName = CStr(sql.SQLDS.Tables(0).Rows(0).Item("BankName").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankNo").ToString) Then
                    _BankAccountNo = CStr(sql.SQLDS.Tables(0).Rows(0).Item("BankNo").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BankBranch").ToString) Then
                    _BankBranch = CStr(sql.SQLDS.Tables(0).Rows(0).Item("BankBranch").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IBAN").ToString) Then
                    _Iban = CStr(sql.SQLDS.Tables(0).Rows(0).Item("IBAN").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Indenty").ToString) Then
                    _Indenty = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Indenty").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalaryPerHour")) Then
                    _SalaryPerHour = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SalaryPerHour").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Mobile1")) Then
                    _Mobile = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Mobile1").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("MonthlyHouresRequired")) Then
                    If sql.SQLDS.Tables(0).Rows(0).Item("MonthlyHouresRequired") = "" Then
                        _MonthlyHouresRequired = TimeSpan.Zero
                    Else
                        Dim _TimeFunctions As New TimeFunctions
                        _MonthlyHouresRequired = _TimeFunctions.ConvertText_hhmm_ToTimeSpan(sql.SQLDS.Tables(0).Rows(0).Item("MonthlyHouresRequired").ToString)
                    End If
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("BonusPerHour")) Then
                    _BonusFactor = CDec(sql.SQLDS.Tables(0).Rows(0).Item("BonusPerHour").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ProcessType")) Then
                    _ProcessType = CDec(sql.SQLDS.Tables(0).Rows(0).Item("ProcessType").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("MaxLeavesHoures")) Then
                    If sql.SQLDS.Tables(0).Rows(0).Item("MaxLeavesHoures") = "" Then
                        _MonthlyMaxLeavesHoures = TimeSpan.Zero
                    Else
                        _MonthlyMaxLeavesHoures = TimeSpan.Parse(sql.SQLDS.Tables(0).Rows(0).Item("MaxLeavesHoures").ToString)
                    End If

                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SalaryPerDay")) Then
                    _SalaryPerDay = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SalaryPerDay").ToString)
                End If
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ActiveSavingFund")) Then
                    _ActiveSavingFund = CBool(sql.SQLDS.Tables(0).Rows(0).Item("ActiveSavingFund"))
                End If
            End If
        Catch ex As Exception
            EmployeeName = "0"
            JobName = "0"
            Department = "0"
            Branch = "0"
            SalaryAccountNo = "0"
            DateOfStart = "01-01-1900"
            SalaryCurrency = " "
            MonthlySalary = 0.0
            RequiredDailyHoures = TimeSpan.Zero
            _BankName = String.Empty
            _BankBranch = String.Empty
            _BankAccountNo = String.Empty
            _Iban = String.Empty
            _Indenty = String.Empty
            _SalaryPerHour = 0.0
            _Mobile = String.Empty
            _MonthlyHouresRequired = TimeSpan.Zero
            _BonusFactor = 0
            _ProcessType = 0
            _MonthlyMaxLeavesHoures = TimeSpan.Zero
            _SalaryPerDay = 0
            _ActiveSavingFund = False
        End Try

        Return (EmployeeName, JobName, Department, Branch, SalaryAccountNo, DateOfStart, SalaryCurrency, MonthlySalary, RequiredDailyHoures, _BankName, _BankBranch, _BankAccountNo, _Iban, _Indenty, _SalaryPerHour, _Mobile, _MonthlyHouresRequired, _BonusFactor, _ProcessType, _MonthlyMaxLeavesHoures, _SalaryPerDay, _ActiveSavingFund)

    End Function

    Public Function GetEmployeesBranches() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" SELECT [Branch]  FROM [dbo].[EmployeesBranches] ")
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    Public Function GetEmployeesDepartments() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" SELECT  [Department]  FROM [dbo].[EmployeesDepartments] ")
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    Public Function GetEmployeesPositions() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" SELECT  [Positions]  FROM [dbo].[EmployeesPositions] ")
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    Public Function GetEmployeesSections() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" SELECT  [ID],[SectionName]  FROM [dbo].[EmployeesSections] ")
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function

    Public Function GetEmployeesTable(_Active As Integer, _ProcessType As Integer) As DataTable
        Dim _table As New DataTable
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select EmployeeID,[EmployeeName],[Department],[JobName],[Branch]
                          from [EmployeesData]
                          where  1 =1"
            Select Case _Active
                Case 1
                    SqlString += " And [Active] =1"
                Case 0
                    SqlString += " And [Active] =0"
            End Select
            Select Case _ProcessType
                Case > 0
                    SqlString += " And (ProcessType=" & _ProcessType & " )    "
            End Select
            sql.SqlTrueTimeRunQuery(SqlString)
            _table = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return _table
    End Function


    Public Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            ExternalIP = (New WebClient()).DownloadString("http://checkip.dyndns.org/")
            ExternalIP = (New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")) _
                     .Matches(ExternalIP)(0).ToString()
            Return ExternalIP
        Catch
            Return Nothing
        End Try
    End Function

    Public Sub GetFormType(_Type As String)
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = "update Settings set SettingValue ='" & _Type & "'  where SettingName ='TempForOpenForms' "
            sql.SqlTrueTimeRunQuery(SqlString)
        Catch ex As Exception
            Return
        End Try

    End Sub

    Public Function GetMaxVocationID() As String

        Try
            Dim sql As New SQLControl
            GetMaxVocationID = 0
            Dim SqlString As String = "Select Max(VocID) as MaxID from Vocations"
            sql.SqlTrueTimeRunQuery(SqlString)

            If sql.SQLDS.Tables(0).Rows(0).Item("MaxID") Is DBNull.Value Then
                GetMaxVocationID = 0
            Else
                GetMaxVocationID = sql.SQLDS.Tables(0).Rows(0).Item("MaxID").ToString
            End If
        Catch ex As Exception
            GetMaxVocationID = 0
        End Try

    End Function
    Public Function GetProcessTypeForEmployee(_EmployeeID As Integer) As Integer
        Dim __ProcessType As Integer
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select IsNull([ProcessType],0) as ProcessType 
                          from [dbo].[EmployeesData] 
                          where [EmployeeID]= " & _EmployeeID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            __ProcessType = Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType")
        Catch ex As Exception
            __ProcessType = 0
        End Try
        Return __ProcessType
    End Function
    Public Function GetSMSBalance() As String
        Try
            Dim strUrl As String
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [Settings] where [SettingName]='SmsAPIGetBalance' ")
            strUrl = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Dim request As WebRequest = WebRequest.Create(strUrl)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine((CType(response, HttpWebResponse)).StatusDescription)
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Console.WriteLine(responseFromServer)
            Return responseFromServer
            reader.Close()
            response.Close()
        Catch ex As Exception
            Return "0"
        End Try
    End Function

    Public Function GetSystemDocNames() As DataTable
        Dim _Table As New DataTable
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT [DocID],[DocName],[DocSystem]
                      FROM [SystemDocNames] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Table = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
        Return _Table
    End Function

    Public Function GetSystemLanguage() As String
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim SoftLanguageString As String = "Arabic"
        Try
            SqlString = "Select SettingValue From Settings where SettingName ='SoftLanguage'"
            If sql.SqlTrueTimeRunQuery(SqlString) = "True" Then
                If sql.SQLDS.Tables(0).Rows.Count = 0 Then SoftLanguageString = "Arabic"
                If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = "Arabic" Then
                    SoftLanguageString = "Arabic"
                ElseIf sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = "English" Then
                    SoftLanguageString = "English"
                End If
            Else
                MsgBox("Error")
            End If
        Catch ex As Exception
            SoftLanguageString = "Arabic"
        End Try
        Return SoftLanguageString
    End Function
    Public Sub GetUserAccess(ByVal userID As Integer)
        Try
            Dim Sql As New SQLControl
            Dim _SettingsTable As New DataTable
            Sql.SqlTrueAccountingRunQuery(" select * from [dbo].[AccessByEmployees] where EmployeeID =" & userID)
            _SettingsTable = Sql.SQLDS.Tables(0)
            Dim _AccessName, _AccessValue As String
            With _SettingsTable
                For i = 0 To .Rows.Count - 1
                    _AccessName = .Rows(i).Item("AccessName")
                    _AccessValue = .Rows(i).Item("AccessValue")
                    Select Case _AccessName
                        Case "ViewItemCost"
                            EmployeeAccess._ShowItemCost = CBool(_AccessValue)
                    End Select
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Public Sub GetUsersTable()
        Dim i As Integer
        NewUsers = 0

        Dim SQLString As String = "SELECT  distinct  USERID FROM [AttCHECKINOUT]
                                    where Edited Is Null order by USERID "
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)
        Dim z As Integer = (sql.SQLDS.Tables(0).Rows.Count)

        For i = 0 To z - 1
            Dim UserID As String = sql.SQLDS.Tables(0).Rows(i).Item("USERID")
            InsertingNewWmployees(UserID)
            '   GetDatesTable(UserID)
        Next

    End Sub

    '    Public Function GetVocationDataByEmpID(EmpID As String, VocID As Integer) As Tuple(Of Decimal, Decimal, Decimal, Decimal, Decimal)

    '        Dim Balance As Decimal = 0
    '        Dim ThisYearVocations As Decimal = 0
    '        Dim ThisYearSetBalance As Decimal = 0
    '        Dim BeginingBalance As Decimal = 0
    '        Dim AccruedVocations As Decimal = 0
    '        Dim EmployeeStartDate As Date

    '        With GetEmpData(EmpID)
    '            Try
    '                EmployeeStartDate = Format(CDate(.Item6), "yyyy-MM-dd")
    '            Catch ex As Exception
    '                EmployeeStartDate = Format(CDate("1900-01-01"), "yyyy-MM-dd")
    '            End Try
    '        End With


    '        Try
    '            Dim sql As New SQLControl
    '            Dim SqlSelect As String = "   SELECT EmpID,ISNULL(AllAddningBalances,0)-ISNULL (AllVocations,0) as Balance,
    '       ISNULL( ThisYearVocations,0) as ThisYearVocations , ISNULL( ThisYearSetBalance ,0) as ThisYearSetBalance,
    '       ISNULL (AllAddningBalances-AllVocations+ThisYearVocations-ThisYearSetBalance,0) as BeginingBalance
    'FROM 
    '(  

    '			(Select E.EmployeeID AS EmpID  From EmployeesData E where EmployeeID = '" & EmpID & "' GROUP BY E.EmployeeID) SS

    '	left Join

    '			(Select top 1  AllAddningBalances,Employee from ( Select SUM(BalanceDays) AS AllAddningBalances , Employee From [VacationsBalancesAdding] where employee='" & EmpID & "' and VocationType=" & VocID & " group by Employee		 union select 0,'" & EmpID & "' 		)   a 		order by AllAddningBalances desc ) DSA		       
    '	on SS.EmpID = DSA.Employee

    '	left Join 

    '			(Select top 1  AllVocations,EmployeeID from ( Select  ISNULL( SUM(NoDays),0)  AS AllVocations,EmployeeID From [Vocations] where EmployeeID='" & EmpID & "' and VocationType=" & VocID & " group by EmployeeID 		 union select 0,'" & EmpID & "' 		)   a 		order by AllVocations desc ) DSS
    '	on SS.EmpID =DSS.EmployeeID 

    '	left Join 

    '			(Select top 1  ThisYearVocations,EmployeeID from ( select ISNULL( SUM(NoDays),0)  AS ThisYearVocations,EmployeeID From [Vocations]  where EmployeeID='" & EmpID & "' and VocationType=" & VocID & " and  FromDate BETWEEN '" & Format(Today, "yyyy").ToString & "-01-01" & "' AND '" & Format(Today, "yyyy").ToString & "-12-31" & "' 		 GROUP BY EmployeeID 		 union select 0,'" & EmpID & "' 		)   a 		order by ThisYearVocations desc) BB
    '	ON SS.EmpID=BB.EmployeeID

    '	left  Join 

    '	 (  Select top 1  ThisYearSetBalance,Employee from ( SELECT ISNULL( SUM(BalanceDays),0)  AS ThisYearSetBalance , VB.Employee From [VacationsBalancesAdding] VB where Employee='" & EmpID & "' and VocationType=" & VocID & " and  VB.[BalanceDate] between '" & Format(Today, "yyyy").ToString & "-01-01" & "' AND '" & Format(Today, "yyyy").ToString & "-12-31" & "'  group by Employee 		 union select 0,'" & EmpID & "' 		)   a 		order by ThisYearSetBalance desc ) as RERE  
    '	ON SS.EmpID =RERE.Employee

    ') "

    '            sql.SqlTrueTimeRunQuery(SqlSelect)
    '            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
    '                Return New Tuple(Of Decimal, Decimal, Decimal, Decimal, Decimal)(Balance, ThisYearVocations, ThisYearSetBalance, BeginingBalance, AccruedVocations)
    '            Else
    '                Balance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Balance").ToString)
    '                ThisYearVocations = CDec(sql.SQLDS.Tables(0).Rows(0).Item("ThisYearVocations").ToString)
    '                ThisYearSetBalance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("ThisYearSetBalance").ToString)
    '                BeginingBalance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("BeginingBalance").ToString)

    '                'Try
    '                '    If (ThisYearSetBalance - ThisYearVocations) > 0 Then
    '                '        Dim _PassingDays As Integer = DateDiff(DateInterval.Day, CDate(Format(Today, "yyyy").ToString & "-01-01"), Today)
    '                '        Dim TempInt As Integer
    '                '        TempInt = 365 / (ThisYearSetBalance - ThisYearVocations)
    '                '        If TempInt > 0 Then AccruedVocations = BeginingBalance + CInt(_PassingDays / TempInt)
    '                '    End If
    '                'Catch ex As Exception
    '                '    AccruedVocations = 0
    '                '    MsgBox(ex.ToString)
    '                'End Try
    '                Dim _PassingDays As Integer
    '                Try
    '                    If (ThisYearSetBalance - ThisYearVocations) > 0 Then
    '                        Dim _PassingDaysFromThisYear As Integer = DateDiff(DateInterval.Day, CDate(Format(Today, "yyyy").ToString & "-01-01"), Today)
    '                        Dim _PassingDaysFromStartdate As Integer = DateDiff(DateInterval.Day, EmployeeStartDate, Today)

    '                        If _PassingDaysFromThisYear > _PassingDaysFromStartdate Then
    '                            _PassingDays = _PassingDaysFromStartdate
    '                        Else
    '                            _PassingDays = _PassingDaysFromThisYear
    '                        End If
    '                        ' Dim TempInt As Integer
    '                        ' TempInt = 365 / (ThisYearSetBalance - ThisYearVocations)
    '                        AccruedVocations = CInt(ThisYearSetBalance * (_PassingDays / 365) + BeginingBalance - ThisYearVocations)
    '                    End If
    '                Catch ex As Exception
    '                    AccruedVocations = 0
    '                    MsgBox(ex.ToString)
    '                End Try


    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '        Return New Tuple(Of Decimal, Decimal, Decimal, Decimal, Decimal)(Balance, ThisYearVocations, ThisYearSetBalance, BeginingBalance, AccruedVocations)

    '    End Function

    Public Function GetVocationsBalancesByEmployee(
            EmpID As String, VocID As Integer, _ToDate As DateTime) As _
                                         (Balance As Decimal, ThisYearVocations As Decimal, ThisYearSetBalance As Decimal,
                                         BeginingBalance As Decimal, AccruedVocations As Decimal)
        If String.IsNullOrEmpty(EmpID) Then
            Return (Balance:=0D, ThisYearVocations:=0D, ThisYearSetBalance:=0D, BeginingBalance:=0D, AccruedVocations:=0D)
        End If

        Dim Balance As Decimal = 0 'الرصيد لنهاية العام
        Dim ThisYearVocations As Decimal = 0 ' الاجازات هذا العام
        Dim ThisYearSetBalance As Decimal = 0 ' الاجازات المضافة هذا العام
        Dim BeginingBalance As Decimal = 0 'الرصيد لبداية العام
        Dim AccruedVocations As Decimal = 0 ' الاجازات المستحقة لتاريخ اليوم
        Dim EmployeeStartDate As Date
        Dim _EmployeeData = GetEmployeeData(EmpID)
        Try
            EmployeeStartDate = _EmployeeData.DateOfStart
        Catch ex As Exception
            EmployeeStartDate = Format(CDate("1900-01-01"), "yyyy-MM-dd")
        End Try
        Try
            Dim sql As New SQLControl
            Dim SqlSelect As String = "   SELECT EmpID,ISNULL(AllAddningBalances,0)-ISNULL (AllVocations,0) as Balance,
                                                 ISNULL( ThisYearVocations,0) as ThisYearVocations , ISNULL( ThisYearSetBalance ,0) as ThisYearSetBalance,
                                                 ISNULL (AllAddningBalances-AllVocations+ThisYearVocations-ThisYearSetBalance,0) as BeginingBalance
                                          FROM 
                                          (  
  
			                                     (Select E.EmployeeID AS EmpID  From EmployeesData E where EmployeeID = '" & EmpID & "' GROUP BY E.EmployeeID) SS
	                                             left Join
			                                     (Select top 1  AllAddningBalances,Employee from ( Select SUM(BalanceDays) AS AllAddningBalances , Employee From [VacationsBalancesAdding] where employee='" & EmpID & "' and VocationType=" & VocID & " group by Employee		 union select 0,'" & EmpID & "' 		)   a 		order by AllAddningBalances desc ) DSA		       
	                                             on SS.EmpID = DSA.Employee
	                                             left Join 
			                                     (Select top 1  AllVocations,EmployeeID from ( Select  ISNULL( SUM(NoDays),0)  AS AllVocations,EmployeeID From [Vocations] where EmployeeID='" & EmpID & "' and VocationType=" & VocID & " group by EmployeeID 		 union select 0,'" & EmpID & "' 		)   a 		order by AllVocations desc ) DSS
	                                             on SS.EmpID =DSS.EmployeeID 
	                                             left Join 
			                                     (Select top 1  ThisYearVocations,EmployeeID from ( select ISNULL( SUM(NoDays),0)  AS ThisYearVocations,EmployeeID From [Vocations]  where EmployeeID='" & EmpID & "' and VocationType=" & VocID & " and  FromDate BETWEEN '" & Format(_ToDate, "yyyy").ToString & "-01-01" & "' AND '" & Format(_ToDate, "yyyy").ToString & "-12-31" & "' 		 GROUP BY EmployeeID 		 union select 0,'" & EmpID & "' 		)   a 		order by ThisYearVocations desc) BB
	                                             ON SS.EmpID=BB.EmployeeID
	                                             left  Join 
	                                             (Select top 1  ThisYearSetBalance,Employee from ( SELECT ISNULL( SUM(BalanceDays),0)  AS ThisYearSetBalance , VB.Employee From [VacationsBalancesAdding] VB where Employee='" & EmpID & "' and VocationType=" & VocID & " and  VB.[BalanceDate] between '" & Format(_ToDate, "yyyy").ToString & "-01-01" & "' AND '" & Format(_ToDate, "yyyy").ToString & "-12-31" & "'  group by Employee 		 union select 0,'" & EmpID & "' 		)   a 		order by ThisYearSetBalance desc ) as RERE  
	                                             ON SS.EmpID =RERE.Employee
                                           ) "

            sql.SqlTrueTimeRunQuery(SqlSelect)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                Return (Balance, ThisYearVocations, ThisYearSetBalance, BeginingBalance, AccruedVocations)
            Else
                Balance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Balance").ToString)
                ThisYearVocations = CDec(sql.SQLDS.Tables(0).Rows(0).Item("ThisYearVocations").ToString)
                ThisYearSetBalance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("ThisYearSetBalance").ToString)
                BeginingBalance = CDec(sql.SQLDS.Tables(0).Rows(0).Item("BeginingBalance").ToString)
                Dim _PassingDays As Integer
                Try
                    'If (ThisYearSetBalance - ThisYearVocations) > 0 Then
                    Dim _PassingDaysFromThisYear As Integer = DateDiff(DateInterval.Day, CDate(Format(Today, "yyyy").ToString & "-01-01"), Today)
                    Dim _PassingDaysFromStartdate As Integer = DateDiff(DateInterval.Day, EmployeeStartDate, Today)

                    If _PassingDaysFromThisYear > _PassingDaysFromStartdate Then
                        _PassingDays = _PassingDaysFromStartdate
                    Else
                        _PassingDays = _PassingDaysFromThisYear
                    End If
                    AccruedVocations = (ThisYearSetBalance * (_PassingDays / 365) + BeginingBalance - ThisYearVocations)
                    'End If
                Catch ex As Exception
                    AccruedVocations = 0
                    MsgBox(ex.ToString)
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return (Balance.ToString("0.#"), ThisYearVocations.ToString("0.#"), ThisYearSetBalance.ToString("0.#"), BeginingBalance.ToString("0.#"), AccruedVocations.ToString("0.#"))
    End Function

    Public Function GetVocationsTypes() As DataTable
        Dim _table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select Vocation,VocID,VocationPaid from VocationsTypes  "
            sql.SqlTrueTimeRunQuery(sqlstring)
            _table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function


    Public Function InsertVocationAndGetID(ByVal EmpID As Integer, ByVal VocDate As Date, ByVal VocationType As String, ByVal NoDays As Integer, ByVal NoteDetails As String, ByVal VocationSource As String) As Integer
        Dim outputID As Integer = 0

        ' Connection string - replace with your actual connection string
        Dim connectionString As String = "Your_Connection_String"

        ' SQL Insert query with OUTPUT clause to get the inserted ID
        Dim sqlString As String = "INSERT INTO Vocations " &
                              " (EmployeeID, VocDate, VocationType, FromDate, ToDate, NoDays, NoteDetails, VocationSource) " &
                              " OUTPUT INSERTED.ID " &
                              " VALUES (@EmployeeID, @VocDate, @VocationType, @FromDate, @ToDate, @NoDays, @NoteDetails, @VocationSource)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(sqlString, connection)
                ' Add parameters
                command.Parameters.AddWithValue("@EmployeeID", EmpID)
                command.Parameters.AddWithValue("@VocDate", VocDate)
                command.Parameters.AddWithValue("@VocationType", VocationType)
                command.Parameters.AddWithValue("@FromDate", VocDate) ' Assuming FromDate = VocDate
                command.Parameters.AddWithValue("@ToDate", VocDate)   ' Assuming ToDate = VocDate
                command.Parameters.AddWithValue("@NoDays", NoDays)
                command.Parameters.AddWithValue("@NoteDetails", NoteDetails)
                command.Parameters.AddWithValue("@VocationSource", VocationSource)

                Try
                    connection.Open()
                    ' Execute the query and get the output ID
                    outputID = Convert.ToInt32(command.ExecuteScalar())
                Catch ex As Exception
                    ' Handle exceptions (log or rethrow)
                    Throw New Exception("Error inserting vocation: " & ex.Message)
                End Try
            End Using
        End Using

        Return outputID
    End Function

    Public Function GetVocID(TheDate As String, EmpID As String) As Tuple(Of String, String, Boolean, String)
        Dim Voc As Decimal = 0
        Dim VocType As String = "0"
        Dim VocationPaid As Boolean = False
        Dim VocationSource As String = String.Empty
        Try
            Dim sql As New SQLControl
            Dim SqlSelect As String = "  Select V.VocID, Sum(NoDays) As Voc, VocationType,VocationPaid,t.Vocation,Case when VocationSource is null then   'vocation' else VocationSource end as VocationSource
                                         FROM         Vocations v
                                         left join VocationsTypes T on V.VocationType=T.VocID
                                         WHERE [VocationSource]<>'adjust' And VocationSource='vocation' And    ('" & TheDate & "' BETWEEN FromDate AND ToDate and EmployeeID='" & EmpID & "'  ) group by V.VocID,VocationType,VocationPaid,t.Vocation,VocationSource "
            sql.SqlTrueTimeRunQuery(SqlSelect)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                Return New Tuple(Of String, String, Boolean, String)(Voc, VocType, VocationPaid, VocationSource)
            Else
                Voc = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Voc").ToString)
                If Voc > 1 Then Voc = 1
                VocType = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Vocation").ToString)
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("VocationSource")) Then
                    If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("VocationSource")) Then
                        VocationSource = CStr(sql.SQLDS.Tables(0).Rows(0).Item("VocationSource").ToString)
                    End If
                Else
                    VocationSource = "vocation"
                End If
                Try
                    VocationPaid = CBool(sql.SQLDS.Tables(0).Rows(0).Item("VocationPaid").ToString)
                Catch ex As Exception
                    VocationPaid = False
                End Try

            End If
        Catch ex As Exception
            Voc = 0
            VocType = "0"
            VocationPaid = False
            VocationSource = String.Empty
        End Try


        Return New Tuple(Of String, String, Boolean, String)(Voc, VocType, VocationPaid, VocationSource)



    End Function

    Public Function HasAccessOnForm(FormName As String, AccessType As String) As Boolean
        Dim SqlString As String = "Select " & AccessType & " as Access from AccessUsers where FromID= '" & FormName & "' and UserNo =" & GlobalVariables.CurrUser
        Dim HasAccess As Boolean = False
        If CheckIfAdmin() = True Then
            HasAccess = True
        Else
            Try
                Dim sql As New SQLControl

                sql.SqlTrueTimeRunQuery(SqlString)
                HasAccess = CBool(sql.SQLDS.Tables(0).Rows(0).Item("Access"))
                '  InsertLogs(GlobalVariables.CurrUser, "فحص صلاحية الدخول للشاشة", "HasAccessOnForm", Now, HasAccess, "", "", SqlString)
            Catch ex As Exception
                HasAccess = True
                '   InsertLogs(GlobalVariables.CurrUser, "فحص صلاحية الدخول للشاشة", "HasAccessOnForm", Now, HasAccess, "", ex.ToString, SqlString)
                '   MsgBox(ex.ToString)
            End Try
        End If

        Return HasAccess

        Return True

    End Function


    Public Function HasValidLocalLicense() As Boolean
        Return True
        ''  Return Fals

        'Dim _result As Boolean = False

        'If IsConnected() = True Then
        '    Try

        '        Dim Sql As New SQLControl
        '        Dim SqlString As String = " Select DeviceKey,RegCode,SoftwareID From DevicesReg where DeviceKey='" & SystemSerialNumber() & "'"
        '        Sql.SqlTrueTimeRunQuery(SqlString)

        '        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
        '            GlobalVariables.LocalRegCode = Sql.SQLDS.Tables(0).Rows(0).Item("RegCode")
        '            GlobalVariables.LocalSoftwareID = Sql.SQLDS.Tables(0).Rows(0).Item("SoftwareID")
        '            If GlobalVariables.LocalRegCode = GetCode(GlobalVariables.LocalDeviceKey, GlobalVariables.LocalSoftwareID) _
        '           And Sql.SQLDS.Tables(0).Rows(0).Item("DeviceKey") = GlobalVariables.LocalDeviceKey Then
        '                _result = True
        '            Else
        '                _result = False
        '            End If
        '        Else
        '            _result = False
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '        _result = False
        '    End Try

        '    LocalHasValidLocalLicense = HasValidLocalLicense
        'Else
        '    _result = False
        'End If
        ''  MsgBox(Environ("ComputerName"))
        'If Environ("ComputerName") = "MAZENLAPTOP" Or Environ("ComputerName") = "MAZENHOMEPC" Or Environ("ComputerName") = "LAPTOP-A4ULI8SL" Then
        '    _result = True
        'End If
        'Return _result
    End Function

    Public Function ImportItemsToLocalDataBAse() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[Items] ")
        Catch ex As Exception

        End Try
        Dim SQLString As String = " SELECT ID, [Type]
      ,[ItemNo]
      ,[ItemName]
      ,[HasExpireDate]
      ,[LastPurchasePrice]
      ,[LastPurchaseDate]
      ,[Price]
      ,[ReOrderQuantity]
      ,[ItemImage]
      ,[notes]
      ,[AccSales]
      ,[AccPurches]
      ,[AccRetSales]
      ,[AccRetPurches]
      ,[CategoryID]
      ,[TradeMarkID]
      ,[GroupID]
      ,[SaleOnScale]
      ,[ItemNo2]
      ,[ItemNo3]
      ,[ItemNo4]
      ,[ProductCompany]
      ,[WebSite1]
      ,[WebSite2]
      ,[VisibleInAPP] From [dbo].[Items]"
        Try
            Dim AttTable As New DataTable
            '  Select Case GlobalVariables._AttConnectionType
            '   Case "Sql"
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable = Sql.SQLDS.Tables(0)
            ' End Select
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then GoTo GG
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"
            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.Items;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "Items"
                    bulkCopy.WriteToServer(newProducts)
                End Using



                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())

                Dim TotalReads As Integer = countEnd - countStart


                MyGlobalString = CStr(TotalReads)

                'InsertLogs("تم قراءة الساعة", "ReadAttTrans", "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers)
                'InsertLogs(GlobalVariables.CurrUser, "قراءة الساعة", "ReadAttTransFunction", Now, String.Empty, "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers, String.Empty, SQLString)



            End Using


        Catch ex As Exception
            '  MsgBox("خطا في عملية القراءة ، تاكد من اضافة عمود Process  من شاشة الاعدادات")
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function


    Public Function ImportItemsUnitsToLocalDataBAse() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[Items_units] ")
        Catch ex As Exception

        End Try
        Dim SQLString As String = " SELECT ID,
      [item_id]
      ,[unit_id]
      ,[main_unit]
      ,[EquivalentToMain]
      ,[item_unit_bar_code]
      ,[Price1]
      ,[main_pay_unit]
      ,[main_sell_unit]
      ,[Price2]
      ,[Price3]
      ,[IsUnit]
      ,[Measure]
      ,[Color]
      ,[item_unit_pay_price]
  FROM [dbo].[Items_units]"
        Try
            Dim AttTable As New DataTable
            '  Select Case GlobalVariables._AttConnectionType
            '   Case "Sql"
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable = Sql.SQLDS.Tables(0)
            ' End Select
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then GoTo GG
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"
            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.Items_units;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "Items_units"
                    bulkCopy.WriteToServer(newProducts)
                End Using



                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())

                Dim TotalReads As Integer = countEnd - countStart


                MyGlobalString = CStr(TotalReads)

                'InsertLogs("تم قراءة الساعة", "ReadAttTrans", "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers)
                'InsertLogs(GlobalVariables.CurrUser, "قراءة الساعة", "ReadAttTransFunction", Now, String.Empty, "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers, String.Empty, SQLString)



            End Using


        Catch ex As Exception
            '  MsgBox("خطا في عملية القراءة ، تاكد من اضافة عمود Process  من شاشة الاعدادات")
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function

    Public Function ImportItemTablesToLocalDataBAse() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[ItemsGroups];delete FROM [dbo].[ItemsTradeMark];
delete FROM [dbo].[ItemsCategories];Delete FROM [dbo].[Units] ")
        Catch ex As Exception

        End Try
        Dim SQLString As String = " SELECT [GroupID]
      ,[GroupName]
      ,[AvailableOnPOS]
      ,[GroupImage]
  FROM [SuperMarket].[dbo].[ItemsGroups];
  SELECT  [TradeMarkID]
      ,[TradeMarkName]
  FROM [SuperMarket].[dbo].[ItemsTradeMark];
  SELECT  [CategoryID]
      ,[CategoryName]
  FROM [dbo].[ItemsCategories];
SELECT id,
      [name]
      ,[state]
  FROM [dbo].[Units]"
        Try
            Dim AttTable1, AttTable2, AttTable3, AttTable4 As New DataTable
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable1 = Sql.SQLDS.Tables(0)
            AttTable2 = Sql.SQLDS.Tables(1)
            AttTable3 = Sql.SQLDS.Tables(2)
            AttTable4 = Sql.SQLDS.Tables(3)
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"
            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.[ItemsGroups];",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable1
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "ItemsGroups"
                    bulkCopy.WriteToServer(newProducts)
                End Using
                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using

            Using connection As SqlConnection =
New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.ItemsTradeMark;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable2
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "ItemsTradeMark"
                    bulkCopy.WriteToServer(newProducts)
                End Using
                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using

            Using connection As SqlConnection =
New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.ItemsCategories;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable3
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "ItemsCategories"
                    bulkCopy.WriteToServer(newProducts)
                End Using
                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using


            Using connection As SqlConnection =
New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.[Units];",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable4
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "Units"
                    bulkCopy.WriteToServer(newProducts)
                End Using
                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using
        Catch ex As Exception
            '  MsgBox("خطا في عملية القراءة ، تاكد من اضافة عمود Process  من شاشة الاعدادات")
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function

    Public Sub InsertingNewWmployees(USER As Integer)
        Dim sql As New SQLControl
        Dim Name As String = "NewEmployee"

        Dim SQLInsertingCheckEmp As String = " select UserIDInAttFile from EmployeesData where UserIDInAttFile= " & USER
        sql.SqlTrueTimeRunQuery(SQLInsertingCheckEmp)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            Dim SQLInsertingNewEmp As String = " Insert into EmployeesData (EmployeeID,EmployeeName,UserIDInAttFile,Active)
                Values ( '" & USER & "','" & Name & "'," & USER & " , 1 )"
            sql.SqlTrueTimeRunQuery(SQLInsertingNewEmp)
            NewUsers = NewUsers + 1
        End If
    End Sub

    Public Sub InsertLogs(UserID, LogName, FormName, LogDate, LastValue, LogDetails, LogErrorMessage, SqlString)

        Try
            Dim query As String = String.Empty
            query &= "INSERT INTO [SettingsLogs] ([UserID],[LogName],[FormName],[LogDate],[LastValue],[LogDetails],[LogErrorMessage],SqlString)  "
            query &= "VALUES (@UserID,@LogName, @FormName, @LogDate, @LastValue,@LogDetails,@LogErrorMessage,@SqlString)"

            Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
                Using comm As New SqlCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@UserID", UserID)
                        .Parameters.AddWithValue("@LogName", LogName)
                        .Parameters.AddWithValue("@FormName", FormName)
                        .Parameters.AddWithValue("@LogDate", LogDate)
                        .Parameters.AddWithValue("@LastValue", LastValue)
                        .Parameters.AddWithValue("@LogDetails", LogDetails)
                        .Parameters.AddWithValue("@LogErrorMessage", Left(LogErrorMessage, 100))
                        .Parameters.AddWithValue("@SqlString", SqlString)
                    End With
                    conn.Open()
                    comm.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try

        '   Try
        '       Dim sql As New SQLControl
        '       Dim SqString As String

        '       SqString = "INSERT INTO [SettingsLogs]
        '      ([UserID]
        '      ,[LogName]
        '      ,[FormName]
        '      ,[LogDate]
        '      ,[LastValue]
        '      ,[LogDetails]
        '      ,[LogErrorMessage],SqlString)
        'VALUES
        '      ('" & UserID & "'
        '      ,'" & LogName & "'
        '      ,'" & FormName & "'
        '      , GetDate()
        '      ,'" & LastValue & "'
        '      ,'" & LogDetails & "'
        '      ,'" & LogErrorMessage & "','" & SqlString & "')"

        '       sql.SqlTrueTimeRunQuery(SqString)
        '   Catch ex As Exception
        '       MsgBox(Err.ToString)
        '   End Try
    End Sub


    Public Function IsConnected() As Boolean

        Try
            Dim SqlTrueTime As New SqlConnection With {.connectionString = My.Settings.TrueTimeConnectionString}
            SqlTrueTime.Open()
            If SqlTrueTime.State = ConnectionState.Open Then
                SqlTrueTime.Close()
                Return True
            Else
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBox("خطا بالاتصال مع قاعدة البيانات")
                Else
                    MsgBox("Database Connection Error")
                End If

                Return False
            End If
        Catch ex As Exception

        End Try


        Return IsConnected
    End Function
    Public Function IsConnectedTrueAccounting() As Boolean

        Try
            Dim SqlTrueAccounting As New SqlConnection With {.connectionString = My.Settings.TrueTimeConnectionString}
            SqlTrueAccounting.Open()
            If SqlTrueAccounting.State = ConnectionState.Open Then
                SqlTrueAccounting.Close()
                Return True
            Else

                MsgBox("خطا بالاتصال مع قاعدة البيانات")
                Return False
            End If
        Catch ex As Exception

        End Try


        Return IsConnectedTrueAccounting()
    End Function

    Public Async Function IsInternetAvailableAsync() As Task(Of Boolean)
        Try
            ' Create a new web request to a known website (e.g., google.com)
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create("http://www.google.com"), HttpWebRequest)

            ' Set the request's method to "HEAD" to minimize data transfer
            request.Method = "HEAD"

            ' Get the web response asynchronously
            Using response As HttpWebResponse = DirectCast(Await request.GetResponseAsync(), HttpWebResponse)
                ' If the response status is OK, return true (internet is available)
                Return response.StatusCode = HttpStatusCode.OK
            End Using
        Catch ex As WebException
            ' If a WebException occurs, it means there is no internet connection
            Return False
        End Try
    End Function
    Public Sub LoadPdfFile(File As String)
        Try
            '    If OrderIDTextBox.Text = "" Then Exit Try
            Dim memoryStream As IO.MemoryStream = New MemoryStream()
            Dim con As SqlConnection
            Dim cmd As SqlCommand
            Dim row As Integer
            'Dim str As String
            con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            con.Open()
            cmd = New SqlCommand(" select DocFile   FROM [ArchiveDocs] where DocID= " & File, con)
            row = cmd.ExecuteNonQuery()
            Using sqlQueryResult = cmd.ExecuteReader()
                If sqlQueryResult IsNot Nothing Then
                    sqlQueryResult.Read()
#Disable Warning BC42016 ' Implicit conversion
                    Dim blob = New Byte((sqlQueryResult.GetBytes(0, 0, Nothing, 0, Integer.MaxValue)) - 1) {}
#Enable Warning BC42016 ' Implicit conversion
                    sqlQueryResult.GetBytes(0, 0, blob, 0, blob.Length)
                    memoryStream.Write(blob, 0, blob.Length)
                    My.Forms.AttachmentDispaly.PdfViewer1.LoadDocument(memoryStream)
                End If
            End Using
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            My.Forms.AttachmentDispaly.PdfViewer1.CloseDocument()
        End Try


    End Sub

    Public Function MySqlString() As String
        Return "server=truetime.ps;Port=3306; User ID=truetime_TTS; password=1031342; database=truetime_Customers"
    End Function
    Public Function MySqlString2() As String
        Return "server=tts.com.ps;Port=3306; User ID=ttsttstt_mazen; password=mazen@2020; database=ttsttstt_resturant"
    End Function
    Private Function GetDefualtHRSalarySlip() As String
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue from [Settings] where SettingName='HR_DefualtSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Public Sub PrintSalaryDocument(_DocID As Integer, _PrintOption As String)
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _DateFrom, _Date__To, _EmployeeId As String
        SqlString = "  SELECT   A.[ID],A.[DateFrom],A.[DateTo] ,A.[DocMonth] ,A.[DocYear] ,A.[EmployeeID]  ,A.SavingsFund
                              ,C.[Code] as [Currency] ,A.[SalaryMonth] ,A.[BonusAmount]
                              ,A.[Transport] ,A.[Additions] ,A.[LeavesAmount] ,A.[Payment] ,A.[GrossSalary] ,A.[MonthDays] ,A.[ActualDays]
                              ,A.[VocationDays] ,A.[WeekOffDays] ,A.[AbsenceDays] ,A.[HouresRequired] ,A.[ActualHoures] ,A.[VocationBegBalance] ,A.[AccruedVocationDays]
                              ,A.[VocationCurrentBalance] ,A.[VocationAtEndYear] ,A.[VocationSick] ,A.[NetSalary] ,A.HouresNetBonus,A.HouresNetLeaves,ArchiveStatus,AbsenceAmount"
        SqlString &= "        ,A.[EmployeeNoAsAcc],A.[EmployeeName],A.[Branch] ,A.[Department] ,A.[JobName] ,A.[BeginDate],A.[Indenty],A.[BankName],A.[BankNo],A.[BankBranch],A.IBAN,A.ProcessType,A.SalaryPerHour "
        SqlString &= "  FROM [AttRawatebArchive] A  
                        Left join EmployeesData E on E.EmployeeID =A.EmployeeID
                        Left join [dbo].[Currency] C on C.CurrID =A.Currency
                        Where A.[ID] > 0 and A.ID=" & _DocID
        sql.SqlTrueTimeRunQuery(SqlString)
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID")) Then _EmployeeId = sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID") Else _EmployeeId = "0"
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DateFrom")) Then _DateFrom = sql.SQLDS.Tables(0).Rows(0).Item("DateFrom") Else _DateFrom = "1900-01-01"
        If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DateTo")) Then _Date__To = sql.SQLDS.Tables(0).Rows(0).Item("DateTo") Else _Date__To = "1900-01-01"

        Select Case GetDefualtHRSalarySlip()
            Case "1"
                Dim report As New SalaryReport With {
                    .DocID = _DocID
                }
                With sql.SQLDS.Tables(0).Rows(0)
                    If Not IsDBNull(.Item("EmployeeID")) Then report.Parameters("EmployeeNo").Value = .Item("EmployeeID")
                    If Not IsDBNull(.Item("EmployeeName")) Then report.Parameters("EmployeeName").Value = .Item("EmployeeName")
                    report.Parameters("PeriodString").Value = " من " & .Item("DateFrom") & " الى " & .Item("DateTo")
                    If Not IsDBNull(.Item("DateFrom")) Then _DateFrom = .Item("DateFrom") Else _DateFrom = "1900-01-01"
                    If Not IsDBNull(.Item("DateTo")) Then _Date__To = .Item("DateTo") Else _Date__To = "1900-01-01"
                    If Not IsDBNull(.Item("EmployeeID")) Then _EmployeeId = .Item("EmployeeID") Else _EmployeeId = "0"
                    If Not IsDBNull(.Item("EmployeeNoAsAcc")) Then report.Parameters("EmployeeNoAsAcc").Value = .Item("EmployeeNoAsAcc")
                    If Not IsDBNull(.Item("Branch")) Then report.Parameters("Branch").Value = .Item("Branch")
                    If Not IsDBNull(.Item("Department")) Then report.Parameters("Department").Value = .Item("Department")
                    If Not IsDBNull(.Item("JobName")) Then report.Parameters("JobName").Value = .Item("JobName")
                    If Not IsDBNull(.Item("Currency")) Then report.Parameters("Currency").Value = .Item("Currency")
                    If Not IsDBNull(.Item("SalaryMonth")) Then report.Parameters("SalaryMonth").Value = .Item("SalaryMonth")
                    If Not IsDBNull(.Item("BonusAmount")) Then report.Parameters("BonusAmount").Value = .Item("BonusAmount")
                    If Not IsDBNull(.Item("Transport")) Then report.Parameters("Transport").Value = .Item("Transport")
                    If Not IsDBNull(.Item("Additions")) Then report.Parameters("Additions").Value = .Item("Additions")
                    If Not IsDBNull(.Item("LeavesAmount")) Then report.Parameters("LeavesAmount").Value = .Item("LeavesAmount")
                    If Not IsDBNull(.Item("Payment")) Then report.Parameters("Payment").Value = .Item("Payment")
                    If Not IsDBNull(.Item("GrossSalary")) Then report.Parameters("GrossSalary").Value = .Item("GrossSalary")
                    If Not IsDBNull(.Item("MonthDays")) Then report.Parameters("MonthDays").Value = .Item("MonthDays")
                    If Not IsDBNull(.Item("ActualDays")) Then report.Parameters("ActualDays").Value = .Item("ActualDays")
                    If Not IsDBNull(.Item("VocationDays")) Then report.Parameters("VocationDays").Value = .Item("VocationDays")
                    If Not IsDBNull(.Item("WeekOffDays")) Then report.Parameters("WeekOffDays").Value = .Item("WeekOffDays")
                    If Not IsDBNull(.Item("AbsenceDays")) Then report.Parameters("AbsenceDays").Value = .Item("AbsenceDays")
                    If Not IsDBNull(.Item("HouresRequired")) Then report.Parameters("HouresRequired").Value = .Item("HouresRequired")
                    If Not IsDBNull(.Item("ActualHoures")) Then report.Parameters("ActualHoures").Value = .Item("ActualHoures")
                    If Not IsDBNull(.Item("VocationBegBalance")) Then report.Parameters("VocationBegBalance").Value = .Item("VocationBegBalance")
                    If Not IsDBNull(.Item("AccruedVocationDays")) Then report.Parameters("AccruedVocationDays").Value = .Item("AccruedVocationDays")
                    If Not IsDBNull(.Item("VocationAtEndYear")) Then report.Parameters("VocationAtEndYear").Value = .Item("VocationAtEndYear")
                    If Not IsDBNull(.Item("VocationSick")) Then report.Parameters("VocationSick").Value = .Item("VocationSick")
                    If Not IsDBNull(.Item("NetSalary")) Then report.Parameters("NetSalary").Value = .Item("NetSalary")
                    If Not IsDBNull(.Item("SalaryMonth")) Then report.Parameters("SalaryMonth").Value = .Item("SalaryMonth")
                    If Not IsDBNull(.Item("HouresNetBonus")) Then report.Parameters("HouresNetBonus").Value = .Item("HouresNetBonus")
                    If Not IsDBNull(.Item("HouresNetLeaves")) Then report.Parameters("HouresNetLeaves").Value = .Item("HouresNetLeaves")
                    ' MsgBox(.Item("HouresNetLeaves"))
                    If Not IsDBNull(.Item("Indenty")) Then report.Parameters("Indenty").Value = .Item("Indenty")
                    If Not IsDBNull(.Item("BankName")) Then report.Parameters("BankName").Value = .Item("BankName")
                    If Not IsDBNull(.Item("BankNo")) Then report.Parameters("BankNo").Value = .Item("BankNo")
                    If Not IsDBNull(.Item("BankBranch")) Then report.Parameters("BankBranch").Value = .Item("BankBranch")
                    If Not IsDBNull(.Item("IBAN")) Then report.Parameters("IBAN").Value = .Item("IBAN")
                    If Not IsDBNull(.Item("AbsenceAmount")) Then report.Parameters("AbsenceAmount").Value = .Item("AbsenceAmount")
                    If Not IsDBNull(.Item("ProcessType")) Then report.Parameters("ProcessType").Value = .Item("ProcessType")
                    If Not IsDBNull(.Item("SavingsFund")) Then report.Parameters("SavingsFund").Value = .Item("SavingsFund")
                    If Not IsDBNull(.Item("SalaryPerHour")) Then
                        report.XrLabelSalaryPerHourParameter.Visible = True
                        report.XrLabelSalaryPerHour.Visible = True
                        report.XrLabelSalaryPerHourParameter.Text = .Item("SalaryPerHour")
                    End If
                    If Not IsDBNull(.Item("BeginDate")) Then
                        If CStr(.Item("BeginDate")) = String.Empty Then
                            report.Parameters("BeginDate").Value = DBNull.Value
                        Else
                            report.Parameters("BeginDate").Value = Format(.Item("BeginDate"), "yyyy-MM-dd")
                        End If
                    End If

                    If Not IsDBNull(.Item("ProcessType")) Then
                        Select Case CInt(.Item("ProcessType"))
                            Case 1
                                report.XrLabelProcessTypeWords.Text = "دوام ثابت وردية"
                                report.XrLabelActualHoures.Visible = False
                                report.XrLabelActualHouresParameters.Visible = False
                            Case 2
                                report.XrLabelProcessTypeWords.Text = "ساعات يومية مطلوبة"
                                report.XrLabelActualHoures.Visible = False
                                report.XrLabelActualHouresParameters.Visible = False
                            Case 3
                                report.XrLabelProcessTypeWords.Text = "راتب /الساعة"
                                report.XrLabelActualHoures.Visible = True
                                report.XrLabelActualHouresParameters.Visible = True
                            Case 4
                                report.XrLabelProcessTypeWords.Text = "دوام بوجود حركة"
                                report.XrLabelActualHoures.Visible = False
                                report.XrLabelActualHouresParameters.Visible = False
                            Case 6
                                report.XrLabelProcessTypeWords.Text = "ساعات شهرية مطلوبة"
                                report.XrLabelSalaryPerHour.Visible = False
                                report.XrLabelSalaryPerHourParameter.Visible = False
                                report.XrLabelDeductAbsenceDays.Visible = False
                                report.XrLabelDeductAbsenceDaysParameter.Visible = False
                                report.XrLabelDeductAbsenceDaysParameter.Value = 0
                                report.XrLabelHolidays.Visible = False
                                report.XrLabelHolidaysParameters.Visible = False
                                report.XrLabelBonusHours.Visible = True
                                report.XrLabelBonusHoursParameters.Visible = True
                                report.XrLabelLeavesHours.Visible = False
                                report.XrLabelLeavesHoursParameters.Visible = False
                                report.XrLabelBonusAmount.Visible = False
                                report.XrLabelBonusAmountParameters.Visible = False
                                report.XrLabelDeductLateParameter.Visible = False
                                report.XrLabelDeductLate.Visible = False
                            Case 7
                                report.XrLabelActualHoures.Visible = False
                                report.XrLabelActualHouresParameters.Visible = False
                                report.XrLabelProcessTypeWords.Text = "نظام المياومة"
                                report.XrLabelBonusAmount.Visible = False
                                report.XrLabelBonusAmountParameters.Visible = False
                                report.XrLabelDeductLate.Visible = False
                                report.XrLabelDeductLateParameter.Visible = False
                                report.XrLabelDeductAbsenceDays.Visible = False
                                report.XrLabelDeductAbsenceDaysParameter.Visible = False
                                report.XrLabelRequiredHours.Visible = False
                                report.XrLabelRequiredHoursParameters.Visible = False
                                report.XrLabelBonusHours.Visible = False
                                report.XrLabelBonusHoursParameters.Visible = False
                                report.XrLabelLeavesHours.Visible = False
                                report.XrLabelLeavesHoursParameters.Visible = False

                        End Select
                    End If
                End With

                Dim _ShowVocationsTable As String = "False"
                Dim _AttShowAdditionsInSalarySlip As String = "False"
                Dim _AttShowPaymentsInSalarySlip As String = "False"

                Try
                    SqlString = " select SettingValue From Settings where SettingName ='VocationTableInMonthSalaryVisible';
                          select SettingValue From Settings where SettingName ='AttShowAdditionsInSalarySlip';
                          select SettingValue From Settings where SettingName ='AttShowPaymentsInSalarySlip'"
                    sql.SqlTrueTimeRunQuery(SqlString)
                    If sql.SQLDS.Tables(0).Rows.Count > 0 Then _ShowVocationsTable = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
                    If sql.SQLDS.Tables(1).Rows.Count > 0 Then _AttShowAdditionsInSalarySlip = CStr(sql.SQLDS.Tables(1).Rows(0).Item("SettingValue"))
                    If sql.SQLDS.Tables(2).Rows.Count > 0 Then _AttShowPaymentsInSalarySlip = CStr(sql.SQLDS.Tables(2).Rows(0).Item("SettingValue"))
                Catch ex As Exception
                    XtraMessageBox.Show(ex.ToString)
                End Try


                If _ShowVocationsTable = "True" Then
                    SalaryPosted.GridControlVocations.DataSource = Nothing
                    report.XrPanelVocations.Visible = True
                    Try
                        SqlString = " select T.Vocation,Sum(V.NoDays) as VocationDays from Vocations V
                                        left join VocationsTypes T on V.VocationType=T.VocID 
                                        Where FromDate BETWEEN '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' AND '" & Format(CDate(_Date__To), "yyyy-MM-dd") & "' 
                                        and EmployeeID='" & _EmployeeId & "'
                                        group by T.Vocation "
                        sql.SqlTrueTimeRunQuery(SqlString)
                        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            SalaryPosted.GridControlVocations.DataSource = sql.SQLDS.Tables(0)
                            report.PrintableComponentContainer1.PrintableComponent = SalaryPosted.GridControlVocations
                            report.PrintableComponentContainer1.Visible = True
                        Else
                            report.PrintableComponentContainer1.Visible = False
                        End If
                    Catch ex As Exception
                        report.PrintableComponentContainer1.Visible = False
                    End Try
                Else
                    report.PrintableComponentContainer1.Visible = False
                End If

                If _AttShowAdditionsInSalarySlip = "True" Then
                    SalaryPosted.GridControlAdds.DataSource = Nothing
                    Try
                        SqlString = "  SELECT  T.[AdditionsType] as AdditionType ,sum(AdditionAmount) as AdditionAmount FROM [dbo].[AttEmployeeAdditions] A
                                        left join EmployeesData E on A.EmployeeID=E.EmployeeID left join [AttAdditionsTypes] T on A.AdditionType=T.ID
                                        Where AdditionDate BETWEEN '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' AND '" & Format(CDate(_Date__To), "yyyy-MM-dd") & "' 
                                        and A.EmployeeID='" & _EmployeeId & "'
                                        group by T.[AdditionsType]  "
                        sql.SqlTrueTimeRunQuery(SqlString)
                        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            SalaryPosted.GridControlAdds.DataSource = sql.SQLDS.Tables(0)
                            report.PrintableComponentContainerAdds.PrintableComponent = SalaryPosted.GridControlAdds
                            report.PrintableComponentContainerAdds.Visible = True
                        Else
                            report.PrintableComponentContainerAdds.Visible = False
                        End If
                    Catch ex As Exception
                        report.PrintableComponentContainerAdds.Visible = False
                    End Try
                Else
                    report.PrintableComponentContainerAdds.Visible = False
                End If


                If _AttShowPaymentsInSalarySlip = "True" Then
                    SalaryPosted.GridControlDiscounts.DataSource = Nothing
                    Try
                        SqlString = "  SELECT  T.[PaymentType] as PaymentType,sum([PaymentAmount]) as PaymentAmount FROM [dbo].[AttEmployeePayments] P
                                        left join EmployeesData E on P.EmployeeID=E.EmployeeID left join [AttPaymentsTypes] T on P.PaymentType=T.ID
                                        Where P.[Status]=1 And [PaymentDate] BETWEEN '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' AND '" & Format(CDate(_Date__To), "yyyy-MM-dd") & "' 
                                        and P.EmployeeID='" & _EmployeeId & "'
                                        group by T.[PaymentType] "
                        sql.SqlTrueTimeRunQuery(SqlString)
                        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            SalaryPosted.GridControlDiscounts.DataSource = sql.SQLDS.Tables(0)
                            report.PrintableComponentContainerDiscount.PrintableComponent = SalaryPosted.GridControlDiscounts
                            report.PrintableComponentContainerDiscount.Visible = True
                        Else
                            report.PrintableComponentContainerDiscount.Visible = False
                        End If

                    Catch ex As Exception
                        report.PrintableComponentContainerDiscount.Visible = False
                    End Try
                Else
                    report.PrintableComponentContainerDiscount.Visible = False
                End If
                Dim _VocationDetails = GetVocationsBalancesByEmployee(_EmployeeId, 1, Today())
                report.Parameters("VocationAtEndYear").Value = _VocationDetails.Balance
                report.Parameters("AccruedVocationDays").Value = _VocationDetails.AccruedVocations
                report.Parameters("VocationBegBalance").Value = _VocationDetails.BeginingBalance
                report.Parameters("VocationSick").Value = 0

                'If CStr(report.Parameters("AbsenceDays").Value) = "" Then report.Parameters("AbsenceDays").Value = DBNull.Value
                'If CStr(report.Parameters("HouresRequired").Value) = "" Then report.Parameters("HouresRequired").Value = DBNull.Value
                'If CStr(report.Parameters("ActualHoures").Value) = "" Then report.Parameters("ActualHoures").Value = DBNull.Value
                'If CStr(report.Parameters("VocationBegBalance").Value) = "" Then report.Parameters("VocationBegBalance").Value = DBNull.Value
                'If CStr(report.Parameters("AccruedVocationDays").Value) = "" Then report.Parameters("AccruedVocationDays").Value = DBNull.Value
                'If CStr(report.Parameters("VocationAtEndYear").Value) = "" Then report.Parameters("VocationAtEndYear").Value = DBNull.Value
                'If CStr(report.Parameters("VocationSick").Value) = "" Then report.Parameters("VocationSick").Value = DBNull.Value
                'If CStr(report.Parameters("NetSalary").Value) = "" Then report.Parameters("NetSalary").Value = DBNull.Value
                'If CStr(report.Parameters("SalaryMonth").Value) = "" Then report.Parameters("SalaryMonth").Value = DBNull.Value
                '''''
                report.CreateDocument()
                report.PrintingSystem.ShowMarginsWarning = False
                report.RequestParameters = False

                Select Case _PrintOption
                    Case "Print"
                        report.Print()
                    Case "Preview"
                        Dim printTool As New ReportPrintTool(report)
                        printTool.AutoShowParametersPanel = False
                        printTool.ShowPreviewDialog()
                    Case "Pdf"
                        report.ExportToPdf("Salary.pdf")
                End Select
            Case "2"
                Dim report As New SalaryReportPTEC()
                With report
                    ._DocID = _DocID
                    Select Case _PrintOption
                        Case "Print"
                            report.Print()
                        Case "Preview"
                            Dim printTool As New ReportPrintTool(report)
                            printTool.AutoShowParametersPanel = False
                            printTool.ShowPreviewDialog()
                        Case "Pdf"
                            report.ExportToPdf("Salary.pdf")
                    End Select
                End With
        End Select

        'SalaryMonthForm.DocumentViewer1.DocumentSource = report
        'SalaryMonthForm.RibbonPage2.Visible = False
        'SalaryMonthForm.Show()


    End Sub


    Public Sub ProcessTransWithUserAndDate(DDDdate, UserID)
        Dim TableA As New DataTable
        Dim TableB As New DataTable
        Dim AttTable As New DataTable
        Dim i As Integer
        Dim sql As New SQLControl
        Dim MaxId As Integer = 0
        Dim CheckIn As String = "IN"
        Dim CheckOut As String = "Out"
        Dim Checkin2 As String = "In2"
        Dim Checkout2 As String = "Out2"

        Dim CurrDateTime As String = Format(Now, "yyyy-MM-dd HH:mm")

        Try

            Dim DDdate = Format(DateTime.Parse(DDDdate), "yyyy-MM-dd")


            For UserLoop = 1 To 10


                Dim CheckInSQL As String = "SELECT TOP (1)  [ID] As MaxInID,CHECKTYPE FROM [AttCHECKINOUT] 
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'I' COLLATE Latin1_General_CS_AS  and Edited Is Null  "
                sql.SqlTrueTimeRunQuery(CheckInSQL)

                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    CheckIn = (sql.SQLDS.Tables(0).Rows(i).Item("CHECKTYPE").ToString())
                Else
                    CheckIn = "NoIn"
                End If


                Dim CheckOutSQL As String = "SELECT TOP (1)  [ID] As MaxOutID,CHECKTYPE FROM [AttCHECKINOUT] 
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS  and Edited Is Null   "
                sql.SqlTrueTimeRunQuery(CheckOutSQL)

                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    CheckOut = (sql.SQLDS.Tables(0).Rows(i).Item("CHECKTYPE").ToString())
                Else
                    CheckOut = "NoOut"
                End If


                If CheckIn = "NoIn" Or CheckOut = "NoOut" Then
                    GoTo DD
                End If 'check if first row In and The Second Out


                If CheckIn = "I" And CheckOut = "O" Then

                    Dim SQLString As String = " Insert Into CheckInOut (TransID,UserID,UserName,In" & 1 & ")  ( SELECT TOP (1) [ID],[USERID],'', CHECKTIME
                                    FROM [AttCHECKINOUT]
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'I' COLLATE Latin1_General_CS_AS  and Edited Is Null  )"
                    Dim SQLUpdate As String = " Update Top(1) AttCHECKINOUT Set Edited = 1  , EditedDate= '" & CurrDateTime & "' 
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'I'  COLLATE Latin1_General_CS_AS  and Edited Is Null  "
                    sql.SqlTrueTimeRunQuery(SQLString)
                    sql.SqlTrueTimeRunQuery(SQLUpdate)


                    Dim GetMaxID As String = "Select Max(ID) as MaxID from [CheckInOut] "
                    sql.SqlTrueTimeRunQuery(GetMaxID)
                    If sql.SQLDS.Tables(0).Rows(i).Item("MaxID").ToString <> String.Empty Then
                        MaxId = sql.SQLDS.Tables(0).Rows(i).Item("MaxID").ToString
                    End If



                    Dim SqlSelect As String = " SELECT TOP (1) CHECKTIME,[ID] as AttID
                                        FROM [AttCHECKINOUT]
                                        where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                        and USERID = " & UserLoop & "
                                        And CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS and Edited Is Null  "
                    sql.SqlTrueTimeRunQuery(SqlSelect)
                    Dim ChekOut As String = Format(sql.SQLDS.Tables(0).Rows(i).Item("CHECKTIME"), "yyyy-MM-dd HH:mm")
                    Dim TransIDOut As String = sql.SQLDS.Tables(0).Rows(i).Item("AttID").ToString



                    Dim SQLString2 As String = " Update CheckInOut Set Out" & 1 & " = '" & ChekOut & "' , TransIDOut=" & TransIDOut & "
                                                     where  [ID]= " & MaxId

                    Dim SQLUpdate2 As String = " Update Top(1) AttCHECKINOUT Set Edited = 1  , EditedDate= '" & CurrDateTime & "'
                                        where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                        and USERID = " & UserLoop & "
                                        And CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS and Edited Is Null   "
                    Dim UpdateElapse As String = " Update  CheckInOut Set ElapseTime = (select  CONVERT(VARCHAR(8), DATEADD(SECOND, DATEDIFF(SECOND,In1, Out1),0), 108) from [CheckInOut]  where  [ID]= " & MaxId & ") where  [ID]= " & MaxId & " "

                    sql.SqlTrueTimeRunQuery(SQLString2)
                    sql.SqlTrueTimeRunQuery(SQLUpdate2)
                    sql.SqlTrueTimeRunQuery(UpdateElapse)
                End If
DD:
            Next UserLoop



            For UserLoop = 1 To 10


                Dim CheckInSQL As String = "SELECT TOP (1)  [ID] As MaxInID,CHECKTYPE FROM [AttCHECKINOUT] 
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'i'  COLLATE Latin1_General_CS_AS and Edited Is Null "
                sql.SqlTrueTimeRunQuery(CheckInSQL)

                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    CheckIn = (sql.SQLDS.Tables(0).Rows(i).Item("CHECKTYPE").ToString())
                Else
                    CheckIn = "NoIn"
                End If


                Dim CheckOutSQL As String = "SELECT TOP (1)  [ID] As MaxOutID,CHECKTYPE FROM [AttCHECKINOUT] 
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'o' COLLATE Latin1_General_CS_AS and Edited Is Null "

                sql.SqlTrueTimeRunQuery(CheckOutSQL)

                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    CheckOut = (sql.SQLDS.Tables(0).Rows(i).Item("CHECKTYPE").ToString())
                Else
                    CheckOut = "NoOut"
                End If




                If CheckIn = "NoIn" Or CheckOut = "NoOut" Then
                    GoTo EE
                End If



                If CheckIn = "i" And CheckOut = "o" Then

                    Dim SQLString As String = " Insert Into CheckInOut (TransID,UserID,UserName,In" & 2 & ")  ( SELECT TOP (1) [ID],[USERID],'', CHECKTIME
                                    FROM [AttCHECKINOUT]
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                    and USERID = " & UserLoop & "
                                    And CHECKTYPE = 'i' COLLATE Latin1_General_CS_AS and Edited Is Null 
                                     )"
                    Dim SQLUpdate As String = " Update Top(1) AttCHECKINOUT Set Edited = 1  , EditedDate= '" & CurrDateTime & "'
                                    where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                     and  USERID = " & UserLoop & "
                                    And CHECKTYPE = 'i' COLLATE Latin1_General_CS_AS and Edited Is Null  "
                    sql.SqlTrueTimeRunQuery(SQLString)
                    sql.SqlTrueTimeRunQuery(SQLUpdate)




                    Dim GetMaxID As String = "Select Max(ID) as MaxID from [CheckInOut] "
                    sql.SqlTrueTimeRunQuery(GetMaxID)
                    If sql.SQLDS.Tables(0).Rows(i).Item("MaxID").ToString <> String.Empty Then
                        MaxId = sql.SQLDS.Tables(0).Rows(i).Item("MaxID").ToString
                    End If



                    Dim SqlSelect As String = " SELECT TOP (1) CHECKTIME,[ID] as AttID
                                        FROM [AttCHECKINOUT]
                                        where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                        and USERID = " & UserLoop & "
                                        And CHECKTYPE = 'o' COLLATE Latin1_General_CS_AS and Edited Is Null  "
                    sql.SqlTrueTimeRunQuery(SqlSelect)
                    Dim ChekOut As String = Format(sql.SQLDS.Tables(0).Rows(i).Item("CHECKTIME"), "yyyy-MM-dd HH:mm")
                    Dim TransIDOut As String = sql.SQLDS.Tables(0).Rows(i).Item("AttID").ToString



                    Dim SQLString2 As String = " Update CheckInOut Set Out" & 2 & " = '" & ChekOut & "' , TransIDOut=" & TransIDOut & "
                                                     where  [ID]= " & MaxId

                    Dim SQLUpdate2 As String = " Update Top(1) AttCHECKINOUT Set Edited = 1  
                                        where CHECKTIME BETWEEN '" & DDdate & " 00:00:00' and '" & DDdate & " 23:59:59'
                                        and USERID = " & UserLoop & "
                                        And CHECKTYPE = 'o' COLLATE Latin1_General_CS_AS and Edited Is Null   "
                    Dim UpdateElapse As String = " Update  CheckInOut Set ElapseTime = (select  CONVERT(VARCHAR(8), DATEADD(SECOND, DATEDIFF(SECOND,Out2, In2),0), 108) from [CheckInOut]  where  [ID]= " & MaxId & ") where  [ID]= " & MaxId & " "

                    sql.SqlTrueTimeRunQuery(SQLString2)
                    sql.SqlTrueTimeRunQuery(SQLUpdate2)
                    sql.SqlTrueTimeRunQuery(UpdateElapse)
                End If
EE:
            Next UserLoop


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

        End Try

    End Sub



    Public Sub ReadAttTrans()
        Dim SQLString As String = " SELECT Badgenumber AS USERID,CHECKTIME,CHECKTYPE,SENSORID,sn 
                                    FROM  CHECKINOUT,USERINFO  
                                    Where CHECKINOUT.USERID =USERINFO.USERID  AND [AttProcess] is null "
        Try
            Dim AttTable As New DataTable
            Select Case GlobalVariables._AttConnectionType
                Case "Access"
                    Dim con = New System.Data.OleDb.OleDbConnection With {
                        .connectionString = AttConectionString()
                    }
                    con.Open()
                    '     Dim SQLString As String = " SELECT USERID,CHECKTIME,CHECKTYPE,SENSORID,sn FROM  CHECKINOUT where [AttProcess] is null  "
                    Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
                    da.Fill(AttTable)
                    con.Close()
                Case "Sql"
                    Dim Sql As New SQLControl
                    Sql.SqlTrueTimeRunQuery(SQLString)
                    AttTable = Sql.SQLDS.Tables(0)
            End Select


            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then Exit Sub
            Dim connectionString As String = My.Settings.TrueTimeConnectionString
            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.AttCHECKINOUT;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "AttCHECKINOUT"
                    bulkCopy.WriteToServer(newProducts)
                End Using

                EditProcess()

                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())

                Dim TotalReads As Integer = countEnd - countStart


                MyGlobalString = CStr(TotalReads)

                'InsertLogs("تم قراءة الساعة", "ReadAttTrans", "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers)
                InsertLogs(GlobalVariables.CurrUser, "قراءة الساعة", "ReadAttTransFunction", Now, String.Empty, "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers, String.Empty, SQLString)



            End Using


        Catch ex As Exception
            '  MsgBox("خطا في عملية القراءة ، تاكد من اضافة عمود Process  من شاشة الاعدادات")
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try

    End Sub ' قراءة حركات الساعة وادخالها الى البرنامج دفعة واحدة

    Function SendDirectWhatsAppMessage(destination As String, sms As String) As String
        destination = CType(Val(destination), String)
        Dim strUrl As String
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [Settings] where [SettingName]='SmsWhatsAppAPI' ")
        strUrl = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Select Case Len(destination)
            Case 9
                destination = "970" & destination
            Case 12
                destination = destination
            Case Else
                Return "False"
        End Select
        strUrl = strUrl.Replace("#MobileNo#", destination)
        strUrl = strUrl.Replace("#Message#", sms)

        If Not LogInMenue.HasWhatsAppPackage Then
            Return "WhatsApp Package Disabled"
        End If

        Dim request As WebRequest = HttpWebRequest.Create(strUrl)
        Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
        Dim s As Stream = response.GetResponseStream()
        Dim readStream As New StreamReader(s)
        Dim dataString As String = readStream.ReadToEnd()
        Dim Result As String = dataString.ToString
        response.Close()
        s.Close()
        readStream.Close()
        Return Result
        ' Return "Success"
    End Function
    Public Function SendFileToWhatsApp(_MobileNo As String, DocName As String, FileName As String, Caption As String, RefName As String) As Boolean
        If GetAPISenderType() = "green" Then
            SendFileToWhatsAppByGreenAPI(_MobileNo, DocName, FileName, Caption, RefName)
        Else
            SendFileViaCustomWhatsAppAPI(_MobileNo, DocName, FileName, Caption, RefName)
        End If
        Return True
    End Function
    Public Function SendFileToWhatsAppByGreenAPI(_MobileNo As String, DocName As String, FileName As String, Caption As String, RefName As String) As Boolean
        Dim flags As Integer = 0
        Dim isUp As Boolean = InternetGetConnectedState(flags, 0)
        If isUp = False Then
            MsgBoxShowError("خطا في الاتصال بالانترنت")
            WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", "No InterNet Connection", 0, RefName)
            Return (False)
        End If

        If Len(_MobileNo) < 8 Then
            WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", "Mobile No Less Than 8 Character", 0, RefName)
            Return (False)
        End If

        Caption = Left(Caption, 15).Replace("""", "\""").Replace(vbCrLf, "\n").Replace(Environment.NewLine, "\n")


        Select Case Len(_MobileNo)
            Case 10
                _MobileNo = "972" & _MobileNo.Substring(1)
            Case 9
                _MobileNo = "972" & _MobileNo
            Case Else
                _MobileNo = _MobileNo.TrimStart("0"c)
        End Select

        Dim client As New HttpClient()
        Dim url As String = GetWhatsAppURLString(True)
        Dim payload As New MultipartFormDataContent()
        Dim chatId As String = _MobileNo & "@c.us"
        Dim files As New List(Of String)() From {DocName}
        Dim response As HttpResponseMessage
        Dim _CompanyData = GetCompanyData()
        Dim _InstanceID As String = GetInstanceID()

        Caption += "\n" & " للمراجعة  " & _CompanyData.CompanyNameForWhattsUp & "\n" & _CompanyData.CompanyMobile

        Try
            payload.Add(New StringContent(chatId), "chatId")
            payload.Add(New StringContent(Caption), "caption")
            For Each filePath As String In files
                Dim fileContent As New ByteArrayContent(File.ReadAllBytes(filePath))
                fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf")
                Dim fileInfo As New FileInfo(filePath)
                payload.Add(fileContent, "file", FileName)
            Next
            response = client.PostAsync(url, payload).Result
            Dim responseContent As String = response.Content.ReadAsStringAsync().Result
            If response.IsSuccessStatusCode Then
                Dim result As GreenApiResponse = JsonConvert.DeserializeObject(Of GreenApiResponse)(responseContent)

                ' Optional: Add your own success logic depending on API contract
                If Not String.IsNullOrEmpty(result.IdMessage) Then
                    My.Computer.Audio.Play(My.Resources.Send, AudioPlayMode.Background)
                    WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", responseContent, 1, RefName)
                    Return (True)

                Else
                    My.Computer.Audio.Play(My.Resources.Send, AudioPlayMode.Background)
                    WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", responseContent, 0, RefName)
                    Return (False)
                End If
            Else
                WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", responseContent, 0, RefName)
                Return (False)
            End If
        Catch ex As Exception
            ' Console.WriteLine("An error occurred: " & ex.Message)
            WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", ex.Message, 0, RefName)
            'MsgBoxShowError(ex.Message)
        End Try
        Return (False)
    End Function
    Public Function SendFileViaCustomWhatsAppAPI(_MobileNo As String, filePath As String, FileName As String, Caption As String, RefName As String) As Boolean
        Try
            ' Validate file existence
            If Not File.Exists(filePath) Then
                MsgBox("File not found.")
                Return False
            End If
            If Len(_MobileNo) = 9 Then _MobileNo = "0" & _MobileNo
            Caption = Left(Caption, 15).Replace("""", "\""").Replace(vbCrLf, "\n").Replace(Environment.NewLine, "\n")
            Dim _CompanyData = GetCompanyData()
            Caption += " للمراجعة  " & _CompanyData.CompanyNameForWhattsUp & _CompanyData.CompanyMobile
            If Len(_MobileNo) = 18 Then
                _MobileNo = _MobileNo & "@g.us"
            End If
            ' Convert file to Base64
            Dim fileBytes As Byte() = File.ReadAllBytes(filePath)
            Dim base64String As String = Convert.ToBase64String(fileBytes)

            Dim _InstanceID As String = GetInstanceID()
            ' Prepare JSON payload
            Dim requestBody As New With {
            .accountId = _InstanceID,
            .chatId = _MobileNo,
            .document = base64String,
            .documentName = Caption & " " & FileName
        }

            Dim json As String = JsonConvert.SerializeObject(requestBody)

            ' Setup HTTP request
            Dim url As String = GetWhatsAppURLString(True)
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json"
            request.Timeout = 10000

            ' Write request body
            Using writer As New StreamWriter(request.GetRequestStream())
                writer.Write(json)
            End Using

            ' Get response
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim responseText As String = reader.ReadToEnd()
                    WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", responseText, 1, RefName)
                End Using
            End Using

            Return True
        Catch ex As Exception
            WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsApp", ex.Message, 0, RefName)
            'MsgBox("Error sending file: " & ex.Message)
            Return False
        End Try
    End Function




    'Public Sub SendFileToWhatsApp2(_MobileNo As String, DocName As String, FileName As String, Caption As String)
    '    Caption = Left(Caption, 15)
    '    Select Case Len(_MobileNo)
    '        Case 10
    '            _MobileNo = "972" & _MobileNo.Substring(1)
    '        Case 9
    '            _MobileNo = "972" & _MobileNo
    '        Case Else
    '            _MobileNo = _MobileNo.TrimStart("0"c)
    '    End Select
    '    Dim client As New HttpClient()
    '    Dim url As String = "https://api.green-api.com/waInstance7103903885/sendMessage/83ac2143e09b4d45831e7b7423ae5a2c4bed9c1bed394c2389"
    '    Dim payload As New MultipartFormDataContent()
    '    Dim chatId As String = _MobileNo & "@c.us"
    '    Dim files As New List(Of String)() From {DocName}
    '    Dim response As HttpResponseMessage
    '    Try
    '        payload.Add(New StringContent(chatId), "chatId")
    '        payload.Add(New StringContent(Caption), "caption")
    '        For Each filePath As String In files
    '            Dim fileContent As New ByteArrayContent(File.ReadAllBytes(filePath))
    '            fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf")
    '            Dim fileInfo As New FileInfo(filePath)
    '            payload.Add(fileContent, "file", FileName)
    '        Next
    '        response = client.PostAsync(url, payload).Result
    '        Dim responseContent As String = response.Content.ReadAsStringAsync().Result
    '        Console.WriteLine(responseContent)
    '        ' My.Computer.Audio.Play(My.Resources.Send, AudioPlayMode.Background)
    '    Catch ex As Exception
    '        ' Console.WriteLine("An error occurred: " & ex.Message)
    '        MsgBoxShowError(ex.Message)
    '    End Try
    'End Sub
    Public Sub SendFileToWhatsAppGroup(_GroupID As String, DocName As String, FileName As String, Caption As String)
        'If CheckIFHasAccessOnWhatsApp() Then
        '    'mm
        'End If
        '  Caption = Left(Caption, 15)
        Dim client As New HttpClient()
        Dim url As String = GetWhatsAppURLString(True)
        'Dim url As String = "https://api.green-api.com/waInstance7103903885/sendMessage/83ac2143e09b4d45831e7b7423ae5a2c4bed9c1bed394c2389"
        Dim payload As New MultipartFormDataContent()
        Dim chatId As String = _GroupID & "@g.us"
        Dim files As New List(Of String)() From {DocName}
        Dim response As HttpResponseMessage
        ' Dim _CompanyData = GetCompanyData()
        '  Caption += " " & _CompanyData.CompanyNameForWhattsUp
        Try
            payload.Add(New StringContent(chatId), "chatId")
            payload.Add(New StringContent(Caption), "caption")
            For Each filePath As String In files
                Dim fileContent As New ByteArrayContent(File.ReadAllBytes(filePath))
                fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf")
                Dim fileInfo As New FileInfo(filePath)
                payload.Add(fileContent, "file", FileName)
            Next
            response = client.PostAsync(url, payload).Result
            Dim responseContent As String = response.Content.ReadAsStringAsync().Result
            Console.WriteLine(responseContent)
            My.Computer.Audio.Play(My.Resources.Send, AudioPlayMode.Background)
        Catch ex As Exception
            ' Console.WriteLine("An error occurred: " & ex.Message)
            MsgBoxShowError(ex.Message)
        End Try
    End Sub
    <DllImport("wininet.dll", SetLastError:=True)>
    Public Function InternetGetConnectedState(ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Boolean
    End Function
    Function SendSMSMessage(destination As String, sms As String, type As String, group As Boolean, referance As String) As String
        If String.IsNullOrWhiteSpace(destination) Then
            Return False
        End If
        If Len(destination) = 18 Then group = True
        Dim flags As Integer = 0
        Dim isUp As Boolean = InternetGetConnectedState(flags, 0)
        If Not isUp Then
            MsgBoxShowError("خطأ في الاتصال بالإنترنت")
            Return False
        End If

        Dim strUrl As String
        Dim sql As New SQLControl



        Select Case type
            Case "SMS"
                sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [Settings] where [SettingName]='SmsAPI' ")
                strUrl = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
                strUrl = strUrl.Replace("#MobileNo#", destination)
                strUrl = strUrl.Replace("#Message#", sms)
                Dim request As WebRequest = HttpWebRequest.Create(strUrl)
                Dim response As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)
                Dim s As Stream = response.GetResponseStream()
                Dim readStream As New StreamReader(s)
                Dim dataString As String = readStream.ReadToEnd()
                Dim Result As String = dataString.ToString
                response.Close()
                s.Close()
                readStream.Close()
                Return Result
            Case "WhatsApp"
                ' Escape message text for JSON (replace quotes and newlines)
                Dim _CompanyData = GetCompanyData()
                Dim safeMessage As String = sms.Replace("""", "\""").Replace(vbCrLf, "\n").Replace(Environment.NewLine, "\n")
                Dim URL As String = GetWhatsAppURLString(False)
                Dim RequestBody As String = ""
                Dim http As HttpWebRequest
                Dim dataStream As Stream
                Dim reader As StreamReader
                Dim response As WebResponse
                Dim responseText As String = String.Empty
                Dim _InstanceID As String = GetInstanceID()


                ' Normalize destination
                Dim _MobileNo As String = destination.Trim()
                If Not group Then
                    Select Case _MobileNo.Length
                        Case 10
                            If _MobileNo.StartsWith("0") Then
                                _MobileNo = "972" & _MobileNo.Substring(1)
                            End If
                        Case 9
                            _MobileNo = "972" & _MobileNo
                        Case Else
                            _MobileNo = _MobileNo.TrimStart("0"c)
                    End Select
                End If

                If GetAPISenderType() = "green" Then
                    Dim chatIdSuffix As String = If(group, "@g.us", "@c.us")
                    Dim chatId As String = _MobileNo & chatIdSuffix
                    RequestBody = String.Format("{{""chatId"":""{0}"",""message"":""{1}""}}", chatId, safeMessage)
                Else
                    ' Generic API structure
                    '_MobileNo = If(Len(_MobileNo) = 18, "@g.us", _MobileNo)
                    If Len(_MobileNo) = 18 Then
                        _MobileNo = _MobileNo & "@g.us"
                    End If
                    RequestBody = String.Format("{{""accountId"":""{0}"",""chatId"":""{1}"",""message"":""{2}""}}", _InstanceID, _MobileNo, safeMessage)
                End If

                ' Send HTTP request
                Try
                    http = CType(WebRequest.Create(URL), HttpWebRequest)
                    http.ContentType = "application/json"
                    http.Method = "POST"

                    Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(RequestBody)
                    http.ContentLength = byteArray.Length

                    dataStream = http.GetRequestStream()
                    dataStream.Write(byteArray, 0, byteArray.Length)
                    dataStream.Close()

                    response = http.GetResponse()
                    dataStream = response.GetResponseStream()
                    reader = New StreamReader(dataStream)
                    responseText = reader.ReadToEnd()

                    reader.Close()
                    dataStream.Close()
                    response.Close()

                    Console.WriteLine("Response: " & responseText)
                    WhatsAppLogMessage("TEXT", sms, _MobileNo, "SendTextToWhatsApp", responseText, 1, referance)
                    Return True
                Catch ex As WebException
                    MsgBoxShowError("فشل إرسال الرسالة عبر واتساب: " & ex.Message)
                    WhatsAppLogMessage("TEXT", sms, _MobileNo, "SendTextToWhatsApp", ex.Message, 0, referance)
                    Return False
                End Try
        End Select


        Return "True"
    End Function
    Private Function GetAPISenderType() As String
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _type As String
        Try
            sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenToken' "
            sql.SqlTrueTimeRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = "tts" Then
                _type = "tts"
            Else
                _type = "green"
            End If
        Catch ex As Exception
            Return "green"
        End Try
        Return _type
    End Function
    Private Function GetInstanceID() As String
        Dim sql As New SQLControl
        Dim sqlstring As String
        Try
            sqlstring = " select SettingValue from Settings where SettingName='WhatsAppGreenInstanceID' "
            sql.SqlTrueTimeRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            Return ""
        End Try
    End Function




    Function SendSMSMessageDirectFromtts(destination As String, sms As String) As String
        If String.IsNullOrWhiteSpace(destination) Then
            Return False
        End If

        Dim flags As Integer = 0
        Dim isUp As Boolean = InternetGetConnectedState(flags, 0)
        If Not isUp Then
            MsgBoxShowError("خطأ في الاتصال بالإنترنت")
            Return False
        End If

        Dim strUrl As String = "http://whatsapi.truetime.top:5051/send"
        Dim sql As New SQLControl

        Dim safeMessage As String = sms.Replace("""", "\""").Replace(vbCrLf, "\n").Replace(Environment.NewLine, "\n")
        Dim URL As String = GetWhatsAppURLString(False)
        Dim RequestBody As String = ""
        Dim http As HttpWebRequest
        Dim dataStream As Stream
        Dim reader As StreamReader
        Dim response As WebResponse
        Dim responseText As String = String.Empty
        Dim _InstanceID As String = 10670

        Dim _MobileNo As String = destination.Trim()

        Select Case _MobileNo.Length
            Case 10
                If _MobileNo.StartsWith("0") Then
                    _MobileNo = "972" & _MobileNo.Substring(1)
                End If
            Case 9
                _MobileNo = "972" & _MobileNo
            Case Else
                _MobileNo = _MobileNo.TrimStart("0"c)
        End Select



        RequestBody = String.Format("{{""accountId"":""{0}"",""chatId"":""{1}"",""message"":""{2}""}}", _InstanceID, _MobileNo, safeMessage)


        ' Send HTTP request
        Try
            http = CType(WebRequest.Create(URL), HttpWebRequest)
            http.ContentType = "application/json"
            http.Method = "POST"

            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(RequestBody)
            http.ContentLength = byteArray.Length

            dataStream = http.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            response = http.GetResponse()
            dataStream = response.GetResponseStream()
            reader = New StreamReader(dataStream)
            responseText = reader.ReadToEnd()

            reader.Close()
            dataStream.Close()
            response.Close()

            Console.WriteLine("Response: " & responseText)
            Return True
        Catch ex As WebException
            MsgBoxShowError("فشل إرسال الرسالة عبر واتساب: " & ex.Message)
            Return False
        End Try

        Return "True"
    End Function



    'Public Sub SendFileToWhatsAppForTest(_MobileNo As String, DocName As String)
    '    Select Case Len(_MobileNo)
    '        Case 10
    '            _MobileNo = "972" & _MobileNo.Substring(1)
    '        Case 9
    '            _MobileNo = "972" & _MobileNo
    '        Case Else
    '            _MobileNo = _MobileNo.TrimStart("0"c)
    '    End Select
    '    Dim client As New HttpClient()
    '    Dim url As String = "https://api.green-api.com/waInstance7103903885/sendFileByUpload/83ac2143e09b4d45831e7b7423ae5a2c4bed9c1bed394c2389"
    '    Dim payload As New MultipartFormDataContent()
    '    Dim chatId As String = _MobileNo & "@c.us"
    '    Dim files As New List(Of String)() From {DocName}
    '    Dim response As HttpResponseMessage
    '    Dim Caption As String = "Caption"
    '    Dim FileName As String = "file name"
    '    Try
    '        payload.Add(New StringContent(chatId), "chatId")
    '        payload.Add(New StringContent(Caption), "caption")
    '        For Each filePath As String In files
    '            Dim fileContent As New ByteArrayContent(File.ReadAllBytes(filePath))
    '            fileContent.Headers.ContentType = New System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf")
    '            Dim fileInfo As New FileInfo(filePath)
    '            payload.Add(fileContent, "file", FileName)
    '        Next
    '        response = client.PostAsync(url, payload).Result
    '        Dim responseContent As String = response.Content.ReadAsStringAsync().Result
    '        'WhatsAppLogMessage(FileName, Caption, _MobileNo, "SendFileToWhatsAppForTest", responseContent)
    '        Console.WriteLine(responseContent)
    '    Catch ex As Exception
    '        Console.WriteLine("An error occurred: " & ex.Message)
    '    End Try
    'End Sub
    Public Function SMSSendMessageToTable(SMSType As Integer, SMSDetails As String,
                                             SMSStatus As String, BulkNo As Integer,
                                             RefNo As Integer, RefMobile As String, RefName As String,
                                             AccrualDateTime As DateTime, Sent As Integer, DocName As Integer,
                                             DocID As Integer, DocCode As String, DocData As String) As Boolean
        Dim _TableName As String
        If Sent = 1 Then
            _TableName = "SmsSentMessages"
        Else
            _TableName = "SmsPendingMessages"
        End If

        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "INSERT INTO [dbo].[" & _TableName & "]
           ([SMSType]
           ,[SMSDetails]
           ,[SMSDatetime]
           ,[SMSUser]
           ,[SMSStatus]
           ,BulkNo
           ,[RefNo]
           ,[RefMobile]
           ,[RefName]
           ,[AccrualDateTime]
           ,[Sent],
DocName,DocID,DocCode,DocData)
     VALUES
           (N'" & SMSType & "'
           ,N'" & SMSDetails & "'
           ,GetDate()
           ,'" & GlobalVariables.CurrUser & "'
           ,'" & SMSStatus & "'
           ,'" & BulkNo & "'
           ,'" & RefNo & "'
           ,'" & RefMobile & "'
           ,N'" & RefName & "'
           ,'" & Format(AccrualDateTime, "yyyy-MM-dd") & "'
           ," & Sent & "
           ," & DocName & "
           ," & DocID & "
           ,'" & DocCode & "'
           ,'" & DocData & "')"
            sql.SqlTrueAccountingRunQuery(sqlstring)
        Catch ex As Exception

        End Try
        Return True
    End Function
    Public Sub WhatsAppLogMessage(fileName As String, caption As String, mobileNo As String, method As String, responseContent As String, result As Boolean, refName As String)
        Dim query As String = "INSERT INTO dbo.WhatsAppLogs (FileName, Caption, MobileNo, Method,ResponseContent,Result,UserNo,DeviceName,RefName) 
                               VALUES (@FileName, @Caption, @MobileNo, @Method,@ResponseContent,@Result,@UserNo,@DeviceName,@RefName)"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand(query, conn)
                ' Use parameters to protect against SQL injection
                cmd.Parameters.AddWithValue("@FileName", If(fileName, DBNull.Value))
                cmd.Parameters.AddWithValue("@Caption", If(caption, DBNull.Value))
                cmd.Parameters.AddWithValue("@MobileNo", If(mobileNo, DBNull.Value))
                cmd.Parameters.AddWithValue("@Method", If(method, DBNull.Value))
                cmd.Parameters.AddWithValue("@ResponseContent", If(responseContent, DBNull.Value))
                cmd.Parameters.AddWithValue("@Result", result)
                cmd.Parameters.AddWithValue("@UserNo", GlobalVariables.CurrUser)
                cmd.Parameters.AddWithValue("@DeviceName", GlobalVariables.CurrDevice)
                cmd.Parameters.AddWithValue("@RefName", refName)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' Ideally log this error to a file or monitoring system
                    'Throw New ApplicationException("Error inserting WhatsApp log entry.", ex)
                End Try
            End Using
        End Using
    End Sub

    Public Function SystemSerialNumber() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
            "{impersonationLevel=impersonate}!\\" &
            computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
            "Win32_Processor")

        Dim cpu_ids As String = String.Empty
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
            cpu_ids.Substring(2)
        If String.IsNullOrEmpty(cpu_ids) Then
            cpu_ids = "0"
        End If

        GlobalVariables.LocalDeviceKey = cpu_ids
        Return cpu_ids
    End Function


    Public Function ToLocalAttTrans(_FromDate As DateTime, _ToDate As DateTime, EmpId As Integer) As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[AttCHECKINOUT] ")
        Catch ex As Exception

        End Try

        Dim SQLString As String = " SELECT  [USERID]
                                      ,[CHECKTIME]      ,[CHECKTYPE]
                                      ,[VERIFYCODE]      ,[SENSORID]
                                      ,[Memoinfo]      ,[WorkCode]
                                      ,[sn]      ,[UserExtFmt]
                                      ,[AttProcess]      ,[Edited]
                                      ,[EditedDate]      ,[ID]
                                      ,[EditedType]      ,[TransIDOnAccess]
                                      ,[EditedUser]      ,[EditNote]
                                      ,[Latitude]      ,[Longitude]
                                      ,[Location]       
                                   FROM [dbo].[AttCHECKINOUT] where [CHECKTIME] between '" & Format(_FromDate.AddDays(-2), "yyyy-MM-dd") & "' and '" & Format(_ToDate.AddDays(2), "yyyy-MM-dd") & "'"
        If EmpId <> -1 Then
            SQLString += " and  USERID=" & EmpId
        End If

        Try
            Dim AttTable As New DataTable
            '  Select Case GlobalVariables._AttConnectionType
            '   Case "Sql"
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable = Sql.SQLDS.Tables(0)
            ' End Select
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then GoTo GG
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"

            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.AttCHECKINOUT;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "AttCHECKINOUT"
                    bulkCopy.WriteToServer(newProducts)
                End Using



                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())

                Dim TotalReads As Integer = countEnd - countStart


                MyGlobalString = CStr(TotalReads)

                'InsertLogs("تم قراءة الساعة", "ReadAttTrans", "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers)
                'InsertLogs(GlobalVariables.CurrUser, "قراءة الساعة", "ReadAttTransFunction", Now, String.Empty, "عدد الحركات " & MyGlobalString & " عدد الموظفين " & NewUsers, String.Empty, SQLString)



            End Using


        Catch ex As Exception
            '  MsgBox("خطا في عملية القراءة ، تاكد من اضافة عمود Process  من شاشة الاعدادات")
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function

    Public Function ToLocalItemsData() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[Items] ")
        Catch ex As Exception

        End Try

        Dim SQLString As String = " SELECT     ID, [Type]
                                              , [ItemNo]      , [ItemName]
                                              , [HasExpireDate]      , [LastPurchasePrice]
                                              , [LastPurchaseDate]      , [Price]
                                              , [ReOrderQuantity]      , [notes]      , [AccSales]
                                              , [AccPurches]      , [AccRetSales]
                                              , [AccRetPurches]      , [CategoryID]
                                              , [TradeMarkID]      , [GroupID]
                                              , [SaleOnScale]      , [ItemNo2]
                                              , [ItemNo3]      , [ItemNo4]
                                              , [ProductCompany]      , [WebSite1]
                                              , [WebSite2]      , [VisibleInAPP]
                                              , [Active]      , [ItemStatus]
                                              , [HasSerial]      , [TransOnShelf]
                                              , [MaxQuantity]      , [HasProductionEquation]
                                              , [CostCenter]      , [Vendor]
                                     FROM [dbo].[Items]"

        Try
            Dim AttTable As New DataTable
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable = Sql.SQLDS.Tables(0)
            ' End Select
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then GoTo GG
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"

            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.Items;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "Items"
                    bulkCopy.WriteToServer(newProducts)
                End Using

                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using


        Catch ex As Exception
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function

    Public Function ToLocalItemsUnitsData() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlLocalTrueTimeRunQuery("delete FROM [dbo].[Items_units] ")
        Catch ex As Exception

        End Try

        Dim SQLString As String = " SELECT id,
                                          [item_id]      ,[unit_id]
                                          ,[main_unit]      ,[EquivalentToMain]
                                          ,[item_unit_bar_code]      ,[Price1]
                                          ,[main_pay_unit]      ,[main_sell_unit]
                                          ,[Price2]      ,[Price3]
                                          ,[IsUnit]      ,[Measure]
                                          ,[Color]      ,[item_unit_pay_price]
                                     FROM [dbo].[Items_units]"

        Try
            Dim AttTable As New DataTable
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(SQLString)
            AttTable = Sql.SQLDS.Tables(0)
            ' End Select
            MyGlobalString = AttTable.Rows.Count
            If AttTable.Rows.Count = 0 Then GoTo GG
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"

            Using connection As SqlConnection =
            New SqlConnection(connectionString)
                connection.Open()
                Dim commandRowCount As New SqlCommand(
                "SELECT COUNT(*) FROM dbo.Items_units;",
                connection)
                Dim countStart As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim newProducts As DataTable = AttTable
                Using bulkCopy As SqlBulkCopy =
                New SqlBulkCopy(connection)
                    bulkCopy.DestinationTableName = "Items_units"
                    bulkCopy.WriteToServer(newProducts)
                End Using

                Dim countEnd As Long =
                System.Convert.ToInt32(commandRowCount.ExecuteScalar())
                Dim TotalReads As Integer = countEnd - countStart
                MyGlobalString = CStr(TotalReads)
            End Using


        Catch ex As Exception
            MyGlobalString = 0
            MsgBox(ex.ToString)
        End Try
GG:
        Return MyGlobalString
    End Function

    Public Sub UpdateMachineName()
        If GlobalVariables._AttConnectionType = "Access" Then
            Try
                Dim AttTable As New DataTable
                Dim con = New System.Data.OleDb.OleDbConnection With {.connectionString = AttConectionString()}
                con.Open()
                Dim SQLString As String = " SELECT  * FROM  [Machines]  "
                Dim da = New System.Data.OleDb.OleDbDataAdapter(SQLString, con)
                da.Fill(AttTable)
                con.Close()
                If AttTable.Rows.Count = 0 Then Exit Sub
                Dim connectionString As String = My.Settings.TrueTimeConnectionString
                Using connection As SqlConnection = New SqlConnection(connectionString)
                    connection.Open()
                    Dim commandRowCount As New SqlCommand("DELETE   from [Machines]", connection)
                    commandRowCount.ExecuteScalar()
                    Dim newProducts As DataTable = AttTable
                    Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(connection)
                        bulkCopy.DestinationTableName = "Machines"
                        bulkCopy.WriteToServer(newProducts)
                    End Using
                    connection.Close()
                End Using
            Catch ex As Exception
                '  MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Public Function GetNumbersForReseiptsVoucherMsgs() As String
        Dim _Numbers As String = ""
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select IsNull(SettingValue,0) as SettingValue from Settings where SettingName='NumbersForReseiptsVoucherMsgs'")
            _Numbers = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _Numbers = ""
        End Try
        Return _Numbers
    End Function
    Public Function VocationInsert(_type As Integer, _emp As Integer, _from As DateTime, _to As DateTime, _days As Decimal, _note As String, _docdate As Date, _source As String, _hours As String) As Integer
        Dim _VocID As Integer = 0
        Dim DateFrom As String = Format(_from, "yyyy-MM-dd")
        Dim DateTo As String = Format(_to, "yyyy-MM-dd")
        Dim DocDate As String = Format(_docdate, "yyyy-MM-dd")
        Dim _DaysNo As Decimal = _days
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = "   Insert Into Vocations " _
                                              & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource,HoursPriod) Output Inserted.VocID " _
                                              & " Values ( " _
                                              & String.Empty & _emp & "," _
                                              & "'" & DocDate & "'," _
                                              & "N'" & _type & "'," _
                                              & "'" & DateFrom & "'," _
                                              & "'" & DateTo & "'," _
                                              & String.Empty & _DaysNo & "," _
                                              & "N'" & _note & "'," _
                                              & "N'" & _source & "'," _
                                              & "'" & _hours & "'" _
                                              & " ) "
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                _VocID = sql.SQLDS.Tables(0).Rows(0).Item("VocID")
            End If
        Catch ex As Exception
            _VocID = 0
        End Try
        Return _VocID
    End Function
    Public Function VocationInsertNew(employeeID As Integer, vocationType As Integer, docNote As String,
                                      dateFrom As DateTime, dateTo As DateTime, docDate As DateTime,
                                      daysNo As Decimal, vocationSource As String, adjType As String,
                                      _hours As String, SalaryDocumentID As Integer) As Integer
        Dim _dateFrom As String = Format(dateFrom, "yyyy-MM-dd")
        Dim _dateTo As String = Format(dateTo, "yyyy-MM-dd")
        Dim _docDate As String = Format(docDate, "yyyy-MM-dd")
        Dim _vocID As Integer = 0
        If vocationSource = "adjust" And adjType = "+" Then
            daysNo = -1 * daysNo
        End If
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = "   Insert Into Vocations " _
                                          & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource,HoursPriod,SalaryDocumentID)  Output Inserted.VocID" _
                                          & " Values ( " _
                                          & String.Empty & employeeID & "," _
                                          & "'" & _docDate & "'," _
                                          & "N'" & vocationType & "'," _
                                          & "'" & _docDate & "'," _
                                          & "'" & _docDate & "'," _
                                          & String.Empty & daysNo & "," _
                                          & "N'" & docNote & "'," _
                                          & "N'" & vocationSource & "'," _
                                          & "'" & Right(_hours, 5) & "'," _
                                          & "'" & SalaryDocumentID & "'" _
                                          & " ) "
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                _vocID = sql.SQLDS.Tables(0).Rows(0).Item("VocID")
            End If
        Catch ex As Exception
            _vocID = 0
            MsgBox(" خطا، لم يتم اصدار اجازة ")
        End Try
        Return _vocID
    End Function
    Public Function CheckIfHasBonusRequest(_EmpID As Integer, _DocDate As Date) As (RequestId As Integer, RequestStatus As Integer)
        Dim _SQLString As String = "Select Id,[status] from AttEmployeeOvertime where [EmployeeId]=" & _EmpID & " and [Date_]='" & Format(_DocDate, "yyyy-MM-dd") & "'"
        Dim _SQL As New SQLControl
        _SQL.SqlTrueTimeRunQuery(_SQLString)
        If _SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            Return (CInt(_SQL.SQLDS.Tables(0).Rows(0).Item("Id")), CInt(_SQL.SQLDS.Tables(0).Rows(0).Item("status")))
        Else
            Return (0, 0)
        End If
    End Function
    Public Function CheckIfHasMorningLateRequest(_EmpID As Integer, _DocDate As Date, _StartTime As String) As Integer
        Dim _SQLString As String = "Select Id from [AttEmployeeLeaves] where [status]=1 AND [EmployeeId]=" & _EmpID & " and [Date_]='" & Format(_DocDate, "yyyy-MM-dd") & "' And From_='" & _StartTime & "'"
        Dim _SQL As New SQLControl
        _SQL.SqlTrueTimeRunQuery(_SQLString)
        If _SQL.SQLDS.Tables(0).Rows.Count > 0 Then
            Return CInt(_SQL.SQLDS.Tables(0).Rows(0).Item("Id"))
        Else
            Return 0
        End If
    End Function
    Public Sub DeleteRelatedTransForSalaryDocument(_ID As Integer)
        If _ID <> 0 Then
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = "  DELETE FROM AttRawatebArchive WHERE ID = " & _ID & ";"
            sqlString += " DELETE FROM [AttEmployeeAdditions] WHERE [SalaryDocumentID]=" & _ID & ";"
            sqlString += " DELETE FROM [AttEmployeePayments]  WHERE [SalaryDocumentID]=" & _ID & ";"
            sqlString += " DELETE From SavingsFund Where SalaryDocumentID =" & _ID & ";"
            sqlString += " DELETE From [Vocations] Where [VocationSource]='leaves' And SalaryDocumentID =" & _ID & ";"
            sql.SqlTrueTimeRunQuery(sqlString)
        End If
    End Sub
    Public Function GetSalaryDocumentIDAndStatusIfExist(employeeId As Integer, fromDate As Date, toDate As Date) As (DocID As Integer, DocStatus As Integer)
        Dim sql As New SQLControl
        Dim _DateFrom As String = Format(CDate(fromDate), "yyyy-MM-dd")
        Dim _DateTo As String = Format(CDate(toDate), "yyyy-MM-dd")
        Dim sqlstring As String
        sqlstring = "Select ID,ArchiveStatus From [AttRawatebArchive] where EmployeeID=" & employeeId & " and ((DateFrom  between '" & _DateFrom & "'  and '" & _DateTo & "' ) or 
                              (DateTo between '" & _DateFrom & "' and '" & _DateTo & "' ))  "
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return (sql.SQLDS.Tables(0).Rows(0).Item("ID"), sql.SQLDS.Tables(0).Rows(0).Item("ArchiveStatus"))
        Else
            Return (0, 0)
        End If
    End Function
    Public Sub ReCalcSalaryDocument(SalaryDocID As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update AttRawatebArchive Set  NetSalary=SalaryMonth+BonusAmount+Transport+Additions-LeavesAmount-AbsenceAmount-Payment-IsNull(SavingsFund,0)-IsNull(IncomeTAX,0)  where ID=" & SalaryDocID
        If sql.SqlTrueTimeRunQuery(sqlString) <> True Then
            XtraMessageBox.Show(" خطأ  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Sub SwitchKeyboardLayout(twoLetterIsoName As String)
        Try
            For Each lang As InputLanguage In InputLanguage.InstalledInputLanguages
                If lang.Culture.TwoLetterISOLanguageName.Equals(twoLetterIsoName, StringComparison.OrdinalIgnoreCase) Then
                    InputLanguage.CurrentInputLanguage = lang
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Function CalculateTotalTax(ByVal taxableIncome As Decimal) As Decimal
        ' Define the tax brackets and corresponding rates
        Dim taxBrackets As Decimal() = {75000D, 150000D} ' Thresholds for the tax brackets
        Dim taxRates As Decimal() = {0.05D, 0.1D, 0.15D} ' Tax rates for each bracket

        Dim totalTax As Decimal = 0D

        ' Calculate tax for the first bracket
        If taxableIncome <= taxBrackets(0) Then
            totalTax = taxableIncome * taxRates(0)
        Else
            totalTax = taxBrackets(0) * taxRates(0)
        End If

        ' Calculate tax for the second bracket
        If taxableIncome > taxBrackets(0) AndAlso taxableIncome <= taxBrackets(1) Then
            totalTax += (taxableIncome - taxBrackets(0)) * taxRates(1)
        ElseIf taxableIncome > taxBrackets(1) Then
            totalTax += (taxBrackets(1) - taxBrackets(0)) * taxRates(1)
        End If

        ' Calculate tax for the third bracket
        If taxableIncome > taxBrackets(1) Then
            totalTax += (taxableIncome - taxBrackets(1)) * taxRates(2)
        End If

        Return totalTax
    End Function
    Public Sub CustomDrawEmptyForeground(ByVal gridControl As GridControl, ByVal gridView As GridView)



        ' Initialize variables used to paint View's empty space in a custom manner
        Dim noMatchesFoundTextFont As New Font("Tahoma", 10)
        Dim trySearchingAgainTextFont As New Font("Tahoma", 15, FontStyle.Underline)
        Dim trySearchingAgainTextFontBold As New Font(trySearchingAgainTextFont, FontStyle.Underline Or FontStyle.Bold)
        Dim linkBrush As New SolidBrush(DevExpress.Skins.EditorsSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel).Colors("HyperLinkTextColor"))
        Dim noMatchesFoundText As String = "   "
        Dim trySearchingAgainText As String = " لا يوجد بيانات "
        Dim noMatchesFoundBounds As Rectangle = Rectangle.Empty
        Dim trySearchingAgainBounds As Rectangle = Rectangle.Empty
        Dim trySearchingAgainBoundsContainCursor As Boolean = False
        Dim offset As Integer = 10

        'Handle this event to paint View's empty space in a custom manner
        AddHandler gridView.CustomDrawEmptyForeground, Sub(s, e)
                                                           e.DefaultDraw()
                                                           e.Appearance.Options.UseFont = True
                                                           e.Appearance.Font = noMatchesFoundTextFont
                                                           'Draw the noMatchesFoundText string
                                                           Dim size As Size = e.Appearance.CalcTextSize(e.Cache, noMatchesFoundText, e.Bounds.Width).ToSize()
                                                           Dim x As Integer = (e.Bounds.Width - size.Width) \ 2
                                                           Dim y As Integer = e.Bounds.Y + offset
                                                           noMatchesFoundBounds = New Rectangle(New Point(x, y), size)
                                                           e.Appearance.DrawString(e.Cache, noMatchesFoundText, noMatchesFoundBounds)
                                                           'Draw the trySearchingAgain link
                                                           e.Appearance.Font = If(trySearchingAgainBoundsContainCursor, trySearchingAgainTextFontBold, trySearchingAgainTextFont)
                                                           size = e.Appearance.CalcTextSize(e.Cache, trySearchingAgainText, e.Bounds.Width).ToSize()
                                                           x = noMatchesFoundBounds.X - (size.Width - noMatchesFoundBounds.Width) \ 2
                                                           y = noMatchesFoundBounds.Bottom + offset
                                                           size.Width += offset
                                                           trySearchingAgainBounds = New Rectangle(New Point(x, y), size)
                                                           e.Appearance.DrawString(e.Cache, trySearchingAgainText, trySearchingAgainBounds, linkBrush)
                                                       End Sub

        'AddHandler gridView.MouseMove, Sub(s, e)
        '                                   trySearchingAgainBoundsContainCursor = trySearchingAgainBounds.Contains(e.Location)
        '                                   gridControl.Cursor = If(trySearchingAgainBoundsContainCursor, Cursors.Hand, Cursors.Default)
        '                                   gridView.InvalidateRect(trySearchingAgainBounds)
        '                               End Sub

        'AddHandler gridView.MouseDown, Sub(s, e)
        '                                   If trySearchingAgainBoundsContainCursor Then
        '                                       searchName = XtraInputBox.Show(String.Format("Enter {0}", "Name"), String.Format("Enter {0} dialog", "Name"), searchName)
        '                                       gridView.ActiveFilterCriteria = New DevExpress.Data.Filtering.BinaryOperator("Category_Name", searchName)
        '                                   End If
        '                               End Sub
    End Sub

    Public Class SQLControl
        Public AccessCMD As OleDbCommand
        Public AccessDA As OleDbDataAdapter


        Public SqlCmd As SqlCommand
        Public SQLDA As SqlDataAdapter
        Public SQLDS As DataSet
        Public SqlLocalTrueTime As New SqlConnection With {.connectionString = LocalAttCHECKINOUTConnectionString}
        Public SqlTrueAccounting As New SqlConnection With {.connectionString = My.Settings.TrueTimeConnectionString}

        Public SqlTrueTime As New SqlConnection With {.connectionString = My.Settings.TrueTimeConnectionString}

        Private Sub CreateLog(_StringError As String, _query As String)
            Dim filePath As String = "ErrorsLog.txt"
            If Not File.Exists(filePath) Then
                Dim fileStream As FileStream = File.Create(filePath)
                fileStream.Close()
            End If
            Dim sw As StreamWriter = New StreamWriter(filePath, True)
            sw.WriteLine(" Error: " & " @" & Format(Now(), "yyyy-MM-dd HH:mm:ss"))
            sw.WriteLine("----------")
            sw.WriteLine(_query)
            sw.WriteLine("----------")
            sw.WriteLine(_StringError)
            sw.WriteLine("----------")
            sw.WriteLine("----------------------------------------------")
            sw.Close()
        End Sub

        Public Function SqlLocalTrueTimeRunQuery(query As String) As Boolean
            Try
                SqlLocalTrueTime.Open()
                SqlCmd = New SqlCommand(query, SqlLocalTrueTime)
                SQLDA = New SqlDataAdapter(SqlCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SqlLocalTrueTime.Close()
                Return True
            Catch ex As Exception
                Return False
                If SqlLocalTrueTime.State = ConnectionState.Open Then
                    SqlLocalTrueTime.Close()
                End If
            End Try
        End Function
        Public Function SqlOrpak(PosID As Integer) As SqlConnection
            Dim SqlOrpak2 As New SqlConnection With {.connectionString = GetOrpakConnectionString(PosID)._Cstring}
            Return SqlOrpak2
        End Function
        Public Function SqlOrpakRunQuery(query As String, _PosNo As Integer) As Boolean
            Try
                SqlOrpak(_PosNo).Open()
                SqlCmd = New SqlCommand(query, SqlOrpak(_PosNo))
                SqlCmd.CommandTimeout = 240
                SQLDA = New SqlDataAdapter(SqlCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SqlOrpak(_PosNo).Close()
                Return True
            Catch ex As Exception
                Return False
                If SqlOrpak(_PosNo).State = ConnectionState.Open Then
                    SqlOrpak(_PosNo).Close()
                End If
            End Try
        End Function
        Public Function SqlPosRunQuery(query As String, _PosNo As Integer) As Boolean
            Try
                SqlOrpak(_PosNo).Open()
                SqlCmd = New SqlCommand(query, SqlOrpak(_PosNo))
                SqlCmd.CommandTimeout = 240
                SQLDA = New SqlDataAdapter(SqlCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SqlOrpak(_PosNo).Close()
                Return True
            Catch ex As Exception
                Return False
                If SqlOrpak(_PosNo).State = ConnectionState.Open Then
                    SqlOrpak(_PosNo).Close()
                End If
            End Try
        End Function
        Public Function SqlTrueAccountingRunQuery(query As String) As Boolean
            Try

                SqlTrueAccounting.Open()
                'query = query.Replace("'", "''")
                SqlCmd = New SqlCommand(query, SqlTrueAccounting)
                SqlCmd.CommandTimeout = 60
                SQLDA = New SqlDataAdapter(SqlCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SqlTrueAccounting.Close()
                'CreateLog(query)
                Return True
            Catch ex As Exception
                MsgBox(ex.ToString)
                Clipboard.SetText(query)
                If SqlTrueAccounting.State = ConnectionState.Open Then
                    SqlTrueAccounting.Close()
                End If
                CreateLog(ex.ToString, query)
                Return False
                'h
            End Try
        End Function

        Public Async Function SqlTrueAccountingRunQueryAsync(query As String) As Task(Of Boolean)
            Return Await Task.Run(Function()
                                      Return SqlTrueAccountingRunQuery(query)
                                  End Function)
        End Function
        Public Function ExecuteSqlQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As (Success As Boolean, RowCount As Integer, ErrorMessage As String)
            ' First check if connection string is valid
            If String.IsNullOrEmpty(My.Settings.TrueTimeConnectionString) Then
                Return (False, 0, "Connection string is empty or invalid")
            End If

            Using connection As New SqlConnection(My.Settings.TrueTimeConnectionString)
                Try
                    ' Attempt to verify connection before executing query
                    Try
                        ' Test connection with a short timeout
                        connection.ConnectionString += ";Connection Timeout=3"
                        connection.Open()
                        connection.Close()
                    Catch cnEx As SqlException
                        ' Log specific connection error and return early
                        CreateLog(cnEx.ToString, "Connection test failed: " + query)
                        Return (False, 0, "Database connection failed: " + cnEx.Message)
                    End Try

                    ' Reset connection string to original (without the short timeout)
                    connection.ConnectionString = My.Settings.TrueTimeConnectionString

                    Using command As New SqlCommand(query, connection)
                        ' Add parameters safely
                        If parameters IsNot Nothing Then
                            For Each param In parameters
                                command.Parameters.AddWithValue(param.Key, param.Value)
                            Next
                        End If

                        connection.Open()
                        SQLDA = New SqlDataAdapter(command)
                        SQLDS = New DataSet
                        Dim rowCount = SQLDA.Fill(SQLDS)
                        Return (True, rowCount, "")
                    End Using
                Catch ex As Exception
                    CreateLog(ex.ToString, query)

                    ' More specific error message for connection issues
                    If TypeOf ex Is SqlException Then
                        Dim sqlEx As SqlException = DirectCast(ex, SqlException)
                        If sqlEx.Number = -1 OrElse sqlEx.Number = 53 OrElse sqlEx.Number = 40 Then
                            Return (False, 0, "Cannot connect to database server. Please check your network connection.")
                        End If
                    End If

                    Return (False, 0, ex.Message)
                End Try
            End Using
        End Function

        Public Function SqlTrueAccountingRunQueryWithResultCount(query As String) As Integer
            Dim rows_Affected As Integer
            Try
                Using SqlTrueAccounting
                    Dim command As SqlCommand = New SqlCommand(query, SqlTrueAccounting)
                    command.Connection.Open()
                    rows_Affected = command.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                rows_Affected = -1
            End Try
            Return rows_Affected
        End Function

        Public Function SqlTrueTimeRunQuery(query As String) As Boolean
            Try
                SqlTrueTime.Open()
                'query = query.Replace("'", "''")
                SqlCmd = New SqlCommand(query, SqlTrueTime)
                SQLDA = New SqlDataAdapter(SqlCmd)
                SQLDS = New DataSet
                SQLDA.Fill(SQLDS)
                SqlTrueTime.Close()
                Return True
            Catch ex As Exception
                ' MsgBox(ex.ToString)
                Return False
                If SqlTrueTime.State = ConnectionState.Open Then
                    SqlTrueTime.Close()
                End If
                CreateLog(ex.ToString, query)
            End Try
        End Function
        Public Sub TracingTest(ByVal fileName As String)
            My.Application.Log.WriteEntry(
        "Entering TracingTest with argument " &
        fileName & ".")
            ' Code to trace goes here.
            My.Application.Log.WriteEntry(
        "Exiting TracingTest with argument " &
        fileName & ".")
        End Sub


    End Class
    Public Class WhatsAppStatus
        Public Property WhatsAppStatus As String
    End Class
End Module


Public Module SerialStatus
    Public Available As String = "<backcolor=@Success><b><color=255, 255, 255>  متوفر  </b>"
    Public Cancelled As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  ملغي  </b>"
    Public Sold As String = "<backcolor=@Critical><b><color=255, 255, 255>  مباع  </b>"
End Module
Public Module DocumentsStatus
    Public Audited As String = "<backcolor=@WarningFill><b><color=255, 255, 255>  مدقق  </b>"
    Public Auto As String = "<backcolor=@DisabledText><b><color=255, 255, 255>  الي  </b>"
    Public Cancelled As String = "<backcolor=0,0,0><b><color=255, 255, 255>  ملغي  </b>"
    Public Posted As String = "<backcolor=@Critical><b><color=255, 255, 255>  مرحل  </b>"
    Public Saved As String = "<backcolor=@Success><b><color=255, 255, 255>  محفوظ  </b>"
End Module
Public Module PaidStatus
    Public Paid As String = "<backcolor=@Success><b><color=255, 255, 255>  مسدد   </b>"
    Public PaidPartial As String = "<backcolor=@WarningFill><b><color=255, 255, 255>  مسدد جزئي  </b>"
    Public Unpaid As String = "<backcolor=@Critical><b><color=255, 255, 255>  غير مسدد  </b>"
End Module
Public Module OrderStatus
    Public Other As String = "<backcolor=@Success><b><color=255, 255, 255>  محفوظ   </b>"
    Public Saved As String = "<backcolor=@Success><b><color=255, 255, 255>  محفوظ   </b>"
    Public Voucherd As String = "<backcolor=@Critical><b><color=255, 255, 255>  مفوترة  </b>"
    Public VoucherdPartial As String = "<backcolor=@WarningFill><b><color=255, 255, 255>  قيد التجهيز  </b>"
End Module
Public Module UserPermission

    Public UserId As Integer
    Public UserType As String
    Public UserName As String
    Public UserAccessType As Integer
    Public UserGroupID As Integer
    Public FeatureAccess
End Module
Public Class FeatureAccess
    Public IsAllow As Boolean
    Public CanEdit As Boolean
    Public CanDelete As Boolean
    Public CanAdd As Boolean
End Class
Public Module GlobalVariables
    Public _AcceptFromImportSreen As Boolean
    Public _AccessType As String
    Public _Accounting_PrintAccountStatmentByEnglish = False
    Public _AlertWhenItemQuantityLessThanBalanceInVouchers As Boolean
    Public _AllowUseWhatsApp As Boolean
    Public _AppSettingsTable As New DataTable
    Public _AttAllowEditAttTrans As Boolean
    Public _AttConnectionType As String
    Public _AttDailyAdjustment As Boolean = False
    Public _AttNoteRequiredforAttTrans As Boolean = False
    Public _BatchIDTemp As Integer = 0
    Public _BatchNoTemp As String = String.Empty
    Public _ChecksTable As New DataTable
    Public _CostCenterRequired As Boolean
    Public _DefaultBaseCashAccount As String
    Public _EndDate As DateTime = Today.AddYears(10)
    Public _HasOrpak As Boolean = False
    Public _ItemBarcodeGlobal As String
    Public _ItemColorIDGlobal As String
    Public _ItemMeasureIDGlobal As String
    Public _ItemNameGlobal As String
    Public _ItemNoGlobal As Integer
    Public _ItemsTable As New DataTable
    Public _ItemUnitIDGlobal As Integer
    Public _OrderedQuantity As Decimal
    Public _OrderTable As New DataTable
    Public _OrpakConnectionString As String
    Public _PayCardName As String
    Public _PosAllowChangeItemPrice As Boolean
    Public _PosMaxDiscount As Decimal
    Public _PosPrintReferanceBalance As Boolean
    Public _PosUseScales As Boolean = True
    Public _POSuseShelves As Boolean
    Public _PosUseVoucherCounterInsteadVoucherNo As Boolean = True
    Public _PublicDocumentTags As String
    Public _ReferanceNameGlobal As String
    Public _ReferanceNoGlobal As Integer
    Public _ReferancesMessage As String
    Public _SendSmsFromDocuments As Boolean = False
    Public _Shalash As Boolean = False
    Public _ShiftID As Integer
    Public _ShowActionMenueAfterSaveDocuments As Boolean = True
    Public _ShowBalanceColumnInVoucher As Boolean
    Public _ShowColNoteInMoneyTransDoc As Boolean
    Public _ShowColNoteInStockMoveDoc As Boolean
    Public _ShowCostCenter As Boolean
    Public _ShowItemCostInItemScreenUser As Boolean
    Public _ShowItemNo2 As Boolean
    Public _ShowLastPurchasePriceColumnInVoucher As Boolean
    Public _ShowRowMaterialinVouchers As Boolean = False
    Public _ShowShelvesColumnInVoucher As Boolean
    Public _ShowWorkLeavesData As Boolean = False
    Public _SMSMessagesTempTable As New DataTable
    Public _SystemLanguage As String
    Public _TempItemName As String
    Public _TempItemNo As String
    Public _TempWeight As Decimal
    Public _TotalRequiredHoursInMonthlyAdjustment As String
    Public _TotalWorkingHoursInMonthlyAdjustment As String
    Public _UseBatch As Boolean
    Public _UseColorsAndMeasuresInItems As Boolean = False
    Public _UserAccessType As Integer
    Public _UseSalesMan As Boolean
    Public _UseSerials As Boolean
    Public _VersionMode As String
    Public _VocationTypeInQuickMode As Integer
    Public _WareHouseUseShelf As Boolean
    Public CurrDevice As String
    Public CurrUser As String = "0"
    Public CurrUserForTasks As String
    Public CustomerActiveStatus As Boolean
    Public CustomerLicenceDateValid As Boolean
    Public EmployeeName As String
    Public LocalAttCHECKINOUTConnectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LocalAttCHECKINOUT.mdf;Integrated Security=True"
    Public LocalDeviceKey As String
    Public LocalHasValidLocalLicense As Boolean
    Public LocalRegCode As String
    Public LocalSoftwareID As String
    Public MyGlobalString As String
    Public NewUsers As Integer
    Public Online As Boolean
    Public Production_DirectProduceInVoucherDocument As Boolean
    Public ScaleComNO As Integer
    Public Accounting_UseSubAccounts As Boolean
    Public _TempItemNos As List(Of Integer)
    Public _ItemBarcodesGlobal As List(Of String)
    Public _ItemColorIDsGlobal As List(Of String)
    Public _ItemMeasureIDsGlobal As List(Of String)
    Public _HRSystemIsConnectedWithAccountingSystem As Boolean = False
    Public GetCRMServices As Boolean = True
    Public ReadOnly connectionString As String = My.Settings.TrueTimeConnectionString
    Public _UserType As String
    Public ttsSystemsAPI As String = "https://ttssystemsapi.truetime.ps/api/"
    Public HasPrintBarcodeService As Boolean = False
    Public HasShelfsService As Boolean = False
    Public GetSystemPermissions As Boolean = False
    Public HasPosSystem As Boolean = False
    Public VATDefaultPercentage As Decimal = 0
    Public UseVAT As Boolean = False
    Public UseThreeLevelsOfGroupsItem As Boolean = True
End Module
Public Module EmployeeAccess
    Public _ShowItemCost As Boolean
End Module
Public Class GreenApiResponse
    Public Property IdMessage As String
    Public Property Sent As Boolean
    Public Property Message As String
End Class
Public Class FormControls
    Public Property MainButton As Object
    Public Property ButtonAdd As Object
    Public Property ButtonEdit As Object
    Public Property ButtonDelete As Object
    Public Property ButtonAllow As Object
End Class


Public Module FormControlMapping
    Private _formControlMap As Dictionary(Of Integer, FormControls)

    Public ReadOnly Property FormControlMap As Dictionary(Of Integer, FormControls)
        Get
            If _formControlMap Is Nothing Then
                Debug.WriteLine("🧩 Initializing FormControlMap (lazy load)...")
                _formControlMap = New Dictionary(Of Integer, FormControls) From {
                    {1, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup1,
                        .ButtonAllow = My.Forms.Main.BarButtonItemEmloyeesFile,
                        .ButtonEdit = My.Forms.Main.BarButtonEmployeesEdit
                    }},
                    {3, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAdd = My.Forms.Main.BarButtonItem55
                    }},
                    {4, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarPlanRequiredHours,
                        .ButtonEdit = My.Forms.Main.BarButtonItem2
                    }},
                    {6, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItemShiftReport
                    }},
                    {7, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupIssueAttReport,
                        .ButtonAllow = My.Forms.Main.BarButtonItem299,
                        .ButtonAdd = My.Forms.Main.BarButtonItem300
                    }},
                    {9, New FormControls With {
                        .ButtonAllow = My.Forms.Lists2.NavigationPage1
                    }},
                    {11, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup18
                    }},
                    {13, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup1,
                        .ButtonAllow = My.Forms.Main.BarSubItem16
                    }},
                    {31, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem298
                    }},
                    {32, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem109
                    }},
                    {34, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem1
                    }},
                    {35, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup6,
                        .ButtonAllow = My.Forms.Main.BarButtonItem311
                    }},
                    {36, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup6,
                        .ButtonAllow = My.Forms.Main.BarButtonItemRCCIInsentives
                    }},
                    {37, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup6,
                        .ButtonAllow = My.Forms.Main.BarButtonItem245
                    }},
                    {38, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup6,
                        .ButtonAllow = My.Forms.Main.BarButtonItem84
                    }},
                    {39, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup6,
                        .ButtonAllow = My.Forms.Main.BarButtonItem70
                    }},
                    {40, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup27,
                        .ButtonAllow = My.Forms.Main.BarButtonItem284
                    }},
                    {41, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup27,
                        .ButtonAllow = My.Forms.Main.BarSubItem17
                    }},
                    {42, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup27,
                        .ButtonAllow = My.Forms.Main.BarButtonItem78
                    }},
                    {43, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup26,
                        .ButtonAllow = My.Forms.Main.BarButtonItem304
                    }},
                    {44, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup26,
                        .ButtonAllow = My.Forms.Main.BarButtonItem64,
                        .ButtonAdd = My.Forms.Main.BarButtonItem63
                    }},
                    {45, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup26,
                        .ButtonAllow = My.Forms.Main.BarButtonItem59,
                        .ButtonAdd = My.Forms.Main.BarButtonItem56
                    }},
                    {47, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem296
                    }},
                    {48, New FormControls With {
                        .ButtonAllow = My.Forms.Main.BarButtonItem267
                    }},
                    {49, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupAttendanceReports
                    }},
                    {50, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarButtonItem100
                    }},
                    {51, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup27,
                        .ButtonAllow = My.Forms.Main.BarButtonItem60
                    }},'ملفات
                    {53, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarButtonItem89
                    }},
                    {55, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarButtonItem75
                    }},
                    {56, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonItem238
                    }},
                    {60, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupReferances,
                        .ButtonAllow = My.Forms.Main.BarButtonItem292
                    }},
                    {61, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupReferances,
                        .ButtonAllow = My.Forms.Main.BarButtonItem293
                    }},
                    {62, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupReferances,
                        .ButtonAllow = My.Forms.Main.BarButtonItem291
                    }},
                    {63, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.ItemsBarcodes
                    }},
                    {64, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonPrintBarcodes
                    }},
                    {65, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonPrintBarcodesSettings
                    }},
                    {66, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonItemChangePrice
                    }},
                    {67, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonItems
                    }},
                    {68, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupItems,
                        .ButtonAllow = My.Forms.Main.BarButtonItemQuickAddNewItem
                    }},
                    {73, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarButtonItem203
                    }},
                    {74, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarButtonItem102
                    }},'سندات
                    {75, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup5,
                        .ButtonAllow = My.Forms.Main.BarSubItem13
                    }},
                    {76, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupCheuqs,
                        .ButtonAllow = My.Forms.Main.BarSubItem1
                    }},
                    {77, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupCheuqs,
                        .ButtonAllow = My.Forms.Main.BarSubItem2
                    }},
                    {78, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialAccountsReport,
                        .ButtonAllow = My.Forms.Main.BarButtonItem260
                    }},
                    {79, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupJournal,
                        .ButtonAllow = My.Forms.Main.BarButtonItem131
                    }},
                    {80, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupJournal,
                        .ButtonAllow = My.Forms.Main.BarButtonItem282
                    }},
                    {81, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroupJournal,
                        .ButtonAllow = My.Forms.Main.BarButtonItem130
                    }},
                    {83, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup43,
                        .ButtonAllow = My.Forms.Main.BarButtonItem20
                    }},
                    {84, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup43,
                        .ButtonAllow = My.Forms.Main.BarButtonItem180
                    }},
                    {85, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup43,
                        .ButtonAllow = My.Forms.Main.BarButtonItem185
                    }},
                    {86, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup43,
                        .ButtonAllow = My.Forms.Main.BarButtonItem90
                    }},
                    {87, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup43,
                        .ButtonAllow = My.Forms.Main.BarButtonPurchases
                    }},
                    {88, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup44,
                        .ButtonAllow = My.Forms.Main.BarButtonItem19
                    }},
                    {89, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup44,
                        .ButtonAllow = My.Forms.Main.BarButtonItem178
                    }},
                    {90, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup44,
                        .ButtonAllow = My.Forms.Main.BarButtonItem184
                    }},
                    {91, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup44,
                        .ButtonAllow = My.Forms.Main.BarButtonItem165
                    }},
                    {92, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup44,
                        .ButtonAllow = My.Forms.Main.BarButtonSales
                    }},
                    {93, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup46,
                        .ButtonAllow = My.Forms.Main.BarButtonItem261
                    }},
                    {94, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialItemsReport,
                        .ButtonAllow = My.Forms.Main.BarSubItem12
                    }},
                    {95, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup46,
                        .ButtonAllow = My.Forms.Main.BarInternalOrdersLogsReports
                    }},
                    {96, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup46,
                        .ButtonAllow = My.Forms.Main.BarSubItemJardMenue
                    }},
                    {97, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageGroup46,
                        .ButtonAllow = My.Forms.Main.BarSubItemJardMenue
                    }},
                    {98, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialItemsReport,
                        .ButtonAllow = My.Forms.Main.BarSubItem12
                    }},
                    {100, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialItemsReport,
                        .ButtonAllow = My.Forms.Main.BarSubItem11
                    }},
                    {101, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialItemsReport,
                        .ButtonAllow = My.Forms.Main.BarButtonItem197
                    }},
                    {102, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialAccountsReport,
                        .ButtonAllow = My.Forms.Main.BarButtonItem82
                    }},
                    {103, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialAccountsReport,
                        .ButtonAllow = My.Forms.Main.BarButtonItemAccountStatment
                    }},
                    {105, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialReferancesReports,
                        .ButtonAllow = My.Forms.Main.BarSubItem14
                    }},
                    {106, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialReferancesReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem122
                    }},
                    {107, New FormControls With {
                        .MainButton = My.Forms.Main.FinancialReferancesReports,
                        .ButtonAllow = My.Forms.Main.BarButtonItem128
                    }},
                    {108, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageDashBoareds,
                        .ButtonAllow = My.Forms.Main.BarButtonItem182
                    }},
                    {109, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageDashBoareds,
                        .ButtonAllow = My.Forms.Main.BarButtonItem3
                    }},
                    {110, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageDashBoareds,
                        .ButtonAllow = My.Forms.Main.BarButtonItem181
                    }},
                    {111, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageFinancialStatment,
                        .ButtonAllow = My.Forms.Main.BarButtonItem273
                    }},
                    {112, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageFinancialStatment,
                        .ButtonAllow = My.Forms.Main.BarButtonItem104
                    }},
                    {113, New FormControls With {
                        .MainButton = My.Forms.Main.RibbonPageFinancialStatment,
                        .ButtonAllow = My.Forms.Main.BarButtonItem103
                    }}
                }
            End If
            Return _formControlMap
        End Get
    End Property
End Module





