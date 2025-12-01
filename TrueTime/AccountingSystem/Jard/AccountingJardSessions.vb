Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.Data.SqlTypes
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DevExpress.XtraPrinting
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class AccountingJardSessions
    Private _SessionID As Integer
    Private Sub GetSessions()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" SELECT  [ID],[SessionDetails],[SessionStatus],[SessionDate],[SessionWareHouse],W.WarehouseNameAR  
                                        FROM [dbo].[JardSessions] J
                                        Left Join Warehouses W on J.SessionWareHouse =W.WarehouseID  ")
        GridControlSessions.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub AccountingJardSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSessions()
        TabbedControlGroup1.SelectedTabPage = TabSessions
        TabbedControlGroup1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
    End Sub
    Private Function CheckIfSessionsOpened() As Boolean
        Dim _Count As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select count(*) as _Count from [dbo].[JardSessions] where SessionStatus=0  "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                _Count = sql.SQLDS.Tables(0).Rows(0).Item("_Count")
                If _Count = 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs)
        Dim _ID As Integer
        _ID = GridViewSessions.GetFocusedRowCellValue("ID")
        _SessionID = _ID
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'If checkIfSessionsOpened() = True Then
        '    MsgBoxShowError(" يوجد جلسة جرد مفتوحة الرجلء اغلاقها  ")
        '    Exit Sub
        'End If
        Dim F As New AccountingJardSessionData(-1)
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetSessions()
            End If
        End With
    End Sub

    Private Sub BtnAddNewJardDocument_Click(sender As Object, e As EventArgs) Handles BtnAddNewJardDocument.Click
        Using connection As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Dim sqlstring As String
            sqlstring = " INSERT INTO [dbo].[JardJournalList]
           ([DocDate]
           ,[DocName]
           ,[UserID]
           ,[DocStatus]
           ,[DocNote]
           ,[DeviceName]
           ,[SessionID])
     VALUES
           (GETDATE()
           ,1
           ," & GlobalVariables.CurrUser & "
           ,1
           ,' '
           ,N'" & GlobalVariables.CurrDevice & "'
           ," & _SessionID & ") ; SELECT SCOPE_IDENTITY() "
            Using command As New SqlCommand(sqlstring, connection)
                connection.Open()
                Dim insertedId As Integer = CInt(command.ExecuteScalar())
                connection.Close()
                If insertedId > 0 Then
                    Dim F As New AccountingJardDocument(True, _SessionID, CreateRandomCode(), insertedId)
                    Dim child As Form = Nothing
                    If child Is Nothing Then
                        child = F
                        child.MdiParent = My.Forms.Main
                        child.Show()
                    End If
                    Me.Close()
                End If
            End Using
        End Using
    End Sub
    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim _ID As Integer
        _ID = GridViewSessions.GetFocusedRowCellValue("ID")
        Dim F As New AccountingJardSessionData(_ID)
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetSessions()
            End If
        End With
    End Sub
    Private Sub GetJardDocuments(_SessionID As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = "SELECT J.ID,E.EmployeeName,DocDate,J.DocStatus,DocNote,J.DeviceName,S.ID as SessionID ,W.WarehouseNameAR,S.SessionDetails,count(O.ID) as ItemCount
                                    FROM [dbo].[JardJournalList] J
                                    left join EmployeesData E on E.EmployeeID=J.UserID
                                    left join JardSessions S on J.SessionID=S.ID
                                    left join Warehouses W on W.WarehouseID=S.SessionWareHouse
                                    left join JardJournal O on O.DocID=J.ID 
                                    where J.SessionID=" & _SessionID & "
                                    group by J.ID,E.EmployeeName,DocDate,J.DocStatus,DocNote,J.DeviceName,S.ID  ,W.WarehouseNameAR,S.SessionDetails "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControlJardDocuments.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError(" خطأ في جلب البيانات ")
        End Try

    End Sub

    Private Sub RepositoryItemHyperLinkEdit2_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit2.OpenLink
        Dim ID As Integer
        Dim DocCode As String
        ID = GridViewJardDocuments.GetFocusedRowCellValue("ID")
        DocCode = GridViewJardDocuments.GetFocusedRowCellValue("DocCode")
        Dim F As New AccountingJardDocument(False, _SessionID, DocCode, ID)
        Dim child As Form = Nothing
        If child Is Nothing Then
            child = F
            child.MdiParent = My.Forms.Main
            F.Text = " سند جرد رقم " & ID
            child.Show()
        End If
    End Sub



    Private Sub BtnSettlementRefreshData_Click(sender As Object, e As EventArgs) Handles BtnSettlementRefreshData.Click
        GetJardData(False)
    End Sub
    Private Sub GetJardData(_WithInsert As Boolean)
        Dim _SessionData = GetSesssionData(_SessionID)
        Dim sql As New SQLControl
        Dim sqlstring
        sqlstring = " 
        Declare @WahreHouseFrom Int;
        Declare @WahreHouseTo Int;
        Declare @Date date;
        Declare @SessionID int;
        Set @SessionID=" & _SessionID & "
        Set @WahreHouseFrom=" & _SessionData.WarehouseID & "
        Set @WahreHouseTo=" & _SessionData.WarehouseID & "
        Set @Date ='" & _SessionData.DocDate & "'"
        If _WithInsert = True Then sqlstring += " Insert Into [JardSavedSessions] ( StockID,ItemName,GroupName,TradeMarkName,CategoryName,balance,LastPurchasePrice,ItemCostAmount,[Price1],[ItemPriceAmount],[HasTrans],[QuantityByMainUnitInJard],[AdjustingQuantity],[AdjustingAmount],[SessionID],[MainUnitID],[UnitName],[UserID] )
                                                  Select StockID,ItemName,GroupName,TradeMarkName,CategoryName,balance,LastPurchasePrice,ItemCostAmount,[Price1],[ItemPriceAmount],[HasTrans],[QuantityByMainUnitInJard],[AdjustingQuantity],[AdjustingAmount],@SessionID,MainUnitID,[UnitName]," & GlobalVariables.CurrUser & "
                                                  from (  "
        sqlstring += "
        Select AA.Barcode, AA.ItemNo As StockID , AA.ItemName, AA.GroupName, AA.TradeMarkName, AA.CategoryName,IsNull(AA.LastPurchasePrice,0) As LastPurchasePrice,
            IsNull(BB.[balance],0) as balance ,
             AA.Price1, IsNull(BB.ItemPriceAmount,0) as ItemPriceAmount,
	        case when (IsNull(BB.QuantityIn,0) = 0 And IsNull(BB.QuantityOut,0) = 0)  then 'NoTrans' else 'YesTrans' end as HasTrans,
            IsNull(CC.QuantityByMainUnitInJard,0) as QuantityByMainUnitInJard,AA.UnitName,MainUnitID,
	        (IsNull(CC.QuantityByMainUnitInJard,0)-IsNull(balance,0) ) as AdjustingQuantity,
	        (IsNull(CC.QuantityByMainUnitInJard,0)*IsNull(AA.LastPurchasePrice,0) - (IsNull(BB.[balance],0) * IsNull(AA.LastPurchasePrice,0)) ) as AdjustingAmount,IsNull(BB.[balance],0) * IsNull(AA.LastPurchasePrice,0)  As ItemCostAmount
        From
        (
	        SELECT IU.item_unit_bar_code as Barcode, ItemNo, ItemName As ItemName, GroupName, TradeMarkName, CategoryName, IU.Price1,U.name as UnitName,U.id MainUnitID,LastPurchasePrice
            From items I
                left join Items_units IU on IU.item_id=I.ItemNo
                left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID
                left join ItemsGroups G on G.GroupID=I.GroupID
                left Join [Units] U on U.id=IU.unit_id 
            Where IU.main_unit=1 and I.[Type]=0 
        ) AA
        Left Join
        (
	        Select A.Barcode, A.StockID, ItemName, QuantityIn, QuantityOut, [balance], 
               Price1, Price1*balance as ItemPriceAmount
            From
	        (
			        SELECT StockID, I.ItemName As ItemName,
				        isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0)  as QuantityIn,
				        isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as QuantityOut,
				        isnull(sum(case when    [StockDebitWhereHouse] Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end),0) -isnull(sum(case when    StockCreditWhereHouse  Between @WahreHouseFrom And @WahreHouseTo then [StockQuantityByMainUnit] end) ,0) as balance,
				        IsNull(IU.Price1,0) as  Price1, IsNull(IU.item_unit_bar_code,0) as  Barcode
			        FROM [Journal] J
				        left join Items I on I.ItemNo=J.StockID
				        left join Items_units IU on IU.item_id=I.ItemNo
			        where  DocDate <= @Date And IU.main_unit=1 and DocStatus<>0 and StockID > '0'
				        And I.[Type]=0 and (StockDebitWhereHouse Between @WahreHouseFrom And @WahreHouseTo or StockCreditWhereHouse Between @WahreHouseFrom And @WahreHouseTo )
			        group by item_unit_bar_code,StockID,I.ItemName,Price1
	        ) A
	        where Balance<>0 

        ) BB 
        on AA.ItemNo=BB.StockID 
        Left Join 
        ( 
	        select ItemNo as ItemNoInJard ,Sum(J.ItemQuantity*IU.EquivalentToMain)   as QuantityByMainUnitInJard
	        from JardJournal J
	        left join Items_units IU on IU.item_id=J.ItemNo   and J.ItemBarcode=IU.item_unit_bar_code
	        where J.SessionID=@SessionID
	        group by ItemNo 
        ) CC
        on AA.ItemNo=CC.ItemNoInJard "
        If _WithInsert = True Then sqlstring += " ) Z "
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            If _WithInsert <> True Then
                GridControl1.DataSource = sql.SQLDS.Tables(0)
            Else
                MsgBoxShowSuccess(" تم حفظ التسوية ")
            End If
        End If
    End Sub

    Private Sub CheckShowItemsDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowItemsDetails.CheckedChanged
        gridBandItemsDetails.Visible = CheckShowItemsDetails.Checked
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(*) as _Count from [JardSavedSessions] where [SessionID]=" & _SessionID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows(0).Item("_Count") = 0 Then
            GetJardData(True)
        Else
            MsgBoxShowError(" يوجد تسوية محفوظة من قبل ")
        End If

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub BuildDocument()
        Dim _DefaultCurr As Integer = GetDefaultCurrency()
        Dim _InputDateTime As String
        _InputDateTime = Now().ToString("yyyy-MM-dd HH:mm:ss")
        Dim _SessionData = GetSesssionData(_SessionID)
        Dim sql As New SQLControl
        Dim sqlstring As String = ""
        Dim _DocCodeIn As String = CreateRandomCode()
        Dim _DocCodeOut As String = CreateRandomCode()
        Dim _InRowsCount As Integer = 0
        Dim _OutRowsCount As Integer = 0
        Dim _InRowsSum As Integer = 0
        Dim _OutRowsSum As Integer = 0
        With BandedGridView1
            Dim selectedRowHandles As Integer() = .GetSelectedRows()
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim _AdjustingQuantity As Decimal = .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity")
                Dim _IsSettle As Boolean = .GetRowCellValue(selectedRowHandles(i), "Settle")
                If _AdjustingQuantity <> 0 And _IsSettle = False Then
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then _InRowsCount += 1 Else _OutRowsCount += 1 ' Count Noumber Of rows for each Document
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then _InRowsSum += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingAmount")) Else _OutRowsSum += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingAmount")) ' Sum Of rows for each Document
                    Dim _ID As Object = .GetRowCellValue(selectedRowHandles(i), "ID")
                    sqlstring = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,StockUnit,StockQuantity,StockQuantityByMainUnit,StockPrice,StockDiscount,StockDebitWhereHouse,StockCreditWhereHouse,
                                Referance,ReferanceName,ItemName,DocCode,StockBarcode,Color,Measure,VoucherDiscount,ItemVAT,OrderID) Values ("
                    sqlstring += "'" & _SessionData.DocDate & "'," ' DocDate
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then sqlstring += "17," Else sqlstring += "18," 'DocName
                    sqlstring += "1," ' DocStatus
                    sqlstring += "1," ' CostCenter
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then sqlstring += "'4020000000','0'," Else sqlstring += "'0','4020000000'," 'DebitAcc CredAcc
                    sqlstring += _DefaultCurr & "," ' AccountCurr
                    sqlstring += _DefaultCurr & "," ' DocCurrency
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingAmount")) & "," 'DocAmount
                    sqlstring += "1," ' ExchangePrice
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingAmount")) & "," 'BaseCurrAmount
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingAmount")) & "," 'BaseAmount
                    sqlstring += "'" & _SessionID & "'," ' DocManualNo
                    sqlstring += GlobalVariables.CurrUser & "," ' InputUser
                    sqlstring += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
                    sqlstring += "'" & _InputDateTime & "'," ' InputDateTime
                    sqlstring += GlobalVariables.CurrUser & "," ' CurrUser
                    sqlstring += "N'" & " Stock Adjustment For " & _SessionData.Details & "," & " جلسة رقم " & _SessionID & "'," ' DocNotes
                    sqlstring += .GetRowCellValue(selectedRowHandles(i), "StockID") & "," ' StockID
                    sqlstring += .GetRowCellValue(selectedRowHandles(i), "MainUnitID") & "," ' StockUnit
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity")) & "," ' StockQuantity
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity")) & "," ' StockQuantityByMainUnit
                    sqlstring += Math.Abs(.GetRowCellValue(selectedRowHandles(i), "LastPurchasePrice")) & "," ' LastPurchasePrice
                    sqlstring += "'0'," ' StockDiscount
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then sqlstring += _SessionData.WarehouseID & ",0," Else sqlstring += "0," & _SessionData.WarehouseID & ","  'StockDebitWhereHouse StockCreditWhereHouse
                    sqlstring += "0," ' Referance
                    sqlstring += "''," ' ReferanceName
                    sqlstring += "N'" & .GetRowCellValue(selectedRowHandles(i), "ItemName") & "'," ' ItemName
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then sqlstring += "'" & _DocCodeIn & "'," Else sqlstring += "'" & _DocCodeOut & "'," ' DocCode
                    sqlstring += " '" & .GetRowCellValue(selectedRowHandles(i), "Barcode") & "'," ' Barcode
                    sqlstring += "0," ' Color
                    sqlstring += "0," ' Measure
                    sqlstring += "0," ' VoucherDiscount
                    sqlstring += "0," ' ItemVAT
                    sqlstring += "1" ' OrderID
                    sqlstring += ") "
                    If .GetRowCellValue(selectedRowHandles(i), "AdjustingQuantity") > 0 Then
                        sqlstring += " ; Update [JardSavedSessions] Set InDocNo=-1 where [ID]=" & _ID
                    Else
                        sqlstring += " ; Update [JardSavedSessions] Set OutDocNo=-1 where [ID]=" & _ID
                    End If
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                End If
            Next
        End With

        ' بناء الطرف المدين لسند الادخال ان وجد
        If _InRowsCount > 0 Then
            sqlstring = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,Referance,ReferanceName,DocCode,OrderID) Values ("
            sqlstring += "'" & _SessionData.DocDate & "'," ' DocDate
            sqlstring += "17," 'DocName
            sqlstring += "1," ' DocStatus
            sqlstring += "1," ' DocCostCenter
            sqlstring += "0," ' DebitAcc
            sqlstring += "'4020000000'," ' CredAcc
            sqlstring += _DefaultCurr & "," ' AccountCurr
            sqlstring += _DefaultCurr & "," ' DocCurrency
            sqlstring += _InRowsSum & "," ' DocAmount
            sqlstring += "1," ' ExchangePrice
            sqlstring += _InRowsSum & "," 'BaseCurrAmount
            sqlstring += _InRowsSum & "," 'BaseAmount
            sqlstring += "'" & _SessionID & "'," ' DocManualNo
            sqlstring += GlobalVariables.CurrUser & "," ' InputUser
            sqlstring += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
            sqlstring += "'" & _InputDateTime & "'," ' InputDateTime
            sqlstring += GlobalVariables.CurrUser & "," ' CurrentUserID
            sqlstring += "N'" & " Stock Adjustment For " & _SessionData.Details & "," & " جلسة رقم " & _SessionID & "'," ' DocNotes
            sqlstring += "0," ' StockID
            sqlstring += "0," ' Referance
            sqlstring += "''," ' ReferanceName
            sqlstring += "'" & _DocCodeIn & "',"
            sqlstring += "0" ' OrderID
            sqlstring += ") "
            sql.SqlTrueAccountingRunQuery(sqlstring)
        End If

        ' بناء الطرف الدائن لسند الاخراج للمشتريات ان وجد
        If _OutRowsCount > 0 Then
            sqlstring = " Insert into JournalTemp (DocDate,DocName,DocStatus,DocCostCenter,DebitAcc,CredAcc,AccountCurr,DocCurrency,
                                DocAmount,ExchangePrice,BaseCurrAmount,BaseAmount,DocManualNo,InputUser,DeviceName,InputDateTime,CurrentUserID,DocNotes,
                                StockID,Referance,ReferanceName,DocCode,OrderID) Values ("
            sqlstring += "'" & _SessionData.DocDate & "'," ' DocDate
            sqlstring += "18," 'DocName
            sqlstring += "1," ' DocStatus
            sqlstring += "1," ' DocCostCenter
            sqlstring += "'4020000000'," ' DebitAcc
            sqlstring += "0," ' CredAcc
            sqlstring += _DefaultCurr & "," ' AccountCurr
            sqlstring += _DefaultCurr & "," ' DocCurrency
            sqlstring += _OutRowsSum & "," ' DocAmount
            sqlstring += "1," ' ExchangePrice
            sqlstring += _OutRowsSum & "," 'BaseCurrAmount
            sqlstring += _OutRowsSum & "," 'BaseAmount
            sqlstring += "'" & _SessionID & "'," ' DocManualNo
            sqlstring += GlobalVariables.CurrUser & "," ' InputUser
            sqlstring += "'" & GlobalVariables.CurrDevice & "'," ' DeviceName
            sqlstring += "'" & _InputDateTime & "'," ' InputDateTime
            sqlstring += GlobalVariables.CurrUser & "," ' CurrentUserID
            sqlstring += "N'" & " Stock Adjustment For " & _SessionData.Details & "," & " جلسة رقم " & _SessionID & "'," ' DocNotes
            sqlstring += "0," ' StockID
            sqlstring += "0," ' Referance
            sqlstring += "''," ' ReferanceName
            sqlstring += "'" & _DocCodeOut & "',"
            sqlstring += "0" ' OrderID
            sqlstring += ") "
            sql.SqlTrueAccountingRunQuery(sqlstring)
        End If
        Dim _DocInID As Integer
        If _InRowsCount > 0 Then
            _DocInID = InsertDataFromTempToJournalWithLockTable(17, _DocCodeIn, 0)
            If _DocInID = 0 Then
                MsgBoxShowError(" خطا في ادخال بيانات سند الادخال ")
            Else
                sql.SqlTrueAccountingRunQuery(" Update [JardSavedSessions] Set [Settle]=1,InDocNo=" & _DocInID & " where [InDocNo]=-1")
                MsgBoxShowSuccess(" تم اصدار سند ادخال بضاعة  ")
            End If
        End If
        Dim _DocOutID As Integer
        If _OutRowsCount > 0 Then
            _DocOutID = InsertDataFromTempToJournalWithLockTable(18, _DocCodeOut, 0)
            If _DocOutID = 0 Then
                MsgBoxShowError(" خطا في ادخال بيانات سند الاخراج ")
            Else
                sql.SqlTrueAccountingRunQuery(" Update [JardSavedSessions] Set [Settle]=1,InDocNo=" & _DocOutID & " where [OutDocNo]=-1")
                MsgBoxShowSuccess(" تم اصدار سند اخراج بضاعة  ")
            End If
        End If

        GetSavedSessionData()


        '        If JournalTable.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (JournalTable.Rows.Count)) & "%" &
        '                                                                               " " & i + 1 & " From " & GridView1.RowCount)
        '    Next
        'End With

        ' InsertDataFromTempToJournal("Journal",)

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select * from JardSavedSessions where sessionID=" & _SessionID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles BtnSattle.Click
        BuildDocument()
    End Sub

    Private Sub RepositoryJardDocuments_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryJardDocuments.ButtonClick
        Dim _Id As Integer
        _Id = GridViewSessions.GetFocusedRowCellValue("ID")
        _SessionID = _Id
        TabbedControlGroup1.SelectedTabPage = TabJardDocuments
        GetJardDocuments(_SessionID)
    End Sub
    Private Sub RepositoryBtnSettlement_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryBtnSettlement.ButtonClick
        Dim _ID As Integer = GridViewSessions.GetFocusedRowCellValue("ID")
        _SessionID = _ID
        Dim _SessionData = GetSesssionData(_ID)

        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select count(*) as _Count from [JardSavedSessions] where [SessionID]=" & _SessionID
        sql.SqlTrueAccountingRunQuery(sqlstring)
        If sql.SQLDS.Tables(0).Rows(0).Item("_Count") = 0 Then
            MsgBoxShowError(" يجب حفظ التسوية قبل البدء باجراءات التسوية ")
            Exit Sub
        End If

        LabelWarehouseName.Text = " المستودع: " & _SessionData.WarehouseIDName
        LabelSessionDetails.Text = " الجلسة: " & _SessionData.Details
        LabelControlSessionDate.Text = " تاريخ الجلسة: " & _SessionData.DocDate
        BandedGridView1.OptionsSelection.MultiSelect = True
        BandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        LayoutBtnRefreshSattlement.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutBtnSattle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutBtnSaveSattleData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutBtnRefreshDataFromJournal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        TabbedControlGroup1.SelectedTabPage = TabSaveSettlement
        GetSavedSessionData()
    End Sub
    Private Sub RepositoryBtnSaveSession_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryBtnSaveSession.ButtonClick
        Dim _ID As Integer = GridViewSessions.GetFocusedRowCellValue("ID")
        _SessionID = _ID
        Dim _SessionData = GetSesssionData(_ID)
        LabelWarehouseName.Text = " المستودع: " & _SessionData.WarehouseIDName
        LabelSessionDetails.Text = " الجلسة: " & _SessionData.Details
        LabelControlSessionDate.Text = " تاريخ الجلسة: " & _SessionData.DocDate
        BandedGridView1.OptionsSelection.MultiSelect = False
        BandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
        LayoutBtnRefreshSattlement.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutBtnSattle.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutBtnSaveSattleData.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        LayoutBtnRefreshDataFromJournal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        TabbedControlGroup1.SelectedTabPage = TabSaveSettlement
        GetJardData(False)
    End Sub

    Private Sub SimpleButton3_Click_2(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        TabbedControlGroup1.SelectedTabPage = TabSessions
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        TabbedControlGroup1.SelectedTabPage = TabSessions
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        GetSavedSessionData()
    End Sub
    Private Sub GetSavedSessionData()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select * from [JardSavedSessions] where SessionID=" & _SessionID & " ")
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            MsgBoxShowError(" لا يوجد بيانات ")
            GridControl1.DataSource = Nothing
        Else
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        End If
    End Sub

    Private Sub BandedGridView1_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles BandedGridView1.ShowingEditor
        Dim val As Integer = Convert.ToInt32(BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "Settle"))
        If val = 1 Then e.Cancel = True
    End Sub

    Private Sub BandedGridView1_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles BandedGridView1.RowStyle
        Dim val As Integer = Convert.ToInt32(BandedGridView1.GetRowCellValue(e.RowHandle, "Settle"))
        If val = 1 Then e.Appearance.BackColor = System.Drawing.Color.DodgerBlue
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        GetJardDocuments(_SessionID)
    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Dim focusedRow As Integer = BandedGridView1.FocusedRowHandle
        Dim _ID As Integer = BandedGridView1.GetFocusedRowCellValue("ID")
        Dim F As New AccountingJardEditRowInSettle(_ID)
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetSavedSessionData()
            End If
        End With
        BandedGridView1.FocusedRowHandle = focusedRow
    End Sub



End Class