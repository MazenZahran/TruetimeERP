Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports System.ComponentModel



Public Class AttReportAndProcessByHoures

    Dim PlaneID As Integer
    Dim EmployeeName As String
    Dim Summery As Boolean
    Dim _FormType As String



    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateData()
    End Sub

    Private Sub UpdateData()
        GridControl1.DataSource = String.Empty
        Summery = False


        SplashScreenManager1.ShowWaitForm()
        SplashScreenManager1.SetWaitFormCaption("جاري تحضير بيانات التقرير...")

        Dim EmployeesTable As DataTable
        Dim DataTable As New DataTable
        Dim SQLString As String
        SQLString = "Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane] from EmployeesData
            where (DontCheckInOut IS NULL OR DontCheckInOut=0)  "

        If CheckEditCheckActive.Checked = True Then SQLString = SQLString + "and EmployeesData.Active = 1"
        If CStr(SearchLookUpEdit1.EditValue) IsNot Nothing And CStr(SearchLookUpEdit1.EditValue) <> 0 Then SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
        If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
        If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
        If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"

        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then MsgBox("لا يوجد حركات") : SplashScreenManager1.CloseWaitForm() : Exit Sub
        Else
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then MsgBox("No Data Found") : SplashScreenManager1.CloseWaitForm() : Exit Sub
        End If


        EmployeesTable = sql.SQLDS.Tables(0)


        For j As Integer = 0 To EmployeesTable.Rows.Count - 1
            If Not IsDBNull(EmployeesTable.Rows(j).Item("EmpID")) Then
                Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")
                EmployeeName = EmployeesTable.Rows(j).Item("EmployeeName")
                DataTable.Merge(QueryData(EmpID))
            End If
        Next
        Summery = True

        GridControl1.DataSource = DataTable

        BandedGridView1.BestFitColumns()
        ' GridBand1.Width = GridControl1.Width / 2
        'If SearchLookUpEdit1.EditValue = 0 Or IsNothing(SearchLookUpEdit1.EditValue) Then
        '    ColEmpID.Visible = True
        '    CollEmployeeName.Visible = True
        'Else
        '    ColEmpID.Visible = False
        '    CollEmployeeName.Visible = False
        'End If

        '    BandedGridView1.BestFitColumns()

        SplashScreenManager1.CloseWaitForm()

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


        Me.KeyPreview = True

        'If _FormType = "Dawam" Then
        '    '  CheckEdit1.Checked = True
        '    ' gridBand7.Visible = False
        '    ' LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '    Me.Text = "تقرير الدوام بالساعة"
        '    If GlobalVariables._SystemLanguage = "English" Then
        '        Me.Text = "Attendant Shift Report"
        '    End If

        '    ' SimpleButton1.Visible = False
        'ElseIf _FormType = "Rawateb" Then
        '    ' CheckEdit1.Checked = False
        '    ' gridBand7.Visible = True
        '    ' LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    Me.Text = "تقرير الرواتب بالساعة"
        'Else
        '    MsgBox("Error No Defined Form Type")
        'End If


        If GlobalVariables._SystemLanguage = "English" Then
            ColEnglishStatus.Visible = True
            ColAttStatus.Visible = False
        Else
            ColEnglishStatus.Visible = False
            ColAttStatus.Visible = True
        End If


    End Sub

    Private Sub BandedGridView1_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BandedGridView1.CustomSummaryCalculate

        If Summery = False Then Exit Sub
        '  MsgBox("df")
        Try

            Dim view As GridView = TryCast(sender, GridView)
            Dim summaryID As Integer = Convert.ToInt32((TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)).Tag)


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                If summaryID < 30 Then
                    e.TotalValue = TimeSpan.Zero
                ElseIf summaryID = 100 Or summaryID = 101 Or summaryID = 102 Then
                    e.TotalValue = 0
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                If summaryID < 30 Then
                    Dim ts As TimeSpan = TimeSpan.Parse(e.FieldValue.ToString())
                    ts = ts + CType(e.TotalValue, TimeSpan)
                    e.TotalValue = ts
                ElseIf summaryID = 100 Or summaryID = 200 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "عطلة" Then
                        e.TotalValue = e.TotalValue + 1
                        'Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "UnitsInStock"))
                    End If
                ElseIf summaryID = 101 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "غياب" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                ElseIf summaryID = 102 Then
                    If BandedGridView1.GetRowCellValue(e.RowHandle, "AttStatus") = "دوام" Then
                        e.TotalValue = e.TotalValue + 1
                    End If
                End If
            End If


            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                If summaryID < 30 Then
                    e.TotalValue = ((Int(e.TotalValue.TotalHours) & ":" & CInt(e.TotalValue.Minutes)))
                End If
            End If




        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
        ' MsgBox("df2")
    End Sub


    Private Sub Attreportandprocessbyhours_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            UpdateData()
        ElseIf e.KeyCode = Keys.Insert Then
            InsertSub()
        ElseIf e.KeyCode = Keys.F12 Then
            ShowPrint()
        End If
    End Sub

    Private Sub InsertSub()
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
            '  MsgBox(ex.ToString)
        Finally
            AttEditTrans.ShowDialog()
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ShowPrint()
    End Sub

    Private Sub ShowPrint()
        If GridControl1.IsPrintingAvailable = False Then Exit Sub

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If BandedGridView1.RowCount = 0 Then MsgBox("التقرير فارغ") : Exit Sub
        Else
            If BandedGridView1.RowCount = 0 Then MsgBox("Empty Report") : Exit Sub
        End If


        GridControl1.ShowPrintPreview()
    End Sub



    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try

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

            My.Forms.AttEditTrans.SearchLookUpEdit1.EditValue = BandedGridView1.GetFocusedRowCellValue("EmpID")

            My.Forms.AttEditTrans.DateEdit1.DateTime = SrartTime.AddHours(-ElapseHours)
            My.Forms.AttEditTrans.DateEdit2.DateTime = EndTime.AddHours(ElapseHours)


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


    Private Sub BandedGridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles BandedGridView1.PrintInitialize

        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()

        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)

        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {String.Empty, String.Empty, "Pages: [Page # of Pages #]"})
        If CStr(SearchLookUpEdit1.EditValue) IsNot Nothing And CStr(SearchLookUpEdit1.EditValue) <> 0 Then

            If GlobalVariables._SystemLanguage = "Arabic" Then
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة : " & SearchLookUpEdit1.Text)
            Else
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("Attendante Report By Hour : " & SearchLookUpEdit1.Text)
            End If


        Else
            If GlobalVariables._SystemLanguage = "Arabic" Then
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("تقرير دوام الموظف بالساعة  ")
            Else
                TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(" Attendante Report By Hour ")
            End If

        End If
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
    End Sub


    Private Function QueryData(EmpID As String) As DataTable
        Dim CheckInOutTable As New DataTable
        With CheckInOutTable
            .Columns.Add("TransDate", GetType(DateTime))
            .Columns.Add("TransDay", GetType(String))
            .Columns.Add("EmpID", GetType(String))
            .Columns.Add("EmployeeName", GetType(String))
            .Columns.Add("StartTimeReal", GetType(DateTime))
            .Columns.Add("EndTimeReal", GetType(DateTime))
            .Columns.Add("ElapseTime", GetType(TimeSpan))
            .Columns.Add("TransInID", GetType(Integer))
            .Columns.Add("TransOutID", GetType(Integer))
            .Columns.Add("EditedType", GetType(String))
        End With

        Try


            Dim DateFrom As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim DateTo As String = Format(DateEdit2.DateTime, "yyyy-MM-dd")



            Dim sql As New SQLControl
            Dim CheckInTimes As String
            Dim CheckInTimesTable As DataTable
            Dim SqlString As String = " SELECT DISTINCT 
                                                  CHECKTIME AS CheckINTimes, USERID, CHECKTYPE, ID As CheckInID
                                        FROM      AttCHECKINOUT
                                        WHERE     CHECKTIME between '" & DateFrom & " 00:00:00" & "' and '" & DateTo & " 23:59:59" & "' And USERID = '" & EmpID & "' and CHECKTYPE = 'I' COLLATE Latin1_General_CS_AS       
                                        ORDER BY  CheckINTimes, CHECKTYPE"

            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Function
            CheckInTimesTable = sql.SQLDS.Tables(0)

            Dim i As Integer
            For i = 0 To CheckInTimesTable.Rows.Count - 1

                CheckInTimes = CheckInTimesTable.Rows(i).Item("CheckINTimes")
                Dim CheckIn As String = Format(CDate(CheckInTimes), "yyyy-MM-dd HH:mm")
                Dim CheckOut As String = Format(CDate(CheckInTimes).AddHours(23.999), "yyyy-MM-dd HH:mm")
                Dim CheckOutSQL As String = "SELECT   [ID] As CheckOutID,CHECKTYPE,USERID,CHECKTIME FROM [AttCHECKINOUT] 
                                             Where    USERID= '" & EmpID & "'  and CHECKTIME between '" & CheckIn & "' And '" & CheckOut & "' 
                                                     and CHECKTYPE = 'O' COLLATE Latin1_General_CS_AS  
                                             Order By CHECKTIME, CHECKTYPE "

                sql.SqlTrueTimeRunQuery(CheckOutSQL)

                Dim ItemTransDate As Date
                Dim ItemStartTime, ItemEndTime As DateTime
                Dim ItemTransDay, ItemEmpID, ItemEmpName As String
                Dim ItemTransInID, ItemTransOutID As Integer
                Dim ElapseTime As TimeSpan
                If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                    ItemTransDate = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    ' ItemTransDay = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    If GlobalVariables._SystemLanguage = "Arabic" Then
                        ItemTransDay = ItemTransDate.ToString("dddd", New System.Globalization.CultureInfo("ar-AE"))
                    Else
                        ItemTransDay = ItemTransDate.ToString("dddd")
                    End If
                    ItemEmpID = EmpID
                    ItemEmpName = EmployeeName
                    ItemStartTime = Format(CDate(CheckInTimes), "HH:mm")
                    ItemEndTime = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("CHECKTIME")), "HH:mm")
                    ElapseTime = CDate(Format(sql.SQLDS.Tables(0).Rows(0).Item("CHECKTIME"), "yyyy-MM-dd HH:mm")).Subtract(CheckInTimes)
                    ItemTransInID = CheckInTimesTable.Rows(i).Item("CheckInID")
                    ItemTransOutID = sql.SQLDS.Tables(0).Rows(0).Item("CheckOutID")
                    CheckInOutTable.Rows.Add(ItemTransDate, ItemTransDay, ItemEmpID, ItemEmpName, ItemStartTime, ItemEndTime, ElapseTime, ItemTransInID, ItemTransOutID)

                Else
                    ItemTransDate = Format(CDate(CheckInTimes), "yyyy-MM-dd")
                    ItemTransDay = ItemTransDate.ToString("dddd", New System.Globalization.CultureInfo("ar-AE"))
                    ItemEmpID = EmpID
                    ItemEmpName = EmployeeName
                    ItemStartTime = Format(CDate(CheckInTimes), "HH:mm")
                    ItemTransInID = CheckInTimesTable.Rows(i).Item("CheckInID")
                    CheckInOutTable.Rows.Add(ItemTransDate, ItemTransDay, ItemEmpID, ItemEmpName, ItemStartTime, "00:00", TimeSpan.Zero, ItemTransInID, 0)

                End If


                ' MsgBox(CheckInOutTable.Rows(i).Item("ElapseTime"))

            Next
            Dim sum As TimeSpan = (CheckInOutTable.Compute("SUM(ElapseTime)", String.Empty))

            QueryData = CheckInOutTable
            ' Return CheckInOutTable
            ' GridControl1.DataSource = CheckInOutTable
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            QueryData = CheckInOutTable
        End Try








    End Function




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
                    BandedGridView1.Columns("EmpID").GroupIndex = 0
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
    Private Sub RepositoryItemTimeEdit1_ButtonClick(sender As Object, e As Controls.ButtonPressedEventArgs) Handles RepositoryItemTimeEdit1.ButtonClick

    End Sub

    Private Sub CheckEditCheckActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditCheckActive.CheckedChanged

    End Sub

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged

    End Sub
    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs) Handles SearchLookUpEdit1.QueryPopUp
        Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
    Private Sub GetSettings()
        Dim sql As New SQLControl
        Dim SqlString As String
        Try
            SqlString = " select SettingValue From Settings where SettingName ='TempForOpenForms'"
            Sql.SqlTrueTimeRunQuery(SqlString)
            _FormType = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            _FormType = "0"
            XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        MsgBox("طباعة قسيمة راتب")
    End Sub
End Class