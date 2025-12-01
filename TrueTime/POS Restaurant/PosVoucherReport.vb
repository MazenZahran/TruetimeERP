Public Class PosVoucherReport
    Private Sub PosVoucherReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueAccountingDataSet.DocNames' table. You can move, or remove it, as needed.
        Me.DocNamesTableAdapter.Fill(Me.TrueAccountingDataSet.DocNames)
        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt
        Me.SearchPOSNames.Properties.DataSource = GetAccountingPosNamesTable()
        Me.KeyPreview = True
        GetUsers()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub
    Public Sub RefreshData()
        Dim FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm")
        Dim ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm")
        GridControl1.DataSource = Nothing
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select [VoucherID]     ,[VoucherCounter] ,[VoucherDateTime]      ,[VoucherAmount]      ,[VoucherDiscount],[VoucherDiscount2]
                                ,[VoucherPC]      ,[VoucherAmountAfterDiscount]      ,[UserNo]      ,[VoucherCode]
                                ,[VoucherDebit]      ,[VoucherCredit]      ,[VoucherPayType]      ,[VoucherReferanceName]
                                ,[VoucherReferance],E.EmployeeName,A.PaidMethodName ,VoucherNote,DocName,P.PosNo,P2.POSName,[ShiftID],T.[TableName],IsNull(C.[CustomerName],0) As CashCustomerName
                          FROM  [dbo].[PosVouchers] P
                              Left join  [dbo].[EmployeesData] E on P.[UserNo] = E.EmployeeID 
                              Left join [PosPaidMethods] A on A.MethodNo =P.PayCardName
                              Left join [PosTables] T on T.TableID =P.TableID
                              Left join [CashCustomer] C on C.CustomerID =P.CashCustomerId
                              Left join AccountingPOSNames P2 on P2.ID = P.PosNo
                          Where  [VoucherDateTime] between '" & FromDate & "' and '" & ToDate & "'"
            If SearchEmployees.EditValue IsNot Nothing Then
                SqlString += " And [UserNo] ='" & SearchEmployees.EditValue & "'"
            End If
            If SearchPOSNames.EditValue IsNot Nothing Then
                SqlString += " And P.PosNo ='" & SearchPOSNames.EditValue & "'"
                ColPOSName.Visible = True
            End If
            SqlString += " order by VoucherDateTime desc  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        GridView1.BestFitColumns()
    End Sub
    Private Sub GetUsers()
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " Select distinct [DeleteUser] as EmployeeID, [EmployeeName] 
                                    from [dbo].[POSDeletedJournal] P 
                                    left join  [dbo].[EmployeesData] E on P.[DeleteUser] = E.EmployeeID "
            sql.SqlTrueAccountingRunQuery(SqlString)
            SearchEmployees.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        SearchLookUpEdit1View.BestFitColumns()
    End Sub
    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoFit.CheckedChanged
        If CheckAutoFit.Checked = True Then
            GridView1.OptionsView.ColumnAutoWidth = True
        Else
            GridView1.OptionsView.ColumnAutoWidth = False
        End If
        GridView1.BestFitColumns()
    End Sub

    Private Sub RepositoryItemHyperLinkEditVoucherNo_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEditVoucherNo.OpenLink

        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "VoucherID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocName"))
        Dim DocCode As String
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "VoucherCode")) Then
            MsgBox("لا يمكن فتج السند DocCode is Empty")
            Exit Sub
        Else
            DocCode = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "VoucherCode"))
        End If
        Select Case DocName
            Case 1, 2, 3, 4, 5, 12, 13, 6, 7, 16, 18, 17
                OpenDocumentsByDocCode(DocCode, "Journal", Me.Name)
            Case 10, 11
                OpenDocumentsByDocCode(DocCode, "OrdersJournal", Me.Name)
        End Select
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub

End Class