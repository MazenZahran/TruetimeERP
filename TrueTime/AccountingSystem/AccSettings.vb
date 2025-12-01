Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DocumentFormat.OpenXml.ExtendedProperties


Public Class AccSettings
    Dim Con As SqlConnection
    Dim RefTypesAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveSettings()
        GetSettings()
    End Sub
    Private Sub AccSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Timer1.Interval = 500
        ' Timer1.Start()

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Dim start_time As DateTime
        'Dim stop_time As DateTime
        'Dim elapsed_time As TimeSpan
        'My.Forms.Main.ItemElapseTime.Caption = (0)
        'start_time = Now
        'Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        'Dim _FinancialAccounts As DataTable = GetFinancialAccounts(-1, -1, False,-1)
        'SearchReferancesSalaryAccount.Properties.DataSource = _FinancialAccounts
        'RepositoryFinancialAccount.DataSource = _FinancialAccounts
        'TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
        'GetSettings()
        'Timer1.Stop()
        'stop_time = Now
        'CloseProgressPanel(handle)
        'stop_time = Now
        'elapsed_time = stop_time.Subtract(start_time)
        'My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub


    Private Sub GetSettings()


        Try
            Dim Sql As New SQLControl
            Dim _SettingsTable As New DataTable
            Sql.SqlTrueAccountingRunQuery(" Select [SettingName],[SettingValue],[SettingDescription]  from [dbo].[Settings] ")
            _SettingsTable = Sql.SQLDS.Tables(0)
            Dim _SettingName, _SettingValue As String
            With _SettingsTable
                For i = 0 To .Rows.Count - 1
                    _SettingName = .Rows(i).Item("SettingName")
                    _SettingValue = .Rows(i).Item("SettingValue")
                    Select Case _SettingName
                        Case "ShowColBalanceInJournal"
                            Me.CheckShowColBalanceInJournal.EditValue = CBool(_SettingValue)
                        Case "Archive_FolderPath"
                            Me.Archive_FolderPath.Text = _SettingValue
                        Case "Archive_SaveDataInSqlOrFolder"
                            Me.Archive_SaveDataInSqlOrFolder.EditValue = _SettingValue
                        Case "PosUseVoucherCounterInsteadVoucherNo"
                            Me.PosUseVoucherCounterInsteadVoucherNo.EditValue = CBool(_SettingValue)
                            GlobalVariables._PosUseVoucherCounterInsteadVoucherNo = CBool(_SettingValue)
                        Case "SendSmsFromDocuments"
                            SendSmsFromDocuments.EditValue = CBool(_SettingValue)
                        Case "PosNumberOfCopies"
                            Me.PosNumberOfCopies.EditValue = CInt(_SettingValue)
                        Case "ShowSummeryInDocumentList"
                            Me.ShowSummeryInDocumentList.EditValue = CBool(_SettingValue)
                        Case "PosPostVouchers"
                            Me.PosPostVouchers.EditValue = CBool(_SettingValue)
                        Case "PosShowRadialMenu"
                            Me.PosShowRadialMenu.EditValue = CBool(_SettingValue)
                        Case "PosAllowChangeDeleteItemInVoucher"
                            Me.PosAllowChangeDeleteItemInVoucher.EditValue = CBool(_SettingValue)
                        Case "PosPrintReferanceBalance"
                            Me.PosPrintReferanceBalance.EditValue = CBool(_SettingValue)
                        Case "ReportStatmentTop"
                            Me.TextTopMargine.EditValue = CDec(_SettingValue)
                        Case "ReportStatmentRight"
                            Me.TextRightMargine.EditValue = CDec(_SettingValue)
                        Case "ReportStatmentLeft"
                            Me.TextLeftMargine.EditValue = CDec(_SettingValue)
                        Case "ReportStatmentBottom"
                            Me.TextBottomMargine.EditValue = CDec(_SettingValue)
                        Case "AlertWhenItemQuantityLessThanBalanceInVouchers"
                            Me.AlertWhenItemQuantityLessThanBalanceInVouchers.EditValue = CBool(_SettingValue)
                        Case "PosMaxDiscount"
                            Me.PosMaxDiscount.EditValue = CDec(_SettingValue)
                        Case "PosAllowChangeItemPrice"
                            Me.PosAllowChangeItemPrice.EditValue = CBool(_SettingValue)
                        Case "PosVoucherQueryLimit"
                            PosVoucherQueryLimit.EditValue = CInt(_SettingValue)
                        Case "PosCloseShiftPassword2"
                            PosCloseShiftPassword2.Text = CStr(_SettingValue)
                        Case "PosCloseShiftPassword"
                            PosCloseShiftPassword.Text = CStr(_SettingValue)
                        Case "POSuseShelves"
                            Me.CheckPOSuseShelves.EditValue = CBool(_SettingValue)
                        Case "WareHouseUseShelf"
                            Me.WareHouseUseShelf.EditValue = CBool(_SettingValue)
                            GlobalVariables._WareHouseUseShelf = CBool(_SettingValue)
                        Case "UseSalesMan"
                            Me.UseSalesMan.EditValue = CBool(_SettingValue)
                        Case "ShowShelvesColumnInVoucher"
                            Me.ShowShelvesColumnInVoucher.EditValue = CBool(_SettingValue)
                        Case "UseSerials"
                            Me.CheckUseSerials.EditValue = CBool(_SettingValue)
                        Case "ShowDiscountColumnInVoucher"
                            Me.ShowDiscountColumnInVoucher.EditValue = CBool(_SettingValue)
                        Case "ShowBarcodeColumnInVoucher"
                            Me.CheckShowBarcodeColumnInVoucher.EditValue = CBool(_SettingValue)
                        Case "PrintRefBalanceInVoucher"
                            Me.CheckPrintRefBalanceInVoucher.EditValue = CBool(_SettingValue)
                        Case "PrintBarcodeInVoucher"
                            Me.ComboFirstColInDocuments.Text = _SettingValue
                        Case "IssueVoucherInSubscriptionsSystem"
                            Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(_SettingValue)
                        Case "ShowItemNo2"
                            Me.CheckShowItemNo2.EditValue = CBool(_SettingValue)
                        Case "PrintHeaderInVouchers"
                            Me.CheckPrintHeaderInVouchers.EditValue = CBool(_SettingValue)
                        Case "OpenCashOnSave"
                            Me.CheckOpenCashOnSave.EditValue = CBool(_SettingValue)
                        Case "PosPrinterSize"
                            Me.PosPrinterSize.EditValue = _SettingValue
                        Case "PosVoucherNote2"
                            Me.PosVoucherNote2.EditValue = _SettingValue
                        Case "PosVoucherNote1"
                            Me.PosVoucherNote1.EditValue = _SettingValue
                        Case "ShowColNoteInStockMoveDoc"
                            Me.CheckShowColNoteInStockMoveDoc.EditValue = CBool(_SettingValue)
                        Case "ShowColNoteInMoneyTransDoc"
                            Me.CheckShowColNoteInMoneyTransDoc.EditValue = CBool(_SettingValue)
                        Case "CostCenters"
                            Me.CheckCostCenters.EditValue = CBool(_SettingValue)
                        Case "ReferancesSalaryAccount"
                            Me.SearchReferancesSalaryAccount.EditValue = _SettingValue
                        Case "ConnectedWIthTrueTime"
                            CheckConnectedWIthTrueTime.EditValue = CBool(_SettingValue)
                        Case "CostCenterRequired"
                            CheckCostCenterRequired.EditValue = CBool(_SettingValue)
                        Case "PosAllowMergeItems"
                            PosAllowMergeItems.EditValue = CBool(_SettingValue)
                        Case "AllowCampaginsOnPOS"
                            AllowCampaginsOnPOS.EditValue = CBool(_SettingValue)
                        Case "AccountingStatmentRefNote"
                            Me.AccountingStatmentRefNote.Text = _SettingValue
                        Case "POSCheckSendClosedShiftToMobile"
                            POSCheckSendClosedShiftToMobile.EditValue = CBool(_SettingValue)
                        Case "POSNumbersToSendClosedShift"
                            POSNumbersToSendClosedShift.EditValue = _SettingValue
                        Case "PosUseScales"
                            Me.PosUseScales.EditValue = CBool(_SettingValue)
                        Case "POS_ScaleComNO"
                            Me.ComboScaleComNo.EditValue = CInt(_SettingValue)
                        Case "Accounting_CostingMethodInProduction"
                            Me.ComboCostingMethodInProduction.Text = CStr(_SettingValue)
                        Case "POS_PosVoucherRoundingType"
                            Me.ComboRoundMethod.Text = CStr(_SettingValue)
                        Case "Accounting_VATdefaultPercentage"
                            Me.TextVATDefaultPercentage.Text = CDec(_SettingValue)
                    End Select
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
            Me.Close()
        End Try



        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ConnectedWIthTrueTime'")
        '    CheckConnectedWIthTrueTime.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ConnectedWIthTrueTime")
        'End Try
        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReferancesSalaryAccount'")
        '    Me.SearchReferancesSalaryAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        'Catch ex As Exception
        '    MsgBox("Err: ReferancesSalaryAccount")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='CostCenters'")
        '    Me.CheckCostCenters.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: CostCenters")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInMoneyTransDoc'")
        '    Me.CheckShowColNoteInMoneyTransDoc.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowColNoteInMoneyTransDoc")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInStockMoveDoc'")
        '    Me.CheckShowColNoteInStockMoveDoc.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowColNoteInStockMoveDoc")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote1'")
        '    Me.PosVoucherNote1.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        'Catch ex As Exception
        '    MsgBox("Err: PosVoucherNote1")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote2'")
        '    Me.PosVoucherNote2.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        'Catch ex As Exception
        '    MsgBox("Err: PosVoucherNote2")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPrinterSize'")
        '    Me.PosPrinterSize.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        'Catch ex As Exception
        '    MsgBox("Err: PosPrinterSize")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='OpenCashOnSave'")
        '    Me.CheckOpenCashOnSave.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintHeaderInVouchers'")
        '    Me.CheckPrintHeaderInVouchers.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PrintHeaderInVouchers")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2'")
        '    Me.CheckShowItemNo2.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowItemNo2")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='IssueVoucherInSubscriptionsSystem'")
        '    Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: IssueVoucherInSubscriptionsSystem")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintBarcodeInVoucher'")
        '    Me.ComboFirstColInDocuments.Text = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        'Catch ex As Exception
        '    MsgBox("Err: PrintBarcodeInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintRefBalanceInVoucher'")
        '    Me.CheckPrintRefBalanceInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PrintRefBalanceInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowBarcodeColumnInVoucher'")
        '    Me.CheckShowBarcodeColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowBarcodeColumnInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowDiscountColumnInVoucher'")
        '    Me.ShowDiscountColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowDiscountColumnInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseSerials'")
        '    Me.CheckUseSerials.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: UseSerials")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowShelvesColumnInVoucher'")
        '    Me.ShowShelvesColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowShelvesColumnInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseSalesMan'")
        '    Me.UseSalesMan.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: UseSalesMan")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='WareHouseUseShelf'")
        '    Me.WareHouseUseShelf.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        '    GlobalVariables._WareHouseUseShelf = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: WareHouseUseShelf")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='POSuseShelves'")
        '    Me.CheckPOSuseShelves.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: POSuseShelves")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosCloseShiftPassword'")
        '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then PosCloseShiftPassword.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosCloseShiftPassword")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosCloseShiftPassword2'")
        '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then PosCloseShiftPassword2.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosCloseShiftPassword2")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherQueryLimit'")
        '    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) Then PosVoucherQueryLimit.EditValue = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosVoucherQueryLimit")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosAllowChangeItemPrice'")
        '    Me.PosAllowChangeItemPrice.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosAllowChangeItemPrice")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosMaxDiscount'")
        '    Me.PosMaxDiscount.EditValue = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosMaxDiscount")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='AlertWhenItemQuantityLessThanBalanceInVouchers'")
        '    Me.AlertWhenItemQuantityLessThanBalanceInVouchers.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: AlertWhenItemQuantityLessThanBalanceInVouchers")
        'End Try




        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReportStatmentBottom'")
        '    Me.TextBottomMargine.EditValue = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ReportStatmentBottom")
        'End Try
        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReportStatmentLeft'")
        '    Me.TextLeftMargine.EditValue = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ReportStatmentLeft")
        'End Try
        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReportStatmentRight'")
        '    Me.TextRightMargine.EditValue = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ReportStatmentRight")
        'End Try
        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReportStatmentTop'")
        '    Me.TextTopMargine.EditValue = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ReportStatmentTop")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPrintReferanceBalance'")
        '    Me.PosPrintReferanceBalance.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosPrintReferanceBalance")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosAllowChangeDeleteItemInVoucher'")
        '    Me.PosAllowChangeDeleteItemInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosAllowChangeDeleteItemInVoucher")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosUseScales'")
        '    Me.PosUseScales.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosUseScales")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosShowRadialMenu'")
        '    Me.PosShowRadialMenu.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosShowRadialMenu")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPostVouchers'")
        '    Me.PosPostVouchers.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosPostVouchers")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowSummeryInDocumentList'")
        '    Me.ShowSummeryInDocumentList.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowSummeryInDocumentList")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosNumberOfCopies'")
        '    Me.PosNumberOfCopies.EditValue = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosNumberOfCopies")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='SendSmsFromDocuments'")
        '    Me.SendSmsFromDocuments.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: SendSmsFromDocuments")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosUseVoucherCounterInsteadVoucherNo'")
        '    Me.PosUseVoucherCounterInsteadVoucherNo.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        '    GlobalVariables._PosUseVoucherCounterInsteadVoucherNo = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: PosUseVoucherCounterInsteadVoucherNo")
        'End Try


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_SaveDataInSqlOrFolder'")
        '    Me.Archive_SaveDataInSqlOrFolder.EditValue = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: Archive_SaveDataInSqlOrFolder")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_FolderPath'")
        '    Me.Archive_FolderPath.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: Archive_FolderPath")
        'End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColBalanceInJournal'")
        '    Me.CheckShowColBalanceInJournal.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        'Catch ex As Exception
        '    MsgBox("Err: ShowColBalanceInJournal")
        'End Try




        GetRefTypes()

        GetImageQR()

        GetHeaderImages()

        GetFooterImages()

    End Sub

    '    Private Sub GetSettings()

    '        Try
    '            Dim Sql As New SQLControl
    '            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ConnectedWIthTrueTime';
    'Select SettingValue from [dbo].[Settings] where SettingName='ReferancesSalaryAccount';
    ' Select SettingValue from [dbo].[Settings] where SettingName='CostCenters';
    'Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInMoneyTransDoc';
    'Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInStockMoveDoc';
    'Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote1';
    'Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote2';
    'Select SettingValue from [dbo].[Settings] where SettingName='PosPrinterSize';
    'Select SettingValue from [dbo].[Settings] where SettingName='OpenCashOnSave';
    'Select SettingValue from [dbo].[Settings] where SettingName='PrintHeaderInVouchers';
    'Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2';
    ' Select SettingValue from [dbo].[Settings] where SettingName='IssueVoucherInSubscriptionsSystem';
    'Select SettingValue from [dbo].[Settings] where SettingName='PrintBarcodeInVoucher';
    ' Select SettingValue from [dbo].[Settings] where SettingName='PrintRefBalanceInVoucher';
    ' Select SettingValue from [dbo].[Settings] where SettingName='ShowBarcodeColumnInVoucher';
    'Select SettingValue from [dbo].[Settings] where SettingName='UseSerials';
    'Select SettingValue from [dbo].[Settings] where SettingName='ShowShelvesColumnInVoucher'
    '")
    '            Me.CheckConnectedWIthTrueTime.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '            Me.SearchReferancesSalaryAccount.EditValue = Sql.SQLDS.Tables(1).Rows(0).Item("SettingValue")
    '            Me.CheckCostCenters.EditValue = CBool(Sql.SQLDS.Tables(2).Rows(0).Item("SettingValue"))
    '            Me.CheckShowColNoteInMoneyTransDoc.EditValue = CBool(Sql.SQLDS.Tables(3).Rows(0).Item("SettingValue"))
    '            Me.CheckShowColNoteInStockMoveDoc.EditValue = CBool(Sql.SQLDS.Tables(4).Rows(0).Item("SettingValue"))
    '            Me.PosVoucherNote1.EditValue = Sql.SQLDS.Tables(5).Rows(0).Item("SettingValue")
    '            Me.PosVoucherNote2.EditValue = Sql.SQLDS.Tables(6).Rows(0).Item("SettingValue")
    '            Me.PosPrinterSize.EditValue = Sql.SQLDS.Tables(7).Rows(0).Item("SettingValue")
    '            Me.CheckOpenCashOnSave.EditValue = CBool(Sql.SQLDS.Tables(8).Rows(0).Item("SettingValue"))
    '            Me.CheckPrintHeaderInVouchers.EditValue = CBool(Sql.SQLDS.Tables(9).Rows(0).Item("SettingValue"))
    '            Me.CheckShowItemNo2.EditValue = CBool(Sql.SQLDS.Tables(10).Rows(0).Item("SettingValue"))
    '            Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(Sql.SQLDS.Tables(11).Rows(0).Item("SettingValue"))
    '            Me.CheckPrintBarcodeInVoucher.EditValue = CBool(Sql.SQLDS.Tables(12).Rows(0).Item("SettingValue"))
    '            Me.CheckPrintRefBalanceInVoucher.EditValue = CBool(Sql.SQLDS.Tables(13).Rows(0).Item("SettingValue"))
    '            Me.CheckShowBarcodeColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(14).Rows(0).Item("SettingValue"))
    '            Me.CheckUseSerials.EditValue = CBool(Sql.SQLDS.Tables(15).Rows(0).Item("SettingValue"))
    '            Me.ShowShelvesColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(16).Rows(0).Item("SettingValue"))
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '        GetRefTypes()

    '        GetImageQR()

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ReferancesSalaryAccount'")
    '        '    Me.SearchReferancesSalaryAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='CostCenters'")
    '        '    Me.CheckCostCenters.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInMoneyTransDoc'")
    '        '    Me.CheckShowColNoteInMoneyTransDoc.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try


    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowColNoteInStockMoveDoc'")
    '        '    Me.CheckShowColNoteInStockMoveDoc.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote1'")
    '        '    Me.PosVoucherNote1.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosVoucherNote2'")
    '        '    Me.PosVoucherNote2.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try


    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosPrinterSize'")
    '        '    Me.PosPrinterSize.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='OpenCashOnSave'")
    '        '    Me.CheckOpenCashOnSave.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintHeaderInVouchers'")
    '        '    Me.CheckPrintHeaderInVouchers.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2'")
    '        '    Me.CheckShowItemNo2.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try


    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='IssueVoucherInSubscriptionsSystem'")
    '        '    Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintBarcodeInVoucher'")
    '        '    Me.CheckPrintBarcodeInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PrintRefBalanceInVoucher'")
    '        '    Me.CheckPrintRefBalanceInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowBarcodeColumnInVoucher'")
    '        '    Me.CheckShowBarcodeColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseSerials'")
    '        '    Me.CheckUseSerials.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowShelvesColumnInVoucher'")
    '        '    Me.ShowShelvesColumnInVoucher.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try

    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseSalesMan'")
    '        '    Me.UseSalesMan.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try


    '        'Try
    '        '    Dim Sql As New SQLControl
    '        '    Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='AllowCostCenterByRow'")
    '        '    Me.AllowCostCenterByRow.EditValue = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
    '        'Catch ex As Exception
    '        '    MsgBox(ex.ToString)
    '        'End Try




    '    End Sub

    Private Sub SaveSettings()
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(CheckConnectedWIthTrueTime.EditValue) & "'
                                                  Where SettingName='ConnectedWIthTrueTime'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            If SearchReferancesSalaryAccount.Text <> "" Or Not IsNothing(SearchReferancesSalaryAccount.EditValue) Then
                Dim Sql As New SQLControl
                Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & SearchReferancesSalaryAccount.EditValue & "'
                                                  Where SettingName='ReferancesSalaryAccount'")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(CheckCostCenters.EditValue) & "'
                                                  Where SettingName='CostCenters'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(CheckShowColNoteInMoneyTransDoc.EditValue) & "'
                                                  Where SettingName='ShowColNoteInMoneyTransDoc'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(CheckShowColNoteInStockMoveDoc.EditValue) & "'
                                                  Where SettingName='ShowColNoteInStockMoveDoc'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckOpenCashOnSave.EditValue) & "'
                                                  Where SettingName='OpenCashOnSave'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & PosVoucherNote1.Text & "'
                                                  Where SettingName='PosVoucherNote1'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & PosVoucherNote2.Text & "'
                                                  Where SettingName='PosVoucherNote2'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & PosPrinterSize.Text & "'
                                                  Where SettingName='PosPrinterSize'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckPrintHeaderInVouchers.EditValue) & "'
                                                  Where SettingName='PrintHeaderInVouchers'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckShowItemNo2.EditValue) & "'
                                                  Where SettingName='ShowItemNo2'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckIssueVoucherInSubscriptionsSystem.EditValue) & "'
                                                  Where SettingName='IssueVoucherInSubscriptionsSystem'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & Me.ComboFirstColInDocuments.EditValue & "'
                                                  Where SettingName='PrintBarcodeInVoucher'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckPrintRefBalanceInVoucher.EditValue) & "'
                                                  Where SettingName='PrintRefBalanceInVoucher'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckShowBarcodeColumnInVoucher.EditValue) & "'
                                                  Where SettingName='ShowBarcodeColumnInVoucher'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckUseSerials.EditValue) & "'
                                                  Where SettingName='UseSerials'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.ShowShelvesColumnInVoucher.EditValue) & "'
                                                  Where SettingName='ShowShelvesColumnInVoucher'")
            GlobalVariables._ShowShelvesColumnInVoucher = CBool(Me.ShowShelvesColumnInVoucher.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.UseSalesMan.EditValue) & "'
                                                  Where SettingName='UseSalesMan'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.WareHouseUseShelf.EditValue) & "'
                                                  Where SettingName='WareHouseUseShelf'")
            GlobalVariables._WareHouseUseShelf = CBool(Me.WareHouseUseShelf.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(Me.CheckPOSuseShelves.EditValue) & "'
                                                  Where SettingName='POSuseShelves'")
            GlobalVariables._WareHouseUseShelf = CBool(Me.WareHouseUseShelf.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & PosCloseShiftPassword.Text & "'
                                                  Where SettingName='PosCloseShiftPassword'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & PosCloseShiftPassword2.Text & "'
                                                  Where SettingName='PosCloseShiftPassword2'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & PosVoucherQueryLimit.Text & "'
                                                  Where SettingName='PosVoucherQueryLimit'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & PosMaxDiscount.Text & "'
                                                  Where SettingName='PosMaxDiscount'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(AlertWhenItemQuantityLessThanBalanceInVouchers.EditValue) & "'
                                                  Where SettingName='AlertWhenItemQuantityLessThanBalanceInVouchers'")
            GlobalVariables._AlertWhenItemQuantityLessThanBalanceInVouchers = CBool(AlertWhenItemQuantityLessThanBalanceInVouchers.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CDec(TextBottomMargine.EditValue) & "'
                                                  Where SettingName='ReportStatmentBottom'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CDec(TextLeftMargine.EditValue) & "'
                                                  Where SettingName='ReportStatmentLeft'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CDec(TextRightMargine.EditValue) & "'
                                                  Where SettingName='ReportStatmentRight'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CDec(TextTopMargine.EditValue) & "'
                                                  Where SettingName='ReportStatmentTop'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(ShowDiscountColumnInVoucher.EditValue) & "'
                                                  Where SettingName='ShowDiscountColumnInVoucher'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosPrintReferanceBalance.EditValue) & "'
                                                  Where SettingName='PosPrintReferanceBalance'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosAllowChangeDeleteItemInVoucher.EditValue) & "'
                                                  Where SettingName='PosAllowChangeDeleteItemInVoucher'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosUseScales.EditValue) & "'
                                                  Where SettingName='PosUseScales'")
            GlobalVariables._PosUseScales = CBool(PosUseScales.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosShowRadialMenu.EditValue) & "'
                                                  Where SettingName='PosShowRadialMenu'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosPostVouchers.EditValue) & "'
                                                  Where SettingName='PosPostVouchers'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosAllowChangeItemPrice.EditValue) & "'
                                                  Where SettingName='PosAllowChangeItemPrice'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(ShowSummeryInDocumentList.EditValue) & "'
                                                  Where SettingName='ShowSummeryInDocumentList'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CInt(PosNumberOfCopies.EditValue) & "'
                                                  Where SettingName='PosNumberOfCopies'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosUseVoucherCounterInsteadVoucherNo.EditValue) & "'
                                                  Where SettingName='PosUseVoucherCounterInsteadVoucherNo'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(SendSmsFromDocuments.EditValue) & "'
                                                  Where SettingName='SendSmsFromDocuments'")
            GlobalVariables._SendSmsFromDocuments = CBool(SendSmsFromDocuments.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CStr(Archive_SaveDataInSqlOrFolder.EditValue) & "'
                                                  Where SettingName='Archive_SaveDataInSqlOrFolder'")
            GlobalVariables._CostCenterRequired = CBool(CheckCostCenterRequired.EditValue)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CStr(Archive_FolderPath.EditValue) & "'
                                                  Where SettingName='Archive_FolderPath'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CStr(CheckCostCenterRequired.EditValue) & "'
                                                  Where SettingName='CostCenterRequired'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(PosAllowMergeItems.EditValue) & "'
                                                  Where SettingName='PosAllowMergeItems'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(AllowCampaginsOnPOS.EditValue) & "'
                                                  Where SettingName='AllowCampaginsOnPOS'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & AccountingStatmentRefNote.Text & "'
                                                  Where SettingName='AccountingStatmentRefNote'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & CBool(POSCheckSendClosedShiftToMobile.EditValue) & "'
                                                  Where SettingName='POSCheckSendClosedShiftToMobile'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & POSNumbersToSendClosedShift.Text & "'
                                                  Where SettingName='POSNumbersToSendClosedShift'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & ComboScaleComNo.EditValue & "'
                                                  Where SettingName='POS_ScaleComNO'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & Me.ComboCostingMethodInProduction.Text & "'
                                                  Where SettingName='Accounting_CostingMethodInProduction'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & Me.ComboRoundMethod.Text & "'
                                                  Where SettingName='POS_PosVoucherRoundingType'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue=N'" & Me.TextVATDefaultPercentage.Text & "'
                                                  Where SettingName='Accounting_VATdefaultPercentage'")
            GlobalVariables.VATDefaultPercentage = CDec(Me.TextVATDefaultPercentage.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
        '                                          SettingValue='" & CBool(Me.AllowCostCenterByRow.EditValue) & "'
        '                                          Where SettingName='AllowCostCenterByRow'")
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        SavingRefTypesTable()

        Try
            If Not PictureQR.Image Is Nothing Then
                Dim m As New System.IO.MemoryStream
                PictureQR.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhoto(b)
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try

        Try
            If Not PictureHeader.Image Is Nothing Then
                Dim m As New System.IO.MemoryStream
                PictureHeader.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhoto(b)
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try

        Try
            If Not PictureHeader.Image Is Nothing Then
                Dim m As New System.IO.MemoryStream
                PictureHeader.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhotoHeaderFooter(b, "HeaderImage")
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try

        Try
            If Not PictureFooter.Image Is Nothing Then
                Dim m As New System.IO.MemoryStream
                PictureFooter.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhotoHeaderFooter(b, "FooterImage")
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try


        'XtraMessageBox.Show("تم حفظ البيانات")
        'XtraMessageBox.Show("تم حفظ البيانات", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
        Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
        Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حفظ الاعدادات بنجاح", Me.Text, New DialogResult() {DialogResult.OK}, icon, 0)
        XtraMessageBox.Show(args)


    End Sub



    Private Function IfAvailabeToConnect() As Boolean
        Dim j As Integer = 0
        Try
            Dim _Referances As New DataTable
            Dim Sql As New SQLControl
            Dim _RefNo As String
            Sql.SqlTrueAccountingRunQuery(" SELECT [RefNo],[RefName] FROM [dbo].[Referencess] ")
            _Referances = Sql.SQLDS.Tables(0)
            For i = 0 To _Referances.Rows.Count - 1
                _RefNo = _Referances.Rows(i).Item("RefNo")
                Try
                    Sql.SqlTrueTimeRunQuery(" select SalaryAccountNo from dbo.EmployeesData where SalaryAccountNo= '" & _RefNo & "'")
                    If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                        j = j + 1
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Next
        Catch ex As Exception

        End Try
        If j > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CheckConnectedWIthTrueTime_CheckedChanged(sender As Object, e As EventArgs) Handles CheckConnectedWIthTrueTime.CheckedChanged
        If CheckConnectedWIthTrueTime.CheckState = CheckState.Checked Then
            If IfAvailabeToConnect() = False Then
                MsgBox("خطأ: يوجد موظفين بنفس ارقام الذمم بالنظام المالي  ، لا يمكن الربط")
                CheckConnectedWIthTrueTime.Checked = False
            End If
        End If
    End Sub

    Private Sub SavePhoto(ByVal bytPhoto As Byte())
        Try
            Dim SQLString As String = " UPDATE CompanyData "
            SQLString = SQLString + " SET CompanyQR = @photo "
            Dim cn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(SQLString, cn)
                cmd.Parameters.Add("@photo", SqlDbType.Image, bytPhoto.Length).Value = bytPhoto
                Try
                    cmd.ExecuteNonQuery()
                Catch SqlExceptionErr As SqlClient.SqlException
                    MessageBox.Show(SqlExceptionErr.Message)
                End Try
            End Using
            cn.Close()
        Catch ex As Exception
            ' XtraMessageBox.Show("خطا: لم يتم حفظ الصورة")
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SavePhotoHeaderFooter(ByVal bytPhoto As Byte(), _HeaderFooter As String)
        Try
            Dim SQLString As String = " UPDATE CompanyData "
            SQLString = SQLString + " SET " & _HeaderFooter & " = @photo "
            Dim cn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(SQLString, cn)
                cmd.Parameters.Add("@photo", SqlDbType.Image, bytPhoto.Length).Value = bytPhoto
                Try
                    cmd.ExecuteNonQuery()
                Catch SqlExceptionErr As SqlClient.SqlException
                    MessageBox.Show(SqlExceptionErr.Message)
                End Try
            End Using
            cn.Close()
        Catch ex As Exception
            ' XtraMessageBox.Show("خطا: لم يتم حفظ الصورة")
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub GetImageQR()
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyQR from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New System.IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            PictureQR.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub GetHeaderImages()
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select HeaderImage from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New System.IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            PictureHeader.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetFooterImages()
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select FooterImage from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New System.IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            PictureFooter.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub GetHeaderFooter()
    '    Try
    '        Dim cn As SqlConnection
    '        cn = New SqlConnection
    '        cn.ConnectionString = My.Settings.TrueTimeConnectionString
    '        Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyQR from [dbo].[CompanyData]  ")
    '        cn.Open()
    '        cmd.Connection = cn
    '        cmd.CommandType = CommandType.Text
    '        Dim ImgStream As New System.IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
    '        PictureQR.Image = Image.FromStream(ImgStream)
    '        ImgStream.Dispose()
    '        cmd.Connection.Close()
    '        cn.Close()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub GetRefTypes()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            RefTypesAdapter = New SqlDataAdapter("SELECT TypeID,RefTypeName,DefaultAccount 
                                              FROM [dbo].[ReferencesTypes] order by TypeID ", Con)
            DS = New System.Data.DataSet()
            RefTypesAdapter.Fill(DS, "ReferencesTypes")
            GridRefTypes.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingRefTypesTable()
        Dim SqlCommBuil As SqlCommandBuilder
        SqlCommBuil = New SqlCommandBuilder(RefTypesAdapter)
        RefTypesAdapter.Update(DS, "ReferencesTypes")
    End Sub

    Private Sub CheckPrintHeaderInVouchers_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If Not ShellHelper.IsApplicationShortcutExist("tts") Then
            DevExpress.Data.ShellHelper.TryCreateShortcut("tts company", "tts")
            'Application.Restart()
        End If
    End Sub

    Private Sub CheckUseSerials_CheckedChanged(sender As Object, e As EventArgs) Handles CheckUseSerials.CheckedChanged

    End Sub

    Private Sub CheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles ShowShelvesColumnInVoucher.CheckedChanged

    End Sub

    Private Sub UseSalesMan_CheckedChanged(sender As Object, e As EventArgs) Handles UseSalesMan.CheckedChanged

    End Sub

    Private Sub AccSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        My.Forms.Main.ItemElapseTime.Caption = (0)
        start_time = Now
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me, customPainter:=New CustomOverlayPainter())
        Dim _FinancialAccounts As DataTable = GetFinancialAccounts(-1, -1, False, -1, -1)
        SearchReferancesSalaryAccount.Properties.DataSource = _FinancialAccounts
        RepositoryFinancialAccount.DataSource = _FinancialAccounts
        TabbedControlGroup1.SelectedTabPage = LayoutControlGroup3
        GetSettings()
        stop_time = Now
        CloseProgressPanel(handle)
        stop_time = Now
        elapsed_time = stop_time.Subtract(start_time)
        My.Forms.Main.ItemElapseTime.Caption = (elapsed_time.TotalSeconds.ToString("0.00"))
    End Sub

    Private Sub CheckShowBarcodeColumnInVoucher_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowBarcodeColumnInVoucher.CheckedChanged

    End Sub

    Private Sub PosAllowChangeItemPrice_CheckedChanged(sender As Object, e As EventArgs) Handles PosAllowChangeItemPrice.CheckedChanged

    End Sub

    Private Sub SendSmsFromDocuments_CheckedChanged(sender As Object, e As EventArgs) Handles SendSmsFromDocuments.CheckedChanged

    End Sub

    Private Sub Archive_FolderPath_Properties_Click(sender As Object, e As EventArgs) Handles Archive_FolderPath.Properties.Click
        Try
            XtraFolderBrowserDialog1.ShowDialog()
            Me.Archive_FolderPath.Text = XtraFolderBrowserDialog1.SelectedPath
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckShowColBalanceInJournal_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowColBalanceInJournal.CheckedChanged
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CBool(CheckShowColBalanceInJournal.EditValue) & "'
                                                  Where SettingName='ShowColBalanceInJournal'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub







    'Private Sub ComboPosPrinterType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboPosPrinterType.SelectedIndexChanged
    '    Select Case ComboPosPrinterType.Text
    '        Case "حجم: 80"
    '            PosPrinterSize.Text = "290"
    '        Case "حجم: 55"
    '            PosPrinterSize.Text = "200"
    '    End Select
    'End Sub
End Class