Imports DevExpress.DataProcessing
Imports DevExpress.XtraEditors
Imports DocumentFormat.OpenXml.ExtendedProperties
Imports DocumentFormat.OpenXml.VariantTypes
Imports Microsoft.Graph

Public Class MonthlyAdjustmentForm
    Private _MonthlyRequirdHours As TimeSpan
    Private _Vocations As Decimal = 0.0
    Private _RequireDailyHours As TimeSpan
    Private _Year As Integer
    Private _Month As Integer
    Private _DocDate As Date
    Private _Factor As Integer
    Public Sub New(Month As Integer, Year As Integer, MonthlyRequirdHours As TimeSpan)
        InitializeComponent()
        _Year = Year
        _Month = Month
        _MonthlyRequirdHours = MonthlyRequirdHours
    End Sub
    Private Sub LabelControl2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NetHouresTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles BonusOrLeavesHours.EditValueChanged
        Try
            Dim _NetHoures As TimeSpan
            _NetHoures = BonusOrLeavesHours.EditValue
            If _Factor = -1 Then
                '  BonusOrLeavesHours.BackColor = Color.Red
                CheckAddBalanceToVocation.Enabled = False
                CheckAddToSalary.Enabled = False
                CheckDeductFromSalary.Enabled = True
                CheckDeductFromVocation.Enabled = True
                ' CheckDeductFromVocation.EditValue = True
            Else
                '  BonusOrLeavesHours.BackColor = DefaultBackColor
                CheckAddBalanceToVocation.Enabled = True
                CheckAddToSalary.Enabled = True
                CheckDeductFromVocation.Enabled = False
                CheckDeductFromSalary.Enabled = False
                ' CheckAddBalanceToVocation.EditValue = False
            End If
        Catch ex As Exception

        End Try
        CalcSalary()
        If TheRemainingPeriod.EditValue < TimeSpan.Zero Then
            CheckAddBalanceToVocation.Enabled = False
            CheckAddToSalary.Enabled = False
            CheckDeductFromVocation.Enabled = False
            CheckDeductFromSalary.Enabled = False

            CheckAddBalanceToVocation.EditValue = False
            CheckAddToSalary.EditValue = False
            CheckDeductFromVocation.EditValue = False
            CheckDeductFromSalary.EditValue = False
        End If
    End Sub
    Private Sub CalcSalary()
        If BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero Then
            TextAmount.EditValue = 0
            Exit Sub
        End If
        Try
            Dim _NetHoures As TimeSpan
            _NetHoures = BonusOrDiscountTimeSpan.EditValue
            'If BonusOrDiscountTimeSpan.TimeSpan < TimeSpan.Zero Then
            '    TextAmount.EditValue = Math.Round(Math.Abs(_NetHoures.TotalHours) * TextSalaryPerHour.EditValue)
            'Else
            '    TextAmount.EditValue = Math.Round(Math.Abs(_NetHoures.TotalHours) * TextSalaryPerHour.EditValue * BonusFactor.EditValue)
            'End If

            If _Factor = -1 Then
                TextAmount.EditValue = Math.Round(Math.Abs(_NetHoures.TotalHours) * TextSalaryPerHour.EditValue)
            Else
                TextAmount.EditValue = Math.Round(Math.Abs(_NetHoures.TotalHours) * TextSalaryPerHour.EditValue * BonusFactor.EditValue)
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub MonthlyAdjustmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextMonthlyRequirdHoures.EditValue = _MonthlyRequirdHours
        _DocDate = New Date(_Year, _Month, DateTime.DaysInMonth(_Year, _Month))
        Me.VocationDate.DateTime = _DocDate
        Me.DateDocDate.DateTime = _DocDate
        LookUpEditVocations.Properties.DataSource = GetVocationsTypes()
        LookUpEditVocations.EditValue = 1
        LookUpEditType.Properties.DataSource = GetAdditionsDiscountTypes()
    End Sub
    Private Function GetAdditionsDiscountTypes() As DataTable
        Dim _Table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            If _Factor = 1 Then
                SqlString = " SELECT [ID],      [AdditionsType] as TypeName FROM [dbo].[AttAdditionsTypes] "
            Else
                SqlString = " SELECT [Id] as ID,[PaymentType] As TypeName   FROM [dbo].[AttPaymentsTypes] "
            End If
            sql.SqlTrueTimeRunQuery(SqlString)
            _Table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _Table
    End Function

    Private Sub TextMonthlyRequirdHoures_EditValueChanged(sender As Object, e As EventArgs) Handles TextMonthlyRequirdHoures.EditValueChanged, TextActualHours.EditValueChanged
        CalcPeriod()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Try
            '  Dim _MonthlyHouresRequired, _ActualHoures As Decimal

            '_MonthlyHouresRequired = TimeSpan.FromHours(TextMonthlyRequirdHoures.EditValue)
            '_ActualHoures = TimeSpan.FromHours(TextActualHoures.EditValue)
            'If _MonthlyHouresRequired > 0 Then
            '    .TextSalaryPerHour.Text = TextMonthlySalary.EditValue / GridView1.GetFocusedRowCellValue("MonthlyHouresRequired")
            '    NetHouresTextEdit.EditValue = _MonthlyHouresRequired -
            'End If
            '  _MonthlyHouresRequired = TimeSpan.Parse(TextMonthlyRequirdHoures.EditValue).TotalHours
            '   _ActualHoures = TimeSpan.Parse(TextActualHoures.EditValue).TotalHours
            '   NetHouresTextEdit.EditValue = TimeSpan.Parse(TextMonthlyRequirdHoures.EditValue).TotalHours - TimeSpan.Parse(TextActualHoures.EditValue).TotalHours
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            If TheRemainingPeriod.EditValue < TimeSpan.Zero Then
                MsgBoxShowError(" لا يمكن اجراء التسوية لان الفترة المطلوب معالجتها اكبر من الفترة المتاحة ")
                Exit Sub
            End If
            Dim sql As New SQLControl
            Dim _EmployeeID As Integer = Me.TextEmpID.EditValue
            Dim _DocDateString As String = Format(_DocDate, "yyyy-MM-dd")
            Dim _Text As String = ""
            Dim _VocID, _DocID, AdjusId1, AdjusId2 As Integer
            If _Factor = 1 Then
                If CheckAddBalanceToVocation.EditValue = True Then
                    If String.IsNullOrEmpty(LookUpEditVocations.Text) Then
                        MsgBoxShowError(" يجب اختيار نوع الاجازة ")
                        Exit Sub
                    End If
                    If VocationTimeSpan.EditValue = TimeSpan.Zero Then
                        MsgBoxShowError(" يجب تحديد الفترة المطوب معالجتها ")
                        Exit Sub
                    End If
                    _VocID = InsertVocationAdjustment()
                    If _VocID > 0 Then
                        _Text += " تم ترصيد الإجازة بنجاح " & "/"
                        AdjusId1 = InsertToAttMonthlyAdjustments("AddBalanceToVocation", 0, VocationTimeSpan.EditValue, _VocID, 0, 0, VocationNote.Text)
                    End If
                End If
                If CheckAddToSalary.EditValue = True Then
                    If BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero Then
                        MsgBoxShowError(" يجب تحديد الفترة المطوب معالجتها ")
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(LookUpEditType.Text) Then
                        MsgBoxShowError(" يجب اختيار نوع الاضافة ")
                        Exit Sub
                    End If
                    _DocID = InsertBonusTrans()
                    If _DocID > 0 Then
                        _Text += " تم اضافة ترصيد على الراتب بنجاح " & "/"
                        AdjusId2 = InsertToAttMonthlyAdjustments("AddToSalary", 0, BonusOrDiscountTimeSpan.EditValue, _DocID, 0, 0, DocNote.Text)
                    End If
                End If
                MsgBoxShowSuccess(_Text)
            Else
                If CheckDeductFromVocation.EditValue = True Then
                    If VocationTimeSpan.EditValue = TimeSpan.Zero Then
                        MsgBoxShowError(" يجب تحديد الفترة المطوب معالجتها ")
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(LookUpEditVocations.Text) Then
                        MsgBoxShowError(" يجب اختيار نوع الاجازة ")
                        Exit Sub
                    End If
                    _VocID = InsertVocationAdjustment()
                    If _VocID > 0 Then
                        _Text += " تم خصم من الإجازات بنجاح " & "/"
                        AdjusId1 = InsertToAttMonthlyAdjustments("DeductFromVocation", 0, VocationTimeSpan.EditValue, _VocID, 0, 0, VocationNote.Text)
                    End If
                End If
                If CheckDeductFromSalary.EditValue = True Then
                    If BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero Then
                        MsgBoxShowError(" يجب تحديد الفترة المطوب معالجتها ")
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(LookUpEditType.Text) Then
                        MsgBoxShowError(" يجب اختيار نوع الخصم ")
                        Exit Sub
                    End If
                    _DocID = InsertDiscountTrans()
                    If _DocID > 0 Then
                        _Text += " تم خصم المبلغ من الراتب بنجاح " & "/"
                        AdjusId2 = InsertToAttMonthlyAdjustments("DeductFromSalary", 0, BonusOrDiscountTimeSpan.EditValue, _DocID, 0, 0, DocNote.Text)
                    End If
                End If
                If _Text <> "" Then MsgBoxShowSuccess(_Text)
            End If
            GetData()
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try
        GetData()
    End Sub
    Private j = 0
    Private Function InsertToAttMonthlyAdjustments(_ProcessName As String, _Amount As Decimal, _Period As TimeSpan, _VocDocID As Integer, _AdditionDocID As Integer, _PaymentDocID As Integer, _Note As String) As Integer
        Try
            Dim Sql As New SQLControl
            Dim Sqlstring As String
            Dim _TimeFunction As New TimeFunctions
            Dim StringPeriod As String = _TimeFunction.ConvertTimeSpan_hhmmm_ToString(_Period)
            Sqlstring = " INSERT INTO [dbo].[AttMonthlyAdjustments] (
                                  [Month],[Year],[EmpID],[ProcessType],[Amount],[Priod],
                                  [VocDocID],[AdditionDocID],[PaymentDocID],[Notes],[InputUser] ) Output Inserted.ID
     VALUES
           (" & _Month & "
           ," & _Year & "
           ," & Me.TextEmpID.EditValue & "
           ,'" & _ProcessName & "'
           ," & _Amount & "
           ,'" & StringPeriod & "'
           ," & _VocDocID & "
           ," & _AdditionDocID & "
           ," & _PaymentDocID & ",N'" & _Note & "'," & GlobalVariables.CurrUser & "); "
            If Sql.SqlTrueAccountingRunQuery(Sqlstring) = True Then
                Return Sql.SQLDS.Tables(0).Rows(0).Item("ID")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Function InsertVocationAdjustment() As Integer
        Dim _VocID As Integer = 0
        Try
            Dim sql As New SQLControl
            Dim _ID As Integer = GetMaxVocationID() + 1
            Dim _DocDateString As String = Format(_DocDate, "yyyy-MM-dd")
            Dim _VocationType As Integer = LookUpEditVocations.EditValue
            Dim _DaysNo As Decimal = CDec(VocationTimeSpan.TimeSpan.TotalHours / _RequireDailyHours.TotalHours) * 1.ToString("n2")
            If _Factor = 1 Then
                _DaysNo = -1 * _DaysNo
            Else
                _DaysNo = 1 * _DaysNo
            End If
            Dim SqlString As String = "  Insert Into Vocations  
                                     (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource) 
                                      Output Inserted.VocID 
                                     Values ( " & Me.TextEmpID.EditValue & ",'" & _DocDateString & "',N'" & _VocationType & "','" & _DocDateString & "','" & _DocDateString & "'," & _DaysNo & ",N'" & VocationNote.Text & "',N'adjust' ) "
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                _VocID = sql.SQLDS.Tables(0).Rows(0).Item("VocID")
            End If
        Catch ex As Exception
            _VocID = 0
        End Try
        Return _VocID
    End Function
    Private Function InsertDiscountTrans() As Integer
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
           ,'" & Me.TextEmpID.EditValue & "'
           ," & Me.TextAmount.EditValue & "
           ,N'" & Me.DocNote.Text & "'
           ,N'" & LookUpEditType.EditValue & "'
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
    Private Function InsertBonusTrans() As Integer
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
           ,'" & Me.TextEmpID.EditValue & "'
           ," & Me.TextAmount.EditValue & "
           ,N'" & Me.DocNote.Text & "'
           ,N'" & LookUpEditType.EditValue & "')"
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
    Private Sub CalcPeriod()
        If Me.IsHandleCreated Then
            Try
                j += 1
                Dim t1 As New TimeSpan(Split(TextMonthlyRequirdHoures.Text, ":")(0), Split(TextMonthlyRequirdHoures.Text, ":")(1), 0)
                Dim t2 As New TimeSpan(Split(TextActualHours.Text, ":")(0), Split(TextActualHours.Text, ":")(1), 0)
                TextActualHours.EditValue = t2
                Dim Difference3 As TimeSpan = t2 - t1
                If Difference3 > TimeSpan.Zero Then
                    LayoutControlItemMaxLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                    BonusOrLeavesHours.BackColor = DefaultBackColor
                    _Factor = 1
                Else
                    LayoutControlItemMaxLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    Difference3 = -Difference3
                    BonusOrLeavesHours.BackColor = Color.Red
                    _Factor = -1
                End If

                BonusOrLeavesHours.EditValue = Difference3

                If _Factor = -1 Then
                    If BonusOrLeavesHours.EditValue <= TimeSpanMaxLeavesHours.EditValue Then
                        BonusOrLeavesHours.EditValue = TimeSpan.Zero
                    Else
                        BonusOrLeavesHours.EditValue = BonusOrLeavesHours.EditValue - TimeSpanMaxLeavesHours.EditValue
                    End If
                End If

                If _Factor = 1 Then
                    TheRemainingPeriod.EditValue = BonusOrLeavesHours.EditValue - SumForLastAdjustments.EditValue - CurrentProcessingPeriod.EditValue
                Else
                    TheRemainingPeriod.EditValue = BonusOrLeavesHours.EditValue - SumForLastAdjustments.EditValue - CurrentProcessingPeriod.EditValue
                End If

            Catch ex As Exception

            End Try
            Console.WriteLine(j)
        End If

    End Sub
    Private Sub WriteNote(_Procedure)
        If Me.IsHandleCreated Then
            Try
                Dim _Text As String
                _Text = "..."
                DocNote.Text = ""
                Dim _NetHouresTextEdit As TimeSpan
                Dim _VocationsData = GetVocationsBalancesByEmployee(Me.TextEmpID.EditValue, 1, Today())
                _NetHouresTextEdit = BonusOrLeavesHours.EditValue
                Select Case _Procedure
                    Case "AddBalanceToVocation"
                        If VocationTimeSpan.EditValue = TimeSpan.Zero Then
                            _Text = ""
                            VocationNote.Text = ""
                        Else
                            _Text = " ترصيد الاجازة "
                            _Vocations = CDec(VocationTimeSpan.TimeSpan.TotalHours / _RequireDailyHours.TotalHours) * 1.ToString("n2")
                            ' VocationTimeSpan.EditValue = Me.TheRemainingPeriod.EditValue
                            _Text += CStr(Format(_Vocations, "n2"))
                            _Text += " يوم "
                            _Text += " علما أن الرصيد الحالي للاجازات هو "
                            _Text += CStr(_VocationsData.Balance)
                            _Text += " يوم "
                            VocationNote.Text = " ترصيد اجازة بدل عمل اضافي " & Me.VocationTimeSpan.Text & " ساعة " & " للفترة " & _Month & " / " & _Year
                            LabelForAddBalanceToVocation.Text = _Text
                        End If

                    Case "DeductFromVocation"

                        _Text = " خصم من الاجازات  "
                        _Vocations = CDec(_NetHouresTextEdit.TotalHours / _RequireDailyHours.TotalHours) * -1.ToString("n2")
                        _Text += CStr(Format(_Vocations, "n2"))
                        _Text += " يوم "
                        _Text += " علما أن الرصيد الحالي للاجازات هو "
                        _Text += CStr(_VocationsData.Balance)
                        _Text += " يوم "
                        If _VocationsData.Balance < _Vocations Then
                            LabelResult.ItemAppearance.Normal.ForeColor = Color.OrangeRed
                        Else
                            LabelResult.ItemAppearance.Normal.ForeColor = DefaultForeColor
                        End If
                        DocNote.Text = " خصم مغادرات الفترة لشهر  " & _Month & " / " & _Year
                    Case "DeductFromSalary"
                        _Text = " خصم مبلغ   "
                        _Text += CStr(TextAmount.EditValue) & " شيكل "
                        _Text += " من الراتب "
                        DocNote.Text = " خصم من الراتب بدل دوام اقل من الساعات المطلوبة بـ "
                        DocNote.Text += CStr(BonusOrDiscountTimeSpan.Text)
                    Case "AddToSalary"
                        If BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero Then
                            _Text = ""
                            DocNote.Text = ""
                        End If
                        _Text = " ترصيد مبلغ   "
                        _Text += CStr(TextAmount.EditValue) & " شيكل "
                        _Text += " على الراتب "
                        DocNote.Text = " اضافي على الراتب بدل دوام اضافي "
                        DocNote.Text += CStr(BonusOrDiscountTimeSpan.Text)
                        DocNote.Text += " ساعة  "
                        LabelForAddToSalary.Text = _Text
                    Case Else
                        _Text = " ...  "
                        DocNote.Text = ""
                End Select

            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub TextEmpID_EditValueChanged(sender As Object, e As EventArgs) Handles TextEmpID.EditValueChanged
        GetData()
    End Sub
    Private Sub GetData()

        Dim _LastAdjustment As TimeSpan = GetAttAdjustmentsForMonthAdjustments(TextEmpID.Text, _Month, _Year)
        Me.SumForLastAdjustments.EditValue = _LastAdjustment
        CurrentProcessingPeriod.EditValue = TimeSpan.Zero
        BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero
        VocationTimeSpan.EditValue = TimeSpan.Zero

        Dim _empdata = GetEmployeeData(TextEmpID.EditValue)
        TextEmpName.Text = _empdata.EmployeeName
        TextMonthlySalary.Text = _empdata.MonthlySalary
        _RequireDailyHours = _empdata.RequiredDailyHoures
        TextSalaryPerHour.EditValue = _empdata.SalaryPerHour
        BonusFactor.Text = _empdata.BonusFactor
        TimeSpanMaxLeavesHours.EditValue = _empdata.MonthlyMaxLeavesHoures
        HyperlinkLabelControl1.Text = " حركات التسوية السابقة " & GetCountForLastAdjustments()
        CalcPeriod()
    End Sub

    Private Sub GroupControl4_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub TextAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextAmount.EditValueChanged

    End Sub

    Private Sub TextSalaryPerHour_EditValueChanged(sender As Object, e As EventArgs) Handles TextSalaryPerHour.EditValueChanged
        CalcSalary()
    End Sub

    Private Sub BonusFactor_EditValueChanged(sender As Object, e As EventArgs) Handles BonusFactor.EditValueChanged
        CalcSalary()
    End Sub

    Private Sub TimeSpanMaxLeavesHours_EditValueChanged(sender As Object, e As EventArgs) Handles TimeSpanMaxLeavesHours.EditValueChanged
        CalcPeriod()
    End Sub

    Private Sub CheckAddBalanceToVocation_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAddBalanceToVocation.CheckedChanged
        CheckedProcedure()
    End Sub
    Private Sub CheckDeductFromVocation_CheckedChanged(sender As Object, e As EventArgs) Handles CheckDeductFromVocation.CheckedChanged
        CheckedProcedure()
    End Sub
    Private Sub CheckDeductFromSalary_CheckedChanged(sender As Object, e As EventArgs) Handles CheckDeductFromSalary.CheckedChanged
        CheckedProcedure()
    End Sub
    Private Sub CheckedProcedure()
        If _Factor = 1 Then
            If CheckAddBalanceToVocation.EditValue = False Then
                VocationTimeSpan.EditValue = TimeSpan.Zero
                VocationTimeSpan.ReadOnly = True
            Else
                VocationTimeSpan.ReadOnly = False

            End If
            If CheckAddToSalary.EditValue = False Then
                BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero
                BonusOrDiscountTimeSpan.ReadOnly = True
                LayoutControlItem29.Text = " نوع الخصم "
            Else
                BonusOrDiscountTimeSpan.ReadOnly = False
                LayoutControlItem29.Text = " نوع الاضافة "
            End If


        End If

        If _Factor = -1 Then
            If CheckDeductFromVocation.EditValue = False Then
                VocationTimeSpan.EditValue = TimeSpan.Zero
                VocationTimeSpan.ReadOnly = True
            Else
                VocationTimeSpan.ReadOnly = False
            End If
            If CheckDeductFromSalary.EditValue = False Then
                BonusOrDiscountTimeSpan.EditValue = TimeSpan.Zero
                BonusOrDiscountTimeSpan.ReadOnly = True
            Else
                BonusOrDiscountTimeSpan.ReadOnly = False
            End If
        End If



    End Sub
    Private Sub CalcRemainingPeriod()
        CurrentProcessingPeriod.EditValue = VocationTimeSpan.EditValue + BonusOrDiscountTimeSpan.EditValue
    End Sub
    Private Sub AddBalanceToVocation()

    End Sub

    Private Sub VocationTimeSpan_EditValueChanged(sender As Object, e As EventArgs) Handles VocationTimeSpan.EditValueChanged
        'Me.CurrentProcessingPeriod.EditValue = Me.CurrentProcessingPeriod.EditValue + BonusOrDiscountTimeSpan.EditValue
        '' CalcPeriod()
        'If _Factor > 1 Then

        'End If

        CalcRemainingPeriod()
        WriteNote("AddBalanceToVocation")
    End Sub

    Private Sub CurrentProcessingPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles CurrentProcessingPeriod.EditValueChanged
        CalcPeriod()
    End Sub

    Private Sub BonusOrDiscountTimeSpan_EditValueChanged(sender As Object, e As EventArgs) Handles BonusOrDiscountTimeSpan.EditValueChanged
        CalcRemainingPeriod()
        CalcSalary()
        If _Factor = 1 Then
            WriteNote("AddToSalary")
        Else
            WriteNote("DeductFromSalary")
        End If

    End Sub

    Private Sub CheckAddToSalary_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAddToSalary.CheckedChanged
        CheckedProcedure()
    End Sub

    Private Sub LookUpEditType_Properties_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles LookUpEditType.Properties.AddNewValue

    End Sub

    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles HyperlinkLabelControl1.HyperlinkClick
        Dim F As New AttMonthlyLastAdjustments(Me.TextEmpID.Text, _Year, _Month)
        If F.ShowDialog() <> DialogResult.OK Then
            ' Me.SumForLastAdjustments.EditValue =
            GetData()
        End If
    End Sub
    Private Function GetCountForLastAdjustments() As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "select count(*) As _Count from AttMonthlyAdjustments where EmpID=" & Me.TextEmpID.EditValue & " and Year=" & _Year & " and Month=" & _Month
            sql.SqlTrueTimeRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return sql.SQLDS.Tables(0).Rows(0).Item("_Count")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub CheckAddBalanceToVocation_Click(sender As Object, e As EventArgs) Handles CheckAddBalanceToVocation.Click
        TabbedControlGroup1.SelectedTabPage = TabVocation
    End Sub

    Private Sub CheckAddToSalary_Click(sender As Object, e As EventArgs) Handles CheckAddToSalary.Click
        TabbedControlGroup1.SelectedTabPage = TabSalary
    End Sub

    Private Sub CheckDeductFromVocation_Click(sender As Object, e As EventArgs) Handles CheckDeductFromVocation.Click
        TabbedControlGroup1.SelectedTabPage = TabVocation
    End Sub

    Private Sub CheckDeductFromSalary_Click(sender As Object, e As EventArgs) Handles CheckDeductFromSalary.Click
        TabbedControlGroup1.SelectedTabPage = TabSalary
    End Sub

    Private Sub LookUpEditType_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditType.EditValueChanged

    End Sub
End Class