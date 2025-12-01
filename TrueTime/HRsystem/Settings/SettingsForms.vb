Imports DevExpress.XtraEditors
Imports System.Threading.Thread
Imports System.Globalization
Imports System.Data.SqlClient

Public Class SettingsForms

    Dim AttFilePath As String
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = "ملف بيانات الساعة"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.mdb)|*.mdb|All files (*.mdb)|*.mdb"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            TextAttFileBath.Text = strFileName
            AttFilePath = TextAttFileBath.Text
        End If
        'ds
    End Sub

    Private Sub AttFileBath_EditValueChanged(sender As Object, e As EventArgs) Handles TextAttFileBath.EditValueChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Try
            If TextAttFileBath.Text <> String.Empty Then
                Dim sql As New SQLControl
                Dim SQLString As String = "Update Settings set SettingValue ='" & TextAttFileBath.Text & "'
                                           where  SettingName='AttFilePath'  "
                sql.SqlTrueTimeRunQuery(SQLString)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            If TextAttAplicationPath.Text <> String.Empty Then
                Dim sql As New SQLControl
                Dim SQLString As String = "Update Settings set SettingValue ='" & TextAttAplicationPath.Text & "'
                                           where  SettingName='AttAplicationPath'  "
                sql.SqlTrueTimeRunQuery(SQLString)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CheckVocationsOnOutDays.EditValue & "'
                                           where  SettingName='VocationAtOffDay'  "
            sql.SqlTrueTimeRunQuery(SQLString)

            Dim SQLString2 As String = "Update Settings set SettingValue ='" & CheckElapseTimeOnVocation.EditValue & "'
                                           where  SettingName='ElapseTimeZeroOnVocationDay'  "
            sql.SqlTrueTimeRunQuery(SQLString2)

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Select Case DaysInMonthOptions.EditValue
                Case "DaysInMonth"
                    Dim SQLString As String = "Update Settings set SettingValue ='DaysInMonth'
                                           where  SettingName='DaysInMonth'  "
                    sql.SqlTrueTimeRunQuery(SQLString)
                Case "ExactDays"
                    If ExactDaysInMonthText.EditValue > 0 Then
                        Dim SQLString As String = "Update Settings set SettingValue ='" & ExactDaysInMonthText.EditValue & "'
                                           where  SettingName='DaysInMonth'  "
                        sql.SqlTrueTimeRunQuery(SQLString)
                    End If
            End Select
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            If BonusOnDayOff.Text <> String.Empty Then
                Dim sql As New SQLControl
                Dim SQLString As String = "Update Settings set SettingValue ='" & BonusOnDayOff.Text & "'
                                           where  SettingName='BonusOnDayOff'  "
                sql.SqlTrueTimeRunQuery(SQLString)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & BonusAmountAfterRequirdHoures.EditValue & "'
                                           where  SettingName='BonusAmountAfterRequirdHoures'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & AttConnectionType.Text & "'
                                           where  SettingName='AttConnectionType'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CheckEditUseLocalDataBaseForReport.EditValue & "'
                                           where  SettingName='UseLocalDataBaseForReport'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CBool(AttAllowEditAttTrans.EditValue) & "'
                                           where  SettingName='AttAllowEditAttTrans'  "
            GlobalVariables._AttAllowEditAttTrans = CBool(AttAllowEditAttTrans.EditValue)
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CBool(ShowWorkLeavesData.EditValue) & "'
                                           where  SettingName='ShowWorkLeavesData'  "
            GlobalVariables._ShowWorkLeavesData = CBool(ShowWorkLeavesData.EditValue)
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CBool(AttNoteRequiredforAttTrans.EditValue) & "'
                                           where  SettingName='AttNoteRequiredforAttTrans'  "
            GlobalVariables._AttNoteRequiredforAttTrans = CBool(AttNoteRequiredforAttTrans.EditValue)
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try




        XtraMessageBox.Show("تم حفظ الاعدادات")

    End Sub

    Private Sub SettingsForms_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim sql As New SQLControl
            Dim i As Integer = 0
            Dim SQLString As String = "select SettingValue  From Settings where SettingName='AttFilePath'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables.Count > 0 Then TextAttFileBath.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = " select SettingValue  From Settings where SettingName='AttAplicationPath'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables.Count > 0 Then TextAttAplicationPath.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='VocationAtOffDay'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then CheckVocationsOnOutDays.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")

            SqlString = " select SettingValue From Settings where SettingName ='ElapseTimeZeroOnVocationDay'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then CheckElapseTimeOnVocation.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")


        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try




        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='DaysInMonth'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows(0).Item("SettingValue") = "DaysInMonth" Then
                DaysInMonthOptions.EditValue = "DaysInMonth"
                LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            Else
                DaysInMonthOptions.EditValue = "ExactDays"
                LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                ExactDaysInMonthText.EditValue = CDec(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try



        Try
            Dim sql As New SQLControl
            Dim SQLString As String = " select SettingValue  From Settings where SettingName='BonusOnDayOff'"
            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables.Count > 0 Then BonusOnDayOff.Text = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='BonusAmountAfterRequirdHoures'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then BonusAmountAfterRequirdHoures.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try



        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='Archive_DeleteDocAfterArchive'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then Archive_DeleteDocAfterArchive.EditValue = sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='ShowVocationBegBalanceInRawatebSplit'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then ShowVocationBegBalanceInRawatebSplit.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='ShowAccruedVocationDaysInRawatebSplit'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then ShowAccruedVocationDaysInRawatebSplit.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='ShowVocationAtEndYearInRawatebSplit'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then ShowVocationAtEndYearInRawatebSplit.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AddBonusBeforeShift'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AddBonusBeforeShift.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try



        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='SalaryNoteLabel'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then SalaryNoteText.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='VocationTableInMonthSalaryVisible'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then VocationTableInMonthSalaryVisible.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AttConnectionType'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AttConnectionType.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='GetSalaryPerHourFromEmployee_ShiftReport'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then GetSalaryPerHourFromEmployee_ShiftReport.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='UseLocalDataBaseForReport'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then CheckEditUseLocalDataBaseForReport.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AttAllowEditAttTrans'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AttAllowEditAttTrans.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AttShowAdditionsInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AttShowAdditionsInSalarySlip.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AttShowPaymentsInSalarySlip'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AttShowPaymentsInSalarySlip.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='ShowWorkLeavesData'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then ShowWorkLeavesData.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='AttNoteRequiredforAttTrans'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then AttNoteRequiredforAttTrans.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_SaveDataInSqlOrFolder'")
            Me.Archive_SaveDataInSqlOrFolder.EditValue = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: Archive_SaveDataInSqlOrFolder")
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='Archive_FolderPath'")
            Me.Archive_FolderPath.Text = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: Archive_FolderPath")
        End Try

        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HR_ActiveSavingFund'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then
                HR_ActiveSavingFund.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Else
                HR_ActiveSavingFund.EditValue = False
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='HR_CompanyContributionPercentage';
                                            Select SettingValue from [dbo].[Settings] where SettingName='HR_PersonalContributionPercentage'")
            Me.TextCompanyContribution.EditValue = CStr(Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
            Me.TextPersonalContribution.EditValue = CStr(Sql.SQLDS.Tables(1).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: Archive_FolderPath")
        End Try


        Try
            Dim sql As New SQLControl
            Dim SqlString As String
            SqlString = " select SettingValue From Settings where SettingName ='HRSystemIsConnectedWithAccountingSystem'"
            sql.SqlTrueTimeRunQuery(SqlString)
            If sql.SQLDS.Tables(0).Rows.Count > 0 Then CheckIfHRSystemIsConnectedWithAccountingSystem.EditValue = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        LoadCompanyData()



    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Try
            Dim _txtCompanyNameForWhattsUp As String
            If txtCompanyNameForWhattsUp.Text <> "" Then
                _txtCompanyNameForWhattsUp = txtCompanyNameForWhattsUp.Text
            Else
                _txtCompanyNameForWhattsUp = TextCompanyName.Text
            End If
            Dim sql As New SQLControl
            Dim SQLString As String = "  UPDATE [dbo].[CompanyData]
                                         SET [CompanyName] = N'" & TextCompanyName.Text & "' 
                                              ,[CompanyAddress] = N'" & TextCompanyAddress.Text & "' 
                                              ,[CompanyPhone] =  N'" & TextCompanyPhone.Text & "' 
                                              ,[CompanyMobile] = N'" & TextCompanyMobile.Text & "' 
                                              ,[CompanyFax] = N'" & TextCompanyFax.Text & "' 
                                              ,[CompanyEmail] = N'" & TextCompanyEmail.Text & "' 
                                              ,[CompanyWebSite] = N'" & TextCompanyWebSite.Text & "' 
                                              ,[CompanyFaceBook] = N'" & TextFaceBook.Text & "'
                                              ,[CompanyVAT] = N'" & TextCompanyVAT.Text & "'
                                              ,[CompanyNameForWhattsUp] = N'" & _txtCompanyNameForWhattsUp & "'"

            If sql.SqlTrueTimeRunQuery(SQLString) = True Then
                XtraMessageBox.Show("تم التعديل")
            Else
                MsgBoxShowError(" خطا في حفظ البيانات ")
            End If


        Catch ex As Exception
            '  XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            If Not PictureCompanyLogo.Image Is Nothing Then
                Dim m As New IO.MemoryStream
                PictureCompanyLogo.Image.Save(m, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim b() As Byte = m.ToArray()
                SavePhoto(b)
                '   Me.EmployeesDataTableAdapter.Fill(Me.TrueTimeDataSet.EmployeesData)
            End If
        Catch ex As Exception
            '   MsgBox("لم يتم حفظ الصورة")
        End Try
        LoadCompanyData()
    End Sub
    Private Sub SavePhoto(ByVal bytPhoto As Byte())
        Try
            Dim SQLString As String = " UPDATE CompanyData "
            SQLString = SQLString + " SET CompanyLogo = @photo "
            Dim cn As New SqlConnection(My.Settings.TrueTimeConnectionString)
            cn.Open()
            Using cmd As New SqlClient.SqlCommand(SQLString, cn)
                cmd.Parameters.Add("@photo", SqlDbType.Image, bytPhoto.Length).Value = bytPhoto
                Try
                    cmd.ExecuteNonQuery()
                Catch SqlExceptionErr As SqlClient.SqlException
                    MessageBox.Show(SqlExceptionErr.Message)
                End Try
            End Using
            cn.Close()
        Catch ex As Exception
            ' XtraMessageBox.Show("خطا: لم يتم حفظ الصورة")
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub LoadCompanyData()
        Try
            Dim sql As New SQLControl
            Dim i As Integer = 0
            Dim SQLString As String = "SELECT  [CompanyName]
                                              ,[CompanyAddress]
                                              ,[CompanyPhone]
                                              ,[CompanyMobile]
                                              ,[CompanyFax]
                                              ,[CompanyEmail]
                                              ,[CompanyWebSite]
                                              ,[CompanyFaceBook]
                                              ,[CompanyLogo]
                                              ,[CompanyVAT]
                                              ,[CompanyNameForWhattsUp]
                                      FROM [dbo].[CompanyData]"

            sql.SqlTrueTimeRunQuery(SQLString)
            If sql.SQLDS.Tables.Count > 0 Then
                TextCompanyName.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyName")
                TextCompanyAddress.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyAddress")
                TextCompanyPhone.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyPhone")
                TextCompanyMobile.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyMobile")
                TextCompanyFax.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFax")
                TextCompanyEmail.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyEmail")
                TextCompanyWebSite.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyWebSite")
                TextFaceBook.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyFaceBook")
                TextCompanyVAT.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyVAT")
                txtCompanyNameForWhattsUp.Text = sql.SQLDS.Tables(0).Rows(0).Item("CompanyNameForWhattsUp")
            End If

            GetImageCompany()

        Catch ex As Exception
            '  XtraMessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub GetImageCompany()
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            PictureCompanyLogo.Image = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        CreateProcessCol()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String

        fd.Title = " برنامج الساعة "
        fd.InitialDirectory = TextAttFileBath.Text
        fd.Filter = "All files (*.exe)|*.exe|All files (*.exe)|*.exe"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            TextAttAplicationPath.Text = strFileName
            ' AttFilePath = TextAttFileBath.Text
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NavigationPane1_Click(sender As Object, e As EventArgs) Handles NavigationPane1.Click

    End Sub

    Private Sub RadioGroup1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DaysInMonthOptions.SelectedIndexChanged
        ' If DaysInMonthOptions.EditValue = "DaysInMonth" Then MsgBox("DaysInMonthOptions")
        Select Case DaysInMonthOptions.EditValue
            Case "DaysInMonth"
                LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

            Case "ExactDays"
                LayoutControlItem19.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        End Select
    End Sub

    Private Sub DaysInMonthOptions_EditValueChanged(sender As Object, e As EventArgs) Handles DaysInMonthOptions.EditValueChanged
        'MsgBox(DaysInMonthOptions.EditValue)
        'If DaysInMonthOptions.EditValue = "ExactDays" Then
        '    LayoutControlItem19.Visibility = True
        'ElseIf DaysInMonthOptions.EditValue = "DaysInMonth" Then
        '    LayoutControlItem19.Visibility = False
        'End If
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles BtnSaveArchiveSettings.Click
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & Archive_DeleteDocAfterArchive.EditValue & "'
                                           where  SettingName='Archive_DeleteDocAfterArchive'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CStr(Archive_SaveDataInSqlOrFolder.EditValue) & "'
                                                  Where SettingName='Archive_SaveDataInSqlOrFolder'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Update [dbo].[Settings] Set 
                                                  SettingValue='" & CStr(Archive_FolderPath.EditValue) & "'
                                                  Where SettingName='Archive_FolderPath'")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub GetAccess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If CheckIfFormExist(Me.Name) = False Or HasAccessOnForm(Me.Name, "QueryAccess") = False Then
            Me.Close()
            MsgBox("لا يوجد صلاحية")
        End If
    End Sub

    Private Sub SimpleButton6_Click_2(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & ShowVocationBegBalanceInRawatebSplit.EditValue & "'
                                           where  SettingName='ShowVocationBegBalanceInRawatebSplit'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & ShowAccruedVocationDaysInRawatebSplit.EditValue & "'
                                           where  SettingName='ShowAccruedVocationDaysInRawatebSplit'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & ShowVocationAtEndYearInRawatebSplit.EditValue & "'
                                           where  SettingName='ShowVocationAtEndYearInRawatebSplit'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & AddBonusBeforeShift.EditValue & "'
                                           where  SettingName='AddBonusBeforeShift'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        If Len(SalaryNoteText.Text) < 1000 Then
            Try
                Dim sql As New SQLControl
                Dim SQLString As String = "Update Settings set SettingValue =N'" & SalaryNoteText.Text & "'
                                           where  SettingName='SalaryNoteLabel'  "
                sql.SqlTrueTimeRunQuery(SQLString)
            Catch ex As Exception
                XtraMessageBox.Show(ex.ToString)
            End Try
        Else
            XtraMessageBox.Show("ملاحظة الرواتب كبيرة يرجى اختصار الحروف")
        End If

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & VocationTableInMonthSalaryVisible.EditValue & "'
                                           where  SettingName='VocationTableInMonthSalaryVisible'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & GetSalaryPerHourFromEmployee_ShiftReport.EditValue & "'
                                           where  SettingName='GetSalaryPerHourFromEmployee_ShiftReport'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & AttShowAdditionsInSalarySlip.EditValue & "'
                                           where  SettingName='AttShowAdditionsInSalarySlip'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & AttShowPaymentsInSalarySlip.EditValue & "'
                                           where  SettingName='AttShowPaymentsInSalarySlip'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & HR_ActiveSavingFund.EditValue & "'
                                           where  SettingName='HR_ActiveSavingFund'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try

        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & TextCompanyContribution.EditValue & "'
                                           where  SettingName='HR_CompanyContributionPercentage';  "
            SQLString += "Update Settings set SettingValue ='" & TextPersonalContribution.EditValue & "'
                                           where  SettingName='HR_PersonalContributionPercentage'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try


        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & HR_ActiveSavingFund.EditValue & "'
                                           where  SettingName='HR_ActiveSavingFund'  "
            sql.SqlTrueTimeRunQuery(SQLString)
        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try
        Try
            Dim sql As New SQLControl
            Dim SQLString As String = "Update Settings set SettingValue ='" & CheckIfHRSystemIsConnectedWithAccountingSystem.EditValue & "'
                                           where  SettingName='HRSystemIsConnectedWithAccountingSystem'  "
            If sql.SqlTrueTimeRunQuery(SQLString) = True Then
                GlobalVariables._HRSystemIsConnectedWithAccountingSystem = CheckIfHRSystemIsConnectedWithAccountingSystem.EditValue
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.ToString)
        End Try



        'Try
        '    Dim sql As New SQLControl
        '    Dim SQLString As String = "Update Settings set SettingValue ='" & CBool(AttAllowEditAttTrans.EditValue) & "'
        '                                   where  SettingName='AttAllowEditAttTrans'  "
        '    sql.SqlTrueTimeRunQuery(SQLString)
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.ToString)
        'End Try

        MsgBox("تم حفظ الاعدادات")
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles AddBonusBeforeShift.CheckedChanged

    End Sub

    Private Sub ExactDaysInMonthText_EditValueChanged(sender As Object, e As EventArgs) Handles ExactDaysInMonthText.EditValueChanged

    End Sub

    Private Sub SoftLanguage_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckEditUseLocalDataBase_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditUseLocalDataBaseForReport.CheckedChanged

    End Sub

    Private Sub CheckEdit1_CheckedChanged_1(sender As Object, e As EventArgs) Handles AttAllowEditAttTrans.CheckedChanged

    End Sub

    Private Sub Archive_FolderPath_Properties_Click(sender As Object, e As EventArgs) Handles Archive_FolderPath.Properties.Click

    End Sub
End Class