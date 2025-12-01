Imports System.IO

Public Class PosWelcomeScreen
    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles LabelControlCompanyName.Click, LabelControl3.Click, LabelControl2.Click

    End Sub

    Private Sub PosWelcomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCompanyData()
        GetImage()
    End Sub
    Private Sub GetCompanyData()
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " select top(1) [CompanyName] from [dbo].[CompanyData]  "
            sql.SqlTrueAccountingRunQuery(sqlstring)
            LabelControlCompanyName.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetImage()
        Dim imagePath As String = "SecondScreen.jpg" ' Replace with the actual path
        ' Check if the image file exists
        If File.Exists(imagePath) Then
            ' Load the image into the PictureEdit control
            PictureEdit1.Image = Image.FromFile(imagePath)
        End If
    End Sub
End Class