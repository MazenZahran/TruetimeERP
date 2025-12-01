Imports System.Data

''' <summary>
''' Helper class for managing notifications
''' </summary>
Public Class NotificationHelper

    ''' <summary>
    ''' Add a new notification to the database
    ''' </summary>
    Public Shared Function AddNotification(
        title As String,
        message As String,
        Optional notificationType As String = "Info",
        Optional userID As String = Nothing,
     Optional relatedModule As String = Nothing,
        Optional relatedID As Integer? = Nothing,
    Optional priority As Integer = 0) As Boolean

        Try
            Dim sql As New SQLControl

            ' Escape single quotes in strings
            title = title.Replace("'", "''")
            message = message.Replace("'", "''")

            Dim userFilter As String = If(String.IsNullOrEmpty(userID), "NULL", "'" & userID & "'")
            Dim moduleFilter As String = If(String.IsNullOrEmpty(relatedModule), "NULL", "'" & relatedModule & "'")
            Dim idFilter As String = If(relatedID.HasValue, relatedID.Value.ToString(), "NULL")

            Dim sqlString As String = $"INSERT INTO [dbo].[Notifications] 
  (UserID, Title, Message, NotificationType, IsRead, CreatedDate, RelatedModule, RelatedID, Priority)
       VALUES 
          ({userFilter}, '{title}', '{message}', '{notificationType}', 0, GETDATE(), {moduleFilter}, {idFilter}, {priority})"

            sql.SqlTrueTimeRunQuery(sqlString)
            Return True

        Catch ex As Exception
            ' Log error or handle silently
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Add notification for all users
    ''' </summary>
    Public Shared Function AddGlobalNotification(
        title As String,
    message As String,
        Optional notificationType As String = "Info",
      Optional priority As Integer = 0) As Boolean

        Return AddNotification(title, message, notificationType, Nothing, Nothing, Nothing, priority)
    End Function

    ''' <summary>
    ''' Add notification for specific user
    ''' </summary>
    Public Shared Function AddUserNotification(
userID As String,
        title As String,
        message As String,
     Optional notificationType As String = "Info",
    Optional priority As Integer = 0) As Boolean

        Return AddNotification(title, message, notificationType, userID, Nothing, Nothing, priority)
    End Function

    ''' <summary>
    ''' Delete old read notifications (cleanup)
    ''' </summary>
    Public Shared Sub CleanupOldNotifications(Optional daysOld As Integer = 30)
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = $"DELETE FROM [dbo].[Notifications] 
          WHERE IsRead = 1 
                AND ReadDate < DATEADD(day, -{daysOld}, GETDATE())"

            sql.SqlTrueTimeRunQuery(sqlString)

        Catch ex As Exception
            ' Handle silently
        End Try
    End Sub

    ''' <summary>
    ''' Get unread notification count for user
    ''' </summary>
    Public Shared Function GetUnreadCount(userID As String) As Integer
        Try
            Dim sql As New SQLControl
            Dim sqlString As String = $"SELECT COUNT(*) as UnreadCount 
       FROM [dbo].[Notifications] 
                WHERE (UserID = '{userID}' OR UserID IS NULL) 
 AND IsRead = 0"

            sql.SqlTrueTimeRunQuery(sqlString)

            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(sql.SQLDS.Tables(0).Rows(0)("UnreadCount"))
            End If

            Return 0

        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Sample usage: Add notification for salary posting
    ''' </summary>
    Public Shared Sub NotifySalaryPosted(month As String, year As String)
        AddGlobalNotification(
            "Salary Posted",
            $"Salaries for {month}/{year} have been posted and are ready for review.",
    "Success",
        1 ' High priority
   )
    End Sub

    ''' <summary>
    ''' Sample usage: Add notification for pending approval
    ''' </summary>
    Public Shared Sub NotifyPendingApproval(userID As String, documentType As String, documentNo As Integer)
        AddUserNotification(
        userID,
       "Approval Required",
    $"{documentType} #{documentNo} is waiting for your approval.",
     "Warning",
            2 ' Urgent priority
        )
    End Sub

    ''' <summary>
    ''' Sample usage: Add notification for vacation request
    ''' </summary>
    Public Shared Sub NotifyVacationRequest(userID As String, employeeName As String, vacationID As Integer)
        AddUserNotification(
     userID,
 "Vacation Request",
     $"{employeeName} has submitted a vacation request that requires your approval.",
"Info",
    1 ' High priority
        )
    End Sub

    ''' <summary>
    ''' Sample usage: Add notification for document expiry
    ''' </summary>
    Public Shared Sub NotifyDocumentExpiry(userID As String, documentName As String, expiryDate As Date)
        AddUserNotification(
      userID,
            "Document Expiring Soon",
            $"{documentName} will expire on {expiryDate:dd/MM/yyyy}. Please renew it.",
          "Warning",
            2 ' Urgent priority
        )
    End Sub

End Class
