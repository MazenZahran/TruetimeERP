Imports DevExpress.XtraEditors

Public Class VocationForGroup
    Dim OpenForm As Boolean = False
    Private Sub VocationForGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.Locations' table. You can move, or remove it, as needed.
        Me.LocationsTableAdapter.Fill(Me.TrueTimeDataSet.Locations)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.Vocations' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesPositions' table. You can move, or remove it, as needed.
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)

        LookUpEditVocations.EditValue = 1
        TextVocationDate.DateTime = Today
        DateEditTo.DateTime = Today
        DateEditFrom.DateTime = Today

        TextDayNo.EditValue = 1
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        RefreshEmployee()
        GetMaxBatch()
    End Sub

    Private Sub RefreshEmployee()
        Try
            Dim SQLString As String = " Select  EmployeeID,EmployeeName,[Department],
                                    [JobName],[Branch],[Active], 'True' as chk
                                    from EmployeesData 
                                    where EmployeeID is not null  "

            If Me.LookUpEditDepartment.Text <> String.Empty Then SQLString = SQLString + " and [Department] = N'" & LookUpEditDepartment.Text & "'"
            If Me.LookUpEditBranch.Text <> String.Empty Then SQLString = SQLString + " and [Branch] = N'" & LookUpEditBranch.Text & "'"
            If Me.LookUpEditPosition.Text <> String.Empty Then SQLString = SQLString + " and [JobName] = N'" & LookUpEditPosition.Text & "'"
            If Me.LookUpEditLocations.Text <> String.Empty Then SQLString = SQLString + " and [Location] = N'" & LookUpEditLocations.EditValue & "'"
            If CStr(ActiveCheckEdit1.EditValue) <> "TF" Then SQLString = SQLString + " and [Active] = " & ActiveCheckEdit1.CheckState & String.Empty
            SQLString = SQLString + " Order By ID"
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(SQLString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Saving()
    End Sub
    Private Sub Saving()
        Dim i As Integer
        Dim BatchNo As Integer = GetMaxBatch() + 1
        Dim RowCount As Integer = GridView1.RowCount
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If RowCount = 0 Then XtraMessageBox.Show(" لا يوجد بيانات  ") : Exit Sub
            If ChkRowsCount() = 0 Then XtraMessageBox.Show("لم يتم تحديد اي موظف") : Exit Sub

            Dim Msg As DialogResult = XtraMessageBox.Show(" سيتم عمل اجازة للموظفين عدد   " & ChkRowsCount(), "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Msg = vbNo Then Exit Sub
        Else
            If RowCount = 0 Then XtraMessageBox.Show(" No Data Found  ") : Exit Sub
            If ChkRowsCount() = 0 Then XtraMessageBox.Show(" There is no Employees Selected ") : Exit Sub

            Dim Msg As DialogResult = XtraMessageBox.Show(" Employees Count    " & ChkRowsCount(), "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Msg = vbNo Then Exit Sub
        End If




        Dim Chk As Boolean
        Dim EmpId As Integer
        For i = 0 To GridView1.RowCount - 1
            Chk = CBool(Me.GridView1.GetRowCellValue(i, "chk"))
            EmpId = CInt(Me.GridView1.GetRowCellValue(i, "EmployeeID"))
            If Chk = True Then
                PostingVocations(EmpId, BatchNo)
            End If

        Next
        If GlobalVariables._SystemLanguage = "Arabic" Then
            MsgBox("تم تنفيذ الاجازة")
        Else
            MsgBox("Done")
        End If

    End Sub

    Private Sub PostingVocations(EmployeeID As Integer, BatchNo As Integer)

        Dim DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Try
            Dim sql As New SQLControl
            Dim VocDate As String = Format(TextVocationDate.DateTime, "yyyy-MM-dd")
            Dim SqlString As String = "   Insert Into Vocations " _
                                      & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,BatchNo,VocationSource)" _
                                      & " Values ( " _
                                      & String.Empty & EmployeeID & "," _
                                      & "'" & VocDate & "'," _
                                      & "N'" & LookUpEditVocations.EditValue & "'," _
                                      & "'" & DateFrom & "'," _
                                      & "'" & DateTo & "'," _
                                      & String.Empty & TextDayNo.Text & "," _
                                      & "N'" & MemoDetails.Text & "'," _
                                      & "'" & BatchNo & "'," _
                                      & "'vocation'" _
                                      & " ) "

            sql.SqlTrueTimeRunQuery(SqlString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            '  Finally
            '  XtraMessageBox.Show("تم حفظ السند", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


    Private Function ChkRowsCount() As Integer

        Dim i As Integer
        Dim j As Integer
        Dim Chk As Boolean

        For i = 0 To GridView1.RowCount - 1
            Chk = CBool(Me.GridView1.GetRowCellValue(i, "chk"))
            If Chk = True Then j = j + 1
        Next

        Return j
    End Function

    Private Sub DateEditFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditFrom.Leave
        If DateEditFrom.IsHandleCreated Then TextDayNo.Text = GetDaysNo()
    End Sub
    Private Function GetDaysNo() As Integer


        Try
            If DateEditFrom.IsHandleCreated AndAlso DateEditTo.IsHandleCreated Then
                If DateEditFrom.ToString = String.Empty Or DateEditTo.ToString = String.Empty Then
                    Return 0
                End If

                Dim VocationsDay As Integer = DateDiff(DateInterval.Day, DateEditFrom.DateTime, DateEditTo.DateTime).ToString()

                VocationsDay = VocationsDay + 1

                If VocationsDay <= 0 Then
                    If GlobalVariables._SystemLanguage = "Arabic" Then
                        XtraMessageBox.Show("التاريخ الثاني اقل من التاريخ الأول", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        XtraMessageBox.Show("Second Date Less Than The First date", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    DateEditTo.DateTime = DateEditFrom.DateTime
                    Return 0

                ElseIf VocationsDay >= 364 Then
                    If GlobalVariables._SystemLanguage = "Arabic" Then
                        MsgBox("عدد الايام اكبر من سنة")
                    Else
                        MsgBox("Days Count Greate Than 365")
                    End If

                    Return 0

                ElseIf VocationsDay < 364 Then
                    Return VocationsDay
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try


    End Function

    Private Sub DateEditTo_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditTo.Leave
        If DateEditTo.IsHandleCreated Then TextDayNo.Text = GetDaysNo()
    End Sub


    Private Function GetMaxBatch() As Integer

        Try
            Dim sql As New SQLControl
            Dim SqlString As String = "Select Max(BatchNo) as BatchNo from Vocations"
            sql.SqlTrueTimeRunQuery(SqlString)

            If sql.SQLDS.Tables(0).Rows(0).Item("BatchNo") Is DBNull.Value Then
                Return 0
            Else
                Return sql.SQLDS.Tables(0).Rows(0).Item("BatchNo").ToString
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            Return 0
        End Try

    End Function

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        '   Colchk.SummaryItem.SummaryValue = ChkRowsCount()
    End Sub
    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If GridView1.GetRowCellValue(e.RowHandle, "chk") = "دوام" Then
                e.TotalValue = e.TotalValue + 1
            End If
        End If

    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select "
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButtonRefresh_Click(sender As Object, e As EventArgs) Handles SimpleButtonRefresh.Click
        RefreshEmployee()
        GetMaxBatch()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub ActiveCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles ActiveCheckEdit1.CheckedChanged

    End Sub
End Class