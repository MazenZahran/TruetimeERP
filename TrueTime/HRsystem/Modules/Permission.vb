Imports System.Data.SqlClient
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon

Module Permission

    Private CachedPermissions As Dictionary(Of Integer, FeatureAccess)

    Public Sub InitializePermissions(userId As Integer)
        CachedPermissions = LoadUserPermissionsDict(userId)
        Debug.WriteLine($"✅ Permissions cached for user {userId}: {CachedPermissions.Count} entries")
    End Sub

    ' 🔹 Apply permissions for a specific form (by FormId)
    Public Sub ApplyPermissions(userId As Integer, formId As Integer)
        ' Load from cache if not already loaded
        If CachedPermissions Is Nothing Then
            CachedPermissions = LoadUserPermissionsDict(userId)
        End If

        ' Find matching controls for the form
        If Not FormControlMapping.FormControlMap.ContainsKey(formId) Then
            Debug.WriteLine($"⚠ No mapping found for FormId={formId}")
            Exit Sub
        End If

        Dim controls As FormControls = FormControlMapping.FormControlMap(formId)

        ' Find user’s access or default deny
        Dim access As FeatureAccess =
            If(CachedPermissions.ContainsKey(formId),
               CachedPermissions(formId),
               New FeatureAccess With {.IsAllow = False, .CanAdd = False, .CanEdit = False, .CanDelete = False})

        ' Apply permissions
        SetControlPermission(controls.MainButton, access.IsAllow, Nothing, Nothing, Nothing, "MainButton")
        SetControlPermission(controls.ButtonAllow, access.IsAllow, Nothing, Nothing, Nothing, "ButtonAllow")
        SetControlPermission(controls.ButtonAdd, Nothing, access.CanAdd, Nothing, Nothing, "ButtonAdd")
        SetControlPermission(controls.ButtonEdit, Nothing, Nothing, access.CanEdit, Nothing, "ButtonEdit")
        SetControlPermission(controls.ButtonDelete, Nothing, Nothing, Nothing, access.CanDelete, "ButtonDelete")

        Debug.WriteLine($"🔸 Applied permissions for FormId={formId}: Allow={access.IsAllow}, Add={access.CanAdd}, Edit={access.CanEdit}, Delete={access.CanDelete}")
    End Sub

    ' 🔹 Load permissions from database
    Private Function LoadUserPermissionsDict(userId As Integer) As Dictionary(Of Integer, FeatureAccess)
        Dim permissions As New Dictionary(Of Integer, FeatureAccess)()

        Try
            Dim sql As String = "
                SELECT 
                    pa.FormId,
                    pa.CanEdit,
                    pa.CanDelete,
                    pa.CanAdd,
                    pa.IsAllow
                FROM PermissionsAssignments pa
                WHERE pa.UserId = @UserId
                   OR pa.GroupId = (
                        SELECT TOP 1 GroupId 
                        FROM PermissionsAssignments 
                        WHERE UserId = @UserId AND GroupId IS NOT NULL
                    )
            "

            Using conn As New SqlConnection(GlobalVariables.connectionString)
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@UserId", userId)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim formId As Integer = Convert.ToInt32(reader("FormId"))
                            Dim access As New FeatureAccess With {
                                .IsAllow = Convert.ToBoolean(reader("IsAllow")),
                                .CanAdd = Convert.ToBoolean(reader("CanAdd")),
                                .CanEdit = Convert.ToBoolean(reader("CanEdit")),
                                .CanDelete = Convert.ToBoolean(reader("CanDelete"))
                            }
                            permissions(formId) = access
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Debug.WriteLine($"❌ Error loading user permissions: {ex.Message}")
        End Try

        Return permissions
    End Function

    Private Sub SetControlPermission(control As Object, isAllow As Boolean?, canAdd As Boolean?, canEdit As Boolean?, canDelete As Boolean?, Optional controlName As String = "")
        If control Is Nothing Then
            ' Debug.WriteLine($"⚠ {controlName} is Nothing, skipping permission")
            Return
        End If

        Select Case True

            Case TypeOf control Is DevExpress.XtraBars.BarItem
                Dim bar As DevExpress.XtraBars.BarItem = DirectCast(control, DevExpress.XtraBars.BarItem)

                If isAllow.HasValue Then
                    bar.Visibility = If(isAllow.Value, BarItemVisibility.Always, BarItemVisibility.Never)
                    bar.Enabled = isAllow.Value
                    'Debug.WriteLine($"🔹 {controlName} (BarItem) Allow → Visible={bar.Visibility}, Enabled={bar.Enabled}")
                    Return ' Exit so the others don't override this
                End If

                If canAdd.HasValue Then
                    bar.Visibility = If(canAdd.Value, BarItemVisibility.Always, BarItemVisibility.Never)
                    bar.Enabled = canAdd.Value
                    'Debug.WriteLine($"🔹 {controlName} (Add) → Visible={bar.Visibility}, Enabled={bar.Enabled}")
                ElseIf canEdit.HasValue Then
                    bar.Visibility = If(canEdit.Value, BarItemVisibility.Always, BarItemVisibility.Never)
                    bar.Enabled = canEdit.Value
                    'Debug.WriteLine($"🔹 {controlName} (Edit) → Visible={bar.Visibility}, Enabled={bar.Enabled}")
                ElseIf canDelete.HasValue Then
                    bar.Visibility = If(canDelete.Value, BarItemVisibility.Always, BarItemVisibility.Never)
                    bar.Enabled = canDelete.Value
                    'Debug.WriteLine($"🔹 {controlName} (Delete) → Visible={bar.Visibility}, Enabled={bar.Enabled}")
                End If


            Case TypeOf control Is DevExpress.XtraBars.Ribbon.RibbonPageGroup
                Dim group As DevExpress.XtraBars.Ribbon.RibbonPageGroup = DirectCast(control, DevExpress.XtraBars.Ribbon.RibbonPageGroup)
                If isAllow.HasValue Then
                    group.Visible = isAllow.Value
                    'Debug.WriteLine($"🔹 {controlName} (RibbonPageGroup) → Visible={group.Visible}")
                End If

            Case TypeOf control Is DevExpress.XtraBars.Navigation.NavigationPage
                Dim page As DevExpress.XtraBars.Navigation.NavigationPage = DirectCast(control, DevExpress.XtraBars.Navigation.NavigationPage)

                If isAllow.HasValue Then
                    page.PageVisible = isAllow.Value
                    'Debug.WriteLine($"🔹 {controlName} (NavigationPage) Visible={page.PageVisible}")
                End If


            Case TypeOf control Is Control
                Dim c As Control = DirectCast(control, Control)
                If isAllow.HasValue Then c.Visible = isAllow.Value
                If canAdd.HasValue Then c.Enabled = canAdd.Value
                If canEdit.HasValue Then c.Enabled = canEdit.Value
                If canDelete.HasValue Then c.Enabled = canDelete.Value
                Try : c.Refresh() : Catch : End Try
                'Debug.WriteLine($"🔹 {controlName} (Control) updated visibility/enabled")

            Case Else
                'Debug.WriteLine($"⚠ {controlName} unsupported type: {control.GetType().Name}")

        End Select
    End Sub

End Module
