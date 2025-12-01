' ====================================================================================================
' Reference Data Transfer Object
' Represents customer/supplier information
' ====================================================================================================
Public Class ReferenceData
    ' Core Properties
    Public Property RefID As Integer
    Public Property RefNo As Integer
    Public Property RefName As String
    Public Property RefType As Integer
    Public Property RefTypeName As String

    ' Contact Information
    Public Property RefMobile As String
    Public Property RefPhone As String
    Public Property RefEmail As String
    Public Property ContactPerson As String

    ' Address Information
    Public Property Address As String
    Public Property SearchCity As String
    Public Property CityName As String

    ' Financial Properties
    Public Property RefAccID As String
    Public Property PriceCategory As Integer
    Public Property Currency As Integer
    Public Property MaxDebit As Decimal
    Public Property Balance As Decimal

    ' Identity Information
    Public Property IdentityNo As String
    Public Property Nationality As String
    Public Property IdentityType As String
    Public Property ReferanceCode As String

    ' License Information (Tarkhes)
    Public Property TarkhesID As String
    Public Property TarkhesIssueDate As String
    Public Property TarkhesEndDate As String

    ' Business Information
    Public Property SalesMan As Integer
    Public Property SalesManDay As Integer
    Public Property RefSort As String
    Public Property RefBirthDate As String
    Public Property RefMemo As String
    Public Property StartDate As String
    Public Property IsActive As Boolean

    ' Subscription
    Public Property SubscribeAmount As Decimal

    ' Default Constructor
    Public Sub New()
        RefID = 0
        RefNo = 0
        RefType = 0
        Currency = 1
        IsActive = True
        Balance = 0
        MaxDebit = 0
    End Sub
End Class