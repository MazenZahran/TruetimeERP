Public Class BankAccountsList
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        BankAccount.TextID.EditValue = -1

        If BankAccount.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If

    End Sub
    Private Sub RefreshList()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT  A.[ID]
      ,A.[BankName]
      ,[BankDepositAccount]
      ,[BankOutChequeAccount]
      ,[BankCheqsTahselAccount]
      ,[UserID]
      ,[BankAccID]
      ,[Currency]
	  ,B.BankName
	  ,R.BranchName
  FROM [dbo].[BanksAccounts] A
  left join Bank B on B.ID=A.[BankID]
  left join BankBranche R on R.ID=A.BranchID  ")
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        RepositoryBankDepositAccount.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryItemLookUpEdit1.DataSource = GetCurrency()
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshList()
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        My.Forms.BankAccount.TextID.EditValue = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ID")
        If BankAccount.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub

    Private Sub BankAccountsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
        DocCurrency.Properties.DataSource = GetCurrency()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim f As New BankAccountReplaceName
        With f
            If .ShowDialog <> DialogResult.OK Then
                RefreshList()
            End If
        End With
    End Sub
End Class