Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class AttManualAddTrans


    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        Else
            Exit Sub
        End If
        e.SuppressKeyPress = True 'this will prevent ding sound 


    End Sub

    Private Sub AttManualAddTrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        'TODO: This line of code loads data into the 'TrueTimeDataSet.CheckTypes' table. You can move, or remove it, as needed.

        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttCHECKINOUT' table. You can move, or remove it, as needed.
        Me.AttCHECKINOUTTableAdapter.FillByTransID(Me.TrueTimeDataSet.AttCHECKINOUT, -1)
        DateEditTrans.DateTime = Today



        'If GlobalVariables._SystemLanguage = "Arabic" Then
        '    RepositoryItemLookUpEdit1
        'Else

        'End If


        If GlobalVariables._SystemLanguage = "Arabic" Then
            RepositoryItemLookUpEdit1.Columns("InEnglish").Visible = False
            RepositoryItemLookUpEdit1.DisplayMember = "InArabic"
        ElseIf GlobalVariables._SystemLanguage = "English" Then
            RepositoryItemLookUpEdit1.Columns("InArabic").Visible = False
            RepositoryItemLookUpEdit1.DisplayMember = "InEnglish"
        End If

        Me.CheckTypesTableAdapter.Fill(Me.TrueTimeDataSet.CheckTypes)

        DateEditTrans.Select()
    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow

        Try
            Me.GridView1.SetRowCellValue(e.RowHandle, "CHECKTIME", Format(DateEditTrans.DateTime, "yyyy-MM-dd HH:mm"))
            '  Me.GridView1.SetRowCellValue(e.RowHandle, "CHECKTYPE", 0)
            Me.GridView1.SetRowCellValue(e.RowHandle, "Edited", "True")
            Me.GridView1.SetRowCellValue(e.RowHandle, "EditedDate", Format(Now, "yyyy-MM-dd HH:mm"))
            Me.GridView1.SetRowCellValue(e.RowHandle, "EditedType", "Insert")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RepositoryItemButtonEditDelete_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEditDelete.Click
        Try
            Me.AttCHECKINOUTBindingSource.RemoveCurrent()
        Catch ex As Exception
            MsgBox("لا يمكن حذف الحركة")
        End Try

    End Sub

    Private Sub SimpleButtonSave_Click(sender As Object, e As EventArgs) Handles SimpleButtonSave.Click
        Try
            Me.Validate()
            Me.AttCHECKINOUTBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
            Me.AttCHECKINOUTTableAdapter.FillByTransID(Me.TrueTimeDataSet.AttCHECKINOUT, -1)


            If GlobalVariables._SystemLanguage = "Arabic" Then
                MsgBox("تم حفظ الحركات")
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                MsgBox("Data Saved")
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DateEditTrans_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditTrans.EditValueChanged

        Try

            Dim Count As Integer = GridView1.RowCount
            If GlobalVariables._SystemLanguage = "Arabic" Then
                If Count > 1 Then MsgBox("سيتم تعديل " & Count - 1)
            ElseIf GlobalVariables._SystemLanguage = "English" Then
                If Count > 1 Then MsgBox("Edit Trans? " & Count - 1)
            End If

            Dim Time As String
            For i = 0 To Count - 1
                Time = Format(CDate(Me.GridView1.GetRowCellValue(i, colCHECKTIME)), "HH:mm")
                GridView1.SetRowCellValue(i, colCHECKTIME, Format(DateEditTrans.DateTime, "yyyy-MM-dd") & " " & Time)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub view_ValidateRow(ByVal sender As Object, ByVal e As ValidateRowEventArgs) Handles GridView1.ValidateRow

        Try


            Dim view As ColumnView = TryCast(sender, ColumnView)
            Dim column1 As GridColumn = view.Columns("USERID")

            Dim EmployeeError, TimeError, TypeError As String
            If GlobalVariables._SystemLanguage = "Arabic" Then
                EmployeeError = "ألموظف فارغ"
                TimeError = "الوقت فارغ"
                TypeError = "نوع الحركة فارغ"
            Else GlobalVariables._SystemLanguage = "English"
                EmployeeError = "Empty Employee"
                TimeError = "Empty Time"
                TypeError = "Trans. Type Empty"
            End If


            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "USERID")) Then

                e.Valid = False
                e.ErrorText = EmployeeError
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = view.Columns("USERID")
                view.ShowEditor()
            End If

            If Format(CDate((Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CHECKTIME"))), "HH:mm") = "00:00" Then
                e.Valid = False
                e.ErrorText = TimeError
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = view.Columns("CHECKTIME")
                view.ShowEditor()
            End If

            If IsDBNull(Me.GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CHECKTYPE")) Then
                e.Valid = False
                e.ErrorText = TypeError
                view.FocusedRowHandle = e.RowHandle
                view.FocusedColumn = view.Columns("CHECKTYPE")
                view.ShowEditor()
            End If

        Catch ex As Exception

        End Try




    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

End Class