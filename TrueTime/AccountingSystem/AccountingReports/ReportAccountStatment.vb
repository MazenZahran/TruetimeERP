Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class ReportAccountStatment
    Private Sub ReportAccountStatment_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        If Me.XrLabelReforAcc.Text = "True" Then
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("select SettingValue from [dbo].[Settings] where SettingName=N'AccountingStatmentRefNote'")
            XrLabelReportNote.Text = "  " & " ملاحظة: " & sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
                XrLabelReportNote.Text = "  " & "Note: " & sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
            End If

        Else
            XrLabelReportNote.Visible = False
        End If


        Dim _HeaderImage, _FooterImage As Image
        _HeaderImage = Nothing
        _FooterImage = Nothing
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
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select FooterImage from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            _FooterImage = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

        HeaderPicture.Image = _HeaderImage
        FooterPicture.Image = _FooterImage

        XrLabelDateTime.Text = " تاريخ الطباعة: " & Format(CDate(Now), "yyyy-MM-dd HH:mm")
        XrLabelUser.Text = " المستخدم:  " & CurrUser

        Dim _PrintProparites = GetPrintingProperites("AccountStatment")
        Margins.Right = _PrintProparites.Margins_Right
        Margins.Left = _PrintProparites.Margins_Left
        Margins.Top = _PrintProparites.Margins_Top
        Margins.Bottom = _PrintProparites.Margins_Bottom

        XrLabel3.Visible = False
        'HeaderPicture.Visible = False


        Dim _SoftwareID As Integer = GlobalVariables.LocalSoftwareID
        If GlobalVariables._Accounting_PrintAccountStatmentByEnglish = True Then
            XrLabelAccountStatment.Text = "Account Statment"
            Me.RightToLeft = False
            Me.RightToLeftLayout = False
            XrLabelAccountLabel.Text = "Accont: "
            XrLabelCurrencyLabel.Text = "Curr.:"
            XrLabelDateTime.Text = "Printed@ " & Format(CDate(Now), "yyyy-MM-dd HH:mm")
            XrLabelUser.Text = "User: " & CurrUser


        End If

    End Sub
End Class