Imports DevExpress.XtraEditors

Public Class Campaignes
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetCampagins()
    End Sub
    Private Sub GetCampagins()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select [ID],[CampaginName],[CampaginType],
                                 [FromDate],[ToDate],[Active],CampaginNotes,
                                 [CampaginCode] From [dbo].[Campagins] "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim F As New CampaignesByProductQuantity
        With F
            .TextNewOld.Text = "New"
            .ShowDialog()
        End With

    End Sub

    Private Sub Campaignes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCampagins()
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        CampaignesByProductQuantity.TextID.EditValue = GridView1.GetFocusedRowCellValue("ID")
        CampaignesByProductQuantity.TextNewOld.Text = "Old"
        CampaignesByProductQuantity.Show()
    End Sub



    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        ' If RepositoryItemCheckEdit1.check
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        Dim f As New CampaignesByProductQuantity
        With f
            .TextID.EditValue = GridView1.GetFocusedRowCellValue("ID")
            .TextNewOld.Text = "Old"
            Dim child As Form = Nothing

            If child Is Nothing Then
                child = f
                child.MdiParent = My.Forms.Main
                child.Show()
            Else
                child.Activate()
            End If
            'If .ShowDialog() <> DialogResult.OK Then
            '    GetCampagins()
            'End If
        End With




    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        If XtraMessageBox.Show("هل تريد حذف الحملة ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Dim Sql As New SQLControl
            Dim sqlString As String
            sqlString = " Delete From [dbo].[Campagins] Where ID = " & GridView1.GetFocusedRowCellValue("ID")
            sqlString += " ; Delete From [dbo].[CampaginByItemsCount] Where [CampaginID] = " & GridView1.GetFocusedRowCellValue("ID")
            Sql.SqlTrueAccountingRunQuery(sqlString)
            GetCampagins()
        End If
    End Sub
End Class