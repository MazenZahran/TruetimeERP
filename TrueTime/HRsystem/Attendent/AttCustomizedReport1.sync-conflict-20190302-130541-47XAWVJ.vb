Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports System.Data.SqlClient

Public Class AttCustomizedReport1
    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean
    Dim RequiredDailyHoures As TimeSpan
    Dim RestDailyHoures As TimeSpan
    Dim OffDay1 As String
    Dim OffDay2 As String
    Dim SalaryPerHour As Decimal
    Dim BonusPerHour As Decimal = 1
    Dim Salary As Decimal = 0
    Dim DailyTransport As Decimal = 0
    Dim SalaryAccountNo As String = " "



    Private Sub AttReportByHouresFixed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)

        Me.DateEdit2.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt

        Me.KeyPreview = True

        GetSettings()
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim SqlString As String

        Try
            SqlString = " select SettingValue From Settings where SettingName ='VocationAtOffDay'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = 1 Then
                CheckCalcVocationsAtOffDay.Checked = True
            Else
                CheckCalcVocationsAtOffDay.Checked = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='ElapseTimeZeroOnVocationDay'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = "1" Then
                CheckElapseOnVocation.Checked = True
            Else
                CheckElapseOnVocation.Checked = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub


    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            UpdateData()
        ElseIf e.KeyCode = Keys.Insert Then
            InsertSub()
        ElseIf e.KeyCode = Keys.F12 Then
            ShowPrint()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub

    Private Sub UpdateData()
        GridControl1.DataSource = String.Empty
        Summery = False


        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("جاري تحضير بيانات التقرير...")

        Dim EmployeesTable As DataTable
        Dim DataTable As New DataTable
        Dim SQLString As String
        Dim EmpIDCombo As String = SearchLookUpEdit1.EditValue






        SQLString = " Select  DISTINCT USERID as EmpID ,EmployeeName, [AttPlane],
                              RequiredDailyHoures,OffDay1,OffDay2,SalaryPerHour,RestDailyHoures,BonusPerHour,Salary,DailyTransport,SalaryAccountNo
                      From    AttCHECKINOUT,EmployeesData
                      where   (DontCheckInOut IS NULL OR DontCheckInOut=0) 
                              and AttCHECKINOUT.userid = EmployeesData.EmployeeID "

        If CheckEditCheckActive.Checked = True Then SQLString = SQLString + "and EmployeesData.Active = 1"
        If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = '" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = '" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = '" & LookUpEditPosition.EditValue & "'"


        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then MsgBox("لا يوجد حركات") : SplashScreenManager1.CloseWaitForm() : Exit Sub

        EmployeesTable = sql.SQLDS.Tables(0)


        For j As Integer = 0 To EmployeesTable.Rows.Count - 1
            Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")
            EmployeeName = EmployeesTable.Rows(j).Item("EmployeeName")
            If Not IsDBNull(EmployeesTable.Rows(j).Item("OffDay1")) Then OffDay1 = EmployeesTable.Rows(j).Item("OffDay1")
            If Not IsDBNull(EmployeesTable.Rows(j).Item("OffDay2")) Then OffDay2 = EmployeesTable.Rows(j).Item("OffDay2")
            If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryPerHour")) Then
                SalaryPerHour = EmployeesTable.Rows(j).Item("SalaryPerHour")
            Else
                SalaryPerHour = 0
            End If

            If Not IsDBNull(EmployeesTable.Rows(j).Item("Salary")) Then
                Salary = EmployeesTable.Rows(j).Item("Salary")
            Else
                Salary = 0
            End If

            If Not IsDBNull(EmployeesTable.Rows(j).Item("RequiredDailyHoures")) Then
                RequiredDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
            Else
                RequiredDailyHoures = TimeSpan.Zero
            End If

            If Not IsDBNull(EmployeesTable.Rows(j).Item("RestDailyHoures")) Then
                RestDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RestDailyHoures"))
            Else
                RestDailyHoures = TimeSpan.Zero
            End If

            If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHour")) Then BonusPerHour = EmployeesTable.Rows(j).Item("BonusPerHour")

            If Not IsDBNull(EmployeesTable.Rows(j).Item("DailyTransport")) Then DailyTransport = EmployeesTable.Rows(j).Item("DailyTransport")

            If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryAccountNo")) Then SalaryAccountNo = EmployeesTable.Rows(j).Item("SalaryAccountNo")


            DataTable.Merge(QueryData(EmpID))
        Next
        Summery = True

        GridControl1.DataSource = DataTable

        BandedGridView1.BestFitColumns()
        ' GridBand1.Width = GridControl1.Width / 2
        'If SearchLookUpEdit1.EditValue = 0 Or IsNothing(SearchLookUpEdit1.EditValue) Then
        '    ColEmpID.Visible = True
        '    CollEmployeeName.Visible = True
        'Else
        '    ColEmpID.Visible = False
        '    CollEmployeeName.Visible = False
        'End If

        '    BandedGridView1.BestFitColumns()

        SplashScreenManager1.CloseWaitForm()

    End Sub

    Private Function QueryData(EmpID As String) As DataTable




        '    If (SearchLookUpEdit1.EditValue = 0) Then MsgBox("الرجاء اختيار موظف") : Exit Sub

        '    Dim EmpID As String = SearchLookUpEdit1.EditValue


        Dim PlaneTable As New DataTable

        Dim ListDays As New DataTable
        Dim DD As New DataColumn
        DD.AllowDBNull = False
        DD.Unique = True
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
        ListDays.Columns.Add("Voc", GetType(String))
        ListDays.Columns.Add("LeavesHours", GetType(TimeSpan))
        ListDays.Columns.Add("BonusHours", GetType(TimeSpan))
        ListDays.Columns.Add("NetDurations", GetType(TimeSpan))
        ListDays.Columns.Add("SalaryPerHour", GetType(Decimal))
        ListDays.Columns.Add("NetSalary", GetType(Decimal))
        ListDays.Columns.Add("BonusPerHour", GetType(Decimal))

        ListDays.Columns.Add("MonthlySalary", GetType(Decimal))
        ListDays.Columns.Add("BonusHoursNIS", GetType(Decimal))
        ListDays.Columns.Add("LeavesHoursNIS", GetType(Decimal))
        ListDays.Columns.Add("Payment", GetType(Decimal))
        ListDays.Columns.Add("DailyTransport", GetType(Decimal))
        ListDays.Columns.Add("SalaryAccountNo", GetType(String))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim CurrDName As String = Format(CurrD, "dddd")


        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)


        While (CurrD < endP)
            CurrD = CurrD.AddDays(1)
            ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        End While



        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        Dim dr As SqlDataReader
        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1
            ListDays.Rows(i).Item("BonusPerHour") = BonusPerHour
            ListDays.Rows(i).Item("RequiredDailyHoures") = RequiredDailyHoures
            ListDays.Rows(i).Item("RestDailyHoures") = RestDailyHoures
            ListDays.Rows(i).Item("MonthlySalary") = Salary

            Dim FromDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            Dim ToDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero
            Dim TotalDurationsSpan As TimeSpan = TimeSpan.Zero


            Dim GetTransAllCount As String = "0"
            Dim GetTransInCount As String = "0"
            Dim GetTransOutCount As String = "0"
            GetTransAllCount = GetTransCount(FromDate2, ToDate2, EmpID).Item1
            GetTransInCount = GetTransCount(FromDate2, ToDate2, EmpID).Item2
            GetTransOutCount = GetTransCount(FromDate2, ToDate2, EmpID).Item3

            If GetTransInCount > 0 Then
                If GetTransInCount > 5 Then GetTransInCount = 5
                For j = 1 To CInt(GetTransInCount)
                    Try





                        Dim SQLString2 As String = "SELECT     Row, CHECKTIME AS CheckINTimes, USERID, CHECKTYPE, ID As CheckInID,EditedType
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [TrueTime].[dbo].[AttCHECKINOUT] 
                                        where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
                                        where row =" & j

                        'Dim SQLString2 As String = ";WITH BASE_DATA AS
                        '                        (
                        '                            SELECT
                        '                                TS.CHECKTIME AS CheckINTimes ,TS.CHECKTYPE,TS.USERID,EditedType,ID As CheckInID,ROW_NUMBER() OVER 
                        '                                    (
                        '                                        ORDER BY TS.CHECKTIME
                        '                                    ) AS TS_RID
                        '                            FROM     [TrueTime].[dbo].[AttCHECKINOUT]    TS
                        '                        )
                        '                        Select  Row, CheckINTimes, USERID, CHECKTYPE, CheckInID As CheckInID,EditedType From 
                        '                        (
                        '                         SELECT ROW_NUMBER() OVER(ORDER BY BD.CheckINTimes ASC) AS Row,
                        '                            BD.CheckINTimes,bd.USERID,BD.CHECKTYPE,BD.CheckInID,BD.EditedType
                        '                            ,CONVERT(TIME(0),DATEADD(MINUTE,DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes),CONVERT(DATETIME,0,0)),0) AS TimeDiff
                        '                         FROM            BASE_DATA       BD
                        '                         LEFT OUTER JOIN BASE_DATA       BD2
                        '                         ON              BD.TS_RID   =   BD2.TS_RID + 1

                        '                         where   BD.USERID =" & EmpID & " and BD.CheckINTimes between '" & FromDate2 & "' and '" & ToDate2 & "' and BD.CHECKTYPE='I' COLLATE Latin1_General_CS_AS 
                        '                         and CONVERT(TIME(0),DATEADD(MINUTE,DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes),CONVERT(DATETIME,0,0)),0) > '00:05:00'
                        '                         )  
                        '                         aa
                        '                         where Row =" & j

                        'MsgBox(j)

                        mycommand = New SqlCommand(SQLString2, myconnection)
                        dr = mycommand.ExecuteReader

                        Try
                            If dr.HasRows Then
                                dr.Read()

                                'If j > 1 Then

                                '    MsgBox(Format(CDate(ListDays.Rows(i).Item("StartTimeReal" & j - 1)).AddMinutes(5), "yyyy-MM-dd HH:mm"))
                                '    Dim CC As String = Format(CDate(dr.Item("CheckINTimes")), "yyyy-MM-dd HH:mm")
                                '    Dim CC2 As String = Format(CDate(ListDays.Rows(i).Item("StartTimeReal" & j - 1)).AddMinutes(5), "yyyy-MM-dd HH:mm")


                                '    If CDate(CC) > CDate(CC2) Then
                                '        ListDays.Rows(i).Item("StartTimeReal" & j) = dr.Item("CheckINTimes")
                                '        ListDays.Rows(i).Item("TransInID") = dr.Item("CheckInID")
                                '        ListDays.Rows(i).Item("EditedTypeIn") = dr.Item("EditedType")
                                '    End If
                                '  End If
                                'If j = 1 Then
                                ListDays.Rows(i).Item("StartTimeReal" & j) = dr.Item("CheckINTimes")
                                ListDays.Rows(i).Item("TransInID") = dr.Item("CheckInID")
                                ListDays.Rows(i).Item("EditedTypeIn") = dr.Item("EditedType")
                                'End If




                                dr.Close()

                            Else
                                dr.Close()
                            End If


                        Catch ex As Exception
                            MsgBox(ex.ToString)
                            dr.Close()
                        End Try






                        If Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal" & j)) Then
                            ' MsgBox(ListDays.Rows(i).Item("StartTimeReal" & j))
                            Dim CheckIn, CheckOut As String

                            CheckIn = Format((ListDays.Rows(i).Item("StartTimeReal" & j)), "yyyy-MM-dd HH:mm")
                            CheckOut = Format(CDate(CheckIn).AddHours(23.5999), "yyyy-MM-dd HH:mm")


                            Dim SQLString3 As String = " SELECT CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType
                                                 FROM   [TrueTime].[dbo].[AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & "
                                                        and ( CHECKTIME between '" & CheckIn & "'  and '" & CheckOut & "')"


                            mycommand = New SqlCommand(SQLString3, myconnection)
                            dr = mycommand.ExecuteReader
                            If dr.HasRows Then
                                dr.Read()
                                ListDays.Rows(i).Item("EndTimeReal" & j) = dr.Item("CheckOutTimes")
                                ListDays.Rows(i).Item("TransOutID") = dr.Item("CheckOutID")
                                ListDays.Rows(i).Item("EditedTypeOut") = dr.Item("EditedType")
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
                        Dim sql As New SQLControl
                        Dim SQLString As String = ";WITH BASE_DATA AS
                                                (
                                                    SELECT
                                                        TS.CHECKTIME AS CheckINTimes ,TS.CHECKTYPE,TS.USERID,EditedType,ID As CheckInID,ROW_NUMBER() OVER 
                                                            (
                                                                ORDER BY TS.CHECKTIME
                                                            ) AS TS_RID
                                                    FROM     [TrueTime].[dbo].[AttCHECKINOUT]    TS
                                                )
                                                Select  Row, CheckINTimes, USERID, CHECKTYPE, CheckInID As CheckInID,EditedType From 
                                                (
	                                                SELECT ROW_NUMBER() OVER(ORDER BY BD.CheckINTimes ASC) AS Row,
	                                                   BD.CheckINTimes,bd.USERID,BD.CHECKTYPE,BD.CheckInID,BD.EditedType
	                                                   ,CONVERT(TIME(0),DATEADD(MINUTE,DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes),CONVERT(DATETIME,0,0)),0) AS TimeDiff
	                                                FROM            BASE_DATA       BD
	                                                LEFT OUTER JOIN BASE_DATA       BD2
	                                                ON              BD.TS_RID   =   BD2.TS_RID + 1

	                                                where   BD.USERID =" & EmpID & " and BD.CheckINTimes between '" & FromDate2 & "' and '" & ToDate2 & "' and BD.CHECKTYPE='O' COLLATE Latin1_General_CS_AS 
	                                                and CONVERT(TIME(0),DATEADD(MINUTE,DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes),CONVERT(DATETIME,0,0)),0) > '00:02:00'
                                                 )  
                                                 aa
                                                 where Row =" & j
                        sql.SqlTrueTimeRunQuery(SQLString)

                        ListDays.Rows(i).Item("EndTimeReal" & j) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                        ListDays.Rows(i).Item("TransInID") = sql.SQLDS.Tables(0).Rows(0).Item("CheckInID")
                        ListDays.Rows(i).Item("EditedTypeIn") = sql.SQLDS.Tables(0).Rows(0).Item("EditedType")


                    Catch ex As Exception
                        '   MsgBox(ex.ToString)
                    End Try

                Next j

            End If








            Try

                With GetVocID(Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd"), ListDays.Rows(i).Item("EmpID"))
                    ListDays.Rows(i).Item("Voc") = .Item1
                    ListDays.Rows(i).Item("AttStatus") = .Item2
                    If ListDays.Rows(i).Item("AttStatus") = "سنوية" Then
                        If CheckElapseOnVocation.Checked = True Then ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero
                    End If
                End With

                'If IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures")) Then
                '    If ListDays.Rows(i).Item("Voc") = "1" And CheckCalcVocationsAtOffDay.Checked = False Then
                '        ListDays.Rows(i).Item("AttStatus") = "عطلة"
                '        ListDays.Rows(i).Item("Voc") = "0"
                '    ElseIf ListDays.Rows(i).Item("Voc") = "1" And CheckCalcVocationsAtOffDay.Checked = True Then
                '        ListDays.Rows(i).Item("AttStatus") = "سنوية"
                '    ElseIf ListDays.Rows(i).Item("Voc") = "0" Then
                '        ListDays.Rows(i).Item("AttStatus") = "عطلة"
                '    End If
                'End If

                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) AndAlso Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures")) And ListDays.Rows(i).Item("Voc") <> 1 Then
                    ListDays.Rows(i).Item("AttStatus") = "غياب"
                End If

                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) _
                And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures")) And ListDays.Rows(i).Item("Voc") <> 1 _
                And GetTransAllCount > GetTransInCount + GetTransOutCount Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                If OffDay1 = Format(CDate(ListDays.Rows(i).Item("TransDate")), "dddd") Or
                   OffDay2 = Format(CDate(ListDays.Rows(i).Item("TransDate")), "dddd") Then
                    ListDays.Rows(i).Item("AttStatus") = "عطلة"
                    ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero
                End If


                If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures"))) Then
                    ListDays.Rows(i).Item("AttStatus") = "دوام"
                End If

                Dim DiffHoureSpan As TimeSpan
                DiffHoureSpan = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")
                If DiffHoureSpan > TimeSpan.Zero Then
                    ListDays.Rows(i).Item("BonusHours") = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")
                    '  ListDays.Rows(i).Item("NetDurations") = ListDays.Rows(i).Item("TotalDurations") + ListDays.Rows(i).Item("BonusHours") - ListDays.Rows(i).Item("RestDailyHoures")
                ElseIf DiffHoureSpan < TimeSpan.Zero Then
                    ListDays.Rows(i).Item("LeavesHours") = ListDays.Rows(i).Item("RequiredDailyHoures") - ListDays.Rows(i).Item("TotalDurations")
                    Dim LeavesHours As TimeSpan = ListDays.Rows(i).Item("LeavesHours")
                    ListDays.Rows(i).Item("LeavesHoursNIS") = SalaryPerHour * LeavesHours.TotalHours
                    '  ListDays.Rows(i).Item("NetDurations") = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("LeavesHours") - ListDays.Rows(i).Item("RestDailyHoures")
                ElseIf DiffHoureSpan = TimeSpan.Zero Then
                    ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


            ListDays.Rows(i).Item("SalaryPerHour") = SalaryPerHour
            ListDays.Rows(i).Item("DailyTransport") = DailyTransport
            ListDays.Rows(i).Item("SalaryAccountNo") = SalaryAccountNo
            ListDays.Rows(i).Item("Payment") = GetPayment(ListDays.Rows(i).Item("EmpID").ToString, Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd").ToString)

            'Dim LeavesHours As TimeSpan = TimeSpan.Zero
            'If (IsDBNull(ListDays.Rows(i).Item("LeavesHours"))) Then LeavesHours = ListDays.Rows(i).Item("LeavesHours")

            Dim BonusHoures As TimeSpan
            If IsDBNull(ListDays.Rows(i).Item("BonusHours")) Then
                BonusHoures = TimeSpan.Zero
            Else
                BonusHoures = ListDays.Rows(i).Item("BonusHours")
            End If

            Dim TotalDurations As TimeSpan = TimeSpan.Zero
            If ListDays.Rows(i).Item("TotalDurations") > TimeSpan.Zero Then
                If CheckEditRestTime.Checked = True Then
                    TotalDurations = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RestDailyHoures") - BonusHoures
                Else
                    TotalDurations = ListDays.Rows(i).Item("TotalDurations") - BonusHoures
                End If


                ListDays.Rows(i).Item("BonusHoursNIS") = SalaryPerHour * BonusPerHour * BonusHoures.TotalHours

                Dim BonusHoursNIS As Decimal = 0
                If IsDBNull(ListDays.Rows(i).Item("BonusHoursNIS")) Then
                    BonusHoursNIS = 0
                Else
                    BonusHoursNIS = ListDays.Rows(i).Item("BonusHoursNIS")
                End If

                Dim LeavesHoursNIS As Decimal = 0
                If IsDBNull(ListDays.Rows(i).Item("LeavesHoursNIS")) Then
                    LeavesHoursNIS = 0
                Else
                    LeavesHoursNIS = ListDays.Rows(i).Item("LeavesHoursNIS")
                End If

                Dim Payment As Decimal = 0
                If IsDBNull(ListDays.Rows(i).Item("Payment")) Then
                    Payment = 0
                Else
                    Payment = ListDays.Rows(i).Item("Payment")
                End If

                ListDays.Rows(i).Item("NetSalary") = Salary + BonusHoursNIS - LeavesHoursNIS + DailyTransport - Payment
                '  ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) + SalaryPerHour * BonusPerHour * BonusHoures.TotalHours
                ListDays.Rows(i).Item("NetSalary") = Format(ListDays.Rows(i).Item("NetSalary"), "n1")

                    'ListDays.Rows(i).Item("LeavesHoursNIS") = (ListDays.Rows(i).Item("LeavesHours")) * SalaryPerHour
                Else
                    ListDays.Rows(i).Item("NetSalary") = 0
            End If

        Next

        '    myconnection.Close()


        QueryData = ListDays



    End Function


    Private Sub InsertSub()

        'Try
        '    My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue

        '    '    My.Forms.AttEditTrans.DateEdit1.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")

        '    If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> "" Then
        '        My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
        '        My.Forms.AttEditTrans.TimeEdit1.Time = Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal"), "HH:mm")
        '    Else
        '        My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
        '    End If
        '    If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> "" Then
        '        My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
        '        My.Forms.AttEditTrans.TimeEdit2.Time = Format(BandedGridView1.GetFocusedRowCellValue("EndTimeReal"), "HH:mm")
        '    Else
        '        My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
        '    End If

        '    My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True
        '    '   My.Forms.AttEditTrans.DateEdit1.ReadOnly = True


        '    My.Forms.AttEditTrans.DateEdit3.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd") & " 00:00:00"

        '    AttEditTrans.Show()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        '    AttEditTrans.Show()
        'End Try

        Try

            My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue
            If BandedGridView1.GetFocusedRowCellValue("StartTimeReal1").ToString <> String.Empty Then

                My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("StartTimeReal1")).AddHours(-6)
                My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("StartTimeReal1")).AddHours(6)
                My.Forms.AttEditTrans.DateEdit3.DateTime = BandedGridView1.GetFocusedRowCellValue("StartTimeReal1")
            Else
                My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate")).AddHours(-6)
                My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate")).AddHours(6)
                My.Forms.AttEditTrans.DateEdit3.DateTime = BandedGridView1.GetFocusedRowCellValue("TransDate")
            End If
            AttEditTrans.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

            AttEditTrans.Show()
        End Try
    End Sub


    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.EditValueChanged
        If SpinEdit1.Value >= 0 AndAlso SpinEdit1.IsHandleCreated Then
            'Do the work

            If SpinEdit1.Text = 0 Then Me.LeaveBand1.Visible = False : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 1 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 2 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 3 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 4 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 5 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True



            '  BandedGridView1.BestFitColumns()

            Using g = GridControl1.CreateGraphics()

                For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BandedGridView1.Bands
                    band.MinWidth = CInt(g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width)
                Next
            End Using


            BandedGridView1.BestFitColumns()
        End If
    End Sub


    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawCell

        'Dim ImageIN As Image = My.Resources.User_Blue_icon
        'Dim ImageOut As Image = My.Resources.User_Red_icon
        'Dim ImageIN2 As Image = My.Resources.User_Green_icon
        'Dim ImageOut2 As Image = My.Resources.User_Orange_icon
        Dim EmptyTrans As Image = My.Resources.User_Red_icon
        Dim View As GridView = CType(sender, GridView)


        'If e.Column.FieldName = "StartTimeReal" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTime"))
        '    Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal"))
        '    If category2 = "" And category <> "" Then
        '        e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '        '  e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '        '   e.DisplayText = "انقر للتعديل"
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If

        'If e.Column.FieldName = "EndTimeReal" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
        '    Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal"))
        '    If category2 = "" And category <> "" Then
        '        e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '        ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '        '  e.DisplayText = "..."
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If



        For j As Integer = 1 To 5
            If e.Column.FieldName = "EndTimeReal" & j Or e.Column.FieldName = "StartTimeReal" & j Then
                Dim category1 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal" & j))
                Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal" & j))
                Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("RequiredDailyHoures"))

                If category1 = String.Empty And category2 = String.Empty Then GoTo eend3
                If (category1 = String.Empty Or category2 = String.Empty) And category3 <> String.Empty Then
                    e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                    ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                    '  e.DisplayText = "..."
                    e.Appearance.Options.CancelUpdate()
eend3:          End If
            End If
        Next
    End Sub


    Private Sub BandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = " .................:توقيع الادارة"
        Dim Tawqe3_2 As String = " .................:توقيع الموظف"

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)


        If SearchLookUpEdit1.Text <> String.Empty Or IsDBNull(SearchLookUpEdit1.EditValue) Or CStr(SearchLookUpEdit1.EditValue) IsNot Nothing Or CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة : " & SearchLookUpEdit1.Text)
        Else
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة  ")
        End If

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



    End Sub


    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridView1.CustomSummaryCalculate

        If Summery = False Then Exit Sub
        '  MsgBox("df")
        Try

            Dim view As GridView = TryCast(sender, GridView)
            Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                If summaryID < 30 Then
                    e.TotalValue = TimeSpan.Zero
                ElseIf summaryID = 100 Or summaryID = 101 Or summaryID = 102 Then
                    e.TotalValue = 0
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If summaryID < 30 Then
                    Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
                    ts = ts + CType(e.TotalValue, TimeSpan)
                    e.TotalValue = ts
                ElseIf summaryID = 100 Or summaryID = 200 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "عطلة" Then
                        e.TotalValue = e.TotalValue + 1
                        'Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"))
                    End If
                ElseIf summaryID = 101 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "غياب" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                ElseIf summaryID = 102 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "دوام" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If summaryID < 30 Then
                    e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))
                End If
            End If




        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        ' MsgBox("df2")
    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ShowPrint()
    End Sub
    Private Sub ShowPrint()
        If GridControl1.IsPrintingAvailable = False Then Exit Sub
        If BandedGridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButtonInsertAttTrans_Click(sender As Object, e As EventArgs) Handles SimpleButtonInsertAttTrans.Click
        InsertSub()
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try

            Dim SrartTime As String
            Dim EndTime As String

            If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTimeReal1")) Then
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal1"), "yyyy-MM-dd HH:mm"))
                EndTime = CDate(SrartTime).AddHours(23.59)
            Else
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " 00:00"
                EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " 23:59"
            End If



            My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(SrartTime).AddHours(-6)
            My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(EndTime).AddHours(6)

            If BandedGridView1.GetFocusedRowCellValue("EmpID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If

            'If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> "" Then
            '    My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
            '    My.Forms.AttEditTrans.TimeEdit1.Time = SrartTime
            'Else
            '    My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            'End If

            'If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> "" Then
            '    My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
            '    My.Forms.AttEditTrans.TimeEdit2.Time = EndTime
            'Else
            '    My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
            'End If

            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True


            AttEditTrans.DateEdit3.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate").ToString)
            AttEditTrans.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            AttEditTrans.Show()
        End Try
    End Sub

    Private Sub SimpleButtonAddVocations_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddVocations.Click
        Try
            My.Forms.AddVocation.FromFrom.Text = Me.Text
            If BandedGridView1.GetFocusedRowCellValue("EmpID") <> "False" Then
                My.Forms.AddVocation.LookUpEditEmployees.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
                My.Forms.AddVocation.DateEditTo.DateTime = BandedGridView1.GetFocusedRowCellValue("TransDate")
                My.Forms.AddVocation.DateEditFrom.DateTime = BandedGridView1.GetFocusedRowCellValue("TransDate")

            End If

            If Not IsNothing(SearchLookUpEdit1.EditValue) Or SearchLookUpEdit1.EditValue <> 0 Then
                My.Forms.AddVocation.LookUpEditEmployees.EditValue = SearchLookUpEdit1.EditValue
                My.Forms.AddVocation.DateEditTo.DateTime = Today
                My.Forms.AddVocation.DateEditFrom.DateTime = Today

            End If

            AddVocation.Show()
            My.Forms.AddVocation.MemoDetails.Select()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Grouping()
    End Sub

    Private Sub Grouping()

        BandedGridView1.BeginSort()

        Summery = True

        Try

            BandedGridView1.ClearGrouping()
            Select Case RadioGroup1.EditValue
                Case 1
                    BandedGridView1.Columns("EmpID").GroupIndex = 0
                Case 2
                    BandedGridView1.Columns("TransDate").GroupIndex = 0
                Case 3
                    BandedGridView1.Columns("TransDay").GroupIndex = 0
            End Select
        Catch ex As Exception

        Finally
            BandedGridView1.EndSort()
        End Try
    End Sub

    Private Sub RadioGroup2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup2.SelectedIndexChanged
        Select Case RadioGroup2.EditValue
            Case 1
                BandedGridView1.ExpandAllGroups()

            Case 2
                BandedGridView1.CollapseAllGroups()
        End Select
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        MsgBox(BandedGridView1.GetFocusedRowCellValue("StartTimeReal1"))
    End Sub

    'Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles BandedGridView1.RowLoaded
    '    BandedGridView1.BestFitColumns()
    '    '  BandedGridView1.Bands.ba

    'End Sub

    'Private Function GetTransInCount(DateTimeFrom As String, DateTimeTo As String, EmpID As String) As Integer

    '    Try
    '        Dim SqlString As String
    '        Dim Sql As New SQLControl
    '        SqlString = "   Select count([ID]) as TransCount 
    '                        From [TrueTime].[dbo].[AttCHECKINOUT]
    '                        Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'"
    '        Sql.SqlTrueTimeRunQuery(SqlString)
    '        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
    '            Return CInt(Sql.SQLDS.Tables(0).Rows(0).Item("TransCount").ToString)
    '        Else
    '            Return 0
    '        End If
    '    Catch ex As Exception
    '        Return 0
    '    End Try

    'End Function

    Private Function GetTransCount(DateTimeFrom As String, DateTimeTo As String, EmpID As String) As Tuple(Of String, String, String)
        Dim GetTransAllCount As String = "0"
        Dim GetTransInCount As String = "0"
        Dim GetTransOutCount As String = "0"

        Dim SqlString As String

        Try
            Dim sql As New SQLControl
            SqlString = "   Select count([ID]) as TransAllCount 
                            From [TrueTime].[dbo].[AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                GetTransAllCount = "0"
            Else
                GetTransAllCount = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TransAllCount").ToString)
            End If
        Catch ex As Exception
            GetTransAllCount = "0"
        End Try

        Try
            Dim sql As New SQLControl
            SqlString = "   Select count([ID]) as TransInCount 
                            From [TrueTime].[dbo].[AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                GetTransInCount = "0"
            Else
                GetTransInCount = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TransInCount").ToString)
            End If
        Catch ex As Exception
            GetTransInCount = "0"
        End Try


        Try
            Dim sql As New SQLControl
            SqlString = "   Select count([ID]) as TransOutCount 
                            From [TrueTime].[dbo].[AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                GetTransOutCount = "0"
            Else
                GetTransOutCount = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TransOutCount").ToString)
            End If
        Catch ex As Exception
            GetTransOutCount = "0"
        End Try


        Return New Tuple(Of String, String, String)(GetTransAllCount, GetTransInCount, GetTransOutCount)


    End Function

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub
    Private Function GetPayment(EmployeeID As String, TransDate As String) As Decimal
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = "  select SUM(PaymentAmount) as payment FROM [AttEmployeePayments] where [EmployeeID]='" & EmployeeID & "' and [PaymentDate] ='" & TransDate & "'"
            sql.SqlTrueTimeRunQuery(SelectString)
            Return CDec(sql.SQLDS.Tables(0).Rows(0).Item("payment"))
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class