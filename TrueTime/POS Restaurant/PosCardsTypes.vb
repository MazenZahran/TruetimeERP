Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class PosCardsTypes
    Dim Con As SqlConnection
    Dim MethodsAdapter As SqlDataAdapter
    Dim DS As DataSet
    Private Sub PosPaidMethodsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        'Me.Validate()
        'Me.PosPaidMethodsBindingSource.EndEdit()
        'Me.TableAdapterManager.UpdateAll(Me.AccountingDataSet)
    End Sub

    Private Sub PosCardsTypes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AccountingDataSet.PosPaidMethods' table. You can move, or remove it, as needed.
        '   Me.PosPaidMethodsTableAdapter.FillBy(Me.AccountingDataSet.PosPaidMethods)
        GetMethodsTables()
        RepositoryItemLookUpEdit1.DataSource = GetFinancialAccounts(-1, -1, False, -1, -1)
    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub GetMethodsTables()
        Try
            Con = New SqlConnection(My.Settings.TrueTimeConnectionString)
            Con.Open()
            MethodsAdapter = New SqlDataAdapter(" select MethodNo,PaidMethodName,AccountNO,IsDefualt,0 from PosPaidMethods order by  MethodNo", Con)
            DS = New System.Data.DataSet()
            MethodsAdapter.Fill(DS, "PosPaidMethods")
            GridControl1.DataSource = DS.Tables(0)
        Catch __unusedException1__ As Exception
            Throw
        End Try
    End Sub
    Private Sub SavingMethodsTables()
        Try
            Dim SqlCommBuil As SqlCommandBuilder
            SqlCommBuil = New SqlCommandBuilder(MethodsAdapter)
            MethodsAdapter.Update(DS, "PosPaidMethods")
            'MsgBoxShowSuccess(" تم حفظ البيانات ")
        Catch ex As Exception

        End Try
        GetMethodsTables()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SavingMethodsTables()
        Me.Close()
    End Sub

    Private Sub GridView1_EditFormHidden(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormHiddenEventArgs) Handles GridView1.EditFormHidden
        'Dim textEdit As TextEdit = TryCast(e.BindableControls(ColPaidMethodName), TextEdit)
        'If TextEdit IsNot Nothing Then
        '    'RemoveHandler textEdit.EditValueChanging, AddressOf TextEdit_EditValueChanging
        'End If
        If e.Result = EditFormResult.Update Then
            SavingMethodsTables()
        End If

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.FocusedRowHandle = GridControl.NewItemRowHandle
        GridView1.ShowEditForm()
    End Sub
    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) _
Handles GridView1.ValidateRow
        Dim View As GridView = CType(sender, GridView)
        Dim methodnameCol As GridColumn = View.Columns("PaidMethodName")
        Dim accountCol As GridColumn = View.Columns("AccountNO")
        'Get the value of the first column
        If IsDBNull(View.GetRowCellValue(e.RowHandle, methodnameCol)) Then
            Exit Sub
        End If
        If IsDBNull(View.GetRowCellValue(e.RowHandle, accountCol)) Then
            Exit Sub
        End If
        Dim inSt As String = CType(View.GetRowCellValue(e.RowHandle, methodnameCol), String)
        'Get the value of the second column
        Dim onOrd As String = CType(View.GetRowCellValue(e.RowHandle, accountCol), String)
        'Validity criterion
        If String.IsNullOrEmpty(inSt) Or String.IsNullOrEmpty(onOrd) Then
            e.Valid = False
            'Set errors with specific descriptions for the columns
            View.SetColumnError(methodnameCol, " الاسم فارغ ")
            View.SetColumnError(accountCol, " الحساب فارغ ")
        End If
        If e.Valid Then
            View.ClearColumnErrors()
        End If
    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        GridView1.DeleteSelectedRows()
    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        Dim i As Integer
        For i = 0 To GridView1.RowCount - 1
            GridView1.SetRowCellValue(i, "IsDefualt", 0)
        Next
        GridView1.SetFocusedRowCellValue("IsDefualt", 1)
    End Sub
End Class