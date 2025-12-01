Imports DevExpress.XtraEditors
Imports System.ComponentModel

Public Class AttBonus
    Private Sub AttAdvancePayment_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttAdditionsTypes' table. You can move, or remove it, as needed.
        Me.AttAdditionsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttAdditionsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttPaymentsTypes' table. You can move, or remove it, as needed.
        '   Me.AttPaymentsTypesTableAdapter.Fill(Me.TrueTimeDataSet.AttPaymentsTypes)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        Me.KeyPreview = True
        SearchEmployee.Select()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            SaveData()
        End If
    End Sub
    Private Sub SimpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SimpleButton1.Click

        SaveData()
    End Sub
    Private Sub SaveData()
        If String.IsNullOrEmpty(Me.SearchEmployee.Text) Or String.IsNullOrEmpty(Me.TextEditAmount.Text) Or String.IsNullOrEmpty(Me.LookUpEditType.Text) Then
            If GlobalVariables._SystemLanguage = "Arabic" Then
                MsgBox("يجب تعبئة البيانات المطلوبة")
                Exit Sub
            Else
                MsgBox("You Should Fill All Required Fields")
                Exit Sub
            End If
        End If

        If Me.LookUpEditType.Text = "" Then
            XtraMessageBox.Show("يجب اختيار النوع")
            Exit Sub
        End If

        If GlobalVariables._SystemLanguage = "Arabic" Then
            If Me.TextEditAmount.EditValue < 1 Then MsgBox("المبلغ خطا") : Exit Sub
        Else
            If Me.TextEditAmount.EditValue < 1 Then MsgBox("Amount Error") : Exit Sub
        End If

        If TextAdditionsID.EditValue <= GetMaxAdvancePayment() And TextAdditionsID.EditValue > 0 Then
            Updating()
        End If

        If TextFormType.Text = "New" Then
            Inserting()
        End If
        AddNew()
        Me.TextAdditionsID.Text = GetMaxAdvancePayment() + 1

        '   Me.Close()




        ' Inserting()
    End Sub
    Private Sub Inserting()

        Try


            Dim sql As New SQLControl
            Dim PaymentDate As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim EmployeeID As Integer = Me.SearchEmployee.EditValue
            Dim PaymentAmount As Decimal = Me.TextEditAmount.EditValue
            Dim PaymentNote As String = Me.MemoNotes.Text
            Dim PaymentType As String = Me.LookUpEditType.EditValue





            Dim InsertString As String = " INSERT INTO [AttEmployeeAdditions]
           ([AdditionDate]
           ,[EmployeeID]
           ,[AdditionAmount]
           ,[AdditionNote]
           ,[AdditionType])
            VALUES
           ('" & PaymentDate & "'
           ,'" & EmployeeID & "'
           ," & PaymentAmount & "
           ,N'" & PaymentNote & "'
           ,N'" & PaymentType & "')"

            If sql.SqlTrueTimeRunQuery(InsertString) = True Then
                XtraMessageBox.Show(" تم حفظ البيانات بنجاح ")
                ' Me.Dispose()
            End If
        Catch ex As Exception
            MsgBox("الرجاء اعادة المحاولة")
        End Try


    End Sub


    Private Sub AddNew()
        DateEdit1.DateTime = Today
        Me.SearchEmployee.Text = String.Empty
        Me.TextEditAmount.EditValue = 0
        Me.MemoNotes.ResetText()
        Me.LookUpEditType.Text = String.Empty
        Me.LookUpEditType.EditValue = "Null"
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        AddNew()
    End Sub

    Private Sub Updating()
        If TextFormType.Text = "Old" Then

            Dim sql As New SQLControl
            Dim PaymentDate As String = Format(DateEdit1.DateTime, "yyyy-MM-dd")
            Dim EmployeeID As Integer = Me.SearchEmployee.EditValue
            Dim PaymentAmount As Decimal = Me.TextEditAmount.EditValue
            Dim PaymentNote As String = Me.MemoNotes.Text
            Dim PaymentType As String = Me.LookUpEditType.EditValue

            If GlobalVariables._SystemLanguage = "Arabic" Then
                If PaymentAmount < 1 Then MsgBox("المبلغ خطا") : Exit Sub
                If String.IsNullOrEmpty(EmployeeID) Then MsgBox("الموظف فارغ") : Exit Sub
            Else
                If PaymentAmount < 1 Then MsgBox("Amount Error") : Exit Sub
                If String.IsNullOrEmpty(EmployeeID) Then MsgBox("Empty Employee") : Exit Sub
            End If


            Dim UpdateString As String = " UPDATE [AttEmployeeAdditions]
                                       SET   [AdditionDate] = '" & PaymentDate & "'
                                            ,[EmployeeID] = '" & EmployeeID & "'
                                            ,[AdditionAmount] ='" & PaymentAmount & "'
                                            ,[AdditionNote] =N'" & PaymentNote & "'
                                            ,[AdditionType] = N'" & PaymentType & "'
            WHERE([AdditionID] = " & TextAdditionsID.Text & ")"

            If sql.SqlTrueTimeRunQuery(UpdateString) = True Then
                XtraMessageBox.Show(" تم تعديل البيانات بنجاح ")
                ' Me.Dispose()
            End If

        End If

    End Sub

    Private Sub Searching(ByVal TextPaymentID As Integer)

        Dim sql As New SQLControl

        Dim SelectString As String = " SELECT  [AdditionID],[AdditionDate],[EmployeeID] ,[AdditionAmount] ,[AdditionNote],[AdditionType]
        FROM [AttEmployeeAdditions]
        where AdditionID = " & TextPaymentID & String.Empty
        sql.SqlTrueTimeRunQuery(SelectString)

        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AdditionDate"))) Then DateEdit1.DateTime = sql.SQLDS.Tables(0).Rows(0).Item("AdditionDate")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID"))) Then Me.SearchEmployee.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("EmployeeID")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AdditionAmount"))) Then Me.TextEditAmount.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AdditionAmount")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AdditionNote"))) Then Me.MemoNotes.Text = sql.SQLDS.Tables(0).Rows(0).Item("AdditionNote")
            If Not (IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AdditionType"))) Then Me.LookUpEditType.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AdditionType")
        End If


    End Sub

    Private Sub TextPaymentID_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextAdditionsID.EditValueChanged
        AddNew()

        If String.IsNullOrEmpty(TextAdditionsID.Text) Then Exit Sub
        If TextAdditionsID.EditValue > GetMaxAdvancePayment() Then
            TextFormType.Text = "New"
            TextAdditionsID.EditValue = GetMaxAdvancePayment() + 1
        Else
            TextFormType.Text = "Old"
            Searching(TextAdditionsID.EditValue)
        End If

        If GetMaxAdvancePayment() = 0 Then TextFormType.Text = "New"

    End Sub

    Public Function GetMaxAdvancePayment() As Integer

        Try
            Dim sql As New SQLControl
            Dim SelectString As String = " select max(AdditionID) as MaxID from [AttEmployeeAdditions] "
            sql.SqlTrueTimeRunQuery(SelectString)
            Return CInt(sql.SQLDS.Tables(0).Rows(0).Item("MaxID").ToString)
        Catch ex As Exception
            Return 0
        End Try


    End Function

    Private Sub SimpleButton2_Click_1(ByVal sender As Object, ByVal e As EventArgs)
        Updating()
    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SimpleButton3.Click
        Deleting()
    End Sub

    Private Sub Deleting()
        If TextFormType.Text = "Old" Then

            Try

                If GlobalVariables._SystemLanguage = "Arabic" Then
                    Dim Msg As DialogResult = XtraMessageBox.Show("هل تريد حذف الحركة", "تأكيد", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                Else
                    Dim Msg As DialogResult = XtraMessageBox.Show("Do you want delete trans.", "Are you sure", MessageBoxButtons.YesNo)
                    If Msg = System.Windows.Forms.DialogResult.No Then Exit Sub
                End If


                Dim sql As New SQLControl


                Dim UpdateString As String = " Delete from [AttEmployeeAdditions] 
                WHERE([AdditionID] = " & TextAdditionsID.Text & ")"

                sql.SqlTrueTimeRunQuery(UpdateString)
                Me.Close()
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try



        End If

    End Sub

    Private Sub SearchEmployee_EditValueChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub SearchLookUpEdit1_QueryPopUp(sender As Object, e As CancelEventArgs)
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
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
End Class