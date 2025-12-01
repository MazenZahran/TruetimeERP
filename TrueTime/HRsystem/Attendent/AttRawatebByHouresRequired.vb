Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Globalization

Public Class AttRawatebByHouresRequired
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
    Public _EmployeesCount As Integer
    Dim _CurrentEmployeeHandle As Integer = 0
    Dim _UseLocalDataBaseForReport As Boolean = False
    Dim _BonusPerHourAmount As Decimal = 0
    Dim _BonusPerHourAmountOption As Boolean = False
    Dim _MaxLeavesHouresDaily As TimeSpan = TimeSpan.Zero
    Dim _MaxBonusHoures As TimeSpan = TimeSpan.Zero
    Dim LastWorkLeaveID As Integer = 0
    Dim _ShowEmployeeDetails As Boolean = False
    Dim Branch As String = String.Empty
    Dim Department As String = String.Empty
    Dim JobName As String = String.Empty
    Dim DaysInMonth As Decimal
    Dim RequiredHoursPlane As Integer
    Public _OpenForPrint As Boolean
    Public _OnlyPrint As Boolean
    Public _PrintSalayDocument As Boolean
    Public _PrintAtt As Boolean
    Public _SaveSalary As Boolean
    Public _TheOptionPrint As String
    Dim _CalAbsentInSalary As Boolean
    Dim _CalcBonusAfterMinutesInReqHoures As TimeSpan = TimeSpan.Zero
    Private _ShowProductionColumnInAttReports As Boolean
    Private _ShowProductionTimeSpanColumnInAttReports As Boolean
    Private _ShowAllEmployees As Boolean
    Private _SubtractAbsenceFromHolidays As Boolean
    Private _TimeSpanFunction As New TimeFunctions
    Private _Att_MaxHoursToFindOutTrans As Decimal
    Private CalcLeavesDuringWorkFromVocations As Boolean
    Private _ShowHrNotePerDayInAttReports As Boolean
    Private Vocation_BeginingBalance As Decimal
    Private Vocation_ThisYearVocations As Decimal
    Private Vocation_Balance As Decimal
    Private Vocation_AccruedVocations As Decimal



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

        'Me.DateEdit2.DateTime = Today
        'Dim startDt As New Date(Today.Year, Today.Month, 1)
        'Me.DateEdit1.DateTime = startDt

        Me.KeyPreview = True

        GetSettings()
        _ShowAllEmployees = False
        'If Me.TextEditReportName.Text = 2 Then

        'End If

        If _FormType = "Dawam" Then
            gridBandSalary.Visible = False
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = "تقرير الدوام حسب الساعات المطلوبة"
            Else
                Me.Text = "Attendance By Required Hours"
            End If
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ColGrossSalary.Visible = False
            gridBand2.Visible = True
            ColDailyTransport.Visible = False
            Colpayment.Visible = False
            ColAdditions.Visible = False
        ElseIf _FormType = "Rawateb" Then
            gridBandSalary.Visible = True
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            ColNetSalaryNew.Visible = True
            gridBand2.Visible = True
            ColGrossSalary.Visible = False
            ColRequiredDailyHoures.Visible = False
            gridBand7.Visible = False
            gridBand13.Visible = False
        ElseIf _FormType = "Rawateb2" Then ' تقرير الراتب بالساعة
            gridBandSalary.Visible = True
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            ColBonusHours.Visible = True
            ColLeavesHours.Visible = False
            ColMonthlySalary.Visible = False
            ColBonusHoursNIS.Visible = True
            ColLeavesHoursNIS.Visible = False
            ColAbsentDaysAmount.Visible = False
            gridBand2.Visible = True
            ColSalaryAccountNo.Visible = False
            ' LayoutControlVocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ColDailyTransport.Visible = True
            Colpayment.Visible = True
            ColAdditions.Visible = True
            '  ColNetSalary.Visible = False
            ColSalaryPerHour.Visible = True
            ColNetSalary.Visible = True
            ColNetDurations.Visible = False
            ColNetSalaryNew.Visible = False
            gridBand7.Visible = False
            gridBand13.Visible = False
            If GlobalVariables._UserAccessType = 2 Then
                ColGrossSalary.Visible = False
            Else
                ColGrossSalary.Visible = True
            End If
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = "تقرير الرواتب بالساعة"
            Else
                Me.Text = "Salaries By Required Hours"
            End If
            ColRequiredDailyHoures.Visible = False
        ElseIf _FormType = "Dawam2" Then ' تقرير الدوام حسب الساعة
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = "تقرير الدوام بالساعة"
            Else
                Me.Text = "Attendance By Hours"
            End If
            BarButtonAddDiscount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonAddAddition.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonSaveAttData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarMonthlySalaryProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            gridBandSalary.Visible = True
            ColBonusHours.Visible = True
            ColLeavesHours.Visible = False
            gridBand2.Visible = True
            SimpleButton3.Visible = False
            SimpleButtonAddVocations.Visible = False
            CheckShowDawamTab.Visible = False
            CheckEditRestTime.Visible = False
            CheckCalcVocationsAtOffDay.Visible = False
            CheckElapseOnVocation.Visible = False
            '   LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
            If GlobalVariables._UserAccessType = 2 Then
                '  ColGrossSalary.Visible = False
                '  ColSalaryPerHour.Visible = False
                gridBandSalary.Visible = False
            Else
                '  ColGrossSalary.Visible = True
                '  ColSalaryPerHour.Visible = True
                gridBandSalary.Visible = True
            End If
        ElseIf _FormType = "MonthlyRequirdHoures" Then 'تقرير الدوام حسب الساعات الشهرية المطلوبة
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = " تقرير الدوام حسب الساعات الشهرية المطلوبة "
            Else
                Me.Text = "Work report by required monthly hours "
            End If
            BarButtonAddDiscount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonAddAddition.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonSaveAttData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarMonthlySalaryProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            gridBandSalary.Visible = True
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
            LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
            gridBandSalary.Visible = False

        ElseIf _FormType = "DailyAtt" Then ' تقرير الدوام حسب نظام المياومة
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Me.Text = "تقرير الدوام حسب نظام المياومة"
            Else
                Me.Text = "Attendance By Daily"
            End If
            BarButtonAddDiscount.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonAddAddition.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonSaveAttData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarMonthlySalaryProcessing.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            gridBandSalary.Visible = True
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
            LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
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
            ColBonusHoursNIS.Visible = False
            ColAbsentDaysAmount.Visible = False
            ColLeavesHoursNIS.Visible = False
            ColRequiredDailyHoures.Visible = False
            If GlobalVariables._UserAccessType = 2 Then
                '  ColGrossSalary.Visible = False
                '  ColSalaryPerHour.Visible = False
                gridBandSalary.Visible = False
            Else
                '  ColGrossSalary.Visible = True
                '  ColSalaryPerHour.Visible = True
                gridBandSalary.Visible = True
            End If
            ColAdditions.Visible = True
            Colpayment.Visible = True
            ColMonthlySalaryPerDay.Visible = True
            'MsgBox("ColAdditions " & ColAdditions.VisibleIndex)
            'MsgBox("Colpayment " & Colpayment.VisibleIndex)
            'MsgBox("ColMonthlySalaryPerDay " & ColMonthlySalaryPerDay.VisibleIndex)
            'ColMonthlySalaryPerDay.VisibleIndex = 0
            'ColAdditions.VisibleIndex = 1
            'Colpayment.VisibleIndex = 2

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

        If _OpenForPrint = True Then
            UpdateData()

            If _SaveSalary = True Then SaveSalary()
            PrintWithOption(_TheOptionPrint)
            _OpenForPrint = False
            Me.Close()
        End If



        Me.AdvBandedGridView1.OptionsView.ShowPreview = _ShowHrNotePerDayInAttReports
        RadioGroup3.EditValue = "last"
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

        Try
            SqlString = " select SettingValue From Settings where SettingName ='Att_ShowProductionColumnInAttReports'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _ShowProductionColumnInAttReports = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _ShowProductionColumnInAttReports = False
            XtraMessageBox.Show(ex.ToString)
        End Try
        If _ShowProductionColumnInAttReports = True Then
            gridBandProduction.Visible = True
            ColProduction.Visible = True
        Else
            gridBandProduction.Visible = False
            ColProduction.Visible = False
        End If

        Try
            SqlString = " select SettingValue From Settings where SettingName ='Att_ShowProductionTimeSpanColumnInAttReports'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _ShowProductionTimeSpanColumnInAttReports = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _ShowProductionTimeSpanColumnInAttReports = False
            XtraMessageBox.Show(ex.ToString)
        End Try
        If _ShowProductionTimeSpanColumnInAttReports = True Then
            ColProductionTimeSpan.Visible = True
            ColNetDurationsFromProductionTimeSpan.Visible = True
        Else
            ColProductionTimeSpan.Visible = False
            ColNetDurationsFromProductionTimeSpan.Visible = False
        End If


        Try
            SqlString = " select SettingValue From Settings where SettingName ='SubtractAbsenceFromHolidays'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _SubtractAbsenceFromHolidays = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _SubtractAbsenceFromHolidays = False
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            SqlString = " select SettingValue From Settings where SettingName ='Att_MaxHoursToFindOutTrans'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _Att_MaxHoursToFindOutTrans = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _Att_MaxHoursToFindOutTrans = 20
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='HR_CalcLeavesDuringWorkFromVocations';
                          select SettingValue From Settings where SettingName ='Att_ShowHrNotePerDayInAttReports'"
            sql.SqlTrueTimeRunQuery(SqlString)
            CalcLeavesDuringWorkFromVocations = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            _ShowHrNotePerDayInAttReports = CBool(sql.SQLDS.Tables(1).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            CalcLeavesDuringWorkFromVocations = False
            XtraMessageBox.Show(ex.ToString)
        End Try

        ColHrNotePerDay.Visible = _ShowHrNotePerDayInAttReports

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
        ElseIf e.Control AndAlso e.KeyCode = Keys.V Then
            AddQuickVocation()
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
                              RequiredDailyHoures,OffDay1,OffDay2,SalaryPerHour,IsNull(RestDailyHoures,'00:00:00') As RestDailyHoures,BonusPerHour,BonusOnDayOff,IsNull(Salary,0) as Salary,
                              DailyTransport,SalaryAccountNo,SubtractionLeavesAndLates,AddBonusToSalary,
                              MaxLeavesHoures,ProcessType,DateOfStart,DateOfEnd,BonusPerHourAmount,
                              BonusPerHourAmountOption,MaxLeavesHouresDaily,MaxBonusHoures,[JobName],[Department],[Branch],
                              IsNull(RequiredHoursPlane,0) as RequiredHoursPlane,IsNull(CalAbsentInSalary,0) as CalAbsentInSalary,
                              IsNull(CalcBonusAfterMinutesInReqHoures,0) as CalcBonusAfterMinutesInReqHoures,IsNull(SalaryPerDay,0) as SalaryPerDay
                      From    EmployeesData E
                      where  (DontCheckInOut IS NULL OR DontCheckInOut=0) And (E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 )"


        If CheckEditCheckActive.Checked = True Then SQLString = SQLString + "and E.Active = 1"
        If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
            'colEmployeeName.Visible = False
            CollEmployeeName.Visible = False



        Else
            'colEmployeeName.Visible = True
            CollEmployeeName.Visible = True
            Me.AdvBandedGridView1.ViewCaption = ""
        End If
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"
        If _ShowAllEmployees = False Then
            If _FormType = "Dawam2" Or _FormType = "Rawateb2" Then
                SQLString += " And (ProcessType=3 or ProcessType=6 or ProcessType is null )    "
            ElseIf _FormType = "MonthlyRequirdHoures" Then
                SQLString += " And (ProcessType=6 )    "
            ElseIf _FormType = "DailyAtt" Then
                SQLString += " And (ProcessType=7 )    "
            Else
                SQLString += " And (ProcessType=2 or ProcessType is null )    "
            End If
        End If



        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        Try
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                'MsgBox("لا يوجد حركات")
                ' SplashScreenManager1.CloseWaitForm()
                SplashScreenManager.CloseForm(False)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
            SplashScreenManager.CloseForm(False)
            Exit Sub
        End Try


        EmployeesTable = sql.SQLDS.Tables(0)



        If _OpenForPrint = False Then
            _EmployeesCount = EmployeesTable.Rows.Count
        End If


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
                    If String.IsNullOrEmpty(EmployeesTable.Rows(j).Item("RequiredDailyHoures")) Then
                        RequiredDailyHoures = TimeSpan.Zero
                    Else
                        RequiredDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
                    End If
                Else
                    RequiredDailyHoures = TimeSpan.Zero
                End If

                If EmployeesTable.Rows(j).Item("RequiredHoursPlane") <> 0 Then
                    RequiredHoursPlane = CInt(EmployeesTable.Rows(j).Item("RequiredHoursPlane"))
                Else
                    RequiredHoursPlane = 0
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
                    Case 7
                        SalaryPerDay = CDec(EmployeesTable.Rows(j).Item("SalaryPerDay"))
                End Select


                If String.IsNullOrEmpty(EmployeesTable.Rows(j).Item("RestDailyHoures")) Then
                    RestDailyHoures = TimeSpan.Zero
                Else
                    RestDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RestDailyHoures"))
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
                    If EmployeesTable.Rows(j).Item("MaxLeavesHoures") <> "" Then
                        MaxLeavesHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxLeavesHoures"))
                    End If
                End If
                _DateOfStart = "1900-01-01"
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfStart")) Then
                        _DateOfStart = Format(CDate(EmployeesTable.Rows(j).Item("DateOfStart")), "yyyy-MM-dd")
                    End If
                    _DateOfEnd = "2100-01-01"
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
                    If EmployeesTable.Rows(j).Item("MaxLeavesHouresDaily") <> String.Empty Then
                        _MaxLeavesHouresDaily = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxLeavesHouresDaily"))
                    Else
                        _MaxLeavesHouresDaily = TimeSpan.Zero
                    End If
                End If
                If Not IsDBNull(EmployeesTable.Rows(j).Item("MaxBonusHoures")) Then
                        If EmployeesTable.Rows(j).Item("MaxBonusHoures") <> String.Empty Then
                            _MaxBonusHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("MaxBonusHoures"))
                        Else
                            _MaxBonusHoures = TimeSpan.Zero
                        End If
                    Else
                        _MaxBonusHoures = TimeSpan.Zero
                    End If


                    If Not IsDBNull(EmployeesTable.Rows(j).Item("JobName")) Then
                        JobName = (EmployeesTable.Rows(j).Item("JobName"))
                    Else
                        JobName = String.Empty
                    End If
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("Department")) Then
                        Department = (EmployeesTable.Rows(j).Item("Department"))
                    Else
                        Department = String.Empty
                    End If
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("Branch")) Then
                        Branch = (EmployeesTable.Rows(j).Item("Branch"))
                    Else
                        Branch = String.Empty
                    End If

                    _CalAbsentInSalary = 1
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("CalAbsentInSalary")) Then
                        _CalAbsentInSalary = CBool(EmployeesTable.Rows(j).Item("CalAbsentInSalary"))
                    Else
                        _CalAbsentInSalary = 1
                    End If

                    _CalcBonusAfterMinutesInReqHoures = TimeSpan.Zero
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("CalcBonusAfterMinutesInReqHoures")) Then
                        _CalcBonusAfterMinutesInReqHoures = TimeSpan.FromMinutes(EmployeesTable.Rows(j).Item("CalcBonusAfterMinutesInReqHoures"))
                    Else
                        _CalcBonusAfterMinutesInReqHoures = TimeSpan.Zero
                    End If


                Vocation_Balance = 0
                Vocation_BeginingBalance = 0
                Vocation_ThisYearVocations = 0
                Vocation_AccruedVocations = 0
                Dim _VocationBalances = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Me.DateEdit2.DateTime)
                Vocation_Balance = _VocationBalances.Balance
                Vocation_BeginingBalance = _VocationBalances.BeginingBalance
                Vocation_ThisYearVocations = _VocationBalances.ThisYearVocations
                Vocation_AccruedVocations = _VocationBalances.AccruedVocations


                'BonusPerHourAmount
                DataTable.Merge(QueryData(EmpID))
                End If
        Next
        Summery = True

        GridControl1.DataSource = DataTable
        GlobalVariables._TotalWorkingHoursInMonthlyAdjustment = CStr(ColTotalDurations.SummaryItem.SummaryValue)
        GlobalVariables._TotalRequiredHoursInMonthlyAdjustment = CStr(ColRequiredDailyHoures.SummaryItem.SummaryValue)
        '  AdvBandedGridView1.BestFitColumns()
        ' GridBand1.Width = GridControl1.Width / 2
        'If SearchLookUpEdit1.EditValue = 0 Or IsNothing(SearchLookUpEdit1.EditValue) Then
        '    ColEmpID.Visible = True
        '    CollEmployeeName.Visible = True
        'Else
        '    ColEmpID.Visible = False
        '    CollEmployeeName.Visible = False
        'End If

        AdvBandedGridView1.BestFitColumns()

        ' SplashScreenManager1.CloseWaitForm()
HH:
        SplashScreenManager.CloseForm(False)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
    End Sub
    Private Function GetHrNotePerDay(EmployeeNo As Integer, AttDate As String) As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT [AttNotes] FROM [AttHrNotesPerDayForAttReports] WHERE [EmployeeNo] = " & EmployeeNo & " AND [AttDate] = '" & Format(CDate(AttDate), "yyyy-MM-dd") & "'"
            Sql.SqlTrueTimeRunQuery(SqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return CStr(Sql.SQLDS.Tables(0).Rows(0).Item("AttNotes"))
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
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
        ListDays.Columns.Add("Duration1", GetType(TimeSpan))
        ListDays.Columns.Add("Duration2", GetType(TimeSpan))
        ListDays.Columns.Add("Duration3", GetType(TimeSpan))
        ListDays.Columns.Add("Duration4", GetType(TimeSpan))
        ListDays.Columns.Add("Duration5", GetType(TimeSpan))
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
        ListDays.Columns.Add("HrNotePerDay", GetType(String))

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
        ListDays.Columns.Add("Note2", GetType(String))
        ListDays.Columns.Add("BonusIsAdjust", GetType(String))
        ListDays.Columns.Add("LeavesIsAdjust", GetType(String))
        ListDays.Columns.Add("Production", GetType(Decimal))
        ListDays.Columns.Add("ProductionTimeSpan", GetType(String))
        ListDays.Columns.Add("NetDurationsFromProductionTimeSpan", GetType(String))

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
        Dim dr2 As SqlDataReader
        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1
            ListDays.Rows(i).Item("HrNotePerDay") = GetHrNotePerDay(EmpID, Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd"))
            ListDays.Rows(i).Item("BonusPerHour") = BonusPerHour
            ListDays.Rows(i).Item("BonusOnDayOff") = BonusOnDayOff
            ListDays.Rows(i).Item("RestDailyHoures") = RestDailyHoures
            ListDays.Rows(i).Item("BonusIsAdjust") = 0
            ListDays.Rows(i).Item("LeavesIsAdjust") = 0
            If CheckEditRestTime.Checked = True Then
                ListDays.Rows(i).Item("RequiredDailyHoures") = RequiredDailyHoures - RestDailyHoures
            Else
                ListDays.Rows(i).Item("RequiredDailyHoures") = RequiredDailyHoures
            End If

            If RequiredHoursPlane <> 0 Then
                RequiredDailyHoures = GetRequiredHours(RequiredHoursPlane, CDate(ListDays.Rows(i).Item("TransDate")))
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
                If GetTransInCount > 5 Then GetTransInCount = 5
                For j = 1 To CInt(GetTransInCount)
                    Try




                        Dim SQLString2 As String
                        SQLString2 = "SELECT     Row, CHECKTIME AS CheckINTimes, USERID, CHECKTYPE, ID As CheckInID,EditedType,Concat(EditNote,' - ',Notes, ' - ',RecordType) As Notes
                                        FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
                                        FROM        [AttCHECKINOUT] 
                                        where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS "
                        If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                            SQLString2 += " and sn='" & Me.SearchDevice.EditValue & "'"
                        End If
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
                                If j = 1 Then ListDays.Rows(i).Item("Note1") = dr.Item("Notes")


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
                            CheckOut = Format(CDate(CheckIn).AddHours(_Att_MaxHoursToFindOutTrans), "yyyy-MM-dd HH:mm")
                            ' CheckOut = Format(CDate(CheckIn).AddHours(30), "yyyy-MM-dd HH:mm")

                            Dim SQLString3 As String
                            SQLString3 = " SELECT top 1 CHECKTIME AS CheckOutTimes, USERID, CHECKTYPE, ID As CheckOutID,EditedType,Concat(EditNote,' - ',Notes, ' - ',RecordType) As Notes   
                                                 FROM   [AttCHECKINOUT] 
                                                 where  [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS "
                            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                                SQLString3 += " and sn='" & Me.SearchDevice.EditValue & "'"
                            End If
                            SQLString3 += " and  [USERID] = " & EmpID & "
                                            and ( CHECKTIME between '" & CheckIn & "'  and '" & CheckOut & "') order by CHECKTIME asc "
                            mycommand = New SqlCommand(SQLString3, myconnection)
                            dr = mycommand.ExecuteReader
                            If dr.HasRows Then
                                dr.Read()
                                ListDays.Rows(i).Item("EndTimeReal" & j) = dr.Item("CheckOutTimes")
                                ListDays.Rows(i).Item("TransOutID") = dr.Item("CheckOutID")
                                ListDays.Rows(i).Item("EditedTypeOut") = dr.Item("EditedType")
                                If j = 1 Then ListDays.Rows(i).Item("Note2") = dr.Item("Notes")
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
                        If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                            SQLString += " and sn='" & Me.SearchDevice.EditValue & "'"
                        End If

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
                                        where [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS "
                        If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                            SQLString2 += " and sn='" & Me.SearchDevice.EditValue & "'"
                        End If
                        SQLString2 += " and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
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
                                        where [CHECKTYPE]='i' COLLATE Latin1_General_CS_AS "
                        If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                            SQLString3 += " and sn='" & Me.SearchDevice.EditValue & "'"
                        End If
                        SQLString3 += " and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate2 & "' and '" & ToDate2 & "')   )  cc
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
                _VocationName = String.Empty
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
                ' تم تفعيله بتاريخ 05/06/2024 لاحتساب يوم العطلة غياب اذا كان الموظف ترك العمل

                If ProcessType = 2 Then
                    If ListDays.Rows(i).Item("Voc") = "0" And CDate(CurrentDateString) < CDate(_DateOfStart) Then
                        ListDays.Rows(i).Item("AttStatus") = "غياب"
                        ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerHour * __RequiredDailyHoures.TotalHours
                    End If
                    If CDate(CurrentDateString) > CDate(_DateOfEnd) And CDate(_DateOfEnd) <> CDate("2100-01-01") And ListDays.Rows(i).Item("AttStatus") = "عطلة" Then
                        ListDays.Rows(i).Item("AttStatus") = "غياب"
                        ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerHour * __RequiredDailyHoures.TotalHours
                    End If
                End If



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

                ' مرة طلع فوق ومرة نزل هان - انا مش عارف وين ادور  فيه اذا طلع فوق ببطل يحسب العطلة غياب بعد انتهاء العمل  بعد الاستقالة
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
                    If (ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")) <= _CalcBonusAfterMinutesInReqHoures Then
                        ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
                    Else
                        ListDays.Rows(i).Item("BonusHours") = ListDays.Rows(i).Item("TotalDurations") - ListDays.Rows(i).Item("RequiredDailyHoures")
                    End If


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

                    'If SubtractionLeavesAndLates = False Then
                    '    ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                    'End If

                ElseIf DiffHoureSpan = TimeSpan.Zero Then
                    ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
                End If


                Dim _AdjLeave As TimeSpan = TimeSpan.Zero
                Dim _LastLeaves As TimeSpan = TimeSpan.Zero
                ' معالجة المغادرات والاضافي بشكل يومي ماعدا للموظف الدوام الشهري او اليومي
                If GlobalVariables._AttDailyAdjustment = True And ProcessType <> 7 And ProcessType <> 6 Then
                    ' معالجة المغادرات
                    If Not IsDBNull(ListDays.Rows(i).Item("LeavesHours")) Then
                        _LastLeaves = ListDays.Rows(i).Item("LeavesHours")
                    End If
                    _AdjLeave = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 1)
                    If _AdjLeave <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeavesIsAdjust") = 1
                    End If
                    ListDays.Rows(i).Item("LeavesHours") = _LastLeaves + _AdjLeave
                    ListDays.Rows(i).Item("LeavesHoursNIS") = SalaryPerHour * (_LastLeaves + _AdjLeave).TotalHours
                    ' معالجة الاضافي
                    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                    Dim _LastBonus As TimeSpan = TimeSpan.Zero
                    If Not IsDBNull(ListDays.Rows(i).Item("BonusHours")) Then
                        _LastBonus = ListDays.Rows(i).Item("BonusHours")
                    End If
                    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 2)
                    If _AdjBonus <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("BonusIsAdjust") = 1
                    End If
                    ListDays.Rows(i).Item("BonusHours") = _LastBonus + _AdjBonus
                End If


                If SubtractionLeavesAndLates = False Then
                    ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                End If

                'ادا نوع الاحتساب حسب الساعة او شهري او يومي فلا معنى باحتساب المغادرات
                If ProcessType = 3 Or ProcessType = 6 Or ProcessType = 7 Then
                    ListDays.Rows(i).Item("LeavesHours") = TimeSpan.Zero
                    ListDays.Rows(i).Item("LeavesHoursNIS") = 0
                End If


                'اظهار عمود التجاوز في الحد الاقصى للبونص
                If CheckShowColMaxBonusHoures.Checked = True And ProcessType = 6 Or ProcessType = 7 Then
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

                ' احتساب الانتاج 
                If _ShowProductionColumnInAttReports = True Then
                    Dim _timeFunction As New TimeFunctions
                    Dim _timespan As TimeSpan
                    Dim _Diff As TimeSpan
                    Dim _GetEmployeeProduction As Decimal = GetEmployeeProduction(EmpID, CDate(ListDays.Rows(i).Item("TransDate")))
                    _timespan = _timeFunction.ConvertFromDecimalToTimeSpan(_GetEmployeeProduction)
                    ListDays.Rows(i).Item("Production") = _GetEmployeeProduction
                    ListDays.Rows(i).Item("ProductionTimeSpan") = String.Format("{0:00}:{1:00}", _timespan.Hours, _timespan.Minutes)
                    _Diff = ListDays.Rows(i).Item("TotalDurations") - _timespan
                    ListDays.Rows(i).Item("NetDurationsFromProductionTimeSpan") = String.Format("{0:00}:{1:00}", _Diff.Hours, _Diff.Minutes)
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try



            If ListDays.Rows(i).Item("AttStatus") = "غياب" And ProcessType = "4" Then
                ListDays.Rows(i).Item("AbsentDaysAmount") = 0.00
            End If
            If ListDays.Rows(i).Item("AttStatus") = "غياب" And _CalAbsentInSalary = False Then
                ListDays.Rows(i).Item("AbsentDaysAmount") = 0.00
            End If
            'لا داعي لحساب الغياب ادا كان نوع الاحتساب الراتب حسب الساعة
            If ProcessType = "3" Or ProcessType = 6 Then
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

            If ProcessType <> 7 Then
                ListDays.Rows(i).Item("SalaryPerHour") = SalaryPerHour
            End If


            'حساب المواصلات اليومية

            'If ListDays.Rows(i).Item("AttStatus") = "دوام" Then
            '    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
            'End If
            'If ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" Then
            '    ListDays.Rows(i).Item("DailyTransport") = 0
            'End If
            'If ListDays.Rows(i).Item("AttStatus") = "غياب" Then
            '    DailyTransport = 0
            '    ListDays.Rows(i).Item("DailyTransport") = 0
            'End If
            If ListDays.Rows(i).Item("AttStatus") <> "دوام" Then
                ListDays.Rows(i).Item("DailyTransport") = 0
                '  DailyTransport = 0
            Else
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

                If ProcessType = 2 Or ProcessType = 7 Then
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

                'If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal1")) And Not IsDBNull(ListDays.Rows(i).Item("RequiredDailyHoures"))) And ListDays.Rows(i).Item("AttStatus") = "عطلة" Then
                '    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                '    '  ListDays.Rows(i).Item("BonusHoursNIS") =
                '    'BonusHoursNIS = BonusHoursNIS + BonusOnDayOff *
                'End If

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
                If ProcessType = 7 Then
                    ListDays.Rows(i).Item("NetSalary") = ListDays.Rows(i).Item("MonthlySalaryPerDay") - Payment _
                                            + Additions + ListDays.Rows(i).Item("DailyTransport")
                Else
                    ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) _
                                          + CDec(ListDays.Rows(i).Item("BonusHoursNIS")) - Payment _
                                          - LeavesHoursNIS - AbsentDaysAmount + Additions + ListDays.Rows(i).Item("DailyTransport")
                End If


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
                    If ProcessType = 7 Then MonthlySalaryPerDay = SalaryPerDay : ListDays.Rows(i).Item("MonthlySalaryPerDay") = SalaryPerDay
                    If Not IsDBNull(ListDays.Rows(i).Item("BonusHoursNIS")) Then BonusHoursNIS = ListDays.Rows(i).Item("BonusHoursNIS")
                    If Not IsDBNull(ListDays.Rows(i).Item("LeavesHoursNIS")) Then LeavesHoursNIS = ListDays.Rows(i).Item("LeavesHoursNIS")
                    If Not IsDBNull(ListDays.Rows(i).Item("AbsentDaysAmount")) Then AbsentDaysAmount = ListDays.Rows(i).Item("AbsentDaysAmount")
                    If Not IsDBNull(ListDays.Rows(i).Item("Payment")) Then Payment = ListDays.Rows(i).Item("Payment")
                    If Not IsDBNull(ListDays.Rows(i).Item("Additions")) Then Additions = ListDays.Rows(i).Item("Additions")

                    ListDays.Rows(i).Item("NetSalary") = MonthlySalaryPerDay - Payment + Additions
                Else
                    ListDays.Rows(i).Item("NetSalary") = (SalaryPerHour * TotalDurations.TotalHours) _
                                                          + SalaryPerHour * BonusPerHour * BonusHoures.TotalHours - Payment _
                                                          - 0 - 0 + Additions + ListDays.Rows(i).Item("DailyTransport")
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
                    Case Else
                        ListDays.Rows(i).Item("EnglishStatus") = ListDays.Rows(i).Item("AttStatus")
                End Select
            End If

            If IsDBNull(ListDays.Rows(i).Item("BonusHours")) Then
                ListDays.Rows(i).Item("BonusHours") = TimeSpan.Zero
            End If
            If IsDBNull(ListDays.Rows(i).Item("LeavesHours")) Then
                ListDays.Rows(i).Item("LeavesHours") = TimeSpan.Zero
            End If





            If ListDays.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (ListDays.Rows.Count)) & "%" &
                                                                                   " " & _CurrentEmployeeHandle & " From " & _EmployeesCount)
        Next

        '    myconnection.Close()
        If ProcessType = 2 Then
            If _SubtractAbsenceFromHolidays = True Then
                Dim _Alldays As Decimal
                Dim _Absencedays As Decimal
                Dim _Holidays As Decimal
                Dim _Percent As Decimal
                Dim _AmountToDeduct As Decimal
                _Alldays = ListDays.Rows.Count
                _Absencedays = ListDays.Compute("Count(AttStatus)", "AttStatus = 'غياب'")
                'g g g
                If _Absencedays > 6 Then
                    _Holidays = ListDays.Compute("Count(AttStatus)", "AttStatus = 'عطلة'")
                    _Percent = (_Absencedays + _Holidays) / _Alldays
                    _AmountToDeduct = CDec(SalaryPerDay * _Percent).ToString("n2")
                    If _AmountToDeduct <> 0 Then
                        For l = 0 To ListDays.Rows.Count - 1
                            If ListDays.Rows(l).Item("AttStatus") = "عطلة" Then
                                ListDays.Rows(l).Item("AbsentDaysAmount") = _AmountToDeduct
                                'ListDays.Rows(l).Item("AbsentDaysAmount") = SalaryPerDay - _AmountToDeduct
                            End If
                        Next
                    End If
                End If
            End If
        End If


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


    Private Sub PrintWithOption(_PrintOption)
        If GridControl1.IsPrintingAvailable = False Then Exit Sub
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If AdvBandedGridView1.RowCount = 0 Then Exit Sub
        Else
            If AdvBandedGridView1.RowCount = 0 Then Exit Sub
        End If
        AdvBandedGridView1.OptionsPrint.ExpandAllGroups = False
        '  ColRequiredDailyHoures.Visible = False

        If _PrintAtt = True Then
            _PrintOption = "Print"
        End If
        Select Case _PrintOption
            Case "Print"
                GridControl1.Print()
            Case "Preview"
                GridControl1.ShowPrintPreview()
            Case "Pdf"
                GridControl1.ExportToPdf("تقرير الدوام.pdf")
        End Select
        ColAddAndEdit.Visible = True
        '  ColRequiredDailyHoures.Visible = True
    End Sub

    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles AdvBandedGridView1.CustomSummaryCalculate

        If Summery = False Then Exit Sub

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
                    'e.TotalValue = CDec(e.TotalValue.TotalHours).ToString("00") & ":" & CDec(e.TotalValue.Minutes).ToString("00")

                    Dim _TimeSpanFunction As New TimeFunctions
                    Dim _TotalMinutes As Decimal = e.TotalValue.TotalMinutes
                    e.TotalValue = _TimeSpanFunction.ConvertTimeSpan_hhmmm_ToString(_TimeSpanFunction.ConvertFromDecimalToTimeSpan(_TotalMinutes / 60))

                    'e.TotalValue = FormatTimeSpanToHHMM(e.TotalValue)
                End If
                'If summaryID = 11 Then
                '    e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))
                'End If

                'If summaryID = 50 Then
                '    e.TotalValue = CDec(ColBonusHours.SummaryItem.SummaryValue / ColTransDay.SummaryItem.SummaryValue)
                'End If

                If summaryID = 17001 Then
                    e.TotalValue = GetEmpSalary(AdvBandedGridView1.GetRowCellValue(e.RowHandle, "EmpID"))
                    'e.TotalValue = Salary
                End If

                If summaryID = 15001 Then
                    e.TotalValue = Decimal.Round(ColMonthlySalary.SummaryItem.SummaryValue _
                                                 + ColDailyTransport.SummaryItem.SummaryValue _
                                                 + ColBonusHoursNIS.SummaryItem.SummaryValue _
                                                 - Colpayment.SummaryItem.SummaryValue _
                                                 + ColAdditions.SummaryItem.SummaryValue _
                                                 - ColLeavesHoursNIS.SummaryItem.SummaryValue _
                                                 - ColAbsentDaysAmount.SummaryItem.SummaryValue, 2)


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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            If LayoutDevice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always And Me.SearchDevice.Text <> String.Empty Then
                SqlString += " and sn='" & Me.SearchDevice.EditValue & "'"
            End If
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
            Dim SelectString As String = "  select SUM(PaymentAmount) as payment FROM [AttEmployeePayments] where [Status]=1 and [EmployeeID]='" & EmployeeID & "' and [PaymentDate] ='" & TransDate & "'"
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
                '.Parameters("SaleryPerHour").Value = ColSalaryPerHour.SummaryItem.SummaryValue
                '.Parameters("VocationSick").Value = GetSumVocationsThisYear(Me.SearchLookUpEdit1.EditValue, "مرضية")
                '   .Parameters("VocationAtEndYear").Value = VocationAtEndYear(Me.SearchLookUpEdit1.EditValue) + CInt(.Parameters("VocationBegBalance").Value) - CInt(.Parameters("AccruedVocationDays").Value)
                Dim _VocationDetails = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Today())
                .Parameters("VocationAtEndYear").Value = _VocationDetails.Balance
                .Parameters("AccruedVocationDays").Value = _VocationDetails.AccruedVocations
                .Parameters("VocationBegBalance").Value = _VocationDetails.BeginingBalance
                .Parameters("VocationSick").Value = 0
                .Parameters("HouresNetBonus").Value = ColBonusHours.SummaryItem.SummaryValue
                .Parameters("HouresNetLeaves").Value = ColLeavesHours.SummaryItem.SummaryValue

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
                                        Where P.[Status]=1 and [PaymentDate] BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
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
                      from [EmployeesData] E
                      where  E.[Active] =1 And E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 "

            If _FormType = "Dawam2" Or _FormType = "Rawateb2" Then
                SqlString += " And (ProcessType=3 or ProcessType is null )    "
            ElseIf _FormType = "MonthlyRequirdHoures" Then
                SqlString += " And (ProcessType=6 )    "
                'SqlString += " And (ProcessType=3 or ProcessType is null )    "
            ElseIf _FormType = "DailyAtt" Then
                SqlString += " And (ProcessType=7 )  "
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
                gridBand7.Visible = True
                gridBand13.Visible = True
            Case CheckState.Unchecked
                gridBand7.Visible = False
                gridBand13.Visible = False
        End Select
    End Sub

    Private Sub GridView1_CustomDrawRowFooterCell(ByVal sender As Object, ByVal e As FooterCellCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowFooterCell
        If e.Column Is ColNetSalaryNew Then
            Dim view As GridView = CType(sender, GridView)
            'Dim _Val1 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("17001"), GridGroupSummaryItem)))
            'Dim _Val2 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("BonusHoursNIS"), GridGroupSummaryItem)))
            'Dim _Val3 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Transport"), GridGroupSummaryItem)))
            'Dim _Val4 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("LeavesHoursNIS"), GridGroupSummaryItem)))
            'Dim _Val5 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Payment"), GridGroupSummaryItem)))
            'Dim _Val6 As Decimal = Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("AbsentDaysAmount"), GridGroupSummaryItem)))
            'MsgBox(_Val1 & "+" & _Val2 & "+" & _Val3 & "-" & _Val4 & "-" & _Val5 & "-" & _Val6)
            'Console.WriteLine(_Val1 & "+" & _Val2 & "+" & _Val3 & "-" & _Val4 & "-" & _Val5 & "-" & _Val6)
            e.Info.DisplayText = (CDec(Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("17001"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("BonusHoursNIS"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Additions"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Transport"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("LeavesHoursNIS"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Payment"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("AbsentDaysAmount"), GridGroupSummaryItem))))).ToString("n2")
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

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs)
        'ColNetLeavesHouresDaily.Visible = CheckShowColNetLeavesHouresDaily.CheckState
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
                BandedNote2.Visible = False
                Exit Sub
            Case False
                BandedNote1.Visible = True
                BandedNote2.Visible = True
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

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSaveAttData.ItemClick



        SaveSalary()
    End Sub
    Private Sub SaveSalary()
        Dim _DateFrom As String = Format(CDate(DateEdit1.DateTime), "yyyy-MM-dd")
        Dim _DateTo As String = Format(CDate(DateEdit2.DateTime), "yyyy-MM-dd")
        Dim SQl4 As New SQLControl
        Dim _ID As Integer = 0
        Dim Sql As New SQLControl
        Dim sqlString As String
        Try
            Dim SqlString4 As String
            SqlString4 = " Select [ID],ArchiveStatus  
                               From [AttRawatebArchive]
                               Where  [EmployeeID]='" & SearchLookUpEdit1.EditValue & "' and ((DateFrom  between '" & _DateFrom & "'  and '" & _DateTo & "' ) or 
                               (DateTo between '" & _DateFrom & "' and '" & _DateTo & "'   ))  "
            SQl4.SqlTrueTimeRunQuery(SqlString4)
            If SQl4.SQLDS.Tables(0).Rows.Count >= 1 Then
                If SQl4.SQLDS.Tables(0).Rows(0).Item("ArchiveStatus") = 0 Then
                    _ID = CInt(SQl4.SQLDS.Tables(0).Rows(0).Item("ID"))
                    'Dim Msg As DialogResult = XtraMessageBox.Show("يوجد قسيمة مرحلة، هل تريد حفظ التعديلات؟", "تحذير", MessageBoxButtons.YesNo)
                    'If Msg = System.Windows.Forms.DialogResult.No Then
                    '    Exit Sub
                    'End If
                End If

            ElseIf SQl4.SQLDS.Tables(0).Rows.Count >= 1 Then
                If SQl4.SQLDS.Tables(0).Rows(0).Item("ArchiveStatus") <> 0 Then
                    _ID = 0
                    XtraMessageBox.Show("بيانات الراتب مرحلة لا يمكن ترحيل القسيمة", "خطأ")
                    Exit Sub
                End If
            End If

            Dim HR_ActiveSavingFund As Boolean
            Try
                sqlString = " select SettingValue From Settings where SettingName ='HR_ActiveSavingFund'"
                Sql.SqlTrueTimeRunQuery(sqlString)
                If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    HR_ActiveSavingFund = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
                Else
                    HR_ActiveSavingFund = False
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try
            Dim connectionString As String = My.Settings.TrueTimeConnectionString
            Dim _EmployeeData = GetEmployeeData(SearchLookUpEdit1.EditValue)
            Dim _ActiveSavingFund As Boolean = _EmployeeData.ActiveSavingFund


            Dim _TimeFunction As New TimeFunctions
            Dim _MonthSalary As Decimal = 0
            Dim _NetSalary As Decimal = 0
            Dim _RequiredMonthlyHoures As String = "00:00"
            Dim _Payment As Decimal = 0
            Dim _BonusAmount As Decimal = 0
            Dim _Transport As Decimal = 0
            Dim _AdditionsAmount As Decimal = 0
            Dim _LeavesAmount As Decimal = 0
            Dim _BonusHours As String = ColBonusHours.SummaryItem.SummaryValue
            Dim _LeavesHoures As String = ColLeavesHours.SummaryItem.SummaryValue
            _BonusAmount = ColBonusHoursNIS.SummaryItem.SummaryValue
            _Payment = Colpayment.SummaryItem.SummaryValue
            _Transport = ColDailyTransport.SummaryItem.SummaryValue
            _AdditionsAmount = ColAdditions.SummaryItem.SummaryValue
            _LeavesAmount = ColLeavesHoursNIS.SummaryItem.SummaryValue

            _MonthSalary = _EmployeeData.MonthlySalary
            Dim _LeavesAfterMonthlyMaxLeavesHoures As TimeSpan = TimeSpan.Zero
            Dim _VocationNote As String = ""

            Select Case _EmployeeData.ProcessType
                Case 2
                    If _LeavesAmount > 0 Then
                        Dim _SalaryPerHour As Decimal
                        Dim _MaxMonthlyLeaves As TimeSpan = _EmployeeData.MonthlyMaxLeavesHoures
                        Dim _TotalleavesHours As TimeSpan = _TimeSpanFunction.ConvertText_hhmm_ToTimeSpan(ColLeavesHours.SummaryItem.SummaryValue)
                        _LeavesAfterMonthlyMaxLeavesHoures = _TotalleavesHours - _MaxMonthlyLeaves
                        If _MaxMonthlyLeaves > TimeSpan.Zero Then
                            If _LeavesAfterMonthlyMaxLeavesHoures > TimeSpan.Zero Then
                                _SalaryPerHour = SalaryPerHour
                                _LeavesAmount = (_TotalleavesHours.TotalHours - _MaxMonthlyLeaves.TotalHours) * _SalaryPerHour
                                If _LeavesAmount < 0 Then _LeavesAmount = 0
                            Else
                                _LeavesAmount = 0
                            End If
                        End If
                        If CalcLeavesDuringWorkFromVocations Then
                            _VocationNote = " خصم مغادرات خلال الدوام " & _LeavesAfterMonthlyMaxLeavesHoures.TotalHours.ToString("n2") & " ساعة " & " من الاجازات السنوية "
                        End If
                    End If



                    'If ProcessType = 2 And SubtractionLeavesAndLates = True Then
                    '    If ProcessType = 2 And SubtractionLeavesAndLates = True Then
                    '        Dim _MaxMonthlyLeaves As TimeSpan = _EmployeeData.MonthlyMaxLeavesHoures
                    '        Dim _SalaryPerHour As Decimal
                    '        If _MaxMonthlyLeaves > TimeSpan.Zero Then
                    '            Dim _TotalleavesHours As TimeSpan = _TimeSpanFunction.ConvertText_hhmm_ToTimeSpan(ColLeavesHours.SummaryItem.SummaryValue)
                    '            Dim _TotalleavesNIS As Decimal = CDec(ColLeavesHoursNIS.SummaryItem.SummaryValue)
                    '            If _TotalleavesHours > _MaxMonthlyLeaves Then
                    '                _SalaryPerHour = SalaryPerHour
                    '                _LeavesAmount = (_TotalleavesHours.TotalHours - _MaxMonthlyLeaves.TotalHours) * _SalaryPerHour

                    '                If _LeavesAmount < 0 Then _LeavesAmount = 0
                    '            Else
                    '                _LeavesAmount = 0
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    _NetSalary = ColNetSalaryNew.SummaryItem.SummaryValue
                    _RequiredMonthlyHoures = ColRequiredDailyHoures.SummaryItem.SummaryValue
                    _BonusHours = ColBonusHours.SummaryItem.SummaryValue
                Case 3
                    _MonthSalary = ColMonthlySalaryPerDay.SummaryItem.SummaryValue
                    _NetSalary = ColNetSalary.SummaryItem.SummaryValue
                    _RequiredMonthlyHoures = ColRequiredDailyHoures.SummaryItem.SummaryValue
                    _BonusHours = ColBonusHours.SummaryItem.SummaryValue
                Case 6
                    _MonthSalary = _EmployeeData.MonthlySalary
                    _NetSalary = _MonthSalary + _BonusAmount + _AdditionsAmount + _Transport - _Payment - _LeavesAmount
                    sqlString = " select SettingValue From Settings where SettingName ='AttInMonthSalaryAdjustmentsCalcRequHouresFromEmployee' "
                    If Sql.SqlTrueTimeRunQuery(sqlString) = True Then
                        _RequiredMonthlyHoures = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_EmployeeData.MonthlyHouresRequired)
                    Else
                        _RequiredMonthlyHoures = ColRequiredDailyHoures.SummaryItem.SummaryValue
                    End If
                    Dim _TotalDuration As TimeSpan = _TimeFunction.ConvertText_hhmm_ToTimeSpan(ColTotalDurations.SummaryItem.SummaryValue)
                    Dim _RequiredMonthlyHouresTimeSpan As TimeSpan = _TimeFunction.ConvertText_hhmm_ToTimeSpan(_RequiredMonthlyHoures)
                    If ColTotalDurations.SummaryItem.SummaryValue > _RequiredMonthlyHoures Then
                        Dim _BonusTimeSpan As TimeSpan = _TotalDuration - _RequiredMonthlyHouresTimeSpan
                        _BonusHours = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_BonusTimeSpan)
                        _LeavesHoures = "00:00"
                    ElseIf ColTotalDurations.SummaryItem.SummaryValue < _RequiredMonthlyHoures Then
                        Dim _LeavesTimeSpan As TimeSpan = _RequiredMonthlyHouresTimeSpan - _TotalDuration
                        _LeavesHoures = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_LeavesTimeSpan)
                        _BonusHours = "00:00"
                    End If
                Case 7
                    _MonthSalary = ColMonthlySalaryPerDay.SummaryItem.SummaryValue
                    _NetSalary = ColNetSalary.SummaryItem.SummaryValue
            End Select






            'Dim _MaxMonthlyLeaves As TimeSpan = _EmployeeData.MonthlyMaxLeavesHoures
            'Dim _LeavesAfterMonthlyMaxLeavesHoures As TimeSpan = TimeSpan.Zero
            'Dim _SalaryPerHour As Decimal
            'If _MaxMonthlyLeaves > TimeSpan.Zero Then
            '    Dim _TotalleavesHours As TimeSpan = _TimeSpanFunction.ConvertText_hhmm_ToTimeSpan(ColLeavesHours.SummaryItem.SummaryValue)
            '    Dim _TotalleavesNIS As Decimal = CDec(ColLeavesHoursNIS.SummaryItem.SummaryValue)
            '    If CalcLeavesDuringWorkFromVocations Then
            '        If _TotalleavesHours > _MaxMonthlyLeaves Then
            '            _LeavesAfterMonthlyMaxLeavesHoures = _TotalleavesHours - _MaxMonthlyLeaves
            '            If _LeavesAfterMonthlyMaxLeavesHoures < TimeSpan.Zero Then
            '                _LeavesAfterMonthlyMaxLeavesHoures = TimeSpan.Zero
            '            Else
            '                _SalaryPerHour = SalaryPerHour
            '                _LeavesAmount = (_TotalleavesHours.TotalHours - _MaxMonthlyLeaves.TotalHours) * _SalaryPerHour
            '            End If
            '        Else
            '            _LeavesAfterMonthlyMaxLeavesHoures = TimeSpan.Zero
            '        End If
            '    Else
            '        If _TotalleavesHours > _MaxMonthlyLeaves Then
            '            _SalaryPerHour = SalaryPerDay / 8
            '            _LeavesAmount = (_TotalleavesHours.TotalHours - _MaxMonthlyLeaves.TotalHours) * _SalaryPerHour
            '            If _LeavesAmount < 0 Then _LeavesAmount = 0
            '        Else
            '            _LeavesAmount = 0
            '        End If
            '    End If

            'End If





            sqlString = "    INSERT INTO [AttRawatebArchive]
                             ([DateFrom],[DateTo],[EmployeeID],
                              [EmployeeNoAsAcc],[EmployeeName],
                              [Branch],[Department],
                              [JobName],[BeginDate],
                              [Currency],[SalaryMonth],[BonusAmount]
                             ,[Transport],[Additions],[LeavesAmount],
                              [Payment],[GrossSalary],
                              [MonthDays],[ActualDays],
                              [VocationDays],[WeekOffDays],
                              [AbsenceDays],[HouresRequired],
                              [ActualHoures],[VocationBegBalance],[AccruedVocationDays],[VocationAtEndYear],[VocationSick]
                             ,[NetSalary],HouresNetBonus,HouresNetLeaves,
                              BankName,BankNo,BankBranch,IBAN,Indenty,[ArchiveStatus],
                              AbsenceAmount,ProcessType,SalaryPerHour,SalaryPerDay)
                           VALUES
                             ('" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "','" & SearchLookUpEdit1.EditValue & "',
                             '" & _EmployeeData.SalaryAccountNo & "', N'" & _EmployeeData.EmployeeName & "',
                             N'" & _EmployeeData.Branch & "',N'" & _EmployeeData.Department & "',
                             N'" & _EmployeeData.JobName & "','" & _EmployeeData.DateOfStart & "',
                             '" & _EmployeeData.SalaryCurrency & "','" & _MonthSalary & "','" & _BonusAmount & "',
                             '" & _Transport & "','" & _AdditionsAmount & "','" & _LeavesAmount & "',
                             '" & Colpayment.SummaryItem.SummaryValue & "','" & ColGrossSalary.SummaryItem.SummaryValue & "',
                             '" & ColTransDay.SummaryItem.SummaryValue & "','" & ColAttendentDays.SummaryItem.SummaryValue & "',
                             '" & ColVocationDays.SummaryItem.SummaryValue & "' ,'" & ColOffDays.SummaryItem.SummaryValue & "',
                             '" & ColAbsentDays.SummaryItem.SummaryValue & "','" & _RequiredMonthlyHoures & "',
                             '" & ColTotalDurations.SummaryItem.SummaryValue & "','" & 0 & "',
                             '" & 0 & "','" & 0 & "','" & 0 & "',
                             '" & _NetSalary & "','" & _BonusHours & "','" & ColLeavesHours.SummaryItem.SummaryValue & "',
                             N'" & _EmployeeData.BankName & "','" & _EmployeeData.BankAccountNo & "',N'" & _EmployeeData.BankBranch & "','" & _EmployeeData.Iban & "',
                             '" & _EmployeeData.Indenty & "',0,
                             '" & ColAbsentDaysAmount.SummaryItem.SummaryValue & "','" & _EmployeeData.ProcessType & "','" & _EmployeeData.SalaryPerHour & "','" & _EmployeeData.SalaryPerDay & "'); SELECT SCOPE_IDENTITY()"



            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sqlString, connection)
                    connection.Open()
                    Dim insertedId As Integer = CInt(command.ExecuteScalar())

                    If insertedId > 0 Then
                        Att_IssueDiscountAndAddsWhenPublishSalary(SearchLookUpEdit1.EditValue, DateEdit2.DateTime, insertedId)
                        UpdateAdditions(insertedId)
                        UpdatePayments(insertedId)
                        If _ActiveSavingFund = True And HR_ActiveSavingFund = True Then Att_InsertNewAttEmployeeSavingsFund(insertedId, SearchLookUpEdit1.EditValue, DateEdit2.DateTime, "")
                        If CalcLeavesDuringWorkFromVocations And _LeavesAfterMonthlyMaxLeavesHoures > TimeSpan.Zero And Vocation_Balance > 0 Then
                            VocationInsertNew(SearchLookUpEdit1.EditValue, 1, _VocationNote, DateEdit2.DateTime, DateEdit2.DateTime, DateEdit2.DateTime, _LeavesAfterMonthlyMaxLeavesHoures.TotalHours / 8, "leaves", "-", (_LeavesAfterMonthlyMaxLeavesHoures.TotalHours).ToString("n2"), insertedId)
                            UpodateLeavesAmountToZero(insertedId)
                        End If
                        If _LeavesAfterMonthlyMaxLeavesHoures = TimeSpan.Zero Then
                            UpodateLeavesAmountToZero(insertedId)
                        End If
                    Else
                        MsgBox(" لم يتم اصدار راتب ")
                        Exit Sub
                    End If

                    Sql.SqlTrueTimeRunQuery("  Update AttRawatebArchive Set  NetSalary=SalaryMonth+BonusAmount+Transport+Additions-LeavesAmount-AbsenceAmount-Payment-IsNull(SavingsFund,0) where ID=" & insertedId)
                    connection.Close()
                    If _PrintSalayDocument = True Then
                        PrintSalaryDocument(insertedId, "Print")
                    End If
                    If _OpenForPrint <> True Then
                        XtraMessageBox.Show(" تم الحفظ ", "تم", MessageBoxButtons.OK, MessageBoxIcon.None)
                    End If





                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        'If sql.SqlTrueTimeRunQuery(SqlString) = True Then
        '    If _OpenForPrint <> True Then
        '        XtraMessageBox.Show(" تم الحفظ ", "تم", MessageBoxButtons.OK, MessageBoxIcon.None)
        '    End If
        'Else
        '    XtraMessageBox.Show(" خطأ بالحفظ ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If
    End Sub
    Private Sub DeleteRelatedDocument(_ID As Integer)
        If _ID <> 0 Then
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = "  DELETE FROM AttRawatebArchive WHERE ID = '" & _ID & "';"
            sqlString += " DELETE FROM [AttEmployeeAdditions] WHERE [SalaryDocumentID]=" & _ID & ";"
            sqlString += " DELETE FROM [AttEmployeePayments]  WHERE [SalaryDocumentID]=" & _ID & ";"
            sqlString += " DELETE From SavingsFund Where SalaryDocumentID =" & _ID & ";"
            sqlString += " DELETE From [Vocations] Where SalaryDocumentID =" & _ID & ";"
            sql.SqlTrueTimeRunQuery(sqlString)
        End If
    End Sub
    Private Sub ReCalcAttRawatebArchive(insertedId As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update AttRawatebArchive Set  NetSalary=SalaryMonth+BonusAmount+Transport+Additions-LeavesAmount-AbsenceAmount-Payment-IsNull(SavingsFund,0) where ID=" & insertedId
        If sql.SqlTrueTimeRunQuery(sqlString) <> True Then
            XtraMessageBox.Show(" خطأ  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub UpodateLeavesAmountToZero(insertedId As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update AttRawatebArchive Set LeavesAmount=0 where ID=" & insertedId
        If sql.SqlTrueTimeRunQuery(sqlString) <> True Then
            XtraMessageBox.Show(" خطأ  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub UpdateAdditions(insertedId As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update [AttRawatebArchive] 
        Set Additions = ( Select IsNull(sum(AdditionAmount),0) from AttEmployeeAdditions A Where   A.EmployeeID=" & SearchLookUpEdit1.EditValue & " And (A.AdditionDate  between '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "'  and '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "' )) 
        Where [AttRawatebArchive].ID=" & insertedId
        If sql.SqlTrueTimeRunQuery(sqlString) <> True Then
            XtraMessageBox.Show(" خطأ  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub UpdatePayments(insertedId As Integer)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update [AttRawatebArchive] 
                      Set Payment = ( Select IsNull(sum(PaymentAmount),0) from AttEmployeePayments A Where [Status]=1 And A.EmployeeID=" & SearchLookUpEdit1.EditValue & " And (A.PaymentDate  between '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "'  and '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "' )) 
                       Where [AttRawatebArchive].ID=" & insertedId
        If sql.SqlTrueTimeRunQuery(sqlString) <> True Then
            XtraMessageBox.Show(" خطأ  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        With AdvBandedGridView1
            Dim _LeavesHours As TimeSpan, _BonusHours As TimeSpan, _EmpNo As Integer, _EmpName As String, _TransDate As Date
            Select Case .FocusedColumn.FieldName
                Case "BonusHours"
                    If GlobalVariables._AttDailyAdjustment = False Then Exit Sub
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
                    If GlobalVariables._AttDailyAdjustment = False Then Exit Sub
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
                Case "HrNotePerDay"
                    If IsDBNull(.GetFocusedRowCellValue("HrNotePerDay")) Then

                    Else
                        Dim EmpID As Integer = .GetFocusedRowCellValue("EmpID")
                        Dim TransDate As Date = .GetFocusedRowCellValue("TransDate")
                        .SetFocusedRowCellValue("HrNotePerDay", InsertHrNotePerDay(EmpID, TransDate.ToString("yyyy-MM-dd")))
                    End If
                Case Else
                    Exit Sub
            End Select
        End With

    End Sub

    Private Function InsertHrNotePerDay(EmployeeNo As Integer, AttDate As String) As String
        Dim LastNote As String
        LastNote = AdvBandedGridView1.GetFocusedRowCellValue("HrNotePerDay")
        Dim NewNote As String = ""
        Dim F As New AttAddHrNoteToAttReports
        With F
            .MemoEdit1.Text = LastNote
            If .ShowDialog() = DialogResult.OK Then
                NewNote = .MemoEdit1.Text ' Get the edited note from the dialog
            Else
                Return LastNote ' Return the original note if dialog was cancelled
            End If
        End With

        ' Return early if note is empty or unchanged
        If String.IsNullOrEmpty(NewNote) OrElse NewNote = LastNote Then
            Return LastNote
        End If

        Dim sql As New SQLControl
        Dim sqlString As String
        Dim _Exist As Boolean

        ' Check if record exists
        _Exist = sql.SqlTrueTimeRunQuery(" SELECT [AttNotes] FROM [AttHrNotesPerDayForAttReports] WHERE [EmployeeNo]=" & EmployeeNo & " AND [AttDate]='" & AttDate & "'")

        ' Escape single quotes in NewNote to prevent SQL injection
        Dim escapedNote As String = NewNote.Replace("'", "''")

        If _Exist = False OrElse sql.SQLDS.Tables(0).Rows.Count = 0 Then
            sqlString = " INSERT INTO [dbo].[AttHrNotesPerDayForAttReports] ([EmployeeNo],[AttDate],[AttNotes]) " &
                   " VALUES (" & EmployeeNo & ", '" & AttDate & "', N'" & escapedNote & "')"
        Else
            sqlString = " UPDATE [dbo].[AttHrNotesPerDayForAttReports] " &
                   " SET [AttNotes]=N'" & escapedNote & "' " &
                   " WHERE [EmployeeNo]=" & EmployeeNo & " AND [AttDate]='" & AttDate & "'"
        End If

        If sql.SqlTrueTimeRunQuery(sqlString) = True Then
            Return NewNote
        Else
            Return LastNote ' Return original note if update failed
        End If
    End Function

    Private Function GetHrNotePerMonth(EmployeeNo As Integer, AttDate As String) As String
        Dim LastNote As String = ""
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Select top(1) [AttNotes] From [AttHrNotesPerMonthForAttReports] 
Where EmployeeNo=" & EmployeeNo & " And 
AttDate Between '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' And '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
Order by AttDate Desc"
        sql.SqlTrueAccountingRunQuery(sqlString)

        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            LastNote = sql.SQLDS.Tables(0).Rows(0).Item("AttNotes").ToString()
        End If

        Return LastNote
    End Function


    Private Function InsertHrNotePerMonth(EmployeeNo As Integer, AttDate As String) As String
        Dim sql As New SQLControl
        Dim sqlString As String

        Dim LastNote As String
        Dim _Exist As Boolean
        Dim _LastNoteID As Integer = 0
        sqlString = " Select top(1) [AttNotes],[ID] From [AttHrNotesPerMonthForAttReports] 
Where EmployeeNo=" & EmployeeNo & " And 
AttDate Between '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' And '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
Order by AttDate Desc"
        sql.SqlTrueAccountingRunQuery(sqlString)

        If  sql.SQLDS.Tables(0).Rows.Count = 0 Then
            _Exist = False
            LastNote = String.Empty ' No previous note found
        Else
            _Exist = True
            LastNote = sql.SQLDS.Tables(0).Rows(0).Item("AttNotes").ToString()
            _LastNoteID = Integer.Parse(sql.SQLDS.Tables(0).Rows(0).Item("ID").ToString())
        End If


        Dim NewNote As String = ""
        Dim F As New AttAddHrNoteToAttReports
        With F
            .MemoEdit1.Text = LastNote
            If .ShowDialog() = DialogResult.OK Then
                NewNote = .MemoEdit1.Text ' Get the edited note from the dialog
            Else
                Return LastNote ' Return the original note if dialog was cancelled
            End If
        End With

        ' Return early if note is empty or unchanged
        If String.IsNullOrEmpty(NewNote) OrElse NewNote = LastNote Then
            Return LastNote
        End If

        If _Exist = False OrElse Sql.SQLDS.Tables(0).Rows.Count = 0 Then
            sqlString = " INSERT INTO [dbo].[AttHrNotesPerMonthForAttReports] ([EmployeeNo],[AttDate],[AttNotes]) " &
                   " VALUES (" & EmployeeNo & ", '" & AttDate & "', N'" & NewNote & "')"
        Else
            sqlString = " UPDATE [dbo].[AttHrNotesPerMonthForAttReports] " &
                   " SET [AttNotes]=N'" & NewNote & "' " &
                   " WHERE [ID]=" & _LastNoteID
        End If
        Me.AdvBandedGridView1.OptionsView.ShowViewCaption = True
        If Sql.SqlTrueTimeRunQuery(sqlString) = True Then
            Return NewNote
        Else
            Return LastNote ' Return original note if update failed
        End If
    End Function



    Private Function GetRequiredHours(_PlaneCode As Integer, _TransDate As Date) As TimeSpan
        Dim _date As String = Format(_TransDate, "yyyy-MM-dd")
        Dim _RequiredHours As TimeSpan
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select [RequiredHoures] 
                          from [dbo].[AttPlanForRequiredHours] 
                          where [PlanCode]=" & _PlaneCode & " and  AttTransDate ='" & _date & "' "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _RequiredHours = TimeSpan.Parse(sql.SQLDS.Tables(0).Rows(0).Item("RequiredHoures"))
            ' TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
        Catch ex As Exception
            _RequiredHours = TimeSpan.Zero
        End Try
        Return _RequiredHours
    End Function

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
        _PrintAtt = True
        PrintWithOption("Print")
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        _PrintAtt = False
        PrintWithOption("Preview")
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        AttPrintSettings.ShowDialog()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If SearchLookUpEdit1.Text = String.Empty Then
            MsgBoxShowError("يجب اختيار الموظف ")
            Exit Sub
        End If
        Dim _MobileNo As String
        _MobileNo = GetEmployeeData(SearchLookUpEdit1.EditValue).Mobile
        PrintWithOption("Pdf")
        SendFileToWhatsApp(_MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام", String.Empty, GetEmployeeData(SearchLookUpEdit1.EditValue).EmployeeName)
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        'If SearchLookUpEdit1.Text = "" Then
        '    MsgBoxShowError("يجب اختيار الموظف ")
        '    Exit Sub
        'End If
        'Dim _MobileNo As String
        '_MobileNo = GetEmployeeData(SearchLookUpEdit1.EditValue).Mobile
        'PrintWithOption("Pdf")
        'SendToWhatsApp(_MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام")


        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrintWithOption("Pdf")
                SendFileToWhatsApp(MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام", String.Empty, SearchLookUpEdit1.Text)
                MsgBoxShowSuccess(" تم ارسال التقرير بنجاح ")
            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Function GetEmployeeProduction(_EmpID As Integer, _TransDate As Date) As Decimal
        Dim _ProductionHours As Decimal
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select IsNull(Sum(Quantity),0) As Total
                          from [dbo].[SalaryByProduction] 
                          where [EmployeeID]=" & _EmpID & " and [From_] between '" & Format(_TransDate, "yyyy-MM-dd 00:00:00") & "' and '" & Format(_TransDate, "yyyy-MM-dd 23:59:59") & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _ProductionHours = CDec(sql.SQLDS.Tables(0).Rows(0).Item("Total"))
            ' TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
        Catch ex As Exception
            _ProductionHours = 0
        End Try
        Return _ProductionHours
    End Function

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Select Case _ShowAllEmployees
            Case True
                _ShowAllEmployees = False
            Case False
                _ShowAllEmployees = True
        End Select
    End Sub
    Private Sub AddQuickVocation()
        Dim j As Integer = 0
        Dim i As Integer
        Dim f As New VocationAddQuick
        With f
            If .ShowDialog <> DialogResult.OK And GlobalVariables._VocationTypeInQuickMode <> 0 Then
                Dim selectedRowHandles As Integer() = AdvBandedGridView1.GetSelectedRows()
                For i = 0 To selectedRowHandles.Length - 1
                    Dim value As Object = AdvBandedGridView1.GetRowCellValue(selectedRowHandles(i), "TransDate")
                    Try
                        Dim sql As New SQLControl
                        Dim VocDate As String = Format(CDate(AdvBandedGridView1.GetRowCellValue(selectedRowHandles(i), "TransDate")), "yyyy-MM-dd")
                        Dim EmpID As String = AdvBandedGridView1.GetRowCellValue(selectedRowHandles(i), "EmpID")
                        Dim SqlString As String = "   Insert Into Vocations " _
                                                      & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource)" _
                                                      & " Values ( " _
                                                      & String.Empty & EmpID & "," _
                                                      & "'" & VocDate & "'," _
                                                      & "N'" & GlobalVariables._VocationTypeInQuickMode & "'," _
                                                      & "'" & VocDate & "'," _
                                                      & "'" & VocDate & "'," _
                                                      & String.Empty & 1 & "," _
                                                      & "N'مجاز'," _
                                                      & "N'vocation'" _
                                                      & " ) "
                        If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                            j = j + 1
                        End If
                    Catch ex As Exception
                    End Try
                Next
                MsgBox(" تم عمل اجازات عدد " & j)
                'MsgBox(j) : MsgBox(selectedRowHandles.Length)
            End If

        End With
    End Sub
    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles BtnQuickVocation.Click
        AddQuickVocation()
    End Sub

    Private Sub BarCheckItem1_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItem1.CheckedChanged

    End Sub

    Private Sub BarAddEditMonthlyHrNotes_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarAddEditMonthlyHrNotes.ItemClick
        InsertHrNotePerMonth(Me.SearchLookUpEdit1.EditValue, Format(Me.DateEdit2.DateTime, "yyyy-MM-dd"))
    End Sub
    Private Sub PrintUsingMyGridReport(Optional action As String = "Preview", Optional outputPath As String = Nothing)
        'Dim _CompanyName As String = GetCompanyData.CompanyName
        Dim view As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView = Me.AdvBandedGridView1
        If view Is Nothing OrElse view.RowCount = 0 Then Exit Sub

        ' Resolve DataTable from the GridControl
        Dim dt As DataTable = TryCast(GridControl1.DataSource, DataTable)
        If dt Is Nothing Then
            Dim dv As DataView = TryCast(GridControl1.DataSource, DataView)
            If dv IsNot Nothing Then dt = dv.ToTable()
        End If
        If dt Is Nothing OrElse dt.Columns.Count = 0 Then Exit Sub

        ' Only visible columns (respects band visibility and order)
        ' Reverse the order for RTL layout
        Dim orderedCols = view.VisibleColumns _
.Cast(Of DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn)() _
.Where(Function(c) Not String.IsNullOrEmpty(c.FieldName)) _
.OrderByDescending(Function(c) c.VisibleIndex) _
.ToList()
        If orderedCols.Count = 0 Then Exit Sub

        ' Compute AttStatus counts (دوام/غياب/عطلة)
        Dim attColExists As Boolean = dt.Columns.Contains("AttStatus")
        Dim countHolidays As Integer = If(attColExists, dt.Select("AttStatus = 'عطلة'").Length, 0)
        Dim countAbsents As Integer = If(attColExists, dt.Select("AttStatus = 'غياب'").Length, 0)
        Dim countAttendance As Integer = If(attColExists, dt.Select("AttStatus = 'دوام'").Length, 0)

        ' Fourth param: اجازات = Sum(Voc)
        Dim vocSum As Decimal = 0D
        If dt.Columns.Contains("Voc") Then
            Try
                Dim obj = dt.Compute("Sum(Voc)", "")
                If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                    vocSum = Convert.ToDecimal(obj)
                End If
            Catch
                vocSum = 0D
            End Try
        End If

        ' Create XtraReport
        Dim report As New DevExpress.XtraReports.UI.XtraReport()

        ' Page setup (small left/right margins + RTL)
        report.Landscape = True
        report.PaperKind = System.Drawing.Printing.PaperKind.A4
        report.Margins = New System.Drawing.Printing.Margins(50, 50, 25, 30)
        report.Font = New DevExpress.Drawing.DXFont("Tahoma", 12.0F, DevExpress.Drawing.DXFontStyle.Bold)
        report.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        report.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True

        Dim usableWidthF As Single = report.PageWidth - report.Margins.Left - report.Margins.Right

        ' PageHeader
        Dim pageHeader As New DevExpress.XtraReports.UI.PageHeaderBand() With {.HeightF = 0}
        report.Bands.Add(pageHeader)

        Dim lblCompany As New DevExpress.XtraReports.UI.XRLabel() With {
.Text = GetCompanyData.CompanyName,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 12.0F, DevExpress.Drawing.DXFontStyle.Bold),
.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
.LocationF = New DevExpress.Utils.PointFloat(0, 0),
.SizeF = New System.Drawing.SizeF(usableWidthF, 24),
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        pageHeader.Controls.Add(lblCompany)

        Dim employeeNameText As String = If(String.IsNullOrEmpty(Me.SearchLookUpEdit1.Text), "", Me.SearchLookUpEdit1.Text)
        Dim empNo As String = Convert.ToString(Me.SearchLookUpEdit1.EditValue)
        Dim lblEmpName As New DevExpress.XtraReports.UI.XRLabel() With {
.Text = $"الموظف: {employeeNameText}" & $"رقم: {empNo}",
.Font = New DevExpress.Drawing.DXFont("Tahoma", 12.0F, DevExpress.Drawing.DXFontStyle.Bold),
.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft,
.LocationF = New DevExpress.Utils.PointFloat(0, 28),
.SizeF = New System.Drawing.SizeF(usableWidthF / 2.0F, 18),
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        pageHeader.Controls.Add(lblEmpName)



        ' Column headers table
        Dim headerTop As Single = 52.0F
        Dim headerTable As New DevExpress.XtraReports.UI.XRTable() With {
.WidthF = usableWidthF,
.LocationF = New DevExpress.Utils.PointFloat(0, headerTop),
.Borders = DevExpress.XtraPrinting.BorderSide.All,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 12.0F, DevExpress.Drawing.DXFontStyle.Bold),
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        Dim headerRow As New DevExpress.XtraReports.UI.XRTableRow() With {.HeightF = 28}

        ' Detail band + table
        Dim detailBand As New DevExpress.XtraReports.UI.DetailBand()
        report.Bands.Add(detailBand)

        Dim detailTable As New DevExpress.XtraReports.UI.XRTable() With {
.WidthF = usableWidthF,
.LocationF = New DevExpress.Utils.PointFloat(0, 0),
.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 12.0F, DevExpress.Drawing.DXFontStyle.Bold),
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        Dim detailRow As New DevExpress.XtraReports.UI.XRTableRow() With {.HeightF = 18}

        Dim totalWidth As Integer = Math.Max(1, orderedCols.Sum(Function(c) Math.Max(1, c.Width)))

        ' Build cells collections first, then add them in the correct order
        Dim headerCells As New List(Of DevExpress.XtraReports.UI.XRTableCell)()
        Dim detailCells As New List(Of DevExpress.XtraReports.UI.XRTableCell)()

        For Each col In orderedCols
            Dim weight As Double = Math.Max(1, col.Width) / totalWidth

            Dim hCell As New DevExpress.XtraReports.UI.XRTableCell() With {
    .Text = If(String.IsNullOrEmpty(col.Caption), col.FieldName, col.Caption),
    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
    .CanGrow = False,
    .Weight = weight,
    .RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
            headerCells.Add(hCell)

            Dim dCell As New DevExpress.XtraReports.UI.XRTableCell() With {
    .CanGrow = False,
    .Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0),
    .Weight = weight,
    .RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
            dCell.ExpressionBindings.Add(New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", $"[{col.FieldName}]"))

            ' Add color formatting for AttStatus field when value is "عطلة"
            ' Add color formatting for AttStatus field when value is "عطلة"
            If col.FieldName = "AttStatus" Then
                AddHandler dCell.BeforePrint, Sub(sender As Object, e As System.EventArgs)
                                                  Dim cell As DevExpress.XtraReports.UI.XRTableCell = DirectCast(sender, DevExpress.XtraReports.UI.XRTableCell)
                                                  If cell.Text = "عطلة" Then
                                                      cell.BackColor = System.Drawing.Color.LightGreen
                                                      cell.ForeColor = System.Drawing.Color.DarkGreen
                                                  ElseIf cell.Text = "غياب" Then
                                                      cell.BackColor = System.Drawing.Color.LightCoral
                                                      cell.ForeColor = System.Drawing.Color.DarkRed
                                                      'ElseIf cell.Text = "دوام" Then
                                                      '    cell.BackColor = System.Drawing.Color.LightBlue
                                                      '    cell.ForeColor = System.Drawing.Color.DarkBlue
                                                  Else
                                                      cell.BackColor = System.Drawing.Color.Transparent
                                                      cell.ForeColor = System.Drawing.Color.Black
                                                  End If
                                              End Sub
            End If

            If dt.Columns.Contains(col.FieldName) Then
                Dim t = dt.Columns(col.FieldName).DataType
                If t Is GetType(TimeSpan) Then
                    dCell.TextFormatString = "{0:hh\:mm}"
                    dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                ElseIf t Is GetType(DateTime) Then
                    If col.FieldName = "StartTimeReal1" OrElse col.FieldName = "EndTimeReal1" Then
                        dCell.TextFormatString = "{0:HH:mm}"
                    ElseIf col.FieldName = "TransDate" Then
                        dCell.TextFormatString = "{0:yyyy-MM-dd}"
                    Else
                        dCell.TextFormatString = "{0:yyyy-MM-dd HH:mm}"
                    End If
                    dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                ElseIf t Is GetType(Decimal) OrElse t Is GetType(Double) OrElse t Is GetType(Single) Then
                    dCell.TextFormatString = "{0:n2}"
                    dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                ElseIf t Is GetType(Integer) OrElse t Is GetType(Int64) OrElse t Is GetType(Int16) Then
                    dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                Else
                    dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                End If
            Else
                dCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            End If

            detailCells.Add(dCell)
        Next

        ' Add cells to rows (they're already in RTL order from OrderByDescending)
        For Each cell In headerCells
            headerRow.Cells.Add(cell)
        Next
        For Each cell In detailCells
            detailRow.Cells.Add(cell)
        Next

        headerTable.Rows.Add(headerRow)
        pageHeader.Controls.Add(headerTable)

        detailTable.Rows.Add(detailRow)
        detailBand.HeightF = detailRow.HeightF
        detailBand.Controls.Clear()
        detailBand.Controls.Add(detailTable)

        ' ReportFooter: totals row + parameters line + HR note + signatures
        Dim footerBand As New DevExpress.XtraReports.UI.ReportFooterBand() With {.HeightF = 280}
        report.Bands.Add(footerBand)

        Dim footerTable As New DevExpress.XtraReports.UI.XRTable() With {
.WidthF = usableWidthF,
.LocationF = New DevExpress.Utils.PointFloat(0, 0),
.Borders = DevExpress.XtraPrinting.BorderSide.All,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 8.0F, DevExpress.Drawing.DXFontStyle.Bold),
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        Dim footerRow As New DevExpress.XtraReports.UI.XRTableRow() With {.HeightF = 22}

        Dim rowsCount As Integer = dt.Rows.Count
        Dim footerCells As New List(Of DevExpress.XtraReports.UI.XRTableCell)()

        For Each col In orderedCols
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell() With {
    .CanGrow = False,
    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
    .Weight = Math.Max(1, col.Width) / totalWidth,
    .RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
            cell.Font = New DevExpress.Drawing.DXFont("Tahoma", 9.0F, DevExpress.Drawing.DXFontStyle.Bold)
            If col Is orderedCols.First() Then
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                'cell.Text = If(GlobalVariables._SystemLanguage = "Arabic", "الإجمالي", "Total")
                footerCells.Add(cell)
                Continue For
            End If

            If dt.Columns.Contains(col.FieldName) Then
                Dim t = dt.Columns(col.FieldName).DataType
                If t Is GetType(TimeSpan) Then
                    Dim total As TimeSpan = TimeSpan.Zero
                    For r As Integer = 0 To rowsCount - 1
                        If Not IsDBNull(dt.Rows(r)(col.FieldName)) Then total += CType(dt.Rows(r)(col.FieldName), TimeSpan)
                    Next
                    Dim hours As Integer = CInt(Math.Floor(total.TotalHours))
                    Dim minutes As Integer = total.Minutes
                    cell.Text = $"{hours:00}:{minutes:00}"
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                ElseIf t Is GetType(Decimal) OrElse t Is GetType(Double) OrElse t Is GetType(Single) Then
                    Dim sumDec As Decimal = 0D
                    For r As Integer = 0 To rowsCount - 1
                        If Not IsDBNull(dt.Rows(r)(col.FieldName)) Then sumDec += Convert.ToDecimal(dt.Rows(r)(col.FieldName))
                    Next
                    cell.Text = sumDec.ToString("n2")
                ElseIf t Is GetType(Int16) OrElse t Is GetType(Int32) OrElse t Is GetType(Int64) Then
                    Dim sumLng As Long = 0
                    For r As Integer = 0 To rowsCount - 1
                        If Not IsDBNull(dt.Rows(r)(col.FieldName)) Then sumLng += Convert.ToInt64(dt.Rows(r)(col.FieldName))
                    Next
                    cell.Text = sumLng.ToString("n0")
                Else
                    cell.Text = ""
                End If
            End If

            footerCells.Add(cell)
        Next

        ' Add footer cells to row
        For Each cell In footerCells
            footerRow.Cells.Add(cell)
        Next

        footerTable.Rows.Add(footerRow)
        footerBand.Controls.Add(footerTable)

        ' Calculate NetSalaryNew total for display
        Dim netSalaryTotal As Decimal = 0D
        If dt.Columns.Contains("NetSalary") Then
            Try
                For r As Integer = 0 To rowsCount - 1
                    If Not IsDBNull(dt.Rows(r)("NetSalary")) Then
                        netSalaryTotal += Convert.ToDecimal(dt.Rows(r)("NetSalary"))
                    End If
                Next
            Catch
                netSalaryTotal = 0D
            End Try
        End If
        netSalaryTotal = CDec(netSalaryTotal)
        ' Parameters: attendance/absence/holidays + vocations (Sum(Voc))
        Dim pAttendance As New DevExpress.XtraReports.Parameters.Parameter() With {.Name = "DaysAttendance", .Type = GetType(Integer), .Visible = False, .Value = countAttendance}
        Dim pAbsence As New DevExpress.XtraReports.Parameters.Parameter() With {.Name = "DaysAbsence", .Type = GetType(Integer), .Visible = False, .Value = countAbsents}
        Dim pHoliday As New DevExpress.XtraReports.Parameters.Parameter() With {.Name = "DaysHoliday", .Type = GetType(Integer), .Visible = False, .Value = countHolidays}
        Dim pVocations As New DevExpress.XtraReports.Parameters.Parameter() With {.Name = "DaysVocations", .Type = GetType(Decimal), .Visible = False, .Value = vocSum}
        Dim pNetSalary As New DevExpress.XtraReports.Parameters.Parameter() With {.Name = "NetSalaryTotal", .Type = GetType(Decimal), .Visible = False, .Value = netSalaryTotal}
        report.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {pAttendance, pAbsence, pHoliday, pVocations, pNetSalary})

        ' One-line text after totals: "دوام X , غياب Y , عطلة Z , اجازات W"
        Dim paramsTop As Single = footerTable.HeightF + 6
        Dim lblParams As New DevExpress.XtraReports.UI.XRLabel() With {
.LocationF = New DevExpress.Utils.PointFloat(0, paramsTop),
.WidthF = usableWidthF,
.HeightF = 20,
.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 9.0F, DevExpress.Drawing.DXFontStyle.Bold),
.Borders = DevExpress.XtraPrinting.BorderSide.None,
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        lblParams.ExpressionBindings.Add(New DevExpress.XtraReports.UI.ExpressionBinding(
"BeforePrint",
"Text",
"Concat('دوام ', ToStr(?DaysAttendance), ' , ', 'غياب ', ToStr(?DaysAbsence), ' , ', 'عطلة ', ToStr(?DaysHoliday), ' , ', 'اجازات ', ToStr(?DaysVocations))"
))
        footerBand.Controls.Add(lblParams)

        ' Add NetSalaryNew total display
        '        Dim netSalaryTop As Single = paramsTop + lblParams.HeightF + 6
        '        Dim lblNetSalary As New DevExpress.XtraReports.UI.XRLabel() With {
        '    .LocationF = New DevExpress.Utils.PointFloat(0, netSalaryTop),
        '    .WidthF = usableWidthF,
        '    .HeightF = 20,
        '    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight,
        '    .Font = New DevExpress.Drawing.DXFont("Tahoma", 9.0F, DevExpress.Drawing.DXFontStyle.Bold),
        '    .Borders = DevExpress.XtraPrinting.BorderSide.None,
        '    .RightToLeft = System.Windows.Forms.RightToLeft.Yes
        '}
        '        lblNetSalary.ExpressionBindings.Add(New DevExpress.XtraReports.UI.ExpressionBinding(
        '    "BeforePrint",
        '    "Text",
        '    "Concat('إجمالي صافي الراتب: ', FormatString('{0:n2}', ?NetSalaryTotal))"
        '))
        '        footerBand.Controls.Add(lblNetSalary)

        ' HR note (monthly)
        'Dim noteTop As Single = netSalaryTop + lblNetSalary.HeightF + 6

        Dim noteTop As Single = 23
        Dim noteText As String = GetHrNotePerMonth(Me.SearchLookUpEdit1.EditValue, Format(Me.DateEdit1.DateTime, "yyyy-MM-dd"))
        Dim lblNote As New DevExpress.XtraReports.UI.XRLabel() With {
.Text = noteText,
.LocationF = New DevExpress.Utils.PointFloat(0, noteTop),
.WidthF = usableWidthF,
.HeightF = 24,
.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
.Font = New DevExpress.Drawing.DXFont("Tahoma", 9.0F, DevExpress.Drawing.DXFontStyle.Bold),
.Borders = DevExpress.XtraPrinting.BorderSide.None,
.RightToLeft = System.Windows.Forms.RightToLeft.Yes
}
        footerBand.Controls.Add(lblNote)

        ' Signatures - Reverse order for RTL
        Dim sigTop As Single = noteTop + 34
        Dim sectionWidth As Single = usableWidthF / 3.0F
        Dim marginFromEdge As Single = 20.0F
        Dim signatures() As String = If(GlobalVariables._SystemLanguage = "Arabic",
New String() {"توقيع الإدارة", "توقيع المدير", "توقيع الموظف"},
New String() {"HR Signature", "Manager Signature", "Employee Signature"})

        For i As Integer = 0 To 2
            Dim x As Single = i * sectionWidth
            footerBand.Controls.Add(New DevExpress.XtraReports.UI.XRLabel() With {
    .Text = signatures(i),
    .LocationF = New DevExpress.Utils.PointFloat(x, sigTop),
    .WidthF = sectionWidth,
    .HeightF = 18,
    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
    .Font = New DevExpress.Drawing.DXFont("Tahoma", 8.5F, DevExpress.Drawing.DXFontStyle.Bold),
    .RightToLeft = System.Windows.Forms.RightToLeft.Yes
})
            footerBand.Controls.Add(New DevExpress.XtraReports.UI.XRLine() With {
    .LineWidth = 1,
    .LocationF = New DevExpress.Utils.PointFloat(x + marginFromEdge, sigTop + 22),
    .SizeF = New System.Drawing.SizeF(sectionWidth - (marginFromEdge * 2), 2)
})
        Next

        ' Data binding
        report.DataSource = dt

        ' Build (fit width)
        report.CreateDocument()
        report.PrintingSystem.ShowMarginsWarning = False
        report.PrintingSystem.Document.AutoFitToPagesWidth = 1

        ' Shrink loop to fit height (optional)
        Dim attempts As Integer = 0
        Do While report.PrintingSystem.Document.PageCount > 1 AndAlso attempts < 8
            attempts += 1
            headerTable.Font = New DevExpress.Drawing.DXFont(headerTable.Font.Name, Math.Max(6.0F, headerTable.Font.Size - 0.5F), DevExpress.Drawing.DXFontStyle.Bold)
            detailTable.Font = New DevExpress.Drawing.DXFont(detailTable.Font.Name, Math.Max(5.0F, detailTable.Font.Size - 0.5F))
            footerTable.Font = New DevExpress.Drawing.DXFont(footerTable.Font.Name, Math.Max(6.0F, footerTable.Font.Size - 0.5F), DevExpress.Drawing.DXFontStyle.Bold)
            headerRow.HeightF = Math.Max(18.0F, headerRow.HeightF - 2.0F)
            detailRow.HeightF = Math.Max(12.0F, detailRow.HeightF - 1.0F)
            footerRow.HeightF = Math.Max(18.0F, footerRow.HeightF - 2.0F)
            detailBand.HeightF = detailRow.HeightF
            report.CreateDocument()
            report.PrintingSystem.Document.AutoFitToPagesWidth = 1
        Loop

        ' Execute requested action
        Select Case action
            Case "Print"
                report.RightToLeft = System.Windows.Forms.RightToLeft.Yes
                report.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True
                report.Print()
            Case "Pdf"
                report.RightToLeft = System.Windows.Forms.RightToLeft.Yes
                report.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True
                Dim path As String = If(String.IsNullOrWhiteSpace(outputPath), "تقرير الدوام.pdf", outputPath)
                report.ExportToPdf(path)
                Dim filePath As String = IO.Path.Combine(Application.StartupPath, path)
                PrintExportedPDF(filePath)
            Case Else
                report.RightToLeft = System.Windows.Forms.RightToLeft.Yes
                report.RightToLeftLayout = DevExpress.Utils.DefaultBoolean.True
                Dim tool As New DevExpress.XtraReports.UI.ReportPrintTool(report)
                tool.ShowPreviewDialog()

        End Select
    End Sub
    Private Sub PrintExportedPDF(pdfFile As String)
        Try
            ' Check if file exists
            If Not IO.File.Exists(pdfFile) Then
                MessageBox.Show("PDF file not found: " & pdfFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Print using PowerShell command (works with Windows 8+)
            Dim psi As New ProcessStartInfo()
            psi.FileName = "powershell.exe"
            psi.Arguments = "-Command ""Start-Process -FilePath '" & pdfFile & "' -Verb Print -WindowStyle Hidden"""
            psi.CreateNoWindow = True
            psi.UseShellExecute = False
            psi.WindowStyle = ProcessWindowStyle.Hidden

            Dim process As Process = Process.Start(psi)
            process.WaitForExit()

        Catch ex As Exception
            ' Fallback to basic shell execute
            Try
                Process.Start(New ProcessStartInfo(pdfFile) With {
                .Verb = "print",
                .CreateNoWindow = True,
                .WindowStyle = ProcessWindowStyle.Hidden,
                .UseShellExecute = True
            })
            Catch fallbackEx As Exception
                MessageBox.Show("Error printing PDF: " & ex.Message & vbCrLf & "Fallback error: " & fallbackEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Try
    End Sub
    ' Example: reuse the existing toolbar action to use MyGridReport instead of PrintableComponentLink
    Private Sub BarButtonItem6_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        ' Make grid rows compact before printing
        Me.ColEmpID.Visible = False
        ColAddAndEdit.Visible = False
        AdvBandedGridView1.OptionsView.RowAutoHeight = False
        AdvBandedGridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        AdvBandedGridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        PrintUsingMyGridReport()
        ColAddAndEdit.Visible = True
    End Sub
    Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        ' Make grid rows compact before printing
        Me.ColEmpID.Visible = False
        ColAddAndEdit.Visible = False
        AdvBandedGridView1.OptionsView.RowAutoHeight = False
        AdvBandedGridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        AdvBandedGridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter

        'PrintUsingMyGridReport()
        PrintUsingMyGridReport("Pdf", Nothing)
        ColAddAndEdit.Visible = True
    End Sub
    Private Sub ApplyPrintVisibleColumnsOnly()
        For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In AdvBandedGridView1.Columns
            col.OptionsColumn.Printable = If(col.Visible, DevExpress.Utils.DefaultBoolean.True, DevExpress.Utils.DefaultBoolean.False)
        Next
    End Sub



    ' Event: Draw footer on the last page
    Private Sub Link_CreateReportFooterArea(sender As Object, e As CreateAreaEventArgs)
        Try
            ' Footer text with better formatting
            Dim footerText As String = GetHrNotePerMonth(Me.SearchLookUpEdit1.EditValue, Me.DateEdit1.DateTime)

            ' Vertical spacing
            Dim yOffset As Single = 30
            Dim signatureSpacing As Single = 80

            ' Draw footer text
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
            e.Graph.Font = New Font("Tahoma", 10, FontStyle.Bold)
            e.Graph.BackColor = Color.Transparent   ' <-- مهم لإزالة الخلفية
            e.Graph.DrawString(footerText, Color.Black,
                       New RectangleF(0, yOffset, e.Graph.ClientPageSize.Width, 25),
                       BorderSide.None)

            ' Signature section
            Dim signatureYOffset As Single = yOffset + signatureSpacing
            Dim sectionWidth As Single = e.Graph.ClientPageSize.Width / 3
            Dim lineHeight As Single = 25
            Dim marginFromEdge As Single = 20

            ' Configure signature formatting
            e.Graph.StringFormat = New BrickStringFormat(StringAlignment.Center)
            e.Graph.Font = New Font("Tahoma", 9, FontStyle.Regular)
            e.Graph.BackColor = Color.Transparent   ' <-- مهم لإزالة الخلفية
            ' Define signature labels (with Arabic support)
            Dim signatures() As String = If(GlobalVariables._SystemLanguage = "Arabic",
                                   {"توقيع الموظف", "توقيع المدير", "توقيع الإدارة"},
                                   {"Employee Signature", "Manager Signature", "HR Signature"})

            ' Draw each signature section
            For i As Integer = 0 To 2
                Dim xPosition As Single = i * sectionWidth

                ' Draw signature label
                e.Graph.DrawString(signatures(i), Color.Black,
                           New RectangleF(xPosition, signatureYOffset, sectionWidth, lineHeight),
                           BorderSide.None)

                ' Draw signature line using PointF parameters
                Dim startPoint As New PointF(xPosition + marginFromEdge, signatureYOffset + lineHeight + 5)
                Dim endPoint As New PointF(xPosition + sectionWidth - marginFromEdge, signatureYOffset + lineHeight + 5)
                e.Graph.DrawLine(startPoint, endPoint, Color.Black, 1.5F)

            Next

        Catch ex As Exception
            ' Log error or handle gracefully
            Console.WriteLine("Error creating report footer: " & ex.Message)
        End Try
    End Sub




    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles AdvBandedGridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.ShowMarginsWarning = False

        pb.PageSettings.LeftMargin = 20
        pb.PageSettings.RightMargin = 20
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        ' إعدادات طباعة إضافية
        'AdvBandedGridView1.AppearancePrint.Row.Font = New Font("Tahoma", 6, FontStyle.Regular)
        'AdvBandedGridView1.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

        'AdvBandedGridView1.OptionsPrint.AutoWidth = DevExpress.Utils.DefaultBoolean.True


        With AdvBandedGridView1.AppearancePrint
            .Row.Font = New Font("Tahoma", 6, FontStyle.Regular)
            .HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)
            '.Row.Options.UseFont = True
            '.HeaderPanel.Options.UseFont = True
            '.Row.Options.UseTextOptions = True
            '.Row.GetFontHeight = Function() 6 ' تعيين ارتفاع الخط للصفوف
            '.Appearance.Row.Font = New Font("Tahoma", 6, FontStyle.Regular)
            '.Appearance.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)
            '.OptionsView.RowAutoHeight = False ' تعطيل الارتفاع التلقائي
            '.OptionsView.ShowGroupPanel = False ' إخفاء لوحة التجميع لتوفير مساحة
        End With

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
                'Tawqe3_2 = " .................:Employee signature" & "  " & vbCrLf & vbCrLf & vbCrLf & Tawqe3 = " .................:Management signature"
            Else
                _VocationString = " رصيد أول الفترة: " & _VocationBalances.BeginingBalance & "  " & vbCrLf &
                                  " اجازات مستوفاه خلال السنة : " & _VocationBalances.ThisYearVocations & "  " & vbCrLf &
                                  " رصيد الاجازات لنهاية العام : " & _VocationBalances.Balance & "  " & vbCrLf &
                                  " رصيد الاجازات لتاريخ اليوم : " & _VocationBalances.AccruedVocations & "  "
                Tawqe3 = _VocationString
                'Tawqe3_2 = vbCrLf & " _________________________________ :توقيع الموظف" & "  " & vbCrLf & vbCrLf & " _________________________________ :توقيع المدير " & vbCrLf & vbCrLf & " _________________________________ :توقيع الادارة "
            End If
        Else
            pb.PageSettings.TopMargin = 50
            pb.PageSettings.BottomMargin = 50
        End If



        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, "Pages: [Page # of Pages #]"})
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







    'Dim hrNote As String = GetHrNotePerMonth(Me.SearchLookUpEdit1.EditValue, Me.DateEdit1.DateTime)
    'If hrNote <> "" Then
    'Me.AdvBandedGridView1.ViewCaption = hrNote
    'Me.AdvBandedGridView1.OptionsView.ShowViewCaption = True
    'Else
    'Me.AdvBandedGridView1.ViewCaption = ""
    'Me.AdvBandedGridView1.OptionsView.ShowViewCaption = False
    'End If

End Class



