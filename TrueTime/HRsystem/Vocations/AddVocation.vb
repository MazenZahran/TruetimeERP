Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports System.Data.SqlClient

Public Class AddVocation
    Dim i As Integer
    Public opend As Boolean = True

    Private Sub AddVocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        CreateAdjTypes()
        'ClearData()
        Me.KeyPreview = True
        'If FromFrom.Text = My.Forms.AttReportAndProcessByHoures.Name Then
        '    '   LookUpEditVocations.EditValue = "سنوية"
        '    TextID.EditValue = GetMaxVocationID() + 1
        '    TextVocationDate.DateTime = Today
        '    '  TextNewOrOld.EditValue = -1

        '    TextVocationDate.Select()
        'ElseIf FromFrom.Text = "False" Then
        '    ClearData()
        'ElseIf FromFrom.Text = "True" Then
        '    GetData(TextID.Text)
        'End If

        If GlobalVariables._EndDate < Today Then
            SaveButton.Enabled = False
        End If

        LookVocationSource.Properties.DataSource = CreateVocationsSource()
        '      Me.LookVocationSource.EditValue = "vocation"
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveBtton()
        ElseIf e.KeyCode = Keys.F6 Then
            ClearData()
        ElseIf e.KeyCode = Keys.F4 Then
            DeleteButtn()
        End If
    End Sub
    Private Sub LookUpEditEmployees_EditValueChanged(sender As Object, e As EventArgs) Handles LookUpEditEmployees.EditValueChanged
        TextEmployeeID.Text = LookUpEditEmployees.EditValue
        Calc()
    End Sub
    Private Sub Calc()
        TextVocationsYear.Text = 0
        TextBalance.Text = 0
        If LookUpEditEmployees.EditValue Is Nothing Or LookUpEditVocations.EditValue Is Nothing Then Exit Sub
        Dim EmpID As String = CStr(LookUpEditEmployees.EditValue)
        Dim VocID As Integer = CInt(LookUpEditVocations.EditValue)
        ' If LookUpEditVocations.Text = "سنوية" Then TextLimitVocations.Text = GetLimitVocations() Else TextLimitVocations.Text = 0
        '  TextVocationsYear.Text = GetSumVocationsThisYear()


        Dim _VocationDetails = GetVocationsBalancesByEmployee(EmpID, VocID, Today())
        TextBalance.Text = _VocationDetails.Balance
        TextVocationsYear.Text = _VocationDetails.ThisYearVocations
        TextBeginigBalance.Text = _VocationDetails.BeginingBalance
        TextAdditions.Text = _VocationDetails.ThisYearSetBalance
        TextVocationsRemaining.Text = _VocationDetails.AccruedVocations
    End Sub
    Private Sub DateEditFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditFrom.EditValueChanged
        GetDaysNo()
    End Sub
    Private Sub DateEditTo_Leave(sender As Object, e As EventArgs) Handles DateEditTo.Leave
        GetDaysNo()
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveBtton()
    End Sub

    Private Sub SaveBtton()
        If GlobalVariables._EndDate < Today Then
            If DateEditTo.DateTime > GlobalVariables._EndDate Then
                MsgBoxShowError(" لا يمكن حفظ البيانات ، النسخة تنتهي بتاريخ  " & " " & GlobalVariables._EndDate)
                Exit Sub
            End If
        End If

        Dim EmployeeError, VocationTypeError, DateError, DayNoError, VocationBalanceError, SecondDateError, SaveError As String
        If GlobalVariables._SystemLanguage = "Arabic" Then
            EmployeeError = "الموظف فارغ"
            VocationTypeError = "يرجى اختيار نوع الاجازة"
            DateError = "يرحى اختيار التاريخ"
            DayNoError = "عدد الأيام"
            VocationBalanceError = "رصيد الاجازات لا يكفي هل تريد الاستمرار؟"
            SecondDateError = " التاريخ الثاني اقل من التاريخ الاول "
            SaveError = " لا يمكن حفظ السند "
        Else
            EmployeeError = "Empty Employee"
            VocationTypeError = "Vocation Type Empty"
            DateError = "Vocation Date Empty"
            DayNoError = "Days Count"
            VocationBalanceError = "Vocation Balance Not Enough, Do You Want Cont. ?"
            SecondDateError = " The Second Date Less Than First Date"
            SaveError = "Error : Document Not Saved "
        End If

        Try
            Dim DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
            Dim DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
            If TextEmployeeID.Text = "0" Then MsgBox(EmployeeError) : Exit Sub
            If TextEmployeeID.Text = String.Empty Then MsgBox(EmployeeError) : Exit Sub
            If LookUpEditVocations.Text = String.Empty Then MsgBox(VocationTypeError) : Exit Sub
            If DateFrom = String.Empty Or DateTo = String.Empty Then MsgBox(DateError) : Exit Sub
            If TextDayNo.Text = String.Empty Then MsgBox(DayNoError) : Exit Sub
            'If TextDayNo.EditValue > TextVocationsRemaining.EditValue Then
            '    Dim Msg As DialogResult = XtraMessageBox.Show(VocationBalanceError, " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            '    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
            'End If
            If TextDayNo.Text < 0 Then
                XtraMessageBox.Show(SecondDateError, " ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                DateEditTo.DateTime = DateEditFrom.DateTime
                TextDayNo.Text = 1
                Exit Sub
            End If

            If TextNewOrOld.Text = "New" Then
                Saving()
            ElseIf TextNewOrOld.Text = "Old" Then
                EditVocations()
            End If
            ' ClearData()
            Me.Close()
        Catch ex As Exception
            Dim Msg As DialogResult = XtraMessageBox.Show(SaveError, " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub ClearData()
        Try
            'opend = False
            TextVocationDate.DateTime = Today
            DateEditTo.DateTime = Today
            DateEditFrom.DateTime = Today
            LookUpEditEmployees.EditValue = Nothing
            TextEmployeeID.Text = Nothing
            LookUpEditVocations.EditValue = Nothing
            MemoDetails.Text = Nothing
            TextVocationsYear.Text = 0
            TextBalance.Text = 0
            TextVocationsRemaining.Text = 0
            TextNewOrOld.Text = "New"
            LookVocationSource.EditValue = "vocation"

            TextVocationDate.Select()
            Me.TextDayNo.EditValue = 1
            Me.LookUpEditVocations.EditValue = 1

        Catch ex As Exception

        Finally

        End Try
    End Sub

    Private Sub TextVocationDate_EditValueChanged(sender As Object, e As EventArgs) Handles TextVocationDate.EditValueChanged
        '  TextVocationsYear.Text = GetVocationDataByEmpID(EmpID, VocID).Item1
        If LookUpEditEmployees.EditValue IsNot Nothing Then Calc()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        ClearData()
    End Sub
    Private Sub TextID_EditValueChanged(sender As Object, e As EventArgs) Handles TextID.EditValueChanged
        'If CheckArchiveDocNo(TextID.Text) = "False" Then
        '    LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'Else
        '    LayoutControlItem26.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        'End If
        If TextID.Text = "" Then Exit Sub
        'If opend = False Then Exit Sub
        If Me.TextNewOrOld.Text = "old" Then
            GetData(TextID.EditValue)
        End If

    End Sub
    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        DeleteButtn()
    End Sub

    Private Sub DeleteButtn()
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If TextNewOrOld.Text = "New" Then XtraMessageBox.Show("لا يوجد شئ لحذفه") : Exit Sub
        Else
            If TextNewOrOld.Text = "Old" Then XtraMessageBox.Show("Nothing To Delete") : Exit Sub
        End If

        If GlobalVariables._SystemLanguage = "Arabic" Then
            Dim Msg As DialogResult = XtraMessageBox.Show(" هل تريد حذف السند؟   ", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
        Else
            Dim Msg As DialogResult = XtraMessageBox.Show(" Are you sure ?   ", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
        End If

        If Me.LookVocationSource.EditValue = "adjust" Then
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" delete from [AttAdjustmentTrans] where ID= ( select [TransAdjustID] from [Vocations] where [VocID]= " & Me.TextID.EditValue & ")")
        End If

        Try
            Dim sql As New SQLControl
            Dim SQLString As String
            SQLString = "Delete From Vocations Where VocID = " & Me.TextID.Text
            sql.SqlTrueTimeRunQuery(SQLString)
            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم حذف السند")
            Else
                XtraMessageBox.Show("Done")
            End If

            ClearData()
        Catch ex As Exception
            XtraMessageBox.Show("Error ")
            Exit Sub
        End Try
    End Sub

    Private Sub EditVocations()

        Dim VocDate As String = Format(TextVocationDate.DateTime, "yyyy-MM-dd")
        Dim DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim _DaysNo As Decimal = TextDayNo.EditValue

        If Me.LookVocationSource.EditValue = "adjust" And AdjTypeLookUp.EditValue = "+" Then
            _DaysNo = -1 * TextDayNo.Text
        End If
        Try

            Dim sql As New SQLControl
            Dim SqlString As String = " Update Vocations Set  
                                               VocDate =  " & "'" & VocDate & "',
                                               EmployeeID = " & " '" & LookUpEditEmployees.EditValue & "',
                                               VocationType = " & " N'" & LookUpEditVocations.EditValue & "',
                                               FromDate = " & " '" & DateFrom & "',
                                               ToDate = " & " '" & DateTo & "',
                                               NoDays = " & " " & _DaysNo & ",
                                               NoteDetails = " & " N'" & MemoDetails.Text & "',
                                               VocationSource = " & "'" & LookVocationSource.EditValue & "'
                                               where VocID =  " & TextID.Text
            If sql.SqlTrueTimeRunQuery(SqlString) = True Then
                If GlobalVariables._SystemLanguage = "Arabic" Then
                    XtraMessageBox.Show("تم تعديل السند بنجاح")
                Else
                    XtraMessageBox.Show(" Document Updated successfully")
                End If
            End If


        Catch ex As Exception
            XtraMessageBox.Show("Error")
            Exit Sub
        End Try
        Me.Close()
    End Sub

    Private Function Saving() As Boolean
        Dim _Result As Boolean
        Dim DateFrom As String = Format(DateEditFrom.DateTime, "yyyy-MM-dd")
        Dim DateTo As String = Format(DateEditTo.DateTime, "yyyy-MM-dd")
        Dim DocDate As String = Format(TextVocationDate.DateTime, "yyyy-MM-dd")
        Dim _DaysNo As Decimal = TextDayNo.EditValue

        If Me.LookVocationSource.EditValue = "adjust" And AdjTypeLookUp.EditValue = "+" Then
            _DaysNo = -1 * TextDayNo.Text
        End If

        Try
            Dim sql As New SQLControl
            Dim VocDate As String = Format(TextVocationDate.DateTime, "yyyy-MM-dd")
            Dim SqlString As String = "   Insert Into Vocations " _
                                          & " (EmployeeID,VocDate,VocationType, FromDate, ToDate, NoDays, NoteDetails,VocationSource)" _
                                          & " Values ( " _
                                          & String.Empty & TextEmployeeID.Text & "," _
                                          & "'" & VocDate & "'," _
                                          & "N'" & LookUpEditVocations.EditValue & "'," _
                                          & "'" & DateFrom & "'," _
                                          & "'" & DateTo & "'," _
                                          & String.Empty & _DaysNo & "," _
                                          & "N'" & MemoDetails.Text & "'," _
                                          & "N'" & LookVocationSource.EditValue & "'" _
                                          & " ) "

            _Result = sql.SqlTrueTimeRunQuery(SqlString)
        Catch ex As Exception
            _Result = False
        Finally
            If GlobalVariables._SystemLanguage = "Arabic" Then
                XtraMessageBox.Show("تم حفظ السند", "تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                XtraMessageBox.Show("Document Saved", " ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            TextNewOrOld.Text = "New"
        End Try

        Return _Result
        Me.Close()
    End Function
    Private Sub LookUpEditVocations_EditValueChanged_1(sender As Object, e As EventArgs) Handles LookUpEditVocations.EditValueChanged
        Calc()
    End Sub
    Private Sub GetData(VocId As String)
        If VocId = "0" Then Exit Sub
        opend = False
        Try
            Dim sql As New SQLControl
            If TextID.Text = String.Empty Then Exit Sub
            If TextID.EditValue <= 0 Then Exit Sub
            Dim SqlString As String = "Select VocID,VocDate,EmployeeID,VocationType,FromDate,ToDate,NoDays,NoteDetails,VocationSource  from Vocations where VocID =  " & VocId

            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables.Count > 0 Then
                If sql.SQLDS.Tables(0).Rows(i).Item("VocDate") IsNot DBNull.Value Then TextVocationDate.DateTime = sql.SQLDS.Tables(0).Rows(i).Item("VocDate")
                If sql.SQLDS.Tables(0).Rows(i).Item("EmployeeID") IsNot DBNull.Value Then TextEmployeeID.Text = sql.SQLDS.Tables(0).Rows(i).Item("EmployeeID")
                If sql.SQLDS.Tables(0).Rows(i).Item("EmployeeID") IsNot DBNull.Value Then LookUpEditEmployees.EditValue = sql.SQLDS.Tables(0).Rows(i).Item("EmployeeID")
                If sql.SQLDS.Tables(0).Rows(i).Item("VocationType") IsNot DBNull.Value Then LookUpEditVocations.EditValue = sql.SQLDS.Tables(0).Rows(i).Item("VocationType")
                If sql.SQLDS.Tables(0).Rows(i).Item("ToDate") IsNot DBNull.Value Then DateEditTo.DateTime = sql.SQLDS.Tables(0).Rows(i).Item("ToDate")
                If sql.SQLDS.Tables(0).Rows(i).Item("FromDate") IsNot DBNull.Value Then DateEditFrom.DateTime = sql.SQLDS.Tables(0).Rows(i).Item("FromDate")
                If sql.SQLDS.Tables(0).Rows(i).Item("NoDays") IsNot DBNull.Value Then TextDayNo.EditValue = sql.SQLDS.Tables(0).Rows(i).Item("NoDays")
                If sql.SQLDS.Tables(0).Rows(i).Item("NoteDetails") IsNot DBNull.Value Then MemoDetails.Text = sql.SQLDS.Tables(0).Rows(i).Item("NoteDetails")
                If sql.SQLDS.Tables(0).Rows(i).Item("VocationSource") IsNot DBNull.Value Then
                    LookVocationSource.EditValue = sql.SQLDS.Tables(0).Rows(i).Item("VocationSource")
                Else
                    LookVocationSource.EditValue = "vocation"
                End If
                If LookVocationSource.EditValue = "adjust" And TextDayNo.EditValue > 0 Then
                    Me.AdjTypeLookUp.EditValue = "-"
                End If
                If LookVocationSource.EditValue = "adjust" And TextDayNo.EditValue < 0 Then
                    Me.AdjTypeLookUp.EditValue = "+"
                    TextDayNo.EditValue = -1 * TextDayNo.EditValue
                End If
                ' TextNewOrOld.Text = "Old"
            Else
                XtraMessageBox.Show("Error", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            XtraMessageBox.Show("Error")
        End Try
        opend = True
    End Sub
    Private Sub GetDaysNo()
        If Me.IsHandleCreated Then
            If opend = False Then Exit Sub
            Try
                If LookVocationSource.EditValue = "vocation" Then
                    If DateEditFrom.ToString = String.Empty Or DateEditTo.ToString = String.Empty Then Exit Sub
                    Dim VocationsDay As Integer = DateDiff(DateInterval.Day, DateEditFrom.DateTime, DateEditTo.DateTime).ToString()

                    VocationsDay = VocationsDay + 1
                    If GlobalVariables._SystemLanguage = "Arabic" Then
                        If VocationsDay <= 0 Then XtraMessageBox.Show("التاريخ الثاني اقل من التاريخ الأول", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error) : DateEditTo.DateTime = DateEditFrom.DateTime : TextDayNo.Text = 1 : Exit Sub
                    Else
                        If VocationsDay <= 0 Then XtraMessageBox.Show("The Second Date Greater Than First Date", "Attension", MessageBoxButtons.OK, MessageBoxIcon.Error) : DateEditTo.DateTime = DateEditFrom.DateTime : TextDayNo.Text = 1 : Exit Sub
                    End If

                    If GlobalVariables._SystemLanguage = "Arabic" Then
                        If VocationsDay >= 364 Then MsgBox("عدد الايام اكبر من سنة") : TextDayNo.Text = VocationsDay
                    Else
                        If VocationsDay >= 364 Then MsgBox("The Days Greater Than 365 Days") : TextDayNo.Text = VocationsDay
                    End If

                    If VocationsDay < 364 Then TextDayNo.Text = VocationsDay
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        PrintVocation()
    End Sub

    Private Sub PrintVocation()
        Try
            Dim report As New VocationNewReport()
            If GlobalVariables._SystemLanguage <> "Arabic" Then
                report.RightToLeft = False
                report.RightToLeftLayout = False
                report.XrLabel30.Text = "Phone:"
                report.XrLabel32.Text = "Fax:"
                report.XrLabel1.Text = "Vocation Form"
                report.XrLabel33.Text = "DocNo:"
                report.XrLabel36.Text = "Date:"
                report.XrLabel3.Text = "Employee:"
                report.XrLabel25.Text = "Department:"
                report.XrLabel26.Text = "Branch:"
                report.XrLabel27.Text = "Position:"
                report.XrLabel6.Text = "From Date:"
                report.XrLabel7.Text = "To Date:"
                report.XrLabel14.Text = "Days:"
                report.XrLabel28.Text = "Vocation Type:"
                report.XrLabel35.Text = "Current Balance:"
                report.XrLabel29.Text = " Notes:"
                report.XrLabel19.Text = " Manager:"
                report.XrLabel18.Text = " Employee:"
            End If
            Try
                Dim cn As SqlConnection
                cn = New SqlConnection
                cn.ConnectionString = My.Settings.TrueTimeConnectionString
                Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
                cn.Open()
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
                report.XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception

            End Try
            report.Parameter1.Value = Me.TextID.Text
            report.Parameter1.Visible = False
            report.VocBalance.Value = Me.TextVocationsRemaining.Text
            report.VocBalance.Visible = False
            report.CreateDocument()
            report.PrintingSystem.ShowMarginsWarning = False
            report.ShowPreview()
        Catch ex As Exception
            If GlobalVariables._SystemLanguage = "Arabic" Then
                MsgBox("خطا: لم يتمكن البرنامج من طباعة السند ")
            Else
                MsgBox("Error ")
            End If

            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub
    Private Sub LookVocationSource_EditValueChanged(sender As Object, e As EventArgs) Handles LookVocationSource.EditValueChanged
        Select Case LookVocationSource.EditValue
            Case "vocation"
                TextDayNo.ReadOnly = False
                LayoutPlusMinus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
      '          GetDaysNo()
            Case "leaves"
                TextDayNo.ReadOnly = False
                LayoutPlusMinus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Case "adjust"
                TextDayNo.ReadOnly = False
                LayoutPlusMinus.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Select
    End Sub
    Private Sub CreateAdjTypes()
        Dim Table1 As DataTable
        Table1 = New DataTable("TableName")
        Dim column1 As DataColumn = New DataColumn("id")
        column1.DataType = System.Type.GetType("System.String")
        Dim column2 As DataColumn = New DataColumn("adjname")
        column2.DataType = System.Type.GetType("System.String")
        Table1.Columns.Add(column1)
        Table1.Columns.Add(column2)
        Dim row1 As DataRow = Table1.NewRow()
        row1("id") = "+"
        row1("adjname") = "ترصيد على الاجازات"
        Table1.Rows.Add(row1)
        Dim row2 As DataRow = Table1.NewRow()
        row2("id") = "-"
        row2("adjname") = "خصم من الاجازات"
        Table1.Rows.Add(row2)
        Me.AdjTypeLookUp.Properties.DataSource = Table1
    End Sub

    Private Sub TextNewOrOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOrOld.EditValueChanged
        If Me.TextNewOrOld.Text = "New" Then
            Me.Text = " اضافة اجازة جديد "
            ClearData()
            TextID.EditValue = GetMaxVocationID() + 1
        ElseIf Me.TextNewOrOld.Text = "Old" Then
            Me.Text = " تعديل بيانات الاجازة "
            GetData(TextID.Text)
        End If
    End Sub

    Private Sub TextBeginigBalance_EditValueChanged(sender As Object, e As EventArgs) Handles TextBeginigBalance.EditValueChanged

    End Sub
End Class