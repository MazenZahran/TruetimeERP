Public Class JiraLinkEmployee
    Private _JiraName As String
    Public Sub New(JiraName As String)
        _JiraName = JiraName
        InitializeComponent()

    End Sub
    Private Sub JiraLinkEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SearchLookUpEdit1.Properties.DataSource = GetEmployeesTable(-1, -1)
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select EmployeeID from EmployeesData where FaceBook=N'" & _JiraName & "'")
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Me.SearchLookUpEdit1.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID")
        End If
        Me.txtJiraName.Text = _JiraName
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Update EmployeesData set FaceBook=N'" & _JiraName & "' where EmployeeID=" & Me.SearchLookUpEdit1.EditValue)
        Me.Close()
    End Sub
End Class