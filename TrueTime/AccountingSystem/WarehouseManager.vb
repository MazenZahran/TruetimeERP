Public Class WarehouseManager
    Private Sub AccordionControlElement1_Click(sender As Object, e As EventArgs) Handles AccordionControlElement1.Click

    End Sub

    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click
        'Dim child As Form = Nothing
        'Dim f As StockMove = New StockMove()
        'f.Label1.Text = "سند استلام بضاعة"
        'f.Label1.BackColor = Color.Green
        'f.DocName.EditValue = 14
        'f.ColShelveTo.Visible = False
        'f.ColBalanceOnShelf.Visible = False
        'f.Text = "سند استلام بضاعة"
        'f.MdiParent = Me
        'f.Show()

        Dim child As Form = Nothing
        Dim f As MoneyTransList = New MoneyTransList()
        f.MdiParent = Me
        f.TextEditDocName.EditValue = 10
        f.Show()

    End Sub
End Class