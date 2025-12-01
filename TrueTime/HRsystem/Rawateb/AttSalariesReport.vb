Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class AttSalariesReport
    Private Sub AttSalariesReport_BeforePrint(sender As Object, e As CancelEventArgs) Handles Me.BeforePrint
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            XrPictureBox1.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

        Try
            Dim _DocSignatur = GetDocumentSignatures("AttSalariesReport")
            Me.XrLabelSignature1.Text = _DocSignatur.signature1
            Me.XrLabelSignature2.Text = _DocSignatur.signature2
            Me.XrLabelSignature3.Text = _DocSignatur.signature3
            Me.XrLabelSignature4.Text = _DocSignatur.signature4
        Catch ex As Exception
            Me.XrLabelSignature1.Text = ""
            Me.XrLabelSignature2.Text = ""
            Me.XrLabelSignature3.Text = ""
            Me.XrLabelSignature4.Text = ""
        End Try

        Dim _Companydata = GetCompanyData()
        XrLabelCompanyName.Text = _Companydata.CompanyName

    End Sub
End Class