Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class EmployeesEditList
    Private Sub EmployeesDataBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)

        Try
            Me.Validate()
            Me.EmployeesData2BindingSource.EndEdit()
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
            XtraMessageBox.Show("تم الحفظ")
        Catch ex As Exception
            XtraMessageBox.Show("خطأ: لم يتم الحفظ")
        End Try


    End Sub

    Private Sub EmployeesList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData1' table. You can move, or remove it, as needed.
        Me.EmployeesData1TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData1)
        'TODO: This line of code loads data into the 'TrueTimeDataSet.EmployeesData2' table. You can move, or remove it, as needed.
        Me.EmployeesData2TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData2)
        LoadData()
        Me.KeyPreview = True
        RepositoryProcessType.DataSource = CreatPreccessTypeTable()
        Me.RepositoryCurrency.DataSource = GetCurrency()
        If GlobalVariables._HRSystemIsConnectedWithAccountingSystem Then
            RepositoryRefNo.DataSource = GetReferences(-1, 99, -1)
        End If

    End Sub

    Private Sub GridView2_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        Dim gw As GridView = TryCast(sender, GridView)
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub GridView1_CustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs) Handles GridView1.CustomDrawCell

        Dim Man As Image = My.Resources.Man
        Dim Girl As Image = My.Resources.Girl
        Dim Mobile As Image = My.Resources.Mobile
        Dim Phone As Image = My.Resources.Phone
        Dim View As GridView = CType(sender, GridView)
        If e.Column.FieldName = "Gender" Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Gender"))
            If category = "ذكر" Then
                e.Graphics.DrawImage(Man, e.Bounds.Location)
                e.DisplayText = String.Empty
                e.Appearance.Options.CancelUpdate()
            End If
            If category = "أنثى" Then
                e.Graphics.DrawImage(Girl, e.Bounds.Location)
                e.DisplayText = String.Empty
            End If
        End If
        If e.Column.FieldName = "Mobile1" Then e.Graphics.DrawImage(Mobile, e.Bounds.Location)
        If e.Column.FieldName = "PhoneNo" Then e.Graphics.DrawImage(Phone, e.Bounds.Location)
    End Sub
    Private Sub Saving()
        Try

            Me.Validate()
            Me.EmployeesData2BindingSource.EndEdit()           '  
            Me.TableAdapterManager.UpdateAll(Me.TrueTimeDataSet)
            '   Me.TrueTimeDataSet.AcceptChanges()
            XtraMessageBox.Show("تم الحفظ")
        Catch ex As Exception
            XtraMessageBox.Show("خطأ: لم يتم الحفظ")
        End Try
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Saving()
        LoadData()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        LoadData()
    End Sub
    Private Sub LoadData()
        'Me.AttPlaneDurationTableAdapter.Fill(Me.TrueTimeDataSet.AttPlaneDuration)
        Me.EmployeesPositionsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesPositions)
        Me.EmployeesBranchesTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesBranches)
        Me.EmployeesDepartmentsTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesDepartments)
        If CheckEditActive.CheckState = CheckState.Checked Then
            Me.EmployeesData2TableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData2)
        ElseIf CheckEditActive.CheckState = CheckState.Unchecked Then
            '  Me.EmployeesData2TableAdapter.FillByActive(Me.TrueTimeDataSet.EmployeesData, True)
        End If
        GridView1.BestFitColumns()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            LoadData()
            '  ElseIf e.KeyCode = Keys.Insert Then
            '      InsertSub()
            ' ElseIf e.KeyCode = Keys.F12 Then
            '    ShowPrint()
        End If
    End Sub
    'Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
    '    If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
    '        e.Menu = PopupMenu1
    '    End If
    'End Sub

    Private Sub gridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
        If e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then
            e.Allow = False
            PopupMenu1.ShowPopup(EmployeesDataGridControl.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim RowValue As String = GridView1.GetFocusedRowCellValue(GridView1.FocusedColumn.FieldName)

        For i As Integer = 0 To GridView1.RowCount - 1
            ' If GridView1.IsRowVisible(i) Then
            GridView1.SetRowCellValue(i, GridView1.Columns(GridView1.FocusedColumn.FieldName), RowValue)
            '  End If
        Next


    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        GridView1.BestFitColumns()
        EmployeesDataGridControl.ShowPrintPreview()
    End Sub

    Private Sub GridView1_PrintInitialize(sender As System.Object, e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
        pb.PageSettings.LeftMargin = 0
        pb.PageSettings.RightMargin = 0
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Clear()
        Dim sql As New SQLControl
        Dim SQLString As String = "Select *  from CompanyData"
        sql.SqlTrueTimeRunQuery(SQLString)
        If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
        Dim ComName As String = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Footer.Content.AddRange(New String() {String.Empty, String.Empty, "Pages: [Page # of Pages #]"})
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add("بيانات الموظفين")
        TryCast(e.Link.PageHeaderFooter, PageHeaderFooter).Header.Content.Add(ComName)
    End Sub

    Private Sub CheckEditActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditActive.CheckedChanged
        LoadData()
    End Sub


    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditFitColumns.CheckedChanged
        If CheckEditFitColumns.Checked = True Then
            Me.GridView1.OptionsView.ColumnAutoWidth = True
        Else
            GridView1.OptionsView.ColumnAutoWidth = False
        End If
        GridView1.BestFitColumns()
    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        GridView1.SelectAll()
        GridView1.CopyToClipboard()
        XtraMessageBox.Show("تم نسخ البيانات")
    End Sub
    Private Sub YourFormName_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        ' Display a confirmation dialog to the user
        Dim result As DialogResult = MessageBox.Show(" هل تريد حفظ التعديلات ",
                                                     "تاكيد",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question)

        ' If the user clicks 'No', cancel the closing operation
        If result = DialogResult.Yes Then
            Saving()

        End If



    End Sub
End Class