''' <summary>
''' Document types as defined in table [DocNames].
''' The numeric values MUST stay synchronized with the ID field in the database.
''' </summary>
Public Enum DocNameType
    Unknown = 0

    ''' <summary>1 - فاتورة مشتريات</summary>
    PurchaseInvoice = 1

    ''' <summary>2 - فاتورة مبيعات</summary>
    SalesInvoice = 2

    ''' <summary>3 - سند صرف</summary>
    PaymentVoucher = 3

    ''' <summary>4 - سند قبض</summary>
    ReceiptVoucher = 4

    ''' <summary>5 - سند قيد</summary>
    JournalVoucher = 5

    ''' <summary>6 - اشعار مدين</summary>
    DebitNote = 6

    ''' <summary>7 - اشعار دائن</summary>
    CreditNote = 7

    ''' <summary>8 - ارسالـية مشتريات</summary>
    PurchaseDispatch = 8

    ''' <summary>9 - ارسالـية مبيعات</summary>
    SalesDispatch = 9

    ''' <summary>10 - طلبية مشتريات</summary>
    PurchaseOrder = 10

    ''' <summary>11 - طلبية مبيعات</summary>
    SalesOrder = 11

    ''' <summary>12 - مردودات مبيعات</summary>
    SalesReturn = 12

    ''' <summary>13 - مردودات مشتريات</summary>
    PurchaseReturn = 13

    ''' <summary>14 - سند استلام بضاعة</summary>
    GoodsReceipt = 14

    ''' <summary>15 - سند تسليم بضاعة</summary>
    GoodsIssue = 15

    ''' <summary>16 - ارسالـية داخلية</summary>
    InternalTransfer = 16

    ''' <summary>17 - سند ادخال بضاعة</summary>
    GoodsIn = 17

    ''' <summary>18 - سند اخراج بضاعة</summary>
    GoodsOut = 18

    ''' <summary>19 - سند انتاج</summary>
    ProductionVoucher = 19
End Enum

