Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTreeList.Data
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization

Public Class AttRawatebByHouresRequiredMultiPeriod
    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean
    Dim RequiredDailyHoures As TimeSpan
    Dim RestDailyHoures As TimeSpan
    Dim OffDay1 As String = String.Empty
    Dim OffDay2 As String = String.Empty
    Dim Salary As Decimal = 0
    Dim SalaryPerHour As Decimal
    Dim SalaryPerDay As Decimal
    Dim BonusPerHour As Decimal = 1
    Dim DailyTransport As Decimal = 0
    Dim SalaryAccountNo As String = " "
    Dim BonusOnDayOff As Decimal = 1
    Dim TempOutID As Integer = 0
    Dim SubtractionLeavesAndLates As Boolean = True
    Dim AddBonusToSalary As Boolean = True
    Dim MaxLeavesHoures As TimeSpan = TimeSpan.Zero
    Dim ProcessType As String = 0
    Dim _FormType As String = String.Empty
    Dim _DateOfStart As String = "1900-01-01"
    Dim _DateOfEnd As String = "2100-01-01"
    Dim _AdditionsFound As Boolean
    Dim _PaymentFound As Boolean
    Dim _VocationsFound As Boolean
    Dim _EmployeesCount As Integer = 0
    Dim _CurrentEmployeeHandle As Integer = 0
    Dim _UseLocalDataBaseForReport As Boolean = False
    Dim _BonusPerHourAmount As Decimal = 0
    Dim _BonusPerHourAmountOption As Boolean = False
    Dim _MaxLeavesHouresDaily As TimeSpan = TimeSpan.Zero
    Dim _MaxBonusHoures As TimeSpan = TimeSpan.Zero
    Dim LastWorkLeaveID As Integer = 0
    Dim _ShowEmployeeDetails As Boolean = False
    Dim Branch As String = ""
    Dim Department As String = ""
    Dim JobName As String = ""
    Dim DaysInMonth As Decimal



    Public Sub New()
        InitializeComponent()
        '  MsgBox("Start")
        'AdvAdvBandedGridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        ' AdvAdvBandedGridView1.OptionsView.AllowHtmlDrawGroups = True
    End Sub

    Private Sub AttReportByHouresFixed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'gfgf
        LayoutControl1.AllowCustomization = False
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        '  Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)

        Me.DateEdit2.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt

        Me.KeyPreview = True

        GetSettings()

        'If Me.TextEditReportName.Text = 2 Then

        'End If
        If _FormType = "Dawam2" Then 'دوام حسب الساعة
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = "تقرير الدوام بالساعة"
            Else
                Me.Text = "Attendance By Hours"
            End If
            'gridBand9.Visible = True
            ColBonusHours.Visible = True
            ColBonusHours.Visible = False
            ColLeavesHours.Visible = False
            gridBand2.Visible = True
            SimpleButton3.Visible = False
            SimpleButtonAddVocations.Visible = False
            CheckShowDawamTab.Visible = False
            CheckEditRestTime.Visible = False
            CheckCalcVocationsAtOffDay.Visible = False
            CheckElapseOnVocation.Visible = False
            '   LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            'LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem13.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            '  LayoutControlVocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'ColGrossSalary.Visible = False
            ColDailyTransport.Visible = False
            Colpayment.Visible = False
            ColAdditions.Visible = False
            'ColSalaryPerHour.Visible = True
            'ColGrossSalary.Visible = True
            ColNetSalary.Visible = True
            ColNetSalaryNew.Visible = False
            ColMonthlySalary.Visible = False
            ColBonusHoursNIS.Visible = True
            ColAbsentDaysAmount.Visible = False
            ColLeavesHoursNIS.Visible = False
            gridBandRawateb.Visible = False
        Else
            MsgBox("Error No Defined Form Type")
        End If

        If GlobalVariables._SystemLanguage = "English" Then
            ColEnglishStatus.Visible = True
            ColAttStatus.Visible = False
        Else
            ColEnglishStatus.Visible = False
            ColAttStatus.Visible = True
        End If
        ColNetLeavesHouresDaily.Visible = False
        ColNetBonusHoures.Visible = False

        If GlobalVariables._ShowWorkLeavesData = False Then
            gridBandWorkLeaves.Visible = False
            LayoutControlShowWorkLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            gridBandTotalWorkDuration.Visible = False
        End If

        If GlobalVariables._EndDate < Today Then
            DateEdit2.Enabled = False
            DateEdit2.DateTime = GlobalVariables._EndDate
        End If

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

        Try
            SqlString = " select SettingValue From Settings where SettingName ='BonusOnDayOff'"
            sql.SqlTrueTimeRunQuery(SqlString)
            BonusOnDayOff = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            BonusOnDayOff = 1
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='TempForOpenForms'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _FormType = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _FormType = "0"
            XtraMessageBox.Show(ex.ToString)
        End Try

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
            ShowPrint()
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
        '  SplashScreenManager1.ShowWaitForm()
        '  SplashScreenManager1.SetWaitFormCaption("جاري تحضير بيانات التقرير...")

        GetSettings()

        Try
            Dim sql2 As New SQLControl
            Dim SqlString2 As String
            SqlString2 = " select SettingValue From Settings where SettingName ='DaysInMonth'"
            sql2.SqlTrueTimeRunQuery(SqlString2)
            If CStr(sql2.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = "DaysInMonth" Then
                DaysInMonth = DateTime.DaysInMonth(CDate(DateEdit1.DateTime).Year, CDate(DateEdit1.DateTime).Month)
            Else
                DaysInMonth = CDec(sql2.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            End If
        Catch ex As Exception
            DaysInMonth = 30
        End Try


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







        SQLString = " Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],
                              RequiredDailyHoures,OffDay1,OffDay2,SalaryPerHour,RestDailyHoures,BonusPerHour,BonusOnDayOff,Salary,
                              DailyTransport,SalaryAccountNo,SubtractionLeavesAndLates,AddBonusToSalary,
                              MaxLeavesHoures,ProcessType,DateOfStart,DateOfEnd,BonusPerHourAmount,
                              BonusPerHourAmountOption,MaxLeavesHouresDaily,MaxBonusHoures,[JobName],[Department],[Branch]
                      From    EmployeesData
                      where  (DontCheckInOut IS NULL OR DontCheckInOut=0) "


        If CheckEditCheckActive.Checked = True Then SQLString = SQLString + "and EmployeesData.Active = 1"
        If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
            'colEmployeeName.Visible = False
            CollEmployeeName.Visible = False
        Else
            'colEmployeeName.Visible = True
            CollEmployeeName.Visible = True
        End If
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"
        'If _FormType = "Dawam2" Or _FormType = "Rawateb2" Then
        '    SQLString += " And (ProcessType=3 or ProcessType is null )    "
        'Else
        '    SQLString += " And (ProcessType=2 or ProcessType is null )    "
        'End If


        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            MsgBox("لا يوجد حركات")
            ' SplashScreenManager1.CloseWaitForm()
            SplashScreenManager.CloseForm(False)
            Exit Sub
        End If

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
                If Not IsDBNull(EmployeesTable.Rows(j).Item("OffDay1")) Then
                    OffDay1 = EmployeesTable.Rows(j).Item("OffDay1")
                Else
                    OffDay1 = String.Empty
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("OffDay2")) Then
                    OffDay2 = EmployeesTable.Rows(j).Item("OffDay2")
                Else
                    OffDay2 = String.Empty
                End If

                If Not IsDBNull(EmployeesTable.Rows(j).Item("ProcessType")) Then
                    ProcessType = EmployeesTable.Rows(j).Item("ProcessType")
                End If

                If Not IsDBNull(EmployeesTable.Rows(j).Item("RequiredDailyHoures")) Then
                    RequiredDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
                Else
                    RequiredDailyHoures = TimeSpan.Zero
                End If

                If Not IsDBNull(EmployeesTable.Rows(j).Item("Salary")) Then
                    Salary = EmployeesTable.Rows(j).Item("Salary")
                Else
                    Salary = 0
                End If

                Select Case ProcessType
                    Case 2
                        If RequiredDailyHoures.TotalHours > 0 Then
                            SalaryPerHour = (Salary / (DaysInMonth * RequiredDailyHoures.TotalHours)).ToString("n2")
                        Else
                            SalaryPerHour = 0
                            XtraMessageBox.Show(" الموظف: " & EmployeeName & " لا يوجد تعريف لعدد الساعات المطلوبة ")
                        End If

                    Case 3
                        If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryPerHour")) Then
                            SalaryPerHour = EmployeesTable.Rows(j).Item("SalaryPerHour")
                        Else
                            SalaryPerHour = 0
                        End If
                End Select


                Select Case ProcessType
                    Case 2
                        If RequiredDailyHoures.TotalHours > 0 Then
                            SalaryPerDay = (Salary / (DaysInMonth)).ToString("n2")
                        Else
                            SalaryPerDay = 0
                            XtraMessageBox.Show(" الموظف: " & EmployeeName & " لا يوجد تعريف لعدد الساعات المطلوبة ")
                        End If
                    Case 3
                        SalaryPerDay = 0
                End Select






                If Not IsDBNull(EmployeesTable.Rows(j).Item("RestDailyHoures")) Then
                    RestDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RestDailyHoures"))
                Else
                    RestDailyHoures = TimeSpan.Zero
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHour")) Then
                    BonusPerHour = EmployeesTable.Rows(j).Item("BonusPerHour")
                Else
                    BonusPerHour = 1
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusOnDayOff")) Then
                    BonusOnDayOff = EmployeesTable.Rows(j).Item("BonusOnDayOff")
                Else
                    BonusOnDayOff = 1
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("DailyTransport")) Then
                    DailyTransport = EmployeesTable.Rows(j).Item("DailyTransport")
                Else
                    DailyTransport = 0
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryAccountNo")) Then
                    SalaryAccountNo = EmployeesTable.Rows(j).Item("SalaryAccountNo")
                End If

                If Not IsDBNull(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates")) Then
                    SubtractionLeavesAndLates = CBool(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates"))
                Else
                    SubtractionLeavesAndLates = True
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("AddBonusToSalary")) Then
                    AddBonusToSalary = CBool(EmployeesTable.Rows(j).Item("AddBonusToSalary"))
                Else
                    AddBonusToSalary = True
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("MaxLeavesHoures")) Then
                    MaxLeavesHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxLeavesHoures"))
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfStart")) Then
                    _DateOfStart = Format(CDate(EmployeesTable.Rows(j).Item("DateOfStart")), "yyyy-MM-dd")
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfEnd")) Then
                    _DateOfEnd = Format(CDate(EmployeesTable.Rows(j).Item("DateOfEnd")), "yyyy-MM-dd")
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHourAmount")) Then
                    _BonusPerHourAmount = (EmployeesTable.Rows(j).Item("BonusPerHourAmount"))
                Else
                    _BonusPerHourAmount = 0
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHourAmountOption")) Then
                    _BonusPerHourAmountOption = (EmployeesTable.Rows(j).Item("BonusPerHourAmountOption"))
                Else
                    _BonusPerHourAmountOption = False
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("MaxLeavesHouresDaily")) Then
                    _MaxLeavesHouresDaily = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxLeavesHouresDaily"))
                Else
                    _MaxLeavesHouresDaily = TimeSpan.Zero
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("MaxBonusHoures")) Then
                    _MaxBonusHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxBonusHoures"))
                Else
                    _MaxBonusHoures = TimeSpan.Zero
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
            End If
        Next
        Summery = True

        GridControl1.DataSource = DataTable

        '  AdvBandedGridView1.BestFitColumns()
        ' GridBand1.Width = GridControl1.Width / 2
        'If SearchLookUpEdit1.EditValue = 0 Or IsNothing(SearchLookUpEdit1.EditValue) Then
        '    ColEmpID.Visible = True
        '    CollEmployeeName.Visible = True
        'Else
        '    ColEmpID.Visible = False
        '    CollEmployeeName.Visible = False
        'End If

        '    AdvBandedGridView1.BestFitColumns()

        ' SplashScreenManager1.CloseWaitForm()
HH:
        SplashScreenManager.CloseForm(False)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
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
        '    If (SearchLookUpEdit1.EditValue = 0) Then MsgBox("الرجاء اختيار موظف") : Exit Sub

        '    Dim EmpID As String = SearchLookUpEdit1.EditValue



        Dim PlaneTable As New DataTable

        Dim ListDays As New DataTable


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


        ListDays.Columns.Add("StartTimeReal6", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal6", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal7", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal7", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal8", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal8", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal9", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal9", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal10", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal10", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal11", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal11", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal12", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal12", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal13", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal13", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal14", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal14", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal15", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal15", GetType(DateTime))

        ListDays.Columns.Add("Duration1", GetType(TimeSpan))
        ListDays.Columns.Add("Duration2", GetType(TimeSpan))
        ListDays.Columns.Add("Duration3", GetType(TimeSpan))
        ListDays.Columns.Add("Duration4", GetType(TimeSpan))
        ListDays.Columns.Add("Duration5", GetType(TimeSpan))

        ListDays.Columns.Add("Duration6", GetType(TimeSpan))
        ListDays.Columns.Add("Duration7", GetType(TimeSpan))
        ListDays.Columns.Add("Duration8", GetType(TimeSpan))
        ListDays.Columns.Add("Duration9", GetType(TimeSpan))
        ListDays.Columns.Add("Duration10", GetType(TimeSpan))

        ListDays.Columns.Add("Duration11", GetType(TimeSpan))
        ListDays.Columns.Add("Duration12", GetType(TimeSpan))
        ListDays.Columns.Add("Duration13", GetType(TimeSpan))
        ListDays.Columns.Add("Duration14", GetType(TimeSpan))
        ListDays.Columns.Add("Duration15", GetType(TimeSpan))




        ListDays.Columns.Add("TotalDurations", GetType(TimeSpan))
        ListDays.Columns.Add("AttStatus", GetType(String))
        ListDays.Columns.Add("Voc", GetType(Decimal))
        ListDays.Columns.Add("LeavesHours", GetType(TimeSpan))
        ListDays.Columns.Add("BonusHours", GetType(TimeSpan))
        ListDays.Columns.Add("NetDurations", GetType(TimeSpan))
        ListDays.Columns.Add("SalaryPerHour", GetType(Decimal))
        ListDays.Columns.Add("NetSalary", GetType(Decimal))
        ListDays.Columns.Add("BonusPerHour", GetType(Decimal))
        ListDays.Columns.Add("BonusOnDayOff", GetType(Decimal))

        ListDays.Columns.Add("MonthlySalary", GetType(Decimal))
        ListDays.Columns.Add("BonusHoursNIS", GetType(Decimal))
        ListDays.Columns.Add("LeavesHoursNIS", GetType(Decimal))
        ListDays.Columns.Add("Payment", GetType(Decimal))
        ListDays.Columns.Add("Additions", GetType(Decimal))
        ListDays.Columns.Add("DailyTransport", GetType(Decimal))
        ListDays.Columns.Add("SalaryAccountNo", GetType(String))
        ListDays.Columns.Add("MonthlySalaryPerDay", GetType(Decimal))

        ListDays.Columns.Add("AttendentDays", GetType(Integer))
        ListDays.Columns.Add("VocationDays", GetType(Decimal))
        ListDays.Columns.Add("OffDays", GetType(Integer))
        ListDays.Columns.Add("AbsentDays", GetType(Integer))

        ListDays.Columns.Add("AbsentDaysAmount", GetType(Decimal))
        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))
        ListDays.Columns.Add("EnglishStatus", GetType(String))
        ListDays.Columns.Add("GrossSalary", GetType(Decimal))
        ListDays.Columns.Add("NetLeavesHouresDaily", GetType(TimeSpan))
        ListDays.Columns.Add("NetBonusHoures", GetType(TimeSpan))
        ListDays.Columns.Add("VocationSource", GetType(String))


        If GlobalVariables._ShowWorkLeavesData = True Then
            ListDays.Columns.Add("StartLeaveWork1", GetType(DateTime))
            ListDays.Columns.Add("EndLeaveWork1", GetType(DateTime))
            ListDays.Columns.Add("DurationLeave1", GetType(TimeSpan))
            ListDays.Columns.Add("StartLeaveWork2", GetType(DateTime))
            ListDays.Columns.Add("EndLeaveWork2", GetType(DateTime))
            ListDays.Columns.Add("DurationLeave2", GetType(TimeSpan))
            ListDays.Columns.Add("StartLeaveWork3", GetType(DateTime))
            ListDays.Columns.Add("EndLeaveWork3", GetType(DateTime))
            ListDays.Columns.Add("DurationLeave3", GetType(TimeSpan))
            ListDays.Columns.Add("TotalDurationLeave", GetType(TimeSpan))

            ListDays.Columns.Add("WorkLeaveNote1", GetType(String))
            ListDays.Columns.Add("WorkLeaveNote2", GetType(String))
            ListDays.Columns.Add("WorkLeaveNote3", GetType(String))
        End If

        If _ShowEmployeeDetails = True Then
            ListDays.Columns.Add("JobName", GetType(String))
            ListDays.Columns.Add("Department", GetType(String))
            ListDays.Columns.Add("Branch", GetType(String))
        End If

        ListDays.Columns.Add("Note1", GetType(String))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        'Dim CurrDName As String = myCulture.Calendar.GetDayOfWeek(CurrD)
        'Dim CurrDName As String = CurrD.ToString("dddd", New CultureInfo("ar-AE"))


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




        '        Dim Sqla As New SQLControl
        '        Dim SqlStringa As String = "
        'DECLARE @MinDate DATE = '20140101',
        '        @MaxDate DATE = '20140131';

        'SELECT  TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
        '        TransDate = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),'' as TransDay,0 as PlaneID,'' as EmpID,
        '		'' as EmployeeName,0 as RequiredDailyHoures,'00:00' as RestDailyHoures,'00:00' as StartTimeReal,'00:00' as EndTimeReal,
        '		'00:00' as ElapseTime,'00:00' as ElapseTimePlane,0 as TransInID,0 as TransOutID,'' as EditedTypeIn,'' as EditedTypeOut,'00:00' StartTimeReal1,
        '		'00:00' as EndTimeReal1,'' as StartTimeReal2,'' as EndTimeReal2,'' as StartTimeReal3,'' as EndTimeReal3,'' as StartTimeReal4,'' as EndTimeReal4,
        '		'' as StartTimeReal5,'' as EndTimeReal5,'' as Duration1,'' as Duration2,'' as Duration3,'' as Duration4,'' as Duration5,'' as TotalDurations,
        '		'' as AttStatus,'' as Voc,'' as LeavesHours,'' as BonusHours,'' as NetDurations,'' as SalaryPerHour,'' as NetSalary,'' as BonusPerHour,
        '		'' as MonthlySalary,'' as BonusHoursNIS,'' as LeavesHoursNIS,'' as Payment,'' as Additions,'' as DailyTransport,'' as SalaryAccountNo,'' as MonthlySalaryPerDay,
        '		'' as AttendentDays,'' as VocationDays,'' as OffDays,'' as AbsentDays,'' as AbsentDaysAmount,'' as DateOfStart,'' as DateOfEnd,'' as EnglishStatus

        'FROM    sys.all_objects a
        '        CROSS JOIN sys.all_objects b; "
        '        Sqla.SqlLocalTrueTimeRunQuery(SqlStringa)
        '        ListDays = Sqla.SQLDS.Tables(0)

        ' ListDays.Merge(dt, True)

        'Return ListDays
        'Exit Function




        'While (CurrD < endP)
        '    CurrD = CurrD.AddDays(1)
        '    If GlobalVariables._SystemLanguage = "Arabic" Then
        '        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        '    Else
        '        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd"), PlaneID, EmpID, EmployeeName)
        '    End If
        'End While



        'If ToLocalAttTrans(DateEdit1.DateTime, DateEdit2.DateTime) = 0 Then

        'End If


        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        If _UseLocalDataBaseForReport = True Then
            myconnection = New SqlConnection(GlobalVariables.LocalAttCHECKINOUTConnectionString)
        Else
            myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        End If

        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader
        myconnection.Open()






        For i = 0 To ListDays.Rows.Count - 1
            ListDays.Rows(i).Item("BonusPerHour") = BonusPerHour
            ListDays.Rows(i).Item("BonusOnDayOff") = BonusOnDayOff
            ListDays.Rows(i).Item("RestDailyHoures") = RestDailyHoures
            If CheckEditRestTime.Checked = True Then
                ListDays.Rows(i).Item("RequiredDailyHoures") = RequiredDailyHoures - RestDailyHoures
            Else
                ListDays.Rows(i).Item("RequiredDailyHoures") = RequiredDailyHoures
            End If

            'If ProcessType = "3" Then
            '    ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero
            'End If

            Dim CurrentDateString As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd")
            If CurrentDateString = _DateOfStart Then
                ListDays.Rows(i).Item("DateOfStart") = "True"
            End If
            If CurrentDateString = _DateOfEnd Then
                ListDays.Rows(i).Item("DateOfEnd") = "True"
            End If

            ' ListDays.Rows(i).Item("MonthlySalary") = Salary


            Dim FromDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            Dim ToDate2 As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero
            Dim TotalDurationsSpan As TimeSpan = TimeSpan.Zero
            Dim TotalDurationLeave As TimeSpan = TimeSpan.Zero

            Dim GetTransAllCount As String = "0"
            Dim GetTransInCount As String = "0"
            Dim GetTransOutCount As String = "0"
            Dim _TransCount = GetTransCount(FromDate2, ToDate2, EmpID)
            GetTransAllCount = _TransCount.Item1
            GetTransInCount = _TransCount.Item2
            GetTransOutCount = _TransCount.Item3



            If GetTransInCount > 0 Then
                If GetTransInCount > 15 Then GetTransInCount = 15
                For j = 1 To CInt(GetTransInCount)
                    Try





                        Dim SQLString2 As String = "SELECT     Row, CHECKTIME AS CheckINTimes, USERID, CHECKTYPE, ID As CheckInID,EditedType,EditNote
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [AttCHECKINOUT] 
                                        where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
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
                            CheckOut = Format(CDate(CheckIn).AddHours(23.9999), "yyyy-MM-dd HH:mm")


                            Dim SQLString3 As String = " SELECT top 1 CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType,EditNote
                                                 FROM   [AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & "
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
                        If _UseLocalDataBaseForReport = True Then
                            sql.SqlLocalTrueTimeRunQuery(SQLString)
                        Else
                            sql.SqlTrueTimeRunQuery(SQLString)
                        End If

                        'MsgBox(TempOutID)
                        If TempOutID <> sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID") Then
                            If j > 1 Then
                                If IsDBNull(ListDays.Rows(i).Item("EndTimeReal" & j - 1)) Then
                                    ListDays.Rows(i).Item("EndTimeReal" & j - 1) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                                End If
                            Else
                                ListDays.Rows(i).Item("EndTimeReal" & (j)) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                            End If
                            'If ListDays.Rows(i).Item("EndTimeReal" & j - 1) = "" Then
                            '    ListDays.Rows(i).Item("EndTimeReal" & j - 1) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                            'Else
                            '    ListDays.Rows(i).Item("EndTimeReal" & (j)) = sql.SQLDS.Tables(0).Rows(0).Item("CheckINTimes")
                            'End If
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

            ' عرض مغادرات العمل 
            If GlobalVariables._ShowWorkLeavesData = True Then
                Dim GetleavesworkTransAllCount As String = "0"
                Dim GetleavesworkTransInCount As String = "0"
                Dim GetleavesworkTransOutCount As String = "0"
                Dim _TransleavesworkCount = GetTransCountforWorkLeaves(FromDate2, ToDate2, EmpID)
                GetleavesworkTransAllCount = _TransleavesworkCount.Item1
                GetleavesworkTransInCount = _TransleavesworkCount.Item2
                GetleavesworkTransOutCount = _TransleavesworkCount.Item3
                If GetleavesworkTransAllCount > 0 Then
                    For j = 1 To 3
                        Dim SQLString2 As String = "SELECT     Row, CHECKTIME AS CheckOutWorkLeave, USERID, CHECKTYPE, ID As CheckInID,EditedType,EditNote
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [AttCHECKINOUT] 
                                        where [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
                                        where row =" & j
                        mycommand = New SqlCommand(SQLString2, myconnection)
                        dr2 = mycommand.ExecuteReader
                        Try
                            If dr2.HasRows Then
                                dr2.Read()
                                ListDays.Rows(i).Item("StartLeaveWork" & j) = dr2.Item("CheckOutWorkLeave")
                                ListDays.Rows(i).Item("WorkLeaveNote" & j) = dr2.Item("EditNote")
                                dr2.Close()
                            Else
                                dr2.Close()
                            End If
                        Catch ex As Exception
                            dr2.Close()
                        End Try
                        Dim SQLString3 As String = "SELECT     Row, CHECKTIME AS CheckInWorkLeave, USERID, CHECKTYPE, ID As CheckInID,EditedType
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [AttCHECKINOUT] 
                                        where [CHECKTYPE]='i' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
                                        where row =" & j
                        mycommand = New SqlCommand(SQLString3, myconnection)
                        dr = mycommand.ExecuteReader
                        Try
                            If dr.HasRows Then
                                dr.Read()
                                ListDays.Rows(i).Item("EndLeaveWork" & j) = dr.Item("CheckInWorkLeave")
                                dr.Close()
                            Else
                                dr.Close()
                            End If
                        Catch ex As Exception
                            dr.Close()
                        End Try
                        If Not IsDBNull(ListDays.Rows(i).Item("StartLeaveWork" & j)) And Not IsDBNull(ListDays.Rows(i).Item("EndLeaveWork" & j)) Then
                            Dim StartJ, EndJ As DateTime
                            StartJ = CDate(ListDays.Rows(i).Item("StartLeaveWork" & j))
                            EndJ = CDate(ListDays.Rows(i).Item("EndLeaveWork" & j))
                            ListDays.Rows(i).Item("DurationLeave" & j) = EndJ.Subtract(StartJ)
                        End If

                        If Not IsDBNull(ListDays.Rows(i).Item("DurationLeave" & j)) Then
                            TotalDurationLeave += ListDays.Rows(i).Item("DurationLeave" & j)
                            ListDays.Rows(i).Item("TotalDurationLeave") = TotalDurationLeave
                        End If
                    Next j

                End If
            End If





            'تم نقلها الى هنا بسبب وجود خروج من اليوم الي قبل فانه يلغي الاحازة
            If GetTransAllCount > GetTransInCount + GetTransOutCount Then
                ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
            End If
            Dim _VocationName As String
            Dim VocationPaid As Boolean
            If _VocationsFound = True Then
                With GetVocID(Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd"), ListDays.Rows(i).Item("EmpID"))
                    ListDays.Rows(i).Item("Voc") = .Item1
                    ListDays.Rows(i).Item("AttStatus") = .Item2
                    VocationPaid = .Item3
                    _VocationName = .Item2
                    ListDays.Rows(i).Item("VocationSource") = .Item4
                    '  If ListDays.Rows(i).Item("AttStatus") = "سنوية" Then
                    If VocationPaid = True And ListDays.Rows(i).Item("VocationSource") = "vocation" Then
                        If CheckElapseOnVocation.Checked = True Then ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero
                    End If
                End With
            Else
                _VocationName = ""
                VocationPaid = False
                ListDays.Rows(i).Item("Voc") = "0"
                ListDays.Rows(i).Item("AttStatus") = "0"
                ListDays.Rows(i).Item("VocationSource") = " "
            End If


            Dim __RequiredDailyHoures As TimeSpan = ListDays.Rows(i).Item("RequiredDailyHoures")
            Dim _TotalDurations As TimeSpan = ListDays.Rows(i).Item("TotalDurations")
            'MsgBox(OffDay1)
            'MsgBox(Format(CDate(ListDays.Rows(i).Item("TransDate")).ToString("dddd", New CultureInfo("en-US"))))
            If OffDay1 = Format(CDate(ListDays.Rows(i).Item("TransDate")).ToString("dddd", New CultureInfo("en-US"))) Or
                   OffDay2 = Format(CDate(ListDays.Rows(i).Item("TransDate")).ToString("dddd", New CultureInfo("en-US"))) Then
                ListDays.Rows(i).Item("AttStatus") = "عطلة"
                ListDays.Rows(i).Item("OffDays") = "1"
                ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero




                ' اتوقع يجب الغائها 
                ' تم ايقاف الكود بتاريخ 03/09/2022
                'If ProcessType = 2 Then
                '    If ListDays.Rows(i).Item("Voc") = "0" And CDate(CurrentDateString) < CDate(_DateOfStart) Then
                '        ListDays.Rows(i).Item("AttStatus") = "غياب"
                '        ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerHour * __RequiredDailyHoures.TotalHours
                '    End If
                '    If CDate(CurrentDateString) > CDate(_DateOfEnd) And CDate(_DateOfEnd) <> CDate("1900-01-01") And ListDays.Rows(i).Item("AttStatus") <> "عطلة" Then
                '        ListDays.Rows(i).Item("AttStatus") = "غياب"
                '        ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerHour * __RequiredDailyHoures.TotalHours
                '    End If
                'End If



                If ListDays.Rows(i).Item("OffDays") = "1" And ListDays.Rows(i).Item("Voc") = "1" Then
                    Select Case CheckCalcVocationsAtOffDay.EditValue
                        Case True
                            ListDays.Rows(i).Item("Voc") = "1"
                            ListDays.Rows(i).Item("OffDays") = "0"
                            ListDays.Rows(i).Item("AttStatus") = _VocationName
                        Case False
                            ListDays.Rows(i).Item("Voc") = "0"
                            ListDays.Rows(i).Item("OffDays") = "1"
                            ListDays.Rows(i).Item("AttStatus") = "عطلة"
                    End Select
                End If


            End If

            ' خصم الاستراحة من مجموع ألدوام اذا كان نوع الراتب بالساعة
            If ProcessType = 3 And CheckEditRestTime.Checked = True Then
                If _TotalDurations.TotalHours > 1 Then
                    ListDays.Rows(i).Item("TotalDurations") = TotalDurationsSpan - RestDailyHoures
                End If
            End If


            Try
                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) AndAlso Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                If (IsDBNull(ListDays.Rows(i).Item("EndTimeReal1")) AndAlso Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal1"))) Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) _
                        And IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) _
                        And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures")) _
                        And ListDays.Rows(i).Item("Voc") <> 1 _
                        And ListDays.Rows(i).Item("AttStatus") <> "عطلة" Then
                    ListDays.Rows(i).Item("AttStatus") = "غياب"
                End If

                'تم نقلها الى اعلى
                'If GetTransAllCount > GetTransInCount + GetTransOutCount Then
                '    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                'End If

                ' 12/05/2020 لا تظهر خطا بصمةعند وجود جكو حوج  فقط ل>لك تم تغقيل الكود التالي
                '  ListDays.Rows(i).Item("AttStatus") <> "عطلة" 20210126
                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) _
                And (Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures"))) And
                ListDays.Rows(i).Item("Voc") <> 1 And ListDays.Rows(i).Item("AttStatus") <> "عطلة" _
               Then
                    ListDays.Rows(i).Item("AttStatus") = "غياب"

                End If

                ' حل مشكلة ظهر غياب مع انه في حركة خروج 
                If Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal2")) AndAlso IsDBNull(ListDays.Rows(i).Item("StartTimeReal2")) Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And (Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal1"))) And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures"))) Then
                    ListDays.Rows(i).Item("AttStatus") = "دوام"
                End If

                Dim DiffHoureSpan As TimeSpan
                DiffHoureSpan = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")
                If DiffHoureSpan > TimeSpan.Zero Then
                    ListDays.Rows(i).Item("BonusHours") = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")
                    '  ListDays.Rows(i).Item("NetDurations") = ListDays.Rows(i).Item("TotalDurations") + ListDays.Rows(i).Item("BonusHours") - ListDays.Rows(i).Item("RestDailyHoures")
                ElseIf DiffHoureSpan < TimeSpan.Zero Then
                    If DiffHoureSpan = -ListDays.Rows(i).Item("RequiredDailyHoures") Then
                        ListDays.Rows(i).Item("LeavesHours") = TimeSpan.Zero
                        ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                        If VocationPaid = True And ListDays.Rows(i).Item("VocationSource") = "vocation" Then
                            ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                        Else
                            ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerHour * ListDays.Rows(i).Item("RequiredDailyHoures").TotalHours
                        End If


                    Else
                        ListDays.Rows(i).Item("LeavesHours") = ListDays.Rows(i).Item("RequiredDailyHoures") - ListDays.Rows(i).Item("TotalDurations")
                        Dim LeavesHours As TimeSpan = ListDays.Rows(i).Item("LeavesHours")
                        ListDays.Rows(i).Item("LeavesHoursNIS") = SalaryPerHour * LeavesHours.TotalHours
                    End If


                    '  ListDays.Rows(i).Item("NetDurations") = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("LeavesHours") - ListDays.Rows(i).Item("RestDailyHoures")

                    If SubtractionLeavesAndLates = False Then
                        ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                    End If

                ElseIf DiffHoureSpan = TimeSpan.Zero Then
                    ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
                End If

                'ادا نوع الاحتساب حسب الساعة فلا معنى باحتساب المغادرات
                If ProcessType = 3 Then
                    ListDays.Rows(i).Item("LeavesHours") = TimeSpan.Zero
                    ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                End If

                ' اضافة عمود لمعالجة المغاردات بشكل يومي
                If CheckShowColNetLeavesHouresDaily.Checked = True Then
                    If ProcessType <> 3 Then
                        If Not IsDBNull(ListDays.Rows(i).Item("LeavesHours")) And ListDays.Rows(i).Item("TotalDurations") <> TimeSpan.Zero Then
                            Dim _LeavesHours As TimeSpan
                            _LeavesHours = ListDays.Rows(i).Item("LeavesHours")
                            ListDays.Rows(i).Item("NetLeavesHouresDaily") = _LeavesHours - _MaxLeavesHouresDaily
                            Dim sql As New SQLControl
                            Dim _ProcessedHours As TimeSpan
                            Dim _HoursFactors As Decimal
                            sql.SqlTrueTimeRunQuery(" Select ProcessType,HoursFactors,ProcessedHours 
                                                  From [dbo].[AttLeavesProcess] 
                                                  Where [ProcessDate]='" & Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & "' 
                                                        And [EmployeeID]= " & EmpID)
                            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("HoursFactors")) Then
                                    _HoursFactors = sql.SQLDS.Tables(0).Rows(0).Item("HoursFactors")
                                End If

                                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ProcessedHours")) Then
                                    _ProcessedHours = TimeSpan.Parse(sql.SQLDS.Tables(0).Rows(0).Item("ProcessedHours"))
                                    If _HoursFactors = 1 Then
                                        ListDays.Rows(i).Item("NetLeavesHouresDaily") = ListDays.Rows(i).Item("NetLeavesHouresDaily") - _ProcessedHours
                                    Else
                                        ListDays.Rows(i).Item("NetLeavesHouresDaily") = ListDays.Rows(i).Item("NetLeavesHouresDaily") + _ProcessedHours
                                    End If

                                End If
                            End If

                        End If
                    End If
                End If

                'اظهار عمود التجاوز في الحد الاقصى للبونص
                If CheckShowColMaxBonusHoures.Checked = True Then
                    Dim _emptimespambonus As TimeSpan
                    If ProcessType <> 3 Then
                        If Not IsDBNull(ListDays.Rows(i).Item("BonusHours")) And ListDays.Rows(i).Item("TotalDurations") <> TimeSpan.Zero Then
                            Dim _BonusHours As TimeSpan
                            _BonusHours = ListDays.Rows(i).Item("BonusHours")
                            If _BonusHours > TimeSpan.Zero And _BonusHours.TotalMinutes > _MaxBonusHoures.TotalMinutes Then
                                _emptimespambonus = TimeSpan.FromMinutes(_BonusHours.TotalMinutes - _MaxBonusHoures.TotalMinutes)
                                ListDays.Rows(i).Item("NetBonusHoures") = _emptimespambonus
                            Else
                                ListDays.Rows(i).Item("NetBonusHoures") = TimeSpan.Zero
                            End If
                        Else
                            ListDays.Rows(i).Item("NetBonusHoures") = TimeSpan.Zero
                        End If
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try



            If ListDays.Rows(i).Item("AttStatus") = "غياب" And ProcessType = "4" Then
                ListDays.Rows(i).Item("AbsentDaysAmount") = 0.00
            End If
            'لا داعي لحساب الغياب ادا كان نوع الاحتساب الراتب حسب الساعة
            If ProcessType = "3" Then
                ListDays.Rows(i).Item("AbsentDaysAmount") = 0
            End If
            If ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" And ProcessType = "5" Then
                ListDays.Rows(i).Item("AbsentDaysAmount") = 0.00
                ListDays.Rows(i).Item("AttStatus") = "دوام"
            End If


            Dim BonusHoures As TimeSpan
            If IsDBNull(ListDays.Rows(i).Item("BonusHours")) Then
                BonusHoures = TimeSpan.Zero
            Else
                BonusHoures = ListDays.Rows(i).Item("BonusHours")
            End If


            'If ProcessType = "3" Then
            '    BonusHoures = TimeSpan.Zero
            '    ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
            'End If

            'If ProcessType = 2 Then
            '    If CDate(CurrentDateString) < CDate(_DateOfStart) Then

            '    End If
            'End If

            '--------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------
            ' اتوقع هنا يتم احتساب الرواتب
            '--------------------------------------------------------------------------------------------------
            '--------------------------------------------------------------------------------------------------


            ListDays.Rows(i).Item("SalaryPerHour") = SalaryPerHour

            'حساب المواصلات اليومية
            If ListDays.Rows(i).Item("AttStatus") <> "دوام" Then
                ListDays.Rows(i).Item("DailyTransport") = 0
            End If
            If ListDays.Rows(i).Item("AttStatus") = "دوام" Then
                ListDays.Rows(i).Item("DailyTransport") = DailyTransport
            End If
            If ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" And ProcessType = "5" Then
                ListDays.Rows(i).Item("DailyTransport") = DailyTransport
            End If
            If ListDays.Rows(i).Item("AttStatus") = "غياب" And ProcessType = "4" Then
                ListDays.Rows(i).Item("DailyTransport") = DailyTransport
            End If

            ListDays.Rows(i).Item("SalaryAccountNo") = SalaryAccountNo
            If _PaymentFound = True Then
                ListDays.Rows(i).Item("Payment") = GetPayment(ListDays.Rows(i).Item("EmpID").ToString, Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd").ToString)
            Else
                ListDays.Rows(i).Item("Payment") = 0
            End If
            If _AdditionsFound = True Then
                ListDays.Rows(i).Item("Additions") = GetAdditions(ListDays.Rows(i).Item("EmpID").ToString,
                                                                  Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd").ToString)
            Else
                ListDays.Rows(i).Item("Additions") = 0
            End If

            Dim Payment As Decimal = 0
            If IsDBNull(ListDays.Rows(i).Item("Payment")) Then
                Payment = 0
            Else
                Payment = ListDays.Rows(i).Item("Payment")
            End If

            Dim Additions As Decimal = 0
            If IsDBNull(ListDays.Rows(i).Item("Additions")) Then
                Additions = 0
            Else
                Additions = ListDays.Rows(i).Item("Additions")
            End If
            Dim TotalDurations As TimeSpan = TimeSpan.Zero
            Dim NetSalaryTemp As Decimal = 0.00
            If ListDays.Rows(i).Item("TotalDurations") > TimeSpan.Zero Then


                TotalDurations = ListDays.Rows(i).Item("TotalDurations") - BonusHoures

                If ProcessType = 3 Then
                    ListDays.Rows(i).Item("GrossSalary") = ListDays.Rows(i).Item("SalaryPerHour") * TotalDurations.TotalHours
                End If

                If ProcessType = 2 Then
                    ListDays.Rows(i).Item("MonthlySalaryPerDay") = SalaryPerDay
                End If
                If ProcessType = 3 Then
                    ListDays.Rows(i).Item("MonthlySalaryPerDay") = ListDays.Rows(i).Item("SalaryPerHour") * TotalDurations.TotalHours
                End If

                ' Calc Bonus Amount
                If _BonusPerHourAmountOption = False Then
                    If ListDays.Rows(i).Item("RequiredDailyHoures") = TimeSpan.Zero Then
                        ListDays.Rows(i).Item("BonusHoursNIS") = SalaryPerHour * BonusOnDayOff * BonusHoures.TotalHours
                    Else
                        ListDays.Rows(i).Item("BonusHoursNIS") = SalaryPerHour * BonusPerHour * BonusHoures.TotalHours
                    End If
                Else
                    ListDays.Rows(i).Item("BonusHoursNIS") = _BonusPerHourAmount * BonusHoures.TotalHours
                End If


                ListDays.Rows(i).Item("BonusHoursNIS") = Format(ListDays.Rows(i).Item("BonusHoursNIS"), "n2")

                If AddBonusToSalary = False Then ListDays.Rows(i).Item("BonusHoursNIS") = 0.00

                If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures"))) And ListDays.Rows(i).Item("AttStatus") = "عطلة" Then
                    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                    '  ListDays.Rows(i).Item("BonusHoursNIS") =
                    'BonusHoursNIS = BonusHoursNIS + BonusOnDayOff *
                End If

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

                Dim AbsentDaysAmount As Decimal = 0.00
                If IsDBNull(ListDays.Rows(i).Item("AbsentDaysAmount")) Then
                    AbsentDaysAmount = 0.00
                Else
                    AbsentDaysAmount = ListDays.Rows(i).Item("AbsentDaysAmount")
                End If




                'If IsDBNull(ListDays.Rows(i).Item("MonthlySalaryPerDay")) Then
                '    SalaryPerDay = 0
                'Else
                '    SalaryPerDay = ListDays.Rows(i).Item("MonthlySalaryPerDay")
                'End If

                'ادا نوع الاحتساب حسب الساعة فلا معنى باحتساب الاضافي
                'If ProcessType = 3 Then
                '    ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
                '    ListDays.Rows(i).Item("BonusHoursNIS") = 0
                'End If


                ''   ListDays.Rows(i).Item("NetSalary") = SalaryPerDay + BonusHoursNIS - LeavesHoursNIS - AbsentDaysAmount + DailyTransport - Payment + Additions

                'ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) + SalaryPerHour * BonusPerHour * BonusHoures.TotalHours
                'ListDays.Rows(i).Item("NetSalary") = Format(ListDays.Rows(i).Item("NetSalary"), "n1")

                'ListDays.Rows(i).Item("LeavesHoursNIS") = (ListDays.Rows(i).Item("LeavesHours")) * SalaryPerHour
                ''''''
                '  If ProcessType = "3" Then
                '    ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) _
                '     - Payment + Additions + DailyTransport
                '  Else
                ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) _
                                                          + CDec(ListDays.Rows(i).Item("BonusHoursNIS")) - Payment _
                                                          - LeavesHoursNIS - AbsentDaysAmount + Additions + DailyTransport
                '   End If




                ListDays.Rows(i).Item("NetSalary") = Format(ListDays.Rows(i).Item("NetSalary"), "n1")

            ElseIf ListDays.Rows(i).Item("TotalDurations") = TimeSpan.Zero Then


                If ListDays.Rows(i).Item("AttStatus") = "عطلة" Or VocationPaid = True Then
                    Dim MonthlySalaryPerDay As Decimal = 0.00
                    Dim BonusHoursNIS As Decimal = 0.00
                    Dim LeavesHoursNIS As Decimal = 0.00
                    Dim AbsentDaysAmount As Decimal = 0.00
                    'Dim Payment2 As Integer = 0
                    'Dim Additions2 As Integer = 0
                    If Not IsDBNull(ListDays.Rows(i).Item("MonthlySalaryPerDay")) Then MonthlySalaryPerDay = ListDays.Rows(i).Item("MonthlySalaryPerDay")
                    If Not IsDBNull(ListDays.Rows(i).Item("BonusHoursNIS")) Then BonusHoursNIS = ListDays.Rows(i).Item("BonusHoursNIS")
                    If Not IsDBNull(ListDays.Rows(i).Item("LeavesHoursNIS")) Then LeavesHoursNIS = ListDays.Rows(i).Item("LeavesHoursNIS")
                    If Not IsDBNull(ListDays.Rows(i).Item("AbsentDaysAmount")) Then AbsentDaysAmount = ListDays.Rows(i).Item("AbsentDaysAmount")
                    If Not IsDBNull(ListDays.Rows(i).Item("Payment")) Then Payment = ListDays.Rows(i).Item("Payment")
                    If Not IsDBNull(ListDays.Rows(i).Item("Additions")) Then Additions = ListDays.Rows(i).Item("Additions")

                    ListDays.Rows(i).Item("NetSalary") = MonthlySalaryPerDay - Payment + Additions
                Else
                    ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) _
                                                              + SalaryPerHour * BonusPerHour * BonusHoures.TotalHours - Payment _
                                                              - 0 - 0 + Additions + DailyTransport
                End If
                ''يوم العطلة لا يوجد راتب ادا كانت طريقة احتساب الراتب حسب الساعة
                'If ProcessType = "3" Then
                '    ListDays.Rows(i).Item("NetSalary") = 0
                'End If
            End If


            If ListDays.Rows(i).Item("AttStatus") = "دوام" Then ListDays.Rows(i).Item("AttendentDays") = 1
            If ListDays.Rows(i).Item("AttStatus") = "سنوية" Then ListDays.Rows(i).Item("VocationDays") = 1
            '      If ListDays.Rows(i).Item("AttStatus") = "عطلة" Then ListDays.Rows(i).Item("OffDays") = 1
            If ListDays.Rows(i).Item("AttStatus") = "غياب" Then ListDays.Rows(i).Item("AbsentDays") = 1

            'If Not IsDBNull(ListDays.Rows(i).Item("VocationSource")) Then
            '    If ListDays.Rows(i).Item("VocationSource") = "leaves" Then
            '        ListDays.Rows(i).Item("BonusHoursNIS") = 0
            '        ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
            '    End If
            'End If

            If _ShowEmployeeDetails = True Then
                ListDays.Rows(i).Item("Department") = Department
                ListDays.Rows(i).Item("JobName") = JobName
                ListDays.Rows(i).Item("Branch") = Branch
            End If

            If GlobalVariables._SystemLanguage = "English" Then
                Select Case ListDays.Rows(i).Item("AttStatus")
                    Case "دوام"
                        ListDays.Rows(i).Item("EnglishStatus") = "Attendance"
                    Case "عطلة"
                        ListDays.Rows(i).Item("EnglishStatus") = "Holidays"
                    Case "غياب"
                        ListDays.Rows(i).Item("EnglishStatus") = "Absents"
                    Case "خطا بصمة"
                        ListDays.Rows(i).Item("EnglishStatus") = "Trans. Error"
                End Select
            End If


            If ListDays.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (ListDays.Rows.Count)) & "%" &
                                                                                   " " & _CurrentEmployeeHandle & " From " & _EmployeesCount)
        Next

        '    myconnection.Close()


        QueryData = ListDays



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

            'Dim i As Integer
            'For i = 0 To SpinEdit1.Text
            '    Me.LeaveBand1.Visible = True
            'Next






            '  If SpinEdit1.Text = 3 Then Me.LeaveBand1.Visible = False : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 1 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 2 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 3 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 4 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = False : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 5 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = False : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 6 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = False : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 7 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = False : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 8 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = False : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 9 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = False : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 10 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = False : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 11 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = True : Me.LeaveBand12.Visible = False : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 12 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = True : Me.LeaveBand12.Visible = True : Me.LeaveBand13.Visible = False : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 13 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = True : Me.LeaveBand12.Visible = True : Me.LeaveBand13.Visible = True : Me.LeaveBand14.Visible = False : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 14 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = True : Me.LeaveBand12.Visible = True : Me.LeaveBand13.Visible = True : Me.LeaveBand14.Visible = True : Me.LeaveBand15.Visible = False
            If SpinEdit1.Text = 15 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True : Me.LeaveBand6.Visible = True : Me.LeaveBand7.Visible = True : Me.LeaveBand8.Visible = True : Me.LeaveBand9.Visible = True : Me.LeaveBand10.Visible = True : Me.LeaveBand11.Visible = True : Me.LeaveBand12.Visible = True : Me.LeaveBand13.Visible = True : Me.LeaveBand14.Visible = True : Me.LeaveBand15.Visible = True


            Using g = GridControl1.CreateGraphics()
                For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In AdvBandedGridView1.Bands
                    band.MinWidth = CInt(g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width)
                Next
            End Using
            AdvBandedGridView1.BestFitColumns()
        End If
    End Sub


    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawCell

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

        ' تم تعطيله بتاريخ 09072021
        '        For j As Integer = 1 To 5
        '            If e.Column.FieldName = "EndTimeReal" & j Or e.Column.FieldName = "StartTimeReal" & j Then
        '                Dim category1 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal" & j))
        '                Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal" & j))
        '                Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("RequiredDailyHoures"))

        '                If category1 = String.Empty And category2 = String.Empty Then GoTo eend3
        '                If (category1 = String.Empty Or category2 = String.Empty) And category3 <> String.Empty Then
        '                    e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '                    ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '                    '  e.DisplayText = "..."
        '                    e.Appearance.Options.CancelUpdate()
        'eend3:          End If
        '            End If
        '        Next



        If e.Column.FieldName = "StartTimeReal1" Then
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal1"))
            Dim _AttStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AttStatus"))
            Dim _AbsentDays As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AbsentDays"))
            If category2 = String.Empty And (_AbsentDays = "1" Or _AttStatus = "خطا بصمة") Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                '  e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '   e.DisplayText = "انقر للتعديل"
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        If e.Column.FieldName = "EndTimeReal1" Then
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal1"))
            Dim _AttStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AttStatus"))
            Dim _AbsentDays As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AbsentDays"))
            If category2 = String.Empty And (_AbsentDays = "1" Or _AttStatus = "خطا بصمة") Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '  e.DisplayText = "..."
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        'If e.Column.FieldName = "TotalDurations" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal1"))
        '    Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal1"))
        '    If (category2 = String.Empty Or category = String.Empty) Then
        '        e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '        ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '        '  e.DisplayText = "..."
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If
    End Sub


    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles AdvBandedGridView1.PrintInitialize

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
            Dim _VocationBalances = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Me.DateEdit2.DateTime)
            _VocationString = " رصيد أول الفترة: " & _VocationBalances.BeginingBalance & "  " & vbCrLf &
            " اجازات مستوفاه خلال السنة : " & _VocationBalances.ThisYearVocations & "  " & vbCrLf &
            " رصيد الاجازات لنهاية العام : " & _VocationBalances.Balance & "  " & vbCrLf &
            " رصيد الاجازات لتاريخ اليوم : " & _VocationBalances.AccruedVocations & "  "
            Tawqe3 = _VocationString
            Tawqe3_2 = " .................:توقيع الموظف" & "  " & vbCrLf & " .................:توقيع الادارة "
        End If



        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)


        If SearchLookUpEdit1.Text <> String.Empty Or IsDBNull(SearchLookUpEdit1.EditValue) Or CStr(SearchLookUpEdit1.EditValue) IsNot Nothing Or CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة : " & SearchLookUpEdit1.Text & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
        Else
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة " & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
        End If

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



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
                ElseIf summaryID = 100 Or summaryID = 200 Then
                    If AdvBandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "عطلة" Then
                        e.TotalValue = e.TotalValue + 1
                        'Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"))
                    End If
                ElseIf summaryID = 101 Then
                    If AdvBandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "غياب" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                ElseIf summaryID = 102 Then
                    If AdvBandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "دوام" Then
                        e.TotalValue = e.TotalValue + 1
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
                    e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))
                End If

                'If summaryID = 50 Then
                '    e.TotalValue = CDec(ColBonusHours.SummaryItem.SummaryValue / ColTransDay.SummaryItem.SummaryValue)
                'End If

                If summaryID = 17001 Then
                    '  e.TotalValue = GetEmpSalary(AdvBandedGridView1.GetRowCellValue(e.RowHandle, "EmpID"))
                    e.TotalValue = Salary
                End If

                If summaryID = 15001 Then
                    e.TotalValue = ColMonthlySalary.SummaryItem.SummaryValue _
                                                 + ColDailyTransport.SummaryItem.SummaryValue _
                                                 + ColBonusHoursNIS.SummaryItem.SummaryValue _
                                                 - Colpayment.SummaryItem.SummaryValue _
                                                 + ColAdditions.SummaryItem.SummaryValue _
                                                 - ColLeavesHoursNIS.SummaryItem.SummaryValue _
                                                 - ColAbsentDaysAmount.SummaryItem.SummaryValue

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
    Private Function GetEmpSalary(EmpId As String) As Decimal

        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " Select Salary from EmployeesData where EmployeeID ='" & EmpId & "'"
            Sql.SqlTrueTimeRunQuery(SqlString)
            Return CDec(Sql.SQLDS.Tables(0).Rows(0).Item("Salary"))
        Catch ex As Exception
            Return 0
        End Try


    End Function
    Private Sub ShowPrint()

        If GridControl1.IsPrintingAvailable = False Then Exit Sub

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If AdvBandedGridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
        Else
            If AdvBandedGridView1.RowCount = 0 Then MsgBox("Empty Report ") : Exit Sub
        End If


        '  AdvBandedGridView1.OptionsPrint.PrintDetails = False
        AdvBandedGridView1.OptionsPrint.ExpandAllGroups = False
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButtonInsertAttTrans_Click(sender As Object, e As EventArgs)
        InsertSub()
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
        Try
            'My.Forms.AddVocation.FromFrom.Text = Me.Text
            If String.IsNullOrWhiteSpace(AdvBandedGridView1.GetFocusedRowCellValue("EmpID")) Then
                My.Forms.AddVocation.LookUpEditEmployees.EditValue = SearchLookUpEdit1.EditValue
                My.Forms.AddVocation.DateEditTo.DateTime = Today
                My.Forms.AddVocation.DateEditFrom.DateTime = Today
                My.Forms.AddVocation.TextVocationDate.DateTime = Today
            Else
                My.Forms.AddVocation.LookUpEditEmployees.EditValue = AdvBandedGridView1.GetFocusedRowCellValue("EmpID")
                My.Forms.AddVocation.DateEditTo.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
                My.Forms.AddVocation.DateEditFrom.DateTime = AdvBandedGridView1.GetFocusedRowCellValue("TransDate")
                My.Forms.AddVocation.TextVocationDate.DateTime = Today
            End If
            AddVocation.TextID.EditValue = GetMaxVocationID() + 1
            AddVocation.TextNewOrOld.EditValue = -1
            AddVocation.Show()
            My.Forms.AddVocation.MemoDetails.Select()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        AdvBandedGridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        AdvBandedGridView1.OptionsView.AllowHtmlDrawGroups = True
        AdvBandedGridView1.OptionsView.ShowFooter = True

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

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        MsgBox(AdvBandedGridView1.GetFocusedRowCellValue("StartTimeReal1"))
    End Sub

    'Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles AdvBandedGridView1.RowLoaded
    '    AdvBandedGridView1.BestFitColumns()
    '    '  AdvBandedGridView1.Bands.ba

    'End Sub

    'Private Function GetTransInCount(DateTimeFrom As String, DateTimeTo As String, EmpID As String) As Integer

    '    Try
    '        Dim SqlString As String
    '        Dim Sql As New SQLControl
    '        SqlString = "   Select count([ID]) as TransCount 
    '                        From [AttCHECKINOUT]
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
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'"
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & Format(CDate(DateTimeTo).AddHours(5), "yyyy-MM-dd HH:mm") & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS"
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
    Private Function GetTransCountforWorkLeaves(DateTimeFrom As String, DateTimeTo As String, EmpID As String) As Tuple(Of String, String, String)
        Dim GetTransAllCount As String = "0"
        Dim GetTransInCount As String = "0"
        Dim GetTransOutCount As String = "0"

        Dim SqlString As String

        Try
            Dim sql As New SQLControl
            SqlString = "   Select count([ID]) as TransAllCount 
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "' and ([CHECKTYPE]='i' COLLATE Latin1_General_CS_AS or [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS)"
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & DateTimeTo & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='i' COLLATE Latin1_General_CS_AS "
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
                            From [AttCHECKINOUT]
                            Where [CHECKTIME] between '" & DateTimeFrom & "' and '" & Format(CDate(DateTimeTo).AddHours(5), "yyyy-MM-dd HH:mm") & "' and [USERID] ='" & EmpID & "'
                            and [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS"
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
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
            AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            AdvBandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        AdvBandedGridView1.BestFitColumns()
    End Sub
    Private Function GetPayment(EmployeeID As String, TransDate As String) As Decimal
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = "  select SUM(PaymentAmount) as payment FROM [AttEmployeePayments] where [Status]=1 And [EmployeeID]='" & EmployeeID & "' and [PaymentDate] ='" & TransDate & "'"
            sql.SqlTrueTimeRunQuery(SelectString)
            Return CDec(sql.SQLDS.Tables(0).Rows(0).Item("payment"))
        Catch ex As Exception
            Return 0
        End Try
    End Function



    Private Function GetAdditions(EmployeeID As String, TransDate As String) As Decimal
        Try
            Dim sql As New SQLControl
            Dim SelectString As String = "  select SUM(AdditionAmount) as Addition FROM [AttEmployeeAdditions] where [EmployeeID]='" & EmployeeID & "' and [AdditionDate] ='" & TransDate & "'"
            sql.SqlTrueTimeRunQuery(SelectString)
            Return CDec(sql.SQLDS.Tables(0).Rows(0).Item("Addition"))
        Catch ex As Exception
            Return 0
        End Try
    End Function




    Private Function GetSumVocationsThisYear(EmpID As String, VocType As String) As String
        Dim sql As New SQLControl
        GetSumVocationsThisYear = 0
        Try
            If EmpID IsNot Nothing Then
                Dim SqlString As String = "Select Sum(NoDays) as SumDays from Vocations where EmployeeID =  '" & EmpID & "'
                    And VocationType ='" & VocType & "' and year(FromDate) = '" & DateEdit1.DateTime.Year.ToString & "'"

                sql.SqlTrueTimeRunQuery(SqlString)

                If sql.SQLDS.Tables(0).Rows(0).Item("SumDays") Is DBNull.Value Then
                    GetSumVocationsThisYear = 0
                Else
                    GetSumVocationsThisYear = sql.SQLDS.Tables(0).Rows(0).Item("SumDays").ToString
                End If



            End If

        Catch ex As Exception
            GetSumVocationsThisYear = 0
        End Try

    End Function

    Private Function GetBeginingBalance(EmpID As String) As String
        Dim sql As New SQLControl
        GetBeginingBalance = 0
        Try
            If EmpID IsNot Nothing Then
                Dim SqlString As String = "Select VocationBeginingBalance from [EmployeesData] where EmployeeID =  '" & EmpID & "'"

                sql.SqlTrueTimeRunQuery(SqlString)

                If sql.SQLDS.Tables(0).Rows(0).Item("VocationBeginingBalance") Is DBNull.Value Then
                    GetBeginingBalance = 0
                Else
                    GetBeginingBalance = sql.SQLDS.Tables(0).Rows(0).Item("VocationBeginingBalance").ToString
                End If



            End If

        Catch ex As Exception
            GetBeginingBalance = 0
        End Try

    End Function

    Private Function VocationAtEndYear(EmpID As String) As Integer
        Dim sql As New SQLControl
        VocationAtEndYear = 0
        Try
            If EmpID IsNot Nothing Then
                Dim SqlString As String = "Select VocationsLimit from [EmployeesData] where EmployeeID =  '" & EmpID & "'"

                sql.SqlTrueTimeRunQuery(SqlString)

                If sql.SQLDS.Tables(0).Rows(0).Item("VocationsLimit") Is DBNull.Value Then
                    VocationAtEndYear = 0
                Else
                    VocationAtEndYear = sql.SQLDS.Tables(0).Rows(0).Item("VocationsLimit").ToString

                End If



            End If

        Catch ex As Exception
            VocationAtEndYear = 0
        End Try

    End Function





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
            With GetEmpData(Me.SearchLookUpEdit1.EditValue)
                report.Parameters("JobName").Value = .Item2
                report.Parameters("Department").Value = .Item3
                report.Parameters("Branch").Value = .Item4
                report.Parameters("EmployeeNoAsAcc").Value = .Item5
                Try
                    report.Parameters("BeginDate").Value = Format(CDate(.Item6), "dd/MM/yyyy")
                Catch ex As Exception
                    report.Parameters("BeginDate").Value = Format(CDate("1900-01-01"), "dd/MM/yyyy")
                End Try
                report.Parameters("Currency").Value = .Item7
            End With


            Try
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select [BankName] ,[BankNo] ,[BankBranch] ,[IBAN],[Indenty],ProcessType
                              from EmployeesData
                              where EmployeeID='" & CStr(SearchLookUpEdit1.EditValue) & "'"
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
                        Case 4
                            report.XrLabelProcessTypeWords.Text = "دوام بوجود حركة"
                    End Select
                    report.ProcessType.Value = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType"))
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            With report
                .Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
                .Parameters("SalaryMonth").Value = ColMonthlySalary.SummaryItem.SummaryValue
                .Parameters("BonusAmount").Value = ColBonusHoursNIS.SummaryItem.SummaryValue
                .Parameters("Transport").Value = ColDailyTransport.SummaryItem.SummaryValue
                .Parameters("LeavesAmount").Value = ColLeavesHoursNIS.SummaryItem.SummaryValue
                .Parameters("AbsenceAmount").Value = ColAbsentDaysAmount.SummaryItem.SummaryValue
                .Parameters("GrossSalary").Value = 0
                .Parameters("Payment").Value = Colpayment.SummaryItem.SummaryValue + GetDeductionsTotals(CStr(SearchLookUpEdit1.EditValue), Me.DateEdit2.DateTime)
                '  MsgBox(.Parameters("Payment").Value)
                .Parameters("Additions").Value = ColAdditions.SummaryItem.SummaryValue

                '  .Parameters("MonthDays").Value = ColNetSalaryMonthDays.SummaryItem.SummaryValue
                .Parameters("ActualDays").Value = ColAttendentDays.SummaryItem.SummaryValue
                .Parameters("VocationDays").Value = ColVocationDays.SummaryItem.SummaryValue
                .Parameters("WeekOffDays").Value = ColOffDays.SummaryItem.SummaryValue
                .Parameters("AbsenceDays").Value = ColAbsentDays.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColTransDay.SummaryItem.SummaryValue
                .Parameters("HouresRequired").Value = ColRequiredDailyHoures.SummaryItem.SummaryValue
                .Parameters("ActualHoures").Value = ColTotalDurations.SummaryItem.SummaryValue
                .Parameters("SaleryPerHour").Value = ColSalaryPerHour.SummaryItem.SummaryValue
                Dim _VocationDetails = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Today())
                .Parameters("AccruedVocationDays").Value = _VocationDetails.AccruedVocations
                .Parameters("VocationBegBalance").Value = _VocationDetails.BeginingBalance
                .Parameters("VocationAtEndYear").Value = _VocationDetails.Balance
                .Parameters("VocationSick").Value = 0
                .Parameters("HouresNetBonus").Value = ColBonusHours.SummaryItem.SummaryValue
                .Parameters("Leaves").Value = ColLeavesHours.SummaryItem.SummaryValue

                'طرح سقف المغادات من المغادرات الفعلية للموظف
                'Dim _TextLeaves As String = .Parameters("Leaves").Value
                'Dim _TimeLeaves As TimeSpan = New TimeSpan(Integer.Parse(_TextLeaves.Split(":"c)(0)), Integer.Parse(_TextLeaves.Split(":"c)(1)), 0)
                'If _TimeLeaves > MaxLeavesHoures Then
                '    .Parameters("Leaves").Value = ((_TimeLeaves - MaxLeavesHoures).ToString)
                'End If

                .Parameters("MaxLeavesHoures").Value = MaxLeavesHoures

                '  .Parameters("HouresNetLeaves").Value = ColLeavesHours.SummaryItem.SummaryValue

                .Parameters("NetSalary").Value = ColMonthlySalary.SummaryItem.SummaryValue _
                                                 + ColDailyTransport.SummaryItem.SummaryValue _
                                                 + ColBonusHoursNIS.SummaryItem.SummaryValue _
                                                 - Colpayment.SummaryItem.SummaryValue _
                                                 + ColAdditions.SummaryItem.SummaryValue _
                                                 - ColLeavesHoursNIS.SummaryItem.SummaryValue _
                                                 - ColAbsentDaysAmount.SummaryItem.SummaryValue
                .Parameters("NetSalary").Value = CDec(Format(.Parameters("NetSalary").Value, "n1"))

                If _FormType = "Rawateb2" Then
                    .Parameters("SalaryMonth").Value = ColGrossSalary.SummaryItem.SummaryValue
                    .Parameters("NetSalary").Value = ColNetSalary.SummaryItem.SummaryValue
                End If

                Try
                    Dim SqlString As String
                    Dim sql As New SQLControl
                    SqlString = " SELECT [CompanyName] ,[CompanyAddress] ,[CompanyPhone],[CompanyMobile] ,[CompanyFax],[CompanyEmail] ,[CompanyWebSite]
                              FROM [CompanyData] "
                    sql.SqlTrueTimeRunQuery(SqlString)
                    .Parameters("ComapnyName").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
                    .Parameters("CompanyAddress").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress")
                    .Parameters("CompanyPhone").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone")
                    .Parameters("CompanyFax").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFax")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    Dim cn As SqlConnection
                    cn = New SqlConnection
                    cn.ConnectionString = My.Settings.TrueTimeConnectionString
                    Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                    cn.Open()
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                    .XrPictureBox1.Image = Image.FromStream(ImgStream)
                    ImgStream.Dispose()
                    cmd.Connection.Close()
                    cn.Close()
                Catch ex As Exception

                End Try

                If _ShowVocationsTable = "True" Then
                    Try
                        Dim SqlString As String
                        Dim Sql As New SQLControl
                        SqlString = " select T.Vocation,Sum(V.NoDays) as VocationDays from Vocations V
                                        left join VocationsTypes T on V.VocationType=T.VocID 
                                        Where FromDate BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by T.Vocation "
                        Sql.SqlTrueTimeRunQuery(SqlString)
                        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            GridControlVocations.DataSource = Sql.SQLDS.Tables(0)
                            report.PrintableComponentContainer1.PrintableComponent = GridControlVocations
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
                    Try
                        Dim SqlString As String
                        Dim Sql As New SQLControl
                        SqlString = "  SELECT  [AdditionType],sum(AdditionAmount) as AdditionAmount FROM [dbo].[AttEmployeeAdditions] A
                                        left join EmployeesData E on A.EmployeeID=E.EmployeeID
                                        Where AdditionDate BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and A.EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by [AdditionType] "
                        Sql.SqlTrueTimeRunQuery(SqlString)
                        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            GridControlAdds.DataSource = Sql.SQLDS.Tables(0)
                            report.PrintableComponentContainerAdds.PrintableComponent = GridControlAdds
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
                    Try
                        Dim SqlString As String
                        Dim Sql As New SQLControl
                        SqlString = "  SELECT  P.[PaymentType],sum([PaymentAmount]) as PaymentAmount FROM [dbo].[AttEmployeePayments] P
                                        left join EmployeesData E on P.EmployeeID=E.EmployeeID
                                        Where [Status]=1 And [PaymentDate] BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and P.EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by [PaymentType] "
                        Sql.SqlTrueTimeRunQuery(SqlString)
                        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                            GridControlDiscounts.DataSource = Sql.SQLDS.Tables(0)
                            report.PrintableComponentContainerDiscount.PrintableComponent = GridControlDiscounts
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

            Try
                If ColAdditions.SummaryItem.SummaryValue = 0 Then
                    report.XrLabelAdditionsAmount.Visible = False
                    report.XrLabelAdditionsParameters.Visible = False
                End If
                If ColDailyTransport.SummaryItem.SummaryValue = 0 Then
                    report.XrTranport.Visible = False
                    report.XrLabelTransport.Visible = False
                End If
            Catch ex As Exception

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

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        GetEmployeesList()
    End Sub

    Private Sub GetEmployeesList()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select EmployeeID,EmployeeName,[Department],[JobName],[Branch],[PictureEmp]
                      from [EmployeesData]
                      where  [Active] =1"

            If _FormType = "Dawam2" Or _FormType = "Rawateb2" Then
                SqlString += " And (ProcessType=3 or ProcessType is null )    "
            Else
                SqlString += " And (ProcessType=2 or ProcessType is null )    "
            End If

            sql.SqlTrueTimeRunQuery(SqlString)
            SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextEditReportName_EditValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckShowDawamTab_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowDawamTab.CheckedChanged
        Select Case CheckShowDawamTab.CheckState
            Case CheckState.Checked
                gridBand2.Visible = True
            Case CheckState.Unchecked
                gridBand2.Visible = False

        End Select
    End Sub

    Private Sub GridView1_CustomDrawRowFooterCell(ByVal sender As Object, ByVal e As FooterCellCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowFooterCell
        If e.Column Is ColNetSalaryNew Then
            Dim view As GridView = CType(sender, GridView)

            e.Info.DisplayText = (Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("17001"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("BonusHoursNIS"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Transport"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("LeavesHoursNIS"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Payment"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("AbsentDaysAmount"), GridGroupSummaryItem)))).ToString()
            'e.Info.DisplayText = "1000"
            'e.TotalValue = ColMonthlySalary.SummaryItem.SummaryValue _
            '                             + ColDailyTransport.SummaryItem.SummaryValue _
            '                             + ColBonusHoursNIS.SummaryItem.SummaryValue _
            '                             - Colpayment.SummaryItem.SummaryValue _
            '                             + ColAdditions.SummaryItem.SummaryValue _
            '                             - ColLeavesHoursNIS.SummaryItem.SummaryValue _
            '                             - ColAbsentDaysAmount.SummaryItem.SummaryValue
        End If

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

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowColNetLeavesHouresDaily.CheckedChanged
        ColNetLeavesHouresDaily.Visible = CheckShowColNetLeavesHouresDaily.CheckState
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControlAdds_Click(sender As Object, e As EventArgs) Handles GridControlAdds.Click

    End Sub

    Private Sub CheckShowColMaxBonusHoures_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowColMaxBonusHoures.CheckedChanged
        ColNetBonusHoures.Visible = True
    End Sub

    Private Sub SpinEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles SpinEdit2.EditValueChanged
        If SpinEdit2.Value >= 0 AndAlso SpinEdit2.IsHandleCreated Then
            If SpinEdit2.Text = 0 Then
                gridBandWorkLeaves.Visible = False
                LayoutControlShowWorkLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                gridBandTotalWorkDuration.Visible = False
            Else
                gridBandWorkLeaves.Visible = True
                LayoutControlShowWorkLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                gridBandTotalWorkDuration.Visible = True
            End If
            If SpinEdit2.Text = 1 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = False : Me.LeaveJobBand3.Visible = False
            If SpinEdit2.Text = 2 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = False
            If SpinEdit2.Text = 3 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = True
            Using g = GridControl1.CreateGraphics()
                For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In AdvBandedGridView1.Bands
                    band.MinWidth = CInt(g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width)
                Next
            End Using
            AdvBandedGridView1.BestFitColumns()
        End If
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioGroup3_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioGroup3_SelectedIndexChanged_1(sender As Object, e As EventArgs)

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

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If GlobalVariables._ShowWorkLeavesData = False Then
            GlobalVariables._ShowWorkLeavesData = True
            gridBandWorkLeaves.Visible = True
            LayoutControlShowWorkLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            gridBandTotalWorkDuration.Visible = True
            UpdateData()
        Else
            GlobalVariables._ShowWorkLeavesData = False
            gridBandWorkLeaves.Visible = False
            LayoutControlShowWorkLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            gridBandTotalWorkDuration.Visible = False
            UpdateData()
        End If

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        'Dim f As New MonthlyAdjustmentForm
        'With f
        '    .DateEditfrom.DateTime = Me.DateEdit1.DateTime
        '    .DateEditto.DateTime = Me.DateEdit2.DateTime
        '    .DateDocDate.DateTime = Me.DateEdit2.DateTime
        '    .TextEmpID.Text = SearchLookUpEdit1.EditValue
        '    Dim t1 As New TimeSpan(Split(ColRequiredDailyHoures.SummaryItem.SummaryValue, ":")(0), Split(ColRequiredDailyHoures.SummaryItem.SummaryValue, ":")(1), 0)
        '    Dim t2 As New TimeSpan(Split(ColTotalDurations.SummaryItem.SummaryValue, ":")(0), Split(ColTotalDurations.SummaryItem.SummaryValue, ":")(1), 0)
        '    .TextMonthlyRequirdHoures.EditValue = t1
        '    .TextActualHours.EditValue = t2
        '    .ShowDialog()
        'End With
        'MonthlyAdjustmentForm.ShowDialog()
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

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim f As New AttBonus

        With f
            .TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim f As New AttAdvancePayment
        With f
            .TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick

        Dim _DateFrom As String = Format(CDate(DateEdit1.DateTime), "yyyy-MM-dd")
        Dim _DateTo As String = Format(CDate(DateEdit2.DateTime), "yyyy-MM-dd")
        Dim SQl4 As New SQLControl
        Dim _ID As Integer = 0
        Try
            Dim SqlString4 As String
            SqlString4 = " Select [ID],ArchiveStatus  
                               From [AttRawatebArchive]
                               Where  [EmployeeID]='" & SearchLookUpEdit1.EditValue & "' and ((DateFrom  between '" & _DateFrom & "'  and '" & _DateTo & "' ) or 
                               (DateTo between '" & _DateFrom & "' and '" & _DateTo & "'   ))  "
            SQl4.SqlTrueTimeRunQuery(SqlString4)
            If SQl4.SQLDS.Tables(0).Rows.Count >= 1 And SQl4.SQLDS.Tables(0).Rows(0).Item("ArchiveStatus") = 0 Then
                _ID = CInt(SQl4.SQLDS.Tables(0).Rows(0).Item("ID"))
                Dim Msg As DialogResult = XtraMessageBox.Show("يوجد قسيمة مرحلة، هل تريد حفظ التعديلات؟", "تحذير", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf SQl4.SQLDS.Tables(0).Rows.Count >= 1 And SQl4.SQLDS.Tables(0).Rows(0).Item("ArchiveStatus") <> 0 Then
                _ID = 0
                XtraMessageBox.Show("بيانات الراتب مرحلة لا يمكن ترحيل القسيمة", "خطأ")
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        Dim _employeedata = GetEmployeeData(SearchLookUpEdit1.EditValue)
        ' Dim vocationdata = GetVocationsDataBYEmployee2(Me.SearchLookUpEdit1.EditValue, "1")
        ' .Parameters("AccruedVocationDays").Value = GetVocationDataByEmpID(Me.SearchLookUpEdit1.EditValue, "1").Item2
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " INSERT INTO [AttRawatebArchive]
                             ([DateFrom],[DateTo],[EmployeeID],[EmployeeNoAsAcc]
                             ,[EmployeeName],[Branch],[Department],[JobName]
                             ,[BeginDate],[Currency],[SalaryMonth],[BonusAmount]
                             ,[Transport],[Additions],[LeavesAmount],[Payment]
                             ,[GrossSalary],[MonthDays],[ActualDays],[VocationDays]
                             ,[WeekOffDays],[AbsenceDays],[HouresRequired],[ActualHoures]
                             ,[VocationBegBalance],[AccruedVocationDays],[VocationAtEndYear],[VocationSick]
                             ,[NetSalary],HouresNetBonus,HouresNetLeaves,BankName,BankNo,BankBranch,IBAN,Indenty,[ArchiveStatus],AbsenceAmount,ProcessType)
                           VALUES
                             ('" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "','" & SearchLookUpEdit1.EditValue & "',
                             '" & _employeedata.SalaryAccountNo & "', N'" & _employeedata.EmployeeName & "',
                             N'" & _employeedata.Branch & "',N'" & _employeedata.Department & "',
                             N'" & _employeedata.JobName & "','" & _employeedata.DateOfStart & "',
                             '" & _employeedata.SalaryCurrency & "','" & _employeedata.MonthlySalary & "',
                             '" & ColBonusHoursNIS.SummaryItem.SummaryValue & "','" & ColDailyTransport.SummaryItem.SummaryValue & "',
                             '" & ColAdditions.SummaryItem.SummaryValue & "','" & ColLeavesHoursNIS.SummaryItem.SummaryValue & "',
                             '" & Colpayment.SummaryItem.SummaryValue & "','" & ColGrossSalary.SummaryItem.SummaryValue & "',
                             '" & ColTransDay.SummaryItem.SummaryValue & "','" & ColAttendentDays.SummaryItem.SummaryValue & "',
                             '" & 0 & "' ,'" & ColOffDays.SummaryItem.SummaryValue & "',
                             '" & ColAbsentDays.SummaryItem.SummaryValue & "','" & ColRequiredDailyHoures.SummaryItem.SummaryValue & "',
                             '" & ColTotalDurations.SummaryItem.SummaryValue & "','" & 0 & "',
                             '" & 0 & "','" & 0 & "',
                             '" & 0 & "','" & ColNetSalary.SummaryItem.SummaryValue & "',
                             '" & ColNetBonusHoures.SummaryItem.SummaryValue & "','" & ColNetLeavesHouresDaily.SummaryItem.SummaryValue & "',
                             N'" & _employeedata.BankName & "','" & _employeedata.BankAccountNo & "',
                             N'" & _employeedata.BankBranch & "','" & _employeedata.Iban & "',
                             '" & _employeedata.Indenty & "',0,
                             '" & ColAbsentDaysAmount.SummaryItem.SummaryValue & "','" & 0 & "')"
        If sql.SqlTrueTimeRunQuery(SqlString) = True Then
            XtraMessageBox.Show(" تم الحفظ ", "تم", MessageBoxButtons.OK, MessageBoxIcon.None)
        Else
            XtraMessageBox.Show(" خطأ بالحفظ ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Function GetDeductionsTotals(EmpID As Integer, DateTo As Date)
        Dim _Amount As Decimal
        Dim _DateTo As String
        _DateTo = Format(DateTo, "yyyy-MM-dd")
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueTimeRunQuery(" SELECT  IsNull(Sum([DeductionAmount]),0) as Amount
                                      FROM [dbo].[AttRecurrenceDeductions] D
                                      Left join EmployeesData E on E.EmployeeID=D.[EmployeeID]
                                      Where D.[EmployeeID]=" & EmpID & " And '" & _DateTo & "' between datefrom and dateto  ")
            _Amount = Sql.SQLDS.Tables(0).Rows(0).Item("Amount")
        Catch ex As Exception
            _Amount = 0
        End Try
        Return _Amount
    End Function

    Private Function GetAdditionsTotals(EmpID As Integer, DateTo As Date)
        Dim _Amount As Decimal
        Dim _DateTo As String
        _DateTo = Format(DateTo, "yyyy-MM-dd")
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueTimeRunQuery(" SELECT  IsNull(Sum([DeductionAmount]),0) as Amount
                                      FROM [dbo].[AttRecurrenceDeductions] D
                                      Left join EmployeesData E on E.EmployeeID=D.[EmployeeID]
                                      Where D.[EmployeeID]=" & EmpID & " And '" & _DateTo & "' between datefrom and dateto  ")
            _Amount = Sql.SQLDS.Tables(0).Rows(0).Item("Amount")
        Catch ex As Exception
            _Amount = 0
        End Try
        Return _Amount
    End Function

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit2.EditValueChanged
        'If GlobalVariables._EndDate < Today Then
        '    'DateEdit2.Enabled = False
        '    DateEdit2.DateTime = GlobalVariables._EndDate
        'End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        AdvBandedGridView1.OptionsSelection.MultiSelect = True
        AdvBandedGridView1.SelectAll()
        AdvBandedGridView1.CopyToClipboard()
        AdvBandedGridView1.OptionsSelection.MultiSelect = False
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub


    ' لحل مشكلة سيجا فريدو وهو وجود خروج فقط الساعة 2 الصبح ولا يوجد دخول تم اضافة 5 ساعات على حقل التاريخ ل في عملية البحث عن الخروج وعدد مرات الخروج
End Class



