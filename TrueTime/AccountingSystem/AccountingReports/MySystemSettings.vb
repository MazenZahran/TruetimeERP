Public Class MySystemSettings
    Public Property UseCostCenters As Boolean
    Public Property CostCenterForIncomeAccountsOnly As Boolean
    Sub New()
        ' GetMySystemSettings()
    End Sub

    Public Sub GetMySystemSettings()
        'Dim _SettingName, _SettingValue As String
        Try
            'Dim Sql As New SQLControl
            'Dim _SettingsTable As New DataTable
            'Sql.SqlTrueAccountingRunQuery(" Select [SettingName],[SettingValue],[SettingDescription]  from [dbo].[Settings] ")
            '_SettingsTable = _AppSettingsTable
            'With _SettingsTable
            '    For i = 0 To .Rows.Count - 1
            '        _SettingName = .Rows(i).Item("SettingName")
            '        _SettingValue = .Rows(i).Item("SettingValue")
            '        Select Case _SettingName
            '            Case "CostCenters"
            '                UseCostCenters = CBool(_SettingValue)
            '            Case "CostCenterForIncomeAccountsOnly"
            '                CostCenterForIncomeAccountsOnly = CBool(_SettingValue)
            'MsgBox(CostCenterForIncomeAccountsOnly)
            'Case "Archive_SaveDataInSqlOrFolder"
            '    Me.Archive_SaveDataInSqlOrFolder.EditValue = _SettingValue
            'Case "PosUseVoucherCounterInsteadVoucherNo"
            '    Me.PosUseVoucherCounterInsteadVoucherNo.EditValue = CBool(_SettingValue)
            '    GlobalVariables._PosUseVoucherCounterInsteadVoucherNo = CBool(_SettingValue)
            'Case "SendSmsFromDocuments"
            '    SendSmsFromDocuments.EditValue = CBool(_SettingValue)
            'Case "PosNumberOfCopies"
            '    Me.PosNumberOfCopies.EditValue = CInt(_SettingValue)
            'Case "ShowSummeryInDocumentList"
            '    Me.ShowSummeryInDocumentList.EditValue = CBool(_SettingValue)
            'Case "PosPostVouchers"
            '    Me.PosPostVouchers.EditValue = CBool(_SettingValue)
            'Case "PosShowRadialMenu"
            '    Me.PosShowRadialMenu.EditValue = CBool(_SettingValue)
            'Case "PosAllowChangeDeleteItemInVoucher"
            '    Me.PosAllowChangeDeleteItemInVoucher.EditValue = CBool(_SettingValue)
            'Case "PosPrintReferanceBalance"
            '    Me.PosPrintReferanceBalance.EditValue = CBool(_SettingValue)
            'Case "ReportStatmentTop"
            '    Me.TextTopMargine.EditValue = CDec(_SettingValue)
            'Case "ReportStatmentRight"
            '    Me.TextRightMargine.EditValue = CDec(_SettingValue)
            'Case "ReportStatmentLeft"
            '    Me.TextLeftMargine.EditValue = CDec(_SettingValue)
            'Case "ReportStatmentBottom"
            '    Me.TextBottomMargine.EditValue = CDec(_SettingValue)
            'Case "AlertWhenItemQuantityLessThanBalanceInVouchers"
            '    Me.AlertWhenItemQuantityLessThanBalanceInVouchers.EditValue = CBool(_SettingValue)
            'Case "PosMaxDiscount"
            '    Me.PosMaxDiscount.EditValue = CDec(_SettingValue)
            'Case "PosAllowChangeItemPrice"
            '    Me.PosAllowChangeItemPrice.EditValue = CBool(_SettingValue)
            'Case "PosVoucherQueryLimit"
            '    PosVoucherQueryLimit.EditValue = CInt(_SettingValue)
            'Case "PosCloseShiftPassword2"
            '    PosCloseShiftPassword2.Text = CStr(_SettingValue)
            'Case "PosCloseShiftPassword"
            '    PosCloseShiftPassword.Text = CStr(_SettingValue)
            'Case "POSuseShelves"
            '    Me.CheckPOSuseShelves.EditValue = CBool(_SettingValue)
            'Case "WareHouseUseShelf"
            '    Me.WareHouseUseShelf.EditValue = CBool(_SettingValue)
            '    GlobalVariables._WareHouseUseShelf = CBool(_SettingValue)
            'Case "UseSalesMan"
            '    Me.UseSalesMan.EditValue = CBool(_SettingValue)
            'Case "ShowShelvesColumnInVoucher"
            '    Me.ShowShelvesColumnInVoucher.EditValue = CBool(_SettingValue)
            'Case "UseSerials"
            '    Me.CheckUseSerials.EditValue = CBool(_SettingValue)
            'Case "ShowDiscountColumnInVoucher"
            '    Me.ShowDiscountColumnInVoucher.EditValue = CBool(_SettingValue)
            'Case "ShowBarcodeColumnInVoucher"
            '    Me.CheckShowBarcodeColumnInVoucher.EditValue = CBool(_SettingValue)
            'Case "PrintRefBalanceInVoucher"
            '    Me.CheckPrintRefBalanceInVoucher.EditValue = CBool(_SettingValue)
            'Case "PrintBarcodeInVoucher"
            '    Me.ComboFirstColInDocuments.Text = _SettingValue
            'Case "IssueVoucherInSubscriptionsSystem"
            '    Me.CheckIssueVoucherInSubscriptionsSystem.EditValue = CBool(_SettingValue)
            'Case "ShowItemNo2"
            '    Me.CheckShowItemNo2.EditValue = CBool(_SettingValue)
            'Case "PrintHeaderInVouchers"
            '    Me.CheckPrintHeaderInVouchers.EditValue = CBool(_SettingValue)
            'Case "OpenCashOnSave"
            '    Me.CheckOpenCashOnSave.EditValue = CBool(_SettingValue)
            'Case "PosPrinterSize"
            '    Me.PosPrinterSize.EditValue = _SettingValue
            'Case "PosVoucherNote2"
            '    Me.PosVoucherNote2.EditValue = _SettingValue
            'Case "PosVoucherNote1"
            '    Me.PosVoucherNote1.EditValue = _SettingValue
            'Case "ShowColNoteInStockMoveDoc"
            '    Me.CheckShowColNoteInStockMoveDoc.EditValue = CBool(_SettingValue)
            'Case "ShowColNoteInMoneyTransDoc"
            '    Me.CheckShowColNoteInMoneyTransDoc.EditValue = CBool(_SettingValue)
            'Case "CostCenters"
            '    Me.CheckCostCenters.EditValue = CBool(_SettingValue)
            'Case "ReferancesSalaryAccount"
            '    Me.SearchReferancesSalaryAccount.EditValue = _SettingValue
            'Case "ConnectedWIthTrueTime"
            '    CheckConnectedWIthTrueTime.EditValue = CBool(_SettingValue)
            'Case "CostCenterRequired"
            '    CheckCostCenterRequired.EditValue = CBool(_SettingValue)
            'Case "PosAllowMergeItems"
            '    PosAllowMergeItems.EditValue = CBool(_SettingValue)
            'Case "AllowCampaginsOnPOS"
            '    AllowCampaginsOnPOS.EditValue = CBool(_SettingValue)
            'Case "AccountingStatmentRefNote"
            '    Me.AccountingStatmentRefNote.Text = _SettingValue
            'End Select
            '    Next
            'End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
