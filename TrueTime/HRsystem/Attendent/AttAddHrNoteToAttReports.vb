Public Class AttAddHrNoteToAttReports


    Private Sub AttAddHrNoteToAttReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        ' Set dialog result to OK to indicate the note should be accepted
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        ' Set dialog result to Cancel to indicate the note should not be accepted
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class