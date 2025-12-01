Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraScheduler
Imports Outlook = Microsoft.Office.Interop.Outlook

Public Class AttachmentDirectDisplay
    Public _Filter As String
    Public _DocCode As String
    Public _DocName As Integer
    Public _Referance As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetAttachments()
    End Sub

    Private Sub RepositoryOpenFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryOpenFile.ButtonClick
        Dim _DocID As Integer
        _DocID = GridView3.GetFocusedRowCellValue("DocID")
        OpenAttachment(_DocID)
    End Sub
    Public Sub GetAttachments()
        Select Case _Filter
            Case "Document"
                GridControl2.DataSource = GetAttachmentsByDocCode(_DocCode, _DocName)
            Case "All"
                GridControl2.DataSource = GetAttachmentsByDocCode("*", "*")
        End Select
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim _DocName, _DocID As String
        _DocName = GridView3.GetFocusedRowCellValue("DocName")
        _DocID = GridView3.GetFocusedRowCellValue("DocID")
        If XtraMessageBox.Show(" هل تريد حذف الوثيقة " & _DocName & " ؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                Dim Sql As New SQLControl
                Dim Sqlstring As String
                Sqlstring = " Delete from ArchiveDocs Where DocID=" & _DocID
                Sql.SqlTrueAccountingRunQuery(Sqlstring)
                XtraMessageBox.Show(" تم حذف الوثيقة بنجاح ")
                GetAttachments()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub AttachmentDirectDisplay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not System.IO.Directory.Exists(Path.Combine(System.IO.Directory.GetCurrentDirectory() & "\Attachment"))) Then
            System.IO.Directory.CreateDirectory(Path.Combine(System.IO.Directory.GetCurrentDirectory() & "\Attachment"))
        End If
    End Sub

    Private Sub RepositoryEditFile_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryEditFile.ButtonClick
        Dim _DocID As Integer
        _DocID = GridView3.GetFocusedRowCellValue("DocID")
        Dim F As New AttachmentEdit
        With F
            .DocIDEdit.EditValue = _DocID
            If .ShowDialog <> DialogResult.OK Then
                GetAttachments()
            End If
        End With

    End Sub

    Private Sub RepositoryEmailFile_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryEmailFile.ButtonClick
        Try
            Dim _DocType As String
            Dim _DocID As Integer
            Dim _DocName As String
            Dim _ArchiveType As String
            Dim FILE_NAME As String
            _DocID = GridView3.GetFocusedRowCellValue("DocID")
            _DocName = GridView3.GetFocusedRowCellValue("DocName")
            _DocType = GridView3.GetFocusedRowCellValue("DocType")
            _ArchiveType = GetArchiveTypeForDocument(_DocID)

            Select Case _ArchiveType
                Case "Sql"
                    Dim con As String = My.Settings.TrueTimeConnectionString
                    Dim connection As SqlConnection = New SqlConnection(con)
                    connection.Open()
                    Dim sqlstring As String = "select [DocFile] from [ArchiveDocs] where [DocID]=" & "'" & _DocID & "'"
                    Dim cmd As SqlCommand = New SqlCommand(sqlstring, connection)
                    Dim dr As SqlDataReader = cmd.ExecuteReader()
                    Dim data As Byte() = Nothing
                    While dr.Read()
                        data = CType(dr(0), Byte())
                    End While
                    FILE_NAME = Path.Combine(System.IO.Directory.GetCurrentDirectory() & "\Attachment\", _DocID & _DocType)
                    Using fs = New FileStream(FILE_NAME, FileMode.Create, FileAccess.Write)
                        fs.Write(data, 0, data.Length)
                    End Using
                    SendEMailThroughOutlook("Info@Info.Com", _DocName, "Attachment", FILE_NAME, _DocName)
                Case "Folder"
                    FILE_NAME = Path.Combine(GetArchive_FolderPath() & "\", _DocID & _DocType)
                    SendEMailThroughOutlook("Info@Info.Com", _DocName, "Attachment", FILE_NAME, _DocName)
            End Select



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub
    Public Shared Sub SendEMailThroughOutlook(ByVal toList As String, ByVal subject As String, ByVal msg As String, ByVal Optional attachementFileName As String = Nothing, ByVal Optional AttachemntName As String = Nothing)
        Dim oApp As Outlook.Application = New Outlook.Application()
        Dim oMsg As Outlook.MailItem = CType(oApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
        oMsg.HTMLBody += msg
        Dim sDisplayName As String = AttachemntName
        Dim iPosition As Integer = CInt(oMsg.Body.Length) + 1
        Dim iAttachType As Integer = CInt(Outlook.OlAttachmentType.olByValue)
        Dim oAttach As Outlook.Attachment = oMsg.Attachments.Add(attachementFileName, iAttachType, iPosition, sDisplayName)
        oMsg.Subject = subject
        Dim oRecips As Outlook.Recipients = CType(oMsg.Recipients, Outlook.Recipients)
        Dim oRecip As Outlook.Recipient = CType(oRecips.Add(toList), Outlook.Recipient)
        oRecip.Resolve()
        oMsg.Display()
    End Sub
    Private Function GetArchiveTypeForDocument(_DocID As Integer)
        Dim _Type As String
        Dim sql As New SQLControl
        Try
            Dim sqlstring As String = "select [ArchiveType] from [ArchiveDocs] where [DocID]=" & "'" & _DocID & "'"
            sql.SqlTrueTimeRunQuery(sqlstring)
            _Type = (sql.SQLDS.Tables(0).Rows(0).Item("ArchiveType"))
        Catch ex As Exception
            _Type = "Sql"
        End Try
        Return _Type
    End Function
End Class