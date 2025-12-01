Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class PosEditItemsInPOS
    Private _Calc As Boolean
    Private transID As Integer
    Private showPurchasePrice As Boolean
    Private showLastTrans As Boolean
    Private refNo As Integer
    Private itemPrice As Decimal
    Private docCode As String
    Private itemNo As Integer
    Sub New(_TransID As Integer, _ShowPurchasePrice As Boolean, _ShowLastTrans As Boolean, _RefNo As Integer)
        InitializeComponent()
        TransID = _TransID
        showPurchasePrice = _ShowPurchasePrice
        showLastTrans = _ShowLastTrans
        refNo = _RefNo
        LoadData()
    End Sub
    Private Sub LoadData()
        SwitchKeyboardLayout("ar")
        If showPurchasePrice = True Then
            LayoutLastPurchasePrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutLastPurchasePrice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        If showLastTrans = True Then
            LayoutControlItemLastTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlItemLastTrans.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        'If TextID.Text = "0" Then Exit Sub
        _Calc = False
        Dim _ID As Integer = transID
        Dim _DocAmount As Decimal = 0
        If String.IsNullOrEmpty(transID) Then Exit Sub
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Select [StockID],[StockUnit],[StockQuantity]," _
                                          & " [StockQuantityByMainUnit],[StockPrice]," _
                                          & " [StockDiscount],[DocAmount]," _
                                          & " [ItemName],DocNoteByAccount,StockBarcode,Isnull(VoucherDiscount,0) as VoucherDiscount,LastPurchasePrice,DocCode,
                                          [StockQuantityByMainUnit]/[StockQuantity] as Equivalent  " _
                                          & " From [dbo].[POSJournal] where ID=" & _ID)

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockID")) Then
            Me.TextStockID.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("StockID"))
            Me.TextStockUnit.Properties.DataSource = GetUnitsTable(TextStockID.Text)
            itemNo = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("StockID"))
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")) Then
            Me.TextItemName.Text = Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
            Me.LabelControlItemName.Text = Sql.SQLDS.Tables(0).Rows(0).Item("ItemName")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockUnit")) Then
            Me.TextStockUnit.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockUnit")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockQuantity")) Then
            Me.TextStockQuantity.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockQuantity")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")) Then
            Me.TextStockPrice.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")
            itemPrice = Sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")
        Else
            Me.TextStockPrice.EditValue = 0
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockDiscount")) Then
            ' Me.TextNetAmount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockDiscount")
            Me.TextDiscountAmount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockDiscount") * Sql.SQLDS.Tables(0).Rows(0).Item("StockQuantity")
        Else
            Me.TextNetAmount.EditValue = 0
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocNoteByAccount")) Then
            Me.NoteByAccount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("DocNoteByAccount")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("StockBarcode")) Then
            Me.TextStockBarcode.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("StockBarcode")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")) Then
            Me.TxtPurchasePrice.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice")
        End If
        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocAmount")) Then
            _DocAmount = Sql.SQLDS.Tables(0).Rows(0).Item("DocAmount") + Me.TextDiscountAmount.EditValue + Sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")
        End If

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("Equivalent")) Then
            TextEquivalent.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("Equivalent")
        End If

        If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")) Then
            docCode = Sql.SQLDS.Tables(0).Rows(0).Item("DocCode")
        End If

        If GlobalVariables._Shalash Then
            LayoutControlItemItemNo2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            Me.TextItemNumber2.Text = GetItemNo2()
            Dim _LastPurchasePrice As Integer = CInt(Sql.SQLDS.Tables(0).Rows(0).Item("LastPurchasePrice"))
            Me.TxtPurchasePrice.EditValue = ShalashNumbersToLetters(_LastPurchasePrice)
            LayoutLastPurchasePrice.Text = "."
        End If

        TextNetAmount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("DocAmount") + Sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")
        TextAmount.EditValue = _DocAmount
        _Calc = True



        CalAmount()

        If GlobalVariables._Shalash = True Then
            TextStockPrice.Text = 0
        End If

        ' i will 

    End Sub
    Private Function GetItemNo2() As String
        Dim sql As New SQLControl
        Dim sqlString As String
        sqlString = "Select ItemNo2 From Items Where ItemNo=" & TextStockID.Text
        sql.SqlTrueAccountingRunQuery(sqlString)
        If sql.SQLDS.Tables(0).Rows.Count > 0 Then
            Return sql.SQLDS.Tables(0).Rows(0).Item("ItemNo2")
        End If
        Return ""
    End Function

    Private Sub PosEditItemsInPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextStockUnit.Properties.DataSource = GetOnlyUnitsTable()
        'TextNetAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        'TextNetAmount.Properties.Mask.EditMask = "#,##0.0 NIS"
        'TextNetAmount.Properties.Mask.UseMaskAsDisplayFormat = True
        '   TextStockUnit.Properties.DataSource = GetAllUnits()
        If GlobalVariables._PosAllowChangeItemPrice = True Then
            TextStockPrice.ReadOnly = False
            TextStockPrice.Select()
        Else
            TextStockPrice.ReadOnly = True
            TextStockQuantity.Select()
        End If
        If GlobalVariables._Shalash And RefNo <> 0 Then
            LayoutControlGetLastPriceForCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlGetLastPriceForCustomer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        Me.KeyPreview = True
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        'If e.KeyCode = Keys.Up Then
        '    ' TextStockQuantity.Select()
        '    TextStockQuantity.EditValue = TextStockQuantity.EditValue + 1
        'End If
        'If e.KeyCode = Keys.Down Then
        '    ' TextStockQuantity.Select()
        '    If TextStockQuantity.EditValue > 0 Then
        '        TextStockQuantity.EditValue = TextStockQuantity.EditValue - 1
        '    End If
        'End If
    End Sub


    Private Sub TextDiscountPercentage_EditValueChanged(sender As Object, e As EventArgs) Handles TextDiscountPercentage.EditValueChanged
        CalAmount()
    End Sub

    Private Sub TextDiscountAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextDiscountAmount.EditValueChanged
        CalAmount()
    End Sub

    Private Sub TextDiscount_EditValueChanged(sender As Object, e As EventArgs)
        CalAmount()
    End Sub
    Private Sub CalAmount()
        If Me.IsHandleCreated Then
            If _Calc = False Then Exit Sub
            Try
                Dim _Price, _Quantity As Decimal
                _Price = TextStockPrice.EditValue
                _Quantity = TextStockQuantity.EditValue
                TextAmount.EditValue = (_Quantity * _Price)
                'If TextStockQuantity.EditValue < 0 Then
                '    TextDiscountAmount.EditValue = -1 * TextDiscountAmount.EditValue
                'End If
            Catch ex As Exception

            End Try

            Try
                TextNetAmount.EditValue = (TextAmount.EditValue - TextDiscountAmount.EditValue) - (TextDiscountPercentage.EditValue / 100 * TextAmount.EditValue)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextStockQuantity_EditValueChanged(sender As Object, e As EventArgs) Handles TextStockQuantity.EditValueChanged
        If TextStockQuantity.EditValue > 10000 Then
            TextStockQuantity.EditValue = TextStockQuantity.OldEditValue
        End If
        CalAmount()
    End Sub

    Private Sub TextStockPrice_EditValueChanged(sender As Object, e As EventArgs)
        'Try
        '    If TextStockPrice.EditValue = 0 Then TextStockPrice.ReadOnly = False
        'Catch ex As Exception

        'End Try

        CalAmount()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        AcceptChages()
    End Sub
    Private Sub AcceptChages()
        Try
            If TextStockQuantity.EditValue = 0 Then
                MsgBox("خطأ: الكمية صفر")
                Exit Sub
            End If

            If TextNetAmount.EditValue < 0 Then
                MsgBoxShowError("خطأ: المبلغ أقل من الصفر")
                Exit Sub
            End If
            '    " ,[StockPrice]= " & TextStockPrice.EditValue - TextDiscountAmount.EditValue &
            '      " ,[StockDiscount]= " & TextDiscount.EditValue &
            Dim Sql As New SQLControl
            Dim _ID As Integer = TransID
            Dim SqlString As String = "Update [dbo].[POSJournal] Set" _
                                       & "  [DocAmount]= " & TextNetAmount.EditValue &
                                       " ,[StockQuantity]= " & TextStockQuantity.EditValue &
                                       " ,[StockQuantityByMainUnit]= " & TextEquivalent.EditValue * TextStockQuantity.EditValue &
                                       " ,[StockPrice]= " & TextStockPrice.EditValue &
                                       " ,[StockDiscount]= " & ((TextAmount.EditValue - TextNetAmount.EditValue) / TextStockQuantity.EditValue) &
                                       " ,[DocNoteByAccount]= N'" & NoteByAccount.Text & "'" &
                                       " ,[ItemName]= N'" & LabelControlItemName.Text & "'" &
                                       " ,[PriceEdited]= 1" &
                                       " Where ID=" & _ID
            If TextDiscountAmount.EditValue = 0 And TextDiscountPercentage.EditValue = 0 Then
                SqlString += " ; EXEC	 [dbo].[ApplyCampagins]		@Barcode ='" & TextStockBarcode.Text & "', @ItemNo='" & itemNo & "', @UnitID=" & TextStockUnit.EditValue & ",@DocCode=N'" & docCode & "'"
            End If
            ChangeItemPrice()
            If Sql.SqlTrueAccountingRunQuery(SqlString) = False Then
                MsgBox("لم يتم تعديل البيانات")
                Me.Close()
            End If
        Catch ex As Exception
            Me.Close()
        End Try
        Me.Close()
    End Sub

    Private Sub TextStockUnit_EditValueChanged(sender As Object, e As EventArgs) Handles TextStockUnit.EditValueChanged
        'TextStockQuantityByMainUnit.EditValue = GetCountMainUnitsInUnit(TextStockID.EditValue, TextStockUnit.EditValue)
        'CalAmount()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        TextStockQuantity.EditValue = TextStockQuantity.EditValue + 1
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If TextStockQuantity.EditValue > 0 Then
            TextStockQuantity.EditValue = TextStockQuantity.EditValue - 1
        End If

    End Sub

    Private Sub TextAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TextAmount.EditValueChanged

    End Sub

    Private Sub TextStockPrice_EditValueChanged_1(sender As Object, e As EventArgs) Handles TextStockPrice.EditValueChanged
        CalAmount()
    End Sub
    Private Sub TextStockPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles TextStockPrice.MouseUp
        TextEditSelectText(TextStockPrice)
    End Sub
    Private Sub TextStockQuantity_MouseUp(sender As Object, e As MouseEventArgs) Handles TextStockQuantity.MouseUp
        TextEditSelectText(TextStockQuantity)
    End Sub
    Private Sub TextDiscountAmount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextDiscountAmount.MouseUp
        TextEditSelectText(TextDiscountAmount)
    End Sub
    Private Sub TextDiscountPercentage_MouseUp(sender As Object, e As MouseEventArgs) Handles TextDiscountPercentage.MouseUp
        TextEditSelectText(TextDiscountPercentage)
    End Sub

    Private Sub TextStockPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles TextStockPrice.KeyDown
        If e.KeyCode = Keys.Enter Then AcceptChages()
    End Sub

    Private Sub TextStockQuantity_Spin(sender As Object, e As SpinEventArgs) Handles TextStockQuantity.Spin
        '  e.Handled = True
    End Sub

    Private Sub TextStockPrice_Spin(sender As Object, e As SpinEventArgs) Handles TextStockPrice.Spin
        e.Handled = True
    End Sub

    Private Sub TextStockQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles TextStockQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then AcceptChages()
    End Sub

    Private Sub TextDiscountAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles TextDiscountAmount.KeyDown
        If e.KeyCode = Keys.Enter Then AcceptChages()
    End Sub

    Private Sub TextDiscountPercentage_KeyDown(sender As Object, e As KeyEventArgs) Handles TextDiscountPercentage.KeyDown
        If e.KeyCode = Keys.Enter Then AcceptChages()
    End Sub
    Private _ChangePrice As Boolean = True
    Private Sub ChangeItemPrice()
        Try
            If GlobalVariables._Shalash = True And _ChangePrice = True And TextStockPrice.EditValue <> itemPrice Then
                If XtraMessageBox.Show(" هل تريد تغيير سعر الصنف في النظام المالي ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim sql As New SQLControl
                    Dim sqlString As String
                    sqlString = " Update Items_units Set Price1=" & TextStockPrice.EditValue & " Where item_id=" & TextStockID.EditValue & " and unit_id=" & TextStockUnit.EditValue
                    sql.SqlTrueAccountingRunQuery(sqlString)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButtonLastTrans_Click(sender As Object, e As EventArgs) Handles SimpleButtonLastTrans.Click
        Dim F3 As New StockMoveReport
        With F3
            .SearchItems.Text = Me.TextStockID.Text
            .Warehouses.Text = -1
            .Text = " حركة صنف ( " & LabelControlItemName.Text & " ) "
            .Show()
            .RefreshData()
        End With
    End Sub

    Private Sub SimpleButtonGetLastPriceForCustomer_Click(sender As Object, e As EventArgs) Handles SimpleButtonGetLastPriceForCustomer.Click
        Try
            Dim Sql As New SQLControl
            Dim sqlString As String
            Dim lastPrice As Decimal
            sqlString = "  select top(1) StockPrice from Journal Where Referance=" & RefNo & " and StockID='" & Me.TextStockID.Text & "' AND StockPrice <> 0 Order By ID desc"
            Sql.SqlTrueAccountingRunQuery(sqlString)
            If Sql.SQLDS.Tables(0).Rows.Count > 0 Then
                lastPrice = Sql.SQLDS.Tables(0).Rows(0).Item("StockPrice")
                If XtraMessageBox.Show("اخر سعر لهذا الزبون " & lastPrice & " هل تريد اعتماد ؟ ", "Confirmation", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Me.TextStockPrice.EditValue = lastPrice
                    _ChangePrice = False
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

End Class