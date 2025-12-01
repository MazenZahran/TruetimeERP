Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports System.Security.Cryptography

Public Class ItemsWithSubGroupInMajar
    Dim Con As SqlConnection
    Dim ItemsAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub ItemsWithSubGroupInMajar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GetItemsTable()
        RepositorySubGroup.DataSource = GetItemsSubGroupsForMatjar()
    End Sub
    Private Sub GetItemsTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ItemsAdapter = New SqlDataAdapter("SELECT [id],[ItemNo],[ItemName],[SubGroupForMatjar],[SubGroupForMatjarTarteeb]  FROM [dbo].[Items] order by id ", Con)
            DS = New System.Data.DataSet()
            ItemsAdapter.Fill(DS, "Items")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingItemsCategories()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(ItemsAdapter)
            ItemsAdapter.Update(DS, "Items")
            XtraMessageBox.Show("تم حفظ البيانات")
        Catch ex As Exception

        End Try
        '  Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingItemsCategories()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
End Class