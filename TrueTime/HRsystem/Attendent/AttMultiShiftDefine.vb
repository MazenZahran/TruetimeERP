Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class AttMultiShiftDefine
    Private Sub AttMultiShiftDefine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEdit2.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt
        Me.KeyPreview = True
        GetEmployees()
    End Sub
    Private Sub GetEmployees()
        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(" Select [EmployeeID],[EmployeeName],[Department],[JobName],[Branch] from [dbo].[EmployeesData] where Active=1 ")
        SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        UpdateData()
    End Sub
    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(Me.GridControl1.PointToScreen(e.Point))
        End If
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles BandedGridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub
    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawCell
        Dim AddImage As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png")
        Dim ApplyImage As Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/apply_16x16.png")
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "ID" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If category = "" Then
                e.Graphics.DrawImage(AddImage, e.Bounds.Location)
                e.DisplayText = String.Empty
                e.Appearance.Options.CancelUpdate()
            End If
            If category <> "" Then
                e.Graphics.DrawImage(ApplyImage, e.Bounds.Location)
                e.DisplayText = String.Empty
            End If
        End If
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
                                    Select [ID], A.[AttTransDate], [EmpID],' ' as Notes,
                                            IsNull(StartTime1,'00:00') as StartTimeA,IsNull(StartTime2,'00:00') as StartTimeB,IsNull(StartTime3,'00:00') as StartTimeC,
                                            IsNull(EndTime1,'00:00') as EndTimeA,IsNull(EndTime2,'00:00') as EndTimeB,IsNull(EndTime3,'00:00') as EndTimeC, '' as DatePartString, '' as DayOfWeek,'' as GridColumn2,IsNull(LateMinutes,0) as LateMinutes ,IsNull(EarlyMinutes,0) as EarlyMinutes ,IsNull(BonusBefore,0) as BonusBefore,IsNull(BonusAfter,0) as BonusAfter
                                    From (SELECT TOP (DATEDIFF(DAY, @MinDate, @MaxDate) + 1)
                                             [AttTransDate] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate),
                                             [AttTransDateName] = DATEADD(DAY, ROW_NUMBER() OVER(ORDER BY a.object_id) - 1, @MinDate)
                                             FROM sys.all_objects a CROSS JOIN sys.all_objects b ) A
                                    Left Join (SELECT [ID], [AttTransDate], [EmpID], LateMinutes,EarlyMinutes,
                                            CONVERT(VARCHAR(5), [StartTime1], 108) as StartTime1, CONVERT(VARCHAR(5), [EndTime1], 108) as EndTime1,
                                            CONVERT(VARCHAR(5), [StartTime2], 108) as StartTime2, CONVERT(VARCHAR(5), [EndTime2], 108) as EndTime2,
                                            CONVERT(VARCHAR(5), [StartTime3], 108) as StartTime3, CONVERT(VARCHAR(5), [EndTime3], 108) as EndTime3,
                                            BonusBefore,BonusAfter
                                    FROM [dbo].[AttPlanMultiplePeriods] where EmpID='" & SearchLookUpEdit1.EditValue & "') B On A.AttTransDate=b.AttTransDate  Order by A.AttTransDate"
        Sql.SqlTrueTimeRunQuery(SqlString)
        Me.GridControl1.DataSource = Sql.SQLDS.Tables(0)
        For i = 0 To BandedGridView1.RowCount - 1
            If IsDBNull(BandedGridView1.GetRowCellValue(i, "ID")) Then
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EmpID"), SearchLookUpEdit1.EditValue)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("StartTime1"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EndTime1"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("StartTime2"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EndTime2"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("StartTime3"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EndTime3"), "00:00")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("BonusBefore"), "0")
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("BonusAfter"), "0")
            End If


            If GlobalVariables._SystemLanguage = "Arabic" Then
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("DatePartString"), CDate(BandedGridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd", New System.Globalization.CultureInfo("ar-AE")))
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("DatePartString"), CDate(BandedGridView1.GetRowCellValue(i, "AttTransDate")).ToString("dddd"))
            End If


            BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("DayOfWeek"), CInt(CDate(BandedGridView1.GetRowCellValue(i, "AttTransDate")).DayOfWeek))
        Next
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CreateTable()
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
    End Sub
    Private Sub UpdateInsertRows()
        Dim Sql As New SQLControl
        Dim SqlString As String
        Dim _Notes As String
        Dim _Location As Integer
        Dim _LateMinutes As Integer
        Dim _EarlyMinutes As Integer
        Dim _BonusBefore As Integer
        Dim _BonusAfter As Integer

        For i = 0 To BandedGridView1.RowCount - 1
            _Notes = ""
            _Location = 0
            Dim _AttTransDate As String = Format(CDate(BandedGridView1.GetRowCellValue(i, "AttTransDate")), "yyyy-MM-dd")
            Dim _EmpID As String = SearchLookUpEdit1.EditValue
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "Notes")) Then _Notes = BandedGridView1.GetRowCellValue(i, "Notes")
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "LateMinutes")) Then _LateMinutes = BandedGridView1.GetRowCellValue(i, "LateMinutes")
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "EarlyMinutes")) Then _EarlyMinutes = BandedGridView1.GetRowCellValue(i, "EarlyMinutes")
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "BonusBefore")) Then _BonusBefore = BandedGridView1.GetRowCellValue(i, "BonusBefore")
            If Not IsDBNull(BandedGridView1.GetRowCellValue(i, "BonusAfter")) Then _BonusAfter = BandedGridView1.GetRowCellValue(i, "BonusAfter")
            If IsDBNull(BandedGridView1.GetRowCellValue(i, "ID")) Then
                SqlString = " INSERT INTO [dbo].[AttPlanMultiplePeriods]
                                   ([AttTransDate],[EmpID],[StartTime1],[EndTime1],[StartTime2],[EndTime2],[StartTime3],[EndTime3],[Notes],LateMinutes,EarlyMinutes,BonusBefore,BonusAfter)
                                   VALUES
                                   ('" & _AttTransDate & "','" & _EmpID & "',
                                    '" & BandedGridView1.GetRowCellValue(i, "StartTimeA") & "','" & BandedGridView1.GetRowCellValue(i, "EndTimeA") & "',
                                    '" & BandedGridView1.GetRowCellValue(i, "StartTimeB") & "','" & BandedGridView1.GetRowCellValue(i, "EndTimeB") & "',
                                    '" & BandedGridView1.GetRowCellValue(i, "StartTimeC") & "','" & BandedGridView1.GetRowCellValue(i, "EndTimeC") & "',
                                    N'" & _Notes & "'," & _LateMinutes & "," & _EarlyMinutes & "," & _BonusBefore & "," & _BonusAfter & ") "
                Sql.SqlTrueTimeRunQuery(SqlString)
            Else
                SqlString = " Update [dbo].[AttPlanMultiplePeriods] Set
                                     StartTime1= '" & BandedGridView1.GetRowCellValue(i, "StartTimeA") & "',
                                     EndTime1='" & BandedGridView1.GetRowCellValue(i, "EndTimeA") & "',
                                     StartTime2= '" & BandedGridView1.GetRowCellValue(i, "StartTimeB") & "',
                                     EndTime2='" & BandedGridView1.GetRowCellValue(i, "EndTimeB") & "',
                                     StartTime3= '" & BandedGridView1.GetRowCellValue(i, "StartTimeC") & "',
                                     EndTime3='" & BandedGridView1.GetRowCellValue(i, "EndTimeC") & "',
                                     Notes =N'" & _Notes & "',
                                     LateMinutes =" & _LateMinutes & ",
                                     EarlyMinutes =" & _EarlyMinutes & ",
                                     BonusBefore =" & _BonusBefore & ",
                                     BonusAfter =" & _BonusAfter & "
                              Where ID=" & BandedGridView1.GetRowCellValue(i, "ID")
                Sql.SqlTrueTimeRunQuery(SqlString)
End If
            SplashScreenManager.Default.SetWaitFormDescription(CInt(100 * i / (BandedGridView1.RowCount - 1)) & "%")
            ' Thread.Sleep(25)
        Next
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim _RowIndex As Integer = BandedGridView1.GetVisibleIndex(BandedGridView1.FocusedRowHandle)
        Dim St1, St2, End1, End2, End3, _LateMinutes, _EarlyMinutes, _ShiftRest, _BonusAfter, _BonusBefore As String
        St2 = "0"
        _ShiftRest = "0"
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StartTimeA")) Then
            St1 = ""
        Else
            St1 = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StartTimeA")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeA")) Then
            End1 = ""
        Else
            End1 = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeA")
        End If

        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StartTimeB")) Then
            End1 = ""
        Else
            End1 = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "StartTimeB")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeB")) Then
            End2 = ""
        Else
            End2 = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeB")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeC")) Then
            End3 = ""
        Else
            End3 = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EndTimeC")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "LateMinutes")) Then
            _LateMinutes = "0"
        Else
            _LateMinutes = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "LateMinutes")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EarlyMinutes")) Then
            _EarlyMinutes = "0"
        Else
            _EarlyMinutes = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "EarlyMinutes")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "BonusBefore")) Then
            _BonusBefore = "0"
        Else
            _BonusBefore = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "BonusBefore")
        End If
        If IsDBNull(Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "BonusAfter")) Then
            _BonusAfter = "0"
        Else
            _BonusAfter = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "BonusAfter")
        End If
        Dim CurrDateString As String = Me.BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DatePartString")
        For i = _RowIndex To BandedGridView1.RowCount - 1
            If BandedGridView1.GetRowCellValue(i, "DayOfWeek") = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DayOfWeek") Then
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("StartTime"), St1)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EndTime"), St2)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("LateMinutes"), _LateMinutes)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("EarlyMinutes"), _EarlyMinutes)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("ShiftRest"), _ShiftRest)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("BonusBefore"), _BonusBefore)
                BandedGridView1.SetRowCellValue(i, BandedGridView1.Columns("BonusAfter"), _BonusAfter)
            End If
        Next


        If GlobalVariables._SystemLanguage = "Arabic" Then
            XtraMessageBox.Show("تم النسخ لايام" & " " & CurrDateString & " " & "فقط")
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            XtraMessageBox.Show(" Data Filled " & " " & CurrDateString & " " & " Only ")
        End If



    End Sub
End Class