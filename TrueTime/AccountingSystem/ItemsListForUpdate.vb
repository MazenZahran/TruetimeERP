Imports DevExpress.XtraSplashScreen

Public Class ItemsListForUpdate
    Private Sub ItemsListForUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try
            Me.Validate()
            Me.ItemsBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
        Catch ex As Exception
            MsgBox("لا يمكن حفظ الاصناف")
            MsgBox(ex.ToString)
        Finally
            CloseProgressPanel(handle)
        End Try
        GridView1.FocusedRowHandle = focusedRow
    End Sub
    Private Sub RefreshData()
        Me.ItemsTradeMarkTableAdapter.Fill(Me.AccountingDataSet.ItemsTradeMark)
        Me.ItemsCategoriesTableAdapter.Fill(Me.AccountingDataSet.ItemsCategories)
        Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
        Me.ItemsTableAdapter.Fill(Me.AccountingDataSet.Items)
    End Sub

    Private Sub RepositoryGroups_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryGroups.BeforePopup

    End Sub

    Private Sub RepositoryCategory_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryCategory.BeforePopup

    End Sub

    Private Sub RepositoryTradeMark_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryTradeMark.BeforePopup

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If AccountingLists.ShowDialog() <> DialogResult.OK Then
            Me.ItemsTradeMarkTableAdapter.Fill(Me.AccountingDataSet.ItemsTradeMark)
            Me.ItemsCategoriesTableAdapter.Fill(Me.AccountingDataSet.ItemsCategories)
            Me.ItemsGroupsTableAdapter.Fill(Me.AccountingDataSet.ItemsGroups)
        End If
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
            '  ElseIf e.KeyCode = Keys.Insert Then
            '      InsertSub()
            ' ElseIf e.KeyCode = Keys.F12 Then
            '    ShowPrint()
        End If
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(ItemsList.PointToScreen(e.Point))
        End If
    End Sub
    'Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
    '    Dim RowValue As String = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)
    '    For i As Integer = 0 To GridView1.RowCount - 1
    '        ' If GridView1.IsRowVisible(i) Then
    '        GridView1.SetRowCellValue(i, GridView1.Columns(GridView1.FocusedColumn.FieldName), RowValue)
    '        '  End If
    '    Next
    'End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim RowValue As String = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try

            For i As Integer = 0 To GridView1.RowCount - 1
                ' If GridView1.IsRowVisible(i) Then
                GridView1.SetRowCellValue(i, GridView1.Columns(GridView1.FocusedColumn.FieldName), RowValue)
                '  End If
            Next
        Finally
            CloseProgressPanel(Handle)
        End Try
        GridView1.FocusedRowHandle = focusedRow
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub

    Private Sub RefreshBut_Click(sender As Object, e As EventArgs) Handles RefreshBut.Click
        RefreshData()
    End Sub
End Class