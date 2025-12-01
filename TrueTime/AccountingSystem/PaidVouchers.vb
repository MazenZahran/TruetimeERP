Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraTreeList.Data

Public Class PaidVouchers
    Private Sub PaidVouchers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookReferences.Properties.DataSource = GetReferences(-1, -1, -1)
        RepositoryItemPaidStatus.DataSource = GetDocPaidStatus(False)
    End Sub
    Private Sub GetDocuments()
        GridControl1.DataSource = ""
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " Declare @RefNo int; Set @RefNo=" & LookReferences.EditValue & "
 SELECT   J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,DocCode,
          C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,
          SUM(BaseAmount) AS BaseAmount,case when DocName in (6,13) then -1*Sum(BaseCurrAmount) else Sum(BaseCurrAmount) end as BaseCurrAmount,Case when SUM(DocAmount) > 0 then SUM(BaseAmount)/SUM(DocAmount) end As ExchangePrice,
          DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DocManualNo,R.ReferanceCode,E.EmployeeName As SalesPerson,DocStatus,DocID2,PaidStatus,PaidAmount,0.0 as CurrPaidAmount,
          DebitAcc As Account  from journal J
left join DocNames N on N.id =J.DocName
left join Currency C on C.CurrID = J.DocCurrency 
left Join DocSorts S on S.SortID =J.DocSort
left join Referencess R on R.[RefNo] = J.Referance
Left Join EmployeesData E on E.EmployeeID = J.SalesPerson 
where DocName in (2,6,13) and J.DocStatus > 0  and	 DebitAcc<>'0'   and J.Referance =@RefNo and PaidStatus <> 2
group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DocCode,DocManualNo,DocStatus,R.ReferanceCode,E.EmployeeName,DocID2,PaidStatus,PaidAmount ,DebitAcc 
Union 
 SELECT   J.DocID,DocDate,N.[Name] as DocNameText, J.DocName ,DocCode,
          C.Code as DocCurrency ,SUM(DocAmount) AS DocAmount,
          SUM(BaseAmount) AS BaseAmount,case when DocName in(7,12) then -1*Sum(BaseCurrAmount) else Sum(BaseCurrAmount) end as BaseCurrAmount,Case when SUM(DocAmount) > 0 then SUM(BaseAmount)/SUM(DocAmount) end As ExchangePrice,
          DocNotes,S.SortName as DocSort,Referance,J.ReferanceName as ReferanceName,DocManualNo,R.ReferanceCode,E.EmployeeName As SalesPerson,DocStatus,DocID2,PaidStatus,PaidAmount,0.0 as CurrPaidAmount,
          CredAcc As Account  from journal J
left join DocNames N on N.id =J.DocName
left join Currency C on C.CurrID = J.DocCurrency 
left Join DocSorts S on S.SortID =J.DocSort
left join Referencess R on R.[RefNo] = J.Referance
Left Join EmployeesData E on E.EmployeeID = J.SalesPerson 
where DocName in (1,7,12) and J.DocStatus > 0  and	 CredAcc<>'0'   and J.Referance =@RefNo and PaidStatus <> 2
group by DocDate,N.[Name],C.Code,J.DocID,DocNotes,S.SortName,DocName,Referance,ReferanceName,DocCode,DocManualNo,DocStatus,R.ReferanceCode,E.EmployeeName,DocID2,PaidStatus,PaidAmount ,CredAcc 
order by DocID  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try


    End Sub

    Private Sub LookReferences_EditValueChanged(sender As Object, e As EventArgs) Handles LookReferences.EditValueChanged
        GetDocuments()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If
        'If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
        '    XtraMessageBox.Show("الرجاء اختيار السندات من القائمة")
        '    Exit Sub
        'End If
        If txtCurrPaidAmount.EditValue = 0 Then
            MsgBoxShowError(" لم يتم تسديد اي فاتورة ")
            Exit Sub
        End If
        If CInt(txtRemain.EditValue) <> 0 Then
            If XtraMessageBox.Show(" السند غير مطابق هل تريد الاستمرار ", " تاكيد ", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            Dim _DocID As String = GridView1.GetRowCellValue(i, "DocID")
            Dim _DocName As String = GridView1.GetRowCellValue(i, "DocName")
            Dim _PaidStatus As String = GridView1.GetRowCellValue(i, "PaidStatusTemp")
            Dim _PaidAmount As Decimal = GridView1.GetRowCellValue(i, "PaidAmount")
            Dim _CurrPaidAmount As Decimal = GridView1.GetRowCellValue(i, "CurrPaidAmount")
            Dim _AllPaid As Decimal = _PaidAmount + _CurrPaidAmount
            If _CurrPaidAmount <> 0 Then
                PaidVoucher(_DocID, _DocName, _PaidStatus, _AllPaid, txtPaidByDocNo.EditValue)
            End If
        Next
        Me.Close()

        'Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        'If selectedRowHandles.Length > 0 Then
        '    If XtraMessageBox.Show(" هل تريد تسديد الفواتير؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '        For i As Integer = 0 To selectedRowHandles.Length - 1
        '            Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
        '            Dim _DocName As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocName")
        '            Dim _PaidStatus As String = GridView1.GetRowCellValue(selectedRowHandles(i), "PaidStatusTemp")
        '            Dim _PaidAmount As Decimal = GridView1.GetRowCellValue(selectedRowHandles(i), "PaidAmount")
        '            If _PaidAmount <> 0 Then
        '                PaidVoucher(_DocID, _DocName, _PaidStatus, _PaidAmount)
        '            End If
        '            'GridView1.SetRowCellValue(selectedRowHandles(i), "DocStatus", 2)
        '        Next
        '        GetDocuments()
        '    End If
        'End If
    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "PaidStatusTemp" AndAlso e.IsGetData Then
            e.Value = getTotalValue(view, e.ListSourceRowIndex)
        End If
    End Sub
    Private Function getTotalValue(view As GridView, listSourceRowIndex As Integer) As Integer
        Dim _result As Integer = 0
        Dim _DocAmount As Decimal = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "BaseCurrAmount"))
        Dim _RemainAmount As Decimal = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "RemainAmount"))
        Dim _CurrPaidAmount As Decimal = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "CurrPaidAmount"))
        If _RemainAmount = 0 Then _result = 2
        If _RemainAmount = _DocAmount Then _result = 0
        If _RemainAmount <> 0 Then _result = 1
        Select Case CInt(_RemainAmount)
            Case 0
                _result = 2
            Case <> 0
                _result = 1
        End Select
        If _RemainAmount = _DocAmount Then
            _result = 0
        End If
        Return _result
    End Function

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim view As GridView = TryCast(sender, GridView)
        view.UpdateTotalSummary()
        txtCurrPaidAmount.Text = ColCurrPaidAmount.SummaryText
        txtRemain.Text = txtDocAmount.EditValue - txtCurrPaidAmount.EditValue
    End Sub
End Class