Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Grid
Public Class TagsNamesList
    Dim Con As SqlConnection
    Dim TagsAdapter As SqlDataAdapter
    Dim DS As DataSet

    Private Sub TagsNamesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTagsTable()
    End Sub
    Private Sub GetTagsTable()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            TagsAdapter = New SqlDataAdapter("SELECT * From [dbo].[Tags] order by ID ", Con)
            DS = New System.Data.DataSet()
            TagsAdapter.Fill(DS, "Tags")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingTagsTables()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(TagsAdapter)
        TagsAdapter.Update(DS, "Tags")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SavingTagsTables()
        Me.Close()
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Try
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub
End Class