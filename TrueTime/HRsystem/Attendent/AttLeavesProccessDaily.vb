Imports DevExpress.XtraEditors

Public Class AttLeavesProccessDaily
    Private Sub AttLeavesProccessDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.Vocations' table. You can move, or remove it, as needed.
        'Me.VocationsTableAdapter.Fill(Me.TrueTimeDataSet.Vocations)

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
        'If LayoutRemainingLeaves.Text = "المتبقي" Then
        '    XtraMessageBox.Show("لا يمكن معالجة المغادرات، عدد ساعات المغادرات أقل من الحد المسموح به")
        '    Exit Sub
        'End If

        'If TextDayNo.EditValue > TextVocationsBalance.EditValue Then
        '    Dim Msg2 As DialogResult = XtraMessageBox.Show("رصيد الاجازات لا يكفي لمعالجة المغادرات", "تأكيد", MessageBoxButtons.YesNo)
        '    If Msg2 = System.Windows.Forms.DialogResult.No Then Exit Sub
        'End If

        Dim Msg As DialogResult = XtraMessageBox.Show("سيتم عمل اجازة ب ساعات المغادرات", "تأكيد", MessageBoxButtons.YesNo)
        If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
        ' Dim report As SalaryReport
        '  report = SalaryMonthForm.DocumentViewer1.DocumentSource
        '  MemoDetails.Text = "خصم مغادرات الفترة " & report.Parameters("DateFrom").Value & " : " & report.Parameters("DateTo").Value
        '    MemoDetails.Text = "خصم مغادرات الفترة " & " " & Format(VocationDate.DateTime, "yyyy-MM-dd") & " : " & Format(VocationDate.DateTime, "yyyy-MM-dd")
        Saving()
    End Sub
    Private Sub Saving()
        If TextEmployeeID.Text = String.Empty Or VocationDate.Text = String.Empty Or LookUpEditVocations.Text = String.Empty _
            Or TextDayNo.Text = String.Empty Or TextDayNo.EditValue <= 0 Then
            XtraMessageBox.Show("يجب تعبئة كل البيانات المطلوبة لترحيل الاجازة")
            Exit Sub
        End If
        Dim DateFrom As String = Format(VocationDate.DateTime, "yyyy-MM-dd")
        Dim DateTo As String = Format(VocationDate.DateTime, "yyyy-MM-dd")

        Try
            Dim sql As New SQLControl
            Dim VocDate As String = Format(VocationDate.DateTime, "yyyy-MM-dd")
            Dim SqlString As String = " 
                                        Insert Into Vocations " _
                                      & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource)" _
                                      & " Values ( " _
                                      & String.Empty & TextEmployeeID.Text & "," _
                                      & "'" & VocDate & "'," _
                                      & "'" & LookUpEditVocations.EditValue & "'," _
                                      & "'" & DateFrom & "'," _
                                      & "'" & DateTo & "'," _
                                      & String.Empty & TextDayNo.Text & "," _
                                      & "N'" & MemoDetails.Text & "'," _
                                      & "'leaves'" _
                                      & " ) "
            SqlString += "   
                                        ; Insert Into AttLeavesProcess " _
                                      & " ([EmployeeID],[ProcessDate],[ProcessType])" _
                                      & " Values ( " _
                                      & TextEmployeeID.Text & "," _
                                      & "'" & VocDate & "'," _
                                      & "" & 2 & "" _
                                      & " ) "
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                XtraMessageBox.Show("تم حفظ السند", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally


        End Try

    End Sub

    Private Sub TextLeavesPeriod_EditValueChanged(sender As Object, e As EventArgs)
        Try
            If Me.IsHandleCreated Then
                TextDayNo.EditValue = TextLeavesPeriod.EditValue / RequiredDailyHoures.EditValue
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CalcVocationPeriod()
        If Me.IsHandleCreated = True Then
            TextDayNo.EditValue = (TextLeavesPeriod.TimeSpan.TotalHours / RequiredDailyHoures.TimeSpan.TotalHours).ToString("0.0")
        End If
    End Sub

    Private Sub TextLeavesPeriod_EditValueChanged_1(sender As Object, e As EventArgs) Handles TextLeavesPeriod.EditValueChanged
        CalcVocationPeriod()
    End Sub

    Private Sub RequiredDailyHoures_EditValueChanged(sender As Object, e As EventArgs) Handles RequiredDailyHoures.EditValueChanged
        CalcVocationPeriod()
    End Sub
End Class