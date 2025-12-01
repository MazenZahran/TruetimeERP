Imports DevExpress.Pdf.ContentGeneration.Interop
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraTreeList.Columns
Imports DevExpress.XtraTreeList.Nodes
Imports DocumentFormat.OpenXml.Drawing

Public Class EmployeesTreeList

    Private Sub EmployeesTreeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeList1.StateImageList = ImageCollection2
        Me.TreeList1.DataSource = GetFinancialAccountsTable()
        TreeList1.ExpandToLevel(0)
        'TreeList1.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True

        'TreeList1.OptionsView.TreeLineStyle = LineStyle.Percent50 ' // Solid, Light, Dark, Wide, Large

        Me.KeyPreview = True
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            RefreshData()
        ElseIf e.KeyCode = Keys.Insert Then
            InsertNewAccount()
        End If
    End Sub
    Private Function GetFinancialAccountsTable() As DataTable
        Dim FinancialAccounts As New DataTable

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select F.[EmployeeID]  as ID,F.[EmployeeName],FF.EmployeeName as FatherAccName,
F.[Branch],
F.[ManagerID] as ParentID
From [EmployeesData] F
left join EmployeesData FF on F.ManagerID=FF.EmployeeID  where F.[Active]=1 "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            FinancialAccounts = Sql.SQLDS.Tables(0)
        Catch ex As Exception

        End Try

        Return FinancialAccounts
    End Function
    Private Sub treeList1_CustomDrawNodeCell(ByVal sender As Object, ByVal e As CustomDrawNodeCellEventArgs) Handles TreeList1.CustomDrawNodeCell
        Dim treeList As TreeList = TryCast(sender, TreeList)
        'If e.Node.Id <> DevExpress.XtraTreeList.TreeList.NewItemNodeId AndAlso treeList.GetRowCellValue(e.Node, e.Column).ToString() = "موقوف" Then
        '    e.Cache.DrawImage(ImageCollection1.Images(0), e.Bounds.X + 1, e.Bounds.Y + 1)
        'End If
        'If e.Node.Id <> DevExpress.XtraTreeList.TreeList.NewItemNodeId AndAlso treeList.GetRowCellValue(e.Node, e.Column).ToString() = "فعال" Then
        '    e.Cache.DrawImage(ImageCollection1.Images(1), e.Bounds.X + 1, e.Bounds.Y + 1)
        'End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "1000000000" Then
            e.Node.StateImageIndex = 0
        End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "2000000000" Then
            e.Node.StateImageIndex = 1
        End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "3000000000" Then
            e.Node.StateImageIndex = 2
        End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "4000000000" Then
            e.Node.StateImageIndex = 3
        End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "5000000000" Then
            e.Node.StateImageIndex = 4
        End If
        If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("ID")) = "6000000000" Then
            e.Node.StateImageIndex = 5
        End If
        'If treeList.GetRowCellDisplayText(e.Node, TreeList1.Columns("IsActive")) = "فعال" Then
        '    e.Cache = "<backcolor=@Success><b><color=255, 255, 255>  متوفر  </b>"
        'End If
    End Sub


    'Private Sub TreeList1_CustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs)
    '    If e.Column.Caption = "Icon" Then
    '        'image from a collection
    '        e.Value = "<image=add_32x32.png>"
    '        'image from resources
    '        'e.Value = "<image=#_589812_200>"
    '    End If
    'End Sub


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        InsertNewAccount()
    End Sub
    Private Sub InsertNewAccount()
        Dim F As New FinancialAccountsAddNewAccount
        With F
            Dim columnID1 As TreeListColumn = TreeList1.Columns("ID")
            Dim _AccountNo As Object = TreeList1.FocusedNode.GetDisplayText(columnID1)
            Dim _Account As New FinancialAccount
            _Account.HasTrans = _Account.CheckHasTrans(_AccountNo)
            If _Account.HasTrans = True Then
                XtraMessageBox.Show("لا يمكن اضافة حساب فرعي بسبب وجود حركات على الحساب")
                Exit Sub
            End If
            .TextInsertUpdate.Text = "Insert"
            .SearchAccType.Properties.DataSource = GetAccTypes(-1)
            .TextCurrency.Properties.DataSource = GetCurrency()
            .GetFinancialStatementNames()
            .GetFinancialSectors()
            .TextFatherAccName.Properties.DataSource = F.GetFinancialAccountsTable()
            If _Account.GetAccountData(_AccountNo) = True Then
                .TextFatherAccName.EditValue = _Account.AccountNo
                .TextCurrency.EditValue = _Account.Currency
                .TextFinancialSector.EditValue = _Account.FinancialSector
                .TextFinancialStatment.EditValue = _Account.FinancialStatment
                .CheckIsActive.Checked = True
                .SearchAccType.EditValue = _Account.AccType
                .TextAccNo.Text = GetAccountNo(_Account.AccountNo)
                .Text = "اضافة حساب جديد"
                .TextAccName.Select()
                .SimpleButton2.Enabled = False
                If .ShowDialog() <> DialogResult.OK Then
                    If FinanicialAccountsVariable.IsInserted = True Then
                        Dim _Account2 As New FinancialAccount
                        _Account2.GetAccountData(FinanicialAccountsVariable.AccountNo)
                        Dim _Active As String
                        If _Account.IsActive = True Then
                            _Active = "فعال"
                        Else
                            _Active = "موقوف"
                        End If
                        Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Me.TreeList1.AppendNode(nodeData:=New Object() {_Account2.AccountNo,
                        1, _Account2.AccountName, _Account2.FatherAccountName, 1, 1, 1, 1, _Active, _Account2.CurrencyCode}, parentNode:=Me.TreeList1.FocusedNode)
                        Me.TreeList1.FocusedNode = newNode
                    End If
                    FinanicialAccountsVariable.IsInserted = False
                End If
            End If

        End With
    End Sub
    Private Sub EditAccount()
        Dim F As New FinancialAccountsAddNewAccount
        With F
            .SearchAccType.Properties.DataSource = GetAccTypes(-1)
            .TextCurrency.Properties.DataSource = GetCurrency()
            .GetFinancialStatementNames()
            .GetFinancialSectors()
            .TextFatherAccName.Properties.DataSource = F.GetFinancialAccountsTable()
            Dim columnID1 As TreeListColumn = TreeList1.Columns("ID")
            Dim _AccountNo As Object = TreeList1.FocusedNode.GetDisplayText(columnID1)
            Dim _Account As New FinancialAccount
            If _Account.GetAccountData(_AccountNo) = True Then
                .TextInsertUpdate.Text = "Update"
                .TextAccNo.Text = _AccountNo
                .TextFatherAccName.EditValue = _Account.FatherAccount
                .TextAccName.Text = _Account.AccountName
                .TextCurrency.EditValue = _Account.Currency
                .TextFinancialSector.EditValue = _Account.FinancialSector
                .TextFinancialStatment.EditValue = _Account.FinancialStatment
                .SearchAccType.EditValue = _Account.AccType
                .CheckIsActive.Checked = _Account.IsActive
                .Text = "تعديل الحساب (" & " " & _Account.AccountName & ")"
                .TextAccNo.ReadOnly = True
                If _Account.CheckHasTrans(_AccountNo) = True Then
                    .TextCurrency.ReadOnly = True
                End If
                .TextAccName.Select()
                If .ShowDialog() <> DialogResult.OK Then
                    If FinanicialAccountsVariable.IsInserted = True Or FinanicialAccountsVariable.IsUpdated = True Then
                        If _Account.GetAccountData(_AccountNo) = True Then
                            TreeList1.FocusedNode.SetValue(1, _Account.AccountName)
                            TreeList1.FocusedNode.SetValue(2, _Account.FatherAccount)
                            TreeList1.FocusedNode.SetValue(3, _Account.FatherAccountName)
                            If _Account.IsActive = True Then
                                TreeList1.FocusedNode.SetValue(5, "فعال")
                            Else
                                TreeList1.FocusedNode.SetValue(5, "موقوف")
                            End If
                            TreeList1.FocusedNode.SetValue(4, _Account.CurrencyCode)
                        End If
                        FinanicialAccountsVariable.IsInserted = False
                        FinanicialAccountsVariable.IsUpdated = False
                    ElseIf FinanicialAccountsVariable.IsDeleted = True Then
                        TreeList1.DeleteSelectedNodes()
                        FinanicialAccountsVariable.IsDeleted = False
                    End If
                End If
            End If
        End With
    End Sub
    Public Sub DeleteAccount()
        Dim count As Integer = TreeList1.Selection.Count
        If count = 0 Then Return
        Dim columnID1 As TreeListColumn = TreeList1.Columns("ID")
        Dim ColAccName As TreeListColumn = TreeList1.Columns("AccName")
        Dim _AccountNo As Object = TreeList1.FocusedNode.GetDisplayText(columnID1)
        Dim _AccName As Object = TreeList1.FocusedNode.GetDisplayText(ColAccName)
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
            TreeList1.DeleteSelectedNodes()
        End If
    End Sub
    Private Sub FillNodeLevels(ByVal nodes As TreeListNodes)
        'Dim col As TreeListColumn = TreeList1.Columns(0)

        'For Each node As TreeListNode In nodes
        '    node.SetValue(col, node.Level)
        '    FillNodeLevels(node.Nodes)
        'Next
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        DeleteAccount()
    End Sub


    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        EditAccount()
    End Sub

    Private Function GetAccountNo(FatherAccount As String) As String
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "   Select  IsNull(max(CAST([AccNo] AS BIGINT)),'" & FatherAccount & "')+1 as NewAccNo
                            FROM [dbo].[FinancialAccounts]
	                        Where [FatherAccount]='" & FatherAccount & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return Sql.SQLDS.Tables(0).Rows(0).Item("NewAccNo")
            Else
                Return "0"
            End If
        Catch ex As Exception
            Return "0"
        End Try
    End Function


    Private Sub TreeList1_DoubleClick(sender As Object, e As EventArgs) Handles TreeList1.DoubleClick
        EditAccount()
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        TreeList1.CollapseAll()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        TreeList1.ExpandAll()
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        TreeList1.ExpandToLevel(1)
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        TreeList1.ExpandToLevel(2)
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        TreeList1.ExpandToLevel(3)
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        TreeList1.ExpandToLevel(4)
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        TreeList1.CollapseToLevel(1)
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        TreeList1.CollapseToLevel(2)
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        TreeList1.CollapseToLevel(3)
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        TreeList1.CollapseToLevel(4)
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        RefreshData()
    End Sub
    Private Sub RefreshData()
        Dim _Int As Integer
        _Int = TreeList1.GetVisibleIndexByNode(TreeList1.FocusedNode)
        Me.TreeList1.DataSource = GetFinancialAccountsTable()
        TreeList1.ExpandAll()
        TreeList1.FocusedNode = TreeList1.GetNodeByVisibleIndex(_Int)
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        TreeList1.ShowPrintPreview()
    End Sub


End Class