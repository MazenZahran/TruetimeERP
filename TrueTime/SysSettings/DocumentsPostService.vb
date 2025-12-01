Imports System.Data.SqlClient

Public Class DocumentsPostService

    ''' <summary>
    ''' Attempts to acquire an exclusive lock on a document for editing.
    ''' Returns True if lock acquired, False if document is already locked by another user.
    ''' </summary>
    Public Function TryLockDocument(docCode As String) As Boolean
        Dim sql As New SQLControl

        Try
            Dim query As String = $"EXEC TryLockDocument @DocCode = '{docCode}', @UserID = {GlobalVariables.CurrUser}, @DeviceName = '{GlobalVariables.CurrDevice}'"
            sql.SqlTrueAccountingRunQuery(query)

            If sql.SQLDS.Tables.Count > 0 AndAlso sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return (CInt(sql.SQLDS.Tables(0).Rows(0)("Result")) = 1)
            End If
        Catch ex As Exception
            Debug.WriteLine($"TryLockDocument Error: {ex.Message}")
        End Try

        Return False
    End Function

    Public Sub ReleaseDocumentLock(docCode As String)
        Dim sql As New SQLControl

        Try
            Dim query As String = $"EXEC ReleaseDocumentLock @DocCode = '{docCode}'"
            sql.SqlTrueAccountingRunQuery(query)
        Catch ex As Exception
            Debug.WriteLine($"ReleaseDocumentLock Error: {ex.Message}")
        End Try
    End Sub

    Public Shared Function ClearDocumentLocksByDevice(deviceName As String) As Integer
        If String.IsNullOrWhiteSpace(deviceName) Then
            Throw New ArgumentException("DeviceName must not be empty.", NameOf(deviceName))
        End If

        Const sql As String = "
            DELETE FROM dbo.DocumentLocks
            WHERE DeviceName = @DeviceName;
        "

        Using cn As New SqlConnection(My.Settings.TrueTimeConnectionString),
              cmd As New SqlCommand(sql, cn)

            cmd.Parameters.Add("@DeviceName", SqlDbType.NVarChar, 100).Value = deviceName

            cn.Open()
            Dim affectedRows As Integer = cmd.ExecuteNonQuery()
            Return affectedRows
        End Using
    End Function
End Class
