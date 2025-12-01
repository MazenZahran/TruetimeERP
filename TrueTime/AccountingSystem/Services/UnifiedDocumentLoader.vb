Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout
Imports DevExpress.XtraBars
Imports System.Drawing
Imports DevExpress

' ====================================================================================================
' Unified Document Loader
' Single class that handles ALL stock document types using configuration
' ====================================================================================================
Public Class UnifiedDocumentLoader
    Private Form As AccStockMove
    Private DocData As DocumentData
    Private Config As DocumentConfig
    Private Stopwatch As System.Diagnostics.Stopwatch

    Public Sub New(form As AccStockMove)
        Me.Form = form
        Me.Stopwatch = New System.Diagnostics.Stopwatch()
    End Sub

    ''' <summary>
    ''' Main loading method - works for ALL document types
    ''' </summary>
    Public Function LoadDocument(docCode As String, dataName As String, modifiedDateTime As String) As Boolean
        Try
            Stopwatch.Start()

            ' 1. Load document data
            DocData = GetDocDataByDocCodeDTO(docCode, dataName, modifiedDateTime)
            If DocData Is Nothing OrElse DocData.DocID = 0 Then
                MsgBoxShowError("لم يتم العثور على المستند")
                Return False
            End If

            ' 2. Get configuration for this document type
            Config = DocumentConfigFactory.GetConfig(DocData.DocName)

            ' 3. Handle serials if needed
            If GlobalVariables._UseSerials Then
                If Not LoadSerials(docCode, DocData.DocName) Then Return False
            End If

            ' 4. Show form first
            Form.Show()
            Form.DocName.EditValue = DocData.DocName

            ' 5. Try to lock document
            If Not TryAcquireLock(docCode) Then Return False

            ' 6. Load all form data
            ShowProgressBar()
            LoadFormHeaderData()
            LoadGridData(dataName, modifiedDateTime)

            ' 7. Apply UI settings
            ApplyUISettings()
            HideProgressBar()

            Stopwatch.Stop()
            Form.BarPeriod.Caption = "Time: " & Stopwatch.Elapsed.TotalSeconds.ToString("0.00") & "s"
            Form.BarPeriod.Visibility = XtraBars.BarItemVisibility.Always

            Return True

        Catch ex As Exception
            HandleError(ex)
            Return False
        Finally
            If Stopwatch.IsRunning Then Stopwatch.Stop()
        End Try
    End Function

    ''' <summary>
    ''' Load all form header data
    ''' </summary>
    Private Sub LoadFormHeaderData()
        With Form
            ' Basic fields
            .DocID.EditValue = DocData.DocID
            .DocDate.DateTime = DocData.DocDate
            .TaxDate.DateTime = DocData.TaxDate
            .DocManualNo.Text = DocData.DocManualNo
            .DocSort.EditValue = DocData.DocSort
            .Referance.EditValue = DocData.Referance
            .TextReferanceName.Text = DocData.ReferanceName
            .DocNotes.Text = DocData.DocNotes
            .DocCurrency.EditValue = DocData.DocCurrency
            .ExchangePrice.Text = DocData.ExchangePrice.ToString()
            .DocStatus.EditValue = DocData.DocStatus
            .DocCode.Text = DocData.DocCode
            .SalesPerson.EditValue = DocData.SalesPerson
            .StockDriver.Text = DocData.StockDriver
            .StockCarNo.Text = DocData.StockCarNo

            ' Cost center
            .LookCostCenter.EditValue = GetCostCenterForDocument(DocData.DocName, DocData.DocID)

            ' Warehouse (configuration-driven)
            LoadWarehouse()

            ' Other account
            .AccountForRefranace.EditValue = GetOtherAccount(DocData.DocName, DocData.DocID)

            ' Bar info
            .BarDocCode.Caption = DocData.DocCode
            .BarDeviceName.Caption = DocData.DeviceName
            .BarInputUser.Caption = DocData.InputUser
            .BarInputDateTime.Caption = DocData.InputDateTime
            .BarPaidStatus.Caption = DocData.PaidStatus.ToString()
            .BarPaidSAmount.Caption = DocData.PaidAmount.ToString()
            .BarPaidByDocID.Caption = DocData.PaidByDocID.ToString()

            ' Internal fields
            ._PosNo = DocData.PosNo
            ._ShiftID = DocData.ShiftID
            ._DocID2 = DocData.DocID2

            ' Last document link
            .LastDocCode.Text = DocData.LastDocCode
            .LastDataName.Text = DocData.LastDataName
            If Not String.IsNullOrEmpty(.LastDocCode.Text) Then
                .LayoutSourceFrom.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            End If

            ' Form title
            .Text = Config.FormTitle

            ' Tags
            If Not String.IsNullOrEmpty(DocData.DocTags) Then
                SetDocumentTags(DocData.DocTags)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Load warehouse based on configuration
    ''' </summary>
    Private Sub LoadWarehouse()
        Select Case Config.WarehouseField
            Case "Debit"
                Dim warehouse = GetWhareHouse(DocData.DocName, DocData.DocID)
                Form.StockDebitWhereHouse.EditValue = warehouse
                Form.LayoutDebitHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Form.LayoutCreditHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                Form.LayoutDebitHouse.Text = Config.WarehouseLabel

            Case "Credit"
                Dim warehouse = GetWhareHouse(DocData.DocName, DocData.DocID)
                Form.StockCreditWhereHouse.EditValue = warehouse
                Form.LayoutCreditHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Form.LayoutDebitHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Never
                Form.LayoutCreditHouse.Text = Config.WarehouseLabel

            Case "Both" ' Internal transfer
                Dim warehouses = GetWhareHouseFor16(DocData.DocName, DocData.DocID)
                Form.StockDebitWhereHouse.EditValue = warehouses.DebitWahreHouse
                Form.StockCreditWhereHouse.EditValue = warehouses.CreditWareHouse
                Form.LayoutDebitHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Form.LayoutCreditHouse.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                Form.LayoutDebitHouse.Text = Config.WarehouseLabel
                Form.LayoutCreditHouse.Text = Config.WarehouseLabelSecondary
                Form.LayoutDebitHouse.Location = New Point(0, 48)
                Form.LayoutCreditHouse.Location = New Point(0, 24)
        End Select
    End Sub

    ''' <summary>
    ''' Apply UI settings based on configuration and document status
    ''' </summary>
    Private Sub ApplyUISettings()
        With Form
            ' Read-only mode for posted documents
            If Config.IsReadOnlyWhenPosted AndAlso DocData.DocStatus = 3 Then
                ApplyReadOnlyMode()
            End If

            ' Hide price columns for dispatch documents
            If Config.HidePriceColumns Then
                .ColStockPrice.Visible = False
                .colDocAmount.Visible = False
                .ColLastPurchasePrice.Visible = False
                .ColStockDiscount.Visible = False
            End If

            ' Show/hide discount columns
            If Not Config.ShowDiscountColumns Then
                .ColStockDiscount.Visible = False
            End If

            ' Show driver info
            If Config.ShowDriverInfo Then
                .LayoutControlItemDriver.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                .LayoutControlItemPlate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            End If

            ' Show approval button for dispatch documents
            If Config.ShowApprovalButton AndAlso DocData.DocStatus = 3 AndAlso DocData.OrderStatus <> 99 Then
                .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            Else
                .LayoutControlItemApproveToVoucher.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            ' Convert options
            If Config.ShowConvertOptions AndAlso DocData.OrderStatus <> 99 Then
                .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            Else
                .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            ' Order-specific fields
            If Config.ShowOrderStatus Then
                .SearchOrderStatus.EditValue = DocData.OrderStatus
                .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            Else
                .LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            If Config.ShowDeliverDate Then
                .DateDeliverDate.DateTime = DocData.DeliverDate
                .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Always
            Else
                .LayoutDeliverDate.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            ' Shelf columns for internal transfer
            If DocData.DocName = 16 Then
                If GlobalVariables._WareHouseUseShelf = False Then
                    .ColStockDebitShelve.Visible = False
                    .ColStockCreditShelve.Visible = False
                Else
                    .ColStockDebitShelve.VisibleIndex = 10
                    .ColStockCreditShelve.VisibleIndex = 9
                End If
            End If
        End With
    End Sub

    ''' <summary>
    ''' Apply read-only mode to form
    ''' </summary>
    Private Sub ApplyReadOnlyMode()
        With Form
            .GridView1.OptionsBehavior.Editable = False
            .DocManualNo.ReadOnly = True
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
            .SalesPerson.ReadOnly = True
            .TextVoucherDiscount.ReadOnly = True
            .StockDriver.ReadOnly = True
            .StockCarNo.ReadOnly = True
            .LayoutControlSave.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            .DocStatus.BackColor = Color.Red
        End With
    End Sub

    ''' <summary>
    ''' Load grid data
    ''' </summary>
    Private Sub LoadGridData(dataName As String, modifiedDateTime As String)
        Dim table = GetDocDataTable(DocData.DocName, DocData.DocID, dataName, modifiedDateTime).FirstTable
        Form.JournalGridControl.DataSource = table

        If table.Rows.Count > 0 Then
            Form.TextVoucherDiscount.EditValue = Convert.ToDecimal(table.Compute("SUM(VoucherDiscount)", String.Empty))
        End If
    End Sub

    ' Helper methods
    Private Function LoadSerials(docCode As String, docName As Integer) As Boolean
        If CheckIfDocOpend(docCode) Then
            MsgBox("The Voucher Already Opened")
            Return False
        End If

        If Not InsertSerialsToTempWhenOpenDoc(docCode, docName) Then
            MsgBox("Error: Serials Cannot be Loaded")
            Return False
        End If

        Return True
    End Function

    Private Function TryAcquireLock(docCode As String) As Boolean
        Dim postService As New DocumentsPostService()
        If Not postService.TryLockDocument(docCode) Then
            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر")
            Form.askBeforeClose = False
            Form.Close()
            Return False
        End If
        Return True
    End Function

    Private Sub ShowProgressBar()
        Form.LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
        Form.ProgressBarControl1.EditValue = 0
        For i As Integer = 1 To 3
            Form.ProgressBarControl1.PerformStep()
            Form.ProgressBarControl1.Update()
        Next
    End Sub

    Private Sub HideProgressBar()
        Form.ProgressBarControl1.EditValue = 0
        Form.LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization
    End Sub

    Private Sub SetDocumentTags(tags As String)
        Try
            Dim customHeaderButton = Form.LayoutHeader.CustomHeaderButtons(0)
            If customHeaderButton IsNot Nothing Then
                CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton).Caption = tags
            End If
        Catch ex As Exception
            ' Tags not supported
        End Try
    End Sub

    Private Sub HandleError(ex As Exception)
        MsgBoxShowError("خطأ في تحميل المستند: " & ex.Message)
        ClearTempTables(DocData?.DocCode)
        If Form IsNot Nothing AndAlso Form.Visible Then
            Form.askBeforeClose = False
            Form.Close()
        End If
    End Sub

    ''' <summary>
    ''' Convert existing function result to DTO
    ''' </summary>
    Private Function GetDocDataByDocCodeDTO(docCode As String, dataName As String, modifiedDateTime As String) As DocumentData
        Dim result = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)

        Return New DocumentData With {
            .DocID = result.DocID,
            .DocName = result.DocName,
            .DocCode = result.DocCode,
            .DocDate = result.DocDate,
            .TaxDate = result.TaxDate,
            .DocStatus = result.DocStatus,
            .DocManualNo = result.DocManualNo,
            .DocSort = result.DocSort,
            .Referance = result.Referance,
            .ReferanceName = result.ReferanceName,
            .DocNotes = result.DocNotes,
            .DocCurrency = result.DocCurrency,
            .DocCurrencyName = result.DocCurrencyName,
            .ExchangePrice = result.ExchangePrice,
            .DocAmount = result.DocAmount,
            .BaseAmount = result.BaseAmount,
            .DebitAcc = result.DebitAcc,
            .CredAcc = result.CredAcc,
            .Account = result.Account,
            .AccountName = result.AccountName,
            .RefAccID = result.RefAccID,
            .DeviceName = result.DeviceName,
            .InputUser = result.InputUser,
            .InputDateTime = result.InputDateTime,
            .SalesPerson = result.SalesPerson,
            .OrderStatus = result.OrderStatus,
            .DeliverDate = result.DeliverDate,
            .LastDocCode = result.LastDocCode,
            .LastDataName = result.LastDataName,
            .PaidStatus = result.PaidStatus,
            .PaidAmount = result.PaidAmount,
            .PaidByDocID = result.PaidByDocID,
            .PosNo = result.PosNo,
            .ShiftID = result.ShiftID,
            .DocID2 = result.DocID2,
            .DocTags = result.DocTags,
            .StockDriver = result.StockDriver,
            .StockCarNo = result.StockCarNo
        }
    End Function
End Class