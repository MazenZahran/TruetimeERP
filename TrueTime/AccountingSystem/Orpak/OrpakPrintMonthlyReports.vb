Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraSpreadsheet.Import.Xls

Public Class OrpakPrintMonthlyReports

    Private Async Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        Try
            ' Disable the button while data is loading
            BtnLoad.Enabled = False
            BtnLoad.Text = "Loading..."

            ' Call async data loading
            Await GetDataAsync()

        Catch ex As Exception
            MessageBox.Show("⚠️ Error: " & ex.Message)
        Finally
            ' Re-enable the button after completion
            BtnLoad.Enabled = True
            BtnLoad.Text = "Load Data"
        End Try
    End Sub
    '    Private Sub GetData2()
    '        Dim _dataName As String = If(OrpakHasHeadOffice(), "ho_data", "data")
    '        Dim _RefSort As Integer = If(SearchSort.Text = "", -1, SearchSort.EditValue)

    '        Dim query As String = "
    '        DECLARE @FromDate DATETIME, @ToDate DATETIME;
    '        SET @FromDate = @pFromDate;
    '        SET @ToDate   = @pToDate;

    '        -- Optimized query using CTEs
    '        WITH JournalAgg AS (
    '            SELECT 
    '                J.Referance AS RefNo,
    '                SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) AS CredSum,
    '                SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END) AS DebitSum
    '            FROM journal J
    '            INNER JOIN Referencess R ON R.RefNo = J.Referance
    '            WHERE J.DocDate <= @ToDate
    '              AND J.DocStatus <> 0
    '              AND (j.DebitAcc = R.RefAccID OR j.CredAcc = R.RefAccID)
    '            GROUP BY J.Referance
    '        ),
    '        FleetSales AS (
    '            SELECT 
    '                f.code AS fleet_code,
    '                SUM(sale) AS sales
    '            FROM [ORPAK].[" & _dataName & "].dbo.transactions T
    '            INNER JOIN [ORPAK].[" & _dataName & "].dbo.fleets f ON T.fleet_id = F.id
    '            WHERE [date] BETWEEN @FromDate AND @ToDate
    '            GROUP BY f.code
    '        )
    '        SELECT 
    '            CASE WHEN ISNULL(J.CredSum,0) - ISNULL(F.sales,0) <> 0 THEN 'True' ELSE 'False' END AS PrintAccStatement,
    '            A.RefNo AS ReferanceNo,
    '            A.RefName,
    '            ISNULL(J.CredSum,0) - ISNULL(J.DebitSum,0) AS balance,
    '            J.CredSum AS DebitAsAccount,
    '            F.sales,
    '            ISNULL(J.CredSum,0) - ISNULL(F.sales,0) AS Diff
    '        FROM Referencess A
    '        LEFT JOIN JournalAgg J ON A.RefNo = J.RefNo
    '        LEFT JOIN FleetSales F ON A.RefNo = F.fleet_code
    '        WHERE F.sales IS NOT NULL;
    '    "

    '        Using conn As New SqlConnection(My.MySettings.Default.TrueTimeConnectionString),
    '            cmd As New SqlCommand(query, conn)

    '            cmd.CommandTimeout = 600  ' Increase timeout to 5 minutes
    '            cmd.Parameters.AddWithValue("@pFromDate", Me.DateEdit1.DateTime)
    '            cmd.Parameters.AddWithValue("@pToDate", Me.DateEdit2.DateTime)

    '            Dim da As New SqlDataAdapter(cmd)
    '            Dim dt As New DataTable()
    '            da.Fill(dt)
    '            GridControl1.DataSource = dt
    '        End Using
    '    End Sub
    '    Private Sub GetData()
    '        Dim stopwatch As New System.Diagnostics.Stopwatch()
    '        stopwatch.Start()
    '        Try

    '            ' Determine database name
    '            Dim dataName As String = If(OrpakHasHeadOffice(), "ho_data", "data")
    '            ' Get RefSort
    '            Dim refSort As Integer = If(String.IsNullOrEmpty(SearchSort.Text), -1, CInt(SearchSort.EditValue))

    '            ' SQL with parameter placeholders
    '            Dim sqlstring As String = "
    'DECLARE @pFromDate DATETIME = '" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "';
    'DECLARE @pToDate   DATETIME = '" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "';
    'With JournalSummary As (
    '    SELECT J.Referance, 
    '           SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) AS TotalCredit,
    '           SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END) AS TotalDebit
    '    FROM journal J
    '    INNER JOIN Referencess R ON R.RefNo = J.Referance
    '    WHERE J.DocDate <= @pToDate AND J.DocStatus<>0 AND (J.DebitAcc=R.RefAccID OR J.CredAcc=R.RefAccID)
    '    GROUP BY J.Referance
    '),
    'JournalDebit AS (
    '    SELECT J.Referance,
    '           SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) AS DebitAsAccount
    '    FROM journal J
    '    INNER JOIN Referencess R ON R.RefNo = J.Referance
    '    WHERE J.DocDate BETWEEN @pFromDate AND @pToDate AND J.DocStatus<>0 AND (J.DebitAcc=R.RefAccID OR J.CredAcc=R.RefAccID)
    '    GROUP BY J.Referance
    '),
    'SalesSummary AS (
    '    SELECT F.code AS fleet_code, SUM(sale) AS sales
    '    FROM [ORPAK].[{DATA_NAME}].dbo.transactions T
    '    INNER JOIN [ORPAK].[{DATA_NAME}].dbo.fleets F ON T.fleet_id=F.id
    '    WHERE T.[date] BETWEEN @pFromDate AND @pToDate
    '    GROUP BY F.code
    ')
    'SELECT CASE WHEN ISNULL(D.DebitAsAccount,0)-ISNULL(B.sales,0)<>0 THEN 'True' ELSE 'False' END AS PrintAccStatment,
    '       A.RefNo AS ReferanceNo, A.RefName, 
    '       C.TotalCredit - C.TotalDebit AS balance, 
    '       D.DebitAsAccount, B.sales, 
    '       ISNULL(D.DebitAsAccount,0) - ISNULL(B.sales,0) AS Diff
    'FROM Referencess A
    'LEFT JOIN JournalSummary C ON A.RefNo=C.Referance
    'LEFT JOIN SalesSummary B ON A.RefNo=B.fleet_code
    'LEFT JOIN JournalDebit D ON A.RefNo=D.Referance
    'WHERE B.sales IS NOT NULL
    '" & If(refSort <> -1, " AND A.RefSort=" & refSort, "") & ";"

    '            ' Prepare SQLControl and parameters
    '            Dim sql As New SQLControl()
    '            ' Execute
    '            sql.SqlTrueAccountingRunQuery(sqlstring.Replace("{DATA_NAME}", dataName))
    '            GridControl1.DataSource = sql.SQLDS.Tables(0)

    '        Catch ex As Exception
    '            MessageBox.Show("Error fetching data: " & ex.Message)
    '        End Try
    '        stopwatch.Stop()
    '        My.Forms.Main.ItemElapseTime.Caption = $"Query time: {stopwatch.ElapsedMilliseconds} ms"
    '    End Sub
    Private Async Function GetDataAsync() As Task
        Try
            ' Start measuring execution time
            Dim sw As New Stopwatch()
            sw.Start()

            ' Determine database name
            Dim dataName As String = If(OrpakHasHeadOffice(), "ho_data", "data")

            ' Determine RefSort
            Dim refSort As Integer = If(String.IsNullOrEmpty(SearchSort.Text), -1, CInt(SearchSort.EditValue))

            ' Build SQL string (using separate function)
            Dim sqlstring As String = BuildSqlQuery(dataName, refSort)

            ' Create SQLControl
            Dim sql As New SQLControl()

            ' Run query asynchronously in a background thread
            Dim success As Boolean = Await Task.Run(Function()
                                                        Return sql.SqlTrueAccountingRunQuery(sqlstring)
                                                    End Function)

            ' Stop measuring time
            sw.Stop()

            ' Update UI safely
            If success Then
                If GridControl1.InvokeRequired Then
                    GridControl1.Invoke(Sub() GridControl1.DataSource = sql.SQLDS.Tables(0))
                Else
                    GridControl1.DataSource = sql.SQLDS.Tables(0)
                End If

                MessageBox.Show($"✅ Data loaded successfully! Execution time: {sw.Elapsed.TotalSeconds:F2} seconds")
            Else
                MessageBox.Show("❌ Failed to load data.")
            End If

        Catch ex As Exception
            MessageBox.Show("⚠️ Error loading data: " & ex.Message)
        End Try
    End Function
    Private Function BuildSqlQuery(dataName As String, refSort As Integer) As String
        Dim sqlstring As String = "
DECLARE @FromDate DATETIME = '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "';
DECLARE @ToDate   DATETIME = '" & Format(DateEdit2.DateTime, "yyyy-MM-dd") & "';

WITH JournalSummary AS (
    SELECT J.Referance, 
           SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) AS TotalCredit,
           SUM(CASE WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END) AS TotalDebit
    FROM journal J
    INNER JOIN Referencess R ON R.RefNo = J.Referance
    WHERE J.DocDate <= @ToDate AND J.DocStatus<>0 AND (J.DebitAcc=R.RefAccID OR J.CredAcc=R.RefAccID)
    GROUP BY J.Referance
),
JournalDebit AS (
    SELECT J.Referance,
           SUM(CASE WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END) AS DebitAsAccount
    FROM journal J
    INNER JOIN Referencess R ON R.RefNo = J.Referance
    WHERE J.DocDate BETWEEN @FromDate AND @ToDate AND J.DocStatus<>0 AND (J.DebitAcc=R.RefAccID OR J.CredAcc=R.RefAccID)
    GROUP BY J.Referance
),
SalesSummary AS (
    SELECT F.code AS fleet_code, SUM(sale) AS sales
    FROM [ORPAK].[" & dataName & "].dbo.transactions T
    INNER JOIN [ORPAK].[" & dataName & "].dbo.fleets F ON T.fleet_id=F.id
    WHERE T.[date] BETWEEN @FromDate AND @ToDate
    GROUP BY F.code
)
SELECT CASE WHEN ISNULL(D.DebitAsAccount,0)-ISNULL(B.sales,0)<>0 THEN 'True' ELSE 'False' END AS PrintAccStatment,
       A.RefNo AS ReferanceNo, A.RefName, 
       (ISNULL(C.TotalCredit,0) - ISNULL(C.TotalDebit,0)) AS balance, 
       D.DebitAsAccount, B.sales, 
       (ISNULL(D.DebitAsAccount,0) - ISNULL(B.sales,0)) AS Diff
FROM Referencess A
LEFT JOIN JournalSummary C ON A.RefNo=C.Referance
LEFT JOIN SalesSummary B ON A.RefNo=B.fleet_code
LEFT JOIN JournalDebit D ON A.RefNo=D.Referance
WHERE B.sales IS NOT NULL"

        ' Apply RefSort filter if needed
        If refSort <> -1 Then
            sqlstring &= " AND A.RefSort=" & refSort
        End If

        Return sqlstring
    End Function


    'Private Sub GetData()
    '    Dim _OrpakHasHeadOffice As Boolean
    '    Dim _dataName As String = "data"
    '    _OrpakHasHeadOffice = OrpakHasHeadOffice()
    '    If _OrpakHasHeadOffice = True Then
    '        _dataName = "ho_data"
    '    Else
    '        _dataName = "data"
    '    End If
    '    Dim _RefSort As Integer
    '    If SearchSort.Text = "" Then
    '        _RefSort = -1
    '    Else
    '        _RefSort = SearchSort.EditValue
    '    End If
    '    _RefSort = SearchSort.EditValue
    '    Dim sql As New SQLControl
    '    Dim sqlstring As String
    '    sqlstring = "    Declare @FromDate DATETIME    ;      Declare @ToDate DATETIME "
    '    sqlstring += "   Set @FromDate='" & Format(Me.DateEdit1.DateTime, "yyyy-MM-dd") & "'; Set @ToDate ='" & Format(Me.DateEdit2.DateTime, "yyyy-MM-dd") & "'"
    '    sqlstring += "    select case when convert(int,(ISNULL(D.DebitAsAccount,0)-IsNull(B.sales,0))) <>0 then 'True' else 'False' end as PrintAccStatment ,A.ReferanceNo,A.RefName,C.balance,D.DebitAsAccount,B.sales,convert(int,(ISNULL(D.DebitAsAccount,0)-IsNull(B.sales,0))) as Diff from "
    '    sqlstring += "    (select RefNo as ReferanceNo,RefName  from Referencess   "
    '    If _RefSort <> -1 Then
    '        sqlstring += "    where  RefSort=" & _RefSort & "   "
    '    End If
    '    sqlstring += "     ) A   "
    '    sqlstring += "    left join 
    '                      (SELECT J.Referance AS RefNo,
    '                    (CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END)) -CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN DebitAcc='0' THEN BaseCurrAmount ELSE 0 END)) ) as balance
    '                    FROM journal J
    '                    LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '                    WHERE J.DocDate <=@ToDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '                    GROUP BY Referance) C on A.ReferanceNo=C.RefNo
    '                    left Join
    '                    (select f.code as fleet_code ,sum(sale) as sales   from [ORPAK].[" & _dataName & "].dbo.transactions T left join [ORPAK].[" & _dataName & "].dbo.fleets f on T.fleet_id=F.id  where [date] between @FromDate  and @ToDate group by f.code) B
    '                      on A.ReferanceNo=B.fleet_code 
    '                      left join 
    '                     (SELECT J.Referance AS RefNo,
    '                    (CONVERT(DECIMAL(16, 2), SUM(CASE  WHEN CredAcc='0' THEN BaseCurrAmount ELSE 0 END))  ) as DebitAsAccount
    '                    FROM journal J
    '                    LEFT JOIN Referencess R ON R.RefNo=J.Referance
    '                    WHERE J.DocDate between @FromDate and @ToDate AND j.DocStatus<>0 AND (j.DebitAcc= R.RefAccID OR j.CredAcc= R.RefAccID) 
    '                    GROUP BY Referance) D on A.ReferanceNo=D.RefNo
    '                      where sales is not Null  "
    '    sql.SqlTrueAccountingRunQuery(sqlstring)
    '    GridControl1.DataSource = sql.SQLDS.Tables(0)
    'End Sub

    Private Sub OrpakPrintMonthlyReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _fromdate, _todate As DateTime
        Dim _lastmonth, _year As Integer
        If Today.Month = 1 Then
            _lastmonth = 12
            _year = Today.Year - 1
        Else
            _lastmonth = Today.Month - 1
            _year = Today.Year
        End If
        Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
        _fromdate = New DateTime(_year, _lastmonth, 1)
        _todate = New DateTime(_year, _lastmonth, _daysCount)
        Me.DateEdit2.DateTime = _todate
        Me.DateEdit1.DateTime = _fromdate
        GetReferancessTypes(False)
        SearchSort.Properties.DataSource = GetRefSorts(True)
        SearchSort.EditValue = -1
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Dim selectedRowHandles As Integer() = BandedGridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim RefNo As Object = BandedGridView1.GetRowCellValue(selectedRowHandles(i), "ReferanceNo")
            Dim RefName As Object = BandedGridView1.GetRowCellValue(selectedRowHandles(i), "RefName")
            Dim F As New FleetTrans
            With F
                ._OpenForPrint = True
                .CheckEditShowBalance.EditValue = CheckEditShowBalance.EditValue
                .DateEdit1.DateTime = Me.DateEdit1.DateTime
                .DateEdit2.DateTime = Me.DateEdit2.DateTime
                .TextRefNo.EditValue = RefNo
                .TextRefName.EditValue = RefName
                .Show()
            End With

            Dim _PrintAccStatment As Boolean = CBool(BandedGridView1.GetRowCellValue(selectedRowHandles(i), "PrintAccStatment"))
            If _PrintAccStatment = True Then
                Dim F3 As New AccountStatmentForRef
                With F3
                    ._OpenForPrint = True
                    ._PrintOption = "Print"
                    .CheckReportForRef.Text = "True"
                    .CheckCalcOpenBalance.EditValue = Me.CheckPrintPrevBalance.EditValue
                    .DateEditFrom.DateTime = Me.DateEdit1.DateTime
                    .DateEditTo.DateTime = Me.DateEdit2.DateTime
                    .Text = "كشف حساب ( " & BandedGridView1.GetRowCellValue(selectedRowHandles(i), "RefName") & " )"
                    .SearchReferance.Text = BandedGridView1.GetRowCellValue(selectedRowHandles(i), "ReferanceNo")
                    .RefreshDataInAccountStatmentForRef()
                    .Show()
                End With
            End If
        Next
    End Sub
    Private Function OrpakHasHeadOffice() As Boolean
        Dim _result As Boolean
        _result = False
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where  SettingName='OrpakHasHeadOffice' ")
            _result = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _result = False
        End Try
        Return _result
    End Function
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            If BandedGridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If BandedGridView1.SelectedRowsCount = 0 And BandedGridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & BandedGridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
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
            sql.SqlTrueAccountingRunQuery(" select SMSMessage from Messages where ID=6")
            If IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")) Then
                MsgBoxShowError(" يرجى مراجعة مسؤول النظام ")
                Exit Sub
            End If
            _OrigionalSMSMessage = sql.SQLDS.Tables(0).Rows(0).Item("SMSMessage")

            With BandedGridView1
                For i As Integer = 0 To .DataRowCount - 1
                    If BandedGridView1.IsRowSelected(i) = True Then
                        _ReferanceNo = .GetRowCellValue(i, "ReferanceNo")
                        If Not String.IsNullOrEmpty(_ReferanceNo) Then
                            Dim _RefData = GetRefranceData(_ReferanceNo)
                            _RefMobile = _RefData.RefMobile
                            _RefName = .GetRowCellValue(i, "RefName")
                            _DocAmount = .GetRowCellValue(i, "DebitAsAccount")
                            _DocCurrency = GetCurrencyCode(GetDefaultCurrency())

                            _DocData = "Journal"
                            _DocDate = Format(DateEdit1.DateTime, "yyyy-MM-dd")
                            _SMSMessage = _OrigionalSMSMessage
                            _SMSMessage = _SMSMessage.Replace("#ReferanceName#", _RefName)
                            _SMSMessage = _SMSMessage.Replace("#Amount#", _DocAmount)
                            _SMSMessage = _SMSMessage.Replace("#DocDate#", _DocDate)
                            _SMSMessage = _SMSMessage.Replace("#Balance#", GetReferanceBalance(_ReferanceNo))
                            _SMSMessage = _SMSMessage.Replace("#Period#", Format(DateEdit1.DateTime, "yyyy-MM"))
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
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (BandedGridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & BandedGridView1.SelectedRowsCount)
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

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridControl1.Print()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            '   BandedGridView1.OptionsSelection.MultiSelect = True
            BandedGridView1.SelectAll()
            BandedGridView1.CopyToClipboard()
            ' BandedGridView1.OptionsSelection.MultiSelect = False
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم نسخ التقرير بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
        Catch ex As Exception
            XtraMessageBox.Show("خطا في عملية النسخ ، يرجى اعادة المحاولة")
        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Try
            If BandedGridView1.RowCount = 0 Then
                XtraMessageBox.Show("لا يوجد بيانات")
                Exit Sub
            End If

            If BandedGridView1.SelectedRowsCount = 0 And BandedGridView1.RowCount > 0 Then
                XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
                Exit Sub
            End If


            If XtraMessageBox.Show(" هل تريد ارسال مسجات الى  " & BandedGridView1.SelectedRowsCount & " ملف ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
            Dim _ReferanceNo As Integer
            Dim _RefMobile As String
            Dim J As Integer = 0

            Dim selectedRowHandles As Integer() = BandedGridView1.GetSelectedRows()

            For i As Integer = 0 To selectedRowHandles.Length - 1
                _ReferanceNo = CInt(BandedGridView1.GetRowCellValue(selectedRowHandles(i), "ReferanceNo"))
                Dim _RefData = GetRefranceData(_ReferanceNo)
                With BandedGridView1
                    _RefMobile = _RefData.RefMobile
                    Dim F As New FleetTrans
                    With F
                        ._OpenForPrint = True
                        ._SendWhatsApp = True
                        .CheckEditShowBalance.EditValue = CheckEditShowBalance.EditValue
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .TextRefNo.EditValue = _ReferanceNo
                        .TextRefName.EditValue = _RefData.RefName
                        .Show()
                    End With


                    Dim _PrintAccStatment As Boolean = CBool(BandedGridView1.GetRowCellValue(selectedRowHandles(i), "PrintAccStatment"))
                    If _PrintAccStatment = True Then
                        Dim F3 As New AccountStatmentForRef
                        With F3
                            ._OpenForPrint = True
                            ._PrintOption = "SendWhatsApp"
                            .CheckReportForRef.Text = True
                            .DateEditFrom.DateTime = Me.DateEdit1.DateTime
                            .DateEditTo.DateTime = Me.DateEdit2.DateTime
                            .Text = "كشف حساب ( " & _RefData.RefName & " )"
                            .SearchReferance.EditValue = _ReferanceNo
                            .RefreshDataInAccountStatmentForRef()
                            .Show()
                        End With
                    End If

                    J = J + 1

                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * J / (BandedGridView1.SelectedRowsCount)) & "%" &
                                                                          " " & J & " From " & BandedGridView1.SelectedRowsCount)
                    End If
                End With

            Next




        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub
End Class