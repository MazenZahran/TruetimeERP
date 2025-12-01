Public Class ItemsBatchReport
    Private Sub ItemsBatchReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetData()
    End Sub
    Private Sub GetData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " 
                    Select A.ID,A.BatchNo,D.ItemName,A.ItemNo,A.[ExpireDate],IsNull(b.[In],0) as [In],IsNull(C.[Out],0) as [Out] , (IsNull(b.[In],0) - IsNull(C.[Out],0)) as balance  from
                      (select *   FROM [dbo].[ItemBatchNo]   ) A
                    left join 
                      ( SELECT J.batchID,ISNull(case when J.DocName in (1) then sum(J.StockQuantityByMainUnit) end ,0) as 'In'
                        from  Journal J 
                        where DocStatus > 0 and J.BatchID <> 0 and BatchID is not null and DocName in (1)
                        group by batchID,DocName ) B
                    on A.ID=B.batchID
                    left join 
                      ( SELECT  J.batchID,ISNull(case when J.DocName in (2) then sum(J.StockQuantityByMainUnit) end ,0) as 'Out'
	                    from  Journal J 
	                    where DocStatus > 0 and J.BatchID <> 0 and BatchID is not null and DocName in (2)
                    group by batchID,DocName ) C
                    on A.ID=C.batchID 
				    left join 
                      ( SELECT ItemNo,ItemName
	                    from  Items I 
	                     ) D
                    on A.ItemNo=D.ItemNo "
            If CheckEditHideZeroBalances.CheckState = True Then sqlstring += " where (IsNull(b.[In],0) - IsNull(C.[Out],0)) <> 0 "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try
    End Sub
End Class