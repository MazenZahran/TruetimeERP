Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System.Web.Script.Serialization
Imports DevExpress.Mvvm.POCO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Asn1.Cmp


Public Class ContractDetails

    Private _deviceKey As String
    Private _deviceName As String
    Private _deviceModel As String
    Private _staticContractKey As String

    Dim moduleInfo As Object = SubServices.GetModuleInfo("")

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Resize, AddressOf ContractDetails_Resize
        AddHandler Me.Load, AddressOf ContractDetails_Load
        GetServices()
        LoadDeviceInfo()
    End Sub

    Private Sub LoadDeviceInfo()

        Dim cachedStatus As String = DeviceActivationForm.GetDeviceStatusFromDatabase()
        If Not String.IsNullOrEmpty(cachedStatus) Then
            Try
                Dim json = JObject.Parse(cachedStatus)
                Dim exists As Boolean = json("exists")
                Dim isActive As Boolean = json("isActive")
                Dim companyDeviceId As Boolean = json("companyDeviceId")

                lblCompanyDeviceId.Text = companyDeviceId

            Catch
                lblCompanyDeviceId.Text = ""
            End Try
        Else

        End If
    End Sub

    Private Sub GetServices()
        Try
            _deviceKey = LogInMenue.GetHWID()
            _deviceName = Environment.MachineName
            _deviceModel = My.Computer.Info.OSFullName
            _staticContractKey = DeviceActivationForm.GetStaticContractKeyFromDatabase()

            lblDeviceKey.Text = $"مفتاح الجهاز: {If(String.IsNullOrEmpty(_deviceKey), "غير متوفر", _deviceKey)}"
            lblDeviceName.Text = $"اسم الجهاز: {If(String.IsNullOrEmpty(_deviceName), "غير متوفر", _deviceName)}"

            Dim permission As New SubServices()
            Dim deviceStatus As New DeviceActivationForm()
            Dim services As List(Of SubServices.ServiceInfo) = permission.GetServicesUserHave()

            If services IsNot Nothing AndAlso services.Count > 0 Then
                Dim totalServices As Integer = services.Count
                Dim activeServices As Integer = services.Where(Function(s) s.Active = True).Count()
                Dim inactiveServices As Integer = totalServices - activeServices

                lblTotalServicesCount.Text = totalServices.ToString()
                lblActiveServicesCount.Text = activeServices.ToString()
                lblInactiveServicesCount.Text = inactiveServices.ToString()

                flowLayoutServices.Controls.Clear()

                For Each svc In services.OrderByDescending(Function(s) s.Active).ThenBy(Function(s) s.Title)
                    Dim serviceCard As Panel = CreateServiceCard(svc)
                    flowLayoutServices.Controls.Add(serviceCard)
                Next
            Else
                lblTotalServicesCount.Text = "0"
                lblActiveServicesCount.Text = "0"
                lblInactiveServicesCount.Text = "0"

                Dim noServicesLabel As New System.Windows.Forms.Label With {
                    .Text = "لا توجد خدمات متاحة حالياً",
                    .Font = New Font("Segoe UI", 14, FontStyle.Bold),
                    .ForeColor = Color.FromArgb(149, 165, 166),
                    .AutoSize = True,
                    .Padding = New Padding(20)
                }
                flowLayoutServices.Controls.Add(noServicesLabel)
            End If

        Catch ex As Exception
            MessageBox.Show($"حدث خطأ أثناء تحميل البيانات: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CreateServiceCard(svc As SubServices.ServiceInfo) As Panel
        Dim cardPanel As New Panel With {
            .Width = 350,
            .Height = 140,
            .Margin = New Padding(10),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        Dim statusColor As Color = If(svc.Active, Color.FromArgb(46, 204, 113), Color.FromArgb(231, 76, 60))
        Dim statusText As String = If(svc.Active, "فعّالة", "غير فعّالة")

        Dim statusBar As New Panel With {
            .Dock = DockStyle.Top,
            .Height = 8,
            .BackColor = statusColor
        }
        cardPanel.Controls.Add(statusBar)

        Dim statusIcon As New System.Windows.Forms.Label With {
            .Text = If(svc.Active, "✓", "✗"),
            .Font = New Font("Segoe UI", 16, FontStyle.Bold),
            .ForeColor = statusColor,
            .AutoSize = True,
            .Location = New Point(310, 20)
        }
        cardPanel.Controls.Add(statusIcon)

        Dim titleLabel As New System.Windows.Forms.Label With {
            .Text = svc.Title,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(52, 73, 94),
            .Location = New Point(15, 20),
            .Size = New Size(280, 50),
            .RightToLeft = RightToLeft.Yes,
            .TextAlign = ContentAlignment.MiddleRight
        }
        cardPanel.Controls.Add(titleLabel)

        Dim statusLabel As New System.Windows.Forms.Label With {
            .Text = statusText,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .ForeColor = statusColor,
            .Location = New Point(15, 75),
            .AutoSize = True,
            .RightToLeft = RightToLeft.Yes
        }
        cardPanel.Controls.Add(statusLabel)

        Dim endDateLabel As New System.Windows.Forms.Label With {
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .ForeColor = Color.FromArgb(127, 140, 141),
            .Location = New Point(15, 100),
            .Size = New Size(320, 30),
            .RightToLeft = RightToLeft.Yes,
            .TextAlign = ContentAlignment.MiddleRight
        }

        Dim endDate As Date
        If String.IsNullOrWhiteSpace(svc.ServiceEndDate) Then
            endDateLabel.Text = ""
            endDateLabel.ForeColor = Color.FromArgb(46, 204, 113)
        Else
            If Date.TryParse(svc.ServiceEndDate, endDate) Then
                Dim daysRemaining As Integer = (endDate - Date.Now).Days
                If daysRemaining > 30 Then
                    endDateLabel.ForeColor = Color.FromArgb(46, 204, 113)
                ElseIf daysRemaining > 7 Then
                    endDateLabel.ForeColor = Color.FromArgb(243, 156, 18)
                Else
                    endDateLabel.ForeColor = Color.FromArgb(231, 76, 60)
                End If
                endDateLabel.Text = $"تاريخ الانتهاء: {endDate.ToShortDateString()} (باقي {daysRemaining} يوم)"
            Else
                endDateLabel.Text = "تاريخ الانتهاء: غير محدد"
            End If
        End If
        cardPanel.Controls.Add(endDateLabel)

        AddHandler cardPanel.Paint, AddressOf CardPanel_Paint

        Return cardPanel
    End Function

    Private Sub CardPanel_Paint(sender As Object, e As PaintEventArgs)
        Dim pnl As Panel = CType(sender, Panel)
        ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle,
                               Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                               Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                               Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid,
                               Color.FromArgb(220, 220, 220), 1, ButtonBorderStyle.Solid)
    End Sub

    Private Sub ContractDetails_Load(sender As Object, e As EventArgs)
        AdjustLayout()
    End Sub

    Private Sub ContractDetails_Resize(sender As Object, e As EventArgs)
        AdjustLayout()
    End Sub

    Private Sub AdjustLayout()
        Try
            Dim formWidth As Integer = Me.ClientSize.Width

            If formWidth < 900 Then
                pnlStats.Height = 330
                Dim cardWidth As Integer = Math.Max(200, formWidth - 60)
                Dim leftMargin As Integer = (formWidth - cardWidth) \ 2

                pnlTotalServices.Size = New Size(cardWidth, 90)
                pnlTotalServices.Location = New Point(leftMargin, 20)

                pnlActiveServices.Size = New Size(cardWidth, 90)
                pnlActiveServices.Location = New Point(leftMargin, 120)

                pnlInactiveServices.Size = New Size(cardWidth, 90)
                pnlInactiveServices.Location = New Point(leftMargin, 220)
            ElseIf formWidth < 1200 Then
                pnlStats.Height = 220
                Dim cardWidth As Integer = Math.Max(250, (formWidth - 80) \ 2)
                Dim spacing As Integer = 20
                Dim totalWidth As Integer = (cardWidth * 2) + spacing
                Dim leftMargin As Integer = (formWidth - totalWidth) \ 2

                pnlTotalServices.Size = New Size(cardWidth, 90)
                pnlTotalServices.Location = New Point(leftMargin + cardWidth + spacing, 20)

                pnlActiveServices.Size = New Size(cardWidth, 90)
                pnlActiveServices.Location = New Point(leftMargin, 20)

                pnlInactiveServices.Size = New Size(cardWidth, 90)
                pnlInactiveServices.Location = New Point(leftMargin + (cardWidth + spacing) \ 2, 120)
            Else
                pnlStats.Height = 120
                Dim cardWidth As Integer = Math.Max(280, (formWidth - 100) \ 3)
                Dim spacing As Integer = 20
                Dim totalWidth As Integer = (cardWidth * 3) + (spacing * 2)
                Dim leftMargin As Integer = (formWidth - totalWidth) \ 2

                pnlTotalServices.Size = New Size(cardWidth, 90)
                pnlTotalServices.Location = New Point(leftMargin + (cardWidth + spacing) * 2, 20)

                pnlActiveServices.Size = New Size(cardWidth, 90)
                pnlActiveServices.Location = New Point(leftMargin + cardWidth + spacing, 20)

                pnlInactiveServices.Size = New Size(cardWidth, 90)
                pnlInactiveServices.Location = New Point(leftMargin, 20)
            End If

            If formWidth < 700 Then
                pnlDeviceInfo.Height = 180
                lblDeviceKey.Location = New Point(20, 50)
                lblDeviceName.Location = New Point(20, 80)
            Else
                pnlDeviceInfo.Height = 120
                lblDeviceKey.Location = New Point(Math.Max(20, formWidth - 700), 50)
                lblDeviceName.Location = New Point(Math.Max(20, formWidth - 700), 80)
            End If

            If formWidth < 600 Then
                lblTitle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
            ElseIf formWidth < 900 Then
                lblTitle.Font = New Font("Segoe UI", 20, FontStyle.Bold)
            Else
                lblTitle.Font = New Font("Segoe UI", 24, FontStyle.Bold)
            End If

            Dim titleWidth As Integer = TextRenderer.MeasureText(lblTitle.Text, lblTitle.Font).Width
            lblTitle.Location = New Point((formWidth - titleWidth) \ 2, 15)

        Catch ex As Exception
        End Try
    End Sub

End Class