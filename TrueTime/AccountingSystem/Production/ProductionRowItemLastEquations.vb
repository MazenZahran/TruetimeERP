Public Class ProductionRowItemLastEquations

    Private Sub ProductionRowItemLastEquations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'RefreshDataToGetRowItemEquations()
    End Sub
    Public Sub RefreshDataToGetRowItemEquations(_ItemNo As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT [EquationID] ,
                               P.[ItemNo] ,
                               I.ItemName ,
                               UU.name AS [ItemUnit] ,
                               [ItemQuantity] ,
                               [DocNote] ,
                               [RawItemNo] ,
                               [RawItemName] ,
                               [RawItemQuantity] ,
                               U.name AS [RawItemUnit] ,
                               IsNull(I.LastPurchasePrice, 0) AS [RawItemPrice] ,
                               [RawItemAmount] ,
                               [EquationStatus]
                        FROM [dbo].[ProductionEquation] P
                        LEFT JOIN [dbo].Items I ON P.ItemNo=I.ItemNo
                        LEFT JOIN [dbo].Items II ON II.ItemNo=P.RawItemNo
                        LEFT JOIN Units U ON U.id=P.[RawItemUnit]
                        LEFT JOIN units UU ON UU.id=P.[ItemUnit]
                        WHERE [RawItemNo]= " & _ItemNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RepositoryEquationID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryEquationID.OpenLink
        Dim F As New ProductionEquation
        With F
            .EquationIDQuery.EditValue = BandedGridView1.GetFocusedRowCellValue("EquationID")
            .ProductionEquationTableAdapter.FillByEquationID(.AccountingDataSet.ProductionEquation, .EquationIDQuery.EditValue)
            .Show()



            'If .ShowDialog <> DialogResult.OK Then
            '    GetData()
            'End If
        End With
    End Sub
End Class