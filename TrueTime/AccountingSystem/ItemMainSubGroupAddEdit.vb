Imports System.Data.SqlClient
Imports DevExpress.XtraEditors

Public Class ItemMainSubGroupAddEdit
    Dim connectionString As String = GlobalVariables.connectionString
    Dim CurrentItemID As Integer

    Public Sub New(itemNo As Integer)
        InitializeComponent()
        CurrentItemID = itemNo
    End Sub

    Private Sub ItemMainSubGroupAddEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Debug.Print("Form loaded, loading main groups...")
        LoadMainGroups()

        ' 🔹 If only 2 levels are needed, disable and hide the 3rd ComboBox
        If Not GlobalVariables.UseThreeLevelsOfGroupsItem Then
            ComboBoxEdit3.Enabled = False
            ComboBoxEdit3.Visible = False
            pnlSmallGroup.Visible = False
        End If
    End Sub

    ' --------------------------- LOADERS ---------------------------

    Private Sub LoadMainGroups()
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT GroupID, GroupName FROM ItemsMainGroups ORDER BY SortsOrder", con)
                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        'Debug.Print($"Main Groups fetched: {dt.Rows.Count}")

        ComboBoxEdit1.Properties.Items.Clear()
        For Each row As DataRow In dt.Rows
            Dim item As New ComboBoxItem(row("GroupName").ToString(), row("GroupID"))
            ComboBoxEdit1.Properties.Items.Add(item)
        Next

        ComboBoxEdit2.Properties.Items.Clear()
        ComboBoxEdit3.Properties.Items.Clear()
    End Sub

    Private Sub LoadMidGroups(mainGroupID As Integer)
        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT GroupID, GroupName FROM ItemsGroups WHERE MainGroupID=@MainID ORDER BY SortOrder", con)
                cmd.Parameters.AddWithValue("@MainID", mainGroupID)
                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        ComboBoxEdit2.Properties.Items.Clear()
        ComboBoxEdit3.Properties.Items.Clear()
        For Each row As DataRow In dt.Rows
            Dim item As New ComboBoxItem(row("GroupName").ToString(), row("GroupID"))
            ComboBoxEdit2.Properties.Items.Add(item)
        Next
    End Sub

    Private Sub LoadSmallGroups(midGroupID As Integer)
        If Not GlobalVariables.UseThreeLevelsOfGroupsItem Then Exit Sub ' 🔹 Skip if 3rd level is disabled

        Dim dt As New DataTable()
        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("SELECT ID, SubGroupName FROM ItemsSubGroup WHERE MainGroup=@MidID ORDER BY SortOrder", con)
                cmd.Parameters.AddWithValue("@MidID", midGroupID)
                con.Open()
                dt.Load(cmd.ExecuteReader())
            End Using
        End Using

        ComboBoxEdit3.Properties.Items.Clear()
        For Each row As DataRow In dt.Rows
            Dim item As New ComboBoxItem(row("SubGroupName").ToString(), row("ID"))
            ComboBoxEdit3.Properties.Items.Add(item)
        Next
    End Sub

    ' --------------------------- COMBO EVENTS ---------------------------

    Private Sub ComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit1.SelectedIndexChanged
        Dim selectedItem As ComboBoxItem = TryCast(ComboBoxEdit1.SelectedItem, ComboBoxItem)
        If selectedItem IsNot Nothing Then
            LoadMidGroups(selectedItem.ID)
        End If
    End Sub

    Private Sub ComboBoxEdit2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit2.SelectedIndexChanged
        Try
            Dim selectedItem As ComboBoxItem = TryCast(ComboBoxEdit2.SelectedItem, ComboBoxItem)
            If selectedItem IsNot Nothing AndAlso GlobalVariables.UseThreeLevelsOfGroupsItem Then
                LoadSmallGroups(selectedItem.ID)
                If ComboBoxEdit3.Properties.Items.Count = 0 Then
                    ComboBoxEdit3.Text = ""
                End If
            Else
                ComboBoxEdit3.Properties.Items.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("حدث خطأ عند اختيار المجموعة الفرعية الأولى: " & ex.Message)
        End Try
    End Sub

    ' --------------------------- SAVE BUTTON ---------------------------

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim mainID As Integer = If(TryCast(ComboBoxEdit1.SelectedItem, ComboBoxItem)?.ID, 0)
        Dim midID As Integer = If(TryCast(ComboBoxEdit2.SelectedItem, ComboBoxItem)?.ID, 0)
        Dim smallID As Integer = If(TryCast(ComboBoxEdit3.SelectedItem, ComboBoxItem)?.ID, 0)

        Dim sql As String = ""
        Dim groupID As Integer = 0

        ' 🔹 Decide which group level to save depending on UseThreeLevels
        If GlobalVariables.UseThreeLevelsOfGroupsItem Then
            If smallID > 0 Then
                sql = "UPDATE Items SET MainGroupID = NULL, GroupID = NULL, SubGroupID = @GroupID WHERE ItemNo = @ItemID"
                groupID = smallID
            ElseIf midID > 0 Then
                sql = "UPDATE Items SET MainGroupID = NULL, GroupID = @GroupID, SubGroupID = NULL WHERE ItemNo = @ItemID"
                groupID = midID
            ElseIf mainID > 0 Then
                sql = "UPDATE Items SET MainGroupID = @GroupID, GroupID = NULL, SubGroupID = NULL WHERE ItemNo = @ItemID"
                groupID = mainID
            Else
                MessageBox.Show("الرجاء اختيار مجموعة قبل الحفظ.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            ' 🔹 Only 2 levels (Main + Mid)
            If midID > 0 Then
                sql = "UPDATE Items SET MainGroupID = NULL, GroupID = @GroupID, SubGroupID = NULL WHERE ItemNo = @ItemID"
                groupID = midID
            ElseIf mainID > 0 Then
                sql = "UPDATE Items SET MainGroupID = @GroupID, GroupID = NULL, SubGroupID = NULL WHERE ItemNo = @ItemID"
                groupID = mainID
            Else
                MessageBox.Show("الرجاء اختيار مجموعة قبل الحفظ.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        Try
            Using con As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@GroupID", groupID)
                    cmd.Parameters.AddWithValue("@ItemID", CurrentItemID)

                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("تم الحفظ بنجاح.", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الحفظ: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class

' --------------------------- HELPER CLASS ---------------------------
Public Class ComboBoxItem
    Public Property Name As String
    Public Property ID As Integer

    Public Sub New(name As String, id As Integer)
        Me.Name = name
        Me.ID = id
    End Sub

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class
