Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls

Public Class JournalAddQuick
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _ValidateRow As Boolean
    Private CheckReportForRef As String
    Private RefOrAccNo As String
    Private AccountNo As String
    Private RefNo As String

    Sub New(_checkReportForRef As Boolean, _No As String)
        CheckReportForRef = _checkReportForRef
        RefOrAccNo = _No
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub JournalAddQuick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        LoadSettings()
        RepositoryItemLookUpEdit1.DataSource = GetNewAccounts()
        ColBaseCurrAmount.Caption = " المبلغ " & GetCurrencyCode(GetDefaultCurrency())
        RepositoryAccount.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryAccountCurr.DataSource = GetCurrency()
        RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
        If CheckReportForRef = "True" Then
            RefNo = RefOrAccNo
            AccountNo = GetRefranceData(RefNo).RefAccID
        Else
            RefNo = "0"
            AccountNo = RefOrAccNo
        End If
        GridJournal.Select()
        Me.GridView1.MoveFirst()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Saving()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridJournal.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
                GridView1.UpdateSummary()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub
    Private Sub LoadSettings()

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColBalanceInJournal'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                GridColAccBalance.Visible = True
            Else
                GridColAccBalance.Visible = False
            End If
        Catch ex As Exception
            MsgBox("Err: ShowColBalanceInJournal")
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                ColDocCostCenter.Visible = True
                Me.RepositoryCostCenter.DataSource = GetCostCenter(False)
            Else
                ColDocCostCenter.Visible = False
            End If
        Catch ex As Exception
            ColDocCostCenter.Visible = False
        End Try
    End Sub
    Private Function GetNewAccounts() As DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select RefNo,AccNo,AccName,AccType,Currency,Code As CurrCode From (
                        Select CONVERT(NVARCHAR(20), RefNo) as RefNo ,RefAccID  as [AccNo],RefName as [AccName], 'Ref' As AccType,F.Currency as  Currency
                        from Referencess R Left Join FinancialAccounts F on F.AccNo=R.RefAccID where R.Active=1
                        Union
                        SELECT CONVERT(NVARCHAR(20), [AccNo]) as RefNo, [AccNo] ,[AccName], 'Acc' As AccType,Currency
                        FROM [dbo].[FinancialAccounts] Where IsMain =0  and IsActive=1
                        ) A
                        Left Join 
                        (Select CurrID,Code from Currency ) B
                        on A.Currency=B.CurrID
                        order by RefNo"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Return Sql.SQLDS.Tables(0)
    End Function
    Private Sub RepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim _RefNo As Object = row("RefNo")
        Dim _AccNo As Object = row("AccNo")
        Dim _CurrCode As Object = row("CurrCode")
        Dim _AccType As Object = row("AccType")
        Dim _Currency As Object = row("Currency")
        GridView1.SetFocusedRowCellValue("Account", _AccNo)
        GridView1.SetFocusedRowCellValue("AccountNew", _RefNo)
        If _AccType = "Ref" Then
            GridView1.SetFocusedRowCellValue("Referance", _RefNo)
            GridView1.SetFocusedRowCellValue("AccBalance", GetReferanceBalance(_RefNo))
        Else
            GridView1.SetFocusedRowCellValue("Referance", "")
            GridView1.SetFocusedRowCellValue("AccBalance", GetAccountBalance(_AccNo))
        End If
        GridView1.SetFocusedRowCellValue("AccountCurr", _Currency)
        If Not IsDBNull(GridView1.GetFocusedRowCellValue("CreditAmount")) Then
            Dim _ExchRate = GetExchengPrice(_Currency, Format(CDate(DocDate.DateTime), "yyyy-MM-dd")).PurchasePrice
            GridView1.SetFocusedRowCellValue("ExchangePrice", _ExchRate)
        End If

        If _Currency = _DefaultCurr Then
            GridView1.SetFocusedRowCellValue("ExchangePrice", 1)
        End If
        GridView1.SetFocusedRowCellValue("DocCurrency", _Currency)
        GridView1.SetFocusedRowCellValue("DocCostCenter", GetDefaultCostCenter(GlobalVariables.CurrUser))
        GridView1.FocusedColumn = ColDebitAmount
        'If IsDBNull(GridView1.GetFocusedRowCellValue("DebitAmount")) And IsDBNull(GridView1.GetFocusedRowCellValue("CreditAmount")) Then
        '    BalanceJournal()
        'End If
    End Sub
    Private Sub gridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCurrency")) Then
            e.Cancel = True
        Else
            If view.FocusedColumn.FieldName = "ExchangePrice" AndAlso Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCurrency") = 1 Then
                e.Cancel = True
            End If
        End If
    End Sub
    Public Function EmptyJournal() As DataTable
        Dim JournalTable As New DataTable
        With JournalTable
            .Columns.Add("Account", GetType(String))
            .Columns.Add("AccountCurr", GetType(Integer))
            .Columns.Add("DebitAmount", GetType(Decimal))
            .Columns.Add("CreditAmount", GetType(Decimal))
            .Columns.Add("ExchangePrice", GetType(Decimal))
            .Columns.Add("BaseCurrAmount", GetType(Decimal))
            .Columns.Add("Referance", GetType(Integer))
            .Columns.Add("DocNotes", GetType(String))
            .Columns.Add("DocNoteByAccount", GetType(String))
            .Columns.Add("DocCostCenter", GetType(String))
            .Columns.Add("AccountNew", GetType(String))
            .Columns.Add("DocCurrency", GetType(Decimal))
            .Columns.Add("AccBalance", GetType(Decimal))
            .Columns.Add("DocDate", GetType(Date))
        End With
        '  DocCode.Text = CreateRandomCode()
        Return JournalTable

    End Function


    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        '    With GridView1

        '        Dim _DebitAmount As Decimal = 0
        '        Dim _CreditAmount As Decimal = 0
        '        Dim _ExchangePrice As Decimal = 0
        '        Try
        '            _DebitAmount = .GetRowCellValue(.FocusedRowHandle, "DebitAmount")
        '        Catch ex As Exception
        '            _DebitAmount = 0
        '        End Try
        '        Try
        '            _CreditAmount = .GetRowCellValue(.FocusedRowHandle, "CreditAmount")
        '        Catch ex As Exception
        '            _CreditAmount = 0
        '        End Try
        '        Try
        '            _ExchangePrice = .GetRowCellValue(.FocusedRowHandle, "ExchangePrice")
        '        Catch ex As Exception
        '            _ExchangePrice = 0
        '        End Try

        '        'Try
        '        '    If e.Column.FieldName = "Account" Then
        '        '        Dim _Account As String = .GetRowCellValue(.FocusedRowHandle, "Account")
        '        '        Dim _CurrencyID As Integer = GetFinancialAccountsData(_Account).Currency
        '        '        .SetRowCellValue(.FocusedRowHandle, .Columns("AccountCurr"), _CurrencyID)
        '        '        Dim _ExchRate = GetExchengPrice(_CurrencyID, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        '        '        .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), _ExchRate)
        '        '        If _CurrencyID = _DefaultCurr Then
        '        '            .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), 1)
        '        '        End If

        '        '    End If
        '        'Catch ex As Exception
        '        '    MsgBox(ex.ToString)
        '        'End Try

        '        Try
        '            If e.Column.FieldName = "DebitAmount" Then
        '                Try
        '                    If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("CreditAmount"), 0)
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                    End If
        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            End If

        '            If e.Column.FieldName = "CreditAmount" Then
        '                Try
        '                    If .GetRowCellValue(.FocusedRowHandle, "CreditAmount") <> "0" Then
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("DebitAmount"), 0)
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                    End If
        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            End If

        '            If e.Column.FieldName = "ExchangePrice" Then
        '                Try
        '                    .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            End If

        '            'DocCurrency
        '            If e.Column.FieldName = "DocCurrency" Then
        '                Try
        '                    Dim _CurrencyID = .GetFocusedRowCellValue("DocCurrency")
        '                    Dim _ExchRate = GetExchengPrice(_CurrencyID, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        '                    .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), _ExchRate)
        '                    If _CurrencyID = _DefaultCurr Then
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), 1)
        '                    End If
        '                    If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
        '                        .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                    End If
        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            End If

        '        Catch ex As Exception
        '        End Try

        '    End With



        GridView1.UpdateTotalSummary()

    End Sub
    Private edit As BaseEdit = Nothing
    Dim _FieldName As String
    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor
        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
    End Sub
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        With GridView1
            If .PostEditor() Then
                Dim _DebitAmount As Decimal = 0
                Dim _CreditAmount As Decimal = 0
                Dim _ExchangePrice As Decimal = 0
                Dim _BaseCurrAmount As Decimal = 0
                _ValidateRow = False
                GridView1.UpdateCurrentRow()
                _ValidateRow = True
                If IsDBNull(.GetFocusedRowCellValue("DebitAmount")) Then
                    .SetFocusedRowCellValue(("DebitAmount"), 0)
                End If
                If IsDBNull(.GetFocusedRowCellValue("CreditAmount")) Then
                    .SetFocusedRowCellValue(("CreditAmount"), 0)
                End If
                If IsDBNull(.GetFocusedRowCellValue("BaseCurrAmount")) Then
                    .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
                End If
                Try
                    _DebitAmount = .GetFocusedRowCellValue("DebitAmount")
                Catch ex As Exception
                    _DebitAmount = 0
                End Try
                Try
                    _CreditAmount = .GetFocusedRowCellValue("CreditAmount")
                Catch ex As Exception
                    _CreditAmount = 0
                End Try
                Try
                    _ExchangePrice = .GetFocusedRowCellValue("ExchangePrice")
                Catch ex As Exception
                    _ExchangePrice = 0
                End Try

                Select Case _FieldName
                    Case "DebitAmount"
                        Try
                            If _DebitAmount <> "0" Then
                                _CreditAmount = 0
                                .SetFocusedRowCellValue(("CreditAmount"), 0)
                                .SetFocusedRowCellValue(("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            End If
                            If .GetFocusedRowCellValue("DebitAmount") = 0 And .GetFocusedRowCellValue("CreditAmount") = 0 Then
                                .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
                            End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Case "CreditAmount"
                        Try
                            If _CreditAmount <> "0" Then
                                _DebitAmount = 0
                                .SetFocusedRowCellValue(("DebitAmount"), 0)
                                .SetFocusedRowCellValue(("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            End If
                            If .GetFocusedRowCellValue("DebitAmount") = 0 And .GetFocusedRowCellValue("CreditAmount") = 0 Then
                                .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
                            End If
                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try
                    Case "ExchangePrice"
                        Try
                            .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try
                    Case "DocCurrency"
                        Try
                            Dim _CurrencyID = .GetFocusedRowCellValue("DocCurrency")
                            Dim _ExchRate = GetExchengPrice(_CurrencyID, Format(CDate(.GetFocusedRowCellValue("DocDate")), "yyyy-MM-dd")).PurchasePrice
                            .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), _ExchRate)
                            If _CurrencyID = _DefaultCurr Then
                                .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), 1)
                            End If
                            If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
                                .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            End If
                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try
                End Select

                ' GridViewJournal.UpdateCurrentRow()
                GlobalVariables._TempItemNo = 0
            End If


        End With

    End Sub
    Private Sub Saving()

        Dim _DocCode As string 
        GridView1.UpdateCurrentRow()
        GridView1.PostEditor()
        GridView1.UpdateTotalSummary()
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()

        If Me.GridView1.GetRowCellValue(0, "AccountNew") = 0 Then
            XtraMessageBox.Show("السند فارغ")
            Exit Sub
        End If

        Dim _RefNo As Integer = 0
        Dim _RefAccount As String = "0"
        Dim _RefCurrency As Integer = GetDefaultCurrency()
        If CheckReportForRef = True Then
            Dim _RefData = GetRefranceData(CInt(RefOrAccNo))
            _RefNo = CInt(RefOrAccNo)
            _RefAccount = CStr(_RefData.RefAccID)
            _RefCurrency = CInt(_RefData.currency_id)
        End If



        'Dim view As ColumnView = TryCast(sender, ColumnView)
        GridView1.CloseEditor()
        If GridView1.UpdateCurrentRow() Then

            _DocCode = CreateRandomCode()

            If ColDebitAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة المدين صفر") : Exit Sub
            If ColCreditAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة الدائن صفر") : Exit Sub


            Try
                Dim JournalTable As New DataTable
                With JournalTable
                    .Columns.Add("DocDate", GetType(DateTime))
                    .Columns.Add("DocName", GetType(Integer))
                    .Columns.Add("DocStatus", GetType(Integer))
                    .Columns.Add("DocCostCenter", GetType(Integer))
                    .Columns.Add("DebitAcc", GetType(String))
                    .Columns.Add("CredAcc", GetType(String))
                    .Columns.Add("AccountCurr", GetType(Integer))
                    .Columns.Add("DocCurrency", GetType(Integer))
                    .Columns.Add("DocAmount", GetType(Decimal))
                    .Columns.Add("ExchangePrice", GetType(Decimal))
                    .Columns.Add("BaseCurrAmount", GetType(Decimal))
                    .Columns.Add("BaseAmount", GetType(Decimal))
                    .Columns.Add("DocSort", GetType(Integer))
                    .Columns.Add("Referance", GetType(String))
                    .Columns.Add("DocManualNo", GetType(String))
                    .Columns.Add("InputUser", GetType(Integer))
                    .Columns.Add("InputDateTime", GetType(DateTime))
                    .Columns.Add("DocNotes", GetType(String))
                    .Columns.Add("ReferanceName", GetType(String))
                    .Columns.Add("CurrentUserID", GetType(String))
                    .Columns.Add("DocCode", GetType(String))
                    .Columns.Add("DocNoteByAccount", GetType(String))
                    .Columns.Add("OrderID", GetType(Integer))
                End With
                Dim _Referance As String
                With GridView1 ' 
                    For i = 0 To .RowCount - 1
                        If Not String.IsNullOrEmpty(.GetRowCellValue(i, "BaseCurrAmount")) Then
                            _Referance = "0"
                            Try
                                _Referance = .GetRowCellValue(i, "Referance")
                            Catch ex As Exception
                                _Referance = "0"
                            End Try
                            Dim R As DataRow = JournalTable.NewRow
                            R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                            R("DocName") = 5
                            If .GetRowCellValue(i, "DebitAmount") <> "0" Then R("DebitAcc") = .GetRowCellValue(i, "Account") Else R("DebitAcc") = 0
                            If .GetRowCellValue(i, "CreditAmount") <> "0" Then R("CredAcc") = .GetRowCellValue(i, "Account") Else R("CredAcc") = 0
                            If IsDBNull(.GetRowCellValue(i, "Account")) Then XtraMessageBox.Show("الحساب فارغ") : Exit Sub
                            Dim AccData = GetFinancialAccountsData(.GetRowCellValue(i, "Account"))
                            R("AccountCurr") = AccData.Currency
                            R("DocCurrency") = .GetRowCellValue(i, "DocCurrency")
                            R("DocAmount") = .GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")
                            R("DocCostCenter") = .GetRowCellValue(i, "DocCostCenter")
                            R("ExchangePrice") = .GetRowCellValue(i, "ExchangePrice")
                            R("BaseCurrAmount") = Math.Abs(.GetRowCellValue(i, "BaseCurrAmount"))
                            R("BaseAmount") = GetBaseAmount(.GetRowCellValue(i, "AccountCurr"), (.GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")), .GetRowCellValue(i, "DocCurrency"), CDate(DocDate.DateTime), .GetRowCellValue(i, "ExchangePrice"))
                            R("DocManualNo") = "0"
                            R("InputUser") = GlobalVariables.CurrUser
                            R("InputDateTime") = Now()
                            R("DocNotes") = ""
                            R("Referance") = _Referance
                            R("ReferanceName") = .GetRowCellDisplayText(i, "Referance")
                            R("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                            R("OrderID") = i
                            JournalTable.Rows.Add(R)


                            Dim RR As DataRow = JournalTable.NewRow
                            RR("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                            RR("DocName") = 5
                            If ColBaseCurrAmount.SummaryItem.SummaryValue > 0 Then RR("DebitAcc") = "0" Else RR("DebitAcc") = AccountNo
                            If ColBaseCurrAmount.SummaryItem.SummaryValue < 0 Then RR("CredAcc") = "0" Else RR("CredAcc") = AccountNo
                            ' If IsDBNull(.GetRowCellValue(i, "Account")) Then XtraMessageBox.Show("الحساب فارغ") : Exit Sub
                            Dim AccData2 = GetFinancialAccountsData(AccountNo)
                            RR("AccountCurr") = AccData2.Currency
                            RR("DocCurrency") = .GetRowCellValue(i, "DocCurrency")
                            RR("DocAmount") = .GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")
                            RR("DocCostCenter") = .GetRowCellValue(i, "DocCostCenter")
                            RR("ExchangePrice") = .GetRowCellValue(i, "ExchangePrice")
                            RR("BaseCurrAmount") = Math.Abs(.GetRowCellValue(i, "BaseCurrAmount"))
                            RR("BaseAmount") = GetBaseAmount(RR("DocCurrency"), (.GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")), .GetRowCellValue(i, "DocCurrency"), CDate(DocDate.DateTime), .GetRowCellValue(i, "ExchangePrice"))
                            RR("DocManualNo") = "0"
                            RR("InputUser") = GlobalVariables.CurrUser
                            RR("InputDateTime") = Now()
                            RR("DocNotes") = ""
                            RR("Referance") = RefNo
                            RR("ReferanceName") = GetRefranceData(RefNo).RefName
                            RR("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                            RR("OrderID") = i
                            JournalTable.Rows.Add(RR)

                        End If
                    Next
                End With








                Dim _DocID As Integer = 0

                _DocID = GetDocNo(5, False)

                If _DocID = 0 Then
                    XtraMessageBox.Show("لا يمكن ترحيل السند: خطا برقم السند")
                    Exit Sub
                End If

                For Each row As DataRow In JournalTable.Rows
                    Dim Sql2 As New SQLControl
                    Dim SqlInsertDetials As String
                    SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],DocCostCenter,[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(CDate(row("DocDate").ToString), "yyyy-MM-dd") & "', 
                                      '" & row("DocName").ToString & "', 
                                      '" & 1 & "',
                                      '" & row("DocCostCenter").ToString & "',
                                      '" & row("DebitAcc").ToString & "',
                                      '" & row("CredAcc").ToString & "',
                                      '" & row("AccountCurr").ToString & "',
                                      '" & row("DocCurrency").ToString & "',
                                      '" & row("DocAmount").ToString & "',
                                      '" & row("ExchangePrice").ToString & "',
                                      '" & row("BaseCurrAmount").ToString & "',
                                      '" & row("BaseAmount").ToString & "',
                                      '" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & row("InputUser").ToString & "',
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & _DocCode & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                        " & row("OrderID").ToString & "
                                            )"
                    If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                        MsgBox("خطا بخظ السند")
                        DeleteFromJournalTemp(5, _DocCode)
                        Exit Sub
                    End If
                Next row


                If InsertFromTempToJournal(5, _DocID) = False Then
                    XtraMessageBox.Show("خطا بعملية الحفظ")
                    DeleteFromJournalTemp(5, _DocCode)
                    Exit Sub
                Else
                End If


                DeleteFromJournalTemp(5, _DocCode)
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            Finally
                'SplashScreenManager2.CloseWaitForm()
            End Try

        Else
            XtraMessageBox.Show("خطا، يجب اكمال تعبئة السند")
        End If



    End Sub
    Private Sub GridView1_InvalidRowException(ByVal sender As Object,
ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) _
Handles GridView1.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
        'MessageBox.Show(e.ErrorText)
    End Sub


    Private Sub View1_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        If _ValidateRow = False Then Exit Sub
        Dim View As GridView = CType(sender, GridView)
        Try
            ' Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _AccountNew As GridColumn = View.Columns("AccountNew")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccountNew")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الحساب"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = _AccountNew
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
            End If

            Dim _ExchangePrice As GridColumn = View.Columns("ExchangePrice")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ExchangePrice")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال سعر الصرف"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = _ExchangePrice
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
            End If


            Dim _DebitAmount As GridColumn = View.Columns("DebitAmount")
            Dim _CreditAmount As GridColumn = View.Columns("CreditAmount")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DebitAmount")) = True AndAlso
                IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CreditAmount")) = True Then
                e.Valid = False
                e.ErrorText = "خطأ، يجب ادخال المبلغ"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = _DebitAmount
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
            End If
            If Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DebitAmount") = 0 AndAlso
            Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CreditAmount") = 0 Then
                e.Valid = False
                View.SetColumnError(_DebitAmount, "يجب ادخال المبلغ ")
                e.ErrorText = "خطأ، يجب ادخال المبلغ"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = _DebitAmount
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
            End If
        Catch ex As Exception

        End Try

        Dim _DocCostCenter As GridColumn = View.Columns("DocCostCenter")
        If GlobalVariables._CostCenterRequired = True Then
            Dim _accno As String = GridView1.GetFocusedRowCellValue("Account")
            Dim _Account As New FinancialAccount
            If _Account.GetAccountData(_accno) = True Then
                If _Account.NeedCostCenter = True Then
                    If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCostCenter")) = True Then
                        XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        e.Valid = False
                        View.SetColumnError(_DocCostCenter, "خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار ")
                        View.FocusedRowHandle = e.RowHandle
                        View.FocusedColumn = _DocCostCenter
                        View.ShowEditor()
                        SimpleButtonSave.Enabled = False
                    End If
                End If
                Exit Sub
            End If
        End If

        If e.Valid Then
            View.ClearColumnErrors()
            SimpleButtonSave.Enabled = True
        End If

    End Sub

    Private Sub SimpleButtonSave_Click(sender As Object, e As EventArgs) Handles SimpleButtonSave.Click
        Saving()
    End Sub

    Private Sub GridJournal_Click(sender As Object, e As EventArgs) Handles GridJournal.Click

    End Sub

    Private Sub HyperlinkLabelControl1_Click(sender As Object, e As EventArgs) Handles HyperlinkLabelControl1.Click
        Dim f As New ReferancessAddNew
        With f
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .TextRefName.Select()
            ._AddNewOrSave = "AddNew"
            .CheckActive.Checked = True
            If .ShowDialog <> DialogResult.OK Then
                RepositoryItemLookUpEdit1.DataSource = GetNewAccounts()
                RepositoryAccount.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
                RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
            End If
        End With
    End Sub

    Private Sub GridView1_InitNewRow(sender As Object, e As InitNewRowEventArgs) Handles GridView1.InitNewRow
        Dim lastRowHandle = GridView1.DataRowCount - 1
        If Not IsDBNull(GridView1.GetRowCellValue(lastRowHandle, ColDocCostCenter)) Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDocCostCenter,
                                 CInt(GridView1.GetRowCellValue(lastRowHandle, ColDocCostCenter)))
        End If
    End Sub
End Class