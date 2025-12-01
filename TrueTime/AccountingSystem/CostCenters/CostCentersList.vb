Public Class CostCentersList
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        GetCostCenters()
    End Sub
    Private Sub GetCostCenters()
        Dim sql As New SQLControl
        Dim sqlstring As String = " SELECT [CostID],[CostName],[CostCenterTypeID],
                                        [CostCenterImage],[StartDate],[EndDate],
                                        [Notes] ,IsNull([CostCenterStatus],1) as CostCenterStatus,T.[Type],ISNULL(CompletionRate,0) As CompletionRate,R.RefName As SupplierName
                                    FROM [dbo].[CostCenter] C
                                    Left Join CostCenterTypes T on C.CostCenterTypeID=T.ID 
                                    Left Join Referencess R on R.RefNo=C.Supplier"
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControlCostCentersList.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub CostCentersList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCostCenters()
    End Sub

    Private Sub BtnAddNew_Click(sender As Object, e As EventArgs) Handles BtnAddNew.Click
        OpenCostCenterForm()
    End Sub
    Private Sub OpenCostCenterForm(Optional costCenterId As Integer = 0)
        'Try
        ' Create a new instance of the CostCenterForm
        Dim costCenterForm As New CostCenterForm()

            ' If a costCenterId is provided, load that cost center for editing
            If costCenterId > 0 Then
                costCenterForm.LoadCostCenter(costCenterId)
            End If

            ' Show the form as a dialog
            Dim result As DialogResult = costCenterForm.ShowDialog()

            ' If any changes were made, refresh the grid
            If result = DialogResult.OK OrElse result = DialogResult.Yes Then
                GetCostCenters()
            End If
        'Catch ex As Exception
        '    DevExpress.XtraEditors.XtraMessageBox.Show("خطأ في فتح نموذج مركز التكلفة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub RepositoryID_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryID.OpenLink
        MsgBox(e.EditValue.ToString)
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        If GridViewCostCentersList.FocusedRowHandle >= 0 Then
            Try
                Dim costCenterId As Integer = Convert.ToInt32(GridViewCostCentersList.GetFocusedRowCellValue("CostID"))
                OpenCostCenterForm(costCenterId)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("خطأ في فتح مركز التكلفة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class