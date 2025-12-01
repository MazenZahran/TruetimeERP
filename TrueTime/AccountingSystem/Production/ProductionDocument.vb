Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout
Imports DevExpress.XtraReports.UI
Imports System.Runtime.InteropServices
Imports GMap.NET
Public Class ProductionDocument
    Private _CostingMethod As String
    Private _EquationQuantity As Decimal
    Private Sub ProductionDocument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WarehousesTableAdapter.Fill(Me.AccountingDataSet.Warehouses)
        Me.UnitsTableAdapter.Fill(Me.AccountingDataSet.Units)
        SearchItems.Properties.DataSource = GetItemsHaveProductionEquation()
        Dim _ItemTable As New DataTable
        _ItemTable = GetItems(-1)
        Me.RepositoryRawItemNo.DataSource = _ItemTable
        Me.RepositoryItem.DataSource = _ItemTable
        Dim _WareHouse As New DataTable
        _WareHouse = GetWharehouses(False)
        StockDebitWhereHouse.Properties.DataSource = _WareHouse
        RepositoryItemWahreHouse.DataSource = _WareHouse
        LookCostCenter.Properties.DataSource = GetCostCenter(False)
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
        Me.DocStatus.Properties.DataSource = GetDocStatus(False)
        GetSettings()
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery("Select SettingValue from [dbo].[Settings] where SettingName='Accounting_CostingMethodInProduction'")
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _CostingMethod = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Else
            _CostingMethod = "LastPurchasePrice"
        End If
    End Sub
    Private Sub SearchItems_EditValueChanged(sender As Object, e As EventArgs) Handles SearchItems.EditValueChanged
        If Me.IsHandleCreated Then
            Dim _ItemData = GetItemsData(Me.SearchItems.EditValue, False)
            Me.SearchStockUnit.EditValue = _ItemData.DefaultUnit
            If String.IsNullOrWhiteSpace(SearchItems.Text) Then
                Exit Sub
            End If
            Me.ProductionEquationGridControl.DataSource = GetItemEquation(SearchItems.EditValue, True)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()
        Dim sql As New SQLControl
        Dim _DocLogName, _LogDetails As String
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Try
            If String.IsNullOrEmpty(SearchItems.Text) Or String.IsNullOrEmpty(SearchStockUnit.Text) Then
                XtraMessageBox.Show("خطا: لا يوجد صنف لانتاجه")
                Exit Sub
            End If

            If String.IsNullOrEmpty(StockDebitWhereHouse.Text) Then
                XtraMessageBox.Show("خطا: يجب اختيار مستودع")
                Exit Sub
            End If

            If String.IsNullOrEmpty(ItemQuantity.Text) Then
                XtraMessageBox.Show("خطا: لا يوجد كمية للانتاج")
                Exit Sub
            End If

            If ItemQuantity.EditValue = 0 Then
                XtraMessageBox.Show("خطا: لا يوجد كمية للانتاج")
                Exit Sub
            End If
            'g

            Try
                GridView1.PostEditor()
                GridView1.UpdateCurrentRow()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Dim sqlstring As String
            Dim _DocCode As String
            Dim _RowItemNo, _RawItemUnit As Integer
            Dim _DocID, _RowItemWahreHouse, _CostCenter As Integer
            Dim _RowItemPrice, _RawItemAmount, _RawItemQuantity, _ItemCost As Double
            Dim _DocNote, _InputDateTime, _DocDate, _ItemName As String
            If Me.TextNewOld.Text = "old" Then
                _DocCode = TextDocCode.Text
                _DocID = TextDocID.Text
            Else
                _DocCode = CreateRandomCode()
                TextDocCode.Text = _DocCode
                _DocID = TextDocID.Text
            End If
            Dim _Referance As String
            If String.IsNullOrEmpty(Referance.Text) Then
                _Referance = ""
            Else
                _Referance = Referance.EditValue
            End If
            _DocNote = Me.DocNotes.Text
            _CostCenter = LookCostCenter.EditValue
            _InputDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
            _DocDate = Format(DocDate.DateTime, "yyyy-MM-dd HH:mm")
            _ItemCost = Convert.ToDecimal(GridView1.Columns("RawItemAmount").SummaryItem.SummaryValue).ToString()
            For i = 0 To GridView1.RowCount - 1
                If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, "RawItemNo")) Then
                    _RowItemNo = GridView1.GetRowCellValue(i, "RawItemNo")
                    _RawItemUnit = GridView1.GetRowCellValue(i, "RawItemUnit")
                    _RowItemPrice = GridView1.GetRowCellValue(i, "RawItemPrice")
                    _RawItemAmount = GridView1.GetRowCellValue(i, "RawItemAmount")
                    _RawItemQuantity = GridView1.GetRowCellValue(i, "RawItemQuantity")
                    _RowItemWahreHouse = GridView1.GetRowCellValue(i, "StockCreditWhereHouse")
                    _ItemName = GridView1.GetRowCellValue(i, "RawItemName")
                    sqlstring = " 
                            Declare @DocID int;
                            Declare @ItemEquivalent as decimal (18,5);
                            Declare @ItemNo as int;
                            Set @DocID=" & _DocID & ";
                            Set @ItemNo=" & _RowItemNo & "
                            Set @ItemEquivalent= (Select EquivalentToMain from  [dbo].[Items_units]  where item_id=@ItemNo And unit_id= " & _RawItemUnit & " );
                            Insert INTO JournalTemp (
                            [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                            [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                            [BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
                            [InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
                            [StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
                            [DeviceName],[DocCode],ItemName,Referance,ReferanceName) 
                            Values ( @DocID,'" & _DocDate & "',19,1," & _CostCenter & ",
                            '0','4090000000', 1 ,1 ," & _RawItemAmount & " ,1 ,
                            " & _RawItemAmount & "," & _RawItemAmount & " ,0 ,0 ," & TextInputUser.EditValue & ",
                            '" & _InputDateTime & "',N'" & _DocNote & "'," & _RowItemNo & " ," & _RawItemUnit & "," & _RawItemQuantity & ", " & _RawItemQuantity & " * @ItemEquivalent,
                            " & _RowItemPrice & ", " & _RowItemPrice & "/@ItemEquivalent" & "  ,0 ," & _RowItemWahreHouse & " ,0,
                            '" & Me.TextDeviceName.Text & "','" & _DocCode & "',N'" & _ItemName & "','" & _Referance & "',N'" & Referance.Text & "'  )"
                    If sql.SqlTrueAccountingRunQuery(sqlstring) = False Then
                        sql.SqlTrueAccountingRunQuery("Delete from JournalTemp where DocCode='" & Me.TextDocCode.Text & "'")
                        Exit Sub
                    End If
                End If
            Next i
            sqlstring = "      
                            Insert INTO JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                            [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                            [BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
                            [InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
                            [StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
                            [DeviceName],[DocCode],ItemName,Referance,ReferanceName) 
                            Values 
                            ( " & _DocID & ",'" & _DocDate & "',19,1," & _CostCenter & ",
                            '4090000000','0', 1 ,1 ," & _ItemCost & " ,1,
                            " & _ItemCost & "," & _ItemCost & ",0 ,0 ," & TextInputUser.EditValue & ",
                            '" & _InputDateTime & "',N'" & _DocNote & "'," & SearchItems.EditValue & "," & SearchStockUnit.EditValue & " ,
                            " & ItemQuantity.EditValue & " , (  select top(1) EquivalentToMain * " & ItemQuantity.EditValue & "  from Items_units where item_id=" & SearchItems.EditValue & " and unit_id=" & SearchStockUnit.EditValue & " ) ,
                            " & _ItemCost / ItemQuantity.EditValue & ", " & _ItemCost / ItemQuantity.EditValue & "," & StockDebitWhereHouse.EditValue & ",0 ,'0',
                            '" & Me.TextDeviceName.Text & "','" & _DocCode & "',N'" & SearchItems.Text & "','" & _Referance & "',N'" & Referance.Text & "')  "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = False Then
                sql.SqlTrueAccountingRunQuery("Delete from JournalTemp where DocCode='" & Me.TextDocCode.Text & "'")
            End If
        Catch ex As Exception
            sql.SqlTrueAccountingRunQuery("Delete from JournalTemp where DocCode='" & Me.TextDocCode.Text & "'")
            MsgBox(ex.ToString)
        End Try

        Dim _AskBeforeSave As String = "0"
        Select Case TextNewOld.Text
            Case "old"
                _DocLogName = "Insert"
                _LogDetails = " New Voucher "
                _AskBeforeSave = "هل تريد تعديل السند"
            Case Else
                _DocLogName = "Insert"
                _LogDetails = " New Voucher "
                _AskBeforeSave = "هل تريد حفظ السند"
        End Select

        Dim SqlString3 As String = ""
        SqlString3 = "   Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                               [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID)"
        SqlString3 += " Select "
        If TextNewOld.Text = "new" Then
            SqlString3 += "( Select isnull(max([DocID])+1,1)  from Journal where DocName=19) "
        Else
            SqlString3 += "'" & Me.TextDocID.Text & "' "
        End If
        SqlString3 += " , [DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID
                                                from JournalTemp  "

        If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            If Me.TextNewOld.Text = "old" Then DeleteFromJournal(19, Me.TextDocID.Text)
            If sql.SqlTrueAccountingRunQuery(SqlString3) = True Then
                ChangePurchasePricesForProducedItem(Me.TextDocCode.Text)
                CreateDocLog("Document", Me.TextDocCode.Text, 19, Me.TextDocID.Text, _DocLogName, _LogDetails, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
                Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تمSaved السند بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
                XtraMessageBox.Show(args)
                Me.Dispose()
            End If
        End If
        sql.SqlTrueAccountingRunQuery("Delete from JournalTemp where DocCode='" & Me.TextDocCode.Text & "'")
    End Sub
    Private Sub ChangePurchasePricesForProducedItem(DocCode As String)
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "UPDATE Items 
SET items.LastPurchasePrice = JournalTemp.[BaseAmount]/JournalTemp.[StockQuantityByMainUnit],items.LastPurchaseDate=JournalTemp.DocDate 
FROM JournalTemp, items 
WHERE DocCOde='" & DocCode & "' And StockDebitWhereHouse<>0 And JournalTemp.StockID = items.ItemNo"
            sql.SqlTrueAccountingRunQuery(SqlString)
        Catch ex As Exception

        End Try

    End Sub
    Private Function GetItemEquation(ItemNo As Integer, WithHeader As Boolean) As DataTable
        Dim _Table As New DataTable
        Try
            If String.IsNullOrEmpty(ItemNo) Or IsNothing(ItemNo) Then
                Return _Table
            End If
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT [EquationID] ,P.[ItemNo],[ItemUnit],[ItemQuantity],
                                 [DocNote],[RawItemNo],[RawItemQuantity],[RawItemUnit],
                                 IsNull(LastPurchasePrice,0) *IU.EquivalentToMain As [RawItemPrice],[RawItemName],[EquationStatus],
	                             IsNull(LastPurchasePrice,0) * RawItemQuantity*IU.EquivalentToMain As RawItemAmount,[StockCreditWhereHouse]
                          FROM [dbo].[ProductionEquation] P
                          Left Join Items I on I.ItemNo=P.RawItemNo 
						  left join Items_units IU on IU.item_id=P.RawItemNo And IU.unit_id=P.RawItemUnit 
                          Where P.ItemNo=" & ItemNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Table = sql.SQLDS.Tables(0)
                Me.StockDebitWhereHouse.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("StockCreditWhereHouse")
                If WithHeader = True Then GetEquationHeader()

                If _CostingMethod = "WeightedAverageCost" Then
                    For i = 0 To _Table.Rows.Count - 1
                        Dim _ItemNo As Integer = _Table.Rows(i).Item("RawItemPrice")
                        Dim _UnitID As Integer = _Table.Rows(i).Item("RawItemUnit")
                        _Table.Rows(i).Item("RawItemPrice") = GetLastPurchasePriceByAverage(_ItemNo, _UnitID)
                        _Table.Rows(i).Item("RawItemAmount") = _Table.Rows(i).Item("RawItemPrice") * _Table.Rows(i).Item("RawItemQuantity")
                    Next
                End If


                'If _CostingMethod = "WeightedAverageCost" Then
                '    RecalcultePrices()
                'End If
            Else
                XtraMessageBox.Show("لا يوجد معادلة انتاج للصنف")
            End If
        Catch ex As Exception

        End Try
        Return _Table
    End Function
    Private Sub GetEquationHeader()
        _EquationQuantity = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("select top(1) [ItemNo],[ItemUnit],[EquationID],[DocNote],ItemQuantity 
                                              from [dbo].[ProductionEquation] 
                                              where [ItemNo]= " & SearchItems.EditValue)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Me.SearchItems.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
                Me.SearchStockUnit.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemUnit")
                Me.DocNotes.Text = sql.SQLDS.Tables(0).Rows(0).Item("DocNote")
                Me.ItemQuantity.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemQuantity")
                _EquationQuantity = sql.SQLDS.Tables(0).Rows(0).Item("ItemQuantity")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private edit As BaseEdit = Nothing
    Dim _FieldName As String
    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor

        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
        If view.FocusedColumn.FieldName = "RawItemUnit" Then

            Dim editor As SearchLookUpEdit = CType(view.ActiveEditor, SearchLookUpEdit)
            Dim _StockID As String = Convert.ToString(view.GetFocusedRowCellValue("RawItemNo"))
            If String.IsNullOrEmpty(_StockID) Then Exit Sub
            editor.Properties.DataSource = GetUnitsForItems(_StockID)
        End If

    End Sub
    Private Function GetUnitsForItems(ItemNo As Integer) As DataTable
        Dim _Units As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select unit_id as id,U.name as [name]  
                                            from [Items_units] IU 
                                            left join Units U on U.id=IU.unit_id 
                                            where item_id=" & ItemNo)
            _Units = sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Units
        End Try
        Return _Units
    End Function
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        With GridView1
            Try
                .PostEditor()
                Dim _StockID As String = "0"
                Dim _StockBarCode As String = "0"
                Try
                    _StockID = .GetFocusedRowCellValue("RawItemNo")
                Catch ex As Exception
                    _StockID = "0"
                End Try
                Select Case _FieldName
                    Case "RawItemNo"
                        If _StockID <> "0" Then
                            Dim ItemData = GetItemsData(_StockID, False)
                            .SetFocusedRowCellValue("RawItemName", ItemData.ItemName)
                            If .GetFocusedRowCellValue("RawItemQuantity") = 1 Then .SetFocusedRowCellValue("RawItemQuantity", 1)
                            .SetFocusedRowCellValue("RawItemPrice", ItemData.LastPurchasePrice * ItemData.EquivalentToMain)
                            .SetRowCellValue(.FocusedRowHandle, "RawItemUnit", ItemData.DefaultUnit)
                        End If

                    Case "RawItemQuantity"
                        If IsDBNull(.GetFocusedRowCellValue("RawItemQuantity")) Then
                            Exit Sub
                        End If
                        Dim UnitID As Integer = 0
                        Try
                            UnitID = .GetFocusedRowCellValue("RawItemUnit")
                        Catch ex As Exception
                            UnitID = 0
                        End Try
                    Case "StockPrice"

                    Case "StockDiscount"

                    Case "RawItemUnit"
                        Try
                            Dim _Item_Unit_ID As Integer
                            Dim _EquivalentToMain As Decimal
                            Dim _RowItemCost As Decimal
                            _Item_Unit_ID = .GetFocusedRowCellValue("RawItemUnit")
                            If String.IsNullOrEmpty(_Item_Unit_ID) Then Exit Sub
                            Dim Sql As New SQLControl
                            Sql.SqlTrueAccountingRunQuery(" Select LastPurchasePrice, item_unit_bar_code,EquivalentToMain
                                                            From Items I Left Join  [dbo].[Items_units] IU on I.ItemNo=IU.item_id
                                                            where [ItemNo]='" & _StockID & "' and [unit_id]=" & _Item_Unit_ID)
                            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")) Then
                                _EquivalentToMain = Sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")
                            Else
                                _EquivalentToMain = 0
                            End If
                            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")) Then
                                _RowItemCost = Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
                            Else
                                _RowItemCost = 0
                            End If
                            .SetFocusedRowCellValue("RawItemPrice", _EquivalentToMain * _RowItemCost)
                        Catch ex As Exception
                            MsgBox("لا يمكن اختيار هذه الوحدة، فهي غير معرفة لهذا الصنف")
                            .SetFocusedRowCellValue("RawItemPrice", 0)
                            .SetFocusedRowCellValue("RawItemUnit", String.Empty)
                            MsgBox(ex.ToString)
                        End Try
                End Select
                Dim _Temp1 As Decimal = .GetFocusedRowCellValue("RawItemQuantity")
                Dim _Temp2 As Decimal = .GetFocusedRowCellValue("RawItemPrice")
                .SetRowCellValue(.FocusedRowHandle, "RawItemAmount", (_Temp1 * _Temp2))
                GridView1.UpdateCurrentRow()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            GlobalVariables._TempItemNo = 0
        End With

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        Me.GridView1.SetRowCellValue(e.RowHandle, "RawItemQuantity", 1)
        Me.GridView1.SetRowCellValue(e.RowHandle, "StockCreditWhereHouse", 1)
        Select Case GridView1.RowCount
            Case 10
                Me.GridView1.IndicatorWidth = 30
            Case 99
                Me.GridView1.IndicatorWidth = 100
        End Select
    End Sub

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        Select Case TextNewOld.Text
            Case "new"
                Me.LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
                Me.TextDocID.EditValue = GetDocNo(19, True)
                Me.DocDate.DateTime = Today()
                Me.TextInputUser.Text = GlobalVariables.CurrUser
                Me.TextDeviceName.Text = GlobalVariables.CurrDevice
                Me.StockDebitWhereHouse.EditValue = GetDefaultWharehouse()
            Case "old"

        End Select
    End Sub

    Private Sub ItemQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles ItemQuantity.EditValueChanged

        SetEnglishKeyboardLayout()
        If Me.IsHandleCreated Then
            'If XtraMessageBox.Show("سيتم تجاهل التغييرات في السند هل تريد المتابعة؟", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            '    Exit Sub
            'End If
            'GetItemEquation(SearchItems.EditValue, False)
            Me.ProductionEquationGridControl.DataSource = GetItemEquation(SearchItems.EditValue, False)
            Dim EquationQuantity As Decimal = _EquationQuantity
            If EquationQuantity = 0 Then Exit Sub
            Dim _Quantity As Decimal
            If String.IsNullOrEmpty(ItemQuantity.Text) Then
                Exit Sub
            End If
            _Quantity = ItemQuantity.EditValue
            Dim i As Integer
            For i = 0 To GridView1.DataRowCount - 1
                Dim rawNoObj = GridView1.GetRowCellValue(i, "RawItemNo")
                If rawNoObj Is Nothing OrElse IsDBNull(rawNoObj) OrElse String.IsNullOrEmpty(rawNoObj.ToString()) Then
                    Continue For
                End If

                Dim qObj = GridView1.GetRowCellValue(i, "RawItemQuantity")
                Dim pObj = GridView1.GetRowCellValue(i, "RawItemPrice")
                Dim _RawItemQuantity As Decimal = If(qObj Is Nothing OrElse IsDBNull(qObj), 0D, Convert.ToDecimal(qObj))
                Dim _RawItemPrice As Decimal = If(pObj Is Nothing OrElse IsDBNull(pObj), 0D, Convert.ToDecimal(pObj))

                If _Quantity <> 0 Then
                    GridView1.SetRowCellValue(i, "RawItemQuantity", _Quantity * _RawItemQuantity / EquationQuantity)
                    GridView1.SetRowCellValue(i, "RawItemPrice", _RawItemPrice / EquationQuantity)
                    GridView1.SetRowCellValue(i, "RawItemAmount", _Quantity * _RawItemQuantity * _RawItemPrice / EquationQuantity)
                End If
            Next
        End If
    End Sub

    Private Sub TextQueryID_EditValueChanged(sender As Object, e As EventArgs) Handles TextQueryID.EditValueChanged


        Try
            Dim sql As New SQLControl
            Dim sqlstring, sqlstring2 As String
            sqlstring = " SELECT Top(1)  [DocID],[DocDate],[DocStatus],[DocCostCenter],
                                     [DocAmount],[DocSort],[DocManualNo],[Referance],
                                     [InputUser],[InputDateTime],[DocNotes],[StockDebitWhereHouse],
                                     [DocCode],[DeviceName],[LastDocCode],[StockID],[StockUnit],[StockQuantity]
                      FROM [dbo].[Journal] 
                      Where DocID='" & TextQueryID.EditValue & "' And DocName = " & 19 & " And [StockDebitWhereHouse]<>0 "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    With sql.SQLDS.Tables(0).Rows(0)
                        TextDocID.Text = .Item("DocID")
                        DocDate.DateTime = .Item("DocDate")
                        DocStatus.EditValue = .Item("DocStatus")
                        If DocStatus.EditValue = 3 Or DocStatus.EditValue = 4 Then
                            DocStatus.BackColor = Color.Red
                            GridView1.OptionsBehavior.Editable = False
                            DocManualNo.ReadOnly = True
                            DocDate.ReadOnly = True
                            LookCostCenter.ReadOnly = True
                            StockDebitWhereHouse.ReadOnly = True
                            SearchItems.ReadOnly = True
                            SearchStockUnit.ReadOnly = True
                            ItemQuantity.ReadOnly = True
                            Referance.ReadOnly = True
                            DocNotes.ReadOnly = True
                            LayoutSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        End If
                        If Not IsDBNull(.Item("DocCostCenter")) Then LookCostCenter.EditValue = .Item("DocCostCenter")
                        If Not IsDBNull(.Item("Referance")) Then Referance.EditValue = .Item("Referance")
                        If Not IsDBNull(.Item("DocManualNo")) Then DocManualNo.EditValue = .Item("DocManualNo")
                        If Not IsDBNull(.Item("InputUser")) Then
                            BarInputUser.Caption = .Item("InputUser")
                            TextInputUser.EditValue = .Item("InputUser")
                        End If
                        If Not IsDBNull(.Item("DeviceName")) Then
                            BarDeviceName.Caption = .Item("DeviceName")
                            Me.TextDeviceName.Text = .Item("DeviceName")
                        End If
                        BarInputDateTime.Caption = .Item("InputDateTime")
                        If Not IsDBNull(.Item("DocNotes")) Then Me.DocNotes.Text = .Item("DocNotes")
                        StockDebitWhereHouse.EditValue = .Item("StockDebitWhereHouse")
                        TextDocCode.Text = .Item("DocCode")
                        If Not IsDBNull(.Item("LastDocCode")) Then LastDocCode.Text = .Item("LastDocCode")
                        If Not IsDBNull(.Item("StockID")) Then SearchItems.EditValue = .Item("StockID")
                        If Not IsDBNull(.Item("StockUnit")) Then SearchStockUnit.EditValue = .Item("StockUnit")
                        If Not IsDBNull(.Item("StockQuantity")) Then ItemQuantity.EditValue = .Item("StockQuantity")

                    End With
                End If
            End If
            sqlstring2 = " SELECT [StockID] As RawItemNo ,[StockUnit] As RawItemUnit,[StockQuantity] As RawItemQuantity,[StockPrice] As RawItemPrice,
                              [StockCreditWhereHouse] As StockCreditWhereHouse ,[ItemName] as RawItemName, DocAmount As RawItemAmount
                      FROM [dbo].[Journal] 
                      Where  [StockCreditWhereHouse]<>0 And DocID='" & TextQueryID.EditValue & "' And DocName = " & 19
            If sql.SqlTrueAccountingRunQuery(sqlstring2) = True Then
                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    ProductionEquationGridControl.DataSource = sql.SQLDS.Tables(0)
                End If
            End If
        Catch ex As Exception
            MsgBox(" خطأ في البيانات")
        End Try


    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If DeleteDoc(19, TextDocID.EditValue, Me.TextDocCode.Text, True) = True Then
            Me.Dispose()
        End If
    End Sub

    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles ProductionEquationGridControl.ProcessGridKey
        Dim sql As New SQLControl
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso e.Control AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
                GridView1.UpdateSummary()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            ItemsSearchMenue.LayoutSelectItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            ItemsSearchMenue.ShowDialog()
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                _FieldName = "StockID"
                GridView1.SetFocusedRowCellValue("RawItemNo", GlobalVariables._TempItemNo)
                Edit_EditValueChanged(sender, e)
                GlobalVariables._TempItemNo = 0
            Else
                Dim _String As String = "0"
                Try
                    If Not IsNothing(GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "RawItemNo")) Then
                        _String = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "RawItemNo").ToString()
                    End If
                Catch ex As Exception
                    _String = "0"
                End Try
                If _String = "0" Then
                    GridView1.AddNewRow()
                    _FieldName = "StockID"
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                    Edit_EditValueChanged(sender, e)
                Else
                    _FieldName = "StockID"
                    GridView1.SetFocusedRowCellValue("RawItemNo", GlobalVariables._TempItemNo)
                    Edit_EditValueChanged(sender, e)
                End If
                GlobalVariables._TempItemNo = 0
            End If
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count <> 0 Then
            GlobalVariables._ItemsTable = dt
            XtraMessageBox.Show("تم نسخ السند، يمكنك فتح سند جديد ولصقه")
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ل.ItemClick
        If Me.TextNewOld.Text = "old" Then
            XtraMessageBox.Show("خطأ: يجب فتح سند جديد لكي يتم لصق المحتويات")
            Exit Sub
        Else
            ProductionEquationGridControl.DataSource = GlobalVariables._ItemsTable
        End If
        'Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        'If dt.Rows.Count > 0 Then
        '    If XtraMessageBox.Show("سيتم حذف الأصناف بالفاتورة هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '        Dim i As Integer = 0
        '        While i < GridView1.RowCount
        '            GridView1.DeleteRow(i)
        '        End While
        '    Else
        '        Exit Sub
        '    End If
        'End If

    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
        XtraMessageBox.Show("تم نسخ النص الى الحافظة كملف نصي")
    End Sub

    Private Sub أخرأسعارالشراءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles أخرأسعارالشراءToolStripMenuItem.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")
            .TextPurchaseOrSale.Text = 1
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemName")
            .Text = "  اسعار الشراء ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemName") & " ) "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub حركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")
            .Warehouses.Text = 1
            .Text = " حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemName") & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        My.Forms.JournalForDocument.GridControl1.DataSource =
    GetJournalForTrans(19, Me.TextDocID.EditValue)
        My.Forms.JournalForDocument.ShowDialog()
    End Sub

    Private Sub تفاصيلالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تفاصيلالصنفToolStripMenuItem.Click
        My.Forms.Items.ItemNo.EditValue = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")
        Items.ShowDialog()
    End Sub
    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _StockQuantity As GridColumn = view.Columns("RawItemQuantity")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemQuantity")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الكمية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockQuantity
                view.ShowEditor()
            End If
            'If CDec(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemQuantity")) = 0 Then
            '    e.Valid = False
            '    e.ErrorText = "يجب ادخال الكمية"
            '    view.FocusedRowHandle = e.RowHandle
            '    view.FocusedColumn = _StockQuantity
            '    view.ShowEditor()
            'End If

            Dim _StockID As GridColumn = view.Columns("RawItemNo")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockID
                view.ShowEditor()
            End If

            If Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo") = "0" Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockID
                view.ShowEditor()
            End If
            Dim _StockUnit As GridColumn = view.Columns("RawItemUnit")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemUnit")) = True Then
                e.Valid = False
                e.ErrorText = "يجب اختيار وحدة الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockUnit
                view.ShowEditor()
            End If
        Catch ex As Exception

        End Try




    End Sub

    Private Sub StockDebitWhereHouse_EditValueChanged(sender As Object, e As EventArgs) Handles StockDebitWhereHouse.EditValueChanged
        'For i As Integer = 0 To GridView1.DataRowCount - 1
        '    '  GridView1.SetRowCellValue(i, colWarehouseID, StockDebitWhereHouse.EditValue)
        '    GridView1.SetRowCellValue(i, "StockCreditWhereHouse", StockDebitWhereHouse.EditValue)
        'Next
    End Sub
    ' Import necessary Windows API functions
    Private Declare Function LoadKeyboardLayout Lib "user32.dll" Alias "LoadKeyboardLayoutW" (ByVal pwszKLID As String, ByVal Flags As UInteger) As IntPtr
    Private Declare Function GetKeyboardLayoutName Lib "user32.dll" Alias "GetKeyboardLayoutNameW" (ByVal pwszKLID As String) As Boolean

    ' Constants for English keyboard layout ID
    Private Const ENG_US As String = "00000409"
    Private Sub SetEnglishKeyboardLayout()
        'Dim currentLayout As String = New String(ChrW(0), 9)
        'GetKeyboardLayoutName(currentLayout)

        '' Check if the current layout is already English (US)
        'If Not currentLayout.StartsWith(ENG_US) Then
        '    ' Load the English (US) keyboard layout
        '    Dim result As IntPtr = LoadKeyboardLayout(ENG_US, 1)
        '    If result = IntPtr.Zero Then
        '        ' Handle error if the layout couldn't be loaded
        '        MessageBox.Show("Failed to set English keyboard layout")
        '    End If
        'End If
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick

    End Sub
    Private Sub RecalcultePrices()
        If _CostingMethod = "WeightedAverageCost" Then
            For i As Integer = 0 To GridView1.DataRowCount - 1
                Dim itemNo As Integer = GridView1.GetRowCellValue(i, "RawItemNo")
                Dim unitID As Integer = GridView1.GetRowCellValue(i, "RawItemUnit")
                GridView1.SetRowCellValue(i, "RawItemPrice", GetAveragePriceForItemNo(itemNo, unitID))
            Next
        End If
    End Sub
    Private Function GetAveragePriceForItemNo(ItemNo As Integer, UnitID As Integer) As Decimal
        Dim _Price As Decimal = 0
        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = "
                Declare @ItemNo int
                Set @ItemNo = " & ItemNo & "
                Declare @Unit int
                Set @Unit = " & UnitID & "
                Declare @Equivalent decimal(18,2)
                Set @Equivalent = (select EquivalentToMain from Items_units where item_id = @ItemNo AND unit_id = @Unit)
                Declare @AvgPriceForUnit decimal(18,2)
                Declare @AvgPriceForMainUnit as decimal(18,2)
                Set @AvgPriceForMainUnit = (
                    Select Sum(DocAmount) / Sum(StockQuantityByMainUnit) 
                    From Journal 
                    Where DocStatus <> 0 AND DocName in (1, 17) AND StockID = @ItemNo
                )
                Set @AvgPriceForUnit = @AvgPriceForMainUnit * @Equivalent
                select 
                    @AvgPriceForMainUnit As AvgPriceForMainUnit, 
                    @AvgPriceForUnit As AvgPriceForUnit, 
                    @Equivalent As Equivalent "
            sql.SqlTrueAccountingRunQuery(sqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Price = sql.SQLDS.Tables(0).Rows(0).Item("AvgPriceForUnit")
            End If
        Catch ex As Exception
        End Try
        Return _Price
        Return 0
    End Function

    Private Sub ItemQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles ItemQuantity.MouseUp
        TextEditSelectText(ItemQuantity)
    End Sub
End Class