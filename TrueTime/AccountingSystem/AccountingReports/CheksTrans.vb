Public Class CheksTrans
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetChekTrans()
        '  GridControl1.MainView = CardView1
    End Sub
    Private Sub GetChekTrans()
        Dim _CheckInOut As String = "0"
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " Select [CheckInOut] from [dbo].[Checks] where [CheckCode]= '" & Me.TextCheckCode.Text & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _CheckInOut = Sql.SQLDS.Tables(0).Rows(0).Item("CheckInOut")
        Catch ex As Exception
            Exit Sub
        End Try

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "   Select J.[DocID],[DocDate] ,D.[Name],J.DocName,
Case When J.CheckInOut='IN' then DebitAcc When J.CheckInOut='OUT' Then CredAcc End as AccNo  , 
Case When J.CheckInOut='IN' then A.AccName When J.CheckInOut='OUT' Then AA.AccName End as AccName ,
[DocAmount],ExchangePrice,BaseCurrAmount,R.RefName,Cs.CheckStatus
From Journal J
Left Join [dbo].[Checks] C On J.CheckCode=C.CheckCode 
left join Referencess R on R.RefNo=J.Referance
left join FinancialAccounts A on A.AccNo=J.DebitAcc
left join FinancialAccounts AA on AA.AccNo=J.CredAcc 
left Join [dbo].[ChecksStatus] Cs on Cs.ID=J.CheckStatus 
left Join [dbo].[DocNames] D on D.id=J.DocName
Where    DocStatus<>0 and  J.CheckCode='" & Me.TextCheckCode.Text & "'"
            If _CheckInOut = "IN" Then SqlString += " And [DebitAcc]<>0 "
            If _CheckInOut = "OUT" Then SqlString += " And [DebitAcc]=0 "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        GridView1.BestFitColumns()
    End Sub

    Private Sub CheksTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            GetChekTrans()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub TextCheckCode_EditValueChanged(sender As Object, e As EventArgs) Handles TextCheckCode.EditValueChanged
        GetChekTrans()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName"))
        Dim DocData = GetDocData(DocID, DocName)
        Select Case DocName

            Case 3, 4
                With My.Forms.MoneyTrans
                    .TextDocID.EditValue = DocID
                    .DocName.EditValue = DocName
                    .TextDocIDQuery.EditValue = DocID
                    .TextOpenFrom.Text = Me.Name
                    If .ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    Else
                        GetChekTrans()
                    End If
                End With
            Case 5
                With My.Forms.Journal
                    .TextDocIDQuery.EditValue = 0
                    .TextDocID.EditValue = DocID
                    .DocName.EditValue = DocName
                    .TextDocIDQuery.EditValue = DocID
                    .TextOpenFrom.Text = Me.Name
                    .DateDocDate.Select()
                    If .ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    Else
                        GetChekTrans()
                    End If
                End With
        End Select
    End Sub
End Class