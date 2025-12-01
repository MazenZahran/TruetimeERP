Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraSplashScreen

Public Class AttRequiredHoursPeriodsForPlans
    Private Sub AttRequiredHoursPeriodsForPlans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPlans()
        SearchPlans.EditValue = 1

        Dim startDate As New Date(Today.Year, 1, 1)
        Dim EndDate As New Date(Today.Year + 5, 12, 31)
        Me.DateEdit1.DateTime = startDate
        Me.DateEdit2.DateTime = EndDate
        Me.KeyPreview = True
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(Me.AttPlaneForPeriodGridControl.PointToScreen(e.Point))
        End If
    End Sub
    Private Sub GetPlans()
        Dim sqlstring As String
        sqlstring = " SELECT id,PlaneCode,PlaneName from AttRequiredHoursPlanesNames order by ID "
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(sqlstring)
        SearchPlans.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        UpdateData()
    End Sub

    Private Sub UpdateInsertRows()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _Notes As String
        Dim _Location As Integer
        Dim _PlanCode As String = ""
        Dim _RequiredHoures As String = "00:00"
        Dim _InputDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        For i = 0 To GridView1.RowCount - 1
            _Notes = ""
            _Location = 0
            Dim _AttTransDate As String = Format(CDate(GridView1.GetRowCellValue(i, "AttTransDate")), "yyyy-MM-dd")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Notes")) Then _Notes = GridView1.GetRowCellValue(i, "Notes")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "Location")) Then _Location = GridView1.GetRowCellValue(i, "Location")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "RequiredHoures")) Then _RequiredHoures = GridView1.GetRowCellValue(i, "RequiredHoures")
            If Not IsDBNull(GridView1.GetRowCellValue(i, "PlanCode")) Then _PlanCode = GridView1.GetRowCellValue(i, "PlanCode")
            If IsDBNull(GridView1.GetRowCellValue(i, "ID")) Then
                SqlString = " INSERT INTO [dbo].[AttPlanForRequiredHours]
                                   ([AttTransDate],[PlanCode],[RequiredHoures],[Location],[Notes],InputDateTime)
                                   VALUES
                                   ('" & _AttTransDate & "','" & _PlanCode & "',
                                    '" & GridView1.GetRowCellValue(i, "RequiredHoures") & "',
                                    '" & _Location & "',N'" & _Notes & "','" & _InputDateTime & "') "
                Sql.SqlTrueTimeRunQuery(SqlString)
            Else
                SqlString = " Update [dbo].[AttPlanForRequiredHours] Set
                                     Location ='" & _Location & "',
                                     Notes =N'" & _Notes & "',
                                     PlanCode ='" & _PlanCode & "',
                                     RequiredHoures ='" & _RequiredHoures & "',
                                     InputDateTime ='" & _InputDateTime & "'
                              Where ID=" & GridView1.GetRowCellValue(i, "ID")
                Sql.SqlTrueTimeRunQuery(SqlString)
            End If
            SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (GridView1.RowCount - 1)) & "%")
            ' Thread.Sleep(25)
        Next
    End Sub

    Private Sub SearchPlans_Properties_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles SearchPlans.Properties.AddNewValue
        Dim F As New PlansForRequiredHours
        With F
            If .ShowDialog <> DialogResult.OK Then
                GetPlans()
            End If
        End With
    End Sub
    Private Sub View_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs)
        Try
            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim _ColDateFrom As GridColumn = view.Columns("DateFrom")
            Dim _ColDateTo As GridColumn = view.Columns("DateTo")
            Dim _ColRequiredHours As GridColumn = view.Columns("RequiredHours")
            Dim dateFrom As String = ""
            Dim dateTo As String = ""
            Dim requiredHours As String = ""

            Try
                dateFrom = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DateFrom")
            Catch ex As Exception
                dateFrom = ""
            End Try
            Try
                dateTo = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DateTo")
            Catch ex As Exception
                dateTo = ""
            End Try
            Try
                requiredHours = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RequiredHours")
            Catch ex As Exception
                requiredHours = ""
            End Try


            If IsDBNull(dateFrom) Or String.IsNullOrEmpty(dateFrom) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال التاريخ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColDateFrom
                view.ShowEditor()
            End If

            If IsDBNull(dateTo) = True Or String.IsNullOrEmpty(dateTo) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال التاريخ"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColDateTo
                view.ShowEditor()
            End If

            If IsDBNull(requiredHours) = True Or String.IsNullOrEmpty(requiredHours) Then
                e.Valid = False
                e.ErrorText = "يجب ادخال الساعات المطلوبة"
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = _ColRequiredHours
                view.ShowEditor()
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GridView1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Dim view As GridView = TryCast(sender, GridView)
        If e.Column.FieldName = "RequiredHoures2" Then
            If e.IsGetData Then
                e.Value = getTotalValue(view, e.ListSourceRowIndex)
            ElseIf e.IsSetData Then
                Dim _string As String
                _string = e.Value.ToString.Substring(0, 5)
                view.SetFocusedRowCellValue("RequiredHoures", _string)
                '  MsgBox(e.Value.ToString)
            End If
        End If
    End Sub
    Private Function getTotalValue(view As GridView, listSourceRowIndex As Integer) As TimeSpan
        If Not IsDBNull(view.GetListSourceRowCellValue(listSourceRowIndex, "RequiredHoures")) Then
            Dim _period As TimeSpan = TimeSpan.Parse(CStr(view.GetListSourceRowCellValue(listSourceRowIndex, "RequiredHoures")))
            Return _period
        Else
            Return TimeSpan.Zero
        End If
    End Function

    Private Sub BtnRefreshData_Click(sender As Object, e As EventArgs) Handles BtnRefreshData.Click
        CreateTable()
    End Sub
    Private Sub CreateTable()
        Dim _DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim _Date__To As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim Sql As New SQLControl

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If String.IsNullOrEmpty(SearchPlans.EditValue) Then MsgBox("يجب اختيار الخطة") : Exit Sub
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            If String.IsNullOrEmpty(SearchPlans.EditValue) Then MsgBox(" You must select the plan ") : Exit Sub
        End If


        Dim SqlString As String = " DECLARE @MinDate DATE = '" & _DateFrom & "',
                                            @MaxDate DATE = '" & _Date__To & "';
                                    Select [ID], A.[AttTransDate], [Location], [Notes],[RequiredHoures],[PlanCode], '' as DatePartString, '' as DayOfWeek
                                    From 
                                    (SELECT TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
			                                    [AttTransDate] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),
			                                    [AttTransDateName] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
                                    FROM sys.all_objects a CROSS JOIN sys.all_objects b 
                                    )
                                    A
                                    Left Join 
                                    (
                                    SELECT [ID], [AttTransDate], [PlanCode],[Location], [Notes],[RequiredHoures]
                                    FROM [dbo].[AttPlanForRequiredHours] where PlanCode=" & Me.SearchPlans.EditValue & "
                                    ) B 
                                    On A.AttTransDate=b.AttTransDate  Order by A.AttTransDate"
        Sql.SqlTrueTimeRunQuery(SqlString)
        Me.AttPlaneForPeriodGridControl.DataSource = Sql.SQLDS.Tables(0)
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, "ID")) Then
                GridView1.SetRowCellValue(i, GridView1.Columns("PlanCode"), SearchPlans.EditValue)
                GridView1.SetRowCellValue(i, GridView1.Columns("RequiredHoures"), "00:00")
                GridView1.SetRowCellValue(i, GridView1.Columns("Location"), "")
                GridView1.SetRowCellValue(i, GridView1.Columns("Notes"), "")

            End If


            If GlobalVariables._SystemLanguage = "Arabic" Then
                GridView1.SetRowCellValue(i, GridView1.Columns("DatePartString"), CDate(GridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd", New System.Globalization.CultureInfo("ar-AE")))
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                GridView1.SetRowCellValue(i, GridView1.Columns("DatePartString"), CDate(GridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd"))
            End If

            GridView1.SetRowCellValue(i, GridView1.Columns("DayOfWeek"), CInt(CDate(GridView1.GetRowCellValue(i, "AttTransDate")).DayOfWeek))
        Next
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
        MsgBoxShowSuccess(" تم تعريف الخطة  ")
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim _RowIndex As Integer = GridView1.GetVisibleIndex(GridView1.FocusedRowHandle)
        Dim _PlanCode, TheLocation, _RequiredHoures, _Notes As String
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlanCode")) Then
            _PlanCode = ""
        Else
            _PlanCode = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlanCode")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")) Then
            TheLocation = ""
        Else
            TheLocation = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RequiredHoures")) Then
            _RequiredHoures = ""
        Else
            _RequiredHoures = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RequiredHoures")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Notes")) Then
            _Notes = ""
        Else
            _Notes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Notes")
        End If
        Dim CurrDateString As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DatePartString")
        For i = _RowIndex To GridView1.RowCount - 1
            Dim _FocusedDay As String = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DayOfWeek")
            Dim _Nextday As String = GridView1.GetRowCellValue(i, "DayOfWeek")

            If _FocusedDay = _Nextday Then
                GridView1.SetRowCellValue(i, GridView1.Columns("PlanCode"), _PlanCode)
                GridView1.SetRowCellValue(i, GridView1.Columns("Location"), TheLocation)
                GridView1.SetRowCellValue(i, GridView1.Columns("RequiredHoures"), _RequiredHoures)
                GridView1.SetRowCellValue(i, GridView1.Columns("Notes"), _Notes)
            End If
        Next


        If GlobalVariables._SystemLanguage = "Arabic" Then
            XtraMessageBox.Show("تم النسخ لايام" & " " & CurrDateString & " " & "فقط")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            XtraMessageBox.Show(" Data Filled " & " " & CurrDateString & " " & " Only ")
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _RowIndex As Integer = GridView1.GetVisibleIndex(GridView1.FocusedRowHandle)
        Dim _PlanCode, TheLocation, _RequiredHoures, _Notes As String
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlanCode")) Then
            _PlanCode = ""
        Else
            _PlanCode = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "PlanCode")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")) Then
            TheLocation = ""
        Else
            TheLocation = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Location")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RequiredHoures")) Then
            _RequiredHoures = ""
        Else
            _RequiredHoures = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "RequiredHoures")
        End If
        If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Notes")) Then
            _Notes = ""
        Else
            _Notes = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Notes")
        End If
        Dim CurrDateString As String = Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "DatePartString")
        For i = _RowIndex To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, GridView1.Columns("PlanCode"), _PlanCode)
            GridView1.SetRowCellValue(i, GridView1.Columns("Location"), TheLocation)
            GridView1.SetRowCellValue(i, GridView1.Columns("RequiredHoures"), _RequiredHoures)
            GridView1.SetRowCellValue(i, GridView1.Columns("Notes"), _Notes)
        Next


        If GlobalVariables._SystemLanguage = "Arabic" Then
            XtraMessageBox.Show("تم النسخ لكل الايام")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            XtraMessageBox.Show("Data Filled For All Days")
        End If
    End Sub
End Class