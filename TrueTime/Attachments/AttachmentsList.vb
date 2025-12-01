

Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO

Public Class AttachmentsList
    Dim EnableEvents As Boolean = False



    Private Sub AttachmentsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.ArchiveDocsSorts1' table. You can move, or remove it, as needed.
        Me.ArchiveDocsSorts1TableAdapter.Fill(Me.TrueTimeDataSet.ArchiveDocsSorts1)
        LoadingAttachmentsWithParameters()
        LoadingAccountsdata()
        EnableEvents = True
        DockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        LoadingSorts1()
    End Sub


    Private Sub LoadingAttachmentsWithParameters()
        ' hgfjhgjdfhgjkdfhgkdf 
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [DocID],[DocName],[DocAccountCode],[DocInputUser],[DocSort1],[DocSort2],
                                                [DocCostCenter],[DocDetails],[DocLocation],[DocType],[DocStatus],[DocInputDate],
                                                [DocExpireDate],[DocCreatedDate],[DocNo],[DocCode],[TextDateModified],[EmployeeName] 
                                        FROM [ArchiveDocs]
                                             left join EmployeesData on ArchiveDocs.DocAccountCode = EmployeesData.EmployeeID 
                                        where DocID > 0  "
            If Not String.IsNullOrWhiteSpace(DocAccountCode.Text) Then SqlString = SqlString + " and DocAccountCode = '" & DocAccountCode.EditValue & "'"
            If Not String.IsNullOrWhiteSpace(DocSort1.Text) Then SqlString = SqlString + " and DocSort1 = '" & DocSort1.Text & "'"
            If Not String.IsNullOrWhiteSpace(DocName.Text) Then SqlString = SqlString + " and DocName like '%" & DocName.Text & "%'"
            If Not String.IsNullOrWhiteSpace(DocDetails.Text) Then SqlString = SqlString + " and DocDetails like '%" & DocDetails.Text & "%'"

            SQl.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = SQl.SQLDS.Tables(0)
            GridView1.BestFitColumns()
            DockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadingAttachmentsWithParameters()
    End Sub



    Private Sub groupControl1_CustomButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs)
        MessageBox.Show("Button caption: " & e.Button.Properties.Caption)
    End Sub
    Private Sub LoadingAccountsdata()
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " Select EmployeeID as AccID ,EmployeeName As AccName from EmployeesData  "
            SQl.SqlTrueTimeRunQuery(SqlString)
            DocAccountCode.Properties.DataSource = SQl.SQLDS.Tables(0)
            DocAccountCodeEdit.Properties.DataSource = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub EditDocAccountCode_QueryPopUp(sender As Object, e As CancelEventArgs)
        LoadingAccountsdata()
    End Sub

    Private Sub DocAccountCode_QueryPopUp(sender As Object, e As CancelEventArgs) Handles DocAccountCode.QueryPopUp
        LoadingAccountsdata()
    End Sub

    Private Sub DocSort1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles DocSort1.QueryPopUp
        LoadingSorts1()
    End Sub

    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs)
        Me.ArchiveDocsSorts1TableAdapter.Fill(Me.TrueTimeDataSet.ArchiveDocsSorts1)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim File As String = CType(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"), String)
        LoadPdfFile(File)
        '   AttachmentDispaly.Show()
        Dim mydialogbox As New AttachmentDispaly
        AttachmentDispaly.ShowDialog()
    End Sub
    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            If EnableEvents = True Then

                Dim _DocID As String = CType(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DocID"), String)
                LoadDataToEdit(_DocID)
                DockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
            End If
            '  Me.PdfViewer1.LoadDocument(File)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadDataToEdit(DocID As String)
        Cleardata()

        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " Select   [DocID]  ,[DocName] ,[DocAccountCode] as AccID  ,[DocInputDate],[DocInputUser],
                                                 [DocSort1] as  ArchiveDocsSorts1  ,[DocCostCenter],[DocDetails] ,[DocLocation],EmployeeName,
                                                 [DocType],[TextDateModified],DocCode,DocNo,DocExpireDate
                                        FROM [ArchiveDocs] 
                                        Left join [EmployeesData] on ArchiveDocs.DocAccountCode= [EmployeesData].EmployeeID where DocID = '" & DocID & "'"
            SQl.SqlTrueTimeRunQuery(SqlString)
            DocIDEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocID")
            DocNameEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocName")
            DocAccountCodeEdit.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("AccID")
            DocInputDateEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocInputDate")
            DocInputUserEdit.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("DocInputUser")
            DocSort1Edit.EditValue = SQl.SQLDS.Tables(0).Rows(0).Item("ArchiveDocsSorts1")
            DocDetailsEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocDetails")
            DocTypeEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocType")
            TextDateModifiedEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("TextDateModified")
            DocCodeEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocCode")
            DocNoEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocNo")
            DocExpireDateEdit.Text = SQl.SQLDS.Tables(0).Rows(0).Item("DocExpireDate")
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try



    End Sub
    Private Sub Cleardata()
        DocIDEdit.Text = Nothing
        DocNameEdit.Text = Nothing
        DocAccountCodeEdit.Text = Nothing
        DocInputDateEdit.Text = Nothing
        DocInputUserEdit.Text = Nothing
        DocSort1Edit.Text = Nothing
        DocDetailsEdit.Text = Nothing
        DocTypeEdit.Text = Nothing
        DocExpireDateEdit.Text = Nothing
        DocCodeEdit.Text = Nothing
        DocNoEdit.Text = Nothing

    End Sub

    Private Sub LoadingSorts1()
        Try
            Dim SQl As New SQLControl
            Dim SqlString As String = " SELECT  [ArchiveDocsSorts1]  FROM [ArchiveDocsSorts1]  "
            SQl.SqlTrueTimeRunQuery(SqlString)
            DocSort1.Properties.DataSource = SQl.SQLDS.Tables(0)
            DocSort1Edit.Properties.DataSource = SQl.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DocSort1_EditValueChanged(sender As Object, e As EventArgs) Handles DocSort1.EditValueChanged

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click


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
                                         ,[DocSort1] = '" & DocSort1Edit.Text & "' 
                                         ,[DocDetails] = N'" & DocDetailsEdit.Text & "' 
                                         ,[DocExpireDate] = '" & Format(DocExpireDateEdit.DateTime, "yyyy-MM-dd HH:mm") & "' 
                                        ,[DocNo] ='" & DocNoEdit.Text & "'  
                                        ,[DocCode] = '" & DocCodeEdit.Text & "'  
                                        ,[DocAccountCode] = '" & DocAccountCodeEdit.EditValue & "'  
                                   WHERE DocID = " & DocIDEdit.Text
            Sql.SqlTrueTimeRunQuery(SqlString)
            LoadingAttachmentsWithParameters()
            If String.IsNullOrWhiteSpace(DocSort1Edit.Text) Then
                XtraMessageBox.Show("تم تعديل بيانات الوثيقة", "تم")
            Else
                XtraMessageBox.Show("Document Data Saved", "Done")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub TextDateModified_EditValueChanged(sender As Object, e As EventArgs) Handles TextDateModifiedEdit.EditValueChanged

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click

        Try
            If GlobalVariables._SystemLanguage = "Arabic" Then
                Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد حذف الوثيقة" & " : " & DocNameEdit.Text, "تأكيد", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            Else
                Dim Msg As DialogResult = XtraMessageBox.Show("Do you want delete document?" & " : " & DocNameEdit.Text, "Are you sure?", MessageBoxButtons.YesNo)
                If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            End If


            Dim Sql As New SQLControl
            Dim SqlString As String = " Delete from   [ArchiveDocs]
                                   WHERE DocID = " & DocIDEdit.Text
            Sql.SqlTrueTimeRunQuery(SqlString)
            LoadingAttachmentsWithParameters()
            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم حذف الوثيقة", "تم")
            Else
                XtraMessageBox.Show(" Document Deleted ", "Done")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Dim _DocType As String = ""
        Dim con As String = My.Settings.TrueTimeConnectionString
        Dim connection As SqlConnection = New SqlConnection(con)
        connection.Open()
        Dim sql As String = "select [DocFile],DocType from [ArchiveDocs] where [DocID]=" & "'" & 3 & "'"
        Dim cmd As SqlCommand = New SqlCommand(sql, connection)
        Dim dr As SqlDataReader = cmd.ExecuteReader()
        Dim data As Byte() = Nothing

        While dr.Read()
            data = CType(dr(0), Byte())
            _DocType = dr(1)
        End While

        Using fs = New FileStream(Path.Combine("D:\", 3 & _DocType), FileMode.Create, FileAccess.Write)
            fs.Write(data, 0, data.Length)
        End Using

        MessageBox.Show("success")
    End Sub
End Class