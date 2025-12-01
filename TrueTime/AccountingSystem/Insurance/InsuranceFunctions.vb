Module InsuranceFunctions
    Public Function GetInsuranceTypes()
        Dim InsuranceTypes As New DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "SELECT  [TypeID],[InsuranceTypeName]  FROM [InsuranceTypes] Order By TypeID"
        Try
            Sql.SqlTrueAccountingRunQuery(SqlString)
            InsuranceTypes = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return InsuranceTypes
    End Function

    Public Function GetInsuranceCars(Referance As Integer)

        Dim InsuranceTypes As New DataTable
        If String.IsNullOrEmpty(Referance) Then
            Return InsuranceTypes
        End If
        If IsNothing(Referance) Then
            Return InsuranceTypes
        End If
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = "SELECT  [CarID],[CARNO] FROM [dbo].[CarsRent] 
                             WHERE OwnByReferance=" & Referance & " Order By CarID"
        Try
            Sql.SqlTrueAccountingRunQuery(SqlString)
            InsuranceTypes = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return InsuranceTypes
    End Function

    Public Function GetInsuranceCarsTypes()
        Dim InsuranceCarsTypes As New DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT  [ID],[CarType]  FROM [dbo].[InsuranceCarsTypes] "
        Try
            Sql.SqlTrueAccountingRunQuery(SqlString)
            InsuranceCarsTypes = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return InsuranceCarsTypes
    End Function
    Public Function GetInsuranceCarsCoverTypes()
        Dim InsuranceCarsCoverTypes As New DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [ID] ,[CoverType]  FROM [dbo].[InsuranceCarsCoverTypes] "
        Try
            Sql.SqlTrueAccountingRunQuery(SqlString)
            InsuranceCarsCoverTypes = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return InsuranceCarsCoverTypes
    End Function

    Public Function CreateInsuranceDocumentsStatusTable() As DataTable
        Dim table As New DataTable
        table.Columns.Add("DocStatus", GetType(Integer))
        table.Columns.Add("DocName", GetType(String))
        table.Rows.Add(1, "محفوظ")
        table.Rows.Add(2, "مفوتر")
        Return table
    End Function

End Module
