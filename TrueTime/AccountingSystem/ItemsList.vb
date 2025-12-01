Imports System.Data.SqlClient
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class ItemsList
    Dim _ScreenMode As String
    Dim _ShowVerticalLines As Boolean = False

    Private Sub ItemsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColGroupName.VisibleIndex = -1
        ColCategoryName.VisibleIndex = -1
        ColTradeMarkName.VisibleIndex = -1
        Me.KeyPreview = True
        ServiceOrItem()
        Me.Type.EditValue = -1
        GetSettings()
        GetItemsAsync()
        ColUnitPrice.DisplayFormat.FormatString = "{0:0.00}"
        ColItemNo.DisplayFormat.FormatString = "{0:00000}"
        Me.SearchItemsCategories.Properties.DataSource = GetItemsCategories()
        Me.SearchItemsTradeMark.Properties.DataSource = GetItemsTradeMark()
        Me.SearchItemsGroups.Properties.DataSource = GetItemsGroups(False)
        Me.ColHasProductionEquation.Visible = False
        ColBalance.Visible = False
    End Sub
    Private Sub GetSettings()
        Dim _ShowItemNo2 As Boolean = False
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2'")
            _ShowItemNo2 = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If _ShowItemNo2 = True Then
                ColItemName2.Visible = True
            Else
                ColItemName2.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ServiceOrItem()
        Dim Sr As New DataTable
        Sr.Columns.Add("id", GetType(Integer))
        Sr.Columns.Add("ItemType", GetType(String))
        Sr.Rows.Add(-1, "الكل")
        Sr.Rows.Add(0, "صنف")
        Sr.Rows.Add(1, "خدمة")
        Type.Properties.DataSource = Sr
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Async Sub GetItemsAsync()
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())

        Try
            ' Run the data-fetching logic on a separate thread
            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Return FetchItemsData()
                                                        End Function)

            ' Update the GridControl on the UI thread
            GridControlItems.DataSource = dataTable
        Catch ex As Exception
            MsgBoxShowError($"An error occurred while fetching items: {ex.Message}")
        Finally
            CloseProgressPanel(handle)
        End Try

        ' Restore the focused row and adjust column widths
        GridView1.BestFitColumns()
        GridView1.FocusedRowHandle = focusedRow
    End Sub

    ' Function to fetch data (runs on a background thread)
    Private Function FetchItemsData() As DataTable
        Dim sqlString As String = ""
        If CheckEditShowBalances.Checked = True Then sqlString = " Select * From ( "
        sqlString &= "SELECT I.[id], " &
                                  "CASE WHEN [Type] = 0 THEN N'Item' WHEN [Type] = 1 THEN N'Service' WHEN [Type] = 3 THEN N'Assets' END AS [Type], " &
                                  "CONVERT(int, ItemNo) AS ItemNo, " &
                                  "[ItemName], " &
                                  "[HasExpireDate], " &
                                  "[LastPurchasePrice], " &
                                  "[LastPurchaseDate], " &
                                  "[ReOrderQuantity], " &
                                  "I.[notes], " &
                                  "[AccSales], " &
                                  "[AccPurches], " &
                                  "[AccRetSales], " &
                                  "[AccRetPurches], " &
                                  "U.[name] AS UnitName, " &
                                  "IU.Price1 AS UnitPrice, " &
                                  "C.CategoryName, " &
                                  "T.TradeMarkName, " &
                                  "'' AS Edited, " &
                                  "IU.id AS PriceUnitID, " &
                                  "CONVERT(decimal(18,3), '0') AS NewPrice, " &
                                  "G.GroupName, " &
                                  "ISNULL(HasProductionEquation, 0) AS HasProductionEquation, " &
                                  "I.ItemNo2, " &
                                  "I.ItemStatus, " &
                                  "Cs.CostName, " &
                                  "CONVERT(varchar(1), [classification]) AS [classification], " &
                                  "F.AccName AS PurchaseAccount, " &
                                  "FF.AccName AS ReturnPurchaseAccount " &
                                  "FROM [Items] I " &
                                  "LEFT JOIN Items_units IU ON I.ItemNo = IU.item_id " &
                                  "LEFT JOIN Units U ON U.id = IU.unit_id " &
                                  "LEFT JOIN [dbo].[ItemsCategories] C ON C.CategoryID = I.CategoryID " &
                                  "LEFT JOIN [dbo].[ItemsTradeMark] T ON T.TradeMarkID = I.TradeMarkID " &
                                  "LEFT JOIN ItemsGroups G ON G.GroupID = I.GroupID " &
                                  "LEFT JOIN CostCenter Cs ON Cs.CostID = I.CostCenter " &
                                  "LEFT JOIN FinancialAccounts F ON F.AccNo = I.AccPurches " &
                                  "LEFT JOIN FinancialAccounts FF ON FF.AccNo = I.AccRetPurches " &
                                  "WHERE [main_unit] = 1 AND Type <> 3 "

        ' Apply filters
        If Not String.IsNullOrEmpty(SearchItemsGroups.Text) Then
            sqlString &= " AND I.GroupID = '" & SearchItemsGroups.EditValue & "'"
        End If
        If Not String.IsNullOrEmpty(SearchItemsCategories.Text) Then
            sqlString &= " AND I.CategoryID = '" & SearchItemsCategories.EditValue & "'"
        End If
        If Not String.IsNullOrEmpty(SearchItemsTradeMark.Text) Then
            sqlString &= " AND I.TradeMarkID = '" & SearchItemsTradeMark.EditValue & "'"
        End If
        If CheckItemWithoutTrans.Checked Then
            sqlString &= " AND NOT EXISTS (SELECT ItemNo FROM Journal J WHERE I.ItemNo = J.StockID)"
        End If
        If Not CheckShowUnActiveItems.Checked Then
            sqlString &= " AND ItemStatus = 1"
        End If
        If Me.Type.EditValue <> -1 Then
            sqlString &= " AND I.Type = " & Me.Type.EditValue
        End If

        If CheckEditShowBalances.Checked = True Then sqlString &= " ) A 
            left join
            (
            SELECT StockID,
            isnull(sum(case when    [StockDebitWhereHouse] Between 1 And 9999999 then [StockQuantityByMainUnit] end),0)  -
            isnull(sum(case when    StockCreditWhereHouse  Between 1 And 9999999 then [StockQuantityByMainUnit] end) ,0) as Balance
            FROM [Journal] J
            WHERE DocStatus<>0 and StockID > '0' 
            Group By StockID
            ) B
            On A.ItemNo=B.StockID "

        sqlString &= " ORDER BY ItemNo"

        ' Execute the query and return the result
        Dim sql As New SQLControl()
        sql.SqlTrueAccountingRunQuery(sqlString)
        Return sql.SQLDS.Tables(0)
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        GetItemsAsync()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetItemsAsync()
        ElseIf e.KeyCode = Keys.Insert Then
            AddNewItem()
            'ElseIf keys.Control AndAlso e.KeyCode = Keys.P Then
            '    GridControlItems.ShowPrintPreview()
        End If
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        'My.Forms.Items.Show()
        'My.Forms.Items.ItemNo.EditValue = CInt(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo"))
        ShowEditForm()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)


    End Sub
    Private Sub AddNewItem()
        My.Forms.Items.ItemName.Select()
        My.Forms.Items.ItemNo.EditValue = GetMaxNoForNewItem()
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetItemsAsync()
        End If
    End Sub

    Private Sub ShowEditForm()
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo"))
        If Items.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetItemsAsync()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()
        GetItemsAsync()
        stopwatch.Stop()
        My.Forms.Main.ItemElapseTime.Caption = $"Query time: {stopwatch.ElapsedMilliseconds} ms"
    End Sub

    Private Sub SimpleButtonAddNewDoc_Click(sender As Object, e As EventArgs) Handles SimpleButtonAddNewDoc.Click
        AddNewItem()
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControlItems.ShowPrintPreview()
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = " "
        Dim Tawqe3_2 As String = " "

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)



        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" تقرير البضاعة ")


        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



    End Sub



    Private Sub TextOpen_EditValueChanged(sender As Object, e As EventArgs) Handles TextOpen.EditValueChanged
        Select Case TextOpen.Text
            Case "EditPrice"
                LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColCategoryName.Visible = False
                'ColOpen.Visible = False
                'ColUnitPrice.OptionsColumn.AllowEdit = True
                'ColUnitPrice.OptionsColumn.ReadOnly = False
                ColNewPrice.Visible = True
                ColNewPrice.AppearanceCell.BackColor = Color.GhostWhite
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Case "View"
                LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColNewPrice.Visible = False
        End Select
    End Sub
    'Sub gridView1_RowUpdated(ByVal sender As Object, ByVal e As RowObjectEventArgs) Handles GridView1.RowUpdated
    '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Edited"), "True")
    'End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "NewPrice" Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("Edited"), "True")
        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()

        Try
            Dim i, rowsAffected As Integer
            Using con As New SqlConnection(My.Settings.TrueTimeConnectionString)
                con.Open()
                For i = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(i, "Edited") = "True" Then
                        Dim _PriceUnitID As Integer = CInt(Me.GridView1.GetRowCellValue(i, "PriceUnitID"))
                        Dim _NewPrice As Decimal = CDec(Me.GridView1.GetRowCellValue(i, "NewPrice"))
                        Using cmd As New SqlCommand("UPDATE [dbo].[Items_units] Set  [Price1]=@NewPrice WHERE id =@PriceUnitID", con)
                            cmd.Parameters.Add("@PriceUnitID", SqlDbType.Int).Value = _PriceUnitID
                            cmd.Parameters.Add("@NewPrice", SqlDbType.Decimal).Value = _NewPrice
                            rowsAffected = cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
                con.Close()
            End Using
            XtraMessageBox.Show("تم تعديل الاسعار")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        GetItemsAsync()
    End Sub

    Private Sub RepositoryItemHyperItemNo_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperItemNo.OpenLink
        ShowEditForm()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
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

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemNo")
            .Warehouses.Text = 1
            ' .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = " حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
        If e.Column.FieldName = "ItemName" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
            'e.Appearance.BackColor = Color.FromArgb(1, 55, 99)
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        Dim Sql As New SQLControl
        Dim _Status As Boolean
        Try
            _Status = CBool(GridView1.GetFocusedRowCellValue("ItemStatus"))
        Catch ex As Exception
            _Status = False
        End Try

        Dim _ItemNo As Integer = CInt(GridView1.GetFocusedRowCellValue("ItemNo"))
        Select Case _Status
            Case False
                If XtraMessageBox.Show("هل تريد تفعيل الصنف؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[Items] Set [ItemStatus] =1 where [ItemNo]=" & _ItemNo)
                    GridView1.SetFocusedRowCellValue("Active", True)
                Else
                    GridView1.SetFocusedRowCellValue("Active", False)
                End If
            Case True
                If XtraMessageBox.Show("هل تريد ايقاف الحركة على الصنف؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[Items] Set [ItemStatus] =0 where ItemNo=" & _ItemNo)
                    GridView1.SetFocusedRowCellValue("Active", False)
                Else
                    GridView1.SetFocusedRowCellValue("Active", True)
                End If
        End Select
    End Sub

    Private Sub CheckShowItemsDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowItemsDetails.CheckedChanged
        If CheckShowItemsDetails.Checked = True Then
            ColGroupName.VisibleIndex = 3
            ColCategoryName.VisibleIndex = 4
            ColTradeMarkName.VisibleIndex = 5
            '   BandedGridView1.OptionsView.ShowGroupPanel = True
        Else
            ColGroupName.VisibleIndex = -1
            ColCategoryName.VisibleIndex = -1
            ColTradeMarkName.VisibleIndex = -1
            '  BandedGridView1.OptionsView.ShowGroupPanel = False
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        AddNewItem()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        GridControlItems.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        GridControlItems.Print()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        GetItemsAsync()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Select Case _ShowVerticalLines
            Case True
                GridView1.OptionsView.ShowVerticalLines = DefaultBoolean.False
                _ShowVerticalLines = False
            Case False
                GridView1.OptionsView.ShowVerticalLines = DefaultBoolean.True
                _ShowVerticalLines = True
        End Select
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If GridView1.OptionsView.ShowAutoFilterRow = True Then
            GridView1.OptionsView.ShowAutoFilterRow = DefaultBoolean.True
        Else
            GridView1.OptionsView.ShowAutoFilterRow = DefaultBoolean.False
        End If
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckItemWithoutTrans.CheckedChanged

    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Dim f As New ItemReplaceName
        With f
            If .ShowDialog <> DialogResult.OK Then
                GetItemsAsync()
            End If
        End With
    End Sub

    Private Sub ContextJournalMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextJournalMenu.Opening
        If GlobalVariables._UserAccessType = 95 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)


    End Sub
    Private Sub PrintItemsListWithImages(_withPrice As Boolean)
        Dim itemNumbers As New List(Of Integer)()
        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                Dim _ItemNo As Integer = CInt(GridView1.GetRowCellValue(rowHandle, "ItemNo"))
                itemNumbers.Add(CInt(_ItemNo))
            End If
        Next rowHandle

        Dim itemArray As Integer() = itemNumbers.ToArray()
        Dim Report As New ItemsListWithImages
        With Report
            ._WithPrice = _withPrice
            .Parameters("ItemNo").Value = itemArray
            .ShowPreview()
        End With
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        PrintItemsListWithImages(True)
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        PrintItemsListWithImages(False)
    End Sub

    Private Sub نسخالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخالصنفToolStripMenuItem.Click
        CopyItem()
    End Sub

    Private Sub BarButtonItem11_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
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
                    GetItemsAsync()
                End If
            End With
        End If
    End Sub
    Private Sub BarButtonUpdateLastCost_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonUpdateLastCost.ItemClick
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        If UpdateItemsLastPurchasePrice(Today()) = True Then
            MsgBoxShowSuccess(" تم تحديث الأسعار بنجاح ")
        End If
        CloseProgressPanel(handle)
        GridView1.FocusedRowHandle = focusedRow
        GetItemsAsync()
    End Sub

    Private Sub CheckEditShowBalances_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowBalances.CheckedChanged
        If CheckEditShowBalances.Checked = True Then
            ColBalance.Visible = True
            ColBalance.VisibleIndex = ColItemStatus.VisibleIndex - 1
        Else
            ColBalance.Visible = False
        End If
    End Sub
End Class