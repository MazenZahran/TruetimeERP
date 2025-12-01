
Imports System.Data.SqlClient
Imports System.Net
Imports System.Text
Imports DevExpress
Imports DevExpress.DataAccess.Native.Excel
Imports DevExpress.Utils
Imports DevExpress.Utils.DragDrop
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.ReportGeneration
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports System.Web
Imports System.IO
Imports System.Data.SqlTypes
Imports DevExpress.CodeParser
Imports DevExpress.XtraGrid

Public Class AccountStatmentForRef
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private _RefType As Integer = 0
    Private _TarteebID As Integer = 0
    Public _OpenForPrint As Boolean
    Public _PrintOption As String
    Private _SortByModifiedDate As Boolean
    Private _ShowInputDateTimeField As Boolean

    'Private _TarteebMode As Boolean = True
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshDataInAccountStatmentForRef()
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Public Sub RefreshDataInAccountStatmentForRef()


        GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near
        If CheckReportForRef.Text = "True" Then
            If SearchReferance.Text = "" And _OpenForPrint = False Then
                XtraMessageBox.Show("يجب اختيار ذمة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Else
            If TheAccount.Text = "" Then
                XtraMessageBox.Show("يجب اختيار الحساب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If

        If String.IsNullOrEmpty(Currency.Text) And _OpenForPrint = False Then
            XtraMessageBox.Show("يجب تحديد العملة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        If CheckReportForRef.Text = "True" Then
            GetAcountStatmentForRef(DateEditFrom.DateTime, DateEditTo.DateTime, SearchReferance.EditValue, Currency.EditValue)
        Else
            GetAcountStatmentForAcc(DateEditFrom.DateTime, DateEditTo.DateTime, TheAccount.EditValue, Currency.EditValue)
        End If

        'CloseProgressPanel(handle)
    End Sub


    Private Sub GetAcountStatmentForRef(_DateFrom As String, _DateTo As String, Referance As String, Currency As Integer)

        Try
            _RefType = 0
            GridControl1.DataSource = ""
            Dim SqlString As String = String.Empty
            Dim JouranlTable As New DataTable
            Dim RefData = GetRefranceData(Referance)
            _RefType = RefData.RefType
            Dim AccData = GetFinancialAccountsData(RefData.RefAccID)
            Dim AccCurr = AccData.Currency
            SqlString = " Select J.ID "
            If CheckTarteeb.Checked = True Then
                SqlString += ", IsNull(TarteebID,0) as TarteebID"
            Else
                SqlString += ", '0' as TarteebID"
            End If
            SqlString += "  ,J.[DocID],[DocDate],D.Name as DocName,D.NameEn as DocNameEn,DocName as DocNameValue, c.CostName,[DebitAcc],[CredAcc],[AccountCurr],
                            [DocAmount],[ExchangePrice],[BaseCurrAmount],BaseAmount,
                             U.Code as DocCurrency,J.DocCode,DS.DocStatus,DocID2,DocNoteByAccount,DocManualNo"
            If Currency = _DefaultCurr Then
                SqlString += ",Case when CredAcc ='0'  then [BaseCurrAmount] else 0 end as DebitAmount"
                SqlString += ",Case when DebitAcc ='0' then [BaseCurrAmount] else 0 end as CredAmount "
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += ",Case when CredAcc ='0'  then [BaseAmount] else 0 end as DebitAmount"
                SqlString += ",Case when DebitAcc ='0' then [BaseAmount] else 0 end as CredAmount "
            Else
                Exit Sub
            End If
            SqlString += ",Case when DebitAcc ='0' then -[BaseCurrAmount] else [BaseCurrAmount] end as ToBaseAmount "
            SqlString += ", J.DocSort,[Referance],[DocManualNo],A.AccName,AA.AccName 
                      , Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes
                              , cast( 0 as decimal(10,2)) as  Balance,InputDateTime,IsNull(ModifiedDateTime,'1900-01-01') as ModifiedDateTime ,InputUser,PaidStatus,IsNull(DocTags,'') As DocTags
                           from Journal J
                           left join FinancialAccounts A on A.AccNo = J.CredAcc
                           left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                        
                           left join DocNames D on D.id = J.DocName 
                           left join DocSorts S on S.SortID = J.DocSort
                           left join CostCenter C on C.CostID = J.DocCostCenter
                           left join Currency U on U.CurrID=J.DocCurrency
                           left join DocStatus DS on DS.ID=J.DocStatus
                      where DocAmount <> 0 And J.DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')"
            SqlString += "  and (   DebitAcc = '" & RefData.RefAccID & "' OR CredAcc= '" & RefData.RefAccID & "') and  Referance = " & Referance

            If LookDocStatus.Text = "" Then LookDocStatus.EditValue = -1
            If LookDocStatus.EditValue <> -1 Then
                SqlString += " And J.DocStatus = " & LookDocStatus.EditValue
            End If


            If GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) And LookCostCenter.EditValue <> -1 Then
                SqlString += " and (  DocCostCenter=" & LookCostCenter.EditValue & "  ) "
            End If

            If CheckTarteeb.Checked = True Then
                SqlString += " order by TarteebID desc"
            Else

                If _SortByModifiedDate = True Then
                    SqlString += " order by DocDate,J.ModifiedDateTime"
                Else
                    SqlString += " order by DocDate,J.DocName,DocID"
                End If

            End If

            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(SqlString)
            JouranlTable = sql.SQLDS.Tables(0)

            If CheckCalcOpenBalance.Checked = True Then
                Dim BegBalce As Decimal
                Dim R As DataRow = JouranlTable.NewRow
                If CheckTarteeb.Checked = False Then
                    BegBalce = GetBegBalanceForRef(Referance, _DateFrom, _DateTo, Currency, LookCostCenter.EditValue)
                Else
                    BegBalce = GetBegBalanceForRefForTarteebMode(Referance, _DateFrom, _DateTo, Currency, LookCostCenter.EditValue)
                End If

                If BegBalce > 0 Then R("DebitAmount") = BegBalce
                If BegBalce < 0 Then R("CredAmount") = Math.Abs(BegBalce)
                R("DocDate") = CDate(_DateFrom).AddDays(-1)

                If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
                    R("DocNotes") = "Begining Balance ...  "
                Else
                    R("DocNotes") = "  رصيد مدور"
                End If

                If CheckTarteeb.Checked = True Then
                    R("TarteebID") = "1"
                Else
                    R("TarteebID") = "0"
                End If
                JouranlTable.Rows.Add(R)
            End If


            If CheckShowUnDueChecks.Checked = True Then
                Dim _checksnote As String
                Dim R As DataRow = JouranlTable.NewRow
                '_checksnote = "شيكات صادرة "
                Dim _UnDueChecks = GetSumForNotDueCheks(Referance)
                _checksnote = "  الرصيد يشمل الشيكات غير المستحقة " & "(" & _UnDueChecks._Count & ")"
                R("DebitAmount") = _UnDueChecks._Sum
                R("CredAmount") = 0
                R("DocDate") = Today
                R("DocNotes") = _checksnote
                R("TarteebID") = "9999999"
                JouranlTable.Rows.Add(R)
                'R("TarteebID") = "9999999"
                'JouranlTable.Rows.Add(R)
            End If




            If CheckTarteeb.Checked = True Then
                JouranlTable.DefaultView.Sort = "TarteebID ASC , DocDate ASC"
            Else
                JouranlTable.DefaultView.Sort = "DocDate ASC"
            End If

            JouranlTable = JouranlTable.DefaultView.ToTable()


            For i As Integer = 0 To JouranlTable.Rows.Count - 1
                Dim row As DataRow = JouranlTable.Rows(i)
                Dim credit As Decimal = 0, debit As Decimal = 0, previousBalance As Decimal = 0, _Tarteb As Integer
                Decimal.TryParse(row("CredAmount").ToString(), credit)
                Decimal.TryParse(row("DebitAmount").ToString(), debit)
                Integer.TryParse(row("TarteebID").ToString(), _Tarteb)
                If i > 0 Then Decimal.TryParse(JouranlTable.Rows(i - 1)("Balance").ToString(), previousBalance)
                If CheckTarteeb.Checked = False Then
                    row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
                Else
                    If _Tarteb > 0 Then
                        row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
                    Else
                        row("Balance") = If(i = 0, 0 - 0, previousBalance - 0 + 0)
                    End If
                End If

            Next

            GridControl1.DataSource = JouranlTable
            '  GridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub GetAcountStatmentForRefWeb(_DateFrom As String, _DateTo As String, Referance As String, Currency As Integer)

        Try
            _RefType = 0
            GridControl1.DataSource = ""
            Dim SqlString As String = String.Empty
            Dim JouranlTable As New DataTable
            Dim RefData = GetRefranceData(Referance)
            _RefType = RefData.RefType
            Dim AccData = GetFinancialAccountsData(RefData.RefAccID)
            Dim AccCurr = AccData.Currency
            SqlString = " Select J.ID "
            SqlString += ", IsNull(TarteebID,0) as TarteebID"
            SqlString += "  ,J.[DocID],[DocDate],D.Name as DocName,DocName as DocNameValue, c.CostName,[DebitAcc],[CredAcc],[AccountCurr],
                            [DocAmount],[ExchangePrice],[BaseCurrAmount],BaseAmount,
                             U.Code as DocCurrency,J.DocCode,DS.DocStatus,DocID2,DocNoteByAccount,DocManualNo"
            If Currency = _DefaultCurr Then
                SqlString += ",Case when CredAcc ='0'  then [BaseCurrAmount] else 0 end as DebitAmount"
                SqlString += ",Case when DebitAcc ='0' then [BaseCurrAmount] else 0 end as CredAmount "
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += ",Case when CredAcc ='0'  then [BaseAmount] else 0 end as DebitAmount"
                SqlString += ",Case when DebitAcc ='0' then [BaseAmount] else 0 end as CredAmount "
            Else
                Exit Sub
            End If
            SqlString += ",Case when DebitAcc ='0' then -[BaseCurrAmount] else [BaseCurrAmount] end as ToBaseAmount "
            SqlString += ", J.DocSort,[Referance],[DocManualNo],A.AccName,AA.AccName 
                      , Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes
                              , cast( 0 as decimal(10,2)) as  Balance,InputDateTime,InputUser,PaidStatus
                           from Journal J
                           left join FinancialAccounts A on A.AccNo = J.CredAcc
                           left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                        
                           left join DocNames D on D.id = J.DocName 
                           left join DocSorts S on S.SortID = J.DocSort
                           left join CostCenter C on C.CostID = J.DocCostCenter
                           left join Currency U on U.CurrID=J.DocCurrency
                           left join DocStatus DS on DS.ID=J.DocStatus
                      where DocAmount <> 0 And J.DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')"
            SqlString += "  and (   DebitAcc = '" & RefData.RefAccID & "' OR CredAcc= '" & RefData.RefAccID & "') and  Referance = " & Referance

            If GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) And LookCostCenter.EditValue <> -1 Then
                SqlString += " and (  DocCostCenter=" & LookCostCenter.EditValue & "  ) "
            End If

            SqlString += " order by DocDate,J.DocName,DocID"


            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(SqlString)
            JouranlTable = sql.SQLDS.Tables(0)


            Dim BegBalce As Decimal
            Dim R As DataRow = JouranlTable.NewRow
            BegBalce = GetBegBalanceForRef(Referance, _DateFrom, _DateTo, Currency, LookCostCenter.EditValue)

            If BegBalce > 0 Then R("DebitAmount") = BegBalce
            If BegBalce < 0 Then R("CredAmount") = Math.Abs(BegBalce)
            R("DocDate") = CDate(_DateFrom).AddDays(-1)
            If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
                R("DocNotes") = "Begining Balance ...  "
            Else
                R("DocNotes") = "  رصيد مدور"
            End If
            R("TarteebID") = "0"
            JouranlTable.Rows.Add(R)
            Dim _checksnote As String
            Dim Rr As DataRow = JouranlTable.NewRow
            '_checksnote = "شيكات صادرة "
            Dim _UnDueChecks = GetSumForNotDueCheks(Referance)
            _checksnote = "  الرصيد يشمل الشيكات غير المستحقة " & "(" & _UnDueChecks._Count & ")"
            Rr("DebitAmount") = _UnDueChecks._Sum
            Rr("CredAmount") = 0
            Rr("DocDate") = Today
            Rr("DocNotes") = _checksnote
            Rr("TarteebID") = "9999999"
            JouranlTable.Rows.Add(Rr)






            JouranlTable.DefaultView.Sort = "DocDate ASC"


            JouranlTable = JouranlTable.DefaultView.ToTable()


            For i As Integer = 0 To JouranlTable.Rows.Count - 1
                Dim row As DataRow = JouranlTable.Rows(i)
                Dim credit As Decimal = 0, debit As Decimal = 0, previousBalance As Decimal = 0, _Tarteb As Integer
                Decimal.TryParse(row("CredAmount").ToString(), credit)
                Decimal.TryParse(row("DebitAmount").ToString(), debit)
                Integer.TryParse(row("TarteebID").ToString(), _Tarteb)
                If i > 0 Then Decimal.TryParse(JouranlTable.Rows(i - 1)("Balance").ToString(), previousBalance)
                row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
            Next

            GridControl1.DataSource = JouranlTable
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub GetAcountStatmentForAcc(_DateFrom As String, _DateTo As String, AccountID As String, Currency As Integer)
        GridControl1.DataSource = ""
        Dim SqlString As String = String.Empty
        Dim JouranlTable As New DataTable

        Dim AccData = GetFinancialAccountsData(AccountID)
        Dim AccCurr = AccData.Currency
        Dim isMain As Boolean = AccData.IsMain
        Dim fatherAccount As String = AccData.FatherAccount

        SqlString = " Select J.ID "
        If CheckTarteeb.Checked = True Then
            SqlString += ", IsNull(TarteebID,0) as TarteebID"
        Else
            SqlString += ", '0' as TarteebID"
        End If
        SqlString += "  ,J.[DocID],[DocDate],D.Name as DocName,DocName as DocNameValue, c.CostName,[DebitAcc],[CredAcc],[AccountCurr],
                            [DocAmount],[ExchangePrice],[BaseCurrAmount],BaseAmount,
                             U.Code as DocCurrency,J.DocCode,DS.DocStatus,DocID2,DocNoteByAccount,DocManualNo,ReferanceName"
        If Currency = _DefaultCurr Then
            SqlString += ",Case when CredAcc ='0'  then [BaseCurrAmount] else 0 end as DebitAmount"
            SqlString += ",Case when DebitAcc ='0' then [BaseCurrAmount] else 0 end as CredAmount "
        ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
            SqlString += ",Case when CredAcc ='0'  then [BaseAmount] else 0 end as DebitAmount"
            SqlString += ",Case when DebitAcc ='0' then [BaseAmount] else 0 end as CredAmount "
        Else
            Exit Sub
        End If
        SqlString += ",Case when DebitAcc ='0' then -[BaseCurrAmount] else [BaseCurrAmount] end as ToBaseAmount "
        SqlString += ", J.DocSort,[Referance],[DocManualNo],A.AccName,AA.AccName 
                      , Case when DocNoteByAccount is null or DocNoteByAccount='' then J.DocNotes else Concat(J.DocNotes,' (',DocNoteByAccount,')') end as DocNotes
                              ,cast( 0 as decimal(10,2)) as  Balance,InputDateTime,InputUser,DocTags
                           from Journal J
                           left join FinancialAccounts A on A.AccNo = J.CredAcc
                           left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                         
                           left join DocNames D on D.id = J.DocName 
                           left join DocSorts S on S.SortID = J.DocSort
                           left join CostCenter C on C.CostID = J.DocCostCenter
                           left join Currency U on U.CurrID=J.DocCurrency
                           left join DocStatus DS on DS.ID=J.DocStatus
                      where DocAmount <> 0 And J.DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')"


        SqlString += " and (   DebitAcc = '" & AccountID & "' OR CredAcc= '" & AccountID & "')"
        'SqlString += " and (   A.FatherAccount = '" & fatherAccount & "' OR CredAcc= '" & fatherAccount & "')"

        If GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) And LookCostCenter.EditValue <> -1 Then
            SqlString += " and (  DocCostCenter=" & LookCostCenter.EditValue & "  ) "
        End If

        If LookDocStatus.EditValue <> -1 Then
            SqlString += " And J.DocStatus = " & LookDocStatus.EditValue
        End If

        If CheckTarteeb.Checked = True Then
            SqlString += " order by TarteebID"
        Else
            '        SqlString += " order by DocDate,J.DocName,DocID"
            If _SortByModifiedDate = True Then
                SqlString += " order by DocDate,J.InputDateTime"
            Else
                SqlString += " order by DocDate,J.DocName,DocID"
            End If
        End If

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(SqlString)
        JouranlTable = sql.SQLDS.Tables(0)

        If CheckCalcOpenBalance.Checked = True Then
            Dim BegBalce As Decimal
            Dim R As DataRow = JouranlTable.NewRow
            If CheckTarteeb.Checked = False Then
                BegBalce = GetBegBalanceForAcc(AccountID, _DateFrom, _DateTo, Currency, LookCostCenter.EditValue)
            Else
                BegBalce = GetBegBalanceForAccForTarteebMode(AccountID, _DateFrom, _DateTo, Currency, LookCostCenter.EditValue)
            End If

            If BegBalce > 0 Then R("DebitAmount") = BegBalce
            If BegBalce < 0 Then R("CredAmount") = Math.Abs(BegBalce)
            R("DocDate") = CDate(_DateFrom).AddDays(-1)
            If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
                R("DocNotes") = "Begining Balance ...  "
            Else
                R("DocNotes") = "  رصيد مدور"
            End If
            If CheckTarteeb.Checked = True Then
                R("TarteebID") = "1"
            Else
                R("TarteebID") = "0"
            End If
            JouranlTable.Rows.Add(R)
        End If


        If CheckTarteeb.Checked = True Then
            JouranlTable.DefaultView.Sort = "TarteebID ASC , DocDate ASC"
        Else
            JouranlTable.DefaultView.Sort = "DocDate ASC"
        End If

        JouranlTable = JouranlTable.DefaultView.ToTable()


        For i As Integer = 0 To JouranlTable.Rows.Count - 1
            Dim row As DataRow = JouranlTable.Rows(i)
            Dim credit As Decimal = 0, debit As Decimal = 0, previousBalance As Decimal = 0, _Tarteb As Integer
            Decimal.TryParse(row("CredAmount").ToString(), credit)
            Decimal.TryParse(row("DebitAmount").ToString(), debit)
            Integer.TryParse(row("TarteebID").ToString(), _Tarteb)
            If i > 0 Then Decimal.TryParse(JouranlTable.Rows(i - 1)("Balance").ToString(), previousBalance)
            If CheckTarteeb.Checked = False Then
                row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
            Else
                If _Tarteb > 0 Then
                    row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
                Else
                    row("Balance") = If(i = 0, 0 - 0, previousBalance - 0 + 0)
                End If
            End If
        Next






        GridControl1.DataSource = JouranlTable
        '  GridView1.BestFitColumns()

    End Sub


    Private Function GetCurrenciesForReport(AccountCurr As Integer) As DataTable
        Dim Currency As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select Code,CurrID from Currency where IsDefault=1 or CurrID=" & AccountCurr
            Sql.SqlTrueAccountingRunQuery(SqlString)
            Currency = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return Currency
    End Function
    'ColBaseCurrAmount
    Private Sub AccountStatmentForReferance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim _Currnecy As DataTable = GetCurrency()
        'Dim R As DataRow = _Currnecy.NewRow
        'R("CurrID") = -1
        'R("Code") = "كل العملات"
        '_Currnecy.Rows.Add(R)
        ' Me.GridView1.Appearance.HeaderPanel.HAlignment = HorzAlignment.Near

        SearchReferance.Properties.DataSource = GetReferences(1, -1, -1)


        TheAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
        Me.RepositoryPaidStatus.DataSource = GetDocPaidStatus(False)
        'Currency.Properties.DataSource = _Currnecy
        Me.KeyPreview = True
        'Currency.EditValue = 1

        ' LayoutByAcc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never




        ColDocAmount.Visible = False
        ColExchangePrice.Visible = False
        ColDocStatus.Visible = False
        ColDocCurrency.Visible = False
        If _ShowCostCenter = True Then
            LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.LookCostCenter.Properties.DataSource = GetCostCenter(True)
            LookCostCenter.EditValue = -1
        Else
            LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If


        Me.LookDocStatus.Properties.DataSource = GetDocStatus(True)
        LookDocStatus.EditValue = -1
        GetSettings()
        'ColInputUser.Visible = False
        'ColInputDateTime.Visible = False

        ColDocID.Width = 70
        ColDocDate.Width = 100
        ColDocName.Width = 120
        ColDebitAmount.Width = 110
        ColCredAmount.Width = 110
        ColBalance.Width = 110
        ColDocCurrency.Width = 70
        ColDocStatus.Width = 70
        ColExchangePrice.Width = 70
        ColBaseCurrAmount.Width = 110
        ColDocAmount.Width = 110
        ColDocManualNo.Width = 110

        If _OpenForPrint = True Then
            Select Case _PrintOption
                Case "SendWhatsApp"
                    PrintReport("Pdf")
                    Dim _RefData = GetRefranceData(SearchReferance.EditValue)
                    SendFileToWhatsApp(_RefData.RefMobile, "AccountStatment.pdf", "كشف حساب", "", Me.SearchReferance.Text)
                Case "Print"
                    PrintReport("Print")
            End Select
            Me.Close()
        Else
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" SELECT SettingValue FROM Settings WHERE SettingName='AccountingDateStartFromCurrentMonthInAccountStatment'  ")
            If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = True Then
                Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), Format(Today, "MM"), 1)
                Dim DateTo As DateTime = Today
                DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
                DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
            Else
                Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
                Dim DateTo As DateTime = Today
                DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
                DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
            End If

        End If
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim sqlString As String = "
        SELECT SettingName, SettingValue 
        FROM [Settings] 
        WHERE SettingName IN (
            'SortByModifiedDateInAccountingStatment',
            'Accounting_ShowInputDateTimeFieldInAccountingStatment'
        )"
        Try
            sql.SqlTrueAccountingRunQuery(sqlString)

            ' Create dictionary of settings
            Dim settings As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
            For Each row As DataRow In sql.SQLDS.Tables(0).Rows
                Dim name As String = row("SettingName").ToString()
                Dim value As Boolean
                Boolean.TryParse(row("SettingValue").ToString(), value)
                settings(name) = value
            Next

            ' Assign values with fallback
            _SortByModifiedDate = If(settings.ContainsKey("SortByModifiedDateInAccountingStatment"),
                                 settings("SortByModifiedDateInAccountingStatment"), False)

            _ShowInputDateTimeField = If(settings.ContainsKey("Accounting_ShowInputDateTimeFieldInAccountingStatment"),
                                     settings("Accounting_ShowInputDateTimeFieldInAccountingStatment"), False)

            ColInputDateTime.Visible = _ShowInputDateTimeField
            If _ShowInputDateTimeField Then
                ColInputDateTime.VisibleIndex = 3
            End If
        Catch ex As Exception
            ' Fallback to defaults
            _SortByModifiedDate = False
            _ShowInputDateTimeField = False

            ' Optional: log error
            ' Logger.LogError("Error in GetSettings: " & ex.Message)
        End Try
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshDataInAccountStatmentForRef()
        ElseIf e.Control AndAlso e.KeyCode = Keys.J Then
            ShowQuickJournal()
        End If
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged_1(sender As Object, e As EventArgs)

    End Sub
    Private Function GetBegBalanceForRef(RefNo As Integer, _DateFrom As String, _DateTo As String, Currency As Integer, CostCenter As Integer) As Decimal
        Dim RefData = GetRefranceData(RefNo)
        Dim AccData = GetFinancialAccountsData(RefData.RefAccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal
        Dim _SearchType As String
        ' _SearchType = " where 1=1 "
        _SearchType = " and (   DebitAcc ='" & RefData.RefAccID & "' OR CredAcc= '" & RefData.RefAccID & "') and  Referance = " & RefNo
        If CostCenter <> -1 And GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) Then
            _SearchType += " And DocCostCenter=" & CostCenter
        End If
        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where  DocStatus > 0 and  CredAcc ='0'  and [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where DocStatus > 0 and DebitAcc ='0' and  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  DocStatus > 0 And  CredAcc ='0'  And [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where DocStatus > 0 And DebitAcc ='0' And  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Function GetBegBalanceForRefForTarteebMode(RefNo As Integer, _DateFrom As String, _DateTo As String, Currency As Integer, CostCenter As Integer) As Decimal
        Dim RefData = GetRefranceData(RefNo)
        Dim AccData = GetFinancialAccountsData(RefData.RefAccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal
        Dim _SearchType As String
        _SearchType = "   "
        _SearchType += " and (   DebitAcc ='" & RefData.RefAccID & "' OR CredAcc= '" & RefData.RefAccID & "') and  Referance = " & RefNo
        If CostCenter <> -1 And GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) Then
            _SearchType += " And DocCostCenter=" & CostCenter
        End If

        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and  CredAcc ='0'  and [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and DebitAcc ='0' and  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  TarteebID > 0 And DocStatus > 0 And  CredAcc ='0'  And [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 And DebitAcc ='0' And  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Function GetBegBalanceForAccForTarteebMode(AccID As String, _DateFrom As String, _DateTo As String, Currency As Integer, CostCenter As Integer) As Decimal
        Dim AccData = GetFinancialAccountsData(AccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal = 0
        Dim _SearchType As String = "  "
        _SearchType = " and (   DebitAcc = '" & AccID & "' OR CredAcc= '" & AccID & "') "
        If CostCenter <> -1 And GlobalVariables._ShowCostCenter = True And Not IsNothing(LookCostCenter.EditValue) Then
            _SearchType += " And DocCostCenter=" & CostCenter
        End If
        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where TarteebID > 0 And  DocStatus > 0 and  CredAcc ='0'  and [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and DebitAcc ='0' and  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  TarteebID > 0 And DocStatus > 0 And  CredAcc ='0'  And [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 And DebitAcc ='0' And  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Function GetEndBalanceForRefForTarteebMode(RefNo As Integer, Currency As Integer) As Decimal
        Dim RefData = GetRefranceData(RefNo)
        Dim AccData = GetFinancialAccountsData(RefData.RefAccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal = 0
        Dim _SearchType As String = "  "
        _SearchType = " and (   DebitAcc ='" & RefData.RefAccID & "' OR CredAcc= '" & RefData.RefAccID & "') and  Referance = " & RefNo

        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and  CredAcc ='0'   " & "  " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and DebitAcc ='0'  " & "  " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  TarteebID > 0 And DocStatus > 0 And  CredAcc ='0'    " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 And DebitAcc ='0'    " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Function GetEndBalanceForAccForTarteebMode(AccID As String, Currency As Integer) As Decimal
        Dim AccData = GetFinancialAccountsData(AccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal = 0
        Dim _SearchType As String = "  "
        _SearchType = " and (   DebitAcc = '" & AccID & "' OR CredAcc= '" & AccID & "') "
        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where TarteebID > 0 And  DocStatus > 0 and  CredAcc ='0'    " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 and DebitAcc ='0'    " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  TarteebID > 0 And DocStatus > 0 And  CredAcc ='0'     " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where TarteebID > 0 And DocStatus > 0 And DebitAcc ='0'     " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function
    Private Function GetBegBalanceForAcc(AccID As String, _DateFrom As String, _DateTo As String, Currency As Integer, CostCenter As Integer) As Decimal
        Dim AccData = GetFinancialAccountsData(AccID)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal = 0
        Dim _SearchType As String = "  "
        _SearchType = " and (   DebitAcc = '" & AccID & "' OR CredAcc= '" & AccID & "') "
        Try
            Dim SqlString As String = "select D.DebitAmount-C.CreditAmount as BeginBalance from "
            If Currency = _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseCurrAmount),0) as DebitAmount from [Journal] Where  DocStatus > 0 and  CredAcc ='0'  and [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseCurrAmount),0) as CreditAmount from [Journal] Where DocStatus > 0 and DebitAcc ='0' and  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"
            ElseIf Currency = AccCurr And Currency <> _DefaultCurr Then
                SqlString += "
(select isnull(sum(BaseAmount),0) as DebitAmount from [Journal] Where  DocStatus > 0 And  CredAcc ='0'  And [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & ") as D,
(select isnull(sum(BaseAmount),0) as CreditAmount from [Journal] Where DocStatus > 0 And DebitAcc ='0' And  [DocDate] < '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "'  " & _SearchType & "  ) as C"

            End If
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _BegBalance = Sql.SQLDS.Tables(0).Rows(0).Item("BeginBalance")
        Catch ex As Exception
            _BegBalance = 0
        End Try

        Return _BegBalance
    End Function


    'Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

    '    Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)



    '    pb.PageSettings.Landscape = False
    '    pb.PageSettings.LeftMargin = 0
    '    pb.PageSettings.RightMargin = 0
    '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
    '    Dim sql As New SQLControl
    '    Dim SQLString As String = "Select *  from CompanyData"
    '    sql.SqlTrueTimeRunQuery(SQLString)

    '    If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
    '    Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")


    '    'Try
    '    '    Dim cn As SqlConnection
    '    '    cn = New SqlConnection
    '    '    cn.ConnectionString = My.Settings.TrueTimeConnectionString
    '    '    Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
    '    '    cn.Open()
    '    '    cmd.Connection = cn
    '    '    cmd.CommandType = CommandType.Text
    '    '    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
    '    '    .XrPictureBox1.Image = Image.FromStream(ImgStream)
    '    '    ImgStream.Dispose()
    '    '    cmd.Connection.Close()
    '    '    cn.Close()
    '    'Catch ex As Exception

    '    'End Try


    '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
    '                                                                               {"  ", Now(), "Pages: [Page # of Pages #]"})
    '    If CheckReportForRef.Text = "True" Then
    '        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
    '            (Currency.Text & " " & "كشف حساب : " & SearchReferance.Text & " ")
    '    Else
    '        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
    '            (Currency.Text & " " & "كشف حساب : " & TheAccount.Text)
    '    End If
    '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
    '    Dim _FromToDate As String = " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
    '    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    'End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        '' GridControl1.ShowPrintPreview()
        ''   Dim report As New XtraReport1
        ''  report.PrintableComponentContainer1.PrintableComponent = Me.GridControl1



        ''Dim options As New ReportGenerationOptions()
        ''options.PrintGroupSummaryFooter = DefaultBoolean.True
        ''Dim report As XtraReport = ReportGenerator.GenerateReport(GridView1, options)
        ''report.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        ''report.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes

        ''report.ShowPreview()

        'Dim _HeaderImage, _FooterImage As Image
        '_HeaderImage = Nothing
        '_FooterImage = Nothing
        'Try
        '    Dim cn As SqlConnection
        '    cn = New SqlConnection
        '    cn.ConnectionString = My.Settings.TrueTimeConnectionString
        '    Dim cmd As New System.Data.SqlClient.SqlCommand("select HeaderImage from [dbo].[CompanyData]  ")
        '    cn.Open()
        '    cmd.Connection = cn
        '    cmd.CommandType = CommandType.Text
        '    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
        '    _HeaderImage = Image.FromStream(ImgStream)
        '    ImgStream.Dispose()
        '    cmd.Connection.Close()
        '    cn.Close()
        'Catch ex As Exception

        'End Try
        'Try
        '    Dim cn As SqlConnection
        '    cn = New SqlConnection
        '    cn.ConnectionString = My.Settings.TrueTimeConnectionString
        '    Dim cmd As New System.Data.SqlClient.SqlCommand("select FooterImage from [dbo].[CompanyData]  ")
        '    cn.Open()
        '    cmd.Connection = cn
        '    cmd.CommandType = CommandType.Text
        '    Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
        '    _FooterImage = Image.FromStream(ImgStream)
        '    ImgStream.Dispose()
        '    cmd.Connection.Close()
        '    cn.Close()
        'Catch ex As Exception

        'End Try



        'Dim sql As New SQLControl
        'Dim SQLString As String = "Select *  from CompanyData"
        'sql.SqlTrueTimeRunQuery(SQLString)
        'If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        'Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")

        '' Create a printing system.
        'Dim printingSystem1 As New PrintingSystem()

        ''Create a link to print the Grid control.
        'Dim printableComponentLink1 As New PrintableComponentLink()
        ''printingSystem1.Watermark.Image = _Image
        ''printingSystem1.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Stretch
        ''printingSystem1.Watermark.ImageTransparency = 50
        '' Specify the link's printable component.
        'printableComponentLink1.Component = GridControl1

        '' Assign the printing system to this link.
        'printableComponentLink1.PrintingSystem = printingSystem1
        'printableComponentLink1.RightToLeftLayout = RightToLeft
        'printableComponentLink1.Margins.Right = 50
        'printableComponentLink1.Margins.Left = 50
        'printableComponentLink1.Margins.Top = 150
        'printableComponentLink1.Margins.Bottom = 100
        '' Add an image to the link's image collection.
        'printableComponentLink1.Images.Add(_HeaderImage)
        'printableComponentLink1.Images.Add(_FooterImage)
        '' printableComponentLink1.Images.Item(0).siz

        'Dim pgHArea As New PageHeaderArea()
        'pgHArea.Content.AddRange(New String() {"", "", "[Image 0]"})

        'Dim pgFArea As New PageFooterArea()
        'pgFArea.Content.AddRange(New String() {"", " ", "[Image 1]"})

        '' Create a PageHeaderFooter object for this link.
        'printableComponentLink1.PageHeaderFooter = New PageHeaderFooter(pgHArea, pgFArea)


        ''TryCast(printableComponentLink1.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
        ''                                                                              {"  ", Now(), "Pages: [Page # of Pages #]"})

        ''TryCast(printableComponentLink1.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
        ''    (Currency.Text & " " & "كشف حساب : " & SearchReferance.Text & " ")
        'Dim _FromToDate As String = " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
        ''TryCast(printableComponentLink1.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
        'GridView1.ViewCaption = " " & "كشف حساب : " & SearchReferance.Text & " " & Currency.Text & " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
        ''    If CheckReportForRef.Text = "True" Then
        ''        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
        ''            (Currency.Text & " " & "كشف حساب : " & SearchReferance.Text & " ")
        ''    Else
        ''        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
        ''            (Currency.Text & " " & "كشف حساب : " & TheAccount.Text)
        ''    End If
        ''    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        ''    Dim _FromToDate As String = " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
        ''    TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)


        '' Preview the report.
        'printableComponentLink1.ShowPreviewDialog()

        PrintReport("Preview")
    End Sub
    Private Sub PrintReport(_option As String)

        ColDocID.Width = 50
        ColDocDate.Width = 70
        ColDocName.Width = 70
        ColDebitAmount.Width = 70
        ColCredAmount.Width = 70
        ColBalance.Width = 70
        ColDocCurrency.Width = 50
        ColDocStatus.Width = 50
        ColExchangePrice.Width = 50
        ColBaseCurrAmount.Width = 70
        ColDocAmount.Width = 70
        ColDocManualNo.Width = 70
        ColDocNotes.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
        ColDocNotes.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far
        Dim report As New ReportAccountStatment
        With report
            .XrLabelReforAcc.Text = CheckReportForRef.Text
            .XrLabelPeriod.Text = " من تاريخ: " & DateEditFrom.DateTime & " " & " إلى تاريخ " & DateEditTo.DateTime
            If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
                .XrLabelPeriod.Text = " From Date: " & DateEditFrom.DateTime & " " & " To Date: " & DateEditTo.DateTime
                ColDocID.Caption = "Doc. No."
                ColDocManualNo.Caption = "Referance"
                ColDocDate.Caption = "Date"
                ColDocName.Caption = "Document"
                ColDocNotes.Caption = "Notes"
                ColDocAmount.Caption = "Amount"
                ColDocCurrency.Caption = "Currency"
                ColExchangePrice.Caption = "Exch.Price"
                ColDebitAmount.Caption = "Debit"
                ColCredAmount.Caption = "Credit"
                ColBalance.Caption = "Balance"
                ColDocument.VisibleIndex = 3
                ColDocName.Visible = False

                Me.GridView1.AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center
                '  Me.GridView1.OptionsPrint.PrintFooter = True
                '    Me.GridView1.OptionsPrint.RtfReportFooter = False


                ColDocNotes.AppearanceCell.TextOptions.HAlignment = VertAlignment.Center
                ColDocID.AppearanceCell.TextOptions.HAlignment = VertAlignment.Center
                ColDocManualNo.AppearanceCell.TextOptions.HAlignment = VertAlignment.Center
                ColDocDate.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColDocName.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColDocNotes.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColDocAmount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColDocCurrency.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColExchangePrice.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColDebitAmount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColCredAmount.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center
                ColBalance.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

            End If

            .XrLabelCurrency.Text = Currency.Text
            If CheckReportForRef.Text = "True" Then
                .XrLabelAccountName.Text = SearchReferance.EditValue & " / " & SearchReferance.Text
            Else
                .XrLabelAccountName.Text = TheAccount.EditValue & " / " & TheAccount.Text
            End If
            .PrintableComponentContainer1.PrintableComponent = Me.GridControl1
            Try
                Select Case _option
                    Case "Preview"
                        .ShowPreviewDialog()
                    Case "Print"
                        .Print()
                    Case "Pdf"
                        .ExportToPdf("AccountStatment.pdf")
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End With
        ColDocID.Width = 70
        ColDocDate.Width = 100
        ColDocName.Width = 120
        ColDebitAmount.Width = 110
        ColCredAmount.Width = 110
        ColBalance.Width = 110
        ColDocCurrency.Width = 70
        ColDocStatus.Width = 70
        ColExchangePrice.Width = 70
        ColBaseCurrAmount.Width = 110
        ColDocAmount.Width = 110
        ColDocManualNo.Width = 110
        ColDocNotes.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near
        ColDocNotes.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Near
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        'OpenDoc()
    End Sub


    Private Sub OpenDoc()

        '  Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            '  Handle = ShowProgressPanel()
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
        Finally
            ' CloseProgressPanel(Handle)
        End Try



    End Sub

    Private Sub SearchReferance_EditValueChanged(sender As Object, e As EventArgs) Handles SearchReferance.EditValueChanged
        Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        Dim _AccData = GetFinancialAccountsData(_RefData.RefAccID)
        Currency.Properties.DataSource = GetCurrenciesForReport(_AccData.Currency)
        Currency.EditValue = _AccData.Currency
        If Me.IsHandleCreated Then
            RefreshDataInAccountStatmentForRef()
        End If
        If _OpenForPrint = True Then
            RefreshDataInAccountStatmentForRef()
        End If
    End Sub

    Private Sub CheckShowBaseAmount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowBaseAmount.CheckedChanged
        If CheckShowBaseAmount.Checked = True Then
            ' ColBaseCurrAmount.Visible = True
            'Dim i As Integer = ColDebitAmount.VisibleIndex + 3
            ColExchangePrice.VisibleIndex = ColDebitAmount.VisibleIndex - 0
            ColDocCurrency.VisibleIndex = ColDebitAmount.VisibleIndex - 1
            ColDocAmount.VisibleIndex = ColDebitAmount.VisibleIndex - 2




        Else
            'ColBaseCurrAmount.Visible = False
            ColExchangePrice.Visible = False
            ColDocCurrency.Visible = False
            ColDocAmount.Visible = False
        End If
        GridView1.BestFitColumns()
    End Sub

    Private Sub AccountForRefranace_EditValueChanged(sender As Object, e As EventArgs) Handles TheAccount.EditValueChanged

        Dim _AccData = GetFinancialAccountsData(TheAccount.EditValue)
        Currency.Properties.DataSource = GetCurrenciesForReport(_AccData.Currency)
        Currency.EditValue = _AccData.Currency
    End Sub
    Private Sub CheckReportForRef_EditValueChanged(sender As Object, e As EventArgs) Handles CheckReportForRef.EditValueChanged
        If CheckReportForRef.Text = "True" Then
            LayoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            BarButtonSendByWhatsApp.Visibility = XtraBars.BarItemVisibility.Always
            BarButtonItemRefData.Visibility = XtraBars.BarItemVisibility.Always
            LayoutControlItemShowCheqsBalance.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlShowPaidStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            BarButtonSendByWhatsApp.Visibility = XtraBars.BarItemVisibility.Never
            ColDocManualNo.Visible = -1
            BarButtonItemRefData.Visibility = XtraBars.BarItemVisibility.Never
            LayoutControlItemShowCheqsBalance.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlShowPaidStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub
    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = 15001 Then
                e.TotalValue = (ColDebitAmount.SummaryItem.SummaryValue - ColCredAmount.SummaryItem.SummaryValue)
            End If
        End If
    End Sub

    Private Sub RepositoryOpen_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs)

    End Sub

    Private Sub RepositoryOpen_Click(sender As Object, e As EventArgs) Handles RepositoryOpen.Click
        OpenDoc()
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub CheckCalcOpenBalance_CheckedChanged(sender As Object, e As EventArgs) Handles CheckCalcOpenBalance.CheckedChanged

    End Sub



    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkDocNo.OpenLink
        OpenDoc()
    End Sub

    Private Sub Currency_EditValueChanged(sender As Object, e As EventArgs) Handles Currency.EditValueChanged
        'ColDebitAmount.Caption = "مدين" & "(" & Currency.Text & ")"
        'ColCredAmount.Caption = "دائن" & "(" & Currency.Text & ")"
        'ColBalance.Caption = "الرصيد" & "(" & Currency.Text & ")"
        'ColBalance.Caption = "  <color=green>(NIS)</color> الرصيد "
        ColBalance.Caption = " <size=-3> " & Currency.Text & " </size> الرصيد "
        ColCredAmount.Caption = " <size=-3> " & Currency.Text & " </size> دائن "
        ColDebitAmount.Caption = " <size=-3> " & Currency.Text & " </size> مدين "
    End Sub





    Private Sub Behavior_DragOver(ByVal sender As Object, ByVal e As DragOverEventArgs)

    End Sub



    Private Sub DragDropEvents1_DragDrop(sender As Object, e As DragDropEventArgs) Handles DragDropEvents1.DragDrop
        'Dim _ID, CurrentTarteeb, TarteebIDRowBefore As Integer
        'Dim sql As New SQLControl
        'Dim targetGrid As GridView = TryCast(e.Target, GridView)
        'Dim sourceGrid As GridView = TryCast(e.Source, GridView)
        'If e.Action = DragDropActions.None OrElse targetGrid IsNot sourceGrid Then Return
        'Dim sourceTable As DataTable = TryCast(sourceGrid.GridControl.DataSource, DataTable)
        'Dim hitPoint As Point = targetGrid.GridControl.PointToClient(Cursor.Position)
        'Dim hitInfo As GridHitInfo = targetGrid.CalcHitInfo(hitPoint)
        'Dim sourceHandles As Integer() = e.GetData(Of Integer())()
        'Dim targetRowHandle As Integer = hitInfo.RowHandle
        'Dim targetRowIndex As Integer = targetGrid.GetDataSourceRowIndex(targetRowHandle)
        'Dim draggedRows As List(Of DataRow) = New List(Of DataRow)()
        'For Each sourceHandle As Integer In sourceHandles
        '    Dim oldRowIndex As Integer = sourceGrid.GetDataSourceRowIndex(sourceHandle)
        '    Dim oldRow As DataRow = sourceTable.Rows(oldRowIndex)
        '    Dim BeforeRow As DataRow = sourceTable.Rows(oldRowIndex - 1)
        '    TarteebIDRowBefore = GridView1.GetRowCellValue(targetRowIndex, "TarteebID")
        '    draggedRows.Add(oldRow)
        'Next

        'Dim newRowIndex As Integer
        'Select Case e.InsertType
        '    Case InsertType.Before
        '        TarteebIDRowBefore = GridView1.GetRowCellValue(targetRowIndex - 1, "TarteebID")
        '        newRowIndex = If(targetRowIndex > sourceHandles(sourceHandles.Length - 1), targetRowIndex - 1, targetRowIndex)
        '        For i As Integer = draggedRows.Count - 1 To 0 Step -1
        '            TarteebIDRowBefore += 1
        '            Dim oldRow As DataRow = draggedRows(i)
        '            Dim newRow As DataRow = sourceTable.NewRow()
        '            newRow.ItemArray = oldRow.ItemArray
        '            sourceTable.Rows.Remove(oldRow)
        '            sourceTable.Rows.InsertAt(newRow, newRowIndex)
        '            _ID = newRow.Item("ID")
        '            sql.SqlTrueAccountingRunQuery(" Update Journal Set TarteebID=" & TarteebIDRowBefore & " where ID=" & _ID)
        '            sql.SqlTrueAccountingRunQuery(" Update Journal Set TarteebID=TarteebID+1 where TarteebID > " & TarteebIDRowBefore & " and Referance=" & SearchReferance.EditValue)
        '        Next

        '    Case InsertType.After
        '        TarteebIDRowBefore = GridView1.GetRowCellValue(targetRowIndex, "TarteebID")
        '        newRowIndex = If(targetRowIndex < sourceHandles(0), targetRowIndex + 1, targetRowIndex)
        '        For i As Integer = 0 To draggedRows.Count - 1
        '            TarteebIDRowBefore += 1
        '            Dim oldRow As DataRow = draggedRows(i)
        '            Dim newRow As DataRow = sourceTable.NewRow()
        '            newRow.ItemArray = oldRow.ItemArray
        '            sourceTable.Rows.Remove(oldRow)
        '            sourceTable.Rows.InsertAt(newRow, newRowIndex)
        '            _ID = newRow.Item("ID")
        '            sql.SqlTrueAccountingRunQuery(" Update Journal Set TarteebID=" & TarteebIDRowBefore & " where ID=" & _ID)
        '            sql.SqlTrueAccountingRunQuery(" Update Journal Set TarteebID=TarteebID+1 where TarteebID > " & TarteebIDRowBefore & " and Referance=" & SearchReferance.EditValue)
        '        Next

        '    Case Else
        '        newRowIndex = -1
        'End Select



        'Dim insertedIndex As Integer = targetGrid.GetRowHandle(newRowIndex)
        'targetGrid.FocusedRowHandle = insertedIndex
        'targetGrid.SelectRow(targetGrid.FocusedRowHandle)
        'Dim _handle As Integer = targetGrid.FocusedRowHandle
        'RefreshDataInAccountStatmentForRef()
        ''targetGrid.ClearSelection()
        ''targetGrid.SelectRow(insertedIndex - 1)

    End Sub

    Private Sub DragDropEvents1_DragOver(sender As Object, e As DragOverEventArgs) Handles DragDropEvents1.DragOver
        Dim args As DragOverGridEventArgs = DragOverGridEventArgs.GetDragOverGridEventArgs(e)
        e.InsertType = args.InsertType
        e.InsertIndicatorLocation = args.InsertIndicatorLocation
        e.Action = args.Action
        Cursor.Current = args.Cursor
        args.Handled = True
        'MsgBox("done")
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            GridView1.OptionsSelection.MultiSelect = True
            GridView1.SelectAll()
            GridView1.CopyToClipboard()
            GridView1.OptionsSelection.MultiSelect = False
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم نسخ التقرير بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
        Catch ex As Exception
            XtraMessageBox.Show("خطا في عملية النسخ ، يرجى اعادة المحاولة")
        End Try

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        ShowQuickJournal()
    End Sub
    Private Sub ShowQuickJournal()

        If CheckReportForRef.Text = "True" Then
            If Me.SearchReferance.Text = "" Then Exit Sub
            Dim f As JournalAddQuick = New JournalAddQuick(True, Me.SearchReferance.EditValue)
            With f
                .LabelControlAccountName.Text = " سند قيد مختصر  " & Me.SearchReferance.Text
                .DocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
                .GridJournal.DataSource = .EmptyJournal()
                .Text = "سند قيد مختصر"
                If .ShowDialog <> DialogResult.OK Then
                    GetAcountStatmentForRef(DateEditFrom.DateTime, DateEditTo.DateTime, SearchReferance.EditValue, Currency.EditValue)
                End If
            End With
        Else
            If Me.TheAccount.Text = "" Then Exit Sub
            Dim f As JournalAddQuick = New JournalAddQuick(False, Me.TheAccount.EditValue)
            With f
                .LabelControlAccountName.Text = " سند قيد مختصر  " & Me.TheAccount.Text
                .DocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
                .GridJournal.DataSource = .EmptyJournal()
                .Text = "سند قيد مختصر "
                If .ShowDialog <> DialogResult.OK Then
                    GetAcountStatmentForAcc(DateEditFrom.DateTime, DateEditTo.DateTime, TheAccount.EditValue, Currency.EditValue)
                End If
            End With
        End If
    End Sub

    Private Function GetSumForNotDueCheks(_RefNo As Integer) As (_Count As Integer, _Sum As Decimal)
        Dim _Count As Integer = 0
        Dim _Sum As Decimal = 0
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = " 
                        select count(CheckID) as Count,sum(CheckBaseAmount) as BaseAmount
                        from Checks
                        where CheckInOut='IN' and CheckDueDate > GETDATE() and Referance =" & _RefNo
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Count = sql.SQLDS.Tables(0).Rows(0).Item("Count")
            If _Count > 0 Then
                _Sum = sql.SQLDS.Tables(0).Rows(0).Item("BaseAmount")
            End If

        Catch ex As Exception

        End Try
        Return (_Count, _Sum)
    End Function

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
        ElseIf e.Column.FieldName = "DocTags" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocTags"))
            If category <> "" Then
                e.DisplayText = SetTagsColor(category)
                e.Appearance.Options.CancelUpdate()
            End If
        End If
    End Sub
    Private Sub GridControl1_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridControl1.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.F2 AndAlso view.SelectedRowsCount > 0 Then
            Tarteeb()
        End If
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Tarteeb()
    End Sub
    Private Sub Tarteeb()
        Dim focusedRow As Integer = GridView1.FocusedRowHandle
        If CheckTarteeb.Checked = True Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            Dim _RowTarteebID As Integer = 0
            Dim _ID As Integer
            _RowTarteebID = GridView1.GetFocusedRowCellValue("TarteebID")
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then
                _ID = GridView1.GetFocusedRowCellValue("ID")
                If _RowTarteebID = 0 Then
                    If CheckReportForRef.Text = "True" Then
                        sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where Referance =" & SearchReferance.EditValue & " ) where  ID=" & _ID
                        sql.SqlTrueAccountingRunQuery(sqlstring)
                    Else
                        sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where [DebitAcc] ='" & TheAccount.EditValue & "' or [CredAcc]='" & TheAccount.EditValue & "' ) where  ID=" & _ID
                        sql.SqlTrueAccountingRunQuery(sqlstring)
                    End If

                Else
                    GridView1.SetFocusedRowCellValue("TarteebID", 0)
                    sqlstring = " Update Journal Set TarteebID = 0  where  ID=" & _ID
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                End If

                RefreshDataInAccountStatmentForRef()
                'MsgBox(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue))
                If CheckReportForRef.Text = "True" Then
                    GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue), "N2")
                Else
                    GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForAccForTarteebMode(TheAccount.EditValue, Me.Currency.EditValue), "N2")
                End If

            End If
        Else
            OpenDoc()
        End If
        GridView1.FocusedRowHandle = focusedRow
    End Sub

    Private Sub CheckTarteeb_CheckedChanged(sender As Object, e As EventArgs) Handles CheckTarteeb.CheckedChanged

        Me.GridView1.OptionsView.ShowViewCaption = CheckTarteeb.CheckState
        If CheckTarteeb.Checked = True Then
            GridView1.ViewCaption = " كشف مطابقة "

            If CheckReportForRef.Text = "True" Then
                GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue), "N2")
            Else
                GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForAccForTarteebMode(TheAccount.EditValue, Me.Currency.EditValue), "N2")
            End If

        End If



        RefreshDataInAccountStatmentForRef()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        CreateNewDocument(2, SearchReferance.EditValue, 0, "", True)
        'RefreshDataInAccountStatmentForRef()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        CreateNewDocument(4, SearchReferance.EditValue, 0, "", True)
    End Sub

    Private Sub CheckShowDocPaid_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowDocPaid.CheckedChanged
        ColPaidStatus.Visible = CheckShowDocPaid.CheckState
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        If CheckTarteeb.Checked = True Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            Dim _RowTarteebID As Integer = 0
            Dim _ID As Integer
            _RowTarteebID = GridView1.GetFocusedRowCellValue("TarteebID")
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then
                _ID = GridView1.GetFocusedRowCellValue("ID")
                If _RowTarteebID = 0 Then
                    If CheckReportForRef.Text = "True" Then
                        sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where Referance =" & SearchReferance.EditValue & " ) where  ID=" & _ID
                        sql.SqlTrueAccountingRunQuery(sqlstring)
                    Else
                        sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where [DebitAcc] ='" & TheAccount.EditValue & "' or [CredAcc]='" & TheAccount.EditValue & "' ) where  ID=" & _ID
                        sql.SqlTrueAccountingRunQuery(sqlstring)
                    End If

                Else
                    GridView1.SetFocusedRowCellValue("TarteebID", 0)
                    sqlstring = " Update Journal Set TarteebID = 0  where  ID=" & _ID
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                End If

                RefreshDataInAccountStatmentForRef()
                'MsgBox(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue))
                If CheckReportForRef.Text = "True" Then
                    GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue), "N2")
                Else
                    GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForAccForTarteebMode(TheAccount.EditValue, Me.Currency.EditValue), "N2")
                End If

            End If
            'Else
            '    OpenDoc()
        End If
    End Sub
    Private Sub BarButtonItem15_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrintReport("Pdf")
                SendFileToWhatsApp(MobileNo, "AccountStatment.pdf", "كشف حساب", "", SearchReferance.Text)
                '  SendFileToWhatsApp2(MobileNo, "AccountStatment.pdf", "كشف حساب", "")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BarButtonItem12_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonSendByWhatsApp.ItemClick
        Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        PrintReport("Pdf")
        SendFileToWhatsApp(_RefData.RefMobile, "AccountStatment.pdf", " كشف حساب ", "", SearchReferance.Text)
    End Sub


    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchReferance.Properties.BeforePopup
        SearchReferance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub

    Private Sub BarButtonItem12_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _RowTarteebID As Integer = 0
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()

        If DevExpress.XtraEditors.XtraMessageBox.Show("هل مطابقة ؟" & selectedRowHandles.Count & " سطر ", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If
        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _ID As Integer
            If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "ID")) Then
                _ID = GridView1.GetRowCellValue(selectedRowHandles(i), "ID")
                If CheckReportForRef.Text = "True" Then
                    sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where Referance =" & SearchReferance.EditValue & " ) where  ID=" & _ID
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                Else
                    sqlstring = " Update Journal Set TarteebID = ( Select Case when Max(TarteebID)=0 then 2 else IsNull(Max(TarteebID),1)+1 end as MaxTarteeb  from Journal where [DebitAcc] ='" & TheAccount.EditValue & "' or [CredAcc]='" & TheAccount.EditValue & "' ) where  ID=" & _ID
                    sql.SqlTrueAccountingRunQuery(sqlstring)
                End If
            End If
        Next
        CheckTarteeb.Checked = True
        RefreshDataInAccountStatmentForRef()
        If CheckReportForRef.Text = "True" Then
            GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue), "N2")
        Else
            GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForAccForTarteebMode(TheAccount.EditValue, Me.Currency.EditValue), "N2")
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد الغاء المطابقة للحساب ؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If
        Dim sql As New SQLControl
        Dim sqlstring As String
        If CheckReportForRef.Text = "True" Then
            sqlstring = " Update Journal Set TarteebID = 0 where Referance =" & SearchReferance.EditValue
            sql.SqlTrueAccountingRunQuery(sqlstring)
        Else
            sqlstring = " Update Journal Set TarteebID = 0 where [DebitAcc] ='" & TheAccount.EditValue & "' or [CredAcc]='" & TheAccount.EditValue & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
        End If
        CheckTarteeb.Checked = True
        RefreshDataInAccountStatmentForRef()
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Dim sql As New SQLControl
        Dim sqlstring As String
        Dim _RowTarteebID As Integer = 0
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()

        If DevExpress.XtraEditors.XtraMessageBox.Show("هل مطابقة ؟" & selectedRowHandles.Count & " سطر ", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _ID As Integer
            If Not IsDBNull(GridView1.GetRowCellValue(selectedRowHandles(i), "ID")) Then
                _ID = GridView1.GetRowCellValue(selectedRowHandles(i), "ID")
                sqlstring = " Update Journal Set TarteebID = 0  where  ID=" & _ID
                sql.SqlTrueAccountingRunQuery(sqlstring)
            End If
        Next
        CheckTarteeb.Checked = True
        RefreshDataInAccountStatmentForRef()
        If CheckReportForRef.Text = "True" Then
            GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForRefForTarteebMode(SearchReferance.EditValue, Me.Currency.EditValue), "N2")
        Else
            GridView1.ViewCaption = " رصيد المطابقة " & Format(GetEndBalanceForAccForTarteebMode(TheAccount.EditValue, Me.Currency.EditValue), "N2")
        End If
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItemRefData.ItemClick
        If SearchReferance.Text <> "" Then
            Dim f As New ReferancessAddNew
            With f
                .TextRefNo.Text = SearchReferance.EditValue
                .ShowDialog()
            End With
        End If

    End Sub

    Private Sub BarButtonItem16_ItemClick_1(sender As Object, e As XtraBars.ItemClickEventArgs)
        SendGreenAPI.Show()
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick

    End Sub

    Private Sub BarButtonItem16_ItemClick_2(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        Dim F As New InstallmentsForRef
        With F
            .SearchReferance.EditValue = Me.SearchReferance.EditValue
            .LookDocStatus.EditValue = -1
            .GetInstallmentsForRef()
            If .ShowDialog() <> DialogResult.OK Then
                RefreshDataInAccountStatmentForRef()
            End If
        End With
    End Sub
    Public Function GetAccountTotal(accountNo As String, connectionString As String) As Decimal
        ' Get all sub-accounts including the main account
        Dim allAccounts = GetAllSubAccounts(accountNo, connectionString)

        ' Calculate total amount (both debit and credit)
        Return GetTotalAmountForAccounts(allAccounts, connectionString)
    End Function

    Private Function GetAllSubAccounts(accountNo As String, connectionString As String) As List(Of String)
        Dim accounts As New List(Of String)()

        ' Recursively get all sub-accounts
        Dim query As String = "
            WITH AccountHierarchy AS (
                SELECT AccNo FROM Accounts WHERE AccNo = @AccountNo
                UNION ALL
                SELECT a.AccNo FROM Accounts a
                INNER JOIN AccountHierarchy ah ON a.FatherAccount = ah.AccNo
            )
            SELECT AccNo FROM AccountHierarchy"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@AccountNo", accountNo)

                Try
                    connection.Open()
                    Dim reader = command.ExecuteReader()

                    While reader.Read()
                        accounts.Add(reader("AccNo").ToString())
                    End While
                Catch ex As Exception
                    Throw New Exception("Error retrieving account hierarchy", ex)
                End Try
            End Using
        End Using

        Return accounts
    End Function

    Private Function GetTotalAmountForAccounts(accountList As List(Of String), connectionString As String) As Decimal
        If accountList.Count = 0 Then Return 0

        Dim totalAmount As Decimal = 0
        Dim accountParams = String.Join(",", accountList.Select(Function(a) $"'{a}'"))

        Dim query As String = $"
            SELECT SUM(CASE WHEN DebitAcc IN ({accountParams}) THEN DocAmount ELSE 0 END) -
                   SUM(CASE WHEN CredAcc IN ({accountParams}) THEN DocAmount ELSE 0 END) AS NetAmount
            FROM JOURNAL
            WHERE DebitAcc IN ({accountParams}) OR CredAcc IN ({accountParams})"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()

                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        totalAmount = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    Throw New Exception("Error calculating account totals", ex)
                End Try
            End Using
        End Using

        Return totalAmount
    End Function

End Class

