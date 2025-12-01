Public Class VehicleMaintenanceList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT  M.[ID]  As DocID
                        ,V.CARNO  ,[DocDate]
                        ,R.RefName 
                        ,M.[Notes] ,[OdometerCurrent]
                        ,[OdometerNext] ,E.EmployeeName 
                        ,[Cost],[Paid]              
                      FROM [dbo].[Vehicle Maintenance] M
					  left join Vehicles V on V.CarID=M.CarID 
					  left join EmployeesData E on E.EmployeeID=M.Driver 
					  left join Referencess R on R.RefNo=M.RefNo  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim f As New VehicleMaintenance
        With f
            .AddNewMaintenanceDocument()
            If .ShowDialog <> DialogResult.OK Then
                RefreshData()
            End If
        End With
    End Sub

    Private Sub VehicleMaintenanceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim f As New VehicleMaintenance
        With f
            .TextDocID.EditValue = GridView1.GetFocusedRowCellValue("DocID")
            .GetMaintenanceDocument()
            If .ShowDialog <> DialogResult.OK Then
                RefreshData()
            End If
        End With
    End Sub
End Class