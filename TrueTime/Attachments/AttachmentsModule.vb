Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Module AttachmentsModule
    Public Function GetAttachmentsByReferance(ReferanceID As String) As DataTable
        Dim _Table As New DataTable
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [DocID],[DocName],[DocAccountCode],[DocInputUser],[DocSort1],[DocSort2],
                                                [DocCostCenter],[DocDetails],[DocLocation],[DocType],[DocStatus],[DocInputDate],
                                                [DocExpireDate],[DocCreatedDate],[DocNo],[DocCode],[TextDateModified]
                                        FROM [ArchiveDocs]
                                        Where [ReferanceNo]='" & ReferanceID & "'"
            SQl.SqlTrueTimeRunQuery(SqlString)
            _Table = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return _Table
    End Function

    Public Function GetAttachmentsByAccount(ReferanceID As String) As DataTable
        Dim _Table As New DataTable
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [DocID],[DocName],[DocAccountCode],[DocInputUser],[DocSort1],[DocSort2],
                                                [DocCostCenter],[DocDetails],[DocLocation],[DocType],[DocStatus],[DocInputDate],
                                                [DocExpireDate],[DocCreatedDate],[DocNo],[DocCode],[TextDateModified],[EmployeeName] 
                                        FROM [ArchiveDocs]
                                             left join EmployeesData on ArchiveDocs.DocAccountCode = EmployeesData.EmployeeID 
                                        where EmployeeID = '1'  "
            SQl.SqlTrueTimeRunQuery(SqlString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return _Table
    End Function

    Public Function GetAttachmentsByDocCode(DocCode As String, DocName As String) As DataTable
        Dim _Table As New DataTable
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [DocID],[DocName],[DocAccountCode],[DocInputUser],[DocSort2],
                                                [DocCostCenter],[DocDetails],[DocLocation],[DocType],[DocStatus],[DocInputDate],
                                                [DocExpireDate],[DocCreatedDate],[DocNo],[DocCode],[TextDateModified],S.ArchiveDocsSorts1 As DocSort1,LinkDocNo,D.Name as LinkDocName,
                                                Case when A.ReferanceNo =0 then E.EmployeeName  when A.EmployeeID=0 then R.RefName when A.ReferanceNo=0 and A.ReferanceNo =0 then '' end as RefName
                                        FROM [ArchiveDocs] A
                                        Left Join [dbo].[ArchiveDocsSorts1] S On A.DocSort1=S.[ID]
                                        left join EmployeesData E on E.EmployeeID=A.EmployeeID
                                        left join Referencess R on A.ReferanceNo=R.RefNo
                                        left join DocNames D on A.LinkDocType= D.id
                                        Where 1 = 1"
            If DocCode <> "*" Then SqlString += " And  LinkDocNo  ='" & DocCode & "'"
            If DocName <> "*" Then SqlString += " And  LinkDocType='" & DocName & "'"
            SQl.SqlTrueTimeRunQuery(SqlString)
            _Table = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return _Table
    End Function
    Public Sub OpenAttachment(DocID As Integer)
        Try
            Dim _DocType As String = ""
            Dim _DocID As Integer
            Dim _ArchiveType As String = "Sql"
            _DocID = DocID
            Dim con As String = My.Settings.TrueTimeConnectionString
            Dim connection As SqlConnection = New SqlConnection(con)
            connection.Open()
            Dim sql As String = "select [DocFile],[DocType],[ArchiveType] from [ArchiveDocs] where [DocID]=" & "'" & _DocID & "'"
            Dim cmd As SqlCommand = New SqlCommand(sql, connection)
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim data As Byte() = Nothing
            Dim FILE_NAME As String

            While dr.Read()
                If Not IsDBNull(dr(2)) Then
                    _ArchiveType = dr(2)
                Else
                    _ArchiveType = "Sql"
                End If

                Select Case _ArchiveType
                    Case "Sql"
                        data = CType(dr(0), Byte())
                        _DocType = dr(1)
                        If _DocType = ".pdf" Then
                            Dim File As String = CType(DocID, String)
                            LoadPdfFile(File)
                            Dim mydialogbox As New AttachmentDispaly
                            AttachmentDispaly.ShowDialog()
                        Else
                            FILE_NAME = Path.Combine(GetArchive_FolderPath() & "\", _DocID & _DocType)
                            Using fs = New FileStream(FILE_NAME, FileMode.Create, FileAccess.Write)
                                fs.Write(data, 0, data.Length)
                            End Using
                            If System.IO.File.Exists(FILE_NAME) = True Then
                                Process.Start(FILE_NAME)
                            Else
                                MsgBox("File Does Not Exist")
                            End If
                        End If
                    Case "Folder"
                        _DocType = dr(1)
                        FILE_NAME = Path.Combine(GetArchive_FolderPath() & "\", _DocID & _DocType)
                        Dim psi As ProcessStartInfo = New ProcessStartInfo(FILE_NAME)
                        psi.UseShellExecute = True
                        Process.Start(psi)
                End Select
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Function GetArchive_SaveDataInSqlOrFolder() As String
        Dim _ArchiveType As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_SaveDataInSqlOrFolder'")
            _ArchiveType = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _ArchiveType = "Sql"
        End Try
        Return _ArchiveType
    End Function
    Public Function GetArchive_FolderPath() As String
        Dim _Folder As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_FolderPath'")
            _Folder = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _Folder = "C:\Archive"
        End Try
        Return _Folder
    End Function

End Module
