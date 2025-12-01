Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data

Public Class NotificationViewer
    Private mainForm As Main
    Private notificationsData As DataTable

    Public Sub New(parentForm As Main)
        InitializeComponent()
        mainForm = parentForm
    End Sub

    Private Sub NotificationViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
    End Sub

    ''' <summary>
    ''' Load notifications data into the grid
    ''' </summary>
    Public Sub LoadNotifications(data As DataTable)
        notificationsData = data
        GridControlNotifications.DataSource = notificationsData

        ' Update title with count
        Me.Text = $"Notifications ({notificationsData.Rows.Count})"
    End Sub

    ''' <summary>
    ''' Configure grid appearance and columns
    ''' </summary>
    Private Sub ConfigureGrid()
        ' Configure GridView
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsView.ShowGroupPanel = False
        GridView1.OptionsView.ColumnAutoWidth = False

        ' Hide ID column
        If GridView1.Columns("NotificationID") IsNot Nothing Then
            GridView1.Columns("NotificationID").Visible = False
        End If

        ' Configure columns
        If GridView1.Columns("Title") IsNot Nothing Then
            GridView1.Columns("Title").Caption = "Title"
            GridView1.Columns("Title").Width = 150
        End If

        If GridView1.Columns("Message") IsNot Nothing Then
            GridView1.Columns("Message").Caption = "Message"
            GridView1.Columns("Message").Width = 300
        End If

        If GridView1.Columns("NotificationType") IsNot Nothing Then
            GridView1.Columns("NotificationType").Caption = "Type"
            GridView1.Columns("NotificationType").Width = 80
        End If

        If GridView1.Columns("IsRead") IsNot Nothing Then
            GridView1.Columns("IsRead").Caption = "Read"
            GridView1.Columns("IsRead").Width = 60
        End If

        If GridView1.Columns("CreatedDate") IsNot Nothing Then
            GridView1.Columns("CreatedDate").Caption = "Date"
            GridView1.Columns("CreatedDate").Width = 120
            GridView1.Columns("CreatedDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns("CreatedDate").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm"
        End If

        If GridView1.Columns("Priority") IsNot Nothing Then
            GridView1.Columns("Priority").Caption = "Priority"
            GridView1.Columns("Priority").Width = 70
        End If

        If GridView1.Columns("RelatedModule") IsNot Nothing Then
            GridView1.Columns("RelatedModule").Caption = "Module"
            GridView1.Columns("RelatedModule").Width = 100
        End If
    End Sub

    ''' <summary>
    ''' Mark selected notification as read
    ''' </summary>
    Private Sub BtnMarkAsRead_Click(sender As Object, e As EventArgs) Handles BtnMarkAsRead.Click
        Try
            Dim selectedRow As Integer = GridView1.FocusedRowHandle
            If selectedRow >= 0 Then
                Dim notificationID As Integer = Convert.ToInt32(GridView1.GetRowCellValue(selectedRow, "NotificationID"))
                Dim isRead As Boolean = Convert.ToBoolean(GridView1.GetRowCellValue(selectedRow, "IsRead"))

                If Not isRead Then
                    'mainForm.MarkNotificationAsRead(notificationID)

                    ' Update local data
                    GridView1.SetRowCellValue(selectedRow, "IsRead", True)
                    XtraMessageBox.Show("Notification marked as read.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show("This notification is already read.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                XtraMessageBox.Show("Please select a notification.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Mark all notifications as read
    ''' </summary>
    'Private Sub BtnMarkAllAsRead_Click(sender As Object, e As EventArgs) Handles BtnMarkAllAsRead.Click
    '    Try
    '        If XtraMessageBox.Show("Mark all notifications as read?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
    '            mainForm.MarkAllNotificationsAsRead()

    '            ' Update all rows
    '            For i As Integer = 0 To GridView1.RowCount - 1
    '                GridView1.SetRowCellValue(i, "IsRead", True)
    '            Next

    '            XtraMessageBox.Show("All notifications marked as read.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    ''' <summary>
    ''' Double-click to view notification details
    ''' </summary>
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            Dim selectedRow As Integer = GridView1.FocusedRowHandle
            If selectedRow >= 0 Then
                Dim title As String = GridView1.GetRowCellValue(selectedRow, "Title").ToString()
                Dim message As String = GridView1.GetRowCellValue(selectedRow, "Message").ToString()
                Dim type As String = GridView1.GetRowCellValue(selectedRow, "NotificationType").ToString()
                Dim createdDate As DateTime = Convert.ToDateTime(GridView1.GetRowCellValue(selectedRow, "CreatedDate"))

                Dim details As String = $"Title: {title}" & vbCrLf &
                 $"Type: {type}" & vbCrLf &
             $"Date: {createdDate:dd/MM/yyyy HH:mm}" & vbCrLf & vbCrLf &
            $"Message:" & vbCrLf & message

                XtraMessageBox.Show(details, "Notification Details", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Mark as read
                Dim notificationID As Integer = Convert.ToInt32(GridView1.GetRowCellValue(selectedRow, "NotificationID"))
                'mainForm.MarkNotificationAsRead(notificationID)
                GridView1.SetRowCellValue(selectedRow, "IsRead", True)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Apply conditional formatting for unread notifications
    ''' </summary>
    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim isRead As Boolean = Convert.ToBoolean(GridView1.GetRowCellValue(e.RowHandle, "IsRead"))
                Dim priority As Integer = Convert.ToInt32(GridView1.GetRowCellValue(e.RowHandle, "Priority"))

                If Not isRead Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)

                    ' Color by priority
                    Select Case priority
                        Case 2 ' Urgent
                            e.Appearance.BackColor = Color.FromArgb(255, 230, 230)
                        Case 1 ' High
                            e.Appearance.BackColor = Color.FromArgb(255, 245, 230)
                        Case Else ' Normal
                            e.Appearance.BackColor = Color.FromArgb(230, 240, 255)
                    End Select
                End If
            End If
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ' Reload notifications from parent form
        Dim sql As New SQLControl
        Dim sqlString As String = "SELECT TOP 50 
        NotificationID,
     Title,
      Message,
 NotificationType,
        IsRead,
          CreatedDate,
   RelatedModule,
  Priority
                    FROM [dbo].[Notifications] 
          WHERE (UserID = '" & GlobalVariables.CurrUser & "' OR UserID IS NULL) 
    ORDER BY Priority DESC, CreatedDate DESC"

        sql.SqlTrueTimeRunQuery(sqlString)
        LoadNotifications(sql.SQLDS.Tables(0))
    End Sub
End Class
