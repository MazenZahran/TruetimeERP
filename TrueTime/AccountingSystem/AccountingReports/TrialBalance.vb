Imports DevExpress.XtraPrinting

Public Class TrialBalance
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TrialBalance()
    End Sub
    Private Sub TrialBalance()
        Dim _DateFrom As String = Format(DateFrom.DateTime, "yyyy-MM-dd")
        Dim _DateTo As String = Format(DateTo.DateTime, "yyyy-MM-dd")
        Dim Sql As New SQLControl
        Dim SqlString As String = "  Select A.AccNo,AccName,
                                       Case When  IsNull(BegDebitSum,0) >= IsNull(BegCreditSum,0) Then IsNull(BegDebitSum,0)-IsNull(BegCreditSum,0) else 0 End As DebBegBalance ,
                                       Case When  IsNull(BegDebitSum,0) < IsNull(BegCreditSum,0) Then  IsNull(BegCreditSum,0)-IsNull(BegDebitSum,0) else 0 End As CreditBegBalance ,
                                       Isnull(B.DebitSum,0)  As Debit,   Isnull(C.CreditSum,0) As Credit,
                                       IsNull(EndDebitSum,0) As EndDebit ,IsNull(EndCreditSum,0) AS EndCredit,
                                       Case When  IsNull(EndDebitSum,0) >= IsNull(EndCreditSum,0) Then IsNull(EndDebitSum,0)-IsNull(EndCreditSum,0) else 0 End As DebEndBalance ,
                                       Case When  IsNull(EndDebitSum,0) < IsNull(EndCreditSum,0)  Then IsNull(EndCreditSum,0)-IsNull(EndDebitSum,0) else 0 End As CreditEndBalance ,
                                       (IsNull(BegDebitSum,0)-IsNull(BegCreditSum,0)+Isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) As Balance ,
                                        IsNull(DebitCount,0)+IsNull(CreditCount,0) As AccTransCount
                                    from
                                        (Select AccNo ,AccName from [dbo].FinancialAccounts) A
                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as DebitSum ,DebitAcc  from Journal where DocStatus<>0  and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  group by  DebitAcc ) B
                                        on A.AccNo=B.DebitAcc
                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as CreditSum ,CredAcc  from Journal where DocStatus<>0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "') group by CredAcc  ) C
                                        on A.AccNo=C.CredAcc

                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as BegDebitSum ,DebitAcc  from Journal where DocStatus<>0  and (DocDate < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "')  group by DebitAcc ) BB
                                        on A.AccNo=BB.DebitAcc
                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as BegCreditSum ,CredAcc  from Journal where DocStatus<>0 and  (DocDate <  '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "')  group by CredAcc  ) CC
                                        on A.AccNo=CC.CredAcc

                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as EndDebitSum ,DebitAcc  from Journal where DocStatus<>0  and (DocDate <= '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  group by DebitAcc ) BBB
                                        on A.AccNo=BBB.DebitAcc
                                        left Join 
                                        ( Select Sum(BaseCurrAmount) as EndCreditSum ,CredAcc  from Journal where DocStatus<>0 and  (DocDate <=  '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  group by CredAcc  ) CCC
                                        on A.AccNo=CCC.CredAcc

                                        left Join 
                                        ( Select Count(id) as DebitCount ,DebitAcc  from Journal where DocStatus<>0 and  (DocDate <=  '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  group by DebitAcc  ) E
                                        on A.AccNo=E.DebitAcc
                                        left Join 
                                        ( Select Count(id) as CreditCount ,CredAcc  from Journal where DocStatus<>0 and  (DocDate <=  '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  group by CredAcc  ) F
                                        on A.AccNo=F.CredAcc "
        SqlString += " where 1=1  "
        If CheckShowAll.Checked = False Then SqlString += " And  IsNull(DebitCount,0)+IsNull(CreditCount,0) > 0 "
        If CheckHideZerosBalance.Checked = True Then SqlString += " And  Abs(IsNull(BegDebitSum,0)-IsNull(BegCreditSum,0)+Isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) > 0 "
        ' Where (isnull(B.DebitSum,0)-Isnull(C.CreditSum,0)) <> 0
        Sql.SqlTrueAccountingRunQuery(SqlString)
        GridControl1.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub TrialBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        DateTo.DateTime = Today
    End Sub

    Private Sub RepositoryItemHyperAccountNo_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles RepositoryItemHyperAccountNo.OpenLink

    End Sub

    Private Sub كشفحسابToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles كشفحسابToolStripMenuItem.Click
        Dim F3 As New AccountStatmentForRef
        With F3
            .CheckReportForRef.Text = "False"
            .Text = "كشف حساب ( " & Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "AccName") & " )"
            .TheAccount.EditValue = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "AccNo")
            .Show()
            .DateEditFrom.DateTime = Me.DateFrom.DateTime
            .DateEditTo.DateTime = Me.DateTo.DateTime
            .RefreshDataInAccountStatmentForRef()
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        End With
    End Sub

    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize
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

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("ميزان مراجعة")

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ  " & DateFrom.EditValue & "  الى تاريخ  " & DateTo.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
                                                                           {"  ", Now(), "Pages: [Page # of Pages #]"})
    End Sub

End Class