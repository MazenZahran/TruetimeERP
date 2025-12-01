' ====================================================================================================
' Warehouse Data Transfer Object
' Represents warehouse information for stock movements
' ====================================================================================================
Public Class WarehouseData
    ' Warehouse Properties
    Public Property WarehouseID As Integer
    Public Property WarehouseNameAR As String
    Public Property WarehouseNameEN As String
    Public Property IsDefault As Boolean

    ' Shelf Properties (for warehouse with shelves)
    Public Property ShelfID As Integer
    Public Property ShelfCode As String

    ' Default Constructor
    Public Sub New()
        WarehouseID = 0
        WarehouseNameAR = String.Empty
        WarehouseNameEN = String.Empty
        IsDefault = False
        ShelfID = 0
        ShelfCode = String.Empty
    End Sub
End Class

' ====================================================================================================
' Dual Warehouse Data (for transfers)
' ====================================================================================================
Public Class DualWarehouseData
    Public Property DebitWarehouse As WarehouseData
    Public Property CreditWarehouse As WarehouseData

    Public Sub New()
        DebitWarehouse = New WarehouseData()
        CreditWarehouse = New WarehouseData()
    End Sub
End Class