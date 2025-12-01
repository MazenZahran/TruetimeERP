Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class PosTestBarcode
    Private Sub PosTestBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub PosTestBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' MsgBox("KeyPress")
    End Sub

    Private Sub PosTestBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        ' MsgBox("KeyUp")
    End Sub

    Private Sub PosTestBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'MsgBox()
        TextEdit1.Select()

        ' MsgBox("KeyDown")
    End Sub
    Private lastKeyPressTime As DateTime = DateTime.Now
    Private barcodeBuffer As String = ""

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim timeSinceLastKeyPress = DateTime.Now - lastKeyPressTime

        ' Check if the time between keypresses is longer than a certain threshold.
        ' This helps to determine if the input is from the barcode scanner.
        If timeSinceLastKeyPress.TotalMilliseconds > 50 Then
            barcodeBuffer = ""
        End If

        ' Append the barcode scanner input to TextBox1.
        barcodeBuffer += e.KeyChar.ToString()
        TextEdit1.Text = barcodeBuffer

        ' Clear TextBox2.
        TextEdit2.Text = ""

        ' Update the last key press time.
        lastKeyPressTime = DateTime.Now
    End Sub
End Class