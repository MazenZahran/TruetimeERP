Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class CashCustomerDetails
    Private connectionString As String = My.Settings.TrueTimeConnectionString
    Private isNewCustomer As Boolean = True
    Public customerId As Integer = 0
    Public customerName As String
    Private creditRefNo As Integer = 0

    Public Property Mode As CustomerMode = CustomerMode.Cash
    Public isEditMode As Boolean = False

    '-- Common Methods ----
    Private Sub SearchCity_BeforePopup(sender As Object, e As EventArgs) Handles SearchCity.BeforePopup
        SearchCity.Properties.DataSource = GetRefCities()
    End Sub
    Private Sub SearchCity_AddNewValue(sender As Object, e As EventArgs) Handles SearchCity.AddNewValue
        My.Forms.AccountingLists.NavigationPane1.SelectedPage = My.Forms.AccountingLists.Cities
        AccountingLists.ShowDialog()
    End Sub
    Private Sub SearchCity_EditValueChanged(sender As Object, e As EventArgs)
        LoadAreasByCityId()
    End Sub
    Private Sub LoadAreasByCityId()
        Try
            If SearchCity.EditValue Is Nothing Then
                SearchArea.Properties.DataSource = Nothing
                Return
            End If

            Dim cityId As Integer = Convert.ToInt32(SearchCity.EditValue)

            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim command As New SqlCommand("SELECT AreaId, AreaName FROM Areas WHERE CityId = @CityId", connection)
                command.Parameters.AddWithValue("@CityId", cityId)
                Dim adapter As New SqlDataAdapter(command)
                Dim dataTable As New DataTable()
                adapter.Fill(dataTable)
                SearchArea.Properties.DataSource = dataTable
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading areas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GenerateNewCustomerNumber()
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim command As New SqlCommand("SELECT ISNULL(MAX(CustomerNo), 0) + 1 FROM CashCustomer", connection)
                Dim newNumber As Integer = Convert.ToInt32(command.ExecuteScalar())
                TextNo.Text = newNumber.ToString()

                ' Generate a code based on customer number (e.g., C00001)
                TextCode.Text = $"C{newNumber.ToString().PadLeft(5, "0"c)}"
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating customer number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GenerateNewCreditNumber()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("
            SELECT ISNULL(MAX(RefNo),0)+1 
            FROM Referencess 
            WHERE RefType IN (2,99)", con)

            Dim num As Integer = cmd.ExecuteScalar()
            TextNo.Text = num.ToString()
            TextCode.Text = "CR" & num.ToString().PadLeft(5, "0"c)
        End Using
    End Sub

    '--- Cash Customer Methods ----
    Private Sub CashCustomerDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load cities for the SearchCity control

        ' Check if we're editing an existing customer or creating a new one
        If Mode = CustomerMode.Cash Then
            Me.Text = "إضافة زبون نقدي"
            Me.Text = "بيانات الزبون النقدي"
            GenerateNewCustomerNumber()
            SearchCity.Properties.DataSource = GetRefCities()

        Else
            Me.Text = "إضافة ذمة "
            Me.Text = "بيانات الذمة"
            LayoutControlItem10.Text = "اسم المرجع"
            LayoutControlItem6.Text = "رقم الحساب"
            GenerateNewCreditNumber()

        End If
    End Sub
    Private Sub CashCustomerDetails_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Set focus after the form is fully shown and all controls are ready
        TextName.Focus()
        TextName.Select()
    End Sub
    Public Sub LoadCustomerById(customerId As Integer)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim sql As String =
                "SELECT CustomerID, CustomerCode, CustomerNo, CustomerName, Mobile, Mobile2, " &
                "ISNULL(CityID,0) AS CityID, ISNULL(AreaID,0) AS AreaID, Address, Notes " &
                "FROM CashCustomer WHERE CustomerID = @CustomerID"

                Using cmd As New SqlCommand(sql, connection)
                    cmd.Parameters.AddWithValue("@CustomerID", customerId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            TextCode.Text = reader("CustomerCode").ToString()
                            TextNo.Text = reader("CustomerNo").ToString()
                            TextName.Text = reader("CustomerName").ToString()
                            TextMobile.Text = reader("Mobile").ToString()
                            TextMobile2.Text = reader("Mobile2").ToString()
                            SearchCity.EditValue = Convert.ToInt32(reader("CityID"))
                            SearchArea.EditValue = Convert.ToInt32(reader("AreaID"))
                            TextAdress.Text = reader("Address").ToString()
                            MemoNotes.Text = reader("Notes").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading customer: {ex.Message}")
        End Try
    End Sub
    Private Sub UpdateCashCustomer()
        Try
            If Not ValidateInputs() Then Return

            ' Ensure we have a valid ID to update
            Dim idToUpdate As Integer
            If Tag Is Nothing OrElse Not Integer.TryParse(Tag.ToString(), idToUpdate) Then
                MessageBox.Show("Customer ID is invalid, cannot update.", "Error")
                Return
            End If

            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim sql As String =
                "UPDATE CashCustomer SET " &
                "CustomerCode=@CustomerCode, CustomerNo=@CustomerNo, CustomerName=@CustomerName, " &
                "Mobile=@Mobile, Mobile2=@Mobile2, CityID=@CityID, AreaID=@AreaID, Address=@Address, Notes=@Notes " &
                "WHERE CustomerID=@CustomerID"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@CustomerCode", TextCode.Text)
                    cmd.Parameters.AddWithValue("@CustomerNo", Convert.ToInt32(TextNo.Text))
                    cmd.Parameters.AddWithValue("@CustomerName", TextName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Mobile", TextMobile.Text.Trim())
                    cmd.Parameters.AddWithValue("@Mobile2", TextMobile2.Text.Trim())
                    cmd.Parameters.AddWithValue("@CityID", If(SearchCity.EditValue Is Nothing, DBNull.Value, SearchCity.EditValue))
                    cmd.Parameters.AddWithValue("@AreaID", If(SearchArea.EditValue Is Nothing, DBNull.Value, SearchArea.EditValue))
                    cmd.Parameters.AddWithValue("@Address", TextAdress.Text.Trim())
                    cmd.Parameters.AddWithValue("@Notes", MemoNotes.Text.Trim())
                    cmd.Parameters.AddWithValue("@CustomerID", idToUpdate)

                    Dim rowsAffected = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("تم تحديث بيانات الزبون بنجاح", "نجاح")
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("لم يتم العثور على الزبون", "خطأ")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error updating customer: {ex.Message}", "Error")
        End Try
    End Sub
    Private Sub CreateCashCustomer()
        Try
            If Not ValidateInputs() Then
                Return
            End If

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim sql As String =
                    "INSERT INTO CashCustomer (CustomerCode, CustomerNo, CustomerName, " &
                    "Mobile, Mobile2, CityID, AreaID, Address, Notes, CreatedDate) " &
                    "VALUES (@CustomerCode, @CustomerNo, @CustomerName, @Mobile, @Mobile2, " &
                    "@CityID, @AreaID, @Address, @Notes, @CreatedDate); " &
                    "SELECT SCOPE_IDENTITY()"

                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@CustomerCode", TextCode.Text)
                    command.Parameters.AddWithValue("@CustomerNo", Convert.ToInt32(TextNo.Text))
                    command.Parameters.AddWithValue("@CustomerName", TextName.Text)
                    command.Parameters.AddWithValue("@Mobile", TextMobile.Text)
                    command.Parameters.AddWithValue("@Mobile2", TextMobile2.Text)
                    command.Parameters.AddWithValue("@CityID", If(SearchCity.EditValue Is Nothing, DBNull.Value, SearchCity.EditValue))
                    command.Parameters.AddWithValue("@AreaID", If(SearchArea.EditValue Is Nothing, DBNull.Value, SearchArea.EditValue))
                    command.Parameters.AddWithValue("@Address", TextAdress.Text)
                    command.Parameters.AddWithValue("@Notes", MemoNotes.Text)
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now)

                    Dim newCustomerId As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Tag = newCustomerId.ToString()
                    customerId = newCustomerId
                    customerName = TextName.Text
                    isNewCustomer = False
                End Using
            End Using
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Error creating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '--- Credit Customer Methods ----

    Public Sub LoadCustomerForEdit(refNo As Integer, name As String, mobile As String, accId As Integer?)
        creditRefNo = refNo ' Store RefNo for update
        TextNo.Text = refNo.ToString()
        TextName.Text = name
        TextMobile.Text = mobile
        TextMobile2.Text = "" ' if needed

        If accId.HasValue Then
            TextAdress.Text = accId.Value.ToString()
        End If

        isEditMode = True
        isNewCustomer = False
    End Sub
    Private Sub CreateCreditCustomer()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Get last RefNo safely
                Dim lastRefNo As Integer = 0
                Using cmdLast As New SqlCommand("SELECT MAX(RefNo) FROM Referencess WHERE RefType = 2", con)
                    Dim result = cmdLast.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Integer.TryParse(result.ToString(), lastRefNo)
                    End If
                End Using

                Dim newRefNo As Integer = lastRefNo + 1
                TextNo.Text = newRefNo.ToString()

                ' Prepare AccID safely
                Dim accIDValue As Object = DBNull.Value
                Dim accID As Integer
                If Integer.TryParse(TextAdress.Text, accID) Then
                    accIDValue = accID
                End If

                ' Insert customer
                Dim sql As String = "
                INSERT INTO Referencess
                (RefName, RefNo, RefType, RefMobile, RefPhone, RefAccID, Active)
                VALUES
                (@Name, @No, 2, @Mobile, @Phone, @AccID, 1);
                SELECT SCOPE_IDENTITY()"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Name", TextName.Text.Trim())
                    cmd.Parameters.AddWithValue("@No", newRefNo)
                    cmd.Parameters.AddWithValue("@Mobile", TextMobile.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", TextMobile2.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccID", accIDValue)

                    Dim idResult = cmd.ExecuteScalar()
                    If idResult IsNot Nothing AndAlso idResult IsNot DBNull.Value Then
                        customerId = Convert.ToInt32(idResult)
                        customerName = TextName.Text.Trim()
                    End If

                    Me.DialogResult = DialogResult.OK
                    Me.Close()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("CreateCreditCustomer Error: " & ex.ToString())
        End Try
    End Sub
    Private Sub UpdateCreditCustomer()
        Try

            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Prepare AccID safely
                Dim accID As Integer = 0
                If Not String.IsNullOrWhiteSpace(TextAdress.Text) Then
                    Integer.TryParse(TextAdress.Text.Trim(), accID)
                End If

                Dim accIDValue As Object = accID

                Dim sql As String =
                "UPDATE Referencess SET
                    RefName = @Name,
                    RefMobile = @Mobile,
                    RefPhone = @Phone,
                    RefAccID = @AccID
                 WHERE RefNo = @RefNo AND RefType = 2"

                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Name", TextName.Text.Trim())
                    cmd.Parameters.AddWithValue("@Mobile", TextMobile.Text.Trim())
                    cmd.Parameters.AddWithValue("@Phone", TextMobile2.Text.Trim())
                    cmd.Parameters.AddWithValue("@AccID", accIDValue)
                    cmd.Parameters.AddWithValue("@RefNo", creditRefNo)


                    Dim rows = cmd.ExecuteNonQuery()


                    If rows > 0 Then
                        customerId = creditRefNo
                        customerName = TextName.Text.Trim()


                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        XtraMessageBox.Show("لم يتم العثور على الزبون الآجل لتحديثه", "خطأ")
                    End If
                End Using
            End Using

        Catch ex As Exception
            XtraMessageBox.Show("Error updating customer: " & ex.Message)
        End Try
    End Sub
    Private Sub DeleteCustomer()
        Try
            If String.IsNullOrEmpty(Tag?.ToString()) Then
                MessageBox.Show("الرجاء تحديد الزبون للحذف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("هل أنت متأكد من حذف هذا الزبون النقدي؟", "تأكيد الحذف",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    ' Check if the customer is referenced in other tables first
                    ' This is a basic example - adapt for your actual schema
                    Dim checkSql As String = "SELECT COUNT(*) FROM Journal WHERE CashCustomerId = @CashCustomerId"

                    Using checkCommand As New SqlCommand(checkSql, connection)
                        checkCommand.Parameters.AddWithValue("@CashCustomerId", Convert.ToInt32(Tag))
                        Dim referencesCount As Integer = Convert.ToInt32(checkCommand.ExecuteScalar())

                        If referencesCount > 0 Then
                            MessageBox.Show("لا يمكن حذف هذا الزبون لأنه مرتبط ببيانات أخرى", "تنبيه",
                                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Define the SQL command for delete
                    Dim sql As String = "DELETE FROM CashCustomer WHERE CustomerID = @CustomerID"

                    Using command As New SqlCommand(sql, connection)
                        command.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(Tag))

                        ' Execute the delete
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("تم حذف الزبون بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ClearForm()
                            GenerateNewCustomerNumber()
                            isNewCustomer = True
                        Else
                            MessageBox.Show("لم يتم العثور على الزبون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '-- Validation and Utility Methods ----
    Private Function ValidateInputs() As Boolean
        ' Basic validation for required fields
        If String.IsNullOrEmpty(TextName.Text.Trim()) Then
            MessageBox.Show("الرجاء إدخال اسم الزبون", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextName.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(TextMobile.Text.Trim()) Then
            MessageBox.Show("الرجاء إدخال رقم الموبايل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextMobile.Focus()
            Return False
        End If

        ' Check if mobile number already exists
        Dim currentCustomerId As Integer? = Nothing
        If Not isNewCustomer AndAlso Not String.IsNullOrEmpty(Tag?.ToString()) Then
            currentCustomerId = Convert.ToInt32(Tag)
        End If

        If IsMobileExists(TextMobile.Text.Trim(), currentCustomerId) Then
            MessageBox.Show("رقم الموبايل موجود بالفعل لزبون آخر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextMobile.Focus()
            Return False
        End If

        Return True
    End Function
    Private Function IsMobileExists(mobile As String, currentCustomerId As Integer?) As Boolean
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim sql As String = "SELECT COUNT(*) FROM CashCustomer WHERE Mobile = @Mobile"

                ' Exclude current customer when updating
                If currentCustomerId.HasValue Then
                    sql += " AND CustomerID <> @CustomerID"
                End If

                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@Mobile", mobile)

                    If currentCustomerId.HasValue Then
                        command.Parameters.AddWithValue("@CustomerID", currentCustomerId.Value)
                    End If

                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error checking mobile number: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Sub ClearForm()
        TextCode.Text = ""
        TextNo.Text = ""
        TextName.Text = ""
        TextMobile.Text = ""
        TextMobile2.Text = ""
        SearchCity.EditValue = Nothing
        SearchArea.EditValue = Nothing
        TextAdress.Text = ""
        MemoNotes.Text = ""
        Tag = Nothing

        ' Set focus to TextName after clearing
        TextName.Focus()
        TextName.Select()
    End Sub
    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If Mode = CustomerMode.Cash Then
            If isEditMode Then

                isNewCustomer = False
                UpdateCashCustomer()
                isEditMode = False
            Else
                CreateCashCustomer()
            End If

        Else

            If isEditMode Then
                isNewCustomer = False
                UpdateCreditCustomer()
                isEditMode = False
            Else
                CreateCreditCustomer()
            End If

        End If
    End Sub

End Class
Public Enum CustomerMode
    Cash
    Credit
End Enum
