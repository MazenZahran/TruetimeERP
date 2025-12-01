Imports DevExpress.XtraEditors

Public Class FinancialAccountsAddNewAccount
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Select Case TextInsertUpdate.EditValue
            Case "Insert"
                SaveData("Insert")
            Case "Update"
                SaveData("Update")
        End Select
    End Sub
    Private Sub SaveData(InsertUpdate As String)
        If String.IsNullOrEmpty(TextAccNo.Text) Then
            XtraMessageBox.Show("يجب تعبئة رقم الحساب", "تنبيه!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextAccNo.Text) Then
            XtraMessageBox.Show("يجب تعبئة العملة", "تنبيه!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextAccNo.Text) Then
            XtraMessageBox.Show("يجب تعبئة العملة", "تنبيه!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim _Account As New FinancialAccount
        _Account.AccountNo = TextAccNo.Text
        _Account.AccountName = TextAccName.Text
        _Account.Currency = TextCurrency.EditValue
        _Account.FatherAccount = TextFatherAccName.EditValue
        _Account.FinancialStatment = TextFinancialStatment.EditValue
        _Account.FinancialSector = TextFinancialSector.EditValue
        _Account.AccType = SearchAccType.EditValue
        _Account.IsActive = CheckIsActive.Checked
        _Account.HasTrans = _Account.CheckHasTrans(TextAccNo.Text)
        _Account.NeedCostCenter = Me.CheckNeedCostCenter.EditValue
        FinanicialAccountsVariable.IsInserted = False
        Select Case InsertUpdate
            Case "Insert"
                Try
                    Dim Sql As New SQLControl
                    Sql.SqlTrueAccountingRunQuery("Select [AccNo] from [dbo].[FinancialAccounts] where AccNo='" & TextAccNo.EditValue & "'")
                    If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("AccNo")) Then
                        MsgBox("الحساب موجود لا يمكن الحفظ")
                        FinanicialAccountsVariable.IsInserted = False
                        Exit Sub
                    End If
                Catch ex As Exception
                End Try
                If _Account.InsertAccount() = True Then
                    XtraMessageBox.Show("تم اضافة الحساب")
                    _Account.GetAccountData(TextAccNo.Text)
                    FinanicialAccountsVariable.IsInserted = True
                    FinanicialAccountsVariable.AccountNo = TextAccNo.Text
                    'If CheckIsActive.Checked = True Then
                    '    _Active = "فعال"
                    'Else
                    '    _Active = "موقوف"
                    'End If
                    ' Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = FinancialAccountsList.TreeList1.AppendNode(nodeData:=New Object() {TextAccNo.Text,
                    ' 1, TextAccName.Text, TextFatherAccName.Text, 1, 1, 1, 1, _Active, TextCurrency.Text}, parentNode:=FinancialAccountsList.TreeList1.FocusedNode)
                    ' FinancialAccountsList.TreeList1.FocusedNode = newNode
                    Me.Close()
                Else
                    XtraMessageBox.Show("خطا، لم يتم اضافة الحساب", "خطا", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
                    FinanicialAccountsVariable.IsInserted = False
                End If
            Case "Update"
                If _Account.UpdateAccount(TextAccNo.Text) = True Then
                    XtraMessageBox.Show("تم تعديل الحساب")
                    FinanicialAccountsVariable.IsUpdated = True
                    Me.Close()
                Else
                    XtraMessageBox.Show("خطا، لم يتم التعديل", "خطا", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
                End If
        End Select

        'Try
        'Dim SqlString As String
        '    Dim Sql As New SQLControl
        '    Dim _AccName, _FatherAccount As String
        '    Dim _IsActive As Boolean
        '    Dim _FinancialStatment, _FinancialSector, _Currency As Integer
        '    _AccName = Me.TextAccName.Text
        '    _FinancialStatment = TextFinancialStatment.EditValue
        '    _FinancialSector = TextFinancialSector.EditValue
        '    _Currency = Me.TextCurrency.EditValue
        '    _IsActive = Me.CheckIsActive.Checked
        '    _FatherAccount = Me.TextFatherAccName.EditValue

        '    If String.IsNullOrEmpty(_AccName) Or IsNothing(_FinancialStatment) Or IsNothing(_FinancialSector) Or IsNothing(_Currency) Or IsNothing(Me.TextAccNo.Text) Then
        '        XtraMessageBox.Show("يجب تعبئة كل البيانات", "تعديل", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    SqlString = " Update FinancialAccounts
        '              Set AccName= N'" & _AccName & "',FinancialStatment= " & _FinancialStatment & ",
        '              FinancialSector= " & _FinancialSector & " , Currency=" & _Currency & " , [IsActive]='" & _IsActive & "' , [FatherAccount]='" & _FatherAccount & "' where AccNo='" & Me.TextAccNo.Text & "'"
        '    If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
        '        XtraMessageBox.Show("تم التعديل", "تعديل", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information)
        '    Else
        '        XtraMessageBox.Show("خطا، لم يتم التعديل", "خطا", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub

    Private Sub FinancialAccountsAddNewAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.TextFatherAccName.Properties.DataSource = GetFinancialAccountsTable()
        'GetFinancialSectors()
        'GetFinancialStatementNames()
        'TextCurrency.Properties.DataSource = GetCurrency()
        'SearchAccType.Properties.DataSource = GetAccTypes(-1)
    End Sub
    Public Sub GetFinancialSectors()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " SELECT [SectorID],[SectorName]
  FROM [FinancialParts] S
  left join [FinancialStatementNames] N on S.[FinancialStatmentID]=N.ID
order by SectorID"
        sql.SqlTrueAccountingRunQuery(SqlString)
        TextFinancialSector.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Public Sub GetFinancialStatementNames()
        Dim sql As New SQLControl
        Dim SqlString As String
        SqlString = " Select [ID],[FinancialStatementName] From [FinancialStatementNames]  "
        sql.SqlTrueAccountingRunQuery(SqlString)
        Me.TextFinancialStatment.Properties.DataSource = sql.SQLDS.Tables(0)
    End Sub
    Public Function GetFinancialAccountsTable() As DataTable
        Dim FinancialAccounts As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select F.[AccNo]  as ID, F.[AccID],F.[AccName],FF.AccName as FatherAccName,
F.[Currency],F.[FinancialStatment],F.[FinancialSector],
F.[AccType],F.[FatherAccount] as ParentID,F.[IsMain],F.[IsActive]
From [FinancialAccounts] F
left join FinancialAccounts FF on F.FatherAccount=FF.AccNo  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            FinancialAccounts = Sql.SQLDS.Tables(0)
            '  Me.TreeList1.BestFitColumns()
        Catch ex As Exception

        End Try

        Return FinancialAccounts
    End Function

    Private Sub TextAccNo_EditValueChanged(sender As Object, e As EventArgs) Handles TextAccNo.EditValueChanged
        'If Not String.IsNullOrEmpty(TextAccNo.Text) Then
        '    Dim _Account As New FinancialAccount
        '    If _Account.GetAccountData(TextAccNo.Text) = True Then
        '        'TextAccName.Text = _Account.AccountName
        '        'TextCurrency.EditValue = _Account.Currency
        '        'TextFatherAccName.EditValue = _Account.FatherAccount
        '        'TextFinancialStatment.EditValue = _Account.FinancialStatment
        '        'TextFinancialSector.EditValue = _Account.FinancialSector
        '        'SearchAccType.EditValue = _Account.AccType
        '        'CheckIsActive.Checked = _Account.IsActive
        '        TextInsertUpdate.Text = "Update"
        '    Else
        '        '_Account = Nothing
        '        'TextAccName.Text = ""
        '        'TextCurrency.EditValue = ""
        '        'TextFatherAccName.EditValue = ""
        '        'TextFinancialStatment.EditValue = ""
        '        'TextFinancialSector.EditValue = ""
        '        'SearchAccType.EditValue = ""
        '        'CheckIsActive.Checked = True
        '        TextInsertUpdate.Text = "Insert"
        '    End If
        'End If
    End Sub

    Private Sub TextAccNo_Validated(sender As Object, e As EventArgs) Handles TextAccNo.Validated

    End Sub

    Private Sub TextFinancialSector_BeforePopup(sender As Object, e As EventArgs) Handles TextFinancialSector.BeforePopup
        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT [SectorID],[SectorName]
                      FROM [FinancialParts] S
                      left join [FinancialStatementNames] N on S.[FinancialStatmentID]=N.ID Where S.FinancialStatmentID= " & TextFinancialStatment.EditValue & "
                      order by SectorID"
            sql.SqlTrueAccountingRunQuery(SqlString)
            TextFinancialSector.Properties.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        Dim _AccountNo As Object = TextAccNo.Text
        Dim _AccName As Object = TextAccName.Text
        Dim _Account As New FinancialAccount
        Dim msg As String = String.Format(" سيت حذف الحساب {0} ، هل تريد الاستمرار؟", _AccName)
        If _Account.GetAccountData(_AccountNo) <> True Then
            XtraMessageBox.Show("خطأ: بيانات الحساب غير متوفرة ، لا يمكن الحذف")
            Exit Sub
        End If
        If _Account.CheckHasTrans(_AccountNo) = True Then
            XtraMessageBox.Show("خطأ: يوجد حركات على الحساب، لا يمكن الحذف")
            Exit Sub
        End If
        If _Account.IsFatherAccount(_AccountNo) = True Then
            XtraMessageBox.Show("خطأ: حساب أب ، لا يمكن الحذف")
            Exit Sub
        End If
        If XtraMessageBox.Show(msg, "Deleting node", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No Then
            XtraMessageBox.Show("لم يتم حذف الحساب")
            Exit Sub
        End If
        If _Account.DeleteAccount(_AccountNo) = True Then
            Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
            Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
            Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حذف الحساب ", "تأكيد الحذف", New DialogResult() {DialogResult.OK}, icon, 0)
            XtraMessageBox.Show(args)
            FinanicialAccountsVariable.IsDeleted = True
            Me.Close()
        Else
            FinanicialAccountsVariable.IsDeleted = False
        End If

        'Dim _Account As New FinancialAccount
        'Dim msg As String = String.Format(" سيت حذف الحساب {0} ، هل تريد الاستمرار؟", TextAccName.Text)
        'If XtraMessageBox.Show(msg, "سيتم حذف الحساب، هل تريد الاستمرار", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
        '    If _Account.DeleteAccount(TextAccNo.Text) = True Then
        '        Dim bitmap As Bitmap = New Bitmap(My.Resources.ok_32px)
        '        Dim icon As Icon = Icon.FromHandle(bitmap.GetHicon())
        '        Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs(Me, "تم حذف الحساب ", "تأكيد الحذف", New DialogResult() {DialogResult.OK}, icon, 0)
        '        XtraMessageBox.Show(args)
        '        FinanicialAccountsVariable.IsDeleted = True
        '        Me.Close()
        '    Else
        '        FinanicialAccountsVariable.IsDeleted = False
        '    End If
        'End If
        'FinancialAccountsList.DeleteAccount()

    End Sub
End Class