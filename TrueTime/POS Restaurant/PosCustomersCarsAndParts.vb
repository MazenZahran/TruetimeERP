Imports System.Data.SqlClient
Imports System.Data

Public Class PosCustomersCarsAndParts
    Private connectionString As String = My.Settings.TrueTimeConnectionString
    Private dataTable As DataTable

    Public Class CustomerCar
        Public Property ID As Integer
        Public Property CarNo As String
        Public Property ChassiNo As String
        Public Property EnginePower As Integer?
        Public Property FuelType As String
        Public Property OwnerID As Integer?
    End Class

    Private Sub PosCustomersCarsAndParts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadCustomersCars()
        Try
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "SELECT ID, CarNo, ChassiNo, EnginePower, FuelType, OwnerID FROM CustomersCars ORDER BY CarNo"
                Using adapter As New SqlDataAdapter(query, connection)
                    dataTable = New DataTable()
                    adapter.Fill(dataTable)
                    GridCustomersCars.DataSource = dataTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        ShowCustomerCarForm()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
        Dim dgv As DataGridView = DirectCast(Me.Controls("GridView1"), DataGridView)
        If dgv.SelectedRows.Count > 0 Then
            Dim selectedRow = dgv.SelectedRows(0)
            Dim carNo As String = selectedRow.Cells("CarNo").Value?.ToString()
            ShowCustomerCarForm(carNo)
        Else
            MessageBox.Show("Please select a car to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)
        Dim dgv As DataGridView = DirectCast(Me.Controls("dgvCustomersCars"), DataGridView)
        If dgv.SelectedRows.Count > 0 Then
            Dim selectedRow = dgv.SelectedRows(0)
            Dim carNo As String = selectedRow.Cells("CarNo").Value?.ToString()

            If MessageBox.Show($"Are you sure you want to delete car {carNo}?", "Confirm Delete",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DeleteCustomerCar(carNo)
            End If
        Else
            MessageBox.Show("Please select a car to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ShowCustomerCarForm(Optional carNo As String = Nothing)
        Using form As New Form With {.Text = If(String.IsNullOrEmpty(carNo), "Add Car", "Edit Car"), .Size = New Size(400, 300)}
            Dim txtCarNo As New TextBox With {.Name = "txtCarNo", .Location = New Point(120, 20), .Width = 200}
            Dim txtChassiNo As New TextBox With {.Name = "txtChassiNo", .Location = New Point(120, 60), .Width = 200}
            Dim txtEnginePower As New TextBox With {.Name = "txtEnginePower", .Location = New Point(120, 100), .Width = 200}
            Dim txtFuelType As New TextBox With {.Name = "txtFuelType", .Location = New Point(120, 140), .Width = 200}
            Dim txtOwnerID As New TextBox With {.Name = "txtOwnerID", .Location = New Point(120, 180), .Width = 200}

            form.Controls.AddRange({
                New Label With {.Text = "Car No:", .Location = New Point(20, 23), .Width = 90},
                txtCarNo,
                New Label With {.Text = "Chassi No:", .Location = New Point(20, 63), .Width = 90},
                txtChassiNo,
                New Label With {.Text = "Engine Power:", .Location = New Point(20, 103), .Width = 90},
                txtEnginePower,
                New Label With {.Text = "Fuel Type:", .Location = New Point(20, 143), .Width = 90},
                txtFuelType,
                New Label With {.Text = "Owner ID:", .Location = New Point(20, 183), .Width = 90},
                txtOwnerID
            })

            Dim btnSave As New Button With {.Text = "Save", .Location = New Point(120, 220), .DialogResult = DialogResult.OK}
            Dim btnCancel As New Button With {.Text = "Cancel", .Location = New Point(210, 220), .DialogResult = DialogResult.Cancel}
            form.Controls.AddRange({btnSave, btnCancel})

            If Not String.IsNullOrEmpty(carNo) Then
                LoadCarData(carNo, txtCarNo, txtChassiNo, txtEnginePower, txtFuelType, txtOwnerID)
                txtCarNo.ReadOnly = True
            End If

            If form.ShowDialog() = DialogResult.OK Then
                SaveCustomerCar(txtCarNo.Text, txtChassiNo.Text, txtEnginePower.Text, txtFuelType.Text, txtOwnerID.Text, String.IsNullOrEmpty(carNo))
            End If
        End Using
    End Sub

    Private Sub LoadCarData(carNo As String, txtCarNo As TextBox, txtChassiNo As TextBox, txtEnginePower As TextBox, txtFuelType As TextBox, txtOwnerID As TextBox)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM CustomersCars WHERE CarNo = @CarNo"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@CarNo", carNo)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            txtCarNo.Text = reader("CarNo").ToString()
                            txtChassiNo.Text = reader("ChassiNo").ToString()
                            txtEnginePower.Text = If(reader("EnginePower") Is DBNull.Value, "", reader("EnginePower").ToString())
                            txtFuelType.Text = reader("FuelType").ToString()
                            txtOwnerID.Text = If(reader("OwnerID") Is DBNull.Value, "", reader("OwnerID").ToString())
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading car data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveCustomerCar(carNo As String, chassiNo As String, enginePower As String, fuelType As String, ownerID As String, isNew As Boolean)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String

                If isNew Then
                    query = "INSERT INTO CustomersCars (CarNo, ChassiNo, EnginePower, FuelType, OwnerID) VALUES (@CarNo, @ChassiNo, @EnginePower, @FuelType, @OwnerID)"
                Else
                    query = "UPDATE CustomersCars SET ChassiNo = @ChassiNo, EnginePower = @EnginePower, FuelType = @FuelType, OwnerID = @OwnerID WHERE CarNo = @CarNo"
                End If

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@CarNo", carNo)
                    command.Parameters.AddWithValue("@ChassiNo", If(String.IsNullOrEmpty(chassiNo), DBNull.Value, chassiNo))
                    command.Parameters.AddWithValue("@EnginePower", If(String.IsNullOrEmpty(enginePower), DBNull.Value, CInt(enginePower)))
                    command.Parameters.AddWithValue("@FuelType", If(String.IsNullOrEmpty(fuelType), DBNull.Value, fuelType))
                    command.Parameters.AddWithValue("@OwnerID", If(String.IsNullOrEmpty(ownerID), DBNull.Value, CInt(ownerID)))

                    command.ExecuteNonQuery()
                    MessageBox.Show("Car saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomersCars()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving car: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteCustomerCar(carNo As String)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "DELETE FROM CustomersCars WHERE CarNo = @CarNo"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@CarNo", carNo)
                    command.ExecuteNonQuery()
                    MessageBox.Show("Car deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadCustomersCars()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting car: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefreshCustomersCars.Click
        LoadCustomersCars()
    End Sub
    Private Sub LoadCustomersCarsParts()
        Try
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "  SELECT C.ID, CarID, I.ItemName, IsNull(R.RefName,'') As RefName , C.ItemNo,CC.CarNo, C.DocName, C.VoucherNo, C.InputDateTime, C.RefNo 
                                          FROM CustomersCarsParts C
                                          Left Join Items I on I.ItemNo=C.ItemNo
                                          Left Join Referencess R on R.RefNo=C.RefNo
                                          Left Join CustomersCars CC on CC.ID = C.CarID
                                          ORDER BY InputDateTime DESC"
                Using adapter As New SqlDataAdapter(query, connection)
                    dataTable = New DataTable()
                    adapter.Fill(dataTable)
                    GridCustomersCarsParts.DataSource = dataTable
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnRefreshCustomersCarsParts_Click(sender As Object, e As EventArgs) Handles BtnRefreshCustomersCarsParts.Click
        LoadCustomersCarsParts()
    End Sub
End Class