Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI

Public Class SalaryMonthForm
    Private _Print As Boolean
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

        _Print = False
        SaveSalary()



    End Sub
    Private Sub SaveSalary()
        Try
            Dim report As New SalaryReport()
            report = DocumentViewer1.DocumentSource
            '  Dim _Branch As String = CStr(report.Parameters("Branch").Value)
            If CStr(report.Parameters("EmployeeNo").Value) = String.Empty Then
                MsgBox("رقم الموظف فارغ، لا يمكن الحفظ")
                Exit Sub
            End If

            Dim _DateFrom As String = Format(CDate(report.Parameters("DateFrom").Value), "yyyy-MM-dd")
            Dim _DateTo As String = Format(CDate(report.Parameters("DateTo").Value), "yyyy-MM-dd")
            Dim _EmployeeId As String = report.Parameters("EmployeeNo").Value

            Dim SQl4 As New SQLControl
            Dim _ID As Integer = 0
            Try
                Dim SqlString4 As String
                SqlString4 = " Select [ID],ArchiveStatus  
                               From [AttRawatebArchive]
                               Where  [EmployeeID]='" & _EmployeeId & "' and ((DateFrom  between '" & _DateFrom & "'  and '" & _DateTo & "' ) or 
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
            '  MsgBox(report.Parameters("ProcessType").Value)
            If report.Parameters("EmployeeNoAsAcc").Value = String.Empty Then report.Parameters("EmployeeNoAsAcc").Value = DBNull.Value
            If report.Parameters("EmployeeName").Value = String.Empty Then report.Parameters("EmployeeName").Value = DBNull.Value
            If report.Parameters("Branch").Value = String.Empty Then report.Parameters("Branch").Value = DBNull.Value
            If report.Parameters("Department").Value = String.Empty Then report.Parameters("Department").Value = DBNull.Value
            If report.Parameters("JobName").Value = String.Empty Then report.Parameters("JobName").Value = DBNull.Value
            If report.Parameters("BeginDate").Value = String.Empty Then
                report.Parameters("BeginDate").Value = DBNull.Value
            Else
                report.Parameters("BeginDate").Value = Format(CDate(report.Parameters("BeginDate").Value), "yyyy-MM-dd")
            End If
            If report.Parameters("Currency").Value = String.Empty Then report.Parameters("Currency").Value = DBNull.Value
            If CStr(report.Parameters("SalaryMonth").Value) = String.Empty Then report.Parameters("SalaryMonth").Value = DBNull.Value
            If CStr(report.Parameters("BonusAmount").Value) = String.Empty Then report.Parameters("BonusAmount").Value = DBNull.Value
            If CStr(report.Parameters("Transport").Value) = String.Empty Then report.Parameters("Transport").Value = DBNull.Value
            If CStr(report.Parameters("Additions").Value) = String.Empty Then report.Parameters("Additions").Value = DBNull.Value
            If CStr(report.Parameters("LeavesAmount").Value) = String.Empty Then report.Parameters("LeavesAmount").Value = DBNull.Value
            If CStr(report.Parameters("Payment").Value) = String.Empty Then report.Parameters("Payment").Value = DBNull.Value
            If CStr(report.Parameters("GrossSalary").Value) = String.Empty Then report.Parameters("GrossSalary").Value = DBNull.Value
            If CStr(report.Parameters("MonthDays").Value) = String.Empty Then report.Parameters("MonthDays").Value = DBNull.Value
            If CStr(report.Parameters("ActualDays").Value) = String.Empty Then report.Parameters("ActualDays").Value = DBNull.Value
            If CStr(report.Parameters("VocationDays").Value) = String.Empty Then report.Parameters("VocationDays").Value = DBNull.Value
            If CStr(report.Parameters("WeekOffDays").Value) = String.Empty Then report.Parameters("WeekOffDays").Value = DBNull.Value
            If CStr(report.Parameters("AbsenceDays").Value) = String.Empty Then report.Parameters("AbsenceDays").Value = DBNull.Value
            If CStr(report.Parameters("HouresRequired").Value) = String.Empty Then report.Parameters("HouresRequired").Value = DBNull.Value
            If CStr(report.Parameters("ActualHoures").Value) = String.Empty Then report.Parameters("ActualHoures").Value = DBNull.Value
            If CStr(report.Parameters("VocationBegBalance").Value) = String.Empty Then report.Parameters("VocationBegBalance").Value = DBNull.Value
            If CStr(report.Parameters("AccruedVocationDays").Value) = String.Empty Then report.Parameters("AccruedVocationDays").Value = DBNull.Value
            If CStr(report.Parameters("VocationAtEndYear").Value) = String.Empty Then report.Parameters("VocationAtEndYear").Value = DBNull.Value
            If CStr(report.Parameters("VocationSick").Value) = String.Empty Then report.Parameters("VocationSick").Value = DBNull.Value
            If CStr(report.Parameters("NetSalary").Value) = String.Empty Then report.Parameters("NetSalary").Value = DBNull.Value
            If CStr(report.Parameters("SalaryMonth").Value) = String.Empty Then report.Parameters("SalaryMonth").Value = DBNull.Value
            If CStr(report.Parameters("HouresNetBonus").Value) = String.Empty Then report.Parameters("HouresNetBonus").Value = DBNull.Value
            If CStr(report.Parameters("HouresNetLeaves").Value) = String.Empty Then report.Parameters("HouresNetLeaves").Value = DBNull.Value
            If CStr(report.Parameters("BankName").Value) = String.Empty Then report.Parameters("BankName").Value = DBNull.Value
            If CStr(report.Parameters("BankNo").Value) = String.Empty Then report.Parameters("BankNo").Value = DBNull.Value
            If CStr(report.Parameters("BankBranch").Value) = String.Empty Then report.Parameters("BankBranch").Value = DBNull.Value
            If CStr(report.Parameters("IBAN").Value) = String.Empty Then report.Parameters("IBAN").Value = DBNull.Value
            If CStr(report.Parameters("Indenty").Value) = String.Empty Then report.Parameters("Indenty").Value = DBNull.Value
            If CStr(report.Parameters("AbsenceAmount").Value) = String.Empty Then report.Parameters("AbsenceAmount").Value = DBNull.Value
            If CStr(report.Parameters("ProcessType").Value) = String.Empty Then report.Parameters("ProcessType").Value = DBNull.Value
            If CStr(report.XrLabelSalaryPerHourParameter.Text) = String.Empty Then report.XrLabelSalaryPerHourParameter.Text = 0



            If CInt(report.Parameters("SalaryMonth").Value) <= 0 Then
                Dim Msg As DialogResult = XtraMessageBox.Show("لا يوجد راتب لهذا الموظف ، هل تريد الاستمرار؟", "تحذير", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            End If


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
                             ,[NetSalary],HouresNetBonus,HouresNetLeaves,BankName,BankNo,BankBranch,IBAN,Indenty,[ArchiveStatus],AbsenceAmount,ProcessType,SalaryPerHour)
                           VALUES
                             ('" & _DateFrom & "', '" & _DateTo & "','" & report.Parameters("EmployeeNo").Value & "',
                             '" & report.Parameters("EmployeeNoAsAcc").Value & "', N'" & report.Parameters("EmployeeName").Value & "',
                             N'" & report.Parameters("Branch").Value & "',N'" & report.Parameters("Department").Value & "',
                             N'" & report.Parameters("JobName").Value & "','" & report.Parameters("BeginDate").Value & "',
                             '" & report.Parameters("Currency").Value & "','" & report.Parameters("SalaryMonth").Value & "',
                             '" & report.Parameters("BonusAmount").Value & "','" & report.Parameters("Transport").Value & "',
                             '" & report.Parameters("Additions").Value & "','" & report.Parameters("LeavesAmount").Value & "',
                             '" & report.Parameters("Payment").Value & "','" & report.Parameters("GrossSalary").Value & "',
                             '" & report.Parameters("MonthDays").Value & "','" & report.Parameters("ActualDays").Value & "',
                             '" & report.Parameters("VocationDays").Value & "','" & report.Parameters("WeekOffDays").Value & "',
                             '" & report.Parameters("AbsenceDays").Value & "','" & report.Parameters("HouresRequired").Value & "',
                             '" & report.Parameters("ActualHoures").Value & "','" & report.Parameters("VocationBegBalance").Value & "',
                             '" & report.Parameters("AccruedVocationDays").Value & "','" & report.Parameters("VocationAtEndYear").Value & "',
                             '" & report.Parameters("VocationSick").Value & "','" & report.Parameters("NetSalary").Value & "',
                             '" & report.Parameters("HouresNetBonus").Value & "','" & report.Parameters("HouresNetLeaves").Value & "',
                             N'" & report.Parameters("BankName").Value & "','" & report.Parameters("BankNo").Value & "',
                             N'" & report.Parameters("BankBranch").Value & "','" & report.Parameters("IBAN").Value & "',
                             '" & report.Parameters("Indenty").Value & "',0,
                             '" & report.Parameters("AbsenceAmount").Value & "','" & report.Parameters("ProcessType").Value & "','" & report.XrLabelSalaryPerHourParameter.Text & "')"
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                If _ID <> 0 Then SQl4.SqlTrueTimeRunQuery("Delete From [AttRawatebArchive] where ID=" & _ID)
                XtraMessageBox.Show(" تم الحفظ ", "تم", MessageBoxButtons.OK, MessageBoxIcon.None)
            Else
                XtraMessageBox.Show(" خطأ بالحفظ ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            If _Print = True Then
                report.Print()
            End If

            Me.Close()
        Catch ex As Exception
            XtraMessageBox.Show("لا يمكن الحفظ ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.ToString)
        End Try
    End Sub

    'Private Function CheckIfDocExist() As Boolean



    'End Function

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim report As New SalaryReport()
        Dim designTool As New ReportDesignTool(report)
        designTool.ShowDesignerDialog()

        ' Calling the CreateDocument method each time you show the Report Designer is required 
        ' because a report cannot be edited and previewed at the same time.
        report.CreateDocument()
    End Sub

    Private Sub SalaryMonthForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim form As SalaryMonthForm = CType(sender, SalaryMonthForm)
        form.DocumentViewer1.PrintingSystem.ExecCommand(DevExpress.XtraPrinting.PrintingSystemCommand.Parameters, New Object() {False})
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick

        Try

            Dim report As New SalaryReport()
            report = DocumentViewer1.DocumentSource

            With My.Forms.AttLeavesProccess
                ._ProcessTypeInAttLeavesProcess = GetProcessTypeForEmployee(report.Parameters("EmployeeNo").Value)
                .TextEmployeeID.Text = report.Parameters("EmployeeNo").Value
                .TextEmployeeName.Text = report.Parameters("EmployeeName").Value
                .TextVocationsBalance.Text = report.Parameters("VocationAtEndYear").Value

                Dim _TextMaxLeavesHoures As String = report.Parameters("MaxLeavesHoures").Value.ToString
                Dim _TimeMaxLeavesHoures As TimeSpan = New TimeSpan(Integer.Parse(_TextMaxLeavesHoures.Split(":"c)(0)), Integer.Parse(_TextMaxLeavesHoures.Split(":"c)(1)), 0)
                .TextMaxLeavesHoures.EditValue = _TimeMaxLeavesHoures

                Dim _TextTotalNetLeaves As String = report.Parameters("HouresNetLeaves").Value
                Dim _TimeTotalNetLeaves As TimeSpan = New TimeSpan(Integer.Parse(_TextTotalNetLeaves.Split(":"c)(0)), Integer.Parse(_TextTotalNetLeaves.Split(":"c)(1)), 0)
                .TextTotalNetLeaves.EditValue = _TimeTotalNetLeaves

                Dim _TextLeaves As String = report.Parameters("HouresNetLeaves").Value
                '   MsgBox(report.Parameters("HouresNetLeaves").Value)
                Dim _TimeLeaves As TimeSpan = New TimeSpan(Integer.Parse(_TextLeaves.Split(":"c)(0)), Integer.Parse(_TextLeaves.Split(":"c)(1)), 0)


                .MemoDetails.Text = "خصم مغادرات الفترة " & report.Parameters("DateFrom").Value & " : " & report.Parameters("DateTo").Value

                .VocationDate.DateTime = Format(CDate(report.Parameters("DateTo").Value))
                .LookUpEditVocations.EditValue = "سنوية"

                '   Dim _DayDurationByHour As Decimal
                Dim _HouresRequired As Decimal
                Dim _TextHouresRequired As String = report.Parameters("HouresRequired").Value
                Dim _TimeHouresRequired As TimeSpan = New TimeSpan(Integer.Parse(_TextHouresRequired.Split(":"c)(0)), Integer.Parse(_TextHouresRequired.Split(":"c)(1)), 0)
                _HouresRequired = _TimeHouresRequired.TotalHours
                'Dim _MonthDays As Decimal = CDec(report.Parameters("MonthDays").Value)
                Dim _MonthDays As Decimal = CDec(report.Parameters("ActualDays").Value)

                If GetProcessTypeForEmployee(report.Parameters("EmployeeNo").Value) <> 2 Then
                    If _MonthDays > 0 Then
                        .tempdaysLeaves.EditValue = ((_HouresRequired / _MonthDays)).ToString("#.0")
                    Else
                        _MonthDays = 0
                    End If
                Else
                    If _MonthDays > 0 Then
                        .tempdaysLeaves.EditValue = GetHouresRequired(report.Parameters("EmployeeNo").Value).TotalHours
                    Else
                        _MonthDays = 0
                    End If
                End If


                'Dim _SalaryMonth As Decimal = CDec(report.Parameters("SalaryMonth").Value)
                'If _TimeHouresRequired.TotalHours > 0 Or Not String.IsNullOrEmpty(_TimeHouresRequired.TotalHours) Then
                '    .TextLeaveNIS_PerHour.EditValue = (_SalaryMonth / _TimeHouresRequired.TotalHours).ToString("#.00")
                'End If

                Dim _LeavesAmount As Decimal = CDec(report.Parameters("LeavesAmount").Value)
                If _TimeLeaves.TotalHours > 0 Or Not String.IsNullOrEmpty(_TimeLeaves.TotalHours) Then
                    If _TimeLeaves.TotalHours = 0 Then
                        .TextLeaveNIS_PerHour.EditValue = 0
                    Else
                        .TextLeaveNIS_PerHour.EditValue = (_LeavesAmount / _TimeLeaves.TotalHours).ToString("#.00")
                    End If
                End If

            End With

            AttLeavesProccess.ShowDialog()
        Catch ex As Exception
            MsgBox("خطا: لا يمكن معالجة المغادرات")
        End Try

    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
    Private Function GetHouresRequired(EmployeeID As Integer) As TimeSpan
        Dim _Result As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select [RequiredDailyHoures] 
                          From [dbo].[EmployeesData] 
                          Where EmployeeID=" & EmployeeID
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _Result = Sql.SQLDS.Tables(0).Rows(0).Item("RequiredDailyHoures")
        Catch ex As Exception
            _Result = "00:00"
        End Try
        Return TimeSpan.Parse(_Result)
    End Function

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        _Print = True
        SaveSalary()
    End Sub
End Class