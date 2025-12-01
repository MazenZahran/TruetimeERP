Imports DevExpress.XtraEditors

Module CodesForUse
    'Private Sub CreateRepositryForGridView()
    '    Dim col As GridColumn = TryCast(GridView1.Columns.Add, GridColumn)
    '    col.MaxWidth = 50
    '    GridView1.Columns.Add(col)
    '    col.Visible = True
    '    Dim columnEditor As New RepositoryItemButtonEdit()
    '    With columnEditor
    '        .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
    '        .Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
    '        .Buttons(0).ImageOptions.Image = My.Resources.edit_24
    '    End With
    '    AddHandler columnEditor.ButtonClick, AddressOf RepositoryItemButtonEdit_ButtonClick
    '    GridControlAccountsPercentage.RepositoryItems.Add(columnEditor)
    '    col.ColumnEdit = columnEditor
    'End Sub

    'Private Sub MsgboxWithYesNo()
    '    If XtraMessageBox.Show("Do you want to quit the application?", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
    '        'e.Cancel = True
    '    End If
    'End Sub

    'Private Sub SyncTowTablesInSqlServer()
    '    Dim sqlstring As String
    '    sqlstring = " MERGE [TrueTimeNafa].[dbo].[Referencess] AS target
    '                  USING [TrueTimeNafa3].[dbo].[Referencess] AS source
    '                  ON (target.RefNo = source.RefNo) -- Match based on ID or any key
    '                  WHEN MATCHED THEN
    '                        UPDATE SET target.RefName = source.RefName, target.RefMobile = source.RefMobile
    '                  WHEN NOT MATCHED BY TARGET THEN
    '                        INSERT ( [RefName],[RefNo]) VALUES ( source.[RefName])
    '                  WHEN NOT MATCHED BY SOURCE THEN DELETE; "
    '    'https://chat.openai.com/share/465de301-a49d-44a9-9f35-e20100071f31
    'End Sub
    'Private Sub CreteVoucherForMeatMoot()
    '    Dim sqlstring As String
    '    sqlstring = "  Declare @Date date
    '                    Declare @Quantity float
    '                    Declare @Amount as float
    '                    Declare @DocCode varchar(15)
    '                    Declare @DocNo int
    '                    Set @Date=(select DATEADD(DAY, 1, max(DocDate))   from Journal where DocName=2)
    '                    Set @Quantity=(SELECT  CASE     WHEN DATENAME(WEEKDAY, @Date) = 'Saturday' THEN       CAST((RAND() * (13 - 11) + 11) AS DECIMAL(10, 2))    ELSE       CAST((RAND() * (9 - 7) + 7) AS DECIMAL(10, 2))  END AS RandomDecimal)
    '                    Set @Amount=@Quantity*200
    '                    Set @DocCode=FLOOR(RAND()*(25-100000)+100000)
    '                    Set @DocNo=( select max(DocID)+1 from Journal  )
    '                    INSERT [dbo].[Journal] ([DocID], [DocDate], [DocName], [DocStatus], [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency], [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], [InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], [StockQuantity], [StockQuantityByMainUnit], [StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], [StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], [CurrentUserID], [ReferanceName], [DocCode], [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], [StockDiscount], [StockBarcode], [PosNo], [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], [LastDocCode], [LastDataName], [DeliverDate], [Color], [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], [DocID2], [DocDueDate], [VoucherCounter], [AuditNote], [TarteebID], [PaidStatus], [PaidAmount], [PaidByDocID], [LastPurchasePrice], [BatchID], [BatchNo]) VALUES ( @DocNo, @Date, 2, 1, 0, N'0', N'3000000000', 1, 1, @Amount, 1, @Amount, @Amount, 0, N'0', N'', 0, 1, FORMAT (getdate(), 'yyyy-MM-dd HH:mm'), NULL, NULL, NULL, NULL, N'', 1, 1, @Quantity, @Quantity, 200, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, N'مبيعات نقدية', @DocCode, NULL, N'وجبات لحمة ', NULL, NULL, NULL, NULL, 0, N'1', NULL, @DocCode, NULL, NULL, NULL, N'', N'', NULL, 0, 0, 0, 0, NULL, NULL, N'', 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'')
    '                    INSERT [dbo].[Journal] ([DocID], [DocDate], [DocName], [DocStatus], [DocCostCenter], [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency], [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount], [DocSort], [Referance], [DocManualNo], [DocMultiCurrency], [InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime], [DocAuditDate], [DocAuditUser], [DocNotes], [StockID], [StockUnit], [StockQuantity], [StockQuantityByMainUnit], [StockPrice], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse], [StockDriver], [StockCarNo], [SalesPerson], [CheckNo], [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank], [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser], [DeleteDateTime], [CurrentUserID], [ReferanceName], [DocCode], [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal], [ShiftID], [DocNoteByAccount], [StockDiscount], [StockBarcode], [PosNo], [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity], [LastDocCode], [LastDataName], [DeliverDate], [Color], [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [ItemNo2], [OrderID], [Produced], [DocID2], [DocDueDate], [VoucherCounter], [AuditNote], [TarteebID], [PaidStatus], [PaidAmount], [PaidByDocID], [LastPurchasePrice], [BatchID], [BatchNo]) VALUES ( @DocNo, @Date, 2, 1, 1, N'1101010000', N'0', 1, 1, @Amount, 1, @Amount, @Amount, 0, N'0', N'', 0, 1, FORMAT (getdate(), 'yyyy-MM-dd HH:mm'), NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, N'مبيعات نقدية', @DocCode, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, @DocCode, NULL, NULL, NULL, N'', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'')
    '                    GO "
    'End Sub
    '    Private Sub UpdateWithJoin()
    '        Dim SqlString As String
    '        SqlString = " update A
    'set A.PaymentType=T.ID
    'from [dbo].[AttEmployeePayments] A
    'inner join [dbo].[AttPaymentsTypes] T on A.PaymentType  =T.PaymentType

    'update A
    'set A.AdditionType=T.ID
    'from [dbo].[AttEmployeeAdditions] A
    'inner join [dbo].[AttAdditionsTypes] T on A.AdditionType  =T.AdditionsType "
    '    End Sub
End Module
