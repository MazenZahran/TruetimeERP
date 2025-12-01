Imports DevExpress.XtraEditors

Public Class SavePrintPostDocument
    Public DocAmount As Decimal
    Public DocName As Integer
    Public DocID As Integer
    Public Referance As Integer
    Public VoucherCode As String


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If PostDocument(Me.TextDocCode.Text, TextDocData.Text) = True Then
            PrintDoc(True, TextDocCode.Text, TextDocData.Text, True, False)

            Me.Dispose()
        Else
            MsgBox("error")
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If PostDocument(Me.TextDocCode.Text, TextDocData.Text) = True Then
            Me.Dispose()
        Else
            MsgBox("error")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PrintDoc(False, TextDocCode.Text, TextDocData.Text, False, False)
        Me.Dispose()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Close()
    End Sub

    Private Sub SavePrintPostDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleButton5.Select()
        If GlobalVariables._Shalash = True Then
            LayoutBtnSendToGroupWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        If GlobalVariables._SendSmsFromDocuments = False Then
            LayoutControlSendSMS.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        GetSettings()
        Me.KeyPreview = True
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim sqlstring As String

        sqlstring = " select SettingValue from Settings where SettingName='ShowPostButtonsInSavePrintPostDocument' "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
            LayoutControlItemPostAndPrint.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemPost.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
    End Sub
    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        SendSMS()
    End Sub
    Private Sub SendSMS()
        Dim _DocData = GetDocDataByDocCode(Me.TextDocCode.Text, "Journal")
        Dim _RefName As String = ""
        Dim _RefNo As Integer = 0
        Dim _DocAmount As Integer = 0
        Dim _DocCurrency As String
        Dim _DocName As Integer
        Dim _DocDate As String
        Dim _DocID As Integer
        _DocName = _DocData.DocName
        _RefName = _DocData.ReferanceName
        _RefNo = _DocData.Referance
        _DocAmount = _DocData.DocAmount
        _DocCurrency = _DocData.DocCurrencyName
        _DocDate = Format(_DocData.DocDate, "yyyy-MM-dd")
        _DocID = _DocData.DocID
        If _RefNo = 0 Then Exit Sub
        Try
            If _RefNo = 0 Then
                XtraMessageBox.Show("لا يوجد اسم ")
                Exit Sub
            End If
            Dim _RefData = GetRefranceData(_RefNo)
            Dim _RefMobile As String = ""
            _RefMobile = _RefData.RefMobile
            Dim _RefBalance As Decimal = GetReferanceBalance(_RefNo)
            _SMSMessagesTempTable.Clear()
            CeateMessagesTempTable()
            Dim sql As New SQLControl
            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try


            Dim _OrigionalSMSMessage, _SMSMessage As String

            Select Case _DocName
                Case 2
                    sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=4")
                    _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")
                    If Not String.IsNullOrEmpty(_RefNo) Then
                        _SMSMessage = _OrigionalSMSMessage
                        _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                        _SMSMessage = _SMSMessage.Replace("#DocAmount#", _DocAmount)
                        _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                        _SMSMessage = _SMSMessage.Replace("#DocCurrency#", _DocCurrency)
                        _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)
                        Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                        dr("SMSType") = 3
                        dr("SMSDetails") = _SMSMessage
                        dr("RefNo") = _RefNo
                        dr("RefMobile") = _RefMobile
                        dr("RefName") = _RefName
                        dr("AccrualDateTime") = _DocDate
                        dr("Sent") = 0
                        dr("DocName") = _DocName
                        dr("DocID") = _DocID
                        dr("DocCode") = Me.TextDocCode.Text
                        dr("DocData") = _DocData
                        dr("Sent") = 0
                        dr("SmsID") = 0
                        dr("SMSStatus") = ""
                        If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                        _SMSMessagesTempTable.Rows.Add(dr)
                    End If
                Case 4
                    sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=3")
                    _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")
                    If Not String.IsNullOrEmpty(_RefNo) Then
                        _SMSMessage = _OrigionalSMSMessage
                        _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                        _SMSMessage = _SMSMessage.Replace("#DocAmount#", _DocAmount)
                        _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                        _SMSMessage = _SMSMessage.Replace("#DocCurrency#", _DocCurrency)
                        _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)
                        Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                        dr("SMSType") = 3
                        dr("SMSDetails") = _SMSMessage
                        dr("RefNo") = _RefNo
                        dr("RefMobile") = _RefMobile
                        dr("RefName") = _RefName
                        dr("AccrualDateTime") = _DocDate
                        dr("Sent") = 0
                        dr("DocName") = _DocName
                        dr("DocID") = _DocID
                        dr("DocCode") = Me.TextDocCode.Text
                        dr("DocData") = _DocData
                        dr("Sent") = 0
                        dr("SmsID") = 0
                        dr("SMSStatus") = ""
                        If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                        _SMSMessagesTempTable.Rows.Add(dr)
                    End If
            End Select



            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                Me.Close()
                .ShowDialog()
            End With

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        PaidVouchers()
    End Sub
    Private Sub PaidVouchers()
        Me.Close()
        Dim _DocData = GetDocDataByDocCode(Me.TextDocCode.Text, "Journal")
        Dim f As New PaidVouchers
        With f
            .txtDocName.Text = _DocData.DocName
            .txtPaidByDocNo.Text = _DocData.DocID
            .LookReferences.EditValue = _DocData.Referance
            .txtDocAmount.EditValue = _DocData.BaseAmount
            .ShowDialog()
        End With
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        PrintDoc(False, TextDocCode.Text, TextDocData.Text, True, False)
        Me.Dispose()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        SendPDFtoReferance()
    End Sub
    Private Sub SendPDFtoReferance()
        PrintDoc(False, TextDocCode.Text, TextDocData.Text, False, True)
        Dim _DocData = GetDocDataByDocCode(Me.TextDocCode.Text, TextDocData.Text)
        Dim _DocNameText As String = GetDocNameTextByDocNameID(_DocData.DocName)
        Dim MobileNo As String = GetRefranceData(_DocData.Referance).RefMobile
        If String.IsNullOrEmpty(MobileNo) Or MobileNo = "0" Or Len(MobileNo) < 8 Then
            MsgBoxShowError(" لا يوجد رقم موبايل " & " ( " & _DocData.ReferanceName & " ) ")
        Else
            SendFileToWhatsApp(MobileNo, "Document.pdf", _DocNameText, _DocNameText & ": " & _DocData.DocID & "-" & _DocData.ReferanceName, _DocData.ReferanceName)
        End If
        Me.Dispose()
    End Sub
    Private Sub SendPDFtoGroup()
        'PrintDoc(False, TextDocCode.Text, TextDocData.Text, False, True)
        Dim _DocData = GetDocDataByDocCode(Me.TextDocCode.Text, TextDocData.Text)
        Dim _DocNameText As String = GetDocNameTextByDocNameID(_DocData.DocName)
        PrintDoc(False, TextDocCode.Text, "Journal", False, True)
        'SendFileToWhatsAppGroup(CStr("120363418766138503"), "Document.pdf", 1, _DocNameText & ":" & "-" & _DocData.ReferanceName)
        SendFileToWhatsApp(CStr("120363418766138503"), "Document.pdf", 1, _DocNameText & ":" & "-" & _DocData.ReferanceName, "")
        Me.Dispose()
    End Sub
    Private Sub BtnIssueReceiptOrPayment_Click(sender As Object, e As EventArgs) Handles BtnIssueReceiptOrPayment.Click
        IssueMoneyTransDocument()
    End Sub
    Private Sub IssueMoneyTransDocument()
        Dim F As New MoneyTrans
        If DocName = 1 Then
            With F
                CreateNewDocument(3, Referance, DocAmount, "  ", True)
            End With
        End If
        If DocName = 2 Then
            With F
                CreateNewDocument(4, Referance, DocAmount, " ", True)
            End With
        End If
    End Sub
    Private Sub SavePrintPostDocument_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.D0 Or e.KeyCode = Keys.NumPad0 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.D1 Or e.KeyCode = Keys.NumPad1 Then
            Me.Close()
        ElseIf e.KeyCode = Keys.D2 Or e.KeyCode = Keys.NumPad2 Then
            PrintDoc(False, TextDocCode.Text, TextDocData.Text, False, False)
            Me.Dispose()
        ElseIf e.KeyCode = Keys.D3 Or e.KeyCode = Keys.NumPad3 Then
            PrintDoc(False, TextDocCode.Text, TextDocData.Text, True, False)
            Me.Dispose()
        ElseIf e.KeyCode = Keys.D4 Or e.KeyCode = Keys.NumPad4 Then
            If PostDocument(Me.TextDocCode.Text, TextDocData.Text) = True Then
                Me.Dispose()
            Else
                MsgBox("error")
            End If
        ElseIf e.KeyCode = Keys.D5 Or e.KeyCode = Keys.NumPad5 Then
            If PostDocument(Me.TextDocCode.Text, TextDocData.Text) = True Then
                PrintDoc(True, TextDocCode.Text, TextDocData.Text, True, False)

                Me.Dispose()
            Else
                MsgBox("error")
            End If
        ElseIf e.KeyCode = Keys.D6 Or e.KeyCode = Keys.NumPad6 Then
            SendSMS()
        ElseIf e.KeyCode = Keys.D7 Or e.KeyCode = Keys.NumPad7 Then
            SendPDFtoReferance()
        ElseIf e.KeyCode = Keys.D8 Or e.KeyCode = Keys.NumPad8 Then
            PaidVouchers()
        ElseIf e.KeyCode = Keys.D9 Or e.KeyCode = Keys.NumPad9 Then
            IssueMoneyTransDocument()
        End If
    End Sub

    Private Sub BtnPrintVoucher_Click(sender As Object, e As EventArgs) Handles BtnPrintVoucher.Click
        PrintDoc(False, TextDocCode.Text, "Journal", False, False)
        Me.Close()
    End Sub

    Private Sub BtnSendToGroupWhatsApp_Click(sender As Object, e As EventArgs) Handles BtnSendToGroupWhatsApp.Click
        'Dim _DocCode As String
        '_DocCode = Me.TextDocCode.Text
        'PrintPosVoucherFromDataBase(_DocCode, True)

        SendPDFtoGroup()

    End Sub
End Class