Imports DevExpress.XtraEditors

Public Class AttFromApp
    Private Sub AttFromApp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Calc()

        'TextVocationsYear.Text = 0
        'TextBalance.Text = 0
        If EmployeeID.EditValue Is Nothing Or TextTransTypeID.EditValue Is Nothing Then Exit Sub
        Dim EmpID As String = CStr(EmployeeID.EditValue)
        Dim VocID As Integer = CInt(TextTransTypeID.EditValue)
        Dim _VocationDetails = GetVocationsBalancesByEmployee(EmpID, VocID, Today())
        MemoEdit2.Text = ""
        MemoEdit2.Text = "رصيد الاجازات : " & _VocationDetails.Balance & "" & Environment.NewLine
        MemoEdit2.Text += "رصيد الاجازات المستحقة لتاريخ اليوم: " & _VocationDetails.AccruedVocations & "" & Environment.NewLine
    End Sub

    Private Sub TextEdit6_EditValueChanged(sender As Object, e As EventArgs)
        Calc()
    End Sub

    Private Sub VocationType_EditValueChanged(sender As Object, e As EventArgs) Handles TransType.EditValueChanged
        Calc()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim _DocID As Integer = Me.DocID.Text
        If MemoEdit3.Text = "" Then XtraMessageBox.Show("يجب تعبئة ملاحظات الادارة") : Exit Sub
        If XtraMessageBox.Show("سيتم اعتماد حركة الدوام، هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Try
                Dim Sql As New SQLControl
                Dim SqlString As String = " DECLARE @DocID int;
                                            SET @DocID=" & _DocID & ";
                                            INSERT INTO [dbo].[AttCHECKINOUT] ([USERID], [CHECKTIME], [CHECKTYPE], [SENSORID], [Location], [Latitude], [Longitude],[EditNote])
                                            SELECT [USERID],
                                                   [CHECKTIME],
                                                   [CHECKTYPE],
                                                   [SENSORID],
                                                   [Location],
                                                   [Latitude],
                                                   [Longitude],N'" & MemoEdit3.Text & "'
                                            FROM AttCHECKINOUTPending
                                            WHERE ID=@DocID;
                                            UPDATE [dbo].[AttCHECKINOUTPending]
                                            SET [TransStatus]=1,
                                                [NoteFromManager]=N'" & MemoEdit3.Text & "'
                                            WHERE ID=@DocID "
                If Sql.SqlTrueTimeRunQuery(SqlString) = True Then
                    XtraMessageBox.Show("تم اعتماد الطلب")
                    Me.Close()
                Else
                    MsgBoxShowError(" خطا ")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim _DocID As Integer = Me.DocID.Text
        If MemoEdit3.Text = "" Then XtraMessageBox.Show("يجب تعبئة ملاحظات الادارة") : Exit Sub
        Try
            If XtraMessageBox.Show("سيتم رفض طلب حركة الدوام، هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Dim Sql As New SQLControl
                Dim SqlString As String = " Update [dbo].[AttCHECKINOUTPending] Set [TransStatus] = -1 , 
                                                                            NoteFromManager = N'" & Me.MemoEdit3.Text & "' 
                                                                            Where [ID]= " & _DocID
                If Sql.SqlTrueTimeRunQuery(SqlString) = True Then XtraMessageBox.Show("تم رفض الحركة") : Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub LongitudeAndLatitude_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles LongitudeAndLatitude.ButtonClick
        Dim f As New AttGetMap
        With f
            .teLatitude.Text = Me.Latitude.Text
            .teLongitude.Text = Me.Longitude.Text
            .ShowDialog()
            '   .GetData()
        End With
    End Sub

    Private Sub LongitudeAndLatitude_EditValueChanged(sender As Object, e As EventArgs) Handles LongitudeAndLatitude.EditValueChanged

    End Sub
End Class