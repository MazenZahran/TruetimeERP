Imports DevExpress.XtraGrid.Views.Grid

Public Class AccountingBranchesList
    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Dim F As New AccountingBranches
        With F
            ._BranchNo = GridView1.GetFocusedRowCellValue("ID")
            ._AddOrEdit = "Edit"
            .TextBranchName.Text = GridView1.GetFocusedRowCellValue("BranchName")
            .Text = " تعديل الفرع " & "(" & GridView1.GetFocusedRowCellValue("BranchName") & ")"
            If .ShowDialog <> DialogResult.OK Then
                GridControl1.DataSource = GetAccountingBranches()
            End If
        End With
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        ' tt hghg
        Dim F As New AccountingBranches
        With F
            ._BranchNo = GridView1.GetFocusedRowCellValue("ID")
            ._AddOrEdit = "Add"
            .Text = " اضافة فرع جديد "
            If .ShowDialog <> DialogResult.OK Then
                GridControl1.DataSource = GetAccountingBranches()
            End If
        End With
    End Sub

    Private Sub AccountingBranchesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl1.DataSource = GetAccountingBranches()
    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        If GridView1.Editable Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف الفرع؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim sql As New SQLControl
                If sql.SqlTrueAccountingRunQuery(" delete from [dbo].[AccountingBranches] where [ID]=" & GridView1.GetFocusedRowCellValue("ID")) = True Then
                    MsgBoxShowSuccess(" تم حذف الفرع بنجاح ")
                    GridControl1.DataSource = GetAccountingBranches()
                End If
            End If
        End If
    End Sub
End Class