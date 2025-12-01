Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class ImportReferancesBalance
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleGetFile.Click

        Try
            Dim strConnection As String = "ConnectionString"
            Dim connectionString As String = ""
            XtraOpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            Dim res As DialogResult = XtraOpenFileDialog1.ShowDialog()
            Dim fileName As String = Path.GetFileName(XtraOpenFileDialog1.FileName)
            Dim fileExtension As String = Path.GetExtension(XtraOpenFileDialog1.FileName)
            If String.IsNullOrEmpty(fileExtension) Then
                Return
            End If
            Dim fileLocation As String = XtraOpenFileDialog1.FileName
            TextFilePath.Text = XtraOpenFileDialog1.FileName
            If fileExtension = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
            ElseIf fileExtension = ".xlsx" Or fileExtension = ".xlsm" Then
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fileLocation & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
            End If
            Dim con As OleDbConnection = New OleDbConnection(connectionString)
            Dim cmd As OleDbCommand = New OleDbCommand()
            cmd.CommandType = System.Data.CommandType.Text
            cmd.Connection = con
            Dim dAdapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim dtExcelRecords As DataTable = New DataTable()
            con.Open()

            Dim dtExcelSheetName As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim getExcelSheetName As String = dtExcelSheetName.Rows(0)("Table_Name").ToString()
            cmd.CommandText = " SELECT Code,AccountName,Balance as BalanceFromExcel ,Phone,Mobile,Type,Address,Notes,
                                       '' as IsExist, '' as Result,'0' as Journal,'' as BalanceFromAccounting , '' as Diff  FROM [Sheet1$] where [Code] <> '' "
            dAdapter.SelectCommand = cmd
            dAdapter.Fill(dtExcelRecords)
            GridControl1.DataSource = dtExcelRecords

            CheckData()
            con.Close()



        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
            SplashScreenManager.CloseForm(False)
        End Try

        If GridView1.RowCount > 0 Then
            SimpleImportData.Enabled = True
        End If




    End Sub

    Private Sub CheckData()

        Try
            My.Forms.Main.ItemElapseTime.Caption = "0"
            Dim start_time As DateTime
            Dim stop_time As DateTime
            Dim elapsed_time As TimeSpan
            start_time = Now
            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات ")
            Dim _CustCode As String
            With GridView1
                For i As Integer = 0 To .DataRowCount - 1
                    .SetRowCellValue(i, "Diff", 0.00)
                    _CustCode = .GetRowCellValue(i, "Code")
                    '  _Balance = GridView1.GetRowCellValue(i, "Balance")
                    Dim SqlString1 As String
                    Dim dr As SqlDataReader
                    Using connection As SqlConnection = New SqlConnection(My.Settings.TrueTimeConnectionString)
                        connection.Open()
                        SqlString1 = "   Select Isnull(A.RefNo,0) as RefNo,isnull(B.BalanceFromAccounting,0.00) AS  BalanceFromAccounting from 
  (Select isnull(RefNo,0) as RefNo,ReferanceCode From [dbo].[Referencess]) A
  left join
  (Select J.Referance as AccNo, R.RefName as AccName ,
  CONVERT(DECIMAL(16,2),SUM(CASE When CredAcc='0' Then BaseCurrAmount Else 0.00 End ))  - CONVERT(DECIMAL(16,2), SUM(CASE When DebitAcc='0' Then BaseCurrAmount Else 0.00 End ))   As BalanceFromAccounting 
  from journal J 
  left join Referencess R on R.RefNo=J.Referance 
  where j.DocStatus<>0 And J.DocDate <= '" & Format(DateOfBalance.DateTime, "yyyy-MM-dd") & "' AND  (j.DebitAcc= R.RefAccID or j.CredAcc= R.RefAccID) 
  group by Referance,RefName) B
  on A.RefNo=B.AccNo where   A.[ReferanceCode]=N'" & _CustCode & "'"
                        Dim _ExcelBanalce, _AccountingBalance As Decimal
                        _ExcelBanalce = CDec(GridView1.GetRowCellValue(i, "BalanceFromExcel"))
                        Using command1 As SqlCommand = New SqlCommand(SqlString1, connection)
                            dr = command1.ExecuteReader
                            If dr.HasRows Then
                                dr.Read()
                                .SetRowCellValue(i, "IsExist", dr.Item("RefNo"))
                                .SetRowCellValue(i, "BalanceFromAccounting", dr.Item("BalanceFromAccounting"))
                                _AccountingBalance = CDec(dr.Item("BalanceFromAccounting"))
                                If Not IsDBNull(GridView1.GetRowCellValue(i, "BalanceFromAccounting")) Then
                                    .SetRowCellValue(i, "Diff", _ExcelBanalce - _AccountingBalance)
                                Else
                                    .SetRowCellValue(i, "Diff", -1 * _ExcelBanalce)
                                End If
                                dr.Close()
                            Else
                                dr.Close()
                                .SetRowCellValue(i, "Diff", -1 * _ExcelBanalce)
                            End If
                        End Using
                    End Using
                    Try

                    Catch ex As Exception
                        SplashScreenManager.CloseForm(False)
                    End Try


                    If .DataRowCount > 0 Then
                        SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (.DataRowCount)) & "%" &
                                                                           " " & i & " From " & .DataRowCount)
                    End If



                Next
            End With


            SplashScreenManager.CloseForm(False)
            stop_time = Now
            elapsed_time = stop_time.Subtract(start_time)
            My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))


            'For i As Integer = 0 To GridView1.DataRowCount - 1
            '    If GridView1.IsRowSelected(i) = True Then
            '        'Do something  
            '    Else
            '        'Do something else  
            '    End If
            'Next


            'Using conn As SqlConnection = New SqlConnection(My.Settings.TrueTimeConnectionString)
            '    conn.Open()
            '    Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            '    For i As Integer = 0 To selectedRowHandles.Length - 1
            '        Dim value As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "FieldName")
            '    Next
            'End Using


        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
        End Try




    End Sub
    Private Sub ImportData()
        My.Forms.Main.ItemElapseTime.Caption = "0"
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        start_time = Now

        Dim _AcumlateBalance As Decimal = 0

        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد بيانات")
            Exit Sub
        End If

        If GridView1.SelectedRowsCount = 0 And GridView1.RowCount > 0 Then
            XtraMessageBox.Show("الرجاء اختيار الاسماء من القائمة")
            Exit Sub
        End If







        If XtraMessageBox.Show(" هل تريد سحب البينات؟ " & GridView1.SelectedRowsCount, "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If

        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")

        Dim _DocCode As String = CreateRandomCode()
        Dim _RefNo, _RefCode, _CustName, _Phone, _Mobile, _Address, _Type, _Notes As String
        Dim _PriceCategory As Integer = 1
        Dim RecordUpdated, RecordInserted, RecordJournal As Decimal
        Dim _Balance As Decimal
        With GridView1
            For i As Integer = 0 To .DataRowCount - 1
                If GridView1.IsRowSelected(i) = True Then
                    _RefNo = .GetRowCellValue(i, "IsExist")
                    If Not IsDBNull(.GetRowCellValue(i, "AccountName")) Then
                        _CustName = .GetRowCellValue(i, "AccountName")
                    Else
                        _CustName = String.Empty
                    End If
                    If Not IsDBNull(.GetRowCellValue(i, "Phone")) Then
                        _Phone = .GetRowCellValue(i, "Phone")
                    Else
                        _Phone = String.Empty
                    End If
                    If Not IsDBNull(.GetRowCellValue(i, "Mobile")) Then
                        _Mobile = .GetRowCellValue(i, "Mobile")
                    Else
                        _Mobile = String.Empty
                    End If
                    If Not IsDBNull(.GetRowCellValue(i, "Address")) Then
                        _Address = .GetRowCellValue(i, "Address")
                    Else
                        _Address = String.Empty
                    End If
                    If Not IsDBNull(.GetRowCellValue(i, "Type")) Then
                        _Type = .GetRowCellValue(i, "Type")
                    Else
                        _Type = String.Empty
                    End If
                    If Not IsDBNull(.GetRowCellValue(i, "Diff")) Then
                        _Balance = .GetRowCellValue(i, "Diff")
                    Else
                        _Balance = 0
                    End If
                    'If Not IsDBNull(.GetRowCellValue(i, "PriceCategory")) Then
                    '    _PriceCategory = .GetRowCellValue(i, "PriceCategory")
                    'Else
                    '    _PriceCategory = 1
                    'End If
                    If Not IsDBNull(.GetRowCellValue(i, "Notes")) Then
                        _Notes = .GetRowCellValue(i, "Notes")
                    Else
                        _Notes = " "
                    End If

                    _RefCode = .GetRowCellValue(i, "Code")
                    Dim SqlStringUpdate, SqlStringInsert As String
                    Using connection As SqlConnection = New SqlConnection(My.Settings.TrueTimeConnectionString)
                        connection.Open()

                        Select Case _RefNo
                            Case > 0
                                SqlStringUpdate = " Update [Referencess] Set [RefName]=N'" & _CustName & "',
                                                RefPhone='" & _Phone & "',RefMobile='" & _Mobile & "',
                                                Address=N'" & _Address & "' where ReferanceCode=N'" & _RefCode & "'"
                                Using command1 As SqlCommand = New SqlCommand(SqlStringUpdate, connection)
                                    RecordUpdated = command1.ExecuteNonQuery()
                                    If RecordUpdated > 0 Then .SetRowCellValue(i, "Result", "Updated")
                                End Using
                            Case ""
                                SqlStringInsert = " Insert Into [dbo].[Referencess] (RefNo,RefName,RefPhone,RefMobile,Address,RefType,RefAccID,[ReferanceCode],RefBirthDate,PriceCategory,RefMemo,Active) 
                                                Values
                                                (isnull((Select max(RefNo)+1 from [Referencess]),1) ,N'" & _CustName & "','" &
                                                    _Phone & "','" & _Mobile & "','" & _Address & "'," & _Type & ",'" &
                                                    1104010000 & "','" & _RefCode & "','1900-01-01'," & _PriceCategory & ",N'" & _Notes & "',1) "
                                Using command2 As SqlCommand = New SqlCommand(SqlStringInsert, connection)
                                    RecordInserted = command2.ExecuteNonQuery()
                                    If RecordInserted > 0 Then .SetRowCellValue(i, "Result", "Inserted")
                                End Using
                        End Select

                        ' Insert New Balances 
                        If CheckEdit1.Checked = True Then
                            Dim SqlStringInsertToJournal As String
                            SqlStringInsertToJournal = " insert into JournalTemp
                                     ( [DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount) 
                                       Values (
                                      '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 5 & "', 
                                      '" & 1 & "',
                                      '" & 1104010000 & "',
                                      '" & 0 & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & _Balance & "',
                                      '" & 1 & "',
                                      '" & _Balance & "',
                                      '" & _Balance & "',
                                      '" & 0 & "',
                                       N'" & MemoEdit1.Text & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & Format(Now(), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & GetRefNoFromRefCode(_RefCode) & "',
                                      N'" & _CustName & "',
                                       '" & _DocCode & "',
                                      N'" & "" & "'
                                            )"

                            Using command2 As SqlCommand = New SqlCommand(SqlStringInsertToJournal, connection)
                                RecordJournal = command2.ExecuteNonQuery()
                                If RecordJournal > 0 Then
                                    .SetRowCellValue(i, "Journal", "Done")
                                    _AcumlateBalance += _Balance
                                End If
                            End Using






                        End If


                    End Using
                Else
                    .SetRowCellValue(i, "Result", "Nothing")
                End If
                .UnselectRow(i)

                If .DataRowCount > 0 Then
                    SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (.DataRowCount)) & "%" &
                                                                       " " & i & " From " & .DataRowCount)
                End If

            Next

            Dim Sql As New SQLControl
            Dim SqlStringInsertOtherAccount As String
            SqlStringInsertOtherAccount = " insert into JournalTemp
                     ( [DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                       [BaseCurrAmount],[BaseAmount],
                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                       CurrentUserID,DocCode,DocNoteByAccount) 
                       Values (
                      '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "', 
                      '" & 5 & "', 
                      '" & 1 & "',
                      '" & 0 & "',
                      '" & OtherAccount.EditValue & "',
                      '" & 1 & "',
                      '" & 1 & "',
                      '" & _AcumlateBalance & "',
                      '" & 1 & "',
                      '" & _AcumlateBalance & "',
                      '" & _AcumlateBalance & "',
                      '" & 0 & "',
                       N'" & MemoEdit1.Text & "' ,
                      '" & GlobalVariables.CurrUser & "',
                      '" & Format(Now(), "yyyy-MM-dd HH:mm") & "',
                      '" & GlobalVariables.CurrUser & "',
                      '" & _DocCode & "',
                      N'" & "" & "'
                            )"
            Sql.SqlTrueAccountingRunQuery(SqlStringInsertOtherAccount)

            Dim SqlString3 As String
            SqlString3 = "   Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                        [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                        [BaseCurrAmount],[BaseAmount],
                                                        [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                        [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                        [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                        [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,DeliverDate )"
            SqlString3 += " Select "

            SqlString3 += "( Select isnull(max([DocID])+1,1)  from Journal where DocName= 5 ) "

            SqlString3 += " , [DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                        [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                        [BaseCurrAmount],[BaseAmount],
                                                        [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                                        [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                        [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                        [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,DeliverDate
                                                        from JournalTemp ; Delete from JournalTemp "

            Sql.SqlTrueAccountingRunQuery(SqlString3)



        End With
        SplashScreenManager.CloseForm(False)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))

        CheckData()

        XtraMessageBox.Show("Done")

    End Sub

    Private Function GetRefNoFromRefCode(_ReferanceCode As String) As String
        Dim _RefNo As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " Select [RefNo] from [dbo].[Referencess] where  ReferanceCode='" & _ReferanceCode & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _RefNo = Sql.SQLDS.Tables(0).Rows(0).Item("RefNo")
        Catch ex As Exception
            _RefNo = 0
        End Try
        Return _RefNo
    End Function
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleImportData.Click
        ImportData()
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        'Dim RowIndex As Integer = e.ListSourceRowIndex
        'Dim _BeginingBalance As Integer = GridView1.GetListSourceRowCellValue(RowIndex, "BeginingBalance")

        'Dim _PassingDays As Integer
        'If (e.Column.FieldName <> "AccruedVocation") Then Return
        'If (e.IsGetData) Then
        '    If (_ThisYearSetBalance - _ThisYearVocations) <= 0 Then e.Value = 0 : Return
        '    Try
        '        If (_ThisYearSetBalance - _ThisYearVocations) > 0 Then
        '            Dim _PassingDaysFromThisYear As Integer = DateDiff(DateInterval.Day, CDate(Format(Today, "yyyy").ToString & "-01-01"), Today)
        '            Dim _PassingDaysFromStartdate As Integer = DateDiff(DateInterval.Day, CDate(_EmployeeStartDate), Today)

        '            If _PassingDaysFromThisYear > _PassingDaysFromStartdate Then
        '                _PassingDays = _PassingDaysFromStartdate
        '            Else
        '                _PassingDays = _PassingDaysFromThisYear
        '            End If
        '            If _PassingDays <= 0 Then e.Value = 0 : Return
        '            e.Value = (_ThisYearSetBalance * (_PassingDays / 365) + _BeginingBalance - _ThisYearVocations).ToString("0.##")
        '        End If
        '    Catch ex As Exception
        '        e.Value = 0
        '        MsgBox(ex.ToString)
        '    End Try

        'End If

    End Sub

    Private Sub ImportReferancesBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleImportData.Enabled = False
        TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        OtherAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        DateEdit1.DateTime = Today
        DateOfBalance.DateTime = Today
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.Checked = True Then
            TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            TabbedControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CheckData()
    End Sub
End Class