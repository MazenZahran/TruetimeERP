Module VehiclesFunctions
    Public Function GetCarsList(Active As Boolean) As DataTable
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select CarID,CARNO from Vehicles "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Return sql.SQLDS.Tables(0)
    End Function
End Module
