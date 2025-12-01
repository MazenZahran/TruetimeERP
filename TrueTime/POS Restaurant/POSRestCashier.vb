Imports DevExpress
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports System.ComponentModel
Imports DevExpress.XtraLayout
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports TrueTime.SinglePageReport
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraGrid.Views.WinExplorer

Public Class POSRestCashier
    Dim _DefaultCurr As Integer = GetDefaultCurrency()
    Dim DefaultCashAcc As String = GetDefaultAccounts(1, _DefaultCurr, GlobalVariables.CurrUser)
    Dim _TempDocVoucherCode As String
    Private lockTimerCounter As Integer = 0
    Dim Con As SqlConnection
    Dim PosJournalAdapter As SqlDataAdapter
    Dim DS As DataSet
    Dim _VoucherView As String
    Public _PosVoucherNote As String = String.Empty
    Public _PosVoucherNoteCancelled As Boolean = False
    Dim _TempVoucherNote As String = String.Empty
    Dim _TempDocName As String = 2
    Dim _TempDocID As Integer = 0
    Public _TempPaidAmount As Decimal = 0
    Public _TempReturnAmount As Decimal = 0
    Dim _DefaultWharehouse As String
    Dim _CostCenter As Integer
    Dim _PrinterSize As Integer
    Private sqlCon As SqlConnection
    Dim _PosNo As String
    Dim __DefaultBaseCashAccountName As String
    Dim _PosVoucherNote1 As String
    Dim _PosVoucherNote2 As String
    Dim _ItemsGroupWidth As Decimal = 95
    Dim _ItemsGroupHeight As Decimal = 70
    Dim _ItemsWidth As Decimal = 150
    Dim _ItemsHeight As Decimal = 100
    Dim _VoucherWidth As Decimal = 600
    Dim _OpenCashOnSave As String = "False"
    'Dim _PaidAmount As Decimal = 0
    Dim _DebitInvoice As Boolean
    Dim _VouchertAmountAfterDiscount As Decimal = 0
    Dim _UserNo As Integer
    Dim _Customer As String
    Dim _CustomerNo As Integer
    Dim _CustomerBalance As String
    Dim _CustMobile As String
    Dim _UseDirectProduction As Boolean
    Dim _PosShowRadialMenu As Boolean = False
    Dim posPostVouchers As Boolean
    Dim posNumberOfCopies As Integer
    Public _HoldVoucherCode As String
    Public useVoucherCounter As Boolean
    Public _PosAllowChangeItemPrice As Boolean = False
    Public posAllowMinusQuantityIvVoucher As Boolean = False
    Dim _SecondScreen As String = "Welcome"
    Dim posDefineNewItemInPos As Boolean
    Private Itlaf_Gift As String
    Private _KitchenPrinter As String
    Private _DefaultPrinterPOS As String
    Private _ItemsViewTemplateName As String
    Private _POS_SortItemsByItemName As Boolean
    Private _POS_ShowPosVoucherWhenSellItems As Boolean
    Private customerIsRequirdInPOS As Boolean
    Private _PrintVoucherByItemGroup As Boolean
    Private _PrintVoucherFromPosJournalOrHoldJournal As Boolean
    Private _ResturantMode As Boolean
    Private showLastPurchasePrice As Boolean
    Private showLastTransForCustomer As Boolean
    Public cashCustomerId As Integer = 0
    Private sendVouchersAsTextToMobileNumbers As Boolean = False
    Private OwnersMobileNumbers As String()
    Private resturantModeTablesOrTakeAway As String = "Tables"
    Private cuurentModeInTablesOrTakeAway As String
    Private sendMessageWhenTheItemNotDefined As Boolean = False
    Private WithEvents Timer1 As New Timer
    Private _TextItemDescription As String = ""
    Private _PortionTable As New DataTable
    Private lastKeyPressTime As DateTime = DateTime.Now
    Private barcodeBuffer As String = ""
    Private _previousTabPage As DevExpress.XtraLayout.LayoutControlGroup
    Private _FromTableVouchers As Boolean = False
    Private _SelectedLocation As Integer = 1
    Private shalashCo As Boolean = False
    Private preventKeySubtractInPos As Boolean
    Private sendVoucherToCustomer As Boolean
    Private sendVoucherPDFToCustomer As Boolean
    Private posVoucherRoundingType As String = "RoundToNearestHalf"
    Private posShowImagesInItemsView As Boolean = True
    '-------------------------------
    Dim ReceiptsDetails As List(Of Payment)
    Public SaveWithMultiplePayments As Boolean = False
    Private barAccountNo As String
    Private barAccountName As String
    Private barRefNo As String = "0"
    Private barRefName As String = ""
    Private barCashCustomerName As String = ""
    Private barCashCustomerID As String = ""
    Dim totalPaid As Decimal
    Dim returnAmount As Decimal
    Dim __FirstSide As Boolean = False
    Dim _SecondSide As Boolean = False
    Dim _VoucherSide As Boolean = False
    Dim sql As New SQLControl
    Dim _paymentAccount As String
    Private Function CheckIfPosNoExist() As Boolean
        Dim _Exist As Boolean = False
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Select * from [dbo].[AccountingPOSNames] where ID='" & My.Settings.POSNo & "'")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Exist = True
                BarPosNoName.Caption = sql.SQLDS.Tables(0).Rows(0).Item("POSName")
            End If
        Catch ex As Exception
            _Exist = False
        End Try
        Return _Exist
    End Function

    Private Sub POSRestCashier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim stopwatch As New Stopwatch()
        stopwatch.Start()

        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab

        If Not CheckIfPosNoExist() Then
            MsgBoxShowError("يجب تعريف نقطة البيع في النظام")
            Application.Exit()
            Return
        End If

        _PrintVoucherFromPosJournalOrHoldJournal = True

        With WinExplorerViewItems.OptionsViewStyles
            .Medium.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
            .Large.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
            .ExtraLarge.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
        End With

        TabbedControlGroupAllScreens.ShowTabHeader = DefaultBoolean.False
        TabDailyReport.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab

        _PosNo = My.Settings.POSNo
        Me.DocCode.Text = CreateRandomCode()
        LoadData()

        CreatePorionTable()
        TextItemPriceInPortionScreen.EditValue = 0
        SimpleLabelItemItemName.Text = ""
        TextAdditionsPrice.EditValue = 0

        Me.DocName.Text = 2
        Me.KeyPreview = True

        GridPosVoucher.MainView = TileView2

        TileViewPrice.DisplayFormat.FormatString = "السعر:{0:0.00}"
        TileViewAmount.DisplayFormat.FormatString = "المبلغ:{0:0.00}"
        TileViewDiscount.DisplayFormat.FormatString = "الخصم:({0:0.00})"

        If GlobalVariables._PosUseScales Then
            TileViewQuantity.DisplayFormat.FormatString = "الكمية:{0:0.000}"
        Else
            TileViewQuantity.DisplayFormat.FormatString = "الكمية:{0:0.00}"
        End If

        With TextVoucherAmount.Properties.Mask
            .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            .EditMask = "#,##0.00 NIS"
            .UseMaskAsDisplayFormat = True
        End With

        TileUnitPrice.DisplayFormat.FormatString = "{0:0.00} NIS"

        With TexVouchertAmountBeforeDiscount.Properties.Mask
            .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            .EditMask = "#,##0.00"
            .UseMaskAsDisplayFormat = True
        End With

        Dim msg As String = String.Format("{0} {1} {2}", " الصافي للدفع: ", "#,###0.00", " شيكل ")
        With TexVouchertAmountAfterDiscount.Properties.Mask
            .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            .EditMask = msg
            .UseMaskAsDisplayFormat = True
        End With

        With TextVoucherDiscount.Properties.Mask
            .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
            .EditMask = "#,##0.00"
            .UseMaskAsDisplayFormat = True
        End With

        SetItemsViewTemplateName()

        Timer1.Interval = 1000 ' 1 second
        Timer1.Start()

        _VoucherView = "TileView"
        Me.Text = "فاتورة مبيعات نقدية"
        PosAddLOG(Me.DocCode.Text, "PosOpened")
        ShowSecondScreen("Welcome")
        txtBarcode.Focus()

        BarElapseTimes.Caption = $"LoadData: {stopwatch.ElapsedMilliseconds} ms"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BarDateTime.Caption = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub


    Private Sub CreatePorionTable()
        _PortionTable.Columns.Add("ID", GetType(System.Int32))
        _PortionTable.Columns.Add("PortionName", GetType(System.String))
        _PortionTable.Columns.Add("ItemPrice", GetType(System.Int32))
    End Sub
    Private Sub ShowSecondScreen(_FormName As String)

        Try
            Dim _screen As Screen
            If Screen.AllScreens.Count > 1 Then
                _screen = Screen.AllScreens(1)
                Select Case _FormName
                    Case "Voucher"
                        PosWelcomeScreen.Hide()
                        PosSecondScreen.StartPosition = FormStartPosition.Manual
                        PosSecondScreen.Location = _screen.Bounds.Location + New Point(100, 100)
                        PosSecondScreen.Show()
                    Case "Welcome"
                        PosSecondScreen.Hide()
                        PosWelcomeScreen.StartPosition = FormStartPosition.Manual
                        PosWelcomeScreen.Location = _screen.Bounds.Location + New Point(100, 100)
                        PosWelcomeScreen.Show()
                End Select
                _SecondScreen = _FormName
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        txtBarcode.Focus()
    End Sub
    Private Sub POSRestCashier_Load2(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtBarcode.Focus()
    End Sub
    Private Sub LoadData()
        Dim stopwatch As New Stopwatch()
        stopwatch.Start()
        Dim sql As New SQLControl
        ' Check license validity
        Try
            sql.SqlTrueAccountingRunQuery("SELECT SetCode FROM [dbo].[SettValues] WHERE SetName='Set1'")
            GlobalVariables._EndDate = CDate(DecodingData(sql.SQLDS.Tables(0).Rows(0).Item("SetCode")))

            Dim daysRemaining As Integer = CInt(GlobalVariables._EndDate.Subtract(Today).TotalDays)
            If daysRemaining <= 0 Then
                MsgBoxShowError("النسخة انتهت / يرجى مراجعة قسم المبيعات لشركة تروتايم سوليوشنز")
                Application.Exit()
                Return
            End If
        Catch ex As Exception
            ' Continue if license check fails (development mode)
        End Try

        ' Update account settings in journal
        sql.SqlTrueAccountingRunQuery("UPDATE t1
                                      SET t1.CredAcc = t2.AccSales, t1.DebitAcc='0'
                                      FROM POSJournal t1
                                      JOIN Items t2 ON t1.StockID=t2.ItemNo
                                      WHERE t1.PosNo=" & _PosNo & " AND DeviceName='" & GlobalVariables.CurrDevice & "';
                                      UPDATE [AccountingPOSNames] SET [VouchersCounter]=0 WHERE [VouchersCounter] IS NULL")

        ' Load essential data
        GetPosJournalTable()
        CheckIfShiftFound()
        _PrinterSize = PosPrinterSize()

        ' Check for default cash account
        If DefaultCashAcc = "0" Then
            MsgBox("المستخدم لا يوجد له صندوق افتراضي")
            SidePanel1.Enabled = False
        End If

        ' Set up UI captions
        Me.ItemUserNo.Caption = GlobalVariables.CurrUser
        Me.BarItemUserName.Caption = GlobalVariables.EmployeeName
        _DefaultBaseCashAccount = GetDefaultAccounts(1, 1, GlobalVariables.CurrUser)
        Me.BarWahrehouse.Caption = "المستودع: " & _DefaultWharehouse
        TextOtherAccountNo.Caption = GlobalVariables._DefaultBaseCashAccount

        ' Initialize UI elements
        CenterCaption()
        SetIcons()
        _DefaultWharehouse = GetDefaultWharehouseForPos()
        __DefaultBaseCashAccountName = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
        TextOtherAccountName.Caption = __DefaultBaseCashAccountName
        BarPosNo.Caption = My.Settings.POSNo

        ' Load settings and configure groups
        GetSettings()
        GetSettings2()

        ' Load Numbers of Owners
        OwnersMobileNumbers = GetOwnersNumbers()

        ' Configure UI dimensions

        TileViewGroups.OptionsTiles.ItemSize = New Size(_ItemsGroupWidth, _ItemsGroupHeight)
        TileViewWithImages.OptionsTiles.ItemSize = New Size(_ItemsWidth, _ItemsHeight)
        TileViewWithoutImages.OptionsTiles.ItemSize = New Size(_ItemsWidth, _ItemsHeight)
        SidePanel1.Width = _VoucherWidth

        ' Restore last document state if exists
        Dim _LastDocData = GetLasDocCodeInPosJournal()
        If _LastDocData.DocID <> 0 Then
            Me.DocCode.Text = _LastDocData.DocCode
            Me.BarStaticItemVoucherCounter.Caption = _LastDocData.DocID
            Me.LabelControlTableName.Text = _LastDocData.TableName
            Me.SearchTables.EditValue = _LastDocData.TableID

            If _ResturantMode = True Then
                If _LastDocData.TableID = 0 Then
                    ChangePosModeInResturantMode("TakeAway")
                Else
                    ChangePosModeInResturantMode("Tables")
                End If
            End If

            If _LastDocData.RefNo <> 0 Then
                Dim _RefData = GetRefranceData(_LastDocData.RefNo)
                Me.TextReferanceNo.Text = _LastDocData.RefNo
                Me.TextReferanceName.Text = _LastDocData.RefName
                Me.TextOtherAccountNo.Caption = _RefData.RefAccID
                Me.TextOtherAccountName.Caption = GetFinancialAccountsData(_RefData.RefAccID).AccName
            End If
        ElseIf _ResturantMode = True Then
            ChangePosModeInResturantMode("Tables")
        End If

        If _ResturantMode = True Then
            LayoutControlItemTitle.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            EmptySpaceItemTitle.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        End If

        GridItemsGroups.DataSource = GetItemsGroupsForPOS(My.Settings.POSNo)

        PosAddLOG(Me.DocCode.Text, "Data Loaded")
        txtBarcode.Focus()

        BarElapseTimes.Caption = $"LoadData: {stopwatch.ElapsedMilliseconds} ms"
    End Sub
    Private Function GetTablesTable() As DataTable
        Dim _table As New DataTable
        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = " select * from [PosTables] "
            sql.SqlTrueAccountingRunQuery(sqlString)
            _table = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        Return _table
    End Function
    Private Sub TileViewHoldVouchers_ItemPress(sender As Object, e As TileViewItemClickEventArgs) Handles TileViewHoldVouchers.ItemPress
        LayoutControlItemAllGroups.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        Dim _DocCode As String = If(IsDBNull(TileViewHoldVouchers.GetFocusedRowCellValue("DocCode")), CreateRandomCode(), TileViewHoldVouchers.GetFocusedRowCellValue("DocCode"))
        Me.BarStaticItemVoucherCounter.Caption = If(IsDBNull(TileViewHoldVouchers.GetFocusedRowCellValue("DocIDint")), Me.BarStaticItemVoucherCounter.Caption, TileViewHoldVouchers.GetFocusedRowCellValue("DocIDint"))
        SearchTables.EditValue = TileViewHoldVouchers.GetFocusedRowCellValue("TableID")
        LabelControlTableName.Text = TileViewHoldVouchers.GetFocusedRowCellValue("TableName")
        _HoldVoucherCode = _DocCode

        If String.IsNullOrEmpty(_HoldVoucherCode) Then Exit Sub

        If GetPOSHoldJournal(_HoldVoucherCode, SearchTables.EditValue) = 0 Then
            LayoutControlPaidOptions.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        End If
        LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        _FromTableVouchers = True
        _HoldVoucherCode = "0"
        TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
        LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never

        GridItemsGroups.Visible = True
        GetHoldVouchers(-1)
        Me.txtBarcode.Focus()
    End Sub
    Private Function GetLasDocCodeInPosJournal() As (DocCode As String, DocID As Integer, TableID As Integer, TableName As String, RefNo As Integer, RefName As String)
        Dim _DocCode As String = CreateRandomCode()
        Dim _DocID As Integer = 0
        Dim _TableID As Integer = 0
        Dim _TableName As String = ""
        Dim _RefNo As Integer = 0
        Dim _RefName As String = ""

        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = "SELECT TOP(1) DocCode, ISNULL(DocID, 0) AS DocID, ISNULL(TableID, 0) AS TableID, " &
                                 "ISNULL(Referance, 0) AS Referance, ISNULL(ReferanceName, '') AS ReferanceName " &
                                 "FROM PosJournal " &
                                 "WHERE PosNo = " & My.Settings.POSNo & " AND DeviceName = N'" & GlobalVariables.CurrDevice & "'"

            sql.SqlTrueAccountingRunQuery(sqlstring)

            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Dim row = sql.SQLDS.Tables(0).Rows(0)
                _DocCode = row("DocCode").ToString()
                _DocID = Convert.ToInt32(row("DocID"))
                _RefNo = Convert.ToInt32(row("Referance"))
                _RefName = row("ReferanceName").ToString()

                If _DocID = 0 Then
                    _DocID = GetAndIncrementVouchersCounter(GlobalVariables._ShiftID)
                End If

                _TableID = Convert.ToInt32(row("TableID"))
                If _TableID <> 0 Then
                    _TableName = GetTableName(_TableID)
                    _FromTableVouchers = True
                End If
            Else
                Me.BarStaticItemVoucherCounter.Caption = GetAndIncrementVouchersCounter(GlobalVariables._ShiftID).ToString()
            End If
        Catch ex As Exception
            PosAddLOG(Me.DocCode.Text, "Error in GetLasDocCodeInPosJournal: " & ex.Message)
            Me.BarStaticItemVoucherCounter.Caption = GetAndIncrementVouchersCounter(GlobalVariables._ShiftID).ToString()
        End Try

        Return (_DocCode, _DocID, _TableID, _TableName, _RefNo, _RefName)
    End Function

    Private Function GetTableName(_TableID As Integer) As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select TableName from PosTables where TableID=" & _TableID)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return sql.SQLDS.Tables(0).Rows(0).Item("TableName")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Async Sub GetSettings2()
        Dim posHideSaveButton As Boolean
        Dim posShowGiftButton As Boolean
        Dim posShowItlafButton As Boolean
        Dim posStretchGroupItems As Boolean
        Dim posSettings As Dictionary(Of String, String) = Await GetPOSSettingsAsync()
        GlobalVariables.ScaleComNO = posSettings("POS_ScaleComNO")
        showLastPurchasePrice = posSettings("POS_ShowLastPurchasePrice")
        showLastTransForCustomer = posSettings("POS_ShowLastTransForCustomer")
        posShowGiftButton = posSettings("PosShowGiftButton")
        posShowItlafButton = posSettings("PosShowItlafButton")
        posVoucherRoundingType = posSettings("POS_PosVoucherRoundingType")
        GlobalPosVariables._PlayBeep = posSettings("PosPlayBeep")
        posDefineNewItemInPos = posSettings("POSDefineNewItemInPos")
        posHideSaveButton = posSettings("PosHideSaveButton")
        posStretchGroupItems = posSettings("PosStretchGroupItems")
        useVoucherCounter = posSettings("PosUseVoucherCounterInsteadVoucherNo")
        posNumberOfCopies = CInt(posSettings("PosNumberOfCopies"))
        posPostVouchers = posSettings("PosPostVouchers")
        customerIsRequirdInPOS = posSettings("_POS_CustomerIsRequirdInPOS")
        sendVouchersAsTextToMobileNumbers = posSettings("POS_SendVouchersAsWhatsAppToNumbers")
        sendMessageWhenTheItemNotDefined = posSettings("POS_SendSMSWhenTheItemNotDefined")
        posAllowMinusQuantityIvVoucher = posSettings("PosAllowMinusQuantityIvVoucher")
        preventKeySubtractInPos = posSettings("POS_PreventKeySubtractInPos")
        sendVoucherToCustomer = posSettings("POS_SendVoucherToCustomer")
        sendVoucherPDFToCustomer = posSettings("POS_SendVoucherPDFToCustomer")
        posShowImagesInItemsView = posSettings("POS_PosShowImagesInItemsView")


        Me.Invoke(Sub()
                      If CBool(posShowGiftButton) = True Then
                          LayoutBtnAsGift.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                      Else
                          LayoutBtnAsGift.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                      End If
                      If CBool(posShowItlafButton) = True Then
                          LayoutBtnAsItlaf.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                      Else
                          LayoutBtnAsItlaf.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                      End If
                      If CBool(posHideSaveButton) = True Then
                          LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                      Else
                          LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                      End If
                      TileViewGroups.OptionsTiles.StretchItems = CBool(posStretchGroupItems)
                  End Sub)


    End Sub

    Private Sub GetSettings()



        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='PosVoucherNote1' ")
            _PosVoucherNote1 = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception

        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosVoucherNote2' ")
            _PosVoucherNote2 = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception

        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSItemsGroupWidth' ")
            _ItemsGroupWidth = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ItemsGroupWidth = 95
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSItemsGroupHeight' ")
            _ItemsGroupHeight = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ItemsGroupHeight = 70
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSItemsWidth' ")
            _ItemsWidth = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ItemsGroupWidth = 150
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSItemsHeight' ")
            _ItemsHeight = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _ItemsGroupHeight = 100
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSVoucherWidth' ")
            _VoucherWidth = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _VoucherWidth = 800
        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='OpenCashOnSave' ")
            _OpenCashOnSave = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _OpenCashOnSave = "False"
        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POSuseShelves' ")
            GlobalVariables._POSuseShelves = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._POSuseShelves = False
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosAllowChangeItemPrice' ")
            GlobalVariables._PosAllowChangeItemPrice = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._PosAllowChangeItemPrice = False
        End Try




        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosMaxDiscount' ")
            GlobalVariables._PosMaxDiscount = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._PosMaxDiscount = 0
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosPrintReferanceBalance' ")
            GlobalVariables._PosPrintReferanceBalance = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._PosPrintReferanceBalance = False
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosUseScales' ")
            GlobalVariables._PosUseScales = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._PosUseScales = False
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POS_ShowPosVoucherWhenSellItems' ")
            _POS_ShowPosVoucherWhenSellItems = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _POS_ShowPosVoucherWhenSellItems = True
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("  select UseDirectProduction,CostCenter from [dbo].[AccountingPOSNames] where ID=" & My.Settings.POSNo)
            _UseDirectProduction = Sql.SQLDS.Tables(0).Rows(0).Item("UseDirectProduction")
        Catch ex As Exception
            _UseDirectProduction = "False"
        End Try



        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosShowRadialMenu'")
            _PosShowRadialMenu = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If _PosShowRadialMenu = True Then
                BarSubAccountingMenue.Visibility = XtraBars.BarItemVisibility.Always
            Else
                BarSubAccountingMenue.Visibility = XtraBars.BarItemVisibility.Never
            End If
        Catch ex As Exception
            MsgBox("Err: PosShowRadialMenu")
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Shalash'")
            shalashCo = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If shalashCo = True Then
                LayoutControlItemCarNo.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemChassiNo.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                TabbedControlGroupAllScreens.SelectedTabPage = TabCustomersCarsParts
                TabCustomersCarsParts.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlGroupCar.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            Else
                LayoutControlItemCarNo.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                LayoutControlItemChassiNo.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If
        Catch ex As Exception
            MsgBox("Err: PosShowRadialMenu")
        End Try


        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='POS_ShowPosVoucherWhenSellItems' ")
            _POS_ShowPosVoucherWhenSellItems = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _POS_ShowPosVoucherWhenSellItems = True
        End Try

        '------------------



        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPostVouchers'")
        '    posPostVouchers = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosPostVouchers")
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosNumberOfCopies'")
        '    _PosNumberOfCopies = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    _PosNumberOfCopies = 1
        '    ' MsgBox("Err: PosPostVouchers")
        'End Try


        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosUseVoucherCounterInsteadVoucherNo'")
        '    _UseVoucherCounter = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosPostVouchers")
        '    _UseVoucherCounter = True
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosStretchGroupItems'")
        '    If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = False Then
        '        TileViewGroups.OptionsTiles.StretchItems = False
        '    End If
        'Catch ex As Exception
        'End Try




        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosHideSaveButton'")
        '    If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
        '        LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    Else
        '        LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        '    End If
        '    'LayoutItemSaveButtom
        'Catch ex As Exception
        '    MsgBox("Err: PosPostVouchers")
        '    _UseVoucherCounter = True
        'End Try

        '_ShowDocNoteByAccountInPosVoucher = True


        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POSDefineNewItemInPos'")
        '    posDefineNewItemInPos = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    ' MsgBox("Err: PosPostVouchers")
        '    posDefineNewItemInPos = False
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPlayBeep'")
        '    GlobalPosVariables._PlayBeep = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    ' MsgBox("Err: PosPostVouchers")
        '    GlobalPosVariables._PlayBeep = True
        'End Try



        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosRoundVoucherNearInteger'")
        '    posRoundVoucherNearInteger = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    ' MsgBox("Err: PosPostVouchers")
        '    posRoundVoucherNearInteger = True
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosRoundVoucherToDownInteger'")
        '    _PosRoundVoucherToDownInteger = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    ' MsgBox("Err: PosPostVouchers")
        '    _PosRoundVoucherToDownInteger = True
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosShowItlafButton'")
        '    If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
        '        LayoutBtnAsItlaf.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        '    Else
        '        LayoutBtnAsItlaf.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    End If
        'Catch ex As Exception
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosShowGiftButton'")
        '    If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
        '        LayoutBtnAsGift.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        '    Else
        '        LayoutBtnAsGift.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    End If
        'Catch ex As Exception
        'End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='_POS_CustomerIsRequirdInPOS'")
        '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
        '        customerIsRequirdInPOS = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        '    Else
        '        customerIsRequirdInPOS = False
        '    End If
        'Catch ex As Exception
        '    customerIsRequirdInPOS = False
        'End Try


        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POS_SendVoucherPDFToCustomer'")
        '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
        '        sendVoucherPDFToCustomer = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        '    Else
        '        sendVoucherPDFToCustomer = False
        '    End If
        'Catch ex As Exception
        '    sendVoucherPDFToCustomer = False
        'End Try


        Try
            Sql.SqlTrueAccountingRunQuery("SELECT Kitchen_printer, DefaultPrinter,
                                                  IsNull(ItemsViewTemplateName,'TileViewWithImages') as ItemsViewTemplateName,
                                                  IsNull(ResturantMode,0) As ResturantMode,
                                                  IsNull(PrintVoucherByItemGroup,0) As PrintVoucherByItemGroup,IsNull(CostCenter,0) As CostCenter,
                                                IsNull([POSName],'') As PosName
                                           FROM [dbo].[AccountingPOSNames] 
                                           WHERE [ID]='" & My.Settings.POSNo & "'")
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Kitchen_printer")) Then
                _KitchenPrinter = Sql.SQLDS.Tables(0).Rows(0).Item("Kitchen_printer")
            Else
                _KitchenPrinter = ""
            End If
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DefaultPrinter")) Then
                _DefaultPrinterPOS = Sql.SQLDS.Tables(0).Rows(0).Item("DefaultPrinter")
            Else
                _DefaultPrinterPOS = ""
            End If

            _ItemsViewTemplateName = Sql.SQLDS.Tables(0).Rows(0).Item("ItemsViewTemplateName")
            _PrintVoucherByItemGroup = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("PrintVoucherByItemGroup"))
            _ResturantMode = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("ResturantMode"))
            _CostCenter = Int(Sql.SQLDS.Tables(0).Rows(0).Item("CostCenter"))
            Me.BarCostCenter.Caption = "مركز التكلفة: " & _CostCenter
        Catch ex As Exception
            _KitchenPrinter = ""
            _DefaultPrinterPOS = ""
            _ItemsViewTemplateName = "TileViewWithImages"
            _PrintVoucherByItemGroup = False
            _ResturantMode = False
        End Try




        Try
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POS_SortItemsByItemName'")
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                _POS_SortItemsByItemName = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Else
                _POS_SortItemsByItemName = False
            End If
        Catch ex As Exception
            _POS_SortItemsByItemName = False
        End Try





        Try
            Sql.SqlTrueAccountingRunQuery("  select ItemsViewTemplateName from [dbo].[AccountingPOSNames] where ID=" & My.Settings.POSNo)
            _UseDirectProduction = Sql.SQLDS.Tables(0).Rows(0).Item("UseDirectProduction")
        Catch ex As Exception
            _UseDirectProduction = "False"
        End Try

        'Try
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POS_PrintVoucherByItemGroup'")
        '    _PrintVoucherByItemGroup = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    _PrintVoucherByItemGroup = False
        'End Try







        Try
            Dim cn As SqlConnection
            cn = New SqlConnection With {
                .ConnectionString = My.Settings.TrueTimeConnectionString
            }
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            Me.CompanyLogo.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

        Try
            Dim cn As SqlConnection
            cn = New SqlConnection With {
                .ConnectionString = My.Settings.TrueTimeConnectionString
            }
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyQR from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            Me.PictureEditCompanyQR.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

        PosAddLOG(Me.DocCode.Text, "Settings Loaded")

    End Sub
    Public Async Function GetPOSSettingsAsync() As Task(Of Dictionary(Of String, String))
        Dim defaultValues As New Dictionary(Of String, String) From {
        {"POS_ScaleComNO", "4"},
        {"POS_ShowLastPurchasePrice", "False"},
        {"POS_ShowLastTransForCustomer", "False"},
        {"POS_SendVoucherToCustomer", "False"},
        {"POS_SendVoucherPDFToCustomer", "False"},
        {"_POS_CustomerIsRequirdInPOS", "False"},
        {"PosShowGiftButton", "False"},
        {"PosShowItlafButton", "False"},
        {"POS_PosVoucherRoundingType", "RoundToNearestHalf"},
        {"PosPlayBeep", "True"},
        {"POSDefineNewItemInPos", "False"},
        {"PosHideSaveButton", "False"},
        {"PosStretchGroupItems", "False"},
        {"PosUseVoucherCounterInsteadVoucherNo", "True"},
        {"PosNumberOfCopies", "1"},
        {"PosPostVouchers", "True"},
        {"PosShowRadialMenu", "0"},
        {"POS_ShowPosVoucherWhenSellItems", "0"},
        {"PosUseScales", "0"},
        {"PosPrintReferanceBalance", "0"},
        {"POS_SendVouchersAsWhatsAppToNumbers", "False"},
        {"POS_SendSMSWhenTheItemNotDefined", "False"},
        {"PosAllowMinusQuantityIvVoucher", "False"},
        {"POS_PreventKeySubtractInPos", "False"},
        {"POS_PosShowImagesInItemsView", "False"}
    }

        Dim settings As New Dictionary(Of String, String)()
        Dim connectionString As String = My.Settings.TrueTimeConnectionString

        ' Build a query that retrieves only the specified settings.
        Dim inClause As String = String.Join(",", defaultValues.Keys.Select(Function(key) "'" & key & "'"))
        Dim query As String = "SELECT SettingName, SettingValue FROM [dbo].[Settings] " &
                          "WHERE SettingName IN (" & inClause & ")"

        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    Await connection.OpenAsync()
                    Using reader As SqlDataReader = Await command.ExecuteReaderAsync() ' Use Await for async data reading
                        While Await reader.ReadAsync()
                            Dim settingName As String = reader("SettingName").ToString()
                            Dim settingValue As String = reader("SettingValue").ToString()
                            settings(settingName) = settingValue
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed.
            Throw New ApplicationException("Error fetching POS settings.", ex)
        End Try

        ' Ensure all expected settings have a value; assign default value if missing.
        For Each key As String In defaultValues.Keys
            If Not settings.ContainsKey(key) Then
                settings(key) = defaultValues(key)
            End If
        Next

        Return settings
    End Function

    Private Sub SetIcons()
        If Me.IsHandleCreated = False Then
            For Each navButton As WindowsUIButton In WindowsUIButtonPanel2.Buttons
                Select Case navButton.Tag
                    Case "Save"
                        navButton.ImageUri = "Save"
                    Case "Print"
                        navButton.ImageUri = "Print"
                    Case "Currency"
                        navButton.ImageUri = "Currency"
                    Case "Pin"
                        navButton.ImageUri = "dashboards/unpinbutton"
                    Case "Discount"
                        navButton.ImageUri = "unlike"
                    Case "Note"
                        navButton.ImageUri = "business%20objects/bo_note"
                End Select
            Next navButton
            WindowsUIButtonPanel2.Buttons.Insert(0, New WindowsUISeparator())
            WindowsUIButtonPanel2.Buttons.Insert(2, New WindowsUISeparator())
            WindowsUIButtonPanel2.Buttons.Insert(4, New WindowsUISeparator())
            WindowsUIButtonPanel2.Buttons.Insert(8, New WindowsUISeparator())
        End If
    End Sub


    Private Sub CenterCaption()
        Dim g As Graphics = Me.CreateGraphics()
        Dim startingPoint As Double = (Me.Width / 2) - (g.MeasureString(Me.Text.Trim, Me.Font).Width / 2)
        Dim widthOfASpace As Double = g.MeasureString(" ", Me.Font).Width
        Dim tmp As String = " "
        Dim tmpWidth As Double = 0
        Do
            tmp += " "
            tmpWidth += widthOfASpace
        Loop While (tmpWidth + widthOfASpace) < startingPoint

        Me.Text = tmp & Me.Text.Trim & tmp

        Me.Refresh()
    End Sub

    Private Sub PosRestCashier_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Handle function key operations (F1-F12)
        If HandleFunctionKeys(e.KeyCode) Then
            Return
        End If

        ' Handle keyboard shortcuts with modifiers
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.R
                    NewReceipt()
                    Return

                Case Keys.P
                    PrintLastVoucher()
                    Return
            End Select
        End If

        ' Handle arithmetic operations
        If Me.txtBarcode.Text = "" Then
            Select Case e.KeyCode
                'Case Keys.Add
                '    PosAddLOG(Me.DocCode.Text, "Press Add")
                '    e.Handled = True
                '    AddOrSubtractQauntity("Add")
                '    Me.txtBarcode.Text = ""
                'Case Keys.Subtract
                '    PosAddLOG(Me.DocCode.Text, "Press Subtract")
                '    e.Handled = True
                '    AddOrSubtractQauntity("Subtract")
                '    Me.txtBarcode.Text = ""
                Case Keys.Delete
                    PosAddLOG(Me.DocCode.Text, "Press Delete")
                    e.Handled = True
                    Dim selectedID As Object = TileView2.GetFocusedRowCellValue("ID")
                    DeleteRowFromPOSVoucher(selectedID)
            End Select
        End If

    End Sub

    Private Function HandleFunctionKeys(keyCode As Keys) As Boolean
        Select Case keyCode
            Case Keys.F1
                ShowItemslist()

            Case Keys.F2
                PosAddLOG(Me.DocCode.Text, "Press F2")
                PosPrintVoucherEmpty()

            Case Keys.F3
                PosAddLOG(Me.DocCode.Text, "Press F3")
                CheckPrint.Checked = False
                SaveToJournal()

            Case Keys.F4
                PosAddLOG(Me.DocCode.Text, "Press F4")
                CheckPrint.Checked = True
                SaveToJournal()

            Case Keys.F5
                PosAddLOG(Me.DocCode.Text, "Press F5")
                ShowCashBox()

            Case Keys.F6
                PosAddLOG(Me.DocCode.Text, "Press F6")
                ShowDiscountDialog()

            Case Keys.F7
                PosAddLOG(Me.DocCode.Text, "Press F7")
                AddNoteToVoucher()

            Case Keys.F8
                PosAddLOG(Me.DocCode.Text, "Press F8")
                RetuenSalesMode()

            Case Keys.F9
                PosAddLOG(Me.DocCode.Text, "Press F9")
                HoldVoucher()

            Case Keys.F10
                HandleF10Reports()
            Case Keys.F11
                ShowKeyboard()

            Case Keys.F12
                PosAddLOG(Me.DocCode.Text, "Press F12")
                ShowRadialMenuIfEnabled()

            Case Else
                Return False
        End Select

        Return True
    End Function

    Private Sub ShowDiscountDialog()
        Dim F As New PosAddDiscountOnVoucher
        With F
            .TextVoucherAmountAfterDiscount.EditValue = TextVoucherAmount.EditValue
            .TextVoucherAmount.EditValue = TextVoucherAmount.EditValue
            .TextVoucherCode.Text = Me.DocCode.Text
            If .ShowDialog() <> DialogResult.OK Then
                GetPosJournalTable()
            End If
        End With
    End Sub

    Private Sub ShowRadialMenuIfEnabled()
        If _PosShowRadialMenu Then
            If RadialMenu1 IsNot Nothing Then
                Dim pt As Point = Me.Location
                pt.Offset(Me.Width \ 2, Me.Height \ 2)
                RadialMenu1.ShowPopup(pt)
            End If
        End If
    End Sub


    Private Sub HandleF10Reports()
        ' If reports tab is already visible, hide it and return to items tab
        If TabDailyReport.Visibility = XtraLayout.Utils.LayoutVisibility.Always Then
            TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
            TabDailyReport.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            TabDailyReportGrid.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            Return
        End If

        ' Get password from settings
        Dim posReportsPassword As String = ""
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [SettingValue] FROM [dbo].[Settings] WHERE [SettingName]='POS_PasswordForPosReports'")
            posReportsPassword = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").ToString()
        Catch ex As Exception
            posReportsPassword = ""
        End Try

        ' If password is required, prompt for it
        If Not String.IsNullOrEmpty(posReportsPassword) Then
            Dim args As New XtraInputBoxArgs() With {
            .Caption = "Reports Access",
            .Prompt = "Enter Password",
            .DefaultResponse = ""
        }

            Dim editor As New TextEdit()
            editor.Properties.UseSystemPasswordChar = True
            args.Editor = editor

            Dim password As String = XtraInputBox.Show(args)

            ' If password matches, show reports tab
            If password = posReportsPassword Then
                ShowReportsTab()
            End If
        Else
            ' No password required, show reports directly
            ShowReportsTab()
        End If
    End Sub

    Private Sub ShowReportsTab()
        TabDailyReport.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        TabDailyReportGrid.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        TabbedControlGroupAllScreens.SelectedTabPage = TabDailyReport
    End Sub

    'Prints the last saved voucher using stored voucher code
    Private Sub PrintLastVoucher()
        ' Check if we have a last voucher code
        If String.IsNullOrEmpty(GlobalPosVariables._LastVoucherCode) Then
            MsgBoxShowError("لا يوجد فاتورة سابقة للطباعة")
            PosAddLOG(Me.DocCode.Text, "Print Last Voucher - No Last Voucher Found")
            Return
        End If

        Try
            ' Log the action
            PosAddLOG(Me.DocCode.Text, "Print Last Voucher: " & GlobalPosVariables._LastVoucherCode)

            ' Print the voucher
            PosFunctions.PrintPosVoucherFromDataBase(GlobalPosVariables._LastVoucherCode, False)

            ' Give user feedback
            BarElapseTimes.Caption = "تمت طباعة الفاتورة السابقة"
        Catch ex As Exception
            MsgBoxShowError("حدث خطأ أثناء طباعة الفاتورة: " & ex.Message)
            PosAddLOG(Me.DocCode.Text, "Error printing last voucher: " & ex.Message)
        End Try
    End Sub

    Private Sub GridItemsCategories_Click(sender As Object, e As EventArgs) Handles GridItemsGroups.Click, GridItemsGroups.DoubleClick
        txtBarcode.Focus()
    End Sub

    Private Sub RefreshItems(WithGroup As Boolean)
        Dim _Group As String = TileViewGroups.GetFocusedRowCellValue("GroupID")
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = ""

            Select Case posShowImagesInItemsView
                Case True
                    SqlString = " SELECT   [ItemNo],[ItemName],U.[name] As UnitName
	                              ,IU.Price1 As UnitPrice,IU.[unit_id],C.GroupName
	                              ,I.ItemImage,I.[AccSales],I.[SaleOnScale]
                                  ,[item_unit_bar_code] as Barcode,I.WithAdditions,I.RequirePriceInPOS,IsNull(BarcodesCount ,0) as BarcodesCount 
                          FROM [Items] I
                          left join Items_units IU On I.ItemNo=IU.item_id
                          left Join Units U on U.id=IU.unit_id
                          left Join [dbo].[ItemsGroups] C on C.GroupID=I.GroupID
                          where [main_unit]=1 and [ItemStatus]=1 AND ([VisibleInPOS] = 1 OR [VisibleInPOS] IS NULL) "
                    If WithGroup = True Then SqlString += "and I.[GroupID]='" & _Group & "'"
                    If _POS_SortItemsByItemName = False Then
                        SqlString += " order by ItemNo  "
                    Else
                        SqlString += " order by ItemName  "
                    End If
                Case False
                    SqlString = " SELECT   [ItemNo],[ItemName],U.[name] As UnitName
	                              ,IU.Price1 As UnitPrice,IU.[unit_id],C.GroupName
	                              ,I.[AccSales],I.[SaleOnScale]
                                  ,[item_unit_bar_code] as Barcode,I.WithAdditions,I.RequirePriceInPOS,IsNull(BarcodesCount ,0) as BarcodesCount 
                          FROM [Items] I
                          left join Items_units IU On I.ItemNo=IU.item_id
                          left Join Units U on U.id=IU.unit_id
                          left Join [dbo].[ItemsGroups] C on C.GroupID=I.GroupID
                          where [main_unit]=1 and [ItemStatus]=1 AND ([VisibleInPOS] = 1 OR [VisibleInPOS] IS NULL) "
                    If WithGroup = True Then SqlString += "and I.[GroupID]='" & _Group & "'"
                    If _POS_SortItemsByItemName = False Then
                        SqlString += " order by ItemNo  "
                    Else
                        SqlString += " order by ItemName  "
                    End If
            End Select




            sql.SqlTrueAccountingRunQuery(SqlString)
            GridItems.DataSource = sql.SQLDS.Tables(0)
            'SearchFindItem.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        PosAddLOG(Me.DocCode.Text, "Items Refreashed")
        txtBarcode.Focus()
    End Sub
    Private Sub WindowsUIButtonPanel2_ButtonChecked(ByVal sender As Object, ByVal e As ButtonEventArgs) Handles WindowsUIButtonPanel2.ButtonClick, WindowsUIButtonPanel2.DoubleClick
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag
            Case "Save"
                PosAddLOG(Me.DocCode.Text, "Press Save ")
                CheckPrint.Checked = False
                SaveToJournal()
            Case "Cancel"
                PosAddLOG(Me.DocCode.Text, "Press Cancel ")
                ClearAllRows()
            Case "Print"
                PosAddLOG(Me.DocCode.Text, "Press Print ")
                CheckPrint.Checked = True
                SaveToJournal()
            Case "CashBox"
                PosAddLOG(Me.DocCode.Text, "Press CashBox ")
                ShowCashBox()
            Case "Note"
                PosAddLOG(Me.DocCode.Text, "Press Note ")
                AddNoteToVoucher()
            Case "Discount"
                PosAddLOG(Me.DocCode.Text, "Press Discount ")
                Dim F As New PosAddDiscountOnVoucher
                With F
                    .TextVoucherAmountAfterDiscount.EditValue = TextVoucherAmount.EditValue
                    .TextVoucherAmount.EditValue = TextVoucherAmount.EditValue
                    .TextVoucherCode.Text = Me.DocCode.Text
                    If .ShowDialog() <> DialogResult.OK Then
                        '   _DiscountVoucherAmount = .TextVoucherAmountAfterDiscount.EditValue
                        '  AllocateDiscount()
                        GetPosJournalTable()
                    End If
                End With
            Case "Return"
                PosAddLOG(Me.DocCode.Text, "Press Return ")
                RetuenSalesMode()
            Case "Hold"
                PosAddLOG(Me.DocCode.Text, "Press Hold ")
                HoldVoucher()
        End Select
    End Sub
    Private Sub AddNoteToVoucher()
        Dim F As New PosVoucherNote(My.Settings.POSNo, Me.DocCode.Text)
        With F
            .MemoEdit1.Text = _PosVoucherNote
            .MemoEdit1.Select()
            .ShowDialog()
        End With
        PosAddLOG(Me.DocCode.Text, "Note On Voucher Added")
        txtBarcode.Focus()
    End Sub

    Private Sub RetuenSalesMode()
        ' Retrieve password settings from database
        Dim posCloseShiftPassword As String = ""
        Dim posCloseShiftPassword2 As String = ""

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [SettingValue] FROM [dbo].[Settings] WHERE [SettingName]='PosCloseShiftPassword'")
            posCloseShiftPassword = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            ' Continue with empty password if setting not found
        End Try

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT [SettingValue] FROM [dbo].[Settings] WHERE [SettingName]='PosCloseShiftPassword2'")
            posCloseShiftPassword2 = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            ' Continue with empty password if setting not found
        End Try

        ' Handle mode switching based on current mode
        Select Case DocName.EditValue
            Case 12 ' Return mode -> Regular sales mode
                ' Update accounting entries in journal if there are items
                If GridPosVoucher.MainView.RowCount > 0 Then
                    Dim sql As New SQLControl
                    sql.SqlTrueAccountingRunQuery("UPDATE t1
                                             SET t1.CredAcc = t2.AccSales, 
                                                 t1.DebitAcc = '0', 
                                                 t1.[StockCreditWhereHouse] = " & _DefaultWharehouse & ",
                                                 t1.[StockDebitWhereHouse] = 0
                                             FROM POSJournal t1
                                             JOIN Items t2 ON t1.StockID = t2.ItemNo
                                             WHERE t1.PosNo = " & _PosNo & " 
                                             AND t1.DeviceName = '" & GlobalVariables.CurrDevice & "'")
                End If

                ' Update UI for sales mode
                LayoutControl1.BackColor = Color.White
                DocName.EditValue = 2

                ' Format amount display
                Dim formatString As String = "{0} {1} {2}"
                Dim displayFormat As String = String.Format(formatString, " الصافي للدفع: ", "#,##0.0", " شيكل ")
                With TexVouchertAmountAfterDiscount.Properties.Mask
                    .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                    .EditMask = displayFormat
                    .UseMaskAsDisplayFormat = True
                End With

                PosAddLOG(Me.DocCode.Text, "Document From Return To Voucher")

            Case 2 ' Regular sales mode -> Return mode
                ' Update accounting entries in journal if there are items
                If GridPosVoucher.MainView.RowCount > 0 Then
                    Dim sql As New SQLControl
                    sql.SqlTrueAccountingRunQuery("UPDATE t1
                                             SET t1.DebitAcc = t2.AccRetSales, 
                                                 t1.CredAcc = '0',
                                                 t1.[StockDebitWhereHouse] = " & _DefaultWharehouse & ",
                                                 t1.[StockCreditWhereHouse] = 0
                                             FROM POSJournal t1
                                             JOIN Items t2 ON t1.StockID = t2.ItemNo
                                             WHERE t1.PosNo = " & _PosNo & " 
                                             AND t1.DeviceName = '" & GlobalVariables.CurrDevice & "'")
                End If

                ' Check if password is required
                If String.IsNullOrEmpty(posCloseShiftPassword) AndAlso String.IsNullOrEmpty(posCloseShiftPassword2) Then
                    ' No password required, switch directly
                    LayoutControl1.BackColor = Color.FromArgb(255, 80, 0)
                    DocName.EditValue = 12
                Else
                    ' Password required
                    Dim arg As New XtraInputBoxArgs()
                    Dim editor As New TextEdit
                    With editor.Properties
                        .UseSystemPasswordChar = True
                    End With

                    With arg
                        .Editor = editor
                        .Caption = "Extra Tools"
                        .Prompt = "Enter Password"
                        .DefaultResponse = String.Empty
                    End With

                    Dim passkey As String = XtraInputBox.Show(arg)
                    If String.IsNullOrEmpty(passkey) Then Exit Sub

                    If passkey = posCloseShiftPassword OrElse passkey = posCloseShiftPassword2 Then
                        LayoutControl1.BackColor = Color.FromArgb(255, 80, 0)
                        DocName.EditValue = 12
                    Else
                        XtraMessageBox.Show("Authentication Error")
                        Exit Sub
                    End If
                End If

                ' Format amount display for return mode
                Dim formatString As String = "{0} {1} {2}"
                Dim displayFormat As String = String.Format(formatString, " الصافي للارجاع: ", "#,##0.0", " شيكل ")
                With TexVouchertAmountAfterDiscount.Properties.Mask
                    .MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                    .EditMask = displayFormat
                    .UseMaskAsDisplayFormat = True
                End With

                PosAddLOG(Me.DocCode.Text, "Document From Voucher To Return")
        End Select

        txtBarcode.Focus()
    End Sub

    Private Sub ShowCashBox()

        ' Check if grid has rows
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Case "TileView2"
                If TileView2.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
        End Select

        Dim posCashBox = My.Forms.PosCashBox

        ' Set default values for the cash box
        posCashBox.TextDefaultCashAccount.Text = _DefaultBaseCashAccount
        posCashBox.TextVoucherAmount.EditValue = TexVouchertAmountAfterDiscount.EditValue
        posCashBox.BarAccountNo.Caption = TextOtherAccountNo.Caption
        posCashBox.BarAccountName.Caption = TextOtherAccountName.Caption
        posCashBox.BarRefNo.Caption = Me.TextReferanceNo.Text
        posCashBox.BarRefName.Caption = Me.TextReferanceName.Text

        ' Set the title based on the reference number
        If Me.TextReferanceNo.Text = "0" Then
            posCashBox.LabelControlTitle.Text = " مبيعات نقدية "
            posCashBox.TextPaid.EditValue = TexVouchertAmountAfterDiscount.EditValue
        Else
            posCashBox.LabelControlTitle.Text = " مبيعات ذمم للزبون " & " " & Me.TextReferanceName.Text
            posCashBox.ButtonSave.Enabled = True
            posCashBox.ButtonSaveAndPrint.Enabled = True
        End If

        ' Show the cash box dialog and handle the result
        If posCashBox.ShowDialog() <> DialogResult.OK AndAlso TextReady.Text <> "No" Then
            _FromTableVouchers = False

            If _ResturantMode Then
                LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            End If

            ' Update account and reference details
            TextOtherAccountNo.Caption = posCashBox.BarAccountNo.Caption
            TextReferanceNo.Text = posCashBox.BarRefNo.Caption
            TextReferanceName.Text = posCashBox.BarRefName.Caption
            If IsNumeric(posCashBox.BarCashCustomerID.Caption) Then
                cashCustomerId = CInt(posCashBox.BarCashCustomerID.Caption)
            Else
                cashCustomerId = 0
            End If
            SaveToJournal()
        Else

        End If

        ' Log the action and refocus on the barcode input
        PosAddLOG(Me.DocCode.Text, "Show Cash Box")
        txtBarcode.Focus()
    End Sub

    Private Sub Args_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
        e.Form.Icon = Me.Icon
    End Sub
    Public Class LoginUserControl
        Inherits XtraUserControl
        Public Sub New()
            Dim lc As New LayoutControl With {
                .Dock = DockStyle.Fill
            }
            Dim TextNote As New TextEdit()
            Dim separatorControl As New SeparatorControl()
            lc.AddItem(String.Empty, TextNote)
            Me.Controls.Add(lc)
            Me.Height = 100
            Me.Dock = DockStyle.Fill
        End Sub
    End Class

    Private Sub RefreshData()
        LoadData()
        GridItemsGroups.DataSource = GetItemsGroupsForPOS(My.Settings.POSNo)
        PosAddLOG(Me.DocCode.Text, "RefreshData ")
    End Sub
    Private Function GetItemsGroupsForPOS(_PosNo As Integer) As DataTable
        Dim _Table As New DataTable
        Dim _Groups As String
        PosAddLOG(Me.DocCode.Text, "GetItemsGroupsForPOS ")
        Try
            Dim Sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "SELECT IsNull([ItemsGroups],0) As ItemsGroups  
                                            FROM [dbo].[AccountingPOSNames] 
                                            Where ID=" & _PosNo
            Sql.SqlTrueAccountingRunQuery(sqlstring)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _Groups = Sql.SQLDS.Tables(0).Rows(0).Item("ItemsGroups")
            Else
                _Groups = "0"
            End If
        Catch ex As Exception
            _Groups = "0"
        End Try

        If _Groups <> "0" Then
            Try
                Dim Sql2 As New SQLControl
                Dim sqlstring As String
                sqlstring = "select GroupID,GroupName,AvailableOnPOS,GroupImage 
                                            from [ItemsGroups] 
                                            where AvailableOnPOS=1 And GroupID in (" & _Groups & ")"
                Sql2.SqlTrueAccountingRunQuery(sqlstring)
                _Table = Sql2.SQLDS.Tables(0)
            Catch ex As Exception
                Return _Table
            End Try
        Else
            Try
                Dim Sql As New SQLControl
                Sql.SqlTrueAccountingRunQuery(" select GroupID,GroupName,AvailableOnPOS,GroupImage 
                                                from [ItemsGroups] 
                                                where AvailableOnPOS=1 ")
                _Table = Sql.SQLDS.Tables(0)
            Catch ex As Exception
                Return _Table
            End Try
        End If


        Return _Table
    End Function
    ' كود جلب الصنف ند الضغط على زر الصنف
    Private Sub GridItemsClick()
        PosAddLOG(Me.DocCode.Text, "GridItemsClick ")
        '   MsgBox(GridItems.MainView.ViewCaption)
        Dim _SaleOnScale As Boolean = False
        Dim _Barcode As String = "0"
        Dim _ItemNo As String = "0"
        Dim _Quantity As Decimal = 1
        Dim _WithAdditions As Boolean = False
        Dim _RequirePriceInPOS As Boolean = False
        Dim _BarcodesCount As Integer = 0
        Dim _ItemPrice As Decimal = 0
        Dim _ItemName As String = ""
        Select Case GridItems.MainView.ViewCaption
            Case "TileViewWithImages"
                _Barcode = TileViewWithImages.GetFocusedRowCellValue("Barcode")
                _ItemNo = TileViewWithImages.GetFocusedRowCellValue("ItemNo")
                _ItemName = TileViewWithImages.GetFocusedRowCellValue("ItemName")
                If Not IsDBNull(TileViewWithImages.GetFocusedRowCellValue("SaleOnScale")) Then
                    _SaleOnScale = TileViewWithImages.GetFocusedRowCellValue("SaleOnScale")
                End If
                _WithAdditions = TileViewWithImages.GetFocusedRowCellValue("WithAdditions")
                _RequirePriceInPOS = TileViewWithImages.GetFocusedRowCellValue("RequirePriceInPOS")
                _ItemPrice = TileViewWithImages.GetFocusedRowCellValue("UnitPrice")
                _BarcodesCount = CInt(TileViewWithImages.GetFocusedRowCellValue("BarcodesCount"))
            Case "TileViewWithoutImages"
                _Barcode = TileViewWithoutImages.GetFocusedRowCellValue("Barcode")
                _ItemNo = TileViewWithoutImages.GetFocusedRowCellValue("ItemNo")
                _ItemName = TileViewWithoutImages.GetFocusedRowCellValue("ItemName")
                If Not IsDBNull(TileViewWithoutImages.GetFocusedRowCellValue("SaleOnScale")) Then
                    _SaleOnScale = TileViewWithoutImages.GetFocusedRowCellValue("SaleOnScale")
                End If
                _WithAdditions = TileViewWithoutImages.GetFocusedRowCellValue("WithAdditions")
                _RequirePriceInPOS = TileViewWithoutImages.GetFocusedRowCellValue("RequirePriceInPOS")
                _ItemPrice = TileViewWithoutImages.GetFocusedRowCellValue("UnitPrice")
                _BarcodesCount = CInt(TileViewWithoutImages.GetFocusedRowCellValue("BarcodesCount"))
            Case "WinExplorerItems"
                _Barcode = WinExplorerViewItems.GetFocusedRowCellValue("Barcode")
                _ItemNo = WinExplorerViewItems.GetFocusedRowCellValue("ItemNo")
                _ItemName = WinExplorerViewItems.GetFocusedRowCellValue("ItemName")
                If Not IsDBNull(WinExplorerViewItems.GetFocusedRowCellValue("SaleOnScale")) Then
                    _SaleOnScale = WinExplorerViewItems.GetFocusedRowCellValue("SaleOnScale")
                End If
                _WithAdditions = WinExplorerViewItems.GetFocusedRowCellValue("WithAdditions")
                _RequirePriceInPOS = WinExplorerViewItems.GetFocusedRowCellValue("RequirePriceInPOS")
                _ItemPrice = WinExplorerViewItems.GetFocusedRowCellValue("UnitPrice")
                _BarcodesCount = CInt(WinExplorerViewItems.GetFocusedRowCellValue("BarcodesCount"))
        End Select

        If _SaleOnScale = True Then
            GlobalVariables._TempWeight = 0
            Select Case GridItems.MainView.ViewCaption
                Case "TileViewWithImages"
                    POSGetItemWeight.TextPrice.EditValue = TileViewWithImages.GetFocusedRowCellValue("UnitPrice")
                    POSGetItemWeight.TextItemName.Text = TileViewWithImages.GetFocusedRowCellValue("ItemName")
                Case "TileViewWithoutImages"
                    POSGetItemWeight.TextPrice.EditValue = TileViewWithoutImages.GetFocusedRowCellValue("UnitPrice")
                    POSGetItemWeight.TextItemName.Text = TileViewWithoutImages.GetFocusedRowCellValue("ItemName")
            End Select
            PosFunctions.PlaySuccessBeepOnPos()
            POSGetItemWeight.ShowDialog()
            Try
                If GlobalVariables._TempWeight = -1 Then
                    Return
                Else
                    _Quantity = GlobalVariables._TempWeight
                End If
            Catch ex As Exception
                _Quantity = 1
            End Try
        Else
            _Quantity = 1
        End If
        '  _NoteFromAddtions = ""
        If _WithAdditions = True And _SaleOnScale = False Then
            'GridItems.Visible = False
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" Select [ID],[ItemNo],[PortionName],[ItemPrice],N'" & _Barcode & "' As StockBarcode,case when [AddOrRemove]='-1' then N'بدون' else N'اضافة' end as [AddOrRemove],'False' as IsSelected from ItemsPortions where ItemNo=" & _ItemNo)
            If sql.SQLDS.Tables(0).Rows.Count <> 0 Then
                GridPortions.DataSource = sql.SQLDS.Tables(0)
                TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupAdditionsTab
                Me.TextItemPriceInPortionScreen.EditValue = _ItemPrice
                SimpleLabelItemItemName.Text = _ItemName
                ' LayoutControlItemsPortions.Visibility = XtraLayout.Utils.LayoutVisibility.Always

            Else
                If InsertIntoPOSJournalByStoredProcedure(_Barcode, DocName.EditValue, _Quantity, _DefaultWharehouse, Me.DocCode.Text, Me.TextReferanceNo.EditValue, _ItemNo, 0, 0, "") > 0 Then
                    PosFunctions.PlaySuccessBeepOnPos()
                End If
                GetPosJournalTable()
                GridItems.Visible = True
                txtBarcode.Focus()
            End If
        ElseIf _BarcodesCount > 1 And _SaleOnScale = False Then
            'GridItems.Visible = False
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" Select IU.id as ID , ItemNo,ItemName,IU.item_unit_bar_code as Barcode,IU.Price1 as ItemPrice,U.name as UnitName  
                                      From [dbo].[Items] I 
                                      Left Join Items_units IU on I.ItemNo=IU.item_id 
                                      Left Join Units U on U.id=IU.unit_id 
                                      Where ItemNo=" & _ItemNo)
            If sql.SQLDS.Tables(0).Rows.Count <> 0 Then
                GridControlUnitsForItem.DataSource = sql.SQLDS.Tables(0)
                TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                TabUnitsForItem.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                TabbedControlGroupAllScreens.SelectedTabPage = TabUnitsForItem
                SimpleLabelUnitsForItem.Text = _ItemName
                ' LayoutControlItemsPortions.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            End If
        Else
            Dim _RowID As Integer
            _RowID = InsertIntoPOSJournalByStoredProcedure(_Barcode, DocName.EditValue, _Quantity, _DefaultWharehouse, Me.DocCode.Text, Me.TextReferanceNo.EditValue, _ItemNo, 0, 0, "")
            If _RowID > 0 Then
                PosFunctions.PlaySuccessBeepOnPos()
            End If
            If _RequirePriceInPOS = True Then
                Dim F As New PosEditPrice(_ItemNo, _ItemPrice, _RowID)
                With F
                    .ShowDialog()
                End With
            End If
            GetPosJournalTable()
            GridItems.Visible = True
            txtBarcode.Focus()
        End If


    End Sub

    Private Sub TextBarcode_Enter(sender As Object, e As EventArgs) Handles txtBarcode.Enter
        SwitchKeyboardLayout("en")
    End Sub


    ' Helper method to process barcodes that need shelf selection
    Private Sub ProcessBarcodeWithShelf(barcodeText As String)
        Dim shelfSelector As New PosSelectShelf
        With shelfSelector
            .DockPanel1.Close()
            .Text = "شاشة تحديد الرف"
            .TextItemBarcode.EditValue = barcodeText
            .StockCreditWhereHouse.EditValue = 1
            .TextOpenFrom.Text = "POS"
            .GetDataForPosSelectShelf()

            If .ShowDialog() <> DialogResult.OK Then
                InsertIntoPOSJournalByStoredProcedure(
                barcodeText,
                DocName.EditValue,
                1.0,
                _DefaultWharehouse,
                Me.DocCode.Text,
                Me.TextReferanceNo.EditValue,
                0,
                0,
                .TextShelf.EditValue,
                "")
                GetPosJournalTable()
            End If
        End With
    End Sub

    ' Helper method to extract weight from barcode for scale items
    Private Sub ExtractWeightFromBarcode(ByRef barcodeText As String, ByRef quantity As Decimal)
        If CheckIfItemSaleOnScale(Mid(barcodeText, 3, 5)) Then
            quantity = Mid(barcodeText, 8, 5) / 1000
            barcodeText = Mid(barcodeText, 3, 5)
        End If
        txtBarcode.Focus()
    End Sub

    ' Helper method to add an item to the journal
    Private Function AddItemToJournal(barcodeText As String, quantity As Decimal) As Boolean
        If InsertIntoPOSJournalByStoredProcedure(
            barcodeText,
            DocName.EditValue,
            quantity,
            _DefaultWharehouse,
            Me.DocCode.Text,
            Me.TextReferanceNo.EditValue,
            0,
            0,
            0,
            "") = 0 Then

            PosAddLOG(Me.DocCode.Text, "InsertIntoPOSJournalByStoredProcedure Failed")
            PlayErrorBeepOnPos()

            ' Handle item not found
            If Not CheckIfBarcodeFound(barcodeText) Then
                HandleItemNotFound(barcodeText)
            Else
                MsgBoxShowError(" خطا - يرجى اعادة المحاولة ")
            End If

            Return False
        End If
        txtBarcode.Focus()
        Return True
    End Function

    ' Helper method to handle when an item is not found
    Private Sub HandleItemNotFound(barcodeText As String)
        CreateDocLog("POS", "", "0", "0", "Insert",
                "Item Not Defined Barcode:" & barcodeText & " From Pos",
                Format(Now(), "yyyy-MM-dd HH:mm:ss"))
        Dim itemNotDefinedDialog As New PosItemNotDefined
        With itemNotDefinedDialog
            .LabelControlBarcode.Text = barcodeText
            If Not CheckIfBarcodeFound(barcodeText) Then
                .BtnDefineNewItem.Visible = posDefineNewItemInPos
            End If

            Dim sql As New SQLControl
            If sendMessageWhenTheItemNotDefined Then
                sql.SqlTrueAccountingRunQuery(" select SettingValue from Settings where SettingName='POSNumbersToSendClosedShift'")
                If Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then
                    Dim wordsArray As String() = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").Split("-"c)
                    For Each word As String In wordsArray
                        SendSMSMessage(word, " Item Not Defined:" & barcodeText & " " & " Pos:" & _PosNo & " User:" & GlobalVariables.EmployeeName, "WhatsApp", False, "")
                    Next
                End If
            End If

            If .ShowDialog() <> DialogResult.OK Then
                txtBarcode.SelectionStart = 0
                txtBarcode.SelectionLength = txtBarcode.Text.Length
                txtBarcode.Focus()
            End If
        End With
    End Sub


    Private Function CheckIfItemSaleOnScale(_barcode As String) As Boolean
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("    select SaleOnScale from Items  I left Join Items_units IU on I.ItemNo=IU.item_id where item_unit_bar_code='" & _barcode & "'")
            Return CBool(sql.SQLDS.Tables(0).Rows(0).Item("SaleOnScale"))
        Catch ex As Exception
            Return False
        End Try
        txtBarcode.Focus()
    End Function
    Private Function GetItemTypeByBarcode(_Barcode As String) As Integer
        Dim _Type As Integer
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  select I.Type As ItemType from Items I
                                            left join Items_units U on I.ItemNo=U.item_id 
                                            where U.item_unit_bar_code='" & _Barcode & "'"
            sql.SqlTrueAccountingRunQuery(SqlString)
            _Type = sql.SQLDS.Tables(0).Rows(0).Item("ItemType")
        Catch ex As Exception
            _Type = 0
        End Try
        Return _Type
    End Function
    Private Function CheckIfAllowDeleteItemFromPos() As Boolean
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosAllowChangeDeleteItemInVoucher'")
            Return CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: PosAllowChangeDeleteItemInVoucher")
            Return True
        End Try
    End Function
    Private Sub GridPosVoucher_ProcessGridKey(ByVal sender As Object, ByVal e As KeyEventArgs) Handles GridPosVoucher.ProcessGridKey

        Dim grid = TryCast(sender, GridControl)
        If _VoucherView = "TileView" Then
            Dim view = TryCast(grid.FocusedView, TileView)
            If e.KeyData = Keys.Delete Then
                If CheckIfAllowDeleteItemFromPos() = False Then
                    XtraMessageBox.Show("لا يوجد صلاحية")
                    Exit Sub
                End If
                DeleteRowFromPOSVoucher(TileView2.GetFocusedRowCellValue("ID"))
                PosAddLOG(Me.DocCode.Text, "DeleteRowFomPOSVoucher  ")
                e.Handled = True
                txtBarcode.Focus()
            End If
        ElseIf _VoucherView = "GridView" Then
            Dim view = TryCast(grid.FocusedView, GridView)
            If e.KeyData = Keys.Delete Then
                If CheckIfAllowDeleteItemFromPos() = False Then
                    XtraMessageBox.Show("لا يوجد صلاحية")
                    Exit Sub
                End If
                DeleteRowFromPOSVoucher(GridView1.GetFocusedRowCellValue("ID"))
                PosAddLOG(Me.DocCode.Text, "DeleteRowFomPOSVoucher  ")
                e.Handled = True
                txtBarcode.Focus()
            End If
        End If

        GridPosVoucher.RefreshDataSource()
        txtBarcode.Focus()
    End Sub

    Private Sub TxtBarcode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyUp
        ' Only process barcode if Enter key is pressed and text is not empty
        If e.KeyCode = Keys.Enter AndAlso Not String.IsNullOrEmpty(txtBarcode.Text) Then
            PosAddLOG(Me.DocCode.Text, "TextBarcode Enter")

            Try
                Dim barcodeText As String = txtBarcode.Text.Trim()
                Dim quantity As Decimal = 1.0

                ' Validate barcode
                If barcodeText = "0" OrElse String.IsNullOrEmpty(barcodeText) Then
                    PosFunctions.PlayErrorBeepOnPos()
                    Exit Sub
                End If

                ' Handle shelf selection if needed
                If GlobalVariables._POSuseShelves AndAlso GetItemTypeByBarcode(barcodeText) = 0 Then
                    ProcessBarcodeWithShelf(barcodeText)
                Else
                    ' Process scale items if enabled
                    If GlobalVariables._PosUseScales AndAlso Len(barcodeText) = 13 AndAlso barcodeText.StartsWith("2") Then
                        ExtractWeightFromBarcode(barcodeText, quantity)
                    End If

                    ' Add item to journal
                    If Not AddItemToJournal(barcodeText, quantity) Then
                        Exit Sub
                    End If
                End If

                ' Refresh display and reset barcode field
                GetPosJournalTable()
                txtBarcode.Text = ""

            Catch ex As Exception
                PosAddLOG(Me.DocCode.Text, "Error processing barcode: " & ex.Message)
            End Try
        ElseIf e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            ActiveControl = Me.GridPosVoucher
        End If
    End Sub

    Private Sub TextBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress
        If txtBarcode.Text = "" Then
            Select Case e.KeyChar
                Case "+"c
                    AddOrSubtractQauntity("Add")
                    e.Handled = True
                Case "-"c
                    If preventKeySubtractInPos Then
                        e.Handled = True ' Prevent the '-' key if setting is enabled
                    Else
                        AddOrSubtractQauntity("Subtract")
                        e.Handled = True
                    End If
                Case " "c
                    e.Handled = True
            End Select
        Else
            Select Case e.KeyChar
                Case "-"c
                    If preventKeySubtractInPos Then
                        e.Handled = True ' Prevent the '-' key if setting is enabled
                    End If
            End Select
        End If
        ' End If
    End Sub
    Private Sub AddOrSubtractQauntity(_Key As String)


        PosAddLOG(Me.DocCode.Text, "AddOrSubtractQauntity: " & _Key)

        Try
            ' Check if voucher discount is applied
            If Me.TextVoucherDiscount2.EditValue > 0 Then
                XtraMessageBox.Show("لا يمكن تعديل الكميات بعد خصم الفاتورة. يرجى إزالة خصم الفاتورة أولاً")
                Exit Sub
            End If

            If _Key = "Subtract" Then
                If posAllowMinusQuantityIvVoucher = False Then
                    Dim currentQuantity As Decimal = TileView2.GetFocusedRowCellValue("Quantity")
                    If currentQuantity <= 1 Then
                        'PlayErrorBeepOnPos()
                        'MsgBoxShowError("لا يمكن تقليل الكمية عن 1. لا توجد صلاحية للسماح بكمية سالبة.")
                        Exit Sub
                    End If
                End If
            End If



            ' Ensure we have a valid row selected
            Dim focusedRow As Integer = TileView2.FocusedRowHandle
            If focusedRow < 0 Then
                TileView2.FocusedRowHandle = 0
                TileView2.FocusedColumn = TileViewItemName
                TileView2.SelectRow(0)
            Else
                TileView2.SelectRow(focusedRow)
            End If

            ' Validate the item has a barcode
            If Not IsDBNull(TileView2.GetFocusedRowCellValue("StockBarcode")) Then
                Dim barcode As String = CStr(TileView2.GetFocusedRowCellValue("StockBarcode"))
                If barcode = "0" OrElse String.IsNullOrEmpty(barcode) Then
                    PlayErrorBeepOnPos()
                    MsgBoxShowError("لا يمكن تعديل الكمية بسبب عدم وجود باركود للصنف")
                    Exit Sub
                End If
            End If

            ' Get row data and check if price was manually edited
            Dim rowID As Integer = TileView2.GetFocusedRowCellValue("ID")
            Dim isPriceEdited As Boolean = CBool(TileView2.GetFocusedRowCellValue("PriceEdited"))

            If isPriceEdited Then
                PlayErrorBeepOnPos()
                Exit Sub
            End If

            ' Prepare SQL and execute quantity update
            Dim sqlString As String = BuildQuantityUpdateSQL(rowID, _Key)
            Dim sql As New SQLControl()

            If Not sql.SqlTrueAccountingRunQuery(sqlString) Then
                MsgBox("لم يتم تعديل البيانات")
                PlayErrorBeepOnPos()
                Exit Sub
            End If

            Me.txtBarcode.Text = ""
            ' Refresh the UI with updated data
            GetPosJournalTable()
            TileView2.FocusedRowHandle = focusedRow
            txtBarcode.Focus()

        Catch ex As Exception
            PosAddLOG(Me.DocCode.Text, "Error in AddOrSubtractQauntity: " & ex.Message)
            MsgBox("حدث خطأ أثناء تعديل الكمية: " & ex.Message)
        End Try
    End Sub

    Private Function BuildQuantityUpdateSQL(rowID As Integer, operationType As String) As String
        ' Common initial SQL setup
        Dim sql As String = " DECLARE @Barcode VARCHAR(50);
                              DECLARE @UnitID INT;
                              DECLARE @DocCode VARCHAR(50);
                              DECLARE @ItemNo INT;

                              SELECT 
                                    @Barcode = StockBarcode,
                                    @UnitID = StockUnit,
                                    @DocCode = DocCode,
                                    @ItemNo = StockID
                              FROM POSJournal WHERE ID = " & rowID & "; " &
                        "DECLARE @DocAmountBeforeDiscount FLOAT; " &
                        "SET @DocAmountBeforeDiscount = (SELECT StockQuantity * StockPrice FROM POSJournal WHERE ID = " & rowID & "); "

        ' Different update logic based on operation type
        If operationType = "Add" Then
            sql &= "UPDATE u " &
               "SET u.StockQuantityByMainUnit = u.StockQuantityByMainUnit + s.EquivalentToMain, " &
               "    u.StockQuantity = CASE WHEN u.StockQuantity = -1 THEN 1 ELSE u.StockQuantity + 1 END, " &
               "    u.DocAmount = CASE WHEN u.StockQuantity = -1 THEN (s.Price1 - ABS(StockDiscount)) ELSE u.DocAmount + s.Price1 END, " &
               "    u.StockDiscount = ABS((@DocAmountBeforeDiscount - u.DocAmount)) / CASE WHEN u.StockQuantity = -1 THEN 1 ELSE u.StockQuantity + 1 END " &
               "FROM [dbo].[POSJournal] u " &
               "INNER JOIN Items_units s ON u.StockID = s.item_id AND u.StockUnit = s.unit_id " &
               "WHERE u.ID = " & rowID
        Else ' Subtract
            sql &= "UPDATE u " &
               "SET u.StockQuantityByMainUnit = u.StockQuantityByMainUnit - s.EquivalentToMain, " &
               "    u.StockQuantity = CASE WHEN u.StockQuantity = 1 THEN -1 ELSE u.StockQuantity - 1 END, " &
               "    u.DocAmount = CASE WHEN u.StockQuantity = 1 THEN -1 * (s.Price1 - StockDiscount) ELSE u.DocAmount - s.Price1 END, " &
               "    u.StockDiscount = ABS((@DocAmountBeforeDiscount - u.DocAmount)) / CASE WHEN u.StockQuantity = 1 THEN -1 ELSE u.StockQuantity - 1 END " &
               "FROM [dbo].[POSJournal] u " &
               "INNER JOIN Items_units s ON u.StockID = s.item_id AND u.StockUnit = s.unit_id " &
               "WHERE u.ID = " & rowID
        End If

        ' Apply any campaign discounts
        sql &= "; EXEC [dbo].[ApplyCampagins] @Barcode = @Barcode ,@ItemNo=@ItemNo, @UnitID=@UnitID , @DocCode=@DocCode "

        Return sql
    End Function


    Private Sub CheckIfShiftFound()
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery(" Select top 1 ShiftID 
                                        from [dbo].[PosShifts] 
                                        where [PosNumber]=" & _PosNo & " And ShiftStatus='Opening'  order by ShiftID desc")
        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
            GlobalVariables._ShiftID = Sql.SQLDS.Tables(0).Rows(0).Item("ShiftID")
            TextShiftStatus.Text = "Opening"
        Else
            GlobalVariables._ShiftID = 0
        End If

        If GlobalVariables._ShiftID = 0 Then
            SidePanel1.Enabled = False
            SidePanel5.Enabled = False
            BarButtonCloseShift.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.PosOpenCloseShift.TextShiftID.Text = GlobalVariables._ShiftID
            My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Open"
            'PosOpenCloseShift.ShowDialog()

            Try
                Dim _screen As Screen
                _screen = Screen.AllScreens(0)
                PosOpenCloseShift.StartPosition = FormStartPosition.Manual
                PosOpenCloseShift.Location = _screen.Bounds.Location + New Point(100, 100)
                PosOpenCloseShift.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If

        BarStaticShiftID.Caption = GlobalVariables._ShiftID

    End Sub
    Public Sub ChangePosModeInResturantMode(_ToMode As String)
        If _ResturantMode = True Then
            Select Case _ToMode
                Case "Tables"
                    TabbedControlGroupAllScreens.SelectedTabPage = TabTables
                    TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    Me.LayoutControlItemTableName.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlItemTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlGroupTable.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItemPrintKitchen.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlHoldVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    BarButtonItemHoldedVouchers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                    LabelControlModeName.Text = "الطاولات"
                    LayoutControlItemAllGroups.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItemPrint.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    GetHoldVouchers(-1)
                    GetTablesLocations(True)
                    SearchTables.Properties.DataSource = GetTablesTable()
                    LayoutControlPaidOptions.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    cuurentModeInTablesOrTakeAway = "Tables"
                Case "TakeAway"
                    Me.LayoutControlItemTableName.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
                    _FromTableVouchers = False
                    GridItemsGroups.Visible = True
                    LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    SearchTables.EditValue = 0
                    LayoutControlItemTables.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlGroupTable.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlItemPrintKitchen.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlHoldVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    BarButtonItemHoldedVouchers.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    LabelControlModeName.Text = "Take Away"
                    Me.LabelControlTableName.Text = "Take Away"
                    LayoutControlItemAllGroups.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutItemSaveButtom.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlItemPrint.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                    LayoutControlPaidOptions.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    cuurentModeInTablesOrTakeAway = "TakeAway"
            End Select
            resturantModeTablesOrTakeAway = _ToMode
        End If
    End Sub

    Private Sub SaveToJournal()
        PosAddLOG(Me.DocCode.Text, "Begin Try Save Voucher")

        CheckShiftIfOpening()

        ' Handle restaurant mode table/takeaway visibility
        If _ResturantMode Then
            LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlGroupTable.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemPrintKitchen.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        End If


        ' Handle table vouchers
        If _FromTableVouchers Then
            If Not CheckPrint.Checked Then
                HoldVoucher()
                GetHoldVouchers(_SelectedLocation)
                LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                _FromTableVouchers = False
                Exit Sub
            ElseIf CheckPrint.Checked Then
                PrintVoucherFromPosJournalOrHoldJournal("PosJournal", False, False)
                LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Exit Sub
            End If
        End If

        ' Check if grid has rows
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Case "TileView2"
                If TileView2.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
        End Select

        ' Handle rounding
        If Math.Abs(Me.TextVoucherDiscountRound.EditValue) > 0.01 Then
            ReCalculateVouvherAfterRounded()
            Me.TextVoucherDiscountRound.EditValue = 0
        End If

        ' Validate discount amounts for non-gift/destruction vouchers
        If DocName.EditValue <> 18 Then
            If ChackIfDiscountGreatThanMaxDiscount() Then
                MsgBox("لا يمكن حفظ الفاتورة، لقد تجاوزت الحد الأقصى للخصم")
                PosAddLOG(Me.DocCode.Text, "Failed Save Voucher Because DocAmount Over Discount")
                Exit Sub
            End If
        End If

        ' Check if customer is required
        If customerIsRequirdInPOS AndAlso TextReferanceNo.Text = 0 Then
            My.Forms.PosSerachReferance.ShowDialog()
            If String.IsNullOrEmpty(TextReferanceName.Text) Then
                MsgBoxShowError("يجب اختيار زبون")
                Exit Sub
            End If
        End If

        ' Set up voucher variables
        Dim _DocAmount As Decimal = TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue
        Dim _PaidStatus As Integer = 0
        Dim _PaidAmount As Decimal = 0.0
        Dim SqlString, SqlString2, SqlString3, _VoucherType As String
        SqlString3 = ""

        ' Determine reference info
        Dim _Referance As String = If(String.IsNullOrEmpty(TextReferanceNo.Text) OrElse TextReferanceNo.Text = "0", "0", TextReferanceNo.Text)
        Dim _ReferanceName As String = TextReferanceName.Text

        ' Determine voucher type and payment status
        If Not String.IsNullOrEmpty(_ReferanceName) AndAlso TextOtherAccountNo.Caption <> DefaultCashAcc Then
            _VoucherType = "CSTMR"
            _PaidStatus = 0
            _PaidAmount = 0
        Else
            _VoucherType = If(TextOtherAccountNo.Caption = DefaultCashAcc, "Cash", "Card")
            _PaidStatus = 2
            _PaidAmount = _DocAmount
        End If

        ' Set account info for customer vouchers
        If _VoucherType = "CSTMR" Then
            Dim RefData = GetRefranceData(_Referance)
            TextOtherAccountNo.Caption = RefData.RefAccID
            _CustomerBalance = 0
            cashCustomerId = 0
        Else
            If _ReferanceName = "" Then _ReferanceName = "زبون نقدي"
        End If

        If _VoucherType = "Card" Then
            _ReferanceName = "زبون فيزا"
        End If

        ' Handle empty card name
        If String.IsNullOrEmpty(GlobalVariables._PayCardName) Then
            GlobalVariables._PayCardName = ""
        End If

        ' Get table ID
        Dim tableID As Integer = If(SearchTables.EditValue IsNot Nothing, SearchTables.EditValue, 0)

        ' Get document ID
        Dim _DocID As Integer = GetDocNo(DocName.EditValue, False)
        If _DocID = 0 Then
            PosAddLOG(Me.DocCode.Text, "Error: Voucher No. Is Zero")
        End If

        ' Determine document status
        Dim _DocStatus As Integer = If(posPostVouchers, 3, 1)

        ' Set shelf ID for special cases
        Dim _Shelf As Integer = If(shalashCo, 1397, 0)

        ' Get payment amounts
        Dim __paidamount As Decimal = If(Not IsNothing(Me.TextPaidAmount.EditValue), Me.TextPaidAmount.EditValue, 0)
        Dim __returnamount As Decimal = If(Not IsNothing(Me.TextReturnAmount.EditValue), Me.TextReturnAmount.EditValue, 0)

        ' Get voucher time
        Dim _VoucherTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        ' Initialize SQL execution flags
        Dim __FirstSide As Boolean = False
        Dim _SecondSide As Boolean = False
        Dim _VoucherSide As Boolean = False
        Dim sql As New SQLControl

        ' Get voucher counter
        Dim _VoucherCounter As Integer = CInt(Me.BarStaticItemVoucherCounter.Caption)

        ' تم ادخال هذ الكود لمنع تخزين فاتورة زبون ذمم على الصندوق النقدي
        If _Referance <> "0" And _Referance <> "" And _Referance <> " " Then
            If TextOtherAccountNo.Caption = DefaultCashAcc Then
                CreateDocLog("POS", "", "0", "0", "Insert", " الفاتورة ذمم ولكن كان من المحتمل تسجيلها كاش " & TextOtherAccountNo.Caption & " :  " & DefaultCashAcc & " From Pos", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                TextOtherAccountNo.Caption = GetRefranceData(_Referance).RefAccID
                Exit Sub
            End If
        End If





        ' Execute SQL based on document type
        Select Case DocName.EditValue
            Case 2 ' Sales voucher
                ' Handle voucher note
                If String.IsNullOrEmpty(_PosVoucherNote) Then _PosVoucherNote = "  "

                ' Insert to PosVouchers
                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                           [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                           [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,PaidAmount,ReturnAmount,TableID,CashCustomerId)
                    VALUES(" & _DocID & ",'" & _VoucherTime & "'," & TexVouchertAmountBeforeDiscount.EditValue & "," &
                           TextVoucherDiscount.EditValue & "," & TextVoucherDiscount2.EditValue & "," &
                           (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                           GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                           TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                           _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                           GlobalVariables._ShiftID & ",2," & My.Settings.POSNo & "," & _VoucherCounter & "," &
                           __paidamount & "," & __returnamount & "," & tableID & "," & cashCustomerId & ")"

                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)

                If _VoucherSide Then
                    ' Insert items to journal
                    SqlString = "INSERT INTO Journal
                              ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                               [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                               [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                               StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                               CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,
                               [StockDebitShelve],[StockCreditShelve],[VoucherCounter],StockBarcode,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,LastPurchasePrice,CashCustomerId) 
                           SELECT " & _DocID & ",CAST(GETDATE() AS DATE) ," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                                [DebitAcc],[CredAcc],AccountCurr,
                                " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & _PosNo & "',
                                 DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve]," & _Shelf & ",
                                " & _VoucherCounter & ",StockBarcode," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",
                                '" & GlobalVariables.CurrDevice & "','" & _VoucherType & "'," & tableID & ",LastPurchasePrice," & cashCustomerId & "
                          FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on first side")
                    End If
                End If

                If __FirstSide And _VoucherSide Then
                    ' Insert total row
                    SqlString2 = "INSERT INTO Journal
                               ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,CashCustomerId) 
                              VALUES(" & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",'" &
                                TextOtherAccountNo.Caption & "','0'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," &
                                _DocAmount & "," & _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" &
                                _VoucherTime & "','" & TextReferanceNo.Text & "',N'" & _ReferanceName & "'," & GlobalVariables._ShiftID & ",'" &
                                GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," & _VoucherCounter & "," &
                                GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" & GlobalVariables.CurrDevice & "','" &
                                _VoucherType & "'," & tableID & "," & cashCustomerId & ")"

                    _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)

                    If Not _SecondSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on second side")
                    End If
                End If

            Case 12 ' Returns voucher
                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                           [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                           [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,TableID,CashCustomerId) 
                           VALUES (" & _DocID & ",'" & _VoucherTime & "'," & -1 * TexVouchertAmountBeforeDiscount.EditValue & "," &
                          -1 * TextVoucherDiscount.EditValue & "," & -1 * TextVoucherDiscount2.EditValue & "," &
                          -1 * (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                           GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                           TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                           _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                           GlobalVariables._ShiftID & ",12," & My.Settings.POSNo & ", " & _VoucherCounter & "," & tableID & "," & cashCustomerId & ")"

                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)

                If _VoucherSide Then
                    SqlString = "INSERT INTO Journal
                              ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                               [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                               [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,CashCustomerId) 
                              VALUES(" & _DocID & ",'" & _VoucherTime & "'," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter &
                                ",'0','" & TextOtherAccountNo.Caption & "'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," &
                                _DocAmount & "," & _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser &
                                "',CAST(GETDATE() AS smalldatetime),'" & TextReferanceNo.Text & "',N'" & _ReferanceName & "'," &
                                GlobalVariables._ShiftID & ",'" & GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," &
                                _VoucherCounter & "," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" &
                                GlobalVariables.CurrDevice & "','" & _VoucherType & "'," & tableID & "," & cashCustomerId & ")"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                    End If
                End If

                If __FirstSide And _VoucherSide Then
                    SqlString2 = "INSERT INTO Journal
                               ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,
                                StockDiscount,[StockDebitShelve],[StockCreditShelve],VoucherCounter,StockBarcode,DocID2,[PaidStatus],[PaidAmount],DeviceName,POSVoucherPayType,TableID,LastPurchasePrice,CashCustomerId) 
                              SELECT " & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                                   [DebitAcc],[CredAcc],AccountCurr,
                                   " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                   " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                    StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                     '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",
                                     DocCode,'" & _PosNo & "',DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve]," &
                                     _VoucherCounter & ",StockBarcode," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" &
                                     GlobalVariables.CurrDevice & "',POSVoucherPayType," & tableID & ",LastPurchasePrice," & cashCustomerId & "
                              FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)

                    If Not _SecondSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                    End If
                End If

            Case 18 ' Gift or destruction voucher
                ' Add appropriate note based on type
                If Itlaf_Gift = "Gift" Then
                    If String.IsNullOrEmpty(_PosVoucherNote) Then
                        _PosVoucherNote = " سند اخراج / هدية "
                    Else
                        _PosVoucherNote += " سند اخراج / هدية "
                    End If
                ElseIf Itlaf_Gift = "Itlaf" Then
                    If String.IsNullOrEmpty(_PosVoucherNote) Then
                        _PosVoucherNote = " سند اخراج / اتلاف "
                    Else
                        _PosVoucherNote += " سند اخراج / اتلاف "
                    End If
                End If

                ' Reset payment values
                GlobalVariables._PayCardName = ""
                __paidamount = 0
                __returnamount = 0

                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                           [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                           [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,PaidAmount,ReturnAmount)
                    VALUES(" & _DocID & ",'" & _VoucherTime & "'," & TexVouchertAmountBeforeDiscount.EditValue & "," &
                           TextVoucherDiscount.EditValue & "," & TextVoucherDiscount2.EditValue & "," &
                           (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                           GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                           TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                           _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                           GlobalVariables._ShiftID & "," & DocName.EditValue & "," & My.Settings.POSNo & "," &
                           _VoucherCounter & "," & __paidamount & "," & __returnamount & ")"

                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)

                If _VoucherSide Then
                    SqlString = "INSERT INTO Journal
                              ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                               [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                               [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                               StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                               CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,
                               [StockDebitShelve],[StockCreditShelve],[VoucherCounter],StockBarcode,DocID2,[PaidStatus],[PaidAmount],DeviceName,POSVoucherPayType,LastPurchasePrice) 
                           SELECT " & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                                [DebitAcc],'4020000000',AccountCurr,
                                " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & _PosNo & "',
                                 DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve]," & _VoucherCounter & ",StockBarcode," &
                                 GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" & GlobalVariables.CurrDevice & "','',LastPurchasePrice
                          FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on first side")
                    End If
                End If

                If __FirstSide And _VoucherSide Then
                    SqlString2 = "INSERT INTO Journal
                               ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],POSVoucherPayType) 
                              VALUES(" & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter &
                                ",'4020000000','0'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," & _DocAmount & "," &
                                _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" & _VoucherTime & "','" &
                                TextReferanceNo.Text & "',N'" & _ReferanceName & "'," & GlobalVariables._ShiftID & ",'" &
                                GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," & _VoucherCounter & "," &
                                GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'')"

                    _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)
                    If Not _SecondSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on second side")
                    End If
                End If
        End Select

        ' Process successful voucher save
        If _VoucherSide AndAlso __FirstSide AndAlso _SecondSide Then
            ' Log document creation
            CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, "Insert",
                    "Inserted From POS No.:" & _PosNo, Format(Now(), "yyyy-MM-dd HH:mm:ss"))

            ' Send Voucher to OwnersMobile as text
            _CustomerBalance = GetReferanceBalance(TextReferanceNo.EditValue)
            If sendVouchersAsTextToMobileNumbers Then
                SendVoucherAsTextToOwners(OwnersMobileNumbers)
            End If

            If sendVoucherToCustomer = True And sendVoucherPDFToCustomer = False Then
                Dim mobiles As String() = New String() {GetRefranceData(_Referance).RefMobile}
                SendVoucherAsTextToOwners(mobiles)
                If shalashCo = True Then
                    Dim mobiles2 As String() = New String() {"120363418766138503"}
                    SendVoucherAsTextToOwners(mobiles2)
                End If
            End If

            ' Process any production items
            ProduceItems()
            If shalashCo Then
                InsertCustomerCarIfNotExists(Me.TextCarNumber.EditValue, Me.TextShassiNumber.Text)
                InsertItemsToCustomersCarsParts()
                SetupCarNoAutoComplete()
                TextCarNumber.Text = ""
                TextShassiNumber.Text = ""

            End If
            ' Set last _LastVoucherCode to use to print last voucher by Ctrl+P
            GlobalPosVariables._LastVoucherCode = Me.DocCode.Text

            ' Handle printing if requested
            If CheckPrint.Checked Then
                _TempDocVoucherCode = DocCode.Text
                _TempPaidAmount = Me.TextPaidAmount.EditValue
                _VouchertAmountAfterDiscount = Me.TexVouchertAmountAfterDiscount.EditValue
                _TempVoucherNote = _PosVoucherNote
                _TempDocName = Me.DocName.EditValue
                _Customer = TextReferanceName.Text
                If TextReferanceName.Text = "" And _VoucherType = "Card" Then
                    _Customer = " زبون فيزا "
                End If
                ' Set customer details for receipt
                If Me.TextReferanceNo.Text = "0" Or Me.TextReferanceNo.Text = "" Then
                    _DebitInvoice = False
                    _CustomerNo = 0
                    _CustomerBalance = ""
                Else
                    _DebitInvoice = True
                    _CustomerNo = TextReferanceNo.Text
                    _CustMobile = GetRefranceData(TextReferanceNo.EditValue).RefMobile
                End If

                PrintVoucher()

                If _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                    PrintVoucherFromPosJournalOrHoldJournal("POSJournal", True, False)
                End If
            ElseIf _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                PrintVoucherFromPosJournalOrHoldJournal("POSJournal", True, False)
                'ElseIf CheckPrint.Checked And _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                '    PrintVoucherFromPosJournalOrHoldJournal("POSJournal", False)
            End If
            cashCustomerId = 0
            PosAddLOG(Me.DocCode.Text, "Saving voucher Done")
            ClearPosVoucher()
        Else
            XtraMessageBox.Show("خطا: حاول مرة اخرى")
        End If

        ' Refresh UI state
        GetPosJournalTable()

        If _ResturantMode Then
            Me.LabelControlTableName.Text = ""
            'TabbedControlGroupAllScreens.SelectedTabPage = TabTables
            'TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            'LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            'LayoutControlItemTableName.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            ChangePosModeInResturantMode(cuurentModeInTablesOrTakeAway)
            'LayoutControlItemAllGroups.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        End If

        ShowSecondScreen("Welcome")
        txtBarcode.Focus()
    End Sub

    Private Sub ReCalculateVouvherAfterRounded()
        Dim sql As New SQLControl
        Dim sqlString As String
        Dim _lastDiscount As Decimal
        Dim _roundedAmount As Decimal
        Dim _newDiscount As Decimal
        Dim _NewVoucherAmount As Decimal

        sqlString = " Select IsNull(Sum(VoucherDiscount),0) as VoucherDiscount  
                          From [POSJournal] 
                          Where DocCode='" & Me.DocCode.Text & "'"
        sql.SqlTrueAccountingRunQuery(sqlString)
        _lastDiscount = sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")
        _roundedAmount = Me.TextVoucherDiscountRound.EditValue
        _newDiscount = _lastDiscount + _roundedAmount
        _NewVoucherAmount = TexVouchertAmountBeforeDiscount.EditValue
        sqlString = "  Update [dbo].[POSJournal]
                       Set VoucherDiscount= 0 
                       Where DocCode='" & DocCode.Text & "'  "
        sql.SqlTrueAccountingRunQuery(sqlString)

        sqlString = " Update [dbo].[POSJournal]
                      Set [VoucherDiscount] =(((StockPrice-StockDiscount)*StockQuantity)/" & _NewVoucherAmount & ") * " & _newDiscount & " 
                      Where DocCode='" & DocCode.Text & "' "
        sql.SqlTrueAccountingRunQuery(sqlString)
        sqlString = " Update [dbo].[POSJournal]
                      Set DocAmount=((StockPrice-StockDiscount)*StockQuantity)-(((StockPrice-StockDiscount)*StockQuantity)/" & _NewVoucherAmount & ") * " & _newDiscount & " 
                      Where DocCode='" & DocCode.Text & "' "
        sql.SqlTrueAccountingRunQuery(sqlString)
        Me.TextVoucherDiscount2.EditValue = _newDiscount
    End Sub

    Private Sub ProduceItems()
        Select Case DocName.EditValue
            Case 2
                If _UseDirectProduction = True Then

                    Dim i As Integer
                    Dim _Produced As Boolean
                    Dim _ItemNo As Integer
                    Dim _ItemName As String
                    Dim _Referance As Integer
                    If String.IsNullOrEmpty(TextReferanceNo.Text) Then _Referance = 0 : Else _Referance = TextReferanceNo.Text
                    For i = 0 To TileView2.RowCount - 1
                        _Produced = TileView2.GetRowCellValue(i, "Produced")
                        _ItemNo = TileView2.GetRowCellValue(i, "StockID")
                        _ItemName = TileView2.GetRowCellValue(i, "ItemName")
                        If _Produced = True Then
                            sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
                            Using (sqlCon)
                                Dim sqlComm As New SqlCommand With {
                                    .Connection = sqlCon,
                                    .CommandText = "ProduceItem",
                                    .CommandType = CommandType.StoredProcedure
                                }
                                sqlComm.Parameters.AddWithValue("ItemNo", _ItemNo)
                                sqlComm.Parameters.AddWithValue("UserID", GlobalVariables.CurrUser)
                                sqlComm.Parameters.AddWithValue("Quantity", TileView2.GetRowCellValue(i, "Quantity"))
                                sqlComm.Parameters.AddWithValue("Unit", TileView2.GetRowCellValue(i, "StockUnit"))
                                sqlComm.Parameters.AddWithValue("CostCenter", _CostCenter)
                                sqlComm.Parameters.AddWithValue("WahreHouse", _DefaultWharehouse)
                                sqlComm.Parameters.AddWithValue("BarCode", TileView2.GetRowCellValue(i, "StockBarcode"))
                                sqlComm.Parameters.AddWithValue("PosNo", _PosNo)
                                sqlComm.Parameters.AddWithValue("DeviceName", GlobalVariables.CurrDevice)
                                sqlComm.Parameters.AddWithValue("ItemName", _ItemName)
                                sqlComm.Parameters.AddWithValue("Referance", TextReferanceNo.Text)
                                sqlComm.Parameters.AddWithValue("ReferanceName", TextReferanceName.Text)
                                sqlComm.Parameters.AddWithValue("DocNote", "")
                                sqlComm.Parameters.AddWithValue("LastDocCode", "")
                                sqlComm.Parameters.AddWithValue("DocID2", 1)
                                sqlComm.Parameters.AddWithValue("DocDate", Format(Now, "yyyy-MM-dd"))
                                sqlCon.Open()
                                sqlComm.ExecuteNonQuery()
                                PosAddLOG(Me.DocCode.Text, "Produce Items  Done")
                            End Using
                        End If
                    Next
                End If
        End Select
    End Sub

    Private Sub InsertItemsToCustomersCarsParts()
        Try
            Dim i As Integer
            Dim _ItemNo As Integer
            Dim _CarID As Integer
            Dim _VoucherNo As Integer
            Dim _Now As DateTime = DateTime.Now
            Dim RefNo As Integer
            If TextReferanceNo.Text = "" Then RefNo = 0
            'If String.IsNullOrEmpty(TextReferanceNo.Text) Then Exit Sub
            If String.IsNullOrEmpty(TextCarNumber.Text) Then Exit Sub

            ' Get CarID from CarNo
            _CarID = GetCarIDByCarNo(TextCarNumber.Text)
            If _CarID = 0 Then Exit Sub

            ' Get current voucher number
            _VoucherNo = CInt(Me.BarStaticItemVoucherCounter.Caption)

            For i = 0 To TileView2.RowCount - 1
                _ItemNo = TileView2.GetRowCellValue(i, "StockID")
                sqlCon = New SqlConnection(My.Settings.TrueTimeConnectionString)
                Using (sqlCon)
                    Dim sqlComm As New SqlCommand With {
                    .Connection = sqlCon,
                    .CommandText = "INSERT INTO [dbo].[CustomersCarsParts] (CarID, ItemNo, DocName, VoucherNo, InputDateTime, RefNo) VALUES (@CarID, @ItemNo, @DocName, @VoucherNo, @InputDateTime, @RefNo)",
                    .CommandType = CommandType.Text
                }
                    sqlComm.Parameters.AddWithValue("@CarID", _CarID)
                    sqlComm.Parameters.AddWithValue("@ItemNo", _ItemNo)
                    sqlComm.Parameters.AddWithValue("@DocName", Me.DocName.EditValue)
                    sqlComm.Parameters.AddWithValue("@VoucherNo", _VoucherNo)
                    sqlComm.Parameters.AddWithValue("@InputDateTime", _Now)
                    sqlComm.Parameters.AddWithValue("@RefNo", RefNo)

                    sqlCon.Open()
                    sqlComm.ExecuteNonQuery()
                End Using
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
            PosAddLOG(Me.DocCode.Text, "InsertItemsToCustomersCarsParts Error " & ex.Message)
        End Try
    End Sub

    Private Function GetCarIDByCarNo(carNo As String) As Integer
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT ID FROM CustomersCars WHERE CarNo = '" & carNo & "'")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return CInt(sql.SQLDS.Tables(0).Rows(0).Item("ID"))
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private Function GetOwnersNumbers() As String()
        Dim numbers As String() = Nothing
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT SettingValue FROM Settings WHERE SettingName='POSNumbersToSendClosedShift'")

            If sql.SQLDS.Tables(0).Rows.Count > 0 AndAlso
               Not String.IsNullOrEmpty(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").ToString()) Then
                numbers = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue").ToString().Split("-"c)
            End If
        Catch ex As Exception
            ' Initialize to empty array instead of Nothing when exception occurs
            numbers = New String() {}
        End Try

        ' If numbers is still Nothing, return empty array
        If numbers Is Nothing Then
            numbers = New String() {}
        End If

        Return numbers
    End Function

    Private Sub SendVoucherAsTextToOwners(numbers As String())

        _Customer = Me.TextReferanceName.Text
        ' Check if we have a customer mobile number
        If numbers Is Nothing Then
            Return
        End If

        Try
            ' Start building the message
            Dim messageBuilder As New System.Text.StringBuilder()

            ' Add invoice info
            Select Case Me.DocName.EditValue
                Case 2
                    messageBuilder.AppendLine("فاتورة مبيعات رقم: " & BarStaticItemVoucherCounter.Caption)
                Case 12
                    messageBuilder.AppendLine("مردودات مبيعات رقم: " & BarStaticItemVoucherCounter.Caption)
            End Select
            messageBuilder.AppendLine(Me.BarPosNoName.Caption)
            messageBuilder.AppendLine("تاريخ: " & Format(Now, "yyyy-MM-dd HH:mm"))
            messageBuilder.AppendLine("الزبون: " & _Customer)
            messageBuilder.AppendLine("--------------------------------")

            ' Add column headers
            messageBuilder.AppendLine("الكمية    السعر    المجموع")
            messageBuilder.AppendLine("--------------------------------")

            ' Add items from grid
            Dim totalQuantity As Decimal = 0
            Dim totalAmount As Decimal = 0

            If GridPosVoucher.MainView.Name = "TileView2" Then
                For i As Integer = 0 To TileView2.RowCount - 1
                    Dim itemName As String = TileView2.GetRowCellValue(i, "ItemName").ToString()
                    Dim quantity As Decimal = CDec(TileView2.GetRowCellValue(i, "Quantity"))
                    Dim price As Decimal = CDec(TileView2.GetRowCellValue(i, "Price"))
                    Dim amount As Decimal = CDec(TileView2.GetRowCellValue(i, "Amount"))

                    ' Format the line with item name on separate line
                    messageBuilder.AppendLine(itemName)
                    messageBuilder.AppendLine(String.Format("{0,5:N1} {1,8:N2} {2,8:N2}",
                                                 quantity, price, amount))

                    totalQuantity += quantity
                    totalAmount += amount
                Next
            ElseIf GridPosVoucher.MainView.Name = "GridView1" Then
                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim itemName As String = GridView1.GetRowCellValue(i, "ItemName").ToString()
                    Dim quantity As Decimal = CDec(GridView1.GetRowCellValue(i, "Quantity"))
                    Dim price As Decimal = CDec(GridView1.GetRowCellValue(i, "Price"))
                    Dim amount As Decimal = CDec(GridView1.GetRowCellValue(i, "Amount"))

                    ' Format the line with item name on separate line
                    messageBuilder.AppendLine(itemName)
                    messageBuilder.AppendLine(String.Format("{0,5:N1} {1,8:N2} {2,8:N2}",
                                                 quantity, price, amount))

                    totalQuantity += quantity
                    totalAmount += amount
                Next
            End If

            ' Add footer information
            messageBuilder.AppendLine("--------------------------------")
            messageBuilder.AppendLine("إجمالي الكمية: " & Convert.ToDecimal(totalQuantity).ToString("N1"))

            ' Add discount information if applicable
            If TextVoucherDiscount.EditValue > 0 OrElse TextVoucherDiscount2.EditValue > 0 Then
                messageBuilder.AppendLine("المبلغ قبل الخصم: " & Convert.ToDecimal(TexVouchertAmountBeforeDiscount.EditValue).ToString("N") & " شيكل")

                If TextVoucherDiscount.EditValue > 0 Then
                    messageBuilder.AppendLine("خصم الأصناف: " & Convert.ToDecimal(TextVoucherDiscount.EditValue).ToString("N") & " شيكل")
                End If

                If TextVoucherDiscount2.EditValue > 0 Then
                    messageBuilder.AppendLine("خصم الفاتورة: " & Convert.ToDecimal(TextVoucherDiscount2.EditValue).ToString("N") & " شيكل")
                End If
            End If

            ' Add final amount
            messageBuilder.AppendLine("إجمالي المبلغ: " & Convert.ToDecimal(TexVouchertAmountAfterDiscount.EditValue).ToString("N") & " شيكل")


            ' Add payment info if available
            If TextPaidAmount.EditValue > 0 Then
                messageBuilder.AppendLine("المدفوع: " & Convert.ToDecimal(TextPaidAmount.EditValue).ToString("N") & " شيكل")
                messageBuilder.AppendLine("المتبقي: " & Convert.ToDecimal(TextReturnAmount.EditValue).ToString("N") & " شيكل")
            End If

            If GlobalVariables._PosPrintReferanceBalance Then
                If Not String.IsNullOrEmpty(_CustomerBalance) AndAlso _CustomerBalance <> "0.00" Then
                    messageBuilder.AppendLine("--------------------------------")
                    messageBuilder.AppendLine("رصيد الزبون: " & _CustomerBalance & " شيكل")
                Else
                    'MsgBox("الرصيد صفر")
                End If
            Else
                'MsgBox(" خيار طباعة الرصيد غير مغعل  ")
            End If
            ' Send the message using the existing WhatsApp function
            ' Dim messageText As String = messageBuilder.ToString()

            Dim messageText As String = messageBuilder.ToString().Replace(Environment.NewLine, "\n")
            For Each word As String In numbers
                If word = "0" Then Exit Sub
                'If Len(word) = 18 Then word = word & "@g.us"
                SendSMSMessage(word, messageText, "WhatsApp", False, _Customer)
                PosAddLOG(Me.DocCode.Text, "Invoice sent as WhatsApp text message to " & _CustMobile)
            Next


        Catch ex As Exception
            PosAddLOG(Me.DocCode.Text, "Error sending WhatsApp text: " & ex.Message)
            'MsgBoxShowError("حدث خطأ أثناء إرسال الفاتورة: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearPosVoucher()
        ClearPosJournalTable(Me.DocCode.Text)
        TextTotalQuantity.EditValue = 0
        TextVoucherDiscount.EditValue = 0
        TexVouchertAmountBeforeDiscount.EditValue = 0
        TextVoucherAmount.EditValue = 0
        TextPaidAmount.EditValue = 0
        TexVouchertAmountAfterDiscount.EditValue = 0
        CheckPrint.Checked = False
        Me.DocCode.Text = CreateRandomCode()
        Me.BarStaticItemVoucherCounter.Caption = GetAndIncrementVouchersCounter(GlobalVariables._ShiftID)
        'ReferanceNameItem.Caption = "مبيعات نقدية"
        TextReferanceName.Text = "زبون نقدي"
        _PosVoucherNote = ""
        GlobalVariables._PayCardName = ""
        TextReferanceName.Text = ""
        Text = "فاتورة مبيعات"
        _PosVoucherNote = ""
        TextOtherAccountNo.Caption = _DefaultBaseCashAccount
        TextOtherAccountName.Caption = __DefaultBaseCashAccountName
        LayoutControl1.BackColor = Color.White
        DocName.EditValue = 2

        Dim s As String = "{0} {1} {2}"
        Dim msg As String = String.Format(s, " الصافي للدفع: ", "#,##0.0", " شيكل ")
        TexVouchertAmountAfterDiscount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        TexVouchertAmountAfterDiscount.Properties.Mask.EditMask = msg
        TexVouchertAmountAfterDiscount.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TextReferanceNo.Text = "0"
        Me.TextCarNumber.Text = ""
        Me.TextShassiNumber.Text = ""
        GridControlCarsParts.DataSource = Nothing
        'PosAddLOG(Me.DocCode.Text, "  ClearPosVoucher ")
    End Sub
    Private Sub ClearPosJournalTable(DocCode As String)
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery(" Delete  FROM [dbo].[POSJournal] 
                                        Where DocCode='" & DocCode & "'")
        txtBarcode.Focus()
    End Sub

    Private Sub PrintVoucher()
        If _PrintVoucherByItemGroup = False Then
            BackgroundWorker1.WorkerSupportsCancellation = True
            If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
        Else
            PrintVoucherFromPosJournalOrHoldJournal("PosJournal", False, False)
        End If
        PosAddLOG(Me.DocCode.Text, "PrintVoucherv after save ")
    End Sub

    Private Sub ClearAllRows()
        Dim i As Integer = 0
        While i < GridView1.RowCount
            GridView1.DeleteRow(i)
        End While
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If XtraMessageBox.Show("هل تريد اغلاق البرنامج؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            End If
        Else
            If XtraMessageBox.Show("Are You Sure?", "Close", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            End If
        End If
        PosAddLOG(Me.DocCode.Text, "Close System ")
    End Sub
    Public Function GetAndIncrementVouchersCounter(_ShiftID As Integer) As Integer
        Dim connectionString As String = My.Settings.TrueTimeConnectionString
        Dim newCounter As Integer = 0

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using transaction As SqlTransaction = conn.BeginTransaction()
                Try
                    Dim selectQuery As String = "UPDATE PosShifts " &
                                            "SET VoucherCounter = IsNull(VoucherCounter,0) + 1 " &
                                            "OUTPUT inserted.VoucherCounter " &
                                            "WHERE ShiftID = " & _ShiftID
                    Using cmd As New SqlCommand(selectQuery, conn, transaction)
                        newCounter = Convert.ToInt32(cmd.ExecuteScalar())
                    End Using

                    ' Commit transaction after successfully retrieving and updating the counter
                    transaction.Commit()
                Catch ex As Exception
                    ' Rollback in case of error
                    transaction.Rollback()
                    Throw New Exception("Error updating VouchersCounter: " & ex.Message)
                End Try
            End Using
        End Using

        Return newCounter
    End Function
    Private Sub PrintVoucherFromPosJournalOrHoldJournal(_Journal As String, OnlyKitchenPrinters As Boolean, AllItems As Boolean)

        Dim Sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Select [DocID],[ItemName],([DocAmount]+IsNull(VoucherDiscount,0)) as Amount,InputDateTime,DocNoteByAccount,
                             [StockQuantity] as Quantity ,[StockPrice] as Price,[DocCode],IsNull([StockDiscount]*StockQuantity,0) as StockDiscount,
                             IsNull(VoucherDiscount,0) as VoucherDiscount,ISNULL(DocNotes,'') AS DocNotes,IsNull(VoucherCounter,0) As VoucherCounter,POSVoucherPayType,IsNull(PrinterName,'') As PrinterName
                      From [dbo].[" & _Journal & "] J 
                      Where [DocCode]=N'" & Me.DocCode.Text & "'"

        If OnlyKitchenPrinters And AllItems = False Then
            sqlstring += " And Printed=0"
        End If

        Sql.SqlTrueAccountingRunQuery(sqlstring)
        Dim VoucherDataTable As DataTable = Sql.SQLDS.Tables(0)

        If Sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub


        'Dim _VoucherCounter As Integer = GetAndIncrementVouchersCounter()

        If OnlyKitchenPrinters Then
            PrintGroupedKitchenReports(VoucherDataTable, Me.BarStaticItemVoucherCounter.Caption)
        Else

            Dim report As New ReportPos() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                Dim _MyCompanyData2 = GetCompanyData()
                .XrLabelCompanyName.Text = _MyCompanyData2.CompanyName
                .XrLabelAddress.Text = _MyCompanyData2.CompanyAddress & vbCrLf
                .XrLabelMobile.Text = _MyCompanyData2.CompanyMobile & " " & _MyCompanyData2.CompanyPhone
                .XrLabelVoucherNo.Text = "Inv.#: " & Me.BarStaticItemVoucherCounter.Caption
                .XrLabelUserName.Text = "الموظف: " & BarItemUserName.Caption
                .XrLabelNote.Text = "ملاحظة" & " : " & .XrLabelNote.Text
                If _FromTableVouchers Then
                    If Me.DocName.EditValue = 2 Then .XrLabelVoucherName.Text = "مطالبة"
                    If Me.DocName.EditValue = 12 Then .XrLabelVoucherName.Text = "الغاء"
                Else
                    If Me.DocName.EditValue = 2 Then .XrLabelVoucherName.Text = "فاتورة"
                    If Me.DocName.EditValue = 12 Then .XrLabelVoucherName.Text = "مردودات مبيعات"
                End If

                Dim _PaidAmount As Decimal = Me.TextPaidAmount.EditValue
                If _PaidAmount = 0 And _FromTableVouchers <> True Then
                    If _DebitInvoice = False Then
                        _PaidAmount = _VouchertAmountAfterDiscount
                        .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                    Else
                        _PaidAmount = 0
                        .XrLabelReturnAmount.Text = 0
                        .XrLabelReturnAmount.Visible = False
                        .XrLabelReturnAmountLabel.Visible = False
                    End If
                End If
                If _FromTableVouchers Then
                    _PaidAmount = 0
                    .XrLabelReturnAmount.Text = 0
                    .XrLabelPaidAmount.Text = 0
                    .XrLabelPaidAmount.Visible = False
                    .XrLabelReturnAmount.Visible = False
                    .XrLabelPaidAmountLabel.Visible = False
                    .XrLabelReturnAmountLabel.Visible = False
                Else
                    .XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")
                    .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                End If

                If _CustomerNo = 0 Then
                    .XrLabelCustomer.Text = "  الزبون: " & _Customer & " / " & Sql.SQLDS.Tables(0).Rows(0).Item("POSVoucherPayType")
                Else
                    .XrLabelCustomer.Text = "  الزبون: " & _Customer & " / " & _CustomerNo
                End If

                If _DebitInvoice = True And GlobalVariables._PosPrintReferanceBalance = True Then
                    .XrLabelBalance.Text = "( الرصيد يشمل الفاتورة الحالية " & _CustomerBalance & " شيكل )"
                End If
                .XrLabelNote.Text = "ملاحظات: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocNotes")
                .PosVoucherNote1.Text = _PosVoucherNote1
                .PosVoucherNote2.Text = _PosVoucherNote2
                report.PageWidth = _PrinterSize
                .XrPictureBox1.Image = Me.CompanyLogo.Image
                .XrPictureQR.Image = (Me.PictureEditCompanyQR.Image)
                If Me.DocName.EditValue = 12 Then
                    .XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
                End If
                If sendVoucherToCustomer = True And sendVoucherPDFToCustomer = True And Me.DocName.EditValue = 2 And _DebitInvoice = True Then
                    Dim _RefData = GetRefranceData(_CustomerNo)
                    report.ExportToPdf("فاتورة نقطة بيع.pdf")
                    SendFileToWhatsApp(_RefData.RefMobile, "فاتورة نقطة بيع.pdf", "فاتورة نقطة بيع", "فاتورة نقطة بيع" & ": " & Me.BarStaticItemVoucherCounter.Caption & "-" & _Customer, _Customer)

                End If
            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)
            ' printTool.ShowPreviewDialog()

            If _DefaultPrinterPOS <> "" Then
                printTool.PrinterSettings.PrinterName = _DefaultPrinterPOS
            End If



            For i = 1 To posNumberOfCopies
                printTool.Print()
            Next
            Me.TextPaidAmount.EditValue = 0
            Me.TextReturnAmount.EditValue = 0
        End If

    End Sub

    Public Sub PrintGroupedKitchenReports(VoucherDataTable As DataTable, _VoucherCounter As Integer)
        Try
            ' Group VoucherDataTable by PrinterName
            Dim groupedData = VoucherDataTable.AsEnumerable().GroupBy(Function(row) row.Field(Of String)("PrinterName"))

            ' Loop through each group and print
            For Each group In groupedData
                Dim printerName As String = group.Key

                ' Only print if printerName is not empty
                If Not String.IsNullOrEmpty(printerName) Then
                    ' Create a new report instance
                    Dim kitchenReport As New KitchenReport()

                    ' Convert the grouped data back to a DataTable
                    Dim filteredData As DataTable = group.CopyToDataTable()

                    ' Set the report data source
                    kitchenReport.DataSource = filteredData

                    ' Set report labels and additional details
                    With kitchenReport
                        .XrLabelVoucherNo.Text = "Inv.#: " & _VoucherCounter
                        .XrLabelUserName.Text = BarItemUserName.Caption & ""
                        If Me.DocName.EditValue = 2 Then .XrLabelVoucherName.Text = " طلبية "
                        .XrLabelTableName.Text = Me.LabelControlTableName.Text
                        .XrLabelCustomer.Text = TextReferanceName.Text
                    End With

                    ' Generate the report
                    SinglePageHelper.GenerateSinglePageReport(kitchenReport)

                    ' Print using the respective printer
                    Dim printTool As New ReportPrintTool(kitchenReport)
                    printTool.PrinterSettings.PrinterName = printerName
                    printTool.Print()
                End If
            Next
        Catch ex As Exception
            MsgBoxShowError(" لا يمكن الوصول الى الطابعة ")
        End Try

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim sql As New SQLControl
        Dim sqlString As String = "SELECT [DocID], CASE WHEN U.id <> 1 then  concat([ItemName],'/',U.name) else [ItemName] end as ItemName , ([DocAmount] + ISNULL(VoucherDiscount, 0)) AS Amount, DocName, InputDateTime, Referance, " &
                             "DocNoteByAccount, [StockQuantity] AS Quantity, [StockPrice] AS Price, R.[RefMobile] AS RefMobile, " &
                             "[DocCode], D.EmployeeName AS UserName, ISNULL([StockDiscount] * StockQuantity, 0) AS StockDiscount, " &
                             "ISNULL(VoucherDiscount, 0) AS VoucherDiscount, ISNULL(VoucherCounter, 0) AS VoucherCounter, POSVoucherPayType " &
                             "FROM [dbo].[Journal] J " &
                             "LEFT JOIN EmployeesData D ON D.EmployeeID = J.CurrentUserID " &
                             "LEFT JOIN [dbo].[Referencess] R ON J.Referance = R.[RefNo] " &
                             "LEFT JOIN [dbo].[Units] U on U.id=J.StockUnit " &
                             "WHERE 1=1 "

        If _TempDocName = 2 Then
            sqlString += "AND [CredAcc] <> '0' "
        ElseIf _TempDocName = 12 Then
            sqlString += "AND [DebitAcc] <> '0' "
        End If

        sqlString += "AND [DocCode] = '" & _TempDocVoucherCode & "'"
        sql.SqlTrueAccountingRunQuery(sqlString)

        ' Handle different printer sizes
        If _PrinterSize > 200 AndAlso _PrinterSize < 300 Then
            PrintMediumSizeReceipt(sql.SQLDS.Tables(0))
        ElseIf _PrinterSize <= 200 Then
            PrintSmallSizeReceipt(sql.SQLDS.Tables(0))
        ElseIf _PrinterSize > 300 AndAlso _PrinterSize <= 400 Then
            PrintA5SizeReceipt(sql.SQLDS.Tables(0))
        ElseIf _PrinterSize = 1000 Then
            PrintHebrewReceipt(sql.SQLDS.Tables(0))
        End If
    End Sub

    Private Sub PrintMediumSizeReceipt(dataTable As DataTable)
        Dim report As New ReportPos() With {.DataSource = dataTable}

        With report
            .ShowPrintMarginsWarning = False
            .PrintingSystem.ShowMarginsWarning = False

            ' Set company data
            Dim companyData = GetCompanyData()
            .XrLabelCompanyName.Text = companyData.CompanyName
            .XrLabelAddress.Text = companyData.CompanyAddress & vbCrLf
            .XrLabelMobile.Text = companyData.CompanyMobile & " " & companyData.CompanyPhone

            ' Set invoice number
            If useVoucherCounter = False Then
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("DocID")
            Else
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("VoucherCounter")
            End If

            ' Set additional labels
            .XrLabelUserName.Text = "الموظف: " & dataTable.Rows(0).Item("UserName")
            .XrLabelNote.Text = "ملاحظة: " & _TempVoucherNote

            ' Set document type
            If dataTable.Rows(0).Item("DocName") = 2 Then
                .XrLabelVoucherName.Text = "فاتورة مبيعات"
            ElseIf dataTable.Rows(0).Item("DocName") = 12 Then
                .XrLabelVoucherName.Text = "مردودات مبيعات"
            End If

            ' Handle payment amounts
            If _TempPaidAmount = 0 Then
                If _DebitInvoice = False Then
                    _TempPaidAmount = _VouchertAmountAfterDiscount
                    .XrLabelReturnAmount.Text = (_TempPaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                Else
                    _TempPaidAmount = 0
                    .XrLabelReturnAmount.Text = "0"
                    .XrLabelReturnAmount.Visible = False
                    .XrLabelReturnAmountLabel.Visible = False
                End If
            End If

            .XrLabelPaidAmount.Text = _TempPaidAmount.ToString("N1")
            .XrLabelReturnAmount.Text = (_TempPaidAmount - _VouchertAmountAfterDiscount).ToString("N1")

            ' Set customer info
            If _CustomerNo = 0 Then
                .XrLabelCustomer.Text = "  الزبون: " & _Customer & " / " & dataTable.Rows(0).Item("POSVoucherPayType")
            Else
                .XrLabelCustomer.Text = "  الزبون: " & _Customer & " / " & _CustomerNo
            End If

            ' Add balance if needed
            If _DebitInvoice = True AndAlso GlobalVariables._PosPrintReferanceBalance = True Then
                .XrLabelBalance.Text = "( الرصيد يشمل الفاتورة الحالية " & _CustomerBalance & " شيكل )"
            End If

            ' Set notes and images
            .PosVoucherNote1.Text = _PosVoucherNote1
            .PosVoucherNote2.Text = _PosVoucherNote2
            report.PageWidth = _PrinterSize
            .XrPictureBox1.Image = Me.CompanyLogo.Image
            .XrPictureQR.Image = Me.PictureEditCompanyQR.Image

            ' Special handling for returns
            If _TempDocName = 12 Then
                .XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
            End If

            ' Handle PDF export for WhatsApp if needed
            If sendVoucherPDFToCustomer = True AndAlso _TempDocName = 2 And _CustomerNo <> 0 Then
                Dim refData = GetRefranceData(_CustomerNo)
                report.ExportToPdf("فاتورة نقطة بيع.pdf")
                SendFileToWhatsApp(refData.RefMobile, "فاتورة نقطة بيع.pdf", "فاتورة نقطة بيع",
                          "فاتورة نقطة بيع: " & .XrLabelVoucherNo.Text & "-" & _Customer, _Customer)

                If shalashCo = True Then
                    'SendFileToWhatsAppGroup("120363418766138503", "فاتورة نقطة بيع.pdf", _Customer,
                    '              "فاتورة نقطة بيع: " & .XrLabelVoucherNo.Text & " بتاريخ " & Format(Now, "dd-MM-yyyy HH:mm:ss"))
                    SendFileToWhatsApp("120363418766138503", "فاتورة نقطة بيع.pdf", _Customer,
              "فاتورة نقطة بيع: " & .XrLabelVoucherNo.Text & " بتاريخ " & Format(Now, "dd-MM-yyyy HH:mm:ss"), "")
                End If
            End If
        End With

        ' Generate and print
        SinglePageHelper.GenerateSinglePageReport(report)
        Dim printTool As New ReportPrintTool(report)

        If _DefaultPrinterPOS <> "" Then
            printTool.PrinterSettings.PrinterName = _DefaultPrinterPOS
        End If

        For i = 1 To posNumberOfCopies
            printTool.Print()
        Next

        ' Print kitchen copy if needed
        If _KitchenPrinter <> "" AndAlso _ResturantMode = False Then
            PrintKitchenCopy(dataTable)
        End If

        ResetReceiptVariables()
    End Sub

    Private Sub PrintKitchenCopy(dataTable As DataTable)
        Dim kitchenReport As New KitchenReport() With {.DataSource = dataTable}

        With kitchenReport
            .ShowPrintMarginsWarning = False
            .PrintingSystem.ShowMarginsWarning = False

            If useVoucherCounter = False Then
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("DocID")
            Else
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("VoucherCounter")
            End If

            .XrLabelUserName.Text = "الموظف: " & dataTable.Rows(0).Item("UserName")

            If Not String.IsNullOrWhiteSpace(_TempVoucherNote) Then
                .XrLabelNote.Text = "ملاحظة: " & _TempVoucherNote
            End If

            If dataTable.Rows(0).Item("DocName") = 2 Then
                .XrLabelVoucherName.Text = " طلبية"
            ElseIf dataTable.Rows(0).Item("DocName") = 12 Then
                .XrLabelVoucherName.Text = " الغاء"
            End If

            .XrLabelCustomer.Text = "  الزبون: " & _Customer
        End With

        SinglePageHelper.GenerateSinglePageReport(kitchenReport)
        Dim printTool As New ReportPrintTool(kitchenReport)
        printTool.PrinterSettings.PrinterName = _KitchenPrinter
        printTool.Print()
    End Sub

    Private Sub PrintSmallSizeReceipt(dataTable As DataTable)
        Dim report As New ReportPosThin() With {.DataSource = dataTable}

        With report
            .ShowPrintMarginsWarning = False
            .PrintingSystem.ShowMarginsWarning = False

            ' Set company data
            Dim companyData = GetCompanyData()
            .XrLabelCompanyName.Text = companyData.CompanyName
            .XrLabelAddress.Text = companyData.CompanyAddress

            ' Set invoice number
            If useVoucherCounter = False Then
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("DocID")
            Else
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("VoucherCounter")
            End If

            .XrLabelUserName.Text = "الموظف: " & dataTable.Rows(0).Item("UserName")
            .XrLabelNote.Text = "ملاحظة: " & _TempVoucherNote

            ' Handle payment amounts
            If _TempPaidAmount = 0 Then
                If _DebitInvoice = False Then
                    _TempPaidAmount = _VouchertAmountAfterDiscount
                    .XrLabelReturnAmount.Text = (_TempPaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                Else
                    _TempPaidAmount = 0
                    .XrLabelReturnAmount.Text = "0"
                    .XrLabelReturnAmount.Visible = False
                    .XrLabel10.Visible = False
                End If
            End If

            .XrLabelPaidAmount.Text = _TempPaidAmount.ToString("N1")
            .XrLabelReturnAmount.Text = (_TempPaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
            .XrLabelCustomer.Text = "  الزبون: " & _Customer

            If _DebitInvoice = True AndAlso GlobalVariables._PosPrintReferanceBalance = True Then
                .XrLabelCustomer.Text += Environment.NewLine & "( الرصيد يشمل الفاتورة " & _CustomerBalance & " شيكل )"
            End If

            .PosVoucherNote1.Text = _PosVoucherNote1
            .PosVoucherNote2.Text = _PosVoucherNote2
            report.PageWidth = _PrinterSize
            .XrPictureBox1.Image = Me.CompanyLogo.Image
            .XrPictureQR.Image = Me.PictureEditCompanyQR.Image

            If _TempDocName = 12 Then
                .XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
            End If
        End With

        SinglePageHelper.GenerateSinglePageReport(report)
        Dim printTool As New ReportPrintTool(report)

        For i = 1 To posNumberOfCopies
            printTool.Print()
        Next

        ResetReceiptVariables()
    End Sub

    Private Sub PrintA5SizeReceipt(dataTable As DataTable)
        Dim report As New ReportPosA5() With {.DataSource = dataTable}

        With report
            .ShowPrintMarginsWarning = False
            .PrintingSystem.ShowMarginsWarning = False

            ' Set company data
            Dim companyData = GetCompanyData()
            .XrLabelCompanyName.Text = companyData.CompanyName
            .XrLabelAddress.Text = companyData.CompanyAddress

            ' Set invoice number
            If useVoucherCounter = False Then
                .XrLabelVoucher.Text = "Inv.#: " & dataTable.Rows(0).Item("DocID")
            Else
                .XrLabelVoucher.Text = "Inv.#: " & dataTable.Rows(0).Item("VoucherCounter")
            End If

            .XrLabelUserName.Text = "الموظف: " & dataTable.Rows(0).Item("UserName")
            .XrLabelNote.Text = "ملاحظة: " & _TempVoucherNote

            ' Add customer memo if available
            If CStr(_CustomerNo) <> "" Then
                Dim refData = GetRefranceData(_CustomerNo)
                .XrLabelNote.Text += " " & refData.RefMemo
            End If

            .XrLabelDocDateTime.Text = "التاريخ: " & Format(CDate(dataTable.Rows(0).Item("InputDateTime")), "yyyy-MM-dd HH:mm")

            If dataTable.Rows(0).Item("DocName") = 2 Then
                .XrLabelVoucherName.Text = "سند استلام"
            ElseIf dataTable.Rows(0).Item("DocName") = 12 Then
                .XrLabelVoucherName.Text = "مردودات مبيعات"
            End If

            ' Handle payment amounts
            If _TempPaidAmount = 0 Then
                If _DebitInvoice = False Then
                    _TempPaidAmount = _VouchertAmountAfterDiscount
                Else
                    _TempPaidAmount = 0
                End If
            End If

            ' Set customer info
            Dim refMobile As String = ""
            If Not IsDBNull(dataTable.Rows(0).Item("RefMobile")) Then
                refMobile = dataTable.Rows(0).Item("RefMobile")
            End If

            .XrLabelCustomer.Text = "  " & _Customer
            .XrLabelMobile.Text = "  Tel:" & refMobile

            If _DebitInvoice = True AndAlso GlobalVariables._PosPrintReferanceBalance = True Then
                .XrLabelRefBalance.Text = " الرصيد يشمل الفاتورة " & _CustomerBalance & " شيكل "
            End If

            .XrPictureBox1.Image = Me.CompanyLogo.Image
        End With

        SinglePageHelper.GenerateSinglePageReport(report)
        Dim printTool As New ReportPrintTool(report)

        For i = 1 To posNumberOfCopies
            printTool.Print()
        Next

        ResetReceiptVariables()
    End Sub

    Private Sub PrintHebrewReceipt(dataTable As DataTable)
        Dim report As New ReportPosHebrew() With {.DataSource = dataTable}

        With report
            .ShowPrintMarginsWarning = False
            .PrintingSystem.ShowMarginsWarning = False

            ' Set company data
            Dim companyData = GetCompanyData()
            .XrLabelCompanyName.Text = companyData.CompanyName
            .XrLabelAddress.Text = companyData.CompanyAddress
            .XrLabelVatNo.Text = "Vat No.: " & companyData.CompanyVAT
            .XrLabelMobile.Text = companyData.CompanyMobile

            ' Set invoice number
            If useVoucherCounter = False Then
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("DocID")
            Else
                .XrLabelVoucherNo.Text = "Inv.#: " & dataTable.Rows(0).Item("VoucherCounter")
            End If

            .XrLabelUserName.Text = "עוֹבֵד: " & dataTable.Rows(0).Item("UserName")
            .XrLabelNote.Text = "הערה: " & _TempVoucherNote

            If dataTable.Rows(0).Item("DocName") = 2 Then
                .XrLabelVoucherName.Text = "חשבון מכירה"
            ElseIf dataTable.Rows(0).Item("DocName") = 12 Then
                .XrLabelVoucherName.Text = "החזרות מכירות"
            End If

            ' Handle payment amounts
            If _TempPaidAmount = 0 Then
                If _DebitInvoice = False Then
                    _TempPaidAmount = _VouchertAmountAfterDiscount
                Else
                    _TempPaidAmount = 0
                End If
            End If

            ' Translate Arabic customer text to Hebrew
            If _Customer = "زبون نقدي" Then
                _Customer = "לקוח מזומן"
            End If

            .XrLabelCustomer.Text = "  הלקוח: " & _Customer

            If _DebitInvoice = True AndAlso GlobalVariables._PosPrintReferanceBalance = True Then
                .XrLabelCustomer.Text += "( היתרה כוללת את החשבון הנוכחי " & _CustomerBalance & " NIS   )"
            End If

            If _DebitInvoice = True Then
                .XrLabelRefMobile.Text = " Mobile:" & _CustMobile
            End If

            .PosVoucherNote1.Text = _PosVoucherNote1
            .PosVoucherNote2.Text = _PosVoucherNote2
            .PageWidth = 290
            .XrPictureBox1.Image = Me.CompanyLogo.Image

            If _TempDocName = 12 Then
                .XrLabel3.TextFormatString = "{0:נטו להחזרה: #.0 }"
            End If
        End With

        SinglePageHelper.GenerateSinglePageReport(report)
        Dim printTool As New ReportPrintTool(report)

        For i = 1 To posNumberOfCopies
            printTool.Print()
        Next

        ResetReceiptVariables()
    End Sub

    Private Sub ResetReceiptVariables()
        _TempDocVoucherCode = ""
        _TempVoucherNote = ""
        _TempPaidAmount = 0
        _VouchertAmountAfterDiscount = 0
        _Customer = ""
        _CustomerNo = 0
        _CustomerBalance = ""
        _CustMobile = ""
        _DebitInvoice = False
        _TempDocName = 2
    End Sub

    Private Sub TileView2_ContextButtonClick(ByVal sender As Object, ByVal e As ContextItemClickEventArgs) _
    Handles TileView2.ContextButtonClick
        Dim view1 = TryCast(sender, DevExpress.XtraGrid.Views.Tile.TileView)
        Dim rowHandle = (TryCast(e.DataItem, DevExpress.XtraGrid.Views.Tile.TileViewItem)).RowHandle
        view1.FocusedRowHandle = rowHandle

        Dim view As TileView = TryCast(sender, TileView)
        Dim _TransID As Integer = TileView2.GetFocusedRowCellValue("ID")
        Select Case e.Item.Tag
            Case "Edit"
                If Me.TextVoucherDiscount2.EditValue > 0 Then
                    XtraMessageBox.Show(" لا يمكن تعديل الاسعار بعد خصم الفاتورة يرجى ازالة خصم الفاتورة أولا")
                    Exit Sub
                End If
                PosAddLOG(Me.DocCode.Text, "Start Edit Item ")
                Dim _RefNo As Integer = 0
                If Me.TextReferanceNo.Text <> "" Then
                    _RefNo = Me.TextReferanceNo.Text
                End If
                Try
                    Dim _F As New PosEditItemsInPOS(_TransID, showLastPurchasePrice, showLastTransForCustomer, _RefNo)
                    With _F
                        ' .TextID.Text = 0
                        .TextID.Text = _TransID
                        If Me.TextVoucherDiscount2.EditValue > 0 Then
                            .TextDiscountAmount.ReadOnly = True
                            .TextDiscountPercentage.ReadOnly = True
                        End If
                        .TextStockQuantity.Select()
                        If .ShowDialog() = DialogResult.OK Then
                            MsgBox("ok")
                        Else
                            GetPosJournalTable()
                            txtBarcode.Focus()
                        End If
                    End With
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Delete"
                DeleteRowFromPOSVoucher(_TransID)
                txtBarcode.Focus()
        End Select

        If TileView2.RowCount <> rowHandle Then
            view1.FocusedRowHandle = rowHandle
        Else
            view1.FocusedRowHandle = rowHandle - 1
        End If

    End Sub
    Private Sub DeleteRowFromPOSVoucher(_TransID As Integer)
        If _TransID = 0 Then
            'XtraMessageBox.Show("لا يمكن حذف هذا السطر من الفاتورة" & vbCrLf & "TransID: " & _TransID,
            '                "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBarcode.Focus()
            Return
        End If

        Try
            Using sqlCon As New SqlConnection(My.Settings.TrueTimeConnectionString)
                Using sqlComm As New SqlCommand("PosGetAndDeleteDeletedItems", sqlCon)
                    sqlComm.CommandType = CommandType.StoredProcedure

                    ' إدخال المعاملات
                    sqlComm.Parameters.AddWithValue("@JournalID", _TransID)

                    'مخرجات:             اسم الصنف
                    'Dim paramItemName As New SqlParameter("@ItemName", SqlDbType.NVarChar, 200)
                    'paramItemName.Direction = ParameterDirection.Output
                    'sqlComm.Parameters.Add(paramItemName)

                    ' قيمة الإرجاع (عدد الصفوف المحذوفة)
                    Dim paramReturn As New SqlParameter()
                    paramReturn.Direction = ParameterDirection.ReturnValue
                    sqlComm.Parameters.Add(paramReturn)

                    sqlCon.Open()

                    ' تنفيذ الحذف
                    sqlComm.ExecuteNonQuery()

                    'Dim itemName As String = If(IsDBNull(paramItemName.Value), "غير معروف", paramItemName.Value.ToString())
                    'Dim rowsAffected As Integer = CInt(paramReturn.Value)

                    '' تأكيد الحذف
                    'If rowsAffected > 0 Then
                    '    'XtraMessageBox.Show($"تم حذف الصنف: {itemName} بنجاح." & vbCrLf &
                    '    '                $"عدد السجلات المحذوفة: {rowsAffected}",
                    '    '                "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Console.WriteLine($"تم حذف الصنف: {itemName} بنجاح." & vbCrLf &
                    '                    $"عدد السجلات المحذوفة: {rowsAffected}")
                    'Else
                    '    XtraMessageBox.Show("لم يتم العثور على السجل المطلوب حذفه.",
                    '                    "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If
                End Using
            End Using

            ' تحديث الجدول بعد الحذف
            GetPosJournalTable()

        Catch ex As Exception
            XtraMessageBox.Show("حدث خطأ أثناء الحذف: " & ex.Message,
                            "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub GetPosJournalTable()
        Dim focusedRow As Integer = TileView2.FocusedRowHandle
        Try
            Dim VoucherAmount As Decimal = 0
            Dim ItemsDiscount As Decimal = 0
            Dim TextTotalQuantity As Decimal = 0
            Dim VoucherDiscount As Decimal = 0
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            ' تم اضافة كود التعديل لحل مشكلة الرداي كلين 
            PosJournalAdapter = New SqlDataAdapter("
                                Select ID,StockID,ItemName ,[StockUnit],[StockQuantityByMainUnit],[StockQuantity] as Quantity ,ISNULL(ReferanceName,'') AS ReferanceName ,Referance,
              [StockPrice] as Price ,[StockItemPrice],[StockDebitWhereHouse],[SalesPerson] ,(DocAmount+isnull(VoucherDiscount,0)) as Amount,StockDiscount as Discount,StockBarcode,
            StockDiscount*StockQuantity as TotalDiscount,isnull(VoucherDiscount,0) as VoucherDiscount,PosNo,Produced,IsNull(PriceEdited,0) as PriceEdited,DocNoteByAccount,UnitName,TableID
              FROM [dbo].[POSJournal] Where PosNo=" & My.Settings.POSNo & " And DeviceName='" & GlobalVariables.CurrDevice & "'" & "  order by ID Desc ", Con)


            DS = New System.Data.DataSet()
            PosJournalAdapter.Fill(DS, "POSJournal")
            GridPosVoucher.DataSource = DS.Tables(0)
            PosSecondScreen.GridPosVoucher.DataSource = DS.Tables(0)

            If DS.Tables(0).Rows.Count <> 0 Then
                VoucherAmount = Convert.ToDecimal(DS.Tables(0).Compute("SUM(Amount)", String.Empty))
                ItemsDiscount = Convert.ToDecimal(DS.Tables(0).Compute("SUM(TotalDiscount)", String.Empty))
                TextTotalQuantity = Convert.ToDecimal(DS.Tables(0).Compute("sum(Quantity)", String.Empty))
                VoucherDiscount = Convert.ToDecimal(DS.Tables(0).Compute("SUM(VoucherDiscount)", String.Empty))
                If DS.Tables(0).Rows(0).Item("ReferanceName") <> "زبون نقدي" Then Me.TextReferanceName.Text = DS.Tables(0).Rows(0).Item("ReferanceName")
                Me.TextReferanceNo.Text = DS.Tables(0).Rows(0).Item("Referance")
            End If
            Me.TextVoucherAmount.EditValue = VoucherAmount
            Me.TextVoucherDiscount.EditValue = ItemsDiscount
            Me.TextTotalQuantity.EditValue = TextTotalQuantity
            TexVouchertAmountBeforeDiscount.EditValue = Val(VoucherAmount) + Val(ItemsDiscount)
            TextVoucherDiscount2.EditValue = Val(VoucherDiscount)
            'TexVouchertAmountAfterDiscount.EditValue = Val(VoucherAmount) - VoucherDiscount


            'شغل لكي يتم تقريب مبلغ الفاتورة
            Dim _baseAmount As Decimal = Val(VoucherAmount) - VoucherDiscount
            Dim _RoundedDecimals = RoundVoucherAmount(_baseAmount)
            TextVoucherDiscountRound.EditValue = _RoundedDecimals._NewDiscountAmount
            TexVouchertAmountAfterDiscount.EditValue = _RoundedDecimals._NewAmount

            If _SecondScreen = "Voucher" Then
                PosSecondScreen.TexVouchertAmountAfterDiscount.EditValue = _RoundedDecimals._NewAmount
            End If

            Try
                PosAddLOG(Me.DocCode.Text, "TexVoucherAmountAfterDiscount Changed from" & TexVouchertAmountAfterDiscount.OldEditValue & " To " & TexVouchertAmountAfterDiscount.EditValue)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox(ex.ToString)
            TileView2.FocusedRowHandle = focusedRow
        End Try
        TileView2.FocusedRowHandle = focusedRow


        If DS.Tables(0).Rows.Count = 0 Then
            ShowSecondScreen("Welcome")
        End If
        If _SecondScreen = "Welcome" And DS.Tables(0).Rows.Count > 0 Then
            If _POS_ShowPosVoucherWhenSellItems = True Then
                ShowSecondScreen("Voucher")
            End If
        End If
        '  TextBarcode.Select()
        txtBarcode.Focus()
        'txtBarcode.Select()
    End Sub
    Private Function RoundVoucherAmount(_OriginalAmount As Decimal) As (_NewAmount As Decimal, _NewDiscountAmount As Decimal)
        Try
            Dim _roundedAmount As Decimal = 0
            Dim _DiscountAmount As Decimal = 0

            Select Case posVoucherRoundingType
                Case "NoRounding"
                    ' No rounding - return original amount
                    Return (_OriginalAmount, 0)

                Case "RoundToNearestInteger", "hasNearInteger"
                    ' Round to nearest integer (12.3 → 12, 12.7 → 13)
                    _roundedAmount = Math.Round(_OriginalAmount, MidpointRounding.AwayFromZero)

                Case "RoundDownToInteger", "hasDownInteger"
                    ' Always round down to integer (12.7 → 12)
                    _roundedAmount = Math.Floor(_OriginalAmount)

                Case "RoundToNearestHalf", "hasNearHalf"
                    ' Round to nearest half (12.3 → 12.5, 12.7 → 13.0)
                    _roundedAmount = Math.Round(_OriginalAmount * 2, MidpointRounding.AwayFromZero) / 2

                Case "RoundToLowestHalf", "hasDownHalf"
                    ' Round to lowest half (12.7 → 12.5, 12.3 → 12.0)
                    _roundedAmount = Math.Floor(_OriginalAmount * 2) / 2

                Case Else
                    ' Default to no rounding for unrecognized values
                    Return (_OriginalAmount, 0)
            End Select

            _DiscountAmount = _OriginalAmount - _roundedAmount
            Return (_roundedAmount, _DiscountAmount)

        Catch ex As Exception
            Return (0, 0)
        End Try
    End Function
    Private Function GetPOSHoldJournal(DocCode As String, TableID As Integer) As Integer
        Dim Sql As New SQLControl
        Dim sqlstring As String
        Dim _ItemsCount As Integer = 0

        ' SQL query to insert rows and capture the number of rows inserted
        sqlstring = "  DECLARE @InsertedRows INT; " &
                "  Insert Into [dbo].[POSJournal] (DocID,StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse, " &
                "      StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity], " &
                "      StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode], " &
                "      [InputUser],[PCName],[ShiftID],PosNo,Produced,PriceEdited,DocNoteByAccount,DeviceName,TableID,ReferanceName,Referance,PrinterName ) " &
                "  Select DocID,StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse, " &
                "      StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity], " &
                "      StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode], " &
                "      [InputUser],[PCName],[ShiftID],PosNo,Produced,1 As PriceEdited,DocNoteByAccount,DeviceName,TableID,ReferanceName,Referance,PrinterName " &
                "  From [POSHoldJournal] Where DocCode='" & DocCode & "'; " &
                "  SET @InsertedRows = @@ROWCOUNT; " & ' Capture the number of rows inserted
                "  Delete from [POSHoldJournal] Where DocCode='" & DocCode & "'; " &
                "  SELECT @InsertedRows AS RowsInserted; " ' Return the number of rows inserted

        ' Add condition to update the Printed flag if TableID is not 0
        If TableID <> 0 Then
            sqlstring += "; Update PosJournal Set Printed=1 where DocCode='" & DocCode & "'"
        End If

        ' Execute the query and retrieve the number of rows inserted
        If Sql.SqlTrueAccountingRunQuery(sqlstring) = True Then
            If Sql.SQLDS.Tables.Count > 0 AndAlso Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                _ItemsCount = Convert.ToInt32(Sql.SQLDS.Tables(0).Rows(0)("RowsInserted"))
            End If

            Me.DocCode.Text = DocCode
            GetPosJournalTable()
            PosAddLOG(Me.DocCode.Text, "GetPOSHoldJournal ")
        End If

        Return _ItemsCount
    End Function


    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Me.Hide()
        'My.Forms.Main.RibbonControl.Hide()
        'My.Forms.Main.RibbonControl.Enabled = False
        'My.Forms.Main.TextPassword.Text = String.Empty
        'My.Forms.Main.PanelControl1.Show()
        'My.Forms.Main.TextPassword.Select()
        My.Forms.LogInMenue.TextPassword.Select()
        My.Forms.LogInMenue.Show()
    End Sub

    Private Sub WinExplorerView1_GotFocus(sender As Object, e As EventArgs) Handles TileViewGroups.FocusedRowChanged
        RefreshItems(True)
    End Sub
    Private Sub TileViewItems_ItemPress(sender As Object, e As EventArgs) Handles TileViewWithImages.ItemPress
        GridItemsClick()
    End Sub
    Private Sub TileViewWithoutImages_ItemPress(sender As Object, e As EventArgs) Handles TileViewWithoutImages.ItemPress
        GridItemsClick()
    End Sub
    Private Sub WinExplorerViewItems_Click(sender As Object, e As EventArgs) Handles WinExplorerViewItems.Click
        GridItemsClick()
    End Sub
    Private Sub ZoomTrackBarControl1_EditValueChanged(sender As Object, e As EventArgs) Handles ZoomTrackItems.ValueChanged
        If Me.IsHandleCreated Then
            Select Case GridItems.MainView.ViewCaption
                Case "TileViewWithImages"
                    TileViewWithImages.OptionsTiles.ItemSize = New Size(100 + ZoomTrackItems.Value, 50 + ZoomTrackItems.Value)
                Case "TileViewWithoutImages"
                    TileViewWithoutImages.OptionsTiles.ItemSize = New Size(100 + ZoomTrackItems.Value, 50 + ZoomTrackItems.Value)
                Case "WinExplorerItems"
                    Select Case ZoomTrackItems.Value
                        Case 20
                            Me.WinExplorerViewItems.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.List
                        Case 40
                            Me.WinExplorerViewItems.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Tiles
                        Case 60
                            Me.WinExplorerViewItems.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Medium
                        Case 80
                            Me.WinExplorerViewItems.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.Large
                        Case 100
                            Me.WinExplorerViewItems.OptionsView.Style = DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewStyle.ExtraLarge
                    End Select

            End Select
        End If
    End Sub



    Private Sub TextBoxItemsView_TextChanged(sender As Object, e As EventArgs) Handles TextBoxItemsView.TextChanged
        If TextBoxItemsView.Text = "3" Then ' كاشير سوبرماركت
            GridItems.MainView = TileViewWithImages
            ZoomTrackItems.Value = 50
        End If
        If TextBoxItemsView.Text = "4" Then ' كاشير مطعم
            GridItems.MainView = WinExplorerViewItems
            ZoomTrackItems.Value = 80
        End If
    End Sub
    Private Sub BarButtonCloseShift_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonCloseShift.ItemClick, BarButtonCloseShift.ItemDoubleClick
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount > 0 Then
                    XtraMessageBox.Show("يجب حفظ الفاتورة قبل اغلاق الوردية")
                    Exit Sub
                End If
            Case "TileView2"
                If TileView2.RowCount > 0 Then
                    XtraMessageBox.Show("يجب حفظ الفاتورة قبل اغلاق الوردية")
                    Exit Sub
                End If
        End Select

        If CheckIfThereIsHoldVoucher() > 0 Then
            XtraMessageBox.Show("يوجد فواتير معلقة يجب حفظها قبل اغلاق الوردية")
            Exit Sub
        End If

        Dim _PosCloseShiftPassword As String
        Dim _PosCloseShiftPassword2 As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosCloseShiftPassword' ")
            _PosCloseShiftPassword = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _PosCloseShiftPassword = ""
        End Try

        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosCloseShiftPassword2' ")
            _PosCloseShiftPassword2 = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _PosCloseShiftPassword2 = ""
        End Try



        Dim PassText As String = _PosCloseShiftPassword
        Dim PassText2 As String = _PosCloseShiftPassword2

        If PassText2 = "" And PassText = "" Then
            My.Forms.PosOpenCloseShift.TextShiftID.Text = GlobalVariables._ShiftID
            My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Close"
            Try
                Dim _screen As Screen
                _screen = Screen.AllScreens(0)
                PosOpenCloseShift.StartPosition = FormStartPosition.Manual
                PosOpenCloseShift.Location = _screen.Bounds.Location + New Point(100, 100)
                PosOpenCloseShift.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Dim arg As New XtraInputBoxArgs()
            Dim editor As New TextEdit
            editor.Properties.UseSystemPasswordChar = True
            arg.Editor = editor
            arg.Caption = "Extra Tools"
            arg.Prompt = "Enter Password"
            arg.DefaultResponse = String.Empty
            Dim passkey As String = XtraInputBox.Show(arg)

            If passkey = "" Then Exit Sub
            My.Forms.PosOpenCloseShift.TextShiftID.Text = GlobalVariables._ShiftID
            My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Close"
            Try
                Dim _screen As Screen
                _screen = Screen.AllScreens(0)
                PosOpenCloseShift.StartPosition = FormStartPosition.Manual
                PosOpenCloseShift.Location = _screen.Bounds.Location + New Point(100, 100)
                PosOpenCloseShift.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        PosAddLOG(Me.DocCode.Text, "Close Shift ")
        'If passkey = PassText Or passkey = PassText2 Then
        '    My.Forms.PosOpenCloseShift.TextShiftID.Text = GlobalVariables._ShiftID
        '    My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Close"
        '    PosOpenCloseShift.ShowDialog()
        'End If




    End Sub
    Private Function CheckIfThereIsHoldVoucher() As Integer
        Dim _Count As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = "   select IsNull(count(id),0) As Count from POSHoldJournal where ShiftID=" & GlobalVariables._ShiftID
            sql.SqlTrueAccountingRunQuery(sqlstring)
            _Count = sql.SQLDS.Tables(0).Rows(0).Item("Count")
        Catch ex As Exception
            _Count = 0
        End Try
        Return _Count
    End Function
    Private Sub PopupMenu1_BeforePopup(sender As Object, e As CancelEventArgs) Handles PopupMenu1.BeforePopup
        If TextShiftStatus.Text = "Opening" Then
            BarButtonOpenShift.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonCloseShift.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If String.IsNullOrEmpty(TextShiftStatus.Text) Then
            BarButtonCloseShift.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    Private Sub BarButtonOpenShift_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonOpenShift.ItemClick, BarButtonOpenShift.ItemDoubleClick
        '_PosShiftOopenClosePassword = 0
        'Dim result = XtraInputBox.Show("كلمة المرور", "Change Settings", "Default")

        My.Forms.PosOpenCloseShift.TextShiftID.Text = GlobalVariables._ShiftID
        My.Forms.PosOpenCloseShift.TextOpenOrClose.Text = "Open"
        Try
            Dim _screen As Screen
            _screen = Screen.AllScreens(0)
            PosOpenCloseShift.StartPosition = FormStartPosition.Manual
            PosOpenCloseShift.Location = _screen.Bounds.Location + New Point(100, 100)
            PosOpenCloseShift.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        CurrencyExchangePrices.ShowDialog()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        POSGetItemWeight.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click_4(sender As Object, e As EventArgs)
        ShowItemslist()
    End Sub
    Private Sub ShowItemslist()
        My.Forms.PosSearchItems.DocCode.Text = Me.DocCode.Text
        If My.Forms.PosSearchItems.ShowDialog() <> DialogResult.OK Then
            GetPosJournalTable()
            CenterCaption()
            Me.txtBarcode.Focus()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SwitchKeyboardLayout("ar")
        Me.WindowState = FormWindowState.Minimized
        'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Beep)
        'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Asterisk)
        'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
        'My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Question)


    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Application.Exit()
    End Sub
    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If XtraMessageBox.Show("هل تريد اغلاق البرنامج؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            e.Cancel = True
        Else
            Application.Exit()
        End If


    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        RefreshData()
    End Sub

    Private Sub ZoomTrackBarControl1_EditValueChanged_1(sender As Object, e As EventArgs) Handles ZoomTrackGroups.EditValueChanged
        If Me.IsHandleCreated Then
            TileViewGroups.OptionsTiles.ItemSize = New Size(50 + ZoomTrackGroups.Value, 50 + ZoomTrackGroups.Value)
        End If
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If ZoomTrackGroups.Visible = True Then
            ZoomTrackGroups.Visible = False
            ZoomTrackItems.Visible = False
            LayoutControlItem9.Visibility = Utils.LayoutVisibility.Never
        Else
            ZoomTrackGroups.Visible = True
            ZoomTrackItems.Visible = True
            LayoutControlItem9.Visibility = Utils.LayoutVisibility.Always
        End If

    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Dim Sql As New SQLControl


        Try
            Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewGroups.OptionsTiles.ItemSize.Width & " 
                                           where  [SettingName]='POSItemsGroupWidth' ")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewGroups.OptionsTiles.ItemSize.Height & " 
                                           where  [SettingName]='POSItemsGroupHeight' ")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Select Case GridItems.MainView.ViewCaption
            Case "TileViewWithImages"
                Try
                    Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewWithImages.OptionsTiles.ItemSize.Width & " 
                                           where  [SettingName]='POSItemsWidth' ")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewWithImages.OptionsTiles.ItemSize.Height & " 
                                           where  [SettingName]='POSItemsHeight' ")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "TileViewWithoutImages"

                Try
                    Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewWithoutImages.OptionsTiles.ItemSize.Width & " 
                                           where  [SettingName]='POSItemsWidth' ")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Try
                    Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & TileViewWithoutImages.OptionsTiles.ItemSize.Height & " 
                                           where  [SettingName]='POSItemsHeight' ")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select








        Try
            Sql.SqlTrueAccountingRunQuery("Update  [dbo].[Settings]
                                           Set [SettingValue]= " & SidePanel1.Width & " 
                                           where  [SettingName]='POSVoucherWidth' ")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        XtraMessageBox.Show("تم حفظ التصميم")

    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemHoldedVouchers.ItemClick
        If GridPosVoucher.MainView.RowCount <> 0 Then
            If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد تعليق الفاتورة الحالية؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                HoldVoucher()
            Else
                Exit Sub
            End If
        End If

        'Try
        '    PosOpenCloseShift.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        Dim F As New PosHoldVouchers
        With F
            Dim _screen As Screen
            _screen = Screen.AllScreens(0)
            .StartPosition = FormStartPosition.Manual
            .Location = _screen.Bounds.Location + New Point(100, 100)
            If .ShowDialog <> DialogResult.OK Then
                If IsNothing(_HoldVoucherCode) Then Exit Sub
                If _HoldVoucherCode <> "0" And _HoldVoucherCode <> "" Then
                    GetPOSHoldJournal(_HoldVoucherCode, 0)
                    _HoldVoucherCode = "0"
                    Me.txtBarcode.Focus()
                End If
            End If
        End With
        'PosHoldVouchers.ShowDialog()
    End Sub

    Private Sub BarButtonItem14_ItemPress(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemPress
        '\  PosWelcomeScreen.Show()
        Dim PassText As String = "100200300"
        Dim arg As New XtraInputBoxArgs()
        Dim editor As New TextEdit
        editor.Properties.UseSystemPasswordChar = True
        arg.Editor = editor
        arg.Caption = "Extra Tools"
        arg.Prompt = "Enter Password"
        arg.DefaultResponse = String.Empty
        Dim passkey As String = XtraInputBox.Show(arg)
        If passkey = PassText Then

            Dim F As New PosSettings
            With F
                .TextPosNo.Text = My.Settings.POSNo
                .ShowDialog()
            End With
        Else
            XtraMessageBox.Show("Password Error")
        End If

    End Sub

    Private Sub DropDownButton2_Click(sender As Object, e As EventArgs) Handles DropDownButton2.Click, DropDownButton2.DoubleClick
        txtBarcode.Focus()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim f As New PosLastVouchers
        With f
            ._PosNoInDataForPasLastVouchers = Me._PosNo
            .ShowDialog()
        End With
        'PosLastVouchers._PosNoInDataForPasLastVouchers = Me._PosNo
    End Sub

    Private Sub DocCode_EditValueChanged(sender As Object, e As EventArgs) Handles DocCode.EditValueChanged
        BarDocCode.Caption = DocCode.Text
    End Sub

    Private Sub TextVoucherDiscount_EditValueChanged(sender As Object, e As EventArgs) Handles TextVoucherDiscount.EditValueChanged
        ChackIfDiscountGreatThanMaxDiscount()
        Try
            PosAddLOG(Me.DocCode.Text, "TextVoucherDiscount Changed from" & TextVoucherDiscount.OldEditValue & " To " & TextVoucherDiscount.EditValue)
        Catch ex As Exception
        End Try

    End Sub
    Private Function ChackIfDiscountGreatThanMaxDiscount() As Boolean
        If Me.IsHandleCreated Then
            Dim _DiscountPercentage, _MaxDiscountPercentage As Decimal
            Try
                'If TexVouchertAmountAfterDiscount.EditValue <= 0 Then Return False
                _DiscountPercentage = (TextVoucherDiscount.EditValue + TextVoucherDiscount2.EditValue) / TexVouchertAmountBeforeDiscount.EditValue
                _MaxDiscountPercentage = GlobalVariables._PosMaxDiscount / 100
                If _DiscountPercentage > _MaxDiscountPercentage Then
                    XtraMessageBox.Show("لقد تجاوزت الحد الأقصى للخصم")
                    PosAddLOG(Me.DocCode.Text, "ChackIfDiscountGreatThanMaxDiscount = True  ")
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Private Sub TextVoucherDiscount2_EditValueChanged(sender As Object, e As EventArgs) Handles TextVoucherDiscount2.EditValueChanged
        Try
            PosAddLOG(Me.DocCode.Text, "TextVoucherDiscount2 Changed from" & TextVoucherDiscount2.OldEditValue & " To " & TextVoucherDiscount2.EditValue)
        Catch ex As Exception
        End Try

        ChackIfDiscountGreatThanMaxDiscount()
    End Sub



    Private Sub DropDownButton2_DoubleClick(sender As Object, e As EventArgs) Handles DropDownButton2.DoubleClick
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = FormBorderStyle.None
        End If

    End Sub



    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButtonSave.Click, SimpleButtonSave.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press Save ")
        CheckPrint.Checked = False
        SaveToJournal()
    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs)
        CheckPrint.Checked = True
        SaveToJournal()
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButtonPaidMethods.Click, SimpleButtonPaidMethods.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press ShowCashBox ")
        ShowCashBox()
    End Sub

    Private Sub SimpleButton8_Click(sender As Object, e As EventArgs) Handles SimpleButton8.Click, SimpleButton8.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press AddNoteToVoucher ")
        AddNoteToVoucher()
    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click, SimpleButton11.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press PosAddDiscountOnVoucher ")
        Dim F As New PosAddDiscountOnVoucher
        With F
            .TextVoucherAmount.EditValue = CDec(TextVoucherAmount.EditValue).ToString("n2")
            .TextVoucherCode.Text = Me.DocCode.Text
            .TextVoucherAmountAfterDiscount.EditValue = TextVoucherAmount.EditValue
            If .ShowDialog() <> DialogResult.OK Then
                '   _DiscountVoucherAmount = .TextVoucherAmountAfterDiscount.EditValue
                '  AllocateDiscount()
                GetPosJournalTable()
            End If
        End With
        txtBarcode.Focus()
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click, SimpleButton7.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press RetuenSales ")
        RetuenSalesMode()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButtonHold.Click, SimpleButtonHold.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press HoldVoucher ")
        HoldVoucher()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        ' Dim child As Form = Nothing
        Dim f As New AccountStatmentForRef()
        f.CheckReportForRef.Text = "True"
        ' ctr = ctr + 1
        ' f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        'Dim f As MoneyTrans = New MoneyTrans()
        'With f
        '    .Show()
        '    .DocName.EditValue = 4
        '    .DocName.Text = 4
        '    .DocStatus.Text = -1
        '    .TextDocIDQuery.EditValue = -1
        '    .Text = "سند قبض"
        '    .DocDate.DateTime = Today()
        '    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        '    .TextDocID.EditValue = GetDocNo(4)
        '    ' .Show()
        'End With

        Dim f As New PosDirectReceipt
        With f
            ._CostCenter = Me._CostCenter
            ._ShiftID = Me.BarStaticShiftID.Caption
            ._PosName = Me.BarPosNo.Caption
            ._DefaultCashAccount = Me.DefaultCashAcc
            ._InputUser = GlobalVariables.CurrUser
            If Me.TextReferanceNo.Text <> "" Then
                .Referance.EditValue = Me.TextReferanceNo.EditValue
            End If
            .ShowDialog()
        End With
        Me.RadialMenu1.HidePopup()
    End Sub
    Private Sub NewReceipt()
        If _PosShowRadialMenu = True Then
            Dim f As New PosDirectReceipt
            With f
                ._CostCenter = Me._CostCenter
                ._ShiftID = Me.BarStaticShiftID.Caption
                ._PosName = Me.BarPosNo.Caption
                ._DefaultCashAccount = Me.DefaultCashAcc
                ._InputUser = GlobalVariables.CurrUser
                If Me.TextReferanceNo.Text <> "" Then
                    .Referance.EditValue = Me.TextReferanceNo.EditValue
                End If
                .ShowDialog()
            End With
        End If
    End Sub
    Private Sub BarButtonItem17_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick

        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 2
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            End If
        End With
        Me.RadialMenu1.HidePopup()
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick

        Dim _ItemNo As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT IsNull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items")
            _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
        Catch ex As Exception
            _ItemNo = 0
        End Try

        Dim F As New Items
        With F
            .ItemNo.EditValue = _ItemNo
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            End If
        End With
        Me.RadialMenu1.HidePopup()
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        CurrencyExchangePrices.ShowDialog()
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        'Dim f As MoneyTrans = New MoneyTrans()
        'With f
        '    .Show()
        '    .DocName.EditValue = 3
        '    .DocName.Text = 3
        '    .DocStatus.Text = -1
        '    .TextDocIDQuery.EditValue = -1
        '    .Text = "سند صرف"
        '    .DocDate.DateTime = Today()
        '    '.LayoutControlItem18.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        '    .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
        '    .TextDocID.EditValue = GetDocNo(3)
        'End With

        Dim f As New PosPaymentDirect
        With f
            ._CostCenter = Me._CostCenter
            ._ShiftID = Me.BarStaticShiftID.Caption
            ._PosName = Me.BarPosNo.Caption
            ._DefaultCashAccount = Me.DefaultCashAcc
            ._InputUser = GlobalVariables.CurrUser
            PosAddLOG(Me.DocCode.Text, "Open PosPaymentDirect   ")
            .ShowDialog()
        End With
        Me.RadialMenu1.HidePopup()
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        AccountingLists.NavigationPane1.SelectedPage = AccountingLists.NavigationPane1.Pages(6)
        AccountingLists.ShowDialog()

    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Dim f As New PosVoucherReport()
        PosAddLOG(Me.DocCode.Text, "Open PosVoucherReport   ")
        f.ColPosNo.Visible = False
        f.ColShiftID.Visible = False
        f.ColVoucherNote.Visible = False
        f.ColVoucherReferance.Visible = False
        f.ColPaidMethodName.Visible = False
        f.ColVoucherPayType.Visible = False
        f.ColEmployeeName.Visible = False
        '  ctr = ctr + 1
        ' f.MdiParent = Me
        f.Show()
        f.RefreshData()
    End Sub

    Private Sub SimpleButton13_Click(sender As Object, e As EventArgs) Handles SimpleButtonPrint.Click, SimpleButtonPrint.DoubleClick
        PosAddLOG(Me.DocCode.Text, "Press Print ")
        CheckPrint.Checked = True
        SaveToJournal()
    End Sub

    Private Sub TileView1_ItemPress(sender As Object, e As TileViewItemClickEventArgs) Handles TileView1.ItemPress, TileView1.ItemDoubleClick
        Try
            If TileView1.GetFocusedRowCellValue("IsSelected") = "False" Then
                _TextItemDescription += TileView1.GetFocusedRowCellValue("PortionName") & " / "
                Me.TileView1.SetFocusedRowCellValue("IsSelected", "True")
                _PortionTable.Rows.Add(TileView1.GetFocusedRowCellValue("ID"), TileView1.GetFocusedRowCellValue("PortionName"), CInt(TileView1.GetFocusedRowCellValue("ItemPrice")))
            Else
                If _PortionTable.Rows.Count <> 0 Then
                    For i = 0 To _PortionTable.Rows.Count - 1
                        If _PortionTable.Rows(i).Item("ID") = TileView1.GetFocusedRowCellValue("ID") Then
                            _PortionTable.Rows(i).Delete()
                            TileView1.SetFocusedRowCellValue("IsSelected", "False")
                        End If
                    Next
                End If
            End If
            If _PortionTable.Rows.Count = 0 Then
                TextAdditionsPrice.EditValue = 0
                _TextItemDescription = ""
            Else
                TextAdditionsPrice.EditValue = _PortionTable.Compute("SUM(ItemPrice)", "")
            End If
        Catch ex As Exception
            ' MsgBoxShowError(" الرجاء اعادة المحاولة ")
        End Try

    End Sub



    Private Sub GridItems_Click(sender As Object, e As EventArgs) Handles GridItems.Click, GridItems.DoubleClick
        txtBarcode.Focus()
    End Sub

    Private Sub GridPosVoucher_Click(sender As Object, e As EventArgs) Handles GridPosVoucher.Click, GridPosVoucher.DoubleClick
        txtBarcode.Focus()
    End Sub

    Private Sub TexVouchertAmountAfterDiscount_Click(sender As Object, e As EventArgs) Handles TexVouchertAmountAfterDiscount.Click, TexVouchertAmountAfterDiscount.DoubleClick
        txtBarcode.Focus()
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick, BarButtonItem25.ItemDoubleClick
        ShowKeyboard()
    End Sub

    Private Sub SimpleButtonAdditions_Click(sender As Object, e As EventArgs) Handles SimpleButtonAdditions.Click, SimpleButtonAdditions.DoubleClick
        Dim sql As New SQLControl
        Dim _ItemNo As Integer = TileView1.GetFocusedRowCellValue("ItemNo")
        Dim _ItemBarcode As String = TileView1.GetFocusedRowCellValue("StockBarcode")
        Dim _NoteFromAddtions As String = _TextItemDescription
        Dim _Price As Decimal = _TextTotalWithPriceAndPortions.EditValue
        Dim _RowID As Integer
        Try
            _RowID = InsertIntoPOSJournalByStoredProcedure(_ItemBarcode, DocName.EditValue, 1, _DefaultWharehouse, Me.DocCode.Text, Me.TextReferanceNo.EditValue, _ItemNo, 0, 0, _NoteFromAddtions)
            sql.SqlTrueAccountingRunQuery(" Update [POSJournal] set [PriceEdited]= 1 , DocAmount =" & _Price & ",[StockPrice]=" & _Price & " where [ID]=" & _RowID)
            PosFunctions.PlaySuccessBeepOnPos()
            TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
        Catch ex As Exception
            MsgBox(ex.ToString)
            TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        End Try


        TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        GetPosJournalTable()
        ' TextTotalWithPriceAndPortions.EditValue = 0
        TextItemPriceInPortionScreen.EditValue = 0
        SimpleLabelItemItemName.Text = ""
        TextAdditionsPrice.EditValue = 0
        _TextItemDescription = ""
        _PortionTable.Clear()
        'GridItems.Visible = True
        txtBarcode.Focus()
    End Sub

    Private Sub TextItemPriceInPortionScreen_EditValueChanged(sender As Object, e As EventArgs) Handles TextItemPriceInPortionScreen.EditValueChanged
        TextTotalWithPriceAndPortions.EditValue = TextItemPriceInPortionScreen.EditValue + TextAdditionsPrice.EditValue
    End Sub

    Private Sub TextAdditionsPrice_EditValueChanged(sender As Object, e As EventArgs) Handles TextAdditionsPrice.EditValueChanged
        TextTotalWithPriceAndPortions.EditValue = TextItemPriceInPortionScreen.EditValue + TextAdditionsPrice.EditValue
    End Sub

    Private Sub SimpleButton9_Click_1(sender As Object, e As EventArgs) Handles SimpleButton9.Click, SimpleButton9.DoubleClick
        Dim i As Integer
        For i = 0 To TileView1.RowCount - 1
            TileView1.SetRowCellValue(i, "IsSelected", "False")
            ' TextItemPriceInPortionScreen.EditValue = 0
            TextAdditionsPrice.EditValue = 0
            ' _TextItemDescription = ""
            txtBarcode.Focus()
        Next
        _PortionTable.Clear()
        _TextItemDescription = ""
        TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
    End Sub

    Public Sub GetSalesForChart(_SalesDateFrom As String, _SalesDateTo As String)

        GetSalesByHoures(_SalesDateTo)
        GetSalesByGroups(_SalesDateTo)
        GetSalesByDayThisMonth(_SalesDateFrom)
        GetSalesMonthly(_SalesDateFrom)
        GetSalesByDayName(_SalesDateFrom)

    End Sub
    Private Sub GetSalesByHoures(_ShiftDateTimeTo As String)
        Dim dtParameter As DateTime = CDate(_ShiftDateTimeTo)
        Dim startTime As TimeSpan = TimeSpan.Parse("00:01")
        Dim endTime As TimeSpan = TimeSpan.Parse("04:00")
        Dim timeComponent As TimeSpan = dtParameter.TimeOfDay
        If timeComponent >= startTime AndAlso timeComponent <= endTime Then
            _ShiftDateTimeTo = Format(CDate(_ShiftDateTimeTo).AddDays(-1), "yyyy-MM-dd")
        Else
            _ShiftDateTimeTo = Format(CDate(_ShiftDateTimeTo), "yyyy-MM-dd")
        End If
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String = " SELECT DATEPART(HOUR, [VoucherDateTime]) AS HourOfDay, CAST(SUM([VoucherAmountAfterDiscount]) AS INT)  AS TotalSales
                                        FROM [dbo].[PosVouchers]
                                        WHERE  DocName=2 And Convert(Date,[VoucherDateTime]) = '" & _ShiftDateTimeTo & "' AND [PosNo]='" & _PosNo & "'
                                        GROUP BY DATEPART(HOUR, [VoucherDateTime])
                                        ORDER BY HourOfDay; "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            ChartControlSalesByHoures.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetSalesByGroups(_ShiftDateTimeTo As String)
        Dim dtParameter As DateTime = CDate(_ShiftDateTimeTo)
        Dim startTime As TimeSpan = TimeSpan.Parse("00:01")
        Dim endTime As TimeSpan = TimeSpan.Parse("04:00")
        Dim timeComponent As TimeSpan = dtParameter.TimeOfDay
        If timeComponent >= startTime AndAlso timeComponent <= endTime Then
            _ShiftDateTimeTo = Format(CDate(_ShiftDateTimeTo).AddDays(-1), "yyyy-MM-dd")
        Else
            _ShiftDateTimeTo = Format(CDate(_ShiftDateTimeTo), "yyyy-MM-dd")
        End If
        Try
            Dim sql As New SQLControl
            Dim sqlstring40 As String = " select Case when G.GroupName Is Null or G.GroupName ='' then N'بدون' else G.GroupName End as GroupName, cast(sum(DocAmount) as decimal(18,2)) as TotalSales
                                     from Journal J 
                                     left join Items I on J.StockID=I.ItemNo
                                     left join ItemsGroups G on I.GroupID=G.GroupID
                                     where DocName=2 And DocDate='" & _ShiftDateTimeTo & "' AND [PosNo]='" & _PosNo & "'
                                     group by G.GroupName "
            sql.SqlTrueAccountingRunQuery(sqlstring40)
            ChartControlSalesByGroups.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetSalesByDayThisMonth(_ShiftDateFrom As String)
        Try
            Dim sql As New SQLControl
            Dim sqlstring2 As String = " SELECT DATEPART(DAY, [VoucherDateTime]) AS DaysOfMonth, CAST(SUM([VoucherAmountAfterDiscount]) AS BIGINT) AS TotalSales
                                    FROM [dbo].[PosVouchers]
                                    WHERE    DocName=2 And Month([VoucherDateTime])= " & Format(CDate(_ShiftDateFrom), "MM") & " and Year([VoucherDateTime])= " & Format(CDate(_ShiftDateFrom), "yyyy") & " AND [PosNo]='" & _PosNo & "'
                                    GROUP BY DATEPART(DAY, [VoucherDateTime])
                                    ORDER BY DaysOfMonth; "
            sql.SqlTrueAccountingRunQuery(sqlstring2)
            ChartControlDailySalesThisMonth.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetSalesMonthly(_ShiftDateFrom As String)
        Try
            Dim sql As New SQLControl
            Dim sqlstring3 As String = " SELECT DATEPART(MONTH, [VoucherDateTime]) AS MonthOfYear, CAST(SUM([VoucherAmountAfterDiscount]) AS INT)  AS TotalSales
                                    FROM [dbo].[PosVouchers]
                                    WHERE  DocName=2 And Year([VoucherDateTime])= " & Format(CDate(_ShiftDateFrom), "yyyy") & " AND [PosNo]='" & _PosNo & "'
                                    GROUP BY DATEPART(MONTH, [VoucherDateTime])
                                    ORDER BY MonthOfYear; "
            sql.SqlTrueAccountingRunQuery(sqlstring3)
            ChartControlMonthly.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetSalesByDayName(_ShiftDateFrom As String)
        Try
            Dim sql As New SQLControl

            Dim sqlstring4 As String = "    Declare @StartDate date
                                        Declare @EndDate date
                                        Set @EndDate='" & Format(CDate(_ShiftDateFrom).AddDays(1), "yyyy-MM-dd") & "'
                                        Set @StartDate=DATEADD(Day,-7,@EndDate)
                                        SELECT 
                                        DATEPART(WEEKDAY, [VoucherDateTime]) AS DayOfWeek,
                                        DATENAME(WEEKDAY, [VoucherDateTime]) AS DayName,
                                        DATENAME(DAY, [VoucherDateTime]) AS Day,
                                        SUM([VoucherAmountAfterDiscount]) AS TotalSales
                                        FROM [PosVouchers]
                                        WHERE  DocName=2 And [VoucherDateTime] between @StartDate and @EndDate AND [PosNo]='" & _PosNo & "'
                                        GROUP BY DATEPART(WEEKDAY, [VoucherDateTime]), DATENAME(WEEKDAY, [VoucherDateTime]),DATENAME(DAY, [VoucherDateTime])
                                        ORDER BY DATENAME(DAY, [VoucherDateTime]); "
            sql.SqlTrueAccountingRunQuery(sqlstring4)
            ChartControlSalesByDayName.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub BtnRefreshSalesData_Click(sender As Object, e As EventArgs)
        '  GetSalesForChart()
    End Sub

    Private Sub BarBtnShowSalesTab_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarBtnShowSalesTab.ItemClick, BarBtnShowSalesTab.ItemDoubleClick
        TabbedControlGroupAllScreens.SelectedTabPage = TabDailyReport
        '  GetSalesForChart()
    End Sub

    Private Sub BtnRefreshSalesDataToday_Click(sender As Object, e As EventArgs) Handles btnRefreshSalesDataToday.Click, btnRefreshSalesDataToday.DoubleClick
        GetSalesForChart(Format(Today(), "yyyy-MM-dd") & " 00:00:00.000", Format(Today(), "yyyy-MM-dd") & " 23:59:59.999")
        LayoutControlItem27.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem42.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem47.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnRefreshSalesDataYesterday.Click
        GetSalesForChart(Format(Today().AddDays(-1), "yyyy-MM-dd") & " 00:00:00.000", Format(Today().AddDays(-1), "yyyy-MM-dd") & " 23:59:59.999")
        LayoutControlItem27.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem42.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem47.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub SimpleButton14_Click(sender As Object, e As EventArgs) Handles btnRefreshSalesDataThisMonth.Click
        Dim DateFrom As New DateTime(Format(Today, "yyyy"), Format(Today, "MM"), 1)
        GetSalesForChart(Format(DateFrom, "yyyy-MM-dd") & " 00:00:00.000", Format(Today(), "yyyy-MM-dd") & " 23:59:59.999")
        LayoutControlItem27.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem42.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem47.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    Private Sub BtnRefreshSalesDataThisYear_Click(sender As Object, e As EventArgs) Handles btnRefreshSalesDataThisYear.Click
        Dim DateFrom As New DateTime(Format(Today, "yyyy"), 1, 1)
        GetSalesForChart(Format(DateFrom, "yyyy-MM-dd") & " 00:00:00.000", Format(Today(), "yyyy-MM-dd") & " 23:59:59.999")
        LayoutControlItem27.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem42.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem47.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    Private Sub BtnRefreshSalesDataLastMonth_Click(sender As Object, e As EventArgs) Handles btnRefreshSalesDataLastMonth.Click
        Dim DateFrom As New DateTime(Format(Today, "yyyy"), Format(Today.AddMonths(-1), "MM"), 1)
        Dim currentDate As DateTime = DateTime.Now
        Dim firstDayOfCurrentMonth As New DateTime(currentDate.Year, currentDate.Month, 1)
        Dim lastDayOfLastMonth As DateTime = firstDayOfCurrentMonth.AddDays(-1)
        GetSalesForChart(Format(DateFrom, "yyyy-MM-dd") & " 00:00:00.000", Format(lastDayOfLastMonth, "yyyy-MM-dd") & " 23:59:59.999")
        LayoutControlItem27.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem42.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        LayoutControlItem47.Visibility = XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    Private Sub BarReceipt_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarReceipt.ItemClick, BarReceipt.ItemDoubleClick
        Dim f As New PosDirectReceipt
        With f
            ._CostCenter = Me._CostCenter
            ._ShiftID = Me.BarStaticShiftID.Caption
            ._PosName = Me.BarPosNo.Caption
            ._DefaultCashAccount = Me.DefaultCashAcc
            ._InputUser = GlobalVariables.CurrUser
            If Me.TextReferanceNo.Text <> "" Then
                .Referance.EditValue = Me.TextReferanceNo.EditValue
            End If
            .ShowDialog()
        End With
    End Sub

    Private Sub BarPayment_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarPayment.ItemClick, BarPayment.ItemDoubleClick
        Dim f As New PosPaymentDirect
        With f
            ._CostCenter = Me._CostCenter
            ._ShiftID = Me.BarStaticShiftID.Caption
            ._PosName = Me.BarPosNo.Caption
            ._DefaultCashAccount = Me.DefaultCashAcc
            ._InputUser = GlobalVariables.CurrUser
            PosAddLOG(Me.DocCode.Text, "Open PosPaymentDirect   ")
            .ShowDialog()
        End With
    End Sub

    Private Sub BarNewCustomer_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarNewCustomer.ItemClick
        Dim F As New ReferancessAddNew
        With F
            .TextRefNo.Text = GetReferanceMax() + 1
            .TextRefName.Text = ""
            .TextRefMobile.Text = ""
            .TextRefPhone.Text = ""
            .PriceCategory.EditValue = 1
            .LookRefType.EditValue = 2
            .TextRefName.Select()
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            End If
        End With
    End Sub

    Private Sub BarAccountStatment_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarAccountStatment.ItemClick
        ' Dim child As Form = Nothing
        Dim f As New AccountStatmentForRef()
        f.CheckReportForRef.Text = "True"
        ' ctr = ctr + 1
        ' f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem27_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        Dim f As New AccStockMove()
        With f
            .DocName.EditValue = 17
            .DocName.Text = 17
            .Show()
            .DocStatus.Text = -1
            .LoadDefault()
            .Text = "سند ادخال"
            .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
            .DocID.EditValue = GetDocNo(1, True)
            .BarButtonMDI.Visibility = XtraBars.BarItemVisibility.Never
            .BarButtonRestore.Visibility = XtraBars.BarItemVisibility.Never
            .Bar1.Visible = False
        End With
    End Sub

    Private Sub BarButtonItem28_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        Dim f As New AccStockMove()
        With f
            .DocName.EditValue = 13
            .DocName.Text = 13
            .Show()
            .DocStatus.Text = -1
            .LoadDefault()
            .Text = "مردودات مشتريات"
            .LookCostCenter.EditValue = GetDefaultCostCenter(GlobalVariables.CurrUser)
            .DocID.EditValue = GetDocNo(13, True)
            .BarButtonMDI.Visibility = XtraBars.BarItemVisibility.Never
            .BarButtonRestore.Visibility = XtraBars.BarItemVisibility.Never
            .Bar1.Visible = False
        End With
    End Sub

    Private Sub BarNewItem_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarNewItem.ItemClick
        Dim _ItemNo As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("SELECT IsNull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items")
            _ItemNo = Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo")
        Catch ex As Exception
            _ItemNo = 0
        End Try

        Dim F As New Items
        With F
            .ItemNo.EditValue = _ItemNo
            If .ShowDialog() = DialogResult.OK Then
                MsgBox("ok")
            End If
        End With
    End Sub

    Private Sub TextRefName_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles TextReferanceName.ButtonClick
        Select Case e.Button.Tag
            Case "Cash"
                TextReferanceNo.Text = "0"
                TextReferanceName.Text = ""
                My.Forms.POSRestCashier.Text = "فاتورة مبيعات"
                TextOtherAccountNo.Caption = GlobalVariables._DefaultBaseCashAccount
                TextOtherAccountName.Caption = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
                'ReferanceNameItem.Caption = ""
                TextReferanceName.Text = "زبون نقدي"
                Dim sql As New SQLControl
                Dim sqlString As String
                sqlString = " Update POSJournal Set Referance=0,ReferanceName=N'زبون نقدي' where DocCode='" & DocCode.Text & "' and PosNo=" & Me.BarPosNo.Caption
                sql.SqlTrueAccountingRunQuery(sqlString)
                txtBarcode.Focus()
            Case "Debit"
                Dim F As New PosSerachReferance
                With F
                    .docCode = Me.DocCode.Text
                    .posNo = Me.BarPosNo.Caption
                    If .ShowDialog <> DialogResult.OK Then
                        GetPosJournalTable()
                        CenterCaption()
                        txtBarcode.Focus()
                    End If
                End With
            Case "CashCustomer"

                _previousTabPage = TabbedControlGroupAllScreens.SelectedTabPage
                TabbedControlGroupAllScreens.SelectedTabPage = TabCashCustomers
                TabCashCustomers.Visibility = XtraLayout.Utils.LayoutVisibility.Always

                'Dim F As New PosSerachReferance
                'With F
                '    .docCode = Me.DocCode.Text
                '    .posNo = Me.BarPosNo.Caption
                '    If .ShowDialog <> DialogResult.OK Then
                '        GetPosJournalTable()
                '        CenterCaption()
                '        txtBarcode.Focus()
                '    End If
                'End With
        End Select
    End Sub

    Private Sub TextBarcode_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles txtBarcode.ButtonClick
        If e.Button.Tag = "Barcode" Then
            ShowItemslist()
        End If
    End Sub

    Private Sub WinExplorerViewItems_HtmlElementMouseClick(sender As Object, e As WinExplorerViewHtmlElementEventArgs) Handles WinExplorerViewItems.HtmlElementMouseClick
        GridItemsClick()
    End Sub

    Private Sub BtnDestruction_Click(sender As Object, e As EventArgs) Handles BtnSaveAsGift.Click, BtnSaveAsGift.DoubleClick
        If GridPosVoucher.MainView.RowCount = 0 Then Exit Sub
        DocName.EditValue = 18
        Itlaf_Gift = "Gift"
        CheckPrint.Checked = False
        AddNoteToVoucher()
        If _PosVoucherNoteCancelled = True Then
            MsgBoxShowError(" لم يتم اعتماد السند ")
            _PosVoucherNote = ""
            Exit Sub
        End If
        SaveToJournal()
    End Sub

    Private Sub BtnGift_Click(sender As Object, e As EventArgs) Handles BtnSaveAsItlaf.Click, BtnSaveAsItlaf.DoubleClick
        If GridPosVoucher.MainView.RowCount = 0 Then Exit Sub
        DocName.EditValue = 18
        Itlaf_Gift = "Itlaf"
        CheckPrint.Checked = False
        AddNoteToVoucher()
        If _PosVoucherNoteCancelled = True Then
            MsgBoxShowError(" لم يتم اعتماد السند ")
            _PosVoucherNote = ""
            Exit Sub
        End If
        SaveToJournal()
    End Sub



    Private Sub BarButtonItem29_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick, BarButtonItem29.ItemDoubleClick
        PosLogs.ShowDialog()
    End Sub

    Private Sub TileView2_LostFocus(sender As Object, e As EventArgs) Handles TileView2.LostFocus
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        txtBarcode.Focus()
    End Sub

    Private Sub TextRefName_MouseUp(sender As Object, e As MouseEventArgs) Handles TextReferanceName.MouseUp
        TextEditSelectText(TextReferanceName)
    End Sub

    Private Sub BarButtonItem31_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        Try
            InstallmentsHeaderList.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TileView3_ItemClick(sender As Object, e As TileViewItemClickEventArgs) Handles TileViewControlUnitsForItem.ItemClick
        Dim _Barcode As String = TileViewControlUnitsForItem.GetFocusedRowCellValue("Barcode")
        Dim _ItemNo As String = TileViewControlUnitsForItem.GetFocusedRowCellValue("ItemNo")

        Dim _RowID As Integer
        _RowID = InsertIntoPOSJournalByStoredProcedure(_Barcode, DocName.EditValue, 1, _DefaultWharehouse, Me.DocCode.Text, Me.TextReferanceNo.EditValue, _ItemNo, 0, 0, "")
        If _RowID > 0 Then
            PosFunctions.PlaySuccessBeepOnPos()
        End If
        GetPosJournalTable()
        GridItems.Visible = True
        TabUnitsForItem.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always

        TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab

        txtBarcode.Focus()
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'TabUnitsForItem.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        'TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always


        TabUnitsForItem.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabLayoutControlGroupItemsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Always

        TabLayoutControlGroupAdditionsTab.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
        txtBarcode.Focus()
    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim FromDate As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd HH:mm")
        Dim ToDate As String = Format(DateEditTo.DateTime, "yyyy-MM-dd HH:mm")
        GridControlPosVouchers.DataSource = Nothing
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " Select [VoucherID]      ,[VoucherDateTime]      ,[VoucherAmount]      ,[VoucherDiscount],[VoucherDiscount2]
                                ,[VoucherPC]      ,[VoucherAmountAfterDiscount]      ,[UserNo]      ,[VoucherCode]
                                ,[VoucherDebit]      ,[VoucherCredit]      ,[VoucherPayType]      ,[VoucherReferanceName]
                                ,[VoucherReferance],E.EmployeeName,A.PaidMethodName ,VoucherNote,DocName,PosNo,[ShiftID]
                          FROM  [dbo].[PosVouchers] P
                              Left join  [dbo].[EmployeesData] E on P.[UserNo] = E.EmployeeID 
                              Left join [PosPaidMethods] A on A.MethodNo =P.PayCardName
                          Where  [VoucherDateTime] between '" & FromDate & "' and '" & ToDate & "'"
            SqlString += " order by VoucherDateTime desc  "
            sql.SqlTrueAccountingRunQuery(SqlString)
            GridControlPosVouchers.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
        GridView1.BestFitColumns()
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        TabbedControlGroupAllScreens.SelectedTabPage = TabDailyReportGrid

        Me.DateEditTo.DateTime = Today() & " 23:59:59"
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEditFrom.DateTime = startDt

    End Sub

    Private Sub SimpleButton14_Click_1(sender As Object, e As EventArgs) Handles SimpleButton14.Click
        TabbedControlGroupAllScreens.SelectedTabPage = TabDailyReport
    End Sub

    Private Sub TileViewItems_CustomItemTemplate(sender As Object, e As TileViewCustomItemTemplateEventArgs) Handles TileViewWithImages.CustomItemTemplate
        Dim tileView As TileView = TryCast(sender, TileView)
        '  Dim country As String = TileView1.GetRowCellDisplayText(e.RowHandle, "Country")
        '  If country = "UK" Then
        e.Template = e.Templates("templateWithImages")
        '  End If
    End Sub



    Private Sub BarButtonViewWithImage_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonViewWithImage.ItemClick
        GridItems.MainView = TileViewWithImages
        GridItems.MainView.ViewCaption = "TileViewWithImages"
        posShowImagesInItemsView = True
        UpdateItemsViewTemplateNameInDB()
    End Sub

    Private Sub BarButtonViewItemsWithoutImages_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonViewItemsWithoutImages.ItemClick
        GridItems.MainView = TileViewWithoutImages
        posShowImagesInItemsView = False
        GridItems.MainView.ViewCaption = "TileViewWithoutImages"
        UpdateItemsViewTemplateNameInDB()
    End Sub
    Private Sub ViewItemsMethod()
        Select Case GridItems.MainView.ViewCaption
            Case "TileViewWithImages", "TileViewWithoutImages"
                WinExplorerViewItems.OptionsViewStyles.Medium.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
                WinExplorerViewItems.OptionsViewStyles.Large.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
                WinExplorerViewItems.OptionsViewStyles.ExtraLarge.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
                WinExplorerViewItems.OptionsViewStyles.Small.HtmlTemplate.Assign(WinExplorerViewItems.HtmlTemplates(0))
                GridItems.MainView = WinExplorerViewItems
                Return
            Case "WinExplorerItems"
                GridItems.MainView = TileViewWithImages
                Return
        End Select
    End Sub
    Private Sub SetItemsViewTemplateName()
        Select Case _ItemsViewTemplateName
            Case "TileViewWithImages"
                GridItems.MainView = TileViewWithImages
            Case "TileViewWithoutImages"
                GridItems.MainView = TileViewWithoutImages
            Case "WinExplorerItems"
                GridItems.MainView = WinExplorerViewItems
        End Select
        GridItems.MainView.ViewCaption = _ItemsViewTemplateName
    End Sub
    Private Sub UpdateItemsViewTemplateNameInDB()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("Update [dbo].[AccountingPOSNames] set ItemsViewTemplateName='" & GridItems.MainView.ViewCaption & "' where ID=" & My.Settings.POSNo)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetHoldVouchers(_Location As Integer)
        Try
            Dim sql As New SQLControl
            Dim sqlString As String
            sqlString = " 
Select A.TableName,A.TableID,DocIDint,CAST(case when IsNull(B.Quantity,0) =0 then 0 else 1 end as bit ) AS IsReserved,B.Amount,B.Quantity,B.DocCode,B.InputDateTime,B.DocID,B.DocNotes,B.Referance,B.ReferanceName from 
(
Select [TableName],[TableID],IsReserved,L.ID as LocationID From [PosTables] P left Join [PosTablesLocations] L On P.Location=L.[ID] 
) A
Left Join 
( Select concat(Sum(BaseAmount),N' ₪') As Amount,Count(DocID) As Quantity,DocCode,
Concat( 'Last Update: ' ,CONVERT(VARCHAR(8), InputDateTime, 108)) AS InputDateTime ,
Concat('No. ',DocID) As DocID ,DocID as DocIDint,DocNotes,Referance,ReferanceName,IsNull(TableID,0) as TableID
from POSHoldJournal 
where PosNo=" & My.Settings.POSNo & " 
Group by DocCode,CONVERT(VARCHAR(8), InputDateTime, 108),DocID,DocNotes,Referance,ReferanceName  ,TableID) B
on A.TableID=B.TableID "
            If _Location <> -1 Then
                sqlString += " where A.LocationID=" & _Location
            End If
            sqlString += " Order By A.TableID "
            sql.SqlTrueAccountingRunQuery(sqlString)
            Me.GridControlHoldVouchers.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetTablesLocations(WithAll As Boolean)
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " SELECT [ID],[LocationName],[PosNo]  FROM [dbo].[PosTablesLocations] "
        If WithAll = True Then sqlString += " union select -1 as ID , N'الكل' as LocationName," & _PosNo & " As PosNo"
        sql.SqlTrueAccountingRunQuery(sqlString)
        Me.GridControlTableLocations.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton15_Click(sender As Object, e As EventArgs) Handles SimpleButton15.Click
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount <> 0 Then MsgBoxShowError("يجب حفظ الفاتورة اولا ") : txtBarcode.Focus() : Exit Sub
            Case "TileView2"
                If TileView2.RowCount <> 0 Then MsgBoxShowError("يجب حفظ الفاتورة اولا ") : txtBarcode.Focus() : Exit Sub
        End Select
        ChangePosModeInResturantMode("Tables")
    End Sub


    Private Sub HoldVoucher()
        'If _PosVoucherNote = "" Then AddNoteToVoucher()

        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount = 0 Then
                    TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    TabbedControlGroupAllScreens.SelectedTabPage = TabTables
                    GridItemsGroups.Visible = False
                    SearchTables.EditValue = 0
                    LabelControlTableName.Text = ""
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Case "TileView2"
                If TileView2.RowCount = 0 Then
                    TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    TabbedControlGroupAllScreens.SelectedTabPage = TabTables
                    GridItemsGroups.Visible = False
                    SearchTables.EditValue = 0
                    LabelControlTableName.Text = ""
                    txtBarcode.Focus()
                    Exit Sub
                End If
        End Select
        Dim _VoucherTime As String
        _VoucherTime = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim sqlstring As String
        Dim sql As New SQLControl
        Dim _DocID As Integer
        Dim __FirstSide As Boolean
        _DocID = Me.BarStaticItemVoucherCounter.Caption
        sqlstring = "INSERT into POSHoldJournal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,[StockBarcode],[PCName],DocCode,PosNo,DocNoteByAccount,
                                       VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve],Produced,PriceEdited,DeviceName,TableID,PrinterName,Printed  ) 
                                       Select " & _DocID & ",CAST(GETDATE() AS DATE) ," & Me.DocName.Text & ",1," & _CostCenter & ",
                                       [DebitAcc],[CredAcc],AccountCurr,
                                       " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                       " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                        StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                         '" & TextReferanceNo.Text & "',N'" & TextReferanceName.Text & "',ItemName," & GlobalVariables._ShiftID & ",[StockBarcode],[PCName],
                                         DocCode,'" & _PosNo & "',DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve] ,
                                         Produced,IsNull(PriceEdited,0) as PriceEdited,DeviceName,'" & SearchTables.EditValue & "',IsNull(PrinterName,''),Printed
                                       from [dbo].[PosJournal] where DocCode='" & Me.DocCode.Text & "'"
        __FirstSide = sql.SqlTrueAccountingRunQuery(sqlstring)
        If __FirstSide = True Then
            sql.SqlTrueAccountingRunQuery("Delete from [dbo].[PosVouchers] where VoucherCode='" & DocCode.Text & "'")
        End If
        If _ResturantMode = True And resturantModeTablesOrTakeAway = "Tables" Then
            PrintVoucherFromPosJournalOrHoldJournal("POSJournal", True, False)
        End If
        '  _VoucherNote = ""
        ClearPosVoucher()
        GetPosJournalTable()
        PosAddLOG(Me.DocCode.Text, " Hold Voucher  ")
        SearchTables.EditValue = 0
        LabelControlTableName.Text = ""
        If _ResturantMode = True Then
            TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            TabbedControlGroupAllScreens.SelectedTabPage = TabTables
            GridItemsGroups.Visible = False
            ChangePosModeInResturantMode(cuurentModeInTablesOrTakeAway)
            'LayoutControlItem20.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            ' BarButtonItem13.Visibility = XtraBars.BarItemVisibility.Never
        End If

        txtBarcode.Focus()
    End Sub
    Private Sub BtnBackFromHoldVouchers_Click(sender As Object, e As EventArgs) Handles BtnBackFromHoldVouchers.Click
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount <> 0 Then MsgBoxShowError("يجب حفظ الفاتورة اولا ") : txtBarcode.Focus() : Exit Sub
            Case "TileView2"
                If TileView2.RowCount <> 0 Then MsgBoxShowError("يجب حفظ الفاتورة اولا ") : txtBarcode.Focus() : Exit Sub
        End Select
        ChangePosModeInResturantMode("TakeAway")
    End Sub

    Private Sub SimpleButton16_Click(sender As Object, e As EventArgs) Handles SimpleButton16.Click
        ShowKeyboard()
    End Sub

    Private Sub SearchTables_EditValueChanged(sender As Object, e As EventArgs) Handles SearchTables.EditValueChanged
        LabelControlTableName.Text = SearchTables.Text
    End Sub

    Private Sub TileViewTablesLocations_ItemPress(sender As Object, e As TileViewItemClickEventArgs) Handles TileViewTablesLocations.ItemPress
        Dim _ID As Integer
        _ID = TileViewTablesLocations.GetFocusedRowCellValue("ID")
        GetHoldVouchers(_ID)
        _SelectedLocation = _ID
    End Sub

    Private Sub ButtonOpenCashDrawer_Click(sender As Object, e As EventArgs)
        PosPrintVoucherEmpty()
        txtBarcode.Focus()
    End Sub

    Private Sub TextReferanceNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextReferanceNo.EditValueChanged
        BarReferanceNo.Caption = "رقم الزبون" & " " & TextReferanceNo.Text
    End Sub

    Private Sub TabCashCustomers_Shown(sender As Object, e As EventArgs) Handles TabCashCustomers.Shown
        GetCashCustomers()
    End Sub
    Private Sub GetCashCustomers()
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = "SELECT * FROM CashCustomer WHERE [IsActive] = 1 Order By CustomerID Desc"
            sql.SqlTrueAccountingRunQuery(sqlString)
            GridControlCashCustomers.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            XtraMessageBox.Show("Error loading cash customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit3_ButtonClick(sender As Object, e As XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit3.ButtonClick
        cashCustomerId = GridViewCashCustomer.GetFocusedRowCellValue("CustomerID")
        TextReferanceName.Text = GridViewCashCustomer.GetFocusedRowCellValue("CustomerName") & " (نقدي)"
        If _previousTabPage IsNot Nothing Then
            TabbedControlGroupAllScreens.SelectedTabPage = _previousTabPage
        End If
        TabCashCustomers.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    Private Sub BtnAddNewCashCustomer_Click(sender As Object, e As EventArgs) Handles BtnAddNewCashCustomer.Click
        Dim newCustomerForm As New CashCustomerDetails
        newCustomerForm.Text = "اضافة زبون نقدي جديد"
        newCustomerForm.TextName.Focus()
        If newCustomerForm.ShowDialog() <> DialogResult.OK Then
            If newCustomerForm.customerId <> 0 Then
                cashCustomerId = newCustomerForm.customerId
                TextReferanceName.Text = newCustomerForm.customerName & " (نقدي)"
                If _previousTabPage IsNot Nothing Then
                    TabbedControlGroupAllScreens.SelectedTabPage = _previousTabPage
                End If
                TabCashCustomers.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If
            GetCashCustomers()
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        If _previousTabPage IsNot Nothing Then
            TabbedControlGroupAllScreens.SelectedTabPage = _previousTabPage
        End If
        TabCashCustomers.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        txtBarcode.Focus()
    End Sub

    Private Sub POSRestCashier_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        txtBarcode.Focus()
    End Sub

    Private Sub BtnCalculater_Click(sender As Object, e As EventArgs) Handles BtnCalculater.Click
        Try
            Process.Start("calc.exe")
        Catch ex As Exception
            MessageBox.Show("Unable to open Calculator: " & ex.Message)
        End Try
    End Sub

    Public Sub InsertCustomerCarIfNotExists(carNo As String, chassiNo As String)
        If carNo = "" Then Exit Sub
        Dim sql As String =
            "IF NOT EXISTS (SELECT 1 FROM dbo.CustomersCars WHERE CarNo = @CarNo) " &
            "BEGIN " &
            "   INSERT INTO dbo.CustomersCars (CarNo, ChassiNo) " &
            "   VALUES (@CarNo, @ChassiNo) " &
            "END"

        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.Add("@CarNo", SqlDbType.NVarChar, 50).Value = carNo
                cmd.Parameters.Add("@ChassiNo", SqlDbType.NVarChar, 100).Value = chassiNo
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetupCarNoAutoComplete()
        Dim autoCompleteCollection As New AutoCompleteStringCollection()

        ' Fetch CarNo list from database
        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            Dim sql As String = "SELECT CarNo FROM dbo.CustomersCars ORDER BY CarNo"
            Using cmd As New SqlCommand(sql, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        autoCompleteCollection.Add(reader("CarNo").ToString())
                    End While
                End Using
            End Using
        End Using

        ' Apply to DevExpress TextEdit
        TextCarNumber.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextCarNumber.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextCarNumber.MaskBox.AutoCompleteCustomSource = autoCompleteCollection
    End Sub

    Private Sub TextReferanceName_TextChanged(sender As Object, e As EventArgs) Handles TextReferanceName.TextChanged
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = " Update POSJournal Set ReferanceName=N'" & TextReferanceName.Text & "' where DocCode='" & DocCode.Text & "' and PosNo=" & Me.BarPosNo.Caption
        sql.SqlTrueAccountingRunQuery(sqlString)
    End Sub

    Private Sub TextReferanceName_Enter(sender As Object, e As EventArgs) Handles TextReferanceName.Enter
        SwitchKeyboardLayout("ar")
    End Sub


    Private Sub LoadCustomersCarsParts()
        GridControlCarsParts.DataSource = Nothing
        Try
            Dim Sql As New SQLControl
            Dim sqlString As String
            'sqlString = "SELECT C.ID, CarID, I.ItemName, IsNull(R.RefName,'') As RefName , distinct (C.ItemNo) As ItemNo ,I.ItemNo2,CC.CarNo, C.DocName, C.VoucherNo, C.InputDateTime, C.RefNo 
            '                              FROM CustomersCarsParts C
            '                              Left Join Items I on I.ItemNo=C.ItemNo
            '                              Left Join Referencess R on R.RefNo=C.RefNo
            '                              Left Join CustomersCars CC on CC.ID = C.CarID
            '              Where CC.CarNo='" & TextCarNumber.Text & "' 
            '                              ORDER BY InputDateTime DESC"
            sqlString = " WITH RankedParts AS (
    SELECT 
        C.ItemNo,
        C.ID,
        C.CarID,
        I.ItemName,
        ISNULL(R.RefName, '') AS RefName,
        I.ItemNo2,
        CC.CarNo,
        C.DocName,
        C.VoucherNo,
        C.InputDateTime,
        C.RefNo,
        ROW_NUMBER() OVER (
            PARTITION BY C.CarID, C.ItemNo
            ORDER BY C.InputDateTime DESC
        ) AS rn
    FROM CustomersCarsParts C
    LEFT JOIN Items I 
           ON I.ItemNo = C.ItemNo
    LEFT JOIN Referencess R 
           ON R.RefNo = C.RefNo
    LEFT JOIN CustomersCars CC 
           ON CC.ID = C.CarID
          Where CC.CarNo='" & TextCarNumber.Text & "' 
)
SELECT 
    ItemNo,
    ID,
    CarID,
    ItemName,
    RefName,
    ItemNo2,
    CarNo,
    DocName,
    VoucherNo,
    InputDateTime,
    RefNo
FROM RankedParts
WHERE rn = 1
ORDER BY InputDateTime DESC; "
            Sql.SqlTrueAccountingRunQuery(sqlString)
            GridControlCarsParts.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        TabbedControlGroupAllScreens.SelectedTabPage = TabLayoutControlGroupItemsTab
        TabCustomersCarsParts.Visibility = XtraLayout.Utils.LayoutVisibility.Never
        txtBarcode.Focus()
    End Sub
    Private Sub TextCarNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCarNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True ' Prevents "ding" sound
            LoadCustomersCarsParts()
            TextShassiNumber.Focus()
        End If
    End Sub
    Private Sub CheckShiftIfOpening()
        Dim sqlString As String
        Dim Sql As New SQLControl
        sqlString = " Select [ShiftStatus] from PosShifts 
                      Where ShiftID=" & GlobalVariables._ShiftID
        Sql.SqlTrueAccountingRunQuery(sqlString)
        If Sql.SQLDS.Tables(0).Rows(0).Item("ShiftStatus") = "Closed" Then
            CreateDocLog("POS", "", "0", "0", "Insert",
                "Save Voucher in Closed Shift:" & GlobalVariables._ShiftID & " From Pos" & " " & _PosNo & " Employee:" & GlobalVariables.EmployeeName,
                Format(Now(), "yyyy-MM-dd HH:mm:ss"))
            Application.Exit()
        End If
    End Sub
    Private Sub RepositoryEditCashCustomer_Click(sender As Object, e As EventArgs) Handles RepositoryEditCashCustomer.Click
        Try
            ' Get the focused customer ID from the grid
            Dim customerId As Integer = GridViewCashCustomer.GetFocusedRowCellValue("CustomerID")

            If customerId <= 0 Then
                XtraMessageBox.Show("الرجاء تحديد زبون للتعديل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Create and configure the edit form
            Dim editCustomerForm As New CashCustomerDetails()
            With editCustomerForm
                .Text = "تعديل بيانات الزبون"
                .Tag = customerId.ToString() ' Pass the customer ID to load existing data

                ' Show the form and handle the result
                If .ShowDialog() = DialogResult.OK Then
                    ' Refresh the customers grid to show updated data
                    GetCashCustomers()

                    ' Show success message
                Else
                    GetCashCustomers()
                End If
            End With

        Catch ex As Exception
            XtraMessageBox.Show($"حدث خطأ أثناء تعديل الزبون: {ex.Message}", "خطأ",
                           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnPrintKitchen_Click(sender As Object, e As EventArgs) Handles BtnPrintKitchen.Click
        PrintVoucherFromPosJournalOrHoldJournal("PosJournal", True, True)
    End Sub
    Private Sub SimpleButton10_Click_1(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        Dim voucherAmount As Decimal = TexVouchertAmountAfterDiscount.EditValue
        If voucherAmount > 0 Then
            Dim posPaymentOptions As New PosPaymentOptions(voucherAmount, DefaultCashAcc)

            If posPaymentOptions.ShowDialog() = DialogResult.OK Then
                ReceiptsDetails = posPaymentOptions.SelectedPayments
                If ReceiptsDetails Is Nothing OrElse ReceiptsDetails.Count = 0 Then
                    XtraMessageBox.Show("لم يتم تحديد أي دفعة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                totalPaid = posPaymentOptions.TotalPaidAmount
                returnAmount = posPaymentOptions.ReturnAmount

                _FromTableVouchers = False
                Dim paymentsInfo As String = "تفاصيل المدفوعات:" & Environment.NewLine & Environment.NewLine
                For Each p As Payment In ReceiptsDetails
                    paymentsInfo &= $"طريقة الدفع: {p.PaymentOption} - المبلغ: {p.Amount:C}" & Environment.NewLine &
                            $"AccountNo: {p.AccountNo}, RefNo: {p.RefNo}, RefName: {p.RefName}, CustomerID: {p.CustomerID}" & Environment.NewLine & Environment.NewLine
                Next

                'XtraMessageBox.Show(paymentsInfo, "Returned Payments", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If _ResturantMode Then
                    LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                    LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                End If

                ' Update account and reference details
                'TextOtherAccountNo.Caption = PosCashBox.BarAccountNo.Caption
                'TextReferanceNo.Text = PosCashBox.BarRefNo.Caption
                'TextReferanceName.Text = PosCashBox.BarRefName.Caption

                SaveWithMultiplePaymentMethods(False)

            End If

            PosAddLOG(Me.DocCode.Text, "Show Payment Option")
        End If
        txtBarcode.Focus()
    End Sub
    Private Sub SaveWithMultiplePaymentMethods(printReceipt As Boolean)
        If ReceiptsDetails Is Nothing OrElse ReceiptsDetails.Count = 0 Then
            XtraMessageBox.Show("No payments selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        For Each payment As Payment In ReceiptsDetails
            Dim paymentType As String = payment.PaymentOption
            Dim amount As Decimal = payment.Amount
            Dim accountNo As String = payment.AccountNo
            Dim refNo As Integer = payment.RefNo
            Dim refName As String = payment.RefName
            Dim customerID As Integer = payment.CustomerID
            Select Case True
                Case paymentType.Contains("نقدي (شيكل)")
                    barAccountNo = _DefaultBaseCashAccount
                    barAccountName = GetFinancialAccountsData(_DefaultBaseCashAccount).AccName
                    barRefNo = "0"
                    barRefName = ""
                Case paymentType.Contains("فيزا")
                    If accountNo <> "" Then
                        barAccountNo = accountNo
                        barAccountName = GetFinancialAccountsData(barAccountNo).AccName

                    End If
                    barRefNo = "0"
                    barRefName = ""

                Case paymentType.Contains("ذمم")
                    If accountNo <> "" Then
                        barAccountNo = accountNo
                        barAccountName = GetFinancialAccountsData(barAccountNo).AccName
                    End If
                    barRefNo = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefNo")
                    barRefName = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RefName")

                    barCashCustomerName = ""
                    barCashCustomerID = ""

                Case paymentType.Contains("زبون نقدي")
                    barCashCustomerID = customerID.ToString()
                    barCashCustomerName = refName
            End Select
            SaveToJournalPaymentOptions()
        Next
    End Sub
    Private Sub SaveToJournalPaymentOptions()
        PosAddLOG(Me.DocCode.Text, "Begin Try Save Voucher")

        Dim _Referance As String = ""
        Dim _ReferanceName As String = ""
        CheckShiftIfOpening()

        ' Handle restaurant mode table/takeaway visibility
        If _ResturantMode Then
            LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlGroupTable.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            LayoutControlItemPrintKitchen.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        End If

        ' Handle table vouchers
        If _FromTableVouchers Then
            If Not CheckPrint.Checked Then
                HoldVoucher()
                GetHoldVouchers(_SelectedLocation)
                LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                _FromTableVouchers = False
                Exit Sub
            ElseIf CheckPrint.Checked Then
                PrintVoucherFromPosJournalOrHoldJournal("PosJournal", False, False)
                LayoutControlItemTablesModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Exit Sub
            End If
        End If

        ' Check if grid has rows
        Select Case GridPosVoucher.MainView.Name
            Case "GridView1"
                If GridView1.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Case "TileView2"
                If TileView2.RowCount = 0 Then
                    txtBarcode.Focus()
                    Exit Sub
                End If
        End Select

        ' Handle rounding
        If Math.Abs(Me.TextVoucherDiscountRound.EditValue) > 0.01 Then
            ReCalculateVouvherAfterRounded()
            Me.TextVoucherDiscountRound.EditValue = 0
        End If

        ' Validate discount amounts for non-gift/destruction vouchers
        If DocName.EditValue <> 18 Then
            If ChackIfDiscountGreatThanMaxDiscount() Then
                MsgBox("لا يمكن حفظ الفاتورة، لقد تجاوزت الحد الأقصى للخصم")
                PosAddLOG(Me.DocCode.Text, "Failed Save Voucher Because DocAmount Over Discount")
                Exit Sub
            End If
        End If

        ' Check if customer is required
        If customerIsRequirdInPOS AndAlso TextReferanceNo.Text = 0 Then
            My.Forms.PosSerachReferance.ShowDialog()
            If String.IsNullOrEmpty(TextReferanceName.Text) Then
                MsgBoxShowError("يجب اختيار زبون")
                Exit Sub
            End If
        End If

        ' Set up voucher variables
        Dim _DocAmount As Decimal = TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue
        Dim _PaidStatus As Integer = 0
        Dim _PaidAmount As Decimal = 0.0
        Dim _VoucherType As String = ""
        If ReceiptsDetails.Count = 1 Then
            SaveWithMultiplePayments = False

            Dim p = ReceiptsDetails(0)

            barAccountNo = p.AccountNo
            barRefNo = p.RefNo
            barRefName = p.RefName
            barCashCustomerID = p.CustomerID

            _Referance = If(String.IsNullOrEmpty(TextReferanceNo.Text) OrElse TextReferanceNo.Text = "0", "0", TextReferanceNo.Text)
            _ReferanceName = TextReferanceName.Text

            Dim paymentType As String = p.PaymentOption
            Select Case True
                Case paymentType.Contains("نقدي (شيكل)")
                    _VoucherType = If(TextOtherAccountNo.Caption = DefaultCashAcc, "Cash", "Card")
                    _PaidStatus = 2
                    _PaidAmount = _DocAmount
                    _ReferanceName = If(String.IsNullOrEmpty(_ReferanceName), "زبون نقدي", _ReferanceName)

                Case paymentType.Contains("فيزا")
                    _VoucherType = "Card"
                    _PaidStatus = 2
                    _PaidAmount = _DocAmount
                    _ReferanceName = "زبون فيزا"
                    GlobalVariables._PayCardName = p.CustomerID.ToString()

                Case paymentType.Contains("ذمم")
                    _VoucherType = "CSTMR"
                    _PaidStatus = 0
                    _PaidAmount = 0

                    ' Use RefNo from payment if available
                    If p.RefNo > 0 Then
                        _Referance = p.RefNo.ToString()

                    Else
                        _Referance = TextReferanceNo.Text
                    End If
                    TextReferanceNo.Text = _Referance
                    ' Get the reference data
                    Dim RefData = GetRefranceData(p.RefNo)
                    If RefData.RefID > 0 Then
                        _ReferanceName = RefData.RefName
                        TextOtherAccountNo.Caption = RefData.RefAccID
                    Else
                        MsgBoxShowError("يجب اختيار زبون للفاتورة ذمم")
                        Exit Sub
                    End If

                    _CustomerBalance = 0
                    cashCustomerId = 0

                Case paymentType.Contains("زبون نقدي")
                    _ReferanceName = "زبون نقدي"
                    _VoucherType = "Cash"
                    cashCustomerId = p.CustomerID
                    _PaidStatus = 2
            End Select

            ' Prevent storing CSTMR invoice on cash account
            If _VoucherType = "CSTMR" And TextOtherAccountNo.Caption = DefaultCashAcc Then
                CreateDocLog("POS", "", "0", "0", "Insert",
                             "الفاتورة ذمم ولكن كان من المحتمل تسجيلها كاش " &
                             TextOtherAccountNo.Caption & " : " & DefaultCashAcc & " From Pos",
                             Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                TextOtherAccountNo.Caption = GetRefranceData(_Referance).RefAccID
                Exit Sub
            End If
        ElseIf ReceiptsDetails.Count > 1 Then
            ' Multiple payments
            _VoucherType = "Multi"
            _PaidStatus = 0
            _PaidAmount = _DocAmount
            _Referance = If(String.IsNullOrEmpty(TextReferanceNo.Text) OrElse TextReferanceNo.Text = "0", "0", TextReferanceNo.Text)
            _ReferanceName = "متعدد"
            SaveWithMultiplePayments = True
            _paymentAccount = "9999999999"
        End If

        ' Handle empty card name
        If String.IsNullOrEmpty(GlobalVariables._PayCardName) Then
            GlobalVariables._PayCardName = ""
        End If

        ' Get table ID
        Dim tableID As Integer = If(SearchTables.EditValue IsNot Nothing, SearchTables.EditValue, 0)

        ' Get document ID
        Dim _DocID As Integer = GetDocNo(DocName.EditValue, False)
        If _DocID = 0 Then
            PosAddLOG(Me.DocCode.Text, "Error: Voucher No. Is Zero")
        End If
        ' Determine document status
        Dim _DocStatus As Integer = If(posPostVouchers, 3, 1)

        ' Set shelf ID for special cases
        Dim _Shelf As Integer = If(shalashCo, 1397, 0)

        ' Get payment amounts
        Dim __paidamount As Decimal = totalPaid
        Dim __returnamount As Decimal = returnAmount

        ' Get voucher time
        Dim _VoucherTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        ' Get voucher counter
        Dim _VoucherCounter As Integer = CInt(Me.BarStaticItemVoucherCounter.Caption)
        Try

            Select Case DocName.EditValue
                Case 2 ' Sales voucher
                    ' Handle voucher note
                    If String.IsNullOrEmpty(_PosVoucherNote) Then _PosVoucherNote = "  "
                    SaveToPosVoucher(_DocID, _DocStatus, _VoucherTime, _referanceName, _Shelf, _VoucherCounter,
                          _PaidStatus, _PaidAmount, _VoucherType, tableID,
                          _DocAmount, __returnamount, __paidamount)

                    SaveVoucherToJournal(_DocID, _DocStatus, _VoucherTime, _referanceName, _Shelf, _VoucherCounter, _PaidStatus, _PaidAmount,
                          _VoucherType, tableID, _DocAmount)

                Case 12 ' Returns voucher
                    SaveToPosVoucher(_DocID, _DocStatus, _VoucherTime, _referanceName, _Shelf, _VoucherCounter,
                          _PaidStatus, _PaidAmount, _VoucherType, tableID,
                          _DocAmount, __returnamount, __paidamount)

                Case 18 ' Gift or destruction voucher
                    ' Add appropriate note based on type
                    If Itlaf_Gift = "Gift" Then
                        If String.IsNullOrEmpty(_PosVoucherNote) Then
                            _PosVoucherNote = " سند اخراج / هدية "
                        Else
                            _PosVoucherNote += " سند اخراج / هدية "
                        End If
                    ElseIf Itlaf_Gift = "Itlaf" Then
                        If String.IsNullOrEmpty(_PosVoucherNote) Then
                            _PosVoucherNote = " سند اخراج / اتلاف "
                        Else
                            _PosVoucherNote += " سند اخراج / اتلاف "
                        End If
                    End If

                    ' Reset payment values
                    GlobalVariables._PayCardName = ""
                    __paidamount = 0
                    __returnamount = 0
                    SaveToPosVoucher(_DocID, _DocStatus, _VoucherTime, _referanceName, _Shelf, _VoucherCounter,
                      _PaidStatus, _PaidAmount, _VoucherType, tableID,
                      _DocAmount, __returnamount, __paidamount)


                    SaveVoucherToJournal(_DocID, _DocStatus, _VoucherTime, _referanceName, _Shelf, _VoucherCounter, _PaidStatus, _PaidAmount,
                          _VoucherType, tableID, _DocAmount)
            End Select
            If _VoucherSide AndAlso __FirstSide AndAlso _SecondSide Then
                ' Log document creation
                CreateDocLog("Document", Me.DocCode.Text, Me.DocName.EditValue, _DocID, "Insert",
                    "Inserted From POS No.:" & _PosNo, Format(Now(), "yyyy-MM-dd HH:mm:ss"))

                ' Send Voucher to OwnersMobile as text
                _CustomerBalance = GetReferanceBalance(TextReferanceNo.EditValue)
                If sendVouchersAsTextToMobileNumbers Then
                    SendVoucherAsTextToOwners(OwnersMobileNumbers)
                End If

                If sendVoucherToCustomer = True And sendVoucherPDFToCustomer = False Then
                    Dim mobiles As String() = New String() {GetRefranceData(_Referance).RefMobile}
                    SendVoucherAsTextToOwners(mobiles)
                    If shalashCo = True Then
                        Dim mobiles2 As String() = New String() {"120363418766138503"}
                        SendVoucherAsTextToOwners(mobiles2)
                    End If
                End If

                ' Process any production items
                ProduceItems()
                If shalashCo Then
                    InsertCustomerCarIfNotExists(Me.TextCarNumber.EditValue, Me.TextShassiNumber.Text)
                    InsertItemsToCustomersCarsParts()
                    SetupCarNoAutoComplete()
                    TextCarNumber.Text = ""
                    TextShassiNumber.Text = ""

                End If
                ' Set last _LastVoucherCode to use to print last voucher by Ctrl+P
                GlobalPosVariables._LastVoucherCode = Me.DocCode.Text

                ' Handle printing if requested
                If CheckPrint.Checked Then
                    _TempDocVoucherCode = DocCode.Text
                    _TempPaidAmount = Me.TextPaidAmount.EditValue
                    _VouchertAmountAfterDiscount = Me.TexVouchertAmountAfterDiscount.EditValue
                    _TempVoucherNote = _PosVoucherNote
                    _TempDocName = Me.DocName.EditValue
                    _Customer = TextReferanceName.Text
                    If TextReferanceName.Text = "" And _VoucherType = "Card" Then
                        _Customer = " زبون فيزا "
                    End If
                    ' Set customer details for receipt
                    If Me.TextReferanceNo.Text = "0" Or Me.TextReferanceNo.Text = "" Then
                        _DebitInvoice = False
                        _CustomerNo = 0
                        _CustomerBalance = ""
                    Else
                        _DebitInvoice = True
                        _CustomerNo = TextReferanceNo.Text
                        _CustMobile = GetRefranceData(TextReferanceNo.EditValue).RefMobile
                    End If

                    PrintVoucher()

                    If _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                        PrintVoucherFromPosJournalOrHoldJournal("POSJournal", True, False)
                    End If
                ElseIf _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                    PrintVoucherFromPosJournalOrHoldJournal("POSJournal", True, False)
                    'ElseIf CheckPrint.Checked And _ResturantMode AndAlso resturantModeTablesOrTakeAway = "TakeAway" Then
                    '    PrintVoucherFromPosJournalOrHoldJournal("POSJournal", False)
                End If
                cashCustomerId = 0
                PosAddLOG(Me.DocCode.Text, "Saving voucher Done")
                ClearPosVoucher()
            Else
                XtraMessageBox.Show("خطا: حاول مرة اخرى")
            End If

            ' Refresh UI state
            GetPosJournalTable()

            If _ResturantMode Then
                Me.LabelControlTableName.Text = ""
                'TabbedControlGroupAllScreens.SelectedTabPage = TabTables
                'TabTables.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                'LayoutControlItemCashModeButton.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                'LayoutControlItemTableName.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                ChangePosModeInResturantMode(cuurentModeInTablesOrTakeAway)
                'LayoutControlItemAllGroups.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            ShowSecondScreen("Welcome")
            txtBarcode.Focus()
            If (SaveWithMultiplePayments = True) Then
                Dim voucherID As Integer = _DocID
                SaveToReceiptsDetails(voucherID, ReceiptsDetails)
            End If
            'SaveWithMultiplePayments = False
        Catch ex As Exception
            XtraMessageBox.Show("Transaction failed: " & ex.Message)
        End Try
    End Sub
    Private Sub SaveToPosVoucher(_DocID As Integer, _DocStatus As Integer, _VoucherTime As String, _ReferanceName As String, _Shelf As Integer, _VoucherCounter As Integer,
                              _PaidStatus As Integer, _PaidAmount As Decimal,
                              _VoucherType As String, tableID As Integer,
                              _DocAmount As Decimal, __returnamount As Decimal, __paidamount As Decimal)

        Dim SqlString, SqlString2, SqlString3 As String
        Select Case DocName.EditValue
            Case 2
                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                        [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                        [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,PaidAmount,ReturnAmount,TableID,CashCustomerId)
                        VALUES(" & _DocID & ",'" & _VoucherTime & "'," & TexVouchertAmountBeforeDiscount.EditValue & "," &
                                TextVoucherDiscount.EditValue & "," & TextVoucherDiscount2.EditValue & "," &
                                (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                                GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                                TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                                _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                                GlobalVariables._ShiftID & ",2," & My.Settings.POSNo & "," & _VoucherCounter & "," &
                                __paidamount & "," & __returnamount & "," & tableID & "," & cashCustomerId & ")"
                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)

            Case 12 ' Returns voucher
                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                           [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                           [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,TableID,CashCustomerId) 
                           VALUES (" & _DocID & ",'" & _VoucherTime & "'," & -1 * TexVouchertAmountBeforeDiscount.EditValue & "," &
                              -1 * TextVoucherDiscount.EditValue & "," & -1 * TextVoucherDiscount2.EditValue & "," &
                              -1 * (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                               GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                               TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                               _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                               GlobalVariables._ShiftID & ",12," & My.Settings.POSNo & ", " & _VoucherCounter & "," & tableID & "," & cashCustomerId & ")"

                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)
                If _VoucherSide Then
                    SqlString = "INSERT INTO Journal
                              ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                               [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                               [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,CashCustomerId) 
                              VALUES(" & _DocID & ",'" & _VoucherTime & "'," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter &
                                    ",'0','" & TextOtherAccountNo.Caption & "'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," &
                                    _DocAmount & "," & _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser &
                                    "',CAST(GETDATE() AS smalldatetime),'" & TextReferanceNo.Text & "',N'" & _ReferanceName & "'," &
                                    GlobalVariables._ShiftID & ",'" & GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," &
                                    _VoucherCounter & "," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" &
                                    GlobalVariables.CurrDevice & "','" & _VoucherType & "'," & tableID & "," & cashCustomerId & ")"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                    End If
                End If

                If __FirstSide And _VoucherSide Then
                    SqlString2 = "INSERT INTO Journal
                               ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,
                                StockDiscount,[StockDebitShelve],[StockCreditShelve],VoucherCounter,StockBarcode,DocID2,[PaidStatus],[PaidAmount],DeviceName,POSVoucherPayType,TableID,LastPurchasePrice,CashCustomerId) 
                              SELECT " & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                                   [DebitAcc],[CredAcc],AccountCurr,
                                   " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                   " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                    StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                     '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",
                                     DocCode,'" & _PosNo & "',DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve]," &
                                         _VoucherCounter & ",StockBarcode," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" &
                                         GlobalVariables.CurrDevice & "',POSVoucherPayType," & tableID & ",LastPurchasePrice," & cashCustomerId & "
                              FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)

                    If Not _SecondSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                    End If
                End If

            Case 18 ' Gift or destruction voucher
                SqlString3 = "INSERT INTO [dbo].[PosVouchers] ([VoucherID],[VoucherDateTime],[VoucherAmount],[VoucherDiscount],[VoucherDiscount2],
                           [VoucherAmountAfterDiscount],[VoucherPC],[UserNo],[VoucherCode],[VoucherDebit],
                           [VoucherCredit],[VoucherPayType],VoucherReferance,VoucherReferanceName,PayCardName,VoucherNote,ShiftID,DocName,PosNo,VoucherCounter,PaidAmount,ReturnAmount)
                    VALUES(" & _DocID & ",'" & _VoucherTime & "'," & TexVouchertAmountBeforeDiscount.EditValue & "," &
                             TextVoucherDiscount.EditValue & "," & TextVoucherDiscount2.EditValue & "," &
                             (TextVoucherAmount.EditValue - TextVoucherDiscount2.EditValue) & ",'" &
                             GlobalVariables.CurrDevice & "'," & GlobalVariables.CurrUser & ",'" & DocCode.Text & "','" &
                             TextOtherAccountNo.Caption & "','0','" & _VoucherType & "','" & TextReferanceNo.Text & "',N'" &
                             _ReferanceName & "','" & GlobalVariables._PayCardName & "',N'" & _PosVoucherNote & "'," &
                             GlobalVariables._ShiftID & "," & DocName.EditValue & "," & My.Settings.POSNo & "," &
                             _VoucherCounter & "," & __paidamount & "," & __returnamount & ")"

                _VoucherSide = sql.SqlTrueAccountingRunQuery(SqlString3)

        End Select
    End Sub
    Private Sub SaveVoucherToJournal(_DocID As Integer, _DocStatus As Integer, _VoucherTime As String, _ReferanceName As String, _Shelf As Integer, _VoucherCounter As Integer,
                              _PaidStatus As Integer, _PaidAmount As Decimal,
                              _VoucherType As String, tableID As Integer, _DocAmount As Decimal)
        Dim Account As String = TextOtherAccountNo.Caption
        If SaveWithMultiplePayments = True Then
            Account = "9999999999"
        End If
        Dim SqlString, SqlString2 As String
        Select Case DocName.EditValue
            Case 2
                If _VoucherSide Then
                    ' Insert items to journal
                    SqlString = "INSERT INTO Journal
                           ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                            [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                            [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                            StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                            CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,
                            [StockDebitShelve],[StockCreditShelve],[VoucherCounter],StockBarcode,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,LastPurchasePrice,CashCustomerId) 
                        SELECT " & _DocID & ",CAST(GETDATE() AS DATE) ," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                             [DebitAcc],[CredAcc],AccountCurr,
                             " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                             " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                             StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                             '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & _PosNo & "',
                              DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve]," & _Shelf & ",
                             " & _VoucherCounter & ",StockBarcode," & GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",
                             '" & GlobalVariables.CurrDevice & "','" & _VoucherType & "'," & tableID & ",LastPurchasePrice," & cashCustomerId & "
                       FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on first side")
                    End If
                End If
                If __FirstSide And _VoucherSide Then
                    ' Insert total row
                    SqlString2 = "INSERT INTO Journal
                            ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                             [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                             [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],[DeviceName],POSVoucherPayType,TableID,CashCustomerId) 
                           VALUES(" & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",'" &
                                        Account & "','0'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," &
                                        _DocAmount & "," & _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" &
                                        _VoucherTime & "','" & TextReferanceNo.Text & "',N'" & _ReferanceName & "'," & GlobalVariables._ShiftID & ",'" &
                                        GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," & _VoucherCounter & "," &
                                        GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" & GlobalVariables.CurrDevice & "','" &
                                        _VoucherType & "'," & tableID & "," & cashCustomerId & ")"

                    _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)

                    If Not _SecondSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on second side")
                    End If
                    If SaveWithMultiplePayments = True Then
                        SaveReceiptToJournal(_DocStatus, _VoucherTime, _ReferanceName,
                                     _Shelf, _VoucherCounter, _PaidStatus, _PaidAmount,
                                     _VoucherType, tableID, _DocAmount)
                    End If
                End If
            Case 18
                If _VoucherSide Then
                    SqlString = "INSERT INTO Journal
                              ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                               [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                               [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                               StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                               CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,
                               [StockDebitShelve],[StockCreditShelve],[VoucherCounter],StockBarcode,DocID2,[PaidStatus],[PaidAmount],DeviceName,POSVoucherPayType,LastPurchasePrice) 
                           SELECT " & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter & ",
                                [DebitAcc],'4020000000',AccountCurr,
                                " & _DefaultCurr & ",[DocAmount],1,[DocAmount],[DocAmount],[DocManualNo],N'" & _PosVoucherNote & "',
                                " & GlobalVariables.CurrUser & ",'" & _VoucherTime & "',StockID,StockUnit,StockQuantity,[StockQuantityByMainUnit],
                                StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,'" & GlobalVariables.CurrUser & "',
                                '" & TextReferanceNo.Text & "',N'" & _ReferanceName & "',ItemName," & GlobalVariables._ShiftID & ",DocCode,'" & _PosNo & "',
                                 DocNoteByAccount,VoucherDiscount,StockDiscount,[StockDebitShelve],[StockCreditShelve]," & _VoucherCounter & ",StockBarcode," &
                                 GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'" & GlobalVariables.CurrDevice & "','',LastPurchasePrice
                          FROM [dbo].[PosJournal] WHERE DocCode='" & Me.DocCode.Text & "'"

                    __FirstSide = sql.SqlTrueAccountingRunQuery(SqlString)

                    If Not __FirstSide Then
                        sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                        PosAddLOG(Me.DocCode.Text, "Saving voucher failed on first side")
                    End If
        End If

        If __FirstSide And _VoucherSide Then
            SqlString2 = "INSERT INTO Journal
                               ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],POSVoucherPayType) 
                              VALUES(" & _DocID & ",CAST(GETDATE() AS DATE)," & Me.DocName.Text & "," & _DocStatus & "," & _CostCenter &
                        ",'4020000000','0'," & _DefaultCurr & "," & 1 & "," & _DocAmount & ",1," & _DocAmount & "," &
                        _DocAmount & ",0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" & _VoucherTime & "','" &
                        TextReferanceNo.Text & "',N'" & _ReferanceName & "'," & GlobalVariables._ShiftID & ",'" &
                        GlobalVariables.CurrUser & "','" & DocCode.Text & "','" & _PosNo & "'," & _VoucherCounter & "," &
                        GlobalVariables._ShiftID & "," & _PaidStatus & "," & _PaidAmount & ",'')"

            _SecondSide = sql.SqlTrueAccountingRunQuery(SqlString2)
            If Not _SecondSide Then
                sql.SqlTrueAccountingRunQuery("DELETE FROM journal WHERE DocCode='" & DocCode.Text & "' AND [DocID]=" & _DocID)
                sql.SqlTrueAccountingRunQuery("DELETE FROM [dbo].[PosVouchers] WHERE VoucherCode='" & DocCode.Text & "'")
                PosAddLOG(Me.DocCode.Text, "Saving voucher failed on second side")
            End If
        End If
        End Select
    End Sub
    Private Sub SaveToReceiptsDetails(voucherID As Integer, PaymentTable As List(Of Payment))
        Try

            For Each p As Payment In PaymentTable

                ' Reset values every loop
                Dim paymentType As String = ""
                Dim referanceName As String = ""
                Dim referanceNo As String = "0"
                Dim payCardName As String = "0"
                Dim cashCustomerId As Integer = 0
                If p.CustomerID <> -1 Then
                    cashCustomerId = p.CustomerID
                End If
                Select Case True
                    Case p.PaymentOption.Contains("نقدي (شيكل)")
                        paymentType = "Cash"
                        referanceName = "زبون نقدي"

                    Case p.PaymentOption.Contains("فيزا")
                        paymentType = "Card"
                        referanceName = "زبون فيزا"
                        payCardName = p.CardMethodID.ToString()

                    Case p.PaymentOption.Contains("ذمم")
                        paymentType = "CSTMR"

                        If p.RefNo > 0 Then
                            referanceNo = p.RefNo.ToString()
                        Else
                            referanceNo = TextReferanceNo.Text
                        End If

                        Dim refData = GetRefranceData(p.RefNo)
                        If refData.RefID > 0 Then
                            referanceName = refData.RefName
                            TextOtherAccountNo.Caption = refData.RefAccID
                        End If

                    Case p.PaymentOption.Contains("زبون نقدي")
                        paymentType = "Cash"
                        referanceName = "زبون نقدي"
                        cashCustomerId = p.CustomerID

                End Select

                ' SQL Insert
                Dim query As String =
                $"INSERT INTO PosReceipts
                (VoucherID, ReceiptDateTime, ReceiptPayType, ReceiptAmount, Notes,
                 ReferanceName, ReferanceNo, PayCardName, CashCustomerId)
                VALUES
                ({voucherID}, GETDATE(),
                 '{paymentType}',
                 {p.Amount},
                 '',
                 N'{referanceName}',
                 '{referanceNo}',
                 '{payCardName}',
                 {cashCustomerId}
                )"

                sql.SqlTrueAccountingRunQuery(query)
            Next

        Catch ex As Exception
            XtraMessageBox.Show("Error saving receipt details: " & ex.Message)
        End Try
    End Sub
    Private Sub SaveReceiptToJournal(_DocStatus As Integer, _VoucherTime As String, _ReferanceName As String,
                                     _Shelf As Integer, _VoucherCounter As Integer, _PaidStatus As Integer, _PaidAmount As Decimal,
                                     _VoucherType As String, tableID As Integer, _DocAmount As Decimal)
        Dim _DocID As Integer = GetDocNo(20, False)
        Try
            For Each p As Payment In ReceiptsDetails

                ' Reset values every loop
                Dim paymentAcc As String = ""
                Dim paymentAmount As Decimal = 0D
                Dim paymentType As String = ""
                Dim referanceName As String = ""
                Dim referanceNo As String = "0"
                Dim payCardName As String = "0"
                Dim cashCustomerId As Integer = 0
                Dim debitAccount As String = ""
                Dim paidStatus As Integer = 0
                Dim docName As String = "20"
                paymentAcc = p.AccountNo
                paymentAmount = p.Amount
                Dim refValue As String =
                If(p.RefNo.ToString IsNot Nothing AndAlso
                   p.RefNo.ToString() <> "0" AndAlso
                   p.RefNo.ToString() <> "-1",
                   p.RefNo.ToString(),
                   "0")
                If p.CustomerID <> -1 Then
                    cashCustomerId = p.CustomerID
                End If
                ' Determine payment type
                Select Case True

                    Case p.PaymentOption.Contains("نقدي (شيكل)")
                        paymentType = "Cash"
                        referanceName = "زبون نقدي"
                        debitAccount = DefaultCashAcc
                        paidStatus = 2
                    Case p.PaymentOption.Contains("فيزا")
                        paymentType = "Card"
                        referanceName = "زبون فيزا"
                        payCardName = p.CardMethodID.ToString()
                        debitAccount = p.AccountNo
                        paidStatus = 2
                    Case p.PaymentOption.Contains("ذمم")
                        paymentType = "CSTMR"
                        debitAccount = p.RefNo.ToString()
                        If p.RefNo > 0 Then
                            referanceNo = p.RefNo.ToString()
                        Else
                            referanceNo = TextReferanceNo.Text
                        End If

                        Dim refData = GetRefranceData(p.RefNo)
                        If refData.RefID > 0 Then
                            referanceName = refData.RefName
                            TextOtherAccountNo.Caption = refData.RefAccID
                        End If
                        paidStatus = 0
                    Case p.PaymentOption.Contains("زبون نقدي")
                        paymentType = "Cash"
                        referanceName = "زبون نقدي"
                        cashCustomerId = p.CustomerID
                        debitAccount = "10000004"
                        paidStatus = 2
                End Select

                Dim _CreditSide As Boolean = False
                Dim _DebitSide As Boolean = False
                Dim SqlCredit As String =
                        "INSERT INTO Journal
                ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                 [DebitAcc],[CredAcc],
                 [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                 [BaseCurrAmount],[BaseAmount],
                 [DocManualNo],[DocNotes],InputUser,InputDateTime,
                 Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,
                 PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],
                 DeviceName,POSVoucherPayType,TableID,[CashCustomerId])
                 VALUES(" &
                            _DocID & ",CAST(GETDATE() AS DATE)," & docName & "," & _DocStatus & "," & _CostCenter & ",
                    '0','" & _paymentAccount & "'," &
                            _DefaultCurr & "," & 1 & "," & paymentAmount & ",1," &
                            paymentAmount & "," & paymentAmount & ",
                    0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" &
                            _VoucherTime & "','" & refValue & "',N'" & _ReferanceName & "'," &
                            GlobalVariables._ShiftID & ",'" & GlobalVariables.CurrUser & "','" & DocCode.Text & "','" &
                            _PosNo & "'," & _VoucherCounter & "," & GlobalVariables._ShiftID & "," &
                            paidStatus & "," & paymentAmount & ",'" &
                            GlobalVariables.CurrDevice & "','" & paymentType & "'," &
                            tableID & "," & cashCustomerId & ")"

                _CreditSide = sql.SqlTrueAccountingRunQuery(SqlCredit)

                If _CreditSide = True Then
                    Dim SqlDebit As String =
                        "INSERT INTO Journal
                ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
                 [DebitAcc],[CredAcc],
                 [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                 [BaseCurrAmount],[BaseAmount],
                 [DocManualNo],[DocNotes],InputUser,InputDateTime,
                 Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,
                 PosNo,VoucherCounter,DocID2,[PaidStatus],[PaidAmount],
                 DeviceName,POSVoucherPayType,TableID,[CashCustomerId])
                 VALUES(" &
                    _DocID & ",CAST(GETDATE() AS DATE)," & docName & "," & _DocStatus & "," & _CostCenter &
                    ",'" & debitAccount &
                    "','0'," & _DefaultCurr & "," & 1 & "," & paymentAmount &
                    ",1," & paymentAmount & "," & paymentAmount & ",
                0,N'" & _PosVoucherNote & "','" & GlobalVariables.CurrUser & "','" &
                    _VoucherTime & "','" & refValue & "',N'" & _ReferanceName & "'," &
                    GlobalVariables._ShiftID & ",'" & GlobalVariables.CurrUser & "','" & DocCode.Text & "','" &
                    _PosNo & "'," & _VoucherCounter & "," & GlobalVariables._ShiftID & "," &
                    paidStatus & "," & paymentAmount & ",'" &
                    GlobalVariables.CurrDevice & "','" & paymentType & "'," &
                    tableID & "," & cashCustomerId & ")"

                    _DebitSide = sql.SqlTrueAccountingRunQuery(SqlDebit)

                End If
                If _CreditSide = False Then

                    Dim SqlDeleteLastDebit As String =
                    "DELETE TOP (1) FROM Journal " &
                    "WHERE DocID = " & _DocID &
                    " AND DebitAcc = '" & paymentAcc & "'" &
                    " AND CredAcc = '0'" &
                    " AND DocAmount = " & paymentAmount &
                    " AND PaidAmount = " & paymentAmount &
                    " AND POSVoucherPayType = '" & paymentType & "'" &
                    " AND ShiftID = " & GlobalVariables._ShiftID &
                    " AND DocCode = '" & DocCode.Text & "'" &
                    " AND PosNo = '" & _PosNo & "'" &
                    " ORDER BY ID DESC"

                    sql.SqlTrueAccountingRunQuery(SqlDeleteLastDebit)

                End If

            Next
        Catch ex As Exception
            XtraMessageBox.Show("Error saving receipt details: " & ex.Message)
        End Try
    End Sub
End Class

