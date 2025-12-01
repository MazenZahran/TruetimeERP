Imports System.ComponentModel
Imports System.Data.SqlClient
Imports TrueTime.AccountingDataSet

Public Class SalaryReportPTEC
    Public _DocID As Integer
    Private Sub SalaryReportPTEC_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        FillReport()
    End Sub
    Private Sub FillReport()
        Me.XrLabelPrintDate.Text = Format(Today, "yyyy-MM-dd")
        Me.XrLabelPrintTime.Text = Format(Now, "HH:mm")
        Dim sql As New SQLControl
        Dim SqlString As String
        Dim _DateFrom, _Date__To, _EmployeeId As String
        SqlString = "  SELECT   A.[ID],A.[DateFrom],A.[DateTo] ,A.[DocMonth] ,A.[DocYear] ,A.[EmployeeID]  
                              ,C.[Code] as [Currency] ,A.[SalaryMonth] ,A.[BonusAmount]
                              ,A.[Transport] ,A.[Additions] ,A.[LeavesAmount] ,A.[Payment] ,A.[GrossSalary] ,A.[MonthDays] ,A.[ActualDays]
                              ,A.[VocationDays] ,A.[WeekOffDays] ,A.[AbsenceDays] ,A.[HouresRequired] ,A.[ActualHoures] ,A.[VocationBegBalance] ,A.[AccruedVocationDays]
                              ,A.[VocationCurrentBalance] ,A.[VocationAtEndYear] ,A.[VocationSick] ,A.[NetSalary] ,A.HouresNetBonus,A.HouresNetLeaves,ArchiveStatus,AbsenceAmount"
        SqlString &= "        ,A.[EmployeeNoAsAcc],A.[EmployeeName],A.[Branch] ,A.[Department] ,A.[JobName] ,A.[BeginDate],A.[Indenty],A.[BankName],A.[BankNo],A.[BankBranch],A.IBAN,A.ProcessType,A.SalaryPerHour,IsNull(IncomeTAX,0) as IncomeTAX "
        SqlString &= "  FROM [AttRawatebArchive] A  
                        Left join EmployeesData E on E.EmployeeID =A.EmployeeID
                        Left join [dbo].[Currency] C on C.CurrID =A.Currency
                        Where A.[ID] > 0 and A.ID=" & _DocID
        sql.SqlTrueTimeRunQuery(SqlString)


        With sql.SQLDS.Tables(0).Rows(0)
            If Not IsDBNull(.Item("EmployeeID")) Then XrLabelEmployeeID.Text = .Item("EmployeeID")
            If Not IsDBNull(.Item("EmployeeName")) Then XrLabelEmployeeName.Text = .Item("EmployeeName")
            XrLabelPeriodString.Text = " من " & .Item("DateFrom") & " الى " & .Item("DateTo")
            If Not IsDBNull(.Item("DateFrom")) Then _DateFrom = .Item("DateFrom") Else _DateFrom = "1900-01-01"
            If Not IsDBNull(.Item("DateTo")) Then _Date__To = .Item("DateTo") Else _Date__To = "1900-01-01"
            If Not IsDBNull(.Item("EmployeeID")) Then _EmployeeId = .Item("EmployeeID") Else _EmployeeId = "0"
            If Not IsDBNull(.Item("Branch")) Then XrLabelBranch.Text = .Item("Branch")
            If Not IsDBNull(.Item("Department")) Then XrLabelDepartment.Text = .Item("Department")
            If Not IsDBNull(.Item("JobName")) Then XrLabelJobName.Text = ""
            If Not IsDBNull(.Item("SalaryMonth")) Then XrLabelMonthSalaryParameter.Text = .Item("SalaryMonth")
            If Not IsDBNull(.Item("Indenty")) Then XrLabelIndenty.Text = .Item("Indenty")
            If Not IsDBNull(.Item("IncomeTAX")) Then XrLabelIncomeTAX.Text = .Item("IncomeTAX")

            XrLabelBonusAmount.Text = CStr(CDec(GetAdditionsByTypeID(5, _EmployeeId, _DateFrom, _Date__To)) + CDec(GetAdditionsByTypeID(6, _EmployeeId, _DateFrom, _Date__To)) - CDec(GetDiscountByPaymentTypeID(15, _EmployeeId, _DateFrom, _Date__To)))
            XrLabelAdditionsParameters.Text = CStr(GetAdditionsByTypeID(4, _EmployeeId, _DateFrom, _Date__To))
            XrLabelCurrencyDiff.Text = CStr(GetAdditionsByTypeID(7, _EmployeeId, _DateFrom, _Date__To))

            XrLabelAbsent.Text = CStr(GetDiscountByPaymentTypeID(13, _EmployeeId, _DateFrom, _Date__To))
            ' XrLabelAbsent.Text = GetAbsentAmountFromSalariesArchive(_DocID)
            'XrLabelAbsent.Text = CStr(GetDiscountByPaymentTypeID(13, _EmployeeId, _DateFrom, _Date__To))
            XrLabelMobile.Text = CStr(GetDiscountByPaymentTypeID(7, _EmployeeId, _DateFrom, _Date__To))
            XrLabelInsurance.Text = CStr(GetDiscountByPaymentTypeID(9, _EmployeeId, _DateFrom, _Date__To))
            XrLabelCash.Text = CStr(GetDiscountByPaymentTypeID(8, _EmployeeId, _DateFrom, _Date__To))
            XrLabelAdjustments.Text = CStr(GetDiscountByPaymentTypeID(16, _EmployeeId, _DateFrom, _Date__To))
            XrLabelTotalDeduction.Text = .Item("IncomeTAX") + GetDiscountByPaymentTypeID(7, _EmployeeId, _DateFrom, _Date__To) + GetDiscountByPaymentTypeID(9, _EmployeeId, _DateFrom, _Date__To) + GetDiscountByPaymentTypeID(8, _EmployeeId, _DateFrom, _Date__To) + CStr(GetDiscountByPaymentTypeID(16, _EmployeeId, _DateFrom, _Date__To))
            Dim DeferredIncentives As Decimal = GetDiscountByPaymentTypeID(9, _EmployeeId, _DateFrom, _Date__To) ' ألحوافز المؤجلة
            Dim AccruedIncentives As Decimal = CDec(GetAdditionsByTypeID(6, _EmployeeId, _DateFrom, _Date__To)) ' الحوافز المستحقة
            Try
                XrLabelNetSalary.Text = CStr(CDec(XrLabelMonthSalaryParameter.Text) + CDec(XrLabelAdditionsParameters.Text) + CDec(XrLabelCurrencyDiff.Text) + CDec(XrLabelBonusAmount.Text) - XrLabelTotalDeduction.Text - GetDiscountByPaymentTypeID(13, _EmployeeId, _DateFrom, _Date__To))
                ' XrLabelGrossMonthSalaryParameter.Text = .Item("SalaryMonth") + .Item("BonusAmount") + .Item("Additions") - XrLabelAbsent.Text
                XrLabelGrossMonthSalaryParameter.Text = CDec(XrLabelMonthSalaryParameter.Text) + CDec(XrLabelBonusAmount.Text) + CDec(XrLabelAdditionsParameters.Text) + CDec(XrLabelCurrencyDiff.Text) - CDec(XrLabelAbsent.Text)
                'XrLabelSalaryAfterTAX.Text = XrLabelGrossMonthSalaryParameter.Text - .Item("IncomeTAX")
            Catch ex As Exception
                XrLabelNetSalary.Text = "0"
                XrLabelGrossMonthSalaryParameter.Text = "0"
                ' XrLabelSalaryAfterTAX.Text = "0"
            End Try

            If Not IsDBNull(.Item("BeginDate")) Then
                If CStr(.Item("BeginDate")) = String.Empty Then
                    XrLabelBeginDate.Text = ""
                Else
                    XrLabelBeginDate.Text = Format(.Item("BeginDate"), "yyyy-MM-dd")
                End If
            End If


        End With
        GetCompanyData()
    End Sub
    Private Function GetAbsentAmountFromSalariesArchive(_DocID) As Decimal
        Dim amount As Decimal = 0
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = "  SELECT   IsNull(Sum(AbsenceAmount),0) as AbsenceAmount"
            SqlString &= "  FROM [AttRawatebArchive] A  
                        Where A.[ID] ='" & _DocID & "'"
            sql.SqlTrueTimeRunQuery(SqlString)
            With sql.SQLDS.Tables(0).Rows(0)
                If Not IsDBNull(.Item("AbsenceAmount")) Then amount = .Item("AbsenceAmount")
            End With
        Catch ex As Exception
            amount = 0
        End Try
        Return amount
    End Function
    Private Sub GetCompanyData()
        Try
            Dim SqlString As String
            Dim sql As New SQLControl
            SqlString = " SELECT top(1) [CompanyName] ,[CompanyAddress] ,[CompanyPhone],[CompanyMobile] ,[CompanyFax],[CompanyEmail] ,[CompanyWebSite],IsNull([SoftwareID],'0') as SoftwareID
                              FROM [CompanyData] "
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelComapnyName.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
            XrLabelCompanyAddress.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress")
            XrLabelPhoneParameters.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone")
            XrLabelFaxParameter.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFax")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            XrPictureBox1.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try


        Try
            If String.IsNullOrEmpty(XrLabelFaxParameter.Text) Then
                XrLabelFax.Visible = False
            Else
                XrLabelFax.Visible = True
            End If

            If String.IsNullOrEmpty(XrLabelPhoneParameters.Text) Then
                XrLabelPhone.Visible = False
            Else
                XrLabelPhone.Visible = True
            End If

        Catch ex As Exception

        End Try

    End Sub

End Class