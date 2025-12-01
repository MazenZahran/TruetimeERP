Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports TrueTime.DynamicallyConnectionString

Public Class SambaReports2
    Private _houres As DataTable
    Private _Payments As DataTable
    Private _ItemsWithCategories As New DataTable
    Public _OpenForPrint As Boolean
    Public _SambaShiftStatus As String
    Private _SendPayment As Boolean
    Private Sub SambaReports2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchPosName.Properties.DataSource = GetSambaBranches()
        'SearchWorkPeriod.ReadOnly = True
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroupTickets
        RepositoryItemBarcode.DataSource = GetItems(-1)

        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt
        Me.KeyPreview = True

        If _OpenForPrint = True Then
            SearchPosName.EditValue = 1
            Dim _MaxID As Integer = GetMaxPeriodID(_SambaShiftStatus)
            Dim sql As New SQLControl
            Dim _DateFrom As Date
            Dim _DateTo As Date


            Dim connString As String = TextConnectionString.Text
            Dim conn As New SqlConnection(connString)
            conn.Open()
            Dim comm As New SqlCommand(" select StartDate,EndDate from WorkPeriods where WorkPeriodNumber=" & _MaxID, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            dt.Load(reader)
            _DateFrom = dt.Rows(0).Item("StartDate")
            _DateTo = dt.Rows(0).Item("EndDate")

            Me.DateEditFrom.DateTime = _DateFrom
            If _SambaShiftStatus = "Opened" Then
                Me.DateEditTo.DateTime = Format("yyyy-MM-dd HH:mm:ss", Now)
                _DateTo = Format("yyyy-MM-dd HH:mm", Now)
            Else
                Me.DateEditTo.DateTime = _DateTo
            End If
            SearchWorkPeriod.EditValue = _MaxID
            GetDataFromBranch()
            PrepareReportForShare()

            Dim _ReportTitle As String = ""
            If _SambaShiftStatus = "Opened" Then
                _ReportTitle = " المبيعات " & " من " & Format(CDate(_DateFrom), "yyyy-MM-dd HH:mm") & " الى " & Format(CDate(_DateTo), "yyyy-MM-dd HH:mm")
            Else
                _ReportTitle = " تقرير المبيعات للفترة  " & " من " & Format(CDate(_DateFrom), "MM-dd HH:mm") & " الى " & Format(CDate(_DateTo), "MM-dd HH:mm")
            End If

            'SendFileToWhatsApp("0597505029", "D:\Truetime\SambaReportForOpenedShift\Debug\SambaReport.pdf", "SalesReport", _ReportTitle)
            'SendFileToWhatsApp("0569556555", "D:\Truetime\SambaReportForOpenedShift\Debug\SambaReport.pdf", "SalesReport", _ReportTitle)
            'SendFileToWhatsApp("0597505029", "SambaReport.pdf", "SalesReport", _ReportTitle)
            '  SendToWhatsApp("0599503503", "SambaReport.pdf", _ReportTitle)

            Me.Close()
        End If

    End Sub

    Private Function GetMaxPeriodID(_Status As String) As Integer
        Dim connString As String = TextConnectionString.Text
        Dim conn As New SqlConnection(connString)
        conn.Open()
        If _Status = "Closed" Then
            Dim comm As New SqlCommand(" select top(1) WorkPeriodNumber from WorkPeriods where StartDate<>EndDate order by id desc ", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            dt.Load(reader)
            Return dt.Rows(0).Item("WorkPeriodNumber")
        Else
            Dim comm As New SqlCommand(" select top(1) WorkPeriodNumber from WorkPeriods where StartDate=EndDate order by id desc ", conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            dt.Load(reader)
            Return dt.Rows(0).Item("WorkPeriodNumber")
        End If
    End Function

    Private Sub SearchPosName_EditValueChanged(sender As Object, e As EventArgs) Handles SearchPosName.EditValueChanged
        GetWorkPeriod()
    End Sub
    Private Sub GetWorkPeriod()
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
    Private Sub SearchWorkPeriod_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchWorkPeriod.BeforePopup
        If TextConnectionString.Text = "" Then
            Exit Sub
        End If
        Dim connString As String = TextConnectionString.Text
        Dim conn As New SqlConnection(connString)
        conn.Open()
        Dim comm As New SqlCommand("select * from [dbo].[WorkPeriods] ", conn)
        Dim reader As SqlDataReader = comm.ExecuteReader
        Dim dt As New DataTable
        dt.Load(reader)
        SearchWorkPeriod.Properties.DataSource = dt
    End Sub
    Private Sub GetWorkPeriodDetails()
        Try
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
            Dim _ِTicketsAddress As String = " تفاصيل فواتير المبيعات "
            Dim _ِPaymentsAddress As String = " تفاصيل الدفعات   "
            Dim _ِOrdersAddress As String = " تفاصيل مبيعات الأصناف "
            Dim _DeletedOrders As String = " تفاصيل الأصناف المحذوفة  "
            Dim _SupliersPayments As String = " تفاصيل دفعات الموردين/الموظفين  "
            Dim _Text2 As String = " "
            Dim _Text3 As String = " الفترة من "
            Dim _ShiftID As String = ""
            Dim _StartByName As String = ""
            Dim _StartDate As String = Format(CDate(dt.Rows(0).Item("StartDate")), "yyyy-MM-dd HH:mm:ss")
            Dim _EndDate As String = Format(CDate(dt.Rows(0).Item("EndDate")), "yyyy-MM-dd HH:mm:ss")
            Dim _Text As String = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                _Text1, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            ' Me.LabelPeriodDetails.Text = _Text
            GridViewMasterTickets.ViewCaption = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِTicketsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            GridViewPayments.ViewCaption = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِPaymentsAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            GridViewOrders.ViewCaption = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _ِOrdersAddress, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)

            GridViewOrdersDeleted.ViewCaption = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _DeletedOrders, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)

            GridViewSupliersPayments.ViewCaption = String.Format(" {0} {1} {2} {3} {4} {5} " & "الى" & " {6}",
                                                       _SupliersPayments, _ShiftID, _Text2, _StartByName, _Text3, _StartDate, _EndDate)
            GetTicketsMaster(Format(dt.Rows(0).Item("StartDate"), "yyyy-MM-dd HH:mm:ss.fff"),
                       Format(dt.Rows(0).Item("EndDate"), "yyyy-MM-dd HH:mm:ss.fff"))
            DateEditFrom.DateTime = _StartDate
            DateEditTo.DateTime = _EndDate
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GetTicketsMaster(StartDate As String, EndDate As String)
        GridControlTickets.DataSource = ""
        Dim SqlString As String
        Dim SqlString2 As String
        Dim SqlString3 As String
        Dim SqlString4 As String
        Dim SqlStringDeleted As String
        Dim SqlSumForGroups As String
        Dim SqlStringHours As String
        Dim SqlStringTiketVsPayment As String
        Dim SqlStringSupliersPayments As String
        Dim JouranlTable As New DataTable
        If StartDate = EndDate Then
            EndDate = Format(CDate(EndDate).AddYears(99), "yyyy-MM-dd HH:mm:ss.fff")
            TextWorkPeriodStatus.EditValue = 0
        Else
            TextWorkPeriodStatus.EditValue = 1
        End If
        SqlString = "SELECT T.[Id]      , [LastUpdateTime]      , [TicketVersion],
                            LEFT([TicketUid],50) As TicketCode     , [TicketNumber]      , [Date],
                            [LastOrderDate]      , [LastPaymentDate]      , T.[PreOrder],
                            [IsClosed]      , [IsLocked]      , [IsOpened],
                            [RemainingAmount]      , [TotalAmount]      , [TotalAmountPreTax],
                            D.Name as DepartmentName      , TR.Name As TerminalName    , TT.Name As TicketTypeName,
                            [Note]      , [LastModifiedUserName]      , [CreatedUserName],
                            [TicketTags]      , [TicketStates]      , [TicketLogs],
                            [LineSeparators]      , [ExchangeRate]      , T.[TaxIncluded],
                            T.[Name]      , [TransactionDocument_Id],sum(O.Price*O.Quantity) As OrderAmount,sum(Price*Quantity)-TotalAmount As Discount,E.EntityName as TableName
                      FROM [dbo].[Tickets] T
                            left join Departments D on T.DepartmentId=D.Id
                            left join Terminals TR on TR.Id=T.TerminalId
                            left join TicketTypes TT on TT.Id=T.TicketTypeId 
                            left Join Orders O on T.Id=o.TicketId
                            left JOIN TicketEntities E on T.Id=E.Ticket_Id and E.EntityTypeId in (2,3)
                      Where Date Between '" & StartDate & "' And '" & EndDate & "' 
                      Group by T.[Id]      , [LastUpdateTime]      , [TicketVersion],
                            LEFT([TicketUid],50), [TicketNumber]      , [Date],
                            [LastOrderDate]      , [LastPaymentDate]      , T.[PreOrder],
                            [IsClosed]      , [IsLocked]      , [IsOpened],
                            [RemainingAmount]      , [TotalAmount]      , [TotalAmountPreTax],
                            D.Name     , TR.Name    , TT.Name ,
                            [Note]      , [LastModifiedUserName]      , [CreatedUserName],
                            [TicketTags]      , [TicketStates]      , [TicketLogs],
                            [LineSeparators]      , [ExchangeRate]      , T.[TaxIncluded],
                            T.[Name]      , [TransactionDocument_Id] ,E.EntityName
                      Order by TicketNumber"




        'SqlString2 = " SELECT 
        '                  P.[Id]      ,P.TicketId
        '                  , TC.TicketNumber      , P.[Name] As AccountName
        '                  , [Description]      , P.[Date]
        '                  ,  P.[AccountTransactionId]       , (P.[Amount]-IsNull(CP.Amount,0)) as Amount,TC.TotalAmount as TicketAmount
        '                  , Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end As CurrAmount
        '                  , P.[ExchangeRate]      , [PaymentData]
        '                  , [CanAdjustTip]      ,  P.[AccountTransaction_Id]
        '                  ,  P.[AccountTransaction_AccountTransactionDocumentId]
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
        '                left join [ChangePayments] CP on CP.TicketId=P.TicketId
        '            Where TC.Date Between '" & StartDate & "' And '" & EndDate & "' 
        '            Order by TC.TicketNumber "

        SqlString2 = " SELECT 
                          P.[Id]      ,P.TicketId
                          , TC.TicketNumber      , P.[Name] As AccountName
                          , [Description]      , P.[Date]
                          ,  P.[AccountTransactionId]       , P.[Amount] as Amount
                          , Case when P.[ExchangeRate] > 0 then P.Amount/P.[ExchangeRate] else 0 end As CurrAmount
                          , P.[ExchangeRate] 
                          , Case When T.Account_Id Is Null then (select top(1) [Name] from ForeignCurrencies where ExchangeRate=1  ) else  C.Name end as Currency
                          , U.Name As Username      , D.Name As DepartmentName
                          , TR.Name As TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,tts.ttsName
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
                          , '' as  TerminalName,tts.ttsAccountNo,tts.ttsAccountType,tts.ttsRefNo,tts.ttsName
                    FROM [dbo].[ChangePayments] P
                        left join PaymentTypes T on P.ChangePaymentTypeId=T.Id
                        left join Accounts A on A.Id=T.Account_Id
                        left join AccountTypes AT on AT.Id=A.AccountTypeId
                        left join ForeignCurrencies C on C.Id=A.ForeignCurrencyId
                        left Join Users U on U.Id=P.UserId
                        left Join Departments D on D.Id=P.AccountTransaction_AccountTransactionDocumentId
                        left join Tickets TC on TC.Id=P.TicketId
                        left join AccountsMapWithTTS tts on P.[Name]=tts.SambaName
                    Where P.Date Between '" & StartDate & "' And '" & EndDate & "'"

        SqlString3 = " SELECT O.[Id]
                            , O.[TicketId] , T.TicketNumber     , O.[WarehouseId]
                            , D.Name As DepartmentName      , TR.Name as TerminalName
                            , O.[MenuItemId]      , O.[MenuItemName]
                            , O.[PortionName]      ,  O.[Price]  As Price
                            , O.[Quantity] ,  [Price]*[Quantity]  As Amount     , O.[PortionCount]
                            , O.[Locked]      , O.[CalculatePrice]
                            , O.[DecreaseInventory]      , O.[IncreaseInventory]
                            , O.[OrderNumber]      , O.[CreatingUserName]
                            , O.[CreatedDateTime]      , O.[LastUpdateDateTime]
                            , O.[AccountTransactionTypeId]      , O.[ProductTimerValueId]
                            , O.[GroupTagName]      , O.[GroupTagFormat]
                            , O.[Separator]      , O.[PriceTag]
                            , O.[Tag]      , O.[DisablePortionSelection]
                            , O.[OrderUid]      , O.[Taxes]
                            , O.[OrderTags],M.Barcode,M.GroupCode
                       FROM [dbo].[Orders] O
                                Left Join [dbo].[Tickets] T on T.id=O.TicketId
                                left join Departments D on D.Id=O.DepartmentId
                                left join Terminals TR on TR.Id=O.TerminalId
                                left join MenuItems M on M.Id=O.MenuItemId
                       Where CalculatePrice<>0 And T.Date Between '" & StartDate & "' And '" & EndDate & "' 
                       Order by T.TicketNumber"


        SqlString4 = " SELECT O.[Id],
                              O.[MenuItemId]      , O.[MenuItemName]
                            , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
                            , O.[Quantity] , Case when CalculatePrice=0 then 0 else [Price]*[Quantity] End As Amount 
                            ,M.Barcode,'" & GlobalVariables.CurrUser & "' As UserID ,case when '" & SearchWorkPeriod.EditValue & "'='' then '0' else '" & SearchWorkPeriod.EditValue & "' end As WorkPeriod,O.TicketId,T.TicketNumber
                       FROM [dbo].[Orders] O
                                Left Join [dbo].[Tickets] T on T.id=O.TicketId
                                left join MenuItems M on M.Id=O.MenuItemId
                       Where DecreaseInventory<>0 And T.Date Between '" & StartDate & "' And '" & EndDate & "' 
                       Order by T.TicketNumber"

        SqlSumForGroups = " 
                       Select sum(Quantity) as Quantity ,M.GroupCode as GroupCode,
                       sum(O.[Price]*O.[Quantity]) As Amount 
                       FROM [dbo].[Orders] O 
                       Left join MenuItems M on O.MenuItemId=M.Id
                       Left Join [dbo].[Tickets] T on T.id=O.TicketId
                       Where  T.Date Between '" & StartDate & "' And '" & EndDate & "' and  CalculatePrice<>0 
                       Group by M.GroupCode
                       order by Amount  "

        SqlStringDeleted = " SELECT O.[Id]
                            , O.[TicketId] , T.TicketNumber     , O.[WarehouseId]
                            , D.Name As DepartmentName      , TR.Name as TerminalName
                            , O.[MenuItemId]      , O.[MenuItemName]
                            , O.[PortionName]      , Case when CalculatePrice=0 then 0 else O.[Price] End As Price
                            , O.[Quantity] ,  [Price]*[Quantity] As Amount     , O.[PortionCount]
                            , O.[Locked]      , O.[CalculatePrice]
                            , O.[DecreaseInventory]      , O.[IncreaseInventory]
                            , O.[OrderNumber]      , O.[CreatingUserName]
                            , O.[CreatedDateTime]      , O.[LastUpdateDateTime]
                            , O.[AccountTransactionTypeId]      , O.[ProductTimerValueId]
                            , O.[GroupTagName]      , O.[GroupTagFormat]
                            , O.[Separator]      , O.[PriceTag]
                            , O.[Tag]      , O.[DisablePortionSelection]
                            , O.[OrderUid]      , O.[Taxes]
                            , O.[OrderTags],M.GroupCode
                       FROM [dbo].[Orders] O
                                Left Join [dbo].[Tickets] T on T.id=O.TicketId
                                left join Departments D on D.Id=O.DepartmentId
                                left join Terminals TR on TR.Id=O.TerminalId
                                left join MenuItems M on M.Id=O.MenuItemId
                       Where  T.Date Between '" & StartDate & "' And '" & EndDate & "' And (DecreaseInventory =0 and IncreaseInventory=0)
                       Order by T.TicketNumber"

        SqlStringHours = " Select
                       Sum(Case when CalculatePrice=0 then 0 else O.[Price]*O.[Quantity] End )As Amount ,DATEPART(Hour,CreatedDateTime) as HourOfDay
                       FROM [dbo].[Orders] O 
                       Left Join [dbo].[Tickets] T on T.id=O.TicketId
                       Left join MenuItems M on O.MenuItemId=M.Id
                       Where  T.Date Between '" & StartDate & "' And '" & EndDate & "'
                       Group by DATEPART(Hour,CreatedDateTime)
                       order by Amount  "

        SqlStringTiketVsPayment = " Select A.Id as TiketID, SUM(A.Amount) as TiketAmount,Sum(B.Amount) as PaymentAmount,SUM(A.Amount)-Sum(B.Amount) As Diff from 
                                        (
                                        SELECT T.[Id]      , sum(TotalAmount) Amount
                                        FROM [dbo].[Tickets] T
                                        left join Departments D on T.DepartmentId=D.Id
                                        left join Terminals TR on TR.Id=T.TerminalId
                                        left join TicketTypes TT on TT.Id=T.TicketTypeId 
                                        Where Date Between '" & StartDate & "' And '" & EndDate & "'
                                        group by T.Id
                                        ) A
                                        left join 
                                        (

                                        Select C.TicketId,Sum(C.Amount) As Amount From
                                        (
                                        SELECT P.TicketId,
                                        sum( P.[Amount] )as Amount
                                        FROM [dbo].[Payments] P
                                        left join Tickets TC on TC.Id=P.TicketId
                                        Where P.Date Between '" & StartDate & "' And '" & EndDate & "'   group by P.TicketId
                                        Union All
                                        SELECT  P.TicketId,
                                        -1* sum( P.[Amount] )as Amount
                                        FROM [dbo].[ChangePayments] P
                                        left join Tickets TC on TC.Id=P.TicketId
                                        Where P.Date Between '" & StartDate & "' And '" & EndDate & "' group by P.TicketId
                                        ) C
                                        Group By C.TicketId

                                        ) B
                                        on A.Id=B.TicketId
                                        group by A.Id
                                         "

        SqlStringSupliersPayments = " select AccountTransactionDocumentId,V.AccountTypeId,V.AccountId as sambaAccountID ,V.Date,V.Debit,V.Credit,Exchange,V.Name as Note, A.Name AS AccountName,IsNull(tts.ttsRefNo,0) as ttsRefNo,
	                                    CASE WHEN V.AccountTransactionTypeId=9 then 'Supplier' when AccountTransactionTypeId=10 then 'Employee' else 'Other' end as AccountTransactionTypeName,tts.ttsAccountNo
                                    from AccountTransactionValues V
	                                    left join Accounts A on A.Id=V.AccountId
	                                    left join AccountsMapWithTTS tts on tts.sambaAccountID=A.Id
                                    where AccountTransactionTypeId in (9,10) and V.AccountTypeId in (7,8) And V.Date Between '" & StartDate & "' And '" & EndDate & "' 
                                    order by V.Id desc "

        Dim Con As SqlConnection
        Dim Adapter1, Adapter2, Adapter3, Adapter4, AdapterDeleted, AdapterSumForGroup, AdapterHours, AdapterTiketsVsPayments, AdapterSupliersPayments As SqlDataAdapter
        Dim dataSet11 As DataSet

        Con = New SqlConnection(TextConnectionString.Text)
        Con.Open()
        Adapter1 = New SqlDataAdapter(SqlString, Con)
        Adapter2 = New SqlDataAdapter(SqlString2, Con)
        Adapter3 = New SqlDataAdapter(SqlString3, Con)
        Adapter4 = New SqlDataAdapter(SqlString4, Con)
        AdapterDeleted = New SqlDataAdapter(SqlStringDeleted, Con)
        AdapterSumForGroup = New SqlDataAdapter(SqlSumForGroups, Con)
        AdapterHours = New SqlDataAdapter(SqlStringHours, Con)
        AdapterTiketsVsPayments = New SqlDataAdapter(SqlStringTiketVsPayment, Con)
        AdapterSupliersPayments = New SqlDataAdapter(SqlStringSupliersPayments, Con)

        dataSet11 = New System.Data.DataSet()
        Adapter1.Fill(dataSet11, "Tickets")
        Adapter2.Fill(dataSet11, "Payments")
        Adapter3.Fill(dataSet11, "Orders")
        Adapter4.Fill(dataSet11, "OrdersTemp")

        AdapterDeleted.Fill(dataSet11, "DeletedOrders")
        AdapterSumForGroup.Fill(dataSet11, "SumForGroup")
        AdapterHours.Fill(dataSet11, "ByHours")
        AdapterTiketsVsPayments.Fill(dataSet11, "TiketsVsPayments")
        AdapterSupliersPayments.Fill(dataSet11, "SupliersPayments")

        Con.Close()
        dataSet11.AcceptChanges()

        Try
            Dim keyColumn As DataColumn = dataSet11.Tables("Tickets").Columns("id")
            Dim foreignKeyColumn As DataColumn = dataSet11.Tables("Payments").Columns("TicketId")
            Dim foreignKeyColumn2 As DataColumn = dataSet11.Tables("Orders").Columns("TicketId")
            dataSet11.Relations.Add("الأصناف", keyColumn, foreignKeyColumn2)
            dataSet11.Relations.Add("الدفعات", keyColumn, foreignKeyColumn)
            dataSet11.Tables("Tickets").DefaultView.Sort = "id ASC"
            'GridControlTickets.DataSource = dataSet11.Tables("Tickets")
        Catch ex As Exception
            'GridControlTickets.DataSource = dataSet11.Tables("Tickets")
        End Try

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("delete from [SambaOrdersTempForReport] 
                                       where userid=" & GlobalVariables.CurrUser)
        Using bulkCopy = New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In dataSet11.Tables("OrdersTemp").Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.DestinationTableName = "SambaOrdersTempForReport"
            bulkCopy.WriteToServer(dataSet11.Tables("OrdersTemp"))
        End Using

        Dim SqlString5 As String
        SqlString5 = " Declare @TotalSales Decimal(18,3)
                       Set @TotalSales=(select sum(Amount) from [SambaOrdersTempForReport] )
                       SELECT Sum(Amount) as Amount ,C.CategoryName,CAST((Sum(Amount)/@TotalSales) *100  AS DECIMAL(10, 2))  As Percentage   
                       FROM [dbo].[SambaOrdersTempForReport] S
                       left join Items_units IU on IU.item_unit_bar_code=S.[Barcode]
                       left join Items I on I.ItemNo=IU.item_id
                       left join ItemsCategories C on I.CategoryID=C.CategoryID group by C.CategoryName  "
        SqlString5 += " ;delete from [SambaOrdersTempForReport]  "
        sql.SqlTrueTimeRunQuery(SqlString5)
        _ItemsWithCategories = sql.SQLDS.Tables(0)

        GridControlTickets.DataSource = dataSet11.Tables("Tickets")
        GridControlTickets.ForceInitialize()
        GridControlTickets.LevelTree.Nodes.Add("الدفعات", GridView6)
        GridControlTickets.LevelTree.Nodes.Add("الأصناف", GridView7)

        GridControlPayments.DataSource = dataSet11.Tables("Payments")
        _Payments = dataSet11.Tables("Payments")
        GridControlOrders.DataSource = dataSet11.Tables("Orders")
        GridControlDeleted.DataSource = dataSet11.Tables("DeletedOrders")
        PivotGridControl1.DataSource = dataSet11.Tables("Orders")
        GridControlSumForOrders.DataSource = dataSet11.Tables("SumForGroup")
        ChartControl1.DataSource = dataSet11.Tables("SumForGroup")
        ChartControl2.DataSource = dataSet11.Tables("ByHours")
        ChartControl3.DataSource = _ItemsWithCategories
        ChartControl4.DataSource = _ItemsWithCategories
        GridTiketVsPayments.DataSource = dataSet11.Tables("TiketsVsPayments")
        GridSupliersPayments.DataSource = dataSet11.Tables("SupliersPayments")
        _houres = dataSet11.Tables("ByHours")
    End Sub

    Private Sub SearchWorkPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles SearchWorkPeriod.EditValueChanged
        GetWorkPeriodDetails()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GetDataFromBranch()
    End Sub
    Private Sub GetDataFromBranch()
        If TextConnectionString.Text = "" Then
            MsgBox("يجب اختيار نقطة البيع")
            Exit Sub
        End If
        Try
            GetWorkPeriod()
            RepositoryItemBarcode.DataSource = GetItems(-1)
            GetTicketsMaster(Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm:ss"), Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm:ss"))
            GridViewMasterTickets.ViewCaption = "قائمة فواتير المبيعات"
            GridViewPayments.ViewCaption = " قائمة الدفعات "
            GridViewOrders.ViewCaption = " قائمة الأصناف "
            GridViewOrdersDeleted.ViewCaption = " قائمة الأصناف المحذوفة "
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        GridControlTickets.ShowPrintPreview()
    End Sub
    Protected Sub TabbedGroup_CustomHeaderButtonClickn_Click(ByVal sender As System.Object,
                               ByVal e As DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs) Handles TabbedControlGroup1.CustomHeaderButtonClick
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroupTickets" Then
            GridControlTickets.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "" Then
            GridControlTickets.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup5" Then
            GridControlDeleted.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup2" Then
            GridControlPayments.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup3" Then
            GridControlOrders.ShowPrintPreview()
        End If
        If e.Button.Tag = "Print" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup1" Then
            PivotGridControl1.ShowPrintPreview()
        End If

        If e.Button.Tag = "Share" AndAlso TabbedControlGroup1.SelectedTabPageName = "LayoutControlGroup2" Then
            Dim myControl As New SendToWhatsAppNo()
            If XtraDialog.Show(myControl, "الرجاء ادخال رقم الموبايل", MessageBoxButtons.OKCancel) = System.Windows.Forms.DialogResult.OK Then
                Dim MobileNo As String = myControl.Mobile
                If String.IsNullOrEmpty(MobileNo) Then
                    Exit Sub
                End If
                PrepareReportForShare()
                Dim _ReportTitle As String = " تقرير المبيعات للفترة  " & " من " & Format(DateEditFrom.DateTime, "HH:mm dd/MM/yyyy") & " الى " & Format(DateEditTo.DateTime, "HH:mm dd/MM/yyyy")
                SendFileToWhatsApp(MobileNo, "SambaReport.pdf", _ReportTitle, "", "")
                If _SendPayment = True Then
                    SendFileToWhatsApp(MobileNo, "SambaSupliersPayments.pdf", "تقرير الدفعات", CStr(GridViewSupliersPayments.ViewCaption), "")
                    SendFileToWhatsApp(MobileNo, "ItemsSalesSummery.pdf", "تقرير مبيعات الاصناف", CStr("تقرير مبيعات الاصناف"), "")
                End If
            End If
        End If


    End Sub

    Private Sub PrepareReportForShare()
        Dim report As New SambaReportForPrint
        Dim _ReportTitle As String
        If _SambaShiftStatus = "Opened" Then
            _ReportTitle = " تقرير المبيعات للفترة  " & " من " & Format(DateEditFrom.DateTime, "HH:mm dd/MM/yyyy") & " الى " & Format(Now(), "HH:mm dd/MM/yyyy")
        Else
            _ReportTitle = " تقرير المبيعات للفترة  " & " من " & Format(DateEditFrom.DateTime, "HH:mm dd/MM/yyyy") & " الى " & Format(DateEditTo.DateTime, "HH:mm dd/MM/yyyy")
        End If

        report.XrLabelBranch.Text = Me.SearchPosName.Text
        report.XrLabelReportName.Text = _ReportTitle
        report.XrChart1.DataSource = GridControlSumForOrders.DataSource
        report.XrChart3.DataSource = _houres
        report.XrChart2.DataSource = _ItemsWithCategories
        report.XrChart4.DataSource = _ItemsWithCategories
        Dim _GetSalesSummery = GetSalesSummery()
        report.XrLabelTotalSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Total & "</b></u>" & " مجموع المبيعات: "
        report.XrLabelCashSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Cash & "</b></u>" & " نقدا: "
        report.XrLabelVISASales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Visa & "</b></u>" & " فيزا: "
        report.XrLabelCustomersSales.Text = " NIS " & "<u><b>" & _GetSalesSummery._Customers & "</b></u>" & " دين: "
        report.ExportToPdf("SambaReport.pdf")

        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='Samba_SendPaymentsReportToWhatsApp'")
        _SendPayment = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        If _SendPayment = True Then
            GridViewSupliersPayments.ExportToPdf("SambaSupliersPayments.pdf")
            PivotGridControl1.ExportToPdf("ItemsSalesSummery.pdf")
        End If

        ' report.ExportToPdf("D:\Truetime\SambaReportForOpenedShift\Debug\SambaReport.pdf")
    End Sub
    Private Function GetSalesSummery() As (_Total As Integer, _Cash As Integer, _Visa As Integer, _Customers As Integer)

        If _Payments.Rows.Count > 0 Then
            Dim Visa As Integer
            Dim Customer As Integer
            Dim Total As Integer = _Payments.Compute("Sum(Amount)", "").ToString()
            Dim Cash = Convert.ToInt32(_Payments.Compute("SUM(Amount)", "ttsAccountType = 'Cash'"))
            Try
                Visa = Convert.ToInt32(_Payments.Compute("SUM(Amount)", "ttsAccountType = 'VISA'"))
            Catch ex As Exception
                Visa = 0
            End Try

            Try
                Customer = Convert.ToInt32(_Payments.Compute("SUM(Amount)", "ttsAccountType = 'Customer'"))
            Catch ex As Exception
                Customer = 0
            End Try


            Return (Total, Cash, Visa, Customer)

        Else

            Return (0, 0, 0, 0)

        End If

    End Function

    Private Sub GridControlPayments_Click(sender As Object, e As EventArgs) Handles GridControlPayments.Click

    End Sub

    Private Sub GridViewOrders_DoubleClick(sender As Object, e As EventArgs) Handles GridViewOrders.DoubleClick
        If TextConnectionString.Text = "" Then
            Exit Sub
        End If
        Dim _ItemName As String
        If IsDBNull(GridViewOrders.GetFocusedRowCellValue("Barcode")) Then
            _ItemName = GridViewOrders.GetFocusedRowCellValue("MenuItemName")
            Dim connString As String = TextConnectionString.Text
            Dim conn As New SqlConnection(connString)
            conn.Open()
            Dim SqlString As String
            SqlString = "  declare @ItemName NVARCHAR(100)
                                          Declare @OldID INT
                                          Declare @NewId INT
                                          Set @ItemName=N'" & _ItemName & "'
                                          Set @OldID=(select top(1) MenuItemId from Orders O where [MenuItemName]=@ItemName and NOT EXISTS ( select Id from MenuItems M where M.Id=O.MenuItemId  ) )
                                          Set @NewID=(select top(1) MenuItemId from Orders O where [MenuItemName]=@ItemName and  EXISTS ( select Id from MenuItems M where M.Id=O.MenuItemId  ) )
                                          Update Orders set MenuItemId=@NewID where MenuItemId=@OldID "
            Dim comm As New SqlCommand(SqlString, conn)
            Dim reader As SqlDataReader = comm.ExecuteReader
            Dim dt As New DataTable
            dt.Load(reader)
            SearchWorkPeriod.Properties.DataSource = dt
            GetDataFromBranch()
        End If
    End Sub
End Class