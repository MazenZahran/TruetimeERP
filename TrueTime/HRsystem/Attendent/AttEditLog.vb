Public Class AttEditLog
    Private _AttID As Integer
    Public Sub New(AttID As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        _AttID = AttID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub AttEditLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Private Sub GetData()
        Try
            Dim sqlString As String
            Dim Sql As New SQLControl
            sqlString = " Select * from DeletedEditedTrans where TransID=" & _AttID
            Sql.SqlTrueTimeRunQuery(sqlString)
            Me.GridControl1.DataSource = Sql.SQLDS.Tables(0)
        Catch ex As Exception
            Me.GridControl1.DataSource = ""
        End Try
    End Sub
End Class