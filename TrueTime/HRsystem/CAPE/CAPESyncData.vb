Imports System.ComponentModel
Imports MySqlConnector

Public Class CAPESyncData
    Dim _EmployeesCount As Integer = 0
    Public Sub New()
        InitializeComponent()
        BackgroundWorker1.WorkerReportsProgress = True
        'BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub
    Dim _LocalEmployeesTable As New DataTable
    Dim _LocalMonthlyAttTable As New DataTable
    Dim _LocalVocations As New DataTable
    Dim _JournalTable As New DataTable
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        BarString.Caption = "جاري مازمنة البيانات"
        ClearData()
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.BarStaticItemSync.Caption = "Sync..."
        'Me.BarStaticItemSync.Caption = (e.ProgressPercentage.ToString() & "%")
        Me.BarEditItemSync.EditValue = (e.ProgressPercentage)
        Select Case e.ProgressPercentage
            Case 0
                LabelControl2.Text = "خطا رجى فحص اعدادات الاتصال"
            Case 10
                LabelControl1.Text = "جاري فحص الاتصال"
            Case 20
                LabelControl2.Text = "تم الاتصال بنظام الرقابة"
            Case 30
                LabelControl3.Text = "جاري تحميل بيانات الموظفين"
            Case 40
                LabelControl4.Text = " جاري تحميل بيانات النظام المالي "
            Case 50
                LabelControl5.Text = "جاري تهيئة بيانات الموظفين في نظام الرقابة"
            Case 60
                LabelControl6.Text = "تم تهيئة بيانات الموظفين في نظام الرقابة"
            Case 70
                LabelControl7.Text = "جاري اعادة رفع بيانات الموظفين"
            Case 60
                LabelControl6.Text = "تم تهيئة جدول الاجازات"
            Case 70
                LabelControl7.Text = "جاري اعادة رفع بيانات الموظفين"
            Case 80
                LabelControl8.Text = " تم اعادة رفع البيانات من النظام الاداري "
            Case 90
                LabelControl9.Text = " جاري رفع بيانات النام المالي "
            Case 100
                LabelControl10.Text = " تم اعادة رفع البيانات من النظام المالي "
        End Select

    End Sub

    Private Sub ClearData()
        LabelControl1.Text = " "
        LabelControl2.Text = " "
        LabelControl3.Text = " "
        LabelControl4.Text = " "
        LabelControl5.Text = " "
        LabelControl6.Text = " "
        LabelControl7.Text = " "
        LabelControl8.Text = " "
        LabelControl9.Text = " "
        LabelControl10.Text = "   "
    End Sub
    Private Sub progressBarControl1_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles BarEditItemSync.CustomDisplayText
        e.DisplayText = "test"
    End Sub
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            Me.LabelControl10.Text = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            Me.LabelControl10.Text = "Error: " & e.[Error].Message
        Else
            Me.LabelControl10.Text = "Done!" & " " & Format(Now, "HH:mm")
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)
        worker.ReportProgress(10)
        System.Threading.Thread.Sleep(500)
        Select Case TestConnection()
            Case True
                worker.ReportProgress(20)
                System.Threading.Thread.Sleep(500)
                worker.ReportProgress(30)
                _LocalEmployeesTable = GetLocalEmployees()
                _LocalMonthlyAttTable = GetLocalMonthlyAttTable()
                _LocalVocations = GetVocationsTable()
                worker.ReportProgress(40)
                _JournalTable = GetJournalTable()
                System.Threading.Thread.Sleep(500)
                If _LocalEmployeesTable.Rows.Count > 0 Then
                    worker.ReportProgress(50)
                    If EmptyTablesInCAPEtable() = True Then
                        worker.ReportProgress(60)
                        System.Threading.Thread.Sleep(500)
                        worker.ReportProgress(70)
                        InsertUpdateEmployeesToCAPEtable()
                        worker.ReportProgress(80)
                        InsertUpdateMonthlyAttDataToCAPEtable()
                        worker.ReportProgress(90)
                        InsertUpdateVocationsToCAPEtable()
                    End If
                End If
                If _JournalTable.Rows.Count > 0 Then
                    worker.ReportProgress(95)
                    InsertUpdateJournalToCAPEtable()
                End If
                worker.ReportProgress(100)
                BarString.Caption = "Finished"
                System.Threading.Thread.Sleep(500)
            Case False
                worker.ReportProgress(0)
                Exit Sub
        End Select
    End Sub

    Private Function TestConnection() As Boolean
        Try
            Dim DeviceKey As String = GlobalVariables.LocalDeviceKey
            Dim CustData As New DataTable
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Return True
            MySqlConnection.Close()
        Catch ex As Exception
            Me.LabelControl10.Text = ex.ToString
            Return False
        End Try
    End Function

    Private Sub CAPESyncData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BarString.Caption = "Ready"
        'BarString.Caption = CAPEMySqlString()
    End Sub
    Private Function EmptyTablesInCAPEtable() As Boolean
        Try
            Dim DeleteQuery As String
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Dim Command As New MySqlCommand
            Dim MyAdapter As New MySqlDataAdapter
            Command.Connection = MySqlConnection
            DeleteQuery = " Delete from `بيانات الموظفين`;
                            ALTER TABLE `بيانات الموظفين` AUTO_INCREMENT = 1;
                            Delete from `جدول الدوام والاجازات`;
                            ALTER TABLE `جدول الدوام والاجازات` AUTO_INCREMENT = 1;
                            Delete from `جدول الاجازات`;
                            ALTER TABLE `جدول الاجازات` AUTO_INCREMENT = 1;
                            Delete from `api tts acc`;
                            ALTER TABLE `api tts acc` AUTO_INCREMENT = 1"
            Command.CommandText = DeleteQuery
            Command.ExecuteNonQuery()
            MySqlConnection.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function InsertUpdateEmployeesToCAPEtable() As Boolean
        Try
            Dim _EmployeeID As Integer
            Dim _EmployeeName, InsertQuery As String
            Dim _Notes As String = ""
            Dim _Address As String = ""
            Dim _Mobile1 As String = ""
            Dim _EmployeeType As String = ""
            Dim _Branch As String = ""
            Dim _Department As String = ""
            Dim _JobName As String = ""
            Dim _Salary As String = "0"
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Dim Command As New MySqlCommand
            Dim MyAdapter As New MySqlDataAdapter
            Command.Connection = MySqlConnection
            For i = 0 To _LocalEmployeesTable.Rows.Count - 1
                _EmployeeID = _LocalEmployeesTable.Rows(i).Item("EmployeeID")
                _EmployeeName = _LocalEmployeesTable.Rows(i).Item("EmployeeName")
                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Notes")) Then
                    _Notes = _LocalEmployeesTable.Rows(i).Item("Notes")
                Else
                    _Notes = ""
                End If
                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Address")) Then
                    _Address = _LocalEmployeesTable.Rows(i).Item("Address")
                Else
                    _Address = ""
                End If
                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Mobile1")) Then
                    _Mobile1 = _LocalEmployeesTable.Rows(i).Item("Mobile1")
                Else
                    _Mobile1 = ""
                End If
                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("EmployeeType")) Then
                    _EmployeeType = _LocalEmployeesTable.Rows(i).Item("EmployeeType")
                Else
                    _EmployeeType = ""
                End If

                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Department")) Then
                    _Department = _LocalEmployeesTable.Rows(i).Item("Department")
                Else
                    _Department = ""
                End If

               If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Branch")) Then
                    _Branch = _LocalEmployeesTable.Rows(i).Item("Branch")
                Else
                    _Branch = ""
                End If

                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("JobName")) Then
                    _JobName = _LocalEmployeesTable.Rows(i).Item("JobName")
                Else
                    _JobName = ""
                End If

                If Not IsDBNull(_LocalEmployeesTable.Rows(i).Item("Salary")) Then
                    _Salary = _LocalEmployeesTable.Rows(i).Item("Salary")
                Else
                    _Salary = "0"
                End If




                InsertQuery = " Insert into `بيانات الموظفين` 
                               (
                                `الرقم التسلسلي`,
                                `hdate`,
                                `huserid`,
                                `heditorid`,
                                 hstatus,
                                 `ملاحظات`,
                                 `اسم الموظف`,
                                 `رقم الموظف`,
                                 `الفرع`,
                                 `الوظيفة`,
                                 `الراتب`
                                ) 
                                VALUES
                                (
                                '" & i + 1 & "',
                                '" & Format(Today(), "yyyy-MM-dd") & "',
                                '" & GlobalVariables.CurrUser & "',
                                '" & GlobalVariables.CurrUser & "',
                                'S',
                                '" & _Notes & "',
                                '" & _EmployeeName & "',
                                '" & _EmployeeID & "',
                                '" & _Branch & "',
                                '" & _JobName & "',
                                '" & _Salary & "'
                                ) "
                _EmployeesCount = i
                Command.CommandText = InsertQuery
                Command.ExecuteNonQuery()
            Next
            MySqlConnection.Close()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Function InsertUpdateMonthlyAttDataToCAPEtable() As Boolean
        Try
            Dim _EmployeeID As Integer
            Dim _EmployeeName, InsertQuery As String
            Dim _DateFrom, _DateTo As String
            Dim _MonthDays, _ActualDays, _VocationDays, _WeekOffDays, _AbsenceDays As Decimal
            Dim _HouresRequired, _ActualHoures, _HouresNetBonus, _HouresNetLeaves As Double
            Dim _HouresNetBonusCount, _HouresNetLeavesCount As Decimal
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Dim Command As New MySqlCommand
            Dim MyAdapter As New MySqlDataAdapter
            Command.Connection = MySqlConnection
            For i = 0 To _LocalMonthlyAttTable.Rows.Count - 1
                _EmployeeID = _LocalMonthlyAttTable.Rows(i).Item("EmployeeID")
                _EmployeeName = _LocalMonthlyAttTable.Rows(i).Item("EmployeeName")
                _DateFrom = Format(CDate(_LocalMonthlyAttTable.Rows(i).Item("DateFrom")), "yyyy-MM-dd")
                _DateTo = Format(CDate(_LocalMonthlyAttTable.Rows(i).Item("DateTo")), "yyyy-MM-dd")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("MonthDays")) Then _MonthDays = _LocalMonthlyAttTable.Rows(i).Item("MonthDays")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("ActualDays")) Then _ActualDays = _LocalMonthlyAttTable.Rows(i).Item("ActualDays")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("VocationDays")) Then _VocationDays = _LocalMonthlyAttTable.Rows(i).Item("VocationDays")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("WeekOffDays")) Then _WeekOffDays = _LocalMonthlyAttTable.Rows(i).Item("WeekOffDays")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("AbsenceDays")) Then _AbsenceDays = _LocalMonthlyAttTable.Rows(i).Item("AbsenceDays")
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("HouresRequired")) Then _HouresRequired = Hours(_LocalMonthlyAttTable.Rows(i).Item("HouresRequired"))
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("ActualHoures")) Then _ActualHoures = Hours(_LocalMonthlyAttTable.Rows(i).Item("ActualHoures"))
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("HouresNetBonus")) Then _HouresNetBonus = Hours(_LocalMonthlyAttTable.Rows(i).Item("HouresNetBonus"))
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("HouresNetLeaves")) Then _HouresNetLeaves = Hours(_LocalMonthlyAttTable.Rows(i).Item("HouresNetLeaves"))
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("HouresNetBonusCount")) Then _HouresNetBonusCount = Hours(_LocalMonthlyAttTable.Rows(i).Item("HouresNetBonusCount"))
                If Not IsDBNull(_LocalMonthlyAttTable.Rows(i).Item("HouresNetLeavesCount")) Then _HouresNetLeavesCount = Hours(_LocalMonthlyAttTable.Rows(i).Item("HouresNetLeavesCount"))
                InsertQuery = " Insert into `جدول الدوام والاجازات` 
                               (
                                `الرقم التسلسلي`,
                                `hdate`,
                                `huserid`,
                                `heditorid`,
                                 hstatus,
                                  `عدد ايام الفترة`,
                                  `عدد ايام الدوام`,
                                  `عدد ايام الاجازات`,
                                  `العطل الاسبوعية`,
                                  `عدد ايام الغياب`,
                                  `ساعات مطلوبة`,
                                  `ساعات فعلية`,
                                  `ساعات الاضافي`,
                                  `ساعات مغادرة / تاخير`,
                                  `عدد مرات اخذ اضافي`,
                                  `عدد مرات اخذ مغادرة / تاخير`,
                                  `رقم الموظف`,
                                  `اسم الموظف`,
                                  `من تاريخ`,
                                  `الى تاريخ`
                                ) 
                                VALUES
                                (
                                '" & i + 1 & "',
                                '" & Format(Today(), "yyyy-MM-dd") & "',
                                '" & GlobalVariables.CurrUser & "',
                                '" & GlobalVariables.CurrUser & "',
                                'S',
                                '" & _MonthDays & "',
                                '" & _ActualDays & "',
                                '" & _VocationDays & "',
                                '" & _WeekOffDays & "',
                                '" & _AbsenceDays & "',
                                '" & _HouresRequired & "',
                                '" & _ActualHoures & "',
                                '" & _HouresNetBonus & "',
                                '" & _HouresNetLeaves & "',
                                '" & _HouresNetBonusCount & "',
                                '" & _HouresNetLeavesCount & "',
                                '" & _EmployeeID & "',
                                '" & _EmployeeName & "',
                                '" & _DateFrom & "',
                                '" & _DateTo & "'
                                ) "
                _EmployeesCount = i
                Command.CommandText = InsertQuery
                Command.ExecuteNonQuery()
            Next
            MySqlConnection.Close()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Function InsertUpdateVocationsToCAPEtable() As Boolean
        Try
            Dim _EmployeeID As Integer
            Dim _EmployeeName, InsertQuery As String
            Dim _Notes As String = ""
            Dim _Department As String = ""
            Dim _Mobile1 As String = ""
            Dim _EmployeeType As Integer = 0
            Dim _FromDate, _ToDate, _VocDate, _Vocation As String
            Dim _NoDays As Decimal
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Dim Command As New MySqlCommand
            Dim MyAdapter As New MySqlDataAdapter
            Command.Connection = MySqlConnection
            For i = 0 To _LocalVocations.Rows.Count - 1
                _EmployeeID = _LocalVocations.Rows(i).Item("EmployeeID")
                _EmployeeName = _LocalVocations.Rows(i).Item("EmployeeName")
                If Not IsDBNull(_LocalVocations.Rows(i).Item("NoteDetails")) Then _Notes = _LocalVocations.Rows(i).Item("NoteDetails")
                If Not IsDBNull(_LocalVocations.Rows(i).Item("FromDate")) Then _FromDate = Format(CDate(_LocalVocations.Rows(i).Item("FromDate")), "yyyy-MM-dd") Else _FromDate = "1900-01-01"
                If Not IsDBNull(_LocalVocations.Rows(i).Item("ToDate")) Then _ToDate = Format(CDate(_LocalVocations.Rows(i).Item("ToDate")), "yyyy-MM-dd") Else _ToDate = "1900-01-01"
                If Not IsDBNull(_LocalVocations.Rows(i).Item("VocDate")) Then _VocDate = Format(CDate(_LocalVocations.Rows(i).Item("VocDate")), "yyyy-MM-dd") Else _VocDate = "1900-01-01"
                If Not IsDBNull(_LocalVocations.Rows(i).Item("NoDays")) Then _NoDays = _LocalVocations.Rows(i).Item("NoDays") Else _NoDays = 0
                If Not IsDBNull(_LocalVocations.Rows(i).Item("Vocation")) Then _Vocation = _LocalVocations.Rows(i).Item("Vocation") Else _Vocation = ""
                If Not IsDBNull(_LocalVocations.Rows(i).Item("Department")) Then _Department = _LocalVocations.Rows(i).Item("Department")

                InsertQuery = " Insert into `جدول الاجازات` 
                               (
                                `الرقم التسلسلي`,
                                `hdate`,
                                `huserid`,
                                `heditorid`,
                                 hstatus,
                                 `رقم الموظف`,
                                 `اسم الموظف`,
                                 `الدائرة`,
                                 `تاريخ طلب الاجازة`,
                                 `من تاريخ`,
                                 `الى تاريخ`,
                                 `عدد الايام`,
                                 `نوع الاجازة`,
                                 `ملاحظات`
                                ) 
                                VALUES
                                (
                                '" & i + 1 & "',
                                '" & Format(Today(), "yyyy-MM-dd") & "',
                                '" & GlobalVariables.CurrUser & "',
                                '" & GlobalVariables.CurrUser & "',
                                'S',
                                '" & _EmployeeID & "',
                                '" & _EmployeeName & "',
                                '" & _Department & "',
                                '" & _VocDate & "',
                                '" & _FromDate & "',
                                '" & _ToDate & "',
                                '" & _NoDays & "',
                                '" & _Vocation & "',
                                '" & _Notes & "'
                                ) "
                _EmployeesCount = i
                Command.CommandText = InsertQuery
                Command.ExecuteNonQuery()
            Next
            MySqlConnection.Close()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        End Try
    End Function
    Private Function InsertUpdateJournalToCAPEtable() As Boolean
        Try
            Dim InsertQuery As String
            Dim MySqlConnection = New MySqlConnection
            MySqlConnection.ConnectionString = CAPEMySqlString()
            MySqlConnection.Open()
            Dim Command As New MySqlCommand
            Dim MyAdapter As New MySqlDataAdapter
            Command.Connection = MySqlConnection
            For i = 0 To _JournalTable.Rows.Count - 1
                InsertQuery = " Insert into `api tts acc` 
                               (
                                `الرقم التسلسلي`,
                                `hdate`,
                                `huserid`,
                                `heditorid`,
                                 hstatus,
                                 `رقم السند`,
                                 `التاريخ`,
                                 `اسم السند`,
                                 `حالة السند`,
                                 `مركزالتكلفة`,
                                 `الحساب`,
                                 `العملة`,
                                 `المبلغ`,
                                 `سعر الصرف`,
                                 `المبلغ بالعملة الرئيسية`,
                                 `المبلغ حسب عملة الحساب`,
                                 `اسم الذمة`,
                                 `اسم المستخدم`,
                                 `تاريخ ووقت الادخال`,
                                 `الصنف`,
                                 `الوحدة`,
                                 `السعر`,
                                 `الخصم على الصنف`,
                                 `الخصم على الفاتورة`,
                                 `مندوب مبيعات`,
                                 `رقم الشيك`,
                                 `مبلغ الشيك`,
                                 `مبلغ الشيك حسب العملة الرئيسية`,
                                 `تاريخ الاستحقاق`,
                                 `حالة الشيك`,
                                 `شيك وارد صادر`,
                                 `اسم الجهاز مدخل بيانات`,
                                 `الضريبة على الصنف`,
                                 `الكمية`,
                                 `كمية الداخل`,
                                 `كمية الخارج`,
                                 `مستودع الداخل`,
                                 `مستودع الخارج`,
                                 `مجموعة الصنف`,
                                 `العلامة التجارية`,
                                 `تصنيف الصنف`,
                                 `سعر الشراء`,
                                 `رقم السند اليدوي`
                                ) 
                                VALUES
                                (
                                '" & i + 1 & "',
                                '" & Format(Today(), "yyyy-MM-dd") & "',
                                '" & GlobalVariables.CurrUser & "',
                                '" & GlobalVariables.CurrUser & "',
                                'S',
                                '" & _JournalTable.Rows(i).Item("DocID") & "',
                                '" & Format(_JournalTable.Rows(i).Item("DocDate"), "yyyy-MM-dd") & "',
                                '" & _JournalTable.Rows(i).Item("DocName") & "',
                                '" & _JournalTable.Rows(i).Item("DocStatus") & "',
                                '" & _JournalTable.Rows(i).Item("CostName") & "',
                                '" & _JournalTable.Rows(i).Item("Account") & "',
                                '" & _JournalTable.Rows(i).Item("DocCurrency") & "',
                                '" & _JournalTable.Rows(i).Item("DocAmount") & "',
                                '" & _JournalTable.Rows(i).Item("ExchangePrice") & "',
                                '" & _JournalTable.Rows(i).Item("BaseCurrAmount") & "',
                                '" & _JournalTable.Rows(i).Item("BaseAmount") & "',
                                '" & _JournalTable.Rows(i).Item("RefName") & "',
                                '" & _JournalTable.Rows(i).Item("InputUser") & "',
                                '" & Format(_JournalTable.Rows(i).Item("InputDateTime"), "yyyy-MM-dd HH:mm") & "',
                                '" & _JournalTable.Rows(i).Item("ItemName") & "',
                                '" & _JournalTable.Rows(i).Item("UnitName") & "',
                                '" & _JournalTable.Rows(i).Item("StockPrice") & "',
                                '" & _JournalTable.Rows(i).Item("StockDiscount") & "',
                                '" & _JournalTable.Rows(i).Item("VoucherDiscount") & "',
                                '" & _JournalTable.Rows(i).Item("SalesMan") & "',
                                '" & _JournalTable.Rows(i).Item("CheckNo") & "',
                                '" & _JournalTable.Rows(i).Item("CheckAmount") & "',
                                '" & _JournalTable.Rows(i).Item("CheckBaseAmount") & "',
                                '" & Format(_JournalTable.Rows(i).Item("CheckDueDate"), "yyyy-MM-dd") & "',
                                '" & _JournalTable.Rows(i).Item("CheckStatus") & "',
                                '" & _JournalTable.Rows(i).Item("CheckInOut") & "',
                                '" & _JournalTable.Rows(i).Item("DeviceName") & "',
                                '" & _JournalTable.Rows(i).Item("ItemVAT") & "',
                                '" & _JournalTable.Rows(i).Item("StockQuantity") & "',
                                '" & _JournalTable.Rows(i).Item("QIn") & "',
                                '" & _JournalTable.Rows(i).Item("QOut") & "',
                                '" & _JournalTable.Rows(i).Item("InWarehouse") & "',
                                '" & _JournalTable.Rows(i).Item("OutWahrehouse") & "',
                                '" & _JournalTable.Rows(i).Item("GroupName") & "',
                                '" & _JournalTable.Rows(i).Item("TradeMarkName") & "',
                                '" & _JournalTable.Rows(i).Item("CategoryName") & "',
                                '" & _JournalTable.Rows(i).Item("LastPurchasePrice") & "',
                                '" & _JournalTable.Rows(i).Item("DocManualNo") & "'
                                ) "
                _EmployeesCount = i
                Command.CommandText = InsertQuery
                Command.ExecuteNonQuery()
            Next
            MySqlConnection.Close()
            Return True
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function Hours(ByVal s As String) As Decimal
        Dim r As Decimal
        If Decimal.TryParse(s, r) Then Return r
        Dim parts = s.Split(":"c)
        Return CDec(CDec(New TimeSpan(Integer.Parse(parts(0)), Integer.Parse(parts(1)), 0).TotalHours)).ToString("n2")
    End Function
    Private Function GetLocalEmployees() As DataTable
        Dim _Employees As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select [EmployeeID],[EmployeeName],Notes,Address,Mobile1,T.EmployeesType As EmployeeType,Branch,Department,JobName ,Salary
                          From [dbo].[EmployeesData] E
                          Left Join EmployeesTypes T on E.EmployeeType=T.ID"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Employees
        End Try
    End Function
    Private Function GetLocalMonthlyAttTable() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT   [ID]
                                  ,[DocMonth]      ,[DocYear]
                                  ,[EmployeeID]      ,[EmployeeNoAsAcc]
                                  ,[EmployeeName]      ,[Branch]
                                  ,[Department]      ,[JobName]
                                  ,[BeginDate]      ,[Currency]
                                  ,[SalaryMonth]      ,[BonusAmount]
                                  ,[Transport]      ,[Additions]
                                  ,[LeavesAmount]      ,[Payment]
                                  ,[GrossSalary]      ,[MonthDays]
                                  ,[ActualDays]      ,[VocationDays]
                                  ,[WeekOffDays]      ,[AbsenceDays]
                                  ,[HouresRequired]      ,[ActualHoures]
                                  ,[VocationBegBalance]      ,[AccruedVocationDays]
                                  ,[VocationCurrentBalance]      ,[VocationAtEndYear]
                                  ,[VocationSick]      ,[NetSalary]
                                  ,[DateFrom]      ,[DateTo]
                                  ,[HouresNetBonus]      ,[HouresNetLeaves],0 As HouresNetBonusCount ,0 As HouresNetLeavesCount
                                  ,[Indenty]      ,[BankName]
                                  ,[BankNo]      ,[BankBranch]
                                  ,[IBAN]      ,[CustColomn]
                                  ,[ArchiveStatus]      ,[AbsenceAmount]
                                  ,[ProcessType]  
                          FROM [dbo].[AttRawatebArchive]"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
    End Function
    Private Function GetVocationsTable() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT V.VocID As ID,
                                   [VocDate]
                                  ,V.[EmployeeID]
	                              ,E.EmployeeName
                                  ,[FromDate]
                                  ,[ToDate]
                                  ,[NoDays]
                                  ,[NoteDetails]
	                              , T.Vocation 
	                              ,Department 
                              FROM [dbo].[Vocations] V
                              left join VocationsTypes T on V.VocationType=T.VocID  
                              left join EmployeesData E on V.EmployeeID=E.EmployeeID  
                              where T.Vocation  is not null"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
    End Function
    Private Function GetJournalTable() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT TOP (1000) [increID]
      ,[hdate]
      ,[huserid]
      ,[heditorid]
      ,[hstatus]
      ,[DocID]
      ,[DocDate]
      ,[DocName]
      ,[DocStatus]
      ,[CostName]
      ,[Account]
      ,[DocCurrency]
      ,[DocAmount]
      ,[ExchangePrice]
      ,[BaseCurrAmount]
      ,[BaseAmount]
      ,[RefName]
      ,[InputUser]
      ,[InputDateTime]
      ,[ItemName]
      ,[UnitName]
      ,[StockPrice]
      ,[StockDiscount]
      ,[VoucherDiscount]
      ,[SalesMan]
      ,[CheckNo]
      ,[CheckAmount]
      ,[CheckBaseAmount]
      ,[CheckDueDate]
      ,[checkstatus]
      ,[CheckInOut]
      ,[DeviceName]
      ,[ItemVAT]
      ,[StockQuantity]
      ,[QIn]
      ,[QOut]
      ,[InWarehouse]
      ,[OutWahrehouse]
      ,[GroupName]
      ,[CategoryName]
      ,[TradeMarkName]
      ,[LastPurchasePrice]
      ,[DocManualNo]
  FROM [dbo].[JournalForCape] "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Table
        End Try
    End Function
End Class