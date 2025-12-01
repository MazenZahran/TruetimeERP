Imports DevExpress.XtraEditors

Public Class AttachmentEdit

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If String.IsNullOrWhiteSpace(DocNameEdit.Text) Then
            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("يجب تعبئة اسم الوثيقة", "خطـأ")
            Else
                XtraMessageBox.Show("Document name empty", "Error")
            End If
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(DocSort1Edit.Text) Then
            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("يجب تعبئة تصنيف الوثيقة", "خطـأ")
            Else
                XtraMessageBox.Show("Empty Type Document", "Error")
            End If
            Exit Sub
        End If

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String = " UPDATE [ArchiveDocs]
                                        SET   [DocName] = N'" & DocNameEdit.Text & "' 
                                             ,[DocSort1] = '" & DocSort1Edit.EditValue & "' 
                                             ,[DocDetails] = N'" & DocDetailsEdit.Text & "' 
                                             ,[DocNo] ='" & DocNoEdit.Text & "'  
                                             ,[DocCode] = '" & DocCodeEdit.Text & "'  
                                             ,[DocAccountCode] = '" & DocAccountCodeEdit.EditValue & "'  
                                             ,[ReferanceNo] = '" & SearchLookReferance.EditValue & "'  
                                        WHERE DocID = " & DocIDEdit.Text
            If Sql.SqlTrueTimeRunQuery(SqlString) = True Then
                XtraMessageBox.Show("تم حفظ التعديلات", "Done")
            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AttachmentEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.ReferancesList' table. You can move, or remove it, as needed.
        Me.ReferancesListTableAdapter.Fill(Me.AccountingDataSet.ReferancesList)
        Me.DocAccountCodeEdit.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
        LoadingSorts1()
        Me.SearchLookReferance.Properties.DataSource = GetReferences(-1, -1, -1)
    End Sub
    Private Sub LoadingSorts1()
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [ID],[ArchiveDocsSorts1]  FROM [ArchiveDocsSorts1]  "
            SQl.SqlTrueTimeRunQuery(SqlString)
            DocSort1Edit.Properties.DataSource = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DocAccountCodeEdit_Properties_BeforePopup(sender As Object, e As EventArgs) Handles DocAccountCodeEdit.Properties.BeforePopup
        Me.DocAccountCodeEdit.Properties.DataSource = GetFinancialAccounts(-1, -1, True, -1, -1)
    End Sub

    Private Sub SearchLookUpEdit1_Properties_BeforePopup(sender As Object, e As EventArgs) Handles SearchLookReferance.Properties.BeforePopup
        Me.ReferancesListTableAdapter.Fill(Me.AccountingDataSet.ReferancesList)
    End Sub

    Private Sub DocIDEdit_EditValueChanged(sender As Object, e As EventArgs) Handles DocIDEdit.EditValueChanged
        LoadDataToEdit()
    End Sub
    Private Sub LoadDataToEdit()
        If String.IsNullOrEmpty(DocIDEdit.Text) Then Exit Sub

        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " Select   [DocID]  ,[DocName] ,[DocAccountCode] as AccID  ,[DocInputDate],[DocInputUser],
                                                 [DocSort1] as  ArchiveDocsSorts1  ,[DocCostCenter],[DocDetails] ,[DocLocation],
                                                 [DocType],[TextDateModified],DocCode,DocNo,DocExpireDate,ReferanceNo
                                        FROM [ArchiveDocs] 
                                        where DocID = '" & DocIDEdit.EditValue & "'"
            SQl.SqlTrueTimeRunQuery(SqlString)
            With SQl.SQLDS.Tables(0).Rows(0)
                If Not IsDBNull(.Item("DocName")) Then DocNameEdit.Text = .Item("DocName")
                If Not IsDBNull(.Item("AccID")) Then DocAccountCodeEdit.EditValue = .Item("AccID")
                'DocInputDateEdit.Text = .Item("DocInputDate")
                'DocInputUserEdit.EditValue = .Item("DocInputUser")
                If Not IsDBNull(.Item("ArchiveDocsSorts1")) Then DocSort1Edit.EditValue = .Item("ArchiveDocsSorts1")
                If Not IsDBNull(.Item("DocDetails")) Then DocDetailsEdit.Text = .Item("DocDetails")
                'DocTypeEdit.Text = .Item("DocType")
                'TextDateModifiedEdit.Text = .Item("TextDateModified")
                If Not IsDBNull(.Item("DocCode")) Then DocCodeEdit.Text = .Item("DocCode")
                If Not IsDBNull(.Item("DocNo")) Then DocNoEdit.Text = .Item("DocNo")
                If Not IsDBNull(.Item("DocExpireDate")) Then DocExpireDateEdit.Text = .Item("DocExpireDate")
                If Not IsDBNull(.Item("ReferanceNo")) Then SearchLookReferance.EditValue = .Item("ReferanceNo")
                If Not IsDBNull(.Item("AccID")) Then Me.DocAccountCodeEdit.EditValue = .Item("AccID")
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DocSort1Edit_Properties_BeforePopup(sender As Object, e As EventArgs) Handles DocSort1Edit.Properties.BeforePopup
        LoadingSorts1()
    End Sub
End Class