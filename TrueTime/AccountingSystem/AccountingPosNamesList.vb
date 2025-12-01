Public Class AccountingPosNamesList
    Private Sub AccountingPosNamesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPosNamesList()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim F As New AccountingPosNamesAdd
        With F
            ._PosID = GridView1.GetFocusedRowCellValue("ID")
            ._AddOrEdit = "Add"
            .Text = " اضافة نقطة بيع  "
            If .ShowDialog <> DialogResult.OK Then
                GetPosNamesList()
            End If
        End With
    End Sub

    Private Sub RepositoryItemDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDelete.ButtonClick
        If GridView1.Editable Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف نقطة البيع؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim sql As New SQLControl
                If sql.SqlTrueAccountingRunQuery(" Delete from [dbo].[AccountingPOSNames] 
                                                   Where [ID]=" & GridView1.GetFocusedRowCellValue("ID")) = True Then
                    MsgBoxShowSuccess(" تم حذف نقطة البيع بنجاح ")
                    GetPosNamesList()
                End If
            End If
        End If
    End Sub

    Private Sub RepositoryItemEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemEdit.ButtonClick
        Dim F As New AccountingPosNamesAdd
        With F
            ._PosID = GridView1.GetFocusedRowCellValue("ID")
            .GetPosNameData()
            ._AddOrEdit = "Edit"
            .Text = " تعديل نقطة البيع " & "(" & GridView1.GetFocusedRowCellValue("POSName") & ")"
            If .ShowDialog <> DialogResult.OK Then
                GetPosNamesList()
            End If
        End With
    End Sub
    Private Sub GetPosNamesList()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  P.[ID],[POSCode],[POSName],C.[CostName] as CostName
                        ,[PrefixCode],B.[BranchName] as BranchName,W.[WarehouseNameAR] as WarehouseNameAR,[OnlineOnly]
                        ,[Note1],[Note2],[PaperSize],[OpenCashDrawerOnSave]
                        ,[POSQr],[ServerAddress],[DefaultPrinter],[Tickets]
                        ,[UseDirectProduction],[SamabaPos],[TempAccounting],[ItemsGroups]
                        ,[PosType]
                      FROM [dbo].[AccountingPOSNames] P
                      left join Warehouses W on  W.WarehouseID=P.Warehouse
                      left join AccountingBranches B on B.ID=P.BranchID 
                      left join CostCenter C on C.CostID=P.CostCenter   "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

End Class