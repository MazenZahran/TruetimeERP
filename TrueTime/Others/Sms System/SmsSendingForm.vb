Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class SmsSendingForm
    Private _SendFromWhatsApp As Boolean

    Private Sub SmsSendingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RepositoryActions.DataSource = _SmsActionsTable()
        GridView1.BestFitColumns()
        GridView1.FormatRules.Item(0).Enabled = False
        GridView1.FormatRules.Item(1).Enabled = False
        Me.TextBalanceBeforeSend.Text = GetSMSBalance()
        GetSettings()
        If _SendFromWhatsApp = True Then
            RadioGroupSendType.EditValue = "WhatsApp"
        End If
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub
    Private Sub GetSettings()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select SettingValue from settings where SettingName='DefaultMethodToSendMessagesIsWhatsApp' "

            sql.SqlTrueTimeRunQuery(sqlstring)
            _SendFromWhatsApp = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _SendFromWhatsApp = True
        End Try

    End Sub
    Public Sub GetUnsentMessages(BulkNo As Integer)
        'Dim sql As New SQLControl
        'Dim sqlstring As String
        'sqlstring = " SELECT [ID]      ,[SMSType]
        '                  ,[SMSDetails]      ,[SMSDatetime]
        '                  ,[SMSUser]      ,[SMSStatus]
        '                  ,[BulkNo]      ,[RefNo]
        '                  ,[RefMobile]      ,[RefName]
        '                  ,[AccrualDateTime]      ,[Sent]
        '              FROM [dbo].[SmsSentMessages]
        '             where Sent =0 and BulkNo= " & BulkNo
        'sql.SqlTrueAccountingRunQuery(sqlstring)
        'GridControl1.DataSource = sql.SQLDS.Tables(0)

        'Dim view As ColumnView = CType(GridControl1.MainView, ColumnView)
        'Dim ColSelectedSerial As GridColumn = view.Columns("SelectedSerial")
        'If ColSelectedSerial Is Nothing Then Return
        'view.OptionsSelection.MultiSelect = True
        'view.ClearSelection()
        'Dim rowHandle As Integer = -1
        'While rowHandle <> GridControl.InvalidRowHandle
        '    '   rowHandle = view.LocateByValue("",)
        '    'rowHandle = view.LocateByValue(rowHandle + 1, ColSelectedSerial, Nothing)
        '    view.SelectRow(rowHandle)
        'End While
        If _SMSMessagesTempTable.Rows.Count > 0 Then
            GridControl1.DataSource = _SMSMessagesTempTable
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButtonSendSms.Click
        '   Dim _smsType As Integer

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.RowCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            'If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.RowCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            '    Exit Sub
            'End If




            Dim sql As New SQLControl


            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")

            GridView1.FormatRules.Item(0).Enabled = True
            GridView1.FormatRules.Item(1).Enabled = True

            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try

            Dim _SuccessString As String
            Try
                Dim sqlstring As String
                sqlstring = "select SettingValue  from Settings where SettingName='SmsSuccessString'"
                sql.SqlTrueAccountingRunQuery(sqlstring)
                _SuccessString = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Catch ex As Exception
                _SuccessString = ""
            End Try

            Dim J, S, P, Er As Integer
            J = 1 : S = 0 : P = 0 : Er = 0
            Dim _ReferanceNo As String
            Dim _RefMobile, _RefName, _SMSDetails, SmsStatus, _DocCode, _DocData As String
            Dim _DocDate As String
            Dim _Action, _DocName, _DocID, _SMSType, _SmsID As Integer
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    '  If GridView1.GetRowCellValue(i, "") = 1 Then
                    _ReferanceNo = .GetRowCellValue(i, "RefNo")
                    '   If Not String.IsNullOrEmpty(_RefMobile) Then
                    '   Dim _RefData = GetRefranceData(_ReferanceNo)
                    _RefMobile = .GetRowCellValue(i, "RefMobile")
                    If _RefMobile Is Nothing OrElse String.IsNullOrEmpty(_RefMobile) Or Len(_RefMobile) < 9 Then
                        Continue For
                    End If
                    _RefName = .GetRowCellValue(i, "RefName")
                    _DocDate = Format(CDate(.GetRowCellValue(i, "AccrualDateTime")), "yyyy-MM-dd")
                    _Action = .GetRowCellValue(i, "Action")
                    _SMSDetails = .GetRowCellValue(i, "SMSDetails")
                    _DocName = .GetRowCellValue(i, "DocName")
                    _DocID = .GetRowCellValue(i, "DocID")
                    _DocCode = .GetRowCellValue(i, "DocCode")
                    _DocData = .GetRowCellValue(i, "DocData")
                    _SMSType = .GetRowCellValue(i, "SMSType")
                    _SmsID = .GetRowCellValue(i, "SmsID")
                    If _Action = 1 Then
                        SmsStatus = SendSMSMessage(_RefMobile, _SMSDetails, CStr(RadioGroupSendType.EditValue), False, _RefName)
                        Me.BarResponse.Caption = SmsStatus
                        If SmsStatus = _SuccessString Then SmsStatus = "Success"
                        GridView1.SetRowCellValue(i, "SMSStatus", SmsStatus)
                        'SMSSendMessageToTable(_SMSType, _SMSDetails, SmsStatus, _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate, 1, _DocName, _DocID, _DocCode, "Journal")
                        CreateDocLog("Document", _DocCode, _DocName, _DocID, "SendSms", "Send SMS: " & _SMSDetails, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                        If SmsStatus = "Success" Then
                            sql.SqlTrueAccountingRunQuery(" Delete from SmsPendingMessages where ID=" & _SmsID)
                            S = S + 1
                        Else
                            Er = Er + 1
                        End If
                    Else
                        If _SmsID = 0 Then
                            GridView1.SetRowCellValue(i, "SMSStatus", "Pending")
                            SMSSendMessageToTable(_SMSType, _SMSDetails, "Pending", _BulkNo, _ReferanceNo, _RefMobile, _RefName, _DocDate, 0, _DocName, _DocID, _DocCode, _DocData)
                        End If
                        P = P + 1
                    End If
                    J = J + 1
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.RowCount)) & "%" &
                                                                          " " & J & " From " & GridView1.RowCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            'Dim _String As String = String.Format("تم ارسال مسجات عدد {0} بنجاح " + Environment.NewLine + " تم تعليق مسجات عدد {1} بنجاح" + Environment.NewLine + " مسجات عدد {2} لم يتم ارسالها ", S, P, Er)
            'XtraMessageBox.Show(_String)
            SimpleButtonSendSms.Enabled = False
            Me.TextBalanceAfterSend.Text = GetSMSBalance()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            'XtraMessageBox.Show(ex.ToString)
        End Try
        GridView1.BestFitColumns()
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        If XtraMessageBox.Show(" هل تريد الغاء ارسال الرسالة الى ?" & " : " & GridView1.GetFocusedRowCellValue("RefName") & "  ", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
        End If

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Dispose()
    End Sub
End Class