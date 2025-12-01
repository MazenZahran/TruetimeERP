Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Globalization
Imports DevExpress.CodeParser
Imports DevExpress.DataProcessing
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTreeList.Data

Public Class AttRawatebByShift

    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean
    Dim Salary As Decimal = 0
    Dim SalaryPerDay As Decimal = 0
    Dim SalaryPerDayPerMonth As Decimal = 0
    Dim DailyTransport As Decimal = 0
    Dim Payment As Decimal = 0
    Dim Additions As Decimal = 0
    Dim FactorLate As Decimal = 1
    Dim BonusPerHour As Decimal = 1
    Dim _CalcBonusAfterMinitues As Decimal = 1
    Dim _BonusPerHourAferPeriod1 As Decimal = 0
    Dim SalaryAccountNo As String = String.Empty
    Dim DaysPerMonth As String = "0"
    Dim VocationPaid2 As Boolean
    Dim _FormType As String
    Dim _AddBonusBeforeShift As Boolean = True
    Dim BonusOnDayOff As Decimal = 1
    Dim TempElapseTimeas As TimeSpan = TimeSpan.Zero
    Dim RequiredDailyHoures As TimeSpan = TimeSpan.Zero
    Dim BonusAmountAfterRequirdHoures As String = "0"
    Dim SubtractionLeavesAndLates As Boolean = True
    Dim AddBonusToSalary As Boolean = True
    Dim MaxLeavesHoures As String = "00:00"
    Dim ProcessType As String = String.Empty
    Dim _DateOfStart As String = "1900-01-01"
    Dim _DateOfEnd As String = "2100-01-01"
    Dim _BonusFirstPeriod As Integer = 0
    Dim _BonusFirstPeriodFactor As Integer = 100
    Dim _BonusSecondPeriodFactor As Integer = 100
    Dim _SalaryPerHourFromEmployeeData As Decimal = 0
    Dim _GetSalaryPerHourFromEmployee_ShiftReport As Boolean
    Dim _AdditionsFound As Boolean
    Dim _PaymentFound As Boolean
    Dim _VocationsFound As Boolean
    Dim _EmployeesCount As Integer = 0
    Dim _CurrentEmployeeHandle As Integer = 0
    Dim _UseLocalDataBaseForReport As Boolean = False
    Dim _AttCalcBonusBerforePeriodInMinutes As Integer
    Dim _AttCalcBonusAfterPeriodMinutes As Integer
    Public _OpenForPrint As Boolean
    Public _PrintSalayDocument As Boolean
    Public _PrintAtt As Boolean
    Public _EmployeeIDFromSalariesPublish As Integer
    Public _PrintSalary As Boolean
    Public _TheOptionPrint As String
    Private _SubtractAbsenceFromHolidays As Boolean
    Private _CalAbsentInSalary As Boolean
    Private _TimeSpanFunction As New TimeFunctions
    Dim attDataTable As New DataTable
    Private CalcLeavesDuringWorkFromVocations As Boolean
    Private _AdjustMorningLateToZeroIfRequestFound As Boolean
    Private Vocation_BeginingBalance As Decimal
    Private Vocation_ThisYearVocations As Decimal
    Private Vocation_Balance As Decimal
    Private Vocation_AccruedVocations As Decimal
    Public PrintScale As Decimal = 100D

    Public Sub New()
        InitializeComponent()
        '  MsgBox("Start")
        BandedGridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        BandedGridView1.OptionsView.AllowHtmlDrawGroups = True
    End Sub

    Dim SelectedRowHandles
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButtonUpdate.Click

        UpdateDataForAttRawatebByShift()
        'BandedGridView1.OptionsSelection.MultiSelect = True
        'BandedGridView1.SelectAll()
        'selectedRowHandles = BandedGridView1.GetSelectedRows()
        'Dim tempGC As GridControl = New GridControl()
        'tempGC.Parent = New Form()
        'tempGC.ForceInitialize()
        'Dim tempGV As GridView = TryCast(tempGC.MainView, GridView)
        'tempGV.Assign(BandedGridView1, False)
        '' tempGV.CustomRowFilter += AddressOf tempGV_CustomRowFilter
        'tempGC.DataSource = GridControl1.DataSource
        'tempGC.ShowPrintPreview()


    End Sub
    'Private Sub tempGV_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)
    '    Dim gv As GridView = TryCast(sender, GridView)
    '    e.Visible = selectedRowHandles.Contains(gv.GetRowHandle(e.ListSourceRow))
    '    e.Handled = True
    'End Sub



    Public Sub UpdateDataForAttRawatebByShift()
        My.Forms.Main.ItemElapseTime.Caption = "0"
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        start_time = Now

        GridControl1.DataSource = String.Empty
        Summery = False
        GetSettings()
        Try

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
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
            If _EmployeeIDFromSalariesPublish <> 0 Then
                _EmpID = _EmployeeIDFromSalariesPublish
            End If
            If _UseLocalDataBaseForReport = True Then
                If ToLocalAttTrans(DateEdit1.DateTime, DateEdit2.DateTime, _EmpID) < 0 Then
                    GoTo HH
                End If
            End If
            _CalAbsentInSalary = 1
            SQLString = "Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],Salary,DailyTransport ,FactorLate,BonusPerHour,
                                 SalaryAccountNo,RequiredDailyHoures,[SalaryPerHour],SubtractionLeavesAndLates,AddBonusToSalary,
                                 MaxLeavesHoures,ProcessType,BonusOnDayOff,DateOfStart,DateOfEnd,IsNull(CalAbsentInSalary,0) as CalAbsentInSalary,
                                 IsNull(CalcBonusAfterMinitues,0) as CalcBonusAfterMinitues,IsNull(BonusPerHourAferPeriod1,1) as BonusPerHourAferPeriod1
                         From EmployeesData"

            SQLString += " Where (ProcessType ='1' Or ProcessType='4' Or ProcessType='5' )   "
            SQLString += " And (EmployeeID <>'-999' and EmployeeID<>'-9999'  and EmployeeID<>'9999' )   "



            '_AttShowAllEmployeesInAttReports
            If CheckEditCheckActive.Checked = True Then SQLString += "and EmployeesData.Active = 1  "
            If _EmpID <> -1 Then
                'colEmployeeName.Visible = False
                CollEmployeeName.Visible = False
                SQLString = SQLString + " And EmployeeID = " & _EmpID
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

                SplashScreenManager.CloseForm(False)
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

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("Salary")) Then
                        Salary = Format(CDec(EmployeesTable.Rows(j).Item("Salary")), "0.00")
                    Else
                        Salary = 0
                    End If

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("Salary")) Then
                        Select Case DaysPerMonth
                            Case "DaysInMonth"
                                SalaryPerDay = Format(Salary / DateTime.DaysInMonth(CDate(DateEdit1.DateTime).Year, CDate(DateEdit1.DateTime).Month), "0.00")
                            Case Else
                                SalaryPerDay = Format(CDec(EmployeesTable.Rows(j).Item("Salary")) / CDec(DaysPerMonth), "0.00")
                        End Select
                    End If


                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DailyTransport")) Then DailyTransport = Format(CDec(EmployeesTable.Rows(j).Item("DailyTransport")), "0.00")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("FactorLate")) Then FactorLate = Format(CDec(EmployeesTable.Rows(j).Item("FactorLate")), "0.00")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHour")) Then BonusPerHour = Format(CDec(EmployeesTable.Rows(j).Item("BonusPerHour")), "0.00")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("CalcBonusAfterMinitues")) Then _CalcBonusAfterMinitues = Format(CDec(EmployeesTable.Rows(j).Item("CalcBonusAfterMinitues")), "0.00")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusPerHourAferPeriod1")) Then _BonusPerHourAferPeriod1 = Format(CDec(EmployeesTable.Rows(j).Item("BonusPerHourAferPeriod1")), "0.00")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates")) Then SubtractionLeavesAndLates = CBool(EmployeesTable.Rows(j).Item("SubtractionLeavesAndLates"))

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("AddBonusToSalary")) Then AddBonusToSalary = CBool(EmployeesTable.Rows(j).Item("AddBonusToSalary"))

                    MaxLeavesHoures = "00:00"
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("MaxLeavesHoures")) Then
                        MaxLeavesHoures = EmployeesTable.Rows(j).Item("MaxLeavesHoures")
                    Else
                        MaxLeavesHoures = "00:00"
                    End If

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryAccountNo")) Then SalaryAccountNo = EmployeesTable.Rows(j).Item("SalaryAccountNo")
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("ProcessType")) Then ProcessType = EmployeesTable.Rows(j).Item("ProcessType")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("BonusOnDayOff")) Then BonusOnDayOff = EmployeesTable.Rows(j).Item("BonusOnDayOff")

                    _DateOfStart = "1900-01-01"
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfStart")) Then _DateOfStart = Format(CDate(EmployeesTable.Rows(j).Item("DateOfStart")), "yyyy-MM-dd")

                    _DateOfEnd = "2100-01-01"
                    If Not IsDBNull(EmployeesTable.Rows(j).Item("DateOfEnd")) Then _DateOfEnd = Format(CDate(EmployeesTable.Rows(j).Item("DateOfEnd")), "yyyy-MM-dd")

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("RequiredDailyHoures")) Then
                        RequiredDailyHoures = TimeSpan.Parse(EmployeesTable.Rows(j).Item("RequiredDailyHoures"))
                    Else
                        RequiredDailyHoures = TimeSpan.FromHours(8)
                    End If

                    If RequiredDailyHoures.TotalHours > 20 Then
                        RequiredDailyHoures = TimeSpan.FromHours(8)
                    End If

                    If Not IsDBNull(EmployeesTable.Rows(j).Item("SalaryPerHour")) Then
                        _SalaryPerHourFromEmployeeData = CDec(EmployeesTable.Rows(j).Item("SalaryPerHour"))
                    Else
                        _SalaryPerHourFromEmployeeData = 0
                    End If

                    _CalAbsentInSalary = CBool(EmployeesTable.Rows(j).Item("CalAbsentInSalary"))

                    Vocation_Balance = 0
                    Vocation_BeginingBalance = 0
                    Vocation_ThisYearVocations = 0
                    Vocation_AccruedVocations = 0
                    Dim _VocationBalances = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Me.DateEdit2.DateTime)
                    Vocation_Balance = _VocationBalances.Balance
                    Vocation_BeginingBalance = _VocationBalances.BeginingBalance
                    Vocation_ThisYearVocations = _VocationBalances.ThisYearVocations
                    Vocation_AccruedVocations = _VocationBalances.AccruedVocations

                    DataTable.Merge(QueryData(EmpID))

                End If
            Next
            Summery = True

            GridControl1.DataSource = DataTable
            attDataTable = DataTable
            'If SearchLookUpEdit1.EditValue = "0" Or IsNothing(SearchLookUpEdit1.Text) Then
            '    ColEmpID.Visible = True
            '    CollEmployeeName.Visible = True
            'Else
            '    ColEmpID.Visible = False
            '    CollEmployeeName.Visible = False
            'End If



HH:
            SplashScreenManager.CloseForm(False)
            stop_time = Now
            elapsed_time = stop_time.Subtract(start_time)
            My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AttReportAndProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LayoutControl1.AllowCustomization = False
        LayoutControl2.AllowCustomization = False
        ' SearchLookUpEdit1.Text = String.Empty
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)

        'Me.DateEdit2.DateTime = Today
        'Dim startDt As New Date(Today.Year, Today.Month, 1)
        'Me.DateEdit1.DateTime = startDt



        Me.KeyPreview = True

        gridBand3.Visible = False
        gridBand4.Visible = False
        gridBand5.Visible = False
        gridBand2.Visible = False
        '  BandedGridView1.CustomSummaryCalculate += New EventHandler(BandedGridView1_CustomSummaryCalculate)
        '   myButton.Click += New EventHandler(myButton_Click)
        '  SoftLanguage()

        GetSettings()
        If _FormType = "Dawam" Then
            CheckEdit1.Checked = True
            gridBand7.Visible = False
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Me.Text = "تقرير الدوام حسب الوردية"
            If GlobalVariables._SystemLanguage = "English" Then
                Me.Text = "Attendant Shift Report"
            End If
            BarPublishSalary.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            SimpleButton1.Visible = False
        ElseIf _FormType = "Rawateb" Then
            CheckEdit1.Checked = False
            gridBand7.Visible = True
            LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            MsgBox("Error No Defined Form Type")
        End If


        '  MsgBox("Start")

        If GlobalVariables._SystemLanguage = "English" Then
            ColEnglishStatus.Visible = True
            ColAttStatus.Visible = False
        Else
            ColEnglishStatus.Visible = False
            ColAttStatus.Visible = True
        End If


        If GlobalVariables._EndDate < Today Then
            DateEdit2.Enabled = False
            DateEdit2.DateTime = GlobalVariables._EndDate
        End If

        LookUpEdit10.Properties.DataSource = GetGroupByTable()
        LookUpEdit10.Properties.ValueMember = "id"

        If GlobalVariables._SystemLanguage = "Arabic" Then
            LookUpEdit10.Properties.DisplayMember = "GroupName"
            LookUpEdit10.Properties.Columns("GroupNameEn").Visible = False
        Else
            LookUpEdit10.Properties.DisplayMember = "GroupNameEn"
            LookUpEdit10.Properties.Columns("GroupName").Visible = False
        End If
        LookUpEdit10.EditValue = 1
        _AdjustMorningLateToZeroIfRequestFound = False
        If _OpenForPrint = True Then
            UpdateDataForAttRawatebByShift()
            If _PrintSalary = True Then SaveSalary()
            PrintWithOption(_TheOptionPrint)
            _OpenForPrint = False
            Me.Close()
        End If
        RadioGroup1.EditValue = "last"
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
            Dim DaysInMonthParameter As String
            SqlString = " select SettingValue From Settings where SettingName ='DaysInMonth'"
            sql.SqlTrueTimeRunQuery(SqlString)
            DaysInMonthParameter = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Select Case DaysInMonthParameter
                Case "DaysInMonth"
                    DaysPerMonth = "DaysInMonth"
                Case "DaysInMonth-OffDays"
                    DaysPerMonth = "DaysInMonth-OffDays"
                Case Else
                    DaysPerMonth = CDec(DaysInMonthParameter)
            End Select
        Catch ex As Exception
            DaysPerMonth = 30
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            SqlString = " select SettingValue From Settings where SettingName ='BonusAmountAfterRequirdHoures'"
            sql.SqlTrueTimeRunQuery(SqlString)
            BonusAmountAfterRequirdHoures = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            BonusAmountAfterRequirdHoures = "0"
            XtraMessageBox.Show(ex.ToString)
        End Try

        Select Case BonusAmountAfterRequirdHoures
            Case 1
                ColLeaveSpanNet.Visible = True
                ColBonusSpanNet.Visible = True
                ColLeaves.Visible = False
                ColBonusSpanTotal.Visible = False
            Case 0
                ColLeaveSpanNet.Visible = False
                ColBonusSpanNet.Visible = False
                ColLeaves.Visible = True
                ColBonusSpanTotal.Visible = True
        End Select



        Try
            SqlString = " select SettingValue From Settings where SettingName ='TempForOpenForms'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _FormType = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _FormType = "0"
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='AddBonusBeforeShift'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _AddBonusBeforeShift = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _AddBonusBeforeShift = True
            ' XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            SqlString = " select SettingValue From Settings where SettingName ='GetSalaryPerHourFromEmployee_ShiftReport'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _GetSalaryPerHourFromEmployee_ShiftReport = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _GetSalaryPerHourFromEmployee_ShiftReport = False
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
            SqlString = " select SettingValue From Settings where SettingName ='SubtractAbsenceFromHolidays'"
            sql.SqlTrueTimeRunQuery(SqlString)
            _SubtractAbsenceFromHolidays = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _SubtractAbsenceFromHolidays = False
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            SqlString = " select SettingValue From Settings where SettingName ='HR_CalcLeavesDuringWorkFromVocations'"
            sql.SqlTrueTimeRunQuery(SqlString)
            CalcLeavesDuringWorkFromVocations = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            CalcLeavesDuringWorkFromVocations = False
            XtraMessageBox.Show(ex.ToString)
        End Try




    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            UpdateDataForAttRawatebByShift()
        ElseIf e.KeyCode = Keys.Insert Then
            InsertSub()
        ElseIf e.KeyCode = Keys.F12 Then
            PrintWithOption("Preview")
        ElseIf e.Control AndAlso e.KeyCode = Keys.Up Then
            If RadioGroup1.EditValue = "today" Or RadioGroup1.EditValue = "yesterday" Then
                DateEdit1.DateTime = DateEdit1.DateTime.AddDays(1)
                DateEdit2.DateTime = DateEdit2.DateTime.AddDays(1)
                UpdateDataForAttRawatebByShift()
            End If
        ElseIf e.Control AndAlso e.KeyCode = Keys.Down Then
            If RadioGroup1.EditValue = "today" Or RadioGroup1.EditValue = "yesterday" Then
                DateEdit1.DateTime = DateEdit1.DateTime.AddDays(-1)
                DateEdit2.DateTime = DateEdit2.DateTime.AddDays(-1)
                UpdateDataForAttRawatebByShift()
            End If
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        'Dim groupSum As Double = Convert.ToDouble(BandedGridView1.GetGroupSummaryValue(-1, TryCast(BandedGridView1.GroupSummary(0), GridGroupSummaryItem)))
        ' ShowPrint()
        IterateGroupRows()
    End Sub
    Function GetGroupByTable() As DataTable
        ' Create new DataTable instance.
        Dim table As New DataTable

        ' Create 3 typed columns in the DataTable.
        table.Columns.Add("id", GetType(Integer))
        table.Columns.Add("GroupName", GetType(String))
        table.Columns.Add("GroupNameEn", GetType(String))


        ' Add five rows with those columns filled in the DataTable.
        table.Rows.Add(1, "اسم الموظف", "Employee Name")
        table.Rows.Add(2, "التاريخ", "Date")
        table.Rows.Add(3, "اليوم", "Day")

        Return table
    End Function
    Public Sub IterateGroupRows()



        Try
            Dim s As Integer = 0
            Dim i As Integer = -1

            While BandedGridView1.IsValidRowHandle(i)

                If BandedGridView1.IsGroupRow(i) Then
                    Dim row As DataRow = BandedGridView1.GetDataRow(BandedGridView1.GetDataRowHandleByGroupRowHandle(i))

                    '   If CInt(row.ItemArray(0)) = 2 Then
                    Dim val1 As Decimal = Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(i, TryCast(BandedGridView1.GroupSummary(14), GridGroupSummaryItem)))
                    '   Dim val2 As Decimal = Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(i, TryCast(BandedGridView1.GroupSummary(6), GridGroupSummaryItem)))
                    s += val1
                    ' End If
                Else
                    Return
                End If

                i -= 1
            End While

            '    Text = s
            MsgBox(s)

        Catch ex As Exception

        End Try



        '  Convert.ToDecimal(View.GetGroupSummaryValue(e.RowHandle, CType(View.GroupSummary("AbsentDaysAmount"), GridGroupSummaryItem)))).ToString()

    End Sub


    Private Sub ShowPrint2()
        If GridControl1.IsPrintingAvailable = False Then Exit Sub


        If GlobalVariables._SystemLanguage = "Arabic" Then
            If BandedGridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
        Else
            If BandedGridView1.RowCount = 0 Then MsgBox("Empty Report") : Exit Sub
        End If


        '  BandedGridView1.OptionsPrint.PrintDetails = False
        BandedGridView1.OptionsPrint.ExpandAllGroups = False
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridView1.CustomSummaryCalculate
        Dim AllSalary As Integer = 0

        If Summery = False Then Exit Sub
        '  MsgBox("df")
        Try

            Dim view As GridView = TryCast(sender, GridView)
            Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
            Dim summaryStr As Integer = Convert.ToString((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                If summaryID < 30 Then
                    e.TotalValue = TimeSpan.Zero
                ElseIf summaryID = 99 Or summaryID = 100 Or summaryID = 101 Or summaryID = 102 Or summaryID = 50 Or summaryID = 16001 Or summaryID = 15001 Or summaryID = 19001 Then
                    e.TotalValue = 0
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If summaryID < 30 Then
                    Try
                        If e.FieldValue IsNot Nothing Then
                            Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
                            ts = ts + CType(e.TotalValue, TimeSpan)
                            e.TotalValue = ts
                        End If
                    Catch ex As Exception
                        e.TotalValue = TimeSpan.Zero
                    End Try

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
                ElseIf summaryID = 1000 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "دوام" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                ElseIf summaryID = 16001 Then
                    '  e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(BandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                    e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(17), GridGroupSummaryItem)))

                ElseIf summaryID = 15001 Then
                    '  e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(BandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                    e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(14), GridGroupSummaryItem)))
                    ' e.TotalValue = 18001
                    'If summaryID = 19001 Then
                    '    ' e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(14), GridGroupSummaryItem)))
                    '    e.TotalValue = e.TotalValue + 1
                    'End If
                    ' ElseIf summaryID = 19001 Then
                    '  e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(BandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                    ' e.TotalValue = e.TotalValue + 1
                    ' e.TotalValue = 18001
                    'ElseIf summaryID = 19001 Then
                    '    e.TotalValue = Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(17), GridGroupSummaryItem))) * 2
                    'If summaryID = 19001 Then
                    '    e.TotalValue = Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, BandedGridView1.GroupSummary(17)))
                    'End If
                End If
                '  ElseIf summaryID = 18001 Then
                '  e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, TryCast(BandedGridView1.GroupSummary("Salary"), GridGroupSummaryItem)))
                '  e.TotalValue = e.TotalValue + Convert.ToDecimal(BandedGridView1.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary(14), GridGroupSummaryItem)))
                '   e.TotalValue = 18001

                ' 18001ss
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If summaryID < 30 Then
                    ' If summaryID = 9 Then
                    Dim _TimeSpanFunction As New TimeFunctions
                    Dim _TotalMinutes As Decimal = e.TotalValue.TotalMinutes
                    e.TotalValue = _TimeSpanFunction.ConvertTimeSpan_hhmmm_ToString(_TimeSpanFunction.ConvertFromDecimalToTimeSpan(_TotalMinutes / 60))
                    '  End If
                    'e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))
                    ' e.TotalValue = CDec(e.TotalValue.TotalHours).ToString("00") & ":" & CDec(e.TotalValue.Minutes).ToString("00")
                End If

                If summaryID = 15001 Then
                    e.TotalValue = ColSalary.SummaryItem.SummaryValue + ColBonusAmount.SummaryItem.SummaryValue _
                                   + ColTransport.SummaryItem.SummaryValue - ColLeavesAmount.SummaryItem.SummaryValue _
                                   - ColPayment.SummaryItem.SummaryValue - ColAbsentDaysAmount.SummaryItem.SummaryValue + ColAdditions.SummaryItem.SummaryValue
                End If

                If summaryStr = 17001 Then
                    e.TotalValue = GetEmpSalary(BandedGridView1.GetRowCellValue(e.RowHandle, "EmpID"))
                    '  e.TotalValue = Salary
                End If

                ' يجب اكمال كود عند الانتهاء من عمل معادلة لجلب عدد ايام الاجازات خلال الفترة
                'If summaryStr = 99 Then
                '    e.TotalValue = GetEmpVocationsCount(BandedGridView1.GetRowCellValue(e.RowHandle, "EmpID"))
                '    '  e.TotalValue = Salary
                'End If

                'If summaryStr = 15001 Then
                '    e.TotalValue = 15001
                'End If
                'If summaryID = "15001" Then
                '    e.TotalValue = (Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("DailyTransport"), GridGroupSummaryItem)))).ToString()
                '    MsgBox((Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("DailyTransport"), GridGroupSummaryItem)))).ToString())
                '    e.TotalValue = "15000"
                'End If
                'If summaryID = "15001" Then
                '    '  Dim view As GridView = CType(sender, GridView)
                '    '  e.TotalValue = (Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Salary"), GridGroupSummaryItem))) + Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("DailyTransport"), GridGroupSummaryItem)))).ToString()
                '    '  e.TotalValue = 1000
                '    e.TotalValue = (Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("UnitPrice"), GridGroupSummaryItem))) * Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("UnitsInStock"), GridGroupSummaryItem)))).ToString()
                '    '   e.TotalValue = ColNetSalaryNew.SummaryItem.SummaryValue
                'End If
                'If view.Columns("Transport") IsNot Nothing Then
                '    If TypeOf e.Item Is GridGroupSummaryItem Then
                '        e.TotalValue = DirectCast(view.GetGroupSummaryValue(e.GroupRowHandle, TryCast(Me.BandedGridView1.GroupSummary(0), GridGroupSummaryItem)), Integer) * 2

                '    End If
                'End If

            End If




        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        ' MsgBox("df2")
    End Sub


    'Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
    '    Dim view As BandedGridView = sender
    '    If view Is Nothing Then
    '        Return
    '    End If
    '    If e.Column.Caption <> "FirstName" Then
    '        Return
    '    End If
    '    Dim cellValue As String = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns("LastName")).ToString()
    '    view.SetRowCellValue(e.RowHandle, view.Columns("FullName"), cellValue)
    'End Sub




    '    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As Object,
    'ByVal e As CustomColumnDisplayTextEventArgs) _
    'Handles GridView1.CustomColumnDisplayText
    '        Dim view As ColumnView = TryCast(sender, ColumnView)
    '        If e.Column.FieldName = "StartTime" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

    '            Dim cc As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "StartTimeReal"))
    '            Dim dd As String = Convert.ToDecimal(e.Value)

    '            Select Case cc
    '                Case ""
    '                    e.Graphics.DrawImage(ImageIN, e.Bounds.Location)
    '                    e.DisplayText = "دخول"
    '                    Exit Select
    '                Case 1
    '                    e.DisplayText = String.Format(ciEUR, "{0:c}", price)
    '                    Exit Select
    '            End Select
    '        End If
    '    End Sub

    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawCell

        Dim EmptyTrans As Image = My.Resources.User_Red_icon
        Dim View As GridView = CType(sender, GridView)


        If e.Column.FieldName = "StartTimeReal" Then
            ' Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTime"))
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal"))
            Dim _AttStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AttStatus"))
            If category2 = String.Empty And (_AttStatus = "غياب" Or _AttStatus = "خطا بصمة") Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                '  e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '   e.DisplayText = "انقر للتعديل"
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        If e.Column.FieldName = "EndTimeReal" Then
            ' Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal"))
            Dim _AttStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AttStatus"))
            If category2 = String.Empty And (_AttStatus = "غياب" Or _AttStatus = "خطا بصمة") Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '  e.DisplayText = "..."
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        'If e.Column.FieldName = "ElapseTime" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal"))
        '    Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal"))
        '    Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
        '    If category3 <> String.Empty And (category2 = String.Empty Or category = String.Empty) Then
        '        e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '        ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '        '  e.DisplayText = "..."
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            'MsgBox(BandedGridView1.GetFocusedRowCellValue("TransDate"))
            'If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTime")) Then
            '    MsgBox(BandedGridView1.GetFocusedRowCellValue("StartTime"))
            'Else
            '    MsgBox("NOTHING")
            'End If
            Dim SrartTime As DateTime
            Dim EndTime As DateTime

            If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTime")) Then
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("StartTime"))
                EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("EndTime"))
            Else
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("StartRealTime"))
                EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (BandedGridView1.GetFocusedRowCellValue("EndRealTime"))
            End If

            Dim ElapseTimeTemp As TimeSpan
            Dim ElapseHours As Double

            If EndTime > SrartTime Then
                ElapseTimeTemp = (EndTime).Subtract(SrartTime)
                ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
            Else
                ElapseTimeTemp = EndTime.AddDays(1).Subtract(SrartTime)
                ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
            End If


            EndTime = EndTime.AddMinutes(-1)
            If EndTime < SrartTime Then EndTime = EndTime.AddDays(1)

            '   My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue

            My.Forms.AttEditTrans.DateEdit1.DateTime = SrartTime.AddHours(-ElapseHours)
            My.Forms.AttEditTrans.DateEdit2.DateTime = EndTime.AddHours(ElapseHours)


            If BandedGridView1.GetFocusedRowCellValue("EmpID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")

            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If


            If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
                My.Forms.AttEditTrans.TimeEdit1.Time = Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If

            If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
                My.Forms.AttEditTrans.TimeEdit2.Time = Format(BandedGridView1.GetFocusedRowCellValue("EndTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
            End If

            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True
            My.Forms.AttEditTrans.LayoutControlShift.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            My.Forms.AttEditTrans.LayoutControlShift.Text = " تعديل وردية الموظف لتاريخ  " & " " & (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd"))
            My.Forms.AttEditTrans.TextTransDate.Text = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")

            Dim sql As New SQLControl
            Dim _PlaneID As Integer
            _PlaneID = CInt(BandedGridView1.GetFocusedRowCellValue("PlaneID").ToString)
            My.Forms.AttEditTrans.txtPlaneID.Text = _PlaneID
            sql.SqlTrueTimeRunQuery(" select IsNull(StartTime,'00:00') as StartTime,IsNull(EndTime,'00:00') as EndTime from [AttPlaneForPeriod] where [ID]=" & _PlaneID)
            'MsgBox(Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("StartTime")), "HH:mm"))
            My.Forms.AttEditTrans.TimeSpanEdit1.EditValue = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("StartTime")), "HH:mm")
            My.Forms.AttEditTrans.TimeSpanEdit2.EditValue = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("EndTime")), "HH:mm")
            '  My.Forms.AttEditTrans.DateEdit1.ReadOnly = True

            AttEditTrans.DateEdit3.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate").ToString)
            'AttEditTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            AttEditTrans.ShowDialog()
        End Try



    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddVocations.Click
        'Try
        '    My.Forms.AddVocation.FromFrom.Text = Me.Text
        '    'If String.IsNullOrWhiteSpace(BandedGridView1.GetFocusedRowCellValue("EmpID")) Then
        '    '    My.Forms.AddVocation.LookUpEditEmployees.EditValue = SearchLookUpEdit1.EditValue
        '    '    My.Forms.AddVocation.DateEditTo.DateTime = Today
        '    '    My.Forms.AddVocation.DateEditFrom.DateTime = Today
        '    '    My.Forms.AddVocation.TextVocationDate.DateTime = Today
        '    'Else
        '    '    My.Forms.AddVocation.LookUpEditEmployees.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
        '    '    My.Forms.AddVocation.DateEditTo.DateTime = BandedGridView1.GetFocusedRowCellValue("TransDate")
        '    '    My.Forms.AddVocation.DateEditFrom.DateTime = BandedGridView1.GetFocusedRowCellValue("TransDate")
        '    '    My.Forms.AddVocation.TextVocationDate.DateTime = Today
        '    'End If
        '    ' AddVocation.TextID.EditValue = GetMaxVocationID() + 1
        '    ' AddVocation.TextNewOrOld.EditValue = -1
        '    AddVocation.Show()
        '    My.Forms.AddVocation.MemoDetails.Select()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        Dim f As New AddVocation
        With f
            .Show()
            .TextNewOrOld.Text = "New"
            .LookUpEditEmployees.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
            .DateEditFrom.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate"))
            .DateEditTo.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate"))
            .TextDayNo.EditValue = 1
            .MemoDetails.Select()
        End With
    End Sub


    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        InsertSub()
    End Sub

    Private Sub InsertSub()
        Try
            My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue

            '    My.Forms.AttEditTrans.DateEdit1.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")

            If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
                My.Forms.AttEditTrans.TimeEdit1.Time = Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If
            If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
                My.Forms.AttEditTrans.TimeEdit2.Time = Format(BandedGridView1.GetFocusedRowCellValue("EndTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
            End If

            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True
            '   My.Forms.AttEditTrans.DateEdit1.ReadOnly = True


            My.Forms.AttEditTrans.DateEdit3.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd") & " 00:00:00"

            'AttEditTrans.ShowDialog()
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        Finally
            AttEditTrans.ShowDialog()
        End Try
    End Sub
    'Public Sub ShowPrint()
    '    If GridControl1.IsPrintingAvailable = False Then Exit Sub
    '    If BandedGridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
    '    '  BandedGridView1.OptionsPrint.PrintDetails = False
    '    BandedGridView1.OptionsPrint.ExpandAllGroups = False

    '    If _PrintAtt = True Then
    '        GridControl1.Print()
    '    Else
    '        GridControl1.ShowPrintPreview()
    '    End If
    '    ColAddAndEdit.Visible = True
    '    ' Dim opt As New XlsxExportOptionsEx()
    '    'AddHandler BandedGridView1.CustomDrawRowFooterCell, AddressOf GridView1_CustomDrawRowFooterCell

    'End Sub

    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)


        pb.ShowMarginsWarning = False
        ' pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        Dim Tawqe3, Tawqe3_2 As String
        If GlobalVariables._SystemLanguage = "English" Then
            Tawqe3 = " .................:Management signature"
            Tawqe3_2 = " .................:Employee signature"
        Else
            Tawqe3 = " .................:توقيع الادارة"
            Tawqe3_2 = " .................:توقيع الموظف"
        End If

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")


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
        _VocationString = ""
        Dim _VocationTableInMonthSalaryVisible As Boolean
        _VocationTableInMonthSalaryVisible = False
        Try
            SQLString = " select SettingValue From Settings where SettingName ='VocationTableInMonthSalaryVisible'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then _VocationTableInMonthSalaryVisible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        If _VocationTableInMonthSalaryVisible = True Then
            pb.PageSettings.TopMargin = 50
            pb.PageSettings.BottomMargin = 75

            If GlobalVariables._SystemLanguage = "English" Then
                _VocationString = " balance of the first period: " & Vocation_BeginingBalance & "  " & vbCrLf &
                                  " Completed vacations during the year: " & Vocation_ThisYearVocations & "  " & vbCrLf &
                                  " Leave balance for the end of the year: " & Vocation_Balance & "  " & vbCrLf &
                                  " Leave balance for today's date : " & Vocation_AccruedVocations & "  "
                Tawqe3 = _VocationString
                Tawqe3_2 = " .................:Employee signature" & "  " & vbCrLf & Tawqe3 = " .................:Management signature"
            Else
                _VocationString = " رصيد أول الفترة: " & Vocation_BeginingBalance & "  " & vbCrLf &
                                  " اجازات مستوفاه خلال السنة : " & Vocation_ThisYearVocations & "  " & vbCrLf &
                                  " رصيد الاجازات لنهاية العام : " & Vocation_Balance & "  " & vbCrLf &
                                  " رصيد الاجازات لتاريخ اليوم : " & Vocation_AccruedVocations & "  "
                Tawqe3 = _VocationString
                Tawqe3_2 = " .................:توقيع الموظف" & "  " & vbCrLf & " .................:توقيع الادارة "
            End If
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        Else
            Tawqe3 = ""
            pb.PageSettings.TopMargin = 50
            pb.PageSettings.BottomMargin = 50
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        End If

        ' TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        '  TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)



        'If GlobalVariables._SystemLanguage = "Arabic" Then
        '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {"......................... Employee", "......................... Manager ", "Pages: [Page # of Pages #]"})
        'Else
        '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {"......................... Employee ", ".........................  Manager", "Pages: [Page # of Pages #]"})

        'End If

        If CStr(SearchLookUpEdit1.EditValue) IsNot Nothing And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            If GlobalVariables._SystemLanguage = "Arabic" Then
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & "تقرير راتب الموظف حسب الوردية : " & " للفترة من  " & DateEdit1.DateTime & " الى  " & DateEdit2.DateTime)
            Else
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(vbCrLf & " Attendant Report By Shift : " & " From  " & DateEdit1.DateTime & " To  " & DateEdit2.DateTime)
            End If
            '   BandedGridView1.OptionsPrint.PrintGroupFooter = False
        Else
            '  BandedGridView1.OptionsPrint.PrintGroupFooter = True
        End If
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)

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

        ' Dim PlaneTable As New DataTable
        Dim LeaveSpanTotalPerEmployee As TimeSpan = TimeSpan.Zero
        Dim ListDays As New DataTable
        ListDays.Columns.Add("TransDate", GetType(DateTime))
        ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("PlaneID", GetType(Integer))
        ListDays.Columns.Add("EmpID", GetType(String))
        ListDays.Columns.Add("EmployeeName", GetType(String))
        ListDays.Columns.Add("StartTime", GetType(DateTime))
        ListDays.Columns.Add("EndTime", GetType(DateTime))
        ListDays.Columns.Add("LateMinutes", GetType(Integer))
        ListDays.Columns.Add("EarlyMinutes", GetType(Integer))
        ListDays.Columns.Add("ShiftRest", GetType(Integer))
        ListDays.Columns.Add("ID", GetType(Integer))
        ListDays.Columns.Add("BonusBefore", GetType(Integer))
        ListDays.Columns.Add("BonusAfter", GetType(Integer))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim CurrDName As String = Format(CurrD, "dddd")
        Dim ElapseTimeTemp As TimeSpan
        Dim ElapseHours As Double

        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " DECLARE @MinDate DATE = '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "',
                                            @MaxDate DATE = '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "';
                                    Select [ID],PlaneID, A.[AttTransDate] as TransDate, [EmpID],EmployeeName, IsNull(StartTime,'00:00') as StartTime, IsNull(EndTime,'00:00') as EndTime, '' as DatePartString, '' as DayOfWeek,LateMinutes,EarlyMinutes,ShiftRest,IsNull(BonusBefore,0) as BonusBefore,IsNull(BonusAfter,0) as BonusAfter
                                    From (SELECT TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
                                             [AttTransDate] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),
                                             [AttTransDateName] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
                                             FROM sys.all_objects a CROSS JOIN sys.all_objects b ) A
                                     Left Join (SELECT P.[ID],P.[ID] as PlaneID, [AttTransDate],  [EmpID],D.EmployeeName, CONVERT(VARCHAR(5), [StartTime], 108) as StartTime, CONVERT(VARCHAR(5), [EndTime], 108) as EndTime,LateMinutes,EarlyMinutes,ShiftRest,BonusBefore,BonusAfter
                                     FROM [dbo].[AttPlaneForPeriod] P left join EmployeesData D on D.EmployeeID=P.EmpID where EmpID='" & EmpID & "') B On A.AttTransDate=b.AttTransDate where ID is not null Order by A.AttTransDate"
            SQl.SqlTrueTimeRunQuery(SqlString)
            ListDays = SQl.SQLDS.Tables(0)
            If ListDays.Rows.Count = 0 Then
                MsgBox("لا يوجد وردية بهذه الفترة للموظف " & " " & EmpID)
                GoTo EEnd
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        ListDays.Columns.Add("StartTimeReal", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal", GetType(DateTime))
        ListDays.Columns.Add("LateSpan", GetType(TimeSpan))
        ListDays.Columns.Add("LeaveSpan", GetType(TimeSpan))
        ListDays.Columns.Add("BonusSpanBeforeBeg", GetType(TimeSpan))
        ListDays.Columns.Add("BonusSpanAfterEnd", GetType(TimeSpan))
        ListDays.Columns.Add("ElapseTime", GetType(TimeSpan))
        ListDays.Columns.Add("ElapseTimePlane", GetType(TimeSpan))
        ListDays.Columns.Add("TransDay", GetType(String))

        ListDays.Columns.Add("TransInID", GetType(Integer))
        ListDays.Columns.Add("TransOutID", GetType(Integer))
        ListDays.Columns.Add("EditedType", GetType(String))
        ListDays.Columns.Add("Voc", GetType(Decimal))
        ListDays.Columns.Add("AttStatus", GetType(String))
        ListDays.Columns.Add("ActualElapseTime", GetType(TimeSpan))
        ListDays.Columns.Add("Leaves", GetType(TimeSpan))
        ListDays.Columns.Add("Salary", GetType(Decimal))
        ListDays.Columns.Add("SalaryPerDay", GetType(Decimal))
        ListDays.Columns.Add("SalaryPerDayPerMonth", GetType(Decimal))
        ListDays.Columns.Add("BonusAmount", GetType(Decimal))
        ListDays.Columns.Add("DailyTransport", GetType(Decimal))
        ListDays.Columns.Add("GrossSalary", GetType(Decimal))
        ListDays.Columns.Add("LeavesAmount", GetType(Decimal))
        ListDays.Columns.Add("Payment", GetType(Decimal))
        ListDays.Columns.Add("Additions", GetType(Decimal))
        ListDays.Columns.Add("NetSalary", GetType(Decimal))
        ListDays.Columns.Add("NetSalaryMonthDays", GetType(Decimal))

        ListDays.Columns.Add("AttendentDays", GetType(Integer))
        ListDays.Columns.Add("VocationDays", GetType(Decimal))
        ListDays.Columns.Add("OffDays", GetType(Integer))
        ListDays.Columns.Add("AbsentDays", GetType(Integer))
        ListDays.Columns.Add("AbsentDaysAmount", GetType(Decimal))
        ListDays.Columns.Add("AbsentHoures", GetType(TimeSpan))
        ListDays.Columns.Add("SalaryAccountNo", GetType(String))
        ListDays.Columns.Add("NetSalaryAsMonthSalary", GetType(Decimal))
        ListDays.Columns.Add("BonusSpanTotal", GetType(TimeSpan))
        ListDays.Columns.Add("BonusSpanNet", GetType(TimeSpan))
        ListDays.Columns.Add("LeaveSpanNet", GetType(TimeSpan))
        ListDays.Columns.Add("DateOfStart", GetType(String))
        ListDays.Columns.Add("DateOfEnd", GetType(String))
        ListDays.Columns.Add("EnglishStatus", GetType(String))
        ListDays.Columns.Add("VocationSource", GetType(String))

        ListDays.Columns.Add("BonusBeforeIsAdjust", GetType(String))
        ListDays.Columns.Add("BonusAfterIsAdjust", GetType(String))
        ListDays.Columns.Add("LatesIsAdjust", GetType(String))
        ListDays.Columns.Add("LeavesIsAdjust", GetType(String))
        ListDays.Columns.Add("EditNote", GetType(String))
        ListDays.Columns.Add("LeavesDuringWork", GetType(TimeSpan))
        ListDays.Columns.Add("OverTimeRequestID", GetType(Integer))
        ListDays.Columns.Add("OverTimeRequestStatus", GetType(Integer))
        ListDays.Columns.Add("MorningLeaveRequest", GetType(Integer))

        'ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        'While (CurrD < endP)
        '    CurrD = CurrD.AddDays(1)
        '    ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        'End While
        'Dim sql As New SQLControl
        'Dim SqlString As String = "Select * from [AttPlane] where [PlaneID] = " & PlaneID
        'sql.SqlTrueTimeRunQuery(SqlString)
        'PlaneTable = sql.SQLDS.Tables(0)
        'Dim ListDaysRows As Integer
        'For ListDaysRows = 0 To ListDays.Rows.Count - 1
        '    Dim ss As DataView = New DataView(PlaneTable,
        '    "PlaneID = " & PlaneID & " and DayName ='" & Format(ListDays.Rows(ListDaysRows).Item("TransDate"), "dddd").ToString & "'", "ID", DataViewRowState.CurrentRows)
        '    If ss.Count > 0 Then
        '        ListDays.Rows(ListDaysRows).Item("StartTime") = ss(0)("StartTime").ToString
        '        ListDays.Rows(ListDaysRows).Item("EndTime") = ss(0)("EndTime").ToString
        '        ListDays.Rows(ListDaysRows).Item("LateMinutes") = ss(0)("LateMinutes").ToString
        '        ListDays.Rows(ListDaysRows).Item("EarlyMinutes") = ss(0)("EarlyMinutes").ToString
        '        ListDays.Rows(ListDaysRows).Item("ShiftRest") = ss(0)("ShiftRest").ToString
        '    End If
        'Next


        Dim TempLateTimeSpan As TimeSpan
        Dim TempAllowLateTimeSpan As TimeSpan
        Dim TempleaveTimeSpan As TimeSpan
        Dim TempAllowleaveTimeSpan As TimeSpan
        Dim ShiftRest As TimeSpan

        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        If _UseLocalDataBaseForReport = True Then
            myconnection = New SqlConnection(GlobalVariables.LocalAttCHECKINOUTConnectionString)
        Else
            myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        End If

        Dim dr As SqlDataReader
        Dim FromDate, ToDate As String
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

            ListDays.Rows(i).Item("BonusBeforeIsAdjust") = 0
            ListDays.Rows(i).Item("MorningLeaveRequest") = 0
            'ListDays.Rows(i).Item("LeavesIsAdjust") = 0

            If ListDays.Rows(i).Item("StartTime") <> "00:00" Or ListDays.Rows(i).Item("EndTime") <> "00:00" Then
                Dim EEnd, SStart As DateTime
                EEnd = Convert.ToDateTime(ListDays.Rows(i).Item("EndTime"))
                SStart = Convert.ToDateTime(ListDays.Rows(i).Item("StartTime"))

                If EEnd > SStart Then
                    ElapseTimeTemp = (EEnd).Subtract(SStart)
                    ElapseHours = (30 - CInt(ElapseTimeTemp.TotalHours)) / 2
                Else
                    ElapseTimeTemp = EEnd.AddDays(1).Subtract(SStart)
                    ElapseHours = (30 - CInt(ElapseTimeTemp.TotalHours)) / 2
                End If
            End If

            If ListDays.Rows(i).Item("StartTime") <> "00:00" Then
                FromDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("StartTime")
                FromDate = Format(Convert.ToDateTime(FromDate).AddHours(-ElapseHours + 4), "yyyy-MM-dd HH:mm:ss")
            Else
                Dim _InTrans As String
                _InTrans = GetAttTrans(CurrentDateString, EmpID, "I")
                FromDate = Format(CDate(_InTrans), "yyyy-MM-dd HH:mm:ss")
            End If

            If ListDays.Rows(i).Item("EndTime") <> "00:00" Then
                If CDate(ListDays.Rows(i).Item("EndTime")) > CDate(ListDays.Rows(i).Item("StartTime")) Then
                    ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("EndTime")
                    ToDate = Format(Convert.ToDateTime(ToDate).AddHours(ElapseHours).AddMinutes(60), "yyyy-MM-dd HH:mm:ss")
                Else
                    ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & ListDays.Rows(i).Item("EndTime")
                    ToDate = Format(Convert.ToDateTime(ToDate).AddHours(ElapseHours + 24).AddMinutes(-1), "yyyy-MM-dd HH:mm:ss")
                End If
            Else
                ToDate = Format(CDate(GetAttTrans(CurrentDateString, EmpID, "I")).AddHours(24).AddMinutes(-1), "yyyy-MM-dd HH:mm:ss")
            End If

            'Dim SQLString2 As String = "Select CHECKTIME,[ID] as TransInID,EditedType,USERID,EditNote from [AttCHECKINOUT] where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  
            '                            and [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate & "'  and '" & ToDate & "')   order by CHECKTIME "

            Dim SQLString2 As String = " WITH FilteredRecords AS (
                                            SELECT 
                                            CHECKTIME,[ID] as TransInID,EditedType,USERID,EditNote,
                                            LAG(CHECKTIME) OVER (ORDER BY CHECKTIME) AS PrevCheckTime
                                            FROM 
                                            AttCHECKINOUT
                                            WHERE [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  and [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate & "'  and '" & ToDate & "')  
                                            )
                                            SELECT 
                                            *
                                            FROM 
                                            FilteredRecords
                                            WHERE 
                                            PrevCheckTime IS NULL 
                                            OR DATEDIFF(MINUTE, PrevCheckTime, CHECKTIME) >= 10 ORDER BY  CHECKTIME ;  "
            mycommand = New SqlCommand(SQLString2, myconnection)
            dr = mycommand.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                ListDays.Rows(i).Item("StartTimeReal") = dr.Item("CHECKTIME")
                ListDays.Rows(i).Item("TransInID") = dr.Item("TransInID")
                ListDays.Rows(i).Item("EditedType") = dr.Item("EditedType")
                ListDays.Rows(i).Item("EditNote") = dr.Item("EditNote")

                dr.Close()
            Else
                dr.Close()
            End If

            Dim _TransOutID As Integer
            Dim SQLString3 As String = " Select CHECKTIME,[ID] as TransOutID,EditedType,USERID from [AttCHECKINOUT]
                                         Where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS
                                               and [AttCHECKINOUT].[ID]<> " & _TransOutID & "
                                               and [USERID] = " & EmpID & "  
                                               and ( CHECKTIME between '" & FromDate & "'  and '" & ToDate & "')
                                         Order by CHECKTIME desc "

            mycommand = New SqlCommand(SQLString3, myconnection)
            dr = mycommand.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                ListDays.Rows(i).Item("EndTimeReal") = dr.Item("CHECKTIME")
                ListDays.Rows(i).Item("TransOutID") = dr.Item("TransOutID")
                ListDays.Rows(i).Item("EditedType") = dr.Item("EditedType")
                _TransOutID = dr.Item("TransOutID")
                dr.Close()
            Else
                dr.Close()
            End If

            Try
                ShiftRest = TimeSpan.FromMinutes(CInt(ListDays.Rows(i).Item("ShiftRest")))
                If CDate(ListDays.Rows(i).Item("EndTime")) > CDate(ListDays.Rows(i).Item("StartTime")) Then
                    ListDays.Rows(i).Item("ElapseTimePlane") = CDate(ListDays.Rows(i).Item("EndTime")).Subtract(CDate(ListDays.Rows(i).Item("StartTime")))
                    ListDays.Rows(i).Item("ElapseTimePlane") = ListDays.Rows(i).Item("ElapseTimePlane").Subtract(ShiftRest)
                ElseIf CDate(ListDays.Rows(i).Item("EndTime")) < CDate(ListDays.Rows(i).Item("StartTime")) Then
                    ListDays.Rows(i).Item("ElapseTimePlane") = (CDate(ListDays.Rows(i).Item("EndTime")).AddDays(1)).Subtract(CDate(ListDays.Rows(i).Item("StartTime")))
                    ListDays.Rows(i).Item("ElapseTimePlane") = ListDays.Rows(i).Item("ElapseTimePlane").Subtract(ShiftRest)
                ElseIf CDate(ListDays.Rows(i).Item("EndTime")) = CDate(ListDays.Rows(i).Item("StartTime")) Then
                    ListDays.Rows(i).Item("ElapseTimePlane") = "00:00"
                End If



                Dim StartTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("StartTimeReal"), "HH:mm:ss"))
                Dim StartTime As DateTime = ListDays.Rows(i).Item("StartTime")

                Dim EndTime As DateTime = CDate(ListDays.Rows(i).Item("EndTime"))

                _AttCalcBonusBerforePeriodInMinutes = ListDays.Rows(i).Item("BonusBefore")
                _AttCalcBonusAfterPeriodMinutes = ListDays.Rows(i).Item("BonusAfter")

                If StartTimeReal.TimeOfDay >= StartTime.TimeOfDay And StartTime <> EndTime Then
                    TempLateTimeSpan = StartTimeReal.Subtract(StartTime)
                    TempAllowLateTimeSpan = TimeSpan.FromMinutes(CInt(ListDays.Rows(i).Item("LateMinutes")))
                    If CheckEditAllows.CheckState = 1 And TempAllowLateTimeSpan.Subtract(TempLateTimeSpan) >= TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                    ElseIf CheckEditAllows.CheckState = 1 And TempAllowLateTimeSpan.Subtract(TempLateTimeSpan) < TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LateSpan") = TempLateTimeSpan
                    ElseIf CheckEditAllows.CheckState = 0 Then
                        ListDays.Rows(i).Item("LateSpan") = StartTimeReal.Subtract(StartTime)
                    End If
                    ListDays.Rows(i).Item("BonusSpanBeforeBeg") = TimeSpan.Zero
                ElseIf StartTimeReal.TimeOfDay < StartTime.TimeOfDay And StartTime <> EndTime Then
                    ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                    ListDays.Rows(i).Item("BonusSpanBeforeBeg") = StartTime.Subtract(StartTimeReal)
                    If ListDays.Rows(i).Item("BonusSpanBeforeBeg") <= TimeSpan.FromMinutes(_AttCalcBonusBerforePeriodInMinutes) Then
                        ListDays.Rows(i).Item("BonusSpanBeforeBeg") = TimeSpan.Zero
                    End If
                End If

                ' معالجة الاضافي قبل الدوام بشكل يومي
                If GlobalVariables._AttDailyAdjustment = True Then
                    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 3)
                    If _AdjBonus <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("BonusBeforeIsAdjust") = 1
                        Dim _LastBonus As TimeSpan = TimeSpan.Zero
                        _LastBonus = ListDays.Rows(i).Item("BonusSpanBeforeBeg")
                        ListDays.Rows(i).Item("BonusSpanBeforeBeg") = _LastBonus + _AdjBonus
                    End If
                End If

                ' معالجة التاخير الصباحي  بشكل يومي
                If GlobalVariables._AttDailyAdjustment = True Then
                    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 5)
                    If _AdjBonus <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LatesIsAdjust") = 1
                        Dim _LastBonus As TimeSpan = TimeSpan.Zero
                        _LastBonus = ListDays.Rows(i).Item("LateSpan")
                        ListDays.Rows(i).Item("LateSpan") = _LastBonus + _AdjBonus
                    End If
                End If

                ' فحص اذا كان يوجد طلب مغادرة صباحي 
                If _AdjustMorningLateToZeroIfRequestFound = True Then
                    If ListDays.Rows(i).Item("LateSpan") > TimeSpan.Zero Then
                        ListDays.Rows(i).Item("MorningLeaveRequest") = CheckIfHasMorningLateRequest(EmpID, ListDays.Rows(i).Item("TransDate"), ListDays.Rows(i).Item("StartTime"))
                        If ListDays.Rows(i).Item("MorningLeaveRequest") > 0 Then
                            ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                        End If
                    End If
                End If


                ' في حال تغثيل خيار الغاء الاضافي قبل الداوم
                If _AddBonusBeforeShift = False Then
                    ListDays.Rows(i).Item("BonusSpanBeforeBeg") = TimeSpan.Zero
                End If

                Dim EndTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("EndTimeReal"), "HH:mm:ss"))
                Dim BonusPeriod As TimeSpan
                BonusPeriod = EndTimeReal.Subtract(EndTime)
                '   If  EndTimeReal.Subtract(EndTime) < TimeSpan.Parse("23:00")
                'لحساب مجموع  ساعات ومبلغ المغادرات
                If EndTimeReal.TimeOfDay >= EndTime.TimeOfDay And BonusPeriod < TimeSpan.Parse("10:00") Then
                    ListDays.Rows(i).Item("BonusSpanAfterEnd") = (EndTimeReal.AddDays(0)).Subtract(EndTime)
                    If ListDays.Rows(i).Item("BonusSpanAfterEnd") <= TimeSpan.FromMinutes(_AttCalcBonusAfterPeriodMinutes) Then
                        ListDays.Rows(i).Item("BonusSpanAfterEnd") = TimeSpan.Zero
                    End If
                Else
                    TempleaveTimeSpan = EndTime.Subtract(EndTimeReal)
                    ' كانت مشكلة عند عليان ما بحسب خروج مبكر اذا خرج الساعة 23 مثلا وكانت ورديته ل 3 الصبح
                    If TempleaveTimeSpan < TimeSpan.Zero Then TempleaveTimeSpan = EndTime.AddDays(1).Subtract(EndTimeReal)
                    TempAllowleaveTimeSpan = TimeSpan.FromMinutes(CInt(ListDays.Rows(i).Item("EarlyMinutes")))
                    If CheckEditAllows.CheckState = 1 And TempleaveTimeSpan.Subtract(TempAllowleaveTimeSpan) > TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeaveSpan") = TempleaveTimeSpan
                    ElseIf CheckEditAllows.CheckState = 1 And TempleaveTimeSpan.Subtract(TempAllowleaveTimeSpan) <= TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeaveSpan") = TimeSpan.Zero
                    ElseIf CheckEditAllows.CheckState = 0 Then
                        ListDays.Rows(i).Item("LeaveSpan") = TempleaveTimeSpan
                    End If
                    If ListDays.Rows(i).Item("LeaveSpan") > TimeSpan.Parse("10:00") Then
                        ListDays.Rows(i).Item("BonusSpanAfterEnd") = (EndTimeReal.AddDays(1)).Subtract(EndTime)
                        If ListDays.Rows(i).Item("BonusSpanAfterEnd") <= TimeSpan.FromMinutes(_AttCalcBonusAfterPeriodMinutes) Then
                            ListDays.Rows(i).Item("BonusSpanAfterEnd") = TimeSpan.Zero
                        End If
                        ListDays.Rows(i).Item("LeaveSpan") = TimeSpan.Zero
                        ListDays.Rows(i).Item("LeavesAmount") = 0
                    End If
                End If

                If IsDBNull(ListDays.Rows(i).Item("BonusSpanAfterEnd")) Then
                    ListDays.Rows(i).Item("BonusSpanAfterEnd") = TimeSpan.Zero
                End If
                ' معالجة  الخروج المبكر  بشكل يومي
                If GlobalVariables._AttDailyAdjustment = True Then
                    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 6)
                    If _AdjBonus <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeavesIsAdjust") = 1
                        Dim _LastBonus As TimeSpan = TimeSpan.Zero
                        _LastBonus = ListDays.Rows(i).Item("LeaveSpan")
                        ListDays.Rows(i).Item("LeaveSpan") = _LastBonus + _AdjBonus
                    End If
                End If

                ' معالجة الاضافي بعد الدوام بشكل يومي
                If GlobalVariables._AttDailyAdjustment = True Then
                    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 4)
                    If _AdjBonus <> TimeSpan.Zero Then
                        ListDays.Rows(i).Item("BonusAfterIsAdjust") = 1
                        Dim _LastBonus As TimeSpan = TimeSpan.Zero
                        _LastBonus = ListDays.Rows(i).Item("BonusSpanAfterEnd")
                        ListDays.Rows(i).Item("BonusSpanAfterEnd") = _LastBonus + _AdjBonus
                    End If
                End If

                Try
                    ' لحساب مجموع ساعات الاضافي
                    Dim _BonusSpanBeforeBeg As TimeSpan
                    If IsDBNull(ListDays.Rows(i).Item("BonusSpanBeforeBeg")) Then
                        _BonusSpanBeforeBeg = TimeSpan.Zero
                    Else
                        _BonusSpanBeforeBeg = ListDays.Rows(i).Item("BonusSpanBeforeBeg")
                    End If
                    Dim _BonusSpanAfterEnd As TimeSpan
                    If IsDBNull(ListDays.Rows(i).Item("BonusSpanAfterEnd")) Then
                        _BonusSpanAfterEnd = TimeSpan.Zero
                    Else
                        _BonusSpanAfterEnd = ListDays.Rows(i).Item("BonusSpanAfterEnd")
                    End If
                    ListDays.Rows(i).Item("BonusSpanTotal") = _BonusSpanBeforeBeg + _BonusSpanAfterEnd
                    If (_BonusSpanBeforeBeg.TotalHours + _BonusSpanAfterEnd.TotalHours) > 0 Then
                        Dim _CheckIfHasBonusRequest = CheckIfHasBonusRequest(EmpID, ListDays.Rows(i).Item("TransDate"))
                        ListDays.Rows(i).Item("OverTimeRequestID") = _CheckIfHasBonusRequest.RequestId
                        ListDays.Rows(i).Item("OverTimeRequestStatus") = _CheckIfHasBonusRequest.RequestStatus
                    End If
                Catch ex As Exception

                End Try




                Try
                    If EndTimeReal.TimeOfDay >= StartTimeReal.TimeOfDay Then
                        ListDays.Rows(i).Item("ElapseTime") = EndTimeReal.Subtract(StartTimeReal)
                    Else
                        ListDays.Rows(i).Item("ElapseTime") = (EndTimeReal.AddDays(1)).Subtract(StartTimeReal)
                    End If
                Catch ex As Exception

                End Try
            Catch ex As Exception
                ' MsgBox(ex.ToString)
            End Try

            Try
                Dim VocationPaid As Boolean
                If _VocationsFound = True Then
                    With GetVocID(Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd"), ListDays.Rows(i).Item("EmpID"))

                        ListDays.Rows(i).Item("Voc") = .Item1
                        ListDays.Rows(i).Item("AttStatus") = .Item2
                        VocationPaid = .Item3
                        ListDays.Rows(i).Item("VocationDays") = 1
                        ListDays.Rows(i).Item("VocationSource") = .Item4
                        ' If ListDays.Rows(i).Item("AttStatus") = "سنوية" Then
                        If VocationPaid = True And ListDays.Rows(i).Item("VocationSource") = "vocation" Then
                            If CheckElapseOnVocation.Checked = True Then ListDays.Rows(i).Item("ElapseTimePlane") = TimeSpan.Zero
                            '   AbsentDaysAmount
                        End If


                    End With
                Else
                    VocationPaid = False
                    ListDays.Rows(i).Item("Voc") = "0"
                    ListDays.Rows(i).Item("AttStatus") = "0"
                    ListDays.Rows(i).Item("VocationSource") = " "

                End If


                If ListDays.Rows(i).Item("StartTime") = "00:00" Then
                    If ListDays.Rows(i).Item("Voc") = "1" And CheckCalcVocationsAtOffDay.Checked = False Then
                        ListDays.Rows(i).Item("AttStatus") = "عطلة"
                        ListDays.Rows(i).Item("Voc") = "0"
                    End If
                    If ListDays.Rows(i).Item("Voc") = "0" Then
                        ListDays.Rows(i).Item("AttStatus") = "عطلة"
                    End If
                    If ListDays.Rows(i).Item("Voc") = "0" And CDate(CurrentDateString) < CDate(_DateOfStart) Then
                        ListDays.Rows(i).Item("AttStatus") = "غياب"
                    End If
                    If CDate(CurrentDateString) > CDate(_DateOfEnd) And CDate(_DateOfEnd) <> CDate("1900-01-01") Then
                        ListDays.Rows(i).Item("AttStatus") = "غياب"
                    End If
                End If

                ' كانت يوم العطلة اذا في دخول او خروج بعطي عطلة لذلك تم تعديل الكود
                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) Or IsDBNull(ListDays.Rows(i).Item("EndTimeReal"))) And ListDays.Rows(i).Item("StartTime") <> "00:00" And ListDays.Rows(i).Item("Voc") = 0 Then
                    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                End If

                'If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) Or IsDBNull(ListDays.Rows(i).Item("EndTimeReal"))) Then
                '    ListDays.Rows(i).Item("AttStatus") = "خطا بصمة"
                'End If

                If (IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) And IsDBNull(ListDays.Rows(i).Item("EndTimeReal"))) And ListDays.Rows(i).Item("StartTime") <> "00:00" And ListDays.Rows(i).Item("Voc") = 0 Then
                    ListDays.Rows(i).Item("AttStatus") = "غياب"
                End If

                If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) And Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal"))) And ListDays.Rows(i).Item("StartTime") <> "00:00" Then
                    ListDays.Rows(i).Item("AttStatus") = "دوام"
                End If




                Dim leavv As TimeSpan
                If IsDBNull(ListDays.Rows(i).Item("LeaveSpan")) Then
                    leavv = TimeSpan.Zero
                Else
                    leavv = ListDays.Rows(i).Item("LeaveSpan")
                End If

                Dim Leatt As TimeSpan
                If IsDBNull(ListDays.Rows(i).Item("LateSpan")) Then
                    Leatt = TimeSpan.Zero
                Else
                    Leatt = ListDays.Rows(i).Item("LateSpan")
                End If

                If ListDays.Rows(i).Item("ElapseTimePlane") <> TimeSpan.Zero Then
                    ListDays.Rows(i).Item("ActualElapseTime") = GetSumActual(EmpID, FromDate)
                    If Not IsDBNull(ListDays.Rows(i).Item("ElapseTime")) Then
                        ListDays.Rows(i).Item("Leaves") = ListDays.Rows(i).Item("ElapseTime") + Leatt + leavv - ListDays.Rows(i).Item("ActualElapseTime")
                        ListDays.Rows(i).Item("LeavesDuringWork") = ListDays.Rows(i).Item("Leaves") - Leatt - leavv
                    Else
                        ' تم اضافتها بتاريخ 05/02/2025 حيث انه اذا لم يتم اكتمال الدوام ما كان النظام يقدر يحسب مجموع المغادرات 
                        '  ف على الاقل هنا يتم احتساب التاخير الصباحي
                        ListDays.Rows(i).Item("Leaves") = Leatt
                    End If
                Else
                    ListDays.Rows(i).Item("ActualElapseTime") = ListDays.Rows(i).Item("ElapseTime")
                End If



                ' معالجة المغادرات والاضافي بشكل يومي
                'If GlobalVariables._AttDailyAdjustment = True Then
                '    ' معالجة المغادرات
                '    Dim _AdjLeave As TimeSpan = TimeSpan.Zero
                '    Dim _LastLeaves As TimeSpan = TimeSpan.Zero
                '    If Not IsDBNull(ListDays.Rows(i).Item("Leaves")) Then
                '        _LastLeaves = ListDays.Rows(i).Item("Leaves")
                '    End If
                '    _AdjLeave = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 1)
                '    If _AdjLeave <> TimeSpan.Zero Then
                '        ListDays.Rows(i).Item("LeavesIsAdjust") = 1
                '    End If
                '    ListDays.Rows(i).Item("Leaves") = _LastLeaves + _AdjLeave
                '    ' معالجة الاضافي
                '    Dim _AdjBonus As TimeSpan = TimeSpan.Zero
                '    Dim _LastBonus As TimeSpan = TimeSpan.Zero
                '    If Not IsDBNull(ListDays.Rows(i).Item("BonusSpanTotal")) Then
                '        _LastBonus = ListDays.Rows(i).Item("BonusSpanTotal")
                '    End If
                '    _AdjBonus = GetAttAdjustmentsForHoresRequired(EmpID, ListDays.Rows(i).Item("TransDate"), 2)
                '    If _AdjBonus <> TimeSpan.Zero Then
                '        ListDays.Rows(i).Item("BonusIsAdjust") = 1
                '    End If
                '    ListDays.Rows(i).Item("BonusSpanTotal") = _LastBonus + _AdjBonus
                'End If

                Try
                    ' لحساب صافي الاضافي وصافي المغادرات
                    If ListDays.Rows(i).Item("ActualElapseTime") > ListDays.Rows(i).Item("ElapseTimePlane") Then
                        ListDays.Rows(i).Item("BonusSpanNet") = ListDays.Rows(i).Item("ActualElapseTime") - ListDays.Rows(i).Item("ElapseTimePlane")
                    Else
                        If ListDays.Rows(i).Item("AttStatus") <> "غياب" Then
                            ListDays.Rows(i).Item("LeaveSpanNet") = ListDays.Rows(i).Item("ElapseTimePlane") - ListDays.Rows(i).Item("ActualElapseTime")
                        End If
                    End If
                Catch ex As Exception

                End Try

                ''''''///////////////ساعات الدوام هي نفسها ساعات الاضافي يوم العطلة ويوم الاجازة/////////////
                If ListDays.Rows(i).Item("AttStatus") = "عطلة" Or ListDays.Rows(i).Item("VocationSource") = "vocation" Then
                    ListDays.Rows(i).Item("BonusSpanTotal") = ListDays.Rows(i).Item("ElapseTime")
                    ListDays.Rows(i).Item("BonusSpanNet") = ListDays.Rows(i).Item("ElapseTime")
                    ListDays.Rows(i).Item("LeaveSpanNet") = TimeSpan.Zero
                    ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                    ListDays.Rows(i).Item("LeaveSpan") = TimeSpan.Zero
                    ListDays.Rows(i).Item("BonusSpanBeforeBeg") = TimeSpan.Zero
                    ListDays.Rows(i).Item("BonusSpanAfterEnd") = TimeSpan.Zero
                End If

                If ListDays.Rows(i).Item("AttStatus") = "غياب" Then
                    ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                End If

                ListDays.Rows(i).Item("SalaryAccountNo") = SalaryAccountNo
                Dim AbsentDaysAmount As Decimal = 0
                Dim BonusSpanBeforeBeg As TimeSpan = TimeSpan.Zero
                Dim BonusSpanAfterEnd As TimeSpan = TimeSpan.Zero
                Dim ElapseTimePlane As TimeSpan = TimeSpan.Zero
                Dim LeaveSpanNet As TimeSpan = TimeSpan.Zero
                Dim LateSpan As TimeSpan = TimeSpan.Zero
                Dim BonusSpanNet As TimeSpan = TimeSpan.Zero
                Dim LeaveSpan As TimeSpan = TimeSpan.Zero

                Dim Leaves As TimeSpan = TimeSpan.Zero
                Dim _ActualElapseTime As TimeSpan = TimeSpan.Zero

                If Not IsDBNull(ListDays.Rows(i).Item("BonusSpanBeforeBeg")) Then BonusSpanBeforeBeg = ListDays.Rows(i).Item("BonusSpanBeforeBeg")
                If Not IsDBNull(ListDays.Rows(i).Item("BonusSpanAfterEnd")) Then BonusSpanAfterEnd = ListDays.Rows(i).Item("BonusSpanAfterEnd")
                If Not IsDBNull(ListDays.Rows(i).Item("ElapseTimePlane")) Then ElapseTimePlane = ListDays.Rows(i).Item("ElapseTimePlane")
                If Not IsDBNull(ListDays.Rows(i).Item("LeaveSpanNet")) Then LeaveSpanNet = ListDays.Rows(i).Item("LeaveSpanNet")
                If Not IsDBNull(ListDays.Rows(i).Item("LateSpan")) Then LateSpan = ListDays.Rows(i).Item("LateSpan")
                If Not IsDBNull(ListDays.Rows(i).Item("BonusSpanNet")) Then BonusSpanNet = ListDays.Rows(i).Item("BonusSpanNet")
                If Not IsDBNull(ListDays.Rows(i).Item("LeaveSpan")) Then LeaveSpan = ListDays.Rows(i).Item("LeaveSpan")
                LeaveSpanTotalPerEmployee = LeaveSpanTotalPerEmployee + BonusSpanNet
                If Not IsDBNull(ListDays.Rows(i).Item("Leaves")) Then Leaves = ListDays.Rows(i).Item("Leaves")
                If Leaves.TotalMinutes < 1 Then Leaves = TimeSpan.Zero
                If Not IsDBNull(ListDays.Rows(i).Item("ActualElapseTime")) Then _ActualElapseTime = ListDays.Rows(i).Item("ActualElapseTime")

                'تحديد فيمة افتراضية قبل الاحتساب
                ListDays.Rows(i).Item("BonusAmount") = 0
                ListDays.Rows(i).Item("LeavesAmount") = 0

                Dim LeavesDuringDay As TimeSpan
                Dim _SalaryPerHour As Decimal
                If _GetSalaryPerHourFromEmployee_ShiftReport = True Then
                    _SalaryPerHour = _SalaryPerHourFromEmployeeData
                Else
                    If ElapseTimePlane.TotalHours > 0 Then
                        _SalaryPerHour = SalaryPerDay / ElapseTimePlane.TotalHours
                    Else
                        _SalaryPerHour = 0
                    End If
                End If

                ' تم عمل if لكي يتم التخلص من الثواني
                ' اذا ما كان اله مغادرات بالنهار ف ما يخصم ثواني عليه

                LeavesDuringDay = Leaves - LateSpan - LeaveSpan
                If LeavesDuringDay.TotalMinutes < 10 Then
                    LeavesDuringDay = TimeSpan.Zero
                End If
                'LeavesDuringDay = TimeSpan.Zero


                ' تم تعطيله مشان هنجرز
                If ElapseTimePlane.TotalHours > 0 Then

                    ' لحساب الاضافي في فترات
                    Dim _Period1 As Integer
                    Dim _Period2 As Integer
                    Dim _Factor1 As Decimal
                    Dim _Factor2 As Decimal
                    Dim _HoursFactor As Decimal
                    Dim _BonusMinutes As Decimal
                    Dim _BonusHoursforperiod2 As TimeSpan = TimeSpan.Zero
                    _Period1 = _CalcBonusAfterMinitues
                    _Factor1 = BonusPerHour
                    ' عند الشويكي الله يسامحه طلب انه ينضرب البونص بعد فترة من الدقائق بمعامل يختلف 
                    '_Factor2 = _BonusPerHourAferPeriod1
                    _Factor2 = _Factor1
                    ' انا لغيت هاي الميزة واعتبرت انه factor 1 هو نفسه factor 2
                    If BonusAmountAfterRequirdHoures = 1 Then
                        _BonusMinutes = BonusSpanNet.TotalMinutes
                    Else
                        _BonusMinutes = BonusSpanAfterEnd.TotalMinutes
                    End If

                    If _Period1 = 0 Then
                        _Period2 = 0
                    Else
                        _Period2 = _BonusMinutes - _Period1
                    End If

                    If _BonusMinutes > _CalcBonusAfterMinitues Then
                        If _Period1 <> 0 Then
                            '_HoursFactor = ((_Period1 * _Factor1) + (_Period2 * _Factor2)) / 60
                            _HoursFactor = (_BonusMinutes * _Factor1) / 60
                        Else
                            _HoursFactor = (_BonusMinutes * _Factor1) / 60
                        End If
                    Else
                        _HoursFactor = (_BonusMinutes * _Factor1) / 60
                    End If

                    'If BonusAmountAfterRequirdHoures = 1 Then
                    '    ListDays.Rows(i).Item("BonusAmount") = Format((BonusSpanNet.TotalHours * BonusPerHour) * (_SalaryPerHour), "0.00")
                    '    ListDays.Rows(i).Item("LeavesAmount") = Format((LeaveSpanNet.TotalHours - LateSpan.TotalHours + LateSpan.TotalHours * FactorLate) * (_SalaryPerHour), "0.00")
                    'Else
                    '    ListDays.Rows(i).Item("BonusAmount") = Format((BonusSpanAfterEnd.TotalHours * BonusPerHour) * (_SalaryPerHour), "0.00")
                    '    If _AddBonusBeforeShift = True Then ListDays.Rows(i).Item("BonusAmount") += Format((BonusSpanBeforeBeg.TotalHours * BonusPerHour) * (_SalaryPerHour), "0.00")
                    '    ListDays.Rows(i).Item("LeavesAmount") = Format(((LateSpan.TotalHours * FactorLate) + LeaveSpan.TotalHours + LeavesDuringDay.TotalHours) * (_SalaryPerHour), "0.00")
                    'End If


                    If BonusAmountAfterRequirdHoures = 1 Then
                        ListDays.Rows(i).Item("BonusAmount") = Format((_HoursFactor) * (_SalaryPerHour), "0.00")
                        ListDays.Rows(i).Item("LeavesAmount") = Format((LeaveSpanNet.TotalHours - LateSpan.TotalHours + LateSpan.TotalHours * FactorLate) * (_SalaryPerHour), "0.00")
                    Else
                        ListDays.Rows(i).Item("BonusAmount") = Format((_HoursFactor) * (_SalaryPerHour), "0.00")
                        If _AddBonusBeforeShift = True Then ListDays.Rows(i).Item("BonusAmount") += Format((BonusSpanBeforeBeg.TotalHours * BonusPerHour) * (_SalaryPerHour), "0.00")
                        If CalcLeavesDuringWorkFromVocations And Vocation_Balance > 0 Then
                            ListDays.Rows(i).Item("LeavesAmount") = Format(((LateSpan.TotalHours * FactorLate) + LeaveSpan.TotalHours) * (_SalaryPerHour), "0.00")
                        Else
                            ListDays.Rows(i).Item("LeavesAmount") = Format(((LateSpan.TotalHours * FactorLate) + LeaveSpan.TotalHours + LeavesDuringDay.TotalHours) * (_SalaryPerHour), "0.00")
                        End If

                    End If

                Else
                    ListDays.Rows(i).Item("BonusAmount") = 0
                    ListDays.Rows(i).Item("LeavesAmount") = 0
                End If



                ' حساب مبلغ الغياب
                If _CalAbsentInSalary = True Then
                    If ListDays.Rows(i).Item("AttStatus") = "دوام" Or ListDays.Rows(i).Item("AttStatus") = "عطلة" Then
                        ListDays.Rows(i).Item("SalaryPerDay") = SalaryPerDay
                    ElseIf ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" And ProcessType = "5" Then
                        ListDays.Rows(i).Item("SalaryPerDay") = SalaryPerDay
                        ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                    ElseIf ProcessType = "4" Then
                        ListDays.Rows(i).Item("SalaryPerDay") = SalaryPerDay
                        ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                    Else
                        ListDays.Rows(i).Item("SalaryPerDay") = 0
                        If VocationPaid = True Then
                            ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                            'If ListDays.Rows(i).Item("VocationSource") = "vocation" Then
                            '    ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                            'End If
                            'If ListDays.Rows(i).Item("VocationSource") = "adjust" Then
                            '    ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                            'End If
                        Else
                            ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerDay
                            ListDays.Rows(i).Item("LeavesAmount") = 0
                        End If
                    End If
                Else
                    ListDays.Rows(i).Item("AbsentDaysAmount") = 0
                End If



                If SubtractionLeavesAndLates = False Then
                    ListDays.Rows(i).Item("LeavesAmount") = 0
                End If


                If ListDays.Rows(i).Item("AttStatus") = "دوام" Then
                    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                ElseIf ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" And ProcessType = "5" Then
                    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                    ListDays.Rows(i).Item("AttStatus") = "دوام"
                ElseIf ProcessType = "4" Then
                    ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                Else
                    ListDays.Rows(i).Item("DailyTransport") = 0
                End If


                If Not IsDBNull(ListDays.Rows(i).Item("AbsentDaysAmount")) Then AbsentDaysAmount = ListDays.Rows(i).Item("AbsentDaysAmount")

                '    SalaryPerDayPerMonth = Format(Salary / DateTime.DaysInMonth(CDate(ListDays.Rows(i).Item("TransDate")).Year, CDate(ListDays.Rows(i).Item("TransDate")).Month), "0.00")
                ' SalaryPerDayPerMonth = Format(Salary / DateTime.DaysInMonth(CDate(ListDays.Rows(i).Item("TransDate")).Year, CDate(ListDays.Rows(i).Item("TransDate")).Month), "0.00")

                Select Case DaysPerMonth
                    Case "DaysInMonth"
                        SalaryPerDayPerMonth = Format(Salary / DateTime.DaysInMonth(CDate(ListDays.Rows(i).Item("TransDate")).Year, CDate(ListDays.Rows(i).Item("TransDate")).Month), "0.00")
                    Case Else
                        SalaryPerDayPerMonth = (Salary / DaysPerMonth)
                End Select


                '         تحويل يوم العطلة الى دوام اذا كان دوام يوم العطلة
                If (Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) And Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal"))) And (ListDays.Rows(i).Item("AttStatus") = "عطلة" Or ListDays.Rows(i).Item("Voc") <> "0") Then
                    ListDays.Rows(i).Item("AttStatus") = "دوام"
                    If RequiredDailyHoures.TotalHours = 0 Then
                        XtraMessageBox.Show("بجب تحديد عدد الساعات المطلوبة في بيانات الموظف لكي يتم احتساب الدوام يوم العطلة")
                    Else
                        Try
                            Dim TT As TimeSpan
                            Dim StartTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("StartTimeReal"), "HH:mm:ss"))
                            Dim EndTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("EndTimeReal"), "HH:mm:ss"))
                            If EndTimeReal.TimeOfDay >= StartTimeReal.TimeOfDay Then
                                ListDays.Rows(i).Item("ElapseTime") = EndTimeReal.Subtract(StartTimeReal)
                            Else
                                ListDays.Rows(i).Item("ElapseTime") = (EndTimeReal.AddDays(1)).Subtract(StartTimeReal)
                            End If
                            TT = ListDays.Rows(i).Item("ElapseTime")
                            ListDays.Rows(i).Item("DailyTransport") = DailyTransport
                            Dim BonusBefore As Decimal
                            'اذا تم تفعيل خيار الراتب بالساعة من شاشاة الاعدادات
                            If _GetSalaryPerHourFromEmployee_ShiftReport = True Then
                                BonusBefore = TT.TotalHours * _SalaryPerHourFromEmployeeData
                            Else
                                BonusBefore = TT.TotalHours * (SalaryPerDayPerMonth / RequiredDailyHoures.TotalHours)
                            End If
                            ListDays.Rows(i).Item("BonusAmount") = Format(BonusBefore * BonusOnDayOff, "0.00")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                End If

                If AddBonusToSalary = False Then ListDays.Rows(i).Item("BonusAmount") = 0

                ListDays.Rows(i).Item("SalaryPerDayPerMonth") = SalaryPerDayPerMonth

                ListDays.Rows(i).Item("GrossSalary") = ListDays.Rows(i).Item("SalaryPerDayPerMonth") + ListDays.Rows(i).Item("BonusAmount") + ListDays.Rows(i).Item("DailyTransport") - ListDays.Rows(i).Item("LeavesAmount") - AbsentDaysAmount

                If _PrintSalary = True Then
                    Dim sql As New SQLControl
                    Dim sqlStrig As String = " Delete from  "
                End If

                If _PaymentFound = True Then
                    ListDays.Rows(i).Item("Payment") = GetPayment(ListDays.Rows(i).Item("EmpID").ToString, Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd").ToString)
                Else
                    ListDays.Rows(i).Item("Payment") = 0
                End If


                If _AdditionsFound = True Then
                    ListDays.Rows(i).Item("Additions") = GetAdditions(ListDays.Rows(i).Item("EmpID").ToString, Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd").ToString)
                Else
                    ListDays.Rows(i).Item("Additions") = 0
                End If


                ListDays.Rows(i).Item("NetSalary") = ListDays.Rows(i).Item("GrossSalary") - ListDays.Rows(i).Item("Payment") + ListDays.Rows(i).Item("Additions")

                ListDays.Rows(i).Item("NetSalaryMonthDays") = ListDays.Rows(i).Item("SalaryPerDayPerMonth") + ListDays.Rows(i).Item("BonusAmount") _
                                                              + ListDays.Rows(i).Item("DailyTransport") - ListDays.Rows(i).Item("LeavesAmount") _
                                                              - ListDays.Rows(i).Item("Payment") - AbsentDaysAmount + ListDays.Rows(i).Item("Additions")

                If ListDays.Rows(i).Item("AttStatus") = "غياب" Or ListDays.Rows(i).Item("AttStatus") = "خطا بصمة" Then
                    ListDays.Rows(i).Item("NetSalaryMonthDays") = 0
                    ListDays.Rows(i).Item("NetSalary") = 0
                    ListDays.Rows(i).Item("GrossSalary") = 0
                End If

                If ListDays.Rows(i).Item("AttStatus") = "دوام" Then ListDays.Rows(i).Item("AttendentDays") = 1
                'If ListDays.Rows(i).Item("AttStatus") = "سنوية" Then ListDays.Rows(i).Item("VocationDays") = 1
                If ListDays.Rows(i).Item("AttStatus") = "عطلة" Then ListDays.Rows(i).Item("OffDays") = 1
                If ListDays.Rows(i).Item("AttStatus") = "غياب" Then ListDays.Rows(i).Item("AbsentDays") = 1
                '  ListDays.Rows(i).Item("Salary") = Salary
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try



            '''' ترجم
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
        myconnection.Close()

        If _SubtractAbsenceFromHolidays = True Then
            Dim _Alldays As Decimal
            Dim _Absencedays As Decimal
            Dim _Holidays As Decimal
            Dim _Percent As Decimal
            Dim _AmountToDeduct As Decimal
            _Alldays = ListDays.Rows.Count
            _Absencedays = ListDays.Compute("Count(AttStatus)", "AttStatus = 'غياب'")
            If _Absencedays > 6 Then
                _Holidays = ListDays.Compute("Count(AttStatus)", "AttStatus = 'عطلة'")
                _Percent = _Absencedays / _Alldays
                _AmountToDeduct = CDec(SalaryPerDay * _Percent).ToString("n2")
                If _AmountToDeduct <> 0 Then
                    For i = 0 To ListDays.Rows.Count - 1
                        If ListDays.Rows(i).Item("AttStatus") = "عطلة" Then
                            ListDays.Rows(i).Item("AbsentDaysAmount") = _AmountToDeduct
                            ' ListDays.Rows(i).Item("AbsentDaysAmount") = SalaryPerDay - _AmountToDeduct
                        End If
                    Next
                End If
            End If
        End If

        'If MaxLeavesHoures <> "00:00" Then

        '    Dim _LeavesHoures As String
        '    If Not IsNothing(ColLeaves.SummaryItem.SummaryValue) Or Not String.IsNullOrEmpty(ColLeaves.SummaryItem.SummaryValue) Then
        '        _LeavesHoures = ColLeaves.SummaryItem.SummaryValue
        '        MsgBox(ListDays.Compute("sum(LeavesAmount)", ""))
        '        MsgBox(LeaveSpanTotalPerEmployee)
        '    Else
        '        _LeavesHoures = "00:00"
        '    End If

        '    Dim _LeavesAmount As Decimal
        '    _LeavesAmount = CDec(ColLeavesAmount.SummaryItem.SummaryValue)

        'End If

        ' how i can use compute in datatable  

EEnd:

        QueryData = ListDays


    End Function


    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LookUpEdit10.EditValueChanged

        Grouping()

    End Sub


    Private Sub Grouping()

        BandedGridView1.BeginSort()

        Summery = True

        Try

            BandedGridView1.ClearGrouping()
            Select Case LookUpEdit10.EditValue

                Case 1
                    '  TextEdit1.Text = ""
                    BandedGridView1.Columns("EmployeeName").GroupIndex = 0
                    '   BandedGridView1.Columns("TransDate").GroupIndex = -1
                 '   BandedGridView1.Columns("TransDay").GroupIndex = -1
                Case 2

                    '  BandedGridView1.Columns("EmployeeName").GroupIndex = -1
                    '  BandedGridView1.Columns("TransDate").GroupIndex = -1
                    BandedGridView1.Columns("TransDate").GroupIndex = -0
                Case 3

                    '  BandedGridView1.Columns("EmployeeName").GroupIndex = -1
                    '  BandedGridView1.Columns("TransDate").GroupIndex = -1
                    BandedGridView1.Columns("TransDay").GroupIndex = -0
            End Select
        Catch ex As Exception

        Finally
            BandedGridView1.EndSort()

        End Try
    End Sub





    Private Function GetSumActual(EmpID As String, DateFrom As String) As TimeSpan
        Dim CheckInOutTable As New DataTable
        With CheckInOutTable
            .Columns.Add("TransDate", GetType(DateTime))
            .Columns.Add("TransDay", GetType(String))
            .Columns.Add("EmpID", GetType(String))
            .Columns.Add("EmployeeName", GetType(String))
            .Columns.Add("StartTimeReal", GetType(DateTime))
            .Columns.Add("EndTimeReal", GetType(DateTime))
            .Columns.Add("ElapseTime", GetType(TimeSpan))
            .Columns.Add("TransInID", GetType(Integer))
            .Columns.Add("TransOutID", GetType(Integer))
            .Columns.Add("EditedType", GetType(String))
        End With

        Try


            Dim DateTo As String
            DateTo = Format(CDate(DateFrom).AddHours(26), "yyyy-MM-dd HH:mm:ss")
            Dim sql As New SQLControl
            Dim CheckInTimes As String
            Dim CheckInTimesTable As DataTable
            'Dim SqlString As String = " SELECT  CHECKTIME AS CheckINTimes, USERID, CHECKTYPE,id as checkinid
            '                            FROM      AttCHECKINOUT
            '                            WHERE     CHECKTIME between '" & DateFrom & "' and '" & DateTo & "' And USERID = '" & EmpID & "' and CHECKTYPE = 'I' COLLATE Latin1_General_CS_AS         
            '                            ORDER BY  CheckINTimes, CHECKTYPE"

            Dim SqlString As String = "WITH FilteredRecords AS (
                                        SELECT 
                                        CHECKTIME AS CheckINTimes, USERID, CHECKTYPE,id as checkinid,
                                        LAG(CHECKTIME) OVER (ORDER BY CHECKTIME) AS PrevCheckTime
                                        FROM 
                                        AttCHECKINOUT
                                        WHERE     CHECKTIME between '" & DateFrom & "' and '" & DateTo & "' And USERID = '" & EmpID & "' and CHECKTYPE = 'I' COLLATE Latin1_General_CS_AS          
                                        )
                                        SELECT 
                                        *
                                        FROM 
                                        FilteredRecords
                                        WHERE 
                                        PrevCheckTime IS NULL 
                                        OR DATEDIFF(MINUTE, PrevCheckTime, CheckINTimes) >= 10
                                        ORDER BY  CheckINTimes, CHECKTYPE"
            If _UseLocalDataBaseForReport = True Then
                sql.SqlLocalTrueTimeRunQuery(SqlString)
            Else
                sql.SqlTrueTimeRunQuery(SqlString)
            End If
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Function
            CheckInTimesTable = sql.SQLDS.Tables(0)

            Dim i As Integer
            For i = 0 To CheckInTimesTable.Rows.Count - 1
                CheckInTimes = CheckInTimesTable.Rows(i).Item("CheckINTimes")

                '         If CheckInTimesTable.Rows(i).Item("CheckINTimes") <> CheckInTimesTable.Rows(i + 1).Item("CheckINTimes") Then




                Dim CheckIn As String = Format(CDate(CheckInTimes), "yyyy-MM-dd HH:mm:ss")
                Dim CheckOut As String = Format(CDate(CheckInTimes).AddHours(23.999), "yyyy-MM-dd HH:mm:ss")
                'Dim CheckOutSQL As String = "SELECT   [ID] As CheckOutID,CHECKTYPE,USERID,CHECKTIME FROM [AttCHECKINOUT] 
                '                             Where    USERID= '" & EmpID & "'  and CHECKTIME between '" & CheckIn & "' And '" & CheckOut & "' 
                '                                     and CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS  
                '                             Order By CHECKTIME, CHECKTYPE "
                Dim CheckOutSQL As String = " WITH FilteredRecords AS (
                                                SELECT 
                                                [ID] As CheckOutID,CHECKTYPE,USERID,CHECKTIME,
                                                LAG(CHECKTIME) OVER (ORDER BY CHECKTIME) AS PrevCheckTime
                                                FROM 
                                                AttCHECKINOUT
                                                 Where    USERID= '" & EmpID & "'  and CHECKTIME between '" & CheckIn & "' And '" & CheckOut & "' and CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS     
                                                )
                                                SELECT 
                                                *
                                                FROM 
                                                FilteredRecords
                                                WHERE 
                                                PrevCheckTime IS NULL 
                                                OR DATEDIFF(MINUTE, PrevCheckTime, CHECKTIME) >= 10
                                                ORDER BY  CHECKTIME  "

                If _UseLocalDataBaseForReport = True Then
                    sql.SqlLocalTrueTimeRunQuery(CheckOutSQL)
                Else
                    sql.SqlTrueTimeRunQuery(CheckOutSQL)
                End If


                Dim ItemTransDate As Date
                Dim ItemStartTime, ItemEndTime As DateTime
                Dim ItemTransDay, ItemEmpID, ItemEmpName As String
                Dim ItemTransInID, ItemTransOutID As Integer
                Dim ElapseTime As TimeSpan
                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    ItemTransDate = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    ' ItemTransDay = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    ItemTransDay = ItemTransDate.ToString("dddd", New System.Globalization.CultureInfo("ar-AE"))
                    ItemEmpID = EmpID
                    ItemEmpName = EmployeeName
                    ItemStartTime = Format(CDate(CheckInTimes), "HH:mm:ss")
                    ItemEndTime = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("CHECKTIME")), "HH:mm:ss")


                    ElapseTime = CDate(Format(sql.SQLDS.Tables(0).Rows(0).Item("CHECKTIME"), "yyyy-MM-dd HH:mm:ss")).Subtract(CheckInTimes)
                    If ElapseTime > TimeSpan.Parse("20:00") Then ElapseTime = TimeSpan.Zero
                    ItemTransInID = CheckInTimesTable.Rows(i).Item("CheckInID")
                    ItemTransOutID = sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID")
                    CheckInOutTable.Rows.Add(ItemTransDate, ItemTransDay, ItemEmpID, ItemEmpName, ItemStartTime, ItemEndTime, ElapseTime, ItemTransInID, ItemTransOutID)
                Else
                    ItemTransDate = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    ItemTransDay = Format(CDate(CheckInTimes), "dddd")
                    ItemEmpID = EmpID
                    ItemEmpName = EmployeeName
                    ItemStartTime = Format(CDate(CheckInTimes), "HH:mm:ss")
                    ItemTransInID = CheckInTimesTable.Rows(i).Item("CheckInID")
                    CheckInOutTable.Rows.Add(ItemTransDate, ItemTransDay, ItemEmpID, ItemEmpName, ItemStartTime, "00:00", TimeSpan.Zero, ItemTransInID, 0)

                End If


                ' MsgBox(CheckInOutTable.Rows(i).Item("ElapseTime"))
                '  End If
            Next
            Dim SumActualDurations As TimeSpan = (CheckInOutTable.Compute("SUM(ElapseTime)", String.Empty))
            'Dim ClipRow As String = String.Empty
            'Dim ClipText As String = String.Empty
            ''Data rows
            'For Each row As DataRow In CheckInOutTable.Rows
            '    ClipRow = String.Empty

            '    For Each col As DataColumn In CheckInOutTable.Columns
            '        If Not String.IsNullOrEmpty(ClipRow) Then
            '            ClipRow += ControlChars.Tab
            '        End If

            '        ClipRow += row(col.ColumnName)
            '    Next

            '    ClipText += ClipRow + ControlChars.NewLine
            'Next

            'Clipboard.SetText(ClipText)




            GetSumActual = SumActualDurations

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try








    End Function

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            gridBand3.Visible = True
            gridBand4.Visible = True
            gridBand5.Visible = True
            gridBand2.Visible = True
        ElseIf CheckEdit1.Checked = False Then
            gridBand3.Visible = False
            gridBand4.Visible = False
            gridBand5.Visible = False
            gridBand2.Visible = False
        End If
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

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit2.CheckedChanged
        If CheckEdit2.Checked = True Then
            BandedGridView1.OptionsView.ColumnAutoWidth = True
        Else
            BandedGridView1.OptionsView.ColumnAutoWidth = False
        End If
        BandedGridView1.BestFitColumns()
    End Sub

    Private Sub RadioGroup2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup2.SelectedIndexChanged
        Select Case RadioGroup2.EditValue
            Case 1
                BandedGridView1.ExpandAllGroups()

            Case 2
                BandedGridView1.CollapseAllGroups()
        End Select
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If GlobalVariables._SystemLanguage = "Arabic" Then
            PrintRateb()
        Else
            PrintRatebEn()
        End If


    End Sub

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

        If SearchLookUpEdit1.Text = String.Empty Then Exit Sub
        If Me.BandedGridView1.RowCount = 0 Then Exit Sub

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
            ' Dim report As New SalaryReport()
            Dim report As New SalaryReport
            ' Dim report As XtraReport
            'If GlobalVariables._SystemLanguage = "Arabic" Then
            '    report = New SalaryReport
            'Else
            '    report = New SalaryStatmentEn
            'End If
            Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim _DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")


            report.Parameters("EmployeeName").Value = Me.SearchLookUpEdit1.Text
            ' report.Parameters("PeriodString").Value = "قسيمة راتب لشهر  " & " " & Month(DateEdit1.DateTime) & " / " & Year(DateEdit1.DateTime)

            'If GlobalVariables._SystemLanguage = "Arabic" Then
            report.Parameters("PeriodString").Value = " من " & _DateFrom & " الى " & _DateTo
            'Else
            '   report.Parameters("PeriodString").Value = " From " & _DateFrom & " To " & _DateTo
            ' End If



            report.Parameters("DateFrom").Value = _DateFrom
            report.Parameters("DateTo").Value = _DateTo

            report.Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
            report.NoteLabel.Text = _SalaryNoteLabel

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
                            report.XrLabelProcessTypeWords.Text = " راتب لا يتطلب دوام "
                        Case 5
                            report.XrLabelProcessTypeWords.Text = "دوام بوجود حركة"
                    End Select
                    report.ProcessType.Value = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("ProcessType"))
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try



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

            With report
                .Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
                .Parameters("SalaryMonth").Value = ColSalary.SummaryItem.SummaryValue
                .Parameters("BonusAmount").Value = ColBonusAmount.SummaryItem.SummaryValue
                .Parameters("Transport").Value = ColTransport.SummaryItem.SummaryValue
                .Parameters("LeavesAmount").Value = ColLeavesAmount.SummaryItem.SummaryValue
                .Parameters("AbsenceAmount").Value = ColAbsentDaysAmount.SummaryItem.SummaryValue
                .Parameters("GrossSalary").Value = ColGrossSalary.SummaryItem.SummaryValue
                .Parameters("Payment").Value = ColPayment.SummaryItem.SummaryValue
                .Parameters("Additions").Value = ColAdditions.SummaryItem.SummaryValue
                .Parameters("NetSalary").Value = ColNetSalaryNew.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColNetSalaryMonthDays.SummaryItem.SummaryValue
                .Parameters("ActualDays").Value = ColAttendentDays.SummaryItem.SummaryValue
                .Parameters("VocationDays").Value = ColVocID.SummaryItem.SummaryValue
                .Parameters("WeekOffDays").Value = ColOffDays.SummaryItem.SummaryValue
                .Parameters("AbsenceDays").Value = ColAbsentDays.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColTransDate.SummaryItem.SummaryValue
                .Parameters("HouresRequired").Value = ColElapseTimePlane.SummaryItem.SummaryValue
                .Parameters("ActualHoures").Value = ColElapseTime.SummaryItem.SummaryValue


                If BonusAmountAfterRequirdHoures = 1 Then
                    .Parameters("HouresNetBonus").Value = ColBonusSpanNet.SummaryItem.SummaryValue
                    .Parameters("HouresNetLeaves").Value = ColLeaveSpanNet.SummaryItem.SummaryValue
                Else
                    .Parameters("HouresNetBonus").Value = ColBonusSpanTotal.SummaryItem.SummaryValue
                    .Parameters("HouresNetLeaves").Value = ColLeaves.SummaryItem.SummaryValue
                End If

                'Dim _VocationDetails = GetVocationsBalancesByEmployee(SearchLookUpEdit1.EditValue, 1, Today())
                .Parameters("AccruedVocationDays").Value = Vocation_AccruedVocations
                .Parameters("VocationSick").Value = "0"
                .Parameters("VocationBegBalance").Value = Vocation_BeginingBalance
                .Parameters("VocationAtEndYear").Value = Vocation_Balance
                .Parameters("MaxLeavesHoures").Value = MaxLeavesHoures

                If BonusAmountAfterRequirdHoures = 1 Then
                    .Parameters("Leaves").Value = ColLeaveSpanNet.SummaryItem.SummaryValue
                Else
                    .Parameters("Leaves").Value = ColLeaves.SummaryItem.SummaryValue
                End If







                ' .SqlDataSource1.Queries(0).Parameters(0).Value = 2
                '  .SqlDataSource1.Fill()
            End With



            ' report.Parameters("Salary").Value = .Item7


            '  report.Parameter1.Visible = False
            ' report.VocBalance.Value = Me.TextVocationsRemaining.Text
            ' report.VocBalance.Visible = False
            ' تحميل اعدادات طباعة 

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
                    SqlString = "  SELECT  T.[AdditionsType] as AdditionType ,sum(AdditionAmount) as AdditionAmount FROM [dbo].[AttEmployeeAdditions] A
                                        left join EmployeesData E on A.EmployeeID=E.EmployeeID left join [AttAdditionsTypes] T on A.AdditionType=T.ID
                                        Where AdditionDate BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and A.EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by T.[AdditionsType]  "
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
                    'SqlString = "  SELECT  P.[PaymentType],sum([PaymentAmount]) as PaymentAmount FROM [dbo].[AttEmployeePayments] P
                    '                    left join EmployeesData E on P.EmployeeID=E.EmployeeID
                    '                    Where P.[Status]=1 And [PaymentDate] BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                    '                    and P.EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                    '                    group by [PaymentType] "
                    SqlString = "  SELECT  T.[PaymentType] as PaymentType,sum([PaymentAmount]) as PaymentAmount FROM [dbo].[AttEmployeePayments] P
                                        left join EmployeesData E on P.EmployeeID=E.EmployeeID left join [AttPaymentsTypes] T on P.PaymentType=T.ID
                                        Where P.[Status]=1 And [PaymentDate] BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and P.EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by T.[PaymentType] "
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



            Try
                If ColAdditions.SummaryItem.SummaryValue = 0 Then
                    report.XrLabelAdditionsAmount.Visible = False
                    report.XrLabelAdditionsParameters.Visible = False
                End If
                If ColTransport.SummaryItem.SummaryValue = 0 Then
                    report.XrTranport.Visible = False
                    report.XrLabelTransport.Visible = False
                End If
            Catch ex As Exception

            End Try

            'If GlobalVariables._SystemLanguage = "English" Then
            '    report.ApplyLocalization(New CultureInfo("EN"))
            'End If

            report.CreateDocument()

            report.PrintingSystem.ShowMarginsWarning = False



            'Dim myItem As BarItem = New BarButtonItem() With {.Caption = "MyButton"}
            'Dim pt As New ReportPrintTool(report)
            'Dim manager As BarManager = TryCast((TryCast(pt.PreviewForm, PrintPreviewFormEx)).PrintBarManager, BarManager)
            'manager.Bars("Toolbar").AddItem(myItem)
            'pt.ShowPreview()


            'If GlobalVariables._SystemLanguage = "English" Then
            '    report.XrLabelPhone.Text = "Phone"
            '    report.XrLabelPhax.Text = "Fax"
            'End If

            SalaryMonthForm.DocumentViewer1.DocumentSource = report

            '    report.ShowPreview
            SalaryMonthForm.Show()

        Catch ex As Exception
            MsgBox("Error ")
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SaveSalary()
        Dim _DateFrom As String = Format(CDate(DateEdit1.DateTime), "yyyy-MM-dd")
        Dim _DateTo As String = Format(CDate(DateEdit2.DateTime), "yyyy-MM-dd")
        Dim SQl4 As New SQLControl
        Dim Sql As New SQLControl
        Dim _ID As Integer = 0
        Dim SqlString As String
        Try
            Dim _BonusAmount As Decimal
            If Not IsNothing(ColBonusAmount.SummaryItem.SummaryValue) Then
                _BonusAmount = ColBonusAmount.SummaryItem.SummaryValue
            Else
                _BonusAmount = 0
            End If
            Dim _Transport As Decimal
            If Not IsNothing(ColTransport.SummaryItem.SummaryValue) Then
                _Transport = ColTransport.SummaryItem.SummaryValue
            Else
                _Transport = 0
            End If
            Dim _Additions As Decimal
            If Not IsNothing(ColAdditions.SummaryItem.SummaryValue) Then
                _Additions = ColAdditions.SummaryItem.SummaryValue
            Else
                _Additions = 0
            End If
            Dim _ActualHoures As String
            If Not IsNothing(ColActualElapseTime.SummaryItem.SummaryValue) Or Not String.IsNullOrEmpty(ColActualElapseTime.SummaryItem.SummaryValue) Then
                _ActualHoures = ColActualElapseTime.SummaryItem.SummaryValue
            Else
                _ActualHoures = "00:00"
            End If
            Dim _LeavesAmount As Decimal
            If Not IsNothing(ColLeavesAmount.SummaryItem.SummaryValue) Or Not String.IsNullOrEmpty(ColLeavesAmount.SummaryItem.SummaryValue) Then
                _LeavesAmount = ColLeavesAmount.SummaryItem.SummaryValue
            Else
                _LeavesAmount = "00:00"
            End If

            Dim _Leaves As String
            If Not IsNothing(ColLeaves.SummaryItem.SummaryValue) Or Not String.IsNullOrEmpty(ColLeaves.SummaryItem.SummaryValue) Then
                _Leaves = ColLeaves.SummaryItem.SummaryValue
            Else
                _Leaves = "00:00"
            End If

            Dim NetSalaryNew As String
            If Not IsNothing(ColNetSalaryNew.SummaryItem.SummaryValue) Or Not String.IsNullOrEmpty(ColNetSalaryNew.SummaryItem.SummaryValue) Then
                NetSalaryNew = ColNetSalaryNew.SummaryItem.SummaryValue
            Else
                NetSalaryNew = "0"
            End If

            Dim HR_ActiveSavingFund As Boolean
            Try
                SqlString = " select SettingValue From Settings where SettingName ='HR_ActiveSavingFund'"
                Sql.SqlTrueTimeRunQuery(SqlString)
                If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    HR_ActiveSavingFund = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
                Else
                    HR_ActiveSavingFund = False
                End If
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try

            Dim _employeedata = GetEmployeeData(SearchLookUpEdit1.EditValue)
            'Dim _VocationBalance As Decimal = GetVocationsBalancesByEmployee(SearchLookUpEdit1.EditValue, 1, DateEdit2.DateTime).Balance
            Dim _ActiveSavingFund As Boolean = _employeedata.ActiveSavingFund
            Dim _LeavesAfterMonthlyMaxLeavesHoures As TimeSpan = TimeSpan.Zero
            Dim _VocationNote As String = ""
            If _LeavesAmount > 0 Then
                Dim _SalaryPerHour As Decimal
                Dim _MaxMonthlyLeaves As TimeSpan = _employeedata.MonthlyMaxLeavesHoures
                Dim _TotalleavesHours As TimeSpan = _TimeSpanFunction.ConvertText_hhmm_ToTimeSpan(ColLeaves.SummaryItem.SummaryValue)
                _LeavesAfterMonthlyMaxLeavesHoures = _TotalleavesHours - _MaxMonthlyLeaves
                If _MaxMonthlyLeaves > TimeSpan.Zero Then
                    If ProcessType = 1 And _LeavesAfterMonthlyMaxLeavesHoures > TimeSpan.Zero Then
                        _SalaryPerHour = SalaryPerDayPerMonth / RequiredDailyHoures.TotalHours
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

            Dim connectionString As String = My.Settings.TrueTimeConnectionString


            ' Then, construct the insert query for adding a new record
            SqlString = "INSERT INTO [AttRawatebArchive] " &
                            "( [DateFrom], [DateTo], [EmployeeID], [EmployeeNoAsAcc], [EmployeeName], [Branch], [Department], [JobName], [BeginDate], " &
                            "[Currency], [SalaryMonth], [BonusAmount], [Transport], [Additions], [LeavesAmount], [Payment], [GrossSalary], [MonthDays], " &
                            "[ActualDays], [VocationDays], [WeekOffDays], [AbsenceDays], [HouresRequired], [ActualHoures], [VocationBegBalance], " &
                            "[AccruedVocationDays], [VocationAtEndYear], [VocationSick], [NetSalary], [HouresNetBonus], [HouresNetLeaves], [BankName], " &
                            "[BankNo], [BankBranch], [IBAN], [Indenty], [ArchiveStatus], [AbsenceAmount], [ProcessType] ) " &
                            "VALUES " &
                            "( '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', -- DateFrom: " & Format(DateEdit1.DateTime, "yyyy-MM-dd") & vbCrLf &
                            "  '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "', -- DateTo: " & Format(DateEdit2.DateTime, "yyyy-MM-dd") & vbCrLf &
                            "  '" & SearchLookUpEdit1.EditValue & "', -- EmployeeID: " & SearchLookUpEdit1.EditValue & vbCrLf &
                            "  '" & _employeedata.SalaryAccountNo & "', -- EmployeeNoAsAcc: " & _employeedata.SalaryAccountNo & vbCrLf &
                            "  N'" & _employeedata.EmployeeName & "', -- EmployeeName: " & _employeedata.EmployeeName & vbCrLf &
                            "  N'" & _employeedata.Branch & "', -- Branch: " & _employeedata.Branch & vbCrLf &
                            "  N'" & _employeedata.Department & "', -- Department: " & _employeedata.Department & vbCrLf &
                            "  N'" & _employeedata.JobName & "', -- JobName: " & _employeedata.JobName & vbCrLf &
                            "  '" & _employeedata.DateOfStart & "', -- BeginDate: " & _employeedata.DateOfStart & vbCrLf &
                            "  '" & _employeedata.SalaryCurrency & "', -- Currency: " & _employeedata.SalaryCurrency & vbCrLf &
                            "  '" & _employeedata.MonthlySalary & "', -- SalaryMonth: " & _employeedata.MonthlySalary & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(_BonusAmount) & "', -- BonusAmount: " & ConvertFromStringToDecimal(_BonusAmount) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(_Transport) & "', -- Transport: " & ConvertFromStringToDecimal(_Transport) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColAdditions.SummaryItem.SummaryValue) & "', -- Additions: " & ConvertFromStringToDecimal(ColAdditions.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(_LeavesAmount) & "', -- LeavesAmount: " & ConvertFromStringToDecimal(_LeavesAmount) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColPayment.SummaryItem.SummaryValue) & "', -- Payment: " & ConvertFromStringToDecimal(ColPayment.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(NetSalaryNew) & "', -- GrossSalary: " & ConvertFromStringToDecimal(NetSalaryNew) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColTransDate.SummaryItem.SummaryValue) & "', -- MonthDays: " & ConvertFromStringToDecimal(ColTransDate.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColAttendentDays.SummaryItem.SummaryValue) & "', -- ActualDays: " & ConvertFromStringToDecimal(ColAttendentDays.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColVocID.SummaryItem.SummaryValue) & "', -- VocationDays: " & ConvertFromStringToDecimal(ColVocID.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColOffDays.SummaryItem.SummaryValue) & "', -- WeekOffDays: " & ConvertFromStringToDecimal(ColOffDays.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColAbsentDays.SummaryItem.SummaryValue) & "', -- AbsenceDays: " & ConvertFromStringToDecimal(ColAbsentDays.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & ColElapseTimePlane.SummaryItem.SummaryValue & "', -- HouresRequired: " & ColElapseTimePlane.SummaryItem.SummaryValue & vbCrLf &
                            "  '" & _ActualHoures & "', -- ActualHoures: " & _ActualHoures & vbCrLf &
                            "  '" & 0 & "', -- VocationBegBalance: " & 0 & vbCrLf &
                            "  '" & 0 & "', -- AccruedVocationDays: " & 0 & vbCrLf &
                            "  '" & 0 & "', -- VocationAtEndYear: " & 0 & vbCrLf &
                            "  '" & 0 & "', -- VocationSick: " & 0 & vbCrLf &
                            "  '" & NetSalaryNew & "', -- NetSalary: " & NetSalaryNew & vbCrLf &
                            "  '" & ColBonusSpanTotal.SummaryItem.SummaryValue & "', -- HouresNetBonus: " & ColBonusSpanTotal.SummaryItem.SummaryValue & vbCrLf &
                            "  '" & _Leaves & "', -- HouresNetLeaves: " & ColLeaves.SummaryItem.SummaryValue & vbCrLf &
                            "  N'" & _employeedata.BankName & "', -- BankName: " & _employeedata.BankName & vbCrLf &
                            "  '" & _employeedata.BankAccountNo & "', -- BankNo: " & _employeedata.BankAccountNo & vbCrLf &
                            "  N'" & _employeedata.BankBranch & "', -- BankBranch: " & _employeedata.BankBranch & vbCrLf &
                            "  '" & _employeedata.Iban & "', -- IBAN: " & _employeedata.Iban & vbCrLf &
                            "  '" & _employeedata.Indenty & "', -- Indenty: " & _employeedata.Indenty & vbCrLf &
                            "  0, -- ArchiveStatus: 0" & vbCrLf &
                            "  '" & ConvertFromStringToDecimal(ColAbsentDaysAmount.SummaryItem.SummaryValue) & "', -- AbsenceAmount: " & ConvertFromStringToDecimal(ColAbsentDaysAmount.SummaryItem.SummaryValue) & vbCrLf &
                            "  '" & 0 & "' -- ProcessType: 0" & vbCrLf &
                            "); SELECT SCOPE_IDENTITY() ;"



            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(SqlString, connection)
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
                    Else
                        MsgBox(" لم يتم اصدار راتب ")
                        Exit Sub
                    End If
                    connection.Close()
                    ReCalcSalaryDocument(insertedId)
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
    Private Function ConvertFromStringToDecimal(_String As String) As Decimal
        If String.IsNullOrEmpty(_String) Then
            Return 0
        Else
            Return Decimal.Parse(_String)
        End If
    End Function

    Private Sub PrintRatebEn()

        If SearchLookUpEdit1.Text = String.Empty Then Exit Sub
        If Me.BandedGridView1.RowCount = 0 Then Exit Sub

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
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='VocationTableInMonthSalaryVisible'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then _ShowVocationsTable = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim report As New SalaryStatmentEn
            Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim _DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")
            report.Parameters("EmployeeName").Value = Me.SearchLookUpEdit1.Text
            report.Parameters("PeriodString").Value = " From " & _DateFrom & " To " & _DateTo
            report.Parameters("DateFrom").Value = _DateFrom
            report.Parameters("DateTo").Value = _DateTo
            report.Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
            report.NoteLabel.Text = _SalaryNoteLabel
            Try
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Select [BankName] ,[BankNo] ,[BankBranch] ,[IBAN],[Indenty]
                              from EmployeesData
                              where EmployeeID='" & CStr(SearchLookUpEdit1.EditValue) & "'"
                Sql.SqlTrueTimeRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankName")) Then report.Parameters("BankName").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankName")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankNo")) Then report.Parameters("BankNo").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankNo")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("BankBranch")) Then report.Parameters("BankBranch").Value = Sql.SQLDS.Tables(0).Rows(0).Item("BankBranch")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("IBAN")) Then report.Parameters("IBAN").Value = Sql.SQLDS.Tables(0).Rows(0).Item("IBAN")
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Indenty")) Then report.Parameters("Indenty").Value = Sql.SQLDS.Tables(0).Rows(0).Item("Indenty")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

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

            With report
                .Parameters("EmployeeNo").Value = Me.SearchLookUpEdit1.EditValue
                .Parameters("SalaryMonth").Value = ColSalary.SummaryItem.SummaryValue
                .Parameters("BonusAmount").Value = ColBonusAmount.SummaryItem.SummaryValue
                .Parameters("Transport").Value = ColTransport.SummaryItem.SummaryValue
                .Parameters("LeavesAmount").Value = ColLeavesAmount.SummaryItem.SummaryValue
                .Parameters("AbsenceAmount").Value = ColAbsentDaysAmount.SummaryItem.SummaryValue
                .Parameters("GrossSalary").Value = ColGrossSalary.SummaryItem.SummaryValue
                .Parameters("Payment").Value = ColPayment.SummaryItem.SummaryValue
                .Parameters("Additions").Value = ColAdditions.SummaryItem.SummaryValue
                .Parameters("NetSalary").Value = ColNetSalaryNew.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColNetSalaryMonthDays.SummaryItem.SummaryValue
                .Parameters("ActualDays").Value = ColAttendentDays.SummaryItem.SummaryValue
                .Parameters("VocationDays").Value = ColVocID.SummaryItem.SummaryValue
                .Parameters("WeekOffDays").Value = ColOffDays.SummaryItem.SummaryValue
                .Parameters("AbsenceDays").Value = ColAbsentDays.SummaryItem.SummaryValue
                .Parameters("MonthDays").Value = ColTransDate.SummaryItem.SummaryValue
                .Parameters("HouresRequired").Value = ColElapseTimePlane.SummaryItem.SummaryValue
                .Parameters("ActualHoures").Value = ColElapseTime.SummaryItem.SummaryValue

                If BonusAmountAfterRequirdHoures = 1 Then
                    .Parameters("HouresNetBonus").Value = ColBonusSpanNet.SummaryItem.SummaryValue
                    .Parameters("HouresNetLeaves").Value = ColLeaveSpanNet.SummaryItem.SummaryValue
                Else
                    .Parameters("HouresNetBonus").Value = ColBonusSpanِAfterEnd.SummaryItem.SummaryValue
                    .Parameters("HouresNetLeaves").Value = ColLeaves.SummaryItem.SummaryValue
                End If
                'Dim _VocationDetails = GetVocationsBalancesByEmployee(SearchLookUpEdit1.EditValue, 1, Today())
                '_VocationBalances = GetVocationsBalancesByEmployee(Me.SearchLookUpEdit1.EditValue, 1, Me.DateEdit2.DateTime)
                .Parameters("AccruedVocationDays").Value = Vocation_AccruedVocations
                .Parameters("VocationBegBalance").Value = Vocation_BeginingBalance
                .Parameters("VocationAtEndYear").Value = Vocation_Balance
                .Parameters("VocationSick").Value = "0"
                .Parameters("MaxLeavesHoures").Value = MaxLeavesHoures
                .Parameters("Leaves").Value = ColLeaves.SummaryItem.SummaryValue
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

                ' .SqlDataSource1.Queries(0).Parameters(0).Value = 2
                '  .SqlDataSource1.Fill()
            End With

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

            If _ShowVocationsTable = "True" Then
                Try
                    Dim SqlString As String
                    Dim Sql As New SQLControl
                    SqlString = " select T.Vocation,Sum(V.NoDays) as VocationNo from Vocations V
                                        left join VocationsTypes T on V.VocationType=T.VocID 
                                       Where FromDate BETWEEN '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "' AND '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "' 
                                        and EmployeeID='" & Me.SearchLookUpEdit1.EditValue & "'
                                        group by T.Vocation "
                    Sql.SqlTrueTimeRunQuery(SqlString)
                    GridControl2.DataSource = Sql.SQLDS.Tables(0)
                    report.PrintableComponentContainer1.PrintableComponent = GridControl2
                    report.PrintableComponentContainer1.Visible = True
                Catch ex As Exception
                End Try

            End If

            report.CreateDocument()
            report.PrintingSystem.ShowMarginsWarning = False
            SalaryMonthForm.DocumentViewer1.DocumentSource = report

            '    report.ShowPreview
            SalaryMonthForm.Show()

        Catch ex As Exception
            MsgBox("Error ")
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged

        If SearchLookUpEdit1.Text = String.Empty Then
            LookUpEditBranch.ReadOnly = False
            LookUpEditPosition.ReadOnly = False
            LookUpEditDepartment.ReadOnly = False
        Else
            LookUpEditBranch.ReadOnly = True
            LookUpEditBranch.EditValue = String.Empty
            LookUpEditPosition.ReadOnly = True
            LookUpEditPosition.EditValue = String.Empty
            LookUpEditDepartment.ReadOnly = True
            LookUpEditDepartment.EditValue = String.Empty
        End If
    End Sub

    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        ' Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
        GetEmployeesList()
    End Sub
    Private Sub GetEmployeesList()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = "  
                                select EmployeeID, EmployeeName, [Department], [JobName], [Branch], [PictureEmp]
                                from [EmployeesData] E
                                where ( E.ProcessType=1 OR E.ProcessType=4 OR E.ProcessType=5 )  and E.[Active] =1 And E.EmployeeID <> -999 and  E.EmployeeID <> 9999 and E.EmployeeID <> 8888 
                             "
            sql.SqlTrueTimeRunQuery(SqlString)
            SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub GridView1_CustomDrawRowFooterCell(ByVal sender As Object, ByVal e As FooterCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawRowFooterCell
        If e.Column Is ColNetSalaryNew Then
            Dim view As GridView = CType(sender, GridView)

            e.Info.DisplayText = (Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("17001"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("BonusAmount"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Additions"), GridGroupSummaryItem))) +
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Transport"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("LeavesAmount"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("Payment"), GridGroupSummaryItem))) -
                Convert.ToDecimal(view.GetGroupSummaryValue(e.RowHandle, CType(view.GroupSummary("AbsentDaysAmount"), GridGroupSummaryItem)))).ToString()
            '   e.Info.DisplayText = "1000"
            'e.TotalValu e = ColSalary.SummaryItem.SummaryValue + ColBonusAmount.SummaryItem.SummaryValue _
            '                       + ColTransport.SummaryItem.SummaryValue - ColLeavesAmount.SummaryItem.SummaryValue _
            '                       - ColPayment.SummaryItem.SummaryValue - ColAbsentDaysAmount.SummaryItem.SummaryValue + ColAdditions.SummaryItem.SummaryValue
        End If

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

    Private Sub SimpleButtonPrint_Click(sender As Object, e As EventArgs) Handles SimpleButtonPrint.Click
        '   BandedGridView1.OptionsPrint.PrintGroupFooter = True
        PrintWithOption("Preview")
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub CheckEditCheckActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditCheckActive.CheckedChanged

    End Sub

    Private Sub CheckShowDawamTab_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowDawamTab.CheckedChanged
        Select Case CheckShowDawamTab.CheckState
            Case CheckState.Checked
                gridBand2.Visible = True
                gridBand8.Visible = True

            Case CheckState.Unchecked
                gridBand2.Visible = False
                gridBand8.Visible = False

        End Select
    End Sub

    Private Function GetAttTrans(_Date As String, _Employee As String, _Type As String) As String
        Dim _AttTrans As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" Select CHECKTIME
                                  from [AttCHECKINOUT]
                                  where USERID='" & _Employee & "'
                                        and CHECKTYPE='" & _Type & "' and CHECKTIME between '" & _Date & " 00:00:00' and '" & _Date & " 23:59:59' ")
            _AttTrans = sql.SQLDS.Tables(0).Rows(0).Item("CHECKTIME")
        Catch ex As Exception
            _AttTrans = _Date
        End Try

        Return _AttTrans
    End Function

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
                RadioGroup2.EditValue = "1"
                LookUpEdit10.EditValue = 1
            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If
                RadioGroup2.EditValue = "1"
                LookUpEdit10.EditValue = 1
            Case "today"
                Me.DateEdit1.DateTime = Today
                Me.DateEdit2.DateTime = Today
                RadioGroup2.EditValue = "2"
                LookUpEdit10.EditValue = 2
            Case "yesterday"
                Me.DateEdit1.DateTime = Today.AddDays(-1)
                Me.DateEdit2.DateTime = Today.AddDays(-1)
                RadioGroup2.EditValue = "2"
                LookUpEdit10.EditValue = 2
        End Select
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)






    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim j As Integer = 0
        Dim i As Integer
        Dim f As New VocationAddQuick
        With f
            If .ShowDialog <> DialogResult.OK And GlobalVariables._VocationTypeInQuickMode <> 0 Then
                Dim selectedRowHandles As Integer() = BandedGridView1.GetSelectedRows()
                For i = 0 To selectedRowHandles.Length - 1
                    Dim value As Object = BandedGridView1.GetRowCellValue(selectedRowHandles(i), "TransDate")
                    Try
                        Dim sql As New SQLControl
                        Dim VocDate As String = Format(CDate(BandedGridView1.GetRowCellValue(selectedRowHandles(i), "TransDate")), "yyyy-MM-dd")
                        Dim EmpID As String = BandedGridView1.GetRowCellValue(selectedRowHandles(i), "EmpID")
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

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim f As New AttBonus

        With f
            .TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim f As New AttAdvancePayment
        With f
            .TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
            .TextFormType.Text = "New"
            .SearchEmployee.EditValue = SearchLookUpEdit1.EditValue
            .DateEdit1.EditValue = DateEdit2.DateTime
            .ShowDialog()
        End With
    End Sub
    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView1.DoubleClick
        If GlobalVariables._AttDailyAdjustment = False Then Exit Sub
        With BandedGridView1
            Dim _BonusHours As TimeSpan, _EmpNo As Integer, _EmpName As String, _TransDate As Date
            'MsgBox(.FocusedColumn.FieldName)
            Select Case .FocusedColumn.FieldName
                Case "BonusSpanBeforeBeg"
                    If IsDBNull(.GetFocusedRowCellValue("BonusSpanBeforeBeg")) Then
                        _BonusHours = TimeSpan.Zero
                    Else
                        _BonusHours = .GetFocusedRowCellValue("BonusSpanBeforeBeg")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة اضافي قبل الدوام "
                    f.CurrentPeriod.EditValue = _BonusHours
                    f.TextAdjustType.Text = "3"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("ElapseTime")
                    f.ShowDialog()
                Case "BonusSpanAfterEnd"
                    If IsDBNull(.GetFocusedRowCellValue("BonusSpanAfterEnd")) Then
                        _BonusHours = TimeSpan.Zero
                    Else
                        _BonusHours = .GetFocusedRowCellValue("BonusSpanAfterEnd")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة اضافي بعد الدوام "
                    f.CurrentPeriod.EditValue = _BonusHours
                    f.TextAdjustType.Text = "4"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("ElapseTime")
                    f.ShowDialog()
                Case "LateSpan"
                    If IsDBNull(.GetFocusedRowCellValue("LateSpan")) Then
                        _BonusHours = TimeSpan.Zero
                    Else
                        _BonusHours = .GetFocusedRowCellValue("LateSpan")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة تاخير صباحي  "
                    f.CurrentPeriod.EditValue = _BonusHours
                    f.TextAdjustType.Text = "5"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("ElapseTime")
                    f.ShowDialog()
                Case "LeaveSpan"
                    If IsDBNull(.GetFocusedRowCellValue("LeaveSpan")) Then
                        _BonusHours = TimeSpan.Zero
                    Else
                        _BonusHours = .GetFocusedRowCellValue("LeaveSpan")
                    End If
                    _EmpNo = .GetFocusedRowCellValue("EmpID")
                    _EmpName = .GetFocusedRowCellValue("EmployeeName")
                    _TransDate = .GetFocusedRowCellValue("TransDate")
                    Dim f As New AttAdjustmentTrans
                    f.LabelAddress.Text = " معالجة خروج مبكر  "
                    f.CurrentPeriod.EditValue = _BonusHours
                    f.TextAdjustType.Text = "6"
                    f.TextEmpNo.Text = _EmpNo
                    f.DateTransDate.DateTime = _TransDate
                    f.TextEmployeeName.Text = _EmpName
                    f.TimeSpanRequriedHoursInDay.EditValue = .GetFocusedRowCellValue("ElapseTime")
                    f.ShowDialog()
                Case "StartTimeReal"
                    If IsDBNull(.GetFocusedRowCellValue("StartTimeReal")) Then
                        Dim f As New AttQuickAddTrans(.GetFocusedRowCellValue("EmpID"), "I", "Insert")
                        f.LabelControlDetails.Text = " اضافة حركة دخول للموظف  " & .GetFocusedRowCellValue("EmployeeName")
                        f.TransDate.DateTime = .GetFocusedRowCellValue("TransDate")
                        If f.ShowDialog() <> DialogResult.OK Then
                            .SetFocusedRowCellValue("StartTimeReal", f._PublicTransTime)
                        End If
                    End If
                Case "EndTimeReal"
                    If IsDBNull(.GetFocusedRowCellValue("EndTimeReal")) Then
                        Dim f As New AttQuickAddTrans(.GetFocusedRowCellValue("EmpID"), "O", "Insert")
                        f.LabelControlDetails.Text = " اضافة حركة خروج للموظف  " & .GetFocusedRowCellValue("EmployeeName")
                        f.TransDate.DateTime = .GetFocusedRowCellValue("TransDate")
                        If f.ShowDialog() <> DialogResult.OK Then
                            .SetFocusedRowCellValue("EndTimeReal", f._PublicTransTime)
                        End If
                    End If
                Case "OverTimeRequestID"
                    If IsDBNull(.GetFocusedRowCellValue("OverTimeRequestID")) Then
                        Return
                    End If
                    Dim F As New AttEmployeeOvertimeRequest
                    With F
                        .ShowDialog()
                    End With
                Case Else
                    Exit Sub
            End Select
        End With

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarPublishSalary.ItemClick
        SaveSalary()
    End Sub

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim _EmpID As String
        If Not String.IsNullOrEmpty(SearchLookUpEdit1.Text) Then
            _EmpID = SearchLookUpEdit1.EditValue
        Else
            _EmpID = CStr(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EmpID"))
        End If
        If String.IsNullOrEmpty(_EmpID) Then Exit Sub
        My.Forms.EmployeesEdit.EmployeeIDTextEdit.Text = _EmpID
        My.Forms.EmployeesEdit.EmployeeNameTextEdit.Select()
        EmployeesEdit.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        BandedGridView1.OptionsSelection.MultiSelect = True
        BandedGridView1.SelectAll()
        BandedGridView1.CopyToClipboard()
        BandedGridView1.OptionsSelection.MultiSelect = False
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        _PrintAtt = True
        PrintWithOption("Print")
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        _PrintAtt = False
        PrintWithOption("Preview")
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        AttPrintSettings.ShowDialog()
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If SearchLookUpEdit1.Text = "" Then
            MsgBoxShowError("يجب اختيار الموظف ")
            Exit Sub
        End If
        Dim _MobileNo As String
        _MobileNo = GetEmployeeData(SearchLookUpEdit1.EditValue).Mobile
        PrintWithOption("Pdf")
        SendFileToWhatsApp(_MobileNo, "تقرير الدوام.Pdf", "تقرير الدوام", "", GetEmployeeData(SearchLookUpEdit1.EditValue).EmployeeName)
    End Sub

    'Private Sub PrintWithOption(_PrintOption)
    '    If GridControl1.IsPrintingAvailable = False Then Exit Sub
    '    If GlobalVariables._SystemLanguage = "Arabic" Then
    '        If BandedGridView1.RowCount = 0 Then Exit Sub
    '    Else
    '        If BandedGridView1.RowCount = 0 Then Exit Sub
    '    End If
    '    BandedGridView1.OptionsPrint.ExpandAllGroups = False
    '    If _PrintAtt = True Then
    '        _PrintOption = "Print"
    '    End If
    '    Select Case _PrintOption
    '        Case "Print"
    '            GridControl1.Print()
    '        Case "Preview"
    '            GridControl1.ShowPrintPreview()
    '        Case "Pdf"
    '            GridControl1.ExportToPdf("تقرير الدوام.pdf")
    '    End Select
    '    ColAddAndEdit.Visible = True
    'End Sub

    Private Sub PrintWithOption(_PrintOption As String)
        If Not GridControl1.IsPrintingAvailable Then Return
        If BandedGridView1.RowCount = 0 Then Return

        '=== Fit to one page WIDTH ===
        With BandedGridView1.OptionsPrint
            .AutoWidth = True            'Scale all columns to the page width
            .ExpandAllGroups = False
            .PrintBandHeader = True
            .PrintHeader = True
            ' .UsePrintStyles = True     'optional: gray-scale print style
        End With

        If _PrintAtt = True Then
            _PrintOption = "Print"
        End If

        Select Case _PrintOption
            Case "Print"
                ' GridControl1.Print()
                PrintGridScaled90("Print")
            Case "Preview"
                ' GridControl1.ShowPrintPreview()
                PrintGridScaled90("Preview")
            Case "Pdf"
                PrintGridScaled90("Pdf")
                'GridControl1.ExportToPdf("تقرير الدوام.pdf")
        End Select

        ColAddAndEdit.Visible = True
    End Sub

    Private Sub PrintGridScaled90(_Option As String)

        ' 1) Create printing objects
        Dim ps As New PrintingSystem()
        Dim link As New PrintableComponentLink(ps)

        ' 2) Assign your grid
        link.Component = GridControl1

        ' 3) Set page settings BEFORE CreateDocument
        link.Landscape = True
        link.PaperKind = PaperKind.A4
        link.Margins.Left = 10
        link.Margins.Right = 10
        link.Margins.Top = 70
        link.Margins.Bottom = 40
        link.RightToLeftLayout = True
        ' 4) Create document FIRST
        link.CreateDocument()

        ' 5) ⭐ Now apply 90% scale (this is the ONLY legal place)

        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = " select SettingValue From Settings where SettingName ='AttScaleAttendantReport'"
            sql.SqlTrueTimeRunQuery(sqlString)
            PrintScale = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            PrintScale = 100D
            XtraMessageBox.Show(ex.ToString)
        End Try

        ps.Document.ScaleFactor = PrintScale / 100       ' ← 90%

        ' 6) Show preview
        Select Case _Option
            Case "Print"
                link.Print()
            Case "Preview"
                link.ShowPreview()
            Case "Pdf"
                GridControl1.ExportToPdf("تقرير الدوام.pdf")
        End Select


    End Sub



    Private Sub BarButtonItemShowEditNote_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShowEditNote.ItemClick
        Select Case ColEditNote.Visible
            Case True
                ColEditNote.Visible = False
                Exit Sub
            Case False
                ColEditNote.Visible = True
                Exit Sub
        End Select
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        ' create _LateTable



        Try
            Dim _LateTable As New DataTable
            With _LateTable
                .Columns.Add("TransDate", GetType(DateTime))
                .Columns.Add("TransDay", GetType(String))
                .Columns.Add("EmpID", GetType(String))
                .Columns.Add("EmployeeName", GetType(String))
                .Columns.Add("StartTimeReal", GetType(DateTime))
                .Columns.Add("StartTime", GetType(DateTime))
                .Columns.Add("LateSpan", GetType(TimeSpan))
            End With

            Dim _TotalLatesTable As New DataTable
            With _TotalLatesTable
                .Columns.Add("EmpID", GetType(String))
                .Columns.Add("EmployeeName", GetType(String))
                .Columns.Add("TotalLates", GetType(Integer))     ' Count of late instances
                .Columns.Add("TotalLateTime", GetType(String)) ' Sum of all late times
                .Columns.Add("AvgLateTime", GetType(String))   ' Average late time
            End With

            Dim _AbsentTable As New DataTable
            With _AbsentTable
                .Columns.Add("TransDate", GetType(DateTime))
                .Columns.Add("TransDay", GetType(String))
                .Columns.Add("EmpID", GetType(String))
                .Columns.Add("EmployeeName", GetType(String))
            End With

            Dim _VacationTable As New DataTable
            With _VacationTable
                .Columns.Add("TransDate", GetType(DateTime))
                .Columns.Add("TransDay", GetType(String))
                .Columns.Add("EmpID", GetType(String))
                .Columns.Add("EmployeeName", GetType(String))
                .Columns.Add("AttStatus", GetType(String))
            End With

            Dim _OffTable As New DataTable
            With _OffTable
                .Columns.Add("TransDate", GetType(DateTime))
                .Columns.Add("TransDay", GetType(String))
                .Columns.Add("EmpID", GetType(String))
                .Columns.Add("EmployeeName", GetType(String))
            End With

            'Dim i As Integer
            'For i = 1 To BandedGridView1.RowCount - 2
            '    Dim Row As DataRow
            '    Row = _LateTable.NewRow()
            '    Row.Item("TransDate") = BandedGridView1.GetRowCellValue(i, "TransDate")
            '    Row.Item("TransDay") = BandedGridView1.GetRowCellValue(i, "TransDay")
            '    Row.Item("EmpID") = BandedGridView1.GetRowCellValue(i, "EmpID")
            '    _LateTable.Rows.Add(Row)
            'Next i

            With _LateTable
                For i = 0 To attDataTable.Rows.Count - 1
                    Dim _Status As String = attDataTable.Rows(i).Item("AttStatus")
                    Select Case _Status
                        Case "غياب"
                            Dim Row As DataRow
                            Row = _AbsentTable.NewRow()
                            Row.Item("TransDate") = attDataTable.Rows(i).Item("TransDate")
                            Row.Item("TransDay") = attDataTable.Rows(i).Item("TransDay")
                            Row.Item("EmpID") = attDataTable.Rows(i).Item("EmpID")
                            Row.Item("EmployeeName") = attDataTable.Rows(i).Item("EmployeeName")
                            _AbsentTable.Rows.Add(Row)
                        Case "اجازة"
                            Dim Row As DataRow
                            Row = _VacationTable.NewRow()
                            Row.Item("TransDate") = attDataTable.Rows(i).Item("TransDate")
                            Row.Item("TransDay") = attDataTable.Rows(i).Item("TransDay")
                            Row.Item("EmpID") = attDataTable.Rows(i).Item("EmpID")
                            Row.Item("EmployeeName") = attDataTable.Rows(i).Item("EmployeeName")
                            _VacationTable.Rows.Add(Row)
                        Case "عطلة"
                            Dim Row As DataRow
                            Row = _OffTable.NewRow()
                            Row.Item("TransDate") = attDataTable.Rows(i).Item("TransDate")
                            Row.Item("TransDay") = attDataTable.Rows(i).Item("TransDay")
                            Row.Item("EmpID") = attDataTable.Rows(i).Item("EmpID")
                            Row.Item("EmployeeName") = attDataTable.Rows(i).Item("EmployeeName")
                            _OffTable.Rows.Add(Row)
                        Case "خطا بصمة", "دوام"
                            Dim _Late As TimeSpan
                            If Not IsDBNull(attDataTable.Rows(i).Item("LateSpan")) Then
                                _Late = attDataTable.Rows(i).Item("LateSpan")
                                If _Late <> TimeSpan.Zero Then
                                    Dim Row As DataRow
                                    Row = .NewRow()
                                    Row.Item("TransDate") = attDataTable.Rows(i).Item("TransDate")
                                    Row.Item("TransDay") = attDataTable.Rows(i).Item("TransDay")
                                    Row.Item("EmpID") = attDataTable.Rows(i).Item("EmpID")
                                    Row.Item("EmployeeName") = attDataTable.Rows(i).Item("EmployeeName")
                                    If Not IsDBNull(attDataTable.Rows(i).Item("StartTimeReal")) Then
                                        Row.Item("StartTimeReal") = attDataTable.Rows(i).Item("StartTimeReal")
                                    Else
                                        Row.Item("StartTimeReal") = TimeSpan.Zero
                                        attDataTable.Rows(i).Item("EmployeeName") += attDataTable.Rows(i).Item("EmployeeName") & "/ لا يوجد ختم "
                                    End If

                                    Row.Item("StartTime") = attDataTable.Rows(i).Item("StartTime")
                                    Row.Item("LateSpan") = attDataTable.Rows(i).Item("LateSpan")
                                    .Rows.Add(Row)
                                End If
                            End If
                    End Select

                    If Not IsDBNull(attDataTable.Rows(i).Item("VocationDays")) Then
                        If attDataTable.Rows(i).Item("VocationDays") = "1" Then
                            Dim Row As DataRow
                            Row = _VacationTable.NewRow()
                            Row.Item("TransDate") = attDataTable.Rows(i).Item("TransDate")
                            Row.Item("TransDay") = attDataTable.Rows(i).Item("TransDay")
                            Row.Item("EmpID") = attDataTable.Rows(i).Item("EmpID")
                            Row.Item("EmployeeName") = attDataTable.Rows(i).Item("EmployeeName")
                            Row.Item("AttStatus") = attDataTable.Rows(i).Item("AttStatus")
                            _VacationTable.Rows.Add(Row)
                        End If 'VocationDays
                    End If

                Next i
            End With


            If _LateTable IsNot Nothing AndAlso _LateTable.Rows.Count > 0 Then
                ' Group by employee ID and calculate totals
                Dim empGroups = _LateTable.AsEnumerable() _
                    .GroupBy(Function(row) New With {
                        Key .EmpID = row.Field(Of String)("EmpID"),
                        Key .EmployeeName = row.Field(Of String)("EmployeeName")
                    })

                For Each group In empGroups
                    Dim newRow As DataRow = _TotalLatesTable.NewRow()
                    Dim lateCount As Integer = group.Count()
                    Dim totalLateSpan As TimeSpan = TimeSpan.Zero

                    ' Sum up all late spans for this employee
                    For Each row In group
                        Dim lateSpan As TimeSpan = row.Field(Of TimeSpan)("LateSpan")
                        totalLateSpan = totalLateSpan.Add(lateSpan)
                    Next

                    ' Calculate average late time
                    Dim avgLateSpan As TimeSpan = If(lateCount > 0,
                                        TimeSpan.FromTicks(totalLateSpan.Ticks \ lateCount),
                                        TimeSpan.Zero)

                    ' Populate the row
                    newRow("EmpID") = group.Key.EmpID
                    newRow("EmployeeName") = group.Key.EmployeeName
                    newRow("TotalLates") = lateCount
                    newRow("TotalLateTime") = _TimeSpanFunction.ConvertTimeSpan_hhmmm_ToString(totalLateSpan)
                    newRow("AvgLateTime") = _TimeSpanFunction.ConvertTimeSpan_hhmmm_ToString(avgLateSpan)

                    _TotalLatesTable.Rows.Add(newRow)
                Next
            End If

            Dim F As New AttMorningLates
            F.GridControlLates.DataSource = _LateTable
            F.GridControlAbsent.DataSource = _AbsentTable
            F.GridControlVacation.DataSource = _VacationTable
            F.GridControlOff.DataSource = _OffTable
            F.GridControlTotalLates.DataSource = _TotalLatesTable
            F.DateEdit1.DateTime = DateEdit1.DateTime
            F.DateEdit2.DateTime = DateEdit2.DateTime
            F.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub BarAdjustMorningLateToZeroIfRequestFound_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarAdjustMorningLateToZeroIfRequestFound.CheckedChanged
        If BarAdjustMorningLateToZeroIfRequestFound.Checked Then
            _AdjustMorningLateToZeroIfRequestFound = True
        Else
            _AdjustMorningLateToZeroIfRequestFound = False
        End If
    End Sub
End Class