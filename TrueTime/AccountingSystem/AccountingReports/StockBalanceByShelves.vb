Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraSplashScreen

Public Class StockBalanceByShelves
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetShelvesContains()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub StockBalanceByShelves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub TextFromShelv_EditValueChanged(sender As Object, e As EventArgs) Handles TextFromShelv.EditValueChanged

    End Sub

    Private Sub CheckGroupByBarcode_CheckedChanged(sender As Object, e As EventArgs) Handles CheckGroupByBarcode.CheckedChanged
        GetShelvesContains()
    End Sub
    Public Sub GetShelvesContains()
        GridColumn3.Visible = CheckGroupByBarcode.Checked
        Try
            Dim SQL As New SQLControl
            Dim sqlstring As String
            Dim temptable As String = "#Temp" & GlobalVariables.CurrUser
            sqlstring = "Delete from  ShelvesReportTemp where UserID=" & GlobalVariables.CurrUser & ";
                        Select ShelfID as id 
                        Into   " & temptable & "
                        From   FinancialShelves 
                        Where ShelfCode between '" & TextFromShelv.Text & "' And '" & TextToShelf.Text & "'

                        Declare @Id int

                        While (Select Count(*) From " & temptable & ") > 0
                            Begin
                                Select Top 1 @Id = Id From " & temptable & " 
                                Declare @Shelve int;
                                Set @Shelve=@Id "
            If CheckGroupByBarcode.Checked = True Then
                sqlstring += "  Insert Into ShelvesReportTemp  (StockID,ItemName,ShelvID,balance,ItemNo2,[UserID],Barcode,MainBarcode,ItemNo3,ItemNo4) "
            Else
                sqlstring += "  Insert Into ShelvesReportTemp  (StockID,ItemName,ShelvID,balance,ItemNo2,[UserID],MainBarcode,ItemNo3,ItemNo4)"
            End If
            sqlstring += "          SELECT StockID,I.ItemName As ItemName ,@Shelve,
                                    isnull(sum(case when S.ShelfID = @Shelve then [StockQuantityByMainUnit] end),0) -isnull(sum(case when SS.ShelfID = @Shelve then [StockQuantityByMainUnit] end) ,0) as balance,
                                    I.ItemNo2," & GlobalVariables.CurrUser & ""
            If CheckGroupByBarcode.Checked = True Then
                sqlstring += "     ,J.StockBarcode "
            End If
            sqlstring += "     ,IU.item_unit_bar_code as MainBarcode,I.ItemNo3,I.ItemNo4 "
            sqlstring += "          
                                FROM [Journal] J
                                left join Items I on I.ItemNo=J.StockID
                                Left Join FinancialShelves S on S.ShelfID=J.StockDebitShelve
                                Left Join FinancialShelves SS on SS.ShelfID=J.StockCreditShelve
                                left join Items_units IU on IU.item_id= J.StockID and IU.main_unit=1
                                where DocStatus<>0 and StockID > '0' and I.[Type]=0 and (S.ShelfID= @Shelve or SS.ShelfID =@Shelve) "
            If CheckGroupByBarcode.Checked = True Then
                sqlstring += "         group by StockID,I.ItemName,I.ItemNo2,J.StockBarcode,IU.item_unit_bar_code,I.ItemNo3,I.ItemNo4 "
            Else
                sqlstring += "         group by StockID,I.ItemName,I.ItemNo2,IU.item_unit_bar_code,I.ItemNo3,I.ItemNo4  "
            End If
            sqlstring += "         Delete " & temptable & " Where Id = @Id
                            End

                        Drop Table " & temptable & "

                        Select StockID,ItemName,ShelvID,balance,S.ShelfCode ,w.WarehouseNameAR,ItemNo2,UserID,Barcode,MainBarcode,ItemNo3,ItemNo4,w.WarehouseID
                        From ShelvesReportTemp R 
                        Left Join FinancialShelves S on R.ShelvID=S.ShelfID
                        left join Warehouses W on w.WarehouseID=S.WareHouseID Where balance <> 0 Order By StockID ;"
            sqlstring += " delete from ShelvesReportTemp where UserID=" & GlobalVariables.CurrUser
            SQL.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = SQL.SQLDS.Tables(0)
            GridView1.BestFitColumns()
            '    SQL.SqlTrueAccountingRunQuery(" delete from ShelvesReportTemp where UserID=" & GlobalVariables.CurrUser)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub رصيدالصنفحسبالرفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles رصيدالصنفحسبالرفToolStripMenuItem.Click
        Dim F3 As New PosSelectShelf
        With F3
            '.CheckSearchByItemNo.Checked = True
            .TextItemBarcode.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .Text = "رصيد صنف حسب الرف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .GetDataForPosSelectShelf()
            .Show()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
            '.RefreshData()
        End With
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub تقريرحركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرحركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            '.GridColumn4.Visible = False
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            '.TextPurchaseOrSale.Text = 1
            '.TextItemName.Text = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "ItemName")
            .Text = "حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " )"
            .Show()
            .RefreshData()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Sub gridView1_CellValueChanged(ByVal sender As Object, ByVal e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim view As ColumnView = TryCast(sender, ColumnView)
        view.CloseEditor()
        If e.Column.FieldName = "MainBarcode" Then
            If XtraMessageBox.Show("هل تريد تعديل الباركود؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                GetShelvesContains()
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _StockID As Integer
                Dim _item_unit_bar_code, _ItemNo2 As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemUnitID")) Then
                    _StockID = CInt(GridView1.GetFocusedRowCellValue("StockID"))
                    _item_unit_bar_code = GridView1.GetFocusedRowCellValue("MainBarcode")
                    _ItemNo2 = GridView1.GetFocusedRowCellValue("ItemNo2")
                    If GlobalVariables._Shalash = True Then
                        If _ItemNo2 = _item_unit_bar_code Then
                            MsgBox("لا يمكن تعديل الباركود لانه نفس رقم الصنف")
                            GetShelvesContains()
                            Exit Sub
                        End If
                    End If
                    UpdateItemBarcode(_StockID, _item_unit_bar_code)
                End If
            End If
        End If

        If e.Column.FieldName = "ItemNo2" Or e.Column.FieldName = "ItemNo3" Or e.Column.FieldName = "ItemNo4" Then
            If XtraMessageBox.Show("هل تريد تعديل كود الصنف؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                GetShelvesContains()
                Exit Sub
            End If
            If view.UpdateCurrentRow() Then
                Dim _StockID As Integer
                Dim _ItemNo2, _ItemNo3, _ItemNo4 As String
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("StockID")) Then
                    _StockID = GridView1.GetFocusedRowCellValue("StockID")
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo2")) Then _ItemNo2 = "" Else _ItemNo2 = GridView1.GetFocusedRowCellValue("ItemNo2")
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo3")) Then _ItemNo3 = "" Else _ItemNo3 = GridView1.GetFocusedRowCellValue("ItemNo3")
                    If IsDBNull(GridView1.GetFocusedRowCellValue("ItemNo4")) Then _ItemNo4 = "" Else _ItemNo4 = GridView1.GetFocusedRowCellValue("ItemNo4")
                    ChangeItemNo2(_StockID, _ItemNo2, _ItemNo3, _ItemNo4)
                End If
            End If
        End If



    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub UpdateItemBarcode(_ItemNo As Integer, _item_unit_bar_code As String)


        If String.IsNullOrWhiteSpace(_item_unit_bar_code) Then
            MsgBoxShowError(" رقم الباركود فارغ ")
            GetShelvesContains()
            Exit Sub
        End If
        If _item_unit_bar_code = "0" Then
            MsgBoxShowError(" رقم الباركود خطا ")
            GetShelvesContains()
            Exit Sub
        End If
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            Dim SQl As New SQLControl
            Dim SqlString As String
            If CheckIfBarcodeFound(_item_unit_bar_code) = False Then
                SqlString = " Update Items_units 
                      Set item_unit_bar_code='" & _item_unit_bar_code & "' 
                      where main_unit=1 and  item_id =" & _ItemNo
                If SQl.SqlTrueAccountingRunQuery(SqlString) <> "True" Then
                    XtraMessageBox.Show("لم يتم تعديل الباركود")
                    GetShelvesContains()
                End If
            Else
                CloseProgressPanel(Handle)
                XtraMessageBox.Show("لم يتم تعديل الباركود، الباركود مكرر")
                GetShelvesContains()
            End If
        Finally
            CloseProgressPanel(Handle)
        End Try
    End Sub
    Private Sub ChangeItemNo2(_ItemNo As Integer, _ItemNo2 As String, _ItemNo3 As String, _ItemNo4 As String)
        If String.IsNullOrEmpty(_ItemNo) Then
            MsgBoxShowError(" رقم الصنف فارغ ")
            Exit Sub
        End If
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Update [Items] set [ItemNo2]=N'" & _ItemNo2 & "',[ItemNo3]='" & _ItemNo3 & "',[ItemNo4]='" & _ItemNo4 & "' where [ItemNo]=" & _ItemNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub نقلالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نقلالصنفToolStripMenuItem.Click
        Dim _ItemNo As Integer = GridView1.GetFocusedRowCellValue("StockID")
        Dim _balance As Integer = GridView1.GetFocusedRowCellValue("balance")
        Dim _WarehouseID As Integer = GridView1.GetFocusedRowCellValue("WarehouseID")
        Dim _ShelvID As Integer = GridView1.GetFocusedRowCellValue("ShelvID")
        Dim _ItemName As String = GridView1.GetFocusedRowCellValue("ItemName")
        If _balance = 0 Then Exit Sub
        Dim f As New QuickTransferItemsBetweenShelves
        With f
            .txtItemNo.EditValue = _ItemNo
            .txtItemName.Text = _ItemName
            .txtQuantity.EditValue = _balance
            .searchFromWarehouse.EditValue = _WarehouseID
            .searchFromShelf.EditValue = _ShelvID
            .searchToWarehouse.Select()
            If .ShowDialog <> DialogResult.OK Then
                GetShelvesContains()
            End If
        End With

    End Sub

    Private Sub RepositoryPrint_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryPrint.ButtonClick
        If GlobalVariables._Shalash Then
            Dim barcode As String = GridView1.GetFocusedRowCellValue("MainBarcode")
            Dim itemNo As String = GridView1.GetFocusedRowCellValue("StockID")
            PrintShalashItem(itemNo, barcode)
            Exit Sub
        End If
    End Sub
End Class