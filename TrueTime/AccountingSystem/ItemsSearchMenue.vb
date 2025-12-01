
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports GridView = DevExpress.XtraGrid.Views.Grid.GridView

Public Class ItemsSearchMenue
    Private Sub ItemsSearchMenue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GridControlItems.Focus()
        GetItems()
        ' SearchControl1.Select()
        CheckButton1.Appearance.BackColor = Color.Red
        CheckButton1.Appearance.ForeColor = Color.Black
        ColItemName.OptionsColumn.AllowEdit = False
        ColBarcode.OptionsColumn.AllowEdit = False
        ColUnitPrice.OptionsColumn.AllowEdit = False
        ' SearchControl1.EditValue = String.Empty
        ColItemName.BestFit()
        If GlobalVariables._WareHouseUseShelf = False Then
            ToolStripMenuItemBalanceOnShelf.Visible = False
        End If
        Me.KeyPreview = True
        If GlobalVariables._UserAccessType = 99 Then
            LayoutEditMode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        ' SearchControl1.Select()
        'If GlobalVariables.HasPrintBarcodeService = False Then
        '    ColPrintBarcode.Visible = False
        'End If
    End Sub

    Private Sub ItemsSearchMenue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetItems()
        ElseIf e.KeyCode = Keys.F1 Then
            SearchControl1.Focus()
        End If
    End Sub
    Private Sub SearchControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles SearchControl1.KeyDown
        If e.KeyCode = Keys.Down Then
            GridControlItems.Focus()
            If GridView1.RowCount > 0 Then
                GridView1.FocusedRowHandle = 0
            End If
            e.Handled = True
        End If
    End Sub
    Private Sub GetItems()
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        My.Forms.Main.ItemElapseTime.Caption = (0)
        start_time = Now
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try
            Try
                Dim SqlString As String
                Dim sql As New SQLControl
                SqlString = " select I.[id],[Type],[ItemNo],[ItemName],[HasExpireDate] "
                If EmployeeAccess._ShowItemCost = True Then
                    SqlString += ",[LastPurchasePrice],[LastPurchaseDate] "
                End If
                SqlString += ",[ReOrderQuantity],[notes],[AccSales],[AccPurches]
                              ,[AccRetSales],[AccRetPurches],U.[name] As UnitName,IU.Price1 As UnitPrice
                              ,C.CategoryName,T.TradeMarkName,IU.id as ItemUnitID,IsNull(ItemNo2,'0') as ItemNo2
                              ,IsNull(ItemNo3,'0') as ItemNo3,IsNull(ItemNo4,'0') as ItemNo4,IU.item_unit_bar_code,G.GroupName
                              ,IU.[unit_id] as unit_id,IC.ColorName As ColorName
                              ,IM.MeasureName As  MeasureName,IC.ID as ColorID,IM.ID as MeasureID,ProductCompany
                            from Items_units IU
                            left join Items I on I.ItemNo=IU.item_id 
                            left Join Units U on U.id=IU.unit_id
                            left Join [dbo].[ItemsCategories] C on C.CategoryID=I.CategoryID
                            left Join [dbo].[ItemsTradeMark] T on T.TradeMarkID=I.TradeMarkID 
                            left join dbo.ItemsGroups G on G.GroupID=I.GroupID  
                            left join ItemsColors IC on IU.Color=IC.ID
                            left Join ItemsMeasures IM on IU.Measure=IM.ID 
                            where I.Type<>3 And [ItemStatus] =1  order by ItemNo "
                sql.SqlTrueAccountingRunQuery(SqlString)
                GridControlItems.DataSource = sql.SQLDS.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Finally
            CloseProgressPanel(handle)
        End Try
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
        GridView1.FocusedRowHandle = focusedRow
        'SearchControl1.Select()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Sub gridView1_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Dim view As ColumnView = TryCast(sender, ColumnView)
        view.CloseEditor()
        If e.Column.FieldName = "item_unit_bar_code" Then
            If XtraMessageBox.Show("هل تريد تعديل الباركود؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                GetItems()
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _ItemUnitID As Integer
                Dim _item_unit_bar_code, _ItemNo2 As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemUnitID")) Then
                    _ItemUnitID = GridView1.GetFocusedRowCellValue("ItemUnitID")
                    _item_unit_bar_code = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
                    _ItemNo2 = GridView1.GetFocusedRowCellValue("ItemNo2")
                    If GlobalVariables._Shalash = True Then
                        If _ItemNo2 = _item_unit_bar_code Then
                            MsgBox("لا يمكن تعديل الباركود لانه نفس رقم الصنف")
                            GetItems()
                            Exit Sub
                        End If
                    End If
                    UpdateItemBarcode(_ItemUnitID, _item_unit_bar_code)
                End If
                End If
        End If

        If e.Column.FieldName = "ItemName" Then
            If XtraMessageBox.Show("هل تريد تعديل اسم الصنف؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                GetItems()
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _ItemID As Integer
                Dim _ItemName As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("id")) Then
                    _ItemID = GridView1.GetFocusedRowCellValue("id")
                    _ItemName = GridView1.GetFocusedRowCellValue("ItemName")
                    UpdateItemName(_ItemID, _ItemName)
                End If
            End If
        End If

        If e.Column.FieldName = "UnitPrice" Then
            If XtraMessageBox.Show("هل تريد تعديل سعر الصنف؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                GetItems()
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _item_id As String
                Dim _unit_id As Integer
                Dim _Price1 As Decimal
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("UnitPrice")) Then
                    _item_id = GridView1.GetFocusedRowCellValue("ItemNo")
                    _Price1 = GridView1.GetFocusedRowCellValue("UnitPrice")
                    _unit_id = GridView1.GetFocusedRowCellValue("unit_id")
                    UpdateItemPrice(_Price1, _item_id, _unit_id)
                End If
            End If
        End If
    End Sub
    Private Sub UpdateItemBarcode(_PriceUnitID As Integer, _item_unit_bar_code As String)
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            Dim SQl As New SQLControl
            Dim SqlString As String
            If CheckIfBarcodeFound(_item_unit_bar_code) = False Then
                SqlString = " Update Items_units 
                      Set item_unit_bar_code='" & _item_unit_bar_code & "' 
                      where id =" & _PriceUnitID
                If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                    XtraMessageBox.Show("لم يتم تعديل الباركود")
                    GetItems()
                End If
            Else
                CloseProgressPanel(Handle)
                XtraMessageBox.Show("الباركود مكرر")
                GetItems()
            End If
        Finally
            CloseProgressPanel(Handle)
        End Try
    End Sub

    Private Sub UpdateItemName(_ItemID As Integer, _ItemName As String)
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            Dim SQl As New SQLControl
            Dim SqlString As String
            SqlString = " Update Items 
                      Set [ItemName]=N'" & _ItemName & "' 
                      where id =" & _ItemID
            If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                XtraMessageBox.Show("لم يتم تعديل اسم الصنف")
                GetItems()
            End If
        Finally
            CloseProgressPanel(Handle)
        End Try
    End Sub
    Private Sub UpdateItemPrice(_Price1 As Decimal, _item_id As String, _unit_id As Integer)
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            Dim SQl As New SQLControl
            Dim SqlString As String
            SqlString = " Update Items_units 
                      Set [Price1]=N'" & _Price1 & "' 
                      where item_id ='" & _item_id & "' and unit_id=" & _unit_id
            If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                XtraMessageBox.Show("لم يتم تعديل سعر الصنف")
                GetItems()
            End If
        Finally
            CloseProgressPanel(Handle)
        End Try
        GetItems()
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetItems()
    End Sub
    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        ' Get selected rows
        Dim selectedRows As Integer() = GridView1.GetSelectedRows()
        Dim selectedCount As Integer = selectedRows.Length

        ' Show the count in the button text
        BtnAddSelectedItemsToVouchers.Text = $"تم اختيار : {selectedCount}"
    End Sub
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControlItems.ProcessGridKey
        If e.KeyCode = Keys.Enter AndAlso GlobalVariables._UserAccessType <> 99 Then
            Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
            If view Is Nothing Then Return
            If e.KeyCode = Keys.Enter AndAlso GlobalVariables._UserAccessType <> 99 Then
                If view.ActiveEditor IsNot Nothing Then Return
                e.Handled = True
                CollectSelectedRowsToGlobalVariables()
                Me.Dispose()
            End If
        End If
    End Sub
    Private Sub CollectSelectedRowsToGlobalVariables()
        ' Get selected rows
        Dim selectedRows As Integer() = GridView1.GetSelectedRows()

        ' Create lists to store multiple values
        Dim itemNos As New List(Of Integer)
        Dim barcodes As New List(Of String)
        Dim colors As New List(Of String)
        Dim measures As New List(Of String)

        ' Loop through selected rows and collect values
        For Each rowHandle In selectedRows
            ' Get ItemNo
            Dim itemNo As Integer = GridView1.GetRowCellValue(rowHandle, "ItemNo")
            itemNos.Add(itemNo)

            ' Get Barcode
            Dim barcode As String = GridView1.GetRowCellValue(rowHandle, "item_unit_bar_code")
            barcodes.Add(barcode)

            ' Get Color
            Dim color As String = "0"
            If Not IsDBNull(GridView1.GetRowCellValue(rowHandle, "ColorID")) Then
                color = GridView1.GetRowCellValue(rowHandle, "ColorID")
            End If
            colors.Add(color)

            ' Get Measure 
            Dim measure As String = "0"
            If Not IsDBNull(GridView1.GetRowCellValue(rowHandle, "MeasureID")) Then
                measure = GridView1.GetRowCellValue(rowHandle, "MeasureID")
            End If
            measures.Add(measure)
        Next

        ' Store the lists in GlobalVariables
        GlobalVariables._TempItemNos = itemNos
        GlobalVariables._ItemBarcodesGlobal = barcodes
        GlobalVariables._ItemColorIDsGlobal = colors
        GlobalVariables._ItemMeasureIDsGlobal = measures

        Me.Close()
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo"))
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        End If
    End Sub

    Private Sub GridView1_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles GridView1.ValidateRow

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControlItems.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButtonSelect.Click
        If Me.TextFromForm.Text = "PosSelectShelf" Then
            GlobalVariables._ItemBarcodeGlobal = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
            GlobalVariables._ItemNoGlobal = GridView1.GetFocusedRowCellValue("ItemNo")
            GlobalVariables._ItemNameGlobal = GridView1.GetFocusedRowCellValue("ItemName")
            Me.Close()
        ElseIf Me.TextFromForm.Text = "StockBalanceBywarehouse" Then
            GlobalVariables._TempItemNo = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
            GlobalVariables._TempItemName = GridView1.GetFocusedRowCellValue("ItemName")
            Me.Close()
        Else
            Dim ItemsTable As New DataTable
            Dim ItemsTable2 As New DataTable
            ItemsTable.Columns.Add("ItemNo", GetType(String))
            ItemsTable.Columns.Add("ItemName", GetType(String))
            ItemsTable.Columns.Add("UnitPrice", GetType(Decimal))
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            For i As Integer = 0 To selectedRowHandles.Length - 1
                Dim R As DataRow = ItemsTable.NewRow
                R("ItemNo") = GridView1.GetRowCellValue(selectedRowHandles(i), "ItemNo")
                R("ItemName") = GridView1.GetRowCellValue(selectedRowHandles(i), "ItemName")
                R("UnitPrice") = GridView1.GetRowCellValue(selectedRowHandles(i), "UnitPrice")
                ItemsTable.Rows.Add(R)
            Next
            Dim _View As New DataView(ItemsTable) With {
                .Sort = "ItemNo"
            }
            Dim newTable As DataTable = _View.ToTable("ItemNo", True, "ItemNo", "ItemName", "UnitPrice")
            GlobalVariables._ItemsTable = newTable
            Me.Dispose()
        End If


    End Sub


    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.InRow Then
            Dim view As GridView = TryCast(sender, GridView)
            view.FocusedRowHandle = e.HitInfo.RowHandle
            ContextMenuStrip1.Show(view.GridControl, e.Point)
        End If
    End Sub

    Private Sub اخرأسعارالبيعToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اخرأسعارالبيعToolStripMenuItem.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo")
            .TextPurchaseOrSale.Text = 2
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = "اخر اسعار البيع "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub اخرأسعارالشراءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اخرأسعارالشراءToolStripMenuItem.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo")
            .TextPurchaseOrSale.Text = 1
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = "اخر اسعار الشراء "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub حركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            If GlobalVariables._UserAccessType = 99 Then .ColDocID.OptionsColumn.AllowEdit = False
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo")
            '.TextPurchaseOrSale.Text = 1
            '.TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = "حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .RefreshData()
        End With

    End Sub

    Private Sub رصيدالصنفحسبالرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBalanceOnShelf.Click
        Dim F3 As New PosSelectShelf
        With F3
            .TextItemBarcode.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "item_unit_bar_code")
            .Text = "رصيد صنف حسب الرف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .GetDataForPosSelectShelf()
        End With
    End Sub

    Private Sub ItemsSearchMenue_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        'SearchControl1.Select()
    End Sub
    Private Sub CheckButton1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckButton1.CheckedChanged
        Dim btn As CheckButton = TryCast(sender, CheckButton)
        If btn.Checked Then
            'GridView1.OptionsCustomization.AllowFilter = True
            btn.Appearance.BackColor = Color.LightGreen
            btn.Appearance.BackColor2 = Color.DarkGreen
            btn.Appearance.ForeColor = Color.White
            ColItemName.OptionsColumn.AllowEdit = True
            ColBarcode.OptionsColumn.AllowEdit = True
            ColUnitPrice.OptionsColumn.AllowEdit = True
            GridView1.OptionsCustomization.AllowColumnMoving = True
            GridView1.OptionsCustomization.AllowQuickHideColumns = True
            'GridView1.OptionsColumn.ShowInCustomizationForm = True
        Else
            btn.Appearance.BackColor = Color.Red
            btn.Appearance.ForeColor = Color.Black
            ColItemName.OptionsColumn.AllowEdit = False
            ColBarcode.OptionsColumn.AllowEdit = False
            ColUnitPrice.OptionsColumn.AllowEdit = False
            GridView1.OptionsCustomization.AllowColumnMoving = False
            GridView1.OptionsCustomization.AllowQuickHideColumns = False
            'GridView1.OptionsCustomization.AllowFilter = False
            'btn.Appearance.BackColor2 = Color.DarkSalmon
        End If
        GridView1.OptionsCustomization.AllowFilter = False

    End Sub

    Private Sub رصيدالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles رصيدالصنفToolStripMenuItem.Click
        Dim F3 As New StockBalanceBywarehouse
        With F3
            .CheckSearchByItemNo.Checked = True
            .TextStockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo")
            .Text = "رصيد صنف حسب المستودع ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .GetBalanceByWareHouse()
            .Show()
            '.RefreshData()
        End With
    End Sub

    Private Sub ItemsSearchMenue_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' TextFind.Select()
        SearchControl1.Focus()
    End Sub

    Private Sub نسخالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخالصنفToolStripMenuItem.Click
        CopyItem()
    End Sub
    Private Sub CopyItem()
        Dim _ItemNo As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo"))
        If Not IsNothing(_ItemNo) Then
            Dim F As New Items
            With F
                .ItemNo.EditValue = _ItemNo
                ._CopyItem = True
                .ItemNo.EditValue = GetMaxNoForNewItem()
                ._CopyItem = False
                .TextNewOld.Text = "New"
                Dim dt As DataTable = CType(.GridControlUnits.DataSource, DataTable)
                If dt IsNot Nothing Then
                    dt.Rows.Clear()
                End If
                .GridControlUnits.RefreshDataSource()

                Dim dt2 As DataTable = CType(.GridControlBarcodes.DataSource, DataTable)
                If dt2 IsNot Nothing Then
                    dt2.Rows.Clear()
                End If
                .GridControlBarcodes.RefreshDataSource()

                .GridControlUnits.DataSource = .DefualtUnit()

                If .ShowDialog <> DialogResult.OK Then
                    GetItems()
                End If
            End With
        End If


    End Sub

    Private Sub RepositoryPrintBarcode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryPrintBarcode.ButtonClick
        If GlobalVariables._WareHouseUseShelf Then
            Dim barcode As String = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
            Dim itemNo As String = GridView1.GetFocusedRowCellValue("ItemNo")
            PrintShalashItem(itemNo, barcode)
            Exit Sub
        End If

        Dim F As New ItemBarcodePrint
        With F
            .txtItemName.Text = GridView1.GetFocusedRowCellValue("ItemName")
            .txtBarcode.Text = GridView1.GetFocusedRowCellValue("item_unit_bar_code")
            .TxtUnitName.Text = GridView1.GetFocusedRowCellValue("UnitName")
            .txtPrice.Text = GridView1.GetFocusedRowCellValue("UnitPrice")
            .txtItemCode.Text = GridView1.GetFocusedRowCellValue("ItemNo2")
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo3")) And Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo4")) Then
                .txtOtherCodes.Text = GridView1.GetFocusedRowCellValue("ItemNo3") & "   " & GridView1.GetFocusedRowCellValue("ItemNo4")
            End If
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("ProductCompany")) Then .txtProductCompany.Text = GridView1.GetFocusedRowCellValue("ProductCompany")
            .txtQuantity.EditValue = 1
            .ShowDialog()
        End With
    End Sub
    Private Sub BtnAddNew_Click(sender As Object, e As EventArgs) Handles BtnAddNew.Click
        My.Forms.Items.ItemName.Select()
        My.Forms.Items.ItemNo.EditValue = GetMaxNoForNewItem()
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetItems()
        End If
    End Sub

    Private Sub نقلالىرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نقلالىرفToolStripMenuItem.Click
        Dim _ItemNo As Integer = GridView1.GetFocusedRowCellValue("ItemNo")
        Dim _balance As Integer = 0
        Dim _WarehouseID As Integer = GetDefaltWahreHouseForUser(GlobalVariables.CurrUser)
        Dim _ShelvID As Integer = 0
        Dim _ItemName As String = GridView1.GetFocusedRowCellValue("ItemName")
        'If _balance = 0 Then Exit Sub
        Dim f As New QuickTransferItemsBetweenShelves
        With f
            .txtItemNo.EditValue = _ItemNo
            .txtItemName.Text = _ItemName
            .txtQuantity.EditValue = _balance
            .searchFromWarehouse.EditValue = _WarehouseID
            .searchFromShelf.EditValue = _ShelvID
            .searchToWarehouse.Select()
            .ShowDialog()
        End With
    End Sub


    Private Sub نسخالبياناتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخالبياناتToolStripMenuItem.Click
        Try
            ' Get the current focused column
            Dim focusedColumn As DevExpress.XtraGrid.Columns.GridColumn = GridView1.FocusedColumn

            ' Get the value from the focused cell
            Dim cellValue As Object = GridView1.GetFocusedRowCellValue(focusedColumn)

            ' Check if the value is not null
            If cellValue IsNot Nothing Then
                ' Convert the value to string and copy to clipboard
                Clipboard.SetText(cellValue.ToString())
            Else
                XtraMessageBox.Show("لا توجد بيانات للنسخ", "نسخ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("حدث خطأ أثناء نسخ البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAddSelectedItemsToVouchers_Click(sender As Object, e As EventArgs) Handles BtnAddSelectedItemsToVouchers.Click
        CollectSelectedRowsToGlobalVariables()
    End Sub
End Class