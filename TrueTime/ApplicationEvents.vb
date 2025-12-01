Imports System.Configuration
Imports DevExpress.XtraEditors
Imports System.Threading.Thread
Imports System.Globalization
Imports System.ServiceProcess
Imports System.Threading

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication


        Dim SqlDeviceKey As String = String.Empty
        Dim RegCode As String = String.Empty
        Dim ClientDevice As String = String.Empty
        Dim RegDate As String = String.Empty
        Dim SoftwareID As String = String.Empty
        Dim DeviceName As String = String.Empty
        Dim DeviceKey As String = SystemSerialNumber()
        ' Dim CustomerStatus As Boolean = SelectCustomerStatus()
        Dim NewRegDevice As Boolean
        Dim TextRegistrationCode As String
        Dim TextSoftID As String
        Private appMutex As Mutex


        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            ' Ensure single instance
            'appMutex = New Mutex(True, "MyUniqueAppName", createdNew:=False)
            'If Not appMutex.WaitOne(0, False) Then
            '    XtraMessageBox.Show("The application is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    End
            'End If



            ' Simulate loading time
            'Thread.Sleep(2000) ' Adjust this as needed


            'StartStop()
            DevExpress.XtraEditors.WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True
            DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins()



            GlobalVariables._VersionMode = "All"
            '  GlobalVariables._VersionMode = "HR"
            '  GlobalVariables._VersionMode = "Accounting"
            '  GlobalVariables._VersionMode = "Short"
            ' GlobalVariables._VersionMode = "Demo"

            GlobalVariables.Online = CheckInternetConnection()

            If GlobalVariables._VersionMode = "Demo" Then
                GlobalVariables.LocalHasValidLocalLicense = True
            Else
                GlobalVariables.LocalHasValidLocalLicense = HasValidLocalLicense()
            End If


            ' تحديد لغة النظام
            GlobalVariables._SystemLanguage = GetSystemLanguage()
            If GlobalVariables._SystemLanguage = "Arabic" Then
                CurrentThread.CurrentUICulture = New CultureInfo("AR")
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                CurrentThread.CurrentUICulture = New CultureInfo("EN")
            End If

            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)
            If GlobalVariables._VersionMode <> "Demo" Then
                If IsConnected() = False Then
                    XtraMessageBox.Show("خطا بالاتصال مع قاعدة البيانات", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.MainForm = My.Forms.ChangeConnectionString
                    My.Forms.ChangeConnectionString.ConnectionName.Text = "TrueTime.My.MySettings.TrueTimeConnectionString"
                    Exit Sub
                Else
                    If GlobalVariables.LocalHasValidLocalLicense = True Then
                        Me.MainForm = My.Forms.LogInMenue
                        'Me.MainForm = My.Forms.AccTaxSummary
                        ' Me.MainForm = My.Forms.SalaryTaxDeductionForInsentives
                        ' Me.MainForm = My.Forms.SalaryPosted

                        'SambaReports2._OpenForPrint = True
                        'SambaReports2._SambaShiftStatus = "Opened"
                        'Me.MainForm = My.Forms.SambaReports2

                        EncryptConnStrings()
                    Else
                        MsgBox("لا يوجد ترخيص")
                        DeleteLocalRegData()
                        Me.MainForm = My.Forms.RegistrationForm
                    End If
                End If
            Else
                DecryptConnStrings()
                Me.MainForm = My.Forms.LogInMenue
            End If
            Try
            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try
        End Sub
        Sub StartStop()

            Dim service As ServiceController = New ServiceController("MSSQL$SQLEXPRESS")
            If ((service.Status.Equals(ServiceControllerStatus.Stopped)) Or
         (service.Status.Equals(ServiceControllerStatus.StopPending))) Then
                service.Start()
                'Else
                'service.Stop()
            End If
        End Sub
        Private Sub EncryptConfigSection()
            Dim Config As Configuration
            Dim Section As ConfigurationSection

            Config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Section = Config.GetSection("connectionStrings")
            If (Section IsNot Nothing) Then

                If (Not Section.SectionInformation.IsProtected) Then
                    If (Not Section.ElementInformation.IsLocked) Then
                        Section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
                        Section.SectionInformation.ForceSave = True
                        Config.Save(ConfigurationSaveMode.Full)
                    End If
                End If
            End If

        End Sub

        Protected Sub EncryptConnStrings()
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)



            Dim connectionStrings As ConfigurationSection = config.GetSection("connectionStrings")
            If connectionStrings IsNot Nothing Then
                If Not connectionStrings.SectionInformation.IsProtected Then
                    connectionStrings.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
                    config.Save()
                    '  DisplayWebConfig()
                End If
            End If

            'Dim _EndDateTrialVersion As ConfigurationSection
            '_EndDateTrialVersion = config.GetSection("applicationSettings")
            'If _EndDateTrialVersion IsNot Nothing Then
            '    If Not _EndDateTrialVersion.SectionInformation.IsProtected Then
            '        _EndDateTrialVersion.SectionInformation.ProtectSection("DataProtectionConfigurationProvider")
            '        config.Save()
            '        '  DisplayWebConfig()
            '    End If
            'End If
        End Sub

        Protected Sub DecryptConnStrings()
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim connectionStrings As ConfigurationSection = config.GetSection("connectionStrings")

            If connectionStrings IsNot Nothing Then
                If connectionStrings.SectionInformation.IsProtected Then
                    connectionStrings.SectionInformation.UnprotectSection()
                    config.Save()
                    ' DisplayWebConfig()
                End If
            End If

            Dim _EndDateTrialVersion As ConfigurationSection = config.GetSection("appSettings")
            If _EndDateTrialVersion IsNot Nothing Then
                If _EndDateTrialVersion.SectionInformation.IsProtected Then
                    _EndDateTrialVersion.SectionInformation.UnprotectSection()
                    config.Save()
                    ' DisplayWebConfig()
                End If
            End If
        End Sub

    End Class
End Namespace
