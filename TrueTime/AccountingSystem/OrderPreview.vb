Imports System.Data.SqlTypes
Imports DevExpress.XtraGrid.Views.Grid

Public Class OrderPreview
    Private Sub OrderPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'AccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.

        'Me.GridControl1.DataSource = GlobalVariables._OrderTable
        GerRefereces()
        GetOrders(0)
        GetWahreHouses()
    End Sub
    Private Sub GerRefereces()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select distinct (Vendor) as RefNo,R.RefName  
                                        FROM [dbo].[OrderProcessing] O  
                                        left join dbo.Referencess  R on R.RefNo=O.Vendor 
                                        where Orderstatus=0  ")
        Me.Referance.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PrepareOrders()
        'AddHandler GridView1.ValidateRow, AddressOf View_ValidateRow
        '        Dim i As Integer
        '        Dim SqlString As String
        '        Dim Sql As New SQLControl
        '        Dim _DocCode As String = CreateRandomCode()
        '        Dim _InputdateTime As String = Format(Now, "yyyy-MM-dd HH:mm")
        '        Dim _DocID As Integer = GetMaxDocID()
        '        For i = 0 To GridView1.RowCount - 1
        '            If Not String.IsNullOrEmpty(CStr(GridView1.GetRowCellValue(i, "ItemNo"))) Then
        '                SqlString = "Insert Into [OrdersJournal] 
        '(DocID,[DocDate],[DocName],[DocStatus],[DocCostCenter],
        '[DocAmount],[DocSort],[Referance],[DocManualNo],[DocMultiCurrency],
        '[InputUser],[InputDateTime],[DocNotes],[StockID],[StockUnit],
        '[StockQuantity],[StockPrice],[DocCode],[DeviceName],[StockDebitShelve],
        '[StockCreditShelve],[StockDebitWhereHouse],[StockCreditWhereHouse],ReferanceName,StockBarcode,ItemNo2) Values (" &
        '                               "'" & _DocID & "'," &
        '                               "'" & Format(Today(), "yyyy-MM-dd") & "'," &
        '                               10 & "," &
        '                               1 & "," &
        '                               1 & "," &
        '                               0 & "," &
        '                               0 & "," &
        '                               "'" & CStr(Referance.EditValue) & "'," &
        '                               "'" & 0 & "'," &
        '                               0 & "," &
        '                               1 & "," &
        '                               "'" & _InputdateTime & "'," &
        '                               "N'" & DocNote.Text & "'," &
        '                               "'" & CStr(GridView1.GetRowCellValue(i, "ItemNo")) & "'," &
        '                               1 & "," &
        '                               "" & CStr(GridView1.GetRowCellValue(i, "Quantity")) & "," &
        '                               0 & "," &
        '                               "'" & _DocCode & "'," &
        '                               "'" & GlobalVariables.CurrDevice & "'," &
        '                               "" & 0 & "," &
        '                               "" & 0 & "," &
        '                               "" & 1 & "," &
        '                               "" & 0 & "," &
        '                               "N'" & Me.Referance.Text & "'," &
        '                               "( select item_unit_bar_code  from Items_units where item_id=" & CStr(GridView1.GetRowCellValue(i, "ItemNo")) & " and main_unit=1  ) ," &
        '                               "N'" & 0 & "'" &
        '                               ")"
        '                Sql.SqlTrueAccountingRunQuery(SqlString)
        '            End If
        '        Next
    End Sub
    'Private Function GetMaxDocID() As Integer
    '    Try
    '        Dim sql As New SQLControl
    '        sql.SqlTrueAccountingRunQuery(" Select IsNull(Max(DocID),0) As MaxDocID From [OrdersJournal] where DocName=10 ")
    '        Return sql.SQLDS.Tables(0).Rows(0).Item("MaxDocID") + 1
    '    Catch ex As Exception
    '        Return 1
    '    End Try
    'End Function

    Private Sub GetOrders(_RefNo As Integer)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  O.[ID]
      ,O.[ItemNo]
      ,O.[ItemName]
      ,[Quantity]
      ,[OrderDate]
      ,[OrderByUser]
      ,[AcceptByUser]
      ,[AcceptDate]
      ,[Orderstatus]
      ,[OrderType]
      ,O.[Vendor]
      ,R.RefName,IsNull( I.LastPurchasePrice,0)*IsNull(Quantity,0) As Amount
, I.LastPurchasePrice as Cost
  FROM [dbo].[OrderProcessing] O
  left join Referencess R on O.vendor=R.RefNo 
  left join Items I on I.ItemNo=O.ItemNo 
where Orderstatus=0 "
        If _RefNo <> 0 Then
            sqlstring += " and  O.Vendor=" & _RefNo
        End If
        sql.SqlTrueTimeRunQuery(sqlstring)
        If sql.SQLDS.Tables.Count > 0 Then
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        End If
    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        'If Referance.EditValue > 0 Then
        GetOrders(Referance.EditValue)
        'End If

    End Sub
    Private Sub PrepareOrders()

        If Referance.EditValue = 0 Then
            MsgBoxShowError(" يجب اختيار مورد  ")
            Exit Sub
        End If


        If WhereHouse.EditValue = 0 Then
            MsgBoxShowError(" يجب اختيار المستودع  ")
            Exit Sub
        End If

        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError(" الرجاء تحديد الأصناف  ")
            Exit Sub
        End If
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim _DocCode As String = CreateRandomCode()
        Dim _InputdateTime As String = Format(Now, "yyyy-MM-dd HH:mm")
        Dim _AcceptDate As String = Format(Now, "yyyy-MM-dd")
        Dim _DocID As Integer = GetDocNo(10, False)
        Dim sqlstring2 As String

        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _ID As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "ID")
            Dim _ItemNo As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo")
            Dim _ItemData = GetItemsData(_ItemNo, False)
            If Not String.IsNullOrEmpty(CStr(GridView1.GetRowCellValue(i, "ItemNo"))) Then
                SqlString = "Insert Into [JournalTemp] 
                                    ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                    [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                    [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                    StockQuantity,[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                    StockCreditWhereHouse,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                                    PosNo,DocNoteByAccount,DeviceName,DeliverDate )  Values (" &
                               "" & _DocID & "," & 'DocID
                               "'" & Format(Today(), "yyyy-MM-dd") & "'," & 'DocDate
                               " 10 ," & 'DocName
                               " 1 ," & 'DocStatus
                               " 1 ," & 'DocCostCenter
                               "'" & _ItemData.AccPurches & "'," & 'DebitAcc
                               "'0'," & 'CredAcc
                               "1," & 'AccountCurr
                               "1," & 'DocCurrency
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Amount")) & "," & 'DocAmount
                               "" & 1 & "," & 'ExchangePrice
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Amount")) & "," & 'BaseCurrAmount
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Amount")) & "," &  'BaseAmount
                               "'0'," & 'DocManualNo
                               "N'" & Me.DocNote.Text & "'," & 'DocNotes
                               "'" & GlobalVariables.CurrUser & "'," & 'InputUser
                               "'" & _InputdateTime & "'," & 'InputDateTime
                               "'" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo")) & "'," & 'StockID
                               "'" & _ItemData.DefaultUnit & "'," & 'StockUnit
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Quantity")) & "," & 'StockQuantity
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Quantity")) & "," & 'StockQuantityByMainUnit
                               "" & CDec(GridView1.GetRowCellValue(selectedRowHandles(i), "Cost")) & "," & 'StockPrice
                               "" & 0 & "," & 'StockDebitWhereHouse
                               "" & 1 & "," & 'StockCreditWhereHouse
                               "'" & Referance.EditValue & "'," & 'Referance
                               "N'" & Referance.Text & "'," & 'ReferanceName
                               "N'" & CStr(GridView1.GetRowCellValue(selectedRowHandles(i), "ItemName")) & "'," & 'ItemName
                               "0," & 'ShiftID
                               "'" & _DocCode & "'," & 'DocCode
                               "'0'," & 'PosNo
                               "N'" & CStr(GridView1.GetRowCellValue(selectedRowHandles(i), "DocNoteByAccount")) & "'," & 'DocNoteByAccount
                               "'" & GlobalVariables.CurrDevice & "'," & 'DeviceName
                               "'" & Format(Today(), "yyyy-MM-dd") & "'" & 'DeliverDate
                               ")"
                If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then
                    MsgBox(" خطا باعتماد الاصناف ")
                    DeleteFromJournalTemp(10, _DocCode)
                    Exit Sub
                End If


            End If
        Next

        Dim RefData = GetRefranceData(Referance.EditValue)
        sqlstring2 = "     Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                           [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount], 
                                           [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                           [DocCode],DeviceName,PosNo,ShiftID,DeliverDate ) 
                                       Values
                                       (" & _DocID & ",'" & Format(Today, "yyyy-MM-dd") & "'," & 10 & " ,1," & 1 & ",'0','" & RefData.RefAccID & "',
                                       '" & RefData.currency_id & "'," & 1 & "," &
                               0 & "," & 1 & "," & 0 & "," &
                               0 & ",'" & 0 & "',N'" & Me.DocNote.Text & "','" & GlobalVariables.CurrUser & "'
                               , CAST(GETDATE() AS smalldatetime),'" & Referance.EditValue & "',N'" & Referance.Text & "','" & _DocCode &
                               "','" & GlobalVariables.CurrDevice & "',0,0,'" &
                               Format(Today, "yyyy-MM-dd") & "')"
        If Sql.SqlTrueAccountingRunQuery(sqlstring2) = False Then
            MsgBox(" خطا باعتماد الذمة ")
            DeleteFromJournalTemp(10, _DocCode)
            Exit Sub
        End If

        Dim sqlstring3 As String
        sqlstring3 = " Insert into [dbo].[OrdersJournal] "
        sqlstring3 += "  ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],DeliverDate,LastDocCode,LastDataName,ItemNo2) 
                                                  Select [DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName],DeliverDate,LastDocCode,LastDataName,ItemNo2
                                                 from JournalTemp where DocCode='" & _DocCode & "' Order by Id ; 
                                                 Delete from journaltemp where DocCode='" & _DocCode & "'"
        If Sql.SqlTrueAccountingRunQuery(sqlstring3) = True Then
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim _ID As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "ID")
                Sql.SqlTrueAccountingRunQuery(" Update OrderProcessing Set 
                                                       Orderstatus=1,
                                                       AcceptDate='" & _AcceptDate & "',  
                                                       OrderType=" & 1 & ",  
                                                       AcceptByUser=" & GlobalVariables.CurrUser & " 
                                                       where ID=" & _ID)
            Next
            MsgBoxShowSuccess(" تم اعتماد الطلبية ")
            Referance.EditValue = 0
            GetOrders(0)
        End If
    End Sub
    Private Sub GetWahreHouses()
        Dim sql As New SQLControl
        Dim sqlstring As String = " SELECT [WarehouseID],[WarehouseNameAR],[WarehouseNameEn] FROM [Warehouses] "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        WhereHouse.Properties.DataSource = sql.SQLDS.Tables(0)

    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _Id As Integer
        _Id = GridView1.GetFocusedRowCellValue("ID")
        sqlstring = " Delete from OrderProcessing where ID= " & _Id
        If GridView1.Editable Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف لصنف من الطلبية؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                    GridView1.DeleteSelectedRows()
                End If

            End If
        End If
    End Sub
End Class