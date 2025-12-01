Imports DevExpress.XtraEditors


Public Class VocationFromApp
    Private Sub VocationFromApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Calc()

        'TextVocationsYear.Text = 0
        'TextBalance.Text = 0
        If EmployeeID.EditValue Is Nothing Or VocationID.EditValue Is Nothing Then Exit Sub
        Dim EmpID As String = CStr(EmployeeID.EditValue)
        Dim VocID As Integer = CInt(VocationID.EditValue)
        ' If LookUpEditVocations.Text = "سنوية" Then TextLimitVocations.Text = GetLimitVocations() Else TextLimitVocations.Text = 0
        '  TextVocationsYear.Text = GetSumVocationsThisYear()
        Dim _VocationDetails = GetVocationsBalancesByEmployee(EmpID, VocID, Today())
        'TextBalance.Text = _VocationData.Item1
        'TextVocationsYear.Text = _VocationData.Item2
        'TextBeginigBalance.Text = _VocationData.Item4
        'TextAdditions.Text = _VocationData.Item3
        'TextVocationsRemaining.Text = _VocationData.Item5
        MemoEdit2.Text = ""
        MemoEdit2.Text = "رصيد الاجازات : " & _VocationDetails.Balance & "" & Environment.NewLine
        MemoEdit2.Text += "رصيد الاجازات المستحقة لتاريخ اليوم: " & _VocationDetails.AccruedVocations & "" & Environment.NewLine
    End Sub

    Private Sub TextEdit6_EditValueChanged(sender As Object, e As EventArgs) Handles VocationID.EditValueChanged
        Calc()
    End Sub

    Private Sub VocationType_EditValueChanged(sender As Object, e As EventArgs) Handles VocationType.EditValueChanged
        Calc()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _VocID As Integer = Me.DocID.Text
        If MemoEdit3.Text = "" Then XtraMessageBox.Show("يجب تعبئة ملاحظات الادارة") : Exit Sub
        If XtraMessageBox.Show("سيتم اعتماد طلب الاجازة، هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Try
                Dim Sql As New SQLControl
                'Dim SqlString As String = " Insert Into [dbo].[Vocations] ([VocDate] ,[EmployeeID] ,[VocationType]
                '                                                          ,[FromDate] ,[ToDate] ,[NoDays] ,[NoteDetails] ,[BatchNo]) 
                '                                                           Select  [VocDate] ,[EmployeeID] ,[VocationType]
                '                                                          ,[FromDate] ,[ToDate] ,[NoDays] ,N'" & Me.MemoEdit3.Text & "' ,[BatchNo]
                '                                                           FROM [dbo].[VocationsPending] Where [VocID]= " & _VocID & ";
                '                                                           Update [dbo].[VocationsPending] Set [DocStatus] = 1,[NoteFromManager]=N'" & MemoEdit3.Text & "' Where [VocID]= " & _VocID

                Dim SqlString As String = "INSERT INTO [dbo].[Vocations] ([VocDate], [EmployeeID], [VocationType] , [FromDate], [ToDate], [NoDays], [NoteDetails], [BatchNo])
                                                            SELECT [VocDate],
                                                                   [EmployeeID],
                                                                   [VocationType] ,
                                                                   [FromDate],
                                                                   [ToDate],
                                                                   [NoDays],
                                                                   N'" & Me.MemoEdit3.Text & "',
                                                                   [BatchNo]
                                                            FROM [dbo].[VocationsPending]
                                                            WHERE [VocID]= " & _VocID & ";
                                                            UPDATE [dbo].[VocationsPending]
                                                            SET [DocStatus] = 1,
                                                                [NoteFromManager]=N'" & MemoEdit3.Text & "'
                                                            WHERE [VocID]= " & _VocID
                If Sql.SqlTrueTimeRunQuery(SqlString) = True Then
                    XtraMessageBox.Show("تم اعتماد الطلب")
                    Me.Close()
                Else
                    XtraMessageBox.Show("خطا: الرجاء مراجعة البيانات")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim _VocID As Integer = Me.DocID.Text
        If MemoEdit3.Text = "" Then XtraMessageBox.Show("يجب تعبئة ملاحظات الادارة") : Exit Sub
        Try
            If XtraMessageBox.Show("سيتم رفض طلب الاجازة، هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Dim Sql As New SQLControl
                Dim SqlString As String = " Update [dbo].[VocationsPending] Set [DocStatus] = -1 , 
                                                                            NoteFromManager = N'" & Me.MemoEdit3.Text & "' 
                                                                            Where [VocID]= " & _VocID
                If Sql.SqlTrueTimeRunQuery(SqlString) = True Then XtraMessageBox.Show("تم رفض الطلب") : Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class