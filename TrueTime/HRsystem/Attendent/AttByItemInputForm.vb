Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class AttByItemInputForm
    Private Sub AttByQuantityBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.AttByQuantityBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)

    End Sub

    Private Sub AttByItemInputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateEdit1.DateTime = Today
        'TODO: This line of code loads data into the 'TrueTimeDataSet.AttByQuantity' table. You can move, or remove it, as needed.
        ' Me.AttByQuantityTableAdapter.Fill(Me.TrueTimeDataSet.AttByQuantity)
        GetEmployees()

    End Sub

    Private Sub BindingNavigatorDeleteItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            Dim i As Integer
            For i = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(i, "TransDate", Format(DateEdit1.DateTime, "yyyy-MM-dd"))
            Next
            Me.Validate()
            Me.AttByQuantityBindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
            MsgBoxShowSuccess(" تم حفظ البيانات بنجاح ")
        Catch ex As Exception
            MsgBoxShowError(" لم يتم حفظ البيانات بنجاح ")
        End Try
    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        If Me.IsHandleCreated Then
            'If GridView1.RowCount > 1 Then
            '    XtraMessageBox.Show(" سيتم  ")
            'End If
            Me.AttByQuantityTableAdapter.FillByTransDate(Me.TrueTimeDataSet.AttByQuantity, DateEdit1.DateTime)
        End If

    End Sub
    Private Sub GetEmployees()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery(" select [EmployeeID],[EmployeeName] from [dbo].[EmployeesData]  ")
            RepositoryItemLookUpEdit1.DataSource = sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        'Dim gw As GridView = TryCast(sender, GridView)
        'If e.RowHandle >= 0 Then
        '    e.Info.DisplayText = (e.RowHandle + 1).ToString
        'End If


        GridView1.IndicatorWidth = 50
        ' Handle this event to paint RowIndicator manually
        If Not e.Info.IsRowIndicator Then
            Return
        End If
        Dim view As GridView = TryCast(sender, GridView)
        e.Handled = True

        e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, DXSkinColors.FillColors.Danger, DXSkinColors.FillColors.Success)
        e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
        If e.Info.ImageIndex < 0 Then
            Return
        End If
        Dim ic As ImageCollection = TryCast(e.Info.ImageCollection, ImageCollection)
        Dim indicator As Image = ic.Images(e.Info.ImageIndex)
        e.Cache.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))

        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If

    End Sub

    Private Sub RepositoryDelete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryDelete.ButtonClick
        GridView1.DeleteRow(GridView1.FocusedRowHandle)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GridView1.PasteFromClipboard()
    End Sub
End Class