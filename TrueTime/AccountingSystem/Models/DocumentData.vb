' ====================================================================================================
' Document Data Transfer Object
' Represents all document header information retrieved from Journal/OrdersJournal tables
' ====================================================================================================
Public Class DocumentData
    ' Core Document Properties
    Public Property DocID As Integer
    Public Property DocName As Integer
    Public Property DocCode As String
    Public Property DocDate As DateTime
    Public Property TaxDate As DateTime
    Public Property DocStatus As Integer
    Public Property DocManualNo As String
    Public Property DocNotes As String

    ' Financial Properties
    Public Property DocCurrency As Integer
    Public Property DocCurrencyName As String
    Public Property DocAmount As Decimal
    Public Property ExchangePrice As Decimal
    Public Property BaseAmount As Decimal
    Public Property BaseCurrAmount As Decimal
    Public Property VoucherDiscount As Decimal
    Public Property StockDiscount As Decimal

    ' Account Properties
    Public Property DebitAcc As String
    Public Property CredAcc As String
    Public Property Account As String
    Public Property AccountName As String
    Public Property OtherAccountName As String

    ' Reference Properties
    Public Property Referance As Integer
    Public Property ReferanceName As String
    Public Property RefAccID As String

    ' Document Organization
    Public Property DocSort As Integer
    Public Property DocCostCenter As Integer
    Public Property DocMultiCurrency As Boolean

    ' Warehouse & Logistics
    Public Property StockDebitWhereHouse As Integer
    Public Property StockCreditWhereHouse As Integer
    Public Property StockDriver As String
    Public Property StockCarNo As String

    ' User & Audit Trail
    Public Property InputUser As Integer
    Public Property InputUserName As String
    Public Property InputDateTime As String
    Public Property DeviceName As String

    ' Order Management
    Public Property OrderStatus As Integer
    Public Property DeliverDate As DateTime

    ' Document Linking
    Public Property LastDocCode As String
    Public Property LastDataName As String

    ' Sales & Payment
    Public Property SalesPerson As Integer
    Public Property SalesPersonName As String
    Public Property PaidStatus As Integer
    Public Property PaidAmount As Decimal
    Public Property PaidByDocID As Integer

    ' POS Properties
    Public Property PosNo As Integer
    Public Property ShiftID As Integer
    Public Property DocID2 As Integer

    ' Tags & Attachments
    Public Property DocTags As String
    Public Property HasAttachment As Boolean

    ' Default Constructor
    Public Sub New()
        ' Initialize with safe defaults
        DocID = 0
        DocName = 0
        DocCode = String.Empty
        DocDate = DateTime.Today
        DocStatus = 1
        DocCurrency = 1
        ExchangePrice = 1.0
        InputDateTime = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")
        DeliverDate = DateTime.Today
        HasAttachment = False
    End Sub

    ' Helper method to check if document is posted
    Public ReadOnly Property IsPosted As Boolean
        Get
            Return DocStatus = 3
        End Get
    End Property

    ' Helper method to check if document is approved
    Public ReadOnly Property IsApproved As Boolean
        Get
            Return DocStatus = 2
        End Get
    End Property

    ' Helper method to check if document is deleted
    Public ReadOnly Property IsDeleted As Boolean
        Get
            Return DocStatus = 0
        End Get
    End Property
End Class