Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraSplashScreen

Public Class PosSelectShelf
    Public _ItemNo As Integer
    Public _ItemName As String
    Public _ItemBarcode As String
    Private Sub PosSelectShelf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        StockCreditWhereHouse.Properties.DataSource = GetWharehouses(False)
        StockCreditWhereHouse.EditValue = GetDefaltWahreHouseForUser(CInt(GlobalVariables.CurrUser))
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
    End Sub

    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub TextItemBarcode_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            GetDataForPosSelectShelf()
        End If
    End Sub

    Public Sub GetDataForPosSelectShelf()
        If Me.TextItemBarcode.Text = "" And Me.TextItemNo.Text = "" Then
            XtraMessageBox.Show("يجب اختيار صنف")
        Else
            Dim _ItemNo As Integer
            If Me.TextItemNo.Text = "" Then
                _ItemNo = 0
            Else
                _ItemNo = Me.TextItemNo.EditValue
            End If

            GridControl1.DataSource = ""
            GridControl1.DataSource = GetItemShelfLocationByBarcode(TextItemBarcode.Text, _ItemNo, CheckShowAllBarcodes.EditValue, StockCreditWhereHouse.EditValue, CheckGroupByBarcode.EditValue)
        End If
    End Sub
    Private Sub TileView1_ItemPress(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs) Handles TileView1.ItemPress
        TextShelf.Text = TileView1.GetFocusedRowCellValue("ShelvID")
        ShelfCode.Text = TileView1.GetFocusedRowCellValue("ShelfCode")
        If Me.TextOpenFrom.Text <> "" Then
            Me.Dispose()
        End If
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.TileView1.ShowPrintPreview()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetDataForPosSelectShelf()
    End Sub

    Private Sub ButtonEdit1_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TextItemBarcode.Properties.ButtonClick
        Dim F3 As New ItemsSearchMenue
        With F3
            .TextFromForm.Text = Me.Name
            .ColOpen.Visible = False
            If .ShowDialog() <> DialogResult.OK Then
                Me.TextItemName.Text = _ItemNameGlobal
                Me.TextItemBarcode.Text = _ItemBarcodeGlobal
                Me.TextItemNo.Text = ""
                GetDataForPosSelectShelf()
                TextItemBarcode.Select()
            End If
        End With
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemBarcode.EditValueChanged
        If TextItemBarcode.Text <> "" Then
            Try
                Me.TextItemNo.Text = ""
                Me.TextItemName.Text = ""
                Dim sql As New SQLControl
                Dim sqlstring As String = " select ItemNo,ItemName  
                                        from Items I 
                                        left Join Items_units IU on IU.item_id=I.ItemNo  
                                        where IU.item_unit_bar_code='" & TextItemBarcode.Text & "'"
                sql.SqlTrueAccountingRunQuery(sqlstring)
                Me.TextItemName.Text = sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
            Catch ex As Exception
                Me.TextItemName.Text = ""
            End Try

        End If
    End Sub



    Private Sub TextItemNo_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TextItemNo.Properties.ButtonClick
        Dim F3 As New ItemsSearchMenue
        With F3
            .TextFromForm.Text = Me.Name
            .ColOpen.Visible = False
            If .ShowDialog() <> DialogResult.OK Then
                Me.TextItemName.Text = _ItemNameGlobal
                Me.TextItemNo.Text = _ItemNoGlobal
                Me.TextItemBarcode.Text = ""
                GetDataForPosSelectShelf()
                TextItemBarcode.Select()
            End If
        End With
    End Sub

    Private Sub TextItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemNo.EditValueChanged
        If TextItemNo.Text <> "" Then
            Try
                Me.TextItemName.Text = ""
                Me.TextItemBarcode.Text = ""
                Dim sql As New SQLControl
                Dim sqlstring As String = " select ItemNo,ItemName  
                                        from Items I 
                                        where ItemNo='" & TextItemNo.Text & "'"
                sql.SqlTrueAccountingRunQuery(sqlstring)
                Me.TextItemName.Text = sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
            Catch ex As Exception
                Me.TextItemName.Text = ""
            End Try

        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class