Public Class AttAdvancePaymentList
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshingAttAdvancePaymentList()
    End Sub

    Public Sub RefreshingAttAdvancePaymentList()

        Try
            GridControl1.DataSource = ""
            Dim sql As New SQLControl
            Dim RefreshString As String = " SELECT [PaymentID]
                                          ,[PaymentDate]
                                          ,EmployeesData.EmployeeName 
                                          ,[AttEmployeePayments].[EmployeeID]
                                          ,[PaymentAmount]
                                          ,[PaymentNote]
                                          ,[PaymentType]
                                  FROM [AttEmployeePayments]
                                  Left join [TrueTime].[dbo].EmployeesData on EmployeesData.EmployeeID=[AttEmployeePayments].[EmployeeID] "
            sql.SqlTrueTimeRunQuery(RefreshString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        GridView1.BestFitColumns()


    End Sub

    Private Sub RepositoryItemButtonOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonOpen.ButtonClick
        If GridView1.GetFocusedRowCellValue("PaymentID").ToString <> "" Then
            AttAdvancePayment.TextPaymentID.Text = GridView1.GetFocusedRowCellValue("PaymentID").ToString
            My.Forms.AttAdvancePayment.Show()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        My.Forms.AttAdvancePayment.TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
        My.Forms.AttAdvancePayment.TextFormType.Text = "New"
        My.Forms.AttAdvancePayment.Show()
    End Sub
End Class