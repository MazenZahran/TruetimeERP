Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization

Public Class AttAttendance
    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean
    Dim TempOutID As Integer = 0
    Dim _DateOfStart As String = "1900-01-01"
    Dim _DateOfEnd As String = "2100-01-01"
    Dim _EmployeesCount As Integer = 0
    Dim _CurrentEmployeeHandle As Integer = 0
    Dim _UseLocalDataBaseForReport As Boolean = False
    Dim _ShowEmployeeDetails As Boolean = False
    Dim Branch As String = ""
    Dim Department As String = ""
    Dim JobName As String = ""
    Dim ListDays As New DataTable
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub AttReportByHouresFixed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutControl1.AllowCustomization = False
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.KeyPreview = True
        GetSettings()
        If GlobalVariables._EndDate < Today Then
            DateEdit2.Enabled = False
            DateEdit2.DateTime = GlobalVariables._EndDate
        End If
        RadioGroup3.EditValue = "last"
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
    End Sub


    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            UpdateData()
        ElseIf e.KeyCode = Keys.Insert Then
            InsertSub()
        ElseIf e.KeyCode = Keys.F12 Then
            PrintWithOption("Preview")
        ElseIf e.Control AndAlso e.KeyCode = Keys.Up Then
            If RadioGroup3.EditValue = "today" Or RadioGroup3.EditValue = "yesterday" Then
                DateEdit1.DateTime = DateEdit1.DateTime.AddDays(1)
                DateEdit2.DateTime = DateEdit2.DateTime.AddDays(1)
                UpdateData()
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.Down Then
            If RadioGroup3.EditValue = "today" Or RadioGroup3.EditValue = "yesterday" Then
                DateEdit1.DateTime = DateEdit1.DateTime.AddDays(-1)
                DateEdit2.DateTime = DateEdit2.DateTime.AddDays(-1)
                UpdateData()
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub
    Private Sub UpdateData()
        My.Forms.Main.ItemElapseTime.Caption = "0"
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        start_time = Now
        GridControl1.DataSource = String.Empty
        Summery = False
        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
        GetSettings()
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
            ToLocalAttTrans(DateEdit1.DateTime, DateEdit2.DateTime, _EmpID)
        End If

        ListDays.Clear()


        SQLString = " Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],
                              SalaryAccountNo,ProcessType,DateOfStart,DateOfEnd,[JobName],[Department],[Branch]
                      From    EmployeesData E
                      where  (DontCheckInOut IS NULL OR DontCheckInOut=0) And E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 "


        If CheckEditCheckActive.Checked = True Then SQLString = SQLString + "and E.Active = 1"
        If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
            CollEmployeeName.Visible = False
        Else
            CollEmployeeName.Visible = True
        End If
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"



        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        Try
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                SplashScreenManager.CloseForm(False)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            SplashScreenManager.CloseForm(False)
            Exit Sub
        End Try


        EmployeesTable = sql.SQLDS.Tables(0)

        _EmployeesCount = EmployeesTable.Rows.Count

        For j As Integer = 0 To EmployeesTable.Rows.Count - 1
            _CurrentEmployeeHandle = j + 1
            If Not IsDBNull(EmployeesTable.Rows(j).Item("EmpID")) Then
                Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")

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

                EmployeeName = EmployeesTable.Rows(j).Item("EmployeeName")


                If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfStart")) Then
                    _DateOfStart = Format(CDate(EmployeesTable.Rows(j).Item("DateOfStart")), "yyyy-MM-dd")
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfEnd")) Then
                    _DateOfEnd = Format(CDate(EmployeesTable.Rows(j).Item("DateOfEnd")), "yyyy-MM-dd")
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("JobName")) Then
                    JobName = (EmployeesTable.Rows(j).Item("JobName"))
                Else
                    JobName = ""
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("Department")) Then
                    Department = (EmployeesTable.Rows(j).Item("Department"))
                Else
                    Department = ""
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("Branch")) Then
                    Branch = (EmployeesTable.Rows(j).Item("Branch"))
                Else
                    Branch = ""
                End If
                'BonusPerHourAmount
                DataTable.Merge(QueryData(EmpID))
                '  DataTable.Merge((GetAttendanceTrans(EmpID, Me.DateEdit1.DateTime, Me.DateEdit2.DateTime)))
                ' ط' DataTable.Merge(GetAttendanceTrans(EmpID, Me.DateEdit1.DateTime, Me.DateEdit2.DateTime))
            End If
        Next
        Summery = True

        GridControl1.DataSource = DataTable
HH:
        SplashScreenManager.CloseForm(False)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
    End Sub
    Private Sub CreateListDays()
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
        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))



        If _ShowEmployeeDetails = True Then
            ListDays.Columns.Add("JobName", GetType(String))
            ListDays.Columns.Add("Department", GetType(String))
            ListDays.Columns.Add("Branch", GetType(String))
        End If
        ListDays.Columns.Add("Note1", GetType(String))



    End Sub
    Private Function QueryData(EmpID As String) As DataTable

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
        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))



        If _ShowEmployeeDetails = True Then
            ListDays.Columns.Add("JobName", GetType(String))
            ListDays.Columns.Add("Department", GetType(String))
            ListDays.Columns.Add("Branch", GetType(String))
        End If
        ListDays.Columns.Add("Note1", GetType(String))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
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
        If _UseLocalDataBaseForReport = True Then
            myconnection = New SqlConnection(GlobalVariables.LocalAttCHECKINOUTConnectionString)
        Else
            myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        End If

        Dim dr As SqlDataReader

        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1

            Dim CurrentDateString As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd")
            If CurrentDateString = _DateOfStart Then
                ListDays.Rows(i).Item("DateOfStart") = "True"
            End If
            If CurrentDateString = _DateOfEnd Then
                ListDays.Rows(i).Item("DateOfEnd") = "True"
            End If

            Dim FromDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            Dim ToDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero
            Dim TotalDurationsSpan As TimeSpan = TimeSpan.Zero
            Dim TotalDurationLeave As TimeSpan = TimeSpan.Zero


            ' Get INs Count
            Dim GetTransInCount As Integer = 0
            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = "   Select count([ID]) as TransInCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & ToDate2 & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
                mycommand = New SqlCommand(SqlString, myconnection)
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
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = "   Select count([ID]) as TransOutCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & Format(CDate(ToDate2).AddHours(5), "yyyy-MM-dd HH:mm") & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS"
                mycommand = New SqlCommand(SqlString, myconnection)
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
                        'If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> "" Then
                        '    SQLString2 += " and sn='" & Me.SearchDevice.EditValue & "'"
                        'End If
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
                            ' MsgBox(ListDays.Rows(i).Item("StartTimeReal" & j))
                            Dim CheckIn, CheckOut As String

                            CheckIn = Format((ListDays.Rows(i).Item("StartTimeReal" & j)), "yyyy-MM-dd HH:mm")
                            '   CheckOut = Format(CDate(CheckIn).AddHours(23.9999), "yyyy-MM-dd HH:mm")
                            CheckOut = Format(CDate(CheckIn).AddHours(30), "yyyy-MM-dd HH:mm")

                            Dim SQLString3 As String
                            SQLString3 = " SELECT top 1 CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType,EditNote
                                                 FROM   [AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS "
                            'If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> "" Then
                            '    SQLString3 += " and sn='" & Me.SearchDevice.EditValue & "'"
                            'End If
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
                'MsgBox(FromDate2)
                For j = 1 To CInt(GetTransOutCount)

                    Try
                        Dim sql As New SQLControl
                        Dim SQLString As String = ";WITH BASE_DATA AS
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
                        'If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> "" Then
                        '    SQLString += " and sn='" & Me.SearchDevice.EditValue & "'"
                        'End If

                        If GetTransOutCount <> 1 Then SQLString += " And DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes) >= 2" ' عند وجود حركة خروج واحدة فقط خلال الفترة 
                        SQLString += "          )  
                                                 aa
                                                 where Row =" & j & " order by row desc "
                        If _UseLocalDataBaseForReport = True Then
                            sql.SqlLocalTrueTimeRunQuery(SQLString)
                        Else
                            sql.SqlTrueTimeRunQuery(SQLString)
                        End If

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

            If ListDays.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (ListDays.Rows.Count)) & "%" &
                                                                                   " " & _CurrentEmployeeHandle & " From " & _EmployeesCount)
        Next

        '    myconnection.Close()


        QueryData = ListDays



    End Function




    Private Function GetEmployeeTansTable(EmpID As String, dateFrom As DateTime, dateTo As DateTime) As DataTable

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
        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))
        ListDays.Columns.Add("Note1", GetType(String))


        Dim CurrD As Date = Format(dateFrom, "yyyy-MM-dd")
        Dim endP As Date = Format(dateTo, "yyyy-MM-dd")
        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)


        While (CurrD < endP)
            CurrD = CurrD.AddDays(1)
            ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        End While

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand

        myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))


        Dim dr As SqlDataReader

        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1

            Dim CurrentDateString As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd")
            If CurrentDateString = _DateOfStart Then
                ListDays.Rows(i).Item("DateOfStart") = "True"
            End If
            If CurrentDateString = _DateOfEnd Then
                ListDays.Rows(i).Item("DateOfEnd") = "True"
            End If

            Dim FromDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            Dim ToDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero
            Dim TotalDurationsSpan As TimeSpan = TimeSpan.Zero
            Dim TotalDurationLeave As TimeSpan = TimeSpan.Zero


            ' Get INs Count
            Dim GetTransInCount As Integer = 0
            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = "   Select count([ID]) as TransInCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & ToDate2 & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
                mycommand = New SqlCommand(SqlString, myconnection)
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
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = "   Select count([ID]) as TransOutCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & FromDate2 & "' and '" & Format(CDate(ToDate2).AddHours(5), "yyyy-MM-dd HH:mm") & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS"
                mycommand = New SqlCommand(SqlString, myconnection)
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
                        'If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> "" Then
                        '    SQLString2 += " and sn='" & Me.SearchDevice.EditValue & "'"
                        'End If
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
                            ' MsgBox(ListDays.Rows(i).Item("StartTimeReal" & j))
                            Dim CheckIn, CheckOut As String

                            CheckIn = Format((ListDays.Rows(i).Item("StartTimeReal" & j)), "yyyy-MM-dd HH:mm")
                            '   CheckOut = Format(CDate(CheckIn).AddHours(23.9999), "yyyy-MM-dd HH:mm")
                            CheckOut = Format(CDate(CheckIn).AddHours(30), "yyyy-MM-dd HH:mm")

                            Dim SQLString3 As String
                            SQLString3 = " SELECT top 1 CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType,EditNote
                                                 FROM   [AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS "
                            'If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> "" Then
                            '    SQLString3 += " and sn='" & Me.SearchDevice.EditValue & "'"
                            'End If
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
                'MsgBox(FromDate2)
                For j = 1 To CInt(GetTransOutCount)

                    Try
                        Dim sql As New SQLControl
                        Dim SQLString As String = ";WITH BASE_DATA AS
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


                        If GetTransOutCount <> 1 Then SQLString += " And DATEDIFF(MINUTE,BD2.CheckINTimes,BD.CheckINTimes) >= 2" ' عند وجود حركة خروج واحدة فقط خلال الفترة 
                        SQLString += "          )  
                                                 aa
                                                 where Row =" & j & " order by row desc "

                        sql.SqlTrueTimeRunQuery(SQLString)


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

            If ListDays.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (ListDays.Rows.Count)) & "%" &
                                                                                   " " & _CurrentEmployeeHandle & " From " & _EmployeesCount)
        Next

        '    myconnection.Close()


        GetEmployeeTansTable = ListDays



    End Function

    Private Sub InsertSub()
        Try

            My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue
            If AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1").ToString <> String.Empty Then
                My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1")).AddHours(-6)
                My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1")).AddHours(6)
                My.Forms.AttEditTrans.DateEdit3.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1")
            Else
                My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("TransDate")).AddHours(-6)
                My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("TransDate")).AddHours(6)
                My.Forms.AttEditTrans.DateEdit3.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
            End If
            'AttEditTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally

            AttEditTrans.ShowDialog()
        End Try
    End Sub


    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.EditValueChanged
        If SpinEdit1.Value >= 0 AndAlso SpinEdit1.IsHandleCreated Then
            If SpinEdit1.Text = 0 Then Me.LeaveBand1.Visible = False : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 1 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 2 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 3 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 4 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 5 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True
            Using g = GridControl1.CreateGraphics()
                For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In AdvBandedGridView1.Bands
                    band.MinWidth = CInt(g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width)
                Next
            End Using
            AdvBandedGridView1.BestFitColumns()
        End If
    End Sub
    Private Sub PrintWithOption(_PrintOption)
        If GridControl1.IsPrintingAvailable = False Then Exit Sub
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If AdvBandedGridView1.RowCount = 0 Then Exit Sub
        Else
            If AdvBandedGridView1.RowCount = 0 Then Exit Sub
        End If
        AdvBandedGridView1.OptionsPrint.ExpandAllGroups = False
        Select Case _PrintOption
            Case "Print"
                GridControl1.Print()
            Case "Preview"
                GridControl1.ShowPrintPreview()
            Case "Pdf"
                GridControl1.ExportToPdf("تقرير الدوام.pdf")
        End Select
        ColAddAndEdit.Visible = True
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles AdvBandedGridView1.PrintInitialize



        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.ShowMarginsWarning = False

        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3, Tawqe3_2 As String
        If GlobalVariables._SystemLanguage = "English" Then
            Tawqe3 = " .................:Management signature"
            Tawqe3_2 = " .................:Employee signature"
        Else
            Tawqe3 = " .................:توقيع الادارة"
            Tawqe3_2 = " .................:توقيع الموظف"
        End If

        SQLString = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportLandscape' "
        sql.SqlTrueTimeRunQuery(SQLString)
        If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
            pb.PageSettings.Landscape = True
        Else
            pb.PageSettings.Landscape = False
        End If

        SQLString = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportNarrowLine' "
        sql.SqlTrueTimeRunQuery(SQLString)
        If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
            ColAddAndEdit.Visible = False
        Else
            ColAddAndEdit.Visible = True
        End If

        SQLString = " select SettingValue from Settings where SettingName ='AttPrintAttendantReportShowEmpID' "
        sql.SqlTrueTimeRunQuery(SQLString)
        If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
            ColEmpID.Visible = True
        Else
            ColEmpID.Visible = False
        End If

        Dim _VocationString As String

        Dim _VocationTableInMonthSalaryVisible As Boolean
        _VocationTableInMonthSalaryVisible = False
        Try
            SQLString = " select SettingValue From Settings where SettingName ='VocationTableInMonthSalaryVisible'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then _VocationTableInMonthSalaryVisible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        If _VocationTableInMonthSalaryVisible = True Then
            pb.PageSettings.TopMargin = 50
            pb.PageSettings.BottomMargin = 75
            Dim _VocationBalances = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Me.DateEdit2.DateTime)
            If GlobalVariables._SystemLanguage = "English" Then
                _VocationString = " balance of the first period: " & _VocationBalances.BeginingBalance & "  " & vbCrLf &
                                  " Completed vacations during the year: " & _VocationBalances.ThisYearVocations & "  " & vbCrLf &
                                  " Leave balance for the end of the year: " & _VocationBalances.Balance & "  " & vbCrLf &
                                  " Leave balance for today's date : " & _VocationBalances.AccruedVocations & "  "
                Tawqe3 = _VocationString
                Tawqe3_2 = " .................:Employee signature" & "  " & vbCrLf & Tawqe3 = " .................:Management signature"
            Else
                _VocationString = " رصيد أول الفترة: " & _VocationBalances.BeginingBalance & "  " & vbCrLf &
                                  " اجازات مستوفاه خلال السنة : " & _VocationBalances.ThisYearVocations & "  " & vbCrLf &
                                  " رصيد الاجازات لنهاية العام : " & _VocationBalances.Balance & "  " & vbCrLf &
                                  " رصيد الاجازات لتاريخ اليوم : " & _VocationBalances.AccruedVocations & "  "
                Tawqe3 = _VocationString
                Tawqe3_2 = " .................:توقيع الموظف" & "  " & vbCrLf & " .................:توقيع الادارة "
            End If
        Else
            pb.PageSettings.TopMargin = 50
            pb.PageSettings.BottomMargin = 50
        End If



        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)


        If SearchLookUpEdit1.Text <> String.Empty Or IsDBNull(SearchLookUpEdit1.EditValue) Or CStr(SearchLookUpEdit1.EditValue) IsNot Nothing Or CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            If GlobalVariables._SystemLanguage = "English" Then
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "Hourly employee time report : " & SearchLookUpEdit1.Text & "  From  " & DateEdit1.DateTime & " To  " & DateEdit2.DateTime)
            Else
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "تقرير دوام الموظف بالساعة : " & SearchLookUpEdit1.Text & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
            End If

        Else
            If GlobalVariables._SystemLanguage = "English" Then
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "Hourly employee time report " & " From  " & DateEdit1.DateTime & " To  " & DateEdit2.DateTime)
            Else
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "تقرير دوام الموظف بالساعة " & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
            End If

            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        End If


    End Sub


    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles AdvBandedGridView1.CustomSummaryCalculate

        If Summery = False Then Exit Sub
        '  MsgBox("df")
        Try

            Dim view As GridView = TryCast(sender, GridView)
            Dim summaryID As Decimal = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                If summaryID < 30 Then
                    e.TotalValue = TimeSpan.Zero
                    'ElseIf summaryID = 50 Then
                    '    e.TotalValue = TimeSpan.Zero
                ElseIf summaryID = 100 Or summaryID = 101 Or summaryID = 102 Or summaryID = 15001 Or summaryID = 19001 Then
                    e.TotalValue = 0
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If summaryID < 30 Then
                    If e.FieldValue IsNot Nothing Then
                        Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
                        ts = ts + CType(e.TotalValue, TimeSpan)
                        e.TotalValue = ts
                    End If
                ElseIf summaryID = 16001 Then
                    '  e.TotalValue = e.TotalValue + Convert.ToDecimal(AdvBandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(AdvBandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                    e.TotalValue = e.TotalValue + Convert.ToDecimal(AdvBandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(7), GridGroupSummaryItem)))
                ElseIf summaryID = 15001 Then
                    ' e.TotalValue = e.TotalValue + Convert.ToDecimal(AdvBandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(AdvBandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                    e.TotalValue = e.TotalValue + Convert.ToDecimal(AdvBandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(14), GridGroupSummaryItem)))
                    '    e.TotalValue = 12
                End If


            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If summaryID < 30 Then
                    'e.TotalValue = CDec(e.TotalValue.TotalHours).ToString("00") & ":" & CDec(e.TotalValue.Minutes).ToString("00")

                    Dim _TimeSpanFunction As New TimeFunctions
                    Dim _TotalMinutes As Decimal = e.TotalValue.TotalMinutes
                    e.TotalValue = _TimeSpanFunction.ConvertTimeSpan_hhmmm_ToString(_TimeSpanFunction.ConvertFromDecimalToTimeSpan(_TotalMinutes / 60))

                    'e.TotalValue = FormatTimeSpanToHHMM(e.TotalValue)
                End If



            End If




        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        ' MsgBox("df2")
    End Sub

    Function FormatTimeSpanToHHMM(ts As TimeSpan) As String
        ' Total hours and total minutes in TimeSpan
        ' Calculating total hours and total minutes
        Dim totalHours As Integer = ts.TotalHours
        Dim totalMinutes As Integer = ts.TotalMinutes

        ' Extracting days, hours, and minutes
        Dim days As Integer = ts.Days
        Dim hours As Integer = totalHours - (days * 24)
        Dim minutes As Integer = totalMinutes - (totalHours * 60)

        ' Formatting to (hh:mm)
        Dim formattedTime As String = $"{hours:00}:{minutes:00}" ' Displaying hours and minutes in (hh:mm) format

        Return formattedTime
    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        PrintWithOption("Preview")
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try

            Dim SrartTime As String
            Dim EndTime As String

            If Not IsDBNull(AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1")) Then
                SrartTime = (Format(AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1"), "yyyy-MM-dd HH:mm"))
                EndTime = CDate(SrartTime).AddHours(23.59)
            Else
                SrartTime = (Format(AdvBandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " 00:00"
                EndTime = (Format(AdvBandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " 23:59"
            End If



            My.Forms.AttEditTrans.DateEdit1.DateTime = CDate(SrartTime).AddHours(-6)
            My.Forms.AttEditTrans.DateEdit2.DateTime = CDate(EndTime).AddHours(6)

            If AdvBandedGridView1.GetFocusedRowCellValue("EmpID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = AdvBandedGridView1.GetFocusedRowCellValue("EmpID")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If
            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True

            AttEditTrans.DateEdit3.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("TransDate").ToString)
            AttEditTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'AttEditTrans.ShowDialog()
        End Try
    End Sub

    Private Sub SimpleButtonAddVocations_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddVocations.Click
        'Try
        '    'My.Forms.AddVocation.FromFrom.Text = Me.Text
        '    If String.IsNullOrWhiteSpace(AdvBandedGridView1.GetFocusedRowCellValue("EmpID")) Then
        '        My.Forms.AddVocation.LookUpEditEmployees.EditValue = SearchLookUpEdit1.EditValue
        '        My.Forms.AddVocation.DateEditTo.DateTime = Today
        '        My.Forms.AddVocation.DateEditFrom.DateTime = Today
        '        My.Forms.AddVocation.TextVocationDate.DateTime = Today
        '    Else
        '        My.Forms.AddVocation.LookUpEditEmployees.EditValue = AdvBandedGridView1.GetFocusedRowCellValue("EmpID")
        '        My.Forms.AddVocation.DateEditTo.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
        '        My.Forms.AddVocation.DateEditFrom.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
        '        My.Forms.AddVocation.TextVocationDate.DateTime = Today
        '    End If
        '    AddVocation.TextID.EditValue = GetMaxVocationID() + 1
        '    AddVocation.TextNewOrOld.EditValue = -1
        '    AddVocation.Show()
        '    My.Forms.AddVocation.MemoDetails.Select()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        'AdvBandedGridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        'AdvBandedGridView1.OptionsView.AllowHtmlDrawGroups = True
        'AdvBandedGridView1.OptionsView.ShowFooter = True

        Dim f As New AddVocation
        With f
            .Show()
            .TextNewOrOld.Text = "New"
            .LookUpEditEmployees.EditValue = AdvBandedGridView1.GetFocusedRowCellValue("EmpID")
            .DateEditFrom.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("TransDate"))
            .DateEditTo.DateTime = CDate(AdvBandedGridView1.GetFocusedRowCellValue("TransDate"))
            .TextDayNo.EditValue = 1
            .MemoDetails.Select()
        End With

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Grouping()
    End Sub

    Private Sub Grouping()

        AdvBandedGridView1.BeginSort()

        Summery = True

        Try

            AdvBandedGridView1.ClearGrouping()
            Select Case RadioGroup1.EditValue
                Case 1
                    AdvBandedGridView1.Columns("EmpID").GroupIndex = 0
                Case 2
                    AdvBandedGridView1.Columns("TransDate").GroupIndex = 0
                Case 3
                    AdvBandedGridView1.Columns("TransDay").GroupIndex = 0
            End Select
        Catch ex As Exception

        Finally
            AdvBandedGridView1.EndSort()
        End Try
    End Sub

    Private Sub RadioGroup2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup2.SelectedIndexChanged
        Select Case RadioGroup2.EditValue
            Case 1
                AdvBandedGridView1.ExpandAllGroups()

            Case 2
                AdvBandedGridView1.CollapseAllGroups()
        End Select
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            AdvBandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        AdvBandedGridView1.BestFitColumns()
    End Sub





    Private Sub PrintRateb()



        Dim _SalaryNoteLabel As String = String.Empty
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='SalaryNoteLabel'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then _SalaryNoteLabel = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Dim _ShowVocationsTable As String = "False"
        Dim _AttShowAdditionsInSalarySlip As String = "False"
        Dim _AttShowPaymentsInSalarySlip As String = "False"
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
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

        Try

            Dim report As New SalaryReport()
            Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim _DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")
            report.Parameters("EmployeeName").Value = Me.SearchLookUpEdit1.Text
            report.Parameters("PeriodString").Value = " من " & _DateFrom & " الى " & _DateTo
            report.Parameters("DateFrom").Value = _DateFrom
            report.Parameters("DateTo").Value = _DateTo
            report.Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
            report.NoteLabel.Text = _SalaryNoteLabel
            Dim _EmpData = GetEmployeeData(Me.SearchLookUpEdit1.EditValue)
            report.Parameters("JobName").Value = _EmpData.JobName
            report.Parameters("Department").Value = _EmpData.Department
            report.Parameters("Branch").Value = _EmpData.Branch
            report.Parameters("EmployeeNoAsAcc").Value = _EmpData.SalaryAccountNo
            report.Parameters("BeginDate").Value = _EmpData.DateOfStart
            report.Parameters("Currency").Value = _EmpData.SalaryCurrency
            report.XrLabelSalaryPerHourParameter.Text = _EmpData.SalaryPerHour
            'With GetEmpData(Me.SearchLookUpEdit1.EditValue)
            '    report.Parameters("JobName").Value = .Item2
            '    report.Parameters("Department").Value = .Item3
            '    report.Parameters("Branch").Value = .Item4
            '    report.Parameters("EmployeeNoAsAcc").Value = .Item5
            '    Try
            '        report.Parameters("BeginDate").Value = Format(CDate(.Item6), "dd/MM/yyyy")
            '    Catch ex As Exception
            '        report.Parameters("BeginDate").Value = Format(CDate("1900-01-01"), "dd/MM/yyyy")
            '    End Try
            '    report.Parameters("Currency").Value = .Item7
            'End With


            Try
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select [BankName] ,[BankNo] ,[BankBranch] ,[IBAN],[Indenty],ProcessType
                              from EmployeesData E
                              where (E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 ) And EmployeeID='" & CStr(SearchLookUpEdit1.EditValue) & "'"
                Sql.SqlTrueTimeRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankName")) Then report.Parameters("BankName").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankName")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankNo")) Then report.Parameters("BankNo").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankNo")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankBranch")) Then report.Parameters("BankBranch").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankBranch")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("IBAN")) Then report.Parameters("IBAN").Value = Sql.SQLDS.Tables(0).Rows(0).Item("IBAN")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Indenty")) Then report.Parameters("Indenty").Value = Sql.SQLDS.Tables(0).Rows(0).Item("Indenty")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType")) Then
                    Select Case CInt(Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType"))
                        Case 1
                            report.XrLabelProcessTypeWords.Text = "دوام ثابت وردية"
                        Case 2
                            report.XrLabelProcessTypeWords.Text = "ساعات يومية مطلوبة"
                        Case 3
                            report.XrLabelProcessTypeWords.Text = "راتب /الساعة"
                            report.XrLabelSalaryPerHour.Visible = True
                            report.XrLabelSalaryPerHourParameter.Visible = True
                            'report.Parameters("SaleryPerHour").Value = 0
                        Case 4
                            report.XrLabelProcessTypeWords.Text = "دوام بوجود حركة"
                        Case 6
                            report.XrLabelProcessTypeWords.Text = "ساعات شهرية مطلوبة"
                    End Select
                    report.ProcessType.Value = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType"))
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            With report
                .Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue

                '  .Parameters("MonthDays").Value = ColNetSalaryMonthDays.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColTransDay.SummaryItem.SummaryValue
                .Parameters("ActualHoures").Value = ColTotalDurations.SummaryItem.SummaryValue
                '.Parameters("SaleryPerHour").Value = ColSalaryPerHour.SummaryItem.SummaryValue
                '.Parameters("VocationSick").Value = GetSumVocationsThisYear(Me.SearchLookUpEdit1.EditValue, "مرضية")
                '   .Parameters("VocationAtEndYear").Value = VocationAtEndYear(Me.SearchLookUpEdit1.EditValue) + CInt(.Parameters("VocationBegBalance").Value) - CInt(.Parameters("AccruedVocationDays").Value)
                Dim _VocationDetails = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Today())
                .Parameters("VocationAtEndYear").Value = _VocationDetails.Balance
                .Parameters("AccruedVocationDays").Value = _VocationDetails.AccruedVocations
                .Parameters("VocationBegBalance").Value = _VocationDetails.BeginingBalance
                .Parameters("VocationSick").Value = 0


                'طرح سقف المغادات من المغادرات الفعلية للموظف
                'Dim _TextLeaves As String = .Parameters("Leaves").Value
                'Dim _TimeLeaves As TimeSpan = New TimeSpan(Integer.Parse(_TextLeaves.Split(":"c)(0)), Integer.Parse(_TextLeaves.Split(":"c)(1)), 0)
                'If _TimeLeaves > MaxLeavesHoures Then
                '    .Parameters("Leaves").Value = ((_TimeLeaves - MaxLeavesHoures).ToString)
                'End If


                '  .Parameters("HouresNetLeaves").Value = ColLeavesHours.SummaryItem.SummaryValue




                'Try
                '    Dim SqlString As String
                '    Dim sql As New SQLControl
                '    SqlString = " SELECT [CompanyName] ,[CompanyAddress] ,[CompanyPhone],[CompanyMobile] ,[CompanyFax],[CompanyEmail] ,[CompanyWebSite]
                '              FROM [CompanyData] "
                '    sql.SqlTrueTimeRunQuery(SqlString)
                '    .Parameters("ComapnyName").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
                '    .Parameters("CompanyAddress").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress")
                '    .Parameters("CompanyPhone").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone")
                '    .Parameters("CompanyFax").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFax")
                'Catch ex As Exception
                '    MsgBox(ex.ToString)
                'End Try

                'Try
                '    Dim cn As SqlConnection
                '    cn = New SqlConnection
                '    cn.ConnectionString = My.Settings.TrueTimeConnectionString
                '    Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                '    cn.Open()
                '    cmd.Connection = cn
                '    cmd.CommandType = CommandType.Text
                '    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                '    .XrPictureBox1.Image = Image.FromStream(ImgStream)
                '    ImgStream.Dispose()
                '    cmd.Connection.Close()
                '    cn.Close()
                'Catch ex As Exception

                'End Try





                '  .SqlDataSource1.Queries(0).Parameters(0).Value = 2
                ' .SqlDataSource1.Fill()
            End With

            ' report.Parameters("Salary").Value = .Item7


            '  report.Parameter1.Visible = False
            ' report.VocBalance.Value = Me.TextVocationsRemaining.Text
            ' report.VocBalance.Visible = False

            ' تحميل اعدادات طباعة بيانات الادازات في قسيمة الرواتب
            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " select SettingValue From Settings where SettingName ='ShowVocationBegBalanceInRawatebSplit'"
                sql.SqlTrueTimeRunQuery(SqlString)
                If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = False Then
                    report.VocationBegBalanceText.Visible = False
                    report.VocationBegBalanceLabel.Visible = False
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try

            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " select SettingValue From Settings where SettingName ='ShowAccruedVocationDaysInRawatebSplit'"
                sql.SqlTrueTimeRunQuery(SqlString)
                If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = False Then
                    report.AccruedVocationDaysText.Visible = False
                    report.AccruedVocationDaysLabel.Visible = False
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try


            Try
                Dim sql As New SQLControl
                Dim SqlString As String
                SqlString = " select SettingValue From Settings where SettingName ='ShowVocationAtEndYearInRawatebSplit'"
                sql.SqlTrueTimeRunQuery(SqlString)
                If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = False Then
                    report.VocationAtEndYearText.Visible = False
                    report.VocationAtEndYearLabel.Visible = False
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try



            report.CreateDocument()
            report.PrintingSystem.ShowMarginsWarning = False
            report.RequestParameters = False
            SalaryMonthForm.DocumentViewer1.DocumentSource = report
            '  report.ShowPreview
            SalaryMonthForm.Show()
        Catch ex As Exception
            If GlobalVariables._SystemLanguage = "Arabic" Then
                MsgBox("خطا: لم يتمكن البرنامج من طباعة السند ")
            Else
                MsgBox("Error")
            End If

            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        PrintRateb()
    End Sub

    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        GetEmployeesList()
    End Sub

    Private Sub GetEmployeesList()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select EmployeeID,EmployeeName,[Department],[JobName],[Branch],[PictureEmp]
                      from [EmployeesData] E
                      where  E.[Active] =1 And E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 "



            sql.SqlTrueTimeRunQuery(SqlString)
            SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub





    Private Sub RepositoryProcessLeaves_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryProcessLeaves.ButtonClick
        Dim F As New AttLeavesProccessDaily
        With F
            If Not IsDBNull(AdvBandedGridView1.GetFocusedRowCellValue("NetLeavesHouresDaily")) Then
                .DateEdit1.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
                .VocationDate.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
                .TextEmployeeID.Text = AdvBandedGridView1.GetFocusedRowCellValue("EmpID")
                .TextLeavesPeriod.TimeSpan = AdvBandedGridView1.GetFocusedRowCellValue("NetLeavesHouresDaily")
                .TextEmployeeName.Text = AdvBandedGridView1.GetFocusedRowCellValue("EmployeeName")
                .LookUpEditVocations.EditValue = 1
                .RequiredDailyHoures.TimeSpan = AdvBandedGridView1.GetFocusedRowCellValue("RequiredDailyHoures")
                .TextDayNo.EditValue = (.TextLeavesPeriod.TimeSpan.TotalHours / .RequiredDailyHoures.TimeSpan.TotalHours).ToString("0.0")
                .ShowDialog()
            End If
        End With
    End Sub

    Private Sub RadioGroup3_SelectedIndexChanged_2(sender As Object, e As EventArgs) Handles RadioGroup3.SelectedIndexChanged
        Select Case RadioGroup3.EditValue
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
                RadioGroup2.EditValue = "1"
                RadioGroup1.EditValue = "1"
            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If
                RadioGroup2.EditValue = "1"
                RadioGroup1.EditValue = "1"
            Case "today"
                Me.DateEdit1.DateTime = Today
                Me.DateEdit2.DateTime = Today
                RadioGroup2.EditValue = "2"
                RadioGroup1.EditValue = "2"
            Case "yesterday"
                Me.DateEdit1.DateTime = Today.AddDays(-1)
                Me.DateEdit2.DateTime = Today.AddDays(-1)
                RadioGroup2.EditValue = "2"
                RadioGroup1.EditValue = "2"

        End Select
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Select Case BandedNote1.Visible
            Case True
                BandedNote1.Visible = False
                Exit Sub
            Case False
                BandedNote1.Visible = True
                Exit Sub
        End Select
    End Sub



    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarMonthlySalaryProcessing.ItemClick

        'Dim t1 As New TimeSpan(Split(ColRequiredDailyHoures.SummaryItem.SummaryValue, ":")(0), Split(ColRequiredDailyHoures.SummaryItem.SummaryValue, ":")(1), 0)
        'Dim t2 As New TimeSpan(Split(ColTotalDurations.SummaryItem.SummaryValue, ":")(0), Split(ColTotalDurations.SummaryItem.SummaryValue, ":")(1), 0)
        'Dim _Month As Integer = CInt(Format(DateEdit1.DateTime, "MM"))
        'Dim _Year As Integer = CInt(Format(DateEdit1.DateTime, "yyyy"))
        'Dim f As New MonthlyAdjustmentForm(_Month, _Year)
        'With f
        '    .DateDocDate.DateTime = Me.DateEdit2.DateTime
        '    .TextActualHours.EditValue = t2
        '    .MonthlyRequirdHours = TimeSpan.FromHours(t1.TotalHours)
        '    .TextEmpID.Text = SearchLookUpEdit1.EditValue
        '    If .ShowDialog() <> DialogResult.OK Then
        '        UpdateData()
        '    End If
        'End With

    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If _ShowEmployeeDetails = False Then
            gridBandEmployeesData.Visible = True
            _ShowEmployeeDetails = True
        Else
            gridBandEmployeesData.Visible = False
            _ShowEmployeeDetails = False
        End If
        UpdateData()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonAddAddition.ItemClick
        Dim f As New AttBonus

        With f
            .TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            If .ShowDialog() <> DialogResult.OK Then
                UpdateData()
            End If
        End With
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonAddDiscount.ItemClick
        Dim f As New AttAdvancePayment
        With f
            .TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            If .ShowDialog() <> DialogResult.OK Then
                UpdateData()
            End If
        End With
    End Sub

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged
        'If GlobalVariables._EndDate < Today Then
        '    'DateEdit2.Enabled = False
        '    DateEdit2.DateTime = GlobalVariables._EndDate
        'End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then
            LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select [MachineAlias],[sn] from [dbo].[Machines]  "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                Me.SearchDevice.Properties.DataSource = sql.SQLDS.Tables(0)
            End If
            LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        If GlobalVariables._AttDailyAdjustment = False Then Exit Sub
        With AdvBandedGridView1
            Dim _LeavesHours As TimeSpan, _BonusHours As TimeSpan, _EmpNo As Integer, _EmpName As String, _TransDate As Date
            Select Case .FocusedColumn.FieldName
                Case "BonusHours"
                    If IsDBNull(.GetFocusedRowCellValue("BonusHours")) Then
                        _BonusHours = TimeSpan.Zero
                    Else
                        _BonusHours = .GetFocusedRowCellValue("BonusHours")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة الاضافي "
                    f.CurrentPeriod.EditValue = _BonusHours
                    f.TextAdjustType.Text = "2"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("RequiredDailyHoures")

                    f.ShowDialog()
                Case "LeavesHours"
                    If IsDBNull(.GetFocusedRowCellValue("LeavesHours")) Then
                        _LeavesHours = TimeSpan.Zero
                    Else
                        _LeavesHours = .GetFocusedRowCellValue("LeavesHours")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة المغادرات "
                    f.CurrentPeriod.EditValue = _LeavesHours
                    f.TextAdjustType.Text = "1"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("RequiredDailyHoures")

                    f.ShowDialog()
                Case "StartTimeReal1"
                    If IsDBNull(.GetFocusedRowCellValue("StartTimeReal1")) Then
                        Dim f As New AttQuickAddTrans(.GetFocusedRowCellValue("EmpID"), "I", "Insert")
                        f.LabelControlDetails.Text = " اضافة حركة دخول للموظف  " & .GetFocusedRowCellValue("EmployeeName")
                        f.TransDate.DateTime = .GetFocusedRowCellValue("TransDate")
                        If f.ShowDialog() <> DialogResult.OK Then
                            .SetFocusedRowCellValue("StartTimeReal1", f._PublicTransTime)
                        End If
                    End If
                Case "EndTimeReal1"
                    If IsDBNull(.GetFocusedRowCellValue("EndTimeReal1")) Then
                        Dim f As New AttQuickAddTrans(.GetFocusedRowCellValue("EmpID"), "O", "Insert")
                        f.LabelControlDetails.Text = " اضافة حركة خروج للموظف  " & .GetFocusedRowCellValue("EmployeeName")
                        f.TransDate.DateTime = .GetFocusedRowCellValue("TransDate")
                        If f.ShowDialog() <> DialogResult.OK Then
                            .SetFocusedRowCellValue("EndTimeReal1", f._PublicTransTime)
                        End If
                    End If
                Case Else
                    Exit Sub
            End Select
        End With

    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim _EmpID As String
        If Not String.IsNullOrEmpty(SearchLookUpEdit1.Text) Then
            _EmpID = SearchLookUpEdit1.EditValue
        Else
            _EmpID = CStr(Me.AdvBandedGridView1.GetRowCellValue(AdvBandedGridView1.FocusedRowHandle, "EmpID"))
        End If
        If String.IsNullOrEmpty(_EmpID) Then Exit Sub
        My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = _EmpID
        My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
        EmployeesEdit.ShowDialog()
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        AdvBandedGridView1.OptionsSelection.MultiSelect = True
        AdvBandedGridView1.SelectAll()
        AdvBandedGridView1.CopyToClipboard()
        AdvBandedGridView1.OptionsSelection.MultiSelect = False
        XtraMessageBox.Show("تم نسخ البيانات")

    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        PrintWithOption("Print")
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        PrintWithOption("Preview")
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        AttPrintSettings.ShowDialog()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If SearchLookUpEdit1.Text = "" Then
            MsgBoxShowError("يجب اختيار الموظف ")
            Exit Sub
        End If
        Dim _MobileNo As String
        _MobileNo = GetEmployeeData(SearchLookUpEdit1.EditValue).Mobile
        PrintWithOption("Pdf")
        SendFileToWhatsApp(_MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام", "", SearchLookUpEdit1.Text)
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrintWithOption("Pdf")
                SendFileToWhatsApp(MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام", "", SearchLookUpEdit1.Text)
                MsgBoxShowSuccess(" تم ارسال التقرير بنجاح ")
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class



