Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class AccountStatmentForCostCenter

    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private _CostCenterForIncomeAccountsOnly As Boolean
    Private Sub AccountStatmentForCostCenter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
        SrchCostCenterType.Properties.DataSource = GetCostCentersType(True)
        Me.DateEditTo.DateTime = Today
        Me.DateEditFrom.DateTime = New Date(Today.Year, Today.Month, 1)
        Me.KeyPreview = True
        Me.RepositoryItemLookUpEditDocStatus.DataSource = GetDocStatus(False)
    End Sub
    Private Sub RefreshData()
        If DateEditFrom.Text = "" Or DateEditTo.Text = "" Then
            MsgBoxShowError(" يجب تحديد التاريخ ")
            Exit Sub
        End If
        _CostCenterForIncomeAccountsOnly = CheckEditCostCenterForIncomeStatment.EditValue
        GetAcountStatmentForAcc(DateEditFrom.DateTime, DateEditTo.DateTime, LookCostCenter.EditValue, SrchCostCenterType.EditValue)
    End Sub
    Private Sub GetAcountStatmentForAcc(_DateFrom As String, _DateTo As String, _CostCenter As Integer, _CostCenterType As Integer)
        GridControl1.DataSource = ""
        Dim SqlString As String
        Dim JouranlTable As New DataTable

        Try
            SqlString = "select  J.[DocID],[DocDate],D.Name as DocName,DocName as DocNameValue,[DocStatus],c.CostName,[DebitAcc]
                              ,[CredAcc],[AccountCurr],[DocAmount],[ExchangePrice],[BaseCurrAmount],U.Code as DocCurrency,J.DocCode"

            SqlString += ",Case when CredAcc ='0'  then [BaseCurrAmount] else 0 end as DebitAmount"
            SqlString += ",Case when DebitAcc ='0' then [BaseCurrAmount] else 0 end as CredAmount "
            SqlString += ",Case when DebitAcc ='0' then -[BaseCurrAmount] else [BaseCurrAmount] end as ToBaseAmount "
            SqlString += ",Case when CredAcc ='0' then AA.[AccName] else A.[AccName] end as Account "
            SqlString += ", J.DocSort,[Referance],[DocManualNo],A.AccName,AA.AccName , 
                               Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes,
                               Cast( 0 as decimal(10,2)) as  Balance,IsNull(J.Referance,0) as RefNo  , IsNull(R.RefName,'') as  RefName
                           from Journal J
                           left join FinancialAccounts A on A.AccNo = J.CredAcc
                           left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                         
                           left join DocNames D on D.id = J.DocName 
                           left join DocSorts S on S.SortID = J.DocSort
                           left join CostCenter C on C.CostID = J.DocCostCenter
                           left join Currency U on U.CurrID=J.DocCurrency 
                           left join CostCenterTypes T on C.CostCenterTypeID=T.ID 
                           Left join Referencess R on R.RefNo=J.Referance "
            SqlString += "     where  DocStatus > 0  "
            If _CostCenterForIncomeAccountsOnly = True Then SqlString += " and  (A.FinancialStatment=2 or AA.FinancialStatment=2)   "
            SqlString += "           and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' 
                                 and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')"

            If _CostCenter <> 0 Then
                If LookCostCenter.EditValue <> -1 Then
                    SqlString += " and (  DocCostCenter=" & LookCostCenter.EditValue & "  ) "
                End If
            End If

            If _CostCenterType <> 0 Then
                If SrchCostCenterType.EditValue <> -1 Then
                    SqlString += " and (  T.ID=" & SrchCostCenterType.EditValue & "  ) "
                End If
            End If

            SqlString += " order by DocDate,DocID"

            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(SqlString)
            JouranlTable = sql.SQLDS.Tables(0)

            Dim BegBalce As Decimal = 0
            Dim R As DataRow = JouranlTable.NewRow
            BegBalce = GetBegBalanceForCostCenterReport(Format(CDate(_DateFrom), "yyyy-MM-dd"), _CostCenter, _CostCenterType)
            If BegBalce < 0 Then R("DebitAmount") = Math.Abs(BegBalce)
            If BegBalce > 0 Then R("CredAmount") = Math.Abs(BegBalce)
            R("DocDate") = CDate(_DateFrom).AddDays(-1)
            R("DocNotes") = "  رصيد مدور"
            JouranlTable.Rows.Add(R)
            JouranlTable.DefaultView.Sort = "DocDate ASC"
            JouranlTable = JouranlTable.DefaultView.ToTable()

            For i As Integer = 0 To JouranlTable.Rows.Count - 1
                Dim row As DataRow = JouranlTable.Rows(i)
                Dim credit As Decimal = 0, debit As Decimal = 0, previousBalance As Decimal = 0
                Decimal.TryParse(row("CredAmount").ToString(), credit)
                Decimal.TryParse(row("DebitAmount").ToString(), debit)
                If i > 0 Then Decimal.TryParse(JouranlTable.Rows(i - 1)("Balance").ToString(), previousBalance)
                row("Balance") = If(i = 0, -debit + credit, previousBalance + credit - debit)
            Next
        Catch ex As Exception
            MsgBoxShowError(" حاول مرة أخرى ")
        End Try


        GridControl1.DataSource = JouranlTable
        GridView1.BestFitColumns()

    End Sub
    Private Function GetBegBalanceForCostCenterReport(_DateFrom As String, _CostCenter As Integer, _CostCenterType As Integer) As Decimal
        Dim _BegBalance As Decimal
        Dim SqlString As String
        Try
            SqlString = "     select sum(ToBaseAmount) as BeginBalance from
                              (select Case when CredAcc ='0' then -1*[BaseCurrAmount] else [BaseCurrAmount] end as ToBaseAmount 
                              from Journal J 
                              left join FinancialAccounts A on A.AccNo = J.CredAcc
                              left join FinancialAccounts AA on AA.AccNo = J.DebitAcc
                              left join CostCenter C on C.CostID = J.DocCostCenter
                              left join CostCenterTypes T on C.CostCenterTypeID=T.ID
                              where  DocStatus > 0  and [DocDate] < '" & _DateFrom & "'"
            If _CostCenter <> 0 Then SqlString += " And DocCostCenter=" & _CostCenter & ""
            If _CostCenterType <> 0 Then SqlString += " and (  T.ID=" & _CostCenterType & " ) "
            If _CostCenterForIncomeAccountsOnly = True Then SqlString += "  and (A.FinancialStatment=2 or AA.FinancialStatment=2) "
            SqlString += "   ) A "
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 15001 Then
                Dim _Credit As Decimal = ColCredAmount.SummaryItem.SummaryValue
                Dim _Debit As Decimal = ColDebitAmount.SummaryItem.SummaryValue
                e.TotalValue = (_Credit - _Debit).ToString("#,###.00")
                ' e.TotalValue = e.TotalValue.ToString("#,###.00")
            End If
        End If
    End Sub

    Private Sub RepositoryItemHyperLinkEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit2.Click
        OpenDoc()
    End Sub
    Private Sub OpenDoc()
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID")) Or
            IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")) Or
            GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID") Is Nothing Then
            Exit Sub
        End If
        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocNameValue"))
        Dim DocCode As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
        Select Case DocName
            Case 1, 2, 3, 4, 5, 12, 13, 6, 7
                OpenDocumentsByDocCode(DocCode, "Journal", Me.Name)
        End Select
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
                                                                                   {"  ", Now(), "Pages: [Page # of Pages #]"})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
                (" " & "كشف حساب لمركز تكلفة  : " & LookCostCenter.Text & " ")

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub

    Private Sub GridControl1_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.F2 AndAlso view.SelectedRowsCount > 0 Then
            AuditDocs()
        End If
    End Sub
    Private Sub AuditDocs()
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار السندات من القائمة")
            Exit Sub
        End If


        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 0 Then
            If XtraMessageBox.Show(" هل تريد تدقيق السندات؟  " & "(" & " عدد " & selectedRowHandles.Length & " )", " تاكيد ", MessageBoxButtons.YesNo) <> DialogResult.No Then
                For i As Integer = 0 To selectedRowHandles.Length - 1
                    Dim _DocCode As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocCode")
                    Dim _DocID As String = GridView1.GetRowCellValue(selectedRowHandles(i), "DocID")
                    Dim _DocName As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocNameValue")
                    Dim _DocStatus As Integer = GridView1.GetRowCellValue(selectedRowHandles(i), "DocStatus")
                    If _DocStatus <> 3 Then
                        AuditDocument(_DocCode, _DocID, _DocName, "Journal")
                    End If
                    GridView1.SetRowCellValue(selectedRowHandles(i), "DocStatus", 2)
                Next
            End If

        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "DocStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocStatus"))
            If category = "محفوظ" Then
                e.DisplayText = String.Format(DocumentsStatus.Saved)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مرحل" Then
                e.DisplayText = String.Format(DocumentsStatus.Posted)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "الي" Then
                e.DisplayText = String.Format(DocumentsStatus.Auto)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مدقق" Then
                e.DisplayText = String.Format(DocumentsStatus.Audited)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "ملغي" Then
                e.DisplayText = String.Format(DocumentsStatus.Cancelled)
                e.Appearance.Options.CancelUpdate()
            End If
        ElseIf e.Column.FieldName = "PaidStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PaidStatus"))
            If category = "غير مسدد" Then
                e.DisplayText = String.Format(PaidStatus.Unpaid)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مسدد جزئي" Then
                e.DisplayText = String.Format(PaidStatus.PaidPartial)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مسدد" Then
                e.DisplayText = String.Format(PaidStatus.Paid)
                e.Appearance.Options.CancelUpdate()
            End If
        ElseIf e.Column.FieldName = "OrderStatus" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("OrderStatus"))
            If category = "محفوظ" Then
                e.DisplayText = String.Format(OrderStatus.Saved)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "قيد التجهيز" Then
                e.DisplayText = String.Format(OrderStatus.VoucherdPartial)
                e.Appearance.Options.CancelUpdate()
            ElseIf category = "مفوترة" Then
                e.DisplayText = String.Format(OrderStatus.Voucherd)
                e.Appearance.Options.CancelUpdate()
            End If

            'OrderStatus
        End If
    End Sub
End Class