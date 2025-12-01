' ====================================================================================================
' Document Display Settings
' Controls UI visibility and behavior for different document types
' ====================================================================================================
Public Class DocumentDisplaySettings
    ' Form Display
    Public Property FormTitle As String
    Public Property IsReadOnly As Boolean

    ' Layout Visibility
    Public Property ShowProgressBar As Boolean
    Public Property ShowConvertOptions As Boolean
    Public Property ShowApprovalButton As Boolean
    Public Property ShowOrderStatus As Boolean
    Public Property ShowDeliverDate As Boolean

    ' Warehouse Visibility
    Public Property DebitWarehouseVisible As Boolean
    Public Property CreditWarehouseVisible As Boolean
    Public Property DebitWarehouseLabel As String
    Public Property CreditWarehouseLabel As String

    ' Grid Column Visibility
    Public Property ShowPriceColumns As Boolean
    Public Property ShowDiscountColumns As Boolean
    Public Property ShowDriverInfo As Boolean

    ' Custom Layout Visibility Dictionary
    Public Property LayoutVisibility As New Dictionary(Of String, Boolean)

    ' Default Constructor
    Public Sub New()
        ' Safe defaults
        FormTitle = "Document"
        IsReadOnly = False
        ShowProgressBar = True
        ShowConvertOptions = False
        ShowApprovalButton = False
        ShowOrderStatus = False
        ShowDeliverDate = False
        DebitWarehouseVisible = True
        CreditWarehouseVisible = True
        DebitWarehouseLabel = "Debit Warehouse"
        CreditWarehouseLabel = "Credit Warehouse"
        ShowPriceColumns = True
        ShowDiscountColumns = True
        ShowDriverInfo = False
    End Sub

    ' Helper method to set layout visibility
    Public Sub SetLayoutVisibility(layoutName As String, visible As Boolean)
        If LayoutVisibility.ContainsKey(layoutName) Then
            LayoutVisibility(layoutName) = visible
        Else
            LayoutVisibility.Add(layoutName, visible)
        End If
    End Sub

    ' Helper method to get layout visibility
    Public Function GetLayoutVisibility(layoutName As String) As Boolean
        If LayoutVisibility.ContainsKey(layoutName) Then
            Return LayoutVisibility(layoutName)
        Else
            Return True ' Default to visible
        End If
    End Function
End Class