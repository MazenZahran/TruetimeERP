Public Class ItemsAvailableBatches
    Private _ItemNo As Integer
    Private Sub ItemsAvailableBatches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridControl1.Select()
        GridView1.SelectRow(0)
        Me.KeyPreview = True
    End Sub
    'Public Sub New(ItemNo As Integer)

    '    ' This call is required by the designer.
    '    InitializeComponent()
    '    _ItemNo = ItemNo
    '    ' Add any initialization after the InitializeComponent() call.

    'End Sub

    Private Sub TextItemNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemNo.EditValueChanged
        GetData()
    End Sub
    Private Sub GetData()
        If String.IsNullOrEmpty(TextItemNo.Text) Then Exit Sub
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "   Declare @ItemNo int
                        Set @ItemNo=" & TextItemNo.Text & "
                        Select A.ID,A.BatchNo,A.[ExpireDate],IsNull(b.[In],0) as [In],IsNull(C.[Out],0) as [Out] , (IsNull(b.[In],0) - IsNull(C.[Out],0)) as balance  from
                          (select *   FROM [dbo].[ItemBatchNo] where ItemNo=@ItemNo  ) A
                        left join 
                          ( SELECT J.batchID,ISNull(case when J.DocName in (1) then sum(J.StockQuantityByMainUnit) end ,0) as 'In'
                            from  Journal J 
                            where StockID=@ItemNo and DocStatus > 0 And J.BatchID <> 0 and BatchID is not null and DocName in (1)
                            group by batchID,DocName ) B
                        on A.ID=B.batchID
                        left join 
                          ( SELECT J.batchID,ISNull(case when J.DocName in (2) then sum(J.StockQuantityByMainUnit) end ,0) as 'Out'
	                        from  Journal J 
	                        where StockID=@ItemNo and DocStatus > 0 And J.BatchID <> 0 and BatchID is not null and DocName in (2)
                        group by batchID,DocName ) C
                        on A.ID=C.batchID "
        sql.SqlTrueAccountingRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryOK_Click(sender As Object, e As EventArgs) Handles RepositoryOK.Click
        GetBatch()
    End Sub
    Private Sub GetBatch()
        Dim _BatchID As Integer
        Dim _BatchNo As String
        _BatchID = GridView1.GetFocusedRowCellValue("ID")
        _BatchNo = GridView1.GetFocusedRowCellValue("BatchNo")
        GlobalVariables._BatchIDTemp = _BatchID
        GlobalVariables._BatchNoTemp = _BatchNo
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim f As New ItemDefineBatch
        With f
            .TextItemNo.Text = Me.TextItemNo.Text
            .TextItemName.Text = Me.TextItemName.Text
            If .ShowDialog <> DialogResult.OK Then
                GetData()
            End If
        End With
    End Sub

    Private Sub GridControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridControl1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetBatch()
        End If
    End Sub
End Class