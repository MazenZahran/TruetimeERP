Imports System.Data.SqlClient
Imports DevExpress
Imports DevExpress.XtraEditors

' ====================================================================================================
' Base Stock Document Loader
' Common functionality for all stock movement documents (invoices, dispatches, returns, etc.)
' ====================================================================================================
Public MustInherit Class BaseStockDocumentLoader
    Implements IDocumentLoader

    Protected Form As AccStockMove
    Protected DocData As DocumentData
    Protected DisplaySettings As DocumentDisplaySettings
    Protected Stopwatch As System.Diagnostics.Stopwatch

    Public Sub New(form As AccStockMove)
        Me.Form = form
        Me.Stopwatch = New System.Diagnostics.Stopwatch()
    End Sub

    ''' <summary>
    ''' Main document loading workflow
    ''' </summary>
    Public Overridable Function LoadDocument(docCode As String, dataName As String, modifiedDateTime As String) As Boolean Implements IDocumentLoader.LoadDocument
        Try
            Stopwatch.Start()

            ' 1. Load document header data
            DocData = GetDocDataByDocCode(docCode, dataName, modifiedDateTime)
            If DocData Is Nothing OrElse DocData.DocID = 0 Then
                MsgBoxShowError("لم يتم العثور على المستند")
                Return False
            End If

            ' 2. Check if user can access this document
            If Not ValidateAccess() Then
                Return False
            End If

            ' 3. Handle serial numbers if enabled
            If GlobalVariables._UseSerials Then
                If Not LoadSerials(docCode) Then
                    Return False
                End If
            End If

            ' 4. Try to acquire document lock
            If Not TryAcquireLock(docCode) Then
                Return False
            End If

            ' 5. Show form first (required for control initialization)
            Form.Show()

            ' 6. Configure display settings (form title, read-only mode, etc.)
            ConfigureDisplaySettings()
            ApplyDisplaySettings()

            ' 7. Load form header data
            LoadFormHeaderData()

            ' 8. Load grid data (items)
            LoadGridData(dataName, modifiedDateTime)

            ' 9. Apply post-load configurations
            ApplyPostLoadSettings()

            Stopwatch.Stop()
            Form.BarPeriod.Caption = "Time Elapsed: " & Stopwatch.Elapsed.TotalSeconds.ToString("0.00") & " seconds"
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
    ''' Validates user access to document
    ''' </summary>
    Protected Overridable Function ValidateAccess() As Boolean
        If GlobalVariables._UserAccessType = 98 Then
            MsgBoxShowError("ليس لديك صلاحية الوصول إلى هذا المستند")
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Loads serial numbers into temp table when opening document
    ''' </summary>
    Protected Overridable Function LoadSerials(docCode As String) As Boolean
        If CheckIfDocOpend(docCode) Then
            MsgBox("The Voucher Already Opened")
            Return False
        End If

        If Not InsertSerialsToTempWhenOpenDoc(docCode, DocData.DocName) Then
            MsgBox("Error: Serials Cannot be Loaded")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Attempts to acquire exclusive lock on document
    ''' </summary>
    Protected Overridable Function TryAcquireLock(docCode As String) As Boolean
        Dim postService As New DocumentsPostService()
        If Not postService.TryLockDocument(docCode) Then
            XtraMessageBox.Show("⚠️ السند قيد الاستخدام من قبل مستخدم آخر، الرجاء المحاولة لاحقاً.")
            Form.askBeforeClose = False
            Form.Close()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Configures display settings based on document type and status
    ''' Must be implemented by derived classes
    ''' </summary>
    Protected MustOverride Sub ConfigureDisplaySettings()

    ''' <summary>
    ''' Applies display settings to form controls
    ''' </summary>
    Protected Overridable Sub ApplyDisplaySettings()
        With Form
            .Text = DisplaySettings.FormTitle

            ' Show/hide progress bar
            If DisplaySettings.ShowProgressBar Then
                .LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.Always
                .ProgressBarControl1.EditValue = 0
            End If

            ' Handle read-only mode
            If DisplaySettings.IsReadOnly Then
                .GridView1.OptionsBehavior.Editable = False
                .DocManualNo.ReadOnly = True
                .DocDate.ReadOnly = True
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
            End If

            ' Document status indicator
            If DocData.DocStatus = 3 Then
                .DocStatus.BackColor = Color.Red
            End If

            ' Show/hide convert options
            If Not DisplaySettings.ShowConvertOptions Then
                .LayoutConvertDoc.Visibility = XtraLayout.Utils.LayoutVisibility.Never
            End If

            ' Warehouse visibility
            .LayoutDebitHouse.Visibility = If(DisplaySettings.DebitWarehouseVisible, XtraLayout.Utils.LayoutVisibility.Always, XtraLayout.Utils.LayoutVisibility.Never)
            .LayoutCreditHouse.Visibility = If(DisplaySettings.CreditWarehouseVisible, XtraLayout.Utils.LayoutVisibility.Always, XtraLayout.Utils.LayoutVisibility.Never)

            If Not String.IsNullOrEmpty(DisplaySettings.DebitWarehouseLabel) Then
                .LayoutDebitHouse.Text = DisplaySettings.DebitWarehouseLabel
            End If

            If Not String.IsNullOrEmpty(DisplaySettings.CreditWarehouseLabel) Then
                .LayoutCreditHouse.Text = DisplaySettings.CreditWarehouseLabel
            End If
        End With
    End Sub

    ''' <summary>
    ''' Loads document header data into form controls
    ''' </summary>
    Protected Overridable Sub LoadFormHeaderData()
        With Form
            .DocID.EditValue = DocData.DocID
            .DocName.EditValue = DocData.DocName
            .DocDate.DateTime = DocData.DocDate
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

            ' Bar captions
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

            ' Document tags
            If Not String.IsNullOrEmpty(DocData.DocTags) Then
                SetDocumentTags(DocData.DocTags)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Loads grid data (document items)
    ''' </summary>
    Protected Overridable Function LoadGridData(dataName As String, modifiedDateTime As String) As DataTable
        Dim table = GetDocDataTable(DocData.DocName, DocData.DocID, dataName, modifiedDateTime).FirstTable
        Form.JournalGridControl.DataSource = table

        ' Calculate totals
        If table.Rows.Count > 0 Then
            Form.TextVoucherDiscount.EditValue = Convert.ToDecimal(table.Compute("SUM(VoucherDiscount)", String.Empty))
        End If

        Return table
    End Function

    ''' <summary>
    ''' Sets document tags in header button
    ''' </summary>
    Protected Overridable Sub SetDocumentTags(tags As String)
        Try
            Dim customHeaderButton = Form.LayoutHeader.CustomHeaderButtons(0)
            If customHeaderButton IsNot Nothing Then
                CType(customHeaderButton, DevExpress.XtraEditors.ButtonPanel.BaseButton).Caption = tags
            End If
        Catch ex As Exception
            ' Tags not supported in this form
        End Try
    End Sub

    ''' <summary>
    ''' Applies settings after data is loaded
    ''' </summary>
    Protected Overridable Sub ApplyPostLoadSettings()
        ' Hide progress bar
        Form.LayoutProgressBarControl.Visibility = XtraLayout.Utils.LayoutVisibility.OnlyInCustomization

        ' Hide order status if not needed
        Form.LayoutOrderStatus.Visibility = XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    ''' <summary>
    ''' Handles errors during document loading
    ''' </summary>
    Protected Overridable Sub HandleError(ex As Exception)
        MsgBoxShowError("خطأ في تحميل المستند: " & ex.Message)
        ClearTempTables(DocData?.DocCode)

        If Form IsNot Nothing AndAlso Form.Visible Then
            Form.askBeforeClose = False
            Form.Close()
        End If
    End Sub

    ''' <summary>
    ''' Cleans up resources
    ''' </summary>
    Public Overridable Sub Cleanup() Implements IDocumentLoader.Cleanup
        If DocData IsNot Nothing Then
            ClearTempTables(DocData.DocCode)
        End If
    End Sub

    ''' <summary>
    ''' Returns document type handled by this loader
    ''' </summary>
    Public MustOverride Function GetDocumentType() As Integer Implements IDocumentLoader.GetDocumentType

    ''' <summary>
    ''' Helper method to retrieve document data from database
    ''' Wraps existing function but returns DTO
    ''' </summary>
    Protected Overridable Function GetDocDataByDocCode(docCode As String, dataName As String, modifiedDateTime As String) As DocumentData
        ' Call existing function
        Dim result = AccountingFunctions.GetDocDataByDocCode(docCode, dataName, modifiedDateTime)

        ' Map to DTO
        Return New DocumentData With {
            .DocID = result.DocID,
            .DocName = result.DocName,
            .DocCode = result.DocCode,
            .DocDate = result.DocDate,
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
            .OtherAccountName = result.OtherAccountName,
            .RefAccID = result.RefAccID,
            .DeviceName = result.DeviceName,
            .InputUser = result.InputUser,
            .InputDateTime = result.InputDateTime,
            .SalesPerson = result.SalesPerson,
            .SalesPersonName = result.SalesPersonName,
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