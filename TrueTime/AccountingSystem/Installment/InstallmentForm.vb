Imports System.Data.SqlClient
Imports DevExpress.Pdf.Drawing.DirectX
Imports DevExpress.XtraEditors

Public Class InstallmentForm
    Private _connectionString As String = My.Settings.TrueTimeConnectionString
    Private _NewOld As String
    Public Sub New(NewOld As String)
        _NewOld = NewOld
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub InstallmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InstallmentReferance.Properties.DataSource = GetReferences(-1, 2, -1)
        InstallmentsPeriod.Properties.DataSource = CreatePeriodsDataTable()
        RepositoryPaymentStatus.DataSource = GetDocPaidStatus(False)
        Select Case _NewOld
            Case "New"
                InstallmentID.EditValue = -1
                InstallmentDate.DateTime = Today
            Case "Old"

        End Select
    End Sub

    Private Sub SearchReferance_Properties_BeforePopup(sender As Object, e As EventArgs) Handles InstallmentReferance.Properties.BeforePopup

    End Sub
    Private Sub Calc()
        Try
            If InstallmentsCount.EditValue > 0 Then
                InstallmentAmount.EditValue = (InstallmentsAmount.EditValue - InstallmentInitialAmount.EditValue) / InstallmentsCount.EditValue
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim InsertInstallmentID As Integer
        Dim summaryValue As Decimal = ColAmount.SummaryItem.SummaryValue
        If summaryValue <> InstallmentsAmount.EditValue Then
            MsgBoxShowError(" الدفعات لا تساوي مبلغ التسديد ")
            Exit Sub
        End If
        If GridView1.RowCount = 0 Then
            XtraMessageBox.Show("لا يوجد اصناف بالفاتورة")
            Exit Sub
        End If
        If InstallmentsPeriod.Text = "" Then
            XtraMessageBox.Show(" يجب اختيار الفترة ")
            Exit Sub
        End If
        InsertInstallmentID = InsertInstallment(InstallmentDate.DateTime, Me.VoucherNo.Text, InstallmentReferance.EditValue, InstallmentsAmount.EditValue, InstallmentAmount.EditValue, FirstInstallmentDate.EditValue, InstallmentsCount.EditValue, InstallmentsNotes.Text, InstallmentsPeriod.EditValue, InstallmentInOut.EditValue, InstallmentReferance.EditValue)
        If InsertInstallmentID > 0 Then
            For i = 0 To GridView1.RowCount - 1
                Dim _Amount As Decimal = GridView1.GetRowCellValue(i, "Amount")
                Dim _DueDate As Date = CDate(GridView1.GetRowCellValue(i, "DueDate"))
                Dim _Status As Integer = CInt(GridView1.GetRowCellValue(i, "Status"))
                Dim _Note As String = CStr(GridView1.GetRowCellValue(i, "Note"))
                If _Amount <> 0 Then InsertInstallmentPayment(InsertInstallmentID, _Amount, _DueDate, _Status, _Note)

                '   InsertToCalender(_DueDate, _DueDate, "قسط مستحق" & " " & FormatNumber(_Amount, 0) & " ₪ ", InstallmentReferance.Text, " قسط مستحق   " & InstallmentReferance.Text, 3, GlobalVariables.CurrUser, Today(), -1, InstallmentReferance.EditValue, "InstallmentID: " & InsertInstallmentID & "-" & i)
            Next
        End If
        Me.Close()
    End Sub
    Private Function InsertInstallment(installmentDate As Date, voucherNo As String, installmentReference As String,
                                  installmentsAmount As Decimal, installmentAmount As Decimal,
                                  firstInstallmentDate As Date, installmentsCount As Integer,
                                  installmentsNotes As String, installmentsPeriod As Integer, installmentInOut As String, installmentRef As Integer) As Integer
        Dim query As String = "INSERT INTO Installments (InstallmentDate, VoucherNo, InstallmentReferance, InstallmentsAmount, 
                        InstallmentAmount, FirstInstallmentDate, InstallmentsCount, InstallmentsNotes,InstallmentsPeriod,InstallmentInOut,InstallmentRef) 
                        VALUES (@InstallmentDate, @VoucherNo, @InstallmentReferance, @InstallmentsAmount, 
                        @InstallmentAmount, @FirstInstallmentDate, @InstallmentsCount, @InstallmentsNotes,@InstallmentsPeriod,@InstallmentInOut,@InstallmentRef);
                        SELECT SCOPE_IDENTITY();"

        Dim newInstallmentID As Integer = 0

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@InstallmentDate", installmentDate)
                cmd.Parameters.AddWithValue("@VoucherNo", voucherNo)
                cmd.Parameters.AddWithValue("@InstallmentReferance", installmentReference)
                cmd.Parameters.AddWithValue("@InstallmentsAmount", installmentsAmount)
                cmd.Parameters.AddWithValue("@InstallmentAmount", installmentAmount)
                cmd.Parameters.AddWithValue("@FirstInstallmentDate", firstInstallmentDate)
                cmd.Parameters.AddWithValue("@InstallmentsCount", installmentsCount)
                cmd.Parameters.AddWithValue("@InstallmentsNotes", installmentsNotes)
                cmd.Parameters.AddWithValue("@InstallmentsPeriod", installmentsPeriod)
                cmd.Parameters.AddWithValue("@InstallmentInOut", installmentInOut)
                cmd.Parameters.AddWithValue("@InstallmentRef", installmentRef)

                conn.Open()

                ' Execute the insert and get the generated InstallmentID
                newInstallmentID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        Return newInstallmentID
    End Function
    Private Sub InsertInstallmentPayment(installmentID As Integer, amount As Decimal, dueDate As Date, status As String, note As String)
        Try
            Dim query As String = "INSERT INTO InstallmentsPayments (InstallmentID, Amount, DueDate, Status,Note) 
                               VALUES (@InstallmentID, @Amount, @DueDate, @Status,@Note)"

            Using conn As New SqlConnection(_connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@InstallmentID", installmentID)
                    cmd.Parameters.AddWithValue("@Amount", amount)
                    cmd.Parameters.AddWithValue("@DueDate", dueDate)
                    cmd.Parameters.AddWithValue("@Status", status)
                    cmd.Parameters.AddWithValue("@Note", note)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Delete From Installments where [InstallmentID]=" & installmentID)
        End Try

    End Sub

    Public Function GetInstallments() As DataTable
        Dim query As String = "SELECT * FROM Installments"
        Dim dt As New DataTable()

        Using conn As New SqlConnection("your_connection_string_here")
            Using cmd As New SqlCommand(query, conn)
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using

        Return dt
    End Function


    Public Sub UpdateInstallmentPayment(id As Integer, amount As Decimal, dueDate As Date, status As String)
        Dim query As String = "UPDATE InstallmentsPayments 
                          SET Amount = @Amount, DueDate = @DueDate, Status = @Status
                          WHERE ID = @ID"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.Parameters.AddWithValue("@Amount", amount)
                cmd.Parameters.AddWithValue("@DueDate", dueDate)
                cmd.Parameters.AddWithValue("@Status", status)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub DeleteInstallment(installmentID As Integer)
        Dim query As String = "DELETE FROM Installments WHERE InstallmentID = @InstallmentID"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@InstallmentID", installmentID)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub DeleteInstallmentPayment(id As Integer)
        Dim query As String = "DELETE FROM InstallmentsPayments WHERE ID = @ID"

        Using conn As New SqlConnection(_connectionString)
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub InstallmentsAmount_EditValueChanged(sender As Object, e As EventArgs) Handles InstallmentsAmount.EditValueChanged
        Calc()
    End Sub

    Private Sub InstallmentInitialAmount_EditValueChanged(sender As Object, e As EventArgs) Handles InstallmentInitialAmount.EditValueChanged
        Calc()
    End Sub

    Private Sub InstallmentsCount_EditValueChanged(sender As Object, e As EventArgs) Handles InstallmentsCount.EditValueChanged
        Calc()
    End Sub
    Public Function CreatePeriodsDataTable() As DataTable
        ' Create a new DataTable
        Dim periodsTable As New DataTable("Periods")

        ' Define columns
        periodsTable.Columns.Add("ID", GetType(Integer)) ' ID column of type Integer
        periodsTable.Columns.Add("PeriodsAR", GetType(String)) ' PeriodsAR column of type String
        periodsTable.Columns.Add("PeriodsEN", GetType(String)) ' PeriodsEN column of type String

        ' Add data rows to the table
        periodsTable.Rows.Add(1, "يومي", "Daily")   ' (1,يومي,Daily)
        periodsTable.Rows.Add(2, "اسبوعي", "Weekly") ' (2,اسبوعي,Weekly)
        periodsTable.Rows.Add(3, "شهري", "Monthly") ' (3,شهري,Monthly)

        ' Return the filled DataTable
        Return periodsTable
    End Function

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnSattle.Click
        Dim periodsTable As New DataTable("InstallmentsData")
        periodsTable.Columns.Add("ID", GetType(Integer))
        periodsTable.Columns.Add("Amount", GetType(Decimal))
        periodsTable.Columns.Add("DueDate", GetType(Date))
        periodsTable.Columns.Add("Status", GetType(Integer))
        periodsTable.Columns.Add("Note", GetType(String))
        Select Case InstallmentsPeriod.EditValue
            Case 1
                For i = 0 To InstallmentsCount.EditValue - 1
                    If i = 0 Then
                        periodsTable.Rows.Add(i + 1, InstallmentInitialAmount.EditValue, InstallmentDate.DateTime, 0, "")
                    End If
                    periodsTable.Rows.Add(i + 1, InstallmentAmount.EditValue, FirstInstallmentDate.DateTime.AddDays(i), 0, "")
                Next
            Case 2
                For i = 0 To InstallmentsCount.EditValue
                    If i = 0 Then
                        periodsTable.Rows.Add(i + 1, InstallmentInitialAmount.EditValue, InstallmentDate.DateTime, 0, "")
                    End If
                    If i = 1 Then
                        periodsTable.Rows.Add(i + 1, InstallmentAmount.EditValue, FirstInstallmentDate.DateTime, 0, "")
                    End If
                    If i > 1 Then
                        periodsTable.Rows.Add(i + 1, InstallmentAmount.EditValue, CDate(periodsTable.Rows(i - 1).Item("DueDate")).AddDays(7), 0, "")
                    End If

                Next
            Case 3
                For i = 0 To InstallmentsCount.EditValue - 1
                    If i = 0 Then
                        periodsTable.Rows.Add(i + 1, InstallmentInitialAmount.EditValue, InstallmentDate.DateTime, 0, "")
                    End If
                    periodsTable.Rows.Add(i + 1, InstallmentAmount.EditValue, FirstInstallmentDate.DateTime.AddMonths(i), 0, "")
                Next
        End Select
        GridInstallmentSchedule.DataSource = periodsTable
    End Sub

    Private Sub InstallmentsPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles InstallmentsPeriod.EditValueChanged
        Select Case InstallmentsPeriod.EditValue
            Case 1
                FirstInstallmentDate.DateTime = InstallmentDate.DateTime.AddDays(1)
            Case 2
                FirstInstallmentDate.DateTime = InstallmentDate.DateTime.AddDays(7)
            Case 3
                FirstInstallmentDate.DateTime = InstallmentDate.DateTime.AddMonths(1)
        End Select
    End Sub
End Class