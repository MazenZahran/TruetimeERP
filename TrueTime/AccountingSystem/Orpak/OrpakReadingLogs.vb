Public Class OrpakReadingLogs
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " SELECT  [ID],[StartTime],[EndTime],[executionTime],[TransInOrpakCount]  
                              FROM [dbo].[OrpakReadCSTMRTransLogs] "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class