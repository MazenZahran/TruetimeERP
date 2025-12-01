Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.Data.Filtering
Imports DevExpress.LookAndFeel
Imports DevExpress.Xpf.Core
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports GMap.NET


Public Class Journal

    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _ValidateRow As Boolean
    Public _DocTagsToOpen As String
    Private Sub Journal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        LoadSettings()
        DateDocDate.Select()
        RepositoryItemLookUpEdit1.DataSource = GetNewAccounts()
        ColBaseCurrAmount.Caption = " المبلغ " & GetCurrencyCode(GetDefaultCurrency())
        'RepositoryItemLookUpEdit1.Properties.ShowDropDown = ShowDropDown.Never
        RepositoryAccount.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryAccountCurr.DataSource = GetCurrency()
        RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
        DocStatus.Properties.DataSource = GetDocStatusForInputDocument()
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            Saving()
        ElseIf e.KeyCode = Keys.F4 Then
            ' ShowPrint()
        ElseIf e.KeyCode = Keys.PageUp Then
            'GoToUp()
        ElseIf e.KeyCode = Keys.PageDown Then
            'GoToDown()
            'ElseIf e.KeyCode = Keys.Enter Then
            '    If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
            '        SendKeys.Send("{TAB}")
            '    End If
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
        ElseIf (e.KeyCode) = 187 Then
            GridView1.SetFocusedRowCellValue("DebitAmount", 0)
            GridView1.SetFocusedRowCellValue("CreditAmount", 0)
            BalanceJournal()
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            DocNote.Focus()
            'ElseIf e.KeyCode = Keys.F10 Then
            '    AccountsSearchMenue.ShowDialog()
            '    If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
            '        _FieldName = "AccountNew"
            '        GridView1.SetFocusedRowCellValue("AccountNew", GlobalVariables._TempItemNo)
            '        Edit_EditValueChanged(sender, e)
            '        GlobalVariables._TempItemNo = 0
            '    Else
            '        Dim _String As String = "0"
            '        Try
            '            If Not IsNothing(GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "AccountNew")) Then
            '                _String = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "AccountNew").ToString()
            '            End If
            '        Catch ex As Exception
            '            _String = "0"
            '        End Try
            '        If _String = "0" Then
            '            GridView1.AddNewRow()
            '            _FieldName = "AccountNew"
            '            AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
            '            AddHandler RepositoryItemLookUpEdit1.EditValueChanged, AddressOf RepositoryItemLookUpEdit1_EditValueChanged
            '        Else
            '            _FieldName = "AccountNew"
            '            GridView1.SetFocusedRowCellValue("AccountNew", GlobalVariables._TempItemNo)
            '            AddHandler RepositoryItemLookUpEdit1.EditValueChanged, AddressOf RepositoryItemLookUpEdit1_EditValueChanged
            '        End If
            '        GlobalVariables._TempItemNo = 0
            '    End If

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
                Me.RepositoryCostCenter2.DataSource = GetCostCenter(False)
            Else
                ColDocCostCenter.Visible = False
            End If
        Catch ex As Exception
            ColDocCostCenter.Visible = False
        End Try
    End Sub
    'Private Function USCanada(ByVal view As GridView, ByVal row As Integer) As Boolean
    '    Dim col As GridColumn = view.Columns("RepositoryAccount")
    '    Dim val As String = Convert.ToString(view.GetRowCellValue(row, col))
    '    Return (val = "USA" OrElse val = "Canada")
    'End Function
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
    Private Function EmptyJournal() As DataTable
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
            .Columns.Add("TarteebID", GetType(Integer))
            .Columns.Add("DocTags", GetType(String))
            .Columns.Add("CheckCode", GetType(String))
        End With
        DocCode.Text = CreateRandomCode()
        Return JournalTable

    End Function

    Private Sub TextDocIDQuery_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocIDQuery.EditValueChanged
        Try
            'WaitScreen1.Show()
            SplashScreenManager2.ShowWaitForm()
            Me.DocStatus.EditValue = -1
            If TextDocIDQuery.EditValue = -1 Then
                GridJournal.DataSource = EmptyJournal()
                Me.DateDocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
                Me.TextDocID.Text = Val(GetDocNo(5, True))
                Me.DocStatus.EditValue = -1
            Else
                Dim _DocData = GetDocData(TextDocIDQuery.EditValue, 5)
                Me.TextDocID.EditValue = _DocData.DocID
                Me.DocStatus.EditValue = _DocData.DocStatus
                If _DocData.DocID = -1 Then
                    GridJournal.DataSource = EmptyJournal()
                    Me.DateDocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
                    Me.TextDocID.Text = Val(GetDocNo(5, True))
                    Me.DocStatus.EditValue = -1
                    'TextDocIDQuery.EditValue = TextDocIDQuery.OldEditValue
                End If
                If _DocData.DocStatus = 0 Then
                    Me.DocStatus.EditValue = 0
                    'GridJournal.DataSource = EmptyJournal()
                    GridJournal.Enabled = False
                    ' SimpleButtonSave.Enabled = False
                    'MsgBox("لا يوجد بيانات")
                    Exit Sub
                Else
                    GridJournal.Enabled = True
                    ' SimpleButtonSave.Enabled = True
                End If
                DateDocDate.DateTime = _DocData.DocDate
                TextDocManualNo.Text = _DocData.DocManualNo
                DocStatus.EditValue = _DocData.DocStatus
                DocNote.Text = _DocData.DocNotes
                If CheckIfDocInJournal(DocName.Text, TextDocIDQuery.Text) = True Then
                    Dim SqlString As String
                    Dim Sql As New SQLControl
                    SqlString = "   Select DocID,DocDate,DocName,DocStatus,DocCostCenter,Account,
  DebitAmount,CreditAmount,AccountCurr,BaseCurrAmount,
  DocNoteByAccount,DocAmount,ExchangePrice,DocSort,
  Referance,DocManualNo,DocCode,Case when Referance ='0' or Referance='' then Account Else Referance End as AccountNew,DocCurrency,OrderID,TarteebID ,DocTags,IsNull(CheckCode,'') as CheckCode
  From
  (Select DocID,DocDate,DocName,DocStatus,DocCostCenter,CheckCode,
                                Case when CredAcc='0' then  DebitAcc else CredAcc end as Account ,
                                Case when CredAcc='0' then  DocAmount else 0  End  as DebitAmount ,
                                Case when DebitAcc='0' then  DocAmount else 0  End  as CreditAmount ,
                                Case when CredAcc='0' then  F.Currency  else FF.Currency end as AccountCurr ,
                                Case when CredAcc='0' then  BaseCurrAmount else -1*BaseCurrAmount end as     BaseCurrAmount ,
                                DocNoteByAccount,DocAmount,ExchangePrice,DocSort,Referance,DocManualNo,DocCode,DocCurrency,OrderID,IsNull(TarteebID,0)  as TarteebID,IsNull(DocTags,'') as DocTags
                                From Journal J
								left Join FinancialAccounts F on J.DebitAcc=F.AccNo 
								left Join FinancialAccounts FF on J.CredAcc=FF.AccNo 
                                where DocID=" & TextDocIDQuery.Text & " And DocName=5  ) A order by OrderID "
                    Sql.SqlTrueAccountingRunQuery(SqlString)
                    GridJournal.DataSource = Sql.SQLDS.Tables(0)

                    If Not IsNothing(_DocData.DocTags) Then
                        Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = LayoutControlGroup1.CustomHeaderButtons(0)
                        If customHeaderButton IsNot Nothing Then
                            Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
                            customHeaderButtonTyped.Caption = _DocData.DocTags
                            _DocTagsToOpen = _DocData.DocTags
                        End If
                    Else
                        _DocData.DocTags = ""
                        _DocTagsToOpen = _DocData.DocTags
                    End If

                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        Finally
            SplashScreenManager2.CloseWaitForm()
        End Try


    End Sub

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
                '_ValidateRow = False
                GridView1.UpdateCurrentRow()
                '_ValidateRow = True
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
                            Dim _ExchRate = GetExchengPrice(_CurrencyID, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
                            .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), _ExchRate)
                            If _CurrencyID = _DefaultCurr Then
                                .SetRowCellValue(.FocusedRowHandle, .Columns("ExchangePrice"), 1)
                            End If
                            ' في تاريخ 08/04/2025 تم ازالة تفعيل ال if 
                            '  If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
                            .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            ' End If
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                End Select

                ' GridViewJournal.UpdateCurrentRow()
                GlobalVariables._TempItemNo = 0
            End If


        End With

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Saving()
    End Sub
    Private Sub gridView1_HiddenEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.HiddenEditor
        'GridView1.UpdateCurrentRow()
    End Sub

    Private Function CheckIFBalance() As Boolean
        Dim balanced As Boolean
        Dim domAmount As Decimal = 0
        Dim baseAmount As Decimal = 0
        With GridView1 ' 
            For i = 0 To .RowCount - 1

            Next
        End With
        Return balanced
    End Function
    Private Sub Saving()
        GridView1.UpdateCurrentRow()
        GridView1.PostEditor()
        GridView1.UpdateTotalSummary()
        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()

        If Me.GridView1.GetRowCellValue(0, "AccountNew") = 0 Then
            XtraMessageBox.Show("السند فارغ")
            Exit Sub
        End If

        GridView1.CloseEditor()
        If GridView1.UpdateCurrentRow() Then

            If DocCode.Text = "" Or String.IsNullOrEmpty(DocCode.Text) Then DocCode.Text = CreateRandomCode()

            If ColDebitAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة المدين صفر") : Exit Sub
            If ColCreditAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة الدائن صفر") : Exit Sub

            If CInt(ColBaseCurrAmount.SummaryText) <> 0 Then
                MsgBox("السند غير مطابق")
                Exit Sub
            End If

            If DateDocDate.DateTime > Today Then
                If XtraMessageBox.Show("تاريخ السند اكبر من تاريخ اليوم، هل تريد الاستمرار", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                    Exit Sub
                End If
            End If

            Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

            Dim _DocLogName, _LogDetails As String

            Dim _CheckIfDocInJournal As Boolean
            If DocStatus.EditValue = -1 Then
                _CheckIfDocInJournal = False
                _DocLogName = "Insert"
                _LogDetails = "Insert Voucher "
            Else
                _CheckIfDocInJournal = CheckIfDocInJournal(DocName.Text, TextDocIDQuery.Text)
                _DocLogName = "Update"
                _LogDetails = "Update Voucher "
            End If

            Dim _AskBeforeSave As String = "0"
            Select Case _CheckIfDocInJournal
                Case True
                    _AskBeforeSave = "هل تريد تعديل السند"
                Case False
                    _AskBeforeSave = "هل تريد حفظ السند"
            End Select
            Dim _DocTags As String = _DocTagsToOpen


            If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then

                SplashScreenManager2.ShowWaitForm()
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
                        .Columns.Add("TarteebID", GetType(Integer))
                        .Columns.Add("CheckCode", GetType(String))
                        .Columns.Add("DebitCreditAmount", GetType(Decimal))
                    End With

                    With GridView1 ' 
                        For i = 0 To .RowCount - 1
                            If Not String.IsNullOrEmpty(.GetRowCellValue(i, "BaseCurrAmount")) Then
                                If (.GetRowCellValue(i, "BaseCurrAmount")) = 0 Then
                                    SplashScreenManager2.CloseWaitForm()
                                    Me.GridJournal.Focus()
                                    .FocusedRowHandle = i
                                    MsgBoxShowError(" يوجد حسابات بدون قيمة مالية الرجاء مراجعة السطر ")
                                    Exit Sub
                                End If
                                If (.GetRowCellValue(i, "BaseCurrAmount")) <> 0 Then
                                    Dim _Referance As String = "0"
                                    Try
                                        _Referance = .GetRowCellValue(i, "Referance")
                                    Catch ex As Exception
                                        _Referance = "0"
                                    End Try
                                    Dim R As DataRow = JournalTable.NewRow
                                    R("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                                    R("DocName") = DocName.EditValue
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
                                    R("BaseAmount") = GetBaseAmount(.GetRowCellValue(i, "AccountCurr"), (.GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")), .GetRowCellValue(i, "DocCurrency"), Me.DateDocDate.DateTime, .GetRowCellValue(i, "ExchangePrice"))
                                    R("DocManualNo") = TextDocManualNo.Text
                                    R("InputUser") = GlobalVariables.CurrUser
                                    R("InputDateTime") = _Now
                                    R("DocNotes") = Me.DocNote.Text
                                    R("Referance") = _Referance
                                    R("ReferanceName") = .GetRowCellDisplayText(i, "Referance")
                                    R("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                                    R("OrderID") = i
                                    If CheckNumberIsNullOrNothing(.GetRowCellValue(i, "TarteebID")) = 0 Then
                                        R("TarteebID") = 0
                                    Else
                                        R("TarteebID") = .GetRowCellValue(i, "TarteebID")
                                    End If
                                    R("CheckCode") = .GetRowCellValue(i, "CheckCode")
                                    If R("CredAcc") = 0 Then R("DebitCreditAmount") = R("DocAmount") * R("ExchangePrice") Else R("DebitCreditAmount") = -1 * R("DocAmount") * R("ExchangePrice")
                                    JournalTable.Rows.Add(R)
                                End If
                            End If
                        Next
                    End With

                    If IsDebitCreditAmountBalanced(JournalTable) = False Then
                        MsgBoxShowError(" القيد غير متوازن ")
                        SplashScreenManager2.CloseWaitForm()
                        Exit Sub
                    End If

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
                        SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],DocCostCenter,[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID,TarteebID,DocTags,CheckCode) 
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
                                      N'" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & row("InputUser").ToString & "',
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & DocCode.Text & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                        " & row("OrderID").ToString & ",
                                        " & row("TarteebID").ToString & ",
                                        N'" & _DocTags & "',
                                        N'" & row("CheckCode").ToString & "'
                                            )"
                        If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                            SplashScreenManager2.CloseWaitForm()
                            MsgBox("خطا بحفظ السند")
                            DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)

                            Exit Sub
                        End If
                    Next row


                    If _CheckIfDocInJournal = True Then
                        If DeleteFromJournal(DocName.Text, _DocID) = False Then
                            SplashScreenManager2.CloseWaitForm()
                            XtraMessageBox.Show("خطا بعملية الحفظ")
                            DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)

                            Exit Sub
                        End If
                    End If
                    If InsertFromTempToJournal(DocName.Text, _DocID) = False Then
                        XtraMessageBox.Show("خطا بعملية الحفظ")
                        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                        SplashScreenManager2.CloseWaitForm()
                        Exit Sub
                    Else
                    End If


                    'CoptToClip(JournalTable)
                    TextDocManualNo.EditValue = 0
                    DateDocDate.Text = My.Forms.Main.BarEditDate.EditValue
                    TextDocManualNo.Text = ""
                    _DocTagsToOpen = ""
                    ' GridJournal.DataSource = ""
                    '  EmptyJournal()
                    '  Me.TextDocID.Text = Val(GetDocNo(5)) + 1
                    ' TextDocIDQuery.Text = Me.TextDocID.Text
                    '  TexCashAmount.Text = "0"
                    SplashScreenManager2.CloseWaitForm()
                    'XtraMessageBox.Show("تم حفظ البيانات", "", MessageBoxButtons.OK)
                    DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                    CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, _DocLogName, _LogDetails, _Now)

                    If GlobalVariables._ShowActionMenueAfterSaveDocuments = True Then
                        Dim F As New SavePrintPostDocument
                        With F
                            .TextDocCode.Text = Me.DocCode.Text
                            .TextDocData.Text = "Journal"
                            If .ShowDialog() <> DialogResult.OK Then
                                Me.Dispose()
                            End If
                        End With
                    End If


                    '  If TextOpenFrom.Text = MoneyTransList.Name Then
                    'Me.Dispose()
                    ' End If

                    DocCode.Text = CreateRandomCode()

                Catch ex As Exception
                    XtraMessageBox.Show(ex.ToString)
                    SplashScreenManager2.CloseWaitForm()
                Finally
                    'SplashScreenManager2.CloseWaitForm()
                End Try

            End If
        Else
            XtraMessageBox.Show("خطا، يجب اكمال تعبئة السند")
            Exit Sub
        End If



    End Sub

    Private Function IsDebitCreditAmountBalanced(ByVal journalTable As DataTable) As Boolean
        Dim total As Decimal = 0

        For Each row As DataRow In journalTable.Rows
            If Not IsDBNull(row("DebitCreditAmount")) Then
                total += Convert.ToDecimal(row("DebitCreditAmount"))
            End If
        Next

        Return Math.Abs(total) < 0.01
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

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButtonSave.Click
        Saving()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Me.Dispose()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        GridJournal.ShowPrintPreview()
    End Sub

    Private Sub DocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles DocStatus.EditValueChanged
        Select Case Me.DocStatus.EditValue
            Case -1
                BarButtonItemDelete.Enabled = False
                BarSubItemPrint.Enabled = False
                SimpleButtonSave.Enabled = True
                Me.Text = " سند قيد جديد "
                Me.DocStatus.BackColor = DXSkinColors.FillColors.Success
                Me.ResetBackColor()
            Case 0
                BarButtonItemDelete.Enabled = False
                BarSubItemPrint.Enabled = True
                SimpleButtonSave.Enabled = False
                Me.Text = " سند قيد محذوف " & "(" & Me.TextDocID.Text & ")"
                DocStatus.BackColor = DXSkinColors.FillColors.Danger
                Me.BackColor = DXSkinColors.FillColors.Danger
            Case 3, 4
                Me.DocStatus.BackColor = Color.SlateGray
                LayoutControlItem10.Enabled = False
                LayoutControlItem16.Enabled = False
                BarButtonItemDelete.Enabled = True
                BarSubItemPrint.Enabled = True
                SimpleButtonSave.Enabled = False
                Me.Text = " سند قيد مرحل " & "(" & Me.TextDocID.Text & ")"
                DocStatus.BackColor = DXSkinColors.FillColors.Danger
                'Me.GridJournal.Enabled = False
                Me.ResetBackColor()
            Case 1
                BarButtonItemDelete.Enabled = True
                BarSubItemPrint.Enabled = True
                SimpleButtonSave.Enabled = True
                Me.Text = " سند قيد محفوظ " & "(" & Me.TextDocID.Text & ")"
                DocStatus.ResetBackColor()
                Me.ResetBackColor()
        End Select
    End Sub



    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs)
        PrintDocument()
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        PrintDoc(False, DocCode.Text, "Journal", True, False)
        '  PrintDocument()
    End Sub
    Private Sub PrintDocument()
        'GridJournal.ShowPrintPreview()
        '  Me.GridJournal.Size = New Size(400, 400)
        Dim _Report As New XtraReportJournal
        With _Report
            '.PrintableComponentContainer1.PrintableComponent = GridJournal
            '.PrintableComponentContainer1.Visible = True
            .PrintingSystem.ShowMarginsWarning = False
            Dim CompanyData = GetCompanyData()
            .XrLabelCompanyName.Text = CompanyData.CompanyName
            .XrLabelAdress.Text = " العنوان: " & CompanyData.CompanyAddress
            .XrLabelMobile.Text = " موبايل " & " : " & CompanyData.CompanyMobile
            .XrLabelPhone.Text = " هاتف " & " : " & CompanyData.CompanyPhone
            .XrLabelVat.Text = " مشتغل مرخص " & " : " & CompanyData.CompanyVAT
            .XrLabelJournalID.Text = Me.TextDocID.Text
            .XrLabelNotes.Text = " سند رقم : " & DocNote.Text
            .XrLabelDate.Text = Me.DateDocDate.DateTime
            .Parameters("DocID").Value = Me.TextDocID.Text
            Try
                Dim cn As SqlConnection
                cn = New SqlConnection
                cn.ConnectionString = My.Settings.TrueTimeConnectionString
                Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                .XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception
            End Try
            .ShowPreview()
        End With
    End Sub


    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Journal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Dispose()
    End Sub

    Private Function GetNewAccounts() As DataTable
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select RefNo,AccNo,AccName,AccType,Currency,Code As CurrCode From (
Select CONVERT(NVARCHAR(20), RefNo) as RefNo ,RefAccID  as [AccNo],RefName as [AccName], 'Ref' As AccType,F.Currency as  Currency
from Referencess R Left Join FinancialAccounts F on F.AccNo=R.RefAccID 
Union
SELECT CONVERT(NVARCHAR(20), [AccNo]) as RefNo, [AccNo] ,[AccName], 'Acc' As AccType,Currency
FROM [dbo].[FinancialAccounts] Where IsMain =0 
) A
Left Join 
(Select CurrID,Code from Currency ) B
on A.Currency=B.CurrID
order by RefNo"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Return Sql.SQLDS.Tables(0)
    End Function

    Private Sub RepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.EditValueChanged
        Try
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
            Dim _ExchRate = GetExchengPrice(_Currency, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
            GridView1.SetFocusedRowCellValue("ExchangePrice", _ExchRate)
            If _Currency = _DefaultCurr Then
                GridView1.SetFocusedRowCellValue("ExchangePrice", 1)
            End If
            GridView1.SetFocusedRowCellValue("DocCurrency", _Currency)
            GridView1.FocusedColumn = ColDebitAmount
            If IsDBNull(GridView1.GetFocusedRowCellValue("DebitAmount")) And IsDBNull(GridView1.GetFocusedRowCellValue("CreditAmount")) Then
                BalanceJournal()
            End If
        Catch ex As Exception

        End Try



        '  AccBalance

        'MsgBox(GridView1.DataRowCount)
    End Sub
    Private Sub BalanceJournal()
        Try
            Dim _result As Decimal
            Dim _currencyprice As Decimal
            _currencyprice = GridView1.GetFocusedRowCellValue("ExchangePrice")
            _result = ColBaseCurrAmount.SummaryText
            If _result > 0 Then
                GridView1.SetFocusedRowCellValue("CreditAmount", ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
            If _result < 0 Then
                GridView1.SetFocusedRowCellValue("DebitAmount", -1 * ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
        Catch ex As Exception
            ' GridView1.SetFocusedRowCellValue("CreditAmount", 0)
        End Try
    End Sub

    Private Sub BalanceJournal2()
        Try
            Dim _result As Decimal
            Dim _currencyprice As Decimal
            _currencyprice = GridView1.GetFocusedRowCellValue("ExchangePrice")
            _result = ColBaseCurrAmount.SummaryText
            If _result > 0 Then
                GridView1.SetFocusedRowCellValue("CreditAmount", ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
            If _result < 0 Then
                GridView1.SetFocusedRowCellValue("DebitAmount", -1 * ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
        Catch ex As Exception
            ' GridView1.SetFocusedRowCellValue("CreditAmount", 0)
        End Try
    End Sub
    Private Sub BalanceJournal3()
        Try
            Dim _result As Decimal
            Dim _currencyprice As Decimal
            _currencyprice = GridView1.GetFocusedRowCellValue("ExchangePrice")
            _result = ColBaseCurrAmount.SummaryText
            If _result > 0 Then
                GridView1.SetFocusedRowCellValue("CreditAmount", ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
            If _result < 0 Then
                GridView1.SetFocusedRowCellValue("DebitAmount", -1 * ColBaseCurrAmount.SummaryText / _currencyprice)
                GridView1.SetFocusedRowCellValue("BaseCurrAmount", -1 * ColBaseCurrAmount.SummaryText)
            End If
        Catch ex As Exception
            ' GridView1.SetFocusedRowCellValue("CreditAmount", 0)
        End Try
    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow
        'Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantity", 0)
        ''  Me.GridView1.SetRowCellValue(e.RowHandle, "StockItemPrice", 0)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "DocAmount", 0)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantityByMainUnit", 0)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "StockPrice", 0)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "StockDiscount", 0)
        'Me.GridView1.SetRowCellValue(e.RowHandle, "VoucherDiscount", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "TarteebID", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "CheckCode", 0)

        ' _InsertCheckData = True

        Dim lastRowHandle = GridView1.DataRowCount - 1
        If Not IsDBNull(GridView1.GetRowCellValue(lastRowHandle, ColDocCostCenter)) Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ColDocCostCenter,
                                 CInt(GridView1.GetRowCellValue(lastRowHandle, ColDocCostCenter)))
        End If


    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCopyDocument.ItemClick
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count <> 0 Then
            GlobalVariables._ItemsTable = dt
            XtraMessageBox.Show("تم نسخ السند")
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count > 0 Then
            If XtraMessageBox.Show("سيتم حذف البيانات، تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                EmptyJournal()
            Else
                Exit Sub
            End If
        End If
        GridJournal.DataSource = GlobalVariables._ItemsTable
        For i = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "TarteebID", 0)
        Next
    End Sub
    Private Sub GridView1_InvalidRowException(ByVal sender As Object,
ByVal e As DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs) _
Handles GridView1.InvalidRowException
        'Suppress displaying the error message box
        e.ExceptionMode = ExceptionMode.NoAction
        'MessageBox.Show(e.ErrorText)
    End Sub


    Private Sub View1_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim isValid As Boolean = True

        Try
            ' Validate "AccountNew" field
            Dim accountNew As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccountNew")
            If IsDBNull(accountNew) OrElse (TypeOf accountNew Is String AndAlso String.IsNullOrWhiteSpace(CStr(accountNew))) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الحساب"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = View.Columns("AccountNew")
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
                Return
            End If

            ' Validate "ExchangePrice" field
            Dim exchangePrice As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ExchangePrice")
            If IsDBNull(exchangePrice) OrElse (TypeOf exchangePrice Is String AndAlso String.IsNullOrWhiteSpace(CStr(exchangePrice))) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال سعر الصرف"
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = View.Columns("ExchangePrice")
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
                Return
            End If

            ' Validate "DebitAmount" and "CreditAmount" fields
            Dim debitAmount As Decimal = 0
            Dim creditAmount As Decimal = 0

            ' Safely convert debit amount
            Dim debitObj As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DebitAmount")
            If Not IsDBNull(debitObj) Then
                Try
                    debitAmount = Convert.ToDecimal(debitObj)
                Catch ex As Exception
                    e.Valid = False
                    e.ErrorText = "خطأ في قيمة المدين"
                    View.FocusedRowHandle = e.RowHandle
                    View.FocusedColumn = View.Columns("DebitAmount")
                    View.ShowEditor()
                    SimpleButtonSave.Enabled = False
                    Return
                End Try
            End If

            ' Safely convert credit amount
            Dim creditObj As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CreditAmount")
            If Not IsDBNull(creditObj) Then
                Try
                    creditAmount = Convert.ToDecimal(creditObj)
                Catch ex As Exception
                    e.Valid = False
                    e.ErrorText = "خطأ في قيمة الدائن"
                    View.FocusedRowHandle = e.RowHandle
                    View.FocusedColumn = View.Columns("CreditAmount")
                    View.ShowEditor()
                    SimpleButtonSave.Enabled = False
                    Return
                End Try
            End If

            '' Check if both debit and credit are zero
            'If debitAmount = 0 AndAlso creditAmount = 0 Then
            '    ' e.Valid = False
            '    '   View.SetColumnError(View.Columns("DebitAmount"), "يجب ادخال المبلغ")
            '    '  e.ErrorText = "خطأ، يجب ادخال المبلغ"
            '    View.FocusedRowHandle = e.RowHandle
            '    View.FocusedColumn = View.Columns("DebitAmount")
            '    '  View.ShowEditor()
            '    ' SimpleButtonSave.Enabled = False
            '    Return
            'End If

            ' Validate "Account" field
            Dim account As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account")
            If IsDBNull(account) OrElse (TypeOf account Is String AndAlso String.IsNullOrWhiteSpace(CStr(account))) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الحساب"
                View.SetColumnError(View.Columns("AccountNew"), "الرجاء اعادة اختيار الحساب")
                View.FocusedRowHandle = e.RowHandle
                View.FocusedColumn = View.Columns("AccountNew")
                View.ShowEditor()
                SimpleButtonSave.Enabled = False
                Return
            End If

            ' Validate "Cost Center" if required
            If GlobalVariables._CostCenterRequired Then
                Dim accountNumber As String = ""
                If Not IsDBNull(account) Then accountNumber = account.ToString()

                Dim accountObj As New FinancialAccount()
                If accountObj.GetAccountData(accountNumber) AndAlso accountObj.NeedCostCenter Then
                    Dim costCenter As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCostCenter")
                    Dim costCenterStr As String = ""

                    If Not IsDBNull(costCenter) Then costCenterStr = costCenter.ToString()

                    If String.IsNullOrWhiteSpace(costCenterStr) OrElse costCenterStr = "0" Then
                        XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        e.Valid = False
                        View.SetColumnError(View.Columns("DocCostCenter"), "خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                        View.FocusedRowHandle = e.RowHandle
                        View.FocusedColumn = View.Columns("DocCostCenter")
                        View.ShowEditor()
                        SimpleButtonSave.Enabled = False
                        Return
                    End If
                End If
            End If

            ' If we've made it this far, all validations have passed
            e.Valid = True
            View.ClearColumnErrors()
            SimpleButtonSave.Enabled = True

        Catch ex As Exception
            ' Log or display the exception
            XtraMessageBox.Show("خطأ أثناء التحقق من صحة البيانات: " & ex.Message)
            e.Valid = False
            SimpleButtonSave.Enabled = False
        End Try
    End Sub



    'Private Sub View1_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow
    '    'If _ValidateRow = False Then Exit Sub
    '    Dim View As GridView = CType(sender, GridView)
    '    Try
    '        ' Dim view As ColumnView = TryCast(sender, ColumnView)
    '        Dim _AccountNew As GridColumn = View.Columns("AccountNew")
    '        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccountNew")) = True Then
    '            e.Valid = False
    '            e.ErrorText = "يجب ادخال الحساب"
    '            View.FocusedRowHandle = e.RowHandle
    '            View.FocusedColumn = _AccountNew
    '            View.ShowEditor()
    '            SimpleButtonSave.Enabled = False
    '        End If

    '        Dim _ExchangePrice As GridColumn = View.Columns("ExchangePrice")
    '        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ExchangePrice")) = True Then
    '            e.Valid = False
    '            e.ErrorText = "يجب ادخال سعر الصرف"
    '            View.FocusedRowHandle = e.RowHandle
    '            View.FocusedColumn = _ExchangePrice
    '            View.ShowEditor()
    '            SimpleButtonSave.Enabled = False
    '        End If


    '        Dim _DebitAmount As GridColumn = View.Columns("DebitAmount")
    '        Dim _CreditAmount As GridColumn = View.Columns("CreditAmount")
    '        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DebitAmount")) = True AndAlso
    '            IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CreditAmount")) = True Then
    '            e.Valid = False
    '            e.ErrorText = "خطأ، يجب ادخال المبلغ"
    '            View.FocusedRowHandle = e.RowHandle
    '            View.FocusedColumn = _DebitAmount
    '            View.ShowEditor()
    '            SimpleButtonSave.Enabled = False
    '        End If
    '        If Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DebitAmount") = 0 AndAlso
    '        Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CreditAmount") = 0 Then
    '            e.Valid = False
    '            View.SetColumnError(_DebitAmount, "يجب ادخال المبلغ ")
    '            e.ErrorText = "خطأ، يجب ادخال المبلغ"
    '            View.FocusedRowHandle = e.RowHandle
    '            View.FocusedColumn = _DebitAmount
    '            View.ShowEditor()
    '            SimpleButtonSave.Enabled = False
    '        End If

    '        Dim _Account As GridColumn = View.Columns("Account")
    '        Dim _value = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account")
    '        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account")) = True Then
    '            e.Valid = False
    '            e.ErrorText = "يجب ادخال الحساب"
    '            View.SetColumnError(_AccountNew, "الرجاء اعادة اختيار الحساب")
    '            View.FocusedRowHandle = e.RowHandle
    '            View.FocusedColumn = _AccountNew
    '            View.ShowEditor()
    '            SimpleButtonSave.Enabled = False
    '        End If

    '    Catch ex As Exception

    '    End Try

    '    Dim _DocCostCenter As GridColumn = View.Columns("DocCostCenter")
    '    If GlobalVariables._CostCenterRequired = True Then
    '        Dim _accno As String = GridView1.GetFocusedRowCellValue("Account")
    '        Dim _Account As New FinancialAccount
    '        If _Account.GetAccountData(_accno) = True Then
    '            If _Account.NeedCostCenter = True Then
    '                Dim _value = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCostCenter")
    '                If IsDBNull(_value) = True Or _value = "0" Then
    '                    XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
    '                    e.Valid = False
    '                    View.SetColumnError(_DocCostCenter, "خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار ")
    '                    'e.ErrorText = "خطأ، يجب ادخال المبلغ"
    '                    View.FocusedRowHandle = e.RowHandle
    '                    View.FocusedColumn = _DocCostCenter
    '                    View.ShowEditor()
    '                    SimpleButtonSave.Enabled = False
    '                End If
    '            End If
    '            Exit Sub
    '        End If
    '    End If

    '    If e.Valid Then
    '        View.ClearColumnErrors()
    '        SimpleButtonSave.Enabled = True
    '    End If

    'End Sub

    Private Sub SimpleExit_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("هل تريد الخروج من السند?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        'AttachmentsBulkAdd.ReferanceID.EditValue = Referance.EditValue
        AttachmentsBulkAdd.SearchSystemDocName.EditValue = Me.DocName.EditValue
        AttachmentsBulkAdd.LinkDocNo.EditValue = Me.DocCode.Text
        AttachmentsBulkAdd.ReferanceID.ReadOnly = True
        AttachmentsBulkAdd.SearchAccount.ReadOnly = True
        AttachmentsBulkAdd.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
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

    Private Sub RepositoryItemLookUpEdit1_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.BeforePopup
        'GetNewAccounts()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub

    Private Sub BarButtonItemDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDelete.ItemClick
        If DeleteDoc(DocName.EditValue, TextDocIDQuery.EditValue, Me.DocCode.Text, True) = True Then
            Me.Dispose()
        End If
    End Sub


    Private Sub TextDocManualNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocManualNo.EditValueChanged

    End Sub

    Private Sub TextDocManualNo_MouseUp(sender As Object, e As MouseEventArgs) Handles TextDocManualNo.MouseUp
        TextEditSelectText(TextDocManualNo)
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonClose.ItemClick
        If Me.GridView1.GetRowCellValue(0, "AccountNew") = 0 Then
            Me.Close()
            Exit Sub
        End If

        If MessageBox.Show("هل تريد الخروج من السند?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub RepositoryItemLookUpEdit1_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles RepositoryItemLookUpEdit1.ContextButtonClick




    End Sub

    Private Sub RepositoryItemLookUpEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpEdit1.ButtonClick
        'Dim view As LookUpEdit = TryCast(sender, LookUpEdit)
        'If e.Item.Tag = "refresh" Then
        '    MsgBox("check")
        '    RepositoryItemLookUpEdit1.DataSource = GetNewAccounts()
        'End If

        Dim Editor As ButtonEdit = CType(sender, ButtonEdit)
        Dim Button As EditorButton = e.Button
        If Button.Tag = "refresh" Then
            RepositoryItemLookUpEdit1.DataSource = GetNewAccounts()
        End If

    End Sub

    Private Sub كشفحسابToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحسابToolStripMenuItem.Click

        If GridView1.Editable AndAlso GridView1.SelectedRowsCount > 0 Then
            If GridView1.ActiveEditor IsNot Nothing Then
                Return
            End If
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                GridView1.DeleteSelectedRows()
                GridView1.UpdateSummary()
            End If
        End If
    End Sub

    Private Sub حذفالسطرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفالسطرToolStripMenuItem.Click




        Dim CheckReportForRef As Boolean
        If IsDBNull(GridView1.GetFocusedRowCellValue("Referance")) Then
            Exit Sub
        End If
        If (GridView1.GetFocusedRowCellValue("Referance")) = 0 Then
            CheckReportForRef = False
        Else
            CheckReportForRef = True
        End If
        Dim F3 As New AccountStatmentForRef
        With F3
            .CheckReportForRef.Text = CStr(CheckReportForRef)
            .Text = "كشف حساب ( " & Me.GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, "AccountNew") & " )"
            If CStr(CheckReportForRef) = True Then
                .SearchReferance.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Referance")
            Else
                .TheAccount.EditValue = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Account")
            End If
            .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
            .DateEditTo.DateTime = Today
            .Show()
            .RefreshDataInAccountStatmentForRef()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With

    End Sub

    Private Sub اضافةسطرجديدToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim position As Integer = GridView1.FocusedRowHandle
        'Dim dt As DataTable = TryCast(GridJournal.DataSource, DataTable)
        'Dim dr As DataRow = dt.NewRow()
        'dt.Rows.InsertAt(dr, position)

        Dim dt As DataTable = TryCast(GridJournal.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("AccountNew") = "1"
        Dim pos As Integer = GridView1.GetDataSourceRowIndex(GridView1.FocusedRowHandle) + 1
        dt.Rows.InsertAt(row, pos)
        GridView1.FocusedRowHandle = GridView1.GetRowHandle(pos)


        'TryCast(GridJournal.DataSource, BindingList(Of GridView1)).AddNew()
    End Sub

    'Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
    '    GoToUp()
    'End Sub
    'Private Sub GoToUp()
    '    If Me.DocStatus.EditValue <> -1 Then
    '        If Me.TextDocIDQuery.EditValue + 1 <> Val(GetDocNo(5, True)) Then
    '            TextDocIDQuery.EditValue = TextDocIDQuery.EditValue + 1
    '        Else
    '            TextDocIDQuery.EditValue = -1
    '        End If
    '    End If
    'End Sub
    'Private Sub GoToDown()
    '    If TextDocIDQuery.EditValue = -1 Then
    '        TextDocIDQuery.EditValue = Val(GetDocNo(5)) - 1
    '    ElseIf TextDocIDQuery.EditValue = 1 Then
    '        MsgBox("لا يوجد بيانات")
    '    Else
    '        TextDocIDQuery.EditValue = TextDocIDQuery.EditValue - 1
    '    End If
    'End Sub

    'Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
    '    GoToDown()
    'End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMaximize.ItemClick
        Me.WindowState = FormWindowState.Maximized
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMinimize.ItemClick
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonRestore.ItemClick
        Me.WindowState = FormWindowState.Normal
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
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

    'Private Sub BarButtonItem10_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
    '    TextDocIDQuery.EditValue = Val(GetDocNo(5))
    'End Sub

    Private Sub BarButtonItem1_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        TextDocIDQuery.EditValue = Val(GetMinDocNo(5))
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        PrintDoc(False, DocCode.Text, "Journal", True, False)
    End Sub

    Private Sub نسخالقيمةلكلالعمودToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخالقيمةلكلالعمودToolStripMenuItem.Click
        Dim RowValue As String = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)
        Dim _coloumnName As String = GridView1.FocusedColumn.FieldName
        If _coloumnName = "DocCostCenter" Or _coloumnName = "DocNoteByAccount" Then
            For i As Integer = 0 To GridView1.RowCount - 1
                ' If GridView1.IsRowVisible(i) Then
                GridView1.SetRowCellValue(i, GridView1.Columns(GridView1.FocusedColumn.FieldName), RowValue)
                '  End If
            Next
        End If

    End Sub

    Private Sub BarButtonItem11_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim F As New DocumentLogs
        With F
            ._DocCode = Me.DocCode.Text
            .GridControl1.DataSource = GetDocumentsLogs(Me.DocCode.Text, -1)
            .ColDeviceName.Visible = False
            .ColDocName.Visible = False
            '.ColDocID.Visible = False
            .ColUserID.Visible = False
            .ShowDialog()
        End With
    End Sub

    Private Sub LayoutControlGroup1_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles LayoutControlGroup1.CustomButtonClick
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

    Private Sub dateEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateDocDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridJournal.Focus()
            GridView1.FocusedRowHandle = 0
        End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem10_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub
End Class