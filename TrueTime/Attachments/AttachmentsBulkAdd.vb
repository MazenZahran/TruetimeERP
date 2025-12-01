Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class AttachmentsBulkAdd
    Dim _Table As DataTable
    Dim _ArchiveApproach As String
    Sub AttachmentsBulkAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTempTable()
        GridControl1.DataSource = _Table
        LoadingSorts1()
        SearchAccount.Properties.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
        SearchSystemDocName.Properties.DataSource = GetSystemDocNames()
        ReferanceID.Properties.DataSource = GetReferences(-1, -1, -1)
        _ArchiveApproach = GetArchiveApproachFromSettings()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click


        If String.IsNullOrEmpty(TextFilePath.Text) Then
            XtraMessageBox.Show("خطأ: يجب اختيار ملف")
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextFileName.Text) Then
            XtraMessageBox.Show("خطأ: يجب كتابة اسم الملف")
            Exit Sub
        End If

        Dim Row1 As DataRow
        Row1 = _Table.NewRow()
        Row1.Item("DocName") = TextFileName.Text
        Row1.Item("DocAccountCode") = SearchAccount.EditValue
        Row1.Item("DocSort1") = DocSort1.EditValue
        Row1.Item("FilePath") = TextFilePath.EditValue
        Row1.Item("LinkDocNo") = LinkDocNo.EditValue
        Row1.Item("LinkDocType") = SearchSystemDocName.EditValue
        Row1.Item("DocDetails") = MemoNotes.EditValue
        If Not IsNothing(SearchLookEmployees.EditValue) Then
            Row1.Item("EmployeeID") = SearchLookEmployees.EditValue
        Else
            Row1.Item("EmployeeID") = 0
        End If
        If Not IsNothing(ReferanceID.EditValue) Then Row1.Item("ReferanceNo") = ReferanceID.EditValue
        Row1.Item("ArchiveType") = _ArchiveApproach
        _Table.Rows.Add(Row1)
        TextFilePath.Text = ""
        TextFileName.Text = ""

    End Sub
    Private Sub CreateTempTable()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [DocID]
                      ,[DocName],[DocAccountCode],[DocInputUser],     [DocSort1]
                      ,[DocSort2],[DocCostCenter],[DocDetails],    [DocLocation]
                      ,[DocType],[DocFile],[DocStatus],           [DocInputDate]
                      ,[DocExpireDate],[DocCreatedDate],[DocNo],       [DocCode]
                      ,[TextDateModified],[DocVersion],[LinkDocType],[LinkDocNo]
                      , '' as FilePath,[ReferanceNo] ,[EmployeeID],[ArchiveType]
        FROM [ArchiveDocs] Where 1<>1"
        Sql.SqlTrueTimeRunQuery(SqlString)
        _Table = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        '   XtraOpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim res As DialogResult = XtraOpenFileDialog1.ShowDialog()
        Dim fileName As String = Path.GetFileName(XtraOpenFileDialog1.FileName)
        Dim fileExtension As String = Path.GetExtension(XtraOpenFileDialog1.FileName)
        If String.IsNullOrEmpty(fileExtension) Then
            Return
        End If
        Dim fileLocation As String = XtraOpenFileDialog1.FileName
        TextFilePath.Text = XtraOpenFileDialog1.FileName
        TextFileName.Text = Path.GetFileName(XtraOpenFileDialog1.FileName)
    End Sub
    Private Sub LoadingSorts1()
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [ID],[ArchiveDocsSorts1]  FROM [ArchiveDocsSorts1]  "
            SQl.SqlTrueTimeRunQuery(SqlString)
            DocSort1.Properties.DataSource = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        Dim view = TryCast(GridControl1.FocusedView, GridView)
        view.DeleteSelectedRows()
        view.UpdateSummary()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If String.IsNullOrEmpty(Me.SearchSystemDocName.Text) Then
            Me.SearchSystemDocName.EditValue = 0
        End If

        If DocSort1.Text = "" Then
            MsgBoxShowError(" يجب تحديد تنيف للملف المرفق ")
            Exit Sub
        End If

        Dim Archive_SaveDataInSqlOrFolder, Archive_FolderPath As String
        Archive_SaveDataInSqlOrFolder = GetArchive_SaveDataInSqlOrFolder()
        If Archive_SaveDataInSqlOrFolder = "Folder" Then
            Archive_FolderPath = GetArchive_FolderPath()
        Else
            Archive_FolderPath = ""
        End If

        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            Dim filePath As String = GridView1.GetRowCellValue(i, "FilePath")
            If String.IsNullOrEmpty(filePath) Then Exit Sub
            Dim _InputDateTime As String = Format(Now, "yyyy-M-dd HH:mm")
            Dim DocInputUser As Integer = GlobalVariables.CurrUser
            Dim DocSort1 As String = GridView1.GetRowCellValue(i, "DocSort1")

            Dim Referance As Integer = 0
            If Not IsDBNull(GridView1.GetRowCellValue(i, "ReferanceNo")) Then
                Referance = GridView1.GetRowCellValue(i, "ReferanceNo")
            End If

            Dim DocName As String = "0"
            If Not IsDBNull(GridView1.GetRowCellValue(i, "DocName")) Then
                DocName = GridView1.GetRowCellValue(i, "DocName")
            End If

            Dim DocAccountCode As String = "0"
            If Not IsDBNull(GridView1.GetRowCellValue(i, "DocAccountCode")) Then
                DocAccountCode = GridView1.GetRowCellValue(i, "DocAccountCode")
            End If

            Dim DocDetails As String = ""
            If Not IsDBNull(GridView1.GetRowCellValue(i, "DocDetails")) Then
                DocDetails = GridView1.GetRowCellValue(i, "DocDetails")
            End If

            Dim LinkDocNo As String = ""
            If Not IsDBNull(GridView1.GetRowCellValue(i, "LinkDocNo")) Then
                LinkDocNo = GridView1.GetRowCellValue(i, "LinkDocNo")
            End If

            Dim EmployeeID As Integer = 0
            If Not IsDBNull(GridView1.GetRowCellValue(i, "EmployeeID")) Then
                EmployeeID = GridView1.GetRowCellValue(i, "EmployeeID")
            End If

            Dim bytes As Byte() = Nothing
            Dim fileExtension As String = ""


            fileExtension = Path.GetExtension(filePath)
            Dim filename As String = Path.GetFileName(filePath)
            Select Case Archive_SaveDataInSqlOrFolder
                Case "Sql"
                    Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                    Dim br As BinaryReader = New BinaryReader(fs)
                    bytes = br.ReadBytes(Convert.ToInt32(fs.Length))
                    br.Close()
                    fs.Close()
                Case "Folder"
                    My.Computer.FileSystem.CopyFile(
                                filePath,
                                Archive_FolderPath & "\" & GetMaxFileID() & "" & fileExtension,
                                FileIO.UIOption.OnlyErrorDialogs,
                                FileIO.UICancelOption.DoNothing)
            End Select




            'insert the file into database
            Dim strQuery As String = "insert into [ArchiveDocs] (DocName,DocFile,DocAccountCode,DocInputUser,DocSort1,DocDetails,DocType,
                                                                 DocInputDate,LinkDocNo,DocStatus,ReferanceNo,LinkDocType,DocCode,EmployeeID,DocLocation,ArchiveType) 
                                      values (@DocName,@DocFile,@DocAccountCode,@DocInputUser,@DocSort1,@DocDetails,@DocType,
                                              @DocInputDate,@LinkDocNo,1,@ReferanceNo,@LinkDocType,@DocCode,@EmployeeID,@DocLocation,@ArchiveType)"
            Dim cmd As SqlCommand = New SqlCommand(strQuery)
            cmd.Parameters.Add("@DocName", SqlDbType.NVarChar).Value = DocName
            If Archive_SaveDataInSqlOrFolder = "Sql" Then
                cmd.Parameters.Add("@DocFile", SqlDbType.Binary).Value = bytes
            Else
                cmd.Parameters.Add("@DocFile", SqlDbType.Binary).Value = DBNull.Value
            End If
            cmd.Parameters.Add("@DocAccountCode", SqlDbType.VarChar).Value = DocAccountCode
            cmd.Parameters.Add("@DocInputUser", SqlDbType.Int).Value = DocInputUser
            cmd.Parameters.Add("@DocSort1", SqlDbType.NVarChar).Value = DocSort1
            cmd.Parameters.Add("@DocDetails", SqlDbType.NVarChar).Value = DocDetails
            cmd.Parameters.Add("@DocType", SqlDbType.VarChar).Value = fileExtension
            cmd.Parameters.Add("@DocInputDate", SqlDbType.DateTime).Value = _InputDateTime
            cmd.Parameters.Add("@LinkDocNo", SqlDbType.VarChar).Value = LinkDocNo
            cmd.Parameters.Add("@ReferanceNo", SqlDbType.VarChar).Value = Referance
            cmd.Parameters.Add("@LinkDocType", SqlDbType.VarChar).Value = Me.SearchSystemDocName.EditValue
            cmd.Parameters.Add("@DocCode", SqlDbType.VarChar).Value = CreateRandomCode()
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID
            If Archive_SaveDataInSqlOrFolder <> "Sql" Then
                cmd.Parameters.Add("@DocLocation", SqlDbType.VarChar).Value = Archive_FolderPath & "\" & GetMaxFileID() & "." & fileExtension
            Else
                cmd.Parameters.Add("@DocLocation", SqlDbType.VarChar).Value = DBNull.Value
            End If
            cmd.Parameters.Add("@ArchiveType", SqlDbType.VarChar).Value = _ArchiveApproach
            InsertUpdateData(cmd)
        Next
        Me.Dispose()
    End Sub
    Public Function InsertUpdateData(ByVal cmd As SqlCommand) As Boolean
        Dim strConnString As String = My.Settings.TrueTimeConnectionString
        Dim con As New SqlConnection(strConnString)
        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        Finally
            con.Close()
            con.Dispose()
        End Try

    End Function

    Private Sub ReferanceID_EditValueChanged(sender As Object, e As EventArgs) Handles ReferanceID.EditValueChanged
        Dim RefData = GetRefranceData(ReferanceID.EditValue)
        SearchAccount.EditValue = (RefData.RefAccID)
    End Sub

    Private Sub DocSort1_Properties_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles DocSort1.Properties.AddNewValue
        Lists2.NavigationPane1.SelectedPage = Lists2.NavigationPane1.Pages(6)
        If Lists2.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            LoadingSorts1()
        End If
    End Sub
    Private Function GetMaxFileID() As Integer
        Dim _DocID As Integer
        Try
            Dim sql As New SQLControl
            Dim SqlString As String = " Select IsNull(Max(DocID),0) As FileName from ArchiveDocs"
            sql.SqlTrueTimeRunQuery(SqlString)
            _DocID = CInt(sql.SQLDS.Tables(0).Rows(0).Item("FileName")) + 1
        Catch ex As Exception
            _DocID = 0
        End Try
        Return _DocID
    End Function
    Private Function GetFileName(ByVal path As String) As String
        Dim _filename As String = System.IO.Path.GetFileName(path)
        Return _filename
    End Function

    Private Sub TextFilePath_EditValueChanged(sender As Object, e As EventArgs) Handles TextFilePath.EditValueChanged

    End Sub
    Private Function GetArchiveApproachFromSettings() As String
        Dim _Approach As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_SaveDataInSqlOrFolder'")
            _Approach = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            _Approach = "Sql"
        End Try
        Return _Approach
    End Function
End Class