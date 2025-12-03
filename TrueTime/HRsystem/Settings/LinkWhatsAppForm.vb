Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports System.Threading.Tasks
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Public Class LinkWhatsAppForm
    Private accountId As String
    Private baseURL As String
    Private isInitializing As Boolean = False

    Private Sub LinkWhatsAppForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ShowLoadingStatus()

            checkTimer.Interval = 5000
            checkTimer.Enabled = False

            InitializeConnection()

        Catch ex As Exception
            XtraMessageBox.Show("خطأ في تحميل النموذج: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub InitializeConnection()
        If isInitializing Then Return
        isInitializing = True

        Try
            accountId = Await Task.Run(Function() GetAccountIdFromDatabase())

            If String.IsNullOrEmpty(accountId) Then
                lblStatus.Text = "⚠️ لم يتم العثور على المعرف"
                lblStatus.Appearance.ForeColor = Color.Red
                btnConnect.Enabled = False
                Return
            End If

            baseURL = Await Task.Run(Function() GetWhatsAppBaseURL())

            If String.IsNullOrEmpty(baseURL) Then
                lblStatus.Text = "⚠️ لم يتم العثور على الرابط "
                lblStatus.Appearance.ForeColor = Color.Red
                btnConnect.Enabled = False
                Return
            End If

            CheckCurrentStatus()

        Catch ex As Exception
            lblStatus.Text = "❌ خطأ في التهيئة"
            lblStatus.Appearance.ForeColor = Color.Red
            XtraMessageBox.Show("خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            isInitializing = False
        End Try
    End Sub

    Private Sub ShowLoadingStatus()
        lblStatus.Text = "⏳ جاري التحميل..."
        lblStatus.Appearance.ForeColor = Color.Gray
        lblPhoneNumber.Visible = False
        picQRCode.Visible = False
        lblQRInstruction.Visible = False
        btnConnect.Enabled = False
        btnRetry.Enabled = False
        btnDisconnect.Enabled = False
    End Sub

    Private Async Sub CheckCurrentStatus()
        Try
            lblStatus.Text = "🔍 جاري التحقق من الحالة..."
            lblStatus.Appearance.ForeColor = Color.Blue

            Dim result = Await GetStatus(accountId)

            If result IsNot Nothing Then
                Select Case result.status?.ToLower()
                    Case "open"
                        ShowConnectedStatus(result.phoneNumber)

                    Case "connecting"
                        lblStatus.Text = "⏳ جاري الاتصال... يرجى مسح رمز QR"
                        lblStatus.Appearance.ForeColor = Color.Orange

                        If Not String.IsNullOrEmpty(result.qrCode) Then
                            ShowQRCode(result.qrCode)
                        End If

                        btnConnect.Enabled = False
                        btnRetry.Enabled = True
                        checkTimer.Enabled = True

                    Case Else
                        ShowDisconnectedStatus()
                End Select
            Else
                ShowDisconnectedStatus()
            End If

        Catch ex As Exception
            lblStatus.Text = "❌ خطأ في الاتصال بالخادم"
            lblStatus.Appearance.ForeColor = Color.Red
            btnConnect.Enabled = True
        End Try
    End Sub

    Private Async Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            btnConnect.Enabled = False

            lblStatus.Text = "⚙️ جاري بدء الاتصال..."
            lblStatus.Appearance.ForeColor = Color.Blue

            Dim result = Await ConnectWhatsApp(accountId)

            If result IsNot Nothing AndAlso result.success Then
                checkTimer.Enabled = True
                lblStatus.Text = "⏳ جاري الاتصال... يرجى مسح رمز QR"
                lblStatus.Appearance.ForeColor = Color.Orange
                btnRetry.Enabled = True

                If Not String.IsNullOrEmpty(result.qrCode) Then
                    ShowQRCode(result.qrCode)
                Else
                    Await Task.Delay(1000)
                    Dim statusResult = Await GetStatus(accountId)
                    If statusResult IsNot Nothing AndAlso Not String.IsNullOrEmpty(statusResult.qrCode) Then
                        ShowQRCode(statusResult.qrCode)
                    End If
                End If
            Else
                Dim errorMsg As String = If(result?.message, "فشل في بدء عملية الاتصال")
                lblStatus.Text = "❌ " & errorMsg
                lblStatus.Appearance.ForeColor = Color.Red
                btnConnect.Enabled = True
                XtraMessageBox.Show(errorMsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            lblStatus.Text = "❌ خطأ في الاتصال"
            lblStatus.Appearance.ForeColor = Color.Red
            btnConnect.Enabled = True
            XtraMessageBox.Show("خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub checkTimer_Tick(sender As Object, e As EventArgs) Handles checkTimer.Tick
        Try
            checkTimer.Enabled = False

            Dim result = Await GetStatus(accountId)

            If result Is Nothing Then
                lblStatus.Text = "⚠️ لا يوجد اتصال بالخادم"
                lblStatus.Appearance.ForeColor = Color.Orange
                checkTimer.Enabled = True
                Return
            End If

            Console.WriteLine($"Status received: {result.status}, Phone: {result.phoneNumber}")

            Select Case result.status?.ToLower()
                Case "open"
                    ShowConnectedStatus(result.phoneNumber)

                    Try
                        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
                    Catch
                    End Try

                    XtraMessageBox.Show("تم الاتصال بنجاح! ✓" & vbCrLf & "رقم الهاتف: " & result.phoneNumber,
                                      "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit Sub
                Case "connecting"
                    lblStatus.Text = "⏳ جاري الاتصال... يرجى مسح رمز QR"
                    lblStatus.Appearance.ForeColor = Color.Orange

                    If Not String.IsNullOrEmpty(result.qrCode) Then
                        ShowQRCode(result.qrCode)
                    End If

                    checkTimer.Enabled = True

                Case "timeout", "qr_timeout"
                    lblStatus.Text = "⏱️ انتهت صلاحية رمز QR"
                    lblStatus.Appearance.ForeColor = Color.Orange
                    XtraMessageBox.Show("انتهت صلاحية رمز QR. الرجاء إعادة المحاولة.",
                                      "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ShowDisconnectedStatus()

                Case "disconnected"
                    lblStatus.Text = "❌ تم فصل الاتصال"
                    lblStatus.Appearance.ForeColor = Color.Red
                    ShowDisconnectedStatus()

                Case "close"
                    If Not String.IsNullOrEmpty(result.phoneNumber) Then
                        Console.WriteLine("Status is 'close' but phoneNumber exists - treating as connected")
                        ShowConnectedStatus(result.phoneNumber)

                        picQRCode.Visible = False
                        lblQRInstruction.Visible = False

                        Exit Sub
                    Else
                        lblStatus.Text = "❌ تم فصل الاتصال"
                        lblStatus.Appearance.ForeColor = Color.Red
                        ShowDisconnectedStatus()
                    End If

                Case Else
                    lblStatus.Text = "⚠️ حالة غير معروفة: " & result.status
                    lblStatus.Appearance.ForeColor = Color.Orange
                    checkTimer.Enabled = True
            End Select

        Catch ex As Exception
            lblStatus.Text = "⚠️ خطأ في التحقق"
            lblStatus.Appearance.ForeColor = Color.Orange
            checkTimer.Enabled = True
        End Try
    End Sub

    Private Async Sub btnRetry_Click(sender As Object, e As EventArgs) Handles btnRetry.Click
        Try
            btnRetry.Enabled = False

            lblStatus.Text = "🔄 جاري إعادة تشغيل الاتصال..."
            lblStatus.Appearance.ForeColor = Color.Blue

            Dim result = Await RestartConnection(accountId)

            If result IsNot Nothing AndAlso result.success Then
                lblStatus.Text = "⏳ جاري الاتصال... يرجى مسح رمز QR"
                lblStatus.Appearance.ForeColor = Color.Orange
                checkTimer.Enabled = True
                btnRetry.Enabled = True

                Await Task.Delay(1000)
                Dim statusResult = Await GetStatus(accountId)
                If statusResult IsNot Nothing AndAlso Not String.IsNullOrEmpty(statusResult.qrCode) Then
                    ShowQRCode(statusResult.qrCode)
                End If
            Else
                Dim errorMsg As String = If(result?.message, "فشل في إعادة تشغيل الاتصال")
                lblStatus.Text = "❌ " & errorMsg
                lblStatus.Appearance.ForeColor = Color.Red
                btnRetry.Enabled = True
                XtraMessageBox.Show(errorMsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            lblStatus.Text = "❌ خطأ في إعادة المحاولة"
            lblStatus.Appearance.ForeColor = Color.Red
            btnRetry.Enabled = True
            XtraMessageBox.Show("خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Dim dialogResult = XtraMessageBox.Show(
            "هل أنت متأكد من قطع الاتصال؟" & vbCrLf & "سيتم فصل الواتساب من هذا الجهاز نهائياً!",
            "تأكيد",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If dialogResult = DialogResult.Yes Then
            Try
                btnDisconnect.Enabled = False

                lblStatus.Text = "🔌 جاري قطع الاتصال..."
                lblStatus.Appearance.ForeColor = Color.Orange

                Dim result = Await LogoutWhatsApp(accountId)

                If result IsNot Nothing AndAlso result.success Then
                    lblStatus.Text = "✅ تم قطع الاتصال بنجاح"
                    lblStatus.Appearance.ForeColor = Color.Green
                    ShowDisconnectedStatus()
                    XtraMessageBox.Show("تم قطع الاتصال بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim errorMsg As String = If(result?.message, "فشل في قطع الاتصال")
                    lblStatus.Text = "❌ " & errorMsg
                    lblStatus.Appearance.ForeColor = Color.Red
                    btnDisconnect.Enabled = True
                    XtraMessageBox.Show(errorMsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                lblStatus.Text = "❌ خطأ في قطع الاتصال"
                lblStatus.Appearance.ForeColor = Color.Red
                btnDisconnect.Enabled = True
                XtraMessageBox.Show("خطأ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Async Function ConnectWhatsApp(accountId As String) As Task(Of ConnectResponse)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)
                Dim url As String = $"{baseURL}/connect/{accountId}"
                Dim content As New StringContent("{}", Encoding.UTF8, "application/json")
                Dim response = Await client.PostAsync(url, content)
                Dim jsonResult = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of ConnectResponse)(jsonResult)
            End Using
        Catch ex As Exception
            Return New ConnectResponse With {
                .success = False,
                .message = "خطأ في الاتصال: " & ex.Message
            }
        End Try
    End Function

    Private Async Function GetStatus(accountId As String) As Task(Of StatusResponse)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(15)
                Dim url As String = $"{baseURL}/status/{accountId}"
                Dim response = Await client.GetAsync(url)
                Dim jsonResult = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of StatusResponse)(jsonResult)
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Async Function RestartConnection(accountId As String) As Task(Of ApiResponse)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)
                Dim url As String = $"{baseURL}/restart/{accountId}"
                Dim response = Await client.PostAsync(url, Nothing)
                Dim jsonResult = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of ApiResponse)(jsonResult)
            End Using
        Catch ex As Exception
            Return New ApiResponse With {
                .success = False,
                .message = "خطأ: " & ex.Message
            }
        End Try
    End Function

    Private Async Function LogoutWhatsApp(accountId As String) As Task(Of ApiResponse)
        Try
            Using client As New HttpClient()
                client.Timeout = TimeSpan.FromSeconds(30)
                Dim url As String = $"{baseURL}/logout/{accountId}"
                Dim response = Await client.PostAsync(url, Nothing)
                Dim jsonResult = Await response.Content.ReadAsStringAsync()
                Return JsonConvert.DeserializeObject(Of ApiResponse)(jsonResult)
            End Using
        Catch ex As Exception
            Return New ApiResponse With {
                .success = False,
                .message = "خطأ: " & ex.Message
            }
        End Try
    End Function

    Private Sub ShowQRCode(base64String As String)
        Try
            If String.IsNullOrEmpty(base64String) Then Return

            If base64String.Contains(",") Then
                base64String = base64String.Split(","c)(1)
            End If

            Dim imageBytes = Convert.FromBase64String(base64String)
            Using ms As New IO.MemoryStream(imageBytes)
                picQRCode.Image = Image.FromStream(ms)
            End Using

            picQRCode.Visible = True
            lblQRInstruction.Visible = True

        Catch ex As Exception
            XtraMessageBox.Show("خطأ في عرض QR Code: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ShowConnectedStatus(phoneNumber As String)
        Console.WriteLine($"ShowConnectedStatus called with phone: {phoneNumber}")

        Try
            If Me.InvokeRequired Then
                Me.Invoke(Sub()
                              lblStatus.Text = "✅ متصل"
                              lblStatus.Appearance.ForeColor = Color.Green
                              lblPhoneNumber.Text = "رقم الهاتف: " & If(String.IsNullOrEmpty(phoneNumber), "غير متاح", phoneNumber)
                              lblPhoneNumber.Visible = True

                              picQRCode.Visible = False
                              picQRCode.Image = Nothing
                              lblQRInstruction.Visible = False

                              btnConnect.Enabled = False
                              btnRetry.Enabled = False
                              btnDisconnect.Enabled = True
                          End Sub)
            Else
                lblStatus.Text = "✅ متصل"
                lblStatus.Appearance.ForeColor = Color.Green
                lblPhoneNumber.Text = "رقم الهاتف: " & If(String.IsNullOrEmpty(phoneNumber), "غير متاح", phoneNumber)
                lblPhoneNumber.Visible = True

                picQRCode.Visible = False
                picQRCode.Image = Nothing
                lblQRInstruction.Visible = False

                btnConnect.Enabled = False
                btnRetry.Enabled = False
                btnDisconnect.Enabled = True
            End If

            Console.WriteLine($"QR Visibility after ShowConnectedStatus: {picQRCode.Visible}")
        Catch ex As Exception
            Console.WriteLine("Error in ShowConnectedStatus: " & ex.Message)
        End Try
    End Sub
    Private Sub ShowDisconnectedStatus()
        Dim stackTrace As New System.Diagnostics.StackTrace(True)
        Console.WriteLine("ShowDisconnectedStatus called from: " & stackTrace.GetFrame(1).GetMethod().Name)

        Try
            If Me.InvokeRequired Then
                Me.Invoke(Sub()
                              lblStatus.Text = "❌ غير متصل"
                              lblStatus.Appearance.ForeColor = Color.Red
                              lblPhoneNumber.Visible = False

                              picQRCode.Visible = False
                              lblQRInstruction.Visible = False

                              btnConnect.Enabled = True
                              btnRetry.Enabled = False
                              btnDisconnect.Enabled = False
                          End Sub)
            Else
                lblStatus.Text = "❌ غير متصل"
                lblStatus.Appearance.ForeColor = Color.Red
                lblPhoneNumber.Visible = False

                picQRCode.Visible = False
                lblQRInstruction.Visible = False

                btnConnect.Enabled = True
                btnRetry.Enabled = False
                btnDisconnect.Enabled = False
            End If
        Catch ex As Exception
            Console.WriteLine("Error in ShowDisconnectedStatus: " & ex.Message)
        End Try
    End Sub
    Private Function GetAccountIdFromDatabase() As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT TOP 1 SettingValue FROM [dbo].[Settings] WHERE SettingName = 'WhatsAppGreenInstanceID'")
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetWhatsAppBaseURL() As String
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT TOP 1 SettingValue FROM [dbo].[Settings] WHERE SettingName = 'WhatsAppGreenAPI'")

            Dim fullURL As String = String.Empty
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                fullURL = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            End If

            If String.IsNullOrEmpty(fullURL) Then Return Nothing

            Dim uri As New Uri(fullURL)
            Dim baseUrl As String = $"{uri.Scheme}://{uri.Host}"

            If uri.Port <> 80 AndAlso uri.Port <> 443 Then
                baseUrl &= ":" & uri.Port
            End If

            Return baseUrl

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        checkTimer.Enabled = False
        Me.Close()
    End Sub

    Private Sub LinkWhatsAppForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        checkTimer.Enabled = False
    End Sub
End Class

Public Class ApiResponse
    Public Property success As Boolean
    Public Property message As String
    Public Property [error] As String
End Class

Public Class ConnectResponse
    Inherits ApiResponse
    Public Property status As String
    Public Property qrCode As String
    Public Property phoneNumber As String
End Class

Public Class StatusResponse
    Public Property accountId As String
    Public Property status As String
    Public Property qrCode As String
    Public Property phoneNumber As String
    Public Property queueLength As Integer
    Public Property autoReplyEnabled As Boolean
End Class