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

Public Class ProductionEquation


    Private Sub ProductionEquation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.Warehouses' table. You can move, or remove it, as needed.
        Me.WarehousesTableAdapter.Fill(Me.AccountingDataSet.Warehouses)
        'TODO: This line of code loads data into the 'AccountingDataSet.Units' table. You can move, or remove it, as needed.
        Me.UnitsTableAdapter.Fill(Me.AccountingDataSet.Units)
        'TODO: This line of code loads data into the 'AccountingDataSet.ProductionEquation' table. You can move, or remove it, as needed.
        'Me.ProductionEquationTableAdapter.Fill(Me.AccountingDataSet.ProductionEquation)
        'Me.ProductionEquationTableAdapter.FillByEquationID(Me.AccountingDataSet.ProductionEquation, -1)
        Dim _ItemTable As New DataTable
        _ItemTable = GetItems(-1)
        Me.RepositoryRawItemNo.DataSource = _ItemTable
        Me.SearchItems.Properties.DataSource = _ItemTable
        Me.RepositoryItem.DataSource = _ItemTable
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveData()
    End Sub
    Private Sub SaveData()
        Try
            If String.IsNullOrEmpty(Me.SearchItems.Text) Then
                XtraMessageBox.Show("يجب اختيار الصنف")
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.SearchStockUnit.Text) Then
                XtraMessageBox.Show("يجب اختيار الوحدة")
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.ItemQuantity.Text) Then
                XtraMessageBox.Show("يجب تحديد الكمية")
                Exit Sub
            End If

            Dim _ItemData = GetItemsData(Me.SearchItems.EditValue, False)
            If Me.TextNewOld.Text = "New" Then
                If _ItemData._HasProductionEquation = True Then
                    XtraMessageBox.Show("خطا: الصنف له معادلة انتاج معرفة من قبل")
                    Exit Sub
                End If
            ElseIf Me.TextNewOld.Text = "Old" Then
                If Me.SearchItems.EditValue <> SearchItemsOld.EditValue Then
                    If _ItemData._HasProductionEquation = True Then
                        XtraMessageBox.Show("خطا: الصنف له معادلة انتاج معرفة من قبل")
                        Exit Sub
                    End If
                End If
            End If





            Dim _EquationID As Integer
            If Me.TextNewOld.Text = "New" Then
                _EquationID = GetMaxEquationNo() + 1
            Else
                _EquationID = EquationIDQuery.Text
            End If

            Dim i As Integer
            For i = 0 To GridView1.RowCount - 1
                With GridView1
                    .SetRowCellValue(i, "ItemNo", SearchItems.EditValue)
                    .SetRowCellValue(i, "SearchStockUnit", SearchItems.EditValue)
                    .SetRowCellValue(i, "EquationID", _EquationID)
                    .SetRowCellValue(i, "ItemUnit", SearchStockUnit.EditValue)
                    .SetRowCellValue(i, "DocNote", MemoEdit1.Text)
                    .SetRowCellValue(i, "ItemQuantity", ItemQuantity.Text)
                    .SetRowCellValue(i, "EquationStatus", CheckEquationStatus.Checked)
                End With
            Next
            Me.Validate()
            Me.ProductionEquationBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Update Items Set HasProductionEquation=1 Where ItemNo=" & SearchItems.EditValue)
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حفظ البيانات ", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SaveProductionDocument()
        Try
            If String.IsNullOrEmpty(Me.SearchItems.Text) Then
                XtraMessageBox.Show("يجب اختيار الصنف")
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.SearchStockUnit.Text) Then
                XtraMessageBox.Show("يجب اختيار الوحدة")
                Exit Sub
            End If

            If String.IsNullOrEmpty(Me.ItemQuantity.Text) Then
                XtraMessageBox.Show("يجب تحديد الكمية")
                Exit Sub
            End If


            Dim _EquationID As Integer
            If Me.TextNewOld.Text = "New" Then
                _EquationID = GetMaxEquationNo() + 1
            Else
                _EquationID = EquationIDQuery.Text
            End If

            Dim i As Integer
            For i = 0 To GridView1.RowCount - 1
                With GridView1
                    .SetRowCellValue(i, "ItemNo", SearchItems.EditValue)
                    .SetRowCellValue(i, "SearchStockUnit", SearchItems.EditValue)
                    .SetRowCellValue(i, "EquationID", _EquationID)
                    .SetRowCellValue(i, "ItemUnit", SearchStockUnit.EditValue)
                    .SetRowCellValue(i, "DocNote", MemoEdit1.Text)
                    .SetRowCellValue(i, "ItemQuantity", ItemQuantity.Text)
                    .SetRowCellValue(i, "EquationStatus", CheckEquationStatus.Checked)
                End With
            Next
            Me.Validate()
            Me.ProductionEquationBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Update Items Set HasProductionEquation=1 Where ItemNo=" & SearchItems.EditValue)
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حفظ البيانات ", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        Me.ProductionEquationBindingSource.AddNew()
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
            Dim _RawItemNo As String = Convert.ToString(view.GetFocusedRowCellValue("RawItemNo"))
            editor.Properties.DataSource = GetUnitsForItems(_RawItemNo)
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
                            .SetFocusedRowCellValue("RawItemQuantity", 1)
                            '.SetFocusedRowCellValue("StockQuantityByMainUnit",
                            '                 ItemData.EquivalentToMain * .GetFocusedRowCellValue("StockQuantity"))
                            '.SetFocusedRowCellValue("StockQuantityPerMainUnit", ItemData.EquivalentToMain)
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
                        'If UnitID <> 0 Then
                        '    .SetFocusedRowCellValue("StockQuantityByMainUnit",
                        '                     .GetFocusedRowCellValue("StockQuantity") * .GetFocusedRowCellValue("StockQuantityPerMainUnit"))
                        'End If

                    Case "StockPrice"

                    Case "StockDiscount"

                    Case "RawItemUnit"
                        Try
                            Dim _Item_Unit_ID As Integer
                            'Dim _EquivalentToMain As Decimal
                            'Dim _LastPurchasePrice As Decimal
                            _Item_Unit_ID = .GetFocusedRowCellValue("RawItemUnit")
                            If String.IsNullOrEmpty(_Item_Unit_ID) Then Exit Sub
                            'Dim Sql As New SQLControl
                            'Sql.SqlTrueAccountingRunQuery(" Select LastPurchasePrice, item_unit_bar_code,EquivalentToMain
                            '                                From Items I Left Join  [dbo].[Items_units] IU on I.ItemNo=IU.item_id
                            '                                where [ItemNo]='" & _StockID & "' and [unit_id]=" & _Item_Unit_ID)

                            ''.SetFocusedRowCellValue("StockBarcode", Sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code"))
                            'If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")) Then
                            '    _EquivalentToMain = Sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")
                            'Else
                            '    _EquivalentToMain = 0
                            'End If
                            'If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")) Then
                            '    _LastPurchasePrice = Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
                            'Else
                            '    _LastPurchasePrice = 0
                            'End If
                            Dim _PurchasePrice As Decimal
                            _PurchasePrice = GetLastPurchasePrice(_StockID, _Item_Unit_ID)
                            .SetFocusedRowCellValue("RawItemPrice", _PurchasePrice)
                        Catch ex As Exception
                            MsgBox("لا يمكن اختيار هذه الوحدة، فهي غير معرفة لهذا الصنف")
                            .SetFocusedRowCellValue("RawItemPrice", 0)
                            .SetFocusedRowCellValue("RawItemUnit", String.Empty)
                            MsgBox(ex.ToString)
                        End Try


                End Select
                '    GridView1.PostEditor()
                ' GridView1.UpdateTotalSummary()

                Dim vQty As Object = .GetFocusedRowCellValue("RawItemQuantity")
                Dim vPrice As Object = .GetFocusedRowCellValue("RawItemPrice")

                Dim _Temp1 As Decimal = 0D
                Dim _Temp2 As Decimal = 0D

                If vQty IsNot Nothing AndAlso vQty IsNot DBNull.Value Then
                    Decimal.TryParse(Convert.ToString(vQty), _Temp1)
                End If

                If vPrice IsNot Nothing AndAlso vPrice IsNot DBNull.Value Then
                    Decimal.TryParse(Convert.ToString(vPrice), _Temp2)
                End If


                .SetRowCellValue(.FocusedRowHandle, "RawItemAmount", (_Temp1 * _Temp2))

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            GlobalVariables._TempItemNo = 0
        End With

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow

        Me.GridView1.SetRowCellValue(e.RowHandle, "EquationID", 1)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemNo", SearchItems.EditValue)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemUnit", SearchStockUnit.EditValue)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemQuantity", ItemQuantity.EditValue)
        Me.GridView1.SetRowCellValue(e.RowHandle, "EquationStatus", CheckEquationStatus.Checked)

        'Me.GridView1.SetRowCellValue(e.RowHandle, "StockPrice", 0)
        'If GlobalVariables._TempItemNo <> 0 Then Me.GridView1.SetRowCellValue(e.RowHandle, "RawItemNo", GlobalVariables._TempItemNo)
        Select Case GridView1.RowCount
            Case 10
                Me.GridView1.IndicatorWidth = 30
            Case 99
                Me.GridView1.IndicatorWidth = 100
        End Select
        'Me.GridView1.SetRowCellValue(e.RowHandle, "DocCostCenter", LookCostCenter.EditValue)
        '_HasSerial = False
    End Sub

    Private Sub SearchItems_EditValueChanged(sender As Object, e As EventArgs) Handles SearchItems.EditValueChanged
        'SearchStockUnit.Properties.DataSource = GetUnitsTable(SearchItems.EditValue)
        Dim _ItemData = GetItemsData(Me.SearchItems.EditValue, False)
        Me.SearchStockUnit.EditValue = _ItemData.DefaultUnit
    End Sub


    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AddNewEquation()
    End Sub
    Public Sub AddNewEquation()
        EquationID.EditValue = -1
        ItemQuantity.EditValue = 1
        Me.ProductionEquationTableAdapter.FillByEquationID(Me.AccountingDataSet.ProductionEquation, -1)
        EquationID.EditValue = GetMaxEquationNo() + 1
        TextNewOld.Text = "New"
    End Sub
    Private Function GetMaxEquationNo() As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select IsNull(Max(EquationID),0) As EquationNo From ProductionEquation  ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return sql.SQLDS.Tables(0).Rows(0).Item("EquationNo")
            Else
                Return 1
            End If
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Private Sub EquationID_EditValueChanged(sender As Object, e As EventArgs) Handles EquationID.EditValueChanged

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles EquationIDQuery.EditValueChanged
        If Not String.IsNullOrEmpty(EquationIDQuery.Text) Then
            Dim _MaxEquation As Integer
            _MaxEquation = GetMaxEquationNo()
            If EquationIDQuery.EditValue > _MaxEquation Then
                AddNewEquation()
            Else
                Me.ProductionEquationTableAdapter.FillByEquationID(Me.AccountingDataSet.ProductionEquation, EquationIDQuery.EditValue)
                GetEquationHeader()
                TextNewOld.Text = "Old"
            End If
        End If
    End Sub
    Private Sub GetEquationHeader()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("select top(1) [ItemNo],[ItemUnit],[EquationID],[DocNote],ItemQuantity 
                                              from [dbo].[ProductionEquation] 
                                              where [EquationID]= " & EquationIDQuery.EditValue)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Me.SearchItems.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
                Me.SearchItemsOld.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
                Me.SearchStockUnit.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemUnit")
                Me.MemoEdit1.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("DocNote")
                Me.ItemQuantity.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("ItemQuantity")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف المعادلة؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql As New SQLControl
            If sql.SqlTrueAccountingRunQuery(" Delete from [dbo].[ProductionEquation] Where [EquationID]= " & EquationIDQuery.EditValue) = True Then
                sql.SqlTrueAccountingRunQuery(" Update Items Set HasProductionEquation=1 Where ItemNo=" & SearchItems.EditValue)
                Me.Close()
                ProductionEquationList.GetItemsEquationList()
            Else
                MsgBox("لا يمكن حذف الصنف")
            End If

        End If
    End Sub

    Private Sub RepositoryItem_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItem.BeforePopup
        'Me.RepositoryItem.DataSource = GetItems("-1")
    End Sub

    Private Sub RepositoryItem_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles RepositoryItem.AddNewValue
        Dim _ItemNo As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT IsNull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items")
            _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
        Catch ex As Exception
            _ItemNo = 0
        End Try

        Dim F As New Items
        With F
            .ItemNo.EditValue = _ItemNo
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            Else
                Me.RepositoryItem.DataSource = GetItems("-1")
            End If
        End With
    End Sub



    Private Sub ProductionEquationGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles ProductionEquationGridControl.ProcessGridKey
        Dim sql As New SQLControl
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
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
                _FieldName = "RawItemNo"
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
                    _FieldName = "RawItemNo"
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                    Edit_EditValueChanged(sender, e)
                Else
                    _FieldName = "RawItemNo"
                    GridView1.SetFocusedRowCellValue("RawItemNo", GlobalVariables._TempItemNo)
                    Edit_EditValueChanged(sender, e)
                End If
                GlobalVariables._TempItemNo = 0
            End If
        End If
    End Sub

    Private Sub اخراسعارالشراءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اخراسعارالشراءToolStripMenuItem.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")
            .TextPurchaseOrSale.Text = 1
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemName")
            .Text = "اخر اسعار الشراء "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub معادلاتالانتاجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles معادلاتالانتاجToolStripMenuItem.Click
        Dim F As New ProductionRowItemLastEquations
        With F
            Dim _ItemNo As Integer
            _ItemNo = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RawItemNo")
            .RefreshDataToGetRowItemEquations(_ItemNo)
            .ShowDialog()
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

End Class