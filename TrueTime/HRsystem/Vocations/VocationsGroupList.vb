Imports DevExpress.XtraEditors

Public Class VocationsGroupList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "  SELECT DISTINCT [BatchNo],VocationType, count([EmployeeID]) As EmpCount,[FromDate],[ToDate],[NoteDetails]
                       FROM [Vocations]
                       Where [BatchNo] is not null
                       Group by [BatchNo],[FromDate] ,[ToDate],[NoteDetails],VocationType "
            Sql.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub RepositoryButtonDisplay_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryButtonDisplay.ButtonClick
        Dim sql As New SQLControl
        Dim Sqlstring As String
        Sqlstring = " Select  EmployeesData.EmployeeID,EmployeeName,[Department],
                              [JobName],[Branch],[Active], 'True' as chk
                      FROM  EmployeesData 
                          left join Vocations on Vocations.EmployeeID  = EmployeesData.EmployeeID  
                      where EmployeesData.EmployeeID is not null and Vocations.BatchNo =  " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BatchNo")

        sql.SqlTrueTimeRunQuery(Sqlstring)
        ' My.Forms.VocationForGroup.GridControl1.DataSource = sql.SQLDS.Tables(0)
        With My.Forms.VocationForGroup
            .GridControl1.DataSource = sql.SQLDS.Tables(0)
            .LayoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            .Colchk.OptionsColumn.AllowEdit = False
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden
            .Show()
        End With
        '   My.Forms.VocationForGroup.Show()



    End Sub

    Private Sub RepositoryDeleteBatch_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDeleteBatch.ButtonClick
        Try
            Dim Msg As DialogResult = XtraMessageBox.Show(" هل تريد حذف السند؟  ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Delete from vocations where BatchNo = " & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BatchNo")
            Sql.SqlTrueTimeRunQuery(SqlString)
            RefreshData()
            XtraMessageBox.Show(" هل تريد حذف السند؟  ", "تم", MessageBoxButtons.OK, MessageBoxIcon.None)
        Catch ex As Exception
            XtraMessageBox.Show("خطأ: لم يتم حذف السند")
        End Try

    End Sub

    Private Sub VocationsGroupList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        RefreshData()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
End Class