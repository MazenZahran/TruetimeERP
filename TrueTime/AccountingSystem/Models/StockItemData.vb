' ====================================================================================================
' Stock Item Data Transfer Object
' Represents item line details in stock documents
' ====================================================================================================
Public Class StockItemData
    ' Item Identification
    Public Property StockID As Integer
    Public Property ItemName As String
    Public Property ItemNo2 As String
    Public Property StockBarcode As String

    ' Unit Properties
    Public Property StockUnit As Integer
    Public Property UnitName As String
    Public Property EquivalentToMain As Decimal

    ' Quantity Properties
    Public Property StockQuantity As Decimal
    Public Property BonusQuantity As Decimal
    Public Property StockQuantityByMainUnit As Decimal
    Public Property BonusQuantityByMainUnit As Decimal

    ' Price Properties
    Public Property StockPrice As Decimal
    Public Property StockItemPrice As Decimal
    Public Property LastPurchasePrice As Decimal

    ' Financial Properties
    Public Property DocAmount As Decimal
    Public Property StockDiscount As Decimal
    Public Property VoucherDiscount As Decimal
    Public Property ItemVAT As Decimal
    Public Property ItemVATPercentage As Decimal

    ' Warehouse & Shelf
    Public Property StockDebitWhereHouse As Integer
    Public Property StockCreditWhereHouse As Integer
    Public Property StockDebitShelve As Integer
    Public Property StockCreditShelve As Integer

    ' Accounts
    Public Property DebitAcc As String
    Public Property CredAcc As String
    Public Property DocCostCenter As Integer

    ' Additional Properties
    Public Property Color As Integer
    Public Property Measure As Integer
    Public Property DocNoteByAccount As String
    Public Property Balance As Decimal
    Public Property BatchID As Integer
    Public Property BatchNo As String

    ' Dimensions
    Public Property StockWidth As Decimal
    Public Property StockLength As Decimal
    Public Property StockCount As Decimal

    ' Default Constructor
    Public Sub New()
        StockID = 0
        StockQuantity = 0
        BonusQuantity = 0
        StockQuantityByMainUnit = 0
        BonusQuantityByMainUnit = 0
        StockPrice = 0
        DocAmount = 0
        EquivalentToMain = 1
    End Sub

    ' Calculate net quantity (excluding bonus)
    Public ReadOnly Property NetQuantity As Decimal
        Get
            Return StockQuantity - BonusQuantity
        End Get
    End Property

    ' Calculate net quantity by main unit
    Public ReadOnly Property NetQuantityByMainUnit As Decimal
        Get
            Return StockQuantityByMainUnit - BonusQuantityByMainUnit
        End Get
    End Property

    ' Calculate total amount after discount
    Public ReadOnly Property NetAmount As Decimal
        Get
            Return DocAmount - StockDiscount - VoucherDiscount + ItemVAT
        End Get
    End Property
End Class