Imports DevExpress.XtraEditors
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class AccountingJardDocument
    Private _SessionId As Integer
    Private _SessionDate As String
    Private _WarehouseID As Integer
    Private _DocCode As String
    Private _DocNew As Boolean
    Dim _DocID As Integer

    Public Sub New(_New As Boolean, SessionID As Integer, DocCode As String, DocID As Integer)
        InitializeComponent()
        _SessionId = SessionID
        _DocNew = _New
        _DocCode = DocCode
        _DocID = DocID
    End Sub

    Private Sub AccountingJardDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _SessionData = GetSesssionData(_SessionId)
        DateEdit1.DateTime = CDate(_SessionData.DocDate)
        WhereHouse.EditValue = _SessionData.WarehouseID
        WhereHouse.Properties.DataSource = GetWharehouses(False)
        Me.BarDocNo.Caption = " رقم السند: " & _DocID
        Dim _Docdata = GetJardDocumentData(_DocID)
        BarEmployeeName.Caption = " المستخدم: " & _Docdata.EmployeeName
        BarWarehouseName.Caption = " المستودع: " & _Docdata.Warehouse
        ColShelfID.Visible = GlobalVariables._WareHouseUseShelf
        FillGrid(_DocID)
    End Sub
    Private Sub FillGrid(DocID As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT J.*,F.ShelfCode,U.name as UnitName FROM [dbo].[JardJournal] J Left Join Units U on J.ItemUnit=U.id LEFT JOIN FinancialShelves F on F.ShelfID=J.ShelfID Where [DocID]=" & _DocID & " Order By J.ID desc"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControlJard.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        OpenJardForm()
    End Sub
    Public Sub OpenJardForm()
        Try
            Dim f As New AccountingJardAddItem(_SessionId, _DocID)
            If f.ShowDialog() <> DialogResult.OK Then
                FillGrid(_DocID)
                If JardGlobalVariables._OpenJardFormAgain = True Then
                    OpenJardForm()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim _ID As Integer = GridView1.GetFocusedRowCellValue("ID")
        Dim Ans = XtraMessageBox.Show("هل تريد حذف السطر؟", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Ans = DialogResult.Yes Then
            DeleteJardItem(_ID)
            FillGrid(_DocID)
        End If
    End Sub
    Private Sub DeleteJardItem(ID As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Delete From JardJournal Where ID=" & ID
            sql.SqlTrueAccountingRunQuery(sqlstring)
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BarExportToPurchaseDocument_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarExportToPurchaseDocument.ItemClick
        SaveDocumentFromMobileApp(1)
    End Sub
    Private Sub SaveDocumentFromMobileApp(ToDoc As Integer)
        Dim _LogDetails As String = ""
        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Dim _LogDateTime As String = Now().ToString("yyyy-MM-dd HH:mm:ss")
        Dim docDate As String = Format(Me.DateEdit1.DateTime, "yyyy-MM-dd")

        Dim _Referance As Integer = 0

        Dim _PurchaseDocID As Integer

        Dim _Result1, _Result2, _Result3 As String
        _Result2 = False
        Dim SqlString, SqlString2, SqlString3 As String
        Dim sql As New SQLControl

        Dim _DocCode As String = CreateRandomCode()

        _PurchaseDocID = GetDocNo(ToDoc, False)

        'FirstSide 
        SqlString = " Insert into [JournalTemp]
                              ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                              [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                              [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                              StockQuantity,[BonusQuantity],[StockQuantityByMainUnit],BonusQuantityByMainUnit,StockPrice,StockDebitWhereHouse,
                              StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                              PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,"
        SqlString += " [StockDebitShelve],[StockCreditShelve]  "
        SqlString += ",ItemNo2 )"


        SqlString += " Select " & _PurchaseDocID & ",'" & docDate & "',"
        SqlString += ToDoc & ","
        SqlString += "1," & 1 & ","
        If ToDoc = 1 Then SqlString += " I.[AccPurches] as DebitAcc,'0'," ' مشتريات
        SqlString += "1 as AccountCurr,
                                       " & 1 & ",ItemQuantity*IsNull([ItemCost],0),1,ItemQuantity*IsNull([ItemCost],0),ItemQuantity*IsNull([ItemCost],0),[DocID],N'" & Me.MemoEdit1.Text & "',
                                       " & GlobalVariables.CurrUser & ",'" & _LogDateTime & "',J.ItemNo,ItemUnit,ItemQuantity,0 As [BonusQuantity],IU.[EquivalentToMain]*ItemQuantity,IU.[EquivalentToMain]*BonusQuantity,
                                        IsNull(ItemCost,0) As ItemCost ,"
        SqlString += WhereHouse.EditValue & ",0,'"
        SqlString += GlobalVariables.CurrUser & "',
                                         '" & 0 & "',N'',I.ItemName," & GlobalVariables._ShiftID & ",N'" & _DocCode & "','" & 0 & "',
                                         '' As DocNoteByAccount,DeviceName,'1900-01-01',N'" & _DocCode & "',
                                         'JardJournal',IU.item_unit_bar_code as StockBarcode,"
        SqlString += " [ShelfID],0"
        SqlString += ",I.ItemNo2"
        SqlString += "          from [dbo].[JardJournal] J 
                                         Left Join  [dbo].[Items] I On I.[ItemNo]=J.ItemNo 
                                         Left join Items_units IU on J.ItemNo =IU.item_id and J.ItemBarcode=IU.item_unit_bar_code 
                                         where DocID='" & _DocID & "' order by J.ID"
        _Result1 = sql.SqlTrueAccountingRunQuery(SqlString)

        'Dim _BaseAmount As Decimal
        'Second Side
        If _Result1 = True Then
            SqlString2 = "Declare @DocBase decimal(18,2)
                            set @DocBase = ( Select sum(Isnull(ItemCost,0)*ItemQuantity) from JardJournal where DocID=" & _DocID & " ) ;
                            Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount], 
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                       [DocCode],DeviceName,PosNo,ShiftID,CurrentUserID,LastDocCode,LastDataName ) 
                                       Values
                                     (" & _PurchaseDocID & ",'" & docDate & "'," & ""
            SqlString2 += ToDoc & ",1,1"
            If ToDoc = 1 Then SqlString2 += "  ,'0','" & 1101010000 & "'" ' الصندوق
            SqlString2 += ",'" & 1 & "'," & 1 & ",@DocBase," & 1 & ",@DocBase,@DocBase,N'" & _DocID & "',N'" & Me.MemoEdit1.Text & "','" & GlobalVariables.CurrUser &
                                           "', CAST(GETDATE() AS smalldatetime),'" & 0 & "',N'','" & _DocCode &
                                           "',(select top(1) DeviceName from JardJournal Where DocID=" & _DocID & "),0,0,'" & GlobalVariables.CurrUser &
                                           "','" & _DocCode & "','JardJournal')"
            _Result2 = sql.SqlTrueAccountingRunQuery(SqlString2)
        End If



        If _Result1 = True And _Result2 = True Then
            _LogDetails = "Approve Purchase Document From JardDocument "
            SqlString3 = " Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit] ,[BonusQuantityByMainUnit],[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],DeliverDate,LastDocCode,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags) 
                                                  Select [DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit] ,[BonusQuantityByMainUnit],[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName],DeliverDate,LastDocCode
                                                 ,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags
                                                 from JournalTemp where DocCode='" & _DocCode & "';
                                                 Delete from JournalTemp where DocCode='" & _DocCode & "' "


            If XtraMessageBox.Show("هل تريد اعتماد السند؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                _Result3 = sql.SqlTrueAccountingRunQuery(SqlString3)
                If _Result3 = True Then
                    sql.SqlTrueTimeRunQuery("Update JardJournalList Set Posted=1,DocID=" & _PurchaseDocID & " WHERE [ID]=" & _DocID)
                    XtraMessageBox.Show("تم الاعتماد", "", MessageBoxButtons.OK)
                    ' sql.SqlTrueAccountingRunQuery("Update [dbo].OrdersAppJournal Set OrderStatus= 1 where DocCode='" & _DocCode & "'")
                    CreateDocLog("Document", _DocCode, 1, _PurchaseDocID, "Insert", _LogDetails, _LogDateTime)
                Else
                    MsgBox("Error")
                End If
            End If
            DeleteFromJournalTemp(1, _DocCode)
        Else
            sql.SqlTrueAccountingRunQuery(" Delete from JournalTemp where DocCode='" & _DocCode & "'")
            MsgBox("Error")
            Exit Sub
        End If




        '  Me.Dispose()

    End Sub
End Class