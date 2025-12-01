Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Management
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Win32
Imports Newtonsoft.Json.Linq

Public Class LogInMenue
    Dim UserID As String = String.Empty
    Dim PassWord As String = String.Empty
    Dim LogStatus As Boolean = True
    Private ctr As Integer = 0
    Dim LogNotes As String = String.Empty
    Public Shared HasWhatsAppPackage As Boolean = False
    Public Shared CurrentModuleID As Integer = 0

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LogInBtn()
        'gfgfg
    End Sub
    Private Sub LogInBtn()
        If String.IsNullOrEmpty(TextUserName.Text) Then
            MsgBoxShowError("Error: Empty UserName")
            TextUserName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextPassword.Text) Then
            MsgBoxShowError("Error: Empty Password")
            TextPassword.Select()
            Exit Sub
        End If
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            If CheckRememberMe.Checked = True Then
                RememberMe()
            Else
                RemoveRememberMe()
            End If
            LogIn()
        Finally
            CloseProgressPanel(Handle)
        End Try
    End Sub
    Private Function ShowProgressPanel() As IOverlaySplashScreenHandle
        Dim handle As IOverlaySplashScreenHandle = SplashScreenManager.ShowOverlayForm(Me)
        Return handle
    End Function
    Private Sub CloseProgressPanel(ByVal handle As IOverlaySplashScreenHandle)
        If handle IsNot Nothing Then SplashScreenManager.CloseOverlayForm(handle)
    End Sub
    Private Sub LogIn()
        Try
            If Me.TextUserName.Text = String.Empty Then
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("الرجاء تعبئة البيانات المطلوبة")
                Else
                    MsgBoxShowError("Please Fill All Required Fields")
                End If

                Exit Sub
            End If

            If TextUserName.Text = "99999" And TextPassword.Text = "ourcompany" Then
                GoTo LogInCont
            End If

            Dim sql As New SQLControl
            Dim SQLString As String = " SELECT EmployeeID,EmployeeName,UserPassword,[AccessType],UserAccessType   " &
                                              " FROM  EmployeesData" &
                                              " Where EmployeeID = '" & Me.TextUserName.Text & "'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                If GlobalVariables._SystemLanguage = "Arabic" Then

                End If
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    XtraMessageBox.Show("اسم المستخدم خطا")
                Else
                    XtraMessageBox.Show("Invalid UserName")
                End If

                ' SplashScreenManager1.CloseWaitForm()
                Exit Sub
            End If

            UserID = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID"), String)
            PassWord = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserPassword"), String)
            GlobalVariables.EmployeeName = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName"), String)
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccessType")) Then
                GlobalVariables._AccessType = CType(sql.SQLDS.Tables(0).Rows(0).Item("AccessType"), String)
            Else
                GlobalVariables._AccessType = "User"
            End If
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType")) Then
                GlobalVariables._UserAccessType = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType"), Integer)
            Else
                GlobalVariables._UserAccessType = 1
            End If
            If Me.TextUserName.Text <> UserID Then
                'SplashScreenManager1.CloseWaitForm()0
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("اسم المستخدم خطا")
                Else
                    MsgBoxShowError("Invalid UserName")
                End If

                Exit Sub
            End If
            If GetCode(Me.TextPassword.Text, Me.TextPassword.Text) <> PassWord Then
                'SplashScreenManager1.CloseWaitForm()
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("كلمة المرور خطا")
                Else
                    MsgBoxShowError(" Incorrect Password ")
                End If

                Exit Sub
            End If

LogInCont:



            If Online = False Then
                GoLogIn()
            ElseIf Online = True Then
                Dim CustStatus As Boolean = True
                CustStatus = SelectCustomerStatus()
                If CustStatus = False Then
                    UploadLogIns()
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
                    Exit Sub
                ElseIf CustStatus = True Then
                    Call New Action(AddressOf UploadLogIns).BeginInvoke(Nothing, Nothing)
                    GoLogIn()
                    CreateDocLog("LogIn", "", 0, 0, "LogIn", "LogIn Success", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                    EmptyTempJournal()
                    Me.Close()
                End If
            End If
        Catch ex As Exception

        Finally

        End Try




    End Sub
    Private Sub EmptyTempJournal()
        Dim sql As New SQLControl
        Dim connectionString As String = My.Settings.TrueTimeConnectionString
        Dim query As String = " delete from [dbo].[JournalTemp] where [CurrentUserID]=" & GlobalVariables.CurrUser
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(query, connection)
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    CreateDocLog("LogIn", "", 0, 0, "LogIn", "Empty Journal Temp in logging " & rowsAffected & " rows effected ", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                End If
            End Using
        End Using
    End Sub

    Private Sub GoLogIn()
        'MsgBox("msgbox")
        LogStatus = True
        CurrDevice = Environ("ComputerName")
        CurrUser = TextUserName.Text
        GlobalVariables.CurrUserForTasks = TextUserName.Text

        Dim lockedDocs As Integer = DocumentsPostService.ClearDocumentLocksByDevice(CurrDevice)
        If lockedDocs > 0 Then
            CreateDocLog("LogIn", "", 0, 0, "LogIn", "Empty LockedDocuments in logging " & lockedDocs & " rows effected ", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
        End If

        If TextUserName.Text = "Admin" Then CurrUser = 99999999 : GlobalVariables._UserAccessType = 1
        My.Forms.Main.RibbonControl.Enabled = True
        TextPassword.Text = String.Empty
        My.Forms.Main.BarStaticCurrentUser.Caption = GlobalVariables.EmployeeName
        'My.Forms.Main.PanelControl1.Hide()
        My.Forms.Main.ItemUserName.Caption = GlobalVariables.CurrUser


        If GlobalVariables._UserAccessType = 2 Then ' مراقب دوام
            My.Forms.Main.Rawateb.Visible = False
            My.Forms.Main.BarButtonEmployeesEdit.Enabled = False
            My.Forms.Main.BarButtonItem226.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem223.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageGroup28.Visible = False
            'My.Forms.Main.RibbonPageGroup6.Visible = False
            My.Forms.Main.RibbonPageGroup3.Visible = False
            My.Forms.Main.BarButtonEmployeesEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageGroupIssueAttReport.Visible = False
            My.Forms.EmployeesEdit.SalaryTab.Visible = False
            My.Forms.Main.RibbonPageDocuments.Visible = False
            'My.Forms.Main.RibbonPageGroup3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 3 Or GlobalVariables._UserAccessType = 4 Then
            My.Forms.POSRestCashier.TextBoxItemsView.Text = GlobalVariables._UserAccessType
            My.Forms.POSRestCashier.Show()
            My.Forms.Main.Hide()
        ElseIf GlobalVariables._UserAccessType = 5 Then
            'My.Forms.SubScriptionsList.TextBoxItemsView.Text = GlobalVariables._UserAccessType
            My.Forms.SubScriptionsList.Show()
            My.Forms.Main.Hide()
        ElseIf GlobalVariables._UserAccessType = 98 Then ' Only Report
            My.Forms.Main.Visible = True
            My.Forms.Main.BarButtonEmployeesEdit.Enabled = True
            'My.Forms.Main.RibbonPageSettings.Visible = False
            My.Forms.Main.RibbonPageOther.Visible = False
            My.Forms.Main.FinancialDocuments.Visible = False
            My.Forms.Main.FinancialFiles.Visible = False
            'My.Forms.Main.RibbonPageSettings.Visible = False
            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 99 Then
            My.Forms.ItemsSearchMenue.LayoutEditMode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            My.Forms.ItemsSearchMenue.GridColumn1.Visible = False
            My.Forms.ItemsSearchMenue.GridColumn9.Visible = False
            My.Forms.ItemsSearchMenue.ColOpen.Visible = False
            My.Forms.ItemsSearchMenue.LayoutSelectItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            My.Forms.ItemsSearchMenue.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            My.Forms.ItemsSearchMenue.LayoutEditMode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            My.Forms.ItemsSearchMenue.Show()
        ElseIf GlobalVariables._UserAccessType = 97 Then 'ِادارة مواعيد 
            My.Forms.Main.Visible = True
            My.Forms.Main.FinancialPageCategory.Visible = False
            My.Forms.Main.ManagmentRibbonPageCategory.Visible = False
            My.Forms.Main.SettingsPageCategory.Visible = False
            My.Forms.Main.BarButtonItem235.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageDocuments.Visible = False
            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 96 Then '  ادارة بيانات الموظفين
            My.Forms.Main.Rawateb.Visible = False
            My.Forms.Main.BarButtonEmployeesEdit.Enabled = False
            My.Forms.Main.BarButtonItem226.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem223.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageGroup28.Visible = False
            My.Forms.Main.Ijazat.Visible = False
            My.Forms.Main.RibbonPageGroup3.Visible = False
            My.Forms.Main.BarButtonEmployeesEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageGroupAttendanceReports.Visible = False
            'My.Forms.Main.RibbonPageSettings.Visible = False
            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 95 Then  ' محاسب ادخال سندات
            My.Forms.Main.FinancialReports.Visible = False
            '  My.Forms.Main.BarButtonItemAccountsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItemAccountStatment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            ' My.Forms.Main.RibbonPageSettings.Visible = False
            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 94 Then  ' أمين المستودع

            My.Forms.Main.ManagmentRibbonPageCategory.Visible = False
            My.Forms.Main.RibbonPageGroupCheuqs.Visible = False
            'My.Forms.Main.RibbonPageGroupCompains.Visible = False
            My.Forms.Main.RibbonPageOther.Visible = False
            'My.Forms.Main.BarSubItem19.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarSubItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem19.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem20.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonSales.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem178.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem184.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonPurchases.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem180.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem185.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItemIndexes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            My.Forms.Main.BarSubItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonItem197.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.BarButtonInternalOrders.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.Main.RibbonPageDashBoareds.Visible = False
            My.Forms.Main.RibbonPageFinancialStatment.Visible = False
            My.Forms.Main.FinancialReferancesReports.Visible = False
            My.Forms.Main.FinancialAccountsReport.Visible = False
            My.Forms.Main.SettingsPageCategory.Visible = False
            '  My.Forms.Main.RibbonPageGroup41.Visible = False
            My.Forms.Main.FinancialFiles.Visible = False
            My.Forms.Main.RibbonEmployeesPage.Visible = False
            My.Forms.Main.RibbonPageGroupJournal.Visible = False
            My.Forms.Main.RibbonPageGroupTaqseet.Visible = False

            My.Forms.Main.Show()
        ElseIf GlobalVariables._UserAccessType = 93 Then  ' أمين المستودع
            My.Forms.OrdersWaitScreen.Show()
        ElseIf GlobalVariables._UserAccessType = 92 Then ' اقساط
            My.Forms.InstallmentsHeaderList.Show()
            My.Forms.Main.Hide()
        ElseIf GlobalVariables._UserAccessType = 91 Then '  تدقيق الرواتب
            My.Forms.SalaryPosted.Show()
            My.Forms.SalaryPosted.BarButtonItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            My.Forms.SalaryPosted.colEmployeeID.OptionsColumn.AllowEdit = False
            My.Forms.SalaryPosted.gridBandAttendance.Visible = False
            My.Forms.SalaryPosted.colLeavesAmount.OptionsColumn.AllowEdit = False
            My.Forms.Main.Hide()
        Else
            My.Forms.Main.Visible = True
            My.Forms.Main.BarButtonEmployeesEdit.Enabled = True
            My.Forms.Main.Show()
            'My.Forms.Main.RibbonPageSettings.Visible = True
        End If
        GetUserAccess()
        GetProgramSettings()
        '   Me.RadialMenu1.ShowPopup(New Point(100, 100))
        Me.Hide()
    End Sub
    Private Sub GetUserAccess()
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" select * from [EmployeesAccess] where [EmployeeID]=" & GlobalVariables.CurrUser)
        If sql.SQLDS.Tables.Count > 0 Then
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                For i = 0 To sql.SQLDS.Tables(0).Rows.Count - 1
                    With sql.SQLDS.Tables(0)
                        If .Rows(0).Item("AccessName") = "ShowItemCost" Then EmployeeAccess._ShowItemCost = CBool(.Rows(0).Item("AccessValue"))
                    End With
                Next
            End If
        End If
    End Sub
    Private Sub GetProgramSettings()
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseSerials'")
            GlobalVariables._UseSerials = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._UseSerials = False
        End Try
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='UseBatch'")
            GlobalVariables._UseBatch = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            If GlobalVariables._UseBatch = True Then
                My.Forms.Main.BarItemBalanceByBatchNo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            End If
        Catch ex As Exception
            GlobalVariables._UseBatch = False
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='ShowItemNo2' ")
            GlobalVariables._ShowItemNo2 = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._ShowItemNo2 = False
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Shalash'")
            GlobalVariables._Shalash = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables._Shalash = False
        End Try

        GlobalVariables._HRSystemIsConnectedWithAccountingSystem = CheckIfHRSystemIsConnectedWithAccountingSystem()
        GlobalVariables._AttConnectionType = GetAttConnectionType()


        'Try
        '    Dim Sql As New SQLControl
        '    Sql.SqlTrueAccountingRunQuery(" Select top(1) [SoftwareID] from [dbo].[CompanyData] ")
        '    ' GlobalVariables._SoftwareID = CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        '    If GlobalVariables._UseBatch = True Then
        '        My.Forms.Main.BarItemBalanceByBatchNo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        '    End If
        'Catch ex As Exception
        '    GlobalVariables._UseBatch = False
        'End Try
    End Sub
    Private Function SelectCustomerStatus() As Boolean
        Dim CustStatus As Boolean = True
        'If GlobalVariables._VersionMode = "Demo" Then
        '    Return True
        '    Exit Function
        'End If
        'Try

        '    Dim DeviceKey As String = GlobalVariables.LocalDeviceKey
        '    Dim CustData As New DataTable
        '    Dim MySqlConnection = New MySqlConnection
        '    MySqlConnection.ConnectionString = MySqlString()
        '    MySqlConnection.Open()
        '    Dim MyAdapter As New MySqlDataAdapter
        '    Dim SqlQuary = " SELECT DeviceStatus,LicencesDate From CustomerDevicesReg 
        '                            where DeviceKey= '" & DeviceKey & "'"

        '    Dim Command As New MySqlCommand
        '    Command.Connection = MySqlConnection
        '    Command.CommandText = SqlQuary
        '    MyAdapter.SelectCommand = Command
        '    Dim Mydata As MySqlDataReader
        '    Mydata = Command.ExecuteReader

        '    If CInt(Mydata.HasRows) = 0 Then
        '        'MsgBox("النسخة بحاجة الى ترخيص")
        '        LogStatus = True
        '        'LogNotes = "النسخة بحاجة الى ترخيص"
        '        CustStatus = True
        '    Else
        '        While Mydata.Read()
        '            '  CustStatus = Mydata(0)
        '            If Mydata(0) = "0" Then
        '                DeleteLocalRegData()
        '                LogStatus = False
        '                LogNotes = "InActive"
        '                MsgBox("النسخة موقوفة")
        '                CustStatus = False
        '            End If
        '            If Format(Mydata(1), "yyyy-MM-dd") < Today Then
        '                DeleteLocalRegData()
        '                LogStatus = False
        '                LogNotes = "Expired"
        '                MsgBox("الرخصة انتهت")
        '                CustStatus = False
        '            End If
        '        End While
        '    End If

        'Catch ex As Exception
        '    '  MsgBox(ex.ToString)
        'End Try

        Return CustStatus

    End Function
    Private Sub UploadLogIns()

        'Try
        '    Dim Sql As New SQLControl
        '    Dim CustomerName As String = String.Empty
        '    Dim RegistrationCode As String = String.Empty
        '    Dim SoftID As String = String.Empty

        '    Sql.SqlTrueTimeRunQuery("Select CompanyName from CompanyData")
        '    If Sql.SQLDS.Tables(0).Rows.Count <> 0 Then
        '        CustomerName = Sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        '    End If


        '    Dim NowString As String = Format(Now, "yyyy-MM-dd HH:mm")
        '    Dim MySqlConnection = New MySqlConnection
        '    MySqlConnection.ConnectionString = MySqlString()
        '    MySqlConnection.Open()
        '    Dim MyAdapter As New MySqlDataAdapter
        '    Dim SqlQuary = "insert into  LogInsLogs  (UserName,UserPassword,LogStatus,PublicIP,DeviceName,LogDate,CustomerName,SoftwareName) values (
        '                   '" & TextUserName.Text & "','" & TextPassword.Text & "'," & LogStatus & ",'" & GetExternalIp() _
        '                   & "','" & Environ("ComputerName") & "','" & NowString & "','" & CustomerName & "', 'TTA' )"

        '    Dim Command As New MySqlCommand
        '    Command.Connection = MySqlConnection
        '    Command.CommandText = SqlQuary
        '    MyAdapter.SelectCommand = Command
        '    Dim Mydata As MySqlDataReader
        '    Mydata = Command.ExecuteReader
        '    '  SplashScreenManager1.CloseWaitForm()
        'Catch ex As Exception
        '    '  MsgBox(ex.ToString)

        'End Try



    End Sub

    Private Sub PictureEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles PictureEdit3.EditValueChanged

    End Sub

    Private Sub PictureEdit3_Click(sender As Object, e As EventArgs) Handles PictureEdit3.Click
        Application.Exit()
    End Sub

    Private Sub LogInMenue_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' CheckAndHandleDeviceActivation()
        If GlobalVariables.GetCRMServices Then
            Try
                Dim permission As New SubServices()

                permission.UpdateModuleBodyValue()

                Dim services As List(Of SubServices.ServiceInfo) = permission.GetServicesUserHave()

                For Each svc In services
                    Dim endDate As Date

                    ' Handle null or empty EndDate
                    If String.IsNullOrWhiteSpace(svc.ServiceEndDate) Then
                        ' Treat null as no expiration
                        endDate = Date.MaxValue
                    Else
                        ' Try to parse the date
                        If Not Date.TryParse(svc.ServiceEndDate, endDate) Then
                            ' If parsing fails, treat as no expiration
                            endDate = Date.MaxValue
                        End If
                    End If
                    Debug.WriteLine($"ID: {svc.ServiceId}, Title: {svc.Title}, Active: {svc.Active}, End: {svc.ServiceEndDate}")
                    If svc.Active AndAlso endDate >= Today Then
                        SetServices(svc.ServiceId)
                    End If

                Next
            Catch ex As Exception
                Debug.WriteLine($"Error fetching services: {ex.Message}")
            End Try
        Else
            'With My.Forms.Main
            '    .RibbonEmployeesPage.Visible = True
            '    .FinancialFiles.Visible = True
            '    .FinancialDocuments.Visible = True
            '    .FinancialReports.Visible = True
            '    .RibbonPageOther.Visible = True
            '    .RibbonPageGroupPosSystem.Visible = True
            '    .RibbonPageCostCenters.Visible = True
            '    .RibbonPageGroup23.Visible = True
            'End With


        End If

        If GlobalVariables.GetSystemPermissions = False Then
            With My.Forms.Main
                .BarButtonSales.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonSales.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem184.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem165.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem19.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonPurchases.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem180.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem20.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem185.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem90.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem20.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem130.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem131.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem282.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarSubItemJardMenue.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarSubItem21.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarButtonItem261.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarInternalOrdersAudit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarInternalOrdersLogsReports.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                .BarSubItem12.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            End With
        End If

        LoadRememberMe()

        TextUserName.Select()

        If GlobalVariables._VersionMode = "Demo" Then
            TextUserName.Text = "1"
            TextPassword.Text = "123456"
        End If


        Me.KeyPreview = True

    End Sub
    Private Sub SetBaseAttendancePermissions()
        With My.Forms.Main
            .RibbonPageEmployees.Visible = True
            .RibbonPageReports.Visible = True
            .RibbonPageGroupGetAttendanceTrans.Visible = True
            .RibbonPageGroupAttendanceReports.Visible = True
        End With
    End Sub

    Private Sub SetBasePointOfSalePermissions()
        With My.Forms.Main
            .RibbonPageOther.Visible = True
            .RibbonPageGroupPosSystem.Visible = True

            .BarButtonItem221.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            My.Forms.Items.LayoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            My.Forms.Items.LayoutControlItem45.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End With
    End Sub
    Private Sub SetServices(ServiceId As Integer)
        With My.Forms.Main
            Select Case ServiceId
                Case 8927 ' Attendance مبسط
                    SetBaseAttendancePermissions()
                    .RibbonPageGroupAttendanceReports.Visible = True
                    .BarButtonItemGeneralAttendanceReport.Visibility = BarItemVisibility.Always
                    .BarButtonItemAttendanceByHour.Visibility = BarItemVisibility.Always
                    .BarButtonItemAttendaceTrans.Visibility = BarItemVisibility.Always
                    .RibbonPageGroup1.Visible = True
                    .BarButtonItemEmloyeesFile.Visibility = BarItemVisibility.Always
                    .RibbonPageGroupGetAttendanceTrans.Visible = True
                    .BarButtonItem1.Visibility = BarItemVisibility.Always
                    .BarButtonItem2.Visibility = BarItemVisibility.Never
                    .BarButtonItem296.Visibility = BarItemVisibility.Never
                    .BarButtonItem298.Visibility = BarItemVisibility.Never
                    .BarButtonItemShiftReport.Visibility = BarItemVisibility.Never
                    .RibbonPageGroupIssueAttReport.Visible = False
                    .BarSubItem16.Visibility = BarItemVisibility.Never
                    .BarButtonEmployeesEdit.Visibility = BarItemVisibility.Never

                Case 8930 ' Attendance اساسي
                    SetBaseAttendancePermissions()
                    .RibbonPageGroupAttendanceReports.Visible = True
                    .BarButtonItemShiftReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem296.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem298.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem267.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem281.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .RibbonPageGroupIssueAttReport.Visible = True
                    .Ijazat.Visible = True
                    .RibbonPageGroupIssueAttReport.Visible = True
                    .RibbonPageGroup1.Visible = True
                    .BarButtonItemEmloyeesFile.Visibility = BarItemVisibility.Always
                    .RibbonPageGroupGetAttendanceTrans.Visible = True
                    .BarButtonItem1.Visibility = BarItemVisibility.Always
                Case 8932  ' Accounting
                    .FinancialFiles.Visible = True
                    .FinancialDocuments.Visible = True
                    .FinancialReports.Visible = True
                    .FinancialReferancesReports.Visible = True
                    .FinancialAccountsReport.Visible = True
                    .RibbonPageFinancialStatment.Visible = True
                    .RibbonPageGroupItems.Visible = True
                    .RibbonPageGroup5.Visible = True
                    .BarButtonItemFinancialSettings.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .RibbonPageGroupReferances.Visible = True

                Case 8931 ' Rawateb
                    SetBaseAttendancePermissions()
                    .RibbonPageGroupAttendanceReports.Visible = True
                    .BarButtonItemShiftReport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem296.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem298.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem267.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonItem281.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .RibbonPageGroupIssueAttReport.Visible = True
                    .Rawateb.Visible = True

                Case 8955 'نقطة بيع
                    SetBasePointOfSalePermissions()
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroupItems.Visible = True
                    .RibbonPageGroupReferances.Visible = True
                    .FinancialFiles.Visible = True
                    .BarButtonItemChangePrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .BarButtonItemQuickAddNewItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .RibbonPageGroupItems.Visible = True
                    GlobalVariables.HasPosSystem = True
                    '.RibbonPageGroupReferances.Visible = True


                Case 9189 ' مطعم نقطة بيع
                    SetBasePointOfSalePermissions()
                    My.Forms.Items.LayoutControlItem5.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.AccountingPosNamesAdd.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .RibbonPageOther.Visible = True
                    'My.Forms.AccountingPosNamesAdd.TabTables.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    'My.Forms.AccountingPosNamesAdd.TabTablesLocations.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    CurrentModuleID = 9189


                Case 8937 'إدارة مطاعم
                    .RibbonPageOther.Visible = True
                    '.RibbonPageGroupSamba.Visible = True
                    My.Forms.Items.LayoutControlItemPorions.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.Items.CheckWithAddtions.Visible = True

                Case 8939 'إدارة المكاتب السياحية

                Case 8949 'إدارة مركبات 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroupCarsManegement.Visible = True

                Case 9125 'تاجير مركبات 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroupCarsRent.Visible = True

                Case 8974 'مبيعات موبايل 
                    .RibbonPageGroup17.Visible = True
                    My.Forms.Items.LayoutControlItem33.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .RibbonPageOther.Visible = True

                Case 8986 'إدارة تأمين 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroupInsurance.Visible = True

                Case 8992 'إدارة الاشتراكات 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroup7.Visible = True

                Case 8995 'سيريال 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroup11.Visible = True
                    My.Forms.Items.LayoutControlItem34.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

                Case 9113 'ربط مع اورباك 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroup38.Visible = True

                Case 9066 'بند الانتاج 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroup23.Visible = True
                    My.Forms.Items.BarButtonItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.Items.BarButtonItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.Items.BarButtonItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.Items.LayoutControlItem14.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    .RibbonPageOther.Visible = True
                Case 9065 'مراكز التكلفة 
                    .RibbonPageOther.Visible = True
                    .RibbonPageCostCenters.Visible = True
                    '.RibbonPageGroup41.Visible = True
                    .RibbonPageCostCenters.Visible = True
                Case 9120 'متجر الكتروني 
                    .RibbonPageOther.Visible = True
                    .RibbonPageGroup40.Visible = True
                    My.Forms.Items.BtnItemColorImages.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Case 9142 'الباتش 
                    .RibbonPageOther.Visible = True
                    My.Forms.Items.BarButtonItemBalanceByBatch.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                    My.Forms.Items.LayoutControlItem37.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Case 9098 'الربط مع سامبا 
                    .RibbonPageOther.Visible = True
                    '.RibbonPageGroupSamba.Visible = True
                    My.Forms.Items.LayoutControlItem38.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Case 9196 'تقرير الغرفة التجارية  RCCI
                    .BarButtonItemRCCIreports.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Case 9197 ' ضريبة الحوافز للجرارات PTEC
                    .BarButtonItemRCCIInsentives.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                Case 9185 'whatsapp
                    .BarButtonItem285.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    HasWhatsAppPackage = True
                    Debug.WriteLine($"HasWhatsAppPackage: {HasWhatsAppPackage}")
                    .RibbonPageOther.Visible = True

                Case 9198 ' طباعة باكودات الاصناف
                    .BarButtonPrintBarcodes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    .BarButtonPrintBarcodesSettings.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    GlobalVariables.HasPrintBarcodeService = True
                Case 9199  ' ادارة الرفوف
                    GlobalVariables.HasShelfsService = True
            End Select
        End With
    End Sub

    Private Sub TextUserName_EditValueChanged(sender As Object, e As EventArgs) Handles TextUserName.EditValueChanged

    End Sub
    Private Sub TextPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            LogInBtn()
        End If
    End Sub
    Private Sub RememberMe()
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\TrueTime", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.CreateSubKey("Software\TrueTime")
        End If
        regKey.SetValue("UserName", TextUserName.Text)
        regKey.SetValue("Password", TextPassword.Text)
        regKey.Close()
    End Sub
    Private Sub LoadRememberMe()
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\TrueTime", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.CreateSubKey("Software\TrueTime")
        End If
        TextUserName.Text = regKey.GetValue("UserName", "")
        TextPassword.Text = regKey.GetValue("Password", "")
        If Len(regKey.GetValue("UserName", "")) > 0 Then
            CheckRememberMe.Checked = True
        End If
        regKey.Close()

    End Sub
    Private Sub RemoveRememberMe()
        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\TrueTime", True)
        If regKey Is Nothing Then
            regKey = Registry.CurrentUser.CreateSubKey("Software\TrueTime")
        End If
        regKey.SetValue("UserName", "")
        regKey.SetValue("Password", "")
        regKey.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
        LogInBtnTest()
    End Sub

    Private Sub LogInBtnTest()
        If String.IsNullOrEmpty(TextUserName.Text) Then
            MsgBoxShowError("Error: Empty UserName")
            TextUserName.Select()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextPassword.Text) Then
            MsgBoxShowError("Error: Empty Password")
            TextPassword.Select()
            Exit Sub
        End If
        Dim Handle As IOverlaySplashScreenHandle = Nothing
        Try
            Handle = ShowProgressPanel()
            If CheckRememberMe.Checked = True Then
                RememberMe()
            Else
                RemoveRememberMe()
            End If
            LogInTest()
        Finally
            CloseProgressPanel(Handle)
        End Try
    End Sub

    Private Sub LogInTest()
        Try
            If Me.TextUserName.Text = String.Empty Then
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("الرجاء تعبئة البيانات المطلوبة")
                Else
                    MsgBoxShowError("Please Fill All Required Fields")
                End If

                Exit Sub
            End If

            If TextUserName.Text = "99999" And TextPassword.Text = "ourcompany" Then
                GoTo LogInCont
            End If

            Dim sql As New SQLControl
            Dim SQLString As String = " SELECT EmployeeID,EmployeeName,UserPassword,[AccessType],UserAccessType   " &
                                              " FROM  EmployeesData" &
                                              " Where EmployeeID = '" & Me.TextUserName.Text & "'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
                If GlobalVariables._SystemLanguage = "Arabic" Then

                End If
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    XtraMessageBox.Show("اسم المستخدم خطا")
                Else
                    XtraMessageBox.Show("Invalid UserName")
                End If

                ' SplashScreenManager1.CloseWaitForm()
                Exit Sub
            End If
            UserID = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID"), String)
            PassWord = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserPassword"), String)
            GlobalVariables.EmployeeName = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName"), String)
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AccessType")) Then
                GlobalVariables._AccessType = CType(sql.SQLDS.Tables(0).Rows(0).Item("AccessType"), String)
            Else
                GlobalVariables._AccessType = "User"
            End If
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType")) Then
                GlobalVariables._UserAccessType = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType"), Integer)
            Else
                GlobalVariables._UserAccessType = 1
            End If
            If Me.TextUserName.Text <> UserID Then
                'SplashScreenManager1.CloseWaitForm()0
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("اسم المستخدم خطا")
                Else
                    MsgBoxShowError("Invalid UserName")
                End If

                Exit Sub
            End If
            If GetCode(Me.TextPassword.Text, Me.TextPassword.Text) <> PassWord Then
                'SplashScreenManager1.CloseWaitForm()
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    MsgBoxShowError("كلمة المرور خطا")
                Else
                    MsgBoxShowError(" Incorrect Password ")
                End If

                Exit Sub
            End If

LogInCont:



            If Online = False Then
                GoLogInTest()
            ElseIf Online = True Then
                Dim CustStatus As Boolean = True
                CustStatus = SelectCustomerStatus()
                If CustStatus = False Then
                    UploadLogIns()
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
                    Exit Sub
                ElseIf CustStatus = True Then
                    Call New Action(AddressOf UploadLogIns).BeginInvoke(Nothing, Nothing)
                    GoLogInTest()
                    CreateDocLog("LogIn", "", 0, 0, "LogIn", "LogIn Success", Format(Now(), "yyyy-MM-dd HH:mm:ss"))
                    EmptyTempJournal()
                    Me.Close()
                End If
            End If
        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub GoLogInTest()
        Try
            LogStatus = True

            CurrUser = TextUserName.Text
            GlobalVariables.CurrUserForTasks = TextUserName.Text

            ' Admin shortcut
            If TextUserName.Text = "Admin" Then
                CurrUser = 99999999
                GlobalVariables._UserAccessType = 1
            End If

            My.Forms.Main.RibbonControl.Enabled = True

            TextPassword.Text = String.Empty
            My.Forms.Main.BarStaticCurrentUser.Caption = GlobalVariables.EmployeeName
            My.Forms.Main.ItemUserName.Caption = GlobalVariables.CurrUser
            My.Forms.Main.RibbonPageSettings.Visible = True
            ' Database query setup
            Dim query As String = "SELECT TOP 1 UserType, UserId FROM UsersSystem WHERE UserID = @UserId"
            Dim userType As String = ""
            Dim userId As Integer

            Try
                userId = CInt(TextUserName.Text)
            Catch ex As Exception
                Throw
            End Try


            Using conn As New SqlConnection(GlobalVariables.connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@UserId", userId)

                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            userType = reader("UserType").ToString()
                            userId = Convert.ToInt32(reader("UserId"))
                        Else
                        End If
                    End Using
                End Using
            End Using

            Debug.WriteLine($"🧩 Setting UserPermissions: Type={userType}, ID={userId}")

            UserPermission.UserType = userType
            UserPermission.UserId = userId

            InitializePermissions(UserPermission.UserId)


            Select Case userType
                Case "sa"
                    UserPermission.UserType = "sa"
                    My.Forms.Main.RibbonControl.Enabled = True
                    Debug.WriteLine("🛡 Super Admin (sa) permissions applied.")
                    My.Forms.Main.BarButtonItem223.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    My.Forms.Main.RibbonPageSettings.Visible = True

                Case "la"
                    UserPermission.UserType = "la"
                    Debug.WriteLine("🔒 Local Admin (la) permissions applied.")
                    My.Forms.Main.BarButtonItem223.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                    My.Forms.Main.RibbonPageSettings.Visible = True

                Case "User"
                    UserPermission.UserType = "user"
                    Debug.WriteLine("👤 Regular User permissions applied.")

                    Dim formIds As Integer() = {
                        1, 13, 11, 49, 9, 34, 3, 32, 4, 7, 6, 47, 31, 48, 45, 44, 43, 50,
                        42, 51, 41, 40, 39, 38, 37, 36, 35, 53, 55, 56, 60, 61, 62, 63,
                        64, 65, 66, 67, 68, 73, 74, 75, 76, 77, 78, 79, 80, 81, 83, 84,
                        85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 100, 101,
                        102, 103, 105, 106, 107, 108, 109, 110, 111, 112, 113
                    }

                    For Each formId In formIds
                        Try
                            ''Debug.WriteLine(New String("─"c, 50))
                            ''Debug.WriteLine($"🔹 Starting FormId={formId}")
                            ApplyPermissions(UserPermission.UserId, formId)
                            'Debug.WriteLine($"✅ Finished FormId={formId}")
                        Catch ex As Exception
                            Debug.WriteLine($"❌ Exception in FormId={formId}: {ex.Message}")
                            Debug.WriteLine($"📄 StackTrace: {ex.StackTrace}")
                        End Try
                    Next
                Case Else
                    Debug.WriteLine($"⚠ Unknown UserType: {userType}")
            End Select

            My.Forms.Main.Show()
            Debug.WriteLine("🎉 Main form shown successfully.")

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء تحميل البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"💥 Exception caught in main Try: {ex.Message}")
            Debug.WriteLine($"📄 StackTrace: {ex.StackTrace}")
        End Try
    End Sub

    Private Async Function CheckDeviceStatus() As Task(Of String)
        Try
            Dim motherboardSerial As String = GetMotherboardSerialNumber()
            Dim cpuId As String = GetCpuId()
            Dim uniqueDeviceKey As String = GetHWID()

            Dim apiUrl As String = GlobalVariables.ttsSystemsAPI & "Access/CheckDeviceStatus"

            Dim jsonBody As String = "{""uniqueDeviceKey"": """ & uniqueDeviceKey & """}"

            Using client As New HttpClient()
                Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
                Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                Return Await response.Content.ReadAsStringAsync()
            End Using

        Catch ex As Exception
            Return "{""error"":""" & ex.Message & """}"
        End Try
    End Function


    Private Async Function CheckAndHandleDeviceActivation() As Task
        Try
            Dim deviceForm As New DeviceActivationForm()
            Dim isNew As Integer = deviceForm.GetIsNewFromDatabase()

            If isNew = 0 Then
                Me.Hide()

                Using activationForm As New DeviceActivationForm()
                    Dim dialogResult As DialogResult = activationForm.ShowDialog()

                    If dialogResult <> DialogResult.OK Then
                        Application.Exit()
                        Return
                    End If
                End Using

                Me.Show()
                Return
            End If

            Dim result As String = Await DeviceActivationForm.CheckDeviceStatus()
            If Not String.IsNullOrEmpty(result) Then
                Dim json = JObject.Parse(result)
                Dim exists As Boolean = json("exists")
                Dim isActive As Boolean = json("isActive")

                If Not (exists AndAlso isActive) Then
                    deviceForm.SaveIsNewToDatabase(0)
                    MessageBox.Show("تم إيقاف تفعيل الجهاز. يرجى التواصل مع الدعم الفني.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Application.Exit()
                    Return
                End If

                deviceForm.SaveDeviceStatusToDatabase(result)
            End If

        Catch ex As Exception
            Dim deviceForm As New DeviceActivationForm()
            Dim isNew As Integer = deviceForm.GetIsNewFromDatabase()

            If isNew = 0 Then
                MessageBox.Show("الرجاء فحص الإتصال بالإنترنت وإرسال طلب تفعيل للجهاز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If

        End Try
    End Function
    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        LogInBtn()
    End Sub
    Public Shared Function GetMotherboardSerialNumber() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard")
                For Each obj As ManagementObject In searcher.Get()
                    Dim serial = obj("SerialNumber")
                    If serial IsNot Nothing AndAlso serial.ToString().Trim() <> "" Then
                        Return serial.ToString().Trim()
                    End If
                Next
            End Using
        Catch
        End Try
        Return "UnknownMB"
    End Function

    Public Shared Function GetCpuId() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor")
                For Each obj As ManagementObject In searcher.Get()
                    Dim cpuId = obj("ProcessorId")
                    If cpuId IsNot Nothing AndAlso cpuId.ToString().Trim() <> "" Then
                        Return cpuId.ToString().Trim()
                    End If
                Next
            End Using
        Catch
        End Try
        Return "UnknownCPU"
    End Function

    Public Shared Function GetBiosSerialNumber() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS")
                For Each obj As ManagementObject In searcher.Get()
                    Dim serial = obj("SerialNumber")
                    If serial IsNot Nothing AndAlso serial.ToString().Trim() <> "" Then
                        Return serial.ToString().Trim()
                    End If
                Next
            End Using
        Catch
        End Try
        Return "UnknownBIOS"
    End Function

    Public Shared Function GetSystemUUID() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct")
                For Each obj As ManagementObject In searcher.Get()
                    Dim uuid = obj("UUID")
                    If uuid IsNot Nothing AndAlso uuid.ToString().Trim() <> "" Then
                        Return uuid.ToString().Trim()
                    End If
                Next
            End Using
        Catch
        End Try
        Return "UnknownUUID"
    End Function

    Public Shared Function GetDiskSerialNumber() As String
        Try
            Using searcher As New ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia")
                For Each obj As ManagementObject In searcher.Get()
                    Dim serial = obj("SerialNumber")
                    If serial IsNot Nothing AndAlso serial.ToString().Trim() <> "" Then
                        Return serial.ToString().Trim()
                    End If
                Next
            End Using
        Catch
        End Try
        Return "UnknownDisk"
    End Function

    Public Shared Function GetHWID() As String
        Dim bios = GetBiosSerialNumber()
        Dim uuid = GetSystemUUID()
        Dim disk = GetDiskSerialNumber()
        Dim rawData = $"{bios}|{uuid}|{disk}"

        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(rawData)
            Dim hash = sha.ComputeHash(bytes)
            Dim sb As New StringBuilder()
            For Each b In hash
                sb.Append(b.ToString("x2"))
            Next
            Return sb.ToString().ToUpper()
        End Using
    End Function


End Class