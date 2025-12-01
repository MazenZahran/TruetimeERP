Imports DevExpress.XtraEditors

Public Class Lists2
    Private Sub EmployeesBranchesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        SavingData()
    End Sub

    Private Sub Lists2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesTypes' table. You can move, or remove it, as needed.
        Me.EmployeesTypesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesItems' table. You can move, or remove it, as needed.
        Me.EmployeesItemsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesItems)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.Locations' table. You can move, or remove it, as needed.
        Me.LocationsTableAdapter.Fill(Me.TrueTimeDataSet.Locations)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.ArchiveDocsSorts1' table. You can move, or remove it, as needed.
        Me.ArchiveDocsSorts1TableAdapter.Fill(Me.TrueTimeDataSet.ArchiveDocsSorts1)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttAdditionsTypes' table. You can move, or remove it, as needed.
        Me.AttAdditionsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttAdditionsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttPaymentsTypes' table. You can move, or remove it, as needed.
        Me.AttPaymentsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttPaymentsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.AttPaymentsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttPaymentsTypes)
        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SavingData()
        End If
    End Sub

    Private Sub SavingData()

        Try
            Me.Validate()
            Me.EmployeesBranchesBindingSource.EndEdit()
            Me.EmployeesDepartmentsBindingSource.EndEdit()
            Me.EmployeesPositionsBindingSource.EndEdit()
            Me.VocationsTypesBindingSource.EndEdit()
            Me.AttPaymentsTypesBindingSource.EndEdit()
            Me.AttAdditionsTypesBindingSource.EndEdit()
            Me.EmployeesItemsBindingSource.EndEdit()
            Me.LocationsBindingSource.EndEdit()
            Me.EmployeesTypesBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)


            'Dim i As Integer
            'Dim j As Integer = 0
            'For i = 0 To GridView4.RowCount - 1
            '    If GridView4.GetRowCellValue(i, "Vocation").ToString() = "سنوية" Then
            '        j = j + 1
            '    End If
            'Next

            'If j = 0 Then
            '    Dim sql As New SQLControl
            '    Dim SqlString As String = "Insert Into VocationsTypes (Vocation) Values ('سنوية')"
            '    sql.SqlTrueTimeRunQuery(SqlString)

            'End If
            Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
            Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
            Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
            Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
            Me.AttPaymentsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttPaymentsTypes)
            Me.AttAdditionsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttAdditionsTypes)
            Me.EmployeesItemsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesItems)
            Me.LocationsTableAdapter.Fill(Me.TrueTimeDataSet.Locations)
            Me.EmployeesTypesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesTypes)

            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم حفظ البيانات")
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                XtraMessageBox.Show("Data Saved")
            End If



        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub DataNavigator1_ButtonClick(sender As Object, e As NavigatorButtonClickEventArgs)
        Select Case e.Button.ButtonType
            Case NavigatorButtonType.EndEdit
                Me.Validate()
                Me.EmployeesDepartmentsBindingSource.EndEdit()
                Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
        End Select
    End Sub

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs)
        SavingData()
    End Sub


    Private Sub ToolStripButton16_Click(ByVal sender As Object, ByVal e As EventArgs)

        'If (DirectCast(VocationsTypesBindingSource.Current, DataRowView).Item("Vocation").ToString) = "سنوية" Then
        '    MsgBox("لا يمكن حذف بند اساسي  ")
        'Else
        '    VocationsTypesBindingSource.RemoveCurrent()
        'End If
        '  If MessageBox.Show("Sure you wanna delete?", "Warning", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then VocationsTypesBindingSource.RemoveCurrent()
    End Sub
    Private Sub RepositoryDeleteArchiveSort_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeleteArchiveSort.ButtonClick
        Try
            ArchiveDocsSorts1BindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub RepositoryDeleteAdditionsType_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeleteAdditionsType.ButtonClick
        Try
            AttAdditionsTypesBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub
    Private Sub RepositoryDeletePaymentType_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeletePaymentType.ButtonClick
        Try
            AttPaymentsTypesBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub RepositoryDeleteVocation_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeleteVocation.ButtonClick
        Try
            VocationsTypesBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub RepositoryDeleteDepartment_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeleteDepartment.ButtonClick
        Try
            EmployeesDepartmentsBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub
    Private Sub RepositoryDeleteBranch_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeleteBranch.ButtonClick
        Try
            EmployeesBranchesBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub
    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            EmployeesItemsBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        Try
            LocationsBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub

    Private Sub RepositoryDeletePosition_ButtonClick_1(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryDeletePosition.ButtonClick
        Try
            EmployeesPositionsBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try

    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingData()
    End Sub
    Private Sub SimpleButton10_Click(sender As Object, e As EventArgs) Handles SimpleButton10.Click
        SavingData()
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        SavingData()
    End Sub

    Private Sub SimpleButton3_Click_2(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SavingData()
    End Sub

    Private Sub SimpleButton7_Click_1(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        SavingData()
    End Sub

    Private Sub SimpleButton5_Click_2(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        SavingData()
    End Sub

    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        SavingData()
    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SavingData()
    End Sub

    Private Sub SimpleButton8_Click_1(sender As Object, e As EventArgs) Handles SimpleButton8.Click
        SavingData()
    End Sub

    Private Sub EmployeesDepartmentsGridControl_Click(sender As Object, e As EventArgs) Handles EmployeesDepartmentsGridControl.Click

    End Sub

    Private Sub VocationsTypesGridControl_Click(sender As Object, e As EventArgs) Handles VocationsTypesGridControl.Click

    End Sub

    Private Sub AttPaymentsTypesGridControl_Click(sender As Object, e As EventArgs) Handles AttPaymentsTypesGridControl.Click

    End Sub

    Private Sub SimpleButton9_Click(sender As Object, e As EventArgs) Handles SimpleButton9.Click
        SavingData()
    End Sub

    Private Sub RepositoryItemButtonEdit3_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit3.ButtonClick
        Try
            EmployeesTypesBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub
End Class