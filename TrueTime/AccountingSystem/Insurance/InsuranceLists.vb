Imports System.Data.SqlClient

Public Class InsuranceLists
    Dim Con As SqlConnection
    Dim InsuranceCarsCoverTypesAdapter, InsuranceCarsTypesAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub GetTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            InsuranceCarsCoverTypesAdapter = New SqlDataAdapter("SELECT [ID] ,[CoverType]  
                                             FROM [dbo].[InsuranceCarsCoverTypes] ", Con)
            InsuranceCarsTypesAdapter = New SqlDataAdapter("SELECT [ID] ,[CarType] 
                                             FROM [dbo].[InsuranceCarsTypes] ", Con)
            DS = New System.Data.DataSet()
            InsuranceCarsTypesAdapter.Fill(DS, "InsuranceCarsTypes")
            InsuranceCarsCoverTypesAdapter.Fill(DS, "InsuranceCarsCoverTypes")
            GridControl1.DataSource = DS.Tables(0)
            GridControl2.DataSource = DS.Tables(1)

            AccountForInsuranceExp.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)

            Try
                Dim Sql As New SQLControl
                Sql.SqlTrueAccountingRunQuery("Select [SettingValue] from [dbo].[Settings] where [SettingName]='DefualtAccountForInsuranceExpense'")
                AccountForInsuranceExp.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            Catch ex As Exception

            End Try

        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub

    Private Sub InsuranceLists_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTables()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingTables()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingTables()
    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] 
                                       Set SettingValue ='" & AccountForInsuranceExp.EditValue & "' 
                                       Where SettingName='DefualtAccountForInsuranceExpense'")
    End Sub

    Private Sub SavingTables()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(InsuranceCarsCoverTypesAdapter)
        InsuranceCarsCoverTypesAdapter.Update(DS, "InsuranceCarsCoverTypes")
        SqlCommBuil = New SqlCommandBuilder(InsuranceCarsTypesAdapter)
        InsuranceCarsTypesAdapter.Update(DS, "InsuranceCarsTypes")
        GetTables()
    End Sub
End Class