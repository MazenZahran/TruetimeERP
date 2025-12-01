Imports DevExpress.XtraEditors

Public Class UsersAndAccess
    Sub New()

        'InitializeComponent()


    End Sub

    Private Sub UsersAndAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
        ' RepositoryUserAccessType.DataSource = CreateUserAccessTypeTable()
        ' If GlobalVariables._SystemLanguage = "Arabic" Then
        ''RepositoryUserAccessType.DisplayMember = "UserType"
        ' RepositoryUserAccessType.ValueMember = "TypeID"
        ' ColProccessTypeE.Visible = False
        'Else
        'RepositoryUserAccessType.DisplayMember = "UserTypeE"
        '   RepositoryUserAccessType.ValueMember = "TypeID"
        ' ColUserTypeE.Visible = True
        'Co'lUserType.Visible = False
        ' End If

        ' If GlobalVariables._SystemLanguage <> "Arabic" Then
        'NavigationPage1.Visible = False
        ' End If


    End Sub



    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Me.Validate()
            Me.EmployeesDataBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
            Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
        Catch ex As Exception
            XtraMessageBox.Show("Error")
        End Try
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        CreateDataTable()
    End Sub

    Private Sub CreateDataTable()

        Try

            If SearchLookUpEdit1.EditValue Is "0" Or TypeOf (SearchLookUpEdit1.EditValue) Is DBNull Then Exit Sub

            Dim FormsAccess As New DataTable
            Dim sql As New SQLControl
            Dim SQLString As String = " Select [ID],FormName,FormNameArabic,FormCategory from [AccessForms] "
            sql.SqlTrueTimeRunQuery(SQLString)
            FormsAccess = sql.SQLDS.Tables(0)


            With FormsAccess
                .Columns.Add("UserNo", GetType(Integer))

                .Columns.Add("QueryAccess", GetType(Boolean))
                .Columns.Add("AddAccess", GetType(Boolean))
                .Columns.Add("DeleteAccess", GetType(Boolean))
                .Columns.Add("EditAccess", GetType(Boolean))
                .Columns.Add("VisibleAccess", GetType(Boolean))

                .Columns.Add("QueryAccessValue", GetType(Integer))
                .Columns.Add("AddAccessValue", GetType(Integer))
                .Columns.Add("DeleteAccessValue", GetType(Integer))
                .Columns.Add("EditAccessValue", GetType(Integer))
                .Columns.Add("VisibleAccessValue", GetType(Integer))

            End With

            'For i = 0 To FormsAccess.Rows.Count - 1
            '    Dim sql2 As New SQLControl
            '    FormsAccess.Rows(i).Item("UserNo") = SearchLookUpEdit1.EditValue
            '    sql2.SqlTrueTimeRunQuery("select QueryAccess,AddAccess,DeleteAccess,EditAccess,VisibleAccess from [AccessUsers] where UserNo =" & SearchLookUpEdit1.EditValue & " and [FromID] = " & FormsAccess.Rows(i).Item("ID"))
            '    If sql2.SQLDS.Tables(0).Rows.Count > 0 Then FormsAccess.Rows(i).Item("QueryAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("QueryAccess") : FormsAccess.Rows(i).Item("QueryAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("QueryAccess")
            '    If sql2.SQLDS.Tables(0).Rows.Count > 0 Then FormsAccess.Rows(i).Item("AddAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("AddAccess") : FormsAccess.Rows(i).Item("AddAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("AddAccess")
            '    If sql2.SQLDS.Tables(0).Rows.Count > 0 Then FormsAccess.Rows(i).Item("DeleteAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("DeleteAccess") : FormsAccess.Rows(i).Item("DeleteAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("DeleteAccess")
            '    If sql2.SQLDS.Tables(0).Rows.Count > 0 Then FormsAccess.Rows(i).Item("EditAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("EditAccess") : FormsAccess.Rows(i).Item("EditAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("EditAccess")
            '    If sql2.SQLDS.Tables(0).Rows.Count > 0 Then FormsAccess.Rows(i).Item("VisibleAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("VisibleAccess") : FormsAccess.Rows(i).Item("VisibleAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("VisibleAccess")
            'Next

            For i = 0 To FormsAccess.Rows.Count - 1
                Dim sql2 As New SQLControl
                FormsAccess.Rows(i).Item("UserNo") = SearchLookUpEdit1.EditValue
                sql2.SqlTrueTimeRunQuery("select QueryAccess,AddAccess,DeleteAccess,EditAccess,VisibleAccess from [AccessUsers] where UserNo =" & SearchLookUpEdit1.EditValue & " and [FromID] = '" & FormsAccess.Rows(i).Item("FormName") & "'")
                If sql2.SQLDS.Tables(0).Rows.Count > 0 Then
                    FormsAccess.Rows(i).Item("QueryAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("QueryAccess")
                    FormsAccess.Rows(i).Item("QueryAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("QueryAccess")
                Else
                    FormsAccess.Rows(i).Item("QueryAccess") = False
                    FormsAccess.Rows(i).Item("QueryAccessValue") = -1
                End If
                If sql2.SQLDS.Tables(0).Rows.Count > 0 Then
                    FormsAccess.Rows(i).Item("AddAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("AddAccess")
                    FormsAccess.Rows(i).Item("AddAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("AddAccess")
                Else
                    FormsAccess.Rows(i).Item("AddAccess") = False
                    FormsAccess.Rows(i).Item("AddAccessValue") = -1
                End If
                If sql2.SQLDS.Tables(0).Rows.Count > 0 Then
                    FormsAccess.Rows(i).Item("DeleteAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("DeleteAccess")
                    FormsAccess.Rows(i).Item("DeleteAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("DeleteAccess")
                Else
                    FormsAccess.Rows(i).Item("DeleteAccess") = False
                    FormsAccess.Rows(i).Item("DeleteAccessValue") = -1
                End If
                If sql2.SQLDS.Tables(0).Rows.Count > 0 Then
                    FormsAccess.Rows(i).Item("EditAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("EditAccess")
                    FormsAccess.Rows(i).Item("EditAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("EditAccess")
                Else
                    FormsAccess.Rows(i).Item("EditAccess") = False
                    FormsAccess.Rows(i).Item("EditAccessValue") = -1
                End If
                If sql2.SQLDS.Tables(0).Rows.Count > 0 Then
                    FormsAccess.Rows(i).Item("VisibleAccess") = sql2.SQLDS.Tables(0).Rows(0).Item("VisibleAccess")
                    FormsAccess.Rows(i).Item("VisibleAccessValue") = sql2.SQLDS.Tables(0).Rows(0).Item("VisibleAccess")
                Else
                    FormsAccess.Rows(i).Item("VisibleAccess") = False
                    FormsAccess.Rows(i).Item("VisibleAccessValue") = -1
                End If

            Next
            GridControl1.DataSource = FormsAccess


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        CreateDataTable()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        SaveAccess()
    End Sub

    Private Sub SaveAccess()
        Try
            Dim UserNo As Integer = SearchLookUpEdit1.EditValue

            For i = 0 To GridView2.RowCount - 1

                Dim QueryAccessValue As Boolean = False
                Dim AddAccessValue As Boolean = False
                Dim DeleteAccessValue As Boolean = False
                Dim VisibleAccessValue As Boolean = False
                Dim EditAccessValue As Boolean = False

                Dim FormID As String = GridView2.GetRowCellValue(i, GridView2.Columns("FormName"))
                QueryAccessValue = CBool(GridView2.GetRowCellValue(i, GridView2.Columns("QueryAccess")))
                AddAccessValue = CBool(GridView2.GetRowCellValue(i, GridView2.Columns("AddAccess")))
                DeleteAccessValue = CBool(GridView2.GetRowCellValue(i, GridView2.Columns("DeleteAccess")))
                VisibleAccessValue = CBool(GridView2.GetRowCellValue(i, GridView2.Columns("VisibleAccess")))
                EditAccessValue = CBool(GridView2.GetRowCellValue(i, GridView2.Columns("EditAccess")))


                If GridView2.GetRowCellValue(i, GridView2.Columns("QueryAccessValue")) = -1 Then
                    InsertAccess(FormID, UserNo, QueryAccessValue, AddAccessValue, DeleteAccessValue, VisibleAccessValue, EditAccessValue)
                Else
                    UpdateAccess(FormID, UserNo, QueryAccessValue, AddAccessValue, DeleteAccessValue, VisibleAccessValue, EditAccessValue)
                End If

            Next

            CreateDataTable()

            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم حفظ الصلاحيات")
            Else
                XtraMessageBox.Show("Data saved")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub InsertAccess(FormID As String, UserID As Integer, QueryAccessValue As Boolean, AddAccessValue As Boolean, DeleteAccessValue As Boolean, VisibleAccessValue As Boolean, EditAccessValue As Boolean)
        Dim InsertString As String = "Insert into AccessUsers (UserNo,FromID,QueryAccess,AddAccess,EditAccess,DeleteAccess,VisibleAccess) Values  
                                            (" & UserID & ", '" & FormID & "','" & QueryAccessValue & "','" & AddAccessValue & "','" & DeleteAccessValue & "','" & VisibleAccessValue & "','" & EditAccessValue & "' )"

        Dim SQl As New SQLControl
        SQl.SqlTrueTimeRunQuery(InsertString)
    End Sub

    Private Sub UpdateAccess(FormID As String, UserID As Integer, QueryAccessValue As Boolean, AddAccessValue As Boolean, DeleteAccessValue As Boolean, VisibleAccessValue As Boolean, EditAccessValue As Boolean)
        Dim UpdateString As String = " Update  AccessUsers Set
                                              QueryAccess= '" & QueryAccessValue & "'
                                              ,AddAccess= '" & AddAccessValue & "'
                                              ,EditAccess= '" & EditAccessValue & "'
                                              ,DeleteAccess= '" & DeleteAccessValue & "'
                                              ,VisibleAccess= '" & VisibleAccessValue & "'
                                       Where UserNo=" & UserID & " And FromID='" & FormID & "'"
        Dim SQl As New SQLControl
        SQl.SqlTrueTimeRunQuery(UpdateString)
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try

            If GlobalVariables._SystemLanguage = "Arabic" Then
                If String.IsNullOrWhiteSpace(TextEditassword.Text) Then XtraMessageBox.Show("كلمة المرور فارغة") : Exit Sub
                If String.IsNullOrWhiteSpace(TextEditEmployeeId.Text) Then XtraMessageBox.Show("اسم المستخدم فارغ") : Exit Sub
            Else
                If String.IsNullOrWhiteSpace(TextEditassword.Text) Then XtraMessageBox.Show("Empty Password") : Exit Sub
                If String.IsNullOrWhiteSpace(TextEditEmployeeId.Text) Then XtraMessageBox.Show("User name is Empty") : Exit Sub
            End If


            Dim PassText As String = GetCode(TextEditassword.Text, TextEditassword.Text)
            Dim SqlString As String = "Update EmployeesData set UserPassword ='" & PassText & "' where EmployeeID =" & TextEditEmployeeId.Text
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SqlString)

            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم تعديل كلمة المرور", String.Empty)
            Else
                XtraMessageBox.Show("Password Changed", String.Empty)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        SaveAccess()
    End Sub

    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
        '    Me.Close()
        '    MsgBox("لا يوجد صلاحية")
        'End If
    End Sub

End Class