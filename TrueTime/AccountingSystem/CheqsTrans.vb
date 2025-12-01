Imports DevExpress.Utils.DirectXPaint
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class CheqsTrans
    Dim _DefaultCurreny As Integer = GetDefaultCurrency()

    Private Sub CheqsTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookCheqsTrans.Properties.DataSource = GetCheqsTrans(ComboBoxInOut.Text)
        GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
        Banks.Properties.DataSource = GetBankAccounts(-1)
        AccountForBank.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        xSearchChecksRelatedAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)

        xSearchChecksRelatedAccount.EditValue = GetDefaultAccounts(2, 1, GlobalVariables.CurrUser)
        DocDate.DateTime = Today
        RepositoryCheckCurr.DataSource = GetCurrency()
        RepositoryCheckCurr2.DataSource = GetCurrency()
        Dim _ReferancesTable As New DataTable
        _ReferancesTable = GetReferences(-1, -1, -1)
        SearchReferance.Properties.DataSource = _ReferancesTable
        RepositoryRelatedReferance.DataSource = _ReferancesTable
        RepositoryRelatedReferance2.DataSource = _ReferancesTable
        GetChecks()
        If GlobalVariables._SystemLanguage = "Arabic" Then
            DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Else
            DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        End If

        Dim _CurrCode As String = GetCurrencyCode(_DefaultCurreny)
        ColCheckBaseAmount.Caption = " <size=-3> " & _CurrCode & " </size> المبلغ "
        ColCheckBaseAmount2.Caption = " <size=-3> " & _CurrCode & " </size> المبلغ "
        ColDocNoteByAccount.Visible = GlobalVariables._ShowColNoteInMoneyTransDoc
        ColDocNoteByAccount2.Visible = GlobalVariables._ShowColNoteInMoneyTransDoc
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetChecks()
    End Sub
    Private Sub GetTransNames()

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RepositoryCheck_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryCheck.ButtonClick
        CheckOrUnCheck(True)
    End Sub

    Private Sub RepositoryUnCheck_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryUnCheck.ButtonClick
        CheckOrUnCheck(False)
    End Sub

    Private Sub CheckOrUnCheck(Check As Boolean)

        If LookCheqsTrans.EditValue = 1 Then
            If IsNothing(AccountForBank.EditValue) Then
                XtraMessageBox.Show("يجب اختيار الحساب البنكي قبل عملية الايداع")
                Exit Sub
            End If
        End If

        If LookCheqsTrans.EditValue = 1 Then
            Dim _Status As String = Me.GridView1.GetFocusedRowCellValue("StatusName")
            Dim _BankAccNo As String = Me.GridView1.GetFocusedRowCellValue("AccountBank")
            Dim _BankAccNoInTrans As String = Banks.EditValue
            'If _BankAccNo <> _BankAccNoInTrans Then
            '    MsgBoxShowError("لا يمكن ايداع شيك من حساب بنكي الى حساب بنكي اخر")
            '    Exit Sub
            'End If
        End If
        'If Me.GridView1.GetFocusedRowCellValue("StatusName") Then
        '    End If

        Dim type As Integer = 0
        Dim rows As ArrayList = New ArrayList()
        Dim table As DataTable = New DataTable()
        Dim view As GridView = New GridView()


        If Check = True Then
            table = TryCast(GridControl2.DataSource, DataTable)
            view = TryCast(GridView1, GridView)
            type = 1
        ElseIf Check = False Then
            table = TryCast(GridControl1.DataSource, DataTable)
            view = TryCast(GridView2, GridView)
            type = 2
        End If

        For i As Integer = 0 To view.SelectedRowsCount - 1
            If view.GetSelectedRows()(i) >= 0 Then rows.Add(view.GetDataRow(view.GetSelectedRows()(i)))
        Next

        Try

            For i As Integer = 0 To rows.Count - 1
                Dim row As DataRow = TryCast(rows(i), DataRow)
                table.ImportRow(row)
            Next

        Catch
        End Try

        For i As Integer = 0 To view.SelectedRowsCount
            Try
                view.DeleteRow(view.GetSelectedRows()(i))

                If i > 1 Then
                    i -= 1
                Else
                    i = 0
                End If

            Catch
                '  view.DeleteRow(view.GetSelectedRows()(0))
                'view.DeleteSelectedRows()
            End Try
        Next

        If type = 1 Then
            GridControl2.DataSource = Nothing
            GridControl2.DataSource = table
            GridControl2.RefreshDataSource()
            GridControl1.RefreshDataSource()
            GridView1.RefreshData()
            GridControl2.RefreshDataSource()
            GridView2.RefreshData()
        Else
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = table
            GridControl1.RefreshDataSource()
            GridControl1.RefreshDataSource()
            GridView1.RefreshData()
            GridControl2.RefreshDataSource()
            GridView2.RefreshData()
        End If
        GridView1.BestFitColumns()
        GridView2.BestFitColumns()
    End Sub


    Private Sub Saving()

        If GridView2.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد شيكات")
            Exit Sub
        End If

        If DocDate.DateTime > Today Then
            If XtraMessageBox.Show("تاريخ السند اكبر من تاريخ اليوم، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Dim _CheckIfDocInJournal As Boolean = False

        Dim _AskBeforeSave As String = "0"
        _AskBeforeSave = "هل تريد حفظ السند"

        Select Case LookCheqsTrans.EditValue
            Case 4 ' تجيير الشيكات
                If String.IsNullOrEmpty(TextRefAccID.Text) Then
                    XtraMessageBox.Show("يجب اختيار ذمة")
                    Exit Sub
                End If
        End Select

        If String.IsNullOrEmpty(DocDate.Text) Then
            XtraMessageBox.Show("يجب اختيار تاريخ")
            Exit Sub
        End If

        If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            ProgressBarControl1.EditValue = 0




            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()

            'If String.IsNullOrEmpty(AccountForBank.Text) Or AccountForBank.Text = "0" Then
            '    XtraMessageBox.Show("يجب اختيار حساب المرجع")
            '    Exit Sub
            'End If

            'If String.IsNullOrEmpty(TotalDocAmount.Text) Or TotalDocAmount.Text = "0" Then
            '    XtraMessageBox.Show("السند فارغ")
            '    Exit Sub
            'End If

            'If TextMultiCurrency.Text = "True" Then
            '    If String.IsNullOrEmpty(DocCurrency.Text) Or DocCurrency.Text = "0" Then
            '        XtraMessageBox.Show("يجب اخنيار عملة")
            '        Exit Sub
            '    End If

            '    If String.IsNullOrEmpty(ExchangePrice.Text) Or ExchangePrice.Text = "0" Then
            '        XtraMessageBox.Show("سعر الصرف خطا")
            '        Exit Sub
            '    End If
            'End If

            Dim _InputDateTime As DateTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")

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
                .Columns.Add("Referance", GetType(Integer))
                .Columns.Add("DocManualNo", GetType(String))
                .Columns.Add("InputUser", GetType(Integer))
                .Columns.Add("InputDateTime", GetType(DateTime))
                .Columns.Add("DocNotes", GetType(String))
                .Columns.Add("CheckNo", GetType(Integer))
                .Columns.Add("CheckCustBank", GetType(String))
                .Columns.Add("CheckCustBranch", GetType(String))
                .Columns.Add("CheckCustAccountId", GetType(String))
                .Columns.Add("CheckInOut", GetType(String))
                .Columns.Add("CheckStatus", GetType(Integer))
                .Columns.Add("AccountBank", GetType(String))
                .Columns.Add("CheckDueDate", GetType(String))
                .Columns.Add("CheckCode", GetType(String))
                .Columns.Add("ReferanceName", GetType(String))
                .Columns.Add("CurrentUserID", GetType(String))
                .Columns.Add("RelatedAccount", GetType(String))
                .Columns.Add("DocNoteByAccount", GetType(String))
                .Columns.Add("RelatedReferance", GetType(Integer))
            End With

            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()

            Dim _Referance As Integer = 0
            Try
                If SearchReferance.Text = "" Then
                    _Referance = 0
                Else
                    _Referance = SearchReferance.Text
                End If
            Catch ex As Exception
                _Referance = 0
            End Try

            Dim BankAccounts = GetBankAccountsData(Banks.EditValue)
            Dim BankDepositAccount As String = BankAccounts._BankDepositAccount
            Dim BankTahseelAccount As String = BankAccounts._BankCheqsTahselAccount

            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()

            Select Case LookCheqsTrans.EditValue

                Case 1 ' ايداع الشيكات
                    If IsNothing(AccountForBank.EditValue) Or String.IsNullOrEmpty(AccountForBank.Text) Or AccountForBank.Text = "0" Then
                        XtraMessageBox.Show("يجب اختيار البنك")
                        ProgressBarControl1.EditValue = 0
                        ProgressBarControl1.Update()
                        Exit Sub
                    End If
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                If ChecKTahsel.Checked = False Then R("DebitAcc") = BankDepositAccount Else R("DebitAcc") = BankTahseelAccount
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(BankDepositAccount).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                If ChecKTahsel.Checked = False Then R("CheckStatus") = "4" Else R("CheckStatus") = "7"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("AccountBank") = CStr(Banks.EditValue)
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account

                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                _R("CredAcc") = .GetRowCellValue(i, "RelatedAccount")
                                _R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                If ChecKTahsel.Checked = False Then _R("CheckStatus") = "4" Else _R("CheckStatus") = "7"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = "0"
                                _R("ReferanceName") = "0"
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With
                Case 2 ' ارجاع الشيكات من البنك
                    With GridView2 ' الشيكات
                        If IsNothing(xSearchChecksRelatedAccount.EditValue) Then
                            XtraMessageBox.Show("يجب اختيار صندوق الشيكات")
                            ProgressBarControl1.EditValue = 0
                            ProgressBarControl1.Update()
                            Exit Sub
                        End If
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = xSearchChecksRelatedAccount.EditValue
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(xSearchChecksRelatedAccount.EditValue).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "5"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                _R("CredAcc") = .GetRowCellValue(i, "RelatedAccount")
                                _R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "5"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = "0"
                                _R("ReferanceName") = "0"
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With
                Case 3 ' ارجاع للزبون
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = .GetRowCellValue(i, "RefAccID")
                                _R("CredAcc") = "0"
                                _R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RefAccID")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "8"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = .GetRowCellValue(i, "Referance")
                                _R("ReferanceName") = .GetRowCellValue(i, "RefName")
                                JournalTable.Rows.Add(_R)

                                ' Add Credit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = "0"
                                R("CredAcc") = xSearchChecksRelatedAccount.EditValue
                                R("AccountCurr") = GetFinancialAccountsData(xSearchChecksRelatedAccount.EditValue).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "8"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With

                Case 4 ' تجيير الشيكات
                    Dim _ShowRefName As Boolean = False
                    Try
                        Dim sql As New SQLControl
                        sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='ShowRefNameWhenForwardCheques'  ")
                        _ShowRefName = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
                    Catch ex As Exception

                    End Try


                    With GridView2 ' الشيكات
                        If IsNothing(SearchReferance.EditValue) Then
                            MsgBox("يجب اختيار مورد ")
                            Exit Sub
                        End If
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = TextRefAccID.Text
                                _R("CredAcc") = "0"
                                _R("AccountCurr") = GetFinancialAccountsData(_R("DebitAcc")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                If _ShowRefName = True Then
                                    _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                Else
                                    _R("DocNotes") = TextDocNotes.Text
                                End If
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "9"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = SearchReferance.EditValue
                                _R("ReferanceName") = SearchReferance.Text
                                JournalTable.Rows.Add(_R)

                                ' Add Credit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = "0"
                                R("CredAcc") = .GetRowCellValue(i, "RelatedAccount")
                                R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                If _ShowRefName = True Then
                                    R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                Else
                                    R("DocNotes") = TextDocNotes.Text
                                End If
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "9"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With


                Case 5 ' سحب شيك نقدا
                    If IsNothing(srchCashAccount.EditValue) Or String.IsNullOrEmpty(xSearchChecksRelatedAccount.Text) Or xSearchChecksRelatedAccount.Text = "0" Then
                        XtraMessageBox.Show("يجب اختيار حساب الصندوق")
                        ProgressBarControl1.EditValue = 0
                        ProgressBarControl1.Update()
                        Exit Sub
                    End If
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = srchCashAccount.EditValue
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(srchCashAccount.EditValue).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "11"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("AccountBank") = CStr(Banks.EditValue)
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account

                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                _R("CredAcc") = .GetRowCellValue(i, "RelatedAccount")
                                _R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                If ChecKTahsel.Checked = False Then _R("CheckStatus") = "4" Else _R("CheckStatus") = "7"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = "0"
                                _R("ReferanceName") = "0"
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With

                Case 6 ' اخراج شيك صادر من البنك
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = .GetRowCellValue(i, "RelatedAccount")
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"), R("DocCurrency"), DocDate.DateTime, GetExchengPrice(R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckInOut") = "Out"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "2"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                _R("CredAcc") = BankDepositAccount
                                _R("AccountCurr") = GetFinancialAccountsData(BankDepositAccount).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text
                                _R("CheckInOut") = "Out"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "2"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = "0"
                                _R("ReferanceName") = "0"
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next
                    End With


                Case 8 ' استرجاع شيك من المورد
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = GetBankAccountsData(.GetRowCellValue(i, "AccountBank"))._BankOutChequeAccount
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(R("DebitAcc")).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"), R("DocCurrency"), DocDate.DateTime, GetExchengPrice(R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckInOut") = "Out"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "2"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                _R("CredAcc") = GetRefranceData(.GetRowCellValue(i, "Referance")).RefAccID
                                _R("AccountCurr") = GetFinancialAccountsData(_R("CredAcc")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text
                                _R("CheckInOut") = "Out"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "2"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = .GetRowCellValue(i, "Referance")
                                _R("ReferanceName") = .GetRowCellValue(i, "RefName")
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next
                    End With

                Case 7 ' ارجاع شيك صادر من البنك الى المورد
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = BankDepositAccount
                                R("CredAcc") = "0"
                                R("AccountCurr") = GetFinancialAccountsData(.GetRowCellValue(i, "RelatedAccount")).Currency
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckInOut") = "Out"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "10"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = "0"
                                R("ReferanceName") = "0"
                                JournalTable.Rows.Add(R)
                                ' Add Credit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                _R("DebitAcc") = "0"
                                Dim _AccountData = GetFinancialAccountsData(.GetRowCellValue(i, "RefAccID"))
                                _R("CredAcc") = .GetRowCellValue(i, "RefAccID")
                                _R("AccountCurr") = _AccountData.Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text
                                _R("CheckInOut") = "Out"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "10"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                _R("Referance") = .GetRowCellValue(i, "Referance")
                                _R("ReferanceName") = .GetRowCellValue(i, "RefName")
                                JournalTable.Rows.Add(_R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next
                    End With

                Case 9 ' اعادة شيك مجير 
                    With GridView2 ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                ' Add Debit Account
                                Dim _R As DataRow = JournalTable.NewRow
                                _R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                _R("DocName") = "5"
                                If CheckReturnDirectToCustomer.Checked = True Then
                                    _R("DebitAcc") = GetRefranceData(.GetRowCellValue(i, "Referance")).RefAccID
                                    _R("AccountCurr") = GetRefranceData(.GetRowCellValue(i, "Referance")).currency_id
                                Else
                                    _R("DebitAcc") = xSearchChecksRelatedAccount.EditValue
                                    _R("AccountCurr") = GetFinancialAccountsData(xSearchChecksRelatedAccount.EditValue).Currency
                                End If
                                _R("CredAcc") = "0"
                                _R("AccountCurr") = GetFinancialAccountsData(_R("DebitAcc")).Currency
                                _R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                _R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                _R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                _R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                _R("BaseAmount") = GetBaseAmount(_R("AccountCurr"), _R("DocAmount"), _R("DocCurrency"), DocDate.DateTime, GetExchengPrice(_R("DocCurrency"), Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice)
                                _R("DocManualNo") = TextDocManualNo.Text
                                _R("InputUser") = GlobalVariables.CurrUser
                                _R("InputDateTime") = _InputDateTime
                                _R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                _R("CheckInOut") = "IN"
                                _R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                _R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                _R("CheckStatus") = "5"
                                _R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                _R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                _R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                _R("AccountBank") = CStr(Banks.EditValue)
                                _R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                If CheckReturnDirectToCustomer.Checked = True Then
                                    _R("Referance") = .GetRowCellValue(i, "Referance")
                                    _R("ReferanceName") = .GetRowCellValue(i, "RefName")
                                Else
                                    _R("Referance") = "0"
                                    _R("ReferanceName") = "0"
                                End If

                                JournalTable.Rows.Add(_R)

                                ' Add Credit Account
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = "5"
                                R("DebitAcc") = "0"
                                R("CredAcc") = GetRefranceData(.GetRowCellValue(i, "RelatedReferance")).RefAccID
                                R("AccountCurr") = GetRefranceData(.GetRowCellValue(i, "RelatedReferance")).currency_id
                                R("DocCurrency") = .GetRowCellValue(i, "CheckCurr")
                                R("DocAmount") = .GetRowCellValue(i, "CheckAmount")
                                R("ExchangePrice") = .GetRowCellValue(i, "CheckBaseAmount") / .GetRowCellValue(i, "CheckAmount")
                                R("BaseCurrAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("BaseAmount") = .GetRowCellValue(i, "CheckBaseAmount")
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("InputDateTime") = _InputDateTime
                                R("DocNotes") = TextDocNotes.Text & " / " & .GetRowCellValue(i, "RefName")
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "5"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckAccountId")
                                R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                R("Referance") = .GetRowCellValue(i, "RelatedReferance")
                                R("ReferanceName") = GetRefranceData(.GetRowCellValue(i, "RelatedReferance")).RefName
                                JournalTable.Rows.Add(R)
                            End If
                            SaveJournalByCheq(JournalTable)
                            JournalTable.Rows.Clear()
                        Next

                    End With
            End Select



            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()




            '''''''''''''''''''

            'ProgressBarControl1.PerformStep()
            'ProgressBarControl1.Update()





            '  CoptToClip(JournalTable)
            'Referance.EditValue = 0
            'TextDocNotes.Text = ""
            'TextDocManualNo.Text = ""
            'TextReferanceName.Text = ""
            'AccountForBank.EditValue = 0
            'DocCashAmount.EditValue = 0
            'LoadDefault()
        End If

        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()



        GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)

        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()

        XtraMessageBox.Show("تم حفظ البيانات", "", MessageBoxButtons.OK)

        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()

        ProgressBarControl1.EditValue = 0
        ProgressBarControl1.Update()

        'If TextOpenFrom.Text = MoneyTransList.Name Then
        '    Me.Close()
        'End If

    End Sub
    Private Sub SaveJournalByCheq(JournalTable As DataTable)
        DocCode.Text = CreateRandomCode()
        Dim _DocID As Integer = 0
        _DocID = GetDocNo(5, False)

        If _DocID = 0 Then
            XtraMessageBox.Show("لا يمكن ترحيل السند: خطا برقم السند")
            ProgressBarControl1.EditValue = 0
            ProgressBarControl1.Update()
            Exit Sub
        End If

        ProgressBarControl1.PerformStep()
        ProgressBarControl1.Update()
        For Each row As DataRow In JournalTable.Rows
            Dim Sql2 As New SQLControl
            Dim SqlInsertDetials As String
            SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,CheckNo,CheckInOut,CheckStatus,
                                       [CheckDueDate],CurrentUserID,Referance,ReferanceName,CheckCustBank,CheckCustBranch,
                                       [CheckCustAccountId],AccountBank,CheckCode,DocCode,DocNoteByAccount) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(CDate(row("DocDate").ToString), "yyyy-MM-dd") & "', 
                                      '" & row("DocName").ToString & "', 
                                      '" & 4 & "',
                                      '" & row("DebitAcc").ToString & "',
                                      '" & row("CredAcc").ToString & "',
                                      '" & row("AccountCurr").ToString & "',
                                      '" & row("DocCurrency").ToString & "',
                                      '" & row("DocAmount").ToString & "',
                                      '" & row("ExchangePrice").ToString & "',
                                      '" & row("BaseCurrAmount").ToString & "',
                                      '" & row("BaseAmount").ToString & "',
                                      '" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString + " : " + row("CheckNo").ToString & "' ,
                                      '" & row("InputUser").ToString & "',
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm:ss") & "',
                                      '" & row("CheckNo").ToString & "',
                                      '" & row("CheckInOut").ToString & "',
                                      '" & row("CheckStatus").ToString & "',
                                      '" & row("CheckDueDate").ToString & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                      '" & row("CheckCustBank").ToString & "',
                                      '" & row("CheckCustBranch").ToString & "',
                                      '" & row("CheckCustAccountId").ToString & "',
                                      '" & row("AccountBank").ToString & "',
                                      '" & row("CheckCode").ToString & "',
                                      '" & DocCode.Text & "',
                                       N'" & "" & "'
                                            )"
            If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                MsgBox("خطا بخظ السند")
                ProgressBarControl1.EditValue = 0
                ProgressBarControl1.Update()
                Exit Sub
            End If


            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()

            Select Case LookCheqsTrans.EditValue
                Case 1
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            Dim SheckStatus As Integer
                            If ChecKTahsel.Checked = True Then SheckStatus = 6 Else SheckStatus = 4
                            SqlString = " Update Checks Set  CheckStatus= " & SheckStatus & ", AccountBank='" & row("AccountBank").ToString & "',RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 2
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 5, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 3
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 8, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 4
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 9, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "',
                                                 TransNoInJournal+=1,RelatedReferance=" & row("Referance").ToString & " where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 5
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 11, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "',
                                                 TransNoInJournal+=1 " & " where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 6
                    Try
                        If row("CredAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 2,RelatedAccount= '" & row("CredAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 7
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 10,RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 8
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            Dim Sql As New SQLControl
                            Dim SqlString As String
                            SqlString = " Update Checks Set  CheckStatus= 14,RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                            Sql.SqlTrueAccountingRunQuery(SqlString)
                        End If

                    Catch ex As Exception

                    End Try
                Case 9
                    Try
                        If row("DebitAcc").ToString <> "0" Then
                            If CheckReturnDirectToCustomer.Checked = True Then
                                Dim Sql As New SQLControl
                                Dim SqlString As String
                                SqlString = " Update Checks Set  CheckStatus= 8, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                                Sql.SqlTrueAccountingRunQuery(SqlString)
                            Else
                                Dim Sql As New SQLControl
                                Dim SqlString As String
                                SqlString = " Update Checks Set  CheckStatus= 5, AccountBank='0',RelatedAccount= '" & row("DebitAcc").ToString & "', TransNoInJournal+=1 where CheckCode='" & row("CheckCode").ToString & "'"
                                Sql.SqlTrueAccountingRunQuery(SqlString)
                            End If

                        End If

                    Catch ex As Exception

                    End Try
            End Select



        Next row
        If InsertFromTempToJournal(5, _DocID) = False Then
            XtraMessageBox.Show("خطا بعملية الحفظ")
            DeleteFromJournalTemp(5, Me.DocCode.Text)
            Exit Sub
        Else
            DeleteFromJournalTemp(5, Me.DocCode.Text)
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        '  Dim AccountData = GetFinancialAccountsData(11310000).Currency

        Saving()
    End Sub

    Private Sub LookCheqsTrans_EditValueChanged(sender As Object, e As EventArgs) Handles LookCheqsTrans.EditValueChanged
        GetChecks()
    End Sub
    Private Sub GetChecks()
        If Me.IsHandleCreated = False Then Exit Sub
        Me.Text = LookCheqsTrans.Text
        Select Case LookCheqsTrans.EditValue
            Case 1 'ايداع شيكات
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, GetBankAccountsData(Banks.EditValue)._Currency, -1)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = False
                ColCheckBaseAmount2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ColBankAccountName.Visible = False
                ColBankAccountName2.Visible = False
            Case 2 ' ارجاع من البنك
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, Banks.EditValue)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 3 ' ارجاع الى الزبون
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, -1)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = True
                ColCheckBaseAmount2.Visible = True
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 4 ' تجيير الشيكات
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, -1)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                xSearchChecksRelatedAccount.ReadOnly = True
                TextRefAccID.ReadOnly = True
                xSearchChecksRelatedAccount.EditValue = GetDefaultAccounts(1, _DefaultCurreny, GlobalVariables.CurrUser)
                ColCheckBaseAmount.Visible = True
                ColCheckBaseAmount2.Visible = True
            Case 5 'سحب شيك نقدا
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, -1)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = True
                ColCheckBaseAmount2.Visible = True
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColBankAccountName.Visible = False
                ColBankAccountName2.Visible = False
                LayoutsrchCashAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                srchCashAccount.Properties.DataSource = GetFinancialAccounts(1, -1, False, 1, -1)
                srchCashAccount.EditValue = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
            Case 6 ' اخراج شيك صادر من البنك
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, Banks.EditValue)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = False
                ColCheckBaseAmount2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                ColBankAccountName.Visible = True
                ColBankAccountName2.Visible = True
                ColCheckBankName.Visible = False
                ColCheckCustBranch.Visible = False

            Case 7 ' ارجاع شيك صادر من البنك للمورد  
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, Banks.EditValue)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = False
                ColCheckBaseAmount2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            Case 8 ' استرجاع شيك من مورد  
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, Banks.EditValue)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                GridColumnRelatedReferance.Visible = False
                ColRelatedReferance.Visible = False
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = False
                ColCheckBaseAmount2.Visible = False
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case 9 ' اعادة شيك مجير
                GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
                GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, -1, Banks.EditValue)
                LayoutBanks.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutAccountForBank.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutSearchChecksBoxAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutTahseel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCheckReturnDirectToCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                GridColumnRelatedReferance.Visible = True
                ColRelatedReferance.Visible = True
                ColAccountBank.Visible = False
                ColAccountBank2.Visible = False
                ColCheckBaseAmount.Visible = True
                ColCheckBaseAmount2.Visible = True
        End Select

        GridView1.BestFitColumns()
        GridView2.BestFitColumns()

        TextDocNotes.Text = LookCheqsTrans.Text
    End Sub
    Private Sub LookCheqsTrans_BeforePopup(sender As Object, e As EventArgs) Handles LookCheqsTrans.BeforePopup
        LookCheqsTrans.EditValue = 0
    End Sub

    Private Sub Banks_EditValueChanged(sender As Object, e As EventArgs) Handles Banks.EditValueChanged
        GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
        _GetAccountForBank()
        '  GridControl2.DataSource = GetCheques(ComboBoxInOut.Text, 0, -1, -1)
        GridControl1.DataSource = GetCheques(ComboBoxInOut.Text, LookCheqsTrans.EditValue, GetBankAccountsData(Banks.EditValue)._Currency, Banks.EditValue)
    End Sub
    Private Sub _GetAccountForBank()
        Try
            If ChecKTahsel.Checked = True Then
                AccountForBank.EditValue = GetBankAccountsData(Banks.EditValue)._BankCheqsTahselAccount
            Else
                AccountForBank.EditValue = GetBankAccountsData(Banks.EditValue)._BankDepositAccount
            End If
        Catch ex As Exception
            AccountForBank.EditValue = "0"
        End Try




    End Sub

    Private Sub ChecKTahsel_CheckedChanged(sender As Object, e As EventArgs) Handles ChecKTahsel.CheckedChanged
        _GetAccountForBank()
        If ChecKTahsel.Checked = True Then
            ColCheckStatus.FilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo("[StatusName] <>'برسم التحصيل'")
        Else
            GridView1.ClearColumnsFilter()
        End If
    End Sub

    Private Sub ComboBoxInOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxInOut.SelectedIndexChanged

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SearchReferance_EditValueChanged(sender As Object, e As EventArgs) Handles SearchReferance.EditValueChanged
        Try
            TextRefAccID.Text = GetRefranceData(SearchReferance.EditValue).RefAccID
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AccountForBank_EditValueChanged(sender As Object, e As EventArgs) Handles AccountForBank.EditValueChanged

    End Sub

    Private Sub xSearchChecksRelatedAccount_EditValueChanged(sender As Object, e As EventArgs) Handles xSearchChecksRelatedAccount.EditValueChanged

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub كشفحركةالشيكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحركةالشيكToolStripMenuItem.Click
        Try
            Dim _CheckCode As String = GridView1.GetFocusedRowCellValue("CheckCode")
            Dim _CheckNo As String = GridView1.GetFocusedRowCellValue("CheckNo")
            My.Forms.CheksTrans.TextCheckCode.Text = _CheckCode
            My.Forms.CheksTrans.CheckNo.Text = _CheckNo
            My.Forms.CheksTrans.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckReturnDirectToCustomer_CheckedChanged(sender As Object, e As EventArgs) Handles CheckReturnDirectToCustomer.CheckedChanged

    End Sub

    Private Sub srchCashAccount_Popup(sender As Object, e As EventArgs) Handles srchCashAccount.Popup

    End Sub
End Class