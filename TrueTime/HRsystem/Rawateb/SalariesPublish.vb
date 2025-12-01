Imports DevExpress.XtraEditors
Imports DevExpress.XtraRichEdit.Import.EPub

Public Class SalariesPublish
    Private _Mode As String
    Public Sub New(Mode As String)

        ' This call is required by the designer.
        InitializeComponent()
        _Mode = Mode
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub SalariesPublish_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesPositions' table. You can move, or remove it, as needed.
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesDepartments' table. You can move, or remove it, as needed.
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        ProcessTypeSearch.DataSource = CreatPreccessTypeTable()
        RadioGroup1.EditValue = "last"
        Select Case _Mode
            Case "Attendance"
                BtnPublish.Text = "اصدار التقارير"
                LayoutPrintSalaryStatment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End Select
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetEmployees()
    End Sub
    Private Sub GetEmployees()
        Try
            Dim sql As New SQLControl
            Dim _DateFrom As String = Format(CDate(DateEdit1.DateTime), "yyyy-MM-dd")
            Dim _DateTo As String = Format(CDate(DateEdit2.DateTime), "yyyy-MM-dd")
            Dim sqlstring As String
            sqlstring = "Select A.*,Case when B.ArchiveStatus Is Null then 'no'  when B.ArchiveStatus=0 then 'yes' when B.ArchiveStatus=1 then 'posted' end  as DocID
                    From 
                     (Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],Salary,DailyTransport ,FactorLate,BonusPerHour,
                                 SalaryAccountNo,RequiredDailyHoures,[SalaryPerHour],SubtractionLeavesAndLates,AddBonusToSalary,
                                 MaxLeavesHoures,ProcessType,BonusOnDayOff,DateOfStart,DateOfEnd,
                                 IsNull(CalcBonusAfterMinitues,0) as CalcBonusAfterMinitues,IsNull(BonusPerHourAferPeriod1,1) as BonusPerHourAferPeriod1,Mobile1
                         From EmployeesData where 1=1 And EmployeeID <> -999  "
            If CheckEditCheckActive.Checked = True Then sqlstring += " and EmployeesData.Active = 1  "
            If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then sqlstring = sqlstring + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
            If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then sqlstring = sqlstring + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
            If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then sqlstring = sqlstring + " And JobName = N'" & LookUpEditPosition.EditValue & "'"
            sqlstring += " ) A 
                        left join 
                        (
                        Select [ID],ArchiveStatus,EmployeeID 
                        From [AttRawatebArchive]
                        Where ((DateFrom  between '" & _DateFrom & "'  and '" & _DateTo & "' ) or 
                              (DateTo between '" & _DateFrom & "' and '" & _DateTo & "' ))  
                        ) B
                        on A.EmployeeID=B.EmployeeID "
            sql.SqlTrueTimeRunQuery(sqlstring)
            GridControl1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBoxShowError(ex.ToString)
        End Try

    End Sub
    Private Sub RadioGroup1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
        Select Case RadioGroup1.EditValue
            Case "last"
                Dim _fromdate, _todate As DateTime
                Dim _lastmonth, _year As Integer

                If Today.Month = 1 Then
                    _lastmonth = 12
                    _year = Today.Year - 1
                Else
                    _lastmonth = Today.Month - 1
                    _year = Today.Year
                End If

                Dim _daysCount As Integer = System.DateTime.DaysInMonth(_year, _lastmonth)
                _fromdate = New Date(_year, _lastmonth, 1)
                _todate = New Date(_year, _lastmonth, _daysCount)

                Me.DateEdit2.DateTime = _todate
                Me.DateEdit1.DateTime = _fromdate

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If

            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt

                If GlobalVariables._EndDate < Today Then
                    DateEdit2.Enabled = False
                    DateEdit2.DateTime = GlobalVariables._EndDate
                End If

        End Select
    End Sub
    Private Sub PrintSalaries(SaveSalary As Boolean)
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError(" لم يتم اختيار الموظفين ")
            Exit Sub
        End If

        If CheckRows() = False Then
            MsgBoxShowError(" يوجد موظفين بدون سياسة عمل  ")
            Exit Sub
        End If

        Dim j As Integer = 0

        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _EmployeeID As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeID")
            Dim _EmployeeName As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeName")
            Dim _ProcessType As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ProcessType")

            Dim _DocID As Integer = 0
            Dim _DocStatus As Integer = 0
            Dim _DocData = GetSalaryDocumentIDAndStatusIfExist(_EmployeeID, DateEdit1.DateTime, DateEdit2.DateTime)
            _DocID = _DocData.DocID
            _DocStatus = _DocData.DocStatus
            If _DocID > 0 Then
                If _DocStatus <> 0 Then
                    MsgBoxShowError(" يوجد قسيمة مرحلة للموظف " & _EmployeeName)
                    Continue For
                Else
                    DeleteRelatedTransForSalaryDocument(_DocID)
                End If
            End If


            Select Case CInt(_ProcessType)
                Case 2
                    Dim f As New AttRawatebByHouresRequired
                    With f
                        GetFormType("Dawam")
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._OpenForPrint = True
                        ._PrintSalayDocument = CheckPrintSalayDocument.CheckState
                        ._SaveSalary = SaveSalary
                        ._EmployeesCount = selectedRowHandles.Length
                        If CheckPrintAtt.Checked = True Then ._TheOptionPrint = "Print"
                        ' ._PrintAtt = CheckPrintAtt.CheckState
                        .Show()
                    End With
                Case 3, 6
                    Dim f As New AttRawatebByHouresRequired
                    With f
                        GetFormType("Dawam2")
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._OpenForPrint = True
                        ._PrintSalayDocument = CheckPrintSalayDocument.CheckState
                        ._SaveSalary = SaveSalary
                        If CheckPrintAtt.Checked = True Then ._TheOptionPrint = "Print"
                        ' ._PrintAtt = CheckPrintAtt.CheckState
                        .Show()
                    End With
                Case 7
                    Dim f As New AttRawatebByHouresRequired
                    With f
                        GetFormType("DailyAtt")
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._OpenForPrint = True
                        ._PrintSalayDocument = CheckPrintSalayDocument.CheckState
                        ._SaveSalary = SaveSalary
                        If CheckPrintAtt.Checked = True Then ._TheOptionPrint = "Print"
                        ' ._PrintAtt = CheckPrintAtt.CheckState
                        .Show()
                    End With
                Case 1, 4, 5
                    Dim f As New AttRawatebByShift
                    With f
                        GetFormType("Dawam")
                        ._EmployeeIDFromSalariesPublish = 0
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._EmployeeIDFromSalariesPublish = _EmployeeID
                        ._OpenForPrint = True
                        ._PrintSalayDocument = CheckPrintSalayDocument.CheckState
                        ._PrintSalary = True
                        If CheckPrintAtt.Checked = True Then ._TheOptionPrint = "Print"
                        .Show()
                    End With
            End Select
            j += 1

            BarSalariesCounter.Caption = " تم اصدار " & j & " قسيمة "
        Next
        MsgBoxShowSuccess(" تم اصدار الكشوفات " & j)
        GetEmployees()

    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnPublish.Click
        PrintSalaries(True)
    End Sub
    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles BtnPrintOnly.Click
        CheckPrintAtt.Checked = True
        PrintSalaries(False)
        CheckPrintAtt.Checked = False
    End Sub
    Private Function CheckRows() As Boolean
        Dim _result As Boolean
        _result = True
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _ProcessType As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ProcessType")
            If IsDBNull(_ProcessType) Then
                _result = False
                Return False
            End If
        Next
        Return _result
    End Function

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length = 0 Then
            MsgBoxShowError(" لم يتم اختيار الموظفين ")
            Exit Sub
        End If

        If CheckRows() = False Then
            MsgBoxShowError(" يوجد موظفين بدون سياسة عمل  ")
            Exit Sub
        End If

        For i As Integer = 0 To selectedRowHandles.Length - 1
            Dim _EmployeeID As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeID")
            Dim _EmployeeName As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "EmployeeName")
            Dim _ProcessType As Object = GridView1.GetRowCellValue(selectedRowHandles(i), "ProcessType")
            Select Case CInt(_ProcessType)
                Case 2, 3
                    Dim f As New AttRawatebByHouresRequired
                    With f
                        GetFormType("Dawam")
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._OpenForPrint = True
                        ._TheOptionPrint = "Pdf"
                        .Show()
                        SendFileToWhatsApp(GetEmployeeData(_EmployeeID).Mobile, "تقرير الدوام.Pdf", "تقرير الدوام", "", _EmployeeName)
                    End With
                Case 1
                    Dim f As New AttRawatebByShift
                    With f
                        GetFormType("Dawam")
                        ._EmployeeIDFromSalariesPublish = 0
                        .DateEdit1.DateTime = Me.DateEdit1.DateTime
                        .DateEdit2.DateTime = Me.DateEdit2.DateTime
                        .SearchLookUpEdit1.EditValue = _EmployeeID
                        ._EmployeeIDFromSalariesPublish = _EmployeeID
                        ._OpenForPrint = True
                        '._PrintSalayDocument = CheckPrintSalayDocument.CheckState
                        ._TheOptionPrint = "Pdf"
                        .Show()
                        SendFileToWhatsApp(GetEmployeeData(_EmployeeID).Mobile, "تقرير الدوام.Pdf", "تقرير الدوام", "", _EmployeeName)
                    End With
            End Select
        Next
        MsgBoxShowSuccess(" تم ارسال الكشوفات ")
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_OpenLink(sender As Object, e As Controls.OpenLinkEventArgs) Handles RepositoryItemHyperLinkEdit1.OpenLink
        Dim f As New EmployeesEdit
        With f
            .EmployeeIDTextEdit.Text = GridView1.GetFocusedRowCellValue("EmployeeID")
            .EmployeeNameTextEdit.Select()
            If .ShowDialog() <> DialogResult.OK Then
                GetEmployees()
            End If
        End With
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub


End Class