Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class AttReportLeaves2222
    '  Inherits XtraForm
    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean




    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

        '   MsgBox(BandedGridView1.GetFocusedRowCellValue("TransDate"))

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        GridControl1.DataSource = String.Empty
        Summery = False
        '   Try

        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("جاري تحضير بيانات التقرير...")

        'If CStr(SearchLookUpEdit1.EditValue) = String.Empty And CStr(LookUpEditBranch.EditValue) = String.Empty And CStr(LookUpEditDepartment.EditValue) = String.Empty And CStr(LookUpEditPosition.EditValue) = String.Empty Then
        '    XtraMessageBox.Show("لا توجد سجلات")
        '    Exit Sub
        'End If

        Dim EmployeesTable As DataTable
        Dim DataTable As New DataTable
        Dim SQLString As String
        SQLString = "Select  DISTINCT USERID as EmpID ,EmployeeName, [AttPlane] from AttCHECKINOUT,EmployeesData
            where (DontCheckInOut IS NULL OR DontCheckInOut=0) and AttCHECKINOUT.userid = EmployeesData.EmployeeID "
        '    SQLString = "Select  EmployeeID as EmpID ,EmployeeName, AttPlane from EmployeesData
        ' where (DontCheckInOut IS NULL OR DontCheckInOut=0)  "

        If CheckEditCheckActive.Checked = False Then SQLString = SQLString + "and EmployeesData.Active = 1"
        If CStr(SearchLookUpEdit1.EditValue) IsNot Nothing And CStr(SearchLookUpEdit1.EditValue) <> String.Empty Then SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = '" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = '" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = '" & LookUpEditPosition.EditValue & "'"




        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then MsgBox("لا يوجد حركات") : SplashScreenManager1.CloseWaitForm() : Exit Sub
        Else
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then MsgBox("No Data") : SplashScreenManager1.CloseWaitForm() : Exit Sub
        End If


        EmployeesTable = sql.SQLDS.Tables(0)


        For j As Integer = 0 To EmployeesTable.Rows.Count - 1
            Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")
            If EmployeesTable.Rows(j).Item("AttPlane") Is Nothing Or IsDBNull(EmployeesTable.Rows(j).Item("AttPlane")) Then PlaneID = 0 Else PlaneID = EmployeesTable.Rows(j).Item("AttPlane")
            EmployeeName = EmployeesTable.Rows(j).Item("EmployeeName")
            DataTable.Merge(QueryData(EmpID))
        Next
        Summery = True

        GridControl1.DataSource = DataTable
        BandedGridView1.BestFitColumns()

        '  Grouping()
        '  BandedGridView1.Columns.GroupColumn = TileView1.Columns(GroupData)

        SplashScreenManager1.CloseWaitForm()
        '  Catch ex As Exception
        'SplashScreenManager1.CloseWaitForm()
        'MsgBox(ex.ToString)
        ' End Try


    End Sub

    Private Sub AttReportAndProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesPositions' table. You can move, or remove it, as needed.
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData' table. You can move, or remove it, as needed.
        '  Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        '   Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        ' Me.DateEdit1.DateTime = Today.AddDays(-20)
        Me.DateEdit2.DateTime = Today


        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt

        If GlobalVariables._SystemLanguage = "English" Then
            RadioGroup1.Visible = False
            LayoutControlItem15.Visibility = True
        End If

        '  BandedGridView1.CustomSummaryCalculate += New EventHandler(BandedGridView1_CustomSummaryCalculate)
        '   myButton.Click += New EventHandler(myButton_Click)

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
        '   BandedGridView1_CustomSummaryCalculate()
        '    BandedGridView1.CustomSummaryCalculate()
        '   Dim m As New DevExpress.Data.CustomSummaryEventArgs
        '    BandedGridView1_CustomSummaryCalculate(sender, m)




    End Sub

    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridView1.CustomSummaryCalculate
        If Summery = False Then Exit Sub
        '  MsgBox("df")
        Try

            Dim view As GridView = TryCast(sender, GridView)
            Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then e.TotalValue = TimeSpan.Zero

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
                ts = ts + CType(e.TotalValue, TimeSpan)
                e.TotalValue = ts
            End If

            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))

        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        ' MsgBox("df2")
    End Sub

    Private Sub RepositoryItemTimeSpanEdit4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Test()
        ' Define an interval of 1 day, 15+ hours.
        Dim interval As New TimeSpan(1, 15, 42, 45, 750)
        Console.WriteLine("Value of TimeSpan: {0}", interval)

        Console.WriteLine("{0:N5} hours, as follows:", interval.TotalHours)
        Console.WriteLine("   Hours:        {0,3}",
                          interval.Days * 24 + interval.Hours)
        Console.WriteLine("   Minutes:      {0,3}", interval.Minutes)
        Console.WriteLine("   Seconds:      {0,3}", interval.Seconds)
        Console.WriteLine("   Milliseconds: {0,3}", interval.Milliseconds)
    End Sub
    'Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
    '    Dim view As BandedGridView = sender
    '    If view Is Nothing Then
    '        Return
    '    End If
    '    If e.Column.Caption <> "FirstName" Then
    '        Return
    '    End If
    '    Dim cellValue As String = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns("LastName")).ToString()
    '    view.SetRowCellValue(e.RowHandle, view.Columns("FullName"), cellValue)
    'End Sub




    '    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As Object,
    'ByVal e As CustomColumnDisplayTextEventArgs) _
    'Handles GridView1.CustomColumnDisplayText
    '        Dim view As ColumnView = TryCast(sender, ColumnView)
    '        If e.Column.FieldName = "StartTime" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then

    '            Dim cc As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "StartTimeReal"))
    '            Dim dd As String = Convert.ToDecimal(e.Value)

    '            Select Case cc
    '                Case ""
    '                    e.Graphics.DrawImage(ImageIN, e.Bounds.Location)
    '                    e.DisplayText = "دخول"
    '                    Exit Select
    '                Case 1
    '                    e.DisplayText = String.Format(ciEUR, "{0:c}", price)
    '                    Exit Select
    '            End Select
    '        End If
    '    End Sub

    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles BandedGridView1.CustomDrawCell

        'Dim ImageIN As Image = My.Resources.User_Blue_icon
        'Dim ImageOut As Image = My.Resources.User_Red_icon
        'Dim ImageIN2 As Image = My.Resources.User_Green_icon
        'Dim ImageOut2 As Image = My.Resources.User_Orange_icon
        Dim EmptyTrans As Image = My.Resources.User_Red_icon
        Dim View As GridView = CType(sender, GridView)


        If e.Column.FieldName = "StartTimeReal" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTime"))
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal"))
            If category2 = String.Empty And category <> String.Empty Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                '  e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '   e.DisplayText = "انقر للتعديل"
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        If e.Column.FieldName = "EndTimeReal" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal"))
            If category2 = String.Empty And category <> String.Empty Then
                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                '  e.DisplayText = "..."
                e.Appearance.Options.CancelUpdate()
            End If
        End If

        'If e.Column.FieldName = "ElapseTime" Then
        '    Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal"))
        '    Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal"))
        '    Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
        '    If category3 <> "" And (category2 = "" Or category = "") Then
        '        e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '        ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '        '  e.DisplayText = "..."
        '        e.Appearance.Options.CancelUpdate()
        '    End If
        'End If

        '        If e.Column.FieldName = "StartTimeReal1" Then
        '            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal1"))
        '            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal1"))
        '            Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
        '            Dim category4 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Duration1"))
        '            If category = "" And category2 = "" Then GoTo eend
        '            If category = "" Then
        '                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '                ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '                '  e.DisplayText = "..."
        '                e.Appearance.Options.CancelUpdate()
        'eend:       End If
        '        End If


        '        If e.Column.FieldName = "EndTimeReal1" Then
        '            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal1"))
        '            Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal1"))
        '            Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))
        '            Dim category4 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Duration1"))
        '            If category = "" And category2 = "" Then GoTo eend2
        '            If category2 = "" Then
        '                e.Cache.FillRectangle(Color.Salmon, e.Bounds)
        '                ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
        '                '  e.DisplayText = "..."
        '                e.Appearance.Options.CancelUpdate()
        'eend2:      End If
        '        End If

        For j As Integer = 1 To 5
            If e.Column.FieldName = "EndTimeReal" & j Or e.Column.FieldName = "StartTimeReal" & j Then
                Dim category1 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("StartTimeReal" & j))
                Dim category2 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTimeReal" & j))
                Dim category3 As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EndTime"))

                If category1 = String.Empty And category2 = String.Empty Then GoTo eend3
                If (category1 = String.Empty Or category2 = String.Empty) And category3 <> String.Empty Then
                    e.Cache.FillRectangle(Color.Salmon, e.Bounds)
                    ' e.Graphics.DrawImage(EmptyTrans, e.Bounds.Location)
                    '  e.DisplayText = "..."
                    e.Appearance.Options.CancelUpdate()
eend3:          End If
            End If
        Next
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            'MsgBox(BandedGridView1.GetFocusedRowCellValue("TransDate"))
            'If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTime")) Then
            '    MsgBox(BandedGridView1.GetFocusedRowCellValue("StartTime"))
            'Else
            '    MsgBox("NOTHING")
            'End If
            Dim SrartTime As DateTime
            Dim EndTime As DateTime

            If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTime")) Then
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (Format(BandedGridView1.GetFocusedRowCellValue("StartTime"), "HH:mm"))
                EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (Format(BandedGridView1.GetFocusedRowCellValue("EndTime"), "HH:mm"))
            Else
                SrartTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (Format(BandedGridView1.GetFocusedRowCellValue("StartRealTime"), "HH:mm"))
                EndTime = (Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")) & " " & (Format(BandedGridView1.GetFocusedRowCellValue("EndRealTime"), "HH:mm"))
            End If

            Dim ElapseTimeTemp As TimeSpan
            Dim ElapseHours As Double

            If EndTime > SrartTime Then
                ElapseTimeTemp = (EndTime).Subtract(SrartTime)
                ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
            Else
                ElapseTimeTemp = EndTime.AddDays(1).Subtract(SrartTime)
                ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
            End If


            EndTime = EndTime.AddMinutes(-1)
            If EndTime < SrartTime Then EndTime = EndTime.AddDays(1)

            '   My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue

            My.Forms.AttEditTrans.DateEdit1.DateTime = SrartTime.AddHours(-ElapseHours)
            My.Forms.AttEditTrans.DateEdit2.DateTime = EndTime.AddHours(ElapseHours)


            If BandedGridView1.GetFocusedRowCellValue("EmpID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")

            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If


            If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
                My.Forms.AttEditTrans.TimeEdit1.Time = Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If

            If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
                My.Forms.AttEditTrans.TimeEdit2.Time = Format(BandedGridView1.GetFocusedRowCellValue("EndTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
            End If

            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True
            '  My.Forms.AttEditTrans.DateEdit1.ReadOnly = True

            AttEditTrans.DateEdit3.DateTime = CDate(BandedGridView1.GetFocusedRowCellValue("TransDate").ToString)

            AttEditTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            AttEditTrans.ShowDialog()
        End Try



    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            My.Forms.AddVocation.LookUpEditEmployees.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")
            AddVocation.Show()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged

        'Try

        '    Dim SQLString As String = "Select [AttPlane] from [EmployeesData] where [EmployeeID]=  " & SearchLookUpEdit1.EditValue
        '    Dim sql As New SQLControl
        '    sql.SqlTrueTimeRunQuery(SQLString)

        '    PlaneID = CInt(sql.SQLDS.Tables(0).Rows(0).Item("AttPlane"))

        'Catch ex As Exception

        'End Try




    End Sub
    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Try
            My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = Me.SearchLookUpEdit1.EditValue

            '    My.Forms.AttEditTrans.DateEdit1.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd")

            If BandedGridView1.GetFocusedRowCellValue("TransInID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransInID")
                My.Forms.AttEditTrans.TimeEdit1.Time = Format(BandedGridView1.GetFocusedRowCellValue("StartTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDINTextEdit.Text = 0
            End If
            If BandedGridView1.GetFocusedRowCellValue("TransOutID").ToString <> String.Empty Then
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = BandedGridView1.GetFocusedRowCellValue("TransOutID")
                My.Forms.AttEditTrans.TimeEdit2.Time = Format(BandedGridView1.GetFocusedRowCellValue("EndTimeReal"), "HH:mm")
            Else
                My.Forms.AttEditTrans.TransIDOutTextEdit.Text = 0
            End If

            My.Forms.AttEditTrans.SearchLookUpEdit1.ReadOnly = True
            '   My.Forms.AttEditTrans.DateEdit1.ReadOnly = True

            My.Forms.AttEditTrans.DateEdit3.DateTime = Format(BandedGridView1.GetFocusedRowCellValue("TransDate"), "yyyy-MM-dd") & " 00:00:00"

            AttEditTrans.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            AttEditTrans.ShowDialog()
        End Try
    End Sub



    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {String.Empty, String.Empty, "Pages: [Page # of Pages #]"})
        If GlobalVariables._SystemLanguage = "Arabic" Then
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير مغاردات الموظف : " & SearchLookUpEdit1.Text)
        Else
            TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" Leaves Reports : " & SearchLookUpEdit1.Text)
        End If

        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
    End Sub


    Private Function QueryData(EmpID As String) As DataTable




        '    If (SearchLookUpEdit1.EditValue = 0) Then MsgBox("الرجاء اختيار موظف") : Exit Sub

        '    Dim EmpID As String = SearchLookUpEdit1.EditValue


        Dim PlaneTable As New DataTable

        Dim ListDays As New DataTable
        Dim DD As New DataColumn With {
            .AllowDBNull = False,
            .Unique = True
        }
        DD = ListDays.Columns.Add("TransDate", GetType(DateTime))
        ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("PlaneID", GetType(Integer))
        ListDays.Columns.Add("EmpID", GetType(String))
        ListDays.Columns.Add("EmployeeName", GetType(String))
        ListDays.Columns.Add("StartTime", GetType(DateTime))
        ListDays.Columns.Add("EndTime", GetType(DateTime))
        ListDays.Columns.Add("StartTimeReal", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal", GetType(DateTime))
        ListDays.Columns.Add("LateSpan", GetType(TimeSpan))
        ListDays.Columns.Add("LeaveSpan", GetType(TimeSpan))
        ListDays.Columns.Add("BonusSpanBeforeBeg", GetType(TimeSpan))
        ListDays.Columns.Add("BonusSpanAfterEnd", GetType(TimeSpan))
        ListDays.Columns.Add("ElapseTime", GetType(TimeSpan))
        ListDays.Columns.Add("ElapseTimePlane", GetType(TimeSpan))
        ListDays.Columns.Add("LateMinutes", GetType(Integer))
        ListDays.Columns.Add("EarlyMinutes", GetType(Integer))
        ListDays.Columns.Add("TransInID", GetType(Integer))
        ListDays.Columns.Add("TransOutID", GetType(Integer))
        ListDays.Columns.Add("EditedType", GetType(String))

        ListDays.Columns.Add("StartTimeReal1", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal1", GetType(DateTime))

        ListDays.Columns.Add("StartTimeReal2", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal2", GetType(DateTime))

        ListDays.Columns.Add("StartTimeReal3", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal3", GetType(DateTime))

        ListDays.Columns.Add("StartTimeReal4", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal4", GetType(DateTime))

        ListDays.Columns.Add("StartTimeReal5", GetType(DateTime))
        ListDays.Columns.Add("EndTimeReal5", GetType(DateTime))

        ListDays.Columns.Add("Duration1", GetType(TimeSpan))
        ListDays.Columns.Add("Duration2", GetType(TimeSpan))
        ListDays.Columns.Add("Duration3", GetType(TimeSpan))
        ListDays.Columns.Add("Duration4", GetType(TimeSpan))
        ListDays.Columns.Add("Duration5", GetType(TimeSpan))

        ListDays.Columns.Add("TotalLeaves", GetType(TimeSpan))


        ListDays.Columns.Add("JobLeaveIn1", GetType(DateTime))
        ListDays.Columns.Add("JobLeaveOut1", GetType(DateTime))
        ListDays.Columns.Add("DurationJobLeave1", GetType(TimeSpan))

        ListDays.Columns.Add("JobLeaveIn2", GetType(DateTime))
        ListDays.Columns.Add("JobLeaveOut2", GetType(DateTime))
        ListDays.Columns.Add("DurationJobLeave2", GetType(TimeSpan))

        ListDays.Columns.Add("JobLeaveIn3", GetType(DateTime))
        ListDays.Columns.Add("JobLeaveOut3", GetType(DateTime))
        ListDays.Columns.Add("DurationJobLeave3", GetType(TimeSpan))

        ListDays.Columns.Add("JobLeaveIn4", GetType(DateTime))
        ListDays.Columns.Add("JobLeaveOut4", GetType(DateTime))
        ListDays.Columns.Add("DurationJobLeave4", GetType(TimeSpan))

        ListDays.Columns.Add("JobLeaveIn5", GetType(DateTime))
        ListDays.Columns.Add("JobLeaveOut5", GetType(DateTime))
        ListDays.Columns.Add("DurationJobLeave5", GetType(TimeSpan))

        ListDays.Columns.Add("TotalJobLeaves", GetType(TimeSpan))


        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim CurrDName As String = Format(CurrD, "dddd")
        Dim ElapseTimeTemp As TimeSpan
        Dim ElapseHours As Double
        ' Dim Inte


        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)


        While (CurrD < endP)
            CurrD = CurrD.AddDays(1)
            ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New System.Globalization.CultureInfo("ar-AE")), PlaneID, EmpID, EmployeeName)
        End While

        Dim sql As New SQLControl

        Dim SqlString As String = "Select * from [AttPlane] where [PlaneID] = " & PlaneID



        sql.SqlTrueTimeRunQuery(SqlString)
        PlaneTable = sql.SQLDS.Tables(0)


        Dim ListDaysRows As Integer
        '  Dim ToRealTime2, FromRealTime2 As TimeSpan
        For ListDaysRows = 0 To ListDays.Rows.Count - 1
            Dim ss As DataView = New DataView(PlaneTable,
            "PlaneID = " & PlaneID & " and DayName ='" & Format(ListDays.Rows(ListDaysRows).Item("TransDate"), "dddd").ToString & "'", "ID", DataViewRowState.CurrentRows)
            If ss.Count > 0 Then
                ListDays.Rows(ListDaysRows).Item("StartTime") = ss(0)("StartTime").ToString
                ListDays.Rows(ListDaysRows).Item("EndTime") = ss(0)("EndTime").ToString
                ListDays.Rows(ListDaysRows).Item("LateMinutes") = ss(0)("LateMinutes").ToString
                ListDays.Rows(ListDaysRows).Item("EarlyMinutes") = ss(0)("EarlyMinutes").ToString



            End If
        Next


        Dim TempLateTimeSpan As TimeSpan
        Dim TempAllowLateTimeSpan As TimeSpan
        Dim TempleaveTimeSpan As TimeSpan
        Dim TempAllowleaveTimeSpan As TimeSpan
        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        Dim dr As SqlDataReader
        Dim FromDate, ToDate As String
        '  Dim ToRealTime, FromRealTime As TimeSpan
        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1

            If Not IsDBNull(ListDays.Rows(i).Item("StartTime")) Or Not IsDBNull(ListDays.Rows(i).Item("EndTime")) Then
                Dim EEnd, SStart As DateTime
                EEnd = Convert.ToDateTime(ListDays.Rows(i).Item("EndTime"))
                SStart = Convert.ToDateTime(ListDays.Rows(i).Item("StartTime"))

                If EEnd > SStart Then
                    ElapseTimeTemp = (EEnd).Subtract(SStart)
                    ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
                Else
                    ElapseTimeTemp = EEnd.AddDays(1).Subtract(SStart)
                    ElapseHours = (24 - CInt(ElapseTimeTemp.TotalHours)) / 2
                End If

                '   MsgBox(ElapseHours)
            End If
            '   FromDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            '   ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            If Not IsDBNull(ListDays.Rows(i).Item("StartTime")) Then
                FromDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & Format(ListDays.Rows(i).Item("StartTime"), "HH:mm")
                FromDate = Format(Convert.ToDateTime(FromDate).AddHours(-ElapseHours), "yyyy-MM-dd HH:mm")
            Else
                FromDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"
            End If

            If Not IsDBNull(ListDays.Rows(i).Item("EndTime")) Then
                If CDate(ListDays.Rows(i).Item("EndTime")) > CDate(ListDays.Rows(i).Item("StartTime")) Then
                    ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & Format(ListDays.Rows(i).Item("EndTime"), "HH:mm")
                    ToDate = Format(Convert.ToDateTime(ToDate).AddHours(ElapseHours).AddMinutes(-1), "yyyy-MM-dd HH:mm")
                Else
                    ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " " & Format(ListDays.Rows(i).Item("EndTime"), "HH:mm")
                    ToDate = Format(Convert.ToDateTime(ToDate).AddHours(ElapseHours + 24).AddMinutes(-1), "yyyy-MM-dd HH:mm")
                End If
                '' If CDate(ListDays.Rows(i).Item("EndTime")) > CDate(ListDays.Rows(i).Item("EndTime")) Then MsgBox("")
            Else
                ToDate = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 23:59:59"
            End If





            Dim SQLStringRealIn1 As String = "Select CHECKTIME,[ID] as TransInID,EditedType,USERID from [AttCHECKINOUT] where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS  
                                                        and [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate & "'  and '" & ToDate & "')   order by CHECKTIME "
            '  MsgBox(SQLStringRealIn1)
            mycommand = New SqlCommand(SQLStringRealIn1, myconnection)
            dr = mycommand.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                ListDays.Rows(i).Item("StartTimeReal") = dr.Item("CHECKTIME")
                dr.Close()
            Else
                dr.Close()
            End If

            Dim SQLStringRealOut1 As String = "Select CHECKTIME,[ID] as TransOutID,EditedType,USERID from [AttCHECKINOUT] where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS 
                                        and [USERID] = " & EmpID & " and ( CHECKTIME between '" & FromDate & "'  and '" & ToDate & "')  order by CHECKTIME desc "

            ' MsgBox(SQLStringRealOut1)
            mycommand = New SqlCommand(SQLStringRealOut1, myconnection)
            dr = mycommand.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                ListDays.Rows(i).Item("EndTimeReal") = dr.Item("CHECKTIME")
                dr.Close()
            Else
                dr.Close()
            End If

            Dim TTODate As String = ToDate
            Dim FFromDate As String = FromDate

            Try
                If Not IsDBNull(ListDays.Rows(i).Item("EndTimeReal")) Then TTODate = Format(CDate(ListDays.Rows(i).Item("EndTimeReal")).AddMinutes(-1), "yyyy-MM-dd HH:mm")
                If Not IsDBNull(ListDays.Rows(i).Item("StartTimeReal")) Then FFromDate = Format(CDate(ListDays.Rows(i).Item("StartTimeReal")).AddMinutes(1), "yyyy-MM-dd HH:mm")
            Catch ex As Exception

            End Try

            ListDays.Rows(i).Item("TotalLeaves") = TimeSpan.Zero
            Dim TotalLeaves As TimeSpan = TimeSpan.Zero

            Try
                Dim j As Integer = 0
                For j = 1 To 5

                    Dim SQLString2 As String = " SELECT     Row, CHECKTIME,[ID] as TransInID,EditedType,USERID   ,[CHECKTYPE]
                                                 FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
		                                                    FROM        [AttCHECKINOUT] 
		                                                    where [CHECKTYPE]='I' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FFromDate & "'  and '" & TTODate & "')   )  cc
		                                         where row = " & j

                    mycommand = New SqlCommand(SQLString2, myconnection)
                    dr = mycommand.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        ListDays.Rows(i).Item("StartTimeReal" & j) = dr.Item("CHECKTIME")
                        ListDays.Rows(i).Item("TransInID") = dr.Item("TransInID")
                        ListDays.Rows(i).Item("EditedType") = dr.Item("EditedType")
                        dr.Close()
                    Else
                        dr.Close()
                    End If




                    Dim SQLString3 As String = " SELECT Row, CHECKTIME,[ID] as TransOutID,EditedType,USERID   ,[CHECKTYPE]
                                                 FROM 		(SELECT ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
		                                                    FROM [AttCHECKINOUT] 
		                                                    where [CHECKTYPE]='O' COLLATE Latin1_General_CS_AS and  [USERID] = " & EmpID & " and ( CHECKTIME between '" & FFromDate & "'  and '" & TTODate & "')   )  cc
		                                         where row = " & j

                    mycommand = New SqlCommand(SQLString3, myconnection)
                    dr = mycommand.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        ListDays.Rows(i).Item("EndTimeReal" & j) = dr.Item("CHECKTIME")
                        ListDays.Rows(i).Item("TransOutID") = dr.Item("TransOutID")
                        ListDays.Rows(i).Item("EditedType") = dr.Item("EditedType")
                        dr.Close()
                    Else
                        dr.Close()
                    End If


                    '   If IsDBNull((ListDays.Rows(i).Item("TotalLeaves").ToString)) Then ListDays.Rows(i).Item("TotalLeaves") = TimeSpan.Zero

                    If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("EndTimeReal" & j)) Or (Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("StartTimeReal" & j))) Then
                        ListDays.Rows(i).Item("Duration" & j) = (CDate(Format(ListDays.Rows(i).Item("StartTimeReal" & j), "HH:mm"))).Subtract(CDate(Format(ListDays.Rows(i).Item("EndTimeReal" & j), "HH:mm")))
                        TotalLeaves = TotalLeaves + ListDays.Rows(i).Item("Duration" & j)
                        ListDays.Rows(i).Item("TotalLeaves") = TotalLeaves

                    End If

                Next j
            Catch ex As Exception
                '    MsgBox(ex.ToString)
            End Try



            Try
                ListDays.Rows(i).Item("TotalJobLeaves") = TimeSpan.Zero
                Dim TotalJobLeaves As TimeSpan = TimeSpan.Zero

                Dim h As Integer
                For h = 1 To 5

                    '''' بيانات المغادرات الرسمية
                    Dim SQLStringInJob As String = " SELECT     Row, CHECKTIME,[ID] as TransInID,EditedType,USERID   ,[CHECKTYPE]
                                                 FROM 	    (SELECT     ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
		                                                    FROM        [AttCHECKINOUT] 
		                                                    where [CHECKTYPE]='i' COLLATE Latin1_General_CS_AS and  [USERID] = 1 and ( CHECKTIME between '" & FFromDate & "'  and '" & TTODate & "')   )  cc
		                                         where row = " & h

                    mycommand = New SqlCommand(SQLStringInJob, myconnection)
                    dr = mycommand.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        ListDays.Rows(i).Item("JobLeaveIn" & h) = dr.Item("CHECKTIME")
                        dr.Close()
                    Else
                        dr.Close()
                    End If




                    Dim SQLStringOutJob As String = " SELECT Row, CHECKTIME,[ID] as TransOutID,EditedType,USERID   ,[CHECKTYPE]
                                                 FROM 		(SELECT ROW_NUMBER() OVER(ORDER BY [CHECKTIME] ) AS Row, * 
		                                                    FROM [AttCHECKINOUT] 
		                                                    where [CHECKTYPE]='o' COLLATE Latin1_General_CS_AS and  [USERID] = 1 and ( CHECKTIME between '" & FFromDate & "'  and '" & TTODate & "')   )  cc
		                                         where row = " & h

                    mycommand = New SqlCommand(SQLStringOutJob, myconnection)
                    dr = mycommand.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        ListDays.Rows(i).Item("JobLeaveOut" & h) = dr.Item("CHECKTIME")
                        dr.Close()
                    Else
                        dr.Close()
                    End If


                    '   If IsDBNull((ListDays.Rows(i).Item("TotalLeaves").ToString)) Then ListDays.Rows(i).Item("TotalLeaves") = TimeSpan.Zero

                    If Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("JobLeaveOut" & h)) Or (Not IsDBNull(BandedGridView1.GetFocusedRowCellValue("JobLeaveIn" & h))) Then
                        ListDays.Rows(i).Item("DurationJobLeave" & h) = (CDate(Format(ListDays.Rows(i).Item("JobLeaveIn" & h), "HH:mm"))).Subtract(CDate(Format(ListDays.Rows(i).Item("JobLeaveOut" & h), "HH:mm")))
                        TotalJobLeaves = TotalJobLeaves + ListDays.Rows(i).Item("DurationJobLeave" & h)
                        ListDays.Rows(i).Item("TotalJobLeaves") = TotalJobLeaves
                    End If

                    '' انتهاء المغادرات الرسمية






                Next h
            Catch ex As Exception
                '   MsgBox(ex.ToString)
            End Try


            Try
                If CDate(Format(ListDays.Rows(i).Item("EndTime"), "HH:mm")) > CDate(Format(ListDays.Rows(i).Item("StartTime"), "HH:mm")) Then
                    ListDays.Rows(i).Item("ElapseTimePlane") = CDate(Format(ListDays.Rows(i).Item("EndTime"), "HH:mm")).Subtract(CDate(Format(ListDays.Rows(i).Item("StartTime"), "HH:mm")))
                Else
                    ListDays.Rows(i).Item("ElapseTimePlane") = (CDate(Format(ListDays.Rows(i).Item("EndTime"), "HH:mm")).AddDays(1)).Subtract(CDate(Format(ListDays.Rows(i).Item("StartTime"), "HH:mm")))

                End If

            Catch ex As Exception

            End Try




            Try
                Dim StartTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("StartTimeReal"), "HH:mm"))
                Dim StartTime As DateTime = CDate(Format(ListDays.Rows(i).Item("StartTime"), "HH:mm"))
                Dim EndTimeReal As DateTime = CDate(Format(ListDays.Rows(i).Item("EndTimeReal"), "HH:mm"))
                Dim EndTime As DateTime = CDate(Format(ListDays.Rows(i).Item("EndTime"), "HH:mm"))


                If StartTimeReal.TimeOfDay >= StartTime.TimeOfDay Then
                    TempLateTimeSpan = StartTimeReal.Subtract(StartTime)
                    TempAllowLateTimeSpan = TimeSpan.FromMinutes(CInt(ListDays.Rows(i).Item("LateMinutes")))
                    If CheckEditAllows.CheckState = 1 And TempAllowLateTimeSpan.Subtract(TempLateTimeSpan) >= TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LateSpan") = TimeSpan.Zero
                    ElseIf CheckEditAllows.CheckState = 1 And TempAllowLateTimeSpan.Subtract(TempLateTimeSpan) < TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LateSpan") = TempLateTimeSpan
                    ElseIf CheckEditAllows.CheckState = 0 Then
                        ListDays.Rows(i).Item("LateSpan") = StartTimeReal.Subtract(StartTime)
                    End If
                Else
                    ListDays.Rows(i).Item("BonusSpanBeforeBeg") = StartTime.Subtract(StartTimeReal)
                End If


                If EndTimeReal.TimeOfDay >= EndTime.TimeOfDay Then
                    ListDays.Rows(i).Item("BonusSpanAfterEnd") = EndTimeReal.Subtract(EndTime)
                Else
                    TempleaveTimeSpan = EndTime.Subtract(EndTimeReal)
                    TempAllowleaveTimeSpan = TimeSpan.FromMinutes(CInt(ListDays.Rows(i).Item("EarlyMinutes")))
                    If CheckEditAllows.CheckState = 1 And TempleaveTimeSpan.Subtract(TempAllowleaveTimeSpan) > TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeaveSpan") = TempleaveTimeSpan
                    ElseIf CheckEditAllows.CheckState = 1 And TempleaveTimeSpan.Subtract(TempAllowleaveTimeSpan) <= TimeSpan.Zero Then
                        ListDays.Rows(i).Item("LeaveSpan") = TimeSpan.Zero
                    ElseIf CheckEditAllows.CheckState = 0 Then
                        ListDays.Rows(i).Item("LeaveSpan") = TempleaveTimeSpan
                    End If
                End If


                If EndTimeReal.TimeOfDay >= StartTimeReal.TimeOfDay Then
                    ListDays.Rows(i).Item("ElapseTime") = EndTimeReal.Subtract(StartTimeReal)
                Else
                    ListDays.Rows(i).Item("ElapseTime") = (EndTimeReal.AddDays(1)).Subtract(StartTimeReal)
                End If



            Catch ex As Exception
                '  MsgBox(ex.ToString)
            End Try  ' كود حساب التاخير الصباحي المسائي


        Next

        myconnection.Close()


        QueryData = ListDays



    End Function


    Private Sub CheckSummery_CheckedChanged(sender As Object, e As EventArgs)
        '    CType(Me.BandedGridView1.Columns("City"), GridViewDataColumn).GroupBy()
        '  ASPxGridView1.GroupBy(ASPxGridView1.Columns("Country"), 0)
    End Sub

    Private Sub LookUpEditBranch_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditBranch.EditValueChanged

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged

        Grouping()

    End Sub


    Private Sub Grouping()

        BandedGridView1.BeginSort()

        Summery = True

        Try

            BandedGridView1.ClearGrouping()
            Select Case RadioGroup1.EditValue

                Case 1
                    '  TextEdit1.Text = ""
                    BandedGridView1.Columns("EmployeeName").GroupIndex = 0
                    '   BandedGridView1.Columns("TransDate").GroupIndex = -1
                 '   BandedGridView1.Columns("TransDay").GroupIndex = -1
                Case 2

                    '  BandedGridView1.Columns("EmployeeName").GroupIndex = -1
                    BandedGridView1.Columns("TransDate").GroupIndex = 0
                   ' BandedGridView1.Columns("TransDay").GroupIndex = -1
                Case 3

                    '  BandedGridView1.Columns("EmployeeName").GroupIndex = -1
                    '  BandedGridView1.Columns("TransDate").GroupIndex = -1
                    BandedGridView1.Columns("TransDay").GroupIndex = -0
            End Select
        Catch ex As Exception

        Finally
            BandedGridView1.EndSort()

        End Try
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        Dim result As TimeSpan
        '  MsgBox(BandedGridView1.RowCount)
        Dim vv As TimeSpan
        For i = 0 To BandedGridView1.RowCount - 1


            '   Try


            '   MsgBox(BandedGridView1.GetRowCellValue(i, BandedGridView1.Columns("ElapseTime").ToString))
            vv = BandedGridView1.GetRowCellValue(i, BandedGridView1.Columns("ElapseTime"))
            '   MsgBox(VV.ToString)

            '   MsgBox(VV.TotalHours)
            vv = vv + vv

            MsgBox(vv.ToString)






            '\  TextEdit1.Text = VV.TotalDays
            '    TextEdit2.Text = VV.TotalMinutes

            '  result = VV
            'MsgBox("VV.string" & VV.ToString)
            'MsgBox("vv.days" & VV.Days)
            ' MsgBox("vv.hours" & VV.TotalHours)
            '   MsgBox("{0} hours {1} minutes", VV.TotalHours, VV.Minutes)
            '   Catch ex As Exception

            '  End Try
        Next


        Dim dd As Integer = result.Days

        Dim hh As Integer = result.Hours

        Dim mm As Integer = result.Minutes

        Dim ss As Integer = result.Seconds

        MsgBox(String.Format("{0}:{1}:{2}:{3}", dd, hh, mm, ss))

        '   MsgBox(result.TotalHours)
        '  Dim x As New TimeSpan(0, 0, 3600)
        '   x = String.Format("{0}hr:{1}min", CInt(Math.Truncate(x.TotalHours)), x.Minutes)
        '  MsgBox(x)
        'Try

        '    Dim view As GridView = TryCast(sender, GridView)
        '    Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)
        '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then e.TotalValue = TimeSpan.Zero
        '    If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
        '        Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
        '        ts = ts + CType(e.TotalValue, TimeSpan)
        '        e.TotalValue = ts
        '    End If
        'Catch ex As Exception

        'End Try


        ' Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
        'ts = ts + CType(e.TotalValue, TimeSpan)
        'e.TotalValue = ts

    End Sub

    Private Sub SpinEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SpinEdit1.EditValueChanged
        If SpinEdit1.Value >= 0 AndAlso SpinEdit1.IsHandleCreated Then
            'Do the work


            If SpinEdit1.Text = 1 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = False : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 2 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = False : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 3 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = False : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 4 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = False
            If SpinEdit1.Text = 5 Then Me.LeaveBand1.Visible = True : Me.LeaveBand2.Visible = True : Me.LeaveBand3.Visible = True : Me.LeaveBand4.Visible = True : Me.LeaveBand5.Visible = True

            If SpinEdit1.Text = 1 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = False : Me.LeaveJobBand3.Visible = False : Me.LeaveJobBand4.Visible = False : Me.LeaveJobBand5.Visible = False
            If SpinEdit1.Text = 2 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = False : Me.LeaveJobBand4.Visible = False : Me.LeaveJobBand5.Visible = False
            If SpinEdit1.Text = 3 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = True : Me.LeaveJobBand4.Visible = False : Me.LeaveJobBand5.Visible = False
            If SpinEdit1.Text = 4 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = True : Me.LeaveJobBand4.Visible = True : Me.LeaveJobBand5.Visible = False
            If SpinEdit1.Text = 5 Then Me.LeaveJobBand1.Visible = True : Me.LeaveJobBand2.Visible = True : Me.LeaveJobBand3.Visible = True : Me.LeaveJobBand4.Visible = True : Me.LeaveJobBand5.Visible = True


            '  BandedGridView1.BestFitColumns()

            Using g = GridControl1.CreateGraphics()

                For Each band As DevExpress.XtraGrid.Views.BandedGrid.GridBand In BandedGridView1.Bands
                    band.MinWidth = CInt(g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width)
                Next
            End Using


            BandedGridView1.BestFitColumns()
        End If
    End Sub


    Private Sub BestFil(ByVal gridBand As GridBand)
        gridBand.View.BeginUpdate()
        For Each column As BandedGridColumn In gridBand.Columns
            column.BestFit()
        Next column
        gridBand.View.EndUpdate()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    'Private Sub LookUpEdit1_ProcessNewValue(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles LookUpEdit1.ProcessNewValue
    '    If e.DisplayValue = String.Empty Then
    '        LookUpEdit1.EditValue = Nothing
    '    End If
    'End Sub
End Class