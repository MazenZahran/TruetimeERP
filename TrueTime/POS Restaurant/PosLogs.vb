Public Class PosLogs
    Private Sub PosLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As New SQLControl
        Dim sqlstring = " SELECT TOP (1000) [ID]
      ,[DocCode]
      ,[DocName]
      ,[DocID]
      ,[LogName]
      ,[UserID]
      ,[LogDateTime]
      ,[DeviceName]
      ,[UserName]
      ,[LogDetails]
      ,[LogType]
  FROM [dbo].[UsersLogs]
  where LogDetails like '%Item%'
  order by id desc "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        Me.GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub
End Class