Imports DevExpress.XtraEditors
Imports System.Data
Imports System.Data.SqlClient

Public Class AttAdvancePayment
    Private DefualtCurrencyID As Integer = GetDefaultCurrency()
    Private Sub AttAdvancePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesBranches' table. You can move, or remove it, as needed.
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttPaymentsTypes' table. You can move, or remove it, as needed.
        Me.AttPaymentsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttPaymentsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        'Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        SearchEmployee.Properties.DataSource = GetEmployeesTable(1, -1)
        If GlobalVariables._HRSystemIsConnectedWithAccountingSystem Then
            LayoutFinancialPayments.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End If
        Me.KeyPreview = True
        SearchEmployee.Select()
    End Sub

    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveData()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveData()
    End Sub
    Private Sub SaveData()
        If GlobalVariables._SystemLanguage = "Arabic" Then
            If String.IsNullOrEmpty(Me.SearchEmployee.Text) Or String.IsNullOrEmpty(Me.TextEditAmount.Text) Or String.IsNullOrEmpty(Me.LookUpEditType.Text) Then
                MsgBox("يجب تعبئة البيانات المطلوبة")
                Exit Sub
            End If
            If Me.LookUpEditType.Text = "" Then
                XtraMessageBox.Show("يجب اختيار النوع")
                Exit Sub
            End If
        Else
            If String.IsNullOrEmpty(Me.SearchEmployee.EditValue) Or String.IsNullOrEmpty(Me.TextEditAmount.EditValue) Or String.IsNullOrEmpty(Me.LookUpEditType.EditValue) Then
                MsgBox("You Should Fill all required fields")
                Exit Sub
            End If
            If Me.LookUpEditType.Text = "" Then
                XtraMessageBox.Show(" You should fill all required fields ")
                Exit Sub
            End If
        End If

        If Me.TextEditAmount.EditValue < 1 Then MsgBox(" Amount Error ") : Exit Sub

        ' Update existing
        If TextPaymentID.EditValue <= GetMaxAdvancePayment() AndAlso TextPaymentID.EditValue > 0 Then
            Updating()
            AddNew()
        ElseIf TextFormType.Text = "New" Then
            ' Insert new and ensure success
            Dim inserted As Boolean = Inserting()
            If Not inserted Then
                Exit Sub
            Else
                AddNew()
            End If
        End If


        Me.TextPaymentID.Text = GetMaxAdvancePayment() + 1
    End Sub

    Private Function Inserting() As Boolean
        Try
            Dim PaymentDate As Date = DateEdit1.DateTime.Date
            Dim EmployeeID As Integer = Convert.ToInt32(Me.SearchEmployee.EditValue)
            Dim PaymentAmount As Decimal = Convert.ToDecimal(Me.TextEditAmount.EditValue)
            Dim PaymentNote As String = If(Me.MemoNotes.Text, String.Empty)
            Dim PaymentType As String = Convert.ToString(Me.LookUpEditType.EditValue)
            Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
            Dim Branch As String = " "
            If Me.LookUpEditBranch.Text <> "" Then
                Branch = Me.LookUpEditBranch.Text
            End If

            Dim ReferanceNo As Integer = 0
            If GlobalVariables._HRSystemIsConnectedWithAccountingSystem And CheckIfPaymentTypeIsCashPayment(LookUpEditType.EditValue) Then
                ReferanceNo = GetReferanceNoFromEmployeeNo(EmployeeID)
                If ReferanceNo = 0 Then
                    XtraMessageBox.Show(" خطأ: الموظف غير مرتبط بالحساب المالي، لم يتم اصدار السلفة او سند الصرف ")
                    Return False
                End If
            End If

            ' Insert and get the newly created PaymentID
            Dim newPaymentId As Integer = InsertEmployeePaymentAndReturnId(PaymentDate, EmployeeID, PaymentAmount, PaymentNote, PaymentType, Branch)
            If newPaymentId <= 0 Then
                XtraMessageBox.Show("لم يتم حفظ السلفة. حاول مرة أخرى.")
                Return False
            End If
            CreateDocLog("Document", "", 0, newPaymentId, "Insert", "Insert Payment For Employee: " & EmployeeID & " ", _Now)
            ' If connected to accounting system, issue the financial document and update the row with DocNo
            If GlobalVariables._HRSystemIsConnectedWithAccountingSystem And CheckIfPaymentTypeIsCashPayment(LookUpEditType.EditValue) Then
                Dim DocNo As Integer = IssueFinancialPaymentDocument(0, ReferanceNo, PaymentAmount, PaymentNote)
                If DocNo > 0 Then
                    Dim connStr As String = My.Settings("TrueTimeConnectionString")
                    Using con As New SqlConnection(connStr)
                        Using cmd As New SqlCommand("UPDATE [AttEmployeePayments] SET [FinancialPaymentDocNo] = @DocNo WHERE [PaymentID] = @PaymentID", con)
                            cmd.Parameters.Add("@DocNo", SqlDbType.Int).Value = DocNo
                            cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = newPaymentId
                            con.Open()
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                Else
                    MsgBoxShowError(" تم اصدار سلفة للموظف، ولكن لم يتم اصدار سند صرف مالي ")
                    ' Note: insertion succeeded; keep returning True to indicate DB insert success.
                End If
            End If

            XtraMessageBox.Show(" تم حفظ البيانات بنجاح ")
            Return True
        Catch ex As Exception
            MsgBox("Try Again")
            Return False
        End Try
    End Function

    ' --- New helper: parameterized INSERT that returns the new identity value safely ---
    Private Function InsertEmployeePaymentAndReturnId(paymentDate As Date, employeeId As Integer, amount As Decimal, note As String, paymentType As String, branch As String) As Integer
        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return 0
        End If
        Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        Const sql As String = "
        INSERT INTO [AttEmployeePayments]
            ([PaymentDate],[EmployeeID],[PaymentAmount],[PaymentNote],[PaymentType],[PaymentBranch],[Status])
        OUTPUT INSERTED.[PaymentID]
        VALUES
            (@PaymentDate,@EmployeeID,@PaymentAmount,@PaymentNote,@PaymentType,@PaymentBranch,1);"

        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(sql, con)
                    cmd.Parameters.Add("@PaymentDate", SqlDbType.Date).Value = paymentDate
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = employeeId

                    ' Use Decimal; if your column is MONEY, you can switch to SqlDbType.Money.
                    Dim pAmount = cmd.Parameters.Add("@PaymentAmount", SqlDbType.Decimal)
                    pAmount.Precision = 18
                    pAmount.Scale = 4
                    pAmount.Value = amount

                    cmd.Parameters.Add("@PaymentNote", SqlDbType.NVarChar, -1).Value = If(note, String.Empty)
                    cmd.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 100).Value = If(paymentType, String.Empty)
                    cmd.Parameters.Add("@PaymentBranch", SqlDbType.NVarChar, 100).Value = If(branch, String.Empty)

                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                        CreateDocLog("Document", "", 0, result, "Insert", "Insert Document ", _Now)
                    End If
                End Using
            End Using
        Catch
            ' Swallow and return 0 on failure as per existing code style
        End Try
        Return 0
    End Function

    Private Sub AddNew()
        DateEdit1.DateTime = Today
        Me.SearchEmployee.Text = String.Empty
        Me.TextEditAmount.EditValue = 0
        Me.MemoNotes.ResetText()
        Me.LookUpEditType.Text = String.Empty
        Me.LookUpEditType.EditValue = "Null"
        Me.TextFinancialPayments.EditValue = 0
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        AddNew()
    End Sub

    ' Converts the previous Sub to a Function that returns True if update succeeded, otherwise False.
    Private Function Updating() As Boolean
        If TextFormType.Text <> "Old" Then
            Return False
        End If
        Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Try
            Dim sql As New SQLControl
            Dim PaymentDate As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim EmployeeID As Integer = Convert.ToInt32(Me.SearchEmployee.EditValue)
            Dim PaymentAmount As Decimal = Convert.ToDecimal(Me.TextEditAmount.EditValue)
            Dim PaymentNote As String = If(Me.MemoNotes.Text, String.Empty)
            Dim PaymentType As String = Convert.ToString(Me.LookUpEditType.EditValue)
            Dim Branch As String = " "
            If Not String.IsNullOrEmpty(Me.LookUpEditBranch.Text) Then
                Branch = Me.LookUpEditBranch.Text
            End If

            If GlobalVariables._SystemLanguage = "Arabic" Then
                If PaymentAmount < 1D Then MsgBox("المبلغ خطا") : Return False
                If EmployeeID <= 0 Then MsgBox("الموظف فارغ") : Return False
            Else
                If PaymentAmount < 1D Then MsgBox("Wrong Amount ") : Return False
                If EmployeeID <= 0 Then MsgBox("Empty Employee") : Return False
            End If

            Dim ReferanceNo As Integer = 0
            If GlobalVariables._HRSystemIsConnectedWithAccountingSystem And CheckIfPaymentTypeIsCashPayment(LookUpEditType.EditValue) Then
                ReferanceNo = GetReferanceNoFromEmployeeNo(EmployeeID)
                If ReferanceNo = 0 Then
                    XtraMessageBox.Show(" خطأ: الموظف غير مرتبط بالحساب المالي، لم يتم اصدار السلفة ولم يتم اصدار سند الصرف ")
                    Return False
                End If
            End If

            Dim safeNote As String = PaymentNote.Replace("'", "''")
            Dim safeType As String = PaymentType.Replace("'", "''")
            Dim safeBranch As String = Branch.Replace("'", "''")

            Dim UpdateString As String =
                " UPDATE [AttEmployeePayments]" &
                " SET [PaymentDate] = '" & PaymentDate & "'" &
                "   ,[EmployeeID] = '" & EmployeeID & "'" &
                "   ,[PaymentAmount] = '" & PaymentAmount & "'" &
                "   ,[PaymentNote] = N'" & safeNote & "'" &
                "   ,[PaymentType] = N'" & safeType & "'" &
                "   ,[PaymentBranch] = N'" & safeBranch & "'" &
                " WHERE [PaymentID] = " & TextPaymentID.Text

            Dim updated As Boolean = sql.SqlTrueTimeRunQuery(UpdateString)
            If updated Then

                ' If connected to accounting system, issue the financial document and update the row with DocNo
                If GlobalVariables._HRSystemIsConnectedWithAccountingSystem And CheckIfPaymentTypeIsCashPayment(LookUpEditType.EditValue) Then
                    Dim oldFinancialPaymentId As Integer = Convert.ToInt32(Me.TextFinancialPayments.EditValue)
                    Dim newAmount As Decimal = PaymentAmount
                    If oldFinancialPaymentId > 0 Then
                        UpdateFinancialPaymentDocument(oldFinancialPaymentId, newAmount)
                    Else
                        MsgBoxShowError(" لا يوجد سند صرف مالي ل تعديله ")
                    End If
                    CreateDocLog("Document", "", 3, oldFinancialPaymentId, "Update", "Update Voucher From Hr System ", _Now)

                End If

                CreateDocLog("Document", "", 0, TextPaymentID.Text, "Update", "Update Document ", _Now)
                XtraMessageBox.Show(" تم تعديل البيانات بنجاح ")
            End If
            Return updated
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Private Sub Searching(TextPaymentID As Integer)

        Dim sql As New SQLControl

        Dim SelectString As String = " SELECT  [PaymentID]
                                              ,[PaymentDate]
                                              ,[EmployeeID]
                                              ,[PaymentAmount]
                                              ,[PaymentNote]
                                              ,[PaymentType],[PaymentBranch],[FinancialPaymentDocNo]
                                       FROM [AttEmployeePayments] 
                                        where PaymentID = " & TextPaymentID
        sql.SqlTrueTimeRunQuery(SelectString)

        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaymentDate"))) Then DateEdit1.DateTime = sql.SQLDS.Tables(0).Rows(0).Item("PaymentDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID"))) Then Me.SearchEmployee.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaymentAmount"))) Then Me.TextEditAmount.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("PaymentAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaymentNote"))) Then Me.MemoNotes.Text = sql.SQLDS.Tables(0).Rows(0).Item("PaymentNote")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaymentType"))) Then Me.LookUpEditType.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("PaymentType")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("PaymentBranch"))) Then Me.LookUpEditBranch.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("PaymentBranch")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FinancialPaymentDocNo"))) Then Me.TextFinancialPayments.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("FinancialPaymentDocNo")
        End If


    End Sub

    Private Sub TextPaymentID_EditValueChanged(sender As Object, e As EventArgs) Handles TextPaymentID.EditValueChanged
        AddNew()
        If String.IsNullOrEmpty(TextPaymentID.Text) Then Exit Sub
        If TextPaymentID.EditValue > GetMaxAdvancePayment() Then
            TextFormType.Text = "New"
            TextPaymentID.EditValue = GetMaxAdvancePayment() + 1
        Else
            TextFormType.Text = "Old"
            Searching(TextPaymentID.EditValue)
        End If


    End Sub

    Public Function GetMaxAdvancePayment() As Integer

        Try
            Dim sql As New SQLControl
            Dim SelectString As String = " select max(PaymentID) as MaxID from AttEmployeePayments "
            sql.SqlTrueTimeRunQuery(SelectString)
            Return CInt(sql.SQLDS.Tables(0).Rows(0).Item("MaxID").ToString)
        Catch ex As Exception
            Return 0
        End Try


    End Function

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)
        Updating()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Deleting()
    End Sub

    Private Sub Deleting()
        If TextFormType.Text = "Old" Then

            Try

                If GlobalVariables._SystemLanguage = "Arabic" Then
                    Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد حذف الحركة", "تأكيد", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                Else
                    Dim Msg As DialogResult = XtraMessageBox.Show("Do You Want Delete Trans?", "Are You Sure?", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                End If


                Dim sql As New SQLControl


                Dim UpdateString As String = " Delete from [AttEmployeePayments]                                     
                                           WHERE [PaymentID] = " & TextPaymentID.Text

                If sql.SqlTrueTimeRunQuery(UpdateString) = True Then
                    If GlobalVariables._HRSystemIsConnectedWithAccountingSystem And CheckIfPaymentTypeIsCashPayment(LookUpEditType.EditValue) Then
                        CancelFinancialPaymentDocument(TextFinancialPayments.EditValue)
                    End If
                End If
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try



        End If

    End Sub
    Private Sub CancelFinancialPaymentDocument(DocID As Integer)
        DeleteDoc(3, TextFinancialPayments.EditValue, GetDocCodeByDocID(DocID), True)
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub TextEditAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextEditAmount.MouseUp
        TextEditSelectText(TextEditAmount)
    End Sub

    Private Function IssueFinancialPaymentDocument(DocID As Integer, ReferanceNo As Integer, Amount As Decimal, Notes As String) As Integer
        If Amount <= 0D OrElse ReferanceNo <= 0 Then
            Return 0
        End If

        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return 0
        End If

        Dim docDate As Date = Me.DateEdit1.DateTime.Date


        Dim _Now As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")


        Dim userID As Integer = GlobalVariables.CurrUser
        Dim currencyID As Integer = DefualtCurrencyID

        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand("BuildReceiptFromWEB", con)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.Add("@ReferanceNo", SqlDbType.Int).Value = ReferanceNo
                    cmd.Parameters.Add("@DocDate", SqlDbType.Date).Value = docDate
                    cmd.Parameters.Add("@DocNameID", SqlDbType.Int).Value = 3
                    cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = DocID
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userID
                    cmd.Parameters.Add("@DocNote", SqlDbType.NVarChar, -1).Value = If(Notes, String.Empty)
                    cmd.Parameters.Add("@DeviceName", SqlDbType.NVarChar, -1).Value = Environment.MachineName
                    cmd.Parameters.Add("@CurrencyID", SqlDbType.Int).Value = currencyID
                    cmd.Parameters.Add("@CashAmount", SqlDbType.Float).Value = Convert.ToDouble(Amount)
                    cmd.Parameters.Add("@ChecksAmount", SqlDbType.Float).Value = 0.0

                    ' Always pass an EMPTY TVP (never NULL) to make IF EXISTS return FALSE.
                    Dim emptyCheques As DataTable = CreateEmptyChequesDetailsTvp()
                    Dim tvp As New SqlParameter("@ChequesDetails", SqlDbType.Structured) With {
                        .TypeName = "TVP_Cheques",
                        .Value = emptyCheques
                    }
                    cmd.Parameters.Add(tvp)

                    ' Capture RETURN @FinalDocID
                    Dim ret As New SqlParameter() With {
                        .ParameterName = "@RETURN_VALUE",
                        .SqlDbType = SqlDbType.Int,
                        .Direction = ParameterDirection.ReturnValue
                    }
                    cmd.Parameters.Add(ret)

                    con.Open()
                    cmd.ExecuteNonQuery()

                    Dim finalDocId As Integer = 0
                    If ret.Value IsNot Nothing AndAlso Not Convert.IsDBNull(ret.Value) Then
                        finalDocId = Convert.ToInt32(ret.Value)
                        CreateDocLog("Document", "", 3, finalDocId, "Insert", "Insert Document From HR System ", _Now)
                    End If

                    ' You may want to store/display finalDocId as needed.
                    Return finalDocId
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function
    Private Function UpdateFinancialPaymentDocument(DocID As Integer, Amount As Decimal) As Boolean
        If DocID <= 0 Then
            Return False
        End If
        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return False
        End If
        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand("UPDATE [Journal] SET [DocAmount] = @DocAmount ,
                                                                  [BaseCurrAmount]=@DocAmount,
                                                                  [BaseAmount]=@DocAmount 
                                             WHERE [DocID] = @DocID", con)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = DocID
                    cmd.Parameters.Add("@DocAmount", SqlDbType.Decimal).Value = Amount
                    con.Open()
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try

    End Function


    Private Function GetDocCodeByDocID(DocID As Integer) As String
        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return String.Empty
        End If
        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand(" SELECT TOP(1) IsNull(DocCode, '') As DocCode 
                                              FROM [dbo].[Journal] 
                                              WHERE DocName=3 AND DocID = @DocID", con)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.Add("@DocID", SqlDbType.Int).Value = DocID
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return Convert.ToString(result)
                    End If
                End Using
            End Using
        Catch
            Return String.Empty
        End Try
        Return String.Empty
    End Function


    Private Function CreateEmptyChequesDetailsTvp() As DataTable
        Dim dt As New DataTable()

        ' Must match SQL type: [dbo].[TVP_Cheques]
        dt.Columns.Add("ChequeNo", GetType(String))           ' NVARCHAR(50)
        dt.Columns.Add("ChequeDueDate", GetType(Date))        ' DATE
        dt.Columns.Add("ChequeBank", GetType(Integer))        ' INT
        dt.Columns.Add("ChequeBankBranch", GetType(Integer))  ' INT
        dt.Columns.Add("ChequeAccountNo", GetType(String))    ' NVARCHAR(50)
        dt.Columns.Add("ChequeAmount", GetType(Decimal))      ' DECIMAL(18,2)
        dt.Columns.Add("BankAccount", GetType(Integer))       ' INT

        ' No rows => empty TVP
        Return dt
    End Function
    Private Function GetReferanceNoFromEmployeeNo(EmployeeID As Integer) As Integer
        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return 0
        End If
        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand("SELECT IsNull(SalaryAccountNo, 0) As SalaryAccountNo FROM [dbo].[EmployeesData] WHERE EmployeeID = @EmployeeID", con)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch
            Return 0
        End Try
        Return 0
    End Function

    Private Function CheckIfPaymentTypeIsCashPayment(PaymentTypeID As Integer) As Boolean
        Dim connStr As String = My.Settings("TrueTimeConnectionString")
        If String.IsNullOrWhiteSpace(connStr) Then
            Return False
        End If
        Try
            Using con As New SqlConnection(connStr)
                Using cmd As New SqlCommand("SELECT IsCashPayment FROM [AttPaymentsTypes] WHERE ID = @PaymentID", con)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.Add("@PaymentID", SqlDbType.Int).Value = PaymentTypeID
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        Return Convert.ToBoolean(result)
                    End If
                End Using
            End Using
        Catch
            Return False
        End Try
        Return False
    End Function
End Class