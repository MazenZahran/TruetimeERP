Imports System.Data.SqlTypes

Public Class ChangeItemBalanceInStockBalance
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        BuildTheStatment()
    End Sub
    Private Sub BuildTheStatment()
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim _DocDate As String = Format(DocDate.DateTime, "yyyy-MM-dd")
        Dim _TextDifference As Decimal = TextDifference.EditValue
        Dim _DefaultCurr As Integer = GetDefaultCurrency()
        Dim _InputDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        Dim _Amount As Decimal = TextDifferenceAmount.EditValue
        Dim _ItemMainUnit As Integer = GetMainUnitForItemNo()
        Dim _DocCodeIn As String = CreateRandomCode()
        Dim _DocCodeOut As String = CreateRandomCode()
        If _TextDifference = 0 Then
            MsgBoxShowError("لا يوجد فرق في الجرد")
            Exit Sub
        End If

        SqlString = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,StockUnit,StockQuantity,StockQuantityByMainUnit,StockPrice,StockDiscount,StockDebitWhereHouse,StockCreditWhereHouse,
                                Referance,ReferanceName,ItemName,DocCode,StockBarcode,Color,Measure,VoucherDiscount,ItemVAT,OrderID) Values ("

        SqlString += "'" & _DocDate & "'," ' DocDate
        If _TextDifference > 0 Then SqlString += "17," Else SqlString += "18," 'DocName
        SqlString += "1," ' DocStatus
        SqlString += "1," ' CostCenter
        If _TextDifference > 0 Then SqlString += "'4020000000','0'," Else SqlString += "'0','4020000000'," 'DebitAcc CredAcc
        SqlString += _DefaultCurr & "," ' AccountCurr
        SqlString += _DefaultCurr & "," ' DocCurrency
        SqlString += Math.Abs(_Amount) & "," 'DocAmount
        SqlString += "1," ' ExchangePrice
        SqlString += Math.Abs(_Amount) & "," 'BaseCurrAmount
        SqlString += Math.Abs(_Amount) & "," 'BaseAmount
        SqlString += "'" & 0 & "'," ' DocManualNo
        SqlString += GlobalVariables.CurrUser & "," ' InputUser
        SqlString += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
        SqlString += "'" & _InputDateTime & "'," ' InputDateTime
        SqlString += GlobalVariables.CurrUser & "," ' CurrUser
        SqlString += "N'" & " Stock Adjustment From Items Balances Report ',"  ' DocNotes
        SqlString += TextItemNo.EditValue & "," ' StockID
        SqlString += _ItemMainUnit & "," ' StockUnit
        SqlString += Math.Abs(_TextDifference) & "," ' StockQuantity
        SqlString += Math.Abs(_TextDifference) & "," ' StockQuantityByMainUnit
        SqlString += Math.Abs(TextItemCost.EditValue) & "," ' LastPurchasePrice
        SqlString += "'0'," ' StockDiscount
        If _TextDifference > 0 Then SqlString += TextWarehouseID.EditValue & ",0," Else SqlString += "0," & TextWarehouseID.EditValue & ","  'StockDebitWhereHouse StockCreditWhereHouse
        SqlString += "0," ' Referance
        SqlString += "''," ' ReferanceName
        SqlString += "N'" & TexItemName.Text & "'," ' ItemName
        If _TextDifference > 0 Then SqlString += "'" & _DocCodeIn & "'," Else SqlString += "'" & _DocCodeOut & "'," ' DocCode
        SqlString += " '" & TextBarcode.Text & "'," ' Barcode
        SqlString += "0," ' Color
        SqlString += "0," ' Measure
        SqlString += "0," ' VoucherDiscount
        SqlString += "0," ' ItemVAT
        SqlString += "1" ' OrderID
        SqlString += ") "
        Sql.SqlTrueAccountingRunQuery(SqlString)


        Dim _InRowsCount As Integer = 0
        Dim _OutRowsCount As Integer = 0
        Dim _InRowsSum As Integer = 0
        Dim _OutRowsSum As Integer = 0
        If _TextDifference > 0 Then
            _InRowsCount = 1
            _InRowsSum = TextDifferenceAmount.EditValue
        Else
            _OutRowsCount = 1
            _OutRowsSum = TextDifferenceAmount.EditValue
        End If



        ' بناء الطرف المدين لسند الادخال ان وجد
        If _InRowsCount > 0 Then
            SqlString = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,Referance,ReferanceName,DocCode,OrderID) Values ("
            SqlString += "'" & _DocDate & "'," ' DocDate
            SqlString += "17," 'DocName
            SqlString += "1," ' DocStatus
            SqlString += "1," ' DocCostCenter
            SqlString += "0," ' DebitAcc
            SqlString += "'4020000000'," ' CredAcc
            SqlString += _DefaultCurr & "," ' AccountCurr
            SqlString += _DefaultCurr & "," ' DocCurrency
            SqlString += _InRowsSum & "," ' DocAmount
            SqlString += "1," ' ExchangePrice
            SqlString += Math.Abs(_InRowsSum) & "," 'BaseCurrAmount
            SqlString += Math.Abs(_InRowsSum) & "," 'BaseAmount
            SqlString += "'" & 0 & "'," ' DocManualNo
            SqlString += GlobalVariables.CurrUser & "," ' InputUser
            SqlString += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
            SqlString += "'" & _InputDateTime & "'," ' InputDateTime
            SqlString += GlobalVariables.CurrUser & "," ' CurrentUserID
            SqlString += "N'" & " Stock Adjustment From Items Balances Report ',"  ' DocNotes
            SqlString += "0," ' StockID
            SqlString += "0," ' Referance
            SqlString += "''," ' ReferanceName
            SqlString += "'" & _DocCodeIn & "',"
            SqlString += "0" ' OrderID
            SqlString += ") "
            Sql.SqlTrueAccountingRunQuery(SqlString)
        End If

        ' بناء الطرف الدائن لسند الاخراج للمشتريات ان وجد
        If _OutRowsCount > 0 Then
            SqlString = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,Referance,ReferanceName,DocCode,OrderID) Values ("
            SqlString += "'" & _DocDate & "'," ' DocDate
            SqlString += "18," 'DocName
            SqlString += "1," ' DocStatus
            SqlString += "1," ' DocCostCenter
            SqlString += "'4020000000'," ' DebitAcc
            SqlString += "0," ' CredAcc
            SqlString += _DefaultCurr & "," ' AccountCurr
            SqlString += _DefaultCurr & "," ' DocCurrency
            SqlString += _OutRowsSum & "," ' DocAmount
            SqlString += "1," ' ExchangePrice
            SqlString += Math.Abs(_OutRowsSum) & "," 'BaseCurrAmount
            SqlString += Math.Abs(_OutRowsSum) & "," 'BaseAmount
            SqlString += "'" & 0 & "'," ' DocManualNo
            SqlString += GlobalVariables.CurrUser & "," ' InputUser
            SqlString += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
            SqlString += "'" & _InputDateTime & "'," ' InputDateTime
            SqlString += GlobalVariables.CurrUser & "," ' CurrentUserID
            SqlString += "N'" & " Stock Adjustment From Items Balances Report ',"  ' DocNotes
            SqlString += "0," ' StockID
            SqlString += "0," ' Referance
            SqlString += "''," ' ReferanceName
            SqlString += "'" & _DocCodeOut & "',"
            SqlString += "0" ' OrderID
            SqlString += ") "
            Sql.SqlTrueAccountingRunQuery(SqlString)
        End If
        Dim _DocInID As Integer
        If _InRowsCount > 0 Then
            _DocInID = InsertDataFromTempToJournalWithLockTable(17, _DocCodeIn, 0)
            If _DocInID = 0 Then
                MsgBoxShowError(" خطا في ادخال بيانات سند الادخال ")
            Else
                Sql.SqlTrueAccountingRunQuery(" Update [JardSavedSessions] Set [Settle]=1,InDocNo=" & _DocInID & " where [InDocNo]=-1")
                MsgBoxShowSuccess(" تم اصدار سند ادخال بضاعة  ")
            End If
        End If
        Dim _DocOutID As Integer
        If _OutRowsCount > 0 Then
            _DocOutID = InsertDataFromTempToJournalWithLockTable(18, _DocCodeOut, 0)
            If _DocOutID = 0 Then
                MsgBoxShowError(" خطا في ادخال بيانات سند الاخراج ")
            Else
                Sql.SqlTrueAccountingRunQuery(" Update [JardSavedSessions] Set [Settle]=1,InDocNo=" & _DocOutID & " where [OutDocNo]=-1")
                MsgBoxShowSuccess(" تم اصدار سند اخراج بضاعة  ")
            End If
        End If




    End Sub

    Private Sub TextJardQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles TextJardQuantity.EditValueChanged
        Try
            TextDifference.EditValue = CDec(TextJardQuantity.EditValue) - CDec(TextSystemQuantity.EditValue)
        Catch ex As Exception
            TextDifference.EditValue = 0
        End Try

    End Sub

    Private Sub ChangeItemBalanceInStockBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Function GetMainUnitForItemNo() As Integer
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "  Select Top 1 unit_id from Items_units where item_id =" & TextItemNo.EditValue
        Sql.SqlTrueAccountingRunQuery(SqlString)
        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return Sql.SQLDS.Tables(0).Rows(0).Item("unit_id")
        Else
            Return 0
        End If
    End Function

    Private Sub TextDifference_EditValueChanged(sender As Object, e As EventArgs) Handles TextDifference.EditValueChanged
        TextDifferenceAmount.EditValue = TextDifference.EditValue * TextItemCost.EditValue
    End Sub

    Private Sub TextItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemNo.EditValueChanged
        Dim _UnitID As Integer
        _UnitID = GetMainUnitForItemNo()
        TextItemCost.EditValue = GetLastPurchasePrice(TextItemNo.Text, _UnitID)
    End Sub
End Class