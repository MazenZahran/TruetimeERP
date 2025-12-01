Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraCharts
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraPrintingLinks
Imports DevExpress.XtraReports.UI

Public Class AccountStatmentDetails2
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Private _CompanyName As String
    Private _CompanyMobile As String
    Private _CompanyPhone As String
    Private _CompanyAddress As String
    Private _ShowDetailsNote As Boolean
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshData()
    End Sub
    Private Sub RefreshData()
        If String.IsNullOrEmpty(Currency.Text) Then
            XtraMessageBox.Show("يجب اختيار العملة")
            Exit Sub
        End If

        If String.IsNullOrEmpty(SearchReferance.Text) Then
            XtraMessageBox.Show("يجب اختيار المرجع")
            Exit Sub
        End If
        GetAcountStatmentForRef(DateEditFrom.DateTime, DateEditTo.DateTime, SearchReferance.EditValue, Currency.EditValue)

        ExpandAllRows(GridView1)
        If GridView1.RowCount > 2 Then
            LayoutControlItemFind.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If

    End Sub
    Public Sub ExpandAllRows(ByVal View As GridView)
        View.BeginUpdate()
        Try
            Dim dataRowCount As Integer = View.DataRowCount
            Dim rHandle As Integer
            For rHandle = 0 To dataRowCount - 1
                View.SetMasterRowExpanded(rHandle, True)
            Next
        Finally
            View.EndUpdate()
        End Try
    End Sub
    Private Sub GetAcountStatmentForRef(_DateFrom As String, _DateTo As String, Referance As String, Currency As Integer)

        Try
            GridControl1.DataSource = ""
            Dim SqlString As String = String.Empty
            Dim SqlString2 As String = String.Empty
            Dim JouranlTable As New DataTable
            '   Dim RefData = GetRefranceData(Referance)
            Dim AccData = GetFinancialAccountsData(Referance)
            Dim AccCurr = AccData.Currency

            SqlString = "Select sum(DebitAmount) as DebitAmount,sum(CredAmount) as CredAmount,[DocCode],[DocID],[DocDate],
DocName,DocNameValue,[DocManualNo],DocSort,DocNotes,Balance,DocTags  from
(
                         select J.[DocCode] as [DocCode] ,J.[DocID] as [DocID],[DocDate],D.Name as DocName,DocName as DocNameValue,DocNotes,DocTags"
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
            SqlString += ", J.DocSort as DocSort,[DocManualNo] ,
cast( 0 as decimal(10,2)) as Balance 
from Journal J
                           left join FinancialAccounts A on A.AccNo = J.CredAcc
                           left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                        
                           left join DocNames D on D.id = J.DocName 
                           left join DocSorts S on S.SortID = J.DocSort
                           left join CostCenter C on C.CostID = J.DocCostCenter
                           left join Currency U on U.CurrID=J.DocCurrency
                      where DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')"
            SqlString += "  and (   DebitAcc = '" & Referance & "' OR CredAcc= '" & Referance & "')  "
            SqlString += ") Z
group by [DocCode],[DocID],[DocDate],DocName,DocNameValue,[DocManualNo],DocSort,DocNotes,DocTags,Balance order by DocDate,DocName,DocID  "




            SqlString2 = " Select  J.[DocCode],DocDate,Convert(nvarchar(50),j.DocName)+Convert(nvarchar(50),j.DocID)+Convert(nvarchar(50),isnull(J.CheckNo,0)) as DocUniqNO,"


            SqlString2 += " case when f.AccName is NULL then ff.AccName else f.AccName end as AccName,DocNoteByAccount,
                               CONCAT(CAST(DocAmount AS DECIMAL(10,2))  ,' ',U.Code )  as DocAmount,U.Code as DocCurrency,[ExchangePrice],  BaseAmount,BaseCurrAmount,C.CostName,IsNull(J.Referance,0) as RefNo  , IsNull(R.RefName,'') as  RefName"
            SqlString2 += "    From Journal J                 
                           left join Currency U on U.CurrID=J.DocCurrency
                           left join CostCenter C on C.CostID=J.DocCostCenter 
						   left join FinancialAccounts F on F.AccNo=J.DebitAcc 
						   left join FinancialAccounts FF on FF.AccNo=J.CredAcc 
                           left Join Referencess R on R.RefNo=J.Referance
                      where DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "') "
            SqlString2 += " And DocCode In (  select J.[DocCode] as [DocCode]
from Journal J
left join FinancialAccounts A on A.AccNo = J.CredAcc
left join FinancialAccounts AA on AA.AccNo = J.DebitAcc                        
where DocStatus > 0 and (DocDate between '" & Format(CDate(_DateFrom), "yyyy-MM-dd") & "' and '" & Format(CDate(_DateTo), "yyyy-MM-dd") & "')  and (   DebitAcc = '" & Referance & "' OR CredAcc= '" & Referance & "')  )  "
            SqlString2 += "  order by OrderID"


            Dim Con As SqlConnection
            Dim Adapter1, Adapter2 As SqlDataAdapter
            Dim dataSet11 As DataSet

            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            Adapter1 = New SqlDataAdapter(SqlString, Con)
            Adapter2 = New SqlDataAdapter(SqlString2, Con)
            dataSet11 = New System.Data.DataSet()
            Adapter1.Fill(dataSet11, "Journal")
            Adapter2.Fill(dataSet11, "Journal2")

            Dim _Table As New DataTable
            Dim BegBalce As Decimal = 0
            Dim R As DataRow = dataSet11.Tables("Journal").NewRow
            BegBalce = GetBegBalanceForRef(Referance, _DateFrom, _DateTo, Currency)
            If BegBalce > 0 Then R("DebitAmount") = BegBalce
            If BegBalce < 0 Then R("CredAmount") = Math.Abs(BegBalce)
            R("DocDate") = CDate(_DateFrom).AddDays(-1)
            R("DocNotes") = "  رصيد مدور"
            R("DocID") = -1
            R("DocCode") = "X1X"
            dataSet11.Tables("Journal").Rows.Add(R)
            dataSet11.Tables("Journal").DefaultView.Sort = "DocDate,DocName ASC"

            For x As Integer = dataSet11.Tables.Count - 1 To 0 Step -1
                Dim dt = dataSet11.Tables(x)
                dt.DefaultView.Sort = "DocDate Asc"
                dataSet11.Tables.RemoveAt(x)
                dataSet11.Tables.Add(dt.DefaultView.ToTable)
            Next
            dataSet11.AcceptChanges()

            Dim keyColumn As DataColumn = dataSet11.Tables("Journal").Columns("DocCode")
            Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Journal2").Columns("DocCode")
            dataSet11.Relations.Add("CategoriesProducts", keyColumn, foreignKeyColumn)
            dataSet11.Tables("Journal").DefaultView.Sort = "DocDate,DocName ASC"
            For i As Integer = 0 To dataSet11.Tables("Journal").Rows.Count - 1
                Dim row As DataRow = dataSet11.Tables("Journal").Rows(i)
                Dim credit As Decimal = 0, debit As Decimal = 0, previousBalance As Decimal = 0
                Decimal.TryParse(row("CredAmount").ToString(), credit)
                Decimal.TryParse(row("DebitAmount").ToString(), debit)
                If i > 0 Then Decimal.TryParse(dataSet11.Tables("Journal").Rows(i - 1)("Balance").ToString(), previousBalance)
                row("Balance") = If(i = 0, debit - credit, previousBalance - credit + debit)
            Next
            dataSet11.Tables("Journal").DefaultView.Sort = "DocDate ASC"
            GridControl1.DataSource = dataSet11.Tables("Journal")
            GridControl1.ForceInitialize()
            GridView2.OptionsDetail.ShowDetailTabs = False
            GridView1.OptionsDetail.ShowDetailTabs = False
            GridControl1.LevelTree.Nodes.Add("CategoriesProducts", GridView2)
            GridView2.OptionsDetail.ShowDetailTabs = False
            GridView1.OptionsDetail.ShowDetailTabs = False
            'dataSet11.Tables("Journal").DefaultView.Sort = "DocDate,DocName ASC"
            'Dim dataView As DataView = dataSet11.Tables("Journal").DefaultView
            'dataView.Sort = "DocDate,DocNameValue ASC"
            'GridControl1.DataSource = dataView
            'GridControl1.ForceInitialize()
            'GridView2.OptionsDetail.ShowDetailTabs = False
            'GridView1.OptionsDetail.ShowDetailTabs = False
            'GridControl1.LevelTree.Nodes.Add("CategoriesProducts", GridView2)
            'GridView2.OptionsDetail.ShowDetailTabs = False
            'GridView1.OptionsDetail.ShowDetailTabs = False

            '     GridView1.BestFitColumns()
            '    GridView2.BestFitColumns()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    'Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
    '    Dim View As GridView = CType(sender, GridView)
    '    If e.Column.FieldName = "DocTags" Then
    '        Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("DocTags"))
    '        If category <> "" Then
    '            e.DisplayText = SetTagsColor(category)
    '            e.Appearance.Options.CancelUpdate()
    '        End If
    '    End If
    'End Sub
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

    Private Sub XtraForm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchReferance.Properties.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
        ' TheAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, True,-1)

        'Currency.Properties.DataSource = _Currnecy
        Me.KeyPreview = True
        'Currency.EditValue = 1

        ' LayoutByAcc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never


        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        Dim DateTo As DateTime = Today

        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        ' ColBaseCurrAmount.Visible = False
        ' ColExchangePrice.Visible = False

        'If _ShowCostCenter = True Then
        '    LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
        'Else
        '    LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'End If

        Me.ColDocManualNo.Visible = False
        _ShowDetailsNote = False


        'If _OpenForPrint = True Then
        '    Select Case _PrintOption
        '        Case "SendWhatsApp"
        '            PrintReport("Pdf")
        '            Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        '            SendFileToWhatsApp(_RefData.RefMobile, "AccountStatment.pdf", "كشف حساب", "")
        '        Case "Print"
        '            PrintReport("Print")
        '    End Select
        '    Me.Close()
        'Else
        '    Dim sql As New SQLControl
        '    sql.SqlTrueAccountingRunQuery(" SELECT SettingValue FROM Settings WHERE SettingName='AccountingDateStartFromCurrentMonthInAccountStatment'  ")
        '    If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = True Then
        '        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), Format(Today, "MM"), 1)
        '        Dim DateTo As DateTime = Today
        '        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        '        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        '    Else
        '        Dim DateFrom As DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
        '        Dim DateTo As DateTime = Today
        '        DateEditFrom.DateTime = CDate(Format(DateFrom, "yyyy-MM-dd"))
        '        DateEditTo.DateTime = CDate(Format(DateTo, "yyyy-MM-dd"))
        '    End If

        'End If

    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        End If
    End Sub
    Private Function GetBegBalanceForRef(RefNo As Integer, _DateFrom As String, _DateTo As String, Currency As Integer) As Decimal
        ' Dim RefData = GetRefranceData(RefNo)
        Dim AccData = GetFinancialAccountsData(RefNo)
        Dim AccCurr = AccData.Currency
        Dim _BegBalance As Decimal = 0
        Dim _SearchType As String = " where 1=1 "
        _SearchType = " and (   DebitAcc ='" & RefNo & "' OR CredAcc= '" & RefNo & "')  "
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        PrintReport("Preview")
    End Sub
    Private Sub PrintReport(_option As String)
        'GridControl1.ShowPrintPreview()

        Dim _company = GetCompanyData()
        _CompanyName = _company.CompanyName
        '  _CompanyName = _company.CompanyName

        'ColDocID.Width = 50
        'ColDocDate.Width = 120
        'ColDocName.Width = 120
        'ColDebitAmount.Width = 120
        'ColCredAmount.Width = 120
        'ColBalance.Width = 120
        'ColDocCurrency.Width = 50
        'ColExchangePrice.Width = 50
        'ColBaseCurrAmount.Width = 70
        'ColDocAmount.Width = 70
        'ColDocManualNo.Width = 70
        'Dim report As New ReportAccountStatment
        'With report
        '    .XrLabelPeriod.Text = " من تاريخ: " & DateEditFrom.DateTime & " " & " إلى تاريخ " & DateEditTo.DateTime
        '    .XrLabelCurrency.Text = Currency.Text
        '    .XrLabelAccountName.Text = SearchReferance.EditValue & " / " & SearchReferance.Text
        '    .PrintableComponentContainer1.PrintableComponent = Me.GridControl1
        '    .ShowPreviewDialog()
        'End With
        'ColDocID.Width = 70
        'ColDocDate.Width = 100
        'ColDocName.Width = 120
        'ColDebitAmount.Width = 110
        'ColCredAmount.Width = 110
        'ColBalance.Width = 110
        'ColDocCurrency.Width = 70
        'ColExchangePrice.Width = 70
        'ColBaseCurrAmount.Width = 110
        'ColDocAmount.Width = 110
        'ColDocManualNo.Width = 110


        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("select SettingValue from [dbo].[Settings] where SettingName=N'AccountingStatmentRefNote'")
        GridControl2.DataSource = sql.SQLDS.Tables(0)

        ' Me.PrintingSystem1.
        'Dim report As New AccountingStatmentDetailsReport() With {.DataSource = GridControl1.DataSource}
        'report.ShowPreview

        Dim compositeLink As CompositeLink
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            GridControl1.ShowPrintPreview()
        Else
            compositeLink = CreateCompositeLink(GridControl1, GridControl2)
            compositeLink.RightToLeftLayout = True
            'AddHandler compositeLink.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea
            Select Case _option
                Case "Preview"
                    compositeLink.ShowPreview()
                Case "Print"
                    compositeLink.Print()
                Case "Pdf"
                    compositeLink.ExportToPdf("AccountStatment.pdf")
            End Select

        End If
    End Sub
    Private Function CreateCompositeLink(ByVal grid1 As GridControl, ByVal grid2 As GridControl) As CompositeLink


        Dim Link1 As New PrintableComponentLink()
        Link1.Component = grid1
        Dim Link2 As New PrintableComponentLink()
        Link2.Component = grid2
        Dim compositeLink As New CompositeLink(New PrintingSystem())
        Dim linkGrid1Report As Link = New Link()

        '  Dim height As Integer = 10
        'AddHandler linkGrid1Report.CreateReportHeaderArea, Function(s, args) AnonymousMethod1(s, args, height)
        'AddHandler linkGrid1Report.CreateReportFooterArea, Function(s, args) AnonymousMethod2(s, args, height)
        '  AddHandler linkGrid1Report.CreateMarginalHeaderArea, AddressOf composLink_CreateMarginalHeaderArea
        AddHandler linkGrid1Report.CreateDetailArea, AddressOf linkGrid1Report_CreateDetailArea

        compositeLink.Links.Add(linkGrid1Report)
        compositeLink.Links.AddRange(New Object() {Link1, Link2})
        compositeLink.BreakSpace = 100

        Return compositeLink
    End Function
    ' Inserts a PageInfoBrick into the top margin to display the time.
    Private Sub composLink_CreateMarginalHeaderArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        e.Graph.DrawPageInfo(PageInfo.DateTime, "{0:hhhh:mmmm:ssss}",
        Color.Black, New RectangleF(0, 0, 200, 50), BorderSide.Left = 1)
    End Sub
    'Private Function AnonymousMethod1(ByVal s As Object, ByVal args As CreateAreaEventArgs, ByVal height As Integer) As Boolean
    '    args.Graph.DrawString(_CompanyName, Color.Empty, New RectangleF(Point.Empty, New SizeF(args.Graph.ClientPageSize.Width, height)), BorderSide.Top)
    '    args.Graph.DrawRect(New RectangleF(New Point(0, height), New SizeF(args.Graph.ClientPageSize.Width, height)), BorderSide.Top, Color.Empty, Color.Empty)
    '    Return True
    'End Function

    'Private Function AnonymousMethod2(ByVal s As Object, ByVal args As CreateAreaEventArgs, ByVal height As Integer) As Boolean
    '    args.Graph.DrawRect(New RectangleF(Point.Empty, New SizeF(args.Graph.ClientPageSize.Width, height)), BorderSide.Bottom, Color.Empty, Color.Empty)
    '    args.Graph.DrawString(_CompanyName, Color.Empty, New RectangleF(New Point(0, height), New SizeF(args.Graph.ClientPageSize.Width, height)), BorderSide.Bottom)
    '    Return True
    'End Function
    Private Sub linkGrid1Report_CreateDetailArea(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
        Dim tb As TextBrick = New TextBrick()
        ' tb.Text = "كشف حساب تفصيلي"
        tb.Text = "كشف حساب تفصيلي" & "  " & SearchReferance.Text & " ( " & SearchReferance.EditValue & " ) " & " من تاريخ " & DateEditFrom.Text & " الى تاريخ " & DateEditTo.Text & "  "
        tb.Font = New Font("Arial", 12)
        tb.Rect = New RectangleF(0, 0, 600, 20)
        tb.BorderWidth = 1
        tb.BackColor = Color.Silver
        tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Center
        e.Graph.DrawBrick(tb)


        'Dim visBrick As VisualBrick
        'Dim brickGraph As BrickGraphics = PrintingSystem1.Graph
        'Dim s As String = "Developer Express Inc."

        '' Measure the string.
        'Dim sz As SizeF = brickGraph.MeasureString(s)

        '' Start the report generation.
        'PrintingSystem1.Begin()

        '' Create a rectangle of the calculated size.
        'Dim rect As RectangleF = New RectangleF(New PointF(0, 0), sz)
        '' Specify a page area.
        'brickGraph.Modifier = BrickModifier.Detail
        '' Create a text brick.
        'visBrick = brickGraph.DrawString(s, Color.Black, rect, BorderSide.All)


    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)



        ' pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 10
        pb.PageSettings.RightMargin = 10
        pb.PageSettings.TopMargin = 30
        pb.PageSettings.BottomMargin = 10
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
                                                                                   {"  ", Now(), "Pages: [Page # of Pages #]"})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
                (Currency.Text & " " & "كشف حساب تفصيلي  : " & SearchReferance.Text & " ")

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ  " & DateEditFrom.EditValue & "  الى تاريخ  " & DateEditTo.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub
    Private Sub GridControl1_Click(sender As Object, e As EventArgs)
        OpenDoc()
    End Sub


    Private Sub OpenDoc()

        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocNameValue"))
        Dim DocData = GetDocData(DocID, DocName)

        'With My.Forms.MoneyTrans
        '    .DocStatus.EditValue = DocData.DocStatus
        '    .TextDocID.EditValue = DocID
        '    .DocName.EditValue = DocName
        '    .DocDate.DateTime = CDate(DocData.DocDate)
        '    .LookCostCenter.EditValue = DocData.DocCostCenter
        '    .TextDocManualNo.Text = DocData.DocManualNo
        '    .LookDocSort.EditValue = DocData.DocSort
        '    '  .TextDocAmount.Text = DocData.DocAmount
        '    .DocCurrencyForReferanceAcc.EditValue = DocData.DocCurrency
        '    .ExchangePriceForReferanceAcc.Text = DocData.ExchangePrice
        '    .Referance.EditValue = DocData.Referance
        '    .TextDocNotes.Text = DocData.DocNotes
        '    .LayoutDelete.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    .LayoutSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never


        '.LayoutControlGroup4.Enabled = False
        '.LayoutControlGroup1.Enabled = False
        ' .LayoutControlGroup2.Enabled = False
        '  .LayoutControlGroup3.Enabled = False
        '    .LayoutControlGroup5.Enabled = False
        '.LayoutControlGroup6.Enabled = False


        If DocName = 3 Or DocName = 4 Then
            With My.Forms.MoneyTrans
                .TextDocID.EditValue = DocID
                .DocName.EditValue = DocName
                .TextDocIDQuery.EditValue = DocID
                .Show()
            End With
        End If


        '.Show()
        'End With




        Select Case DocName
            Case 3
                My.Forms.MoneyTrans.AccountForRefranace.EditValue = DocData.DebitAcc
            Case 4
                My.Forms.MoneyTrans.AccountForRefranace.EditValue = DocData.CredAcc
        End Select
    End Sub
    Private Sub SearchReferance_EditValueChanged(sender As Object, e As EventArgs) Handles SearchReferance.EditValueChanged
        'Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        Dim _AccData = GetFinancialAccountsData(SearchReferance.EditValue)
        Currency.Properties.DataSource = GetCurrenciesForReport(_AccData.Currency)
        Currency.EditValue = _AccData.Currency
    End Sub
    'Private Sub CheckShowBaseAmount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowBaseAmount.CheckedChanged
    '    If CheckShowBaseAmount.Checked = True Then
    '        ColBaseCurrAmount.Visible = True
    '        ColExchangePrice.Visible = True
    '        ColDocCurrency.Visible = True
    '    Else
    '        ColBaseCurrAmount.Visible = False
    '        ColExchangePrice.Visible = False
    '        ColDocCurrency.Visible = False
    '    End If
    '    GridView1.BestFitColumns()
    'End Sub

    'Private Sub AccountForRefranace_EditValueChanged(sender As Object, e As EventArgs) Handles TheAccount.EditValueChanged

    '    Dim _AccData = GetFinancialAccountsData(TheAccount.EditValue)
    '    Currency.Properties.DataSource = GetCurrenciesForReport(_AccData.Currency)
    '    Currency.EditValue = _AccData.Currency
    'End Sub
    'Private Sub CheckReportForRef_EditValueChanged(sender As Object, e As EventArgs) Handles CheckReportForRef.EditValueChanged
    '    If CheckReportForRef.Text = "True" Then
    '        LayoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '        LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '    Else
    '        LayoutAccount.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '        LayoutByReferance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '    End If

    'End Sub
    Private Sub AdvBandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            If summaryID = "15001" Then
                e.TotalValue = ColDebitAmount.SummaryItem.SummaryValue - ColCredAmount.SummaryItem.SummaryValue
            End If
        End If
    End Sub


    'Private Sub gridViewMaster_ColumnFilterChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ColumnFilterChanged
    '    Dim view As GridView = TryCast(sender, GridView)

    '    For Each masterRowInfo As DevExpress.Data.Details.MasterRowInfo In view.DataController.ExpandedMasterRowCollection
    '        Dim detailView As GridView = TryCast(view.GetDetailView(masterRowInfo.ParentControllerRow, 0), GridView)

    '        If detailView IsNot Nothing Then
    '            detailView.ApplyFindFilter(view.FindFilterText)
    '        End If
    '    Next
    'End Sub
    Private Sub gridViewMaster_ColumnFilterChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ColumnFilterChanged
        Dim view As GridView = TryCast(sender, GridView)

        For Each masterRowInfo As DevExpress.Data.Details.MasterRowInfo In view.DataController.ExpandedMasterRowCollection
            Dim detailView As GridView = TryCast(view.GetDetailView(masterRowInfo.ParentControllerRow, 0), GridView)

            If detailView IsNot Nothing Then
                detailView.ApplyFindFilter(view.FindFilterText)
            End If
        Next
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        If String.IsNullOrWhiteSpace(TextEdit1.Text) Then
            GridView2.ClearColumnsFilter()
        Else
            Dim searchText As String = TextEdit1.Text.Trim()
            Dim filterExpression As String = String.Format("([RefName] LIKE '%{0}%') OR ([AccName] LIKE '%{0}%') OR ([DocNoteByAccount] LIKE '%{0}%')", searchText)
            GridView2.Columns.Clear()
            GridView2.ActiveFilterString = filterExpression
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'Me.DocumentViewer1.DocumentSource = Me.PrintingSystem1
        'Me.DocumentViewer1.InitiateDocumentCreation()
        'DocumentViewer1.sho
        ' DocumentViewer1.Refresh()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("select SettingValue from [dbo].[Settings] where SettingName=N'AccountingStatmentRefNote'")
        GridControl2.DataSource = sql.SQLDS.Tables(0)
        Dim f As New AccountingStatmentDocumentPreview
        With f
            .DocumentViewer1.DocumentSource = Me.PrintingSystem1
            .Show()
        End With




    End Sub

    Private Sub GridControl2_Click(sender As Object, e As EventArgs) Handles GridControl2.Click

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _RefData = GetRefranceData(SearchReferance.EditValue)
        PrintReport("Pdf")
        SendFileToWhatsApp(_RefData.RefMobile, "AccountStatment.pdf", " كشف حساب ", "", SearchReferance.Text)
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            Dim myControl As New SendToWhatsAppNo()
            '  myControl.textMobileNo.Select()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrintReport("Pdf")
                SendFileToWhatsApp(MobileNo, "AccountStatment.pdf", " كشف حساب ", "", SearchReferance.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        If SearchReferance.Text <> "" Then
            Dim f As New ReferancessAddNew
            With f
                .TextRefNo.Text = SearchReferance.EditValue
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub RepositoryOpen_Click(sender As Object, e As EventArgs) Handles RepositoryOpen.Click
        If IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID")) Or
    IsDBNull(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode")) Or
    GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID") Is Nothing Then
            Exit Sub
        End If
        Dim DocID As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"))
        Dim DocName As Integer = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocNameValue"))
        Dim DocCode As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
        'Dim OrderStatus As Integer
        'Try
        '    OrderStatus = CInt(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "OrderStatus"))
        'Catch ex As Exception
        '    OrderStatus = 0
        'End Try


        ' Select Case DocName
        'Case 1, 2, 3, 4, 5, 12, 13
        OpenDocumentsByDocCode(DocCode, "Journal", Me.Name)
        '  End Select
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick

        GridView2.BestFitColumns()

    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Select Case GridView2.OptionsView.ShowColumnHeaders
            Case True
                GridView2.OptionsView.ShowColumnHeaders = False
                GridView2.OptionsPrint.PrintHeader = False
            Case False
                GridView2.OptionsView.ShowColumnHeaders = True
                GridView2.OptionsPrint.PrintHeader = True
        End Select

    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        GridView2.BestFitColumns()
    End Sub

    Private Sub BarCostCenter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCostCenter.ItemClick
        Select Case Me.ColCostName.Visible
            Case False
                Me.ColCostName.Visible = True
                Me.ColCostName.VisibleIndex = 1
            Case True
                Me.ColCostName.Visible = False
                '  Me.ColPriceBeforeDiscount.VisibleIndex = 3
        End Select
        GridView2.BestFitColumns()
    End Sub

    Private Sub BarButtonItem6_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If _ShowDetailsNote = False Then
            _ShowDetailsNote = True
        Else
            _ShowDetailsNote = False
        End If
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
End Class