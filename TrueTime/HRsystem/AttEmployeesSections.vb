Imports System.Data.SqlClient

Public Class AttEmployeesSections
    Dim Con As SqlConnection
    Dim SectionsAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub AttEmployeesSections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetSectionsTables()
    End Sub
    Private Sub GetSectionsTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            SectionsAdapter = New SqlDataAdapter("SELECT [ID],[SectionName] From [dbo].[EmployeesSections] order by [ID] ", Con)
            DS = New System.Data.DataSet()
            SectionsAdapter.Fill(DS, "EmployeesSections")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingSectionsTables()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(SectionsAdapter)
        SectionsAdapter.Update(DS, "EmployeesSections")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SavingSectionsTables()
        GetSectionsTables()
    End Sub
End Class