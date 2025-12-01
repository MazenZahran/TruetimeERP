Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports TrueTime.DynamicallyConnectionString

Public Class SambaAdjustment
    Private _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _ValidateRow As Boolean
    Dim _JournalNote As String
    Private Sub SambaAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PosNo.Properties.DataSource = GetSambaBranches()
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
        RepositoryItemBarcode.DataSource = GetItemsFromBarcodesTable(-1)
        RepositoryAccount.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
        RepositoryReferance.DataSource = GetReferences(1, -1, -1)

    End Sub

    Protected Sub TabbedGroup_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                                   ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupTickets" Then
            GridControlTickets.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "" Then
            GridControlTickets.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupPayments" Then
            GridControlPayments.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupOrders" Then
            GridControlOrders.ShowPrintPreview()
        End If
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) _
        Handles GridViewMasterTickets.PrintInitialize, GridViewOrders.PrintInitialize
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
        If TextConnectionString.Text = "" Then
            Exit Sub
        End If
        Dim connString As String = TextConnectionString.Text
        Dim conn As New SqlConnection(connString)
        conn.Open()
        Dim comm As New SqlCommand("select * from [dbo].[WorkPeriods] where StartDescription <>N'Audited'", conn)
        Dim reader As SqlDataReader = comm.ExecuteReader
        Dim dt As New DataTable
        dt.Load(reader)
        SearchWorkPeriod.Properties.DataSource = dt
    End Sub

    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles PosNo.EditValueChanged
        GetWorkPeriod()
    End Sub
    Private Sub GetWorkPeriod()
        If Me.IsHandleCreated = True Then
            TextConnectionString.Text = ""
            If String.IsNullOrEmpty(PosNo.Text) Then
                Exit Sub
            End If
            Try
                Dim sql As New SQLControl
                Dim sqlstring As String
                sqlstring = " SELECT  ServerAddress,TempAccounting,CostCenter
                                  FROM AccountingPOSNames 
                                  Where ID=" & PosNo.EditValue
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
        'If Me.IsHandleCreated = True Then
        '    TextConnectionString.Text = ""
        '    If String.IsNullOrEmpty(SearchPosName.Text) Then
        '        Exit Sub
        '    End If
        '    Try
        '        Dim sql As New SQLControl
        '        Dim sqlstring As String
        '        sqlstring = " Update  [dbo].[WorkPeriods] Set [StartDescription]=N'Audited'  
        '                                                       Where ID=" & SearchWorkPeriod.EditValue
        '        TextConnectionString.Text = sql.SQLDS.Tables(0).Rows(0).Item("ServerAddress")
        '        If Not String.IsNullOrEmpty(TextConnectionString.Text) Then
        '            Try
        '                Dim helper As SqlHelper = New SqlHelper(TextConnectionString.Text)
        '                If helper.IsConnection Then
        '                    SearchWorkPeriod.ReadOnly = False
        '                Else
        '                    SearchWorkPeriod.ReadOnly = True
        '                End If
        '            Catch ex As Exception
        '                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '            End Try
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    End Try
        'End If


        'Dim connString As String = TextConnectionString.Text
        'Dim conn As New SqlConnection(connString)
        'conn.Open()
        'Dim comm As New SqlCommand(" Update  [dbo].[WorkPeriods] Set [StartDescription]=N'Audited'  
        ''                            Where ID=" & SearchWorkPeriod.EditValue, conn)
        'Dim reader As SqlDataReader = comm.ExecuteReader

        Dim rowsAffected As Integer
        Using con As New SqlConnection(TextConnectionString.Text)
            Using cmd As New SqlCommand("Update  [dbo].[WorkPeriods] Set [StartDescription]='Audited' Where WorkPeriodNumber=" & SearchWorkPeriod.EditValue, con)
                con.Open()
                rowsAffected = cmd.ExecuteNonQuery()
            End Using
        End Using

    End Sub

    Private Sub SearchWorkPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles SearchWorkPeriod.EditValueChanged
        GetWorkPeriodDetails()
    End Sub
    Private Sub GetWorkPeriodDetails()
        RepositoryAccount.DataSource = GetFinancialAccounts(-1, -1, False, 1, -1)
        RepositoryReferance.DataSource = GetReferences(1, -1, -1)
        GetNewAccounts()

        Try
            TextFromDate.Text = ""
            TextToDate.Text = ""
            Dim connString As String = TextConnectionString.Text
            Dim conn As New SqlConnection(connString)
            conn.Open()
            Dim comm As New SqlCommand("select WorkPeriodNumber,[StartDate],[EndDate],[StartByName] 
                                           from [dbo].[WorkPeriods] 
                                           where WorkPeriodNumber=" & SearchWorkPeriod.EditValue, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            'If dt.Rows.Count = 0 Then Exit Sub
            dt.Load(reader)
            Dim _Text1 As String = " تسوية الوردية رقم "
            Dim _ِTicketsAddress As String = " تفاصيل فواتير المبيعات لوردية رقم "
            Dim _ِPaymentsAddress As String = " تفاصيل الدفعات لوردية رقم "
            Dim _ِOrdersAddress As String = " تفاصيل مبيعات الأصناف لوردية رقم "
            Dim _Text2 As String = " للموظف "
            Dim _Text3 As String = " الفترة من "
            Dim _ShiftID As Integer = dt.Rows(0).Item("WorkPeriodNumber")
            Dim _StartByName As String = dt.Rows(0).Item("StartByName")
            Dim _StartDate As String = Format(CDate(dt.Rows(0).Item("StartDate")), "yyyy-MM-dd HH:mm")
            Dim _EndDate As String = Format(CDate(dt.Rows(0).Item("EndDate")), "yyyy-MM-dd HH:mm")
            Dim _Text As String = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                _Text1, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            Me.LabelPeriodDetails.Text = _Text
            GridViewMasterTickets.ViewCaption = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِTicketsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            GridViewPayments.ViewCaption = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِPaymentsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            GridViewOrders.ViewCaption = String.Format(" {0} ({1}) {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِOrdersAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            _JournalNote = _Text

            GetTicketsMaster(Format(dt.Rows(0).Item("StartDate"), "yyyy-MM-dd HH:mm:ss.fff"),
                       Format(dt.Rows(0).Item("EndDate"), "yyyy-MM-dd HH:mm:ss.fff"))
            DateDocDate.DateTime = CDate(Format(dt.Rows(0).Item("StartDate"), "yyyy-MM-dd"))
            TextVouchersTotal.EditValue = GridColumn8.SummaryItem.SummaryValue
            EmptyJournal()
            TextFromDate.Text = _StartDate
            TextToDate.Text = _EndDate

            CheckIfNewAccountOnSamba()
            CheckIfNewPaymentSupplierOnSamba(_StartDate, _EndDate)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private _Journal As DataTable
    Private Sub GetTicketsMaster(StartDate As String, EndDate As String)
        GridControlTickets.DataSource = ""
        Dim SqlString As String
        Dim SqlString2 As String
        Dim SqlString3 As String
        Dim SqlString4 As String
        Dim SqlString5 As String
        Dim sqlstringJournal As String
        Dim SqlStringSupliersPayments As String
        Dim sql As New SQLControl
        Dim JouranlTable As New DataTable
        If StartDate = EndDate Then
            EndDate = Format(CDate(EndDate).AddYears(99), "yyyy-MM-dd HH:mm:ss.fff")
            TextWorkPeriodStatus.EditValue = 0
        Else
            TextWorkPeriodStatus.EditValue = 1
        End If

        sql.SqlTrueAccountingRunQuery(" Delete   FROM [dbo].[SambaOrdersTemp] ;
                                        Delete   FROM [dbo].[SambaTicketsTemp]")

        SqlString = "SELECT T.[Id]      , [LastUpdateTime]      , [TicketVersion],
                            LEFT([TicketUid],50) As TicketCode     , [TicketNumber]      , [Date],
                            [LastOrderDate]      , [LastPaymentDate]      , T.[PreOrder],
                            [IsClosed]      , [IsLocked]      , [IsOpened],
                            [RemainingAmount]      , [TotalAmount]      , [TotalAmountPreTax],
                            D.Name as DepartmentName      , TR.Name As TerminalName    , TT.Name As TicketTypeName,
                            [Note]      , [LastModifiedUserName]      , [CreatedUserName],
                            [TicketTags]      , [TicketStates]      , [TicketLogs],
                            [LineSeparators]      , [ExchangeRate]      , T.[TaxIncluded],
                            T.[Name]      , [TransactionDocument_Id]
                      FROM [dbo].[Tickets] T
                            left join Departments D on T.DepartmentId=D.Id
                            left join Terminals TR on TR.Id=T.TerminalId
                            left join TicketTypes TT on TT.Id=T.TicketTypeId 
                      Where Date Between '" & StartDate & "' And '" & EndDate & "' Order by TicketNumber"


        SqlString2 = " SELECT 
                          P.[Id]      ,P.TicketId
                          , TC.TicketNumber      , P.[Name] As AccountName
                          , [Description]      , P.[Date]
                          ,  P.[AccountTransactionId]       , P.[Amount] as Amount
                          , Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end As CurrAmount
                          , P.[ExchangeRate] 
                          , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
                          , U.Name As Username      , D.Name As DepartmentName
                          , TR.Name As TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,IsNull(tts.ttsName,0) as ttsName
                    FROM [dbo].[Payments] P
                        left join PaymentTypes T on P.PaymentTypeId=T.Id
                        left join Accounts A on A.Id=T.Account_Id
                        left join AccountTypes AT on AT.Id=A.AccountTypeId
                        left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
                        left Join Users U on U.Id=P.UserId
                        left Join Departments D on D.Id=P.DepartmentId
                        left join Terminals TR on TR.Id=P.TerminalId
                        left join Tickets TC on TC.Id=P.TicketId
                        left join AccountsMapWithTTS tts on P.[Name]=tts.SambaName 
                    Where P.Date Between '" & StartDate & "' And '" & EndDate & "' 
                    Union All

					SELECT 
                          P.[Id]      ,P.TicketId
                          , TC.TicketNumber      , P.[Name] As AccountName
                          , '' as [Description]      , P.[Date]
                          ,  P.[AccountTransactionId]       , -1*P.[Amount] as Amount
                          , -1*  (Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end) As CurrAmount
                          , P.[ExchangeRate] 
                          , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
                          , U.Name As Username      , '' As DepartmentName
                          , '' as  TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,IsNull(tts.ttsName,0) as ttsName
                    FROM [dbo].[ChangePayments] P
                        left join PaymentTypes T on P.ChangePaymentTypeId=T.Id
                        left join Accounts A on A.Id=T.Account_Id
                        left join AccountTypes AT on AT.Id=A.AccountTypeId
                        left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
                        left Join Users U on U.Id=P.UserId
                        left Join Departments D on D.Id=P.AccountTransaction_AccountTransactionDocumentId
                        left join Tickets TC on TC.Id=P.TicketId
                        left join AccountsMapWithTTS tts on P.[Name]=tts.SambaName
                    Where P.Date Between '" & StartDate & "' And '" & EndDate & "' "

        sqlstringJournal = " select CONVERT(varchar(20), ttsAccountNo)   as Account,ttsCurrency as DocCurrency,Sum(CurrAmount) as DebitAmount,0.0 as CreditAmount ,
Sum(Amount)/Sum(CurrAmount) as ExchangePrice, Sum(Amount) as BaseCurrAmount ,CAST(ttsRefNo AS varchar(20)) as Referance , 
'' as DocNotes ,case when transType <> '0' then 'VISA' else '' end as DocNoteByAccount,'" & LookCostCenter.EditValue & "' as DocCostCenter, 
Case when ttsRefNo ='0' or ttsRefNo='' 
     then CAST(ttsAccountNo AS varchar(20))  
     Else CAST(ttsRefNo AS varchar(20))  
End as AccountNew,transType from (
                            SELECT 
                          P.[Id]      ,P.TicketId
                          , TC.TicketNumber      , P.[Name] As AccountName
                          , [Description]      , P.[Date]
                          ,  P.[AccountTransactionId]       , P.[Amount] as Amount
                          , Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end As CurrAmount
                          , P.[ExchangeRate] 
                          , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
                          , U.Name As Username      , D.Name As DepartmentName
                          , TR.Name As TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,IsNull(tts.ttsName,0) as ttsName,tts.Currency as ttsCurrency,Case when ttsAccountType='Visa' then P.Id else 0  end as transType
                    FROM [dbo].[Payments] P
                        left join PaymentTypes T on P.PaymentTypeId=T.Id
                        left join Accounts A on A.Id=T.Account_Id
                        left join AccountTypes AT on AT.Id=A.AccountTypeId
                        left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
                        left Join Users U on U.Id=P.UserId
                        left Join Departments D on D.Id=P.DepartmentId
                        left join Terminals TR on TR.Id=P.TerminalId
                        left join Tickets TC on TC.Id=P.TicketId
                        left join AccountsMapWithTTS tts on P.[Name]=tts.SambaName
                        Where P.Date Between '" & StartDate & "' And '" & EndDate & "' 
                    Union All

					SELECT 
                          P.[Id]      ,P.TicketId
                          , TC.TicketNumber      , P.[Name] As AccountName
                          , '' as [Description]      , P.[Date]
                          ,  P.[AccountTransactionId]       , -1*P.[Amount] as Amount
                          , -1*  (Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end) As CurrAmount
                          , P.[ExchangeRate] 
                          , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
                          , U.Name As Username      , '' As DepartmentName
                          , '' as  TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,IsNull(tts.ttsName,0) as ttsName,tts.Currency as ttsCurrency,Case when ttsAccountType='Visa' then P.Id else 0  end as transType
                    FROM [dbo].[ChangePayments] P
                        left join PaymentTypes T on P.ChangePaymentTypeId=T.Id
                        left join Accounts A on A.Id=T.Account_Id
                        left join AccountTypes AT on AT.Id=A.AccountTypeId
                        left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
                        left Join Users U on U.Id=P.UserId
                        left Join Departments D on D.Id=P.AccountTransaction_AccountTransactionDocumentId
                        left join Tickets TC on TC.Id=P.TicketId
                        left join AccountsMapWithTTS tts on P.[Name]=tts.SambaName
                        Where P.Date Between '" & StartDate & "' And '" & EndDate & "' 
                            ) A
                            group by ttsAccountNo,ttsRefNo,ttsName,ttsCurrency,transType 

            Union All
                        select tts.ttsAccountNo as Account, 1 as DocCurrency ,Exchange as BeditAmount,0 as CreditAmount,1 as ExchangePrice,Exchange as BaseCurrAmount,CAST(ISNULL(tts.ttsRefNo, 0) AS varchar(20)) as Referance,
                        '' as  DocNotes,V.Name as DocNoteByAccount,'1' as DocCostCenter , CAST(ISNULL(tts.ttsRefNo, 0) AS varchar(20)) as Referance ,0 as transType 
                        from AccountTransactionValues V
	                        left join Accounts A on A.Id=V.AccountId
	                        left join AccountsMapWithTTS tts on tts.sambaAccountID=A.Id
                        where AccountTransactionTypeId in (9,10) and V.AccountTypeId in (7,8) And V.Date Between '" & StartDate & "' And '" & EndDate & "'  

                       "

        SqlString3 = " SELECT O.[Id]
                            , O.[TicketId] , T.TicketNumber     , O.[WarehouseId]
                            , D.Name As DepartmentName      , TR.Name as TerminalName
                            , O.[MenuItemId]      , O.[MenuItemName]
                            , O.[PortionName]      , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
                            , O.[Quantity] , Case when CalculatePrice=0 then 0 else [Price]*[Quantity] End As Amount     , O.[PortionCount]
                            , O.[Locked]      , O.[CalculatePrice]
                            , O.[DecreaseInventory]      , O.[IncreaseInventory]
                            , O.[OrderNumber]      , O.[CreatingUserName]
                            , O.[CreatedDateTime]      , O.[LastUpdateDateTime]
                            , O.[AccountTransactionTypeId]      , O.[ProductTimerValueId]
                            , O.[GroupTagName]      , O.[GroupTagFormat]
                            , O.[Separator]      , O.[PriceTag]
                            , O.[Tag]      , O.[DisablePortionSelection]
                            , O.[OrderUid]      , O.[Taxes]
                            , O.[OrderTags],M.Barcode
                       FROM [dbo].[Orders] O
                                Left Join [dbo].[Tickets] T on T.id=O.TicketId
                                left join Departments D on D.Id=O.DepartmentId
                                left join Terminals TR on TR.Id=O.TerminalId
                                left join MenuItems M on M.Id=O.MenuItemId
                       Where  T.Date Between '" & StartDate & "' And '" & EndDate & "' 
                       Order by T.TicketNumber"

        SqlString4 = " SELECT O.[Id],
                              O.[MenuItemId]      , O.[MenuItemName]
                            , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
                            , O.[Quantity] , Case when CalculatePrice=0 then 0 else [Price]*[Quantity] End As Amount 
                            ,M.Barcode,'" & GlobalVariables.CurrUser & "' As UserID ,'" & SearchWorkPeriod.EditValue & "' As WorkPeriod,O.TicketId,T.TicketNumber
                       FROM [dbo].[Orders] O
                                Left Join [dbo].[Tickets] T on T.id=O.TicketId
                                left join MenuItems M on M.Id=O.MenuItemId
                       Where DecreaseInventory<>0 And T.Date Between '" & StartDate & "' And '" & EndDate & "' 
                       Order by T.TicketNumber"

        SqlString5 = "SELECT T.[Id]    ,LEFT([TicketUid],50) As TicketCode, [TicketNumber], [Date],TotalAmount,
                                       '" & GlobalVariables.CurrUser & "' As userid,'" & SearchWorkPeriod.EditValue & "' As WorkPeriod
                      From [dbo].[Tickets] T
                      Where Date Between '" & StartDate & "' And '" & EndDate & "' Order by TicketNumber"


        SqlStringSupliersPayments = " select AccountTransactionDocumentId,V.AccountTypeId,V.AccountId as sambaAccountID ,V.Date,V.Debit,V.Credit,Exchange,V.Name as Note, A.Name AS AccountName,IsNull(tts.ttsRefNo,0) as ttsRefNo,
	                                    CASE WHEN V.AccountTransactionTypeId=9 then 'Supplier' when AccountTransactionTypeId=10 then 'Employee' else 'Other' end as AccountTransactionTypeName
                                    from AccountTransactionValues V
	                                    left join Accounts A on A.Id=V.AccountId
	                                    left join AccountsMapWithTTS tts on tts.sambaAccountID=A.Id
                                    where AccountTransactionTypeId in (9,10) and V.AccountTypeId in (7,8) And V.Date Between '" & StartDate & "' And '" & EndDate & "' 
                                    order by V.Id desc "
        Dim Con As SqlConnection
        Dim Adapter1, Adapter2, Adapter3, Adapter4, Adapter5, JournalAdapter, AdapterSupliersPayments As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(TextConnectionString.Text)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        Adapter2 = New SqlDataAdapter(SqlString2, Con)
        Adapter3 = New SqlDataAdapter(SqlString3, Con)
        Adapter4 = New SqlDataAdapter(SqlString4, Con)
        Adapter5 = New SqlDataAdapter(SqlString5, Con)
        JournalAdapter = New SqlDataAdapter(sqlstringJournal, Con)
        AdapterSupliersPayments = New SqlDataAdapter(SqlStringSupliersPayments, Con)

        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "Tickets")
        Adapter2.Fill(dataSet11, "Payments")
        Adapter3.Fill(dataSet11, "Orders")
        Adapter4.Fill(dataSet11, "TempOrders")
        Adapter5.Fill(dataSet11, "TempTickets")
        JournalAdapter.Fill(dataSet11, "Journal")
        AdapterSupliersPayments.Fill(dataSet11, "SupliersPayments")
        Con.Close()
        'For x As Integer = dataSet11.Tables.Count - 1 To 0 Step -1
        '    Dim dt = dataSet11.Tables(x)
        '    dt.DefaultView.Sort = "id Asc"
        '    dataSet11.Tables.RemoveAt(x)
        '    dataSet11.Tables.Add(dt.DefaultView.ToTable)
        'Next
        dataSet11.AcceptChanges()
        Dim keyColumn As DataColumn = dataSet11.Tables("Tickets").Columns("id")
        Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Payments").Columns("TicketId")
        Dim foreignKeyColumn2 As DataColumn = dataSet11.Tables("Orders").Columns("TicketId")
        dataSet11.Relations.Add("الدفعات", keyColumn, foreignKeyColumn)
        dataSet11.Relations.Add("الأصناف", keyColumn, foreignKeyColumn2)
        dataSet11.Tables("Tickets").DefaultView.Sort = "id ASC"

        GridControlTickets.DataSource = dataSet11.Tables("Tickets")
        GridControlTickets.ForceInitialize()
        GridControlTickets.LevelTree.Nodes.Add("الدفعات", GridView6)
        GridControlTickets.LevelTree.Nodes.Add("الأصناف", GridView7)

        GridControlPayments.DataSource = dataSet11.Tables("Payments")
        GridControlOrders.DataSource = dataSet11.Tables("Orders")
        GridSupliersPayments.DataSource = dataSet11.Tables("SupliersPayments")
        _Journal = dataSet11.Tables("Journal")

        ' Fill SambaOrdersTemp Table
        ' Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("delete from [SambaOrdersTemp] 
                                       where userid=" & GlobalVariables.CurrUser)
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In dataSet11.Tables("TempOrders").Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "SambaOrdersTemp"
            bulkCopy.WriteToServer(dataSet11.Tables("TempOrders"))
        End Using

        sql.SqlTrueAccountingRunQuery("delete from [SambaTicketsTemp] 
                                       where userid=" & GlobalVariables.CurrUser)
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In dataSet11.Tables("TempTickets").Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "SambaTicketsTemp"
            bulkCopy.WriteToServer(dataSet11.Tables("TempTickets"))
        End Using

        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In dataSet11.Tables("SupliersPayments").Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "SambaSupliersPaymentsTemp"
            bulkCopy.WriteToServer(dataSet11.Tables("SupliersPayments"))
        End Using

    End Sub

    'Private Sub RepositoryItemLookUpEdit1_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.BeforePopup
    '    GetNewAccounts()
    'End Sub
    Private Sub CheckIfNewAccountOnSamba()
        Dim i As Integer
        For i = 0 To GridViewPayments.RowCount - 1
            Dim _account As String = GridViewPayments.GetRowCellValue(i, "ttsName")
            Dim _sambaAccount As String = GridViewPayments.GetRowCellValue(i, "AccountName")
            If _account = "0" Then
                MsgBoxShowError(_sambaAccount & "  غير معرفة  ")
                Dim F As New SambaUnMatchAccounts()
                With F
                    .txtConnectionString.Text = Me.TextConnectionString.Text
                    .txtSambaName.Text = _sambaAccount
                    If .ShowDialog() <> DialogResult.OK Then
                        GetWorkPeriodDetails()
                    End If
                End With
                Exit Sub
            End If
        Next
    End Sub
    Private Sub CheckIfNewPaymentSupplierOnSamba(_dateFrom As String, _dateTo As String)
        Dim i As Integer
        For i = 0 To GridViewSupliersPayments.RowCount - 1
            Dim _RefNo As String = GridViewSupliersPayments.GetRowCellValue(i, "ttsRefNo")
            Dim _sambaAccountName As String = GridViewSupliersPayments.GetRowCellValue(i, "AccountName")
            If _RefNo = "0" Then
                MsgBoxShowError(_sambaAccountName & "  الذمة غير معرفة  ")
                Dim F As New SambaUnMatchAccountsUnMatchedRef(Me.TextConnectionString.Text, _dateFrom, _dateTo)
                With F
                    If .ShowDialog() <> DialogResult.OK Then
                        GetWorkPeriodDetails()
                    End If
                End With
                Exit Sub
            End If
        Next
    End Sub
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
        'Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        'Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
        'Dim _RefNo As Object = row("RefNo")
        'Dim _AccNo As Object = row("AccNo")
        'Dim _CurrCode As Object = row("CurrCode")
        'Dim _AccType As Object = row("AccType")
        'Dim _Currency As Object = row("Currency")
        'GridViewJournal.SetFocusedRowCellValue("Account", _AccNo)
        'GridViewJournal.SetFocusedRowCellValue("AccountNew", _RefNo)
        'If _AccType = "Ref" Then
        '    GridViewJournal.SetFocusedRowCellValue("Referance", _RefNo)
        'End If
        'GridViewJournal.SetFocusedRowCellValue("AccountCurr", _Currency)
        'Dim _ExchRate = GetExchengPrice(_Currency, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        'GridViewJournal.SetFocusedRowCellValue("ExchangePrice", _ExchRate)
        'If _Currency = _DefaultCurr Then
        '    GridViewJournal.SetFocusedRowCellValue("ExchangePrice", 1)
        'End If
        'GridViewJournal.SetFocusedRowCellValue("DocCurrency", _Currency)
        'GridViewJournal.FocusedColumn = ColDebitAmount
        ''MsgBox(GridView1.DataRowCount)


        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            'Dim _RefNoObj As Object = row("RefNo")
            Dim refNoValue As String = Convert.ToString(row("RefNo"))
            Dim _AccNo As Object = row("AccNo")
            Dim _CurrCode As Object = row("CurrCode")
            Dim _AccType As Object = row("AccType")
            Dim _Currency As Object = row("Currency")
            'Dim refNoValue As Long ' Int64 for large numbers

            GridViewJournal.SetFocusedRowCellValue("AccountNew", refNoValue.ToString)
            GridViewJournal.SetFocusedRowCellValue("Account", _AccNo)

            If _AccType = "Ref" Then
                GridViewJournal.SetFocusedRowCellValue("Referance", refNoValue)
                'GridViewJournal.SetFocusedRowCellValue("AccBalance", GetReferanceBalance(_RefNo))
            Else
                GridViewJournal.SetFocusedRowCellValue("Referance", "")
                'GridViewJournal.SetFocusedRowCellValue("AccBalance", GetAccountBalance(_AccNo))
            End If
            GridViewJournal.SetFocusedRowCellValue("AccountCurr", _Currency)
            Dim _ExchRate = GetExchengPrice(_Currency, Format(DateDocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
            GridViewJournal.SetFocusedRowCellValue("ExchangePrice", _ExchRate)
            If _Currency = _DefaultCurr Then
                GridViewJournal.SetFocusedRowCellValue("ExchangePrice", 1)
            End If
            GridViewJournal.SetFocusedRowCellValue("DocCurrency", _Currency)
            GridViewJournal.FocusedColumn = ColDebitAmount
            'If IsDBNull(GridViewJournal.GetFocusedRowCellValue("DebitAmount")) And IsDBNull(GridViewJournal.GetFocusedRowCellValue("CreditAmount")) Then
            '    BalanceJournal()
            'End If
        Catch ex As Exception

        End Try


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
                TextJournalTotals.EditValue = ColBaseCurrAmount.SummaryItem.SummaryValue
            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridViewJournal.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        End If
    End Sub

    Private Sub Saving(_TicketID As Integer)
        Dim _DocCode As String
        GridViewJournal.PostEditor()
        GridViewJournal.UpdateTotalSummary()
        _DocCode = CreateRandomCode()

        ' If ColDebitAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة المدين صفر") : Exit Sub
        '  If ColCreditAmount.SummaryText = "0" Then MsgBox("خطأ: قيمة الدائن صفر") : Exit Sub

        'If CInt(ColBaseCurrAmount.SummaryText) <> 0 Then
        '    MsgBox("السند غير مطابق")
        '    Exit Sub
        'End If

        'Dim _CheckIfDocInJournal As Boolean
        '_CheckIfDocInJournal = False


        Dim _AskBeforeSave As String = "0"

        _AskBeforeSave = "هل تريد حفظ السند"

        If XtraMessageBox.Show(_AskBeforeSave, "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then


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

            With GridViewOrders ' 
                For i = 0 To .RowCount - 1
                    If .GetRowCellValue(i, "TicketId") = _TicketID Then
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
                        R("InputDateTime") = Now()
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
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID) 
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
                                      '" & Format(CDate(row("InputDateTime").ToString), "yyyy-MM-dd HH:mm") & "',
                                      '" & GlobalVariables.CurrUser & "',
                                      '" & row("Referance").ToString & "',
                                      N'" & row("ReferanceName").ToString & "',
                                       '" & _DocCode & "',
                                      N'" & row("DocNoteByAccount").ToString & "',
                                        " & row("OrderID").ToString & "
                                            )"
                If Sql2.SqlTrueAccountingRunQuery(SqlInsertDetials) = False Then
                    MsgBox("خطا بخظ السند")
                    DeleteFromJournalTemp(5, _DocCode)
                    Exit Sub
                End If
            Next row



            If InsertFromTempToJournal(5, _DocID) = False Then
                XtraMessageBox.Show("خطا بعملية الحفظ")
                DeleteFromJournalTemp(5, _DocCode)
                Exit Sub
            Else
            End If


            'CoptToClip(JournalTable)
            TextDocManualNo.EditValue = 0
            DateDocDate.Text = Format(Today, "yyyy-MM-dd")
            TextDocManualNo.Text = ""


            XtraMessageBox.Show("تم حفظ البيانات", "", MessageBoxButtons.OK)
            DeleteFromJournalTemp(5, _DocCode)
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
        GetWorkPeriodDetails()
        RepositoryItemBarcode.DataSource = GetItemsFromBarcodesTable(-1)
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
        'With GridViewJournal
        '    If .PostEditor() Then
        '        _ValidateRow = False
        '        GridViewJournal.UpdateCurrentRow()
        '        _ValidateRow = True
        '        Dim _DebitAmount As Decimal = 0
        '        Dim _CreditAmount As Decimal = 0
        '        Dim _ExchangePrice As Decimal = 0
        '        If IsDBNull(.GetFocusedRowCellValue("DebitAmount")) Then
        '            .SetFocusedRowCellValue(("DebitAmount"), 0)
        '        End If
        '        If IsDBNull(.GetFocusedRowCellValue("CreditAmount")) Then
        '            .SetFocusedRowCellValue(("CreditAmount"), 0)
        '        End If
        '        Try
        '            _DebitAmount = .GetFocusedRowCellValue("DebitAmount")
        '        Catch ex As Exception
        '            _DebitAmount = 0
        '        End Try
        '        Try
        '            _CreditAmount = .GetFocusedRowCellValue("CreditAmount")
        '        Catch ex As Exception
        '            _CreditAmount = 0
        '        End Try
        '        Try
        '            _ExchangePrice = .GetFocusedRowCellValue("ExchangePrice")
        '        Catch ex As Exception
        '            _ExchangePrice = 0
        '        End Try

        '        Select Case _FieldName
        '            Case "DebitAmount"
        '                Try
        '                    If _DebitAmount <> "0" Then
        '                        _CreditAmount = 0
        '                        .SetFocusedRowCellValue(("CreditAmount"), 0)
        '                        .SetFocusedRowCellValue(("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                        '    GridViewJournal.UpdateCurrentRow()
        '                    End If
        '                    If .GetFocusedRowCellValue("DebitAmount") = 0 And .GetFocusedRowCellValue("CreditAmount") = 0 Then
        '                        .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
        '                    End If
        '                    ' GridViewJournal.UpdateCurrentRow()
        '                Catch ex As Exception
        '                    MsgBox(ex.ToString)
        '                End Try
        '            Case "CreditAmount"
        '                Try
        '                    If _CreditAmount <> "0" Then
        '                        _DebitAmount = 0
        '                        .SetFocusedRowCellValue(("DebitAmount"), 0)
        '                        .SetFocusedRowCellValue(("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                        '  GridViewJournal.UpdateCurrentRow()
        '                    End If
        '                    If .GetFocusedRowCellValue("DebitAmount") = 0 And .GetFocusedRowCellValue("CreditAmount") = 0 Then
        '                        .SetFocusedRowCellValue(("BaseCurrAmount"), 0)
        '                    End If

        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            Case "ExchangePrice"
        '                Try
        '                    .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
        '                Catch ex As Exception
        '                    '  MsgBox(ex.ToString)
        '                End Try
        '            Case "DocCurrency"
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
        '        End Select
        '        .UpdateTotalSummary()
        '        TextJournalTotals.EditValue = ColBaseCurrAmount.SummaryItem.SummaryValue
        '        '.UpdateSummary()
        '        'GridViewJournal.UpdateCurrentRow()
        '        'GlobalVariables._TempItemNo = 0

        '        'Dim i As Integer
        '        'Dim _Sum As Decimal
        '        'For i = 0 To GridViewJournal.RowCount
        '        '    _Sum += .GetRowCellValue(i, "BaseCurrAmount")
        '        'Next
        '        'TextJournalTotals.Text = _Sum
        '    End If


        'End With


        With GridViewJournal
            If .PostEditor() Then
                Dim _DebitAmount As Decimal = 0
                Dim _CreditAmount As Decimal = 0
                Dim _ExchangePrice As Decimal = 0
                Dim _BaseCurrAmount As Decimal = 0
                _ValidateRow = False
                .UpdateCurrentRow()
                _ValidateRow = True
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
                            If .GetRowCellValue(.FocusedRowHandle, "DebitAmount") <> "0" Then
                                .SetRowCellValue(.FocusedRowHandle, .Columns("BaseCurrAmount"), _DebitAmount * _ExchangePrice - _CreditAmount * _ExchangePrice)
                            End If
                        Catch ex As Exception
                            '  MsgBox(ex.ToString)
                        End Try
                End Select

                ' GridViewJournal.UpdateCurrentRow()
                GlobalVariables._TempItemNo = 0
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
        'Dim JournalTable As New DataTable
        'With JournalTable
        '    .Columns.Add("Account", GetType(String))
        '    .Columns.Add("AccountCurr", GetType(Integer))
        '    .Columns.Add("DebitAmount", GetType(Decimal))
        '    .Columns.Add("CreditAmount", GetType(Decimal))
        '    .Columns.Add("ExchangePrice", GetType(Decimal))
        '    .Columns.Add("BaseCurrAmount", GetType(Decimal))
        '    .Columns.Add("Referance", GetType(Integer))
        '    .Columns.Add("DocNotes", GetType(String))
        '    .Columns.Add("DocNoteByAccount", GetType(String))
        '    .Columns.Add("DocCostCenter", GetType(String))
        '    .Columns.Add("AccountNew", GetType(String))
        '    .Columns.Add("DocCurrency", GetType(Decimal))
        'End With
        'Dim _CashAccount As String
        'Dim _VoucherAmount As Decimal
        '_CashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
        '_VoucherAmount = GridColumn8.SummaryItem.SummaryValue
        'TextJournalTotals.EditValue = _VoucherAmount
        'JournalTable.Rows.Add(_CashAccount, 1, _VoucherAmount, 0, 1, _VoucherAmount, 0, "", "", 1, _CashAccount, 1)
        DocNote.Text = _JournalNote
        'GridJournal.DataSource = JournalTable

        TextJournalTotals.EditValue = ColAmount.SummaryItem.SummaryValue
        GridJournal.DataSource = _Journal
        'DocCode.Text = CreateRandomCode()
    End Sub

    'get employees 


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleBtnSave.Click
        GridViewJournal.UpdateCurrentRow()
        Dim _JournalAmount As Decimal = 0
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("  SELECT DISTINCT t1.MenuItemName, t1.Barcode,t2.item_unit_bar_code,t1.MenuItemId as MenuItemId,'' as financialBarcode
                                         FROM [dbo].[SambaOrdersTemp] t1
                                         LEFT JOIN Items_units t2 ON t2.item_unit_bar_code  = t1.Barcode
                                         WHERE t2.item_unit_bar_code  IS NULL ")
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Dim F As New SambaUnMatchItems
            With F
                .GridControl1.DataSource = sql.SQLDS.Tables(0)
                .ShowDialog()
            End With
            Exit Sub
        End If
        Dim sqlCon As SqlConnection
        sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
        Using (sqlCon)
            Dim sqlComm As New SqlCommand
            sqlComm.Connection = sqlCon
            sqlComm.CommandText = "SambaAdjustment"
            sqlComm.CommandType = CommandType.StoredProcedure
            sqlComm.CommandTimeout = 1000
            sqlComm.Parameters.AddWithValue("USERID", GlobalVariables.CurrUser)
            sqlComm.Parameters.AddWithValue("PosNo", PosNo.EditValue)
            sqlComm.Parameters.AddWithValue("WorkPeriod", SearchWorkPeriod.EditValue)
            sqlComm.Parameters.AddWithValue("StartDate", TextFromDate.Text)
            sqlComm.Parameters.AddWithValue("EndDate", TextToDate.Text)
            sqlCon.Open()
            Dim returarameter = sqlComm.Parameters.Add("@TicketsAmount", SqlDbType.Decimal)
            returarameter.Direction = ParameterDirection.ReturnValue
            sqlComm.ExecuteNonQuery()
            sqlCon.Close()
            _JournalAmount = returarameter.Value / 2
        End Using

        Dim _Diff As Decimal = _JournalAmount - TextVouchersTotal.EditValue
        '     If Math.Abs(_Diff) < 1 And Math.Abs(_Diff) > -1 Then
        If PostJournal() = True Then
            MsgBoxShowSuccess("تم ترحيل البيانات بنجاح")
            ChangePeriodStatus()
            'Me.SearchWorkPeriod.EditValue = -1
            Me.Close()
        Else
            MsgBoxShowError(" يوجد خطا في ترحيل البيانات ")
        End If
        'Else
        '    XtraMessageBox.Show(" خطا بترحيل الكشف  " & " يوجد فرق ب " & _Diff)
        'End If





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
        _DocID2 = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DocID2")) + SearchWorkPeriod.EditValue + PosNo.EditValue
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
                    'R("BaseAmount") = GetBaseAmount(.GetRowCellValue(i, "AccountCurr"), (.GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount")), .GetRowCellValue(i, "DocCurrency"), Me.DateDocDate.DateTime, .GetRowCellValue(i, "ExchangePrice"))
                    R("BaseAmount") = (.GetRowCellValue(i, "DebitAmount") + .GetRowCellValue(i, "CreditAmount"))
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
                                       CurrentUserID,Referance,ReferanceName,DocCode,DocNoteByAccount,OrderID,DocID2,PosNo,ShiftID) 
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
                                        " & _DocID2 & "," & PosNo.EditValue & "," & SearchWorkPeriod.EditValue & " 
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
                                       CurrentUserID,DocCode,OrderID,DocID2,PosNo,ShiftID) 
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
                                        " & _DocID2 & "," & PosNo.EditValue & "," & SearchWorkPeriod.EditValue & "
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
        If TextDifferance.EditValue = 0 Then
            TextDifferance.BackColor = Color.Green
            TextDifferance.ForeColor = Color.White
            SimpleBtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success

        Else
            TextDifferance.BackColor = Color.Red
            TextDifferance.ForeColor = Color.White
            SimpleBtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        End If
    End Sub

    Private Sub TextConnectionString_EditValueChanged(sender As Object, e As EventArgs) Handles TextConnectionString.EditValueChanged

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

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim F As New SambaItemsMatching
        With F
            .SearchPosName.EditValue = Me.PosNo.EditValue
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

    Private Sub TabbedControlGroup2_CustomHeaderButtonClick(sender As Object, e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup2.CustomHeaderButtonClick
        If e.Button.Tag = "Refresh" Then
            GetNewAccounts()
        ElseIf e.Button.Tag = "Add" Then
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

    Private Sub GridViewJournal_Click(sender As Object, e As EventArgs) Handles GridViewJournal.Click
        Dim _a As String = GridViewJournal.GetFocusedRowCellValue("DocNoteByAccount")
        GridViewJournal.SetFocusedRowCellValue("DocNoteByAccount", _a)
    End Sub
End Class