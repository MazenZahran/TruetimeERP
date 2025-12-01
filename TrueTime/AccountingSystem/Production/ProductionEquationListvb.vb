Imports DevExpress.XtraEditors

Public Class ProductionEquationList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetItemsEquationList()
    End Sub
    Public Sub GetItemsEquationList()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            'sqlstring = "   SELECT EquationID,
            '                       P.ItemNo,
            '                       I.ItemName,
            '                       U.name As UnitName,
            '                       EquationStatus,
            '                       Sum(RawItemAmount) AS ItemCost,
            '                       Count(RawItemNo) AS ItemsCount
            '                FROM [dbo].[ProductionEquation] P
            '                LEFT JOIN Items I ON I.ItemNo=P.ItemNo
            '                LEFT JOIN Units U ON P.ItemUnit=U.id
            '                GROUP BY EquationID,
            '                         P.ItemNo,
            '                         I.ItemName,
            '                         U.[name],
            '                         EquationStatus"
            sqlstring = "   SELECT
                            P.EquationID,
                            P.ItemNo,
                            I.ItemName,
                            U.[name]          AS UnitName,
                            IU.Price1         AS Price,
                            P.EquationStatus,
                            SUM(P.RawItemAmount)                               AS ItemCost,           -- total cost per equation
                            COUNT(P.RawItemNo)                                 AS ItemsCount,

                            -- Profit in currency
                            CAST(IU.Price1 - SUM(P.RawItemAmount) AS decimal(18,2))        AS ProfitAmount,

                            -- Profit margin in percent: (Price - Cost) / Price * 100
                            CAST(
                                ( (IU.Price1 - SUM(P.RawItemAmount)) / NULLIF(IU.Price1, 0.0) ) * 100.0
                                AS decimal(5,2)
                            ) AS ProfitMarginPct
                        FROM dbo.ProductionEquation AS P
                        LEFT JOIN dbo.Items        AS I  ON I.ItemNo   = P.ItemNo
                        LEFT JOIN dbo.Units        AS U  ON U.id       = P.ItemUnit
                        LEFT JOIN dbo.Items_units  AS IU ON IU.item_id = P.ItemNo
                                                        AND IU.unit_id = P.ItemUnit
                        GROUP BY
                            P.EquationID,
                            P.ItemNo,
                            I.ItemName,
                            U.[name],
                            P.EquationStatus,
                            IU.Price1;
"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ProductionEquationListvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetItemsEquationList()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Dim ctr As Integer = 0
        'Dim child As Form = Nothing
        Dim f As ProductionEquation = New ProductionEquation()
        'ctr = ctr + 1
        'f.MdiParent = My.Forms.Main
        With f
            .Show()
            .AddNewEquation()
            '.DocName.Text = TextEditDocName.EditValue
            '.DocStatus.Text = -1
            '.LoadDefault()
            'If TextEditDocName.EditValue = 1 Then .Text = "فاتورة مشتريات"
            'If TextEditDocName.EditValue = 17 Then .Text = "سند ادخال بضاعة"
            '.LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        End With
    End Sub

    Private Sub RepositoryDocID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryDocID.OpenLink

        Dim F As New ProductionEquation
        With F
            .EquationIDQuery.EditValue = GridView1.GetFocusedRowCellValue("EquationID")
            .ProductionEquationTableAdapter.FillByEquationID(.AccountingDataSet.ProductionEquation, .EquationIDQuery.EditValue)
            .Show()



            'If .ShowDialog <> DialogResult.OK Then
            '    GetData()
            'End If
        End With
    End Sub

    Private Sub RepositoryItemCheckStatus_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckStatus.CheckedChanged
        Dim Sql As New SQLControl
        Dim _Status As Boolean
        Try
            _Status = CBool(GridView1.GetFocusedRowCellValue("EquationStatus"))
        Catch ex As Exception
            _Status = False
        End Try

        Dim _EquationID As Integer = CInt(GridView1.GetFocusedRowCellValue("EquationID"))
        Select Case _Status
            Case False
                If XtraMessageBox.Show("هل تريد تفعيل المعادلة؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[ProductionEquation] Set [EquationStatus] =1 where [EquationID]=" & _EquationID)
                    GridView1.SetFocusedRowCellValue("EquationStatus", True)
                Else
                    GridView1.SetFocusedRowCellValue("EquationStatus", False)
                End If
            Case True
                If XtraMessageBox.Show("هل تريد ايقاف معادلة الانتاج؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Sql.SqlTrueAccountingRunQuery("Update [dbo].[ProductionEquation] Set [EquationStatus] =0 where EquationID=" & _EquationID)
                    GridView1.SetFocusedRowCellValue("EquationStatus", False)
                Else
                    GridView1.SetFocusedRowCellValue("EquationStatus", True)
                End If
        End Select
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If XtraMessageBox.Show("هل تريد تحديث تكلفة مواد الخام حساب فواتير المشتريات وبناء على اخر سعر؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "  UPDATE E
                           SET 
                           E.RawItemPrice  = IsNull(I.LastPurchasePrice,0)/IU.EquivalentToMain,
                           RawItemAmount=IsNull(I.LastPurchasePrice,0)*RawItemQuantity/IU.EquivalentToMain
                           FROM ProductionEquation E
                           JOIN Items I  ON E.RawItemNo = I.ItemNo
                           JOIN Items_units IU on I.ItemNo=IU.item_id And Iu.unit_id=E.RawItemUnit "
            If sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
                XtraMessageBox.Show("تم التحديث")
                GetItemsEquationList()
            End If
        End If
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridControl1.ShowPrintPreview()
    End Sub
End Class