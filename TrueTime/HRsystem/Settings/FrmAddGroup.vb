Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class FrmAddGroup
    Public Property GroupAdded As Boolean = False
    Public Property GroupUpdated As Boolean = False
    Public Property IsEditMode As Boolean = False
    Public Property CurrentGroupId As Integer

    Private ReadOnly connectionString As String = My.Settings.TrueTimeConnectionString

    Private Sub FrmAddGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtGroupName.Focus()
        If IsEditMode AndAlso CurrentGroupId > 0 Then
            LoadGroupData()
        End If
    End Sub

    Private Sub BtnSaveGroup_Click(sender As Object, e As EventArgs) Handles BtnSaveGroup.Click
        Dim groupName As String = TxtGroupName.Text.Trim()
        Dim groupDesc As String = TxtGroupDescription.Text.Trim()

        If String.IsNullOrEmpty(groupName) Then
            XtraMessageBox.Show("اسم المجموعة لا يمكن أن يكون فارغاً.", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtGroupName.Focus()
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                If IsEditMode AndAlso CurrentGroupId > 0 Then
                    ' ---------------- EDIT EXISTING GROUP ----------------
                    Dim oldName As String = ""
                    Dim oldDesc As String = ""

                    Using cmdCheck As New SqlCommand("SELECT GroupName, [Description] FROM Groups WHERE GroupId = @GroupId", conn)
                        cmdCheck.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                        Using reader As SqlDataReader = cmdCheck.ExecuteReader()
                            If reader.Read() Then
                                oldName = reader("GroupName").ToString()
                                oldDesc = reader("Description").ToString()
                            End If
                        End Using
                    End Using

                    ' Only update if changed
                    If oldName = groupName AndAlso oldDesc = groupDesc Then
                        XtraMessageBox.Show("لم يتم إجراء أي تغييرات.", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    Dim sqlUpdate As String = "UPDATE Groups SET GroupName = @Name, [Description] = @Desc WHERE GroupId = @GroupId"
                    Using cmdUpdate As New SqlCommand(sqlUpdate, conn)
                        cmdUpdate.Parameters.AddWithValue("@Name", groupName)
                        cmdUpdate.Parameters.AddWithValue("@Desc", groupDesc)
                        cmdUpdate.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                        cmdUpdate.ExecuteNonQuery()
                    End Using

                    GroupUpdated = True
                    XtraMessageBox.Show("تم تحديث بيانات المجموعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DialogResult = DialogResult.OK
                    Me.Close()

                Else
                    ' ---------------- ADD NEW GROUP ----------------
                    Dim sqlInsert As String = "
                        INSERT INTO Groups (GroupName, [Description], CreatedAt) 
                        VALUES (@Name, @Desc, GETDATE());
                        SELECT SCOPE_IDENTITY();
                    "
                    Using cmd As New SqlCommand(sqlInsert, conn)
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = groupName
                        cmd.Parameters.Add("@Desc", SqlDbType.NVarChar, 250).Value = groupDesc

                        Dim newGroupId As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                        GroupAdded = True

                        ' Open Add Members form automatically for the new group
                        Using addForm As New FrmAddGroupMembers()
                            addForm.CurrentGroupId = newGroupId
                            addForm.StartPosition = FormStartPosition.CenterParent
                            addForm.ShowDialog(Me)
                            If addForm.MembersChanged Then
                                ' Optional: handle updates if needed
                            End If
                        End Using
                    End Using
                End If
            End Using
        Catch ex As Exception
            XtraMessageBox.Show("حدث خطأ أثناء حفظ المجموعة." & vbCrLf & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadGroupData()
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Using cmd As New SqlCommand("SELECT GroupName, Description FROM Groups WHERE GroupId = @GroupId", conn)
                cmd.Parameters.AddWithValue("@GroupId", CurrentGroupId)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        TxtGroupName.Text = reader("GroupName").ToString()
                        TxtGroupDescription.Text = reader("Description").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

End Class
