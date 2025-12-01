Public Class ShishaDefineNewExpenseWithPercentage
    Private _ID As Integer
    Public Sub New(ID As Integer)
        _ID = ID
        InitializeComponent()
    End Sub
    Private Sub SearchItemsCategories_Properties_AddNewValue(sender As Object, e As DevExpress.XtraEditors.Controls.AddNewValueEventArgs) Handles txtCategoryID.Properties.AddNewValue

    End Sub

    Private Sub SearchItemsCategories_Properties_BeforePopup(sender As Object, e As EventArgs) Handles txtCategoryID.Properties.BeforePopup
        'h
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If String.IsNullOrEmpty(txtAccountNo.Text) Then
            MsgBox("يجب اختيار حساب الصرف", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "خطأ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(txtCategoryID.Text) Then
            MsgBox("يجب اختيار حساب الصرف", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "خطأ")
            Exit Sub
        End If

        Dim _PercantageFromSales As Integer = 0
        If CheckPercantageFromSales.Checked = True Then
            _PercantageFromSales = 1
        Else
            _PercantageFromSales = 0
        End If

        If txtPercantage.Text = "" Then txtPercantage.EditValue = 0

        Dim sql As New SQLControl
        Dim sqlstring As String
        Select Case _ID
            Case 0, -1
                sqlstring = "insert into Samba_ShishaExpensesAllocationDefine 
                                 (AccountNo,CategoryID,Percantage,PercantageFromSales) values ('" & txtAccountNo.EditValue & "'," & txtCategoryID.EditValue & "," & txtPercantage.EditValue & "," & _PercantageFromSales & ")"
                sql.SqlTrueAccountingRunQuery(sqlstring)
            Case Else
                sqlstring = "update Samba_ShishaExpensesAllocationDefine set AccountNo='" & txtAccountNo.EditValue & "',CategoryID=" & txtCategoryID.EditValue & ",Percantage=" & txtPercantage.EditValue & ",PercantageFromSales=" & _PercantageFromSales & " where ID=" & _ID
                sql.SqlTrueAccountingRunQuery(sqlstring)
        End Select

        Me.Close()
    End Sub

    Private Sub ShishaDefineNewExpenseWithPercentage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.txtAccountNo.Properties.DataSource = GetFinancialAccounts(-1, -1, False, True, 8) ' المصاريف
        txtCategoryID.Properties.DataSource = GetItemsCategories()
        Me.Text = _ID
        If _ID = -1 Then
            Me.txtAccountNo.Select()
        Else
            Me.txtPercantage.Select()
        End If

    End Sub

    Private Sub txtPercantage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPercantage.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    BtnSave_Click(sender, e)
        'End If
    End Sub
End Class