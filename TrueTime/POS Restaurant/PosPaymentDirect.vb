Imports System.Data.SqlClient
Imports DevExpress.CodeParser
Imports Microsoft.Graph

Public Class PosPaymentDirect
    Public _CostCenter As Integer
    Public _ShiftID As Integer
    Public _PosName As Integer
    Public _DefaultCashAccount As String
    Public _InputUser As Integer
    Private _RefType As Integer
    Private _RefMobile As String
    Private _SendRefBalance As Integer


    Private Sub PosDirectReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Account.Properties.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
        Me.Referance.Properties.DataSource = GetReferencesForPayment(1, -1, -1)
        Me.MemoEdit1.Text = " نقدا " & " من كاش الموظف  "

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POS_SendRefBalanceInsteadRefDebitWhenSendWhatsAppMessage'")
            _SendRefBalance = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _SendRefBalance = False
        End Try


        SwitchKeyboardLayout("ar")
        Me.Referance.Select()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If DirectReceipt() = True Then
            Me.Dispose()
        Else
            MsgBoxShowError(" خطأ، يرجى مراجعة بيانات الادخال ")
        End If
    End Sub
    Private Function DirectReceipt() As Boolean
        Dim _result As Boolean
        Dim _Referance As Integer = 0
        Dim _ReferanceName As String = " "
        _result = False
        If Me.TextAmount.EditValue = 0 Then
            MsgBoxShowError(" يجب ادخال المبلغ  ")
            Return _result
            Exit Function
        End If

        If Me.Account.Text = "" Then
            MsgBoxShowError(" يجب اختيار الحساب ")
            Return _result
            Exit Function
        End If

        If Me.Referance.Text = "" Then
            _Referance = 0
            _ReferanceName = ""
        Else
            _Referance = Me.Referance.EditValue
            _ReferanceName = Me.Referance.Text
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

        Dim _DocID As Integer = GetDocNo(3, False)
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
                    .Parameters.AddWithValue("@DocName", 3)
                    .Parameters.AddWithValue("@DocStatus", _DocStatus)
                    .Parameters.AddWithValue("@DocCostCenter", _CostCenter)
                    .Parameters.AddWithValue("@DebitAcc", CStr(Me.Account.EditValue))
                    .Parameters.AddWithValue("@CredAcc", "0")
                    .Parameters.AddWithValue("@AccountCurr", "1")
                    .Parameters.AddWithValue("@DocCurrency", "1")
                    .Parameters.AddWithValue("@DocAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@ExchangePrice", "1")
                    .Parameters.AddWithValue("@BaseCurrAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@BaseAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@DocSort", "1")
                    .Parameters.AddWithValue("@Referance", _Referance)
                    .Parameters.AddWithValue("@DocManualNo", "0")
                    .Parameters.AddWithValue("@DocMultiCurrency", "0")
                    .Parameters.AddWithValue("@InputUser", _InputUser)
                    .Parameters.AddWithValue("@InputDateTime", _DocInputDateTime)
                    .Parameters.AddWithValue("@DocNotes", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@ReferanceName", _ReferanceName)
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
        'Dim _RefData = GetRefranceData(Me.Referance.EditValue)
        'Dim _RefAccount As String = _RefData.RefAccID

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
                    .Parameters.AddWithValue("@DocName", 3)
                    .Parameters.AddWithValue("@DocStatus", _DocStatus)
                    .Parameters.AddWithValue("@DocCostCenter", _CostCenter)
                    .Parameters.AddWithValue("@DebitAcc", "0")
                    .Parameters.AddWithValue("@CredAcc", Me._DefaultCashAccount)
                    .Parameters.AddWithValue("@AccountCurr", "1")
                    .Parameters.AddWithValue("@DocCurrency", "1")
                    .Parameters.AddWithValue("@DocAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@ExchangePrice", "1")
                    .Parameters.AddWithValue("@BaseCurrAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@BaseAmount", TextAmount.EditValue)
                    .Parameters.AddWithValue("@DocSort", "1")
                    .Parameters.AddWithValue("@Referance", _Referance)
                    .Parameters.AddWithValue("@DocManualNo", "0")
                    .Parameters.AddWithValue("@DocMultiCurrency", "0")
                    .Parameters.AddWithValue("@InputUser", _InputUser)
                    .Parameters.AddWithValue("@InputDateTime", _DocInputDateTime)
                    .Parameters.AddWithValue("@DocNotes", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@ReferanceName", _ReferanceName)
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
                    Return _result
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
                    .Parameters.AddWithValue("@VoucherAmount", -1 * Me.TextAmount.EditValue)
                    .Parameters.AddWithValue("@VoucherDiscount", 0)
                    .Parameters.AddWithValue("@VoucherPC", GlobalVariables.CurrDevice)
                    .Parameters.AddWithValue("@VoucherAmountAfterDiscount", -1 * Me.TextAmount.EditValue)
                    .Parameters.AddWithValue("@UserNo", _InputUser)
                    .Parameters.AddWithValue("@VoucherCode", _DocCode)
                    .Parameters.AddWithValue("@VoucherDebit", Me._DefaultCashAccount)
                    .Parameters.AddWithValue("@VoucherCredit", "0")
                    .Parameters.AddWithValue("@VoucherPayType", "Cash")
                    If Me.Referance.Text = "" Then
                        .Parameters.AddWithValue("@VoucherReferanceName", Account.Text)
                    Else
                        .Parameters.AddWithValue("@VoucherReferanceName", _ReferanceName)
                    End If
                    .Parameters.AddWithValue("@VoucherReferance", _Referance)
                    .Parameters.AddWithValue("@PayCardName", "0")
                    .Parameters.AddWithValue("@VoucherNote", Me.MemoEdit1.Text)
                    .Parameters.AddWithValue("@PosNo", Me._PosName)
                    .Parameters.AddWithValue("@ShiftID", Me._ShiftID)
                    .Parameters.AddWithValue("@DocName", 3)
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
                    Return _result
                End Try

            End Using
        End Using

        If _DebitResult = True And _CreditResult = True And _PosVoucherReslut = True Then
            _result = True
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSNumbersToSendClosedShift'")
            If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                Dim wordsArray As String() = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").Split("-"c)
                For Each word As String In wordsArray
                    SendSMSMessage(word, BuildText, "WhatsApp", False, _ReferanceName)
                Next
            End If
            If _RefType = 99 And _RefMobile <> "" Then
                SendSMSMessage(_RefMobile, BuildText, "WhatsApp", False, _ReferanceName)
            End If
        End If
        Return _result

    End Function

    Private Function BuildText() As String
        Dim _text As String = ""
        If Referance.Text <> "" Then
            _text = " تم صرف مبلغ  " & Me.TextAmount.EditValue & " شيكل " & " لحساب  " & Me.Referance.Text
            _text += GetAmountThisMonthForRef(Referance.EditValue)
        Else
            _text = " تم صرف مبلغ  " & Me.TextAmount.EditValue & " شيكل " & " لحساب  " & Me.Account.Text
            _text += " علما ان السحوبات بلغت هذا الشهر للحساب مبلغ  " & GetAmountThisMonthForAccount(Account.EditValue) & " شيكل  "
        End If
        If MemoEdit1.Text <> "" Then _text += " " & " ملاحظة: " & Me.MemoEdit1.Text
        Return _text
    End Function
    Private Function GetAmountThisMonthForRef(Referance As Integer) As String
        Dim sql As New SQLControl
        Dim sqlString As String
        If _SendRefBalance = False Then
            Dim _Month As Integer = CInt(Format(Today, "MM"))
            Dim _Year As Integer = CInt(Format(Today, "yyyy"))
            sqlString = "   select IsNull(sum(BaseCurrAmount),0) as Amount from [dbo].[Journal] where DocStatus > 0 And  Referance='" & Referance & "'  and CredAcc='0'  and Month(DocDate)=" & _Month & " and Year(DocDate)=" & _Year
            sql.SqlTrueAccountingRunQuery(sqlString)
            Return " علما ان السحوبات بلغت هذا الشهر للحساب مبلغ  " & sql.SQLDS.Tables(0).Rows(0).Item("Amount") & " شيكل "
        Else
            Dim _Balance As Decimal
            _Balance = GetReferanceBalance(Referance)
            Return " علما ان الرصيد لتاريخ اليوم " & _Balance & " شيكل "
        End If
    End Function
    Private Function GetAmountThisMonthForAccount(Account As String) As Decimal
        Dim sql As New SQLControl
        Dim sqlString As String
        Dim _Month As Integer = CInt(Format(Today, "MM"))
        Dim _Year As Integer = CInt(Format(Today, "yyyy"))
        sqlString = "   select IsNull(sum(BaseCurrAmount),0) as Amount from [dbo].[Journal] where DocStatus > 0  And DebitAcc='" & Account & "'  and Month(DocDate)=" & _Month & " and Year(DocDate)=" & _Year
        sql.SqlTrueAccountingRunQuery(sqlString)
        Return sql.SQLDS.Tables(0).Rows(0).Item("Amount")
    End Function

    Private Sub TextPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles Referance.MouseUp

    End Sub
    Private Sub TextAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextAmount.MouseUp
        TextEditSelectText(TextAmount)
    End Sub
    Private Sub MemoEdit1_MouseUp(sender As Object, e As MouseEventArgs) Handles MemoEdit1.MouseUp
        TextEditSelectText(MemoEdit1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup

    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        If Me.IsHandleCreated Then
            If Me.Referance.Text <> "" Then
                Dim _refdata = GetRefranceData(Referance.EditValue)
                Me.Account.EditValue = _refdata.RefAccID
                Me.Account.ReadOnly = True
                _RefType = _refdata.RefType
                _RefMobile = _refdata.RefMobile
            Else
                Me.Account.ReadOnly = False
            End If
        End If

    End Sub
    Private Function GetReferencesForPayment(RefStatus As Integer, RefType As Integer, UserID As String) As DataTable

        Dim AllReferences As New DataTable
        Try
            Dim References As New DataTable
            Dim SqlString As String
            Dim sql As New SQLControl

            SqlString = " Select RefName,RefNo as RefNo ,RefTypeName,RefMobile,T.TypeID, RefAccID ,'1' as Currency,IdentityNo
                          from Referencess R left join ReferencesTypes T on T.TypeID=R.RefType Where 1=1 "
            If RefStatus = "1" Then SqlString += " and [Active]='True'"
            If RefType <> "-1" Then SqlString += " and [RefType]=" & RefType
            SqlString += " Order By RefNo  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            References = sql.SQLDS.Tables(0)
            AllReferences.Merge(References)
        Catch ex As Exception

        End Try


        Return AllReferences

    End Function
End Class