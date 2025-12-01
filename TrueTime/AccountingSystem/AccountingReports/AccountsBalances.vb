Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports DevExpress.Data.Filtering
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout.Customization
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen
Imports TrueTime.POSRestCashier

Public Class AccountsBalances
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _ShowSelectBox As Boolean = False
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        My.Forms.Main.ItemElapseTime.Caption = (0)
        start_time = Now
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Try
            If CheckReportForRef.Text = "True" Then
                BalancesForRef()
            Else
                BalancesForAcc()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            CloseProgressPanel(handle)
        End Try

        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
        GridView1.FocusedRowHandle = focusedRow

    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub BalancesForRef()


        Dim _DateTo As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim Sql As New SQLControl
        Dim SqlString As String
        '      SqlString = "      Select J.Referance as AccNo, R.RefName as AccName ,
        'CONVERT(DECIMAL(16,2), SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0 End ))  as Debit,
        'CONVERT(DECIMAL(16,2),  SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0 End ))  as Credit,
        'CONVERT(DECIMAL(16,2), SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0 End )- SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0 End ) )   Balance 
        'from journal J 
        'left join Referencess R on R.RefNo=J.Referance 
        'where J.DocDate <='" & _DateTo & "' And j.DocStatus<>0  AND  (j.DebitAcc= R.RefAccID or j.CredAcc= R.RefAccID) "
        '      If LookRefType.EditValue <> -1 Then SqlString += " And R.[RefType]='" & LookRefType.EditValue & "' "
        '      SqlString += " Group by Referance,RefName "



        SqlString = "  Select  A.RefNo As AccNo,
                               A.RefName As AccName,
                               A.RefTypeName,
                               B.Debit,
                               B.Credit,RefAccID,
                               A.RefType,
                               A.RefMobile,A.RefPhone,A.RefEmail,A.CITY,IsNull(A.RefMemo,'') As RefMemo,Address,
                               IsNull(Debit, 0)-IsNull(Credit, 0) AS Balance,IsNull(DebitAccCurr, 0)-IsNull(CreditAccCurr, 0) AS BalanceByAccCurr,C.LastTrans,SortName,A.SalesMan,A.SalesManDay
                        FROM
                          (SELECT RefNo,
                                  RefName,
                                  RefType,RefAccID,
                                  T.RefTypeName,
                                  RefMobile,RefPhone,RefEmail,SearchCity,RefMemo,R.Address,C.CITY,S.[SortName] as SortName,IsNull(E.EmployeeName,'') as SalesMan,IsNull(R.SalesManDay,'') as SalesManDay 
                           FROM Referencess R 
                           Left Join ReferencesTypes T on R.RefType=T.TypeID 
                           Left Join RefSorts S on R.RefSort=S.ID
                           left join RefCities C on R.SearchCity=C.ID
                           left Join EmployeesData E on E.EmployeeID=R.SalesMan
                           left Join FinancialAccounts F on F.AccNo=R.RefAccID "
        If Currency.EditValue <> -1 Then
            SqlString += " Where F.Currency=" & Currency.EditValue & ""
            ColBalanceByAccCurr.Visible = True
            ColBalance.Visible = False
            GridView1.ViewCaption = " أرصدة الذمم بعملة " & Currency.Text
        Else
            ColBalanceByAccCurr.Visible = False
            ColBalance.Visible = True
            GridView1.ViewCaption = " أرصدة الذمم بالعملة الأساسية"
        End If
        SqlString += ") A
                        LEFT JOIN
                          (SELECT J.Referance AS AccNo,
                                  R.RefName AS AccName,
                                  CONVERT(DECIMAL(16, 2), SUM(CASE
                                                                  WHEN CredAcc='0' THEN BaseCurrAmount
                                                                  ELSE 0
                                                              END)) AS Debit,
								 CONVERT(DECIMAL(16, 2), SUM(CASE
                                                                  WHEN CredAcc='0' THEN BaseAmount
                                                                  ELSE 0
                                                              END)) AS DebitAccCurr,
                                  CONVERT(DECIMAL(16, 2), SUM(CASE
                                                                  WHEN DebitAcc='0' THEN BaseCurrAmount
                                                                  ELSE 0
                                                              END)) AS Credit,
								  CONVERT(DECIMAL(16, 2), SUM(CASE
                                                                  WHEN DebitAcc='0' THEN BaseAmount
                                                                  ELSE 0
                                                              END)) AS CreditAccCurr
                           FROM journal J
                           LEFT JOIN Referencess R ON R.RefNo=J.Referance
                           WHERE J.DocDate <='" & _DateTo & "' "
        If LookRefType.EditValue <> -1 Then SqlString += " And R.[RefType]='" & LookRefType.EditValue & "' "
        If SearchSort.EditValue <> -1 Then SqlString += " And R.[RefSort]='" & SearchSort.EditValue & "' "
        If Me.SearchEmployees.Text <> "" Then SqlString += " And R.[SalesMan]='" & SearchEmployees.EditValue & "' "

        If GlobalVariables._ShowCostCenter = True And Me.SearchCostCenter.EditValue <> -1 Then SqlString += " And J.[DocCostCenter]='" & SearchCostCenter.EditValue & "' "
        SqlString += "       AND j.DocStatus<>0
                             AND (j.DebitAcc= R.RefAccID
                             OR j.CredAcc= R.RefAccID)"
        SqlString += " GROUP BY Referance,RefName) B ON A.RefNo=B.AccNo"
        SqlString += " Left Join   "
        SqlString += " (Select Max(DocDate) As LastTrans,Referance from Journal Where DocStatus <> 0   "
        If _DocNameForLastDocDate <> -1 Then SqlString += " And  DocName =" & _DocNameForLastDocDate
        SqlString += " group by Referance) C on A.RefNo=C.Referance "
        If CheckShowAll.Checked = False Then SqlString += "   WHERE IsNull(Debit, 0)-IsNull(Credit, 0) <> 0"
        'If GlobalVariables._HRSystemIsConnectedWithAccountingSystem = True Then
        '    SqlString = "   Select J.Referance as AccNo, R.RefName as AccName ,
        '         CONVERT(DECIMAL(16,2), SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0 End )) as Debit,
        '         CONVERT(DECIMAL(16,2), SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0 End )) as Credit,
        '         CONVERT(DECIMAL(16,2), SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0 End )- SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0 End )) As Balance 
        '          from journal J 
        '          left join Referencess R on R.RefNo=J.Referance 
        '          where J.DocDate <='" & _DateTo & "' And j.DocStatus<>0  AND  (j.DebitAcc= R.RefAccID or j.CredAcc= R.RefAccID)
        '          group by Referance,RefName "
        'End If
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)




    End Sub
    Private Sub BalancesForAcc()
        If String.IsNullOrEmpty(Currency.Text) Then
            XtraMessageBox.Show("يجب اختيار العملة")
            Exit Sub
        End If
        Dim _DateTo As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = "    SELECT AccNo as AccNo,AccNo as RefAccID, AccName as AccName,isnull(Debit,0) as Debit ,isnull(Credit,0) as Credit,isnull(Debit,0)-isnull(Credit,0) as Balance,Isnull(DebitBaseAmount,0) - IsNull(CreditBaseAmount,0) as BalanceByAccCurr
FROM 
(Select AccNo,AccName,FinancialStatment,FinancialSector,Currency from FinancialAccounts) t0
left join
(select DebitAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Debit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) DebitBaseAmount from Journal where DocStatus <> 0 And DocDate <='" & _DateTo & "'  "
        If GlobalVariables._ShowCostCenter = True And Me.SearchCostCenter.EditValue <> -1 Then SqlString += " And [DocCostCenter]='" & SearchCostCenter.EditValue & "' "
        SqlString += " group by DebitAcc) t1 ON (t0.AccNo = t1.DebitAcc)
left JOIN
    (select CredAcc, CONVERT(DECIMAL(16,2), sum(BaseCurrAmount)) as Credit,CONVERT(DECIMAL(16,2), sum(BaseAmount),0) as CreditBaseAmount from Journal where DocStatus <> 0 And DocDate <='" & _DateTo & "' "
        If GlobalVariables._ShowCostCenter = True And Me.SearchCostCenter.EditValue <> -1 Then SqlString += " And [DocCostCenter]='" & SearchCostCenter.EditValue & "' "
        SqlString += " group by CredAcc ) t2 ON (t0.AccNo = t2.CredAcc)
where  isnull(Debit,0)-isnull(Credit,0) <> 0   "
        If FinancialStatment.EditValue <> -1 Then SqlString += " And FinancialStatment=" & FinancialStatment.EditValue
        If FinancialSector.EditValue <> -1 Then SqlString += " And FinancialSector=" & FinancialSector.EditValue & ""
        If Currency.EditValue <> -1 Then
            SqlString += " And t0.Currency=" & Currency.EditValue & ""
            ColBalanceByAccCurr.Visible = True
        Else
            ColBalanceByAccCurr.Visible = False
        End If
        sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub AccountsBalances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LookRefType.Properties.DataSource = GetReferancessTypes(True)
        SearchAccType.Properties.DataSource = GetAccTypes(-1)
        Currency.Properties.DataSource = GetCurrencyTableWithAll(True)
        Currency.EditValue = -1
        Me.KeyPreview = True
        DateEdit1.DateTime = Today
        ColRefMobile.Visible = False
        ColRefPhone.Visible = False
        ColSearchCity.Visible = False
        ColRefEmail.Visible = False
        ColAddress.Visible = False
        SearchEmployees.Properties.DataSource = GetEmployeesTable(-1, -1)
        LookUpEditDays.DataSource = GetWeekDaysNames()

        If GlobalVariables._ShowCostCenter = True Then
            LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            SearchCostCenter.Properties.DataSource = GetCostCenter(True)
            SearchCostCenter.EditValue = -1
        End If
        _DocNameForLastDocDate = -1

        CustomDrawEmptyForeground(GridControl1, GridView1)

    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub

    Private Sub CheckReportForRef_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckReportForRef_EditValueChanged(sender As Object, e As EventArgs) Handles CheckReportForRef.EditValueChanged
        If CheckReportForRef.Text = "True" Then
            LayoutControlItemRefType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemStatment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItemSector.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutCurrency.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            'LayoutRefDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            BarButtonSendSMS.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonSendEveryOneByWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonItemShowRefMobile.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonSendMotalabaByWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonItemShowMassegesBuilder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            SearchSort.Properties.DataSource = GetRefSorts(True)
            Me.GridView1.ViewCaption = "تقرير أرصدة الذمم"
            Me.SearchSort.EditValue = -1

        Else
            LayoutControlItemRefType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItemStatment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemSector.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutRefSort.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutSalesMan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutRefDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutShowNotes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutShowAllAccounts.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            BarButtonSendSMS.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonSendEveryOneByWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonItemShowRefMobile.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonSendMotalabaByWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonItemShowMassegesBuilder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            GridColRefTypeName.Visible = False
            'ColRefMobile.Visible = False
            'ColRefEmail.Visible = False
            'ColRefPhone.Visible = False
            'ColAddress.Visible = False
            'ColSearchCity.Visible = False
            ColLastTrans.Visible = False
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT [SectorID],[SectorName]
                          FROM [FinancialParts] S
                          left join [FinancialStatementNames] N on S.[FinancialStatmentID]=N.ID"
            SqlString += " union select -1 as SectorID,N'الكل' as SectorName "
            sql.SqlTrueAccountingRunQuery(SqlString)
            FinancialSector.Properties.DataSource = sql.SQLDS.Tables(0)

            SqlString = " Select [ID],[FinancialStatementName] From [FinancialStatementNames]  "
            SqlString += " union select -1 as ID,N'الكل' as FinancialStatementName "
            sql.SqlTrueAccountingRunQuery(SqlString)
            FinancialStatment.Properties.DataSource = sql.SQLDS.Tables(0)
            Me.GridView1.ViewCaption = "تقرير أرصدة الحسابات"
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        If CheckShowRefDetails.Checked = True Then
            pb.PageSettings.Landscape = True
        Else
            pb.PageSettings.Landscape = False
        End If
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
        If CheckReportForRef.Text = "True" Then
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
                (" " & "كشف ارصدة الذمم  ")
        Else
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
                ("كشف أرصدة الحسابات  ")
        End If
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " لغاية تاريخ:   " & DateEdit1.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub كشفحسابToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحسابToolStripMenuItem.Click
        Dim F3 As New AccountStatmentForRef
        With F3
            .CheckReportForRef.Text = Me.CheckReportForRef.Text
            .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
            .DateEditTo.DateTime = Today
            .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccName") & " )"
            If Me.CheckReportForRef.Text = True Then
                .SearchReferance.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo")
            Else
                .TheAccount.EditValue = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo")
            End If

            .Show()
            .RefreshDataInAccountStatmentForRef()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub RepositoryRefNo_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryRefNo.OpenLink
        If CheckReportForRef.Text = "True" Then
            ReferancessAddNew.TextRefNo.Text = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo")
            ' ReferancessAddNew.TextRefName.Select()
            If ReferancessAddNew.ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            End If
        End If
    End Sub
    Private Sub GridView1_CustomDrawFooterCell(sender As Object, e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
        If e.Column.FieldName = "AccNo" Or e.Column.FieldName = "Balance" Then
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near
            e.Appearance.ForeColor = Color.FromArgb(255, 80, 0)
        End If
    End Sub

    Private Sub CheckShowRefDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowRefDetails.CheckedChanged
        If CheckShowRefDetails.Checked = True Then
            'GridView1.OptionsView.ShowPreview = True
            ColRefMobile.VisibleIndex = 3
            ColRefPhone.VisibleIndex = 4
            ColSearchCity.VisibleIndex = 5
            ColRefEmail.VisibleIndex = 6
            ColAddress.VisibleIndex = 7
        Else
            'GridView1.OptionsView.ShowPreview = True
            ColRefMobile.Visible = False
            ColRefPhone.Visible = False
            ColSearchCity.Visible = False
            ColRefEmail.Visible = False
            ColAddress.Visible = False
        End If
    End Sub

    Private Sub CheckShowNotes_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowNotes.CheckedChanged
        GridView1.OptionsView.ShowPreview = CheckShowNotes.Checked
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSendSMS.ItemClick

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")

            _SMSMessagesTempTable.Clear()
            CeateMessagesTempTable()

            Dim sql As New SQLControl
            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try

            Dim J As Integer
            J = 1
            Dim _ReferanceNo As String
            Dim _RefMobile, _RefName, _DocCurrency As String
            Dim _DocAmount As Decimal = 0
            Dim _DocDate, _DocCode, _DocData As String
            Dim _DocName, _DocID As Integer
            Dim _OrigionalSMSMessage, _SMSMessage As String
            _DocCode = ""
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=5")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "AccNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "AccName")
                            _DocAmount = .GetRowCellValue(i, "Balance")
                            _DocCurrency = GetCurrencyCode(GetDefaultCurrency())



                            _DocData = "Journal"
                            _DocDate = Format(DateEdit1.DateTime, "yyyy-MM-dd")
                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#Balance#", _DocAmount)
                            _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                            _SMSMessage = _SMSMessage.Replace("#Currency#", _DocCurrency)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 4
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = _DocDate
                            dr("Sent") = 0
                            dr("DocName") = _DocName
                            dr("DocID") = _DocID
                            dr("DocCode") = _DocCode
                            dr("DocData") = _DocData
                            dr("Sent") = 0
                            dr("SmsID") = 0
                            dr("SMSStatus") = ""
                            If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                .ShowDialog()
            End With

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarEditItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)


    End Sub

    Private Sub BarSubItem1_Popup(sender As Object, e As EventArgs) Handles BarSubItem1.Popup
        If CheckReportForRef.Text = "True" Then
            If GridView1.RowCount > 1 Then
                If GridView1.SelectedRowsCount = 1 Then

                    If GridView1.GetFocusedRowCellValue("Balance") > 0 Then
                        BarButtonCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                        BarButtonDebitNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    ElseIf GridView1.GetFocusedRowCellValue("Balance") < 0 Then
                        BarButtonCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                        BarButtonDebitNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    End If
                Else
                    BarButtonDebitNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    BarButtonCreditNote.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                End If
            End If
        End If
    End Sub

    Private Sub BarButtonCreditNote_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonCreditNote.ItemClick
        Dim ctr As Integer = 0
        Dim child As Form = Nothing
        Dim f As CreditDebitNotes = New CreditDebitNotes()
        f.TextDocName.EditValue = 7
        ctr = ctr + 1
        With f
            .TextDocStatus.EditValue = -1
            .TextDocName.EditValue = 7
            .Referance.EditValue = GridView1.GetFocusedRowCellValue("AccNo")
            .TextReferanceName.EditValue = GridView1.GetFocusedRowCellValue("AccName")
            .TotalDocAmount.EditValue = Math.Abs(GridView1.GetFocusedRowCellValue("Balance"))
            .Text = "اشعار دائن"
            If .ShowDialog <> DialogResult.OK Then
                RefreshData()
            End If
        End With
    End Sub

    Private Sub BarButtonDebitNote_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonDebitNote.ItemClick
        Dim ctr As Integer = 0
        Dim child As Form = Nothing
        Dim f As CreditDebitNotes = New CreditDebitNotes()
        f.TextDocName.EditValue = 6
        ctr = ctr + 1
        With f
            .TextDocStatus.EditValue = -1
            .TextDocName.EditValue = 6
            .Referance.EditValue = GridView1.GetFocusedRowCellValue("AccNo")
            .TextReferanceName.EditValue = GridView1.GetFocusedRowCellValue("AccName")
            .TotalDocAmount.EditValue = Math.Abs(GridView1.GetFocusedRowCellValue("Balance"))
            .Text = "اشعار مدين"
            If .ShowDialog <> DialogResult.OK Then
                RefreshData()
            End If
            '  .TextDocID.EditValue = GetDocNo(TextEditDocName.EditValue)
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonShowCheckBoxRowSelect.ItemClick
        Select Case GridView1.OptionsSelection.MultiSelectMode
            Case GridMultiSelectMode.CheckBoxRowSelect
                GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect
            Case GridMultiSelectMode.RowSelect
                GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
        End Select
    End Sub

    Private Sub BarSubItem2_Popup(sender As Object, e As EventArgs) Handles BarSubItem2.Popup
        Select Case GridView1.OptionsSelection.MultiSelectMode
            Case GridMultiSelectMode.CheckBoxRowSelect
                BarButtonShowCheckBoxRowSelect.Caption = " اخفاء عمود التحديد "
            Case GridMultiSelectMode.RowSelect
                BarButtonShowCheckBoxRowSelect.Caption = " اظهار عمود التحديد "
        End Select
        If ColRefMobile.VisibleIndex = -1 Then
            BarButtonItemShowRefMobile.Caption = "اظهار عمود رقم الموبايل"
        Else
            BarButtonItemShowRefMobile.Caption = "اخفاء عمود رقم الموبايل"
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim _journal As New DataTable
        With _journal
            .Columns.Add("AccountNew", GetType(System.String))
            .Columns.Add("Account", GetType(System.String))
            .Columns.Add("AccountCurr", GetType(System.Int16))
            .Columns.Add("Referance", GetType(System.Int16))
            .Columns.Add("DocCostCenter", GetType(System.Int32))
            .Columns.Add("DocCurrency", GetType(System.Int32))
            .Columns.Add("DebitAmount", GetType(System.Decimal))
            .Columns.Add("CreditAmount", GetType(System.Decimal))
            .Columns.Add("ExchangePrice", GetType(System.Decimal))
            .Columns.Add("BaseCurrAmount", GetType(System.Decimal))


            Dim _amount As Decimal
            Dim _AccNo, _RefAcc As String

            Dim i As Integer
            For i = 0 To GridView1.RowCount - 1
                _amount = GridView1.GetRowCellValue(i, "Balance")
                _AccNo = GridView1.GetRowCellValue(i, "AccNo")
                _RefAcc = GridView1.GetRowCellValue(i, "RefAccID")

                If _amount > 0 Then
                    .Rows.Add(_AccNo, _RefAcc, 1, _AccNo, 1, 1, 0, _amount, 1, -1 * _amount)
                Else
                    .Rows.Add(_AccNo, _RefAcc, 1, _AccNo, 1, 1, Math.Abs(_amount), 0, 1, Math.Abs(_amount))
                End If
            Next

        End With
        GlobalVariables._ItemsTable = _journal
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonCopy.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSendEveryOneByWhatsApp.ItemClick
        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
            Dim _ReferanceNo As Integer
            Dim _RefMobile As String
            Dim J As Integer = 0
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "AccNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            Dim F3 As New AccountStatmentForRef
                            With F3
                                ._OpenForPrint = True
                                ._PrintOption = "SendWhatsApp"
                                .CheckReportForRef.Text = Me.CheckReportForRef.Text
                                .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
                                .DateEditTo.DateTime = Today
                                .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(i, "AccName") & " )"
                                '  MsgBox(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo"))
                                .SearchReferance.Text = Me.GridView1.GetRowCellValue(i, "AccNo")
                                .RefreshDataInAccountStatmentForRef()
                                .Show()
                            End With

                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
        '  SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSendByWhatsApp.ItemClick
        ' Dim a As XtraInputBox

        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                GridControl1.ExportToPdf("AccountBalance.pdf")
                SendFileToWhatsApp(MobileNo, "AccountBalance.pdf", "كشف حساب", "", "")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSendMotalabaByWhatsApp.ItemClick

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات واتس الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")

            _SMSMessagesTempTable.Clear()
            CeateMessagesTempTable()

            Dim sql As New SQLControl
            Dim _BulkNo As Integer
            Try
                sql.SqlTrueAccountingRunQuery("   select IsNull(max([BulkNo]),0)+1 as BulkNo from [dbo].[SmsSentMessages]  ")
                _BulkNo = sql.SQLDS.Tables(0).Rows(0).Item("BulkNo")
            Catch ex As Exception
                _BulkNo = 0
            End Try

            Dim J As Integer
            J = 1
            Dim _ReferanceNo As String
            Dim _RefMobile, _RefName, _DocCurrency As String
            Dim _DocAmount As Decimal = 0
            Dim _DocDate, _DocCode, _DocData As String
            Dim _DocName, _DocID As Integer
            Dim _OrigionalSMSMessage, _SMSMessage As String
            _DocCode = ""
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=5")
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "AccNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "AccName")
                            _DocAmount = .GetRowCellValue(i, "Balance")
                            _DocCurrency = GetCurrencyCode(GetDefaultCurrency())



                            _DocData = "Journal"
                            _DocDate = Format(DateEdit1.DateTime, "yyyy-MM-dd")
                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#Balance#", _DocAmount)
                            _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                            _SMSMessage = _SMSMessage.Replace("#Currency#", _DocCurrency)
                            Dim dr As DataRow = _SMSMessagesTempTable.NewRow
                            dr("SMSType") = 5
                            dr("SMSDetails") = _SMSMessage
                            dr("RefNo") = _ReferanceNo
                            dr("RefMobile") = _RefMobile
                            dr("RefName") = _RefName
                            dr("AccrualDateTime") = _DocDate
                            dr("Sent") = 0
                            dr("DocName") = _DocName
                            dr("DocID") = _DocID
                            dr("DocCode") = _DocCode
                            dr("DocData") = _DocData
                            dr("Sent") = 0
                            dr("SmsID") = 0
                            dr("SMSStatus") = ""
                            If _DocDate <= Today() Then dr("Action") = 1 Else dr("Action") = 2
                            _SMSMessagesTempTable.Rows.Add(dr)
                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
            SplashScreenManager.CloseForm(False)
            Dim f As New SmsSendingForm
            With f
                .GetUnsentMessages(_BulkNo)
                .RadioGroupSendType.EditValue = "WhatsApp"
                .ShowDialog()
            End With

        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShowMassegesBuilder.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SMSTypeList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SMSTypeList()
            child.MdiParent = My.Forms.Main
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShowRefMobile.ItemClick
        If ColRefMobile.VisibleIndex = -1 Then
            ColRefMobile.VisibleIndex = 3
        Else
            ColRefMobile.VisibleIndex = -1
        End If
    End Sub
    Private _DocNameForLastDocDate As Integer
    Private Sub BarSubItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarSubItem3.ItemClick
        Select Case _DocNameForLastDocDate
            Case -1
                BarCheckAll.Checked = True
                BarCheckItemSales.Checked = False
                BarCheckItemPurchase.Checked = False
                BarCheckItemPayment.Checked = False
                BarCheckItemReceipt.Checked = False
            Case 1
                BarCheckAll.Checked = False
                BarCheckItemSales.Checked = False
                BarCheckItemPurchase.Checked = True
                BarCheckItemPayment.Checked = False
                BarCheckItemReceipt.Checked = False
            Case 2
                BarCheckAll.Checked = False
                BarCheckItemSales.Checked = True
                BarCheckItemPurchase.Checked = False
                BarCheckItemPayment.Checked = False
                BarCheckItemReceipt.Checked = False
            Case 3
                BarCheckAll.Checked = False
                BarCheckItemSales.Checked = False
                BarCheckItemPurchase.Checked = False
                BarCheckItemPayment.Checked = True
                BarCheckItemReceipt.Checked = False
            Case 4
                BarCheckAll.Checked = False
                BarCheckItemSales.Checked = False
                BarCheckItemPurchase.Checked = False
                BarCheckItemPayment.Checked = False
                BarCheckItemReceipt.Checked = True
        End Select

    End Sub

    Private Sub BarCheckAll_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckAll.CheckedChanged
        _DocNameForLastDocDate = -1
    End Sub

    Private Sub BarCheckItemPurchase_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItemPurchase.CheckedChanged
        _DocNameForLastDocDate = 1
    End Sub

    Private Sub BarCheckItemSales_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItemSales.CheckedChanged
        _DocNameForLastDocDate = 2
    End Sub

    Private Sub BarCheckItemPayment_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItemPayment.CheckedChanged
        _DocNameForLastDocDate = 3
    End Sub

    Private Sub BarCheckItemReceipt_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCheckItemReceipt.CheckedChanged
        _DocNameForLastDocDate = 4
    End Sub

    Private Sub BarButtonItem4_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        PrintStatments("SendWhatsApp")
        'Try
        '    If GridView1.RowCount = 0 Then
        '        XtraMessageBox.Show("لا يوجد بيانات")
        '        Exit Sub
        '    End If

        '    If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
        '        XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
        '        Exit Sub
        '    End If


        '    If XtraMessageBox.Show(" هل تريد ارسال الكشوفات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
        '        Exit Sub
        '    End If

        '    SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        '    SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
        '    Dim _ReferanceNo As Integer
        '    Dim _RefMobile As String
        '    Dim J As Integer = 0
        '    With GridView1
        '        For i As Integer = 0 To .DataRowCount - 1
        '            If GridView1.IsRowSelected(i) = True Then
        '                _ReferanceNo = .GetRowCellValue(i, "AccNo")
        '                If Not String.IsNullOrEmpty(_ReferanceNo) Then
        '                    Dim _RefData = GetRefranceData(_ReferanceNo)
        '                    _RefMobile = _RefData.RefMobile
        '                    Dim F3 As New AccountStatmentForRef
        '                    With F3
        '                        ._OpenForPrint = True
        '                        ._PrintOption = "SendWhatsApp"
        '                        .CheckReportForRef.Text = Me.CheckReportForRef.Text
        '                        .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        '                        .DateEditTo.DateTime = Today
        '                        .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(i, "AccName") & " )"
        '                        '  MsgBox(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo"))
        '                        .SearchReferance.Text = Me.GridView1.GetRowCellValue(i, "AccNo")
        '                        .RefreshDataInAccountStatmentForRef()
        '                        .Show()
        '                    End With

        '                    J = J + 1
        '                End If
        '            End If
        '            If .DataRowCount > 0 Then
        '                SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
        '                                                                  " " & J & " From " & GridView1.SelectedRowsCount)
        '            End If
        '        Next i
        '    End With
        'Catch ex As Exception
        '    MsgBoxShowError(ex.ToString)
        'Finally
        '    SplashScreenManager.CloseForm(False)
        'End Try
        '  SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BarButtonTaqseet_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonTaqseet.ItemClick

        Dim _Amount As Decimal = CDec(GridView1.GetFocusedRowCellValue("Balance"))
        If _Amount = 0 Then
            MsgBoxShowError(" الرصيد صفر ولا يمكن التقسيط ")
            Exit Sub
        End If
        Dim _DocNo As Integer = -1
        Dim f As New InstallmentForm("New")
        With f
            .InstallmentReferance.EditValue = GridView1.GetFocusedRowCellValue("AccNo")
            .InstallmentsAmount.EditValue = _Amount
            .Text = " تقسيط دين "
            .InstallmentInOut.EditValue = "IN"
            .VoucherNo.Text = _DocNo
            .InstallmentsAmount.ReadOnly = False
            .InstallmentInOut.ReadOnly = True
            .VoucherNo.ReadOnly = True
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem5_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
            Dim _ReferanceNo As Integer
            Dim _RefMobile As String
            Dim J As Integer = 0
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "AccNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            Dim F3 As New AccountStatmentForRef
                            With F3
                                ._OpenForPrint = True
                                ._PrintOption = "Print"
                                .CheckReportForRef.Text = Me.CheckReportForRef.Text
                                .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
                                .DateEditTo.DateTime = Today
                                .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(i, "AccName") & " )"
                                '  MsgBox(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "AccNo"))
                                .SearchReferance.Text = Me.GridView1.GetRowCellValue(i, "AccNo")
                                .RefreshDataInAccountStatmentForRef()
                                .Show()
                            End With

                            J = J + 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
        '  SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        PrintStatments("Print")
    End Sub
    Private Sub PrintStatments(_PrintOption As String)
        'Get dateFrom from dialog
        Dim dateFrom As Date
        Using dlg As New DateFromDialog()
            If dlg.ShowDialog(Me) <> DialogResult.OK Then
                Exit Sub
            End If
            dateFrom = dlg.SelectedDate
        End Using

        Try
            If GridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد طباعة الكشوفات   " & GridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
            Dim _ReferanceNo As Integer
            Dim _RefMobile As String
            Dim _RefCurrency As String
            Dim J As Integer = 0
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If GridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "AccNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefCurrency = _RefData.currency_id
                            Dim F3 As New AccountStatmentDetails
                            With F3
                                ._OpenForPrint = True
                                ._PrintOption = _PrintOption
                                .DateEditFrom.DateTime = dateFrom          ' <-- use chosen dateFrom
                                .DateEditTo.DateTime = Today
                                .Text = "كشف حساب ( " & Me.GridView1.GetRowCellValue(i, "AccName") & " )"
                                .SearchReferance.Text = Me.GridView1.GetRowCellValue(i, "AccNo")
                                .GetAcountStatmentForRef(dateFrom, Format(Now(), "yyyy-MM-dd"), _ReferanceNo, _RefCurrency)
                                .Show()
                            End With

                            J += 1
                        End If
                    End If
                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (GridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & GridView1.SelectedRowsCount)
                    End If
                Next i
            End With
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BarBtnPrintThermal_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBtnPrintThermal.ItemClick
        PrintStatments("ThermalPrint")
    End Sub
End Class



Public Class DateFromDialog
    Inherits XtraForm

    Private ReadOnly _dateEdit As DateEdit
    Private ReadOnly _btnOk As SimpleButton
    Private ReadOnly _btnCancel As SimpleButton

    Public Sub New()
        Me.Text = "اختيار تاريخ البداية"
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.Width = 320
        Me.Height = 140

        _dateEdit = New DateEdit() With {
            .Left = 20,
            .Top = 20,
            .Width = 260,
            .EditValue = New DateTime(Today.Year, 1, 1)
        }
        _dateEdit.Properties.CalendarTimeEditing = False
        _dateEdit.Properties.Mask.EditMask = "yyyy-MM-dd"
        _dateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd"
        _dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        _dateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd"
        _dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        _btnOk = New SimpleButton() With {
            .Text = "موافق",
            .Left = 120,
            .Top = 60,
            .Width = 70,
            .DialogResult = DialogResult.OK
        }

        _btnCancel = New SimpleButton() With {
            .Text = "الغاء",
            .Left = 210,
            .Top = 60,
            .Width = 70,
            .DialogResult = DialogResult.Cancel
        }

        Me.Controls.Add(_dateEdit)
        Me.Controls.Add(_btnOk)
        Me.Controls.Add(_btnCancel)

        Me.AcceptButton = _btnOk
        Me.CancelButton = _btnCancel
    End Sub

    Public ReadOnly Property SelectedDate As Date
        Get
            If _dateEdit.EditValue Is Nothing Then
                Return New DateTime(Today.Year, 1, 1)
            End If
            Return CDate(_dateEdit.EditValue)
        End Get
    End Property
End Class