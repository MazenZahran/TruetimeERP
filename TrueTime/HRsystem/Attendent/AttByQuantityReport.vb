Imports System.Data.SqlClient
Imports System.Globalization

Public Class AttByQuantityReport
    Dim _employeename As String
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.DataSource = String.Empty
        Dim EmployeesTable As DataTable
        Dim DataTable As New DataTable
        Dim SQLString As String
        Dim EmpIDCombo As String = SearchLookUpEdit1.EditValue
        Dim _EmpID As Integer
        If EmpIDCombo <> String.Empty And CStr(SearchLookUpEdit1.EditValue) <> "0" Then
            _EmpID = SearchLookUpEdit1.EditValue
        Else
            _EmpID = -1
        End If
        SQLString = "Select  EmployeeID ,[UserIDInAttFile] as EmpID ,EmployeeName, [AttPlane],Salary,DailyTransport ,FactorLate,BonusPerHour,
                                 SalaryAccountNo,RequiredDailyHoures,[SalaryPerHour],SubtractionLeavesAndLates,AddBonusToSalary,
                                 MaxLeavesHoures,ProcessType,BonusOnDayOff,DateOfStart,DateOfEnd,
                                 IsNull(CalcBonusAfterMinitues,0) as CalcBonusAfterMinitues,IsNull(BonusPerHourAferPeriod1,1) as BonusPerHourAferPeriod1
                         From EmployeesData
                         Where (ProcessType <>'2' or ProcessType is null)   "

        If CStr(SearchLookUpEdit1.Text) IsNot Nothing And CStr(SearchLookUpEdit1.Text) <> String.Empty Then
            SQLString = SQLString + " And EmployeeID = " & SearchLookUpEdit1.EditValue
        End If



        'If LookUpEditBranch.EditValue <> "0" And LookUpEditBranch.EditValue <> String.Empty Then SQLString = SQLString + " And Branch = N'" & LookUpEditBranch.EditValue & "'"
        'If LookUpEditDepartment.EditValue <> "0" And LookUpEditDepartment.EditValue <> String.Empty Then SQLString = SQLString + " And Department = N'" & LookUpEditDepartment.EditValue & "'"
        'If LookUpEditPosition.EditValue <> "0" And LookUpEditPosition.EditValue <> String.Empty Then SQLString = SQLString + " And JobName = N'" & LookUpEditPosition.EditValue & "'"

        Dim sql As New SQLControl
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then
            MsgBox("لا يوجد حركات")
            Exit Sub
        End If

        EmployeesTable = sql.SQLDS.Tables(0)




        For j As Integer = 0 To EmployeesTable.Rows.Count - 1

            If Not IsDBNull(EmployeesTable.Rows(j).Item("EmpID")) Then
                Dim EmpID As String = EmployeesTable.Rows(j).Item("EmpID")
                _employeename = EmployeesTable.Rows(j).Item("EmployeeName")
                DataTable.Merge(QueryData(EmpID))
            End If
        Next

        GridControl1.DataSource = DataTable


    End Sub
    Private Function QueryData(EmpID As String) As DataTable
        Dim ListDays As New DataTable
        Dim DD As New DataColumn With {
            .AllowDBNull = False,
            .Unique = True
        }
        DD = ListDays.Columns.Add("TransDate", GetType(Date))
        ListDays.Columns.Add("TransDay", GetType(String))
        ListDays.Columns.Add("EmployeeNo", GetType(Integer))
        ListDays.Columns.Add("EmployeeName", GetType(String))

        ListDays.Columns.Add("Quantity", GetType(Decimal))
        ListDays.Columns.Add("Price", GetType(Decimal))
        ListDays.Columns.Add("Amount", GetType(Decimal))
        ListDays.Columns.Add("Notes", GetType(String))
        ListDays.Columns.Add("AttStatus", GetType(String))




        Dim CurrD As Date = Format(DateEdit1.DateTime, "yyyy-MM-dd")
        Dim endP As Date = Format(DateEdit2.DateTime, "yyyy-MM-dd")
        Dim CurrDName As String = Format(CurrD, "dddd")






        ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), EmpID, _employeename)


        While (CurrD < endP)
            CurrD = CurrD.AddDays(1)
            If GlobalVariables._SystemLanguage = "Arabic" Then
                ListDays.Rows.Add(CurrD, CurrD.ToString("dddd", New CultureInfo("ar-AE")), EmpID, _employeename)
            Else
                ListDays.Rows.Add(CurrD, CurrD.ToString("dddd"), EmpID, _employeename)
            End If
        End While


        Dim myconnection As SqlConnection
        Dim mycommand As SqlCommand
        myconnection = New SqlConnection(My.Settings.Item("TrueTimeConnectionString"))
        Dim dr As SqlDataReader
        myconnection.Open()

        For i = 0 To ListDays.Rows.Count - 1
            Dim _TransDate As String = Format(ListDays.Rows(i).Item("TransDate"), "yyyy-MM-dd") & " 00:00:00"


            Dim SQLString2 As String = " SELECT Sum(Quantity) as Quantity ,Avg(Price) as Price ,Sum(Quantity)*Avg(Price) as Amount,[EmployeeNo],[TransDate]
                                         FROM [dbo].[AttByQuantity]
	                                     where TransDate='" & _TransDate & "' and EmployeeNo=" & EmpID & " group by [EmployeeNo],[TransDate] "


            mycommand = New SqlCommand(SQLString2, myconnection)
            dr = mycommand.ExecuteReader

            Try
                If dr.HasRows Then
                    dr.Read()
                    ListDays.Rows(i).Item("EmployeeNo") = dr.Item("EmployeeNo")

                    ListDays.Rows(i).Item("Quantity") = dr.Item("Quantity")
                    ListDays.Rows(i).Item("Price") = dr.Item("Price")
                    ListDays.Rows(i).Item("Amount") = dr.Item("Amount")
                    If Not IsDBNull(ListDays.Rows(i).Item("Quantity")) Then
                        ListDays.Rows(i).Item("AttStatus") = "دوام"
                    End If
                    dr.Close()
                Else
                    ListDays.Rows(i).Item("AttStatus") = "غياب"
                    dr.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                dr.Close()
            End Try

        Next


        Return ListDays
    End Function
    Private Sub GetEmployeesList()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " select EmployeeID,EmployeeName,[Department],[JobName],[Branch],[PictureEmp]
                      from [EmployeesData]
                      where  [Active] =1"



            sql.SqlTrueTimeRunQuery(SqlString)
            SearchLookUpEdit1.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub AttByQuantityReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DateEdit2.DateTime = Today
        Dim startDt As New Date(Today.Year, Today.Month, 1)
        Me.DateEdit1.DateTime = startDt
        GetEmployeesList()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup1.SelectedIndexChanged
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
            Case "current"
                Me.DateEdit2.DateTime = Today
                Dim startDt As New Date(Today.Year, Today.Month, 1)
                Me.DateEdit1.DateTime = startDt
        End Select
    End Sub
End Class