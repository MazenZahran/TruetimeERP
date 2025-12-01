' ====================================================================================================
' Document Configuration Factory
' Returns configuration for each document type
' ====================================================================================================
Public Class DocumentConfigFactory
    Public Shared Function GetConfig(docName As Integer) As DocumentConfig
        Dim config As New DocumentConfig()

        Select Case docName
            ' ========== Purchase Documents ==========
            Case 1 ' Purchase Invoice
                config.DocName = 1
                config.FormTitle = "فاتورة مشتريات"
                config.AccountField = "CredAcc"
                config.WarehouseField = "Debit"
                config.WarehouseLabel = "إلى مستودع"
                config.ShowDiscountColumns = True
                config.TaxDateIsReadOnly = False

            Case 17 ' Input Voucher
                config.DocName = 17
                config.FormTitle = "سند ادخال بضاعة"
                config.AccountField = "CredAcc"
                config.WarehouseField = "Debit"
                config.WarehouseLabel = "إلى مستودع"

            Case 8 ' Purchase Dispatch
                config.DocName = 8
                config.FormTitle = "ارسالية مشتريات"
                config.AccountField = "CredAcc"
                config.WarehouseField = "Debit"
                config.WarehouseLabel = "إلى مستودع"
                config.ShowDriverInfo = True
                config.HidePriceColumns = True
                config.ShowApprovalButton = True
                config.ShowDiscountColumns = False

            ' ========== Sales Documents ==========
            Case 2 ' Sales Invoice
                config.DocName = 2
                config.FormTitle = "فاتورة مبيعات"
                config.AccountField = "DebitAcc"
                config.WarehouseField = "Credit"
                config.WarehouseLabel = "من مستودع"
                config.ShowDiscountColumns = True

            Case 18 ' Output Voucher
                config.DocName = 18
                config.FormTitle = "سند اخراج بضاعة"
                config.AccountField = "DebitAcc"
                config.WarehouseField = "Credit"
                config.WarehouseLabel = "من مستودع"

            Case 9 ' Sales Dispatch
                config.DocName = 9
                config.FormTitle = "ارسالية مبيعات"
                config.AccountField = "DebitAcc"
                config.WarehouseField = "Credit"
                config.WarehouseLabel = "من مستودع"
                config.ShowDriverInfo = True
                config.HidePriceColumns = True
                config.ShowApprovalButton = True
                config.ShowDiscountColumns = False

            ' ========== Return Documents ==========
            Case 12 ' Return Sales
                config.DocName = 12
                config.FormTitle = "مردودات مبيعات"
                config.AccountField = "CredAcc"
                config.WarehouseField = "Debit"
                config.WarehouseLabel = "إلى مستودع"

            Case 13 ' Return Purchase
                config.DocName = 13
                config.FormTitle = "مردودات مشتريات"
                config.AccountField = "DebitAcc"
                config.WarehouseField = "Credit"
                config.WarehouseLabel = "من مستودع"

            ' ========== Internal Transfer ==========
            Case 16
                config.DocName = 16
                config.FormTitle = "ارسالية داخلية"
                config.WarehouseField = "Both"
                config.WarehouseLabel = "إلى مستودع"
                config.WarehouseLabelSecondary = "من مستودع"
                config.ShowDiscountColumns = False

            ' ========== Orders ==========
            Case 10 ' Purchase Order
                config.DocName = 10
                config.FormTitle = "طلبية مشتريات"
                config.AccountField = "CredAcc"
                config.WarehouseField = "Debit"
                config.WarehouseLabel = "إلى مستودع"
                config.ShowConvertOptions = True
                config.ShowOrderStatus = True
                config.ShowDeliverDate = True

            Case 11 ' Sales Order
                config.DocName = 11
                config.FormTitle = "طلبية مبيعات"
                config.AccountField = "DebitAcc"
                config.WarehouseField = "Credit"
                config.WarehouseLabel = "من مستودع"
                config.ShowConvertOptions = True
                config.ShowOrderStatus = True
                config.ShowDeliverDate = True

            Case Else
                Throw New NotSupportedException($"Document type {docName} is not supported")
        End Select

        Return config
    End Function
End Class