Public Class EmloyeesFlowChart
    Private Sub XtraForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData' table. You can move, or remove it, as needed.
        Me.EmployeesDataTableAdapter.FillByActive(Me.TrueTimeDataSet.EmployeesData, True)

    End Sub
End Class