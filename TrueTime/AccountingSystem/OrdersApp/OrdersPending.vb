Imports DevExpress
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base

Public Class OrdersPending
    Private Sub OrdersPending_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        Dim _DocNames As DataTable
        _DocNames = GetDocNames()
        'Dim R As DataRow = _DocNames.NewRow
        'R("id") = -1
        'R("Name") = "الكل"
        '_DocNames.Rows.Add(R)
        Me.SearchDocNames.Properties.DataSource = _DocNames
        Me.SearchDocNames.EditValue = -1
        Me.TextSeconds.EditValue = 5
        CreateDocStatusTable()
        SearchLookDocStatus.EditValue = 0
    End Sub
    Private Sub CreateDocStatusTable()
        Dim Table1 As New DataTable
        Table1.Columns.Add("ID", GetType(System.Int32))
        Table1.Columns.Add("StatusName", GetType(System.String))
        Table1.Columns.Add("StatusNameE", GetType(System.String))
        Table1.Rows.Add("-1", "الكل", "All")
        Table1.Rows.Add("0", "جديد", "Saved")
        Table1.Rows.Add("1", "معتمد", "Posted")
        SearchLookDocStatus.Properties.DataSource = Table1
    End Sub

    Public Sub RefreshOrdersFromAppList()
        Try
            If SearchLookDocStatus.Text = "" Then Exit Sub
            '  If Me.IsHandleCreated Then
            RepositoryReferance.DataSource = GetReferences(-1, -1, -1)
            '    Me.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(SearchDocNames.EditValue, False, SearchLookDocStatus.EditValue)
            Me.GridControl1.DataSource = RefreshMoneyTransListFromOrderApp(SearchDocNames.EditValue, False, SearchLookDocStatus.EditValue)
            'GridView1.BestFitColumns()
            RepositoryDebitAcc.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
            'RepositoryInputUser.DataSource = EmployeesAll
            'GridView1.BestFitColumns()
            '  End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MoneyTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshOrdersFromAppList()
        '  GridView1.BestFitColumns()
        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshOrdersFromAppList()
        End If
    End Sub
    Private Sub RepositoryOpenDoc_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpenDoc.ButtonClick
        OpenDoc()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        RefreshOrdersFromAppList()
    End Sub

    Private Sub OpenDoc()
        Dim DocCode As String = CStr(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocCode"))
        Dim DocStatus As Integer = GetDocStatus(DocCode, "OrdersAppJournal")
        If DocStatus = 1 And SearchLookDocStatus.EditValue = 0 Then
            MsgBox("هذا السند تم ترحيله")
            RefreshOrdersFromAppList()
        Else
            OpenDocumentsByDocCode(DocCode, "OrdersAppJournal", Me.Name)
        End If

    End Sub

    Private Function GetDocStatus(DocCode As String, JournalName As String) As Integer
        Dim _DocStatus As Integer = 0
        Dim Sql As New SQLControl
        Dim SqlString As String = "SELECT top(1) OrderStatus FROM OrdersAppJournal WHERE DocCode = '" & DocCode & "'"
        Sql.SqlTrueAccountingRunQuery(SqlString)
        If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
            _DocStatus = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("OrderStatus"))
        End If
        Return _DocStatus
    End Function
    Private Sub SearchDocNames_EditValueChanged(sender As Object, e As EventArgs) Handles SearchDocNames.EditValueChanged
        RefreshOrdersFromAppList()
    End Sub
    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As Object,
ByVal e As CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "OrderStatus" Then
            If e.Value = 0 Then e.DisplayText = "جديد"
            If e.Value = 1 Then e.DisplayText = "معتمد"
        End If
    End Sub

    Private Sub CheckAutoCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutoCheck.CheckedChanged
        If CheckAutoCheck.Checked = True Then
            Timer1.Interval = 5000
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        RefreshOrdersFromAppList()
    End Sub

    Private Sub SearchLookDocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookDocStatus.EditValueChanged
        RefreshOrdersFromAppList()
    End Sub
End Class