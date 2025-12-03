Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports DevExpress.Utils.Html
Imports DevExpress.Xpf.Core
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports DevExpress.XtraCharts.Designer.Native
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
Imports MySqlConnector
Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
'
Public Class Main
    Dim UserID As String = String.Empty
    Dim PassWord As String = String.Empty
    Dim LogStatus As Boolean = True
    Dim LogNotes As String = String.Empty
    Private ctr As Integer = 0

    Public Sub New()
        InitializeComponent()
        BackgroundWorker1.WorkerReportsProgress = True
        'BackgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        BarEditDate.EditValue = Today
        WindowsFormsSettings.FontIconsStyle = FontIconsStyle.Win10
        'WindowsFormsSettings.CompactUIMode = DefaultBoolean.True
        WindowsFormsSettings.AllowHoverAnimation = DefaultBoolean.True
        'Application.SetCompatibleTextRenderingDefault(False)
        Me.RibbonControl.Minimized = True
        '  gghjghjg
        Dim f As CalenderWithTasks = New CalenderWithTasks()
        f.MdiParent = Me
        f.Show()
        'hg
        'Dim ff As ReservationsList = New ReservationsList()
        'ff.MdiParent = Me
        'ff.Show()
        'k

        'h
        My.Forms.Main.RibbonControl.Show()
        BarLanguage.Caption = GlobalVariables._SystemLanguage

        Statickey.Caption = DeviceActivationForm.GetStaticContractKeyFromDatabase()



        Dim MyDBConnection As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
        Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(MyDBConnection)
        My.Forms.Main.ItemDataBaseName.Caption = builder.InitialCatalog
        GetMySettings()

        If GlobalVariables._ShowCostCenter = True Then
            BarButtonCostCenter.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Else
            BarButtonCostCenter.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If FinancialFiles.Visible = False Then
            BarButtonItemFinancialSettings.Visibility = BarItemVisibility.Never
        End If
        If RibbonPageEmployees.Visible = False Then
            BarButtonItemHR_Settings.Visibility = BarItemVisibility.Never
            BarButtonItemSelfServiceSettings.Visibility = BarItemVisibility.Never
        End If
        If FinancialPageCategory.Visible = True Then
            'Me.RadialMenu1.ShowPopup(New Point(100, 100))
            'ToastNotificationsManager1.ShowNotification(ToastNotificationsManager1.Notifications(0))
        End If
        Me.KeyPreview = True
        '  TextUserName.Select()



        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If

        BarEditItemSync.EditValue = 0

        If GlobalVariables._UserAccessType = 2 Then
            RibbonPageSettings.Visible = False
        End If


        If GlobalVariables._UseBatch = True Then
            BarItemBalanceByBatchNo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If


        Timer1.Start()

        If LogInMenue.HasWhatsAppPackage Then
            btnOpenLinkWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            mnuWhatsApp.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

    End Sub
    Private _NotificationNo As Integer = 1
    Private Sub ribbon_CustomDrawItem(ByVal sender As Object, ByVal e As BarItemCustomDrawEventArgs) Handles RibbonControl.CustomDrawItem
        Try
            If Not IsNothing(e.RibbonItemInfo) Then
                If e.RibbonItemInfo.Text = "Notifications" Then
                    Dim circleBounds As New Rectangle(e.Bounds.X + e.Bounds.Width - 10, e.Bounds.Y + e.Bounds.Height - 20, 20, 20)
                    Dim circleCenter As New Point(circleBounds.X + circleBounds.Width \ 2, circleBounds.Y + circleBounds.Height \ 2)
                    Dim fontFamily As New FontFamily("Arial")
                    Dim captionFont As New Font(fontFamily, 18, FontStyle.Regular, GraphicsUnit.Pixel)
                    e.Cache.FillEllipse(Brushes.Red, circleBounds)
                    e.Cache.DrawString(_NotificationNo, captionFont, Brushes.White, New Point(circleCenter.X - 4, circleCenter.Y - 9))
                End If
            End If

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Public Sub GetMySettings()
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='CostCenters'")
            If CBool(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
                _ShowCostCenter = True
            Else
                _ShowCostCenter = False
            End If
        Catch ex As Exception
            _ShowCostCenter = False
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue] From [dbo].[Settings] Where [SettingName]='Accounting_VATdefaultPercentage'")
            GlobalVariables.VATDefaultPercentage = CDec(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            GlobalVariables.VATDefaultPercentage = 0
        End Try

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.BarStaticItemSync.Caption = "Sync..."
        'Me.BarStaticItemSync.Caption = (e.ProgressPercentage.ToString() & "%")
        Me.BarEditItemSync.EditValue = (e.ProgressPercentage)
    End Sub
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            Me.BarEditItemSync.Caption = "Canceled!"
        ElseIf e.[Error] IsNot Nothing Then
            Me.BarEditItemSync.Caption = "Error: " & e.[Error].Message
        Else
            Me.BarEditItemSync.Caption = "Last Sync" & "@" & Format(Now, "HH:mm")
        End If
    End Sub
    ' Helper: load all requested settings (Boolean) into a dictionary
    Private Function LoadSettings(sql As SQLControl, settingNames As IEnumerable(Of String)) As Dictionary(Of String, Boolean)
        ' Build IN clause safely (names are constants in code, so injection is not an issue here)
        Dim escapedNames = settingNames.
        Select(Function(n) "'" & n.Replace("'", "''") & "'")

        Dim inClause As String = String.Join(",", escapedNames)

        Dim query As String =
        "SELECT SettingName, SettingValue " &
        "FROM [dbo].[Settings] " &
        "WHERE SettingName IN (" & inClause & ")"

        sql.SqlTrueAccountingRunQuery(query)

        Dim dict As New Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
        Dim tbl As DataTable = sql.SQLDS.Tables(0)

        For Each row As DataRow In tbl.Rows
            Dim name As String = CStr(row("SettingName"))
            Dim rawValue As String = CStr(row("SettingValue"))
            Dim value As Boolean
            Boolean.TryParse(rawValue, value)
            dict(name) = value
        Next

        Return dict
    End Function


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker As BackgroundWorker = TryCast(sender, BackgroundWorker)
        Dim sql As New SQLControl

        ' 1) Load all boolean Settings in ONE hit
        Dim settingNames As String() = {
        "ShowItemNo2",
        "UseSalesMan",
        "ShowColNoteInStockMoveDoc",
        "UseColorsAndMeasuresInItems",
        "WareHouseUseShelf",
        "ShowShelvesColumnInVoucher",
        "UseSerials",
        "AlertWhenItemQuantityLessThanBalanceInVouchers",
        "AttAllowEditAttTrans",
        "ShowWorkLeavesData",
        "SendSmsFromDocuments",
        "CostCenterRequired",
        "AttDailyAdjustment",
        "HasOrpak",
        "ShowActionMenueAfterSaveDocuments",
        "ShowColNoteInMoneyTransDoc",
        "ShowItemCostInItemScreenUserForItemUsers",
        "Accounting_UseSubAccounts",
        "ShowBalanceColumnInVoucher",
        "ShowLastPurchasePriceColumnInVoucher",
        "Shalash",
        "Accounting_PrintAccountStatmentByEnglish",
        "Accounting_UseVATsystem"
    }

        Dim settings As Dictionary(Of String, Boolean) = LoadSettings(sql, settingNames)

        ' 2) Map settings to GlobalVariables
        GlobalVariables._ShowItemNo2 = GetBoolSetting(settings, "ShowItemNo2")
        Me.BarEditItemSync.Caption = "ShowItemNo2"
        worker.ReportProgress(10)

        GlobalVariables._UseSalesMan = GetBoolSetting(settings, "UseSalesMan")
        Me.BarEditItemSync.Caption = "UseSalesMan"
        worker.ReportProgress(15)

        GlobalVariables._ShowColNoteInStockMoveDoc = GetBoolSetting(settings, "ShowColNoteInStockMoveDoc")
        Me.BarEditItemSync.Caption = "ShowColNoteInStockMoveDoc"
        worker.ReportProgress(20)

        GlobalVariables._UseColorsAndMeasuresInItems = GetBoolSetting(settings, "UseColorsAndMeasuresInItems")
        Me.BarEditItemSync.Caption = "UseColorsAndMeasuresInItems"

        ' WareHouseUseShelf + UI logic
        GlobalVariables._WareHouseUseShelf = GetBoolSetting(settings, "WareHouseUseShelf")
        If Not GlobalVariables._WareHouseUseShelf Then
            BarButtonItemShelfContains.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonItemBalanceOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonItemItemsTransOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Else
            BarButtonItemShelfContains.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonItemBalanceOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BarButtonItemItemsTransOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        Me.BarEditItemSync.Caption = "WareHouseUseShelf"
        worker.ReportProgress(25)

        GlobalVariables._ShowShelvesColumnInVoucher = GetBoolSetting(settings, "ShowShelvesColumnInVoucher")
        Me.BarEditItemSync.Caption = "ShowShelvesColumnInVoucher"
        worker.ReportProgress(30)

        GlobalVariables._UseSerials =
        GetBoolSetting(settings, "UseSerials")
        Me.BarEditItemSync.Caption = "UseSerials"

        GlobalVariables._AlertWhenItemQuantityLessThanBalanceInVouchers =
        GetBoolSetting(settings, "AlertWhenItemQuantityLessThanBalanceInVouchers")
        Me.BarEditItemSync.Caption = "AlertWhenItemQuantityLessThanBalanceInVouchers"

        GlobalVariables._AttAllowEditAttTrans =
        GetBoolSetting(settings, "AttAllowEditAttTrans")
        Me.BarEditItemSync.Caption = "AttAllowEditAttTrans"

        GlobalVariables._ShowWorkLeavesData =
        GetBoolSetting(settings, "ShowWorkLeavesData")
        Me.BarEditItemSync.Caption = "ShowWorkLeavesData"

        GlobalVariables._SendSmsFromDocuments =
        GetBoolSetting(settings, "SendSmsFromDocuments")
        Me.BarEditItemSync.Caption = "SendSmsFromDocuments"

        GlobalVariables._CostCenterRequired =
        GetBoolSetting(settings, "CostCenterRequired")

        GlobalVariables._AttDailyAdjustment =
        GetBoolSetting(settings, "AttDailyAdjustment")

        GlobalVariables._HasOrpak =
        GetBoolSetting(settings, "HasOrpak")

        GlobalVariables._ShowActionMenueAfterSaveDocuments =
        GetBoolSetting(settings, "ShowActionMenueAfterSaveDocuments")

        GlobalVariables._ShowColNoteInMoneyTransDoc =
        GetBoolSetting(settings, "ShowColNoteInMoneyTransDoc")

        GlobalVariables._ShowItemCostInItemScreenUser =
        GetBoolSetting(settings, "ShowItemCostInItemScreenUserForItemUsers")

        GlobalVariables.Accounting_UseSubAccounts =
        GetBoolSetting(settings, "Accounting_UseSubAccounts")

        GlobalVariables._ShowBalanceColumnInVoucher =
        GetBoolSetting(settings, "ShowBalanceColumnInVoucher", False)

        GlobalVariables._ShowLastPurchasePriceColumnInVoucher =
        GetBoolSetting(settings, "ShowLastPurchasePriceColumnInVoucher", False)

        GlobalVariables._Shalash =
        GetBoolSetting(settings, "Shalash", False)

        GlobalVariables._Accounting_PrintAccountStatmentByEnglish =
        GetBoolSetting(settings, "Accounting_PrintAccountStatmentByEnglish", False)

        GlobalVariables.UseVAT =
        GetBoolSetting(settings, "Accounting_UseVATsystem", False)


        ' 3) Load SettValues / Set1 (separate table)
        Try
            sql.SqlTrueAccountingRunQuery("SELECT SetCode FROM [dbo].[SettValues] WHERE SetName = 'Set1'")
            Dim endDateEncoded As String = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SetCode"))
            GlobalVariables._EndDate = CDate(DecodingData(endDateEncoded))

            Dim _period As TimeSpan = GlobalVariables._EndDate.Subtract(Today)
            If _period.TotalDays < 365 AndAlso _period.TotalDays > 0 Then
                BarEndDate.Caption = " باقي على انتهاء النسخة  " & _period.TotalDays & " يوم "
                BarEndDate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            ElseIf _period.TotalDays <= 0 Then
                BarEndDate.Caption = " النسخة انتهت "
                BarEndDate.ItemAppearance.Normal.ForeColor = Color.Red
                BarEndDate.ItemAppearance.Normal.BorderColor = Color.Red
            Else
                BarEndDate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If
        Catch ex As Exception
            BarEndDate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End Try

        ' 4) Load full Settings table into GlobalVariables._AppSettingsTable (one last query)
        Dim sqlStringsettings As String =
        "SELECT [SettingName], [SettingValue], [ID], [SettingDescription] " &
        "FROM [dbo].[Settings]"

        sql.SqlTrueAccountingRunQuery(sqlStringsettings)
        GlobalVariables._AppSettingsTable = sql.SQLDS.Tables(0)

        ' Apply additional system settings
        Dim _Settings As New MySystemSettings
        _Settings.GetMySystemSettings()

        worker.ReportProgress(100)
    End Sub


    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' MsgBox(e.KeyCode)
        If e.KeyCode = Keys.F12 Then
            If FinancialPageCategory.Visible = True Then RadialMenu1.ShowPopup(Control.MousePosition)
        ElseIf e.KeyCode = Keys.F11 Then
            Dim f As New ItemsSearchMenue
            With f
                .LayoutSelectItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                .Show()
            End With

        ElseIf e.KeyCode = 68 AndAlso e.Control Then
            If RibbonDeleteData.Visible = True Then
                RibbonDeleteData.Visible = False
            Else
                RibbonDeleteData.Visible = True
            End If
        End If
    End Sub

    ' Helper: read a Boolean setting with a default value if not found
    Private Function GetBoolSetting(
    settings As Dictionary(Of String, Boolean),
    name As String,
    Optional defaultValue As Boolean = False
) As Boolean

        Dim value As Boolean
        If settings IsNot Nothing AndAlso settings.TryGetValue(name, value) Then
            Return value
        End If
        Return defaultValue
    End Function

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is ReadClock Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New ReadClock()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
        Dim f As New ReadClock
        With f
            .ShowDialog()
        End With

    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonEmployeesEdit.ItemClick

        'If CheckIfFormExist("EmployeesEditList") = False Or HasAccessOnForm("EmployeesEditList", "QueryAccess") = False Then
        '    MsgBox("لا يوجد صلاحية")
        '    Exit Sub
        'End If

        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmployeesEditList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New EmployeesEditList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick

    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemVocations.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AddVocation Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AddVocation()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttTransReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttTransReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemIndexes.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is Lists2 Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New Lists2()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    '    Private Sub LogIn()

    '        Try
    '            'If Me.TextUserName.Text = String.Empty Then
    '            '    If GlobalVariables._SystemLanguage = "Arabic" Then
    '            '        XtraMessageBox.Show("الرجاء تعبئة البيانات المطلوبة")
    '            '    Else
    '            '        XtraMessageBox.Show("Please Fill All Required Fields")
    '            '    End If

    '            '    Exit Sub
    '            'End If

    '            'If TextUserName.Text = "Admin" And TextPassword.Text = "ourcompany" Then
    '            '    GoTo LogInCont
    '            'End If

    '            Dim sql As New SQLControl
    '            Dim SQLString As String = " SELECT EmployeeID,EmployeeName,UserPassword,[UserAccessType]   " &
    '                                              " FROM  EmployeesData" &
    '                                              " Where EmployeeID = '" & Me.TextUserName.Text & "'"
    '            sql.SqlTrueTimeRunQuery(SQLString)
    '            If sql.SQLDS.Tables(0).Rows.Count = 0 Then
    '                If GlobalVariables._SystemLanguage = "Arabic" Then

    '                End If
    '                If GlobalVariables._SystemLanguage = "Arabic" Then
    '                    XtraMessageBox.Show("اسم المستخدم خطا")
    '                Else
    '                    XtraMessageBox.Show("Invalid UserName")
    '                End If

    '                ' SplashScreenManager1.CloseWaitForm()
    '                Exit Sub
    '            End If
    '            UserID = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID"), String)
    '            PassWord = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserPassword"), String)
    '            GlobalVariables.EmployeeName = CType(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName"), String)
    '            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType")) Then
    '                GlobalVariables._UserAccessType = CType(sql.SQLDS.Tables(0).Rows(0).Item("UserAccessType"), String)
    '            Else
    '                GlobalVariables._UserAccessType = 0
    '            End If
    '            'If Me.TextUserName.Text <> UserID Then
    '            '    'SplashScreenManager1.CloseWaitForm()
    '            '    If GlobalVariables._SystemLanguage = "Arabic" Then
    '            '        XtraMessageBox.Show("اسم المستخدم خطا")
    '            '    Else
    '            '        XtraMessageBox.Show("Invalid UserName")
    '            '    End If

    '            '    Exit Sub
    '            'End If
    '            'If GetCode(Me.TextPassword.Text, Me.TextPassword.Text) <> PassWord Then
    '            '    'SplashScreenManager1.CloseWaitForm()
    '            '    If GlobalVariables._SystemLanguage = "Arabic" Then
    '            '        XtraMessageBox.Show("كلمة المرور خطا")
    '            '    Else
    '            '        XtraMessageBox.Show(" Incorrect Password ")
    '            '    End If

    '            '    Exit Sub
    '            'End If

    'LogInCont:

    '            If Online = False Then
    '                GoLogIn()
    '            ElseIf Online = True Then
    '                Dim op As FluentSplashScreenOptions = New FluentSplashScreenOptions()
    '                op.Title = "We Do The Best For You"
    '                op.Subtitle = "TTS Systems"
    '                op.RightFooter = "Starting..."
    '                op.LeftFooter = "Copyright © 2000 - 2021 TTS Inc." & Environment.NewLine & "All Rights reserved."
    '                op.LoadingIndicatorType = FluentLoadingIndicatorType.Dots
    '                op.OpacityColor = Color.Gray
    '                op.Opacity = 130
    '                '  op.LogoImageOptions.SvgImage = My.Resources.tts22_svg
    '                DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(op, parentForm:=Me, useFadeIn:=True, useFadeOut:=True)
    '                Dim CustStatus As Boolean = SelectCustomerStatus()
    '                If CustStatus = False Then
    '                    UploadLogIns()
    '                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
    '                    Exit Sub
    '                ElseIf CustStatus = True Then
    '                    ' UploadLogIns()
    '                    Call New Action(AddressOf UploadLogIns).BeginInvoke(Nothing, Nothing)
    '                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
    '                    GoLogIn()
    '                End If
    '            End If
    '        Catch ex As Exception
    '            '  SplashScreenManager1.CloseWaitForm()
    '        Finally
    '            ' SplashScreenManager1.CloseWaitForm()
    '        End Try




    '    End Sub
    Private Sub GoLogIn()
        LogStatus = True
        CurrDevice = Environ("ComputerName")

        '  CurrUser = TextUserName.Text
        RibbonControl.Enabled = True
        ' TextPassword.Text = String.Empty
        BarStaticCurrentUser.Caption = GlobalVariables.EmployeeName
        '  PanelControl1.Hide()
        ' OpenDashBoard()

        'Dim MyDBConnection As String = ConfigurationManager.ConnectionStrings("TrueTime.My.MySettings.TrueTimeConnectionString").ConnectionString
        'Dim builder As SqlConnectionStringBuilder = New SqlConnectionStringBuilder(MyDBConnection)
        'My.Forms.Main.ItemDataBaseName.Caption = builder.InitialCatalog
        My.Forms.Main.ItemUserName.Caption = GlobalVariables.CurrUser

        'Select Case GlobalVariables._UserAccessType
        '    Case 2
        '        Me.Rawateb.Visible = False
        '        Me.BarButtonEmployeesEdit.Enabled = False
        '    Case 3
        '        My.Forms.POSRestCashier.TextBoxItemsView.Text = GlobalVariables._UserAccessType
        '        My.Forms.POSRestCashier.Show()
        '        My.Forms.Main.Hide()
        '    Case 95
        '        Me.FinancialReports.Visible = False
        '        BarButtonItemAccountsBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '        BarButtonItemAccountStatment.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '        My.Forms.Main.Show()
        '    Case Else
        '        Me.Rawateb.Visible = True
        '        Me.BarButtonEmployeesEdit.Enabled = True
        '        My.Forms.Main.Show()
        'End Select

        'If GlobalVariables._UserAccessType = 2 Then
        '    Me.Rawateb.Visible = False
        '    Me.BarButtonEmployeesEdit.Enabled = False
        '    '  Me.Ijazat.Visible = False
        '    'Me.RibbonPageSettings.Visible = False
        'ElseIf GlobalVariables._UserAccessType = 3 Then
        '    My.Forms.POSRestCashier.TextBoxItemsView.Text = GlobalVariables._UserAccessType
        '    My.Forms.POSRestCashier.Show()
        '    My.Forms.Main.Hide()
        'Else
        '    Me.Rawateb.Visible = True
        '    Me.BarButtonEmployeesEdit.Enabled = True
        '    My.Forms.Main.Show()
        '    'Me.RibbonPageSettings.Visible = True
        'End If

        Dim child As Form = Nothing
        Dim f As CalenderWithTasks = New CalenderWithTasks()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()

        RibbonControl.Show()
        Me.RadialMenu1.ShowPopup(New Point(100, 100))
    End Sub


    Private Function SelectCustomerStatus() As Boolean
        Dim CustStatus As Boolean = True

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
        '        LogStatus = False
        '        'LogNotes = "النسخة بحاجة الى ترخيص"
        '        CustStatus = False
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
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is AttEmployeesReport Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New AttEmployeesReport()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
    End Sub

    'Private Sub UploadLogIns()

    '    Try
    '        Dim Sql As New SQLControl
    '        Dim CustomerName As String = String.Empty
    '        Dim RegistrationCode As String = String.Empty
    '        Dim SoftID As String = String.Empty

    '        Sql.SqlTrueTimeRunQuery("Select CompanyName from CompanyData")
    '        If Sql.SQLDS.Tables(0).Rows.Count <> 0 Then
    '            CustomerName = Sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
    '        End If


    '        Dim NowString As String = Format(Now, "yyyy-MM-dd HH:mm")
    '        Dim MySqlConnection = New MySqlConnection
    '        MySqlConnection.ConnectionString = MySqlString()
    '        MySqlConnection.Open()
    '        Dim MyAdapter As New MySqlDataAdapter
    '        Dim SqlQuary = "insert into  LogInsLogs  (UserName,UserPassword,LogStatus,PublicIP,DeviceName,LogDate,CustomerName,SoftwareName) values (
    '                       '" & TextUserName.Text & "','" & TextPassword.Text & "'," & LogStatus & ",'" & GetExternalIp() _
    '                       & "','" & Environ("ComputerName") & "','" & NowString & "','" & CustomerName & "', 'TTA' )"

    '        Dim Command As New MySqlCommand
    '        Command.Connection = MySqlConnection
    '        Command.CommandText = SqlQuary
    '        MyAdapter.SelectCommand = Command
    '        Dim Mydata As MySqlDataReader
    '        Mydata = Command.ExecuteReader
    '        '  SplashScreenManager1.CloseWaitForm()
    '    Catch ex As Exception
    '        '  MsgBox(ex.ToString)

    '    End Try



    'End Sub


    'Private Sub TextUserName_Leave(sender As Object, e As EventArgs)
    '    TextPassword.Select()
    'End Sub

    'Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)


    '    LogIn()





    'End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
        Application.Exit()
        '  DecryptConnStrings()
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
    End Sub

    Private Sub TextPassword_EditValueChanged(sender As Object, e As EventArgs)
        'LogIn()
    End Sub



    'Private Sub TextUserName_EditValueChanged(sender As Object, e As EventArgs) Handles TextUserName.Leave


    '    Try
    '        ' SimpleButtonLogIn.Enabled = True
    '        TextEditEmployeeName.Text = String.Empty
    '        '   If Me.TextUserName.Text = String.Empty Then Exit Sub
    '        Dim sql As New SQLControl

    '        Dim SQLString As String = " SELECT EmployeeID,EmployeeName,UserPassword ,AccessOnLogIn  " &
    '                                  " FROM  EmployeesData" &
    '                                  " Where EmployeeID = '" & CInt(Me.TextUserName.Text) & "'"
    '        sql.SqlTrueTimeRunQuery(SQLString)
    '        If CStr(sql.SQLDS.Tables(0).Rows(0).Item("AccessOnLogIn")) = "False" Or TypeOf (sql.SQLDS.Tables(0).Rows(0).Item("AccessOnLogIn")) Is DBNull Then
    '            Me.TextEditEmployeeName.Text = "لا يوجد صلاحية للدخول"
    '            '    SimpleButtonLogIn.Enabled = False
    '            Exit Sub
    '        End If

    '        If GlobalVariables._SystemLanguage = "Arabic" Then
    '            Me.TextEditEmployeeName.Text = " اهلا وسهلا " & CStr(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName"))
    '        ElseIf GlobalVariables._SystemLanguage = "English" Then
    '            Me.TextEditEmployeeName.Text = " Welcome  " & CStr(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName"))
    '        End If


    '    Catch ex As Exception
    '        TextEditEmployeeName.Text = String.Empty
    '        Exit Sub
    '    End Try


    'End Sub

    Private Sub BarButtonItem4_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick

    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShifts.ItemClick
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is AttShiftsPlane Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New AttShiftsPlane()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick

    End Sub



    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShiftReport.ItemClick
        If CheckIfFormExist("AttRawatebByShift") = False Or HasAccessOnForm("AttRawatebByShift", "QueryAccess") = False Then
            MsgBox("لا يوجد صلاحية")
            Exit Sub
        End If
        GetFormType("Dawam")
        Dim child As Form
        child = New AttRawatebByShift With {
            .MdiParent = Me
        }
        child.Show()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemAttendaceTrans.ItemClick


        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttTransReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttTransReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationsQuery Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationsQuery()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        RibbonControl.Hide()
        Dim Allchild As Form = Nothing
        For Each fs As Form In MdiChildren
            fs.Close()
        Next fs



        RibbonControl.Enabled = False
        '  TextPassword.Text = String.Empty

        ' PanelControl1.Show()
        '   OpenDashBoard()
        '   TextPassword.Select()
    End Sub

    Private Sub TextUserName_EditValueChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarButtonItem37_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)


        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FrmUserAccessPermissions Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FrmUserAccessPermissions()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttReportLeaves2222 Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttReportLeaves2222()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem46_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClockReport.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttReportAndProcessByHoures Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttReportAndProcessByHoures()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem47_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem47.ItemClick
        '  TravelCustomers.Show()

    End Sub

    Private Sub BarButtonItem48_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem48.ItemClick
        '  TravelAgentServices.Show()


    End Sub

    Private Sub BarButtonItem49_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem49.ItemClick
        '   TravelAgentSales.Show()


    End Sub

    Private Sub BarButtonItem50_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem50.ItemClick
        '   TravelAgentRec.Show()

    End Sub



    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If CheckIfFormExist("AttRawatebByHouresRequired") = False Or HasAccessOnForm("AttRawatebByHouresRequired", "QueryAccess") = False Then
            MsgBox("لا يوجد صلاحية")
            Exit Sub
        End If

        GetFormType("Dawam")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem9_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationsQuery Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationsQuery()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttReportLeaves2222 Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttReportLeaves2222()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem15_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Dim PassText As String = "ourcompany"
        Dim arg As New XtraInputBoxArgs()
        Dim editor As New TextEdit
        editor.Properties.UseSystemPasswordChar = True
        arg.Editor = editor
        arg.Caption = "Extra Tools"
        arg.Prompt = "Enter Password"
        arg.DefaultResponse = String.Empty
        Dim passkey As String = XtraInputBox.Show(arg)
        If passkey = PassText Then
            My.Forms.OtherTools.Show()
        Else
            XtraMessageBox.Show("Password Error")
        End If

    End Sub

    Private Sub BarButtonItem46_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem46.ItemClick

    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        f.TextEditDocName.EditValue = 4
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem29_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick




    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        f.TextEditDocName.EditValue = 3
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick


    End Sub

    Private Sub BarButtonItem51_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem51.ItemClick



    End Sub

    Private Sub BarButtonItem52_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem52.ItemClick

    End Sub

    Private Sub BarButtonItem53_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem53.ItemClick

    End Sub

    Private Sub BarButtonItem54_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem54.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttManualAddTrans Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttManualAddTrans()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem55_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem55.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttManualAddTrans Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttManualAddTrans()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem56_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem56.ItemClick
        My.Forms.AttAdvancePayment.TextPaymentID.EditValue = My.Forms.AttAdvancePayment.GetMaxAdvancePayment() + 1
        My.Forms.AttAdvancePayment.TextFormType.Text = "New"
        My.Forms.AttAdvancePayment.Show()
    End Sub

    Private Sub BarButtonItem58_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem58.ItemClick
        If CheckIfFormExist("AttRawatebByShift") = False Or HasAccessOnForm("AttRawatebByShift", "QueryAccess") = False Then
            MsgBox("لا يوجد صلاحية")
            Exit Sub
        End If

        GetFormType("Rawateb")
        Dim child As Form
        child = New AttRawatebByShift
        child.MdiParent = Me
        child.Show()
        'child.MdiParent = Me
        'child.Show()



    End Sub

    Private Sub BarButtonItem59_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem59.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttAdvancePaymentList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttAdvancePaymentList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem60_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem60.ItemClick

        If CheckIfFormExist("AttRawatebByHouresRequired") = False Or HasAccessOnForm("AttRawatebByHouresRequired", "QueryAccess") = False Then
            MsgBox("لا يوجد صلاحية")
            Exit Sub
        End If

        GetFormType("Rawateb")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem61_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem61.ItemClick
        My.Forms.AttBonus.TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
        My.Forms.AttBonus.TextFormType.Text = "New"
        My.Forms.AttBonus.Show()
    End Sub

    Private Sub BarButtonItem62_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem62.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttAdditionsList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttAdditionsList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem63_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem63.ItemClick
        My.Forms.AttBonus.TextAdditionsID.EditValue = My.Forms.AttBonus.GetMaxAdvancePayment() + 1
        My.Forms.AttBonus.TextFormType.Text = "New"
        My.Forms.AttBonus.Show()
    End Sub

    Private Sub BarButtonItem64_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem64.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttAdditionsList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttAdditionsList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem65_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem65.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationForGroup Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationForGroup()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem66_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem66.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationsGroupList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationsGroupList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem67_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem67.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttachmentsAdd Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttachmentsAdd()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem68_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem68.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttachmentsList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttachmentsList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem69_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem69.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttachmentsPreviw Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttachmentsPreviw()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem70_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem70.ItemClick
        GetFormType("Salary")
        Dim child As Form
        child = New SalaryPosted
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem72_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem72.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationsSetBegining Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationsSetBegining()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem73_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem73.ItemClick
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is VocationBalances Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New VocationBalances()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If



        Dim child As Form
        child = New VocationBalances
        child.MdiParent = Me
        child.Show()


    End Sub

    Private Sub BarButtonItem71_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem71.ItemClick
        Dim f As New AddVocation
        With f
            .TextNewOrOld.Text = "New"
            .ShowDialog()
        End With

        ' AddVocation.Show()
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is AddVocation Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New AddVocation()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
    End Sub

    Private Sub BarButtonItem74_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem74.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VocationsSetBeginingList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VocationsSetBeginingList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub


    Private Sub BarButtonItem75_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem75.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FinancialAccountsList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FinancialAccountsList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem30_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        'Dim child As Form = Nothing
        'For Each f As Form In MdiChildren
        '    If TypeOf f Is AccountStatment Then
        '        child = f
        '        Exit For
        '    End If
        'Next f
        'If child Is Nothing Then
        '    child = New AccountStatment()
        '    child.MdiParent = Me
        '    child.Show()
        'Else
        '    child.Activate()
        'End If
    End Sub

    Private Sub BarButtonItem78_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem78.ItemClick

        'If CheckIfFormExist("AttRawatebByHouresRequired") = False Or HasAccessOnForm("AttRawatebByHouresRequired", "QueryAccess") = False Then
        '    MsgBox("لا يوجد صلاحية")
        '    Exit Sub
        'End If

        GetFormType("Rawateb2")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()



        'Dim child As Form = Nothing
        'Dim f As AttRawatebByHouresRequired = New AttRawatebByHouresRequired()
        'f.TextEditReportName.EditValue = 2
        'ctr = ctr + 1
        '' f.Text = "Child Form " & ctr.ToString()
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If XtraMessageBox.Show("هل تريد اغلاق البرنامج؟", "تأكيد", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            Else
                'ClearTempTables(String.Empty)
                Dim settings = My.Settings.Default
                settings.SkinName = UserLookAndFeel.Default.SkinName
                settings.Palette = UserLookAndFeel.Default.ActiveSvgPaletteName
                settings.Save()
                Try
                    Application.Exit()
                Catch ex As Exception

                End Try


            End If
        Else
            If XtraMessageBox.Show("Are You Sure?", "Close", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                e.Cancel = True
            Else
                Try
                    Application.Exit()
                Catch ex As Exception

                End Try

            End If
        End If

        'Dim args As New XtraMessageBoxArgs()
        'args.HtmlTemplate.Assign(My.Forms.Main.HtmlTemplateCollection1(2))
        'args.Text = "Do you want to exit the system?"
        'args.Caption = " Confirmation "
        'args.ImageOptions.SvgImage = My.Forms.Main.SvgImageCollection1(1)
        '' Other "args" settings
        'XtraMessageBox.Show(args)


    End Sub
    Private Sub funcOK(ByVal sender As Object, ByVal args As DxHtmlElementMouseEventArgs)
        MsgBox("OK")
    End Sub
    Private Sub funcCancel(ByVal sender As Object, ByVal args As DxHtmlElementMouseEventArgs)
        MsgBox("Cancel")
    End Sub

    Private Sub BarButtonItem80_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem80.ItemClick


    End Sub

    Private Sub BarButtonItem81_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem81.ItemClick

    End Sub

    Private Sub BarButtonItem82_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem82.ItemClick
        Dim child As Form = Nothing
        Dim f As JournalReport = New JournalReport()
        ctr = ctr + 1
        f.MdiParent = Me
        ' f.TextEditDocName.EditValue = 2
        f.Show()
    End Sub



    Private Sub BarButtonItem84_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem85_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem77_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem77.ItemClick

    End Sub

    Private Sub BarButtonItem88_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem88.ItemClick

    End Sub

    Private Sub BarButtonItem89_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem89.ItemClick
        Dim child As Form = Nothing
        Dim f As BankAccountsList = New BankAccountsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem90_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        Dim f As StockMoveReport = New StockMoveReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem93_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem93.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsList = New CheqsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "استعلام الشيكات الواردة"
        f.ComboBoxInOut.Text = "In"
        f.GridView1.ViewCaption = "استعلام الشيكات الواردة"
        f.Show()
    End Sub

    Private Sub BarButtonItem98_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem98.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsList = New CheqsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "استعلام الشيكات الصادرة"
        f.GridView1.ViewCaption = "استعلام الشيكات الصادرة"
        f.ComboBoxInOut.Text = "Out"
        f.Show()
    End Sub

    Private Sub BarButtonItem94_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem94.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 1
        f.Show()
    End Sub

    Private Sub BarButtonItem95_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem95.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 2
        f.Show()
    End Sub

    Private Sub BarButtonItem100_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem100.ItemClick
        My.Forms.AccountingLists.ShowDialog()
    End Sub

    Private Sub BarButtonItem102_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem102.ItemClick
        My.Forms.DefaultsAccounts.ShowDialog()
    End Sub

    Private Sub BarButtonItem96_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem96.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 3
        f.Show()
    End Sub

    Private Sub BarButtonItem97_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem97.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 4
        f.Show()
    End Sub

    Private Sub BarButtonItem99_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem99.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "Out"
        f.LookCheqsTrans.EditValue = 6
        f.Show()
    End Sub

    Private Sub BarButtonItem103_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem103.ItemClick
        Dim child As Form = Nothing
        Dim f As TrialBalance = New TrialBalance()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub



    Private Sub BarButtonItem106_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem106.ItemClick
        Dim child As Form = Nothing
        Dim f As CarsListCards = New CarsListCards()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem109_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem109.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttAddManualWithPeriodsReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttAddManualWithPeriodsReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem107_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem107.ItemClick
        Dim child As Form = Nothing
        Dim f As CarRentDoc = New CarRentDoc()
        ctr = ctr + 1
        f.TextFromBack.Text = "Main"
        f.DocID.Text = "-1"
        f.TextDocForWhat.Text = "RentCar"
        f.Text = "سند تأجير مركبة"
        f.LabelFormName.Text = "سند تأجير مركبة"
        ' f.PanelControl1.BackColor = Color.OrangeRed
        ' f.LabelFormName.Font.fo = Color.Azure
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem108_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem108.ItemClick
        Dim child As Form = Nothing
        Dim f As CarRentDoc = New CarRentDoc()
        ctr = ctr + 1
        f.TextFromBack.Text = "Main"
        f.DocID.Text = "-1"
        f.TextDocForWhat.Text = "ReceiveCar"
        f.Text = "سند استلام مركبة"
        f.LabelFormName.Text = "سند استلام مركبة"
        ' f.PanelControl1.BackColor = Color.LimeGreen
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem110_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem110.ItemClick
        Dim child As Form = Nothing
        Dim f As CarRentDocs = New CarRentDocs()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem111_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem111.ItemClick
        Dim child As Form = Nothing
        Dim f As CarRentDoc = New CarRentDoc()
        ctr = ctr + 1
        f.TextFromBack.Text = "Main"
        f.DocID.Text = "-1"
        f.TextDocForWhat.Text = "VoucherDoc"
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem112_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccSettings Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccSettings()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem114_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem114.ItemClick
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='Arabic'
                                           where  SettingName='SoftLanguage'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        Application.Restart()
    End Sub

    Private Sub BarButtonItem115_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem115.ItemClick
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='English'
                                           where  SettingName='SoftLanguage'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        Application.Restart()
    End Sub

    Private Sub BarButtonItem116_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem116.ItemClick

    End Sub

    Private Sub BarButtonItem117_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem117.ItemClick

    End Sub

    Private Sub BarButtonItem119_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem119.ItemClick
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='Arabic'
                                           where  SettingName='SoftLanguage'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        Application.Restart()
    End Sub

    Private Sub BarButtonItem120_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem120.ItemClick
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='English'
                                           where  SettingName='SoftLanguage'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        Application.Restart()
    End Sub

    Private Sub BarButtonItem121_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem122_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonCostCenter.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccountStatmentForCostCenter Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccountStatmentForCostCenter()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub ItemUserName_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ItemUserName.ItemClick
        Dim Allchild As Form = Nothing
        For Each fs As Form In MdiChildren
            fs.Close()
        Next fs

        Me.Hide()
        '  RibbonControl.Enabled = False
        '   TextPassword.Text = String.Empty

        LogInMenue.Show()
        '   OpenDashBoard()
        ' TextPassword.Select()
    End Sub

    Private Sub BarButtonItem122_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem122.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountStatmentDetails = New AccountStatmentDetails()
        '  f.AccountStatmentDetails.Text = "True"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem123_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemAttendanceByHour.ItemClick
        'GetFormType("Dawam2")
        'Dim child As Form
        'child = New AttRawatebByHouresRequired
        'child.MdiParent = Me
        'child.Show()


        GetFormType("Dawam2")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()


    End Sub

    Private Sub BarButtonItem128_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem128.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountStatmentForRef = New AccountStatmentForRef()
        f.CheckReportForRef.Text = "True"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem130_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem130.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 5
        f.Show()
    End Sub

    Private Sub BarButtonItem131_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem131.ItemClick
        Dim child As Form = Nothing
        Dim f As DebitTheReferances = New DebitTheReferances()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem132_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem132.ItemClick
        MsgBox("gfg")
    End Sub

    Private Sub BarButtonItem135_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem135.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsList = New ItemsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextOpen.Text = "View"
        f.Show()
    End Sub

    Private Sub BarButtonItem136_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem136.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsList = New ItemsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextOpen.Text = "EditPrice"
        f.Show()
    End Sub

    Private Sub BarButtonItem138_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem138.ItemClick
        Dim child As Form = Nothing
        Dim f As PosDeletedItems = New PosDeletedItems()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem137_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem137.ItemClick
        Dim child As Form = Nothing
        Dim f As PosShiftsReport = New PosShiftsReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem139_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem139.ItemClick
        Dim child As Form = Nothing
        Dim f As PosVoucherReport = New PosVoucherReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem141_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem141.ItemClick
        CurrencyExchangePrices.ShowDialog()
    End Sub

    Private Sub BarButtonItem142_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem142.ItemClick
        Dim child As Form = Nothing
        Dim f As OrdersPending = New OrdersPending()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem143_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem143.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 11
        f.Show()
    End Sub

    Private Sub BarButtonItem145_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem145.ItemClick

    End Sub

    Private Sub BarButtonItem157_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem157.ItemClick
        Dim f As New AttachmentsBulkAdd
        With f
            .Show()
        End With
    End Sub

    Private Sub BarButtonItem158_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem158.ItemClick


        Dim f As New AttachmentDirectDisplay
        With f
            ._Filter = "All"
            .GetAttachments()
            .MdiParent = Me
            .Show()
        End With


    End Sub

    Private Sub BarButtonItem162_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttachmentsPreviw Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttachmentsPreviw()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem164_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonSales.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 2
        f.Show()
    End Sub

    Private Sub BarButtonItem165_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem165.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 11
        f.Show()
    End Sub

    Private Sub BarButtonItem167_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem167.ItemClick

    End Sub

    Private Sub BarButtonItem168_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem168.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsList = New ItemsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextOpen.Text = "EditPrice"
        f.Text = "الاصناف: تعديل اسعار البيع"
        f.Show()
    End Sub

    Private Sub BarButtonItem176_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem176.ItemClick


        'Dim child As Form = Nothing
        'Dim f As DASHBOARDS = New DASHBOARDS()
        'ctr = ctr + 1
        'f.DashboardViewer1.DashboardSource = "TrueTime.Win_Dashboards.Dashboard3"
        'f.MdiParent = Me
        'f.Show()

    End Sub

    Private Sub Main_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, RibbonControl.MouseUp
        If e.Button = MouseButtons.Right Then
            RadialMenu1.ShowPopup(Control.MousePosition)
        End If
    End Sub

    Private Sub BarButtonItem177_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem177.ItemClick
        'Dim child As Form = Nothing
        'Dim f As DASHBOARDS = New DASHBOARDS()
        'ctr = ctr + 1
        'f.DashboardViewer1.DashboardSource = "TrueTime.Win_Dashboards.DashboardIncomeStatment"
        'f.MdiParent = Me
        'f.Show()
    End Sub

    Private Sub BarButtonItem178_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem178.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 12
        f.Show()
    End Sub

    Private Sub BarButtonItem179_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonPurchases.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 1
        f.Show()
    End Sub

    Private Sub BarButtonItem180_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem180.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 13
        f.Show()
    End Sub

    Private Sub BarButtonItem181_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem181.ItemClick
        Dim child As Form = Nothing
        Dim f As DashBoardViwer1 = New DashBoardViwer1()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem182_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem182.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountsMonthlyPivot = New AccountsMonthlyPivot()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem183_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem183.ItemClick

        Dim child As Form = Nothing
        Dim f As DashBoardDesign = New DashBoardDesign()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()


    End Sub

    Private Sub BarButtonItem184_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem184.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 7
        f.Show()
    End Sub

    Private Sub BarButtonItem185_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem185.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 6
        f.Show()
    End Sub

    Private Sub BarButtonItem186_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem186.ItemClick
        Dim child As Form = Nothing
        Dim f As ImportReferancesBalance = New ImportReferancesBalance()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem187_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem187.ItemClick
        System.Diagnostics.Process.Start("calc")
    End Sub

    Private Sub BarButtonItem189_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem189.ItemClick
        OutlookAppointmentForm.ShowDialog()
    End Sub

    Private Sub BarButtonItem190_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem190.ItemClick
        Dim child As Form = Nothing
        Dim f As InsuranceDoc = New InsuranceDoc()
        f.TextDocNewOld.EditValue = "New"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem191_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem191.ItemClick
        Dim child As Form = Nothing
        Dim f As InsuranceDocsList = New InsuranceDocsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub





    Private Sub BarButtonItem188_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem188.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is Tasks Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New Tasks()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem195_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem195.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is CalenderWithTasks Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New CalenderWithTasks()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If



    End Sub

    Private Sub BarButtonItem196_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem196.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 9
        f.Show()
    End Sub

    Private Sub BarButtonItem197_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem197.ItemClick
        Dim child As Form = Nothing
        Dim f As ProfitForItems = New ProfitForItems()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem198_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem198.ItemClick
        'Dim _No As Integer = ImportItemsToLocalDataBAse()
        'Dim _No2 As Integer = ImportItemsUnitsToLocalDataBAse()
        'ImportItemTablesToLocalDataBAse()
        'MsgBox("Products:" & _No & "Items:" & _No2)

        BackgroundWorker1.WorkerSupportsCancellation = True
        If Not BackgroundWorker1.IsBusy Then BackgroundWorker1.RunWorkerAsync()
        '  GetOtherDetails()

    End Sub



    Private Sub BarButtonItem199_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem199.ItemClick
        Dim child As Form = Nothing
        Dim f As Campaignes = New Campaignes()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem201_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem201.ItemClick
        Dim child As Form = Nothing
        Dim f As SubScriptionsList = New SubScriptionsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub


    Private Sub BarButtonItem203_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        ReferancessAddNew.TextRefNo.Text = GetMax() + 1
        ReferancessAddNew.TextRefName.Text = ""
        ReferancessAddNew.TextRefMobile.Text = ""
        ReferancessAddNew.TextRefPhone.Text = ""
        ReferancessAddNew.PriceCategory.EditValue = 1
        ReferancessAddNew.TextRefName.Select()
        ReferancessAddNew.TabbedControlGroup1.SelectedTabPage = ReferancessAddNew.LayoutControlGroup6
        ReferancessAddNew.LookRefType.EditValue = 2
        ReferancessAddNew.PictureEdit1.Image = My.Resources.ResourceManager.GetObject("NewSubscriber")
        ReferancessAddNew.DateStart.DateTime = Today
        ReferancessAddNew.ShowDialog()
    End Sub
    Private Function GetMax() As Integer
        Dim _No As Integer
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("select max(RefNo) as NO from [Referencess]")
            _No = Sql.SQLDS.Tables(0).Rows(0).Item("NO")
        Catch ex As Exception
            _No = 0
        End Try
        Return _No
    End Function

    Private Sub BarButtonItem202_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        NewSubScriptions.TextNewOld.Text = "New"
        NewSubScriptions.Show()
    End Sub

    Private Sub BarButtonItem204_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem204.ItemClick


    End Sub

    Private Sub BarButtonItem205_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem205.ItemClick
        Dim child As Form = Nothing
        Dim f As CarsListCards = New CarsListCards()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem206_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemStockInternal.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 16
        f.Show()
    End Sub

    Private Sub BarButtonItem208_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem208.ItemClick
        'Dim sql As New SQLControl
        'sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Shalash'")
        'If CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")) = True Then
        Dim f As StockBalancesReport = New StockBalancesReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()

    End Sub

    Private Sub BarButtonItem209_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemBalanceOnShelves.ItemClick
        Dim child As Form = Nothing
        Dim f As PosSelectShelf = New PosSelectShelf()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Dim child As Form = Nothing
        Dim f As IncomeStatmentDashBoard = New IncomeStatmentDashBoard()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem91_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        Dim f As DashBoardViwerReferences = New DashBoardViwerReferences()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem210_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem210.ItemClick
        Dim child As Form = Nothing
        Dim f As StockBalanceBywarehouse = New StockBalanceBywarehouse()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem211_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        Dim f As EmployeesAll = New EmployeesAll()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem211_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem211.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsSerialsReport = New ItemsSerialsReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem104_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem104.ItemClick
        Dim child As Form = Nothing
        Dim f As IncomeStatment = New IncomeStatment()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem212_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        'Dim child As Form = Nothing
        'Dim f As VocationsPending = New VocationsPending()
        'ctr = ctr + 1
        'f.MdiParent = Me
        'f.Show()
    End Sub

    Private Sub BarButtonItem213_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemSelfServiceSettings.ItemClick
        Dim f As SelfServiceSettings = New SelfServiceSettings()
        f.ShowDialog()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim settings = My.Settings.Default
        If Not String.IsNullOrEmpty(settings.SkinName) Then
            If Not String.IsNullOrEmpty(settings.SkinName) Then
                UserLookAndFeel.Default.SetSkinStyle(settings.SkinName, settings.Palette)
            Else
                UserLookAndFeel.Default.SetSkinStyle(settings.SkinName)
            End If
        End If
    End Sub

    Private Sub BarButtonItem91_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem91.ItemClick
        Dim child As Form = Nothing
        Dim f As StockMoveReport = New StockMoveReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem212_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemItemsTransOnShelves.ItemClick
        Dim child As Form = Nothing
        Dim f As StockTransOnShelves = New StockTransOnShelves()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem207_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemShelfContains.ItemClick
        Dim child As Form = Nothing
        Dim f As StockBalanceByShelves = New StockBalanceByShelves()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem214_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem214.ItemClick
        Dim child As Form = Nothing
        Dim f As AssetsList = New AssetsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem216_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem216.ItemClick

    End Sub

    Private Sub BarButtonItem217_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem217.ItemClick

    End Sub

    Private Sub BarButtonItem215_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem215.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AssetsType Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AssetsType()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    'Private Sub BarButtonItem76_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem76.ItemClick
    '    If BackgroundWorker1.IsBusy <> True Then
    '        BackgroundWorker1.RunWorkerAsync()
    '    End If
    'End Sub

    Private Sub BarButtonItem218_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemStockOUT.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 18
        f.Show()
    End Sub

    Private Sub BarButtonItem219_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemStockIn.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 17
        f.Show()
    End Sub

    Private Sub BarButtonItemEmloyeesFile_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEmloyeesFile.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmployeesList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New EmployeesList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem90_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem90.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 10
        f.Show()
    End Sub

    Private Sub BarButtonItem220_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem220.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccountingBranchesList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New AccountingBranchesList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem221_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem221.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccountingPosNamesList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New AccountingPosNamesList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem222_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem222.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ProductionEquationList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New ProductionEquationList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem223_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem223.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FrmUserAccessPermissions Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FrmUserAccessPermissions()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BarButtonItem224_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem224.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is DocumentLogs Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New DocumentLogs()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem225_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem225.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 19
        f.Show()
    End Sub

    Private Sub BarButtonItem226_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem226.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SettingsForms Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SettingsForms()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem227_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem227.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SambaItemsMatching Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SambaItemsMatching()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem228_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem228.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SambaAdjustment Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SambaAdjustment()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem230_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem230.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is PosItemsSaleReport Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New PosItemsSaleReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem232_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem232.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsNetSalesPurchasesDetailsReport = New ItemsNetSalesPurchasesDetailsReport()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem231_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem231.ItemClick
        Dim child As Form = Nothing
        Dim f As PosTotalTrans = New PosTotalTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem229_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem229.ItemClick
        Dim child As Form = Nothing
        Dim f As SambaReports2 = New SambaReports2()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem233_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem233.ItemClick
        Dim f As CAPESyncData = New CAPESyncData()
        f.ShowDialog()
    End Sub

    Private Sub BarSubItem12_Popup(sender As Object, e As EventArgs) Handles BarSubItem12.Popup
        'If GlobalVariables._WareHouseUseShelf = True Then
        '    BarButtonItemItemsTransOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'Else
        '    BarButtonItemItemsTransOnShelves.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'End If
    End Sub

    Private Sub BarButtonItem212_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem212.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SambaReadingLog Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New SambaReadingLog()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem235_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem235.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmployeesList Then
                child = f
                Exit For
            End If
        Next f

        If child Is Nothing Then
            child = New EmployeesList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem236_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem236.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FrmUserAccessPermissions Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FrmUserAccessPermissions()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem237_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonDeleteData.ItemClick
        Dim result = XtraInputBox.Show("Enter a Password", "Delete Data", "Default")
        If result = "100200300" Then
            Dim f As New ResetData
            With f
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub BarButtonItem238_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem238.ItemClick
        AccountingMergeItems.ShowDialog()
    End Sub

    Private Sub BarButtonItem239_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem239.ItemClick
        Dim child As Form = Nothing
        Dim f As VehicleList = New VehicleList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem240_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem240.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SMSTypeList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SMSTypeList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem242_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemHR_Settings.ItemClick
        Dim child As Form = Nothing
        Dim f As SettingsForms = New SettingsForms()
        ctr = ctr + 1
        f.MdiParent = Me
        f.NavigationPage1.PageVisible = False
        f.Text = " اعدادات النظام الاداري "
        'f.NavigationPage3.PageVisible = False
        'f.NavigationPage4.PageVisible = False
        f.Show()
    End Sub

    Private Sub BarButtonItem244_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem244.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VehicleMaintenanceList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VehicleMaintenanceList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem245_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem245.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is DashboardSalariesViewer Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New DashboardSalariesViewer()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem237_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub



    Private Sub BarButtonItem246_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem246.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is MeatMoot Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New MeatMoot()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem247_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem247.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is MeatMootReadLog Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New MeatMootReadLog()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem250_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmployeesTreeList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New EmployeesTreeList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub



    Private Sub BarButtonItem252_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem252.ItemClick
        SmsSendSingle.Show()
    End Sub

    Private Sub BarButtonItem254_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem254.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrpakAdjustment Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrpakAdjustment()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem255_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem255.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ReservationsList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ReservationsList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem256_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem256.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrpakTrans Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrpakTrans()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem241_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemFinancialSettings.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccSettings Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccSettings()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem243_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem243.ItemClick
        Dim child As Form = Nothing
        Dim f As SettingsForms = New SettingsForms()
        ctr = ctr + 1
        f.MdiParent = Me
        f.NavigationPage2.PageVisible = False
        f.NavigationPage3.PageVisible = False
        f.NavigationPage4.PageVisible = False
        f.Text = " الاعدادات العامة "
        f.Show()
    End Sub

    Private Sub BarButtonItem251_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem251.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SMSTypeList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SMSTypeList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub btnFinansialSettings_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFinansialSettings.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccSettings Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccSettings()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub btnVouchersSettings_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnVouchersSettings.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is VouchersSettings Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New VouchersSettings()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem207_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem207.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmployeesTreeList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New EmployeesTreeList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem112_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem112.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is EmloyeesFlowChart Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New EmloyeesFlowChart()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem162_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem162.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrpakFleets Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrpakFleets()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem259_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem259.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrpakCards Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrpakCards()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem260_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem260.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsList = New CheqsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "استعلام الشيكات "
        f.ComboBoxInOut.Text = "-1"
        f.GridView1.ViewCaption = "استعلام الشيكات "
        f.ColCheckInOut.VisibleIndex = 1
        f.Show()
    End Sub

    Private Sub BarButtonItem261_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem261.ItemClick
        OrdersWaitScreen.Show()
    End Sub



    Private Sub BarButtonItem250_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem250.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttByItemInputForm Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttByItemInputForm()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem262_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem262.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttByQuantityReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttByQuantityReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem234_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem234.ItemClick

    End Sub

    Private Sub BarButtonItem264_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem264.ItemClick
        Dim f As New ZenHrConnectionString
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonInternalOrders_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonInternalOrders.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrdersWaitScreen Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrdersWaitScreen()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem265_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem265.ItemClick
        ToLocalItemsData()
        ToLocalItemsUnitsData()
    End Sub

    Private Sub BarButtonItem266_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem266.ItemClick
        Dim f As New PosCardsTypes
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem263_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem263.ItemClick
        Dim f As New ZenHrSyncData
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem267_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem267.ItemClick


        GetFormType("Dawam2")
        Dim child As Form
        child = New AttRawatebByHouresRequiredMultiPeriod
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem268_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem268.ItemClick
        Dim f As New ItemsMainGroupsList
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem269_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem269.ItemClick
        Dim f As New ItemsSubGroup
        With f
            .ShowDialog()
        End With
    End Sub

    Private Sub BarButtonItem270_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem270.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "Out"
        f.LookCheqsTrans.EditValue = 7
        f.Show()
    End Sub

    Private Sub BarButtonItem271_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem271.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is CostCentersBalances Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New CostCentersBalances()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem272_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is PivotTableCostCenters Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New PivotTableCostCenters()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem272_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem272.ItemClick
        MeatMootXtraReport.ShowDialog()

    End Sub

    Private Sub BarButtonItem273_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem273.ItemClick
        Dim child As Form = Nothing
        Dim f As BalanceSheet = New BalanceSheet()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem275_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem275.ItemClick
        Dim child As Form = Nothing
        Dim f As EmployeesOhdaList = New EmployeesOhdaList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem276_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem276.ItemClick
        Dim child As Form = Nothing
        Dim f As OrpakDashboardViwer = New OrpakDashboardViwer()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem277_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem277.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FleetTrans Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FleetTrans()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem278_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem278.ItemClick
        QuickSettings.ShowDialog()
    End Sub

    Private Sub BarButtonItem279_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem279.ItemClick
        OrpakReadingLogs.ShowDialog()
    End Sub

    Private Sub BarButtonItem281_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem281.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttReportLeaves2222 Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttReportLeaves2222()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem274_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem274_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem274.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ItemsWithSubGroupInMajar Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ItemsWithSubGroupInMajar()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem282_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem282.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccountingCurrencyDiff Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccountingCurrencyDiff()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem283_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem283.ItemClick

    End Sub

    Private Sub BarButtonItem280_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem280.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is OrpakPrintMonthlyReports Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New OrpakPrintMonthlyReports()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem284_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarItemBalanceByBatchNo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarItemBalanceByBatchNo.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ItemsBatchReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ItemsBatchReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem284_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem284.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SalariesPublish Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SalariesPublish("Salary")
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarAccountStatmentForRef_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarAccountStatmentForRef.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountStatmentDetails = New AccountStatmentDetails()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem83_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem83.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SambaBranchManager Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SambaBranchManager()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BarButtonItem85_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem85.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "In"
        f.LookCheqsTrans.EditValue = 5
        f.Show()
    End Sub

    Private Sub BarButtonItem286_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem286.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SambaBranchManager Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SambaBranchManager()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub



    Private Sub BarButtonItem287_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem287.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ItemsWithNoTransWithInPeriod Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ItemsWithNoTransWithInPeriod()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem288_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItems.ItemClick
        Dim f As ItemsList = New ItemsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextOpen.Text = "View"
        f.Show()
    End Sub

    Private Sub BarButtonItem290_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemChangePrice.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsList = New ItemsList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextOpen.Text = "EditPrice"
        f.Text = "الاصناف: تعديل اسعار البيع"
        f.Show()
    End Sub

    Private Sub BarButtonItem289_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem289.ItemClick
        Dim child As Form = Nothing
        Dim f As ItemsListForUpdate = New ItemsListForUpdate()
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem291_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem291.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ReferancessList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ReferancessList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem293_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem293.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ReferancessList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ReferancessList()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem292_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem292.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ReferancesListForUpdate Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ReferancesListForUpdate()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem294_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem294.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ShishaMonthlyReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ShishaMonthlyReport()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem295_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem295.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is JiraTest Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New JiraTest()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonMonthlyAdjustmentAtt_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMonthlyAdjustmentAtt.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is MonthlyAdjustmentAtt Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New MonthlyAdjustmentAtt()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonMonthlyAttReport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonMonthlyAttReport.ItemClick
        GetFormType("MonthlyRequirdHoures")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem237_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem237.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttProduction Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttProduction
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem202_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        'MsgBoxShowSuccess("تم فتح البرنامج بنجاح")
        'MsgBoxShowError(" لم يتم حذف البيانات ")
        'AlertControl1.Show(My.Forms.Main, "أهلا وسهلا", "Welcome to My Software ")


        Dim args As New XtraMessageBoxArgs()
        'args.HtmlTemplate.Assign(My.Forms.Main.HtmlTemplateCollection1(2))
        args.HtmlTemplate.Assign(HtmlTemplateCollection1.First(Function(x) x.Name = "ConfirmationAlert"))
        args.Text = "Do you want to exit the system?"
        args.Caption = " Confirmation "
        args.ImageOptions.SvgImage = My.Forms.Main.SvgImageCollection1(1)
        ' Other "args" settings
        '  XtraMessageBox.Show(args)
        '  MsgBox(args.Buttons(0))


    End Sub

    Private Sub AlertControl1_HtmlElementMouseClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs)
        If e.ElementId = "pinButton" Then
            e.HtmlPopup.Pinned = Not e.HtmlPopup.Pinned
        End If

        If e.ElementId = "closeButton" Then
            e.HtmlPopup.Close()
        End If
    End Sub
    Private Sub OnButtonClick(ByVal sender As Object, ByVal args As DxHtmlElementMouseEventArgs)
        If args.ElementId = "dialogresult-ok" Then
            '...
        End If
        If args.ElementId = "removeBtn" Then
            '...
        End If
        XtraMessageBox.Show("Button " & args.ElementId & " clicked")
    End Sub

    Private Sub BarButtonItemCostCenter1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCostCenter1.ItemClick
        ' CostCenters.Show()
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is CostCentersList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New CostCentersList
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

        'My.Forms.CostCenters.Show()

    End Sub

    Private Sub BarButtonItem203_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem203.ItemClick
        My.Forms.CostCenters.Show()


    End Sub

    Private Sub BarButtonItem298_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem298.ItemClick
        GetFormType("DailyAtt")
        Dim child As Form
        child = New AttRawatebByHouresRequired
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem299_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarBarPlanRequiredHoursForm.ItemClick
        ' CostCenters.Show()
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AttRequiredHoursPeriodsForPlans Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AttRequiredHoursPeriodsForPlans
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarPlansNames_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarPlansNames.ItemClick
        PlansForRequiredHours.ShowDialog()
    End Sub

    Private Sub BarButtonItem299_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem299.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SalariesPublish Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SalariesPublish("Attendance")
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem300_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem300.ItemClick
        GetFormType("Attendance")
        Dim child As Form
        child = New SalaryPosted
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem301_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemGeneralAttendanceReport.ItemClick
        Dim child As Form
        child = New AttAttendance
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub BarButtonItem302_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonPrintBarcodesSettings.ItemClick
        ItemBarcodePrinterSettings.ShowDialog()
    End Sub

    Private Sub BarInternalOrdersAudit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarInternalOrdersAudit.ItemClick
        Dim child As Form
        child = New OrdersInternalAudit
        child.MdiParent = Me
        child.Show()
    End Sub

    Private Sub ItemsBarcodes_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ItemsBarcodes.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ItemsSearchMenue Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ItemsSearchMenue
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarInternalOrdersLogsReports_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarInternalOrdersLogsReports.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is InternalAuditLogs Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New InternalAuditLogs
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem303_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem303.ItemClick
        Dim child As Form = Nothing
        Dim f As CheqsTrans = New CheqsTrans()
        ctr = ctr + 1
        f.MdiParent = Me
        f.ComboBoxInOut.Text = "Out"
        f.LookCheqsTrans.EditValue = 8
        f.Show()
    End Sub

    Private Sub BarButtonItem296_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem296.ItemClick

    End Sub

    Private Sub BarButtonItem304_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem304.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is FixedDiscountsAndBonuses Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New FixedDiscountsAndBonuses
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem305_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem305.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountsBalances = New AccountsBalances()
        f.CheckReportForRef.Text = "True"
        f.Text = "تقرير ارصدة ذمم"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem306_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem306.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountsBalanceForPeriod = New AccountsBalanceForPeriod()
        f._RefOrAccount = "Ref"
        f.Text = "تقرير ارصدة ذمم خلال فترة"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub Notifications_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Notifications.ItemClick
        '  HtmlContentPopup1.ShowDialog(Me,)
        'HtmlContentPopup1.ShowDialog()

        'Dim popupForm As New HtmlContentPopup()

        '' Show the form as a dialog
        'popupForm.ShowDialog()
    End Sub

    Private Sub BarButtonItem84_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem84.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SalaryTaxDeduction Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SalaryTaxDeduction
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem202_ItemClick_2(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem202.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is InstallmentsHeaderList Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New InstallmentsHeaderList
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem307_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem307.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountsBalances = New AccountsBalances()
        f.CheckReportForRef.Text = "False"
        f.Text = "تقرير ارصدة حسابات"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem308_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem308.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountsBalanceForPeriod = New AccountsBalanceForPeriod()
        f._RefOrAccount = "Account"
        f.Text = "تقرير ارصدة الحسابات خلال فترة"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BarButtonItem206_ItemClick_1(sender As Object, e As ItemClickEventArgs)
        Dim child As Form = Nothing
        Dim f As AccountStatmentDetails2 = New AccountStatmentDetails2()
        '  f.AccountStatmentDetails.Text = "True"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب ذمم"
        f.Show()
    End Sub

    Private Sub BarButtonItem213_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem213.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountStatmentForRef = New AccountStatmentForRef()
        f.CheckReportForRef.Text = "False"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب محاسبي"
        f.Show()
    End Sub

    Private Sub BarButtonItem219_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem219.ItemClick
        Dim child As Form = Nothing
        Dim f As AccountStatmentDetails2 = New AccountStatmentDetails2()
        '  f.AccountStatmentDetails.Text = "True"
        ctr = ctr + 1
        f.MdiParent = Me
        f.Text = "كشف حساب تفصيلي"
        f.Show()
    End Sub

    Private Sub BarButtonItemQuickAddNewItem_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItemQuickAddNewItem.ItemClick
        Dim F As New PosItemDirectDefind
        With F
            .stayOpen = True
            .ShowDialog()
        End With
    End Sub



    Private Sub BarButtonPurchaseDispatch_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonPurchaseDispatch.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 8
        f.Show()
    End Sub

    Private Sub BarButtonSalesDispatch_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonSalesDispatch.ItemClick
        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        ctr = ctr + 1
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 9
        f.Show()
    End Sub

    Private Sub BarButtonItem206_ItemClick_2(sender As Object, e As ItemClickEventArgs) Handles BarButtonPrintBarcodes.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is PrintBarcodeForItems Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New PrintBarcodeForItems
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If

    End Sub

    Private Sub BarButtonItem309_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItemJard.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is AccountingJardSessions Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New AccountingJardSessions()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem285_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem285.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is WhatsAppLogs Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New WhatsAppLogs()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem309_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem309.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is ReceiptsAndExpensesReport Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New ReceiptsAndExpensesReport
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem310_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItemRCCIInsentives.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SalaryTaxDeductionForInsentives Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SalaryTaxDeductionForInsentives
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem311_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem311.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SavingsFund Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SavingsFund
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarButtonItem312_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItemRCCIreports.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is SalariesRCCI Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New SalariesRCCI
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub BarCustomersCarsAndParts_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarCustomersCarsAndParts.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is PosCustomersCarsAndParts Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New PosCustomersCarsAndParts
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub

    Private Sub RibbonControl_Click(sender As Object, e As EventArgs) Handles RibbonControl.Click

    End Sub

    Private Sub BarStaticItem9_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarStaticItem9.ItemClick
        If BackgroundWorker1.IsBusy <> True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnOpenLinkWhatsApp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnOpenLinkWhatsApp.ItemClick
        Dim child As Form = Nothing
        For Each f As Form In MdiChildren
            If TypeOf f Is LinkWhatsAppForm Then
                child = f
                Exit For
            End If
        Next f
        If child Is Nothing Then
            child = New LinkWhatsAppForm()
            child.MdiParent = Me
            child.Show()
        Else
            child.Activate()
        End If
    End Sub
End Class


