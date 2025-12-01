Imports DevExpress.XtraEditors

Public Class AssetsAddEdit
    Private Sub Assets_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'AccountingDataSet.FinancialAccounts1' table. You can move, or remove it, as needed.
        Me.FinancialAccounts1TableAdapter.Fill(Me.AccountingDataSet.FinancialAccounts1)
        'TODO: This line of code loads data into the 'AccountingDataSet.AssetsType' table. You can move, or remove it, as needed.
        Me.AssetsTypeTableAdapter.Fill(Me.AccountingDataSet.AssetsType)
        'TODO: This line of code loads data into the 'AccountingDataSet.Assets' table. You can move, or remove it, as needed.
        'Me.AssetsTableAdapter.Fill(Me.AccountingDataSet.Assets)

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        InsertIntoItems()
    End Sub

    Private Sub InsertIntoItems()
        Dim SqlString As String
        Dim Sql As New SQLControl
        Dim _ItemNo As Integer
        If String.IsNullOrEmpty(AssetNameTextEdit.Text) Then
            XtraMessageBox.Show("خطأ: يجب تعبئة الاسم")
            Exit Sub
        End If
        If String.IsNullOrEmpty(DepreciationPercentageTextEdit.Text) Then
            XtraMessageBox.Show("خطأ: يجب ادخال نسبة الاستهلاك ")
            Exit Sub
        End If
        If String.IsNullOrEmpty(AssetTypeLookUpEdit.Text) Then
            XtraMessageBox.Show("خطأ: يجب تحديد نوع الأصل ")
            Exit Sub
        End If

        If Me.TextNewOld.Text = "New" Then
            SqlString = " SELECT isnull(max(CONVERT(INT, ItemNo))+1,1) as ItemNo FROM items  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
            _ItemNo = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("ItemNo"))
            'ItemNoTextEdit.Text = _ItemNo
            SqlString = "Insert Into Items (ItemNo,ItemName,[Type],ReOrderQuantity,notes,AccSales,AccPurches,AccRetPurches,
                                             AccRetSales,HasExpireDate,CategoryID,TradeMarkID,GroupID,SaleOnScale,ItemNo2,
                                            ItemNo3,ItemNo4,WebSite1,WebSite2,ProductCompany,HasSerial,[ItemStatus]) Values (
                                            '" & _ItemNo & "',
                                            N'" & AssetNameTextEdit.Text & "',
                                            '" & 3 & "',
                                            '" & 0 & "',
                                            N'" & NotesTextEdit.Text & "',
                                            '" & AssetsMainAccount.EditValue & "',
                                            '" & AssetsMainAccount.EditValue & "',
                                            '" & AssetsMainAccount.EditValue & "',
                                            '" & AssetsMainAccount.EditValue & "',
                                            '" & 0 & "',
                                            '',
                                            '',
                                            '',
                                            " & 0 & ",
                                            '',
                                            '',
                                            '',
                                            '',
                                            '',
                                            '',
                                            '" & 0 & "',
                                            " & 1 & "
                                            )"
            If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then XtraMessageBox.Show("لا يمكن حفظ ") : Exit Sub

            SqlString = " Insert Into Items_units (item_id,unit_id,main_unit,EquivalentToMain,
                                             item_unit_bar_code,Price1,Price2,Price3,IsUnit) Values (
                                                '" & _ItemNo & "',
                                                '" & 1 & "',
                                                '" & 1 & "',
                                                '" & 1 & "',
                                                '" & 0 & "',
                                                " & 0 & ",
                                                " & 0 & ",
                                                " & 0 & ",
                                                1)"
            If Sql.SqlTrueAccountingRunQuery(SqlString) = True Then
                SqlString = " Insert Into [dbo].[Assets] 
                                  ([AssetCode],[ItemNo],[AssetName],[AssetLocation],[DepreciationPercentage],[AssetType],[Notes]) 
                                  Values ('" & AssetCodeTextEdit.Text & "',
                                  " & _ItemNo & ",
                                  N'" & AssetNameTextEdit.Text & "',
                                  N'" & AssetLocationTextEdit.Text & "',
                                  " & DepreciationPercentageTextEdit.Text & ",
                                  '" & AssetTypeLookUpEdit.EditValue & "',
                                  N'" & NotesTextEdit.Text & "'
                                  ) "
                Sql.SqlTrueAccountingRunQuery(SqlString)
                XtraMessageBox.Show("تم تعريف الأصل ")
            End If

        ElseIf Me.TextNewOld.Text = "Old" Then
            Dim UpdateString As String
            UpdateString = " Update [dbo].[Assets] Set [AssetCode]=N'" & AssetCodeTextEdit.Text & "',
                                                       [AssetName]= N'" & AssetNameTextEdit.Text & "',
                                                       [AssetLocation]=N'" & AssetLocationTextEdit.Text & "',
                                                       [AssetType]='" & AssetTypeLookUpEdit.EditValue & "',
                                                       [Notes]=N'" & NotesTextEdit.EditValue & "',
                                                       [DepreciationPercentage]='" & DepreciationPercentageTextEdit.EditValue & "'
                                                       where [ItemNo]='" & Me.ItemNoTextEdit.Text & "'"
            Sql.SqlTrueAccountingRunQuery(UpdateString)

            UpdateString = " Update [dbo].[Items] Set [ItemName]=N'" & AssetNameTextEdit.Text & "',
                                                       [AccSales]='" & AssetsMainAccount.EditValue & "',
                                                       [AccPurches]='" & AssetsMainAccount.EditValue & "',
                                                       [AccRetPurches]='" & AssetsMainAccount.EditValue & "',
                                                       [AccRetSales]='" & AssetsMainAccount.EditValue & "'
                                                       where [ItemNo]='" & Me.ItemNoTextEdit.Text & "'"
            Sql.SqlTrueAccountingRunQuery(UpdateString)
        End If

        Me.Dispose()

    End Sub

    Private Sub AssetTypeLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles AssetTypeLookUpEdit.EditValueChanged
        If Me.IsHandleCreated = True Then
            Dim _AssetType As Integer
            If Not IsDBNull(AssetTypeLookUpEdit.EditValue) Then
                _AssetType = AssetTypeLookUpEdit.EditValue
                Dim sql As New SQLControl
                sql.SqlTrueAccountingRunQuery("Select AssetsMainAccount,AssetsDepAccount,AssetsAccumulatedAccount From [dbo].[AssetsType] Where [ID]=" & _AssetType)
                AssetsMainAccount.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AssetsMainAccount")
                AssetsAccumulatedAccount.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AssetsAccumulatedAccount")
                AssetsDepAccount.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("AssetsDepAccount")
            End If
        End If
    End Sub
    Private Function GetAssetData(ItemNo As String) As Boolean
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = "SELECT  [AssetCode],
                             [AssetName],[AssetLocation],
                             [Cost],[PurchaseDate],
                             [DepreciationPercentage],A.[AssetType],
                             A.[Notes],A.[ItemNo],[LastPurchaseDate],[LastPurchasePrice],
                             AssetsMainAccount,AssetsDepAccount,AssetsAccumulatedAccount
                     FROM [dbo].[Assets] A 
                     Left Join [dbo].[Items] I on I.ItemNo=A.ItemNo 
                     Left Join [dbo].[AssetsType] T on T.ID=A.AssetType 
                     Where A.[ItemNo]= '" & ItemNo & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                AssetNameTextEdit.Text = .Item("AssetName")
                AssetCodeTextEdit.Text = .Item("AssetCode")
                AssetLocationTextEdit.Text = .Item("AssetLocation")
                DepreciationPercentageTextEdit.Text = .Item("DepreciationPercentage")
                AssetTypeLookUpEdit.EditValue = .Item("AssetType")
                NotesTextEdit.EditValue = .Item("Notes")
                PurchaseDateDateEdit.EditValue = .Item("LastPurchaseDate")
                CostTextEdit.EditValue = .Item("LastPurchasePrice")
                AssetsMainAccount.EditValue = .Item("AssetsMainAccount")
                AssetsAccumulatedAccount.EditValue = .Item("AssetsAccumulatedAccount")
                AssetsDepAccount.EditValue = .Item("AssetsDepAccount")
                TextNewOld.Text = "Old"
                If HasTrans(ItemNo) = True Then AssetTypeLookUpEdit.ReadOnly = True
            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Private Function HasTrans(_ItemNo As String) As Boolean
        Try
            Dim sqlstring As String
            Dim sql As New SQLControl
            sqlstring = "  select top(1) ID from journal where StockID='" & _ItemNo & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub TextNewOld_EditValueChanged(sender As Object, e As EventArgs) Handles TextNewOld.EditValueChanged
        If Me.TextNewOld.Text = "New" Then
            Me.Text = "اضافة أصل ثابت جديد"
        ElseIf Me.TextNewOld.Text = "Old" Then
            Me.Text = "تعديل أصل ثابت "
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If DeleteAssets(ItemNoTextEdit.Text) = True Then
            XtraMessageBox.Show("تم حذف الأصل")
        Else
            XtraMessageBox.Show("خطأ: لا يمكن حذف الأصل")
        End If
    End Sub
    Private Function DeleteAssets(_itemNo As String) As Boolean
        If DevExpress.XtraEditors.XtraMessageBox.Show("هل تريد حذف الأصل؟", "تاكيد", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sql As New SQLControl
            If sql.SqlTrueAccountingRunQuery("Delete from Items where ItemNo ='" & _itemNo & "' ;
                                              Delete FROM [dbo].[Assets] where ItemNo ='" & _itemNo & "'") = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Sub ItemNoTextEdit_EditValueChanged(sender As Object, e As EventArgs) Handles ItemNoTextEdit.EditValueChanged
        GetAssetData(ItemNoTextEdit.Text)
    End Sub

    Private Sub AssetTypeLookUpEdit_AddNewValue(sender As Object, e As Controls.AddNewValueEventArgs) Handles AssetTypeLookUpEdit.AddNewValue
        If AssetsType.ShowDialog <> DialogResult.OK Then
            Me.AssetsTypeTableAdapter.Fill(Me.AccountingDataSet.AssetsType)
        End If
    End Sub
End Class