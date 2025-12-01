Public Class WebForm
    Private Sub WebForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WebBrowser1.Navigate("https://www.google.com")
    End Sub

    Private Sub webBrowser1_DocumentTitleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles WebBrowser1.DocumentTitleChanged
        Me.Text = WebBrowser1.DocumentTitle
    End Sub
    Private Sub toolStripTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles toolStripTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Navigate(toolStripTextBox1.Text)
        End If
    End Sub

    Private Sub goButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGo.Click
        Navigate(toolStripTextBox1.Text)
    End Sub

    Private Sub Navigate(ByVal address As String)
        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return

        If Not address.StartsWith("http://") AndAlso Not address.StartsWith("https://") Then
            address = "http://" & address
        End If

        Try
            WebBrowser1.Navigate(New Uri(address))
        Catch __unusedUriFormatException1__ As System.UriFormatException
            Return
        End Try
    End Sub

    Private Sub webBrowser1_Navigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        toolStripTextBox1.Text = WebBrowser1.Url.ToString()
    End Sub


End Class