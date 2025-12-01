Imports DevExpress.Utils
Imports DevExpress.Utils.Behaviors.Common
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout



Public Class MoneyTrans
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private CurrencyTable As DataTable = GetCurrency()
    Dim _InsertCheckData As Boolean
    Public _PosNo As Integer
    Public _ShiftID As Integer
    Public _DocID2 As Integer
    Public _ForceCloseAfterSaved As Boolean = False
    Public _DocTagsToOpen As String
    Private showWarningForCashAccount As Boolean = False
    Private sendWhatsappAfterSave As Boolean = False

    Private Sub MoneyTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextDocManualNo.Select()
        LoadSettings()
        Me.KeyPreview = True
    End Sub
    Private Sub LoadSettings()

        Me.RepositoryLookUpBanks.DataSource = GetBanksTable()
        Me.RepositoryLookUpBranches.DataSource = GetBanksBranches()

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters';
                                           Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInMoneyTransDoc';
                                           Select EmployeeID,EmployeeName from EmployeesData;
                                           Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowRefMobileInDocuments';
                                           Select [SettingValue] From [dbo].[Settings] Where [SettingName]='PosPlayBeep';
                                           Select [SettingValue] From [dbo].[Settings] Where [SettingName]='Accounting_ShowWarningForCashAccountInPayments';
                                           Select [SettingValue] From [dbo].[Settings] Where [SettingName]='SendWhatsappAfterSaveForMoneyTrans'")

            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Always
                Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
            Else
                Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Never
            End If

            If CBool(Sql.SQLDS.Tables(1).Rows(0).Item("SettingValue")) = True Then
                ColDocNoteByAccount.Visible = True
            Else
                ColDocNoteByAccount.Visible = False
            End If

            If GlobalVariables._UseSalesMan = True Then
                Me.SalesPerson.Properties.DataSource = Sql.SQLDS.Tables(2)
                Me.LayoutControlSalesPerson.Visibility = Utils.LayoutVisibility.Always
            End If

            ColRefMobile.Visible = CBool(Sql.SQLDS.Tables(3).Rows(0).Item("SettingValue"))

            GlobalPosVariables._PlayBeep = CBool(Sql.SQLDS.Tables(4).Rows(0).Item("SettingValue"))
            showWarningForCashAccount = CBool(Sql.SQLDS.Tables(5).Rows(0).Item("SettingValue"))
            sendWhatsappAfterSave = CBool(Sql.SQLDS.Tables(6).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Never
        End Try
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Saving()
        ElseIf e.KeyCode = Keys.F4 Then
            ' ShowPrint()
        ElseIf e.KeyCode = Keys.Enter Then
            If GridViewChecks.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.End Then
            TextDocNotes.Focus()
            'ElseIf e.KeyCode = Keys.Escape Then
            '    If XtraMessageBox.Show("هل تريد الخروج من السند؟", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
            '        Me.Close()
            '    End If
        End If
    End Sub
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            If XtraMessageBox.Show("هل تريد الخروج من السند؟", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Me.Close()
            End If
            Return True
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function
    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        If String.IsNullOrEmpty(Referance.Text) Then
            AccountForRefranace.ReadOnly = False
        Else
            AccountForRefranace.ReadOnly = True
        End If
        If Referance.IsHandleCreated Then
            If Referance.Text <> "" Then
                Dim RefData = GetRefranceData(Referance.EditValue)
                TextReferanceName.Text = RefData.RefName
                AccountForRefranace.EditValue = RefData.RefAccID
                TextRefBalance.Text = GetReferanceBalance(Referance.EditValue)
                SalesPerson.EditValue = RefData.SalesMan
            Else
                TextReferanceName.Text = ""
                AccountForRefranace.EditValue = ""
                TextRefBalance.Text = ""
                SalesPerson.EditValue = 0
            End If
        End If
    End Sub

    Private Function CreatCashAccTable() As DataTable
        Dim OtherAccTable As New DataTable
        With OtherAccTable
            .Columns.Add("DebitCredAcc", GetType(String))
            .Columns.Add("DebitCredAccCurr", GetType(Integer))
            .Columns.Add("DocAmount", GetType(Decimal))
            .Columns.Add("AccountCurr", GetType(Integer))
            .Columns.Add("ExchangePrice", GetType(Decimal))
            .Columns.Add("BaseCurrAmount", GetType(Decimal))
            .Columns.Add("DocCurrency", GetType(Decimal))
        End With
        Return OtherAccTable
    End Function
    Private Function CreatChecksAccTable() As DataTable
        Dim OtherAccTable As New DataTable
        With OtherAccTable
            .Columns.Add("AccountBank", GetType(String))
            .Columns.Add("CheckNo", GetType(String))
            .Columns.Add("CheckCustBank", GetType(String))
            .Columns.Add("CheckCustBranch", GetType(String))
            .Columns.Add("CheckCustAccountId", GetType(String))
            .Columns.Add("CheckDueDate", GetType(DateTime))
            .Columns.Add("DocCheksCurr", GetType(Decimal))
            .Columns.Add("AccountCurr", GetType(Integer))
            .Columns.Add("ExchangePrice", GetType(Decimal))
            .Columns.Add("BaseCurrAmount", GetType(Decimal))
            .Columns.Add("DocAmount", GetType(Decimal))
            .Columns.Add("FinancialAccount", GetType(String))
            .Columns.Add("CheckCode", GetType(String))
            .Columns.Add("DocNoteByAccount", GetType(String))
        End With
        Return OtherAccTable
    End Function
    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        With GridView2
            Try
                If e.Column.FieldName = "DebitCredAcc" Then
                    Dim _DebitCredAcc As String = .GetRowCellValue(.FocusedRowHandle, "DebitCredAcc")
                    Dim _CurrencyID As Integer = GetFinancialAccountsData(_DebitCredAcc).Currency
                    .SetRowCellValue(.FocusedRowHandle, .Columns("AccountCurr"), _CurrencyID)
                    If _CurrencyID = _DefaultCurr Then
                        .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), 1)
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'If e.Column.FieldName = "AccType" Then
            '    .SetRowCellValue(.FocusedRowHandle, .Columns("CheckNo"), 0)
            '    .SetRowCellValue(.FocusedRowHandle, .Columns("CheckDueDate"), "1900-01-01")
            'End If


            Try
                If e.Column.FieldName = "DocAmount" Or e.Column.FieldName = "ExchangePrice" Then
                    Try
                        Dim _DocAmount As Decimal = .GetRowCellValue(.FocusedRowHandle, "DocAmount")
                        Dim _ExchangePrice As Decimal = .GetRowCellValue(.FocusedRowHandle, "ExchangePrice")
                        .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DocAmount * _ExchangePrice)
                    Catch ex As Exception
                        '  MsgBox(ex.ToString)
                    End Try
                End If

            Catch ex As Exception
            End Try

        End With


    End Sub


    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewChecks.CellValueChanged
        With GridViewChecks
            Try
                If e.Column.FieldName = "DocAmount" Or e.Column.FieldName = "ExchangePrice" Then
                    Try
                        Dim _DocAmount As Decimal = .GetRowCellValue(.FocusedRowHandle, "DocCheksCurr")
                        Dim _ExchangePrice As Decimal = .GetRowCellValue(.FocusedRowHandle, "ExchangePrice")
                        .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DocAmount * _ExchangePrice)
                    Catch ex As Exception
                        '  MsgBox(ex.ToString)
                    End Try
                    GridViewChecks.UpdateTotalSummary()
                    DocCheqsAmount.EditValue = ColCheksDocAmount.SummaryText
                End If

                If e.Column.FieldName = "AccountBank" Then
                    Dim _AccountBank = GetBankAccountsData(e.Value)
                    .SetRowCellValue(.FocusedRowHandle, .Columns("CheckCustAccountId"), _AccountBank._BankAccID)
                    .SetRowCellValue(.FocusedRowHandle, .Columns("CheckCustBank"), _AccountBank._BankID)
                    .SetRowCellValue(.FocusedRowHandle, .Columns("CheckCustBranch"), _AccountBank._BranchID)
                    .SetRowCellValue(.FocusedRowHandle, .Columns("FinancialAccount"), _AccountBank._BankOutChequeAccount)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With
    End Sub
    Private Sub View5_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridViewChecks.ValidateRow

        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _CheckNo As GridColumn = view.Columns("CheckNo")
            If IsDBNull(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "CheckNo")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال رقم الشيك"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _CheckNo
                view.ShowEditor()
            End If


            Dim _CheckDueDate As GridColumn = view.Columns("CheckDueDate")
            If IsDBNull(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "CheckDueDate")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال تاريخ استحقاق الشيك"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _CheckDueDate
                view.ShowEditor()
            End If


            Dim _DocAmount As GridColumn = view.Columns("DocAmount")
            If IsDBNull(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "DocAmount")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DocAmount
                view.ShowEditor()

            End If



            If Me.DocName.EditValue = 3 Then
                Dim _AccountBank As GridColumn = view.Columns("AccountBank")
                If IsDBNull(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "AccountBank")) = True Then
                    e.Valid = False
                    e.ErrorText = "يجب اختيار الحساب البنكي"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = _AccountBank
                    view.ShowEditor()
                End If
            End If

            If Me.DocName.EditValue = 3 Then
                Dim checkNoCol As GridColumn = view.Columns("CheckNo")
                Dim checkNo As Integer = Integer.Parse(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "CheckNo"))
                Dim accountBank As Integer = Integer.Parse(Me.GridViewChecks.GetRowCellValue(GridViewChecks.FocusedRowHandle, "AccountBank"))
                If CheckIFOutChequeExistInChecksTable(checkNo, accountBank) = True Then
                    e.Valid = False
                    MsgBoxShowError(" رقم الشيك مصدر من قبل لهذا البنك ، الرجاء مراجعة البيانات ")
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = checkNoCol
                    view.ShowEditor()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView5_RowUpdated(sender As Object, e As RowObjectEventArgs) Handles GridViewChecks.RowUpdated, GridView2.RowUpdated
        Try
            GridViewChecks.UpdateTotalSummary()
            Dim _Res As Decimal = 0
            Dim ChecksSum As Decimal = 0
            Dim CashSum As Decimal = 0
            Try
                DocCheqsAmount.EditValue = ColCheksDocAmount.SummaryText
            Catch ex As Exception
            End Try
            Try
                ChecksSum = CDec(ColCheckBaseCurrAmount.SummaryItem.SummaryValue)
            Catch ex As Exception
            End Try
            Try
                CashSum = CDec(ColCashBaseCurrAmount.SummaryItem.SummaryValue)
            Catch ex As Exception
            End Try



            TextAmountInRefCurr.Text = (Val(ChecksSum) + Val(CashSum)) / ExchangePriceForReferanceAcc.EditValue
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Saving()
    End Sub


    Private Sub GridView2_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView2.InitNewRow
        GridView2.SetRowCellValue(e.RowHandle, "AccountCurr", DocCurrencyForReferanceAcc.EditValue)
        GridView2.SetRowCellValue(e.RowHandle, "ExchangePrice", ExchangePriceForReferanceAcc.EditValue)
    End Sub



    Private Sub Saving()

        If TotalDocAmount.EditValue = 0 Then
            XtraMessageBox.Show(" السند فارغ، لا يمكن الترحيل  ")
            Exit Sub
        End If

        If DocStatus.EditValue = 3 Then
            XtraMessageBox.Show(" السند مرحل، لا يمكن حفظه  ")
            Exit Sub
        End If

        If DocCashAmount.EditValue > 0 Then
            If String.IsNullOrEmpty(CashAccount.Text) Then
                XtraMessageBox.Show(" يجب اختيار حساب الصندوق النقدي  ")
                Exit Sub
            End If
        End If

        For i = 0 To GridViewChecks.RowCount - 1
            If Not IsDBNull(GridViewChecks.GetRowCellValue(i, "TransNoInJournal")) Then
                If GridViewChecks.GetRowCellValue(i, "TransNoInJournal") > 1 Then
                    MsgBox("لا يمكن تعديل السند، يوجد حركات على الشيكات")
                    Exit Sub
                End If
            End If
        Next

        If DocDate.DateTime > Today Then
            If XtraMessageBox.Show("تاريخ السند اكبر من تاريخ اليوم، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
        End If

        If showWarningForCashAccount AndAlso DocCashAmount.EditValue <> 0 Then
            If GetAccountBalance(CashAccount.EditValue) <= DocCashAmount.EditValue AndAlso DocName.EditValue = 3 Then
                If XtraMessageBox.Show("رصيد الحساب النقدي اقل من المبلغ المدخل، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If
        End If

        Dim _ModifiedDateTime As String
        Dim _CheckIfDocInJournal As Boolean
        Dim _InputDateTime As String
        Dim _DeviceName As String
        Dim _InputUser As Integer
        If DocStatus.EditValue = -1 Then
            _CheckIfDocInJournal = False
            _InputDateTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            _DeviceName = GlobalVariables.CurrDevice
            _ModifiedDateTime = "1900-01-01"
            _InputUser = GlobalVariables.CurrUser
        Else
            '_CheckIfDocInJournal = CheckIfDocInJournal(DocName.Text, TextDocIDQuery.Text)
            _CheckIfDocInJournal = True
            _InputDateTime = Format(CDate(BarInputDateTime.Caption), "yyyy-MM-dd HH:mm:ss")
            _DeviceName = Me.BarDeviceName.Caption
            _ModifiedDateTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            _InputUser = Me.BarInputUser.Caption
        End If
        Dim _DocTags As String = _DocTagsToOpen


        If AccountForRefranace.Text = "" Then
            MsgBox(" يجب اختيار حساب للذمة")
            Exit Sub
        End If

        'Check Cost Center for ref account
        If GlobalVariables._CostCenterRequired = True Then
            If LookCostCenter.Text = "" Then
                Dim _Account As New FinancialAccount
                If _Account.GetAccountData(AccountForRefranace.EditValue) = True Then
                    If _Account.NeedCostCenter = True Then
                        XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        Exit Sub
                    End If
                End If
            End If
        End If

        Dim _DocLogName As String = ""
        Dim _LogDetails As String = ""
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _AskBeforeSave As String = "0"
        Select Case _CheckIfDocInJournal
            Case True
                _AskBeforeSave = "هل تريد تعديل السند"
                _DocLogName = "Update"
                _LogDetails = "Update Voucher "
            Case False
                _AskBeforeSave = "هل تريد حفظ السند"
                _DocLogName = "Insert"
                _LogDetails = "New Voucher "
        End Select


        If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            'ProgressBarControl1.EditValue = 0
            ' ProgressBarControl1.PerformStep()
            ' ProgressBarControl1.Update()

            If String.IsNullOrEmpty(DocDate.Text) Then
                XtraMessageBox.Show("يجب اختيار تاريخ")
                Exit Sub
            End If

            If String.IsNullOrEmpty(AccountForRefranace.Text) Or AccountForRefranace.Text = "0" Then
                XtraMessageBox.Show("يجب اختيار حساب المرجع")
                Exit Sub
            End If

            If String.IsNullOrEmpty(TotalDocAmount.Text) Or TotalDocAmount.Text = "0" Then
                XtraMessageBox.Show("السند فارغ")
                Exit Sub
            End If

            If TextMultiCurrency.Text = "True" Then
                If String.IsNullOrEmpty(DocCurrency.Text) Or DocCurrency.Text = "0" Then
                    XtraMessageBox.Show("يجب اخنيار عملة")
                    Exit Sub
                End If

                If String.IsNullOrEmpty(ExchangePrice.Text) Or ExchangePrice.Text = "0" Then
                    XtraMessageBox.Show("سعر الصرف خطا")
                    Exit Sub
                End If
            End If


            DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
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
                .Columns.Add("ModifiedDateTime", GetType(DateTime))
                .Columns.Add("DeviceName", GetType(String))
                .Columns.Add("DocNotes", GetType(String))
                .Columns.Add("CheckNo", GetType(Integer))
                .Columns.Add("CheckCustBank", GetType(String))
                .Columns.Add("CheckCustBranch", GetType(String))
                .Columns.Add("CheckCustAccountId", GetType(String))
                .Columns.Add("CheckInOut", GetType(String))
                .Columns.Add("CheckStatus", GetType(Integer))
                .Columns.Add("AccountBank", GetType(Integer))
                .Columns.Add("CheckDueDate", GetType(String))
                .Columns.Add("ReferanceName", GetType(String))
                .Columns.Add("CurrentUserID", GetType(String))
                .Columns.Add("DocCode", GetType(String))
                .Columns.Add("CheckCode", GetType(String))
                .Columns.Add("DocNoteByAccount", GetType(String))
                .Columns.Add("TransNoInJournal", GetType(Integer))
                .Columns.Add("DocTags", GetType(String))
                .Columns.Add("SalesPerson", GetType(Integer))
            End With

            '   ProgressBarControl1.PerformStep()
            '   ProgressBarControl1.Update()

            Dim _Referance As Integer = 0
            Try
                If Referance.Text = "" Then
                    _Referance = 0
                Else
                    _Referance = Referance.Text
                End If
            Catch ex As Exception
                _Referance = 0
            End Try


            Select Case DocName.EditValue
                Case 3 ' Payment Doc
                    'Add Debit Account
                    With JournalTable
                        Dim AccData = GetFinancialAccountsData(AccountForRefranace.EditValue)
                        Dim R As DataRow = .NewRow
                        R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                        R("DocName") = DocName.EditValue
                        R("DocStatus") = 1
                        If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = "0" Else R("DocCostCenter") = LookCostCenter.EditValue
                        If String.IsNullOrEmpty(AccountForRefranace.Text) Then R("DebitAcc") = "0" Else R("DebitAcc") = AccountForRefranace.EditValue
                        R("CredAcc") = "0"
                        R("AccountCurr") = AccData.Currency
                        R("DocCurrency") = DocCurrency.EditValue
                        R("DocAmount") = TotalDocAmount.EditValue
                        R("ExchangePrice") = ExchangePrice.EditValue
                        R("BaseCurrAmount") = R("DocAmount") * R("ExchangePrice")
                        R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                        If String.IsNullOrEmpty(LookDocSort.Text) Then R("DocSort") = 0 Else R("DocSort") = LookDocSort.EditValue
                        If String.IsNullOrEmpty(Referance.Text) Then R("Referance") = 0 Else R("Referance") = Referance.EditValue
                        If String.IsNullOrEmpty(TextDocManualNo.Text) Then R("DocManualNo") = 0 Else R("DocManualNo") = TextDocManualNo.EditValue
                        R("InputUser") = GlobalVariables.CurrUser
                        R("DocNotes") = TextDocNotes.Text
                        R("ReferanceName") = TextReferanceName.Text
                        R("DocTags") = _DocTags
                        If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                        JournalTable.Rows.Add(R)

                    End With
                    'Add Credit Account Payment Doc
                    With GridViewChecks ' الشيكات
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                Dim R As DataRow = JournalTable.NewRow
                                Dim BankOutChequeAccount As Integer = GetBankAccountsData(.GetRowCellValue(i, "AccountBank"))._BankOutChequeAccount
                                '  Dim ChAccData = GetFinancialAccountsData(_AccountBank.)
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = DocName.EditValue
                                If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = "0" Else R("DocCostCenter") = LookCostCenter.EditValue
                                ' R("DocCostCenter") = "0"
                                R("DebitAcc") = "0"
                                R("CredAcc") = BankOutChequeAccount
                                R("AccountCurr") = GetFinancialAccountsData(BankOutChequeAccount).Currency
                                R("DocCurrency") = DocCurrency.EditValue
                                R("DocAmount") = .GetRowCellValue(i, "DocAmount")
                                R("ExchangePrice") = ExchangePrice.EditValue
                                R("BaseCurrAmount") = R("DocAmount") * R("ExchangePrice")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckInOut") = "OUT"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "1"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckCustBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckCustBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckCustAccountId")
                                R("AccountBank") = .GetRowCellValue(i, "AccountBank")
                                R("Referance") = _Referance
                                R("ReferanceName") = TextReferanceName.Text
                                R("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                                If IsDBNull(.GetRowCellValue(i, "CheckCode")) Then R("CheckCode") = CreateRandomCode() Else R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                If Me.DocStatus.EditValue = -1 Then
                                    R("TransNoInJournal") = 1
                                Else
                                    R("TransNoInJournal") = .GetRowCellValue(i, "TransNoInJournal")
                                End If
                                R("DocTags") = _DocTags
                                If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                                JournalTable.Rows.Add(R)
                                InsertToCalender(R("CheckDueDate"), CDate(R("CheckDueDate")).AddDays(0), "شيك صادر" & " " & FormatNumber(R("DocAmount"), 0) & " " & GetCurrencyCode(R("DocCurrency")), R("ReferanceName"), " شيك صادر مستحق ل  " & R("ReferanceName") & " (" & R("CheckNo") & ")", 1, GlobalVariables.CurrUser, Today(), -1, R("Referance"), R("CheckCode"))
                            End If
                        Next
                    End With
                    With GridView2 ' الصناديق
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "DebitCredAcc")) Then
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = DocName.EditValue
                                If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = "0" Else R("DocCostCenter") = LookCostCenter.EditValue
                                'R("DocCostCenter") = "0"
                                R("DebitAcc") = "0"
                                R("CredAcc") = .GetRowCellValue(i, "DebitCredAcc")
                                R("AccountCurr") = .GetRowCellValue(i, "AccountCurr")
                                R("DocCurrency") = DocCurrency.EditValue
                                R("DocAmount") = .GetRowCellValue(i, "DocAmount")
                                R("ExchangePrice") = ExchangePrice.EditValue
                                R("BaseCurrAmount") = R("ExchangePrice") * R("DocAmount")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                                R("DocManualNo") = TextDocManualNo.Text
                                R("InputUser") = GlobalVariables.CurrUser
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckNo") = "0"
                                R("CheckDueDate") = "1900-01-01"
                                R("CheckCustBank") = "0"
                                R("CheckCustBranch") = "0"
                                R("CheckCustAccountId") = "0"
                                R("CheckStatus") = "0"
                                R("Referance") = _Referance
                                R("ReferanceName") = TextReferanceName.Text
                                R("DocTags") = _DocTags
                                If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                                JournalTable.Rows.Add(R)
                            End If
                        Next
                    End With
                Case 4 ' Receipt Doc
                    'Add Debit Account
                    With GridView2 ' الصناد
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "DebitCredAcc")) Then
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = DocName.EditValue
                                If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = "0" Else R("DocCostCenter") = LookCostCenter.EditValue
                                ' R("DocCostCenter") = "0"
                                R("DebitAcc") = .GetRowCellValue(i, "DebitCredAcc")
                                R("CredAcc") = "0"
                                R("AccountCurr") = .GetRowCellValue(i, "AccountCurr")
                                R("DocCurrency") = .GetRowCellValue(i, "DocCurrency")
                                R("DocAmount") = .GetRowCellValue(i, "DocAmount")
                                R("ExchangePrice") = ExchangePrice.EditValue
                                R("BaseCurrAmount") = R("ExchangePrice") * R("DocAmount")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                                R("DocManualNo") = TextDocManualNo.Text
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckNo") = "0"
                                R("CheckDueDate") = "1900-01-01"
                                R("CheckCustBank") = "0"
                                R("CheckCustBranch") = "0"
                                R("CheckCustAccountId") = "0"
                                R("CheckStatus") = "0"
                                R("Referance") = _Referance
                                R("ReferanceName") = TextReferanceName.Text
                                R("DocTags") = _DocTags
                                If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                                JournalTable.Rows.Add(R)
                            End If
                        Next
                    End With
                    With GridViewChecks ' الشيكات
                        Dim ChAccData = GetFinancialAccountsData(SearchChecksBoxAccount.EditValue)
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "CheckNo")) Then
                                Dim R As DataRow = JournalTable.NewRow
                                R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                                R("DocName") = DocName.EditValue
                                If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = "0" Else R("DocCostCenter") = LookCostCenter.EditValue
                                'R("DocCostCenter") = "0"
                                R("DebitAcc") = SearchChecksBoxAccount.EditValue
                                R("CredAcc") = "0"
                                R("AccountCurr") = ChAccData.Currency
                                R("DocCurrency") = DocCurrency.EditValue
                                R("DocAmount") = .GetRowCellValue(i, "DocAmount")
                                R("ExchangePrice") = ExchangePrice.EditValue
                                R("BaseCurrAmount") = R("DocAmount") * R("ExchangePrice")
                                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                                R("DocManualNo") = TextDocManualNo.Text
                                R("DocNotes") = TextDocNotes.Text
                                R("CheckInOut") = "IN"
                                R("CheckNo") = .GetRowCellValue(i, "CheckNo")
                                R("CheckDueDate") = Format(CDate(.GetRowCellValue(i, "CheckDueDate")), "yyyy-MM-dd")
                                R("CheckStatus") = "3"
                                R("CheckCustBank") = .GetRowCellValue(i, "CheckCustBank")
                                R("CheckCustBranch") = .GetRowCellValue(i, "CheckCustBranch")
                                R("CheckCustAccountId") = .GetRowCellValue(i, "CheckCustAccountId")
                                R("AccountBank") = .GetRowCellValue(i, "AccountBank")
                                R("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                                R("Referance") = _Referance
                                R("ReferanceName") = TextReferanceName.Text
                                If IsDBNull(.GetRowCellValue(i, "CheckCode")) Then R("CheckCode") = CreateRandomCode() Else R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                If Me.DocStatus.EditValue = -1 Then
                                    R("TransNoInJournal") = 1
                                Else
                                    R("TransNoInJournal") = .GetRowCellValue(i, "TransNoInJournal")
                                End If
                                R("DocTags") = _DocTags
                                If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                                JournalTable.Rows.Add(R)
                                InsertToCalender(R("CheckDueDate"), CDate(R("CheckDueDate")).AddDays(0), "شيك وارد" & " " & FormatNumber(R("DocAmount"), 0) & " " & GetCurrencyCode(R("DocCurrency")), R("ReferanceName"), " شيك وارد مستحق ل  " & R("ReferanceName") & " (" & R("CheckNo") & ")", 3, GlobalVariables.CurrUser, Today(), -1, R("Referance"), R("CheckCode"))
                            End If
                        Next
                    End With
                    'Add Credit Account
                    With JournalTable
                        Dim R As DataRow = .NewRow
                        R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                        R("DocName") = DocName.EditValue
                        R("DocStatus") = 1
                        If String.IsNullOrEmpty(LookCostCenter.Text) Then R("DocCostCenter") = 0 Else R("DocCostCenter") = LookCostCenter.EditValue
                        If String.IsNullOrEmpty(AccountForRefranace.Text) Then R("CredAcc") = "0" Else R("CredAcc") = CStr(AccountForRefranace.EditValue)
                        R("DebitAcc") = "0"
                        R("AccountCurr") = DocCurrencyForReferanceAcc.EditValue
                        R("DocCurrency") = DocCurrency.EditValue
                        R("DocAmount") = TotalDocAmount.EditValue
                        R("ExchangePrice") = ExchangePrice.EditValue
                        R("BaseCurrAmount") = R("DocAmount") * R("ExchangePrice")
                        R("BaseAmount") = GetBaseAmount(R("AccountCurr"), R("DocAmount"))
                        If String.IsNullOrEmpty(LookDocSort.Text) Then R("DocSort") = 0 Else R("DocSort") = LookDocSort.EditValue
                        If String.IsNullOrEmpty(Referance.Text) Then R("Referance") = 0 Else R("Referance") = Referance.EditValue
                        If String.IsNullOrEmpty(TextDocManualNo.Text) Then R("DocManualNo") = 0 Else R("DocManualNo") = TextDocManualNo.EditValue
                        R("DocNotes") = TextDocNotes.Text
                        JournalTable.Rows.Add(R)
                        R("ReferanceName") = TextReferanceName.Text
                        R("DocTags") = _DocTags
                        If SalesPerson.Text <> "" Then R("SalesPerson") = SalesPerson.EditValue Else R("SalesPerson") = 0
                    End With
            End Select


            '   ProgressBarControl1.PerformStep()
            '   ProgressBarControl1.Update()

            Dim _DocID As Integer = 0
            If _CheckIfDocInJournal = False Then
                _DocID = GetDocNo(DocName.EditValue, False)
            Else
                _DocID = TextDocID.Text
            End If
            If _DocID = 0 Then
                XtraMessageBox.Show("لا يمكن ترحيل السند: خطا برقم السند")
                Exit Sub
            End If


            For Each row As DataRow In JournalTable.Rows
                Dim Sql2 As New SQLControl
                Dim SqlInsertDetials As String
                Dim _Count As Integer
                If row("TransNoInJournal").ToString = "" Then
                    _Count = 1
                Else
                    _Count = row("TransNoInJournal").ToString
                End If
                ' If IsNothing(row("TransNoInJournal").ToString) Then _Count = 1
                SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,DeviceName,CheckNo,CheckInOut,CheckStatus,
                                       [CheckDueDate],CurrentUserID,Referance,ReferanceName,CheckCustBank,CheckCustBranch,
                                       CheckCustAccountId,AccountBank,DocCode,CheckCode,DocCostCenter,DocNoteByAccount,TransNoInJournal,DocTags,SalesPerson ) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(CDate(row("DocDate").ToString), "yyyy-MM-dd") & "', 
                                      '" & row("DocName").ToString & "', 
                                      '" & 1 & "',
                                      '" & row("DebitAcc").ToString & "',
                                      '" & row("CredAcc").ToString & "',
                                      '" & row("AccountCurr").ToString & "',
                                      '" & row("DocCurrency").ToString & "',
                                      '" & row("DocAmount").ToString & "',
                                      '" & row("ExchangePrice").ToString & "',
                                      '" & row("BaseCurrAmount").ToString & "',
                                      '" & row("BaseAmount").ToString & "',
                                      N'" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & _InputUser & "',
                                      '" & _InputDateTime & "',
                                      '" & _ModifiedDateTime & "',
                                       N'" & _DeviceName & "',
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
                                      '" & DocCode.Text & "',
                                      '" & row("CheckCode").ToString & "',
                                      '" & row("DocCostCenter").ToString & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                       " & _Count & ",
                                      N'" & row("DocTags").ToString & "',
                                      N'" & row("SalesPerson").ToString & "'
                                            )"

                If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                    MsgBox("خطا بحفظ السند")
                    DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                    Exit Sub
                End If

            Next row
            ' لا زم هان غي كود يحص القيد اذا كله اترحل 

            '  ProgressBarControl1.PerformStep()
            '  ProgressBarControl1.Update()

            If _CheckIfDocInJournal = True Then
                DeleteFromJournal(DocName.Text, _DocID)
            End If
            If InsertFromTempToJournal(DocName.Text, _DocID) = False Then
                XtraMessageBox.Show("خطا بعملية الحفظ")
                DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                Exit Sub
            End If

            If GlobalVariables._HasOrpak = True Then
                If CheckIfFleetExist() = True Then
                    'ChargeFleet()
                    CheckIfFleetBlocked()
                End If
            End If

            CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, _DocLogName, _LogDetails, _LogDateTime)

            If GlobalVariables._Shalash = True And Me.DocName.EditValue = 4 Then
                SendSMSMessage(CStr("120363419725512046"), " دفعة بقيمة  " & Me.TotalDocAmount.EditValue & " من " & Me.TextReferanceName.Text & " بتاريخ " & _LogDateTime & " المستخدم " & GlobalVariables.EmployeeName, "WhatsApp", True, Me.TextReferanceName.Text)
            End If
            If GlobalVariables._Shalash = True And Me.DocName.EditValue = 3 Then
                SendSMSMessage(CStr("120363418450142475"), " دفعة بقيمة  " & Me.TotalDocAmount.EditValue & " الى " & Me.TextReferanceName.Text & " بتاريخ " & _LogDateTime & " المستخدم " & GlobalVariables.EmployeeName, "WhatsApp", True, Me.TextReferanceName.Text)
            End If




            If sendWhatsappAfterSave = True Then
                Dim docTypeName As String = If(Me.DocName.EditValue = 3, "سند صرف", "سند قبض")
                Dim whatsappMessage As String = String.Format(
                "✅ *تم {0}*{1}{1}" &
                "📄 نوع السند: {2}{1}" &
                "🔢 رقم السند: {3}{1}" &
                "📅 التاريخ: {4}{1}" &
                "👤 المستخدم: {5}{1}" &
                "💰 الحساب: {6}{1}" &
                "💵 المبلغ: {7}",
                If(DocStatus.EditValue = -1, "حفظ", "تعديل"),
                Environment.NewLine,
                docTypeName,
                _DocID,
                DateTime.Parse(_LogDateTime).ToString("yyyy-MM-dd HH:mm"),
                GlobalVariables.EmployeeName,
                CashAccount.Text,
                FormatNumber(TotalDocAmount.EditValue, 2))
                SendSMSMessage(CStr("120363422414893307"), whatsappMessage, "WhatsApp", True, Me.TextReferanceName.Text)
            End If

            'CoptToClip(JournalTable)
            Referance.EditValue = 0
            TextDocNotes.Text = ""
            TextDocManualNo.Text = ""
            TextReferanceName.Text = ""
            AccountForRefranace.EditValue = 0
            DocCashAmount.EditValue = 0
            _DocTagsToOpen = ""
            '  TexCashAmount.Text = "0"
            'LoadDefault()
            DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
            If GlobalPosVariables._PlayBeep = True Then
                My.Computer.Audio.Play(My.Resources.CashSound, AudioPlayMode.Background)
                'AlertControl1.Show(Me, "Sample caption", "Sample notification text")

            End If
            If GlobalVariables._ShowActionMenueAfterSaveDocuments = True Then
                Dim F As New SavePrintPostDocument
                With F
                    .TextDocCode.Text = Me.DocCode.Text
                    .TextDocData.Text = "Journal"
                    .LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .LayoutPayVoucher.Visibility = Utils.LayoutVisibility.Always
                    If .ShowDialog() <> DialogResult.OK Then
                        If _ForceCloseAfterSaved = True Then
                            Me.Close()
                        Else
                            If Me.DocStatus.EditValue = -1 Then
                                LoadDefault()
                            Else
                                Me.Close()
                            End If
                        End If
                    End If

                End With
            End If
            'Dim _string As String = " مازن زهران <br> مازن زهران     بلع رصيده  <br> مازن زهران  <br>  مازن زهران "
            '_string += " مازن زهران <br> مازن زهران     بلع رصيده  <br> مازن زهران  <br>  مازن زهران "
            '_string.Replace("<br>", Environment.NewLine)
            'Dim aInfo As New AlertInfo("Sample notification", "تم حغظ السند بنجاح")
            'aInfo.ImageOptions.SvgImage = My.Forms.Main.SvgImageCollection1(0)

            'My.Forms.Main.AlertControl1.Show(My.Forms.Main, aInfo)

        End If
        Me.DocDate.Focus()

        'DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
        ' ProgressBarControl1.PerformStep()
        '  ProgressBarControl1.Update()

        'MsgBoxShowSuccess()

    End Sub
    Private Sub LoadDefault()

        DocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
        TextDocID.Text = GetDocNo(DocName.EditValue, True)

        '  TextCheckAmount.EditValue = 0
        GridControlCash.DataSource = CreatCashAccTable()

        GridControlChecks.DataSource = CreatChecksAccTable()

        DocCurrencyForReferanceAcc.Properties.DataSource = CurrencyTable
        DocCurrencyForReferanceAcc.EditValue = GetDefaultCurrency()
        SearchChecksBoxAccount.EditValue = GetDefaultAccounts(2, DocCurrencyForReferanceAcc.EditValue, GlobalVariables.CurrUser)
        CashAccount.EditValue = GetDefaultAccounts(1, DocCurrencyForReferanceAcc.EditValue, GlobalVariables.CurrUser)
        If String.IsNullOrEmpty(CashAccount.Text) Then
            MsgBoxShowError(" لا يوجد حساب افتراضي للمستخدم ")
            Me.Close()
        End If
        DocCurrency.EditValue = GetDefaultCurrency()
        ExchangePrice.Text = "1"
        DocCashAmount.Text = "0"
        DocCheqsAmount.Text = "0"
        DocStatus.EditValue = -1
        Me.TextDocIDQuery.EditValue = -1
        LayoutDelete.Visibility = Utils.LayoutVisibility.Never
        InsertDefaultRecordToOtherAccountTable()
        If DocName.EditValue = 3 Then
            RepositoryAccountBank.DataSource = GetBankAccounts(DocCurrency.EditValue)
            ColAccountBank.Visible = True
            LayoutCheqsInAccount.Visibility = Utils.LayoutVisibility.Never
        ElseIf DocName.EditValue = 4 Then
            ColAccountBank.Visible = False
            LayoutCheqsInAccount.Visibility = Utils.LayoutVisibility.Always
        End If
        BehaviorManager1.Detach(Of DisabledCellBehavior)(GridViewChecks)
        Me.TextDocID.EditValue = GetDocNo(Me.DocName.EditValue, True)
        Me.LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        DocCode.Text = CreateRandomCode()
        Me.SalesPerson.EditValue = 0
    End Sub
    Private Function GetBaseAmount(_AccountCurr As Integer, _DocAmount As Decimal) As Decimal
        Dim _BaseAmount As Decimal
        If _AccountCurr = DocCurrency.EditValue Then
            _BaseAmount = _DocAmount
        ElseIf _AccountCurr = _DefaultCurr And DocCurrency.EditValue = _DefaultCurr Then
            _BaseAmount = _DocAmount / GetExchengPrice(_AccountCurr, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        Else
            _BaseAmount = (_DocAmount * ExchangePrice.EditValue) / GetExchengPrice(_AccountCurr, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        End If
        Return _BaseAmount
    End Function
    Private Sub CoptToClip(DT As DataTable)
        Dim ClipText As String = String.Empty
        For Each row As DataRow In DT.Rows
            Dim ClipRow As String = String.Empty
            ClipRow = String.Empty
            For Each col As DataColumn In DT.Columns
                If Not String.IsNullOrEmpty(ClipRow) Then
                    ClipRow += ControlChars.Tab
                End If

                ClipRow += row(col.ColumnName).ToString
            Next
            ClipText += ClipRow + ControlChars.NewLine
        Next
        Clipboard.SetText(ClipText)

    End Sub



    Private Sub DocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles DocStatus.EditValueChanged
        Select Case DocStatus.EditValue
            Case -1
                LoadDefault()

            Case 2
                DocStatus.BackColor = Color.Red
            Case 3
                DocStatus.BackColor = Color.Red
            Case Else
                DocStatus.BackColor = DefaultBackColor
        End Select
    End Sub


    Private Sub DocCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles DocCurrency.EditValueChanged
        If DocCurrency.IsHandleCreated Then
            CashAccount.EditValue = GetDefaultAccounts(1, DocCurrency.EditValue, GlobalVariables.CurrUser)
            InsertDefaultRecordToOtherAccountTable()
            If DocName.EditValue = 3 Then
                '  RepositoryAccountBank.DataSource = GetBankAccounts(DocCurrency.EditValue)
                RepositoryItemLookUpEditAccountBank.DataSource = GetBankAccounts(DocCurrency.EditValue)
            End If
        End If

    End Sub
    Private Sub InsertDefaultRecordToOtherAccountTable()
        If ExchangePrice.Text = "" Then Exit Sub
        If TextMultiCurrency.Text <> "True" AndAlso DocCashAmount.EditValue IsNot Nothing AndAlso CashAccount.EditValue IsNot Nothing AndAlso DocCashAmount.IsHandleCreated Then
            GridControlCash.DataSource = ""
            Dim _DefaultCashAccTable As DataTable = CreatCashAccTable()
            With _DefaultCashAccTable
                Try
                    Dim R As DataRow = .NewRow
                    R("DebitCredAcc") = CashAccount.EditValue
                    R("DocAmount") = DocCashAmount.EditValue
                    R("DocCurrency") = DocCurrency.EditValue
                    R("ExchangePrice") = ExchangePrice.EditValue
                    R("BaseCurrAmount") = R("DocAmount") * R("ExchangePrice")
                    R("AccountCurr") = GetFinancialAccountsData(CashAccount.EditValue).Currency
                    .Rows.Add(R)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                GridControlCash.DataSource = _DefaultCashAccTable
            End With



        End If
    End Sub

    Private Sub DocCurrencyForReferanceAcc_EditValueChanged(sender As Object, e As EventArgs) Handles DocCurrencyForReferanceAcc.EditValueChanged


        If DocCurrencyForReferanceAcc.EditValue = _DefaultCurr Then
            ExchangePriceForReferanceAcc.ReadOnly = True
            ExchangePriceForReferanceAcc.EditValue = 1
        End If


        If DocCurrencyForReferanceAcc.EditValue <> _DefaultCurr Then
            ExchangePriceForReferanceAcc.ReadOnly = False
        End If


    End Sub


    Private Sub TexCashAmount_EditValueChanged(sender As Object, e As EventArgs)
        'CalcCashInFirstRow()
    End Sub
    Private Sub ExchangePriceForReferanceAcc_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangePriceForReferanceAcc.EditValueChanged
        'CalcCashInFirstRow()
    End Sub

    'Private Sub RepositoryColOtherAcc_Popup(sender As Object, e As EventArgs) Handles RepositoryColCashAcc.Popup
    '    Dim _AccType As String = "1"
    '    '  If Not String.IsNullOrEmpty(_AccType) Then
    '    Dim sle As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
    '    sle.Properties.View.ActiveFilterString = "[AccType]=" & _AccType
    '    '  End If
    'End Sub
    'Private Sub SearchChecksBoxAccount_Popup(sender As Object, e As EventArgs) Handles SearchChecksBoxAccount.Popup
    '    Dim _AccType As String = "2"
    '    '  If Not String.IsNullOrEmpty(_AccType) Then
    '    Dim sle As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
    '    sle.Properties.View.ActiveFilterString = "[AccType]=" & _AccType
    '    '  End If
    'End Sub

    Private Sub AccountForRefranace_EditValueChanged(sender As Object, e As EventArgs) Handles AccountForRefranace.EditValueChanged
        If AccountForRefranace.IsHandleCreated = True Then
            If DocStatus.EditValue = -1 Then
                GridView2.SetRowCellValue(0, "DebitCredAcc", GetDefaultAccounts(1, DocCurrencyForReferanceAcc.EditValue, GlobalVariables.CurrUser))
            End If
        End If
        DocCurrencyForReferanceAcc.EditValue = GetFinancialAccountsData(AccountForRefranace.EditValue).Currency
    End Sub

    'Private Function GetAccType(ByVal view As GridView, ByVal row As Integer) As Integer
    '    Dim col As GridColumn = view.Columns("AccType")
    '    Dim val As Integer = Convert.ToString(view.GetRowCellValue(row, col))
    '    Return val
    'End Function
    Private Function IsDefaultCurrency(ByVal view As GridView, ByVal row As Integer) As Boolean
        Dim _Res As Boolean
        Try
            Dim col As GridColumn = view.Columns("AccountCurr")
            Dim val As Integer = Convert.ToString(view.GetRowCellValue(row, col))
            If val = _DefaultCurr Then
                _Res = True
            Else
                _Res = False
            End If
        Catch ex As Exception
            _Res = False
        End Try

        Return _Res
    End Function
    ' disable editing  
    Private Sub GridView2_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView2.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If (view.FocusedColumn.FieldName = "ExchangePrice") AndAlso IsDefaultCurrency(view, view.FocusedRowHandle) = True Then
            e.Cancel = True
        End If
    End Sub



    Private Sub View2_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView2.ValidateRow

        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _DebitCredAcc As GridColumn = view.Columns("DebitCredAcc")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "DebitCredAcc")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الصندوق"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DebitCredAcc
                view.ShowEditor()
            End If


            Dim _AccountCurr As GridColumn = view.Columns("AccountCurr")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "AccountCurr")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال العملة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _AccountCurr
                view.ShowEditor()
            End If

            Dim _DocAmount As GridColumn = view.Columns("DocAmount")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "DocAmount")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DocAmount
                view.ShowEditor()
            End If

            Dim _ExchangePrice As GridColumn = view.Columns("ExchangePrice")
            If IsDBNull(Me.GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "ExchangePrice")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال سعر الصرف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ExchangePrice
                view.ShowEditor()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function CheckIFOutChequeExistInChecksTable(checkNo As String, accountBank As Integer) As Boolean
        If Me.DocStatus.EditValue = 1 Then
            Return False
        End If
        ' Create parameter dictionary for safe SQL execution
        Dim parameters As New Dictionary(Of String, Object)
        parameters.Add("@CheckNo", checkNo)
        parameters.Add("@AccountBank", accountBank)

        ' Use the secure ExecuteSqlQuery method with parameterized query
        Dim sql As New SQLControl
        Dim queryString As String = "SELECT COUNT(*) AS CheckCount FROM [dbo].[Checks] WHERE [CheckInOut]='OUT' AND [CheckStatus]<>0 AND [CheckStatus]<>13 And [CheckStatus]<>12 AND [CheckNo] = @CheckNo AND [AccountBank] = @AccountBank"

        ' Execute the query and check results
        Dim result = sql.ExecuteSqlQuery(queryString, parameters)

        If result.Success Then
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim count As Integer = Convert.ToInt32(sql.SQLDS.Tables(0).Rows(0)("CheckCount"))
                If count > 0 Then Return True
            End If
        Else
            ' Log the error or display a message
            XtraMessageBox.Show("Error checking if cheque exists: " & result.ErrorMessage,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return False
    End Function

    Private Function CheckIFInChequeExistInChecksTable(checkNo As String, chankBranch As String, accountBank As Integer) As Boolean
        ' Create parameter dictionary for safe SQL execution
        Dim parameters As New Dictionary(Of String, Object)
        parameters.Add("@CheckNo", checkNo)
        parameters.Add("@AccountBank", accountBank)
        parameters.Add("@AccountBank", chankBranch)

        ' Use the secure ExecuteSqlQuery method with parameterized query
        Dim sql As New SQLControl
        Dim queryString As String = "SELECT COUNT(*) AS CheckCount FROM [dbo].[Checks] WHERE [CheckNo] = @CheckNo AND [AccountBank] = @AccountBank"

        ' Execute the query and check results
        Dim result = sql.ExecuteSqlQuery(queryString, parameters)

        If result.Success Then
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim count As Integer = Convert.ToInt32(sql.SQLDS.Tables(0).Rows(0)("CheckCount"))
                Return (count > 0)
            End If
        Else
            ' Log the error or display a message
            XtraMessageBox.Show("Error checking if cheque exists: " & result.ErrorMessage,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return False
    End Function


    '    Dim sql As New SQLControl
    'Dim parameters As New Dictionary(Of String, Object)

    '' Add parameters safely
    'parameters.Add("@EmployeeID", 123)
    'parameters.Add("@StartDate", DateTime.Now.AddDays(-30))

    '' Execute the query with parameters
    'Dim result = sql.ExecuteQuery("SELECT * FROM Employees WHERE EmployeeID = @EmployeeID AND HireDate > @StartDate", parameters)

    '' Check the results
    'If result.Success Then
    '    ' Access the data in sql.SQLDS.Tables(0)
    '    Dim employees As DataTable = sql.SQLDS.Tables(0)

    '    ' Do something with the data...
    '    MessageBox.Show($"Found {result.RowCount} employees")
    'Else
    '    MessageBox.Show($"Query failed: {result.ErrorMessage}")
    'End If



    Private Sub TextMultiCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles TextMultiCurrency.EditValueChanged
        If TextMultiCurrency.Text = "True" Then
            LayoutControlItem13.Visibility = Utils.LayoutVisibility.Always
            LayoutControlItem15.Visibility = Utils.LayoutVisibility.Always
            LayoutControlItem5.Visibility = Utils.LayoutVisibility.Always
            LayoutControlItem20.Visibility = Utils.LayoutVisibility.Never
            LayoutControlItem17.Visibility = Utils.LayoutVisibility.Never
            LayoutDocCurrency.Visibility = Utils.LayoutVisibility.Never
            TabbedControlGroup1.SelectedTabPage = LayoutControlGroup2
            LayoutControlGroup2.Visibility = Utils.LayoutVisibility.Always
        Else
            LayoutControlItem13.Visibility = Utils.LayoutVisibility.Never
            LayoutControlItem15.Visibility = Utils.LayoutVisibility.Never
            LayoutControlItem5.Visibility = Utils.LayoutVisibility.Never
            LayoutControlItem20.Visibility = Utils.LayoutVisibility.Always
            LayoutControlItem17.Visibility = Utils.LayoutVisibility.Always
            LayoutDocCurrency.Visibility = Utils.LayoutVisibility.Always
            TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
            LayoutControlGroup2.Visibility = Utils.LayoutVisibility.Always
        End If
        '  LayoutControlGroup2.Visibility = Utils.LayoutVisibility.Always

    End Sub

    Private Sub DocExchangePrice_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangePrice.EditValueChanged
        InsertDefaultRecordToOtherAccountTable()
    End Sub

    Private Sub LookDocCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles DocCurrency.EditValueChanged
        If DocCurrency.IsHandleCreated Then
            If TextDocIDQuery.EditValue = -1 Then
                ExchangePrice.ReadOnly = False
                ExchangePrice.EditValue = GetExchengPrice(DocCurrency.EditValue, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
            End If

            If DocCurrency.EditValue = _DefaultCurr Then
                ExchangePrice.EditValue = 1
                ExchangePrice.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DocCashAmount.EditValueChanged

        InsertDefaultRecordToOtherAccountTable()

        If IsDBNull(DocCashAmount.EditValue) Then DocCashAmount.EditValue = 0
        If IsDBNull(DocCheqsAmount.EditValue) Then DocCheqsAmount.EditValue = 0
        TotalDocAmount.EditValue = Val(DocCashAmount.EditValue) + Val(DocCheqsAmount.EditValue)

    End Sub

    Private Sub SearchCashAccount_EditValueChanged(sender As Object, e As EventArgs)
        InsertDefaultRecordToOtherAccountTable()
    End Sub

    Private Sub CashAccount_EditValueChanged(sender As Object, e As EventArgs) Handles CashAccount.EditValueChanged
        InsertDefaultRecordToOtherAccountTable()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        DeleteThisDoc()
    End Sub
    Private Sub DeleteThisDoc()

        'If DocStatus.EditValue <> -1 Then
        '    For i = 0 To GridView5.RowCount - 1
        '        If Not IsDBNull(GridView5.GetRowCellValue(i, "TransNoInJournal")) Then
        '            If GridView5.GetRowCellValue(i, "TransNoInJournal") > 1 Then
        '                MsgBox("لا يمكن تعديل السند، يوجد حركات على الشيكات" & " " & GridView5.GetRowCellValue(i, "CheckNo"))
        '                Exit Sub
        '            End If
        '        End If
        '    Next
        'End If

        'Dim _AllowDelete As Boolean


        If DeleteDoc(DocName.EditValue, TextDocIDQuery.EditValue, Me.DocCode.Text, True) = True Then
            Me.Dispose()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

    End Sub

    Private Sub DocCheqsAmount_EditValueChanged(sender As Object, e As EventArgs) Handles DocCheqsAmount.EditValueChanged
        If IsDBNull(DocCashAmount.EditValue) Then DocCashAmount.EditValue = 0
        If IsDBNull(DocCheqsAmount.EditValue) Then DocCheqsAmount.EditValue = 0
        TotalDocAmount.EditValue = Val(DocCashAmount.EditValue) + Val(DocCheqsAmount.EditValue)
    End Sub


    Private Sub GridControlChecks_ProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles GridControlChecks.ProcessGridKey
        Try
            Dim grid = TryCast(sender, GridControl)
            Dim view = TryCast(grid.FocusedView, GridView)
            If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
                'Prevent record deletion when an in-place editor is invoked:
                If view.ActiveEditor IsNot Nothing Then
                    Return
                End If
                e.Handled = True
                If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    view.DeleteSelectedRows()
                    GridViewChecks.UpdateSummary()
                    DocCheqsAmount.EditValue = ColCheksDocAmount.SummaryText
                End If

            ElseIf e.KeyCode = Keys.Enter Then
                If GridViewChecks.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                    SendKeys.Send("{TAB}")
                End If
            ElseIf e.KeyData = Keys.Insert Then
                ' _InsertCheckData = True
                GridViewChecks.AddNewRow()
                Dim lastRowHandle = GridViewChecks.DataRowCount - 1
                If Not GridViewChecks.IsValidRowHandle(lastRowHandle) Then Return
                GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheckNo,
                                         CInt(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckNo)) + 1)


                GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheckDueDate,
                                         CDate(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckDueDate)).AddMonths(1))
                GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheksDocAmount,
                                         CInt(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheksDocAmount)))
                GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColTransNoInJournal, 1)

                If Not IsDBNull(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustBank)) Then
                    GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheckCustBank,
                                         CInt(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustBank)))
                End If
                If Not IsDBNull(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustBranch)) Then
                    GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheckCustBranch,
                         CInt(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustBranch)))
                End If
                If Not IsDBNull(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustAccountId)) Then
                    GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColCheckCustAccountId,
                                         CStr(GridViewChecks.GetRowCellValue(lastRowHandle, ColCheckCustAccountId)))
                End If

                If DocName.Text = 3 Then
                    GridViewChecks.SetRowCellValue(GridViewChecks.FocusedRowHandle, ColAccountBank,
                                         CInt(GridViewChecks.GetRowCellValue(lastRowHandle, ColAccountBank)))
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GridView5_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridViewChecks.InitNewRow
        Try
            GridViewChecks.SetRowCellValue(e.RowHandle, "AccountCurr", DocCurrencyForReferanceAcc.EditValue)
            GridViewChecks.SetRowCellValue(e.RowHandle, "ExchangePrice", ExchangePriceForReferanceAcc.EditValue)
            GridViewChecks.SetRowCellValue(e.RowHandle, "TransNoInJournal", 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextDocIDQuery_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocIDQuery.EditValueChanged


        '  ProgressBarControl1.PerformStep()
        ' ProgressBarControl1.Update()

        Dim CurrencyTable As DataTable
        CurrencyTable = GetCurrency()
        Dim _FinancialAccounts As DataTable
        _FinancialAccounts = GetFinancialAccounts(-1, -1, False, -1, -1)
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
        AccountForRefranace.Properties.DataSource = _FinancialAccounts
        RepositoryColCashAcc.DataSource = _FinancialAccounts
        SearchChecksBoxAccount.Properties.DataSource = _FinancialAccounts
        CashAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryOtherAccCurrency.DataSource = CurrencyTable
        DocCurrencyForReferanceAcc.Properties.DataSource = CurrencyTable
        RepositoryChecksCurrency.DataSource = CurrencyTable
        DocCurrency.Properties.DataSource = CurrencyTable
        Me.DocStatus.Properties.DataSource = GetDocStatus(False)
        If TextDocIDQuery.EditValue = -1 Then
            LoadDefault()
            '  ProgressBarControl1.EditValue = 0
            '  ProgressBarControl1.Update()
            Exit Sub
        End If

        ' ProgressBarControl1.PerformStep()
        ' ProgressBarControl1.Update()

        LayoutDelete.Visibility = Utils.LayoutVisibility.Always
        Dim _DocID As Integer = CInt(TextDocIDQuery.EditValue)
        Dim _DocName As Integer = CInt(DocName.EditValue)
        Dim DocData = GetDocData(_DocID, _DocName)
        Dim _CashTable As New DataTable
        Dim _CheqsTable As New DataTable
        Dim _CheqsTableFromCheks As New DataTable
        Dim _DocDataTable = GetDocDataTable(_DocName, _DocID, "Journal")
        _CashTable = _DocDataTable.SecondTable
        _CheqsTable = _DocDataTable.FirstTable
        _CheqsTableFromCheks = GetDocChecksTable(_DocName, _DocID)

        '  ProgressBarControl1.PerformStep()
        ' ProgressBarControl1.Update()

        With My.Forms.MoneyTrans
            Select Case _DocName
                Case 4, 3
                    .DocStatus.EditValue = DocData.DocStatus
                    .TextDocID.EditValue = _DocID
                    .DocName.EditValue = _DocName
                    .DocDate.DateTime = CDate(DocData.DocDate)
                    .LookCostCenter.EditValue = DocData.DocCostCenter
                    .TextDocManualNo.Text = DocData.DocManualNo
                    .LookDocSort.EditValue = DocData.DocSort
                    .ExchangePriceForReferanceAcc.Text = DocData.ExchangePrice
                    .Referance.EditValue = DocData.Referance
                    .TextDocNotes.Text = DocData.DocNotes
                    .ExchangePrice.EditValue = DocData.ExchangePrice
                    If _DocName = 3 Then RepositoryAccountBank.DataSource = GetBankAccounts(DocCurrency.EditValue)
                    .GridControlChecks.DataSource = _CheqsTableFromCheks
                    .GridControlCash.DataSource = _CashTable
                    .DocCashAmount.EditValue = _CashTable.Compute("SUM(DocAmount)", String.Empty)
                    .DocCheqsAmount.EditValue = _CheqsTable.Compute("SUM(DocAmount)", String.Empty)
                    .DocCurrency.EditValue = DocData.DocCurrency
                    .TextMultiCurrency.Text = CStr(DocData.DocMultiCurrency)
                    .DocCode.Text = DocData.DocCode
                    ._PosNo = DocData.PosNo
                    ._ShiftID = DocData.ShiftID
                    ._DocID2 = DocData.DocID2
                    .BarDeviceName.Caption = DocData.DeviceName
                    .BarInputUser.Caption = DocData.InputUser
                    .BarInputDateTime.Caption = DocData.InputDateTime
                    .SalesPerson.EditValue = DocData.SalesPerson
            End Select

            ' ProgressBarControl1.PerformStep()
            '  ProgressBarControl1.Update()

            Select Case _DocName
                Case 3
                    Me.Text = "سند صرف"
                    .AccountForRefranace.EditValue = DocData.DebitAcc
                    .TextReferanceName.Text = DocData.ReferanceName
                    RepositoryAccountBank.DataSource = GetBankAccounts(DocCurrency.EditValue)
                    If _CashTable.Rows.Count > 0 Then CashAccount.EditValue = _CashTable.Rows.Item(0).Item("DebitCredAcc")
                    If _CashTable.Rows.Count = 0 Then CashAccount.EditValue = GetDefaultAccounts(1, DocData.DocCurrency, GlobalVariables.CurrUser)
                    LayoutCheqsInAccount.Visibility = Utils.LayoutVisibility.Never

                    ColAccountBank.Visible = True
                Case 4
                    Me.Text = "سند قبض"
                    .AccountForRefranace.EditValue = DocData.CredAcc
                    .TextReferanceName.Text = DocData.ReferanceName
                    If _DocDataTable.FirstTable.Rows.Count > 0 Then SearchChecksBoxAccount.EditValue = _CheqsTable.Rows.Item(0).Item("DebitAcc")
                    If _CashTable.Rows.Count > 0 Then CashAccount.EditValue = _CashTable.Rows.Item(0).Item("DebitCredAcc")
                    If _DocDataTable.FirstTable.Rows.Count = 0 Then SearchChecksBoxAccount.EditValue = GetDefaultAccounts(2, DocData.DocCurrency, GlobalVariables.CurrUser)
                    If _CashTable.Rows.Count = 0 Then CashAccount.EditValue = GetDefaultAccounts(1, DocData.DocCurrency, GlobalVariables.CurrUser)
                    LayoutCheqsInAccount.Visibility = Utils.LayoutVisibility.Always
                    ColAccountBank.Visible = False
            End Select

            If Not IsNothing(DocData.DocTags) Then
                Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = .LayoutHeader.CustomHeaderButtons(0)
                If customHeaderButton IsNot Nothing Then
                    Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
                    customHeaderButtonTyped.Caption = DocData.DocTags
                    _DocTagsToOpen = DocData.DocTags
                End If
            Else
                DocData.DocTags = ""
                _DocTagsToOpen = DocData.DocTags
            End If

            '  ProgressBarControl1.PerformStep()
            '  ProgressBarControl1.Update()

            Select Case TextMultiCurrency.Text
                Case "True"
                Case "False"
            End Select

            TextDocManualNo.Select()
            '   LayoutProgressPar.Visibility = False
        End With
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DocDate_EditValueChanged(sender As Object, e As EventArgs) Handles DocDate.EditValueChanged

    End Sub

    Private Sub Referance_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles Referance.AddNewValue
        Dim ff As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        Dim findBox As Control = ff.Controls.Find("teFind", True)(0)
        Dim RefName As String = findBox.Text
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = RefName
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .CheckActive.Checked = True
            .PriceCategory.EditValue = 1
            ._AddNewOrSave = "AddNew"
            If Me.DocName.EditValue = 4 Then .LookRefType.EditValue = 2
            If Me.DocName.EditValue = 3 Then .LookRefType.EditValue = 1
            .TextRefName.Select()
            If .ShowDialog() <> DialogResult.OK Then

                Me.Referance.EditValue = GlobalVariables._ReferanceNoGlobal
                Me.Referance.Text = GlobalVariables._ReferanceNoGlobal

                Me.TextReferanceName.Text = GlobalVariables._ReferanceNameGlobal
                Me.Referance.Properties.DataSource = GetReferences(-1, -1, -1)
                Me.Referance.ShowPopup()
                Me.Referance.StartAutoSearch(GlobalVariables._ReferanceNameGlobal)
            End If
        End With
    End Sub

    Private Sub Referance_BeforePopup(sender As Object, e As EventArgs) Handles Referance.BeforePopup
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.Dispose()
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Saving()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs)
        DeleteThisDoc()
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("هل تريد الخروج من السند?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        AttachmentsBulkAdd.ReferanceID.EditValue = Referance.EditValue
        AttachmentsBulkAdd.SearchSystemDocName.EditValue = Me.DocName.EditValue
        AttachmentsBulkAdd.LinkDocNo.EditValue = Me.DocCode.Text
        AttachmentsBulkAdd.ReferanceID.ReadOnly = True
        AttachmentsBulkAdd.SearchAccount.ReadOnly = True
        AttachmentsBulkAdd.ShowDialog()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim F As New AttachmentDirectDisplay
        With F
            ._Filter = "Document"
            ._DocCode = Me.DocCode.Text
            ._DocName = Me.DocName.EditValue
            .ColDocAccountCode.Visible = False
            .ColAccountName.Visible = False
            .GetAttachments()
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        DeleteThisDoc()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        PrintDoc(False, DocCode.Text, "Journal", True, False)
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        PrintDoc(False, DocCode.Text, "Journal", True, False)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        My.Forms.JournalForDocument.GridControl1.DataSource =
    GetJournalForTrans(Me.DocName.EditValue, Me.TextDocID.EditValue)
        My.Forms.JournalForDocument.ShowDialog()
    End Sub

    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub DocCashAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles DocCashAmount.MouseUp
        TextEditSelectText(sender)
    End Sub

    'Private Sub RepositoryLookUpBanks_ProcessNewValue(sender As Object, e As ProcessNewValueEventArgs) Handles RepositoryLookUpBanks.ProcessNewValue
    '    If CStr(e.DisplayValue) = String.Empty Then Exit Sub
    '    Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد اضافة  البنك     : " & e.DisplayValue.ToString(), "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
    '    AccountingLists.NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(10)
    '    AccountingLists.ShowDialog()
    '    'Me.RepositoryLookUpBanks.DataSource = GetBanksTable()
    '    'Try


    '    'Catch ex As Exception
    '    '    Dim f As New AccountingLists
    '    '    With f
    '    '        .NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(10)
    '    '        If .ShowDialog <> DialogResult.OK Then
    '    '            RepositoryLookUpBanks.DataSource = GetBanksTable()
    '    '        End If
    '    '    End With
    '    'End Try


    '    'Try
    '    '    Dim sql As New SQLControl
    '    '    Dim SQLString As String
    '    '    SQLString = "insert into EmployeesDepartments (Department) values (N'" & e.DisplayValue.ToString() & "')"
    '    '    sql.SqlTrueTimeRunQuery(SQLString)
    '    '    XtraMessageBox.Show("تم اضافة  القسم ")
    '    '    Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
    '    '    e.Handled = True
    '    'Catch ex As Exception
    '    '    XtraMessageBox.Show(" خطا: لم يتم  اضافة   القسم ")
    '    '    Exit Sub
    '    'End Try
    'End Sub
    Private Sub LookUpEdit1_ProcessNewValue(ByVal sender As Object, ByVal e As _
    DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles RepositoryLookUpBanks.ProcessNewValue

        'Dim Row As DataRow
        Dim Edit As Repository.RepositoryItemLookUpEdit
        Edit = CType(sender, LookUpEdit).Properties

        '  If e.DisplayValue = Edit.NullString OrElse e.DisplayValue = String.Empty Then Exit Sub

        With New AccountingLists()
            .BankNo = 1
            .BankName = e.DisplayValue
            .GridView11.AddNewRow()
            If .ShowDialog(Me) <> DialogResult.OK Then
                MsgBox("تم اضافة البنك")
            End If
            'If .ShowDialog(Me) = DialogResult.OK Then
            '                                           e.DisplayValue = .BankName
            '                                           MsgBox(e.DisplayValue)
            '                                           ' Row = LookupTable.NewRow()
            '                                           ' Row("Name") = .ItemName
            '                                           '    RepositoryLookUpBanks.Rows.Add(Row)
            '                                       End If
            '                                       .Dispose()
        End With

        e.Handled = True
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        GridViewChecks.OptionsSelection.MultiSelect = True
        GridViewChecks.SelectAll()
        GridViewChecks.CopyToClipboard()
        GridViewChecks.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim dt As DataTable = (CType(GridViewChecks.DataSource, DataView)).Table
        If dt.Rows.Count > 0 Then
            If XtraMessageBox.Show("سيتم حذف الشيكات بالسند هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                CreatChecksAccTable()
            Else
                Exit Sub
            End If
        End If
        GridControlChecks.DataSource = GlobalVariables._ChecksTable
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim dt As DataTable = (CType(GridViewChecks.DataSource, DataView)).Table
        If dt.Rows.Count <> 0 Then
            GlobalVariables._ChecksTable = dt
            XtraMessageBox.Show("تم نسخ السند")
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        GridViewChecks.PasteFromClipboard()
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If XtraMessageBox.Show("هل تريد الخروج من السند؟", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
            Me.Close()
        End If
    End Sub

    Private Sub GridView5_ShownEditor(sender As Object, e As EventArgs) Handles GridViewChecks.ShownEditor
        'Dim view As GridView = TryCast(s, GridView)

        'Dim view As GridView = TryCast(s, GridView)
        'view.ActiveEditor.Properties.ReadOnly =
        '    GridView.FocusedColumn.FieldName = "ID" AndAlso GridView.FocusedRowHandle Mod 2 = 0


        'Dim view As ColumnView = DirectCast(sender, ColumnView)
        'view.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustBank"
        'view.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustBranch"
        'view.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustAccountId"

        '_FieldName = view.FocusedColumn.FieldName
        'Dim view2 As GridView = TryCast(sender, GridView)
        'edit = view2.ActiveEditor

        'GridView5.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustBank"
        'GridView5.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustBranch"
        'GridView5.ActiveEditor.Properties.ReadOnly = GridView5.FocusedColumn.FieldName = "CheckCustAccountId"
    End Sub
    Private Sub gridView5_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridViewChecks.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedColumn.FieldName = "CheckCustBank" Or view.FocusedColumn.FieldName = "CheckCustBranch" Or view.FocusedColumn.FieldName = "CheckCustAccountId" Then
            If Not IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccountBank")) Then
                If DocName.EditValue = 3 Then
                    e.Cancel = True
                End If
            End If
        End If
        'If view.FocusedColumn.FieldName = "StockID" Then
        '    If GridView1.GetFocusedRowCellValue("StockID") = 0 Then
        '        GridView1.FocusedColumn = colStockID
        '    End If
        'End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMaximize.ItemClick
        Me.WindowState = FormWindowState.Maximized
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub BarButtonRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonRestore.ItemClick
        Me.WindowState = FormWindowState.Normal
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Private Sub BarButtonItem12_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMinimize.ItemClick
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BarButtonMDI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMDI.ItemClick
        Dim child As Form = Nothing
        If child Is Nothing Then
            child = Me
            child.MdiParent = My.Forms.Main
            child.Show()
        Else
            child.Activate()
        End If
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMDI.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMinimize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub حذفالشيكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفالشيكToolStripMenuItem.Click
        If GridViewChecks.GetFocusedRowCellValue("TransNoInJournal") > 1 Then
            MsgBoxShowError(" خطا: لا يمكن الحذف،  بسبب وجود حركات على الشيك ")
        Else
            SendKeys.Send("{Delete}")

            'Dim grid = TryCast(sender, GridControl)
            'Dim view = TryCast(grid.FocusedView, GridView)
            'If View.ActiveEditor IsNot Nothing Then
            '    Return
            'End If
            'If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            '    View.DeleteSelectedRows()
            '    GridView5.UpdateSummary()
            '    DocCheqsAmount.EditValue = ColCheksDocAmount.SummaryText
            'End If


        End If

    End Sub

    Private Sub كشفحركةللشيكToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحركةللشيكToolStripMenuItem.Click
        Try
            Dim _CheckCode As String = GridViewChecks.GetFocusedRowCellValue("CheckCode")
            Dim _CheckNo As String = GridViewChecks.GetFocusedRowCellValue("CheckNo")
            My.Forms.CheksTrans.TextCheckCode.Text = _CheckCode
            My.Forms.CheksTrans.CheckNo.Text = _CheckNo
            My.Forms.CheksTrans.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RepositoryLookUpBanks_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryLookUpBanks.BeforePopup

    End Sub

    Private Sub RepositoryLookUpBanks_AutoSearchComplete(sender As Object, e As LookUpEditAutoSearchCompleteEventArgs) Handles RepositoryLookUpBanks.AutoSearchComplete
        'Me.RepositoryLookUpBanks.DataSource = GetBanksTable()
    End Sub
    Private Function CheckIfFleetExist() As Boolean
        Dim _result As Boolean
        If Referance.Text <> "" Then
            Dim fleetepository As New FleetRepository()
            _result = fleetepository.CheckIfFleetExist(Referance.EditValue)
        End If
        Return _result
    End Function
    Private Sub ChargeFleet()
        If Referance.Text <> "" Then
            Dim fleetepository As New FleetRepository()
            Dim fleet As Fleet = fleetepository.GetFleetByFleetCode(Referance.EditValue, 1)
            If fleet.Prepaid = True Then
                If XtraMessageBox.Show(" الزبون دفع مسبق ورصيده الحالي " & CInt(fleet.Available_amount) & " هل تريد شحن الرصيد    ", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    Dim form As New ChargeFleet(fleet.ID)
                    form.txtAmount.EditValue = TotalDocAmount.EditValue
                    form.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Sub CheckIfFleetBlocked()
        If Referance.Text <> "" Then
            Dim fleetepository As New FleetRepository()
            Dim fleet As Fleet = fleetepository.GetFleetByFleetCode(Referance.EditValue, 1)
            If fleet.Status = 1 Then
                If XtraMessageBox.Show(" الزبون موقوف " & " هل تريد تفعيله    ", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    fleetepository.ActiveFleet(fleet.ID)
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim f As New PaidVouchers
        With f
            .LookReferences.EditValue = Me.Referance.EditValue
            .txtPaidByDocNo.EditValue = Me.TextDocID.EditValue
            .txtDocName.EditValue = Me.DocName.EditValue
            .txtDocAmount.EditValue = Me.TotalDocAmount.EditValue
            .ShowDialog()
        End With
    End Sub

    Private Sub TextDocManualNo_Leave(sender As Object, e As EventArgs) Handles TextDocManualNo.Leave
        If String.IsNullOrEmpty(Me.TextDocManualNo.Text) Or TextDocManualNo.Text = "0" Or TextDocManualNo.Text = "  " Then Exit Sub
        Dim _DocID As Integer = CheckIfDocManualExisit(Me.DocName.EditValue, Me.TextDocManualNo.Text)
        If _DocID > 0 And _DocID <> Me.TextDocID.EditValue Then
            If XtraMessageBox.Show("رقم السند اليدوي موجود مسبقا في  " & Me.DocName.Text & "  رقم " & _DocID & " هل تريد الاستمرار؟ ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, DefaultBoolean.Default) = DialogResult.No Then
                Me.TextDocManualNo.Text = ""
                Me.TextDocManualNo.Focus()
            End If
        End If
    End Sub

    Private Sub TextDocManualNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocManualNo.EditValueChanged

    End Sub

    Private Sub LayoutHeader_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles LayoutHeader.CustomButtonClick
        Try
            Dim F As New TagsNames
            With F
                If .ShowDialog() <> DialogResult.OK Then
                    If GlobalVariables._PublicDocumentTags <> "" Then
                        e.Button.Properties.Caption = GlobalVariables._PublicDocumentTags
                        _DocTagsToOpen = GlobalVariables._PublicDocumentTags
                    Else
                        e.Button.Properties.Caption = e.Button.Properties.Caption
                        _DocTagsToOpen = e.Button.Properties.Caption
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class
