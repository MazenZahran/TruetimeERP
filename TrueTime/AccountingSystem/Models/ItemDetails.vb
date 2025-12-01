Public Class ItemDetails

    ' --- Identity & basic info ---
    Public Property ItemNo As String
    Public Property ItemName As String

    ' In DB you store it as something, but logically it is Boolean
    Public Property HasExpireDate As Boolean

    ' Prices
    Public Property LastPurchasePrice As Decimal
    Public Property LastNetPurchasePrice As Decimal
    Public Property Price1 As Decimal
    Public Property Price2 As Decimal
    Public Property Price3 As Decimal
    Public Property TaxPercentage As Decimal

    ' Accounts
    Public Property AccSales As String
    Public Property AccPurches As String
    Public Property AccRetSales As String
    Public Property AccRetPurches As String

    ' Units
    Public Property DefaultUnit As Integer
    Public Property EquivalentToMain As Decimal
    Public Property Units As List(Of ItemUnit)

    ' Extra info
    Public Property ItemNote As String
    Public Property ItemType As String
    Public Property CategoryID As String
    Public Property TradeMarkID As Integer
    Public Property GroupID As Integer

    ' POS / Scale / Barcodes
    Public Property SaleOnScale As Boolean
    Public Property UnitBarcode As String
    Public Property VisibleInAPP As Boolean
    Public Property VisibleInPOS As Boolean
    Public Property ReOrderQuantity As Decimal
    Public Property HasSerial As Boolean
    Public Property HasProductionEquation As Boolean
    Public Property WithAdditions As Boolean
    Public Property UseBatchNo As Boolean
    Public Property SaleOnSamba As Boolean
    Public Property RequirePriceInPOS As Boolean

    ' Dates
    Public Property LastPurchaseDate As String   ' (keep as String if you want exact behavior)

    ' Stock / attributes
    Public Property Color As Integer
    Public Property Measure As Integer
    Public Property DefaultColor As Integer
    Public Property DefaultSize As Integer
    Public Property MaxQuantity As Decimal
    Public Property Vendor As Integer
    Public Property Classification As Integer    ' = _LookItemsclassification

    ' Item alternative codes
    Public Property ItemNo2 As String
    Public Property ItemNo3 As String
    Public Property ItemNo4 As String

    ' Company / web
    Public Property ProductCompany As String
    Public Property WebSite1 As String
    Public Property WebSite2 As String

    ' Costing / cost centers
    Public Property CostCenter As Integer

    ' Period info (subscriptions etc.)
    Public Property PeriodType As String
    Public Property PeriodCount As Decimal

End Class
