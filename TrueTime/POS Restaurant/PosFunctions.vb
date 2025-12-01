Imports System.Data.SqlClient
Imports System.Threading
Imports System.Windows
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports TrueTime.SinglePageReport

Module PosFunctions
    Public Function InsertIntoPOSJournalByStoredProcedure(
    _ItemBarcode As String,
    _DocName As String,
    _Quantity As Decimal,
    _WhereHouse As Integer,
    _DocCode As String,
    _ReferanceNo As String,
    _ItemNo As Integer,
    _Unit As Integer,
    _Shelf As Integer,
    _NoteByItem As String) As Integer

        ' Validate if discount has been applied
        If My.Forms.POSRestCashier.TextVoucherDiscount2.EditValue > 0 Then
            MsgBoxShowError("لا يمكن تعديل الاسعار بعد خصم الفاتورة يرجى ازالة خصم الفاتورة أولا")
            Return 0
        End If

        ' Handle reference number
        Dim _RefNo As Integer = 0
        If Not String.IsNullOrEmpty(_ReferanceNo) Then
            Integer.TryParse(_ReferanceNo, _RefNo)
        End If

        Try
            ' Create connection with Using block for proper disposal
            Using sqlCon As New SqlConnection(My.Settings.TrueTimeConnectionString)
                ' Create command
                Using sqlComm As New SqlCommand("InsertIntoPOSJournal", sqlCon)
                    ' Set command properties
                    sqlComm.CommandType = CommandType.StoredProcedure
                    sqlComm.CommandTimeout = 1000

                    ' Add parameters
                    With sqlComm.Parameters
                        .AddWithValue("Barcode", _ItemBarcode)
                        .AddWithValue("DocName", _DocName)
                        .AddWithValue("Quantity", _Quantity)
                        .AddWithValue("WahreHouse", _WhereHouse)
                        .AddWithValue("DocCode", _DocCode)
                        .AddWithValue("ReferanceNo", _RefNo)
                        .AddWithValue("Device", GlobalVariables.CurrDevice)
                        .AddWithValue("ShiftID", GlobalVariables._ShiftID)
                        .AddWithValue("POSNo", My.Settings.POSNo)
                        .AddWithValue("UserNo", GlobalVariables.CurrUser)
                        .AddWithValue("ItemNo", _ItemNo)
                        .AddWithValue("Unit", _Unit)
                        .AddWithValue("shelf", _Shelf)
                        .AddWithValue("NoteByItem", _NoteByItem)

                        ' Add output parameter
                        Dim outputParameter As New SqlParameter("@OutputID", SqlDbType.Int) With {
                        .Direction = ParameterDirection.Output
                    }
                        .Add(outputParameter)
                    End With

                    ' Execute command
                    sqlCon.Open()
                    sqlComm.ExecuteNonQuery()

                    ' Get output value
                    Dim outputID As Integer = 0
                    If Not IsDBNull(sqlComm.Parameters("@OutputID").Value) Then
                        outputID = Convert.ToInt32(sqlComm.Parameters("@OutputID").Value)
                    End If
                    My.Forms.POSRestCashier.txtBarcode.Focus()
                    Return outputID
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
            Return 0
        End Try
    End Function

    Public Function PosPrinterSize() As Decimal
        Dim _Size As Integer
        _Size = 200
        Try
            Dim sql As New SQLControl
            sql.SqlTrueTimeRunQuery("Select [SettingValue] as PrinterSize
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosPrinterSize' ")
            _Size = sql.SQLDS.Tables(0).Rows(0).Item("PrinterSize")

        Catch ex As Exception
            _Size = 200
        End Try
        Return _Size
    End Function
    Public Sub PosPrintVoucherEmpty()
        Dim report As New XtraReportEmpty With {
            .ShowPrintMarginsWarning = False
        }
        report.PrintingSystem.ShowMarginsWarning = False
        report.Print()
    End Sub

    Public Function UseVoucherCount() As Boolean
        Dim _UseVoucherCounter As Boolean
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery(" Select SettingValue from [dbo].[Settings] where SettingName='PosUseVoucherCounterInsteadVoucherNo'")
            _UseVoucherCounter = CBool(sql.SQLDS.Tables(0).Rows(0).Item("SettingValue"))
        Catch ex As Exception
            MsgBox("Err: PosPostVouchers")
            _UseVoucherCounter = False
        End Try
        Return _UseVoucherCounter
    End Function
    Public Function GetVoucherAddedNotes() As (Note1 As String, Note2 As String)
        Dim _Note1 As String = " "
        Dim _Note2 As String = " "
        Dim Sql As New SQLControl
        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    from [dbo].[Settings]
                                    where  [SettingName]='PosVoucherNote1' ")
            _Note1 = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception

        End Try

        Try
            Sql.SqlTrueAccountingRunQuery("Select [SettingValue]
                                    From [dbo].[Settings]
                                    where  [SettingName]='PosVoucherNote2' ")
            _Note2 = Sql.SQLDS.Tables(0).Rows(0).Item("SettingValue")
        Catch ex As Exception

        End Try

        Return (_Note1, _Note2)

    End Function
    Public Function GetPosVoucherData(DocCode As String) As (DocName As Integer, DocNo As Integer,
        DocNote As String, PaidAmount As Decimal, ReturnAmount As Decimal, DebitInvoice As Boolean,
        VoucherAmountAfterDiscount As Decimal, VoucherReferanceName As String, VoucherReferance As Integer)
        Dim _DocName As Integer = 0
        Dim _VoucherID As Integer = 0
        Dim _DocNote As String = ""
        Dim _VoucherDateTime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _PaidAmount As Integer = 0
        Dim _ReturnAmount As Integer = 0
        Dim _DebitInvoice As Boolean = False
        Dim _VoucherAmountAfterDiscount As Decimal = 0
        Dim _VoucherReferanceName As String = " "
        Dim _VoucherReferance As Integer = 0
        Try
            Dim sql As New SQLControl
            Dim sqlstring As String
            sqlstring = " SELECT TOP (1) [VoucherID]
                                  ,[VoucherDateTime]      ,[VoucherAmount]
                                  ,[VoucherDiscount]      ,[VoucherPC]
                                  ,[VoucherAmountAfterDiscount]      ,[UserNo]
                                  ,[VoucherCode]      ,[VoucherDebit]
                                  ,[VoucherCredit]      ,[VoucherPayType]
                                  ,[VoucherReferanceName]      ,[VoucherReferance]
                                  ,[PayCardName]      ,[VoucherNote]
                                  ,[PosNo]      ,[ShiftID]
                                  ,[DocName]      ,[ID]
                                  ,[VoucherDiscount2]      ,[VoucherCounter]
                                  ,[PaidAmount]      ,[ReturnAmount] 
                           FROM [dbo].[PosVouchers] where VoucherCode='" & DocCode & "'"
            sql.SqlTrueAccountingRunQuery(sqlstring)
            With sql.SQLDS.Tables(0).Rows(0)
                If Not IsDBNull(.Item("DocName")) Then _DocName = .Item("DocName")
                If Not IsDBNull(.Item("VoucherID")) Then _VoucherID = .Item("VoucherID")
                If Not IsDBNull(.Item("VoucherDateTime")) Then _VoucherDateTime = Format(CDate(.Item("VoucherDateTime")), "yyyy-MM-dd HH:mm:ss")
                If Not IsDBNull(.Item("PaidAmount")) Then _PaidAmount = .Item("PaidAmount")
                If Not IsDBNull(.Item("ReturnAmount")) Then _ReturnAmount = .Item("ReturnAmount")
                If Not IsDBNull(.Item("VoucherPayType")) Then
                    If .Item("VoucherPayType") = "CSTMR" Then _DebitInvoice = True
                End If
                If Not IsDBNull(.Item("VoucherAmountAfterDiscount")) Then _VoucherAmountAfterDiscount = .Item("VoucherAmountAfterDiscount")
                If Not IsDBNull(.Item("VoucherReferanceName")) Then _VoucherReferanceName = .Item("VoucherReferanceName")
                If Not IsDBNull(.Item("VoucherNote")) Then _DocNote = .Item("VoucherNote")
                If Not IsDBNull(.Item("VoucherReferance")) Then
                    If Not String.IsNullOrEmpty(.Item("VoucherReferance")) Then
                        _VoucherReferance = .Item("VoucherReferance")
                    Else
                        _VoucherReferance = 0
                    End If
                End If


            End With


        Catch ex As Exception
            _VoucherReferance = 0
        End Try
        Return (_DocName, _VoucherID, _DocNote, _PaidAmount, _ReturnAmount, _DebitInvoice, _VoucherAmountAfterDiscount, _VoucherReferanceName, _VoucherReferance)
    End Function
    Public Sub PrintPosVoucherFromDataBase(_DocCode As String, _Preview As Boolean, Optional DocName As Integer = 0)
        Dim _PrinterSize As Decimal = 300
        _PrinterSize = PosPrinterSize()
        Dim _DocData = GetPosVoucherData(_DocCode)


        Dim _TempDocName As Integer = 2
        _TempDocName = _DocData.DocName
        If _TempDocName = 0 Then _TempDocName = DocName

        Dim _MyCompanyData = GetCompanyData()

        Dim _UseVoucherCounter As Boolean = UseVoucherCount()

        Dim _TempVoucherNote As String = " "
        _TempVoucherNote = _DocData.DocNote

        Dim _PaidAmount As Decimal = 0
        _PaidAmount = _DocData.PaidAmount

        Dim _DebitInvoice As Boolean = False
        _DebitInvoice = _DocData.DebitInvoice

        Dim _VouchertAmountAfterDiscount As Decimal = 0
        _VouchertAmountAfterDiscount = _DocData.VoucherAmountAfterDiscount

        Dim _Customer As String = "  "
        _Customer = _DocData.VoucherReferanceName

        Dim _CustomerBalance As Decimal = 0
        _CustomerBalance = GetReferanceBalance(_DocData.VoucherReferance)

        Dim _AddedNotes = GetVoucherAddedNotes()
        Dim _PosVoucherNote1 As String = _AddedNotes.Note1
        Dim _PosVoucherNote2 As String = _AddedNotes.Note2

        Dim _CustomerNo As String = CStr(_DocData.VoucherReferance)

        Dim _PosNumberOfCopies As Integer = 1
        Dim _CompanyLogo As Image = Nothing

        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyLogo from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            _CompanyLogo = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try



        Dim _PictureEditCompanyQR As Image = Nothing
        Try
            Dim cn As SqlConnection
            cn = New SqlConnection
            cn.ConnectionString = My.Settings.TrueTimeConnectionString
            Dim cmd As New System.Data.SqlClient.SqlCommand("select CompanyQR from [dbo].[CompanyData]  ")
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            Dim ImgStream As New IO.MemoryStream(CType(cmd.ExecuteScalar, Byte()))
            _PictureEditCompanyQR = Image.FromStream(ImgStream)
            ImgStream.Dispose()
            cmd.Connection.Close()
            cn.Close()
        Catch ex As Exception

        End Try



        Dim Sql As New SQLControl
        Dim sqlstring As String
        sqlstring = " Select [DocID],CASE WHEN U.id <> 1 then  concat([ItemName],'/',U.name) else [ItemName] end as ItemName,([DocAmount]+IsNull(VoucherDiscount,0)) as Amount,DocName,DocNoteByAccount,
                                               [StockQuantity] as Quantity ,[StockPrice] as Price,InputDateTime,R.[RefMobile] as RefMobile,
                                               [DocCode],D.EmployeeName as UserName,IsNull([StockDiscount]*StockQuantity,0) as StockDiscount,IsNull(VoucherDiscount,0) as VoucherDiscount,IsNull(VoucherCounter,0) As VoucherCounter
                                        From [dbo].[Journal] J 
                                        Left join EmployeesData D  on D.EmployeeID = J.CurrentUserID 
                                        left join [dbo].[Referencess] R on J.Referance=R.[RefNo]
                                        LEFT JOIN [dbo].[Units] U on U.id=J.StockUnit 
                                        Where 1=1 "
        If _TempDocName = 2 Then sqlstring += "  And [CredAcc]  <> '0' "
        If _TempDocName = 12 Then sqlstring += " And [DebitAcc] <> '0' "
        sqlstring += " and [DocCode]='" & _DocCode & "'"
        Sql.SqlTrueAccountingRunQuery(sqlstring)
        'Select Case _PrinterSize
        '    Case Is >= 500
        'End Select
        If _PrinterSize > 200 And _PrinterSize < 300 Then
            Dim report As New ReportPos() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelCompanyName.Text = _MyCompanyData.CompanyName
                .XrLabelAddress.Text = _MyCompanyData.CompanyAddress
                .XrLabelMobile.Text = _MyCompanyData.CompanyMobile & " " & _MyCompanyData.CompanyPhone
                If _UseVoucherCounter = False Then
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Else
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("VoucherCounter")
                End If
                .XrLabelUserName.Text = "الموظف: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""
                .XrLabelNote.Text = "ملاحظة" & " : " & _TempVoucherNote
                If Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 2 Then .XrLabelVoucherName.Text = "فاتورة مبيعات"
                If Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 12 Then .XrLabelVoucherName.Text = "مردودات مبيعات"
                If _PaidAmount = 0 Then
                    If _DebitInvoice = False Then
                        _PaidAmount = _VouchertAmountAfterDiscount
                        .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                    Else
                        _PaidAmount = 0
                        .XrLabelReturnAmount.Text = 0
                        .XrLabelReturnAmount.Visible = False
                        .XrLabelReturnAmountLabel.Visible = False
                    End If
                End If
                .XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")
                .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                .XrLabelCustomer.Text = "  الزبون: " & _Customer
                If _DebitInvoice = True And GlobalVariables._PosPrintReferanceBalance = True Then
                    .XrLabelCustomer.Text += Environment.NewLine & "( الرصيد يشمل الفاتورة الحالية " & _CustomerBalance & " شيكل )"
                End If
                .PosVoucherNote1.Text = _PosVoucherNote1
                .PosVoucherNote2.Text = _PosVoucherNote2
                report.PageWidth = _PrinterSize
                .XrPictureBox1.Image = _CompanyLogo
                .XrPictureQR.Image = _PictureEditCompanyQR
                If _TempDocName = 12 Then
                    '.XrLabel7.Visible = False
                    '.XrLabel1.Visible = False
                    '.XrLabel8.Visible = False
                    .XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
                End If
            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)
            ' printTool.ShowPreviewDialog()
            For i = 1 To _PosNumberOfCopies
                If _Preview = False Then
                    printTool.Print()
                Else
                    printTool.ShowPreview()
                End If
            Next
            '  printTool.PrinterSettings.Copies = _PosNumberOfCopies
            'printTool.Print()
            _DocCode = ""
            _TempVoucherNote = ""
            _PaidAmount = 0
            _VouchertAmountAfterDiscount = 0
            _Customer = ""
            _CustomerNo = 0
            _CustomerBalance = 0
            _DebitInvoice = False
            _TempDocName = 2

        ElseIf _PrinterSize <= 200 Then
            Dim report As New ReportPosThin() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelCompanyName.Text = _MyCompanyData.CompanyName
                .XrLabelAddress.Text = _MyCompanyData.CompanyAddress
                '.XrLabelMobile.Text = _MyCompanyData.CompanyMobile
                If _UseVoucherCounter = False Then
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Else
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("VoucherCounter")
                End If
                .XrLabelUserName.Text = "الموظف: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""
                .XrLabelNote.Text = "ملاحظة" & " : " & _TempVoucherNote
                If _PaidAmount = 0 Then
                    If _DebitInvoice = False Then
                        _PaidAmount = _VouchertAmountAfterDiscount
                        .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                    Else
                        _PaidAmount = 0
                        .XrLabelReturnAmount.Text = 0
                        .XrLabelReturnAmount.Visible = False
                        .XrLabel10.Visible = False
                    End If
                End If
                '.XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")

                '.XrLabelCustomer.Text = "  الزبون: " & _Customer
                '.PosVoucherNote1.Text = _PosVoucherNote1
                '.PosVoucherNote2.Text = _PosVoucherNote2
                'report.PageWidth = _PrinterSize
                '.XrPictureBox1.Image = Me.CompanyLogo.Image
                '.XrPictureQR.Image = (Me.PictureEditCompanyQR.Image)


                .XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")
                .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                .XrLabelCustomer.Text = "  الزبون: " & _Customer
                If _DebitInvoice = True And GlobalVariables._PosPrintReferanceBalance = True Then
                    .XrLabelCustomer.Text += Environment.NewLine & "( الرصيد يشمل الفاتورة " & _CustomerBalance & " شيكل )"
                End If
                .PosVoucherNote1.Text = _PosVoucherNote1
                .PosVoucherNote2.Text = _PosVoucherNote2
                report.PageWidth = _PrinterSize
                .XrPictureBox1.Image = _CompanyLogo
                .XrPictureQR.Image = _PictureEditCompanyQR
                If _TempDocName = 12 Then
                    '.XrLabel7.Visible = False
                    '.XrLabel1.Visible = False
                    '.XrLabel8.Visible = False
                    .XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
                End If

            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)
            ' printTool.ShowPreviewDialog()
            For i = 1 To _PosNumberOfCopies
                If _Preview = False Then
                    printTool.Print()
                Else
                    printTool.ShowPreview()
                End If
            Next
            ' printTool.Print()
            _DocCode = ""
            _TempVoucherNote = ""
            _PaidAmount = 0
            _VouchertAmountAfterDiscount = 0
            _Customer = ""
            _CustomerNo = 0
            _CustomerBalance = 0
            _DebitInvoice = False
            _TempDocName = 2

        ElseIf _PrinterSize > 300 AndAlso _PrinterSize <= 400 Then 'A5
            Dim report As New ReportPosA5() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelCompanyName.Text = _MyCompanyData.CompanyName
                .XrLabelAddress.Text = _MyCompanyData.CompanyAddress
                '.XrLabelMobile.Text = _MyCompanyData.CompanyMobile
                If _UseVoucherCounter = False Then
                    .XrLabelVoucher.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Else
                    .XrLabelVoucher.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("VoucherCounter")
                End If
                .XrLabelUserName.Text = "الموظف: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""

                .XrLabelNote.Text = "ملاحظة" & " : " & _TempVoucherNote
                If _CustomerNo <> "" Then
                    Dim _RefData = GetRefranceData(_CustomerNo)
                    .XrLabelNote.Text += " " & _RefData.RefMemo
                End If
                .XrLabelDocDateTime.Text = "التاريخ" & " : " & Format(CDate(Sql.SQLDS.Tables(0).Rows(0).Item("InputDateTime")), "yyyy-MM-dd HH:mm")
                If Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 2 Then .XrLabelVoucherName.Text = "سند استلام"
                If Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 12 Then .XrLabelVoucherName.Text = "مردودات مبيعات"
                If _PaidAmount = 0 Then
                    If _DebitInvoice = False Then
                        _PaidAmount = _VouchertAmountAfterDiscount
                        '    .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                    Else
                        _PaidAmount = 0
                        '  .XrLabelReturnAmount.Text = 0
                        ' .XrLabelReturnAmount.Visible = False
                        '  .XrLabel10.Visible = False
                    End If
                End If
                ' .XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")
                ' .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                Dim _refmobile As String = ""
                If Not IsDBNull(Sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")) Then
                    _refmobile = Sql.SQLDS.Tables(0).Rows(0).Item("RefMobile")
                End If
                .XrLabelCustomer.Text = "  " & _Customer
                .XrLabelMobile.Text = "  Tel:" & _refmobile
                If _DebitInvoice = True And GlobalVariables._PosPrintReferanceBalance = True Then
                    .XrLabelRefBalance.Text = " الرصيد يشمل الفاتورة " & _CustomerBalance & " شيكل "
                End If
                '  .XrLabelDocDateTime.Text=
                '.PosVoucherNote1.Text = _PosVoucherNote1
                '.PosVoucherNote2.Text = _PosVoucherNote2
                'report.PageWidth = _PrinterSize
                .XrPictureBox1.Image = _CompanyLogo
                ' .XrPictureQR.Image = (Me.PictureEditCompanyQR.Image)
                If _TempDocName = 12 Then
                    '.XrLabel7.Visible = False
                    '.XrLabel1.Visible = False
                    '.XrLabel8.Visible = False
                    '.XrLabel3.TextFormatString = "{0:الصافي للارجاع: #.0 }"
                End If
            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)
            ' printTool.ShowPreviewDialog()
            printTool.AutoShowParametersPanel = False
            For i = 1 To _PosNumberOfCopies
                If _Preview = False Then
                    printTool.Print()
                Else
                    printTool.ShowPreview()
                End If
            Next
            ' printTool.Print()
            _DocCode = ""
            _TempVoucherNote = ""
            _PaidAmount = 0
            _VouchertAmountAfterDiscount = 0
            _Customer = ""
            _CustomerNo = ""
            _CustomerBalance = 0
            _DebitInvoice = False
            _TempDocName = 2
        ElseIf _PrinterSize = 1000 Then
            Dim report As New ReportPosHebrew() With {.DataSource = Sql.SQLDS.Tables(0)}
            With report
                .ShowPrintMarginsWarning = False
                .PrintingSystem.ShowMarginsWarning = False
                .XrLabelCompanyName.Text = _MyCompanyData.CompanyName
                .XrLabelAddress.Text = _MyCompanyData.CompanyAddress
                .XrLabelMobile.Text = _MyCompanyData.CompanyMobile & " " & _MyCompanyData.CompanyPhone
                If _UseVoucherCounter = False Then
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("DocID")
                Else
                    .XrLabelVoucherNo.Text = "Inv.#: " & Sql.SQLDS.Tables(0).Rows(0).Item("VoucherCounter")
                End If


                .XrLabelUserName.Text = "עוֹבֵד: " & Sql.SQLDS.Tables(0).Rows(0).Item("UserName") & ""
                .XrLabelNote.Text = "הערה: " & _TempVoucherNote

                If Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 2 Then
                    .XrLabelVoucherName.Text = "חשבון מכירה"
                ElseIf Sql.SQLDS.Tables(0).Rows(0).Item("DocName") = 12 Then
                    .XrLabelVoucherName.Text = "החזרות מכירות"
                End If


                'If _PaidAmount = 0 Then
                '    If _DebitInvoice = False Then
                '        _PaidAmount = _VouchertAmountAfterDiscount
                '        .XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")
                '    Else
                '        _PaidAmount = 0
                '        .XrLabelReturnAmount.Text = 0
                '        .XrLabelReturnAmount.Visible = False
                '        .XrLabel10.Visible = False
                '    End If
                'End If
                '.XrLabelPaidAmount.Text = _PaidAmount.ToString("N1")
                '.XrLabelReturnAmount.Text = (_PaidAmount - _VouchertAmountAfterDiscount).ToString("N1")

                ' Translate Arabic customer text to Hebrew
                If _Customer = "زبون نقدي" Then
                    _Customer = "לקוח מזומן"
                End If

                .XrLabelCustomer.Text = "  הלקוח: " & _Customer


                If _DebitInvoice = True AndAlso GlobalVariables._PosPrintReferanceBalance = True Then
                    .XrLabelCustomer.Text += "( היתרה כוללת את החשבון הנוכחי " & _CustomerBalance & " NIS   )"
                End If


                .PosVoucherNote1.Text = _PosVoucherNote1
                .PosVoucherNote2.Text = _PosVoucherNote2
                .PageWidth = 290
                .XrPictureBox1.Image = _CompanyLogo
                If _TempDocName = 12 Then
                    .XrLabel3.TextFormatString = "{0:נטו להחזרה: #.0 }"
                End If

            End With
            SinglePageHelper.GenerateSinglePageReport(report)
            Dim printTool As New ReportPrintTool(report)
            ' printTool.ShowPreviewDialog()
            For i = 1 To _PosNumberOfCopies
                If _Preview = False Then
                    printTool.Print()
                Else
                    printTool.ShowPreview()
                End If
            Next
            '  printTool.PrinterSettings.Copies = _PosNumberOfCopies
            'printTool.Print()
            _DocCode = ""
            _TempVoucherNote = ""
            _PaidAmount = 0
            _VouchertAmountAfterDiscount = 0
            _Customer = ""
            _CustomerNo = 0
            _CustomerBalance = 0
            _DebitInvoice = False
            _TempDocName = 2
        End If

        '    Dim report As New ReportPos() With {.DataSource = Sql.SQLDS.Tables(0)}
        '  Dim report As New ReportPosThin() With {.DataSource = Sql.SQLDS.Tables(0)}


    End Sub
    Public Sub POS_PrintDirectReceipt(_DocID As Integer, _AmountType As String)
        Try
            'Dim _DocDate = GetDocumentHeaderData(_DocID, 4)
            Dim _Report As New ReportPosReceipt
            _Report._DocID = _DocID
            _Report._AmountType = _AmountType

            _Report.Print()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub PosAddLOG(_DocCode As String, _Notes As String)
        'Try
        '    Dim sql As New SQLControl
        '    Dim sqlstring As String
        '    sqlstring = " Insert Into [dbo].[PosLog] ([DocCode],[DocDateTime],[Notes],UserID,PosNo ) Values (
        '                                              '" & _DocCode & "',GetDate(),N'" & _Notes & "','" & GlobalVariables.CurrUser & "','" & My.Settings.POSNo & "') "
        '    sql.SqlTrueAccountingRunQuery(sqlstring)
        'Catch ex As Exception

        'End Try
    End Sub

    Private osk As String = "C:\Windows\System32\osk.exe"
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Public Sub ShowKeyboard()
        Try
            Dim old As Long
            Dim oskPath As String = "C:\Windows\System32\osk.exe"
            Dim tabTipPath As String = "C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe"

            If Environment.Is64BitOperatingSystem Then
                If Wow64DisableWow64FsRedirection(old) Then
                    If IO.File.Exists(oskPath) Then
                        Process.Start(oskPath)
                    ElseIf IO.File.Exists(tabTipPath) Then
                        Process.Start(tabTipPath)
                    End If
                    Wow64EnableWow64FsRedirection(old)
                End If
            Else
                If IO.File.Exists(oskPath) Then
                    Process.Start(oskPath)
                ElseIf IO.File.Exists(tabTipPath) Then
                    Process.Start(tabTipPath)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub PlaySuccessBeepOnPos()
        If GlobalPosVariables._PlayBeep = True Then
            My.Computer.Audio.Play(My.Resources.beep2, AudioPlayMode.Background)
        End If
    End Sub
    Public Sub PlayErrorBeepOnPos()
        If GlobalPosVariables._PlayBeep = True Then
            Console.Beep(2500, 1000)
        End If
    End Sub
End Module
Public Module GlobalPosVariables
    Public _PosAllowMergeItems As Boolean = False
    Public _PlayBeep As Boolean = True
    Public _LastVoucherCode As String = ""
End Module
