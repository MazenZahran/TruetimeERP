Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout
Imports DevExpress.XtraSplashScreen

Public Class DebitTheReferances
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshList()
    End Sub

    Private Sub DebitTheReferances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SearchRevenueAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryAccounts.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        RepositoryRefTypes.DataSource = GetReferancessTypes(False)
        SearchSort.Properties.DataSource = GetRefSorts(False)
        LookRefType.Properties.DataSource = GetReferancessTypes(False)

        LookUpActiveNotActive.Properties.DataSource = ActiveNotActive()
        If GlobalVariables._SystemLanguage = "Arabic" Then
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusName"
            GridColumn3.Visible = True
            GridColumn4.Visible = False
        Else
            Me.LookUpActiveNotActive.Properties.ValueMember = "StatusValue"
            Me.LookUpActiveNotActive.Properties.DisplayMember = "StatusNameE"
            GridColumn3.Visible = False
            GridColumn4.Visible = True
        End If
        LookUpActiveNotActive.EditValue = "1"
        RefreshList()

        DocDate.DateTime = Today
        Me.KeyPreview = True

    End Sub
    Private Sub RefreshList()

        Dim SqlString As String
        Dim Sql As New SQLControl
        SqlString = " Select RefID,RefName,RefNo,RefType,RefMobile,RefPhone,RefAccID,PriceCategory,CONVERT(DECIMAL(16,2), SubscribeAmount) as SubscribeAmount from Referencess where 1 =1   "
        If Not String.IsNullOrEmpty(Me.SearchSort.Text) Then
            SqlString += "  and [RefSort]=  " & SearchSort.EditValue
        End If
        If Not String.IsNullOrEmpty(Me.LookRefType.Text) Then
            SqlString += "  and [RefType]=  " & LookRefType.EditValue
        End If
        If Not String.IsNullOrEmpty(Me.LookUpActiveNotActive.Text) And Me.LookUpActiveNotActive.EditValue <> "2" Then
            SqlString += "  and [Active]=  " & LookUpActiveNotActive.EditValue
        End If

        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
        GridView1.BestFitColumns()
    End Sub
    Private Sub OpenRefForm()
        ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefNo")
        ' ReferancessAddNew.TextRefName.Select()
        If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            RefreshList()
        End If
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpen.ButtonClick
        OpenRefForm()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingData()
    End Sub
    Private Sub SavingData()
        Me.DocCode.Text = CreateRandomCode()
        GridView1.UpdateSummary()

        If GridView1.RowCount = 0 Then
            MsgBox("خطا: لا يوجد بيانات")
            Exit Sub
        End If

        If String.IsNullOrEmpty(SearchRevenueAccount.Text) Then
            MsgBox("خطا: يجب اختيار حساب الايراد")
            Exit Sub
        End If

        If Me.ColRefMemberAmount.SummaryItem.SummaryValue = 0 Then
            MsgBox("خطأ: مجموع الاشتراكات صفر ")
            Exit Sub
        End If

        If XtraMessageBox.Show("هل تريد حفظ البيانات", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Exit Sub


        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")

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
        End With


        With GridView1 ' 
            For i = 0 To .RowCount - 1
                If Not String.IsNullOrEmpty(.GetRowCellValue(i, "RefNo")) Then
                    Dim RR As DataRow = JournalTable.NewRow
                    RR("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
                    RR("DocName") = "5"
                    RR("DebitAcc") = .GetRowCellValue(i, "RefAccID")
                    RR("CredAcc") = "0"
                    Dim AccData = GetFinancialAccountsData(.GetRowCellValue(i, "RefAccID"))
                    RR("AccountCurr") = AccData.Currency
                    RR("DocCurrency") = _DefaultCurr
                    If IsDBNull(.GetRowCellValue(i, "SubscribeAmount")) Then RR("DocAmount") = 0 Else RR("DocAmount") = .GetRowCellValue(i, "SubscribeAmount")
                    RR("ExchangePrice") = "1"
                    RR("BaseCurrAmount") = RR("DocAmount")
                    RR("BaseAmount") = RR("DocAmount")
                    RR("DocManualNo") = TextDocManualNo.Text
                    RR("InputUser") = GlobalVariables.CurrUser
                    RR("InputDateTime") = Now()
                    RR("DocNotes") = Me.TextDocNotes.Text
                    RR("Referance") = .GetRowCellValue(i, "RefNo")
                    RR("ReferanceName") = .GetRowCellDisplayText(i, "RefName")
                    JournalTable.Rows.Add(RR)
                End If
            Next

            Dim R As DataRow = JournalTable.NewRow
            R("DocDate") = Format(DocDate.DateTime, "yyyy-MM-dd")
            R("DocName") = "5"
            R("DebitAcc") = "0"
            R("CredAcc") = SearchRevenueAccount.EditValue
            Dim AccData2 = GetFinancialAccountsData(SearchRevenueAccount.EditValue)
            R("AccountCurr") = AccData2.Currency
            R("DocCurrency") = _DefaultCurr
            R("DocAmount") = Me.ColRefMemberAmount.SummaryItem.SummaryValue
            R("ExchangePrice") = "1"
            R("BaseCurrAmount") = R("DocAmount")
            R("BaseAmount") = R("DocAmount")
            R("DocManualNo") = TextDocManualNo.Text
            R("InputUser") = GlobalVariables.CurrUser
            R("InputDateTime") = Now()
            R("DocNotes") = Me.TextDocNotes.Text
            R("Referance") = "0"
            JournalTable.Rows.Add(R)

        End With


        Dim _DocID As Integer = 0
        _DocID = GetDocNo(5, False)

        Dim j As Integer = 0
        For Each row As DataRow In JournalTable.Rows
            Dim Sql2 As New SQLControl
            Dim SqlInsertDetials As String
            SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount) 
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
                                      '" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & row("InputUser").ToString & "',
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & Me.DocCode.Text & "',
                                      N'" & row("DocNoteByAccount").ToString & "'
                                            )"
            If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                MsgBox("خطا بخظ السند")
                DeleteFromJournalTemp(5, DocCode.Text)
                SplashScreenManager.CloseForm(False)
                Exit Sub
            End If
            j += 1
            If JournalTable.Rows.Count > 0 Then SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * j / (JournalTable.Rows.Count)) & "%")
        Next row



        '  If XtraMessageBox.Show("هل تريد حفظ البيانات", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
        InsertFromTempToJournal(5, _DocID)
        XtraMessageBox.Show("تم الترحيل", "", MessageBoxButtons.OK)
        '  End If

        DeleteFromJournalTemp(5, Me.DocCode.Text)


        SplashScreenManager.CloseForm(False)

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class