Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraPrinting

Public Class PosDirectReceipt
    Public _CostCenter As Integer
    Public _ShiftID As Integer
    Public _PosName As Integer
    Public _DefaultCashAccount As String
    Public _InputUser As Integer
    Public _SubscriptionID As Integer
    Public _RequiredAmount As Decimal
    Private _PrintPosReceiptSize As String
    Public _TotalDebit As Decimal
    Public _InstallmentID As Integer


    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup

    End Sub

    Private Sub PosDirectReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Referance.Properties.DataSource = GetReferences(1, -1, -1)
        'Me.MemoEdit1.Text = " نقدا من نقطة البيع، وذلك من شفت رقم  " & Me._ShiftID & " للموظف: " & Me._InputUser
        Me.Referance.Select()
        Me.SearchCashAccount.Properties.DataSource = CreatePosPaidOptions()
        SearchCashAccount.EditValue = _DefaultCashAccount
        RadioAmountType.EditValue = "Cash"
        GetSettings()
        SwitchKeyboardLayout("ar")
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim sqlString As String
        Try
            sqlString = " Select IsNull([PaperSize],'80*80') as PaperSize from AccountingPOSNames where ID=" & _PosName
            sql.SqlTrueAccountingRunQuery(sqlString)
            _PrintPosReceiptSize = sql.SQLDS.Tables(0).Rows(0).Item("PaperSize")
        Catch ex As Exception
            _PrintPosReceiptSize = "80*80"
        End Try

        Try
            sqlString = " Select IsNull(DefaultStatusForPrintReceipt,1) as DefaultStatusForPrintReceipt,
                                 IsNull(DefaultStatusForSendReceiptByWhatsApp,1) as DefaultStatusForSendReceiptByWhatsApp 
                          From AccountingPOSNames where ID=" & _PosName
            sql.SqlTrueAccountingRunQuery(sqlString)
            CheckPrint.Checked = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DefaultStatusForPrintReceipt"))
            CheckSendSMS.Checked = CBool(sql.SQLDS.Tables(0).Rows(0).Item("DefaultStatusForSendReceiptByWhatsApp"))
        Catch ex As Exception
            CheckPrint.Checked = True
            CheckSendSMS.Checked = True
        End Try

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DirectReceipt() = True Then
            Me.Dispose()
        Else
            MsgBoxShowError(" خطأ، يرجى مراجعة بيانات الادخال ")
        End If
    End Sub
    Private Function DirectReceipt() As Boolean
        Dim _result As Boolean
        _result = False

        If Me.SearchCashAccount.Text = "" Then
            Return _result
            Exit Function
        End If
        If Me.TextAmount.EditValue = 0 Then
            MsgBoxShowError(" يجب ادخال المبلغ  ")
            Return _result
            Exit Function
        End If
        If Me.Referance.Text = "" Then
            MsgBoxShowError(" يجب اختيار الزبون ")
            Return _result
            Exit Function
        End If

        Dim _PosPostVouchers As Boolean = True
        Dim _DocStatus As Integer = 3
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPostVouchers'")
            _PosPostVouchers = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _PosPostVouchers = True
        End Try

        If _PosPostVouchers = True Then _DocStatus = 3 Else _DocStatus = 1

        Dim _DocID As Integer = GetDocNo(4, False)
        Dim query As String = String.Empty
        Dim _DocDate As String = Format(Today, "yyyy-MM-dd")
        Dim _DocInputDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim _DocCode As String = CreateRandomCode()
        Dim _DebitResult, _CreditResult, _PosVoucherReslut As Boolean
        If MemoEdit1.Text = "" Then MemoEdit1.Text = " "
        query = "INSERT INTO [dbo].[Journal] ("
        query &= "            [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc], "
        query &= "            [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount], "
        query &= "            [BaseAmount],[DocSort],[Referance],[DocManualNo],[DocMultiCurrency],[InputUser],[InputDateTime],[DocNotes],[ReferanceName],[CheckCode],[DocCode],[CheckNo])
                              OUTPUT Inserted.DocID "
        query &= "VALUES ( " & _DocID & ", @DocDate, @DocName,@DocStatus,@DocCostCenter,@DebitAcc,@CredAcc, "
        query &= "         @AccountCurr,@DocCurrency,@DocAmount,@ExchangePrice,@BaseCurrAmount,@BaseAmount,@DocSort,@Referance,"
        query &= "         @DocManualNo,@DocMultiCurrency,@InputUser,@InputDateTime,@DocNotes,@ReferanceName,@CheckCode,@DocCode,@CheckNo)"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@DocDate", _DocDate)
                    .Parameters.AddWithValue("@DocName", 4)
                    .Parameters.AddWithValue("@DocStatus", _DocStatus)
                    .Parameters.AddWithValue("@DocCostCenter", _CostCenter)
                    .Parameters.AddWithValue("@DebitAcc", SearchCashAccount.EditValue)
                    .Parameters.AddWithValue("@CredAcc", "0")
                    .Parameters.AddWithValue("@AccountCurr", "1")
                    .Parameters.AddWithValue("@DocCurrency", "1")
                    .Parameters.AddWithValue("@DocAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@ExchangePrice", "1")
                    .Parameters.AddWithValue("@BaseCurrAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@BaseAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@DocSort", "1")
                    .Parameters.AddWithValue("@Referance", Referance.EditValue)
                    .Parameters.AddWithValue("@DocManualNo", "0")
                    .Parameters.AddWithValue("@DocMultiCurrency", "0")
                    .Parameters.AddWithValue("@InputUser", _InputUser)
                    .Parameters.AddWithValue("@InputDateTime", _DocInputDateTime)
                    .Parameters.AddWithValue("@DocNotes", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@ReferanceName", Me.Referance.Text)
                    .Parameters.AddWithValue("@CheckCode", "0")
                    .Parameters.AddWithValue("@DocCode", _DocCode)
                    .Parameters.AddWithValue("@CheckNo", "0")
                End With
                Try
                    conn.Open()
                    _DocID = comm.ExecuteScalar()
                    If _DocID > 0 Then
                        _DebitResult = True
                    Else
                        _DebitResult = False
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    _DebitResult = False
                End Try
            End Using
        End Using


        If _DebitResult = False Then
            MsgBoxShowError(" خطا، لم يتم ادخال سند القبض ")
        End If
        Dim _RefData = GetRefranceData(Me.Referance.EditValue)
        Dim _RefAccount As String = _RefData.RefAccID

        query = "INSERT INTO [dbo].[Journal] ("
        query &= "            [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc], "
        query &= "            [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount], "
        query &= "            [BaseAmount],[DocSort],[Referance],[DocManualNo],[DocMultiCurrency],[InputUser],[InputDateTime],[DocNotes],[ReferanceName],[CheckCode],[DocCode],[CheckNo])
                              OUTPUT Inserted.DocID  "
        query &= "VALUES ( @DocID, @DocDate, @DocName,@DocStatus,@DocCostCenter,@DebitAcc,@CredAcc, "
        query &= "         @AccountCurr,@DocCurrency,@DocAmount,@ExchangePrice,@BaseCurrAmount,@BaseAmount,@DocSort,@Referance,"
        query &= "         @DocManualNo,@DocMultiCurrency,@InputUser,@InputDateTime,@DocNotes,@ReferanceName,@CheckCode,@DocCode,@CheckNo)"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@DocID", _DocID)
                    .Parameters.AddWithValue("@DocDate", _DocDate)
                    .Parameters.AddWithValue("@DocName", 4)
                    .Parameters.AddWithValue("@DocStatus", _DocStatus)
                    .Parameters.AddWithValue("@DocCostCenter", _CostCenter)
                    .Parameters.AddWithValue("@DebitAcc", "0")
                    .Parameters.AddWithValue("@CredAcc", _RefAccount)
                    .Parameters.AddWithValue("@AccountCurr", "1")
                    .Parameters.AddWithValue("@DocCurrency", "1")
                    .Parameters.AddWithValue("@DocAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@ExchangePrice", "1")
                    .Parameters.AddWithValue("@BaseCurrAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@BaseAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@DocSort", "1")
                    .Parameters.AddWithValue("@Referance", Referance.EditValue)
                    .Parameters.AddWithValue("@DocManualNo", "0")
                    .Parameters.AddWithValue("@DocMultiCurrency", "0")
                    .Parameters.AddWithValue("@InputUser", _InputUser)
                    .Parameters.AddWithValue("@InputDateTime", _DocInputDateTime)
                    .Parameters.AddWithValue("@DocNotes", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@ReferanceName", Me.Referance.Text)
                    .Parameters.AddWithValue("@CheckCode", "0")
                    .Parameters.AddWithValue("@DocCode", _DocCode)
                    .Parameters.AddWithValue("@CheckNo", "0")
                End With
                Try
                    conn.Open()
                    _DocID = comm.ExecuteScalar()
                    If _DocID > 0 Then
                        _CreditResult = True
                    Else
                        _CreditResult = False
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    _CreditResult = False
                End Try

            End Using
        End Using



        ' Insert Pos-Voucher Record
        query = "INSERT INTO [dbo].[PosVouchers] ("
        query &= "            [VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherPC],[VoucherAmountAfterDiscount],[UserNo], "
        query &= "            [VoucherCode],[VoucherDebit],[VoucherCredit],[VoucherPayType],[VoucherReferanceName], "
        query &= "            [VoucherReferance],[PayCardName],[VoucherNote],[PosNo],[ShiftID],[DocName],[VoucherDiscount2],[VoucherCounter],[PaidAmount],[ReturnAmount])
                              OUTPUT Inserted.VoucherID  "
        query &= "VALUES ( @VoucherID, @VoucherDateTime, @VoucherAmount,@VoucherDiscount,@VoucherPC,@VoucherAmountAfterDiscount,@UserNo, "
        query &= "         @VoucherCode,@VoucherDebit,@VoucherCredit,@VoucherPayType,@VoucherReferanceName,@VoucherReferance,@PayCardName,@VoucherNote,"
        query &= "         @PosNo,@ShiftID,@DocName,@VoucherDiscount2,@VoucherCounter,@PaidAmount,@ReturnAmount)"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@VoucherID", _DocID)
                    .Parameters.AddWithValue("@VoucherDateTime", _DocInputDateTime)
                    .Parameters.AddWithValue("@VoucherAmount", Me.TextAmount.EditValue)
                    .Parameters.AddWithValue("@VoucherDiscount", 0)
                    .Parameters.AddWithValue("@VoucherPC", GlobalVariables.CurrDevice)
                    .Parameters.AddWithValue("@VoucherAmountAfterDiscount", Me.TextAmount.EditValue)
                    .Parameters.AddWithValue("@UserNo", _InputUser)
                    .Parameters.AddWithValue("@VoucherCode", _DocCode)
                    .Parameters.AddWithValue("@VoucherDebit", Me.SearchCashAccount.EditValue)
                    .Parameters.AddWithValue("@VoucherCredit", "0")
                    .Parameters.AddWithValue("@VoucherPayType", CStr(RadioAmountType.EditValue))
                    .Parameters.AddWithValue("@VoucherReferanceName", Me.Referance.Text)
                    .Parameters.AddWithValue("@VoucherReferance", Me.Referance.EditValue)
                    .Parameters.AddWithValue("@PayCardName", "0")
                    .Parameters.AddWithValue("@VoucherNote", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@PosNo", Me._PosName)
                    .Parameters.AddWithValue("@ShiftID", Me._ShiftID)
                    .Parameters.AddWithValue("@DocName", 4)
                    .Parameters.AddWithValue("@VoucherDiscount2", "0")
                    .Parameters.AddWithValue("@VoucherCounter", _DocID)
                    .Parameters.AddWithValue("@PaidAmount", "0")
                    .Parameters.AddWithValue("@ReturnAmount", "0")
                End With
                Try
                    conn.Open()
                    _DocID = comm.ExecuteScalar()
                    If _DocID > 0 Then
                        _PosVoucherReslut = True
                    Else
                        _PosVoucherReslut = False
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString(), "Error Message")
                    _PosVoucherReslut = False
                End Try

            End Using
        End Using

        If _DebitResult = True And _CreditResult = True And _PosVoucherReslut = True Then
            _result = True
        Else
            _result = False
        End If

        If GlobalVariables._Shalash = True And _result = True Then
            SendSMSMessage(CStr("120363419725512046"), " دفعة بقيمة  " & Me.TextAmount.EditValue & " من " & Me.Referance.Text & " بتاريخ " & _DocInputDateTime & " المستخدم " & GlobalVariables.EmployeeName, "WhatsApp", True, Me.Referance.Text)
        End If

        If _result = True AndAlso _SubscriptionID <> 0 Then
            Dim _Status As Integer
            If _RequiredAmount = Me.TextAmount.Text Or Me.TextAmount.Text > _RequiredAmount Then
                _Status = 2
            Else
                _Status = 1
            End If
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Update [SubscriptionDoc] Set [PaidStatus]=" & _Status & " where [SubID]=" & _SubscriptionID)
        End If
        If _result = True AndAlso _InstallmentID <> 0 Then
            Dim _Status As Integer
            If _RequiredAmount = Me.TextAmount.Text Or Me.TextAmount.Text > _RequiredAmount Then
                _Status = 2
            Else
                _Status = 1
            End If
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Update [InstallmentsPayments] Set [status]=" & _Status & ",PaidDate='" & Format(Today, "yyyy-MM-dd") & "',PaidAmount=" & Me.TextAmount.Text & " where [ID]=" & _InstallmentID)
        End If

        If _result = True Then
            If CheckPrint.Checked = True Then
                If _PrintPosReceiptSize = "A4" Or _PrintPosReceiptSize = "A5" Then
                    PrintDoc(False, _DocCode, "Journal", False, False)
                ElseIf _PrintPosReceiptSize = "80*80" Then
                    POS_PrintDirectReceipt(_DocID, Me.RadioAmountType.Text)
                End If


            End If
            If CheckSendSMS.Checked = True Then
                SendSMSMessage(_RefData.RefMobile, BuildSMSText(_DocCode, _DocID), "WhatsApp", False, Me.Referance.Text)
            End If
        End If
        Return _result

    End Function

    Private Sub TextAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextAmount.EditValueChanged

    End Sub
    Private Sub TextPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles Referance.MouseUp
        TextEditSelectText(Referance)
    End Sub
    Private Sub TextAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextAmount.MouseUp
        TextEditSelectText(TextAmount)
    End Sub
    Private Sub MemoEdit1_MouseUp(sender As Object, e As MouseEventArgs) Handles MemoEdit1.MouseUp
        TextEditSelectText(MemoEdit1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        TextRefBalance.Text = GetReferanceBalance(Referance.EditValue)
    End Sub

    Private Sub Referance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Referance.KeyPress

    End Sub

    Private Sub Referance_KeyDown(sender As Object, e As KeyEventArgs) Handles Referance.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextAmount.Select()
        End If
    End Sub

    Private Sub MemoEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles MemoEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.BtnSave.Select()
        End If
    End Sub

    Private Sub TextAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles TextAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.MemoEdit1.Select()
        End If
    End Sub

    Private Function CreatePosPaidOptions() As DataTable
        Dim _PaidOptionTable As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select MethodNo,PaidMethodName,AccountNO from PosPaidMethods "
        sql.SqlTrueTimeRunQuery(sqlstring)
        _PaidOptionTable = sql.SQLDS.Tables(0)
        Dim newRow As DataRow = _PaidOptionTable.NewRow()
        newRow("MethodNo") = 0
        newRow("PaidMethodName") = "نقدا"
        newRow("AccountNO") = _DefaultCashAccount
        _PaidOptionTable.Rows.Add(newRow)
        Return _PaidOptionTable
    End Function

    Private Sub BtnSaveAndPrint_Click(sender As Object, e As EventArgs)
        If DirectReceipt() = True Then
            Me.Dispose()
        Else
            MsgBoxShowError(" خطأ، يرجى مراجعة بيانات الادخال ")
        End If
    End Sub
    Private Function BuildSMSText(DocCode As String, _DocID As Integer) As String
        Dim sql As New SQLControl
        Dim _OrigionalSMSMessage, _SMSMessage As String
        sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=3")
        _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")
        Dim _RefBalance As Decimal = GetReferanceBalance(Me.Referance.EditValue)
        Dim _RefData = GetRefranceData(Me.Referance.EditValue)
        _SMSMessage = _OrigionalSMSMessage
        _SMSMessage = _SMSMessage.Replace("#ReferanceName#", Me.Referance.Text)
        _SMSMessage = _SMSMessage.Replace("#DocAmount#", Me.TextAmount.EditValue)
        _SMSMessage = _SMSMessage.Replace("#DocDate#", Today())
        _SMSMessage = _SMSMessage.Replace("#DocCurrency#", "شيكل")
        _SMSMessage = _SMSMessage.Replace("#RefBalance#", _RefBalance)
        Return _SMSMessage
    End Function

    Private Sub RadioAmountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioAmountType.SelectedIndexChanged
        Select Case RadioAmountType.EditValue
            Case "Cash"
                SearchCashAccount.EditValue = _DefaultCashAccount
            Case "Card"
                SearchCashAccount.EditValue = GetAccountNoForDefaultVISA()
        End Select
    End Sub
    Private Function GetAccountNoForDefaultVISA() As String
        Try
            Dim sqlString As String
            Dim sql As New SQLControl
            sqlString = " 
                            SELECT COALESCE(
                                (SELECT TOP(1) AccountNO 
                                 FROM [dbo].[PosPaidMethods] 
                                 WHERE [IsDefualt] = 1),
                                (SELECT TOP(1) AccountNO 
                                 FROM [dbo].[PosPaidMethods])
                            ) AS AccountNO; "
            sql.SqlTrueAccountingRunQuery(sqlString)
            Return sql.SQLDS.Tables(0).Rows(0).Item("AccountNO")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class