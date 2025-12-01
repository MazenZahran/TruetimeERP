Imports System.ComponentModel
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraWizard

Public Class EmployeeOut
    Private finish As Boolean = False
    Private Sub WizardControl1_Click(sender As Object, e As EventArgs) Handles WizardControl1.Click

    End Sub

    Private Sub EmployeesOhdahGridControl_Click(sender As Object, e As EventArgs) Handles EmployeesOhdahGridControl.Click

    End Sub

    Private Sub EmployeeOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesItems' table. You can move, or remove it, as needed.
        Me.EmployeesItemsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesItems)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesOhdah' table. You can move, or remove it, as needed.
        Me.EmployeesOhdahTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesOhdah)
        Me.DateOfEnd.EditValue = Format(Today, "dd/MM/yyyy")
        LastSalarty.EditValue = 3500
    End Sub
    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        If finish Then Return
        If XtraMessageBox.Show(Me, "Do you want to exit the XtraWizard feature tour?", "XtraWizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then e.Cancel = True
    End Sub
    Private Sub wizardControl1_SelectedPageChanging(ByVal sender As Object, ByVal e As WizardPageChangingEventArgs)




        'If e.Page Is wpLongText Then
        '    e.Page.AllowNext = ceLongText.Checked
        '    CreateLongTextTimer()
        'End If

        'If e.PrevPage Is wpQuestion AndAlso e.Direction = Direction.Forward Then
        '    If ceYesAnswer.Checked Then e.Page = wpProgress
        'End If

        'If e.PrevPage Is wpProgress AndAlso e.Direction = Direction.Backward Then e.Page = wpQuestion
        'If e.Page Is wpProgress Then CreateProgressTimer()
        'If e.PrevPage Is wpProgress Then
        '    RemoveHandler progressTimer.Tick, New EventHandler(AddressOf progressTimer_Tick)
        '    progressTimer.Dispose()
        '    progressTimer = Nothing
        '    progressBarControl1.Position = 0
        '    lbProgress.Visible = False
        'End If

        'If e.Page Is CompletionWizardPage1 Then
        '    If Equals(teRobotTest.Text.ToLower(), "devexpress123") Then
        '        CompletionWizardPage1.Text = "Congratulations – You've Passed All the Way Through!"
        '        CompletionWizardPage1.FinishText = If(lbcPlay.SelectedIndex > -1, String.Format("Thank you for completing this XtraWizard feature tour! We can now conclusively state that you are very patient, definitely not a robot, a quick reader, and a fan of {0} just like we are.", GetArtistName(lbcPlay.SelectedValue)), "Thank you for completing this XtraWizard feature tour! We can now conclusively state that you are very patient, a quick reader and definitely not a robot.")
        '    Else
        '        CompletionWizardPage1.Text = "Sorry, No Robots Allowed"
        '        CompletionWizardPage1.FinishText = "We are very sorry, but no robots are allowed to continue this wizard. Please click Finish to exit."
        '    End If
        'End If

    End Sub
    Private Sub wizardControl1_FinishClick(ByVal sender As Object, ByVal e As CancelEventArgs) Handles WizardControl1.FinishClick
        finish = True
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery("Update [dbo].[EmployeesData] Set [Active]=0 Where [EmployeeID]=" & EmployeeIDTextEdit.Text)
        Close()
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles EmployeeIDTextEdit.EditValueChanged
        GetEmployeeDetails()
    End Sub
    Private Sub GetEmployeeDetails()
        Try
            Dim SqlString As String
            Dim Sql As New SQLControl
            SqlString = " Select EmployeeName,JobName,Department,Branch,DateOfStart,PictureEmp from
                                 [dbo].[EmployeesData] where [EmployeeID]= '" & EmployeeIDTextEdit.Text & "'"
            Sql.SqlTrueTimeRunQuery(SqlString)
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName")) Then
                EmployeeName.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("EmployeeName")
            End If

            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("JobName")) Then
                JobName.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("JobName")
            End If

            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Department")) Then
                Department.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Department")
            End If

            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Branch")) Then
                Branch.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Branch")
            End If


            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart")) Then
                DateOfStart.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart")
                'LabelControl8.Text = " مضى على بداية العمل :  " & " " & CalcAge(Sql.SQLDS.Tables(0).Rows(0).Item("DateOfStart"))
            End If


            Me.PictureEmpPictureEdit.Image = Nothing
            If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("PictureEmp")) Then
                Dim photo_aray As Byte()
                photo_aray = CType(Sql.SQLDS.Tables(0).Rows(0).Item("PictureEmp"), Byte())
                Dim ms As MemoryStream = New MemoryStream(photo_aray)
                PictureEmpPictureEdit.Image = Image.FromStream(ms)
            End If


        Catch ex As Exception

        End Try

        Try
            If EmployeeIDTextEdit.Text <> "" Then
                Me.EmployeesOhdahTableAdapter.FillByEmpNo(Me.TrueTimeDataSet.EmployeesOhdah, EmployeeIDTextEdit.Text)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DateOfStart_EditValueChanged(sender As Object, e As EventArgs) Handles DateOfStart.EditValueChanged

    End Sub
End Class