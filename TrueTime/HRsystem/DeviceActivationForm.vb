Imports System.Management
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.Configuration
Imports System.Data.SqlClient

Public Class DeviceActivationForm
    Private _deviceKey As String
    Private _deviceName As String
    Private _deviceModel As String
    Private _staticContractKey As String
    Private _lastRequestDetails As String = ""
    Private _lastResponseDetails As String = ""

    Public Sub New()
        InitializeComponent()
        LoadDeviceInfo()
        Me.KeyPreview = True
        AddHandler Me.KeyDown, AddressOf DeviceActivationForm_KeyDown
        Dim MyDBConnection As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
        Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(MyDBConnection)
        DBName.Text = builder.InitialCatalog
    End Sub

    Private Sub LoadDeviceInfo()
        _deviceKey = LogInMenue.GetHWID()
        _deviceName = Environment.MachineName
        _deviceModel = My.Computer.Info.OSFullName
        _staticContractKey = GetStaticContractKeyFromDatabase()

        lblDeviceName.Text = "اسم الجهاز: " & _deviceName
    End Sub

    Private Sub DeviceActivationForm_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.D Then
            ShowDebugDetails()
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ShowDebugDetails()
        Dim debugForm As New Form()
        debugForm.Text = "تفاصيل الطلب والرد - Debug"
        debugForm.Size = New Size(800, 600)
        debugForm.RightToLeft = RightToLeft.Yes
        debugForm.RightToLeftLayout = True
        debugForm.StartPosition = FormStartPosition.CenterParent

        Dim panel As New Panel()
        panel.Dock = DockStyle.Fill
        panel.AutoScroll = True

        Dim txtDetails As New TextBox()
        txtDetails.Multiline = True
        txtDetails.ScrollBars = ScrollBars.Both
        txtDetails.Dock = DockStyle.Fill
        txtDetails.Font = New Font("Consolas", 10)
        txtDetails.ReadOnly = True
        txtDetails.WordWrap = False

        Dim details As New StringBuilder()
        details.AppendLine("========== معلومات الجهاز ==========")
        details.AppendLine("Device Key: " & _deviceKey)
        details.AppendLine("Device Name: " & _deviceName)
        details.AppendLine("Device Model: " & _deviceModel)
        details.AppendLine("Static Key: " & If(String.IsNullOrEmpty(_staticContractKey), "(فارغ)", _staticContractKey))
        details.AppendLine("")
        details.AppendLine("========== آخر طلب  ==========")
        details.AppendLine(If(String.IsNullOrEmpty(_lastRequestDetails), "(لم يتم إرسال أي طلب بعد)", _lastRequestDetails))
        details.AppendLine("")
        details.AppendLine("========== آخر رد  ==========")
        details.AppendLine(If(String.IsNullOrEmpty(_lastResponseDetails), "(لم يتم استلام أي رد بعد)", _lastResponseDetails))
        details.AppendLine("")
        details.AppendLine("========== حالة التفعيل من ق.ب ==========")
        Dim cachedStatus As String = GetDeviceStatusFromDatabase()
        details.AppendLine(If(String.IsNullOrEmpty(cachedStatus), "(-)", cachedStatus))

        txtDetails.Text = details.ToString()

        panel.Controls.Add(txtDetails)
        debugForm.Controls.Add(panel)

        debugForm.ShowDialog(Me)
    End Sub

    Private Async Sub btnRequestActivation_Click(sender As Object, e As EventArgs) Handles btnRequestActivation.Click
        If String.IsNullOrWhiteSpace(txtNotes.Text) Then
            MessageBox.Show("يجب إدخال ملاحظة لطلب التفعيل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNotes.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtRequestedBy.Text) Then
            MessageBox.Show("يجب إدخال اسمك لطلب التفعيل", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNotes.Focus()
            Return
        End If

        Try
            btnRequestActivation.Enabled = False
            btnCheckActivation.Enabled = False
            lblStatus.Text = "جاري إرسال الطلب..."

            Dim result As String = Await SubmitDeviceRequest(_deviceKey, _deviceName, _deviceModel, txtNotes.Text, txtRequestedBy.Text)
            _lastResponseDetails = result

            Dim jsonResult = JObject.Parse(result)
            Dim message As String = jsonResult("message")?.ToString()

            If String.IsNullOrEmpty(message) Then
                message = "تأكد من الإتصال بالإنترنت ."
            End If

            MessageBox.Show(message, "نتيجة الطلب", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblStatus.Text = "تم إرسال الطلب بنجاح"

        Catch ex As Exception
            MessageBox.Show("خطأ في إرسال الطلب: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblStatus.Text = "فشل إرسال الطلب"
        Finally
            btnRequestActivation.Enabled = True
            btnCheckActivation.Enabled = True
        End Try
    End Sub

    Private Async Sub btnCheckActivation_Click(sender As Object, e As EventArgs) Handles btnCheckActivation.Click
        Try
            btnRequestActivation.Enabled = False
            btnCheckActivation.Enabled = False
            lblStatus.Text = "جاري فحص حالة التفعيل..."

            Dim result As String = Await CheckDeviceStatus()
            _lastResponseDetails = result

            Dim json = JObject.Parse(result)
            Dim exists As Boolean = json("exists")
            Dim isActive As Boolean = json("isActive")
            Dim deviceType As String = json("deviceType")
            Dim deviceRepeatCount As Integer = If(json("deviceRepeatCount") IsNot Nothing, CInt(json("deviceRepeatCount")), 0)
            Dim IsNew As Integer = GetIsNewFromDatabase()

            If deviceRepeatCount >= 1 AndAlso deviceType = "multi" AndAlso String.IsNullOrEmpty(_staticContractKey) Then
                Dim contractKey As String = InputBox("هذا الجهاز مُسجّل لأكثر من نسخة." & vbCrLf & "الرجاء إدخال الكود الخاص بك:", "إدخال الكود", "")

                If String.IsNullOrWhiteSpace(contractKey) Then

                    Return
                End If

                _staticContractKey = contractKey

                result = Await CheckDeviceStatus()
                _lastResponseDetails = result
                json = JObject.Parse(result)
                exists = json("exists")
                isActive = json("isActive")

                If Not (exists AndAlso isActive) Then
                    _staticContractKey = ""
                    MessageBox.Show("الكود المُدخل غير صحيح أو الجهاز غير مُفعّل. يرجى التحقق والمحاولة مجددًا.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lblStatus.Text = "كود خاطئ"
                    Return
                End If

                SaveStaticContractKeyToDatabase(contractKey)

            ElseIf deviceRepeatCount > 1 AndAlso Not String.IsNullOrEmpty(_staticContractKey) Then
                result = Await CheckDeviceStatus()
                _lastResponseDetails = result
                json = JObject.Parse(result)
                exists = json("exists")
                isActive = json("isActive")

            ElseIf deviceRepeatCount = 0 Then
                MessageBox.Show("الجهاز غير مُفعّل. يرجى طلب التفعيل أولاً.", "غير مفعل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblStatus.Text = "الجهاز غير مفعل"
                ResetModule()
                Return
            End If

            If exists AndAlso isActive Then
                Dim moduleBodyValue As New SubServices()

                SaveDeviceStatusToDatabase(result)
                SaveIsNewToDatabase(1)
                moduleBodyValue.UpdateModuleBodyValue()

                MessageBox.Show("تم التفعيل بنجاح.", "تم التفعيل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                Dim message As String = If(json("message") IsNot Nothing, json("message").ToString(), "الجهاز غير مفعل")
                MessageBox.Show(message, "غير مفعل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblStatus.Text = "الجهاز غير مفعل"
            End If

        Catch ex As Exception
            Dim cachedStatus As String = GetDeviceStatusFromDatabase()
            If Not String.IsNullOrEmpty(cachedStatus) Then
                Try
                    Dim json = JObject.Parse(cachedStatus)
                    Dim exists As Boolean = json("exists")
                    Dim isActive As Boolean = json("isActive")

                    If exists AndAlso isActive Then
                        MessageBox.Show("الجهاز مفعل.", "مفعل", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("الجهاز غير مفعل. يرجى الاتصال بالإنترنت للتحقق.", "غير مفعل", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        lblStatus.Text = "الجهاز غير مفعل"
                    End If
                Catch
                    MessageBox.Show("خطأ في فحص حالة التفعيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    lblStatus.Text = "فشل فحص التفعيل"
                End Try
            Else
                MessageBox.Show("خطأ في فحص حالة التفعيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblStatus.Text = "فشل فحص التفعيل"
            End If
        Finally
            btnRequestActivation.Enabled = True
            btnCheckActivation.Enabled = True
        End Try
    End Sub

    Public Async Function CheckDeviceStatus() As Task(Of String)


        Try
            Dim apiUrl As String = GlobalVariables.ttsSystemsAPI & "Access/CheckDeviceStatus"
            Dim jsonBody As String = "{""uniqueDeviceKey"": """ & _deviceKey & """, ""StaticContractKey"": """ & _staticContractKey & """}"
            _lastRequestDetails = "Body: " & jsonBody

            Using client As New HttpClient()
                Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                Dim result As String = Await response.Content.ReadAsStringAsync()

                If Not String.IsNullOrEmpty(result) AndAlso Not result.Contains("""error""") Then
                    SaveDeviceStatusToDatabase(result)
                End If

                Return result
            End Using

        Catch ex As Exception
            Return "{""error"":""" & ex.Message & """}"
        End Try
    End Function

    Private Async Function SubmitDeviceRequest(uniqueDeviceKey As String, deviceName As String, deviceModel As String, userNotes As String, RequestedBy As String) As Task(Of String)
        Try
            Dim apiUrl As String = GlobalVariables.ttsSystemsAPI & "Access/SubmitDeviceRequest"


            Dim jsonBody As String = "{
                ""uniqueDeviceKey"": """ & uniqueDeviceKey & """,
                ""deviceName"": """ & deviceName & """,
                ""deviceModel"": """ & deviceModel & """,
                ""userNotes"": """ & userNotes & """,
                ""RequestedBy"": """ & RequestedBy & """
            }"
            _lastRequestDetails = "Body: " & jsonBody

            Using client As New HttpClient()
                Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                Return Await response.Content.ReadAsStringAsync()
            End Using

        Catch ex As Exception
            Return "{""error"":""" & ex.Message & """}"
        End Try
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub SaveDeviceStatusToDatabase(jsonStatus As String)
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Module WHERE Text = @text", con)
                checkCmd.Parameters.AddWithValue("@text", "DeviceActivationStatus")
                Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

                Dim query As String
                If exists > 0 Then
                    query = "UPDATE Module SET Value = ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value), UpdatedAt = @updatedAt WHERE Text = @text"
                Else
                    query = "INSERT INTO Module (Text, Value, CreatedAt, UpdatedAt) VALUES (@text, ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value), @createdAt, @updatedAt)"
                End If

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@value", jsonStatus)
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                    cmd.Parameters.AddWithValue("@text", "DeviceActivationStatus")
                    If exists = 0 Then
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error saving device status: " & ex.Message)
        End Try
    End Sub

    Public Function GetDeviceStatusFromDatabase() As String
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Using cmd As New SqlCommand("SELECT CONVERT(NVARCHAR(MAX), DECRYPTBYPASSPHRASE('TTsAaBb2023', [Value])) FROM [dbo].[Module] WHERE [Text] = 'DeviceActivationStatus'", con)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving device status: " & ex.Message)
        End Try

        Return Nothing
    End Function
    Public Function GetStaticContractKeyFromDatabase() As String
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Using cmd As New SqlCommand("SELECT CONVERT(NVARCHAR(MAX), DECRYPTBYPASSPHRASE('TTsAaBb2023', [Value])) FROM [dbo].[Module] WHERE [Text] = 'StaticContractKey'", con)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return result.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving device status: " & ex.Message)
        End Try

        Return Nothing
    End Function

    Public Function GetIsNewFromDatabase() As Integer
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Using cmd As New SqlCommand("SELECT CONVERT(NVARCHAR(MAX), [Value]) FROM [dbo].[Module] WHERE [Text] = 'IsNew'", con)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Dim value As String = result.ToString()
                        If Not String.IsNullOrEmpty(value) Then
                            Return CInt(value)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error retrieving IsNew: " & ex.Message)
        End Try

        Return 0 ' القيمة الافتراضية
    End Function

    Public Sub SaveStaticContractKeyToDatabase(contractKey As String)
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Module WHERE Text = @text", con)
                checkCmd.Parameters.AddWithValue("@text", "StaticContractKey")
                Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

                Dim query As String
                If exists > 0 Then
                    query = "UPDATE Module SET Value = ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value), UpdatedAt = @updatedAt WHERE Text = @text"
                Else
                    query = "INSERT INTO Module (Text, Value, CreatedAt, UpdatedAt) VALUES (@text, ENCRYPTBYPASSPHRASE('TTsAaBb2023', @value), @createdAt, @updatedAt)"
                End If


                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@value", contractKey)
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                    cmd.Parameters.AddWithValue("@text", "StaticContractKey")
                    If exists = 0 Then
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error saving StaticContractKey: " & ex.Message)
            MessageBox.Show("خطأ في حفظ رمز العقد: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SaveIsNewToDatabase(isNewValue As Integer)
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Module WHERE Text = @text", con)
                checkCmd.Parameters.AddWithValue("@text", "IsNew")
                Dim exists As Integer = CInt(checkCmd.ExecuteScalar())

                Dim query As String
                If exists > 0 Then
                    query = "UPDATE Module SET Value = @value, UpdatedAt = @updatedAt WHERE Text = @text"
                Else
                    query = "INSERT INTO Module (Text, Value, CreatedAt, UpdatedAt) VALUES (@text, @value, @createdAt, @updatedAt)"
                End If

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@value", isNewValue.ToString())
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now)
                    cmd.Parameters.AddWithValue("@text", "IsNew")
                    If exists = 0 Then
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error saving IsNew: " & ex.Message)
            MessageBox.Show("خطأ في حفظ حالة التفعيل: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ResetModule()
        Try
            Dim connString As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString

            Using con As New SqlConnection(connString)
                con.Open()

                Dim query As String = "UPDATE Module " &
                                  "SET Value = NULL " &
                                  "WHERE (Text = 'Body' OR Text = 'DeviceActivationStatus' OR Text = 'StaticContractKey' OR Text = 'IsNew') "

                Using cmd As New SqlCommand(query, con)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error saving: " & ex.Message)
            MessageBox.Show("خطأ في الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ResetModule()
    End Sub
End Class