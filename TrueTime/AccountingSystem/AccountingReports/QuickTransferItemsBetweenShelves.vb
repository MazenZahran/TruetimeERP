Imports DevExpress.XtraGrid.Views.Tile

Public Class QuickTransferItemsBetweenShelves
    Private Sub QuickTransferItemsBetweenShelves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        searchFromWarehouse.Properties.DataSource = GetWharehouses(False)
        searchToWarehouse.Properties.DataSource = GetWharehouses(False)
    End Sub

    Private Sub searchFromWarehouse_EditValueChanged(sender As Object, e As EventArgs) Handles searchFromWarehouse.EditValueChanged
        If searchFromWarehouse.Text = "" Then searchFromShelf.Text = ""
        searchFromShelf.Properties.DataSource = GetShelves(searchFromWarehouse.EditValue)
        GetItemBalanceOnShelf()
    End Sub

    Private Sub searchToWarehouse_EditValueChanged(sender As Object, e As EventArgs) Handles searchToWarehouse.EditValueChanged
        If searchToWarehouse.Text = "" Then searchToShelf.Text = ""
        searchToShelf.Properties.DataSource = GetShelves(searchToWarehouse.EditValue)
        GetItemBalanceOnShelf()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If searchFromWarehouse.Text = "" Then
            MsgBoxShowError("يجب اختيار المخزن المنقول منه")
            searchFromWarehouse.Focus()
            Exit Sub
        End If
        If searchFromShelf.Text = "" Then
            MsgBoxShowError("يجب اختيار الرف المنقول منه")
            searchFromShelf.Focus()
            Exit Sub
        End If
        If searchToWarehouse.Text = "" Then
            MsgBoxShowError("يجب اختيار المخزن المنقول اليه")
            searchToWarehouse.Focus()
            Exit Sub
        End If
        If searchToShelf.Text = "" Then
            MsgBoxShowError("يجب اختيار الرف المنقول اليه")
            searchToShelf.Focus()
            Exit Sub
        End If
        If txtQuantity.EditValue > textQuantity1.EditValue Or txtQuantity.EditValue = 0 Then
            MsgBoxShowError("لا يوجد كمية كافية على الرف")
            txtQuantity.Focus()
            Exit Sub
        End If
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _DocCode = CreateRandomCode()
        Dim _DocID As Integer
        Dim _Result2 As Boolean
        _Result2 = False
        Dim _LogDetails As String = " Transfer Item from QuickTransferScreen "
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim _ApproveDocToVoucher As Boolean = True
        SqlString = " BEGIN TRANSACTION; "
        SqlString += " Declare @DocID int ; Set @DocID=" & GetDocNo(16, False)
        SqlString += " Insert into [Journal]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[StockBarcode],
                                       [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockPrice,
                                       StockDebitWhereHouse,StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                                       PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,
                                       [StockDebitShelve], [StockCreditShelve], ItemNo2 ) "
        SqlString += " Values "
        SqlString += " (@DocID,CONVERT(date, GETDATE()),16,1,0"
        SqlString += " " & ",N'" & txtBarcode.Text & "'"
        SqlString += " ,'4020000000','4020000000',1,1,0,1,0,0"
        SqlString += " ,'0',N'" & DocNote.Text & "','" & GlobalVariables.CurrUser & "','" & _LogDateTime & "'," & txtItemNo.Text & ",1"
        SqlString += "," & txtQuantity.Text & "," & txtQuantity.Text & ",0"
        SqlString += "," & searchToWarehouse.EditValue & "," & searchFromWarehouse.EditValue & "," & GlobalVariables.CurrUser & ",0,'',N'" & txtItemName.Text & "',0,'" & _DocCode & "'"
        SqlString += ",0,'','" & GlobalVariables.CurrDevice & "','1900-01-01','','" & "'"
        SqlString += "," & searchToShelf.EditValue & "," & searchFromShelf.EditValue & ",'" & txtItemNo2.Text & "')"
        SqlString += " ; Select @DocID as DocID "
        SqlString += " COMMIT TRANSACTION; "
        If sql.SqlTrueAccountingRunQuery(SqlString) = True Then
            _DocID = sql.SQLDS.Tables(0).Rows(0).Item("DocID")
            CreateDocLog("Document", _DocCode, 16, _DocID, "Insert", _LogDetails, Format(Now(), "yyyy-MM-dd HH:mm:ss"))
            Me.Close()
        End If


    End Sub

    Private Sub txtItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles txtItemNo.EditValueChanged
        If String.IsNullOrEmpty(txtItemNo.Text) Then
            Exit Sub
        End If
        'Dim _ItemData = GetItemsData(txtItemNo.Text, False)
        Dim repo As New ItemRepository()
        Dim item As ItemDetails = repo.GetItem(txtItemNo.Text, "False")
        txtBarcode.Text = item.UnitBarcode
        txtItemNo2.Text = item.ItemNo2
    End Sub
    Private Sub GetItemBalanceOnShelf()
        If searchFromWarehouse.Text <> "" And searchFromShelf.Text <> "" Then
            Me.textQuantity1.EditValue = GetItemBalanceByShelf(txtItemNo.EditValue, searchFromShelf.EditValue)
        End If
        If searchToWarehouse.Text <> "" And searchFromShelf.Text <> "" Then
            Me.textQuantity2.EditValue = GetItemBalanceByShelf(txtItemNo.EditValue, searchToShelf.EditValue)
        End If
    End Sub

    Private Sub searchFromShelf_EditValueChanged(sender As Object, e As EventArgs) Handles searchFromShelf.EditValueChanged
        GetItemBalanceOnShelf()
    End Sub

    Private Sub searchToShelf_EditValueChanged(sender As Object, e As EventArgs) Handles searchToShelf.EditValueChanged
        GetItemBalanceOnShelf()
    End Sub

    Private Sub SimpleBrowse1_Click(sender As Object, e As EventArgs) Handles SimpleBrowse1.Click
        Dim F3 As New PosSelectShelf
        With F3
            .TextItemNo.Text = txtItemNo.Text
            .Text = "رصيد صنف حسب الرف ( " & Me.txtItemName.Text & " )"
            .TextOpenFrom.Text = "QuickTransferItemsBetweenShelves"
            .StockCreditWhereHouse.EditValue = searchFromWarehouse.EditValue
            .GetDataForPosSelectShelf()
            If .ShowDialog() <> DialogResult.OK Then
                Me.searchFromShelf.EditValue = .TextShelf.Text
            End If
        End With
    End Sub

    Private Sub SimpleBrowse2_Click(sender As Object, e As EventArgs) Handles SimpleBrowse2.Click
        Dim F3 As New PosSelectShelf
        With F3
            .TextItemNo.Text = txtItemNo.Text
            .Text = "رصيد صنف حسب الرف ( " & Me.txtItemName.Text & " )"
            .TextOpenFrom.Text = "QuickTransferItemsBetweenShelves"
            .StockCreditWhereHouse.EditValue = searchToWarehouse.EditValue
            .GetDataForPosSelectShelf()
            If .ShowDialog() <> DialogResult.OK Then
                Me.searchToShelf.EditValue = .TextShelf.Text
            End If
        End With
    End Sub
End Class