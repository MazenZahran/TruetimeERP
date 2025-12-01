Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class CarRentDocs
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GetCarRentDocuments()
    End Sub
    Private Sub GetCarRentDocuments()
        Try
            Dim Sql As New SQLControl
            Dim SqlString As String
            SqlString = " SELECT [DocID],[ReferanceID],[DocStartDate],[DocEndDate],
	                             CONCAT( case when [DocEndDate] > [DocStartDate] then (DATEPART(YEAR,   [DocEndDate] - [DocStartDate])-1900) * 365 +
                                 (DATEPART(MONTH,   [DocEndDate] - [DocStartDate])-1) *30 +(DATEPART(DAY,   [DocEndDate] - [DocStartDate])-1) else '' End, N'يوم و ' ,
	                             Case when [DocEndDate] > [DocStartDate] then DATEPART(HOUR,   [DocEndDate] - [DocStartDate]) else '' End,N'ساعة' ) as CarPeriod,
                                 [OdometerFrom]       ,[OdometerFrom]      ,[OdometerTo]      ,[Amount]      ,[Currency]      ,[ExchangeRate],
                                 [DocBaseAmount]      ,[DocNotes]      ,[DocStatus]      ,[CarID]      ,R.RefName as [ReferanceName]
                           FROM  [dbo].[CarRentDocuments]  D
                                 Left join Referencess R on D.ReferanceID=R.RefNo"
            If SearchDocStatus.EditValue <> -1 Then SqlString += " Where  DocStatus =" & SearchDocStatus.EditValue
            Sql.SqlTrueAccountingRunQuery(SqlString)
            GridControl1.DataSource = Sql.SQLDS.Tables(0)
            BandedGridView1.BestFitColumns()
        Catch ex As Exception
            GridControl1.DataSource = ""
        End Try
        If SearchDocStatus.EditValue <> 1 Then
            BandedReceiveCar.Visible = False
        Else
            BandedReceiveCar.Visible = True
        End If
        If SearchDocStatus.EditValue = 3 Then
            ColIssueVoucher.Visible = False
        Else
            ColIssueVoucher.Visible = True
        End If
    End Sub
    Private Function IsVouchred(ByVal view As GridView, ByVal row As Integer) As Boolean
        Dim _Res As Boolean
        Try
            Dim col As GridColumn = view.Columns("DocStatus")
            Dim val As Integer = Convert.ToString(view.GetRowCellValue(row, col))
            If val = 3 Then
                _Res = True
            Else
                _Res = False
            End If
        Catch ex As Exception
            _Res = False
        End Try

        Return _Res
    End Function
    Private Sub GridView2_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BandedGridView1.ShowingEditor
        Dim view As GridView = TryCast(sender, GridView)
        'If (view.FocusedColumn.FieldName = "IssueVoucher") AndAlso IsVouchred(view, view.FocusedRowHandle) = True Then
        '    e.Cancel = True
        'End If
        If (view.FocusedColumn.FieldName = "IssueVoucher") AndAlso view.GetFocusedRowCellValue("DocStatus") = 3 Then
            e.Cancel = True
        End If
        If (view.FocusedColumn.FieldName = "ReceiveCar") AndAlso (view.GetFocusedRowCellValue("DocStatus") = 2 Or view.GetFocusedRowCellValue("DocStatus") = 3) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub RepositoryOpen_Click(sender As Object, e As EventArgs) Handles RepositoryOpen.Click
        My.Forms.CarRentDoc.DocID.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocID")
        My.Forms.CarRentDoc.TextDocForWhat.Text = "OpenDoc"
        If CarRentDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetCarRentDocuments()
        End If
    End Sub

    Private Sub CarRentDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetCars()
        RepositoryDocStatus.DataSource = CreateRentDocumentsStatusTable()
        SearchDocStatus.Properties.DataSource = CreateRentDocumentsStatusTable()
        SearchDocStatus.EditValue = 1
        '  GetCarRentDocuments()
        gridBandOdometer.Visible = False

    End Sub
    Private Sub GetCars()
        Dim Sql As New SQLControl
        Sql.SqlTrueAccountingRunQuery("Select CarID,CARNO From [dbo].[CarsRent]")
        RepositoryCar.DataSource = Sql.SQLDS.Tables(0)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        My.Forms.CarRentDoc.DocID.Text = "-1"
        My.Forms.CarRentDoc.TextDocForWhat.Text = "RentCar"
        My.Forms.CarRentDoc.Text = "سند تأجير مركبة"
        My.Forms.CarRentDoc.LabelFormName.Text = "سند تأجير مركبة"
        'My.Forms.CarRentDoc.PanelControl1.BackColor = Color.OrangeRed
        If CarRentDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetCarRentDocuments()
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        My.Forms.CarRentDoc.DocID.Text = "-1"
        My.Forms.CarRentDoc.TextDocForWhat.Text = "ReceiveCar"
        My.Forms.CarRentDoc.Text = "سند استلام مركبة"
        My.Forms.CarRentDoc.LabelFormName.Text = "سند استلام مركبة"
        '  My.Forms.CarRentDoc.PanelControl1.BackColor = Color.LimeGreen
        If CarRentDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetCarRentDocuments()
        End If
    End Sub

    Private Sub RepositoryIssueVoucher_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryIssueVoucher.ButtonClick
        Dim _DocStatus As String = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocStatus")
        Dim _CarID As String = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "CarID")
        Select Case _DocStatus
            Case 1
                MsgBox("يجب استلام المركبة لكي يتم فوترة السند")
                Exit Sub
            Case 2
                If CheckIfCarHasSerivce(_CarID) = "0" Then
                    MsgBox("يجب أن تكون المركبة مرتبظة بخدمة لاصدار فاتورة")
                    My.Forms.CarEdit.TextSearchCarID.Text = _CarID
                    My.Forms.CarEdit.SearchRelatedService.Select()
                    If CarEdit.ShowDialog() = DialogResult.OK Then
                        MsgBox("ok")
                    End If
                    Exit Sub
                End If
                My.Forms.CarRentDoc.DocID.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocID")
                My.Forms.CarRentDoc.TextDocForWhat.Text = "IssueVoucher"
                If CarRentDoc.ShowDialog() = DialogResult.OK Then
                    MsgBox("ok")
                Else
                    GetCarRentDocuments()
                End If
            Case 3
                MsgBox("سند الايجار صدرت به فاتورة هل تريد فتح الفاتورة")
                Exit Sub
        End Select
    End Sub
    Private Function CheckIfCarHasSerivce(CarID As Integer) As String
        Dim _Service As String
        Try
            Dim Sql As New SQLControl
            Sql.SqlTrueAccountingRunQuery("Select RelatedService From [dbo].[CarsRent] where CarID=" & CarID)
            _Service = Sql.SQLDS.Tables(0).Rows(0).Item("RelatedService")
            If _Service = "" Then _Service = "0"
        Catch ex As Exception
            MsgBox(ex.ToString)
            _Service = "0"
        End Try
        Return _Service
    End Function

    Private Sub RepositoryPrintDoc_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryPrintDoc.ButtonClick
        Dim report As New CarRentpaper()
        With report
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT   [DocID],[DocStartDate]
		                            ,[DocEndDate],[OdometerFrom]
		                            ,[OdometerTo],[Amount]
		                            ,[Currency],[ExchangeRate]
		                            ,[DocBaseAmount],[DocNotes]
		                            ,[DocStatus],[ReferanceName]
		                            ,[DocNote2],[VoucherNo]
		                            ,[DocCode],C.CARNO ,M.CarModel,DATEDIFF(day, [DocStartDate],[DocEndDate]) as DayNo
		                            ,R.RefName ,R.RefBirthDate ,R.Address ,R.RefMobile,DATEDIFF(year,RefBirthDate, GetDate()) as Age
                                    ,IsNull(T.CarType,'') as CarType,IsNull(ColorName,'') as ColorName ,D.[DailyAmount],[FuelPercentage]
                                    ,[AddDriverName],[AddDriverIdentityNo],[AddDriverIdentityType],[AddDriverBirthday]
                                    ,[AddDriverTarkhesIssueDate],[AddDriverTarkhesEndDate],R.IdentityNo,R.Nationality,R.IdentityType,R.TarkhesID,R.TarkhesIssueDate,R.TarkhesEndDate,R.Address
                          FROM [dbo].[CarRentDocuments] D
                          left join CarsRent C on C.CarID=D.CarID 
                          left join Referencess R on R.RefNo =D.ReferanceID  
                          left join CarsModel M on C.CarModel = M.CarModelID 
                          left join [dbo].[CarsTypes] T on T.CarTypeID=C.CarType
                          left join [dbo].[ItemsColors] IC on IC.ID=C.ColorCar
                          where [DocID]=" & BandedGridView1.GetFocusedRowCellValue("DocID")
            sql.SqlTrueAccountingRunQuery(sqlstring)
            If sql.SQLDS.Tables(0).Rows.Count = 0 Then Exit Sub
            report.XrLabelDocNo.Text = BandedGridView1.GetFocusedRowCellValue("DocID")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStartDate")) Then report.XrLabelDocDate.Text = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocStartDate")), "yyyy-MM-dd")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CARNO")) Then report.XrLabelCarNo.Text = sql.SQLDS.Tables(0).Rows(0).Item("CARNO")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("CarModel")) Then report.XrLabelCarType.Text = sql.SQLDS.Tables(0).Rows(0).Item("CarModel") & " / " & sql.SQLDS.Tables(0).Rows(0).Item("CarType")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("ColorName")) Then report.XrLabelCarColor.Text = sql.SQLDS.Tables(0).Rows(0).Item("ColorName")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocStartDate")) Then report.XrLabelDateOfOut.Text = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocStartDate")), "yyyy-MM-dd HH:mm")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DocEndDate")) Then report.XrLabelDateOfIn.Text = Format(CDate(sql.SQLDS.Tables(0).Rows(0).Item("DocEndDate")), "yyyy-MM-dd HH:mm")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DayNo")) Then report.XrLabelDaysNo.Text = sql.SQLDS.Tables(0).Rows(0).Item("DayNo")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("OdometerFrom")) Then report.XrLabelSpedometer.Text = sql.SQLDS.Tables(0).Rows(0).Item("OdometerFrom")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefName")) Then report.XrLabelRefName.Text = sql.SQLDS.Tables(0).Rows(0).Item("RefName")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefBirthDate")) Then report.XrLabelRefBirthday.Text = sql.SQLDS.Tables(0).Rows(0).Item("RefBirthDate")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Address")) Then report.XrLabelAddress.Text = sql.SQLDS.Tables(0).Rows(0).Item("Address")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")) Then report.XrLabelPhone.Text = sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Age")) Then report.XrGaugeAge.ActualValue = CInt(sql.SQLDS.Tables(0).Rows(0).Item("Age"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("DailyAmount")) Then report.XrLabelCarDailyAmount.Text = CInt(sql.SQLDS.Tables(0).Rows(0).Item("DailyAmount"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("FuelPercentage")) Then report.XrGauge1.ActualValue = CInt(sql.SQLDS.Tables(0).Rows(0).Item("FuelPercentage"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverName")) Then report.XrLabelAddDriverName.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverName"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityNo")) Then report.XrLabelAddDriverIdentityNo.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverIdentityNo"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverBirthday")) Then report.XrLabelAddDriverBirthday.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverBirthday"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesIssueDate")) Then report.XrLabelAddDriverTarkhesIssueDate.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesIssueDate"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesEndDate")) Then report.XrLabelAddDriverTarkhesEndDate.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("AddDriverTarkhesEndDate"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IdentityNo")) Then report.XrLabelRefDocNo.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("IdentityNo"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Nationality")) Then report.XrLabelRefNationality.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Nationality"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("IdentityType")) Then report.XrLabelRefDocType.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("IdentityType"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesID")) Then report.XrLabelLicense.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesID"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesIssueDate")) Then report.XrLabelLicenseIssDate.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesIssueDate"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate")) Then report.XrLabelLicenseExpDate.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("TarkhesEndDate"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Address")) Then report.XrLabelAddress.Text = CStr(sql.SQLDS.Tables(0).Rows(0).Item("Address"))
            If Not IsDBNull(sql.SQLDS.Tables(0).Rows(0).Item("Amount")) Then report.XrLabelCarDocAmount.Text = CInt(sql.SQLDS.Tables(0).Rows(0).Item("Amount"))
            report.XrLabelNote1.Text = "" & ControlChars.CrLf
            report.XrLabelNote1.Text = "  المكتب غير مسؤول عن أية أغراض شخصية داخل المركبة بعد تسليمها " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " يوم الجمعة عطلة رسمية لا يجوز فيه تسليم المركبة " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " تزويد المركبة بنزين 95 فقط " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " في حال وقوع حادث يتحمل المستأجر أجرة المركبة والتصليح " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " في حال وقوع حادث يتحمل المستأجر ثمانية ألاف شيكل و تقرير الشرطة و فترة الصيانة " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " لقد قرأت التعليمات والشروط المذكورة على جانبي هذه الاتفاقية ووافقت عليها " & "*" & ControlChars.CrLf
            report.XrLabelNote1.Text += " أنا الموقع أدناه ..................................................... موافق على ما جاء بالعقد " & "" & ControlChars.CrLf

            Dim _MyCompanyData = GetCompanyData()
            report.XrLabelCompanyNameAr.Text = _MyCompanyData.CompanyName
            report.XrLabelCompanyAddressAr.Text = _MyCompanyData.CompanyAddress
            If _MyCompanyData.CompanyMobile <> "" Then
                report.XrLabelCompanyMobile.Text = " موبايل: " & _MyCompanyData.CompanyMobile
            End If
            If _MyCompanyData.CompanyPhone <> "" Then
                report.XrLabelCompanyPhone.Text = " هاتف:  " & _MyCompanyData.CompanyPhone
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
                .XrPictureBox1.Image = Image.FromStream(ImgStream)
                ImgStream.Dispose()
                cmd.Connection.Close()
                cn.Close()
            Catch ex As Exception

            End Try
            report.PrintingSystem.ShowMarginsWarning = False
            '.Print()
            'AddHandler   report.PrintingSystem.StartPrint += New DevExpress.XtraPrinting.PrintDocumentEventHandler(AddressOf PrintingSystem_StartPrint)
            AddHandler report.PrintingSystem.StartPrint, AddressOf PrintingSystem_StartPrint
            report.ShowPreview()



        End With
    End Sub
    Private Sub PrintingSystem_StartPrint(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintDocumentEventArgs)
        e.PrintDocument.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Horizontal
    End Sub

    Private Sub CheckShowOdometer_CheckedChanged(sender As Object, e As EventArgs) Handles CheckShowOdometer.CheckedChanged
        Me.gridBandOdometer.Visible = CheckShowOdometer.CheckState
    End Sub

    Private Sub RepositoryReceiveCar_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryReceiveCar.ButtonClick
        My.Forms.CarRentDoc.DocID.Text = "-1"
        My.Forms.CarRentDoc.TextDocForWhat.Text = "ReceiveCar"
        My.Forms.CarRentDoc.Text = "سند استلام مركبة"
        My.Forms.CarRentDoc.LabelFormName.Text = "سند استلام مركبة"
        My.Forms.CarRentDoc.DocID.Text = BandedGridView1.GetFocusedRowCellValue("DocID")
        '  My.Forms.CarRentDoc.PanelControl1.BackColor = Color.LimeGreen
        If CarRentDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetCarRentDocuments()
        End If
    End Sub

    Private Sub RepositoryItemHyperLinkDocID_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemHyperLinkDocID.ButtonClick

    End Sub

    Private Sub RepositoryItemHyperLinkDocID_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkDocID.Click
        My.Forms.CarRentDoc.DocID.Text = BandedGridView1.GetRowCellValue(BandedGridView1.FocusedRowHandle, "DocID")
        My.Forms.CarRentDoc.TextDocForWhat.Text = "OpenDoc"
        If CarRentDoc.ShowDialog() = DialogResult.OK Then
            MsgBox("ok")
        Else
            GetCarRentDocuments()
        End If
    End Sub

    Private Sub SearchDocStatus_EditValueChanged(sender As Object, e As EventArgs) Handles SearchDocStatus.EditValueChanged
        GetCarRentDocuments()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        My.Forms.CarRentRolesText.Show()
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
    '    Dim filename As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
    '    Dim contentType As String = FileUpload1.PostedFile.ContentType
    '    Using fs As Stream = FileUpload1.PostedFile.InputStream
    '        Using br As New BinaryReader(fs)
    '            Dim bytes As Byte() = br.ReadBytes(DirectCast(fs.Length, Long))
    '            Dim constr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
    '            Using con As New SqlConnection(constr)
    '                Dim query As String = "insert into tblFiles values (@Name, @ContentType, @Data)"
    '                Using cmd As New SqlCommand(query)
    '                    cmd.Connection = con
    '                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename
    '                    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contentType
    '                    cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes
    '                    con.Open()
    '                    cmd.ExecuteNonQuery()
    '                    con.Close()
    '                End Using
    '            End Using
    '        End Using
    '    End Using
    '    Response.Redirect(Request.Url.AbsoluteUri)
    'End Sub
End Class