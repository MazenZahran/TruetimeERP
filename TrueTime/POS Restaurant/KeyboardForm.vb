Public Class KeyboardForm
    Public Property TargetTextBox As TextBox

    Private Sub Key_Click(sender As Object, e As EventArgs)
        If TargetTextBox IsNot Nothing Then
            Dim btn As Button = DirectCast(sender, Button)
            TargetTextBox.Text &= btn.Text ' Append text to the input field
        End If
    End Sub

    Private Sub KeyboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create buttons dynamically for a touch keyboard
        Dim keys As String = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM"
        Dim startX As Integer = 10
        Dim startY As Integer = 10
        Dim btnSize As Integer = 40

        For i As Integer = 0 To keys.Length - 1
            Dim btn As New Button()
            btn.Text = keys(i)
            btn.Width = btnSize
            btn.Height = btnSize
            btn.Left = startX + (i Mod 10) * btnSize
            btn.Top = startY + (i \ 10) * btnSize
            AddHandler btn.Click, AddressOf Key_Click
            Me.Controls.Add(btn)
        Next
    End Sub
End Class