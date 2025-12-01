Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports DevExpress.XtraEditors

Public Class SalaryReport
    Public DocID As Integer
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub SalaryReport_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.BeforePrint
        Dim _SoftwareID As String = "0"
        Dim sql As New SQLControl
        Try
            Dim SqlString As String
            SqlString = " SELECT top(1) [CompanyName] ,[CompanyAddress] ,[CompanyPhone],[CompanyMobile] ,[CompanyFax],[CompanyEmail] ,[CompanyWebSite],IsNull([SoftwareID],'0') as SoftwareID
                              FROM [CompanyData] "
            sql.SqlTrueTimeRunQuery(SqlString)
            Parameters("ComapnyName").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
            Parameters("CompanyAddress").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress")
            Parameters("CompanyPhone").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone")
            Parameters("CompanyFax").Value = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFax")
            _SoftwareID = sql.SQLDS.Tables(0).Rows(0).Item("SoftwareID")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

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
            If String.IsNullOrEmpty(XrLabelFaxParameter.Text) Then
                XrLabelFax.Visible = False
            Else
                XrLabelFax.Visible = True
            End If

            If String.IsNullOrEmpty(XrLabelPhoneParameters.Text) Then
                XrLabelPhone.Visible = False
            Else
                XrLabelPhone.Visible = True
            End If

        Catch ex As Exception

        End Try

        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='SalaryNoteLabel'"
            sql.SqlTrueTimeRunQuery(SqlString)
            Me.NoteLabel.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            Me.NoteLabel.Text = " :بتوقيع الموظف على هذا الكشف يقر أنه قد قام باستلام مستحقاته كاملة ويوافق على ما جاء في هذه القسيمة من ارصدة "
        End Try




        Dim GetAddField As String
        Try
            sql.SqlTrueTimeRunQuery(" select FieldString from AddCustomField ")
            GetAddField = sql.SQLDS.Tables(0).Rows(0).Item("FieldString")
            If String.IsNullOrEmpty(GetAddField) Or IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FieldString")) Then
                GetAddField = " "
            Else
                GetAddField += " As GrossSalary "
            End If
        Catch ex As Exception
            GetAddField = ""
        End Try
        If GetAddField <> "" Then
            Dim sqlString As String = " Select top(1) " & GetAddField & " from AttRawatebArchive where ID=" & DocID
            sql.SqlTrueTimeRunQuery(sqlString)
            XrGrossSalary.Text = sql.SQLDS.Tables(0).Rows(0).Item("GrossSalary")
        Else
            XrGrossSalary.Visible = False
            XrLabelXrGrossSalary.Visible = False
        End If

        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowGrossSalaryInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelXrGrossSalary.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrGrossSalary.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelXrGrossSalary.Visible = False
            XrGrossSalary.Visible = False
        End Try

        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ActiveSavingFund'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelParameterSavingsFund.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelSavingsFund.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelParameterSavingsFund.Visible = False
            XrLabelSavingsFund.Visible = False
        End Try


        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowBonusAmountInInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelBonusHours.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelBonusHoursParameters.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelBonusHours.Visible = True
            XrLabelBonusHoursParameters.Visible = True
        End Try


        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowBonusAmountInInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelAdditionsAmount.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelAdditionsParameters.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelAdditionsAmount.Visible = True
            XrLabelAdditionsParameters.Visible = True
        End Try


        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowLeavesHouresInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelLeavesHours.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelLeavesHoursParameters.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelLeavesHours.Visible = True
            XrLabelLeavesHoursParameters.Visible = True
        End Try

        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowLeavesAmountInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelDeductLate.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelDeductLateParameter.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelDeductLate.Visible = True
            XrLabelDeductLateParameter.Visible = True
        End Try

        Try
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ShowActualHouresInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            XrLabelActualHoures.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            XrLabelActualHouresParameters.Visible = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XrLabelActualHoures.Visible = True
            XrLabelActualHouresParameters.Visible = True
        End Try





        'Select Case _SoftwareID
        '    Case "19"
        '        XrLabelProcessTypeWords.Visible = False
        '        XrLabelLeavesHours.Visible = False
        '        XrLabelLeavesHoursParameters.Visible = False
        '        '  XrLabelAdditionsAmount.Text = ":" & " بدل ساعات عمل اضافي "
        '        XrLabelAdditionsAmount.TextFitMode = DevExpress.XtraReports.UI.TextFitMode.ShrinkAndGrow
        '        XrLabelTransport.Visible = False
        '        XrTranport.Visible = False
        '        XrLabelRequiredHours.Visible = False
        '        XrLabelRequiredHoursParameters.Visible = False
        '        XrLabelActualHoures.Visible = False
        '        XrLabelActualHouresParameters.Visible = False
        '    Case "20"

        'End Select

        '  MsgBox(XrLabelMonthSalaryParameter.Value)

    End Sub

    Private Sub SalaryReport_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint
        'PrintableComponentContainer1.WidthF = XrPanel4.WidthF - 100
        'PrintableComponentContainerAdds.WidthF = XrPanel4.WidthF - 100
        'PrintableComponentContainerDiscount.WidthF = XrPanel4.WidthF - 100
    End Sub
End Class