Public Class PosEditPrice
    Private ItemNo As Integer
    Private ItemPrice As Decimal
    Private RowID As Integer
    Public Sub New(_ItemNo As Integer, _ItemPrice As Decimal, _RowID As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        ItemNo = _ItemNo
        ItemPrice = _ItemPrice
        RowID = _RowID
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub PosEditPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPrice.Select()
        LabelControl1.Text = ""
    End Sub

    Private Sub txtPrice_MouseUp(sender As Object, e As MouseEventArgs) Handles txtPrice.MouseUp
        TextEditSelectText(txtPrice)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim sql As New SQLControl
        sql.SqlTrueAccountingRunQuery(" Update [POSJournal] set PriceEdited=1,DocAmount =" & txtPrice.EditValue & ",[StockPrice]=" & txtPrice.EditValue & " where [ID]=" & RowID)
        Me.Close()
    End Sub


    Private Sub txtPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Update [POSJournal] set PriceEdited=1,DocAmount =" & txtPrice.EditValue & ",[StockPrice]=" & txtPrice.EditValue & " where [ID]=" & RowID)
            Me.Close()
        End If
    End Sub
End Class