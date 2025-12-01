Imports DevExpress.XtraEditors

Public Class SmsSendSingle
    Private Sub SmsSendSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Referance.Properties.DataSource = GetReferences(-1, -1, -1)
        'AccrualDateTime.DateTime = Now
    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        Try
            If Referance.EditValue <> 0 Then
                Dim RefData = GetRefranceData(Referance.EditValue)
                RefName.Text = RefData.RefName
                RefMobile.Text = RefData.RefMobile
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        TextSMSResult.Text = ""
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _RefNo As Integer
        Dim _RefName, _RefMobile, _SmsDetails, _AccrualDate, SmsStatus As String
        _RefNo = Referance.EditValue
        If String.IsNullOrEmpty(_RefNo) Then _RefNo = "0"
        _RefName = RefName.EditValue
        _RefMobile = RefMobile.EditValue
        _SmsDetails = SMSDetails.Text
        _AccrualDate = Format(Now, "yyyy-MM-dd HH:mm")
        'If String.IsNullOrEmpty(_AccrualDate) Then
        '    XtraMessageBox.Show("التاريخ فارغ")
        '    Exit Sub
        'End If
        If String.IsNullOrEmpty(_RefMobile) Then
            XtraMessageBox.Show("رقم الموبايل فارغ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(_SmsDetails) Then
            XtraMessageBox.Show("نص الرسالة فارغ")
            Exit Sub
        End If

        Dim _SuccessString As String
        Try
            sqlstring = "select SettingValue  from Settings where SettingName='SmsSuccessString'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _SuccessString = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _SuccessString = ""
        End Try

        SmsStatus = SendSMSMessage(_RefMobile, _SmsDetails, CStr(RadioGroupSendType.EditValue), False, _RefName)
        If SmsStatus = _SuccessString Then SmsStatus = "Success"

        If SmsStatus = "Success" Then
            TextSMSResult.Text = " تم ارسال الرسالة بنجاح "
        End If


        TextSMSResult.Text += " الرصيد: " + GetSMSBalance()

        sqlstring = " Insert into SmsPendingMessages (SMSType,SMSDetails,SMSDatetime,SMSUser,SMSStatus,
                                                      BulkNo,RefNo,RefMobile,RefName,AccrualDateTime,Sent,
                                                      DocName,DocID,DocCode,DocData) 
                                                      Values (" & -1 & ",
                                                      N'" & _SmsDetails & "',GetDate(),
                                                      '" & GlobalVariables.CurrUser & "',
                                                      'Pending',
                                                      0,
                                                      '" & _RefNo & "','" & _RefMobile & "',N'" & _RefName & "','" & _AccrualDate & "',0,'0','0','0','0') "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            '  Me.Close()
        End If
    End Sub
End Class