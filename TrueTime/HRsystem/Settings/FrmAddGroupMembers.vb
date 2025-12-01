Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class FrmAddGroupMembers
    Inherits DevExpress.XtraEditors.XtraForm

    Public Property CurrentGroupId As Integer
    Public Property MembersChanged As Boolean = False
    Public connectionString As String = My.Settings.TrueTimeConnectionString

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmAddGroupMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
        LoadGroupMembers()
        AddDeleteButtonColumn()
    End Sub

    ' ---------------- Load Users ----------------
    Private Sub LoadUsers()
        ComboBoxUsers.Properties.Items.Clear()
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Get all user IDs already in the group
            Dim existingUserIds As New List(Of Integer)
            Using cmd As New SqlCommand("SELECT UserId FROM GroupMembers WHERE GroupId = @GroupId", conn)
                cmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        existingUserIds.Add(Convert.ToInt32(rd("UserId")))
                    End While
                End Using
            End Using

            ' Build SQL to get all users not in the group
            Dim sql As String = "SELECT UserId, UserName, UserType FROM UsersSystem WHERE 1=1"

            ' Filter based on current user type
            If UserPermission.UserType = "la" Then
                ' Limited admin cannot add SA or LA
                sql &= " AND UserType NOT IN ('sa','la')"
            ElseIf UserPermission.UserType = "sa" Then
                ' SA cannot add LA
                sql &= " AND UserType != 'la'"
            End If

            ' Exclude users already in the group
            If existingUserIds.Count > 0 Then
                sql &= " AND UserId NOT IN (" & String.Join(",", existingUserIds) & ")"
            End If

            sql &= " ORDER BY UserName"

            Using cmd As New SqlCommand(sql, conn)
                Dim dtUsers As New DataTable()
                dtUsers.Load(cmd.ExecuteReader())
                For Each row As DataRow In dtUsers.Rows
                    ComboBoxUsers.Properties.Items.Add(row("UserName").ToString() & "|" & row("UserId").ToString())
                Next
            End Using
        End Using
    End Sub



    ' ---------------- Load Group Members ----------------
    Private Sub LoadGroupMembers()
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim sql As String = "
                SELECT u.UserId, u.UserName 
                FROM GroupMembers gm
                INNER JOIN UsersSystem u ON gm.UserId = u.UserId
                WHERE gm.GroupId = @GroupId
                ORDER BY u.UserName"
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                Dim dt As New DataTable()
                dt.Load(cmd.ExecuteReader())
                GridControlGroupMembers.DataSource = dt
            End Using
        End Using
    End Sub

    ' ---------------- Add Member ----------------
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAddMember.Click
        If ComboBoxUsers.SelectedItem Is Nothing Then
            XtraMessageBox.Show("Please select a user.")
            Return
        End If

        Dim parts() As String = ComboBoxUsers.SelectedItem.ToString().Split("|"c)
        Dim userName As String = parts(0)
        Dim userId As Integer = Convert.ToInt32(parts(1))

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using tran As SqlTransaction = conn.BeginTransaction()
                    Try
                        ' 1️⃣ Insert into GroupMembers if not exists
                        Dim sqlAddUser As String = "
                        IF NOT EXISTS (SELECT 1 FROM GroupMembers WHERE GroupId=@GroupId AND UserId=@UserId)
                            INSERT INTO GroupMembers (GroupId, UserId) VALUES (@GroupId, @UserId)
                    "
                        Using cmd As New SqlCommand(sqlAddUser, conn, tran)
                            cmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                            cmd.Parameters.AddWithValue("@UserId", userId)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' 2️⃣ Always delete standalone (non-group) permissions
                        Dim delStandalone As String = "
                        DELETE FROM PermissionsAssignments
                        WHERE UserId = @UserId AND GroupId IS NULL
                    "
                        Using cmdDel As New SqlCommand(delStandalone, conn, tran)
                            cmdDel.Parameters.AddWithValue("@UserId", userId)
                            cmdDel.ExecuteNonQuery()
                        End Using

                        ' 3️⃣ Check if group has permissions
                        Dim groupPermCount As Integer = 0
                        Using checkCmd As New SqlCommand("SELECT COUNT(*) FROM GroupPermissions WHERE GroupId=@GroupId", conn, tran)
                            checkCmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                            groupPermCount = Convert.ToInt32(checkCmd.ExecuteScalar())
                        End Using

                        ' 4️⃣ If group has permissions, insert only missing ones (avoid duplicates)
                        If groupPermCount > 0 Then
                            Dim sqlInsertPerms As String = "
                            INSERT INTO PermissionsAssignments 
                                (UserId, GroupId, FormId, IsAllow, CanEdit, CanAdd, CanDelete)
                            SELECT @UserId, gp.GroupId, gp.FormId, gp.IsAllow, gp.CanEdit, gp.CanAdd, gp.CanDelete
                            FROM GroupPermissions gp
                            WHERE gp.GroupId = @GroupId
                            AND NOT EXISTS (
                                SELECT 1 FROM PermissionsAssignments pa
                                WHERE pa.UserId = @UserId
                                  AND pa.GroupId = gp.GroupId
                                  AND pa.FormId = gp.FormId
                            )
                        "
                            Using cmdPerm As New SqlCommand(sqlInsertPerms, conn, tran)
                                cmdPerm.Parameters.AddWithValue("@UserId", userId)
                                cmdPerm.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                                cmdPerm.ExecuteNonQuery()
                            End Using
                        End If

                        ' 5️⃣ Commit all changes
                        tran.Commit()

                        MembersChanged = True
                        LoadGroupMembers()
                        LoadUsers()
                        XtraMessageBox.Show($"تم إضافة المستخدم {userName} إلى المجموعة بنجاح.")

                    Catch ex As Exception
                        tran.Rollback()
                        XtraMessageBox.Show("Error adding user to group: " & ex.Message)
                    End Try
                End Using
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("Error adding user: " & ex.Message)
        End Try
    End Sub





    ' ---------------- Cancel Add ----------------
    Private Sub BtnCancelAddMember_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    ' ---------------- Add Delete Button Column ----------------
    Private Sub AddDeleteButtonColumn()
        If GridView1.Columns.ColumnByFieldName("DeleteUser") IsNot Nothing Then Exit Sub

        Dim colDelete As New DevExpress.XtraGrid.Columns.GridColumn()
        colDelete.Caption = ""
        colDelete.FieldName = "DeleteUser"
        colDelete.Visible = True
        colDelete.VisibleIndex = GridView1.Columns.Count
        colDelete.Width = 40

        Dim btnDelete As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        btnDelete.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        btnDelete.Buttons(0).Caption = "✖"
        btnDelete.Appearance.ForeColor = Color.Red
        btnDelete.Appearance.Font = New Font("Tahoma", 10, FontStyle.Bold)
        AddHandler btnDelete.ButtonClick, AddressOf DeleteUserButton_Click

        GridControlGroupMembers.RepositoryItems.Add(btnDelete)
        colDelete.ColumnEdit = btnDelete
        GridView1.Columns.Add(colDelete)
    End Sub

    ' ---------------- Delete Member ----------------
    Private Sub DeleteUserButton_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim rowHandle As Integer = GridView1.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim userId As Integer = Convert.ToInt32(GridView1.GetRowCellValue(rowHandle, "UserId"))
        Dim userName As String = GridView1.GetRowCellValue(rowHandle, "UserName").ToString()

        If XtraMessageBox.Show($"هل أنت متأكد من حذف المستخدم {userName} من المجموعة؟", "تأكيد الحذف", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(connectionString)
                    conn.Open()
                    Using tran As SqlTransaction = conn.BeginTransaction()
                        ' 1️⃣ Remove user from the group
                        Using cmd As New SqlCommand("DELETE FROM GroupMembers WHERE GroupId=@GroupId AND UserId=@UserId", conn, tran)
                            cmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                            cmd.Parameters.AddWithValue("@UserId", userId)
                            cmd.ExecuteNonQuery()
                        End Using

                        ' 2️⃣ Remove only the permissions that came from this group
                        Dim sqlDeletePerms As String = "
                        DELETE FROM PermissionsAssignments
                        WHERE UserId = @UserId AND GroupId = @GroupId
                    "
                        Using cmdPerm As New SqlCommand(sqlDeletePerms, conn, tran)
                            cmdPerm.Parameters.AddWithValue("@UserId", userId)
                            cmdPerm.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                            cmdPerm.ExecuteNonQuery()
                        End Using

                        tran.Commit()
                    End Using
                End Using

                ' 3️⃣ Update UI
                GridView1.DeleteRow(rowHandle)
                MembersChanged = True
                LoadUsers()

                XtraMessageBox.Show("تم حذف المستخدم وصلاحياته الخاصة بالمجموعة بنجاح.")
            Catch ex As Exception
                XtraMessageBox.Show("خطأ أثناء الحذف: " & ex.Message)
            End Try
        End If
    End Sub

End Class
