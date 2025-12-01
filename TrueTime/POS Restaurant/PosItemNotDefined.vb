Public Class PosItemNotDefined
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButtonClose.Click
        Me.Dispose()
    End Sub

    Private Sub PosItemNotDefined_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnDefineNewItem.Click
        Dim f As New PosItemDirectDefind
        With f
            .TextItemBarcode.Text = Me.LabelControlBarcode.Text
            .TextItemName.Text = ""
            .LookUpUnit.EditValue = 1
            .TextPrice.EditValue = 0
            If .ShowDialog <> DialogResult.OK Then
                Me.Close()
            End If
        End With
    End Sub
End Class