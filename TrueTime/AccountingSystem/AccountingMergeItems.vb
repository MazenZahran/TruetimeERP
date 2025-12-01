Imports DevExpress.XtraEditors

Public Class AccountingMergeItems
    Private Sub AccountingMergeItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _ItemsTable As DataTable
        _ItemsTable = GetItems("All")
        Me.SearchLookOldItem.Properties.DataSource = _ItemsTable
        Me.SearchLookNewItem.Properties.DataSource = _ItemsTable
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim sql As New SQLControl
        If TextOldItemUnitName.Text <> TextNewItemUnitName.Text Then
            XtraMessageBox.Show("لا يمكن استبدال الصنف بسبب اختلاف الوحدة الرئيسية")
            Exit Sub
        End If
        If TextOldItemHasEquation.Text = "True" And TextNewItemHasEquation.Text = "True" Then
            If XtraMessageBox.Show("سيتم حذف معادلة الانتاج للصنف القديم بسبب وجود معادلة للصنف الجديد ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                Exit Sub
            Else
                sql.SqlTrueAccountingRunQuery("Delete from ProductionEquation where ItemNo=" & SearchLookOldItem.Text)
            End If
        End If
        If TextOldItemHasEquation.Text = "True" And TextNewItemHasEquation.Text = "False" Then
            sql.SqlTrueAccountingRunQuery("Update ProductionEquation Set ItemNo =" & SearchLookNewItem.Text & " where ItemNo=" & SearchLookOldItem.Text)
            sql.SqlTrueAccountingRunQuery("update Items set HasProductionEquation=1 where ItemNo=" & SearchLookNewItem.Text & " ")
            sql.SqlTrueAccountingRunQuery("update Items set HasProductionEquation=0 where ItemNo=" & SearchLookOldItem.Text & " ")
        End If

        Dim sqlstring As String
        sqlstring = "   Declare @OldItemNo int;
                        Declare @NewItemNo int;
                        Set @OldItemNo=" & SearchLookOldItem.Text & ";
                        Set @NewItemNo = " & SearchLookNewItem.Text & ";
                        update Journal set StockID=@NewItemNo where StockID=@OldItemNo;
                        Update Items Set ItemName = ItemName + N' (Canceled)',[Active]=0 where ItemNo=@OldItemNo;
                        Update ProductionEquation Set RawItemNo=@NewItemNo where RawItemNo=@OldItemNo "
        If CheckMergeBarcodes.Checked Then
            sqlstring += " ;Update [dbo].[Items_units] Set item_id=@NewItemNo , main_unit=0 , IsUnit=0  Where item_id=@OldItemNo  "
        End If
        If CheckEditDelete.Checked Or CheckMergeBarcodes.Checked Then
            sqlstring += " ;Delete From Items Where ItemNo=@OldItemNo ; Delete From [dbo].[Items_units] Where item_id=@OldItemNo  "
        End If
        If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            XtraMessageBox.Show("تم استبدال الصنف بنجاح")
        End If
        Me.Dispose()
    End Sub

    Private Sub SearchLookOldItem_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookOldItem.EditValueChanged
        If Me.IsHandleCreated Then
            Dim repo As New ItemRepository()
            Dim item As ItemDetails = repo.GetItem(SearchLookOldItem.EditValue, "False")
            'Dim _ItemData = GetItemsData(SearchLookOldItem.EditValue, "False")
            TextOldItemName.Text = item.ItemName
            TextOldItemHasEquation.Text = item.HasProductionEquation.ToString()
            TextOldItemUnitName.Text = GetMainUnitName(SearchLookOldItem.EditValue)
            TextOldItemTransCount.Text = GetTransCount(SearchLookOldItem.EditValue)
            OldItemProductEquationCount.Text = GetProduceEquationCount(SearchLookOldItem.EditValue)
        End If

    End Sub
    Private Function GetMainUnitName(ItemNo As Integer) As String
        Dim _OldItemMainUnit As String
        _OldItemMainUnit = 0
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select u.name as UnitName  from Items_units IU left Join Units U on U.id=IU.unit_id where item_id=" & ItemNo & " and main_unit=1  "
        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _OldItemMainUnit = sql.SQLDS.Tables(0).Rows(0).Item("UnitName")
        Catch ex As Exception
            _OldItemMainUnit = 0
        End Try
        Return _OldItemMainUnit
    End Function
    Private Function GetTransCount(ItemNo As Integer) As String
        Dim _TextOldItemTransCount As String
        _TextOldItemTransCount = 0
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select Count(ID) As Count from Journal where StockID= " & ItemNo & ""
        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _TextOldItemTransCount = sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _TextOldItemTransCount = 0
        End Try
        Return _TextOldItemTransCount
    End Function

    Private Sub SearchLookNewItem_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookNewItem.EditValueChanged
        If Me.IsHandleCreated Then
            If Me.IsHandleCreated Then
                'Dim _ItemData = GetItemsData(SearchLookNewItem.EditValue, "False")
                Dim repo As New ItemRepository()
                Dim item As ItemDetails = repo.GetItem(SearchLookOldItem.EditValue, "False")
                TextNewItemName.Text = item.ItemName
                TextNewItemHasEquation.Text = item.HasProductionEquation.ToString()
                TextNewItemUnitName.Text = GetMainUnitName(SearchLookNewItem.EditValue)
                TextNewItemTransCount.Text = GetTransCount(SearchLookNewItem.EditValue)
                NewItemProductEquationCount.Text = GetProduceEquationCount(SearchLookNewItem.EditValue)
            End If
        End If
    End Sub
    Private Function GetProduceEquationCount(ItemNo As Integer) As String
        Dim _ProduceEquationCount As String
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select Count(ID) As Count from ProductionEquation  where RawItemNo= " & ItemNo & ""
        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _ProduceEquationCount = sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _ProduceEquationCount = 0
        End Try
        Return _ProduceEquationCount
    End Function

    Private Sub TextOldItemTransCount_EditValueChanged(sender As Object, e As EventArgs) Handles TextOldItemTransCount.DoubleClick
        Dim F3 As New StockMoveReport
        With F3
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.SearchLookOldItem.EditValue
            .Text = "حركة صنف ( " & TextOldItemName.Text & " )"
            .Show()
            .DateEditFrom.DateTime = CDate("1900-01-01")
            .DateEdit__To.DateTime = Today
            .RefreshData()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub TextNewItemTransCount_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewItemTransCount.DoubleClick
        Dim F3 As New StockMoveReport
        With F3
            .ColDocNoteByAccount.Visible = False
            .Warehouses.EditValue = -1
            .SearchItems.Text = Me.SearchLookNewItem.EditValue
            .Text = "حركة صنف ( " & TextNewItemName.Text & " )"
            .Show()
            .DateEditFrom.DateTime = CDate("1900-01-01")
            .DateEdit__To.DateTime = Today
            .RefreshData()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub OldItemProductEquationCount_DoubleClick(sender As Object, e As EventArgs) Handles OldItemProductEquationCount.DoubleClick
        Dim F As New ProductionRowItemLastEquations
        With F
            Dim _ItemNo As Integer
            _ItemNo = SearchLookOldItem.EditValue
            .RefreshDataToGetRowItemEquations(_ItemNo)
            .Text = "معادلات الانتاج للصنف"
            .ShowDialog()
        End With
    End Sub

    Private Sub NewItemProductEquationCount_DoubleClick(sender As Object, e As EventArgs) Handles NewItemProductEquationCount.DoubleClick
        Dim F As New ProductionRowItemLastEquations
        With F
            Dim _ItemNo As Integer
            _ItemNo = SearchLookNewItem.EditValue
            .RefreshDataToGetRowItemEquations(_ItemNo)
            .Text = "معادلات الانتاج للصنف"
            .ShowDialog()
        End With
    End Sub

    Private Sub TextOldItemHasEquation_EditValueChanged(sender As Object, e As EventArgs) Handles TextOldItemHasEquation.EditValueChanged

    End Sub

    Private Sub TextOldItemHasEquation_DoubleClick(sender As Object, e As EventArgs) Handles TextOldItemHasEquation.DoubleClick
        GetEquationTableForItem(SearchLookOldItem.EditValue)
    End Sub

    Private Sub TextNewItemHasEquation_DoubleClick(sender As Object, e As EventArgs) Handles TextNewItemHasEquation.DoubleClick
        GetEquationTableForItem(SearchLookNewItem.EditValue)
    End Sub

    Private Sub AccountingMergeItems_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class