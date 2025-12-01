Imports System.Buffers
Imports System.Data.SqlClient
Imports DevExpress.Utils.Extensions
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports TrueTime.DynamicallyConnectionString

Public Class OrpakAdjustment
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _ValidateRow As Boolean
    Dim _JournalNote As String
    Private Sub OrpakAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchPosName.Properties.DataSource = GetOrpakPos()
        SearchWorkPeriod.ReadOnly = True
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroupTickets
        RepositoryAccountCurr.DataSource = GetCurrency()
        GetNewAccounts()
        Dim _CostCenters As New DataTable
        _CostCenters = GetCostCenter(False)
        RepositoryCostCenter.DataSource = _CostCenters
        LookCostCenter.Properties.DataSource = _CostCenters
        'EmptyJournal()
        'GridJournal.DataSource = EmptyJournal()
        '  RepositoryItemBarcode.DataSource = GetItems(-1)
        SimpleBtnSave.Enabled = False
        SearchPosName.EditValue = 1
    End Sub
    Protected Sub TabbedControlGroup1_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                                   ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupTickets" Then
            GridControlTickets.ShowPrintPreview()
        ElseIf e.Button.Tag = "Refresh" Then
            GetTransactions()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "" Then
            GridControlTickets.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupPayments" Then
            ' GridControlPayments.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupOrders" Then
            ' GridControlOrders.ShowPrintPreview()
        End If
    End Sub
    Protected Sub TabbedControlGroup2_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                                   ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup2.CustomHeaderButtonClick
        If e.Button.Tag = "UpdateAccounts" Then
            GetNewAccounts()
        ElseIf e.Button.Tag = "AddNewRef" Then
            Dim f As New ReferancessAddNew
            With f
                .TextRefNo.Text = GetReferanceMax() + 1
                .TextRefName.Text = ""
                .TextRefMobile.Text = ""
                .TextRefPhone.Text = ""
                .PriceCategory.EditValue = 1
                .TextRefName.Select()
                ._AddNewOrSave = "AddNew"
                .CheckActive.Checked = True
                If .ShowDialog <> DialogResult.OK Then
                    GetNewAccounts()
                End If
            End With
        End If
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) _
        Handles GridViewMasterTickets.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = " "
        Dim Tawqe3_2 As String = " "

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Now(), Tawqe3_2, "Pages: [Page # of Pages #]"})

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.AddRange(New String() {"", ComName, ""})

    End Sub


    Private Sub SearchWorkPeriod_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchWorkPeriod.BeforePopup
        'If TextConnectionString.Text = "" Then
        '    Exit Sub
        'End If
        'Dim connString As String = TextConnectionString.Text
        'Dim conn As New SqlConnection(connString)
        'conn.Open()
        'Dim comm As New SqlCommand("select [id] as WorkPeriodNumber, [open_timestamp] as StartDate ,[close_timestamp] as EndDate, [opened_by_name] as StartByName from [dbo].[shift_instance] where [closed_by_name] <>N'Audited'", conn)
        'Dim reader As SqlDataReader = comm.ExecuteReader
        'Dim dt As New DataTable
        'dt.Load(reader)
        'SearchWorkPeriod.Properties.DataSource = dt

        Try
            If GridViewJournal.RowCount > 2 Then
                'XtraMessageBox.Show(" سيتم افراغ محتويات السند هل تريد الاستمرار ")
                If DevExpress.XtraEditors.XtraMessageBox.Show("  سيتم افراغ محتويات السند هل تريد الاستمرار ", "تاكيد", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If

            SearchWorkPeriod.Text = ""
            TextEmployeeName.Text = ""

            Dim sqlstring As String = " SELECT
                                        shift_id as WorkPeriodNumber ,mean_name as StartByName,sum(sale) as Amount
                                    FROM
                                        [dbo].[transactions] T
                                    WHERE  T.fleet_id =200000000 and proxy_id=0 and  NOT EXISTS 
                                    (
                                    SELECT shiftID,[EmployeeName] 
                                        FROM
                                            [dbo].[ttsShiftsReads] L
		                                Where T.shift_id=L.[ShiftID] and T.mean_name=L.[EmployeeName] 
                                    )
                                    Group by shift_id,mean_name
                                    Order by shift_id  "

            If TextConnectionString.Text = "" Then
                Exit Sub
            End If
            Dim connString As String = TextConnectionString.Text
            Dim conn As New SqlConnection(connString)
            conn.Open()
            Dim comm As New SqlCommand(sqlstring, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            dt.Load(reader)
            SearchWorkPeriod.Properties.DataSource = dt

        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try




    End Sub

    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosName.EditValueChanged

        GetWorkPeriod()
    End Sub
    Private Sub GetWorkPeriod()
        SearchWorkPeriod.Text = ""
        TextEmployeeName.Text = ""
        If Me.IsHandleCreated = True Then
            TextConnectionString.Text = ""

            If String.IsNullOrEmpty(SearchPosName.Text) Then
                Exit Sub
            End If
            Try
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " SELECT  ServerAddress,TempAccounting,CostCenter
                                  FROM AccountingPOSNames 
                                  Where ID=" & SearchPosName.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
                TextConnectionString.Text = sql.SQLDS.Tables(0).Rows(0).Item("ServerAddress")
                TextTempAccount.Text = sql.SQLDS.Tables(0).Rows(0).Item("TempAccounting")
                LookCostCenter.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("CostCenter")
                If Not String.IsNullOrEmpty(TextConnectionString.Text) Then
                    Try
                        Dim helper As SqlHelper = New SqlHelper(TextConnectionString.Text)
                        If helper.IsConnection Then
                            SearchWorkPeriod.ReadOnly = False
                        Else
                            SearchWorkPeriod.ReadOnly = True
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End If
    End Sub
    Private Sub ChangePeriodStatus()
        Dim rowsAffected As Integer
        Using con As New SqlConnection(TextConnectionString.Text)
            Using cmd As New SqlCommand("Update  [dbo].[shift_instance] Set [closed_by_name]='Audited' Where ID=" & SearchWorkPeriod.EditValue, con)
                con.Open()
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

    Private Sub SearchWorkPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles SearchWorkPeriod.EditValueChanged
        GetWorkPeriodDetails()
    End Sub
    Private Sub GetWorkPeriodDetails()
        If Me.SearchWorkPeriod.Text = "" Then
            Me.TextEmployeeName.Text = ""
            Exit Sub
        End If

        Try
            Dim view As GridView = SearchWorkPeriod.Properties.View
            Dim rowHandle As Integer = view.FocusedRowHandle
            Dim fieldName As String = "StartByName"
            Dim value As Object = view.GetRowCellValue(rowHandle, fieldName)
            Me.TextEmployeeName.Text = value
        Catch ex As Exception

        End Try


    End Sub
    'Private Sub GetEmployeesForShift(ShiftID As Integer)
    '    If TextConnectionString.Text = "" Then
    '        Exit Sub
    '    End If
    '    Dim connString As String = TextConnectionString.Text
    '    Dim conn As New SqlConnection(connString)
    '    conn.Open()
    '    Dim comm As New SqlCommand("  select [mean_name] as EmployeeName from [transactions] where type='ATNDT' and shift_id=" & ShiftID & " group by [mean_name]", conn)
    '    Dim reader As SqlDataReader = comm.ExecuteReader
    '    Dim dt As New DataTable
    '    dt.Load(reader)
    '    SearchEmployee.Properties.DataSource = dt
    'End Sub
    Private Sub GetTicketsMaster(ShiftID As Integer)
        'GridControlTickets.DataSource = ""
        'Dim SqlString As String
        'Dim SqlString2 As String
        'Dim SqlString3 As String
        'Dim SqlString4 As String
        'Dim SqlString5 As String
        'Dim sql As New SQLControl
        'Dim JouranlTable As New DataTable

        'TextWorkPeriodStatus.EditValue = 1
        'sql.SqlTrueAccountingRunQuery(" Delete   FROM [dbo].[SambaOrdersTemp] ;
        '                                Delete   FROM [dbo].[SambaTicketsTemp]")

        'SqlString = "SELECT T.[Id]      , [LastUpdateTime]      , [TicketVersion],
        '                    LEFT([TicketUid],50) As TicketCode     , [TicketNumber]      , [Date],
        '                    [LastOrderDate]      , [LastPaymentDate]      , T.[PreOrder],
        '                    [IsClosed]      , [IsLocked]      , [IsOpened],
        '                    [RemainingAmount]      , [TotalAmount]      , [TotalAmountPreTax],
        '                    D.Name as DepartmentName      , TR.Name As TerminalName    , TT.Name As TicketTypeName,
        '                    [Note]      , [LastModifiedUserName]      , [CreatedUserName],
        '                    [TicketTags]      , [TicketStates]      , [TicketLogs],
        '                    [LineSeparators]      , [ExchangeRate]      , T.[TaxIncluded],
        '                    T.[Name]      , [TransactionDocument_Id]
        '              FROM [dbo].[Tickets] T
        '                    left join Departments D on T.DepartmentId=D.Id
        '                    left join Terminals TR on TR.Id=T.TerminalId
        '                    left join TicketTypes TT on TT.Id=T.TicketTypeId 
        '              Where Date Between '" & StartDate & "' And '" & EndDate & "' Order by TicketNumber"


        'SqlString2 = " SELECT 
        '                  P.[Id]      ,P.TicketId
        '                  , TC.TicketNumber      , P.[Name] As AccountName
        '                  , [Description]      , P.[Date]
        '                  , [AccountTransactionId]       , [Amount]
        '                  , Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end As CurrAmount
        '                  , P.[ExchangeRate]      , [PaymentData]
        '                  , [CanAdjustTip]      , [AccountTransaction_Id]
        '                  , [AccountTransaction_AccountTransactionDocumentId]
        '                  , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
        '                  , U.Name As Username      , D.Name As DepartmentName
        '                  , TR.Name As TerminalName
        '            FROM [dbo].[Payments] P
        '                left join PaymentTypes T on P.PaymentTypeId=T.Id
        '                left join Accounts A on A.Id=T.Account_Id
        '                left join AccountTypes AT on AT.Id=A.AccountTypeId
        '                left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
        '                left Join Users U on U.Id=P.UserId
        '                left Join Departments D on D.Id=P.DepartmentId
        '                left join Terminals TR on TR.Id=P.TerminalId
        '                left join Tickets TC on TC.Id=P.TicketId
        '            Where TC.Date Between '" & StartDate & "' And '" & EndDate & "' 
        '            Order by TC.TicketNumber "

        'SqlString3 = " SELECT O.[Id]
        '                    , O.[TicketId] , T.TicketNumber     , O.[WarehouseId]
        '                    , D.Name As DepartmentName      , TR.Name as TerminalName
        '                    , O.[MenuItemId]      , O.[MenuItemName]
        '                    , O.[PortionName]      , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
        '                    , O.[Quantity] , Case when CalculatePrice=0 then 0 else [Price]*[Quantity] End As Amount     , O.[PortionCount]
        '                    , O.[Locked]      , O.[CalculatePrice]
        '                    , O.[DecreaseInventory]      , O.[IncreaseInventory]
        '                    , O.[OrderNumber]      , O.[CreatingUserName]
        '                    , O.[CreatedDateTime]      , O.[LastUpdateDateTime]
        '                    , O.[AccountTransactionTypeId]      , O.[ProductTimerValueId]
        '                    , O.[GroupTagName]      , O.[GroupTagFormat]
        '                    , O.[Separator]      , O.[PriceTag]
        '                    , O.[Tag]      , O.[DisablePortionSelection]
        '                    , O.[OrderUid]      , O.[Taxes]
        '                    , O.[OrderTags],M.Barcode
        '               FROM [dbo].[Orders] O
        '                        Left Join [dbo].[Tickets] T on T.id=O.TicketId
        '                        left join Departments D on D.Id=O.DepartmentId
        '                        left join Terminals TR on TR.Id=O.TerminalId
        '                        left join MenuItems M on M.Id=O.MenuItemId
        '               Where  T.Date Between '" & StartDate & "' And '" & EndDate & "' 
        '               Order by T.TicketNumber"

        'SqlString4 = " SELECT O.[Id],
        '                      O.[MenuItemId]      , O.[MenuItemName]
        '                    , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
        '                    , O.[Quantity] , Case when CalculatePrice=0 then 0 else [Price]*[Quantity] End As Amount 
        '                    ,M.Barcode,'" & GlobalVariables.CurrUser & "' As UserID ,'" & SearchWorkPeriod.EditValue & "' As WorkPeriod,O.TicketId,T.TicketNumber
        '               FROM [dbo].[Orders] O
        '                        Left Join [dbo].[Tickets] T on T.id=O.TicketId
        '                        left join MenuItems M on M.Id=O.MenuItemId
        '               Where DecreaseInventory<>0 And T.Date Between '" & StartDate & "' And '" & EndDate & "' 
        '               Order by T.TicketNumber"

        'SqlString5 = "SELECT T.[Id]    ,LEFT([TicketUid],50) As TicketCode, [TicketNumber], [Date],TotalAmount,
        '                               '" & GlobalVariables.CurrUser & "' As userid,'" & SearchWorkPeriod.EditValue & "' As WorkPeriod
        '              From [dbo].[Tickets] T
        '              Where Date Between '" & StartDate & "' And '" & EndDate & "' Order by TicketNumber"

        'Dim Con As SqlConnection
        'Dim Adapter1, Adapter2, Adapter3, Adapter4, Adapter5 As SqlDataAdapter
        'Dim dataSet11 As DataSet

        'Con = New SqlConnection(TextConnectionString.Text)
        'Con.Open()
        'Adapter1 = New SqlDataAdapter(SqlString, Con)
        'Adapter2 = New SqlDataAdapter(SqlString2, Con)
        'Adapter3 = New SqlDataAdapter(SqlString3, Con)
        'Adapter4 = New SqlDataAdapter(SqlString4, Con)
        'Adapter5 = New SqlDataAdapter(SqlString5, Con)
        'dataSet11 = New System.Data.DataSet()
        'Adapter1.Fill(dataSet11, "Tickets")
        'Adapter2.Fill(dataSet11, "Payments")
        'Adapter3.Fill(dataSet11, "Orders")
        'Adapter4.Fill(dataSet11, "TempOrders")
        'Adapter5.Fill(dataSet11, "TempTickets")
        'Con.Close()
        ''For x As Integer = dataSet11.Tables.Count - 1 To 0 Step -1
        ''    Dim dt = dataSet11.Tables(x)
        ''    dt.DefaultView.Sort = "id Asc"
        ''    dataSet11.Tables.RemoveAt(x)
        ''    dataSet11.Tables.Add(dt.DefaultView.ToTable)
        ''Next
        'dataSet11.AcceptChanges()
        'Dim keyColumn As DataColumn = dataSet11.Tables("Tickets").Columns("id")
        'Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Payments").Columns("TicketId")
        'Dim foreignKeyColumn2 As DataColumn = dataSet11.Tables("Orders").Columns("TicketId")
        'dataSet11.Relations.Add("الدفعات", keyColumn, foreignKeyColumn)
        'dataSet11.Relations.Add("الأصناف", keyColumn, foreignKeyColumn2)
        'dataSet11.Tables("Tickets").DefaultView.Sort = "id ASC"

        'GridControlTickets.DataSource = dataSet11.Tables("Tickets")
        'GridControlTickets.ForceInitialize()
        'GridControlTickets.LevelTree.Nodes.Add("الدفعات", GridView6)
        'GridControlTickets.LevelTree.Nodes.Add("الأصناف", GridView7)

        'GridControlPayments.DataSource = dataSet11.Tables("Payments")
        'GridControlOrders.DataSource = dataSet11.Tables("Orders")

        '' Fill SambaOrdersTemp Table
        '' Dim sql As New SQLControl
        'sql.SqlTrueAccountingRunQuery("delete from [SambaOrdersTemp] 
        '                               where userid=" & GlobalVariables.CurrUser)
        'Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
        '    For Each col As DataColumn In dataSet11.Tables("TempOrders").Columns
        '        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
        '    Next
        '    bulkCopy.BulkCopyTimeout = 600
        '    bulkCopy.DestinationTableName = "SambaOrdersTemp"
        '    bulkCopy.WriteToServer(dataSet11.Tables("TempOrders"))
        'End Using

        'sql.SqlTrueAccountingRunQuery("delete from [SambaTicketsTemp] 
        '                               where userid=" & GlobalVariables.CurrUser)
        'Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
        '    For Each col As DataColumn In dataSet11.Tables("TempTickets").Columns
        '        bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
        '    Next
        '    bulkCopy.BulkCopyTimeout = 600
        '    bulkCopy.DestinationTableName = "SambaTicketsTemp"
        '    bulkCopy.WriteToServer(dataSet11.Tables("TempTickets"))
        'End Using
    End Sub

    'Private Sub RepositoryItemLookUpEdit1_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.BeforePopup
    '    GetNewAccounts()
    'End Sub

    Private Sub GetNewAccounts()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select RefNo,AccNo,AccName,AccType,Currency,Code As CurrCode 
                             From 
                                   (
                                    Select CONVERT(NVARCHAR(20), RefNo) as RefNo ,RefAccID  as [AccNo],RefName as [AccName], 
                                           'Ref' As AccType,F.Currency as  Currency
                                    from Referencess R Left Join FinancialAccounts F on F.AccNo=R.RefAccID
                                    Union
                                    SELECT CONVERT(NVARCHAR(20), [AccNo]) as RefNo, [AccNo] ,[AccName], 'Acc' As AccType,Currency
                                    FROM [dbo].[FinancialAccounts] Where IsMain =0 
                                   ) A
                             Left Join 
                                   (
                                Select CurrID,Code from Currency 
                                   ) B
                             on A.Currency=B.CurrID
                             order by RefNo"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        RepositoryItemLookUpEdit1.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.EditValueChanged
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        Dim _RefNo As Object = row("RefNo")
        Dim _AccNo As Object = row("AccNo")
        Dim _CurrCode As Object = row("CurrCode")
        Dim _AccType As Object = row("AccType")
        Dim _Currency As Object = row("Currency")
        GridViewJournal.SetFocusedRowCellValue("Account", _AccNo)
        GridViewJournal.SetFocusedRowCellValue("AccountNew", _RefNo)
        If _AccType = "Ref" Then
            GridViewJournal.SetFocusedRowCellValue("Referance", _RefNo)
        End If
        GridViewJournal.SetFocusedRowCellValue("AccountCurr", _Currency)
        Dim _ExchRate = GetExchengPrice(_Currency, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        GridViewJournal.SetFocusedRowCellValue("ExchangePrice", _ExchRate)
        If _Currency = _DefaultCurr Then
            GridViewJournal.SetFocusedRowCellValue("ExchangePrice", 1)
        End If
        GridViewJournal.SetFocusedRowCellValue("DocCurrency", _Currency)
        GridViewJournal.FocusedColumn = ColDebitAmount
        'MsgBox(GridView1.DataRowCount)
    End Sub
    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles GridJournal.ProcessGridKey
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                view.DeleteSelectedRows()
                GridViewJournal.UpdateSummary()
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridViewJournal.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub


    Private Sub View1_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridViewJournal.ValidateRow
        If _ValidateRow = False Then Exit Sub
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _AccountNew As GridColumn = view.Columns("AccountNew")
            If IsDBNull(Me.GridViewJournal.GetRowCellValue(GridViewJournal.FocusedRowHandle, "AccountNew")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الحساب"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _AccountNew
                view.ShowEditor()
            End If

            Dim _ExchangePrice As GridColumn = view.Columns("ExchangePrice")
            If IsDBNull(Me.GridViewJournal.GetRowCellValue(GridViewJournal.FocusedRowHandle, "ExchangePrice")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال سعر الصرف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ExchangePrice
                view.ShowEditor()
            End If


            Dim _DebitAmount As GridColumn = view.Columns("DebitAmount")
            Dim _CreditAmount As GridColumn = view.Columns("CreditAmount")
            If IsDBNull(Me.GridViewJournal.GetRowCellValue(GridViewJournal.FocusedRowHandle, "DebitAmount")) = True AndAlso
                IsDBNull(Me.GridViewJournal.GetRowCellValue(GridViewJournal.FocusedRowHandle, "CreditAmount")) = True Then
                e.Valid = False
                e.ErrorText = "خطأ، يجب ادخال المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DebitAmount
                view.ShowEditor()
            End If
            If GridViewJournal.GetFocusedRowCellValue("DebitAmount") = 0 And GridViewJournal.GetFocusedRowCellValue("CreditAmount") = 0 Then
                e.Valid = False
                e.ErrorText = "خطأ، يجب ادخال المبلغ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _DebitAmount
                view.ShowEditor()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetWorkPeriod()
        'GetWorkPeriodDetails()
        '  RepositoryItemBarcode.DataSource = GetItems(-1)
    End Sub
    Private Sub GridViewJournal_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridViewJournal.CellValueChanged
        GridViewJournal.UpdateTotalSummary()
        TextJournalTotals.EditValue = ColBaseCurrAmount.SummaryItem.SummaryValue
    End Sub
    Private edit As BaseEdit = Nothing
    Dim _FieldName As String
    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridViewJournal.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor
        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
    End Sub
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        With GridViewJournal
            If .PostEditor() Then
                _ValidateRow = False
                GridViewJournal.UpdateCurrentRow()
                _ValidateRow = True
                Dim _DebitAmount As Decimal = 0
                Dim _CreditAmount As Decimal = 0
                Dim _ExchangePrice As Decimal = 0
                If IsDBNull(.GetFocusedRowCellValue("DebitAmount")) Then
                    .SetFocusedRowCellValue(("DebitAmount"), 0)
                End If
                If IsDBNull(.GetFocusedRowCellValue("CreditAmount")) Then
                    .SetFocusedRowCellValue(("CreditAmount"), 0)
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
                                '    GridViewJournal.UpdateCurrentRow()
                            End If
                            If .GetFocusedRowCellValue("DebitAmount") = 0 And .GetFocusedRowCellValue("CreditAmount") = 0 Then
                                .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
                            End If
                            ' GridViewJournal.UpdateCurrentRow()
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Case "CreditAmount"
                        Try
                            If _CreditAmount <> "0" Then
                                _DebitAmount = 0
                                .SetFocusedRowCellValue(("DebitAmount"), 0)
                                .SetFocusedRowCellValue(("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                                '  GridViewJournal.UpdateCurrentRow()
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
                            If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
                                .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            End If
                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try
                End Select
                .UpdateTotalSummary()
                TextJournalTotals.EditValue = ColBaseCurrAmount.SummaryItem.SummaryValue
                '.UpdateSummary()
                'GridViewJournal.UpdateCurrentRow()
                'GlobalVariables._TempItemNo = 0

                'Dim i As Integer
                'Dim _Sum As Decimal
                'For i = 0 To GridViewJournal.RowCount
                '    _Sum += .GetRowCellValue(i, "BaseCurrAmount")
                'Next
                'TextJournalTotals.Text = _Sum
            End If


        End With

    End Sub
    Private Sub gridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridViewJournal.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedColumn.FieldName = "ExchangePrice" AndAlso Me.GridViewJournal.GetRowCellValue(GridViewJournal.FocusedRowHandle, "DocCurrency") = 1 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub EmptyJournal()
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
        End With
        Dim _CashAccount As String
        Dim _VoucherAmount As Decimal
        _CashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
        _VoucherAmount = ColAmount.SummaryItem.SummaryValue
        TextJournalTotals.EditValue = _VoucherAmount
        JournalTable.Rows.Add(_CashAccount, 1, _VoucherAmount, 0, 1, _VoucherAmount, 0, "", "", 1, _CashAccount, 1)
        DocNote.Text = _JournalNote
        GridJournal.DataSource = JournalTable
        'DocCode.Text = CreateRandomCode()
    End Sub

    Private Sub GridJournal_Click(sender As Object, e As EventArgs) Handles GridJournal.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleBtnSave.Click

        Try
            GridViewJournal.UpdateCurrentRow()
            Dim _JournalAmount As Decimal = 0
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  SELECT DISTINCT t1.[product_name] as MenuItemName,t2.ItemNo, [product_code] as Barcode
                                         FROM [dbo].[OrpakTransactionsTemp] t1
                                         LEFT JOIN Items t2 ON t2.ItemNo  = t1.[product_code]
                                         WHERE t2.ItemNo  IS NULL ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim F As New SambaUnMatchItems
                With F
                    .GridControl1.DataSource = sql.SQLDS.Tables(0)
                    .Text = " الاصناف التالية غير معرفة في النظام المالي "
                    .GridColumn1.Caption = "رقم الصنف في اورباك"
                    .ShowDialog()
                End With
                Exit Sub
            End If
            Dim sqlCon As SqlConnection
            sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using (sqlCon)
                Dim sqlComm As New SqlCommand
                sqlComm.Connection = sqlCon
                sqlComm.CommandText = "OrpakAdjustment"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000
                sqlComm.Parameters.AddWithValue("USERID", GlobalVariables.CurrUser)
                sqlComm.Parameters.AddWithValue("PosNo", SearchPosName.EditValue)
                sqlComm.Parameters.AddWithValue("WorkPeriod", SearchWorkPeriod.EditValue)
                sqlComm.Parameters.AddWithValue("StartDate", TextFromDate.Text)
                sqlComm.Parameters.AddWithValue("EndDate", TextToDate.Text)
                sqlComm.Parameters.AddWithValue("Employee", TextEmployeeName.Text)
                sqlCon.Open()
                Dim returarameter = sqlComm.Parameters.Add("@TicketsAmount", SqlDbType.Decimal)
                returarameter.Direction = ParameterDirection.ReturnValue
                sqlComm.ExecuteNonQuery()
                sqlCon.Close()
                _JournalAmount = returarameter.Value
            End Using

            Dim _Diff As Decimal = _JournalAmount - TextVouchersTotal.EditValue
            If Math.Abs(_Diff) < 1 And Math.Abs(_Diff) > -1 Then
                If PostJournal() = True Then
                    MsgBox("تم ترحيل البيانات بنجاح")
                    ChangePeriodStatus()
                    Me.SearchWorkPeriod.EditValue = -1
                    ' Me.Close()
                    GridControlTickets.DataSource = ""
                    EmptyJournal()
                    TextEmployeeName.Text = ""
                    SearchWorkPeriod.Text = ""
                    TextVouchersTotal.EditValue = 0
                    DocNote.Text = ""
                    SimpleBtnSave.Enabled = False
                    TextEmployeeName.Text = ""
                    GridViewMasterTickets.ViewCaption = ""
                End If
            End If

        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try





        'GridControl1.DataSource = dataSet11.Tables("MenuItems")

    End Sub
    Private Function PostJournal() As Boolean
        Dim _Return As Boolean = False
        Dim _DocCode As String = CreateRandomCode()
        Dim _InputDateTime As String
        Dim _DocID2 As Integer
        _InputDateTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery("declare @testdate datetime='" & _InputDateTime &
                                "' select  cast(CONVERT(varchar(20),@testdate,112) as INT) As DocID2")
        _DocID2 = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocID2")) + SearchWorkPeriod.EditValue + SearchPosName.EditValue
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
        End With

        With GridViewJournal  ' 
            For i = 0 To .RowCount - 1
                If Not String.IsNullOrEmpty(.GetRowCellValue(i, "BaseCurrAmount")) Then
                    Dim _Referance As String = "0"
                    Try
                        _Referance = .GetRowCellValue(i, "Referance")
                    Catch ex As Exception
                        _Referance = "0"
                    End Try
                    Dim R As DataRow = JournalTable.NewRow
                    R("DocDate") = Format(DateDocDate.DateTime, "yyyy-MM-dd")
                    R("DocName") = 5
                    If .GetRowCellValue(i, "DebitAmount") <> "0" Then R("DebitAcc") = .GetRowCellValue(i, "Account") Else R("DebitAcc") = 0
                    If .GetRowCellValue(i, "CreditAmount") <> "0" Then R("CredAcc") = .GetRowCellValue(i, "Account") Else R("CredAcc") = 0
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
                    R("InputDateTime") = _InputDateTime
                    R("DocNotes") = Me.DocNote.Text
                    R("Referance") = _Referance
                    R("ReferanceName") = .GetRowCellDisplayText(i, "Referance")
                    R("DocNoteByAccount") = .GetRowCellValue(i, "DocNoteByAccount")
                    R("OrderID") = i
                    JournalTable.Rows.Add(R)
                End If
            Next
        End With


        Dim _DocID As Integer = 0
        _DocID = GetDocNo(5, False)
        If _DocID = 0 Then
            XtraMessageBox.Show("لا يمكن ترحيل السند: خطا برقم السند")
            _Return = False
        End If

        Dim SqlInsertDetials, SqlInsertDetials2 As String
        Dim Sql2 As New SQLControl
        For Each row As DataRow In JournalTable.Rows
            SqlInsertDetials = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],DocCostCenter,[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID,DocID2) 
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
                                      '" & row("DocManualNo").ToString & "',
                                       N'" & row("DocNotes").ToString & "',
                                      '" & row("InputUser").ToString & "',
                                      '" & _InputDateTime & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & _DocCode & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                        " & row("OrderID").ToString & ",
                                        " & _DocID2 & "
                                            )"
            If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                MsgBox("خطا بخظ السند")
                DeleteFromJournalTemp(5, _DocCode)
                _Return = False
            End If
        Next row

        SqlInsertDetials2 = " insert into JournalTemp
                                     ( [DocID],[DocDate],[DocName],[DocStatus],DocCostCenter,[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                       [BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,
                                       CurrentUserID,DocCode,OrderID,DocID2) 
                                       Values (
                                      '" & _DocID & "', 
                                      '" & Format(Me.DateDocDate.DateTime, "yyyy-MM-dd") & "', 
                                      '" & 5 & "', 
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & 0 & "',
                                      '" & TextTempAccount.Text & "',
                                      '" & 1 & "',
                                      '" & 1 & "',
                                      '" & TextVouchersTotal.EditValue & "',
                                      '" & 1 & "',
                                      '" & TextVouchersTotal.EditValue & "',
                                      '" & TextVouchersTotal.EditValue & "',
                                      '" & TextDocManualNo.Text & "',
                                       N'" & Me.DocNote.Text & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & _InputDateTime & "',
                                      '" & GlobalVariables.CurrUser & "',
                                       '" & _DocCode & "',
                                        " & 999 & ",
                                        " & _DocID2 & "
                                            )"
        If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials2) = True And InsertFromTempToJournal(5, _DocID) = True Then
            _Return = True
        Else
            _Return = False
        End If


        DeleteFromJournalTemp(5, _DocCode)

        'If InsertFromTempToJournal(5, _DocID) = False Then
        '    XtraMessageBox.Show("خطا بعملية الحفظ")
        '    DeleteFromJournalTemp(5, _DocCode)
        '    _Return = False
        'Else
        'End If

        Return _Return
    End Function


    Private Sub TextDifferance_EditValueChanged(sender As Object, e As EventArgs) Handles TextDifferance.EditValueChanged
        If CInt(TextDifferance.EditValue) = 0 Then
            TextDifferance.BackColor = Color.Green
            TextDifferance.ForeColor = Color.White
            SimpleBtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
            SimpleBtnSave.Enabled = True
        Else
            TextDifferance.BackColor = Color.Red
            TextDifferance.ForeColor = Color.White
            SimpleBtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
            SimpleBtnSave.Enabled = False
        End If
    End Sub


    Private Sub TextVouchersTotal_EditValueChanged(sender As Object, e As EventArgs) Handles TextVouchersTotal.EditValueChanged
        CalcJournalGrid()
    End Sub
    Private Sub CalcJournalGrid()
        TextDifferance.EditValue = TextJournalTotals.EditValue - TextVouchersTotal.EditValue
    End Sub

    Private Sub TextJournalTotals_EditValueChanged(sender As Object, e As EventArgs) Handles TextJournalTotals.EditValueChanged
        CalcJournalGrid()
    End Sub
    Private Sub CheckItems()


    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
        Dim F As New SambaItemsMatching
        With F
            .SearchPosName.EditValue = Me.SearchPosName.EditValue
            .TextConnectionString.Text = Me.TextConnectionString.Text
            .ShowDialog()
            '.SearchPosName.EditValue = Me.SearchPosName.EditValue
        End With
    End Sub

    Private Sub TextWorkPeriodStatus_EditValueChanged(sender As Object, e As EventArgs) Handles TextWorkPeriodStatus.EditValueChanged
        If Me.IsHandleCreated = True Then
            If Me.TextWorkPeriodStatus.EditValue = "0" Then
                SimpleBtnSave.Enabled = False
            Else
                SimpleBtnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        PostJournal()
    End Sub

    Private Sub SearchEmployee_EditValueChanged(sender As Object, e As EventArgs)


    End Sub
    Private Sub GetTransactions()
        If Me.IsHandleCreated = False Then Exit Sub
        TextFromDate.Text = ""
        TextToDate.Text = ""
        If TextEmployeeName.Text = "" Then
            EmptyJournal()
            GridControlTickets.DataSource = ""
            GridJournal.DataSource = ""
            Me.LabelPeriodDetails.Text = ""
            GridViewMasterTickets.ViewCaption = ""
            Me.DocNote.Text = ""
            'e.LabelPeriodDetails.Text = _Text
            Me.SimpleBtnSave.Enabled = False
            Exit Sub
        End If

        Dim connString As String = TextConnectionString.Text
        Dim conn As New SqlConnection(connString)
        conn.Open()
        If SearchWorkPeriod.EditValue <> -1 Then
            Dim comm As New SqlCommand("select [id] as WorkPeriodNumber,[status] ,[open_timestamp] as StartDate ,[close_timestamp] as EndDate, [opened_by_name] as StartByName from [dbo].[shift_instance]  
                                           where [id]=" & SearchWorkPeriod.EditValue, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            'If dt.Rows.Count = 0 Then Exit Sub
            dt.Load(reader)
            Dim _Text1 As String = " تسوية الوردية رقم "
            Dim _ِTicketsAddress As String = " تفاصيل فواتير المبيعات لوردية رقم "
            Dim _Text2 As String = " للموظف "
            Dim _Text3 As String = " الفترة من "
            Dim _ShiftID As Integer = dt.Rows(0).Item("WorkPeriodNumber")
            Dim _StartByName As String = Me.TextEmployeeName.Text
            Dim _StartDate As String = Format(CDate(dt.Rows(0).Item("StartDate")), "yyyy-MM-dd HH:mm")
            Dim _EndDate As String = Format(CDate(dt.Rows(0).Item("EndDate")), "yyyy-MM-dd HH:mm")
            Dim _Status As String = dt.Rows(0).Item("status")
            Dim _Text As String = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                _Text1, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            Me.LabelPeriodDetails.Text = _Text
            GridViewMasterTickets.ViewCaption = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِTicketsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            _JournalNote = _Text
            DateDocDate.DateTime = CDate(Format(dt.Rows(0).Item("StartDate"), "yyyy-MM-dd"))
            GetTransByEmployee()
            EmptyJournal()
            TextFromDate.Text = _StartDate
            TextToDate.Text = _EndDate
            If _Status = 1 Then
                SimpleBtnSave.Enabled = False
            Else
                SimpleBtnSave.Enabled = True
            End If
        ElseIf SearchWorkPeriod.EditValue = -1 Then
            Dim comm As New SqlCommand("select [id] as WorkPeriodNumber, [open_timestamp] as StartDate ,[close_timestamp] as EndDate, [opened_by_name] as StartByName from [dbo].[shift_instance]  
                                           where [id]=" & SearchWorkPeriod.EditValue, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            'If dt.Rows.Count = 0 Then Exit Sub
            dt.Load(reader)
            Dim _Text1 As String = " تسوية الوردية رقم "
            Dim _ِTicketsAddress As String = " تفاصيل فواتير المبيعات لوردية رقم "
            Dim _Text2 As String = " للموظف "
            Dim _Text3 As String = " الفترة من "
            Dim _ShiftID As Integer = dt.Rows(0).Item("WorkPeriodNumber")
            Dim _StartByName As String = Me.TextEmployeeName.Text
            Dim _StartDate As String = ""
            Dim _EndDate As String = ""
            Dim _Text As String = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                _Text1, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            Me.LabelPeriodDetails.Text = _Text
            GridViewMasterTickets.ViewCaption = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِTicketsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            _JournalNote = _Text
            DateDocDate.DateTime = CDate(Format(dt.Rows(0).Item("StartDate"), "yyyy-MM-dd"))
            GetTransByEmployee()
            EmptyJournal()
            TextFromDate.Text = _StartDate
            TextToDate.Text = _EndDate
        End If


    End Sub
    Private Sub GetTransByEmployee()
        GridControlTickets.DataSource = ""
        Dim SqlString As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable
        TextWorkPeriodStatus.EditValue = 1
        sql.SqlTrueAccountingRunQuery(" Delete   FROM [dbo].[OrpakTransactionsTemp] 
                                        where [UserID]=" & GlobalVariables.CurrUser)

        SqlString = "SELECT  [shift_id]
                              ,[timestamp]      ,[id]
                              ,[product_code]      ,[sale]
                              ,[ppv]      ,[quantity]
                              ,[mean_name]      ,[product_name] , '" & GlobalVariables.CurrUser & "' As UserID
                               FROM [dbo].[transactions] 
                    where [shift_id]= " & SearchWorkPeriod.EditValue & " and [mean_name]='" & TextEmployeeName.Text & "' order by [timestamp]"


        Dim Con As SqlConnection
        Dim Adapter1 As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(TextConnectionString.Text)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "Tickets")
        Con.Close()
        dataSet11.AcceptChanges()
        GridControlTickets.DataSource = dataSet11.Tables("Tickets")

        ' Fill SambaOrdersTemp Table
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In dataSet11.Tables("Tickets").Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "OrpakTransactionsTemp"
            bulkCopy.WriteToServer(dataSet11.Tables("Tickets"))
        End Using
        TextVouchersTotal.EditValue = ColAmount.SummaryItem.SummaryValue

    End Sub

    Private Sub TextEmployeeName_EditValueChanged(sender As Object, e As EventArgs) Handles TextEmployeeName.EditValueChanged
        GetTransactions()
    End Sub

    Private Sub SearchWorkPeriod_QueryCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchWorkPeriod.QueryCloseUp

    End Sub

    Private Sub RepositoryEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryEdit.ButtonClick
        Dim f As New OrpakEditTrans
        With f
            .SearchPosID.EditValue = SearchPosName.EditValue
            .SearchPosName.Text = SearchPosName.Text
            ._OrpakCs = TextConnectionString.Text
            .TextTransID.EditValue = GridViewMasterTickets.GetFocusedRowCellValue("id")
            If .ShowDialog() <> DialogResult.OK Then
                GetTransactions()
            End If
        End With
    End Sub
End Class