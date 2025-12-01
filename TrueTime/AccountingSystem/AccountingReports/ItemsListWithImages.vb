Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class ItemsListWithImages
    Public _WithPrice As Boolean = True
    Private Sub XtraReport4_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        Dim _MyCompanyData = GetCompanyData()
        XrCompanyName.Text = _MyCompanyData.CompanyName

        Dim _MobileString As String = ""
        If _MyCompanyData.CompanyMobile <> "" Then
            _MobileString = " موبايل " & " : " & _MyCompanyData.CompanyMobile
        End If
        If _MyCompanyData.CompanyPhone <> "" Then
            _MobileString = " هاتف " & " : " & _MyCompanyData.CompanyPhone
        End If
        Me.XrLabelMobilePhone.Text = _MobileString

        If _MyCompanyData.CompanyAddress <> "" Then
            XrLabelAddress.Text = " العنوان: " & _MyCompanyData.CompanyAddress
        End If

        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            XrPictureLogo.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try
        Me.PrintingSystem.ShowMarginsWarning = False
        If _WithPrice = False Then
            XrLabelPrice1Header.Text = ""
            XrLabelPriceField.Visible = False
        End If
    End Sub
End Class