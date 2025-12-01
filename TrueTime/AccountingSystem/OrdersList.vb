Public Class OrdersList
    Private Sub OrdersList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()

        GridView1.BestFitColumns()
        Me.KeyPreview = True
    End Sub
    Private Sub NewDocument()

        Select Case TextEditDocName.EditValue
            Case 11
                Dim ctr As Integer = 0
                Dim child As Form = Nothing
                Dim f As AccStockMove = New AccStockMove()
                f.DocName.EditValue = 1
                ctr = ctr + 1
                f.MdiParent = My.Forms.Main
                With f
                    .DocName.EditValue = 1
                    .DocName.Text = 1
                    .DocStatus.Text = -1
                    .Text = "طلبية مبيعات"
                End With
                f.Show()
        End Select

        'DeleteFromJournalTemp(TextEditDocName.EditValue, -1)

    End Sub
    Private Sub RefreshList()
        Me.GridControl1.DataSource = RefreshMoneyTransList(TextEditDocName.EditValue, False, -1)
        GridView1.BestFitColumns()
        RepositoryDebitAcc.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
        RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
    End Sub
    Private Sub OpenDoc()
        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName"))
        Dim DocData = GetDocData(DocID, DocName)
        Select Case DocName
            Case 11
                With My.Forms.AccStockMove
                    .DocStatus.EditValue = DocData.DocStatus
                    .DocID.EditValue = DocID
                    .DocName.EditValue = DocName
                    .DocDate.DateTime = CDate(DocData.DocDate)
                    .LookCostCenter.EditValue = DocData.DocCostCenter
                    .DocManualNo.Text = DocData.DocManualNo
                    .DocSort.EditValue = DocData.DocSort
                    .Referance.EditValue = DocData.Referance
                    .DocNotes.Text = DocData.DocNotes
                    .BarInputUser.Caption = DocData.InputUser
                    .JournalGridControl.DataSource = GetDocDataTable(2, DocID, "OrderJournal").FirstTable
                    '  .RepositoryUnit.DataSource = GetAllUnits()
                    '  .StockCreditWhereHouse.EditValue = GetWhareHouse(2, DocID)
                    '   .AccountForRefranace.EditValue = GetOtherAccount(2, DocID)
                    .Text = "فاتورة مبيعات"
                    .TextReferanceName.Text = DocData.ReferanceName
                    .DocCurrency.EditValue = DocData.DocCurrency
                    .ExchangePrice.Text = DocData.ExchangePrice
                    .TextOpenFrom.Text = Me.Name
                    '.LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .LookCostCenter.EditValue = DocData.DocCostCenter
                    .DocCode.Text = DocData.DocCode
                    If .DocCode.Text = "" Then .DocCode.Text = CreateRandomCode()
                    If .ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    Else
                        RefreshList()
                    End If
                End With
        End Select


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    End Sub
End Class