Public Class VocationAddQuick
    Private Sub VocationAddQuick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TrueTimeDataSet.VocationsTypes' table. You can move, or remove it, as needed.
        Me.VocationsTypesTableAdapter.Fill(Me.TrueTimeDataSet.VocationsTypes)
        Me.LookUpEditVocations.EditValue = 1
        Me.KeyPreview = True
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GlobalVariables._VocationTypeInQuickMode = Me.LookUpEditVocations.EditValue
        Me.Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        GlobalVariables._VocationTypeInQuickMode = 0
        Me.Close()
    End Sub
    Private Sub AddVocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F3 Then
            GlobalVariables._VocationTypeInQuickMode = Me.LookUpEditVocations.EditValue
            Me.Close()
        End If
    End Sub
End Class