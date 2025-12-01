Public Class MeatMootXtraReport
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim report As New MeatmootPos
        With report
            .FistTrans.Text = Me.TextFirsttrans.Text
            .LastTrans.Text = Me.TextLasttrans.Text
            .ShiftID.Text = Me.TextShiftid.Text
            .Ztime.Text = Me.TextZtime.Text
            .TotalSales.Text = CDec(Me.TextTotalSales.EditValue).ToString("N2")
            .CumulativeTotal.Text = CInt(Me.TextCumulativesales.EditValue).ToString("N2")
            .DrawerCash.Text = CInt(Me.TextDrawerCash.EditValue).ToString("N2")
            .Cash.Text = CInt(Me.TextCash.EditValue).ToString("N2")
            .Visa.Text = CInt(Me.TextVISA.EditValue).ToString("N2")
            .PrintAsync()

            'TextFirsttrans.Text = CDate(TextFirsttrans.Text).AddMonths(1).AddMinutes(GetRandomInteger()).AddSeconds(GetRandomInteger())
            'TextLasttrans.Text = CDate(TextFirsttrans.Text).AddMonths(1).AddMinutes(GetRandomInteger()).AddSeconds(GetRandomInteger()).AddMinutes(-40)
        End With
    End Sub
    Public Function GetRandomInteger() As Integer
        ' Create a new instance of the Random class
        Dim random As New Random()
        If random.Next(0, 11) Mod 2 = 0 Then
            Return 8 - random.Next(0, 11)
        Else
            Return 8 + random.Next(0, 11)
        End If

        ' Generate a random integer between 0 and 10

    End Function

    Private Sub TextLasttrans_EditValueChanged(sender As Object, e As EventArgs) Handles TextLasttrans.EditValueChanged
        Try
            Me.TextZtime.Text = Me.TextLasttrans.Text
        Catch ex As Exception
            Me.TextZtime.Text = ""
        End Try

    End Sub

    Private Sub TextTotalSales_EditValueChanged(sender As Object, e As EventArgs) Handles TextTotalSales.EditValueChanged

    End Sub

    Private Sub TextVISA_EditValueChanged(sender As Object, e As EventArgs) Handles TextVISA.EditValueChanged
        Try
            TextTotalSales.Text = CDec(TextCash.Text) + CDec(TextVISA.Text)
        Catch ex As Exception
            TextTotalSales.Text = "0"
        End Try
    End Sub

    Private Sub TextCash_EditValueChanged(sender As Object, e As EventArgs) Handles TextCash.EditValueChanged
        Try
            TextTotalSales.Text = CDec(TextCash.Text) + CDec(TextVISA.Text)
        Catch ex As Exception
            TextTotalSales.Text = "0"
        End Try
    End Sub

    Private Sub MeatMootXtraReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextDrawerCash.Text = "200"
    End Sub

    Private Sub TextCumulativesales_DoubleClick(sender As Object, e As EventArgs) Handles TextCumulativesales.DoubleClick

    End Sub

    Private Sub TextCumulativesales_EditValueChanged(sender As Object, e As EventArgs) Handles TextCumulativesales.DoubleClick
        TextCumulativesales.EditValue = CDec(TextLastCum.EditValue) + CDec(TextTotalSales.EditValue)
    End Sub
End Class