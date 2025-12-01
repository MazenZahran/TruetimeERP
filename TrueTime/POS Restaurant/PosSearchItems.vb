Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DocumentFormat.OpenXml.Office2010.Excel

Public Class PosSearchItems
    Dim _DefaultWhareHouse As Integer
    Dim PosChangeItemPriceFromItemList As Boolean = False


    Private Sub PosSearchItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchItems()
        _DefaultWhareHouse = GetDefaultWharehouseForPos()
        SearchControl1.Select()
        ColItemNo2.Visible = GlobalVariables._ShowItemNo2
        ColItemNo3.Visible = GlobalVariables._ShowItemNo2
        ColItemNo4.Visible = GlobalVariables._ShowItemNo2
        SwitchKeyboardLayout("ar")
    End Sub
    Private Sub Getsettings()
        Dim sql As New SQLControl
        Try
            sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosChangeItemPriceFromItemList'")
            PosChangeItemPriceFromItemList = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: PosChangeItemPriceFromItemList")
            PosChangeItemPriceFromItemList = False
        End Try

        Try
            sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosShowColOpenItemInItemsList'")
            ColOpenItemsCard.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            ColOpenItemsCard.Visible = False
        End Try

    End Sub
    Private Sub SearchItems()
        Getsettings()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "   SELECT   [ItemNo]      ,[ItemName]	  ,Case When IU.unit_id=1 then U.[name] else Concat( U.[name] , '' , IU.EquivalentToMain ) end  As UnitName ,ItemNo2,ItemNo3,ItemNo4
	                          ,CAST(IU.Price1 AS DECIMAL(7,2) )  As UnitPrice,[item_unit_bar_code] as Barcode,G.GroupName,C.CategoryName,IU.unit_id,IU.id
                      FROM [Items_units] IU
                            left join Items I On I.ItemNo=IU.item_id
                            left Join Units U on U.id=IU.unit_id
                            left Join [dbo].[ItemsGroups] G on G.GroupID=I.GroupID
							left Join [dbo].ItemsCategories C on C.CategoryID=I.CategoryID
                     Where [ItemStatus]=1  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        ColUnitPrice.OptionsColumn.AllowEdit = PosChangeItemPriceFromItemList
    End Sub

    Private Sub TextItemName_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemName.EditValueChanged
        SearchItems()
    End Sub

    Private Sub RepositorySelect_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositorySelect.ButtonClick
        SelectItem()
    End Sub
    Private Sub SelectItem()
        Dim _Barcode As String = GridView1.GetFocusedRowCellValue("Barcode")
        Dim _ItemNo As String = GridView1.GetFocusedRowCellValue("ItemNo")
        Dim _Unit As Integer = GridView1.GetFocusedRowCellValue("unit_id")
        If GetItemTypeByBarcode(_Barcode) = 0 And GlobalVariables._POSuseShelves = True Then
            Dim F As New PosSelectShelf
            With F
                .DockPanel1.Close()
                .Text = "شاشة تحديد الرف"
                .TextItemBarcode.EditValue = _Barcode
                .GetDataForPosSelectShelf()
                If .ShowDialog() <> DialogResult.OK Then
                    'InsertIntoPOSJournal(_Barcode, 0, POSRestCashier.DocName.Text, 1, _DefaultWhareHouse, Me.DocCode.Text, 0, .TextShelf.EditValue, POSRestCashier.Referance.EditValue)
                    InsertIntoPOSJournalByStoredProcedure(_Barcode, POSRestCashier.DocName.Text, 1, _DefaultWhareHouse, Me.DocCode.Text, POSRestCashier.TextReferanceNo.EditValue, _ItemNo, 0, 0, "")
                End If
            End With
        Else
            '  InsertIntoPOSJournal(_Barcode, _ItemNo, My.Forms.POSRestCashier.DocName.EditValue, 1, _DefaultWhareHouse, DocCode.Text, 0, 0, POSRestCashier.Referance.EditValue, _Unit)
            If InsertIntoPOSJournalByStoredProcedure(_Barcode, POSRestCashier.DocName.Text, 1, _DefaultWhareHouse, Me.DocCode.Text, POSRestCashier.TextReferanceNo.EditValue, _ItemNo, _Unit, 0, "") > 0 Then
                My.Computer.Audio.Play(My.Resources.beep2, AudioPlayMode.Background)
            Else

            End If
        End If
        Me.Hide()
    End Sub

    Private Function GetItemTypeByBarcode(_Barcode As String) As Integer
        Dim _Type As Integer
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  select I.Type As ItemType from Items I
                                            left join Items_units U on I.ItemNo=U.item_id 
                                            where I.Type<>3 And U.item_unit_bar_code='" & _Barcode & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Type = sql.SQLDS.Tables(0).Rows(0).Item("ItemType")
        Catch ex As Exception
            _Type = 0
        End Try
        Return _Type

    End Function
    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        SearchItems()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Hide()
    End Sub
    Dim _AllowPriceChange As Boolean = True
    Sub gridView1_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        Dim sql As New SQLControl
        view.CloseEditor()
        If e.Column.FieldName = "UnitPrice" And _AllowPriceChange = True And PosChangeItemPriceFromItemList = True Then
            If XtraMessageBox.Show("هل تريد تعديل السعر للصنف؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _ItemNo As Integer
                Dim _ItemUnit As Integer
                Dim _ItemPrice As Decimal
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("UnitPrice")) Then
                    _ItemNo = GridView1.GetFocusedRowCellValue("ItemNo")
                    _ItemUnit = GridView1.GetFocusedRowCellValue("unit_id")
                    _ItemPrice = GridView1.GetFocusedRowCellValue("UnitPrice")
                    'MsgBox(_ItemPrice.ToString)
                    If CDec(_ItemPrice) > 10000 Then
                        MsgBoxShowError(" السعر خطا ")
                        _AllowPriceChange = False
                        GridView1.SetFocusedRowCellValue("UnitPrice", GetItemPrice(_ItemNo, _ItemUnit, "0"))
                        _AllowPriceChange = True
                        Exit Sub
                    End If
                    If sql.SqlTrueAccountingRunQuery(" update [dbo].[Items_units] set Price1=" & _ItemPrice & " where  item_id=" & _ItemNo & " And unit_id=" & _ItemUnit) = True Then
                        ' MsgBoxShowSuccess(" تم تعديل الرقم  ")
                        _AllowPriceChange = False
                        GridView1.SetFocusedRowCellValue("UnitPrice", _ItemPrice)
                        _AllowPriceChange = True
                    End If
                End If
            End If
        ElseIf e.Column.FieldName = "Barcode" And _AllowPriceChange = True And PosChangeItemPriceFromItemList = True Then
            If XtraMessageBox.Show("هل تريد تعديل الباركود للصنف؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _id As Integer
                Dim _Barcode As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("Barcode")) Then
                    _id = GridView1.GetFocusedRowCellValue("id")
                    _Barcode = GridView1.GetFocusedRowCellValue("Barcode")
                    If Len(_Barcode) > 20 Then
                        MsgBoxShowError(" الباركود خطا ")
                        _AllowPriceChange = False
                        SearchItems()
                        _AllowPriceChange = True
                        Exit Sub
                    End If
                    If ChangeItemBarcode(_id, _Barcode) = True Then
                        _AllowPriceChange = False
                        GridView1.SetFocusedRowCellValue("Barcode", _Barcode)
                        _AllowPriceChange = True
                    Else
                        MsgBoxShowError("خطا في تعديل الباركود")
                        SearchItems()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo"))
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            SearchItems()
        End If
    End Sub



    Private Sub RepositoryPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles RepositoryPrice.MouseUp
    End Sub

    Private Sub SearchControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchControl1.KeyDown
        If e.KeyCode = Keys.Down Then
            SearchControl1.Properties.Items.Clear()
            GridControl1.Focus()
        End If
    End Sub

    Private Sub SearchControl1_MouseUp(sender As Object, e As MouseEventArgs) Handles SearchControl1.MouseUp
        If SearchControl1.Text <> "" Then
            SearchControl1.SelectionStart = 0
            SearchControl1.SelectionLength = SearchControl1.Text.Length
        End If
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectItem()
        End If
    End Sub

    Private Sub SearchControl1_Properties_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles SearchControl1.Properties.ButtonClick
        If e.Button.Tag = "Refresh" Then
            SearchItems()
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class