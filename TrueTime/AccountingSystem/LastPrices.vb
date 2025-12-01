Imports DevExpress.XtraPrinting

Public Class LastPrices
    Private Sub LastPrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' GetLastPrices(-1)
    End Sub

    Public Sub GetLastPrices(RefNo As String)
        Try
            If String.IsNullOrEmpty(TextPurchaseOrSale.Text) Then
                Exit Sub
            End If
            If String.IsNullOrEmpty(StockID.EditValue) Or StockID.Text = "0" Then
                Exit Sub
            End If
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select DocID,DocDate,D.Name,ReferanceName, 
                                 StockPrice,
                                 DocCode,U.name as StockUnit,J.DocName,J.StockQuantity,InputUser,InputDateTime,
                                 J.DocAmount,StockBarcode,J.ItemName,C.Code as CurrencyCode,J.[StockPrice]/IU.EquivalentToMain As UnitPrice
                      From Journal J
                      Left join DocNames D on J.DocName=D.id
                      Left join Units U on J.StockUnit=U.id 
                      left join Currency C on c.CurrID=J.DocCurrency
                      left join Items_Units IU on IU.item_id=J.StockID And J.StockUnit=IU.unit_id
                      Where DocStatus<>0 "
            If TextPurchaseOrSale.Text = "1" Then SqlString += " And DocName in (1,17,19)"
            If TextPurchaseOrSale.Text = "2" Then SqlString += " And DocName in (2,18,19)"
            If RefNo <> "-1" Then SqlString += " And Referance= '" & RefNo & "'"
            SqlString += "and StockID<>0 and StockID is not null and StockID='" & StockID.Text & "'
                      Order by DocDate"

            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'GetLastPrices()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControl1.ShowPrintPreview()
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
        Dim HeaderText As String = ""
        If TextPurchaseOrSale.Text = 1 Then
            HeaderText = " اسعار الشراء للصنف  " & Me.TextItemName.Text
        ElseIf TextPurchaseOrSale.Text = 2 Then
            HeaderText = " اسعار البيع للصنف  " & Me.TextItemName.Text
        End If
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {"Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(HeaderText)





    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim _DocCode As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")
        Dim _DocName As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName")
        OpenDocumentsByDocCode(_DocCode, "Journal", _DocName)
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim _DocCode As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")
        Dim _DocName As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName")
        OpenDocumentsByDocCode(_DocCode, "Journal", _DocName)
    End Sub
End Class