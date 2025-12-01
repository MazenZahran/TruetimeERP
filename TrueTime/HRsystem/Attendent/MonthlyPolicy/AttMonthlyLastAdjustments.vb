Imports DevExpress.XtraEditors

Public Class AttMonthlyLastAdjustments
    Private _EmpID As Integer
    Private _Year As Integer
    Private _Month As Integer
    Public Sub New(EmpID As Integer, Year As Integer, Month As Integer)
        InitializeComponent()
        _EmpID = EmpID
        _Year = Year
        _Month = Month
    End Sub
    Private Sub AttMonthlyLastAdjustments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Private Sub GetData()
        Dim sql As New SQLControl
        Dim sqlstring As String
        sqlstring = "select * from AttMonthlyAdjustments where EmpID=" & _EmpID & " and Year=" & _Year & " and Month=" & _Month
        sql.SqlTrueTimeRunQuery(sqlstring)
        GridControl1.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim _Answer = XtraMessageBox.Show(" هل تريد حذف السجل؟ ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If _Answer = DialogResult.Yes Then
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " delete from [AttMonthlyAdjustments] where EmpID=" & _EmpID & " and Year=" & _Year & " and Month=" & _Month & " and ID=" & GridView1.GetFocusedRowCellValue("ID") & ";"
            sqlstring += "delete from [Vocations] where EmployeeID=" & _EmpID & " and VocID=" & GridView1.GetFocusedRowCellValue("VocDocID") & ";"
            sqlstring += "delete from [AttEmployeeAdditions] where EmployeeID=" & _EmpID & " and AdditionID=" & GridView1.GetFocusedRowCellValue("AdditionDocID") & ";"
            sqlstring += "delete from [AttEmployeePayments] where EmployeeID=" & _EmpID & " and PaymentID=" & GridView1.GetFocusedRowCellValue("PaymentDocID") & ""
            sql.SqlTrueTimeRunQuery(sqlstring)
            GetData()
        End If
    End Sub
End Class