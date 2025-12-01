Imports DevExpress.XtraPrinting

Public Class PosAddDiscountOnVoucher
    Private Sub PosAddDiscountOnVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetLastDiscount()
        TextAmountDiscount.Select()

    End Sub
    Private Sub GetLastDiscount()

        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " Select IsNull(Sum(VoucherDiscount),0) as VoucherDiscount  
                          From [POSJournal] 
                          Where DocCode='" & TextVoucherCode.Text & "'"
            Sql.SqlTrueAccountingRunQuery(SqlString)
            TextAmountDiscount.EditValue = Sql.SQLDS.Tables(0).Rows(0).Item("VoucherDiscount")
        Catch ex As Exception
            TextAmountDiscount.EditValue = 0
        End Try


        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = "    DISABLE TRIGGER ALL ON [dbo].[POSJournal];
                             Update [dbo].[POSJournal]
                             Set VoucherDiscount= 0 
                             Where DocCode='" & TextVoucherCode.Text & "';
                             ENABLE TRIGGER ALL ON [dbo].[POSJournal];  "
            Sql.SqlTrueAccountingRunQuery(SqlString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try





    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveData()
    End Sub
    Private Sub SaveData()
        If TexVoucherDiscount.EditValue > TextVoucherAmount.EditValue Then
            MsgBoxShowError("المبلغ خطأ")
            Exit Sub
        End If
        Dim Sql As New SQLControl
        Dim SqlString As String
        SqlString = " DISABLE TRIGGER ALL ON [dbo].[POSJournal];
                      Update [dbo].[POSJournal]
                      Set [VoucherDiscount] =(((StockPrice-StockDiscount)*StockQuantity)/" & CDec(TextVoucherAmount.EditValue) & ") * " & CDec(TexVoucherDiscount.EditValue) & " 
                      Where DocCode='" & TextVoucherCode.Text & "' ;
                      ENABLE TRIGGER ALL ON [dbo].[POSJournal];  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        SqlString = " DISABLE TRIGGER ALL ON [dbo].[POSJournal];
                      Update [dbo].[POSJournal]
                      Set DocAmount=((StockPrice-StockDiscount)*StockQuantity)-(((StockPrice-StockDiscount)*StockQuantity)/" & CDec(TextVoucherAmount.EditValue) & ") * " & CDec(TexVoucherDiscount.EditValue) & " 
                      Where DocCode='" & TextVoucherCode.Text & "';
                      ENABLE TRIGGER ALL ON [dbo].[POSJournal];  "
        Sql.SqlTrueAccountingRunQuery(SqlString)
        Me.Close()
    End Sub

    Private Sub TexVoucherDiscount_EditValueChanged(sender As Object, e As EventArgs) Handles TexVoucherDiscount.EditValueChanged
        Try
            If TexVoucherDiscount.EditValue < TextVoucherAmount.EditValue Then
                TextVoucherAmountAfterDiscount.EditValue = CDec(TextVoucherAmount.EditValue - TexVoucherDiscount.EditValue).ToString("n2")
                Me.SimpleButton1.Enabled = True
            Else
                Me.SimpleButton1.Enabled = False
                TextVoucherAmountAfterDiscount.EditValue = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        ShowKeyboard()
    End Sub

    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextAmountDiscount.EditValueChanged
        calc()
    End Sub
    Private Sub calc()
        If Me.IsHandleCreated Then
            Try
                TexVoucherDiscount.EditValue = TextAmountDiscount.EditValue + (TextPercDiscount.EditValue) / 100 * TextVoucherAmount.EditValue
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub TextPercDiscount_EditValueChanged(sender As Object, e As EventArgs) Handles TextPercDiscount.EditValueChanged
        calc()
    End Sub
    Private Sub TextPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles TextAmountDiscount.MouseUp
        TextEditSelectText(TextAmountDiscount)
    End Sub

    Private Sub TextPercDiscount_MouseUp(sender As Object, e As MouseEventArgs) Handles TextPercDiscount.MouseUp
        TextEditSelectText(TextPercDiscount)
    End Sub

    Private Sub MemoEdit1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextAmountDiscount.KeyUp, TextPercDiscount.KeyUp
        If e.KeyCode = Keys.Enter Then
            SaveData()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        ShowKeyboard()
    End Sub
End Class