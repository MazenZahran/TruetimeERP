Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class PosHoldVouchers
    Private Sub PosHoldVouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetVouchers()
    End Sub
    Private Sub GetVouchers()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Select Sum(BaseAmount) As Amount,Count(DocID) As Quantity,DocCode,InputDateTime,DocID,DocNotes,Referance,ReferanceName
                      from POSHoldJournal where [TableID]=0 And PosNo=" & My.Settings.POSNo & " And DeviceName='" & GlobalVariables.CurrDevice & "'
                      Group by DocCode,InputDateTime,DocID,DocNotes,Referance,ReferanceName  Order By DocID "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TileView1_ItemClick(sender As Object, e As Views.Tile.TileViewItemClickEventArgs) Handles TileView1.ItemClick
        Dim _DocCode, _DocNotes, _Referance, _ReferanceName As String
        _DocCode = TileView1.GetFocusedRowCellValue("DocCode")
        _DocNotes = TileView1.GetFocusedRowCellValue("DocNotes")
        _Referance = TileView1.GetFocusedRowCellValue("Referance")
        _ReferanceName = TileView1.GetFocusedRowCellValue("ReferanceName")
        POSRestCashier._HoldVoucherCode = _DocCode
        POSRestCashier._PosVoucherNote = _DocNotes

        With POSRestCashier
            Select Case _Referance
                Case ""
                    .TextReferanceNo.Text = ""
                    .TextReferanceName.Text = ""
                    .Text = "فاتورة مبيعات"
                    .TextOtherAccountNo.Caption = GlobalVariables._DefaultBaseCashAccount
                    .TextOtherAccountName.Caption = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
                    '.ReferanceNameItem.Caption = ""
                    .TextReferanceName.Text = "زبون نقدي"
                Case "0"
                    .TextReferanceNo.Text = ""
                    .TextReferanceName.Text = ""
                    .Text = "فاتورة مبيعات"
                    .TextOtherAccountNo.Caption = GlobalVariables._DefaultBaseCashAccount
                    .TextOtherAccountName.Caption = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
                    '.ReferanceNameItem.Caption = ""
                    .TextReferanceName.Text = "زبون نقدي"
                Case Else
                    .TextReferanceNo.Text = _Referance
                    .BarReferanceNo.Caption = _Referance
                    .TextReferanceName.Text = _ReferanceName
                    .Text = "فاتورة مبيعات"
                    .TextOtherAccountNo.Caption = GetRefranceData(_Referance).RefAccID
                    .TextOtherAccountName.Caption = GetFinancialAccountsData(_Referance).AccName
                    '.ReferanceNameItem.Caption = _ReferanceName
                    .TextReferanceName.Text = _ReferanceName
            End Select
            .ChangePosModeInResturantMode("TakeAway")
        End With
        Dim sql As New SQLControl

        'POSRestCashier.Referance.EditValue = _Referance
        'POSRestCashier.ReferanceNameItem.Caption = _Referance
        Me.Close()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    'Private Sub TileView1_MouseMove(sender As Object, e As MouseEventArgs) Handles TileView1.MouseMove
    '    BeginInvoke(CType(Function() AnonymousMethod1(sender), MethodInvoker))
    'End Sub

    'Private Function AnonymousMethod1(ByVal sender As Object) As Boolean
    '    Dim control As GridControl = TryCast(sender, GridControl)
    '    Dim hi As TileControlHitInfo = control.CalcHitInfo(control.PointToClient(MousePosition))
    '    If hi.InItem Then
    '        Cursor = Cursors.Hand
    '    Else
    '        Cursor = Cursors.Arrow
    '    End If
    '    Return True
    'End Function
End Class