Imports DevExpress.XtraEditors

Public Class AttLeavesProccessMonthly
    Private _docID As Integer

    Public Sub New(docID As Integer)
        InitializeComponent()
        _docID = docID
    End Sub
    Private Sub AttLeavesProccessMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _lastTrans As Integer = CheckIDDocumentInLogs()
        If _lastTrans > 0 Then
            ' Me.Close()
            Dim F As New AttLeavesProcessMonthlyLogs(_docID)
            F.ShowDialog()
            Me.Close()
        End If



        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        Me.LabelDocID.Text = " قسيمة راتب رقم: " & _docID

        Me.HyperlinkLabelControl1.Text = " تسويات سابقة عدد  " & _lastTrans
        SpanRequirdDailyHoures.Text = "08:00"
    End Sub
    Public Function GetProcessTypeTable() As DataTable
        Dim Sr As New DataTable
        Sr.Columns.Add("ID", GetType(Integer))
        Sr.Columns.Add("ProcessName", GetType(String))
        Sr.Rows.Add(1, "خصم مغادرات")
        Sr.Rows.Add(2, "خصم اجازة")
        Return Sr
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' Dim report As SalaryReport
        '  report = SalaryMonthForm.DocumentViewer1.DocumentSource
        'MemoDetails.Text = "خصم مغادرات الفترة " & report.Parameters("DateFrom").Value & " : " & report.Parameters("DateTo").Value
        '    MemoDetails.Text = "خصم مغادرات الفترة " & " " & Format(VocationDate.DateTime, "yyyy-MM-dd") & " : " & Format(VocationDate.DateTime, "yyyy-MM-dd")
        Saving()
    End Sub
    Private Sub Saving()
        If CheckIDDocumentInLogs() > 0 Then
            MsgBoxShowError(" يوجد تسوية سابقة، يجب حذفها واعادة المحاولة ")
            Exit Sub
        End If
        If SpanRequirdDailyHoures.Text = "00:00" Then
            MsgBoxShowError(" يجب تحديد عدد الساعات المطلوبة، يجب تحدي واعادة المحاولة ")
            Exit Sub
        End If
        If TextEmployeeID.Text = String.Empty Or VocationDate.Text = String.Empty Or LookUpEditVocations.Text = String.Empty _
            Or TextDayNo.Text = String.Empty Or TextDayNo.EditValue < 0 Then
            XtraMessageBox.Show("يجب تعبئة كل البيانات المطلوبة لترحيل الاجازة")
            Exit Sub
        End If

        Dim Msg As DialogResult = XtraMessageBox.Show("سيتم عمل اجازة ب ساعات المغادرات", "تأكيد", MessageBoxButtons.YesNo)
        If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub

        Dim _docDate As String = Format(VocationDate.DateTime, "yyyy-MM-dd")

        If SpanMonthlyAllowedLeavesPeriod.TimeSpan < SpanLeavesPeriod.TimeSpan Then

        End If

        If SpanMonthlyAllowedLeavesPeriod.TimeSpan >= SpanLeavesPeriod.TimeSpan Then
            UpdateSalaryDocument()
            InsertLog(0)
            MsgBoxShowSuccess(" تمت عملية المعالجة بنجاح بدون اجازة ")
            Me.Close()
        Else
            Dim _vocID As Integer
            _vocID = VocationInsertNew(TextEmployeeID.Text, LookUpEditVocations.EditValue, MemoDetails.Text, _docDate, _docDate, _docDate, TextDayNo.EditValue, "leaves", "-", SpanNetPriodLeavesPeriod.Text, 0)
            If _vocID = 0 Then
                MsgBoxShowError(" خطا في عملية الادخال ")
            Else
                UpdateSalaryDocument()
                InsertLog(_vocID)
                MsgBoxShowSuccess(" تمت عملية ادخال الاجازة بنجاح ")
                Me.Close()
            End If
        End If

    End Sub
    Private Sub InsertLog(vocID As Integer)
        If Me.TextLastLeavesAmount.Text = "" Then Me.TextLastLeavesAmount.EditValue = 0
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " INSERT INTO [dbo].[AttRawatebArchiveAdjustmentLogs]
                                   ([DocID]
                                   ,[InputUser]
                                   ,[LastLeavesTimeSpan],[LastLeavesAmount],[VocID]
                                   ,[TransType])
                             VALUES
                                   (" & _docID & "
                                   ," & GlobalVariables.CurrUser & "
                                   ,'" & SpanLeavesPeriod.Text & "'," & Me.TextLastLeavesAmount.EditValue & "," & vocID & "
                                   ," & "'Leaves'" & ")"
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub
    Private Sub UpdateSalaryDocument()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Update [AttRawatebArchive] Set 
                             [HouresNetLeaves]='00:00',
                             [LeavesAmount]=0,
                             [LeavesIsAdjusted]=1,
                             [NetSalary]=IsNull(NetSalary,0)+IsNull(LeavesAmount,0)
                       Where [ID]=" & _docID
        sql.SqlTrueAccountingRunQuery(sqlstring)
    End Sub
    Private Function CheckIDDocumentInLogs() As Integer
        Try
            Dim sqlString As String
            Dim sql As New SQLControl
            sqlString = " select count(*) as Count from AttRawatebArchiveAdjustmentLogs where DocID=" & _docID
            sql.SqlTrueAccountingRunQuery(sqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub CalcVocationPeriod()
        Try
            If SpanRequirdDailyHoures.TimeSpan.TotalHours > 0 Then
                TextDayNo.EditValue = ((SpanLeavesPeriod.TimeSpan - SpanMonthlyAllowedLeavesPeriod.TimeSpan).TotalHours / SpanRequirdDailyHoures.TimeSpan.TotalHours).ToString("0.0")
            Else
                TextDayNo.EditValue = 0
            End If

        Catch ex As Exception
            TextDayNo.EditValue = 0
        End Try

        Try
            If SpanMonthlyAllowedLeavesPeriod.TimeSpan < SpanLeavesPeriod.TimeSpan Then
                SpanNetPriodLeavesPeriod.TimeSpan = SpanLeavesPeriod.TimeSpan - SpanMonthlyAllowedLeavesPeriod.TimeSpan
            Else
                SpanNetPriodLeavesPeriod.TimeSpan = TimeSpan.Zero
                TextLastLeavesAmount.EditValue = 0
                TextDayNo.EditValue = 0
            End If
        Catch ex As Exception
            SpanNetPriodLeavesPeriod.TimeSpan = TimeSpan.Zero
            TextLastLeavesAmount.EditValue = 0
            TextDayNo.EditValue = 0
        End Try

        Try
            MemoDetails.Text = Me.LabelPeriod.Text & " عن ساعات التأخير  " & SpanNetPriodLeavesPeriod.Text & " ساعة "
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextLeavesPeriod_EditValueChanged_1(sender As Object, e As EventArgs) Handles SpanLeavesPeriod.EditValueChanged
        CalcVocationPeriod()
    End Sub

    Private Sub RequiredDailyHoures_EditValueChanged(sender As Object, e As EventArgs) Handles SpanMonthlyAllowedLeavesPeriod.EditValueChanged
        CalcVocationPeriod()
    End Sub

    Private Sub TextEmployeeID_EditValueChanged(sender As Object, e As EventArgs) Handles TextEmployeeID.EditValueChanged
        Dim _timeFunction As New TimeFunctions
        Dim _employeeeData = GetEmployeeData(TextEmployeeID.Text)
        SpanRequirdDailyHoures.TimeSpan = _timeFunction.ConvertText_hhmm_ToTimeSpan(_employeeeData.RequiredDailyHoures)
        SpanMonthlyAllowedLeavesPeriod.TimeSpan = _employeeeData.MonthlyMaxLeavesHoures
        Me.TextEmployeeName.Text = _employeeeData.EmployeeName
        If SpanRequirdDailyHoures.Text = "00:00" Then
            MsgBoxShowError(" يجب تعريف عدد الساعات اليومية المطلوبة من شاشة بيانات الموظف  ")
        End If
    End Sub

    Private Sub SpanRequirdDailyHoures_EditValueChanged(sender As Object, e As EventArgs) Handles SpanRequirdDailyHoures.EditValueChanged
        CalcVocationPeriod()
    End Sub

    Private Sub SpanNetPriodLeavesPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles SpanNetPriodLeavesPeriod.EditValueChanged


    End Sub

    Private Sub HyperlinkLabelControl1_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles HyperlinkLabelControl1.HyperlinkClick

    End Sub

    Private Sub HyperlinkLabelControl1_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelControl1.Click
        Dim F As New AttLeavesProcessMonthlyLogs(_docID)
        With F
            If .ShowDialog() <> DialogResult.OK And ._deleteLastTrans = True Then
                Me.Close()
            End If
        End With
    End Sub
End Class