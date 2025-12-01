Imports DevExpress.XtraEditors

Public Class MonthlyAdjustmentAtt


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetSettings()
        Dim sqlstring As String
        Dim sql As New SQLControl
        sqlstring = " select SettingValue From Settings where SettingName ='AttInMonthSalaryAdjustmentsCalcRequHouresFromEmployee' "
        If sql.SqlTrueTimeRunQuery(sqlstring) = True Then
            RequireHoursFromEmplData.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        End If
    End Sub

    Private Sub GetData()
        Try
            GridControl1.DataSource = Nothing

            Dim _EmployeeTable As DataTable
            Dim sql As New SQLControl
            Dim _DateFrom As New Date(txtYear.Text, txtMonth.EditValue, 1)
            Dim _DateTo As New Date(txtYear.Text, txtMonth.EditValue, DateTime.DaysInMonth(txtYear.Text, txtMonth.EditValue))
            Dim sqlstring As String
            Dim _TimeFunction As New TimeFunctions

            sqlstring = " select [EmployeeID],[EmployeeName],[Branch],[Department],[JobName],[Active],'00:00' as WorkingHoures,'00:00' as MonthlyHouresRequired,0.0 as PaidVocations,'00:00' As PaidVocationsHours,'00:00' as NetRequireHours,'00:00' as Diff,0 as DiffFactor,'00:00' as LastAdjustments,'00:00' as MonthlyMaxLeavesHoures   from [dbo].[EmployeesData] where ProcessType=6 "
            If CheckEditCheckActive.Checked = True Then sqlstring += " and EmployeesData.Active = 1  "
            If Not String.IsNullOrEmpty(SearchEmployees.Text) Then
                sqlstring = sqlstring + " And EmployeeID =" & SearchEmployees.EditValue
            End If
            If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then sqlstring = sqlstring + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
            If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then sqlstring = sqlstring + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
            If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then sqlstring = sqlstring + " And JobName = N'" & LookUpEditPosition.EditValue & "'"
            sql.SqlTrueTimeRunQuery(sqlstring)
            _EmployeeTable = sql.SQLDS.Tables(0)

            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Properties.Maximum = _EmployeeTable.Rows.Count

            For i = 0 To _EmployeeTable.Rows.Count - 1
                Dim _EmployeeID As Object = _EmployeeTable.Rows(i).Item("EmployeeID")
                If CheckIfEmployeeHasTrans(_EmployeeID, _DateFrom, _DateTo) = False Then
                    _EmployeeTable.Rows(i).Delete()
                    Continue For
                End If
                Dim _EmpData = GetEmployeeData(_EmployeeID)


                Dim f As New AttRawatebByHouresRequired
                With f
                    GetFormType("MonthlyRequirdHoures")
                    .DateEdit1.DateTime = _DateFrom
                    .DateEdit2.DateTime = _DateTo
                    .SearchLookUpEdit1.EditValue = _EmployeeID
                    ._OpenForPrint = True
                    .Show()
                    _EmployeeTable.Rows(i).Item("WorkingHoures") = GlobalVariables._TotalWorkingHoursInMonthlyAdjustment
                    GlobalVariables._TotalWorkingHoursInMonthlyAdjustment = "00:00"
                End With
                Dim _WorkingHours As TimeSpan = _TimeFunction.ConvertText_hhmm_ToTimeSpan(_EmployeeTable.Rows(i).Item("WorkingHoures"))

                If RequireHoursFromEmplData.EditValue = "True" Then
                    _EmployeeTable.Rows(i).Item("MonthlyHouresRequired") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_EmpData.MonthlyHouresRequired)
                Else
                    _EmployeeTable.Rows(i).Item("MonthlyHouresRequired") = GlobalVariables._TotalRequiredHoursInMonthlyAdjustment.ToString
                    GlobalVariables._TotalRequiredHoursInMonthlyAdjustment = "00:00"
                End If

                Dim _LastAdjustments As TimeSpan = GetAttAdjustmentsForMonthAdjustments(CInt(_EmployeeID), Me.txtMonth.EditValue, Me.txtYear.EditValue)
                _EmployeeTable.Rows(i).Item("LastAdjustments") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_LastAdjustments)
                _EmployeeTable.Rows(i).Item("PaidVocations") = GetSumForPaidVocations(_EmployeeID, Me.txtMonth.EditValue, Me.txtYear.EditValue)

                Dim _MonthlyHouresRequired As TimeSpan = _TimeFunction.ConvertText_hhmm_ToTimeSpan(_EmployeeTable.Rows(i).Item("MonthlyHouresRequired"))
                If _EmpData.RequiredDailyHoures.TotalHours = 0 Then
                    MsgBoxShowError(" لا يوجد تعريف لعدد ساعات العمل اليومية للموظف " & _EmployeeTable.Rows(i).Item("EmployeeName") & " ")
                End If
                Dim _PaidVocationsHours As TimeSpan = TimeSpan.FromHours(_EmpData.RequiredDailyHoures.TotalHours * _EmployeeTable.Rows(i).Item("PaidVocations"))
                Dim _NetRequireHours As TimeSpan = _MonthlyHouresRequired - _PaidVocationsHours
                Dim _DiffFactor As Integer = 0


                _EmployeeTable.Rows(i).Item("NetRequireHours") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_NetRequireHours)
                _EmployeeTable.Rows(i).Item("PaidVocationsHours") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_PaidVocationsHours)
                _EmployeeTable.Rows(i).Item("MonthlyMaxLeavesHoures") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_EmpData.MonthlyMaxLeavesHoures)

                If _WorkingHours >= _NetRequireHours Then _EmployeeTable.Rows(i).Item("DiffFactor") = 1
                If _WorkingHours < _NetRequireHours Then _EmployeeTable.Rows(i).Item("DiffFactor") = -1

                If _EmployeeTable.Rows(i).Item("DiffFactor") = 1 Then
                    _EmployeeTable.Rows(i).Item("Diff") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(TimeSpan.FromTicks(Math.Abs((_WorkingHours - _NetRequireHours - _LastAdjustments).Ticks)))
                Else
                    _EmployeeTable.Rows(i).Item("Diff") = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(TimeSpan.FromTicks(Math.Abs((_WorkingHours - _NetRequireHours + _LastAdjustments + _EmpData.MonthlyMaxLeavesHoures).Ticks)))
                End If




                If _EmployeeTable.Rows(i).Item("WorkingHoures") = "00:00" Then _EmployeeTable.Rows(i).Delete()
                ProgressBarControl1.EditValue = i + 1
                ProgressBarControl1.Update()
            Next
            GridControl1.DataSource = _EmployeeTable
            ProgressBarControl1.Properties.Maximum = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
            ProgressBarControl1.Properties.Maximum = 0
        End Try

    End Sub


    Private Sub MonthlyAdjustmentAtt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        GetSettings()
        Dim _Month As String = Format(Today(), "MM")
        If Format(Today(), "MM") <> "01" Then
            txtMonth.EditValue = CInt(Format(Today(), "MM")) - 1
            txtYear.EditValue = Format(Today, "yyyy")
        Else
            txtMonth.EditValue = "12"
            txtYear.EditValue = CInt(Format(Today, "yyyy")) - 1
        End If
        Me.SearchEmployees.Properties.DataSource = GetEmployeesTable(1, 6)
    End Sub

    Private Sub RepositoryProcess_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryProcess.ButtonClick
        Try
            Dim _DateFrom As New Date(txtYear.Text, txtMonth.EditValue, 1)
            Dim _DateTo As New Date(txtYear.Text, txtMonth.EditValue, DateTime.DaysInMonth(txtYear.Text, txtMonth.EditValue))
            Dim _EmpID As Integer = CInt(GridView1.GetFocusedRowCellValue("EmployeeID"))
            Dim _RequiredHoures As New TimeSpan(Split(GridView1.GetFocusedRowCellValue("NetRequireHours"), ":")(0), Split(GridView1.GetFocusedRowCellValue("NetRequireHours"), ":")(1), 0)
            Dim _WorkingHoures As New TimeSpan(Split(GridView1.GetFocusedRowCellValue("WorkingHoures"), ":")(0), Split(GridView1.GetFocusedRowCellValue("WorkingHoures"), ":")(1), 0)
            Dim f As New MonthlyAdjustmentForm(txtMonth.Text, txtYear.Text, _RequiredHoures)
            With f
                .DateDocDate.DateTime = _DateTo
                .TextActualHours.EditValue = _WorkingHoures
                .TextEmpID.Text = _EmpID
                If .ShowDialog() <> DialogResult.OK Then
                    ' UpdateData()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function GetSumForPaidVocations(_EmpID As Integer, _Month As Integer, _Year As Integer) As Decimal
        Dim _days As Decimal
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = " DECLARE @EmployeeID INT = " & _EmpID & "; 
                        DECLARE @Month INT = " & _Month & ";
                        DECLARE @Year INT = " & _Year & ";
                        SELECT 
                            Sum(DATEDIFF(
                                DAY, 
                                CASE 
                                    WHEN FromDate < DATEFROMPARTS(@Year, @Month, 1) THEN DATEFROMPARTS(@Year, @Month, 1)
                                    ELSE FromDate
                                END,
                                CASE 
                                    WHEN ToDate > EOMONTH(DATEFROMPARTS(@Year, @Month, 1)) THEN EOMONTH(DATEFROMPARTS(@Year, @Month, 1))
                                    ELSE ToDate
                                END
                            ) + 1 ) As DaysNo
                        FROM Vocations V 
                        Left Join VocationsTypes T on V.VocationType=T.VocID 
                        WHERE T.VocationPaid=1 And VocationSource='vocation' And EmployeeID = @EmployeeID
                            AND ((FromDate >= DATEFROMPARTS(@Year, @Month, 1) AND FromDate <= EOMONTH(DATEFROMPARTS(@Year, @Month, 1)))
                            OR (ToDate >= DATEFROMPARTS(@Year, @Month, 1) AND ToDate <= EOMONTH(DATEFROMPARTS(@Year, @Month, 1)))
                            OR (FromDate < DATEFROMPARTS(@Year, @Month, 1) AND ToDate > EOMONTH(DATEFROMPARTS(@Year, @Month, 1))))   "
            sql.SqlTrueTimeRunQuery(sqlstring)
            If IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DaysNo")) Then
                _days = 0
            Else
                _days = sql.SQLDS.Tables(0).Rows(0).Item("DaysNo")
            End If
        Catch ex As Exception
            _days = 0
        End Try

        Return _days
    End Function

    Private Sub RepositoryItemHyperLinkEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemHyperLinkEdit1.ButtonClick

    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim F As New EmployeesEdit
        F.EmployeeIDTextEdit.Text = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EmployeeID"))
        F.EmployeeNameTextEdit.Select()
        F.ShowDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            Dim _Timefunction As New TimeFunctions
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If selectedRowHandles.Length = 0 Then
                MsgBoxShowError(" لم يتم اختيار اي موظف  ")
                Exit Sub
            End If
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Properties.Maximum = selectedRowHandles.Length
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim _DiffFactor As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "DiffFactor")
                Dim _EmployeeID As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeID")
                Dim _EmpData = GetEmployeeData(_EmployeeID)
                Dim _Diff As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "Diff")
                Dim _DocDate As Date = New Date(txtYear.Text, txtMonth.EditValue, DateTime.DaysInMonth(txtYear.Text, txtMonth.EditValue))
                Dim _Amount = Math.Round(Math.Abs(_Timefunction.ConvertText_hhmm_ToTimeSpan(_Diff).TotalHours) * _EmpData.SalaryPerHour)

                Dim _DocID, AdjusId2 As Integer
                If _DiffFactor = -1 Then
                    Dim _Type As Integer = Att_Get_DefualtDiscountTypeID()
                    Dim _DocNote As String = " خصم من الراتب بدل دوام اقل من الساعات المطلوبة بـ " & _Diff
                    _DocID = InsertDiscountTrans(_DocDate, _EmployeeID, _Amount, _DocNote, _Type)
                    If _DocID > 0 Then
                        AdjusId2 = InsertToAttMonthlyAdjustments(_EmployeeID, "DeductFromSalary", 0, _Timefunction.ConvertText_hhmm_ToTimeSpan(_Diff), 0, 0, _DocID, _DocNote)
                    End If
                ElseIf _DiffFactor = 1 Then
                    Dim _Type As Integer = Att_Get_DefualtAdditionTypeID()
                    Dim _DocNote As String = " اضافة على الراتب بدل دوام اضافي بـ " & _Diff
                    _DocID = InsertBonusTrans(_DocDate, _EmployeeID, _Amount * _EmpData.BonusFactor, _DocNote, _Type)
                    If _DocID > 0 Then
                        AdjusId2 = InsertToAttMonthlyAdjustments(_EmployeeID, "AddToSalary", 0, _Timefunction.ConvertText_hhmm_ToTimeSpan(_Diff), 0, _DocID, 0, _DocNote)
                    End If
                End If
                ProgressBarControl1.EditValue = i + 1
                ProgressBarControl1.Update()
            Next
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try
        ProgressBarControl1.Properties.Maximum = 0
    End Sub
    Private Function InsertDiscountTrans(_DocDate As Date, _EmpID As Integer, _Amount As Decimal, _DocNote As String, _PaymentType As Integer) As Integer
        Dim _DocID As Integer
        Try
            Dim InsertString As String = " INSERT INTO [AttEmployeePayments]
           ([PaymentDate]
           ,[EmployeeID]
           ,[PaymentAmount]
           ,[PaymentNote]
           ,[PaymentType],[PaymentBranch],[Status]) output Inserted.PaymentID
     VALUES
           ('" & Format(_DocDate, "yyyy-MM-dd") & "'
           ,'" & _EmpID & "'
           ," & _Amount & "
           ,N'" & _DocNote & "'
           ,N'" & _PaymentType & "'
           ,N'" & 0 & "',1)"
            Dim sql As New SQLControl
            If sql.SqlTrueTimeRunQuery(InsertString) = True Then
                _DocID = sql.SQLDS.Tables(0).Rows(0).Item("PaymentID")
            Else
                _DocID = 0
            End If
        Catch ex As Exception

        End Try
        Return _DocID
    End Function
    Private Function InsertBonusTrans(_DocDate As Date, _EmpID As Integer, _Amount As Decimal, _DocNote As String, _AdditionType As Integer) As Integer
        Dim _DocID As Integer
        Try
            Dim InsertString As String = " INSERT INTO [AttEmployeeAdditions]
           ([AdditionDate]
           ,[EmployeeID]
           ,[AdditionAmount]
           ,[AdditionNote]
           ,[AdditionType]) output Inserted.AdditionID
            VALUES 
           ('" & Format(_DocDate, "yyyy-MM-dd") & "'
           ,'" & _EmpID & "'
           ," & _Amount & "
           ,N'" & _DocNote & "'
           ,N'" & _AdditionType & "')"
            Dim sql As New SQLControl
            If sql.SqlTrueTimeRunQuery(InsertString) = True Then
                _DocID = sql.SQLDS.Tables(0).Rows(0).Item("AdditionID")
            Else
                _DocID = 0
            End If
        Catch ex As Exception
            _DocID = 0
        End Try
        Return _DocID
    End Function
    Private Function InsertToAttMonthlyAdjustments(_EmpID As Integer, _ProcessName As String, _Amount As Decimal, _Period As TimeSpan, _VocDocID As Integer, _AdditionDocID As Integer, _PaymentDocID As Integer, _Note As String) As Integer
        Dim _ID As Integer
        Try
            Dim Sql As New SQLControl
            Dim Sqlstring As String
            Dim _TimeFunction As New TimeFunctions
            Dim StringPeriod As String = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_Period)
            Sqlstring = " INSERT INTO [dbo].[AttMonthlyAdjustments] (
                                  [Month],[Year],[EmpID],[ProcessType],[Amount],[Priod],
                                  [VocDocID],[AdditionDocID],[PaymentDocID],[Notes],[InputUser] ) Output Inserted.ID
     VALUES
           (" & Me.txtMonth.Text & "
           ," & Me.txtYear.Text & "
           ," & _EmpID & "
           ,'" & _ProcessName & "'
           ," & _Amount & "
           ,'" & StringPeriod & "'
           ," & _VocDocID & "
           ," & _AdditionDocID & "
           ," & _PaymentDocID & ",N'" & _Note & "'," & GlobalVariables.CurrUser & "); "
            If Sql.SqlTrueAccountingRunQuery(Sqlstring) = True Then
                _ID = Sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Else
                _ID = 0
            End If
        Catch ex As Exception
            _ID = 0
        End Try
        Return _ID
    End Function



    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        ''AttMonthlyAdjustmentSettings.ShowDialog()
        Dim F As New AttMonthlyAdjustmentSettings()
        F.ShowDialog()
    End Sub
End Class