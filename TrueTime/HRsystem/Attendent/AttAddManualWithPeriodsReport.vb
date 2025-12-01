Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class AttAddManualWithPeriodsReport
    Private Sub AttAddManualWithPeriodsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        'Me.AttPlaneForPeriodTableAdapter.FillByEmpIDAndTransDate(Me.TrueTimeDataSet.AttPlaneForPeriod, -1, CDate("1900-01-01"), CDate("1900-01-01"))
        '   Me.AttPlaneForPeriodTableAdapter.Fill(Me.TrueTimeDataSet.AttPlaneForPeriod)
        ' Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
        Me.DateEdit2.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt
        Me.KeyPreview = True
        GetLocations()
        CheckForIllegalCrossThreadCalls = False
        GetEmployees()
        LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub
    Private Sub GetEmployees()
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(" Select [EmployeeID],[EmployeeName],[Department],[JobName],[Branch] from [dbo].[EmployeesData] where Active=1 ")
        SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            CreateTable()
        ElseIf e.KeyCode = Keys.F3 Then
            UpdateData()
        End If
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(Me.AttPlaneForPeriodGridControl.PointToScreen(e.Point))
        End If
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell
        ''  Dim AddImage As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png")
        'Dim AddImage As Image = My.Resources.User_Red_icon
        ''  Dim ApplyImage As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png")
        'Dim ApplyImage As Image = My.Resources.User_Blue_icon
        'Dim View As GridView = CType(sender, GridView)
        'If e.Column.FieldName = "ID" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
        '    If category = "" Then
        '        e.Graphics.DrawImage(AddImage, e.Bounds.Location)
        '        e.DisplayText = String.Empty
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        '    If category <> "" Then
        '        e.Graphics.DrawImage(ApplyImage, e.Bounds.Location)
        '        e.DisplayText = String.Empty
        '    End If
        'End If
    End Sub
    Private Sub CreateTable()
        Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim _Date__To As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim Sql As New SQLControl

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If String.IsNullOrEmpty(SearchLookUpEdit1.EditValue) Then MsgBox("يجب اختيار موظف") : Exit Sub
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            If String.IsNullOrEmpty(SearchLookUpEdit1.EditValue) Then MsgBox(" You must select employee ") : Exit Sub
        End If


        Dim SqlString As String = " DECLARE @MinDate DATE = '" & _DateFrom & "',
                                            @MaxDate DATE = '" & _Date__To & "';
                                    Select [ID], A.[AttTransDate], [EmpID], IsNull(StartTime,'00:00') as StartTime, IsNull(EndTime,'00:00') as EndTime, [Location], [Notes], '' as DatePartString, '' as DayOfWeek,'' as GridColumn2,LateMinutes,EarlyMinutes,ShiftRest,IsNull(BonusBefore,0) as BonusBefore,IsNull(BonusAfter,0) as BonusAfter
                                    From (SELECT TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
                                             [AttTransDate] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),
                                             [AttTransDateName] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
                                             FROM sys.all_objects a CROSS JOIN sys.all_objects b ) A
                                    Left Join (SELECT [ID], [AttTransDate], [PlaneID], [EmpID], CONVERT(VARCHAR(5), [StartTime], 108) as StartTime, CONVERT(VARCHAR(5), [EndTime], 108) as EndTime,[Location], [Notes],LateMinutes,EarlyMinutes,ShiftRest,BonusBefore,BonusAfter
                                    FROM [dbo].[AttPlaneForPeriod] where EmpID='" & SearchLookUpEdit1.EditValue & "') B On A.AttTransDate=b.AttTransDate  Order by A.AttTransDate"
        Sql.SqlTrueTimeRunQuery(SqlString)
        Me.AttPlaneForPeriodGridControl.DataSource = Sql.SQLDS.Tables(0)
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, "ID")) Then
                GridView1.SetRowCellValue(i, GridView1.Columns("EmpID"), SearchLookUpEdit1.EditValue)
                GridView1.SetRowCellValue(i, GridView1.Columns("Location"), TextLocation.Text)
                GridView1.SetRowCellValue(i, GridView1.Columns("PlaneID"), TextAttPlane.Text)
                GridView1.SetRowCellValue(i, GridView1.Columns("StartTime"), "00:00")
                GridView1.SetRowCellValue(i, GridView1.Columns("EndTime"), "00:00")
                GridView1.SetRowCellValue(i, GridView1.Columns("LateMinutes"), "0")
                GridView1.SetRowCellValue(i, GridView1.Columns("EarlyMinutes"), "0")
                GridView1.SetRowCellValue(i, GridView1.Columns("ShiftRest"), "0")
                GridView1.SetRowCellValue(i, GridView1.Columns("BonusBefore"), "0")
                GridView1.SetRowCellValue(i, GridView1.Columns("BonusAfter"), "0")
            End If


            If GlobalVariables._SystemLanguage = "Arabic" Then
                GridView1.SetRowCellValue(i, GridView1.Columns("DatePartString"), CDate(GridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd", New System.Globalization.CultureInfo("ar-AE")))
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                GridView1.SetRowCellValue(i, GridView1.Columns("DatePartString"), CDate(GridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd"))
            End If


            GridView1.SetRowCellValue(i, GridView1.Columns("DayOfWeek"), CInt(CDate(GridView1.GetRowCellValue(i, "AttTransDate")).DayOfWeek))
        Next
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CreateTable()
    End Sub
    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        If SearchLookUpEdit1.IsHandleCreated Then
            Try
                Dim Sql As New SQLControl
                Dim SqlString As String = "   Select AttPlane,E.[Location],A.StartTime,A.EndTime 
                                              From EmployeesData E
                                              Left Join [AttPlaneForPeriod] A on E.AttPlane=A.PlaneID
                                              Where EmployeeID ='" & SearchLookUpEdit1.EditValue & "'"
                Sql.SqlTrueTimeRunQuery(SqlString)
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Location")) Then TextLocation.Text = Sql.SQLDS.Tables(0).Rows(0).Item("Location")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        UpdateData()
    End Sub
    Private Sub UpdateData()
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
            UpdateInsertRows()
            SplashScreenManager.CloseForm(False)
        Catch ex As Exception
            MsgBox(ex.ToString)
            SplashScreenManager.CloseForm(False)
        End Try
        CreateTable()
        MsgBoxShowSuccess(" تم تعريف الوردية  ")
    End Sub
    Private Sub UpdateInsertRows()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _Notes As String
        Dim _Location As Integer
        Dim _LateMinutes As Integer
        Dim _EarlyMinutes As Integer
        Dim _ShiftRest As Integer
        Dim _BonusBefore As Integer
        Dim _BonusAfter As Integer
        Dim _InputDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        For i = 0 To GridView1.RowCount - 1
            _Notes = ""
            _Location = 0
            Dim _AttTransDate As String = Format(CDate(GridView1.GetRowCellValue(i, "AttTransDate")), "yyyy-MM-dd")
            Dim _EmpID As String = GridView1.GetRowCellValue(i, "EmpID")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Notes")) Then _Notes = GridView1.GetRowCellValue(i, "Notes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Location")) Then _Location = GridView1.GetRowCellValue(i, "Location")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "LateMinutes")) Then _LateMinutes = GridView1.GetRowCellValue(i, "LateMinutes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "EarlyMinutes")) Then _EarlyMinutes = GridView1.GetRowCellValue(i, "EarlyMinutes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "ShiftRest")) Then _ShiftRest = GridView1.GetRowCellValue(i, "ShiftRest")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "BonusBefore")) Then _BonusBefore = GridView1.GetRowCellValue(i, "BonusBefore")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "BonusAfter")) Then _BonusAfter = GridView1.GetRowCellValue(i, "BonusAfter")
            If IsDBNull(GridView1.GetRowCellValue(i, "ID")) Then
                SqlString = " INSERT INTO [dbo].[AttPlaneForPeriod]
                                   ([AttTransDate],[EmpID],[StartTime],[EndTime],[Location],[Notes],LateMinutes,EarlyMinutes,ShiftRest,BonusBefore,BonusAfter,InputDateTime)
                                   VALUES
                                   ('" & _AttTransDate & "','" & _EmpID & "',
                                    '" & GridView1.GetRowCellValue(i, "StartTime") & "','" & GridView1.GetRowCellValue(i, "EndTime") & "',
                                    '" & _Location & "',N'" & _Notes & "'," & _LateMinutes & "," & _EarlyMinutes & "," & _ShiftRest & "," & _BonusBefore & "," & _BonusAfter & ",'" & _InputDateTime & "') "
                Sql.SqlTrueTimeRunQuery(SqlString)
            Else
                SqlString = " Update [dbo].[AttPlaneForPeriod] Set
                                     StartTime= '" & GridView1.GetRowCellValue(i, "StartTime") & "',
                                     EndTime='" & GridView1.GetRowCellValue(i, "EndTime") & "',
                                     Location ='" & _Location & "',
                                     Notes =N'" & _Notes & "',
                                     LateMinutes =" & _LateMinutes & ",
                                     EarlyMinutes =" & _EarlyMinutes & ",
                                     BonusBefore =" & _BonusBefore & ",
                                     BonusAfter =" & _BonusAfter & ",
                                     ShiftRest =" & _ShiftRest & ",
                                     InputDateTime ='" & _InputDateTime & "'
                              Where ID=" & GridView1.GetRowCellValue(i, "ID")
                Sql.SqlTrueTimeRunQuery(SqlString)
            End If
            SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (GridView1.RowCount - 1)) & "%")
            ' Thread.Sleep(25)
        Next
    End Sub
    Private Sub GetLocations()
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select [LocationName],[LocationID] FROM [dbo].[Locations] "
        Sql.SqlTrueTimeRunQuery(SqlString)
        RepositoryLocation.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _RowIndex As Integer = GridView1.GetVisibleIndex(GridView1.FocusedRowHandle)
        Dim St1, St2, TheLocation, _LateMinutes, _EarlyMinutes, _ShiftRest, _BonusAfter, _BonusBefore As String
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StartTime")) Then
            St1 = ""
        Else
            St1 = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StartTime")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EndTime")) Then
            St2 = ""
        Else
            St2 = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EndTime")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")) Then
            TheLocation = ""
        Else
            TheLocation = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "LateMinutes")) Then
            _LateMinutes = "0"
        Else
            _LateMinutes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "LateMinutes")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EarlyMinutes")) Then
            _EarlyMinutes = "0"
        Else
            _EarlyMinutes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EarlyMinutes")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ShiftRest")) Then
            _ShiftRest = "0"
        Else
            _ShiftRest = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ShiftRest")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")) Then
            _BonusBefore = "0"
        Else
            _BonusBefore = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")) Then
            _BonusAfter = "0"
        Else
            _BonusAfter = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")
        End If
        Dim CurrDateString As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DatePartString")
        For i = _RowIndex To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(i, "DayOfWeek") = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DayOfWeek") Then
                GridView1.SetRowCellValue(i, GridView1.Columns("StartTime"), St1)
                GridView1.SetRowCellValue(i, GridView1.Columns("EndTime"), St2)
                GridView1.SetRowCellValue(i, GridView1.Columns("Location"), TheLocation)
                GridView1.SetRowCellValue(i, GridView1.Columns("LateMinutes"), _LateMinutes)
                GridView1.SetRowCellValue(i, GridView1.Columns("EarlyMinutes"), _EarlyMinutes)
                GridView1.SetRowCellValue(i, GridView1.Columns("ShiftRest"), _ShiftRest)
                GridView1.SetRowCellValue(i, GridView1.Columns("BonusBefore"), _BonusBefore)
                GridView1.SetRowCellValue(i, GridView1.Columns("BonusAfter"), _BonusAfter)
            End If
        Next


        If GlobalVariables._SystemLanguage = "Arabic" Then
            XtraMessageBox.Show("تم النسخ لايام" & " " & CurrDateString & " " & "فقط")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            XtraMessageBox.Show(" Data Filled " & " " & CurrDateString & " " & " Only ")
        End If



    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim _RowIndex As Integer = GridView1.GetVisibleIndex(GridView1.FocusedRowHandle)
        Dim St1, St2, TheLocation, _LateMinutes, _EarlyMinutes, _ShiftRest, _BonusAfter, _BonusBefore As String
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StartTime")) Then
            St1 = ""
        Else
            St1 = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "StartTime")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EndTime")) Then
            St2 = ""
        Else
            St2 = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EndTime")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")) Then
            TheLocation = ""
        Else
            TheLocation = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "LateMinutes")) Then
            _LateMinutes = "0"
        Else
            _LateMinutes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "LateMinutes")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EarlyMinutes")) Then
            _EarlyMinutes = "0"
        Else
            _EarlyMinutes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "EarlyMinutes")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ShiftRest")) Then
            _ShiftRest = "0"
        Else
            _ShiftRest = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "ShiftRest")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")) Then
            _BonusBefore = "0"
        Else
            _BonusBefore = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")) Then
            _BonusAfter = "0"
        Else
            _BonusAfter = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")
        End If
        For i = _RowIndex To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, GridView1.Columns("StartTime"), St1)
            GridView1.SetRowCellValue(i, GridView1.Columns("EndTime"), St2)
            GridView1.SetRowCellValue(i, GridView1.Columns("Location"), TheLocation)
            GridView1.SetRowCellValue(i, GridView1.Columns("LateMinutes"), _LateMinutes)
            GridView1.SetRowCellValue(i, GridView1.Columns("EarlyMinutes"), _EarlyMinutes)
            GridView1.SetRowCellValue(i, GridView1.Columns("ShiftRest"), _ShiftRest)
            GridView1.SetRowCellValue(i, GridView1.Columns("BonusBefore"), _BonusBefore)
            GridView1.SetRowCellValue(i, GridView1.Columns("BonusAfter"), _BonusAfter)
        Next


        If GlobalVariables._SystemLanguage = "Arabic" Then
            XtraMessageBox.Show("تم النسخ لكل الايام")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            XtraMessageBox.Show("Data Filled For All Days")
        End If



    End Sub


    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Me.AttPlaneForPeriodGridControl.ShowPrintPreview()
    End Sub
    Private Sub AdvBandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize




        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = False
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Dim Tawqe3 As String = " .................:توقيع الادارة"
        Dim Tawqe3_2 As String = " .................:توقيع الموظف"

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {Tawqe3, Tawqe3_2, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.Add(Tawqe3)


        If SearchLookUpEdit1.Text <> String.Empty Or IsDBNull(SearchLookUpEdit1.EditValue) Or CStr(SearchLookUpEdit1.EditValue) IsNot Nothing Or CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" وردية موظف لفترة : " & SearchLookUpEdit1.Text)
        Else
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("وردية موظف لفترة  ")
        End If

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)



    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim _Date__To As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Try

            Dim _EmployeesTable As New DataTable
            Dim EmpID As String
            Dim Sql As New SQLControl
            Sql.SqlTrueTimeRunQuery(" Select [EmployeeID],[UserIDInAttFile] as EmpID,[EmployeeName],[Department],[JobName],[Branch]
                                  from [dbo].[EmployeesData] where  Department=N'" & LookUpEditDepartment.EditValue & " ' and Active=1")
            _EmployeesTable = Sql.SQLDS.Tables(0)
            If _EmployeesTable.Rows.Count = 0 Then Exit Sub
            For i = 0 To _EmployeesTable.Rows.Count - 1
                If Not IsDBNull(_EmployeesTable.Rows(i).Item("EmpID")) Then
                    EmpID = _EmployeesTable.Rows(i).Item("EmpID")
                    Sql.SqlTrueTimeRunQuery("  delete from [dbo].[AttPlaneForPeriod] 
                                               where empid='" & EmpID & "' and 
                                               [AttTransDate] between '" & _DateFrom & "' And '" & _Date__To & "'")
                    SplashScreenManager.ShowForm(Me, GetType(WaitForm11), True, True, False)
                    SplashScreenManager.Default.SetWaitFormCaption("الرجاء الانتظار")
                    UpdateInsertRowsByEmployee(EmpID) '
                    SplashScreenManager.CloseForm(False)
                End If

            Next
            MsgBoxShowSuccess(" تم توزيع الوردية على  " & _EmployeesTable.Rows.Count & " موظف ")
        Catch ex As Exception
            MsgBox(ex.ToString)
            SplashScreenManager.CloseForm(False)
        End Try




    End Sub
    Private Sub UpdateInsertRowsByEmployee(EmpID As String)
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _Notes As String
        Dim _Location As Integer
        Dim _LateMinutes As Integer
        Dim _EarlyMinutes As Integer
        Dim _ShiftRest As Integer
        Dim _BonusBefore As Integer
        Dim _BonusAfter As Integer

        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")) Then
            _BonusBefore = "0"
        Else
            _BonusBefore = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusBefore")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")) Then
            _BonusAfter = "0"
        Else
            _BonusAfter = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BonusAfter")
        End If


        For i = 0 To GridView1.RowCount - 1
            _Notes = ""
            _Location = 0
            Dim _AttTransDate As String = Format(CDate(GridView1.GetRowCellValue(i, "AttTransDate")), "yyyy-MM-dd")
            Dim _EmpID As String = EmpID
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Notes")) Then _Notes = GridView1.GetRowCellValue(i, "Notes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Location")) Then _Location = GridView1.GetRowCellValue(i, "Location")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "LateMinutes")) Then _LateMinutes = GridView1.GetRowCellValue(i, "LateMinutes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "EarlyMinutes")) Then _EarlyMinutes = GridView1.GetRowCellValue(i, "EarlyMinutes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "ShiftRest")) Then _ShiftRest = GridView1.GetRowCellValue(i, "ShiftRest")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "BonusBefore")) Then _BonusBefore = GridView1.GetRowCellValue(i, "BonusBefore")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "BonusAfter")) Then _BonusAfter = GridView1.GetRowCellValue(i, "BonusAfter")

            SqlString = " INSERT INTO [dbo].[AttPlaneForPeriod]
                                   ([AttTransDate],[EmpID],[StartTime],[EndTime],[Location],[Notes],LateMinutes,EarlyMinutes,ShiftRest,BonusBefore,BonusAfter)
                                   VALUES
                                   ('" & _AttTransDate & "','" & _EmpID & "',
                                    '" & GridView1.GetRowCellValue(i, "StartTime") & "','" & GridView1.GetRowCellValue(i, "EndTime") & "',
                                    '" & _Location & "',N'" & _Notes & "'," & _LateMinutes & "," & _EarlyMinutes & "," & _ShiftRest & "," & _BonusBefore & "," & _BonusAfter & ") "
            Sql.SqlTrueTimeRunQuery(SqlString)

            SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (GridView1.RowCount - 1)) & "%")
        Next
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If CheckEdit1.CheckState = CheckState.Checked Then
            LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    Private Sub BarSubItem1_Popup(sender As Object, e As EventArgs) Handles BarSubItem1.Popup
        BarButtonItem3.Caption = " توزيع الورديةة لكل الموظفين بناء على وردية الموظف  " & SearchLookUpEdit1.Text
    End Sub
End Class