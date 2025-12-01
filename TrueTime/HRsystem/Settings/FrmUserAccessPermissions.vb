Imports System.Data.SqlClient
Imports System.Web
Imports DevExpress.XtraEditors

Public Class FrmUserAccessPermissions

    Private dt As DataTable
    Public connectionString As String = My.Settings.TrueTimeConnectionString

    Public Sub New()
        InitializeComponent()
        AddHandler RepositoryItemButtonEdit1.ButtonClick, AddressOf BtnEditMembers_Click
        AddHandler RepositoryItemButtonEdit2.ButtonClick, AddressOf BtnEditGroupInfo_Click
        AddHandler RepositoryItemButtonEdit3.ButtonClick, AddressOf BtnDeleteGroup_Click


        InitializeDataTable()
        SetupGridEditors()
        LoadSections()
        LoadGroups()
        UpdateTextsForGroupsTab()
        LoadGroupsData()
    End Sub

    ' ---------------- Initialize DataTable ----------------
    Private Sub InitializeDataTable()
        dt = New DataTable()
        dt.Columns.Add("GridColumnAccess", GetType(String))
        dt.Columns.Add("GridColumnAllow", GetType(Boolean))
        dt.Columns.Add("GridColumnCategory", GetType(String))
        dt.Columns.Add("GridColumnEdit", GetType(Boolean))
        dt.Columns.Add("GridColumnAdd", GetType(Boolean))
        dt.Columns.Add("GridColumnDelete", GetType(Boolean))
        dt.Columns.Add("FormId", GetType(Integer)) ' Hidden column
        GridControl1.DataSource = dt
    End Sub

    Private Sub SetupGridEditors()
        GridColumnAllow.ColumnEdit = RepositoryItemToggleSwitch1
        GridColumnEdit.ColumnEdit = RepositoryItemToggleSwitch2
        GridColumnAdd.ColumnEdit = RepositoryItemToggleSwitch3
        GridColumnDelete.ColumnEdit = RepositoryItemToggleSwitch4
    End Sub

    ' ---------------- Load ComboBox Items ----------------
    Private Sub LoadGroups()
        ComboBoxGroups.Properties.Items.Clear()
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT GroupId, GroupName FROM Groups ORDER BY GroupName", conn)
            Dim dtGroups As New DataTable()
            dtGroups.Load(cmd.ExecuteReader())
            For Each row As DataRow In dtGroups.Rows
                ComboBoxGroups.Properties.Items.Add(row("GroupName").ToString() & "|" & row("GroupId").ToString())
            Next
        End Using
        ComboBoxGroups.EditValue = Nothing
        ComboBoxGroups.SelectedIndex = -1
        ComboBoxGroups.RefreshEditValue()

    End Sub

    Private Sub LoadUsers()
        ComboBoxGroups.Properties.Items.Clear()

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim sql As String = "
            SELECT UserId, UserName, UserType
            FROM UsersSystem
            WHERE UserId NOT IN (SELECT UserId FROM GroupMembers)
        "

            ' Only filter the SQL if the current user is limited
            If UserPermission.UserType = "la" Then
                sql &= " AND UserType NOT IN ('la', 'sa')"
            End If

            sql &= " ORDER BY UserName"

            Dim cmd As New SqlCommand(sql, conn)
            Dim dtUsers As New DataTable()
            dtUsers.Load(cmd.ExecuteReader())

            For Each row As DataRow In dtUsers.Rows
                ComboBoxGroups.Properties.Items.Add($"{row("UserName")}|{row("UserId")}")
            Next
        End Using
        ComboBoxGroups.EditValue = Nothing
        ComboBoxGroups.SelectedIndex = -1

    End Sub


    ' ---------------- ComboBox Selected ----------------
    'Private Sub ComboBoxGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxGroups.SelectedIndexChanged
    '    Debug.WriteLine("ComboBoxGroups_SelectedIndexChanged triggered.")
    '    Debug.WriteLine("SelectedValue: " & If(ComboBoxGroups.EditValue, "Nothing"))

    '    If TabGroupsControl.SelectedTabPage Is XtraTabPage1 Then
    '        Dim groupId As Integer = GetSelectedGroupId()
    '        Debug.WriteLine("Active tab: Groups. Selected GroupId: " & groupId)
    '        If groupId > 0 Then LoadPermissionsForUsers()
    '    ElseIf TabGroupsControl.SelectedTabPage Is XtraTabPage2 Then
    '        Dim userId As Integer = GetSelectedUserId()
    '        Debug.WriteLine("Active tab: Users. Selected UserId: " & userId)
    '        If userId > 0 Then LoadPermissionsForUsers()
    '    End If
    'End Sub

    Private Sub ComboBoxGroups_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxGroups.SelectedIndexChanged
        LoadPermissionsForUsers()
    End Sub

    Private Sub ComboBoxSections_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSections.SelectedIndexChanged
        ' Only filter if a valid section is selected
        If ComboBoxSections.EditValue IsNot Nothing Then
            Dim selectedSection As String = ComboBoxSections.EditValue.ToString()

            ' Check which tab is active
            If TabGroupsControl.SelectedTabPage Is XtraTabPage1 Then
                Dim groupId As Integer = GetSelectedGroupId()
                If groupId > 0 Then LoadPermissionsForUsers()
            ElseIf TabGroupsControl.SelectedTabPage Is XtraTabPage2 Then
                Dim userId As Integer = GetSelectedUserId()
                If userId > 0 Then LoadPermissionsForUsers()
            End If
        End If
    End Sub

    Private Function GetSelectedGroupId() As Integer
        If ComboBoxGroups.EditValue IsNot Nothing Then
            Dim parts() As String = ComboBoxGroups.EditValue.ToString().Split("|"c)
            Debug.WriteLine("GetSelectedGroupId: parts=" & String.Join(",", parts))
            Return Convert.ToInt32(parts(1))
        End If
        Debug.WriteLine("GetSelectedGroupId: EditValue is Nothing")
        Return 0
    End Function

    Private Function GetSelectedUserId() As Integer
        If ComboBoxGroups.EditValue IsNot Nothing Then
            Dim parts() As String = ComboBoxGroups.EditValue.ToString().Split("|"c)
            Debug.WriteLine("GetSelectedUserId: parts=" & String.Join(",", parts))
            Return Convert.ToInt32(parts(1))
        End If
        Debug.WriteLine("GetSelectedUserId: EditValue is Nothing")
        Return 0
    End Function


    ' ---------------- Tab Changed ----------------
    Private Sub TabGroupsControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabGroupsControl.SelectedPageChanged
        ' 1️⃣ Clear the DataTable completely
        dt.Rows.Clear()
        dt.Clear()
        dt.AcceptChanges()

        ' 2️⃣ Reset GridControl
        GridControl1.DataSource = Nothing
        GridView1.RefreshData()

        ' 3️⃣ Reset ComboBox
        ComboBoxGroups.Properties.Items.Clear()
        ComboBoxGroups.EditValue = Nothing
        ComboBoxGroups.SelectedIndex = -1
        ComboBoxGroups.RefreshEditValue()

        ' 4️⃣ Re-parent the layout control
        LayoutControl1.Parent = TabGroupsControl.SelectedTabPage
        LayoutControl1.Dock = DockStyle.Fill

        ' 5️⃣ Load the appropriate data for the selected tab
        If TabGroupsControl.SelectedTabPage Is XtraTabPage1 Then
            LoadGroups()
            UpdateTextsForGroupsTab()
        ElseIf TabGroupsControl.SelectedTabPage Is XtraTabPage2 Then
            LoadUsers()
            UpdateTextsForUsersTab()
        End If
    End Sub


    ' ---------------- Load Permissions ----------------

    Public Function LoadPermissionsForUsers() As Object
        Dim res As New Dictionary(Of String, Object)()
        Dim items As New List(Of Dictionary(Of String, Object))()
        Dim categories As New Dictionary(Of String, List(Of Dictionary(Of String, Object)))()

        Debug.WriteLine("LoadPermissionsForUsers triggered")
        Debug.WriteLine("Tab: " & If(TabGroupsControl.SelectedTabPage Is XtraTabPage1, "Groups", "Users"))
        Debug.WriteLine("ComboBoxGroups.EditValue: " & If(ComboBoxGroups.EditValue, "Nothing"))

        dt.Rows.Clear()
        dt = New DataTable()
        dt.Columns.Add("FormId", GetType(Integer))
        dt.Columns.Add("FormNameAR", GetType(String))
        dt.Columns.Add("Category", GetType(String))
        dt.Columns.Add("CanEdit", GetType(Boolean))
        dt.Columns.Add("CanAdd", GetType(Boolean))
        dt.Columns.Add("CanDelete", GetType(Boolean))
        dt.Columns.Add("IsAllow", GetType(Boolean))
        dt.Columns.Add("ArCategoryNameForShow", GetType(String))

        Try
            Dim IsSuperAdmin As Boolean = String.Equals(Convert.ToString(UserPermission.UserType), "sa", StringComparison.OrdinalIgnoreCase)
            Dim IsLocalAdmin As Boolean = String.Equals(Convert.ToString(UserPermission.UserType), "la", StringComparison.OrdinalIgnoreCase)
            Dim userId As Object = UserPermission.UserId
            Dim permissionMapping = GetPermissionMapping()
            Dim userPermissions As New List(Of Integer)()

            If Not IsSuperAdmin AndAlso userId IsNot Nothing Then
                Using cn As New SqlConnection(connectionString)
                    cn.Open()
                    Using cmd As New SqlCommand("
                      SELECT DISTINCT FormId 
                      FROM PermissionsAssignments 
                      WHERE UserId = @userId 
                      AND IsAllow = 1 
                      AND FormId IS NOT NULL", cn)

                        cmd.Parameters.AddWithValue("@userId", userId)
                        Using rd = cmd.ExecuteReader()
                            While rd.Read()
                                userPermissions.Add(Convert.ToInt32(rd("FormId")))
                            End While
                        End Using
                    End Using
                End Using
            End If

            Using cn As New SqlConnection(connectionString)
                cn.Open()
                Dim whereClause As String = ""
                If Not IsSuperAdmin Then
                    whereClause = " WHERE (Category IS NULL OR Category != 'Permessions')"
                End If

                ' Check if a section is selected
                Dim selectedSection As String = Nothing
                If ComboBoxSections.EditValue IsNot Nothing AndAlso ComboBoxSections.EditValue.ToString().Trim() <> "" Then
                    selectedSection = ComboBoxSections.EditValue.ToString().Trim()
                    If whereClause = "" Then
                        whereClause = " WHERE Section = @Section"
                    Else
                        whereClause &= " AND Section = @Section"
                    End If
                End If

                Using cmd As New SqlCommand("
                SELECT FormId, FormNameAR, FormNameEN, Description, Category, ArCategoryNameForShow
                FROM PermissionsForms" & whereClause & "
                ORDER BY ISNULL(ArCategoryNameForShow, Category), FormNameAR", cn)

                    If Not String.IsNullOrEmpty(selectedSection) Then
                        cmd.Parameters.AddWithValue("@Section", selectedSection)
                    End If


                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim formId As Integer = Convert.ToInt32(rd("FormId"))
                            Dim shouldInclude As Boolean = True

                            If Not IsSuperAdmin Then
                                If permissionMapping.ContainsKey(formId) Then
                                    Dim controlPermissionId = permissionMapping(formId)
                                    shouldInclude = userPermissions.Contains(controlPermissionId)
                                End If
                            End If

                            If shouldInclude Then
                                Dim categoryForShow As String = If(IsDBNull(rd("ArCategoryNameForShow")) OrElse String.IsNullOrEmpty(rd("ArCategoryNameForShow").ToString()), "عام", rd("ArCategoryNameForShow").ToString())

                                ' Build permission dictionary for web-style return
                                Dim permission = New Dictionary(Of String, Object) From {
                                    {"FormId", formId},
                                    {"FormNameAR", rd("FormNameAR").ToString()},
                                    {"FormNameEN", rd("FormNameEN").ToString()},
                                    {"Description", If(rd("Description") Is DBNull.Value, Nothing, rd("Description").ToString())},
                                    {"Category", If(rd("Category") Is DBNull.Value, Nothing, rd("Category").ToString())},
                                    {"ArCategoryNameForShow", categoryForShow}
                                }

                                items.Add(permission)

                                If Not categories.ContainsKey(categoryForShow) Then
                                    categories(categoryForShow) = New List(Of Dictionary(Of String, Object))()
                                End If
                                categories(categoryForShow).Add(permission)

                                ' ✅ Add row to DataTable (instead of da.Fill)
                                Dim dr As DataRow = dt.NewRow()
                                dr("FormId") = formId
                                dr("FormNameAR") = rd("FormNameAR").ToString()
                                dr("Category") = If(IsDBNull(rd("Category")), Nothing, rd("Category").ToString())
                                dr("CanEdit") = False
                                dr("CanAdd") = False
                                dr("CanDelete") = False
                                dr("IsAllow") = False
                                dr("ArCategoryNameForShow") = categoryForShow
                                dt.Rows.Add(dr)
                            End If
                        End While
                    End Using
                End Using
            End Using
            res("success") = True
            res("items") = items
            res("categories") = categories
            If dt.Rows.Count > 0 Then
                GridControl1.DataSource = Nothing
                GridControl1.DataSource = dt
                GridControl1.RefreshDataSource()
                GridView1.BestFitColumns()
            Else
                GridControl1.DataSource = Nothing
                GridView1.RefreshData()
            End If
        Catch ex As Exception
            res("success") = False
            res("error") = ex.Message
        End Try
        Return res
    End Function
    Private Function GetPermissionMapping() As Dictionary(Of Integer, Integer)
        Dim map As New Dictionary(Of Integer, Integer) From {
        {1, 15},      ' الموظفين → صلاحية الموظفين
        {2, 16},      ' إدارة ساعات الدوام → صلاحية إدارة ساعات الدوام
        {3, 17},      ' الدوام العام → صلاحية الدوام العام
        {4, 18},      ' دوام الساعات المطلوبة → صلاحية دوام الساعات المطلوبة
        {5, 19},      ' دوام الوردية → صلاحية دوام الوردية
        {6, 20},      ' دوام حسب الساعة → صلاحية دوام حسب الساعة
        {7, 21},      ' إصدار تقارير الدوام → صلاحية إصدار تقارير الدوام
        {8, 22},      ' كشوفات الدوام → صلاحية كشوفات الدوام
        {9, 23},      ' الإجازات → صلاحية الإجازات
        {10, 24},     ' الإجازات الجماعية → صلاحية الإجازات الجماعية
        {11, 25},     ' ثوابت النظام → صلاحية ثوابت النظام
        {12, 26},     ' إعدادات عامة → صلاحية إعدادات عامة
        {13, 27},     ' بيانات الشركة → صلاحية بيانات الشركة
        {28, 114},    ' ملفات الموظفين → صلاحية ملفات الموظفين
        {30, 115},    ' تقرير المغادرات → صلاحية تقرير المغادرات
        {31, 116},    ' نظام المياومة → صلاحية نظام المياومة
        {32, 117},    ' تعريف وردية موظف لفترة الساعات المطلوبة → صلاحية تعريف وردية...
        {33, 118},    ' خطة الدوام → صلاحية خطة الدوام
        {34, 119},    ' سحب الحركات من ساعة الدوام → صلاحية سحب الحركات...
        {35, 120},    ' صندوق الادخار → صلاحية صندوق الادخار
        {36, 121},    ' ضريبة الحوافز → صلاحية ضريبة الحوافز
        {37, 122},    ' تحكم الرواتب → صلاحية تحكم الرواتب
        {38, 123},    ' ضريبة الرواتب → صلاحية ضريبة الرواتب
        {39, 124},    ' كشف الرواتب → صلاحية كشف الرواتب
        {40, 125},    ' إصدار الرواتب → صلاحية إصدار الرواتب
        {41, 126},    ' الرواتب حسب الإنتاج → صلاحية الرواتب حسب الإنتاج
        {42, 127},    ' الرواتب بالساعة → صلاحية الرواتب بالساعة
        {43, 128},    ' العلاوات والخصميات الثابتة → صلاحية العلاوات والخصميات الثابتة
        {44, 129},    ' تقرير المكافآت → صلاحية تقرير المكافآت
        {45, 130},    ' إدخال الخصميات → صلاحية إدخال الخصميات
        {46, 131},    ' السلف → صلاحية السلف
        {47, 132},    ' الدوام حسب الساعات الشهرية المطلوبة → صلاحية ...
        {48, 133},    ' الدوام حسب الفترات → صلاحية ...
        {49, 134},    ' التقارير → صلاحية التقارير
        {50, 135},    ' الرواتب حسب الوردية → صلاحية الرواتب حسب الوردية
        {51, 136},    ' الرواتب حسب الساعات المطلوبة → صلاحية ...
        {52, 137},    ' القوائم والثوابت → صلاحية القوائم والثوابت
        {53, 138},    ' حسابات البنوك → صلاحية حسابات البنوك
        {55, 139},    ' الحسابات المالية → صلاحية الحسابات المالية
        {56, 140},    ' دمج أصناف → صلاحية دمج أصناف
        {60, 141},    ' تعديل البيانات → صلاحية تعديل البيانات
        {61, 142},    ' قائمة الذمم → صلاحية قائمة الذمم
        {62, 143},    ' الذمم → صلاحية الذمم
        {63, 144},    ' باركودات الأصناف → صلاحية باركودات الأصناف
        {64, 145},    ' طباعة باركودات → صلاحية طباعة باركودات
        {65, 146},    ' اعدادات الباركودات → صلاحية اعدادات الباركودات
        {66, 147},    ' تعديل اسعار البيع → صلاحية تعديل اسعار البيع
        {67, 148},    ' المخزون → صلاحية المخزون
        {68, 149},    ' تعريف صنف → صلاحية تعريف صنف
        {73, 150},    ' مراكز التكلفة → صلاحية مراكز التكلفة
        {74, 151},    ' الحسابات الافتراضية → صلاحية الحسابات الافتراضية
        {75, 152},    ' الأصول → صلاحية الأصول
        {76, 153},    ' الشيكات الواردة → صلاحية الشيكات الواردة
        {77, 154},    ' الشيكات الصادرة → صلاحية الشيكات الصادرة
        {78, 155},    ' الشيكات → صلاحية الشيكات
        {79, 156},    ' سند قيد تذميم → صلاحية سند قيد تذميم
        {80, 157},    ' فروقات عملة → صلاحية فروقات عملة
        {81, 158},    ' سند قيد → صلاحية سند قيد
        {82, 159},    ' مجاسبي → صلاحية مجاسبي
        {83, 160},    ' سند صرف → صلاحية سند صرف
        {84, 161},    ' مردودات مشتريات → صلاحية مردودات مشتريات
        {85, 162},    ' اشعار مدين → صلاحية اشعار مدين
        {86, 163},    ' طلبية مشتريات → صلاحية طلبية مشتريات
        {87, 164},    ' فاتورة مشتريات → صلاحية فاتورة مشتريات
        {88, 165},    ' سند قبض → صلاحية سند قبض
        {89, 166},    ' مردودات مبيعات → صلاحية مردودات مبيعات
        {90, 167},    ' اشعار دائن → صلاحية اشعار دائن
        {91, 168},    ' طلبية مبيعات → صلاحية طلبية مبيعات
        {92, 169},    ' فاتورة مبيعات → صلاحية فاتورة مبيعات
        {93, 170},    ' الطلبيات الداخلية → صلاحية الطلبيات الداخلية
        {94, 171},    ' تدقيق الطلبيات الداخلية → صلاحية تدقيق الطلبيات الداخلية
        {95, 172},    ' تقارير استلام الطلبيات الداخلية → صلاحية تقارير...
        {96, 173},    ' الارساليات → صلاحية الارساليات
        {97, 174},    ' جرد المخزون → صلاحية جرد المخزون
        {98, 175},    ' حرکات الاصناف → صلاحية حرکات الاصناف
        {99, 176},    ' تقارير الاصناف → صلاحية تقارير الاصناف
        {100, 177},   ' أرصدة الحسابات → صلاحية أرصدة الحسابات
        {101, 178},   ' تقرير ربح الأصناف → صلاحية تقرير ربح الأصناف
        {102, 179},   ' استعلام الحركات → صلاحية استعلام الحركات
        {103, 180},   ' كشف حساب → صلاحية كشف حساب
        {105, 181},   ' كشف أرصدة الذمم → صلاحية كشف أرصدة الذمم
        {106, 182},   ' كشف الذمة مفصل → صلاحية كشف الذمة مفصل
        {107, 183},   ' كشف حساب ذمة → صلاحية كشف حساب ذمة
        {108, 184},   ' تقرير شهري للحسابات → صلاحية تقرير شهري للحسابات
        {109, 185},   ' ملخص الدخل → صلاحية ملخص الدخل
        {110, 186},   ' مبيعات الاصناف → صلاحية مبيعات الاصناف
        {111, 187},   ' الميزانية العمومية → صلاحية الميزانية العمومية
        {112, 188},   ' قائمة الدخل → صلاحية قائمة الدخل
        {113, 189}    ' ميزان المراجعة → صلاحية ميزان المراجعة
    }

        Debug.WriteLine($"✅ Mapping initialized with {map.Count} entries")
        Return map
    End Function


    ' ---------------- Update Form Text ----------------
    Private Sub UpdateTextsForGroupsTab()
        Me.Text = "صلاحيات المجموعات"
    End Sub

    Private Sub UpdateTextsForUsersTab()
        Me.Text = "صلاحيات المستخدمين"
    End Sub

    ' ---------------- Save Button (Groups and Users) ----------------
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim tran = conn.BeginTransaction()
            Try
                If TabGroupsControl.SelectedTabPage Is XtraTabPage1 Then
                    ' --- Groups Tab ---
                    Dim groupId As Integer = GetSelectedGroupId()
                    If groupId = 0 Then Return

                    ' Delete previous permissions for the group
                    Using delCmd As New SqlCommand("DELETE FROM GroupPermissions WHERE GroupId = @GroupId", conn, tran)
                        delCmd.Parameters.AddWithValue("@GroupId", groupId)
                        delCmd.ExecuteNonQuery()
                    End Using

                    ' Insert current toggles into GroupPermissions
                    Using insertCmd As New SqlCommand("
                    INSERT INTO GroupPermissions
                    (GroupId, FormId, IsAllow, CanEdit, CanAdd, CanDelete)
                    VALUES (@GroupId, @FormId, @IsAllow, @CanEdit, @CanAdd, @CanDelete)", conn, tran)

                        insertCmd.Parameters.Add("@GroupId", SqlDbType.Int)
                        insertCmd.Parameters.Add("@FormId", SqlDbType.Int)
                        insertCmd.Parameters.Add("@IsAllow", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanEdit", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanAdd", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanDelete", SqlDbType.Bit)

                        For Each row As DataRow In dt.Rows
                            insertCmd.Parameters("@GroupId").Value = groupId
                            insertCmd.Parameters("@FormId").Value = row("FormId")
                            insertCmd.Parameters("@IsAllow").Value = row("IsAllow")
                            insertCmd.Parameters("@CanEdit").Value = row("CanEdit")
                            insertCmd.Parameters("@CanAdd").Value = row("CanAdd")
                            insertCmd.Parameters("@CanDelete").Value = row("CanDelete")
                            insertCmd.ExecuteNonQuery()
                        Next
                    End Using

                    ' --- Sync with users in this group ---
                    Dim userIds As New List(Of Integer)
                    Using userCmd As New SqlCommand("SELECT UserId FROM GroupMembers WHERE GroupId = @GroupId", conn, tran)
                        userCmd.Parameters.AddWithValue("@GroupId", groupId)
                        Using rdr = userCmd.ExecuteReader()
                            While rdr.Read()
                                userIds.Add(rdr("UserId"))
                            End While
                        End Using
                    End Using

                    ' Update permissions for each user
                    For Each userId In userIds
                        ' Delete previous assignments
                        Using delUserCmd As New SqlCommand("DELETE FROM PermissionsAssignments WHERE UserId = @UserId", conn, tran)
                            delUserCmd.Parameters.AddWithValue("@UserId", userId)
                            delUserCmd.ExecuteNonQuery()
                        End Using

                        ' Insert new assignments based on group permissions
                        Using insertUserCmd As New SqlCommand("
                        INSERT INTO PermissionsAssignments
                        (UserId, FormId, IsAllow, CanEdit, CanAdd, CanDelete)
                        VALUES (@UserId, @FormId, @IsAllow, @CanEdit, @CanAdd, @CanDelete)", conn, tran)

                            insertUserCmd.Parameters.Add("@UserId", SqlDbType.Int)
                            insertUserCmd.Parameters.Add("@FormId", SqlDbType.Int)
                            insertUserCmd.Parameters.Add("@IsAllow", SqlDbType.Bit)
                            insertUserCmd.Parameters.Add("@CanEdit", SqlDbType.Bit)
                            insertUserCmd.Parameters.Add("@CanAdd", SqlDbType.Bit)
                            insertUserCmd.Parameters.Add("@CanDelete", SqlDbType.Bit)

                            For Each row As DataRow In dt.Rows
                                insertUserCmd.Parameters("@UserId").Value = userId
                                insertUserCmd.Parameters("@FormId").Value = row("FormId")
                                insertUserCmd.Parameters("@IsAllow").Value = row("IsAllow")
                                insertUserCmd.Parameters("@CanEdit").Value = row("CanEdit")
                                insertUserCmd.Parameters("@CanAdd").Value = row("CanAdd")
                                insertUserCmd.Parameters("@CanDelete").Value = row("CanDelete")
                                insertUserCmd.ExecuteNonQuery()
                            Next
                        End Using
                    Next


                ElseIf TabGroupsControl.SelectedTabPage Is XtraTabPage2 Then
                    ' --- Users Tab ---
                    Dim userId As Integer = GetSelectedUserId()
                    If userId = 0 Then Return

                    ' Delete previous user permissions
                    Using delCmd As New SqlCommand("DELETE FROM PermissionsAssignments WHERE UserId = @UserId", conn, tran)
                        delCmd.Parameters.AddWithValue("@UserId", userId)
                        delCmd.ExecuteNonQuery()
                    End Using

                    ' Insert current toggles
                    Using insertCmd As New SqlCommand("
                    INSERT INTO PermissionsAssignments
                    (UserId, FormId, IsAllow, CanEdit, CanAdd, CanDelete)
                    VALUES (@UserId, @FormId, @IsAllow, @CanEdit, @CanAdd, @CanDelete)", conn, tran)

                        insertCmd.Parameters.Add("@UserId", SqlDbType.Int)
                        insertCmd.Parameters.Add("@FormId", SqlDbType.Int)
                        insertCmd.Parameters.Add("@IsAllow", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanEdit", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanAdd", SqlDbType.Bit)
                        insertCmd.Parameters.Add("@CanDelete", SqlDbType.Bit)

                        For Each row As DataRow In dt.Rows
                            insertCmd.Parameters("@UserId").Value = userId
                            insertCmd.Parameters("@FormId").Value = row("FormId")
                            insertCmd.Parameters("@IsAllow").Value = row("IsAllow")
                            insertCmd.Parameters("@CanEdit").Value = row("CanEdit")
                            insertCmd.Parameters("@CanAdd").Value = row("CanAdd")
                            insertCmd.Parameters("@CanDelete").Value = row("CanDelete")
                            insertCmd.ExecuteNonQuery()
                        Next
                    End Using
                End If

                tran.Commit()
                MessageBox.Show("تم حفظ الصلاحيات بنجاح ✅", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                tran.Rollback()
                MessageBox.Show("Error saving permissions: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub LoadSections()
        ComboBoxSections.Properties.Items.Clear()
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT [Section] FROM [PermissionsForms]", conn)
            Dim dtGroups As New DataTable()
            dtGroups.Load(cmd.ExecuteReader())
            For Each row As DataRow In dtGroups.Rows
                ComboBoxSections.Properties.Items.Add(row("Section").ToString())
            Next
        End Using
    End Sub
    Private Sub LoadGroupsData()
        Dim dt As New DataTable()

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Base query: all groups
                Dim query As String = "
                SELECT 
                    g.GroupId,
                    g.GroupName AS GridColumnGroupName,
                    g.Description AS GridColumnGroupDescription,
                    (SELECT COUNT(*) FROM GroupMembers ug WHERE ug.GroupId = g.GroupId) AS GridColumnNumOfMembers
                FROM Groups g
            "

                ' 🔐 Apply filters for local admin or normal user
                If UserPermission.UserType <> "sa" Then
                    query &= "
                    WHERE g.GroupId NOT IN (
                        SELECT DISTINCT gm.GroupId
                        FROM GroupMembers gm
                        INNER JOIN UsersSystem u ON gm.UserId = u.UserId
                        WHERE u.UserType IN ('sa', 'la')
                    )
                "
                End If

                Using da As New SqlDataAdapter(query, conn)
                    da.Fill(dt)
                End Using

                ' Add button columns
                dt.Columns.Add("GridColumnEditMembers", GetType(Object))
                dt.Columns.Add("GridColumnEditGroupInfo", GetType(Object))
                dt.Columns.Add("GridColumnDeleteGroup", GetType(Object))

                GridControl2.DataSource = dt
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading groups: " & ex.Message)
        End Try
    End Sub
    Private Sub BtnAddGroup_Click(sender As Object, e As EventArgs) Handles BtnAddGroup.Click
        Dim addForm As New FrmAddGroup()
        addForm.StartPosition = FormStartPosition.CenterParent
        addForm.ShowDialog(Me)

        ' Reload grid if a new group was added
        If addForm.GroupAdded Or addForm.GroupUpdated Then
            LoadGroupsData()
        End If
    End Sub

    Private Sub BtnEditMembers_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        ' Get the currently focused row
        Dim rowHandle As Integer = GridView2.FocusedRowHandle
        If rowHandle < 0 Then
            'ss.WriteLine("EditMembersButton_Click: No row is focused.")
            Return
        End If

        ' Try to get the GroupId from the row
        Dim groupIdObj = GridView2.GetRowCellValue(rowHandle, "GroupId")
        If groupIdObj Is Nothing Then
            'Debug.WriteLine("EditMembersButton_Click: GroupId is Nothing for rowHandle=" & rowHandle)
            Return
        End If

        Dim groupId As Integer
        If Integer.TryParse(groupIdObj.ToString(), groupId) Then
            ' Debug.WriteLine("EditMembersButton_Click: GroupId=" & groupId & " for rowHandle=" & rowHandle)
        Else
            '  Debug.WriteLine("EditMembersButton_Click: Failed to parse GroupId=" & groupIdObj.ToString())
            Return
        End If

        ' Open the FrmAddGroupMembers form and pass the group ID
        Dim frm As New FrmAddGroupMembers()
        frm.CurrentGroupId = groupId
        frm.ShowDialog()

        If frm.MembersChanged Then
            LoadGroupsData()
        End If
    End Sub

    Private Sub BtnEditGroupInfo_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        Dim rowHandle As Integer = GridView2.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim groupId As Integer = Convert.ToInt32(GridView2.GetRowCellValue(rowHandle, "GroupId"))
        Dim groupName As String = GridView2.GetRowCellValue(rowHandle, "GridColumnGroupName").ToString()

        Dim frm As New FrmAddGroup()
        frm.IsEditMode = True
        frm.CurrentGroupId = groupId
        frm.Text = "تعديل المجموعة - " & groupName
        frm.TextBox1.Text = "تعديل المجموعة"

        ' Load existing data into form fields
        Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT GroupName, [Description] FROM Groups WHERE GroupId = @GroupId", conn)
            cmd.Parameters.AddWithValue("@GroupId", groupId)
            Using reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    frm.TxtGroupName.Text = reader("GroupName").ToString()
                    frm.TxtGroupDescription.Text = reader("Description").ToString()
                End If
            End Using
        End Using

        If frm.ShowDialog() = DialogResult.OK Then
            LoadGroupsData()
        End If
    End Sub

    Private Sub BtnDeleteGroup_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim rowHandle As Integer = GridView2.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim groupId As Integer = Convert.ToInt32(GridView2.GetRowCellValue(rowHandle, "GroupId"))
        Dim groupName As String = GridView2.GetRowCellValue(rowHandle, "GridColumnGroupName").ToString()

        If MessageBox.Show($"هل تريد حذف المجموعة '{groupName}'؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(My.Settings.TrueTimeConnectionString)
                    conn.Open()

                    Dim deleteMembersSql As String = "DELETE FROM GroupMembers WHERE GroupId = @GroupId"
                    Using cmdMembers As New SqlCommand(deleteMembersSql, conn)
                        cmdMembers.Parameters.AddWithValue("@GroupId", groupId)
                        cmdMembers.ExecuteNonQuery()
                    End Using

                    Dim deleteGroupSql As String = "DELETE FROM Groups WHERE GroupId = @GroupId"
                    Using cmdGroup As New SqlCommand(deleteGroupSql, conn)
                        cmdGroup.Parameters.AddWithValue("@GroupId", groupId)
                        cmdGroup.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("تم حذف المجموعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadGroupsData()

            Catch ex As Exception
                MessageBox.Show("حدث خطأ أثناء حذف المجموعة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub GridView2_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView2.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is GridColumnEditMembers Then
                e.Value = "EditMembers"
            ElseIf e.Column Is GridColumnEditGroupInfo Then
                e.Value = "EditGroupInfo"
            ElseIf e.Column Is GridColumnDeleteGroup Then
                e.Value = "DeleteGroup"
            End If
        End If
    End Sub

End Class