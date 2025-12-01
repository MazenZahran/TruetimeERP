Imports DevExpress.XtraPrinting

Public Class VocationBalances
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Refreshing()
    End Sub
    Private Sub Refreshing()
        Try
            Dim sql As New SQLControl
            Dim SqlString As String

            Dim _DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
            Dim _DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
            If GlobalVariables._SystemLanguage = "Arabic" Then
                If CDate(_DateTo) <= CDate(_DateFrom) Then MsgBox("يجب ان تكون فترة التقرير صحيحة") : Exit Sub
            Else
                If CDate(_DateTo) <= CDate(_DateFrom) Then MsgBox("Error In Period") : Exit Sub
            End If

            If GlobalVariables._SystemLanguage = "Arabic" Then
                If SearchLookUpEdit1.Text = String.Empty Then MsgBox("يجب اختيار نوع الاجازة") : Exit Sub
            Else
                If SearchLookUpEdit1.Text = String.Empty Then MsgBox("Vocation Type Empty ") : Exit Sub
            End If

            Dim _VocID As Integer = SearchLookUpEdit1.EditValue

            SqlString = SQLStringFunction(_DateFrom, _DateTo, _VocID)

            sql.SqlTrueTimeRunQuery(SqlString)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
            GridView1.BestFitColumns()
            Me.GridView1.OptionsFind.AlwaysVisible = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub VocationBalances_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesPositions' table. You can move, or remove it, as needed.
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.KeyPreview = True
        DateEditFrom.DateTime = Format(Today, "yyyy").ToString & "-01-01"
        DateEditTo.DateTime = Format(Today, "yyyy").ToString & "-12-31"
        Me.SearchLookUpEdit1.EditValue = 1
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Refreshing()
        End If
    End Sub

    Private Function SQLStringFunction(DateFrom As String, DateTo As String, VocID As Integer) As String
        Dim _SQLString As String

        _SQLString = "   SELECT EmpID,EmployeeName,DateOfStart,ISNULL(AllAddningBalances,0)-ISNULL (AllVocations,0) as balance,IsNull(VocationType," & VocID & ") As VocationType,
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
         
                           (  Select VocationType, EmployeeID AS Employe , ISNULL( AllAddningBalances,0) as AllAddningBalances  From EmployeesData  left join (  Select   SUM(BalanceDays) AS AllAddningBalances , Employee, VocationType   From [VacationsBalancesAdding]   where VocationType = " & VocID & " and [BalanceDate] <  '" & DateTo & "'   group by Employee,VocationType     ) aa    on aa.Employee = EmployeeID  ) DSA		       
                         on SS.EmpID = DSA.Employe

                         Left Join 

                           ( Select bb.EmployeeID AS Employee , ISNULL(AllVocations,0) as AllVocations From EmployeesData bb  left join ( Select  ISNULL( SUM(NoDays),0)  AS AllVocations,EmployeeID From [Vocations] where VocationType = " & VocID & " And FromDate <=  '" & DateTo & "'  group by EmployeeID    ) aa    on aa.EmployeeID = bb.EmployeeID  ) DSS
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

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Dim RowIndex As Integer = e.ListSourceRowIndex
        Dim _BeginingBalance As Decimal = GridView1.GetListSourceRowCellValue(RowIndex, "BeginingBalance")
        Dim _ThisYearSetBalance As Decimal = GridView1.GetListSourceRowCellValue(RowIndex, "ThisYearSetBalance")
        Dim _ThisYearVocations As Decimal = GridView1.GetListSourceRowCellValue(RowIndex, "THISYEARVOCATIONS")
        Dim _EmployeeStartDate As String = Format(CDate(GridView1.GetListSourceRowCellValue(RowIndex, "DateOfStart")), "yyyy-MM-dd")
        Dim _PartialPeriod As Integer
        Dim _PassingDays As Integer
        If (e.Column.FieldName <> "AccruedVocation") Then Return
        If (e.IsGetData) Then
            'If (_ThisYearSetBalance - _ThisYearVocations) <= 0 Then e.Value = 0 : Return
            Try
                '        If (_ThisYearSetBalance - _ThisYearVocations) > 0 Then
                Dim _PassingDaysFromThisYear As Integer = DateDiff(DateInterval.Day, CDate(Format(Today, "yyyy").ToString & "-01-01"), Today)
                Dim _PassingDaysFromStartdate As Integer = DateDiff(DateInterval.Day, CDate(_EmployeeStartDate), Today)

                If _PassingDaysFromThisYear > _PassingDaysFromStartdate Then
                    _PassingDays = _PassingDaysFromStartdate

                    _PartialPeriod = DateDiff(DateInterval.Day, CDate(_EmployeeStartDate), CDate(Format(Today, "yyyy").ToString & "-12-31"))
                Else
                    _PassingDays = _PassingDaysFromThisYear
                    _PartialPeriod = 365
                End If
                If _PassingDays <= 0 Then e.Value = 0 : Return
                e.Value = (_ThisYearSetBalance * (_PassingDays / _PartialPeriod) + _BeginingBalance - _ThisYearVocations).ToString("0.#")
                '     End If
            Catch ex As Exception
                e.Value = 0
                MsgBox(ex.ToString)
            End Try

        End If




    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub
    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        pb.PageSettings.TopMargin = 100
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select CompanyName  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() _
        {"  ", "Print@:" & Now(), "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add _
        (" " & "ارصدة الاجازات   " & " / " & SearchLookUpEdit1.Text)
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" ")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
        Dim _FromToDate As String = " من تاريخ:   " & DateEditFrom.EditValue & " الى تاريخ: " & " " & DateEditTo.EditValue
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(_FromToDate)
    End Sub
End Class