' ====================================================================================================
' Document Configuration
' Defines settings for each document type
' ====================================================================================================
Public Class DocumentConfig
    ' Document Identity
    Public Property DocName As Integer
    Public Property FormTitle As String

    ' Account & Warehouse Configuration
    Public Property AccountField As String ' "DebitAcc" or "CredAcc"
    Public Property WarehouseField As String ' "Debit", "Credit", or "Both"
    Public Property WarehouseLabel As String
    Public Property WarehouseLabelSecondary As String

    ' UI Visibility Settings
    Public Property ShowConvertOptions As Boolean
    Public Property ShowApprovalButton As Boolean
    Public Property ShowDriverInfo As Boolean
    Public Property ShowOrderStatus As Boolean
    Public Property ShowDeliverDate As Boolean
    Public Property HidePriceColumns As Boolean
    Public Property IsReadOnlyWhenPosted As Boolean
    Public Property TaxDateIsReadOnly As Boolean

    ' Column Visibility
    Public Property ShowDiscountColumns As Boolean
    Public Property ShowShelfColumns As Boolean

    ' Constructor with safe defaults
    Public Sub New()
        IsReadOnlyWhenPosted = True
        ShowConvertOptions = False
        ShowApprovalButton = False
        ShowDriverInfo = False
        ShowOrderStatus = False
        ShowDeliverDate = False
        HidePriceColumns = False
        ShowDiscountColumns = True
        ShowShelfColumns = True
    End Sub
End Class