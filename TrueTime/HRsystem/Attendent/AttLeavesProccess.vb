

Imports System.ComponentModel
Imports DevExpress.XtraEditors

Public Class AttLeavesProccess
    Public _ProcessTypeInAttLeavesProcess As Integer
    Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim report As SalaryReport
        report = SalaryMonthForm.DocumentViewer1.DocumentSource
        Select Case RadioGroup1.EditValue

            Case "1"
                Dim Msg As DialogResult = XtraMessageBox.Show("سيتم خصم مبلغ المغادرات من الراتب هل تود الاستمرار؟", "تأكيد", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub

                Select Case LayoutRemainingLeaves.Text
                    Case "تجاوز"
                        report.Parameters("NetSalary").Value = CDec(report.Parameters("NetSalary").Value) - (TextLeavesAmount.EditValue - report.Parameters("LeavesAmount").Value)
                        report.Parameters("LeavesAmount").Value = TextLeavesAmount.EditValue
                        report.Parameters("Leaves").Value = TextRemainingLeaves.EditValue.ToString
                    Case "المتبقي"
                        report.Parameters("NetSalary").Value = CDec(report.Parameters("NetSalary").Value) + CDec(report.Parameters("LeavesAmount").Value)
                        report.Parameters("LeavesAmount").Value = "0"
                        report.Parameters("Leaves").Value = "0"

                End Select




            Case "2"
                If LayoutRemainingLeaves.Text = "المتبقي" Then
                    XtraMessageBox.Show("لا يمكن معالجة المغادرات، عدد ساعات المغادرات أقل من الحد المسموح به")
                    Exit Sub
                End If

                'If TextDayNo.EditValue > 1 Then
                '    XtraMessageBox.Show("لا يمكن عمل اجازة لاكثر من يوم", "تأكيد")
                '    Exit Sub
                'End If

                If TextDayNo.EditValue > TextVocationsBalance.EditValue Then
                    Dim Msg2 As DialogResult = XtraMessageBox.Show("رصيد الاجازات لا يكفي لمعالجة المغادرات", "تأكيد", MessageBoxButtons.YesNo)
                    If Msg2 = System.Windows.Forms.DialogResult.No Then Exit Sub
                End If



                Dim Msg As DialogResult = XtraMessageBox.Show("سيتم عمل اجازة ب ساعات المغادرات", "تأكيد", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                ' Dim report As SalaryReport
                '  report = SalaryMonthForm.DocumentViewer1.DocumentSource
                '  MemoDetails.Text = "خصم مغادرات الفترة " & report.Parameters("DateFrom").Value & " : " & report.Parameters("DateTo").Value
                '    MemoDetails.Text = "خصم مغادرات الفترة " & " " & Format(VocationDate.DateTime, "yyyy-MM-dd") & " : " & Format(VocationDate.DateTime, "yyyy-MM-dd")
                Saving()
                report.Parameters("NetSalary").Value = CDec(report.Parameters("NetSalary").Value) + CDec(report.Parameters("LeavesAmount").Value)
                report.Parameters("LeavesAmount").Value = "0"
                report.Parameters("Leaves").Value = "0"
        End Select
        report.CreateDocument(True)
        Me.Dispose()
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
            Dim SqlString As String = "   Insert Into Vocations " _
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

            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                XtraMessageBox.Show("تم حفظ السند", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally


        End Try

    End Sub


    Private Sub CalcRemainingHours()
        TextRemainingLeaves.BackColor = DefaultBackColor
        LayoutRemainingLeaves.Text = "المتبقي"
        Dim _TextRemainingLeaves As TimeSpan = TimeSpan.Zero
        Dim _TextTotalNetLeaves As TimeSpan = TextTotalNetLeaves.EditValue
        Dim _TextMaxLeavesHoures As TimeSpan = TextMaxLeavesHoures.EditValue
        Try
            If _TextTotalNetLeaves >= _TextMaxLeavesHoures Then
                _TextRemainingLeaves = _TextTotalNetLeaves - _TextMaxLeavesHoures
                TextRemainingLeaves.EditValue = _TextRemainingLeaves
                TextRemainingLeaves.BackColor = Color.Red
                LayoutRemainingLeaves.Text = "تجاوز"
                Dim _TextLeavesAmount As Decimal
                _TextLeavesAmount = (_TextRemainingLeaves.TotalHours * TextLeaveNIS_PerHour.EditValue)
                TextLeavesAmount.Text = _TextLeavesAmount.ToString("#.0")
            Else
                _TextRemainingLeaves = _TextMaxLeavesHoures - _TextTotalNetLeaves
                TextRemainingLeaves.EditValue = _TextRemainingLeaves
                TextLeavesAmount.Text = "0"
                TextLeaveNIS_PerHour.Text = "0"
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            If LayoutRemainingLeaves.Text <> "المتبقي" Then
                Dim _TextDayNo As Decimal
                _TextDayNo = (_TextRemainingLeaves.TotalHours / tempdaysLeaves.EditValue)
                TextDayNo.Text = _TextDayNo.ToString("#.00")
            Else
                TextDayNo.Text = "0"
            End If
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub TextTotalNetLeaves_EditValueChanged(sender As Object, e As EventArgs) Handles TextTotalNetLeaves.EditValueChanged
        CalcRemainingHours()
    End Sub

    Private Sub TextMaxLeavesHoures_EditValueChanged(sender As Object, e As EventArgs) Handles TextMaxLeavesHoures.EditValueChanged
        CalcRemainingHours()
    End Sub

    Private Sub AttLeavesProccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'LayouttempdaysLeaves.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        RadioGroup1.EditValue = "1"
    End Sub

    Private Sub TextLeaveNIS_PerHour_EditValueChanged(sender As Object, e As EventArgs) Handles TextLeaveNIS_PerHour.EditValueChanged
        CalcRemainingHours()
    End Sub

    Private Sub TextDayNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextDayNo.EditValueChanged
        'CalcRemainingHours()
    End Sub

    Private Sub tempdaysLeaves_EditValueChanged(sender As Object, e As EventArgs) Handles tempdaysLeaves.EditValueChanged
        CalcRemainingHours()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "1"
                LayoutFromSalary.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutFromVocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            Case "2"
                LayoutFromVocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutFromSalary.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub AttLeavesProccess_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Sub TextVocationsBalance_EditValueChanged(sender As Object, e As EventArgs) Handles TextVocationsBalance.EditValueChanged

    End Sub
End Class
