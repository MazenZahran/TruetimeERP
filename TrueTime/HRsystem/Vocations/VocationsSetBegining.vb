Imports DevExpress.XtraEditors

Public Class VocationsSetBegining
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Refreshing()

    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Refreshing()
        End If
    End Sub
    Private Sub Refreshing()
        Try
            If String.IsNullOrEmpty(SearchVocationType.Text) Then Exit Sub
            Dim VocID As Integer
            VocID = SearchVocationType.EditValue
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select ss.EmployeeID,EmployeeName, ISNULL( DateOfStart,'1900-01-01') As DateOfStart ,'True' as AddBalance,
                          Case when   DateOfStart<>'1900-01-01' then 
                               CONVERT(DECIMAL(15,2), DATEDIFF(month, DateOfStart, '" & Format(DateEdit1.DateTime, "yyyy-MM-dd") & "' ))/12 else 0  end AS DateDiff,
                               CASE WHEN DefaultBalanceForEmployee IS NULL THEN CONVERT(DECIMAL(15,2),VocationDefaultBalance) ELSE CONVERT(DECIMAL(15,2),DefaultBalanceForEmployee) END as VocationsLimit
                          FROM
                            (  
                                 (Select E.EmployeeID ,E.EmployeeName ,E.DateOfStart   From EmployeesData  E where [Active] =1 "
            If Me.LookUpEditDepartment.Text <> String.Empty Then SqlString = SqlString + " and [Department] = N'" & LookUpEditDepartment.Text & "'"
            If Me.LookUpEditBranch.Text <> String.Empty Then SqlString = SqlString + " and [Branch] = N'" & LookUpEditBranch.Text & "'"
            If Me.LookUpEditPosition.Text <> String.Empty Then SqlString = SqlString + " and [JobName] = N'" & LookUpEditPosition.Text & "'"
            SqlString = SqlString + "  ) SS
                             Left Join
                                 (Select C.DefaultBalanceForEmployee as DefaultBalanceForEmployee ,C.VocID As VVocID ,C.EmployeeID   From [VocationsDefaultBalances] C where C.VocID=" & VocID & "   ) DSA		       
                             On SS.EmployeeID = DSA.EmployeeID                                
                             )
                             ,   (Select [VocationDefaultBalance] as VocationDefaultBalance  ,VocID AS VOD  FROM [VocationsTypes] where VocID=" & VocID & ")  QQ "
            sql.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub


    Private Function SQLStringFunction(DateFrom As String, DateTo As String, VocID As Integer) As String
        Dim _SQLString As String

        _SQLString = "   SELECT EmpID,EmployeeName,DateOfStart,ISNULL(AllAddningBalances,0)-ISNULL (AllVocations,0) as balance,VocationType,
                               ISNULL( THISYEARVOCATIONS,0) as THISYEARVOCATIONS , ISNULL( ThisYearSetBalance ,0) as ThisYearSetBalance,
                               ISNULL (AllAddningBalances-AllVocations+THISYEARVOCATIONS-ThisYearSetBalance,0) as BeginingBalance
                               
                         
                                               FROM 

                        (  
  
			                        ( Select EmployeeID AS EmpID ,EmployeeName,DateOfStart From EmployeesData  where [Active] = 1 "
        If Me.LookUpEditDepartment.Text <> String.Empty Then _SQLString += " and [Department] = N'" & LookUpEditDepartment.Text & "'"
        If Me.LookUpEditBranch.Text <> String.Empty Then _SQLString += " and [Branch] = N'" & LookUpEditBranch.Text & "'"
        If Me.LookUpEditPosition.Text <> String.Empty Then _SQLString += " and [JobName] = N'" & LookUpEditPosition.Text & "'"
        _SQLString += "GROUP BY EmployeeID,EmployeeName,DateOfStart) SS
			
	                        Left Join
	        
			                        (  Select VocationType, EmployeeID AS Employe , ISNULL( AllAddningBalances,0) as AllAddningBalances From EmployeesData  left join (  Select   SUM(BalanceDays) AS AllAddningBalances , Employee, VocationType   From [VacationsBalancesAdding]   where VocationType = " & VocID & "    group by Employee,VocationType     ) aa    on aa.Employee = EmployeeID  ) DSA		       
	                        on SS.EmpID = DSA.Employe

	                        Left Join 
	 
			                        ( Select bb.EmployeeID AS Employee , ISNULL(AllVocations,0) as AllVocations From EmployeesData bb  left join ( Select  ISNULL( SUM(NoDays),0)  AS AllVocations,EmployeeID From [Vocations] where VocationType = " & VocID & " group by EmployeeID    ) aa    on aa.EmployeeID = bb.EmployeeID  ) DSS
	                        on SS.EmpID =DSS.Employee 

	                        Left Join 

			                        ( Select bb.EmployeeID AS EmployeeID , ISNULL(THISYEARVOCATIONS,0) as THISYEARVOCATIONS From EmployeesData bb  left join (Select  ISNULL( SUM(NoDays),0)  AS THISYEARVOCATIONS,EmployeeID From [Vocations]  where VocationType = " & VocID & " and FromDate BETWEEN '" & DateFrom & "' AND '" & DateTo & "' GROUP BY EmployeeID  ) aa    on aa.EmployeeID = bb.EmployeeID) BB
	                        ON SS.EmpID=BB.EmployeeID
	 
	                        Left Join 
	
	                                ( Select bb.EmployeeID AS Emp , ISNULL(ThisYearSetBalance,0) as ThisYearSetBalance From EmployeesData bb  left join ( SELECT ISNULL( SUM(BalanceDays),0)  AS ThisYearSetBalance , Employee From [VacationsBalancesAdding]  where  VocationType = " & VocID & " and [BalanceDate] between  '" & DateFrom & "' and '" & DateTo & "' group by Employee  ) aa    on aa.Employee = bb.EmployeeID  ) as RERE  
	                        ON SS.EmpID =RERE.Emp
  
                        ) "

        Return _SQLString
    End Function

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Saving()
    End Sub
    Private Function GetMaxBatch() As Integer
        Dim _GetMaxBatch As Integer = 0
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery("Select max(BatchNo) as BatchNo from VacationsBalancesAdding ")
            _GetMaxBatch = sql.SQLDS.Tables(0).Rows(0).Item("BatchNo")
            Return _GetMaxBatch
        Catch ex As Exception
            '  MsgBox(ex.ToString)
            Return 0
        End Try
        ' Return _GetMaxBatch
    End Function

    Private Sub Saving()

        Try
            Dim i As Integer
            Dim BatchNo As Integer = GetMaxBatch() + 1
            Dim RowCount As Integer = GridView1.RowCount

            If _SystemLanguage = "Arabic" Then
                If RowCount = 0 Then XtraMessageBox.Show(" لا يوجد بيانات  ") : Exit Sub
            Else
                If RowCount = 0 Then XtraMessageBox.Show(" No Data  ") : Exit Sub
            End If

            If _SystemLanguage = "Arabic" Then
                If ChkRowsCount() = 0 Then XtraMessageBox.Show("لم يتم تحديد اي موظف") : Exit Sub
            Else
                If ChkRowsCount() = 0 Then XtraMessageBox.Show("Empty Employee") : Exit Sub
            End If

            If _SystemLanguage = "Arabic" Then
                Dim Msg As DialogResult = XtraMessageBox.Show(" سيتم عمل ترصيد اجازات  للموظفين عدد   " & ChkRowsCount(), "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If Msg = vbNo Then Exit Sub
            Else

                Dim Msg As DialogResult = XtraMessageBox.Show(" Employees :    " & ChkRowsCount(), "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If Msg = vbNo Then Exit Sub
            End If




            Dim Chk As Boolean
            Dim EmpId As Integer
            Dim AddedDays As Decimal
            Dim VocationType As String
            For i = 0 To GridView1.RowCount - 1
                Try
                    If Not IsDBNull(Me.GridView1.GetRowCellValue(i, "VocationsLimit")) Then
                        If CDec(Me.GridView1.GetRowCellValue(i, "VocationsLimit")) <> 0 Then
                            Chk = CBool(Me.GridView1.GetRowCellValue(i, "AddBalance"))
                            EmpId = CInt(Me.GridView1.GetRowCellValue(i, "EmployeeID"))
                            AddedDays = CDec(Me.GridView1.GetRowCellValue(i, "VocationsLimit"))
                            VocationType = Me.SearchVocationType.EditValue

                            If Chk = True Then
                                PostingVocations(EmpId, BatchNo, AddedDays, VocationType)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Error" & CStr(Me.GridView1.GetRowCellValue(i, "EmployeeID")))
                End Try

            Next

            If _SystemLanguage = "Arabic" Then
                MsgBox("تم تنفيذ الترصيد")
            Else
                MsgBox("Done")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Function ChkRowsCount() As Integer

        Try
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim Chk As Boolean
            Dim VocationDays As Decimal

            For i = 0 To GridView1.RowCount - 1

                Chk = CBool(Me.GridView1.GetRowCellValue(i, "AddBalance"))


                Try
                    VocationDays = CDec(Me.GridView1.GetRowCellValue(i, "VocationsLimit"))
                Catch ex As Exception
                    VocationDays = 0
                End Try

                If Chk = True And VocationDays <> 0 Then j = j + 1

                'If Not String.IsNullOrEmpty(CStr(Me.GridView1.GetRowCellValue(i, "VocationsLimit"))) Then
                '    VocationDays = CDec(Me.GridView1.GetRowCellValue(i, "VocationsLimit"))
                'End If


            Next

            Return j
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0

        End Try


    End Function
    Private Sub PostingVocations(EmployeeID As Integer, BatchNo As Integer, AddedDays As Decimal, VocationType As Integer)

        Dim _Date As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")

        Try
            Dim sql As New SQLControl
            Dim SqlString As String = "   Insert Into VacationsBalancesAdding " _
                                      & " (BalanceDate,BalanceDays,Employee, BatchNo,VocationType)" _
                                      & " Values ( " _
                                      & "'" & _Date & "'," _
                                      & "'" & AddedDays & "'," _
                                      & "'" & EmployeeID & "'," _
                                      & "'" & BatchNo & "'," _
                                      & "'" & VocationType & "'" _
                                      & " ) "
            sql.SqlTrueTimeRunQuery(SqlString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            '  Finally
            '  XtraMessageBox.Show("تم حفظ السند", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub VocationsSetBegining_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesPositions' table. You can move, or remove it, as needed.
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)

        Me.SearchVocationType.EditValue = 1

        ColDateDiff.DisplayFormat.FormatString = "{0:0.0}"


        Dim TheDate As New DateTime(DateTime.Now.Year, 1, 1)
        DateEdit1.DateTime = TheDate
        Me.KeyPreview = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEmployees.CheckedChanged

        For i = 0 To GridView1.RowCount - 1
            If CheckEmployees.Checked = True Then
                GridView1.SetRowCellValue(i, GridView1.Columns("AddBalance"), "True")
            Else
                GridView1.SetRowCellValue(i, GridView1.Columns("AddBalance"), "False")
            End If
        Next
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        If Me.IsHandleCreated Then
            Refreshing()
        End If
    End Sub

    Private Sub نسخالىاسفلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles نسخالىاسفلToolStripMenuItem.Click

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _DefualtBalance As Decimal
        _DefualtBalance = GridView1.GetFocusedRowCellValue("VocationsLimit")
        For i = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "VocationsLimit", _DefualtBalance)
        Next
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(GridControl1.PointToScreen(e.Point))
        End If
    End Sub
End Class