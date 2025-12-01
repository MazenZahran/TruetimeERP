Public Class Fleet
    Private _fleetCode As Integer
    Private _fleetName As String
    Private _sendMessage As Boolean
    Private _monthlyVoucher As Boolean
    Private _prepaid As Boolean
    Private _SmsWithBalance As Boolean
    Private _mobile As String
    Private _available_amount As Integer
    Private _id As Integer
    Private _status As Integer
    Private _lastupdate As String

    Public Property fleetCode As Integer
        Get
            Return _fleetCode
        End Get
        Set(ByVal value As Integer)
            _fleetCode = value
        End Set
    End Property
    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property FleetName As String
        Get
            Return _fleetName
        End Get
        Set(ByVal value As String)
            _fleetName = value
        End Set
    End Property
    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

    Public Property SendMessage As Boolean
        Get
            Return _sendMessage
        End Get
        Set(ByVal value As Boolean)
            _sendMessage = value
        End Set
    End Property
    Public Property MonthlyVoucher As Boolean
        Get
            Return _monthlyVoucher
        End Get
        Set(ByVal value As Boolean)
            _monthlyVoucher = value
        End Set
    End Property
    Public Property SmsWithBalance As Boolean
        Get
            Return _SmsWithBalance
        End Get
        Set(ByVal value As Boolean)
            _SmsWithBalance = value
        End Set
    End Property
    Public Property Prepaid As Boolean
        Get
            Return _prepaid
        End Get
        Set(ByVal value As Boolean)
            _prepaid = value
        End Set
    End Property
    Public Property Mobile As String
        Get
            Return _mobile
        End Get
        Set(ByVal value As String)
            _mobile = value
        End Set
    End Property
    Public Property Available_amount As Decimal
        Get
            Return _available_amount
        End Get
        Set(ByVal value As Decimal)
            _available_amount = value
        End Set
    End Property
    Public Property LastUpdate As String
        Get
            Return _lastupdate
        End Get
        Set(ByVal value As String)
            _lastupdate = value
        End Set
    End Property
End Class
