Imports System.Data.SqlClient

Public Class SavingsFund
    Private connectionString As String = My.Settings.TrueTimeConnectionString

    Private Sub SavingsFund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GridControl1.DataSource = GetAllSavingsFunds()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        Me.GridControl1.DataSource = GetAllSavingsFunds()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.F5 Then
            Me.GridControl1.DataSource = GetAllSavingsFunds()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' CREATE
    Public Sub AddSavingsFund(salaryDocumentID As Integer, employeeID As Integer, companyContribution As Decimal, personalContribution As Decimal, docDate As Date, notes As String, inputDateTime As DateTime, inputUser As Integer)
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("INSERT INTO SavingsFund (SalaryDocumentID, EmployeeID, CompanyContribution, PersonalContribution, DocDate, Notes, InputDateTime, InputUser) VALUES (@SalaryDocumentID, @EmployeeID, @CompanyContribution, @PersonalContribution, @DocDate, @Notes, @InputDateTime, @InputUser)", con)
            cmd.Parameters.AddWithValue("@SalaryDocumentID", salaryDocumentID)
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
            cmd.Parameters.AddWithValue("@CompanyContribution", companyContribution)
            cmd.Parameters.AddWithValue("@PersonalContribution", personalContribution)
            cmd.Parameters.AddWithValue("@DocDate", docDate)
            cmd.Parameters.AddWithValue("@Notes", If(notes, DBNull.Value))
            cmd.Parameters.AddWithValue("@InputDateTime", inputDateTime)
            cmd.Parameters.AddWithValue("@InputUser", inputUser)
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' READ
    Public Function GetSavingsFundById(id As Integer) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT * FROM SavingsFund WHERE ID = @ID", con)
            cmd.Parameters.AddWithValue("@ID", id)
            Using adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function GetAllSavingsFunds() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT S.ID,S.SalaryDocumentID,S.EmployeeID,S.CompanyContribution,S.PersonalContribution, (S.CompanyContribution +S.PersonalContribution) As Total,S.DocDate,S.Notes,S.InputDateTime,S.InputUser,E.EmployeeName 
                                        FROM SavingsFund S
                                        Left Join EmployeesData E on E.EmployeeID=S.EmployeeID", con)
            Using adapter As New SqlDataAdapter(cmd)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    ' UPDATE
    Public Sub UpdateSavingsFund(id As Integer, salaryDocumentID As Integer, employeeID As Integer, companyContribution As Decimal, personalContribution As Decimal, docDate As Date, notes As String, inputDateTime As DateTime, inputUser As Integer)
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("UPDATE SavingsFund SET SalaryDocumentID=@SalaryDocumentID, EmployeeID=@EmployeeID, CompanyContribution=@CompanyContribution, PersonalContribution=@PersonalContribution, DocDate=@DocDate, Notes=@Notes, InputDateTime=@InputDateTime, InputUser=@InputUser WHERE ID=@ID", con)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.Parameters.AddWithValue("@SalaryDocumentID", salaryDocumentID)
            cmd.Parameters.AddWithValue("@EmployeeID", employeeID)
            cmd.Parameters.AddWithValue("@CompanyContribution", companyContribution)
            cmd.Parameters.AddWithValue("@PersonalContribution", personalContribution)
            cmd.Parameters.AddWithValue("@DocDate", docDate)
            cmd.Parameters.AddWithValue("@Notes", If(notes, DBNull.Value))
            cmd.Parameters.AddWithValue("@InputDateTime", inputDateTime)
            cmd.Parameters.AddWithValue("@InputUser", inputUser)
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' DELETE
    Public Sub DeleteSavingsFund(id As Integer)
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("DELETE FROM SavingsFund WHERE ID=@ID", con)
            cmd.Parameters.AddWithValue("@ID", id)
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
End Class