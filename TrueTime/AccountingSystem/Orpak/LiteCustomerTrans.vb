Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class LiteCustomerTrans
    Private Sub LiteCustomerTrans_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint


        Dim _HeaderImage
        _HeaderImage = Nothing

        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select HeaderImage from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            _HeaderImage = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try


        HeaderPicture.Image = _HeaderImage


        XrLabelDateTime.Text = " تاريخ الطباعة: " & Format(CDate(Now), "yyyy-MM-dd HH:mm")
        XrLabelUser.Text = " المستخدم:  " & CurrUser

        Dim _PrintProparites = GetPrintingProperites("AccountStatment")
        Margins.Right = _PrintProparites.Margins_Right
        Margins.Left = _PrintProparites.Margins_Left
        Margins.Top = _PrintProparites.Margins_Top
        Margins.Bottom = _PrintProparites.Margins_Bottom

        XrLabel3.Visible = False
        'HeaderPicture.Visible = False
    End Sub
End Class