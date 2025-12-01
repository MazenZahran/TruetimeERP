Imports System.Data.SqlClient

Public Class CarRentLists
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingModelsTypesTables()
        GetModelsTypesTables()
    End Sub
    Dim Con As SqlConnection
    Dim CarsModelsAdapter, CarsTypesAdapter As SqlDataAdapter
    Dim DS As DataSet

    Private Sub CarRentLists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetModelsTypesTables()
    End Sub

    Private Sub GetModelsTypesTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            CarsTypesAdapter = New SqlDataAdapter("SELECT [CarTypeID],[CarType] From [dbo].[CarsTypes] order by CarTypeID ", Con)
            CarsModelsAdapter = New SqlDataAdapter("SELECT [CarModelID],[CarModel]  FROM [dbo].[CarsModel] order by CarModelID ", Con)
            DS = New System.Data.DataSet()
            CarsModelsAdapter.Fill(DS, "CarsModels")
            CarsTypesAdapter.Fill(DS, "CarsTypes")
            GridControl1.DataSource = DS.Tables(0)
            GridControl2.DataSource = DS.Tables(1)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingModelsTypesTables()
        GetModelsTypesTables()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        My.Forms.CarRentRolesText.Show()
    End Sub

    Private Sub SavingModelsTypesTables()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(CarsModelsAdapter)
        CarsModelsAdapter.Update(DS, "CarsModels")
        SqlCommBuil = New SqlCommandBuilder(CarsTypesAdapter)
        CarsTypesAdapter.Update(DS, "CarsTypes")
    End Sub
End Class