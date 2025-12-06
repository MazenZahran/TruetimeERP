Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.Data
Imports DevExpress.Mvvm
Imports DevExpress.Utils
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraLayout
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Graph


Public Class AccStockMove
    Dim _DefaultCurr As Integer = GetDefaultCurrency()
    Dim _RefPrice As Integer
    Dim _StockBarCode As String
    Dim _AllowCostCenter As Boolean = False
    Dim _ApproveDocToVoucher As Boolean
    Dim _CheckIfPriceLessThanCost As Boolean
    Public _PosNo As Integer
    Public _ShiftID As Integer
    Public _DocID2 As Integer
    Private _RefMaxDebit As Decimal
    Private ShowInActiveItems As Boolean
    Private Accounting_AllowSortItemsInVouchers As Boolean
    Public _DocTagsToOpen As String
    Public _TempPercentage As Decimal = 0D
    Public askBeforeClose As Boolean = True
    Dim EventForWhatsMsg As String = ""
    Public Sub CreateTempTable()
        Dim PlaneTable As New DataTable

        Dim JournalTable As New DataTable
        Dim DD As New DataColumn With {
            .AllowDBNull = False,
            .Unique = True
        }
        With JournalTable
            .Columns.Add("DocID", GetType(Integer))
            .Columns.Add("DocCostCenter", GetType(Integer))
            .Columns.Add("DocAmount", GetType(Decimal))
            .Columns.Add("DocManualNo", GetType(String))
            .Columns.Add("StockID", GetType(String))
            .Columns.Add("ItemName", GetType(String))
            .Columns.Add("StockUnit", GetType(Integer))
            .Columns.Add("StockQuantity", GetType(Decimal))
            .Columns.Add("BonusQuantity", GetType(Decimal))
            .Columns.Add("StockQuantityByMainUnit", GetType(Decimal))
            .Columns.Add("BonusQuantityByMainUnit", GetType(Decimal))
            .Columns.Add("StockPrice", GetType(Decimal))
            .Columns.Add("StockDiscount", GetType(Decimal))
            .Columns.Add("StockBarcode", GetType(String))
            .Columns.Add("Color", GetType(Integer))
            .Columns.Add("Measure", GetType(Integer))
            .Columns.Add("StockQuantityPerMainUnit", GetType(Decimal))
            .Columns.Add("VoucherDiscount", GetType(Decimal))

            .Columns.Add("StockDebitShelve", GetType(Integer))
            .Columns.Add("StockCreditShelve", GetType(Integer))
            .Columns.Add("DocNoteByAccount", GetType(String))
            .Columns.Add("ItemNo2", GetType(String))
            .Columns.Add("Produced", GetType(Boolean))
            .Columns.Add("Balance", GetType(Decimal))
            .Columns.Add("LastPurchasePrice", GetType(Decimal))
            .Columns.Add("BatchID", GetType(Integer))
            .Columns.Add("BatchNo", GetType(String))

            .Columns.Add("StockWidth", GetType(Decimal))
            .Columns.Add("StockLength", GetType(Decimal))
            .Columns.Add("StockCount", GetType(Decimal))
            .Columns.Add("StockThickness", GetType(Decimal))
            .Columns.Add("StockDivision", GetType(Decimal))

            .Columns.Add("ItemVAT", GetType(Decimal))
            .Columns.Add("ItemVATPercentage", GetType(Decimal))


        End With

        JournalGridControl.DataSource = JournalTable

    End Sub
    Private Sub AccStockMove_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Hint: Register row-updated event for saving edits dynamically
        AddHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated

        ' Hint: Default visibility for inactive items
        ShowInActiveItems = False

        ' Hint: Build multi-result SQL batch to preload all lookup tables
        Dim sql As New SQLControl
        Dim SQlString As String

        ' Hint: Load Items base list (ItemNo, Names, Status)
        SQlString = "
        Select ItemNo ,ItemName,ItemNo2,[ItemStatus],[ItemNo3],[ItemNo4] from Items  "

        ' Hint: Hide raw-material (classification=3) for specific document types
        If GlobalVariables._ShowRowMaterialinVouchers = False _
        And (Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 2) Then

            SQlString += " where classification<>3 "
        End If

        ' Hint: Append all additional lookups (Currencies, Units, References, Warehouses, Accounts, Settings...)
        SQlString += " Order by ItemNo ; "
        SQlString += "
        Select Code,CurrID from Currency;
        Select id,name from Units;
        Select RefName,RefNo as RefNo ,RefTypeName,RefMobile,T.TypeID, RefAccID ,'1' as Currency
            From Referencess R left join ReferencesTypes T on T.TypeID=R.RefType ;
        SELECT [WarehouseID],[WarehouseNameAR],[WarehouseNameEn] FROM [Warehouses];
        Select CAST([AccNo] AS float) as AccNo, [AccID],[AccName]
            From [FinancialAccounts] where  IsMain =0;
        Select [ID],[OrderStatus],[OrderStatusE] from [dbo].[OrdersStatus];
        Select ID,DocStatus from [dbo].[DocStatus] where ID<>-1;
        Select [ID],[ColorName] from [dbo].[ItemsColors];
        Select [ID],   [MeasureName] from [dbo].[ItemsMeasures];
        Select SortID,SortName from DocSorts S left join DocNames N on S.DocID=N.id where N.id=" & Me.DocName.EditValue & ";
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters';
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]='VATInternal';
        Select [ShelfID],[ShelfCode] From [dbo].[FinancialShelves] ;
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowBarcodeColumnInVoucher';
        select EmployeeID,EmployeeName from EmployeesData;
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowDiscountColumnInVoucher';
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowRefMobileInDocuments';
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'ShowBarVoucherStatusInDocuments'; 
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowColumnBonusInVouchers'; 
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowWidthLengthCountColumnsInVouchers'; 
        Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowTaxDateOnVouchers'; "

        ' Hint: Execute batch SQL — dataset will contain multiple tables
        sql.SqlTrueAccountingRunQuery(SQlString)

        ' Hint: Bind lookup tables to repository editors and lookup editors
        RepositoryItem.DataSource = sql.SQLDS.Tables(0)
        DocCurrency.Properties.DataSource = sql.SQLDS.Tables(1)
        AccCurrency.Properties.DataSource = sql.SQLDS.Tables(1)
        RepositoryUnit.DataSource = sql.SQLDS.Tables(2)
        Referance.Properties.DataSource = sql.SQLDS.Tables(3)
        StockDebitWhereHouse.Properties.DataSource = sql.SQLDS.Tables(4)
        StockCreditWhereHouse.Properties.DataSource = sql.SQLDS.Tables(4)
        AccountForRefranace.Properties.DataSource = sql.SQLDS.Tables(5)

        ' Hint: Select default tab
        Me.tabb.SelectedTabPage = LayoutControlGroup1

        ' Hint: 4-decimal price formatting for stock prices
        ColStockPrice.DisplayFormat.FormatString = "{0:n4}"

        ' Hint: Bind order status, doc status
        SearchOrderStatus.Properties.DataSource = sql.SQLDS.Tables(6)
        DocStatus.Properties.DataSource = sql.SQLDS.Tables(7)

        ' Hint: Enable keyboard preview for form-level key events
        Me.KeyPreview = True

        ' Hint: Bind colors and measures lookup lists
        Me.RepositoryItemColor.DataSource = sql.SQLDS.Tables(8)
        Me.RepositoryMeasure.DataSource = sql.SQLDS.Tables(9)

        ' Hint: Bind sorting types for this document ID
        DocSort.Properties.DataSource = sql.SQLDS.Tables(10)

        ' Hint: Load shelves lookup
        RepositoryShelves.DataSource = sql.SQLDS.Tables(13)

        ' Hint: Show/hide barcode column per system setting
        GridColStockBarcode.Visible = CBool(sql.SQLDS.Tables(14).Rows(0)("SettingValue"))

        ' Hint: Load employee list for salesperson selection
        SalesPerson.Properties.DataSource = sql.SQLDS.Tables(15)

        ' Hint: Toggle discount column visibility
        ColStockDiscount.Visible = CBool(sql.SQLDS.Tables(16).Rows(0)("SettingValue"))

        ' Hint: Load Cost Center system setting (table 11)
        Try
            Dim _Result As Boolean = CBool(sql.SQLDS.Tables(11).Rows(0)("SettingValue"))
            If _Result = True Then
                ' Hint: Enable cost center controls and bind lookup source
                Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Always
                Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
                Me.RepositoryDocCostCenter2.DataSource = GetCostCenter(False)
                colDocCostCenter.Visible = True
            Else
                ' Hint: Hide cost center controls
                Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Never
                colDocCostCenter.Visible = False
            End If
        Catch ex As Exception
            colDocCostCenter.Visible = False
        End Try

        ' Hint: Toggle reference mobile field visibility
        ColRefMobile.Visible = CBool(sql.SQLDS.Tables(17).Rows(0)("SettingValue"))

        ' Hint: Optional bar status visibility
        Try
            BarVoucherStatus.Visible = CBool(sql.SQLDS.Tables(18).Rows(0)("SettingValue"))
        Catch
        End Try

        ' Hint: Show Bonus column only for sales/purchase vouchers
        If Not IsNothing(Me.DocName.EditValue) AndAlso
        (Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 2 _
        Or Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 13 _
        Or Me.DocName.EditValue = 11) Then

            Try
                ColBonus.Visible = CBool(sql.SQLDS.Tables(19).Rows(0)("SettingValue"))
            Catch
                ColBonus.Visible = False
            End Try
        Else
            ColBonus.Visible = False
        End If

        ' Hint: Load global & form-level settings
        LoadSettings()

        ' Hint: Disable journal entry if license expired
        If GlobalVariables._EndDate < Today Then
            Me.JournalGridControl.Enabled = False
        End If

        ' Hint: Increase row indicator width for better visibility
        Me.GridView1.IndicatorWidth = 40

        ' Hint: Special UI rules for document type 2 (Sales)
        If Not IsNothing(Me.DocName.EditValue) AndAlso Me.DocName.EditValue = 2 Then
            Try : BarFinancialClaim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always : Catch : End Try
            Try : GridView1.FormatRules(0).Enabled = True : Catch : End Try
            Try : BarButtonItemVoucherProfit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always : Catch : End Try
        End If

        ' Hint: Hide reference info for specific document type 16
        If Not IsNothing(Me.DocName.EditValue) AndAlso Me.DocName.EditValue = 16 Then
            LayoutControlItemRefNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItemRefBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutControlItemRefName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        ' Hint: Toggle balance column visibility
        ColBalance.Visible = GlobalVariables._ShowBalanceColumnInVoucher

        If GlobalVariables._ShowBalanceColumnInVoucher = True Then
            Try : BarShowColBalance.Caption = " اخفاء عمود الرصيد " : Catch : End Try
        End If

        ' Hint: Toggle visibility of last purchase price
        If GlobalVariables._ShowLastPurchasePriceColumnInVoucher = True Then
            Try
                ColLastPurchasePrice.Visible = True
                BarShowLastPurchasePrice.Caption = " اخفاء عمود اخر سعر شراء "
            Catch
            End Try
        Else
            Try : ColLastPurchasePrice.VisibleIndex = -1 : Catch : End Try
        End If

        ' Hint: Toggle Width/Length/Count/Thickness/Division columns
        If CBool(sql.SQLDS.Tables(20).Rows(0)(0)) = True Then
            ColWidth.Visible = True
            ColLength.Visible = True
            ColCount.Visible = True
            ColThickness.Visible = True
            ColDivision.Visible = True
        Else
            ColWidth.Visible = False
            ColLength.Visible = False
            ColCount.Visible = False
            ColThickness.Visible = False
            ColDivision.Visible = False
        End If

        ' Hint: Show tax date field if setting enabled
        If CBool(sql.SQLDS.Tables(21).Rows(0)("SettingValue")) = True Then
            Me.LayoutControlTaxDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlDocDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
        End If

        ' Hint: VAT visibility logic
        ColItemVAT.Visible = GlobalVariables.UseVAT
        ColItemVATPercentage.Visible = GlobalVariables.UseVAT
        TextVoucherDiscount.ReadOnly = GlobalVariables.UseVAT

        ' Hint: Batch lookup binding if batch feature enabled
        If GlobalVariables._UseBatch = True Then
            Me.RepositoryItemLookUpBatchID.DataSource = GetAllBatchesNumbersForItems()
        End If

        ' Hint: Disable item sorting (feature control)
        Accounting_AllowSortItemsInVouchers = False

    End Sub

    'Private Sub AccStockMove_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    AddHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated
    '    ShowInActiveItems = False
    '    Dim sql As New SQLControl
    '    Dim SQlString As String
    '    SQlString = "
    '    Select ItemNo ,ItemName,ItemNo2,[ItemStatus],[ItemNo3],[ItemNo4] from Items  "
    '    If GlobalVariables._ShowRowMaterialinVouchers = False And (Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 2) Then
    '        SQlString += " where classification<>3 "
    '    End If
    '    SQlString += " Order by ItemNo ; "
    '    SQlString += "   Select  Code,CurrID from Currency;
    '    Select id,name from Units;
    '    Select RefName,RefNo as RefNo ,RefTypeName,RefMobile,T.TypeID, RefAccID ,'1' as Currency
    '        From Referencess R left join ReferencesTypes T on T.TypeID=R.RefType ;
    '    SELECT [WarehouseID],[WarehouseNameAR],[WarehouseNameEn] FROM [Warehouses];
    '    Select CAST([AccNo] AS float) as AccNo, [AccID],[AccName]
    '        From [FinancialAccounts] where  IsMain =0;
    '    Select [ID],[OrderStatus],[OrderStatusE] from [dbo].[OrdersStatus];
    '    Select ID,DocStatus from [dbo].[DocStatus] where ID<>-1;
    '    Select [ID],[ColorName] from [dbo].[ItemsColors];
    '    Select [ID],   [MeasureName] from [dbo].[ItemsMeasures];
    '    Select SortID,SortName from DocSorts S left join DocNames N on S.DocID=N.id where N.id=" & Me.DocName.EditValue & ";
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters';
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]='VATInternal';
    '    Select [ShelfID],[ShelfCode] From [dbo].[FinancialShelves] ;
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowBarcodeColumnInVoucher';
    '    select EmployeeID,EmployeeName from EmployeesData;
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowDiscountColumnInVoucher';
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]='ShowRefMobileInDocuments';
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'ShowBarVoucherStatusInDocuments'; 
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowColumnBonusInVouchers'; 
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowWidthLengthCountColumnsInVouchers'; 
    '    Select [SettingValue] From [dbo].[Settings] Where [SettingName]= 'Accounting_ShowTaxDateOnVouchers'; "
    '    sql.SqlTrueAccountingRunQuery(SQlString)
    '    RepositoryItem.DataSource = sql.SQLDS.Tables(0)
    '    DocCurrency.Properties.DataSource = sql.SQLDS.Tables(1)
    '    AccCurrency.Properties.DataSource = sql.SQLDS.Tables(1)
    '    RepositoryUnit.DataSource = sql.SQLDS.Tables(2)
    '    Referance.Properties.DataSource = sql.SQLDS.Tables(3)
    '    StockDebitWhereHouse.Properties.DataSource = sql.SQLDS.Tables(4)
    '    StockCreditWhereHouse.Properties.DataSource = sql.SQLDS.Tables(4)
    '    AccountForRefranace.Properties.DataSource = sql.SQLDS.Tables(5)
    '    Me.tabb.SelectedTabPage = LayoutControlGroup1
    '    ColStockPrice.DisplayFormat.FormatString = "{0:n4}"
    '    SearchOrderStatus.Properties.DataSource = sql.SQLDS.Tables(6)
    '    DocStatus.Properties.DataSource = sql.SQLDS.Tables(7)
    '    Me.KeyPreview = True
    '    Me.RepositoryItemColor.DataSource = sql.SQLDS.Tables(8)
    '    Me.RepositoryMeasure.DataSource = sql.SQLDS.Tables(9)
    '    DocSort.Properties.DataSource = sql.SQLDS.Tables(10)
    '    RepositoryShelves.DataSource = sql.SQLDS.Tables(13)
    '    GridColStockBarcode.Visible = CBool(sql.SQLDS.Tables(14).Rows(0).Item("SettingValue"))
    '    SalesPerson.Properties.DataSource = sql.SQLDS.Tables(15)
    '    ColStockDiscount.Visible = CBool(sql.SQLDS.Tables(16).Rows(0).Item("SettingValue"))
    '    Try
    '        Dim _Result As Boolean
    '        _Result = CBool(sql.SQLDS.Tables(11).Rows(0).Item("SettingValue"))
    '        If _Result = True Then
    '            Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Always
    '            Me.LookCostCenter.Properties.DataSource = GetCostCenter(False)
    '            Me.RepositoryDocCostCenter2.DataSource = GetCostCenter(False)
    '            colDocCostCenter.Visible = _Result
    '        Else
    '            Me.LayoutCostCenter.Visibility = Utils.LayoutVisibility.Never
    '            colDocCostCenter.Visible = False
    '        End If
    '    Catch ex As Exception
    '        colDocCostCenter.Visible = False
    '    End Try
    '    ColRefMobile.Visible = CBool(sql.SQLDS.Tables(17).Rows(0).Item("SettingValue"))
    '    Try
    '        BarVoucherStatus.Visible = CBool(sql.SQLDS.Tables(18).Rows(0).Item("SettingValue"))
    '    Catch ex As Exception
    '        ' BarVoucherStatus might not be initialized yet
    '    End Try
    '    If Not IsNothing(Me.DocName.EditValue) AndAlso (Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 2 Or Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 13 Or Me.DocName.EditValue = 11) Then
    '        Try
    '            ColBonus.Visible = CBool(sql.SQLDS.Tables(19).Rows(0).Item("SettingValue"))
    '        Catch ex As Exception
    '            ColBonus.Visible = False
    '        End Try
    '    Else
    '        ColBonus.Visible = False
    '    End If


    '    LoadSettings()
    '    If GlobalVariables._EndDate < Today Then
    '        Me.JournalGridControl.Enabled = False
    '    End If
    '    Me.GridView1.IndicatorWidth = 40
    '    '  LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '    If Not IsNothing(Me.DocName.EditValue) AndAlso Me.DocName.EditValue = 2 Then
    '        Try
    '            BarFinancialClaim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    '        Catch ex As Exception
    '            ' BarFinancialClaim might not be initialized yet
    '        End Try
    '        Try
    '            GridView1.FormatRules(0).Enabled = True
    '        Catch ex As Exception
    '            ' GridView1.FormatRules might not be initialized yet
    '        End Try
    '        Try
    '            BarButtonItemVoucherProfit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    '        Catch ex As Exception
    '            ' BarButtonItemVoucherProfit might not be initialized yet
    '        End Try
    '    End If
    '    If Not IsNothing(Me.DocName.EditValue) AndAlso Me.DocName.EditValue = 16 Then
    '        LayoutControlItemRefNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '        LayoutControlItemRefBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '        LayoutControlItemRefName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '        LayoutCostCenter.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    '    End If


    '    ColBalance.Visible = GlobalVariables._ShowBalanceColumnInVoucher
    '    If GlobalVariables._ShowBalanceColumnInVoucher = True Then
    '        Try
    '            BarShowColBalance.Caption = " اخفاء عمود الرصيد "
    '        Catch ex As Exception
    '            ' BarShowColBalance might not be initialized yet
    '        End Try
    '    End If

    '    'ColLastPurchasePrice.Visible = GlobalVariables._ShowLastPurchasePriceColumnInVoucher
    '    If GlobalVariables._ShowLastPurchasePriceColumnInVoucher = True Then
    '        '  ColLastPurchasePrice.VisibleIndex = ColStockPrice.VisibleIndex - 1
    '        Try
    '            ColLastPurchasePrice.Visible = True
    '            BarShowLastPurchasePrice.Caption = " اخفاء عمود اخر سعر شراء "
    '        Catch ex As Exception
    '            ' BarShowLastPurchasePrice might not be initialized yet
    '        End Try
    '    Else
    '        Try
    '            ColLastPurchasePrice.VisibleIndex = -1
    '        Catch ex As Exception
    '            ' ColLastPurchasePrice might not be initialized yet
    '        End Try
    '    End If


    '    If CBool(sql.SQLDS.Tables(20).Rows(0).Item(0)) = True Then
    '        ColWidth.Visible = True
    '        ColLength.Visible = True
    '        ColCount.Visible = True
    '        ColThickness.Visible = True
    '        ColDivision.Visible = True
    '    Else
    '        ColWidth.Visible = False
    '        ColLength.Visible = False
    '        ColCount.Visible = False
    '        ColThickness.Visible = False
    '        ColDivision.Visible = False
    '    End If

    '    If CBool(sql.SQLDS.Tables(21).Rows(0).Item("SettingValue")) = True Then
    '        Me.LayoutControlTaxDate.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    '        LayoutControlDocDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize
    '    End If


    '    ColItemVAT.Visible = GlobalVariables.UseVAT
    '    ColItemVATPercentage.Visible = GlobalVariables.UseVAT
    '    TextVoucherDiscount.ReadOnly = GlobalVariables.UseVAT


    '    If GlobalVariables._UseBatch = True Then
    '        Me.RepositoryItemLookUpBatchID.DataSource = GetAllBatchesNumbersForItems()
    '    End If

    '    Accounting_AllowSortItemsInVouchers = False

    'End Sub
    Private Sub LoadSettings()
        colDocNoteByAccount.Visible = GlobalVariables._ShowColNoteInStockMoveDoc
        ColItemNo2.Visible = GlobalVariables._ShowItemNo2
        ColItemNo3.Visible = GlobalVariables._ShowItemNo2
        ColItemNo4.Visible = GlobalVariables._ShowItemNo2
        GridControlItemNo2.Visible = GlobalVariables._ShowItemNo2


        If GlobalVariables._ShowShelvesColumnInVoucher = True Then
            Select Case DocName.EditValue
                Case 1, 8, 12, 14, 17
                    ColStockCreditShelve.VisibleIndex = -1
                Case 2, 9, 13, 15, 18
                    ColStockDebitShelve.VisibleIndex = -1
            End Select
        Else
            ColStockCreditShelve.VisibleIndex = -1
            ColStockDebitShelve.VisibleIndex = -1
        End If

        If GlobalVariables._UseSalesMan = False Then
            LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        If GlobalVariables._UseSerials = False Then
            BarButtonShowSerials.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If GlobalVariables._UseColorsAndMeasuresInItems = False Then
            ColColor.Visible = False
            ColMeasure.Visible = False
        End If
        ColBatchNo.Visible = GlobalVariables._UseBatch

        If GlobalVariables._UserAccessType = 95 Then
            BarButtonItemVoucherProfit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If


    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveDocument("Nothing")
        ElseIf e.KeyCode = Keys.End Then
            e.Handled = True
            DocNotes.Focus()
        ElseIf e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.Delete Then
            If GlobalVariables._UseSerials = True Then
                Dim _Count As Integer
                Dim sql As New SQLControl
                Try
                    sql.SqlTrueAccountingRunQuery("Select Count(TransID) as Count FROM [dbo].[ItemsSerialTransTemp] 
                                           Where DocCode='" & Me.DocCode.Text & "'")
                    _Count = sql.SQLDS.Tables(0).Rows(0).Item("Count")
                Catch ex As Exception
                    _Count = 0
                End Try
                If _Count > 0 Then
                    XtraMessageBox.Show("لا يمكن حذف السند بسبب وجود سيريال مرتبط بالاصناف، الرجاء حذف الاصناف بشكل منفرد ")
                    Exit Sub
                End If
            End If
            If DeleteDoc(DocName.EditValue, DocID.EditValue, Me.DocCode.Text, False) = True Then
                Me.Dispose()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            ' ShowPrint()
        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SaveDocument("Nothing")
    End Sub

    Private Class DocumentContext
        Public Property WithAction As String
        Public Property DocStatus As Integer
        Public Property DocCode As String
        Public Property DocID As Integer
        Public Property DocIDForLog As Integer
        Public Property DocNameID As Integer
        Public Property Referance As Integer
        Public Property InputUser As Integer
        Public Property DeviceName As String
        Public Property InputDateTime As String
        Public Property ModifiedDateTime As String
        Public Property LogDateTime As String
        Public Property DocLogName As String
        Public Property LogDetails As String
        Public Property AskBeforeSave As String
        Public Property PaidAmount As Decimal
        Public Property PaidStatus As Integer
        Public Property PaidByDocID As Integer
        Public Property PosNo As Integer
        Public Property ShiftID As Integer
        Public Property DocID2 As Integer
        Public Property DocTags As String
        Public Property HasAttachment As Boolean
        Public Property DocDataTableName As String    ' "dbo.Journal" أو "dbo.OrdersJournal"
        Public Property JournalTable As DataTable
        Public Property TaxDate As Date
        Public Property OrderStatus As Integer
    End Class

    Private Function PrepareDocumentContext(_WithAction As String) As DocumentContext

        If Not ValidateBeforeSave() Then
            Return Nothing
        End If

        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            MsgBox(ex.ToString())
            Return Nothing
        End Try

        AllocateDiscount()
        CalcBaseAmount()

        Dim nowValue As DateTime = Now()
        Dim ctx As New DocumentContext()

        ctx.WithAction = _WithAction
        ctx.LogDateTime = nowValue.ToString("yyyy-MM-dd HH:mm:ss")
        ctx.ModifiedDateTime = nowValue.ToString("yyyy-MM-dd HH:mm:ss")
        ctx.DocTags = _DocTagsToOpen
        ctx.DocNameID = CInt(Me.DocName.EditValue)
        ctx.JournalTable = CreateJournalTableSchema()

        ' Referance
        Dim refInt As Integer = 0
        If Not String.IsNullOrWhiteSpace(Referance.Text) Then
            Integer.TryParse(Referance.Text, refInt)
        End If
        ctx.Referance = refInt

        ' قراءة قيم الدفع من الـ Bar
        Dim paidAmountValue As Decimal = 0D
        Decimal.TryParse(Me.BarPaidSAmount.Caption, paidAmountValue)
        ctx.PaidAmount = paidAmountValue

        Dim paidStatusValue As Integer = 0
        Integer.TryParse(Me.BarPaidStatus.Caption, paidStatusValue)
        ctx.PaidStatus = paidStatusValue

        Dim paidByDocIdValue As Integer = 0
        Integer.TryParse(Me.BarPaidByDocID.Caption, paidByDocIdValue)
        ctx.PaidByDocID = paidByDocIdValue

        ' حالة المستند
        Dim docStatusValue As Integer = -1
        Integer.TryParse(Convert.ToString(Me.DocStatus.EditValue), docStatusValue)
        ctx.DocStatus = docStatusValue

        If docStatusValue = -1 Then
            ' سند جديد
            ctx.DocStatus = 1
            ctx.InputUser = GlobalVariables.CurrUser
            ctx.DeviceName = GlobalVariables.CurrDevice
            ctx.DocLogName = "Insert"
            ctx.LogDetails = "New Voucher "
            ctx.AskBeforeSave = "هل تريد حفظ السند"
            ctx.DocIDForLog = 0
            ctx.InputDateTime = nowValue.ToString("yyyy-MM-dd HH:mm:ss")

            ctx.PaidStatus = 0
            ctx.PaidByDocID = 0
            ctx.PaidAmount = 0
            ctx.PosNo = 0
            ctx.ShiftID = 0
            ctx.DocID2 = 0
        Else
            ' تعديل سند
            ctx.DocID = CInt(Me.DocID.Text)
            ctx.InputUser = CInt(BarInputUser.Caption)
            ctx.DeviceName = BarDeviceName.Caption
            ctx.AskBeforeSave = "هل تريد تعديل السند"
            ctx.DocLogName = "Update"
            ctx.LogDetails = "Update Voucher "
            ctx.InputDateTime = BarInputDateTime.Caption
            ctx.DocIDForLog = ctx.DocID
        End If

        ctx.HasAttachment = CheckIfDocumentHasAttachment(Me.DocCode.Text)

        ' حذف من JournalTemp قبل بناء جديد
        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)

        ' تحديد جدول الوجهة (Journal / OrdersJournal)
        If ctx.DocNameID = 10 Or ctx.DocNameID = 11 Then
            ctx.DocDataTableName = "dbo.OrdersJournal"
        Else
            ctx.DocDataTableName = "dbo.Journal"
        End If

        Return ctx

    End Function

    Private Sub BuildJournalTable(ctx As DocumentContext)

        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات")

        Select Case ctx.DocNameID
            Case 1, 8, 17
                BuildJournalForPurchases(ctx)
            Case 2, 9, 18
                BuildJournalForSales(ctx)
            Case 11
                BuildJournalForSalesOrder(ctx)
            Case 10
                BuildJournalForPurchaseOrder(ctx)
            Case 12
                BuildJournalForSalesReturn(ctx)
            Case 13
                BuildJournalForPurchaseReturn(ctx)
            Case 16
                BuildJournalForInternalTransfer(ctx)
        End Select

    End Sub

    ' New
    Private Sub BuildJournalForPurchases(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف المدين — الأصناف
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse stockId Is DBNull.Value OrElse stockId.ToString() = "" Then
                Continue For
            End If

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '--- Cost Center
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '--- حساب المدين
            Dim itemData = GetItemsData(stockId, False)
            Select Case ctx.DocNameID
                Case 1, 8 : R("DebitAcc") = itemData.AccPurches
                Case 17 : R("DebitAcc") = "4020000000"
            End Select
            R("CredAcc") = "0"

            '--- العملة
            R("AccountCurr") = GetFinancialAccountsData(R("DebitAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   حساب مبلغ السطر (DocAmount) حسب حالة الضريبة
            '========================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' VAT ON → ignore voucher discount
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                R("DocAmount") = netBeforeVat - itemVat  ' صافي بدون ضريبة
                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc

            Else
                ' VAT OFF → use voucher discount
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            ' تحويل العملة
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))

            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '========================================================
            '   بيانات المخزون
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))

            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc
            R("StockDebitWhereHouse") = StockDebitWhereHouse.EditValue

            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            R("Color") = If(IsDBNull(GridView1.GetRowCellValue(i, "Color")),
                        0, GridView1.GetRowCellValue(i, "Color"))
            R("Measure") = GridView1.GetRowCellValue(i, "Measure")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0

            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) طرف الضريبة (إن وجد)
        '============================================================
        If GlobalVariables.UseVAT Then

            Dim taxAmount As Decimal = CDec(TextTotalTax.EditValue)
            If taxAmount > 0 Then

                Dim R As DataRow = JT.NewRow()
                FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                                ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

                R("DocCostCenter") = If(String.IsNullOrWhiteSpace(LookCostCenter.Text),
                                    1, LookCostCenter.EditValue)

                R("DebitAcc") = "2107020000"    ' حساب ضريبة المدخلات
                R("CredAcc") = "0"

                R("AccountCurr") = _DefaultCurr
                R("DocCurrency") = DocCurrency.EditValue

                R("DocAmount") = taxAmount
                R("ExchangePrice") = ExchangePrice.EditValue
                R("BaseCurrAmount") = taxAmount * ExchangePrice.EditValue
                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), taxAmount)

                R("StockID") = 0
                R("Referance") = ctx.Referance
                R("ReferanceName") = TextReferanceName.Text

                R("OrderID") = -1
                R("ItemVAT") = 0
                R("ItemVATPercentage") = 0
                R("IsVAT") = 1

                FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                                  ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                                  StockDriver.Text, StockCarNo.Text)

                JT.Rows.Add(R)
            End If
        End If


        '============================================================
        ' 3) الطرف الدائن — حساب المورد
        '============================================================
        Dim creditRow As DataRow = JT.NewRow()
        FillCommonDocFields(creditRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                        ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

        creditRow("DocCostCenter") =
        If(String.IsNullOrWhiteSpace(LookCostCenter.Text), 1, LookCostCenter.EditValue)

        creditRow("DebitAcc") = "0"

        Select Case ctx.DocNameID
            Case 1, 8
                creditRow("CredAcc") = AccountForRefranace.EditValue
            Case 17
                creditRow("CredAcc") = "4020000000"
        End Select

        creditRow("AccountCurr") = GetFinancialAccountsData(creditRow("CredAcc")).Currency
        creditRow("DocCurrency") = DocCurrency.EditValue

        ' DocAmount للمورد = إجمالي بعد الضريبة
        creditRow("DocAmount") = JT.Compute("SUM(DocAmount)", "")
        'creditRow("DocAmount") = TextTotalAfterTAX.EditValue
        creditRow("ExchangePrice") = CDec(ExchangePrice.EditValue)
        creditRow("BaseCurrAmount") = totalBaseCurr + CDec(TextTotalTax.EditValue)
        creditRow("BaseAmount") =
        GetBaseAmount(creditRow("AccountCurr"), CDec(creditRow("DocAmount")))

        creditRow("StockID") = 0
        creditRow("Referance") = ctx.Referance
        creditRow("ReferanceName") = TextReferanceName.Text

        creditRow("OrderID") = 0
        creditRow("ItemVAT") = 0
        creditRow("ItemVATPercentage") = 0
        creditRow("IsVAT") = 0

        FillPaymentAndPosInfo(creditRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

        JT.Rows.Add(creditRow)

    End Sub

    ' New
    Private Sub BuildJournalForSales(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف الدائن — المبيعات (الأصناف)
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse stockId Is DBNull.Value OrElse stockId.ToString() = "" Then
                Continue For
            End If

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '--- Cost Center
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '--- حساب الدائن (حساب المبيعات)
            Dim itemData = GetItemsData(stockId, False)
            Select Case ctx.DocNameID
                Case 2, 9    ' فاتورة مبيعات + إرسالـية مبيعات
                    R("CredAcc") = itemData.AccSales
                Case 18      ' مردودات (إعادة) مبيعات
                    R("CredAcc") = "4020000000"
            End Select
            R("DebitAcc") = "0"

            '--- العملة
            R("AccountCurr") = GetFinancialAccountsData(R("CredAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '============================================================
            '   حساب DocAmount حسب الضريبة
            '============================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' VAT ON → تجاهل خصم الفاتورة
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                R("DocAmount") = netBeforeVat - itemVat    ' صافي بدون ضريبة
                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc

            Else
                ' VAT OFF → خصم الفاتورة مفعل
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            ' تحويل العملة
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))

            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '============================================================
            '   بيانات المخزون (للبيع من المستودع)
            '============================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))

            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc
            R("StockDebitWhereHouse") = 0
            R("StockCreditWhereHouse") = StockCreditWhereHouse.EditValue

            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            R("Color") = If(IsDBNull(GridView1.GetRowCellValue(i, "Color")), 0,
                        GridView1.GetRowCellValue(i, "Color"))
            R("Measure") = GridView1.GetRowCellValue(i, "Measure")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0

            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) طرف الضريبة (إن وجد)
        '============================================================
        If GlobalVariables.UseVAT Then

            Dim taxAmount As Decimal = CDec(TextTotalTax.EditValue)
            If taxAmount > 0 Then

                Dim R As DataRow = JT.NewRow()
                FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                                ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

                R("DocCostCenter") = If(String.IsNullOrWhiteSpace(LookCostCenter.Text),
                                    1, LookCostCenter.EditValue)

                R("DebitAcc") = "0"
                R("CredAcc") = "2107010000"   ' ضريبة المخرجات (Sales VAT Payable)

                R("AccountCurr") = _DefaultCurr
                R("DocCurrency") = DocCurrency.EditValue

                R("DocAmount") = taxAmount
                R("ExchangePrice") = CDec(ExchangePrice.EditValue)
                R("BaseCurrAmount") = taxAmount * CDec(ExchangePrice.EditValue)
                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), taxAmount)

                R("StockID") = 0
                R("Referance") = ctx.Referance
                R("ReferanceName") = TextReferanceName.Text
                R("OrderID") = -1

                R("ItemVAT") = 0
                R("ItemVATPercentage") = 0
                R("IsVAT") = 1

                FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                                  ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                                  StockDriver.Text, StockCarNo.Text)

                JT.Rows.Add(R)
            End If
        End If


        '============================================================
        ' 3) الطرف المدين — حساب العميل
        '============================================================
        Dim debitRow As DataRow = JT.NewRow()
        FillCommonDocFields(debitRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                        ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

        debitRow("DocCostCenter") =
        If(String.IsNullOrWhiteSpace(LookCostCenter.Text), 1, LookCostCenter.EditValue)

        debitRow("CredAcc") = "0"
        debitRow("DebitAcc") = AccountForRefranace.EditValue      ' حساب العميل

        debitRow("AccountCurr") = GetFinancialAccountsData(debitRow("DebitAcc")).Currency
        debitRow("DocCurrency") = DocCurrency.EditValue

        '--- الطرف المدين يجب أن = مجموع الطرف الدائن
        Dim totalCredit As Decimal =
        JT.AsEnumerable().Where(Function(r) r.Field(Of String)("CredAcc") <> "0").
        Sum(Function(r) CDec(r("DocAmount")))

        debitRow("DocAmount") = totalCredit
        debitRow("ExchangePrice") = CDec(ExchangePrice.EditValue)
        debitRow("BaseCurrAmount") = totalBaseCurr + CDec(TextTotalTax.EditValue)
        debitRow("BaseAmount") = GetBaseAmount(debitRow("AccountCurr"), totalCredit)

        debitRow("StockID") = 0
        debitRow("Referance") = ctx.Referance
        debitRow("ReferanceName") = TextReferanceName.Text

        debitRow("OrderID") = 0
        debitRow("ItemVAT") = 0
        debitRow("ItemVATPercentage") = 0
        debitRow("IsVAT") = 0

        FillPaymentAndPosInfo(debitRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

        JT.Rows.Add(debitRow)

    End Sub

    ' New
    Private Sub BuildJournalForSalesOrder(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف المدين — أصناف طلبية المبيعات
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse IsDBNull(stockId) OrElse stockId.ToString() = "" Then Continue For

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '-----------------------------
            ' Cost Center
            '-----------------------------
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '-----------------------------
            ' حساب المدين — طلبية مبيعات
            ' ملاحظة: بعض الأنظمة تستخدم حساب "مبيعات مستقبلية" أو "طلبية مبيعات".
            ' سنستخدم حساب المبيعات العادي.
            '-----------------------------
            Dim itemData = GetItemsData(stockId, False)
            R("CredAcc") = itemData.AccSales
            R("DebitAcc") = "0"

            '-----------------------------
            ' العملة
            '-----------------------------
            R("AccountCurr") = GetFinancialAccountsData(R("DebitAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   حساب DocAmount حسب الضريبة
            '========================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' طلبية مبيعات — لا نستخدم خصم السند، ولا نُنشئ قيد ضريبة
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                R("DocAmount") = netBeforeVat - itemVat
                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc
            Else
                ' بدون ضريبة → استخدم Voucher Discount
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            '-----------------------------
            ' التحويل لعملة الأساس
            '-----------------------------
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))
            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '========================================================
            '  مخزون (أرقام فقط — لا يوجد تنزيل مخزون في طلبية)
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))
            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc

            R("StockDebitWhereHouse") = 0
            R("StockCreditWhereHouse") = StockCreditWhereHouse.EditValue

            ' معلومات إضافية
            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            Dim colorVal As Object = GridView1.GetRowCellValue(i, "Color")
            If colorVal Is Nothing OrElse IsDBNull(colorVal) Then
                R("Color") = 0
            Else
                R("Color") = Convert.ToInt32(colorVal)
            End If

            Dim measureVal As Object = GridView1.GetRowCellValue(i, "Measure")
            If measureVal Is Nothing OrElse IsDBNull(measureVal) Then
                R("Measure") = 0
            Else
                R("Measure") = Convert.ToInt32(measureVal)
            End If

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0

            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) الطرف الدائن — حساب الزبون
        '============================================================
        If JT.Rows.Count > 0 Then

            Dim creditRow As DataRow = JT.NewRow()
            FillCommonDocFields(creditRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            creditRow("DocCostCenter") = If(String.IsNullOrWhiteSpace(LookCostCenter.Text),
                                        1, LookCostCenter.EditValue)

            creditRow("CredAcc") = "0"
            creditRow("DebitAcc") = AccountForRefranace.EditValue  ' حساب العميل

            creditRow("AccountCurr") = GetFinancialAccountsData(creditRow("CredAcc")).Currency
            creditRow("DocCurrency") = DocCurrency.EditValue

            creditRow("DocAmount") = JT.Compute("SUM(DocAmount)", "")
            creditRow("ExchangePrice") = CDec(ExchangePrice.EditValue)
            creditRow("BaseCurrAmount") = totalBaseCurr
            creditRow("BaseAmount") =
        GetBaseAmount(creditRow("AccountCurr"), CDec(creditRow("DocAmount")))

            creditRow("StockID") = 0
            creditRow("Referance") = ctx.Referance
            creditRow("ReferanceName") = TextReferanceName.Text

            creditRow("OrderID") = 0
            creditRow("ItemVAT") = 0
            creditRow("ItemVATPercentage") = 0
            creditRow("IsVAT") = 0

            FillPaymentAndPosInfo(creditRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            JT.Rows.Add(creditRow)
        End If

    End Sub

    ' New
    Private Sub BuildJournalForSalesReturn(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف المدين — مردودات المبيعات (الأصناف)
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse stockId Is DBNull.Value OrElse stockId.ToString() = "" Then
                Continue For
            End If

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '--- مركز الكلفة
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '--- حساب المدين (مردودات المبيعات)
            Dim itemData = GetItemsData(stockId, False)
            Select Case ctx.DocNameID
                Case 12 ' مردودات مبيعات
                    R("DebitAcc") = itemData.AccRetSales
                Case Else
                    ' احتياطاً: يمكنك وضع حساب افتراضي أو تركه بدون تغيير
                    R("DebitAcc") = itemData.AccRetSales
            End Select
            R("CredAcc") = "0"

            '--- العملة
            R("AccountCurr") = GetFinancialAccountsData(R("DebitAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   حساب مبلغ السطر (DocAmount) حسب حالة الضريبة
            '========================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' VAT ON → نتجاهل خصم الفاتورة
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                ' مردودات: مدين بمردودات المبيعات بقيمة صافي بدون ضريبة
                R("DocAmount") = netBeforeVat - itemVat
                If CDec(R("DocAmount")) < 0D Then R("DocAmount") = 0D

                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc
            Else
                ' VAT OFF → خصم الفاتورة مفعل
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            ' تحويل العملة
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))

            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '========================================================
            '   بيانات المخزون (المردودات ترجع للمستودع)
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))

            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc
            R("StockDebitWhereHouse") = StockDebitWhereHouse.EditValue   ' عودة للمستودع
            R("StockCreditWhereHouse") = 0

            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            R("Color") = If(IsDBNull(GridView1.GetRowCellValue(i, "Color")), 0,
                        GridView1.GetRowCellValue(i, "Color"))
            R("Measure") = GridView1.GetRowCellValue(i, "Measure")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0

            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) طرف الضريبة (عكس ضريبة المخرجات – إن وجد)
        '============================================================
        If GlobalVariables.UseVAT Then

            Dim taxAmount As Decimal = CDec(TextTotalTax.EditValue)
            If taxAmount > 0D Then

                Dim R As DataRow = JT.NewRow()
                FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                                ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

                R("DocCostCenter") =
                If(String.IsNullOrWhiteSpace(LookCostCenter.Text), 1, LookCostCenter.EditValue)

                ' مردودات مبيعات: مدين بضريبة المخرجات لتخفيض الالتزام
                R("DebitAcc") = "2107010000"   ' حساب ضريبة المخرجات
                R("CredAcc") = "0"

                R("AccountCurr") = _DefaultCurr
                R("DocCurrency") = DocCurrency.EditValue

                R("DocAmount") = taxAmount
                R("ExchangePrice") = CDec(ExchangePrice.EditValue)
                R("BaseCurrAmount") = taxAmount * CDec(ExchangePrice.EditValue)
                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), taxAmount)

                R("StockID") = 0
                R("Referance") = ctx.Referance
                R("ReferanceName") = TextReferanceName.Text

                R("OrderID") = -1
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
                R("IsVAT") = 1

                FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                                  ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                                  StockDriver.Text, StockCarNo.Text)

                JT.Rows.Add(R)

                ' لو أردت أن تحتسب BaseCurr مع الضريبة:
                ' totalBaseCurr += CDec(R("BaseCurrAmount"))
            End If
        End If


        '============================================================
        ' 3) الطرف الدائن — حساب العميل (تقليل ذمم العميل)
        '============================================================
        Dim creditRow As DataRow = JT.NewRow()
        FillCommonDocFields(creditRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                        ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

        creditRow("DocCostCenter") =
        If(String.IsNullOrWhiteSpace(LookCostCenter.Text), 1, LookCostCenter.EditValue)

        creditRow("DebitAcc") = "0"
        creditRow("CredAcc") = AccountForRefranace.EditValue   ' حساب العميل

        creditRow("AccountCurr") = GetFinancialAccountsData(creditRow("CredAcc")).Currency
        creditRow("DocCurrency") = DocCurrency.EditValue

        ' مجموع الطرف المدين (مردودات + ضريبة) يجب أن يساوي هذا السطر
        Dim totalDebit As Decimal =
        JT.AsEnumerable().
           Where(Function(r) r.Field(Of String)("DebitAcc") <> "0").
           Sum(Function(r) CDec(r("DocAmount")))

        creditRow("DocAmount") = totalDebit
        creditRow("ExchangePrice") = CDec(ExchangePrice.EditValue)

        ' BaseCurrAmount هنا يمكن أيضاً حسابه كمجموع BaseCurrAmount للطرف المدين
        Dim totalDebitBase As Decimal =
        JT.AsEnumerable().
           Where(Function(r) r.Field(Of String)("DebitAcc") <> "0").
           Sum(Function(r) CDec(r("BaseCurrAmount")))

        creditRow("BaseCurrAmount") = totalDebitBase
        creditRow("BaseAmount") = GetBaseAmount(creditRow("AccountCurr"), totalDebit)

        creditRow("StockID") = 0
        creditRow("Referance") = ctx.Referance
        creditRow("ReferanceName") = TextReferanceName.Text

        creditRow("OrderID") = 0
        creditRow("ItemVAT") = 0D
        creditRow("ItemVATPercentage") = 0D
        creditRow("IsVAT") = 0

        FillPaymentAndPosInfo(creditRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

        JT.Rows.Add(creditRow)

    End Sub

    ' New
    Private Sub BuildJournalForPurchaseOrder(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف المدين – أصناف طلبية المشتريات
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse IsDBNull(stockId) OrElse stockId.ToString() = "" Then Continue For

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '-----------------------------
            ' Cost Center
            '-----------------------------
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '-----------------------------
            ' حساب المدين — مشتريات
            '-----------------------------
            Dim itemData = GetItemsData(stockId, False)
            R("DebitAcc") = itemData.AccPurches     ' حساب مشتريات
            R("CredAcc") = "0"

            '-----------------------------
            ' عملة الحساب + المستند
            '-----------------------------
            R("AccountCurr") = GetFinancialAccountsData(R("DebitAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   حساب DocAmount (مع أو بدون ضريبة حسب الإعدادات)
            '========================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' طلبية مشتريات: لا نخصم السند (VoucherDiscount)
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                R("DocAmount") = netBeforeVat - itemVat
                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc

            Else
                ' بدون ضريبة → استخدم خصم السند
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            ' تحويل العملة
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))
            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '========================================================
            ' بيانات المخزون
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))
            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc
            R("StockDebitWhereHouse") = StockDebitWhereHouse.EditValue

            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            ' أرفف + أبعاد
            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            R("Color") = If(IsDBNull(GridView1.GetRowCellValue(i, "Color")), 0, GridView1.GetRowCellValue(i, "Color"))
            R("Measure") = GridView1.GetRowCellValue(i, "Measure")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            ' الترحيل + نقاط البيع
            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0
            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) الطرف الدائن — حساب المورد (بدون ضريبة)
        '   Purchase Order does NOT post VAT to GL
        '============================================================
        Dim creditRow As DataRow = JT.NewRow()
        FillCommonDocFields(creditRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                        ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

        creditRow("DocCostCenter") = If(String.IsNullOrWhiteSpace(LookCostCenter.Text),
                                    1, LookCostCenter.EditValue)

        creditRow("DebitAcc") = "0"
        creditRow("CredAcc") = AccountForRefranace.EditValue

        creditRow("AccountCurr") = GetFinancialAccountsData(creditRow("CredAcc")).Currency
        creditRow("DocCurrency") = DocCurrency.EditValue

        ' إجمالي DocAmount (بدون ضريبة)
        creditRow("DocAmount") = JT.Compute("SUM(DocAmount)", "")
        creditRow("ExchangePrice") = CDec(ExchangePrice.EditValue)
        creditRow("BaseCurrAmount") = totalBaseCurr
        creditRow("BaseAmount") = GetBaseAmount(creditRow("AccountCurr"), CDec(creditRow("DocAmount")))

        creditRow("StockID") = 0
        creditRow("Referance") = ctx.Referance
        creditRow("ReferanceName") = TextReferanceName.Text

        creditRow("OrderID") = 0

        FillPaymentAndPosInfo(creditRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

        creditRow("ItemVAT") = 0
        creditRow("ItemVATPercentage") = 0
        creditRow("IsVAT") = 0

        JT.Rows.Add(creditRow)

    End Sub

    ' New
    Private Sub BuildJournalForPurchaseReturn(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable
        Dim totalBaseCurr As Decimal = 0D

        '============================================================
        ' 1) الطرف الدائن — مردودات مشتريات (الأصناف)
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse stockId Is DBNull.Value OrElse stockId.ToString() = "" Then
                Continue For
            End If

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '--- Cost Center
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '--- حساب الدائن (مردودات مشتريات)
            Dim itemData = GetItemsData(stockId, False)
            R("CredAcc") = itemData.AccRetPurches
            R("DebitAcc") = "0"

            '--- العملة
            R("AccountCurr") = GetFinancialAccountsData(R("CredAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   حساب DocAmount حسب الضريبة
            '========================================================
            Dim qty As Decimal = CDec(GridView1.GetRowCellValue(i, "StockQuantity"))
            Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "StockPrice"))
            Dim lineDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "StockDiscount"))
            Dim voucherDisc As Decimal = CDec(GridView1.GetRowCellValue(i, "VoucherDiscount"))
            Dim itemVat As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVAT"))
            Dim vatPerc As Decimal = CDec(GridView1.GetRowCellValue(i, "ItemVATPercentage"))

            Dim baseAmount = qty * price

            If GlobalVariables.UseVAT Then
                ' VAT ON → ignore voucher discount
                Dim netBeforeVat = baseAmount - lineDisc
                If netBeforeVat < 0D Then netBeforeVat = 0D

                ' مردودات مشتريات → CredAcc بسعر بدون الضريبة
                R("DocAmount") = netBeforeVat - itemVat
                If CDec(R("DocAmount")) < 0D Then R("DocAmount") = 0D

                R("ItemVAT") = itemVat
                R("ItemVATPercentage") = vatPerc

            Else
                ' VAT OFF → تطبيق خصم الفاتورة
                Dim net = baseAmount - lineDisc - voucherDisc
                If net < 0D Then net = 0D

                R("DocAmount") = net
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
            End If

            ' تحويل عملة
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))

            totalBaseCurr += CDec(R("BaseCurrAmount"))

            '========================================================
            '   بيانات المخزون (إخراج من المستودع)
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim bonus = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantity")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantity")))
            Dim bonusMain = CDec(If(IsDBNull(GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")),
                            0D, GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")))

            Dim qtyMain = CDec(GridView1.GetRowCellValue(i, "StockQuantityByMainUnit"))

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            R("StockPrice") = price
            R("StockDiscount") = lineDisc

            R("StockDebitWhereHouse") = 0
            R("StockCreditWhereHouse") = StockCreditWhereHouse.EditValue   ' خروج للمورد

            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")
            R("VoucherDiscount") = If(GlobalVariables.UseVAT, 0D, voucherDisc)

            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            R("Color") = If(IsDBNull(GridView1.GetRowCellValue(i, "Color")), 0,
                        GridView1.GetRowCellValue(i, "Color"))
            R("Measure") = GridView1.GetRowCellValue(i, "Measure")

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")

            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            R("IsVAT") = 0

            JT.Rows.Add(R)
        Next


        '============================================================
        ' 2) طرف الضريبة (عكس ضريبة المدخلات – إن وجد)
        '============================================================
        If GlobalVariables.UseVAT Then

            Dim taxAmount As Decimal = CDec(TextTotalTax.EditValue)
            If taxAmount > 0D Then

                Dim R As DataRow = JT.NewRow()
                FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                                ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

                R("DocCostCenter") = If(String.IsNullOrWhiteSpace(LookCostCenter.Text),
                                    1, LookCostCenter.EditValue)

                ' مردودات مشتريات تقلل VAT Input → Cred من الضريبة
                R("CredAcc") = "2107020000"   ' VAT Input
                R("DebitAcc") = "0"

                R("AccountCurr") = _DefaultCurr
                R("DocCurrency") = DocCurrency.EditValue

                R("DocAmount") = taxAmount
                R("ExchangePrice") = CDec(ExchangePrice.EditValue)
                R("BaseCurrAmount") = taxAmount * CDec(ExchangePrice.EditValue)
                R("BaseAmount") = GetBaseAmount(R("AccountCurr"), taxAmount)

                R("StockID") = 0
                R("Referance") = ctx.Referance
                R("ReferanceName") = TextReferanceName.Text

                R("OrderID") = -1
                R("ItemVAT") = 0D
                R("ItemVATPercentage") = 0D
                R("IsVAT") = 1

                FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                                  ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                                  StockDriver.Text, StockCarNo.Text)

                JT.Rows.Add(R)

            End If

        End If


        '============================================================
        ' 3) الطرف المدين — حساب المورد
        '============================================================
        Dim debitRow As DataRow = JT.NewRow()
        FillCommonDocFields(debitRow, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                        ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

        debitRow("DocCostCenter") =
        If(String.IsNullOrWhiteSpace(LookCostCenter.Text), 1, LookCostCenter.EditValue)

        debitRow("CredAcc") = "0"
        debitRow("DebitAcc") = AccountForRefranace.EditValue   ' المورد

        debitRow("AccountCurr") = GetFinancialAccountsData(debitRow("DebitAcc")).Currency
        debitRow("DocCurrency") = DocCurrency.EditValue

        ' مجموع الطرف الدائن (مردودات + VAT) يجب أن = هذا السطر
        Dim totalCredit As Decimal =
        JT.AsEnumerable().Where(Function(r) r.Field(Of String)("CredAcc") <> "0").
        Sum(Function(r) CDec(r("DocAmount")))

        debitRow("DocAmount") = totalCredit
        debitRow("ExchangePrice") = CDec(ExchangePrice.EditValue)

        Dim totalCreditBase As Decimal =
        JT.AsEnumerable().Where(Function(r) r.Field(Of String)("CredAcc") <> "0").
        Sum(Function(r) CDec(r("BaseCurrAmount")))

        debitRow("BaseCurrAmount") = totalCreditBase
        debitRow("BaseAmount") = GetBaseAmount(debitRow("AccountCurr"), totalCredit)

        debitRow("StockID") = 0
        debitRow("Referance") = ctx.Referance
        debitRow("ReferanceName") = TextReferanceName.Text

        debitRow("OrderID") = 0
        debitRow("ItemVAT") = 0D
        debitRow("ItemVATPercentage") = 0D
        debitRow("IsVAT") = 0

        FillPaymentAndPosInfo(debitRow, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                          ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                          StockDriver.Text, StockCarNo.Text)

        JT.Rows.Add(debitRow)

    End Sub

    ' New
    Private Sub BuildJournalForInternalTransfer(ctx As DocumentContext)

        Dim JT As DataTable = ctx.JournalTable

        '============================================================
        ' 1) Internal Transfer – one row per item (no GL accounts)
        '============================================================
        For i As Integer = 0 To GridView1.RowCount - 1

            Dim stockId = GridView1.GetRowCellValue(i, "StockID")
            If stockId Is Nothing OrElse stockId Is DBNull.Value OrElse stockId.ToString() = "" Then
                Continue For
            End If

            Dim R As DataRow = JT.NewRow()
            FillCommonDocFields(R, ctx.DocStatus, ctx.InputUser, ctx.DeviceName,
                            ctx.InputDateTime, ctx.ModifiedDateTime, ctx.OrderStatus)

            '---------------------------
            ' Cost Center
            '---------------------------
            Dim cc = GridView1.GetRowCellValue(i, "DocCostCenter")
            R("DocCostCenter") = If(cc Is Nothing OrElse IsDBNull(cc), 0, cc)

            '---------------------------
            ' Accounts – neutral (no GL effect)
            '---------------------------
            R("DebitAcc") = "0"
            R("CredAcc") = "0"

            ' Workaround: your old code used GetFinancialAccountsData("0")
            ' so we keep the same behavior to preserve currency logic.
            R("AccountCurr") = GetFinancialAccountsData(R("CredAcc")).Currency
            R("DocCurrency") = DocCurrency.EditValue

            '========================================================
            '   DocAmount = DocAmount(row) - VoucherDiscount(row)
            '   (same as your original Case 16)
            '========================================================
            Dim docAmountGrid As Decimal = 0D
            Dim voucherDisc As Decimal = 0D

            Dim docAmountObj = GridView1.GetRowCellValue(i, "DocAmount")
            Dim voucherDiscObj = GridView1.GetRowCellValue(i, "VoucherDiscount")

            If docAmountObj IsNot Nothing AndAlso docAmountObj IsNot DBNull.Value Then
                docAmountGrid = CDec(docAmountObj)
            End If

            If voucherDiscObj IsNot Nothing AndAlso voucherDiscObj IsNot DBNull.Value Then
                voucherDisc = CDec(voucherDiscObj)
            End If

            Dim lineDocAmount As Decimal = docAmountGrid - voucherDisc
            If lineDocAmount < 0D Then lineDocAmount = 0D

            R("DocAmount") = lineDocAmount

            ' VAT on internal transfer is not posted to GL
            Dim itemVat As Decimal = 0D
            Dim vatPerc As Decimal = 0D

            Dim itemVatObj = GridView1.GetRowCellValue(i, "ItemVAT")
            Dim vatPercObj = GridView1.GetRowCellValue(i, "ItemVATPercentage")

            If itemVatObj IsNot Nothing AndAlso itemVatObj IsNot DBNull.Value Then
                itemVat = CDec(itemVatObj)
            End If

            If vatPercObj IsNot Nothing AndAlso vatPercObj IsNot DBNull.Value Then
                vatPerc = CDec(vatPercObj)
            End If

            R("ItemVAT") = itemVat
            R("ItemVATPercentage") = vatPerc

            '---------------------------
            ' Currency conversion
            '---------------------------
            R("ExchangePrice") = CDec(ExchangePrice.EditValue)
            R("BaseCurrAmount") = CDec(R("DocAmount")) * CDec(R("ExchangePrice"))
            R("BaseAmount") = GetBaseAmount(R("AccountCurr"), CDec(R("DocAmount")))

            '========================================================
            '   Stock information (movement between warehouses)
            '========================================================
            R("StockID") = stockId
            R("StockUnit") = GridView1.GetRowCellValue(i, "StockUnit")

            Dim qty As Decimal = 0D
            Dim qtyMain As Decimal = 0D
            Dim bonus As Decimal = 0D
            Dim bonusMain As Decimal = 0D

            Dim qtyObj = GridView1.GetRowCellValue(i, "StockQuantity")
            Dim qtyMainObj = GridView1.GetRowCellValue(i, "StockQuantityByMainUnit")
            Dim bonusObj = GridView1.GetRowCellValue(i, "BonusQuantity")
            Dim bonusMainObj = GridView1.GetRowCellValue(i, "BonusQuantityByMainUnit")

            If qtyObj IsNot Nothing AndAlso qtyObj IsNot DBNull.Value Then
                qty = CDec(qtyObj)
            End If

            If qtyMainObj IsNot Nothing AndAlso qtyMainObj IsNot DBNull.Value Then
                qtyMain = CDec(qtyMainObj)
            End If

            If bonusObj IsNot Nothing AndAlso bonusObj IsNot DBNull.Value Then
                bonus = CDec(bonusObj)
            End If

            If bonusMainObj IsNot Nothing AndAlso bonusMainObj IsNot DBNull.Value Then
                bonusMain = CDec(bonusMainObj)
            End If

            R("StockQuantity") = qty + bonus
            R("StockQuantityByMainUnit") = qtyMain + bonusMain

            ' Price / Discount
            Dim price As Decimal = 0D
            Dim lineDisc As Decimal = 0D

            Dim priceObj = GridView1.GetRowCellValue(i, "StockPrice")
            Dim discObj = GridView1.GetRowCellValue(i, "StockDiscount")

            If priceObj IsNot Nothing AndAlso priceObj IsNot DBNull.Value Then
                price = CDec(priceObj)
            End If
            If discObj IsNot Nothing AndAlso discObj IsNot DBNull.Value Then
                lineDisc = CDec(discObj)
            End If

            R("StockPrice") = price
            R("StockDiscount") = lineDisc

            ' From / To warehouses
            R("StockDebitWhereHouse") = StockDebitWhereHouse.EditValue
            R("StockCreditWhereHouse") = StockCreditWhereHouse.EditValue

            ' Voucher Discount (for reports only)
            R("VoucherDiscount") = voucherDisc

            ' Shelves + dimensional fields
            FillShelves(R, GridView1, i)
            FillStockDimensions(R, GridView1, i)

            '========================================================
            '   Misc fields
            '========================================================
            R("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
            R("StockBarcode") = GridView1.GetRowCellValue(i, "StockBarcode")

            R("Referance") = ctx.Referance
            R("ReferanceName") = TextReferanceName.Text

            Dim colorObj = GridView1.GetRowCellValue(i, "Color")
            If colorObj Is Nothing OrElse colorObj Is DBNull.Value Then
                R("Color") = 0
            Else
                R("Color") = colorObj
            End If

            Dim measureObj = GridView1.GetRowCellValue(i, "Measure")
            If measureObj IsNot Nothing AndAlso measureObj IsNot DBNull.Value Then
                R("Measure") = measureObj
            End If

            R("ItemNo2") = GridView1.GetRowCellValue(i, "ItemNo2")
            R("LastPurchasePrice") = GridView1.GetRowCellValue(i, "LastPurchasePrice")
            R("BatchID") = GridView1.GetRowCellValue(i, "BatchID")
            R("BatchNo") = GridView1.GetRowCellValue(i, "BatchNo")

            R("OrderID") = i + 1

            FillPaymentAndPosInfo(R, ctx.PaidStatus, ctx.PaidAmount, ctx.PaidByDocID,
                              ctx.PosNo, ctx.ShiftID, ctx.DocID2, ctx.DocTags,
                              StockDriver.Text, StockCarNo.Text)

            ' Internal transfer rows are not VAT rows
            R("IsVAT") = 0

            JT.Rows.Add(R)

            ' Optional: progress bar
            If JT.Rows.Count > 0 Then
                SplashScreenManager.Default.SetWaitFormDescription(
                CInt(100 * (i + 1) / GridView1.RowCount) & "%" &
                " " & (i + 1).ToString() & " From " & GridView1.RowCount.ToString())
            End If

        Next

    End Sub

    Private Function CreateJournalTableSchema() As DataTable
        Dim dt As New DataTable("JournalTemp")

        dt.Columns.Add("DocID", GetType(Integer))
        dt.Columns.Add("DocDate", GetType(Date))           ' [date]
        dt.Columns.Add("TaxDate", GetType(Date))           ' [date]
        dt.Columns.Add("DocName", GetType(Integer))
        dt.Columns.Add("DocStatus", GetType(Integer))
        dt.Columns.Add("DocCostCenter", GetType(Integer))
        dt.Columns.Add("DebitAcc", GetType(String))        ' varchar(10)
        dt.Columns.Add("CredAcc", GetType(String))         ' varchar(10)
        dt.Columns.Add("AccountCurr", GetType(Integer))
        dt.Columns.Add("DocCurrency", GetType(Integer))
        dt.Columns.Add("DocAmount", GetType(Double))       ' float
        dt.Columns.Add("ExchangePrice", GetType(Double))   ' float
        dt.Columns.Add("BaseCurrAmount", GetType(Double))  ' float
        dt.Columns.Add("BaseAmount", GetType(Double))      ' float
        dt.Columns.Add("DocSort", GetType(Integer))
        dt.Columns.Add("Referance", GetType(String))       ' nvarchar(20)
        dt.Columns.Add("DocManualNo", GetType(String))     ' nvarchar(50)
        dt.Columns.Add("DocMultiCurrency", GetType(Boolean)) ' bit
        dt.Columns.Add("InputUser", GetType(Integer))
        dt.Columns.Add("InputDateTime", GetType(Date))     ' datetime
        dt.Columns.Add("ModifiedUser", GetType(Integer))
        dt.Columns.Add("ModifiedDateTime", GetType(Date))  ' datetime
        dt.Columns.Add("DocAuditDate", GetType(Date))      ' datetime
        dt.Columns.Add("DocAuditUser", GetType(Integer))
        dt.Columns.Add("DocNotes", GetType(String))        ' nvarchar(max)
        dt.Columns.Add("StockID", GetType(Integer))
        dt.Columns.Add("StockUnit", GetType(Integer))
        dt.Columns.Add("StockQuantity", GetType(Double))   ' float
        dt.Columns.Add("StockQuantityByMainUnit", GetType(Double))
        dt.Columns.Add("StockPrice", GetType(Double))      ' float
        dt.Columns.Add("StockItemPrice", GetType(Double))  ' float
        dt.Columns.Add("StockDebitWhereHouse", GetType(Integer))
        dt.Columns.Add("StockCreditWhereHouse", GetType(Integer))
        dt.Columns.Add("StockDriver", GetType(String))     ' nvarchar(50)
        dt.Columns.Add("StockCarNo", GetType(String))      ' nvarchar(max)
        dt.Columns.Add("SalesPerson", GetType(Integer))
        dt.Columns.Add("CheckNo", GetType(Integer))
        dt.Columns.Add("CheckInOut", GetType(String))      ' nvarchar(5)
        dt.Columns.Add("CheckStatus", GetType(Integer))
        dt.Columns.Add("CheckDueDate", GetType(Date))      ' date
        dt.Columns.Add("CheckCustBank", GetType(String))   ' varchar(20)
        dt.Columns.Add("CheckCustBranch", GetType(String)) ' varchar(20)
        dt.Columns.Add("CheckCustAccountId", GetType(String)) ' varchar(20)
        dt.Columns.Add("AccountBank", GetType(Integer))
        dt.Columns.Add("DeleteUser", GetType(Integer))
        dt.Columns.Add("DeleteDateTime", GetType(Date))
        dt.Columns.Add("CurrentUserID", GetType(Integer))
        dt.Columns.Add("ReferanceName", GetType(String))   ' nvarchar(100)
        dt.Columns.Add("DocCode", GetType(String))         ' varchar(50)
        dt.Columns.Add("CheckCode", GetType(String))       ' varchar(15)
        dt.Columns.Add("ItemName", GetType(String))        ' nvarchar(250)
        dt.Columns.Add("DocCheckTransID", GetType(Integer))
        dt.Columns.Add("TransNoInJournal", GetType(Integer))
        dt.Columns.Add("ShiftID", GetType(Integer))
        dt.Columns.Add("DocNoteByAccount", GetType(String)) ' nvarchar(max)
        dt.Columns.Add("StockDiscount", GetType(Double))    ' float
        dt.Columns.Add("StockBarcode", GetType(String))     ' varchar(50)
        dt.Columns.Add("PosNo", GetType(Integer))
        dt.Columns.Add("DeviceName", GetType(String))       ' nvarchar(70)
        dt.Columns.Add("OrderStatus", GetType(Integer))
        dt.Columns.Add("ItemStatus", GetType(Integer))
        dt.Columns.Add("ApprovedQuantity", GetType(Decimal)) ' decimal(18,2)
        dt.Columns.Add("LastDocCode", GetType(String))      ' varchar(50)
        dt.Columns.Add("LastDataName", GetType(String))     ' varchar(30)
        dt.Columns.Add("DeliverDate", GetType(Date))        ' datetime
        dt.Columns.Add("Color", GetType(Integer))
        dt.Columns.Add("Measure", GetType(Integer))
        dt.Columns.Add("VoucherDiscount", GetType(Double))  ' float
        dt.Columns.Add("ItemVAT", GetType(Double))          ' float
        dt.Columns.Add("StockDebitShelve", GetType(Integer))
        dt.Columns.Add("StockCreditShelve", GetType(Integer))

        ' Identity في SQL لكن في DataTable نتركه Int عادي (سيُتجاهل أو يملأه السيرفر لاحقاً)
        dt.Columns.Add("ID", GetType(Integer))

        dt.Columns.Add("ItemNo2", GetType(String))          ' varchar(50)
        dt.Columns.Add("OrderID", GetType(Integer))
        dt.Columns.Add("Produced", GetType(Boolean))        ' bit
        dt.Columns.Add("DocID2", GetType(Integer))
        dt.Columns.Add("DocDueDate", GetType(Date))
        dt.Columns.Add("LastPurchasePrice", GetType(Double)) ' float
        dt.Columns.Add("BatchID", GetType(Integer))
        dt.Columns.Add("BatchNo", GetType(String))          ' nvarchar(50)
        dt.Columns.Add("PaidStatus", GetType(Integer))
        dt.Columns.Add("PaidAmount", GetType(Integer))      ' int في SQL
        dt.Columns.Add("PaidByDocID", GetType(Integer))
        dt.Columns.Add("TarteebID", GetType(Integer))
        dt.Columns.Add("DocTags", GetType(String))          ' nvarchar(1024)
        dt.Columns.Add("POSVoucherPayType", GetType(String)) ' nvarchar(20)
        dt.Columns.Add("HasAttachment", GetType(Boolean))   ' bit
        dt.Columns.Add("BonusQuantity", GetType(Decimal))   ' decimal(18,4)
        dt.Columns.Add("BonusQuantityByMainUnit", GetType(Decimal)) ' decimal(18,4)
        dt.Columns.Add("OldTransID", GetType(Integer))
        dt.Columns.Add("TableID", GetType(Integer))
        dt.Columns.Add("DispatchQuantity", GetType(Double))           ' float
        dt.Columns.Add("DispatchStockQuantityByMainUnit", GetType(Double)) ' float
        dt.Columns.Add("DispatchVoucherID", GetType(Integer))
        dt.Columns.Add("SubAccount", GetType(Integer))
        dt.Columns.Add("CashCustomerId", GetType(Integer))
        dt.Columns.Add("BaseItemPrice", GetType(Double))   ' float
        dt.Columns.Add("StockWidth", GetType(Decimal))     ' decimal(18,4)
        dt.Columns.Add("StockLength", GetType(Decimal))    ' decimal(18,4)
        dt.Columns.Add("StockCount", GetType(Decimal))     ' decimal(18,4)
        dt.Columns.Add("StockThickness", GetType(Decimal)) ' decimal(18,4)
        dt.Columns.Add("StockDivision", GetType(Decimal))  ' decimal(18,4)

        ' ملاحظة مهمة: في الجدول SQL النوع decimal(18,4) وليس bit
        dt.Columns.Add("IsVAT", GetType(Decimal))          ' decimal(18,4) NOT NULL
        dt.Columns.Add("ItemVATPercentage", GetType(Decimal)) ' decimal(18,4) NOT NULL

        Return dt
    End Function


    ' عملية تخزين الفاتورة
    Private Sub SaveDocument(_WithAction As String)

        Dim docCode As String = Me.DocCode.Text
        Dim postService As New DocumentsPostService()

        '============================================================
        ' 0) التحقق من السماح بالحفظ
        '============================================================
        If Not ValidateBeforeSave() Then Exit Sub

        '============================================================
        ' 1) تحديث GridView
        '============================================================
        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString())
            Exit Sub
        End Try

        '============================================================
        ' 2) توزيع الخصم وحساب المبلغ الأساسي
        '============================================================
        AllocateDiscount()
        CalcBaseAmount()

        '============================================================
        ' 3) تجهيز القيم العامة و DocumentContext
        '============================================================
        Dim nowValue As DateTime = Now()
        Dim modifiedDateTime As String = nowValue.ToString("yyyy-MM-dd HH:mm:ss")
        Dim inputDateTime As String = modifiedDateTime

        Dim docTags As String = _DocTagsToOpen
        Dim journalTable As DataTable = CreateJournalTableSchema()

        Dim referance As Integer = 0
        If Not String.IsNullOrWhiteSpace(Me.Referance.Text) Then
            Integer.TryParse(Me.Referance.Text, referance)
        End If

        Dim hasAttachment As Boolean = CheckIfDocumentHasAttachment(docCode)

        ' حالة السند في الـ UI: -1 = سند جديد، غير ذلك = تعديل
        Dim uiDocStatus As Integer
        If Me.DocStatus.EditValue Is Nothing Then
            uiDocStatus = -1
        ElseIf Me.DocStatus.EditValue.ToString() = "-1" Then
            uiDocStatus = -1
        Else
            uiDocStatus = CInt(Me.DocStatus.EditValue)
        End If

        ' إعداد سياق المستند
        Dim ctx As New DocumentContext With {
        .DocNameID = CInt(DocName.EditValue),
        .DocStatus = uiDocStatus,            ' يُستخدم في PostDocumentWithTransaction
        .InputUser = If(uiDocStatus = -1,    ' سند جديد
                        GlobalVariables.CurrUser,
                        CInt(BarInputUser.Caption)),
        .DeviceName = If(uiDocStatus = -1,
                         GlobalVariables.CurrDevice,
                         BarDeviceName.Caption),
        .InputDateTime = If(uiDocStatus = -1,
                            inputDateTime,
                            BarInputDateTime.Caption),
        .ModifiedDateTime = modifiedDateTime,
        .Referance = referance,
        .DocCode = docCode,
        .DocID = If(uiDocStatus = -1, 0, CInt(Me.DocID.Text)),
        .JournalTable = journalTable,
        .PaidStatus = CInt(Me.BarPaidStatus.Caption),
        .PaidAmount = CDec(Me.BarPaidSAmount.Caption),
        .PaidByDocID = CInt(Me.BarPaidByDocID.Caption),
        .PosNo = _PosNo,
        .ShiftID = _ShiftID,
        .DocID2 = _DocID2,
        .DocTags = docTags,
        .HasAttachment = hasAttachment
    }

        ' تحديد جدول الوجهة (Journal / OrdersJournal) ليستخدم داخل الترانزكشن
        If ctx.DocNameID = 10 OrElse ctx.DocNameID = 11 Then
            ctx.DocDataTableName = "dbo.OrdersJournal"
        Else
            ctx.DocDataTableName = "dbo.Journal"
        End If

        '============================================================
        ' 4) حذف السابق من JournalTemp لهذا المستند/المستخدم
        '============================================================
        DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode)

        '============================================================
        ' 5) بناء جدول اليومية في الذاكرة
        '============================================================
        SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
        SplashScreenManager.Default.SetWaitFormCaption("جاري تحضير البيانات")

        Try
            BuildJournalTable(ctx)
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            XtraMessageBox.Show("خطأ في تحضير البيانات، الرجاء فحص البيانات واعادة المحاولة" & vbCrLf &
                            ex.Message,
                            "خطأ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode)
            Exit Sub
        End Try

        SplashScreenManager.CloseForm(False)

        '============================================================
        ' 6) ترحيل جدول اليومية المؤقت إلى SQL (BulkCopy → JournalTemp)
        '============================================================
        Using bulkCopy As New SqlBulkCopy(My.Settings.TrueTimeConnectionString, SqlBulkCopyOptions.TableLock)
            For Each col As DataColumn In ctx.JournalTable.Columns
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName)
            Next
            bulkCopy.DestinationTableName = "JournalTemp"
            bulkCopy.BulkCopyTimeout = 600
            bulkCopy.WriteToServer(ctx.JournalTable)
        End Using

        '============================================================
        ' 7) التحقق من توازن القيد في JournalTemp
        '============================================================
        If Not ValidateJournalBalancedInDb(ctx.DocCode) Then
            DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode)
            Exit Sub
        End If

        '============================================================
        ' 8) فحص الرفوف
        '============================================================
        If Not CheckIfShelvesInWarehouse() Then
            MsgBoxShowError(" يوجد رفوف غير معرفة على المستودع ")
            DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode)
            Exit Sub
        End If

        '============================================================
        ' 9) رسالة تأكيد الحفظ
        '============================================================
        Dim askText As String =
        If(uiDocStatus = -1, "هل تريد حفظ السند؟", "هل تريد تعديل السند؟")

        If XtraMessageBox.Show(askText, "Confirmation", MessageBoxButtons.YesNo) = DialogResult.No Then
            DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode)
            Exit Sub
        End If

        ' القيم الخاصة بالـ Log
        ctx.DocLogName = If(uiDocStatus = -1, "Insert", "Update")
        ctx.LogDetails = If(uiDocStatus = -1, "New Voucher", "Update Voucher")
        ctx.LogDateTime = modifiedDateTime
        ctx.DocIDForLog = If(uiDocStatus = -1, 0, ctx.DocID)

        '============================================================
        ' 10) تنفيذ عملية الترحيل الفعلية داخل Transaction واحدة
        '============================================================
        Try
            ' هذه الدالة تنفذ:
            ' - DeleteFromJournalTx (عند التعديل)
            ' - GetDocNo (عند السند الجديد)
            ' - UpdateJournalTempBeforePostToJournalTx (إن وجد مرفقات)
            ' - InsertDataFromTempToJournalTx
            ' - UpdateInsertSerialTx (إن كانت التسلسلات مفعلة)
            ' - ChangePurchasePricesTx (لسندات المشتريات)
            ' - DeleteFromJournalTempTx
            If Not PostDocumentWithTransaction(ctx, hasAttachment) Then
                ' الدالة أظهرت الرسالة و عملت Rollback
                DeleteFromJournalTemp(ctx.DocNameID, ctx.DocCode) ' تنظيف احتياطي
                Exit Sub
            End If

            ' بعد نجاح الترانزكشن، يكون ctx.DocID محدثاً (للسند الجديد)
            If uiDocStatus = -1 Then
                ctx.DocIDForLog = ctx.DocID
            End If

            '========================================================
            ' 11) بناء رسالة WhatsApp بعد نجاح الحفظ
            '========================================================
            Dim messageBuilder As New System.Text.StringBuilder()

            messageBuilder.AppendLine("╔════════════════════════╗")

            Select Case ctx.DocNameID
                Case 1
                    messageBuilder.AppendLine("║  📦 فاتورة مشتريات رقم: " & ctx.DocID)
                Case 2
                    messageBuilder.AppendLine("║  🧾 فاتورة مبيعات رقم: " & ctx.DocID)
                Case 8
                    messageBuilder.AppendLine("║  📥 سند ادخال رقم: " & ctx.DocID)
                Case 9
                    messageBuilder.AppendLine("║  📤 سند اخراج رقم: " & ctx.DocID)
                Case 10
                    messageBuilder.AppendLine("║  🛒 طلبية شراء رقم: " & ctx.DocID)
                Case 11
                    messageBuilder.AppendLine("║  🛍️ طلبية بيع رقم: " & ctx.DocID)
                Case 12
                    messageBuilder.AppendLine("║  ↩️ مردودات مبيعات رقم: " & ctx.DocID)
                Case 13
                    messageBuilder.AppendLine("║  ↩️ مردودات مشتريات رقم: " & ctx.DocID)
                Case 16
                    messageBuilder.AppendLine("║  🔄 سند تحويل داخلي رقم: " & ctx.DocID)
                Case Else
                    messageBuilder.AppendLine("║  📄 فاتورة رقم: " & ctx.DocID)
            End Select

            messageBuilder.AppendLine("╚════════════════════════╝")
            messageBuilder.AppendLine("")
            messageBuilder.AppendLine("👤 الزبون: " & Me.TextReferanceName.Text)

            If Not String.IsNullOrEmpty(Me.DocManualNo.Text) Then
                messageBuilder.AppendLine("🔖 رقم يدوي: " & Me.DocManualNo.Text)
            End If

            messageBuilder.AppendLine("📋 التفاصيل:")

            Dim totalQuantity As Decimal = 0
            Dim totalAmount As Decimal = 0
            Dim totalBeforeDiscount As Decimal = 0
            Dim itemCounter As Integer = 0

            For i As Integer = 0 To GridView1.RowCount - 1
                Try
                    Dim itemNameObj = GridView1.GetRowCellValue(i, "ItemName")
                    Dim quantityObj = GridView1.GetRowCellValue(i, "StockQuantity")
                    Dim priceObj = GridView1.GetRowCellValue(i, "StockPrice")
                    Dim amountObj = GridView1.GetRowCellValue(i, "DocAmount")

                    If itemNameObj Is Nothing OrElse IsDBNull(itemNameObj) OrElse
                       quantityObj Is Nothing OrElse IsDBNull(quantityObj) OrElse
                       priceObj Is Nothing OrElse IsDBNull(priceObj) OrElse
                       amountObj Is Nothing OrElse IsDBNull(amountObj) Then
                        Continue For
                    End If

                    Dim itemName As String = itemNameObj.ToString()
                    Dim quantity As Decimal = CDec(quantityObj)
                    Dim price As Decimal = CDec(priceObj)
                    Dim amount As Decimal = CDec(amountObj)
                    Dim unitObj = GridView1.GetRowCellValue(i, "StockUnit")
                    Dim bonusObj = GridView1.GetRowCellValue(i, "BonusQuantity")
                    Dim discountObj = GridView1.GetRowCellValue(i, "StockDiscount")

                    Dim unitName As String = ""
                    Dim bonusQty As Decimal = 0
                    Dim itemDiscount As Decimal = 0

                    If unitObj IsNot Nothing AndAlso Not IsDBNull(unitObj) Then
                        Try
                            Dim unitId As Integer = CInt(unitObj)
                            Dim unitSql As New SQLControl
                            unitSql.SqlTrueAccountingRunQuery("SELECT name FROM Units WHERE id = " & unitId)
                            If unitSql.SQLDS.Tables(0).Rows.Count > 0 Then
                                unitName = unitSql.SQLDS.Tables(0).Rows(0)("name").ToString()
                            End If
                        Catch
                        End Try
                    End If

                    If bonusObj IsNot Nothing AndAlso Not IsDBNull(bonusObj) Then
                        bonusQty = CDec(bonusObj)
                    End If

                    If discountObj IsNot Nothing AndAlso Not IsDBNull(discountObj) Then
                        itemDiscount = CDec(discountObj)
                    End If

                    itemCounter += 1

                    messageBuilder.AppendLine("")
                    messageBuilder.AppendLine("▸ " & itemCounter.ToString() & ". " & itemName)

                    If Not String.IsNullOrEmpty(unitName) Then
                        messageBuilder.AppendLine("   ├─ الكمية: " & quantity.ToString("N2") & " " & unitName)
                    Else
                        messageBuilder.AppendLine("   ├─ الكمية: " & quantity.ToString("N2"))
                    End If

                    If bonusQty > 0 Then
                        If Not String.IsNullOrEmpty(unitName) Then
                            messageBuilder.AppendLine("   ├─ 🎁 بونص: " & bonusQty.ToString("N2") & " " & unitName)
                        Else
                            messageBuilder.AppendLine("   ├─ 🎁 بونص: " & bonusQty.ToString("N2"))
                        End If
                    End If

                    messageBuilder.AppendLine("   ├─ السعر: " & price.ToString("N2"))

                    If itemDiscount > 0 Then
                        messageBuilder.AppendLine("   ├─ 🏷️ خصم: -" & itemDiscount.ToString("N2"))
                    End If

                    messageBuilder.AppendLine("   └─ المبلغ: *" & amount.ToString("N2") & "*")

                    totalQuantity += quantity
                    totalAmount += amount
                    totalBeforeDiscount += (quantity * price)
                Catch ex As Exception
                    Continue For
                End Try
            Next

            messageBuilder.AppendLine("")
            messageBuilder.AppendLine("━━━━━━━━━━━━━━━━━━━━━━━━━")
            messageBuilder.AppendLine("")
            messageBuilder.AppendLine("• عدد الأصناف: " & itemCounter.ToString())
            messageBuilder.AppendLine("• إجمالي الكمية: " & Convert.ToDecimal(totalQuantity).ToString("N2"))

            If Not IsNothing(Me.TextTotalDocAmount.EditValue) AndAlso
               Not IsNothing(Me.TextVoucherDiscount.EditValue) AndAlso
               Me.TextVoucherDiscount.EditValue > 0 Then
                Dim amountBeforeDiscount As Decimal = CDec(Me.TextTotalDocAmount.EditValue) + CDec(Me.TextVoucherDiscount.EditValue)
                messageBuilder.AppendLine("• المبلغ قبل الخصم: " & amountBeforeDiscount.ToString("N2"))
            End If

            If Not IsNothing(TextVoucherDiscount.EditValue) AndAlso TextVoucherDiscount.EditValue > 0 Then
                messageBuilder.AppendLine("• 💰 خصم الفاتورة: -" & Convert.ToDecimal(TextVoucherDiscount.EditValue).ToString("N2"))
            End If

            messageBuilder.AppendLine("")
            If Not IsNothing(TextTotalDocAmount.EditValue) Then
                messageBuilder.AppendLine(" 💵 *مبلغ الفاتورة* :" & Convert.ToDecimal(TextTotalDocAmount.EditValue).ToString("N2"))
            End If

            If Not String.IsNullOrEmpty(Me.DocNotes.Text) Then
                messageBuilder.AppendLine("")
                messageBuilder.AppendLine("📝 ملاحظات:")
                messageBuilder.AppendLine(Me.DocNotes.Text)
            End If

            '========================================================
            ' 12) ما بعد الحفظ (لا يوجد كود حساس للتوازن هنا)
            '========================================================
            If ctx.DocLogName = "Update" Then EventForWhatsMsg = "WhenEdit"
            If ctx.DocLogName = "Insert" Then EventForWhatsMsg = "WhenAdd"
            ' Log السند
            CreateDocLog("Document",
                     ctx.DocCode,
                     ctx.DocNameID,
                     ctx.DocIDForLog,
                     ctx.DocLogName,
                     ctx.LogDetails,
                     ctx.LogDateTime)
            MoneyTrans.GenerateMessage(ctx.DocNameID, EventForWhatsMsg, messageBuilder.ToString(), ctx.DocIDForLog)

            ' حالة خاصة: موافقة طلبية وتحويلها إلى سند
            If _WithAction = "ApproveOrderToVoucher" Then
                PostOrdersToVouchers()
                Me.Dispose()
                Return
            End If

            ' عرض قائمة الإجراءات بعد الحفظ (طباعة / إرسال واتسآب / ... إلخ)
            If GlobalVariables._ShowActionMenueAfterSaveDocuments Then
                Dim f As New SavePrintPostDocument()
                With f
                    .DocAmount = Me.TextTotalDocAmount.EditValue
                    .DocName = ctx.DocNameID
                    .Referance = If(Me.Referance.Text <> "", Me.Referance.Text, "0")
                    .TextDocCode.Text = ctx.DocCode

                    If {1, 2, 8, 9, 12, 13, 16, 17, 18}.Contains(ctx.DocNameID) Then
                        .TextDocData.Text = "Journal"
                        .LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    ElseIf ctx.DocNameID = 10 OrElse ctx.DocNameID = 11 Then
                        .TextDocData.Text = "OrdersJournal"
                        .LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    End If

                    If ctx.DocNameID = 1 Then
                        .BtnIssueReceiptOrPayment.Text = "9- اصدار سند صرف"
                        .LayoutControlPayOrRec.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    ElseIf ctx.DocNameID = 2 Then
                        .BtnIssueReceiptOrPayment.Text = "9- اصدار سند قبض"
                        .LayoutControlPayOrRec.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    End If

                    .ShowDialog()
                End With
            End If

            ' إعادة تهيئة الشاشة
            LoadDefault()
            DocManualNo.Select()

            ' تنظيف الجداول المؤقتة في الذاكرة
            GlobalVariables._OrderTable.Clear()
            Try
                GlobalVariables._ItemsTable.Clear()
            Catch
            End Try

        Catch ex As Exception
            XtraMessageBox.Show("خطأ أثناء حفظ السند: " & vbCrLf & ex.Message,
                            "خطأ في الحفظ",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        Finally
            ' تحرير قفل المستند دائماً
            Try
                postService.ReleaseDocumentLock(docCode)
            Catch
            End Try
        End Try

    End Sub

    ' تنفّذ كل خطوات الترحيل (Delete القديم + Insert الجديد + تحديث الأسعار + المرفقات + الإشعارات)
    ' داخل Transaction واحدة.
    Private Function PostDocumentWithTransaction(ctx As DocumentContext,
                                             hasAttachment As Boolean) As Boolean
        Dim connString As String = My.Settings.TrueTimeConnectionString

        Using cn As New SqlConnection(connString)
            cn.Open()

            Dim tran As SqlTransaction = cn.BeginTransaction()

            Try
                '--------------------------------------------
                ' 1) إذا كان تعديل → حذف السند القديم من اليومية
                '--------------------------------------------
                If ctx.DocID > 0 Then
                    If Not DeleteFromJournalTx2(cn, tran,
                                           ctx.DocNameID,
                                           ctx.DocID,
                                           ctx.ModifiedDateTime) Then
                        Throw New Exception("فشل حذف السند القديم من اليومية.")
                    End If
                End If

                '--------------------------------------------
                ' 2) إذا كان جديد → الحصول على DocID داخل نفس الاتصال/الترا نزكشن
                '--------------------------------------------
                If ctx.DocID = 0 Then
                    Dim newDocId As Integer = GetDocNo(Me.DocName.EditValue, False)

                    ' لو الدالة رجعت 0 (أو رقم غير صحيح) نوقف العملية داخل الـ Transaction
                    If newDocId <= 0 Then
                        Throw New Exception("فشل في الحصول على رقم للفاتورة.")
                    End If

                    ctx.DocID = newDocId
                End If



                '--------------------------------------------
                ' 3) لو يوجد مرفقات → تحديث JournalTemp قبل الترحيل
                '--------------------------------------------
                If hasAttachment Then
                    If Not UpdateJournalTempBeforePostToJournalTx(cn, tran, ctx.DocCode) Then
                        Throw New Exception("فشل تحديث حقل HasAttachment في JournalTemp.")
                    End If
                End If


                '--------------------------------------------
                ' 4) ترحيل من JournalTemp إلى جدول اليومية الفعلي
                '--------------------------------------------

                If Not InsertDataFromTempToJournalTx(cn, tran,
                                                 ctx.DocDataTableName,
                                                 ctx.DocID,
                                                 ctx.DocCode) Then
                    Throw New Exception("فشل ترحيل البيانات من JournalTemp إلى " & ctx.DocDataTableName)
                End If

                '--------------------------------------------
                ' 5) تحديث Serial Numbers إن كانت مفعلة
                '--------------------------------------------
                If GlobalVariables._UseSerials Then
                    Dim refNo As Integer = If(String.IsNullOrWhiteSpace(Referance.Text),
                              0,
                              CInt(Referance.EditValue))
                    If Not UpdateInsertSerialTx(cn, tran, ctx.DocCode, refNo, ctx.DocNameID, GlobalVariables.CurrUser) Then
                        Throw New Exception("Error in UpdateInsertSerialTx.")
                    End If
                End If


                '--------------------------------------------
                ' 6) تحديث أسعار المشتريات لسندات المشتريات فقط (1,17 مثلاً)
                '--------------------------------------------
                If ctx.DocNameID = 1 OrElse ctx.DocNameID = 17 Then
                    If Not ChangePurchasePricesTx(cn, tran, ctx.DocCode) Then
                        Throw New Exception("Error in ChangePurchasePricesTx.")
                    End If
                End If


                '--------------------------------------------
                ' 7) حذف البيانات من JournalTemp بعد نجاح الترحيل
                '--------------------------------------------
                ' مثال داخل Using tran
                If Not DeleteFromJournalTempTx(cn, tran,
                               ctx.DocNameID,
                               ctx.DocCode,
                               GlobalVariables.CurrUser) Then
                    Throw New Exception("Error deleting from JournalTemp.")
                End If


                '--------------------------------------------
                ' 8) نجاح كامل → COMMIT
                '--------------------------------------------
                tran.Commit()
                Return True

            Catch ex As Exception
                ' أي خطأ → Rollback
                Try
                    tran.Rollback()
                Catch
                    ' في حالات نادرة قد يفشل الـ Rollback أيضاً
                End Try

                XtraMessageBox.Show("فشل عملية الترحيل داخل Transaction:" & vbCrLf &
                                ex.Message,
                                "خطأ في الترحيل",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error)
                Return False
            End Try
        End Using
    End Function

    Public Function DeleteFromJournalTempTx(cn As SqlConnection,
                                        tran As SqlTransaction,
                                        docName As Integer,
                                        docCode As String,
                                        currentUserId As Integer) As Boolean
        Const sql As String =
        "DELETE FROM JournalTemp " & vbCrLf &
        "WHERE DocName = @DocName " & vbCrLf &
        "  AND DocCode = @DocCode " & vbCrLf &
        "  AND CurrentUserID = @CurrentUserID;"

        Try
            Using cmd As New SqlCommand(sql, cn, tran)
                cmd.CommandTimeout = 600
                cmd.Parameters.Add("@DocName", SqlDbType.Int).Value = docName
                cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode
                cmd.Parameters.Add("@CurrentUserID", SqlDbType.Int).Value = currentUserId
                cmd.ExecuteNonQuery()
            End Using

            Return True
        Catch
            Return False
        End Try
    End Function


    Private Function DeleteFromJournalTx2(cn As SqlConnection,
                                     tran As SqlTransaction,
                                     docName As Integer,
                                     docId As Integer,
                                     modifiedDateTime As String) As Boolean
        Try
            '---------------------------------------------------------
            ' Case 10 & 11 → OrdersJournal only
            '---------------------------------------------------------
            If docName = 10 OrElse docName = 11 Then

                Const sqlOrders As String =
                "DELETE FROM dbo.OrdersJournal WHERE DocName = @DocName AND DocID = @DocID;"

                Using cmd As New SqlCommand(sqlOrders, cn, tran)
                    cmd.Parameters.Add("@DocName", SqlDbType.Int).Value = docName
                    cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = docId
                    cmd.ExecuteNonQuery()
                End Using

                Return True
            End If

            '---------------------------------------------------------
            ' Normalize ModifiedDateTime
            '---------------------------------------------------------
            Dim modDT As String =
            If(String.IsNullOrWhiteSpace(modifiedDateTime),
               DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
               modifiedDateTime)

            '---------------------------------------------------------
            ' 1) Backup to JournalBeforeUpdate
            '---------------------------------------------------------
            Const sqlBackup As String =
"
INSERT INTO JournalBeforeUpdate (
    ID, DocID, DocDate, DocName, DocStatus, DebitAcc, CredAcc,
    AccountCurr, DocCurrency, DocAmount, ExchangePrice,
    BaseCurrAmount, BaseAmount,
    DocManualNo, DocNotes, InputUser, InputDateTime, ModifiedDateTime,
    StockID, StockUnit, StockQuantity, BonusQuantity,
    StockQuantityByMainUnit, BonusQuantityByMainUnit, StockPrice,
    StockDebitWhereHouse, StockCreditWhereHouse, CurrentUserID,
    Referance, ReferanceName, ItemName, DocCostCenter, DocCode,
    OrderStatus, LastDocCode, LastDataName, StockBarcode,
    DeliverDate, Color, Measure, StockDiscount, VoucherDiscount,
    ItemVAT, StockDebitShelve, StockCreditShelve, DocNoteByAccount,
    SalesPerson, DeviceName, ItemNo2, OrderID, DocTags,
    StockWidth, StockLength, StockCount, ItemVATPercentage,TaxDate
)
SELECT 
    ID, DocID, DocDate, DocName, DocStatus, DebitAcc, CredAcc,
    AccountCurr, DocCurrency, DocAmount, ExchangePrice,
    BaseCurrAmount, BaseAmount,
    DocManualNo, DocNotes, InputUser, InputDateTime, @ModifiedDateTime,
    StockID, StockUnit, StockQuantity, BonusQuantity,
    StockQuantityByMainUnit, BonusQuantityByMainUnit, StockPrice,
    StockDebitWhereHouse, StockCreditWhereHouse, CurrentUserID,
    Referance, ReferanceName, ItemName, DocCostCenter, DocCode,
    OrderStatus, LastDocCode, LastDataName, StockBarcode,
    DeliverDate, Color, Measure, StockDiscount, VoucherDiscount,
    ItemVAT, StockDebitShelve, StockCreditShelve, DocNoteByAccount,
    SalesPerson, DeviceName, ItemNo2, OrderID, DocTags,
    StockWidth, StockLength, StockCount, ItemVATPercentage,TaxDate
FROM Journal
WHERE DocName = @DocName AND DocID = @DocID;
"

            Using cmd As New SqlCommand(sqlBackup, cn, tran)
                cmd.Parameters.Add("@DocName", SqlDbType.Int).Value = docName
                cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = docId
                cmd.Parameters.Add("@ModifiedDateTime", SqlDbType.VarChar, 50).Value = modDT

                Dim rows = cmd.ExecuteNonQuery()
                If rows = 0 Then
                    ' No journal rows → cannot continue deleting
                    Return False
                End If
            End Using

            '---------------------------------------------------------
            ' 2) Delete from Journal
            '---------------------------------------------------------
            Const sqlDelJournal As String =
            "DELETE FROM dbo.Journal WHERE DocName = @DocName AND DocID = @DocID;"

            Using cmd As New SqlCommand(sqlDelJournal, cn, tran)
                cmd.Parameters.Add("@DocName", SqlDbType.Int).Value = docName
                cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = docId
                cmd.ExecuteNonQuery()
            End Using

            '---------------------------------------------------------
            ' 3) Delete from Checks table
            '---------------------------------------------------------
            Const sqlDelChecks As String =
            "DELETE FROM dbo.Checks 
             WHERE DocName = @DocName AND DocID = @DocID AND TransNoInJournal = 1;"

            Using cmd As New SqlCommand(sqlDelChecks, cn, tran)
                cmd.Parameters.Add("@DocName", SqlDbType.Int).Value = docName
                cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = docId
                cmd.ExecuteNonQuery()
            End Using

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function InsertDataFromTempToJournalTx(cn As SqlConnection,
                                               tran As SqlTransaction,
                                               targetTable As String,
                                               docId As Integer,
                                               docCode As String) As Boolean
        ' الفكرة: نفس منطق InsertDataFromTempToJournal القديم 
        ' لكن نحقنه داخل نفس cn, tran

        Dim sql As String =
        "INSERT INTO " & targetTable & " ( " & vbCrLf &
        "    DocID, DocDate, DocName, DocStatus, DocCostCenter, " & vbCrLf &
        "    DebitAcc, CredAcc, AccountCurr, DocCurrency, DocAmount, " & vbCrLf &
        "    ExchangePrice, BaseCurrAmount, BaseAmount, DocSort, Referance, " & vbCrLf &
        "    DocManualNo, DocMultiCurrency, InputUser, InputDateTime, ModifiedUser, " & vbCrLf &
        "    ModifiedDateTime, DocAuditDate, DocAuditUser, DocNotes, StockID, " & vbCrLf &
        "    StockUnit, StockQuantity, StockQuantityByMainUnit, StockPrice, StockItemPrice, " & vbCrLf &
        "    StockDebitWhereHouse, StockCreditWhereHouse, StockDriver, StockCarNo, SalesPerson, " & vbCrLf &
        "    CheckNo, CheckInOut, CheckStatus, CheckDueDate, CheckCustBank, CheckCustBranch, " & vbCrLf &
        "    CheckCustAccountId, AccountBank, DeleteUser, DeleteDateTime, CurrentUserID, " & vbCrLf &
        "    ReferanceName, DocCode, CheckCode, ItemName, DocCheckTransID, TransNoInJournal, " & vbCrLf &
        "    ShiftID, DocNoteByAccount, StockDiscount, StockBarcode, PosNo, DeviceName, " & vbCrLf &
        "    OrderStatus, ItemStatus, ApprovedQuantity, LastDocCode, LastDataName, DeliverDate, " & vbCrLf &
        "    Color, Measure, VoucherDiscount, ItemVAT, StockDebitShelve, StockCreditShelve, " & vbCrLf &
        "    ItemNo2, OrderID, Produced, DocID2, DocDueDate, LastPurchasePrice, BatchID, " & vbCrLf &
        "    BatchNo, PaidStatus, PaidAmount, PaidByDocID, TarteebID, DocTags, " & vbCrLf &
        "    POSVoucherPayType, HasAttachment, BonusQuantity, BonusQuantityByMainUnit, " & vbCrLf &
        "    OldTransID, TableID, DispatchQuantity, DispatchStockQuantityByMainUnit, " & vbCrLf &
        "    DispatchVoucherID, SubAccount, CashCustomerId, BaseItemPrice, StockWidth, " & vbCrLf &
        "    StockLength, StockCount, StockThickness, StockDivision, IsVAT, ItemVATPercentage,TaxDate " & vbCrLf &
        ") " & vbCrLf &
        "SELECT " & vbCrLf &
        "    @DocID AS DocID, DocDate, DocName, 1, DocCostCenter, " & vbCrLf &
        "    DebitAcc, CredAcc, AccountCurr, DocCurrency, DocAmount, " & vbCrLf &
        "    ExchangePrice, BaseCurrAmount, BaseAmount, DocSort, Referance, " & vbCrLf &
        "    DocManualNo, DocMultiCurrency, InputUser, InputDateTime, ModifiedUser, " & vbCrLf &
        "    ModifiedDateTime, DocAuditDate, DocAuditUser, DocNotes, StockID, " & vbCrLf &
        "    StockUnit, StockQuantity, StockQuantityByMainUnit, StockPrice, StockItemPrice, " & vbCrLf &
        "    StockDebitWhereHouse, StockCreditWhereHouse, StockDriver, StockCarNo, SalesPerson, " & vbCrLf &
        "    CheckNo, CheckInOut, CheckStatus, CheckDueDate, CheckCustBank, CheckCustBranch, " & vbCrLf &
        "    CheckCustAccountId, AccountBank, DeleteUser, DeleteDateTime, CurrentUserID, " & vbCrLf &
        "    ReferanceName, DocCode, CheckCode, ItemName, DocCheckTransID, TransNoInJournal, " & vbCrLf &
        "    ShiftID, DocNoteByAccount, StockDiscount, StockBarcode, PosNo, DeviceName, " & vbCrLf &
        "    OrderStatus, ItemStatus, ApprovedQuantity, LastDocCode, LastDataName, DeliverDate, " & vbCrLf &
        "    Color, Measure, VoucherDiscount, ItemVAT, StockDebitShelve, StockCreditShelve, " & vbCrLf &
        "    ItemNo2, OrderID, Produced, DocID2, DocDueDate, LastPurchasePrice, BatchID, " & vbCrLf &
        "    BatchNo, PaidStatus, PaidAmount, PaidByDocID, TarteebID, DocTags, " & vbCrLf &
        "    POSVoucherPayType, HasAttachment, BonusQuantity, BonusQuantityByMainUnit, " & vbCrLf &
        "    OldTransID, TableID, DispatchQuantity, DispatchStockQuantityByMainUnit, " & vbCrLf &
        "    DispatchVoucherID, SubAccount, CashCustomerId, BaseItemPrice, StockWidth, " & vbCrLf &
        "    StockLength, StockCount, StockThickness, StockDivision, IsVAT, ItemVATPercentage,TaxDate " & vbCrLf &
        "FROM dbo.JournalTemp " & vbCrLf &
        "WHERE DocCode = @DocCode;"

        Using cmd As New SqlCommand(sql, cn, tran)
            cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = docId
            cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode
            Dim affected As Integer = cmd.ExecuteNonQuery()
            Return (affected > 0)
        End Using
    End Function

    Private Function UpdateJournalTempBeforePostToJournalTx(cn As SqlConnection,
                                                        tran As SqlTransaction,
                                                        docCode As String) As Boolean
        Const sql As String = "
        UPDATE [JournalTemp]
        SET [HasAttachment] = 1
        WHERE [DocCode] = @DocCode;
    "

        Using cmd As New SqlCommand(sql, cn, tran)
            cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode
            Dim affected As Integer = cmd.ExecuteNonQuery()
            ' يمكنك إرجاع True حتى لو لم يتم تحديث أي صف، أو تشترط affected > 0 حسب منطقك
            Return True
        End Using
    End Function

    Private Function UpdateInsertSerialTx(cn As SqlConnection,
                                      tran As SqlTransaction,
                                      docCode As String,
                                      referance As Integer,
                                      docNameId As Integer,
                                      userNo As Integer) As Boolean

        Dim sb As New StringBuilder()

        ' 1) Insert new serials from temp to ItemsSerials
        sb.AppendLine("INSERT INTO ItemsSerials")
        sb.AppendLine("    ([SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],")
        sb.AppendLine("     [SaleWarrantyStart],[SaleWarrantyEnd],[ItemNo],[DocCode],CurrentWahreHouse,vendor)")
        sb.AppendLine("SELECT [SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],")
        sb.AppendLine("       [SaleWarrantyStart],[SaleWarrantyEnd],[ItemNo],[DocCode], SerialDebitWhereHouse,")
        sb.AppendLine("       @Referance")
        sb.AppendLine("FROM ItemsSerialTransTemp tt")
        sb.AppendLine("WHERE tt.DocCode = @DocCode")
        sb.AppendLine("  AND tt.TempTransType = 'New'")
        sb.AppendLine("  AND DocName IN (1,17);")

        ' 2) Insert into ItemsSerialTrans
        sb.AppendLine("INSERT INTO [ItemsSerialTrans]")
        sb.AppendLine("    ([SerialNumber],[DocCode],[ItemNo],[SerialID],")
        sb.AppendLine("     [SerialDebitWhereHouse],[SerialCreditWhereHouse],[DocName],[DocDate],")
        sb.AppendLine("     [AddedDate],[AddedUser],[Notes],[DocNo],ReferanceNo)")
        sb.AppendLine("SELECT [SerialNumber],[DocCode],[ItemNo],[SerialID],")
        sb.AppendLine("       [SerialDebitWhereHouse],[SerialCreditWhereHouse],[DocName],[DocDate],")
        sb.AppendLine("       [AddedDate],[AddedUser],[Notes],[DocNo],")
        sb.AppendLine("       @Referance")
        sb.AppendLine("FROM [ItemsSerialTransTemp] tt")
        sb.AppendLine("WHERE tt.DocCode = @DocCode")
        sb.AppendLine("  AND tt.TempTransType = 'New';")

        ' 3) Update ItemsSerials from temp
        sb.AppendLine("UPDATE  S")
        sb.AppendLine("SET     S.SerialStatus            = tt.SerialStatus,")
        sb.AppendLine("        S.SaleWarrantyStart       = tt.SaleWarrantyStart,")
        sb.AppendLine("        S.SaleWarrantyEnd         = tt.SaleWarrantyEnd,")
        sb.AppendLine("        S.PurchaseWarrantyStart   = tt.PurchaseWarrantyStart,")
        sb.AppendLine("        S.PurchaseWarrantyEnd     = tt.PurchaseWarrantyEnd,")
        sb.AppendLine("        S.CurrentWahreHouse = CASE")
        sb.AppendLine("              WHEN DocName IN (1,17,16) AND S.[SerialStatus] = 1 THEN SerialDebitWhereHouse")
        sb.AppendLine("              WHEN tt.TempTransType = 'Delete' AND DocName = 2 THEN SerialDebitWhereHouse")
        sb.AppendLine("              ELSE SerialCreditWhereHouse")
        sb.AppendLine("          END")

        ' Vendor update (for purchase docs 1,17)
        If docNameId = 1 OrElse docNameId = 17 Then
            sb.AppendLine("      , S.Vendor = CASE")
            sb.AppendLine("              WHEN DocName IN (1,17) THEN @Referance")
            sb.AppendLine("          END")
        End If

        ' Customer update (for sales docs 2,18)
        If docNameId = 2 OrElse docNameId = 18 Then
            sb.AppendLine("      , S.Customer = CASE")
            sb.AppendLine("              WHEN DocName IN (2,18) AND tt.TempTransType IN ('Update','New') THEN @Referance")
            sb.AppendLine("              WHEN DocName IN (2,18) AND tt.TempTransType = 'Delete' THEN NULL")
            sb.AppendLine("          END")
        End If

        sb.AppendLine("FROM [dbo].[ItemsSerials] S")
        sb.AppendLine("INNER JOIN [dbo].[ItemsSerialTransTemp] tt")
        sb.AppendLine("    ON S.SerialNumber = tt.SerialNumber")
        sb.AppendLine("   AND S.ItemNo       = tt.ItemNo")

        If docNameId = 1 OrElse docNameId = 17 Then
            sb.AppendLine("WHERE tt.TempTransType = 'Update'")
            sb.AppendLine("  AND tt.DocCode = @DocCode;")
        ElseIf docNameId = 2 OrElse docNameId = 18 OrElse docNameId = 16 Then
            sb.AppendLine("WHERE tt.DocCode = @DocCode;")
        End If

        ' 4) Update ItemsSerialTrans from temp
        sb.AppendLine("UPDATE  T")
        sb.AppendLine("SET     T.SerialDebitWhereHouse   = tt.SerialDebitWhereHouse,")
        sb.AppendLine("        T.SerialCreditWhereHouse  = tt.SerialCreditWhereHouse,")
        sb.AppendLine("        T.DocDate                 = tt.DocDate,")
        sb.AppendLine("        T.ReferanceNo             = @Referance")
        sb.AppendLine("FROM [dbo].ItemsSerialTrans T")
        sb.AppendLine("INNER JOIN [dbo].[ItemsSerialTransTemp] tt")
        sb.AppendLine("    ON T.SerialNumber = tt.SerialNumber")
        sb.AppendLine("   AND T.ItemNo       = tt.ItemNo")
        sb.AppendLine("WHERE tt.TempTransType = 'Update'")
        sb.AppendLine("  AND tt.DocCode = @DocCode;")

        ' 5) Delete from ItemsSerials for delete operations (purchase docs 1,17)
        sb.AppendLine("DELETE  S")
        sb.AppendLine("FROM    [dbo].ItemsSerials S")
        sb.AppendLine("INNER JOIN [dbo].[ItemsSerialTransTemp] tt")
        sb.AppendLine("    ON S.ID = tt.IDInSerials")
        sb.AppendLine("WHERE tt.TempTransType = 'Delete'")
        sb.AppendLine("  AND tt.DocCode = @DocCode")
        sb.AppendLine("  AND DocName IN (1,17);")

        ' 6) Delete from ItemsSerialTrans for delete operations
        sb.AppendLine("DELETE  T")
        sb.AppendLine("FROM    [dbo].[ItemsSerialTrans] T")
        sb.AppendLine("INNER JOIN [dbo].[ItemsSerialTransTemp] tt")
        sb.AppendLine("    ON T.TransID = tt.TransIDInSerialTrans")
        sb.AppendLine("WHERE tt.TempTransType = 'Delete'")
        sb.AppendLine("  AND tt.DocCode = @DocCode;")

        ' 7) Clean temp table by user + doc
        sb.AppendLine("DELETE TT")
        sb.AppendLine("FROM ItemsSerialTransTemp TT")
        sb.AppendLine("WHERE TT.UserNo = @UserNo")
        sb.AppendLine("  AND TT.DocCode = @DocCode;")

        Using cmd As New SqlCommand(sb.ToString(), cn, tran)
            cmd.CommandTimeout = 600
            cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode
            cmd.Parameters.Add("@Referance", SqlDbType.Int).Value = referance
            cmd.Parameters.Add("@UserNo", SqlDbType.Int).Value = userNo

            cmd.ExecuteNonQuery()
            Return True
        End Using

    End Function

    Private Function ChangePurchasePricesTx(cn As SqlConnection,
                                        tran As SqlTransaction,
                                        docCode As String) As Boolean
        Dim sb As New StringBuilder()

        ' نفس المعادلة التي استخدمتها، لكن بشكل منسق وباستخدام Parameter
        sb.AppendLine("UPDATE I")
        sb.AppendLine("SET")
        sb.AppendLine("    I.LastPurchasePrice = ")
        sb.AppendLine("        (")
        sb.AppendLine("            (CASE")
        sb.AppendLine("                WHEN J.DocAmount > 0 THEN J.BaseCurrAmount / J.DocAmount")
        sb.AppendLine("                ELSE J.BaseCurrAmount")
        sb.AppendLine("             END) * J.StockPrice")
        sb.AppendLine("        ) / (J.StockQuantityByMainUnit / J.StockQuantity),")
        sb.AppendLine("    I.LastPurchaseDate = J.DocDate")
        sb.AppendLine("FROM JournalTemp AS J")
        sb.AppendLine("INNER JOIN Items AS I ON J.StockID = I.ItemNo")
        sb.AppendLine("WHERE J.DocCode = @DocCode")
        sb.AppendLine("  AND J.StockPrice <> 0;")

        Using cmd As New SqlCommand(sb.ToString(), cn, tran)
            cmd.CommandTimeout = 600
            cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode
            cmd.ExecuteNonQuery()
        End Using

        Return True
    End Function

    Private Sub ShowAfterSaveActions(ctx As DocumentContext)

        Dim F As New SavePrintPostDocument()
        With F
            .DocAmount = Me.TextTotalDocAmount.EditValue
            .DocName = ctx.DocNameID

            If Me.Referance.Text <> "" Then
                .Referance = Me.Referance.Text
            Else
                .Referance = "0"
            End If

            .TextDocCode.Text = ctx.DocCode

            ' هل نرسل إلى مكتب اليومية أم دفتر الطلبات؟
            If ctx.DocNameID = 1 Or ctx.DocNameID = 2 Or ctx.DocNameID = 12 Or ctx.DocNameID = 13 _
            Or ctx.DocNameID = 17 Or ctx.DocNameID = 18 Or ctx.DocNameID = 8 Or ctx.DocNameID = 9 Or ctx.DocNameID = 16 Then

                .TextDocData.Text = "Journal"
                .LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            ElseIf ctx.DocNameID = 11 Or ctx.DocNameID = 10 Then
                .TextDocData.Text = "OrdersJournal"
                .LayoutSendDocumentByWhatsApp.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If

            ' زر إصدار سند القبض أو الصرف بعد الحفظ
            If ctx.DocNameID = 1 Then
                .BtnIssueReceiptOrPayment.Text = "9- اصدار سند صرف"
                .LayoutControlPayOrRec.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If

            If ctx.DocNameID = 2 Then
                .BtnIssueReceiptOrPayment.Text = "9- اصدار سند قبض"
                .LayoutControlPayOrRec.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            End If

            .ShowDialog()
        End With

    End Sub


    Private Sub FillStockDimensions(row As DataRow, grid As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer)
        Dim width = grid.GetRowCellValue(i, "StockWidth")
        Dim length = grid.GetRowCellValue(i, "StockLength")
        Dim countVal = grid.GetRowCellValue(i, "StockCount")
        Dim thicknessVal = grid.GetRowCellValue(i, "StockThickness")
        Dim divisionVal = grid.GetRowCellValue(i, "StockDivision")

        row("StockWidth") = If(width Is Nothing OrElse IsDBNull(width), 0D, Convert.ToDecimal(width))
        row("StockLength") = If(length Is Nothing OrElse IsDBNull(length), 0D, Convert.ToDecimal(length))
        row("StockCount") = If(countVal Is Nothing OrElse IsDBNull(countVal), 0D, Convert.ToDecimal(countVal))
        row("StockThickness") = If(thicknessVal Is Nothing OrElse IsDBNull(thicknessVal), 0D, Convert.ToDecimal(thicknessVal))
        row("StockDivision") = If(divisionVal Is Nothing OrElse IsDBNull(divisionVal), 0D, Convert.ToDecimal(divisionVal))
    End Sub

    Private Sub FillShelves(row As DataRow, grid As DevExpress.XtraGrid.Views.Grid.GridView, i As Integer)
        Dim debitShelve = grid.GetRowCellValue(i, "StockDebitShelve")
        If debitShelve IsNot Nothing AndAlso Not IsDBNull(debitShelve) Then
            Dim v = debitShelve.ToString()
            row("StockDebitShelve") = If(String.IsNullOrEmpty(v), 0, CInt(v))
        End If

        Dim creditShelve = grid.GetRowCellValue(i, "StockCreditShelve")
        If creditShelve IsNot Nothing AndAlso Not IsDBNull(creditShelve) Then
            Dim v = creditShelve.ToString()
            row("StockCreditShelve") = If(String.IsNullOrEmpty(v), 0, CInt(v))
        End If
    End Sub

    Private Sub FillPaymentAndPosInfo(row As DataRow,
                                  paidStatus As Integer,
                                  paidAmount As Decimal,
                                  paidByDocId As Integer,
                                  posNo As Integer,
                                  shiftId As Integer,
                                  docId2 As Integer,
                                  docTags As String,
                                  driverText As String,
                                  carNoText As String)

        row("PaidStatus") = paidStatus
        row("PaidAmount") = CInt(paidAmount)   ' في SQL هو int
        row("PaidByDocID") = paidByDocId
        row("PosNo") = posNo
        row("ShiftID") = shiftId
        row("DocID2") = docId2
        row("DocTags") = docTags
        row("StockDriver") = driverText
        row("StockCarNo") = carNoText
    End Sub

    Private Sub FillCommonDocFields(row As DataRow,
                                docStatus As Integer,
                                inputUser As Integer,
                                deviceName As String,
                                inputDateTime As String,
                                modifiedDateTime As String,
                                orderStatus As Integer)

        row("DocID") = 0
        row("DocDate") = DocDate.DateTime.Date
        row("TaxDate") = TaxDate.DateTime.Date
        row("DocName") = CInt(Me.DocName.EditValue)
        row("DocStatus") = docStatus

        ' يضبط لاحقاً في الكيس حسب نوع السند
        row("DocCostCenter") = 0

        row("DocSort") = 0
        row("Referance") = If(String.IsNullOrWhiteSpace(Me.Referance.Text), "", Me.Referance.Text)
        row("DocManualNo") = Me.DocManualNo.Text

        row("DocMultiCurrency") = False

        row("InputUser") = inputUser
        row("InputDateTime") = DateTime.Parse(inputDateTime)
        row("ModifiedUser") = GlobalVariables.CurrUser
        row("ModifiedDateTime") = DateTime.Parse(modifiedDateTime)

        row("DocAuditDate") = DBNull.Value
        row("DocAuditUser") = DBNull.Value

        row("DocNotes") = Me.DocNotes.Text
        row("CurrentUserID") = GlobalVariables.CurrUser

        row("DocCode") = Me.DocCode.Text
        row("DeviceName") = deviceName

        row("OrderStatus") = orderStatus

        ' اختياري: لو أردت تعبئته من الآن
        ' row("HasAttachment") = CheckIfDocumentHasAttachment(Me.DocCode.Text)
    End Sub

    Private Function ValidateBeforeSave() As Boolean

        ' إيقاف الحفظ إذا كانت حالة السند لا تسمح
        Dim docStatusValue As Integer
        If Me.DocStatus.EditValue IsNot Nothing AndAlso
       Integer.TryParse(Me.DocStatus.EditValue.ToString(), docStatusValue) Then

            If docStatusValue = -2 OrElse docStatusValue = 3 Then
                Return False
            End If
        End If

        GridView1.ClearFindFilter()
        GridView1.ClearColumnsFilter()

        ' التحقق من وجود اصناف (أي سطر فيه كمية أو بونص)
        Dim hasItems As Boolean = False

        For i As Integer = 0 To GridView1.RowCount - 1
            Dim stockQtyObj = GridView1.GetRowCellValue(i, "StockQuantity")
            Dim bonusQtyObj = GridView1.GetRowCellValue(i, "BonusQuantity")

            Dim qty As Decimal = 0D
            Dim bonus As Decimal = 0D

            If stockQtyObj IsNot Nothing AndAlso Not IsDBNull(stockQtyObj) Then
                Decimal.TryParse(stockQtyObj.ToString(), qty)
            End If

            If bonusQtyObj IsNot Nothing AndAlso Not IsDBNull(bonusQtyObj) Then
                Decimal.TryParse(bonusQtyObj.ToString(), bonus)
            End If

            If qty <> 0D OrElse bonus <> 0D Then
                hasItems = True
                Exit For
            End If
        Next

        If Not hasItems Then
            XtraMessageBox.Show("لا يوجد اصناف بالفاتورة")
            Return False
        End If

        ' رقم السند
        If String.IsNullOrEmpty(DocID.Text) Then
            XtraMessageBox.Show("رقم السند فارغ")
            Return False
        End If

        ' حساب الذمة/الطرف المقابل (ما عدا الارسالية الداخلية رقم 16)
        Dim docNameValue As Integer = Convert.ToInt32(Me.DocName.EditValue)

        If docNameValue <> 16 Then
            If AccountForRefranace.Text = "0" OrElse String.IsNullOrEmpty(AccountForRefranace.Text) Then
                XtraMessageBox.Show("لا يوجد حساب بالفاتورة")
                Return False
            End If
        End If

        ' التحقق من مركز التكلفة لحساب الذمة
        If GlobalVariables._CostCenterRequired Then

            ' فقط إذا كان هناك ذمة حقيقية (ليست فارغة أو 0)
            If Not String.IsNullOrEmpty(Referance.Text) AndAlso Referance.Text <> "0" Then
                If String.IsNullOrEmpty(LookCostCenter.Text) Then
                    If docNameValue = 1 OrElse
                   docNameValue = 2 OrElse
                   docNameValue = 12 OrElse
                   docNameValue = 13 Then

                        Dim accountId As String = GetRefranceData(Referance.EditValue).RefAccID
                        Dim account As New FinancialAccount()

                        If account.GetAccountData(accountId) AndAlso account.NeedCostCenter Then
                            XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                            Return False
                        End If
                    End If
                End If
            End If
        End If

        ' تاريخ السند أكبر من اليوم
        If DocDate.DateTime > Today Then
            If XtraMessageBox.Show("تاريخ السند اكبر من تاريخ اليوم، هل تريد الاستمرار؟",
                               "Confirmation",
                               MessageBoxButtons.YesNo) = DialogResult.No Then
                Return False
            End If
        End If

        ' الفاتورة مسددة مسبقاً
        Dim paidStatus As Integer
        If Integer.TryParse(Me.BarPaidStatus.Caption, paidStatus) AndAlso paidStatus = 2 Then
            If XtraMessageBox.Show("الفاتورة مسددة هل تريد الاستمرار؟",
                               "Confirmation",
                               MessageBoxButtons.YesNo) = DialogResult.No Then
                Return False
            End If
        End If

        ' التحقق من المستودع في بعض الحركات
        Select Case docNameValue
            Case 2, 9, 11
                If IsNothing(StockCreditWhereHouse.EditValue) Then
                    MsgBoxShowError(" يجب اختيار مستودع ")
                    Return False
                End If
        End Select

        ' التحقق من وجود ذمة
        If String.IsNullOrEmpty(TextReferanceName.Text) Then

            If docNameValue = 1 OrElse
           docNameValue = 2 OrElse
           docNameValue = 12 OrElse
           docNameValue = 13 Then

                If XtraMessageBox.Show(" لا يوجد ذمة بالسند ، سيتم اعتبار الفاتورة نقدية، هل تريد الاستمرار ",
                                   "Confirmation",
                                   MessageBoxButtons.YesNo) = DialogResult.No Then
                    Return False
                End If

            ElseIf docNameValue = 8 OrElse docNameValue = 9 Then
                MsgBoxShowError(" لا يمكن حفظ الارسالية بدون ذمة ")
                Return False
            End If
        End If

        ' التحقق من أن الطلبية لم ترحل مسبقاً
        If (docNameValue = 11 OrElse docNameValue = 12) AndAlso CheckIfOrderIsVoucherd() Then
            LayoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Return False
        End If

        ' إذا وصلنا هنا، جميع الشروط صحيحة
        Return True

    End Function

    ''' فحص توازن القيد
    ''' <returns>True إذا كان القيد متوازن، False إذا غير متوازن</returns>
    Private Function ValidateJournalBalancedInDb(docCode As String,
                                             Optional tolerance As Decimal = 0.01D) As Boolean

        Const sql As String =
        "SELECT " & vbCrLf &
        "    DebitTotal = ISNULL(SUM( " &
        "        CASE " &
        "            WHEN LTRIM(RTRIM(ISNULL(DebitAcc, ''))) <> '' " &
        "                 AND LTRIM(RTRIM(ISNULL(DebitAcc, ''))) <> '0' " &
        "            THEN CAST(BaseCurrAmount AS decimal(18,4)) " &
        "            ELSE 0 " &
        "        END" &
        "    ), 0), " & vbCrLf &
        "    CreditTotal = ISNULL(SUM( " &
        "        CASE " &
        "            WHEN LTRIM(RTRIM(ISNULL(CredAcc, ''))) <> '' " &
        "                 AND LTRIM(RTRIM(ISNULL(CredAcc, ''))) <> '0' " &
        "            THEN CAST(BaseCurrAmount AS decimal(18,4)) " &
        "            ELSE 0 " &
        "        END" &
        "    ), 0) " & vbCrLf &
        "FROM dbo.JournalTemp " & vbCrLf &
        "WHERE DocCode = @DocCode;"

        Dim debitTotal As Decimal = 0D
        Dim creditTotal As Decimal = 0D

        Using cn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand(sql, cn)
                cmd.Parameters.Add("@DocCode", SqlDbType.VarChar, 50).Value = docCode

                cn.Open()
                Using rdr As SqlDataReader = cmd.ExecuteReader()
                    If rdr.Read() Then
                        ' ملاحظة: الحقول في الاستعلام CAST(decimal(18,4)) لذلك نستخدم GetDecimal
                        debitTotal = If(Not rdr.IsDBNull(0), rdr.GetDecimal(0), 0D)
                        creditTotal = If(Not rdr.IsDBNull(1), rdr.GetDecimal(1), 0D)
                    End If
                End Using
            End Using
        End Using

        Dim diff As Decimal = Math.Abs(debitTotal - creditTotal)

        If diff > tolerance Then
            Dim msg As String = String.Format(
            "القيد المحاسبي غير متوازن في JournalTemp للسند {0}:" & vbCrLf &
            "إجمالي المدين  : {1:N3}" & vbCrLf &
            "إجمالي الدائن : {2:N3}" & vbCrLf &
            "الفرق          : {3:N3}",
            docCode, debitTotal, creditTotal, diff)

            XtraMessageBox.Show(msg,
                            "خطأ في توازن القيد",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function


    Private Sub CreateNotification()
        'Select Case Me.DocName.EditValue
        '    Case 1
        '        Dim _Body As String = "تم اصدار فاتورة مشتريات"
        '        _Body += " علما ان رصيد المورد يشمل الفاتورة الحالية  " & Me.TextRefBalance.Text & " شيكل "
        '        Main.ToastNotificationsManager1.Notifications(1).Body = _Body
        '        Main.ToastNotificationsManager1.ShowNotification("303ceb91-8bf0-4d4a-8675-5524fce15aa4")
        '        '
        'End Select
        'With Me.AlertControl1
        '    '  .AppearanceCaption = "تم اصدار فاتورة مشتريات"
        '    .Show(Me)
        'End With
        'Me.AlertControl1.Show(Me)
    End Sub



    Private Sub UpdateInsertSerial()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _Referance As Integer
        If Not IsNothing(Referance.EditValue) Then
            _Referance = Referance.EditValue
        Else
            _Referance = 0
        End If
        SqlString = "Declare @DocCode Varchar(50)
	                            Set @DocCode='" & Me.DocCode.Text & "'
	                  Insert Into ItemsSerials 
		                            ([SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],
		                             [SaleWarrantyStart],[SaleWarrantyEnd],[ItemNo],[DocCode],CurrentWahreHouse,vendor)
		                             Select [SerialNumber],[SerialStatus],[PurchaseWarrantyStart],[PurchaseWarrantyEnd],
		                             [SaleWarrantyStart],[SaleWarrantyEnd],[ItemNo],[DocCode], SerialDebitWhereHouse,
                                     " & _Referance & "
		                             From ItemsSerialTransTemp tt
		                             Where tt.DocCode=@DocCode And tt.TempTransType='New' And DocName In (1,17);"
        SqlString += "Insert Into [ItemsSerialTrans] ( [SerialNumber],[DocCode],[ItemNo],[SerialID],
		                             [SerialDebitWhereHouse],[SerialCreditWhereHouse],[DocName],[DocDate],
		                             [AddedDate],[AddedUser],[Notes],[DocNo],ReferanceNo) 
		                             Select  [SerialNumber],[DocCode],[ItemNo],[SerialID],[SerialDebitWhereHouse],
		                             [SerialCreditWhereHouse],[DocName],[DocDate],[AddedDate],[AddedUser],[Notes],[DocNo],
                                     " & _Referance & "
        From [ItemsSerialTransTemp] tt
		                             Where tt.DocCode=@DocCode And tt.TempTransType='New';"
        SqlString += "Update S
		                             set S.SerialStatus  = tt.SerialStatus,
		                             S.SaleWarrantyStart=tt.SaleWarrantyStart,
		                             S.SaleWarrantyEnd = tt.SaleWarrantyEnd,
		                             S.PurchaseWarrantyStart = tt.PurchaseWarrantyStart,
		                             S.PurchaseWarrantyEnd = tt.PurchaseWarrantyEnd ,
                                     S.CurrentWahreHouse= Case When DocName in (1,17,16) And S.[SerialStatus]=1  then SerialDebitWhereHouse when  tt.TempTransType='Delete' and DocName=2 then SerialDebitWhereHouse else SerialCreditWhereHouse  End"
        If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 17 Then SqlString += " ,S.Vendor= Case When DocName in (1,17) then " & _Referance & "   End "
        If Me.DocName.EditValue = 2 Or Me.DocName.EditValue = 18 Then SqlString += " ,S.Customer= Case When DocName in (2,18) and tt.TempTransType in ('Update','New') then " & _Referance & "  When DocName in (2,18) and tt.TempTransType='Delete' then Null End   "
        SqlString += " 	             from [dbo].[ItemsSerials] S
		                             inner join [dbo].[ItemsSerialTransTemp] tt on     S.SerialNumber  = tt.SerialNumber and S.ItemNo=tt.ItemNo "
        If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 17 Then
            SqlString += "Where tt.TempTransType='Update' And tt.DocCode=@DocCode ;"
        ElseIf DocName.EditValue = 2 Or Me.DocName.EditValue = 18 Or Me.DocName.EditValue = 16 Then
            SqlString += "Where tt.DocCode=@DocCode ;"
        End If
        SqlString += "   "

        SqlString += "Update T
		                             set T.SerialDebitWhereHouse  = tt.SerialDebitWhereHouse,
		                             T.SerialCreditWhereHouse=tt.SerialCreditWhereHouse,
		                             T.DocDate = tt.DocDate,
                                     ReferanceNo=" & _Referance & "
		                             from [dbo].ItemsSerialTrans T
		                             inner join [dbo].[ItemsSerialTransTemp] tt on T.SerialNumber  = tt.SerialNumber and T.ItemNo=tt.ItemNo
		                             Where tt.TempTransType='Update' And tt.DocCode=@DocCode ;"
        SqlString += "DELETE S
		                             FROM [dbo].ItemsSerials S
		                             INNER JOIN [dbo].[ItemsSerialTransTemp] tt  ON S.ID=tt.IDInSerials
	                                 Where tt.TempTransType='Delete' And tt.DocCode=@DocCode  And DocName In (1,17) ;"
        SqlString += " DELETE T
		                             FROM [dbo].[ItemsSerialTrans] T
		                             INNER JOIN [dbo].[ItemsSerialTransTemp] tt  ON T.TransID=tt.TransIDInSerialTrans
	                                 Where tt.TempTransType='Delete' And tt.DocCode=@DocCode ;"
        SqlString += " Delete TT 
                                     From ItemsSerialTransTemp TT Where UserNo='" & GlobalVariables.CurrUser & "' 
                                     And DocCode = @DocCode"
        Sql.SqlTrueAccountingRunQuery(SqlString)






    End Sub
    Private Sub ChangePurchasePrices(_DocCode As String)
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "UPDATE Items " &
                                  "SET Items.LastPurchasePrice =         ((CASE 
            WHEN j.DocAmount > 0 THEN j.BaseCurrAmount / j.DocAmount 
            ELSE j.BaseCurrAmount 
         END) * j.StockPrice) 
        / (j.StockQuantityByMainUnit / j.StockQuantity) , " &
                                  "    Items.LastPurchaseDate = j.DocDate " &
                                  "FROM JournalTemp j " &
                                  "INNER JOIN Items ON j.StockID = Items.ItemNo " &
                                  "WHERE j.DocCode = '" & _DocCode & "' AND j.StockPrice <> 0"
            'Dim sqlString As String = "UPDATE Items " &
            '                      "SET Items.LastPurchasePrice = JournalTemp.StockPrice * JournalTemp.ExchangePrice , " &
            '                      "    Items.LastPurchaseDate = JournalTemp.DocDate " &
            '                      "FROM JournalTemp " &
            '                      "INNER JOIN Items ON JournalTemp.StockID = Items.ItemNo " &
            '                      "WHERE JournalTemp.DocCode = '" & _DocCode & "' AND JournalTemp.StockPrice <> 0"
            sql.SqlTrueAccountingRunQuery(sqlString)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChangePurchasePricesFromOrdersDocument(_DocCode As String)
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " update I
set I.LastPurchasePrice = O.StockPrice,I.LastPurchaseDate=O.DocDate
from [dbo].[Items] I
    inner join OrdersJournal O on I.ItemNo  = O.StockID 
    where   O.DocCode='" & _DocCode & "'  "
            sql.SqlTrueAccountingRunQuery(SqlString)
        Catch ex As Exception

        End Try
    End Sub

    Private Function GetBaseAmount(_AccountCurr As Integer, _DocAmount As Decimal) As Decimal
        Dim _BaseAmount As Decimal
        If _AccountCurr = DocCurrency.EditValue Then
            _BaseAmount = _DocAmount
        ElseIf _AccountCurr = _DefaultCurr And DocCurrency.EditValue = _DefaultCurr Then
            _BaseAmount = _DocAmount / GetExchengPrice(_AccountCurr, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        Else
            _BaseAmount = (_DocAmount * ExchangePrice.EditValue) / GetExchengPrice(_AccountCurr, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
        End If
        Return _BaseAmount
    End Function
    Private Sub CoptToClip(DT As DataTable)
        Dim ClipText As String = String.Empty
        For Each row As DataRow In DT.Rows
            Dim ClipRow As String = String.Empty
            ClipRow = String.Empty
            For Each col As DataColumn In DT.Columns
                If Not String.IsNullOrEmpty(ClipRow) Then
                    ClipRow += ControlChars.Tab
                End If

                ClipRow += row(col.ColumnName).ToString
            Next
            ClipText += ClipRow + ControlChars.NewLine
        Next
        Clipboard.SetText(ClipText)

    End Sub

    Private Sub GetItems()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " select ItemNo ,ItemName,ItemNo2,[ItemStatus],ItemNo3,ItemNo4 from Items where 1=1 "
            If GlobalVariables._ShowRowMaterialinVouchers = False And (Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 2) Then
                SqlString += " And classification=1 "
            End If
            SqlString += " Order by ItemNo "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            RepositoryItem.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show("لا يمكن تحميل الاصناف")
        End Try
    End Sub


    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        GridView1.UpdateTotalSummary()
        Me.TextTotalDocAmount.EditValue = colDocAmount.SummaryItem.SummaryValue
        Me.TextSumQuantity.EditValue = colStockQuantity.SummaryItem.SummaryValue
        Me.TextTotalTax.EditValue = CDec(ColItemVAT.SummaryItem.SummaryValue)



    End Sub


    Private edit As BaseEdit = Nothing
    Dim _FieldName As String

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.ShownEditor
        Dim view As ColumnView = DirectCast(sender, ColumnView)
        _FieldName = view.FocusedColumn.FieldName
        Dim view2 As GridView = TryCast(sender, GridView)
        edit = view2.ActiveEditor

        AddHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
        If view.FocusedColumn.FieldName = "StockUnit" Then
            Dim editor As SearchLookUpEdit = CType(view.ActiveEditor, SearchLookUpEdit)
            Dim _StockID As String = Convert.ToString(view.GetFocusedRowCellValue("StockID"))
            If _StockID = "" Then Exit Sub
            editor.Properties.DataSource = GetUnitsForItems(_StockID)
        End If

        'If view.FocusedColumn.FieldName = "BatchID" Then
        '    Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
        '    Dim _StockID As String = Convert.ToString(view.GetFocusedRowCellValue("StockID"))
        '    If _StockID = "" Then Exit Sub
        '    If CheckIfItemNeedBatch(_StockID) = True Then
        '        editor.Properties.DataSource = GetItemsBatchNoTable(_StockID)
        '        'Else
        '        '    editor.Properties.DataSource = Nothing
        '    End If
        'End If

        If view.FocusedColumn.FieldName = "StockCreditShelve" Then
            If GlobalVariables._WareHouseUseShelf = True Then
                Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
                editor.Properties.DataSource = GetShelves(Me.StockCreditWhereHouse.EditValue)
            End If
        End If


        If view.FocusedColumn.FieldName = "StockDebitShelve" Then
            If GlobalVariables._WareHouseUseShelf = True Then
                Dim editor As LookUpEdit = CType(view.ActiveEditor, LookUpEdit)
                editor.Properties.DataSource = GetShelves(Me.StockDebitWhereHouse.EditValue)
            End If
        End If

    End Sub
    Private Function GetUnitsForItems(ItemNo As Integer) As DataTable
        Dim _Units As New DataTable
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select unit_id as id,U.name as [name]  
                                            from [Items_units] IU 
                                            left join Units U on U.id=IU.unit_id 
                                            where item_id=" & ItemNo)
            _Units = sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Units
        End Try
        Return _Units
    End Function

    Private Function GetShelves(_WahreHouse As Integer) As DataTable
        Dim _Shelves As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select ShelfID,ShelfCode,WareHouseID From [dbo].[FinancialShelves] where WareHouseID=" & _WahreHouse
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Shelves = sql.SQLDS.Tables(0)
        Catch ex As Exception
            Return _Shelves
        End Try
        Return _Shelves
    End Function
    Private ReadOnly Property CurrentDocName As DocNameType
        Get
            If DocName.EditValue Is Nothing OrElse DocName.EditValue Is DBNull.Value Then
                Return DocNameType.Unknown
            End If

            Dim value As Integer
            If Not Integer.TryParse(DocName.EditValue.ToString(), value) Then
                Return DocNameType.Unknown
            End If

            Return CType(value, DocNameType)
        End Get
    End Property
    Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' تم اضافة هذه السطور لتجنب خطأ عند التعديل على الخلية ، حيث كان المبلغ بالفاتورة لا يكتب بطريقة صحيحة
        Dim editor As DevExpress.XtraEditors.BaseEdit = TryCast(sender, DevExpress.XtraEditors.BaseEdit)
        If editor Is Nothing Then Exit Sub

        ' Only try to access SelectionStart for controls that support it and are properly initialized
        Dim caretPos As Integer = 0
        Dim textEdit As DevExpress.XtraEditors.TextEdit = TryCast(editor, DevExpress.XtraEditors.TextEdit)
        If textEdit IsNot Nothing AndAlso textEdit.IsHandleCreated AndAlso Not textEdit.IsDisposed Then
            Try
                caretPos = textEdit.SelectionStart
            Catch ex As Exception
                ' If SelectionStart fails, default to 0
                caretPos = 0
            End Try
        End If

        With GridView1
            If IsNothing(Referance.EditValue) Then _RefPrice = 1

            Try
                .PostEditor()

                ' قراءة StockID بوضع افتراضي آمن
                Dim stockIdString As String = "0"
                Try
                    stockIdString = Convert.ToString(.GetFocusedRowCellValue("StockID"))
                Catch ex As Exception
                    stockIdString = "0"
                End Try

                ' قراءة StockUnit كعدد صحيح بشكل آمن
                Dim unitId As Integer = GetInt(GridView1, .FocusedRowHandle, "StockUnit")

                AllocateDiscount()

                Select Case _FieldName

                    Case "StockBarcode"
                        Exit Sub

                    Case "StockID"

                        ' التحقق من السيريال
                        If GlobalVariables._UseSerials = True Then
                            If HasSerial(stockIdString) = True AndAlso CurrentDocName <> DocNameType.SalesOrder Then
                                Try
                                    For i As Integer = 0 To GridView1.RowCount - 1
                                        Dim rowStockId = Me.GridView1.GetRowCellValue(i, "StockID")
                                        Dim _rowHandle As Integer = GridView1.GetDataSourceRowIndex(i)
                                        Dim focusedRowHandle As Integer = GridView1.GetFocusedDataSourceRowIndex()

                                        If _rowHandle <> focusedRowHandle AndAlso stockIdString = Convert.ToString(rowStockId) Then
                                            MsgBox("الصنف معرف ب سيريال، ولا يمكن اختياره بالفاتورة أكثر من مرة")
                                            GridView1.DeleteSelectedRows()
                                            GridView1.UpdateSummary()
                                        End If
                                    Next
                                Catch ex As Exception
                                    ' يمكن تسجيل الخطأ في اللوج إذا لزم
                                End Try
                            End If
                        End If

                        If stockIdString <> "0" Then
                            Dim itemData = GetItemsData(stockIdString, False)

                            .SetFocusedRowCellValue("ItemName", itemData.ItemName)

                            If GetDecimal(GridView1, .FocusedRowHandle, "StockQuantity") = 0D Then
                                .SetFocusedRowCellValue("StockQuantity", 1D)
                            End If

                            .SetFocusedRowCellValue("StockQuantityByMainUnit",
                                                itemData.EquivalentToMain * .GetFocusedRowCellValue("StockQuantity"))
                            .SetFocusedRowCellValue("StockBarcode", itemData.UnitBarcode)
                            .SetFocusedRowCellValue("ItemNo2", itemData._ItemNo2)

                            If itemData.CostCenter <> 0 Then
                                .SetFocusedRowCellValue("DocCostCenter", itemData.CostCenter)
                            End If

                            .SetFocusedRowCellValue("Color", itemData._Color)
                            .SetFocusedRowCellValue("Measure", itemData._Measure)
                            .SetFocusedRowCellValue("LastPurchasePrice", itemData.LastPurchasePrice)
                            .SetFocusedRowCellValue("ItemVATPercentage", itemData.TaxPercentage)

                            ' تسعير الصنف حسب نوع المستند
                            Select Case CurrentDocName

                            ' 1, 16, 17, 18  → فاتورة مشتريات + ارسالـية داخلية + سند ادخال بضاعة + سند اخراج بضاعة
                                Case DocNameType.PurchaseInvoice,
                                 DocNameType.InternalTransfer,
                                 DocNameType.GoodsIn,
                                 DocNameType.GoodsOut

                                    .SetFocusedRowCellValue("StockPrice",
                                                        itemData.LastPurchasePrice * itemData.EquivalentToMain)

                            ' 2, 11 → فاتورة مبيعات + طلبية مبيعات
                                Case DocNameType.SalesInvoice,
                                 DocNameType.SalesOrder

                                    ' .SetFocusedRowCellValue("CredAcc", itemData.AccSales)
                                    Select Case _RefPrice
                                        Case 1
                                            .SetFocusedRowCellValue("StockPrice", itemData._Price1)
                                        Case 2
                                            .SetFocusedRowCellValue("StockPrice", itemData._Price2)
                                        Case 3
                                            .SetFocusedRowCellValue("StockPrice", itemData._Price3)
                                    End Select

                            ' 12 → مردودات مبيعات
                                Case DocNameType.SalesReturn

                                    Select Case _RefPrice
                                        Case 1
                                            .SetFocusedRowCellValue("StockPrice", itemData._Price1)
                                        Case 2
                                            .SetFocusedRowCellValue("StockPrice", itemData._Price2)
                                        Case 3
                                            .SetRowCellValue(.FocusedRowHandle, "StockPrice", itemData._Price3)
                                    End Select

                            ' 13 → مردودات مشتريات
                                Case DocNameType.PurchaseReturn

                                    .SetRowCellValue(.FocusedRowHandle,
                                                 "StockPrice",
                                                 itemData.LastPurchasePrice * itemData.EquivalentToMain)

                            ' 8, 9 → ارسالـية مشتريات + ارسالـية مبيعات
                                Case DocNameType.PurchaseDispatch,
                                 DocNameType.SalesDispatch

                                    .SetRowCellValue(.FocusedRowHandle, "StockPrice", 0D)

                            End Select

                            ' الوحدة الافتراضية
                            .SetRowCellValue(.FocusedRowHandle, "StockUnit", itemData.DefaultUnit)

                            ' حساب الرصيد في المخزن
                            If ColBalance.Visible = True Then

                                Dim stockIdObj As Object = GridView1.GetFocusedRowCellValue("StockID")

                                Select Case CurrentDocName

                                    Case DocNameType.PurchaseInvoice,
                                     DocNameType.PurchaseDispatch,
                                     DocNameType.PurchaseOrder,
                                     DocNameType.SalesOrder,
                                     DocNameType.SalesReturn,
                                     DocNameType.GoodsReceipt,
                                     DocNameType.GoodsIn

                                        GridView1.SetFocusedRowCellValue(
                                        "Balance",
                                        GetItemBalance(stockIdObj, StockDebitWhereHouse.EditValue)
                                    )

                                    Case Else
                                        GridView1.SetFocusedRowCellValue(
                                        "Balance",
                                        GetItemBalance(stockIdObj, StockCreditWhereHouse.EditValue)
                                    )

                                End Select
                            End If

                        End If

                    Case "StockQuantity"
                        If unitId <> 0 Then
                            Dim equivalent As Decimal = CalcStockQuantityByMainUnit(stockIdString, unitId)
                            .SetFocusedRowCellValue("StockQuantityByMainUnit",
                                                .GetFocusedRowCellValue("StockQuantity") * equivalent)
                        End If

                    Case "BonusQuantity"
                        If unitId <> 0 Then
                            Dim equivalent As Decimal = CalcStockQuantityByMainUnit(stockIdString, unitId)
                            .SetFocusedRowCellValue("BonusQuantityByMainUnit",
                                                .GetFocusedRowCellValue("BonusQuantity") * equivalent)
                        End If

                    Case "ItemVATPercentage"
                        ' عند تغيير نسبة الضريبة نعيد حساب الضريبة اعتماداً على الدالة الجديدة أيضاً
                        Dim rowHandleVat As Integer = .FocusedRowHandle

                        Dim qVat As Decimal = GetDecimal(GridView1, rowHandleVat, "StockQuantity")
                        Dim pVat As Decimal = GetDecimal(GridView1, rowHandleVat, "StockPrice")
                        Dim lineDiscVat As Decimal = GetDecimal(GridView1, rowHandleVat, "StockDiscount")
                        Dim voucherShareVat As Decimal = GetDecimal(GridView1, rowHandleVat, "VoucherDiscount")
                        Dim percVat As Decimal = GetDecimal(GridView1, rowHandleVat, "ItemVATPercentage")

                        Dim vatAmountRecalc As Decimal = CalculateVatAmount(
                        qVat, pVat, lineDiscVat, voucherShareVat, percVat)

                        .SetFocusedRowCellValue("ItemVAT", vatAmountRecalc)

                    Case "DocAmount"
                        Try
                            Dim qty As Decimal = GetDecimal(GridView1, .FocusedRowHandle, "StockQuantity")
                            If qty <> 0D Then
                                Dim docAmount As Decimal = GetDecimal(GridView1, .FocusedRowHandle, "DocAmount")
                                .SetFocusedRowCellValue("StockPrice", docAmount / qty)
                            End If
                        Catch ex As Exception
                            ' يمكن تسجيل الخطأ في اللوج
                        End Try

                    Case "StockUnit"
                        Try
                            Dim itemUnitId As Integer = GetInt(GridView1, .FocusedRowHandle, "StockUnit")
                            If itemUnitId = 0 Then Exit Sub

                            Dim sql As New SQLControl
                            sql.SqlTrueAccountingRunQuery(
                            "SELECT Price1, Price2, Price3, item_unit_bar_code, EquivalentToMain " &
                            "FROM [dbo].[Items_units] " &
                            "WHERE [item_id] = '" & stockIdString & "' AND [unit_id] = " & itemUnitId)

                            Dim row = sql.SQLDS.Tables(0).Rows(0)

                            .SetFocusedRowCellValue("StockBarcode", row.Item("item_unit_bar_code"))

                            ' 2, 9, 12, 18, 11 → مستندات بيع وإخراج
                            If CurrentDocName = DocNameType.SalesInvoice OrElse
                           CurrentDocName = DocNameType.SalesDispatch OrElse
                           CurrentDocName = DocNameType.SalesReturn OrElse
                           CurrentDocName = DocNameType.GoodsOut OrElse
                           CurrentDocName = DocNameType.SalesOrder Then

                                .SetFocusedRowCellValue("StockPrice", row.Item("Price1"))

                                Select Case _RefPrice
                                    Case 1
                                        .SetFocusedRowCellValue("StockPrice", row.Item("Price1"))
                                    Case 2
                                        .SetFocusedRowCellValue("StockPrice", row.Item("Price2"))
                                    Case 3
                                        .SetFocusedRowCellValue("StockPrice", row.Item("Price3"))
                                End Select
                            End If

                            ' 1, 8, 13, 17 → مستندات شراء وإدخال
                            If CurrentDocName = DocNameType.PurchaseInvoice OrElse
                           CurrentDocName = DocNameType.PurchaseDispatch OrElse
                           CurrentDocName = DocNameType.PurchaseReturn OrElse
                           CurrentDocName = DocNameType.GoodsIn Then

                                .SetFocusedRowCellValue("StockBarcode", row.Item("item_unit_bar_code"))
                                .SetFocusedRowCellValue("StockPrice",
                                                    row.Item("EquivalentToMain") *
                                                    GetLastPurchasePrice(.GetFocusedRowCellValue("StockID")))
                            End If

                            Dim equivalent As Decimal = CalcStockQuantityByMainUnit(stockIdString, unitId)
                            .SetFocusedRowCellValue("StockQuantityByMainUnit",
                                                .GetFocusedRowCellValue("StockQuantity") * equivalent)

                        Catch ex As Exception
                            MsgBox("لا يمكن اختيار هذه الوحدة، فهي غير معرفة لهذا الصنف")
                            .SetFocusedRowCellValue("StockPrice", 0D)
                            .SetFocusedRowCellValue("StockUnit", String.Empty)
                        End Try

                End Select

                ' ---------------- إعادة حساب ضريبة السطر وصافي السطر باستخدام الدالة الجديدة ----------------

                Dim rowHandle As Integer = .FocusedRowHandle

                ' قراءة القيم الرقمية من الجدول بشكل آمن
                Dim stockQuantity As Decimal = GetDecimal(GridView1, rowHandle, "StockQuantity")
                Dim unitPrice As Decimal = GetDecimal(GridView1, rowHandle, "StockPrice")
                Dim lineDiscountAmount As Decimal = GetDecimal(GridView1, rowHandle, "StockDiscount")

                ' نفترض أن VoucherDiscount هو حصة هذا السطر من خصم السند الكلي
                Dim voucherDiscountShare As Decimal = GetDecimal(GridView1, rowHandle, "VoucherDiscount")

                Dim vatPercentage As Decimal = GetDecimal(GridView1, rowHandle, "ItemVATPercentage")

                ' حساب ضريبة القيمة المضافة باستخدام الدالة العامة
                Dim lineVatAmount As Decimal = CalculateVatAmount(
                stockQuantity,
                unitPrice,
                lineDiscountAmount,
                voucherDiscountShare,
                vatPercentage
            )

                ' تخزين قيمة الضريبة في الحقل ItemVAT
                .SetFocusedRowCellValue("ItemVAT", lineVatAmount)

                ' نفس صيغتك القديمة تماماً: (الكمية × السعر) - خصم السطر - ضريبة السطر
                .SetRowCellValue(rowHandle,
                             "DocAmount",
                             (stockQuantity * unitPrice) - lineDiscountAmount - lineVatAmount)

                AllocateDiscount()

                Dim lineNetAmount As Decimal = GetDecimal(GridView1, rowHandle, "DocAmount")
                Debug.WriteLine("Edit_EditValueChanged (Amount): " & lineNetAmount)

            Catch ex As Exception
                MsgBox(ex.ToString)
                Debug.WriteLine("Edit_EditValueChanged (Main): " & ex.Message)
            End Try

            GlobalVariables._TempItemNo = 0
        End With

        ' Only restore caret position for TextEdit controls that support it and are properly initialized
        If textEdit IsNot Nothing AndAlso textEdit.IsHandleCreated AndAlso Not textEdit.IsDisposed Then
            Try
                textEdit.SelectionStart = caretPos ' إعادة مؤشر الكتابة إلى نفس المكان بعد التعديل
            Catch ex As Exception
                ' Silently ignore if SelectionStart assignment fails
            End Try
        End If
    End Sub

    '----------------- Helpers -----------------

    Private Function GetDecimal(view As DevExpress.XtraGrid.Views.Grid.GridView,
                            rowHandle As Integer,
                            fieldName As String) As Decimal
        Dim value = view.GetRowCellValue(rowHandle, fieldName)
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0D
        Dim result As Decimal
        If Decimal.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return 0D
    End Function

    Private Function GetInt(view As DevExpress.XtraGrid.Views.Grid.GridView,
                        rowHandle As Integer,
                        fieldName As String) As Integer
        Dim value = view.GetRowCellValue(rowHandle, fieldName)
        If value Is Nothing OrElse value Is DBNull.Value Then Return 0
        Dim result As Integer
        If Integer.TryParse(value.ToString(), result) Then
            Return result
        End If
        Return 0
    End Function

    '----------------- VAT Calculation -----------------

    Public Function CalculateVatAmount(
    ByVal quantity As Decimal,
    ByVal unitPrice As Decimal,
    ByVal lineDiscount As Decimal,
    ByVal voucherDiscountShare As Decimal,
    ByVal vatPercentage As Decimal
) As Decimal

        If quantity < 0D Then quantity = 0D
        If unitPrice < 0D Then unitPrice = 0D
        If lineDiscount < 0D Then lineDiscount = 0D
        If voucherDiscountShare < 0D Then voucherDiscountShare = 0D
        If vatPercentage < 0D Then vatPercentage = 0D

        Dim gross As Decimal = quantity * unitPrice
        Dim taxableBase As Decimal = gross - lineDiscount - voucherDiscountShare
        If taxableBase < 0D Then taxableBase = 0D

        Dim vatAmount As Decimal = taxableBase * vatPercentage / 100D

        Return Math.Round(vatAmount, 2, MidpointRounding.AwayFromZero)
    End Function



    Private Sub RepositoryItemBarCode_KeyDown(sender As Object, e As KeyEventArgs) _
    Handles RepositoryItemBarCode.KeyDown

        If e.KeyCode <> Keys.Enter Then Exit Sub

        With GridView1

            '--------------------------------------------
            ' 1. Read Barcode Safely
            '--------------------------------------------
            Dim stockBarcode As String = ""
            Try
                stockBarcode = CStr(.GetFocusedRowCellValue("StockBarcode"))
            Catch
                stockBarcode = ""
            End Try

            If String.IsNullOrWhiteSpace(stockBarcode) Or stockBarcode = "0" Then
                Exit Sub
            End If

            '--------------------------------------------
            ' 2. Load Item By Barcode
            '--------------------------------------------
            Dim itemData = GetItemsData(stockBarcode, True)

            If itemData.ItemNo Is Nothing OrElse itemData.ItemNo = "" Then
                MsgBox("الصنف غير موجود")
                Exit Sub
            End If

            '--------------------------------------------
            ' 3. Fill Basic Item Info
            '--------------------------------------------
            .SetFocusedRowCellValue("ItemName", itemData.ItemName)
            .SetFocusedRowCellValue("StockID", itemData.ItemNo)
            .SetFocusedRowCellValue("Color", itemData._Color)
            .SetFocusedRowCellValue("Measure", itemData._Measure)
            .SetFocusedRowCellValue("ItemNo2", itemData._ItemNo2)
            .SetFocusedRowCellValue("LastPurchasePrice", itemData.LastPurchasePrice)
            .SetFocusedRowCellValue("ItemVATPercentage", itemData.TaxPercentage)

            '--------------------------------------------
            ' 4. Handle Quantity Conversion
            '--------------------------------------------
            Dim qty As Decimal = 1
            If CDec(.GetFocusedRowCellValue("StockQuantity")) = 0 Then
                .SetFocusedRowCellValue("StockQuantity", 1D)
            End If

            qty = CDec(.GetFocusedRowCellValue("StockQuantity"))

            .SetFocusedRowCellValue(
            "StockQuantityByMainUnit",
            itemData.EquivalentToMain * qty
        )

            '--------------------------------------------
            ' 5. Assign Cost Center
            '--------------------------------------------
            If itemData.CostCenter <> "0" Then
                .SetFocusedRowCellValue("DocCostCenter", itemData.CostCenter)
            Else
                .SetFocusedRowCellValue("DocCostCenter", LookCostCenter.EditValue)
            End If


            '--------------------------------------------
            ' 6. Prevent Duplicate (Serial)
            '--------------------------------------------
            If GlobalVariables._UseSerials Then
                If HasSerial(itemData.ItemNo) AndAlso DocName.EditValue <> 11 Then

                    Dim focusedRow As Integer = .GetFocusedDataSourceRowIndex()

                    For i As Integer = 0 To .RowCount - 1
                        Dim rowItemID = CStr(.GetRowCellValue(i, "StockID"))
                        Dim rowIndex = .GetDataSourceRowIndex(i)

                        If rowIndex <> focusedRow AndAlso rowItemID = itemData.ItemNo Then
                            MsgBox("الصنف معرف بسيريال ولا يمكن تكراره")
                            .DeleteSelectedRows()
                            .UpdateSummary()
                            Exit Sub
                        End If
                    Next
                End If
            End If

            '--------------------------------------------
            ' 7. Load Item Price Based on Document Type
            '--------------------------------------------
            Select Case DocName.EditValue
                Case 1, 17, 18 'Purchase
                    .SetFocusedRowCellValue("StockPrice",
                    itemData.LastPurchasePrice * itemData.EquivalentToMain / ExchangePrice.EditValue)

                Case 2 'Sales
                    Select Case _RefPrice
                        Case 1 : .SetFocusedRowCellValue("StockPrice", itemData._Price1)
                        Case 2 : .SetFocusedRowCellValue("StockPrice", itemData._Price2)
                        Case 3 : .SetFocusedRowCellValue("StockPrice", itemData._Price3)
                    End Select

                Case 12 'Sales Return
                    Select Case _RefPrice
                        Case 1 : .SetFocusedRowCellValue("StockPrice", itemData._Price1)
                        Case 2 : .SetFocusedRowCellValue("StockPrice", itemData._Price2)
                        Case 3 : .SetFocusedRowCellValue("StockPrice", itemData._Price3)
                    End Select

                Case 13 'Purchase Return
                    .SetFocusedRowCellValue("StockPrice",
                    itemData.LastPurchasePrice * itemData.EquivalentToMain / ExchangePrice.EditValue)
            End Select

            .SetFocusedRowCellValue("StockUnit", itemData.DefaultUnit)
            .SetFocusedRowCellValue("ItemVATPercentage", itemData.TaxPercentage)

            '--------------------------------------------
            ' 8. TAX CALCULATION
            '--------------------------------------------
            Dim price As Decimal = CDec(.GetFocusedRowCellValue("StockPrice"))
            Dim discount As Decimal = CDec(.GetFocusedRowCellValue("StockDiscount"))
            Dim vatPercent As Decimal = CDec(.GetFocusedRowCellValue("ItemVATPercentage"))

            Dim netAmount As Decimal = (qty * price) - discount
            Dim vatAmount As Decimal = netAmount * (vatPercent / 100D)
            Dim docAmount As Decimal = netAmount - vatAmount

            .SetFocusedRowCellValue("ItemVAT", vatAmount)
            .SetFocusedRowCellValue("DocAmount", docAmount)

        End With

    End Sub

    'Private Sub Edit_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

    '    ' تم اضافة هذه السطور لتجنب خطأ عند التعديل على الخلية ، حيث كان المبلغ بالفاتورة لا يكتب بطريقة صحيحة
    '    Dim editor As DevExpress.XtraEditors.TextEdit = TryCast(sender, DevExpress.XtraEditors.TextEdit)
    '    If editor Is Nothing Then Exit Sub
    '    Dim caretPos As Integer = editor.SelectionStart

    '    With GridView1
    '        If (IsNothing(Referance.EditValue)) Then _RefPrice = 1
    '        Try
    '            .PostEditor()
    '            Dim _StockID As String = "0"

    '            Try
    '                _StockID = .GetFocusedRowCellValue("StockID")
    '            Catch ex As Exception
    '                _StockID = "0"
    '            End Try
    '            Dim UnitID As Integer = 0
    '            Try
    '                UnitID = .GetFocusedRowCellValue("StockUnit")
    '            Catch ex As Exception
    '                UnitID = 0
    '            End Try

    '            AllocateDiscount()
    '            Select Case _FieldName
    '                Case "StockBarcode"
    '                    Exit Sub
    '                Case "StockID"
    '                    If GlobalVariables._UseSerials = True Then
    '                        If HasSerial(_StockID) = True And DocName.EditValue <> 11 Then
    '                            Try
    '                                Dim i As Integer
    '                                For i = 0 To GridView1.RowCount - 1
    '                                    Dim _StockIDs = Me.GridView1.GetRowCellValue(i, "StockID")
    '                                    Dim _RowHandel As Integer = GridView1.GetDataSourceRowIndex(i)
    '                                    Dim _RowHandelFocus As Integer = GridView1.GetFocusedDataSourceRowIndex()
    '                                    If _RowHandel <> _RowHandelFocus And _StockID = _StockIDs Then
    '                                        MsgBox("الصنف معرف ب سيريال، ولا يمكن اختياره بالفاتورة أكثر من مرة")
    '                                        GridView1.DeleteSelectedRows()
    '                                        GridView1.UpdateSummary()
    '                                    End If
    '                                Next
    '                            Catch ex As Exception

    '                            End Try
    '                        End If
    '                    End If
    '                    If _StockID <> "0" Then
    '                        Dim ItemData = GetItemsData(_StockID, False)
    '                        .SetFocusedRowCellValue("ItemName", ItemData.ItemName)
    '                        If .GetFocusedRowCellValue("StockQuantity") = 0 Then .SetFocusedRowCellValue("StockQuantity", 1)
    '                        .SetFocusedRowCellValue("StockQuantityByMainUnit",
    '                          ItemData.EquivalentToMain * .GetFocusedRowCellValue("StockQuantity"))
    '                        .SetFocusedRowCellValue("StockBarcode", ItemData.UnitBarcode)
    '                        .SetFocusedRowCellValue("ItemNo2", ItemData._ItemNo2)
    '                        If ItemData.CostCenter <> 0 Then
    '                            .SetFocusedRowCellValue("DocCostCenter", ItemData.CostCenter)
    '                        End If
    '                        .SetFocusedRowCellValue("Color", ItemData._Color)
    '                        .SetFocusedRowCellValue("Measure", ItemData._Measure)
    '                        .SetFocusedRowCellValue("LastPurchasePrice", ItemData.LastPurchasePrice)
    '                        Select Case DocName.EditValue
    '                            Case 1, 16, 17, 18
    '                                .SetFocusedRowCellValue("StockPrice", ItemData.LastPurchasePrice * ItemData.EquivalentToMain)
    '                            Case 2, 11
    '                                ' .SetFocusedRowCellValue("CredAcc", ItemData.AccSales)
    '                                Select Case _RefPrice
    '                                    Case 1
    '                                        .SetFocusedRowCellValue("StockPrice", ItemData._Price1)
    '                                    Case 2
    '                                        .SetFocusedRowCellValue("StockPrice", ItemData._Price2)
    '                                    Case 3
    '                                        .SetFocusedRowCellValue("StockPrice", ItemData._Price3)
    '                                End Select
    '                            Case 12
    '                                Select Case _RefPrice
    '                                    Case 1
    '                                        .SetFocusedRowCellValue("StockPrice", ItemData._Price1)
    '                                    Case 2
    '                                        .SetFocusedRowCellValue("StockPrice", ItemData._Price2)
    '                                    Case 3
    '                                        .SetRowCellValue(.FocusedRowHandle, "StockPrice", ItemData._Price3)
    '                                End Select
    '                            Case 13
    '                                .SetRowCellValue(.FocusedRowHandle, "StockPrice", ItemData.LastPurchasePrice * ItemData.EquivalentToMain)
    '                            Case 8, 9
    '                                .SetRowCellValue(.FocusedRowHandle, "StockPrice", 0)
    '                        End Select
    '                        .SetRowCellValue(.FocusedRowHandle, "StockUnit", ItemData.DefaultUnit)

    '                        If ColBalance.Visible = True Then
    '                            Select Case Me.DocName.EditValue
    '                                Case 1, 8, 10, 11, 12, 14, 17
    '                                    GridView1.SetFocusedRowCellValue("Balance", GetItemBalance(GridView1.GetFocusedRowCellValue("StockID"), StockDebitWhereHouse.EditValue))
    '                                Case Else
    '                                    GridView1.SetFocusedRowCellValue("Balance", GetItemBalance(GridView1.GetFocusedRowCellValue("StockID"), StockCreditWhereHouse.EditValue))
    '                            End Select
    '                        End If

    '                    End If


    '                Case "StockQuantity"

    '                    If UnitID <> 0 Then
    '                        Dim _Equivalent As Decimal = CalcStockQuantityByMainUnit(_StockID, UnitID)
    '                        .SetFocusedRowCellValue("StockQuantityByMainUnit",
    '                                         .GetFocusedRowCellValue("StockQuantity") * _Equivalent)
    '                    End If

    '                Case "BonusQuantity"

    '                    If UnitID <> 0 Then
    '                        Dim _Equivalent As Decimal = CalcStockQuantityByMainUnit(_StockID, UnitID)
    '                        .SetFocusedRowCellValue("BonusQuantityByMainUnit",
    '                                         .GetFocusedRowCellValue("BonusQuantity") * _Equivalent)
    '                    End If

    '                Case "DocAmount"
    '                    Try
    '                        .SetFocusedRowCellValue("StockPrice", .GetFocusedRowCellValue("DocAmount") / .GetFocusedRowCellValue("StockQuantity"))
    '                    Catch ex As Exception

    '                    End Try

    '                Case "StockUnit"
    '                    Try
    '                        Dim _Item_Unit_ID As Integer
    '                        _Item_Unit_ID = .GetFocusedRowCellValue("StockUnit")
    '                        If String.IsNullOrEmpty(_Item_Unit_ID) Then Exit Sub
    '                        Dim Sql As New SQLControl
    '                        Sql.SqlTrueAccountingRunQuery(" Select Price1,Price2,Price3,item_unit_bar_code,EquivalentToMain from [dbo].[Items_units] 
    '                                                    where [item_id]='" & _StockID & "' and [unit_id]=" & _Item_Unit_ID)
    '                        .SetFocusedRowCellValue("StockBarcode", Sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code"))
    '                        If Me.DocName.EditValue = 2 Or Me.DocName.EditValue = 9 Or Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 18 Or Me.DocName.EditValue = 11 Then
    '                            .SetFocusedRowCellValue("StockPrice", Sql.SQLDS.Tables(0).Rows(0).Item("Price1"))
    '                            Select Case _RefPrice
    '                                Case 1
    '                                    .SetFocusedRowCellValue("StockPrice", Sql.SQLDS.Tables(0).Rows(0).Item("Price1"))
    '                                Case 2
    '                                    .SetFocusedRowCellValue("StockPrice", Sql.SQLDS.Tables(0).Rows(0).Item("Price2"))
    '                                Case 3
    '                                    .SetFocusedRowCellValue("StockPrice", Sql.SQLDS.Tables(0).Rows(0).Item("Price3"))
    '                            End Select
    '                        End If
    '                        If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 8 Or Me.DocName.EditValue = 13 Or Me.DocName.EditValue = 17 Then
    '                            .SetFocusedRowCellValue("StockBarcode", Sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code"))
    '                            .SetFocusedRowCellValue("StockPrice", Sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain") * GetLastPurchasePrice(.GetFocusedRowCellValue("StockID")))
    '                        End If

    '                        Dim _Equivalent As Decimal = CalcStockQuantityByMainUnit(_StockID, UnitID)
    '                        .SetFocusedRowCellValue("StockQuantityByMainUnit",
    '                                         .GetFocusedRowCellValue("StockQuantity") * _Equivalent)

    '                    Catch ex As Exception
    '                        MsgBox("لا يمكن اختيار هذه الوحدة، فهي غير معرفة لهذا الصنف")
    '                        .SetFocusedRowCellValue("StockPrice", 0)
    '                        .SetFocusedRowCellValue("StockUnit", String.Empty)
    '                    End Try


    '            End Select

    '            Dim _Temp1 As Decimal = .GetFocusedRowCellValue("StockQuantity")
    '            Dim _Temp2 As Decimal = .GetFocusedRowCellValue("StockPrice")

    '            Dim _Temp4 As Decimal = .GetFocusedRowCellValue("VoucherDiscount")
    '            Dim _Temp5 As Decimal = .GetFocusedRowCellValue("StockDiscount")

    '            .SetRowCellValue(.FocusedRowHandle, "DocAmount", (_Temp1 * _Temp2) - _Temp5)
    '            AllocateDiscount()
    '            Dim _Temp3 As Decimal = .GetFocusedRowCellValue("DocAmount")


    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '        GlobalVariables._TempItemNo = 0
    '    End With
    '    editor.SelectionStart = caretPos ' إعادة مؤشر الكتابة إلى نفس المكان بعد التعديل
    'End Sub
    ' تعطيل تعديل الكمية اذا كان الصنف له سيريال
    Private Sub gridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedColumn.FieldName = "StockQuantity" Or view.FocusedColumn.FieldName = "StockID" Or view.FocusedColumn.FieldName = "StockBarcode" Then
            If Not IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")) Then
                If HasSerial(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")) = True And DocName.EditValue <> 11 Then
                    e.Cancel = True
                End If
            End If
        End If
        'If view.FocusedColumn.FieldName = "StockID" Then
        '    If GridView1.GetFocusedRowCellValue("StockID") = 0 Then
        '        GridView1.FocusedColumn = colStockID
        '    End If
        'End If
    End Sub
    Private Function HasSerial(ItemNo As String) As Boolean
        Dim _HasSerial As Boolean
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "Select HasSerial from [dbo].[Items] where [ItemNo]='" & ItemNo & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _HasSerial = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("HasSerial"))
        Catch ex As Exception
            _HasSerial = False
        End Try
        Return _HasSerial

    End Function
    Private Sub GridView1_HiddenEditor(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.HiddenEditor
        Try
            RemoveHandler edit.EditValueChanged, AddressOf Edit_EditValueChanged
            edit = Nothing
        Catch ex As Exception

        End Try


    End Sub
    Private Sub SearchChecksBoxAccount_Popup(sender As Object, e As EventArgs) Handles RepositoryUnit.Popup
        'RepositoryUnit.DataSource = GetUnitsTable(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))

        'Try
        '    Dim _StockID As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
        '    '  If Not String.IsNullOrEmpty(_AccType) Then
        '    Dim sle As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
        '    sle.Properties.View.ClearColumnsFilter()
        '    sle.Properties.View.ActiveFilterString = "[item_id]='" & _StockID & "'"
        '    '  End If
        'Catch ex As Exception
        '    Dim sle As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
        '    sle.Properties.View.ClearColumnsFilter()
        '    sle.Properties.View.ActiveFilterString = "[item_id]='X'"
        'End Try

    End Sub
    Private Function GetBarcodeByUnitAndItemNo(ItemNo As String, UnitID As Integer) As String
        Dim Barcode As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "   Select item_unit_bar_code from  [dbo].Items_units where item_id='" & ItemNo & "' and unit_id=" & UnitID
            Sql.SqlLocalTrueTimeRunQuery(SqlString)
            Barcode = Sql.SQLDS.Tables(0).Rows(0).Item("item_unit_bar_code")
        Catch ex As Exception
            Barcode = "0"
        End Try
        Return Barcode
    End Function
    Private Sub DocName_EditValueChanged(sender As Object, e As EventArgs) Handles DocName.EditValueChanged
        Select Case DocName.EditValue
            Case 1, 17, 8 'مشتريات
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                StockDebitWhereHouse.Properties.DataSource = GetWharehouses(False)
                If DocName.EditValue = 1 Then Me.Text = "فاتورة مشتريات" : LabelDocName.Text = Me.Text
                If DocName.EditValue = 17 Then Me.Text = "سند ادخال" : LabelDocName.Text = Me.Text
                If DocName.EditValue = 8 Then Me.Text = "ارسالية مشتريات" : LabelDocName.Text = Me.Text

            Case 2, 18, 9
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                StockCreditWhereHouse.Properties.DataSource = GetWharehouses(False)
                If DocName.EditValue = 2 Then Me.Text = "فاتورة مبيعات" : LabelDocName.Text = Me.Text
                If DocName.EditValue = 18 Then Me.Text = "سند اخراج" : LabelDocName.Text = Me.Text
                If DocName.EditValue = 9 Then Me.Text = "ارسالية مبيعات" : LabelDocName.Text = Me.Text
            Case 10
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                StockDebitWhereHouse.Properties.DataSource = GetWharehouses(False)
                Me.Text = "طلبية مشتريات" : LabelDocName.Text = Me.Text
            Case 11
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                StockCreditWhereHouse.Properties.DataSource = GetWharehouses(False)
                LayoutOrderStatus.Visibility = Utils.LayoutVisibility.Always
                Me.Text = "طلبية مبيعات" : LabelDocName.Text = Me.Text
            Case 12
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                StockDebitWhereHouse.Properties.DataSource = GetWharehouses(False)
                Me.Text = "مردودات مبيعات" : LabelDocName.Text = Me.Text
            Case 13
                LayoutDebitHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutCreditHouse.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                'LayoutSalesPerson.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                StockCreditWhereHouse.Properties.DataSource = GetWharehouses(False)
                Me.Text = "مردودات مشتريات " : LabelDocName.Text = Me.Text
            Case 16
                Me.Text = " ارسالية داخلية " : LabelDocName.Text = Me.Text
        End Select
        '  
    End Sub

    Private Sub Referance_EditValueChanged(sender As Object, e As EventArgs) Handles Referance.EditValueChanged
        _RefMaxDebit = 0
        If (IsNothing(Referance.EditValue)) Or Referance.EditValue = 0 Then
            Select Case DocName.EditValue
                Case 1, 2, 12, 13
                    AccountForRefranace.EditValue = GetDefaultAccounts(1, DocCurrency.EditValue, GlobalVariables.CurrUser)
                    _RefPrice = 1
                Case 16, 17, 16
                    AccountForRefranace.EditValue = "4020000000"
            End Select

        Else
            Try
                Dim RefData = GetRefranceData(Referance.EditValue)
                AccountForRefranace.EditValue = (RefData.RefAccID)
                TextReferanceName.Text = RefData.RefName
                TextRefBalance.Text = GetReferanceBalance(Referance.EditValue)
                _RefPrice = RefData.PriceCategory
                _RefMaxDebit = RefData.MaxDebit
                SalesPerson.EditValue = RefData.SalesMan

            Catch ex As Exception
                _RefPrice = 1
            End Try

        End If



    End Sub

    Private Sub DocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles DocStatus.EditValueChanged
        Select Case DocStatus.EditValue
            Case -1
                LoadDefault()
            Case 2
                DocStatus.BackColor = Color.Red
            Case 3
                DocStatus.BackColor = Color.Red
            Case -2
                Dim ctrl As Control
                For Each ctrl In Me.Controls
                    ctrl.Enabled = False
                Next
        End Select
    End Sub
    Private Sub LockDocument()
        With Me
            .GridView1.OptionsBehavior.Editable = False
            .DocManualNo.ReadOnly = True
            .SearchOrderStatus.ReadOnly = True
            .DocStatus.ReadOnly = True
            .DocDate.ReadOnly = True
            .TaxDate.ReadOnly = True
            .Referance.ReadOnly = True
            .TextReferanceName.ReadOnly = True
            .LookCostCenter.ReadOnly = True
            .StockDebitWhereHouse.ReadOnly = True
            .StockCreditWhereHouse.ReadOnly = True
            .DocNotes.ReadOnly = True
            .AccountForRefranace.ReadOnly = True
            .DocCurrency.ReadOnly = True
            .ExchangePrice.ReadOnly = True
        End With
    End Sub
    Public Sub LoadDefault()
        '  StockDebitWhereHouse.EditValue = GetDefaultWharehouse()
        '  StockCreditWhereHouse.EditValue = GetDefaultWharehouse()

        StockDebitWhereHouse.EditValue = GetDefaltWahreHouseForUser(CInt(GlobalVariables.CurrUser))
        StockCreditWhereHouse.EditValue = GetDefaltWahreHouseForUser(GlobalVariables.CurrUser)

        DocCurrency.EditValue = _DefaultCurr
        AccountForRefranace.EditValue = GetDefaultAccounts(1, DocCurrency.EditValue, GlobalVariables.CurrUser)
        ExchangePrice.Text = 1
        If Not IsNothing(My.Forms.Main.BarEditDate.EditValue) Then
            DocDate.DateTime = My.Forms.Main.BarEditDate.EditValue
            TaxDate.DateTime = My.Forms.Main.BarEditDate.EditValue
        Else
            DocDate.DateTime = Today
            TaxDate.DateTime = Today
        End If
        DocID.Text = GetDocNo(DocName.EditValue, True)
        CreateTempTable()
        DocCode.Text = CreateRandomCode()
        '  RepositoryUnit.DataSource = GetUnitsTable(-1)
        DateDeliverDate.DateTime = Today()
        DocStatus.EditValue = -1
        BarDeviceName.Caption = GlobalVariables.CurrDevice
        BarInputUser.Caption = GlobalVariables.CurrUser
        Me.LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        Me.TextReferanceName.Text = ""
        Me.Referance.EditValue = Nothing
        Me.TextRefBalance.Text = ""
        Me.DocManualNo.Text = ""
        Me.DocNotes.Text = ""
        _DocTagsToOpen = ""
        Me.SalesPerson.EditValue = ""


        Dim customHeaderButton As DevExpress.XtraEditors.ButtonPanel.IBaseButton = LayoutHeader.CustomHeaderButtons(0)
        Dim customHeaderButtonTyped As DevExpress.XtraEditors.ButtonPanel.BaseButton = CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton)
        customHeaderButtonTyped.Caption = ""



        TextVoucherDiscount.Text = 0
        'BarInputDateTime.Caption = Format(Now, "yyyy-MM-dd HH:mm")
    End Sub

    Private Sub AccStockMove_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
    End Sub


    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow

        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)

            Dim StockQuantity As Object = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockQuantity")
            Dim BonusQuantity As Object = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusQuantity")
            If StockQuantity Is Nothing Then StockQuantity = 1
            Dim ColStockQuantity As GridColumn = view.Columns("StockQuantity")
            If StockQuantity Is DBNull.Value OrElse (TypeOf StockQuantity Is Integer AndAlso CInt(StockQuantity) = 0 AndAlso CInt(BonusQuantity) = 0) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الكمية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = ColStockQuantity
                view.ShowEditor()
            End If
            If CDec(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockQuantity")) = 0 And
                CDec(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusQuantity")) = 0 Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الكمية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = ColStockQuantity
                view.ShowEditor()
            End If

            Dim StockQuantityByMainUnitValue As Object = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockQuantityByMainUnit")
            If StockQuantityByMainUnitValue Is Nothing Then StockQuantityByMainUnitValue = 1
            Dim BonusQuantityByMainUnit As Object = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusQuantityByMainUnit")
            If StockQuantityByMainUnitValue Is DBNull.Value OrElse StockQuantityByMainUnitValue Is Nothing OrElse (TypeOf StockQuantityByMainUnitValue Is Integer AndAlso CInt(StockQuantityByMainUnitValue) = 0 AndAlso CInt(BonusQuantityByMainUnit) = 0) Then
                e.Valid = False
                e.ErrorText = "يجب اعادة ادخال الكمية"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = ColStockQuantity
                view.ShowEditor()
            End If


            Dim _StockID As GridColumn = view.Columns("StockID")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")) = True Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockID
                view.ShowEditor()
            End If

            If Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID") = "0" Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockID
                view.ShowEditor()
            End If

            'Dim _StockItemPrice As GridColumn = view.Columns("StockItemPrice")
            'If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockItemPrice")) = True Then
            '    e.Valid = False
            '    e.ErrorText = "يجب ادخال سعر للصنف"
            '    view.FocusedRowHandle = e.RowHandle
            '    view.FocusedColumn = _StockItemPrice
            '    view.ShowEditor()
            'End If

            Dim _StockUnit As GridColumn = view.Columns("StockUnit")
            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockUnit")) = True Then
                e.Valid = False
                e.ErrorText = "يجب اختيار وحدة الصنف"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _StockUnit
                view.ShowEditor()
            End If

            If GlobalVariables._AlertWhenItemQuantityLessThanBalanceInVouchers = True Then
                Dim ItemNo As Integer
                Dim balance, Quantity As Decimal
                ItemNo = GridView1.GetFocusedRowCellValue("StockID")
                Quantity = GridView1.GetFocusedRowCellValue("StockQuantityByMainUnit")
                If Not IsDBNull(GridView1.GetFocusedRowCellValue("Balance")) Then
                    balance = GridView1.GetFocusedRowCellValue("Balance")
                Else
                    balance = 0
                End If
                If balance < Quantity Then
                    'Dim _Body As String = "تحذير : "
                    '_Body += " رصيد الصنف في  " & StockCreditWhereHouse.Text & "  لا تكفي، يث أن الرصيد " & balance
                    'Main.ToastNotificationsManager1.Notifications(1).Body = _Body
                    'Main.ToastNotificationsManager1.ShowNotification("303ceb91-8bf0-4d4a-8675-5524fce15aa4")
                    If DocName.EditValue = 2 Then XtraMessageBox.Show("رصيد الصنف لا يكفي، حيث أن الرصيد في " & StockCreditWhereHouse.Text & " =  " & balance.ToString("N2"))
                End If
            End If



            'If _CheckIfPriceLessThanCost = True Then
            '    If CDec(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockQuantity")) < _ItemCost Then
            '        e.Valid = False
            '        e.ErrorText = "يجب ادخال الكمية"
            '        view.FocusedRowHandle = e.RowHandle
            '        view.FocusedColumn = _StockQuantity
            '        view.ShowEditor()
            '    End If
            'End If




            If GlobalVariables._CostCenterRequired = True Then
                Dim _DocCostCenter As GridColumn = view.Columns("DocCostCenter")
                If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 2 Or Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 13 Then
                    Dim _AccountNo As String = "0"
                    Select Case DocName.EditValue
                        Case 1
                            _AccountNo = GetItemsData(GridView1.GetFocusedRowCellValue("StockID"), False).AccPurches
                        Case 2
                            _AccountNo = GetItemsData(GridView1.GetFocusedRowCellValue("StockID"), False).AccSales
                        Case 12
                            _AccountNo = GetItemsData(GridView1.GetFocusedRowCellValue("StockID"), False).AccRetSales
                        Case 13
                            _AccountNo = GetItemsData(GridView1.GetFocusedRowCellValue("StockID"), False).AccRetPurches
                    End Select
                    Dim _AccountData As New FinancialAccount
                    If _AccountNo <> "0" Then
                        If _AccountData.GetAccountData(_AccountNo) = True Then
                            If _AccountData.NeedCostCenter = True Then
                                Dim _costcenter As Object = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCostCenter")
                                If IsCellEmptyOrNull(_costcenter) Or _costcenter.ToString = "0" Then
                                    XtraMessageBox.Show("خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار")
                                    e.Valid = False
                                    view.SetColumnError(_DocCostCenter, "خطأ: الحساب بحاجة الى مركز تكلفة ، لا يمكن الاستمرار ")
                                    'e.ErrorText = "خطأ، يجب ادخال المبلغ"
                                    view.FocusedRowHandle = e.RowHandle
                                    view.FocusedColumn = _DocCostCenter
                                    view.ShowEditor()
                                    ' SimpleButtonSave.Enabled = False
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If GlobalVariables._WareHouseUseShelf = True Then
                Dim _StockCreditShelve As GridColumn = view.Columns("StockCreditShelve")
                Dim _StockDebitShelve As GridColumn = view.Columns("StockDebitShelve")
                If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockCreditShelve")) = True And
                   IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockDebitShelve")) = True Then
                    e.Valid = False
                    e.ErrorText = "يجب اختيار رف"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = ColStockQuantity
                    ' view.SetColumnError(_StockQuantity, "يجب اختيار رف")
                    view.ShowEditor()
                End If
                If String.IsNullOrWhiteSpace(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockCreditShelve")) And
                       String.IsNullOrWhiteSpace(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockDebitShelve")) Then
                    e.Valid = False
                    e.ErrorText = "يجب اختيار رف"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = ColStockQuantity
                    'view.SetColumnError(_StockQuantity, "يجب اختيار رف")
                    view.ShowEditor()
                End If
                If (Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockCreditShelve")) =
                   (Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockDebitShelve")) Then
                    e.Valid = False
                    e.ErrorText = "خطأ بالرف"
                    view.FocusedRowHandle = e.RowHandle
                    view.FocusedColumn = ColStockQuantity
                    view.ShowEditor()
                End If
            End If

            If GlobalVariables._UseBatch = True Then
                Dim _ItemIsNeedBatch As Boolean = CheckIfItemNeedBatch(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))
                If _ItemIsNeedBatch = True Then
                    Dim _BatchNoCol As GridColumn = view.Columns("BatchID")
                    If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BatchID")) Then
                        'e.Valid = False
                        'e.ErrorText = "الصنف بحاجة الى اختيار رقم الباتش "
                        'view.FocusedRowHandle = e.RowHandle
                        'view.FocusedColumn = _BatchNoCol
                        'view.ShowEditor()
                        DefineNewBatch()
                    Else
                        If Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BatchID") = 0 Then
                            e.Valid = False
                            e.ErrorText = "الصنف بحاجة الى احتيار رقم الباتش "
                            view.FocusedRowHandle = e.RowHandle
                            view.FocusedColumn = _BatchNoCol
                            view.ShowEditor()
                            DefineNewBatch()
                        End If
                    End If

                End If
            End If





        Catch ex As Exception
            '   MsgBox(ex.ToString)
        End Try




    End Sub
    Private Function IsCellEmptyOrNull(cellValue As Object) As Boolean
        Return cellValue Is Nothing OrElse String.IsNullOrEmpty(cellValue.ToString().Trim())
    End Function
    Private Function CheckIfItemNeedBatch(_ItemNo As Integer)
        Dim result As Boolean
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" select [UseBatchNo] from [dbo].[Items] where ItemNo=" & _ItemNo)
            result = CBool(sql.SQLDS.Tables(0).Rows(0).Item("UseBatchNo"))
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function
    Private Sub Referance_Leave(sender As Object, e As EventArgs) Handles Referance.Leave
        'If (String.IsNullOrEmpty(Referance.Text) Or Referance.Text = "0") And DocName.Text = 1 Then
        '    LayoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        'End If
    End Sub

    Private Sub AccountForRefranace_EditValueChanged(sender As Object, e As EventArgs) Handles AccountForRefranace.EditValueChanged
        If Me.IsHandleCreated Then
            Dim AccountDAta = GetFinancialAccountsData(AccountForRefranace.EditValue)
            AccCurrency.EditValue = AccountDAta.Currency
        End If



        'If AccountForRefranace.Text = "0" Or AccountForRefranace.Text = "" Or AccountDAta.Currency = _DefaultCurr Then
        '    DocCurrency.EditValue = _DefaultCurr
        '    DocCurrency.Enabled = True
        '    Exit Sub
        'End If


        'If AccountDAta.Currency <> _DefaultCurr Then
        '    XtraMessageBox.Show(" سيتم تغيير عملة السند حسب عملةالحساب", "تحدير")
        '    DocCurrency.EditValue = AccountDAta.Currency
        '    DocCurrency.Enabled = False
        'End If



    End Sub

    Private Sub AccountForRefranace_BeforePopup(sender As Object, e As EventArgs) Handles AccountForRefranace.BeforePopup

    End Sub
    Dim _rowUpdated As Boolean = True

    Private Sub GridView1_RowUpdated(sender As Object, e As RowObjectEventArgs)
        '    BarStaticItemProfit.Caption = (TextTotalAfterTAX.EditValue * ExchangePrice.EditValue) - CDec(ColLastPurchasePrice.SummaryItem.SummaryValue) * CDec(ColStockQuantityByMainUnit.SummaryItem.SummaryValue)

        'If _rowUpdated = False Then
        '    Exit Sub
        ''End If
        'If GridView1.IsNewItemRow(e.RowHandle) Then
        '    If Not String.IsNullOrWhiteSpace(GridView1.GetFocusedRowCellValue("StockID")) Then
        '        GlobalVariables._BatchIDTemp = 0
        '        Dim f As New ItemsAvailableBatches
        '        With f
        '            'MsgBox(GridView1.GetFocusedRowCellValue("StockID"))
        '            .TextItemNo.Text = GridView1.GetFocusedRowCellValue("StockID")
        '            .TextItemName.Text = GridView1.GetFocusedRowCellValue("ItemName")
        '            If .ShowDialog <> DialogResult.OK Then
        '                RemoveHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated
        '                GridView1.SetFocusedRowCellValue("BatchID", GlobalVariables._BatchIDTemp)
        '            End If
        '        End With
        '        GlobalVariables._BatchIDTemp = 0

        '    End If
        'Else
        '    If Not String.IsNullOrWhiteSpace(GridView1.GetFocusedRowCellValue("StockID")) Then
        '        GlobalVariables._BatchIDTemp = 0
        '        Dim f As New ItemsAvailableBatches
        '        With f
        '            'MsgBox(GridView1.GetFocusedRowCellValue("StockID"))
        '            .TextItemNo.Text = GridView1.GetFocusedRowCellValue("StockID")
        '            .TextItemName.Text = GridView1.GetFocusedRowCellValue("ItemName")
        '            If .ShowDialog <> DialogResult.OK Then
        '                RemoveHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated
        '                GridView1.SetFocusedRowCellValue("BatchID", GlobalVariables._BatchIDTemp)
        '                AddHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated
        '            End If
        '        End With
        '        GlobalVariables._BatchIDTemp = 0
        '    End If
        'End If

        'AddHandler GridView1.RowUpdated, AddressOf GridView1_RowUpdated



        'If AccCurrency.EditValue = DocCurrency.EditValue Then
        '    BaseAmount.Text = (CDec(colDocAmount.SummaryItem.SummaryValue) * ExchangePrice.EditValue) / ExchangePrice.EditValue
        'ElseIf AccCurrency.EditValue = _DefaultCurr Then
        '    BaseAmount.Text = BaseCurrAmount.EditValue
        'Else
        '        BaseAmount.Text = (CDec(colDocAmount.SummaryItem.SummaryValue) * ExchangePrice.EditValue) / GetExchengPrice(AccCurrency.EditValue, Format(DocDate.DateTime, "yyyy-MM-dd"))
        'End If


    End Sub
    Private Sub CalcBaseAmount()
        If Me.IsHandleCreated Then
            Try
                If AccCurrency.EditValue = _DefaultCurr And DocCurrency.EditValue = _DefaultCurr Then
                    BaseCurrAmount.EditValue = CDec(TextTotalAfterTAX.EditValue)
                    BaseAmount.EditValue = CDec(TextTotalAfterTAX.EditValue)
                ElseIf AccCurrency.EditValue = DocCurrency.EditValue Then
                    BaseCurrAmount.EditValue = (CDec(TextTotalAfterTAX.EditValue) * ExchangePrice.EditValue)
                    BaseAmount.Text = CDec(TextTotalAfterTAX.EditValue)
                ElseIf AccCurrency.EditValue = _DefaultCurr Then
                    BaseCurrAmount.EditValue = (CDec(TextTotalAfterTAX.EditValue) * ExchangePrice.EditValue)
                    BaseAmount.Text = BaseCurrAmount.EditValue
                Else
                    BaseCurrAmount.EditValue = (CDec(TextTotalAfterTAX.EditValue) * ExchangePrice.EditValue)
                    BaseAmount.Text = BaseCurrAmount.EditValue / GetExchengPrice(AccCurrency.EditValue, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub DocCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles DocCurrency.EditValueChanged
        If Me.IsHandleCreated Then
            Try
                Select Case DocCurrency.EditValue
                    Case CInt(_DefaultCurr), 0
                        ExchangePrice.EditValue = 1
                        ExchangePrice.ReadOnly = True
                    Case Else
                        ExchangePrice.ReadOnly = False
                        ExchangePrice.EditValue = GetExchengPrice(DocCurrency.EditValue, Format(DocDate.DateTime, "yyyy-MM-dd")).PurchasePrice
                End Select
            Catch ex As Exception
                ExchangePrice.EditValue = 1
                ExchangePrice.ReadOnly = False
            End Try
        End If
    End Sub

    Private Sub ExchangePrice_EditValueChanged(sender As Object, e As EventArgs) Handles ExchangePrice.EditValueChanged
        CalcBaseAmount()
    End Sub

    Private Sub AccCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles AccCurrency.EditValueChanged
        CalcBaseAmount()
    End Sub



    Private Sub RepositoryUnit_BeforePopup(sender As Object, e As EventArgs) Handles RepositoryUnit.BeforePopup
        'Dim _StockID As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
        'If Not String.IsNullOrEmpty(_StockID) Then
        '    RepositoryUnit.DataSource = GetUnitsTable(_StockID)
        'End If

    End Sub


    Private Sub glkpItem_ProcessNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles Referance.ProcessNewValue
        'With My.Forms.ReferancessAddNew
        '    If Me.DocName.EditValue = 2 Or 11 Then .SearchRefAccID.EditValue = 2
        '    If Me.DocName.EditValue = 1 Then .SearchRefAccID.EditValue = 1
        '    .ShowDialog()
        'End With

    End Sub

    Private Sub TextDocIDQuery_EditValueChanged(sender As Object, e As EventArgs) Handles TextDocIDQuery.EditValueChanged


    End Sub

    Private Sub AccStockMove_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ClearTempTables(Me.DocCode.Text)
        Me.Dispose()
    End Sub


    'Private Sub GridControlChecks_ProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles JournalGridControl.ProcessGridKey
    '    Dim grid = TryCast(sender, GridControl)
    '    Dim view = TryCast(grid.FocusedView, GridView)
    '    If e.KeyData = Keys.Delete Then
    '        view.DeleteSelectedRows()
    '        view.UpdateSummary()
    '        e.Handled = True

    '    ElseIf e.KeyData = Keys.Tab Then
    '        TryCast(sender, GridView).MoveNextCell()
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub JournalGridControl_ProcessGridKey(sender As Object, e As KeyEventArgs) Handles JournalGridControl.ProcessGridKey
        Dim sql As New SQLControl
        Dim view As ColumnView = TryCast(TryCast(sender, GridControl).FocusedView, ColumnView)
        If view Is Nothing Then
            Return
        End If
        If e.KeyCode = Keys.Delete AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            'Prevent record deletion when an in-place editor is invoked:
            If view.ActiveEditor IsNot Nothing Then
                Return
            End If
            e.Handled = True
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If GlobalVariables._UseSerials = True Then
                    If DocStatus.EditValue = -1 Then
                        sql.SqlTrueAccountingRunQuery(" Delete from [dbo].[ItemsSerialTransTemp] 
                                                        Where ItemNo='" & GridView1.GetFocusedRowCellValue("StockID") & "' 
                                                        And [UserNo]='" & GlobalVariables.CurrUser & "' 
                                                        And [DocCode]='" & Me.DocCode.Text & "'")
                    Else
                        'sql.SqlTrueAccountingRunQuery(" Update  [dbo].[ItemsSerialTransTemp] Set 
                        '                                TempTransType='Delete' 
                        '                                Where ItemNo='" & GridView1.GetFocusedRowCellValue("StockID") & "' 
                        '                                And [UserNo]='" & GlobalVariables.CurrUser & "' 
                        '                                And [DocCode]='" & Me.DocCode.Text & "'")
                        If GetCountForItemSerialsInTemp() <> 0 Then
                            XtraMessageBox.Show("لا يمكن حذف صنف له سيريال الرجاء حذف السيرال من شاشة السيريال")
                            Exit Sub
                        End If

                    End If
                End If


                view.DeleteSelectedRows()
                GridView1.UpdateSummary()
                Me.TextTotalDocAmount.EditValue = colDocAmount.SummaryItem.SummaryValue
                Me.TextSumQuantity.EditValue = colStockQuantity.SummaryItem.SummaryValue
                Me.TextTotalTax.EditValue = CDec(ColItemVAT.SummaryItem.SummaryValue)

            End If
        ElseIf e.KeyCode = Keys.Enter Then
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                SendKeys.Send("{TAB}")
            End If
        ElseIf e.KeyCode = Keys.Insert Then
            ' Initialize shared lists if not already done
            If GlobalVariables._TempItemNos Is Nothing Then
                GlobalVariables._TempItemNos = New List(Of Integer)
            End If
            If GlobalVariables._ItemBarcodesGlobal Is Nothing Then
                GlobalVariables._ItemBarcodesGlobal = New List(Of String)
            End If
            If GlobalVariables._ItemColorIDsGlobal Is Nothing Then
                GlobalVariables._ItemColorIDsGlobal = New List(Of String)
            End If
            If GlobalVariables._ItemMeasureIDsGlobal Is Nothing Then
                GlobalVariables._ItemMeasureIDsGlobal = New List(Of String)
            End If

            Dim F As New ItemsSearchMenue
            With F
                .LayoutSelectItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                .GridView1.OptionsSelection.MultiSelect = True
                .GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
                ' .GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
                .LayoutBtnAddSelectedItemsToVouchers.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                .ShowDialog()
            End With

            If GlobalVariables._TempItemNos.Count > 1 Then
                ' Always add new rows for each item if more than one selected
                For i As Integer = 0 To GlobalVariables._TempItemNos.Count - 1
                    GridView1.AddNewRow()
                    _FieldName = "StockID"
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                    GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNos(i))
                    Edit_EditValueChanged(sender, e)
                    If i < GlobalVariables._ItemBarcodesGlobal.Count Then
                        GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodesGlobal(i))
                    End If
                    If i < GlobalVariables._ItemColorIDsGlobal.Count Then
                        GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDsGlobal(i))
                    End If
                    If i < GlobalVariables._ItemMeasureIDsGlobal.Count Then
                        GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDsGlobal(i))
                    End If
                Next
            ElseIf GlobalVariables._TempItemNos.Count = 1 AndAlso GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                _FieldName = "StockID"
                GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNos(0))
                Edit_EditValueChanged(sender, e)
                If GlobalVariables._ItemBarcodesGlobal.Count > 0 Then
                    GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodesGlobal(0))
                End If
                If GlobalVariables._ItemColorIDsGlobal.Count > 0 Then
                    GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDsGlobal(0))
                End If
                If GlobalVariables._ItemMeasureIDsGlobal.Count > 0 Then
                    GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDsGlobal(0))
                End If
            ElseIf GlobalVariables._TempItemNos.Count = 1 Then
                Dim _String As String = "0"
                Try
                    If Not IsNothing(GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockID")) Then
                        _String = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockID").ToString()
                    End If
                Catch ex As Exception
                    _String = "0"
                End Try

                If _String = "0" Then
                    GridView1.AddNewRow()
                    _FieldName = "StockID"
                    AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                    GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNos(0))
                    Edit_EditValueChanged(sender, e)
                    If GlobalVariables._ItemBarcodesGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodesGlobal(0))
                    End If
                    If GlobalVariables._ItemColorIDsGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDsGlobal(0))
                    End If
                    If GlobalVariables._ItemMeasureIDsGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDsGlobal(0))
                    End If
                Else
                    _FieldName = "StockID"
                    GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNos(0))
                    Edit_EditValueChanged(sender, e)
                    If GlobalVariables._ItemBarcodesGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodesGlobal(0))
                    End If
                    If GlobalVariables._ItemColorIDsGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDsGlobal(0))
                    End If
                    If GlobalVariables._ItemMeasureIDsGlobal.Count > 0 Then
                        GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDsGlobal(0))
                    End If
                End If
            End If

            ' Clear the lists after processing
            GlobalVariables._TempItemNos.Clear()
            GlobalVariables._ItemBarcodesGlobal.Clear()
            GlobalVariables._ItemColorIDsGlobal.Clear()
            GlobalVariables._ItemMeasureIDsGlobal.Clear()
            ItemsSearchMenue.GridView1.OptionsSelection.MultiSelect = False
        ElseIf e.KeyCode = Keys.V AndAlso e.Alt AndAlso view.Editable AndAlso view.SelectedRowsCount > 0 Then
            Dim _DebitShelv As Integer = 0
            Dim _CreditShelv As Integer = 0
            If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                _DebitShelv = GridView1.GetFocusedRowCellValue("StockDebitShelve")
                _CreditShelv = GridView1.GetFocusedRowCellValue("StockCreditShelve")
            Else
                _DebitShelv = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockDebitShelve").ToString()
                _CreditShelv = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockCreditShelve").ToString()
            End If
            If _DebitShelv <> 0 And _CreditShelv <> 0 Then
                For i = 0 To GridView1.RowCount - 1
                    GridView1.SetRowCellValue(i, "StockDebitShelve", _DebitShelv)
                    GridView1.SetRowCellValue(i, "StockCreditShelve", _CreditShelv)
                Next
                MsgBox("تم نسخ الرف")
            End If
        End If
    End Sub
    Private Sub GetInsertItemsByItemsSearchForm()

    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow



        Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantity", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "BonusQuantity", 0)
        '  Me.GridView1.SetRowCellValue(e.RowHandle, "StockItemPrice", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "DocAmount", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "StockQuantityByMainUnit", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "BonusQuantityByMainUnit", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "StockPrice", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "StockDiscount", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "VoucherDiscount", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemVAT", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "ItemVATPercentage", 0)
        Me.GridView1.SetRowCellValue(e.RowHandle, "Balance", 0)
        If GlobalVariables._TempItemNo <> 0 Then Me.GridView1.SetRowCellValue(e.RowHandle, "StockID", GlobalVariables._TempItemNo)
        Select Case GridView1.RowCount
            Case 10
                Me.GridView1.IndicatorWidth = 30
            Case 99
                Me.GridView1.IndicatorWidth = 100
        End Select

        If LookCostCenter.Text <> "" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "DocCostCenter", LookCostCenter.EditValue)
        End If

        Select Case Me.DocName.EditValue
            Case 1, 8
                'Dim _defualtShelf As Integer = GetDefaultshelfforWahrehouse(StockDebitWhereHouse.EditValue)
                'If _defualtShelf <> 0 Then Me.GridView1.SetRowCellValue(e.RowHandle, "StockDebitShelve", _defualtShelf)
                Dim _defualtShelf As Integer = 1396
                If _defualtShelf <> 0 Then Me.GridView1.SetRowCellValue(e.RowHandle, "StockDebitShelve", _defualtShelf)
            Case 2, 9
                Dim _defualtShelf As Integer = GetDefaultshelfforWahrehouse(StockCreditWhereHouse.EditValue)
                If _defualtShelf <> 0 Then Me.GridView1.SetRowCellValue(e.RowHandle, "StockCreditShelve", _defualtShelf)
        End Select



        '_HasSerial = False
    End Sub

    Private Function GetDefaultshelfforWahrehouse(WahrehouseID As Integer) As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select IsNull(DefaultShelf,0) as DefaultShelf from [dbo].[Warehouses] where WarehouseID=" & WahrehouseID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("DefaultShelf")
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Sub DocNotes_EditValueChanged(sender As Object, e As EventArgs) Handles DocNotes.EditValueChanged

    End Sub
    Private Sub DocNotes_Validating(sender As Object, e As CancelEventArgs) Handles DocNotes.Validating
        DocNotes.Text = DocNotes.Text.Replace(",", "").Replace("'", "")
    End Sub

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If

        Dim pen = gw.PaintAppearance.HorzLine.GetBackPen(e.Cache)
        Dim startPoint = New Point(e.Bounds.Location.X, e.Bounds.Bottom - CInt(pen.Width))
        Dim endPoint = New Point(e.Bounds.Right, e.Bounds.Bottom - CInt(pen.Width))
        e.DefaultDraw()
        e.Cache.DrawLine(pen, startPoint, endPoint)
        e.Handled = True
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        If Me.DocName.Text = 1 Or Me.DocName.Text = 2 Or Me.DocName.Text = 12 Or Me.DocName.Text = 13 Or Me.DocName.Text = 16 Or Me.DocName.Text = 17 Or Me.DocName.Text = 18 Then
            PrintDoc(False, DocCode.Text, "Journal", True, False)
        ElseIf Me.DocName.Text = 10 Or Me.DocName.Text = 11 Then
            PrintDoc(False, DocCode.Text, "OrdersJournal", True, False)
        End If
    End Sub

    Private Sub GetImageCompany()

    End Sub
    Private Sub RepositoryItem_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles RepositoryItem.AddNewValue

        Dim ff As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        Dim findBox As Control = ff.Controls.Find("teFind", True)(0)
        Dim ItemName As String = findBox.Text



        Dim F As New Items
        With F
            .ItemNo.EditValue = GetMaxNoForNewItem()
            .ItemName.Text = ItemName
            ._OpenedFromDocument = True
            If .ShowDialog() <> DialogResult.OK Then
                GetItems()
                If GridView1.FocusedRowHandle <> GridControl.NewItemRowHandle Then
                    _FieldName = "StockID"
                    GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNo)
                    Edit_EditValueChanged(sender, e)
                    GlobalVariables._TempItemNo = 0
                Else
                    Dim _String As String = "0"
                    Try
                        If Not IsNothing(GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockID")) Then
                            _String = GridView1.GetRowCellValue(DevExpress.XtraGrid.GridControl.NewItemRowHandle, "StockID").ToString()
                        End If
                    Catch ex As Exception
                        _String = "0"
                    End Try
                    If _String = "0" Then
                        GridView1.AddNewRow()
                        _FieldName = "StockID"
                        AddHandler GridView1.InitNewRow, AddressOf GridView1_InitNewRow
                        Edit_EditValueChanged(sender, e)
                        GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodeGlobal)
                        GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDGlobal)
                        GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDGlobal)
                    Else
                        _FieldName = "StockID"
                        GridView1.SetFocusedRowCellValue("StockID", GlobalVariables._TempItemNo)
                        Edit_EditValueChanged(sender, e)
                        GridView1.SetFocusedRowCellValue("StockBarcode", GlobalVariables._ItemBarcodeGlobal)
                        GridView1.SetFocusedRowCellValue("Color", GlobalVariables._ItemColorIDGlobal)
                        GridView1.SetFocusedRowCellValue("Measure", GlobalVariables._ItemMeasureIDGlobal)
                    End If
                    GlobalVariables._TempItemNo = 0
                    GlobalVariables._ItemBarcodeGlobal = "0"
                    GlobalVariables._ItemColorIDGlobal = "0"
                    GlobalVariables._ItemMeasureIDGlobal = "0"
                End If

            End If
        End With


        ' My.Forms.Items.ShowDialog()
        ' GetItems()
    End Sub

    Private Sub RepositoryItem_BeforePopup_1(sender As Object, e As EventArgs) Handles RepositoryItem.BeforePopup
        '  GetItems()
    End Sub

    Private Sub RepositoryItem_QueryPopUp(sender As Object, e As CancelEventArgs) Handles RepositoryItem.QueryPopUp
        'GetItems()
    End Sub

    Private Sub Referance_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles Referance.AddNewValue
        Dim ff As PopupSearchLookUpEditForm = TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupSearchLookUpEditForm)
        Dim findBox As Control = ff.Controls.Find("teFind", True)(0)
        Dim RefName As String = findBox.Text
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            '.LoaddefaultDataSourceforReferences()
            .TextRefName.Text = RefName
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .CheckActive.Checked = True
            .PriceCategory.EditValue = 1
            ._AddNewOrSave = "AddNew"
            If Me.DocName.EditValue = 2 Or Me.DocName.EditValue = 9 Or Me.DocName.EditValue = 11 Or Me.DocName.EditValue = 17 Then .LookRefType.EditValue = 2
            If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 8 Or Me.DocName.EditValue = 10 Or Me.DocName.EditValue = 18 Then .LookRefType.EditValue = 1
            .TextRefName.Select()
            If .ShowDialog() <> DialogResult.OK Then

                Me.Referance.EditValue = GlobalVariables._ReferanceNoGlobal
                Me.Referance.Text = GlobalVariables._ReferanceNoGlobal

                Me.TextReferanceName.Text = GlobalVariables._ReferanceNameGlobal
                Me.Referance.Properties.DataSource = GetReferences(-1, -1, -1)
                Me.Referance.ShowPopup()
                Me.Referance.StartAutoSearch(GlobalVariables._ReferanceNameGlobal)
            End If
        End With
    End Sub



    Private Sub RepositoryItem_QueryCloseUp(sender As Object, e As CancelEventArgs) Handles RepositoryItem.EditValueChanged
        ' GridView1.FocusedColumn = GridView1.Columns("StockUnit")
        'GridView1.FocusedColumn = GridView1.Columns("ItemName")
    End Sub

    Private Sub tabb_SelectedPageChanged(sender As Object, e As LayoutTabPageChangedEventArgs)
        CalcBaseAmount()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        'If XtraMessageBox.Show("هل تريد تحويل السند الى فاتورة مبيعات؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
        '    Me.DocName.EditValue = 2
        '    SaveDocument("ApproveOrderToVoucher")
        'End If
    End Sub


    Private Sub SaveDocumentFromMobileApp(ToDoc As Integer)
        If String.IsNullOrEmpty(DocID.Text) Then
            XtraMessageBox.Show("رقم السند فارغ")
            Exit Sub
        End If

        Dim _LogDetails As String = ""
        'If GridView1.DataSource Then
        '    XtraMessageBox.Show("لا يوجد اصناف بالفاتورة")
        '    Exit Sub
        'End If

        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        CalcBaseAmount()
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _SalesPerson As String
        If String.IsNullOrEmpty(SalesPerson.Text) Then
            _SalesPerson = 0
        Else
            _SalesPerson = SalesPerson.EditValue
        End If
        Dim _Referance, _FirstSideAcc, _Ref_Currency As String
        _Referance = Referance.EditValue
        Dim _RefData = GetRefranceData(_Referance)

        _Ref_Currency = _RefData.currency_id

        Select Case ToDoc
            Case 1, 2, 10, 11, 12, 13
                _FirstSideAcc = _RefData.RefAccID
            Case 16
                _FirstSideAcc = "4020000000"
            Case 17
                _FirstSideAcc = "4020000000"
            Case 18
                _FirstSideAcc = "4020000000"
            Case Else
                _FirstSideAcc = "4020000000"
        End Select

        'If AccountForRefranace.Text = "0" Or String.IsNullOrEmpty(AccountForRefranace.Text) Then
        '    XtraMessageBox.Show("لا يوجد حساب بالفاتورة")
        '    Exit Sub
        'End If

        Dim _DocID As Integer

        Dim _Result1, _Result2, _Result3 As String
        _Result2 = False
        Dim SqlString, SqlString2, SqlString3 As String
        Dim sql As New SQLControl

        Select Case DocName.Text
            Case 11
                Dim _DocName As Integer
                If _ApproveDocToVoucher = True Then
                    _DocName = 2
                Else
                    _DocName = 11
                End If
                _DocID = GetDocNo(_DocName, False)
                SqlString = " Declare @RefName nvarchar(100);
                             Set @RefName = (select top(1) RefName from Referencess where RefNo='" & Referance.Text & "');
                                       Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                           [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                           [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                           StockQuantity,[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                           StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                                           PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,SalesPerson,J.ItemNo2,DocTags ) 
                                       Select " & _DocID & ",'" & Format(DocDate.DateTime, "yyyy-MM-dd") & "'," & _DocName & ",1," & 1 & ",
                                       '0',I.[AccSales] as CredAcc,1 as AccountCurr,
                                       " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocID],N'" & Me.DocNotes.Text & "',
                                        [InputUser],CAST(GETDATE() AS smalldatetime),StockID,StockUnit,StockQuantity,[BonusQuantity],IU.[EquivalentToMain]*StockQuantity,IU.[EquivalentToMain]*BonusQuantity,
                                        StockPrice,0,'" & StockCreditWhereHouse.EditValue & "','" & GlobalVariables.CurrUser & "',
                                        '" & Referance.Text & "',@RefName,I.ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & 0 & "',DocNoteByAccount,DeviceName,DeliverDate,DocCode,'OrdersAppJournal',IU.item_unit_bar_code as StockBarcode,SalesPerson,J.ItemNo2,DocTags
                                       from [dbo].[OrdersAppJournal] J 
                                         Left Join  [dbo].[Items] I On I.[ItemNo]=J.StockID 
                                         Left Join  [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo] 
                                         Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
                                         where DocCode='" & Me.DocCode.Text & "' order by J.ID"
                _Result1 = sql.SqlTrueAccountingRunQuery(SqlString)
                SqlString2 = " Declare @RefName nvarchar(100);
                               Set @RefName = (select top(1) RefName from Referencess where RefNo='" & Referance.Text & "') 
                               Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                           [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount], [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                           DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,LastDocCode,LastDataName,SalesPerson ) 
                                       Values
                                       (" & _DocID & ",'" & Format(DocDate.DateTime, "yyyy-MM-dd") & "'," & _DocName & " ,1," & 1 & ",'" &
                                               _FirstSideAcc & "','0','" & _Ref_Currency & "'," & DocCurrency.EditValue & "," &
                                               colDocAmount.SummaryItem.SummaryValue & "," & ExchangePrice.EditValue & "," & BaseCurrAmount.EditValue & "," &
                                               BaseAmount.EditValue & ",N'" & DocID.Text & "',N'" & DocNotes.Text & "','" & _SalesPerson &
                                               "', CAST(GETDATE() AS smalldatetime),'" & _Referance & "',@RefName,'" & DocCode.Text &
                                               "','" & Me.BarDeviceName.Caption & "',0,0,'" & GlobalVariables.CurrUser & "','" &
                                               Format(DateDeliverDate.DateTime, "yyyy-MM-dd") & "','" & DocCode.Text & "','OrdersAppJournal'," & _SalesPerson & ")"

                If _Result1 = True Then
                    _Result2 = sql.SqlTrueAccountingRunQuery(SqlString2)
                Else
                    sql.SqlTrueAccountingRunQuery(" Delete from JournalTemp where DocCode='" & Me.DocCode.Text & "'")
                    MsgBox("Error")
                    Exit Sub
                End If





                If _Result1 = True And _Result2 = True Then
                    If _ApproveDocToVoucher = True Then
                        SqlString3 = " Insert into [dbo].[Journal] "
                        _LogDetails = "Approve Order From App To Voucher"
                    Else
                        SqlString3 = " Insert into [dbo].[OrdersJournal] "
                        _LogDetails = "Approve Order From App To Order"

                    End If
                    SqlString3 += "  ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit],[BonusQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],DeliverDate,LastDocCode,LastDataName,ItemNo2,DocTags) 
                                                  Select [DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity] ,[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName],DeliverDate,LastDocCode,LastDataName,ItemNo2,DocTags
                                                 from JournalTemp where DocCode='" & Me.DocCode.Text & "' Order by Id"
                    If XtraMessageBox.Show("هل تريد اعتماد الطلبية؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        If _Result1 = True And _Result2 = True Then
                            _Result3 = sql.SqlTrueAccountingRunQuery(SqlString3)
                            If _Result3 = True Then
                                XtraMessageBox.Show("تم الاعتماد", "", MessageBoxButtons.OK)
                                sql.SqlTrueAccountingRunQuery("Update [dbo].OrdersAppJournal Set OrderStatus= 1 where DocCode='" & Me.DocCode.Text & "'")
                            End If
                        End If
                    End If
                End If

                DeleteFromJournalTemp(_DocName, Me.DocCode.Text)
                CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, "Insert", _LogDetails, _LogDateTime)


            Case 14, 15
                _DocID = GetDocNo(ToDoc, False)

                'FirstSide 
                SqlString = " Insert into [JournalTemp]
                              ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                              [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                              [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                              StockQuantity,[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                              StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                              PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,"
                If DocName.Text = "14" Then SqlString += " [StockDebitShelve],[StockCreditShelve]  "
                If DocName.Text = "15" Then SqlString += " [StockCreditShelve],[StockDebitShelve]  "
                SqlString += ",ItemNo2 )"

                SqlString += " Select " & _DocID & ",'" & Format(DocDate.DateTime, "yyyy-MM-dd") & "',"
                SqlString += ToDoc & ","
                SqlString += "1," & 1 & ","
                If ToDoc = 1 Then SqlString += " I.[AccPurches] as DebitAcc,'0'," ' مشتريات
                If ToDoc = 2 Then SqlString += " '0',I.[AccSales] as CreditAcc," ' مبيعات
                If ToDoc = 12 Then SqlString += " I.[AccRetSales] as CreditAcc,'0'," ' مردودات مبيعات
                If ToDoc = 13 Then SqlString += " '0',I.[AccRetPurches] as CreditAcc," ' مردودات مشتريات
                If ToDoc = 17 Then SqlString += " I.[AccPurches] as DebitAcc,'0'," ' سند ادخال
                If ToDoc = 18 Then SqlString += " '0',I.[AccPurches] as DebitAcc," ' سند اخراج
                SqlString += "1 as AccountCurr,
                                       " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocID],N'" & Me.DocNotes.Text & "',
                                       " & GlobalVariables.CurrUser & ",CAST(GETDATE() AS smalldatetime),StockID,StockUnit,StockQuantity,[BonusQuantity],IU.[EquivalentToMain]*StockQuantity,IU.[EquivalentToMain]*BonusQuantity,
                                        StockPrice,"
                If DocName.Text = "14" Then SqlString += StockDebitWhereHouse.EditValue & ",0,'"
                If DocName.Text = "15" Then SqlString += "0," & StockCreditWhereHouse.EditValue & ",'"
                SqlString += GlobalVariables.CurrUser & "',
                                         '" & Referance.Text & "',N'" & TextReferanceName.Text & "',I.ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & 0 & "',
                                         DocNoteByAccount,DeviceName,DeliverDate,DocCode,
                                         'OrdersAppJournal',IU.item_unit_bar_code as StockBarcode,"
                If DocName.Text = "14" Then SqlString += " [StockDebitShelve],[StockCreditShelve]"
                If DocName.Text = "15" Then SqlString += " [StockCreditShelve],[StockDebitShelve]"
                SqlString += ",J.ItemNo2"
                SqlString += "          from [dbo].[OrdersAppJournal] J 
                                         Left Join  [dbo].[Items] I On I.[ItemNo]=J.StockID 
                                         Left Join  [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo] 
                                         Left join Items_units IU on J.StockID =IU.item_id and J.StockBarcode=IU.item_unit_bar_code 
                                         where DocCode='" & Me.DocCode.Text & "' order by J.ID"
                _Result1 = sql.SqlTrueAccountingRunQuery(SqlString)

                'Second Side
                If _Result1 = True Then
                    SqlString2 = " Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount], 
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
                                       [DocCode],DeviceName,PosNo,ShiftID,CurrentUserID,LastDocCode,LastDataName ) 
                                       Values
                                     (" & _DocID & ",'" & Format(DocDate.DateTime, "yyyy-MM-dd") & "'," & ""
                    SqlString2 += ToDoc & ",1,1"
                    If ToDoc = 1 Then SqlString2 += "  ,'0','" & _FirstSideAcc & "'" ' مشتريات
                    If ToDoc = 2 Then SqlString2 += "  ,'" & _FirstSideAcc & "','0'" ' مبيعات
                    If ToDoc = 12 Then SqlString2 += " ,'0','" & _FirstSideAcc & "'" ' مردودات مبيعات
                    If ToDoc = 13 Then SqlString2 += " ,'" & _FirstSideAcc & "','0'" ' مردودات مشتريات
                    If ToDoc = 17 Then SqlString2 += " ,'0','" & _FirstSideAcc & "'" ' سند ادخال
                    If ToDoc = 18 Then SqlString2 += " ,'" & _FirstSideAcc & "','0'" ' سند اخراج
                    SqlString2 += ",'" & _Ref_Currency & "'," & DocCurrency.EditValue & "," &
                                                   colDocAmount.SummaryItem.SummaryValue & "," & ExchangePrice.EditValue & "," & BaseCurrAmount.EditValue & "," &
                                                   BaseAmount.EditValue & ",N'" & DocManualNo.Text & "',N'" & DocNotes.Text & "','" & GlobalVariables.CurrUser &
                                                   "', CAST(GETDATE() AS smalldatetime),'" & _Referance & "',N'" & TextReferanceName.Text & "','" & DocCode.Text &
                                                   "','" & Me.BarDeviceName.Caption & "',0,0,'" & GlobalVariables.CurrUser &
                                                   "','" & DocCode.Text & "','OrdersAppJournal')"
                    _Result2 = sql.SqlTrueAccountingRunQuery(SqlString2)
                End If



                If _Result1 = True And _Result2 = True Then
                    If DocName.Text = "15" Then
                        _LogDetails = "Approve Input Document From WahreHouseApp "
                    ElseIf DocName.Text = "14" Then
                        _LogDetails = "Approve OutPut Document From WahreHouseApp "
                    ElseIf DocName.Text = "16" Then
                        _LogDetails = "Approve Transfer Document From WahreHouseApp "
                    End If
                    SqlString3 = " Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit] ,[BonusQuantityByMainUnit],[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],DeliverDate,LastDocCode,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags) 
                                                  Select [DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit] ,[BonusQuantityByMainUnit],[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName],DeliverDate,LastDocCode
                                                 ,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags
                                                 from JournalTemp where DocCode='" & Me.DocCode.Text & "';
                                                 Delete from JournalTemp where DocCode='" & Me.DocCode.Text & "' "


                    If XtraMessageBox.Show("هل تريد اعتماد السند؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        _Result3 = sql.SqlTrueAccountingRunQuery(SqlString3)
                        If _Result3 = True Then
                            XtraMessageBox.Show("تم الاعتماد", "", MessageBoxButtons.OK)
                            sql.SqlTrueAccountingRunQuery("Update [dbo].OrdersAppJournal Set OrderStatus= 1 where DocCode='" & Me.DocCode.Text & "'")
                            CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, "Insert", _LogDetails, _LogDateTime)
                        Else
                            MsgBox("Error")
                        End If
                    End If
                    DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                Else
                    sql.SqlTrueAccountingRunQuery(" Delete from JournalTemp where DocCode='" & Me.DocCode.Text & "'")
                    MsgBox("Error")
                    Exit Sub
                End If



            Case 16
                _DocID = GetDocNo(ToDoc, False)
                SqlString = " Insert into [JournalTemp]
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                                       [DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                       StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
                                       PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,
                                       [StockDebitShelve], [StockCreditShelve], ItemNo2 ) "

                SqlString += " Select " & _DocID & ",'" & Format(DocDate.DateTime, "yyyy-MM-dd") & "',"
                SqlString += ToDoc & ","
                SqlString += "1," & 1 & ",
                                       I.[AccPurches],I.[AccSales] as CredAcc,1 as AccountCurr,
                                       " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocID],N'" & Me.DocNotes.Text & "',
                                       " & GlobalVariables.CurrUser & ",CAST(GETDATE() AS smalldatetime),StockID,StockUnit,StockQuantity,[BonusQuantity],IU.[EquivalentToMain]*StockQuantity,IU.[EquivalentToMain]*BonusQuantity,
                                        StockPrice,"
                SqlString += StockDebitWhereHouse.EditValue & "," & StockCreditWhereHouse.EditValue & ",'"
                SqlString += GlobalVariables.CurrUser & "',
                                         '" & Referance.Text & "',N'" & TextReferanceName.Text & "',I.ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & 0 & "',
                                         DocNoteByAccount,DeviceName,DeliverDate,DocCode,
                                         'OrdersAppJournal',IU.item_unit_bar_code as StockBarcode,"
                SqlString += " [StockDebitShelve],[StockCreditShelve],J.ItemNo2"
                SqlString += "          from [dbo].[OrdersAppJournal] J 
                                         Left Join  [dbo].[Items] I On I.[ItemNo]=J.StockID 
                                         Left Join  [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo] 
                                         Left join Items_units IU on J.StockID =IU.item_id and J.StockBarcode=IU.item_unit_bar_code 
                                         where DocCode='" & Me.DocCode.Text & "'"
                _Result1 = sql.SqlTrueAccountingRunQuery(SqlString)

                If _Result1 <> True Then
                    sql.SqlTrueAccountingRunQuery(" Delete from JournalTemp where DocCode='" & Me.DocCode.Text & "'")
                    MsgBox("Error")
                    Exit Sub
                End If



                SqlString3 = " Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],DeliverDate,LastDocCode,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags) 
                                                  Select [DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[StockQuantityByMainUnit],[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName],DeliverDate,LastDocCode
                                                 ,LastDataName,StockDebitShelve,StockCreditShelve,ItemNo2,DocTags
                                                 from JournalTemp where DocCode='" & Me.DocCode.Text & "';
                                                 Delete from JournalTemp where DocCode='" & Me.DocCode.Text & "'"

                If _Result1 = True Then
                    If XtraMessageBox.Show("هل تريد اعتماد السند؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                        _Result3 = sql.SqlTrueAccountingRunQuery(SqlString3)
                        If _Result3 = True Then
                            XtraMessageBox.Show("تم الاعتماد", "", MessageBoxButtons.OK)
                            sql.SqlTrueAccountingRunQuery("Update [dbo].OrdersAppJournal Set OrderStatus= 1 where DocCode='" & Me.DocCode.Text & "'")
                        End If
                    End If
                End If
                DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, "Insert", _LogDetails, _LogDateTime)
        End Select



        '  Me.Dispose()

    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim _ToDoc As Integer
        If Me.DocName.EditValue = 14 Then _ToDoc = 1
        If Me.DocName.EditValue = 15 Then _ToDoc = 2
        If Me.DocName.EditValue = 16 Then _ToDoc = 16
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(_ToDoc)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub
    Private Function CheckIfOrderIsVoucherd() As Boolean
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select top(1) * from OrdersJournal where DocCode='" & Me.DocCode.Text & "' and OrderStatus=99"
            sql.SqlTrueAccountingRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                XtraMessageBox.Show("هذا الطلبية تم تحويلها الى فاتورة من قبل ولا بمكن تعديل بيناتها ")
                LayoutConvertDoc.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Return True
            End If
        Catch ex As Exception

        End Try
        Return False
    End Function
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        If CheckIfOrderIsVoucherd() = True Then
            Exit Sub
        End If
        SaveDocument("ApproveOrderToVoucher")
    End Sub

    Private Sub PostOrdersToVouchers()
        Dim _DocName As Integer
        If Me.DocName.EditValue = 10 Then _DocName = 1
        If Me.DocName.EditValue = 11 Then _DocName = 2
        Dim _LogDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _DocCode As String = CreateRandomCode()
        Try
            Dim SqlString, _Result1 As String
            Dim sql As New SQLControl
            Dim _DocID As Integer
            _DocID = GetDocNo(_DocName, False)
            SqlString = " Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity] ,[BonusQuantity],[StockQuantityByMainUnit],[BonusQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo]
                                                 ,[DeviceName],[LastDocCode],[LastDataName],ItemNo2,OrderID,DocTags) 
                                                  Select " & _DocID & ",[DocDate] ," & _DocName & " ,1
                                                 ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
                                                 ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
                                                 ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
                                                 ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
                                                 ,[StockUnit] ,[StockQuantity],[BonusQuantity] ,[StockQuantityByMainUnit],[BonusQuantityByMainUnit] ,[StockPrice]
                                                 ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
                                                 ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
                                                 ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
                                                 ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,N'" & _DocCode & "'
                                                 ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
                                                 ,[VoucherDiscount],[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,'" & Me.DocCode.Text & "','OrdersJournal',ItemNo2,OrderID,DocTags
                                                 from OrdersJournal where DocCode='" & Me.DocCode.Text & "'"
            '   If XtraMessageBox.Show("هل تريد تحويل السند الى فاتورة ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
            _Result1 = sql.SqlTrueAccountingRunQuery(SqlString)
            If _Result1 = True Then
                sql.SqlTrueAccountingRunQuery("Update [dbo].OrdersJournal Set OrderStatus= 99,DocStatus=3 where DocCode='" & Me.DocCode.Text & "'")
                'If _DocName = 1 Or _DocName = 17 Then ChangePurchasePricesFromOrdersDocument(Me.DocCode.Text)
                ' XtraMessageBox.Show("تم الترحيل", "", MessageBoxButtons.OK)
                ' Me.Dispose()
                CreateDocLog("Document", Me.DocCode.Text, _DocName, _DocID, "Insert", "New Voucher From Orders", _LogDateTime)
            End If
            '  End If

            Dim PrintVoucherAfterAcceptFromOrder As Boolean
            Try
                sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Accounting_PrintVoucherAfterAcceptFromOrder'")
                PrintVoucherAfterAcceptFromOrder = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Catch ex As Exception
                PrintVoucherAfterAcceptFromOrder = "False"
            End Try

            If PrintVoucherAfterAcceptFromOrder Then
                If XtraMessageBox.Show("تم اعتماد الطلبية الى فاتورة بنجاح ، هل تريد طباعة الفاتورة ؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                    PrintDoc(True, _DocCode, "Journal", True, False)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub HyperLinkEdit1_OpenLink(sender As Object, e As OpenLinkEventArgs) Handles HyperLinkEdit1.OpenLink
        Select Case Me.LastDataName.Text
            Case "OrdersAppJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
            Case "OrdersJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
        End Select
    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarFromDoc_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Select Case Me.LastDataName.Text
            Case "OrdersAppJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
            Case "OrdersJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
        End Select
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .TextPurchaseOrSale.Text = 1
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = "اخر اسعار الشراء "
            .GetLastPrices(-1)
            .Show()
        End With
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .TextPurchaseOrSale.Text = 2
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .GetLastPrices(-1)
            .Text = "اخر اسعار البيع "
            .Show()
        End With
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If Me.DocName.Text = 1 Or Me.DocName.Text = 2 Or Me.DocName.Text = 12 Or Me.DocName.Text = 13 Or Me.DocName.Text = 16 Then
            PrintDoc(False, DocCode.Text, "Journal", True, False)
        ElseIf Me.DocName.Text = 10 Or Me.DocName.Text = 11 Then
            PrintDoc(False, DocCode.Text, "OrdersJournal", True, False)
        End If
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        PrintDocDetails(Me.DocCode.Text, "Journal")
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDelete.ItemClick
        'If Me.DocStatus.EditValue = 3 Or Me.DocStatus.EditValue = 4 Then
        '    MsgBoxShowError(" السند مرحل ! لا يمكن حذف السند ")
        '    Exit Sub
        'End If

        If GlobalVariables._UseSerials = True Then
            Dim _Count As Integer
            Dim sql As New SQLControl
            Try
                sql.SqlTrueAccountingRunQuery("Select Count(TransID) as Count FROM [dbo].[ItemsSerialTransTemp] 
                                           Where DocCode='" & Me.DocCode.Text & "'")
                _Count = sql.SQLDS.Tables(0).Rows(0).Item("Count")
            Catch ex As Exception
                _Count = 0
            End Try
            If _Count > 0 Then
                XtraMessageBox.Show("لا يمكن حذف السند بسبب وجود سيريال مرتبط بالاصناف، الرجاء حذف الاصناف بشكل منفرد ")
                Exit Sub
            End If
        End If
        If DeleteDoc(DocName.EditValue, DocID.EditValue, Me.DocCode.Text, True) = True Then
            Me.Dispose()
        End If
    End Sub
    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If Me.DocName.Text = 1 Or Me.DocName.Text = 2 Or Me.DocName.Text = 12 Or Me.DocName.Text = 13 Or Me.DocName.Text = 8 Or Me.DocName.Text = 9 Or Me.DocName.Text = 16 Then
            PrintDocDetails(DocCode.Text, "Journal")
        ElseIf Me.DocName.Text = 10 Or Me.DocName.Text = 11 Then
            PrintDocDetails(DocCode.Text, "OrdersJournal")
        End If
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        If Me.DocName.Text = 1 Or Me.DocName.Text = 2 Or Me.DocName.Text = 12 Or Me.DocName.Text = 13 Or Me.DocName.Text = 8 Or Me.DocName.Text = 9 Or Me.DocName.Text = 16 Then
            PrintDoc(False, DocCode.Text, "Journal", True, False)
        ElseIf Me.DocName.Text = 10 Or Me.DocName.Text = 11 Then
            PrintDoc(False, DocCode.Text, "OrdersJournal", True, False)
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        SaveDocument("Nothing")
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Select Case Me.LastDataName.Text
            Case "OrdersAppJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
            Case "OrdersJournal"
                OpenDocumentsByDocCode(Me.LastDocCode.Text, Me.LastDataName.Text, Me.Name)
        End Select
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        _AcceptFromImportSreen = False
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count > 0 Then
            If XtraMessageBox.Show("سيتم حذف الأصناف بالفاتورة هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) Then
                CreateTempTable()
            Else
                Exit Sub
            End If
        End If
        ImportBarcodesToVouchers.DocName.EditValue = Me.DocName.EditValue
        If ImportBarcodesToVouchers.ShowDialog() <> DialogResult.OK Then
            If _AcceptFromImportSreen = True Then
                JournalGridControl.DataSource = GlobalVariables._ItemsTable
            End If
        End If



    End Sub

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count <> 0 Then
            GlobalVariables._ItemsTable = dt
            XtraMessageBox.Show("تم نسخ السند")
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Dim dt As DataTable = (CType(GridView1.DataSource, DataView)).Table
        If dt.Rows.Count > 0 Then
            If XtraMessageBox.Show("سيتم حذف الأصناف بالفاتورة هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                CreateTempTable()
            Else
                Exit Sub
            End If
        End If
        JournalGridControl.DataSource = GlobalVariables._ItemsTable
    End Sub

    Private Sub BarButtonItem10_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        ' ImportBarcodesToVouchers.DocName.EditValue = Me.DocName.EditValue
        My.Forms.JournalForDocument.GridControl1.DataSource =
            GetJournalForTrans(Me.DocName.EditValue, Me.DocID.EditValue)
        My.Forms.JournalForDocument.ShowDialog()


    End Sub


    Private Sub TextVoucherDiscount_EditValueChanged(sender As Object, e As EventArgs) Handles TextVoucherDiscount.EditValueChanged
        AllocateDiscount()
    End Sub
    Private Sub AllocateDiscount()
        If Me.IsHandleCreated Then
            Try
                Dim i As Integer
                Dim _VoucherAmount As Decimal
                Dim _DocAmount As Decimal
                _VoucherAmount = colDocAmount.SummaryItem.SummaryValue
                With GridView1
                    For i = 0 To .RowCount - 1
                        Try
                            If _VoucherAmount <= 0 Then
                                .SetRowCellValue(i, "VoucherDiscount", 0)
                            Else
                                _DocAmount = .GetRowCellValue(i, "DocAmount")
                                .SetRowCellValue(i, "VoucherDiscount", (_DocAmount / _VoucherAmount) * TextVoucherDiscount.EditValue)
                            End If
                        Catch ex As Exception
                            .SetRowCellValue(i, "VoucherDiscount", 0)
                        End Try
                    Next
                End With
                TextTotalAfterDiscount.EditValue = TextTotalDocAmount.EditValue - TextVoucherDiscount.EditValue
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub gridView1_FocusedRowChanged(ByVal sender As Object,
  ByVal e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        ' i miss YOU too HABEBTI
        '  AddHandler GridView1.CellValueChanged, AddressOf GridView1_CellValueChanged
        Me.TextTotalDocAmount.EditValue = colDocAmount.SummaryItem.SummaryValue
        Me.TextSumQuantity.EditValue = colStockQuantity.SummaryItem.SummaryValue
        Me.TextTotalTax.EditValue = CDec(ColItemVAT.SummaryItem.SummaryValue)
    End Sub

    Private Sub TextTotalDocAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextTotalDocAmount.EditValueChanged
        TextTotalAfterDiscount.EditValue = TextTotalDocAmount.EditValue - TextVoucherDiscount.EditValue
    End Sub

    Private Sub TextTotalAfterDiscount_EditValueChanged(sender As Object, e As EventArgs) Handles TextTotalAfterDiscount.EditValueChanged
        'TextTotalAfterTAX.EditValue = TextTotalAfterDiscount.EditValue - TextTotalTax.EditValue
        'Me.TextTotalTax.EditValue = TextTotalAfterDiscount.EditValue - TextTotalAfterDiscount.EditValue / (1 + (TextVAT.EditValue))

        TextTotalAfterTAX.EditValue = TextTotalAfterDiscount.EditValue
    End Sub

    Private Sub TextTotalAfterTAX_EditValueChanged(sender As Object, e As EventArgs) Handles TextTotalAfterTAX.EditValueChanged
        BaseAmount.EditValue = TextTotalAfterTAX.EditValue

        ' فحص تجاوز حد الدين
        If _RefMaxDebit <> 0 And Not String.IsNullOrEmpty(TextReferanceName.Text) Then
            If TextTotalAfterTAX.EditValue + TextRefBalance.EditValue >= _RefMaxDebit Then
                MsgBoxShowError(" لقد تجاوزت السقف المالي  ")
            End If
        End If

    End Sub

    Private Sub CancellAppDocumentButton_Click(sender As Object, e As EventArgs) Handles CancellAppDocumentButton.Click
        If Me.DocStatus.EditValue = 1 Then
            If XtraMessageBox.Show("سيتم الغاء السند هل تريد الاستمرار؟", "Confirmation", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Dim Sql As New SQLControl
                Dim SqlString As String
                SqlString = " Update OrdersAppJournal Set DocStatus= -1 where DocCode= '" & Me.DocCode.Text & "'"
                Sql.SqlTrueAccountingRunQuery(SqlString)
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        Dim gview As GridView = TryCast(sender, GridView)
        If gview Is Nothing Then
            Exit Sub
        End If
        If e.FocusedColumn IsNot Nothing And e.PrevFocusedColumn IsNot Nothing Then
            e.FocusedColumn.AppearanceHeader.BackColor = Color.Blue
            e.PrevFocusedColumn.AppearanceHeader.BackColor = Color.Empty
        End If


        If e.FocusedColumn.FieldName = "StockQuantity" And CheckSerial(GridView1.GetFocusedRowCellValue("StockID")) = True And DocName.EditValue <> 11 Then
            Dim _ItemName As String = ""
            If Not IsDBNull(GridView1.GetFocusedRowCellValue("ItemName")) Then
                _ItemName = GridView1.GetFocusedRowCellValue("ItemName")
            End If
            Select Case DocName.EditValue
                Case 1, 17
                    Dim F As New ItemsSerialsAdd
                    With F
                        .Text = "( " & _ItemName & " )"
                        .ItemNoInItemsSerialAdd = GridView1.GetFocusedRowCellValue("StockID")
                        .DocCodeInItemsSerialAdd = Me.DocCode.Text
                        .DocNameInItemsSerialAdd = Me.DocName.EditValue
                        .DocDateInItemsSerialAdd = Me.DocDate.EditValue
                        .SerialDebitWhereHouse = Me.StockDebitWhereHouse.EditValue
                        .SerialCreditWhereHouse = 0
                        .DocStatusInItemsSerialAdd = Me.DocStatus.EditValue
                        .DocNoInItemsSerialAdd = Me.DocID.EditValue
                        .GetItemSerials()
                        If .ShowDialog() <> DialogResult.OK Then
                            If GetCountForItemSerialsInTemp() = 0 Then
                                GridView1.DeleteSelectedRows()
                                GridView1.UpdateSummary()
                            Else
                                SetQuantityFromSerialTable()
                            End If
                        End If
                    End With
                Case 2, 18
                    Dim F As New ItemSerialsSelect
                    With F
                        .Text = "( " & _ItemName & " )"
                        .ItemNoInItemsSerialOut = GridView1.GetFocusedRowCellValue("StockID")
                        .DocCodeInItemsSerialOut = Me.DocCode.Text
                        .SerialDebitWhereHouseInItemsSerialOut = 0
                        .DocNameInItemsSerialOut = Me.DocName.EditValue
                        .DocDateInItemsSerialOut = Me.DocDate.EditValue
                        .DocStatusInItemsSerialOut = Me.DocStatus.EditValue
                        .SerialCreditWhereHouseInItemsSerialOut = Me.StockCreditWhereHouse.EditValue
                        .GridView1.OptionsSelection.MultiSelect = True
                        .GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .GridView2.OptionsSelection.MultiSelect = True
                        .GridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .GetItemSerialsForOut()
                        If .ShowDialog() <> DialogResult.OK Then
                            If GetCountForItemSerialsInTemp() = 0 Then
                                GridView1.DeleteSelectedRows()
                                GridView1.UpdateSummary()
                            Else
                                SetQuantityFromSerialTable()
                            End If
                        End If
                    End With
                Case 13 ' مردودات مشتريات
                    Dim F As New ItemSerialsSelect
                    With F
                        .Text = "( " & _ItemName & " )"
                        .ItemNoInItemsSerialOut = GridView1.GetFocusedRowCellValue("StockID")
                        .DocCodeInItemsSerialOut = Me.DocCode.Text
                        .SerialDebitWhereHouseInItemsSerialOut = 0
                        .DocNameInItemsSerialOut = Me.DocName.EditValue
                        .DocDateInItemsSerialOut = Me.DocDate.EditValue
                        .DocStatusInItemsSerialOut = Me.DocStatus.EditValue
                        .SerialCreditWhereHouseInItemsSerialOut = Me.StockCreditWhereHouse.EditValue
                        .GridView1.OptionsSelection.MultiSelect = True
                        .GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .GridView2.OptionsSelection.MultiSelect = True
                        .GridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .SerialVendor = Me.Referance.EditValue
                        .GetItemSerialsForPurchaseReturn()
                        If .ShowDialog() <> DialogResult.OK Then
                            If GetCountForItemSerialsInTemp() = 0 Then
                                GridView1.DeleteSelectedRows()
                                GridView1.UpdateSummary()
                            Else
                                SetQuantityFromSerialTable()
                            End If
                        End If
                    End With
                Case 12
                    Dim F As New ItemSerialsSelect
                    With F
                        .Text = "( " & _ItemName & " )"
                        .ItemNoInItemsSerialOut = GridView1.GetFocusedRowCellValue("StockID")
                        .DocCodeInItemsSerialOut = Me.DocCode.Text
                        .SerialDebitWhereHouseInItemsSerialOut = 0
                        .DocNameInItemsSerialOut = Me.DocName.EditValue
                        .DocDateInItemsSerialOut = Me.DocDate.EditValue
                        .DocStatusInItemsSerialOut = Me.DocStatus.EditValue
                        ' .SerialCreditWhereHouseInItemsSerialOut = Me.StockCreditWhereHouse.EditValue
                        .SerialDebitWhereHouseInItemsSerialOut = Me.StockDebitWhereHouse.EditValue
                        .GridView1.OptionsSelection.MultiSelect = True
                        .GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .GridView2.OptionsSelection.MultiSelect = True
                        .GridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .SerialVendor = Me.Referance.EditValue
                        .GetItemSerialsForSalesReturn(Me.Referance.EditValue)
                        If .ShowDialog() <> DialogResult.OK Then
                            If GetCountForItemSerialsInTemp() = 0 Then
                                GridView1.DeleteSelectedRows()
                                GridView1.UpdateSummary()
                            Else
                                SetQuantityFromSerialTable()
                            End If
                        End If
                    End With
                Case 16
                    Dim F As New ItemSerialsSelect
                    With F
                        .Text = "( " & _ItemName & " )"
                        .ItemNoInItemsSerialOut = GridView1.GetFocusedRowCellValue("StockID")
                        .DocCodeInItemsSerialOut = Me.DocCode.Text
                        .SerialDebitWhereHouseInItemsSerialOut = 0
                        .DocNameInItemsSerialOut = Me.DocName.EditValue
                        .DocDateInItemsSerialOut = Me.DocDate.EditValue
                        .DocStatusInItemsSerialOut = Me.DocStatus.EditValue
                        .SerialCreditWhereHouseInItemsSerialOut = Me.StockCreditWhereHouse.EditValue
                        .GridView1.OptionsSelection.MultiSelect = True
                        .GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .GridView2.OptionsSelection.MultiSelect = True
                        .GridView2.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
                        .SerialDebitWhereHouseInItemsSerialOut = StockDebitWhereHouse.EditValue
                        .SerialCreditWhereHouseInItemsSerialOut = StockCreditWhereHouse.EditValue
                        .GetItemSerialsForWahreHouseMoves()
                        If .ShowDialog() <> DialogResult.OK Then
                            If GetCountForItemSerialsInTemp() = 0 Then
                                GridView1.DeleteSelectedRows()
                                GridView1.UpdateSummary()
                            Else
                                SetQuantityFromSerialTable()
                            End If
                        End If
                    End With
            End Select
        ElseIf e.FocusedColumn.FieldName <> "StockID" And e.FocusedColumn.FieldName <> "StockBarcode" Then
            Dim StockID As Integer
            Try
                StockID = GridView1.GetFocusedRowCellValue("StockID")
                If StockID = 0 Then
                    'XtraMessageBox.Show("يجب اختيار صنف")
                    GridView1.FocusedColumn = colStockID


                    'Exit Sub

                End If
            Catch ex As Exception
                ' XtraMessageBox.Show("يجب اختيار صنف")
                GridView1.FocusedColumn = colStockID
                Exit Sub
            End Try
        End If



    End Sub
    Private Function SetQuantityFromSerialTable() As Integer
        Dim Sql As New SQLControl
        Dim _Quantity
        Try
            Sql.SqlTrueAccountingRunQuery("Select IsNull(Count(ItemNo),0) as Quantity
                                                      from ItemsSerialTransTemp 
                                                      where TempTransType<>'Delete' And ItemNo='" & GridView1.GetFocusedRowCellValue("StockID") & "' and DocCode='" & Me.DocCode.Text & "'")
            _Quantity = Sql.SQLDS.Tables(0).Rows(0).Item("Quantity")
        Catch ex As Exception
            _Quantity = 0.0
        End Try
        GridView1.SetFocusedRowCellValue("StockQuantity", _Quantity)
        'GridView1.SetFocusedRowCellValue("StockQuantityPerMainUnit", _Quantity)
        GridView1.SetFocusedRowCellValue("StockQuantityByMainUnit", _Quantity)
        Dim _Temp1 As Decimal = GridView1.GetFocusedRowCellValue("StockQuantity")
        Dim _Temp2 As Decimal = GridView1.GetFocusedRowCellValue("StockPrice")
        Dim _Temp4 As Decimal = GridView1.GetFocusedRowCellValue("VoucherDiscount")
        Dim _Temp5 As Decimal = GridView1.GetFocusedRowCellValue("StockDiscount")
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "DocAmount", (_Temp1 * _Temp2) - _Temp5)
        Return _Quantity
    End Function
    Private Function GetCountForItemSerialsInTemp()
        Dim _Quantity As Integer
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select IsNull(Count(ItemNo),0) as Quantity
                                                      from ItemsSerialTransTemp 
                                                      where TempTransType<>'Delete' And ItemNo='" & GridView1.GetFocusedRowCellValue("StockID") & "' and DocCode='" & Me.DocCode.Text & "'")
            _Quantity = Sql.SQLDS.Tables(0).Rows(0).Item("Quantity")
        Catch ex As Exception
            _Quantity = 0
        End Try
        Return _Quantity
    End Function
    Private Function CheckSerial(_ItemNo) As Boolean
        Dim _HasSerial As Boolean
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Select HasSerial from Items Where ItemNo='" & _ItemNo & "'")
        Try
            _HasSerial = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("HasSerial"))
        Catch ex As Exception
            _HasSerial = False
        End Try
        Return _HasSerial
    End Function

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        If Me.TextTotalDocAmount.EditValue > 0 Then
            Dim F As New TaxAddToInvoice
            With F
                .DocAmountBeforeTax.EditValue = Me.TextTotalAfterTAX.EditValue
                If .ShowDialog() <> DialogResult.OK Then
                    If _TempPercentage <> 0 Then
                        'MsgBox(_TaxPercentageInAccMove)
                        Try
                            Dim i As Integer
                            'Dim _VoucherAmount As Decimal
                            Dim _DocAmount As Decimal
                            Dim _StockPrice As Decimal
                            '_VoucherAmount = colDocAmount.SummaryItem.SummaryValue
                            With GridView1
                                For i = 0 To .RowCount - 1
                                    Try
                                        _DocAmount = .GetRowCellValue(i, "DocAmount")
                                        _StockPrice = .GetRowCellValue(i, "StockPrice")
                                        .SetRowCellValue(i, "DocAmount", _DocAmount + (_DocAmount * _TempPercentage))
                                        .SetRowCellValue(i, "StockPrice", _StockPrice + (_StockPrice * _TempPercentage))
                                    Catch ex As Exception
                                        .SetRowCellValue(i, "DocAmount", _DocAmount)
                                        .SetRowCellValue(i, "StockPrice", _StockPrice)
                                    End Try
                                Next
                            End With
                            'TextTotalAfterDiscount.EditValue = TextTotalDocAmount.EditValue - TextVoucherDiscount.EditValue
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        GridView1.OptionsSelection.MultiSelect = True
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        GridView1.OptionsSelection.MultiSelect = False
    End Sub

    Private Sub اخرالاسعارللذمةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اخرالاسعارللذمةToolStripMenuItem.Click
        If String.IsNullOrEmpty(Referance.Text) Then Exit Sub
        Dim F3 As New LastPrices
        With F3
            .StockID.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .TextPurchaseOrSale.Text = Me.DocName.EditValue
            .TextItemName.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName")
            .Text = "اخر الاسعار للذمة  "
            .GetLastPrices(Me.Referance.EditValue)
            .Show()
        End With
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.DocName.EditValue = 8 Or Me.DocName.EditValue = 9 Then
            If XtraMessageBox.Show("هل تريد تحويل الارسالية الى فاتورة؟", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
                Dim sourceDocIDs As New List(Of Integer) From {Me.DocID.EditValue} ' مثال لقائمة أرقام DocID
                Dim result As Integer = IssueSalesOrPurchaseFromDispatch2(Me.DocName.EditValue, sourceDocIDs, Me.DocCode.Text)
                If result > 0 Then
                    MsgBoxShowSuccess(" تم اعتماد الارسالية الى فاتورة ")
                    Me.Close()
                Else
                    MsgBoxShowError("فشل في تحويل الارسالية الى فاتورة")
                End If
            End If
        Else
            _ApproveDocToVoucher = True
            SaveDocumentFromMobileApp(1)
            Me.Close()
        End If

        'OrdersPending.SearchDocNames.EditValue = -1
        'OrdersPending.SearchLookDocStatus.EditValue = 0
        'OrdersPending.RefreshOrdersFromAppList()
        'OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        'OrdersPending.RefreshOrdersFromAppList()
        'OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarConvertToInputVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(17)
        Me.Close()
        'OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        'OrdersPending.RefreshOrdersFromAppList()
        'OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBarConvertToPurchaseVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(1)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarButtonItem15_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBarConvertToSalesVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(2)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarConvertToRetPurchaseVoucher_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarConvertToRetPurchaseVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(13)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarConvertToOutVoucher_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarConvertToOutVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(18)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarConvertToRetSalesVoucher_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarConvertToRetSalesVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(12)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarConvertToStockMoveVoucher_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarConvertToStockMoveVoucher.ItemClick
        _ApproveDocToVoucher = False
        SaveDocumentFromMobileApp(16)
        Me.Close()
        OrdersPending.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(-1, False, 0)
        OrdersPending.RefreshOrdersFromAppList()
        OrdersPending.GridView1.RefreshData()
    End Sub

    Private Sub BarButtonShowSerials_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    'Private Sub SimpleButton6_Click_2(sender As Object, e As EventArgs)
    '    If MessageBox.Show("هل تريد الخروج من السند?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '        Me.Close()
    '    End If
    'End Sub

    Private Sub BarButtonItem15_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        AttachmentsBulkAdd.ReferanceID.EditValue = Referance.EditValue
        AttachmentsBulkAdd.SearchSystemDocName.EditValue = Me.DocName.EditValue
        AttachmentsBulkAdd.LinkDocNo.EditValue = Me.DocCode.Text
        AttachmentsBulkAdd.ReferanceID.ReadOnly = True
        AttachmentsBulkAdd.SearchAccount.ReadOnly = True
        AttachmentsBulkAdd.ShowDialog()
    End Sub

    Private Sub BarButtonItem20_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim F As New AttachmentDirectDisplay
        With F
            ._Filter = "Document"
            ._DocCode = Me.DocCode.Text
            ._DocName = Me.DocName.EditValue
            .ColDocAccountCode.Visible = False
            .ColAccountName.Visible = False
            .GetAttachments()
            .ShowDialog()
        End With
    End Sub

    Private Sub RepositoryItemBarCode_Enter(sender As Object, e As EventArgs)


    End Sub




    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Dim F As New DocumentLogs
        With F
            ._DocCode = Me.DocCode.Text
            .GridControl1.DataSource = GetDocumentsLogs(Me.DocCode.Text, -1)
            .ColDeviceName.Visible = False
            .ColDocName.Visible = False
            '.ColDocID.Visible = False
            .ColUserID.Visible = False
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick

        RePriceItems("LastPurchased")

    End Sub


    Private Sub حركةالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حركةالصنفToolStripMenuItem.Click
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID")
            .Warehouses.Text = 1
            .Text = " حركة صنف ( " & Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ItemName") & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub

    Private Sub StockCreditWhereHouse_EditValueChanged(sender As Object, e As EventArgs) Handles StockCreditWhereHouse.EditValueChanged
        'If Me.IsHandleCreated = True Then
        '    MsgBox("تم تغيير المستودع")
        'End If
    End Sub

    Private Sub StockDebitWhereHouse_EditValueChanged(sender As Object, e As EventArgs) Handles StockDebitWhereHouse.EditValueChanged
        If GlobalVariables._UseSerials = True Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            If Me.DocName.EditValue = 1 Or DocName.EditValue = 17 Then
                sqlstring = " update [dbo].[ItemsSerialTransTemp] set [SerialDebitWhereHouse]= " & StockDebitWhereHouse.EditValue
                sql.SqlTrueAccountingRunQuery(sqlstring)
            End If
        End If
    End Sub

    Private Sub تفاصيلالصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تفاصيلالصنفToolStripMenuItem.Click
        My.Forms.Items.ItemNo.EditValue = CStr(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StockID"))
        Items.ShowDialog()
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        BuildMessages.ShowDialog()
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub Referance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles Referance.Properties.BeforePopup
        Referance.Properties.DataSource = GetReferences(1, -1, -1)
    End Sub


    Private Sub RepositoryItem_Popup(ByVal sender As Object, ByVal e As EventArgs) Handles RepositoryItem.Popup
        If ShowInActiveItems = False Then
            TryCast(sender, SearchLookUpEdit).Properties.PopupView.ActiveFilterString = "[ItemStatus]= True"
        End If
    End Sub

    Private Sub TextReferanceName_MouseUp(sender As Object, e As MouseEventArgs) Handles TextReferanceName.MouseUp
        If TextReferanceName.Text <> "" Then
            TextReferanceName.SelectionStart = 0
            TextReferanceName.SelectionLength = TextReferanceName.Text.Length
        End If
    End Sub

    Private Sub DocManualNo_MouseUp(sender As Object, e As MouseEventArgs) Handles DocManualNo.MouseUp
        TextEditSelectText(DocManualNo)
    End Sub

    Private Sub TextVoucherDiscount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextVoucherDiscount.MouseUp
        TextEditSelectText(TextVoucherDiscount)
    End Sub

    Private Sub BarButtonMinimize_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMinimize.ItemClick
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BarButtonMaximize_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMaximize.ItemClick
        Me.WindowState = FormWindowState.Maximized
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub BarButtonMDI_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMDI.ItemClick
        Dim child As Form = Nothing
        If child Is Nothing Then
            child = Me
            child.MdiParent = My.Forms.Main
            child.Show()
        Else
            child.Activate()
        End If
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMDI.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMinimize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

    Private Sub BarButtonRestore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonRestore.ItemClick
        Me.WindowState = FormWindowState.Normal
        BarButtonRestore.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        BarButtonMaximize.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    'Private Sub BarButtonItemClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClose.ItemClick
    '    If XtraMessageBox.Show("هل تريد الخروج من السند؟", "تنبيه", MessageBoxButtons.YesNo) <> DialogResult.No Then
    '        Me.Close()
    '    End If
    'End Sub
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
            Return True
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick

    End Sub




    Private Sub BarButtonItem23_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonShowSerials.ItemClick
        Dim F As New ItemsSerialsReport
        With F
            .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
            .GetSerialForDocument(Me.DocCode.Text)
            .Text = " سيريال  " & Me.Text & " " & "(" & Me.DocID.Text & ")"
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        GlobalVariables._ShowRowMaterialinVouchers = True
        GetItems()
    End Sub

    Private Sub BarButtonItem23_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        PrintFinancialClaim(Me.DocID.EditValue, 2, False)
    End Sub

    Private Sub BarButtonItem31_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        PrintFinancialClaim(Me.DocID.EditValue, 2, True)
    End Sub

    Private Sub BarSubCalcPriceAsPrice1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarSubCalcPriceAsPrice1.ItemClick
        RePriceItems("Price1")
    End Sub

    Private Sub BarSubCalcPriceAsPrice2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarSubCalcPriceAsPrice2.ItemClick
        RePriceItems("Price2")
    End Sub
    Private Sub BarSubCalcPriceAsPrice3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarSubCalcPriceAsPrice3.ItemClick
        RePriceItems("Price3")
    End Sub
    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        RePriceItems("LastPriceFromRef")
    End Sub
    Private Sub RePriceItems(_Method)
        Dim F As New TaxAddToInvoice
        With F
            Try
                Dim i As Integer
                Dim _ItemNo As Integer
                Dim _Unit As Integer
                Dim _Quantity As Decimal
                With GridView1
                    For i = 0 To .RowCount - 1
                        Try
                            _ItemNo = .GetRowCellValue(i, "StockID")
                            _Quantity = .GetRowCellValue(i, "StockQuantity")
                            _Unit = .GetRowCellValue(i, "StockUnit")
                            If _ItemNo = 0 Then Exit Sub
                            Select Case _Method
                                Case "Price1"
                                    Dim _Prices = GetItemPriceByCatagory(_ItemNo, _Unit)
                                    .SetRowCellValue(i, "DocAmount", _Prices.Price1 * _Quantity)
                                    .SetRowCellValue(i, "StockPrice", _Prices.Price1)
                                Case "Price2"
                                    Dim _Prices = GetItemPriceByCatagory(_ItemNo, _Unit)
                                    .SetRowCellValue(i, "DocAmount", _Prices.Price2 * _Quantity)
                                    .SetRowCellValue(i, "StockPrice", _Prices.Price2)
                                Case "Price3"
                                    Dim _Prices = GetItemPriceByCatagory(_ItemNo, _Unit)
                                    .SetRowCellValue(i, "DocAmount", _Prices.Price3 * _Quantity)
                                    .SetRowCellValue(i, "StockPrice", _Prices.Price3)
                                Case "LastPurchased"
                                    Dim _LastPurchasedPrice As Decimal = GetLastPurchasePriceFromJournal(_ItemNo, _Unit)
                                    .SetRowCellValue(i, "DocAmount", _LastPurchasedPrice * _Quantity)
                                    .SetRowCellValue(i, "StockPrice", _LastPurchasedPrice)
                                Case "LastPriceFromRef"
                                    If Referance.Text = "" Or Referance.Text = "0" Then
                                        XtraMessageBox.Show(" لا يوجد ذمة بالفاتورة ")
                                        Exit For
                                    Else
                                        Dim _LastPriceFromRef As Decimal = GetLastPriceFromReferance(_ItemNo, _Unit, Referance.EditValue)
                                        .SetRowCellValue(i, "DocAmount", _LastPriceFromRef * _Quantity)
                                        .SetRowCellValue(i, "StockPrice", _LastPriceFromRef)
                                    End If
                            End Select
                        Catch ex As Exception
                            .SetRowCellValue(i, "DocAmount", 0)
                            .SetRowCellValue(i, "StockPrice", 0)
                        End Try
                    Next
                End With
            Catch ex As Exception
            End Try
        End With
    End Sub
    Private Sub RefreshItemBalancesInColBalanceItems()
        Try
            Dim i As Integer
            Dim _ItemNo As Integer
            Dim _Unit As Integer
            Dim _WahreHouse As Integer
            Select Case Me.DocName.EditValue
                Case 1, 8, 10, 12, 14, 17
                    _WahreHouse = StockDebitWhereHouse.EditValue
                Case Else
                    _WahreHouse = StockCreditWhereHouse.EditValue
            End Select

            With GridView1
                For i = 0 To .RowCount - 1
                    Try
                        _ItemNo = .GetRowCellValue(i, "StockID")
                        _Unit = .GetRowCellValue(i, "StockUnit")
                        If _ItemNo = 0 Then Exit Sub
                        Dim _Balance = GetItemBalance(_ItemNo, _WahreHouse)
                        .SetRowCellValue(i, "Balance", _Balance)
                    Catch ex As Exception
                        .SetRowCellValue(i, "Balance", 0)
                    End Try
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function GetLastPurchasePrice(_ItemNO As Integer) As Decimal
        Dim _Price As Decimal
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " select LastPurchasePrice from items where ItemNo=" & _ItemNO
        Try
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Price = sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
        Catch ex As Exception
            _Price = 0
        End Try
        Return _Price
    End Function
    Private Function GetLastPurchasePriceFromJournal(_ItemNO As Integer, _Unit As Integer)
        Dim _LastPrice As Decimal = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  select top(1) StockPrice  from Journal where StockID=" & _ItemNO & " and StockUnit=" & _Unit & " And DocName in (1,17,19) And StockPrice<>0 order by DocDate  desc ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")) Then
                    _LastPrice = sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")
                End If
            End If
        Catch ex As Exception
            _LastPrice = 0
        End Try
        Return _LastPrice
    End Function
    Private Function GetItemPriceByCatagory(_ItemNO As Integer, _Unit As Integer) As (Price1 As Decimal, Price2 As Decimal, Price3 As Decimal)
        Dim _Price1 As Decimal = 0
        Dim _Price2 As Decimal = 0
        Dim _Price3 As Decimal = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  select top(1) Price1,Price2,Price3  from Items_units where unit_id=" & _Unit & " and item_id =" & _ItemNO)
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Price1")) Then
                _Price1 = sql.SQLDS.Tables(0).Rows(0).Item("Price1")
                _Price2 = sql.SQLDS.Tables(0).Rows(0).Item("Price2")
                _Price3 = sql.SQLDS.Tables(0).Rows(0).Item("Price3")
            End If
        Catch ex As Exception
            _Price1 = 0
            _Price2 = 0
            _Price3 = 0
        End Try
        Return (_Price1, _Price2, _Price3)
    End Function
    Private Function GetLastPriceFromReferance(_ItemNo As Integer, _Unit As Integer, _RefNo As Integer)
        Dim _LastPrice As Decimal = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("  select top(1) StockPrice  
                                             from Journal 
                                             where StockID=" & _ItemNo & " and StockUnit=" & _Unit & " and Referance= " & _RefNo & " 
                                             order by DocDate,DocID  desc ")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")) Then
                    _LastPrice = sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")
                End If
            End If
        Catch ex As Exception
            _LastPrice = 0
        End Try
        Return _LastPrice
    End Function

    Private Sub BarButtonItem16_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick

    End Sub

    Private Sub BarButtonItem11_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemVoucherProfit.ItemClick
        Dim f As New VoucherProfit
        With f
            ._VoucherID = Me.DocID.Text
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarShowColBalance.ItemClick
        If ColBalance.Visible = True Then
            ColBalance.Visible = False
            BarShowColBalance.Caption = " اظهار عمود الرصيد "
        Else
            ColBalance.Visible = True
            BarShowColBalance.Caption = " اخفاء عمود الرصيد "
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarShowLastPurchasePrice.ItemClick
        If ColLastPurchasePrice.Visible = True Then
            ColLastPurchasePrice.Visible = False
            BarShowLastPurchasePrice.Caption = " اظهار عمود اخر سعر شراء "
        Else
            '  ColLastPurchasePrice.Visible = True
            ColLastPurchasePrice.VisibleIndex = ColStockPrice.VisibleIndex - 1
            BarShowLastPurchasePrice.Caption = " اخفاء عمود اخر سعر شراء "
        End If
    End Sub

    Private Sub BarButtonItem18_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        If ColBalance.Visible = True Then
            RefreshItemBalancesInColBalanceItems()
        End If

    End Sub



    Private Sub ContextJournalMenu_Opening(sender As Object, e As CancelEventArgs) Handles ContextJournalMenu.Opening
        If GlobalVariables._UserAccessType = 95 Then
            e.Cancel = True
        End If
        If GlobalVariables._UserAccessType = 94 Then
            ToolStripMenuItem1.Visible = False
            ToolStripMenuItem2.Visible = False
            اخرالاسعارللذمةToolStripMenuItem.Visible = False
            تفاصيلالصنفToolStripMenuItem.Visible = False
        End If
    End Sub


    Private Sub RepositoryItemLookUpBatchID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemLookUpBatchID.ButtonClick
        Dim Editor As ButtonEdit = CType(sender, ButtonEdit)
        Dim Button As EditorButton = e.Button
        If Button.Tag = "Get" Then
            DefineNewBatch()
        End If
    End Sub
    Private Sub DefineNewBatch()
        GlobalVariables._BatchIDTemp = 0
        Dim f As New ItemsAvailableBatches
        With f
            .TextItemNo.Text = GridView1.GetFocusedRowCellValue("StockID")
            .TextItemName.Text = GridView1.GetFocusedRowCellValue("ItemName")
            If .ShowDialog <> DialogResult.OK Then
                If GlobalVariables._BatchIDTemp <> 0 Then
                    'RepositoryItemLookUpBatchID.DataSource = GetItemsBatchNoTable(GridView1.GetFocusedRowCellValue("StockID"))
                    GridView1.SetFocusedRowCellValue("BatchID", GlobalVariables._BatchIDTemp)
                    GridView1.SetFocusedRowCellValue("BatchNo", GlobalVariables._BatchNoTemp)
                End If
            End If
        End With
        GlobalVariables._BatchIDTemp = 0
    End Sub

    Private Sub BarButtonItem11_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If Referance.Text <> "" And Referance.Text <> "0" Then
            Dim F3 As New AccountStatmentForRef
            With F3
                .CheckReportForRef.Text = "True"
                .Text = "كشف حساب ( " & TextReferanceName.Text & " )"
                .SearchReferance.Text = Referance.Text
                .DateEditFrom.DateTime = New DateTime(Format(Today, "yyyy"), 1, 1)
                .DateEditTo.DateTime = Today
                .Show()
                .RefreshDataInAccountStatmentForRef()
                .DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
            End With
        End If
    End Sub

    Private Sub بحثعنصنفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles بحثعنصنفToolStripMenuItem.Click
        If GridView1.IsFindPanelVisible Then
            GridView1.HideFindPanel()
        Else
            GridView1.ShowFindPanel()
        End If
    End Sub

    Private Sub حذفسطرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حذفسطرToolStripMenuItem.Click
        DeleteItemRow()
    End Sub
    Private Sub DeleteItemRow()
        Dim sql As New SQLControl
        Try
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف السطر؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If GlobalVariables._UseSerials = True Then
                    If DocStatus.EditValue = -1 Then
                        sql.SqlTrueAccountingRunQuery(" Delete from [dbo].[ItemsSerialTransTemp] 
                                                        Where ItemNo='" & GridView1.GetFocusedRowCellValue("StockID") & "' 
                                                        And [UserNo]='" & GlobalVariables.CurrUser & "' 
                                                        And [DocCode]='" & Me.DocCode.Text & "'")
                    Else
                        If GetCountForItemSerialsInTemp() <> 0 Then
                            XtraMessageBox.Show("لا يمكن حذف صنف له سيريال الرجاء حذف السيرال من شاشة السيريال")
                            Exit Sub
                        End If

                    End If
                End If


                GridView1.DeleteSelectedRows()
                GridView1.UpdateSummary()
                Me.TextTotalDocAmount.EditValue = colDocAmount.SummaryItem.SummaryValue
                Me.TextSumQuantity.EditValue = colStockQuantity.SummaryItem.SummaryValue
                Me.TextTotalTax.EditValue = CDec(ColItemVAT.SummaryItem.SummaryValue)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function CheckIfShelvesInWarehouse() As Boolean
        Dim _result As Boolean = True
        Try
            If GlobalVariables._WareHouseUseShelf = True Then
                Dim sql As New SQLControl
                Dim sqlstring As String = ""
                If Me.DocName.EditValue = 1 Or Me.DocName.EditValue = 8 Or Me.DocName.EditValue = 12 Or Me.DocName.EditValue = 17 Then
                    sqlstring = " select StockDebitShelve,StockDebitWhereHouse,S.WareHouseID   
                                      from [JournalTemp] J
                                      left join FinancialShelves S on J.StockDebitShelve=S.ShelfID 
                                      where StockDebitShelve is not null and S.WareHouseID <>" & StockDebitWhereHouse.EditValue
                    sql.SqlTrueTimeRunQuery(sqlstring)
                    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                        _result = False
                    End If

                ElseIf DocName.EditValue = 2 Or Me.DocName.EditValue = 9 Or Me.DocName.EditValue = 13 Or Me.DocName.EditValue = 18 Then
                    sqlstring = "   select StockCreditShelve,StockCreditWhereHouse,S.WareHouseID   
                                from [JournalTemp] J
                                left join FinancialShelves S on J.StockCreditShelve=S.ShelfID 
                                where StockCreditShelve is not null and S.WareHouseID <>" & StockCreditWhereHouse.EditValue
                    sql.SqlTrueTimeRunQuery(sqlstring)
                    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                        _result = False
                    End If
                ElseIf DocName.EditValue = 16 Then
                    sqlstring = " select StockDebitShelve,StockDebitWhereHouse,S.WareHouseID   
                                      from [JournalTemp] J
                                      left join FinancialShelves S on J.StockDebitShelve=S.ShelfID 
                                      where StockDebitShelve is not null and S.WareHouseID <>" & StockDebitWhereHouse.EditValue
                    sql.SqlTrueTimeRunQuery(sqlstring)
                    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                        _result = False
                    End If
                    sqlstring = "   select StockCreditShelve,StockCreditWhereHouse,S.WareHouseID   
                                from [JournalTemp] J
                                left join FinancialShelves S on J.StockCreditShelve=S.ShelfID 
                                where StockCreditShelve is not null and S.WareHouseID <>" & StockCreditWhereHouse.EditValue
                    sql.SqlTrueTimeRunQuery(sqlstring)
                    If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                        DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                        _result = False
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
        Return _result
    End Function

    Private Sub DocManualNo_Leave(sender As Object, e As EventArgs) Handles DocManualNo.Leave
        If String.IsNullOrEmpty(DocManualNo.Text) Or DocManualNo.Text = "0" Or DocManualNo.Text = "  " Then Exit Sub
        Dim _DocID As Integer = CheckIfDocManualExisit(Me.DocName.EditValue, Me.DocManualNo.Text)
        If _DocID > 0 And _DocID <> Me.DocID.EditValue Then
            If XtraMessageBox.Show("رقم السند اليدوي موجود مسبقا في  " & Me.LabelDocName.Text & "  رقم " & _DocID & " هل تريد الاستمرار؟ ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, DefaultBoolean.Default) = DialogResult.No Then
                Me.DocManualNo.Text = ""
                Me.DocManualNo.Focus()
            End If
        End If
    End Sub

    Private Sub RepositoryTextBatchNo_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryTextBatchNo.ButtonClick
        DefineNewBatch()
    End Sub

    Private Sub RepositoryItem_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItem.ButtonClick

        Select Case e.Button.Tag
            Case "RefreshItems"
                GetItems()
            Case "DeleteItem"
                DeleteItemRow()
        End Select


    End Sub


    Private Function CalcStockQuantityByMainUnit(_ItemNo As Integer, _UnitID As Integer) As Decimal
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select EquivalentToMain from items_units where Item_id=" & _ItemNo & " and unit_id=" & _UnitID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            Return sql.SQLDS.Tables(0).Rows(0).Item("EquivalentToMain")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub BarStaticItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick

    End Sub

    Private Sub تحديثالأصنافToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تحديثالأصنافToolStripMenuItem.Click
        GetItems()
    End Sub

    Private Sub BarButtonItem29_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        ShowInActiveItems = True
    End Sub

    Private Sub BarButtonItem32_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        Me.GridView1.OptionsCustomization.AllowSort = True
    End Sub

    Private Sub BarButtonSendItemsWhatsApp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSendItemsWhatsApp.ItemClick
        '   SendSMSMessage(CStr("120363313491308599"), " ------ " & TextReferanceName.Text & " ------ ", "WhatsApp", True)
        'Dim i As Integer
        'With GridView1
        '    For i = 0 To GridView1.RowCount - 1
        '        Dim _ItemCode As String = .GetRowCellValue(i, "ItemNo2")
        '        Dim _ItemName As String = .GetRowCellValue(i, "ItemName")
        '        Dim _StockQuantity As String = .GetRowCellValue(i, "StockQuantity")
        '        Dim _StockPrice As String = .GetRowCellValue(i, "StockPrice")
        '        If _ItemName <> "" Then
        '            SendSMSMessage(CStr("120363313491308599"), " " & _ItemName & " " & " رقم:" & _ItemCode & " " & "الكمية:" & _StockQuantity & " " & "السعر:" & _StockPrice, "WhatsApp", True)
        '        End If
        '    Next
        'End With
        PrintDoc(False, Me.DocCode.Text, "Journal", False, True)


        'SendFileToWhatsAppGroup(CStr("120363418766138503"), "Document.pdf", 1, Me.LabelDocName.Text & ":" & Me.DocID.Text & "-" & Me.TextReferanceName.Text)
        SendFileToWhatsApp(CStr("120363418766138503"), "Document.pdf", 1, Me.LabelDocName.Text & ":" & Me.DocID.Text & "-" & Me.TextReferanceName.Text, "")




        ' Dim _DocData = GetDocDataByDocCode(Me.DocCode.Text, "Journal")
        ' Dim _DocNameText As String = GetDocNameTextByDocNameID(_DocData.DocName)
        ' Dim MobileNo As String = "0597505029"
        'If String.IsNullOrEmpty(MobileNo) Or MobileNo = "0" Or Len(MobileNo) < 8 Then
        '    MsgBoxShowError(" لا يوجد رقم موبايل " & " ( " & _DocData.ReferanceName & " ) ")
        'Else
        '    SendFileToWhatsApp(MobileNo, "Document.pdf", _DocNameText, _DocNameText & ": " & _DocData.DocID & "-" & _DocData.ReferanceName)
        'End If
        '  Me.Dispose()
        ' SendSMSMessage(CStr("120363313491308599"), " ------ انتهى ------ ", "WhatsApp", True)
    End Sub

    Private Sub BarPrint_Popup(sender As Object, e As EventArgs) Handles BarPrint.Popup
        If GlobalVariables._Shalash = True Then
            Me.BarButtonSendItemsWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If My.Forms.Main.RibbonPageGroupPosSystem.Visible = True And Me.DocName.Text = "2" Then
            BarButtonItempPrintPosVoucher.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
    End Sub

    Private Sub LayoutHeader_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles LayoutHeader.CustomButtonClick
        Try
            Dim F As New TagsNames
            With F
                If .ShowDialog() <> DialogResult.OK Then
                    If GlobalVariables._PublicDocumentTags <> "" Then
                        e.Button.Properties.Caption = GlobalVariables._PublicDocumentTags
                        _DocTagsToOpen = GlobalVariables._PublicDocumentTags
                    Else
                        e.Button.Properties.Caption = e.Button.Properties.Caption
                        _DocTagsToOpen = e.Button.Properties.Caption
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem33_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        Dim dt As New DataTable
        dt.Columns.Add("ItemNo")
        dt.Columns.Add("ItemName")
        dt.Columns.Add("Barcode")
        dt.Columns.Add("Quantity")
        dt.Columns.Add("UnitName")
        dt.Columns.Add("Price")
        dt.Columns.Add("Balance")

        For i = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(i, "StockBarcode") <> "" Then
                Dim newRow As DataRow = dt.NewRow()
                newRow("ItemNo") = GridView1.GetRowCellValue(i, "StockID")
                newRow("ItemName") = GridView1.GetRowCellValue(i, "ItemName")
                newRow("Barcode") = GridView1.GetRowCellValue(i, "StockBarcode")
                newRow("UnitName") = GridView1.GetRowCellDisplayText(i, "StockUnit")
                newRow("Price") = GridView1.GetRowCellValue(i, "StockPrice")
                newRow("Balance") = GridView1.GetRowCellValue(i, "Balance")
                newRow("Quantity") = GridView1.GetRowCellValue(i, "StockQuantity")
                dt.Rows.Add(newRow)
            End If
        Next




        Dim F As New PrintBarcodeForItems
        With F
            ._Table = dt
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItempPrintPosVoucher_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItempPrintPosVoucher.ItemClick
        Dim _DocCode As String
        _DocCode = Me.DocCode.Text
        PrintPosVoucherFromDataBase(_DocCode, True, Me.DocName.EditValue)
    End Sub
    Private Sub AccStockMove_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If askBeforeClose = True Then
            If Me.GridView1.GetRowCellValue(0, "StockQuantity") = 0 AndAlso
(Not IsDBNull(Me.GridView1.GetRowCellValue(0, "BonusQuantity")) AndAlso Me.GridView1.GetRowCellValue(0, "BonusQuantity") = 0) Then
                Exit Sub
            End If

            If GridView1.RowCount > 1 Then
                Dim result As DialogResult = XtraMessageBox.Show("هل تريد الخروج من السند ؟", "تنبيه", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    ' Save the document
                    'SaveDocument("Nothing")
                    ' If saving failed, cancel the close
                    If GridView1.RowCount > 0 Then
                        e.Cancel = True
                    End If
                ElseIf result = DialogResult.Cancel Then
                    ' User canceled the close operation
                    e.Cancel = True
                End If
            End If

            ' If closing is still proceeding, clean up temporary records
            If Not e.Cancel Then
                'DeleteFromJournalTemp(DocName.Text, Me.DocCode.Text)
                'ClearTempTables(Me.DocCode.Text)
            End If
        End If

        '========================================================
        ' 🔒 تحرير القفل مهما حدث
        '========================================================
        Dim postService As New DocumentsPostService()
        postService.ReleaseDocumentLock(Me.DocCode.Text)

    End Sub

    Private Sub RepositoryDocCostCenter2_AddNewValue(sender As Object, e As AddNewValueEventArgs) Handles RepositoryDocCostCenter2.AddNewValue
        Dim costCenterForm As New CostCenterForm()
        Dim result As DialogResult = costCenterForm.ShowDialog()
        Me.RepositoryDocCostCenter2.DataSource = GetCostCenter(False)
    End Sub




    ''' <summary>
    ''' Document types as defined in table [DocNames].
    ''' The numeric values MUST stay synchronized with the ID field in the database.
    ''' </summary>
    Public Enum DocNameType
        Unknown = 0

        ''' <summary>1 - فاتورة مشتريات</summary>
        PurchaseInvoice = 1

        ''' <summary>2 - فاتورة مبيعات</summary>
        SalesInvoice = 2

        ''' <summary>3 - سند صرف</summary>
        PaymentVoucher = 3

        ''' <summary>4 - سند قبض</summary>
        ReceiptVoucher = 4

        ''' <summary>5 - سند قيد</summary>
        JournalVoucher = 5

        ''' <summary>6 - اشعار مدين</summary>
        DebitNote = 6

        ''' <summary>7 - اشعار دائن</summary>
        CreditNote = 7

        ''' <summary>8 - ارسالـية مشتريات</summary>
        PurchaseDispatch = 8

        ''' <summary>9 - ارسالـية مبيعات</summary>
        SalesDispatch = 9

        ''' <summary>10 - طلبية مشتريات</summary>
        PurchaseOrder = 10

        ''' <summary>11 - طلبية مبيعات</summary>
        SalesOrder = 11

        ''' <summary>12 - مردودات مبيعات</summary>
        SalesReturn = 12

        ''' <summary>13 - مردودات مشتريات</summary>
        PurchaseReturn = 13

        ''' <summary>14 - سند استلام بضاعة</summary>
        GoodsReceipt = 14

        ''' <summary>15 - سند تسليم بضاعة</summary>
        GoodsIssue = 15

        ''' <summary>16 - ارسالـية داخلية</summary>
        InternalTransfer = 16

        ''' <summary>17 - سند ادخال بضاعة</summary>
        GoodsIn = 17

        ''' <summary>18 - سند اخراج بضاعة</summary>
        GoodsOut = 18

        ''' <summary>19 - سند انتاج</summary>
        ProductionVoucher = 19
    End Enum

End Class