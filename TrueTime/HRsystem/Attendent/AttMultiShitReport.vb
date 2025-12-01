Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class AttMultiShitReport
    Dim _UseLocalDataBaseForReport As Boolean = False
    Dim _AttShowAllEmployeesInAttReports As Boolean
    Dim _EmployeesCount As Integer = 0
    Dim _CurrentEmployeeHandle As Integer = 0
    Dim PlaneID As Integer
    Dim AddBonusToSalary As Boolean = True
    Dim _DateOfStart As String = "1900-01-01"
    Dim _DateOfEnd As String = "2100-01-01"
    Dim ProcessType As String = String.Empty
    Dim SalaryAccountNo As String = String.Empty
    Dim BonusOnDayOff As Decimal = 1
    Dim RequiredDailyHoures As TimeSpan = TimeSpan.Zero
    Dim _SalaryPerHourFromEmployeeData As Decimal = 0
    Dim _AdditionsFound As Boolean
    Dim _PaymentFound As Boolean
    Dim _VocationsFound As Boolean
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim SqlString As String
        Try
            SqlString = " select SettingValue From Settings where SettingName ='UseLocalDataBaseForReport'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _UseLocalDataBaseForReport = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _UseLocalDataBaseForReport = False
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='AttShowAllEmployeesInAttReports'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _AttShowAllEmployeesInAttReports = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _AttShowAllEmployeesInAttReports = False
            XtraMessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub UpdateData()
        My.Forms.Main.ItemElapseTime.Caption = "0"
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        start_time = Now

        GridControl1.DataSource = String.Empty
        GetSettings()
        Try

            '  SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            ' SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
            Dim EmployeesTable As DataTable
            Dim DataTable As New DataTable
            Dim SQLString As String
            Dim EmpIDCombo As String = SearchLookUpEdit1.EditValue

            Dim _EmpID As Integer
            If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
                _EmpID = SearchLookUpEdit1.EditValue
            Else
                _EmpID = -1
            End If
            If _UseLocalDataBaseForReport = True Then
                If ToLocalAttTrans(DateEdit1.DateTime, DateEdit2.DateTime, _EmpID) = 0 Then
                    GoTo HH
                End If
            End If

            SQLString = "Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],Salary,DailyTransport ,FactorLate,BonusPerHour,
                                 SalaryAccountNo,RequiredDailyHoures,[SalaryPerHour],SubtractionLeavesAndLates,AddBonusToSalary,
                                 MaxLeavesHoures,ProcessType,BonusOnDayOff,DateOfStart,DateOfEnd,
                                 IsNull(CalcBonusAfterMinitues,0) as CalcBonusAfterMinitues,IsNull(BonusPerHourAferPeriod1,1) as BonusPerHourAferPeriod1
                         From EmployeesData"
            If _AttShowAllEmployeesInAttReports = False Then
                SQLString += " Where (ProcessType <>'2' or ProcessType is null)   "
            Else
                SQLString += " Where 1=1   "
            End If


            '_AttShowAllEmployeesInAttReports
            If CheckEditCheckActive.Checked = True Then SQLString += "and EmployeesData.Active = 1  "
            If CStr(SearchLookUpEdit1.Text) IsNot Nothing And CStr(SearchLookUpEdit1.Text) <> String.Empty Then
                'colEmployeeName.Visible = False
                CollEmployeeName.Visible = False
                SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
            Else
                'colEmployeeName.Visible = True
                CollEmployeeName.Visible = True
            End If
            If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
            If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
            If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"

            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SQLString)

            If sql.SQLDS.Tables(0).Rows.Count = 0 Then

                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBox("لا يوجد حركات")
                Else
                    MsgBox("No Data")
                End If

                ' SplashScreenManager.CloseForm(False)
                Exit Sub
            End If

            EmployeesTable = sql.SQLDS.Tables(0)

            _EmployeesCount = EmployeesTable.Rows.Count
            For j As Integer = 0 To EmployeesTable.Rows.Count - 1
                _CurrentEmployeeHandle = j + 1
                If Not IsDBNull(EmployeesTable.Rows(j).Item("EmpID")) Then
                    Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")
                    If EmployeesTable.Rows(j).Item("AttPlane") Is Nothing Or IsDBNull(EmployeesTable.Rows(j).Item("AttPlane")) Then PlaneID = 0 Else PlaneID = EmployeesTable.Rows(j).Item("AttPlane")
                    EmployeeName = EmployeesTable.Rows(j).Item("EmployeeName")

                    If CheckShowEmployeeIfNoTrans.Checked = True Then
                        Dim StringCout As String
                        Dim SqlLocal As New SQLControl
                        StringCout = " Select Count(ID) as TransCount from AttCHECKINOUT where USERID='" & EmpID & "' and
                               CHECKTIME between '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "' and '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "'"
                        If _UseLocalDataBaseForReport = True Then
                            SqlLocal.SqlLocalTrueTimeRunQuery(StringCout)
                        Else
                            SqlLocal.SqlTrueTimeRunQuery(StringCout)
                        End If
                        If CInt(SqlLocal.SQLDS.Tables(0).Rows(0).Item("TransCount")) = 0 Then Continue For
                    End If

                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("Salary")) Then
                    '    Salary = Format(CDec(EmployeesTable.Rows(j).Item("Salary")), "0.00")
                    'Else
                    '    Salary = 0
                    'End If



                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("DailyTransport")) Then DailyTransport = Format(CDec(EmployeesTable.Rows(j).Item("DailyTransport")), "0.00")
                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("FactorLate")) Then FactorLate = Format(CDec(EmployeesTable.Rows(j).Item("FactorLate")), "0.00")
                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHour")) Then BonusPerHour = Format(CDec(EmployeesTable.Rows(j).Item("BonusPerHour")), "0.00")
                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("CalcBonusAfterMinitues")) Then _CalcBonusAfterMinitues = Format(CDec(EmployeesTable.Rows(j).Item("CalcBonusAfterMinitues")), "0.00")
                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHourAferPeriod1")) Then _BonusPerHourAferPeriod1 = Format(CDec(EmployeesTable.Rows(j).Item("BonusPerHourAferPeriod1")), "0.00")
                    'If Not IsDBNull(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates")) Then SubtractionLeavesAndLates = CBool(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates"))

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("AddBonusToSalary")) Then AddBonusToSalary = CBool(EmployeesTable.Rows(j).Item("AddBonusToSalary"))



                    If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryAccountNo")) Then SalaryAccountNo = EmployeesTable.Rows(j).Item("SalaryAccountNo")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("ProcessType")) Then ProcessType = EmployeesTable.Rows(j).Item("ProcessType")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusOnDayOff")) Then BonusOnDayOff = EmployeesTable.Rows(j).Item("BonusOnDayOff")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfStart")) Then _DateOfStart = Format(CDate(EmployeesTable.Rows(j).Item("DateOfStart")), "yyyy-MM-dd")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfEnd")) Then _DateOfEnd = Format(CDate(EmployeesTable.Rows(j).Item("DateOfEnd")), "yyyy-MM-dd")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("RequiredDailyHoures")) Then
                        RequiredDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
                    Else
                        RequiredDailyHoures = TimeSpan.Zero
                    End If

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryPerHour")) Then
                        _SalaryPerHourFromEmployeeData = CDec(EmployeesTable.Rows(j).Item("SalaryPerHour"))
                    Else
                        _SalaryPerHourFromEmployeeData = 0
                    End If

                    DataTable.Merge(QueryData(EmpID))
                End If
            Next

            GridControl1.DataSource = DataTable
HH:
            ' SplashScreenManager.CloseForm(False)
            stop_time = Now
            elapsed_time = stop_time.Subtract(start_time)
            My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
        Catch ex As Exception
            ' SplashScreenManager.CloseForm(False)
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function QueryData(EmpID As String) As DataTable
        If CheckIfAddition(EmpID, DateEdit1.DateTime, DateEdit2.DateTime) = True Then
            _AdditionsFound = True
        Else
            _AdditionsFound = False
        End If

        If CheckIfPayment(EmpID, DateEdit1.DateTime, DateEdit2.DateTime) = True Then
            _PaymentFound = True
        Else
            _PaymentFound = False
        End If

        If CheckIfVocations(EmpID, DateEdit1.DateTime, DateEdit2.DateTime) = True Then
            _VocationsFound = True
        Else
            _VocationsFound = False
        End If

        Dim _AttTrans As DataTable
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Select ID,CHECKTIME 
                                        from [AttCHECKINOUT]  
                                        where USERID='" & EmpID & "' and  
                                              CHECKTIME between '" & Format(DateEdit1.DateTime.AddDays(-1), "yyyy-MM-dd") & "' and '" & Format(DateEdit2.DateTime.AddDays(1), "yyyy-MM-dd") & "'")
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _AttTrans = sql.SQLDS.Tables(0)
        End If
        Dim ListDays As New DataTable
        ListDays.Columns.Add("TransDate", GetType(DateTime))
        ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("PlaneID", GetType(Integer))
        ListDays.Columns.Add("EmpID", GetType(String))
        ListDays.Columns.Add("EmployeeName", GetType(String))
        ListDays.Columns.Add("StartTimeA", GetType(DateTime))
        ListDays.Columns.Add("EndTimeA", GetType(DateTime))

        ListDays.Columns.Add("StartTimeB", GetType(DateTime))
        ListDays.Columns.Add("EndTimeB", GetType(DateTime))

        ListDays.Columns.Add("StartTimeC", GetType(DateTime))
        ListDays.Columns.Add("EndTimeC", GetType(DateTime))

        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim CurrDName As String = Format(CurrD, "dddd")


        Try
            'Dim SQl As New SQLControl
            Dim SqlString As String = " DECLARE @MinDate DATE = '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "',
                                                @MaxDate DATE = '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "';
                                        Select '' as TransDay , [ID], A.[AttTransDate] as TransDate, [EmpID],EmployeeName, IsNull(StartTime1,'00:00') as StartTimeA, IsNull(EndTime1,'00:00') as EndTimeA, '' as DatePartString, '' as DayOfWeek, IsNull(StartTime2,'00:00') as StartTimeB, IsNull(EndTime2,'00:00') as EndTimeB, IsNull(StartTime3,'00:00') as StartTimeC, IsNull(EndTime3,'00:00') as EndTimeC
                                        From (SELECT TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
                                             [AttTransDate] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),
                                             [AttTransDateName] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
                                             FROM sys.all_objects a CROSS JOIN sys.all_objects b ) A
                                     Left Join (SELECT P.[ID], [AttTransDate],  [EmpID],D.EmployeeName
                                                ,CONVERT(VARCHAR(5), [StartTime1], 108) as StartTime1, CONVERT(VARCHAR(5), [EndTime1], 108) as EndTime1 
                                                ,CONVERT(VARCHAR(5), [StartTime2], 108) as StartTime2, CONVERT(VARCHAR(5), [EndTime2], 108) as EndTime2
                                                ,CONVERT(VARCHAR(5), [StartTime3], 108) as StartTime3, CONVERT(VARCHAR(5), [EndTime3], 108) as EndTime3
                                     FROM [dbo].[AttPlanMultiplePeriods] P left join EmployeesData D on D.EmployeeID=P.EmpID where EmpID='" & EmpID & "') B On A.AttTransDate=b.AttTransDate where ID is not null Order by A.AttTransDate"
            SQl.SqlTrueTimeRunQuery(SqlString)
            ListDays = SQl.SQLDS.Tables(0)
            If ListDays.Rows.Count = 0 Then GoTo EEnd
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("PeriodA", GetType(TimeSpan))
        ListDays.Columns.Add("PeriodB", GetType(TimeSpan))
        ListDays.Columns.Add("PeriodC", GetType(TimeSpan))
        ListDays.Columns.Add("StartTime1", GetType(DateTime))
        ListDays.Columns.Add("StartTime2", GetType(DateTime))
        ListDays.Columns.Add("StartTime3", GetType(DateTime))
        ListDays.Columns.Add("EndTime1", GetType(DateTime))
        ListDays.Columns.Add("EndTime2", GetType(DateTime))
        ListDays.Columns.Add("EndTime3", GetType(DateTime))
        ListDays.Columns.Add("Period1", GetType(TimeSpan))
        ListDays.Columns.Add("Period2", GetType(TimeSpan))
        ListDays.Columns.Add("Period3", GetType(TimeSpan))

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        If _UseLocalDataBaseForReport = True Then
            myconnection = New SqlConnection(GlobalVariables.LocalAttCHECKINOUTConnectionString)
        Else
            myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        End If

        Dim dr As SqlDataReader
        Dim FromDateA, ToDateA, FromDateB, ToDateB, FromDateC, ToDateC As String
        Dim FactorA, FactorB, FactorC As Decimal
        FactorA = 1 : FactorB = 1 : FactorC = 1
        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1
            If IsDBNull(ListDays.Rows(i).Item("ID")) Then
                Exit For
            End If

            If GlobalVariables._SystemLanguage = "Arabic" Then
                ListDays.Rows(i).Item("TransDay") = CDate(ListDays.Rows(i).Item("TransDate")).ToString("dddd", New System.Globalization.CultureInfo("ar-AE"))
            Else
                ListDays.Rows(i).Item("TransDay") = CDate(ListDays.Rows(i).Item("TransDate")).ToString("dddd")
            End If
            Dim CurrentDateString As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd")
            If CurrentDateString = _DateOfStart Then
                ListDays.Rows(i).Item("DateOfStart") = "True"
            End If
            If CurrentDateString = _DateOfEnd Then
                ListDays.Rows(i).Item("DateOfEnd") = "True"
            End If


            ' الفترة الاولى
            If ListDays.Rows(i).Item("StartTimeA") <> "00:00" And ListDays.Rows(i).Item("EndTimeA") <> "00:00" Then
                FromDateA = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("StartTimeA")
                FromDateA = Format(Convert.ToDateTime(FromDateA), "yyyy-MM-dd HH:mm")
                ToDateA = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("EndTimeA")
                ToDateA = Format(Convert.ToDateTime(ToDateA), "yyyy-MM-dd HH:mm")
                If CDate(ToDateA) < CDate(FromDateA) Then
                    ToDateA = Format(CDate(ToDateA).AddDays(1), "yyyy-MM-dd HH:mm")
                End If
                ' احتساب الفترة المطلوبة الاولى
                If CDate(ListDays.Rows(i).Item("EndTimeA")) > CDate(ListDays.Rows(i).Item("StartTimeA")) Then
                    ListDays.Rows(i).Item("PeriodA") = CDate(ListDays.Rows(i).Item("EndTimeA")).Subtract(CDate(ListDays.Rows(i).Item("StartTimeA")))
                Else
                    ListDays.Rows(i).Item("PeriodA") = (CDate(ListDays.Rows(i).Item("EndTimeA")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTimeA")))
                End If
            Else
                FromDateA = ""
                ToDateA = ""
            End If

            ' البحث عن حركات الدخول للفترة الاولى 
            If FromDateA <> "" And ToDateA <> "" Then
                Dim SQLString2 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            Where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(FromDateA).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(FromDateA).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME  "
                mycommand = New SqlCommand(SQLString2, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("StartTime1") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If

                ' البحث عن حركات الخروج للفترة الاولى
                Dim SQLString3 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(ToDateA).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(ToDateA).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME DESC "
                mycommand = New SqlCommand(SQLString3, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("EndTime1") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If
            End If

            'احتساب دوام الفترة الاولى
            If ListDays.Rows(i).Item("StartTime1").ToString <> "" And ListDays.Rows(i).Item("EndTime1").ToString <> "" Then
                If CDate(ListDays.Rows(i).Item("EndTime1")) > CDate(ListDays.Rows(i).Item("StartTime1")) Then
                    ListDays.Rows(i).Item("Period1") = CDate(ListDays.Rows(i).Item("EndTime1")).Subtract(CDate(ListDays.Rows(i).Item("StartTime1")))
                Else
                    ListDays.Rows(i).Item("Period1") = (CDate(ListDays.Rows(i).Item("EndTime1")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTime1")))
                End If
            End If

            ' الفترة الثانية
            If ListDays.Rows(i).Item("StartTimeB") <> "00:00" And ListDays.Rows(i).Item("EndTimeB") <> "00:00" Then
                FromDateB = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("StartTimeB")
                FromDateB = Format(Convert.ToDateTime(FromDateB), "yyyy-MM-dd HH:mm")
                ToDateB = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("EndTimeB")
                ToDateB = Format(Convert.ToDateTime(ToDateB), "yyyy-MM-dd HH:mm")
                If CDate(ToDateB) < CDate(FromDateB) Then
                    ToDateB = Format(CDate(ToDateB).AddDays(1), "yyyy-MM-dd HH:mm")
                End If
                ' احتساب الفترة المطلوبة الثانية
                If CDate(ListDays.Rows(i).Item("EndTimeB")) > CDate(ListDays.Rows(i).Item("StartTimeB")) Then
                    ListDays.Rows(i).Item("PeriodB") = CDate(ListDays.Rows(i).Item("EndTimeB")).Subtract(CDate(ListDays.Rows(i).Item("StartTimeB")))
                Else
                    ListDays.Rows(i).Item("PeriodB") = (CDate(ListDays.Rows(i).Item("EndTimeB")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTimeB")))
                End If
            Else
                FromDateB = ""
                ToDateB = ""
            End If


            ' البحث عن حركات الدخول للفترة الثانية 
            If FromDateB <> "" And ToDateB <> "" Then
                Dim SQLString2 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            Where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(FromDateB).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(FromDateB).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME "
                mycommand = New SqlCommand(SQLString2, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("StartTime2") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If

                ' البحث عن حركات الخروج للفترة الثانية
                Dim SQLString3 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(ToDateB).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(ToDateB).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME DESC"
                mycommand = New SqlCommand(SQLString3, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("EndTime2") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If
            End If
            'احتساب دوام الفترة الثانية
            If ListDays.Rows(i).Item("StartTime2").ToString <> "" And ListDays.Rows(i).Item("EndTime2").ToString <> "" Then
                If CDate(ListDays.Rows(i).Item("EndTime2")) > CDate(ListDays.Rows(i).Item("StartTime2")) Then
                    ListDays.Rows(i).Item("Period2") = CDate(ListDays.Rows(i).Item("EndTime2")).Subtract(CDate(ListDays.Rows(i).Item("StartTime2")))
                Else
                    ListDays.Rows(i).Item("Period2") = (CDate(ListDays.Rows(i).Item("EndTime2")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTime2")))
                End If
            End If

            'الفترة الثالثة
            If ListDays.Rows(i).Item("StartTimeC") <> "00:00" And ListDays.Rows(i).Item("EndTimeC") <> "00:00" Then
                FromDateC = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("StartTimeC")
                FromDateC = Format(Convert.ToDateTime(FromDateC), "yyyy-MM-dd HH:mm")
                ToDateC = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("EndTimeC")
                ToDateC = Format(Convert.ToDateTime(ToDateC), "yyyy-MM-dd HH:mm")
                If CDate(ToDateC) < CDate(FromDateC) Then
                    ToDateC = Format(CDate(ToDateC).AddDays(1), "yyyy-MM-dd HH:mm")
                End If
                ' احتساب الفترة المطلوبة الثانية
                If CDate(ListDays.Rows(i).Item("EndTimeC")) > CDate(ListDays.Rows(i).Item("StartTimeC")) Then
                    ListDays.Rows(i).Item("PeriodC") = CDate(ListDays.Rows(i).Item("EndTimeC")).Subtract(CDate(ListDays.Rows(i).Item("StartTimeC")))
                Else
                    ListDays.Rows(i).Item("PeriodC") = (CDate(ListDays.Rows(i).Item("EndTimeC")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTimeC")))
                End If
            Else
                FromDateC = ""
                ToDateC = ""
            End If

            ' البحث عن حركات الدخول للفترة الثالثة 
            If FromDateC <> "" And ToDateC <> "" Then
                Dim SQLString2 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            Where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(FromDateC).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(FromDateC).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME "
                mycommand = New SqlCommand(SQLString2, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("StartTime3") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If

                ' البحث عن حركات الخروج للفترة الثالثة
                Dim SQLString3 As String = "Select top(1) CHECKTIME from [AttCHECKINOUT] 
                                            where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS  And
                                                  [USERID] = " & EmpID & " and ( CHECKTIME between '" & Format(CDate(ToDateC).AddHours(-5), "yyyy-MM-dd HH:mm:ss") & "'  and '" & Format(CDate(ToDateC).AddHours(5), "yyyy-MM-dd HH:mm:ss") & "')   order by CHECKTIME DESC"
                mycommand = New SqlCommand(SQLString3, myconnection)
                dr = mycommand.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("EndTime3") = dr.Item("CHECKTIME")
                    dr.Close()
                Else
                    dr.Close()
                End If
            End If
            'احتساب دوام الفترة الثالثة
            If ListDays.Rows(i).Item("StartTime3").ToString <> "" And ListDays.Rows(i).Item("EndTime3").ToString <> "" Then
                If CDate(ListDays.Rows(i).Item("EndTime3")) > CDate(ListDays.Rows(i).Item("StartTime3")) Then
                    ListDays.Rows(i).Item("Period3") = CDate(ListDays.Rows(i).Item("EndTime3")).Subtract(CDate(ListDays.Rows(i).Item("StartTime3")))
                Else
                    ListDays.Rows(i).Item("Period3") = (CDate(ListDays.Rows(i).Item("EndTime3")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTime3")))
                End If
            End If

        Next
        myconnection.Close()
EEnd:
        QueryData = ListDays
    End Function


    Private Sub GetEmployeesList()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = "   declare @AllEmployee as bit
                            set @AllEmployee = ( select top(1)
                                SettingValue
                            from Settings
                            where SettingName='AttShowAllEmployeesInAttReports' )
                            if @AllEmployee =1 begin
                                select EmployeeID, EmployeeName, [Department], [JobName], [Branch], [PictureEmp]
                                from [EmployeesData]
                                where  [Active] =1
                            end
                            if @AllEmployee =0 begin
                                select EmployeeID, EmployeeName, [Department], [JobName], [Branch], [PictureEmp]
                                from [EmployeesData]
                                where (ProcessType<>2 or ProcessType is null  ) and [Active] =1
                            end "
            sql.SqlTrueTimeRunQuery(SqlString)
            SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        GetEmployeesList()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "last"
                Dim _fromdate, _todate As DateTime
                Dim _lastmonth, _year As Integer

                If Today.Month = 1 Then
                    _lastmonth = 12
                    _year = Today.Year - 1
                Else
                    _lastmonth = Today.Month - 1
                    _year = Today.Year
                End If

                Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
                _fromdate = New Date(_year, _lastmonth, 1)
                _todate = New Date(_year, _lastmonth, _daysCount)

                Me.DateEdit2.DateTime = _todate
                Me.DateEdit1.DateTime = _fromdate

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If

            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If

        End Select
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged

    End Sub

    Private Sub RepositoryAddOrEditTrans_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryAddOrEditTrans.ButtonClick
        Dim SrartTime As DateTime



        SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("StartTimeA"))
        ' EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("EndTimeA"))


        Dim f As New AttEditTrans
        With f
            .DateEdit1.DateTime = SrartTime.AddHours(-23)
            .DateEdit2.DateTime = SrartTime.AddHours(23)
            .SearchLookUpEdit1.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
            .ShowDialog()
        End With
    End Sub
End Class